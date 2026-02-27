using System;

namespace SistemaPOS.Models
{
    public class PapeleraEntrada
    {
        public string   Entidad        { get; set; }  // "GASTO" | "VENTA" | "COMPRA"
        public int      EntidadId      { get; set; }
        public string   Referencia     { get; set; }  // Concepto / NumeroVenta / NumeroCompra
        public decimal  Monto          { get; set; }
        public DateTime FechaEliminado { get; set; }
        public string   UsuarioElimino { get; set; }
    }
}
