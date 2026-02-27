using System;

namespace SistemaPOS.Models
{
    public class Gasto
    {
        public int GastoID { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public string Categoria { get; set; }
        public string MetodoPago { get; set; }
        public string Comprobante { get; set; }
        public string Observaciones { get; set; }
        public int? CajaID { get; set; }
        public int UsuarioID { get; set; }
        public int TipoIGV { get; set; }         // 0=SinIGV 1=IGVIncluido 2=IGVAdicional
        public decimal BaseImponible { get; set; } // Monto = Total (flujo caja real)
        public int? ProveedorID { get; set; }     // Solo cuando MetodoPago='CREDITO'
    }
}
