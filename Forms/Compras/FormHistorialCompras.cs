using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Forms.Shared;
using SistemaPOS.Reports.DataSources;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Compras
{
    public partial class FormHistorialCompras : Form
    {
        private List<Models.Proveedor> _proveedores;

        public FormHistorialCompras()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            ConfigurarEventos();
            ConfigurarDataGridView();
            InicializarFiltros();
            CargarProveedores();
            CargarCompras();
        }

        private void ConfigurarEventos()
        {
            btnBuscar.Click += BtnBuscar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
            btnExportar.Click += BtnExportar_Click;
            btnCerrar.Click += (s, e) => this.Close();
            dgvCompras.CellClick += DgvCompras_CellClick;
            dgvCompras.CellPainting += DgvCompras_CellPainting;

            // Buscar al presionar Enter en los filtros
            cmbProveedor.KeyDown += Filtros_KeyDown;
            cmbEstado.KeyDown += Filtros_KeyDown;
            cmbTipoComprobante.KeyDown += Filtros_KeyDown;
            txtNumComprobante.KeyDown += Filtros_KeyDown;

            // Buscar al cambiar selecciÃ³n en combos o al perder foco en textbox
            cmbProveedor.SelectedIndexChanged += (s, e) => CargarCompras();
            cmbEstado.SelectedIndexChanged += (s, e) => CargarCompras();
            cmbTipoComprobante.SelectedIndexChanged += (s, e) => CargarCompras();
            dtpDesde.ValueChanged += (s, e) => CargarCompras();
            dtpHasta.ValueChanged += (s, e) => CargarCompras();
            txtNumComprobante.Leave += (s, e) => CargarCompras();
        }

        private void Filtros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarCompras();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.AllowUserToAddRows  = false;
            dgvCompras.ReadOnly            = true;
            dgvCompras.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;

            // ── Estilo profesional ──────────────────────────────────────
            dgvCompras.BorderStyle            = BorderStyle.None;
            dgvCompras.BackgroundColor        = Color.White;
            dgvCompras.GridColor              = Color.FromArgb(235, 237, 240);
            dgvCompras.RowHeadersVisible      = false;
            dgvCompras.RowTemplate.Height     = 44;
            dgvCompras.Font                   = new Font("Segoe UI", 9.5F);
            dgvCompras.DefaultCellStyle.Font  = new Font("Segoe UI", 9.5F);
            dgvCompras.DefaultCellStyle.ForeColor = Color.FromArgb(45, 52, 54);
            dgvCompras.DefaultCellStyle.Padding   = new Padding(8, 0, 4, 0);
            dgvCompras.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 253);

            dgvCompras.ColumnHeadersDefaultCellStyle.BackColor  = Color.FromArgb(30, 36, 40);
            dgvCompras.ColumnHeadersDefaultCellStyle.ForeColor  = Color.FromArgb(200, 210, 215);
            dgvCompras.ColumnHeadersDefaultCellStyle.Font       = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dgvCompras.ColumnHeadersDefaultCellStyle.Padding    = new Padding(8, 0, 4, 0);
            dgvCompras.ColumnHeadersHeight                       = 40;
            dgvCompras.ColumnHeadersHeightSizeMode               = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCompras.EnableHeadersVisualStyles                 = false;

            // ── Imagen transparente en columnas de acción (evita FormatException en ImageColumn con null) ──
            var imgAccion = new Bitmap(1, 1);
            imgAccion.SetPixel(0, 0, Color.Transparent);
            colVerDetalle.Image = imgAccion;
            colImprimir.Image   = imgAccion;
            colAnular.Image     = imgAccion;

            // ── DataError silencioso (evita diálogo del sistema ante errores de celda) ──
            dgvCompras.DataError += (s, e) => { e.ThrowException = false; };

            // ── Hover sin selección fija ─────────────────────────────────
            dgvCompras.RowPrePaint += (s, e) =>
            {
                e.PaintParts &= ~DataGridViewPaintParts.SelectionBackground;
            };
            dgvCompras.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                dgvCompras.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(235, 240, 255);
            };
            dgvCompras.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                dgvCompras.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty;
            };
        }

        private void InicializarFiltros()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("TODOS");
            cmbEstado.Items.Add("COMPLETADA");
            cmbEstado.Items.Add("CREDITO");
            cmbEstado.Items.Add("ANULADA");
            cmbEstado.SelectedIndex = 0;

            cmbTipoComprobante.Items.Clear();
            cmbTipoComprobante.Items.Add("TODOS");
            cmbTipoComprobante.Items.Add("FACTURA");
            cmbTipoComprobante.Items.Add("BOLETA");
            cmbTipoComprobante.Items.Add("GUIA");
            cmbTipoComprobante.SelectedIndex = 0;

            dtpHasta.Value = DateTime.Now;
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
        }

        private void CargarProveedores()
        {
            try
            {
                _proveedores = ProveedorRepository.ObtenerTodos();

                cmbProveedor.Items.Clear();
                cmbProveedor.Items.Add("TODOS");
                foreach (var p in _proveedores)
                    cmbProveedor.Items.Add(p.RazonSocial);

                cmbProveedor.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proveedores: {ex.Message}", "Error");
            }
        }

        private void CargarCompras()
        {
            try
            {
                int? proveedorID = null;
                if (cmbProveedor.SelectedIndex > 0)
                    proveedorID = _proveedores[cmbProveedor.SelectedIndex - 1].ProveedorID;

                string estado = cmbEstado.SelectedIndex == 0 ? null : cmbEstado.Text;
                string tipoComprobante = cmbTipoComprobante.SelectedIndex == 0 ? null : cmbTipoComprobante.Text;
                DateTime fechaDesde = dtpDesde.Value.Date;
                DateTime fechaHasta = dtpHasta.Value.Date;
                string numComprobante = txtNumComprobante.Text.Trim();
                string filtroNumero = string.IsNullOrEmpty(numComprobante) ? null : numComprobante;

                var compras = CompraRepository.Listar(proveedorID, estado, tipoComprobante, fechaDesde, fechaHasta, filtroNumero);

                dgvCompras.Rows.Clear();
                int numero = 1;
                decimal totalEfectivo = 0;
                decimal totalTransferencia = 0;
                decimal totalCredito = 0;
                decimal totalGeneral = 0;

                foreach (var compra in compras)
                {
                    int index = dgvCompras.Rows.Add();
                    DataGridViewRow row = dgvCompras.Rows[index];

                    row.Cells["colNumero"].Value = numero++;
                    row.Cells["colFechaHora"].Value = compra.Fecha.ToString("dd/MM/yyyy") + " " + compra.Hora.ToString(@"hh\:mm");
                    row.Cells["colComprobante"].Value = compra.TipoComprobante + "\n" + compra.NumeroCompra;
                    row.Cells["colProveedor"].Value = compra.NombreProveedor;
                    row.Cells["colItems"].Value = compra.CantidadItems.ToString() + " items";
                    row.Cells["colMetodoPago"].Value = compra.MetodoPago;
                    row.Cells["colTotal"].Value = "S/ " + compra.Total.ToString("N2");
                    row.Cells["colEstado"].Value = compra.Estado;

                    if (compra.Estado == "ANULADA")
                    {
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 160);
                        row.DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
                    }

                    row.Tag = compra.CompraID;

                    if (compra.Estado != "ANULADA")
                    {
                        totalGeneral += compra.Total;

                        if (compra.MetodoPago == "EFECTIVO")
                            totalEfectivo += compra.Total;
                        else if (compra.MetodoPago == "TRANSFERENCIA")
                            totalTransferencia += compra.Total;

                        if (compra.Estado == "CREDITO")
                            totalCredito += compra.Total;
                    }
                }

                lblOperaciones.Text = $"# Compras del período: {compras.Count}";
                txtEfectivoCantidad.Text = $"S/ {totalEfectivo:N2}";
                txtYapeCantidad.Text = "S/ 0.00";
                txtTransferenciaCantidad.Text = $"S/ {totalTransferencia:N2}";
                txtCreditoCantidad.Text = $"S/ {totalCredito:N2}";
                txtTotalCantidad.Text = $"S/ {totalGeneral:N2}";
                txtPorPagar.Text = $"S/ {totalCredito:N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar compras: {ex.Message}", "Error");
            }
        }

        private void DgvCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int compraID = Convert.ToInt32(dgvCompras.Rows[e.RowIndex].Tag);
            string estado = dgvCompras.Rows[e.RowIndex].Cells["colEstado"].Value.ToString();
            string columnName = dgvCompras.Columns[e.ColumnIndex].Name;

            if (columnName == "colVerDetalle")
            {
                var formDetalle = new FormDetalleCompra(compraID);
                formDetalle.ShowDialog();
            }
            else if (columnName == "colImprimir")
            {
                ImprimirCompra(compraID);
            }
            else if (columnName == "colAnular")
            {
                if (estado == "ANULADA")
                {
                    MessageBox.Show("Esta compra ya está anulada.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                AnularEliminarCompra(compraID);
            }
        }

        private void AnularEliminarCompra(int compraID)
        {
            bool tieneImpacto = PapeleraService.TieneImpactoContable("COMPRA", compraID);

            string mensaje = tieneImpacto
                ? "Esta compra tiene asiento contable o CxP activa.\n\nSe ANULARÁ (revertirá el stock y la contabilidad).\n\n¿Continuar?"
                : "Esta compra no tiene asiento contable.\n\nSe enviará a la PAPELERA (podrá recuperarse).\n\n¿Continuar?";

            if (MessageBox.Show(mensaje, "Confirmar acción",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                string usuario = SesionActual.Usuario?.NombreUsuario ?? "Sistema";
                CompraRepository.EliminarInteligente(compraID, usuario);
                string ok = tieneImpacto ? "Compra anulada correctamente." : "Compra enviada a la papelera.";
                MessageBox.Show(ok, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirCompra(int compraID)
        {
            try
            {
                var parametros = ReportHelper.GetCompanyParameters();
                var dt = ReportDataSourceHelper.ObtenerDatosDetalleCompra(compraID, parametros);

                var dataSources = new Dictionary<string, DataTable> { { "DsDetalleCompra", dt } };

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Documents\RptDetalleCompra.rdlc"),
                    dataSources, parametros, "detalle_compra");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCompras_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = dgvCompras.Columns[e.ColumnIndex].Name;
            if (col != "colEstado" && col != "colMetodoPago") return;

            e.PaintBackground(e.ClipBounds, true);

            string val = e.Value?.ToString() ?? "";
            Color bg, fg;

            if (col == "colEstado")
            {
                switch (val)
                {
                    case "COMPLETADA": bg = Color.FromArgb(209, 250, 229); fg = Color.FromArgb(6, 95, 70);    break;
                    case "CREDITO":    bg = Color.FromArgb(254, 243, 199); fg = Color.FromArgb(146, 64, 14);  break;
                    case "ANULADA":    bg = Color.FromArgb(254, 226, 226); fg = Color.FromArgb(153, 27, 27);  break;
                    default:           bg = Color.FromArgb(241, 245, 249); fg = Color.FromArgb(100, 116, 139); break;
                }
            }
            else // colMetodoPago
            {
                switch (val)
                {
                    case "EFECTIVO":      bg = Color.FromArgb(241, 245, 249); fg = Color.FromArgb(51, 65, 85);   break;
                    case "YAPE":          bg = Color.FromArgb(237, 233, 254); fg = Color.FromArgb(91, 33, 182);  break;
                    case "TRANSFERENCIA": bg = Color.FromArgb(219, 234, 254); fg = Color.FromArgb(30, 64, 175);  break;
                    case "TARJETA":       bg = Color.FromArgb(204, 251, 241); fg = Color.FromArgb(17, 94, 89);   break;
                    case "CREDITO":       bg = Color.FromArgb(254, 243, 199); fg = Color.FromArgb(146, 64, 14);  break;
                    default:              bg = Color.FromArgb(241, 245, 249); fg = Color.FromArgb(100, 116, 139); break;
                }
            }

            var g = e.Graphics;
            var cb = e.CellBounds;
            int bH = 22; int bW = Math.Min(val.Length * 8 + 18, cb.Width - 12);
            int bx = cb.X + (cb.Width - bW) / 2;
            int by = cb.Y + (cb.Height - bH) / 2;
            var badge = new Rectangle(bx, by, bW, bH);

            using (var br = new SolidBrush(bg)) g.FillRectangle(br, badge);
            using (var font = new Font("Segoe UI", 7.5F, FontStyle.Bold))
            using (var tb   = new SolidBrush(fg))
            {
                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString(val, font, tb, badge, sf);
            }
            e.Handled = true;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarCompras();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            cmbProveedor.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            cmbTipoComprobante.SelectedIndex = 0;
            txtNumComprobante.Clear();
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
            dtpHasta.Value = DateTime.Now;
            CargarCompras();
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = ObtenerDatosReporteCompras();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay compras para exportar", "InformaciÃ³n",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var dataSources = new Dictionary<string, DataTable> { { "DsCompras", dt } };
                var parameters = ReportHelper.GetCompanyParameters();
                parameters["pPeriodo"] = $"PerÃ­odo: {dtpDesde.Value:dd/MM/yyyy} - {dtpHasta.Value:dd/MM/yyyy}";

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Tabular\RptHistorialCompras.rdlc"),
                    dataSources, parameters, "historial_compras");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ObtenerDatosReporteCompras()
        {
            int? proveedorID = null;
            if (cmbProveedor.SelectedIndex > 0)
                proveedorID = _proveedores[cmbProveedor.SelectedIndex - 1].ProveedorID;

            string estado = cmbEstado.SelectedIndex == 0 ? null : cmbEstado.Text;
            string tipoComprobante = cmbTipoComprobante.SelectedIndex == 0 ? null : cmbTipoComprobante.Text;
            string numComprobante = txtNumComprobante.Text.Trim();
            string filtroNumero = string.IsNullOrEmpty(numComprobante) ? null : numComprobante;

            return ReportDataSourceHelper.ObtenerDatosHistorialCompras(
                proveedorID, estado, tipoComprobante, dtpDesde.Value.Date, dtpHasta.Value.Date, filtroNumero);
        }
    }
}

