using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SistemaPOS.Data
{
    public class CuentaPorCobrarDetalle
    {
        public int VentaID { get; set; }
        public string NumeroVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int ClienteID { get; set; }
        public string NombreCliente { get; set; }
        public decimal TotalCredito { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal SaldoPendiente { get; set; }
        public string Estado { get; set; }
        public int DiasVencidos { get; set; }
    }

    public class PagoClienteDetalle
    {
        public int PagoID { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string MetodoPago { get; set; }
        public decimal MontoAplicado { get; set; }
        public string Observaciones { get; set; }
    }

    public static class CuentaPorCobrarRepository
    {
        public static List<CuentaPorCobrarDetalle> Listar(int? clienteID = null, string estado = null, string busqueda = null, bool soloVencidas = false)
        {
            var lista = new List<CuentaPorCobrarDetalle>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT
                        v.VentaID,
                        v.NumeroVenta,
                        v.Fecha,
                        COALESCE(cv.FechaVencimiento, date(v.Fecha, '+30 day')) as FechaVencimiento,
                        c.ClienteID,
                        CASE
                            WHEN c.TipoDocumento = 'RUC' THEN c.RazonSocial
                            ELSE trim(COALESCE(c.Nombres,'') || ' ' || COALESCE(c.Apellidos,''))
                        END as NombreCliente,
                        v.Total,
                        COALESCE(v.MontoEfectivo + v.MontoYape + v.MontoTransferencia + v.MontoTarjeta, 0) as OldPayments,
                        COALESCE((SELECT SUM(pv.MontoAplicado) FROM PagoVenta pv WHERE pv.VentaID = v.VentaID), 0) as NewPayments
                    FROM Ventas v
                    INNER JOIN Clientes c ON c.ClienteID = v.ClienteID
                    LEFT JOIN CreditosVentas cv ON cv.VentaID = v.VentaID
                    WHERE v.MetodoPago = 'CREDITO'
                      AND v.Estado != 'ANULADA'";

                if (clienteID.HasValue && clienteID.Value > 0)
                    query += " AND v.ClienteID = @ClienteID";

                if (!string.IsNullOrWhiteSpace(busqueda))
                    query += " AND (v.NumeroVenta LIKE @Busqueda OR c.NumeroDocumento LIKE @Busqueda OR c.RazonSocial LIKE @Busqueda OR c.Nombres LIKE @Busqueda OR c.Apellidos LIKE @Busqueda)";

                query += " ORDER BY date(FechaVencimiento) ASC, date(v.Fecha) ASC";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    if (clienteID.HasValue && clienteID.Value > 0)
                        cmd.Parameters.AddWithValue("@ClienteID", clienteID.Value);
                    if (!string.IsNullOrWhiteSpace(busqueda))
                        cmd.Parameters.AddWithValue("@Busqueda", $"%{busqueda.Trim()}%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var total = reader.GetDecimal(6);
                            var oldPayments = reader.GetDecimal(7);
                            var newPayments = reader.GetDecimal(8);
                            var montoPagado = oldPayments + newPayments;
                            var saldo = total - montoPagado;
                            if (saldo < 0) saldo = 0;

                            DateTime fechaVenc = DateTime.Parse(reader.GetString(3));
                            int diasVencidos = (DateTime.Today - fechaVenc.Date).Days;

                            string estadoCalculado;
                            if (saldo <= 0.0001m)
                                estadoCalculado = "PAGADO";
                            else if (fechaVenc.Date < DateTime.Today)
                                estadoCalculado = "VENCIDO";
                            else if (montoPagado > 0)
                                estadoCalculado = "PARCIAL";
                            else
                                estadoCalculado = "PENDIENTE";

                            if (!string.IsNullOrWhiteSpace(estado) && estado != "TODOS" && estado != estadoCalculado)
                                continue;
                            if (soloVencidas && estadoCalculado != "VENCIDO")
                                continue;

                            lista.Add(new CuentaPorCobrarDetalle
                            {
                                VentaID = reader.GetInt32(0),
                                NumeroVenta = reader.GetString(1),
                                FechaVenta = DateTime.Parse(reader.GetString(2)),
                                FechaVencimiento = fechaVenc,
                                ClienteID = reader.GetInt32(4),
                                NombreCliente = reader.GetString(5),
                                TotalCredito = total,
                                MontoPagado = montoPagado,
                                SaldoPendiente = saldo,
                                Estado = estadoCalculado,
                                DiasVencidos = diasVencidos > 0 ? diasVencidos : 0
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public static bool RegistrarCobroVenta(int ventaID, decimal monto, string metodoPago, DateTime fechaPago, string observaciones,
            decimal montoEfectivo = 0, decimal montoYape = 0, decimal montoTransferencia = 0)
        {
            if (monto <= 0)
                throw new Exception("El monto del cobro debe ser mayor a cero.");

            using (var connection = DatabaseConnection.GetConnection())
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    string queryVenta = @"
                        SELECT
                            v.ClienteID,
                            v.Total,
                            COALESCE(v.MontoEfectivo + v.MontoYape + v.MontoTransferencia + v.MontoTarjeta, 0) as OldPayments,
                            COALESCE((SELECT SUM(MontoAplicado) FROM PagoVenta WHERE VentaID = v.VentaID), 0) as NewPayments
                        FROM Ventas v
                        WHERE v.VentaID = @VentaID
                          AND v.MetodoPago = 'CREDITO'
                          AND v.Estado != 'ANULADA'";

                    int clienteID;
                    decimal saldoPendiente;

                    using (var cmd = new SQLiteCommand(queryVenta, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@VentaID", ventaID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                                throw new Exception("La venta no existe o no corresponde a crédito.");

                            clienteID = reader.GetInt32(0);
                            var total = reader.GetDecimal(1);
                            var oldPay = reader.GetDecimal(2);
                            var newPay = reader.GetDecimal(3);
                            saldoPendiente = total - oldPay - newPay;
                        }
                    }

                    if (saldoPendiente <= 0)
                        throw new Exception("La venta ya no tiene saldo pendiente.");
                    if (monto > saldoPendiente)
                        throw new Exception("El monto excede el saldo pendiente de la venta.");

                    string insertPago = @"
                        INSERT INTO Pagos (ClienteID, Monto, MetodoPago, MontoEfectivo, MontoYape, MontoTransferencia, FechaPago, HoraPago, Observaciones)
                        VALUES (@ClienteID, @Monto, @MetodoPago, @MontoEfectivo, @MontoYape, @MontoTransferencia, @FechaPago, @HoraPago, @Observaciones)";
                    using (var cmd = new SQLiteCommand(insertPago, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                        cmd.Parameters.AddWithValue("@Monto", monto);
                        cmd.Parameters.AddWithValue("@MetodoPago", metodoPago);
                        cmd.Parameters.AddWithValue("@MontoEfectivo", montoEfectivo);
                        cmd.Parameters.AddWithValue("@MontoYape", montoYape);
                        cmd.Parameters.AddWithValue("@MontoTransferencia", montoTransferencia);
                        cmd.Parameters.AddWithValue("@FechaPago", fechaPago.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@HoraPago", $"{DateTime.Now.Hour:D2}:{DateTime.Now.Minute:D2}:{DateTime.Now.Second:D2}");
                        cmd.Parameters.AddWithValue("@Observaciones", observaciones ?? "");
                        cmd.ExecuteNonQuery();
                    }

                    int pagoID;
                    using (var cmd = new SQLiteCommand("SELECT last_insert_rowid()", connection, transaction))
                        pagoID = Convert.ToInt32(cmd.ExecuteScalar());

                    using (var cmd = new SQLiteCommand("INSERT INTO PagoVenta (PagoID, VentaID, MontoAplicado) VALUES (@PagoID, @VentaID, @MontoAplicado)", connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@PagoID", pagoID);
                        cmd.Parameters.AddWithValue("@VentaID", ventaID);
                        cmd.Parameters.AddWithValue("@MontoAplicado", monto);
                        cmd.ExecuteNonQuery();
                    }

                    decimal saldoFinal = saldoPendiente - monto;
                    string estadoVenta = saldoFinal <= 0.0001m ? "COMPLETADA" : "CREDITO";
                    using (var cmd = new SQLiteCommand("UPDATE Ventas SET Estado = @Estado WHERE VentaID = @VentaID", connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Estado", estadoVenta);
                        cmd.Parameters.AddWithValue("@VentaID", ventaID);
                        cmd.ExecuteNonQuery();
                    }

                    string upsertCredito = @"
                        INSERT INTO CreditosVentas (VentaID, ClienteID, MontoTotal, MontoPagado, Saldo, FechaVencimiento, Estado, FechaRegistro, FechaPago)
                        VALUES (
                            @VentaID, @ClienteID,
                            (SELECT Total FROM Ventas WHERE VentaID = @VentaID),
                            @MontoPagado,
                            @Saldo,
                            (SELECT COALESCE(FechaVencimiento, date((SELECT Fecha FROM Ventas WHERE VentaID = @VentaID), '+30 day')) FROM CreditosVentas WHERE VentaID = @VentaID),
                            @EstadoCredito,
                            datetime('now'),
                            @FechaPagoFinal
                        )
                        ON CONFLICT(VentaID) DO UPDATE SET
                            MontoPagado = @MontoPagado,
                            Saldo = @Saldo,
                            Estado = @EstadoCredito,
                            FechaPago = @FechaPagoFinal;";

                    var estadoCredito = saldoFinal <= 0.0001m ? "PAGADO" : "PENDIENTE";
                    using (var cmd = new SQLiteCommand(upsertCredito, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@VentaID", ventaID);
                        cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                        cmd.Parameters.AddWithValue("@MontoPagado", (saldoPendiente - saldoFinal));
                        cmd.Parameters.AddWithValue("@Saldo", saldoFinal <= 0 ? 0 : saldoFinal);
                        cmd.Parameters.AddWithValue("@EstadoCredito", estadoCredito);
                        cmd.Parameters.AddWithValue("@FechaPagoFinal", saldoFinal <= 0.0001m ? fechaPago.ToString("yyyy-MM-dd") : (object)DBNull.Value);
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

        public static List<PagoClienteDetalle> ObtenerPagosVenta(int ventaID)
        {
            var pagos = new List<PagoClienteDetalle>();
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT p.PagoID, p.FechaPago, p.HoraPago, p.MetodoPago, pv.MontoAplicado, p.Observaciones
                    FROM PagoVenta pv
                    INNER JOIN Pagos p ON p.PagoID = pv.PagoID
                    WHERE pv.VentaID = @VentaID
                    ORDER BY p.FechaPago DESC, p.HoraPago DESC";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@VentaID", ventaID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pagos.Add(new PagoClienteDetalle
                            {
                                PagoID = reader.GetInt32(0),
                                Fecha = DateTime.Parse(reader.GetString(1)),
                                Hora = TimeSpan.Parse(reader.GetString(2)),
                                MetodoPago = reader.GetString(3),
                                MontoAplicado = reader.GetDecimal(4),
                                Observaciones = reader.IsDBNull(5) ? "" : reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return pagos;
        }

        public static (decimal TotalCredito, decimal TotalCobrado, decimal TotalPendiente, int CuentasAbiertas, int Vencidas) ObtenerResumen()
        {
            var cuentas = Listar();
            decimal totalCredito = 0m;
            decimal totalCobrado = 0m;
            decimal totalPendiente = 0m;
            int abiertas = 0;
            int vencidas = 0;

            foreach (var c in cuentas)
            {
                totalCredito += c.TotalCredito;
                totalCobrado += c.MontoPagado;
                totalPendiente += c.SaldoPendiente;
                if (c.Estado != "PAGADO") abiertas++;
                if (c.Estado == "VENCIDO") vencidas++;
            }

            return (totalCredito, totalCobrado, totalPendiente, abiertas, vencidas);
        }
    }
}
