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
                // Ventas brutas
                er.VentasBrutas = ObtenerDecimal(connection,
                    "SELECT COALESCE(SUM(Total), 0) FROM Ventas WHERE Fecha >= @FD AND Fecha <= @FH AND Estado != 'ANULADA'", fd, fh);

                // Devoluciones (ventas anuladas)
                er.DevolucionesVentas = ObtenerDecimal(connection,
                    "SELECT COALESCE(SUM(Total), 0) FROM Ventas WHERE FechaAnulacion >= @FD AND FechaAnulacion <= @FH AND Estado = 'ANULADA'", fd, fh);

                er.VentasNetas = er.VentasBrutas - er.DevolucionesVentas;

                // Costo de mercadería vendida (basado en costo de productos vendidos)
                er.CostoMercaderia = ObtenerDecimal(connection, @"
                    SELECT COALESCE(SUM(vd.Cantidad * pp.CostoBase), 0)
                    FROM VentaDetalles vd
                    INNER JOIN Ventas v ON vd.VentaID = v.VentaID
                    INNER JOIN ProductoPresentaciones pp ON vd.ProductoPresentacionID = pp.ProductoPresentacionID
                    WHERE v.Fecha >= @FD AND v.Fecha <= @FH AND v.Estado != 'ANULADA'", fd, fh);

                er.UtilidadBruta = er.VentasNetas - er.CostoMercaderia;

                // Gastos operativos por categoría
                // Servicios = LUZ + AGUA + INTERNET + TELEFONO
                er.GastosServicios = ObtenerDecimal(connection,
                    "SELECT COALESCE(SUM(Monto), 0) FROM Gastos WHERE Fecha >= @FD AND Fecha <= @FH AND Categoria IN ('LUZ','AGUA','INTERNET','TELEFONO')", fd, fh);

                er.GastosAlquiler = ObtenerDecimal(connection,
                    "SELECT COALESCE(SUM(Monto), 0) FROM Gastos WHERE Fecha >= @FD AND Fecha <= @FH AND Categoria = 'ALQUILER'", fd, fh);

                er.GastosSueldos = ObtenerDecimal(connection,
                    "SELECT COALESCE(SUM(Monto), 0) FROM Gastos WHERE Fecha >= @FD AND Fecha <= @FH AND Categoria = 'SUELDOS'", fd, fh);

                er.GastosOtros = ObtenerDecimal(connection,
                    "SELECT COALESCE(SUM(Monto), 0) FROM Gastos WHERE Fecha >= @FD AND Fecha <= @FH AND Categoria NOT IN ('LUZ','AGUA','INTERNET','TELEFONO','ALQUILER','SUELDOS')", fd, fh);

                // Llenar gastos por categoría
                string queryGastos = "SELECT Categoria, COALESCE(SUM(Monto), 0) as Total FROM Gastos WHERE Fecha >= @FD AND Fecha <= @FH GROUP BY Categoria";
                using (var cmd = new SQLiteCommand(queryGastos, connection))
                {
                    cmd.Parameters.AddWithValue("@FD", fd);
                    cmd.Parameters.AddWithValue("@FH", fh);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string categoria = reader.GetString(0);
                            decimal monto = reader.GetDecimal(1);
                            er.GastosPorCategoria[categoria] = monto;
                        }
                    }
                }

                er.TotalGastos = er.GastosServicios + er.GastosAlquiler + er.GastosSueldos + er.GastosOtros;
                er.GastosOperativos = er.TotalGastos;
                er.UtilidadOperativa = er.UtilidadBruta - er.GastosOperativos;

                // Otros ingresos (cobros de créditos) - solo informativo, no se suma
                // porque VentasBrutas ya incluye las ventas a crédito
                er.OtrosIngresos = ObtenerDecimal(connection,
                    "SELECT COALESCE(SUM(Monto), 0) FROM Pagos WHERE FechaPago >= @FD AND FechaPago <= @FH", fd, fh);

                er.UtilidadNeta = er.UtilidadOperativa;
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
