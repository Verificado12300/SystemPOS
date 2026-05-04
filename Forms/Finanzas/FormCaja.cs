using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Reports.DataSources;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormCaja : Form
    {
        private Caja _cajaActual;
        private List<Usuario> _usuarios;
        private Timer _timerActualizacion;

        public FormCaja()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            ConfigurarEventos();
            ConfigurarControles();
            CargarDatos();
            IniciarTimer();
        }

        // ─── Initialization ───────────────────────────────────────────────────
        private void ConfigurarEventos()
        {
            btnAbrirTurno.Click    += BtnAbrirTurno_Click;
            btnCapitalInicial.Click += BtnCapitalInicial_Click;
            btnMoneteo.Click       += BtnMoneteo_Click;
            btnConversion.Click    += BtnConversion_Click;
            btnCerrarCaja.Click    += BtnCerrarCaja_Click;

            btnExportar.Click                    += BtnExportar_Click;
            dtpDesde.ValueChanged                += (s, e) => CargarHistorial();
            dtpHasta.ValueChanged                += (s, e) => CargarHistorial();
            cmbUsuarios.SelectedIndexChanged     += (s, e) => CargarHistorial();
            dgvHistorialCaja.CellClick           += DgvHistorialCaja_CellClick;
            dgvHistorialCaja.CellDoubleClick     += DgvHistorialCaja_CellDoubleClick;
        }

        private void ConfigurarControles()
        {
            EstilizarDgv(dgvHistorialCaja);
            EstilizarDgv(dgvVentasTurno);
            EstilizarDgv(dgvGastosTurno);
            EstilizarDgv(dgvConversionesTurno);
            dtpDesde.Value = DateTime.Now.AddDays(-30);
            dtpHasta.Value = DateTime.Now;
        }

        private void EstilizarDgv(DataGridView dgv)
        {
            dgv.AutoGenerateColumns  = false;
            dgv.AllowUserToAddRows   = false;
            dgv.ReadOnly             = true;
            dgv.SelectionMode        = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible    = false;
            dgv.BorderStyle          = BorderStyle.None;
            dgv.BackgroundColor      = Color.White;
            dgv.GridColor            = Color.FromArgb(235, 237, 240);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 52, 54);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgv.ColumnHeadersHeight  = 32;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            DgvStyleHelper.Aplicar(dgv);
        }

        private void IniciarTimer()
        {
            _timerActualizacion = new Timer { Interval = 30000 };
            _timerActualizacion.Tick += (s, e) =>
            {
                if (_cajaActual != null)
                {
                    ActualizarInfoTopBar();
                    CargarResumenTarjetas();
                }
            };
            _timerActualizacion.Start();
        }

        // ─── Data & State ─────────────────────────────────────────────────────
        private void CargarDatos()
        {
            _cajaActual = CajaRepository.ObtenerCajaAbierta();
            CargarUsuarios();
            CargarHistorial();
            ActualizarEstado();
        }

        private void ActualizarEstado()
        {
            ActualizarBarraEstado();
            if (_cajaActual != null)
                MostrarDashboard();
            else
                MostrarSinTurno();
        }

        private void ActualizarBarraEstado()
        {
            if (_cajaActual != null)
            {
                pnlStatusDot.BackColor = Color.FromArgb(39, 174, 96);
                lblStatusText.Text      = "TURNO ACTIVO";
                lblStatusText.ForeColor = Color.FromArgb(39, 174, 96);
                ActualizarInfoTopBar();
                lblTurnoInfo.Visible = true;

                btnAbrirTurno.Visible    = false;
                btnCapitalInicial.Visible = true;
                btnMoneteo.Visible       = true;
                btnConversion.Visible    = true;
                btnCerrarCaja.Visible    = true;
            }
            else
            {
                pnlStatusDot.BackColor  = Color.FromArgb(189, 195, 199);
                lblStatusText.Text      = "SIN TURNO ACTIVO";
                lblStatusText.ForeColor = Color.FromArgb(127, 140, 141);
                lblTurnoInfo.Visible    = false;

                btnAbrirTurno.Visible    = true;
                btnCapitalInicial.Visible = false;
                btnMoneteo.Visible       = false;
                btnConversion.Visible    = false;
                btnCerrarCaja.Visible    = false;
            }
        }

        private void ActualizarInfoTopBar()
        {
            if (_cajaActual == null) return;
            string nombre = UsuarioRepository.ObtenerNombreCompletoPorID(_cajaActual.UsuarioID);
            var inicio = _cajaActual.FechaApertura.Date + _cajaActual.HoraApertura;
            var t = DateTime.Now - inicio;
            lblTurnoInfo.Text = $"{nombre}   |   Turno {_cajaActual.Turno}" +
                                $"   |   Apertura: {_cajaActual.HoraApertura:hh\\:mm}" +
                                $"   |   {(int)t.TotalHours}h {t.Minutes}m" +
                                $"   |   Fondo: S/ {_cajaActual.MontoInicial:N2}";
        }

        private void MostrarDashboard()
        {
            pnlNoTurno.Visible  = false;
            pnlDashboard.Visible = true;
            CargarResumenTarjetas();
            CargarDetallesTurno();
        }

        private void MostrarSinTurno()
        {
            pnlDashboard.Visible = false;
            pnlNoTurno.Visible   = true;
        }

        // ─── Tab Historial ────────────────────────────────────────────────────
        private void CargarUsuarios()
        {
            _usuarios = CajaRepository.ObtenerUsuariosConCajas();
            cmbUsuarios.Items.Clear();
            cmbUsuarios.Items.Add("TODOS");
            foreach (var u in _usuarios) cmbUsuarios.Items.Add(u.NombreCompleto);
            cmbUsuarios.SelectedIndex = 0;
        }

        private void CargarHistorial()
        {
            int? usuarioID = cmbUsuarios.SelectedIndex > 0
                ? _usuarios[cmbUsuarios.SelectedIndex - 1].UsuarioID
                : (int?)null;

            var historial = CajaRepository.Listar(dtpDesde.Value.Date, dtpHasta.Value.Date, usuarioID);
            dgvHistorialCaja.Rows.Clear();

            foreach (var caja in historial)
            {
                int idx = dgvHistorialCaja.Rows.Add();
                var row  = dgvHistorialCaja.Rows[idx];
                row.Cells["colFecha"].Value         = caja.FechaApertura.ToString("dd/MM/yyyy");
                row.Cells["colTurno"].Value         = caja.Turno;
                row.Cells["colApertura"].Value      = caja.HoraApertura.ToString(@"hh\:mm");
                row.Cells["colCierre"].Value        = caja.HoraCierre?.ToString(@"hh\:mm") ?? "-";
                row.Cells["colDuracion"].Value      = caja.Duracion;
                row.Cells["colEncargado"].Value     = caja.NombreUsuario;
                row.Cells["colTotalIngresos"].Value = $"S/ {caja.TotalVentas:N2}";
                row.Cells["colEstado"].Value        = caja.Estado;
                row.Cells["colVerDetalle"].Value    = "Ver";
                row.Tag = caja.CajaID;

                if (caja.Estado == "ABIERTA")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(232, 255, 240);
                    row.DefaultCellStyle.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
            }

            lblTotalRegistros.Text = $"Total: {historial.Count} registros";
        }

        private void DgvHistorialCaja_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvHistorialCaja.Columns[e.ColumnIndex].Name == "colVerDetalle")
                AbrirDetalleCaja(e.RowIndex);
        }

        private void DgvHistorialCaja_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) AbrirDetalleCaja(e.RowIndex);
        }

        private void AbrirDetalleCaja(int rowIndex)
        {
            int cajaID = Convert.ToInt32(dgvHistorialCaja.Rows[rowIndex].Tag);
            using (var f = new FormDetalleCaja(cajaID))
                f.ShowDialog(this);
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                int? usuarioID = cmbUsuarios.SelectedIndex > 0
                    ? _usuarios[cmbUsuarios.SelectedIndex - 1].UsuarioID
                    : (int?)null;

                var dt = ReportDataSourceHelper.ObtenerDatosHistorialCaja(
                    dtpDesde.Value.Date, dtpHasta.Value.Date, usuarioID);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay registros para exportar.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var dataSources = new Dictionary<string, DataTable> { { "DsHistorialCaja", dt } };
                var parameters  = ReportHelper.GetCompanyParameters();
                parameters["pPeriodo"] = $"Período: {dtpDesde.Value:dd/MM/yyyy} - {dtpHasta.Value:dd/MM/yyyy}";

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Tabular\RptHistorialCaja.rdlc"),
                    dataSources, parameters, "historial_caja");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Tab Dashboard ────────────────────────────────────────────────────
        private void CargarResumenTarjetas()
        {
            if (_cajaActual == null) return;
            var resumen = CajaRepository.ObtenerResumenVentas(_cajaActual.CajaID);
            lblCardTotalMonto.Text        = $"S/ {resumen.TotalVentas:N2}";
            lblCardTotalOps.Text          = $"{resumen.Operaciones} operaciones";
            lblCardEfectivoMonto.Text     = $"S/ {resumen.TotalEfectivoAjustado:N2}";
            lblCardYapeMonto.Text         = $"S/ {resumen.TotalYapeAjustado:N2}";
            lblCardTransferenciaMonto.Text = $"S/ {resumen.TotalTransferenciaAjustado:N2}";
            lblCardGastosMonto.Text       = $"S/ {resumen.TotalGastos:N2}";
        }

        private void CargarDetallesTurno()
        {
            if (_cajaActual == null) return;

            dgvVentasTurno.Rows.Clear();
            foreach (var v in CajaRepository.ObtenerVentasDelTurno(_cajaActual.CajaID))
            {
                int idx = dgvVentasTurno.Rows.Add();
                var row = dgvVentasTurno.Rows[idx];
                row.Cells["colVentaHora"].Value   = v.Hora;
                row.Cells["colVentaNumero"].Value = v.NumeroVenta;
                row.Cells["colVentaCliente"].Value = v.NombreCliente;
                row.Cells["colVentaMetodo"].Value = v.Metodo;
                row.Cells["colVentaTotal"].Value  = $"S/ {v.Total:N2}";
            }

            dgvGastosTurno.Rows.Clear();
            foreach (var g in CajaRepository.ObtenerGastosDelTurno(_cajaActual.CajaID))
            {
                int idx = dgvGastosTurno.Rows.Add();
                var row = dgvGastosTurno.Rows[idx];
                row.Cells["colGastoHora"].Value      = g.Hora;
                row.Cells["colGastoConcepto"].Value  = g.Concepto;
                row.Cells["colGastoCategoria"].Value = g.Categoria;
                row.Cells["colGastoMonto"].Value     = $"S/ {g.Monto:N2}";
            }

            dgvConversionesTurno.Rows.Clear();
            foreach (var c in CajaRepository.ObtenerConversiones(_cajaActual.CajaID))
            {
                int idx = dgvConversionesTurno.Rows.Add();
                var row = dgvConversionesTurno.Rows[idx];
                row.Cells["colConvHora"].Value    = c.FechaHora.ToString("HH:mm");
                row.Cells["colConvOrigen"].Value  = c.MetodoOrigen;
                row.Cells["colConvDestino"].Value = c.MetodoDestino;
                row.Cells["colConvMonto"].Value   = $"S/ {c.Monto:N2}";
                row.Cells["colConvObs"].Value     = c.Observacion;
            }
        }

        // ─── Button Handlers ──────────────────────────────────────────────────
        private void BtnAbrirTurno_Click(object sender, EventArgs e)
        {
            var cajaExistente = CajaRepository.ObtenerCajaAbierta();
            if (cajaExistente != null)
            {
                _cajaActual = cajaExistente;
                ActualizarEstado();
                return;
            }
            using (var dlg = new FormAperturaCaja())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    CargarDatos();
            }
        }

        private void BtnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (_cajaActual == null)
            {
                MessageBox.Show("No hay turno abierto.", "Sin turno",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var dlg = new FormCierreCaja(_cajaActual))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    CargarDatos();
            }
        }

        private void BtnConversion_Click(object sender, EventArgs e)
        {
            if (_cajaActual == null) return;
            using (var dlg = new FormConversion(_cajaActual.CajaID))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    CargarResumenTarjetas();
                    CargarDetallesTurno();
                }
            }
        }

        private void BtnMoneteo_Click(object sender, EventArgs e)
        {
            if (_cajaActual == null) return;
            using (var dlg = new FormMoneteo(_cajaActual.CajaID))
                dlg.ShowDialog(this);
        }

        private void BtnCapitalInicial_Click(object sender, EventArgs e)
        {
            if (_cajaActual == null) return;

            decimal monto;
            using (var dlg = new Form())
            {
                dlg.Text = "Capital Inicial";
                dlg.ClientSize = new Size(320, 120);
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;
                var lbl = new Label { Text = "Monto (S/):", Location = new Point(16, 18), AutoSize = true };
                var num = new NumericUpDown
                {
                    Location = new Point(16, 38), Size = new Size(180, 26),
                    DecimalPlaces = 2, Minimum = 0, Maximum = 9999999
                };
                var btnOk = new Button
                {
                    Text = "Aceptar", DialogResult = DialogResult.OK,
                    Location = new Point(200, 36), Size = new Size(100, 28)
                };
                dlg.Controls.AddRange(new Control[] { lbl, num, btnOk });
                dlg.AcceptButton = btnOk;
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                monto = num.Value;
            }

            if (monto <= 0)
            {
                MessageBox.Show("El monto debe ser mayor a cero.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        ContabilidadService.RegistrarCapitalInicial(
                            _cajaActual.FechaApertura, DateTime.Now.TimeOfDay, monto,
                            SesionActual.Usuario.UsuarioID, _cajaActual.CajaID, conn, tx);
                        tx.Commit();
                    }
                    catch { tx.Rollback(); throw; }
                }
                MessageBox.Show($"Capital inicial registrado.\nDr 101 Caja / Cr 300 Capital — S/ {monto:N2}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timerActualizacion?.Stop();
            _timerActualizacion?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
