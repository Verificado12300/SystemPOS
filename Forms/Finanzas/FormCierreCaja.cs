using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Reports.DataSources;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormCierreCaja : Form
    {
        private readonly Caja _caja;
        private decimal _totalMoneteo;

        private static readonly decimal[] Denominaciones =
            { 200m, 100m, 50m, 20m, 10m, 5m, 2m, 1m, 0.50m, 0.20m, 0.10m };

        public FormCierreCaja() { InitializeComponent(); }

        public FormCierreCaja(Caja caja)
        {
            InitializeComponent();
            _caja = caja;
            ConfigurarEventos();
            InicializarMoneteo();
            MostrarPaso(1);
        }

        private void ConfigurarEventos()
        {
            dgvMoneteo.CellValueChanged += DgvMoneteo_CellValueChanged;
            dgvMoneteo.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dgvMoneteo.IsCurrentCellDirty)
                    dgvMoneteo.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };

            btnPaso1Cancelar.Click  += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            btnPaso1Siguiente.Click += BtnPaso1Siguiente_Click;
            btnPaso2Atras.Click     += (s, e) => MostrarPaso(1);
            btnPaso2Confirmar.Click += BtnPaso2Confirmar_Click;
            btnPaso3Cerrar.Click    += (s, e) => { DialogResult = DialogResult.OK; Close(); };
        }

        // ─── Step Navigation ──────────────────────────────────────────────────
        private void MostrarPaso(int paso)
        {
            pnlPaso1.Visible = paso == 1;
            pnlPaso2.Visible = paso == 2;
            pnlPaso3.Visible = paso == 3;

            lblPasoIndicador.Text = paso == 1 ? "Paso 1 de 3  —  Conteo de Efectivo (Moneteo)"
                : paso == 2 ? "Paso 2 de 3  —  Verificación del Cierre"
                : "Paso 3 de 3  —  Turno Cerrado Exitosamente";

            if (paso == 2) ActualizarResumenCierre();
        }

        // ─── Paso 1: Moneteo ──────────────────────────────────────────────────
        private void InicializarMoneteo()
        {
            dgvMoneteo.Rows.Clear();
            var existente = new Dictionary<decimal, int>();
            foreach (var d in CajaRepository.ObtenerMoneteo(_caja.CajaID))
                existente[d.Denominacion] = d.Cantidad;

            decimal total = 0;
            foreach (var den in Denominaciones)
            {
                int cant = existente.ContainsKey(den) ? existente[den] : 0;
                decimal sub = den * cant;
                total += sub;
                int idx = dgvMoneteo.Rows.Add();
                var row = dgvMoneteo.Rows[idx];
                row.Cells["colMonDenominacion"].Value = $"S/ {den:N2}";
                row.Cells["colMonCantidad"].Value     = cant;
                row.Cells["colMonSubtotal"].Value     = $"S/ {sub:N2}";
                row.Cells["colMonDenominacion"].ReadOnly = true;
                row.Cells["colMonSubtotal"].ReadOnly     = true;
                row.Tag = den;
            }
            _totalMoneteo = total;
            lblMoneteoTotalMonto.Text = $"S/ {total:N2}";
        }

        private void DgvMoneteo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvMoneteo.Columns[e.ColumnIndex].Name != "colMonCantidad") return;

            var row = dgvMoneteo.Rows[e.RowIndex];
            decimal den = row.Tag != null ? (decimal)row.Tag : 0m;

            if (!int.TryParse(row.Cells["colMonCantidad"].Value?.ToString(), out int cant) || cant < 0)
            {
                cant = 0;
                row.Cells["colMonCantidad"].Value = 0;
            }
            row.Cells["colMonSubtotal"].Value = $"S/ {den * cant:N2}";

            decimal total = 0;
            foreach (DataGridViewRow r in dgvMoneteo.Rows)
            {
                if (r.Tag == null) continue;
                int.TryParse(r.Cells["colMonCantidad"].Value?.ToString(), out int c);
                total += (decimal)r.Tag * c;
            }
            _totalMoneteo = total;
            lblMoneteoTotalMonto.Text = $"S/ {total:N2}";
        }

        private void BtnPaso1Siguiente_Click(object sender, EventArgs e)
        {
            try
            {
                var detalles = new List<CajaMoneteoDetalle>();
                foreach (DataGridViewRow row in dgvMoneteo.Rows)
                {
                    if (row.Tag == null) continue;
                    decimal den = (decimal)row.Tag;
                    int.TryParse(row.Cells["colMonCantidad"].Value?.ToString(), out int cant);
                    if (cant > 0)
                        detalles.Add(new CajaMoneteoDetalle
                        {
                            Denominacion = den, Cantidad = cant, Subtotal = den * cant
                        });
                }
                if (detalles.Count > 0)
                    CajaRepository.RegistrarMoneteo(_caja.CajaID, detalles);
            }
            catch { /* Non-critical — proceed to paso 2 */ }

            MostrarPaso(2);
        }

        // ─── Paso 2: Verificación ─────────────────────────────────────────────
        private void ActualizarResumenCierre()
        {
            var resumen = CajaRepository.ObtenerResumenVentas(_caja.CajaID);
            decimal efectivoEsperado = _caja.MontoInicial
                + resumen.TotalEfectivo + resumen.ConversionEfectivo
                - resumen.TotalGastos;
            decimal diferencia = _totalMoneteo - efectivoEsperado;

            lblResVentasVal.Text        = $"S/ {resumen.TotalVentas:N2}";
            lblResEfectivoVal.Text      = $"S/ {resumen.TotalEfectivoAjustado:N2}";
            lblResYapeVal.Text          = $"S/ {resumen.TotalYapeAjustado:N2}";
            lblResTransferenciaVal.Text = $"S/ {resumen.TotalTransferenciaAjustado:N2}";
            lblResCreditoVal.Text       = $"S/ {resumen.TotalCredito:N2}";
            lblResGastosVal.Text        = $"S/ {resumen.TotalGastos:N2}";
            lblResFondoVal.Text         = $"S/ {_caja.MontoInicial:N2}";
            lblResEsperadoVal.Text      = $"S/ {efectivoEsperado:N2}";
            lblResMoneteoVal.Text       = $"S/ {_totalMoneteo:N2}";
            lblResDiferenciaVal.Text    = $"S/ {diferencia:N2}";
            lblResDiferenciaVal.ForeColor = diferencia == 0
                ? Color.FromArgb(39, 174, 96)
                : Color.FromArgb(231, 76, 60);

            bool necesitaMotivo = diferencia != 0;
            lblResObsTxt.Visible          = necesitaMotivo;
            txtObservacionCierre.Visible  = necesitaMotivo;
        }

        private void BtnPaso2Confirmar_Click(object sender, EventArgs e)
        {
            var resumen = CajaRepository.ObtenerResumenVentas(_caja.CajaID);
            decimal efectivoEsperado = _caja.MontoInicial
                + resumen.TotalEfectivo + resumen.ConversionEfectivo
                - resumen.TotalGastos;
            decimal diferencia = _totalMoneteo - efectivoEsperado;
            string motivo = txtObservacionCierre.Text.Trim();

            if (diferencia != 0 && string.IsNullOrWhiteSpace(motivo))
            {
                MessageBox.Show("Ingrese una observación para justificar la diferencia.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtObservacionCierre.Focus();
                return;
            }

            try
            {
                if (!CajaRepository.CerrarCaja(_caja.CajaID, _totalMoneteo, motivo))
                {
                    MessageBox.Show("Error al cerrar el turno.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (chkImprimirCierre.Checked)
                {
                    try
                    {
                        var parametros = ReportHelper.GetCompanyParameters();
                        ReportDataSourceHelper.ObtenerParametrosDetalleCaja(_caja.CajaID, parametros);
                        ReportHelper.MostrarDialogoExportacion(
                            ReportHelper.GetRdlcPath(@"Documents\RptDetalleCaja.rdlc"),
                            new Dictionary<string, DataTable>(), parametros, "cierre_caja");
                    }
                    catch { /* Non-critical */ }
                }

                lblResumenFinalTurno.Text    = $"Turno {_caja.Turno}  —  {_caja.FechaApertura:dd/MM/yyyy}";
                lblResumenFinalTotal.Text    = $"Total Ventas:  S/ {resumen.TotalVentas:N2}";
                var dur = DateTime.Now - (_caja.FechaApertura.Date + _caja.HoraApertura);
                lblResumenFinalDuracion.Text = $"Duración del turno:  {(int)dur.TotalHours}h {dur.Minutes}m";
                MostrarPaso(3);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
