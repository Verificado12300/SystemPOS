using System;

namespace SistemaPOS.Models
{
    public class MovimientoCuenta
    {
        public int?     PagoVentaID { get; set; }   // null si no se puede anular
        public DateTime Fecha       { get; set; }
        public TimeSpan Hora        { get; set; }
        public string   Tipo        { get; set; }   // VENTA | PAGO | ANULACION_COBRO
        public string   Documento   { get; set; }   // NumeroVenta / referencia
        public string   Metodo      { get; set; }   // MetodoPago
        public decimal  Cargo       { get; set; }
        public decimal  Abono       { get; set; }
        public decimal  Saldo       { get; set; }   // acumulado, calculado en memoria
        public bool     Anulado     { get; set; }
        public bool     PuedeAnular { get; set; }   // sólo pagos activos
        public int      OrdenSort   { get; set; }   // clave interna de ordenamiento
    }
}
