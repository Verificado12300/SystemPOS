using SistemaPOS.Data;
using SistemaPOS.Forms.Finanzas;
using SistemaPOS.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaPOS.Forms.Principal
{
    public partial class FormLogin : Form
    {
        private static readonly object IntentosLock = new object();
        private static readonly Dictionary<string, (int Intentos, DateTime? BloqueoHasta)> IntentosFallidos
            = new Dictionary<string, (int, DateTime?)>(StringComparer.OrdinalIgnoreCase);

        private const int MaxIntentos   = 5;
        private const int MinutosBloqueo = 5;

        private static readonly Color ColorAccent      = Color.FromArgb(99, 102, 241);
        private static readonly Color ColorLinea       = Color.FromArgb(226, 232, 240);

        public FormLogin()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            btnIniciarSesion.Click    += BtnIniciarSesion_Click;
            btnMostrarClave.Click     += BtnMostrarClave_Click;
            lnkOlvideContraseña.LinkClicked += LnkOlvideContraseña_LinkClicked;

            txtContraseña.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    BtnIniciarSesion_Click(s, e);
                    e.Handled = true;
                }
            };

            // Gradient de la barra lateral izquierda
            pnlLeft.Paint += (s, e) =>
            {
                using (var brush = new LinearGradientBrush(
                    pnlLeft.ClientRectangle,
                    Color.FromArgb(26, 27, 75),
                    Color.FromArgb(10, 15, 35),
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, pnlLeft.ClientRectangle);
                }
            };

            // Círculos decorativos en pnlLeft
            pnlDeco1.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(Color.FromArgb(25, 99, 102, 241)))
                    e.Graphics.FillEllipse(brush, 0, 0, pnlDeco1.Width, pnlDeco1.Height);
            };

            pnlDeco2.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(Color.FromArgb(18, 99, 102, 241)))
                    e.Graphics.FillEllipse(brush, 0, 0, pnlDeco2.Width, pnlDeco2.Height);
            };

            // Efecto underline al enfocar campos
            txtUsuario.Enter += (s, e)    => pnlLineUsuario.BackColor = ColorAccent;
            txtUsuario.Leave += (s, e)    => pnlLineUsuario.BackColor = ColorLinea;
            txtContraseña.Enter += (s, e) => pnlLineContra.BackColor  = ColorAccent;
            txtContraseña.Leave += (s, e) => pnlLineContra.BackColor  = ColorLinea;
        }

        private void LnkOlvideContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var form = new FormRecuperarContraseña())
            {
                form.ShowDialog(this);
            }
        }

        private void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                string usuario   = txtUsuario.Text.Trim();
                string contrasena = txtContraseña.Text;

                if (EstaBloqueado(usuario, out TimeSpan tiempoRestante))
                {
                    MessageBox.Show(
                        $"Demasiados intentos fallidos. Intente nuevamente en {Math.Ceiling(tiempoRestante.TotalMinutes)} minuto(s).",
                        "Acceso temporalmente bloqueado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var usuarioValidado = UsuarioRepository.ValidarLogin(usuario, contrasena);

                if (usuarioValidado != null)
                {
                    LimpiarIntentos(usuario);
                    SesionActual.Usuario = usuarioValidado;
                    UsuarioRepository.ActualizarUltimoAcceso(usuarioValidado.UsuarioID);

                    var cajaAbierta = CajaRepository.ObtenerCajaAbierta();
                    this.Hide();

                    if (cajaAbierta == null)
                    {
                        var formApertura = new FormAperturaCaja();
                        if (formApertura.ShowDialog() == DialogResult.OK)
                        {
                            var formPrincipal = new FormPrincipal();
                            formPrincipal.FormClosed += (s, args) => this.Close();
                            formPrincipal.Show();
                        }
                        else
                        {
                            this.Show();
                        }
                    }
                    else
                    {
                        var formPrincipal = new FormPrincipal();
                        formPrincipal.FormClosed += (s, args) => this.Close();
                        formPrincipal.Show();
                    }
                }
                else
                {
                    RegistrarIntentoFallido(usuario);
                    MessageBox.Show(
                        "Usuario o contraseña incorrectos",
                        "Error de inicio de sesión",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtContraseña.Clear();
                    txtContraseña.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al iniciar sesión: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Ingresa tu usuario", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Ingresa tu contraseña", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Focus();
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

        private static bool EstaBloqueado(string usuario, out TimeSpan restante)
        {
            lock (IntentosLock)
            {
                restante = TimeSpan.Zero;
                if (!IntentosFallidos.TryGetValue(usuario, out var estado) || !estado.BloqueoHasta.HasValue)
                    return false;
                if (estado.BloqueoHasta.Value <= DateTime.Now)
                {
                    IntentosFallidos.Remove(usuario);
                    return false;
                }
                restante = estado.BloqueoHasta.Value - DateTime.Now;
                return true;
            }
        }

        private static void RegistrarIntentoFallido(string usuario)
        {
            lock (IntentosLock)
            {
                if (!IntentosFallidos.TryGetValue(usuario, out var estado))
                    estado = (0, null);
                estado.Intentos++;
                if (estado.Intentos >= MaxIntentos)
                {
                    estado.BloqueoHasta = DateTime.Now.AddMinutes(MinutosBloqueo);
                    estado.Intentos     = 0;
                }
                IntentosFallidos[usuario] = estado;
            }
        }

        private static void LimpiarIntentos(string usuario)
        {
            lock (IntentosLock)
            {
                if (IntentosFallidos.ContainsKey(usuario))
                    IntentosFallidos.Remove(usuario);
            }
        }
    }
}
