namespace SistemaPOS.Models
{
    public class EstadoResultadosDTO
    {
        public decimal Ventas             { get; set; }
        public decimal CostoVentas        { get; set; }
        public decimal UtilidadBruta      { get; set; }
        public decimal Gastos             { get; set; }
        public decimal UtilidadOperativa  { get; set; }
    }
}
