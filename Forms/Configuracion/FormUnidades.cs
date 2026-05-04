using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;

namespace SistemaPOS.Forms.Configuracion
{
    public partial class FormUnidades : Form
    {
        private int? _unidadEditandoID = null;

        public FormUnidades()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            ConfigurarEventos();
            chkActivo.Checked = true;
            CargarTipos();
            CargarUnidades();
            LimpiarFormulario();
        }

        private void ConfigurarEventos()
        {
            btnGuardar.Click      += BtnGuardar_Click;
            btnCancelar.Click     += BtnCancelar_Click;
            txtBuscar.TextChanged += (s, e) => CargarUnidades(txtBuscar.Text);
            txtBuscar.KeyDown     += TxtBuscar_KeyDown;
            dgvUnidades.CellClick += DgvUnidades_CellClick;
        }

        private void TxtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarUnidades(txtBuscar.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void CargarTipos()
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.AddRange(UnidadRepository.ObtenerTipos());
            if (cmbTipo.Items.Count > 0)
                cmbTipo.SelectedIndex = 0;
        }

        private void CargarUnidades(string busqueda = null)
        {
            var unidades = UnidadRepository.Listar(busqueda);

            dgvUnidades.Rows.Clear();
            int numero = 1;

            foreach (var u in unidades)
            {
                int index = dgvUnidades.Rows.Add();
                var row   = dgvUnidades.Rows[index];

                row.Cells["colNumero"].Value      = numero++;
                row.Cells["colNombre"].Value      = u.Nombre;
                row.Cells["colAbreviatura"].Value = u.Simbolo;
                row.Cells["colTipo"].Value        = u.Tipo;
                row.Cells["colProducto"].Value    = u.CantidadProductos.ToString();

                if (u.Activo)
                {
                    row.Cells["colEstado"].Value           = "ACTIVO";
                    row.Cells["colEstado"].Style.ForeColor = Color.FromArgb(39, 174, 96);
                }
                else
                {
                    row.Cells["colEstado"].Value           = "INACTIVO";
                    row.Cells["colEstado"].Style.ForeColor = Color.FromArgb(150, 160, 170);
                    row.DefaultCellStyle.ForeColor         = Color.FromArgb(150, 160, 170);
                }

                row.Tag = u.UnidadID;
            }

            lblCardVal1.Text = unidades.Count.ToString();
            lblCardVal2.Text = unidades.Count(u => u.Activo).ToString();
            lblCardVal3.Text = unidades.Count(u => u.CantidadProductos > 0).ToString();
            lblMostrar.Text  = $"Mostrando {unidades.Count} unidad{(unidades.Count != 1 ? "es" : "")}";
        }

        private void LimpiarFormulario()
        {
            _unidadEditandoID = null;
            txtNombre.Clear();
            txtAbreviatura.Clear();
            if (cmbTipo.Items.Count > 0)
                cmbTipo.SelectedIndex = 0;
            chkActivo.Checked = true;

            lblFormTitle.Text = "Nueva Unidad";
            btnGuardar.Text   = "Guardar";
            txtNombre.Focus();
        }

        private void CargarUnidadParaEditar(int unidadID)
        {
            var unidad = UnidadRepository.ObtenerPorID(unidadID);
            if (unidad == null)
            {
                MessageBox.Show("No se encontró la unidad.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _unidadEditandoID   = unidadID;
            txtNombre.Text      = unidad.Nombre;
            txtAbreviatura.Text = unidad.Simbolo;
            chkActivo.Checked   = unidad.Activo;

            for (int i = 0; i < cmbTipo.Items.Count; i++)
            {
                if (cmbTipo.Items[i].ToString() == unidad.Tipo)
                {
                    cmbTipo.SelectedIndex = i;
                    break;
                }
            }

            lblFormTitle.Text = "Editando Unidad";
            btnGuardar.Text   = "Actualizar";
            txtNombre.Focus();
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre de la unidad.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (txtNombre.Text.Trim().Length < 2)
            {
                MessageBox.Show("El nombre debe tener al menos 2 caracteres.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAbreviatura.Text))
            {
                MessageBox.Show("Ingrese la abreviatura de la unidad.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAbreviatura.Focus();
                return false;
            }

            if (cmbTipo.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de unidad.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipo.Focus();
                return false;
            }

            if (UnidadRepository.ExisteNombre(txtNombre.Text.Trim(), _unidadEditandoID))
            {
                MessageBox.Show("Ya existe una unidad con ese nombre.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            return true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            try
            {
                var unidad = new UnidadBase
                {
                    Nombre  = txtNombre.Text.Trim(),
                    Simbolo = txtAbreviatura.Text.Trim(),
                    Tipo    = cmbTipo.SelectedItem.ToString(),
                    Activo  = chkActivo.Checked
                };

                if (_unidadEditandoID.HasValue)
                {
                    unidad.UnidadID = _unidadEditandoID.Value;
                    if (UnidadRepository.Actualizar(unidad))
                    {
                        MessageBox.Show("Unidad actualizada exitosamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUnidades(txtBuscar.Text);
                        LimpiarFormulario();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar la unidad.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (UnidadRepository.Crear(unidad))
                    {
                        MessageBox.Show("Unidad creada exitosamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUnidades(txtBuscar.Text);
                        LimpiarFormulario();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo crear la unidad.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void DgvUnidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int    unidadID   = Convert.ToInt32(dgvUnidades.Rows[e.RowIndex].Tag);
            string columnName = dgvUnidades.Columns[e.ColumnIndex].Name;

            if (columnName == "colEditar")
                CargarUnidadParaEditar(unidadID);
            else if (columnName == "colEliminar")
                EliminarUnidad(unidadID);
        }

        private void EliminarUnidad(int unidadID)
        {
            var unidad = UnidadRepository.ObtenerPorID(unidadID);
            if (unidad == null) return;

            var result = MessageBox.Show(
                $"¿Está seguro de eliminar la unidad '{unidad.Nombre}'?\n\n" +
                "Si tiene productos asociados, solo será desactivada.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                if (UnidadRepository.Eliminar(unidadID))
                {
                    MessageBox.Show("Unidad eliminada/desactivada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUnidades(txtBuscar.Text);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la unidad.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
