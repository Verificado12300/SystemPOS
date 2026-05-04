using System;
using SistemaPOS.Data;

namespace SistemaPOS.Models
{
    public class TicketConfig
    {
        // ── Visibilidad ───────────────────────────────────────────────────────

        public bool MostrarLogo      { get; set; } = true;
        public bool MostrarNombre    { get; } = true;   // siempre visible, no configurable
        public bool MostrarRUC       { get; set; } = true;
        public bool MostrarDireccion { get; set; } = true;
        public bool MostrarTelefono  { get; set; } = true;
        public bool MostrarEmail     { get; set; } = false;
        public bool MostrarQR        { get; set; } = false;
        public bool MostrarDNI       { get; set; } = true;
        public bool MostrarPie       { get; set; } = true;
        public bool MostrarInfoPago  { get; set; } = true;

        // ── Tamaño logo ───────────────────────────────────────────────────────

        public int LogoAltura { get; set; } = 50;   // px en preview; escala a dots en ESC/POS

        // ── Texto ─────────────────────────────────────────────────────────────

        public string MensajePie { get; set; } = "Gracias por su compra!";

        // ── Fábrica: BD ───────────────────────────────────────────────────────

        /// <summary>
        /// Lee la configuración del ticket desde la base de datos.
        /// Si la BD no está disponible, devuelve valores por defecto.
        /// </summary>
        public static TicketConfig CargarDesdeDB()
        {
            var cfg = new TicketConfig();
            try
            {
                cfg.MostrarLogo      = Leer("TICKET_MOSTRAR_LOGO",       true);
                cfg.MostrarRUC       = Leer("TICKET_MOSTRAR_RUC",        true);
                cfg.MostrarDireccion = Leer("TICKET_MOSTRAR_DIRECCION",  true);
                cfg.MostrarTelefono  = Leer("TICKET_MOSTRAR_TELEFONO",   true);
                cfg.MostrarEmail     = Leer("TICKET_MOSTRAR_EMAIL",      false);
                cfg.MostrarQR        = Leer("TICKET_MOSTRAR_QR",         false);
                cfg.MostrarDNI       = Leer("TICKET_MOSTRAR_DNI",        true);
                cfg.MostrarPie       = Leer("TICKET_MOSTRAR_PIE",        true);
                cfg.MostrarInfoPago  = Leer("TICKET_MOSTRAR_INFO_PAGO",  true);
                cfg.LogoAltura = LeerEntero("TICKET_LOGO_ALTURA", 50);
                cfg.MensajePie = BuildMensajePie();
                // TICKET_MOSTRAR_NOMBRE no se lee: siempre true
            }
            catch (Exception)
            {
                // BD no disponible → devuelve el objeto con defaults ya asignados
            }
            return cfg;
        }

        // ── Fábrica: Demo ─────────────────────────────────────────────────────

        /// <summary>
        /// Devuelve una configuración de demostración con todas las secciones
        /// visibles, para usarse en la vista previa de FormImpresoras.
        /// </summary>
        public static TicketConfig CrearDemo() => new TicketConfig
        {
            MostrarLogo      = true,
            MostrarRUC       = true,
            MostrarDireccion = true,
            MostrarTelefono  = true,
            MostrarEmail     = true,
            MostrarQR        = true,
            MostrarDNI       = true,
            MostrarPie       = true,
            MostrarInfoPago  = true,
            MensajePie       = "¡Gracias por su compra! Vuelva pronto.",
        };

        // ── Helpers privados ──────────────────────────────────────────────────

        private static int LeerEntero(string clave, int valorDefault)
        {
            string raw = EmpresaRepository.ObtenerConfiguracion(clave, valorDefault.ToString());
            return int.TryParse(raw, out int v) ? v : valorDefault;
        }

        private static bool Leer(string clave, bool valorDefault)
        {
            string raw = EmpresaRepository.ObtenerConfiguracion(clave, valorDefault ? "1" : "0");
            return raw == "1" || string.Equals(raw, "true", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Lee TICKET_PIE_LINEA1 y TICKET_PIE_LINEA2 desde la BD y las combina con '|'.
        /// TicketESCPOS las divide y las imprime línea por línea.
        /// </summary>
        private static string BuildMensajePie()
        {
            string l1 = EmpresaRepository.ObtenerConfiguracion("TICKET_PIE_LINEA1", "Gracias por su compra!");
            string l2 = EmpresaRepository.ObtenerConfiguracion("TICKET_PIE_LINEA2", "");
            if (!string.IsNullOrWhiteSpace(l2))
                return l1 + "|" + l2;
            return l1;
        }
    }
}
