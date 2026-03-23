using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;

namespace SistemaPOS.Forms.Configuracion
{
    public partial class FormEmpresa : Form
    {
        private Empresa _empresa;
        private ConfiguracionFacturacion _configFacturacion;
        private byte[] _logoActual;
        private bool _claveVisible = false;

        public FormEmpresa()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            ConfigurarEventos();
            ConfigurarControles();
            CargarDatos();
        }

        private void ConfigurarEventos()
        {
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            btnCargar.Click += BtnCargar_Click;
            btnQuitar.Click += BtnQuitar_Click;
            btnBuscarRUC.Click += BtnBuscarRUC_Click;
            btnMostrarClave.Click += BtnMostrarClave_Click;
            cmbMoneda.SelectedIndexChanged += CmbMoneda_SelectedIndexChanged;
            txtRUC.KeyPress += TxtRUC_KeyPress;
            txtTelefono.KeyPress += TxtTelefono_KeyPress;
        }

        private void ConfigurarControles()
        {
            // Configurar PictureBox para el logo
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.BorderStyle = BorderStyle.FixedSingle;
            pbLogo.BackColor = Color.White;

            // Configurar ComboBox de moneda
            cmbMoneda.Items.Clear();
            cmbMoneda.Items.Add("PEN - Soles");
            cmbMoneda.Items.Add("USD - Dólares");
            cmbMoneda.Items.Add("EUR - Euros");
            cmbMoneda.SelectedIndex = 0;

            // Configurar campo de clave
            txtClaveSOL.PasswordChar = '*';

            // Limitar longitud de campos
            txtRUC.MaxLength = 11;
            txtTelefono.MaxLength = 20;
            txtSerieNV.MaxLength = 4;
            txtNumeroNV.MaxLength = 8;
            txtSerieB.MaxLength = 4;
            txtNumeroB.MaxLength = 8;
            txtSerieF.MaxLength = 4;
            txtNumeroF.MaxLength = 8;
        }

        private void CargarDatos()
        {
            try
            {
                // Cargar datos de empresa
                _empresa = EmpresaRepository.ObtenerEmpresa();
                if (_empresa == null)
                {
                    _empresa = new Empresa();
                }

                // Cargar configuración de facturación
                _configFacturacion = EmpresaRepository.ObtenerConfiguracionFacturacion();

                // Mostrar datos de empresa
                txtRUC.Text = _empresa.RUC ?? "";
                // Preferir NombreComercial si existe; si no, mostrar RazonSocial
                string nombreDisplay = !string.IsNullOrWhiteSpace(_empresa.NombreComercial)
                    ? _empresa.NombreComercial
                    : (_empresa.RazonSocial ?? "");
                txtNombre.Text = nombreDisplay;
                txtDireccion.Text = _empresa.Direccion ?? "";
                txtTelefono.Text = _empresa.Telefono ?? "";
                txtEmail.Text = _empresa.Email ?? "";
                txtSitioWeb.Text = _empresa.Web ?? "";

                // Cargar logo
                _logoActual = _empresa.Logo;
                MostrarLogo();

                // Mostrar configuración de moneda
                switch (_configFacturacion.Moneda)
                {
                    case "PEN":
                        cmbMoneda.SelectedIndex = 0;
                        break;
                    case "USD":
                        cmbMoneda.SelectedIndex = 1;
                        break;
                    case "EUR":
                        cmbMoneda.SelectedIndex = 2;
                        break;
                    default:
                        cmbMoneda.SelectedIndex = 0;
                        break;
                }
                txtSimbolo.Text = _configFacturacion.SimboloMoneda ?? "S/";

                // Mostrar datos de facturación
                txtUsuarioSOL.Text = _configFacturacion.UsuarioSOL ?? "";
                txtClaveSOL.Text = _configFacturacion.ClaveSOL ?? "";

                // Series y correlativos
                txtSerieNV.Text = _configFacturacion.SerieNotaVenta ?? "NV01";
                txtNumeroNV.Text = _configFacturacion.CorrelativoNotaVenta.ToString().PadLeft(8, '0');
                txtSerieB.Text = _configFacturacion.SerieBoleta ?? "B001";
                txtNumeroB.Text = _configFacturacion.CorrelativoBoleta.ToString().PadLeft(8, '0');
                txtSerieF.Text = _configFacturacion.SerieFactura ?? "F001";
                txtNumeroF.Text = _configFacturacion.CorrelativoFactura.ToString().PadLeft(8, '0');
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarLogo()
        {
            if (_logoActual != null && _logoActual.Length > 0)
            {
                try
                {
                    using (var ms = new MemoryStream(_logoActual))
                        pbLogo.Image = new System.Drawing.Bitmap(ms);
                }
                catch
                {
                    pbLogo.Image = null;
                }
            }
            else
            {
                pbLogo.Image = null;
            }
        }

        private bool ValidarFormulario()
        {
            // Validar RUC
            if (string.IsNullOrWhiteSpace(txtRUC.Text))
            {
                MessageBox.Show("Ingrese el RUC de la empresa", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRUC.Focus();
                return false;
            }

            if (txtRUC.Text.Trim().Length != 11)
            {
                MessageBox.Show("El RUC debe tener 11 dígitos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRUC.Focus();
                return false;
            }

            // Validar nombre del negocio
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del negocio o razón social", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            // Validar email si está ingresado
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    MessageBox.Show("El email ingresado no es válido", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }

            // Validar series de comprobantes
            if (string.IsNullOrWhiteSpace(txtSerieNV.Text))
            {
                MessageBox.Show("Ingrese la serie para Nota de Venta", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSerieNV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSerieB.Text))
            {
                MessageBox.Show("Ingrese la serie para Boleta", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSerieB.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSerieF.Text))
            {
                MessageBox.Show("Ingrese la serie para Factura", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSerieF.Focus();
                return false;
            }

            return true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                // Guardar datos de empresa
                _empresa.RUC = txtRUC.Text.Trim();
                _empresa.RazonSocial = txtNombre.Text.Trim();
                _empresa.NombreComercial = txtNombre.Text.Trim();
                _empresa.Direccion = txtDireccion.Text.Trim();
                _empresa.Telefono = txtTelefono.Text.Trim();
                _empresa.Email = txtEmail.Text.Trim();
                _empresa.Web = txtSitioWeb.Text.Trim();
                _empresa.Logo = _logoActual;

                if (!EmpresaRepository.GuardarEmpresa(_empresa))
                {
                    MessageBox.Show("No se pudo guardar los datos de la empresa", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Guardar configuración de facturación
                string monedaCodigo = "PEN";
                switch (cmbMoneda.SelectedIndex)
                {
                    case 0: monedaCodigo = "PEN"; break;
                    case 1: monedaCodigo = "USD"; break;
                    case 2: monedaCodigo = "EUR"; break;
                }

                _configFacturacion.Moneda = monedaCodigo;
                _configFacturacion.SimboloMoneda = txtSimbolo.Text.Trim();
                _configFacturacion.UsuarioSOL = txtUsuarioSOL.Text.Trim();
                _configFacturacion.ClaveSOL = txtClaveSOL.Text.Trim();
                _configFacturacion.SerieNotaVenta = txtSerieNV.Text.Trim().ToUpper();
                _configFacturacion.CorrelativoNotaVenta = int.TryParse(txtNumeroNV.Text.Trim(), out int nvCorr) ? nvCorr : 0;
                _configFacturacion.SerieBoleta = txtSerieB.Text.Trim().ToUpper();
                _configFacturacion.CorrelativoBoleta = int.TryParse(txtNumeroB.Text.Trim(), out int bCorr) ? bCorr : 0;
                _configFacturacion.SerieFactura = txtSerieF.Text.Trim().ToUpper();
                _configFacturacion.CorrelativoFactura = int.TryParse(txtNumeroF.Text.Trim(), out int fCorr) ? fCorr : 0;

                if (!EmpresaRepository.GuardarConfiguracionFacturacion(_configFacturacion))
                {
                    MessageBox.Show("No se pudo guardar la configuración de facturación", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Datos guardados exitosamente", "Éxito",
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

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            using (var openDialog = new OpenFileDialog())
            {
                openDialog.Title = "Seleccionar Logo";
                openDialog.Filter = "Imágenes|*.png;*.jpg;*.jpeg;*.bmp;*.gif|Todos los archivos|*.*";
                openDialog.FilterIndex = 1;

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Validar tamaño del archivo (máx 2MB)
                        var fileInfo = new FileInfo(openDialog.FileName);
                        if (fileInfo.Length > 2 * 1024 * 1024)
                        {
                            MessageBox.Show("El archivo es demasiado grande. Máximo 2MB permitido.", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Cargar imagen
                        _logoActual = File.ReadAllBytes(openDialog.FileName);
                        MostrarLogo();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            if (_logoActual == null || _logoActual.Length == 0)
                return;

            var result = MessageBox.Show("¿Desea quitar el logo actual?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _logoActual = null;
                pbLogo.Image = null;
            }
        }

        private void BtnBuscarRUC_Click(object sender, EventArgs e)
        {
            // Funcionalidad de búsqueda en SUNAT - próximamente
            MessageBox.Show("Consulta SUNAT próximamente disponible.\n\n" +
                "Por ahora, ingrese los datos manualmente.",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnMostrarClave_Click(object sender, EventArgs e)
        {
            _claveVisible = !_claveVisible;
            txtClaveSOL.PasswordChar = _claveVisible ? '\0' : '*';
            btnMostrarClave.Text = _claveVisible ? "🔒" : "👁";
        }

        private void CmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbMoneda.SelectedIndex)
            {
                case 0: // PEN
                    txtSimbolo.Text = "S/";
                    break;
                case 1: // USD
                    txtSimbolo.Text = "$";
                    break;
                case 2: // EUR
                    txtSimbolo.Text = "€";
                    break;
            }
        }

        private void TxtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir números
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, +, -, (, ), espacios
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '(' &&
                e.KeyChar != ')' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}
