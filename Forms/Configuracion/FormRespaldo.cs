using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Configuracion
{
    public partial class FormRespaldo : Form
    {
        private string _rutaRespaldos;
        private string _rutaBaseDatos;

        public FormRespaldo()
        {
            InitializeComponent();
            if (DesignMode) return;
            ConfigurarEventos();
            ConfigurarControles();
            CargarDatos();
            CargarHistorialRespaldos();
        }

        private void ConfigurarEventos()
        {
            btnGuardar.Click       += BtnGuardar_Click;
            btnCancelar.Click      += BtnCancelar_Click;
            btnCrearRespaldo.Click += BtnCrearRespaldo_Click;
            btnRestaurarDatos.Click += BtnRestaurarDatos_Click;
            btnUbicacionRespaldo.Click += BtnUbicacionRespaldo_Click;
            btnArchivoRespaldo.Click   += BtnArchivoRespaldo_Click;
            btnAbrirCarpeta.Click      += BtnAbrirCarpeta_Click;
            dgvHistorialRespaldos.CellClick += DgvHistorialRespaldos_CellClick;
            chkActivarRespaldoAuto.CheckedChanged += ChkActivarRespaldoAuto_CheckedChanged;
            rbDiario.CheckedChanged  += RbFrecuencia_CheckedChanged;
            rbSemanal.CheckedChanged += RbFrecuencia_CheckedChanged;
            rbMensual.CheckedChanged += RbFrecuencia_CheckedChanged;
        }

        private void ConfigurarControles()
        {
            chkIncluirDatosVentas.Checked     = true;
            chkIncluirDatosInventario.Checked = true;
            chkIncluirConfiguraciones.Checked = true;
            rbDiario.Checked          = true;
            cmbDiaEnvio.SelectedIndex = 0;
            txtDiasRespaldo.Text      = "7";
            dtpHora.Value             = DateTime.Today.AddHours(2);

            _rutaBaseDatos = DatabaseConnection.GetDatabasePath();
            _rutaRespaldos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Respaldos");

            if (!Directory.Exists(_rutaRespaldos))
                Directory.CreateDirectory(_rutaRespaldos);

            txtUbicacion.Text     = _rutaRespaldos;
            txtNombreArchivo.Text = $"respaldo_{DateTime.Now:yyyyMMdd_HHmmss}.db";

            ActualizarEstadoRespaldoAuto();
            ActualizarEstadoDia();
            MostrarUltimoAutoRespaldo();
        }

        private void MostrarUltimoAutoRespaldo()
        {
            var fecha = AutoBackupService.ObtenerFechaUltimoRespaldo();
            lblResumen.Text = fecha.HasValue
                ? $"Último auto-respaldo: {fecha.Value:dd/MM/yyyy HH:mm}"
                : "Último auto-respaldo: (nunca ejecutado)";
        }

        private void CargarDatos()
        {
            try
            {
                chkActivarRespaldoAuto.Checked =
                    EmpresaRepository.ObtenerConfiguracion("RESPALDO_AUTOMATICO", "false") == "true";

                string frecuencia = EmpresaRepository.ObtenerConfiguracion("FRECUENCIA_RESPALDO", "DIARIO");
                rbDiario.Checked  = frecuencia == "DIARIO";
                rbSemanal.Checked = frecuencia == "SEMANAL";
                rbMensual.Checked = frecuencia == "MENSUAL";

                string dia = EmpresaRepository.ObtenerConfiguracion("DIA_RESPALDO", "0");
                if (int.TryParse(dia, out int diaIndex) && diaIndex >= 0 && diaIndex < cmbDiaEnvio.Items.Count)
                    cmbDiaEnvio.SelectedIndex = diaIndex;

                string hora = EmpresaRepository.ObtenerConfiguracion("HORA_RESPALDO", "02:00");
                if (TimeSpan.TryParse(hora, out TimeSpan horaRespaldo))
                    dtpHora.Value = DateTime.Today.Add(horaRespaldo);

                txtDiasRespaldo.Text = EmpresaRepository.ObtenerConfiguracion("CANTIDAD_RESPALDOS", "7");

                string rutaGuardada = EmpresaRepository.ObtenerConfiguracion("RUTA_RESPALDO", "");
                if (!string.IsNullOrEmpty(rutaGuardada) && Directory.Exists(rutaGuardada))
                {
                    _rutaRespaldos    = rutaGuardada;
                    txtUbicacion.Text = rutaGuardada;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar configuración: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarHistorialRespaldos()
        {
            dgvHistorialRespaldos.Rows.Clear();
            long totalBytes   = 0;
            string ultimaFecha = "—";

            try
            {
                if (!Directory.Exists(_rutaRespaldos))
                {
                    ActualizarStats(0, 0, "—");
                    return;
                }

                var archivos = Directory.GetFiles(_rutaRespaldos, "*.db");
                Array.Sort(archivos);
                Array.Reverse(archivos);

                foreach (var archivo in archivos)
                {
                    var info  = new FileInfo(archivo);
                    int index = dgvHistorialRespaldos.Rows.Add();
                    var row   = dgvHistorialRespaldos.Rows[index];

                    row.Cells["colFechayHora"].Value = info.CreationTime.ToString("dd/MM/yyyy HH:mm:ss");
                    row.Cells["colTamano"].Value     = FormatearTamaño(info.Length);
                    row.Cells["colUbicacion"].Value  = info.FullName;
                    row.Tag = info.FullName;

                    totalBytes += info.Length;
                }

                if (archivos.Length > 0)
                {
                    var newest = new FileInfo(archivos[0]);
                    ultimaFecha = newest.CreationTime.ToString("dd/MM/yy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar historial: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ActualizarStats(dgvHistorialRespaldos.Rows.Count, totalBytes, ultimaFecha);
        }

        private void ActualizarStats(int total, long bytes, string ultimaFecha)
        {
            if (total > 0)
                lblMostrar.Text = $"{total} archivo{(total != 1 ? "s" : "")}  •  {FormatearTamaño(bytes)}  •  Último: {ultimaFecha}";
            else
                lblMostrar.Text = "Sin respaldos guardados";
        }

        private string FormatearTamaño(long bytes)
        {
            string[] sufijos = { "B", "KB", "MB", "GB" };
            int i = 0;
            double tamaño = bytes;
            while (tamaño >= 1024 && i < sufijos.Length - 1) { tamaño /= 1024; i++; }
            return $"{tamaño:F1} {sufijos[i]}";
        }

        private void ActualizarEstadoRespaldoAuto()
        {
            bool activo = chkActivarRespaldoAuto.Checked;
            rbDiario.Enabled         = activo;
            rbSemanal.Enabled        = activo;
            rbMensual.Enabled        = activo;
            cmbDiaEnvio.Enabled      = activo && (rbSemanal.Checked || rbMensual.Checked);
            dtpHora.Enabled          = activo;
            txtDiasRespaldo.Enabled  = activo;
        }

        private void ActualizarEstadoDia()
        {
            if (rbDiario.Checked)
            {
                lblDiaEnvio.Visible  = false;
                cmbDiaEnvio.Visible  = false;
            }
            else
            {
                lblDiaEnvio.Visible  = true;
                cmbDiaEnvio.Visible  = true;
                lblDiaEnvio.Text     = "Día";
            }
        }

        private void ChkActivarRespaldoAuto_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarEstadoRespaldoAuto();
        }

        private void RbFrecuencia_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarEstadoDia();
            if (chkActivarRespaldoAuto.Checked)
                cmbDiaEnvio.Enabled = rbSemanal.Checked || rbMensual.Checked;
        }

        private void BtnUbicacionRespaldo_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description  = "Seleccione la carpeta de respaldos";
                dlg.SelectedPath = txtUbicacion.Text;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtUbicacion.Text = dlg.SelectedPath;
                    _rutaRespaldos    = dlg.SelectedPath;
                    CargarHistorialRespaldos();
                }
            }
        }

        private void BtnArchivoRespaldo_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title            = "Seleccionar archivo de respaldo";
                dlg.Filter           = "Archivos de base de datos|*.db|Todos los archivos|*.*";
                dlg.InitialDirectory = _rutaRespaldos;
                if (dlg.ShowDialog() == DialogResult.OK)
                    txtArchivoRespaldo.Text = dlg.FileName;
            }
        }

        private void BtnAbrirCarpeta_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(_rutaRespaldos))
                System.Diagnostics.Process.Start("explorer.exe", _rutaRespaldos);
        }

        private void DgvHistorialRespaldos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvHistorialRespaldos.Columns[e.ColumnIndex].Name == "colRestaurar")
            {
                string ruta = dgvHistorialRespaldos.Rows[e.RowIndex].Tag?.ToString();
                if (!string.IsNullOrEmpty(ruta))
                {
                    txtArchivoRespaldo.Text = ruta;
                    BtnRestaurarDatos_Click(sender, e);
                }
            }
        }

        private void BtnCrearRespaldo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUbicacion.Text))
            {
                MessageBox.Show("Seleccione una ubicación para el respaldo.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNombreArchivo.Text))
            {
                MessageBox.Show("Ingrese un nombre para el archivo de respaldo.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string nombre = txtNombreArchivo.Text.Trim();
                if (!nombre.EndsWith(".db")) nombre += ".db";

                string destino = Path.Combine(txtUbicacion.Text, nombre);

                if (File.Exists(destino))
                {
                    if (MessageBox.Show("El archivo ya existe. ¿Desea reemplazarlo?", "Confirmar",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;
                }

                if (!Directory.Exists(txtUbicacion.Text))
                    Directory.CreateDirectory(txtUbicacion.Text);

                if (!File.Exists(_rutaBaseDatos))
                    throw new FileNotFoundException($"No se encontró la base de datos en: {_rutaBaseDatos}");

                RespaldarBaseDatos(_rutaBaseDatos, destino);

                MessageBox.Show($"Respaldo creado exitosamente:\n{destino}", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNombreArchivo.Text = $"respaldo_{DateTime.Now:yyyyMMdd_HHmmss}.db";
                CargarHistorialRespaldos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear respaldo: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRestaurarDatos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtArchivoRespaldo.Text))
            {
                MessageBox.Show("Seleccione un archivo de respaldo.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!File.Exists(txtArchivoRespaldo.Text))
            {
                MessageBox.Show("El archivo de respaldo no existe.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show(
                "ADVERTENCIA: Esta acción reemplazará todos los datos actuales con el respaldo seleccionado.\n\n" +
                "Se creará un respaldo de seguridad antes de continuar.\n\n" +
                "¿Está seguro de que desea restaurar?",
                "Confirmar restauración",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                if (!File.Exists(_rutaBaseDatos))
                    throw new FileNotFoundException($"No se encontró la base de datos en: {_rutaBaseDatos}");

                string preRestore = Path.Combine(_rutaRespaldos,
                    $"pre_restauracion_{DateTime.Now:yyyyMMdd_HHmmss}.db");
                RespaldarBaseDatos(_rutaBaseDatos, preRestore);
                RestaurarBaseDatos(txtArchivoRespaldo.Text, _rutaBaseDatos);

                MessageBox.Show(
                    "Base de datos restaurada exitosamente.\n\n" +
                    "Se creó un respaldo de los datos anteriores.\n\n" +
                    "Por favor reinicie la aplicación para aplicar los cambios.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarHistorialRespaldos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al restaurar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                EmpresaRepository.GuardarConfiguracion("RESPALDO_AUTOMATICO",
                    chkActivarRespaldoAuto.Checked ? "true" : "false",
                    "BOOLEAN", "Respaldo", "Activar respaldo automático");

                string frecuencia = rbSemanal.Checked ? "SEMANAL" : rbMensual.Checked ? "MENSUAL" : "DIARIO";
                EmpresaRepository.GuardarConfiguracion("FRECUENCIA_RESPALDO", frecuencia,
                    "STRING", "Respaldo", "Frecuencia de respaldo");
                EmpresaRepository.GuardarConfiguracion("DIA_RESPALDO",
                    cmbDiaEnvio.SelectedIndex.ToString(), "INTEGER", "Respaldo", "Día de respaldo");
                EmpresaRepository.GuardarConfiguracion("HORA_RESPALDO",
                    dtpHora.Value.ToString("HH:mm"), "STRING", "Respaldo", "Hora de respaldo");
                EmpresaRepository.GuardarConfiguracion("CANTIDAD_RESPALDOS",
                    txtDiasRespaldo.Text.Trim(), "INTEGER", "Respaldo", "Cantidad de respaldos a conservar");
                EmpresaRepository.GuardarConfiguracion("RUTA_RESPALDO",
                    txtUbicacion.Text.Trim(), "STRING", "Respaldo", "Ruta de respaldos");

                MessageBox.Show("Configuración de respaldo guardada exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar configuración: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea descartar los cambios realizados?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                CargarDatos();
        }

        private static string BuildConnectionString(string path) =>
            $"Data Source={path};Version=3;BusyTimeout=5000;";

        private static void RespaldarBaseDatos(string origen, string destino)
        {
            if (File.Exists(destino)) File.Delete(destino);
            using (var src = new SQLiteConnection(BuildConnectionString(origen)))
            using (var dst = new SQLiteConnection(BuildConnectionString(destino)))
            {
                src.Open(); dst.Open();
                src.BackupDatabase(dst, "main", "main", -1, null, 0);
            }
        }

        private static void RestaurarBaseDatos(string respaldo, string destino)
        {
            using (var src = new SQLiteConnection(BuildConnectionString(respaldo)))
            using (var dst = new SQLiteConnection(BuildConnectionString(destino)))
            {
                src.Open(); dst.Open();
                src.BackupDatabase(dst, "main", "main", -1, null, 0);
            }
        }
    }
}
