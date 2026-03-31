using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaPOS.Controls;
using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Ventas
{
    /// <summary>
    /// Wrapper de presentación para el ticket de venta.
    /// Toda la lógica del ticket vive en _ticketPreview (TicketPreviewControl).
    /// </summary>
    public partial class FormPreviewTicket : Form
    {
        private TicketPreviewControl _ticketPreview;
        private DataTable _detalle;
        private Dictionary<string, string> _parametros;

        // ── Constructores ─────────────────────────────────────────────────────

        /// <summary>Constructor requerido por el Diseñador de Visual Studio. No usar en tiempo de ejecución.</summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public FormPreviewTicket()
        {
            InitializeComponent();
        }

        private void CrearTicketPreview()
        {
            _ticketPreview = new TicketPreviewControl();
            _ticketPreview.Location = new Point(0, 0);
            pnlVistaTicket.Controls.Add(_ticketPreview);
        }

        /// <summary>Ticket real: datos de venta + config de visibilidad desde BD.</summary>
        public FormPreviewTicket(DataTable detalle, Dictionary<string, string> parametros)
        {
            InitializeComponent();
            CrearTicketPreview();
            _detalle    = detalle;
            _parametros = parametros;
            _ticketPreview.LlenarDatos(detalle, parametros);
        }

        /// <summary>Ticket demo: para FormImpresoras (sin acceso a venta real).</summary>
        public FormPreviewTicket(TicketConfig config)
        {
            InitializeComponent();
            CrearTicketPreview();
            _ticketPreview.LlenarDatosDemo(config);
        }

        // ── Render — 100 % delegados a _ticketPreview ─────────────────────────

        public int TicketContentHeight => _ticketPreview.ContentHeight;
        public int TicketWidth         => _ticketPreview.ContentWidth;

        public Bitmap RenderToBitmap() => _ticketPreview.RenderToBitmap();

        public void RenderForPrint(Graphics g, Rectangle destino, int sourceHeight)
            => _ticketPreview.RenderForPrint(g, destino, sourceHeight);

        // ── Ciclo de vida ─────────────────────────────────────────────────────

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            // Segundo reflow: DGV ya tiene alturas de fila reales tras OnShown.
            _ticketPreview.Reflow();
            AjustarForm();
        }

        private void AjustarForm()
        {
            pnlVistaTicket.Width     = _ticketPreview.Width;
            pnlVistaTicket.Height    = _ticketPreview.Height + 4;
            pnlVistaTicket.BackColor = Color.White;

            int formWidth = _ticketPreview.Width + 50;
            formWidth = Math.Max(formWidth, 320);
            formWidth = Math.Min(formWidth, 420);
            // Si el ticket es más ancho que el form (ej: DPI alto), ampliar el form
            if (pnlVistaTicket.Width + 20 > formWidth)
                formWidth = pnlVistaTicket.Width + 20;
            pnlVistaTicket.Left = Math.Max(0, (formWidth - pnlVistaTicket.Width) / 2);
            pnlVistaTicket.Top  = 12;

            int maxH = Screen.PrimaryScreen.WorkingArea.Height - 100;
            ClientSize = new Size(
                formWidth,
                Math.Min(pnlVistaTicket.Top + pnlVistaTicket.Height + pnlBottom.Height + 20, maxH));
        }

        // ── Botones ───────────────────────────────────────────────────────────

        private void BtnCerrar_Click(object sender, EventArgs e) => Close();

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                string impresora = EmpresaRepository.ObtenerConfiguracion("IMPRESORA_PREDETERMINADA", "");
                if (string.IsNullOrWhiteSpace(impresora))
                {
                    MessageBox.Show("No hay impresora configurada. Configure una en Impresión de Comprobantes.",
                        "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int anchoMm = 88;
                int.TryParse(EmpresaRepository.ObtenerConfiguracion("ANCHO_PAPEL_TICKET", "88"), out anchoMm);

                var config = TicketConfig.CargarDesdeDB();
                var escpos = new TicketESCPOS(anchoMm);
                byte[] data = escpos.GenerarTicket(_detalle, _parametros, config);

                bool ok = RawPrinterHelper.SendBytesToPrinter(impresora, data);
                if (ok)
                    Close();
                else
                    MessageBox.Show("Error al enviar datos a la impresora.", "Imprimir",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message, "Imprimir",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
