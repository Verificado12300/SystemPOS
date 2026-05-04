using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SistemaPOS.Forms.Principal
{
    public partial class FormActualizacion : Form
    {
        private readonly string _versionNueva;
        private readonly string _urlDescarga;
        private WebClient _wc;

        public FormActualizacion(string versionNueva, string urlDescarga)
        {
            InitializeComponent();
            _versionNueva = versionNueva;
            _urlDescarga  = urlDescarga;

            btnAhora.Click += BtnAhora_Click;
            btnLuego.Click += BtnLuego_Click;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblVersionNueva.Text = $"Nueva versión disponible: {_versionNueva}";
        }

        private void BtnAhora_Click(object sender, EventArgs e)
        {
            btnAhora.Enabled    = false;
            btnLuego.Enabled    = false;
            pnlProgreso.Visible = true;
            lblEstadoDescarga.Text = "Descargando...";
            progressBar.Value      = 0;

            string tempPath = Path.Combine(Path.GetTempPath(), "SystemPOS_update.exe");

            _wc = new WebClient();
            _wc.Headers.Add("User-Agent", "SystemPOS-Updater/1.0");

            _wc.DownloadProgressChanged += (s, ev) =>
            {
                if (progressBar.IsDisposed) return;
                progressBar.Value      = ev.ProgressPercentage;
                lblEstadoDescarga.Text = $"Descargando... {ev.ProgressPercentage}%";
            };

            _wc.DownloadFileCompleted += (s, ev) =>
            {
                if (ev.Cancelled) return;

                if (ev.Error != null)
                {
                    if (!IsDisposed)
                    {
                        btnAhora.Enabled    = true;
                        btnLuego.Enabled    = true;
                        pnlProgreso.Visible = false;
                        MessageBox.Show(
                            $"Error al descargar la actualización:\n{ev.Error.Message}",
                            "Error de descarga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }

                lblEstadoDescarga.Text = "Instalando...";
                Application.DoEvents();
                AplicarActualizacion(tempPath);
            };

            _wc.DownloadFileAsync(new Uri(_urlDescarga), tempPath);
        }

        private void AplicarActualizacion(string archivoDescargado)
        {
            string exeActual = Application.ExecutablePath;
            string batPath   = Path.Combine(Path.GetTempPath(), "systempos_update.bat");

            string bat =
                "@echo off\r\n" +
                "timeout /t 3 /nobreak > NUL\r\n" +
                $"copy /Y \"{archivoDescargado}\" \"{exeActual}\"\r\n" +
                $"start \"\" \"{exeActual}\"\r\n" +
                "del \"%~f0\"\r\n";

            File.WriteAllText(batPath, bat);

            Process.Start(new ProcessStartInfo("cmd.exe", $"/c \"{batPath}\"")
            {
                WindowStyle    = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false
            });

            Environment.Exit(0);
        }

        private void BtnLuego_Click(object sender, EventArgs e)
        {
            _wc?.CancelAsync();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _wc?.CancelAsync();
            base.OnFormClosing(e);
        }
    }
}
