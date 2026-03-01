using SistemaPOS.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

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
                MessageBox.Show($"Error al crear cliente: {ex.Message}\n\nDetalles: {ex.ToString()}", "Error");
                return false;
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
                        - COALESCE((SELECT SUM(pv.MontoAplicado) FROM PagoVenta pv INNER JOIN Ventas v ON pv.VentaID = v.VentaID WHERE v.ClienteID = c.ClienteID AND v.MetodoPago = 'CREDITO'), 0)
                    ) <= 0";
                        else if (filtroEstado == "PENDIENTE")
                            query += @" AND (
                        COALESCE((SELECT SUM(v.Total - v.MontoEfectivo - v.MontoYape - v.MontoTransferencia - v.MontoTarjeta) FROM Ventas v WHERE v.ClienteID = c.ClienteID AND v.MetodoPago = 'CREDITO' AND v.Estado != 'ANULADA'), 0)
                        - COALESCE((SELECT SUM(pv.MontoAplicado) FROM PagoVenta pv INNER JOIN Ventas v ON pv.VentaID = v.VentaID WHERE v.ClienteID = c.ClienteID AND v.MetodoPago = 'CREDITO'), 0)
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
                                SELECT SUM(Monto) FROM Pagos 
                                WHERE ClienteID = @ClienteID
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
                                    COALESCE((SELECT SUM(pv.MontoAplicado) FROM PagoVenta pv WHERE pv.VentaID = v.VentaID), 0) as NewPayments
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

                            // ---- 3. Aplicar el pago a las ventas pendientes (más antiguas primero) ----
                            decimal montoRestante = monto;

                            foreach (var venta in ventasPendientes)
                            {
                                if (montoRestante <= 0) break;

                                decimal saldoVenta = venta.Total - venta.OldPayments - venta.NewPayments;
                                if (saldoVenta <= 0) continue;

                                decimal montoAPagar = Math.Min(montoRestante, saldoVenta);

                                // Crear entrada en PagoVenta
                                string insertPV = @"
                                    INSERT INTO PagoVenta (PagoID, VentaID, MontoAplicado)
                                    VALUES (@PagoID, @VentaID, @MontoAplicado)";

                                using (var cmdPV = new SQLiteCommand(insertPV, connection, transaction))
                                {
                                    cmdPV.Parameters.AddWithValue("@PagoID", pagoID);
                                    cmdPV.Parameters.AddWithValue("@VentaID", venta.VentaID);
                                    cmdPV.Parameters.AddWithValue("@MontoAplicado", montoAPagar);
                                    cmdPV.ExecuteNonQuery();
                                }

                                // Asiento contable COBRO: Dr 101/102 / Cr 120 CxC
                                int usuarioID = SistemaPOS.Utils.SesionActual.Usuario?.UsuarioID ?? 0;
                                ContabilidadService.RegistrarCobroCxC(
                                    venta.VentaID, venta.NumeroVenta, montoAPagar,
                                    metodoPago, montoEfectivo, montoYape, montoTransferencia,
                                    monto,   // totalPago para cálculo proporcional en MIXTO
                                    fecha, usuarioID, connection, transaction);

                                // Si se pagó completamente, cambiar estado a COMPLETADA
                                if (montoAPagar >= saldoVenta)
                                {
                                    string updateEstado = "UPDATE Ventas SET Estado = 'COMPLETADA' WHERE VentaID = @VentaID";
                                    using (var cmdEstado = new SQLiteCommand(updateEstado, connection, transaction))
                                    {
                                        cmdEstado.Parameters.AddWithValue("@VentaID", venta.VentaID);
                                        cmdEstado.ExecuteNonQuery();
                                    }
                                }

                                montoRestante -= montoAPagar;
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

    }
}
