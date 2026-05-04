namespace SistemaPOS.Forms.Contactos
{
    partial class FormClienteDetalle
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
            // ── Declaraciones ─────────────────────────────────────────────
            this.pnlHeader          = new System.Windows.Forms.Panel();
            this.lblTitulo          = new System.Windows.Forms.Label();
            this.lblHeaderSub       = new System.Windows.Forms.Label();

            this.pnlFooter          = new System.Windows.Forms.Panel();
            this.btnGuardar         = new System.Windows.Forms.Button();
            this.btnCancelar        = new System.Windows.Forms.Button();

            this.pnlBody            = new System.Windows.Forms.Panel();

            // Sección 1 — Identificación
            this.pnlIdent           = new System.Windows.Forms.Panel();
            this.pnlAccentIdent     = new System.Windows.Forms.Panel();
            this.lblSecIdent        = new System.Windows.Forms.Label();
            this.lblTipoDoc         = new System.Windows.Forms.Label();
            this.rbDNI              = new System.Windows.Forms.RadioButton();
            this.rbRUC              = new System.Windows.Forms.RadioButton();
            this.rbCEE              = new System.Windows.Forms.RadioButton();
            this.lblNumeroDoc       = new System.Windows.Forms.Label();
            this.txtNumeroDoc       = new System.Windows.Forms.TextBox();
            this.btnBuscar          = new System.Windows.Forms.Button();
            this.lblNombres         = new System.Windows.Forms.Label();
            this.txtNombres         = new System.Windows.Forms.TextBox();
            this.lblApellidos       = new System.Windows.Forms.Label();
            this.txtApellidos       = new System.Windows.Forms.TextBox();
            this.lblRazonSocial     = new System.Windows.Forms.Label();
            this.txtRazonSocial     = new System.Windows.Forms.TextBox();

            // Sección 2 — Contacto
            this.pnlContacto        = new System.Windows.Forms.Panel();
            this.pnlAccentContacto  = new System.Windows.Forms.Panel();
            this.lblSecContacto     = new System.Windows.Forms.Label();
            this.lblDireccion       = new System.Windows.Forms.Label();
            this.txtDireccion       = new System.Windows.Forms.TextBox();
            this.lblTelefono        = new System.Windows.Forms.Label();
            this.txtTelefono        = new System.Windows.Forms.TextBox();
            this.lblEmail           = new System.Windows.Forms.Label();
            this.txtEmail           = new System.Windows.Forms.TextBox();

            // Sección 3 — Crédito
            this.pnlCredito         = new System.Windows.Forms.Panel();
            this.pnlAccentCredito   = new System.Windows.Forms.Panel();
            this.lblSecCredito      = new System.Windows.Forms.Label();
            this.lblLimiteCredito   = new System.Windows.Forms.Label();
            this.txtLimiteCredito   = new System.Windows.Forms.TextBox();
            this.lblCeroSoloContado = new System.Windows.Forms.Label();
            this.chkClienteActivo   = new System.Windows.Forms.CheckBox();
            this.lblDetalle         = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlIdent.SuspendLayout();
            this.pnlContacto.SuspendLayout();
            this.pnlCredito.SuspendLayout();
            this.SuspendLayout();

            // ════════════════════════════════════════════════════════
            // pnlHeader  Dock=Top  68px
            // ════════════════════════════════════════════════════════
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 68;
            this.pnlHeader.TabIndex  = 0;

            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(22, 12);
            this.lblTitulo.Text      = "Nuevo Cliente";

            this.lblHeaderSub.AutoSize  = true;
            this.lblHeaderSub.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.lblHeaderSub.Location  = new System.Drawing.Point(24, 42);
            this.lblHeaderSub.Text      = "Complete los datos del cliente";

            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Controls.Add(this.lblTitulo);

            // ════════════════════════════════════════════════════════
            // pnlFooter  Dock=Bottom  56px
            // ════════════════════════════════════════════════════════
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height    = 56;
            this.pnlFooter.TabIndex  = 1;

            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.btnGuardar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(55, 80, 200);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location  = new System.Drawing.Point(460, 11);
            this.btnGuardar.Size      = new System.Drawing.Size(148, 34);
            this.btnGuardar.TabIndex  = 0;
            this.btnGuardar.Text      = "💾  Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;

            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.btnCancelar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(75, 85, 90);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location  = new System.Drawing.Point(620, 11);
            this.btnCancelar.Size      = new System.Drawing.Size(120, 34);
            this.btnCancelar.TabIndex  = 1;
            this.btnCancelar.Text      = "✕  Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;

            this.pnlFooter.Controls.Add(this.btnGuardar);
            this.pnlFooter.Controls.Add(this.btnCancelar);

            // ════════════════════════════════════════════════════════
            // pnlBody  Dock=Fill  bg (240,242,245)  AutoScroll
            // ════════════════════════════════════════════════════════
            this.pnlBody.AutoScroll = true;
            this.pnlBody.BackColor  = System.Drawing.Color.FromArgb(240, 242, 245);
            this.pnlBody.Dock       = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.TabIndex   = 2;

            // ════════════════════════════════════════════════════════
            // SECCIÓN 1 — IDENTIFICACIÓN
            // Card blanca, barra acento azul (67,97,238)
            // ════════════════════════════════════════════════════════
            this.pnlIdent.BackColor = System.Drawing.Color.White;
            this.pnlIdent.Location  = new System.Drawing.Point(14, 14);
            this.pnlIdent.Size      = new System.Drawing.Size(714, 226);
            this.pnlIdent.TabIndex  = 10;

            this.pnlAccentIdent.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.pnlAccentIdent.Location  = new System.Drawing.Point(0, 0);
            this.pnlAccentIdent.Size      = new System.Drawing.Size(5, 226);
            this.pnlAccentIdent.TabIndex  = 0;

            this.lblSecIdent.AutoSize  = false;
            this.lblSecIdent.Size      = new System.Drawing.Size(400, 26);
            this.lblSecIdent.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSecIdent.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblSecIdent.Location  = new System.Drawing.Point(18, 12);
            this.lblSecIdent.Text      = "🪪  IDENTIFICACIÓN";

            this.lblTipoDoc.AutoSize  = true;
            this.lblTipoDoc.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipoDoc.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblTipoDoc.Location  = new System.Drawing.Point(18, 50);
            this.lblTipoDoc.Text      = "Tipo documento";

            this.rbDNI.AutoSize  = true;
            this.rbDNI.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rbDNI.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.rbDNI.Location  = new System.Drawing.Point(138, 48);
            this.rbDNI.TabIndex  = 1;
            this.rbDNI.Text      = "DNI";
            this.rbDNI.UseVisualStyleBackColor = true;

            this.rbRUC.AutoSize  = true;
            this.rbRUC.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rbRUC.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.rbRUC.Location  = new System.Drawing.Point(204, 48);
            this.rbRUC.TabIndex  = 2;
            this.rbRUC.Text      = "RUC";
            this.rbRUC.UseVisualStyleBackColor = true;

            this.rbCEE.AutoSize  = true;
            this.rbCEE.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rbCEE.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.rbCEE.Location  = new System.Drawing.Point(272, 48);
            this.rbCEE.TabIndex  = 3;
            this.rbCEE.Text      = "CEE";
            this.rbCEE.UseVisualStyleBackColor = true;

            this.lblNumeroDoc.AutoSize  = true;
            this.lblNumeroDoc.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNumeroDoc.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblNumeroDoc.Location  = new System.Drawing.Point(18, 84);
            this.lblNumeroDoc.Text      = "N° Documento";

            this.txtNumeroDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroDoc.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNumeroDoc.Location    = new System.Drawing.Point(138, 81);
            this.txtNumeroDoc.Size        = new System.Drawing.Size(210, 24);
            this.txtNumeroDoc.TabIndex    = 4;

            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.btnBuscar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 205, 215);
            this.btnBuscar.FlatAppearance.BorderSize  = 1;
            this.btnBuscar.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font       = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBuscar.ForeColor  = System.Drawing.Color.FromArgb(67, 97, 238);
            this.btnBuscar.Location   = new System.Drawing.Point(356, 81);
            this.btnBuscar.Size       = new System.Drawing.Size(108, 24);
            this.btnBuscar.TabIndex   = 5;
            this.btnBuscar.Text       = "🔍  Consultar";
            this.btnBuscar.UseVisualStyleBackColor = false;

            this.lblNombres.AutoSize  = true;
            this.lblNombres.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombres.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblNombres.Location  = new System.Drawing.Point(18, 120);
            this.lblNombres.Text      = "Nombres";

            this.txtNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombres.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombres.Location    = new System.Drawing.Point(138, 117);
            this.txtNombres.Size        = new System.Drawing.Size(558, 24);
            this.txtNombres.TabIndex    = 6;

            this.lblApellidos.AutoSize  = true;
            this.lblApellidos.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblApellidos.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblApellidos.Location  = new System.Drawing.Point(18, 156);
            this.lblApellidos.Text      = "Apellidos";

            this.txtApellidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidos.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtApellidos.Location    = new System.Drawing.Point(138, 153);
            this.txtApellidos.Size        = new System.Drawing.Size(558, 24);
            this.txtApellidos.TabIndex    = 7;

            this.lblRazonSocial.AutoSize  = true;
            this.lblRazonSocial.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRazonSocial.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblRazonSocial.Location  = new System.Drawing.Point(18, 192);
            this.lblRazonSocial.Text      = "Razón Social";

            this.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRazonSocial.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRazonSocial.Location    = new System.Drawing.Point(138, 189);
            this.txtRazonSocial.Size        = new System.Drawing.Size(558, 24);
            this.txtRazonSocial.TabIndex    = 8;

            this.pnlIdent.Controls.Add(this.txtRazonSocial);
            this.pnlIdent.Controls.Add(this.lblRazonSocial);
            this.pnlIdent.Controls.Add(this.txtApellidos);
            this.pnlIdent.Controls.Add(this.lblApellidos);
            this.pnlIdent.Controls.Add(this.txtNombres);
            this.pnlIdent.Controls.Add(this.lblNombres);
            this.pnlIdent.Controls.Add(this.btnBuscar);
            this.pnlIdent.Controls.Add(this.txtNumeroDoc);
            this.pnlIdent.Controls.Add(this.lblNumeroDoc);
            this.pnlIdent.Controls.Add(this.rbCEE);
            this.pnlIdent.Controls.Add(this.rbRUC);
            this.pnlIdent.Controls.Add(this.rbDNI);
            this.pnlIdent.Controls.Add(this.lblTipoDoc);
            this.pnlIdent.Controls.Add(this.lblSecIdent);
            this.pnlIdent.Controls.Add(this.pnlAccentIdent);

            // ════════════════════════════════════════════════════════
            // SECCIÓN 2 — CONTACTO
            // Card blanca, barra acento verde (39,174,96)
            // ════════════════════════════════════════════════════════
            this.pnlContacto.BackColor = System.Drawing.Color.White;
            this.pnlContacto.Location  = new System.Drawing.Point(14, 252);
            this.pnlContacto.Size      = new System.Drawing.Size(714, 148);
            this.pnlContacto.TabIndex  = 20;

            this.pnlAccentContacto.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.pnlAccentContacto.Location  = new System.Drawing.Point(0, 0);
            this.pnlAccentContacto.Size      = new System.Drawing.Size(5, 148);
            this.pnlAccentContacto.TabIndex  = 0;

            this.lblSecContacto.AutoSize  = false;
            this.lblSecContacto.Size      = new System.Drawing.Size(300, 26);
            this.lblSecContacto.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSecContacto.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblSecContacto.Location  = new System.Drawing.Point(18, 12);
            this.lblSecContacto.Text      = "📞  CONTACTO";

            this.lblDireccion.AutoSize  = true;
            this.lblDireccion.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblDireccion.Location  = new System.Drawing.Point(18, 50);
            this.lblDireccion.Text      = "Dirección";

            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDireccion.Location    = new System.Drawing.Point(138, 47);
            this.txtDireccion.Size        = new System.Drawing.Size(558, 24);
            this.txtDireccion.TabIndex    = 10;

            this.lblTelefono.AutoSize  = true;
            this.lblTelefono.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblTelefono.Location  = new System.Drawing.Point(18, 88);
            this.lblTelefono.Text      = "Teléfono";

            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTelefono.Location    = new System.Drawing.Point(138, 85);
            this.txtTelefono.Size        = new System.Drawing.Size(200, 24);
            this.txtTelefono.TabIndex    = 11;

            this.lblEmail.AutoSize  = true;
            this.lblEmail.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblEmail.Location  = new System.Drawing.Point(360, 88);
            this.lblEmail.Text      = "Email";

            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEmail.Location    = new System.Drawing.Point(414, 85);
            this.txtEmail.Size        = new System.Drawing.Size(282, 24);
            this.txtEmail.TabIndex    = 12;

            this.pnlContacto.Controls.Add(this.txtEmail);
            this.pnlContacto.Controls.Add(this.lblEmail);
            this.pnlContacto.Controls.Add(this.txtTelefono);
            this.pnlContacto.Controls.Add(this.lblTelefono);
            this.pnlContacto.Controls.Add(this.txtDireccion);
            this.pnlContacto.Controls.Add(this.lblDireccion);
            this.pnlContacto.Controls.Add(this.lblSecContacto);
            this.pnlContacto.Controls.Add(this.pnlAccentContacto);

            // ════════════════════════════════════════════════════════
            // SECCIÓN 3 — CRÉDITO Y ESTADO
            // Card blanca, barra acento ámbar (243,156,18)
            // ════════════════════════════════════════════════════════
            this.pnlCredito.BackColor = System.Drawing.Color.White;
            this.pnlCredito.Location  = new System.Drawing.Point(14, 412);
            this.pnlCredito.Size      = new System.Drawing.Size(714, 148);
            this.pnlCredito.TabIndex  = 30;

            this.pnlAccentCredito.BackColor = System.Drawing.Color.FromArgb(243, 156, 18);
            this.pnlAccentCredito.Location  = new System.Drawing.Point(0, 0);
            this.pnlAccentCredito.Size      = new System.Drawing.Size(5, 148);
            this.pnlAccentCredito.TabIndex  = 0;

            this.lblSecCredito.AutoSize  = false;
            this.lblSecCredito.Size      = new System.Drawing.Size(300, 26);
            this.lblSecCredito.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSecCredito.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblSecCredito.Location  = new System.Drawing.Point(18, 12);
            this.lblSecCredito.Text      = "💳  CRÉDITO Y ESTADO";

            this.lblLimiteCredito.AutoSize  = true;
            this.lblLimiteCredito.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLimiteCredito.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblLimiteCredito.Location  = new System.Drawing.Point(18, 52);
            this.lblLimiteCredito.Text      = "Límite crédito (S/)";

            this.txtLimiteCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLimiteCredito.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtLimiteCredito.Location    = new System.Drawing.Point(160, 49);
            this.txtLimiteCredito.Size        = new System.Drawing.Size(90, 24);
            this.txtLimiteCredito.TabIndex    = 20;

            this.lblCeroSoloContado.AutoSize  = true;
            this.lblCeroSoloContado.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCeroSoloContado.ForeColor = System.Drawing.Color.FromArgb(130, 140, 145);
            this.lblCeroSoloContado.Location  = new System.Drawing.Point(262, 52);
            this.lblCeroSoloContado.Text      = "S/ 0 = solo contado";

            this.chkClienteActivo.AutoSize  = true;
            this.chkClienteActivo.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkClienteActivo.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.chkClienteActivo.Location  = new System.Drawing.Point(18, 90);
            this.chkClienteActivo.TabIndex  = 21;
            this.chkClienteActivo.Text      = "Cliente activo";
            this.chkClienteActivo.UseVisualStyleBackColor = true;

            this.lblDetalle.AutoSize  = false;
            this.lblDetalle.Size      = new System.Drawing.Size(668, 30);
            this.lblDetalle.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(150, 160, 165);
            this.lblDetalle.Location  = new System.Drawing.Point(18, 116);
            this.lblDetalle.Text      = "ℹ  Monto máximo que este cliente puede deber a crédito. S/ 0 = solo contado; si excede el límite no podrá comprar a crédito.";

            this.pnlCredito.Controls.Add(this.lblDetalle);
            this.pnlCredito.Controls.Add(this.chkClienteActivo);
            this.pnlCredito.Controls.Add(this.lblCeroSoloContado);
            this.pnlCredito.Controls.Add(this.txtLimiteCredito);
            this.pnlCredito.Controls.Add(this.lblLimiteCredito);
            this.pnlCredito.Controls.Add(this.lblSecCredito);
            this.pnlCredito.Controls.Add(this.pnlAccentCredito);

            // ════════════════════════════════════════════════════════
            // pnlBody — agregar cards
            // ════════════════════════════════════════════════════════
            this.pnlBody.Controls.Add(this.pnlIdent);
            this.pnlBody.Controls.Add(this.pnlContacto);
            this.pnlBody.Controls.Add(this.pnlCredito);

            // ════════════════════════════════════════════════════════
            // Form
            // ════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize          = new System.Drawing.Size(760, 640);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.Name                = "FormClienteDetalle";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Cliente";

            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlIdent.ResumeLayout(false);
            this.pnlIdent.PerformLayout();
            this.pnlContacto.ResumeLayout(false);
            this.pnlContacto.PerformLayout();
            this.pnlCredito.ResumeLayout(false);
            this.pnlCredito.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel  pnlHeader;
        private System.Windows.Forms.Label  lblTitulo;
        private System.Windows.Forms.Label  lblHeaderSub;

        private System.Windows.Forms.Panel  pnlFooter;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        private System.Windows.Forms.Panel  pnlBody;

        // Identificación
        private System.Windows.Forms.Panel       pnlIdent;
        private System.Windows.Forms.Panel       pnlAccentIdent;
        private System.Windows.Forms.Label       lblSecIdent;
        private System.Windows.Forms.Label       lblTipoDoc;
        private System.Windows.Forms.RadioButton rbDNI;
        private System.Windows.Forms.RadioButton rbRUC;
        private System.Windows.Forms.RadioButton rbCEE;
        private System.Windows.Forms.Label       lblNumeroDoc;
        private System.Windows.Forms.TextBox     txtNumeroDoc;
        private System.Windows.Forms.Button      btnBuscar;
        private System.Windows.Forms.Label       lblNombres;
        private System.Windows.Forms.TextBox     txtNombres;
        private System.Windows.Forms.Label       lblApellidos;
        private System.Windows.Forms.TextBox     txtApellidos;
        private System.Windows.Forms.Label       lblRazonSocial;
        private System.Windows.Forms.TextBox     txtRazonSocial;

        // Contacto
        private System.Windows.Forms.Panel   pnlContacto;
        private System.Windows.Forms.Panel   pnlAccentContacto;
        private System.Windows.Forms.Label   lblSecContacto;
        private System.Windows.Forms.Label   lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label   lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label   lblEmail;
        private System.Windows.Forms.TextBox txtEmail;

        // Crédito
        private System.Windows.Forms.Panel    pnlCredito;
        private System.Windows.Forms.Panel    pnlAccentCredito;
        private System.Windows.Forms.Label    lblSecCredito;
        private System.Windows.Forms.Label    lblLimiteCredito;
        private System.Windows.Forms.TextBox  txtLimiteCredito;
        private System.Windows.Forms.Label    lblCeroSoloContado;
        private System.Windows.Forms.CheckBox chkClienteActivo;
        private System.Windows.Forms.Label    lblDetalle;
    }
}
