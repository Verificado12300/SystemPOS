using System;
using System.Data.SQLite;

namespace SistemaPOS.Data
{
    public class BalanceGeneral
    {
        // ACTIVOS
        public decimal Efectivo { get; set; }
        public decimal CuentasPorCobrar { get; set; }
        public decimal Inventario { get; set; }
        public decimal TotalActivos { get; set; }

        // PASIVOS
        public decimal CuentasPorPagar { get; set; }
        public decimal TotalPasivos { get; set; }

        // PATRIMONIO
        public decimal Capital { get; set; }
        public decimal UtilidadAcumulada { get; set; }
        public decimal TotalPatrimonio { get; set; }
    }

    public class BalanceRepository
    {
        public static BalanceGeneral Calcular(DateTime fechaCorte)
        {
            var bg = new BalanceGeneral();
            string fc = fechaCorte.ToString("yyyy-MM-dd");

            using (var connection = DatabaseConnection.GetConnection())
            {
                // Verificar si existen asientos contables (partida doble habilitada)
                long countAsientos = 0;
                try
                {
                    using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Asientos WHERE Fecha <= @FC", connection))
                    {
                        cmd.Parameters.AddWithValue("@FC", fc);
                        countAsientos = (long)cmd.ExecuteScalar();
                    }
                }
                catch { }

                if (countAsientos > 0)
                {
                    // ===== CALCULAR DESDE ASIENTOS (partida doble) =====
                    // Balance acumulativo hasta fechaCorte
                    var saldoQuery = @"
                        SELECT cc.Codigo,
                               COALESCE(SUM(ad.Debe), 0) as TotalDebe,
                               COALESCE(SUM(ad.Haber), 0) as TotalHaber
                        FROM CuentasContables cc
                        LEFT JOIN AsientosDetalle ad ON ad.CuentaID = cc.CuentaID
                        LEFT JOIN Asientos a ON a.AsientoID = ad.AsientoID AND a.Fecha <= @FC
                        WHERE cc.Activa = 1
                        GROUP BY cc.Codigo";

                    var saldos = new System.Collections.Generic.Dictionary<string, (decimal Debe, decimal Haber)>();
                    using (var cmd = new SQLiteCommand(saldoQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@FC", fc);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                saldos[reader.GetString(0)] = (reader.GetDecimal(1), reader.GetDecimal(2));
                        }
                    }

                    decimal Saldo(string codigo)
                    {
                        if (!saldos.TryGetValue(codigo, out var t)) return 0;
                        return t.Debe - t.Haber; // saldo natural activo (Debe - Haber)
                    }

                    decimal SaldoPasivo(string codigo)
                    {
                        if (!saldos.TryGetValue(codigo, out var t)) return 0;
                        return t.Haber - t.Debe; // saldo natural pasivo (Haber - Debe)
                    }

                    bg.Efectivo = Saldo("101") + Saldo("102");
                    bg.CuentasPorCobrar = Saldo("103");
                    bg.Inventario = Saldo("201");
                    bg.TotalActivos = bg.Efectivo + bg.CuentasPorCobrar + bg.Inventario;

                    bg.CuentasPorPagar = SaldoPasivo("601");
                    bg.TotalPasivos = bg.CuentasPorPagar;

                    bg.Capital = SaldoPasivo("701");

                    // Utilidad = Ingresos - Gastos
                    decimal ingresos = SaldoPasivo("401"); // INGRESO: saldo natural Haber
                    decimal costoVentas = Saldo("501");    // GASTO: saldo natural Debe
                    decimal gastoOper = Saldo("502");      // GASTO: saldo natural Debe
                    bg.UtilidadAcumulada = ingresos - costoVentas - gastoOper;

                    bg.TotalPatrimonio = bg.Capital + bg.UtilidadAcumulada;
                }
                else
                {
                    // ===== CALCULAR LEGADO (sin asientos contables) =====
                    bg.Efectivo = ObtenerDecimal(connection, @"
                        SELECT COALESCE(
                            (SELECT COALESCE(EfectivoReal, MontoInicial + TotalEfectivo)
                             FROM Cajas ORDER BY CajaID DESC LIMIT 1),
                            0)");

                    bg.CuentasPorCobrar = ObtenerDecimal(connection,
                        "SELECT COALESCE(SUM(Saldo), 0) FROM CreditosVentas WHERE Estado = 'PENDIENTE'");

                    bg.Inventario = ObtenerDecimal(connection, @"
                        SELECT COALESCE(SUM(p.StockTotal * COALESCE(
                            (SELECT pp.CostoBase FROM ProductoPresentaciones pp
                             WHERE pp.ProductoID = p.ProductoID AND pp.Activo = 1
                             ORDER BY pp.CantidadUnidades ASC LIMIT 1), 0
                        )), 0) FROM Productos p WHERE p.Activo = 1");

                    bg.TotalActivos = bg.Efectivo + bg.CuentasPorCobrar + bg.Inventario;

                    bg.CuentasPorPagar = ObtenerDecimal(connection,
                        "SELECT COALESCE(SUM(MontoPendiente), 0) FROM CuentasPorPagar WHERE Estado != 'PAGADO'");
                    bg.TotalPasivos = bg.CuentasPorPagar;

                    decimal totalVentas = ObtenerDecimal(connection,
                        "SELECT COALESCE(SUM(Total), 0) FROM Ventas WHERE Estado != 'ANULADA'");
                    decimal totalCosto = ObtenerDecimal(connection, @"
                        SELECT COALESCE(SUM(vd.Cantidad * pp.CostoBase), 0)
                        FROM VentaDetalles vd
                        INNER JOIN Ventas v ON vd.VentaID = v.VentaID
                        INNER JOIN ProductoPresentaciones pp ON vd.ProductoPresentacionID = pp.ProductoPresentacionID
                        WHERE v.Estado != 'ANULADA'");
                    decimal totalGastos = ObtenerDecimal(connection,
                        "SELECT COALESCE(SUM(Monto), 0) FROM Gastos");

                    bg.UtilidadAcumulada = totalVentas - totalCosto - totalGastos;
                    bg.Capital = (bg.TotalActivos - bg.TotalPasivos) - bg.UtilidadAcumulada;
                    bg.TotalPatrimonio = bg.Capital + bg.UtilidadAcumulada;
                }
            }

            return bg;
        }

        private static decimal ObtenerDecimal(SQLiteConnection connection, string query)
        {
            try
            {
                using (var cmd = new SQLiteCommand(query, connection))
                {
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
