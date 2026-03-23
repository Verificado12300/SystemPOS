using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;

namespace SistemaPOS.Forms.Configuracion
{
    public partial class FormImpresoras : Form
    {
        private bool _cargandoDatos;
        private SistemaPOS.Controls.TicketPreviewControl _ticketPreview;

        public FormImpresoras()
        {
            InitializeComponent();
            AplicarTemaDashboard();
            InicializarPanelPreview();
            ConfigurarEventos();
            _cargandoDatos = true;   // evitar renders parciales al setear defaults
            ConfigurarControles();
            _cargandoDatos = false;
            CargarImpresoras();
            CargarDatos();
        }

        private void AplicarTemaDashboard()
        {
            Color fondo = Color.FromArgb(244, 244, 250);
            Color textoPrincipal = Color.FromArgb(45, 52, 54);
            Color textoSecundario = Color.FromArgb(127, 140, 141);
            Color bordeTarjeta = Color.FromArgb(223, 228, 234);

            BackColor = fondo;

            EstilizarTarjeta(pnlImpresora, bordeTarjeta);
            EstilizarTarjeta(pnlContenidoTicket, bordeTarjeta);
            EstilizarTarjeta(pnlOpcionesImpresion, bordeTarjeta);
            EstilizarTarjeta(pnlVistaTicket, bordeTarjeta);

            lblTitulo.ForeColor = textoPrincipal;
            lblVistaPrevia.ForeColor = textoPrincipal;

            EstilizarBotonPrimario(btnGuardarConfiguracion);
            EstilizarBotonSecundario(btnImprimirPrueba);
            EstilizarBotonSecundario(btnConfigurarImpresora);

            EstilizarControlesPanel(pnlImpresora, textoPrincipal, textoSecundario);
            EstilizarControlesPanel(pnlContenidoTicket, textoPrincipal, textoSecundario);
            EstilizarControlesPanel(pnlOpcionesImpresion, textoPrincipal, textoSecundario);
        }

        private static void EstilizarTarjeta(Panel panel, Color borde)
        {
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
        }

        private static void EstilizarBotonPrimario(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.BackColor = Color.FromArgb(46, 134, 222);
            boton.ForeColor = Color.White;
        }

        private static void EstilizarBotonSecundario(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderColor = Color.FromArgb(223, 228, 234);
            boton.FlatAppearance.BorderSize = 1;
            boton.BackColor = Color.White;
            boton.ForeColor = Color.FromArgb(45, 52, 54);
        }

        private static void EstilizarControlesPanel(Control root, Color textoPrincipal, Color textoSecundario)
        {
            foreach (Control c in root.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.ForeColor = lbl.Font.Bold ? textoPrincipal : textoSecundario;
                }
                else if (c is CheckBox chk)
                {
                    chk.FlatStyle = FlatStyle.Flat;
                    chk.ForeColor = textoPrincipal;
                }
                else if (c is ComboBox cmb)
                {
                    cmb.FlatStyle = FlatStyle.Flat;
                    cmb.BackColor = Color.White;
                    cmb.ForeColor = textoPrincipal;
                }
                else if (c is TextBox txt)
                {
                    txt.BackColor = Color.White;
                    txt.ForeColor = textoPrincipal;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (c is NumericUpDown nud)
                {
                    nud.BackColor = Color.White;
                    nud.ForeColor = textoPrincipal;
                    nud.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }

        private void InicializarPanelPreview()
        {
            // Limpiar TODOS los controles del Designer que estaban en pnlVistaTicket
            // (el Designer original tenía ~35 labels/picturebox propios del ticket).
            // Ahora la única fuente visual es TicketPreviewControl.
            pnlVistaTicket.Controls.Clear();

            _ticketPreview = new SistemaPOS.Controls.TicketPreviewControl
            {
                Location = new Point(0, 0)
            };
            pnlVistaTicket.Controls.Add(_ticketPreview);
            pnlVistaTicket.AutoScroll = true;
        }

        private void ConfigurarEventos()
        {
            btnConfigurarImpresora.Click += BtnConfigurarImpresora_Click;
            btnImprimirPrueba.Click += BtnImprimirPrueba_Click;
            btnGuardarConfiguracion.Click += BtnGuardarConfiguracion_Click;
            cmbImpresoraPredeterminada.SelectedIndexChanged += ConfiguracionCambiada;

            // Eventos de contenido del ticket (Nombre siempre visible — sin evento)
            chkMostrarLogo.CheckedChanged += ConfiguracionCambiada;
            chkMostrarRUC.CheckedChanged += ConfiguracionCambiada;
            chkMostrarDireccion.CheckedChanged += ConfiguracionCambiada;
            chkMostrarTelefono.CheckedChanged += ConfiguracionCambiada;
            chkMostrarEmail.CheckedChanged += ConfiguracionCambiada;
            chkMostrarQR.CheckedChanged += ConfiguracionCambiada;
            chkMostrarInfoPago.CheckedChanged += ConfiguracionCambiada;
            chkMostrarDNI.CheckedChanged += ConfiguracionCambiada;
            chkMostrarPie.CheckedChanged += ConfiguracionCambiada;
            txtMensajePie1.TextChanged += ConfiguracionCambiada;
            txtMensajePie2.TextChanged += ConfiguracionCambiada;

            // Eventos de opciones de impresion
            cmbNumeroCopias.SelectedIndexChanged += ConfiguracionCambiada;
            tbDensidad.ValueChanged += ConfiguracionCambiada;
            chkCortaPapel.CheckedChanged += ConfiguracionCambiada;
            chkSonidoImprimir.CheckedChanged += ConfiguracionCambiada;
            cmbEspaciadoLineas.SelectedIndexChanged += ConfiguracionCambiada;
            cmbAnchoPapel.SelectedIndexChanged += CmbAnchoPapel_SelectedIndexChanged;
            nudAnchoPersonalizado.ValueChanged += ConfiguracionCambiada;
            nudEscalaAjuste.ValueChanged += ConfiguracionCambiada;
            nudMargenIzquierdo.ValueChanged += ConfiguracionCambiada;
            nudMargenDerecho.ValueChanged += ConfiguracionCambiada;
            nudMargenSuperior.ValueChanged += ConfiguracionCambiada;
            nudMargenInferior.ValueChanged += ConfiguracionCambiada;
        }

        private void ConfigurarControles()
        {
            // Configurar numero de copias
            cmbNumeroCopias.Items.Clear();
            for (int i = 1; i <= 5; i++)
            {
                cmbNumeroCopias.Items.Add(i.ToString());
            }
            cmbNumeroCopias.SelectedIndex = 0;

            // Configurar ancho de papel
            cmbAnchoPapel.Items.Clear();
            cmbAnchoPapel.Items.Add("58 mm");
            cmbAnchoPapel.Items.Add("88 mm");
            cmbAnchoPapel.Items.Add("Personalizado");
            cmbAnchoPapel.SelectedIndex = 1;
            nudAnchoPersonalizado.Minimum = 1;
            nudAnchoPersonalizado.Maximum = 100;
            nudAnchoPersonalizado.Value = 88;
            nudAnchoPersonalizado.Enabled = false;

            // Configurar densidad
            tbDensidad.Minimum = 1;
            tbDensidad.Maximum = 10;
            tbDensidad.Value = 5;

            // Configurar espaciado
            cmbEspaciadoLineas.Items.Clear();
            cmbEspaciadoLineas.Items.Add("Compacto");
            cmbEspaciadoLineas.Items.Add("Normal");
            cmbEspaciadoLineas.Items.Add("Amplio");
            cmbEspaciadoLineas.SelectedIndex = 1;
            nudEscalaAjuste.Minimum = -50;
            nudEscalaAjuste.Maximum = 50;
            nudEscalaAjuste.Value = 0;
            nudMargenIzquierdo.Minimum = 0;
            nudMargenIzquierdo.Maximum = 20;
            nudMargenDerecho.Minimum = 0;
            nudMargenDerecho.Maximum = 20;
            nudMargenSuperior.Minimum = 0;
            nudMargenSuperior.Maximum = 20;
            nudMargenInferior.Minimum = 0;
            nudMargenInferior.Maximum = 20;
            nudMargenIzquierdo.Value = 0;
            nudMargenDerecho.Value = 0;
            nudMargenSuperior.Value = 0;
            nudMargenInferior.Value = 0;

            // Nombre empresa: siempre visible — el checkbox no debe aparecer
            chkMostrarNombre.Visible = false;
            chkMostrarNombre.Checked = true;


            // Valores por defecto
            chkMostrarLogo.Checked = true;
            chkMostrarRUC.Checked = true;
            chkMostrarDireccion.Checked = true;
            chkMostrarTelefono.Checked = true;
            chkMostrarEmail.Checked = false;
            chkMostrarQR.Checked = false;
            chkMostrarQR.Text = "Mostrar Codigo QR (Negocio)";
            chkMostrarInfoPago.Checked = true;
            chkMostrarDNI.Checked = true;
            chkMostrarPie.Checked = true;
            chkCortaPapel.Checked = true;
            chkSonidoImprimir.Checked = true;

            txtMensajePie1.Text = "Gracias por su compra";
            txtMensajePie2.Text = "Vuelva pronto";
        }

        private void CargarImpresoras()
        {
            cmbImpresoraPredeterminada.Items.Clear();

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                cmbImpresoraPredeterminada.Items.Add(printer);
            }

            // Seleccionar impresora guardada o la predeterminada del sistema
            string impresoraGuardada = EmpresaRepository.ObtenerConfiguracion("IMPRESORA_PREDETERMINADA", "");

            if (!string.IsNullOrEmpty(impresoraGuardada) && cmbImpresoraPredeterminada.Items.Contains(impresoraGuardada))
            {
                cmbImpresoraPredeterminada.SelectedItem = impresoraGuardada;
            }
            else if (cmbImpresoraPredeterminada.Items.Count > 0)
            {
                // Buscar impresora predeterminada del sistema
                var settings = new PrinterSettings();
                if (cmbImpresoraPredeterminada.Items.Contains(settings.PrinterName))
                {
                    cmbImpresoraPredeterminada.SelectedItem = settings.PrinterName;
                }
                else
                {
                    cmbImpresoraPredeterminada.SelectedIndex = 0;
                }
            }
        }

        private void CargarDatos()
        {
            try
            {
                _cargandoDatos = true;

                // Cargar configuracion de contenido del ticket
                chkMostrarLogo.Checked   = EmpresaRepository.ObtenerConfiguracion("TICKET_MOSTRAR_LOGO",      "true")  == "true";
                chkMostrarNombre.Checked = true; // Nombre empresa siempre visible
                chkMostrarRUC.Checked    = EmpresaRepository.ObtenerConfiguracion("TICKET_MOSTRAR_RUC",       "true")  == "true";
                chkMostrarDireccion.Checked = EmpresaRepository.ObtenerConfiguracion("TICKET_MOSTRAR_DIRECCION", "true") == "true";
                chkMostrarTelefono.Checked = EmpresaRepository.ObtenerConfiguracion("TICKET_MOSTRAR_TELEFONO", "true") == "true";
                chkMostrarEmail.Checked = EmpresaRepository.ObtenerConfiguracion("TICKET_MOSTRAR_EMAIL", "false") == "true";
                chkMostrarQR.Checked = EmpresaRepository.ObtenerConfiguracion("TICKET_MOSTRAR_QR", "false") == "true";
                chkMostrarInfoPago.Checked = EmpresaRepository.ObtenerConfiguracion("TICKET_MOSTRAR_INFO_PAGO", "true") == "true";
                chkMostrarDNI.Checked = EmpresaRepository.ObtenerConfiguracion("TICKET_MOSTRAR_DNI", "true") == "true";
                chkMostrarPie.Checked = EmpresaRepository.ObtenerConfiguracion("TICKET_MOSTRAR_PIE", "true") == "true";

                txtMensajePie1.Text = EmpresaRepository.ObtenerConfiguracion("TICKET_PIE_LINEA1", "Gracias por su compra");
                txtMensajePie2.Text = EmpresaRepository.ObtenerConfiguracion("TICKET_PIE_LINEA2", "Vuelva pronto");

                // Cargar opciones de impresion
                string copias = EmpresaRepository.ObtenerConfiguracion("TICKET_COPIAS", "1");
                for (int i = 0; i < cmbNumeroCopias.Items.Count; i++)
                {
                    if (cmbNumeroCopias.Items[i].ToString() == copias)
                    {
                        cmbNumeroCopias.SelectedIndex = i;
                        break;
                    }
                }

                int anchoMm = LeerEnteroConfig("ANCHO_PAPEL_TICKET", 88, 1, 100);
                if (anchoMm == 58)
                {
                    cmbAnchoPapel.SelectedIndex = 0;
                }
                else if (anchoMm == 88 || anchoMm == 80)
                {
                    cmbAnchoPapel.SelectedIndex = 1;
                }
                else
                {
                    cmbAnchoPapel.SelectedIndex = 2;
                    nudAnchoPersonalizado.Value = anchoMm;
                }
                CmbAnchoPapel_SelectedIndexChanged(null, EventArgs.Empty);

                int densidad = int.Parse(EmpresaRepository.ObtenerConfiguracion("TICKET_DENSIDAD", "5"));
                tbDensidad.Value = Math.Max(tbDensidad.Minimum, Math.Min(tbDensidad.Maximum, densidad));

                chkCortaPapel.Checked = EmpresaRepository.ObtenerConfiguracion("TICKET_CORTAR_PAPEL", "true") == "true";
                chkSonidoImprimir.Checked = EmpresaRepository.ObtenerConfiguracion("TICKET_SONIDO", "true") == "true";

                string espaciado = EmpresaRepository.ObtenerConfiguracion("TICKET_ESPACIADO", "Normal");
                for (int i = 0; i < cmbEspaciadoLineas.Items.Count; i++)
                {
                    if (cmbEspaciadoLineas.Items[i].ToString() == espaciado)
                    {
                        cmbEspaciadoLineas.SelectedIndex = i;
                        break;
                    }
                }

                nudEscalaAjuste.Value = LeerEnteroConfig("TICKET_ESCALA_AJUSTE", 0, (int)nudEscalaAjuste.Minimum, (int)nudEscalaAjuste.Maximum);
                nudMargenIzquierdo.Value = LeerEnteroConfig("TICKET_MARGEN_IZQ_MM", 0, (int)nudMargenIzquierdo.Minimum, (int)nudMargenIzquierdo.Maximum);
                nudMargenDerecho.Value = LeerEnteroConfig("TICKET_MARGEN_DER_MM", 0, (int)nudMargenDerecho.Minimum, (int)nudMargenDerecho.Maximum);
                nudMargenSuperior.Value = LeerEnteroConfig("TICKET_MARGEN_SUP_MM", 0, (int)nudMargenSuperior.Minimum, (int)nudMargenSuperior.Maximum);
                nudMargenInferior.Value = LeerEnteroConfig("TICKET_MARGEN_INF_MM", 0, (int)nudMargenInferior.Minimum, (int)nudMargenInferior.Maximum);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar configuracion: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _cargandoDatos = false;
            }
        }

        private void ConfiguracionCambiada(object sender, EventArgs e)
        {
            if (_cargandoDatos)
            {
                return;
            }

            ActualizarVistaPrevia();
        }

        private void ActualizarVistaPrevia()
        {
            if (_cargandoDatos) return;
            bool hasPie = chkMostrarPie.Checked && !string.IsNullOrWhiteSpace(txtMensajePie1.Text);
            var config = new TicketConfig
            {
                MostrarLogo      = chkMostrarLogo.Checked,
                MostrarRUC       = chkMostrarRUC.Checked,
                MostrarDireccion = chkMostrarDireccion.Checked,
                MostrarTelefono  = chkMostrarTelefono.Checked,
                MostrarEmail     = chkMostrarEmail.Checked,
                MostrarDNI       = chkMostrarDNI.Checked,
                MostrarInfoPago  = chkMostrarInfoPago.Checked,
                MostrarPie       = hasPie,
                MostrarQR        = chkMostrarQR.Checked,
                MensajePie       = txtMensajePie1.Text,
            };
            _ticketPreview.LlenarDatosDemo(config);
        }


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ActualizarVistaPrevia();
        }

        private void GuardarConfiguracion()
        {
            try
            {
                // Guardar impresora predeterminada
                EmpresaRepository.GuardarConfiguracion("IMPRESORA_PREDETERMINADA",
                    cmbImpresoraPredeterminada.SelectedItem?.ToString() ?? "", "STRING", "Impresion", "Impresora predeterminada");

                // Guardar contenido del ticket
                EmpresaRepository.GuardarConfiguracion("TICKET_MOSTRAR_LOGO",    chkMostrarLogo.Checked   ? "true" : "false", "BOOLEAN", "Impresion", "Mostrar logo en ticket");
                EmpresaRepository.GuardarConfiguracion("TICKET_MOSTRAR_NOMBRE", "true",                                       "BOOLEAN", "Impresion", "Mostrar nombre en ticket");
                EmpresaRepository.GuardarConfiguracion("TICKET_MOSTRAR_RUC",    chkMostrarRUC.Checked    ? "true" : "false", "BOOLEAN", "Impresion", "Mostrar RUC en ticket");
                EmpresaRepository.GuardarConfiguracion("TICKET_MOSTRAR_DIRECCION", chkMostrarDireccion.Checked ? "true" : "false", "BOOLEAN", "Impresion", "Mostrar direccion en ticket");
                EmpresaRepository.GuardarConfiguracion("TICKET_MOSTRAR_TELEFONO", chkMostrarTelefono.Checked ? "true" : "false", "BOOLEAN", "Impresion", "Mostrar telefono en ticket");
                EmpresaRepository.GuardarConfiguracion("TICKET_MOSTRAR_EMAIL", chkMostrarEmail.Checked ? "true" : "false", "BOOLEAN", "Impresion", "Mostrar email en ticket");
                EmpresaRepository.GuardarConfiguracion("TICKET_MOSTRAR_QR", chkMostrarQR.Checked ? "true" : "false", "BOOLEAN", "Impresion", "Mostrar QR en ticket");
                EmpresaRepository.GuardarConfiguracion("TICKET_MOSTRAR_INFO_PAGO", chkMostrarInfoPago.Checked ? "true" : "false", "BOOLEAN", "Impresion", "Mostrar info de pago en ticket");
                EmpresaRepository.GuardarConfiguracion("TICKET_MOSTRAR_DNI", chkMostrarDNI.Checked ? "true" : "false", "BOOLEAN", "Impresion", "Mostrar DNI del cliente en ticket");
                EmpresaRepository.GuardarConfiguracion("TICKET_MOSTRAR_PIE", chkMostrarPie.Checked ? "true" : "false", "BOOLEAN", "Impresion", "Mostrar pie de pagina en ticket");

                EmpresaRepository.GuardarConfiguracion("TICKET_PIE_LINEA1", txtMensajePie1.Text, "STRING", "Impresion", "Primera linea del pie del ticket");
                EmpresaRepository.GuardarConfiguracion("TICKET_PIE_LINEA2", txtMensajePie2.Text, "STRING", "Impresion", "Segunda linea del pie del ticket");

                // Guardar opciones de impresion
                EmpresaRepository.GuardarConfiguracion("TICKET_COPIAS", cmbNumeroCopias.SelectedItem?.ToString() ?? "1", "INTEGER", "Impresion", "Numero de copias");
                EmpresaRepository.GuardarConfiguracion("ANCHO_PAPEL_TICKET", ObtenerAnchoPapelMm().ToString(), "INTEGER", "Impresion", "Ancho del papel en mm");
                EmpresaRepository.GuardarConfiguracion("TICKET_DENSIDAD", tbDensidad.Value.ToString(), "INTEGER", "Impresion", "Densidad de impresion");
                EmpresaRepository.GuardarConfiguracion("TICKET_CORTAR_PAPEL", chkCortaPapel.Checked ? "true" : "false", "BOOLEAN", "Impresion", "Cortar papel automaticamente");
                EmpresaRepository.GuardarConfiguracion("TICKET_SONIDO", chkSonidoImprimir.Checked ? "true" : "false", "BOOLEAN", "Impresion", "Sonido al imprimir");
                EmpresaRepository.GuardarConfiguracion("TICKET_ESPACIADO", cmbEspaciadoLineas.SelectedItem?.ToString() ?? "Normal", "STRING", "Impresion", "Espaciado entre lineas");
                EmpresaRepository.GuardarConfiguracion("TICKET_ESCALA_AJUSTE", nudEscalaAjuste.Value.ToString(), "INTEGER", "Impresion", "Ajuste de escala en porcentaje");
                EmpresaRepository.GuardarConfiguracion("TICKET_MARGEN_IZQ_MM", nudMargenIzquierdo.Value.ToString(), "INTEGER", "Impresion", "Margen izquierdo en mm");
                EmpresaRepository.GuardarConfiguracion("TICKET_MARGEN_DER_MM", nudMargenDerecho.Value.ToString(), "INTEGER", "Impresion", "Margen derecho en mm");
                EmpresaRepository.GuardarConfiguracion("TICKET_MARGEN_SUP_MM", nudMargenSuperior.Value.ToString(), "INTEGER", "Impresion", "Margen superior en mm");
                EmpresaRepository.GuardarConfiguracion("TICKET_MARGEN_INF_MM", nudMargenInferior.Value.ToString(), "INTEGER", "Impresion", "Margen inferior en mm");
            }
            catch
            {
                // Silenciar errores de guardado automatico
            }
        }

        private void BtnConfigurarImpresora_Click(object sender, EventArgs e)
        {
            if (cmbImpresoraPredeterminada.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una impresora primero", "Informacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var printDialog = new PrintDialog();
                printDialog.PrinterSettings.PrinterName = cmbImpresoraPredeterminada.SelectedItem.ToString();

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    // Actualizar la impresora seleccionada si cambio
                    if (cmbImpresoraPredeterminada.Items.Contains(printDialog.PrinterSettings.PrinterName))
                    {
                        cmbImpresoraPredeterminada.SelectedItem = printDialog.PrinterSettings.PrinterName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir configuracion de impresora: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnImprimirPrueba_Click(object sender, EventArgs e)
        {
            if (cmbImpresoraPredeterminada.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una impresora primero", "Informacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var printDocument = new PrintDocument();
                printDocument.PrinterSettings.PrinterName = cmbImpresoraPredeterminada.SelectedItem.ToString();

                int copias = int.Parse(cmbNumeroCopias.SelectedItem?.ToString() ?? "1");
                printDocument.PrinterSettings.Copies = (short)copias;
                printDocument.OriginAtMargins = false;
                printDocument.DefaultPageSettings.Landscape = false;

                int anchoMm = ObtenerAnchoPapelMm();
                int anchoPapel = MmAHundredthsInch(anchoMm);
                int ajusteEscala = (int)nudEscalaAjuste.Value;
                double factorEscala = Math.Max(0.5d, 1d + (ajusteEscala / 100d));
                int margenIzq = MmAHundredthsInch((int)nudMargenIzquierdo.Value);
                int margenDer = MmAHundredthsInch((int)nudMargenDerecho.Value);
                int margenSup = MmAHundredthsInch((int)nudMargenSuperior.Value);
                int margenInf = MmAHundredthsInch((int)nudMargenInferior.Value);

                int altoContenidoVista = _ticketPreview?.ContentHeight ?? 500;
                int anchoVista         = _ticketPreview?.ContentWidth  ?? 288;

                int anchoBase = Math.Max(1, anchoPapel - margenIzq - margenDer);
                int anchoContenido = Math.Max(1, (int)Math.Round(anchoBase * factorEscala));
                anchoContenido = Math.Min(anchoBase, anchoContenido);
                double relacionVista = (double)altoContenidoVista / Math.Max(1, anchoVista);
                int altoContenido = (int)Math.Ceiling(anchoContenido * relacionVista);
                int altoPapel = Math.Max(200, altoContenido + margenSup + margenInf);

                printDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                printDocument.DefaultPageSettings.PaperSize = new PaperSize("TicketPersonalizado", anchoPapel, altoPapel);

                printDocument.PrintPage += (s, ev) =>
                {
                    ev.Graphics.Clear(Color.White);
                    ev.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    ev.Graphics.InterpolationMode  = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    ev.Graphics.SmoothingMode      = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    ev.Graphics.PixelOffsetMode    = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    ev.Graphics.TextRenderingHint  = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                    ev.Graphics.TranslateTransform(-ev.PageSettings.HardMarginX, -ev.PageSettings.HardMarginY);

                    int anchoDriver = Math.Max(1, ev.PageBounds.Width);
                    int diferenciaAncho = Math.Abs(anchoDriver - anchoPapel);
                    int anchoBaseReal = diferenciaAncho > (anchoPapel / 4) ? anchoDriver : anchoPapel;
                    int anchoImprimibleReal = Math.Max(1, anchoBaseReal - margenIzq - margenDer);
                    int anchoDestino = Math.Max(1, (int)Math.Round(anchoImprimibleReal * factorEscala));
                    anchoDestino = Math.Min(anchoImprimibleReal, anchoDestino);

                    Rectangle destino = new Rectangle
                    {
                        X      = margenIzq,
                        Y      = margenSup,
                        Width  = anchoDestino,
                        Height = (int)Math.Round(anchoDestino * relacionVista)
                    };
                    int altoMaximo = Math.Max(1, ev.PageBounds.Height - margenSup - margenInf);
                    destino.Height = Math.Min(destino.Height, altoMaximo);

                    _ticketPreview?.RenderForPrint(ev.Graphics, destino, altoContenidoVista);
                    ev.HasMorePages = false;
                };

                printDocument.Print();

                if (chkSonidoImprimir.Checked)
                {
                    System.Media.SystemSounds.Beep.Play();
                }

                MessageBox.Show("Ticket de prueba enviado a la impresora", "Informacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static int MmAHundredthsInch(int mm)
        {
            return (int)Math.Round(mm * 3.937d);
        }


        private int ObtenerAnchoPapelMm()
        {
            if (cmbAnchoPapel.SelectedIndex == 0)
            {
                return 58;
            }

            if (cmbAnchoPapel.SelectedIndex == 1)
            {
                return 88;
            }

            return (int)nudAnchoPersonalizado.Value;
        }

        private void CmbAnchoPapel_SelectedIndexChanged(object sender, EventArgs e)
        {
            nudAnchoPersonalizado.Enabled = cmbAnchoPapel.SelectedIndex == 2;
        }

        private void BtnGuardarConfiguracion_Click(object sender, EventArgs e)
        {
            GuardarConfiguracion();
            MessageBox.Show("Configuracion guardada correctamente.", "Informacion",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private int LeerEnteroConfig(string clave, int valorDefecto, int min, int max)
        {
            string valor = EmpresaRepository.ObtenerConfiguracion(clave, valorDefecto.ToString());
            if (!int.TryParse(valor, out int numero))
            {
                numero = valorDefecto;
            }

            return Math.Max(min, Math.Min(max, numero));
        }

    }
}
