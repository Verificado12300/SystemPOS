using System;
using System.ComponentModel;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormAperturaCaja : Form
    {
        public FormAperturaCaja()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            ConfigurarEventos();
            CargarDatos();
        }

        private void ConfigurarEventos()
        {
            btnAbrir.Click += BtnAbrir_Click;
        }

        private void CargarDatos()
        {
            // Mostrar usuario actual
            txtUsuario.Text = SesionActual.Usuario.NombreCompleto;
            txtUsuario.ReadOnly = true;

            // Fecha y hora actual
            dtpFecha.Value = DateTime.Now;
            dtpHora.Value = DateTime.Now;

            // Seleccionar turno según hora
            int hora = DateTime.Now.Hour;
            if (hora >= 6 && hora < 14)
                rbMañana.Checked = true;
            else if (hora >= 14 && hora < 22)
                rbTarde.Checked = true;
            else
                rbNoche.Checked = true;

            // Monto inicial en 0
            txtMontoInicial.Text = "0.00";
            txtMontoInicial.Focus();
            txtMontoInicial.SelectAll();
        }

        private void BtnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                string turno = rbMañana.Checked ? "MAÑANA" :
                               rbTarde.Checked ? "TARDE" : "NOCHE";

                if (!decimal.TryParse(txtMontoInicial.Text.Trim(), out decimal montoInicial))
                {
                    MessageBox.Show("Ingresa un monto inicial válido", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMontoInicial.Focus();
                    txtMontoInicial.SelectAll();
                    return;
                }

                var caja = new Caja
                {
                    UsuarioID = SesionActual.Usuario.UsuarioID,
                    Turno = turno,
                    FechaApertura = dtpFecha.Value.Date,
                    HoraApertura = dtpHora.Value.TimeOfDay,
                    MontoInicial = montoInicial,
                    Estado = "ABIERTA"
                };

                bool opened = chkCapitalInicial.Checked
                    ? CajaRepository.AbrirCaja(caja, true, SesionActual.Usuario.UsuarioID)
                    : CajaRepository.AbrirCaja(caja);

                if (opened)
                {
                    MessageBox.Show("Caja abierta exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al abrir caja", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (!rbMañana.Checked && !rbTarde.Checked && !rbNoche.Checked)
            {
                MessageBox.Show("Selecciona un turno", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMontoInicial.Text))
            {
                MessageBox.Show("Ingresa el monto inicial", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoInicial.Focus();
                return false;
            }

            // ← AGREGAR .Trim() AQUÍ
            if (!decimal.TryParse(txtMontoInicial.Text.Trim(), out decimal monto) || monto < 0)
            {
                MessageBox.Show("Ingresa un monto válido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoInicial.Focus();
                txtMontoInicial.SelectAll();
                return false;
            }

            return true;
        }
    }
}
