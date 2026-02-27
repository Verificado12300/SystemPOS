using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormHistorialPagosCxP : Form
    {
        private readonly int _cuentaID;
        private bool _huboCambios = false;

        public FormHistorialPagosCxP(int cuentaPorPagarID)
        {
            InitializeComponent();
            _cuentaID = cuentaPorPagarID;
        }

        private void FormHistorialPagosCxP_Load(object sender, EventArgs e)
        {
            try
            {
                CargarEncabezado();
                CargarPagos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarEncabezado()
        {
            var cx = CuentaPorPagarRepository.ObtenerPorID(_cuentaID);
            if (cx == null) return;

            lblSub.Text        = $"CxP #{_cuentaID}  —  {cx.Referencia}";
            lblInfoRef.Text    = cx.Referencia ?? "—";
            lblInfoProv.Text   = cx.NombreProveedor ?? "Sin proveedor";
            lblInfoTotal.Text  = $"S/ {cx.MontoTotal:N2}";
            lblInfoEstado.Text = cx.Estado ?? "—";

            Color estadoColor;
            switch (cx.Estado)
            {
                case "PENDIENTE": estadoColor = Color.FromArgb(243, 156, 18);  break;
                case "PARCIAL":   estadoColor = Color.FromArgb(241, 196, 15);  break;
                case "PAGADO":    estadoColor = Color.FromArgb(39, 174, 96);   break;
                case "ANULADO":   estadoColor = Color.FromArgb(149, 165, 166); break;
                default:          estadoColor = Color.FromArgb(44, 62, 80);    break;
            }
            lblInfoEstado.ForeColor = estadoColor;
        }

        private void CargarPagos()
        {
            dgvPagos.Rows.Clear();
            var pagos = CuentaPorPagarRepository.ObtenerPagos(_cuentaID);
            int n = 1;

            foreach (var p in pagos)
            {
                int idx = dgvPagos.Rows.Add();
                var row = dgvPagos.Rows[idx];

                row.Cells["colNro"].Value          = n++;
                row.Cells["colFecha"].Value        = p.Fecha.ToString("dd/MM/yyyy");
                row.Cells["colMonto"].Value        = $"S/ {p.Monto:N2}";
                row.Cells["colMetodo"].Value       = p.MetodoPago;
                row.Cells["colComprobante"].Value  = p.Comprobante ?? "";
                row.Cells["colAsiento"].Value      = p.AsientoId?.ToString() ?? "-";
                row.Cells["colEstadoPago"].Value   = p.Anulado ? "ANULADO" : "ACTIVO";
                row.Tag = p.PagoProveedorID;

                if (p.Anulado)
                {
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(149, 165, 166);
                    row.Cells["colEstadoPago"].Style.ForeColor = Color.FromArgb(149, 165, 166);
                }
                else
                {
                    row.Cells["colEstadoPago"].Style.ForeColor = Color.FromArgb(39, 174, 96);
                    row.Cells["colEstadoPago"].Style.Font = new Font(dgvPagos.Font, FontStyle.Bold);
                }
            }
        }

        private void DgvPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if (dgvPagos.Columns[e.ColumnIndex].Name != "colAnular") return;

                string estadoPago = dgvPagos.Rows[e.RowIndex].Cells["colEstadoPago"].Value?.ToString();
                if (estadoPago == "ANULADO")
                {
                    MessageBox.Show("Este pago ya está anulado.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string montoStr = dgvPagos.Rows[e.RowIndex].Cells["colMonto"].Value?.ToString() ?? "";
                int pagoID = Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Tag);

                var confirm = MessageBox.Show(
                    $"¿Anular el pago de {montoStr}?\n\n" +
                    "Se generará un asiento contable inverso (Dr Caja/Bancos / Cr Cuentas por Pagar).\n" +
                    "Esta acción no se puede deshacer.",
                    "Confirmar anulación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) return;

                CuentaPorPagarRepository.AnularPago(pagoID, SesionActual.Usuario.UsuarioID);
                _huboCambios = true;

                CargarEncabezado();
                CargarPagos();

                MessageBox.Show("Pago anulado correctamente.\nAsiento contable inverso generado.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al anular pago:\n\n{ex.Message}", "Error",
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
