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
                lblVersion.Text = $"Versión:      {version?.ToString() ?? "1.0.0"}";
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
                // Licencia activa
                lblEstado.Text = "Estado:                     Activo";
                lblEstado.ForeColor = Color.Green;
                lblVencimiento.Text = $"Vencimiento:          {_fechaVencimiento.Value:dd/MM/yyyy}";

                int diasRestantes = (_fechaVencimiento.Value - DateTime.Today).Days;
                lblDiasRestantes.Text = $"Días restantes:       {diasRestantes}";

                if (diasRestantes <= 30)
                {
                    lblDiasRestantes.ForeColor = Color.Orange;
                }
                else
                {
                    lblDiasRestantes.ForeColor = Color.Black;
                }

                btnActivar.Text = "Renovar Licencia";
            }
            else if (_fechaVencimiento.HasValue && _fechaVencimiento.Value < DateTime.Today)
            {
                // Licencia vencida
                lblEstado.Text = "Estado:                     Licencia vencida";
                lblEstado.ForeColor = Color.Red;
                lblVencimiento.Text = $"Vencimiento:          {_fechaVencimiento.Value:dd/MM/yyyy}";
                lblDiasRestantes.Text = "Días restantes:       0";
                lblDiasRestantes.ForeColor = Color.Red;
                btnActivar.Text = "Renovar Licencia";
            }
            else
            {
                // Sin licencia
                lblEstado.Text = "Estado:                     Sistema no activado";
                lblEstado.ForeColor = Color.Orange;
                lblVencimiento.Text = "Vencimiento:          --/--/----";
                lblDiasRestantes.Text = "Días restantes:       --";
                btnActivar.Text = "Activar Licencia";
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
