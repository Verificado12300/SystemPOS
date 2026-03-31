using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using SistemaPOS.Data;
using SistemaPOS.Models;

namespace SistemaPOS.Utils
{
    public class TicketESCPOS
    {
        private readonly MemoryStream _buffer = new MemoryStream();
        private readonly Encoding _enc = Encoding.GetEncoding(858); // Western European with €

        // ── ESC/POS Commands ──
        private static readonly byte[] INIT                = { 0x1B, 0x40 };           // Initialize
        private static readonly byte[] ALIGN_LEFT          = { 0x1B, 0x61, 0x00 };
        private static readonly byte[] ALIGN_CENTER        = { 0x1B, 0x61, 0x01 };
        private static readonly byte[] ALIGN_RIGHT         = { 0x1B, 0x61, 0x02 };
        private static readonly byte[] BOLD_ON             = { 0x1B, 0x45, 0x01 };
        private static readonly byte[] BOLD_OFF            = { 0x1B, 0x45, 0x00 };
        private static readonly byte[] DOUBLE_ON           = { 0x1D, 0x21, 0x11 };     // GS ! — Double width+height (ESC/POS moderno)
        private static readonly byte[] DOUBLE_OFF          = { 0x1D, 0x21, 0x00 };     // GS ! — Normal size
        // ESC ! — comando original Epson, compatible con TODAS las térmicas
        // 0x08=bold  0x10=doble alto  0x20=doble ancho  → 0x38 = los tres juntos
        private static readonly byte[] EMPRESA_SIZE_ON     = { 0x1B, 0x21, 0x38 };     // ESC ! — bold+dblH+dblW
        private static readonly byte[] EMPRESA_SIZE_OFF    = { 0x1B, 0x21, 0x00 };     // ESC ! — normal
        private static readonly byte[] FONT_A              = { 0x1B, 0x4D, 0x00 };     // Font A (12x24)
        private static readonly byte[] FONT_B              = { 0x1B, 0x4D, 0x01 };     // Font B (9x17, smaller)
        private static readonly byte[] CUT_PAPER           = { 0x1D, 0x56, 0x42, 0x03 }; // Partial cut
        private static readonly byte[] FEED_LINES_3        = { 0x1B, 0x64, 0x03 };     // Feed 3 lines
        private static readonly byte[] FEED_LINES_1        = { 0x1B, 0x64, 0x01 };     // Feed 1 line
        private static readonly byte[] LINE_SPACING_DEFAULT = { 0x1B, 0x32 };          // Default line spacing

        // Number of characters per line (Font A, 80mm paper ≈ 42 chars; 58mm ≈ 32 chars)
        private int _lineWidth = 42;

        public TicketESCPOS(int paperWidthMm = 80)
        {
            _lineWidth = paperWidthMm <= 58 ? 32 : 42;
        }

        // ── Public API ──

        public byte[] GenerarTicket(DataTable detalle, Dictionary<string, string> p, TicketConfig config)
        {
            _buffer.SetLength(0);
            Write(INIT);
            Write(LINE_SPACING_DEFAULT);
            Write(FONT_A);

            // ── Logo ──────────────────────────────────────────────────────────────
            if (config.MostrarLogo)
            {
                try
                {
                    byte[] logoBytes = EmpresaRepository.ObtenerEmpresa()?.Logo;
                    if (logoBytes != null && logoBytes.Length > 0)
                    {
                        int maxDots = _lineWidth >= 42 ? 576 : 384;
                        PrintLogo(logoBytes, maxDots);
                    }
                }
                catch { }
            }

            // ── Company Header (centered) ──
            Write(ALIGN_CENTER);
            string empresa = Get(p, "pEmpresaNombre", "").ToUpper();
            if (!string.IsNullOrWhiteSpace(empresa))
            {
                Write(BOLD_ON);
                PrintLine(empresa);
                Write(BOLD_OFF);
            }

            if (config.MostrarRUC)
                PrintLine("RUC: " + Get(p, "pEmpresaRUC"));

            if (config.MostrarDireccion)
            {
                string dir = Get(p, "pEmpresaDireccion");
                if (!string.IsNullOrWhiteSpace(dir))
                    PrintLine(dir);
            }

            if (config.MostrarTelefono)
            {
                string tel = Get(p, "pEmpresaTelefono");
                if (!string.IsNullOrWhiteSpace(tel))
                    PrintLine("Tel: " + tel);
            }

            if (config.MostrarEmail)
            {
                string email = Get(p, "pEmpresaEmail");
                if (!string.IsNullOrWhiteSpace(email))
                    PrintLine(email);
            }

            // ── Separator + Tipo Comprobante + Número ──
            Write(ALIGN_LEFT);
            PrintSeparator();
            Write(ALIGN_CENTER);
            Write(BOLD_ON);
            PrintLine(Get(p, "pTipoComprobante", "NOTA DE VENTA").ToUpper());
            Write(BOLD_OFF);
            string nroVenta = Get(p, "pNumeroVenta");
            if (!string.IsNullOrWhiteSpace(nroVenta))
                PrintLine(nroVenta);
            Write(ALIGN_LEFT);
            PrintSeparator();

            PrintLine("Fecha   : " + Get(p, "pFecha", DateTime.Now.ToString("dd/MM/yyyy")) + "  " + Get(p, "pHora", DateTime.Now.ToString("HH:mm")));
            PrintLine("Cliente : " + (string.IsNullOrWhiteSpace(Get(p, "pCliente")) ? "CLIENTE GENERAL" : Get(p, "pCliente")));

            if (config.MostrarDNI)
            {
                string doc = Get(p, "pDocCliente");
                if (!string.IsNullOrWhiteSpace(doc) && doc != "00000000" && doc != "0")
                    PrintLine("DNI     : " + doc);
            }

            // ── Separator + Column Headers ──
            PrintSeparator();
            Write(BOLD_ON);
            PrintLine(FormatColumns("Descripcion", "Ud.", "Cant.", "Total"));
            Write(BOLD_OFF);
            PrintSeparator();

            // ── Detail Rows ──
            if (detalle != null)
            {
                foreach (DataRow row in detalle.Rows)
                {
                    string producto     = row["Producto"]?.ToString() ?? "";
                    string presentacion = row["Presentacion"]?.ToString() ?? "";
                    string cantidad     = decimal.TryParse(row["Cantidad"]?.ToString(), out decimal c) ? c.ToString("N2") : "0.00";
                    string subtotal     = decimal.TryParse(row["SubTotal"]?.ToString(), out decimal s) ? "S/" + s.ToString("N2") : "S/0.00";
                    PrintProductRow(producto, presentacion, cantidad, subtotal);
                }
            }

            // ── Separator + Totals ──
            PrintSeparator();
            PrintTwoColumns("SUBTOTAL:", FormatMoney(Get(p, "pSubTotal", "0.00")));
            string igvRaw = Get(p, "pIGV", "0");
            if (decimal.TryParse(igvRaw, out decimal igvEsc) && igvEsc > 0m)
                PrintTwoColumns("IGV:", FormatMoney(igvRaw));
            Write(BOLD_ON);
            PrintTwoColumns("TOTAL:", FormatMoney(Get(p, "pTotal", "0.00")));
            Write(BOLD_OFF);

            // ── Payment Info ──
            if (config.MostrarInfoPago)
            {
                PrintSeparator();
                PrintTwoColumns("Metodo de Pago:", Get(p, "pMetodoPago"));

                if (decimal.TryParse(Get(p, "pMontoRecibido"), out decimal recibido) && recibido > 0)
                    PrintTwoColumns("Recibido:", "S/" + recibido.ToString("N2"));

                if (decimal.TryParse(Get(p, "pVuelto"), out decimal vuelto) && vuelto > 0)
                    PrintTwoColumns("Vuelto:", "S/" + vuelto.ToString("N2"));
            }

            Write(BOLD_OFF);

            // ── Pie de página ──
            if (config.MostrarPie && !string.IsNullOrWhiteSpace(config.MensajePie))
            {
                PrintSeparator();
                Write(ALIGN_CENTER);
                foreach (string linea in config.MensajePie.Split(new[] { '\n', '|' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string l = linea.Trim();
                    if (!string.IsNullOrEmpty(l))
                        PrintLine(l);
                }
                Write(ALIGN_LEFT);
            }

            // ── Feed and Cut ──
            Write(FEED_LINES_3);

            bool cortarPapel = EmpresaRepository.ObtenerConfiguracion("TICKET_CORTAR_PAPEL", "true") == "true";
            if (cortarPapel)
                Write(CUT_PAPER);

            return _buffer.ToArray();
        }

        // ── Private helpers ──

        /// <summary>
        /// Convierte una imagen a ESC/POS raster bitmap (GS v 0) y la escribe centrada.
        /// maxWidthDots: ancho máximo imprimible en puntos (576 para 80mm, 384 para 58mm).
        /// </summary>
        private void PrintLogo(byte[] imageBytes, int maxWidthDots)
        {
            Image img;
            try { img = Image.FromStream(new MemoryStream(imageBytes)); }
            catch { return; }

            using (img)
            {
                // Escalar manteniendo proporción para que quepa en el ancho del papel
                int targetWidth  = Math.Min(img.Width, maxWidthDots);
                int targetHeight = (int)Math.Round((double)img.Height * targetWidth / img.Width);
                if (targetWidth < 1 || targetHeight < 1) return;

                using (var bmp = new Bitmap(targetWidth, targetHeight))
                {
                    using (var g = Graphics.FromImage(bmp))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(img, 0, 0, targetWidth, targetHeight);
                    }

                    // Convertir a 1 bit por píxel.
                    // Regla: imprimir cualquier píxel que NO sea blanco/casi-blanco ni transparente.
                    // Esto preserva colores como amarillo, rojo, azul, etc. que la fórmula de
                    // luminancia eliminaría por ser "claros" visualmente pero sí deben aparecer en negro.
                    int bytesPerRow = (targetWidth + 7) / 8;
                    var pixData     = new byte[bytesPerRow * targetHeight];

                    for (int y = 0; y < targetHeight; y++)
                    {
                        for (int x = 0; x < targetWidth; x++)
                        {
                            Color c = bmp.GetPixel(x, y);
                            // Transparente → no imprimir
                            if (c.A < 128) continue;
                            // Blanco o casi-blanco (R,G,B todos > 230) → no imprimir
                            if (c.R > 230 && c.G > 230 && c.B > 230) continue;
                            // Todo lo demás (negro, colores, amarillo, etc.) → imprimir
                            int byteIdx = y * bytesPerRow + x / 8;
                            int bitPos  = 7 - (x % 8);
                            pixData[byteIdx] |= (byte)(1 << bitPos);
                        }
                    }

                    // GS v 0 (raster bit image): 1D 76 30 00 xL xH yL yH [data]
                    Write(ALIGN_CENTER);
                    Write(new byte[]
                    {
                        0x1D, 0x76, 0x30, 0x00,
                        (byte)(bytesPerRow & 0xFF), (byte)((bytesPerRow >> 8) & 0xFF),
                        (byte)(targetHeight & 0xFF), (byte)((targetHeight >> 8) & 0xFF)
                    });
                    Write(pixData);
                    Write(FEED_LINES_1);
                }
            }
        }

        private void Write(byte[] data) => _buffer.Write(data, 0, data.Length);

        private void PrintLine(string text)
        {
            byte[] bytes = _enc.GetBytes(text + "\n");
            Write(bytes);
        }

        private void PrintSeparator()
        {
            PrintLine(new string('-', _lineWidth));
        }

        private void PrintTwoColumns(string left, string right)
        {
            if (left  == null) left  = "";
            if (right == null) right = "";
            int spaces = _lineWidth - left.Length - right.Length;
            if (spaces < 1)
            {
                int maxLeft = _lineWidth - right.Length - 1;
                if (maxLeft < 0) maxLeft = 0;
                left   = left.Length > maxLeft ? left.Substring(0, maxLeft) : left;
                spaces = 1;
            }
            PrintLine(left + new string(' ', spaces) + right);
        }

        /// <summary>
        /// Imprime una fila de producto. Si el nombre cabe en w1 chars, va en una línea.
        /// Si es más largo, imprime el nombre en la primera línea y los datos en la segunda.
        /// Ejemplo nombre largo:
        ///   "Crecimiento de Pollo Especial Premium"
        ///   "                  kg        2.00    S/240.00"
        /// </summary>
        private void PrintProductRow(string producto, string presentacion, string cantidad, string subtotal)
        {
            if (producto     == null) producto     = "";
            if (presentacion == null) presentacion = "";
            // 4 columnas: Desc(w1,izq) | Ud.(w2,centrado) | Cant.(w3,der) | Total(w4,der)
            // SIEMPRE UNA LÍNEA — descripción truncada a w1 si es más larga.
            int w1, w2, w3, w4;
            if (_lineWidth >= 42)
            { w1 = 21; w2 = 5; w3 = 6; w4 = 10; }   // 21+5+6+10 = 42
            else
            { w1 = 12; w2 = 5; w3 = 6; w4 =  9; }   // 12+5+6+9  = 32

            PrintLine(PadRight(producto, w1) + CenterPad(presentacion, w2) + PadLeft(cantidad, w3) + PadLeft(subtotal, w4));
        }

        private string FormatColumns(string col1, string col2, string col3, string col4)
        {
            // 4 columnas: Desc(w1,izq) | Ud.(w2,centrado) | Cant.(w3,der) | Total(w4,der)
            int w1, w2, w3, w4;
            if (_lineWidth >= 42)
            { w1 = 21; w2 = 5; w3 = 6; w4 = 10; }
            else
            { w1 = 12; w2 = 5; w3 = 6; w4 =  9; }
            return PadRight(col1, w1) + CenterPad(col2, w2) + PadLeft(col3, w3) + PadLeft(col4, w4);
        }

        private static string PadRight(string s, int w)
        {
            if (s == null) s = "";
            return s.Length >= w ? s.Substring(0, w) : s + new string(' ', w - s.Length);
        }

        private static string PadLeft(string s, int w)
        {
            if (s == null) s = "";
            return s.Length >= w ? s.Substring(0, w) : new string(' ', w - s.Length) + s;
        }

        private static string CenterPad(string s, int w)
        {
            if (s == null) s = "";
            if (s.Length >= w) return s.Substring(0, w);
            int pad   = w - s.Length;
            int left  = pad / 2;
            int right = pad - left;
            return new string(' ', left) + s + new string(' ', right);
        }

        private static string Get(Dictionary<string, string> p, string k, string def = "")
        {
            string v;
            return p != null && p.TryGetValue(k, out v) && v != null ? v : def;
        }

        private static string FormatMoney(string raw)
        {
            raw = raw?.Trim() ?? "0.00";
            if (raw.StartsWith("S/")) return raw;
            return "S/" + raw;
        }
    }
}
