using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Principal
{
    public partial class FormRegistroInicial : Form
    {
        public FormRegistroInicial()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        private static readonly Color ColorAccent  = Color.FromArgb(16, 185, 129);
        private static readonly Color ColorLinea   = Color.FromArgb(226, 232, 240);

        private void ConfigurarEventos()
        {
            btnRegistrarse.Click += BtnRegistrarse_Click;
            btnMostrarClave.Click += BtnMostrarClave_Click;
            btnMostrarClave2.Click += BtnMostrarClave2_Click;

            pnlLeft.Paint += (s, e) =>
            {
                using (var brush = new LinearGradientBrush(
                    pnlLeft.ClientRectangle,
                    Color.FromArgb(5, 46, 37), Color.FromArgb(2, 20, 16),
                    LinearGradientMode.Vertical))
                    e.Graphics.FillRectangle(brush, pnlLeft.ClientRectangle);
            };

            pnlDeco1.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var b = new SolidBrush(Color.FromArgb(30, 16, 185, 129)))
                    e.Graphics.FillEllipse(b, 0, 0, pnlDeco1.Width, pnlDeco1.Height);
            };

            pnlDeco2.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var b = new SolidBrush(Color.FromArgb(20, 16, 185, 129)))
                    e.Graphics.FillEllipse(b, 0, 0, pnlDeco2.Width, pnlDeco2.Height);
            };

            ConfigurarFocusUnderline(txtNombreUsuario,      pnlLineNombreU);
            ConfigurarFocusUnderline(txtCorreo,             pnlLineCorreo);
            ConfigurarFocusUnderline(txtContraseña,         pnlLineContra);
            ConfigurarFocusUnderline(txtConfirmarContraseña, pnlLineConfirmar);
        }

        private void ConfigurarFocusUnderline(TextBox txt, Panel line)
        {
            txt.Enter += (s, e) => line.BackColor = ColorAccent;
            txt.Leave += (s, e) => line.BackColor = ColorLinea;
        }

        private void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                var usuario = new Usuario
                {
                    NombreCompleto = txtNombreUsuario.Text.Trim(),
                    NombreUsuario = txtNombreUsuario.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtCorreo.Text) ? null : txtCorreo.Text.Trim(),
                    Contraseña = PasswordHelper.HashPassword(txtContraseña.Text.Trim()),
                    DNI = "00000000",
                    RolID = 1,
                    Activo = true
                };

                bool resultado = UsuarioRepository.Crear(usuario);

                if (resultado)
                {
                    MessageBox.Show(
                        "¡Cuenta de administrador creada exitosamente!\n\nYa puedes iniciar sesión.",
                        "Registro Exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo crear la cuenta.", "Error",
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
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("Ingresa un nombre de usuario", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return false;
            }
            if (txtNombreUsuario.Text.Trim().Length < 4)
            {
                MessageBox.Show("El nombre de usuario debe tener al menos 4 caracteres", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return false;
            }
            if (UsuarioRepository.ExisteNombreUsuario(txtNombreUsuario.Text.Trim()))
            {
                MessageBox.Show("Este nombre de usuario ya está en uso", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtCorreo.Text) && !txtCorreo.Text.Contains("@"))
            {
                MessageBox.Show("Ingresa un correo electrónico válido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Ingresa una contraseña", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Focus();
                return false;
            }
            if (txtContraseña.Text.Length < 3)
            {
                MessageBox.Show("La contraseña debe tener al menos 3 caracteres", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtConfirmarContraseña.Text))
            {
                MessageBox.Show("Confirma tu contraseña", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarContraseña.Focus();
                return false;
            }
            if (txtContraseña.Text.Trim() != txtConfirmarContraseña.Text.Trim())
            {
                MessageBox.Show("Las contraseñas no coinciden", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarContraseña.Focus();
                return false;
            }
            return true;
        }

        private void BtnMostrarClave_Click(object sender, EventArgs e)
        {
            if (txtContraseña.PasswordChar == '*')
            {
                txtContraseña.PasswordChar = '\0';
                btnMostrarClave.Text = "🙈";
            }
            else
            {
                txtContraseña.PasswordChar = '*';
                btnMostrarClave.Text = "👁";
            }
        }

        private void BtnMostrarClave2_Click(object sender, EventArgs e)
        {
            if (txtConfirmarContraseña.PasswordChar == '*')
            {
                txtConfirmarContraseña.PasswordChar = '\0';
                btnMostrarClave2.Text = "🙈";
            }
            else
            {
                txtConfirmarContraseña.PasswordChar = '*';
                btnMostrarClave2.Text = "👁";
            }
        }

        private void TxtSoloTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}