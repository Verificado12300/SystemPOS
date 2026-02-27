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
                    WHERE cp.Estado != 'ANULADO'";

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
        // RESUMEN TOTAL
        // ---------------------------------------------------------------

        public static (decimal TotalDeuda, decimal TotalPagado, int CuentasPendientes) ObtenerResumen()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT
                        COALESCE(SUM(MontoTotal), 0),
                        COALESCE(SUM(MontoPagado), 0),
                        COUNT(CASE WHEN Estado NOT IN ('PAGADO','ANULADO') THEN 1 END)
                    FROM CuentasPorPagar
                    WHERE Estado != 'ANULADO'";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return (reader.GetDecimal(0), reader.GetDecimal(1), reader.GetInt32(2));
                    }
                }
            }

            return (0, 0, 0);
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
        // HELPER: mapear row del reader
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
