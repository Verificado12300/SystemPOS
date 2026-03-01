using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Reports.DataSources;
using SistemaPOS.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormCuentasPorCobrar : Form
    {
        private List<dynamic> _clientes = new List<dynamic>();
        private List<CuentaPorCobrarDetalle> _data = new List<CuentaPorCobrarDetalle>();

        public FormCuentasPorCobrar()
        {
            InitializeComponent();
            ConfigurarControles();
            CargarClientes();
            CargarCuentas();
        }

        private void ConfigurarControles()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new object[] { "TODOS", "PENDIENTE", "PARCIAL", "VENCIDO", "PAGADO" });
            cmbEstado.SelectedIndex = 0;

            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;

            btnBuscar.Click += (_, __) => CargarCuentas();
            btnEstadoCuenta.Click += (_, __) => AbrirEstadoCuenta();
            btnExportar.Click += BtnExportar_Click;
        }

        private void CargarClientes()
        {
            _clientes = ClienteRepository.Listar();
            cmbCliente.Items.Clear();
            cmbCliente.Items.Add("TODOS");
            foreach (var c in _clientes)
                cmbCliente.Items.Add($"{c.NombreCompleto} - {c.NumeroDocumento}");
            cmbCliente.SelectedIndex = 0;
        }

        private void CargarCuentas()
        {
            int? clienteID = cmbCliente.SelectedIndex > 0 ? (int?)_clientes[cmbCliente.SelectedIndex - 1].ClienteID : null;
            string estado = cmbEstado.SelectedItem?.ToString() ?? "TODOS";
            string busqueda = txtBuscar.Text?.Trim();
            bool soloVencidas = chkSoloVencidas.Checked;

            _data = CuentaPorCobrarRepository.Listar(clienteID, estado, busqueda, soloVencidas);
            dgv.Rows.Clear();

            decimal totalPendiente = 0m;
            int vencidas = 0;

            foreach (var c in _data)
            {
                int i = dgv.Rows.Add();
                var row = dgv.Rows[i];
                row.Tag = c.VentaID;
                row.Cells["colVenta"].Value = c.NumeroVenta;
                row.Cells["colCliente"].Value = c.NombreCliente;
                row.Cells["colFecha"].Value = c.FechaVenta.ToString("dd/MM/yyyy");
                row.Cells["colVence"].Value = c.FechaVencimiento.ToString("dd/MM/yyyy");
                row.Cells["colDias"].Value = c.DiasVencidos > 0 ? c.DiasVencidos.ToString() : "-";
                row.Cells["colTotal"].Value = $"S/ {c.TotalCredito:N2}";
                row.Cells["colPagado"].Value = $"S/ {c.MontoPagado:N2}";
                row.Cells["colSaldo"].Value = $"S/ {c.SaldoPendiente:N2}";
                row.Cells["colEstado"].Value = c.Estado;

                var font = new System.Drawing.Font(dgv.Font, System.Drawing.FontStyle.Bold);
                row.Cells["colEstado"].Style.Font = font;

                if (c.Estado == "VENCIDO")
                    row.Cells["colEstado"].Style.ForeColor = System.Drawing.Color.FromArgb(214, 48, 49);
                else if (c.Estado == "PARCIAL")
                    row.Cells["colEstado"].Style.ForeColor = System.Drawing.Color.FromArgb(225, 112, 85);
                else if (c.Estado == "PENDIENTE")
                    row.Cells["colEstado"].Style.ForeColor = System.Drawing.Color.FromArgb(243, 156, 18);
                else
                    row.Cells["colEstado"].Style.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);

                totalPendiente += c.SaldoPendiente;
                if (c.Estado == "VENCIDO") vencidas++;
            }

            lblResumen.Text = $"Registros: {_data.Count} | Vencidas: {vencidas} | Total pendiente: S/ {totalPendiente:N2}";
        }

        private void AbrirEstadoCuenta()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una cuenta para ver el estado de cuenta del cliente.", "Cobros",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int ventaID = (int)dgv.SelectedRows[0].Tag;
            var cuenta = _data.Find(x => x.VentaID == ventaID);
            if (cuenta == null) return;

            using (var form = new Contactos.FormEstadoCuenta(cuenta.ClienteID))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    CargarCuentas();
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            try
            {
                int? clienteID = cmbCliente.SelectedIndex > 0 ? (int?)_clientes[cmbCliente.SelectedIndex - 1].ClienteID : null;
                string estado = cmbEstado.SelectedItem?.ToString() ?? "TODOS";
                string busqueda = txtBuscar.Text?.Trim();
                bool soloVencidas = chkSoloVencidas.Checked;

                DataTable dt = ReportDataSourceHelper.ObtenerDatosCuentasPorCobrar(clienteID, estado, busqueda, soloVencidas);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para generar el reporte.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var dataSources = new Dictionary<string, DataTable> { { "DsCuentasCobrar", dt } };
                var parametros = ReportHelper.GetCompanyParameters();
                parametros["pFiltro"] = $"Estado: {estado} | Vencidas: {(soloVencidas ? "Sí" : "No")} | Búsqueda: {(string.IsNullOrWhiteSpace(busqueda) ? "-" : busqueda)}";

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Tabular\RptCuentasPorCobrar.rdlc"),
                    dataSources,
                    parametros,
                    "cuentas_por_cobrar");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
