namespace SistemaPOS.Forms.Principal
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.cmsUsuarioConfig = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEmpresa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPresentaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUnidades = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImpresoras = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRespaldo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPapelera = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConciliacion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLicencia = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep = new System.Windows.Forms.ToolStripSeparator();
            this.mnuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUsuarioConfig = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnToggleMenu = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnBalanceGeneral = new System.Windows.Forms.Button();
            this.btnEstadoResultados = new System.Windows.Forms.Button();
            this.btnFlujoCaja = new System.Windows.Forms.Button();
            this.lblReportes = new System.Windows.Forms.Label();
            this.btnCuentasPagar = new System.Windows.Forms.Button();
            this.btnContabilidad = new System.Windows.Forms.Button();
            this.btnCobros = new System.Windows.Forms.Button();
            this.btnGastos = new System.Windows.Forms.Button();
            this.btnCaja = new System.Windows.Forms.Button();
            this.lblFinanzas = new System.Windows.Forms.Label();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.lblContactos = new System.Windows.Forms.Label();
            this.btnAjustes = new System.Windows.Forms.Button();
            this.btnKardex = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.lblInventario = new System.Windows.Forms.Label();
            this.btnHistorialCompras = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.btnHistorialVentas = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.lblOperaciones = new System.Windows.Forms.Label();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.btnEmpresa = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.lblConfiguracion = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlMenuBorder = new System.Windows.Forms.Panel();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.pnlStatusBorderTop = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblCaja = new System.Windows.Forms.Label();
            this.cmsUsuarioConfig.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsUsuarioConfig
            // 
            this.cmsUsuarioConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEmpresa,
            this.mnuUsuarios,
            this.mnuCategorias,
            this.mnuPresentaciones,
            this.mnuUnidades,
            this.mnuImpresoras,
            this.mnuRespaldo,
            this.mnuReportes,
            this.mnuGeneral,
            this.mnuPapelera,
            this.mnuConciliacion,
            this.mnuLicencia,
            this.mnuSep});
            this.cmsUsuarioConfig.Name = "cmsUsuarioConfig";
            this.cmsUsuarioConfig.Size = new System.Drawing.Size(181, 252);
            // 
            // mnuEmpresa
            // 
            this.mnuEmpresa.Name = "mnuEmpresa";
            this.mnuEmpresa.Size = new System.Drawing.Size(180, 22);
            this.mnuEmpresa.Text = "Empresa";
            this.mnuEmpresa.Click += new System.EventHandler(this.MnuEmpresa_Click);
            // 
            // mnuUsuarios
            // 
            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Size = new System.Drawing.Size(180, 22);
            this.mnuUsuarios.Text = "Usuarios";
            this.mnuUsuarios.Click += new System.EventHandler(this.MnuUsuarios_Click);
            // 
            // mnuCategorias
            // 
            this.mnuCategorias.Name = "mnuCategorias";
            this.mnuCategorias.Size = new System.Drawing.Size(180, 22);
            this.mnuCategorias.Text = "Categorias";
            this.mnuCategorias.Click += new System.EventHandler(this.MnuCategorias_Click);
            // 
            // mnuPresentaciones
            // 
            this.mnuPresentaciones.Name = "mnuPresentaciones";
            this.mnuPresentaciones.Size = new System.Drawing.Size(180, 22);
            this.mnuPresentaciones.Text = "Presentaciones";
            this.mnuPresentaciones.Click += new System.EventHandler(this.MnuPresentaciones_Click);
            // 
            // mnuUnidades
            // 
            this.mnuUnidades.Name = "mnuUnidades";
            this.mnuUnidades.Size = new System.Drawing.Size(180, 22);
            this.mnuUnidades.Text = "Unidades";
            this.mnuUnidades.Click += new System.EventHandler(this.MnuUnidades_Click);
            // 
            // mnuImpresoras
            // 
            this.mnuImpresoras.Name = "mnuImpresoras";
            this.mnuImpresoras.Size = new System.Drawing.Size(180, 22);
            this.mnuImpresoras.Text = "Impresoras";
            this.mnuImpresoras.Click += new System.EventHandler(this.MnuImpresoras_Click);
            // 
            // mnuRespaldo
            // 
            this.mnuRespaldo.Name = "mnuRespaldo";
            this.mnuRespaldo.Size = new System.Drawing.Size(180, 22);
            this.mnuRespaldo.Text = "Respaldo";
            this.mnuRespaldo.Click += new System.EventHandler(this.MnuRespaldo_Click);
            // 
            // mnuGeneral
            // 
            this.mnuGeneral.Name = "mnuGeneral";
            this.mnuGeneral.Size = new System.Drawing.Size(180, 22);
            this.mnuGeneral.Text = "General";
            this.mnuGeneral.Click += new System.EventHandler(this.MnuGeneral_Click);
            //
            // mnuPapelera
            //
            this.mnuPapelera.Name = "mnuPapelera";
            this.mnuPapelera.Size = new System.Drawing.Size(180, 22);
            this.mnuPapelera.Text = "Papelera";
            this.mnuPapelera.Click += new System.EventHandler(this.MnuPapelera_Click);
            //
            // mnuConciliacion
            //
            this.mnuConciliacion.Name = "mnuConciliacion";
            this.mnuConciliacion.Size = new System.Drawing.Size(180, 22);
            this.mnuConciliacion.Text = "Conciliación Inventario";
            this.mnuConciliacion.Click += new System.EventHandler(this.MnuConciliacion_Click);
            //
            // mnuLicencia
            //
            this.mnuLicencia.Name = "mnuLicencia";
            this.mnuLicencia.Size = new System.Drawing.Size(180, 22);
            this.mnuLicencia.Text = "Licencia";
            this.mnuLicencia.Click += new System.EventHandler(this.MnuLicencia_Click);
            // 
            // mnuSep
            // 
            this.mnuSep.Name = "mnuSep";
            this.mnuSep.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuReportes
            // 
            this.mnuReportes.Name = "mnuReportes";
            this.mnuReportes.Size = new System.Drawing.Size(180, 22);
            this.mnuReportes.Text = "Reportes";
            this.mnuReportes.Click += new System.EventHandler(this.MnuReportes_Click);
            // 
            // btnUsuarioConfig
            // 
            this.btnUsuarioConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUsuarioConfig.BackColor = System.Drawing.Color.White;
            this.btnUsuarioConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuarioConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(220)))));
            this.btnUsuarioConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnUsuarioConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarioConfig.Font = new System.Drawing.Font("Inter V", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarioConfig.ForeColor = System.Drawing.Color.Black;
            this.btnUsuarioConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarioConfig.Location = new System.Drawing.Point(1019, 7);
            this.btnUsuarioConfig.Name = "btnUsuarioConfig";
            this.btnUsuarioConfig.Size = new System.Drawing.Size(121, 25);
            this.btnUsuarioConfig.TabIndex = 4;
            this.btnUsuarioConfig.Text = "Mi Empresa  ▾";
            this.btnUsuarioConfig.UseVisualStyleBackColor = false;
            this.btnUsuarioConfig.Click += new System.EventHandler(this.BtnUsuarioConfig_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.Controls.Add(this.btnToggleMenu);
            this.pnlMenu.Controls.Add(this.btnCerrarSesion);
            this.pnlMenu.Controls.Add(this.btnReportes);
            this.pnlMenu.Controls.Add(this.btnBalanceGeneral);
            this.pnlMenu.Controls.Add(this.btnEstadoResultados);
            this.pnlMenu.Controls.Add(this.btnFlujoCaja);
            this.pnlMenu.Controls.Add(this.lblReportes);
            this.pnlMenu.Controls.Add(this.btnContabilidad);
            this.pnlMenu.Controls.Add(this.btnCuentasPagar);
            this.pnlMenu.Controls.Add(this.btnCobros);
            this.pnlMenu.Controls.Add(this.btnGastos);
            this.pnlMenu.Controls.Add(this.btnCaja);
            this.pnlMenu.Controls.Add(this.lblFinanzas);
            this.pnlMenu.Controls.Add(this.btnProveedores);
            this.pnlMenu.Controls.Add(this.btnClientes);
            this.pnlMenu.Controls.Add(this.lblContactos);
            this.pnlMenu.Controls.Add(this.btnAjustes);
            this.pnlMenu.Controls.Add(this.btnKardex);
            this.pnlMenu.Controls.Add(this.btnProductos);
            this.pnlMenu.Controls.Add(this.lblInventario);
            this.pnlMenu.Controls.Add(this.btnHistorialCompras);
            this.pnlMenu.Controls.Add(this.btnCompras);
            this.pnlMenu.Controls.Add(this.btnHistorialVentas);
            this.pnlMenu.Controls.Add(this.btnVentas);
            this.pnlMenu.Controls.Add(this.lblOperaciones);
            this.pnlMenu.Controls.Add(this.btnDashboard);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(250, 1034);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnToggleMenu
            // 
            this.btnToggleMenu.BackColor = System.Drawing.Color.White;
            this.btnToggleMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleMenu.FlatAppearance.BorderSize = 0;
            this.btnToggleMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnToggleMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleMenu.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnToggleMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnToggleMenu.Location = new System.Drawing.Point(12, 4);
            this.btnToggleMenu.Name = "btnToggleMenu";
            this.btnToggleMenu.Size = new System.Drawing.Size(40, 40);
            this.btnToggleMenu.TabIndex = 28;
            this.btnToggleMenu.Text = "☰";
            this.btnToggleMenu.UseVisualStyleBackColor = false;
            this.btnToggleMenu.Click += new System.EventHandler(this.BtnToggleMenu_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.DimGray;
            this.btnCerrarSesion.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_Cerrar_hover;
            this.btnCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 994);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnCerrarSesion.Size = new System.Drawing.Size(250, 40);
            this.btnCerrarSesion.TabIndex = 27;
            this.btnCerrarSesion.Text = "       Cerrar Sesion";
            this.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesion_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.White;
            this.btnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.Black;
            this.btnReportes.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_ReportesGenerales;
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.Location = new System.Drawing.Point(0, 840);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnReportes.Size = new System.Drawing.Size(250, 35);
            this.btnReportes.TabIndex = 22;
            this.btnReportes.Text = "       Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.BtnReportes_Click);
            // 
            // btnBalanceGeneral
            // 
            this.btnBalanceGeneral.BackColor = System.Drawing.Color.White;
            this.btnBalanceGeneral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBalanceGeneral.FlatAppearance.BorderSize = 0;
            this.btnBalanceGeneral.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnBalanceGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBalanceGeneral.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBalanceGeneral.ForeColor = System.Drawing.Color.Black;
            this.btnBalanceGeneral.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_BalanceGeneral;
            this.btnBalanceGeneral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBalanceGeneral.Location = new System.Drawing.Point(0, 801);
            this.btnBalanceGeneral.Name = "btnBalanceGeneral";
            this.btnBalanceGeneral.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnBalanceGeneral.Size = new System.Drawing.Size(250, 35);
            this.btnBalanceGeneral.TabIndex = 21;
            this.btnBalanceGeneral.Text = "       Balance";
            this.btnBalanceGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBalanceGeneral.UseVisualStyleBackColor = false;
            this.btnBalanceGeneral.Click += new System.EventHandler(this.BtnBalanceGeneral_Click);
            // 
            // btnEstadoResultados
            // 
            this.btnEstadoResultados.BackColor = System.Drawing.Color.White;
            this.btnEstadoResultados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstadoResultados.FlatAppearance.BorderSize = 0;
            this.btnEstadoResultados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnEstadoResultados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadoResultados.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadoResultados.ForeColor = System.Drawing.Color.Black;
            this.btnEstadoResultados.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_EstadoDeResultado;
            this.btnEstadoResultados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstadoResultados.Location = new System.Drawing.Point(0, 762);
            this.btnEstadoResultados.Name = "btnEstadoResultados";
            this.btnEstadoResultados.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnEstadoResultados.Size = new System.Drawing.Size(250, 35);
            this.btnEstadoResultados.TabIndex = 20;
            this.btnEstadoResultados.Text = "       Resultados";
            this.btnEstadoResultados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstadoResultados.UseVisualStyleBackColor = false;
            this.btnEstadoResultados.Click += new System.EventHandler(this.BtnEstadoResultados_Click);
            // 
            // btnFlujoCaja
            // 
            this.btnFlujoCaja.BackColor = System.Drawing.Color.White;
            this.btnFlujoCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFlujoCaja.FlatAppearance.BorderSize = 0;
            this.btnFlujoCaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnFlujoCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlujoCaja.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFlujoCaja.ForeColor = System.Drawing.Color.Black;
            this.btnFlujoCaja.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_FlujoDeCaja;
            this.btnFlujoCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFlujoCaja.Location = new System.Drawing.Point(0, 723);
            this.btnFlujoCaja.Name = "btnFlujoCaja";
            this.btnFlujoCaja.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnFlujoCaja.Size = new System.Drawing.Size(250, 35);
            this.btnFlujoCaja.TabIndex = 19;
            this.btnFlujoCaja.Text = "       Flujo";
            this.btnFlujoCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFlujoCaja.UseVisualStyleBackColor = false;
            this.btnFlujoCaja.Click += new System.EventHandler(this.BtnFlujoCaja_Click);
            // 
            // lblReportes
            // 
            this.lblReportes.AutoSize = true;
            this.lblReportes.Font = new System.Drawing.Font("Inter V Semi Bold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportes.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblReportes.Location = new System.Drawing.Point(15, 705);
            this.lblReportes.Name = "lblReportes";
            this.lblReportes.Size = new System.Drawing.Size(66, 14);
            this.lblReportes.TabIndex = 18;
            this.lblReportes.Text = "ANALITICA";
            // 
            // btnCuentasPagar
            // 
            this.btnCuentasPagar.BackColor = System.Drawing.Color.White;
            this.btnCuentasPagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCuentasPagar.FlatAppearance.BorderSize = 0;
            this.btnCuentasPagar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnCuentasPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCuentasPagar.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCuentasPagar.ForeColor = System.Drawing.Color.Black;
            this.btnCuentasPagar.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_CuentasPorPagar;
            this.btnCuentasPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCuentasPagar.Location = new System.Drawing.Point(0, 627);
            this.btnCuentasPagar.Name = "btnCuentasPagar";
            this.btnCuentasPagar.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnCuentasPagar.Size = new System.Drawing.Size(250, 35);
            this.btnCuentasPagar.TabIndex = 17;
            this.btnCuentasPagar.Text = "       Cuentas por Pagar";
            this.btnCuentasPagar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCuentasPagar.UseVisualStyleBackColor = false;
            this.btnCuentasPagar.Click += new System.EventHandler(this.BtnCuentasPagar_Click);
            //
            // btnContabilidad
            //
            this.btnContabilidad.BackColor = System.Drawing.Color.White;
            this.btnContabilidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContabilidad.FlatAppearance.BorderSize = 0;
            this.btnContabilidad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnContabilidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContabilidad.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContabilidad.ForeColor = System.Drawing.Color.Black;
            this.btnContabilidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContabilidad.Location = new System.Drawing.Point(0, 662);
            this.btnContabilidad.Name = "btnContabilidad";
            this.btnContabilidad.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnContabilidad.Size = new System.Drawing.Size(250, 35);
            this.btnContabilidad.TabIndex = 29;
            this.btnContabilidad.Text = "       Contabilidad";
            this.btnContabilidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContabilidad.UseVisualStyleBackColor = false;
            this.btnContabilidad.Click += new System.EventHandler(this.BtnContabilidad_Click);
            //
            // btnCobros
            //
            this.btnCobros.BackColor = System.Drawing.Color.White;
            this.btnCobros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCobros.FlatAppearance.BorderSize = 0;
            this.btnCobros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnCobros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCobros.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobros.ForeColor = System.Drawing.Color.Black;
            this.btnCobros.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_LibroDiario;
            this.btnCobros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCobros.Location = new System.Drawing.Point(0, 588);
            this.btnCobros.Name = "btnCobros";
            this.btnCobros.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnCobros.Size = new System.Drawing.Size(250, 35);
            this.btnCobros.TabIndex = 16;
            this.btnCobros.Text = "       Cobros";
            this.btnCobros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCobros.UseVisualStyleBackColor = false;
            this.btnCobros.Click += new System.EventHandler(this.BtnCobros_Click);
            // 
            // btnGastos
            // 
            this.btnGastos.BackColor = System.Drawing.Color.White;
            this.btnGastos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGastos.FlatAppearance.BorderSize = 0;
            this.btnGastos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnGastos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGastos.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGastos.ForeColor = System.Drawing.Color.Black;
            this.btnGastos.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_Gastos;
            this.btnGastos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGastos.Location = new System.Drawing.Point(0, 549);
            this.btnGastos.Name = "btnGastos";
            this.btnGastos.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnGastos.Size = new System.Drawing.Size(250, 35);
            this.btnGastos.TabIndex = 15;
            this.btnGastos.Text = "       Gastos Operativos";
            this.btnGastos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGastos.UseVisualStyleBackColor = false;
            this.btnGastos.Click += new System.EventHandler(this.BtnGastos_Click);
            // 
            // btnCaja
            // 
            this.btnCaja.BackColor = System.Drawing.Color.White;
            this.btnCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCaja.FlatAppearance.BorderSize = 0;
            this.btnCaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaja.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaja.ForeColor = System.Drawing.Color.Black;
            this.btnCaja.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_Caja;
            this.btnCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaja.Location = new System.Drawing.Point(0, 510);
            this.btnCaja.Name = "btnCaja";
            this.btnCaja.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnCaja.Size = new System.Drawing.Size(250, 35);
            this.btnCaja.TabIndex = 14;
            this.btnCaja.Text = "       Caja y Turnos";
            this.btnCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaja.UseVisualStyleBackColor = false;
            this.btnCaja.Click += new System.EventHandler(this.BtnCaja_Click);
            // 
            // lblFinanzas
            // 
            this.lblFinanzas.AutoSize = true;
            this.lblFinanzas.Font = new System.Drawing.Font("Inter V Semi Bold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinanzas.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblFinanzas.Location = new System.Drawing.Point(15, 492);
            this.lblFinanzas.Name = "lblFinanzas";
            this.lblFinanzas.Size = new System.Drawing.Size(106, 14);
            this.lblFinanzas.TabIndex = 13;
            this.lblFinanzas.Text = "CAJA Y FINANZAS";
            // 
            // btnProveedores
            // 
            this.btnProveedores.BackColor = System.Drawing.Color.White;
            this.btnProveedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProveedores.FlatAppearance.BorderSize = 0;
            this.btnProveedores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedores.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedores.ForeColor = System.Drawing.Color.Black;
            this.btnProveedores.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_Proveedores;
            this.btnProveedores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProveedores.Location = new System.Drawing.Point(0, 453);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnProveedores.Size = new System.Drawing.Size(250, 35);
            this.btnProveedores.TabIndex = 12;
            this.btnProveedores.Text = "       Proveedores";
            this.btnProveedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProveedores.UseVisualStyleBackColor = false;
            this.btnProveedores.Click += new System.EventHandler(this.BtnProveedores_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.White;
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.Black;
            this.btnClientes.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_Clientes;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(0, 414);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnClientes.Size = new System.Drawing.Size(250, 35);
            this.btnClientes.TabIndex = 11;
            this.btnClientes.Text = "       Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.BtnClientes_Click);
            // 
            // lblContactos
            // 
            this.lblContactos.AutoSize = true;
            this.lblContactos.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblContactos.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblContactos.Location = new System.Drawing.Point(15, 397);
            this.lblContactos.Name = "lblContactos";
            this.lblContactos.Size = new System.Drawing.Size(73, 13);
            this.lblContactos.TabIndex = 10;
            this.lblContactos.Text = "RELACIONES";
            // 
            // btnAjustes
            // 
            this.btnAjustes.BackColor = System.Drawing.Color.White;
            this.btnAjustes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAjustes.FlatAppearance.BorderSize = 0;
            this.btnAjustes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnAjustes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjustes.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjustes.ForeColor = System.Drawing.Color.Black;
            this.btnAjustes.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_Ajustes;
            this.btnAjustes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAjustes.Location = new System.Drawing.Point(0, 358);
            this.btnAjustes.Name = "btnAjustes";
            this.btnAjustes.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnAjustes.Size = new System.Drawing.Size(250, 35);
            this.btnAjustes.TabIndex = 9;
            this.btnAjustes.Text = "       Ajustes de Inventario";
            this.btnAjustes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAjustes.UseVisualStyleBackColor = false;
            this.btnAjustes.Click += new System.EventHandler(this.BtnAjustes_Click);
            // 
            // btnKardex
            // 
            this.btnKardex.BackColor = System.Drawing.Color.White;
            this.btnKardex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKardex.FlatAppearance.BorderSize = 0;
            this.btnKardex.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnKardex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKardex.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKardex.ForeColor = System.Drawing.Color.Black;
            this.btnKardex.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_AlertaStock;
            this.btnKardex.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKardex.Location = new System.Drawing.Point(0, 319);
            this.btnKardex.Name = "btnKardex";
            this.btnKardex.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnKardex.Size = new System.Drawing.Size(250, 35);
            this.btnKardex.TabIndex = 8;
            this.btnKardex.Text = "       Kardex";
            this.btnKardex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKardex.UseVisualStyleBackColor = false;
            this.btnKardex.Click += new System.EventHandler(this.BtnKardex_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.White;
            this.btnProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.Black;
            this.btnProductos.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_Productos;
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Location = new System.Drawing.Point(0, 280);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnProductos.Size = new System.Drawing.Size(250, 35);
            this.btnProductos.TabIndex = 7;
            this.btnProductos.Text = "       Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.BtnProductos_Click);
            // 
            // lblInventario
            // 
            this.lblInventario.AutoSize = true;
            this.lblInventario.Font = new System.Drawing.Font("Inter V Semi Bold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventario.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblInventario.Location = new System.Drawing.Point(15, 262);
            this.lblInventario.Name = "lblInventario";
            this.lblInventario.Size = new System.Drawing.Size(74, 14);
            this.lblInventario.TabIndex = 6;
            this.lblInventario.Text = "INVENTARIO";
            // 
            // btnHistorialCompras
            // 
            this.btnHistorialCompras.BackColor = System.Drawing.Color.White;
            this.btnHistorialCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorialCompras.FlatAppearance.BorderSize = 0;
            this.btnHistorialCompras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnHistorialCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorialCompras.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorialCompras.ForeColor = System.Drawing.Color.Black;
            this.btnHistorialCompras.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_HistorialCompras;
            this.btnHistorialCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistorialCompras.Location = new System.Drawing.Point(0, 223);
            this.btnHistorialCompras.Name = "btnHistorialCompras";
            this.btnHistorialCompras.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnHistorialCompras.Size = new System.Drawing.Size(250, 35);
            this.btnHistorialCompras.TabIndex = 5;
            this.btnHistorialCompras.Text = "       Historial de Compras";
            this.btnHistorialCompras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistorialCompras.UseVisualStyleBackColor = false;
            this.btnHistorialCompras.Click += new System.EventHandler(this.BtnHistorialCompras_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.BackColor = System.Drawing.Color.White;
            this.btnCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompras.FlatAppearance.BorderSize = 0;
            this.btnCompras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompras.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompras.ForeColor = System.Drawing.Color.Black;
            this.btnCompras.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_Compras;
            this.btnCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompras.Location = new System.Drawing.Point(0, 184);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnCompras.Size = new System.Drawing.Size(250, 35);
            this.btnCompras.TabIndex = 4;
            this.btnCompras.Text = "       Compras";
            this.btnCompras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompras.UseVisualStyleBackColor = false;
            this.btnCompras.Click += new System.EventHandler(this.BtnCompras_Click);
            // 
            // btnHistorialVentas
            // 
            this.btnHistorialVentas.BackColor = System.Drawing.Color.White;
            this.btnHistorialVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorialVentas.FlatAppearance.BorderSize = 0;
            this.btnHistorialVentas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnHistorialVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorialVentas.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorialVentas.ForeColor = System.Drawing.Color.Black;
            this.btnHistorialVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnHistorialVentas.Image")));
            this.btnHistorialVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistorialVentas.Location = new System.Drawing.Point(0, 145);
            this.btnHistorialVentas.Name = "btnHistorialVentas";
            this.btnHistorialVentas.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnHistorialVentas.Size = new System.Drawing.Size(250, 35);
            this.btnHistorialVentas.TabIndex = 3;
            this.btnHistorialVentas.Text = "       Historial de Ventas";
            this.btnHistorialVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistorialVentas.UseVisualStyleBackColor = false;
            this.btnHistorialVentas.Click += new System.EventHandler(this.BtnHistorialVentas_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.Color.White;
            this.btnVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.ForeColor = System.Drawing.Color.Black;
            this.btnVentas.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_Ventas;
            this.btnVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.Location = new System.Drawing.Point(0, 106);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnVentas.Size = new System.Drawing.Size(250, 35);
            this.btnVentas.TabIndex = 2;
            this.btnVentas.Text = "       Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.UseVisualStyleBackColor = false;
            this.btnVentas.Click += new System.EventHandler(this.BtnVentas_Click);
            // 
            // lblOperaciones
            // 
            this.lblOperaciones.AutoSize = true;
            this.lblOperaciones.Font = new System.Drawing.Font("Inter V Semi Bold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperaciones.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblOperaciones.Location = new System.Drawing.Point(15, 88);
            this.lblOperaciones.Name = "lblOperaciones";
            this.lblOperaciones.Size = new System.Drawing.Size(51, 14);
            this.lblOperaciones.TabIndex = 1;
            this.lblOperaciones.Text = "VENTAS";
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.White;
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Inter V Semi Bold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.Black;
            this.btnDashboard.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_Dashboard;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 47);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(251, 35);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "         Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.BtnDashboard_Click);
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.BackColor = System.Drawing.Color.White;
            this.btnConfiguracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfiguracion.FlatAppearance.BorderSize = 0;
            this.btnConfiguracion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnConfiguracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracion.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracion.ForeColor = System.Drawing.Color.Black;
            this.btnConfiguracion.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_Configuracion;
            this.btnConfiguracion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracion.Location = new System.Drawing.Point(0, 936);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnConfiguracion.Size = new System.Drawing.Size(250, 35);
            this.btnConfiguracion.TabIndex = 26;
            this.btnConfiguracion.Text = "       Configuracion del Sistema";
            this.btnConfiguracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracion.UseVisualStyleBackColor = false;
            this.btnConfiguracion.Click += new System.EventHandler(this.BtnConfiguracion_Click);
            // 
            // btnEmpresa
            // 
            this.btnEmpresa.BackColor = System.Drawing.Color.White;
            this.btnEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmpresa.FlatAppearance.BorderSize = 0;
            this.btnEmpresa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpresa.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpresa.ForeColor = System.Drawing.Color.Black;
            this.btnEmpresa.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_Empresa;
            this.btnEmpresa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpresa.Location = new System.Drawing.Point(0, 897);
            this.btnEmpresa.Name = "btnEmpresa";
            this.btnEmpresa.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnEmpresa.Size = new System.Drawing.Size(250, 35);
            this.btnEmpresa.TabIndex = 25;
            this.btnEmpresa.Text = "       Empresa";
            this.btnEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpresa.UseVisualStyleBackColor = false;
            this.btnEmpresa.Click += new System.EventHandler(this.BtnEmpresa_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.White;
            this.btnUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Inter V", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.Black;
            this.btnUsuarios.Image = global::SistemaPOS.Properties.Resources.Icono_Boton_Usuarios;
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(0, 858);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnUsuarios.Size = new System.Drawing.Size(250, 35);
            this.btnUsuarios.TabIndex = 24;
            this.btnUsuarios.Text = "       Usuarios y Roles";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.BtnUsuarios_Click);
            // 
            // lblConfiguracion
            // 
            this.lblConfiguracion.AutoSize = true;
            this.lblConfiguracion.Font = new System.Drawing.Font("Inter V Semi Bold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfiguracion.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblConfiguracion.Location = new System.Drawing.Point(15, 840);
            this.lblConfiguracion.Name = "lblConfiguracion";
            this.lblConfiguracion.Size = new System.Drawing.Size(104, 14);
            this.lblConfiguracion.TabIndex = 23;
            this.lblConfiguracion.Text = "ADMINISTRACION";
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnUsuarioConfig);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(250, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1150, 40);
            this.pnlTop.TabIndex = 30;
            // 
            // pnlMenuBorder
            // 
            this.pnlMenuBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlMenuBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.pnlMenuBorder.Location = new System.Drawing.Point(250, 0);
            this.pnlMenuBorder.Name = "pnlMenuBorder";
            this.pnlMenuBorder.Size = new System.Drawing.Size(1, 1034);
            this.pnlMenuBorder.TabIndex = 29;
            // 
            // pnlContenido
            // 
            this.pnlContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.pnlContenido.Location = new System.Drawing.Point(251, 40);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1149, 964);
            this.pnlContenido.TabIndex = 1;
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.White;
            this.pnlStatus.Controls.Add(this.pnlStatusBorderTop);
            this.pnlStatus.Controls.Add(this.lblFecha);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Location = new System.Drawing.Point(250, 1004);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(1150, 30);
            this.pnlStatus.TabIndex = 2;
            // 
            // pnlStatusBorderTop
            // 
            this.pnlStatusBorderTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.pnlStatusBorderTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatusBorderTop.Location = new System.Drawing.Point(0, 0);
            this.pnlStatusBorderTop.Name = "pnlStatusBorderTop";
            this.pnlStatusBorderTop.Size = new System.Drawing.Size(1150, 1);
            this.pnlStatusBorderTop.TabIndex = 3;
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Inter V", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblFecha.Location = new System.Drawing.Point(964, 8);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(45, 15);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Inter V", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblUsuario.Location = new System.Drawing.Point(470, 8);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(53, 15);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario:";
            this.lblUsuario.Visible = false;
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Font = new System.Drawing.Font("Inter V", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblCaja.Location = new System.Drawing.Point(10, 8);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(36, 15);
            this.lblCaja.TabIndex = 0;
            this.lblCaja.Text = "Caja:";
            this.lblCaja.Visible = false;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1400, 1034);
            this.Controls.Add(this.pnlMenuBorder);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlMenu);
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema POS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.cmsUsuarioConfig.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Panel pnlStatusBorderTop;
        private System.Windows.Forms.Panel pnlMenuBorder;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button btnToggleMenu;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Label lblOperaciones;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnHistorialVentas;
        private System.Windows.Forms.Button btnCompras;
        private System.Windows.Forms.Button btnHistorialCompras;
        private System.Windows.Forms.Label lblInventario;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnKardex;
        private System.Windows.Forms.Button btnAjustes;
        private System.Windows.Forms.Label lblContactos;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Label lblFinanzas;
        private System.Windows.Forms.Button btnCaja;
        private System.Windows.Forms.Button btnGastos;
        private System.Windows.Forms.Button btnCobros;
        private System.Windows.Forms.Button btnCuentasPagar;
        private System.Windows.Forms.Button btnContabilidad;
        private System.Windows.Forms.Label lblReportes;
        private System.Windows.Forms.Button btnFlujoCaja;
        private System.Windows.Forms.Button btnEstadoResultados;
        private System.Windows.Forms.Button btnBalanceGeneral;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Label lblConfiguracion;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnEmpresa;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.ContextMenuStrip cmsUsuarioConfig;
        private System.Windows.Forms.ToolStripMenuItem mnuEmpresa;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuCategorias;
        private System.Windows.Forms.ToolStripMenuItem mnuPresentaciones;
        private System.Windows.Forms.ToolStripMenuItem mnuUnidades;
        private System.Windows.Forms.ToolStripMenuItem mnuImpresoras;
        private System.Windows.Forms.ToolStripMenuItem mnuRespaldo;
        private System.Windows.Forms.ToolStripMenuItem mnuGeneral;
        private System.Windows.Forms.ToolStripMenuItem mnuPapelera;
        private System.Windows.Forms.ToolStripMenuItem mnuConciliacion;
        private System.Windows.Forms.ToolStripMenuItem mnuLicencia;
        private System.Windows.Forms.ToolStripSeparator mnuSep;
        private System.Windows.Forms.ToolStripMenuItem mnuReportes;
        private System.Windows.Forms.Button btnUsuarioConfig;
        private System.Windows.Forms.Panel pnlTop;
    }
}
