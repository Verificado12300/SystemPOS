using System;

namespace SistemaPOS.Models
{
    public class BalanceGeneralDTO
    {
        // ACTIVOS (saldo = Debe - Haber, cuentas 101/102/120/140)
        public decimal Caja       { get; set; }
        public decimal Bancos     { get; set; }
        public decimal CxC        { get; set; }
        public decimal Inventario { get; set; }
        public decimal TotalActivos => Caja + Bancos + CxC + Inventario;

        // PASIVOS (saldo = Haber - Debe, cuenta 200)
        public decimal CxP          { get; set; }
        public decimal TotalPasivos => CxP;

        // PATRIMONIO (cuenta 300 + utilidad acumulada de cuentas 400-500-600)
        public decimal Capital         { get; set; }  // cuenta 300: Haber - Debe
        public decimal Utilidad        { get; set; }  // Ventas(400) - COGS(500) - Gastos(600)
        public decimal TotalPatrimonio => Capital + Utilidad;

        // CUADRATURA: Activos = Pasivos + Patrimonio (tolerancia 0.01)
        public decimal Diferencia => TotalActivos - (TotalPasivos + TotalPatrimonio);
        public bool    Cuadra     => Math.Abs(Diferencia) <= 0.01m;
    }
}
