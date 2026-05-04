using System;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Services;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Principal
{
    public partial class FormRecuperarContraseña : Form
    {
        private int _paso = 1;
        private int _usuarioID;
        private string _tokenEnviado;
        private string _nombreUsuario;

        public FormRecuperarContraseña()
        {
            InitializeComponent();
            ConfigurarEventos();
            MostrarPaso(1);
        }

        private void ConfigurarEventos()
        {
            btnSiguiente.Click += BtnSiguiente_Click;
            btnCancelar.Click += (s, e) => this.Close();
            btnMostrarNueva.Click += (s, e) => TogglePasswordChar(txtNuevaClave, btnMostrarNueva);
            btnMostrarConfirmar.Click += (s, e) => TogglePasswordChar(txtConfirmarClave, btnMostrarConfirmar);

            txtUsuarioBuscar.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter) { BtnSiguiente_Click(s, e); e.Handled = true; }
            };
            txtCodigo.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter) { BtnSiguiente_Click(s, e); e.Handled = true; }
            };
        }

        private void MostrarPaso(int paso)
        {
            _paso = paso;
            pnlPaso1.Visible = (paso == 1);
            pnlPaso2.Visible = (paso == 2);
            pnlPaso3.Visible = (paso == 3);

            switch (paso)
            {
                case 1:
                    lblTituloPaso.Text = "Recuperar Contraseña";
                    lblDescPaso.Text = "Ingresa el correo registrado en tu cuenta.";
                    btnSiguiente.Text = "Enviar Código";
                    txtUsuarioBuscar.Focus();
                    break;
                case 2:
                    lblTituloPaso.Text = "Verificar Código";
                    lblDescPaso.Text = "Ingresa el código de 6 dígitos que enviamos a tu correo.";
                    btnSiguiente.Text = "Verificar";
                    txtCodigo.Focus();
                    break;
                case 3:
                    lblTituloPaso.Text = "Nueva Contraseña";
                    lblDescPaso.Text = "Ingresa y confirma tu nueva contraseña.";
                    btnSiguiente.Text = "Cambiar Contraseña";
                    txtNuevaClave.Focus();
                    break;
            }

            ActualizarIndicadorPasos(paso);
        }

        private void ActualizarIndicadorPasos(int paso)
        {
            var verde   = System.Drawing.Color.FromArgb(16, 185, 129);
            var indigo  = System.Drawing.Color.FromArgb(99, 102, 241);
            var gris    = System.Drawing.Color.FromArgb(51, 65, 85);
            var blanco  = System.Drawing.Color.White;
            var grisText = System.Drawing.Color.FromArgb(100, 116, 139);

            // Paso 1
            lblStep1.BackColor = paso == 1 ? indigo : verde;
            lblStep1.ForeColor = blanco;

            // Línea 1-2
            pnlLine12.BackColor = paso >= 2 ? verde : gris;

            // Paso 2
            lblStep2.BackColor = paso == 2 ? indigo : (paso > 2 ? verde : gris);
            lblStep2.ForeColor = paso >= 2 ? blanco : grisText;

            // Línea 2-3
            pnlLine23.BackColor = paso >= 3 ? verde : gris;

            // Paso 3
            lblStep3.BackColor = paso == 3 ? indigo : gris;
            lblStep3.ForeColor = paso == 3 ? blanco : grisText;
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            switch (_paso)
            {
                case 1: EjecutarPaso1(); break;
                case 2: EjecutarPaso2(); break;
                case 3: EjecutarPaso3(); break;
            }
        }

        private void EjecutarPaso1()
        {
            string correo = txtUsuarioBuscar.Text.Trim();
            if (string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("Ingresa tu correo electrónico.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuarioBuscar.Focus();
                return;
            }

            if (!EmailService.VerificarConfiguracion())
            {
                MessageBox.Show(
                    "El sistema de correo no está configurado.\n\n" +
                    "Un administrador debe configurar el servidor SMTP en:\n" +
                    "Configuración > General > Correo electrónico.",
                    "Sin configuración de correo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var (tieneEmail, emailMascarado, usuarioID, nombreCompleto) =
                TokenRecuperacionRepository.BuscarPorCorreo(correo);

            // Respuesta genérica para no revelar si el correo existe o no
            if (usuarioID == 0 || !tieneEmail)
            {
                MessageBox.Show(
                    "Si ese correo está registrado en el sistema, recibirás un código en unos momentos.",
                    "Código enviado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _usuarioID = usuarioID;
            _nombreUsuario = nombreCompleto;

            try
            {
                btnSiguiente.Enabled = false;
                btnSiguiente.Text = "Enviando...";

                string token = TokenRecuperacionRepository.GenerarToken(_usuarioID);
                string emailReal = TokenRecuperacionRepository.ObtenerEmailPorUsuarioID(_usuarioID);
                EmailService.EnviarCodigoRecuperacion(emailReal, token, _nombreUsuario);
                _tokenEnviado = token;

                lblEmailMascarado.Text = emailMascarado;
                MostrarPaso(2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al enviar el correo: {ex.Message}\n\n" +
                    "Verifica la configuración SMTP en Configuración > General.",
                    "Error al enviar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSiguiente.Enabled = true;
                if (_paso == 1) btnSiguiente.Text = "Enviar Código";
            }
        }

        private void EjecutarPaso2()
        {
            string codigo = txtCodigo.Text.Trim();
            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Ingresa el código recibido por correo.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return;
            }

            var (valido, uid) = TokenRecuperacionRepository.ValidarToken(codigo);

            if (!valido || uid != _usuarioID)
            {
                MessageBox.Show("Código incorrecto o expirado.\nRevisa tu correo o solicita un nuevo código.",
                    "Código inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Clear();
                txtCodigo.Focus();
                return;
            }

            _tokenEnviado = codigo;
            MostrarPaso(3);
        }

        private void EjecutarPaso3()
        {
            if (string.IsNullOrWhiteSpace(txtNuevaClave.Text))
            {
                MessageBox.Show("Ingresa la nueva contraseña.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNuevaClave.Focus();
                return;
            }

            if (txtNuevaClave.Text.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNuevaClave.Focus();
                return;
            }

            if (txtNuevaClave.Text != txtConfirmarClave.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarClave.Focus();
                return;
            }

            try
            {
                string hash = PasswordHelper.HashPassword(txtNuevaClave.Text);
                UsuarioRepository.ActualizarContraseña(_usuarioID, hash);
                TokenRecuperacionRepository.MarcarUsado(_tokenEnviado);

                MessageBox.Show(
                    "Contraseña cambiada exitosamente.\nYa puedes iniciar sesión con tu nueva contraseña.",
                    "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar la contraseña: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void TogglePasswordChar(System.Windows.Forms.TextBox txt, System.Windows.Forms.Button btn)
        {
            if (txt.PasswordChar == '*')
            {
                txt.PasswordChar = '\0';
                btn.Text = "🙈";
            }
            else
            {
                txt.PasswordChar = '*';
                btn.Text = "👁";
            }
        }
    }
}
