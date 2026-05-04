using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;

namespace SistemaPOS.Forms.Configuracion
{
    public partial class FormEmpresa : Form
    {
        private Empresa _empresa;
        private ConfiguracionFacturacion _configFacturacion;
        private byte[] _logoActual;
        private bool _claveVisible = false;
        private bool _chipHovered  = false;

        public FormEmpresa()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            ConfigurarEventos();
            ConfigurarControles();
            CargarDatos();
        }

        private void ConfigurarEventos()
        {
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            btnCargar.Click += BtnCargar_Click;
            btnQuitar.Click += BtnQuitar_Click;
            btnBuscarRUC.Click += BtnBuscarRUC_Click;
            btnMostrarClave.Click += BtnMostrarClave_Click;
            cmbMoneda.SelectedIndexChanged += CmbMoneda_SelectedIndexChanged;
            txtRUC.KeyPress += TxtRUC_KeyPress;
            txtTelefono.KeyPress += TxtTelefono_KeyPress;

            // Live preview in sidebar
            txtNombre.TextChanged += (s, ev) => ActualizarPreview();
            txtRUC.TextChanged    += (s, ev) => ActualizarPreview();

            // Ctrl+S shortcut
            this.KeyDown += (s, ev) =>
            {
                if (ev.Control && ev.KeyCode == Keys.S)
                    BtnGuardar_Click(s, ev);
            };
        }

        private void ActualizarPreview()
        {
            lblPreviewNombre.Text = string.IsNullOrWhiteSpace(txtNombre.Text)
                ? "Nombre del negocio"
                : txtNombre.Text.Trim();
            lblPreviewRUC.Text = string.IsNullOrWhiteSpace(txtRUC.Text)
                ? "RUC: —"
                : $"RUC: {txtRUC.Text.Trim()}";
            pnlCompanyChip?.Invalidate();
        }

        private void ConfigurarControles()
        {
            // Configurar PictureBox para el logo
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.BorderStyle = BorderStyle.FixedSingle;
            pbLogo.BackColor = Color.White;

            // Configurar ComboBox de moneda
            cmbMoneda.Items.Clear();
            cmbMoneda.Items.Add("PEN - Soles");
            cmbMoneda.Items.Add("USD - Dólares");
            cmbMoneda.Items.Add("EUR - Euros");
            cmbMoneda.SelectedIndex = 0;

            // Configurar campo de clave
            txtClaveSOL.PasswordChar = '*';

            // Limitar longitud de campos
            txtRUC.MaxLength = 11;
            txtTelefono.MaxLength = 20;
            txtSerieNV.MaxLength = 4;
            txtNumeroNV.MaxLength = 8;
            txtSerieB.MaxLength = 4;
            txtNumeroB.MaxLength = 8;
            txtSerieF.MaxLength = 4;
            txtNumeroF.MaxLength = 8;
        }

        private void CargarDatos()
        {
            try
            {
                // Cargar datos de empresa
                _empresa = EmpresaRepository.ObtenerEmpresa();
                if (_empresa == null)
                {
                    _empresa = new Empresa();
                }

                // Cargar configuración de facturación
                _configFacturacion = EmpresaRepository.ObtenerConfiguracionFacturacion();

                // Mostrar datos de empresa
                txtRUC.Text = _empresa.RUC ?? "";
                // Preferir NombreComercial si existe; si no, mostrar RazonSocial
                string nombreDisplay = !string.IsNullOrWhiteSpace(_empresa.NombreComercial)
                    ? _empresa.NombreComercial
                    : (_empresa.RazonSocial ?? "");
                txtNombre.Text = nombreDisplay;
                txtDireccion.Text = _empresa.Direccion ?? "";
                txtTelefono.Text = _empresa.Telefono ?? "";
                txtEmail.Text = _empresa.Email ?? "";
                txtSitioWeb.Text = _empresa.Web ?? "";

                // Cargar logo
                _logoActual = _empresa.Logo;
                MostrarLogo();

                // Mostrar configuración de moneda
                switch (_configFacturacion.Moneda)
                {
                    case "PEN":
                        cmbMoneda.SelectedIndex = 0;
                        break;
                    case "USD":
                        cmbMoneda.SelectedIndex = 1;
                        break;
                    case "EUR":
                        cmbMoneda.SelectedIndex = 2;
                        break;
                    default:
                        cmbMoneda.SelectedIndex = 0;
                        break;
                }
                txtSimbolo.Text = _configFacturacion.SimboloMoneda ?? "S/";

                // Mostrar datos de facturación
                txtUsuarioSOL.Text = _configFacturacion.UsuarioSOL ?? "";
                txtClaveSOL.Text = _configFacturacion.ClaveSOL ?? "";

                // Series y correlativos
                txtSerieNV.Text = _configFacturacion.SerieNotaVenta ?? "NV01";
                txtNumeroNV.Text = _configFacturacion.CorrelativoNotaVenta.ToString().PadLeft(8, '0');
                txtSerieB.Text = _configFacturacion.SerieBoleta ?? "B001";
                txtNumeroB.Text = _configFacturacion.CorrelativoBoleta.ToString().PadLeft(8, '0');
                txtSerieF.Text = _configFacturacion.SerieFactura ?? "F001";
                txtNumeroF.Text = _configFacturacion.CorrelativoFactura.ToString().PadLeft(8, '0');

                ActualizarPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarLogo()
        {
            var old = pbLogo.Image;
            pbLogo.Image = null;
            old?.Dispose();

            if (_logoActual != null && _logoActual.Length > 0)
            {
                try
                {
                    // Renderizar en un Bitmap independiente (sin dependencia del stream)
                    // para evitar el lazy-decoding de GDI+ sobre un stream ya cerrado.
                    Bitmap standalone;
                    using (var ms = new MemoryStream(_logoActual))
                    using (var tmp = Image.FromStream(ms, false, false))
                    {
                        standalone = new Bitmap(tmp.Width, tmp.Height, PixelFormat.Format32bppArgb);
                        using (var g = Graphics.FromImage(standalone))
                            g.DrawImage(tmp, 0, 0, tmp.Width, tmp.Height);
                    }
                    pbLogo.Image = standalone;
                }
                catch
                {
                    pbLogo.Image = null;
                }
            }

            pbLogo.Invalidate();
        }

        private bool ValidarFormulario()
        {
            // Validar RUC
            if (string.IsNullOrWhiteSpace(txtRUC.Text))
            {
                MessageBox.Show("Ingrese el RUC de la empresa", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRUC.Focus();
                return false;
            }

            if (txtRUC.Text.Trim().Length != 11)
            {
                MessageBox.Show("El RUC debe tener 11 dígitos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRUC.Focus();
                return false;
            }

            // Validar nombre del negocio
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del negocio o razón social", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            // Validar email si está ingresado
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    MessageBox.Show("El email ingresado no es válido", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }

            // Validar series de comprobantes
            if (string.IsNullOrWhiteSpace(txtSerieNV.Text))
            {
                MessageBox.Show("Ingrese la serie para Nota de Venta", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSerieNV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSerieB.Text))
            {
                MessageBox.Show("Ingrese la serie para Boleta", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSerieB.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSerieF.Text))
            {
                MessageBox.Show("Ingrese la serie para Factura", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSerieF.Focus();
                return false;
            }

            return true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                // Guardar datos de empresa
                _empresa.RUC = txtRUC.Text.Trim();
                _empresa.RazonSocial = txtNombre.Text.Trim();
                _empresa.NombreComercial = txtNombre.Text.Trim();
                _empresa.Direccion = txtDireccion.Text.Trim();
                _empresa.Telefono = txtTelefono.Text.Trim();
                _empresa.Email = txtEmail.Text.Trim();
                _empresa.Web = txtSitioWeb.Text.Trim();
                _empresa.Logo = _logoActual;

                if (!EmpresaRepository.GuardarEmpresa(_empresa))
                {
                    MessageBox.Show("No se pudo guardar los datos de la empresa", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Guardar configuración de facturación
                string monedaCodigo = "PEN";
                switch (cmbMoneda.SelectedIndex)
                {
                    case 0: monedaCodigo = "PEN"; break;
                    case 1: monedaCodigo = "USD"; break;
                    case 2: monedaCodigo = "EUR"; break;
                }

                _configFacturacion.Moneda = monedaCodigo;
                _configFacturacion.SimboloMoneda = txtSimbolo.Text.Trim();
                _configFacturacion.UsuarioSOL = txtUsuarioSOL.Text.Trim();
                _configFacturacion.ClaveSOL = txtClaveSOL.Text.Trim();
                _configFacturacion.SerieNotaVenta = txtSerieNV.Text.Trim().ToUpper();
                _configFacturacion.CorrelativoNotaVenta = int.TryParse(txtNumeroNV.Text.Trim(), out int nvCorr) ? nvCorr : 0;
                _configFacturacion.SerieBoleta = txtSerieB.Text.Trim().ToUpper();
                _configFacturacion.CorrelativoBoleta = int.TryParse(txtNumeroB.Text.Trim(), out int bCorr) ? bCorr : 0;
                _configFacturacion.SerieFactura = txtSerieF.Text.Trim().ToUpper();
                _configFacturacion.CorrelativoFactura = int.TryParse(txtNumeroF.Text.Trim(), out int fCorr) ? fCorr : 0;

                if (!EmpresaRepository.GuardarConfiguracionFacturacion(_configFacturacion))
                {
                    MessageBox.Show("No se pudo guardar la configuración de facturación", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Datos guardados exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Desea descartar los cambios realizados?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CargarDatos();
            }
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            using (var openDialog = new OpenFileDialog())
            {
                openDialog.Title = "Seleccionar Logo";
                openDialog.Filter = "Imágenes|*.png;*.jpg;*.jpeg;*.bmp;*.gif|Todos los archivos|*.*";
                openDialog.FilterIndex = 1;

                if (openDialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    byte[] fileBytes = File.ReadAllBytes(openDialog.FileName);
                    _logoActual = NormalizarLogoParaTicket(fileBytes);
                    MostrarLogo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static byte[] NormalizarLogoParaTicket(byte[] fileBytes)
        {
            const int maxW = 576, maxH = 400;

            // Stream debe vivir durante todo el DrawImage (GDI+ lazy-decode de PNG/GIF/TIFF).
            using (var fileMs = new MemoryStream(fileBytes))
            using (var img = Image.FromStream(fileMs, false, false))
            {
                double scale = 1.0;
                if (img.Width > maxW || img.Height > maxH)
                    scale = Math.Min((double)maxW / img.Width, (double)maxH / img.Height);

                int w = Math.Max(1, (int)Math.Round(img.Width  * scale));
                int h = Math.Max(1, (int)Math.Round(img.Height * scale));

                using (var bmp = new Bitmap(w, h, PixelFormat.Format32bppArgb))
                {
                    using (var g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.White);
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode     = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        g.DrawImage(img, 0, 0, w, h);
                    }
                    using (var outMs = new MemoryStream())
                    {
                        bmp.Save(outMs, ImageFormat.Png);
                        return outMs.ToArray();
                    }
                }
            }
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            if (_logoActual == null || _logoActual.Length == 0)
                return;

            var result = MessageBox.Show("¿Desea quitar el logo actual?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _logoActual = null;
                pbLogo.Image = null;
            }
        }

        private void BtnBuscarRUC_Click(object sender, EventArgs e)
        {
            // Funcionalidad de búsqueda en SUNAT - próximamente
            MessageBox.Show("Consulta SUNAT próximamente disponible.\n\n" +
                "Por ahora, ingrese los datos manualmente.",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnMostrarClave_Click(object sender, EventArgs e)
        {
            _claveVisible = !_claveVisible;
            txtClaveSOL.PasswordChar = _claveVisible ? '\0' : '*';
            btnMostrarClave.Text = _claveVisible ? "🔒" : "👁";
        }

        private void CmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbMoneda.SelectedIndex)
            {
                case 0: // PEN
                    txtSimbolo.Text = "S/";
                    break;
                case 1: // USD
                    txtSimbolo.Text = "$";
                    break;
                case 2: // EUR
                    txtSimbolo.Text = "€";
                    break;
            }
        }

        private void TxtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir números
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, +, -, (, ), espacios
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '(' &&
                e.KeyChar != ')' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        // ── Paint handlers (movidos desde Designer.cs) ────────────────────────

        private void PbLogo_Paint(object sender, System.Windows.Forms.PaintEventArgs pe)
        {
            var pb = (System.Windows.Forms.PictureBox)sender;
            if (pb.Image != null) return;
            var g = pe.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int cx = pb.Width / 2, cy = pb.Height / 2 - 10;
            var ir = new System.Drawing.Rectangle(cx - 26, cy - 22, 52, 42);
            using (var br = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(224, 231, 255)))
                g.FillRectangle(br, ir);
            using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(165, 180, 252), 1.5f))
                g.DrawRectangle(pen, ir);
            var sf = new System.Drawing.StringFormat
            {
                Alignment     = System.Drawing.StringAlignment.Center,
                LineAlignment = System.Drawing.StringAlignment.Center
            };
            using (var f  = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold))
            using (var b  = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(99, 102, 241)))
                g.DrawString("LOGO", f, b, new System.Drawing.RectangleF(0, cy + 28, pb.Width, 16), sf);
            using (var f2 = new System.Drawing.Font("Segoe UI", 7.5F))
            using (var b2 = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(148, 163, 184)))
                g.DrawString("Clic para cargar", f2, b2, new System.Drawing.RectangleF(0, cy + 44, pb.Width, 14), sf);
        }

        private void PbLogo_Click(object sender, EventArgs e)
        {
            btnCargar.PerformClick();
        }

        private void PnlPreview_Paint(object sender, System.Windows.Forms.PaintEventArgs pe)
        {
            var p = (System.Windows.Forms.Panel)sender;
            pe.Graphics.DrawRectangle(
                new System.Drawing.Pen(System.Drawing.Color.FromArgb(203, 213, 225)),
                0, 0, p.Width - 1, p.Height - 1);
        }

        private void PnlSOLNote_Paint(object sender, System.Windows.Forms.PaintEventArgs pe)
        {
            var p = (System.Windows.Forms.Panel)sender;
            pe.Graphics.DrawRectangle(
                new System.Drawing.Pen(System.Drawing.Color.FromArgb(253, 230, 138)),
                0, 0, p.Width - 1, p.Height - 1);
        }

        private void PnlTableHdrRow_Paint(object sender, System.Windows.Forms.PaintEventArgs pe)
        {
            var p = (System.Windows.Forms.Panel)sender;
            pe.Graphics.DrawLine(
                new System.Drawing.Pen(System.Drawing.Color.FromArgb(226, 232, 240)),
                0, p.Height - 1, p.Width, p.Height - 1);
        }

        private void PnlSeriesInfo_Paint(object sender, System.Windows.Forms.PaintEventArgs pe)
        {
            var p = (System.Windows.Forms.Panel)sender;
            pe.Graphics.DrawRectangle(
                new System.Drawing.Pen(System.Drawing.Color.FromArgb(196, 181, 253)),
                0, 0, p.Width - 1, p.Height - 1);
        }

        // ── Company Avatar Chip ───────────────────────────────────────────────

        private void PnlCompanyChip_MouseEnter(object sender, EventArgs e)
        {
            _chipHovered = true;
            pnlCompanyChip.Invalidate();
        }

        private void PnlCompanyChip_MouseLeave(object sender, EventArgs e)
        {
            _chipHovered = false;
            pnlCompanyChip.Invalidate();
        }

        private void PnlCompanyChip_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var p = (System.Windows.Forms.Panel)sender;
            var g = e.Graphics;
            g.SmoothingMode   = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            var rect   = new Rectangle(0, 0, p.Width - 1, p.Height - 1);
            int radius = p.Height / 2;

            // ── Pill background ──────────────────────────────────────────────
            var bgColor     = _chipHovered ? Color.FromArgb(45, 55, 72) : Color.FromArgb(28, 38, 58);
            var borderColor = _chipHovered ? Color.FromArgb(99, 102, 241) : Color.FromArgb(51, 65, 85);

            using (var path = ChipRoundedPath(rect, radius))
            {
                using (var br = new SolidBrush(bgColor))
                    g.FillPath(br, path);
                using (var pen = new Pen(borderColor, _chipHovered ? 1.5f : 1f))
                    g.DrawPath(pen, path);
            }

            // ── Avatar circle (izquierda) ────────────────────────────────────
            int circleSize = 28;
            int circleX    = 6;
            int circleY    = (p.Height - circleSize) / 2;

            // Sombra sutil del círculo
            using (var shadowBr = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
                g.FillEllipse(shadowBr, circleX + 1, circleY + 1, circleSize, circleSize);

            // Fondo del círculo (índigo)
            using (var circleBr = new SolidBrush(_chipHovered
                ? Color.FromArgb(124, 58, 237)
                : Color.FromArgb(99, 102, 241)))
                g.FillEllipse(circleBr, circleX, circleY, circleSize, circleSize);

            // Borde del círculo
            using (var borderPen = new Pen(Color.FromArgb(255, 255, 255, 30), 1f))
                g.DrawEllipse(borderPen, circleX, circleY, circleSize - 1, circleSize - 1);

            // Inicial de la empresa dentro del círculo
            string initial = ObtenerInicialEmpresa();
            using (var f  = new Font("Segoe UI", 11f, FontStyle.Bold))
            using (var br = new SolidBrush(Color.White))
            {
                var sf = new StringFormat
                {
                    Alignment     = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(initial, f, br,
                    new RectangleF(circleX, circleY, circleSize, circleSize), sf);
            }

            // ── Nombre de la empresa ─────────────────────────────────────────
            string name = txtNombre?.Text?.Trim();
            if (string.IsNullOrWhiteSpace(name)) name = "Mi Empresa";
            if (name.Length > 17) name = name.Substring(0, 15) + "…";

            using (var nameFt = new Font("Segoe UI", 8.5f, FontStyle.Regular))
            using (var nameBr = new SolidBrush(Color.FromArgb(226, 232, 240)))
            {
                var sf = new StringFormat { LineAlignment = StringAlignment.Center };
                float textX = circleX + circleSize + 8;
                float textW = p.Width - textX - 22;
                g.DrawString(name, nameFt, nameBr,
                    new RectangleF(textX, 0, textW, p.Height), sf);
            }

            // ── Chevron ▾ ────────────────────────────────────────────────────
            int cx = p.Width - 13;
            int cy = p.Height / 2;
            using (var chevronPen = new Pen(Color.FromArgb(148, 163, 184), 1.5f)
                { StartCap = LineCap.Round, EndCap = LineCap.Round })
            {
                g.DrawLine(chevronPen, cx - 4, cy - 2, cx, cy + 3);
                g.DrawLine(chevronPen, cx,     cy + 3, cx + 4, cy - 2);
            }
        }

        private string ObtenerInicialEmpresa()
        {
            string name = txtNombre?.Text?.Trim();
            if (string.IsNullOrWhiteSpace(name)) return "E";
            return name[0].ToString().ToUpper();
        }

        private static GraphicsPath ChipRoundedPath(Rectangle rect, int radius)
        {
            int d = Math.Min(radius * 2, Math.Min(rect.Width, rect.Height));
            var path = new GraphicsPath();
            path.AddArc(rect.X,           rect.Y,           d, d, 180, 90);
            path.AddArc(rect.Right - d,   rect.Y,           d, d, 270, 90);
            path.AddArc(rect.Right - d,   rect.Bottom - d,  d, d,   0, 90);
            path.AddArc(rect.X,           rect.Bottom - d,  d, d,  90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
