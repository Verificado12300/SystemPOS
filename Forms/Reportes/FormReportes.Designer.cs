namespace SistemaPOS.Forms.Reportes
{
    partial class FormReportes
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubHeader = new System.Windows.Forms.Label();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lblIconHeader = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlColReportes = new System.Windows.Forms.Panel();
            this.pnlBodyReportes = new System.Windows.Forms.Panel();
            this.chkGenerarReportes = new System.Windows.Forms.CheckBox();
            this.lblFrecuencia = new System.Windows.Forms.Label();
            this.rbDiario = new System.Windows.Forms.RadioButton();
            this.rbSemanal = new System.Windows.Forms.RadioButton();
            this.rbMensual = new System.Windows.Forms.RadioButton();
            this.lblDiaEnvio = new System.Windows.Forms.Label();
            this.cmbDiaEnvio = new System.Windows.Forms.ComboBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.lblSeccionReportes = new System.Windows.Forms.Label();
            this.chkMostrarLogo = new System.Windows.Forms.CheckBox();
            this.chkMostrarNombre = new System.Windows.Forms.CheckBox();
            this.chkMostrarRUC = new System.Windows.Forms.CheckBox();
            this.chkMostrarDireccion = new System.Windows.Forms.CheckBox();
            this.chkMostrarTelefono = new System.Windows.Forms.CheckBox();
            this.chkMostrarEmail = new System.Windows.Forms.CheckBox();
            this.pnlHdrReportes = new System.Windows.Forms.Panel();
            this.lblTitHdrReportes = new System.Windows.Forms.Label();
            this.lblIconReportes = new System.Windows.Forms.Label();
            this.pnlColCorreo = new System.Windows.Forms.Panel();
            this.pnlBodyCorreo = new System.Windows.Forms.Panel();
            this.chkEnviarporCorreo = new System.Windows.Forms.CheckBox();
            this.lblDestinatarios = new System.Windows.Forms.Label();
            this.txtDestinatarios = new System.Windows.Forms.TextBox();
            this.lblAsunto = new System.Windows.Forms.Label();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.lblFormato = new System.Windows.Forms.Label();
            this.rbPDF = new System.Windows.Forms.RadioButton();
            this.rbExcel = new System.Windows.Forms.RadioButton();
            this.chkAmbosFormatos = new System.Windows.Forms.CheckBox();
            this.pnlHdrCorreo = new System.Windows.Forms.Panel();
            this.lblTitHdrCorreo = new System.Windows.Forms.Label();
            this.lblIconCorreo = new System.Windows.Forms.Label();
            this.pnlColAlertas = new System.Windows.Forms.Panel();
            this.pnlBodyAlertas = new System.Windows.Forms.Panel();
            this.chkAlertaStockBajo = new System.Windows.Forms.CheckBox();
            this.chkNotificarVentasMayores = new System.Windows.Forms.CheckBox();
            this.numMontoVentas = new System.Windows.Forms.NumericUpDown();
            this.lblMontoUnidad = new System.Windows.Forms.Label();
            this.chkAlertarProductosVencer = new System.Windows.Forms.CheckBox();
            this.chkNotificarCompras = new System.Windows.Forms.CheckBox();
            this.pnlHdrAlertas = new System.Windows.Forms.Panel();
            this.lblTitHdrAlertas = new System.Windows.Forms.Label();
            this.lblIconAlertas = new System.Windows.Forms.Label();
            this.pnlFooterBar = new System.Windows.Forms.Panel();
            this.lblEstadoGuardado = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.pnlColReportes.SuspendLayout();
            this.pnlBodyReportes.SuspendLayout();
            this.pnlHdrReportes.SuspendLayout();
            this.pnlColCorreo.SuspendLayout();
            this.pnlBodyCorreo.SuspendLayout();
            this.pnlHdrCorreo.SuspendLayout();
            this.pnlColAlertas.SuspendLayout();
            this.pnlBodyAlertas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMontoVentas)).BeginInit();
            this.pnlHdrAlertas.SuspendLayout();
            this.pnlFooterBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlHeader.Controls.Add(this.btnGuardar);
            this.pnlHeader.Controls.Add(this.lblSubHeader);
            this.pnlHeader.Controls.Add(this.lblTituloHeader);
            this.pnlHeader.Controls.Add(this.lblIconHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1545, 64);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblSubHeader
            // 
            this.lblSubHeader.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(185)))), ((int)(((byte)(205)))));
            this.lblSubHeader.Location = new System.Drawing.Point(60, 40);
            this.lblSubHeader.Name = "lblSubHeader";
            this.lblSubHeader.Size = new System.Drawing.Size(600, 16);
            this.lblSubHeader.TabIndex = 0;
            this.lblSubHeader.Text = "Reportes automáticos, notificaciones por correo y alertas del sistema";
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(58, 10);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(500, 28);
            this.lblTituloHeader.TabIndex = 1;
            this.lblTituloHeader.Text = "Configuración de Reportes";
            // 
            // lblIconHeader
            // 
            this.lblIconHeader.Font = new System.Drawing.Font("Segoe MDL2 Assets", 18F);
            this.lblIconHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.lblIconHeader.Location = new System.Drawing.Point(20, 16);
            this.lblIconHeader.Name = "lblIconHeader";
            this.lblIconHeader.Size = new System.Drawing.Size(30, 30);
            this.lblIconHeader.TabIndex = 2;
            this.lblIconHeader.Text = "";
            this.lblIconHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.pnlContent.Controls.Add(this.tlpMain);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 64);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(12);
            this.pnlContent.Size = new System.Drawing.Size(1545, 669);
            this.pnlContent.TabIndex = 0;
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpMain.Controls.Add(this.pnlColReportes, 0, 0);
            this.tlpMain.Controls.Add(this.pnlColCorreo, 1, 0);
            this.tlpMain.Controls.Add(this.pnlColAlertas, 2, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlpMain.Location = new System.Drawing.Point(12, 12);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1521, 645);
            this.tlpMain.TabIndex = 0;
            // 
            // pnlColReportes
            // 
            this.pnlColReportes.BackColor = System.Drawing.Color.White;
            this.pnlColReportes.Controls.Add(this.pnlBodyReportes);
            this.pnlColReportes.Controls.Add(this.pnlHdrReportes);
            this.pnlColReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColReportes.Location = new System.Drawing.Point(0, 0);
            this.pnlColReportes.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlColReportes.Name = "pnlColReportes";
            this.pnlColReportes.Size = new System.Drawing.Size(500, 645);
            this.pnlColReportes.TabIndex = 0;
            // 
            // pnlBodyReportes
            // 
            this.pnlBodyReportes.BackColor = System.Drawing.Color.White;
            this.pnlBodyReportes.Controls.Add(this.chkGenerarReportes);
            this.pnlBodyReportes.Controls.Add(this.lblFrecuencia);
            this.pnlBodyReportes.Controls.Add(this.rbDiario);
            this.pnlBodyReportes.Controls.Add(this.rbSemanal);
            this.pnlBodyReportes.Controls.Add(this.rbMensual);
            this.pnlBodyReportes.Controls.Add(this.lblDiaEnvio);
            this.pnlBodyReportes.Controls.Add(this.cmbDiaEnvio);
            this.pnlBodyReportes.Controls.Add(this.lblHora);
            this.pnlBodyReportes.Controls.Add(this.dtpHora);
            this.pnlBodyReportes.Controls.Add(this.lblSeccionReportes);
            this.pnlBodyReportes.Controls.Add(this.chkMostrarLogo);
            this.pnlBodyReportes.Controls.Add(this.chkMostrarNombre);
            this.pnlBodyReportes.Controls.Add(this.chkMostrarRUC);
            this.pnlBodyReportes.Controls.Add(this.chkMostrarDireccion);
            this.pnlBodyReportes.Controls.Add(this.chkMostrarTelefono);
            this.pnlBodyReportes.Controls.Add(this.chkMostrarEmail);
            this.pnlBodyReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBodyReportes.Location = new System.Drawing.Point(0, 42);
            this.pnlBodyReportes.Name = "pnlBodyReportes";
            this.pnlBodyReportes.Size = new System.Drawing.Size(500, 603);
            this.pnlBodyReportes.TabIndex = 0;
            // 
            // chkGenerarReportes
            // 
            this.chkGenerarReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkGenerarReportes.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkGenerarReportes.Location = new System.Drawing.Point(16, 14);
            this.chkGenerarReportes.Name = "chkGenerarReportes";
            this.chkGenerarReportes.Size = new System.Drawing.Size(290, 20);
            this.chkGenerarReportes.TabIndex = 0;
            this.chkGenerarReportes.Text = "Generar reportes automáticamente";
            // 
            // lblFrecuencia
            // 
            this.lblFrecuencia.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblFrecuencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(140)))), ((int)(((byte)(155)))));
            this.lblFrecuencia.Location = new System.Drawing.Point(18, 46);
            this.lblFrecuencia.Name = "lblFrecuencia";
            this.lblFrecuencia.Size = new System.Drawing.Size(80, 14);
            this.lblFrecuencia.TabIndex = 1;
            this.lblFrecuencia.Text = "FRECUENCIA";
            // 
            // rbDiario
            // 
            this.rbDiario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbDiario.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.rbDiario.Location = new System.Drawing.Point(18, 64);
            this.rbDiario.Name = "rbDiario";
            this.rbDiario.Size = new System.Drawing.Size(62, 20);
            this.rbDiario.TabIndex = 2;
            this.rbDiario.Text = "Diario";
            // 
            // rbSemanal
            // 
            this.rbSemanal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbSemanal.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.rbSemanal.Location = new System.Drawing.Point(86, 64);
            this.rbSemanal.Name = "rbSemanal";
            this.rbSemanal.Size = new System.Drawing.Size(74, 20);
            this.rbSemanal.TabIndex = 3;
            this.rbSemanal.Text = "Semanal";
            // 
            // rbMensual
            // 
            this.rbMensual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbMensual.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.rbMensual.Location = new System.Drawing.Point(166, 64);
            this.rbMensual.Name = "rbMensual";
            this.rbMensual.Size = new System.Drawing.Size(74, 20);
            this.rbMensual.TabIndex = 4;
            this.rbMensual.Text = "Mensual";
            // 
            // lblDiaEnvio
            // 
            this.lblDiaEnvio.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDiaEnvio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(135)))));
            this.lblDiaEnvio.Location = new System.Drawing.Point(18, 90);
            this.lblDiaEnvio.Name = "lblDiaEnvio";
            this.lblDiaEnvio.Size = new System.Drawing.Size(150, 14);
            this.lblDiaEnvio.TabIndex = 5;
            this.lblDiaEnvio.Text = "Día de envío:";
            this.lblDiaEnvio.Visible = false;
            // 
            // cmbDiaEnvio
            // 
            this.cmbDiaEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiaEnvio.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.cmbDiaEnvio.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado",
            "Domingo"});
            this.cmbDiaEnvio.Location = new System.Drawing.Point(18, 108);
            this.cmbDiaEnvio.Name = "cmbDiaEnvio";
            this.cmbDiaEnvio.Size = new System.Drawing.Size(150, 21);
            this.cmbDiaEnvio.TabIndex = 6;
            this.cmbDiaEnvio.Visible = false;
            // 
            // lblHora
            // 
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(135)))));
            this.lblHora.Location = new System.Drawing.Point(188, 90);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(40, 14);
            this.lblHora.TabIndex = 7;
            this.lblHora.Text = "Hora:";
            // 
            // dtpHora
            // 
            this.dtpHora.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(188, 108);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(110, 23);
            this.dtpHora.TabIndex = 8;
            // 
            // lblSeccionReportes
            // 
            this.lblSeccionReportes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeccionReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.lblSeccionReportes.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblSeccionReportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(140)))), ((int)(((byte)(155)))));
            this.lblSeccionReportes.Location = new System.Drawing.Point(16, 142);
            this.lblSeccionReportes.Name = "lblSeccionReportes";
            this.lblSeccionReportes.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblSeccionReportes.Size = new System.Drawing.Size(470, 18);
            this.lblSeccionReportes.TabIndex = 9;
            this.lblSeccionReportes.Text = "REPORTES A INCLUIR";
            this.lblSeccionReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkMostrarLogo
            // 
            this.chkMostrarLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkMostrarLogo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkMostrarLogo.Location = new System.Drawing.Point(18, 166);
            this.chkMostrarLogo.Name = "chkMostrarLogo";
            this.chkMostrarLogo.Size = new System.Drawing.Size(170, 20);
            this.chkMostrarLogo.TabIndex = 10;
            this.chkMostrarLogo.Text = "Reporte de Ventas";
            // 
            // chkMostrarNombre
            // 
            this.chkMostrarNombre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkMostrarNombre.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkMostrarNombre.Location = new System.Drawing.Point(18, 190);
            this.chkMostrarNombre.Name = "chkMostrarNombre";
            this.chkMostrarNombre.Size = new System.Drawing.Size(170, 20);
            this.chkMostrarNombre.TabIndex = 11;
            this.chkMostrarNombre.Text = "Reporte de Inventario";
            // 
            // chkMostrarRUC
            // 
            this.chkMostrarRUC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkMostrarRUC.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkMostrarRUC.Location = new System.Drawing.Point(18, 214);
            this.chkMostrarRUC.Name = "chkMostrarRUC";
            this.chkMostrarRUC.Size = new System.Drawing.Size(200, 20);
            this.chkMostrarRUC.TabIndex = 12;
            this.chkMostrarRUC.Text = "Productos con Stock Bajo";
            // 
            // chkMostrarDireccion
            // 
            this.chkMostrarDireccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkMostrarDireccion.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkMostrarDireccion.Location = new System.Drawing.Point(18, 238);
            this.chkMostrarDireccion.Name = "chkMostrarDireccion";
            this.chkMostrarDireccion.Size = new System.Drawing.Size(170, 20);
            this.chkMostrarDireccion.TabIndex = 13;
            this.chkMostrarDireccion.Text = "Resumen de Caja";
            // 
            // chkMostrarTelefono
            // 
            this.chkMostrarTelefono.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkMostrarTelefono.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkMostrarTelefono.Location = new System.Drawing.Point(18, 262);
            this.chkMostrarTelefono.Name = "chkMostrarTelefono";
            this.chkMostrarTelefono.Size = new System.Drawing.Size(180, 20);
            this.chkMostrarTelefono.TabIndex = 14;
            this.chkMostrarTelefono.Text = "Reporte de Compras";
            // 
            // chkMostrarEmail
            // 
            this.chkMostrarEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkMostrarEmail.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkMostrarEmail.Location = new System.Drawing.Point(18, 286);
            this.chkMostrarEmail.Name = "chkMostrarEmail";
            this.chkMostrarEmail.Size = new System.Drawing.Size(190, 20);
            this.chkMostrarEmail.TabIndex = 15;
            this.chkMostrarEmail.Text = "Cuentas por Cobrar";
            // 
            // pnlHdrReportes
            // 
            this.pnlHdrReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(153)))), ((int)(((byte)(82)))));
            this.pnlHdrReportes.Controls.Add(this.lblTitHdrReportes);
            this.pnlHdrReportes.Controls.Add(this.lblIconReportes);
            this.pnlHdrReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHdrReportes.Location = new System.Drawing.Point(0, 0);
            this.pnlHdrReportes.Name = "pnlHdrReportes";
            this.pnlHdrReportes.Size = new System.Drawing.Size(500, 42);
            this.pnlHdrReportes.TabIndex = 1;
            // 
            // lblTitHdrReportes
            // 
            this.lblTitHdrReportes.BackColor = System.Drawing.Color.Transparent;
            this.lblTitHdrReportes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitHdrReportes.ForeColor = System.Drawing.Color.White;
            this.lblTitHdrReportes.Location = new System.Drawing.Point(38, 13);
            this.lblTitHdrReportes.Name = "lblTitHdrReportes";
            this.lblTitHdrReportes.Size = new System.Drawing.Size(280, 18);
            this.lblTitHdrReportes.TabIndex = 0;
            this.lblTitHdrReportes.Text = "REPORTES AUTOMÁTICOS";
            // 
            // lblIconReportes
            // 
            this.lblIconReportes.BackColor = System.Drawing.Color.Transparent;
            this.lblIconReportes.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.lblIconReportes.ForeColor = System.Drawing.Color.White;
            this.lblIconReportes.Location = new System.Drawing.Point(12, 11);
            this.lblIconReportes.Name = "lblIconReportes";
            this.lblIconReportes.Size = new System.Drawing.Size(20, 20);
            this.lblIconReportes.TabIndex = 1;
            this.lblIconReportes.Text = "";
            // 
            // pnlColCorreo
            // 
            this.pnlColCorreo.BackColor = System.Drawing.Color.White;
            this.pnlColCorreo.Controls.Add(this.pnlBodyCorreo);
            this.pnlColCorreo.Controls.Add(this.pnlHdrCorreo);
            this.pnlColCorreo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColCorreo.Location = new System.Drawing.Point(512, 0);
            this.pnlColCorreo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.pnlColCorreo.Name = "pnlColCorreo";
            this.pnlColCorreo.Size = new System.Drawing.Size(494, 645);
            this.pnlColCorreo.TabIndex = 1;
            // 
            // pnlBodyCorreo
            // 
            this.pnlBodyCorreo.BackColor = System.Drawing.Color.White;
            this.pnlBodyCorreo.Controls.Add(this.chkEnviarporCorreo);
            this.pnlBodyCorreo.Controls.Add(this.lblDestinatarios);
            this.pnlBodyCorreo.Controls.Add(this.txtDestinatarios);
            this.pnlBodyCorreo.Controls.Add(this.lblAsunto);
            this.pnlBodyCorreo.Controls.Add(this.txtAsunto);
            this.pnlBodyCorreo.Controls.Add(this.lblFormato);
            this.pnlBodyCorreo.Controls.Add(this.rbPDF);
            this.pnlBodyCorreo.Controls.Add(this.rbExcel);
            this.pnlBodyCorreo.Controls.Add(this.chkAmbosFormatos);
            this.pnlBodyCorreo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBodyCorreo.Location = new System.Drawing.Point(0, 42);
            this.pnlBodyCorreo.Name = "pnlBodyCorreo";
            this.pnlBodyCorreo.Size = new System.Drawing.Size(494, 603);
            this.pnlBodyCorreo.TabIndex = 0;
            // 
            // chkEnviarporCorreo
            // 
            this.chkEnviarporCorreo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkEnviarporCorreo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkEnviarporCorreo.Location = new System.Drawing.Point(16, 14);
            this.chkEnviarporCorreo.Name = "chkEnviarporCorreo";
            this.chkEnviarporCorreo.Size = new System.Drawing.Size(310, 20);
            this.chkEnviarporCorreo.TabIndex = 0;
            this.chkEnviarporCorreo.Text = "Enviar reportes por correo electrónico";
            // 
            // lblDestinatarios
            // 
            this.lblDestinatarios.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDestinatarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(135)))));
            this.lblDestinatarios.Location = new System.Drawing.Point(18, 46);
            this.lblDestinatarios.Name = "lblDestinatarios";
            this.lblDestinatarios.Size = new System.Drawing.Size(260, 14);
            this.lblDestinatarios.TabIndex = 1;
            this.lblDestinatarios.Text = "Destinatarios (separados por coma)";
            // 
            // txtDestinatarios
            // 
            this.txtDestinatarios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestinatarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtDestinatarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDestinatarios.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDestinatarios.Location = new System.Drawing.Point(16, 64);
            this.txtDestinatarios.Name = "txtDestinatarios";
            this.txtDestinatarios.Size = new System.Drawing.Size(466, 23);
            this.txtDestinatarios.TabIndex = 2;
            // 
            // lblAsunto
            // 
            this.lblAsunto.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblAsunto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(135)))));
            this.lblAsunto.Location = new System.Drawing.Point(18, 96);
            this.lblAsunto.Name = "lblAsunto";
            this.lblAsunto.Size = new System.Drawing.Size(150, 14);
            this.lblAsunto.TabIndex = 3;
            this.lblAsunto.Text = "Asunto del correo";
            // 
            // txtAsunto
            // 
            this.txtAsunto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAsunto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtAsunto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAsunto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAsunto.Location = new System.Drawing.Point(16, 114);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(466, 23);
            this.txtAsunto.TabIndex = 4;
            this.txtAsunto.Text = "Reporte Automático - SystemPOS";
            // 
            // lblFormato
            // 
            this.lblFormato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.lblFormato.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblFormato.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(140)))), ((int)(((byte)(155)))));
            this.lblFormato.Location = new System.Drawing.Point(16, 150);
            this.lblFormato.Name = "lblFormato";
            this.lblFormato.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblFormato.Size = new System.Drawing.Size(466, 18);
            this.lblFormato.TabIndex = 5;
            this.lblFormato.Text = "FORMATO DE EXPORTACIÓN";
            this.lblFormato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbPDF
            // 
            this.rbPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbPDF.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.rbPDF.Location = new System.Drawing.Point(18, 174);
            this.rbPDF.Name = "rbPDF";
            this.rbPDF.Size = new System.Drawing.Size(56, 20);
            this.rbPDF.TabIndex = 6;
            this.rbPDF.Text = "PDF";
            // 
            // rbExcel
            // 
            this.rbExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbExcel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.rbExcel.Location = new System.Drawing.Point(82, 174);
            this.rbExcel.Name = "rbExcel";
            this.rbExcel.Size = new System.Drawing.Size(64, 20);
            this.rbExcel.TabIndex = 7;
            this.rbExcel.Text = "Excel";
            // 
            // chkAmbosFormatos
            // 
            this.chkAmbosFormatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAmbosFormatos.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkAmbosFormatos.Location = new System.Drawing.Point(154, 174);
            this.chkAmbosFormatos.Name = "chkAmbosFormatos";
            this.chkAmbosFormatos.Size = new System.Drawing.Size(68, 20);
            this.chkAmbosFormatos.TabIndex = 8;
            this.chkAmbosFormatos.Text = "Ambos";
            // 
            // pnlHdrCorreo
            // 
            this.pnlHdrCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlHdrCorreo.Controls.Add(this.lblTitHdrCorreo);
            this.pnlHdrCorreo.Controls.Add(this.lblIconCorreo);
            this.pnlHdrCorreo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHdrCorreo.Location = new System.Drawing.Point(0, 0);
            this.pnlHdrCorreo.Name = "pnlHdrCorreo";
            this.pnlHdrCorreo.Size = new System.Drawing.Size(494, 42);
            this.pnlHdrCorreo.TabIndex = 1;
            // 
            // lblTitHdrCorreo
            // 
            this.lblTitHdrCorreo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitHdrCorreo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitHdrCorreo.ForeColor = System.Drawing.Color.White;
            this.lblTitHdrCorreo.Location = new System.Drawing.Point(38, 13);
            this.lblTitHdrCorreo.Name = "lblTitHdrCorreo";
            this.lblTitHdrCorreo.Size = new System.Drawing.Size(280, 18);
            this.lblTitHdrCorreo.TabIndex = 0;
            this.lblTitHdrCorreo.Text = "NOTIFICACIONES POR CORREO";
            // 
            // lblIconCorreo
            // 
            this.lblIconCorreo.BackColor = System.Drawing.Color.Transparent;
            this.lblIconCorreo.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.lblIconCorreo.ForeColor = System.Drawing.Color.White;
            this.lblIconCorreo.Location = new System.Drawing.Point(12, 11);
            this.lblIconCorreo.Name = "lblIconCorreo";
            this.lblIconCorreo.Size = new System.Drawing.Size(20, 20);
            this.lblIconCorreo.TabIndex = 1;
            this.lblIconCorreo.Text = "";
            // 
            // pnlColAlertas
            // 
            this.pnlColAlertas.BackColor = System.Drawing.Color.White;
            this.pnlColAlertas.Controls.Add(this.pnlBodyAlertas);
            this.pnlColAlertas.Controls.Add(this.pnlHdrAlertas);
            this.pnlColAlertas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColAlertas.Location = new System.Drawing.Point(1018, 0);
            this.pnlColAlertas.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.pnlColAlertas.Name = "pnlColAlertas";
            this.pnlColAlertas.Size = new System.Drawing.Size(503, 645);
            this.pnlColAlertas.TabIndex = 2;
            // 
            // pnlBodyAlertas
            // 
            this.pnlBodyAlertas.BackColor = System.Drawing.Color.White;
            this.pnlBodyAlertas.Controls.Add(this.chkAlertaStockBajo);
            this.pnlBodyAlertas.Controls.Add(this.chkNotificarVentasMayores);
            this.pnlBodyAlertas.Controls.Add(this.numMontoVentas);
            this.pnlBodyAlertas.Controls.Add(this.lblMontoUnidad);
            this.pnlBodyAlertas.Controls.Add(this.chkAlertarProductosVencer);
            this.pnlBodyAlertas.Controls.Add(this.chkNotificarCompras);
            this.pnlBodyAlertas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBodyAlertas.Location = new System.Drawing.Point(0, 42);
            this.pnlBodyAlertas.Name = "pnlBodyAlertas";
            this.pnlBodyAlertas.Size = new System.Drawing.Size(503, 603);
            this.pnlBodyAlertas.TabIndex = 0;
            // 
            // chkAlertaStockBajo
            // 
            this.chkAlertaStockBajo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAlertaStockBajo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkAlertaStockBajo.Location = new System.Drawing.Point(16, 14);
            this.chkAlertaStockBajo.Name = "chkAlertaStockBajo";
            this.chkAlertaStockBajo.Size = new System.Drawing.Size(290, 20);
            this.chkAlertaStockBajo.TabIndex = 0;
            this.chkAlertaStockBajo.Text = "Alertar cuando stock esté bajo";
            // 
            // chkNotificarVentasMayores
            // 
            this.chkNotificarVentasMayores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkNotificarVentasMayores.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkNotificarVentasMayores.Location = new System.Drawing.Point(16, 40);
            this.chkNotificarVentasMayores.Name = "chkNotificarVentasMayores";
            this.chkNotificarVentasMayores.Size = new System.Drawing.Size(200, 20);
            this.chkNotificarVentasMayores.TabIndex = 1;
            this.chkNotificarVentasMayores.Text = "Notificar ventas mayores a:";
            // 
            // numMontoVentas
            // 
            this.numMontoVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMontoVentas.DecimalPlaces = 2;
            this.numMontoVentas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numMontoVentas.Location = new System.Drawing.Point(34, 64);
            this.numMontoVentas.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numMontoVentas.Name = "numMontoVentas";
            this.numMontoVentas.Size = new System.Drawing.Size(100, 23);
            this.numMontoVentas.TabIndex = 2;
            // 
            // lblMontoUnidad
            // 
            this.lblMontoUnidad.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMontoUnidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(135)))));
            this.lblMontoUnidad.Location = new System.Drawing.Point(140, 66);
            this.lblMontoUnidad.Name = "lblMontoUnidad";
            this.lblMontoUnidad.Size = new System.Drawing.Size(40, 18);
            this.lblMontoUnidad.TabIndex = 3;
            this.lblMontoUnidad.Text = "soles";
            // 
            // chkAlertarProductosVencer
            // 
            this.chkAlertarProductosVencer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAlertarProductosVencer.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkAlertarProductosVencer.Location = new System.Drawing.Point(16, 96);
            this.chkAlertarProductosVencer.Name = "chkAlertarProductosVencer";
            this.chkAlertarProductosVencer.Size = new System.Drawing.Size(290, 20);
            this.chkAlertarProductosVencer.TabIndex = 4;
            this.chkAlertarProductosVencer.Text = "Alertar productos próximos a vencer";
            // 
            // chkNotificarCompras
            // 
            this.chkNotificarCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkNotificarCompras.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkNotificarCompras.Location = new System.Drawing.Point(16, 122);
            this.chkNotificarCompras.Name = "chkNotificarCompras";
            this.chkNotificarCompras.Size = new System.Drawing.Size(230, 20);
            this.chkNotificarCompras.TabIndex = 5;
            this.chkNotificarCompras.Text = "Notificar compras realizadas";
            // 
            // pnlHdrAlertas
            // 
            this.pnlHdrAlertas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.pnlHdrAlertas.Controls.Add(this.lblTitHdrAlertas);
            this.pnlHdrAlertas.Controls.Add(this.lblIconAlertas);
            this.pnlHdrAlertas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHdrAlertas.Location = new System.Drawing.Point(0, 0);
            this.pnlHdrAlertas.Name = "pnlHdrAlertas";
            this.pnlHdrAlertas.Size = new System.Drawing.Size(503, 42);
            this.pnlHdrAlertas.TabIndex = 1;
            // 
            // lblTitHdrAlertas
            // 
            this.lblTitHdrAlertas.BackColor = System.Drawing.Color.Transparent;
            this.lblTitHdrAlertas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitHdrAlertas.ForeColor = System.Drawing.Color.White;
            this.lblTitHdrAlertas.Location = new System.Drawing.Point(38, 13);
            this.lblTitHdrAlertas.Name = "lblTitHdrAlertas";
            this.lblTitHdrAlertas.Size = new System.Drawing.Size(280, 18);
            this.lblTitHdrAlertas.TabIndex = 0;
            this.lblTitHdrAlertas.Text = "ALERTAS Y NOTIFICACIONES";
            // 
            // lblIconAlertas
            // 
            this.lblIconAlertas.BackColor = System.Drawing.Color.Transparent;
            this.lblIconAlertas.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.lblIconAlertas.ForeColor = System.Drawing.Color.White;
            this.lblIconAlertas.Location = new System.Drawing.Point(12, 11);
            this.lblIconAlertas.Name = "lblIconAlertas";
            this.lblIconAlertas.Size = new System.Drawing.Size(20, 20);
            this.lblIconAlertas.TabIndex = 1;
            this.lblIconAlertas.Text = "";
            // 
            // pnlFooterBar
            // 
            this.pnlFooterBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlFooterBar.Controls.Add(this.lblEstadoGuardado);
            this.pnlFooterBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterBar.Location = new System.Drawing.Point(0, 733);
            this.pnlFooterBar.Name = "pnlFooterBar";
            this.pnlFooterBar.Size = new System.Drawing.Size(1545, 56);
            this.pnlFooterBar.TabIndex = 1;
            // 
            // lblEstadoGuardado
            // 
            this.lblEstadoGuardado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstadoGuardado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEstadoGuardado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(185)))), ((int)(((byte)(205)))));
            this.lblEstadoGuardado.Location = new System.Drawing.Point(0, 0);
            this.lblEstadoGuardado.Name = "lblEstadoGuardado";
            this.lblEstadoGuardado.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.lblEstadoGuardado.Size = new System.Drawing.Size(1545, 56);
            this.lblEstadoGuardado.TabIndex = 0;
            this.lblEstadoGuardado.Text = "  Los cambios se guardan al cerrar o pulsando Guardar";
            this.lblEstadoGuardado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(153)))), ((int)(((byte)(82)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(1392, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(141, 40);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // FormReportes
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1545, 789);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooterBar);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FormReportes";
            this.Text = "Configuración de Reportes";
            this.pnlHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.pnlColReportes.ResumeLayout(false);
            this.pnlBodyReportes.ResumeLayout(false);
            this.pnlHdrReportes.ResumeLayout(false);
            this.pnlColCorreo.ResumeLayout(false);
            this.pnlBodyCorreo.ResumeLayout(false);
            this.pnlBodyCorreo.PerformLayout();
            this.pnlHdrCorreo.ResumeLayout(false);
            this.pnlColAlertas.ResumeLayout(false);
            this.pnlBodyAlertas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numMontoVentas)).EndInit();
            this.pnlHdrAlertas.ResumeLayout(false);
            this.pnlFooterBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel         pnlHeader;
        private System.Windows.Forms.Label         lblIconHeader;
        private System.Windows.Forms.Label         lblTituloHeader;
        private System.Windows.Forms.Label         lblSubHeader;
        private System.Windows.Forms.Panel         pnlContent;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel         pnlColReportes;
        private System.Windows.Forms.Panel         pnlHdrReportes;
        private System.Windows.Forms.Label         lblIconReportes;
        private System.Windows.Forms.Label         lblTitHdrReportes;
        private System.Windows.Forms.Panel         pnlBodyReportes;
        private System.Windows.Forms.CheckBox      chkGenerarReportes;
        private System.Windows.Forms.Label         lblFrecuencia;
        private System.Windows.Forms.RadioButton   rbDiario;
        private System.Windows.Forms.RadioButton   rbSemanal;
        private System.Windows.Forms.RadioButton   rbMensual;
        private System.Windows.Forms.Label         lblDiaEnvio;
        private System.Windows.Forms.ComboBox      cmbDiaEnvio;
        private System.Windows.Forms.Label         lblHora;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Label         lblSeccionReportes;
        private System.Windows.Forms.CheckBox      chkMostrarLogo;
        private System.Windows.Forms.CheckBox      chkMostrarNombre;
        private System.Windows.Forms.CheckBox      chkMostrarRUC;
        private System.Windows.Forms.CheckBox      chkMostrarDireccion;
        private System.Windows.Forms.CheckBox      chkMostrarTelefono;
        private System.Windows.Forms.CheckBox      chkMostrarEmail;
        private System.Windows.Forms.Panel         pnlColCorreo;
        private System.Windows.Forms.Panel         pnlHdrCorreo;
        private System.Windows.Forms.Label         lblIconCorreo;
        private System.Windows.Forms.Label         lblTitHdrCorreo;
        private System.Windows.Forms.Panel         pnlBodyCorreo;
        private System.Windows.Forms.CheckBox      chkEnviarporCorreo;
        private System.Windows.Forms.Label         lblDestinatarios;
        private System.Windows.Forms.TextBox       txtDestinatarios;
        private System.Windows.Forms.Label         lblAsunto;
        private System.Windows.Forms.TextBox       txtAsunto;
        private System.Windows.Forms.Label         lblFormato;
        private System.Windows.Forms.RadioButton   rbPDF;
        private System.Windows.Forms.RadioButton   rbExcel;
        private System.Windows.Forms.CheckBox      chkAmbosFormatos;
        private System.Windows.Forms.Panel         pnlColAlertas;
        private System.Windows.Forms.Panel         pnlHdrAlertas;
        private System.Windows.Forms.Label         lblIconAlertas;
        private System.Windows.Forms.Label         lblTitHdrAlertas;
        private System.Windows.Forms.Panel         pnlBodyAlertas;
        private System.Windows.Forms.CheckBox      chkAlertaStockBajo;
        private System.Windows.Forms.CheckBox      chkNotificarVentasMayores;
        private System.Windows.Forms.NumericUpDown numMontoVentas;
        private System.Windows.Forms.Label         lblMontoUnidad;
        private System.Windows.Forms.CheckBox      chkAlertarProductosVencer;
        private System.Windows.Forms.CheckBox      chkNotificarCompras;
        private System.Windows.Forms.Panel         pnlFooterBar;
        private System.Windows.Forms.Label         lblEstadoGuardado;
        private System.Windows.Forms.Button        btnGuardar;
    }
}
