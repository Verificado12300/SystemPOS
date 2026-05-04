using SistemaPOS.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace SistemaPOS.Data
{
    public class ClienteRepository
    {
        // ==================== MÉTODOS CRUD ====================

        public static bool Crear(Cliente cliente)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                INSERT INTO Clientes (
                    TipoDocumento, NumeroDocumento, Nombres, Apellidos, RazonSocial,
                    Direccion, Telefono, Email, LimiteCredito, Activo, FechaRegistro
                ) VALUES (
                    @TipoDocumento, @NumeroDocumento, @Nombres, @Apellidos, @RazonSocial,
                    @Direccion, @Telefono, @Email, @LimiteCredito, @Activo, @FechaRegistro
                )";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@TipoDocumento", cliente.TipoDocumento);
                        cmd.Parameters.AddWithValue("@NumeroDocumento", cliente.NumeroDocumento);
                        cmd.Parameters.AddWithValue("@Nombres", (cliente.Nombres ?? "").Substring(0, Math.Min((cliente.Nombres ?? "").Length, 100)));
                        cmd.Parameters.AddWithValue("@Apellidos", (cliente.Apellidos ?? "").Substring(0, Math.Min((cliente.Apellidos ?? "").Length, 100)));
                        cmd.Parameters.AddWithValue("@RazonSocial", (cliente.RazonSocial ?? "").Substring(0, Math.Min((cliente.RazonSocial ?? "").Length, 200)));
                        cmd.Parameters.AddWithValue("@Direccion", (cliente.Direccion ?? "").Substring(0, Math.Min((cliente.Direccion ?? "").Length, 300)));
                        cmd.Parameters.AddWithValue("@Telefono", (cliente.Telefono ?? "").Substring(0, Math.Min((cliente.Telefono ?? "").Length, 20)));
                        cmd.Parameters.AddWithValue("@Email", (cliente.Email ?? "").Substring(0, Math.Min((cliente.Email ?? "").Length, 100)));
                        cmd.Parameters.AddWithValue("@LimiteCredito", cliente.LimiteCredito);
                        cmd.Parameters.AddWithValue("@Activo", cliente.Activo ? 1 : 0);
                        cmd.Parameters.AddWithValue("@FechaRegistro", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        int affected = cmd.ExecuteNonQuery();
                        return affected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear cliente: {ex.Message}", ex);
            }
        }

        public static bool Actualizar(Cliente cliente)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                        UPDATE Clientes SET
                            TipoDocumento = @TipoDocumento,
                            NumeroDocumento = @NumeroDocumento,
                            Nombres = @Nombres,
                            Apellidos = @Apellidos,
                            RazonSocial = @RazonSocial,
                            Direccion = @Direccion,
                            Telefono = @Telefono,
                            Email = @Email,
                            LimiteCredito = @LimiteCredito,
                            Activo = @Activo
                        WHERE ClienteID = @ClienteID";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ClienteID", cliente.ClienteID);
                        cmd.Parameters.AddWithValue("@TipoDocumento", cliente.TipoDocumento);
                        cmd.Parameters.AddWithValue("@NumeroDocumento", cliente.NumeroDocumento);
                        cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres ?? "");
                        cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos ?? "");
                        cmd.Parameters.AddWithValue("@RazonSocial", cliente.RazonSocial ?? "");
                        cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion ?? "");
                        cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono ?? "");
                        cmd.Parameters.AddWithValue("@Email", cliente.Email ?? "");
                        cmd.Parameters.AddWithValue("@LimiteCredito", cliente.LimiteCredito);
                        cmd.Parameters.AddWithValue("@Activo", cliente.Activo ? 1 : 0);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar cliente: {ex.Message}");
            }
        }

        public static Cliente ObtenerPorID(int clienteID)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT * FROM Clientes WHERE ClienteID = @ClienteID";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ClienteID", clienteID);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Reemplaza el bloque 'return new Cliente { ... }' por este:
                                return new Cliente
                                {
                                    ClienteID = reader.IsDBNull(reader.GetOrdinal("ClienteID")) ? 0 : reader.GetInt32(reader.GetOrdinal("ClienteID")),
                                    TipoDocumento = reader.IsDBNull(reader.GetOrdinal("TipoDocumento")) ? "" : reader.GetString(reader.GetOrdinal("TipoDocumento")),
                                    NumeroDocumento = reader.IsDBNull(reader.GetOrdinal("NumeroDocumento")) ? "" : reader.GetString(reader.GetOrdinal("NumeroDocumento")),
                                    Nombres = reader.IsDBNull(reader.GetOrdinal("Nombres")) ? "" : reader.GetString(reader.GetOrdinal("Nombres")),
                                    Apellidos = reader.IsDBNull(reader.GetOrdinal("Apellidos")) ? "" : reader.GetString(reader.GetOrdinal("Apellidos")),
                                    RazonSocial = reader.IsDBNull(reader.GetOrdinal("RazonSocial")) ? "" : reader.GetString(reader.GetOrdinal("RazonSocial")),
                                    Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? "" : reader.GetString(reader.GetOrdinal("Direccion")),
                                    Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? "" : reader.GetString(reader.GetOrdinal("Telefono")),
                                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? "" : reader.GetString(reader.GetOrdinal("Email")),
                                    LimiteCredito = reader.IsDBNull(reader.GetOrdinal("LimiteCredito")) ? 0m : Convert.ToDecimal(reader.GetValue(reader.GetOrdinal("LimiteCredito"))),
                                    Activo = !reader.IsDBNull(reader.GetOrdinal("Activo")) && Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Activo"))) == 1,
                                    FechaRegistro = reader.IsDBNull(reader.GetOrdinal("FechaRegistro")) ? DateTime.MinValue : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("FechaRegistro")))
                                };

                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener cliente: {ex.Message}");
            }
        }

        public static List<dynamic> Listar(string buscar = null, string filtroTipo = null, string filtroEstado = null)
        {
            var clientes = new List<dynamic>();

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    // SaldoPendiente = TotalVentas(CREDITO) - OldPayments(MontoEfectivo etc) - NewPayments(PagoVenta)
                    string query = @"
                SELECT 
                    c.ClienteID,
                    c.TipoDocumento,
                    c.NumeroDocumento,
                    CASE 
                        WHEN c.TipoDocumento = 'RUC' THEN c.RazonSocial
                        ELSE c.Nombres || ' ' || c.Apellidos
                    END as NombreCompleto,
                    c.Telefono,
                    c.Email,
                    c.Direccion,
                    c.LimiteCredito,
                    c.Activo,
                    COALESCE((
                        SELECT SUM(v.Total - v.MontoEfectivo - v.MontoYape - v.MontoTransferencia - v.MontoTarjeta)
                        FROM Ventas v
                        WHERE v.ClienteID = c.ClienteID AND v.MetodoPago = 'CREDITO' AND v.Estado != 'ANULADA'
                    ), 0)
                    - COALESCE((
                        SELECT SUM(pv.MontoAplicado)
                        FROM PagoVenta pv
                        INNER JOIN Ventas v ON pv.VentaID = v.VentaID
                        WHERE v.ClienteID = c.ClienteID AND v.MetodoPago = 'CREDITO'
                          AND (pv.Anulado IS NULL OR pv.Anulado = 0)
                    ), 0) as SaldoPendiente
                FROM Clientes c
                WHERE c.ClienteID != 1";

                    if (!string.IsNullOrWhiteSpace(buscar))
                    {
                        query += @" AND (
                    c.NumeroDocumento LIKE @Buscar OR
                    c.Nombres LIKE @Buscar OR
                    c.Apellidos LIKE @Buscar OR
                    c.RazonSocial LIKE @Buscar OR
                    c.Telefono LIKE @Buscar OR
                    c.Email LIKE @Buscar
                )";
                    }

                    if (!string.IsNullOrWhiteSpace(filtroTipo))
                    {
                        if (filtroTipo == "Persona_Natural")
                            query += " AND c.TipoDocumento IN ('DNI', 'CEE')";
                        else if (filtroTipo == "Empresa")
                            query += " AND c.TipoDocumento = 'RUC'";
                    }

                    if (!string.IsNullOrWhiteSpace(filtroEstado))
                    {
                        if (filtroEstado == "PAGADO")
                            query += @" AND (
                        COALESCE((SELECT SUM(v.Total - v.MontoEfectivo - v.MontoYape - v.MontoTransferencia - v.MontoTarjeta) FROM Ventas v WHERE v.ClienteID = c.ClienteID AND v.MetodoPago = 'CREDITO' AND v.Estado != 'ANULADA'), 0)
                        - COALESCE((SELECT SUM(pv.MontoAplicado) FROM PagoVenta pv INNER JOIN Ventas v ON pv.VentaID = v.VentaID WHERE v.ClienteID = c.ClienteID AND v.MetodoPago = 'CREDITO' AND (pv.Anulado IS NULL OR pv.Anulado = 0)), 0)
                    ) <= 0";
                        else if (filtroEstado == "PENDIENTE")
                            query += @" AND (
                        COALESCE((SELECT SUM(v.Total - v.MontoEfectivo - v.MontoYape - v.MontoTransferencia - v.MontoTarjeta) FROM Ventas v WHERE v.ClienteID = c.ClienteID AND v.MetodoPago = 'CREDITO' AND v.Estado != 'ANULADA'), 0)
                        - COALESCE((SELECT SUM(pv.MontoAplicado) FROM PagoVenta pv INNER JOIN Ventas v ON pv.VentaID = v.VentaID WHERE v.ClienteID = c.ClienteID AND v.MetodoPago = 'CREDITO' AND (pv.Anulado IS NULL OR pv.Anulado = 0)), 0)
                    ) > 0";
                    }

                    query += " ORDER BY c.ClienteID DESC";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        if (!string.IsNullOrWhiteSpace(buscar))
                            cmd.Parameters.AddWithValue("@Buscar", "%" + buscar + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clientes.Add(new
                                {
                                    ClienteID = reader.GetInt32(0),
                                    TipoDocumento = reader.GetString(1),
                                    NumeroDocumento = reader.GetString(2),
                                    NombreCompleto = reader.GetString(3),
                                    Telefono = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                    Email = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                    Direccion = reader.IsDBNull(6) ? "" : reader.GetString(6),
                                    LimiteCredito = reader.GetDecimal(7),
                                    Activo = reader.GetInt32(8) == 1,
                                    SaldoPendiente = reader.GetDecimal(9)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al listar clientes: {ex.Message}");
            }

            return clientes;
        }

        // ==================== CUENTA CORRIENTE ====================

        public static dynamic ObtenerEstadoCuenta(int clienteID)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    var cliente = ObtenerPorID(clienteID);
                    if (cliente == null)
                        throw new Exception("Cliente no encontrado");

                    // TotalVentas: solo ventas CREDITO (no anuladas)
                    // TotalPagos: OldPayments (MontoEfectivo etc en Ventas) + NewPayments (tabla Pagos)
                    string queryTotales = @"
                        SELECT 
                            COALESCE((
                                SELECT SUM(Total) FROM Ventas 
                                WHERE ClienteID = @ClienteID AND MetodoPago = 'CREDITO' AND Estado != 'ANULADA'
                            ), 0) as TotalVentas,
                            COALESCE((
                                SELECT SUM(MontoEfectivo + MontoYape + MontoTransferencia + MontoTarjeta) FROM Ventas 
                                WHERE ClienteID = @ClienteID AND MetodoPago = 'CREDITO' AND Estado != 'ANULADA'
                            ), 0) as OldPayments,
                            COALESCE((
                                SELECT SUM(pv.MontoAplicado)
                                FROM PagoVenta pv
                                INNER JOIN Ventas vv ON vv.VentaID = pv.VentaID
                                WHERE vv.ClienteID = @ClienteID
                                  AND vv.MetodoPago = 'CREDITO'
                                  AND (pv.Anulado IS NULL OR pv.Anulado = 0)
                            ), 0) as NewPayments";

                    decimal totalVentas = 0;
                    decimal totalPagos = 0;

                    using (var cmd = new SQLiteCommand(queryTotales, connection))
                    {
                        cmd.Parameters.AddWithValue("@ClienteID", clienteID);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                totalVentas = reader.IsDBNull(0) ? 0m : Convert.ToDecimal(reader.GetValue(0));
                                decimal oldPayments = reader.IsDBNull(1) ? 0m : Convert.ToDecimal(reader.GetValue(1));
                                decimal newPayments = reader.IsDBNull(2) ? 0m : Convert.ToDecimal(reader.GetValue(2));
                                totalPagos = oldPayments + newPayments;

                            }
                        }
                    }

                    decimal saldoPendiente = totalVentas - totalPagos;
                    decimal creditoUtilizado = saldoPendiente > 0 ? saldoPendiente : 0;
                    decimal creditoDisponible = cliente.LimiteCredito - creditoUtilizado;

                    return new
                    {
                        Cliente = cliente,
                        TotalVentas = totalVentas,
                        TotalPagos = totalPagos,
                        SaldoPendiente = saldoPendiente,
                        LimiteCredito = cliente.LimiteCredito,
                        CreditoUtilizado = creditoUtilizado,
                        CreditoDisponible = creditoDisponible
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener estado de cuenta: {ex.Message}");
            }
        }

        public static List<dynamic> ObtenerMovimientos(int clienteID, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            // Usamos una estructura para poder ordenar antes de calcular saldo
            var items = new List<(DateTime Fecha, TimeSpan Hora, int Orden, string Tipo, string Detalle, decimal Cargo, decimal Abono)>();

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    // ---- 1. Obtener ventas CREDITO + sus pagos antiguos (MontoEfectivo etc) ----
                    string queryVentas = @"
                        SELECT Fecha, Hora, NumeroVenta, Total,
                            MontoEfectivo + MontoYape + MontoTransferencia + MontoTarjeta as OldPayment,
                            CASE
                                WHEN MontoEfectivo > 0 AND MontoYape = 0 AND MontoTransferencia = 0 AND MontoTarjeta = 0 THEN 'Efectivo'
                                WHEN MontoYape > 0 AND MontoEfectivo = 0 AND MontoTransferencia = 0 AND MontoTarjeta = 0 THEN 'Yape'
                                WHEN MontoTransferencia > 0 AND MontoEfectivo = 0 AND MontoYape = 0 AND MontoTarjeta = 0 THEN 'Transferencia'
                                WHEN (MontoEfectivo + MontoYape + MontoTransferencia + MontoTarjeta) > 0 THEN 'Mixto'
                                ELSE ''
                            END as OldPayMethod
                        FROM Ventas
                        WHERE ClienteID = @ClienteID AND MetodoPago = 'CREDITO' AND Estado != 'ANULADA'";

                    if (fechaDesde.HasValue)
                        queryVentas += " AND Fecha >= @FechaDesde";
                    if (fechaHasta.HasValue)
                        queryVentas += " AND Fecha <= @FechaHasta";
                    queryVentas += " ORDER BY Fecha ASC, Hora ASC";

                    using (var cmd = new SQLiteCommand(queryVentas, connection))
                    {
                        cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                        if (fechaDesde.HasValue)
                            cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde.Value.ToString("yyyy-MM-dd"));
                        if (fechaHasta.HasValue)
                            cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta.Value.ToString("yyyy-MM-dd"));

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime fecha = DateTime.Parse(reader.GetString(0));
                                TimeSpan hora = TimeSpan.Parse(reader.GetString(1));

                                // Agregar la VENTA (Orden=0 → aparece antes que pagos del mismo momento)
                                items.Add((fecha, hora, 0, "VENTA", reader.GetString(2), reader.GetDecimal(3), 0m));

                                // Agregar pago antiguo si existe (Orden=1)
                                decimal oldPayment = reader.GetDecimal(4);
                                if (oldPayment > 0)
                                {
                                    items.Add((fecha, hora, 1, "PAGO", reader.GetString(5), 0m, oldPayment));
                                }
                            }
                        }
                    }

                    // ---- 2. Obtener pagos NUEVOS de la tabla Pagos ----
                    string queryPagos = @"
                        SELECT FechaPago, HoraPago, MetodoPago, Monto, Observaciones
                        FROM Pagos
                        WHERE ClienteID = @ClienteID2";

                    if (fechaDesde.HasValue)
                        queryPagos += " AND FechaPago >= @FechaDesde2";
                    if (fechaHasta.HasValue)
                        queryPagos += " AND FechaPago <= @FechaHasta2";
                    queryPagos += " ORDER BY FechaPago ASC, HoraPago ASC";

                    using (var cmd = new SQLiteCommand(queryPagos, connection))
                    {
                        cmd.Parameters.AddWithValue("@ClienteID2", clienteID);
                        if (fechaDesde.HasValue)
                            cmd.Parameters.AddWithValue("@FechaDesde2", fechaDesde.Value.ToString("yyyy-MM-dd"));
                        if (fechaHasta.HasValue)
                            cmd.Parameters.AddWithValue("@FechaHasta2", fechaHasta.Value.ToString("yyyy-MM-dd"));

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime fecha = DateTime.Parse(reader.GetString(0));
                                TimeSpan hora = TimeSpan.Parse(reader.GetString(1));
                                string metodo = reader.GetString(2);
                                string obs = reader.IsDBNull(4) ? "" : reader.GetString(4);
                                string detalle = !string.IsNullOrWhiteSpace(obs) ? metodo + " - " + obs : metodo;

                                items.Add((fecha, hora, 1, "PAGO", detalle, 0m, reader.GetDecimal(3)));
                            }
                        }
                    }
                }

                // ---- 3. Ordenar cronológicamente ----
                // Fecha ASC → Hora ASC → Orden ASC (VENTA antes que PAGO en mismo momento)
                items.Sort((a, b) =>
                {
                    int cmp = a.Fecha.CompareTo(b.Fecha);
                    if (cmp != 0) return cmp;
                    cmp = a.Hora.CompareTo(b.Hora);
                    if (cmp != 0) return cmp;
                    return a.Orden.CompareTo(b.Orden);
                });

                // ---- 4. Calcular saldo acumulado ----
                var movimientos = new List<dynamic>();
                decimal saldoAcumulado = 0;

                foreach (var item in items)
                {
                    if (item.Tipo == "VENTA")
                        saldoAcumulado += item.Cargo;
                    else
                        saldoAcumulado -= item.Abono;

                    movimientos.Add(new
                    {
                        Fecha = item.Fecha,
                        Hora = item.Hora,
                        Tipo = item.Tipo,
                        Detalle = item.Detalle,
                        Cargo = item.Cargo,
                        Abono = item.Abono,
                        Saldo = saldoAcumulado
                    });
                }

                // ---- 5. Invertir: más reciente primero ----
                movimientos.Reverse();
                return movimientos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener movimientos: {ex.Message}");
            }
        }

        // ==================== REGISTRAR PAGO (Sistema nuevo con tabla Pagos + PagoVenta) ====================

        public static bool RegistrarPago(int clienteID, decimal monto, string metodoPago, DateTime fecha,
            string observaciones = "", decimal montoEfectivo = 0, decimal montoYape = 0, decimal montoTransferencia = 0)
        {
            try
            {
                if (monto <= 0)
                    throw new Exception("El monto del pago debe ser mayor a cero.");

                using (var connection = DatabaseConnection.GetConnection())
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // ---- 1. Obtener ventas pendientes del cliente ----
                            // SaldoVenta = Total - OldPayments - NewPayments(PagoVenta existentes)
                            string queryVentas = @"
                                SELECT v.VentaID, v.Total, v.NumeroVenta,
                                    (v.MontoEfectivo + v.MontoYape + v.MontoTransferencia + v.MontoTarjeta) as OldPayments,
                                    COALESCE((SELECT SUM(pv.MontoAplicado) FROM PagoVenta pv WHERE pv.VentaID = v.VentaID AND (pv.Anulado IS NULL OR pv.Anulado = 0)), 0) as NewPayments
                                FROM Ventas v
                                WHERE v.ClienteID = @ClienteID AND v.MetodoPago = 'CREDITO' AND v.Estado = 'CREDITO'
                                ORDER BY v.Fecha ASC, v.Hora ASC";

                            var ventasPendientes = new List<dynamic>();

                            using (var cmdVentas = new SQLiteCommand(queryVentas, connection, transaction))
                            {
                                cmdVentas.Parameters.AddWithValue("@ClienteID", clienteID);

                                using (var reader = cmdVentas.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        ventasPendientes.Add(new
                                        {
                                            VentaID     = reader.GetInt32(0),
                                            Total       = reader.GetDecimal(1),
                                            NumeroVenta = reader.GetString(2),
                                            OldPayments = reader.GetDecimal(3),
                                            NewPayments = reader.GetDecimal(4)
                                        });
                                    }
                                }
                            }

                            decimal saldoTotal = 0;
                            foreach (var venta in ventasPendientes)
                            {
                                decimal saldoVenta = venta.Total - venta.OldPayments - venta.NewPayments;
                                if (saldoVenta > 0)
                                    saldoTotal += saldoVenta;
                            }

                            if (saldoTotal <= 0)
                                throw new Exception("El cliente no tiene saldos pendientes para aplicar el pago.");

                            if (monto > saldoTotal + 0.01m)
                                throw new Exception("El monto del pago excede el saldo pendiente del cliente.");

                            // ---- 2. Crear registro en tabla Pagos ----
                            string insertPago = @"
                                INSERT INTO Pagos (ClienteID, Monto, MetodoPago, MontoEfectivo, MontoYape, MontoTransferencia, FechaPago, HoraPago, Observaciones)
                                VALUES (@ClienteID, @Monto, @MetodoPago, @MontoEfectivo, @MontoYape, @MontoTransferencia, @FechaPago, @HoraPago, @Observaciones)";

                            using (var cmdPago = new SQLiteCommand(insertPago, connection, transaction))
                            {
                                cmdPago.Parameters.AddWithValue("@ClienteID", clienteID);
                                cmdPago.Parameters.AddWithValue("@Monto", monto);
                                cmdPago.Parameters.AddWithValue("@MetodoPago", metodoPago);
                                cmdPago.Parameters.AddWithValue("@MontoEfectivo", montoEfectivo);
                                cmdPago.Parameters.AddWithValue("@MontoYape", montoYape);
                                cmdPago.Parameters.AddWithValue("@MontoTransferencia", montoTransferencia);
                                cmdPago.Parameters.AddWithValue("@FechaPago", fecha.ToString("yyyy-MM-dd"));
                                cmdPago.Parameters.AddWithValue("@HoraPago", $"{DateTime.Now.Hour:D2}:{DateTime.Now.Minute:D2}:{DateTime.Now.Second:D2}");
                                cmdPago.Parameters.AddWithValue("@Observaciones", observaciones ?? "");
                                cmdPago.ExecuteNonQuery();
                            }

                            // Obtener el PagoID insertado
                            int pagoID;
                            using (var cmdId = new SQLiteCommand("SELECT last_insert_rowid()", connection, transaction))
                            {
                                pagoID = Convert.ToInt32(cmdId.ExecuteScalar());
                            }

                            // ---- 3. Aplicar el pago FIFO: distribuir entre ventas pendientes ----
                            decimal montoRestante = monto;

                            foreach (var venta in ventasPendientes)
                            {
                                if (montoRestante <= 0) break;

                                decimal saldoVenta = venta.Total - venta.OldPayments - venta.NewPayments;
                                if (saldoVenta <= 0) continue;

                                decimal montoAPagar = Math.Min(montoRestante, saldoVenta);

                                using (var cmdPV = new SQLiteCommand(
                                    "INSERT INTO PagoVenta (PagoID, VentaID, MontoAplicado) VALUES (@PagoID, @VentaID, @MontoAplicado)",
                                    connection, transaction))
                                {
                                    cmdPV.Parameters.AddWithValue("@PagoID",        pagoID);
                                    cmdPV.Parameters.AddWithValue("@VentaID",       venta.VentaID);
                                    cmdPV.Parameters.AddWithValue("@MontoAplicado", montoAPagar);
                                    cmdPV.ExecuteNonQuery();
                                }

                                if (montoAPagar >= saldoVenta)
                                {
                                    using (var cmdEstado = new SQLiteCommand(
                                        "UPDATE Ventas SET Estado = 'COMPLETADA' WHERE VentaID = @VentaID",
                                        connection, transaction))
                                    {
                                        cmdEstado.Parameters.AddWithValue("@VentaID", venta.VentaID);
                                        cmdEstado.ExecuteNonQuery();
                                    }
                                }

                                montoRestante -= montoAPagar;
                            }

                            // ---- 4. UN asiento contable por pago (no por documento) ----
                            // Guard: solo si Pagos aún no tiene asiento
                            long asientoExistente;
                            using (var cmdChk = new SQLiteCommand(
                                "SELECT COALESCE(AsientoId, 0) FROM Pagos WHERE PagoID = @pid",
                                connection, transaction))
                            {
                                cmdChk.Parameters.AddWithValue("@pid", pagoID);
                                asientoExistente = Convert.ToInt64(cmdChk.ExecuteScalar() ?? 0L);
                            }
                            if (asientoExistente == 0)
                            {
                                int usuarioID = SistemaPOS.Utils.SesionActual.Usuario?.UsuarioID ?? 0;
                                string docRef = $"PAGO-{pagoID:D6}";
                                int asientoId = ContabilidadService.RegistrarCobroCxC(
                                    0, docRef, monto,
                                    metodoPago, montoEfectivo, montoYape, montoTransferencia,
                                    monto, fecha, usuarioID, connection, transaction);
                                if (asientoId > 0)
                                {
                                    using (var cmdUpd = new SQLiteCommand(
                                        "UPDATE Pagos SET AsientoId = @aid WHERE PagoID = @pid",
                                        connection, transaction))
                                    {
                                        cmdUpd.Parameters.AddWithValue("@aid", asientoId);
                                        cmdUpd.Parameters.AddWithValue("@pid", pagoID);
                                        cmdUpd.ExecuteNonQuery();
                                    }
                                }
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
            catch (Exception ex)
            {
                throw new Exception($"Error al registrar pago: {ex.Message}");
            }
        }

        // ==================== ANULAR COBRO CxC — NIVEL PAGO (nuevo modelo) ====================
        // Anula el pago completo: reversa UN asiento, marca todos los PagoVenta activos
        // y recalcula el estado de todas las ventas afectadas.

        public static void AnularPago(int pagoID, int usuarioID)
        {
            using (var connection = DatabaseConnection.GetConnection())
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // 1. Leer datos del pago
                    decimal monto, montoEf, montoYape, montoTransf;
                    string  metodoPago;
                    DateTime fechaPago;

                    using (var cmd = new SQLiteCommand(@"
                        SELECT Monto, MetodoPago, MontoEfectivo, MontoYape, MontoTransferencia, FechaPago
                        FROM Pagos WHERE PagoID = @pid", connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@pid", pagoID);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (!r.Read())
                                throw new Exception("Pago no encontrado.");
                            monto          = r.GetDecimal(0);
                            metodoPago     = r.GetString(1);
                            montoEf        = r.GetDecimal(2);
                            montoYape      = r.GetDecimal(3);
                            montoTransf    = r.GetDecimal(4);
                            fechaPago      = DateTime.Parse(r.GetString(5));
                        }
                    }

                    // 2. Verificar que al menos un PagoVenta esté activo
                    int activosCount;
                    using (var cmd = new SQLiteCommand(
                        "SELECT COUNT(*) FROM PagoVenta WHERE PagoID = @pid AND (Anulado IS NULL OR Anulado = 0)",
                        connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@pid", pagoID);
                        activosCount = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                    }
                    if (activosCount == 0)
                        throw new Exception("Este pago ya está completamente anulado.");

                    // 3. Asiento inverso ÚNICO por el total del pago
                    ContabilidadService.RegistrarAnulacionCobroCxC(
                        pagoID, 0, $"PAGO-{pagoID:D6}", monto,
                        metodoPago, montoEf, montoYape, montoTransf,
                        monto, fechaPago, usuarioID, connection, transaction);

                    // 4. Marcar TODOS los PagoVenta activos como anulados
                    string ahora   = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string usuario = SistemaPOS.Utils.SesionActual.Usuario?.NombreUsuario ?? "Sistema";
                    using (var cmd = new SQLiteCommand(@"
                        UPDATE PagoVenta
                        SET Anulado=1, AnuladoFecha=@fecha, AnuladoPor=@usuario, Motivo='Anulación pago'
                        WHERE PagoID=@pid AND (Anulado IS NULL OR Anulado = 0)",
                        connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@pid",    pagoID);
                        cmd.Parameters.AddWithValue("@fecha",  ahora);
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.ExecuteNonQuery();
                    }

                    // 5. Recalcular estado de TODAS las ventas afectadas por este pago
                    using (var cmd = new SQLiteCommand(@"
                        UPDATE Ventas SET Estado =
                            CASE WHEN COALESCE((SELECT SUM(pv2.MontoAplicado)
                                                FROM PagoVenta pv2
                                                WHERE pv2.VentaID = Ventas.VentaID
                                                  AND (pv2.Anulado IS NULL OR pv2.Anulado = 0)), 0)
                                      >= Total
                                 THEN 'COMPLETADA'
                                 ELSE 'CREDITO'
                            END
                        WHERE VentaID IN (
                            SELECT VentaID FROM PagoVenta WHERE PagoID = @pid)",
                        connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@pid", pagoID);
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

        // ==================== ANULAR COBRO CxC — NIVEL PAGOVENTA (legacy) ====================

        public static void AnularPagoCxC(int pagoVentaID, int usuarioID, string motivo = "")
        {
            using (var connection = DatabaseConnection.GetConnection())
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // 1. Leer datos del PagoVenta + Pagos + Ventas
                    int    ventaID, pagoID;
                    decimal montoAplicado, totalPago, montoEf, montoYape, montoTransf;
                    string  metodoPago, numeroVenta;
                    DateTime fechaPago;
                    bool yaAnulado;

                    using (var cmd = new SQLiteCommand(@"
                        SELECT pv.PagoVentaID, pv.VentaID, pv.PagoID, pv.MontoAplicado,
                               COALESCE(pv.Anulado, 0),
                               p.MetodoPago, p.Monto, p.MontoEfectivo, p.MontoYape, p.MontoTransferencia,
                               p.FechaPago,
                               v.NumeroVenta
                        FROM PagoVenta pv
                        INNER JOIN Pagos p  ON p.PagoID  = pv.PagoID
                        INNER JOIN Ventas v ON v.VentaID = pv.VentaID
                        WHERE pv.PagoVentaID = @pvID", connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@pvID", pagoVentaID);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (!r.Read())
                                throw new Exception("Registro de pago no encontrado.");
                            yaAnulado     = r.GetInt32(4) == 1;
                            ventaID       = r.GetInt32(1);
                            pagoID        = r.GetInt32(2);
                            montoAplicado = r.GetDecimal(3);
                            metodoPago    = r.GetString(5);
                            totalPago     = r.GetDecimal(6);
                            montoEf       = r.GetDecimal(7);
                            montoYape     = r.GetDecimal(8);
                            montoTransf   = r.GetDecimal(9);
                            fechaPago     = DateTime.Parse(r.GetString(10));
                            numeroVenta   = r.GetString(11);
                        }
                    }

                    if (yaAnulado)
                        throw new Exception("Este cobro ya está anulado.");

                    // 2. Asiento inverso: Dr 120 / Cr 101|102
                    ContabilidadService.RegistrarAnulacionCobroCxC(
                        pagoVentaID, ventaID, numeroVenta, montoAplicado,
                        metodoPago, montoEf, montoYape, montoTransf,
                        totalPago, fechaPago, usuarioID, connection, transaction);

                    // 3. Marcar PagoVenta como anulado
                    string ahora  = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string usuario = SistemaPOS.Utils.SesionActual.Usuario?.NombreUsuario ?? "Sistema";
                    using (var cmd = new SQLiteCommand(@"
                        UPDATE PagoVenta
                        SET Anulado=1, AnuladoFecha=@fecha, AnuladoPor=@usuario, Motivo=@motivo
                        WHERE PagoVentaID=@pvID", connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@fecha",   ahora);
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@motivo",  motivo ?? "");
                        cmd.Parameters.AddWithValue("@pvID",    pagoVentaID);
                        cmd.ExecuteNonQuery();
                    }

                    // 4. Recalcular estado de la Venta (solo pagos no anulados)
                    using (var cmd = new SQLiteCommand(@"
                        UPDATE Ventas SET Estado =
                            CASE WHEN COALESCE((SELECT SUM(pv2.MontoAplicado)
                                                FROM PagoVenta pv2
                                                WHERE pv2.VentaID = @ventaID
                                                  AND (pv2.Anulado IS NULL OR pv2.Anulado = 0)), 0)
                                      >= Total
                                 THEN 'COMPLETADA'
                                 ELSE 'CREDITO'
                            END
                        WHERE VentaID = @ventaID", connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ventaID", ventaID);
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

        // ==================== VALIDACIONES ====================

        public static bool ExisteDocumento(string numeroDocumento, int? clienteIDExcluir = null)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT COUNT(*) FROM Clientes WHERE NumeroDocumento = @NumeroDocumento";

                    if (clienteIDExcluir.HasValue)
                        query += " AND ClienteID != @ClienteID";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@NumeroDocumento", numeroDocumento);

                        if (clienteIDExcluir.HasValue)
                            cmd.Parameters.AddWithValue("@ClienteID", clienteIDExcluir.Value);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al verificar documento: {ex.Message}");
            }
        }

        // ==================== ELIMINAR CLIENTE ====================
        public static bool Eliminar(int clienteID)
        {
            try
            {
                // Evitar eliminar el cliente general (ID = 1)
                if (clienteID == 1)
                    return false;

                string user = SistemaPOS.Utils.SesionActual.Usuario?.NombreUsuario ?? "Sistema";

                using (var conn = DatabaseConnection.GetConnection())
                using (var tx   = conn.BeginTransaction())
                {
                    try
                    {
                        string resumen;
                        using (var cmd = new SQLiteCommand(
                            "SELECT TRIM(COALESCE(Nombres,'') || ' ' || COALESCE(Apellidos,'')) FROM Clientes WHERE ClienteID=@id",
                            conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@id", clienteID);
                            resumen = cmd.ExecuteScalar()?.ToString()?.Trim() ?? $"Cliente #{clienteID}";
                            if (string.IsNullOrEmpty(resumen)) resumen = $"Cliente #{clienteID}";
                        }

                        PapeleraService.SoftDelete("CLIENTE", clienteID, resumen, user, conn, tx);
                        tx.Commit();
                        return true;
                    }
                    catch { tx.Rollback(); throw; }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar cliente: {ex.Message}");
            }
        }

        // ==================== OBTENER CLIENTE GENERAL ====================
        public static Cliente ObtenerClienteGeneral()
        {
            return ObtenerPorID(1);
        }

        // ==================== MOVIMIENTOS UNIFICADOS (nueva vista) ====================

        /// <summary>
        /// Devuelve los movimientos de cuenta del cliente ordenados ASC con saldo
        /// acumulado calculado en memoria.  Reglas por tipo:
        ///   VENTA            → cargo  (saldo sube).
        ///   PAGO             → abono, solo si Anulado=0 (saldo baja).
        ///   ANULACION_COBRO  → cargo por pago anulado (saldo sube).
        ///                      El PAGO anulado NO aparece como fila separada.
        /// </summary>
        public static List<MovimientoCuenta> ObtenerMovimientosCuentaCliente(
            int clienteID,
            DateTime? fechaDesde = null,
            DateTime? fechaHasta = null,
            string buscar = null)
        {
            var raw = new List<MovimientoCuenta>();

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    // ---- 1. Ventas CREDITO no anuladas/eliminadas ----
                    var sbV = new StringBuilder(@"
                        SELECT Fecha, Hora, NumeroVenta, Total
                        FROM Ventas
                        WHERE ClienteID = @cid
                          AND MetodoPago = 'CREDITO'
                          AND Estado != 'ANULADA'
                          AND (Eliminado IS NULL OR Eliminado = 0)");
                    if (fechaDesde.HasValue) sbV.Append(" AND Fecha >= @fd");
                    if (fechaHasta.HasValue) sbV.Append(" AND Fecha <= @fh");

                    using (var cmd = new SQLiteCommand(sbV.ToString(), conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", clienteID);
                        if (fechaDesde.HasValue)
                            cmd.Parameters.AddWithValue("@fd", fechaDesde.Value.ToString("yyyy-MM-dd"));
                        if (fechaHasta.HasValue)
                            cmd.Parameters.AddWithValue("@fh", fechaHasta.Value.ToString("yyyy-MM-dd"));

                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                                raw.Add(new MovimientoCuenta
                                {
                                    Fecha      = DateTime.Parse(r.GetString(0)),
                                    Hora       = TimeSpan.Parse(r.GetString(1)),
                                    Tipo       = "VENTA",
                                    Documento  = r.GetString(2),
                                    Metodo     = "CRÉDITO",
                                    Cargo      = Convert.ToDecimal(r.GetValue(3)),
                                    OrdenSort  = 0
                                });
                        }
                    }

                    // ---- 2. Pagos antiguos embebidos en Ventas (MontoEfectivo etc) ----
                    var sbOld = new StringBuilder(@"
                        SELECT Fecha, Hora, NumeroVenta,
                            (MontoEfectivo + MontoYape + MontoTransferencia + MontoTarjeta) as OldPmt,
                            CASE
                                WHEN MontoEfectivo > 0 AND MontoYape = 0 AND MontoTransferencia = 0 AND MontoTarjeta = 0 THEN 'Efectivo'
                                WHEN MontoYape > 0 AND MontoEfectivo = 0 AND MontoTransferencia = 0 AND MontoTarjeta = 0 THEN 'Yape'
                                WHEN MontoTransferencia > 0 AND MontoEfectivo = 0 AND MontoYape = 0 AND MontoTarjeta = 0 THEN 'Transferencia'
                                WHEN (MontoEfectivo + MontoYape + MontoTransferencia + MontoTarjeta) > 0 THEN 'Mixto'
                                ELSE ''
                            END as Metodo
                        FROM Ventas
                        WHERE ClienteID = @cid
                          AND MetodoPago = 'CREDITO'
                          AND Estado != 'ANULADA'
                          AND (Eliminado IS NULL OR Eliminado = 0)
                          AND (MontoEfectivo + MontoYape + MontoTransferencia + MontoTarjeta) > 0");
                    if (fechaDesde.HasValue) sbOld.Append(" AND Fecha >= @fd");
                    if (fechaHasta.HasValue) sbOld.Append(" AND Fecha <= @fh");

                    using (var cmd = new SQLiteCommand(sbOld.ToString(), conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", clienteID);
                        if (fechaDesde.HasValue)
                            cmd.Parameters.AddWithValue("@fd", fechaDesde.Value.ToString("yyyy-MM-dd"));
                        if (fechaHasta.HasValue)
                            cmd.Parameters.AddWithValue("@fh", fechaHasta.Value.ToString("yyyy-MM-dd"));

                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                                raw.Add(new MovimientoCuenta
                                {
                                    Fecha      = DateTime.Parse(r.GetString(0)),
                                    Hora       = TimeSpan.Parse(r.GetString(1)),
                                    Tipo       = "PAGO",
                                    Documento  = r.GetString(2),
                                    Metodo     = r.GetString(4),
                                    Abono      = Convert.ToDecimal(r.GetValue(3)),
                                    PuedeAnular = false,  // pagos legacy, sin PagoVentaID
                                    OrdenSort  = 1
                                });
                        }
                    }

                    // ---- 3. Pagos (agrupados por PagoID) ----
                    // UN pago = UNA fila en el historial (modelo cuenta corriente).
                    // PuedeAnular = true solo si todos los PagoVenta del pago están activos.
                    var sbPV = new StringBuilder(@"
                        SELECT p.PagoID,
                               p.FechaPago, p.HoraPago,
                               p.MetodoPago, p.Monto,
                               -- Todos anulados → pago anulado
                               CASE WHEN COUNT(pv.PagoVentaID) = SUM(COALESCE(pv.Anulado,0))
                                    THEN 1 ELSE 0 END as TodosAnulados,
                               -- Ninguno anulado → puede anular
                               CASE WHEN SUM(COALESCE(pv.Anulado,0)) = 0
                                    THEN 1 ELSE 0 END as PuedeAnular
                        FROM Pagos p
                        INNER JOIN PagoVenta pv ON pv.PagoID = p.PagoID
                        INNER JOIN Ventas    v  ON v.VentaID = pv.VentaID
                        WHERE v.ClienteID = @cid");
                    if (fechaDesde.HasValue) sbPV.Append(" AND p.FechaPago >= @fd");
                    if (fechaHasta.HasValue) sbPV.Append(" AND p.FechaPago <= @fh");
                    sbPV.Append(" GROUP BY p.PagoID");

                    using (var cmd = new SQLiteCommand(sbPV.ToString(), conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", clienteID);
                        if (fechaDesde.HasValue)
                            cmd.Parameters.AddWithValue("@fd", fechaDesde.Value.ToString("yyyy-MM-dd"));
                        if (fechaHasta.HasValue)
                            cmd.Parameters.AddWithValue("@fh", fechaHasta.Value.ToString("yyyy-MM-dd"));

                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                int     pagoID  = r.GetInt32(0);
                                var     fecha   = DateTime.Parse(r.GetString(1));
                                var     hora    = r.IsDBNull(2) ? TimeSpan.Zero : TimeSpan.Parse(r.GetString(2));
                                string  met     = r.GetString(3);
                                decimal mto     = Convert.ToDecimal(r.GetValue(4));
                                bool    anulado = r.GetInt32(5) == 1;
                                bool    puedeAnular = r.GetInt32(6) == 1;
                                string  docRef  = $"PAGO-{pagoID:D6}";

                                if (!anulado)
                                {
                                    raw.Add(new MovimientoCuenta
                                    {
                                        PagoID      = pagoID,
                                        Fecha       = fecha,
                                        Hora        = hora,
                                        Tipo        = "PAGO",
                                        Documento   = docRef,
                                        Metodo      = met,
                                        Abono       = mto,
                                        PuedeAnular = puedeAnular,
                                        OrdenSort   = 1
                                    });
                                }
                                else
                                {
                                    // Pago totalmente anulado: PAGO (abono) + ANULACION_COBRO (cargo)
                                    raw.Add(new MovimientoCuenta
                                    {
                                        PagoID      = pagoID,
                                        Fecha       = fecha,
                                        Hora        = hora,
                                        Tipo        = "PAGO",
                                        Documento   = docRef,
                                        Metodo      = met,
                                        Abono       = mto,
                                        Anulado     = true,
                                        PuedeAnular = false,
                                        OrdenSort   = 1
                                    });
                                    raw.Add(new MovimientoCuenta
                                    {
                                        Fecha     = fecha,
                                        Hora      = hora,
                                        Tipo      = "ANULACION_COBRO",
                                        Documento = docRef,
                                        Metodo    = met,
                                        Cargo     = mto,
                                        Anulado   = true,
                                        OrdenSort = 2
                                    });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener movimientos: {ex.Message}");
            }

            // Ordenar cronológicamente (ASC)
            raw.Sort((a, b) =>
            {
                int c = a.Fecha.CompareTo(b.Fecha);
                if (c != 0) return c;
                c = a.Hora.CompareTo(b.Hora);
                if (c != 0) return c;
                return a.OrdenSort.CompareTo(b.OrdenSort);
            });

            // Filtro buscar (en memoria, sobre datos ya ordenados)
            if (!string.IsNullOrWhiteSpace(buscar))
            {
                string b = buscar.ToLower();
                raw = raw.FindAll(m =>
                    (m.Tipo      ?? "").ToLower().Contains(b) ||
                    (m.Documento ?? "").ToLower().Contains(b) ||
                    (m.Metodo    ?? "").ToLower().Contains(b));
            }

            // Calcular saldo acumulado
            decimal saldo = 0;
            foreach (var mov in raw)
            {
                if (mov.Tipo == "VENTA" || mov.Tipo == "ANULACION_COBRO")
                    saldo += mov.Cargo;
                else
                    saldo -= mov.Abono;

                mov.Saldo = saldo;
            }

            return raw;
        }

        /// <summary>
        /// Suma de PagoVenta anulados (MontoAplicado) para el cliente.
        /// Usado en el resumen del estado de cuenta.
        /// </summary>
        public static decimal ObtenerTotalAnulacionesCxC(int clienteID)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = new SQLiteCommand(@"
                    SELECT COALESCE(SUM(pv.MontoAplicado), 0)
                    FROM PagoVenta pv
                    INNER JOIN Ventas v ON v.VentaID = pv.VentaID
                    WHERE v.ClienteID = @cid AND COALESCE(pv.Anulado, 0) = 1", conn))
                {
                    cmd.Parameters.AddWithValue("@cid", clienteID);
                    return Convert.ToDecimal(cmd.ExecuteScalar() ?? 0);
                }
            }
            catch
            {
                return 0m;
            }
        }

    }
}
