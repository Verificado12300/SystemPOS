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
                {
                    int diasDesdeInicio = (int)DateTime.Now.DayOfWeek;
                    if (diasDesdeInicio == 0) diasDesdeInicio = 7;
                    DateTime lunes = DateTime.Now.AddDays(-(diasDesdeInicio - 1)).Date;
                    DateTime domingo = lunes.AddDays(6);

                    // Dom=0, Lun=1 ... Sáb=6 en DayOfWeek
                    string[] etiqDias = { "Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb" };
                    var ventasPorFecha = new Dictionary<string, decimal>();

                    using (var conn = DatabaseConnection.GetConnection())
                    using (var cmd = new SQLiteCommand(
                        "SELECT Fecha, COALESCE(SUM(Total),0) FROM Ventas " +
                        "WHERE Fecha >= @I AND Fecha <= @F AND Estado != 'ANULADA' GROUP BY Fecha", conn))
                    {
                        cmd.Parameters.AddWithValue("@I", lunes.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@F", domingo.ToString("yyyy-MM-dd"));
                        using (var r = cmd.ExecuteReader())
                            while (r.Read())
                                ventasPorFecha[r[0]?.ToString() ?? ""] =
                                    r[1] != DBNull.Value ? Convert.ToDecimal(r[1]) : 0;
                    }

                    var resultado = new List<(string, decimal)>();
                    for (int i = 0; i < 7; i++)
                    {
                        DateTime dia = lunes.AddDays(i);
                        string etiqueta = etiqDias[(int)dia.DayOfWeek];
                        decimal valor = ventasPorFecha.TryGetValue(dia.ToString("yyyy-MM-dd"), out var v) ? v : 0;
                        resultado.Add((etiqueta, valor));
                    }
                    return resultado;
                }

                case "mes":
                {
                    DateTime primer = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    int diasMes = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                    DateTime ultimo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, diasMes);

                    // Semana 1 = días 1-7 | Semana 2 = 8-14 | Semana 3 = 15-21 | Semana 4 = 22-31
                    var ventasPorSem = new Dictionary<int, decimal>();

                    using (var conn = DatabaseConnection.GetConnection())
                    using (var cmd = new SQLiteCommand(@"
                        SELECT CASE
                            WHEN CAST(SUBSTR(Fecha,9,2) AS INTEGER) BETWEEN 1  AND 7  THEN 0
                            WHEN CAST(SUBSTR(Fecha,9,2) AS INTEGER) BETWEEN 8  AND 14 THEN 1
                            WHEN CAST(SUBSTR(Fecha,9,2) AS INTEGER) BETWEEN 15 AND 21 THEN 2
                            ELSE 3
                        END as NumSem,
                        COALESCE(SUM(Total),0) as Total
                        FROM Ventas
                        WHERE Fecha >= @I AND Fecha <= @F AND Estado != 'ANULADA'
                        GROUP BY NumSem ORDER BY NumSem", conn))
                    {
                        cmd.Parameters.AddWithValue("@I", primer.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@F", ultimo.ToString("yyyy-MM-dd"));
                        using (var r = cmd.ExecuteReader())
                            while (r.Read())
                                ventasPorSem[Convert.ToInt32(r[0])] =
                                    r[1] != DBNull.Value ? Convert.ToDecimal(r[1]) : 0;
                    }

                    var resultadoMes = new List<(string, decimal)>();
                    string[] etiqSem = { "Sem 1", "Sem 2", "Sem 3", "Sem 4" };
                    for (int i = 0; i < 4; i++)
                    {
                        decimal valor = ventasPorSem.TryGetValue(i, out var v) ? v : 0;
                        resultadoMes.Add((etiqSem[i], valor));
                    }
                    return resultadoMes;
                }

                default: // "dia" — desde la primera venta, mínimo 5 horas, crece hasta la última
                {
                    var ventasPorHora = new SortedDictionary<int, decimal>();

                    using (var conn = DatabaseConnection.GetConnection())
                    using (var cmd = new SQLiteCommand(@"
                        SELECT CAST(SUBSTR(Hora,1,2) AS INTEGER) as HoraNum,
                               COALESCE(SUM(Total),0) as Total
                        FROM Ventas
                        WHERE Fecha = @Hoy AND Estado != 'ANULADA'
                        GROUP BY HoraNum ORDER BY HoraNum", conn))
                    {
                        cmd.Parameters.AddWithValue("@Hoy", DateTime.Now.ToString("yyyy-MM-dd"));
                        using (var r = cmd.ExecuteReader())
                            while (r.Read())
                                ventasPorHora[Convert.ToInt32(r[0])] =
                                    r[1] != DBNull.Value ? Convert.ToDecimal(r[1]) : 0;
                    }

                    // Sin ventas → estado vacío con horas de referencia
                    if (ventasPorHora.Count == 0)
                        return new List<(string, decimal)>();

                    // Determinar rango: desde primera venta, al menos 5 horas, hasta la última venta
                    int horaMin = -1, horaUltima = -1;
                    foreach (var k in ventasPorHora.Keys)
                    {
                        if (horaMin < 0) horaMin = k;
                        horaUltima = k;
                    }
                    int horaMax = Math.Min(Math.Max(horaUltima, horaMin + 4), 23);

                    // Emitir todas las horas del rango (0 en horas sin ventas = sin marcador)
                    var resultadoDia = new List<(string, decimal)>();
                    for (int h = horaMin; h <= horaMax; h++)
                    {
                        decimal valor = ventasPorHora.TryGetValue(h, out var v) ? v : 0;
                        resultadoDia.Add(($"{h}h", valor));
                    }
                    return resultadoDia;
                }
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

        public static (decimal Ventas, decimal CostoVentas, decimal Gastos, decimal Utilidad) ObtenerUtilidadReal(string periodo)
        {
            ObtenerRangoFechas(periodo, out string inicio, out string fin);
            var dto = ContabilidadService.ObtenerEstadoResultados(
                DateTime.ParseExact(inicio, "yyyy-MM-dd", null),
                DateTime.ParseExact(fin,    "yyyy-MM-dd", null));
            return (dto.Ventas, dto.CostoVentas, dto.Gastos, dto.UtilidadOperativa);
        }

        public static (decimal Total, int Cantidad) ObtenerCxPPendiente()
        {
            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new SQLiteCommand(
                "SELECT COALESCE(SUM(MontoPendiente),0), COUNT(*) FROM CuentasPorPagar " +
                "WHERE Estado IN ('PENDIENTE','PARCIAL')", conn))
            using (var r = cmd.ExecuteReader())
            {
                if (r.Read())
                    return (Convert.ToDecimal(r[0]), Convert.ToInt32(r[1]));
                return (0, 0);
            }
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
