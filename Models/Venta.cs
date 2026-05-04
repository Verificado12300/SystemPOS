using System;

namespace SistemaPOS.Models
{
    public class Venta
    {
        public int VentaID { get; set; }
        public string NumeroVenta { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int? ClienteID { get; set; }
        public string TipoComprobante { get; set; } // BOLETA, FACTURA, NOTA_VENTA
        public string Serie { get; set; }
        public string Numero { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal IGV { get; set; }
        public int TipoIGV { get; set; }       // 0=SIN_IGV  1=IGV_INCLUIDO  2=IGV_ADICIONAL
        public decimal BaseImponible { get; set; }
        public decimal Total { get; set; }
        public string MetodoPago { get; set; } // EFECTIVO, YAPE, TARJETA, TRANSFERENCIA, MIXTO, CREDITO
        public decimal MontoEfectivo { get; set; }
        public decimal MontoYape { get; set; }
        public decimal MontoTarjeta { get; set; }
        public decimal MontoTransferencia { get; set; }
        public string Estado { get; set; } // COMPLETADA, ANULADA, CREDITO
        public int? CajaID { get; set; }
        public int UsuarioID { get; set; }
        public string Observaciones { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        public string MotivoAnulacion { get; set; }
    }
}
