using System.Collections.Generic;

namespace SistemaPOS.Models
{
    public class FlujoCajaDiaDTO
    {
        public System.DateTime Fecha    { get; set; }
        public decimal         Entradas { get; set; }
        public decimal         Salidas  { get; set; }
        public decimal         Neto     => Entradas - Salidas;
    }

    public class FlujoCajaDTO
    {
        public decimal TotalEntradas  { get; set; }
        public decimal TotalSalidas   { get; set; }
        public decimal Neto           => TotalEntradas - TotalSalidas;

        // Desglose por origen
        public decimal EntradasCaja   { get; set; }   // cuenta 101
        public decimal SalidasCaja    { get; set; }
        public decimal EntradasBancos { get; set; }   // cuenta 102
        public decimal SalidasBancos  { get; set; }

        public List<FlujoCajaDiaDTO> DetallesPorDia { get; set; }

        public FlujoCajaDTO()
        {
            DetallesPorDia = new List<FlujoCajaDiaDTO>();
        }
    }
}
