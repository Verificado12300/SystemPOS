using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SistemaPOS.Data
{
    public class DashboardRepository
    {
        private static void ObtenerRangoFechas(string periodo, out string fechaInicio, out string fechaFin)
        {
            fechaFin = DateTime.Now.ToString("yyyy-MM-dd");

            switch (periodo)
            {
                case "semana":
                    int diasDesdeInicio = (int)DateTime.Now.DayOfWeek;
                    if (diasDesdeInicio == 0) diasDesdeInicio = 7;
                    fechaInicio = DateTime.Now.AddDays(-(diasDesdeInicio - 1)).ToString("yyyy-MM-dd");
                    break;
                case "mes":
                    fechaInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd");
                    break;
                default: // "dia"
                    fechaInicio = DateTime.Now.ToString("yyyy-MM-dd");
                    break;
            }
        }

        public static (decimal Total, int Cantidad) ObtenerVentasPorPeriodo(string periodo)
        {
            ObtenerRangoFechas(periodo, out string inicio, out string fin);
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT COALESCE(SUM(Total), 0), COUNT(*)
                                 FROM Ventas
                                 WHERE Fecha >= @Inicio AND Fecha <= @Fin
                                 AND Estado != 'ANULADA'";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Inicio", inicio);
                    cmd.Parameters.AddWithValue("@Fin", fin);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return (Convert.ToDecimal(reader[0]), Convert.ToInt32(reader[1]));
                        return (0, 0);
                    }
                }
            }
        }

        public static decimal ObtenerUtilidadEstimada(string periodo)
        {
            ObtenerRangoFechas(periodo, out string inicio, out string fin);
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT COALESCE(SUM(vd.Subtotal) - SUM(pp.CostoBase * vd.Cantidad), 0)
                    FROM VentaDetalles vd
                    INNER JOIN Ventas v ON vd.VentaID = v.VentaID
                    INNER JOIN ProductoPresentaciones pp ON vd.ProductoPresentacionID = pp.ProductoPresentacionID
                    WHERE v.Fecha >= @Inicio AND v.Fecha <= @Fin
                    AND v.Estado != 'ANULADA'";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Inicio", inicio);
                    cmd.Parameters.AddWithValue("@Fin", fin);
                    var result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        public static decimal ObtenerMargenPorcentaje(string periodo)
        {
            ObtenerRangoFechas(periodo, out string inicio, out string fin);
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT COALESCE(SUM(vd.Subtotal), 0),
                           COALESCE(SUM(pp.CostoBase * vd.Cantidad), 0)
                    FROM VentaDetalles vd
                    INNER JOIN Ventas v ON vd.VentaID = v.VentaID
                    INNER JOIN ProductoPresentaciones pp ON vd.ProductoPresentacionID = pp.ProductoPresentacionID
                    WHERE v.Fecha >= @Inicio AND v.Fecha <= @Fin
                    AND v.Estado != 'ANULADA'";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Inicio", inicio);
                    cmd.Parameters.AddWithValue("@Fin", fin);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal totalVenta = Convert.ToDecimal(reader[0]);
                            if (totalVenta == 0) return 0;
                            decimal totalCosto = Convert.ToDecimal(reader[1]);
                            return ((totalVenta - totalCosto) / totalVenta) * 100;
                        }
                        return 0;
                    }
                }
            }
        }

        public static int ObtenerProductosBajoStock()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Productos WHERE Activo = 1 AND StockTotal <= StockMinimo";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static List<(string Producto, decimal Total, int Cantidad)> ObtenerProductosMasVendidos(string periodo, int top = 5)
        {
            var productos = new List<(string, decimal, int)>();
            ObtenerRangoFechas(periodo, out string inicio, out string fin);

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT p.Nombre,
                           COALESCE(SUM(vd.Subtotal), 0) as Total,
                           CAST(COALESCE(SUM(vd.Cantidad), 0) AS INTEGER) as Cantidad
                    FROM VentaDetalles vd
                    INNER JOIN Productos p ON vd.ProductoID = p.ProductoID
                    INNER JOIN Ventas v ON vd.VentaID = v.VentaID
                    WHERE v.Fecha >= @Inicio AND v.Fecha <= @Fin
                    AND v.Estado != 'ANULADA'
                    GROUP BY vd.ProductoID, p.Nombre
                    ORDER BY Total DESC
                    LIMIT @Top";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Inicio", inicio);
                    cmd.Parameters.AddWithValue("@Fin", fin);
                    cmd.Parameters.AddWithValue("@Top", top);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombre = reader[0]?.ToString() ?? "Sin nombre";
                            decimal total = reader[1] != DBNull.Value ? Convert.ToDecimal(reader[1]) : 0;
                            int cantidad = reader[2] != DBNull.Value ? Convert.ToInt32(reader[2]) : 0;
                            productos.Add((nombre, total, cantidad));
                        }
                    }
                }
            }

            return productos;
        }

        public static List<(string Etiqueta, decimal Total)> ObtenerTendenciaVentas(string periodo)
        {
            switch (periodo)
            {
                case "semana":
                    // 7 dias de la semana (Lun a Dom)
                    int diasDesdeInicio = (int)DateTime.Now.DayOfWeek;
                    if (diasDesdeInicio == 0) diasDesdeInicio = 7;
                    DateTime lunesSemana = DateTime.Now.AddDays(-(diasDesdeInicio - 1)).Date;

                    string[] nombresDia = { "Dom", "Lun", "Mar", "Mie", "Jue", "Vie", "Sab" };
                    var ventasPorFecha = new Dictionary<string, decimal>();

                    DateTime domingoSemana = lunesSemana.AddDays(6);
                    using (var connection = DatabaseConnection.GetConnection())
                    {
                        string query = @"SELECT Fecha, COALESCE(SUM(Total), 0) as Total
                                         FROM Ventas
                                         WHERE Fecha >= @Inicio AND Fecha <= @Fin AND Estado != 'ANULADA'
                                         GROUP BY Fecha";
                        using (var cmd = new SQLiteCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Inicio", lunesSemana.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@Fin", domingoSemana.ToString("yyyy-MM-dd"));
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string fecha = reader[0]?.ToString() ?? "";
                                    decimal total = reader[1] != DBNull.Value ? Convert.ToDecimal(reader[1]) : 0;
                                    ventasPorFecha[fecha] = total;
                                }
                            }
                        }
                    }

                    var resultado = new List<(string, decimal)>();
                    for (int i = 0; i < 7; i++)
                    {
                        DateTime dia = lunesSemana.AddDays(i);
                        string fechaKey = dia.ToString("yyyy-MM-dd");
                        string etiqueta = nombresDia[(int)dia.DayOfWeek] + " " + dia.ToString("dd");
                        decimal valor = ventasPorFecha.ContainsKey(fechaKey) ? ventasPorFecha[fechaKey] : 0;
                        resultado.Add((etiqueta, valor));
                    }
                    return resultado;

                case "mes":
                    DateTime primerDiaMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    int diasEnMes = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                    int totalSemanas = (int)Math.Ceiling(diasEnMes / 7.0);

                    var ventasPorSemana = new Dictionary<int, decimal>();

                    DateTime ultimoDiaMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, diasEnMes);
                    using (var connection = DatabaseConnection.GetConnection())
                    {
                        string query = @"SELECT CAST((julianday(Fecha) - julianday(@Inicio)) / 7 AS INTEGER) as NumSemana,
                                                COALESCE(SUM(Total), 0) as Total
                                         FROM Ventas
                                         WHERE Fecha >= @Inicio AND Fecha <= @Fin AND Estado != 'ANULADA'
                                         GROUP BY NumSemana";
                        using (var cmd = new SQLiteCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Inicio", primerDiaMes.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@Fin", ultimoDiaMes.ToString("yyyy-MM-dd"));
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int numSem = Convert.ToInt32(reader[0]);
                                    decimal total = reader[1] != DBNull.Value ? Convert.ToDecimal(reader[1]) : 0;
                                    ventasPorSemana[numSem] = total;
                                }
                            }
                        }
                    }

                    var resultadoMes = new List<(string, decimal)>();
                    for (int i = 0; i < totalSemanas; i++)
                    {
                        // Calcular rango de fechas de la semana
                        int diaInicio = i * 7 + 1;
                        int diaFin = Math.Min((i + 1) * 7, diasEnMes);
                        string etiqueta = $"{diaInicio:D2}-{diaFin:D2}";
                        decimal valor = ventasPorSemana.ContainsKey(i) ? ventasPorSemana[i] : 0;
                        resultadoMes.Add((etiqueta, valor));
                    }
                    return resultadoMes;

                default: // "dia"
                    string[] bloques = { "00-06", "06-10", "10-14", "14-18", "18-22", "22-24" };
                    var ventasPorBloque = new Dictionary<string, decimal>();

                    using (var connection = DatabaseConnection.GetConnection())
                    {
                        string hoy = DateTime.Now.ToString("yyyy-MM-dd");
                        string query = @"SELECT
                                            CASE
                                                WHEN CAST(SUBSTR(Hora, 1, 2) AS INTEGER) < 6 THEN '00-06'
                                                WHEN CAST(SUBSTR(Hora, 1, 2) AS INTEGER) < 10 THEN '06-10'
                                                WHEN CAST(SUBSTR(Hora, 1, 2) AS INTEGER) < 14 THEN '10-14'
                                                WHEN CAST(SUBSTR(Hora, 1, 2) AS INTEGER) < 18 THEN '14-18'
                                                WHEN CAST(SUBSTR(Hora, 1, 2) AS INTEGER) < 22 THEN '18-22'
                                                ELSE '22-24'
                                            END as Bloque,
                                            COALESCE(SUM(Total), 0) as Total
                                         FROM Ventas
                                         WHERE Fecha = @Inicio AND Estado != 'ANULADA'
                                         GROUP BY Bloque";
                        using (var cmd = new SQLiteCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Inicio", hoy);
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string bloque = reader[0]?.ToString() ?? "";
                                    decimal total = reader[1] != DBNull.Value ? Convert.ToDecimal(reader[1]) : 0;
                                    ventasPorBloque[bloque] = total;
                                }
                            }
                        }
                    }

                    var resultadoDia = new List<(string, decimal)>();
                    foreach (var bloque in bloques)
                    {
                        decimal valor = ventasPorBloque.ContainsKey(bloque) ? ventasPorBloque[bloque] : 0;
                        resultadoDia.Add((bloque, valor));
                    }
                    return resultadoDia;
            }
        }

        public static List<(string NumeroVenta, string Cliente, string MetodoPago, decimal Monto, string FechaHora)> ObtenerOperacionesRecientes(int limite = 20)
        {
            var operaciones = new List<(string, string, string, decimal, string)>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT v.NumeroVenta,
                           COALESCE(
                               CASE
                                   WHEN c.RazonSocial IS NOT NULL AND c.RazonSocial != '' THEN c.RazonSocial
                                   WHEN c.Nombres IS NOT NULL THEN RTRIM(COALESCE(c.Nombres, '') || ' ' || COALESCE(c.Apellidos, ''))
                                   ELSE 'Cliente General'
                               END,
                               'Cliente General'
                           ) as Cliente,
                           v.MetodoPago, v.Total,
                           v.Fecha || ' ' || v.Hora as FechaHora
                    FROM Ventas v
                    LEFT JOIN Clientes c ON v.ClienteID = c.ClienteID
                    WHERE v.Estado != 'ANULADA'
                    ORDER BY v.VentaID DESC
                    LIMIT @Limite";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Limite", limite);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string numero = reader[0]?.ToString() ?? "";
                            string cliente = reader[1]?.ToString() ?? "Cliente General";
                            string metodo = reader[2]?.ToString() ?? "";
                            decimal monto = reader[3] != DBNull.Value ? Convert.ToDecimal(reader[3]) : 0;
                            string fechaHora = reader[4]?.ToString() ?? "";
                            operaciones.Add((numero, cliente, metodo, monto, fechaHora));
                        }
                    }
                }
            }

            return operaciones;
        }

        /// <summary>
        /// Calcula Ventas (Ventas.Total), Costo de Ventas (cuenta 500 de asientos)
        /// y Gastos Operativos (Gastos.Monto) del período, y deriva la Utilidad Neta.
        /// </summary>
        public static (decimal Ventas, decimal CostoVentas, decimal Gastos, decimal Utilidad) ObtenerUtilidadReal(string periodo)
        {
            ObtenerRangoFechas(periodo, out string inicio, out string fin);
            decimal ventas = 0, costoVentas = 0, gastos = 0;

            using (var conn = DatabaseConnection.GetConnection())
            {
                // 1. Ventas totales del período (monto real cobrado, incluye IGV si aplica)
                using (var cmd = new SQLiteCommand(
                    "SELECT COALESCE(SUM(Total), 0) FROM Ventas " +
                    "WHERE Fecha >= @Inicio AND Fecha <= @Fin AND Estado != 'ANULADA'", conn))
                {
                    cmd.Parameters.AddWithValue("@Inicio", inicio);
                    cmd.Parameters.AddWithValue("@Fin", fin);
                    var r = cmd.ExecuteScalar();
                    ventas = r != null && r != DBNull.Value ? Convert.ToDecimal(r) : 0;
                }

                // 2. Costo de ventas: movimientos Debe de cuenta 500 en asientos del período
                using (var cmd = new SQLiteCommand(@"
                    SELECT COALESCE(SUM(ad.Debe - ad.Haber), 0)
                    FROM AsientosDetalle ad
                    JOIN CuentasContables cc ON ad.CuentaID = cc.CuentaID
                    JOIN Asientos a ON ad.AsientoID = a.AsientoID
                    WHERE cc.Codigo = '500'
                      AND a.Fecha >= @Inicio AND a.Fecha <= @Fin", conn))
                {
                    cmd.Parameters.AddWithValue("@Inicio", inicio);
                    cmd.Parameters.AddWithValue("@Fin", fin);
                    var r = cmd.ExecuteScalar();
                    costoVentas = r != null && r != DBNull.Value ? Convert.ToDecimal(r) : 0;
                }

                // 3. Gastos operativos del período (monto real, directo de tabla Gastos)
                using (var cmd = new SQLiteCommand(
                    "SELECT COALESCE(SUM(Monto), 0) FROM Gastos " +
                    "WHERE Fecha >= @Inicio AND Fecha <= @Fin AND (Eliminado IS NULL OR Eliminado = 0)", conn))
                {
                    cmd.Parameters.AddWithValue("@Inicio", inicio);
                    cmd.Parameters.AddWithValue("@Fin", fin);
                    var r = cmd.ExecuteScalar();
                    gastos = r != null && r != DBNull.Value ? Convert.ToDecimal(r) : 0;
                }
            }

            return (ventas, costoVentas, gastos, ventas - costoVentas - gastos);
        }

        public static string ObtenerEstadoCaja()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT Estado FROM Cajas ORDER BY CajaID DESC LIMIT 1";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    var result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "SIN CAJA";
                }
            }
        }
    }
}
