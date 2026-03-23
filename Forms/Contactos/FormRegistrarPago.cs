using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using SistemaPOS.Data;

namespace SistemaPOS.Forms.Contactos
{
    public partial class FormRegistrarPago : Form
    {
        private int _clienteID;
        private decimal _saldoActual;

        public FormRegistrarPago(int clienteID, decimal saldoActual)
        {
            InitializeComponent();
            _clienteID = clienteID;
            _saldoActual = saldoActual;

            ConfigurarFormulario();
            ConfigurarEventos();
        }

        private void ConfigurarFormulario()
        {
            // Obtener nombre del cliente
            var cliente = ClienteRepository.ObtenerPorID(_clienteID);
            string nombreCliente = cliente.TipoDocumento == "RUC" ? cliente.RazonSocial : cliente.Nombres + " " + cliente.Apellidos;

            lblTitulo.Text = $"Registrar Pago - {nombreCliente}";

            // Mostrar saldo actual
            txtSaldoActual.Text = "S/ " + _saldoActual.ToString("N2");
            txtSaldoActual.ForeColor = Color.Red;
            txtSaldoActual.Font = new Font(txtSaldoActual.Font, FontStyle.Bold);

            // Configurar fecha actual
            dtpFecha.Value = DateTime.Now;

            // Seleccionar método Efectivo por defecto
            rbEfectivo.Checked = true;

            // Deshabilitar campos de métodos no seleccionados
            ConfigurarCamposMetodoPago();

            // Hacer readonly el campo observaciones
            txtObservaciones.ReadOnly = false;
        }

        private void ConfigurarEventos()
        {
            // Eventos de RadioButtons
            rbEfectivo.CheckedChanged += MetodoPago_CheckedChanged;
            rbYape.CheckedChanged += MetodoPago_CheckedChanged;
            rbTransferencia.CheckedChanged += MetodoPago_CheckedChanged;
            rbMixto.CheckedChanged += MetodoPago_CheckedChanged;

            // Validaciones
            txtMontoPagar.KeyPress += TxtDecimal_KeyPress;
            txtEfectivo.KeyPress += TxtDecimal_KeyPress;
            txtYape.KeyPress += TxtDecimal_KeyPress;
            txtTransferencia.KeyPress += TxtDecimal_KeyPress;

            // Hacer editable txtMontoPagar
            txtMontoPagar.ReadOnly = false;

            // Botones
            btnRegistrarPago.Click += BtnRegistrarPago_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

        private void MetodoPago_CheckedChanged(object sender, EventArgs e)
        {
            ConfigurarCamposMetodoPago();
        }

        private void ConfigurarCamposMetodoPago()
        {
            // Limpiar campos
            txtEfectivo.Clear();
            txtYape.Clear();
            txtTransferencia.Clear();

            if (rbEfectivo.Checked)
            {
                txtEfectivo.Enabled = false;
                txtYape.Enabled = false;
                txtTransferencia.Enabled = false;
            }
            else if (rbYape.Checked)
            {
                txtEfectivo.Enabled = false;
                txtYape.Enabled = false;
                txtTransferencia.Enabled = false;
            }
            else if (rbTransferencia.Checked)
            {
                txtEfectivo.Enabled = false;
                txtYape.Enabled = false;
                txtTransferencia.Enabled = false;
            }
            else if (rbMixto.Checked)
            {
                txtEfectivo.Enabled = true;
                txtYape.Enabled = true;
                txtTransferencia.Enabled = true;
            }
        }

        private void BtnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                if (!TryParseDecimal(txtMontoPagar.Text, out decimal montoPagar))
                {
                    MessageBox.Show("El monto a pagar no es válido", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMontoPagar.Focus();
                    return;
                }
                string metodoPago = ObtenerMetodoPago();
                DateTime fecha = dtpFecha.Value;
                string observaciones = txtObservaciones.Text.Trim();

                // Calcular montos individuales según método de pago
                decimal montoEfectivo = 0, montoYape = 0, montoTransferencia = 0;

                if (rbEfectivo.Checked)
                    montoEfectivo = montoPagar;
                else if (rbYape.Checked)
                    montoYape = montoPagar;
                else if (rbTransferencia.Checked)
                    montoTransferencia = montoPagar;
                else if (rbMixto.Checked)
                {
                    montoEfectivo = TryParseDecimal(txtEfectivo.Text, out decimal ef) ? ef : 0;
                    montoYape = TryParseDecimal(txtYape.Text, out decimal yp) ? yp : 0;
                    montoTransferencia = TryParseDecimal(txtTransferencia.Text, out decimal tr) ? tr : 0;
                }

                if (ClienteRepository.RegistrarPago(_clienteID, montoPagar, metodoPago, fecha, observaciones, montoEfectivo, montoYape, montoTransferencia))
                {
                    MessageBox.Show("Pago registrado exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar pago: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormulario()
        {
            // Validar monto a pagar
            if (string.IsNullOrWhiteSpace(txtMontoPagar.Text))
            {
                MessageBox.Show("Debe ingresar el monto a pagar", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoPagar.Focus();
                return false;
            }

            decimal montoPagar;
            if (!TryParseDecimal(txtMontoPagar.Text, out montoPagar) || montoPagar <= 0)
            {
                MessageBox.Show("El monto a pagar debe ser mayor a 0", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoPagar.Focus();
                return false;
            }

            // Rechazar si el monto supera el saldo pendiente
            if (montoPagar > _saldoActual)
            {
                MessageBox.Show(
                    $"El monto ingresado (S/ {montoPagar:N2}) excede el saldo pendiente (S/ {_saldoActual:N2}).\n\n" +
                    "Corrija el monto e intente de nuevo.",
                    "Monto inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtMontoPagar.Focus();
                return false;
            }

            // Validar método de pago mixto
            if (rbMixto.Checked)
            {
                decimal efectivo = TryParseDecimal(txtEfectivo.Text, out decimal ef) ? ef : 0;
                decimal yape = TryParseDecimal(txtYape.Text, out decimal yp) ? yp : 0;
                decimal transferencia = TryParseDecimal(txtTransferencia.Text, out decimal tr) ? tr : 0;

                decimal totalMixto = efectivo + yape + transferencia;

                if (Math.Abs(totalMixto - montoPagar) > 0.01m)
                {
                    MessageBox.Show(
                        $"La suma de los montos parciales (S/ {totalMixto:N2}) debe ser igual al monto a pagar (S/ {montoPagar:N2})",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }

                if (totalMixto == 0)
                {
                    MessageBox.Show("Debe ingresar al menos un monto en el pago mixto", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            // Validar fecha
            if (dtpFecha.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha no puede ser futura", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private string ObtenerMetodoPago()
        {
            if (rbEfectivo.Checked)
                return "EFECTIVO";
            else if (rbYape.Checked)
                return "YAPE";
            else if (rbTransferencia.Checked)
                return "TRANSFERENCIA";
            else if (rbMixto.Checked)
                return "MIXTO";

            return "EFECTIVO";
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void TxtDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            var textBox = sender as TextBox;
            if (textBox == null) return;

            if ((e.KeyChar == '.' && textBox.Text.IndexOf('.') > -1)
                || (e.KeyChar == ',' && textBox.Text.IndexOf(',') > -1)
                || ((e.KeyChar == '.' || e.KeyChar == ',') && (textBox.Text.Contains(".") || textBox.Text.Contains(","))))
            {
                e.Handled = true;
            }
        }

        private static bool TryParseDecimal(string texto, out decimal valor)
        {
            if (decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out valor))
                return true;

            return decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out valor);
        }
    }
}
