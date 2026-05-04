using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Contactos
{
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            InicializarFiltros();
            ConfigurarDataGridView();
            ConfigurarEventos();
            CargarClientes();
        }

        private void InicializarFiltros()
        {
            cmbFiltrar.Items.Clear();
            cmbFiltrar.Items.Add("TODOS");
            cmbFiltrar.Items.Add("Persona_Natural");
            cmbFiltrar.Items.Add("Empresa");
            cmbFiltrar.SelectedIndex = 0;

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("TODOS");
            cmbEstado.Items.Add("PAGADO");
            cmbEstado.Items.Add("PENDIENTE");
            cmbEstado.SelectedIndex = 0;
        }

        private void ConfigurarDataGridView()
        {
            dgvClientes.AutoGenerateColumns = false;
            DgvStyleHelper.Aplicar(dgvClientes);
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.ReadOnly = true;
        }

        private void ConfigurarEventos()
        {
            txtBuscar.KeyPress += TxtBuscar_KeyPress;
            txtBuscar.TextChanged += (s, e) => CargarClientes(); // auto-trigger igual que los combos
            btnNuevoCliente.Click += BtnNuevoCliente_Click;
            dgvClientes.CellClick += DgvClientes_CellClick;
            cmbFiltrar.SelectedIndexChanged += Filtros_Changed;
            cmbEstado.SelectedIndexChanged += Filtros_Changed;
        }

        private void CargarClientes()
        {
            try
            {
                string buscar       = string.IsNullOrWhiteSpace(txtBuscar.Text) ? null : txtBuscar.Text.Trim();
                string filtroTipo   = cmbFiltrar.SelectedIndex == 0 ? null : cmbFiltrar.Text;
                string filtroEstado = cmbEstado.SelectedIndex == 0 ? null : cmbEstado.Text;

                var clientes = ClienteRepository.Listar(buscar, filtroTipo, filtroEstado);

                dgvClientes.Rows.Clear();

                int     totalActivos  = 0;
                int     conDeuda      = 0;
                decimal totalDeuda    = 0m;

                int numero = 1;
                foreach (var cliente in clientes)
                {
                    int index = dgvClientes.Rows.Add();
                    DataGridViewRow row = dgvClientes.Rows[index];

                    row.Cells["colNumero"].Value    = numero++;
                    row.Cells["colDocumento"].Value = cliente.TipoDocumento + " - " + cliente.NumeroDocumento;
                    row.Cells["colCliente"].Value   = cliente.NombreCompleto;
                    row.Cells["colEmail"].Value     = cliente.Email;
                    row.Cells["colTelefono"].Value  = cliente.Telefono;
                    row.Cells["colDireccion"].Value = cliente.Direccion;

                    decimal saldo = cliente.SaldoPendiente;
                    if (saldo > 0)
                    {
                        row.Cells["colSaldo"].Value            = "S/ " + saldo.ToString("N2");
                        row.Cells["colSaldo"].Style.ForeColor  = Color.FromArgb(211, 47, 47);
                        conDeuda++;
                        totalDeuda += saldo;
                    }
                    else if (saldo < 0)
                    {
                        row.Cells["colSaldo"].Value            = "-S/ " + Math.Abs(saldo).ToString("N2");
                        row.Cells["colSaldo"].Style.ForeColor  = Color.FromArgb(39, 174, 96);
                    }
                    else
                    {
                        row.Cells["colSaldo"].Value            = "S/ 0.00";
                        row.Cells["colSaldo"].Style.ForeColor  = Color.FromArgb(100, 110, 120);
                    }

                    if (cliente.Activo)
                    {
                        row.Cells["colEstado"].Value            = "ACTIVO";
                        row.Cells["colEstado"].Style.ForeColor  = Color.FromArgb(39, 174, 96);
                        totalActivos++;
                    }
                    else
                    {
                        row.Cells["colEstado"].Value            = "INACTIVO";
                        row.Cells["colEstado"].Style.ForeColor  = Color.FromArgb(150, 160, 170);
                    }

                    row.Tag = cliente.ClienteID;
                }

                // Actualizar tarjetas de métricas
                lblCardVal1.Text = clientes.Count.ToString();
                lblCardVal2.Text = totalActivos.ToString();
                lblCardVal3.Text = conDeuda.ToString();
                lblCardVal4.Text = "S/ " + totalDeuda.ToString("N2");

                lblMostrar.Text = $"Mostrando {clientes.Count} cliente{(clientes.Count != 1 ? "s" : "")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int clienteID = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Tag);

            // Columna Editar
            if (e.ColumnIndex == dgvClientes.Columns["colEditar"].Index)
            {
                AbrirFormEditar(clienteID);
            }
            // Columna Eliminar
            else if (e.ColumnIndex == dgvClientes.Columns["colEliminar"].Index)
            {
                EliminarCliente(clienteID);
            }
        }

        private void EliminarCliente(int clienteID)
        {
            var usuarioActual = SesionActual.Usuario;
            if (usuarioActual == null || (!usuarioActual.PermisoEliminarRegistros && usuarioActual.RolID != 1))
            {
                MessageBox.Show("No tienes permiso para eliminar registros.", "Acceso denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prevenir eliminar cliente general
            if (clienteID == 1)
            {
                MessageBox.Show("No se puede eliminar el cliente general", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                "¿Está seguro de eliminar este cliente?\n\nNOTA: Solo se pueden eliminar clientes sin ventas asociadas.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    if (ClienteRepository.Eliminar(clienteID))
                    {
                        MessageBox.Show("Cliente eliminado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarClientes(); // Recargar lista
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnNuevoCliente_Click(object sender, EventArgs e)
        {
            var formDetalle = new FormClienteDetalle();
            if (formDetalle.ShowDialog() == DialogResult.OK)
            {
                CargarClientes();
            }
        }

        private void AbrirFormEditar(int clienteID)
        {
            var formDetalle = new FormClienteDetalle(clienteID);
            if (formDetalle.ShowDialog() == DialogResult.OK)
            {
                CargarClientes();
            }
        }

        private void TxtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CargarClientes();
                e.Handled = true;
            }
        }

        private void Filtros_Changed(object sender, EventArgs e)
        {
            CargarClientes();
        }
    }
}