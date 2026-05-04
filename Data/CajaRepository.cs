using SistemaPOS.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SistemaPOS.Data
{
    public class CajaRepository
    {
        private static bool _migracionCajasEjecutada = false;

        private static void EnsureCajasMigracion(SQLiteConnection connection)
        {
            if (_migracionCajasEjecutada) return;
            foreach (var col in new[] { "TotalCredito REAL DEFAULT 0", "TotalGastos REAL DEFAULT 0" })
            {
                try
                {
                    using (var cmd = new SQLiteCommand($"ALTER TABLE Cajas ADD COLUMN {col}", connection))
                        cmd.ExecuteNonQuery();
                }
                catch { /* columna ya existe */ }
            }
            _migracionCajasEjecutada = true;
        }

        public static Caja ObtenerCajaAbierta()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT CajaID, UsuarioID, Turno, FechaApertura, HoraApertura,
                           MontoInicial, Estado
                    FROM Cajas
                    WHERE Estado = 'ABIERTA'
                    ORDER BY CajaID DESC
                    LIMIT 1";

                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Caja
                        {
                            CajaID = reader.GetInt32(0),
                            UsuarioID = reader.GetInt32(1),
                            Turno = reader.GetString(2),
                            FechaApertura = DateTime.Parse(reader.GetString(3)),
                            HoraApertura = TimeSpan.Parse(reader.GetString(4)),
                            MontoInicial = reader.GetDecimal(5),
                            Estado = reader.GetString(6)
                        };
                    }
                }
            }
            return null;
        }

        public static Caja ObtenerPorID(int cajaID)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                EnsureCajasMigracion(connection);

                string query = @"
                    SELECT c.CajaID, c.UsuarioID, c.Turno, c.FechaApertura, c.HoraApertura,
                           c.FechaCierre, c.HoraCierre, c.MontoInicial, c.TotalVentas,
                           c.TotalEfectivo, c.TotalYape, c.TotalTarjeta, c.TotalTransferencia,
                           c.TotalCredito, c.EfectivoEsperado, c.EfectivoReal, c.Diferencia,
                           c.MotivoDiferencia, c.Estado, u.NombreCompleto,
                           COALESCE(c.TotalGastos, 0) as TotalGastos
                    FROM Cajas c
                    INNER JOIN Usuarios u ON c.UsuarioID = u.UsuarioID
                    WHERE c.CajaID = @id";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", cajaID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearCajaCompleta(reader);
                        }
                    }
                }
            }
            return null;
        }

        public static bool AbrirCaja(Caja caja)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = @"
                            INSERT INTO Cajas
                            (UsuarioID, Turno, FechaApertura, HoraApertura, MontoInicial, Estado)
                            SELECT
                            @UsuarioID, @Turno, @FechaApertura, @HoraApertura, @MontoInicial, 'ABIERTA'
                            WHERE NOT EXISTS (
                                SELECT 1 FROM Cajas WHERE Estado = 'ABIERTA'
                            )";

                        using (var cmd = new SQLiteCommand(query, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@UsuarioID", caja.UsuarioID);
                            cmd.Parameters.AddWithValue("@Turno", caja.Turno);
                            cmd.Parameters.AddWithValue("@FechaApertura", caja.FechaApertura.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@HoraApertura", caja.HoraApertura.ToString());
                            cmd.Parameters.AddWithValue("@MontoInicial", caja.MontoInicial);

                            bool ok = cmd.ExecuteNonQuery() > 0;
                            if (ok) transaction.Commit();
                            else transaction.Rollback();
                            return ok;
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Abre caja y, si esCapitalInicial=true, genera asiento Dr 101 / Cr 300
        /// en la misma transacción. Rollback total si falla el asiento.
        /// </summary>
        public static bool AbrirCaja(Caja caja, bool esCapitalInicial, int usuarioID)
        {
            using (var connection = DatabaseConnection.GetConnection())
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    const string query = @"
                        INSERT INTO Cajas
                        (UsuarioID, Turno, FechaApertura, HoraApertura, MontoInicial, Estado)
                        SELECT @UsuarioID, @Turno, @FechaApertura, @HoraApertura, @MontoInicial, 'ABIERTA'
                        WHERE NOT EXISTS (SELECT 1 FROM Cajas WHERE Estado = 'ABIERTA')";

                    bool ok;
                    using (var cmd = new SQLiteCommand(query, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@UsuarioID",     caja.UsuarioID);
                        cmd.Parameters.AddWithValue("@Turno",         caja.Turno);
                        cmd.Parameters.AddWithValue("@FechaApertura", caja.FechaApertura.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@HoraApertura",  caja.HoraApertura.ToString());
                        cmd.Parameters.AddWithValue("@MontoInicial",  caja.MontoInicial);
                        ok = cmd.ExecuteNonQuery() > 0;
                    }

                    if (!ok) { transaction.Rollback(); return false; }

                    int cajaID;
                    using (var cmd = new SQLiteCommand("SELECT last_insert_rowid()", connection, transaction))
                        cajaID = Convert.ToInt32(cmd.ExecuteScalar());

                    if (esCapitalInicial)
                        ContabilidadService.RegistrarCapitalInicial(
                            caja.FechaApertura, caja.HoraApertura,
                            caja.MontoInicial, usuarioID, cajaID,
                            connection, transaction);

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

        public static bool CerrarCaja(int cajaID, decimal efectivoReal, string motivoDiferencia)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string queryCaja = @"
                            SELECT CajaID, UsuarioID, Turno, FechaApertura, HoraApertura, MontoInicial, Estado
                            FROM Cajas
                            WHERE CajaID = @cajaID AND Estado = 'ABIERTA'
                            LIMIT 1";

                        Caja caja = null;
                        using (var cmdCaja = new SQLiteCommand(queryCaja, connection, transaction))
                        {
                            cmdCaja.Parameters.AddWithValue("@cajaID", cajaID);
                            using (var reader = cmdCaja.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    caja = new Caja
                                    {
                                        CajaID = reader.GetInt32(0),
                                        UsuarioID = reader.GetInt32(1),
                                        Turno = reader.GetString(2),
                                        FechaApertura = DateTime.Parse(reader.GetString(3)),
                                        HoraApertura = TimeSpan.Parse(reader.GetString(4)),
                                        MontoInicial = reader.GetDecimal(5),
                                        Estado = reader.GetString(6)
                                    };
                                }
                            }
                        }

                        if (caja == null)
                            return false;

                        var resumen = new ResumenCaja();

                        string queryVentas = @"
                            SELECT
                                COUNT(*) as Operaciones,
                                COALESCE(SUM(CASE WHEN Estado != 'CREDITO' THEN Total ELSE 0 END), 0) as TotalVentas,
                                COALESCE(SUM(MontoEfectivo), 0) as TotalEfectivo,
                                COALESCE(SUM(MontoYape), 0) as TotalYape,
                                COALESCE(SUM(MontoTarjeta), 0) as TotalTarjeta,
                                COALESCE(SUM(MontoTransferencia), 0) as TotalTransferencia,
                                COALESCE(SUM(CASE WHEN Estado = 'CREDITO' THEN Total ELSE 0 END), 0) as TotalCredito
                            FROM Ventas
                            WHERE CajaID = @cajaID
                              AND Estado != 'ANULADA'";

                        using (var cmd = new SQLiteCommand(queryVentas, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@cajaID", cajaID);
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    resumen.Operaciones = reader.GetInt32(0);
                                    resumen.TotalVentas = reader.GetDecimal(1);
                                    resumen.TotalEfectivo = reader.GetDecimal(2);
                                    resumen.TotalYape = reader.GetDecimal(3);
                                    resumen.TotalTarjeta = reader.GetDecimal(4);
                                    resumen.TotalTransferencia = reader.GetDecimal(5);
                                    resumen.TotalCredito = reader.GetDecimal(6);
                                }
                            }
                        }

                        string queryGastos = @"
                            SELECT COALESCE(SUM(Monto), 0)
                            FROM Gastos
                            WHERE CajaID = @cajaID
                              AND MetodoPago = 'EFECTIVO'";

                        using (var cmd = new SQLiteCommand(queryGastos, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@cajaID", cajaID);
                            var _r = cmd.ExecuteScalar();
                            resumen.TotalGastos = (_r != null && _r != DBNull.Value) ? Convert.ToDecimal(_r) : 0m;
                        }

                        decimal efectivoEsperado = caja.MontoInicial + resumen.TotalEfectivo - resumen.TotalGastos;
                        decimal diferencia = efectivoReal - efectivoEsperado;

                        // Migraciones de columnas
                        foreach (var col in new[] { "TotalCredito REAL DEFAULT 0", "TotalGastos REAL DEFAULT 0" })
                        {
                            try
                            {
                                using (var cmdAlter = new SQLiteCommand(
                                    $"ALTER TABLE Cajas ADD COLUMN {col}", connection, transaction))
                                {
                                    cmdAlter.ExecuteNonQuery();
                                }
                            }
                            catch { /* La columna ya existe */ }
                        }

                        string updateQuery = @"
                            UPDATE Cajas SET
                                FechaCierre = @fechaCierre,
                                HoraCierre = @horaCierre,
                                TotalVentas = @totalVentas,
                                TotalEfectivo = @totalEfectivo,
                                TotalYape = @totalYape,
                                TotalTarjeta = @totalTarjeta,
                                TotalTransferencia = @totalTransferencia,
                                TotalCredito = @totalCredito,
                                TotalGastos = @totalGastos,
                                EfectivoEsperado = @efectivoEsperado,
                                EfectivoReal = @efectivoReal,
                                Diferencia = @diferencia,
                                MotivoDiferencia = @motivoDiferencia,
                                Estado = 'CERRADA'
                            WHERE CajaID = @cajaID";

                        using (var cmd = new SQLiteCommand(updateQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@cajaID", cajaID);
                            cmd.Parameters.AddWithValue("@fechaCierre", DateTime.Now.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@horaCierre", DateTime.Now.TimeOfDay.ToString());
                            cmd.Parameters.AddWithValue("@totalVentas", resumen.TotalVentas);
                            cmd.Parameters.AddWithValue("@totalEfectivo", resumen.TotalEfectivo);
                            cmd.Parameters.AddWithValue("@totalYape", resumen.TotalYape);
                            cmd.Parameters.AddWithValue("@totalTarjeta", resumen.TotalTarjeta);
                            cmd.Parameters.AddWithValue("@totalTransferencia", resumen.TotalTransferencia);
                            cmd.Parameters.AddWithValue("@totalCredito", resumen.TotalCredito);
                            cmd.Parameters.AddWithValue("@totalGastos", resumen.TotalGastos);
                            cmd.Parameters.AddWithValue("@efectivoEsperado", efectivoEsperado);
                            cmd.Parameters.AddWithValue("@efectivoReal", efectivoReal);
                            cmd.Parameters.AddWithValue("@diferencia", diferencia);
                            cmd.Parameters.AddWithValue("@motivoDiferencia", motivoDiferencia ?? "");

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public static ResumenCaja ObtenerResumenVentas(int cajaID)
        {
            var resumen = new ResumenCaja();

            using (var connection = DatabaseConnection.GetConnection())
            {
                // Ventas del turno
                string queryVentas = @"
                    SELECT
                        COUNT(*) as Operaciones,
                        COALESCE(SUM(CASE WHEN Estado != 'CREDITO' THEN Total ELSE 0 END), 0) as TotalVentas,
                        COALESCE(SUM(MontoEfectivo), 0) as TotalEfectivo,
                        COALESCE(SUM(MontoYape), 0) as TotalYape,
                        COALESCE(SUM(MontoTarjeta), 0) as TotalTarjeta,
                        COALESCE(SUM(MontoTransferencia), 0) as TotalTransferencia,
                        COALESCE(SUM(CASE WHEN Estado = 'CREDITO' THEN Total ELSE 0 END), 0) as TotalCredito
                    FROM Ventas
                    WHERE CajaID = @cajaID
                      AND Estado != 'ANULADA'";

                using (var cmd = new SQLiteCommand(queryVentas, connection))
                {
                    cmd.Parameters.AddWithValue("@cajaID", cajaID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            resumen.Operaciones = reader.GetInt32(0);
                            resumen.TotalVentas = reader.GetDecimal(1);
                            resumen.TotalEfectivo = reader.GetDecimal(2);
                            resumen.TotalYape = reader.GetDecimal(3);
                            resumen.TotalTarjeta = reader.GetDecimal(4);
                            resumen.TotalTransferencia = reader.GetDecimal(5);
                            resumen.TotalCredito = reader.GetDecimal(6);
                        }
                    }
                }

                // Gastos en efectivo asociados a esta caja
                string queryGastos = @"
                    SELECT COALESCE(SUM(Monto), 0)
                    FROM Gastos
                    WHERE CajaID = @cajaID
                      AND MetodoPago = 'EFECTIVO'";

                using (var cmd = new SQLiteCommand(queryGastos, connection))
                {
                    cmd.Parameters.AddWithValue("@cajaID", cajaID);
                    var _r = cmd.ExecuteScalar();
                    resumen.TotalGastos = (_r != null && _r != DBNull.Value) ? Convert.ToDecimal(_r) : 0m;
                }

                // Ajustes por conversiones de método de pago
                string queryConv = @"
                    SELECT MetodoOrigen, MetodoDestino, COALESCE(SUM(Monto), 0)
                    FROM CajaConversiones WHERE CajaID = @cajaID
                    GROUP BY MetodoOrigen, MetodoDestino";

                using (var cmd = new SQLiteCommand(queryConv, connection))
                {
                    cmd.Parameters.AddWithValue("@cajaID", cajaID);
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            string orig  = r.GetString(0).ToUpper();
                            string dest  = r.GetString(1).ToUpper();
                            decimal mto  = r.GetDecimal(2);
                            AplicarAjusteConversion(resumen, orig,  -mto);
                            AplicarAjusteConversion(resumen, dest,  +mto);
                        }
                    }
                }
            }

            return resumen;
        }

        private static void AplicarAjusteConversion(ResumenCaja r, string metodo, decimal delta)
        {
            switch (metodo)
            {
                case "EFECTIVO":     r.ConversionEfectivo     += delta; break;
                case "YAPE":         r.ConversionYape         += delta; break;
                case "TARJETA":      r.ConversionTarjeta      += delta; break;
                case "TRANSFERENCIA":r.ConversionTransferencia += delta; break;
            }
        }

        public static List<CajaHistorial> Listar(DateTime? fechaDesde = null, DateTime? fechaHasta = null, int? usuarioID = null)
        {
            var lista = new List<CajaHistorial>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT c.CajaID, c.FechaApertura, c.HoraApertura, c.HoraCierre,
                           c.Turno, c.MontoInicial, c.TotalVentas, c.Estado,
                           u.NombreCompleto,
                           COALESCE(c.TotalEfectivo, 0), COALESCE(c.TotalYape, 0),
                           COALESCE(c.TotalTransferencia, 0), COALESCE(c.TotalCredito, 0),
                           COALESCE(c.TotalGastos, 0), COALESCE(c.EfectivoEsperado, 0),
                           COALESCE(c.EfectivoReal, 0), COALESCE(c.Diferencia, 0)
                    FROM Cajas c
                    INNER JOIN Usuarios u ON c.UsuarioID = u.UsuarioID
                    WHERE 1=1";

                if (fechaDesde.HasValue)
                    query += " AND c.FechaApertura >= @fechaDesde";
                if (fechaHasta.HasValue)
                    query += " AND c.FechaApertura <= @fechaHasta";
                if (usuarioID.HasValue)
                    query += " AND c.UsuarioID = @usuarioID";

                query += " ORDER BY c.FechaApertura DESC, c.HoraApertura DESC";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    if (fechaDesde.HasValue)
                        cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde.Value.ToString("yyyy-MM-dd"));
                    if (fechaHasta.HasValue)
                        cmd.Parameters.AddWithValue("@fechaHasta", fechaHasta.Value.ToString("yyyy-MM-dd"));
                    if (usuarioID.HasValue)
                        cmd.Parameters.AddWithValue("@usuarioID", usuarioID.Value);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new CajaHistorial
                            {
                                CajaID = reader.GetInt32(0),
                                FechaApertura = DateTime.Parse(reader.GetString(1)),
                                HoraApertura = TimeSpan.Parse(reader.GetString(2)),
                                HoraCierre = reader.IsDBNull(3) ? (TimeSpan?)null : TimeSpan.Parse(reader.GetString(3)),
                                Turno = reader.GetString(4),
                                MontoInicial = reader.GetDecimal(5),
                                TotalVentas = reader.GetDecimal(6),
                                Estado = reader.GetString(7),
                                NombreUsuario = reader.GetString(8),
                                TotalEfectivo = reader.GetDecimal(9),
                                TotalYape = reader.GetDecimal(10),
                                TotalTransferencia = reader.GetDecimal(11),
                                TotalCredito = reader.GetDecimal(12),
                                TotalGastos = reader.GetDecimal(13),
                                EfectivoEsperado = reader.GetDecimal(14),
                                EfectivoReal = reader.GetDecimal(15),
                                Diferencia = reader.GetDecimal(16)
                            };
                            lista.Add(item);
                        }
                    }
                }
            }

            return lista;
        }

        public static List<Usuario> ObtenerUsuariosConCajas()
        {
            var usuarios = new List<Usuario>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT DISTINCT u.UsuarioID, u.NombreCompleto
                    FROM Usuarios u
                    INNER JOIN Cajas c ON u.UsuarioID = c.UsuarioID
                    ORDER BY u.NombreCompleto";

                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(new Usuario
                        {
                            UsuarioID = reader.GetInt32(0),
                            NombreCompleto = reader.GetString(1)
                        });
                    }
                }
            }

            return usuarios;
        }

        public static bool RegistrarConversion(int cajaID, string metodoOrigen, string metodoDestino, decimal monto, string observacion)
        {
            using (var conn = DatabaseConnection.GetConnection())
            using (var tx = conn.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SQLiteCommand(@"
                        INSERT INTO CajaConversiones (CajaID, FechaHora, MetodoOrigen, MetodoDestino, Monto, Observacion)
                        VALUES (@cajaID, @fechaHora, @origen, @destino, @monto, @obs)", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@cajaID", cajaID);
                        cmd.Parameters.AddWithValue("@fechaHora", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@origen", metodoOrigen);
                        cmd.Parameters.AddWithValue("@destino", metodoDestino);
                        cmd.Parameters.AddWithValue("@monto", monto);
                        cmd.Parameters.AddWithValue("@obs", observacion ?? "");
                        cmd.ExecuteNonQuery();
                    }
                    tx.Commit();
                    return true;
                }
                catch { tx.Rollback(); throw; }
            }
        }

        public static List<CajaConversion> ObtenerConversiones(int cajaID)
        {
            var lista = new List<CajaConversion>();
            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new SQLiteCommand(@"
                SELECT ConversionID, CajaID, FechaHora, MetodoOrigen, MetodoDestino, Monto, Observacion
                FROM CajaConversiones WHERE CajaID = @cajaID ORDER BY FechaHora", conn))
            {
                cmd.Parameters.AddWithValue("@cajaID", cajaID);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new CajaConversion
                        {
                            ConversionID  = r.GetInt32(0),
                            CajaID        = r.GetInt32(1),
                            FechaHora     = DateTime.Parse(r.GetString(2)),
                            MetodoOrigen  = r.GetString(3),
                            MetodoDestino = r.GetString(4),
                            Monto         = r.GetDecimal(5),
                            Observacion   = r.IsDBNull(6) ? "" : r.GetString(6)
                        });
                    }
                }
            }
            return lista;
        }

        public static void RegistrarMoneteo(int cajaID, List<CajaMoneteoDetalle> detalles)
        {
            using (var conn = DatabaseConnection.GetConnection())
            using (var tx = conn.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SQLiteCommand("DELETE FROM CajaMoneteo WHERE CajaID = @cajaID", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@cajaID", cajaID);
                        cmd.ExecuteNonQuery();
                    }
                    foreach (var d in detalles)
                    {
                        using (var cmd = new SQLiteCommand(@"
                            INSERT INTO CajaMoneteo (CajaID, Denominacion, Cantidad, Subtotal)
                            VALUES (@cajaID, @den, @cant, @sub)", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@cajaID", cajaID);
                            cmd.Parameters.AddWithValue("@den", d.Denominacion);
                            cmd.Parameters.AddWithValue("@cant", d.Cantidad);
                            cmd.Parameters.AddWithValue("@sub", d.Subtotal);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch { tx.Rollback(); throw; }
            }
        }

        public static List<CajaMoneteoDetalle> ObtenerMoneteo(int cajaID)
        {
            var lista = new List<CajaMoneteoDetalle>();
            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new SQLiteCommand(@"
                SELECT Denominacion, Cantidad, Subtotal FROM CajaMoneteo
                WHERE CajaID = @cajaID ORDER BY Denominacion DESC", conn))
            {
                cmd.Parameters.AddWithValue("@cajaID", cajaID);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        lista.Add(new CajaMoneteoDetalle
                        {
                            Denominacion = r.GetDecimal(0),
                            Cantidad     = r.GetInt32(1),
                            Subtotal     = r.GetDecimal(2)
                        });
                }
            }
            return lista;
        }

        public static List<VentaTurno> ObtenerVentasDelTurno(int cajaID)
        {
            var lista = new List<VentaTurno>();
            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new SQLiteCommand(@"
                SELECT
                    SUBSTR(v.Hora, 1, 5) AS Hora,
                    v.NumeroVenta,
                    COALESCE(TRIM(COALESCE(c.Nombres,'') || ' ' || COALESCE(c.Apellidos,'')), c.RazonSocial, 'GENERAL') AS Cliente,
                    CASE
                        WHEN v.Estado = 'CREDITO' THEN 'CRÉDITO'
                        WHEN (v.MontoEfectivo > 0) + (v.MontoYape > 0) + (v.MontoTarjeta > 0) + (v.MontoTransferencia > 0) > 1 THEN 'MIXTO'
                        WHEN v.MontoYape > 0 THEN 'YAPE'
                        WHEN v.MontoTarjeta > 0 THEN 'TARJETA'
                        WHEN v.MontoTransferencia > 0 THEN 'TRANSF.'
                        ELSE 'EFECTIVO'
                    END AS Metodo,
                    v.Total
                FROM Ventas v
                LEFT JOIN Clientes c ON v.ClienteID = c.ClienteID
                WHERE v.CajaID = @cajaID AND v.Estado != 'ANULADA'
                  AND COALESCE(v.Eliminado, 0) = 0
                ORDER BY v.Fecha, v.Hora", conn))
            {
                cmd.Parameters.AddWithValue("@cajaID", cajaID);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        lista.Add(new VentaTurno
                        {
                            Hora         = r.GetString(0),
                            NumeroVenta  = r.GetString(1),
                            NombreCliente = r.GetString(2),
                            Metodo       = r.GetString(3),
                            Total        = r.GetDecimal(4)
                        });
                }
            }
            return lista;
        }

        public static List<GastoTurno> ObtenerGastosDelTurno(int cajaID)
        {
            var lista = new List<GastoTurno>();
            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new SQLiteCommand(@"
                SELECT SUBSTR(g.Hora, 1, 5), g.Concepto, g.Categoria, g.Monto
                FROM Gastos g
                WHERE g.CajaID = @cajaID
                  AND COALESCE(g.Eliminado, 0) = 0
                  AND COALESCE(g.Anulado, 0) = 0
                ORDER BY g.Fecha, g.Hora", conn))
            {
                cmd.Parameters.AddWithValue("@cajaID", cajaID);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        lista.Add(new GastoTurno
                        {
                            Hora      = r.GetString(0),
                            Concepto  = r.GetString(1),
                            Categoria = r.GetString(2),
                            Monto     = r.GetDecimal(3)
                        });
                }
            }
            return lista;
        }

        private static Caja MapearCajaCompleta(SQLiteDataReader reader)
        {
            return new Caja
            {
                CajaID = reader.GetInt32(0),
                UsuarioID = reader.GetInt32(1),
                Turno = reader.GetString(2),
                FechaApertura = DateTime.Parse(reader.GetString(3)),
                HoraApertura = TimeSpan.Parse(reader.GetString(4)),
                FechaCierre = reader.IsDBNull(5) ? (DateTime?)null : DateTime.Parse(reader.GetString(5)),
                HoraCierre = reader.IsDBNull(6) ? (TimeSpan?)null : TimeSpan.Parse(reader.GetString(6)),
                MontoInicial = reader.GetDecimal(7),
                TotalVentas = reader.GetDecimal(8),
                TotalEfectivo = reader.GetDecimal(9),
                TotalYape = reader.GetDecimal(10),
                TotalTarjeta = reader.GetDecimal(11),
                TotalTransferencia = reader.GetDecimal(12),
                TotalCredito = reader.GetDecimal(13),
                EfectivoEsperado = reader.GetDecimal(14),
                EfectivoReal = reader.GetDecimal(15),
                Diferencia = reader.GetDecimal(16),
                MotivoDiferencia = reader.IsDBNull(17) ? "" : reader.GetString(17),
                Estado = reader.GetString(18),
                TotalGastos = reader.FieldCount > 20 && !reader.IsDBNull(20) ? reader.GetDecimal(20) : 0m
            };
        }
    }

    // Clases auxiliares
    public class ResumenCaja
    {
        public int Operaciones { get; set; }
        public decimal TotalVentas { get; set; }
        public decimal TotalEfectivo { get; set; }
        public decimal TotalYape { get; set; }
        public decimal TotalTarjeta { get; set; }
        public decimal TotalTransferencia { get; set; }
        public decimal TotalCredito { get; set; }
        public decimal TotalGastos { get; set; }

        // Ajustes netos por conversiones (positivo = entradas, negativo = salidas)
        public decimal ConversionEfectivo      { get; set; }
        public decimal ConversionYape          { get; set; }
        public decimal ConversionTarjeta       { get; set; }
        public decimal ConversionTransferencia { get; set; }

        // Totales ajustados para mostrar en pantalla
        public decimal TotalEfectivoAjustado      => TotalEfectivo + ConversionEfectivo;
        public decimal TotalYapeAjustado          => TotalYape + ConversionYape;
        public decimal TotalTarjetaAjustado       => TotalTarjeta + ConversionTarjeta;
        public decimal TotalTransferenciaAjustado => TotalTransferencia + ConversionTransferencia;
    }

    public class CajaHistorial
    {
        public int CajaID { get; set; }
        public DateTime FechaApertura { get; set; }
        public TimeSpan HoraApertura { get; set; }
        public TimeSpan? HoraCierre { get; set; }
        public string Turno { get; set; }
        public decimal MontoInicial { get; set; }
        public decimal TotalVentas { get; set; }
        public string Estado { get; set; }
        public string NombreUsuario { get; set; }
        public decimal TotalEfectivo { get; set; }
        public decimal TotalYape { get; set; }
        public decimal TotalTransferencia { get; set; }
        public decimal TotalCredito { get; set; }
        public decimal TotalGastos { get; set; }
        public decimal EfectivoEsperado { get; set; }
        public decimal EfectivoReal { get; set; }
        public decimal Diferencia { get; set; }

        public string Duracion
        {
            get
            {
                if (!HoraCierre.HasValue) return "En curso";
                var diff = HoraCierre.Value - HoraApertura;
                return $"{(int)diff.TotalHours}h {diff.Minutes}m";
            }
        }
    }

    public class CajaConversion
    {
        public int ConversionID { get; set; }
        public int CajaID { get; set; }
        public DateTime FechaHora { get; set; }
        public string MetodoOrigen { get; set; }
        public string MetodoDestino { get; set; }
        public decimal Monto { get; set; }
        public string Observacion { get; set; }
    }

    public class CajaMoneteoDetalle
    {
        public decimal Denominacion { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }

    public class VentaTurno
    {
        public string Hora { get; set; }
        public string NumeroVenta { get; set; }
        public string NombreCliente { get; set; }
        public string Metodo { get; set; }
        public decimal Total { get; set; }
    }

    public class GastoTurno
    {
        public string Hora { get; set; }
        public string Concepto { get; set; }
        public string Categoria { get; set; }
        public decimal Monto { get; set; }
    }
}
