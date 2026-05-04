namespace SistemaPOS.Forms.Finanzas
{
    partial class FormCaja
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.btnCerrarCaja = new System.Windows.Forms.Button();
            this.btnConversion = new System.Windows.Forms.Button();
            this.btnMoneteo = new System.Windows.Forms.Button();
            this.btnCapitalInicial = new System.Windows.Forms.Button();
            this.btnAbrirTurno = new System.Windows.Forms.Button();
            this.lblTurnoInfo = new System.Windows.Forms.Label();
            this.lblStatusText = new System.Windows.Forms.Label();
            this.pnlStatusDot = new System.Windows.Forms.Panel();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabDashboard = new System.Windows.Forms.TabPage();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.tabControlDetalle = new System.Windows.Forms.TabControl();
            this.tabVentas = new System.Windows.Forms.TabPage();
            this.dgvVentasTurno = new System.Windows.Forms.DataGridView();
            this.colVentaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVentaNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVentaCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVentaMetodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVentaTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabGastos = new System.Windows.Forms.TabPage();
            this.dgvGastosTurno = new System.Windows.Forms.DataGridView();
            this.colGastoHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGastoConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGastoCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGastoMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabConversiones = new System.Windows.Forms.TabPage();
            this.dgvConversionesTurno = new System.Windows.Forms.DataGridView();
            this.colConvHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConvOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConvDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConvMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConvObs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowPanelTarjetas = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCardTotal = new System.Windows.Forms.Panel();
            this.lblCardTotalOps = new System.Windows.Forms.Label();
            this.lblCardTotalMonto = new System.Windows.Forms.Label();
            this.lblCardTotalTitulo = new System.Windows.Forms.Label();
            this.pnlCardEfectivo = new System.Windows.Forms.Panel();
            this.lblCardEfectivoMonto = new System.Windows.Forms.Label();
            this.lblCardEfectivoTitulo = new System.Windows.Forms.Label();
            this.pnlCardYape = new System.Windows.Forms.Panel();
            this.lblCardYapeMonto = new System.Windows.Forms.Label();
            this.lblCardYapeTitulo = new System.Windows.Forms.Label();
            this.pnlCardTransferencia = new System.Windows.Forms.Panel();
            this.lblCardTransferenciaMonto = new System.Windows.Forms.Label();
            this.lblCardTransferenciaTitulo = new System.Windows.Forms.Label();
            this.pnlCardGastos = new System.Windows.Forms.Panel();
            this.lblCardGastosMonto = new System.Windows.Forms.Label();
            this.lblCardGastosTitulo = new System.Windows.Forms.Label();
            this.pnlNoTurno = new System.Windows.Forms.Panel();
            this.lblNoTurnoSub = new System.Windows.Forms.Label();
            this.lblNoTurnoMsg = new System.Windows.Forms.Label();
            this.lblNoTurnoIcono = new System.Windows.Forms.Label();
            this.tabHistorial = new System.Windows.Forms.TabPage();
            this.dgvHistorialCaja = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCierre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEncargado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalIngresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVerDetalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlStatusBar = new System.Windows.Forms.Panel();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.cmbUsuarios = new System.Windows.Forms.ComboBox();
            this.lblUsuarioFiltro = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabDashboard.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.tabControlDetalle.SuspendLayout();
            this.tabVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasTurno)).BeginInit();
            this.tabGastos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastosTurno)).BeginInit();
            this.tabConversiones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConversionesTurno)).BeginInit();
            this.flowPanelTarjetas.SuspendLayout();
            this.pnlCardTotal.SuspendLayout();
            this.pnlCardEfectivo.SuspendLayout();
            this.pnlCardYape.SuspendLayout();
            this.pnlCardTransferencia.SuspendLayout();
            this.pnlCardGastos.SuspendLayout();
            this.pnlNoTurno.SuspendLayout();
            this.tabHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialCaja)).BeginInit();
            this.pnlStatusBar.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.btnCerrarCaja);
            this.pnlHeader.Controls.Add(this.btnAbrirTurno);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 68);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblHeaderSub
            // 
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.lblHeaderSub.Location = new System.Drawing.Point(22, 40);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(265, 15);
            this.lblHeaderSub.TabIndex = 0;
            this.lblHeaderSub.Text = "Control de turnos, arqueo y movimientos de caja";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(231, 25);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Gestión de Caja y Turnos";
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopBar.Controls.Add(this.btnConversion);
            this.pnlTopBar.Controls.Add(this.btnMoneteo);
            this.pnlTopBar.Controls.Add(this.lblTurnoInfo);
            this.pnlTopBar.Controls.Add(this.lblStatusText);
            this.pnlTopBar.Controls.Add(this.pnlStatusDot);
            this.pnlTopBar.Controls.Add(this.btnCapitalInicial);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 68);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1200, 60);
            this.pnlTopBar.TabIndex = 1;
            // 
            // btnCerrarCaja
            // 
            this.btnCerrarCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnCerrarCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarCaja.FlatAppearance.BorderSize = 0;
            this.btnCerrarCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarCaja.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrarCaja.ForeColor = System.Drawing.Color.White;
            this.btnCerrarCaja.Location = new System.Drawing.Point(1032, 19);
            this.btnCerrarCaja.Name = "btnCerrarCaja";
            this.btnCerrarCaja.Size = new System.Drawing.Size(156, 36);
            this.btnCerrarCaja.TabIndex = 0;
            this.btnCerrarCaja.Text = "Cerrar Caja / Turno";
            this.btnCerrarCaja.UseVisualStyleBackColor = false;
            this.btnCerrarCaja.Visible = false;
            // 
            // btnConversion
            // 
            this.btnConversion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConversion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnConversion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConversion.FlatAppearance.BorderSize = 0;
            this.btnConversion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConversion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnConversion.ForeColor = System.Drawing.Color.White;
            this.btnConversion.Location = new System.Drawing.Point(1077, 14);
            this.btnConversion.Name = "btnConversion";
            this.btnConversion.Size = new System.Drawing.Size(110, 32);
            this.btnConversion.TabIndex = 1;
            this.btnConversion.Text = "Conversión";
            this.btnConversion.UseVisualStyleBackColor = false;
            this.btnConversion.Visible = false;
            // 
            // btnMoneteo
            // 
            this.btnMoneteo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoneteo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnMoneteo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoneteo.FlatAppearance.BorderSize = 0;
            this.btnMoneteo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoneteo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMoneteo.ForeColor = System.Drawing.Color.White;
            this.btnMoneteo.Location = new System.Drawing.Point(823, 14);
            this.btnMoneteo.Name = "btnMoneteo";
            this.btnMoneteo.Size = new System.Drawing.Size(100, 32);
            this.btnMoneteo.TabIndex = 2;
            this.btnMoneteo.Text = "Moneteo";
            this.btnMoneteo.UseVisualStyleBackColor = false;
            this.btnMoneteo.Visible = false;
            // 
            // btnCapitalInicial
            // 
            this.btnCapitalInicial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapitalInicial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnCapitalInicial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapitalInicial.FlatAppearance.BorderSize = 0;
            this.btnCapitalInicial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapitalInicial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCapitalInicial.ForeColor = System.Drawing.Color.White;
            this.btnCapitalInicial.Location = new System.Drawing.Point(939, 14);
            this.btnCapitalInicial.Name = "btnCapitalInicial";
            this.btnCapitalInicial.Size = new System.Drawing.Size(120, 32);
            this.btnCapitalInicial.TabIndex = 3;
            this.btnCapitalInicial.Text = "Capital Inicial";
            this.btnCapitalInicial.UseVisualStyleBackColor = false;
            this.btnCapitalInicial.Visible = false;
            // 
            // btnAbrirTurno
            // 
            this.btnAbrirTurno.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAbrirTurno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnAbrirTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirTurno.FlatAppearance.BorderSize = 0;
            this.btnAbrirTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirTurno.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAbrirTurno.ForeColor = System.Drawing.Color.White;
            this.btnAbrirTurno.Location = new System.Drawing.Point(524, 19);
            this.btnAbrirTurno.Name = "btnAbrirTurno";
            this.btnAbrirTurno.Size = new System.Drawing.Size(140, 36);
            this.btnAbrirTurno.TabIndex = 4;
            this.btnAbrirTurno.Text = "+ Abrir Turno";
            this.btnAbrirTurno.UseVisualStyleBackColor = false;
            // 
            // lblTurnoInfo
            // 
            this.lblTurnoInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTurnoInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.lblTurnoInfo.Location = new System.Drawing.Point(36, 36);
            this.lblTurnoInfo.Name = "lblTurnoInfo";
            this.lblTurnoInfo.Size = new System.Drawing.Size(426, 16);
            this.lblTurnoInfo.TabIndex = 5;
            this.lblTurnoInfo.Visible = false;
            // 
            // lblStatusText
            // 
            this.lblStatusText.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStatusText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblStatusText.Location = new System.Drawing.Point(36, 14);
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(200, 20);
            this.lblStatusText.TabIndex = 6;
            this.lblStatusText.Text = "SIN TURNO ACTIVO";
            // 
            // pnlStatusDot
            // 
            this.pnlStatusDot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.pnlStatusDot.Location = new System.Drawing.Point(16, 23);
            this.pnlStatusDot.Name = "pnlStatusDot";
            this.pnlStatusDot.Size = new System.Drawing.Size(12, 12);
            this.pnlStatusDot.TabIndex = 7;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabDashboard);
            this.tabMain.Controls.Add(this.tabHistorial);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabMain.Location = new System.Drawing.Point(0, 128);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Drawing.Point(10, 4);
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1200, 622);
            this.tabMain.TabIndex = 0;
            // 
            // tabDashboard
            // 
            this.tabDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.tabDashboard.Controls.Add(this.pnlDashboard);
            this.tabDashboard.Controls.Add(this.pnlNoTurno);
            this.tabDashboard.Location = new System.Drawing.Point(4, 28);
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.Size = new System.Drawing.Size(1192, 590);
            this.tabDashboard.TabIndex = 0;
            this.tabDashboard.Text = "  Dashboard  ";
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlDashboard.Controls.Add(this.tabControlDetalle);
            this.pnlDashboard.Controls.Add(this.flowPanelTarjetas);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboard.Location = new System.Drawing.Point(0, 0);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(1192, 590);
            this.pnlDashboard.TabIndex = 0;
            this.pnlDashboard.Visible = false;
            // 
            // tabControlDetalle
            // 
            this.tabControlDetalle.Controls.Add(this.tabVentas);
            this.tabControlDetalle.Controls.Add(this.tabGastos);
            this.tabControlDetalle.Controls.Add(this.tabConversiones);
            this.tabControlDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabControlDetalle.Location = new System.Drawing.Point(0, 112);
            this.tabControlDetalle.Name = "tabControlDetalle";
            this.tabControlDetalle.SelectedIndex = 0;
            this.tabControlDetalle.Size = new System.Drawing.Size(1192, 478);
            this.tabControlDetalle.TabIndex = 0;
            // 
            // tabVentas
            // 
            this.tabVentas.BackColor = System.Drawing.Color.White;
            this.tabVentas.Controls.Add(this.dgvVentasTurno);
            this.tabVentas.Location = new System.Drawing.Point(4, 24);
            this.tabVentas.Name = "tabVentas";
            this.tabVentas.Size = new System.Drawing.Size(1184, 450);
            this.tabVentas.TabIndex = 0;
            this.tabVentas.Text = "  Ventas del Turno  ";
            // 
            // dgvVentasTurno
            // 
            this.dgvVentasTurno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVentaHora,
            this.colVentaNumero,
            this.colVentaCliente,
            this.colVentaMetodo,
            this.colVentaTotal});
            this.dgvVentasTurno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVentasTurno.Location = new System.Drawing.Point(0, 0);
            this.dgvVentasTurno.Name = "dgvVentasTurno";
            this.dgvVentasTurno.Size = new System.Drawing.Size(1184, 450);
            this.dgvVentasTurno.TabIndex = 0;
            // 
            // colVentaHora
            // 
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colVentaHora.DefaultCellStyle = dataGridViewCellStyle35;
            this.colVentaHora.HeaderText = "Hora";
            this.colVentaHora.Name = "colVentaHora";
            this.colVentaHora.Width = 72;
            // 
            // colVentaNumero
            // 
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colVentaNumero.DefaultCellStyle = dataGridViewCellStyle36;
            this.colVentaNumero.HeaderText = "Nro. Venta";
            this.colVentaNumero.Name = "colVentaNumero";
            this.colVentaNumero.Width = 110;
            // 
            // colVentaCliente
            // 
            this.colVentaCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colVentaCliente.HeaderText = "Cliente";
            this.colVentaCliente.Name = "colVentaCliente";
            // 
            // colVentaMetodo
            // 
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colVentaMetodo.DefaultCellStyle = dataGridViewCellStyle37;
            this.colVentaMetodo.HeaderText = "Método";
            this.colVentaMetodo.Name = "colVentaMetodo";
            this.colVentaMetodo.Width = 110;
            // 
            // colVentaTotal
            // 
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colVentaTotal.DefaultCellStyle = dataGridViewCellStyle38;
            this.colVentaTotal.HeaderText = "Total";
            this.colVentaTotal.Name = "colVentaTotal";
            this.colVentaTotal.Width = 120;
            // 
            // tabGastos
            // 
            this.tabGastos.BackColor = System.Drawing.Color.White;
            this.tabGastos.Controls.Add(this.dgvGastosTurno);
            this.tabGastos.Location = new System.Drawing.Point(4, 24);
            this.tabGastos.Name = "tabGastos";
            this.tabGastos.Size = new System.Drawing.Size(192, 0);
            this.tabGastos.TabIndex = 1;
            this.tabGastos.Text = "  Gastos del Turno  ";
            // 
            // dgvGastosTurno
            // 
            this.dgvGastosTurno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGastoHora,
            this.colGastoConcepto,
            this.colGastoCategoria,
            this.colGastoMonto});
            this.dgvGastosTurno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGastosTurno.Location = new System.Drawing.Point(0, 0);
            this.dgvGastosTurno.Name = "dgvGastosTurno";
            this.dgvGastosTurno.Size = new System.Drawing.Size(192, 0);
            this.dgvGastosTurno.TabIndex = 0;
            // 
            // colGastoHora
            // 
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colGastoHora.DefaultCellStyle = dataGridViewCellStyle39;
            this.colGastoHora.HeaderText = "Hora";
            this.colGastoHora.Name = "colGastoHora";
            this.colGastoHora.Width = 72;
            // 
            // colGastoConcepto
            // 
            this.colGastoConcepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGastoConcepto.HeaderText = "Concepto";
            this.colGastoConcepto.Name = "colGastoConcepto";
            // 
            // colGastoCategoria
            // 
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colGastoCategoria.DefaultCellStyle = dataGridViewCellStyle40;
            this.colGastoCategoria.HeaderText = "Categoría";
            this.colGastoCategoria.Name = "colGastoCategoria";
            this.colGastoCategoria.Width = 150;
            // 
            // colGastoMonto
            // 
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colGastoMonto.DefaultCellStyle = dataGridViewCellStyle41;
            this.colGastoMonto.HeaderText = "Monto";
            this.colGastoMonto.Name = "colGastoMonto";
            this.colGastoMonto.Width = 120;
            // 
            // tabConversiones
            // 
            this.tabConversiones.BackColor = System.Drawing.Color.White;
            this.tabConversiones.Controls.Add(this.dgvConversionesTurno);
            this.tabConversiones.Location = new System.Drawing.Point(4, 24);
            this.tabConversiones.Name = "tabConversiones";
            this.tabConversiones.Size = new System.Drawing.Size(192, 0);
            this.tabConversiones.TabIndex = 2;
            this.tabConversiones.Text = "  Conversiones  ";
            // 
            // dgvConversionesTurno
            // 
            this.dgvConversionesTurno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConvHora,
            this.colConvOrigen,
            this.colConvDestino,
            this.colConvMonto,
            this.colConvObs});
            this.dgvConversionesTurno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConversionesTurno.Location = new System.Drawing.Point(0, 0);
            this.dgvConversionesTurno.Name = "dgvConversionesTurno";
            this.dgvConversionesTurno.Size = new System.Drawing.Size(192, 0);
            this.dgvConversionesTurno.TabIndex = 0;
            // 
            // colConvHora
            // 
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colConvHora.DefaultCellStyle = dataGridViewCellStyle42;
            this.colConvHora.HeaderText = "Hora";
            this.colConvHora.Name = "colConvHora";
            this.colConvHora.Width = 72;
            // 
            // colConvOrigen
            // 
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colConvOrigen.DefaultCellStyle = dataGridViewCellStyle43;
            this.colConvOrigen.HeaderText = "Origen";
            this.colConvOrigen.Name = "colConvOrigen";
            this.colConvOrigen.Width = 130;
            // 
            // colConvDestino
            // 
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colConvDestino.DefaultCellStyle = dataGridViewCellStyle44;
            this.colConvDestino.HeaderText = "Destino";
            this.colConvDestino.Name = "colConvDestino";
            this.colConvDestino.Width = 130;
            // 
            // colConvMonto
            // 
            dataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colConvMonto.DefaultCellStyle = dataGridViewCellStyle45;
            this.colConvMonto.HeaderText = "Monto";
            this.colConvMonto.Name = "colConvMonto";
            this.colConvMonto.Width = 120;
            // 
            // colConvObs
            // 
            this.colConvObs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colConvObs.HeaderText = "Observación";
            this.colConvObs.Name = "colConvObs";
            // 
            // flowPanelTarjetas
            // 
            this.flowPanelTarjetas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.flowPanelTarjetas.Controls.Add(this.pnlCardTotal);
            this.flowPanelTarjetas.Controls.Add(this.pnlCardEfectivo);
            this.flowPanelTarjetas.Controls.Add(this.pnlCardYape);
            this.flowPanelTarjetas.Controls.Add(this.pnlCardTransferencia);
            this.flowPanelTarjetas.Controls.Add(this.pnlCardGastos);
            this.flowPanelTarjetas.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowPanelTarjetas.Location = new System.Drawing.Point(0, 0);
            this.flowPanelTarjetas.Name = "flowPanelTarjetas";
            this.flowPanelTarjetas.Padding = new System.Windows.Forms.Padding(10);
            this.flowPanelTarjetas.Size = new System.Drawing.Size(1192, 112);
            this.flowPanelTarjetas.TabIndex = 1;
            this.flowPanelTarjetas.WrapContents = false;
            // 
            // pnlCardTotal
            // 
            this.pnlCardTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlCardTotal.Controls.Add(this.lblCardTotalOps);
            this.pnlCardTotal.Controls.Add(this.lblCardTotalMonto);
            this.pnlCardTotal.Controls.Add(this.lblCardTotalTitulo);
            this.pnlCardTotal.Location = new System.Drawing.Point(16, 12);
            this.pnlCardTotal.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.pnlCardTotal.Name = "pnlCardTotal";
            this.pnlCardTotal.Size = new System.Drawing.Size(220, 88);
            this.pnlCardTotal.TabIndex = 0;
            // 
            // lblCardTotalOps
            // 
            this.lblCardTotalOps.AutoSize = true;
            this.lblCardTotalOps.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCardTotalOps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.lblCardTotalOps.Location = new System.Drawing.Point(12, 62);
            this.lblCardTotalOps.Name = "lblCardTotalOps";
            this.lblCardTotalOps.Size = new System.Drawing.Size(79, 13);
            this.lblCardTotalOps.TabIndex = 0;
            this.lblCardTotalOps.Text = "0 operaciones";
            // 
            // lblCardTotalMonto
            // 
            this.lblCardTotalMonto.AutoSize = true;
            this.lblCardTotalMonto.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCardTotalMonto.ForeColor = System.Drawing.Color.White;
            this.lblCardTotalMonto.Location = new System.Drawing.Point(10, 26);
            this.lblCardTotalMonto.Name = "lblCardTotalMonto";
            this.lblCardTotalMonto.Size = new System.Drawing.Size(86, 30);
            this.lblCardTotalMonto.TabIndex = 1;
            this.lblCardTotalMonto.Text = "S/ 0.00";
            // 
            // lblCardTotalTitulo
            // 
            this.lblCardTotalTitulo.AutoSize = true;
            this.lblCardTotalTitulo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCardTotalTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.lblCardTotalTitulo.Location = new System.Drawing.Point(12, 8);
            this.lblCardTotalTitulo.Name = "lblCardTotalTitulo";
            this.lblCardTotalTitulo.Size = new System.Drawing.Size(80, 13);
            this.lblCardTotalTitulo.TabIndex = 2;
            this.lblCardTotalTitulo.Text = "TOTAL VENTAS";
            // 
            // pnlCardEfectivo
            // 
            this.pnlCardEfectivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.pnlCardEfectivo.Controls.Add(this.lblCardEfectivoMonto);
            this.pnlCardEfectivo.Controls.Add(this.lblCardEfectivoTitulo);
            this.pnlCardEfectivo.Location = new System.Drawing.Point(242, 12);
            this.pnlCardEfectivo.Margin = new System.Windows.Forms.Padding(0, 2, 6, 2);
            this.pnlCardEfectivo.Name = "pnlCardEfectivo";
            this.pnlCardEfectivo.Size = new System.Drawing.Size(220, 88);
            this.pnlCardEfectivo.TabIndex = 1;
            // 
            // lblCardEfectivoMonto
            // 
            this.lblCardEfectivoMonto.AutoSize = true;
            this.lblCardEfectivoMonto.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCardEfectivoMonto.ForeColor = System.Drawing.Color.White;
            this.lblCardEfectivoMonto.Location = new System.Drawing.Point(10, 26);
            this.lblCardEfectivoMonto.Name = "lblCardEfectivoMonto";
            this.lblCardEfectivoMonto.Size = new System.Drawing.Size(86, 30);
            this.lblCardEfectivoMonto.TabIndex = 0;
            this.lblCardEfectivoMonto.Text = "S/ 0.00";
            // 
            // lblCardEfectivoTitulo
            // 
            this.lblCardEfectivoTitulo.AutoSize = true;
            this.lblCardEfectivoTitulo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCardEfectivoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(250)))), ((int)(((byte)(225)))));
            this.lblCardEfectivoTitulo.Location = new System.Drawing.Point(12, 8);
            this.lblCardEfectivoTitulo.Name = "lblCardEfectivoTitulo";
            this.lblCardEfectivoTitulo.Size = new System.Drawing.Size(57, 13);
            this.lblCardEfectivoTitulo.TabIndex = 1;
            this.lblCardEfectivoTitulo.Text = "EFECTIVO";
            // 
            // pnlCardYape
            // 
            this.pnlCardYape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.pnlCardYape.Controls.Add(this.lblCardYapeMonto);
            this.pnlCardYape.Controls.Add(this.lblCardYapeTitulo);
            this.pnlCardYape.Location = new System.Drawing.Point(468, 12);
            this.pnlCardYape.Margin = new System.Windows.Forms.Padding(0, 2, 6, 2);
            this.pnlCardYape.Name = "pnlCardYape";
            this.pnlCardYape.Size = new System.Drawing.Size(220, 88);
            this.pnlCardYape.TabIndex = 2;
            // 
            // lblCardYapeMonto
            // 
            this.lblCardYapeMonto.AutoSize = true;
            this.lblCardYapeMonto.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCardYapeMonto.ForeColor = System.Drawing.Color.White;
            this.lblCardYapeMonto.Location = new System.Drawing.Point(10, 26);
            this.lblCardYapeMonto.Name = "lblCardYapeMonto";
            this.lblCardYapeMonto.Size = new System.Drawing.Size(86, 30);
            this.lblCardYapeMonto.TabIndex = 0;
            this.lblCardYapeMonto.Text = "S/ 0.00";
            // 
            // lblCardYapeTitulo
            // 
            this.lblCardYapeTitulo.AutoSize = true;
            this.lblCardYapeTitulo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCardYapeTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(190)))), ((int)(((byte)(250)))));
            this.lblCardYapeTitulo.Location = new System.Drawing.Point(12, 8);
            this.lblCardYapeTitulo.Name = "lblCardYapeTitulo";
            this.lblCardYapeTitulo.Size = new System.Drawing.Size(30, 13);
            this.lblCardYapeTitulo.TabIndex = 1;
            this.lblCardYapeTitulo.Text = "YAPE";
            // 
            // pnlCardTransferencia
            // 
            this.pnlCardTransferencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlCardTransferencia.Controls.Add(this.lblCardTransferenciaMonto);
            this.pnlCardTransferencia.Controls.Add(this.lblCardTransferenciaTitulo);
            this.pnlCardTransferencia.Location = new System.Drawing.Point(694, 12);
            this.pnlCardTransferencia.Margin = new System.Windows.Forms.Padding(0, 2, 6, 2);
            this.pnlCardTransferencia.Name = "pnlCardTransferencia";
            this.pnlCardTransferencia.Size = new System.Drawing.Size(220, 88);
            this.pnlCardTransferencia.TabIndex = 3;
            // 
            // lblCardTransferenciaMonto
            // 
            this.lblCardTransferenciaMonto.AutoSize = true;
            this.lblCardTransferenciaMonto.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCardTransferenciaMonto.ForeColor = System.Drawing.Color.White;
            this.lblCardTransferenciaMonto.Location = new System.Drawing.Point(10, 26);
            this.lblCardTransferenciaMonto.Name = "lblCardTransferenciaMonto";
            this.lblCardTransferenciaMonto.Size = new System.Drawing.Size(86, 30);
            this.lblCardTransferenciaMonto.TabIndex = 0;
            this.lblCardTransferenciaMonto.Text = "S/ 0.00";
            // 
            // lblCardTransferenciaTitulo
            // 
            this.lblCardTransferenciaTitulo.AutoSize = true;
            this.lblCardTransferenciaTitulo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCardTransferenciaTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(225)))), ((int)(((byte)(250)))));
            this.lblCardTransferenciaTitulo.Location = new System.Drawing.Point(12, 8);
            this.lblCardTransferenciaTitulo.Name = "lblCardTransferenciaTitulo";
            this.lblCardTransferenciaTitulo.Size = new System.Drawing.Size(91, 13);
            this.lblCardTransferenciaTitulo.TabIndex = 1;
            this.lblCardTransferenciaTitulo.Text = "TRANSFERENCIA";
            // 
            // pnlCardGastos
            // 
            this.pnlCardGastos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.pnlCardGastos.Controls.Add(this.lblCardGastosMonto);
            this.pnlCardGastos.Controls.Add(this.lblCardGastosTitulo);
            this.pnlCardGastos.Location = new System.Drawing.Point(920, 12);
            this.pnlCardGastos.Margin = new System.Windows.Forms.Padding(0, 2, 6, 2);
            this.pnlCardGastos.Name = "pnlCardGastos";
            this.pnlCardGastos.Size = new System.Drawing.Size(220, 88);
            this.pnlCardGastos.TabIndex = 4;
            // 
            // lblCardGastosMonto
            // 
            this.lblCardGastosMonto.AutoSize = true;
            this.lblCardGastosMonto.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCardGastosMonto.ForeColor = System.Drawing.Color.White;
            this.lblCardGastosMonto.Location = new System.Drawing.Point(10, 26);
            this.lblCardGastosMonto.Name = "lblCardGastosMonto";
            this.lblCardGastosMonto.Size = new System.Drawing.Size(86, 30);
            this.lblCardGastosMonto.TabIndex = 0;
            this.lblCardGastosMonto.Text = "S/ 0.00";
            // 
            // lblCardGastosTitulo
            // 
            this.lblCardGastosTitulo.AutoSize = true;
            this.lblCardGastosTitulo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCardGastosTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(200)))));
            this.lblCardGastosTitulo.Location = new System.Drawing.Point(12, 8);
            this.lblCardGastosTitulo.Name = "lblCardGastosTitulo";
            this.lblCardGastosTitulo.Size = new System.Drawing.Size(101, 13);
            this.lblCardGastosTitulo.TabIndex = 1;
            this.lblCardGastosTitulo.Text = "GASTOS EFECTIVO";
            // 
            // pnlNoTurno
            // 
            this.pnlNoTurno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlNoTurno.Controls.Add(this.lblNoTurnoSub);
            this.pnlNoTurno.Controls.Add(this.lblNoTurnoMsg);
            this.pnlNoTurno.Controls.Add(this.lblNoTurnoIcono);
            this.pnlNoTurno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoTurno.Location = new System.Drawing.Point(0, 0);
            this.pnlNoTurno.Name = "pnlNoTurno";
            this.pnlNoTurno.Size = new System.Drawing.Size(1192, 590);
            this.pnlNoTurno.TabIndex = 1;
            // 
            // lblNoTurnoSub
            // 
            this.lblNoTurnoSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNoTurnoSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblNoTurnoSub.Location = new System.Drawing.Point(220, 298);
            this.lblNoTurnoSub.Name = "lblNoTurnoSub";
            this.lblNoTurnoSub.Size = new System.Drawing.Size(760, 22);
            this.lblNoTurnoSub.TabIndex = 0;
            this.lblNoTurnoSub.Text = "Usa el botón \"+ Abrir Turno\" para comenzar a registrar ventas y gastos";
            this.lblNoTurnoSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNoTurnoMsg
            // 
            this.lblNoTurnoMsg.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblNoTurnoMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.lblNoTurnoMsg.Location = new System.Drawing.Point(280, 255);
            this.lblNoTurnoMsg.Name = "lblNoTurnoMsg";
            this.lblNoTurnoMsg.Size = new System.Drawing.Size(640, 36);
            this.lblNoTurnoMsg.TabIndex = 1;
            this.lblNoTurnoMsg.Text = "No hay turno activo en este momento";
            this.lblNoTurnoMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNoTurnoIcono
            // 
            this.lblNoTurnoIcono.Font = new System.Drawing.Font("Segoe UI", 40F);
            this.lblNoTurnoIcono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.lblNoTurnoIcono.Location = new System.Drawing.Point(540, 160);
            this.lblNoTurnoIcono.Name = "lblNoTurnoIcono";
            this.lblNoTurnoIcono.Size = new System.Drawing.Size(120, 80);
            this.lblNoTurnoIcono.TabIndex = 2;
            this.lblNoTurnoIcono.Text = "⬡";
            this.lblNoTurnoIcono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabHistorial
            // 
            this.tabHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.tabHistorial.Controls.Add(this.dgvHistorialCaja);
            this.tabHistorial.Controls.Add(this.pnlStatusBar);
            this.tabHistorial.Controls.Add(this.pnlFiltros);
            this.tabHistorial.Location = new System.Drawing.Point(4, 28);
            this.tabHistorial.Name = "tabHistorial";
            this.tabHistorial.Size = new System.Drawing.Size(1192, 590);
            this.tabHistorial.TabIndex = 1;
            this.tabHistorial.Text = "  Historial de Turnos  ";
            // 
            // dgvHistorialCaja
            // 
            this.dgvHistorialCaja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colTurno,
            this.colApertura,
            this.colCierre,
            this.colDuracion,
            this.colEncargado,
            this.colTotalIngresos,
            this.colEstado,
            this.colVerDetalle});
            this.dgvHistorialCaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorialCaja.Location = new System.Drawing.Point(0, 44);
            this.dgvHistorialCaja.Name = "dgvHistorialCaja";
            this.dgvHistorialCaja.Size = new System.Drawing.Size(1192, 518);
            this.dgvHistorialCaja.TabIndex = 0;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            // 
            // colTurno
            // 
            dataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTurno.DefaultCellStyle = dataGridViewCellStyle46;
            this.colTurno.HeaderText = "Turno";
            this.colTurno.Name = "colTurno";
            this.colTurno.Width = 82;
            // 
            // colApertura
            // 
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colApertura.DefaultCellStyle = dataGridViewCellStyle47;
            this.colApertura.HeaderText = "Apertura";
            this.colApertura.Name = "colApertura";
            this.colApertura.Width = 80;
            // 
            // colCierre
            // 
            dataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCierre.DefaultCellStyle = dataGridViewCellStyle48;
            this.colCierre.HeaderText = "Cierre";
            this.colCierre.Name = "colCierre";
            this.colCierre.Width = 80;
            // 
            // colDuracion
            // 
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDuracion.DefaultCellStyle = dataGridViewCellStyle49;
            this.colDuracion.HeaderText = "Duración";
            this.colDuracion.Name = "colDuracion";
            // 
            // colEncargado
            // 
            this.colEncargado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEncargado.HeaderText = "Encargado";
            this.colEncargado.Name = "colEncargado";
            // 
            // colTotalIngresos
            // 
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTotalIngresos.DefaultCellStyle = dataGridViewCellStyle50;
            this.colTotalIngresos.HeaderText = "Total Ingresos";
            this.colTotalIngresos.Name = "colTotalIngresos";
            this.colTotalIngresos.Width = 120;
            // 
            // colEstado
            // 
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEstado.DefaultCellStyle = dataGridViewCellStyle51;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.Width = 80;
            // 
            // colVerDetalle
            // 
            this.colVerDetalle.HeaderText = "";
            this.colVerDetalle.Name = "colVerDetalle";
            this.colVerDetalle.Text = "Ver";
            this.colVerDetalle.UseColumnTextForButtonValue = true;
            this.colVerDetalle.Width = 54;
            // 
            // pnlStatusBar
            // 
            this.pnlStatusBar.BackColor = System.Drawing.Color.White;
            this.pnlStatusBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatusBar.Controls.Add(this.lblTotalRegistros);
            this.pnlStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatusBar.Location = new System.Drawing.Point(0, 562);
            this.pnlStatusBar.Name = "pnlStatusBar";
            this.pnlStatusBar.Size = new System.Drawing.Size(1192, 28);
            this.pnlStatusBar.TabIndex = 1;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalRegistros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblTotalRegistros.Location = new System.Drawing.Point(8, 7);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(92, 15);
            this.lblTotalRegistros.TabIndex = 0;
            this.lblTotalRegistros.Text = "Total: 0 registros";
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFiltros.Controls.Add(this.btnExportar);
            this.pnlFiltros.Controls.Add(this.cmbUsuarios);
            this.pnlFiltros.Controls.Add(this.lblUsuarioFiltro);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.lblDesde);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1192, 44);
            this.pnlFiltros.TabIndex = 2;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(614, 8);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(110, 26);
            this.btnExportar.TabIndex = 0;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            // 
            // cmbUsuarios
            // 
            this.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuarios.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbUsuarios.Location = new System.Drawing.Point(420, 9);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(180, 23);
            this.cmbUsuarios.TabIndex = 1;
            // 
            // lblUsuarioFiltro
            // 
            this.lblUsuarioFiltro.AutoSize = true;
            this.lblUsuarioFiltro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsuarioFiltro.Location = new System.Drawing.Point(346, 13);
            this.lblUsuarioFiltro.Name = "lblUsuarioFiltro";
            this.lblUsuarioFiltro.Size = new System.Drawing.Size(66, 15);
            this.lblUsuarioFiltro.TabIndex = 2;
            this.lblUsuarioFiltro.Text = "Encargado:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(224, 9);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(110, 24);
            this.dtpHasta.TabIndex = 3;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHasta.Location = new System.Drawing.Point(180, 13);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(40, 15);
            this.lblHasta.TabIndex = 4;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(60, 9);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(110, 24);
            this.dtpDesde.TabIndex = 5;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesde.Location = new System.Drawing.Point(8, 13);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(42, 15);
            this.lblDesde.TabIndex = 6;
            this.lblDesde.Text = "Desde:";
            // 
            // FormCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FormCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Caja y Turnos";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTopBar.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabDashboard.ResumeLayout(false);
            this.pnlDashboard.ResumeLayout(false);
            this.tabControlDetalle.ResumeLayout(false);
            this.tabVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasTurno)).EndInit();
            this.tabGastos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastosTurno)).EndInit();
            this.tabConversiones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConversionesTurno)).EndInit();
            this.flowPanelTarjetas.ResumeLayout(false);
            this.pnlCardTotal.ResumeLayout(false);
            this.pnlCardTotal.PerformLayout();
            this.pnlCardEfectivo.ResumeLayout(false);
            this.pnlCardEfectivo.PerformLayout();
            this.pnlCardYape.ResumeLayout(false);
            this.pnlCardYape.PerformLayout();
            this.pnlCardTransferencia.ResumeLayout(false);
            this.pnlCardTransferencia.PerformLayout();
            this.pnlCardGastos.ResumeLayout(false);
            this.pnlCardGastos.PerformLayout();
            this.pnlNoTurno.ResumeLayout(false);
            this.tabHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialCaja)).EndInit();
            this.pnlStatusBar.ResumeLayout(false);
            this.pnlStatusBar.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        // ── Field declarations ─────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblHeaderSub;

        private System.Windows.Forms.Panel  pnlTopBar;
        private System.Windows.Forms.Panel  pnlStatusDot;
        private System.Windows.Forms.Label  lblStatusText;
        private System.Windows.Forms.Label  lblTurnoInfo;
        private System.Windows.Forms.Button btnAbrirTurno;
        private System.Windows.Forms.Button btnCapitalInicial;
        private System.Windows.Forms.Button btnMoneteo;
        private System.Windows.Forms.Button btnConversion;
        private System.Windows.Forms.Button btnCerrarCaja;

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage    tabDashboard;
        private System.Windows.Forms.TabPage    tabHistorial;

        private System.Windows.Forms.Panel pnlNoTurno;
        private System.Windows.Forms.Label lblNoTurnoIcono;
        private System.Windows.Forms.Label lblNoTurnoMsg;
        private System.Windows.Forms.Label lblNoTurnoSub;

        private System.Windows.Forms.Panel             pnlDashboard;
        private System.Windows.Forms.FlowLayoutPanel   flowPanelTarjetas;
        private System.Windows.Forms.Panel  pnlCardTotal;
        private System.Windows.Forms.Label  lblCardTotalTitulo;
        private System.Windows.Forms.Label  lblCardTotalMonto;
        private System.Windows.Forms.Label  lblCardTotalOps;
        private System.Windows.Forms.Panel  pnlCardEfectivo;
        private System.Windows.Forms.Label  lblCardEfectivoTitulo;
        private System.Windows.Forms.Label  lblCardEfectivoMonto;
        private System.Windows.Forms.Panel  pnlCardYape;
        private System.Windows.Forms.Label  lblCardYapeTitulo;
        private System.Windows.Forms.Label  lblCardYapeMonto;
        private System.Windows.Forms.Panel  pnlCardTransferencia;
        private System.Windows.Forms.Label  lblCardTransferenciaTitulo;
        private System.Windows.Forms.Label  lblCardTransferenciaMonto;
        private System.Windows.Forms.Panel  pnlCardGastos;
        private System.Windows.Forms.Label  lblCardGastosTitulo;
        private System.Windows.Forms.Label  lblCardGastosMonto;
        private System.Windows.Forms.TabControl tabControlDetalle;
        private System.Windows.Forms.TabPage    tabVentas;
        private System.Windows.Forms.DataGridView              dgvVentasTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaMetodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaTotal;
        private System.Windows.Forms.TabPage    tabGastos;
        private System.Windows.Forms.DataGridView              dgvGastosTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGastoHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGastoConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGastoCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGastoMonto;
        private System.Windows.Forms.TabPage    tabConversiones;
        private System.Windows.Forms.DataGridView              dgvConversionesTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConvHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConvOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConvDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConvMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConvObs;

        private System.Windows.Forms.Panel    pnlFiltros;
        private System.Windows.Forms.Label    lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label    lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label    lblUsuarioFiltro;
        private System.Windows.Forms.ComboBox cmbUsuarios;
        private System.Windows.Forms.Button   btnExportar;
        private System.Windows.Forms.Panel    pnlStatusBar;
        private System.Windows.Forms.Label    lblTotalRegistros;
        private System.Windows.Forms.DataGridView              dgvHistorialCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCierre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEncargado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalIngresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewButtonColumn  colVerDetalle;
    }
}
