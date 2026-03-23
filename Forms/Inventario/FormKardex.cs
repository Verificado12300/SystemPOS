using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Reports.DataSources;
using SistemaPOS.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SistemaPOS.Forms.Inventario
{
    public partial class FormKardex : Form
    {
        private List<dynamic> _productos;
        private List<KardexMovimiento> _ultimoResultado = new List<KardexMovimiento>();

        public FormKardex()
        {
            InitializeComponent();
            ConfigurarControles();
            CargarProductos();
            CargarKardex();
        }

        private void ConfigurarControles()
        {
            cmbMetodo.Items.Clear();
            cmbMetodo.Items.AddRange(new object[] { "PROMEDIO", "PEPS" });
            cmbMetodo.SelectedIndex = 0;

            dgvKardex.Columns["colPresentaciones"].Visible = false;
            chkVerPresentacion.CheckedChanged += (_, __) =>
                dgvKardex.Columns["colPresentaciones"].Visible = chkVerPresentacion.Checked;

            btnBuscar.Click += (_, __) => CargarKardex();
            btnLimpiar.Click += (_, __) =>
            {
                cmbProducto.SelectedIndex = 0;
                cmbMetodo.SelectedIndex = 0;
                dtpDesde.Value = DateTime.Now.AddMonths(-1);
                dtpHasta.Value = DateTime.Now;
                CargarKardex();
            };
            btnExportar.Click += (_, __) => ExportarReporte();
            btnVerAjustes.Click += (_, __) => new FormAjustes().ShowDialog(this);

            dgvKardex.AutoGenerateColumns = false;
            dgvKardex.AllowUserToAddRows = false;
            dgvKardex.AllowUserToDeleteRows = false;
            dgvKardex.ReadOnly = true;
            dgvKardex.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKardex.RowHeadersVisible = false;
            dgvKardex.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKardex.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvKardex.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKardex.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvKardex.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void CargarProductos()
        {
            _productos = KardexRepository.ListarProductos();
            cmbProducto.Items.Clear();
            cmbProducto.Items.Add("TODOS");

            foreach (var p in _productos)
                cmbProducto.Items.Add($"{p.Codigo} - {p.Nombre}");

            cmbProducto.SelectedIndex = 0;
            dtpHasta.Value = DateTime.Now;
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
        }

        private void CargarKardex()
        {
            try
            {
                if (dtpDesde.Value.Date > dtpHasta.Value.Date)
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser mayor que 'Hasta'.", "Validacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int? productoID = ObtenerProductoSeleccionadoID();
                string metodo = cmbMetodo.SelectedItem?.ToString() ?? "PROMEDIO";
                List<KardexMovimiento> data = KardexRepository.ObtenerMovimientos(
                    productoID, dtpDesde.Value.Date, dtpHasta.Value.Date, metodo);
                _ultimoResultado = data;

                dgvKardex.Rows.Clear();
                decimal totalEntradas = 0m;
                decimal totalSalidas = 0m;

                string unidad = data.Count > 0 ? (data[0].UnidadSimbolo ?? "") : "";
                ActualizarHeadersKardex(unidad);

                foreach (var item in data)
                {
                    int row = dgvKardex.Rows.Add();
                    dgvKardex.Rows[row].Cells["colFecha"].Value = item.FechaHora.ToString("dd/MM/yyyy HH:mm");
                    dgvKardex.Rows[row].Cells["colProducto"].Value = item.ProductoNombre;
                    dgvKardex.Rows[row].Cells["colTipo"].Value = item.TipoMovimiento;
                    dgvKardex.Rows[row].Cells["colDocumento"].Value = item.Documento;
                    dgvKardex.Rows[row].Cells["colUsuario"].Value = item.UsuarioNombre;
                    dgvKardex.Rows[row].Cells["colPresentaciones"].Value = item.PresentacionInfo ?? "";
                    dgvKardex.Rows[row].Cells["colEntrada"].Value = item.Entrada == 0 ? "-" : $"{item.Entrada:N2}";
                    dgvKardex.Rows[row].Cells["colSalida"].Value = item.Salida == 0 ? "-" : $"{item.Salida:N2}";
                    dgvKardex.Rows[row].Cells["colStockPosterior"].Value = $"{item.StockPosterior:N2}";
                    dgvKardex.Rows[row].Cells["colCostoUnit"].Value =
                        item.CostoUnitario == 0 ? "-" : $"S/ {item.CostoUnitario:N2}";
                    dgvKardex.Rows[row].Cells["colValorMovimiento"].Value =
                        item.CostoMovimiento == 0 ? "-" : $"S/ {item.CostoMovimiento:N2}";
                    dgvKardex.Rows[row].Cells["colCostoPromedio"].Value = $"S/ {item.CostoPromedio:N2}";

                    totalEntradas += item.Entrada;
                    totalSalidas += item.Salida;
                }

                string u = UiUnitsHelper.NormalizeUnit(unidad);
                lblResumen.Text = $"Movimientos: {data.Count} | Entradas: {totalEntradas:N2} {u} | Salidas: {totalSalidas:N2} {u} | Método: {metodo}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar kardex: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarReporte()
        {
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            try
            {
                if (dtpDesde.Value.Date > dtpHasta.Value.Date)
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser mayor que 'Hasta'.", "Validacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int? productoID = ObtenerProductoSeleccionadoID();

                string metodo = cmbMetodo.SelectedItem?.ToString() ?? "PROMEDIO";
                DataTable dt = ReportDataSourceHelper.ObtenerDatosKardex(
                    productoID, dtpDesde.Value.Date, dtpHasta.Value.Date, metodo);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay movimientos para generar reporte.", "Kardex",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var dataSources = new Dictionary<string, DataTable> { { "DsKardex", dt } };
                var parametros = ReportHelper.GetCompanyParameters();
                parametros["pPeriodo"] = $"Periodo: {dtpDesde.Value:dd/MM/yyyy} - {dtpHasta.Value:dd/MM/yyyy}";
                parametros["pMetodoValorizacion"] = metodo;
                parametros["pProducto"] = ObtenerProductoSeleccionadoNombre();

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Tabular\RptKardex.rdlc"),
                    dataSources,
                    parametros,
                    "kardex_inventario");
            }
            catch (Exception ex)
            {
                string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "kardex_export_error.log");
                try
                {
                    File.WriteAllText(logPath,
                        $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}{Environment.NewLine}{ex}{Environment.NewLine}");
                }
                catch { }

                string detalle = ex.Message;
                if (ex.InnerException != null)
                    detalle += "\n" + ex.InnerException.Message;

                MessageBox.Show($"Error al generar reporte de kardex: {detalle}\n\nDetalle en: {logPath}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? ObtenerProductoSeleccionadoID()
        {
            int index = cmbProducto.SelectedIndex - 1;
            if (index < 0 || _productos == null || index >= _productos.Count)
                return null;

            return _productos[index].ProductoID;
        }

        private string ObtenerProductoSeleccionadoNombre()
        {
            int index = cmbProducto.SelectedIndex - 1;
            if (index < 0 || _productos == null || index >= _productos.Count)
                return "Todos";

            return _productos[index].Nombre?.ToString() ?? "Todos";
        }

        private void ActualizarHeadersKardex(string simbolo)
        {
            dgvKardex.Columns["colEntrada"].HeaderText        = UiUnitsHelper.FormatQtyHeader("Entrada", simbolo);
            dgvKardex.Columns["colSalida"].HeaderText         = UiUnitsHelper.FormatQtyHeader("Salida", simbolo);
            dgvKardex.Columns["colStockPosterior"].HeaderText = UiUnitsHelper.FormatQtyHeader("Stock", simbolo);
            dgvKardex.Columns["colCostoUnit"].HeaderText      = UiUnitsHelper.FormatMoneyPerUnit("Costo unitario", simbolo);
            dgvKardex.Columns["colCostoPromedio"].HeaderText  = UiUnitsHelper.FormatMoneyPerUnit("Costo promedio", simbolo);
        }
    }
}
