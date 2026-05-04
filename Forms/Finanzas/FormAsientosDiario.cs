using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Reports.DataSources;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormAsientosDiario : Form
    {
        private List<dynamic> _todosLosAsientos = new List<dynamic>();
        private int _paginaActual = 1;
        private bool _columnasAsientosConfiguradas = false;
        private const int RegistrosPorPagina = 20;

        public FormAsientosDiario()
        {
            InitializeComponent();
            DgvStyleHelper.Aplicar(dgvAsientos);
            DgvStyleHelper.Aplicar(dgvDetalles);
            dtpDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpHasta.Value = DateTime.Today;
            CargarCombos();

            // Enter en campos de texto ejecuta la búsqueda
            txtBuscar.KeyDown   += FiltroKeyDown;
            txtMontoMin.KeyDown += FiltroKeyDown;
            txtMontoMax.KeyDown += FiltroKeyDown;

            // Cambio de fecha recarga automáticamente
            dtpDesde.ValueChanged += (s, e) => CargarAsientos();
            dtpHasta.ValueChanged += (s, e) => CargarAsientos();

            CargarAsientos();
        }

        private void FiltroKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarAsientos();
                e.SuppressKeyPress = true;
            }
        }

        // ─────────────────────────────────────────────────────────────
        // Combos
        // ─────────────────────────────────────────────────────────────

        private void CargarCombos()
        {
            try
            {
                cboTipoOperacion.Items.Clear();
                cboTipoOperacion.Items.Add("(TODOS)");
                foreach (var tipo in ContabilidadRepository.ObtenerTiposOperacion())
                    cboTipoOperacion.Items.Add(tipo);
                cboTipoOperacion.SelectedIndex = 0;

                cboCuenta.Items.Clear();
                cboCuenta.Items.Add(new CuentaItem { Codigo = "", Display = "(TODAS)" });
                foreach (var c in ContabilidadRepository.ObtenerCuentasActivas())
                {
                    var t = c.GetType();
                    string codigo  = (string)t.GetProperty("Codigo").GetValue(c, null);
                    string display = (string)t.GetProperty("Display").GetValue(c, null);
                    cboCuenta.Items.Add(new CuentaItem { Codigo = codigo, Display = display });
                }
                cboCuenta.SelectedIndex = 0;
                cboCuenta.DisplayMember = "Display";
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[AsientosDiario] CargarCombos: {ex.Message}");
            }
        }

        private sealed class CuentaItem
        {
            public string Codigo  { get; set; }
            public string Display { get; set; }
            public override string ToString() => Display;
        }

        // ─────────────────────────────────────────────────────────────
        // Búsqueda
        // ─────────────────────────────────────────────────────────────

        private void BtnBuscar_Click(object sender, EventArgs e) => CargarAsientos();

        private void CargarAsientos()
        {
            try
            {
                dgvAsientos.DataSource = null;
                dgvDetalles.DataSource = null;
                _columnasAsientosConfiguradas = false;

                string tipo = (cboTipoOperacion.SelectedIndex <= 0)
                    ? null
                    : cboTipoOperacion.SelectedItem as string;

                string cuenta = null;
                if (cboCuenta.SelectedItem is CuentaItem ci && !string.IsNullOrEmpty(ci.Codigo))
                    cuenta = ci.Codigo;

                string texto = string.IsNullOrWhiteSpace(txtBuscar.Text) ? null : txtBuscar.Text.Trim();

                decimal? montoMin = null;
                decimal? montoMax = null;
                if (decimal.TryParse(txtMontoMin.Text, out decimal mn) && mn > 0) montoMin = mn;
                if (decimal.TryParse(txtMontoMax.Text, out decimal mx) && mx > 0) montoMax = mx;

                _todosLosAsientos = ContabilidadRepository.ObtenerAsientos(
                    dtpDesde.Value, dtpHasta.Value,
                    tipo, cuenta, texto, montoMin, montoMax);

                lblTotalAsientos.Text = $"Total: {_todosLosAsientos.Count} asientos";

                _paginaActual = 1;
                MostrarPagina();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[AsientosDiario] CargarAsientos: {ex.Message}");
                lblTotalAsientos.Text = "Total: 0 asientos";
            }
        }

        // ─────────────────────────────────────────────────────────────
        // Paginación
        // ─────────────────────────────────────────────────────────────

        private void MostrarPagina()
        {
            int total       = _todosLosAsientos.Count;
            int totalPaginas = Math.Max(1, (int)Math.Ceiling(total / (double)RegistrosPorPagina));
            _paginaActual   = Math.Max(1, Math.Min(_paginaActual, totalPaginas));

            var pagina = _todosLosAsientos
                .Skip((_paginaActual - 1) * RegistrosPorPagina)
                .Take(RegistrosPorPagina)
                .ToList();

            dgvAsientos.DataSource = null;
            dgvAsientos.DataSource = pagina;

            if (!_columnasAsientosConfiguradas)
            {
                ConfigurarColumnasAsientos();
                _columnasAsientosConfiguradas = true;
            }

            lblPagina.Text       = $"Página {_paginaActual} de {totalPaginas}";
            btnAnterior.Enabled  = _paginaActual > 1;
            btnSiguiente.Enabled = _paginaActual < totalPaginas;
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (_paginaActual > 1)
            {
                _paginaActual--;
                MostrarPagina();
            }
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            int totalPaginas = Math.Max(1, (int)Math.Ceiling(_todosLosAsientos.Count / (double)RegistrosPorPagina));
            if (_paginaActual < totalPaginas)
            {
                _paginaActual++;
                MostrarPagina();
            }
        }

        // ─────────────────────────────────────────────────────────────
        // Configuración de columnas
        // ─────────────────────────────────────────────────────────────

        private void ConfigurarColumnasAsientos()
        {
            try
            {
                var cols = dgvAsientos.Columns;
                if (cols.Count == 0) return;

                foreach (DataGridViewColumn col in cols)
                    col.Visible = false;

                SetCol(cols, "AsientoID",     "ID",         50,  DataGridViewAutoSizeColumnMode.None);
                SetCol(cols, "Fecha",         "Fecha",      90,  DataGridViewAutoSizeColumnMode.None);
                SetCol(cols, "Hora",          "Hora",       60,  DataGridViewAutoSizeColumnMode.None);
                SetCol(cols, "TipoOperacion", "Tipo",       120, DataGridViewAutoSizeColumnMode.None);
                SetCol(cols, "Documento",     "Documento",  180, DataGridViewAutoSizeColumnMode.None);
                SetCol(cols, "Glosa",         "Glosa",      0,   DataGridViewAutoSizeColumnMode.Fill, 200);
                SetCol(cols, "TotalDebe",     "Debe",       110, DataGridViewAutoSizeColumnMode.None);
                SetCol(cols, "TotalHaber",    "Haber",      110, DataGridViewAutoSizeColumnMode.None);

                AlignRight(cols, "TotalDebe");
                AlignRight(cols, "TotalHaber");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ConfigurarColumnasAsientos]: {ex.Message}");
            }
        }

        private void ConfigurarColumnasDetalles()
        {
            try
            {
                var cols = dgvDetalles.Columns;
                if (cols.Count == 0) return;

                foreach (DataGridViewColumn col in cols)
                    col.Visible = false;

                SetCol(cols, "CuentaCodigo", "Código",      70,  DataGridViewAutoSizeColumnMode.None);
                SetCol(cols, "CuentaNombre", "Cuenta",      0,   DataGridViewAutoSizeColumnMode.Fill, 160);
                SetCol(cols, "CuentaTipo",   "Tipo",        80,  DataGridViewAutoSizeColumnMode.None);
                SetCol(cols, "Debe",         "Debe",        110, DataGridViewAutoSizeColumnMode.None);
                SetCol(cols, "Haber",        "Haber",       110, DataGridViewAutoSizeColumnMode.None);
                SetCol(cols, "Descripcion",  "Descripción", 0,   DataGridViewAutoSizeColumnMode.Fill, 160);

                AlignRight(cols, "Debe");
                AlignRight(cols, "Haber");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ConfigurarColumnasDetalles]: {ex.Message}");
            }
        }

        private static void SetCol(DataGridViewColumnCollection cols, string name,
            string header, int width, DataGridViewAutoSizeColumnMode mode, int minWidth = 0)
        {
            if (!cols.Contains(name)) return;
            var col = cols[name];
            if (col == null) return;
            try
            {
                col.Visible    = true;
                col.HeaderText = header;

                // MinimumWidth debe aplicarse ANTES de AutoSizeMode=Fill.
                // Si se aplica después, el DGV lanza excepción durante el recálculo.
                if (minWidth > 0)
                    col.MinimumWidth = minWidth;

                col.AutoSizeMode = mode;

                if (mode == DataGridViewAutoSizeColumnMode.None && width > 0)
                    col.Width = width;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[SetCol] {name}: {ex.Message}");
            }
        }

        private static void AlignRight(DataGridViewColumnCollection cols, string name)
        {
            if (!cols.Contains(name)) return;
            var col = cols[name];
            if (col == null) return;
            try { col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; }
            catch (Exception ex) { Debug.WriteLine($"[AlignRight] {name}: {ex.Message}"); }
        }

        // ─────────────────────────────────────────────────────────────
        // Selección de asiento → carga detalle
        // ─────────────────────────────────────────────────────────────

        private void DgvAsientos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAsientos.SelectedRows.Count == 0) return;
            try
            {
                var row = dgvAsientos.SelectedRows[0];
                if (row.DataBoundItem == null) return;

                var prop = row.DataBoundItem.GetType().GetProperty("AsientoID");
                if (prop == null) return;
                var val = prop.GetValue(row.DataBoundItem);
                if (val == null) return;

                CargarDetalles(Convert.ToInt32(val));
            }
            catch { }
        }

        private bool _columnasDetallesConfiguradas = false;

        private void CargarDetalles(int asientoID)
        {
            try
            {
                var detalles = ContabilidadRepository.ObtenerDetallesAsiento(asientoID);
                _columnasDetallesConfiguradas = false;
                dgvDetalles.DataSource = null;
                dgvDetalles.DataSource = detalles;
                // La configuración de columnas se hace en DataBindingComplete
                // para garantizar que el DGV ya generó las columnas
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[AsientosDiario] CargarDetalles({asientoID}): {ex.Message}");
            }
        }

        private void DgvDetalles_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_columnasDetallesConfiguradas) return;
            if (dgvDetalles.Columns.Count == 0) return;
            ConfigurarColumnasDetalles();
            _columnasDetallesConfiguradas = true;
        }

        // ─────────────────────────────────────────────────────────────
        // Exportar
        // ─────────────────────────────────────────────────────────────

        private void BtnExportar_Click(object sender, EventArgs e) => ExportarReporte();

        private void ExportarReporte()
        {
            if (_todosLosAsientos.Count == 0)
            {
                MessageBox.Show("No hay asientos para exportar.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string tipo = (cboTipoOperacion.SelectedIndex <= 0) ? null : cboTipoOperacion.SelectedItem as string;
                string cuenta = null;
                if (cboCuenta.SelectedItem is CuentaItem ci && !string.IsNullOrEmpty(ci.Codigo))
                    cuenta = ci.Codigo;
                string texto = string.IsNullOrWhiteSpace(txtBuscar.Text) ? null : txtBuscar.Text.Trim();
                decimal? montoMin = decimal.TryParse(txtMontoMin.Text, out decimal mn) && mn > 0 ? mn : (decimal?)null;
                decimal? montoMax = decimal.TryParse(txtMontoMax.Text, out decimal mx) && mx > 0 ? mx : (decimal?)null;

                var dt = ReportDataSourceHelper.ObtenerDatosAsientosDiario(
                    dtpDesde.Value, dtpHasta.Value, tipo, cuenta, texto, montoMin, montoMax);

                var dataSources = new Dictionary<string, DataTable> { { "DsLibroDiario", dt } };
                var parameters = ReportHelper.GetCompanyParameters();
                parameters["pPeriodo"] = $"Período: {dtpDesde.Value:dd/MM/yyyy} - {dtpHasta.Value:dd/MM/yyyy}";

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Tabular\RptLibroDiario.rdlc"),
                    dataSources, parameters, "libro_diario");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
