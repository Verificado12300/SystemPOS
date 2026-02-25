using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SistemaPOS.Models;

namespace SistemaPOS.Data
{
    public class CuentaPorPagarConDetalle : CuentaPorPagar
    {
        public string NumeroCompra { get; set; }
        public string NombreProveedor { get; set; }
        public DateTime FechaCompra { get; set; }
    }

    public class PagoProveedorConDetalle : PagoProveedor
    {
        public string NombreUsuario { get; set; }
    }

    public class CuentaPorPagarRepository
    {
        public static List<CuentaPorPagarConDetalle> Listar(int? proveedorID = null, string estado = null, string busqueda = null)
        {
            var cuentas = new List<CuentaPorPagarConDetalle>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT cp.CuentaPorPagarID, cp.CompraID, cp.ProveedorID, cp.MontoTotal,
                           cp.MontoPagado, cp.MontoPendiente, cp.FechaVencimiento, cp.Estado,
                           co.NumeroCompra, p.RazonSocial as NombreProveedor, co.Fecha as FechaCompra
                    FROM CuentasPorPagar cp
                    INNER JOIN Compras co ON cp.CompraID = co.CompraID
                    INNER JOIN Proveedores p ON cp.ProveedorID = p.ProveedorID
                    WHERE 1=1";

                if (proveedorID.HasValue && proveedorID.Value > 0)
                    query += " AND cp.ProveedorID = @ProveedorID";
                if (!string.IsNullOrEmpty(estado) && estado != "TODOS")
                    query += " AND cp.Estado = @Estado";
                if (!string.IsNullOrEmpty(busqueda))
                    query += " AND (co.NumeroCompra LIKE @Busqueda OR p.RazonSocial LIKE @Busqueda)";

                query += " ORDER BY cp.Estado ASC, cp.FechaVencimiento ASC";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    if (proveedorID.HasValue && proveedorID.Value > 0)
                        cmd.Parameters.AddWithValue("@ProveedorID", proveedorID.Value);
                    if (!string.IsNullOrEmpty(estado) && estado != "TODOS")
                        cmd.Parameters.AddWithValue("@Estado", estado);
                    if (!string.IsNullOrEmpty(busqueda))
                        cmd.Parameters.AddWithValue("@Busqueda", $"%{busqueda}%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cuentas.Add(new CuentaPorPagarConDetalle
                            {
                                CuentaPorPagarID = reader.GetInt32(0),
                                CompraID = reader.GetInt32(1),
                                ProveedorID = reader.GetInt32(2),
                                MontoTotal = reader.GetDecimal(3),
                                MontoPagado = reader.GetDecimal(4),
                                MontoPendiente = reader.GetDecimal(5),
                                FechaVencimiento = reader.IsDBNull(6) ? (DateTime?)null : DateTime.Parse(reader.GetString(6)),
                                Estado = reader.GetString(7),
                                NumeroCompra = reader.GetString(8),
                                NombreProveedor = reader.GetString(9),
                                FechaCompra = DateTime.Parse(reader.GetString(10))
                            });
                        }
                    }
                }
            }

            return cuentas;
        }

        public static CuentaPorPagarConDetalle ObtenerPorID(int cuentaPorPagarID)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT cp.CuentaPorPagarID, cp.CompraID, cp.ProveedorID, cp.MontoTotal,
                           cp.MontoPagado, cp.MontoPendiente, cp.FechaVencimiento, cp.Estado,
                           co.NumeroCompra, p.RazonSocial as NombreProveedor, co.Fecha as FechaCompra
                    FROM CuentasPorPagar cp
                    INNER JOIN Compras co ON cp.CompraID = co.CompraID
                    INNER JOIN Proveedores p ON cp.ProveedorID = p.ProveedorID
                    WHERE cp.CuentaPorPagarID = @CuentaPorPagarID";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CuentaPorPagarID", cuentaPorPagarID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CuentaPorPagarConDetalle
                            {
                                CuentaPorPagarID = reader.GetInt32(0),
                                CompraID = reader.GetInt32(1),
                                ProveedorID = reader.GetInt32(2),
                                MontoTotal = reader.GetDecimal(3),
                                MontoPagado = reader.GetDecimal(4),
                                MontoPendiente = reader.GetDecimal(5),
                                FechaVencimiento = reader.IsDBNull(6) ? (DateTime?)null : DateTime.Parse(reader.GetString(6)),
                                Estado = reader.GetString(7),
                                NumeroCompra = reader.GetString(8),
                                NombreProveedor = reader.GetString(9),
                                FechaCompra = DateTime.Parse(reader.GetString(10))
                            };
                        }
                    }
                }
            }

            return null;
        }

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

                        decimal montoPendienteActual;
                        using (var cmdSaldo = new SQLiteCommand(
                            "SELECT MontoPendiente FROM CuentasPorPagar WHERE CuentaPorPagarID = @CuentaPorPagarID",
                            connection, transaction))
                        {
                            cmdSaldo.Parameters.AddWithValue("@CuentaPorPagarID", pago.CuentaPorPagarID);
                            var saldoObj = cmdSaldo.ExecuteScalar();
                            if (saldoObj == null || saldoObj == DBNull.Value)
                                throw new Exception("La cuenta por pagar no existe.");
                            montoPendienteActual = Convert.ToDecimal(saldoObj);
                        }

                        if (pago.Monto > montoPendienteActual)
                            throw new Exception("El monto del pago excede el saldo pendiente actual.");

                        string queryPago = @"
                            INSERT INTO PagosProveedores (CuentaPorPagarID, Fecha, Hora, Monto, MetodoPago, Comprobante, Observaciones, UsuarioID)
                            VALUES (@CuentaPorPagarID, @Fecha, @Hora, @Monto, @MetodoPago, @Comprobante, @Observaciones, @UsuarioID)";

                        using (var cmd = new SQLiteCommand(queryPago, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@CuentaPorPagarID", pago.CuentaPorPagarID);
                            cmd.Parameters.AddWithValue("@Fecha", pago.Fecha.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@Hora", $"{pago.Hora.Hours:D2}:{pago.Hora.Minutes:D2}:{pago.Hora.Seconds:D2}");
                            cmd.Parameters.AddWithValue("@Monto", pago.Monto);
                            cmd.Parameters.AddWithValue("@MetodoPago", pago.MetodoPago);
                            cmd.Parameters.AddWithValue("@Comprobante", (object)pago.Comprobante ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Observaciones", (object)pago.Observaciones ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@UsuarioID", pago.UsuarioID);
                            cmd.ExecuteNonQuery();
                        }

                        string queryUpdate = @"
                            UPDATE CuentasPorPagar
                            SET MontoPagado = MontoPagado + @Monto,
                                MontoPendiente = MontoPendiente - @Monto,
                                Estado = CASE
                                    WHEN MontoPendiente - @Monto <= 0 THEN 'PAGADO'
                                    ELSE 'PARCIAL'
                                END
                            WHERE CuentaPorPagarID = @CuentaPorPagarID
                              AND Estado != 'PAGADO'
                              AND MontoPendiente >= @Monto";

                        using (var cmd = new SQLiteCommand(queryUpdate, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Monto", pago.Monto);
                            cmd.Parameters.AddWithValue("@CuentaPorPagarID", pago.CuentaPorPagarID);
                            int filas = cmd.ExecuteNonQuery();
                            if (filas == 0)
                                throw new Exception("No se pudo aplicar el pago porque la cuenta cambió o ya está pagada.");
                        }

                        // Sincronizar con CreditosCompras
                        string querySync = @"
                            UPDATE CreditosCompras
                            SET MontoPagado = MontoPagado + @Monto,
                                Saldo = Saldo - @Monto,
                                Estado = CASE
                                    WHEN Saldo - @Monto <= 0 THEN 'PAGADO'
                                    ELSE 'PENDIENTE'
                                END,
                                FechaPago = CASE WHEN Saldo - @Monto <= 0 THEN @FechaPago ELSE FechaPago END
                            WHERE CompraID = (SELECT CompraID FROM CuentasPorPagar WHERE CuentaPorPagarID = @CuentaPorPagarID)";

                        using (var cmd = new SQLiteCommand(querySync, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Monto", pago.Monto);
                            cmd.Parameters.AddWithValue("@CuentaPorPagarID", pago.CuentaPorPagarID);
                            cmd.Parameters.AddWithValue("@FechaPago", pago.Fecha.ToString("yyyy-MM-dd"));
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

        public static List<PagoProveedorConDetalle> ObtenerPagos(int cuentaPorPagarID)
        {
            var pagos = new List<PagoProveedorConDetalle>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT pp.PagoProveedorID, pp.CuentaPorPagarID, pp.Fecha, pp.Hora,
                           pp.Monto, pp.MetodoPago, pp.Comprobante, pp.Observaciones,
                           pp.UsuarioID, u.NombreCompleto as NombreUsuario
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
                                PagoProveedorID = reader.GetInt32(0),
                                CuentaPorPagarID = reader.GetInt32(1),
                                Fecha = DateTime.Parse(reader.GetString(2)),
                                Hora = TimeSpan.Parse(reader.GetString(3)),
                                Monto = reader.GetDecimal(4),
                                MetodoPago = reader.GetString(5),
                                Comprobante = reader.IsDBNull(6) ? "" : reader.GetString(6),
                                Observaciones = reader.IsDBNull(7) ? "" : reader.GetString(7),
                                UsuarioID = reader.GetInt32(8),
                                NombreUsuario = reader.GetString(9)
                            });
                        }
                    }
                }
            }

            return pagos;
        }

        public static (decimal TotalDeuda, decimal TotalPagado, int CuentasPendientes) ObtenerResumen()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT
                        COALESCE(SUM(MontoTotal), 0),
                        COALESCE(SUM(MontoPagado), 0),
                        COUNT(CASE WHEN Estado != 'PAGADO' THEN 1 END)
                    FROM CuentasPorPagar";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (reader.GetDecimal(0), reader.GetDecimal(1), reader.GetInt32(2));
                        }
                    }
                }
            }

            return (0, 0, 0);
        }
    }
}
