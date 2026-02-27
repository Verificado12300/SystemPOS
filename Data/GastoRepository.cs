using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SistemaPOS.Models;

namespace SistemaPOS.Data
{
    public class GastoRepository
    {
        public static bool Crear(Gasto gasto)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = @"
                            INSERT INTO Gastos (Fecha, Hora, Concepto, Monto, Categoria, MetodoPago, Comprobante, Observaciones, CajaID, UsuarioID, TipoIGV, BaseImponible)
                            VALUES (@Fecha, @Hora, @Concepto, @Monto, @Categoria, @MetodoPago, @Comprobante, @Observaciones, @CajaID, @UsuarioID, @TipoIGV, @BaseImponible)";

                        using (var cmd = new SQLiteCommand(query, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Fecha", gasto.Fecha.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@Hora", $"{gasto.Hora.Hours:D2}:{gasto.Hora.Minutes:D2}:{gasto.Hora.Seconds:D2}");
                            cmd.Parameters.AddWithValue("@Concepto", gasto.Concepto);
                            cmd.Parameters.AddWithValue("@Monto", gasto.Monto);
                            cmd.Parameters.AddWithValue("@Categoria", gasto.Categoria);
                            cmd.Parameters.AddWithValue("@MetodoPago", gasto.MetodoPago);
                            cmd.Parameters.AddWithValue("@Comprobante", (object)gasto.Comprobante ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Observaciones", (object)gasto.Observaciones ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@CajaID", gasto.CajaID.HasValue ? (object)gasto.CajaID.Value : DBNull.Value);
                            cmd.Parameters.AddWithValue("@UsuarioID", gasto.UsuarioID);
                            cmd.Parameters.AddWithValue("@TipoIGV", gasto.TipoIGV);
                            cmd.Parameters.AddWithValue("@BaseImponible", gasto.BaseImponible);
                            cmd.ExecuteNonQuery();
                        }

                        long gastoID = connection.LastInsertRowId;

                        // Asiento contable: Dr 600=base + Dr 4012=igv (si aplica) / Cr 101/102/200=total
                        decimal igvGasto = gasto.Monto - gasto.BaseImponible;
                        ContabilidadService.RegistrarGasto(
                            gastoID, gasto.Concepto, gasto.Fecha, gasto.Hora,
                            gasto.Monto, igvGasto, gasto.MetodoPago, gasto.UsuarioID,
                            connection, transaction);

                        // Si es al crédito, crear Cuenta por Pagar
                        if (gasto.MetodoPago?.ToUpper() == "CREDITO")
                        {
                            CuentaPorPagarRepository.CrearDesdeGasto(gasto, gastoID,
                                connection, transaction);
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

        public static List<Gasto> Listar(DateTime? fechaDesde = null, DateTime? fechaHasta = null,
            string categoria = null, string busqueda = null, int limite = 500)
        {
            var gastos = new List<Gasto>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT GastoID, Fecha, Hora, Concepto, Monto, Categoria, MetodoPago,
                           Comprobante, Observaciones, CajaID, UsuarioID
                    FROM Gastos WHERE 1=1";

                if (fechaDesde.HasValue)
                    query += " AND Fecha >= @FechaDesde";
                if (fechaHasta.HasValue)
                    query += " AND Fecha <= @FechaHasta";
                if (!string.IsNullOrEmpty(categoria) && categoria != "TODAS")
                    query += " AND Categoria = @Categoria";
                if (!string.IsNullOrEmpty(busqueda))
                    query += " AND (Concepto LIKE @Busqueda OR Comprobante LIKE @Busqueda)";

                query += " ORDER BY Fecha DESC, Hora DESC LIMIT @Limite";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    if (fechaDesde.HasValue)
                        cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde.Value.ToString("yyyy-MM-dd"));
                    if (fechaHasta.HasValue)
                        cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta.Value.ToString("yyyy-MM-dd"));
                    if (!string.IsNullOrEmpty(categoria) && categoria != "TODAS")
                        cmd.Parameters.AddWithValue("@Categoria", categoria);
                    if (!string.IsNullOrEmpty(busqueda))
                        cmd.Parameters.AddWithValue("@Busqueda", $"%{busqueda}%");
                    cmd.Parameters.AddWithValue("@Limite", limite);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            gastos.Add(new Gasto
                            {
                                GastoID = reader.GetInt32(0),
                                Fecha = DateTime.Parse(reader.GetString(1)),
                                Hora = TimeSpan.Parse(reader.GetString(2)),
                                Concepto = reader.GetString(3),
                                Monto = reader.GetDecimal(4),
                                Categoria = reader.GetString(5),
                                MetodoPago = reader.GetString(6),
                                Comprobante = reader.IsDBNull(7) ? "" : reader.GetString(7),
                                Observaciones = reader.IsDBNull(8) ? "" : reader.GetString(8),
                                CajaID = reader.IsDBNull(9) ? (int?)null : reader.GetInt32(9),
                                UsuarioID = reader.GetInt32(10)
                            });
                        }
                    }
                }
            }

            return gastos;
        }

        public static bool Eliminar(int gastoID)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Verificar si hay CxP activa asociada a este gasto
                        int? cxpId = null;
                        using (var cmd = new SQLiteCommand(
                            "SELECT CuentaPorPagarID FROM CuentasPorPagar " +
                            "WHERE TipoOrigen='GASTO' AND IdOrigen=@GastoID AND Estado!='ANULADO' LIMIT 1",
                            connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@GastoID", gastoID);
                            var r = cmd.ExecuteScalar();
                            if (r != null && r != DBNull.Value)
                                cxpId = Convert.ToInt32(r);
                        }

                        if (cxpId.HasValue)
                        {
                            var info = CuentaPorPagarRepository.ObtenerInfoPagos(
                                cxpId.Value, connection, transaction);
                            if (info.Tiene)
                                throw new Exception(
                                    $"No se puede eliminar el gasto: tiene {info.Cantidad} pago(s) registrado(s) " +
                                    $"por S/ {info.Total:N2}. Revierte los pagos antes de anular.");

                            CuentaPorPagarRepository.MarcarAnulada(cxpId.Value, connection, transaction);
                        }

                        // Reversar el asiento ANTES de borrar el registro (necesita leer datos del gasto)
                        ContabilidadService.ReversarGasto(gastoID, connection, transaction);

                        string query = "DELETE FROM Gastos WHERE GastoID = @GastoID";
                        using (var cmd = new SQLiteCommand(query, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@GastoID", gastoID);
                            int filas = cmd.ExecuteNonQuery();
                            transaction.Commit();
                            return filas > 0;
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

        public static decimal ObtenerTotalPorPeriodo(DateTime fechaDesde, DateTime fechaHasta)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT COALESCE(SUM(Monto), 0) FROM Gastos WHERE Fecha >= @FechaDesde AND Fecha <= @FechaHasta";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta.ToString("yyyy-MM-dd"));
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
        }

        public static Dictionary<string, decimal> ObtenerTotalesPorCategoria(DateTime fechaDesde, DateTime fechaHasta)
        {
            var totales = new Dictionary<string, decimal>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT Categoria, SUM(Monto) as Total
                    FROM Gastos
                    WHERE Fecha >= @FechaDesde AND Fecha <= @FechaHasta
                    GROUP BY Categoria ORDER BY Total DESC";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta.ToString("yyyy-MM-dd"));

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            totales[reader.GetString(0)] = reader.GetDecimal(1);
                        }
                    }
                }
            }

            return totales;
        }

        public static string[] CategoriasDisponibles = new[]
        {
            "LUZ", "AGUA", "INTERNET", "TELEFONO",
            "ALQUILER", "SUELDOS", "TRANSPORTE", "MANTENIMIENTO",
            "LIMPIEZA", "SEGURIDAD", "PUBLICIDAD", "IMPUESTOS", "OTROS"
        };
    }
}
