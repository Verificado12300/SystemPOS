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
                DgvStyleHelper.Aplicar(dgvCuentas);
                dgvCuentas.AllowUserToAddRows  = false;
                dgvCuentas.ReadOnly = true;
                dgvCuentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                txtBuscar.KeyDown              += (s, ev) => { if (ev.KeyCode == Keys.Enter) CargarCuentas(); };
                btnExportar.Click              += BtnExportar_Click;
                cmbEstado.SelectedIndexChanged += (s, ev) => CargarCuentas();
                dtpDesde.ValueChanged          += (s, ev) => CargarCuentas();
                dtpHasta.ValueChanged          += (s, ev) => CargarCuentas();
                dgvCuentas.CellPainting        += DgvCuentas_CellPainting;

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

                string busqueda    = txtBuscar.Text.Trim();
                string estadoFiltro = cmbEstado.SelectedIndex > 0 ? cmbEstado.Text : null;

                var datos = CuentaPorPagarRepository.ListarAgrupadoPorProveedor(
                    string.IsNullOrWhiteSpace(busqueda) ? null : busqueda);

                int     numero         = 1;
                decimal totalPendiente = 0;
                int     totalDocs      = 0;
                int     provCount      = 0;

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
                    row.Cells["colDetalle"].Value        = "Ver detalle";

                    row.Tag = r.ProveedorID.HasValue ? (object)r.ProveedorID.Value : null;

                    totalPendiente += r.TotalPendiente;
                    totalDocs      += r.CantidadDocumentos;
                    provCount++;
                }

                lblTotalRegistros.Text  = $"{dgvCuentas.Rows.Count} proveedores";
                txtTotalPendiente.Text  = $"S/ {totalPendiente:N2}";
                // KPI cards
                lblKpi1Val.Text = $"S/ {totalPendiente:N2}";
                lblKpi2Val.Text = provCount.ToString();
                lblKpi3Val.Text = totalDocs.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cuentas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCuentas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCuentas.Columns[e.ColumnIndex].Name != "colEstado") return;

            e.PaintBackground(e.ClipBounds, true);

            string estado = e.Value?.ToString() ?? "";
            Color bgColor, fgColor;
            switch (estado)
            {
                case "PENDIENTE": bgColor = Color.FromArgb(254, 243, 199); fgColor = Color.FromArgb(146, 64, 14);  break;
                case "PARCIAL":   bgColor = Color.FromArgb(219, 234, 254); fgColor = Color.FromArgb(30, 64, 175);  break;
                case "PAGADO":    bgColor = Color.FromArgb(209, 250, 229); fgColor = Color.FromArgb(6, 95, 70);    break;
                case "ANULADO":   bgColor = Color.FromArgb(254, 226, 226); fgColor = Color.FromArgb(153, 27, 27);  break;
                default:          bgColor = Color.FromArgb(241, 245, 249); fgColor = Color.FromArgb(100, 116, 139); break;
            }

            var g = e.Graphics;
            var cb = e.CellBounds;
            int bH = 22; int bW = Math.Min(estado.Length * 8 + 18, cb.Width - 16);
            int bx = cb.X + (cb.Width - bW) / 2;
            int by = cb.Y + (cb.Height - bH) / 2;
            var badge = new Rectangle(bx, by, bW, bH);

            using (var br = new SolidBrush(bgColor)) g.FillRectangle(br, badge);
            using (var font = new Font("Segoe UI", 7.5F, FontStyle.Bold))
            using (var tb = new SolidBrush(fgColor))
            {
                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString(estado, font, tb, badge, sf);
            }
            e.Handled = true;
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
                var dt = ReportDataSourceHelper.ObtenerDatosCuentasPorPagar(null, estado);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay registros para generar el reporte.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var dataSources = new Dictionary<string, DataTable> { { "DsCuentasPagar", dt } };
                var parametros  = ReportHelper.GetCompanyParameters();
                parametros["pFiltro"] = $"Estado: {cmbEstado.Text}";

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Tabular\RptCuentasPorPagar.rdlc"),
                    dataSources, parametros, "cuentas_por_pagar");
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

                var row       = dgvCuentas.Rows[e.RowIndex];
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
