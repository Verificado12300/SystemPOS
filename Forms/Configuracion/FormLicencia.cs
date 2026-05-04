using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using SistemaPOS.Data;

namespace SistemaPOS.Forms.Configuracion
{
    public partial class FormLicencia : Form
    {
        private bool _licenciaActiva = false;
        private DateTime? _fechaVencimiento = null;

        public FormLicencia()
        {
            InitializeComponent();
            if (DesignMode) return;
            ConfigurarEventos();
            CargarDatos();
        }

        private void ConfigurarEventos()
        {
            btnActivar.Click += BtnActivar_Click;
            txtCodigoLicencia.TextChanged += TxtCodigoLicencia_TextChanged;
        }

        private void CargarDatos()
        {
            try
            {
                // Información de versión
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                lblVersion.Text       = $"{version?.Major ?? 1}.{version?.Minor ?? 0}.{version?.Build ?? 0}";
                lblActualizacion.Text = $"Última actualización: {DateTime.Now:dd/MM/yyyy}";

                // Cargar datos de licencia
                string codigoLicencia = EmpresaRepository.ObtenerConfiguracion("CODIGO_LICENCIA", "");
                string estadoLicencia = EmpresaRepository.ObtenerConfiguracion("ESTADO_LICENCIA", "INACTIVA");
                string fechaVencStr = EmpresaRepository.ObtenerConfiguracion("FECHA_VENCIMIENTO_LICENCIA", "");

                txtCodigoLicencia.Text = codigoLicencia;

                if (estadoLicencia == "ACTIVA" && !string.IsNullOrEmpty(fechaVencStr))
                {
                    if (DateTime.TryParse(fechaVencStr, out DateTime fechaVenc))
                    {
                        _fechaVencimiento = fechaVenc;
                        _licenciaActiva = fechaVenc >= DateTime.Today;
                    }
                }

                ActualizarEstadoLicencia();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarEstadoLicencia()
        {
            if (_licenciaActiva && _fechaVencimiento.HasValue)
            {
                int diasRestantes = (_fechaVencimiento.Value - DateTime.Today).Days;

                // Badge: verde si quedan >30 días, naranja si está próxima a vencer
                bool proxima = diasRestantes <= 30;
                pnlEstadoBadge.BackColor    = proxima
                    ? Color.FromArgb(230, 126, 34)   // naranja → próxima a vencer
                    : Color.FromArgb(27, 153, 82);    // verde → activa OK
                lblEstado.Text              = proxima ? "ACTIVO  —  PRÓXIMO A VENCER" : "ACTIVO";
                lblIconShield.ForeColor     = pnlEstadoBadge.BackColor;

                lblVencimiento.Text         = _fechaVencimiento.Value.ToString("dd/MM/yyyy");
                lblVencimiento.ForeColor    = Color.FromArgb(45, 52, 54);
                lblDiasRestantes.Text       = diasRestantes.ToString();
                lblDiasRestantes.ForeColor  = proxima
                    ? Color.FromArgb(230, 126, 34)
                    : Color.FromArgb(27, 153, 82);

                btnActivar.Text             = "Renovar Licencia";
                btnActivar.BackColor        = Color.FromArgb(27, 153, 82);
            }
            else if (_fechaVencimiento.HasValue && _fechaVencimiento.Value < DateTime.Today)
            {
                // Vencida
                pnlEstadoBadge.BackColor   = Color.FromArgb(192, 57, 43);
                lblEstado.Text             = "LICENCIA VENCIDA";
                lblIconShield.ForeColor    = Color.FromArgb(192, 57, 43);

                lblVencimiento.Text        = _fechaVencimiento.Value.ToString("dd/MM/yyyy");
                lblVencimiento.ForeColor   = Color.FromArgb(192, 57, 43);
                lblDiasRestantes.Text      = "0";
                lblDiasRestantes.ForeColor = Color.FromArgb(192, 57, 43);

                btnActivar.Text            = "Renovar Licencia";
                btnActivar.BackColor       = Color.FromArgb(192, 57, 43);
            }
            else
            {
                // Sin licencia
                pnlEstadoBadge.BackColor   = Color.FromArgb(149, 165, 166);
                lblEstado.Text             = "SISTEMA NO ACTIVADO";
                lblIconShield.ForeColor    = Color.FromArgb(149, 165, 166);

                lblVencimiento.Text        = "--/--/----";
                lblVencimiento.ForeColor   = Color.FromArgb(45, 52, 54);
                lblDiasRestantes.Text      = "--";
                lblDiasRestantes.ForeColor = Color.FromArgb(45, 52, 54);

                btnActivar.Text            = "Activar Licencia";
                btnActivar.BackColor       = Color.FromArgb(52, 152, 219);
            }
        }

        private void TxtCodigoLicencia_TextChanged(object sender, EventArgs e)
        {
            // Formatear el código de licencia mientras se escribe (XXXX-XXXX-XXXX-XXXX)
            string texto = txtCodigoLicencia.Text.Replace("-", "").ToUpper();
            if (texto.Length > 16)
                texto = texto.Substring(0, 16);

            // Solo letras y números
            string limpio = "";
            foreach (char c in texto)
            {
                if (char.IsLetterOrDigit(c))
                    limpio += c;
            }

            if (limpio.Length > 0)
            {
                string formateado = "";
                for (int i = 0; i < limpio.Length; i++)
                {
                    if (i > 0 && i % 4 == 0)
                        formateado += "-";
                    formateado += limpio[i];
                }

                if (txtCodigoLicencia.Text != formateado)
                {
                    int cursorPos = txtCodigoLicencia.SelectionStart;
                    txtCodigoLicencia.Text = formateado;
                    txtCodigoLicencia.SelectionStart = Math.Min(cursorPos + 1, formateado.Length);
                }
            }
        }

        private void BtnActivar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoLicencia.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Ingrese el código de licencia", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoLicencia.Focus();
                return;
            }

            // Validar formato (XXXX-XXXX-XXXX-XXXX)
            if (codigo.Length != 19)
            {
                MessageBox.Show("El código de licencia debe tener el formato XXXX-XXXX-XXXX-XXXX", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoLicencia.Focus();
                return;
            }

            try
            {
                // Validar licencia (en producción, esto se conectaría a un servidor)
                // Por ahora, aceptamos cualquier código válido y damos 365 días
                bool licenciaValida = ValidarLicencia(codigo);

                if (licenciaValida)
                {
                    // Guardar licencia
                    DateTime nuevaFechaVencimiento = DateTime.Today.AddDays(365);

                    EmpresaRepository.GuardarConfiguracion("CODIGO_LICENCIA", codigo, "STRING", "Licencia", "Código de licencia");
                    EmpresaRepository.GuardarConfiguracion("ESTADO_LICENCIA", "ACTIVA", "STRING", "Licencia", "Estado de la licencia");
                    EmpresaRepository.GuardarConfiguracion("FECHA_VENCIMIENTO_LICENCIA", nuevaFechaVencimiento.ToString("yyyy-MM-dd"), "STRING", "Licencia", "Fecha de vencimiento");
                    EmpresaRepository.GuardarConfiguracion("FECHA_ACTIVACION", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "STRING", "Licencia", "Fecha de activación");

                    _licenciaActiva = true;
                    _fechaVencimiento = nuevaFechaVencimiento;

                    ActualizarEstadoLicencia();

                    MessageBox.Show($"Licencia activada exitosamente.\n\n" +
                        $"Válida hasta: {nuevaFechaVencimiento:dd/MM/yyyy}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El código de licencia ingresado no es válido.\n\n" +
                        "Por favor, verifique el código e intente nuevamente.\n" +
                        "Si el problema persiste, contacte al proveedor.",
                        "Error de activación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al activar licencia: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarLicencia(string codigo)
        {
            // En producción, aquí se conectaría a un servidor para validar
            // Por ahora, aceptamos códigos que cumplan el formato y tengan un checksum válido

            // Remover guiones
            string limpio = codigo.Replace("-", "");

            if (limpio.Length != 16)
                return false;

            // Validación simple: verificar que todos sean alfanuméricos
            foreach (char c in limpio)
            {
                if (!char.IsLetterOrDigit(c))
                    return false;
            }

            // Códigos de prueba (solo en compilaciones Debug)
#if DEBUG
            if (codigo == "TEST-1234-5678-ABCD" ||
                codigo == "DEMO-2024-FULL-VERS" ||
                limpio.StartsWith("ACTV"))
            {
                return true;
            }
#endif

            // Validación por checksum simple (último carácter)
            int suma = 0;
            for (int i = 0; i < 15; i++)
            {
                suma += limpio[i];
            }

            char checksumEsperado = (char)('A' + (suma % 26));
            return limpio[15] == checksumEsperado || char.IsDigit(limpio[15]);
        }
    }
}
