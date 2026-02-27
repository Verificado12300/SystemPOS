using SistemaPOS.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaPOS.Data
{
    public class VentaRepository
    {
        public static string GenerarNumeroVenta()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT COALESCE(MAX(CAST(SUBSTR(NumeroVenta, 6) AS INTEGER)), 0) + 1 FROM Ventas WHERE SUBSTR(NumeroVenta, 1, 4) = @Anio";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Anio", DateTime.Now.Year.ToString());

                        var _r = cmd.ExecuteScalar();
                        int siguiente = (_r != null && _r != DBNull.Value) ? Convert.ToInt32(_r) : 1;
                        return $"{DateTime.Now.Year}-{siguiente:D6}";
                    }
                }
            }
            catch
            {
                return $"{DateTime.Now.Year}-{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            }
        }

        public static bool Crear(Venta venta, List<VentaDetalle> detalles)
        {
            const int maxIntentos = 5;

            for (int intento = 1; intento <= maxIntentos; intento++)
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            if (string.IsNullOrWhiteSpace(venta.NumeroVenta))
                                venta.NumeroVenta = GenerarNumeroVentaConConexion(connection, transaction, DateTime.Now.Year);

                            string queryVenta = @"
                                INSERT INTO Ventas (
                                NumeroVenta, Fecha, Hora, ClienteID, TipoComprobante, Serie, Numero,
                                SubTotal, IGV, TipoIGV, BaseImponible, Total,
                                MetodoPago, MontoEfectivo, MontoYape, MontoTarjeta,
                                MontoTransferencia, Estado, CajaID, UsuarioID
                            ) VALUES (
                                @NumeroVenta, @Fecha, @Hora, @ClienteID, @TipoComprobante, @Serie, @Numero,
                                @SubTotal, @IGV, @TipoIGV, @BaseImponible, @Total,
                                @MetodoPago, @MontoEfectivo, @MontoYape, @MontoTarjeta,
                                @MontoTransferencia, @Estado, @CajaID, @UsuarioID
                            )";

                            using (var cmd = new SQLiteCommand(queryVenta, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@NumeroVenta", venta.NumeroVenta);
                                cmd.Parameters.AddWithValue("@Fecha", venta.Fecha.ToString("yyyy-MM-dd"));
                                cmd.Parameters.AddWithValue("@Hora", $"{venta.Hora.Hours:D2}:{venta.Hora.Minutes:D2}:{venta.Hora.Seconds:D2}");
                                cmd.Parameters.AddWithValue("@ClienteID", venta.ClienteID);
                                cmd.Parameters.AddWithValue("@TipoComprobante", venta.TipoComprobante);
                                cmd.Parameters.AddWithValue("@Serie", venta.Serie);
                                cmd.Parameters.AddWithValue("@Numero", venta.Numero);
                                cmd.Parameters.AddWithValue("@SubTotal",      venta.SubTotal);
                                cmd.Parameters.AddWithValue("@IGV",           venta.IGV);
                                cmd.Parameters.AddWithValue("@TipoIGV",       venta.TipoIGV);
                                cmd.Parameters.AddWithValue("@BaseImponible", venta.BaseImponible);
                                cmd.Parameters.AddWithValue("@Total",         venta.Total);
                                cmd.Parameters.AddWithValue("@MetodoPago", venta.MetodoPago);
                                cmd.Parameters.AddWithValue("@MontoEfectivo", venta.MontoEfectivo);
                                cmd.Parameters.AddWithValue("@MontoYape", venta.MontoYape);
                                cmd.Parameters.AddWithValue("@MontoTarjeta", venta.MontoTarjeta);
                                cmd.Parameters.AddWithValue("@MontoTransferencia", venta.MontoTransferencia);
                                cmd.Parameters.AddWithValue("@Estado", venta.Estado);
                                cmd.Parameters.AddWithValue("@CajaID", venta.CajaID);
                                cmd.Parameters.AddWithValue("@UsuarioID", venta.UsuarioID);

                                cmd.ExecuteNonQuery();
                            }

                            long ventaID = connection.LastInsertRowId;

                            foreach (var detalle in detalles)
                            {
                                string queryDetalle = @"
                                INSERT INTO VentaDetalles (
                                    VentaID, ProductoID, ProductoPresentacionID, Cantidad, PrecioUnitario, Subtotal, CantidadUnidadesBase
                                ) VALUES (
                                    @VentaID, @ProductoID, @ProductoPresentacionID, @Cantidad, @PrecioUnitario, @Subtotal, @CantidadUnidadesBase
                                )";

                                using (var cmd = new SQLiteCommand(queryDetalle, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@VentaID", ventaID);
                                    cmd.Parameters.AddWithValue("@ProductoID", detalle.ProductoID);
                                    cmd.Parameters.AddWithValue("@ProductoPresentacionID", detalle.ProductoPresentacionID);
                                    cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                                    cmd.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);
                                    cmd.Parameters.AddWithValue("@Subtotal", detalle.Subtotal);
                                    cmd.Parameters.AddWithValue("@CantidadUnidadesBase", detalle.CantidadUnidadesBase);

                                    cmd.ExecuteNonQuery();
                                }

                                // Descuento atómico de stock para evitar sobreventa por concurrencia
                                string queryStock = @"
                                    UPDATE Productos
                                    SET StockTotal = StockTotal - @Cantidad
                                    WHERE ProductoID = @ProductoID
                                      AND StockTotal >= @Cantidad";
                                using (var cmd = new SQLiteCommand(queryStock, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Cantidad", detalle.CantidadUnidadesBase);
                                    cmd.Parameters.AddWithValue("@ProductoID", detalle.ProductoID);
                                    int filas = cmd.ExecuteNonQuery();
                                    if (filas == 0)
                                        throw new Exception($"Stock insuficiente para ProductoID {detalle.ProductoID}.");
                                }
                            }

                            // Si es venta a crédito, registrar en CreditosVentas
                            if (venta.Estado == "CREDITO")
                            {
                                string queryCredito = @"
                                INSERT INTO CreditosVentas (
                                    VentaID, ClienteID, MontoTotal, MontoPagado, Saldo,
                                    FechaVencimiento, Estado
                                ) VALUES (
                                    @VentaID, @ClienteID, @MontoTotal, 0, @Saldo,
                                    @FechaVencimiento, 'PENDIENTE'
                                )";
                                using (var cmd = new SQLiteCommand(queryCredito, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@VentaID", ventaID);
                                    cmd.Parameters.AddWithValue("@ClienteID", venta.ClienteID);
                                    cmd.Parameters.AddWithValue("@MontoTotal", venta.Total);
                                    cmd.Parameters.AddWithValue("@Saldo", venta.Total);
                                    cmd.Parameters.AddWithValue("@FechaVencimiento",
                                        DateTime.Now.AddDays(30).ToString("yyyy-MM-dd"));
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // Asiento contable: ingreso (Caja/CxC vs Ventas)
                            venta.VentaID = (int)ventaID;
                            ContabilidadService.RegistrarVenta(
                                ventaID, venta.NumeroVenta, venta.Fecha, venta.Hora,
                                venta.Total, venta.MetodoPago,
                                venta.MontoEfectivo, venta.MontoYape,
                                venta.MontoTarjeta, venta.MontoTransferencia,
                                venta.IGV,
                                venta.UsuarioID, connection, transaction);

                            // Asiento contable: costo de ventas (Dr 500 / Cr 140)
                            var detalleCostos = detalles
                                .ConvertAll(d => (d.ProductoID, d.CantidadUnidadesBase));
                            ContabilidadService.RegistrarCostoVenta(
                                ventaID, venta.NumeroVenta, venta.Fecha, venta.Hora,
                                detalleCostos, venta.UsuarioID, connection, transaction);

                            transaction.Commit();
                            return true;
                        }
                        catch (SQLiteException ex) when (EsNumeroVentaDuplicado(ex) && intento < maxIntentos)
                        {
                            transaction.Rollback();
                            venta.NumeroVenta = GenerarNumeroVentaConConexion(connection, null, DateTime.Now.Year);
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }

            throw new Exception("No se pudo generar un número de venta único después de varios intentos.");
        }

        public static List<dynamic> Listar(int? clienteID = null, string estado = null, string tipoComprobante = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null, int? cajaID = null)
        {
            var ventas = new List<dynamic>();

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                SELECT
                    v.VentaID,
                    v.NumeroVenta,
                    v.Fecha,
                    v.Hora,
                    v.TipoComprobante,
                    v.Total,
                    v.MetodoPago,
                    v.Estado,
                    v.ClienteID,
                    CASE
                        WHEN c.ClienteID IS NULL THEN 'CLIENTE GENERAL'
                        WHEN c.TipoDocumento = 'RUC' THEN c.RazonSocial
                        ELSE c.Nombres || ' ' || c.Apellidos
                    END as NombreCliente,
                    (SELECT COUNT(*) FROM VentaDetalles vd WHERE vd.VentaID = v.VentaID) as CantidadItems,
                    v.MontoEfectivo,
                    v.MontoYape,
                    v.MontoTarjeta,
                    v.MontoTransferencia
                FROM Ventas v
                LEFT JOIN Clientes c ON v.ClienteID = c.ClienteID
                WHERE (v.Eliminado IS NULL OR v.Eliminado = 0)";

                    if (cajaID.HasValue && cajaID.Value > 0)
                        query += " AND v.CajaID = @CajaID";

                    if (clienteID.HasValue && clienteID.Value > 0)
                        query += " AND v.ClienteID = @ClienteID";

                    if (!string.IsNullOrEmpty(estado) && estado != "TODOS")
                        query += " AND v.Estado = @Estado";

                    if (!string.IsNullOrEmpty(tipoComprobante) && tipoComprobante != "TODOS")
                        query += " AND v.TipoComprobante = @TipoComprobante";

                    if (fechaDesde.HasValue)
                        query += " AND v.Fecha >= @FechaDesde";

                    if (fechaHasta.HasValue)
                        query += " AND v.Fecha <= @FechaHasta";

                    query += " ORDER BY v.Fecha DESC, v.Hora DESC";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        if (cajaID.HasValue && cajaID.Value > 0)
                            cmd.Parameters.AddWithValue("@CajaID", cajaID.Value);

                        if (clienteID.HasValue && clienteID.Value > 0)
                            cmd.Parameters.AddWithValue("@ClienteID", clienteID.Value);

                        if (!string.IsNullOrEmpty(estado) && estado != "TODOS")
                            cmd.Parameters.AddWithValue("@Estado", estado);

                        if (!string.IsNullOrEmpty(tipoComprobante) && tipoComprobante != "TODOS")
                            cmd.Parameters.AddWithValue("@TipoComprobante", tipoComprobante);

                        if (fechaDesde.HasValue)
                            cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde.Value.ToString("yyyy-MM-dd"));

                        if (fechaHasta.HasValue)
                            cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta.Value.ToString("yyyy-MM-dd"));

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ventas.Add(new
                                {
                                    VentaID = reader.GetInt32(0),
                                    NumeroVenta = reader.GetString(1),
                                    Fecha = DateTime.Parse(reader.GetString(2)),
                                    Hora = TimeSpan.Parse(reader.GetString(3)),
                                    TipoComprobante = reader.GetString(4),
                                    Total = reader.GetDecimal(5),
                                    MetodoPago = reader.GetString(6),
                                    Estado = reader.GetString(7),
                                    ClienteID = reader.IsDBNull(8) ? 0 : reader.GetInt32(8),
                                    NombreCliente = reader.IsDBNull(9) ? "CLIENTE GENERAL" : reader.GetString(9),
                                    CantidadItems = reader.GetInt32(10),
                                    MontoEfectivo = reader.GetDecimal(11),
                                    MontoYape = reader.GetDecimal(12),
                                    MontoTarjeta = reader.GetDecimal(13),
                                    MontoTransferencia = reader.GetDecimal(14)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al listar ventas: {ex.Message}");
            }

            return ventas;
        }

        public static bool Anular(int ventaID, string motivo)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                 
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string queryEstado = "SELECT Estado FROM Ventas WHERE VentaID = @VentaID";
                        using (var cmdEstado = new SQLiteCommand(queryEstado, connection, transaction))
                        {
                            cmdEstado.Parameters.AddWithValue("@VentaID", ventaID);
                            var estadoActual = cmdEstado.ExecuteScalar()?.ToString();
                            if (string.IsNullOrEmpty(estadoActual) || estadoActual == "ANULADA")
                                return false;
                        }

                        string queryDetalles = "SELECT ProductoID, CantidadUnidadesBase FROM VentaDetalles WHERE VentaID = @VentaID";
                        var detalles = new List<(int ProductoID, decimal Cantidad)>();

                        using (var cmd = new SQLiteCommand(queryDetalles, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@VentaID", ventaID);

                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    detalles.Add((reader.GetInt32(0), reader.GetDecimal(1)));
                                }
                            }
                        }

                        foreach (var detalle in detalles)
                        {
                            string queryStock = "UPDATE Productos SET StockTotal = StockTotal + @Cantidad WHERE ProductoID = @ProductoID";
                            using (var cmd = new SQLiteCommand(queryStock, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                                cmd.Parameters.AddWithValue("@ProductoID", detalle.ProductoID);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        string queryAnular = @"
                            UPDATE Ventas
                            SET Estado = 'ANULADA',
                                FechaAnulacion = @FechaAnulacion,
                                MotivoAnulacion = @Motivo
                            WHERE VentaID = @VentaID";

                        using (var cmd = new SQLiteCommand(queryAnular, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@VentaID", ventaID);
                            cmd.Parameters.AddWithValue("@FechaAnulacion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@Motivo", motivo);
                            cmd.ExecuteNonQuery();
                        }

                        // Asiento de reversión (Anulación) — ingreso y costo
                        ContabilidadService.ReversarVenta(ventaID, connection, transaction);
                        ContabilidadService.ReversarCostoVenta(ventaID, connection, transaction);

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

        public static List<dynamic> ObtenerDetalles(int ventaID)
        {
            var detalles = new List<dynamic>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                        SELECT
                            vd.Cantidad,
                            vd.PrecioUnitario,
                            vd.Subtotal,
                            p.Nombre as ProductoNombre,
                            pr.Nombre as PresentacionNombre,
                            vd.CantidadUnidadesBase,
                            ub.Simbolo as UnidadSimbolo
                        FROM VentaDetalles vd
                        INNER JOIN Productos p ON vd.ProductoID = p.ProductoID
                        INNER JOIN ProductoPresentaciones pp ON vd.ProductoPresentacionID = pp.ProductoPresentacionID
                        INNER JOIN Presentaciones pr ON pp.PresentacionID = pr.PresentacionID
                        INNER JOIN UnidadesBase ub ON p.UnidadBaseID = ub.UnidadID
                        WHERE vd.VentaID = @VentaID";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@VentaID", ventaID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                detalles.Add(new
                                {
                                    Cantidad = reader.GetDecimal(0),
                                    PrecioUnitario = reader.GetDecimal(1),
                                    Subtotal = reader.GetDecimal(2),
                                    Producto = reader.GetString(3),
                                    Presentacion = reader.GetString(4),
                                    CantidadUnidadesBase = reader.GetDecimal(5),
                                    UnidadSimbolo = reader.IsDBNull(6) ? "" : reader.GetString(6)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener detalles de venta: {ex.Message}");
            }
            return detalles;
        }

        public static Venta ObtenerPorID(int ventaID)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT * FROM Ventas WHERE VentaID = @VentaID";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@VentaID", ventaID);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Venta
                                {
                                    VentaID = reader.GetInt32(reader.GetOrdinal("VentaID")),
                                    NumeroVenta = reader.GetString(reader.GetOrdinal("NumeroVenta")),
                                    Fecha = DateTime.Parse(reader.GetString(reader.GetOrdinal("Fecha"))),
                                    Hora = TimeSpan.Parse(reader.GetString(reader.GetOrdinal("Hora"))),
                                    ClienteID = reader.GetInt32(reader.GetOrdinal("ClienteID")),
                                    TipoComprobante = reader.GetString(reader.GetOrdinal("TipoComprobante")),
                                    Serie = reader.IsDBNull(reader.GetOrdinal("Serie")) ? "" : reader.GetString(reader.GetOrdinal("Serie")),
                                    Numero = reader.IsDBNull(reader.GetOrdinal("Numero")) ? "" : reader.GetString(reader.GetOrdinal("Numero")),
                                    SubTotal = reader.GetDecimal(reader.GetOrdinal("SubTotal")),
                                    IGV = reader.GetDecimal(reader.GetOrdinal("IGV")),
                                    Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                                    MetodoPago = reader.GetString(reader.GetOrdinal("MetodoPago")),
                                    MontoEfectivo = reader.GetDecimal(reader.GetOrdinal("MontoEfectivo")),
                                    MontoYape = reader.GetDecimal(reader.GetOrdinal("MontoYape")),
                                    MontoTarjeta = reader.GetDecimal(reader.GetOrdinal("MontoTarjeta")),
                                    MontoTransferencia = reader.GetDecimal(reader.GetOrdinal("MontoTransferencia")),
                                    Estado = reader.GetString(reader.GetOrdinal("Estado")),
                                    CajaID = reader.IsDBNull(reader.GetOrdinal("CajaID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CajaID")),
                                    UsuarioID = reader.GetInt32(reader.GetOrdinal("UsuarioID"))
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener venta: {ex.Message}");
            }
        }

        public static int ObtenerVentaIDPorNumero(string numeroVenta)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT VentaID FROM Ventas WHERE NumeroVenta = @NumeroVenta";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@NumeroVenta", numeroVenta);
                        var result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        private static bool EsNumeroVentaDuplicado(SQLiteException ex)
        {
            if (ex == null)
                return false;

            if (ex.ResultCode != SQLiteErrorCode.Constraint && ex.ResultCode != SQLiteErrorCode.Constraint_Unique)
                return false;

            string mensaje = ex.Message ?? string.Empty;
            return mensaje.IndexOf("NumeroVenta", StringComparison.OrdinalIgnoreCase) >= 0
                || mensaje.IndexOf("UNIQUE constraint failed: Ventas.NumeroVenta", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static string GenerarNumeroVentaConConexion(SQLiteConnection connection, SQLiteTransaction transaction, int anio)
        {
            const string query = "SELECT COALESCE(MAX(CAST(SUBSTR(NumeroVenta, 6) AS INTEGER)), 0) + 1 FROM Ventas WHERE SUBSTR(NumeroVenta, 1, 4) = @Anio";
            using (var cmd = transaction == null
                ? new SQLiteCommand(query, connection)
                : new SQLiteCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@Anio", anio.ToString());
                var _r = cmd.ExecuteScalar();
                int siguiente = (_r != null && _r != DBNull.Value) ? Convert.ToInt32(_r) : 1;
                return $"{anio}-{siguiente:D6}";
            }
        }
    }
}
