using System;
using System.Globalization;

namespace SistemaPOS.Models
{
    public class PeriodoContable
    {
        public int    PeriodoId   { get; set; }
        public string FechaInicio { get; set; }   // YYYY-MM-DD
        public string FechaFin    { get; set; }   // YYYY-MM-DD
        public bool   Cerrado     { get; set; }
        public string CerradoEn   { get; set; }   // ISO datetime, nullable
        public string CerradoPor  { get; set; }   // login del usuario, nullable

        // Computados para la UI
        public string Descripcion
        {
            get
            {
                if (DateTime.TryParse(FechaInicio, out var d))
                    return d.ToString("MMMM yyyy", new CultureInfo("es-PE"));
                return FechaInicio ?? "";
            }
        }

        public string Estado => Cerrado ? "CERRADO" : "ABIERTO";
    }
}
