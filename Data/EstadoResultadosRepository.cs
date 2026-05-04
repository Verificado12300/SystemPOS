using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SistemaPOS.Data
{
    public class EstadoResultados
    {
        public decimal VentasBrutas { get; set; }
        public decimal DevolucionesVentas { get; set; }
        public decimal VentasNetas { get; set; }
        public decimal CostoMercaderia { get; set; }
        public decimal UtilidadBruta { get; set; }
        public decimal GastosOperativos { get; set; }
        public decimal GastosServicios { get; set; }
        public decimal GastosAlquiler { get; set; }
        public decimal GastosSueldos { get; set; }
        public decimal GastosOtros { get; set; }
        public decimal TotalGastos { get; set; }
        public Dictionary<string, decimal> GastosPorCategoria { get; set; }
        public decimal UtilidadOperativa { get; set; }
        public decimal OtrosIngresos { get; set; }
        public decimal UtilidadNeta { get; set; }

        public EstadoResultados()
        {
            GastosPorCategoria = new Dictionary<string, decimal>();
        }
    }

    public class EstadoResultadosRepository
    {
        public static EstadoResultados Calcular(DateTime fechaDesde, DateTime fechaHasta)
        {
            var er = new EstadoResultados();
            string fd = fechaDesde.ToString("yyyy-MM-dd");
            string fh = fechaHasta.ToString("yyyy-MM-dd");

            using (var connection = DatabaseConnection.GetConnection())
            {
                // Ventas (400), COGS (500) y Gastos totales (600) desde asientos contables
                const string sqlAsientos = @"
                    SELECT
                        COALESCE(SUM(CASE WHEN cc.Codigo = '400' THEN ad.Haber - ad.Debe ELSE 0 END), 0),
                        COALESCE(SUM(CASE WHEN cc.Codigo = '500' THEN ad.Debe - ad.Haber ELSE 0 END), 0),
                        COALESCE(SUM(CASE WHEN cc.Codigo = '600' THEN ad.Debe - ad.Haber ELSE 0 END), 0)
                    FROM   AsientosDetalle ad
                    JOIN   CuentasContables cc ON ad.CuentaID  = cc.CuentaID
                    JOIN   Asientos a          ON ad.AsientoID = a.AsientoID
                    WHERE  a.Fecha >= @FD AND a.Fecha <= @FH";

                using (var cmd = new SQLiteCommand(sqlAsientos, connection))
                {
                    cmd.Parameters.AddWithValue("@FD", fd);
                    cmd.Parameters.AddWithValue("@FH", fh);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            er.VentasBrutas    = r.IsDBNull(0) ? 0m : r.GetDecimal(0);
                            er.CostoMercaderia = r.IsDBNull(1) ? 0m : r.GetDecimal(1);
                            er.TotalGastos     = r.IsDBNull(2) ? 0m : r.GetDecimal(2);
                        }
                    }
                }

                // Account 400 ya es neto (las anulaciones generan asientos inversos)
                er.VentasNetas       = er.VentasBrutas;
                er.UtilidadBruta     = er.VentasNetas - er.CostoMercaderia;
                er.GastosOperativos  = er.TotalGastos;
                er.UtilidadOperativa = er.UtilidadBruta - er.TotalGastos;
                er.UtilidadNeta      = er.UtilidadOperativa;

                // Desglose por categoría desde Gastos.BaseImponible (informativo)
                const string sqlCategorias = @"
                    SELECT Categoria, COALESCE(SUM(BaseImponible), 0)
                    FROM   Gastos
                    WHERE  Fecha >= @FD AND Fecha <= @FH
                      AND  (Eliminado IS NULL OR Eliminado = 0)
                    GROUP  BY Categoria";

                using (var cmd = new SQLiteCommand(sqlCategorias, connection))
                {
                    cmd.Parameters.AddWithValue("@FD", fd);
                    cmd.Parameters.AddWithValue("@FH", fh);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            er.GastosPorCategoria[reader.GetString(0)] = reader.GetDecimal(1);
                    }
                }

                // OtrosIngresos: cobros de créditos, solo informativo
                er.OtrosIngresos = ObtenerDecimal(connection,
                    "SELECT COALESCE(SUM(Monto), 0) FROM Pagos WHERE FechaPago >= @FD AND FechaPago <= @FH", fd, fh);
            }

            return er;
        }

        private static decimal ObtenerDecimal(SQLiteConnection connection, string query, string fd, string fh)
        {
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@FD", fd);
                cmd.Parameters.AddWithValue("@FH", fh);
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }
    }
}
