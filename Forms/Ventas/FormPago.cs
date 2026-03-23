using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaPOS.Forms.Ventas
{
    public partial class FormPago : Form
    {
        private readonly decimal _total;

        public string  MetodoPago         { get; private set; } = "EFECTIVO";
        public decimal MontoEfectivo      { get; private set; }
        public decimal MontoYape          { get; private set; }
        public decimal MontoTransferencia { get; private set; }
        public decimal MontoTarjeta       { get; private set; }
        public decimal Recibido           { get; private set; }

        public FormPago(decimal total)
        {
            _total = total;
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode ==
                System.ComponentModel.LicenseUsageMode.Designtime) return;

            ConfigurarEventos();
            lblTotalAmount.Text = "S/ " + total.ToString("N2");
            SeleccionarMetodo("EFECTIVO");
        }

        private void ConfigurarEventos()
        {
            btnEfectivo.Click      += BtnMetodo_Click;
            btnYape.Click          += BtnMetodo_Click;
            btnTransferencia.Click += BtnMetodo_Click;
            btnTarjeta.Click       += BtnMetodo_Click;
            btnMixto.Click         += BtnMetodo_Click;
            btnCredito.Click       += BtnMetodo_Click;

            txtRecibidoPago.TextChanged += TxtRecibidoPago_TextChanged;
            txtRecibidoPago.KeyPress    += TxtRecibidoPago_KeyPress;

            txtEfectivoPago.TextChanged     += TxtMixto_TextChanged;
            txtYapePago.TextChanged         += TxtMixto_TextChanged;
            txtTransferenciaPago.TextChanged += TxtMixto_TextChanged;
            txtTarjetaPago.TextChanged      += TxtMixto_TextChanged;

            txtEfectivoPago.KeyPress      += TxtSoloNumeros_KeyPress;
            txtYapePago.KeyPress          += TxtSoloNumeros_KeyPress;
            txtTransferenciaPago.KeyPress += TxtSoloNumeros_KeyPress;
            txtTarjetaPago.KeyPress       += TxtSoloNumeros_KeyPress;

            btnConfirmar.Click    += BtnConfirmar_Click;
            btnCancelarPago.Click += BtnCancelarPago_Click;
        }

        // ── selección de método ──────────────────────────────────────────
        private void SeleccionarMetodo(string metodo)
        {
            MetodoPago = metodo;

            var colorNorm  = Color.White;
            var borderNorm = Color.FromArgb(220, 221, 225);
            var colorSel   = Color.FromArgb(67, 97, 238);

            foreach (Button b in new[] { btnEfectivo, btnYape, btnTransferencia,
                                         btnTarjeta,  btnMixto, btnCredito })
            {
                b.BackColor = colorNorm;
                b.ForeColor = Color.FromArgb(45, 52, 54);
                b.FlatAppearance.BorderColor = borderNorm;
            }

            Button activo = metodo == "EFECTIVO"      ? btnEfectivo      :
                            metodo == "YAPE"          ? btnYape          :
                            metodo == "TRANSFERENCIA" ? btnTransferencia  :
                            metodo == "TARJETA"       ? btnTarjeta       :
                            metodo == "MIXTO"         ? btnMixto         :
                            metodo == "CREDITO"       ? btnCredito       : null;
            if (activo != null)
            {
                activo.BackColor = colorSel;
                activo.ForeColor = Color.White;
                activo.FlatAppearance.BorderColor = colorSel;
            }

            pnlEfectivo.Visible  = (metodo == "EFECTIVO");
            pnlMixto.Visible     = (metodo == "MIXTO");
            pnlCredito.Visible   = (metodo == "CREDITO");
            pnlSinCambio.Visible = (metodo == "YAPE" || metodo == "TRANSFERENCIA" || metodo == "TARJETA");

            if (metodo == "EFECTIVO") { txtRecibidoPago.Text = ""; txtRecibidoPago.Focus(); }
        }

        // ── cálculo de vuelto ────────────────────────────────────────────
        private void CalcularVuelto()
        {
            if (decimal.TryParse(txtRecibidoPago.Text, out decimal rec))
            {
                decimal vuelto = rec - _total;
                lblVueltoPago.Text      = "S/ " + (vuelto >= 0 ? vuelto : 0m).ToString("N2");
                lblVueltoPago.ForeColor = vuelto >= 0
                    ? Color.FromArgb(39, 174, 96) : Color.FromArgb(192, 57, 43);
            }
            else
            {
                lblVueltoPago.Text      = "S/ 0.00";
                lblVueltoPago.ForeColor = Color.FromArgb(99, 110, 114);
            }
        }

        // ── eventos ──────────────────────────────────────────────────────
        private void BtnMetodo_Click(object sender, EventArgs e)
        {
            var b = (Button)sender;
            SeleccionarMetodo(b.Tag?.ToString() ?? "EFECTIVO");
        }

        private void TxtRecibidoPago_TextChanged(object sender, EventArgs e) => CalcularVuelto();

        private void TxtMixto_TextChanged(object sender, EventArgs e)
        {
            decimal ef = decimal.TryParse(txtEfectivoPago.Text,     out decimal e1) ? e1 : 0;
            decimal yp = decimal.TryParse(txtYapePago.Text,         out decimal e2) ? e2 : 0;
            decimal tr = decimal.TryParse(txtTransferenciaPago.Text, out decimal e3) ? e3 : 0;
            decimal tj = decimal.TryParse(txtTarjetaPago.Text,       out decimal e4) ? e4 : 0;
            decimal suma = ef + yp + tr + tj;
            bool ok = Math.Abs(suma - _total) <= 0.01m;
            lblMixtoRestante.Text      = $"Suma: S/ {suma:N2}   /   Total: S/ {_total:N2}";
            lblMixtoRestante.ForeColor = ok ? Color.FromArgb(39, 174, 96) : Color.FromArgb(192, 57, 43);
        }

        private void TxtSoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ','
                && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void TxtRecibidoPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { e.Handled = true; CalcularVuelto(); btnConfirmar.Focus(); }
            else TxtSoloNumeros_KeyPress(sender, e);
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            switch (MetodoPago)
            {
                case "EFECTIVO":
                    if (!decimal.TryParse(txtRecibidoPago.Text, out decimal rec) || rec < _total)
                    {
                        MessageBox.Show("Ingrese un monto recibido mayor o igual al total.",
                            "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRecibidoPago.Focus(); return;
                    }
                    Recibido = rec; MontoEfectivo = _total; break;

                case "YAPE":
                    Recibido = _total; MontoYape = _total; break;

                case "TRANSFERENCIA":
                    Recibido = _total; MontoTransferencia = _total; break;

                case "TARJETA":
                    Recibido = _total; MontoTarjeta = _total; break;

                case "MIXTO":
                    decimal ef = decimal.TryParse(txtEfectivoPago.Text,     out decimal e1) ? e1 : 0;
                    decimal yp = decimal.TryParse(txtYapePago.Text,         out decimal e2) ? e2 : 0;
                    decimal tr = decimal.TryParse(txtTransferenciaPago.Text, out decimal e3) ? e3 : 0;
                    decimal tj = decimal.TryParse(txtTarjetaPago.Text,       out decimal e4) ? e4 : 0;
                    if (Math.Abs(ef + yp + tr + tj - _total) > 0.01m)
                    {
                        MessageBox.Show("La suma de métodos no coincide con el total.",
                            "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    MontoEfectivo = ef; MontoYape = yp;
                    MontoTransferencia = tr; MontoTarjeta = tj;
                    Recibido = ef + yp + tr + tj; break;

                case "CREDITO":
                    Recibido = 0; break;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancelarPago_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
