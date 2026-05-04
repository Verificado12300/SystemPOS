using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Reports.DataSources;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Reportes
{
    public partial class FormFlujoCaja : Form
    {
        public FormFlujoCaja()
        {
            InitializeComponent();
        }

        private void FormFlujoCaja_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
            dtpHasta.Value = DateTime.Now;
            dgvFlujoCaja.AutoGenerateColumns = false;
            DgvStyleHelper.Aplicar(dgvFlujoCaja);
            dgvFlujoCaja.AllowUserToAddRows = false;
            dgvFlujoCaja.ReadOnly = true;
            btnExportar.Click += BtnExportar_Click;

            // Cargar automaticamente al abrir y al cambiar fechas
            dtpDesde.ValueChanged += (s, ev) => CargarDatos();
            dtpHasta.ValueChanged += (s, ev) => CargarDatos();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                dgvFlujoCaja.Rows.Clear();

                // Adaptar encabezados para vista por día desde asientos contables
                dgvFlujoCaja.Columns["colConcepto"].HeaderText  = "Fecha";
                dgvFlujoCaja.Columns["colIngresos"].HeaderText  = "Entradas";
                dgvFlujoCaja.Columns["colEgresos"].HeaderText   = "Salidas";
                dgvFlujoCaja.Columns["colFlujoNeto"].HeaderText = "Neto";

                var fc = ContabilidadService.ObtenerFlujoCaja(
                    dtpDesde.Value.Date, dtpHasta.Value.Date);

                // Detalle por día
                foreach (var dia in fc.DetallesPorDia)
                {
                    int idx = dgvFlujoCaja.Rows.Add(
                        dia.Fecha.ToString("dd/MM/yyyy"),
                        dia.Entradas > 0 ? $"S/ {dia.Entradas:N2}" : "-",
                        dia.Salidas  > 0 ? $"S/ {dia.Salidas:N2}"  : "-",
                        $"S/ {dia.Neto:N2}");
                    if (dia.Neto < 0)
                        dgvFlujoCaja.Rows[idx].DefaultCellStyle.ForeColor = Color.Red;
                }

                // Separador + desglose por origen (Caja / Bancos)
                if (fc.TotalEntradas > 0 || fc.TotalSalidas > 0)
                {
                    dgvFlujoCaja.Rows.Add("─────────────", "", "", "");

                    int iCaja = dgvFlujoCaja.Rows.Add(
                        "Caja (101)",
                        fc.EntradasCaja > 0 ? $"S/ {fc.EntradasCaja:N2}" : "-",
                        fc.SalidasCaja  > 0 ? $"S/ {fc.SalidasCaja:N2}"  : "-",
                        $"S/ {fc.EntradasCaja - fc.SalidasCaja:N2}");
                    dgvFlujoCaja.Rows[iCaja].DefaultCellStyle.Font =
                        new Font(dgvFlujoCaja.Font, FontStyle.Italic);

                    int iBancos = dgvFlujoCaja.Rows.Add(
                        "Bancos (102)",
                        fc.EntradasBancos > 0 ? $"S/ {fc.EntradasBancos:N2}" : "-",
                        fc.SalidasBancos  > 0 ? $"S/ {fc.SalidasBancos:N2}"  : "-",
                        $"S/ {fc.EntradasBancos - fc.SalidasBancos:N2}");
                    dgvFlujoCaja.Rows[iBancos].DefaultCellStyle.Font =
                        new Font(dgvFlujoCaja.Font, FontStyle.Italic);
                }

                lblTotalIngresos.Text      = $"S/ {fc.TotalEntradas:N2}";
                lblTotalEgresos.Text       = $"S/ {fc.TotalSalidas:N2}";
                lblFlujoNeto.Text          = $"S/ {fc.Neto:N2}";
                lblFlujoNeto.ForeColor     = fc.Neto >= 0 ? Color.Green : Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            ExportarReporte();
        }

        private void ExportarReporte()
        {
            if (dgvFlujoCaja.Rows.Count == 0)
            {
                MessageBox.Show("Primero genere el flujo de caja", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var dt = ReportDataSourceHelper.ObtenerDatosFlujoCaja(dtpDesde.Value, dtpHasta.Value);
                var dataSources = new Dictionary<string, DataTable> { { "DsFlujoCaja", dt } };
                var parameters = ReportHelper.GetCompanyParameters();
                parameters["pPeriodo"] = $"Período: {dtpDesde.Value:dd/MM/yyyy} - {dtpHasta.Value:dd/MM/yyyy}";

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Tabular\RptFlujoCaja.rdlc"),
                    dataSources, parameters, "flujo_caja");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
