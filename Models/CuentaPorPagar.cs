using System;

namespace SistemaPOS.Models
{
    public class CuentaPorPagar
    {
        public int CuentaPorPagarID { get; set; }
        public string TipoOrigen { get; set; }    // 'COMPRA' | 'GASTO'
        public int IdOrigen { get; set; }          // CompraID o GastoID
        public int? CompraID { get; set; }         // Backward-compat; null para GASTO
        public int? ProveedorID { get; set; }
        public string ProveedorNombre { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal MontoPendiente { get; set; }
        public string FechaEmision { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
    }
}
