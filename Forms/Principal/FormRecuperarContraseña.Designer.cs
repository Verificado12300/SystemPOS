namespace SistemaPOS.Forms.Principal
{
    partial class FormRecuperarContraseña
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Header
            this.pnlHeader      = new System.Windows.Forms.Panel();
            this.pnlTopAccent   = new System.Windows.Forms.Panel();
            this.lblTituloPaso  = new System.Windows.Forms.Label();
            this.lblDescPaso    = new System.Windows.Forms.Label();
            this.pnlStepBar     = new System.Windows.Forms.Panel();
            this.lblStep1       = new System.Windows.Forms.Label();
            this.pnlLine12      = new System.Windows.Forms.Panel();
            this.lblStep2       = new System.Windows.Forms.Label();
            this.pnlLine23      = new System.Windows.Forms.Panel();
            this.lblStep3       = new System.Windows.Forms.Label();

            // Paso 1
            this.pnlPaso1         = new System.Windows.Forms.Panel();
            this.lblUsuarioBuscar = new System.Windows.Forms.Label();
            this.txtUsuarioBuscar = new System.Windows.Forms.TextBox();
            this.pnlLine1         = new System.Windows.Forms.Panel();

            // Paso 2
            this.pnlPaso2          = new System.Windows.Forms.Panel();
            this.lblInfoEmail      = new System.Windows.Forms.Label();
            this.lblEmailMascarado = new System.Windows.Forms.Label();
            this.lblCodigoLbl      = new System.Windows.Forms.Label();
            this.txtCodigo         = new System.Windows.Forms.TextBox();

            // Paso 3
            this.pnlPaso3            = new System.Windows.Forms.Panel();
            this.lblNuevaClaveLbl    = new System.Windows.Forms.Label();
            this.txtNuevaClave       = new System.Windows.Forms.TextBox();
            this.btnMostrarNueva     = new System.Windows.Forms.Button();
            this.pnlLineNueva        = new System.Windows.Forms.Panel();
            this.lblConfirmarLbl     = new System.Windows.Forms.Label();
            this.txtConfirmarClave   = new System.Windows.Forms.TextBox();
            this.btnMostrarConfirmar = new System.Windows.Forms.Button();
            this.pnlLineConfirmar    = new System.Windows.Forms.Panel();

            // Footer
            this.pnlFooter    = new System.Windows.Forms.Panel();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnCancelar  = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlStepBar.SuspendLayout();
            this.pnlPaso1.SuspendLayout();
            this.pnlPaso2.SuspendLayout();
            this.pnlPaso3.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ─────────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 100;
            this.pnlHeader.Controls.Add(this.pnlStepBar);
            this.pnlHeader.Controls.Add(this.lblDescPaso);
            this.pnlHeader.Controls.Add(this.lblTituloPaso);
            this.pnlHeader.Controls.Add(this.pnlTopAccent);

            // pnlTopAccent
            this.pnlTopAccent.BackColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.pnlTopAccent.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlTopAccent.Height    = 5;
            this.pnlTopAccent.Name      = "pnlTopAccent";
            this.pnlTopAccent.TabIndex  = 0;

            // lblTituloPaso
            this.lblTituloPaso.AutoSize  = true;
            this.lblTituloPaso.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloPaso.ForeColor = System.Drawing.Color.White;
            this.lblTituloPaso.Location  = new System.Drawing.Point(16, 14);
            this.lblTituloPaso.Name      = "lblTituloPaso";
            this.lblTituloPaso.Text      = "Recuperar Contraseña";
            this.lblTituloPaso.TabIndex  = 1;

            // lblDescPaso
            this.lblDescPaso.AutoSize  = false;
            this.lblDescPaso.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDescPaso.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblDescPaso.Location  = new System.Drawing.Point(16, 40);
            this.lblDescPaso.Name      = "lblDescPaso";
            this.lblDescPaso.Size      = new System.Drawing.Size(380, 18);
            this.lblDescPaso.Text      = "";
            this.lblDescPaso.TabIndex  = 2;

            // pnlStepBar — contenedor del indicador de pasos
            this.pnlStepBar.BackColor  = System.Drawing.Color.Transparent;
            this.pnlStepBar.Location   = new System.Drawing.Point(132, 65);
            this.pnlStepBar.Name       = "pnlStepBar";
            this.pnlStepBar.Size       = new System.Drawing.Size(160, 26);
            this.pnlStepBar.TabIndex   = 3;
            this.pnlStepBar.Controls.Add(this.lblStep1);
            this.pnlStepBar.Controls.Add(this.pnlLine12);
            this.pnlStepBar.Controls.Add(this.lblStep2);
            this.pnlStepBar.Controls.Add(this.pnlLine23);
            this.pnlStepBar.Controls.Add(this.lblStep3);

            // Círculos de paso (Labels 26×26)
            this.lblStep1.AutoSize   = false;
            this.lblStep1.BackColor  = System.Drawing.Color.FromArgb(99, 102, 241);
            this.lblStep1.Font       = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStep1.ForeColor  = System.Drawing.Color.White;
            this.lblStep1.Location   = new System.Drawing.Point(0, 0);
            this.lblStep1.Name       = "lblStep1";
            this.lblStep1.Size       = new System.Drawing.Size(26, 26);
            this.lblStep1.Text       = "1";
            this.lblStep1.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStep1.TabIndex   = 0;

            this.pnlLine12.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.pnlLine12.Location  = new System.Drawing.Point(28, 12);
            this.pnlLine12.Name      = "pnlLine12";
            this.pnlLine12.Size      = new System.Drawing.Size(40, 2);
            this.pnlLine12.TabIndex  = 1;

            this.lblStep2.AutoSize   = false;
            this.lblStep2.BackColor  = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblStep2.Font       = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStep2.ForeColor  = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblStep2.Location   = new System.Drawing.Point(70, 0);
            this.lblStep2.Name       = "lblStep2";
            this.lblStep2.Size       = new System.Drawing.Size(26, 26);
            this.lblStep2.Text       = "2";
            this.lblStep2.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStep2.TabIndex   = 2;

            this.pnlLine23.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.pnlLine23.Location  = new System.Drawing.Point(98, 12);
            this.pnlLine23.Name      = "pnlLine23";
            this.pnlLine23.Size      = new System.Drawing.Size(40, 2);
            this.pnlLine23.TabIndex  = 3;

            this.lblStep3.AutoSize   = false;
            this.lblStep3.BackColor  = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblStep3.Font       = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStep3.ForeColor  = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblStep3.Location   = new System.Drawing.Point(140, 0);
            this.lblStep3.Name       = "lblStep3";
            this.lblStep3.Size       = new System.Drawing.Size(26, 26);
            this.lblStep3.Text       = "3";
            this.lblStep3.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStep3.TabIndex   = 4;

            // ── pnlFooter ─────────────────────────────────────────────────────
            this.pnlFooter.BackColor   = System.Drawing.Color.White;
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Dock        = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height      = 56;
            this.pnlFooter.Controls.Add(this.btnCancelar);
            this.pnlFooter.Controls.Add(this.btnSiguiente);

            this.btnSiguiente.BackColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.btnSiguiente.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(79, 82, 221);
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSiguiente.ForeColor = System.Drawing.Color.White;
            this.btnSiguiente.Location  = new System.Drawing.Point(16, 12);
            this.btnSiguiente.Name      = "btnSiguiente";
            this.btnSiguiente.Size      = new System.Drawing.Size(186, 32);
            this.btnSiguiente.Text      = "Enviar Código";
            this.btnSiguiente.UseVisualStyleBackColor = false;

            this.btnCancelar.BackColor  = System.Drawing.Color.White;
            this.btnCancelar.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 210, 220);
            this.btnCancelar.FlatAppearance.BorderSize  = 1;
            this.btnCancelar.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font       = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelar.ForeColor  = System.Drawing.Color.FromArgb(80, 90, 100);
            this.btnCancelar.Location   = new System.Drawing.Point(214, 12);
            this.btnCancelar.Name       = "btnCancelar";
            this.btnCancelar.Size       = new System.Drawing.Size(110, 32);
            this.btnCancelar.Text       = "Cancelar";

            // ── Paso 1 ────────────────────────────────────────────────────────
            this.pnlPaso1.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlPaso1.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlPaso1.Controls.Add(this.pnlLine1);
            this.pnlPaso1.Controls.Add(this.txtUsuarioBuscar);
            this.pnlPaso1.Controls.Add(this.lblUsuarioBuscar);

            this.lblUsuarioBuscar.AutoSize  = true;
            this.lblUsuarioBuscar.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioBuscar.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblUsuarioBuscar.Location  = new System.Drawing.Point(30, 34);
            this.lblUsuarioBuscar.Name      = "lblUsuarioBuscar";
            this.lblUsuarioBuscar.Text      = "CORREO ELECTRÓNICO REGISTRADO";

            this.txtUsuarioBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuarioBuscar.Font        = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUsuarioBuscar.ForeColor   = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtUsuarioBuscar.Location    = new System.Drawing.Point(30, 58);
            this.txtUsuarioBuscar.Name        = "txtUsuarioBuscar";
            this.txtUsuarioBuscar.Size        = new System.Drawing.Size(328, 28);
            this.txtUsuarioBuscar.TabIndex    = 0;

            this.pnlLine1.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlLine1.Location  = new System.Drawing.Point(30, 88);
            this.pnlLine1.Name      = "pnlLine1";
            this.pnlLine1.Size      = new System.Drawing.Size(328, 2);
            this.pnlLine1.TabIndex  = 1;

            // ── Paso 2 ────────────────────────────────────────────────────────
            this.pnlPaso2.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlPaso2.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlPaso2.Visible   = false;
            this.pnlPaso2.Controls.Add(this.txtCodigo);
            this.pnlPaso2.Controls.Add(this.lblCodigoLbl);
            this.pnlPaso2.Controls.Add(this.lblEmailMascarado);
            this.pnlPaso2.Controls.Add(this.lblInfoEmail);

            this.lblInfoEmail.AutoSize  = true;
            this.lblInfoEmail.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfoEmail.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblInfoEmail.Location  = new System.Drawing.Point(30, 22);
            this.lblInfoEmail.Text      = "Código enviado a:";
            this.lblInfoEmail.TabIndex  = 0;

            this.lblEmailMascarado.AutoSize  = true;
            this.lblEmailMascarado.Font      = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblEmailMascarado.ForeColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.lblEmailMascarado.Location  = new System.Drawing.Point(30, 42);
            this.lblEmailMascarado.Name      = "lblEmailMascarado";
            this.lblEmailMascarado.Text      = "";
            this.lblEmailMascarado.TabIndex  = 1;

            this.lblCodigoLbl.AutoSize  = true;
            this.lblCodigoLbl.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCodigoLbl.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCodigoLbl.Location  = new System.Drawing.Point(30, 76);
            this.lblCodigoLbl.Text      = "CÓDIGO DE 6 DÍGITOS";
            this.lblCodigoLbl.TabIndex  = 2;

            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Font        = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.txtCodigo.ForeColor   = System.Drawing.Color.FromArgb(99, 102, 241);
            this.txtCodigo.Location    = new System.Drawing.Point(30, 98);
            this.txtCodigo.MaxLength   = 6;
            this.txtCodigo.Name        = "txtCodigo";
            this.txtCodigo.Size        = new System.Drawing.Size(170, 44);
            this.txtCodigo.TabIndex    = 0;
            this.txtCodigo.TextAlign   = System.Windows.Forms.HorizontalAlignment.Center;

            // ── Paso 3 ────────────────────────────────────────────────────────
            this.pnlPaso3.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlPaso3.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlPaso3.Visible   = false;
            this.pnlPaso3.Controls.Add(this.pnlLineConfirmar);
            this.pnlPaso3.Controls.Add(this.btnMostrarConfirmar);
            this.pnlPaso3.Controls.Add(this.txtConfirmarClave);
            this.pnlPaso3.Controls.Add(this.lblConfirmarLbl);
            this.pnlPaso3.Controls.Add(this.pnlLineNueva);
            this.pnlPaso3.Controls.Add(this.btnMostrarNueva);
            this.pnlPaso3.Controls.Add(this.txtNuevaClave);
            this.pnlPaso3.Controls.Add(this.lblNuevaClaveLbl);

            this.lblNuevaClaveLbl.AutoSize  = true;
            this.lblNuevaClaveLbl.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblNuevaClaveLbl.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblNuevaClaveLbl.Location  = new System.Drawing.Point(30, 20);
            this.lblNuevaClaveLbl.Text      = "NUEVA CONTRASEÑA";
            this.lblNuevaClaveLbl.TabIndex  = 0;

            this.txtNuevaClave.BorderStyle  = System.Windows.Forms.BorderStyle.None;
            this.txtNuevaClave.Font         = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNuevaClave.ForeColor    = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtNuevaClave.Location     = new System.Drawing.Point(30, 42);
            this.txtNuevaClave.Name         = "txtNuevaClave";
            this.txtNuevaClave.PasswordChar = '*';
            this.txtNuevaClave.Size         = new System.Drawing.Size(292, 26);
            this.txtNuevaClave.TabIndex     = 0;

            this.btnMostrarNueva.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarNueva.FlatAppearance.BorderSize = 0;
            this.btnMostrarNueva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarNueva.Font      = new System.Drawing.Font("Segoe UI", 11F);
            this.btnMostrarNueva.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnMostrarNueva.Location  = new System.Drawing.Point(326, 40);
            this.btnMostrarNueva.Name      = "btnMostrarNueva";
            this.btnMostrarNueva.Size      = new System.Drawing.Size(30, 30);
            this.btnMostrarNueva.Text      = "👁";
            this.btnMostrarNueva.TabIndex  = 1;

            this.pnlLineNueva.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlLineNueva.Location  = new System.Drawing.Point(30, 70);
            this.pnlLineNueva.Name      = "pnlLineNueva";
            this.pnlLineNueva.Size      = new System.Drawing.Size(328, 2);
            this.pnlLineNueva.TabIndex  = 2;

            this.lblConfirmarLbl.AutoSize  = true;
            this.lblConfirmarLbl.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblConfirmarLbl.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblConfirmarLbl.Location  = new System.Drawing.Point(30, 86);
            this.lblConfirmarLbl.Text      = "CONFIRMAR CONTRASEÑA";
            this.lblConfirmarLbl.TabIndex  = 3;

            this.txtConfirmarClave.BorderStyle  = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmarClave.Font         = new System.Drawing.Font("Segoe UI", 12F);
            this.txtConfirmarClave.ForeColor    = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtConfirmarClave.Location     = new System.Drawing.Point(30, 108);
            this.txtConfirmarClave.Name         = "txtConfirmarClave";
            this.txtConfirmarClave.PasswordChar = '*';
            this.txtConfirmarClave.Size         = new System.Drawing.Size(292, 26);
            this.txtConfirmarClave.TabIndex     = 2;

            this.btnMostrarConfirmar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarConfirmar.FlatAppearance.BorderSize = 0;
            this.btnMostrarConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarConfirmar.Font      = new System.Drawing.Font("Segoe UI", 11F);
            this.btnMostrarConfirmar.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnMostrarConfirmar.Location  = new System.Drawing.Point(326, 106);
            this.btnMostrarConfirmar.Name      = "btnMostrarConfirmar";
            this.btnMostrarConfirmar.Size      = new System.Drawing.Size(30, 30);
            this.btnMostrarConfirmar.Text      = "👁";
            this.btnMostrarConfirmar.TabIndex  = 3;

            this.pnlLineConfirmar.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlLineConfirmar.Location  = new System.Drawing.Point(30, 136);
            this.pnlLineConfirmar.Name      = "pnlLineConfirmar";
            this.pnlLineConfirmar.Size      = new System.Drawing.Size(328, 2);
            this.pnlLineConfirmar.TabIndex  = 4;

            // ── Form ──────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize          = new System.Drawing.Size(420, 340);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.Name                = "FormRecuperarContraseña";
            this.ShowIcon            = false;
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Recuperar Contraseña";

            this.Controls.Add(this.pnlPaso1);
            this.Controls.Add(this.pnlPaso2);
            this.Controls.Add(this.pnlPaso3);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlStepBar.ResumeLayout(false);
            this.pnlPaso1.ResumeLayout(false);
            this.pnlPaso1.PerformLayout();
            this.pnlPaso2.ResumeLayout(false);
            this.pnlPaso2.PerformLayout();
            this.pnlPaso3.ResumeLayout(false);
            this.pnlPaso3.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // Header
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlTopAccent;
        private System.Windows.Forms.Label lblTituloPaso;
        private System.Windows.Forms.Label lblDescPaso;
        private System.Windows.Forms.Panel pnlStepBar;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Panel pnlLine12;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.Panel pnlLine23;
        private System.Windows.Forms.Label lblStep3;

        // Paso 1
        private System.Windows.Forms.Panel pnlPaso1;
        private System.Windows.Forms.Label lblUsuarioBuscar;
        private System.Windows.Forms.TextBox txtUsuarioBuscar;
        private System.Windows.Forms.Panel pnlLine1;

        // Paso 2
        private System.Windows.Forms.Panel pnlPaso2;
        private System.Windows.Forms.Label lblInfoEmail;
        private System.Windows.Forms.Label lblEmailMascarado;
        private System.Windows.Forms.Label lblCodigoLbl;
        private System.Windows.Forms.TextBox txtCodigo;

        // Paso 3
        private System.Windows.Forms.Panel pnlPaso3;
        private System.Windows.Forms.Label lblNuevaClaveLbl;
        private System.Windows.Forms.TextBox txtNuevaClave;
        private System.Windows.Forms.Button btnMostrarNueva;
        private System.Windows.Forms.Panel pnlLineNueva;
        private System.Windows.Forms.Label lblConfirmarLbl;
        private System.Windows.Forms.TextBox txtConfirmarClave;
        private System.Windows.Forms.Button btnMostrarConfirmar;
        private System.Windows.Forms.Panel pnlLineConfirmar;

        // Footer
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnCancelar;
    }
}
