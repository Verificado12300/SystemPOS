namespace SistemaPOS.Forms.Principal
{
    partial class FormLogin
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
                new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));

            // Left panel
            this.pnlLeft        = new System.Windows.Forms.Panel();
            this.pnlAccentTop   = new System.Windows.Forms.Panel();
            this.lblBrand       = new System.Windows.Forms.Label();
            this.lblBrandTagline  = new System.Windows.Forms.Label();
            this.lblBrandVersion  = new System.Windows.Forms.Label();
            this.pnlDeco1       = new System.Windows.Forms.Panel();
            this.pnlDeco2       = new System.Windows.Forms.Panel();

            // Right panel
            this.pnlRight           = new System.Windows.Forms.Panel();
            this.pbLogo             = new System.Windows.Forms.PictureBox();
            this.lblBienvenido      = new System.Windows.Forms.Label();
            this.lblBienvenidoSub   = new System.Windows.Forms.Label();
            this.lblUsuario         = new System.Windows.Forms.Label();
            this.txtUsuario         = new System.Windows.Forms.TextBox();
            this.pnlLineUsuario     = new System.Windows.Forms.Panel();
            this.lblContraseña      = new System.Windows.Forms.Label();
            this.pnlInputContra     = new System.Windows.Forms.Panel();
            this.txtContraseña      = new System.Windows.Forms.TextBox();
            this.btnMostrarClave    = new System.Windows.Forms.Button();
            this.pnlLineContra      = new System.Windows.Forms.Panel();
            this.btnIniciarSesion   = new System.Windows.Forms.Button();
            this.lnkOlvideContraseña = new System.Windows.Forms.LinkLabel();

            // Legacy hidden controls
            this.pnlCentral     = new System.Windows.Forms.Panel();
            this.lblTitulo      = new System.Windows.Forms.Label();
            this.lblIniciarSesion = new System.Windows.Forms.Label();

            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlInputContra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();

            // ── pnlLeft ───────────────────────────────────────────────────────
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlLeft.Controls.Add(this.lblBrand);
            this.pnlLeft.Controls.Add(this.lblBrandTagline);
            this.pnlLeft.Controls.Add(this.lblBrandVersion);
            this.pnlLeft.Controls.Add(this.pnlDeco1);
            this.pnlLeft.Controls.Add(this.pnlDeco2);
            this.pnlLeft.Controls.Add(this.pnlAccentTop);
            this.pnlLeft.Dock  = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Width = 300;
            this.pnlLeft.Name  = "pnlLeft";
            this.pnlLeft.TabIndex = 10;

            // pnlAccentTop — 5-px indigo stripe at very top of left panel
            this.pnlAccentTop.BackColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.pnlAccentTop.Dock   = System.Windows.Forms.DockStyle.Top;
            this.pnlAccentTop.Height = 5;
            this.pnlAccentTop.Name   = "pnlAccentTop";
            this.pnlAccentTop.TabIndex = 0;

            // pnlDeco1 — translucent circle top-right (painted as ellipse in .cs)
            this.pnlDeco1.BackColor = System.Drawing.Color.Transparent;
            this.pnlDeco1.Location  = new System.Drawing.Point(170, 30);
            this.pnlDeco1.Name      = "pnlDeco1";
            this.pnlDeco1.Size      = new System.Drawing.Size(170, 170);
            this.pnlDeco1.TabIndex  = 4;

            // pnlDeco2 — translucent circle bottom-left
            this.pnlDeco2.BackColor = System.Drawing.Color.Transparent;
            this.pnlDeco2.Location  = new System.Drawing.Point(-50, 340);
            this.pnlDeco2.Name      = "pnlDeco2";
            this.pnlDeco2.Size      = new System.Drawing.Size(160, 160);
            this.pnlDeco2.TabIndex  = 5;

            // lblBrand
            this.lblBrand.AutoSize  = false;
            this.lblBrand.Font      = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location  = new System.Drawing.Point(28, 156);
            this.lblBrand.Name      = "lblBrand";
            this.lblBrand.Size      = new System.Drawing.Size(248, 52);
            this.lblBrand.Text      = "SystemPOS";
            this.lblBrand.TabIndex  = 1;

            // lblBrandTagline
            this.lblBrandTagline.AutoSize  = false;
            this.lblBrandTagline.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBrandTagline.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblBrandTagline.Location  = new System.Drawing.Point(28, 218);
            this.lblBrandTagline.Name      = "lblBrandTagline";
            this.lblBrandTagline.Size      = new System.Drawing.Size(248, 64);
            this.lblBrandTagline.Text      = "Sistema de Punto de Venta\r\nModerno e inteligente\r\npara tu negocio.";
            this.lblBrandTagline.TabIndex  = 2;

            // lblBrandVersion
            this.lblBrandVersion.AutoSize  = false;
            this.lblBrandVersion.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBrandVersion.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblBrandVersion.Location  = new System.Drawing.Point(28, 430);
            this.lblBrandVersion.Name      = "lblBrandVersion";
            this.lblBrandVersion.Size      = new System.Drawing.Size(240, 16);
            this.lblBrandVersion.Text      = "v1.0  ·  © 2026 SystemPOS";
            this.lblBrandVersion.TabIndex  = 3;

            // ── pnlRight ──────────────────────────────────────────────────────
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.pbLogo);
            this.pnlRight.Controls.Add(this.lblBienvenido);
            this.pnlRight.Controls.Add(this.lblBienvenidoSub);
            this.pnlRight.Controls.Add(this.lblUsuario);
            this.pnlRight.Controls.Add(this.txtUsuario);
            this.pnlRight.Controls.Add(this.pnlLineUsuario);
            this.pnlRight.Controls.Add(this.lblContraseña);
            this.pnlRight.Controls.Add(this.pnlInputContra);
            this.pnlRight.Controls.Add(this.pnlLineContra);
            this.pnlRight.Controls.Add(this.btnIniciarSesion);
            this.pnlRight.Controls.Add(this.lnkOlvideContraseña);
            this.pnlRight.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Name     = "pnlRight";
            this.pnlRight.TabIndex = 11;

            // pbLogo — centered in 460 px right area
            this.pbLogo.Image    = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(180, 26);
            this.pbLogo.Name     = "pbLogo";
            this.pbLogo.Size     = new System.Drawing.Size(100, 52);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop  = false;

            // lblBienvenido
            this.lblBienvenido.AutoSize  = false;
            this.lblBienvenido.Font      = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblBienvenido.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblBienvenido.Location  = new System.Drawing.Point(70, 96);
            this.lblBienvenido.Name      = "lblBienvenido";
            this.lblBienvenido.Size      = new System.Drawing.Size(320, 40);
            this.lblBienvenido.Text      = "Iniciar Sesión";
            this.lblBienvenido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBienvenido.TabIndex  = 1;

            // lblBienvenidoSub
            this.lblBienvenidoSub.AutoSize  = false;
            this.lblBienvenidoSub.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBienvenidoSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblBienvenidoSub.Location  = new System.Drawing.Point(70, 138);
            this.lblBienvenidoSub.Name      = "lblBienvenidoSub";
            this.lblBienvenidoSub.Size      = new System.Drawing.Size(320, 20);
            this.lblBienvenidoSub.Text      = "Ingresa tus credenciales para continuar";
            this.lblBienvenidoSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBienvenidoSub.TabIndex  = 2;

            // lblUsuario
            this.lblUsuario.AutoSize  = true;
            this.lblUsuario.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblUsuario.Location  = new System.Drawing.Point(70, 178);
            this.lblUsuario.Name      = "lblUsuario";
            this.lblUsuario.TabIndex  = 3;
            this.lblUsuario.Text      = "USUARIO";

            // txtUsuario — underline style (no box border)
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsuario.ForeColor   = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtUsuario.Location    = new System.Drawing.Point(70, 198);
            this.txtUsuario.Name        = "txtUsuario";
            this.txtUsuario.Size        = new System.Drawing.Size(320, 26);
            this.txtUsuario.TabIndex    = 1;

            // pnlLineUsuario — bottom border for txtUsuario
            this.pnlLineUsuario.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlLineUsuario.Location  = new System.Drawing.Point(70, 227);
            this.pnlLineUsuario.Name      = "pnlLineUsuario";
            this.pnlLineUsuario.Size      = new System.Drawing.Size(320, 2);
            this.pnlLineUsuario.TabIndex  = 4;

            // lblContraseña
            this.lblContraseña.AutoSize  = true;
            this.lblContraseña.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblContraseña.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblContraseña.Location  = new System.Drawing.Point(70, 248);
            this.lblContraseña.Name      = "lblContraseña";
            this.lblContraseña.TabIndex  = 5;
            this.lblContraseña.Text      = "CONTRASEÑA";

            // pnlInputContra — row container: txtContraseña + btnMostrarClave
            this.pnlInputContra.BackColor = System.Drawing.Color.White;
            this.pnlInputContra.Location  = new System.Drawing.Point(70, 268);
            this.pnlInputContra.Name      = "pnlInputContra";
            this.pnlInputContra.Size      = new System.Drawing.Size(320, 28);
            this.pnlInputContra.TabIndex  = 6;
            this.pnlInputContra.Controls.Add(this.txtContraseña);
            this.pnlInputContra.Controls.Add(this.btnMostrarClave);

            // txtContraseña
            this.txtContraseña.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContraseña.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtContraseña.ForeColor   = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtContraseña.Location    = new System.Drawing.Point(0, 2);
            this.txtContraseña.Name        = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size        = new System.Drawing.Size(288, 26);
            this.txtContraseña.TabIndex    = 2;

            // btnMostrarClave
            this.btnMostrarClave.BackColor = System.Drawing.Color.White;
            this.btnMostrarClave.FlatAppearance.BorderSize = 0;
            this.btnMostrarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarClave.Font      = new System.Drawing.Font("Segoe UI", 11F);
            this.btnMostrarClave.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnMostrarClave.Location  = new System.Drawing.Point(290, 0);
            this.btnMostrarClave.Name      = "btnMostrarClave";
            this.btnMostrarClave.Size      = new System.Drawing.Size(30, 28);
            this.btnMostrarClave.TabIndex  = 8;
            this.btnMostrarClave.Text      = "👁";
            this.btnMostrarClave.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarClave.UseVisualStyleBackColor = false;

            // pnlLineContra — bottom border for txtContraseña
            this.pnlLineContra.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlLineContra.Location  = new System.Drawing.Point(70, 298);
            this.pnlLineContra.Name      = "pnlLineContra";
            this.pnlLineContra.Size      = new System.Drawing.Size(320, 2);
            this.pnlLineContra.TabIndex  = 7;

            // btnIniciarSesion
            this.btnIniciarSesion.BackColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.btnIniciarSesion.FlatAppearance.BorderSize = 0;
            this.btnIniciarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(79, 82, 221);
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIniciarSesion.ForeColor = System.Drawing.Color.White;
            this.btnIniciarSesion.Location  = new System.Drawing.Point(70, 324);
            this.btnIniciarSesion.Name      = "btnIniciarSesion";
            this.btnIniciarSesion.Size      = new System.Drawing.Size(320, 46);
            this.btnIniciarSesion.TabIndex  = 3;
            this.btnIniciarSesion.Text      = "INICIAR SESIÓN  →";
            this.btnIniciarSesion.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnIniciarSesion.UseVisualStyleBackColor = false;

            // lnkOlvideContraseña
            this.lnkOlvideContraseña.AutoSize  = false;
            this.lnkOlvideContraseña.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lnkOlvideContraseña.LinkColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.lnkOlvideContraseña.ActiveLinkColor = System.Drawing.Color.FromArgb(79, 82, 221);
            this.lnkOlvideContraseña.Location  = new System.Drawing.Point(70, 388);
            this.lnkOlvideContraseña.Name      = "lnkOlvideContraseña";
            this.lnkOlvideContraseña.Size      = new System.Drawing.Size(320, 20);
            this.lnkOlvideContraseña.TabIndex  = 9;
            this.lnkOlvideContraseña.TabStop   = true;
            this.lnkOlvideContraseña.Text      = "¿Olvidaste tu contraseña?";
            this.lnkOlvideContraseña.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Legacy hidden controls ─────────────────────────────────────────
            this.pnlCentral.Visible = false;
            this.pnlCentral.Size    = new System.Drawing.Size(1, 1);
            this.lblTitulo.Visible  = false;
            this.lblTitulo.Size     = new System.Drawing.Size(1, 1);
            this.lblIniciarSesion.Visible = false;
            this.lblIniciarSesion.Size    = new System.Drawing.Size(1, 1);

            // ── FormLogin ─────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor     = System.Drawing.Color.White;
            this.ClientSize    = new System.Drawing.Size(760, 460);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlCentral);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox   = false;
            this.MinimizeBox   = false;
            this.Name          = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text          = "SystemPOS — Iniciar Sesión";

            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlInputContra.ResumeLayout(false);
            this.pnlInputContra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // Left panel
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlAccentTop;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblBrandTagline;
        private System.Windows.Forms.Label lblBrandVersion;
        private System.Windows.Forms.Panel pnlDeco1;
        private System.Windows.Forms.Panel pnlDeco2;

        // Right panel
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Label lblBienvenidoSub;
        private System.Windows.Forms.Panel pnlLineUsuario;
        private System.Windows.Forms.Panel pnlInputContra;
        private System.Windows.Forms.Panel pnlLineContra;

        // Legacy (not used by .cs logic but kept for clean compile)
        private System.Windows.Forms.Panel pnlCentral;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblIniciarSesion;

        // Controls used by FormLogin.cs
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Button btnMostrarClave;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.LinkLabel lnkOlvideContraseña;
    }
}
