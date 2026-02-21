namespace SistemaPOS.Models
{
    public class CompraDetalle
    {
        public int CompraDetalleID { get; set; }
        public int CompraID { get; set; }
        public int ProductoID { get; set; }
        public int ProductoPresentacionID { get; set; }
        public decimal Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal CostoPresentacion { get; set; }
        public decimal Subtotal { get; set; }
        public decimal CantidadUnidadesBase { get; set; }
    }
}
