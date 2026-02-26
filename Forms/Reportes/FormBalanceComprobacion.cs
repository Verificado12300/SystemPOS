using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaPOS.Data;

namespace SistemaPOS.Forms.Reportes
{
    public partial class FormBalanceComprobacion : Form
    {
        public FormBalanceComprobacion()
        {
            InitializeComponent();
        }

        private void FormBalanceComprobacion_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
            dtpHasta.Value = DateTime.Now;

            dgvComprobacion.AutoGenerateColumns = false;
            dgvComprobacion.AllowUserToAddRows  = false;
            dgvComprobacion.ReadOnly            = true;

            btnBuscar.Click       += (s, ev) => CargarDatos();
            dtpDesde.ValueChanged += (s, ev) => CargarDatos();
            dtpHasta.ValueChanged += (s, ev) => CargarDatos();

            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                dgvComprobacion.Rows.Clear();

                var items = ContabilidadService.ObtenerBalanceComprobacion(
                    dtpDesde.Value.Date, dtpHasta.Value.Date);

                decimal totalDebe  = 0m;
                decimal totalHaber = 0m;

                foreach (var item in items)
                {
                    int idx = dgvComprobacion.Rows.Add(
                        item.Codigo,
                        item.Nombre,
                        item.Tipo,
                        $"S/ {item.Debe:N2}",
                        $"S/ {item.Haber:N2}",
                        $"S/ {item.Saldo:N2}");

                    if (item.Saldo < 0)
                        dgvComprobacion.Rows[idx].Cells["colSaldo"].Style.ForeColor = Color.Red;

                    totalDebe  += item.Debe;
                    totalHaber += item.Haber;
                }

                decimal diferencia = totalDebe - totalHaber;

                lblTotalDebe.Text  = $"S/ {totalDebe:N2}";
                lblTotalHaber.Text = $"S/ {totalHaber:N2}";
                lblDiferencia.Text = $"S/ {diferencia:N2}";
                lblDiferencia.ForeColor = Math.Abs(diferencia) > 0.01m
                    ? Color.Red
                    : Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
