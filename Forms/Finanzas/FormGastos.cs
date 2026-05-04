using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Reports.DataSources;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormGastos : Form
    {
        public FormGastos()
        {
            InitializeComponent();
        }

        private void FormGastos_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarControles();
                CargarCategorias();
                CargarGastos();
                btnExportar.Click += BtnExportar_Click;
                dgvGastos.CellPainting += DgvGastos_CellPainting;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar formulario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarControles()
        {
            // Configurar DateTimePicker con rango del último mes
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
            dtpHasta.Value = DateTime.Now;

            // Configurar DataGridView
            dgvGastos.AutoGenerateColumns = false;
            DgvStyleHelper.Aplicar(dgvGastos);
            dgvGastos.AllowUserToAddRows = false;
            dgvGastos.ReadOnly = true;
            dgvGastos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Configurar columnas
            colNumero.Width = 50;
            colFecha.Width = 100;
            colHora.Width = 80;
            colConcepto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCategoria.Width = 130;
            colMonto.Width = 100;
            colMonto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colMonto.DefaultCellStyle.Format = "N2";
            colMetodoPago.Width = 120;
            colComprobante.Width = 120;
            colEditar.Width = 70;
            colEliminar.Width = 70;
        }

        private void CargarCategorias()
        {
            try
            {
                cmbCategoria.Items.Clear();
                cmbCategoria.Items.Add("TODOS");
                foreach (var cat in GastoRepository.CategoriasDisponibles)
                {
                    cmbCategoria.Items.Add(cat);
                }
                cmbCategoria.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGastos()
        {
            try
            {
                dgvGastos.Rows.Clear();

                DateTime? fechaDesde = dtpDesde.Value.Date;
                DateTime? fechaHasta = dtpHasta.Value.Date;
                string categoria = cmbCategoria.SelectedIndex > 0 ? cmbCategoria.Text : null;

                var gastos = GastoRepository.Listar(fechaDesde, fechaHasta, categoria);

                int numero = 1;
                decimal totalGastos = 0;

                foreach (var gasto in gastos)
                {
                    int index = dgvGastos.Rows.Add();
                    DataGridViewRow row = dgvGastos.Rows[index];

                    row.Cells["colNumero"].Value = numero++;
                    row.Cells["colFecha"].Value = gasto.Fecha.ToString("dd/MM/yyyy");
                    row.Cells["colHora"].Value = gasto.Hora.ToString(@"hh\:mm");
                    row.Cells["colConcepto"].Value = gasto.Concepto;
                    row.Cells["colCategoria"].Value = gasto.Categoria;
                    row.Cells["colMonto"].Value = $"S/ {gasto.Monto:N2}";
                    row.Cells["colMetodoPago"].Value = gasto.MetodoPago;
                    row.Cells["colComprobante"].Value = string.IsNullOrEmpty(gasto.Comprobante) ? "-" : gasto.Comprobante;

                    row.Tag = gasto.GastoID;

                    totalGastos += gasto.Monto;
                }

                lblTotalRegistros.Text = $"{gastos.Count} registros encontrados";
                txtTotalGastos.Text = $"S/ {totalGastos:N2}";
                // KPI cards
                decimal promedio = gastos.Count > 0 ? totalGastos / gastos.Count : 0m;
                lblKpi1Val.Text = $"S/ {totalGastos:N2}";
                lblKpi2Val.Text = gastos.Count.ToString();
                lblKpi3Val.Text = $"S/ {promedio:N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar gastos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpDesde.Value > dtpHasta.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CargarGastos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                FormRegistrarGasto form = new FormRegistrarGasto();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CargarGastos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? fechaDesde = dtpDesde.Value.Date;
                DateTime? fechaHasta = dtpHasta.Value.Date;
                string categoria = cmbCategoria.SelectedIndex > 0 ? cmbCategoria.Text : null;

                var dt = ReportDataSourceHelper.ObtenerDatosGastos(fechaDesde, fechaHasta, categoria);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay gastos para exportar", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var dataSources = new Dictionary<string, DataTable>
                {
                    { "DsGastos", dt }
                };

                var parameters = ReportHelper.GetCompanyParameters();
                parameters["pPeriodo"] = $"Período: {dtpDesde.Value:dd/MM/yyyy} - {dtpHasta.Value:dd/MM/yyyy}";

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Tabular\RptGastosOperativos.rdlc"),
                    dataSources, parameters, "gastos_operativos");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvGastos_CellPainting(object sender, System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvGastos.Columns[e.ColumnIndex].Name != "colMetodoPago") return;

            e.PaintBackground(e.ClipBounds, true);

            string metodo = e.Value?.ToString() ?? "";
            Color bgColor, fgColor;
            switch (metodo)
            {
                case "EFECTIVO":     bgColor = Color.FromArgb(241, 245, 249); fgColor = Color.FromArgb(51, 65, 85); break;
                case "YAPE":         bgColor = Color.FromArgb(237, 233, 254); fgColor = Color.FromArgb(91, 33, 182); break;
                case "TRANSFERENCIA":bgColor = Color.FromArgb(219, 234, 254); fgColor = Color.FromArgb(30, 64, 175); break;
                case "TARJETA":      bgColor = Color.FromArgb(209, 250, 229); fgColor = Color.FromArgb(6, 95, 70);  break;
                case "CREDITO":      bgColor = Color.FromArgb(254, 243, 199); fgColor = Color.FromArgb(146, 64, 14); break;
                default:             bgColor = Color.FromArgb(241, 245, 249); fgColor = Color.FromArgb(100, 116, 139); break;
            }

            var g = e.Graphics;
            var cellBounds = e.CellBounds;
            int badgeH = 20; int badgeW = Math.Max(1, Math.Min(metodo.Length * 8 + 16, cellBounds.Width - 12));
            int bx = cellBounds.X + (cellBounds.Width - badgeW) / 2;
            int by = cellBounds.Y + (cellBounds.Height - badgeH) / 2;
            var badgeRect = new System.Drawing.Rectangle(bx, by, badgeW, badgeH);

            using (var brush = new System.Drawing.SolidBrush(bgColor))
                g.FillRectangle(brush, badgeRect);
            using (var font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold))
            using (var textBrush = new System.Drawing.SolidBrush(fgColor))
            {
                var sf = new System.Drawing.StringFormat { Alignment = System.Drawing.StringAlignment.Center, LineAlignment = System.Drawing.StringAlignment.Center };
                g.DrawString(metodo, font, textBrush, badgeRect, sf);
            }
            e.Handled = true;
        }

        private void DgvGastos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                // Columna Editar
                if (dgvGastos.Columns[e.ColumnIndex].Name == "colEditar")
                {
                    int gastoID = Convert.ToInt32(dgvGastos.Rows[e.RowIndex].Tag);
                    var gasto = GastoRepository.ObtenerPorID(gastoID);
                    if (gasto == null) return;

                    using (var form = new FormRegistrarGasto(gasto))
                    {
                        if (form.ShowDialog(this) == DialogResult.OK)
                            CargarGastos();
                    }
                    return;
                }

                // Columna Eliminar
                if (dgvGastos.Columns[e.ColumnIndex].Name == "colEliminar")
                {
                    int gastoID = Convert.ToInt32(dgvGastos.Rows[e.RowIndex].Tag);
                    string concepto = dgvGastos.Rows[e.RowIndex].Cells["colConcepto"].Value.ToString();

                    bool tieneImpacto = PapeleraService.TieneImpactoContable("GASTO", gastoID);
                    string msg = tieneImpacto
                        ? $"El gasto '{concepto}' tiene asiento contable.\n\nSe ANULARÁ (revertirá su efecto contable).\n\n¿Continuar?"
                        : $"El gasto '{concepto}' no tiene asiento contable.\n\nSe enviará a la PAPELERA (podrá recuperarse).\n\n¿Continuar?";

                    if (MessageBox.Show(msg, "Confirmar acción",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        GastoRepository.Eliminar(gastoID);
                        string ok = tieneImpacto ? "Gasto anulado correctamente." : "Gasto enviado a la papelera.";
                        MessageBox.Show(ok, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGastos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar acción: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
