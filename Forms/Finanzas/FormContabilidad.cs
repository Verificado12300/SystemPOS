using System;
using System.Diagnostics;
using System.Windows.Forms;
using SistemaPOS.Data;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormContabilidad : Form
    {
        public FormContabilidad()
        {
            InitializeComponent();
            dtpDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpHasta.Value = DateTime.Today;
            dtpDesdeC.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpHastaC.Value = DateTime.Today;
            CargarCombos();
        }

        private void CargarCombos()
        {
            try
            {
                // Combo TipoOperacion
                cboTipoOperacion.Items.Clear();
                cboTipoOperacion.Items.Add("(TODOS)");
                foreach (var tipo in ContabilidadRepository.ObtenerTiposOperacion())
                    cboTipoOperacion.Items.Add(tipo);
                cboTipoOperacion.SelectedIndex = 0;

                // Combo Cuenta
                cboCuenta.Items.Clear();
                cboCuenta.Items.Add(new CuentaItem { Codigo = "", Display = "(TODAS)" });
                foreach (var c in ContabilidadRepository.ObtenerCuentasActivas())
                {
                    var tipo = c.GetType();
                    string codigo  = (string)tipo.GetProperty("Codigo").GetValue(c, null);
                    string nombre  = (string)tipo.GetProperty("Nombre").GetValue(c, null);
                    string display = (string)tipo.GetProperty("Display").GetValue(c, null);
                    cboCuenta.Items.Add(new CuentaItem { Codigo = codigo, Display = display });
                }
                cboCuenta.SelectedIndex = 0;
                cboCuenta.DisplayMember = "Display";
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Contabilidad] CargarCombos: {ex.Message}");
            }
        }

        private sealed class CuentaItem
        {
            public string Codigo  { get; set; }
            public string Display { get; set; }
            public override string ToString() => Display;
        }

        private void BtnBuscarAsientos_Click(object sender, EventArgs e)
        {
            CargarAsientos();
        }

        private void BtnBuscarCuentas_Click(object sender, EventArgs e)
        {
            CargarCuentas();
        }

        private void CargarAsientos()
        {
            try
            {
                dgvAsientos.DataSource = null;
                dgvDetalles.DataSource = null;

                // Leer filtros opcionales
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

                var asientos = ContabilidadRepository.ObtenerAsientos(
                    dtpDesde.Value, dtpHasta.Value,
                    tipo, cuenta, texto, montoMin, montoMax);
                dgvAsientos.DataSource = asientos;

                // Configurar columnas
                if (dgvAsientos.Columns.Count > 0)
                {
                    if (dgvAsientos.Columns.Contains("AsientoID")) dgvAsientos.Columns["AsientoID"].HeaderText = "ID";
                    if (dgvAsientos.Columns.Contains("Fecha")) dgvAsientos.Columns["Fecha"].HeaderText = "Fecha";
                    if (dgvAsientos.Columns.Contains("Hora")) dgvAsientos.Columns["Hora"].HeaderText = "Hora";
                    if (dgvAsientos.Columns.Contains("TipoOperacion")) dgvAsientos.Columns["TipoOperacion"].HeaderText = "Tipo";
                    if (dgvAsientos.Columns.Contains("Documento")) dgvAsientos.Columns["Documento"].HeaderText = "Documento";
                    if (dgvAsientos.Columns.Contains("Glosa")) dgvAsientos.Columns["Glosa"].HeaderText = "Glosa";
                    if (dgvAsientos.Columns.Contains("TotalDebe")) dgvAsientos.Columns["TotalDebe"].HeaderText = "Debe";
                    if (dgvAsientos.Columns.Contains("TotalHaber")) dgvAsientos.Columns["TotalHaber"].HeaderText = "Haber";
                }

                lblTotalAsientos.Text = $"Total: {asientos.Count} asientos";
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Contabilidad] CargarAsientos: {ex.Message}");
                lblTotalAsientos.Text = "Total: 0 asientos";
            }
        }

        private void CargarDetalles(int asientoID)
        {
            try
            {
                var detalles = ContabilidadRepository.ObtenerDetallesAsiento(asientoID);
                dgvDetalles.DataSource = detalles;

                if (dgvDetalles.Columns.Count > 0)
                {
                    if (dgvDetalles.Columns.Contains("DetalleID")) dgvDetalles.Columns["DetalleID"].Visible = false;
                    if (dgvDetalles.Columns.Contains("CuentaCodigo")) dgvDetalles.Columns["CuentaCodigo"].HeaderText = "Codigo";
                    if (dgvDetalles.Columns.Contains("CuentaNombre")) dgvDetalles.Columns["CuentaNombre"].HeaderText = "Cuenta";
                    if (dgvDetalles.Columns.Contains("CuentaTipo")) dgvDetalles.Columns["CuentaTipo"].HeaderText = "Tipo";
                    if (dgvDetalles.Columns.Contains("Debe")) dgvDetalles.Columns["Debe"].HeaderText = "Debe";
                    if (dgvDetalles.Columns.Contains("Haber")) dgvDetalles.Columns["Haber"].HeaderText = "Haber";
                    if (dgvDetalles.Columns.Contains("Descripcion")) dgvDetalles.Columns["Descripcion"].HeaderText = "Descripcion";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Contabilidad] CargarDetalles(asientoID={asientoID}): {ex.Message}");
            }
        }

        private void CargarCuentas()
        {
            try
            {
                var saldos = ContabilidadRepository.ObtenerSaldosDetallados(dtpDesdeC.Value, dtpHastaC.Value);
                dgvCuentas.DataSource = saldos;

                if (dgvCuentas.Columns.Count > 0)
                {
                    if (dgvCuentas.Columns.Contains("Codigo")) dgvCuentas.Columns["Codigo"].HeaderText = "Codigo";
                    if (dgvCuentas.Columns.Contains("Nombre")) dgvCuentas.Columns["Nombre"].HeaderText = "Nombre";
                    if (dgvCuentas.Columns.Contains("Tipo")) dgvCuentas.Columns["Tipo"].HeaderText = "Tipo";
                    if (dgvCuentas.Columns.Contains("Debe")) dgvCuentas.Columns["Debe"].HeaderText = "Debe";
                    if (dgvCuentas.Columns.Contains("Haber")) dgvCuentas.Columns["Haber"].HeaderText = "Haber";
                    if (dgvCuentas.Columns.Contains("Saldo")) dgvCuentas.Columns["Saldo"].HeaderText = "Saldo";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Contabilidad] CargarCuentas: {ex.Message}");
            }
        }

        private void DgvAsientos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAsientos.SelectedRows.Count == 0) return;
            try
            {
                // Obtener AsientoID de la fila seleccionada
                var row = dgvAsientos.SelectedRows[0];
                if (row.DataBoundItem == null) return;

                // Usar reflection para obtener AsientoID del tipo anonimo
                var prop = row.DataBoundItem.GetType().GetProperty("AsientoID");
                if (prop == null) return;
                var val = prop.GetValue(row.DataBoundItem);
                if (val == null) return;
                int asientoID = Convert.ToInt32(val);
                CargarDetalles(asientoID);
            }
            catch { }
        }
    }
}
