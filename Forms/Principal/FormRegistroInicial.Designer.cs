namespace SistemaPOS.Forms.Principal
{
    partial class FormRegistroInicial
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
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(FormRegistroInicial));

            // Left panel
            this.pnlLeft         = new System.Windows.Forms.Panel();
            this.pnlAccentTop    = new System.Windows.Forms.Panel();
            this.lblBrand        = new System.Windows.Forms.Label();
            this.lblBrandTagline = new System.Windows.Forms.Label();
            this.lblBrandHint    = new System.Windows.Forms.Label();
            this.lblBrandVersion = new System.Windows.Forms.Label();
            this.pnlDeco1        = new System.Windows.Forms.Panel();
            this.pnlDeco2        = new System.Windows.Forms.Panel();

            // Right panel
            this.pnlRight              = new System.Windows.Forms.Panel();
            this.pbLogo                = new System.Windows.Forms.PictureBox();
            this.lblTitulo             = new System.Windows.Forms.Label();
            this.lblSubtitulo          = new System.Windows.Forms.Label();

            // Campo: Nombre de usuario
            this.lblNombreUsuario      = new System.Windows.Forms.Label();
            this.txtNombreUsuario      = new System.Windows.Forms.TextBox();
            this.pnlLineNombreU        = new System.Windows.Forms.Panel();

            // Campo: Correo
            this.lblCorreo             = new System.Windows.Forms.Label();
            this.txtCorreo             = new System.Windows.Forms.TextBox();
            this.pnlLineCorreo         = new System.Windows.Forms.Panel();

            // Campo: Contraseña
            this.lblContraseña         = new System.Windows.Forms.Label();
            this.pnlInputContra        = new System.Windows.Forms.Panel();
            this.txtContraseña         = new System.Windows.Forms.TextBox();
            this.btnMostrarClave       = new System.Windows.Forms.Button();
            this.pnlLineContra         = new System.Windows.Forms.Panel();

            // Campo: Confirmar contraseña
            this.lblConfirmarContraseña = new System.Windows.Forms.Label();
            this.pnlInputContra2        = new System.Windows.Forms.Panel();
            this.txtConfirmarContraseña = new System.Windows.Forms.TextBox();
            this.btnMostrarClave2       = new System.Windows.Forms.Button();
            this.pnlLineConfirmar       = new System.Windows.Forms.Panel();

            // Botón principal
            this.btnRegistrarse        = new System.Windows.Forms.Button();

            // Legacy — vestigiales, no visibles
            this.pnlCentral            = new System.Windows.Forms.Panel();
            this.lblRegistro           = new System.Windows.Forms.Label();
            this.lblCreaAdmin          = new System.Windows.Forms.Label();
            this.lblNombreCompleto     = new System.Windows.Forms.Label();
            this.txtNombreCompleto     = new System.Windows.Forms.TextBox();

            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlInputContra.SuspendLayout();
            this.pnlInputContra2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();

            // ── pnlLeft ───────────────────────────────────────────────────────
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlLeft.Controls.Add(this.lblBrand);
            this.pnlLeft.Controls.Add(this.lblBrandTagline);
            this.pnlLeft.Controls.Add(this.lblBrandHint);
            this.pnlLeft.Controls.Add(this.lblBrandVersion);
            this.pnlLeft.Controls.Add(this.pnlDeco1);
            this.pnlLeft.Controls.Add(this.pnlDeco2);
            this.pnlLeft.Controls.Add(this.pnlAccentTop);
            this.pnlLeft.Dock  = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Width = 300;
            this.pnlLeft.Name  = "pnlLeft";
            this.pnlLeft.TabIndex = 10;

            this.pnlAccentTop.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.pnlAccentTop.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlAccentTop.Height    = 5;
            this.pnlAccentTop.Name      = "pnlAccentTop";
            this.pnlAccentTop.TabIndex  = 0;

            this.pnlDeco1.BackColor = System.Drawing.Color.Transparent;
            this.pnlDeco1.Location  = new System.Drawing.Point(170, 30);
            this.pnlDeco1.Name      = "pnlDeco1";
            this.pnlDeco1.Size      = new System.Drawing.Size(170, 170);
            this.pnlDeco1.TabIndex  = 4;

            this.pnlDeco2.BackColor = System.Drawing.Color.Transparent;
            this.pnlDeco2.Location  = new System.Drawing.Point(-50, 380);
            this.pnlDeco2.Name      = "pnlDeco2";
            this.pnlDeco2.Size      = new System.Drawing.Size(160, 160);
            this.pnlDeco2.TabIndex  = 5;

            this.lblBrand.AutoSize  = false;
            this.lblBrand.Font      = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location  = new System.Drawing.Point(28, 160);
            this.lblBrand.Name      = "lblBrand";
            this.lblBrand.Size      = new System.Drawing.Size(248, 52);
            this.lblBrand.Text      = "SystemPOS";
            this.lblBrand.TabIndex  = 1;

            this.lblBrandTagline.AutoSize  = false;
            this.lblBrandTagline.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBrandTagline.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblBrandTagline.Location  = new System.Drawing.Point(28, 220);
            this.lblBrandTagline.Name      = "lblBrandTagline";
            this.lblBrandTagline.Size      = new System.Drawing.Size(248, 48);
            this.lblBrandTagline.Text      = "Sistema de Punto de Venta\r\nModerno e inteligente.";
            this.lblBrandTagline.TabIndex  = 2;

            // Aviso de primer acceso
            this.lblBrandHint.AutoSize  = false;
            this.lblBrandHint.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBrandHint.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblBrandHint.Location  = new System.Drawing.Point(28, 290);
            this.lblBrandHint.Name      = "lblBrandHint";
            this.lblBrandHint.Size      = new System.Drawing.Size(248, 48);
            this.lblBrandHint.Text      = "Primer acceso detectado.\r\nCrea tu cuenta de administrador\r\npara comenzar.";
            this.lblBrandHint.TabIndex  = 3;

            this.lblBrandVersion.AutoSize  = false;
            this.lblBrandVersion.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBrandVersion.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblBrandVersion.Location  = new System.Drawing.Point(28, 475);
            this.lblBrandVersion.Name      = "lblBrandVersion";
            this.lblBrandVersion.Size      = new System.Drawing.Size(240, 16);
            this.lblBrandVersion.Text      = "v1.0  ·  © 2026 SystemPOS";
            this.lblBrandVersion.TabIndex  = 6;

            // ── pnlRight ──────────────────────────────────────────────────────
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.pbLogo);
            this.pnlRight.Controls.Add(this.lblTitulo);
            this.pnlRight.Controls.Add(this.lblSubtitulo);
            this.pnlRight.Controls.Add(this.lblNombreUsuario);
            this.pnlRight.Controls.Add(this.txtNombreUsuario);
            this.pnlRight.Controls.Add(this.pnlLineNombreU);
            this.pnlRight.Controls.Add(this.lblCorreo);
            this.pnlRight.Controls.Add(this.txtCorreo);
            this.pnlRight.Controls.Add(this.pnlLineCorreo);
            this.pnlRight.Controls.Add(this.lblContraseña);
            this.pnlRight.Controls.Add(this.pnlInputContra);
            this.pnlRight.Controls.Add(this.pnlLineContra);
            this.pnlRight.Controls.Add(this.lblConfirmarContraseña);
            this.pnlRight.Controls.Add(this.pnlInputContra2);
            this.pnlRight.Controls.Add(this.pnlLineConfirmar);
            this.pnlRight.Controls.Add(this.btnRegistrarse);
            this.pnlRight.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Name     = "pnlRight";
            this.pnlRight.TabIndex = 11;

            // pbLogo — centrado en panel de 460px → x = (460-100)/2 = 180
            this.pbLogo.Image    = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(180, 22);
            this.pbLogo.Name     = "pbLogo";
            this.pbLogo.Size     = new System.Drawing.Size(100, 50);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop  = false;

            // lblTitulo
            this.lblTitulo.AutoSize  = false;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitulo.Location  = new System.Drawing.Point(60, 84);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Size      = new System.Drawing.Size(340, 36);
            this.lblTitulo.Text      = "Crear Cuenta";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.TabIndex  = 1;

            // lblSubtitulo
            this.lblSubtitulo.AutoSize  = false;
            this.lblSubtitulo.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtitulo.Location  = new System.Drawing.Point(60, 122);
            this.lblSubtitulo.Name      = "lblSubtitulo";
            this.lblSubtitulo.Size      = new System.Drawing.Size(340, 18);
            this.lblSubtitulo.Text      = "Configuración inicial — administrador del sistema";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubtitulo.TabIndex  = 2;

            // ── Campo: Nombre de usuario ───────────────────────────────────────
            this.lblNombreUsuario.AutoSize  = true;
            this.lblNombreUsuario.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblNombreUsuario.Location  = new System.Drawing.Point(60, 154);
            this.lblNombreUsuario.Name      = "lblNombreUsuario";
            this.lblNombreUsuario.TabIndex  = 3;
            this.lblNombreUsuario.Text      = "NOMBRE DE USUARIO";

            this.txtNombreUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreUsuario.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNombreUsuario.ForeColor   = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtNombreUsuario.Location    = new System.Drawing.Point(60, 174);
            this.txtNombreUsuario.Name        = "txtNombreUsuario";
            this.txtNombreUsuario.Size        = new System.Drawing.Size(340, 24);
            this.txtNombreUsuario.TabIndex    = 1;

            this.pnlLineNombreU.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlLineNombreU.Location  = new System.Drawing.Point(60, 200);
            this.pnlLineNombreU.Name      = "pnlLineNombreU";
            this.pnlLineNombreU.Size      = new System.Drawing.Size(340, 2);
            this.pnlLineNombreU.TabIndex  = 40;

            // ── Campo: Correo ──────────────────────────────────────────────────
            this.lblCorreo.AutoSize  = true;
            this.lblCorreo.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCorreo.Location  = new System.Drawing.Point(60, 216);
            this.lblCorreo.Name      = "lblCorreo";
            this.lblCorreo.TabIndex  = 41;
            this.lblCorreo.Text      = "CORREO ELECTRÓNICO  (opcional)";

            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreo.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCorreo.ForeColor   = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtCorreo.Location    = new System.Drawing.Point(60, 236);
            this.txtCorreo.Name        = "txtCorreo";
            this.txtCorreo.Size        = new System.Drawing.Size(340, 24);
            this.txtCorreo.TabIndex    = 2;

            this.pnlLineCorreo.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlLineCorreo.Location  = new System.Drawing.Point(60, 262);
            this.pnlLineCorreo.Name      = "pnlLineCorreo";
            this.pnlLineCorreo.Size      = new System.Drawing.Size(340, 2);
            this.pnlLineCorreo.TabIndex  = 42;

            // ── Campo: Contraseña ──────────────────────────────────────────────
            this.lblContraseña.AutoSize  = true;
            this.lblContraseña.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblContraseña.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblContraseña.Location  = new System.Drawing.Point(60, 278);
            this.lblContraseña.Name      = "lblContraseña";
            this.lblContraseña.TabIndex  = 43;
            this.lblContraseña.Text      = "CONTRASEÑA";

            this.pnlInputContra.BackColor = System.Drawing.Color.White;
            this.pnlInputContra.Location  = new System.Drawing.Point(60, 298);
            this.pnlInputContra.Name      = "pnlInputContra";
            this.pnlInputContra.Size      = new System.Drawing.Size(340, 26);
            this.pnlInputContra.TabIndex  = 44;
            this.pnlInputContra.Controls.Add(this.txtContraseña);
            this.pnlInputContra.Controls.Add(this.btnMostrarClave);

            this.txtContraseña.BorderStyle  = System.Windows.Forms.BorderStyle.None;
            this.txtContraseña.Font         = new System.Drawing.Font("Segoe UI", 11F);
            this.txtContraseña.ForeColor    = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtContraseña.Location     = new System.Drawing.Point(0, 2);
            this.txtContraseña.Name         = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size         = new System.Drawing.Size(308, 24);
            this.txtContraseña.TabIndex     = 3;

            this.btnMostrarClave.BackColor = System.Drawing.Color.White;
            this.btnMostrarClave.FlatAppearance.BorderSize = 0;
            this.btnMostrarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarClave.Font      = new System.Drawing.Font("Segoe UI", 11F);
            this.btnMostrarClave.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnMostrarClave.Location  = new System.Drawing.Point(310, 0);
            this.btnMostrarClave.Name      = "btnMostrarClave";
            this.btnMostrarClave.Size      = new System.Drawing.Size(30, 26);
            this.btnMostrarClave.Text      = "👁";
            this.btnMostrarClave.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarClave.UseVisualStyleBackColor = false;

            this.pnlLineContra.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlLineContra.Location  = new System.Drawing.Point(60, 326);
            this.pnlLineContra.Name      = "pnlLineContra";
            this.pnlLineContra.Size      = new System.Drawing.Size(340, 2);
            this.pnlLineContra.TabIndex  = 45;

            // ── Campo: Confirmar contraseña ────────────────────────────────────
            this.lblConfirmarContraseña.AutoSize  = true;
            this.lblConfirmarContraseña.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblConfirmarContraseña.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblConfirmarContraseña.Location  = new System.Drawing.Point(60, 342);
            this.lblConfirmarContraseña.Name      = "lblConfirmarContraseña";
            this.lblConfirmarContraseña.TabIndex  = 46;
            this.lblConfirmarContraseña.Text      = "CONFIRMAR CONTRASEÑA";

            this.pnlInputContra2.BackColor = System.Drawing.Color.White;
            this.pnlInputContra2.Location  = new System.Drawing.Point(60, 362);
            this.pnlInputContra2.Name      = "pnlInputContra2";
            this.pnlInputContra2.Size      = new System.Drawing.Size(340, 26);
            this.pnlInputContra2.TabIndex  = 47;
            this.pnlInputContra2.Controls.Add(this.txtConfirmarContraseña);
            this.pnlInputContra2.Controls.Add(this.btnMostrarClave2);

            this.txtConfirmarContraseña.BorderStyle  = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmarContraseña.Font         = new System.Drawing.Font("Segoe UI", 11F);
            this.txtConfirmarContraseña.ForeColor    = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtConfirmarContraseña.Location     = new System.Drawing.Point(0, 2);
            this.txtConfirmarContraseña.Name         = "txtConfirmarContraseña";
            this.txtConfirmarContraseña.PasswordChar = '*';
            this.txtConfirmarContraseña.Size         = new System.Drawing.Size(308, 24);
            this.txtConfirmarContraseña.TabIndex     = 4;

            this.btnMostrarClave2.BackColor = System.Drawing.Color.White;
            this.btnMostrarClave2.FlatAppearance.BorderSize = 0;
            this.btnMostrarClave2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarClave2.Font      = new System.Drawing.Font("Segoe UI", 11F);
            this.btnMostrarClave2.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnMostrarClave2.Location  = new System.Drawing.Point(310, 0);
            this.btnMostrarClave2.Name      = "btnMostrarClave2";
            this.btnMostrarClave2.Size      = new System.Drawing.Size(30, 26);
            this.btnMostrarClave2.Text      = "👁";
            this.btnMostrarClave2.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarClave2.UseVisualStyleBackColor = false;

            this.pnlLineConfirmar.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlLineConfirmar.Location  = new System.Drawing.Point(60, 390);
            this.pnlLineConfirmar.Name      = "pnlLineConfirmar";
            this.pnlLineConfirmar.Size      = new System.Drawing.Size(340, 2);
            this.pnlLineConfirmar.TabIndex  = 48;

            // ── btnRegistrarse ────────────────────────────────────────────────
            this.btnRegistrarse.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnRegistrarse.FlatAppearance.BorderSize = 0;
            this.btnRegistrarse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(5, 150, 105);
            this.btnRegistrarse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarse.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarse.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarse.Location  = new System.Drawing.Point(60, 416);
            this.btnRegistrarse.Name      = "btnRegistrarse";
            this.btnRegistrarse.Size      = new System.Drawing.Size(340, 46);
            this.btnRegistrarse.TabIndex  = 5;
            this.btnRegistrarse.Text      = "CREAR CUENTA  →";
            this.btnRegistrarse.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarse.UseVisualStyleBackColor = false;

            // ── Legacy hidden controls ─────────────────────────────────────────
            this.pnlCentral.Visible    = false;
            this.pnlCentral.Size       = new System.Drawing.Size(1, 1);
            this.lblRegistro.Visible   = false;
            this.lblRegistro.Size      = new System.Drawing.Size(1, 1);
            this.lblCreaAdmin.Visible  = false;
            this.lblCreaAdmin.Size     = new System.Drawing.Size(1, 1);
            this.lblNombreCompleto.Visible = false;
            this.lblNombreCompleto.Size    = new System.Drawing.Size(1, 1);
            this.txtNombreCompleto.Visible = false;
            this.txtNombreCompleto.Size    = new System.Drawing.Size(1, 1);

            // ── FormRegistroInicial ───────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor     = System.Drawing.Color.White;
            this.ClientSize    = new System.Drawing.Size(760, 500);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlCentral);
            this.Controls.Add(this.lblRegistro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox   = false;
            this.MinimizeBox   = false;
            this.Name          = "FormRegistroInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text          = "SystemPOS — Registro Inicial";

            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlInputContra.ResumeLayout(false);
            this.pnlInputContra.PerformLayout();
            this.pnlInputContra2.ResumeLayout(false);
            this.pnlInputContra2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // Left panel
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlAccentTop;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblBrandTagline;
        private System.Windows.Forms.Label lblBrandHint;
        private System.Windows.Forms.Label lblBrandVersion;
        private System.Windows.Forms.Panel pnlDeco1;
        private System.Windows.Forms.Panel pnlDeco2;

        // Right panel
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlLineNombreU;
        private System.Windows.Forms.Panel pnlLineCorreo;
        private System.Windows.Forms.Panel pnlInputContra;
        private System.Windows.Forms.Panel pnlLineContra;
        private System.Windows.Forms.Panel pnlInputContra2;
        private System.Windows.Forms.Panel pnlLineConfirmar;

        // Legacy (sin uso en lógica .cs)
        private System.Windows.Forms.Panel pnlCentral;
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.Label lblCreaAdmin;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.TextBox txtNombreCompleto;

        // Controles usados por FormRegistroInicial.cs
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Button btnMostrarClave;
        private System.Windows.Forms.Label lblConfirmarContraseña;
        private System.Windows.Forms.TextBox txtConfirmarContraseña;
        private System.Windows.Forms.Button btnMostrarClave2;
        private System.Windows.Forms.Button btnRegistrarse;
    }
}
