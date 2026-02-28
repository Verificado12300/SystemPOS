using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
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

        private void ConfigurarEventos()
        {
            btnCerrarCaja.Click += BtnCerrarCaja_Click;
            btnCapitalInicial.Click += BtnCapitalInicial_Click;
            btnExportar.Click += BtnExportar_Click;
            numEfectivoReal.ValueChanged += NumEfectivoReal_ValueChanged;
            numEfectivoReal.KeyDown += NumEfectivoReal_KeyDown;
            txtMotivo.KeyDown += TxtMotivo_KeyDown;
            dtpDesde.ValueChanged += FiltrosChanged;
            dtpHasta.ValueChanged += FiltrosChanged;
            cmbUsuarios.SelectedIndexChanged += FiltrosChanged;
            dgvHistorialCaja.CellClick += DgvHistorialCaja_CellClick;
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                int? usuarioID = null;
                if (cmbUsuarios.SelectedIndex > 0)
                    usuarioID = _usuarios[cmbUsuarios.SelectedIndex - 1].UsuarioID;

                var dt = ReportDataSourceHelper.ObtenerDatosHistorialCaja(dtpDesde.Value.Date, dtpHasta.Value.Date, usuarioID);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay registros para exportar", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var dataSources = new Dictionary<string, DataTable>
                {
                    { "DsHistorialCaja", dt }
                };

                var parameters = ReportHelper.GetCompanyParameters();
                parameters["pPeriodo"] = $"Período: {dtpDesde.Value:dd/MM/yyyy} - {dtpHasta.Value:dd/MM/yyyy}";

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Tabular\RptHistorialCaja.rdlc"),
                    dataSources, parameters, "historial_caja");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                int? usuarioID = null;
                if (cmbUsuarios.SelectedIndex > 0)
                    usuarioID = _usuarios[cmbUsuarios.SelectedIndex - 1].UsuarioID;

                var dt = ReportDataSourceHelper.ObtenerDatosHistorialCaja(dtpDesde.Value.Date, dtpHasta.Value.Date, usuarioID);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay registros para imprimir", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var dataSources = new Dictionary<string, DataTable>
                {
                    { "DsHistorialCaja", dt }
                };

                var parameters = ReportHelper.GetCompanyParameters();
                parameters["pPeriodo"] = $"Período: {dtpDesde.Value:dd/MM/yyyy} - {dtpHasta.Value:dd/MM/yyyy}";

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Tabular\RptHistorialCaja.rdlc"),
                    dataSources, parameters, "historial_caja");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarControles()
        {
            dgvHistorialCaja.AutoGenerateColumns = false;
            dgvHistorialCaja.AllowUserToAddRows = false;
            dgvHistorialCaja.ReadOnly = true;
            dgvHistorialCaja.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dtpDesde.Value = DateTime.Now.AddDays(-30);
            dtpHasta.Value = DateTime.Now;

            numEfectivoReal.Maximum = 999999;
            numEfectivoReal.Minimum = 0;
            numEfectivoReal.DecimalPlaces = 2;
        }

        private void CargarDatos()
        {
            CargarCajaActual();
            CargarUsuarios();
            CargarHistorial();
        }

        private void CargarCajaActual()
        {
            _cajaActual = CajaRepository.ObtenerCajaAbierta();

            if (_cajaActual != null)
            {
                // Caja abierta - mostrar información
                lblCajaAbierta.Text = "CAJA ABIERTA";
                lblCajaAbierta.ForeColor = Color.Green;

                string nombreUsuario = ObtenerNombreUsuario(_cajaActual.UsuarioID);
                lblEncargado.Text = $"Encargado: {nombreUsuario}";
                lblTurno.Text = $"Turno: {_cajaActual.Turno}";
                lblAperturaFechaHora.Text = $"Apertura: {_cajaActual.FechaApertura:dd/MM/yyyy} {_cajaActual.HoraApertura:hh\\:mm}";
                lblFondoInicial.Text = $"Fondo Inicial: S/ {_cajaActual.MontoInicial:N2}";

                ActualizarTiempoTranscurrido();
                CargarResumenVentas();

                btnCerrarCaja.Enabled = true;
                numEfectivoReal.Enabled = true;
                pnlArqueo.Enabled = true;
            }
            else
            {
                // No hay caja abierta
                lblCajaAbierta.Text = "NO HAY CAJA ABIERTA";
                lblCajaAbierta.ForeColor = Color.Red;
                lblEncargado.Text = "Encargado: -";
                lblTurno.Text = "Turno: -";
                lblAperturaFechaHora.Text = "Apertura: -";
                lblFondoInicial.Text = "Fondo Inicial: S/ 0.00";
                lblTiempoTranscurrido.Text = "Tiempo transcurrido: -";

                // Limpiar resumen
                lblOperaciones.Text = "Operaciones: 0";
                txtEfectivoCantidad.Text = "S/ 0.00";
                txtYapeCantidad.Text = "S/ 0.00";
                txtTransferenciaCantidad.Text = "S/ 0.00";
                txtCreditoCantidad.Text = "S/ 0.00";
                txtTotalCantidad.Text = "S/ 0.00";
                lblApertura.Text = "Apertura: -";

                // Arqueo
                txtEfectivoEsperado.Text = "S/ 0.00";
                txtDiferenciaCantidad.Text = "S/ 0.00";
                txtDiferenciaCantidad.ForeColor = Color.Green;
                numEfectivoReal.Value = 0;

                btnCerrarCaja.Enabled = false;
                numEfectivoReal.Enabled = false;
                pnlArqueo.Enabled = false;
            }
        }

        private void CargarResumenVentas()
        {
            if (_cajaActual == null) return;

            var resumen = CajaRepository.ObtenerResumenVentas(_cajaActual.CajaID);

            lblOperaciones.Text = $"Operaciones: {resumen.Operaciones}";
            lblApertura.Text = $"Apertura: {_cajaActual.FechaApertura:dd/MM/yyyy} {_cajaActual.HoraApertura:hh\\:mm}";

            txtEfectivoCantidad.Text = $"S/ {resumen.TotalEfectivo:N2}";
            txtYapeCantidad.Text = $"S/ {resumen.TotalYape:N2}";
            txtTransferenciaCantidad.Text = $"S/ {resumen.TotalTransferencia:N2}";
            txtCreditoCantidad.Text = $"S/ {resumen.TotalCredito:N2}";
            txtTotalCantidad.Text = $"S/ {resumen.TotalVentas:N2}";

            // Efectivo esperado = Fondo inicial + Ventas en efectivo - Gastos en efectivo
            decimal efectivoEsperado = _cajaActual.MontoInicial + resumen.TotalEfectivo - resumen.TotalGastos;
            txtEfectivoEsperado.Text = $"S/ {efectivoEsperado:N2}";

            // Iniciar efectivo real con el efectivo esperado para que diferencia sea 0
            if (numEfectivoReal.Value == 0 || numEfectivoReal.Value == _cajaActual.MontoInicial)
            {
                numEfectivoReal.Value = Math.Max(0, efectivoEsperado);
            }

            ActualizarDiferencia();
        }

        private void ActualizarTiempoTranscurrido()
        {
            if (_cajaActual == null) return;

            var inicio = _cajaActual.FechaApertura.Date + _cajaActual.HoraApertura;
            var transcurrido = DateTime.Now - inicio;

            lblTiempoTranscurrido.Text = $"Tiempo transcurrido: {(int)transcurrido.TotalHours}h {transcurrido.Minutes}m";
        }

        private void NumEfectivoReal_ValueChanged(object sender, EventArgs e)
        {
            ActualizarDiferencia();
        }

        private void NumEfectivoReal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ActualizarDiferencia();
                txtMotivo.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void TxtMotivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCerrarCaja.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void ActualizarDiferencia()
        {
            if (_cajaActual == null) return;

            var resumen = CajaRepository.ObtenerResumenVentas(_cajaActual.CajaID);
            decimal efectivoEsperado = _cajaActual.MontoInicial + resumen.TotalEfectivo - resumen.TotalGastos;
            decimal efectivoReal = numEfectivoReal.Value;
            decimal diferencia = efectivoReal - efectivoEsperado;

            txtDiferenciaCantidad.Text = $"S/ {diferencia:N2}";
            txtDiferenciaCantidad.ForeColor = diferencia != 0 ? Color.Red : Color.Green;
        }

        private void CargarUsuarios()
        {
            _usuarios = CajaRepository.ObtenerUsuariosConCajas();

            cmbUsuarios.Items.Clear();
            cmbUsuarios.Items.Add("TODOS");

            foreach (var u in _usuarios)
                cmbUsuarios.Items.Add(u.NombreCompleto);

            cmbUsuarios.SelectedIndex = 0;
        }

        private void CargarHistorial()
        {
            int? usuarioID = null;
            if (cmbUsuarios.SelectedIndex > 0)
                usuarioID = _usuarios[cmbUsuarios.SelectedIndex - 1].UsuarioID;

            var historial = CajaRepository.Listar(dtpDesde.Value.Date, dtpHasta.Value.Date, usuarioID);

            dgvHistorialCaja.Rows.Clear();
            int numero = 1;

            foreach (var caja in historial)
            {
                int index = dgvHistorialCaja.Rows.Add();
                var row = dgvHistorialCaja.Rows[index];

                row.Cells["colNumero"].Value = numero++;
                row.Cells["colFechaHora"].Value = caja.FechaApertura.ToString("dd/MM/yyyy");
                row.Cells["colCategoria"].Value = caja.HoraApertura.ToString(@"hh\:mm");
                row.Cells["colStocktotal"].Value = caja.HoraCierre?.ToString(@"hh\:mm") ?? "-";
                row.Cells["colStockMinimo"].Value = caja.Duracion;
                row.Cells["colEstado"].Value = caja.NombreUsuario;
                row.Cells["colIngresos"].Value = $"S/ {caja.TotalVentas:N2}";

                row.Tag = caja.CajaID;
            }

            lblTotalRegistros.Text = $"Total: {historial.Count} registros";
        }

        private void FiltrosChanged(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void DgvHistorialCaja_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int cajaID = Convert.ToInt32(dgvHistorialCaja.Rows[e.RowIndex].Tag);
            string columnName = dgvHistorialCaja.Columns[e.ColumnIndex].Name;

            if (columnName == "colVer")
            {
                var formDetalle = new FormDetalleCaja(cajaID);
                formDetalle.ShowDialog();
            }
        }

        private void BtnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (_cajaActual == null)
            {
                MessageBox.Show("No hay caja abierta para cerrar", "Aviso");
                return;
            }

            var resumen = CajaRepository.ObtenerResumenVentas(_cajaActual.CajaID);
            decimal efectivoEsperado = _cajaActual.MontoInicial + resumen.TotalEfectivo - resumen.TotalGastos;
            decimal efectivoReal = numEfectivoReal.Value;
            decimal diferencia = efectivoReal - efectivoEsperado;

            // Si hay diferencia, exigir motivo
            string motivo = txtMotivo.Text.Trim();
            if (diferencia != 0 && string.IsNullOrWhiteSpace(motivo))
            {
                MessageBox.Show("Debe ingresar un motivo para la diferencia", "Validación");
                txtMotivo.Focus();
                return;
            }

            var confirmacion = MessageBox.Show(
                $"¿Está seguro de cerrar la caja?\n\n" +
                $"Efectivo esperado: S/ {efectivoEsperado:N2}\n" +
                $"Efectivo real: S/ {efectivoReal:N2}\n" +
                $"Diferencia: S/ {diferencia:N2}",
                "Confirmar cierre",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                if (CajaRepository.CerrarCaja(_cajaActual.CajaID, efectivoReal, motivo))
                {
                    MessageBox.Show("Caja cerrada exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (chkImprimir.Checked)
                    {
                        var parametros = ReportHelper.GetCompanyParameters();
                        ReportDataSourceHelper.ObtenerParametrosDetalleCaja(_cajaActual.CajaID, parametros);

                        var dataSources = new Dictionary<string, DataTable>();

                        ReportHelper.MostrarDialogoExportacion(
                            ReportHelper.GetRdlcPath(@"Documents\RptDetalleCaja.rdlc"),
                            dataSources, parametros, "cierre_caja");
                    }

                    txtMotivo.Clear();
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al cerrar la caja", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCapitalInicial_Click(object sender, EventArgs e)
        {
            if (_cajaActual == null)
            {
                MessageBox.Show("No hay caja abierta. Abra una caja antes de registrar capital inicial.",
                    "Sin caja activa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Dialog simple para pedir monto
            decimal monto = 0;
            using (var dlg = new Form())
            {
                dlg.Text = "Capital Inicial";
                dlg.ClientSize = new System.Drawing.Size(320, 120);
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;

                var lbl = new Label { Text = "Monto (S/):", Location = new System.Drawing.Point(16, 18), AutoSize = true };
                var num = new System.Windows.Forms.NumericUpDown
                {
                    Location = new System.Drawing.Point(16, 38),
                    Size = new System.Drawing.Size(180, 26),
                    DecimalPlaces = 2,
                    Minimum = 0,
                    Maximum = 9999999,
                    Value = 0
                };
                var btnOk = new Button
                {
                    Text = "Aceptar",
                    DialogResult = DialogResult.OK,
                    Location = new System.Drawing.Point(200, 36),
                    Size = new System.Drawing.Size(100, 28)
                };
                dlg.Controls.AddRange(new System.Windows.Forms.Control[] { lbl, num, btnOk });
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
                            _cajaActual.FechaApertura,
                            DateTime.Now.TimeOfDay,
                            monto,
                            SesionActual.Usuario.UsuarioID,
                            _cajaActual.CajaID,
                            conn, tx);
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }

                MessageBox.Show(
                    $"Asiento de capital inicial registrado.\nDr 101 Caja / Cr 300 Capital — S/ {monto:N2}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar capital inicial:\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerNombreUsuario(int usuarioID)
        {
            return UsuarioRepository.ObtenerNombreCompletoPorID(usuarioID);
        }

        private void IniciarTimer()
        {
            _timerActualizacion = new Timer();
            _timerActualizacion.Interval = 60000; // 1 minuto
            _timerActualizacion.Tick += (s, e) =>
            {
                ActualizarTiempoTranscurrido();
                CargarResumenVentas();
            };
            _timerActualizacion.Start();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timerActualizacion?.Stop();
            _timerActualizacion?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
