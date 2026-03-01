using SistemaPOS.Data;
using SistemaPOS.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormHistorialCobros : Form
    {
        private readonly int _ventaID;
        private CuentaPorCobrarDetalle _cuenta;
        private bool _huboCambios = false;

        public FormHistorialCobros(CuentaPorCobrarDetalle cuenta)
        {
            InitializeComponent();
            _ventaID = cuenta.VentaID;
            _cuenta  = cuenta;
            ConfigurarDGV();
            btnCerrar.Click += BtnCerrar_Click;
            CargarDatos();
        }

        private void ConfigurarDGV()
        {
            if (!dgvPagos.Columns.Contains("colAnular"))
            {
                var col = new DataGridViewButtonColumn
                {
                    Name                     = "colAnular",
                    HeaderText               = "Anular",
                    UseColumnTextForButtonValue = false,
                    Width                    = 70,
                    FlatStyle                = FlatStyle.Flat
                };
                dgvPagos.Columns.Add(col);
                dgvPagos.CellContentClick += DgvPagos_CellContentClick;
            }
        }

        private void CargarDatos()
        {
            // Recargar estado de la cuenta desde BD para reflejar cambios
            var cuentas = CuentaPorCobrarRepository.Listar(clienteID: _cuenta.ClienteID);
            var actualizada = cuentas.Find(c => c.VentaID == _ventaID);
            if (actualizada != null) _cuenta = actualizada;

            // Cabecera
            lblNombreCliente.Text = _cuenta.NombreCliente;
            lblNumeroVenta.Text   = $"Venta: {_cuenta.NumeroVenta}";
            lblFechaVenta.Text    = $"Fecha: {_cuenta.FechaVenta:dd/MM/yyyy}";
            lblVencimiento.Text   = $"Vence: {_cuenta.FechaVencimiento:dd/MM/yyyy}";

            // Tarjetas resumen
            lblCardTotal.Text  = $"S/ {_cuenta.TotalCredito:N2}";
            lblCardPagado.Text = $"S/ {_cuenta.MontoPagado:N2}";
            lblCardSaldo.Text  = $"S/ {_cuenta.SaldoPendiente:N2}";
            lblCardSaldo.ForeColor = _cuenta.SaldoPendiente > 0
                ? Color.FromArgb(214, 48, 49)
                : Color.FromArgb(39, 174, 96);

            // Estado badge
            lblEstado.Text = _cuenta.Estado;
            switch (_cuenta.Estado)
            {
                case "PAGADO":    lblEstado.BackColor = Color.FromArgb(39, 174, 96);  break;
                case "VENCIDO":   lblEstado.BackColor = Color.FromArgb(214, 48, 49);  break;
                case "PARCIAL":   lblEstado.BackColor = Color.FromArgb(225, 112, 85); break;
                default:          lblEstado.BackColor = Color.FromArgb(243, 156, 18); break;
            }

            // Historial de pagos
            var pagos = CuentaPorCobrarRepository.ObtenerPagosVenta(_ventaID);
            dgvPagos.Rows.Clear();

            decimal totalAplicado = 0;
            int num = 1;
            foreach (var p in pagos)
            {
                int idx = dgvPagos.Rows.Add();
                var row = dgvPagos.Rows[idx];
                row.Tag = p.PagoVentaID;

                row.Cells["colNum"].Value   = num++;
                row.Cells["colFecha"].Value = p.Fecha.ToString("dd/MM/yyyy");
                row.Cells["colHora"].Value  = p.Hora.ToString(@"hh\:mm");
                row.Cells["colMetodo"].Value = p.MetodoPago;
                row.Cells["colObs"].Value   = string.IsNullOrWhiteSpace(p.Observaciones) ? "-" : p.Observaciones;

                if (p.Anulado)
                {
                    row.Cells["colMonto"].Value  = $"[ANULADO] S/ {p.MontoAplicado:N2}";
                    row.Cells["colAnular"].Value = "—";
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(149, 165, 166);
                    row.Cells["colMetodo"].Style.ForeColor = Color.FromArgb(149, 165, 166);
                }
                else
                {
                    row.Cells["colMonto"].Value  = $"S/ {p.MontoAplicado:N2}";
                    row.Cells["colAnular"].Value = "Anular";
                    totalAplicado += p.MontoAplicado;

                    Color metodoColor;
                    switch (p.MetodoPago)
                    {
                        case "EFECTIVO":      metodoColor = Color.FromArgb(0, 184, 148);   break;
                        case "YAPE":          metodoColor = Color.FromArgb(108, 92, 231);  break;
                        case "TRANSFERENCIA": metodoColor = Color.FromArgb(9, 132, 227);   break;
                        case "MIXTO":         metodoColor = Color.FromArgb(253, 203, 110); break;
                        default:              metodoColor = Color.FromArgb(99, 110, 114);  break;
                    }
                    row.Cells["colMetodo"].Style.ForeColor = metodoColor;
                    row.Cells["colMetodo"].Style.Font = new Font(dgvPagos.Font, FontStyle.Bold);
                }
            }

            lblSinPagos.Visible = pagos.Count == 0;
            dgvPagos.Visible    = pagos.Count > 0;

            int activos = pagos.FindAll(p => !p.Anulado).Count;
            lblResumen.Text = $"{pagos.Count} pago(s) registrado(s) ({activos} activo(s))  |  Total cobrado activo: S/ {totalAplicado:N2}";
        }

        private void DgvPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if (dgvPagos.Columns[e.ColumnIndex].Name != "colAnular") return;

                string btnText = dgvPagos.Rows[e.RowIndex].Cells["colAnular"].Value?.ToString();
                if (btnText == "—")
                {
                    MessageBox.Show("Este cobro ya está anulado.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int pagoVentaID = Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Tag);
                string montoStr = dgvPagos.Rows[e.RowIndex].Cells["colMonto"].Value?.ToString() ?? "";

                var confirm = MessageBox.Show(
                    $"¿Anular el cobro de {montoStr}?\n\n" +
                    "Se generará un asiento contable inverso (Dr CxC / Cr Caja/Bancos).\n" +
                    "Esta acción no se puede deshacer.",
                    "Confirmar anulación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) return;

                ClienteRepository.AnularPagoCxC(pagoVentaID, SesionActual.Usuario?.UsuarioID ?? 0);
                _huboCambios = true;
                CargarDatos();

                MessageBox.Show("Cobro anulado correctamente.\nAsiento contable inverso generado.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al anular cobro:\n\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = _huboCambios ? DialogResult.OK : DialogResult.Cancel;
            this.Close();
        }
    }
}
