namespace SistemaPOS.Forms.Configuracion
{
    partial class FormImpresoras
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlImpresora = new System.Windows.Forms.Panel();
            this.btnGuardarConfiguracion = new System.Windows.Forms.Button();
            this.btnImprimirPrueba = new System.Windows.Forms.Button();
            this.cmbImpresoraPredeterminada = new System.Windows.Forms.ComboBox();
            this.btnConfigurarImpresora = new System.Windows.Forms.Button();
            this.lblSubTitulo = new System.Windows.Forms.Label();
            this.lblCodigoLicencia = new System.Windows.Forms.Label();
            this.lblSubTitulo2 = new System.Windows.Forms.Label();
            this.pnlContenidoTicket = new System.Windows.Forms.Panel();
            this.txtMensajePie2 = new System.Windows.Forms.TextBox();
            this.chkMostrarInfoPago = new System.Windows.Forms.CheckBox();
            this.chkMostrarQR = new System.Windows.Forms.CheckBox();
            this.lblMensajePie = new System.Windows.Forms.Label();
            this.txtMensajePie1 = new System.Windows.Forms.TextBox();
            this.chkMostrarDNI = new System.Windows.Forms.CheckBox();
            this.chkMostrarPie = new System.Windows.Forms.CheckBox();
            this.chkMostrarEmail = new System.Windows.Forms.CheckBox();
            this.chkMostrarTelefono = new System.Windows.Forms.CheckBox();
            this.chkMostrarDireccion = new System.Windows.Forms.CheckBox();
            this.chkMostrarRUC = new System.Windows.Forms.CheckBox();
            this.chkMostrarNombre = new System.Windows.Forms.CheckBox();
            this.chkMostrarLogo = new System.Windows.Forms.CheckBox();
            this.pnlOpcionesImpresion = new System.Windows.Forms.Panel();
            this.nudMargenInferior = new System.Windows.Forms.NumericUpDown();
            this.lblMargenInferior = new System.Windows.Forms.Label();
            this.nudMargenSuperior = new System.Windows.Forms.NumericUpDown();
            this.lblMargenSuperior = new System.Windows.Forms.Label();
            this.nudMargenDerecho = new System.Windows.Forms.NumericUpDown();
            this.lblMargenDerecho = new System.Windows.Forms.Label();
            this.nudMargenIzquierdo = new System.Windows.Forms.NumericUpDown();
            this.lblMargenIzquierdo = new System.Windows.Forms.Label();
            this.lblMargenes = new System.Windows.Forms.Label();
            this.nudEscalaAjuste = new System.Windows.Forms.NumericUpDown();
            this.lblEscalaAjuste = new System.Windows.Forms.Label();
            this.nudAnchoPersonalizado = new System.Windows.Forms.NumericUpDown();
            this.lblAnchoPersonalizado = new System.Windows.Forms.Label();
            this.lblOscuro = new System.Windows.Forms.Label();
            this.lblClaro = new System.Windows.Forms.Label();
            this.cmbEspaciadoLineas = new System.Windows.Forms.ComboBox();
            this.lblEspaciadoLineas = new System.Windows.Forms.Label();
            this.chkSonidoImprimir = new System.Windows.Forms.CheckBox();
            this.lblDensidad = new System.Windows.Forms.Label();
            this.chkCortaPapel = new System.Windows.Forms.CheckBox();
            this.tbDensidad = new System.Windows.Forms.TrackBar();
            this.cmbAnchoPapel = new System.Windows.Forms.ComboBox();
            this.lblAnchoPapel = new System.Windows.Forms.Label();
            this.cmbNumeroCopias = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNumeroCopias = new System.Windows.Forms.Label();
            this.lblVistaPrevia = new System.Windows.Forms.Label();
            this.pnlVistaTicket = new SistemaPOS.Controls.TicketDesignPanel();
            this.pnlImpresora.SuspendLayout();
            this.pnlContenidoTicket.SuspendLayout();
            this.pnlOpcionesImpresion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargenInferior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargenSuperior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargenDerecho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargenIzquierdo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEscalaAjuste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnchoPersonalizado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDensidad)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblTitulo.Location = new System.Drawing.Point(16, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(308, 30);
            this.lblTitulo.TabIndex = 66;
            this.lblTitulo.Text = "Impresion de Comprobantes";
            // 
            // pnlImpresora
            // 
            this.pnlImpresora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlImpresora.BackColor = System.Drawing.Color.White;
            this.pnlImpresora.Controls.Add(this.btnGuardarConfiguracion);
            this.pnlImpresora.Controls.Add(this.btnImprimirPrueba);
            this.pnlImpresora.Controls.Add(this.cmbImpresoraPredeterminada);
            this.pnlImpresora.Controls.Add(this.btnConfigurarImpresora);
            this.pnlImpresora.Controls.Add(this.lblSubTitulo);
            this.pnlImpresora.Controls.Add(this.lblCodigoLicencia);
            this.pnlImpresora.Location = new System.Drawing.Point(16, 58);
            this.pnlImpresora.Name = "pnlImpresora";
            this.pnlImpresora.Size = new System.Drawing.Size(856, 116);
            this.pnlImpresora.TabIndex = 67;
            // 
            // btnGuardarConfiguracion
            // 
            this.btnGuardarConfiguracion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarConfiguracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(222)))));
            this.btnGuardarConfiguracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarConfiguracion.FlatAppearance.BorderSize = 0;
            this.btnGuardarConfiguracion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(120)))), ((int)(((byte)(201)))));
            this.btnGuardarConfiguracion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnGuardarConfiguracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarConfiguracion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardarConfiguracion.ForeColor = System.Drawing.Color.White;
            this.btnGuardarConfiguracion.Location = new System.Drawing.Point(694, 17);
            this.btnGuardarConfiguracion.Name = "btnGuardarConfiguracion";
            this.btnGuardarConfiguracion.Size = new System.Drawing.Size(145, 34);
            this.btnGuardarConfiguracion.TabIndex = 64;
            this.btnGuardarConfiguracion.Text = "Guardar Cambios";
            this.btnGuardarConfiguracion.UseVisualStyleBackColor = false;
            // 
            // btnImprimirPrueba
            // 
            this.btnImprimirPrueba.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimirPrueba.BackColor = System.Drawing.Color.White;
            this.btnImprimirPrueba.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimirPrueba.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.btnImprimirPrueba.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnImprimirPrueba.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirPrueba.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnImprimirPrueba.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnImprimirPrueba.Location = new System.Drawing.Point(694, 57);
            this.btnImprimirPrueba.Name = "btnImprimirPrueba";
            this.btnImprimirPrueba.Size = new System.Drawing.Size(145, 34);
            this.btnImprimirPrueba.TabIndex = 63;
            this.btnImprimirPrueba.Text = "Imprimir Prueba";
            this.btnImprimirPrueba.UseVisualStyleBackColor = false;
            // 
            // cmbImpresoraPredeterminada
            // 
            this.cmbImpresoraPredeterminada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImpresoraPredeterminada.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbImpresoraPredeterminada.FormattingEnabled = true;
            this.cmbImpresoraPredeterminada.Location = new System.Drawing.Point(203, 61);
            this.cmbImpresoraPredeterminada.Name = "cmbImpresoraPredeterminada";
            this.cmbImpresoraPredeterminada.Size = new System.Drawing.Size(283, 23);
            this.cmbImpresoraPredeterminada.TabIndex = 62;
            // 
            // btnConfigurarImpresora
            // 
            this.btnConfigurarImpresora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfigurarImpresora.BackColor = System.Drawing.Color.White;
            this.btnConfigurarImpresora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfigurarImpresora.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.btnConfigurarImpresora.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnConfigurarImpresora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigurarImpresora.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnConfigurarImpresora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnConfigurarImpresora.Location = new System.Drawing.Point(543, 57);
            this.btnConfigurarImpresora.Name = "btnConfigurarImpresora";
            this.btnConfigurarImpresora.Size = new System.Drawing.Size(145, 34);
            this.btnConfigurarImpresora.TabIndex = 61;
            this.btnConfigurarImpresora.Text = "Preferencias";
            this.btnConfigurarImpresora.UseVisualStyleBackColor = false;
            // 
            // lblSubTitulo
            // 
            this.lblSubTitulo.AutoSize = true;
            this.lblSubTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubTitulo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSubTitulo.Location = new System.Drawing.Point(15, 14);
            this.lblSubTitulo.Name = "lblSubTitulo";
            this.lblSubTitulo.Size = new System.Drawing.Size(145, 20);
            this.lblSubTitulo.TabIndex = 12;
            this.lblSubTitulo.Text = "Impresora Principal";
            // 
            // lblCodigoLicencia
            // 
            this.lblCodigoLicencia.AutoSize = true;
            this.lblCodigoLicencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCodigoLicencia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoLicencia.Location = new System.Drawing.Point(16, 64);
            this.lblCodigoLicencia.Name = "lblCodigoLicencia";
            this.lblCodigoLicencia.Size = new System.Drawing.Size(150, 15);
            this.lblCodigoLicencia.TabIndex = 47;
            this.lblCodigoLicencia.Text = "Impresora predeterminada:";
            // 
            // lblSubTitulo2
            // 
            this.lblSubTitulo2.AutoSize = true;
            this.lblSubTitulo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubTitulo2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitulo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSubTitulo2.Location = new System.Drawing.Point(16, 14);
            this.lblSubTitulo2.Name = "lblSubTitulo2";
            this.lblSubTitulo2.Size = new System.Drawing.Size(152, 20);
            this.lblSubTitulo2.TabIndex = 12;
            this.lblSubTitulo2.Text = "Contenido del Ticket";
            // 
            // pnlContenidoTicket
            // 
            this.pnlContenidoTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContenidoTicket.BackColor = System.Drawing.Color.White;
            this.pnlContenidoTicket.Controls.Add(this.txtMensajePie2);
            this.pnlContenidoTicket.Controls.Add(this.chkMostrarInfoPago);
            this.pnlContenidoTicket.Controls.Add(this.chkMostrarQR);
            this.pnlContenidoTicket.Controls.Add(this.lblMensajePie);
            this.pnlContenidoTicket.Controls.Add(this.txtMensajePie1);
            this.pnlContenidoTicket.Controls.Add(this.chkMostrarDNI);
            this.pnlContenidoTicket.Controls.Add(this.chkMostrarPie);
            this.pnlContenidoTicket.Controls.Add(this.chkMostrarEmail);
            this.pnlContenidoTicket.Controls.Add(this.chkMostrarTelefono);
            this.pnlContenidoTicket.Controls.Add(this.chkMostrarDireccion);
            this.pnlContenidoTicket.Controls.Add(this.chkMostrarRUC);
            this.pnlContenidoTicket.Controls.Add(this.chkMostrarNombre);
            this.pnlContenidoTicket.Controls.Add(this.chkMostrarLogo);
            this.pnlContenidoTicket.Controls.Add(this.lblSubTitulo2);
            this.pnlContenidoTicket.Location = new System.Drawing.Point(16, 180);
            this.pnlContenidoTicket.Name = "pnlContenidoTicket";
            this.pnlContenidoTicket.Size = new System.Drawing.Size(445, 631);
            this.pnlContenidoTicket.TabIndex = 68;
            // 
            // txtMensajePie2
            // 
            this.txtMensajePie2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMensajePie2.Location = new System.Drawing.Point(20, 337);
            this.txtMensajePie2.Multiline = true;
            this.txtMensajePie2.Name = "txtMensajePie2";
            this.txtMensajePie2.Size = new System.Drawing.Size(317, 24);
            this.txtMensajePie2.TabIndex = 74;
            // 
            // chkMostrarInfoPago
            // 
            this.chkMostrarInfoPago.AutoSize = true;
            this.chkMostrarInfoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMostrarInfoPago.Location = new System.Drawing.Point(20, 414);
            this.chkMostrarInfoPago.Name = "chkMostrarInfoPago";
            this.chkMostrarInfoPago.Size = new System.Drawing.Size(178, 19);
            this.chkMostrarInfoPago.TabIndex = 73;
            this.chkMostrarInfoPago.Text = "Mostrar Información de Pago";
            this.chkMostrarInfoPago.UseVisualStyleBackColor = true;
            // 
            // chkMostrarQR
            // 
            this.chkMostrarQR.AutoSize = true;
            this.chkMostrarQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMostrarQR.Location = new System.Drawing.Point(20, 389);
            this.chkMostrarQR.Name = "chkMostrarQR";
            this.chkMostrarQR.Size = new System.Drawing.Size(172, 19);
            this.chkMostrarQR.TabIndex = 72;
            this.chkMostrarQR.Text = "Mostrar Código QR (SUNAT)";
            this.chkMostrarQR.UseVisualStyleBackColor = true;
            // 
            // lblMensajePie
            // 
            this.lblMensajePie.AutoSize = true;
            this.lblMensajePie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMensajePie.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajePie.Location = new System.Drawing.Point(17, 281);
            this.lblMensajePie.Name = "lblMensajePie";
            this.lblMensajePie.Size = new System.Drawing.Size(128, 15);
            this.lblMensajePie.TabIndex = 71;
            this.lblMensajePie.Text = "Mensaje Pie de Página:";
            // 
            // txtMensajePie1
            // 
            this.txtMensajePie1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMensajePie1.Location = new System.Drawing.Point(20, 306);
            this.txtMensajePie1.Multiline = true;
            this.txtMensajePie1.Name = "txtMensajePie1";
            this.txtMensajePie1.Size = new System.Drawing.Size(317, 24);
            this.txtMensajePie1.TabIndex = 70;
            // 
            // chkMostrarDNI
            // 
            this.chkMostrarDNI.AutoSize = true;
            this.chkMostrarDNI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMostrarDNI.Location = new System.Drawing.Point(20, 198);
            this.chkMostrarDNI.Name = "chkMostrarDNI";
            this.chkMostrarDNI.Size = new System.Drawing.Size(146, 19);
            this.chkMostrarDNI.TabIndex = 115;
            this.chkMostrarDNI.Text = "Mostrar DNI del Cliente";
            this.chkMostrarDNI.UseVisualStyleBackColor = true;
            // 
            // chkMostrarPie
            // 
            this.chkMostrarPie.AutoSize = true;
            this.chkMostrarPie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMostrarPie.Location = new System.Drawing.Point(20, 221);
            this.chkMostrarPie.Name = "chkMostrarPie";
            this.chkMostrarPie.Size = new System.Drawing.Size(138, 19);
            this.chkMostrarPie.TabIndex = 116;
            this.chkMostrarPie.Text = "Mostrar Pie de Página";
            this.chkMostrarPie.UseVisualStyleBackColor = true;
            // 
            // chkMostrarEmail
            // 
            this.chkMostrarEmail.AutoSize = true;
            this.chkMostrarEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMostrarEmail.Location = new System.Drawing.Point(20, 175);
            this.chkMostrarEmail.Name = "chkMostrarEmail";
            this.chkMostrarEmail.Size = new System.Drawing.Size(165, 19);
            this.chkMostrarEmail.TabIndex = 69;
            this.chkMostrarEmail.Text = "Mostrar Correo Electrónico";
            this.chkMostrarEmail.UseVisualStyleBackColor = true;
            // 
            // chkMostrarTelefono
            // 
            this.chkMostrarTelefono.AutoSize = true;
            this.chkMostrarTelefono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMostrarTelefono.Location = new System.Drawing.Point(20, 152);
            this.chkMostrarTelefono.Name = "chkMostrarTelefono";
            this.chkMostrarTelefono.Size = new System.Drawing.Size(112, 19);
            this.chkMostrarTelefono.TabIndex = 68;
            this.chkMostrarTelefono.Text = "Mostrar Teléfono";
            this.chkMostrarTelefono.UseVisualStyleBackColor = true;
            // 
            // chkMostrarDireccion
            // 
            this.chkMostrarDireccion.AutoSize = true;
            this.chkMostrarDireccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMostrarDireccion.Location = new System.Drawing.Point(20, 129);
            this.chkMostrarDireccion.Name = "chkMostrarDireccion";
            this.chkMostrarDireccion.Size = new System.Drawing.Size(117, 19);
            this.chkMostrarDireccion.TabIndex = 67;
            this.chkMostrarDireccion.Text = "Mostrar Dirección";
            this.chkMostrarDireccion.UseVisualStyleBackColor = true;
            // 
            // chkMostrarRUC
            // 
            this.chkMostrarRUC.AutoSize = true;
            this.chkMostrarRUC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMostrarRUC.Location = new System.Drawing.Point(20, 106);
            this.chkMostrarRUC.Name = "chkMostrarRUC";
            this.chkMostrarRUC.Size = new System.Drawing.Size(90, 19);
            this.chkMostrarRUC.TabIndex = 66;
            this.chkMostrarRUC.Text = "Mostrar RUC";
            this.chkMostrarRUC.UseVisualStyleBackColor = true;
            // 
            // chkMostrarNombre
            // 
            this.chkMostrarNombre.AutoSize = true;
            this.chkMostrarNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMostrarNombre.Location = new System.Drawing.Point(20, 83);
            this.chkMostrarNombre.Name = "chkMostrarNombre";
            this.chkMostrarNombre.Size = new System.Drawing.Size(175, 19);
            this.chkMostrarNombre.TabIndex = 65;
            this.chkMostrarNombre.Text = "Mostrar Nombre de Empresa";
            this.chkMostrarNombre.UseVisualStyleBackColor = true;
            // 
            // chkMostrarLogo
            // 
            this.chkMostrarLogo.AutoSize = true;
            this.chkMostrarLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMostrarLogo.Location = new System.Drawing.Point(20, 60);
            this.chkMostrarLogo.Name = "chkMostrarLogo";
            this.chkMostrarLogo.Size = new System.Drawing.Size(158, 19);
            this.chkMostrarLogo.TabIndex = 64;
            this.chkMostrarLogo.Text = "Mostrar Logo de Empresa";
            this.chkMostrarLogo.UseVisualStyleBackColor = true;
            // 
            // pnlOpcionesImpresion
            // 
            this.pnlOpcionesImpresion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOpcionesImpresion.BackColor = System.Drawing.Color.White;
            this.pnlOpcionesImpresion.Controls.Add(this.nudMargenInferior);
            this.pnlOpcionesImpresion.Controls.Add(this.lblMargenInferior);
            this.pnlOpcionesImpresion.Controls.Add(this.nudMargenSuperior);
            this.pnlOpcionesImpresion.Controls.Add(this.lblMargenSuperior);
            this.pnlOpcionesImpresion.Controls.Add(this.nudMargenDerecho);
            this.pnlOpcionesImpresion.Controls.Add(this.lblMargenDerecho);
            this.pnlOpcionesImpresion.Controls.Add(this.nudMargenIzquierdo);
            this.pnlOpcionesImpresion.Controls.Add(this.lblMargenIzquierdo);
            this.pnlOpcionesImpresion.Controls.Add(this.lblMargenes);
            this.pnlOpcionesImpresion.Controls.Add(this.nudEscalaAjuste);
            this.pnlOpcionesImpresion.Controls.Add(this.lblEscalaAjuste);
            this.pnlOpcionesImpresion.Controls.Add(this.nudAnchoPersonalizado);
            this.pnlOpcionesImpresion.Controls.Add(this.lblAnchoPersonalizado);
            this.pnlOpcionesImpresion.Controls.Add(this.lblOscuro);
            this.pnlOpcionesImpresion.Controls.Add(this.lblClaro);
            this.pnlOpcionesImpresion.Controls.Add(this.cmbEspaciadoLineas);
            this.pnlOpcionesImpresion.Controls.Add(this.lblEspaciadoLineas);
            this.pnlOpcionesImpresion.Controls.Add(this.chkSonidoImprimir);
            this.pnlOpcionesImpresion.Controls.Add(this.lblDensidad);
            this.pnlOpcionesImpresion.Controls.Add(this.chkCortaPapel);
            this.pnlOpcionesImpresion.Controls.Add(this.tbDensidad);
            this.pnlOpcionesImpresion.Controls.Add(this.cmbAnchoPapel);
            this.pnlOpcionesImpresion.Controls.Add(this.lblAnchoPapel);
            this.pnlOpcionesImpresion.Controls.Add(this.cmbNumeroCopias);
            this.pnlOpcionesImpresion.Controls.Add(this.label4);
            this.pnlOpcionesImpresion.Controls.Add(this.lblNumeroCopias);
            this.pnlOpcionesImpresion.Location = new System.Drawing.Point(467, 180);
            this.pnlOpcionesImpresion.Name = "pnlOpcionesImpresion";
            this.pnlOpcionesImpresion.Size = new System.Drawing.Size(405, 631);
            this.pnlOpcionesImpresion.TabIndex = 69;
            // 
            // nudMargenInferior
            // 
            this.nudMargenInferior.Location = new System.Drawing.Point(310, 349);
            this.nudMargenInferior.Name = "nudMargenInferior";
            this.nudMargenInferior.Size = new System.Drawing.Size(64, 23);
            this.nudMargenInferior.TabIndex = 92;
            this.nudMargenInferior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMargenInferior
            // 
            this.lblMargenInferior.AutoSize = true;
            this.lblMargenInferior.Location = new System.Drawing.Point(232, 351);
            this.lblMargenInferior.Name = "lblMargenInferior";
            this.lblMargenInferior.Size = new System.Drawing.Size(48, 15);
            this.lblMargenInferior.TabIndex = 91;
            this.lblMargenInferior.Text = "Inferior:";
            // 
            // nudMargenSuperior
            // 
            this.nudMargenSuperior.Location = new System.Drawing.Point(96, 349);
            this.nudMargenSuperior.Name = "nudMargenSuperior";
            this.nudMargenSuperior.Size = new System.Drawing.Size(64, 23);
            this.nudMargenSuperior.TabIndex = 90;
            this.nudMargenSuperior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMargenSuperior
            // 
            this.lblMargenSuperior.AutoSize = true;
            this.lblMargenSuperior.Location = new System.Drawing.Point(14, 351);
            this.lblMargenSuperior.Name = "lblMargenSuperior";
            this.lblMargenSuperior.Size = new System.Drawing.Size(54, 15);
            this.lblMargenSuperior.TabIndex = 89;
            this.lblMargenSuperior.Text = "Superior:";
            // 
            // nudMargenDerecho
            // 
            this.nudMargenDerecho.Location = new System.Drawing.Point(310, 323);
            this.nudMargenDerecho.Name = "nudMargenDerecho";
            this.nudMargenDerecho.Size = new System.Drawing.Size(64, 23);
            this.nudMargenDerecho.TabIndex = 88;
            this.nudMargenDerecho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMargenDerecho
            // 
            this.lblMargenDerecho.AutoSize = true;
            this.lblMargenDerecho.Location = new System.Drawing.Point(232, 325);
            this.lblMargenDerecho.Name = "lblMargenDerecho";
            this.lblMargenDerecho.Size = new System.Drawing.Size(54, 15);
            this.lblMargenDerecho.TabIndex = 87;
            this.lblMargenDerecho.Text = "Derecho:";
            // 
            // nudMargenIzquierdo
            // 
            this.nudMargenIzquierdo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudMargenIzquierdo.Location = new System.Drawing.Point(96, 323);
            this.nudMargenIzquierdo.Name = "nudMargenIzquierdo";
            this.nudMargenIzquierdo.Size = new System.Drawing.Size(64, 19);
            this.nudMargenIzquierdo.TabIndex = 86;
            this.nudMargenIzquierdo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMargenIzquierdo
            // 
            this.lblMargenIzquierdo.AutoSize = true;
            this.lblMargenIzquierdo.Location = new System.Drawing.Point(14, 325);
            this.lblMargenIzquierdo.Name = "lblMargenIzquierdo";
            this.lblMargenIzquierdo.Size = new System.Drawing.Size(59, 15);
            this.lblMargenIzquierdo.TabIndex = 85;
            this.lblMargenIzquierdo.Text = "Izquierdo:";
            // 
            // lblMargenes
            // 
            this.lblMargenes.AutoSize = true;
            this.lblMargenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMargenes.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMargenes.Location = new System.Drawing.Point(14, 299);
            this.lblMargenes.Name = "lblMargenes";
            this.lblMargenes.Size = new System.Drawing.Size(92, 15);
            this.lblMargenes.TabIndex = 84;
            this.lblMargenes.Text = "Márgenes (mm)";
            // 
            // nudEscalaAjuste
            // 
            this.nudEscalaAjuste.Location = new System.Drawing.Point(177, 268);
            this.nudEscalaAjuste.Name = "nudEscalaAjuste";
            this.nudEscalaAjuste.Size = new System.Drawing.Size(80, 23);
            this.nudEscalaAjuste.TabIndex = 83;
            this.nudEscalaAjuste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblEscalaAjuste
            // 
            this.lblEscalaAjuste.AutoSize = true;
            this.lblEscalaAjuste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblEscalaAjuste.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEscalaAjuste.Location = new System.Drawing.Point(14, 270);
            this.lblEscalaAjuste.Name = "lblEscalaAjuste";
            this.lblEscalaAjuste.Size = new System.Drawing.Size(115, 15);
            this.lblEscalaAjuste.TabIndex = 82;
            this.lblEscalaAjuste.Text = "Ajuste de escala (%):";
            // 
            // nudAnchoPersonalizado
            // 
            this.nudAnchoPersonalizado.Location = new System.Drawing.Point(177, 114);
            this.nudAnchoPersonalizado.Name = "nudAnchoPersonalizado";
            this.nudAnchoPersonalizado.Size = new System.Drawing.Size(80, 23);
            this.nudAnchoPersonalizado.TabIndex = 80;
            this.nudAnchoPersonalizado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAnchoPersonalizado
            // 
            this.lblAnchoPersonalizado.AutoSize = true;
            this.lblAnchoPersonalizado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAnchoPersonalizado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnchoPersonalizado.Location = new System.Drawing.Point(14, 116);
            this.lblAnchoPersonalizado.Name = "lblAnchoPersonalizado";
            this.lblAnchoPersonalizado.Size = new System.Drawing.Size(154, 15);
            this.lblAnchoPersonalizado.TabIndex = 81;
            this.lblAnchoPersonalizado.Text = "Ancho personalizado (mm):";
            // 
            // lblOscuro
            // 
            this.lblOscuro.AutoSize = true;
            this.lblOscuro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblOscuro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOscuro.Location = new System.Drawing.Point(330, 168);
            this.lblOscuro.Name = "lblOscuro";
            this.lblOscuro.Size = new System.Drawing.Size(44, 13);
            this.lblOscuro.TabIndex = 79;
            this.lblOscuro.Text = "Oscuro";
            // 
            // lblClaro
            // 
            this.lblClaro.AutoSize = true;
            this.lblClaro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblClaro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClaro.Location = new System.Drawing.Point(174, 168);
            this.lblClaro.Name = "lblClaro";
            this.lblClaro.Size = new System.Drawing.Size(34, 13);
            this.lblClaro.TabIndex = 78;
            this.lblClaro.Text = "Claro";
            // 
            // cmbEspaciadoLineas
            // 
            this.cmbEspaciadoLineas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspaciadoLineas.FormattingEnabled = true;
            this.cmbEspaciadoLineas.Location = new System.Drawing.Point(177, 234);
            this.cmbEspaciadoLineas.Name = "cmbEspaciadoLineas";
            this.cmbEspaciadoLineas.Size = new System.Drawing.Size(197, 23);
            this.cmbEspaciadoLineas.TabIndex = 77;
            // 
            // lblEspaciadoLineas
            // 
            this.lblEspaciadoLineas.AutoSize = true;
            this.lblEspaciadoLineas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblEspaciadoLineas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspaciadoLineas.Location = new System.Drawing.Point(14, 238);
            this.lblEspaciadoLineas.Name = "lblEspaciadoLineas";
            this.lblEspaciadoLineas.Size = new System.Drawing.Size(126, 15);
            this.lblEspaciadoLineas.TabIndex = 76;
            this.lblEspaciadoLineas.Text = "Espaciado entre líneas:";
            // 
            // chkSonidoImprimir
            // 
            this.chkSonidoImprimir.AutoSize = true;
            this.chkSonidoImprimir.Location = new System.Drawing.Point(17, 211);
            this.chkSonidoImprimir.Name = "chkSonidoImprimir";
            this.chkSonidoImprimir.Size = new System.Drawing.Size(124, 19);
            this.chkSonidoImprimir.TabIndex = 75;
            this.chkSonidoImprimir.Text = "Sonido al imprimir";
            this.chkSonidoImprimir.UseVisualStyleBackColor = true;
            // 
            // lblDensidad
            // 
            this.lblDensidad.AutoSize = true;
            this.lblDensidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDensidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDensidad.Location = new System.Drawing.Point(14, 146);
            this.lblDensidad.Name = "lblDensidad";
            this.lblDensidad.Size = new System.Drawing.Size(59, 15);
            this.lblDensidad.TabIndex = 67;
            this.lblDensidad.Text = "Densidad:";
            // 
            // chkCortaPapel
            // 
            this.chkCortaPapel.AutoSize = true;
            this.chkCortaPapel.Location = new System.Drawing.Point(17, 188);
            this.chkCortaPapel.Name = "chkCortaPapel";
            this.chkCortaPapel.Size = new System.Drawing.Size(188, 19);
            this.chkCortaPapel.TabIndex = 74;
            this.chkCortaPapel.Text = "Cortar papel automáticamente";
            this.chkCortaPapel.UseVisualStyleBackColor = true;
            // 
            // tbDensidad
            // 
            this.tbDensidad.AutoSize = false;
            this.tbDensidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbDensidad.Location = new System.Drawing.Point(177, 142);
            this.tbDensidad.Name = "tbDensidad";
            this.tbDensidad.Size = new System.Drawing.Size(197, 23);
            this.tbDensidad.TabIndex = 66;
            this.tbDensidad.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // cmbAnchoPapel
            // 
            this.cmbAnchoPapel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnchoPapel.FormattingEnabled = true;
            this.cmbAnchoPapel.Location = new System.Drawing.Point(177, 87);
            this.cmbAnchoPapel.Name = "cmbAnchoPapel";
            this.cmbAnchoPapel.Size = new System.Drawing.Size(197, 23);
            this.cmbAnchoPapel.TabIndex = 65;
            // 
            // lblAnchoPapel
            // 
            this.lblAnchoPapel.AutoSize = true;
            this.lblAnchoPapel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAnchoPapel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnchoPapel.Location = new System.Drawing.Point(14, 90);
            this.lblAnchoPapel.Name = "lblAnchoPapel";
            this.lblAnchoPapel.Size = new System.Drawing.Size(96, 15);
            this.lblAnchoPapel.TabIndex = 64;
            this.lblAnchoPapel.Text = "Ancho del papel:";
            // 
            // cmbNumeroCopias
            // 
            this.cmbNumeroCopias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNumeroCopias.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbNumeroCopias.FormattingEnabled = true;
            this.cmbNumeroCopias.Location = new System.Drawing.Point(177, 58);
            this.cmbNumeroCopias.Name = "cmbNumeroCopias";
            this.cmbNumeroCopias.Size = new System.Drawing.Size(197, 23);
            this.cmbNumeroCopias.TabIndex = 62;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label4.Location = new System.Drawing.Point(16, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Opciones de Impresion";
            // 
            // lblNumeroCopias
            // 
            this.lblNumeroCopias.AutoSize = true;
            this.lblNumeroCopias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNumeroCopias.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroCopias.Location = new System.Drawing.Point(16, 61);
            this.lblNumeroCopias.Name = "lblNumeroCopias";
            this.lblNumeroCopias.Size = new System.Drawing.Size(109, 15);
            this.lblNumeroCopias.TabIndex = 47;
            this.lblNumeroCopias.Text = "Número de Copias:";
            // 
            // lblVistaPrevia
            // 
            this.lblVistaPrevia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVistaPrevia.AutoSize = true;
            this.lblVistaPrevia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblVistaPrevia.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVistaPrevia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblVistaPrevia.Location = new System.Drawing.Point(878, 58);
            this.lblVistaPrevia.Name = "lblVistaPrevia";
            this.lblVistaPrevia.Size = new System.Drawing.Size(137, 20);
            this.lblVistaPrevia.TabIndex = 12;
            this.lblVistaPrevia.Text = "Vista Previa Ticket";
            // 
            // pnlVistaTicket
            // 
            this.pnlVistaTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVistaTicket.BackColor = System.Drawing.Color.White;
            this.pnlVistaTicket.Location = new System.Drawing.Point(882, 82);
            this.pnlVistaTicket.Name = "pnlVistaTicket";
            this.pnlVistaTicket.Size = new System.Drawing.Size(284, 730);
            this.pnlVistaTicket.TabIndex = 80;
            // 
            // FormImpresoras
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1225, 824);
            this.Controls.Add(this.pnlVistaTicket);
            this.Controls.Add(this.pnlOpcionesImpresion);
            this.Controls.Add(this.pnlContenidoTicket);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlImpresora);
            this.Controls.Add(this.lblVistaPrevia);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormImpresoras";
            this.Text = " ";
            this.pnlImpresora.ResumeLayout(false);
            this.pnlImpresora.PerformLayout();
            this.pnlContenidoTicket.ResumeLayout(false);
            this.pnlContenidoTicket.PerformLayout();
            this.pnlOpcionesImpresion.ResumeLayout(false);
            this.pnlOpcionesImpresion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargenInferior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargenSuperior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargenDerecho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargenIzquierdo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEscalaAjuste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnchoPersonalizado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDensidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlImpresora;
        private System.Windows.Forms.Button btnConfigurarImpresora;
        private System.Windows.Forms.Label lblSubTitulo;
        private System.Windows.Forms.Label lblCodigoLicencia;
        private System.Windows.Forms.ComboBox cmbImpresoraPredeterminada;
        private System.Windows.Forms.Button btnImprimirPrueba;
        private System.Windows.Forms.Button btnGuardarConfiguracion;
        private System.Windows.Forms.Label lblSubTitulo2;
        private System.Windows.Forms.Panel pnlContenidoTicket;
        private System.Windows.Forms.CheckBox chkMostrarEmail;
        private System.Windows.Forms.CheckBox chkMostrarTelefono;
        private System.Windows.Forms.CheckBox chkMostrarDireccion;
        private System.Windows.Forms.CheckBox chkMostrarRUC;
        private System.Windows.Forms.CheckBox chkMostrarNombre;
        private System.Windows.Forms.CheckBox chkMostrarLogo;
        private System.Windows.Forms.Panel pnlOpcionesImpresion;
        private System.Windows.Forms.ComboBox cmbNumeroCopias;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNumeroCopias;
        private System.Windows.Forms.CheckBox chkMostrarInfoPago;
        private System.Windows.Forms.CheckBox chkMostrarQR;
        private System.Windows.Forms.CheckBox chkMostrarDNI;
        private System.Windows.Forms.CheckBox chkMostrarPie;
        private System.Windows.Forms.Label lblMensajePie;
        private System.Windows.Forms.TextBox txtMensajePie1;
        private System.Windows.Forms.ComboBox cmbAnchoPapel;
        private System.Windows.Forms.NumericUpDown nudAnchoPersonalizado;
        private System.Windows.Forms.Label lblAnchoPersonalizado;
        private System.Windows.Forms.Label lblAnchoPapel;
        private System.Windows.Forms.Label lblEscalaAjuste;
        private System.Windows.Forms.NumericUpDown nudEscalaAjuste;
        private System.Windows.Forms.Label lblMargenes;
        private System.Windows.Forms.Label lblMargenIzquierdo;
        private System.Windows.Forms.NumericUpDown nudMargenIzquierdo;
        private System.Windows.Forms.Label lblMargenDerecho;
        private System.Windows.Forms.NumericUpDown nudMargenDerecho;
        private System.Windows.Forms.Label lblMargenSuperior;
        private System.Windows.Forms.NumericUpDown nudMargenSuperior;
        private System.Windows.Forms.Label lblMargenInferior;
        private System.Windows.Forms.NumericUpDown nudMargenInferior;
        private System.Windows.Forms.Label lblDensidad;
        private System.Windows.Forms.TrackBar tbDensidad;
        private System.Windows.Forms.ComboBox cmbEspaciadoLineas;
        private System.Windows.Forms.Label lblEspaciadoLineas;
        private System.Windows.Forms.CheckBox chkSonidoImprimir;
        private System.Windows.Forms.CheckBox chkCortaPapel;
        private System.Windows.Forms.TextBox txtMensajePie2;
        private System.Windows.Forms.Label lblOscuro;
        private System.Windows.Forms.Label lblClaro;
        private SistemaPOS.Controls.TicketDesignPanel pnlVistaTicket;
        private System.Windows.Forms.Label lblVistaPrevia;
    }
}
