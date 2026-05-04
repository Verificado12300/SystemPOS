namespace SistemaPOS.Forms.Configuracion
{
    partial class FormUsuarios
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // ── Header ───────────────────────────────────────────────────────
            this.pnlHeader      = new System.Windows.Forms.Panel();
            this.pnlHeaderAccent = new System.Windows.Forms.Panel();
            this.lblTitulo      = new System.Windows.Forms.Label();
            this.lblHeaderSub   = new System.Windows.Forms.Label();

            // ── Stats ────────────────────────────────────────────────────────
            this.pnlStats      = new System.Windows.Forms.Panel();
            this.pnlCard1      = new System.Windows.Forms.Panel();
            this.pnlAccent1    = new System.Windows.Forms.Panel();
            this.lblCardVal1   = new System.Windows.Forms.Label();
            this.lblCardTitle1 = new System.Windows.Forms.Label();
            this.pnlCard2      = new System.Windows.Forms.Panel();
            this.pnlAccent2    = new System.Windows.Forms.Panel();
            this.lblCardVal2   = new System.Windows.Forms.Label();
            this.lblCardTitle2 = new System.Windows.Forms.Label();
            this.pnlCard3      = new System.Windows.Forms.Panel();
            this.pnlAccent3    = new System.Windows.Forms.Panel();
            this.lblCardVal3   = new System.Windows.Forms.Label();
            this.lblCardTitle3 = new System.Windows.Forms.Label();

            // ── Form panel (izquierda) ────────────────────────────────────────
            this.pnlForm        = new System.Windows.Forms.Panel();
            this.pnlFormHeader  = new System.Windows.Forms.Panel();
            this.pnlFormAccent  = new System.Windows.Forms.Panel();
            this.lblFormTitle   = new System.Windows.Forms.Label();
            this.pnlFormFields  = new System.Windows.Forms.Panel();

            // Datos básicos
            this.lblNombreCompletoLbl = new System.Windows.Forms.Label();
            this.txtNombreCompleto    = new System.Windows.Forms.TextBox();
            this.pnlLineNombre        = new System.Windows.Forms.Panel();
            this.lblUsuarioLbl        = new System.Windows.Forms.Label();
            this.txtUsuario           = new System.Windows.Forms.TextBox();
            this.pnlLineUsuarioCampo  = new System.Windows.Forms.Panel();
            this.lblContraLbl         = new System.Windows.Forms.Label();
            this.txtContraseña        = new System.Windows.Forms.TextBox();
            this.btnMostrarClave      = new System.Windows.Forms.Button();
            this.pnlLineContra        = new System.Windows.Forms.Panel();
            this.lblRolLbl            = new System.Windows.Forms.Label();
            this.cmbRol               = new System.Windows.Forms.ComboBox();
            this.lblActivoLbl         = new System.Windows.Forms.Label();
            this.chkUsuarioActivo     = new System.Windows.Forms.CheckBox();
            this.lblEmailLbl          = new System.Windows.Forms.Label();
            this.txtEmail             = new System.Windows.Forms.TextBox();
            this.pnlLineEmail         = new System.Windows.Forms.Panel();
            this.lblTelefonoLbl       = new System.Windows.Forms.Label();
            this.txtTelefono          = new System.Windows.Forms.TextBox();
            this.pnlLineTelefono      = new System.Windows.Forms.Panel();

            // Sección módulos
            this.lblSeccionModulos    = new System.Windows.Forms.Label();
            this.pnlPermisosModulos   = new System.Windows.Forms.Panel();
            this.chkVentas            = new System.Windows.Forms.CheckBox();
            this.chkClientes          = new System.Windows.Forms.CheckBox();
            this.chkCompras           = new System.Windows.Forms.CheckBox();
            this.chkInventario        = new System.Windows.Forms.CheckBox();
            this.chkReportes          = new System.Windows.Forms.CheckBox();
            this.chkConfiguracion     = new System.Windows.Forms.CheckBox();
            this.chkProveedores       = new System.Windows.Forms.CheckBox();
            this.chkFinanzas          = new System.Windows.Forms.CheckBox();

            // Sección acciones especiales
            this.lblSeccionAcciones   = new System.Windows.Forms.Label();
            this.pnlAccionesWrap      = new System.Windows.Forms.Panel();
            this.chkAplicarDescuentos = new System.Windows.Forms.CheckBox();
            this.chkAnularVentas      = new System.Windows.Forms.CheckBox();
            this.chkEliminarRegistros = new System.Windows.Forms.CheckBox();
            this.chkVerCostos         = new System.Windows.Forms.CheckBox();
            this.chkModificarPrecios  = new System.Windows.Forms.CheckBox();
            this.chkAccederFueraHorario = new System.Windows.Forms.CheckBox();

            // Botones
            this.pnlFormButtons = new System.Windows.Forms.Panel();
            this.btnGuardar     = new System.Windows.Forms.Button();
            this.btnCancelar    = new System.Windows.Forms.Button();
            this.btnNuevo       = new System.Windows.Forms.Button();

            // ── Separador ────────────────────────────────────────────────────
            this.pnlSep = new System.Windows.Forms.Panel();

            // ── Lista (derecha) ───────────────────────────────────────────────
            this.pnlListArea   = new System.Windows.Forms.Panel();
            this.pnlToolbar    = new System.Windows.Forms.Panel();
            this.lblBuscarLbl  = new System.Windows.Forms.Label();
            this.txtBuscar     = new System.Windows.Forms.TextBox();
            this.pnlGridWrap   = new System.Windows.Forms.Panel();
            this.dgvUsuarios   = new System.Windows.Forms.DataGridView();
            this.colNumero     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRol        = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar     = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEliminar   = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlResumen    = new System.Windows.Forms.Panel();
            this.lblMostrar    = new System.Windows.Forms.Label();

            // ── Suspend ───────────────────────────────────────────────────────
            this.pnlHeader.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlFormHeader.SuspendLayout();
            this.pnlFormFields.SuspendLayout();
            this.pnlFormButtons.SuspendLayout();
            this.pnlPermisosModulos.SuspendLayout();
            this.pnlAccionesWrap.SuspendLayout();
            this.pnlListArea.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlGridWrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvUsuarios).BeginInit();
            this.pnlResumen.SuspendLayout();
            this.SuspendLayout();

            // ════════════════════════════════════════════════════════════════
            // pnlHeader  —  blanco + franja indigo 5px arriba
            // ════════════════════════════════════════════════════════════════
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 72;
            this.pnlHeader.TabIndex  = 100;

            this.pnlHeaderAccent.BackColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.pnlHeaderAccent.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderAccent.Height    = 5;
            this.pnlHeaderAccent.Name      = "pnlHeaderAccent";
            this.pnlHeaderAccent.TabIndex  = 0;

            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitulo.Location  = new System.Drawing.Point(22, 14);
            this.lblTitulo.Text      = "Gestión de Usuarios";
            this.lblTitulo.TabIndex  = 1;

            this.lblHeaderSub.AutoSize  = true;
            this.lblHeaderSub.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHeaderSub.Location  = new System.Drawing.Point(22, 44);
            this.lblHeaderSub.Text      = "Administra usuarios, roles y permisos del sistema";
            this.lblHeaderSub.TabIndex  = 2;

            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.pnlHeaderAccent);

            // ════════════════════════════════════════════════════════════════
            // pnlStats  —  3 tarjetas de métricas
            // ════════════════════════════════════════════════════════════════
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlStats.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Height    = 88;
            this.pnlStats.TabIndex  = 101;

            this.pnlAccent1.BackColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.pnlAccent1.Location  = new System.Drawing.Point(0, 0);
            this.pnlAccent1.Size      = new System.Drawing.Size(5, 64);
            this.lblCardVal1.AutoSize  = false;
            this.lblCardVal1.Location  = new System.Drawing.Point(18, 8);
            this.lblCardVal1.Size      = new System.Drawing.Size(332, 30);
            this.lblCardVal1.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCardVal1.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblCardVal1.Text      = "0";
            this.lblCardTitle1.AutoSize  = false;
            this.lblCardTitle1.Location  = new System.Drawing.Point(18, 40);
            this.lblCardTitle1.Size      = new System.Drawing.Size(332, 16);
            this.lblCardTitle1.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle1.ForeColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.lblCardTitle1.Text      = "TOTAL USUARIOS";
            this.pnlCard1.BackColor   = System.Drawing.Color.White;
            this.pnlCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard1.Location    = new System.Drawing.Point(16, 12);
            this.pnlCard1.Size        = new System.Drawing.Size(356, 64);
            this.pnlCard1.Controls.Add(this.lblCardTitle1);
            this.pnlCard1.Controls.Add(this.lblCardVal1);
            this.pnlCard1.Controls.Add(this.pnlAccent1);

            this.pnlAccent2.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.pnlAccent2.Location  = new System.Drawing.Point(0, 0);
            this.pnlAccent2.Size      = new System.Drawing.Size(5, 64);
            this.lblCardVal2.AutoSize  = false;
            this.lblCardVal2.Location  = new System.Drawing.Point(18, 8);
            this.lblCardVal2.Size      = new System.Drawing.Size(332, 30);
            this.lblCardVal2.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCardVal2.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblCardVal2.Text      = "0";
            this.lblCardTitle2.AutoSize  = false;
            this.lblCardTitle2.Location  = new System.Drawing.Point(18, 40);
            this.lblCardTitle2.Size      = new System.Drawing.Size(332, 16);
            this.lblCardTitle2.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle2.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblCardTitle2.Text      = "ACTIVOS";
            this.pnlCard2.BackColor   = System.Drawing.Color.White;
            this.pnlCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard2.Location    = new System.Drawing.Point(388, 12);
            this.pnlCard2.Size        = new System.Drawing.Size(356, 64);
            this.pnlCard2.Controls.Add(this.lblCardTitle2);
            this.pnlCard2.Controls.Add(this.lblCardVal2);
            this.pnlCard2.Controls.Add(this.pnlAccent2);

            this.pnlAccent3.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.pnlAccent3.Location  = new System.Drawing.Point(0, 0);
            this.pnlAccent3.Size      = new System.Drawing.Size(5, 64);
            this.lblCardVal3.AutoSize  = false;
            this.lblCardVal3.Location  = new System.Drawing.Point(18, 8);
            this.lblCardVal3.Size      = new System.Drawing.Size(332, 30);
            this.lblCardVal3.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCardVal3.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblCardVal3.Text      = "0";
            this.lblCardTitle3.AutoSize  = false;
            this.lblCardTitle3.Location  = new System.Drawing.Point(18, 40);
            this.lblCardTitle3.Size      = new System.Drawing.Size(332, 16);
            this.lblCardTitle3.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle3.ForeColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.lblCardTitle3.Text      = "ADMINISTRADORES";
            this.pnlCard3.BackColor   = System.Drawing.Color.White;
            this.pnlCard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard3.Location    = new System.Drawing.Point(760, 12);
            this.pnlCard3.Size        = new System.Drawing.Size(356, 64);
            this.pnlCard3.Controls.Add(this.lblCardTitle3);
            this.pnlCard3.Controls.Add(this.lblCardVal3);
            this.pnlCard3.Controls.Add(this.pnlAccent3);

            this.pnlStats.Controls.Add(this.pnlCard3);
            this.pnlStats.Controls.Add(this.pnlCard2);
            this.pnlStats.Controls.Add(this.pnlCard1);

            // ════════════════════════════════════════════════════════════════
            // pnlForm  —  Dock=Left  455px
            // ════════════════════════════════════════════════════════════════
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlForm.Width     = 455;
            this.pnlForm.TabIndex  = 102;

            // ── pnlFormHeader ─────────────────────────────────────────────────
            this.pnlFormHeader.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlFormHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlFormHeader.Height    = 48;

            this.pnlFormAccent.BackColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.pnlFormAccent.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlFormAccent.Width     = 4;

            this.lblFormTitle.AutoSize  = false;
            this.lblFormTitle.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblFormTitle.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.lblFormTitle.Name      = "lblFormTitle";
            this.lblFormTitle.Padding   = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFormTitle.Text      = "Nuevo Usuario";

            this.pnlFormHeader.Controls.Add(this.lblFormTitle);
            this.pnlFormHeader.Controls.Add(this.pnlFormAccent);

            // ── pnlFormFields ─────────────────────────────────────────────────
            this.pnlFormFields.AutoScroll = true;
            this.pnlFormFields.BackColor  = System.Drawing.Color.White;
            this.pnlFormFields.Dock       = System.Windows.Forms.DockStyle.Fill;

            // ── Nombre Completo (underline style) ─────────────────────────────
            this.lblNombreCompletoLbl.AutoSize  = true;
            this.lblNombreCompletoLbl.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblNombreCompletoLbl.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblNombreCompletoLbl.Location  = new System.Drawing.Point(18, 12);
            this.lblNombreCompletoLbl.Text      = "NOMBRE COMPLETO";
            this.lblNombreCompletoLbl.TabIndex  = 0;

            this.txtNombreCompleto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreCompleto.Font        = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtNombreCompleto.ForeColor   = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtNombreCompleto.Location    = new System.Drawing.Point(18, 30);
            this.txtNombreCompleto.Name        = "txtNombreCompleto";
            this.txtNombreCompleto.Size        = new System.Drawing.Size(419, 24);
            this.txtNombreCompleto.TabIndex    = 0;

            this.pnlLineNombre.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlLineNombre.Location  = new System.Drawing.Point(18, 56);
            this.pnlLineNombre.Name      = "pnlLineNombre";
            this.pnlLineNombre.Size      = new System.Drawing.Size(419, 2);
            this.pnlLineNombre.TabIndex  = 50;

            // ── Usuario + Contraseña (fila) ───────────────────────────────────
            this.lblUsuarioLbl.AutoSize  = true;
            this.lblUsuarioLbl.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioLbl.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblUsuarioLbl.Location  = new System.Drawing.Point(18, 70);
            this.lblUsuarioLbl.Text      = "USUARIO";
            this.lblUsuarioLbl.TabIndex  = 51;

            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font        = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtUsuario.ForeColor   = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtUsuario.Location    = new System.Drawing.Point(18, 88);
            this.txtUsuario.Name        = "txtUsuario";
            this.txtUsuario.Size        = new System.Drawing.Size(190, 24);
            this.txtUsuario.TabIndex    = 1;

            this.pnlLineUsuarioCampo.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlLineUsuarioCampo.Location  = new System.Drawing.Point(18, 114);
            this.pnlLineUsuarioCampo.Name      = "pnlLineUsuarioCampo";
            this.pnlLineUsuarioCampo.Size      = new System.Drawing.Size(190, 2);
            this.pnlLineUsuarioCampo.TabIndex  = 52;

            this.lblContraLbl.AutoSize  = true;
            this.lblContraLbl.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblContraLbl.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblContraLbl.Location  = new System.Drawing.Point(224, 70);
            this.lblContraLbl.Text      = "CONTRASEÑA";
            this.lblContraLbl.TabIndex  = 53;

            this.txtContraseña.BorderStyle  = System.Windows.Forms.BorderStyle.None;
            this.txtContraseña.Font         = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtContraseña.ForeColor    = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtContraseña.Location     = new System.Drawing.Point(224, 88);
            this.txtContraseña.Name         = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size         = new System.Drawing.Size(172, 24);
            this.txtContraseña.TabIndex     = 2;

            this.btnMostrarClave.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarClave.FlatAppearance.BorderSize  = 0;
            this.btnMostrarClave.BackColor = System.Drawing.Color.White;
            this.btnMostrarClave.Font      = new System.Drawing.Font("Segoe UI", 11F);
            this.btnMostrarClave.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnMostrarClave.Location  = new System.Drawing.Point(400, 86);
            this.btnMostrarClave.Name      = "btnMostrarClave";
            this.btnMostrarClave.Size      = new System.Drawing.Size(30, 28);
            this.btnMostrarClave.TabIndex  = 3;
            this.btnMostrarClave.Text      = "👁";

            this.pnlLineContra.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlLineContra.Location  = new System.Drawing.Point(224, 114);
            this.pnlLineContra.Name      = "pnlLineContra";
            this.pnlLineContra.Size      = new System.Drawing.Size(207, 2);
            this.pnlLineContra.TabIndex  = 54;

            // ── Rol + Estado (fila) ───────────────────────────────────────────
            this.lblRolLbl.AutoSize  = true;
            this.lblRolLbl.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblRolLbl.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblRolLbl.Location  = new System.Drawing.Point(18, 128);
            this.lblRolLbl.Text      = "ROL BASE";
            this.lblRolLbl.TabIndex  = 55;

            this.cmbRol.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.FlatStyle         = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRol.Font              = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location          = new System.Drawing.Point(18, 146);
            this.cmbRol.Name              = "cmbRol";
            this.cmbRol.Size              = new System.Drawing.Size(180, 27);
            this.cmbRol.TabIndex          = 4;

            this.lblActivoLbl.AutoSize  = true;
            this.lblActivoLbl.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblActivoLbl.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblActivoLbl.Location  = new System.Drawing.Point(224, 128);
            this.lblActivoLbl.Text      = "ESTADO";
            this.lblActivoLbl.TabIndex  = 56;

            this.chkUsuarioActivo.AutoSize  = true;
            this.chkUsuarioActivo.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkUsuarioActivo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.chkUsuarioActivo.Location  = new System.Drawing.Point(224, 149);
            this.chkUsuarioActivo.Name      = "chkUsuarioActivo";
            this.chkUsuarioActivo.TabIndex  = 5;
            this.chkUsuarioActivo.Text      = "Usuario Activo";

            // ── Email + Teléfono (fila) ───────────────────────────────────────
            this.lblEmailLbl.AutoSize  = true;
            this.lblEmailLbl.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblEmailLbl.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEmailLbl.Location  = new System.Drawing.Point(18, 184);
            this.lblEmailLbl.Text      = "CORREO ELECTRÓNICO";
            this.lblEmailLbl.TabIndex  = 57;

            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font        = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtEmail.ForeColor   = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtEmail.Location    = new System.Drawing.Point(18, 202);
            this.txtEmail.Name        = "txtEmail";
            this.txtEmail.Size        = new System.Drawing.Size(200, 24);
            this.txtEmail.TabIndex    = 5;

            this.pnlLineEmail.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlLineEmail.Location  = new System.Drawing.Point(18, 228);
            this.pnlLineEmail.Name      = "pnlLineEmail";
            this.pnlLineEmail.Size      = new System.Drawing.Size(200, 2);
            this.pnlLineEmail.TabIndex  = 58;

            this.lblTelefonoLbl.AutoSize  = true;
            this.lblTelefonoLbl.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblTelefonoLbl.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTelefonoLbl.Location  = new System.Drawing.Point(234, 184);
            this.lblTelefonoLbl.Text      = "TELÉFONO";
            this.lblTelefonoLbl.TabIndex  = 59;

            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefono.Font        = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtTelefono.ForeColor   = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtTelefono.Location    = new System.Drawing.Point(234, 202);
            this.txtTelefono.Name        = "txtTelefono";
            this.txtTelefono.Size        = new System.Drawing.Size(203, 24);
            this.txtTelefono.TabIndex    = 6;

            this.pnlLineTelefono.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlLineTelefono.Location  = new System.Drawing.Point(234, 228);
            this.pnlLineTelefono.Name      = "pnlLineTelefono";
            this.pnlLineTelefono.Size      = new System.Drawing.Size(203, 2);
            this.pnlLineTelefono.TabIndex  = 60;

            // ── Sección PERMISOS DE MÓDULOS ───────────────────────────────────
            this.lblSeccionModulos.AutoSize  = false;
            this.lblSeccionModulos.BackColor = System.Drawing.Color.FromArgb(238, 242, 255);
            this.lblSeccionModulos.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblSeccionModulos.ForeColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.lblSeccionModulos.Location  = new System.Drawing.Point(0, 244);
            this.lblSeccionModulos.Size      = new System.Drawing.Size(455, 24);
            this.lblSeccionModulos.Text      = "  PERMISOS DE MÓDULOS";
            this.lblSeccionModulos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSeccionModulos.TabIndex  = 61;

            // pnlPermisosModulos — contenedor de checkboxes de módulos
            this.pnlPermisosModulos.BackColor = System.Drawing.Color.White;
            this.pnlPermisosModulos.Location  = new System.Drawing.Point(10, 270);
            this.pnlPermisosModulos.Name      = "pnlPermisosModulos";
            this.pnlPermisosModulos.Size      = new System.Drawing.Size(435, 76);
            this.pnlPermisosModulos.TabIndex  = 62;

            this.chkVentas.AutoSize  = true;
            this.chkVentas.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.chkVentas.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.chkVentas.Location  = new System.Drawing.Point(8, 6);
            this.chkVentas.Name      = "chkVentas";
            this.chkVentas.TabIndex  = 7;
            this.chkVentas.Text      = "Ventas";
            this.chkClientes.AutoSize  = true;
            this.chkClientes.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.chkClientes.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.chkClientes.Location  = new System.Drawing.Point(8, 24);
            this.chkClientes.Name      = "chkClientes";
            this.chkClientes.TabIndex  = 8;
            this.chkClientes.Text      = "Clientes";
            this.chkCompras.AutoSize  = true;
            this.chkCompras.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.chkCompras.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.chkCompras.Location  = new System.Drawing.Point(8, 42);
            this.chkCompras.Name      = "chkCompras";
            this.chkCompras.TabIndex  = 9;
            this.chkCompras.Text      = "Compras";
            this.chkInventario.AutoSize  = true;
            this.chkInventario.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.chkInventario.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.chkInventario.Location  = new System.Drawing.Point(8, 60);
            this.chkInventario.Name      = "chkInventario";
            this.chkInventario.TabIndex  = 10;
            this.chkInventario.Text      = "Inventario";
            this.chkReportes.AutoSize  = true;
            this.chkReportes.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.chkReportes.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.chkReportes.Location  = new System.Drawing.Point(220, 6);
            this.chkReportes.Name      = "chkReportes";
            this.chkReportes.TabIndex  = 11;
            this.chkReportes.Text      = "Reportes";
            this.chkConfiguracion.AutoSize  = true;
            this.chkConfiguracion.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.chkConfiguracion.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.chkConfiguracion.Location  = new System.Drawing.Point(220, 24);
            this.chkConfiguracion.Name      = "chkConfiguracion";
            this.chkConfiguracion.TabIndex  = 12;
            this.chkConfiguracion.Text      = "Configuración";
            this.chkProveedores.AutoSize  = true;
            this.chkProveedores.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.chkProveedores.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.chkProveedores.Location  = new System.Drawing.Point(220, 42);
            this.chkProveedores.Name      = "chkProveedores";
            this.chkProveedores.TabIndex  = 13;
            this.chkProveedores.Text      = "Proveedores";
            this.chkFinanzas.AutoSize  = true;
            this.chkFinanzas.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.chkFinanzas.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.chkFinanzas.Location  = new System.Drawing.Point(220, 60);
            this.chkFinanzas.Name      = "chkFinanzas";
            this.chkFinanzas.TabIndex  = 14;
            this.chkFinanzas.Text      = "Finanzas";

            this.pnlPermisosModulos.Controls.Add(this.chkVentas);
            this.pnlPermisosModulos.Controls.Add(this.chkClientes);
            this.pnlPermisosModulos.Controls.Add(this.chkCompras);
            this.pnlPermisosModulos.Controls.Add(this.chkInventario);
            this.pnlPermisosModulos.Controls.Add(this.chkReportes);
            this.pnlPermisosModulos.Controls.Add(this.chkConfiguracion);
            this.pnlPermisosModulos.Controls.Add(this.chkProveedores);
            this.pnlPermisosModulos.Controls.Add(this.chkFinanzas);

            // ── Sección ACCIONES ESPECIALES ───────────────────────────────────
            this.lblSeccionAcciones.AutoSize  = false;
            this.lblSeccionAcciones.BackColor = System.Drawing.Color.FromArgb(255, 247, 237);
            this.lblSeccionAcciones.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblSeccionAcciones.ForeColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.lblSeccionAcciones.Location  = new System.Drawing.Point(0, 352);
            this.lblSeccionAcciones.Size      = new System.Drawing.Size(455, 24);
            this.lblSeccionAcciones.Text      = "  ACCIONES ESPECIALES";
            this.lblSeccionAcciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSeccionAcciones.TabIndex  = 63;

            // pnlAccionesWrap
            this.pnlAccionesWrap.BackColor = System.Drawing.Color.White;
            this.pnlAccionesWrap.Location  = new System.Drawing.Point(10, 378);
            this.pnlAccionesWrap.Name      = "pnlAccionesWrap";
            this.pnlAccionesWrap.Size      = new System.Drawing.Size(435, 58);
            this.pnlAccionesWrap.TabIndex  = 64;

            this.chkAplicarDescuentos.AutoSize  = true;
            this.chkAplicarDescuentos.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.chkAplicarDescuentos.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.chkAplicarDescuentos.Location  = new System.Drawing.Point(8, 4);
            this.chkAplicarDescuentos.Name      = "chkAplicarDescuentos";
            this.chkAplicarDescuentos.TabIndex  = 15;
            this.chkAplicarDescuentos.Text      = "Descuentos";
            this.chkAnularVentas.AutoSize  = true;
            this.chkAnularVentas.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.chkAnularVentas.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.chkAnularVentas.Location  = new System.Drawing.Point(8, 22);
            this.chkAnularVentas.Name      = "chkAnularVentas";
            this.chkAnularVentas.TabIndex  = 16;
            this.chkAnularVentas.Text      = "Anular ventas";
            this.chkEliminarRegistros.AutoSize  = true;
            this.chkEliminarRegistros.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.chkEliminarRegistros.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.chkEliminarRegistros.Location  = new System.Drawing.Point(8, 40);
            this.chkEliminarRegistros.Name      = "chkEliminarRegistros";
            this.chkEliminarRegistros.TabIndex  = 17;
            this.chkEliminarRegistros.Text      = "Eliminar registros";
            this.chkVerCostos.AutoSize  = true;
            this.chkVerCostos.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.chkVerCostos.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.chkVerCostos.Location  = new System.Drawing.Point(220, 4);
            this.chkVerCostos.Name      = "chkVerCostos";
            this.chkVerCostos.TabIndex  = 18;
            this.chkVerCostos.Text      = "Ver costos";
            this.chkModificarPrecios.AutoSize  = true;
            this.chkModificarPrecios.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.chkModificarPrecios.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.chkModificarPrecios.Location  = new System.Drawing.Point(220, 22);
            this.chkModificarPrecios.Name      = "chkModificarPrecios";
            this.chkModificarPrecios.TabIndex  = 19;
            this.chkModificarPrecios.Text      = "Modificar precios";
            this.chkAccederFueraHorario.AutoSize  = true;
            this.chkAccederFueraHorario.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.chkAccederFueraHorario.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.chkAccederFueraHorario.Location  = new System.Drawing.Point(220, 40);
            this.chkAccederFueraHorario.Name      = "chkAccederFueraHorario";
            this.chkAccederFueraHorario.TabIndex  = 20;
            this.chkAccederFueraHorario.Text      = "Fuera de horario";

            this.pnlAccionesWrap.Controls.Add(this.chkAplicarDescuentos);
            this.pnlAccionesWrap.Controls.Add(this.chkAnularVentas);
            this.pnlAccionesWrap.Controls.Add(this.chkEliminarRegistros);
            this.pnlAccionesWrap.Controls.Add(this.chkVerCostos);
            this.pnlAccionesWrap.Controls.Add(this.chkModificarPrecios);
            this.pnlAccionesWrap.Controls.Add(this.chkAccederFueraHorario);

            // Agregar todos al pnlFormFields
            this.pnlFormFields.Controls.Add(this.lblNombreCompletoLbl);
            this.pnlFormFields.Controls.Add(this.txtNombreCompleto);
            this.pnlFormFields.Controls.Add(this.pnlLineNombre);
            this.pnlFormFields.Controls.Add(this.lblUsuarioLbl);
            this.pnlFormFields.Controls.Add(this.txtUsuario);
            this.pnlFormFields.Controls.Add(this.pnlLineUsuarioCampo);
            this.pnlFormFields.Controls.Add(this.lblContraLbl);
            this.pnlFormFields.Controls.Add(this.txtContraseña);
            this.pnlFormFields.Controls.Add(this.btnMostrarClave);
            this.pnlFormFields.Controls.Add(this.pnlLineContra);
            this.pnlFormFields.Controls.Add(this.lblRolLbl);
            this.pnlFormFields.Controls.Add(this.cmbRol);
            this.pnlFormFields.Controls.Add(this.lblActivoLbl);
            this.pnlFormFields.Controls.Add(this.chkUsuarioActivo);
            this.pnlFormFields.Controls.Add(this.lblEmailLbl);
            this.pnlFormFields.Controls.Add(this.txtEmail);
            this.pnlFormFields.Controls.Add(this.pnlLineEmail);
            this.pnlFormFields.Controls.Add(this.lblTelefonoLbl);
            this.pnlFormFields.Controls.Add(this.txtTelefono);
            this.pnlFormFields.Controls.Add(this.pnlLineTelefono);
            this.pnlFormFields.Controls.Add(this.lblSeccionModulos);
            this.pnlFormFields.Controls.Add(this.pnlPermisosModulos);
            this.pnlFormFields.Controls.Add(this.lblSeccionAcciones);
            this.pnlFormFields.Controls.Add(this.pnlAccionesWrap);

            // ── pnlFormButtons ────────────────────────────────────────────────
            this.pnlFormButtons.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlFormButtons.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFormButtons.Height    = 60;

            this.btnGuardar.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.BackColor  = System.Drawing.Color.FromArgb(99, 102, 241);
            this.btnGuardar.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(79, 82, 221);
            this.btnGuardar.Font       = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor  = System.Drawing.Color.White;
            this.btnGuardar.Location   = new System.Drawing.Point(16, 12);
            this.btnGuardar.Name       = "btnGuardar";
            this.btnGuardar.Size       = new System.Drawing.Size(126, 36);
            this.btnGuardar.TabIndex   = 20;
            this.btnGuardar.Text       = "Guardar";

            this.btnCancelar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnCancelar.FlatAppearance.BorderSize  = 1;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.btnCancelar.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(80, 90, 100);
            this.btnCancelar.Location  = new System.Drawing.Point(154, 12);
            this.btnCancelar.Name      = "btnCancelar";
            this.btnCancelar.Size      = new System.Drawing.Size(100, 36);
            this.btnCancelar.TabIndex  = 21;
            this.btnCancelar.Text      = "Cancelar";

            this.btnNuevo.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.BackColor  = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnNuevo.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(5, 150, 105);
            this.btnNuevo.Font       = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor  = System.Drawing.Color.White;
            this.btnNuevo.Location   = new System.Drawing.Point(266, 12);
            this.btnNuevo.Name       = "btnNuevo";
            this.btnNuevo.Size       = new System.Drawing.Size(110, 36);
            this.btnNuevo.TabIndex   = 22;
            this.btnNuevo.Text       = "+ Nuevo";

            this.pnlFormButtons.Controls.Add(this.btnNuevo);
            this.pnlFormButtons.Controls.Add(this.btnCancelar);
            this.pnlFormButtons.Controls.Add(this.btnGuardar);

            // Armar pnlForm
            this.pnlForm.Controls.Add(this.pnlFormFields);
            this.pnlForm.Controls.Add(this.pnlFormButtons);
            this.pnlForm.Controls.Add(this.pnlFormHeader);

            // ════════════════════════════════════════════════════════════════
            // pnlSep  — línea separadora vertical
            // ════════════════════════════════════════════════════════════════
            this.pnlSep.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlSep.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlSep.Width     = 1;
            this.pnlSep.TabIndex  = 103;

            // ════════════════════════════════════════════════════════════════
            // pnlListArea  —  Dock=Fill
            // ════════════════════════════════════════════════════════════════
            this.pnlListArea.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlListArea.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlListArea.TabIndex  = 104;

            // Toolbar
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Height    = 54;

            this.lblBuscarLbl.AutoSize  = true;
            this.lblBuscarLbl.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblBuscarLbl.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblBuscarLbl.Location  = new System.Drawing.Point(18, 20);
            this.lblBuscarLbl.Text      = "BUSCAR:";
            this.lblBuscarLbl.TabIndex  = 30;

            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.ForeColor   = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtBuscar.Location    = new System.Drawing.Point(90, 15);
            this.txtBuscar.Name        = "txtBuscar";
            this.txtBuscar.Size        = new System.Drawing.Size(310, 26);
            this.txtBuscar.TabIndex    = 30;

            this.pnlToolbar.Controls.Add(this.lblBuscarLbl);
            this.pnlToolbar.Controls.Add(this.txtBuscar);

            // DataGridView
            this.pnlGridWrap.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlGridWrap.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridWrap.Padding   = new System.Windows.Forms.Padding(14, 10, 14, 0);

            var styleHeader = new System.Windows.Forms.DataGridViewCellStyle();
            styleHeader.BackColor          = System.Drawing.Color.FromArgb(15, 23, 42);
            styleHeader.ForeColor          = System.Drawing.Color.White;
            styleHeader.Font               = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            styleHeader.Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            styleHeader.SelectionBackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            styleHeader.SelectionForeColor = System.Drawing.Color.White;

            var styleRow = new System.Windows.Forms.DataGridViewCellStyle();
            styleRow.BackColor          = System.Drawing.Color.White;
            styleRow.ForeColor          = System.Drawing.Color.FromArgb(30, 41, 59);
            styleRow.Font               = new System.Drawing.Font("Segoe UI", 9.5F);
            styleRow.Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            styleRow.SelectionBackColor = System.Drawing.Color.FromArgb(238, 242, 255);
            styleRow.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);

            var styleAlt = new System.Windows.Forms.DataGridViewCellStyle();
            styleAlt.BackColor = System.Drawing.Color.FromArgb(250, 252, 255);

            this.dgvUsuarios.AllowUserToAddRows              = false;
            this.dgvUsuarios.AllowUserToDeleteRows           = false;
            this.dgvUsuarios.AllowUserToResizeRows           = false;
            this.dgvUsuarios.AutoGenerateColumns             = false;
            this.dgvUsuarios.AutoSizeRowsMode                = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.dgvUsuarios.BackgroundColor                 = System.Drawing.Color.White;
            this.dgvUsuarios.BorderStyle                     = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.CellBorderStyle                 = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsuarios.ColumnHeadersBorderStyle        = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle   = styleHeader;
            this.dgvUsuarios.ColumnHeadersHeight             = 36;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode     = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsuarios.DefaultCellStyle                = styleRow;
            this.dgvUsuarios.AlternatingRowsDefaultCellStyle = styleAlt;
            this.dgvUsuarios.Dock                            = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.EnableHeadersVisualStyles       = false;
            this.dgvUsuarios.GridColor                       = System.Drawing.Color.FromArgb(241, 245, 249);
            this.dgvUsuarios.MultiSelect                     = false;
            this.dgvUsuarios.Name                            = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly                        = false;
            this.dgvUsuarios.RowHeadersVisible               = false;
            this.dgvUsuarios.RowTemplate.Height              = 40;
            this.dgvUsuarios.SelectionMode                   = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.TabIndex                        = 0;

            this.colNumero.HeaderText = "#";
            this.colNumero.Name       = "colNumero";
            this.colNumero.ReadOnly   = true;
            this.colNumero.Width      = 44;
            this.colNumero.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colNumero.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);

            this.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombre.HeaderText   = "Nombre Completo";
            this.colNombre.Name         = "colNombre";
            this.colNombre.ReadOnly     = true;
            this.colNombre.MinimumWidth = 140;

            this.colUsuario.HeaderText = "Usuario";
            this.colUsuario.Name       = "colUsuario";
            this.colUsuario.ReadOnly   = true;
            this.colUsuario.Width      = 130;

            this.colRol.HeaderText = "Rol";
            this.colRol.Name       = "colRol";
            this.colRol.ReadOnly   = true;
            this.colRol.Width      = 110;

            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name       = "colEstado";
            this.colEstado.ReadOnly   = true;
            this.colEstado.Width      = 90;
            this.colEstado.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEstado.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);

            this.colEditar.HeaderText = "";
            this.colEditar.Name       = "colEditar";
            this.colEditar.ReadOnly   = false;
            this.colEditar.Text       = "Editar";
            this.colEditar.UseColumnTextForButtonValue = true;
            this.colEditar.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.colEditar.Width      = 72;
            this.colEditar.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(238, 242, 255);
            this.colEditar.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.colEditar.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.colEditar.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colEliminar.HeaderText = "";
            this.colEliminar.Name       = "colEliminar";
            this.colEliminar.ReadOnly   = false;
            this.colEliminar.Text       = "Eliminar";
            this.colEliminar.UseColumnTextForButtonValue = true;
            this.colEliminar.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.colEliminar.Width      = 72;
            this.colEliminar.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 241, 242);
            this.colEliminar.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.colEliminar.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.colEliminar.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNumero, this.colNombre, this.colUsuario,
                this.colRol, this.colEstado, this.colEditar, this.colEliminar
            });

            this.pnlGridWrap.Controls.Add(this.dgvUsuarios);

            // Resumen
            this.pnlResumen.BackColor = System.Drawing.Color.White;
            this.pnlResumen.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumen.Height    = 36;

            this.lblMostrar.AutoSize  = true;
            this.lblMostrar.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMostrar.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblMostrar.Location  = new System.Drawing.Point(16, 11);
            this.lblMostrar.Name      = "lblMostrar";
            this.lblMostrar.Text      = "Mostrando 0 usuarios";

            this.pnlResumen.Controls.Add(this.lblMostrar);

            this.pnlListArea.Controls.Add(this.pnlGridWrap);
            this.pnlListArea.Controls.Add(this.pnlResumen);
            this.pnlListArea.Controls.Add(this.pnlToolbar);

            // ════════════════════════════════════════════════════════════════
            // Form
            // ════════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize          = new System.Drawing.Size(1184, 611);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.None;
            this.Name                = "FormUsuarios";
            this.Text                = "Gestión de Usuarios";

            this.Controls.Add(this.pnlListArea);
            this.Controls.Add(this.pnlSep);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlHeader);

            // ── Resume ────────────────────────────────────────────────────────
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard3.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlFormHeader.ResumeLayout(false);
            this.pnlFormFields.ResumeLayout(false);
            this.pnlFormFields.PerformLayout();
            this.pnlFormButtons.ResumeLayout(false);
            this.pnlPermisosModulos.ResumeLayout(false);
            this.pnlPermisosModulos.PerformLayout();
            this.pnlAccionesWrap.ResumeLayout(false);
            this.pnlAccionesWrap.PerformLayout();
            this.pnlListArea.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlGridWrap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvUsuarios).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // ── Header ───────────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlHeaderAccent;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblHeaderSub;

        // ── Stats ─────────────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlCard1, pnlCard2, pnlCard3;
        private System.Windows.Forms.Panel pnlAccent1, pnlAccent2, pnlAccent3;
        private System.Windows.Forms.Label lblCardVal1, lblCardVal2, lblCardVal3;
        private System.Windows.Forms.Label lblCardTitle1, lblCardTitle2, lblCardTitle3;

        // ── Form panel ───────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Panel pnlFormHeader;
        private System.Windows.Forms.Panel pnlFormAccent;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlFormFields;

        // Campos de datos básicos
        private System.Windows.Forms.Label lblNombreCompletoLbl;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.Panel pnlLineNombre;
        private System.Windows.Forms.Label lblUsuarioLbl;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Panel pnlLineUsuarioCampo;
        private System.Windows.Forms.Label lblContraLbl;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Button btnMostrarClave;
        private System.Windows.Forms.Panel pnlLineContra;
        private System.Windows.Forms.Label lblRolLbl;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Label lblActivoLbl;
        private System.Windows.Forms.CheckBox chkUsuarioActivo;
        private System.Windows.Forms.Label lblEmailLbl;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Panel pnlLineEmail;
        private System.Windows.Forms.Label lblTelefonoLbl;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Panel pnlLineTelefono;

        // Sección módulos
        private System.Windows.Forms.Label lblSeccionModulos;
        private System.Windows.Forms.Panel pnlPermisosModulos;
        private System.Windows.Forms.CheckBox chkVentas;
        private System.Windows.Forms.CheckBox chkClientes;
        private System.Windows.Forms.CheckBox chkCompras;
        private System.Windows.Forms.CheckBox chkInventario;
        private System.Windows.Forms.CheckBox chkReportes;
        private System.Windows.Forms.CheckBox chkConfiguracion;
        private System.Windows.Forms.CheckBox chkProveedores;
        private System.Windows.Forms.CheckBox chkFinanzas;

        // Sección acciones especiales
        private System.Windows.Forms.Label lblSeccionAcciones;
        private System.Windows.Forms.Panel pnlAccionesWrap;
        private System.Windows.Forms.CheckBox chkAplicarDescuentos;
        private System.Windows.Forms.CheckBox chkAnularVentas;
        private System.Windows.Forms.CheckBox chkEliminarRegistros;
        private System.Windows.Forms.CheckBox chkVerCostos;
        private System.Windows.Forms.CheckBox chkModificarPrecios;
        private System.Windows.Forms.CheckBox chkAccederFueraHorario;

        // Botones
        private System.Windows.Forms.Panel pnlFormButtons;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNuevo;

        // ── Separador + Lista ─────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlSep;
        private System.Windows.Forms.Panel pnlListArea;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblBuscarLbl;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Panel pnlGridWrap;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.DataGridViewButtonColumn colEliminar;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblMostrar;

        // Alias de compatibilidad (referenciados en código heredado)
        private System.Windows.Forms.Label lblPermisosModulos    => lblSeccionModulos;
        private System.Windows.Forms.Label lblAccionesEspeciales => lblSeccionAcciones;
        private System.Windows.Forms.Label lblSubTitulo2         => lblFormTitle;
    }
}
