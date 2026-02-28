namespace SistemaPOS.Forms.Finanzas
{
    partial class FormCaja
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCaja));

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.chkImprimir = new System.Windows.Forms.CheckBox();
            this.btnCapitalInicial = new System.Windows.Forms.Button();
            this.btnCerrarCaja = new System.Windows.Forms.Button();
            this.pnlCierreCaja = new System.Windows.Forms.Panel();
            this.lblSubTitulo = new System.Windows.Forms.Label();
            this.lblCajaAbierta = new System.Windows.Forms.Label();
            this.txtStockActual = new System.Windows.Forms.TextBox();
            this.lblEncargado = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblAperturaFechaHora = new System.Windows.Forms.Label();
            this.lblFondoInicial = new System.Windows.Forms.Label();
            this.lblTiempoTranscurrido = new System.Windows.Forms.Label();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.lblSubTitulo2 = new System.Windows.Forms.Label();
            this.lblApertura = new System.Windows.Forms.Label();
            this.lblOperaciones = new System.Windows.Forms.Label();
            this.lblLineaDivisora2 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotalCantidad = new System.Windows.Forms.TextBox();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.txtEfectivoCantidad = new System.Windows.Forms.TextBox();
            this.lbllblYape = new System.Windows.Forms.Label();
            this.txtYapeCantidad = new System.Windows.Forms.TextBox();
            this.lblTransferencia = new System.Windows.Forms.Label();
            this.txtTransferenciaCantidad = new System.Windows.Forms.TextBox();
            this.lblCredito = new System.Windows.Forms.Label();
            this.txtCreditoCantidad = new System.Windows.Forms.TextBox();
            this.pnlArqueo = new System.Windows.Forms.Panel();
            this.lblSubTitulo3 = new System.Windows.Forms.Label();
            this.lblEfectivoEsperado = new System.Windows.Forms.Label();
            this.txtEfectivoEsperado = new System.Windows.Forms.TextBox();
            this.lblEfectivoReal = new System.Windows.Forms.Label();
            this.numEfectivoReal = new System.Windows.Forms.NumericUpDown();
            this.lblSeparador = new System.Windows.Forms.Label();
            this.lblDiferencia = new System.Windows.Forms.Label();
            this.txtDiferenciaCantidad = new System.Windows.Forms.TextBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.pnlHistorial = new System.Windows.Forms.Panel();
            this.lblSubTitulo4 = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbUsuarios = new System.Windows.Forms.ComboBox();
            this.dgvHistorialCaja = new System.Windows.Forms.DataGridView();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStocktotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIngresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVer = new System.Windows.Forms.DataGridViewImageColumn();

            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlCierreCaja.SuspendLayout();
            this.pnlResumen.SuspendLayout();
            this.pnlArqueo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEfectivoReal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialCaja)).BeginInit();
            this.pnlHistorial.SuspendLayout();
            this.SuspendLayout();

            // -------------------------------------------------------
            // pnlHeader
            // -------------------------------------------------------
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1284, 68);
            this.pnlHeader.TabIndex = 200;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(260, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Caja y Arqueo";
            //
            // lblHeaderSub
            //
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.lblHeaderSub.Location = new System.Drawing.Point(20, 40);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(200, 15);
            this.lblHeaderSub.TabIndex = 1;
            this.lblHeaderSub.Text = "Control y cierre de turno activo";

            // -------------------------------------------------------
            // pnlFooter
            // -------------------------------------------------------
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnCerrarCaja);
            this.pnlFooter.Controls.Add(this.btnCapitalInicial);
            this.pnlFooter.Controls.Add(this.chkImprimir);
            this.pnlFooter.Controls.Add(this.lblTotalRegistros);
            this.pnlFooter.Controls.Add(this.btnExportar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 606);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1284, 55);
            this.pnlFooter.TabIndex = 201;
            //
            // btnExportar
            //
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnExportar.Location = new System.Drawing.Point(16, 11);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(125, 33);
            this.btnExportar.TabIndex = 10010;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            //
            // lblTotalRegistros
            //
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRegistros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblTotalRegistros.Location = new System.Drawing.Point(155, 20);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(98, 15);
            this.lblTotalRegistros.TabIndex = 10011;
            this.lblTotalRegistros.Text = "Total: 45 registros";
            //
            // chkImprimir
            //
            this.chkImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkImprimir.AutoSize = true;
            this.chkImprimir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkImprimir.Location = new System.Drawing.Point(1038, 19);
            this.chkImprimir.Name = "chkImprimir";
            this.chkImprimir.Size = new System.Drawing.Size(70, 19);
            this.chkImprimir.TabIndex = 10013;
            this.chkImprimir.Text = "Imprimir";
            this.chkImprimir.UseVisualStyleBackColor = true;
            //
            // btnCapitalInicial
            //
            this.btnCapitalInicial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapitalInicial.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnCapitalInicial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapitalInicial.FlatAppearance.BorderSize = 0;
            this.btnCapitalInicial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapitalInicial.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCapitalInicial.ForeColor = System.Drawing.Color.White;
            this.btnCapitalInicial.Location = new System.Drawing.Point(997, 11);
            this.btnCapitalInicial.Name = "btnCapitalInicial";
            this.btnCapitalInicial.Size = new System.Drawing.Size(136, 33);
            this.btnCapitalInicial.TabIndex = 10011;
            this.btnCapitalInicial.Text = "Capital Inicial";
            this.btnCapitalInicial.UseVisualStyleBackColor = false;

            //
            // btnCerrarCaja
            //
            this.btnCerrarCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCerrarCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarCaja.FlatAppearance.BorderSize = 0;
            this.btnCerrarCaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(45)))));
            this.btnCerrarCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarCaja.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCerrarCaja.ForeColor = System.Drawing.Color.White;
            this.btnCerrarCaja.Location = new System.Drawing.Point(1143, 11);
            this.btnCerrarCaja.Name = "btnCerrarCaja";
            this.btnCerrarCaja.Size = new System.Drawing.Size(125, 33);
            this.btnCerrarCaja.TabIndex = 10012;
            this.btnCerrarCaja.Text = "Cerrar Caja";
            this.btnCerrarCaja.UseVisualStyleBackColor = false;

            // -------------------------------------------------------
            // pnlCierreCaja  (card: estado del turno actual)
            // -------------------------------------------------------
            this.pnlCierreCaja.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCierreCaja.BackColor = System.Drawing.Color.White;
            this.pnlCierreCaja.Controls.Add(this.lblTiempoTranscurrido);
            this.pnlCierreCaja.Controls.Add(this.lblFondoInicial);
            this.pnlCierreCaja.Controls.Add(this.lblAperturaFechaHora);
            this.pnlCierreCaja.Controls.Add(this.txtStockActual);
            this.pnlCierreCaja.Controls.Add(this.lblTurno);
            this.pnlCierreCaja.Controls.Add(this.textBox2);
            this.pnlCierreCaja.Controls.Add(this.lblEncargado);
            this.pnlCierreCaja.Controls.Add(this.textBox1);
            this.pnlCierreCaja.Controls.Add(this.lblCajaAbierta);
            this.pnlCierreCaja.Controls.Add(this.lblSubTitulo);
            this.pnlCierreCaja.Location = new System.Drawing.Point(16, 80);
            this.pnlCierreCaja.Name = "pnlCierreCaja";
            this.pnlCierreCaja.Size = new System.Drawing.Size(636, 175);
            this.pnlCierreCaja.TabIndex = 135;
            //
            // lblSubTitulo
            //
            this.lblSubTitulo.AutoSize = true;
            this.lblSubTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblSubTitulo.Location = new System.Drawing.Point(12, 12);
            this.lblSubTitulo.Name = "lblSubTitulo";
            this.lblSubTitulo.Size = new System.Drawing.Size(119, 15);
            this.lblSubTitulo.TabIndex = 12;
            this.lblSubTitulo.Text = "CIERRE DE CAJA";
            //
            // lblCajaAbierta
            //
            this.lblCajaAbierta.AutoSize = true;
            this.lblCajaAbierta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCajaAbierta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblCajaAbierta.Location = new System.Drawing.Point(14, 44);
            this.lblCajaAbierta.Name = "lblCajaAbierta";
            this.lblCajaAbierta.Size = new System.Drawing.Size(73, 15);
            this.lblCajaAbierta.TabIndex = 130;
            this.lblCajaAbierta.Text = "Caja Abierta";
            //
            // textBox1  (vertical separator)
            //
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(106, 41);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1, 22);
            this.textBox1.TabIndex = 141;
            this.textBox1.TabStop = false;
            //
            // lblEncargado
            //
            this.lblEncargado.AutoSize = true;
            this.lblEncargado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncargado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblEncargado.Location = new System.Drawing.Point(118, 44);
            this.lblEncargado.Name = "lblEncargado";
            this.lblEncargado.Size = new System.Drawing.Size(161, 15);
            this.lblEncargado.TabIndex = 138;
            this.lblEncargado.Text = "Encargado: Steven Gamboa";
            //
            // textBox2  (vertical separator)
            //
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(298, 41);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1, 22);
            this.textBox2.TabIndex = 142;
            this.textBox2.TabStop = false;
            //
            // lblTurno
            //
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblTurno.Location = new System.Drawing.Point(310, 44);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(76, 15);
            this.lblTurno.TabIndex = 139;
            this.lblTurno.Text = "Turno: Tarde";
            //
            // txtStockActual  (vertical separator)
            //
            this.txtStockActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStockActual.Location = new System.Drawing.Point(400, 41);
            this.txtStockActual.Multiline = true;
            this.txtStockActual.Name = "txtStockActual";
            this.txtStockActual.Size = new System.Drawing.Size(1, 22);
            this.txtStockActual.TabIndex = 137;
            this.txtStockActual.TabStop = false;
            //
            // lblAperturaFechaHora
            //
            this.lblAperturaFechaHora.AutoSize = true;
            this.lblAperturaFechaHora.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAperturaFechaHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblAperturaFechaHora.Location = new System.Drawing.Point(412, 44);
            this.lblAperturaFechaHora.Name = "lblAperturaFechaHora";
            this.lblAperturaFechaHora.Size = new System.Drawing.Size(155, 15);
            this.lblAperturaFechaHora.TabIndex = 140;
            this.lblAperturaFechaHora.Text = "Apertura: 24/01/2026 14:05";
            //
            // lblFondoInicial
            //
            this.lblFondoInicial.AutoSize = true;
            this.lblFondoInicial.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFondoInicial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblFondoInicial.Location = new System.Drawing.Point(14, 90);
            this.lblFondoInicial.Name = "lblFondoInicial";
            this.lblFondoInicial.Size = new System.Drawing.Size(174, 20);
            this.lblFondoInicial.TabIndex = 136;
            this.lblFondoInicial.Text = "Fondo Inicial: S/ 200.00";
            //
            // lblTiempoTranscurrido
            //
            this.lblTiempoTranscurrido.AutoSize = true;
            this.lblTiempoTranscurrido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoTranscurrido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblTiempoTranscurrido.Location = new System.Drawing.Point(14, 128);
            this.lblTiempoTranscurrido.Name = "lblTiempoTranscurrido";
            this.lblTiempoTranscurrido.Size = new System.Drawing.Size(159, 15);
            this.lblTiempoTranscurrido.TabIndex = 133;
            this.lblTiempoTranscurrido.Text = "Tiempo transcurrido: 6h 10m";

            // -------------------------------------------------------
            // pnlResumen  (card: resumen de ingresos — middle column)
            // -------------------------------------------------------
            this.pnlResumen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlResumen.BackColor = System.Drawing.Color.White;
            this.pnlResumen.Controls.Add(this.txtTotalCantidad);
            this.pnlResumen.Controls.Add(this.txtCreditoCantidad);
            this.pnlResumen.Controls.Add(this.txtTransferenciaCantidad);
            this.pnlResumen.Controls.Add(this.txtYapeCantidad);
            this.pnlResumen.Controls.Add(this.txtEfectivoCantidad);
            this.pnlResumen.Controls.Add(this.lblTotal);
            this.pnlResumen.Controls.Add(this.lblLineaDivisora2);
            this.pnlResumen.Controls.Add(this.lblCredito);
            this.pnlResumen.Controls.Add(this.lblTransferencia);
            this.pnlResumen.Controls.Add(this.lbllblYape);
            this.pnlResumen.Controls.Add(this.lblEfectivo);
            this.pnlResumen.Controls.Add(this.lblOperaciones);
            this.pnlResumen.Controls.Add(this.lblApertura);
            this.pnlResumen.Controls.Add(this.lblSubTitulo2);
            this.pnlResumen.Location = new System.Drawing.Point(660, 80);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(300, 514);
            this.pnlResumen.TabIndex = 136;
            //
            // lblSubTitulo2
            //
            this.lblSubTitulo2.AutoSize = true;
            this.lblSubTitulo2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitulo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblSubTitulo2.Location = new System.Drawing.Point(12, 12);
            this.lblSubTitulo2.Name = "lblSubTitulo2";
            this.lblSubTitulo2.Size = new System.Drawing.Size(176, 15);
            this.lblSubTitulo2.TabIndex = 111;
            this.lblSubTitulo2.Text = "RESUMEN DE INGRESOS";
            //
            // lblApertura
            //
            this.lblApertura.AutoSize = true;
            this.lblApertura.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApertura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblApertura.Location = new System.Drawing.Point(16, 40);
            this.lblApertura.Name = "lblApertura";
            this.lblApertura.Size = new System.Drawing.Size(147, 15);
            this.lblApertura.TabIndex = 143;
            this.lblApertura.Text = "Apertura: 24/01/2026 14:05";
            //
            // lblOperaciones
            //
            this.lblOperaciones.AutoSize = true;
            this.lblOperaciones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblOperaciones.Location = new System.Drawing.Point(16, 60);
            this.lblOperaciones.Name = "lblOperaciones";
            this.lblOperaciones.Size = new System.Drawing.Size(91, 15);
            this.lblOperaciones.TabIndex = 141;
            this.lblOperaciones.Text = "Operaciones: 15";
            //
            // lblEfectivo
            //
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfectivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblEfectivo.Location = new System.Drawing.Point(20, 98);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(52, 15);
            this.lblEfectivo.TabIndex = 154;
            this.lblEfectivo.Text = "Efectivo:";
            //
            // txtEfectivoCantidad
            //
            this.txtEfectivoCantidad.BackColor = System.Drawing.Color.White;
            this.txtEfectivoCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEfectivoCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivoCantidad.Location = new System.Drawing.Point(172, 98);
            this.txtEfectivoCantidad.Multiline = true;
            this.txtEfectivoCantidad.Name = "txtEfectivoCantidad";
            this.txtEfectivoCantidad.ReadOnly = true;
            this.txtEfectivoCantidad.Size = new System.Drawing.Size(110, 20);
            this.txtEfectivoCantidad.TabIndex = 10023;
            this.txtEfectivoCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lbllblYape
            //
            this.lbllblYape.AutoSize = true;
            this.lbllblYape.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllblYape.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lbllblYape.Location = new System.Drawing.Point(20, 130);
            this.lbllblYape.Name = "lbllblYape";
            this.lbllblYape.Size = new System.Drawing.Size(35, 15);
            this.lbllblYape.TabIndex = 145;
            this.lbllblYape.Text = "Yape:";
            //
            // txtYapeCantidad
            //
            this.txtYapeCantidad.BackColor = System.Drawing.Color.White;
            this.txtYapeCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtYapeCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYapeCantidad.Location = new System.Drawing.Point(172, 130);
            this.txtYapeCantidad.Multiline = true;
            this.txtYapeCantidad.Name = "txtYapeCantidad";
            this.txtYapeCantidad.ReadOnly = true;
            this.txtYapeCantidad.Size = new System.Drawing.Size(110, 20);
            this.txtYapeCantidad.TabIndex = 10024;
            this.txtYapeCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lblTransferencia
            //
            this.lblTransferencia.AutoSize = true;
            this.lblTransferencia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransferencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblTransferencia.Location = new System.Drawing.Point(20, 162);
            this.lblTransferencia.Name = "lblTransferencia";
            this.lblTransferencia.Size = new System.Drawing.Size(79, 15);
            this.lblTransferencia.TabIndex = 152;
            this.lblTransferencia.Text = "Transferencia:";
            //
            // txtTransferenciaCantidad
            //
            this.txtTransferenciaCantidad.BackColor = System.Drawing.Color.White;
            this.txtTransferenciaCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTransferenciaCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransferenciaCantidad.Location = new System.Drawing.Point(172, 162);
            this.txtTransferenciaCantidad.Multiline = true;
            this.txtTransferenciaCantidad.Name = "txtTransferenciaCantidad";
            this.txtTransferenciaCantidad.ReadOnly = true;
            this.txtTransferenciaCantidad.Size = new System.Drawing.Size(110, 20);
            this.txtTransferenciaCantidad.TabIndex = 10025;
            this.txtTransferenciaCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lblCredito
            //
            this.lblCredito.AutoSize = true;
            this.lblCredito.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblCredito.Location = new System.Drawing.Point(20, 194);
            this.lblCredito.Name = "lblCredito";
            this.lblCredito.Size = new System.Drawing.Size(60, 15);
            this.lblCredito.TabIndex = 153;
            this.lblCredito.Text = "A Crédito:";
            //
            // txtCreditoCantidad
            //
            this.txtCreditoCantidad.BackColor = System.Drawing.Color.White;
            this.txtCreditoCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCreditoCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditoCantidad.Location = new System.Drawing.Point(172, 194);
            this.txtCreditoCantidad.Multiline = true;
            this.txtCreditoCantidad.Name = "txtCreditoCantidad";
            this.txtCreditoCantidad.ReadOnly = true;
            this.txtCreditoCantidad.Size = new System.Drawing.Size(110, 20);
            this.txtCreditoCantidad.TabIndex = 10026;
            this.txtCreditoCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lblLineaDivisora2
            //
            this.lblLineaDivisora2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.lblLineaDivisora2.Location = new System.Drawing.Point(16, 224);
            this.lblLineaDivisora2.Name = "lblLineaDivisora2";
            this.lblLineaDivisora2.Size = new System.Drawing.Size(268, 1);
            this.lblLineaDivisora2.TabIndex = 151;
            //
            // lblTotal
            //
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblTotal.Location = new System.Drawing.Point(19, 238);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(58, 20);
            this.lblTotal.TabIndex = 149;
            this.lblTotal.Text = "TOTAL:";
            //
            // txtTotalCantidad
            //
            this.txtTotalCantidad.BackColor = System.Drawing.Color.White;
            this.txtTotalCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalCantidad.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCantidad.Location = new System.Drawing.Point(172, 238);
            this.txtTotalCantidad.Multiline = true;
            this.txtTotalCantidad.Name = "txtTotalCantidad";
            this.txtTotalCantidad.ReadOnly = true;
            this.txtTotalCantidad.Size = new System.Drawing.Size(110, 22);
            this.txtTotalCantidad.TabIndex = 10027;
            this.txtTotalCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // -------------------------------------------------------
            // pnlArqueo  (card: arqueo de efectivo — right column)
            // -------------------------------------------------------
            this.pnlArqueo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlArqueo.BackColor = System.Drawing.Color.White;
            this.pnlArqueo.Controls.Add(this.txtMotivo);
            this.pnlArqueo.Controls.Add(this.txtDiferenciaCantidad);
            this.pnlArqueo.Controls.Add(this.txtEfectivoEsperado);
            this.pnlArqueo.Controls.Add(this.lblMotivo);
            this.pnlArqueo.Controls.Add(this.lblSeparador);
            this.pnlArqueo.Controls.Add(this.lblDiferencia);
            this.pnlArqueo.Controls.Add(this.numEfectivoReal);
            this.pnlArqueo.Controls.Add(this.lblEfectivoReal);
            this.pnlArqueo.Controls.Add(this.lblEfectivoEsperado);
            this.pnlArqueo.Controls.Add(this.lblSubTitulo3);
            this.pnlArqueo.Location = new System.Drawing.Point(968, 80);
            this.pnlArqueo.Name = "pnlArqueo";
            this.pnlArqueo.Size = new System.Drawing.Size(300, 514);
            this.pnlArqueo.TabIndex = 153;
            //
            // lblSubTitulo3
            //
            this.lblSubTitulo3.AutoSize = true;
            this.lblSubTitulo3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitulo3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblSubTitulo3.Location = new System.Drawing.Point(12, 12);
            this.lblSubTitulo3.Name = "lblSubTitulo3";
            this.lblSubTitulo3.Size = new System.Drawing.Size(162, 15);
            this.lblSubTitulo3.TabIndex = 111;
            this.lblSubTitulo3.Text = "ARQUEO DE EFECTIVO";
            //
            // lblEfectivoEsperado
            //
            this.lblEfectivoEsperado.AutoSize = true;
            this.lblEfectivoEsperado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfectivoEsperado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblEfectivoEsperado.Location = new System.Drawing.Point(17, 48);
            this.lblEfectivoEsperado.Name = "lblEfectivoEsperado";
            this.lblEfectivoEsperado.Size = new System.Drawing.Size(103, 15);
            this.lblEfectivoEsperado.TabIndex = 141;
            this.lblEfectivoEsperado.Text = "Efectivo Esperado:";
            //
            // txtEfectivoEsperado
            //
            this.txtEfectivoEsperado.BackColor = System.Drawing.Color.White;
            this.txtEfectivoEsperado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEfectivoEsperado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivoEsperado.Location = new System.Drawing.Point(178, 48);
            this.txtEfectivoEsperado.Multiline = true;
            this.txtEfectivoEsperado.Name = "txtEfectivoEsperado";
            this.txtEfectivoEsperado.ReadOnly = true;
            this.txtEfectivoEsperado.Size = new System.Drawing.Size(110, 20);
            this.txtEfectivoEsperado.TabIndex = 10028;
            this.txtEfectivoEsperado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lblEfectivoReal
            //
            this.lblEfectivoReal.AutoSize = true;
            this.lblEfectivoReal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfectivoReal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblEfectivoReal.Location = new System.Drawing.Point(17, 82);
            this.lblEfectivoReal.Name = "lblEfectivoReal";
            this.lblEfectivoReal.Size = new System.Drawing.Size(77, 15);
            this.lblEfectivoReal.TabIndex = 145;
            this.lblEfectivoReal.Text = "Efectivo Real:";
            //
            // numEfectivoReal
            //
            this.numEfectivoReal.DecimalPlaces = 2;
            this.numEfectivoReal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numEfectivoReal.Location = new System.Drawing.Point(178, 79);
            this.numEfectivoReal.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numEfectivoReal.Name = "numEfectivoReal";
            this.numEfectivoReal.Size = new System.Drawing.Size(110, 25);
            this.numEfectivoReal.TabIndex = 10000;
            this.numEfectivoReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lblSeparador
            //
            this.lblSeparador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.lblSeparador.Location = new System.Drawing.Point(17, 118);
            this.lblSeparador.Name = "lblSeparador";
            this.lblSeparador.Size = new System.Drawing.Size(265, 1);
            this.lblSeparador.TabIndex = 151;
            //
            // lblDiferencia
            //
            this.lblDiferencia.AutoSize = true;
            this.lblDiferencia.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblDiferencia.Location = new System.Drawing.Point(17, 128);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(80, 20);
            this.lblDiferencia.TabIndex = 147;
            this.lblDiferencia.Text = "Diferencia:";
            //
            // txtDiferenciaCantidad
            //
            this.txtDiferenciaCantidad.BackColor = System.Drawing.Color.White;
            this.txtDiferenciaCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiferenciaCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiferenciaCantidad.Location = new System.Drawing.Point(178, 130);
            this.txtDiferenciaCantidad.Multiline = true;
            this.txtDiferenciaCantidad.Name = "txtDiferenciaCantidad";
            this.txtDiferenciaCantidad.ReadOnly = true;
            this.txtDiferenciaCantidad.Size = new System.Drawing.Size(110, 20);
            this.txtDiferenciaCantidad.TabIndex = 10029;
            this.txtDiferenciaCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lblMotivo
            //
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblMotivo.Location = new System.Drawing.Point(17, 165);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(107, 15);
            this.lblMotivo.TabIndex = 149;
            this.lblMotivo.Text = "Motivo (Si Aplica):";
            //
            // txtMotivo
            //
            this.txtMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivo.Location = new System.Drawing.Point(17, 185);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(268, 55);
            this.txtMotivo.TabIndex = 10001;

            // -------------------------------------------------------
            // pnlHistorial  (card: historial de cajas — left bottom)
            // -------------------------------------------------------
            this.pnlHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHistorial.BackColor = System.Drawing.Color.White;
            this.pnlHistorial.Controls.Add(this.dgvHistorialCaja);
            this.pnlHistorial.Controls.Add(this.cmbUsuarios);
            this.pnlHistorial.Controls.Add(this.lblEstado);
            this.pnlHistorial.Controls.Add(this.dtpHasta);
            this.pnlHistorial.Controls.Add(this.lblHasta);
            this.pnlHistorial.Controls.Add(this.dtpDesde);
            this.pnlHistorial.Controls.Add(this.lblDesde);
            this.pnlHistorial.Controls.Add(this.lblSubTitulo4);
            this.pnlHistorial.Location = new System.Drawing.Point(16, 264);
            this.pnlHistorial.Name = "pnlHistorial";
            this.pnlHistorial.Size = new System.Drawing.Size(636, 330);
            this.pnlHistorial.TabIndex = 143;
            //
            // lblSubTitulo4
            //
            this.lblSubTitulo4.AutoSize = true;
            this.lblSubTitulo4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitulo4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblSubTitulo4.Location = new System.Drawing.Point(12, 12);
            this.lblSubTitulo4.Name = "lblSubTitulo4";
            this.lblSubTitulo4.Size = new System.Drawing.Size(151, 15);
            this.lblSubTitulo4.TabIndex = 143;
            this.lblSubTitulo4.Text = "HISTORIAL DE CAJAS";
            //
            // lblDesde
            //
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblDesde.Location = new System.Drawing.Point(8, 50);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(42, 15);
            this.lblDesde.TabIndex = 10007;
            this.lblDesde.Text = "Desde:";
            //
            // dtpDesde
            //
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(58, 47);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(92, 20);
            this.dtpDesde.TabIndex = 143;
            //
            // lblHasta
            //
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblHasta.Location = new System.Drawing.Point(168, 50);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(40, 15);
            this.lblHasta.TabIndex = 10009;
            this.lblHasta.Text = "Hasta:";
            //
            // dtpHasta
            //
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(215, 47);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(92, 20);
            this.dtpHasta.TabIndex = 10008;
            //
            // lblEstado
            //
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblEstado.Location = new System.Drawing.Point(325, 50);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(55, 15);
            this.lblEstado.TabIndex = 10006;
            this.lblEstado.Text = "Usuarios:";
            //
            // cmbUsuarios
            //
            this.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuarios.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsuarios.FormattingEnabled = true;
            this.cmbUsuarios.Location = new System.Drawing.Point(386, 47);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(140, 23);
            this.cmbUsuarios.TabIndex = 10004;
            //
            // dgvHistorialCaja
            //
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorialCaja.AllowUserToAddRows = false;
            this.dgvHistorialCaja.AllowUserToDeleteRows = false;
            this.dgvHistorialCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorialCaja.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHistorialCaja.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorialCaja.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorialCaja.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvHistorialCaja.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistorialCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialCaja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumero,
            this.colFechaHora,
            this.colCategoria,
            this.colStocktotal,
            this.colStockMinimo,
            this.colEstado,
            this.colIngresos,
            this.colVer});
            this.dgvHistorialCaja.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistorialCaja.EnableHeadersVisualStyles = false;
            this.dgvHistorialCaja.Location = new System.Drawing.Point(0, 80);
            this.dgvHistorialCaja.Name = "dgvHistorialCaja";
            this.dgvHistorialCaja.RowHeadersVisible = false;
            this.dgvHistorialCaja.RowTemplate.Height = 40;
            this.dgvHistorialCaja.Size = new System.Drawing.Size(636, 248);
            this.dgvHistorialCaja.TabIndex = 10003;
            //
            // colNumero
            //
            this.colNumero.HeaderText = "#";
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            this.colNumero.Width = 30;
            //
            // colFechaHora
            //
            this.colFechaHora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colFechaHora.HeaderText = "Fecha";
            this.colFechaHora.Name = "colFechaHora";
            this.colFechaHora.ReadOnly = true;
            this.colFechaHora.Width = 90;
            //
            // colCategoria
            //
            this.colCategoria.HeaderText = "H. Apertura";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            this.colCategoria.Width = 90;
            //
            // colStocktotal
            //
            this.colStocktotal.HeaderText = "H. Cierre";
            this.colStocktotal.Name = "colStocktotal";
            this.colStocktotal.ReadOnly = true;
            this.colStocktotal.Width = 90;
            //
            // colStockMinimo
            //
            this.colStockMinimo.HeaderText = "Duración";
            this.colStockMinimo.Name = "colStockMinimo";
            this.colStockMinimo.ReadOnly = true;
            this.colStockMinimo.Width = 75;
            //
            // colEstado
            //
            this.colEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEstado.HeaderText = "Encargado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            //
            // colIngresos
            //
            this.colIngresos.HeaderText = "Ingresos";
            this.colIngresos.Name = "colIngresos";
            this.colIngresos.ReadOnly = true;
            this.colIngresos.Width = 90;
            //
            // colVer
            //
            this.colVer.HeaderText = "";
            this.colVer.Image = ((System.Drawing.Image)(resources.GetObject("colVer.Image")));
            this.colVer.Name = "colVer";
            this.colVer.ReadOnly = true;
            this.colVer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colVer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colVer.Width = 30;

            // -------------------------------------------------------
            // FormCaja
            // -------------------------------------------------------
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.pnlHistorial);
            this.Controls.Add(this.pnlCierreCaja);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.pnlArqueo);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCaja";
            this.Text = "FormCaja";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlCierreCaja.ResumeLayout(false);
            this.pnlCierreCaja.PerformLayout();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.pnlArqueo.ResumeLayout(false);
            this.pnlArqueo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEfectivoReal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialCaja)).EndInit();
            this.pnlHistorial.ResumeLayout(false);
            this.pnlHistorial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.CheckBox chkImprimir;
        private System.Windows.Forms.Button btnCapitalInicial;
        private System.Windows.Forms.Button btnCerrarCaja;
        private System.Windows.Forms.Panel pnlCierreCaja;
        private System.Windows.Forms.Label lblSubTitulo;
        private System.Windows.Forms.Label lblCajaAbierta;
        private System.Windows.Forms.TextBox txtStockActual;
        private System.Windows.Forms.Label lblEncargado;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Label lblAperturaFechaHora;
        private System.Windows.Forms.Label lblFondoInicial;
        private System.Windows.Forms.Label lblTiempoTranscurrido;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblSubTitulo2;
        private System.Windows.Forms.Label lblApertura;
        private System.Windows.Forms.Label lblOperaciones;
        private System.Windows.Forms.Label lblLineaDivisora2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotalCantidad;
        private System.Windows.Forms.Label lblEfectivo;
        private System.Windows.Forms.TextBox txtEfectivoCantidad;
        private System.Windows.Forms.Label lbllblYape;
        private System.Windows.Forms.TextBox txtYapeCantidad;
        private System.Windows.Forms.Label lblTransferencia;
        private System.Windows.Forms.TextBox txtTransferenciaCantidad;
        private System.Windows.Forms.Label lblCredito;
        private System.Windows.Forms.TextBox txtCreditoCantidad;
        private System.Windows.Forms.Panel pnlArqueo;
        private System.Windows.Forms.Label lblSubTitulo3;
        private System.Windows.Forms.Label lblEfectivoEsperado;
        private System.Windows.Forms.TextBox txtEfectivoEsperado;
        private System.Windows.Forms.Label lblEfectivoReal;
        private System.Windows.Forms.NumericUpDown numEfectivoReal;
        private System.Windows.Forms.Label lblSeparador;
        private System.Windows.Forms.Label lblDiferencia;
        private System.Windows.Forms.TextBox txtDiferenciaCantidad;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Panel pnlHistorial;
        private System.Windows.Forms.Label lblSubTitulo4;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbUsuarios;
        private System.Windows.Forms.DataGridView dgvHistorialCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStocktotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIngresos;
        private System.Windows.Forms.DataGridViewImageColumn colVer;
    }
}
