using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormAperturaCaja : Form
    {
        private static readonly Color ColorChipActive   = Color.FromArgb(99, 102, 241);
        private static readonly Color ColorChipInactive = Color.FromArgb(241, 245, 249);
        private static readonly Color ColorTextActive   = Color.White;
        private static readonly Color ColorTextInactive = Color.FromArgb(100, 116, 139);
        private string _inicialUsuario = "U";

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

            pnlChipMañana.Click += (s, e) => SeleccionarTurno("M");
            lblChipMañana.Click += (s, e) => SeleccionarTurno("M");
            pnlChipTarde.Click  += (s, e) => SeleccionarTurno("T");
            lblChipTarde.Click  += (s, e) => SeleccionarTurno("T");
            pnlChipNoche.Click  += (s, e) => SeleccionarTurno("N");
            lblChipNoche.Click  += (s, e) => SeleccionarTurno("N");

            // Gradiente fondo oscuro + sombra bajo la tarjeta
            this.Paint += (s, e) =>
            {
                using (var brush = new LinearGradientBrush(
                    this.ClientRectangle,
                    Color.FromArgb(15, 23, 42), Color.FromArgb(30, 41, 59),
                    LinearGradientMode.Vertical))
                    e.Graphics.FillRectangle(brush, this.ClientRectangle);

                using (var b = new SolidBrush(Color.FromArgb(70, 0, 0, 0)))
                    e.Graphics.FillRectangle(b, new System.Drawing.Rectangle(23, 30, 382, 338));
            };

            // Avatar circular con inicial del usuario
            pnlUserRow.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var b = new SolidBrush(Color.FromArgb(99, 102, 241)))
                    e.Graphics.FillEllipse(b, 8, 9, 22, 22);
                using (var f = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold))
                using (var sb = new SolidBrush(Color.White))
                {
                    var fmt = new System.Drawing.StringFormat
                    {
                        Alignment     = System.Drawing.StringAlignment.Center,
                        LineAlignment = System.Drawing.StringAlignment.Center
                    };
                    e.Graphics.DrawString(_inicialUsuario, f, sb,
                        new System.Drawing.RectangleF(8, 9, 22, 22), fmt);
                }
            };

            // Underline animado al enfocar el monto
            txtMontoInicial.Enter += (s, e) => pnlLineMonto.BackColor = Color.FromArgb(99, 102, 241);
            txtMontoInicial.Leave += (s, e) => pnlLineMonto.BackColor = Color.FromArgb(226, 232, 240);
        }

        private void SeleccionarTurno(string turno)
        {
            rbMañana.Checked = (turno == "M");
            rbTarde.Checked  = (turno == "T");
            rbNoche.Checked  = (turno == "N");
            ActualizarChipsTurno();
        }

        private void ActualizarChipsTurno()
        {
            SetChipEstado(pnlChipMañana, lblChipMañana, rbMañana.Checked);
            SetChipEstado(pnlChipTarde,  lblChipTarde,  rbTarde.Checked);
            SetChipEstado(pnlChipNoche,  lblChipNoche,  rbNoche.Checked);
        }

        private static void SetChipEstado(Panel panel, Label label, bool activo)
        {
            panel.BackColor = activo ? ColorChipActive   : ColorChipInactive;
            label.ForeColor = activo ? ColorTextActive   : ColorTextInactive;
        }

        private void CargarDatos()
        {
            txtUsuario.Text     = SesionActual.Usuario.NombreCompleto;
            txtUsuario.ReadOnly = true;

            _inicialUsuario = SesionActual.Usuario.NombreCompleto?.Length > 0
                ? SesionActual.Usuario.NombreCompleto.Substring(0, 1).ToUpper()
                : "U";

            lblDateDisplay.Text = DateTime.Now.ToString("ddd dd MMM yyyy",
                new System.Globalization.CultureInfo("es-PE")).ToUpper();

            dtpFecha.Value = DateTime.Now;
            dtpHora.Value  = DateTime.Now;

            int hora = DateTime.Now.Hour;
            if (hora >= 6 && hora < 14)
                SeleccionarTurno("M");
            else if (hora >= 14 && hora < 22)
                SeleccionarTurno("T");
            else
                SeleccionarTurno("N");

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
                               rbTarde.Checked  ? "TARDE"  : "NOCHE";

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
                    UsuarioID    = SesionActual.Usuario.UsuarioID,
                    Turno        = turno,
                    FechaApertura = dtpFecha.Value.Date,
                    HoraApertura  = dtpHora.Value.TimeOfDay,
                    MontoInicial  = montoInicial,
                    Estado        = "ABIERTA"
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

        private void dtpHora_ValueChanged(object sender, EventArgs e) { }

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

