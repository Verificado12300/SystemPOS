using System;
using System.Windows.Forms;
using SistemaPOS.Data;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormConversion : Form
    {
        private readonly int _cajaID;

        public FormConversion(int cajaID)
        {
            InitializeComponent();
            _cajaID = cajaID;
            CargarMetodos();
        }

        private void CargarMetodos()
        {
            string[] metodos = { "EFECTIVO", "YAPE", "TARJETA", "TRANSFERENCIA" };
            cboOrigen.Items.AddRange(metodos);
            cboDestino.Items.AddRange(metodos);
            cboOrigen.SelectedIndex = 0;
            cboDestino.SelectedIndex = 1;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (cboOrigen.SelectedIndex < 0 || cboDestino.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione origen y destino.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string origen  = cboOrigen.SelectedItem.ToString();
            string destino = cboDestino.SelectedItem.ToString();

            if (origen == destino)
            {
                MessageBox.Show("El origen y destino deben ser diferentes.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numMonto.Value <= 0)
            {
                MessageBox.Show("El monto debe ser mayor a cero.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numMonto.Focus();
                return;
            }

            try
            {
                CajaRepository.RegistrarConversion(
                    _cajaID, origen, destino,
                    numMonto.Value,
                    txtObservacion.Text.Trim());

                MessageBox.Show(
                    $"Conversión registrada:\n{origen} → {destino}  S/ {numMonto.Value:N2}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
