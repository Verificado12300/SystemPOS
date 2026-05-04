using System;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormRegistrarPagoProveedor : Form
    {
        private int _cuentaID;
        private decimal _montoPendiente;

        public FormRegistrarPagoProveedor() { InitializeComponent(); }

        public FormRegistrarPagoProveedor(int cuentaID)
        {
            InitializeComponent();
            _cuentaID = cuentaID;
        }

        private void FormRegistrarPagoProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarControles();
                CargarDatosCuenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar formulario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarControles()
        {
            dtpFecha.Value = DateTime.Now;
            dtpHora.Value = DateTime.Now;
            numMonto.Minimum = 0;
            numMonto.Maximum = 999999;
            numMonto.DecimalPlaces = 2;

            if (cmbMetodoPago.Items.Count > 0)
                cmbMetodoPago.SelectedIndex = 0;
        }

        private void CargarDatosCuenta()
        {
            try
            {
                var cuenta = CuentaPorPagarRepository.ObtenerPorID(_cuentaID);
                if (cuenta == null)
                {
                    MessageBox.Show("No se encontró la cuenta por pagar", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                lblProveedorValor.Text = cuenta.NombreProveedor;
                lblNumeroCompraValor.Text = cuenta.Referencia;
                lblMontoTotalValor.Text = $"S/ {cuenta.MontoTotal:N2}";
                lblMontoPagadoValor.Text = $"S/ {cuenta.MontoPagado:N2}";
                lblMontoPendienteValor.Text = $"S/ {cuenta.MontoPendiente:N2}";

                _montoPendiente = cuenta.MontoPendiente;
                numMonto.Maximum = _montoPendiente;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormulario()
        {
            if (numMonto.Value <= 0)
            {
                MessageBox.Show("El monto debe ser mayor a cero", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numMonto.Focus();
                return false;
            }

            if (numMonto.Value > _montoPendiente)
            {
                MessageBox.Show($"El monto no puede ser mayor al pendiente (S/ {_montoPendiente:N2})", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numMonto.Focus();
                return false;
            }

            if (cmbMetodoPago.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un método de pago", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMetodoPago.Focus();
                return false;
            }

            return true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarFormulario())
                    return;

                PagoProveedor pago = new PagoProveedor
                {
                    CuentaPorPagarID = _cuentaID,
                    Fecha = dtpFecha.Value.Date,
                    Hora = dtpHora.Value.TimeOfDay,
                    Monto = numMonto.Value,
                    MetodoPago = cmbMetodoPago.Text,
                    Comprobante = string.IsNullOrWhiteSpace(txtComprobante.Text) ? null : txtComprobante.Text.Trim(),
                    Observaciones = string.IsNullOrWhiteSpace(txtObservaciones.Text) ? null : txtObservaciones.Text.Trim(),
                    UsuarioID = SesionActual.Usuario.UsuarioID
                };

                if (CuentaPorPagarRepository.RegistrarPago(pago))
                {
                    MessageBox.Show("Pago registrado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el pago", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
