using System;
using System.Collections.Generic;

namespace SistemaPOS.Models
{
    public class AsientoContable
    {
        public int AsientoID { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string TipoOperacion { get; set; } // VENTA, COMPRA, AJUSTE, GASTO, COBRO, PAGO, ANULACION
        public string Documento { get; set; }
        public int? ReferenciaID { get; set; }
        public int? UsuarioID { get; set; }
        // Auditoría mínima — rellenados por ContabilidadService antes de insertar
        public string ModuloOrigen { get; set; } = "SISTEMA"; // VENTA, COMPRA, GASTO, INVENTARIO…
        public int? OrigenId { get; set; }          // ID del registro origen (ventaID, compraID…)
        public string Glosa { get; set; }
        public decimal TotalDebe { get; set; }
        public decimal TotalHaber { get; set; }
        public List<AsientoDetalleContable> Detalles { get; set; } = new List<AsientoDetalleContable>();
    }
}
