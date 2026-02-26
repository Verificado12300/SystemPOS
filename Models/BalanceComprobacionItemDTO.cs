namespace SistemaPOS.Models
{
    public class BalanceComprobacionItemDTO
    {
        public string  Codigo { get; set; }
        public string  Nombre { get; set; }
        public string  Tipo   { get; set; }
        public decimal Debe   { get; set; }
        public decimal Haber  { get; set; }
        public decimal Saldo  => Debe - Haber;
    }
}
