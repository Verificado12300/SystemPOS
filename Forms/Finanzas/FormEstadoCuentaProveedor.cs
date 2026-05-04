using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormEstadoCuentaProveedor : Form
    {
        private readonly int?   _proveedorID;
        private readonly string _nombreProveedor;
        private bool _huboCambios;

        public FormEstadoCuentaProveedor() { InitializeComponent(); }

        public FormEstadoCuentaProveedor(int? proveedorID, string nombreProveedor)
        {
            InitializeComponent();
            _proveedorID     = proveedorID;
            _nombreProveedor = nombreProveedor ?? "Sin proveedor";

            ConfigurarEventos();
            CargarMovimientos();
        }

        // ─────────────────────────────────────────────────────────────────
        // Configuración inicial
        // ─────────────────────────────────────────────────────────────────

        private void ConfigurarEventos()
        {
            dtpDesde.Value = DateTime.Now.AddMonths(-3);
            dtpHasta.Value = DateTime.Now;

            lblTitulo.Text       = $"Estado de Cuenta  —  {_nombreProveedor}";
            lblProveedorVal.Text = _nombreProveedor;

            dgvMovimientos.AutoGenerateColumns = false;
            DgvStyleHelper.Aplicar(dgvMovimientos);
            dgvMovimientos.AllowUserToAddRows  = false;
            dgvMovimientos.ReadOnly            = false;

            btnFiltrar.Click       += (s, e) => CargarMovimientos();
            btnRegistrarPago.Click += BtnRegistrarPago_Click;
            btnCerrar.Click        += (s, e) => Close();
            txtBuscar.KeyDown      += (s, e) => { if (e.KeyCode == Keys.Enter) CargarMovimientos(); };
        }

        // ─────────────────────────────────────────────────────────────────
        // Carga de movimientos + cards
        // ─────────────────────────────────────────────────────────────────

        private void CargarMovimientos()
        {
            try
            {
                string buscar = txtBuscar.Text.Trim();

                var movimientos = CuentaPorPagarRepository.ObtenerMovimientosCuentaProveedor(
                    _proveedorID,
                    dtpDesde.Value.Date,
                    dtpHasta.Value.Date,
                    string.IsNullOrWhiteSpace(buscar) ? null : buscar);

                // ── Cards ──────────────────────────────────────────────
                decimal totalCompras = 0, totalPagados = 0, totalAnul = 0;
                foreach (var m in movimientos)
                {
                    switch (m.Tipo)
                    {
                        case "COMPRA":
                        case "GASTO":
                            totalCompras += m.Cargo;
                            break;
                        case "PAGO":
                            if (!m.Anulado) totalPagados += m.Abono;
                            break;
                        case "ANULACION_PAGO":
                            totalAnul += m.Cargo;
                            break;
                    }
                }

                decimal saldoFinal = movimientos.Count > 0
                    ? movimientos[movimientos.Count - 1].Saldo
                    : 0m;

                lblComprasVal.Text = $"S/ {totalCompras:N2}";
                lblPagosVal.Text   = $"S/ {totalPagados:N2}";
                lblAnulVal.Text    = $"S/ {totalAnul:N2}";
                lblSaldoVal.Text   = $"S/ {saldoFinal:N2}";
                lblSaldoVal.ForeColor = saldoFinal > 0
                    ? Color.FromArgb(214, 48, 49)
                    : saldoFinal < 0
                        ? Color.FromArgb(39, 174, 96)
                        : Color.FromArgb(99, 110, 114);

                // ── DGV: más reciente primero ──────────────────────────
                dgvMovimientos.Rows.Clear();

                var lista = new List<MovimientoCxP>(movimientos);
                lista.Reverse();

                foreach (var mov in lista)
                {
                    int idx = dgvMovimientos.Rows.Add();
                    var row = dgvMovimientos.Rows[idx];

                    string horaStr = mov.Hora == TimeSpan.Zero
                        ? ""
                        : $"  {mov.Hora:hh\\:mm}";
                    row.Cells["colFecha"].Value     = $"{mov.Fecha:dd/MM/yyyy}{horaStr}";
                    row.Cells["colDocumento"].Value = mov.Documento;
                    row.Cells["colMetodo"].Value    = mov.Metodo;

                    // Tipo y color
                    string tipoLabel;
                    Color  tipoColor;
                    switch (mov.Tipo)
                    {
                        case "COMPRA":
                            tipoLabel = "COMPRA";
                            tipoColor = Color.FromArgb(214, 48, 49);
                            break;
                        case "GASTO":
                            tipoLabel = "GASTO";
                            tipoColor = Color.FromArgb(214, 48, 49);
                            break;
                        case "PAGO":
                            tipoLabel = "PAGO";
                            tipoColor = mov.Anulado
                                ? Color.FromArgb(149, 165, 166)
                                : Color.FromArgb(39, 174, 96);
                            break;
                        case "ANULACION_PAGO":
                            tipoLabel = "ANULACIÓN";
                            tipoColor = Color.FromArgb(149, 165, 166);
                            break;
                        default:
                            tipoLabel = mov.Tipo;
                            tipoColor = Color.FromArgb(45, 52, 54);
                            break;
                    }
                    row.Cells["colTipo"].Value            = tipoLabel;
                    row.Cells["colTipo"].Style.ForeColor  = tipoColor;
                    row.Cells["colTipo"].Style.Font       = new Font(dgvMovimientos.Font, FontStyle.Bold);

                    // Cargo / Abono
                    if (mov.Cargo > 0)
                    {
                        row.Cells["colCargo"].Value           = $"S/ {mov.Cargo:N2}";
                        row.Cells["colCargo"].Style.ForeColor = Color.FromArgb(214, 48, 49);
                        row.Cells["colAbono"].Value           = "";
                    }
                    else
                    {
                        row.Cells["colAbono"].Value           = $"S/ {mov.Abono:N2}";
                        row.Cells["colAbono"].Style.ForeColor = Color.FromArgb(39, 174, 96);
                        row.Cells["colCargo"].Value           = "";
                    }

                    // Saldo
                    decimal saldo = mov.Saldo;
                    row.Cells["colSaldo"].Value           = $"S/ {saldo:N2}";
                    row.Cells["colSaldo"].Style.ForeColor = saldo > 0
                        ? Color.FromArgb(214, 48, 49)
                        : saldo < 0
                            ? Color.FromArgb(39, 174, 96)
                            : Color.FromArgb(45, 52, 54);
                    row.Cells["colSaldo"].Style.Font = new Font(dgvMovimientos.Font, FontStyle.Bold);

                    // Estilo fila anulada: gris
                    if (mov.Anulado)
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(180, 180, 180);

                    // Tag siempre con el movimiento (lo usa BtnRegistrarPago para detectar selección)
                    row.Tag = mov;

                    // Botón Acción: solo "Anular" en pagos activos
                    var cellAccion = (DataGridViewButtonCell)row.Cells["colAccion"];
                    if (mov.PuedeAnular)
                    {
                        cellAccion.Value           = "Anular";
                        cellAccion.Style.BackColor = Color.FromArgb(214, 48, 49);
                        cellAccion.Style.ForeColor = Color.White;
                    }
                    else
                    {
                        cellAccion.Value           = "";
                        cellAccion.Style.BackColor = Color.FromArgb(240, 240, 240);
                        cellAccion.Style.ForeColor = Color.FromArgb(200, 200, 200);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar movimientos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────────
        // Click en columna Acción (solo Anular)
        // ─────────────────────────────────────────────────────────────────

        private void DgvMovimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvMovimientos.Columns["colAccion"].Index)
                return;

            var mov = dgvMovimientos.Rows[e.RowIndex].Tag as MovimientoCxP;
            if (mov == null || !mov.PuedeAnular) return;

            AccionAnular(mov);
        }

        private void AccionAnular(MovimientoCxP mov)
        {
            string monto = $"S/ {mov.Abono:N2}";
            string fecha = mov.Fecha.ToString("dd/MM/yyyy");

            var resp = MessageBox.Show(
                $"¿Confirma la anulación del pago del {fecha} por {monto}?\n\nSe revertirá el asiento contable Dr 101/102 / Cr 200.",
                "Anular pago",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resp != DialogResult.Yes) return;

            try
            {
                CuentaPorPagarRepository.AnularPago(
                    mov.PagoProveedorID.Value,
                    SesionActual.Usuario.UsuarioID);

                _huboCambios = true;
                MessageBox.Show("Pago anulado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarMovimientos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al anular pago: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────────
        // Botón "Registrar Pago" (bottom)
        // Prioridad: fila seleccionada COMPRA/GASTO pendiente → primer pendiente global
        // ─────────────────────────────────────────────────────────────────

        private void BtnRegistrarPago_Click(object sender, EventArgs e)
        {
            try
            {
                MovimientoCxP objetivo = null;

                // 1. ¿Hay una fila COMPRA/GASTO pendiente seleccionada?
                if (dgvMovimientos.SelectedRows.Count > 0)
                {
                    var selMov = dgvMovimientos.SelectedRows[0].Tag as MovimientoCxP;
                    if (selMov != null && selMov.PuedePagar)
                        objetivo = selMov;
                }

                // 2. Si no, buscar el primer pendiente visible en el DGV
                if (objetivo == null)
                {
                    foreach (DataGridViewRow row in dgvMovimientos.Rows)
                    {
                        var m = row.Tag as MovimientoCxP;
                        if (m != null && m.PuedePagar) { objetivo = m; break; }
                    }
                }

                // 3. Si no hay en el rango visible, buscar en todos los documentos del proveedor
                if (objetivo == null)
                {
                    var todos = CuentaPorPagarRepository.ObtenerMovimientosCuentaProveedor(
                        _proveedorID, DateTime.Now.AddYears(-5), DateTime.Now);
                    foreach (var m in todos)
                    {
                        if (m.PuedePagar) { objetivo = m; break; }
                    }
                }

                if (objetivo == null)
                {
                    MessageBox.Show("No hay documentos pendientes de pago para este proveedor.",
                        "Sin pendientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var frm = new FormRegistrarPagoProveedor(objetivo.CuentaPorPagarID.Value))
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        _huboCambios = true;
                        CargarMovimientos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────────
        // Cerrar — propagar si hubo cambios
        // ─────────────────────────────────────────────────────────────────

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (this.DialogResult == DialogResult.None)
                this.DialogResult = _huboCambios ? DialogResult.OK : DialogResult.Cancel;
        }
    }
}
