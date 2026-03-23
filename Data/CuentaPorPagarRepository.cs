using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SistemaPOS.Models;

namespace SistemaPOS.Data
{
    public class CuentaPorPagarConDetalle : CuentaPorPagar
    {
        public string Referencia { get; set; }     // NumeroCompra o Concepto del gasto
        public string NombreProveedor { get; set; }
        public DateTime FechaOrigen { get; set; }  // Fecha de la compra o del gasto
    }

    public class PagoProveedorConDetalle : PagoProveedor
    {
        public string NombreUsuario { get; set; }
        // Anulado ya heredado de PagoProveedor; aquí por claridad en el DGV:
        // Estado = Anulado ? "ANULADO" : "ACTIVO"
    }

    /// <summary>Fila de movimiento cronológico para el Estado de Cuenta Proveedor.</summary>
    public class MovimientoCxP
    {
        public DateTime  Fecha            { get; set; }
        public TimeSpan  Hora             { get; set; }
        public string    Tipo             { get; set; }   // COMPRA | GASTO | PAGO | ANULACION_PAGO
        public string    Documento        { get; set; }
        public string    Metodo           { get; set; }
        public decimal   Cargo            { get; set; }
        public decimal   Abono            { get; set; }
        public decimal   Saldo            { get; set; }   // acumulado (calculado en C#)
        public bool      Anulado          { get; set; }
        public bool      PuedeAnular      { get; set; }   // botón "Anular" en DGV
        public bool      PuedePagar       { get; set; }   // botón "Pagar" en DGV
        public int?      PagoProveedorID  { get; set; }
        public int?      CuentaPorPagarID { get; set; }
        public string    EstadoCxP        { get; set; }   // para COMPRA/GASTO
        public int       OrdenSort        { get; set; }
    }

    /// <summary>Agrupación de CxP por proveedor, para la vista principal.</summary>
    public class ResumenProveedorCxP
    {
        public int?    ProveedorID        { get; set; }
        public string  NombreProveedor    { get; set; }
        public int     CantidadDocumentos { get; set; }
        public decimal TotalCompras       { get; set; }  // SUM(MontoTotal)
        public decimal TotalPagado        { get; set; }  // SUM(MontoPagado)
        public decimal TotalPendiente     { get; set; }  // SUM(MontoPendiente)
        public string  Estado             { get; set; }  // PENDIENTE | CANCELADO
    }

    public class CuentaPorPagarRepository
    {
        // ---------------------------------------------------------------
        // LISTAR
        // ---------------------------------------------------------------

        public static List<CuentaPorPagarConDetalle> Listar(
            int? proveedorID = null,
            string estado = null,
            string busqueda = null,
            string tipoOrigen = null)
        {
            var cuentas = new List<CuentaPorPagarConDetalle>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT cp.CuentaPorPagarID, cp.TipoOrigen, cp.IdOrigen,
                           cp.CompraID, cp.ProveedorID,
                           COALESCE(p.RazonSocial, cp.ProveedorNombre, 'Sin proveedor') AS NombreProveedor,
                           cp.MontoTotal, cp.MontoPagado, cp.MontoPendiente,
                           cp.FechaEmision, cp.FechaVencimiento, cp.Estado,
                           CASE WHEN cp.TipoOrigen = 'COMPRA'
                                THEN COALESCE(c.NumeroCompra, CAST(cp.IdOrigen AS TEXT))
                                ELSE COALESCE(g.Concepto, CAST(cp.IdOrigen AS TEXT))
                           END AS Referencia,
                           CASE WHEN cp.TipoOrigen = 'COMPRA'
                                THEN COALESCE(c.Fecha, cp.FechaEmision)
                                ELSE COALESCE(g.Fecha, cp.FechaEmision)
                           END AS FechaOrigen
                    FROM CuentasPorPagar cp
                    LEFT JOIN Compras     c ON cp.TipoOrigen = 'COMPRA' AND cp.IdOrigen = c.CompraID
                    LEFT JOIN Gastos      g ON cp.TipoOrigen = 'GASTO'  AND cp.IdOrigen = g.GastoID
                    LEFT JOIN Proveedores p ON cp.ProveedorID = p.ProveedorID
                    WHERE cp.Estado != 'ANULADO'
                      AND (cp.Eliminado IS NULL OR cp.Eliminado = 0)";

                if (proveedorID.HasValue && proveedorID.Value > 0)
                    query += " AND cp.ProveedorID = @ProveedorID";
                if (!string.IsNullOrEmpty(estado) && estado != "TODOS")
                    query += " AND cp.Estado = @Estado";
                if (!string.IsNullOrEmpty(tipoOrigen) && tipoOrigen != "TODOS")
                    query += " AND cp.TipoOrigen = @TipoOrigen";
                if (!string.IsNullOrEmpty(busqueda))
                    query += @" AND (COALESCE(c.NumeroCompra,'') LIKE @Busqueda
                                  OR COALESCE(g.Concepto,'') LIKE @Busqueda
                                  OR COALESCE(p.RazonSocial, cp.ProveedorNombre, '') LIKE @Busqueda)";

                query += " ORDER BY cp.Estado ASC, cp.FechaVencimiento ASC";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    if (proveedorID.HasValue && proveedorID.Value > 0)
                        cmd.Parameters.AddWithValue("@ProveedorID", proveedorID.Value);
                    if (!string.IsNullOrEmpty(estado) && estado != "TODOS")
                        cmd.Parameters.AddWithValue("@Estado", estado);
                    if (!string.IsNullOrEmpty(tipoOrigen) && tipoOrigen != "TODOS")
                        cmd.Parameters.AddWithValue("@TipoOrigen", tipoOrigen);
                    if (!string.IsNullOrEmpty(busqueda))
                        cmd.Parameters.AddWithValue("@Busqueda", $"%{busqueda}%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cuentas.Add(MapRow(reader));
                        }
                    }
                }
            }

            return cuentas;
        }

        // ---------------------------------------------------------------
        // LISTAR AGRUPADO POR PROVEEDOR
        // ---------------------------------------------------------------

        public static List<ResumenProveedorCxP> ListarAgrupadoPorProveedor(string busqueda = null)
        {
            var lista = new List<ResumenProveedorCxP>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT
                        cp.ProveedorID,
                        COALESCE(p.RazonSocial, cp.ProveedorNombre, 'Sin proveedor') AS NombreProveedor,
                        COUNT(*)               AS CantidadDocumentos,
                        SUM(cp.MontoTotal)     AS TotalCompras,
                        SUM(cp.MontoPagado)    AS TotalPagado,
                        SUM(cp.MontoPendiente) AS TotalPendiente
                    FROM CuentasPorPagar cp
                    LEFT JOIN Proveedores p ON cp.ProveedorID = p.ProveedorID
                    WHERE cp.Estado != 'ANULADO'
                      AND (cp.Eliminado IS NULL OR cp.Eliminado = 0)";

                if (!string.IsNullOrWhiteSpace(busqueda))
                    query += @" AND (COALESCE(p.RazonSocial, cp.ProveedorNombre, '') LIKE @Busqueda)";

                query += @"
                    GROUP BY cp.ProveedorID,
                             COALESCE(p.RazonSocial, cp.ProveedorNombre, 'Sin proveedor')
                    ORDER BY SUM(cp.MontoPendiente) DESC,
                             COALESCE(p.RazonSocial, cp.ProveedorNombre, 'Sin proveedor') ASC";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    if (!string.IsNullOrWhiteSpace(busqueda))
                        cmd.Parameters.AddWithValue("@Busqueda", $"%{busqueda.Trim()}%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decimal totalPendiente = reader.IsDBNull(5) ? 0m : Convert.ToDecimal(reader.GetValue(5));
                            lista.Add(new ResumenProveedorCxP
                            {
                                ProveedorID        = reader.IsDBNull(0) ? (int?)null : reader.GetInt32(0),
                                NombreProveedor    = reader.GetString(1),
                                CantidadDocumentos = reader.GetInt32(2),
                                TotalCompras       = reader.IsDBNull(3) ? 0m : Convert.ToDecimal(reader.GetValue(3)),
                                TotalPagado        = reader.IsDBNull(4) ? 0m : Convert.ToDecimal(reader.GetValue(4)),
                                TotalPendiente     = totalPendiente,
                                Estado             = totalPendiente > 0.001m ? "PENDIENTE" : "CANCELADO"
                            });
                        }
                    }
                }
            }

            return lista;
        }

        // ---------------------------------------------------------------
        // OBTENER POR ID
        // ---------------------------------------------------------------

        public static CuentaPorPagarConDetalle ObtenerPorID(int cuentaPorPagarID)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT cp.CuentaPorPagarID, cp.TipoOrigen, cp.IdOrigen,
                           cp.CompraID, cp.ProveedorID,
                           COALESCE(p.RazonSocial, cp.ProveedorNombre, 'Sin proveedor') AS NombreProveedor,
                           cp.MontoTotal, cp.MontoPagado, cp.MontoPendiente,
                           cp.FechaEmision, cp.FechaVencimiento, cp.Estado,
                           CASE WHEN cp.TipoOrigen = 'COMPRA'
                                THEN COALESCE(c.NumeroCompra, CAST(cp.IdOrigen AS TEXT))
                                ELSE COALESCE(g.Concepto, CAST(cp.IdOrigen AS TEXT))
                           END AS Referencia,
                           CASE WHEN cp.TipoOrigen = 'COMPRA'
                                THEN COALESCE(c.Fecha, cp.FechaEmision)
                                ELSE COALESCE(g.Fecha, cp.FechaEmision)
                           END AS FechaOrigen
                    FROM CuentasPorPagar cp
                    LEFT JOIN Compras     c ON cp.TipoOrigen = 'COMPRA' AND cp.IdOrigen = c.CompraID
                    LEFT JOIN Gastos      g ON cp.TipoOrigen = 'GASTO'  AND cp.IdOrigen = g.GastoID
                    LEFT JOIN Proveedores p ON cp.ProveedorID = p.ProveedorID
                    WHERE cp.CuentaPorPagarID = @CuentaPorPagarID";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CuentaPorPagarID", cuentaPorPagarID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return MapRow(reader);
                    }
                }
            }

            return null;
        }

        // ---------------------------------------------------------------
        // REGISTRAR PAGO (con asiento contable)
        // ---------------------------------------------------------------

        public static bool RegistrarPago(PagoProveedor pago)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        if (pago.Monto <= 0)
                            throw new Exception("El monto del pago debe ser mayor a cero.");

                        // Leer saldo pendiente y referencia para el asiento
                        decimal montoPendienteActual;
                        string referencia = "";
                        string tipoOrigen = "COMPRA";

                        using (var cmdSaldo = new SQLiteCommand(
                            @"SELECT cp.MontoPendiente, cp.TipoOrigen,
                                     CASE WHEN cp.TipoOrigen='COMPRA'
                                          THEN COALESCE(c.NumeroCompra, CAST(cp.IdOrigen AS TEXT))
                                          ELSE COALESCE(g.Concepto, CAST(cp.IdOrigen AS TEXT))
                                     END AS Ref
                              FROM CuentasPorPagar cp
                              LEFT JOIN Compras c ON cp.TipoOrigen='COMPRA' AND cp.IdOrigen=c.CompraID
                              LEFT JOIN Gastos  g ON cp.TipoOrigen='GASTO'  AND cp.IdOrigen=g.GastoID
                              WHERE cp.CuentaPorPagarID = @CuentaPorPagarID",
                            connection, transaction))
                        {
                            cmdSaldo.Parameters.AddWithValue("@CuentaPorPagarID", pago.CuentaPorPagarID);
                            using (var r = cmdSaldo.ExecuteReader())
                            {
                                if (!r.Read())
                                    throw new Exception("La cuenta por pagar no existe.");
                                montoPendienteActual = r.GetDecimal(0);
                                tipoOrigen = r.IsDBNull(1) ? "COMPRA" : r.GetString(1);
                                referencia = r.IsDBNull(2) ? "" : r.GetString(2);
                            }
                        }

                        if (pago.Monto > montoPendienteActual)
                            throw new Exception("El monto del pago excede el saldo pendiente actual.");

                        // INSERT PagosProveedores
                        string queryPago = @"
                            INSERT INTO PagosProveedores
                                (CuentaPorPagarID, Fecha, Hora, Monto, MetodoPago,
                                 Comprobante, Observaciones, Referencia, UsuarioID)
                            VALUES
                                (@CuentaPorPagarID, @Fecha, @Hora, @Monto, @MetodoPago,
                                 @Comprobante, @Observaciones, @Referencia, @UsuarioID)";

                        using (var cmd = new SQLiteCommand(queryPago, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@CuentaPorPagarID", pago.CuentaPorPagarID);
                            cmd.Parameters.AddWithValue("@Fecha", pago.Fecha.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@Hora", $"{pago.Hora.Hours:D2}:{pago.Hora.Minutes:D2}:{pago.Hora.Seconds:D2}");
                            cmd.Parameters.AddWithValue("@Monto", pago.Monto);
                            cmd.Parameters.AddWithValue("@MetodoPago", pago.MetodoPago);
                            cmd.Parameters.AddWithValue("@Comprobante",   (object)pago.Comprobante   ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Observaciones", (object)pago.Observaciones ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Referencia",    (object)pago.Referencia    ?? (object)referencia);
                            cmd.Parameters.AddWithValue("@UsuarioID", pago.UsuarioID);
                            cmd.ExecuteNonQuery();
                        }

                        long pagoID = connection.LastInsertRowId;

                        // UPDATE CuentasPorPagar
                        string queryUpdate = @"
                            UPDATE CuentasPorPagar
                            SET MontoPagado    = MontoPagado + @Monto,
                                MontoPendiente = MontoPendiente - @Monto,
                                Estado = CASE
                                    WHEN MontoPendiente - @Monto <= 0 THEN 'PAGADO'
                                    ELSE 'PARCIAL'
                                END,
                                UpdatedAt = @Now
                            WHERE CuentaPorPagarID = @CuentaPorPagarID
                              AND Estado NOT IN ('PAGADO','ANULADO')
                              AND MontoPendiente >= @Monto";

                        using (var cmd = new SQLiteCommand(queryUpdate, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Monto", pago.Monto);
                            cmd.Parameters.AddWithValue("@CuentaPorPagarID", pago.CuentaPorPagarID);
                            cmd.Parameters.AddWithValue("@Now", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            int filas = cmd.ExecuteNonQuery();
                            if (filas == 0)
                                throw new Exception("No se pudo aplicar el pago porque la cuenta cambió, ya está pagada o anulada.");
                        }

                        // Asiento contable: Dr 200 / Cr 101|102
                        ContabilidadService.PagarCuentaPorPagar(
                            pagoID, pago.CuentaPorPagarID, referencia,
                            pago.Fecha, pago.Hora,
                            pago.Monto, pago.MetodoPago, pago.UsuarioID,
                            connection, transaction);

                        // Guardar AsientoId en PagosProveedores
                        long asientoId = connection.LastInsertRowId;
                        using (var cmd = new SQLiteCommand(
                            "UPDATE PagosProveedores SET AsientoId = @AsientoId WHERE PagoProveedorID = @PagoID",
                            connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@AsientoId", asientoId);
                            cmd.Parameters.AddWithValue("@PagoID", pagoID);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // ---------------------------------------------------------------
        // CREAR DESDE GASTO (al crédito)
        // ---------------------------------------------------------------

        public static void CrearDesdeGasto(Gasto gasto, long gastoID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string fechaStr = gasto.Fecha.ToString("yyyy-MM-dd");

            // Obtener nombre del proveedor si aplica
            string proveedorNombre = "Sin proveedor";
            if (gasto.ProveedorID.HasValue)
            {
                using (var cmd = new SQLiteCommand(
                    "SELECT RazonSocial FROM Proveedores WHERE ProveedorID = @ID",
                    conn, tx))
                {
                    cmd.Parameters.AddWithValue("@ID", gasto.ProveedorID.Value);
                    var r = cmd.ExecuteScalar();
                    if (r != null && r != DBNull.Value)
                        proveedorNombre = r.ToString();
                }
            }

            using (var cmd = new SQLiteCommand(@"
                INSERT INTO CuentasPorPagar
                    (TipoOrigen, IdOrigen, ProveedorID, ProveedorNombre,
                     MontoTotal, MontoPagado, MontoPendiente,
                     FechaEmision, FechaVencimiento, Estado,
                     CreatedAt, UpdatedAt)
                VALUES
                    ('GASTO', @GastoID, @ProveedorID, @ProveedorNombre,
                     @Monto, 0, @Monto,
                     @Fecha, NULL, 'PENDIENTE',
                     @Now, @Now)",
                conn, tx))
            {
                cmd.Parameters.AddWithValue("@GastoID",          gastoID);
                cmd.Parameters.AddWithValue("@ProveedorID",      (object)gasto.ProveedorID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ProveedorNombre",  proveedorNombre);
                cmd.Parameters.AddWithValue("@Monto",            gasto.Monto);
                cmd.Parameters.AddWithValue("@Fecha",            fechaStr);
                cmd.Parameters.AddWithValue("@Now",              now);
                cmd.ExecuteNonQuery();
            }
        }

        // ---------------------------------------------------------------
        // MARCAR ANULADA (para uso al anular Compra o Gasto)
        // ---------------------------------------------------------------

        public static void MarcarAnulada(int cxpId, SQLiteConnection conn, SQLiteTransaction tx)
        {
            using (var cmd = new SQLiteCommand(@"
                UPDATE CuentasPorPagar
                SET Estado = 'ANULADO', UpdatedAt = @Now
                WHERE CuentaPorPagarID = @CxpId",
                conn, tx))
            {
                cmd.Parameters.AddWithValue("@CxpId", cxpId);
                cmd.Parameters.AddWithValue("@Now", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.ExecuteNonQuery();
            }
        }

        // ---------------------------------------------------------------
        // OBTENER INFO PAGOS (para mensajes de bloqueo de anulación)
        // ---------------------------------------------------------------

        /// <summary>
        /// Retorna (tienePagos, cantidadPagos, totalPagado) para el mensaje de bloqueo.
        /// </summary>
        public static (bool Tiene, int Cantidad, decimal Total) ObtenerInfoPagos(
            int cxpId, SQLiteConnection conn, SQLiteTransaction tx)
        {
            using (var cmd = new SQLiteCommand(@"
                SELECT COUNT(*), COALESCE(SUM(Monto), 0)
                FROM PagosProveedores
                WHERE CuentaPorPagarID = @CxpId AND Anulado = 0",
                conn, tx))
            {
                cmd.Parameters.AddWithValue("@CxpId", cxpId);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        int cantidad = r.GetInt32(0);
                        decimal total = r.GetDecimal(1);
                        return (cantidad > 0, cantidad, total);
                    }
                }
            }
            return (false, 0, 0m);
        }

        // ---------------------------------------------------------------
        // OBTENER PAGOS DE UNA CXP
        // ---------------------------------------------------------------

        public static List<PagoProveedorConDetalle> ObtenerPagos(int cuentaPorPagarID)
        {
            var pagos = new List<PagoProveedorConDetalle>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT pp.PagoProveedorID, pp.CuentaPorPagarID, pp.Fecha, pp.Hora,
                           pp.Monto, pp.MetodoPago, pp.Comprobante, pp.Observaciones,
                           pp.UsuarioID, u.NombreCompleto as NombreUsuario,
                           pp.Referencia, pp.AsientoId, pp.Anulado
                    FROM PagosProveedores pp
                    INNER JOIN Usuarios u ON pp.UsuarioID = u.UsuarioID
                    WHERE pp.CuentaPorPagarID = @CuentaPorPagarID
                    ORDER BY pp.Fecha DESC, pp.Hora DESC";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CuentaPorPagarID", cuentaPorPagarID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pagos.Add(new PagoProveedorConDetalle
                            {
                                PagoProveedorID  = reader.GetInt32(0),
                                CuentaPorPagarID = reader.GetInt32(1),
                                Fecha            = DateTime.Parse(reader.GetString(2)),
                                Hora             = TimeSpan.Parse(reader.GetString(3)),
                                Monto            = reader.GetDecimal(4),
                                MetodoPago       = reader.GetString(5),
                                Comprobante      = reader.IsDBNull(6)  ? "" : reader.GetString(6),
                                Observaciones    = reader.IsDBNull(7)  ? "" : reader.GetString(7),
                                UsuarioID        = reader.GetInt32(8),
                                NombreUsuario    = reader.GetString(9),
                                Referencia       = reader.IsDBNull(10) ? "" : reader.GetString(10),
                                AsientoId        = reader.IsDBNull(11) ? (int?)null : reader.GetInt32(11),
                                Anulado          = reader.GetInt32(12) == 1
                            });
                        }
                    }
                }
            }

            return pagos;
        }

        // ---------------------------------------------------------------
        // ANULAR PAGO
        // ---------------------------------------------------------------

        /// <summary>
        /// Anula un pago de CxP: genera asiento inverso Dr 101/102 / Cr 200,
        /// marca el pago como Anulado=1 y recalcula montos y estado de la CxP.
        /// </summary>
        public static void AnularPago(int pagoID, int usuarioID)
        {
            using (var connection = DatabaseConnection.GetConnection())
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // 1. Leer datos del pago con referencia de la CxP asociada
                    int    cxpId;
                    DateTime fecha;
                    TimeSpan hora;
                    decimal monto;
                    string metodo;
                    string referencia;

                    using (var cmd = new SQLiteCommand(@"
                        SELECT pp.PagoProveedorID, pp.CuentaPorPagarID, pp.Fecha, pp.Hora,
                               pp.Monto, pp.MetodoPago, pp.Anulado,
                               COALESCE(
                                   CASE WHEN cp.TipoOrigen='COMPRA' THEN c.NumeroCompra
                                        ELSE g.Concepto END,
                                   'CxP-' || pp.CuentaPorPagarID
                               ) AS Referencia
                        FROM PagosProveedores pp
                        INNER JOIN CuentasPorPagar cp ON pp.CuentaPorPagarID = cp.CuentaPorPagarID
                        LEFT  JOIN Compras  c ON cp.TipoOrigen='COMPRA' AND cp.IdOrigen = c.CompraID
                        LEFT  JOIN Gastos   g ON cp.TipoOrigen='GASTO'  AND cp.IdOrigen = g.GastoID
                        WHERE pp.PagoProveedorID = @pagoID",
                        connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@pagoID", pagoID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                                throw new Exception("Pago no encontrado.");
                            if (reader.GetInt32(6) == 1)
                                throw new Exception("El pago ya está anulado.");

                            cxpId     = reader.GetInt32(1);
                            fecha     = DateTime.Parse(reader.GetString(2));
                            hora      = TimeSpan.Parse(reader.GetString(3));
                            monto     = reader.GetDecimal(4);
                            metodo    = reader.GetString(5);
                            referencia = reader.IsDBNull(7) ? "" : reader.GetString(7);
                        }
                    }

                    // 2. Asiento inverso: Dr 101/102 / Cr 200
                    ContabilidadService.ReversarPagoCxP(
                        pagoID, cxpId, referencia,
                        fecha, hora, monto, metodo,
                        usuarioID, connection, transaction);

                    // 3. Marcar pago como anulado
                    using (var cmd = new SQLiteCommand(
                        "UPDATE PagosProveedores SET Anulado=1 WHERE PagoProveedorID=@id",
                        connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", pagoID);
                        cmd.ExecuteNonQuery();
                    }

                    // 4. Recalcular montos y estado de la CxP (solo pagos no anulados)
                    string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    using (var cmd = new SQLiteCommand(@"
                        UPDATE CuentasPorPagar SET
                            MontoPagado    = COALESCE((SELECT SUM(Monto) FROM PagosProveedores
                                                       WHERE CuentaPorPagarID = @cxpId AND Anulado = 0), 0),
                            MontoPendiente = MontoTotal
                                           - COALESCE((SELECT SUM(Monto) FROM PagosProveedores
                                                       WHERE CuentaPorPagarID = @cxpId AND Anulado = 0), 0),
                            Estado         = CASE
                                WHEN MontoTotal - COALESCE((SELECT SUM(Monto) FROM PagosProveedores
                                                       WHERE CuentaPorPagarID = @cxpId AND Anulado = 0), 0) <= 0
                                     THEN 'PAGADO'
                                WHEN COALESCE((SELECT SUM(Monto) FROM PagosProveedores
                                                       WHERE CuentaPorPagarID = @cxpId AND Anulado = 0), 0) = 0
                                     THEN 'PENDIENTE'
                                ELSE 'PARCIAL'
                            END,
                            UpdatedAt      = @now
                        WHERE CuentaPorPagarID = @cxpId",
                        connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@cxpId", cxpId);
                        cmd.Parameters.AddWithValue("@now", now);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        // ---------------------------------------------------------------
        // MOVIMIENTOS CRONOLÓGICOS (Estado de Cuenta Proveedor)
        // ---------------------------------------------------------------

        /// <summary>
        /// Devuelve todos los movimientos cronológicos de un proveedor dentro del rango
        /// de fechas, con saldo acumulado calculado en C#.
        /// </summary>
        public static List<MovimientoCxP> ObtenerMovimientosCuentaProveedor(
            int? proveedorID, DateTime desde, DateTime hasta, string busqueda = null)
        {
            string desdeStr = desde.ToString("yyyy-MM-dd");
            string hastaStr = hasta.ToString("yyyy-MM-dd");

            string whereProv = proveedorID.HasValue
                ? "AND cp.ProveedorID = @provID"
                : "AND (cp.ProveedorID IS NULL OR cp.ProveedorID = 0)";

            var raw = new List<MovimientoCxP>();

            using (var conn = DatabaseConnection.GetConnection())
            {
                // ── 1. Documentos (COMPRA / GASTO) ───────────────────────
                string qDocs = $@"
                    SELECT
                        cp.CuentaPorPagarID,
                        cp.TipoOrigen,
                        cp.Estado,
                        cp.MontoTotal,
                        COALESCE(
                            CASE WHEN cp.TipoOrigen='COMPRA' THEN c.NumeroCompra
                                 ELSE g.Concepto END,
                            'CxP-' || cp.CuentaPorPagarID
                        ) AS Documento,
                        COALESCE(c.Fecha, g.Fecha, cp.FechaEmision, '') AS FechaOrigen
                    FROM CuentasPorPagar cp
                    LEFT JOIN Compras c ON cp.TipoOrigen='COMPRA' AND cp.IdOrigen = c.CompraID
                    LEFT JOIN Gastos  g ON cp.TipoOrigen='GASTO'  AND cp.IdOrigen = g.GastoID
                    WHERE cp.Estado != 'ANULADO'
                      AND (cp.Eliminado IS NULL OR cp.Eliminado = 0)
                      {whereProv}
                      AND COALESCE(c.Fecha, g.Fecha, cp.FechaEmision, '') BETWEEN @desde AND @hasta
                    ORDER BY FechaOrigen ASC";

                using (var cmd = new SQLiteCommand(qDocs, conn))
                {
                    if (proveedorID.HasValue)
                        cmd.Parameters.AddWithValue("@provID", proveedorID.Value);
                    cmd.Parameters.AddWithValue("@desde", desdeStr);
                    cmd.Parameters.AddWithValue("@hasta", hastaStr);

                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            string tipo     = r.IsDBNull(1) ? "COMPRA" : r.GetString(1);
                            string estado   = r.GetString(2);
                            decimal monto   = r.GetDecimal(3);
                            string doc      = r.IsDBNull(4) ? "" : r.GetString(4);
                            string fechaStr = r.IsDBNull(5) ? DateTime.Now.ToString("yyyy-MM-dd") : r.GetString(5);
                            DateTime.TryParse(fechaStr, out DateTime fecha);

                            raw.Add(new MovimientoCxP
                            {
                                Fecha            = fecha,
                                Hora             = TimeSpan.Zero,
                                Tipo             = tipo,
                                Documento        = doc,
                                Metodo           = "",
                                Cargo            = monto,
                                PuedePagar       = estado != "PAGADO" && estado != "ANULADO",
                                CuentaPorPagarID = r.GetInt32(0),
                                EstadoCxP        = estado,
                                OrdenSort        = 0
                            });
                        }
                    }
                }

                // ── 2. Pagos ─────────────────────────────────────────────
                string qPagos = $@"
                    SELECT
                        pp.PagoProveedorID,
                        pp.Fecha,
                        pp.Hora,
                        pp.Monto,
                        pp.MetodoPago,
                        pp.Anulado,
                        cp.CuentaPorPagarID,
                        COALESCE(
                            CASE WHEN cp.TipoOrigen='COMPRA' THEN c.NumeroCompra
                                 ELSE g.Concepto END,
                            'CxP-' || cp.CuentaPorPagarID
                        ) AS Documento
                    FROM PagosProveedores pp
                    INNER JOIN CuentasPorPagar cp ON pp.CuentaPorPagarID = cp.CuentaPorPagarID
                    LEFT JOIN Compras c ON cp.TipoOrigen='COMPRA' AND cp.IdOrigen = c.CompraID
                    LEFT JOIN Gastos  g ON cp.TipoOrigen='GASTO'  AND cp.IdOrigen = g.GastoID
                    WHERE cp.Estado != 'ANULADO'
                      AND (cp.Eliminado IS NULL OR cp.Eliminado = 0)
                      {whereProv}
                      AND pp.Fecha BETWEEN @desde AND @hasta
                    ORDER BY pp.Fecha ASC, pp.Hora ASC";

                using (var cmd = new SQLiteCommand(qPagos, conn))
                {
                    if (proveedorID.HasValue)
                        cmd.Parameters.AddWithValue("@provID", proveedorID.Value);
                    cmd.Parameters.AddWithValue("@desde", desdeStr);
                    cmd.Parameters.AddWithValue("@hasta", hastaStr);

                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            int pagoID    = r.GetInt32(0);
                            string fechaS = r.GetString(1);
                            string horaS  = r.IsDBNull(2) ? "00:00:00" : r.GetString(2);
                            decimal monto = r.GetDecimal(3);
                            string metodo = r.IsDBNull(4) ? "" : r.GetString(4);
                            bool anulado  = r.GetInt32(5) == 1;
                            int cxpId     = r.GetInt32(6);
                            string doc    = r.IsDBNull(7) ? "" : r.GetString(7);

                            DateTime.TryParse(fechaS, out DateTime fecha);
                            TimeSpan.TryParse(horaS,  out TimeSpan hora);

                            if (anulado)
                            {
                                // Pago anulado → fila PAGO (abono) + fila ANULACION_PAGO (cargo)
                                raw.Add(new MovimientoCxP
                                {
                                    Fecha = fecha, Hora = hora, Tipo = "PAGO",
                                    Documento = doc, Metodo = metodo,
                                    Abono = monto, Anulado = true, PuedeAnular = false,
                                    PagoProveedorID = pagoID, CuentaPorPagarID = cxpId,
                                    OrdenSort = 1
                                });
                                raw.Add(new MovimientoCxP
                                {
                                    Fecha = fecha, Hora = hora, Tipo = "ANULACION_PAGO",
                                    Documento = doc, Metodo = metodo,
                                    Cargo = monto, Anulado = true, PuedeAnular = false,
                                    PagoProveedorID = pagoID, CuentaPorPagarID = cxpId,
                                    OrdenSort = 2
                                });
                            }
                            else
                            {
                                raw.Add(new MovimientoCxP
                                {
                                    Fecha = fecha, Hora = hora, Tipo = "PAGO",
                                    Documento = doc, Metodo = metodo,
                                    Abono = monto, PuedeAnular = true,
                                    PagoProveedorID = pagoID, CuentaPorPagarID = cxpId,
                                    OrdenSort = 1
                                });
                            }
                        }
                    }
                }
            }

            // ── 3. Ordenar por fecha+hora+orden y calcular saldo ─────────
            raw.Sort((a, b) =>
            {
                int c = a.Fecha.CompareTo(b.Fecha);
                if (c != 0) return c;
                c = a.Hora.CompareTo(b.Hora);
                if (c != 0) return c;
                return a.OrdenSort.CompareTo(b.OrdenSort);
            });

            // ── 4. Filtro búsqueda (en memoria) ─────────────────────────
            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                string b = busqueda.ToLower();
                raw.RemoveAll(m =>
                    !m.Documento.ToLower().Contains(b) &&
                    !m.Tipo.ToLower().Contains(b) &&
                    !(m.Metodo ?? "").ToLower().Contains(b));
            }

            // ── 5. Calcular saldo acumulado ──────────────────────────────
            decimal saldo = 0;
            foreach (var mov in raw)
            {
                saldo += mov.Cargo - mov.Abono;
                mov.Saldo = saldo;
            }

            return raw;
        }

        // ---------------------------------------------------------------
        // HELPER: mapear row del reader
        // ---------------------------------------------------------------

        // ---------------------------------------------------------------
        // ELIMINAR (soft-delete)
        // ---------------------------------------------------------------

        /// <summary>
        /// Soft-delete de una cuenta por pagar. Bloquea si tiene pagos activos.
        /// </summary>
        public static bool Eliminar(int cuentaPorPagarID)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                // Guard: no eliminar si tiene pagos activos no anulados
                int nPagos;
                using (var cmd = new SQLiteCommand(
                    "SELECT COUNT(*) FROM PagosProveedores " +
                    "WHERE CuentaPorPagarID=@id AND Anulado=0",
                    conn))
                {
                    cmd.Parameters.AddWithValue("@id", cuentaPorPagarID);
                    nPagos = Convert.ToInt32(cmd.ExecuteScalar());
                }
                if (nPagos > 0)
                    throw new InvalidOperationException(
                        "No se puede eliminar esta cuenta porque ya tiene pagos registrados.\n" +
                        "Anule primero los pagos para poder eliminar la cuenta.");

                string now  = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string user = SistemaPOS.Utils.SesionActual.Usuario?.NombreUsuario ?? "Sistema";

                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new SQLiteCommand(
                            "UPDATE CuentasPorPagar SET Eliminado=1, FechaEliminado=@f " +
                            "WHERE CuentaPorPagarID=@id",
                            conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@f",  now);
                            cmd.Parameters.AddWithValue("@id", cuentaPorPagarID);
                            cmd.ExecuteNonQuery();
                        }

                        PapeleraService.InsertarLog(
                            "CXP", cuentaPorPagarID, "ELIMINAR", now, user,
                            $"CxP #{cuentaPorPagarID}", conn, tx);

                        tx.Commit();
                        return true;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        // ---------------------------------------------------------------

        private static CuentaPorPagarConDetalle MapRow(SQLiteDataReader r)
        {
            return new CuentaPorPagarConDetalle
            {
                CuentaPorPagarID = r.GetInt32(0),
                TipoOrigen       = r.IsDBNull(1) ? "COMPRA" : r.GetString(1),
                IdOrigen         = r.IsDBNull(2) ? 0 : r.GetInt32(2),
                CompraID         = r.IsDBNull(3) ? (int?)null : r.GetInt32(3),
                ProveedorID      = r.IsDBNull(4) ? (int?)null : r.GetInt32(4),
                NombreProveedor  = r.IsDBNull(5) ? "Sin proveedor" : r.GetString(5),
                MontoTotal       = r.GetDecimal(6),
                MontoPagado      = r.GetDecimal(7),
                MontoPendiente   = r.GetDecimal(8),
                FechaEmision     = r.IsDBNull(9)  ? "" : r.GetString(9),
                FechaVencimiento = r.IsDBNull(10) ? (DateTime?)null : DateTime.Parse(r.GetString(10)),
                Estado           = r.GetString(11),
                Referencia       = r.IsDBNull(12) ? "" : r.GetString(12),
                FechaOrigen      = r.IsDBNull(13) ? DateTime.MinValue
                                    : (DateTime.TryParse(r.GetString(13), out var dt) ? dt : DateTime.MinValue)
            };
        }
    }
}
