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
                // ACTIVOS

                // Efectivo: EfectivoReal de la última caja o MontoInicial + TotalEfectivo si no está cerrada
                bg.Efectivo = ObtenerDecimal(connection, @"
                    SELECT COALESCE(
                        (SELECT COALESCE(EfectivoReal, MontoInicial + TotalEfectivo)
                         FROM Cajas ORDER BY CajaID DESC LIMIT 1),
                        0)");

                // Cuentas por cobrar (créditos de ventas pendientes)
                bg.CuentasPorCobrar = ObtenerDecimal(connection,
                    "SELECT COALESCE(SUM(Saldo), 0) FROM CreditosVentas WHERE Estado = 'PENDIENTE'");

                // Inventario (stock * costo base)
                bg.Inventario = ObtenerDecimal(connection, @"
                    SELECT COALESCE(SUM(p.StockTotal * COALESCE(
                        (SELECT pp.CostoBase FROM ProductoPresentaciones pp
                         WHERE pp.ProductoID = p.ProductoID AND pp.Activo = 1
                         ORDER BY pp.CantidadUnidades ASC LIMIT 1), 0
                    )), 0) FROM Productos p WHERE p.Activo = 1");

                bg.TotalActivos = bg.Efectivo + bg.CuentasPorCobrar + bg.Inventario;

                // PASIVOS

                // Cuentas por pagar (deudas con proveedores)
                bg.CuentasPorPagar = ObtenerDecimal(connection,
                    "SELECT COALESCE(SUM(MontoPendiente), 0) FROM CuentasPorPagar WHERE Estado != 'PAGADO'");

                bg.TotalPasivos = bg.CuentasPorPagar;

                // PATRIMONIO
                // Utilidad acumulada: Total ventas - Total costo mercadería - Total gastos
                decimal totalVentas = ObtenerDecimal(connection,
                    "SELECT COALESCE(SUM(Total), 0) FROM Ventas WHERE Estado != 'ANULADA'");

                decimal totalCostoMercaderia = ObtenerDecimal(connection, @"
                    SELECT COALESCE(SUM(vd.Cantidad * pp.CostoBase), 0)
                    FROM VentaDetalles vd
                    INNER JOIN Ventas v ON vd.VentaID = v.VentaID
                    INNER JOIN ProductoPresentaciones pp ON vd.ProductoPresentacionID = pp.ProductoPresentacionID
                    WHERE v.Estado != 'ANULADA'");

                decimal totalGastos = ObtenerDecimal(connection,
                    "SELECT COALESCE(SUM(Monto), 0) FROM Gastos");

                bg.UtilidadAcumulada = totalVentas - totalCostoMercaderia - totalGastos;

                // Capital = Total Patrimonio - Utilidad Acumulada (lo que se invirtió inicialmente)
                bg.Capital = (bg.TotalActivos - bg.TotalPasivos) - bg.UtilidadAcumulada;
                bg.TotalPatrimonio = bg.Capital + bg.UtilidadAcumulada;
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
