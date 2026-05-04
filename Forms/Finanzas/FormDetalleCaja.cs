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
    public partial class FormDetalleCaja : Form
    {
        private int _cajaID;
        private Caja _caja;

        public FormDetalleCaja(int cajaID)
        {
            InitializeComponent();
            _cajaID = cajaID;
            ConfigurarEventos();
            DgvStyleHelper.Aplicar(dgvVentasTurno);
            DgvStyleHelper.Aplicar(dgvGastosTurno);
            CargarDatos();
        }

        public FormDetalleCaja()
        {
            InitializeComponent();
        }

        private void ConfigurarEventos()
        {
            btnCerrar.Click += (s, e) => this.Close();
            btnImprimir.Click += BtnImprimir_Click;
            btnExportar.Click += BtnExportar_Click;
            dgvVentasTurno.CellPainting += DgvVentasTurno_CellPainting;
        }

        private void DgvVentasTurno_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvVentasTurno.Columns[e.ColumnIndex].Name != "colVentaMetodoD") return;

            e.PaintBackground(e.ClipBounds, true);

            string val = e.Value?.ToString() ?? "";
            Color bg, fg;
            switch (val)
            {
                case "EFECTIVO":      bg = Color.FromArgb(241, 245, 249); fg = Color.FromArgb(51, 65, 85);    break;
                case "YAPE":          bg = Color.FromArgb(237, 233, 254); fg = Color.FromArgb(91, 33, 182);   break;
                case "TRANSFERENCIA": bg = Color.FromArgb(219, 234, 254); fg = Color.FromArgb(30, 64, 175);   break;
                case "TARJETA":       bg = Color.FromArgb(204, 251, 241); fg = Color.FromArgb(17, 94, 89);    break;
                case "CREDITO":       bg = Color.FromArgb(254, 243, 199); fg = Color.FromArgb(146, 64, 14);   break;
                default:              bg = Color.FromArgb(241, 245, 249); fg = Color.FromArgb(100, 116, 139); break;
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

        private void CargarDatos()
        {
            _caja = CajaRepository.ObtenerPorID(_cajaID);

            if (_caja == null)
            {
                MessageBox.Show("No se encontró la información de la caja", "Error");
                this.Close();
                return;
            }

            // Información del turno
            string nombreUsuario = ObtenerNombreUsuario(_caja.UsuarioID);
            lblEncargado.Text = $"Encargado: {nombreUsuario}";
            lblFecha.Text = $"Fecha: {_caja.FechaApertura:dd/MM/yyyy}";
            lblHora.Text = $"Hora Apertura: {_caja.HoraApertura:hh\\:mm\\:ss}";
            lblTipoComprobante.Text = $"Turno: {_caja.Turno}";

            if (_caja.HoraCierre.HasValue)
            {
                var duracion = _caja.HoraCierre.Value - _caja.HoraApertura;
                lblNumeroSerie.Text = $"Duración: {(int)duracion.TotalHours}h {duracion.Minutes}m";
                lblEstado.Text = $"Hora Cierre: {_caja.HoraCierre.Value:hh\\:mm}";
            }
            else
            {
                lblNumeroSerie.Text = "Duración: En curso";
                lblEstado.Text = "Hora Cierre: -";
            }

            // Fondo inicial en panel info turno
            txtFondoInicial1.Text = $"S/ {_caja.MontoInicial:N2}";

            // Resumen de ingresos
            lblOperaciones.Text = $"Operaciones: {ObtenerCantidadOperaciones()}";
            txtEfectivoCantidad.Text = $"S/ {_caja.TotalEfectivo:N2}";
            txtYapeCantidad.Text = $"S/ {_caja.TotalYape:N2}";
            txtTransferenciaCantidad.Text = $"S/ {_caja.TotalTransferencia:N2}";
            txtCreditoCantidad.Text = $"S/ {_caja.TotalCredito:N2}";

            txtTotalCantidad.Text = $"S/ {_caja.TotalVentas:N2}";

            // Arqueo de efectivo
            txtFondoInicial.Text = $"S/ {_caja.MontoInicial:N2}";
            txtEfectivoVentas.Text = $"S/ {_caja.TotalEfectivo:N2}";
            txtEfectivoEsperado.Text = $"S/ {_caja.EfectivoEsperado:N2}";
            txtEfectivoReal.Text = $"S/ {_caja.EfectivoReal:N2}";

            // Diferencia - solo color rojo si no cuadra
            txtDiferenciaCantidad.Text = $"S/ {_caja.Diferencia:N2}";
            txtDiferenciaCantidad.ForeColor = _caja.Diferencia != 0 ? Color.Red : Color.Green;

            // Motivo
            txtMotivo.Text = _caja.MotivoDiferencia ?? "";
            txtMotivo.ReadOnly = true;

            // Gastos en efectivo del turno
            if (_caja.TotalGastos > 0)
            {
                txtObservaciones.Text = $"Gastos en efectivo del turno: S/ {_caja.TotalGastos:N2}";
            }
            else
            {
                txtObservaciones.Text = "Sin gastos registrados en este turno";
            }
            txtObservaciones.ReadOnly = true;

            CargarDetalleTransacciones();
        }

        private void CargarDetalleTransacciones()
        {
            try
            {
                // Ventas del turno
                dgvVentasTurno.Rows.Clear();
                var ventas = CajaRepository.ObtenerVentasDelTurno(_cajaID);
                foreach (var v in ventas)
                {
                    int idx = dgvVentasTurno.Rows.Add();
                    var row = dgvVentasTurno.Rows[idx];
                    row.Cells["colVentaHoraD"].Value    = v.Hora;
                    row.Cells["colVentaNumeroD"].Value  = v.NumeroVenta;
                    row.Cells["colVentaClienteD"].Value = v.NombreCliente;
                    row.Cells["colVentaMetodoD"].Value  = v.Metodo;
                    row.Cells["colVentaTotalD"].Value   = $"S/ {v.Total:N2}";
                }

                // Gastos del turno
                dgvGastosTurno.Rows.Clear();
                var gastos = CajaRepository.ObtenerGastosDelTurno(_cajaID);
                foreach (var g in gastos)
                {
                    int idx = dgvGastosTurno.Rows.Add();
                    var row = dgvGastosTurno.Rows[idx];
                    row.Cells["colGastoHoraD"].Value     = g.Hora;
                    row.Cells["colGastoConceptoD"].Value = g.Concepto;
                    row.Cells["colGastoCategoriaD"].Value= g.Categoria;
                    row.Cells["colGastoMontoD"].Value    = $"S/ {g.Monto:N2}";
                }
            }
            catch { /* No bloquear el form si falla el detalle */ }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (_caja == null) return;

            try
            {
                var parametros = ReportHelper.GetCompanyParameters();
                ReportDataSourceHelper.ObtenerParametrosDetalleCaja(_cajaID, parametros);

                var dataSources = new Dictionary<string, DataTable>();

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Documents\RptDetalleCaja.rdlc"),
                    dataSources, parametros, "detalle_caja");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            if (_caja == null) return;

            try
            {
                var parametros = ReportHelper.GetCompanyParameters();
                ReportDataSourceHelper.ObtenerParametrosDetalleCaja(_cajaID, parametros);

                var dataSources = new Dictionary<string, DataTable>
                {
                    ["DsVentasCaja"]   = ReportDataSourceHelper.ObtenerDatosDetalleCajaVentas(_cajaID),
                    ["DsGastosCaja"]   = ReportDataSourceHelper.ObtenerDatosDetalleCajaGastos(_cajaID),
                    ["DsMoneteoCaja"]  = ReportDataSourceHelper.ObtenerDatosMoneteo(_cajaID)
                };

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Documents\RptDetalleCajaFull.rdlc"),
                    dataSources, parametros, "detalle_turno_completo");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ObtenerCantidadOperaciones()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    var cmd = new System.Data.SQLite.SQLiteCommand(
                        "SELECT COUNT(*) FROM Ventas WHERE CajaID = @cajaID AND Estado != 'ANULADA'", conn);
                    cmd.Parameters.AddWithValue("@cajaID", _cajaID);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch { return 0; }
        }

        private string ObtenerNombreUsuario(int usuarioID)
        {
            return UsuarioRepository.ObtenerNombreCompletoPorID(usuarioID);
        }
    }
}
