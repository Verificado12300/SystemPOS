using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaPOS.Data;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormCuentasPorCobrar : Form
    {
        public FormCuentasPorCobrar()
        {
            InitializeComponent();
        }

        private void FormCuentasPorCobrar_Load(object sender, EventArgs e)
        {
            try
            {
                cmbEstado.SelectedIndex = 0;
                dgvCuentas.AutoGenerateColumns = false;
                dgvCuentas.AllowUserToAddRows  = false;
                dgvCuentas.ReadOnly            = true;
                dgvCuentas.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;

                txtBuscar.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) CargarCuentas(); };

                CargarCuentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar formulario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────
        // Carga principal
        // ─────────────────────────────────────────────────────────────

        private void CargarCuentas()
        {
            try
            {
                dgvCuentas.Rows.Clear();

                string busqueda     = txtBuscar.Text.Trim();
                string estadoFiltro = cmbEstado.SelectedIndex > 0 ? cmbEstado.Text : null;

                var datos = CuentaPorCobrarRepository.ListarAgrupadoPorCliente(
                    string.IsNullOrWhiteSpace(busqueda) ? null : busqueda);

                int     numero         = 1;
                decimal totalPendiente = 0;

                foreach (var r in datos)
                {
                    if (!string.IsNullOrEmpty(estadoFiltro) && r.Estado != estadoFiltro)
                        continue;

                    int idx = dgvCuentas.Rows.Add();
                    var row = dgvCuentas.Rows[idx];

                    row.Cells["colNumero"].Value         = numero++;
                    row.Cells["colCliente"].Value        = r.NombreCliente;
                    row.Cells["colDocumentos"].Value     = r.CantidadDocumentos;
                    row.Cells["colTotalVentas"].Value    = $"S/ {r.TotalVentas:N2}";
                    row.Cells["colTotalPagado"].Value    = $"S/ {r.TotalPagado:N2}";
                    row.Cells["colTotalPendiente"].Value = $"S/ {r.TotalPendiente:N2}";
                    row.Cells["colEstado"].Value         = r.Estado;
                    row.Cells["colDetalle"].Value        = "Detalle";

                    row.Tag = r.ClienteID;

                    totalPendiente += r.TotalPendiente;

                    Color estadoColor = r.Estado == "PENDIENTE"
                        ? Color.FromArgb(243, 156, 18)   // naranja
                        : Color.FromArgb(39, 174, 96);   // verde
                    row.Cells["colEstado"].Style.ForeColor = estadoColor;
                    row.Cells["colEstado"].Style.Font      = new Font(dgvCuentas.Font, FontStyle.Bold);
                }

                lblTotalRegistros.Text = $"Total: {dgvCuentas.Rows.Count} clientes";
                txtTotalPendiente.Text = $"S/ {totalPendiente:N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cuentas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────
        // Eventos
        // ─────────────────────────────────────────────────────────────

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            CargarCuentas();
        }

        private void DgvCuentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if (dgvCuentas.Columns[e.ColumnIndex].Name != "colDetalle") return;

                var row      = dgvCuentas.Rows[e.RowIndex];
                int clienteID = Convert.ToInt32(row.Tag);

                using (var form = new Contactos.FormEstadoCuenta(clienteID))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                        CargarCuentas();
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
