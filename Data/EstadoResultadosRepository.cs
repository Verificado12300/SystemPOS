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
                // Verificar si existen asientos en el rango
                long countAsientos = 0;
                try
                {
                    using (var cmd = new SQLiteCommand(
                        "SELECT COUNT(*) FROM Asientos WHERE Fecha >= @FD AND Fecha <= @FH", connection))
                    {
                        cmd.Parameters.AddWithValue("@FD", fd);
                        cmd.Parameters.AddWithValue("@FH", fh);
                        countAsientos = (long)cmd.ExecuteScalar();
                    }
                }
                catch { }

                if (countAsientos > 0)
                {
                    // ===== CALCULAR DESDE ASIENTOS (partida doble) =====
                    var saldoQuery = @"
                        SELECT cc.Codigo,
                               COALESCE(SUM(ad.Debe), 0) as TotalDebe,
                               COALESCE(SUM(ad.Haber), 0) as TotalHaber
                        FROM CuentasContables cc
                        LEFT JOIN AsientosDetalle ad ON ad.CuentaID = cc.CuentaID
                        LEFT JOIN Asientos a ON a.AsientoID = ad.AsientoID
                            AND a.Fecha >= @FD AND a.Fecha <= @FH
                        WHERE cc.Activa = 1
                        GROUP BY cc.Codigo";

                    var saldos = new Dictionary<string, (decimal Debe, decimal Haber)>();
                    using (var cmd = new SQLiteCommand(saldoQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@FD", fd);
                        cmd.Parameters.AddWithValue("@FH", fh);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                saldos[reader.GetString(0)] = (reader.GetDecimal(1), reader.GetDecimal(2));
                        }
                    }

                    decimal SaldoHaber(string codigo)
                    {
                        if (!saldos.TryGetValue(codigo, out var t)) return 0;
                        return t.Haber - t.Debe; // INGRESO: saldo natural Haber
                    }
                    decimal SaldoDebe(string codigo)
                    {
                        if (!saldos.TryGetValue(codigo, out var t)) return 0;
                        return t.Debe - t.Haber; // GASTO: saldo natural Debe
                    }

                    er.VentasBrutas = SaldoHaber("401");
                    er.DevolucionesVentas = 0; // Las anulaciones ya se contabilizan como asientos ANULACION
                    er.VentasNetas = er.VentasBrutas;
                    er.CostoMercaderia = SaldoDebe("501");
                    er.UtilidadBruta = er.VentasNetas - er.CostoMercaderia;
                    er.GastosOperativos = SaldoDebe("502");
                    er.TotalGastos = er.GastosOperativos;
                    er.UtilidadOperativa = er.UtilidadBruta - er.TotalGastos;
                    er.UtilidadNeta = er.UtilidadOperativa;

                    // GastosPorCategoria desde tabla Gastos para mantener compatibilidad con report
                    string queryGastos = "SELECT Categoria, COALESCE(SUM(Monto), 0) as Total FROM Gastos WHERE Fecha >= @FD AND Fecha <= @FH GROUP BY Categoria";
                    using (var cmd = new SQLiteCommand(queryGastos, connection))
                    {
                        cmd.Parameters.AddWithValue("@FD", fd);
                        cmd.Parameters.AddWithValue("@FH", fh);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                er.GastosPorCategoria[reader.GetString(0)] = reader.GetDecimal(1);
                        }
                    }
                }
                else
                {
                    // ===== CALCULAR LEGADO (sin asientos) =====
                    er.VentasBrutas = ObtenerDecimal(connection,
                        "SELECT COALESCE(SUM(Total), 0) FROM Ventas WHERE Fecha >= @FD AND Fecha <= @FH AND Estado != 'ANULADA'", fd, fh);

                    er.DevolucionesVentas = ObtenerDecimal(connection,
                        "SELECT COALESCE(SUM(Total), 0) FROM Ventas WHERE FechaAnulacion >= @FD AND FechaAnulacion <= @FH AND Estado = 'ANULADA'", fd, fh);

                    er.VentasNetas = er.VentasBrutas - er.DevolucionesVentas;

                    er.CostoMercaderia = ObtenerDecimal(connection, @"
                        SELECT COALESCE(SUM(vd.Cantidad * pp.CostoBase), 0)
                        FROM VentaDetalles vd
                        INNER JOIN Ventas v ON vd.VentaID = v.VentaID
                        INNER JOIN ProductoPresentaciones pp ON vd.ProductoPresentacionID = pp.ProductoPresentacionID
                        WHERE v.Fecha >= @FD AND v.Fecha <= @FH AND v.Estado != 'ANULADA'", fd, fh);

                    er.UtilidadBruta = er.VentasNetas - er.CostoMercaderia;

                    er.GastosServicios = ObtenerDecimal(connection,
                        "SELECT COALESCE(SUM(Monto), 0) FROM Gastos WHERE Fecha >= @FD AND Fecha <= @FH AND Categoria IN ('LUZ','AGUA','INTERNET','TELEFONO')", fd, fh);
                    er.GastosAlquiler = ObtenerDecimal(connection,
                        "SELECT COALESCE(SUM(Monto), 0) FROM Gastos WHERE Fecha >= @FD AND Fecha <= @FH AND Categoria = 'ALQUILER'", fd, fh);
                    er.GastosSueldos = ObtenerDecimal(connection,
                        "SELECT COALESCE(SUM(Monto), 0) FROM Gastos WHERE Fecha >= @FD AND Fecha <= @FH AND Categoria = 'SUELDOS'", fd, fh);
                    er.GastosOtros = ObtenerDecimal(connection,
                        "SELECT COALESCE(SUM(Monto), 0) FROM Gastos WHERE Fecha >= @FD AND Fecha <= @FH AND Categoria NOT IN ('LUZ','AGUA','INTERNET','TELEFONO','ALQUILER','SUELDOS')", fd, fh);

                    string queryGastos = "SELECT Categoria, COALESCE(SUM(Monto), 0) as Total FROM Gastos WHERE Fecha >= @FD AND Fecha <= @FH GROUP BY Categoria";
                    using (var cmd = new SQLiteCommand(queryGastos, connection))
                    {
                        cmd.Parameters.AddWithValue("@FD", fd);
                        cmd.Parameters.AddWithValue("@FH", fh);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                er.GastosPorCategoria[reader.GetString(0)] = reader.GetDecimal(1);
                        }
                    }

                    er.TotalGastos = er.GastosServicios + er.GastosAlquiler + er.GastosSueldos + er.GastosOtros;
                    er.GastosOperativos = er.TotalGastos;
                    er.UtilidadOperativa = er.UtilidadBruta - er.GastosOperativos;
                    er.OtrosIngresos = ObtenerDecimal(connection,
                        "SELECT COALESCE(SUM(Monto), 0) FROM Pagos WHERE FechaPago >= @FD AND FechaPago <= @FH", fd, fh);
                    er.UtilidadNeta = er.UtilidadOperativa;
                }
            }

            return er;
        }

        private static decimal ObtenerDecimal(SQLiteConnection connection, string query, string fd, string fh)
        {
            try
            {
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FD", fd);
                    cmd.Parameters.AddWithValue("@FH", fh);
                    var result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}
