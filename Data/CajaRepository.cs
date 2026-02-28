using SistemaPOS.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SistemaPOS.Data
{
    public class CajaRepository
    {
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
                // Migraciones de columnas
                foreach (var col in new[] { "TotalCredito REAL DEFAULT 0", "TotalGastos REAL DEFAULT 0" })
                {
                    try
                    {
                        using (var cmdAlter = new SQLiteCommand(
                            $"ALTER TABLE Cajas ADD COLUMN {col}", connection))
                        {
                            cmdAlter.ExecuteNonQuery();
                        }
                    }
                    catch { /* La columna ya existe */ }
                }

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
            }

            return resumen;
        }

        public static List<CajaHistorial> Listar(DateTime? fechaDesde = null, DateTime? fechaHasta = null, int? usuarioID = null)
        {
            var lista = new List<CajaHistorial>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT c.CajaID, c.FechaApertura, c.HoraApertura, c.HoraCierre,
                           c.Turno, c.MontoInicial, c.TotalVentas, c.Estado,
                           u.NombreCompleto
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
                                NombreUsuario = reader.GetString(8)
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
}
