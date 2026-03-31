using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using SistemaPOS.Controls;
using SistemaPOS.Data;

namespace SistemaPOS.Utils
{
    /// <summary>
    /// Lógica de impresión de ticket compartida entre FormPreviewTicket y FormImpresoras.
    /// Lee TODOS los parámetros de impresión desde la base de datos:
    ///   IMPRESORA_PREDETERMINADA, ANCHO_PAPEL_TICKET, TICKET_ESCALA_AJUSTE,
    ///   TICKET_MARGEN_IZQ_MM, TICKET_MARGEN_DER_MM, TICKET_MARGEN_SUP_MM, TICKET_MARGEN_INF_MM
    /// </summary>
    public static class TicketPrinter
    {
        /// <summary>
        /// Imprime el ticket usando la configuración guardada en la base de datos.
        /// Lanza excepción si falla la impresión (el llamador debe manejarla).
        /// </summary>
        public static void ImprimirTicket(TicketPreviewControl ticket)
        {
            if (ticket == null) throw new ArgumentNullException("ticket");

            // ── Leer configuración desde BD ───────────────────────────────────
            string impresora = EmpresaRepository.ObtenerConfiguracion("IMPRESORA_PREDETERMINADA", "");

            int anchoMm = 88;
            if (int.TryParse(EmpresaRepository.ObtenerConfiguracion("ANCHO_PAPEL_TICKET", "88"), out int aMm) && aMm > 0)
                anchoMm = aMm;

            int ajusteEscala = 0;
            int.TryParse(EmpresaRepository.ObtenerConfiguracion("TICKET_ESCALA_AJUSTE", "0"), out ajusteEscala);

            int margenIzqMm = 0; int.TryParse(EmpresaRepository.ObtenerConfiguracion("TICKET_MARGEN_IZQ_MM", "0"), out margenIzqMm);
            int margenDerMm = 0; int.TryParse(EmpresaRepository.ObtenerConfiguracion("TICKET_MARGEN_DER_MM", "0"), out margenDerMm);
            int margenSupMm = 0; int.TryParse(EmpresaRepository.ObtenerConfiguracion("TICKET_MARGEN_SUP_MM", "0"), out margenSupMm);
            int margenInfMm = 0; int.TryParse(EmpresaRepository.ObtenerConfiguracion("TICKET_MARGEN_INF_MM", "0"), out margenInfMm);

            int copias = 1;
            if (int.TryParse(EmpresaRepository.ObtenerConfiguracion("TICKET_COPIAS", "1"), out int c) && c > 0)
                copias = c;

            // ── Calcular dimensiones ──────────────────────────────────────────
            int anchoPapel = MmAHundredthsInch(anchoMm);
            double factorEscala = Math.Max(0.5d, 1d + (ajusteEscala / 100d));
            int margenIzq = MmAHundredthsInch(margenIzqMm);
            int margenDer = MmAHundredthsInch(margenDerMm);
            int margenSup = MmAHundredthsInch(margenSupMm);
            int margenInf = MmAHundredthsInch(margenInfMm);

            int altoContenido = ticket.ContentHeight;
            int anchoVista    = ticket.ContentWidth;

            int anchoBase      = Math.Max(1, anchoPapel - margenIzq - margenDer);
            int anchoContenido = Math.Min(anchoBase, Math.Max(1, (int)Math.Round(anchoBase * factorEscala)));
            double relacionVista = (double)altoContenido / Math.Max(1, anchoVista);
            int altoContenidoEscalado = (int)Math.Ceiling(anchoContenido * relacionVista);
            int altoPapel = Math.Max(200, altoContenidoEscalado + margenSup + margenInf);

            // ── Imprimir ──────────────────────────────────────────────────────
            using (var pd = new PrintDocument())
            {
                if (!string.IsNullOrWhiteSpace(impresora))
                    pd.PrinterSettings.PrinterName = impresora;

                pd.PrinterSettings.Copies = (short)Math.Max(1, copias);
                pd.OriginAtMargins = false;
                pd.DefaultPageSettings.Landscape = false;
                pd.DefaultPageSettings.Margins   = new Margins(0, 0, 0, 0);
                pd.DefaultPageSettings.PaperSize = new PaperSize("Ticket", anchoPapel, altoPapel);

                pd.PrintPage += (s, ev) =>
                {
                    ev.Graphics.Clear(Color.White);
                    ev.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    ev.Graphics.InterpolationMode  = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    ev.Graphics.SmoothingMode      = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    ev.Graphics.PixelOffsetMode    = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    ev.Graphics.TextRenderingHint  = TextRenderingHint.AntiAliasGridFit;
                    ev.Graphics.TranslateTransform(-ev.PageSettings.HardMarginX, -ev.PageSettings.HardMarginY);

                    // Tolerar diferencias entre el ancho pedido y el ancho real del driver
                    int anchoDriver = Math.Max(1, ev.PageBounds.Width);
                    int anchoBaseReal = Math.Abs(anchoDriver - anchoPapel) > (anchoPapel / 4)
                        ? anchoDriver : anchoPapel;
                    int anchoImprimible = Math.Max(1, anchoBaseReal - margenIzq - margenDer);
                    int anchoDestino    = Math.Min(anchoImprimible, Math.Max(1, (int)Math.Round(anchoImprimible * factorEscala)));

                    var destino = new Rectangle
                    {
                        X      = margenIzq,
                        Y      = margenSup,
                        Width  = anchoDestino,
                        Height = (int)Math.Round(anchoDestino * relacionVista)
                    };
                    destino.Height = Math.Min(destino.Height, Math.Max(1, ev.PageBounds.Height - margenSup - margenInf));

                    ticket.RenderForPrint(ev.Graphics, destino, altoContenido);
                    ev.HasMorePages = false;
                };

                pd.Print();
            }
        }

        private static int MmAHundredthsInch(int mm)
        {
            return (int)Math.Round(mm * 3.937d);
        }
    }
}
