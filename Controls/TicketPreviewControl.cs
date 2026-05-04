using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;

namespace SistemaPOS.Controls
{
    /// <summary>
    /// Vista previa del ticket de venta como papel térmico monoespaciado.
    /// Usa un único RichTextBox (Consolas 8.25F) con la misma lógica de columnas
    /// que TicketESCPOS (w1=21, w2=5 centrado, w3=6, w4=10).
    ///
    /// Usuarios:
    ///   - FormPreviewTicket  → LlenarDatos(dt, parametros)
    ///   - FormImpresoras     → LlenarDatosDemo(config)
    ///   - TicketPrinter      → RenderForPrint(g, dest, h)
    ///   - Historial/reimpres → RenderToBitmap()
    /// </summary>
    public partial class TicketPreviewControl : TicketDesignPanel
    {
        // Ancho de línea en caracteres (papel 80mm ≈ 42 chars Courier New 8.25F)
        private const int W = 42;

        private TicketConfig _config;

        public TicketPreviewControl()
        {
            InitializeComponent();
            AjustarAncho();
        }

        // Mide el ancho real del carácter Consolas 8.25F y ajusta el control.
        // Se llama en el constructor y al inicio de Renderizar (por si el caller
        // sobrescribió Width después de construir el control).
        //
        // IMPORTANTE: usar TextRenderer (GDI) en lugar de Graphics.MeasureString (GDI+).
        // El RichTextBox renderiza con GDI; GDI+ puede subestimar el ancho unos píxeles,
        // dejando el control demasiado estrecho → el RichEdit hace wrap de la última
        // letra al inicio de la siguiente línea (ej. "EFECTIV" + "O" en líneas distintas).
        private void AjustarAncho()
        {
            // TextRenderer.MeasureText usa GDI, igual que el RichTextBox.
            // NoPadding elimina el holgado extra que GDI añade por defecto.
            Size sz = TextRenderer.MeasureText(
                new string('M', W),
                rtbTicket.Font,
                new Size(99999, 99999),
                TextFormatFlags.NoPadding);

            // Usar el ancho medido exacto para Consolas (no el piso W*7 que era para Courier New).
            // +4 = pequeño margen para evitar wrap accidental de la última letra.
            int rtbWidth  = sz.Width + 4;   // +4 para evitar wrap accidental
            int ctrlWidth = rtbWidth + 4;   // 2px izq + 2px der

            rtbTicket.Width  = rtbWidth;
            rtbTicket.Left   = 2;           // margen simétrico: 2px izq, 2px der
            pbLogo.Left      = 0;
            pbLogo.Width     = ctrlWidth;
            lblEmpresa.Left  = 0;
            lblEmpresa.Width = ctrlWidth;
            this.Width       = ctrlWidth;
        }

        // ═══════════════════════════════════════════════════════════════════════
        // API PÚBLICA
        // ═══════════════════════════════════════════════════════════════════════

        /// <summary>Llena con datos reales de una venta. Si config es null, lee desde BD.</summary>
        public void LlenarDatos(DataTable detalle, Dictionary<string, string> p, TicketConfig config = null)
        {
            _config = config ?? TicketConfig.CargarDesdeDB();
            CompletarEmpresa(p);
            Renderizar(detalle, p);
        }

        /// <summary>Llena con datos de demo usando la configuración provista. No lee BD. Para FormImpresoras.</summary>
        public void LlenarDatosDemo(TicketConfig config)
        {
            _config = config;

            var dt = new DataTable();
            dt.Columns.Add("Numero",       typeof(int));
            dt.Columns.Add("Producto",     typeof(string));
            dt.Columns.Add("Presentacion", typeof(string));
            dt.Columns.Add("Cantidad",     typeof(decimal));
            dt.Columns.Add("SubTotal",     typeof(decimal));
            dt.Rows.Add(1, "CRECIMIENTO DE POLLO",  "kg", 100.00m, 240.00m);
            dt.Rows.Add(2, "MAIZ INTEGRAL GRUESO", "kg",  42.50m,  85.00m);

            var p = new Dictionary<string, string>
            {
                ["pTipoComprobante"] = "NOTA DE VENTA",
                ["pNumeroVenta"]     = "N001-00000001",
                ["pFecha"]           = DateTime.Now.ToString("dd/MM/yyyy"),
                ["pHora"]            = DateTime.Now.ToString("HH:mm"),
                ["pCliente"]         = "Cliente Demo",
                ["pDocCliente"]      = _config.MostrarDNI ? "12345678" : "",
                ["pSubTotal"]        = "325.00",
                ["pIGV"]             = "0.00",
                ["pTotal"]           = "325.00",
                ["pMetodoPago"]      = "EFECTIVO",
                ["pMontoRecibido"]   = "325.00",
                ["pVuelto"]          = "0.00",
            };
            CompletarEmpresa(p);
            // Fallback: nombre empresa siempre visible en demo
            if (!p.ContainsKey("pEmpresaNombre") || string.IsNullOrWhiteSpace(p["pEmpresaNombre"]))
                p["pEmpresaNombre"] = "MI EMPRESA S.A.C.";
            // Fallback: si la dirección de BD está vacía o es placeholder, usar ficticia
            if (string.IsNullOrWhiteSpace(p.ContainsKey("pEmpresaDireccion") ? p["pEmpresaDireccion"] : "")
                || (p.ContainsKey("pEmpresaDireccion") && p["pEmpresaDireccion"].Contains("*")))
                p["pEmpresaDireccion"] = "Av. Los Pinos 234, Lima";
            Renderizar(dt, p);
        }

        /// <summary>Re-mide el ancho con DPI real y reposiciona hijos. Llamado por FormPreviewTicket.OnShown.</summary>
        public void Reflow()
        {
            AjustarAncho();
            int topY = 4;
            if (pbLogo.Visible)    { pbLogo.Top    = topY; topY = pbLogo.Bottom    + 2; }
            if (lblEmpresa.Visible){ lblEmpresa.Top = topY; topY = lblEmpresa.Bottom + 2; }
            rtbTicket.Location = new System.Drawing.Point(2, topY);
            // Recalcular altura: el ancho real (post-DPI) puede cambiar el conteo de líneas
            int lh = rtbTicket.Font.Height + 1;
            rtbTicket.Height = Math.Max(1, rtbTicket.Lines.Length * lh + 4);
            this.Height = rtbTicket.Bottom + 3;
        }

        /// <summary>Alto del control tras el último Renderizar.</summary>
        public int ContentHeight => Height;

        /// <summary>Ancho lógico del ticket.</summary>
        public int ContentWidth => Width;

        /// <summary>Crea un Bitmap del estado actual (para historial / reimpresión estática).</summary>
        public Bitmap RenderToBitmap()
        {
            int w = Math.Max(1, Width);
            int h = Math.Max(1, Height);
            CreateControl(); // garantiza que el HWND exista antes de DrawToBitmap
            var bmp = new Bitmap(w, h);
            DrawToBitmap(bmp, new Rectangle(0, 0, w, h));
            DibujarLogoEnBitmap(bmp, h);
            return bmp;
        }

        /// <summary>Renderiza el control escalado en el rectángulo destino (para TicketPrinter).</summary>
        public new void RenderForPrint(Graphics g, Rectangle destino, int sourceHeight)
        {
            int logH = sourceHeight > 0 ? Math.Min(sourceHeight, Height) : Height;
            logH = Math.Max(1, logH);
            CreateControl();
            using (var bmp = new Bitmap(Math.Max(1, Width), logH))
            {
                DrawToBitmap(bmp, new Rectangle(0, 0, Math.Max(1, Width), logH));
                // PictureBox no siempre responde a WM_PRINTCLIENT — dibujar logo explícitamente.
                DibujarLogoEnBitmap(bmp, logH);
                g.DrawImage(bmp, destino);
            }
        }

        // ═══════════════════════════════════════════════════════════════════════
        // RENDERIZADO MONOESPACIADO
        // ═══════════════════════════════════════════════════════════════════════

        // PictureBox no siempre emite contenido con DrawToBitmap (WM_PRINTCLIENT).
        // Este método lo dibuja manualmente en el bitmap resultante usando SizeMode.Zoom.
        private void DibujarLogoEnBitmap(Bitmap bmp, int logH)
        {
            if (!pbLogo.Visible || pbLogo.Image == null || pbLogo.Top >= logH) return;
            using (var g2 = Graphics.FromImage(bmp))
            {
                g2.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g2.InterpolationMode  = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g2.SmoothingMode      = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                float rw    = pbLogo.Width  / (float)Math.Max(1, pbLogo.Image.Width);
                float rh    = pbLogo.Height / (float)Math.Max(1, pbLogo.Image.Height);
                float ratio = Math.Min(rw, rh);
                int   iw    = Math.Max(1, (int)Math.Round(pbLogo.Image.Width  * ratio));
                int   ih    = Math.Max(1, (int)Math.Round(pbLogo.Image.Height * ratio));
                int   ix    = pbLogo.Left + (pbLogo.Width  - iw) / 2;
                int   iy    = pbLogo.Top  + (pbLogo.Height - ih) / 2;
                g2.FillRectangle(Brushes.White, pbLogo.Left, pbLogo.Top, pbLogo.Width, pbLogo.Height);
                g2.DrawImage(pbLogo.Image, new Rectangle(ix, iy, iw, ih));
            }
        }

        private void Renderizar(DataTable detalle, Dictionary<string, string> p)
        {
            // ── Logo (opcional) ────────────────────────────────────────────────
            pbLogo.Visible = false;
            if (_config.MostrarLogo)
            {
                try
                {
                    byte[] bytes = EmpresaRepository.ObtenerEmpresa()?.Logo;
                    if (bytes != null && bytes.Length > 0)
                    {
                        Bitmap cropped = AutoCropImage(bytes);
                        var oldImg = pbLogo.Image;
                        pbLogo.Height  = Math.Max(20, _config.LogoAltura);
                        pbLogo.Image   = cropped;
                        pbLogo.Visible = true;
                        oldImg?.Dispose();
                    }
                }
                catch { }
            }

            // Re-medir por si el caller sobrescribió Width después del constructor
            AjustarAncho();

            // ── Nombre de empresa: Label independiente (centrado automático) ──
            string empresa = Get(p, "pEmpresaNombre", "").ToUpper();
            lblEmpresa.Text    = empresa;
            lblEmpresa.Height  = lblEmpresa.Font.Height + 6;
            lblEmpresa.Visible = !string.IsNullOrWhiteSpace(empresa);

            // ── Apilar controles: 4px arriba, logo → nombre → cuerpo ──────────
            int topY = 4;
            if (pbLogo.Visible)    { pbLogo.Top    = topY; topY = pbLogo.Bottom    + 2; }
            if (lblEmpresa.Visible){ lblEmpresa.Top = topY; topY = lblEmpresa.Bottom + 2; }
            rtbTicket.Location = new Point(2, topY);

            // ── Construir texto del ticket (empresa va en el Label, no aquí) ──
            var sb = new StringBuilder();

            if (_config.MostrarRUC)
            {
                string ruc = Get(p, "pEmpresaRUC");
                if (!string.IsNullOrWhiteSpace(ruc))
                    sb.AppendLine(Center("RUC: " + ruc, W));
            }

            if (_config.MostrarDireccion)
            {
                string dir = Get(p, "pEmpresaDireccion");
                if (!string.IsNullOrWhiteSpace(dir))
                    sb.AppendLine(Center(dir, W));
            }

            if (_config.MostrarTelefono)
            {
                string tel = Get(p, "pEmpresaTelefono");
                if (!string.IsNullOrWhiteSpace(tel))
                    sb.AppendLine(Center("Tel: " + tel, W));
            }

            if (_config.MostrarEmail)
            {
                string email = Get(p, "pEmpresaEmail");
                if (!string.IsNullOrWhiteSpace(email))
                    sb.AppendLine(Center(email, W));
            }

            // Separador → Tipo comprobante + número (centrados)
            sb.AppendLine(Sep());
            string comprobante = Get(p, "pTipoComprobante", "NOTA DE VENTA").ToUpper();
            sb.AppendLine(Center(comprobante, W));
            string numero = Get(p, "pNumeroVenta");
            if (!string.IsNullOrWhiteSpace(numero))
                sb.AppendLine(Center(numero, W));

            // Separador → Fecha, Cliente, DNI
            sb.AppendLine(Sep());
            sb.AppendLine(TruncLeft("Fecha   : " + Get(p, "pFecha", DateTime.Now.ToString("dd/MM/yyyy"))
                                    + "  " + Get(p, "pHora", DateTime.Now.ToString("HH:mm")), W));

            string cliente = Get(p, "pCliente");
            if (string.IsNullOrWhiteSpace(cliente)) cliente = "CLIENTE GENERAL";
            sb.AppendLine(TruncLeft("Cliente : " + cliente, W));

            if (_config.MostrarDNI)
            {
                string doc   = Get(p, "pDocCliente");
                bool   esGen = string.IsNullOrWhiteSpace(Get(p, "pCliente"))
                               || Get(p, "pCliente").IndexOf("GENERAL", StringComparison.OrdinalIgnoreCase) >= 0
                               || Get(p, "pCliente").IndexOf("VARIOS",  StringComparison.OrdinalIgnoreCase) >= 0;
                bool   docOK = !string.IsNullOrWhiteSpace(doc) && doc != "00000000" && doc != "0";
                if (docOK && !esGen)
                    sb.AppendLine(TruncLeft("DNI     : " + doc, W));
            }

            // Separador → Encabezado columnas
            sb.AppendLine(Sep());
            sb.AppendLine(FormatColumns("Descripcion", "Ud.", "Cant.", "Total"));
            sb.AppendLine(Sep());

            // Filas de producto
            if (detalle != null)
            {
                foreach (DataRow row in detalle.Rows)
                {
                    string prod = row["Producto"]?.ToString()     ?? "";
                    string pres = row["Presentacion"]?.ToString() ?? "";
                    string cant = decimal.TryParse(row["Cantidad"]?.ToString(), out decimal c)
                                  ? c.ToString("N2") : "0.00";
                    string sub  = decimal.TryParse(row["SubTotal"]?.ToString(), out decimal s)
                                  ? "S/" + s.ToString("N2") : "S/0.00";
                    FormatProductRow(sb, prod, pres, cant, sub);
                }
            }

            // Separador → Totales alineados a la derecha
            sb.AppendLine(Sep());
            sb.AppendLine(TwoColumns("SUBTOTAL:", FormatMoney(Get(p, "pSubTotal", "0.00"))));
            decimal igvPreview = decimal.TryParse(Get(p, "pIGV", "0"), out decimal igvPv) ? igvPv : 0m;
            if (igvPreview > 0m)
                sb.AppendLine(TwoColumns("IGV:", FormatMoney(Get(p, "pIGV", "0.00"))));
            sb.AppendLine(TwoColumns("TOTAL:", FormatMoney(Get(p, "pTotal", "0.00"))));

            // Info de pago — solo si hay datos reales (omite bloque en vista previa pre-venta)
            if (_config.MostrarInfoPago)
            {
                string metodoPago = Get(p, "pMetodoPago");
                decimal.TryParse(Get(p, "pMontoRecibido"), out decimal recibido);
                decimal.TryParse(Get(p, "pVuelto"),        out decimal vuelto);
                bool hayInfoPago = !string.IsNullOrEmpty(metodoPago) || recibido > 0 || vuelto > 0;
                if (hayInfoPago)
                {
                    sb.AppendLine(Sep());
                    if (!string.IsNullOrEmpty(metodoPago))
                        sb.AppendLine(TwoColumns("Metodo de Pago:", metodoPago));
                    if (metodoPago == "Mixto")
                    {
                        decimal.TryParse(Get(p, "pMontoEfectivo"),     out decimal mEf);
                        decimal.TryParse(Get(p, "pMontoYape"),          out decimal mYp);
                        decimal.TryParse(Get(p, "pMontoTransferencia"), out decimal mTr);
                        decimal.TryParse(Get(p, "pMontoTarjeta"),       out decimal mTj);
                        if (mEf > 0) sb.AppendLine(TwoColumns("  Efectivo:",  "S/" + mEf.ToString("N2")));
                        if (mYp > 0) sb.AppendLine(TwoColumns("  Yape:",      "S/" + mYp.ToString("N2")));
                        if (mTr > 0) sb.AppendLine(TwoColumns("  Transfer.:", "S/" + mTr.ToString("N2")));
                        if (mTj > 0) sb.AppendLine(TwoColumns("  Tarjeta:",   "S/" + mTj.ToString("N2")));
                    }
                    if (recibido > 0)
                        sb.AppendLine(TwoColumns("Recibido:", "S/" + recibido.ToString("N2")));
                    if (vuelto > 0)
                        sb.AppendLine(TwoColumns("Vuelto:", "S/" + vuelto.ToString("N2")));
                }
            }

            // Pie de página (centrado)
            if (_config.MostrarPie && !string.IsNullOrWhiteSpace(_config.MensajePie))
            {
                sb.AppendLine(Sep());
                foreach (string linea in _config.MensajePie.Split(new[] { '\n', '|' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string l = linea.Trim();
                    if (!string.IsNullOrEmpty(l))
                        sb.AppendLine(Center(l, W));
                }
            }

            // Asignar texto (sin \r\n final para no contar línea vacía extra)
            rtbTicket.Text = sb.ToString().TrimEnd('\r', '\n');
            rtbTicket.SelectionStart  = 0;
            rtbTicket.SelectionLength = 0;

            // Aplicar negrita (comprobante, encabezado columnas, TOTAL)
            AplicarNegritaTicket(rtbTicket, comprobante);

            // Ajustar altura: todo el RichTextBox usa 8.25F uniforme → cálculo simple
            int lh     = rtbTicket.Font.Height + 1;
            int nLines = rtbTicket.Lines.Length;
            rtbTicket.Height = Math.Max(1, nLines * lh + 4);
            this.Height      = rtbTicket.Bottom + 3;
        }

        // ═══════════════════════════════════════════════════════════════════════
        // NEGRITA — replica exactamente los BOLD_ON del ESC/POS
        // ═══════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Aplica negrita a las mismas líneas que TicketESCPOS marca con BOLD_ON:
        ///   • Nombre de empresa  (1ª línea del encabezado)
        ///   • Tipo de comprobante (ej. "NOTA DE VENTA")
        ///   • Encabezado de columnas ("Descripcion  Ud.  Cant.  Total")
        ///   • Línea TOTAL (no coincide con SUBTOTAL porque empieza por "S")
        /// </summary>
        /// <summary>
        /// Aplica negrita en el RichTextBox a las líneas que ESC/POS marca con BOLD_ON:
        /// tipo de comprobante, encabezado de columnas y línea TOTAL.
        /// El nombre de empresa ya no vive aquí — lo muestra lblEmpresa (Label centrado).
        /// </summary>
        private static void AplicarNegritaTicket(RichTextBox rtb, string comprobante)
        {
            var boldFont = new Font(rtb.Font, FontStyle.Bold);
            try
            {
                for (int i = 0; i < rtb.Lines.Length; i++)
                {
                    string line = rtb.Lines[i];
                    string t    = line.Trim();
                    bool   bold =
                        (!string.IsNullOrWhiteSpace(comprobante) && t == comprobante.Trim()) ||
                        t.StartsWith("Descripci") ||   // encabezado columnas
                        t.StartsWith("TOTAL:");        // "SUBTOTAL:" empieza por S → no coincide
                    if (!bold) continue;
                    int start = rtb.GetFirstCharIndexFromLine(i);
                    if (start < 0) continue;
                    rtb.Select(start, line.Length);
                    rtb.SelectionFont = boldFont;
                }
            }
            finally
            {
                rtb.Select(0, 0);
                boldFont.Dispose();
            }
        }

        // ═══════════════════════════════════════════════════════════════════════
        // AUTO-CROP DE LOGO
        // ═══════════════════════════════════════════════════════════════════════

        // Elimina márgenes blancos de la imagen y devuelve un nuevo Bitmap recortado.
        // Si no encuentra contenido (imagen completamente blanca), devuelve la imagen original.
        private static Bitmap AutoCropImage(byte[] imageBytes)
        {
            using (var ms = new MemoryStream(imageBytes))
            using (var original = Image.FromStream(ms, false, true))
            using (var bmp = new Bitmap(original.Width, original.Height, PixelFormat.Format32bppArgb))
            {
                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    g.DrawImage(original, 0, 0, original.Width, original.Height);
                }

                const byte thr = 240;
                int left = bmp.Width, right = -1, top = bmp.Height, bottom = -1;

                var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                try
                {
                    int stride = Math.Abs(data.Stride);
                    var raw    = new byte[stride * bmp.Height];
                    Marshal.Copy(data.Scan0, raw, 0, raw.Length);
                    for (int y = 0; y < bmp.Height; y++)
                        for (int x = 0; x < bmp.Width; x++)
                        {
                            int off = y * stride + x * 4; // B G R A
                            if (raw[off + 2] >= thr && raw[off + 1] >= thr && raw[off] >= thr) continue;
                            if (x < left)   left   = x;
                            if (x > right)  right  = x;
                            if (y < top)    top    = y;
                            if (y > bottom) bottom = y;
                        }
                }
                finally { bmp.UnlockBits(data); }

                if (right < 0)
                    return new Bitmap(original); // imagen completamente blanca — devolver sin cambios

                var crop = new Rectangle(left, top, right - left + 1, bottom - top + 1);
                return bmp.Clone(crop, PixelFormat.Format32bppArgb);
            }
        }

        // ═══════════════════════════════════════════════════════════════════════
        // HELPERS DE FORMATO (mismo algoritmo que TicketESCPOS)
        // ═══════════════════════════════════════════════════════════════════════

        private static string Sep() => new string('-', W);

        // Centra el texto en w caracteres con padding simétrico izq+der
        // → la línea siempre mide exactamente w chars, sin espacio vacío al final
        private static string Center(string s, int w)
        {
            if (s == null) s = "";
            if (s.Length >= w) return s.Substring(0, w);
            int total    = w - s.Length;
            int leftPad  = total / 2;
            int rightPad = total - leftPad;
            return new string(' ', leftPad) + s + new string(' ', rightPad);
        }

        // Rellena con espacios a la derecha hasta w (para líneas Fecha/Cliente)
        // → la línea siempre mide exactamente w chars
        private static string TruncLeft(string s, int w)
        {
            if (s == null) s = "";
            if (s.Length > w) return s.Substring(0, w);
            return s.PadRight(w);
        }

        // Dos columnas: izquierda + espacios + derecha = W chars.
        // Si no cabe, trunca left para dar espacio a right (evita corte de right).
        private static string TwoColumns(string left, string right)
        {
            if (left  == null) left  = "";
            if (right == null) right = "";
            int spaces = W - left.Length - right.Length;
            if (spaces < 1)
            {
                int maxLeft = W - right.Length - 1;
                if (maxLeft < 0) maxLeft = 0;
                left   = left.Length > maxLeft ? left.Substring(0, maxLeft) : left;
                spaces = 1;
            }
            return left + new string(' ', spaces) + right;
        }

        // 4 columnas: Desc(21,izq) | Ud.(5,centrado) | Cant.(6,der) | Total(10,der) = 42
        // SIEMPRE UNA LÍNEA: descripción se trunca a 21 si es más larga.
        // Ud. y datos van siempre en la misma línea → nunca se desplazan a una segunda fila.
        // CenterPad en Ud.: "Ud." y "kg" ambos arrancan en pos 1 del slot → alineados.
        private static string FormatColumns(string col1, string col2, string col3, string col4)
        {
            return PadRight(col1, 21) + CenterPad(col2, 5) + PadLeft(col3, 6) + PadLeft(col4, 10);
        }

        // Fila de producto: siempre una sola línea.
        // PadRight trunca descripción a 21 si supera ese ancho.
        private static void FormatProductRow(StringBuilder sb, string producto, string presentacion, string cantidad, string subtotal)
        {
            if (producto     == null) producto     = "";
            if (presentacion == null) presentacion = "";
            sb.AppendLine(PadRight(producto, 21) + CenterPad(presentacion, 5) + PadLeft(cantidad, 6) + PadLeft(subtotal, 10));
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

        // Centra s en un campo de w chars; el centro del texto queda siempre alineado
        // independientemente del largo de s (e.g. "Ud." y "kg" comparten el mismo centro).
        private static string CenterPad(string s, int w)
        {
            if (s == null) s = "";
            if (s.Length >= w) return s.Substring(0, w);
            int pad   = w - s.Length;
            int left  = pad / 2;
            int right = pad - left;
            return new string(' ', left) + s + new string(' ', right);
        }

        // ── Completar parámetros de empresa desde BD si faltan ─────────────────
        private static void CompletarEmpresa(Dictionary<string, string> p)
        {
            if (p == null) return;
            bool fN = !p.ContainsKey("pEmpresaNombre")   || string.IsNullOrWhiteSpace(p["pEmpresaNombre"]);
            bool fR = !p.ContainsKey("pEmpresaRUC")       || string.IsNullOrWhiteSpace(p["pEmpresaRUC"]);
            bool fD = !p.ContainsKey("pEmpresaDireccion") || string.IsNullOrWhiteSpace(p["pEmpresaDireccion"]);
            bool fT = !p.ContainsKey("pEmpresaTelefono")  || string.IsNullOrWhiteSpace(p["pEmpresaTelefono"]);
            bool fE = !p.ContainsKey("pEmpresaEmail")     || string.IsNullOrWhiteSpace(p["pEmpresaEmail"]);
            if (!fN && !fR && !fD && !fT && !fE) return;
            try
            {
                var emp = EmpresaRepository.ObtenerEmpresa();
                if (emp == null) return;
                string nombre = !string.IsNullOrWhiteSpace(emp.NombreComercial)
                    ? emp.NombreComercial : (emp.RazonSocial ?? "");
                if (fN) p["pEmpresaNombre"]    = nombre;
                if (fR) p["pEmpresaRUC"]       = emp.RUC      ?? "";
                if (fD) p["pEmpresaDireccion"] = emp.Direccion ?? "";
                if (fT) p["pEmpresaTelefono"]  = emp.Telefono  ?? "";
                if (fE) p["pEmpresaEmail"]     = emp.Email     ?? "";
            }
            catch { }
        }

        private static string Get(Dictionary<string, string> p, string k, string def = "")
        {
            string v;
            return p != null && p.TryGetValue(k, out v) && v != null ? v : def;
        }

        private static string FormatMoney(string raw)
        {
            raw = raw?.Trim() ?? "0.00";
            if (raw == "" || raw == "0" || raw == "0.00") return "S/0.00";
            return raw.StartsWith("S/") ? raw : "S/" + raw;
        }
    }
}
