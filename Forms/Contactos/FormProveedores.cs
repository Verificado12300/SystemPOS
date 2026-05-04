using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Contactos
{
    public partial class FormProveedores : Form
    {
        private int? _proveedorIDEdicion;
        private bool _modoEdicion;
        private Label _lblModo;

        public FormProveedores()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            ConfigurarEventos();
            ConfigurarControles();
            CargarProveedores();
        }

        private void AgregarLabelModo()
        {
            _lblModo = new Label
            {
                AutoSize  = false,
                Size      = new Size(380, 20),
                Location  = new Point(230, 10),   // dentro del header oscuro pnlHdrDatos
                Font      = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(168, 230, 198),  // verde claro sobre fondo oscuro
                Text      = "Nuevo proveedor"
            };
            pnlHdrDatos.Controls.Add(_lblModo);
            _lblModo.BringToFront();
        }

        private void ActualizarLabelModo()
        {
            if (_lblModo == null) return;
            if (_modoEdicion && !string.IsNullOrWhiteSpace(txtRazonSocial.Text))
            {
                _lblModo.Text      = $"Editando: {txtRazonSocial.Text.Trim()}";
                _lblModo.ForeColor = Color.FromArgb(144, 202, 249);  // azul claro sobre fondo oscuro
            }
            else
            {
                _lblModo.Text      = "Nuevo proveedor";
                _lblModo.ForeColor = Color.FromArgb(168, 230, 198);  // verde claro sobre fondo oscuro
            }
        }

        private void ConfigurarEventos()
        {
            btnNuevo.Click += BtnNuevo_Click;
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            btnBuscar.Click += BtnBuscar_Click;
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            txtBuscar.KeyDown += TxtBuscar_KeyDown;
            txtRUC.KeyPress += TxtRUC_KeyPress;
            txtTelefono.KeyPress += TxtTelefono_KeyPress;
            dgvProveedores.CellClick += DgvProveedores_CellClick;
        }

        private void TxtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarProveedores(txtBuscar.Text.Trim());
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void ConfigurarControles()
        {
            dgvProveedores.AutoGenerateColumns = false;
            DgvStyleHelper.Aplicar(dgvProveedores);
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.ReadOnly = true;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            chkProveedorActivo.Checked = true;
            chkProveedorActivo.Text = "Proveedor activo";

            AgregarLabelModo();
            LimpiarFormulario();
        }

        private void CargarProveedores(string busqueda = null)
        {
            try
            {
                var proveedores = ProveedorRepository.Listar(busqueda);

                dgvProveedores.Rows.Clear();
                int numero = 1;

                foreach (var prov in proveedores)
                {
                    int index = dgvProveedores.Rows.Add();
                    DataGridViewRow row = dgvProveedores.Rows[index];

                    row.Cells["colNumero"].Value    = numero++;
                    row.Cells["colRUC"].Value       = prov.RUC;
                    row.Cells["colRazonSocial"].Value = prov.RazonSocial;
                    row.Cells["colTelefono"].Value  = prov.Telefono;
                    row.Cells["colEmail"].Value     = prov.Email;

                    if (prov.Activo)
                    {
                        row.Cells["colEstado"].Value            = "ACTIVO";
                        row.Cells["colEstado"].Style.ForeColor  = Color.FromArgb(39, 174, 96);
                    }
                    else
                    {
                        row.Cells["colEstado"].Value            = "INACTIVO";
                        row.Cells["colEstado"].Style.ForeColor  = Color.FromArgb(150, 160, 170);
                    }

                    row.Tag = prov.ProveedorID;
                }

                lblMostrar.Text = $"Mostrando {proveedores.Count} proveedor{(proveedores.Count != 1 ? "es" : "")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proveedores: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            _modoEdicion = false;
            _proveedorIDEdicion = null;
            ActualizarLabelModo();
            txtRUC.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            try
            {
                var proveedor = new Proveedor
                {
                    RUC = txtRUC.Text.Trim(),
                    RazonSocial = txtRazonSocial.Text.Trim(),
                    NombreComercial = txtNombreComercial.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Activo = chkProveedorActivo.Checked
                };

                bool resultado;

                if (_modoEdicion && _proveedorIDEdicion.HasValue)
                {
                    proveedor.ProveedorID = _proveedorIDEdicion.Value;
                    resultado = ProveedorRepository.Actualizar(proveedor);
                }
                else
                {
                    resultado = ProveedorRepository.Crear(proveedor);
                }

                if (resultado)
                {
                    MessageBox.Show(
                        _modoEdicion ? "Proveedor actualizado correctamente" : "Proveedor registrado correctamente",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarProveedores(txtBuscar.Text.Trim());
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el proveedor", "Error",
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
            LimpiarFormulario();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string ruc = txtRUC.Text.Trim();
            if (string.IsNullOrEmpty(ruc))
            {
                MessageBox.Show("Ingrese un RUC para buscar", "Validación");
                return;
            }

            var proveedor = ProveedorRepository.ObtenerPorRUC(ruc);
            if (proveedor != null)
            {
                CargarProveedorEnFormulario(proveedor);
                MessageBox.Show("Proveedor encontrado", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se encontró proveedor con ese RUC", "Búsqueda",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarProveedores(txtBuscar.Text.Trim());
        }

        private void DgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int proveedorID = Convert.ToInt32(dgvProveedores.Rows[e.RowIndex].Tag);
            string columnName = dgvProveedores.Columns[e.ColumnIndex].Name;

            if (columnName == "colEditar")
            {
                EditarProveedor(proveedorID);
            }
            else if (columnName == "colEliminar")
            {
                EliminarProveedor(proveedorID);
            }
        }

        private void EditarProveedor(int proveedorID)
        {
            var proveedor = ProveedorRepository.ObtenerPorID(proveedorID);
            if (proveedor != null)
            {
                CargarProveedorEnFormulario(proveedor);
            }
        }

        private void CargarProveedorEnFormulario(Proveedor proveedor)
        {
            _modoEdicion = true;
            _proveedorIDEdicion = proveedor.ProveedorID;

            txtRUC.Text = proveedor.RUC;
            txtRazonSocial.Text = proveedor.RazonSocial;
            txtNombreComercial.Text = proveedor.NombreComercial;
            txtDireccion.Text = proveedor.Direccion;
            txtTelefono.Text = proveedor.Telefono;
            txtEmail.Text = proveedor.Email;
            chkProveedorActivo.Checked = proveedor.Activo;

            ActualizarLabelModo();
        }

        private void EliminarProveedor(int proveedorID)
        {
            var proveedor = ProveedorRepository.ObtenerPorID(proveedorID);
            if (proveedor == null) return;

            var resultado = MessageBox.Show(
                $"¿Está seguro de eliminar al proveedor '{proveedor.RazonSocial}'?\n\nSi tiene compras asociadas, será desactivado en lugar de eliminado.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes) return;

            try
            {
                if (ProveedorRepository.Eliminar(proveedorID))
                {
                    MessageBox.Show("Proveedor eliminado/desactivado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProveedores(txtBuscar.Text.Trim());
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text))
            {
                MessageBox.Show("La razón social es obligatoria", "Validación");
                txtRazonSocial.Focus();
                return false;
            }

            string ruc = txtRUC.Text.Trim();
            if (!string.IsNullOrEmpty(ruc))
            {
                if (ruc.Length != 11 || !long.TryParse(ruc, out _))
                {
                    MessageBox.Show("El RUC debe tener 11 dígitos numéricos", "Validación");
                    txtRUC.Focus();
                    return false;
                }

                if (ProveedorRepository.ExisteRUC(ruc, _proveedorIDEdicion))
                {
                    MessageBox.Show("Ya existe un proveedor con este RUC", "Validación");
                    txtRUC.Focus();
                    return false;
                }
            }

            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(email) && !email.Contains("@"))
            {
                MessageBox.Show("Ingrese un email válido", "Validación");
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            _modoEdicion = false;
            _proveedorIDEdicion = null;

            txtRUC.Clear();
            txtRazonSocial.Clear();
            txtNombreComercial.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            chkProveedorActivo.Checked = true;
            ActualizarLabelModo();
        }

        private void TxtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ' && e.KeyChar != '-')
                e.Handled = true;
        }
    }
}
