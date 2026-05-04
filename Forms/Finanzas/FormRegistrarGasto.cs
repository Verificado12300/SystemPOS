using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormRegistrarGasto : Form
    {
        private readonly decimal _tasaIGV = 0.18m;
        private decimal _baseImponible;
        private decimal _igvGasto;
        private decimal _totalGasto;
        private List<Proveedor> _proveedores;
        private int? _gastoIDEdicion;

        public FormRegistrarGasto()
        {
            InitializeComponent();
        }

        public FormRegistrarGasto(Models.Gasto gasto) : this()
        {
            _gastoIDEdicion = gasto.GastoID;
            // Pre-fill after Load via stored reference
            Tag = gasto;
        }

        private void FormRegistrarGasto_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCategorias();
                CargarProveedores();
                ConfigurarControles();

                if (_gastoIDEdicion.HasValue && Tag is Models.Gasto gastoEdicion)
                    AplicarModoEdicion(gastoEdicion);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar formulario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarModoEdicion(Models.Gasto gasto)
        {
            this.Text = "Editar Gasto";

            // Pre-fill editable fields
            txtConcepto.Text      = gasto.Concepto;
            txtComprobante.Text   = gasto.Comprobante ?? "";
            txtObservaciones.Text = gasto.Observaciones ?? "";

            // Select categoria
            int catIdx = cmbCategoria.Items.IndexOf(gasto.Categoria);
            if (catIdx >= 0) cmbCategoria.SelectedIndex = catIdx;

            // Lock financial fields — editing monto/fecha/método requires full reversal of accounting
            dtpFecha.Enabled      = false;
            dtpHora.Enabled       = false;
            numMonto.Enabled      = false;
            cmbMetodoPago.Enabled = false;
            cboIGV.Enabled        = false;
            cmbProveedor.Enabled  = false;

            // Show read-only financial values
            dtpFecha.Value = gasto.Fecha;
            dtpHora.Value  = DateTime.Today + gasto.Hora;
            numMonto.Value = gasto.TipoIGV == 0 ? gasto.Monto : (gasto.TipoIGV == 2 ? gasto.BaseImponible : gasto.Monto);

            int mpIdx = cmbMetodoPago.FindStringExact(gasto.MetodoPago);
            if (mpIdx >= 0) cmbMetodoPago.SelectedIndex = mpIdx;
            if (gasto.TipoIGV < cboIGV.Items.Count) cboIGV.SelectedIndex = gasto.TipoIGV;

            // Show note to user
            var lblNota = new System.Windows.Forms.Label
            {
                Text      = "Solo se puede editar: concepto, categoría, comprobante y observaciones.",
                AutoSize  = false,
                Size      = new System.Drawing.Size(440, 18),
                Location  = new System.Drawing.Point(12, 2),
                Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic),
                ForeColor = System.Drawing.Color.FromArgb(52, 152, 219)
            };
            this.Controls.Add(lblNota);
            lblNota.BringToFront();
        }

        private void CargarProveedores()
        {
            try
            {
                _proveedores = ProveedorRepository.Listar();
                cmbProveedor.Items.Clear();
                cmbProveedor.Items.Add("(Sin proveedor)");
                foreach (var p in _proveedores)
                    cmbProveedor.Items.Add(p.RazonSocial);
                cmbProveedor.SelectedIndex = 0;
            }
            catch { /* No crítico: lista vacía es aceptable */ }
        }

        private void CargarCategorias()
        {
            try
            {
                cmbCategoria.Items.Clear();
                foreach (var cat in GastoRepository.CategoriasDisponibles)
                {
                    cmbCategoria.Items.Add(cat);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarControles()
        {
            // Configurar fecha y hora actuales
            dtpFecha.Value = DateTime.Now;
            dtpHora.Value = DateTime.Now;

            // Configurar monto
            numMonto.Value = 0;
            numMonto.Minimum = 0;
            numMonto.Maximum = 999999;
            numMonto.DecimalPlaces = 2;

            // Tipo IGV — Sin IGV por defecto
            if (cboIGV.Items.Count > 0)
                cboIGV.SelectedIndex = 0;

            // Seleccionar primer método de pago por defecto
            if (cmbMetodoPago.Items.Count > 0)
                cmbMetodoPago.SelectedIndex = 0;

            // Eventos IGV y método de pago
            cboIGV.SelectedIndexChanged += (_, __) => CalcularTotales();
            numMonto.ValueChanged += (_, __) => CalcularTotales();
            cmbMetodoPago.SelectedIndexChanged += (_, __) => OnMetodoPagoChanged();

            CalcularTotales();
        }

        private void OnMetodoPagoChanged()
        {
            bool esCredito = cmbMetodoPago.Text == "CREDITO";
            lblProveedor.Visible = esCredito;
            cmbProveedor.Visible = esCredito;

            if (esCredito)
            {
                var tip = new System.Windows.Forms.ToolTip();
                tip.SetToolTip(cmbProveedor,
                    "Opcional. Si selecciona un proveedor, el gasto quedará\nvinculado a Cuentas por Pagar para seguimiento de deuda.");
                tip.SetToolTip(lblProveedor,
                    "Opcional. Si selecciona un proveedor, el gasto quedará\nvinculado a Cuentas por Pagar para seguimiento de deuda.");
            }
        }

        private void CalcularTotales()
        {
            decimal monto = numMonto.Value;
            int tipoIGV = cboIGV.SelectedIndex < 0 ? 0 : cboIGV.SelectedIndex;

            if (tipoIGV == 1)           // IGV INCLUIDO
            {
                _totalGasto    = monto;
                _baseImponible = Math.Round(monto / (1m + _tasaIGV), 2);
                _igvGasto      = _totalGasto - _baseImponible;
            }
            else if (tipoIGV == 2)      // IGV ADICIONAL
            {
                _baseImponible = monto;
                _igvGasto      = Math.Round(monto * _tasaIGV, 2);
                _totalGasto    = monto + _igvGasto;
            }
            else                        // SIN IGV
            {
                _baseImponible = monto;
                _igvGasto      = 0m;
                _totalGasto    = monto;
            }

            txtBaseImponible.Text = _baseImponible.ToString("N2");
            txtIGVGasto.Text      = _igvGasto.ToString("N2");
            txtGastoTotal.Text    = _totalGasto.ToString("N2");
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtConcepto.Text))
            {
                MessageBox.Show("Ingrese el concepto del gasto", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConcepto.Focus();
                return false;
            }

            if (numMonto.Value <= 0)
            {
                MessageBox.Show("El monto debe ser mayor a cero", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numMonto.Focus();
                return false;
            }

            if (cmbCategoria.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una categoría", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategoria.Focus();
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

                bool esCredito = cmbMetodoPago.Text == "CREDITO";
                int? proveedorID = null;
                if (esCredito && _proveedores != null && cmbProveedor.SelectedIndex > 0)
                    proveedorID = _proveedores[cmbProveedor.SelectedIndex - 1].ProveedorID;

                Gasto gasto = new Gasto
                {
                    Fecha         = dtpFecha.Value.Date,
                    Hora          = dtpHora.Value.TimeOfDay,
                    Concepto      = txtConcepto.Text.Trim(),
                    Monto         = _totalGasto,
                    TipoIGV       = cboIGV.SelectedIndex < 0 ? 0 : cboIGV.SelectedIndex,
                    BaseImponible = _baseImponible,
                    Categoria     = cmbCategoria.Text,
                    MetodoPago    = cmbMetodoPago.Text,
                    Comprobante   = string.IsNullOrWhiteSpace(txtComprobante.Text) ? null : txtComprobante.Text.Trim(),
                    Observaciones = string.IsNullOrWhiteSpace(txtObservaciones.Text) ? null : txtObservaciones.Text.Trim(),
                    CajaID        = CajaRepository.ObtenerCajaAbierta()?.CajaID,
                    UsuarioID     = SesionActual.Usuario?.UsuarioID ?? 0,
                    ProveedorID   = proveedorID
                };

                if (_gastoIDEdicion.HasValue)
                {
                    string concepto      = txtConcepto.Text.Trim();
                    string categoria     = cmbCategoria.Text;
                    string comprobante   = string.IsNullOrWhiteSpace(txtComprobante.Text) ? null : txtComprobante.Text.Trim();
                    string observaciones = string.IsNullOrWhiteSpace(txtObservaciones.Text) ? null : txtObservaciones.Text.Trim();

                    if (GastoRepository.ActualizarDescriptivos(_gastoIDEdicion.Value, concepto, categoria, comprobante, observaciones))
                    {
                        MessageBox.Show("Gasto actualizado correctamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el gasto", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }

                if (GastoRepository.Crear(gasto))
                {
                    MessageBox.Show("Gasto registrado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el gasto", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar:\n\n{ex}", "Error",
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
