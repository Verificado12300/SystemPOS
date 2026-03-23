using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Reports.DataSources;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormCuentasPorPagar : Form
    {
        public FormCuentasPorPagar()
        {
            InitializeComponent();
        }

        private void FormCuentasPorPagar_Load(object sender, EventArgs e)
        {
            try
            {
                cmbEstado.SelectedIndex = 0;
                dgvCuentas.AutoGenerateColumns = false;
                dgvCuentas.AllowUserToAddRows  = false;
                dgvCuentas.ReadOnly = true;
                dgvCuentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                txtBuscar.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) CargarCuentas(); };
                btnExportar.Click += BtnExportar_Click;

                CargarCuentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar formulario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCuentas()
        {
            try
            {
                dgvCuentas.Rows.Clear();

                string busqueda = txtBuscar.Text.Trim();
                string estadoFiltro = cmbEstado.SelectedIndex > 0 ? cmbEstado.Text : null;

                var datos = CuentaPorPagarRepository.ListarAgrupadoPorProveedor(
                    string.IsNullOrWhiteSpace(busqueda) ? null : busqueda);

                int numero = 1;
                decimal totalPendiente = 0;

                foreach (var r in datos)
                {
                    if (!string.IsNullOrEmpty(estadoFiltro) && r.Estado != estadoFiltro)
                        continue;

                    int idx = dgvCuentas.Rows.Add();
                    var row = dgvCuentas.Rows[idx];

                    row.Cells["colNumero"].Value         = numero++;
                    row.Cells["colProveedor"].Value      = r.NombreProveedor;
                    row.Cells["colDocumentos"].Value     = r.CantidadDocumentos;
                    row.Cells["colTotalCompras"].Value   = $"S/ {r.TotalCompras:N2}";
                    row.Cells["colTotalPagado"].Value    = $"S/ {r.TotalPagado:N2}";
                    row.Cells["colTotalPendiente"].Value = $"S/ {r.TotalPendiente:N2}";
                    row.Cells["colEstado"].Value         = r.Estado;
                    row.Cells["colDetalle"].Value        = "Detalle";

                    // Tag = ProveedorID (int? serializado como object)
                    row.Tag = r.ProveedorID.HasValue ? (object)r.ProveedorID.Value : null;

                    totalPendiente += r.TotalPendiente;

                    Color estadoColor = r.Estado == "PENDIENTE"
                        ? Color.FromArgb(243, 156, 18)   // naranja
                        : Color.FromArgb(39, 174, 96);   // verde
                    row.Cells["colEstado"].Style.ForeColor = estadoColor;
                    row.Cells["colEstado"].Style.Font = new Font(dgvCuentas.Font, FontStyle.Bold);
                }

                lblTotalRegistros.Text = $"Total: {dgvCuentas.Rows.Count} proveedores";
                txtTotalPendiente.Text = $"S/ {totalPendiente:N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cuentas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            CargarCuentas();
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            try
            {
                string estado = cmbEstado.SelectedIndex > 0 ? cmbEstado.Text : null;

                // El reporte existente sigue usando la vista plana por documento
                var dt = ReportDataSourceHelper.ObtenerDatosCuentasPorPagar(null, estado);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay registros para generar el reporte.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var dataSources = new Dictionary<string, DataTable> { { "DsCuentasPagar", dt } };
                var parametros = ReportHelper.GetCompanyParameters();
                parametros["pFiltro"] = $"Estado: {cmbEstado.Text}";

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Tabular\RptCuentasPorPagar.rdlc"),
                    dataSources,
                    parametros,
                    "cuentas_por_pagar");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCuentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if (dgvCuentas.Columns[e.ColumnIndex].Name != "colDetalle") return;

                var row = dgvCuentas.Rows[e.RowIndex];
                int? proveedorID = row.Tag != null ? (int?)Convert.ToInt32(row.Tag) : null;
                string nombre = row.Cells["colProveedor"].Value?.ToString() ?? "Sin proveedor";

                using (var form = new FormEstadoCuentaProveedor(proveedorID, nombre))
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
