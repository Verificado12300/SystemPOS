using SistemaPOS.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SistemaPOS.Data
{
    public class CompraRepository
    {
        public static string GenerarNumeroCompra()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT COALESCE(MAX(CAST(SUBSTR(NumeroCompra, 6) AS INTEGER)), 0) + 1 FROM Compras WHERE SUBSTR(NumeroCompra, 1, 4) = @Anio";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Anio", DateTime.Now.Year.ToString());
                        int siguiente = Convert.ToInt32(cmd.ExecuteScalar());
                        return $"{DateTime.Now.Year}-{siguiente:D6}";
                    }
                }
            }
            catch
            {
                return $"{DateTime.Now.Year}-{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            }
        }

                public static bool Crear(Compra compra, List<CompraDetalle> detalles, DateTime? fechaVencimientoCredito = null)
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
                            if (string.IsNullOrWhiteSpace(compra.NumeroCompra))
                                compra.NumeroCompra = GenerarNumeroCompraConConexion(connection, transaction, DateTime.Now.Year);

                            string queryCompra = @"
                                INSERT INTO Compras (
                                    NumeroCompra, Fecha, Hora, ProveedorID, TipoComprobante, Serie, Numero,
                                    IncluyeIGV, SubTotal, IGV, Total, MetodoPago, Estado, UsuarioID, Observaciones
                                ) VALUES (
                                    @NumeroCompra, @Fecha, @Hora, @ProveedorID, @TipoComprobante, @Serie, @Numero,
                                    @IncluyeIGV, @SubTotal, @IGV, @Total, @MetodoPago, @Estado, @UsuarioID, @Observaciones
                                )";

                            using (var cmd = new SQLiteCommand(queryCompra, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@NumeroCompra", compra.NumeroCompra);
                                cmd.Parameters.AddWithValue("@Fecha", compra.Fecha.ToString("yyyy-MM-dd"));
                                cmd.Parameters.AddWithValue("@Hora", $"{compra.Hora.Hours:D2}:{compra.Hora.Minutes:D2}:{compra.Hora.Seconds:D2}");
                                cmd.Parameters.AddWithValue("@ProveedorID", compra.ProveedorID);
                                cmd.Parameters.AddWithValue("@TipoComprobante", compra.TipoComprobante);
                                cmd.Parameters.AddWithValue("@Serie", (object)compra.Serie ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@Numero", (object)compra.Numero ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@IncluyeIGV", compra.IncluyeIGV ? 1 : 0);
                                cmd.Parameters.AddWithValue("@SubTotal", compra.SubTotal);
                                cmd.Parameters.AddWithValue("@IGV", compra.IGV);
                                cmd.Parameters.AddWithValue("@Total", compra.Total);
                                cmd.Parameters.AddWithValue("@MetodoPago", compra.MetodoPago);
                                cmd.Parameters.AddWithValue("@Estado", compra.Estado);
                                cmd.Parameters.AddWithValue("@UsuarioID", compra.UsuarioID);
                                cmd.Parameters.AddWithValue("@Observaciones", (object)compra.Observaciones ?? DBNull.Value);
                                cmd.ExecuteNonQuery();
                            }

                            long compraID = connection.LastInsertRowId;

                            foreach (var detalle in detalles)
                            {
                                string queryDetalle = @"
                                    INSERT INTO CompraDetalles (
                                        CompraID, ProductoID, ProductoPresentacionID, Cantidad, CostoUnitario, Subtotal, CantidadUnidadesBase
                                    ) VALUES (
                                        @CompraID, @ProductoID, @ProductoPresentacionID, @Cantidad, @CostoUnitario, @Subtotal, @CantidadUnidadesBase
                                    )";

                                using (var cmd = new SQLiteCommand(queryDetalle, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CompraID", compraID);
                                    cmd.Parameters.AddWithValue("@ProductoID", detalle.ProductoID);
                                    cmd.Parameters.AddWithValue("@ProductoPresentacionID", detalle.ProductoPresentacionID);
                                    cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                                    cmd.Parameters.AddWithValue("@CostoUnitario", detalle.CostoUnitario);
                                    cmd.Parameters.AddWithValue("@Subtotal", detalle.Subtotal);
                                    cmd.Parameters.AddWithValue("@CantidadUnidadesBase", detalle.CantidadUnidadesBase);
                                    cmd.ExecuteNonQuery();
                                }

                                // Aumentar stock
                                string queryStock = "UPDATE Productos SET StockTotal = StockTotal + @Cantidad WHERE ProductoID = @ProductoID";
                                using (var cmd = new SQLiteCommand(queryStock, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Cantidad", detalle.CantidadUnidadesBase);
                                    cmd.Parameters.AddWithValue("@ProductoID", detalle.ProductoID);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // Registrar credito si corresponde
                            if (compra.Estado == "CREDITO")
                            {
                                DateTime vencimiento = fechaVencimientoCredito ?? DateTime.Now.AddDays(30);

                                string queryCredito = @"
                                    INSERT INTO CreditosCompras (
                                        CompraID, ProveedorID, MontoTotal, MontoPagado, Saldo, FechaVencimiento, Estado
                                    ) VALUES (
                                        @CompraID, @ProveedorID, @MontoTotal, 0, @Saldo, @FechaVencimiento, 'PENDIENTE'
                                    )";

                                using (var cmd = new SQLiteCommand(queryCredito, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CompraID", compraID);
                                    cmd.Parameters.AddWithValue("@ProveedorID", compra.ProveedorID);
                                    cmd.Parameters.AddWithValue("@MontoTotal", compra.Total);
                                    cmd.Parameters.AddWithValue("@Saldo", compra.Total);
                                    cmd.Parameters.AddWithValue("@FechaVencimiento", vencimiento.ToString("yyyy-MM-dd"));
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // ===== ASIENTO CONTABLE =====
                            try
                            {
                                CrearAsientoCompra(compra, (int)compraID, connection, transaction);
                            }
                            catch
                            {
                                throw;
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (SQLiteException ex) when (EsNumeroCompraDuplicado(ex) && intento < maxIntentos)
                        {
                            transaction.Rollback();
                            compra.NumeroCompra = GenerarNumeroCompraConConexion(connection, null, DateTime.Now.Year);
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }

            throw new Exception("No se pudo generar un número de compra único después de varios intentos.");
        }
        public static List<dynamic> Listar(int? proveedorID = null, string estado = null, string tipoComprobante = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null, string numeroComprobante = null)
        {
            var compras = new List<dynamic>();

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                        SELECT
                            c.CompraID, c.NumeroCompra, c.Fecha, c.Hora, c.TipoComprobante,
                            c.Total, c.MetodoPago, c.Estado, c.ProveedorID,
                            p.RazonSocial as NombreProveedor,
                            (SELECT COUNT(*) FROM CompraDetalles cd WHERE cd.CompraID = c.CompraID) as CantidadItems
                        FROM Compras c
                        LEFT JOIN Proveedores p ON c.ProveedorID = p.ProveedorID
                        WHERE 1=1";

                    if (proveedorID.HasValue && proveedorID.Value > 0)
                        query += " AND c.ProveedorID = @ProveedorID";
                    if (!string.IsNullOrEmpty(estado) && estado != "TODOS")
                        query += " AND c.Estado = @Estado";
                    if (!string.IsNullOrEmpty(tipoComprobante) && tipoComprobante != "TODOS")
                        query += " AND c.TipoComprobante = @TipoComprobante";
                    if (fechaDesde.HasValue)
                        query += " AND c.Fecha >= @FechaDesde";
                    if (fechaHasta.HasValue)
                        query += " AND c.Fecha <= @FechaHasta";
                    if (!string.IsNullOrEmpty(numeroComprobante))
                        query += " AND (c.NumeroCompra LIKE @NumeroComprobante OR c.Numero LIKE @NumeroComprobante)";

                    query += " ORDER BY c.Fecha DESC, c.Hora DESC";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        if (proveedorID.HasValue && proveedorID.Value > 0)
                            cmd.Parameters.AddWithValue("@ProveedorID", proveedorID.Value);
                        if (!string.IsNullOrEmpty(estado) && estado != "TODOS")
                            cmd.Parameters.AddWithValue("@Estado", estado);
                        if (!string.IsNullOrEmpty(tipoComprobante) && tipoComprobante != "TODOS")
                            cmd.Parameters.AddWithValue("@TipoComprobante", tipoComprobante);
                        if (fechaDesde.HasValue)
                            cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde.Value.ToString("yyyy-MM-dd"));
                        if (fechaHasta.HasValue)
                            cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta.Value.ToString("yyyy-MM-dd"));
                        if (!string.IsNullOrEmpty(numeroComprobante))
                            cmd.Parameters.AddWithValue("@NumeroComprobante", $"%{numeroComprobante}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                compras.Add(new
                                {
                                    CompraID = reader.GetInt32(0),
                                    NumeroCompra = reader.GetString(1),
                                    Fecha = DateTime.Parse(reader.GetString(2)),
                                    Hora = TimeSpan.Parse(reader.GetString(3)),
                                    TipoComprobante = reader.GetString(4),
                                    Total = reader.GetDecimal(5),
                                    MetodoPago = reader.GetString(6),
                                    Estado = reader.GetString(7),
                                    ProveedorID = reader.GetInt32(8),
                                    NombreProveedor = reader.IsDBNull(9) ? "Sin proveedor" : reader.GetString(9),
                                    CantidadItems = reader.GetInt32(10)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al listar compras: {ex.Message}");
            }

            return compras;
        }

        public static Compra ObtenerPorID(int compraID)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT * FROM Compras WHERE CompraID = @CompraID";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CompraID", compraID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Compra
                                {
                                    CompraID = reader.GetInt32(reader.GetOrdinal("CompraID")),
                                    NumeroCompra = reader.GetString(reader.GetOrdinal("NumeroCompra")),
                                    Fecha = DateTime.Parse(reader.GetString(reader.GetOrdinal("Fecha"))),
                                    Hora = TimeSpan.Parse(reader.GetString(reader.GetOrdinal("Hora"))),
                                    ProveedorID = reader.GetInt32(reader.GetOrdinal("ProveedorID")),
                                    TipoComprobante = reader.GetString(reader.GetOrdinal("TipoComprobante")),
                                    Serie = reader.IsDBNull(reader.GetOrdinal("Serie")) ? "" : reader.GetString(reader.GetOrdinal("Serie")),
                                    Numero = reader.IsDBNull(reader.GetOrdinal("Numero")) ? "" : reader.GetString(reader.GetOrdinal("Numero")),
                                    IncluyeIGV = reader.GetInt32(reader.GetOrdinal("IncluyeIGV")) == 1,
                                    SubTotal = reader.GetDecimal(reader.GetOrdinal("SubTotal")),
                                    IGV = reader.GetDecimal(reader.GetOrdinal("IGV")),
                                    Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                                    MetodoPago = reader.GetString(reader.GetOrdinal("MetodoPago")),
                                    Estado = reader.GetString(reader.GetOrdinal("Estado")),
                                    UsuarioID = reader.GetInt32(reader.GetOrdinal("UsuarioID")),
                                    Observaciones = reader.IsDBNull(reader.GetOrdinal("Observaciones")) ? "" : reader.GetString(reader.GetOrdinal("Observaciones")),
                                    FechaAnulacion = reader.IsDBNull(reader.GetOrdinal("FechaAnulacion")) ? (DateTime?)null : DateTime.Parse(reader.GetString(reader.GetOrdinal("FechaAnulacion"))),
                                    MotivoAnulacion = reader.IsDBNull(reader.GetOrdinal("MotivoAnulacion")) ? "" : reader.GetString(reader.GetOrdinal("MotivoAnulacion"))
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener compra: {ex.Message}");
            }
        }

        public static List<dynamic> ObtenerDetalles(int compraID)
        {
            var detallesResult = new List<dynamic>();

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                        SELECT
                            cd.CompraDetalleID, cd.CompraID, cd.ProductoID, cd.ProductoPresentacionID,
                            cd.Cantidad, cd.CostoUnitario, cd.Subtotal, cd.CantidadUnidadesBase,
                            p.Nombre as ProductoNombre, p.Codigo as ProductoCodigo,
                            pr.Nombre as PresentacionNombre,
                            ub.Simbolo as UnidadSimbolo
                        FROM CompraDetalles cd
                        INNER JOIN Productos p ON cd.ProductoID = p.ProductoID
                        INNER JOIN ProductoPresentaciones pp ON cd.ProductoPresentacionID = pp.ProductoPresentacionID
                        INNER JOIN Presentaciones pr ON pp.PresentacionID = pr.PresentacionID
                        INNER JOIN UnidadesBase ub ON p.UnidadBaseID = ub.UnidadID
                        WHERE cd.CompraID = @CompraID";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CompraID", compraID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                detallesResult.Add(new
                                {
                                    CompraDetalleID = reader.GetInt32(0),
                                    CompraID = reader.GetInt32(1),
                                    ProductoID = reader.GetInt32(2),
                                    ProductoPresentacionID = reader.GetInt32(3),
                                    Cantidad = reader.GetDecimal(4),
                                    CostoUnitario = reader.GetDecimal(5),
                                    Subtotal = reader.GetDecimal(6),
                                    CantidadUnidadesBase = reader.GetDecimal(7),
                                    ProductoNombre = reader.GetString(8),
                                    ProductoCodigo = reader.GetString(9),
                                    PresentacionNombre = reader.GetString(10),
                                    UnidadSimbolo = reader.IsDBNull(11) ? "" : reader.GetString(11)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener detalles de compra: {ex.Message}");
            }

            return detallesResult;
        }

        public static CreditoCompra ObtenerCreditoPorCompraID(int compraID)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT * FROM CreditosCompras WHERE CompraID = @CompraID";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CompraID", compraID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new CreditoCompra
                                {
                                    CreditoCompraID = reader.GetInt32(reader.GetOrdinal("CreditoCompraID")),
                                    CompraID = reader.GetInt32(reader.GetOrdinal("CompraID")),
                                    ProveedorID = reader.GetInt32(reader.GetOrdinal("ProveedorID")),
                                    MontoTotal = reader.GetDecimal(reader.GetOrdinal("MontoTotal")),
                                    MontoPagado = reader.GetDecimal(reader.GetOrdinal("MontoPagado")),
                                    Saldo = reader.GetDecimal(reader.GetOrdinal("Saldo")),
                                    FechaVencimiento = DateTime.Parse(reader.GetString(reader.GetOrdinal("FechaVencimiento"))),
                                    Estado = reader.GetString(reader.GetOrdinal("Estado")),
                                    FechaRegistro = DateTime.Parse(reader.GetString(reader.GetOrdinal("FechaRegistro"))),
                                    FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : DateTime.Parse(reader.GetString(reader.GetOrdinal("FechaPago")))
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener crÃ©dito de compra: {ex.Message}");
            }
        }

        public static bool Anular(int compraID, string motivo)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string queryEstado = "SELECT Estado FROM Compras WHERE CompraID = @CompraID";
                        using (var cmdEstado = new SQLiteCommand(queryEstado, connection, transaction))
                        {
                            cmdEstado.Parameters.AddWithValue("@CompraID", compraID);
                            var estadoActual = cmdEstado.ExecuteScalar()?.ToString();
                            if (string.IsNullOrEmpty(estadoActual) || estadoActual == "ANULADA")
                                return false;
                        }

                        string queryDetalles = "SELECT ProductoID, CantidadUnidadesBase FROM CompraDetalles WHERE CompraID = @CompraID";
                        var detalles = new List<(int ProductoID, decimal Cantidad)>();

                        using (var cmd = new SQLiteCommand(queryDetalles, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@CompraID", compraID);
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
                            string queryStock = @"
                                UPDATE Productos
                                SET StockTotal = StockTotal - @Cantidad
                                WHERE ProductoID = @ProductoID
                                  AND StockTotal >= @Cantidad";
                            using (var cmd = new SQLiteCommand(queryStock, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                                cmd.Parameters.AddWithValue("@ProductoID", detalle.ProductoID);
                                int filas = cmd.ExecuteNonQuery();
                                if (filas == 0)
                                    throw new Exception($"No se puede anular la compra. Stock insuficiente para ProductoID {detalle.ProductoID}.");
                            }
                        }

                        // Si ya existen pagos de proveedor registrados, no permitir anular.
                        string queryPagosRegistrados = @"
                            SELECT COUNT(1)
                            FROM PagosProveedores pp
                            INNER JOIN CuentasPorPagar cp ON cp.CuentaPorPagarID = pp.CuentaPorPagarID
                            WHERE cp.CompraID = @CompraID";

                        using (var cmd = new SQLiteCommand(queryPagosRegistrados, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@CompraID", compraID);
                            var cantidadPagos = Convert.ToInt32(cmd.ExecuteScalar());
                            if (cantidadPagos > 0)
                            {
                                throw new Exception("No se puede anular la compra porque ya tiene pagos de proveedor registrados.");
                            }
                        }

                        // Retirar deuda asociada por anulacion (evitar marcar como PAGADO).
                        string queryEliminarCuentasPorPagar = "DELETE FROM CuentasPorPagar WHERE CompraID = @CompraID";
                        using (var cmd = new SQLiteCommand(queryEliminarCuentasPorPagar, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@CompraID", compraID);
                            cmd.ExecuteNonQuery();
                        }

                        string queryEliminarCredito = "DELETE FROM CreditosCompras WHERE CompraID = @CompraID";
                        using (var cmd = new SQLiteCommand(queryEliminarCredito, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@CompraID", compraID);
                            cmd.ExecuteNonQuery();
                        }

                        string queryAnular = @"
                            UPDATE Compras
                            SET Estado = 'ANULADA',
                                FechaAnulacion = @FechaAnulacion,
                                MotivoAnulacion = @Motivo
                            WHERE CompraID = @CompraID";

                        using (var cmd = new SQLiteCommand(queryAnular, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@CompraID", compraID);
                            cmd.Parameters.AddWithValue("@FechaAnulacion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@Motivo", motivo);
                            cmd.ExecuteNonQuery();
                        }

                        // ===== ASIENTO DE ANULACION =====
                        try
                        {
                            CrearAsientoAnulacionCompra(compraID, motivo, connection, transaction);
                        }
                        catch
                        {
                            // No bloquear la anulacion si falla el asiento contable
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
        private static bool EsNumeroCompraDuplicado(SQLiteException ex)
        {
            if (ex == null)
                return false;

            if (ex.ResultCode != SQLiteErrorCode.Constraint && ex.ResultCode != SQLiteErrorCode.Constraint_Unique)
                return false;

            string mensaje = ex.Message ?? string.Empty;
            return mensaje.IndexOf("NumeroCompra", StringComparison.OrdinalIgnoreCase) >= 0
                || mensaje.IndexOf("UNIQUE constraint failed: Compras.NumeroCompra", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static string GenerarNumeroCompraConConexion(SQLiteConnection connection, SQLiteTransaction transaction, int anio)
        {
            const string query = "SELECT COALESCE(MAX(CAST(SUBSTR(NumeroCompra, 6) AS INTEGER)), 0) + 1 FROM Compras WHERE SUBSTR(NumeroCompra, 1, 4) = @Anio";
            using (var cmd = transaction == null
                ? new SQLiteCommand(query, connection)
                : new SQLiteCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@Anio", anio.ToString());
                int siguiente = Convert.ToInt32(cmd.ExecuteScalar());
                return $"{anio}-{siguiente:D6}";
            }
        }

        // =====================================================================
        // Crea el asiento contable para una compra
        // =====================================================================
        private static void CrearAsientoCompra(Compra compra, int compraID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            var asiento = new Models.AsientoContable
            {
                Fecha = compra.Fecha,
                Hora = compra.Hora,
                TipoOperacion = "COMPRA",
                Documento = compra.NumeroCompra,
                ReferenciaID = compraID,
                UsuarioID = compra.UsuarioID,
                Glosa = $"Compra {compra.NumeroCompra}"
            };

            // Debe: Inventario
            var ctaInv = ContabilidadRepository.ObtenerCuentaPorCodigo("201", conn, tx);
            if (ctaInv != null && compra.Total > 0)
                asiento.Detalles.Add(new Models.AsientoDetalleContable { CuentaID = ctaInv.CuentaID, Debe = compra.Total, Descripcion = "Ingreso inventario" });

            // Haber: segun metodo de pago
            if (compra.MetodoPago == "CREDITO" || compra.Estado == "CREDITO")
            {
                var ctaCxP = ContabilidadRepository.ObtenerCuentaPorCodigo("601", conn, tx);
                if (ctaCxP != null && compra.Total > 0)
                    asiento.Detalles.Add(new Models.AsientoDetalleContable { CuentaID = ctaCxP.CuentaID, Haber = compra.Total, Descripcion = "Cuenta por pagar proveedor" });
            }
            else
            {
                string codigoCuenta = ContabilidadRepository.ObtenerCodigoCuentaEfectivo(compra.MetodoPago);
                var ctaPago = ContabilidadRepository.ObtenerCuentaPorCodigo(codigoCuenta, conn, tx);
                if (ctaPago != null && compra.Total > 0)
                    asiento.Detalles.Add(new Models.AsientoDetalleContable { CuentaID = ctaPago.CuentaID, Haber = compra.Total, Descripcion = $"Pago compra {compra.MetodoPago}" });
            }

            if (asiento.Detalles.Count >= 2)
                ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
        }

        // =====================================================================
        // Crea el asiento de anulacion de una compra (reverso)
        // =====================================================================
        private static void CrearAsientoAnulacionCompra(int compraID, string motivo,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            string queryCompra = "SELECT NumeroCompra, Fecha, Hora, Total, MetodoPago, Estado, UsuarioID FROM Compras WHERE CompraID = @CompraID";
            string numeroCompra = null;
            DateTime fecha = DateTime.Now;
            TimeSpan hora = DateTime.Now.TimeOfDay;
            decimal total = 0;
            string metodoPago = "EFECTIVO";
            string estado = "COMPLETADA";
            int usuarioID = 0;

            using (var cmd = new SQLiteCommand(queryCompra, conn, tx))
            {
                cmd.Parameters.AddWithValue("@CompraID", compraID);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return;
                    numeroCompra = reader.GetString(0);
                    fecha = DateTime.Parse(reader.GetString(1));
                    hora = TimeSpan.Parse(reader.GetString(2));
                    total = reader.GetDecimal(3);
                    metodoPago = reader.GetString(4);
                    estado = reader.GetString(5);
                    usuarioID = reader.GetInt32(6);
                }
            }

            var asiento = new Models.AsientoContable
            {
                Fecha = DateTime.Now,
                Hora = DateTime.Now.TimeOfDay,
                TipoOperacion = "ANULACION",
                Documento = numeroCompra + "-ANUL",
                ReferenciaID = compraID,
                UsuarioID = usuarioID,
                Glosa = $"Anulacion compra {numeroCompra}: {motivo}"
            };

            // Revertir: Haber Inventario, Debe a la cuenta de pago original
            var ctaInv = ContabilidadRepository.ObtenerCuentaPorCodigo("201", conn, tx);
            if (ctaInv != null && total > 0)
                asiento.Detalles.Add(new Models.AsientoDetalleContable { CuentaID = ctaInv.CuentaID, Haber = total, Descripcion = "Reverso inventario" });

            if (metodoPago == "CREDITO" || estado == "CREDITO")
            {
                var ctaCxP = ContabilidadRepository.ObtenerCuentaPorCodigo("601", conn, tx);
                if (ctaCxP != null && total > 0)
                    asiento.Detalles.Add(new Models.AsientoDetalleContable { CuentaID = ctaCxP.CuentaID, Debe = total, Descripcion = "Reverso CxP" });
            }
            else
            {
                string codigoCuenta = ContabilidadRepository.ObtenerCodigoCuentaEfectivo(metodoPago);
                var ctaPago = ContabilidadRepository.ObtenerCuentaPorCodigo(codigoCuenta, conn, tx);
                if (ctaPago != null && total > 0)
                    asiento.Detalles.Add(new Models.AsientoDetalleContable { CuentaID = ctaPago.CuentaID, Debe = total, Descripcion = $"Reverso pago {metodoPago}" });
            }

            if (asiento.Detalles.Count >= 2)
                ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
        }
    }
}
