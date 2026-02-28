using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Reports.DataSources;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormCuentasPorPagar : Form
    {
        private List<Proveedor> _proveedores;

        public FormCuentasPorPagar()
        {
            InitializeComponent();
        }

        private void FormCuentasPorPagar_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarControles();
                CargarProveedores();
                CargarCuentas();

                btnExportar.Click += BtnExportar_Click;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar formulario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarControles()
        {
            cmbEstado.SelectedIndex = 0;
            cmbTipo.SelectedIndex = 0;
            cmbProveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbProveedor.AutoCompleteSource = AutoCompleteSource.ListItems;

            dgvCuentas.AutoGenerateColumns = false;
            dgvCuentas.AllowUserToAddRows = false;
            dgvCuentas.ReadOnly = true;
            dgvCuentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            colNumero.Width = 50;
            colTipo.Width = 70;
            colCompra.Width = 120;
            colProveedor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFechaCompra.Width = 100;
            colMontoTotal.Width = 100;
            colMontoPagado.Width = 100;
            colMontoPendiente.Width = 100;
            colVencimiento.Width = 100;
            colEstado.Width = 90;
            colVerPagos.Width = 80;
            colRegistrarPago.Width = 80;

            colMontoTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colMontoPagado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colMontoPendiente.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void CargarProveedores()
        {
            try
            {
                _proveedores = ProveedorRepository.Listar();
                cmbProveedor.Items.Clear();
                cmbProveedor.Items.Add("TODOS");
                foreach (var p in _proveedores)
                {
                    cmbProveedor.Items.Add($"{p.RazonSocial} - {p.RUC}");
                }
                cmbProveedor.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proveedores: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCuentas()
        {
            try
            {
                dgvCuentas.Rows.Clear();

                int? proveedorID = cmbProveedor.SelectedIndex > 0 ? GetProveedorID() : null;
                string estado     = cmbEstado.SelectedIndex > 0 ? cmbEstado.Text : null;
                string tipoOrigen = cmbTipo.SelectedIndex  > 0 ? cmbTipo.Text  : null;

                var cuentas = CuentaPorPagarRepository.Listar(proveedorID, estado, null, tipoOrigen);

                int numero = 1;
                decimal totalPendiente = 0;

                foreach (var cuenta in cuentas)
                {
                    int index = dgvCuentas.Rows.Add();
                    DataGridViewRow row = dgvCuentas.Rows[index];

                    row.Cells["colNumero"].Value    = numero++;
                    row.Cells["colTipo"].Value      = cuenta.TipoOrigen;
                    row.Cells["colCompra"].Value    = cuenta.Referencia;
                    row.Cells["colProveedor"].Value = cuenta.NombreProveedor;
                    row.Cells["colFechaCompra"].Value = cuenta.FechaOrigen != DateTime.MinValue
                        ? cuenta.FechaOrigen.ToString("dd/MM/yyyy")
                        : cuenta.FechaEmision;
                    row.Cells["colMontoTotal"].Value    = $"S/ {cuenta.MontoTotal:N2}";
                    row.Cells["colMontoPagado"].Value   = $"S/ {cuenta.MontoPagado:N2}";
                    row.Cells["colMontoPendiente"].Value = $"S/ {cuenta.MontoPendiente:N2}";
                    row.Cells["colVencimiento"].Value   = cuenta.FechaVencimiento?.ToString("dd/MM/yyyy") ?? "-";
                    row.Cells["colEstado"].Value        = cuenta.Estado;

                    row.Tag = cuenta.CuentaPorPagarID;
                    totalPendiente += cuenta.MontoPendiente;

                    // Color por estado
                    Color estadoColor = Color.Black;
                    switch (cuenta.Estado)
                    {
                        case "PENDIENTE": estadoColor = Color.FromArgb(243, 156, 18); break; // Naranja
                        case "PARCIAL":   estadoColor = Color.FromArgb(241, 196, 15); break; // Amarillo
                        case "PAGADO":    estadoColor = Color.FromArgb(39, 174, 96);  break; // Verde
                        case "ANULADO":   estadoColor = Color.FromArgb(149, 165, 166); break; // Gris
                    }
                    row.Cells["colEstado"].Style.ForeColor = estadoColor;
                    row.Cells["colEstado"].Style.Font = new Font(dgvCuentas.Font, FontStyle.Bold);

                    if (cuenta.Estado == "ANULADO")
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(149, 165, 166);
                }

                lblTotalRegistros.Text = $"Total: {cuentas.Count} registros";
                txtTotalPendiente.Text = $"S/ {totalPendiente:N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cuentas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? GetProveedorID()
        {
            if (cmbProveedor.SelectedIndex <= 0 || _proveedores == null)
                return null;
            return _proveedores[cmbProveedor.SelectedIndex - 1].ProveedorID;
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
                int? proveedorID = GetProveedorID();
                string estado = cmbEstado.SelectedIndex > 0 ? cmbEstado.Text : null;

                var dt = ReportDataSourceHelper.ObtenerDatosCuentasPorPagar(proveedorID, estado);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay registros para generar el reporte.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var dataSources = new Dictionary<string, DataTable> { { "DsCuentasPagar", dt } };
                var parametros = ReportHelper.GetCompanyParameters();
                parametros["pFiltro"] = $"Estado: {cmbEstado.Text} | Proveedor: {(cmbProveedor.SelectedIndex > 0 ? cmbProveedor.Text : "TODOS")}";

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

                if (dgvCuentas.Columns[e.ColumnIndex].Name == "colVerPagos")
                {
                    int cuentaID = Convert.ToInt32(dgvCuentas.Rows[e.RowIndex].Tag);
                    var form = new FormHistorialPagosCxP(cuentaID);
                    if (form.ShowDialog() == DialogResult.OK)
                        CargarCuentas();
                }
                else if (dgvCuentas.Columns[e.ColumnIndex].Name == "colRegistrarPago")
                {
                    int cuentaID = Convert.ToInt32(dgvCuentas.Rows[e.RowIndex].Tag);
                    FormRegistrarPagoProveedor form = new FormRegistrarPagoProveedor(cuentaID);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        CargarCuentas();
                    }
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
