namespace SistemaPOS.Forms.Finanzas
{
    partial class FormDetalleCaja
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlDetalleTransacciones = new System.Windows.Forms.Panel();
            this.lblSubTituloVentasD = new System.Windows.Forms.Label();
            this.dgvVentasTurno = new System.Windows.Forms.DataGridView();
            this.colVentaHoraD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVentaNumeroD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVentaClienteD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVentaMetodoD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVentaTotalD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSubTituloGastosD = new System.Windows.Forms.Label();
            this.dgvGastosTurno = new System.Windows.Forms.DataGridView();
            this.colGastoHoraD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGastoConceptoD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGastoCategoriaD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGastoMontoD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCardObs = new System.Windows.Forms.Panel();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.pnlArqueoEfectivo = new System.Windows.Forms.Panel();
            this.lblSubtitulo3 = new System.Windows.Forms.Label();
            this.lblFondoInicial2 = new System.Windows.Forms.Label();
            this.txtFondoInicial = new System.Windows.Forms.TextBox();
            this.lblEfectivoVentas = new System.Windows.Forms.Label();
            this.txtEfectivoVentas = new System.Windows.Forms.TextBox();
            this.lblSeparador = new System.Windows.Forms.Label();
            this.lblEfectivoEsperado = new System.Windows.Forms.Label();
            this.txtEfectivoEsperado = new System.Windows.Forms.TextBox();
            this.lblSeparador1 = new System.Windows.Forms.Label();
            this.lblEfectivoReal = new System.Windows.Forms.Label();
            this.txtEfectivoReal = new System.Windows.Forms.TextBox();
            this.lblDiferencia = new System.Windows.Forms.Label();
            this.txtDiferenciaCantidad = new System.Windows.Forms.TextBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.lblSubTitulo2 = new System.Windows.Forms.Label();
            this.lblOperaciones = new System.Windows.Forms.Label();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.txtEfectivoCantidad = new System.Windows.Forms.TextBox();
            this.lbllblYape = new System.Windows.Forms.Label();
            this.txtYapeCantidad = new System.Windows.Forms.TextBox();
            this.lblTransferencia = new System.Windows.Forms.Label();
            this.txtTransferenciaCantidad = new System.Windows.Forms.TextBox();
            this.lblCredito = new System.Windows.Forms.Label();
            this.txtCreditoCantidad = new System.Windows.Forms.TextBox();
            this.lblSeparador2 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotalCantidad = new System.Windows.Forms.TextBox();
            this.pnlInfoTurno = new System.Windows.Forms.Panel();
            this.lblSubTitulo = new System.Windows.Forms.Label();
            this.lblEncargado = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.lblNumeroSerie = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblFondoinicial = new System.Windows.Forms.Label();
            this.txtFondoInicial1 = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlDetalleTransacciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasTurno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastosTurno)).BeginInit();
            this.pnlCardObs.SuspendLayout();
            this.pnlArqueoEfectivo.SuspendLayout();
            this.pnlResumen.SuspendLayout();
            this.pnlInfoTurno.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlHeader.Controls.Add(this.btnImprimir);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.btnExportar);
            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1437, 68);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(227, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Detalle de Cierre de Caja";
            // 
            // lblHeaderSub
            // 
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(190)))), ((int)(((byte)(195)))));
            this.lblHeaderSub.Location = new System.Drawing.Point(22, 42);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(184, 15);
            this.lblHeaderSub.TabIndex = 1;
            this.lblHeaderSub.Text = "Resumen e información del turno";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnCerrar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 558);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1437, 60);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(110)))), ((int)(((byte)(195)))));
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(1172, 17);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(110, 36);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = "Resumen";
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(80)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(1294, 17);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnExportar.Size = new System.Drawing.Size(130, 36);
            this.btnExportar.TabIndex = 0;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnCerrar.Location = new System.Drawing.Point(1342, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(82, 36);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlBody.Controls.Add(this.pnlDetalleTransacciones);
            this.pnlBody.Controls.Add(this.pnlCardObs);
            this.pnlBody.Controls.Add(this.pnlArqueoEfectivo);
            this.pnlBody.Controls.Add(this.pnlResumen);
            this.pnlBody.Controls.Add(this.pnlInfoTurno);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 68);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBody.Size = new System.Drawing.Size(1437, 490);
            this.pnlBody.TabIndex = 0;
            // 
            // pnlDetalleTransacciones
            // 
            this.pnlDetalleTransacciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetalleTransacciones.BackColor = System.Drawing.Color.White;
            this.pnlDetalleTransacciones.Controls.Add(this.lblSubTituloVentasD);
            this.pnlDetalleTransacciones.Controls.Add(this.dgvVentasTurno);
            this.pnlDetalleTransacciones.Controls.Add(this.lblSubTituloGastosD);
            this.pnlDetalleTransacciones.Controls.Add(this.dgvGastosTurno);
            this.pnlDetalleTransacciones.Location = new System.Drawing.Point(576, 10);
            this.pnlDetalleTransacciones.Name = "pnlDetalleTransacciones";
            this.pnlDetalleTransacciones.Padding = new System.Windows.Forms.Padding(8);
            this.pnlDetalleTransacciones.Size = new System.Drawing.Size(848, 470);
            this.pnlDetalleTransacciones.TabIndex = 0;
            // 
            // lblSubTituloVentasD
            // 
            this.lblSubTituloVentasD.AutoSize = true;
            this.lblSubTituloVentasD.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSubTituloVentasD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblSubTituloVentasD.Location = new System.Drawing.Point(8, 8);
            this.lblSubTituloVentasD.Name = "lblSubTituloVentasD";
            this.lblSubTituloVentasD.Size = new System.Drawing.Size(120, 15);
            this.lblSubTituloVentasD.TabIndex = 0;
            this.lblSubTituloVentasD.Text = "VENTAS DEL TURNO";
            // 
            // dgvVentasTurno
            // 
            this.dgvVentasTurno.AllowUserToAddRows = false;
            this.dgvVentasTurno.AllowUserToDeleteRows = false;
            this.dgvVentasTurno.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVentasTurno.BackgroundColor = System.Drawing.Color.White;
            this.dgvVentasTurno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVentasTurno.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVentasTurno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentasTurno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVentaHoraD,
            this.colVentaNumeroD,
            this.colVentaClienteD,
            this.colVentaMetodoD,
            this.colVentaTotalD});
            this.dgvVentasTurno.EnableHeadersVisualStyles = false;
            this.dgvVentasTurno.Location = new System.Drawing.Point(8, 26);
            this.dgvVentasTurno.Name = "dgvVentasTurno";
            this.dgvVentasTurno.ReadOnly = true;
            this.dgvVentasTurno.RowHeadersVisible = false;
            this.dgvVentasTurno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentasTurno.Size = new System.Drawing.Size(829, 246);
            this.dgvVentasTurno.TabIndex = 1;
            // 
            // colVentaHoraD
            // 
            this.colVentaHoraD.HeaderText = "Hora";
            this.colVentaHoraD.Name = "colVentaHoraD";
            this.colVentaHoraD.ReadOnly = true;
            this.colVentaHoraD.Width = 50;
            // 
            // colVentaNumeroD
            // 
            this.colVentaNumeroD.HeaderText = "N° Venta";
            this.colVentaNumeroD.Name = "colVentaNumeroD";
            this.colVentaNumeroD.ReadOnly = true;
            this.colVentaNumeroD.Width = 75;
            // 
            // colVentaClienteD
            // 
            this.colVentaClienteD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colVentaClienteD.HeaderText = "Cliente";
            this.colVentaClienteD.Name = "colVentaClienteD";
            this.colVentaClienteD.ReadOnly = true;
            // 
            // colVentaMetodoD
            // 
            this.colVentaMetodoD.HeaderText = "Método";
            this.colVentaMetodoD.Name = "colVentaMetodoD";
            this.colVentaMetodoD.ReadOnly = true;
            this.colVentaMetodoD.Width = 75;
            // 
            // colVentaTotalD
            // 
            this.colVentaTotalD.HeaderText = "Total";
            this.colVentaTotalD.Name = "colVentaTotalD";
            this.colVentaTotalD.ReadOnly = true;
            this.colVentaTotalD.Width = 85;
            // 
            // lblSubTituloGastosD
            // 
            this.lblSubTituloGastosD.AutoSize = true;
            this.lblSubTituloGastosD.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSubTituloGastosD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblSubTituloGastosD.Location = new System.Drawing.Point(8, 282);
            this.lblSubTituloGastosD.Name = "lblSubTituloGastosD";
            this.lblSubTituloGastosD.Size = new System.Drawing.Size(123, 15);
            this.lblSubTituloGastosD.TabIndex = 2;
            this.lblSubTituloGastosD.Text = "GASTOS DEL TURNO";
            // 
            // dgvGastosTurno
            // 
            this.dgvGastosTurno.AllowUserToAddRows = false;
            this.dgvGastosTurno.AllowUserToDeleteRows = false;
            this.dgvGastosTurno.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGastosTurno.BackgroundColor = System.Drawing.Color.White;
            this.dgvGastosTurno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGastosTurno.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGastosTurno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGastosTurno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGastoHoraD,
            this.colGastoConceptoD,
            this.colGastoCategoriaD,
            this.colGastoMontoD});
            this.dgvGastosTurno.EnableHeadersVisualStyles = false;
            this.dgvGastosTurno.Location = new System.Drawing.Point(8, 300);
            this.dgvGastosTurno.Name = "dgvGastosTurno";
            this.dgvGastosTurno.ReadOnly = true;
            this.dgvGastosTurno.RowHeadersVisible = false;
            this.dgvGastosTurno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGastosTurno.Size = new System.Drawing.Size(829, 159);
            this.dgvGastosTurno.TabIndex = 3;
            // 
            // colGastoHoraD
            // 
            this.colGastoHoraD.HeaderText = "Hora";
            this.colGastoHoraD.Name = "colGastoHoraD";
            this.colGastoHoraD.ReadOnly = true;
            this.colGastoHoraD.Width = 50;
            // 
            // colGastoConceptoD
            // 
            this.colGastoConceptoD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGastoConceptoD.HeaderText = "Concepto";
            this.colGastoConceptoD.Name = "colGastoConceptoD";
            this.colGastoConceptoD.ReadOnly = true;
            // 
            // colGastoCategoriaD
            // 
            this.colGastoCategoriaD.HeaderText = "Categoría";
            this.colGastoCategoriaD.Name = "colGastoCategoriaD";
            this.colGastoCategoriaD.ReadOnly = true;
            // 
            // colGastoMontoD
            // 
            this.colGastoMontoD.HeaderText = "Monto";
            this.colGastoMontoD.Name = "colGastoMontoD";
            this.colGastoMontoD.ReadOnly = true;
            this.colGastoMontoD.Width = 85;
            // 
            // pnlCardObs
            // 
            this.pnlCardObs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCardObs.BackColor = System.Drawing.Color.White;
            this.pnlCardObs.Controls.Add(this.lblObservaciones);
            this.pnlCardObs.Controls.Add(this.txtObservaciones);
            this.pnlCardObs.Location = new System.Drawing.Point(10, 385);
            this.pnlCardObs.Name = "pnlCardObs";
            this.pnlCardObs.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlCardObs.Size = new System.Drawing.Size(560, 95);
            this.pnlCardObs.TabIndex = 1;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblObservaciones.Location = new System.Drawing.Point(15, 10);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(140, 15);
            this.lblObservaciones.TabIndex = 0;
            this.lblObservaciones.Text = "Observaciones del Cierre:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtObservaciones.Location = new System.Drawing.Point(15, 28);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(530, 52);
            this.txtObservaciones.TabIndex = 1;
            // 
            // pnlArqueoEfectivo
            // 
            this.pnlArqueoEfectivo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlArqueoEfectivo.BackColor = System.Drawing.Color.White;
            this.pnlArqueoEfectivo.Controls.Add(this.lblSubtitulo3);
            this.pnlArqueoEfectivo.Controls.Add(this.lblFondoInicial2);
            this.pnlArqueoEfectivo.Controls.Add(this.txtFondoInicial);
            this.pnlArqueoEfectivo.Controls.Add(this.lblEfectivoVentas);
            this.pnlArqueoEfectivo.Controls.Add(this.txtEfectivoVentas);
            this.pnlArqueoEfectivo.Controls.Add(this.lblSeparador);
            this.pnlArqueoEfectivo.Controls.Add(this.lblEfectivoEsperado);
            this.pnlArqueoEfectivo.Controls.Add(this.txtEfectivoEsperado);
            this.pnlArqueoEfectivo.Controls.Add(this.lblSeparador1);
            this.pnlArqueoEfectivo.Controls.Add(this.lblEfectivoReal);
            this.pnlArqueoEfectivo.Controls.Add(this.txtEfectivoReal);
            this.pnlArqueoEfectivo.Controls.Add(this.lblDiferencia);
            this.pnlArqueoEfectivo.Controls.Add(this.txtDiferenciaCantidad);
            this.pnlArqueoEfectivo.Controls.Add(this.lblMotivo);
            this.pnlArqueoEfectivo.Controls.Add(this.txtMotivo);
            this.pnlArqueoEfectivo.Location = new System.Drawing.Point(292, 160);
            this.pnlArqueoEfectivo.Name = "pnlArqueoEfectivo";
            this.pnlArqueoEfectivo.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlArqueoEfectivo.Size = new System.Drawing.Size(278, 215);
            this.pnlArqueoEfectivo.TabIndex = 2;
            // 
            // lblSubtitulo3
            // 
            this.lblSubtitulo3.AutoSize = true;
            this.lblSubtitulo3.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSubtitulo3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblSubtitulo3.Location = new System.Drawing.Point(15, 10);
            this.lblSubtitulo3.Name = "lblSubtitulo3";
            this.lblSubtitulo3.Size = new System.Drawing.Size(130, 15);
            this.lblSubtitulo3.TabIndex = 0;
            this.lblSubtitulo3.Text = "ARQUEO DE EFECTIVO";
            // 
            // lblFondoInicial2
            // 
            this.lblFondoInicial2.AutoSize = true;
            this.lblFondoInicial2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFondoInicial2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblFondoInicial2.Location = new System.Drawing.Point(15, 33);
            this.lblFondoInicial2.Name = "lblFondoInicial2";
            this.lblFondoInicial2.Size = new System.Drawing.Size(78, 15);
            this.lblFondoInicial2.TabIndex = 1;
            this.lblFondoInicial2.Text = "Fondo Inicial:";
            // 
            // txtFondoInicial
            // 
            this.txtFondoInicial.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtFondoInicial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFondoInicial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtFondoInicial.Location = new System.Drawing.Point(150, 32);
            this.txtFondoInicial.Multiline = true;
            this.txtFondoInicial.Name = "txtFondoInicial";
            this.txtFondoInicial.ReadOnly = true;
            this.txtFondoInicial.Size = new System.Drawing.Size(100, 18);
            this.txtFondoInicial.TabIndex = 2;
            this.txtFondoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblEfectivoVentas
            // 
            this.lblEfectivoVentas.AutoSize = true;
            this.lblEfectivoVentas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEfectivoVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblEfectivoVentas.Location = new System.Drawing.Point(15, 57);
            this.lblEfectivoVentas.Name = "lblEfectivoVentas";
            this.lblEfectivoVentas.Size = new System.Drawing.Size(108, 15);
            this.lblEfectivoVentas.TabIndex = 3;
            this.lblEfectivoVentas.Text = "(+) Efectivo Ventas:";
            // 
            // txtEfectivoVentas
            // 
            this.txtEfectivoVentas.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtEfectivoVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEfectivoVentas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtEfectivoVentas.Location = new System.Drawing.Point(150, 56);
            this.txtEfectivoVentas.Multiline = true;
            this.txtEfectivoVentas.Name = "txtEfectivoVentas";
            this.txtEfectivoVentas.ReadOnly = true;
            this.txtEfectivoVentas.Size = new System.Drawing.Size(100, 18);
            this.txtEfectivoVentas.TabIndex = 4;
            this.txtEfectivoVentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSeparador
            // 
            this.lblSeparador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.lblSeparador.Location = new System.Drawing.Point(15, 80);
            this.lblSeparador.Name = "lblSeparador";
            this.lblSeparador.Size = new System.Drawing.Size(240, 1);
            this.lblSeparador.TabIndex = 5;
            // 
            // lblEfectivoEsperado
            // 
            this.lblEfectivoEsperado.AutoSize = true;
            this.lblEfectivoEsperado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEfectivoEsperado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblEfectivoEsperado.Location = new System.Drawing.Point(15, 89);
            this.lblEfectivoEsperado.Name = "lblEfectivoEsperado";
            this.lblEfectivoEsperado.Size = new System.Drawing.Size(103, 15);
            this.lblEfectivoEsperado.TabIndex = 6;
            this.lblEfectivoEsperado.Text = "Efectivo Esperado:";
            // 
            // txtEfectivoEsperado
            // 
            this.txtEfectivoEsperado.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtEfectivoEsperado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEfectivoEsperado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtEfectivoEsperado.Location = new System.Drawing.Point(150, 88);
            this.txtEfectivoEsperado.Multiline = true;
            this.txtEfectivoEsperado.Name = "txtEfectivoEsperado";
            this.txtEfectivoEsperado.ReadOnly = true;
            this.txtEfectivoEsperado.Size = new System.Drawing.Size(100, 18);
            this.txtEfectivoEsperado.TabIndex = 7;
            this.txtEfectivoEsperado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSeparador1
            // 
            this.lblSeparador1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.lblSeparador1.Location = new System.Drawing.Point(15, 112);
            this.lblSeparador1.Name = "lblSeparador1";
            this.lblSeparador1.Size = new System.Drawing.Size(240, 1);
            this.lblSeparador1.TabIndex = 8;
            // 
            // lblEfectivoReal
            // 
            this.lblEfectivoReal.AutoSize = true;
            this.lblEfectivoReal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEfectivoReal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblEfectivoReal.Location = new System.Drawing.Point(15, 120);
            this.lblEfectivoReal.Name = "lblEfectivoReal";
            this.lblEfectivoReal.Size = new System.Drawing.Size(77, 15);
            this.lblEfectivoReal.TabIndex = 9;
            this.lblEfectivoReal.Text = "Efectivo Real:";
            // 
            // txtEfectivoReal
            // 
            this.txtEfectivoReal.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtEfectivoReal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEfectivoReal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtEfectivoReal.Location = new System.Drawing.Point(150, 119);
            this.txtEfectivoReal.Multiline = true;
            this.txtEfectivoReal.Name = "txtEfectivoReal";
            this.txtEfectivoReal.ReadOnly = true;
            this.txtEfectivoReal.Size = new System.Drawing.Size(100, 18);
            this.txtEfectivoReal.TabIndex = 10;
            this.txtEfectivoReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.AutoSize = true;
            this.lblDiferencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiferencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblDiferencia.Location = new System.Drawing.Point(15, 144);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(63, 15);
            this.lblDiferencia.TabIndex = 11;
            this.lblDiferencia.Text = "Diferencia:";
            // 
            // txtDiferenciaCantidad
            // 
            this.txtDiferenciaCantidad.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtDiferenciaCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiferenciaCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtDiferenciaCantidad.Location = new System.Drawing.Point(150, 143);
            this.txtDiferenciaCantidad.Multiline = true;
            this.txtDiferenciaCantidad.Name = "txtDiferenciaCantidad";
            this.txtDiferenciaCantidad.ReadOnly = true;
            this.txtDiferenciaCantidad.Size = new System.Drawing.Size(100, 18);
            this.txtDiferenciaCantidad.TabIndex = 12;
            this.txtDiferenciaCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMotivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblMotivo.Location = new System.Drawing.Point(15, 168);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(48, 15);
            this.lblMotivo.TabIndex = 13;
            this.lblMotivo.Text = "Motivo:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotivo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.txtMotivo.Location = new System.Drawing.Point(69, 165);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(186, 35);
            this.txtMotivo.TabIndex = 14;
            // 
            // pnlResumen
            // 
            this.pnlResumen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlResumen.BackColor = System.Drawing.Color.White;
            this.pnlResumen.Controls.Add(this.lblSubTitulo2);
            this.pnlResumen.Controls.Add(this.lblOperaciones);
            this.pnlResumen.Controls.Add(this.lblEfectivo);
            this.pnlResumen.Controls.Add(this.txtEfectivoCantidad);
            this.pnlResumen.Controls.Add(this.lbllblYape);
            this.pnlResumen.Controls.Add(this.txtYapeCantidad);
            this.pnlResumen.Controls.Add(this.lblTransferencia);
            this.pnlResumen.Controls.Add(this.txtTransferenciaCantidad);
            this.pnlResumen.Controls.Add(this.lblCredito);
            this.pnlResumen.Controls.Add(this.txtCreditoCantidad);
            this.pnlResumen.Controls.Add(this.lblSeparador2);
            this.pnlResumen.Controls.Add(this.lblTotal);
            this.pnlResumen.Controls.Add(this.txtTotalCantidad);
            this.pnlResumen.Location = new System.Drawing.Point(10, 160);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlResumen.Size = new System.Drawing.Size(272, 215);
            this.pnlResumen.TabIndex = 3;
            // 
            // lblSubTitulo2
            // 
            this.lblSubTitulo2.AutoSize = true;
            this.lblSubTitulo2.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSubTitulo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblSubTitulo2.Location = new System.Drawing.Point(15, 10);
            this.lblSubTitulo2.Name = "lblSubTitulo2";
            this.lblSubTitulo2.Size = new System.Drawing.Size(143, 15);
            this.lblSubTitulo2.TabIndex = 0;
            this.lblSubTitulo2.Text = "RESUMEN DE INGRESOS";
            // 
            // lblOperaciones
            // 
            this.lblOperaciones.AutoSize = true;
            this.lblOperaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOperaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblOperaciones.Location = new System.Drawing.Point(15, 30);
            this.lblOperaciones.Name = "lblOperaciones";
            this.lblOperaciones.Size = new System.Drawing.Size(85, 15);
            this.lblOperaciones.TabIndex = 1;
            this.lblOperaciones.Text = "Operaciones: 0";
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEfectivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblEfectivo.Location = new System.Drawing.Point(15, 55);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(52, 15);
            this.lblEfectivo.TabIndex = 2;
            this.lblEfectivo.Text = "Efectivo:";
            // 
            // txtEfectivoCantidad
            // 
            this.txtEfectivoCantidad.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtEfectivoCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEfectivoCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtEfectivoCantidad.Location = new System.Drawing.Point(145, 54);
            this.txtEfectivoCantidad.Multiline = true;
            this.txtEfectivoCantidad.Name = "txtEfectivoCantidad";
            this.txtEfectivoCantidad.ReadOnly = true;
            this.txtEfectivoCantidad.Size = new System.Drawing.Size(100, 18);
            this.txtEfectivoCantidad.TabIndex = 3;
            this.txtEfectivoCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbllblYape
            // 
            this.lbllblYape.AutoSize = true;
            this.lbllblYape.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbllblYape.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lbllblYape.Location = new System.Drawing.Point(15, 80);
            this.lbllblYape.Name = "lbllblYape";
            this.lbllblYape.Size = new System.Drawing.Size(35, 15);
            this.lbllblYape.TabIndex = 4;
            this.lbllblYape.Text = "Yape:";
            // 
            // txtYapeCantidad
            // 
            this.txtYapeCantidad.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtYapeCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtYapeCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtYapeCantidad.Location = new System.Drawing.Point(145, 79);
            this.txtYapeCantidad.Multiline = true;
            this.txtYapeCantidad.Name = "txtYapeCantidad";
            this.txtYapeCantidad.ReadOnly = true;
            this.txtYapeCantidad.Size = new System.Drawing.Size(100, 18);
            this.txtYapeCantidad.TabIndex = 5;
            this.txtYapeCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTransferencia
            // 
            this.lblTransferencia.AutoSize = true;
            this.lblTransferencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTransferencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblTransferencia.Location = new System.Drawing.Point(15, 105);
            this.lblTransferencia.Name = "lblTransferencia";
            this.lblTransferencia.Size = new System.Drawing.Size(79, 15);
            this.lblTransferencia.TabIndex = 6;
            this.lblTransferencia.Text = "Transferencia:";
            // 
            // txtTransferenciaCantidad
            // 
            this.txtTransferenciaCantidad.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtTransferenciaCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTransferenciaCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtTransferenciaCantidad.Location = new System.Drawing.Point(145, 104);
            this.txtTransferenciaCantidad.Multiline = true;
            this.txtTransferenciaCantidad.Name = "txtTransferenciaCantidad";
            this.txtTransferenciaCantidad.ReadOnly = true;
            this.txtTransferenciaCantidad.Size = new System.Drawing.Size(100, 18);
            this.txtTransferenciaCantidad.TabIndex = 7;
            this.txtTransferenciaCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCredito
            // 
            this.lblCredito.AutoSize = true;
            this.lblCredito.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCredito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblCredito.Location = new System.Drawing.Point(15, 130);
            this.lblCredito.Name = "lblCredito";
            this.lblCredito.Size = new System.Drawing.Size(60, 15);
            this.lblCredito.TabIndex = 8;
            this.lblCredito.Text = "A Crédito:";
            // 
            // txtCreditoCantidad
            // 
            this.txtCreditoCantidad.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtCreditoCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCreditoCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtCreditoCantidad.Location = new System.Drawing.Point(145, 129);
            this.txtCreditoCantidad.Multiline = true;
            this.txtCreditoCantidad.Name = "txtCreditoCantidad";
            this.txtCreditoCantidad.ReadOnly = true;
            this.txtCreditoCantidad.Size = new System.Drawing.Size(100, 18);
            this.txtCreditoCantidad.TabIndex = 9;
            this.txtCreditoCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSeparador2
            // 
            this.lblSeparador2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.lblSeparador2.Location = new System.Drawing.Point(15, 155);
            this.lblSeparador2.Name = "lblSeparador2";
            this.lblSeparador2.Size = new System.Drawing.Size(235, 1);
            this.lblSeparador2.TabIndex = 10;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblTotal.Location = new System.Drawing.Point(15, 163);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(58, 20);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "TOTAL:";
            // 
            // txtTotalCantidad
            // 
            this.txtTotalCantidad.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtTotalCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalCantidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtTotalCantidad.Location = new System.Drawing.Point(120, 162);
            this.txtTotalCantidad.Multiline = true;
            this.txtTotalCantidad.Name = "txtTotalCantidad";
            this.txtTotalCantidad.ReadOnly = true;
            this.txtTotalCantidad.Size = new System.Drawing.Size(130, 22);
            this.txtTotalCantidad.TabIndex = 12;
            this.txtTotalCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlInfoTurno
            // 
            this.pnlInfoTurno.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInfoTurno.BackColor = System.Drawing.Color.White;
            this.pnlInfoTurno.Controls.Add(this.lblSubTitulo);
            this.pnlInfoTurno.Controls.Add(this.lblEncargado);
            this.pnlInfoTurno.Controls.Add(this.lblFecha);
            this.pnlInfoTurno.Controls.Add(this.lblHora);
            this.pnlInfoTurno.Controls.Add(this.lblTipoComprobante);
            this.pnlInfoTurno.Controls.Add(this.lblNumeroSerie);
            this.pnlInfoTurno.Controls.Add(this.lblEstado);
            this.pnlInfoTurno.Controls.Add(this.lblFondoinicial);
            this.pnlInfoTurno.Controls.Add(this.txtFondoInicial1);
            this.pnlInfoTurno.Location = new System.Drawing.Point(10, 10);
            this.pnlInfoTurno.Name = "pnlInfoTurno";
            this.pnlInfoTurno.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlInfoTurno.Size = new System.Drawing.Size(560, 140);
            this.pnlInfoTurno.TabIndex = 4;
            // 
            // lblSubTitulo
            // 
            this.lblSubTitulo.AutoSize = true;
            this.lblSubTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblSubTitulo.Location = new System.Drawing.Point(15, 10);
            this.lblSubTitulo.Name = "lblSubTitulo";
            this.lblSubTitulo.Size = new System.Drawing.Size(160, 15);
            this.lblSubTitulo.TabIndex = 0;
            this.lblSubTitulo.Text = "INFORMACIÓN DEL TURNO";
            // 
            // lblEncargado
            // 
            this.lblEncargado.AutoSize = true;
            this.lblEncargado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEncargado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblEncargado.Location = new System.Drawing.Point(15, 30);
            this.lblEncargado.Name = "lblEncargado";
            this.lblEncargado.Size = new System.Drawing.Size(93, 17);
            this.lblEncargado.TabIndex = 1;
            this.lblEncargado.Text = "Encargado: —";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblFecha.Location = new System.Drawing.Point(15, 54);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(56, 15);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha: —";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblHora.Location = new System.Drawing.Point(15, 75);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(100, 15);
            this.lblHora.TabIndex = 3;
            this.lblHora.Text = "Hora Apertura: —";
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipoComprobante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblTipoComprobante.Location = new System.Drawing.Point(300, 30);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(56, 15);
            this.lblTipoComprobante.TabIndex = 4;
            this.lblTipoComprobante.Text = "Turno: —";
            // 
            // lblNumeroSerie
            // 
            this.lblNumeroSerie.AutoSize = true;
            this.lblNumeroSerie.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNumeroSerie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblNumeroSerie.Location = new System.Drawing.Point(300, 54);
            this.lblNumeroSerie.Name = "lblNumeroSerie";
            this.lblNumeroSerie.Size = new System.Drawing.Size(73, 15);
            this.lblNumeroSerie.TabIndex = 5;
            this.lblNumeroSerie.Text = "Duración: —";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblEstado.Location = new System.Drawing.Point(300, 75);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(85, 15);
            this.lblEstado.TabIndex = 6;
            this.lblEstado.Text = "Hora Cierre: —";
            // 
            // lblFondoinicial
            // 
            this.lblFondoinicial.AutoSize = true;
            this.lblFondoinicial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFondoinicial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblFondoinicial.Location = new System.Drawing.Point(15, 107);
            this.lblFondoinicial.Name = "lblFondoinicial";
            this.lblFondoinicial.Size = new System.Drawing.Size(92, 17);
            this.lblFondoinicial.TabIndex = 7;
            this.lblFondoinicial.Text = "Fondo Inicial:";
            // 
            // txtFondoInicial1
            // 
            this.txtFondoInicial1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtFondoInicial1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFondoInicial1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFondoInicial1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.txtFondoInicial1.Location = new System.Drawing.Point(120, 108);
            this.txtFondoInicial1.Multiline = true;
            this.txtFondoInicial1.Name = "txtFondoInicial1";
            this.txtFondoInicial1.ReadOnly = true;
            this.txtFondoInicial1.Size = new System.Drawing.Size(120, 20);
            this.txtFondoInicial1.TabIndex = 8;
            // 
            // FormDetalleCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1437, 618);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDetalleCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de Cierre de Caja";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlDetalleTransacciones.ResumeLayout(false);
            this.pnlDetalleTransacciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasTurno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastosTurno)).EndInit();
            this.pnlCardObs.ResumeLayout(false);
            this.pnlCardObs.PerformLayout();
            this.pnlArqueoEfectivo.ResumeLayout(false);
            this.pnlArqueoEfectivo.PerformLayout();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.pnlInfoTurno.ResumeLayout(false);
            this.pnlInfoTurno.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlInfoTurno;
        private System.Windows.Forms.Label lblSubTitulo;
        private System.Windows.Forms.Label lblEncargado;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblTipoComprobante;
        private System.Windows.Forms.Label lblNumeroSerie;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblFondoinicial;
        private System.Windows.Forms.TextBox txtFondoInicial1;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblSubTitulo2;
        private System.Windows.Forms.Label lblOperaciones;
        private System.Windows.Forms.Label lblEfectivo;
        private System.Windows.Forms.TextBox txtEfectivoCantidad;
        private System.Windows.Forms.Label lbllblYape;
        private System.Windows.Forms.TextBox txtYapeCantidad;
        private System.Windows.Forms.Label lblTransferencia;
        private System.Windows.Forms.TextBox txtTransferenciaCantidad;
        private System.Windows.Forms.Label lblCredito;
        private System.Windows.Forms.TextBox txtCreditoCantidad;
        private System.Windows.Forms.Label lblSeparador2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotalCantidad;
        private System.Windows.Forms.Panel pnlArqueoEfectivo;
        private System.Windows.Forms.Label lblSubtitulo3;
        private System.Windows.Forms.Label lblFondoInicial2;
        private System.Windows.Forms.TextBox txtFondoInicial;
        private System.Windows.Forms.Label lblEfectivoVentas;
        private System.Windows.Forms.TextBox txtEfectivoVentas;
        private System.Windows.Forms.Label lblSeparador;
        private System.Windows.Forms.Label lblEfectivoEsperado;
        private System.Windows.Forms.TextBox txtEfectivoEsperado;
        private System.Windows.Forms.Label lblSeparador1;
        private System.Windows.Forms.Label lblEfectivoReal;
        private System.Windows.Forms.TextBox txtEfectivoReal;
        private System.Windows.Forms.Label lblDiferencia;
        private System.Windows.Forms.TextBox txtDiferenciaCantidad;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Panel pnlCardObs;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Panel pnlDetalleTransacciones;
        private System.Windows.Forms.Label lblSubTituloVentasD;
        private System.Windows.Forms.DataGridView dgvVentasTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaHoraD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaNumeroD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaClienteD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaMetodoD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaTotalD;
        private System.Windows.Forms.Label lblSubTituloGastosD;
        private System.Windows.Forms.DataGridView dgvGastosTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGastoHoraD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGastoConceptoD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGastoCategoriaD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGastoMontoD;
    }
}
