using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Principal
{
    public partial class FormPrincipal : Form
    {
        private Form formActivo;
        private Button _botonSeleccionado;
        private ContextMenuStrip _menuUsuario;

        // Company chip
        private bool   _chipHovered     = false;
        private string _empresaNombre   = "Mi Empresa";
        private string _empresaInicial  = "E";

        // Inactividad
        private Timer _timerInactividad;
        private DateTime _ultimaActividad = DateTime.Now;
        private bool _avisoMostrado = false;
        private int _minutosInactividad = 30;

        public FormPrincipal()
        {
            InitializeComponent();
            MostrarSeccionConfiguracion();
            ReconfigurarMenuContextual();
            AplicarPermisosUI();
            ConfigurarMenuUsuario();
            ConfigurarMenuUsuarioConfig();
            ActualizarPermisosMenuUsuario();
            ActualizarBarraEstado();
            btnUsuarioConfig.BringToFront();
            InicializarInactividad();
            CargarNombreEmpresa();
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
                btnUsuarios.Enabled = true;
                btnEmpresa.Enabled = true;

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

            btnUsuarios.Enabled = u.PermisoConfiguracion;
            btnEmpresa.Enabled = u.PermisoConfiguracion;


            ActualizarPermisosMenuUsuario();
        }


        private void ConfigurarMenuUsuario()
        {
            _menuUsuario = new ContextMenuStrip();
            _menuUsuario.Items.Add("Mi cuenta", null, (_, __) => MostrarMiCuenta());          // [0]
            _menuUsuario.Items.Add("Empresa", null, (_, __) => BtnEmpresa_Click(_, __));       // [1]
            _menuUsuario.Items.Add("Usuarios y roles", null, (_, __) => BtnUsuarios_Click(_, __)); // [2]
            _menuUsuario.Items.Add("Reportes", null, (_, __) => BtnReportes_Click(_, __));     // [3]
            _menuUsuario.Items.Add("Cierre de Período", null, (_, __) => AbrirCierrePeriodo()); // [4]
            _menuUsuario.Items.Add(new ToolStripSeparator());                                   // [5]
            _menuUsuario.Items.Add("Cerrar sesion", null, (_, __) => BtnCerrarSesion_Click(_, __)); // [6]
        }

        private void AbrirCierrePeriodo()
        {
            if (!TienePermiso(u => u.PermisoConfiguracion, "Cierre de Período")) return;
            AbrirFormEnPanel(new SistemaPOS.Forms.Finanzas.FormPeriodosContables());
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

            // 0: Mi cuenta | 1: Empresa | 2: Usuarios y roles | 3: Reportes | 4: Cierre de Período
            _menuUsuario.Items[0].Enabled = true;
            _menuUsuario.Items[1].Enabled = permisoConfig;
            _menuUsuario.Items[2].Enabled = permisoConfig;
            _menuUsuario.Items[3].Enabled = permisoReportes;
            _menuUsuario.Items[4].Enabled = permisoConfig;

            // cmsUsuarioConfig — permisos por ítem
            bool soloAdmin = usuario != null && usuario.RolID == 1;

            mnuEmpresa.Visible        = permisoConfig;
            mnuUsuarios.Visible       = permisoConfig;
            mnuCategorias.Visible     = permisoConfig;
            mnuPresentaciones.Visible = permisoConfig;
            mnuUnidades.Visible       = permisoConfig;
            mnuImpresoras.Visible     = permisoConfig;
            mnuRespaldo.Visible       = permisoConfig;
            mnuGeneral.Visible        = permisoConfig;
            mnuPapelera.Visible       = permisoConfig;
            mnuLicencia.Visible       = permisoConfig;
            mnuPeriodos.Visible       = permisoConfig;
            btnUsuarioConfig.Enabled  = permisoConfig;

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

        private void MnuPapelera_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoConfiguracion, "Papelera")) return;
            AbrirFormEnPanel(new SistemaPOS.Forms.Finanzas.FormPapeleraGlobal());
        }

        private void MnuLicencia_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoConfiguracion, "Licencia")) return;
            AbrirFormEnPanel(new Configuracion.FormLicencia());
        }

        private void MnuPeriodos_Click(object sender, EventArgs e)
        {
            AbrirCierrePeriodo();
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

        private void SeleccionarBoton(Button btn)
        {
            _botonSeleccionado = btn;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormDashboard(), btnDashboard);
            AutoBackupService.VerificarYEjecutar();
        }

        private void AbrirFormEnPanel(Form formHijo, Button botonOrigen = null)
        {
            if (formActivo != null && !formActivo.IsDisposed)
                formActivo.Close();
            formActivo = null;

            try
            {
                formHijo.TopLevel = false;
                formHijo.FormBorderStyle = FormBorderStyle.None;
                formHijo.Dock = DockStyle.Fill;
                pnlContenido.Controls.Add(formHijo);
                pnlContenido.Tag = formHijo;
                formHijo.BringToFront();
                formHijo.Show();

                // Si el formulario se auto-cerró durante Show() (ej. sin caja abierta), no lo guardamos
                formActivo = formHijo.IsDisposed ? null : formHijo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el módulo: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                formActivo = null;
            }

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

        private bool CajaEstaAbierta()
        {
            if (Data.CajaRepository.ObtenerCajaAbierta() != null) return true;
            Shared.FormAviso.Mostrar(
                "No hay caja abierta.\n\nDebe abrir un turno en el módulo de Caja\nantes de acceder a este módulo.",
                "Sin caja abierta", Shared.TipoAviso.Advertencia, this);
            return false;
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoVentas, "Ventas")) return;
            if (!CajaEstaAbierta()) return;
            AbrirFormEnPanel(new Ventas.FormVentas(), btnVentas);
        }

        private void BtnHistorialVentas_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoVentas, "Historial de Ventas")) return;
            if (!CajaEstaAbierta()) return;
            AbrirFormEnPanel(new Ventas.FormHistorialVentas(), btnHistorialVentas);
        }

        private void BtnCompras_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoCompras, "Compras")) return;
            if (!CajaEstaAbierta()) return;
            AbrirFormEnPanel(new Compras.FormCompras(), btnCompras);
        }

        private void BtnHistorialCompras_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoCompras, "Historial de Compras")) return;
            if (!CajaEstaAbierta()) return;
            AbrirFormEnPanel(new Compras.FormHistorialCompras(), btnHistorialCompras);
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoInventario, "Productos")) return;
            if (!CajaEstaAbierta()) return;
            AbrirFormEnPanel(new Inventario.FormProductos(), btnProductos);
        }

        private void BtnKardex_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoInventario, "Kardex")) return;
            if (!CajaEstaAbierta()) return;
            AbrirFormEnPanel(new Inventario.FormKardex(), btnKardex);
        }

        private void BtnAjustes_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoInventario, "Ajustes de Inventario")) return;
            if (!CajaEstaAbierta()) return;
            AbrirFormEnPanel(new Inventario.FormAjustes(), btnAjustes);
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoClientes, "Clientes")) return;
            if (!CajaEstaAbierta()) return;
            AbrirFormEnPanel(new Contactos.FormClientes(), btnClientes);
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoProveedores, "Proveedores")) return;
            if (!CajaEstaAbierta()) return;
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
            if (!CajaEstaAbierta()) return;
            AbrirFormEnPanel(new Finanzas.FormGastos(), btnGastos);
        }

        private void BtnCobros_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoFinanzas, "Cuentas por Cobrar")) return;
            if (!CajaEstaAbierta()) return;
            AbrirFormEnPanel(new Finanzas.FormCuentasPorCobrar(), btnCobros);
        }

        private void BtnCuentasPagar_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoFinanzas, "Cuentas por Pagar")) return;
            if (!CajaEstaAbierta()) return;
            AbrirFormEnPanel(new Finanzas.FormCuentasPorPagar(), btnCuentasPagar);
        }


        private void BtnReportes_Click(object sender, EventArgs e)
        {
            if (!TienePermiso(u => u.PermisoReportes, "Reportes")) return;
            Button btn = pnlMenu.Controls["btnReportes"] as Button;
            AbrirFormEnPanel(new Reportes.FormReportes(), btn);
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
            CargarNombreEmpresa(); // refresca el chip si el usuario guardó cambios
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
                        if (btn != _botonSeleccionado)
                            btn.BackColor = Color.Transparent;
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

        // ─── Menú contextual reorganizado con grupos ───────────────────
        private void ReconfigurarMenuContextual()
        {
            cmsUsuarioConfig.Items.Clear();

            // Grupo: CONFIGURACIÓN DEL NEGOCIO
            var hdrNegocio = new ToolStripMenuItem("— NEGOCIO —") { Enabled = false };
            hdrNegocio.Font = new System.Drawing.Font(hdrNegocio.Font, System.Drawing.FontStyle.Bold);
            cmsUsuarioConfig.Items.Add(hdrNegocio);
            cmsUsuarioConfig.Items.Add(mnuEmpresa);
            cmsUsuarioConfig.Items.Add(mnuGeneral);
            cmsUsuarioConfig.Items.Add(mnuImpresoras);
            cmsUsuarioConfig.Items.Add(mnuCategorias);
            cmsUsuarioConfig.Items.Add(mnuPresentaciones);
            cmsUsuarioConfig.Items.Add(mnuUnidades);
            cmsUsuarioConfig.Items.Add(new ToolStripSeparator());

            // Grupo: ADMINISTRACIÓN DEL SISTEMA
            var hdrAdmin = new ToolStripMenuItem("— ADMINISTRACIÓN —") { Enabled = false };
            hdrAdmin.Font = new System.Drawing.Font(hdrAdmin.Font, System.Drawing.FontStyle.Bold);
            cmsUsuarioConfig.Items.Add(hdrAdmin);
            cmsUsuarioConfig.Items.Add(mnuUsuarios);
            mnuRespaldo.Text = "⚠ Respaldo de Datos";
            cmsUsuarioConfig.Items.Add(mnuRespaldo);
            cmsUsuarioConfig.Items.Add(mnuLicencia);
            cmsUsuarioConfig.Items.Add(mnuReportes);
            cmsUsuarioConfig.Items.Add(new ToolStripSeparator());

            // Otros
            cmsUsuarioConfig.Items.Add(mnuPapelera);
        }

        // ─── Mostrar sección CONFIGURACIÓN en sidebar ──────────────────
        private void MostrarSeccionConfiguracion()
        {
            lblConfiguracion.Visible = true;
            btnUsuarios.Visible      = true;

        }

        // ─── Inactividad ───────────────────────────────────────────────
        private void InicializarInactividad()
        {
            // Leer timeout de ConfigGeneral
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = new System.Data.SQLite.SQLiteCommand(
                    "SELECT Valor FROM ConfigGeneral WHERE Clave='TIEMPO_INACTIVIDAD' LIMIT 1", conn))
                {
                    var v = cmd.ExecuteScalar()?.ToString();
                    if (int.TryParse(v, out int min) && min > 0)
                        _minutosInactividad = min;
                }
            }
            catch { }

            if (_minutosInactividad <= 0) return; // 0 = desactivado

            Application.AddMessageFilter(new InactividadFilter(this));

            _timerInactividad = new Timer { Interval = 30000 }; // verifica cada 30 seg
            _timerInactividad.Tick += TimerInactividad_Tick;
            _timerInactividad.Start();
        }

        internal void ResetearInactividad()
        {
            _ultimaActividad = DateTime.Now;
            _avisoMostrado = false;
        }

        private void TimerInactividad_Tick(object sender, EventArgs e)
        {
            double elapsed = (DateTime.Now - _ultimaActividad).TotalMinutes;
            double limite = _minutosInactividad;

            if (elapsed >= limite)
            {
                _timerInactividad.Stop();
                CerrarSesionPorInactividad();
                return;
            }

            if (!_avisoMostrado && elapsed >= limite - 2)
            {
                _avisoMostrado = true;
                var dlg = MessageBox.Show(
                    "Su sesión se cerrará en 2 minutos por inactividad.\n\n¿Desea continuar?",
                    "Aviso de inactividad",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dlg == DialogResult.Yes)
                {
                    ResetearInactividad();
                }
            }
        }

        private void CerrarSesionPorInactividad()
        {
            if (_timerInactividad != null) _timerInactividad.Stop();
            MessageBox.Show("Se cerró la sesión por inactividad.", "Sesión expirada",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            var login = new FormLogin();
            login.ShowDialog();
            this.Close();
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
                if (_timerInactividad != null) _timerInactividad.Stop();
                this.Hide();
                FormLogin login = new FormLogin();
                login.ShowDialog();
                this.Close();
            }
        }

        private void BtnContabilidad_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new SistemaPOS.Forms.Finanzas.FormContabilidad(), btnContabilidad);
        }

        // ─── Company Avatar Chip ─────────────────────────────────────────────

        private void CargarNombreEmpresa()
        {
            try
            {
                var emp = EmpresaRepository.ObtenerEmpresa();
                if (emp != null)
                {
                    string nombre = !string.IsNullOrWhiteSpace(emp.NombreComercial)
                        ? emp.NombreComercial
                        : (emp.RazonSocial ?? "Mi Empresa");
                    _empresaNombre  = nombre;
                    _empresaInicial = nombre.Trim().Length > 0
                        ? nombre.Trim()[0].ToString().ToUpper()
                        : "E";
                }
            }
            catch { }
            btnUsuarioConfig.Invalidate();
        }

        private void BtnUsuarioConfig_MouseEnter(object sender, EventArgs e)
        {
            _chipHovered = true;
            btnUsuarioConfig.Invalidate();
        }

        private void BtnUsuarioConfig_MouseLeave(object sender, EventArgs e)
        {
            _chipHovered = false;
            btnUsuarioConfig.Invalidate();
        }

        private void BtnUsuarioConfig_Paint(object sender, PaintEventArgs e)
        {
            var btn = (Button)sender;
            var g   = e.Graphics;
            g.SmoothingMode     = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            var rect   = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);
            int radius = btn.Height / 2;

            // ── Pill background ──────────────────────────────────────────────
            var bgColor = _chipHovered
                ? Color.FromArgb(224, 231, 255)   // indigo-100 en hover
                : Color.FromArgb(238, 242, 255);   // indigo-50 en reposo
            var borderColor = _chipHovered
                ? Color.FromArgb(99, 102, 241)     // indigo-500 en hover
                : Color.FromArgb(199, 210, 254);   // indigo-200 en reposo

            using (var path = ChipPath(rect, radius))
            {
                using (var bgBr = new SolidBrush(bgColor))
                    g.FillPath(bgBr, path);
                using (var pen = new Pen(borderColor, _chipHovered ? 1.5f : 1f))
                    g.DrawPath(pen, path);
            }

            // ── Avatar circle ────────────────────────────────────────────────
            const int circleSize = 24;
            int circleX = 6;
            int circleY = (btn.Height - circleSize) / 2;

            var circleColor = _chipHovered
                ? Color.FromArgb(79, 70, 229)   // indigo-600
                : Color.FromArgb(99, 102, 241);  // indigo-500

            using (var circleBr = new SolidBrush(circleColor))
                g.FillEllipse(circleBr, circleX, circleY, circleSize, circleSize);

            // Inicial centrada en el círculo
            using (var f  = new Font("Segoe UI", 9f, FontStyle.Bold))
            using (var br = new SolidBrush(Color.White))
            {
                var sf = new StringFormat
                {
                    Alignment     = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(_empresaInicial, f, br,
                    new RectangleF(circleX, circleY, circleSize, circleSize), sf);
            }

            // ── Nombre de la empresa ─────────────────────────────────────────
            string displayName = _empresaNombre;
            if (displayName.Length > 18) displayName = displayName.Substring(0, 16) + "…";

            var textColor = _chipHovered
                ? Color.FromArgb(67, 56, 202)   // indigo-700
                : Color.FromArgb(55, 48, 163);  // indigo-800

            float textX = circleX + circleSize + 7;
            float textW = btn.Width - textX - 20;

            using (var nameFt = new Font("Segoe UI", 8.5f, FontStyle.Regular))
            using (var nameBr = new SolidBrush(textColor))
            {
                var sf = new StringFormat { LineAlignment = StringAlignment.Center };
                g.DrawString(displayName, nameFt, nameBr,
                    new RectangleF(textX, 0, textW, btn.Height), sf);
            }

            // ── Chevron ▾ ────────────────────────────────────────────────────
            int cx = btn.Width - 14;
            int cy = btn.Height / 2;
            var chevronColor = _chipHovered
                ? Color.FromArgb(99, 102, 241)
                : Color.FromArgb(148, 160, 232);

            using (var pen = new Pen(chevronColor, 1.5f)
                { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
            {
                g.DrawLine(pen, cx - 4, cy - 2, cx, cy + 3);
                g.DrawLine(pen, cx,     cy + 3, cx + 4, cy - 2);
            }
        }

        private static GraphicsPath ChipPath(Rectangle rect, int radius)
        {
            int d = Math.Min(radius * 2, Math.Min(rect.Width, rect.Height));
            var path = new GraphicsPath();
            path.AddArc(rect.X,          rect.Y,          d, d, 180, 90);
            path.AddArc(rect.Right - d,  rect.Y,          d, d, 270, 90);
            path.AddArc(rect.Right - d,  rect.Bottom - d, d, d,   0, 90);
            path.AddArc(rect.X,          rect.Bottom - d, d, d,  90, 90);
            path.CloseFigure();
            return path;
        }

        /// <summary>Actualiza el nombre del chip tras guardar en FormEmpresa.</summary>
        public void ActualizarChipEmpresa() => CargarNombreEmpresa();
    }

    // ─── Filtro global de mensajes para detectar actividad ───────────
    internal class InactividadFilter : IMessageFilter
    {
        private readonly FormPrincipal _form;
        private const int WM_MOUSEMOVE   = 0x0200;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_KEYDOWN     = 0x0100;
        private const int WM_SYSKEYDOWN  = 0x0104;

        public InactividadFilter(FormPrincipal form) => _form = form;

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_MOUSEMOVE || m.Msg == WM_LBUTTONDOWN ||
                m.Msg == WM_KEYDOWN   || m.Msg == WM_SYSKEYDOWN)
            {
                _form.ResetearInactividad();
            }
            return false; // no consume el mensaje
        }
    }
}
