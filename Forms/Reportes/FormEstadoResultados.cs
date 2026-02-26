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
    public partial class FormEstadoResultados : Form
    {
        public FormEstadoResultados()
        {
            InitializeComponent();
        }

        private void FormEstadoResultados_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
            dtpHasta.Value = DateTime.Now;
            dgvEstadoResultados.AutoGenerateColumns = false;
            dgvEstadoResultados.AllowUserToAddRows = false;
            dgvEstadoResultados.ReadOnly = true;
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
                dgvEstadoResultados.Rows.Clear();
                var er = ContabilidadService.ObtenerEstadoResultados(
                    dtpDesde.Value.Date, dtpHasta.Value.Date);

                // INGRESOS
                int idx = dgvEstadoResultados.Rows.Add("INGRESOS", "");
                dgvEstadoResultados.Rows[idx].DefaultCellStyle.Font =
                    new Font(dgvEstadoResultados.Font, FontStyle.Bold);

                dgvEstadoResultados.Rows.Add("  Ventas", $"S/ {er.Ventas:N2}");

                // COSTOS
                idx = dgvEstadoResultados.Rows.Add("COSTOS", "");
                dgvEstadoResultados.Rows[idx].DefaultCellStyle.Font =
                    new Font(dgvEstadoResultados.Font, FontStyle.Bold);

                dgvEstadoResultados.Rows.Add("  Costo de Ventas", $"S/ {er.CostoVentas:N2}");

                // UTILIDAD BRUTA
                idx = dgvEstadoResultados.Rows.Add("UTILIDAD BRUTA", $"S/ {er.UtilidadBruta:N2}");
                dgvEstadoResultados.Rows[idx].DefaultCellStyle.Font =
                    new Font(dgvEstadoResultados.Font, FontStyle.Bold);
                dgvEstadoResultados.Rows[idx].DefaultCellStyle.ForeColor =
                    er.UtilidadBruta >= 0 ? Color.Green : Color.Red;

                // GASTOS OPERATIVOS
                idx = dgvEstadoResultados.Rows.Add("GASTOS OPERATIVOS", "");
                dgvEstadoResultados.Rows[idx].DefaultCellStyle.Font =
                    new Font(dgvEstadoResultados.Font, FontStyle.Bold);

                dgvEstadoResultados.Rows.Add("  Total Gastos", $"S/ {er.Gastos:N2}");

                // UTILIDAD OPERATIVA
                idx = dgvEstadoResultados.Rows.Add("UTILIDAD OPERATIVA", $"S/ {er.UtilidadOperativa:N2}");
                dgvEstadoResultados.Rows[idx].DefaultCellStyle.Font =
                    new Font(dgvEstadoResultados.Font, FontStyle.Bold | FontStyle.Italic);
                dgvEstadoResultados.Rows[idx].DefaultCellStyle.ForeColor =
                    er.UtilidadOperativa >= 0
                        ? Color.FromArgb(39, 174, 96)
                        : Color.FromArgb(192, 57, 43);
                dgvEstadoResultados.Rows[idx].DefaultCellStyle.BackColor =
                    Color.FromArgb(240, 240, 240);
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
            if (dgvEstadoResultados.Rows.Count == 0)
            {
                MessageBox.Show("Primero genere el estado de resultados", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var dt = ReportDataSourceHelper.ObtenerDatosEstadoResultados(dtpDesde.Value, dtpHasta.Value);
                var dataSources = new Dictionary<string, DataTable> { { "DsEstadoResultados", dt } };
                var parameters = ReportHelper.GetCompanyParameters();
                parameters["pPeriodo"] = $"Período: {dtpDesde.Value:dd/MM/yyyy} - {dtpHasta.Value:dd/MM/yyyy}";

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Tabular\RptEstadoResultados.rdlc"),
                    dataSources, parameters, "estado_resultados");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
