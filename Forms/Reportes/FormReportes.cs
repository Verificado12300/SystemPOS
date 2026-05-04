using System;
using System.ComponentModel;
using System.Windows.Forms;
using SistemaPOS.Data;

namespace SistemaPOS.Forms.Reportes
{
    public partial class FormReportes : Form
    {
        public FormReportes()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            ConfigurarEventos();
            ConfigurarControles();
            CargarConfiguracion();
        }

        private void ConfigurarEventos()
        {
            chkGenerarReportes.CheckedChanged += ChkGenerarReportes_CheckedChanged;
            chkEnviarporCorreo.CheckedChanged += ChkEnviarporCorreo_CheckedChanged;
            rbDiario.CheckedChanged += FrecuenciaChanged;
            rbSemanal.CheckedChanged += FrecuenciaChanged;
            rbMensual.CheckedChanged += FrecuenciaChanged;
            btnGuardar.Click += BtnGuardar_Click;
        }

        private void ConfigurarControles()
        {
            // Valores por defecto
            rbDiario.Checked = true;
            cmbDiaEnvio.SelectedIndex = 0;
            dtpHora.Value = DateTime.Today.AddHours(8); // 8:00 AM
            rbPDF.Checked = true;
            numMontoVentas.Maximum = 99999;
            numMontoVentas.Value = 500;

            // Estado inicial de paneles
            ActualizarEstadoReportes();
            ActualizarEstadoCorreo();
        }

        private void CargarConfiguracion()
        {
            try
            {
                var config = ConfiguracionRepository.ObtenerConfiguracion();
                if (config == null) return;

                // Reportes automáticos
                chkGenerarReportes.Checked = config.GenerarReportesAuto;

                if (config.FrecuenciaReportes == "DIARIO")
                    rbDiario.Checked = true;
                else if (config.FrecuenciaReportes == "SEMANAL")
                    rbSemanal.Checked = true;
                else if (config.FrecuenciaReportes == "MENSUAL")
                    rbMensual.Checked = true;

                if (config.DiaEnvioReportes >= 0 && config.DiaEnvioReportes < cmbDiaEnvio.Items.Count)
                    cmbDiaEnvio.SelectedIndex = config.DiaEnvioReportes;

                if (config.HoraEnvioReportes.HasValue)
                    dtpHora.Value = DateTime.Today.Add(config.HoraEnvioReportes.Value);

                // Reportes a generar
                chkMostrarLogo.Checked = config.ReporteVentas;
                chkMostrarNombre.Checked = config.ReporteInventario;
                chkMostrarRUC.Checked = config.ReporteStockBajo;
                chkMostrarDireccion.Checked = config.ReporteCaja;
                chkMostrarTelefono.Checked = config.ReporteCompras;
                chkMostrarEmail.Checked = config.ReporteCuentasCobrar;

                // Notificaciones por correo
                chkEnviarporCorreo.Checked = config.EnviarPorCorreo;
                txtDestinatarios.Text = config.DestinatariosCorreo ?? "";
                txtAsunto.Text = config.AsuntoCorreo ?? "Reporte Automático - SystemPOS";

                if (config.FormatoReporte == "PDF")
                    rbPDF.Checked = true;
                else if (config.FormatoReporte == "EXCEL")
                    rbExcel.Checked = true;
                else if (config.FormatoReporte == "AMBOS")
                    chkAmbosFormatos.Checked = true;

                // Alertas
                chkAlertaStockBajo.Checked = config.AlertaStockBajo;
                chkNotificarVentasMayores.Checked = config.NotificarVentasMayores;
                numMontoVentas.Value = config.MontoVentasNotificar;
                chkAlertarProductosVencer.Checked = config.AlertaProductosVencer;
                chkNotificarCompras.Checked = config.NotificarCompras;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar configuración: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GuardarConfiguracion()
        {
            try
            {
                var config = new ConfiguracionReportes
                {
                    // Reportes automáticos
                    GenerarReportesAuto = chkGenerarReportes.Checked,
                    FrecuenciaReportes = rbDiario.Checked ? "DIARIO" : rbSemanal.Checked ? "SEMANAL" : "MENSUAL",
                    DiaEnvioReportes = cmbDiaEnvio.SelectedIndex,
                    HoraEnvioReportes = dtpHora.Value.TimeOfDay,

                    // Reportes a generar
                    ReporteVentas = chkMostrarLogo.Checked,
                    ReporteInventario = chkMostrarNombre.Checked,
                    ReporteStockBajo = chkMostrarRUC.Checked,
                    ReporteCaja = chkMostrarDireccion.Checked,
                    ReporteCompras = chkMostrarTelefono.Checked,
                    ReporteCuentasCobrar = chkMostrarEmail.Checked,

                    // Notificaciones por correo
                    EnviarPorCorreo = chkEnviarporCorreo.Checked,
                    DestinatariosCorreo = txtDestinatarios.Text.Trim(),
                    AsuntoCorreo = txtAsunto.Text.Trim(),
                    FormatoReporte = chkAmbosFormatos.Checked ? "AMBOS" : rbPDF.Checked ? "PDF" : "EXCEL",

                    // Alertas
                    AlertaStockBajo = chkAlertaStockBajo.Checked,
                    NotificarVentasMayores = chkNotificarVentasMayores.Checked,
                    MontoVentasNotificar = numMontoVentas.Value,
                    AlertaProductosVencer = chkAlertarProductosVencer.Checked,
                    NotificarCompras = chkNotificarCompras.Checked
                };

                ConfiguracionRepository.GuardarConfiguracion(config);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar configuración: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChkGenerarReportes_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarEstadoReportes();
            GuardarConfiguracion();
        }

        private void ChkEnviarporCorreo_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarEstadoCorreo();
            GuardarConfiguracion();
        }

        private void FrecuenciaChanged(object sender, EventArgs e)
        {
            bool showDay = rbSemanal.Checked || rbMensual.Checked;

            // Mostrar/ocultar selector de día según frecuencia
            lblDiaEnvio.Visible = showDay;
            cmbDiaEnvio.Visible = showDay;

            // Reposicionar hora: a la derecha del día si éste es visible, o a la izquierda si está oculto
            lblHora.Left  = showDay ? 188 : 18;
            dtpHora.Left  = showDay ? 188 : 18;

            if (rbMensual.Checked)
            {
                lblDiaEnvio.Text = "Día del mes:";
                cmbDiaEnvio.Items.Clear();
                for (int i = 1; i <= 28; i++)
                    cmbDiaEnvio.Items.Add(i.ToString());
                cmbDiaEnvio.SelectedIndex = 0;
            }
            else if (rbSemanal.Checked)
            {
                lblDiaEnvio.Text = "Día de Envío:";
                cmbDiaEnvio.Items.Clear();
                cmbDiaEnvio.Items.AddRange(new object[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" });
                cmbDiaEnvio.SelectedIndex = 0;
            }

            GuardarConfiguracion();
        }

        private void ActualizarEstadoReportes()
        {
            bool habilitado = chkGenerarReportes.Checked;

            rbDiario.Enabled = habilitado;
            rbSemanal.Enabled = habilitado;
            rbMensual.Enabled = habilitado;
            cmbDiaEnvio.Enabled = habilitado;
            dtpHora.Enabled = habilitado;
            chkMostrarLogo.Enabled = habilitado;
            chkMostrarNombre.Enabled = habilitado;
            chkMostrarRUC.Enabled = habilitado;
            chkMostrarDireccion.Enabled = habilitado;
            chkMostrarTelefono.Enabled = habilitado;
            chkMostrarEmail.Enabled = habilitado;
        }

        private void ActualizarEstadoCorreo()
        {
            bool habilitado = chkEnviarporCorreo.Checked;

            txtDestinatarios.Enabled = habilitado;
            txtAsunto.Enabled = habilitado;
            rbPDF.Enabled = habilitado;
            rbExcel.Enabled = habilitado;
            chkAmbosFormatos.Enabled = habilitado;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            GuardarConfiguracion();
            base.OnFormClosing(e);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            GuardarConfiguracion();
            lblEstadoGuardado.Text      = "\uE73E  Configuracion guardada correctamente";
            lblEstadoGuardado.ForeColor = System.Drawing.Color.FromArgb(100, 220, 150);
        }
    }
}
