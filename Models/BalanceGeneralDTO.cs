using System;

namespace SistemaPOS.Models
{
    public class BalanceGeneralDTO
    {
        // ACTIVOS (saldo = Debe - Haber, cuentas 101/102/120/140/4012)
        public decimal Caja             { get; set; }
        public decimal Bancos           { get; set; }
        public decimal CxC              { get; set; }
        public decimal Inventario       { get; set; }
        public decimal IGVCreditoFiscal { get; set; }  // cuenta 4012: Debe - Haber
        public decimal TotalActivos => Caja + Bancos + CxC + Inventario + IGVCreditoFiscal;

        // PASIVOS (saldo = Haber - Debe, cuentas 200 y 210)
        public decimal CxP          { get; set; }
        public decimal Tributos     { get; set; }  // cuenta 210 Tributos por Pagar (IGV)
        public decimal TotalPasivos => CxP + Tributos;

        // PATRIMONIO (cuenta 300 + utilidad acumulada de cuentas 400-500-600)
        public decimal Capital         { get; set; }  // cuenta 300: Haber - Debe
        public decimal Utilidad        { get; set; }  // Ventas(400) - COGS(500) - Gastos(600)
        public decimal TotalPatrimonio => Capital + Utilidad;

        // CUADRATURA: Activos = Pasivos + Patrimonio (tolerancia 0.01)
        public decimal Diferencia => TotalActivos - (TotalPasivos + TotalPatrimonio);
        public bool    Cuadra     => Math.Abs(Diferencia) <= 0.01m;
    }
}
