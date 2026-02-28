namespace SistemaPOS.Forms.Compras
{
    partial class FormCompras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.pnlDatosCompra = new System.Windows.Forms.Panel();
            this.cmbBuscarProveedor = new System.Windows.Forms.ComboBox();
            this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.lblVencimiento = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblNumeroSerie = new System.Windows.Forms.Label();
            this.cmbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.lblNombreRazonSocial = new System.Windows.Forms.Label();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.lblSubTitulo = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.pnlDetalleProducto = new System.Windows.Forms.Panel();
            this.cmbBuscarProducto = new System.Windows.Forms.ComboBox();
            this.lblLineaDivisora2 = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.rbCredito = new System.Windows.Forms.RadioButton();
            this.rbContado = new System.Windows.Forms.RadioButton();
            this.txtIGV = new System.Windows.Forms.TextBox();
            this.lblIGV = new System.Windows.Forms.Label();
            this.cboIGV = new System.Windows.Forms.ComboBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductoDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPresentacionDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidadPres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidadBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.txtCostoUnitario = new System.Windows.Forms.TextBox();
            this.txtCostoUnitarioBase = new System.Windows.Forms.TextBox();
            this.lblCostoUnitarioBase = new System.Windows.Forms.Label();
            this.txtCantidadBase = new System.Windows.Forms.TextBox();
            this.lblCantidadBase = new System.Windows.Forms.Label();
            this.lblCostoUnitario = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.cmbPresentacion = new System.Windows.Forms.ComboBox();
            this.lblPresentacion = new System.Windows.Forms.Label();
            this.lblSubTitulo2 = new System.Windows.Forms.Label();
            this.lblBuscarProducto = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlDatosCompra.SuspendLayout();
            this.pnlDetalleProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Controls.Add(this.btnHistorial);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1184, 68);
            this.pnlHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registro de Compras";
            //
            // lblHeaderSub
            //
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.lblHeaderSub.Location = new System.Drawing.Point(22, 42);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(200, 15);
            this.lblHeaderSub.TabIndex = 1;
            this.lblHeaderSub.Text = "Ingreso de compras a proveedores";
            //
            // btnHistorial
            //
            this.btnHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(68)))), ((int)(((byte)(70)))));
            this.btnHistorial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorial.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.btnHistorial.FlatAppearance.BorderSize = 1;
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnHistorial.ForeColor = System.Drawing.Color.White;
            this.btnHistorial.Location = new System.Drawing.Point(1063, 20);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(105, 28);
            this.btnHistorial.TabIndex = 2;
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.UseVisualStyleBackColor = false;
            //
            // pnlDatosCompra
            //
            this.pnlDatosCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatosCompra.BackColor = System.Drawing.Color.White;
            this.pnlDatosCompra.Controls.Add(this.cmbBuscarProveedor);
            this.pnlDatosCompra.Controls.Add(this.dtpVencimiento);
            this.pnlDatosCompra.Controls.Add(this.lblVencimiento);
            this.pnlDatosCompra.Controls.Add(this.lblFecha);
            this.pnlDatosCompra.Controls.Add(this.dtpFecha);
            this.pnlDatosCompra.Controls.Add(this.txtNumero);
            this.pnlDatosCompra.Controls.Add(this.lblNumeroSerie);
            this.pnlDatosCompra.Controls.Add(this.cmbTipoComprobante);
            this.pnlDatosCompra.Controls.Add(this.lblTipoComprobante);
            this.pnlDatosCompra.Controls.Add(this.lblNombreRazonSocial);
            this.pnlDatosCompra.Controls.Add(this.lblRazonSocial);
            this.pnlDatosCompra.Controls.Add(this.lblSubTitulo);
            this.pnlDatosCompra.Controls.Add(this.btnBuscarCliente);
            this.pnlDatosCompra.Controls.Add(this.lblProveedor);
            this.pnlDatosCompra.Location = new System.Drawing.Point(16, 80);
            this.pnlDatosCompra.Name = "pnlDatosCompra";
            this.pnlDatosCompra.Size = new System.Drawing.Size(614, 552);
            this.pnlDatosCompra.TabIndex = 123;
            //
            // lblSubTitulo
            //
            this.lblSubTitulo.AutoSize = true;
            this.lblSubTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblSubTitulo.Location = new System.Drawing.Point(14, 11);
            this.lblSubTitulo.Name = "lblSubTitulo";
            this.lblSubTitulo.Size = new System.Drawing.Size(130, 15);
            this.lblSubTitulo.TabIndex = 115;
            this.lblSubTitulo.Text = "DATOS DE COMPRA";
            //
            // lblProveedor
            //
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProveedor.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblProveedor.Location = new System.Drawing.Point(15, 59);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(72, 17);
            this.lblProveedor.TabIndex = 117;
            this.lblProveedor.Text = "Proveedor:";
            //
            // btnBuscarCliente
            //
            this.btnBuscarCliente.BackColor = System.Drawing.Color.White;
            this.btnBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCliente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.btnBuscarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBuscarCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnBuscarCliente.Location = new System.Drawing.Point(572, 56);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(21, 21);
            this.btnBuscarCliente.TabIndex = 118;
            this.btnBuscarCliente.Text = "🔍";
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            //
            // cmbBuscarProveedor
            //
            this.cmbBuscarProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuscarProveedor.FormattingEnabled = true;
            this.cmbBuscarProveedor.Location = new System.Drawing.Point(143, 54);
            this.cmbBuscarProveedor.Name = "cmbBuscarProveedor";
            this.cmbBuscarProveedor.Size = new System.Drawing.Size(423, 21);
            this.cmbBuscarProveedor.TabIndex = 146;
            //
            // lblRazonSocial
            //
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRazonSocial.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazonSocial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblRazonSocial.Location = new System.Drawing.Point(15, 87);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(85, 17);
            this.lblRazonSocial.TabIndex = 119;
            this.lblRazonSocial.Text = "Razón Social:";
            //
            // lblNombreRazonSocial
            //
            this.lblNombreRazonSocial.AutoSize = true;
            this.lblNombreRazonSocial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNombreRazonSocial.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreRazonSocial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblNombreRazonSocial.Location = new System.Drawing.Point(140, 87);
            this.lblNombreRazonSocial.Name = "lblNombreRazonSocial";
            this.lblNombreRazonSocial.Size = new System.Drawing.Size(199, 17);
            this.lblNombreRazonSocial.TabIndex = 120;
            this.lblNombreRazonSocial.Text = "AGROPECUARIA DEL NORTE SAC";
            //
            // lblTipoComprobante
            //
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoComprobante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblTipoComprobante.Location = new System.Drawing.Point(15, 117);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(122, 17);
            this.lblTipoComprobante.TabIndex = 121;
            this.lblTipoComprobante.Text = "Tipo Comprobante:";
            //
            // cmbTipoComprobante
            //
            this.cmbTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoComprobante.FormattingEnabled = true;
            this.cmbTipoComprobante.Items.AddRange(new object[] {
            "Factura",
            "Boleta",
            "Nota de Venta"});
            this.cmbTipoComprobante.Location = new System.Drawing.Point(143, 114);
            this.cmbTipoComprobante.Name = "cmbTipoComprobante";
            this.cmbTipoComprobante.Size = new System.Drawing.Size(182, 21);
            this.cmbTipoComprobante.TabIndex = 122;
            //
            // lblNumeroSerie
            //
            this.lblNumeroSerie.AutoSize = true;
            this.lblNumeroSerie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNumeroSerie.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroSerie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblNumeroSerie.Location = new System.Drawing.Point(345, 117);
            this.lblNumeroSerie.Name = "lblNumeroSerie";
            this.lblNumeroSerie.Size = new System.Drawing.Size(26, 17);
            this.lblNumeroSerie.TabIndex = 123;
            this.lblNumeroSerie.Text = "N°:";
            //
            // txtNumero
            //
            this.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumero.Location = new System.Drawing.Point(401, 114);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(192, 20);
            this.txtNumero.TabIndex = 124;
            //
            // dtpFecha
            //
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(129, 146);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(94, 20);
            this.dtpFecha.TabIndex = 127;
            //
            // lblFecha
            //
            this.lblFecha.AutoSize = true;
            this.lblFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblFecha.Location = new System.Drawing.Point(15, 149);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(44, 17);
            this.lblFecha.TabIndex = 128;
            this.lblFecha.Text = "Fecha:";
            //
            // lblVencimiento
            //
            this.lblVencimiento.AutoSize = true;
            this.lblVencimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblVencimiento.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVencimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblVencimiento.Location = new System.Drawing.Point(345, 151);
            this.lblVencimiento.Name = "lblVencimiento";
            this.lblVencimiento.Size = new System.Drawing.Size(118, 17);
            this.lblVencimiento.TabIndex = 130;
            this.lblVencimiento.Text = "Fecha Vencimiento:";
            //
            // dtpVencimiento
            //
            this.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencimiento.Location = new System.Drawing.Point(501, 146);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.Size = new System.Drawing.Size(92, 20);
            this.dtpVencimiento.TabIndex = 131;
            //
            // pnlDetalleProducto
            //
            this.pnlDetalleProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetalleProducto.BackColor = System.Drawing.Color.White;
            this.pnlDetalleProducto.Controls.Add(this.cmbBuscarProducto);
            this.pnlDetalleProducto.Controls.Add(this.lblLineaDivisora2);
            this.pnlDetalleProducto.Controls.Add(this.numCantidad);
            this.pnlDetalleProducto.Controls.Add(this.btnCancelar);
            this.pnlDetalleProducto.Controls.Add(this.btnGuardar);
            this.pnlDetalleProducto.Controls.Add(this.txtObservaciones);
            this.pnlDetalleProducto.Controls.Add(this.lblObservaciones);
            this.pnlDetalleProducto.Controls.Add(this.txtTotal);
            this.pnlDetalleProducto.Controls.Add(this.lblTotal);
            this.pnlDetalleProducto.Controls.Add(this.lblMetodoPago);
            this.pnlDetalleProducto.Controls.Add(this.rbCredito);
            this.pnlDetalleProducto.Controls.Add(this.rbContado);
            this.pnlDetalleProducto.Controls.Add(this.txtIGV);
            this.pnlDetalleProducto.Controls.Add(this.lblIGV);
            this.pnlDetalleProducto.Controls.Add(this.cboIGV);
            this.pnlDetalleProducto.Controls.Add(this.txtSubtotal);
            this.pnlDetalleProducto.Controls.Add(this.lblSubtotal);
            this.pnlDetalleProducto.Controls.Add(this.dgvProductos);
            this.pnlDetalleProducto.Controls.Add(this.btnAgregarProducto);
            this.pnlDetalleProducto.Controls.Add(this.txtCostoUnitarioBase);
            this.pnlDetalleProducto.Controls.Add(this.lblCostoUnitarioBase);
            this.pnlDetalleProducto.Controls.Add(this.txtCantidadBase);
            this.pnlDetalleProducto.Controls.Add(this.lblCantidadBase);
            this.pnlDetalleProducto.Controls.Add(this.txtCostoUnitario);
            this.pnlDetalleProducto.Controls.Add(this.lblCostoUnitario);
            this.pnlDetalleProducto.Controls.Add(this.lblCantidad);
            this.pnlDetalleProducto.Controls.Add(this.cmbPresentacion);
            this.pnlDetalleProducto.Controls.Add(this.lblPresentacion);
            this.pnlDetalleProducto.Controls.Add(this.lblSubTitulo2);
            this.pnlDetalleProducto.Controls.Add(this.lblBuscarProducto);
            this.pnlDetalleProducto.Location = new System.Drawing.Point(636, 80);
            this.pnlDetalleProducto.Name = "pnlDetalleProducto";
            this.pnlDetalleProducto.Size = new System.Drawing.Size(536, 552);
            this.pnlDetalleProducto.TabIndex = 132;
            //
            // lblSubTitulo2
            //
            this.lblSubTitulo2.AutoSize = true;
            this.lblSubTitulo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubTitulo2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitulo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblSubTitulo2.Location = new System.Drawing.Point(14, 11);
            this.lblSubTitulo2.Name = "lblSubTitulo2";
            this.lblSubTitulo2.Size = new System.Drawing.Size(165, 15);
            this.lblSubTitulo2.TabIndex = 115;
            this.lblSubTitulo2.Text = "DETALLE DEL PRODUCTO";
            //
            // lblBuscarProducto
            //
            this.lblBuscarProducto.AutoSize = true;
            this.lblBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBuscarProducto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblBuscarProducto.Location = new System.Drawing.Point(15, 56);
            this.lblBuscarProducto.Name = "lblBuscarProducto";
            this.lblBuscarProducto.Size = new System.Drawing.Size(64, 17);
            this.lblBuscarProducto.TabIndex = 117;
            this.lblBuscarProducto.Text = "Producto:";
            //
            // cmbBuscarProducto
            //
            this.cmbBuscarProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbBuscarProducto.FormattingEnabled = true;
            this.cmbBuscarProducto.Location = new System.Drawing.Point(114, 53);
            this.cmbBuscarProducto.Name = "cmbBuscarProducto";
            this.cmbBuscarProducto.Size = new System.Drawing.Size(400, 21);
            this.cmbBuscarProducto.TabIndex = 145;
            //
            // lblPresentacion
            //
            this.lblPresentacion.AutoSize = true;
            this.lblPresentacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPresentacion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresentacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblPresentacion.Location = new System.Drawing.Point(15, 87);
            this.lblPresentacion.Name = "lblPresentacion";
            this.lblPresentacion.Size = new System.Drawing.Size(85, 17);
            this.lblPresentacion.TabIndex = 121;
            this.lblPresentacion.Text = "Presentación:";
            //
            // cmbPresentacion
            //
            this.cmbPresentacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPresentacion.FormattingEnabled = true;
            this.cmbPresentacion.Location = new System.Drawing.Point(114, 83);
            this.cmbPresentacion.Name = "cmbPresentacion";
            this.cmbPresentacion.Size = new System.Drawing.Size(242, 21);
            this.cmbPresentacion.TabIndex = 122;
            //
            // lblCantidad
            //
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblCantidad.Location = new System.Drawing.Point(362, 85);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(63, 17);
            this.lblCantidad.TabIndex = 123;
            this.lblCantidad.Text = "Cant. (pres.):";
            //
            // numCantidad
            //
            this.numCantidad.Location = new System.Drawing.Point(439, 81);
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(75, 20);
            this.numCantidad.TabIndex = 143;
            //
            // lblCostoUnitario
            //
            this.lblCostoUnitario.AutoSize = true;
            this.lblCostoUnitario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCostoUnitario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoUnitario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblCostoUnitario.Location = new System.Drawing.Point(15, 116);
            this.lblCostoUnitario.Name = "lblCostoUnitario";
            this.lblCostoUnitario.Size = new System.Drawing.Size(95, 17);
            this.lblCostoUnitario.TabIndex = 125;
            this.lblCostoUnitario.Text = "Costo Unitario:";
            //
            // txtCostoUnitario
            //
            this.txtCostoUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCostoUnitario.Location = new System.Drawing.Point(114, 114);
            this.txtCostoUnitario.Name = "txtCostoUnitario";
            this.txtCostoUnitario.Size = new System.Drawing.Size(94, 20);
            this.txtCostoUnitario.TabIndex = 126;
            //
            // txtCostoUnitarioBase
            //
            this.txtCostoUnitarioBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCostoUnitarioBase.Location = new System.Drawing.Point(345, 141);
            this.txtCostoUnitarioBase.Name = "txtCostoUnitarioBase";
            this.txtCostoUnitarioBase.ReadOnly = true;
            this.txtCostoUnitarioBase.Size = new System.Drawing.Size(80, 20);
            this.txtCostoUnitarioBase.TabIndex = 148;
            this.txtCostoUnitarioBase.TabStop = false;
            this.txtCostoUnitarioBase.Text = "0.0000";
            //
            // lblCostoUnitarioBase
            //
            this.lblCostoUnitarioBase.AutoSize = true;
            this.lblCostoUnitarioBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCostoUnitarioBase.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoUnitarioBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblCostoUnitarioBase.Location = new System.Drawing.Point(222, 143);
            this.lblCostoUnitarioBase.Name = "lblCostoUnitarioBase";
            this.lblCostoUnitarioBase.Size = new System.Drawing.Size(115, 17);
            this.lblCostoUnitarioBase.TabIndex = 147;
            this.lblCostoUnitarioBase.Text = "Costo base (S/kg):";
            //
            // txtCantidadBase
            //
            this.txtCantidadBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidadBase.Location = new System.Drawing.Point(320, 114);
            this.txtCantidadBase.Name = "txtCantidadBase";
            this.txtCantidadBase.ReadOnly = true;
            this.txtCantidadBase.Size = new System.Drawing.Size(80, 20);
            this.txtCantidadBase.TabIndex = 146;
            this.txtCantidadBase.TabStop = false;
            this.txtCantidadBase.Text = "0.00";
            //
            // lblCantidadBase
            //
            this.lblCantidadBase.AutoSize = true;
            this.lblCantidadBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCantidadBase.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblCantidadBase.Location = new System.Drawing.Point(222, 116);
            this.lblCantidadBase.Name = "lblCantidadBase";
            this.lblCantidadBase.Size = new System.Drawing.Size(89, 17);
            this.lblCantidadBase.TabIndex = 145;
            this.lblCantidadBase.Text = "Cant. base kg:";
            //
            // btnAgregarProducto
            //
            this.btnAgregarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnAgregarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarProducto.FlatAppearance.BorderSize = 0;
            this.btnAgregarProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(80)))));
            this.btnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProducto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProducto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProducto.Location = new System.Drawing.Point(385, 157);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(129, 27);
            this.btnAgregarProducto.TabIndex = 127;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            //
            // dgvProductos
            //
            this.dgvProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumero,
            this.colProductoDV,
            this.colPresentacionDV,
            this.colCantidadPres,
            this.colCantidadBase,
            this.colCostoUnitario,
            this.colSubTotal,
            this.colEliminar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.Location = new System.Drawing.Point(3, 183);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowTemplate.Height = 44;
            this.dgvProductos.Size = new System.Drawing.Size(528, 152);
            this.dgvProductos.TabIndex = 128;
            //
            // colNumero
            //
            this.colNumero.HeaderText = "#";
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            this.colNumero.Width = 25;
            //
            // colProductoDV
            //
            this.colProductoDV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProductoDV.HeaderText = "Productos";
            this.colProductoDV.Name = "colProductoDV";
            this.colProductoDV.ReadOnly = true;
            //
            // colPresentacionDV
            //
            this.colPresentacionDV.HeaderText = "Presentación";
            this.colPresentacionDV.Name = "colPresentacionDV";
            this.colPresentacionDV.ReadOnly = true;
            this.colPresentacionDV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPresentacionDV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colCantidadPres
            //
            this.colCantidadPres.HeaderText = "Pres. (ref.)";
            this.colCantidadPres.Name = "colCantidadPres";
            this.colCantidadPres.ReadOnly = true;
            this.colCantidadPres.Width = 80;
            //
            // colCantidadBase
            //
            this.colCantidadBase.HeaderText = "Equivalente";
            this.colCantidadBase.Name = "colCantidadBase";
            this.colCantidadBase.ReadOnly = true;
            this.colCantidadBase.Width = 80;
            //
            // colCostoUnitario
            //
            this.colCostoUnitario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCostoUnitario.FillWeight = 90F;
            this.colCostoUnitario.HeaderText = "Costo Unitario";
            this.colCostoUnitario.Name = "colCostoUnitario";
            this.colCostoUnitario.ReadOnly = true;
            this.colCostoUnitario.Width = 90;
            //
            // colSubTotal
            //
            this.colSubTotal.HeaderText = "Subtotal";
            this.colSubTotal.Name = "colSubTotal";
            this.colSubTotal.ReadOnly = true;
            this.colSubTotal.Width = 70;
            //
            // colEliminar
            //
            this.colEliminar.HeaderText = "";
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.Width = 25;
            //
            // lblSubtotal
            //
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblSubtotal.Location = new System.Drawing.Point(331, 356);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(68, 17);
            this.lblSubtotal.TabIndex = 129;
            this.lblSubtotal.Text = "SUBTOTAL:";
            //
            // txtSubtotal
            //
            this.txtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubtotal.Location = new System.Drawing.Point(440, 353);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(76, 20);
            this.txtSubtotal.TabIndex = 130;
            //
            // cboIGV
            //
            this.cboIGV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIGV.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboIGV.Items.AddRange(new object[] { "Sin IGV", "IGV Incluido", "IGV Adicional" });
            this.cboIGV.Location = new System.Drawing.Point(18, 354);
            this.cboIGV.Name = "cboIGV";
            this.cboIGV.Size = new System.Drawing.Size(150, 24);
            this.cboIGV.TabIndex = 131;
            this.cboIGV.SelectedIndex = 0;
            //
            // lblIGV
            //
            this.lblIGV.AutoSize = true;
            this.lblIGV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblIGV.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIGV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblIGV.Location = new System.Drawing.Point(331, 382);
            this.lblIGV.Name = "lblIGV";
            this.lblIGV.Size = new System.Drawing.Size(68, 17);
            this.lblIGV.TabIndex = 132;
            this.lblIGV.Text = "IGV (18%):";
            //
            // txtIGV
            //
            this.txtIGV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIGV.Location = new System.Drawing.Point(440, 381);
            this.txtIGV.Name = "txtIGV";
            this.txtIGV.Size = new System.Drawing.Size(76, 20);
            this.txtIGV.TabIndex = 133;
            //
            // rbContado
            //
            this.rbContado.AutoSize = true;
            this.rbContado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rbContado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.rbContado.Location = new System.Drawing.Point(136, 385);
            this.rbContado.Name = "rbContado";
            this.rbContado.Size = new System.Drawing.Size(76, 21);
            this.rbContado.TabIndex = 134;
            this.rbContado.TabStop = true;
            this.rbContado.Text = "Contado";
            this.rbContado.UseVisualStyleBackColor = true;
            //
            // rbCredito
            //
            this.rbCredito.AutoSize = true;
            this.rbCredito.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rbCredito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.rbCredito.Location = new System.Drawing.Point(228, 385);
            this.rbCredito.Name = "rbCredito";
            this.rbCredito.Size = new System.Drawing.Size(69, 21);
            this.rbCredito.TabIndex = 135;
            this.rbCredito.TabStop = true;
            this.rbCredito.Text = "Crédito";
            this.rbCredito.UseVisualStyleBackColor = true;
            //
            // lblMetodoPago
            //
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMetodoPago.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetodoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblMetodoPago.Location = new System.Drawing.Point(15, 386);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(111, 17);
            this.lblMetodoPago.TabIndex = 136;
            this.lblMetodoPago.Text = "Método de Pago:";
            //
            // lblTotal
            //
            this.lblTotal.AutoSize = true;
            this.lblTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblTotal.Location = new System.Drawing.Point(331, 429);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(58, 20);
            this.lblTotal.TabIndex = 137;
            this.lblTotal.Text = "TOTAL:";
            //
            // txtTotal
            //
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Location = new System.Drawing.Point(440, 428);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(76, 20);
            this.txtTotal.TabIndex = 138;
            //
            // lblObservaciones
            //
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblObservaciones.Location = new System.Drawing.Point(15, 418);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(97, 17);
            this.lblObservaciones.TabIndex = 139;
            this.lblObservaciones.Text = "Observaciones:";
            //
            // txtObservaciones
            //
            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservaciones.Location = new System.Drawing.Point(18, 436);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(276, 42);
            this.txtObservaciones.TabIndex = 140;
            //
            // btnGuardar
            //
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(80)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(141, 505);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 32);
            this.btnGuardar.TabIndex = 141;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            //
            // btnCancelar
            //
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(45)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(291, 505);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 32);
            this.btnCancelar.TabIndex = 142;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            //
            // lblLineaDivisora2
            //
            this.lblLineaDivisora2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.lblLineaDivisora2.Location = new System.Drawing.Point(333, 405);
            this.lblLineaDivisora2.Name = "lblLineaDivisora2";
            this.lblLineaDivisora2.Size = new System.Drawing.Size(192, 13);
            this.lblLineaDivisora2.TabIndex = 144;
            //
            // FormCompras
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1184, 644);
            this.Controls.Add(this.pnlDetalleProducto);
            this.Controls.Add(this.pnlDatosCompra);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCompras";
            this.Text = "FormCompras";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlDatosCompra.ResumeLayout(false);
            this.pnlDatosCompra.PerformLayout();
            this.pnlDetalleProducto.ResumeLayout(false);
            this.pnlDetalleProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Label lblSubTitulo;
        private System.Windows.Forms.Panel pnlDatosCompra;
        private System.Windows.Forms.Label lblNombreRazonSocial;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.ComboBox cmbTipoComprobante;
        private System.Windows.Forms.Label lblTipoComprobante;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblNumeroSerie;
        private System.Windows.Forms.Label lblVencimiento;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.ComboBox cmbBuscarProveedor;
        private System.Windows.Forms.Panel pnlDetalleProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.ComboBox cmbPresentacion;
        private System.Windows.Forms.Label lblPresentacion;
        private System.Windows.Forms.Label lblSubTitulo2;
        private System.Windows.Forms.Label lblBuscarProducto;
        private System.Windows.Forms.TextBox txtCostoUnitario;
        private System.Windows.Forms.Label lblCostoUnitario;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductoDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPresentacionDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidadPres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidadBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubTotal;
        private System.Windows.Forms.DataGridViewImageColumn colEliminar;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.TextBox txtIGV;
        private System.Windows.Forms.Label lblIGV;
        private System.Windows.Forms.ComboBox cboIGV;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.RadioButton rbCredito;
        private System.Windows.Forms.RadioButton rbContado;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label lblLineaDivisora2;
        private System.Windows.Forms.ComboBox cmbBuscarProducto;
        private System.Windows.Forms.TextBox txtCostoUnitarioBase;
        private System.Windows.Forms.Label lblCostoUnitarioBase;
        private System.Windows.Forms.TextBox txtCantidadBase;
        private System.Windows.Forms.Label lblCantidadBase;
    }
}
