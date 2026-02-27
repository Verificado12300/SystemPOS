using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SistemaPOS.Models;

namespace SistemaPOS.Data
{
    /// <summary>
    /// Repositorio de períodos contables.
    ///
    /// GUARD (llamar dentro de tx activa del negocio):
    ///   EstaCerrado / ValidarFechaNoBloqueada
    ///
    /// ADMINISTRACIÓN (abren su propia conexión):
    ///   CerrarMes / ReabrirMes / ObtenerTodos
    /// </summary>
    public static class PeriodosContablesRepository
    {
        // =====================================================================
        // GUARD — se invocan dentro de conn+tx del negocio
        // =====================================================================

        /// <summary>
        /// Devuelve true si la fecha cae dentro de un período cerrado (Cerrado=1).
        /// </summary>
        public static bool EstaCerrado(DateTime fecha,
            SQLiteConnection conn, SQLiteTransaction tx = null)
        {
            const string sql = @"
                SELECT COUNT(*)
                FROM   PeriodosContables
                WHERE  Cerrado = 1
                  AND  @Fecha BETWEEN FechaInicio AND FechaFin";

            using (var cmd = tx != null
                ? new SQLiteCommand(sql, conn, tx)
                : new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Fecha", fecha.ToString("yyyy-MM-dd"));
                return (long)cmd.ExecuteScalar() > 0;
            }
        }

        /// <summary>
        /// Lanza InvalidOperationException si la fecha cae en un período cerrado.
        /// Usar como guard antes de insertar/revertir asientos contables.
        /// El llamador debe atrapar la excepción y hacer rollback.
        /// </summary>
        public static void ValidarFechaNoBloqueada(DateTime fecha,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            if (EstaCerrado(fecha, conn, tx))
                throw new InvalidOperationException(
                    $"[PERIODO CERRADO] No se puede registrar ni anular operaciones " +
                    $"con fecha {fecha:dd/MM/yyyy}. El período contable está cerrado.\n" +
                    "Para realizar cambios, primero reabra el período desde " +
                    "el módulo de Cierre de Período.");
        }

        // =====================================================================
        // ADMINISTRACIÓN — abren su propia conexión interna
        // =====================================================================

        /// <summary>
        /// Cierra el mes indicado.
        /// Upsert: si ya existe registro para ese mes, pone Cerrado=1;
        /// si no existe, inserta uno nuevo.
        /// </summary>
        public static void CerrarMes(int year, int month,
            string usuarioId, SQLiteConnection conn)
        {
            string inicio = new DateTime(year, month, 1).ToString("yyyy-MM-dd");
            string fin    = new DateTime(year, month,
                DateTime.DaysInMonth(year, month)).ToString("yyyy-MM-dd");
            string ahora  = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            using (var tx = conn.BeginTransaction())
            {
                try
                {
                    long count;
                    using (var cmd = new SQLiteCommand(
                        "SELECT COUNT(*) FROM PeriodosContables " +
                        "WHERE FechaInicio = @FI AND FechaFin = @FF",
                        conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@FI", inicio);
                        cmd.Parameters.AddWithValue("@FF", fin);
                        count = (long)cmd.ExecuteScalar();
                    }

                    if (count > 0)
                    {
                        // Actualizar registro existente
                        using (var cmd = new SQLiteCommand(@"
                            UPDATE PeriodosContables
                            SET    Cerrado = 1, CerradoEn = @En, CerradoPor = @Por
                            WHERE  FechaInicio = @FI AND FechaFin = @FF",
                            conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@FI",  inicio);
                            cmd.Parameters.AddWithValue("@FF",  fin);
                            cmd.Parameters.AddWithValue("@En",  ahora);
                            cmd.Parameters.AddWithValue("@Por", (object)usuarioId ?? DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Insertar período nuevo ya cerrado
                        using (var cmd = new SQLiteCommand(@"
                            INSERT INTO PeriodosContables
                                (FechaInicio, FechaFin, Cerrado, CerradoEn, CerradoPor)
                            VALUES (@FI, @FF, 1, @En, @Por)",
                            conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@FI",  inicio);
                            cmd.Parameters.AddWithValue("@FF",  fin);
                            cmd.Parameters.AddWithValue("@En",  ahora);
                            cmd.Parameters.AddWithValue("@Por", (object)usuarioId ?? DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Reabre el mes indicado (Cerrado → 0).
        /// Registra CerradoEn/CerradoPor con el momento de reapertura.
        /// Si no existe registro para ese mes, no hace nada.
        /// </summary>
        public static void ReabrirMes(int year, int month,
            string usuarioId, SQLiteConnection conn)
        {
            string inicio = new DateTime(year, month, 1).ToString("yyyy-MM-dd");
            string fin    = new DateTime(year, month,
                DateTime.DaysInMonth(year, month)).ToString("yyyy-MM-dd");
            string ahora  = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            using (var tx = conn.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SQLiteCommand(@"
                        UPDATE PeriodosContables
                        SET    Cerrado = 0, CerradoEn = @En, CerradoPor = @Por
                        WHERE  FechaInicio = @FI AND FechaFin = @FF",
                        conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@FI",  inicio);
                        cmd.Parameters.AddWithValue("@FF",  fin);
                        cmd.Parameters.AddWithValue("@En",  ahora);
                        cmd.Parameters.AddWithValue("@Por", (object)usuarioId ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Lista todos los períodos, más recientes primero.
        /// </summary>
        public static List<PeriodoContable> ObtenerTodos()
        {
            var lista = new List<PeriodoContable>();

            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new SQLiteCommand(
                "SELECT PeriodoId, FechaInicio, FechaFin, Cerrado, CerradoEn, CerradoPor " +
                "FROM   PeriodosContables ORDER BY FechaInicio DESC",
                conn))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    lista.Add(new PeriodoContable
                    {
                        PeriodoId   = r.GetInt32(0),
                        FechaInicio = r.GetString(1),
                        FechaFin    = r.GetString(2),
                        Cerrado     = r.GetInt32(3) == 1,
                        CerradoEn   = r.IsDBNull(4) ? null : r.GetString(4),
                        CerradoPor  = r.IsDBNull(5) ? null : r.GetString(5)
                    });
                }
            }

            return lista;
        }
    }
}
