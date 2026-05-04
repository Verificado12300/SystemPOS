using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaPOS.Controls;

namespace SistemaPOS.Forms.Ventas
{
    public partial class FormCobrarConTicket : Form
    {
        private readonly decimal _total;
        private bool _soloVista;
        private TicketPreviewControl _ticketPreview;
        private DataTable _detalle;
        private Dictionary<string, string> _parametros;

        // ── Propiedades de salida ────────────────────────────────────────────
        public string  MetodoPago         { get; private set; } = "";
        public decimal MontoEfectivo      { get; private set; }
        public decimal MontoYape          { get; private set; }
        public decimal MontoTransferencia { get; private set; }
        public decimal MontoTarjeta       { get; private set; }
        public decimal Recibido           { get; private set; }

        // ── Constructores ────────────────────────────────────────────────────

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public FormCobrarConTicket()
        {
            InitializeComponent();
        }

        public FormCobrarConTicket(decimal total, DataTable detalle, Dictionary<string, string> parametros)
        {
            _total      = total;
            _detalle    = detalle;
            _parametros = parametros;
            InitializeComponent();
            ConfigurarEventos();
            lblTotalAmount.Text = "S/ " + total.ToString("N2");
            ActualizarResumen();
            InicializarTicket();
        }

        /// <summary>Modo vista previa: solo muestra el ticket con botones Imprimir / Cerrar.</summary>
        public FormCobrarConTicket(DataTable detalle, Dictionary<string, string> parametros)
        {
            _soloVista  = true;
            _detalle    = detalle;
            _parametros = parametros;
            InitializeComponent();

            // Ocultar panel de pago y estirar el lado del ticket
            pnlPagoSide.Visible         = false;
            pnlTicketSide.Dock          = System.Windows.Forms.DockStyle.Fill;

            // Ajustar botones para vista previa
            btnConfirmar.Text           = "Imprimir";
            btnConfirmar.BackColor      = System.Drawing.Color.FromArgb(67, 97, 238);
            btnCancelar.Text            = "Cerrar";

            this.Text        = "Vista Previa del Ticket";
            this.ClientSize  = new System.Drawing.Size(420, 580);

            InicializarTicket();
        }

        // ── Ticket preview ───────────────────────────────────────────────────

        private void InicializarTicket()
        {
            _ticketPreview = new TicketPreviewControl();
            _ticketPreview.Location = new Point(0, 14);
            pnlVistaTicket.Controls.Add(_ticketPreview);
            _ticketPreview.LlenarDatos(_detalle, _parametros);
            pnlScrollTicket.ClientSizeChanged += (s, e) => CentrarTicket();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            _ticketPreview.Reflow();
            AjustarPanelTicket();
        }

        private void AjustarPanelTicket()
        {
            if (_ticketPreview == null) return;
            const int toothH = 10, padX = 16;
            int ticketW = _ticketPreview.Width;
            int ticketH = _ticketPreview.Height;
            int availW  = pnlScrollTicket.ClientSize.Width
                          - pnlScrollTicket.Padding.Left
                          - pnlScrollTicket.Padding.Right;
            pnlVistaTicket.Width  = Math.Max(ticketW + padX * 2 + 8, availW);
            pnlVistaTicket.Height = toothH + ticketH + toothH + 6;
            pnlVistaTicket.Left   = pnlScrollTicket.Padding.Left;
            pnlVistaTicket.Top    = pnlScrollTicket.Padding.Top;
            CentrarTicket();
        }

        private void CentrarTicket()
        {
            if (_ticketPreview == null) return;
            _ticketPreview.Left = Math.Max(0, (pnlVistaTicket.Width - _ticketPreview.Width) / 2) + 6;
            _ticketPreview.Top  = 10 + 4;
        }

        // ── Eventos ──────────────────────────────────────────────────────────

        private void ConfigurarEventos()
        {
            rdbEfectivo.Click      += Rdb_Click;
            rdbYape.Click          += Rdb_Click;
            rdbTransferencia.Click += Rdb_Click;
            rdbTarjeta.Click       += Rdb_Click;
            rdbCredito.Click       += Rdb_Click;

            txtMontoEfectivo.TextChanged      += Txt_TextChanged;
            txtMontoYape.TextChanged          += Txt_TextChanged;
            txtMontoTransferencia.TextChanged += Txt_TextChanged;
            txtMontoTarjeta.TextChanged       += Txt_TextChanged;

            txtMontoEfectivo.KeyPress      += TxtSoloNumeros_KeyPress;
            txtMontoYape.KeyPress          += TxtSoloNumeros_KeyPress;
            txtMontoTransferencia.KeyPress += TxtSoloNumeros_KeyPress;
            txtMontoTarjeta.KeyPress       += TxtSoloNumeros_KeyPress;

            btnConfirmar.Click += BtnConfirmar_Click;
            btnCancelar.Click  += BtnCancelar_Click;
        }

        // ── Selección de radio button ────────────────────────────────────────

        private void Rdb_Click(object sender, EventArgs e)
        {
            var rdb = (RadioButton)sender;

            if (rdb == rdbCredito)
            {
                // Crédito es exclusivo: desactiva todos los demás
                bool activando = !rdbCredito.Checked;
                rdbEfectivo.Checked      = false;
                rdbYape.Checked          = false;
                rdbTransferencia.Checked = false;
                rdbTarjeta.Checked       = false;
                rdbCredito.Checked       = activando;

                txtMontoEfectivo.Text      = "";
                txtMontoYape.Text          = "";
                txtMontoTransferencia.Text = "";
                txtMontoTarjeta.Text       = "";

                txtMontoEfectivo.Enabled      = false;
                txtMontoYape.Enabled          = false;
                txtMontoTransferencia.Enabled = false;
                txtMontoTarjeta.Enabled       = false;
                lblCreditoInfoMini.Visible    = activando;
            }
            else
            {
                // Si crédito estaba activo, desactivarlo
                if (rdbCredito.Checked)
                {
                    rdbCredito.Checked         = false;
                    lblCreditoInfoMini.Visible = false;
                }

                // Toggle el radio clickeado
                rdb.Checked = !rdb.Checked;

                // Habilitar/deshabilitar el TextBox correspondiente
                var txt = TextBoxDeRdb(rdb);
                if (txt != null)
                {
                    txt.Enabled = rdb.Checked;
                    if (!rdb.Checked)
                    {
                        txt.Text = "";
                    }
                    else
                    {
                        // Efectivo: el usuario ingresa cuánto entrega (puede dar más y recibe vuelto)
                        // Yape/Tarjeta/Transferencia: monto exacto → auto-rellenar con lo pendiente
                        if (rdb != rdbEfectivo)
                        {
                            decimal restante = _total - ObtenerSuma();
                            if (restante > 0)
                                txt.Text = restante.ToString("N2");
                        }
                        txt.Focus();
                    }
                }
            }

            ActualizarColorRdb();
            ActualizarTicketPago();
        }

        private TextBox TextBoxDeRdb(RadioButton rdb)
        {
            if (rdb == rdbEfectivo)      return txtMontoEfectivo;
            if (rdb == rdbYape)          return txtMontoYape;
            if (rdb == rdbTransferencia) return txtMontoTransferencia;
            if (rdb == rdbTarjeta)       return txtMontoTarjeta;
            return null;
        }

        private void ActualizarColorRdb()
        {
            var colorActivo  = Color.FromArgb(67, 97, 238);
            var colorNormal  = Color.FromArgb(45, 52, 54);
            foreach (var rdb in new[] { rdbEfectivo, rdbYape, rdbTransferencia, rdbTarjeta, rdbCredito })
                rdb.ForeColor = rdb.Checked ? colorActivo : colorNormal;
        }

        // ── Cambio de monto ──────────────────────────────────────────────────

        private void Txt_TextChanged(object sender, EventArgs e)
        {
            ActualizarResumen();
            ActualizarTicketPago();
        }

        private void TxtSoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ','
                && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        // ── Resumen de suma ──────────────────────────────────────────────────

        private void ActualizarResumen()
        {
            if (rdbCredito.Checked)
            {
                lblResumenPago.Text      = "Crédito — se generará una CxC";
                lblResumenPago.ForeColor = Color.FromArgb(99, 110, 114);
                return;
            }

            decimal suma = ObtenerSuma();
            decimal ef0  = decimal.TryParse(txtMontoEfectivo.Text, out decimal _ef0) ? _ef0 : 0;
            bool efectivoActivo = ef0 > 0;
            // Con efectivo se permite pagar de más (el exceso es vuelto)
            bool ok = suma > 0 && (efectivoActivo ? suma >= _total : Math.Abs(suma - _total) <= 0.01m);
            decimal vuelto = (efectivoActivo && suma > _total) ? suma - _total : 0;
            string vueltoStr = vuelto > 0 ? $"   Vuelto: S/ {vuelto:N2}" : "";
            lblResumenPago.Text      = $"Suma: S/ {suma:N2}   /   Total: S/ {_total:N2}{vueltoStr}";
            lblResumenPago.ForeColor = ok
                ? Color.FromArgb(39, 174, 96)
                : Color.FromArgb(192, 57, 43);
        }

        private decimal ObtenerSuma()
        {
            decimal ef = decimal.TryParse(txtMontoEfectivo.Text,      out decimal e1) ? e1 : 0;
            decimal yp = decimal.TryParse(txtMontoYape.Text,          out decimal e2) ? e2 : 0;
            decimal tr = decimal.TryParse(txtMontoTransferencia.Text,  out decimal e3) ? e3 : 0;
            decimal tj = decimal.TryParse(txtMontoTarjeta.Text,        out decimal e4) ? e4 : 0;
            return ef + yp + tr + tj;
        }

        // ── Actualización del ticket en tiempo real ──────────────────────────

        private void ActualizarTicketPago()
        {
            if (_ticketPreview == null) return;

            decimal ef = decimal.TryParse(txtMontoEfectivo.Text,     out decimal e1) ? e1 : 0;
            decimal yp = decimal.TryParse(txtMontoYape.Text,         out decimal e2) ? e2 : 0;
            decimal tr = decimal.TryParse(txtMontoTransferencia.Text, out decimal e3) ? e3 : 0;
            decimal tj = decimal.TryParse(txtMontoTarjeta.Text,       out decimal e4) ? e4 : 0;

            int metodosActivos = (ef > 0 ? 1 : 0) + (yp > 0 ? 1 : 0) + (tr > 0 ? 1 : 0) + (tj > 0 ? 1 : 0);

            if (rdbCredito.Checked)
            {
                _parametros["pMetodoPago"]     = "Crédito";
                _parametros["pMontoRecibido"]  = "";
                _parametros["pVuelto"]         = "";
                _parametros["pMontoEfectivo"]  = "";
                _parametros["pMontoYape"]      = "";
                _parametros["pMontoTransferencia"] = "";
                _parametros["pMontoTarjeta"]   = "";
            }
            else if (metodosActivos == 0)
            {
                _parametros["pMetodoPago"]         = "";
                _parametros["pMontoRecibido"]      = "";
                _parametros["pVuelto"]             = "";
                _parametros["pMontoEfectivo"]      = "";
                _parametros["pMontoYape"]          = "";
                _parametros["pMontoTransferencia"] = "";
                _parametros["pMontoTarjeta"]       = "";
            }
            else if (metodosActivos == 1)
            {
                string label = ef > 0 ? "Efectivo" : yp > 0 ? "Yape" : tr > 0 ? "Transferencia" : "Tarjeta";
                decimal monto = ef > 0 ? ef : yp > 0 ? yp : tr > 0 ? tr : tj;
                decimal vuelto = (ef > 0 && monto > _total) ? monto - _total : 0;
                _parametros["pMetodoPago"]         = label;
                _parametros["pMontoRecibido"]      = monto > 0 ? monto.ToString("N2") : "";
                _parametros["pVuelto"]             = vuelto > 0 ? vuelto.ToString("N2") : "";
                _parametros["pMontoEfectivo"]      = "";
                _parametros["pMontoYape"]          = "";
                _parametros["pMontoTransferencia"] = "";
                _parametros["pMontoTarjeta"]       = "";
            }
            else
            {
                // Mixto: pasar montos individuales para desglose en ticket
                _parametros["pMetodoPago"]         = "Mixto";
                _parametros["pMontoRecibido"]      = "";
                _parametros["pVuelto"]             = "";
                _parametros["pMontoEfectivo"]      = ef > 0 ? ef.ToString("N2") : "";
                _parametros["pMontoYape"]          = yp > 0 ? yp.ToString("N2") : "";
                _parametros["pMontoTransferencia"] = tr > 0 ? tr.ToString("N2") : "";
                _parametros["pMontoTarjeta"]       = tj > 0 ? tj.ToString("N2") : "";
            }

            _ticketPreview.LlenarDatos(_detalle, _parametros);
            _ticketPreview.Reflow();
            AjustarPanelTicket();
        }

        // ── Confirmar ────────────────────────────────────────────────────────

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (_soloVista)
            {
                try
                {
                    SistemaPOS.Utils.TicketPrinter.ImprimirTicket(_ticketPreview);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al imprimir: " + ex.Message, "Imprimir",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            if (rdbCredito.Checked)
            {
                MetodoPago = "CREDITO";
                Recibido   = 0;
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            decimal ef = decimal.TryParse(txtMontoEfectivo.Text,     out decimal e1) ? e1 : 0;
            decimal yp = decimal.TryParse(txtMontoYape.Text,         out decimal e2) ? e2 : 0;
            decimal tr = decimal.TryParse(txtMontoTransferencia.Text, out decimal e3) ? e3 : 0;
            decimal tj = decimal.TryParse(txtMontoTarjeta.Text,       out decimal e4) ? e4 : 0;
            decimal suma = ef + yp + tr + tj;

            if (suma <= 0)
            {
                MessageBox.Show("Seleccione al menos un método de pago e ingrese el monto.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool conEfectivo = ef > 0;
            bool montoValido = conEfectivo ? suma >= _total : Math.Abs(suma - _total) <= 0.01m;
            if (!montoValido)
            {
                string msg = suma < _total
                    ? $"La suma de los métodos (S/ {suma:N2}) es menor al total (S/ {_total:N2})."
                    : $"La suma (S/ {suma:N2}) no coincide con el total (S/ {_total:N2}). Solo Efectivo permite pagar de más.";
                MessageBox.Show(msg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int metodosActivos = (ef > 0 ? 1 : 0) + (yp > 0 ? 1 : 0) + (tr > 0 ? 1 : 0) + (tj > 0 ? 1 : 0);
            MetodoPago         = metodosActivos > 1 ? "MIXTO"
                               : ef > 0 ? "EFECTIVO"
                               : yp > 0 ? "YAPE"
                               : tr > 0 ? "TRANSFERENCIA"
                               : "TARJETA";
            MontoEfectivo      = ef;
            MontoYape          = yp;
            MontoTransferencia = tr;
            MontoTarjeta       = tj;
            Recibido           = suma; // incluye el exceso (vuelto = suma - _total)

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
