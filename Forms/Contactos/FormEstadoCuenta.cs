using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Reports.DataSources;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Contactos
{
    public partial class FormEstadoCuenta : Form
    {
        private readonly int _clienteID;

        // Cache del resumen global (sin filtro de fecha)
        private decimal _totalVentasGlobal;
        private decimal _totalPagosGlobal;
        private decimal _totalAnulacionesGlobal;
        private decimal _saldoActual;

        public FormEstadoCuenta(int clienteID)
        {
            InitializeComponent();
            _clienteID = clienteID;

            ConfigurarEventos();
            CargarEncabezado();
            CargarMovimientos();
        }

        // ─────────────────────────────────────────────────────────────
        // Configuración inicial
        // ─────────────────────────────────────────────────────────────

        private void ConfigurarEventos()
        {
            dtpDesde.Value = DateTime.Now.AddMonths(-3);
            dtpHasta.Value = DateTime.Now;

            dgvMovimientos.AutoGenerateColumns = false;
            dgvMovimientos.AllowUserToAddRows  = false;
            dgvMovimientos.ReadOnly            = false; // botones en col Acción

            btnFiltrar.Click       += (s, e) => CargarMovimientos();
            btnRegistrarPago.Click += BtnRegistrarPago_Click;
            btnImprimir.Click      += BtnImprimir_Click;
            btnCerrar.Click        += (s, e) => Close();
            txtBuscar.KeyDown      += (s, e) => { if (e.KeyCode == Keys.Enter) CargarMovimientos(); };
        }

        // ─────────────────────────────────────────────────────────────
        // Datos de encabezado + resumen (globales, sin filtro fecha)
        // ─────────────────────────────────────────────────────────────

        private void CargarEncabezado()
        {
            try
            {
                var ec      = ClienteRepository.ObtenerEstadoCuenta(_clienteID);
                var cliente = (Cliente)ec.Cliente;

                string nombre = cliente.TipoDocumento == "RUC"
                    ? cliente.RazonSocial
                    : $"{cliente.Nombres} {cliente.Apellidos}".Trim();

                // Header
                lblTitulo.Text = $"Estado de Cuenta  —  {nombre}";

                // Info compacta
                lblNombreVal.Text    = nombre;
                lblDocVal.Text       = $"{cliente.TipoDocumento} {cliente.NumeroDocumento}";
                lblEstadoBadge.Text  = cliente.Activo ? "ACTIVO" : "INACTIVO";
                lblEstadoBadge.BackColor = cliente.Activo
                    ? Color.FromArgb(39, 174, 96)
                    : Color.FromArgb(214, 48, 49);

                decimal limCred    = (decimal)ec.LimiteCredito;
                decimal credUsado  = (decimal)ec.CreditoUtilizado;
                decimal disponible = (decimal)ec.CreditoDisponible;

                lblLimCredVal.Text    = $"S/ {limCred:N2}";
                lblCredUsadoVal.Text  = $"S/ {credUsado:N2}";
                lblDisponibleVal.Text = $"S/ {disponible:N2}";
                lblDisponibleVal.ForeColor = disponible >= 0
                    ? Color.FromArgb(39, 174, 96)
                    : Color.FromArgb(214, 48, 49);

                // Resumen global
                _totalVentasGlobal     = (decimal)ec.TotalVentas;
                _totalPagosGlobal      = (decimal)ec.TotalPagos;
                _totalAnulacionesGlobal = ClienteRepository.ObtenerTotalAnulacionesCxC(_clienteID);
                _saldoActual           = (decimal)ec.SaldoPendiente;

                ActualizarResumen();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar encabezado: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarResumen()
        {
            lblVentasVal.Text      = $"S/ {_totalVentasGlobal:N2}";
            lblPagosVal.Text       = $"S/ {_totalPagosGlobal:N2}";
            lblAnulacionesVal.Text = $"S/ {_totalAnulacionesGlobal:N2}";
            lblSaldoVal.Text       = $"S/ {_saldoActual:N2}";
            lblSaldoVal.ForeColor  = _saldoActual > 0
                ? Color.FromArgb(214, 48, 49)
                : _saldoActual < 0
                    ? Color.FromArgb(39, 174, 96)
                    : Color.FromArgb(99, 110, 114);
        }

        // ─────────────────────────────────────────────────────────────
        // Tabla de movimientos
        // ─────────────────────────────────────────────────────────────

        private void CargarMovimientos()
        {
            try
            {
                string buscar = txtBuscar.Text.Trim();

                var movimientos = ClienteRepository.ObtenerMovimientosCuentaCliente(
                    _clienteID,
                    dtpDesde.Value.Date,
                    dtpHasta.Value.Date,
                    string.IsNullOrWhiteSpace(buscar) ? null : buscar);

                dgvMovimientos.Rows.Clear();

                // Mostrar más reciente primero (revertir)
                var lista = new List<MovimientoCuenta>(movimientos);
                lista.Reverse();

                foreach (var mov in lista)
                {
                    int idx = dgvMovimientos.Rows.Add();
                    var row = dgvMovimientos.Rows[idx];

                    row.Cells["colFecha"].Value    = $"{mov.Fecha:dd/MM/yyyy}  {mov.Hora:hh\\:mm}";
                    row.Cells["colTipo"].Value     = mov.Tipo == "ANULACION_COBRO" ? "ANULACIÓN" : mov.Tipo;
                    row.Cells["colDocumento"].Value = mov.Documento;
                    row.Cells["colMetodo"].Value   = mov.Metodo;

                    if (mov.Cargo > 0)
                    {
                        row.Cells["colCargo"].Value = $"S/ {mov.Cargo:N2}";
                        row.Cells["colCargo"].Style.ForeColor = Color.FromArgb(214, 48, 49);
                        row.Cells["colAbono"].Value = "";
                    }
                    else if (mov.Abono > 0)
                    {
                        row.Cells["colAbono"].Value = $"S/ {mov.Abono:N2}";
                        row.Cells["colAbono"].Style.ForeColor = Color.FromArgb(39, 174, 96);
                        row.Cells["colCargo"].Value = "";
                    }

                    decimal saldo = mov.Saldo;
                    row.Cells["colSaldo"].Value = $"S/ {saldo:N2}";
                    row.Cells["colSaldo"].Style.ForeColor = saldo > 0
                        ? Color.FromArgb(214, 48, 49)
                        : saldo < 0
                            ? Color.FromArgb(39, 174, 96)
                            : Color.FromArgb(45, 52, 54);
                    row.Cells["colSaldo"].Style.Font = new Font(dgvMovimientos.Font, FontStyle.Bold);

                    // Color de tipo
                    Color tipoColor;
                    switch (mov.Tipo)
                    {
                        case "VENTA":          tipoColor = Color.FromArgb(214, 48, 49);  break;
                        case "PAGO":           tipoColor = Color.FromArgb(39, 174, 96);  break;
                        case "ANULACION_COBRO": tipoColor = Color.FromArgb(149, 165, 166); break;
                        default:               tipoColor = Color.FromArgb(45, 52, 54);   break;
                    }
                    row.Cells["colTipo"].Style.ForeColor = tipoColor;
                    row.Cells["colTipo"].Style.Font = new Font(dgvMovimientos.Font, FontStyle.Bold);

                    // Fila de PAGO anulado → gris, tachado visualmente
                    if (mov.Anulado && mov.Tipo == "PAGO")
                    {
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(180, 180, 180);
                        row.DefaultCellStyle.Font      = new Font(dgvMovimientos.Font, FontStyle.Strikeout);
                    }

                    // Botón Anular: visible sólo en pagos activos
                    var cellAccion = (DataGridViewButtonCell)row.Cells["colAccion"];
                    if (mov.PuedeAnular)
                    {
                        cellAccion.Value           = "Anular";
                        cellAccion.Style.BackColor = Color.FromArgb(214, 48, 49);
                        cellAccion.Style.ForeColor = Color.White;
                        row.Tag = mov.PagoVentaID;   // guardamos el ID para el clic
                    }
                    else
                    {
                        cellAccion.Value           = "";
                        cellAccion.Style.BackColor = Color.FromArgb(240, 240, 240);
                        row.Tag = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar movimientos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvMovimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvMovimientos.Columns["colAccion"].Index)
                return;

            var row = dgvMovimientos.Rows[e.RowIndex];
            if (row.Tag == null) return;

            int pagoVentaID = (int)row.Tag;

            var resp = MessageBox.Show(
                "¿Confirma la anulación de este cobro?\n\nSe revertirá el asiento contable.",
                "Anular cobro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resp != DialogResult.Yes) return;

            try
            {
                int usuarioID = SesionActual.Usuario?.UsuarioID ?? 0;
                ClienteRepository.AnularPagoCxC(pagoVentaID, usuarioID);
                MessageBox.Show("Cobro anulado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar todo
                CargarEncabezado();
                CargarMovimientos();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al anular cobro: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────
        // Botones
        // ─────────────────────────────────────────────────────────────

        private void BtnRegistrarPago_Click(object sender, EventArgs e)
        {
            try
            {
                var ec = ClienteRepository.ObtenerEstadoCuenta(_clienteID);

                if ((decimal)ec.SaldoPendiente <= 0)
                {
                    MessageBox.Show("Este cliente no tiene saldo pendiente.", "Sin deuda",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var frm = new FormRegistrarPago(_clienteID, (decimal)ec.SaldoPendiente))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CargarEncabezado();
                        CargarMovimientos();
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var parametros = ReportHelper.GetCompanyParameters();
                var dt = ReportDataSourceHelper.ObtenerDatosEstadoCuenta(
                    _clienteID, dtpDesde.Value.Date, dtpHasta.Value.Date, parametros);

                var dataSources = new Dictionary<string, DataTable> { { "DsMovimientos", dt } };

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Documents\RptEstadoCuenta.rdlc"),
                    dataSources, parametros, "estado_cuenta");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
