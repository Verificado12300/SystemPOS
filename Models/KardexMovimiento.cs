using System;

namespace SistemaPOS.Models
{
    public class KardexMovimiento
    {
        public int ProductoID { get; set; }
        public string ProductoCodigo { get; set; }
        public string ProductoNombre { get; set; }
        public string UnidadSimbolo { get; set; }
        public DateTime FechaHora { get; set; }
        public string TipoMovimiento { get; set; }
        public string Documento { get; set; }
        public decimal Entrada { get; set; }
        public decimal Salida { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal CostoMovimiento { get; set; }
        public decimal CostoSaldo { get; set; }
        public decimal CostoPromedio { get; set; }
        public decimal StockAnterior { get; set; }
        public decimal StockPosterior { get; set; }
        public string Observacion { get; set; }
        public string UsuarioNombre { get; set; }
        public string PresentacionInfo { get; set; }
    }
}
