using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Principal
{
    public partial class FormPrincipal : Form
    {
        private Form formActivo;
        private Button _botonSeleccionado;
        private Dictionary<Button, Image> _iconosNormal;
        private Dictionary<Button, Image> _iconosHover;
        private Dictionary<Button, Color> _coloresIcono;

        private readonly Color _colorTextoNormal = Color.Black;
        private readonly Color _bgSeleccionado = Color.FromArgb(232, 245, 253);
        private ContextMenuStrip _menuUsuario;

        public FormPrincipal()
        {
            InitializeComponent();
            ConfigurarAccesosMiEmpresa();
            ConfigurarIconosMenu();
            AplicarPermisosUI();
            ConfigurarMenuUsuario();
            ConfigurarMenuUsuarioConfig();
            ActualizarPermisosMenuUsuario();
            ActualizarBarraEstado();
            btnUsuarioConfig.BringToFront();
        }

        private bool TienePermiso(Func<SistemaPOS.Models.Usuario, bool> evaluador, string modulo)
        {
            var usuario = SesionActual.Usuario;
            if (usuario == null)
            {
                MessageBox.Show($"No tiene permisos para acceder a {modulo}.", "Acceso denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Administrador con acceso total
            if (usuario.RolID == 1)
                return true;

            if (!evaluador(usuario))
            {
                MessageBox.Show($"No tiene permisos para acceder a {modulo}.", "Acceso denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void AplicarPermisosUI()
        {
            var u = SesionActual.Usuario;
            if (u == null) return;

            // Administrador con acceso total
            if (u.RolID == 1)
            {
                btnVentas.Enabled = true;
                btnHistorialVentas.Enabled = true;
                btnCompras.Enabled = true;
                btnHistorialCompras.Enabled = true;
                btnProductos.Enabled = true;
                btnKardex.Enabled = true;
                btnAjustes.Enabled = true;
                btnClientes.Enabled = true;
                btnProveedores.Enabled = true;
                btnCaja.Enabled = true;
                btnGastos.Enabled = true;
                btnCobros.Enabled = true;
                btnCuentasPagar.Enabled = true;
                btnContabilidad.Enabled = true;
                btnFlujoCaja.Enabled = true;
                btnEstadoResultados.Enabled = true;
                btnBalanceGeneral.Enabled = true;
                btnReportes.Enabled = true;
                btnUsuarios.Enabled = true;
                btnEmpresa.Enabled = true;
                btnConfiguracion.Enabled = true;
                ActualizarPermisosMenuUsuario();
                return;
            }

            btnVentas.Enabled = u.PermisoVentas;
            btnHistorialVentas.Enabled = u.PermisoVentas;

            btnCompras.Enabled = u.PermisoCompras;
            btnHistorialCompras.Enabled = u.PermisoCompras;

            btnProductos.Enabled = u.PermisoInventario;
            btnKardex.Enabled = u.PermisoInventario;
            btnAjustes.Enabled = u.PermisoInventario;

            btnClientes.Enabled = u.PermisoClientes;
            btnProveedores.Enabled = u.PermisoProveedores;

            btnCaja.Enabled = u.PermisoFinanzas;
            btnGastos.Enabled = u.PermisoFinanzas;
            btnCobros.Enabled = u.PermisoFinanzas;
            btnCuentasPagar.Enabled = u.PermisoFinanzas;
            btnContabilidad.Enabled = u.PermisoFinanzas || u.PermisoReportes;

            btnFlujoCaja.Enabled = u.PermisoReportes;
            btnEstadoResultados.Enabled = u.PermisoReportes;
            btnBalanceGeneral.Enabled = u.PermisoReportes;
            btnReportes.Enabled = u.PermisoReportes;

            btnUsuarios.Enabled = u.PermisoConfiguracion;
            btnEmpresa.Enabled = u.PermisoConfiguracion;
            btnConfiguracion.Enabled = u.PermisoConfiguracion;

            ActualizarPermisosMenuUsuario();
        }


        private void ConfigurarMenuUsuario()
        {
            _menuUsuario = new ContextMenuStrip();
            _menuUsuario.Items.Add("Mi cuenta", null, (_, __) => MostrarMiCuenta());
            _menuUsuario.Items.Add("Empresa", null, (_, __) => BtnEmpresa_Click(_, __));
            _menuUsuario.Items.Add("Usuarios y roles", null, (_, __) => BtnUsuarios_Click(_, __));
            _menuUsuario.Items.Add("Reportes", null, (_, __) => BtnReportes_Click(_, __));
            _menuUsuario.Items.Add(new ToolStripSeparator());
            _menuUsuario.Items.Add("Cerrar sesion", null, (_, __) => BtnCerrarSesion_Click(_, __));
        }

        private void ConfigurarMenuUsuarioConfig()
        {
            ActualizarPermisosMenuUsuario();
        }

        private void ActualizarPermisosMenuUsuario()
        {
            if (_menuUsuario == null) return;

            var usuario = SesionActual.Usuario;
            bool permisoConfig = usuario != null && (usuario.RolID == 1 || usuario.PermisoConfiguracion);
            bool permisoReportes = usuario != null && (usuario.RolID == 1 || usuario.PermisoReportes);

            // 0: Mi cuenta | 1: Empresa | 2: Usuarios y roles | 3: Reportes
            _menuUsuario.Items[0].Enabled = true;
            _menuUsuario.Items[1].Enabled = permisoConfig;
            _menuUsuario.Items[2].Enabled = permisoConfig;
            _menuUsuario.Items[3].Enabled = permisoReportes;

            mnuEmpresa.Visible        = permisoConfig;
            mnuUsuarios.Visible       = permisoConfig;
            mnuCategorias.Visible     = permisoConfig;
            mnuPresentaciones.Visible = permisoConfig;
            mnuUnidades.Visible       = permisoConfig;
            mnuImpresoras.Visible     = permisoConfig;
            mnuRespaldo.Visible       = permisoConfig;
            mnuGeneral.Visible        = permisoConfig;
            mnuLicencia.Visible       = permisoConfig;
            mnuSep.Visible            = permisoConfig && permisoReportes;
            mnuReportes.Visible       = permisoReportes;
            btnUsuarioConfig.Enabled  = permisoConfig || permisoReportes;
        }

        private void BtnUsuarioConfig_Click(object sender, EventArgs e)
        {
            cmsUsuarioConfig.Show(btnUsuarioConfig, new System.Drawing.Point(0, btnUsuarioConfig.Height));
        }

        private void MnuEmpresa_Click(object sender, EventArgs e) => BtnEmpresa_Click(sender, e);
        private void MnuUsuarios_Click(object sender, EventArgs e) => BtnUsuarios_Click(sender, e);
        private void MnuReportes_Click(object sender, EventArgs e) => BtnReportes_Click(sender, e);

        private void MnuCategorias_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoConfiguracion, "Categorias")) return;
            AbrirFormEnPanel(new Configuracion.FormCategorias());
        }

        private void MnuPresentaciones_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoConfiguracion, "Presentaciones")) return;
            AbrirFormEnPanel(new Configuracion.FormPresentaciones());
        }

        private void MnuUnidades_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoConfiguracion, "Unidades")) return;
            AbrirFormEnPanel(new Configuracion.FormUnidades());
        }

        private void MnuImpresoras_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoConfiguracion, "Impresoras")) return;
            AbrirFormEnPanel(new Configuracion.FormImpresoras());
        }

        private void MnuRespaldo_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoConfiguracion, "Respaldo")) return;
            AbrirFormEnPanel(new Configuracion.FormRespaldo());
        }

        private void MnuGeneral_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoConfiguracion, "General")) return;
            AbrirFormEnPanel(new Configuracion.FormGeneral());
        }

        private void MnuLicencia_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoConfiguracion, "Licencia")) return;
            AbrirFormEnPanel(new Configuracion.FormLicencia());
        }

        private void MostrarMiCuenta()
        {
            var usuario = SesionActual.Usuario;
            if (usuario == null) return;

            string mensaje =
                $"Usuario: {usuario.NombreUsuario}\n" +
                $"Nombre: {usuario.NombreCompleto}\n" +
                $"Email: {usuario.Email}\n" +
                $"Rol ID: {usuario.RolID}";

            MessageBox.Show(mensaje, "Mi cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ConfigurarIconosMenu()
        {
            _iconosNormal = new Dictionary<Button, Image>();
            _iconosHover = new Dictionary<Button, Image>();
            _coloresIcono = new Dictionary<Button, Color>();

            var r = Properties.Resources.ResourceManager;
            RegistrarIcono(btnDashboard, r.GetObject("Icono-Boton-Dashboard") as Image, r.GetObject("Icono-Boton-Dashboard-hover") as Image);
            RegistrarIcono(btnVentas, r.GetObject("Icono-Boton-Ventas") as Image, r.GetObject("Icono-Boton-Ventas-hover") as Image);
            RegistrarIcono(btnHistorialVentas, r.GetObject("Icono-Boton-HistorialVentas") as Image, r.GetObject("Icono-Boton-HistorialVentas-hover") as Image);
            RegistrarIcono(btnCompras, r.GetObject("Icono-Boton-Compras") as Image, r.GetObject("Icono-Boton-Compras-hover") as Image);
            RegistrarIcono(btnHistorialCompras, r.GetObject("Icono-Boton-HistorialCompras") as Image, r.GetObject("Icono-Boton-HistorialCompras-hover") as Image);
            RegistrarIcono(btnProductos, r.GetObject("Icono-Boton-Productos") as Image, r.GetObject("Icono-Boton-Productos-hover") as Image);
            RegistrarIcono(btnKardex, r.GetObject("Icono-Boton-AlertaStock") as Image, r.GetObject("Icono-Boton-AlertaStock-hover") as Image);
            RegistrarIcono(btnAjustes, r.GetObject("Icono-Boton-Ajustes") as Image, r.GetObject("Icono-Boton-Ajustes-hover") as Image);
            RegistrarIcono(btnClientes, r.GetObject("Icono-Boton-Clientes") as Image, r.GetObject("Icono-Boton-Clientes-hover") as Image);
            RegistrarIcono(btnProveedores, r.GetObject("Icono-Boton-Proveedores") as Image, r.GetObject("Icono-Boton-Proveedores-hover") as Image);
            RegistrarIcono(btnCaja, r.GetObject("Icono-Boton-Caja") as Image, r.GetObject("Icono-Boton-Caja-hover") as Image);
            RegistrarIcono(btnGastos, r.GetObject("Icono-Boton-Gastos") as Image, r.GetObject("Icono-Boton-Gastos-hover") as Image);
            RegistrarIcono(btnCobros, r.GetObject("Icono-Boton-LibroDiario") as Image, r.GetObject("Icono-Boton-LibroDiario-hover") as Image);
            RegistrarIcono(btnCuentasPagar, r.GetObject("Icono-Boton-CuentasPorPagar") as Image, r.GetObject("Icono-Boton-CuentasPorPagar-hover") as Image);
            RegistrarIcono(btnFlujoCaja, r.GetObject("Icono-Boton-FlujoDeCaja") as Image, r.GetObject("Icono-Boton-FlujoDeCaja-hover") as Image);
            RegistrarIcono(btnEstadoResultados, r.GetObject("Icono-Boton-EstadoDeResultado") as Image, r.GetObject("Icono-Boton-EstadoDeResultado-hover") as Image);
            RegistrarIcono(btnBalanceGeneral, r.GetObject("Icono-Boton-BalanceGeneral") as Image, r.GetObject("Icono-Boton-BalanceGeneral-hover") as Image);
            RegistrarIcono(btnReportes, r.GetObject("Icono-Boton-ReportesGenerales") as Image, r.GetObject("Icono-Boton-ReportesGenerales-hover") as Image);
            RegistrarIcono(btnUsuarios, r.GetObject("Icono-Boton-Usuarios") as Image, r.GetObject("Icono-Boton-Usuarios-hover") as Image);
            RegistrarIcono(btnEmpresa, r.GetObject("Icono-Boton-Empresa") as Image, r.GetObject("Icono-Boton-Empresa-hover") as Image);
            RegistrarIcono(btnConfiguracion, r.GetObject("Icono-Boton-Configuracion") as Image, r.GetObject("Icono-Boton-Configuraciones-hover") as Image);
            RegistrarIcono(btnCerrarSesion, r.GetObject("Icono-Boton-Cerrar") as Image, r.GetObject("Icono-Boton-Cerrar-hover") as Image);
        }

        private void ConfigurarAccesosMiEmpresa()
        {
            // Estos accesos se muestran solo en el selector "Mi empresa" (parte superior)
            btnReportes.Visible = false;
            btnUsuarios.Visible = false;
            btnEmpresa.Visible = false;
            btnConfiguracion.Visible = false;
            lblConfiguracion.Visible = false;
        }

        private void RegistrarIcono(Button btn, Image normal, Image hover)
        {
            if (normal != null) _iconosNormal[btn] = normal;
            if (hover != null)
            {
                _iconosHover[btn] = hover;
                _coloresIcono[btn] = ObtenerColorDominante((Bitmap)hover);
            }
            btn.MouseEnter += BtnMenu_MouseEnter;
            btn.MouseLeave += BtnMenu_MouseLeave;
        }

        private Color ObtenerColorDominante(Bitmap bmp)
        {
            int r = 0, g = 0, b = 0, count = 0;

            for (int x = 0; x < bmp.Width; x += 2)
            {
                for (int y = 0; y < bmp.Height; y += 2)
                {
                    var pixel = bmp.GetPixel(x, y);
                    // Ignorar pixels transparentes, blancos y muy claros
                    if (pixel.A < 100) continue;
                    if (pixel.R > 220 && pixel.G > 220 && pixel.B > 220) continue;

                    r += pixel.R;
                    g += pixel.G;
                    b += pixel.B;
                    count++;
                }
            }

            if (count == 0) return Color.FromArgb(52, 152, 219);
            return Color.FromArgb(r / count, g / count, b / count);
        }

        private void BtnMenu_MouseEnter(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn == _botonSeleccionado) return;
            if (_iconosHover.ContainsKey(btn)) btn.Image = _iconosHover[btn];
            if (_coloresIcono.ContainsKey(btn)) btn.ForeColor = _coloresIcono[btn];
        }

        private void BtnMenu_MouseLeave(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn == _botonSeleccionado) return;
            if (_iconosNormal.ContainsKey(btn)) btn.Image = _iconosNormal[btn];
            btn.ForeColor = _colorTextoNormal;
        }

        private void SeleccionarBoton(Button btn)
        {
            // Restaurar boton anterior
            if (_botonSeleccionado != null && _botonSeleccionado != btn)
            {
                if (_iconosNormal.ContainsKey(_botonSeleccionado))
                    _botonSeleccionado.Image = _iconosNormal[_botonSeleccionado];
                _botonSeleccionado.ForeColor = _colorTextoNormal;
                _botonSeleccionado.BackColor = Color.White;
            }

            // Marcar nuevo boton como seleccionado
            _botonSeleccionado = btn;
            if (_iconosHover.ContainsKey(btn)) btn.Image = _iconosHover[btn];
            if (_coloresIcono.ContainsKey(btn)) btn.ForeColor = _coloresIcono[btn];
            btn.BackColor = _bgSeleccionado;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormDashboard(), btnDashboard);
        }

        private void AbrirFormEnPanel(Form formHijo, Button botonOrigen = null)
        {
            if (formActivo != null)
                formActivo.Close();

            formActivo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(formHijo);
            pnlContenido.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();

            if (botonOrigen != null)
                SeleccionarBoton(botonOrigen);
        }

        private void ActualizarBarraEstado()
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        // === EVENTOS DE BOTONES ===

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormDashboard(), btnDashboard);
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoVentas, "Ventas")) return;
            AbrirFormEnPanel(new Ventas.FormVentas(), btnVentas);
        }

        private void BtnHistorialVentas_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoVentas, "Historial de Ventas")) return;
            AbrirFormEnPanel(new Ventas.FormHistorialVentas(), btnHistorialVentas);
        }

        private void BtnCompras_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoCompras, "Compras")) return;
            AbrirFormEnPanel(new Compras.FormCompras(), btnCompras);
        }

        private void BtnHistorialCompras_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoCompras, "Historial de Compras")) return;
            AbrirFormEnPanel(new Compras.FormHistorialCompras(), btnHistorialCompras);
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoInventario, "Productos")) return;
            AbrirFormEnPanel(new Inventario.FormProductos(), btnProductos);
        }

        private void BtnKardex_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoInventario, "Kardex")) return;
            AbrirFormEnPanel(new Inventario.FormKardex(), btnKardex);
        }

        private void BtnAjustes_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoInventario, "Ajustes de Inventario")) return;
            AbrirFormEnPanel(new Inventario.FormAjustes(), btnAjustes);
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoClientes, "Clientes")) return;
            AbrirFormEnPanel(new Contactos.FormClientes(), btnClientes);
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoProveedores, "Proveedores")) return;
            AbrirFormEnPanel(new Contactos.FormProveedores(), btnProveedores);
        }

        private void BtnCaja_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoFinanzas, "Caja")) return;
            AbrirFormEnPanel(new Finanzas.FormCaja(), btnCaja);
        }

        private void BtnGastos_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoFinanzas, "Gastos")) return;
            AbrirFormEnPanel(new Finanzas.FormGastos(), btnGastos);
        }

        private void BtnCobros_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoFinanzas, "Cuentas por Cobrar")) return;
            AbrirFormEnPanel(new Finanzas.FormCuentasPorCobrar(), btnCobros);
        }

        private void BtnCuentasPagar_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoFinanzas, "Cuentas por Pagar")) return;
            AbrirFormEnPanel(new Finanzas.FormCuentasPorPagar(), btnCuentasPagar);
        }

        private void BtnContabilidad_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoFinanzas || u.PermisoReportes, "Contabilidad")) return;
            AbrirFormEnPanel(new Finanzas.FormContabilidad(), btnContabilidad);
        }

        private void BtnFlujoCaja_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoReportes, "Flujo de Caja")) return;
            AbrirFormEnPanel(new Reportes.FormFlujoCaja(), btnFlujoCaja);
        }

        private void BtnEstadoResultados_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoReportes, "Estado de Resultados")) return;
            AbrirFormEnPanel(new Reportes.FormEstadoResultados(), btnEstadoResultados);
        }

        private void BtnBalanceGeneral_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoReportes, "Balance General")) return;
            AbrirFormEnPanel(new Reportes.FormBalanceGeneral(), btnBalanceGeneral);
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoReportes, "Reportes")) return;
            AbrirFormEnPanel(new Reportes.FormReportes(), btnReportes);
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoConfiguracion, "Usuarios")) return;
            AbrirFormEnPanel(new Configuracion.FormUsuarios(), btnUsuarios);
        }

        private void BtnEmpresa_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoConfiguracion, "Empresa")) return;
            AbrirFormEnPanel(new Configuracion.FormEmpresa(), btnEmpresa);
        }

        private void BtnConfiguracion_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoConfiguracion, "Configuración")) return;
            AbrirFormEnPanel(new Configuracion.FormConfiguracion(), btnConfiguracion);
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, bool wParam, int lParam);
        private const int WM_SETREDRAW = 0x000B;

        private bool _menuExpandido = true;
        private Timer _menuAnimTimer;
        private int _menuTargetWidth;
        private Dictionary<Button, string> _textosBotones;

        private void InicializarMenuAnimacion()
        {
            _textosBotones = new Dictionary<Button, string>();
            foreach (Control ctrl in pnlMenu.Controls)
            {
                if (ctrl is Button btn && btn != btnToggleMenu)
                    _textosBotones[btn] = btn.Text;
            }
        }

        private void BtnToggleMenu_Click(object sender, EventArgs e)
        {
            if (_textosBotones == null)
                InicializarMenuAnimacion();

            _menuExpandido = !_menuExpandido;
            _menuTargetWidth = _menuExpandido ? 250 : 60;

            if (_menuAnimTimer == null)
            {
                _menuAnimTimer = new Timer();
                _menuAnimTimer.Interval = 12;
                _menuAnimTimer.Tick += MenuAnimTimer_Tick;
            }

            // Al colapsar: ocultar textos y labels antes de animar
            if (!_menuExpandido)
            {
                foreach (Control ctrl in pnlMenu.Controls)
                {
                    if (ctrl is Label lbl)
                        lbl.Visible = false;
                    else if (ctrl is Button btn && btn != btnToggleMenu)
                    {
                        btn.Text = "";
                        // Restaurar fondo blanco excepto el seleccionado
                        if (btn != _botonSeleccionado)
                            btn.BackColor = Color.White;
                    }
                }
            }

            // Congelar redibujado del contenido durante la animacion
            SendMessage(pnlContenido.Handle, WM_SETREDRAW, false, 0);

            _menuAnimTimer.Start();
        }

        private void MenuAnimTimer_Tick(object sender, EventArgs e)
        {
            int diff = _menuTargetWidth - pnlMenu.Width;

            if (diff == 0)
            {
                _menuAnimTimer.Stop();

                // Reactivar redibujado del contenido
                SendMessage(pnlContenido.Handle, WM_SETREDRAW, true, 0);
                pnlContenido.Invalidate(true);
                pnlContenido.Update();

                // Al expandir: restaurar textos y labels
                if (_menuExpandido)
                {
                    foreach (Control ctrl in pnlMenu.Controls)
                    {
                        if (ctrl is Label lbl)
                            lbl.Visible = true;
                        else if (ctrl is Button btn && btn != btnToggleMenu && _textosBotones.ContainsKey(btn))
                        {
                            btn.Text = _textosBotones[btn];
                        }
                    }
                }
                return;
            }

            // Easing: desaceleracion suave
            int step = Math.Max(3, Math.Abs(diff) / 4);

            if (diff > 0)
                pnlMenu.Width = Math.Min(pnlMenu.Width + step, _menuTargetWidth);
            else
                pnlMenu.Width = Math.Max(pnlMenu.Width - step, _menuTargetWidth);

            pnlContenido.Left = pnlMenu.Width + 1;
            pnlContenido.Width = this.ClientSize.Width - pnlMenu.Width - 1;
            pnlMenuBorder.Left = pnlMenu.Width;
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Está seguro de cerrar sesión?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                FormLogin login = new FormLogin();
                login.ShowDialog();
                this.Close();
            }
        }
    }
}
