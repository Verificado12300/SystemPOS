using System;
using System.Data.SQLite;

namespace SistemaPOS.Data
{
    public class ConfiguracionRepository
    {
        public static ConfiguracionReportes ObtenerConfiguracion()
        {
            EnsureTableExists();

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM ConfiguracionReportes WHERE ID = 1";

                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ConfiguracionReportes
                        {
                            GenerarReportesAuto = reader.GetInt32(reader.GetOrdinal("GenerarReportesAuto")) == 1,
                            FrecuenciaReportes = reader.IsDBNull(reader.GetOrdinal("FrecuenciaReportes")) ? "DIARIO" : reader.GetString(reader.GetOrdinal("FrecuenciaReportes")),
                            DiaEnvioReportes = reader.GetInt32(reader.GetOrdinal("DiaEnvioReportes")),
                            HoraEnvioReportes = reader.IsDBNull(reader.GetOrdinal("HoraEnvioReportes")) ? (TimeSpan?)null : TimeSpan.Parse(reader.GetString(reader.GetOrdinal("HoraEnvioReportes"))),
                            ReporteVentas = reader.GetInt32(reader.GetOrdinal("ReporteVentas")) == 1,
                            ReporteInventario = reader.GetInt32(reader.GetOrdinal("ReporteInventario")) == 1,
                            ReporteStockBajo = reader.GetInt32(reader.GetOrdinal("ReporteStockBajo")) == 1,
                            ReporteCaja = reader.GetInt32(reader.GetOrdinal("ReporteCaja")) == 1,
                            ReporteCompras = reader.GetInt32(reader.GetOrdinal("ReporteCompras")) == 1,
                            ReporteCuentasCobrar = reader.GetInt32(reader.GetOrdinal("ReporteCuentasCobrar")) == 1,
                            EnviarPorCorreo = reader.GetInt32(reader.GetOrdinal("EnviarPorCorreo")) == 1,
                            DestinatariosCorreo = reader.IsDBNull(reader.GetOrdinal("DestinatariosCorreo")) ? "" : reader.GetString(reader.GetOrdinal("DestinatariosCorreo")),
                            AsuntoCorreo = reader.IsDBNull(reader.GetOrdinal("AsuntoCorreo")) ? "" : reader.GetString(reader.GetOrdinal("AsuntoCorreo")),
                            FormatoReporte = reader.IsDBNull(reader.GetOrdinal("FormatoReporte")) ? "PDF" : reader.GetString(reader.GetOrdinal("FormatoReporte")),
                            AlertaStockBajo = reader.GetInt32(reader.GetOrdinal("AlertaStockBajo")) == 1,
                            NotificarVentasMayores = reader.GetInt32(reader.GetOrdinal("NotificarVentasMayores")) == 1,
                            MontoVentasNotificar = reader.GetDecimal(reader.GetOrdinal("MontoVentasNotificar")),
                            AlertaProductosVencer = reader.GetInt32(reader.GetOrdinal("AlertaProductosVencer")) == 1,
                            NotificarCompras = reader.GetInt32(reader.GetOrdinal("NotificarCompras")) == 1
                        };
                    }
                }
            }

            return new ConfiguracionReportes();
        }

        public static void GuardarConfiguracion(ConfiguracionReportes config)
        {
            EnsureTableExists();

            using (var connection = DatabaseConnection.GetConnection())
            {
                // Verificar si existe registro
                string checkQuery = "SELECT COUNT(*) FROM ConfiguracionReportes WHERE ID = 1";
                bool exists;

                using (var checkCmd = new SQLiteCommand(checkQuery, connection))
                {
                    exists = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;
                }

                string query;
                if (exists)
                {
                    query = @"UPDATE ConfiguracionReportes SET
                        GenerarReportesAuto = @generarReportesAuto,
                        FrecuenciaReportes = @frecuenciaReportes,
                        DiaEnvioReportes = @diaEnvioReportes,
                        HoraEnvioReportes = @horaEnvioReportes,
                        ReporteVentas = @reporteVentas,
                        ReporteInventario = @reporteInventario,
                        ReporteStockBajo = @reporteStockBajo,
                        ReporteCaja = @reporteCaja,
                        ReporteCompras = @reporteCompras,
                        ReporteCuentasCobrar = @reporteCuentasCobrar,
                        EnviarPorCorreo = @enviarPorCorreo,
                        DestinatariosCorreo = @destinatariosCorreo,
                        AsuntoCorreo = @asuntoCorreo,
                        FormatoReporte = @formatoReporte,
                        AlertaStockBajo = @alertaStockBajo,
                        NotificarVentasMayores = @notificarVentasMayores,
                        MontoVentasNotificar = @montoVentasNotificar,
                        AlertaProductosVencer = @alertaProductosVencer,
                        NotificarCompras = @notificarCompras
                    WHERE ID = 1";
                }
                else
                {
                    query = @"INSERT INTO ConfiguracionReportes (
                        ID, GenerarReportesAuto, FrecuenciaReportes, DiaEnvioReportes, HoraEnvioReportes,
                        ReporteVentas, ReporteInventario, ReporteStockBajo, ReporteCaja, ReporteCompras,
                        ReporteCuentasCobrar, EnviarPorCorreo, DestinatariosCorreo, AsuntoCorreo, FormatoReporte,
                        AlertaStockBajo, NotificarVentasMayores, MontoVentasNotificar, AlertaProductosVencer, NotificarCompras
                    ) VALUES (
                        1, @generarReportesAuto, @frecuenciaReportes, @diaEnvioReportes, @horaEnvioReportes,
                        @reporteVentas, @reporteInventario, @reporteStockBajo, @reporteCaja, @reporteCompras,
                        @reporteCuentasCobrar, @enviarPorCorreo, @destinatariosCorreo, @asuntoCorreo, @formatoReporte,
                        @alertaStockBajo, @notificarVentasMayores, @montoVentasNotificar, @alertaProductosVencer, @notificarCompras
                    )";
                }

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@generarReportesAuto", config.GenerarReportesAuto ? 1 : 0);
                    cmd.Parameters.AddWithValue("@frecuenciaReportes", config.FrecuenciaReportes ?? "DIARIO");
                    cmd.Parameters.AddWithValue("@diaEnvioReportes", config.DiaEnvioReportes);
                    cmd.Parameters.AddWithValue("@horaEnvioReportes", config.HoraEnvioReportes?.ToString() ?? "08:00:00");
                    cmd.Parameters.AddWithValue("@reporteVentas", config.ReporteVentas ? 1 : 0);
                    cmd.Parameters.AddWithValue("@reporteInventario", config.ReporteInventario ? 1 : 0);
                    cmd.Parameters.AddWithValue("@reporteStockBajo", config.ReporteStockBajo ? 1 : 0);
                    cmd.Parameters.AddWithValue("@reporteCaja", config.ReporteCaja ? 1 : 0);
                    cmd.Parameters.AddWithValue("@reporteCompras", config.ReporteCompras ? 1 : 0);
                    cmd.Parameters.AddWithValue("@reporteCuentasCobrar", config.ReporteCuentasCobrar ? 1 : 0);
                    cmd.Parameters.AddWithValue("@enviarPorCorreo", config.EnviarPorCorreo ? 1 : 0);
                    cmd.Parameters.AddWithValue("@destinatariosCorreo", config.DestinatariosCorreo ?? "");
                    cmd.Parameters.AddWithValue("@asuntoCorreo", config.AsuntoCorreo ?? "");
                    cmd.Parameters.AddWithValue("@formatoReporte", config.FormatoReporte ?? "PDF");
                    cmd.Parameters.AddWithValue("@alertaStockBajo", config.AlertaStockBajo ? 1 : 0);
                    cmd.Parameters.AddWithValue("@notificarVentasMayores", config.NotificarVentasMayores ? 1 : 0);
                    cmd.Parameters.AddWithValue("@montoVentasNotificar", config.MontoVentasNotificar);
                    cmd.Parameters.AddWithValue("@alertaProductosVencer", config.AlertaProductosVencer ? 1 : 0);
                    cmd.Parameters.AddWithValue("@notificarCompras", config.NotificarCompras ? 1 : 0);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void EnsureTableExists()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS ConfiguracionReportes (
                        ID INTEGER PRIMARY KEY,
                        GenerarReportesAuto INTEGER DEFAULT 0,
                        FrecuenciaReportes TEXT DEFAULT 'DIARIO',
                        DiaEnvioReportes INTEGER DEFAULT 0,
                        HoraEnvioReportes TEXT DEFAULT '08:00:00',
                        ReporteVentas INTEGER DEFAULT 1,
                        ReporteInventario INTEGER DEFAULT 0,
                        ReporteStockBajo INTEGER DEFAULT 0,
                        ReporteCaja INTEGER DEFAULT 0,
                        ReporteCompras INTEGER DEFAULT 0,
                        ReporteCuentasCobrar INTEGER DEFAULT 0,
                        EnviarPorCorreo INTEGER DEFAULT 0,
                        DestinatariosCorreo TEXT,
                        AsuntoCorreo TEXT DEFAULT 'Reporte Automático - SystemPOS',
                        FormatoReporte TEXT DEFAULT 'PDF',
                        AlertaStockBajo INTEGER DEFAULT 0,
                        NotificarVentasMayores INTEGER DEFAULT 0,
                        MontoVentasNotificar REAL DEFAULT 500,
                        AlertaProductosVencer INTEGER DEFAULT 0,
                        NotificarCompras INTEGER DEFAULT 0
                    )";

                using (var cmd = new SQLiteCommand(createTableQuery, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

    public class ConfiguracionReportes
    {
        // Reportes automáticos
        public bool GenerarReportesAuto { get; set; }
        public string FrecuenciaReportes { get; set; } = "DIARIO";
        public int DiaEnvioReportes { get; set; }
        public TimeSpan? HoraEnvioReportes { get; set; } = new TimeSpan(8, 0, 0);

        // Reportes a generar
        public bool ReporteVentas { get; set; } = true;
        public bool ReporteInventario { get; set; }
        public bool ReporteStockBajo { get; set; }
        public bool ReporteCaja { get; set; }
        public bool ReporteCompras { get; set; }
        public bool ReporteCuentasCobrar { get; set; }

        // Notificaciones por correo
        public bool EnviarPorCorreo { get; set; }
        public string DestinatariosCorreo { get; set; }
        public string AsuntoCorreo { get; set; } = "Reporte Automático - SystemPOS";
        public string FormatoReporte { get; set; } = "PDF";

        // Alertas
        public bool AlertaStockBajo { get; set; }
        public bool NotificarVentasMayores { get; set; }
        public decimal MontoVentasNotificar { get; set; } = 500;
        public bool AlertaProductosVencer { get; set; }
        public bool NotificarCompras { get; set; }
    }
}
