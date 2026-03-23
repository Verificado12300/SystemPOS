using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using SistemaPOS.Controls;
using SistemaPOS.Data;
using SistemaPOS.Models;

namespace SistemaPOS.Forms.Ventas
{
    /// <summary>
    /// Wrapper de presentación para el ticket de venta.
    /// Toda la lógica del ticket vive en _ticketPreview (TicketPreviewControl).
    /// </summary>
    public partial class FormPreviewTicket : Form
    {
        private TicketPreviewControl _ticketPreview;

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
            _ticketPreview.Dock = DockStyle.Fill;
            pnlVistaTicket.Controls.Add(_ticketPreview);
        }

        /// <summary>Ticket real: datos de venta + config de visibilidad desde BD.</summary>
        public FormPreviewTicket(DataTable detalle, Dictionary<string, string> parametros)
        {
            InitializeComponent();
            CrearTicketPreview();
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
            pnlVistaTicket.Height = _ticketPreview.Top + _ticketPreview.Height + 4;
            int maxH = Screen.PrimaryScreen.WorkingArea.Height - 50;
            ClientSize = new Size(ClientSize.Width,
                Math.Min(pnlVistaTicket.Height + pnlBottom.Height + 24, maxH));
        }

        // ── Botones ───────────────────────────────────────────────────────────

        private void BtnCerrar_Click(object sender, EventArgs e) => Close();

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            string impresora = EmpresaRepository.ObtenerConfiguracion("IMPRESORA_PREDETERMINADA", "");

            using (var pd = new PrintDocument())
            {
                if (!string.IsNullOrWhiteSpace(impresora))
                    pd.PrinterSettings.PrinterName = impresora;

                int h = _ticketPreview.ContentHeight;
                int w = _ticketPreview.ContentWidth;

                pd.DefaultPageSettings.PaperSize = new PaperSize("Ticket",
                    (int)(w / 96f * 100), (int)(h / 96f * 100));
                pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

                pd.PrintPage += (s2, ev) =>
                {
                    _ticketPreview.RenderForPrint(ev.Graphics,
                        new Rectangle(0, 0, ev.PageBounds.Width, ev.PageBounds.Height), h);
                    ev.HasMorePages = false;
                };

                try   { pd.Print(); Close(); }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al imprimir: " + ex.Message, "Imprimir",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
