namespace SistemaPOS.Models
{
    public class CuentaContable
    {
        public int CuentaID { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; } // ACTIVO, PASIVO, PATRIMONIO, INGRESO, GASTO
        public bool Activa { get; set; }
    }
}
