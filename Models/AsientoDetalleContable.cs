namespace SistemaPOS.Models
{
    public class AsientoDetalleContable
    {
        public int DetalleID { get; set; }
        public int AsientoID { get; set; }
        public int CuentaID { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public string Descripcion { get; set; }
    }
}
