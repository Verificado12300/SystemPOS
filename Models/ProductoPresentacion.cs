namespace SistemaPOS.Models
{
    public class ProductoPresentacion
    {
        public int ProductoPresentacionID { get; set; }
        public int ProductoID { get; set; }
        public int PresentacionID { get; set; }
        public decimal CantidadUnidades { get; set; }
        public decimal CostoBase { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal? Ganancia { get; set; }
        public bool Activo { get; set; }
        public bool PrecioIncluyeIGV { get; set; }
    }
}
