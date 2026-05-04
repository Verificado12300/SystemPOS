using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Configuracion
{
    public partial class FormGeneral : Form
    {
        public FormGeneral()
        {
            InitializeComponent();
            ConfigurarEventos();
            ConfigurarControles();
            CargarDatos();
        }

        private void ConfigurarEventos()
        {
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            btnExaminarTemp.Click += BtnExaminarTemp_Click;
            btnLimpiarSistema.Click += BtnLimpiarSistema_Click;
        }

        private void ConfigurarControles()
        {
            // Configurar combo de zonas horarias
            cmbZonaHoraria.Items.Clear();
            cmbZonaHoraria.Items.Add("UTC-05:00 (Lima)");
            cmbZonaHoraria.Items.Add("UTC-06:00 (México)");
            cmbZonaHoraria.Items.Add("UTC-03:00 (Buenos Aires)");
            cmbZonaHoraria.Items.Add("UTC-04:00 (Santiago)");
            cmbZonaHoraria.Items.Add("UTC+01:00 (Madrid)");

            // Configurar valores por defecto
            cmbDiaEnvio.SelectedIndex = 0; // dd/MM/yyyy
            comboBox1.SelectedIndex = 0; // 24 horas
            cmbZonaHoraria.SelectedIndex = 0; // Lima
            cmbTamañoFuente.SelectedIndex = 1; // Normal

            // Configurar inactividad
            numInactividad.Minimum = 0;
            numInactividad.Maximum = 120;
            numInactividad.Value = 15;

            // Información del sistema (solo lectura)
            txtUbicacion.ReadOnly = true;
            txtNombreArchivo.ReadOnly = true;

            // Mantenimiento: solo visible para administradores
            bool esAdmin = SesionActual.Usuario?.RolID == 1;
            pnlMantenimiento.Visible = esAdmin;
        }

        private void CargarDatos()
        {
            try
            {
                // Información del sistema
                txtUbicacion.Text = "SystemPOS";
                txtNombreArchivo.Text = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0";

                // Ubicación de la base de datos
                lblUbicacionBaseDatos.Text = DatabaseConnection.GetDatabasePath();

                // Cargar configuraciones guardadas
                string formatoFecha = EmpresaRepository.ObtenerConfiguracion("FORMATO_FECHA", "dd/MM/yyyy");
                for (int i = 0; i < cmbDiaEnvio.Items.Count; i++)
                {
                    if (cmbDiaEnvio.Items[i].ToString() == formatoFecha)
                    {
                        cmbDiaEnvio.SelectedIndex = i;
                        break;
                    }
                }

                string formatoHora = EmpresaRepository.ObtenerConfiguracion("FORMATO_HORA", "24 horas");
                comboBox1.SelectedIndex = formatoHora == "12 horas" ? 1 : 0;

                string separador = EmpresaRepository.ObtenerConfiguracion("SEPARADOR_DECIMAL", "Punto");
                rbPunto.Checked = separador == "Punto";
                rbComa.Checked = separador == "Coma";

                string zonaHoraria = EmpresaRepository.ObtenerConfiguracion("ZONA_HORARIA", "UTC-05:00 (Lima)");
                for (int i = 0; i < cmbZonaHoraria.Items.Count; i++)
                {
                    if (cmbZonaHoraria.Items[i].ToString() == zonaHoraria)
                    {
                        cmbZonaHoraria.SelectedIndex = i;
                        break;
                    }
                }

                // Opciones de interfaz
                string tamañoFuente = EmpresaRepository.ObtenerConfiguracion("TAMAÑO_FUENTE", "Normal (Recomendado)");
                for (int i = 0; i < cmbTamañoFuente.Items.Count; i++)
                {
                    if (cmbTamañoFuente.Items[i].ToString() == tamañoFuente)
                    {
                        cmbTamañoFuente.SelectedIndex = i;
                        break;
                    }
                }

                chkMostrarNotificacionPantalla.Checked = EmpresaRepository.ObtenerConfiguracion("MOSTRAR_NOTIFICACIONES", "true") == "true";
                chkSonidosSistema.Checked = EmpresaRepository.ObtenerConfiguracion("SONIDOS_SISTEMA", "true") == "true";
                chkIniciarWindows.Checked = EmpresaRepository.ObtenerConfiguracion("INICIAR_WINDOWS", "false") == "true";

                // Seguridad
                string tiempoInactividad = EmpresaRepository.ObtenerConfiguracion("TIEMPO_INACTIVIDAD", "15");
                if (!decimal.TryParse(tiempoInactividad, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal minutos)
                    && !decimal.TryParse(tiempoInactividad, NumberStyles.Number, CultureInfo.CurrentCulture, out minutos))
                {
                    minutos = 15m;
                }

                if (minutos < numInactividad.Minimum) minutos = numInactividad.Minimum;
                if (minutos > numInactividad.Maximum) minutos = numInactividad.Maximum;
                numInactividad.Value = minutos;
                chkSolicitarContraseña.Checked = EmpresaRepository.ObtenerConfiguracion("SOLICITAR_CONTRASEÑA", "true") == "true";
                chkCerrarSesionMinimizar.Checked = EmpresaRepository.ObtenerConfiguracion("CERRAR_SESION_MINIMIZAR", "false") == "true";
                chkRegistrarAcciones.Checked = EmpresaRepository.ObtenerConfiguracion("REGISTRAR_ACCIONES", "true") == "true";

                // Otras opciones
                chkConfirmarEliminarRegistros.Checked = EmpresaRepository.ObtenerConfiguracion("CONFIRMAR_ELIMINAR", "true") == "true";
                chkMostrarMensajesAyuda.Checked = EmpresaRepository.ObtenerConfiguracion("MOSTRAR_AYUDA", "true") == "true";
                chkModoDesarrollo.Checked = EmpresaRepository.ObtenerConfiguracion("MODO_DESARROLLO", "false") == "true";
                txtDirectorioTemp.Text = EmpresaRepository.ObtenerConfiguracion("DIRECTORIO_TEMP", Path.GetTempPath());

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar configuración: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Formato y regionalización
                EmpresaRepository.GuardarConfiguracion("FORMATO_FECHA", cmbDiaEnvio.SelectedItem?.ToString() ?? "dd/MM/yyyy", "STRING", "Formato", "Formato de fecha");
                EmpresaRepository.GuardarConfiguracion("FORMATO_HORA", comboBox1.SelectedItem?.ToString() ?? "24 horas", "STRING", "Formato", "Formato de hora");
                EmpresaRepository.GuardarConfiguracion("SEPARADOR_DECIMAL", rbPunto.Checked ? "Punto" : "Coma", "STRING", "Formato", "Separador decimal");
                EmpresaRepository.GuardarConfiguracion("ZONA_HORARIA", cmbZonaHoraria.SelectedItem?.ToString() ?? "UTC-05:00 (Lima)", "STRING", "Formato", "Zona horaria");

                // Opciones de interfaz
                EmpresaRepository.GuardarConfiguracion("TAMAÑO_FUENTE", cmbTamañoFuente.SelectedItem?.ToString() ?? "Normal (Recomendado)", "STRING", "Interfaz", "Tamaño de fuente");
                EmpresaRepository.GuardarConfiguracion("MOSTRAR_NOTIFICACIONES", chkMostrarNotificacionPantalla.Checked ? "true" : "false", "BOOLEAN", "Interfaz", "Mostrar notificaciones");
                EmpresaRepository.GuardarConfiguracion("SONIDOS_SISTEMA", chkSonidosSistema.Checked ? "true" : "false", "BOOLEAN", "Interfaz", "Sonidos del sistema");
                EmpresaRepository.GuardarConfiguracion("INICIAR_WINDOWS", chkIniciarWindows.Checked ? "true" : "false", "BOOLEAN", "Interfaz", "Iniciar con Windows");

                // Seguridad
                EmpresaRepository.GuardarConfiguracion("TIEMPO_INACTIVIDAD", numInactividad.Value.ToString(), "INTEGER", "Seguridad", "Tiempo de inactividad en minutos");
                EmpresaRepository.GuardarConfiguracion("SOLICITAR_CONTRASEÑA", chkSolicitarContraseña.Checked ? "true" : "false", "BOOLEAN", "Seguridad", "Solicitar contraseña al desbloquear");
                EmpresaRepository.GuardarConfiguracion("CERRAR_SESION_MINIMIZAR", chkCerrarSesionMinimizar.Checked ? "true" : "false", "BOOLEAN", "Seguridad", "Cerrar sesión al minimizar");
                EmpresaRepository.GuardarConfiguracion("REGISTRAR_ACCIONES", chkRegistrarAcciones.Checked ? "true" : "false", "BOOLEAN", "Seguridad", "Registrar acciones de usuarios");

                // Otras opciones
                EmpresaRepository.GuardarConfiguracion("CONFIRMAR_ELIMINAR", chkConfirmarEliminarRegistros.Checked ? "true" : "false", "BOOLEAN", "Sistema", "Confirmar antes de eliminar");
                EmpresaRepository.GuardarConfiguracion("MOSTRAR_AYUDA", chkMostrarMensajesAyuda.Checked ? "true" : "false", "BOOLEAN", "Sistema", "Mostrar mensajes de ayuda");
                EmpresaRepository.GuardarConfiguracion("MODO_DESARROLLO", chkModoDesarrollo.Checked ? "true" : "false", "BOOLEAN", "Sistema", "Modo de desarrollo");
                EmpresaRepository.GuardarConfiguracion("DIRECTORIO_TEMP", txtDirectorioTemp.Text.Trim(), "STRING", "Sistema", "Directorio temporal");

                MessageBox.Show("Configuración guardada exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Desea descartar los cambios realizados?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CargarDatos();
            }
        }

        private void BtnExaminarTemp_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Seleccione el directorio temporal";
                folderDialog.SelectedPath = txtDirectorioTemp.Text;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDirectorioTemp.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void BtnLimpiarSistema_Click(object sender, EventArgs e)
        {
            if (SesionActual.Usuario?.RolID != 1)
            {
                MessageBox.Show("Solo el Administrador puede acceder a Limpiar Sistema.",
                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var f = new FormLimpiarSistema())
                f.ShowDialog(this);
        }
    }
}
