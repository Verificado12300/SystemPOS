using System;

namespace SistemaPOS.Models
{
    public class Compra
    {
        public int CompraID { get; set; }
        public string NumeroCompra { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int ProveedorID { get; set; }
        public string TipoComprobante { get; set; } // FACTURA, BOLETA, GUIA
        public string Serie { get; set; }
        public string Numero { get; set; }
        public bool IncluyeIGV { get; set; }
        public int TipoIGV { get; set; }         // 0=SinIGV 1=IGVIncluido 2=IGVAdicional
        public decimal BaseImponible { get; set; }
        public decimal SubTotal { get; set; }
        public decimal IGV { get; set; }
        public decimal Total { get; set; }
        public string MetodoPago { get; set; } // EFECTIVO, TRANSFERENCIA, CREDITO
        public string Estado { get; set; } // COMPLETADA, ANULADA, CREDITO
        public int UsuarioID { get; set; }
        public decimal Flete { get; set; }
        public string Observaciones { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        public string MotivoAnulacion { get; set; }
    }
}
