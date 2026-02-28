namespace SistemaPOS.Forms.Finanzas
{
    partial class FormRegistrarPagoProveedor
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlCardObs = new System.Windows.Forms.Panel();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.pnlCardPago = new System.Windows.Forms.Panel();
            this.lblCardPagoTitulo = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.numMonto = new System.Windows.Forms.NumericUpDown();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.txtComprobante = new System.Windows.Forms.TextBox();
            this.pnlCardFecha = new System.Windows.Forms.Panel();
            this.lblCardFechaTitulo = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblHora = new System.Windows.Forms.Label();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.pnlCardInfo = new System.Windows.Forms.Panel();
            this.lblCardInfoTitulo = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.lblProveedorValor = new System.Windows.Forms.Label();
            this.lblNumeroCompra = new System.Windows.Forms.Label();
            this.lblNumeroCompraValor = new System.Windows.Forms.Label();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.lblMontoTotalValor = new System.Windows.Forms.Label();
            this.lblMontoPagado = new System.Windows.Forms.Label();
            this.lblMontoPagadoValor = new System.Windows.Forms.Label();
            this.lblMontoPendiente = new System.Windows.Forms.Label();
            this.lblMontoPendienteValor = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlCardObs.SuspendLayout();
            this.pnlCardPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).BeginInit();
            this.pnlCardFecha.SuspendLayout();
            this.pnlCardInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.pnlHeader.Size = new System.Drawing.Size(600, 68);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(262, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registrar Pago al Proveedor";
            // 
            // lblHeaderSub
            // 
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(190)))), ((int)(((byte)(195)))));
            this.lblHeaderSub.Location = new System.Drawing.Point(22, 42);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(158, 15);
            this.lblHeaderSub.TabIndex = 1;
            this.lblHeaderSub.Text = "Complete los datos del pago";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnGuardar);
            this.pnlFooter.Controls.Add(this.btnCancelar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 538);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(10);
            this.pnlFooter.Size = new System.Drawing.Size(600, 60);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(80)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(165, 13);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 36);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnCancelar.Location = new System.Drawing.Point(339, 13);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 36);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.AutoScroll = true;
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlBody.Controls.Add(this.pnlCardObs);
            this.pnlBody.Controls.Add(this.pnlCardPago);
            this.pnlBody.Controls.Add(this.pnlCardFecha);
            this.pnlBody.Controls.Add(this.pnlCardInfo);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 68);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(12);
            this.pnlBody.Size = new System.Drawing.Size(600, 470);
            this.pnlBody.TabIndex = 0;
            // 
            // pnlCardObs
            // 
            this.pnlCardObs.BackColor = System.Drawing.Color.White;
            this.pnlCardObs.Controls.Add(this.lblObservaciones);
            this.pnlCardObs.Controls.Add(this.txtObservaciones);
            this.pnlCardObs.Location = new System.Drawing.Point(12, 356);
            this.pnlCardObs.Name = "pnlCardObs";
            this.pnlCardObs.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlCardObs.Size = new System.Drawing.Size(576, 104);
            this.pnlCardObs.TabIndex = 0;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblObservaciones.Location = new System.Drawing.Point(15, 10);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(146, 15);
            this.lblObservaciones.TabIndex = 0;
            this.lblObservaciones.Text = "Observaciones (Opcional):";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtObservaciones.Location = new System.Drawing.Point(15, 28);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(545, 60);
            this.txtObservaciones.TabIndex = 5;
            // 
            // pnlCardPago
            // 
            this.pnlCardPago.BackColor = System.Drawing.Color.White;
            this.pnlCardPago.Controls.Add(this.lblCardPagoTitulo);
            this.pnlCardPago.Controls.Add(this.lblMonto);
            this.pnlCardPago.Controls.Add(this.numMonto);
            this.pnlCardPago.Controls.Add(this.lblMetodoPago);
            this.pnlCardPago.Controls.Add(this.cmbMetodoPago);
            this.pnlCardPago.Controls.Add(this.lblComprobante);
            this.pnlCardPago.Controls.Add(this.txtComprobante);
            this.pnlCardPago.Location = new System.Drawing.Point(12, 238);
            this.pnlCardPago.Name = "pnlCardPago";
            this.pnlCardPago.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlCardPago.Size = new System.Drawing.Size(576, 108);
            this.pnlCardPago.TabIndex = 1;
            // 
            // lblCardPagoTitulo
            // 
            this.lblCardPagoTitulo.AutoSize = true;
            this.lblCardPagoTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCardPagoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblCardPagoTitulo.Location = new System.Drawing.Point(15, 10);
            this.lblCardPagoTitulo.Name = "lblCardPagoTitulo";
            this.lblCardPagoTitulo.Size = new System.Drawing.Size(113, 15);
            this.lblCardPagoTitulo.TabIndex = 0;
            this.lblCardPagoTitulo.Text = "DETALLE DEL PAGO";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblMonto.Location = new System.Drawing.Point(15, 35);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(96, 15);
            this.lblMonto.TabIndex = 1;
            this.lblMonto.Text = "Monto a Pagar: *";
            // 
            // numMonto
            // 
            this.numMonto.DecimalPlaces = 2;
            this.numMonto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numMonto.Location = new System.Drawing.Point(15, 55);
            this.numMonto.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numMonto.Name = "numMonto";
            this.numMonto.Size = new System.Drawing.Size(160, 23);
            this.numMonto.TabIndex = 2;
            this.numMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMetodoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblMetodoPago.Location = new System.Drawing.Point(195, 35);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(106, 15);
            this.lblMetodoPago.TabIndex = 3;
            this.lblMetodoPago.Text = "Método de Pago: *";
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Items.AddRange(new object[] {
            "EFECTIVO",
            "YAPE",
            "TRANSFERENCIA",
            "TARJETA"});
            this.cmbMetodoPago.Location = new System.Drawing.Point(195, 55);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(170, 23);
            this.cmbMetodoPago.TabIndex = 3;
            // 
            // lblComprobante
            // 
            this.lblComprobante.AutoSize = true;
            this.lblComprobante.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblComprobante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblComprobante.Location = new System.Drawing.Point(385, 35);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(143, 15);
            this.lblComprobante.TabIndex = 4;
            this.lblComprobante.Text = "Comprobante (Opcional):";
            // 
            // txtComprobante
            // 
            this.txtComprobante.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtComprobante.Location = new System.Drawing.Point(385, 55);
            this.txtComprobante.Name = "txtComprobante";
            this.txtComprobante.Size = new System.Drawing.Size(175, 23);
            this.txtComprobante.TabIndex = 4;
            // 
            // pnlCardFecha
            // 
            this.pnlCardFecha.BackColor = System.Drawing.Color.White;
            this.pnlCardFecha.Controls.Add(this.lblCardFechaTitulo);
            this.pnlCardFecha.Controls.Add(this.lblFecha);
            this.pnlCardFecha.Controls.Add(this.dtpFecha);
            this.pnlCardFecha.Controls.Add(this.lblHora);
            this.pnlCardFecha.Controls.Add(this.dtpHora);
            this.pnlCardFecha.Location = new System.Drawing.Point(12, 140);
            this.pnlCardFecha.Name = "pnlCardFecha";
            this.pnlCardFecha.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlCardFecha.Size = new System.Drawing.Size(576, 88);
            this.pnlCardFecha.TabIndex = 2;
            // 
            // lblCardFechaTitulo
            // 
            this.lblCardFechaTitulo.AutoSize = true;
            this.lblCardFechaTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCardFechaTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblCardFechaTitulo.Location = new System.Drawing.Point(15, 10);
            this.lblCardFechaTitulo.Name = "lblCardFechaTitulo";
            this.lblCardFechaTitulo.Size = new System.Drawing.Size(90, 15);
            this.lblCardFechaTitulo.TabIndex = 0;
            this.lblCardFechaTitulo.Text = "FECHA Y HORA";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblFecha.Location = new System.Drawing.Point(15, 35);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(49, 15);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha: *";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(15, 55);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(250, 23);
            this.dtpFecha.TabIndex = 0;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblHora.Location = new System.Drawing.Point(290, 35);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(44, 15);
            this.lblHora.TabIndex = 2;
            this.lblHora.Text = "Hora: *";
            // 
            // dtpHora
            // 
            this.dtpHora.CustomFormat = "HH:mm";
            this.dtpHora.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHora.Location = new System.Drawing.Point(290, 55);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(250, 23);
            this.dtpHora.TabIndex = 1;
            // 
            // pnlCardInfo
            // 
            this.pnlCardInfo.BackColor = System.Drawing.Color.White;
            this.pnlCardInfo.Controls.Add(this.lblCardInfoTitulo);
            this.pnlCardInfo.Controls.Add(this.lblProveedor);
            this.pnlCardInfo.Controls.Add(this.lblProveedorValor);
            this.pnlCardInfo.Controls.Add(this.lblNumeroCompra);
            this.pnlCardInfo.Controls.Add(this.lblNumeroCompraValor);
            this.pnlCardInfo.Controls.Add(this.lblMontoTotal);
            this.pnlCardInfo.Controls.Add(this.lblMontoTotalValor);
            this.pnlCardInfo.Controls.Add(this.lblMontoPagado);
            this.pnlCardInfo.Controls.Add(this.lblMontoPagadoValor);
            this.pnlCardInfo.Controls.Add(this.lblMontoPendiente);
            this.pnlCardInfo.Controls.Add(this.lblMontoPendienteValor);
            this.pnlCardInfo.Location = new System.Drawing.Point(12, 12);
            this.pnlCardInfo.Name = "pnlCardInfo";
            this.pnlCardInfo.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlCardInfo.Size = new System.Drawing.Size(576, 118);
            this.pnlCardInfo.TabIndex = 3;
            // 
            // lblCardInfoTitulo
            // 
            this.lblCardInfoTitulo.AutoSize = true;
            this.lblCardInfoTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCardInfoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblCardInfoTitulo.Location = new System.Drawing.Point(15, 10);
            this.lblCardInfoTitulo.Name = "lblCardInfoTitulo";
            this.lblCardInfoTitulo.Size = new System.Drawing.Size(179, 15);
            this.lblCardInfoTitulo.TabIndex = 0;
            this.lblCardInfoTitulo.Text = "INFORMACIÓN DE LA COMPRA";
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblProveedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblProveedor.Location = new System.Drawing.Point(15, 34);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(64, 15);
            this.lblProveedor.TabIndex = 1;
            this.lblProveedor.Text = "Proveedor:";
            // 
            // lblProveedorValor
            // 
            this.lblProveedorValor.AutoSize = true;
            this.lblProveedorValor.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblProveedorValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblProveedorValor.Location = new System.Drawing.Point(95, 32);
            this.lblProveedorValor.Name = "lblProveedorValor";
            this.lblProveedorValor.Size = new System.Drawing.Size(150, 19);
            this.lblProveedorValor.TabIndex = 2;
            this.lblProveedorValor.Text = "Nombre del Proveedor";
            // 
            // lblNumeroCompra
            // 
            this.lblNumeroCompra.AutoSize = true;
            this.lblNumeroCompra.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNumeroCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblNumeroCompra.Location = new System.Drawing.Point(15, 60);
            this.lblNumeroCompra.Name = "lblNumeroCompra";
            this.lblNumeroCompra.Size = new System.Drawing.Size(70, 15);
            this.lblNumeroCompra.TabIndex = 3;
            this.lblNumeroCompra.Text = "N° Compra:";
            // 
            // lblNumeroCompraValor
            // 
            this.lblNumeroCompraValor.AutoSize = true;
            this.lblNumeroCompraValor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNumeroCompraValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblNumeroCompraValor.Location = new System.Drawing.Point(95, 60);
            this.lblNumeroCompraValor.Name = "lblNumeroCompraValor";
            this.lblNumeroCompraValor.Size = new System.Drawing.Size(47, 15);
            this.lblNumeroCompraValor.TabIndex = 4;
            this.lblNumeroCompraValor.Text = "C-0001";
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMontoTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblMontoTotal.Location = new System.Drawing.Point(200, 60);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(35, 15);
            this.lblMontoTotal.TabIndex = 5;
            this.lblMontoTotal.Text = "Total:";
            // 
            // lblMontoTotalValor
            // 
            this.lblMontoTotalValor.AutoSize = true;
            this.lblMontoTotalValor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMontoTotalValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblMontoTotalValor.Location = new System.Drawing.Point(240, 60);
            this.lblMontoTotalValor.Name = "lblMontoTotalValor";
            this.lblMontoTotalValor.Size = new System.Drawing.Size(46, 15);
            this.lblMontoTotalValor.TabIndex = 6;
            this.lblMontoTotalValor.Text = "S/ 0.00";
            // 
            // lblMontoPagado
            // 
            this.lblMontoPagado.AutoSize = true;
            this.lblMontoPagado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMontoPagado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblMontoPagado.Location = new System.Drawing.Point(15, 85);
            this.lblMontoPagado.Name = "lblMontoPagado";
            this.lblMontoPagado.Size = new System.Drawing.Size(50, 15);
            this.lblMontoPagado.TabIndex = 7;
            this.lblMontoPagado.Text = "Pagado:";
            // 
            // lblMontoPagadoValor
            // 
            this.lblMontoPagadoValor.AutoSize = true;
            this.lblMontoPagadoValor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMontoPagadoValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblMontoPagadoValor.Location = new System.Drawing.Point(65, 85);
            this.lblMontoPagadoValor.Name = "lblMontoPagadoValor";
            this.lblMontoPagadoValor.Size = new System.Drawing.Size(46, 15);
            this.lblMontoPagadoValor.TabIndex = 8;
            this.lblMontoPagadoValor.Text = "S/ 0.00";
            // 
            // lblMontoPendiente
            // 
            this.lblMontoPendiente.AutoSize = true;
            this.lblMontoPendiente.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMontoPendiente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblMontoPendiente.Location = new System.Drawing.Point(200, 85);
            this.lblMontoPendiente.Name = "lblMontoPendiente";
            this.lblMontoPendiente.Size = new System.Drawing.Size(63, 15);
            this.lblMontoPendiente.TabIndex = 9;
            this.lblMontoPendiente.Text = "Pendiente:";
            // 
            // lblMontoPendienteValor
            // 
            this.lblMontoPendienteValor.AutoSize = true;
            this.lblMontoPendienteValor.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblMontoPendienteValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(48)))), ((int)(((byte)(49)))));
            this.lblMontoPendienteValor.Location = new System.Drawing.Point(265, 83);
            this.lblMontoPendienteValor.Name = "lblMontoPendienteValor";
            this.lblMontoPendienteValor.Size = new System.Drawing.Size(54, 19);
            this.lblMontoPendienteValor.TabIndex = 10;
            this.lblMontoPendienteValor.Text = "S/ 0.00";
            // 
            // FormRegistrarPagoProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(600, 598);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRegistrarPagoProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Pago Proveedor";
            this.Load += new System.EventHandler(this.FormRegistrarPagoProveedor_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlCardObs.ResumeLayout(false);
            this.pnlCardObs.PerformLayout();
            this.pnlCardPago.ResumeLayout(false);
            this.pnlCardPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).EndInit();
            this.pnlCardFecha.ResumeLayout(false);
            this.pnlCardFecha.PerformLayout();
            this.pnlCardInfo.ResumeLayout(false);
            this.pnlCardInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlCardInfo;
        private System.Windows.Forms.Label lblCardInfoTitulo;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblProveedorValor;
        private System.Windows.Forms.Label lblNumeroCompra;
        private System.Windows.Forms.Label lblNumeroCompraValor;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.Label lblMontoTotalValor;
        private System.Windows.Forms.Label lblMontoPagado;
        private System.Windows.Forms.Label lblMontoPagadoValor;
        private System.Windows.Forms.Label lblMontoPendiente;
        private System.Windows.Forms.Label lblMontoPendienteValor;
        private System.Windows.Forms.Panel pnlCardFecha;
        private System.Windows.Forms.Label lblCardFechaTitulo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Panel pnlCardPago;
        private System.Windows.Forms.Label lblCardPagoTitulo;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.NumericUpDown numMonto;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Label lblComprobante;
        private System.Windows.Forms.TextBox txtComprobante;
        private System.Windows.Forms.Panel pnlCardObs;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
    }
}
