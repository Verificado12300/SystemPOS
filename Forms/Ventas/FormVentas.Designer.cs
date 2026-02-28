namespace SistemaPOS.Forms.Ventas
{
    partial class FormVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.pnlDetalleVenta = new System.Windows.Forms.Panel();
            this.cboIGV = new System.Windows.Forms.ComboBox();
            this.grpMetodoPago = new System.Windows.Forms.GroupBox();
            this.txtTransferencia = new System.Windows.Forms.TextBox();
            this.txtYape = new System.Windows.Forms.TextBox();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.rbEfectivo = new System.Windows.Forms.RadioButton();
            this.rbYape = new System.Windows.Forms.RadioButton();
            this.rbTransferencia = new System.Windows.Forms.RadioButton();
            this.rbMixto = new System.Windows.Forms.RadioButton();
            this.rbCredito = new System.Windows.Forms.RadioButton();
            this.rbTarjeta = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.lblLineaDivisora4 = new System.Windows.Forms.Label();
            this.txtVuelto = new System.Windows.Forms.TextBox();
            this.lblVuelto = new System.Windows.Forms.Label();
            this.txtRecibido = new System.Windows.Forms.TextBox();
            this.lblRecibido = new System.Windows.Forms.Label();
            this.lblLineaDivisora3 = new System.Windows.Forms.Label();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.lblLineaDivisora2 = new System.Windows.Forms.Label();
            this.txtIGV = new System.Windows.Forms.TextBox();
            this.lblIGV = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.dgvCarritoVenta = new System.Windows.Forms.DataGridView();
            this.colProductoDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPresentacionDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantPres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisminuir = new System.Windows.Forms.DataGridViewImageColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAumentar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colTotalDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblLineaDivisora = new System.Windows.Forms.Label();
            this.pnlDetalleCliente = new System.Windows.Forms.Panel();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.cmbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.lblDNICliente = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.lblSubTitulo2 = new System.Windows.Forms.Label();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImagen = new System.Windows.Forms.DataGridViewImageColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPresentacion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPrecioUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.pnlDetalleVenta.SuspendLayout();
            this.grpMetodoPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarritoVenta)).BeginInit();
            this.pnlDetalleCliente.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBusqueda.BackColor = System.Drawing.Color.White;
            this.pnlBusqueda.Controls.Add(this.txtBuscar);
            this.pnlBusqueda.Controls.Add(this.lblBuscar);
            this.pnlBusqueda.Controls.Add(this.dgvProductos);
            this.pnlBusqueda.Location = new System.Drawing.Point(25, 76);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(723, 728);
            this.pnlBusqueda.TabIndex = 120;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(17, 33);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(689, 24);
            this.txtBuscar.TabIndex = 111;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblBuscar.Location = new System.Drawing.Point(14, 15);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(46, 17);
            this.lblBuscar.TabIndex = 112;
            this.lblBuscar.Text = "Buscar";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumero,
            this.colImagen,
            this.colProducto,
            this.colPresentacion,
            this.colPrecioUnit});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.Location = new System.Drawing.Point(17, 83);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowTemplate.Height = 44;
            this.dgvProductos.Size = new System.Drawing.Size(689, 622);
            this.dgvProductos.TabIndex = 113;
            // 
            // pnlDetalleVenta
            // 
            this.pnlDetalleVenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetalleVenta.BackColor = System.Drawing.Color.White;
            this.pnlDetalleVenta.Controls.Add(this.cboIGV);
            this.pnlDetalleVenta.Controls.Add(this.grpMetodoPago);
            this.pnlDetalleVenta.Controls.Add(this.btnCancelar);
            this.pnlDetalleVenta.Controls.Add(this.btnCobrar);
            this.pnlDetalleVenta.Controls.Add(this.lblLineaDivisora4);
            this.pnlDetalleVenta.Controls.Add(this.txtVuelto);
            this.pnlDetalleVenta.Controls.Add(this.lblVuelto);
            this.pnlDetalleVenta.Controls.Add(this.txtRecibido);
            this.pnlDetalleVenta.Controls.Add(this.lblRecibido);
            this.pnlDetalleVenta.Controls.Add(this.lblLineaDivisora3);
            this.pnlDetalleVenta.Controls.Add(this.txtTotalPagar);
            this.pnlDetalleVenta.Controls.Add(this.lblTotalPagar);
            this.pnlDetalleVenta.Controls.Add(this.lblLineaDivisora2);
            this.pnlDetalleVenta.Controls.Add(this.txtIGV);
            this.pnlDetalleVenta.Controls.Add(this.lblIGV);
            this.pnlDetalleVenta.Controls.Add(this.txtDescuento);
            this.pnlDetalleVenta.Controls.Add(this.lblDescuento);
            this.pnlDetalleVenta.Controls.Add(this.txtSubtotal);
            this.pnlDetalleVenta.Controls.Add(this.lblSubTotal);
            this.pnlDetalleVenta.Controls.Add(this.dgvCarritoVenta);
            this.pnlDetalleVenta.Controls.Add(this.lblLineaDivisora);
            this.pnlDetalleVenta.Controls.Add(this.pnlDetalleCliente);
            this.pnlDetalleVenta.Controls.Add(this.lblSubTitulo2);
            this.pnlDetalleVenta.Location = new System.Drawing.Point(770, 76);
            this.pnlDetalleVenta.Name = "pnlDetalleVenta";
            this.pnlDetalleVenta.Size = new System.Drawing.Size(502, 728);
            this.pnlDetalleVenta.TabIndex = 121;
            //
            // cboIGV
            //
            this.cboIGV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIGV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIGV.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboIGV.Items.AddRange(new object[] { "Sin IGV", "IGV Incluido", "IGV Adicional" });
            this.cboIGV.Location = new System.Drawing.Point(295, 390);
            this.cboIGV.Name = "cboIGV";
            this.cboIGV.Size = new System.Drawing.Size(130, 25);
            this.cboIGV.TabIndex = 142;
            this.cboIGV.SelectedIndex = 0;
            // 
            // grpMetodoPago
            // 
            this.grpMetodoPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpMetodoPago.Controls.Add(this.txtTransferencia);
            this.grpMetodoPago.Controls.Add(this.txtYape);
            this.grpMetodoPago.Controls.Add(this.txtEfectivo);
            this.grpMetodoPago.Controls.Add(this.txtTarjeta);
            this.grpMetodoPago.Controls.Add(this.rbEfectivo);
            this.grpMetodoPago.Controls.Add(this.rbYape);
            this.grpMetodoPago.Controls.Add(this.rbTransferencia);
            this.grpMetodoPago.Controls.Add(this.rbMixto);
            this.grpMetodoPago.Controls.Add(this.rbCredito);
            this.grpMetodoPago.Controls.Add(this.rbTarjeta);
            this.grpMetodoPago.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.grpMetodoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.grpMetodoPago.Location = new System.Drawing.Point(17, 488);
            this.grpMetodoPago.Name = "grpMetodoPago";
            this.grpMetodoPago.Size = new System.Drawing.Size(248, 170);
            this.grpMetodoPago.TabIndex = 141;
            this.grpMetodoPago.TabStop = false;
            this.grpMetodoPago.Text = "Método de Pago";
            // 
            // txtTransferencia
            // 
            this.txtTransferencia.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtTransferencia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTransferencia.Location = new System.Drawing.Point(155, 71);
            this.txtTransferencia.Multiline = true;
            this.txtTransferencia.Name = "txtTransferencia";
            this.txtTransferencia.Size = new System.Drawing.Size(87, 21);
            this.txtTransferencia.TabIndex = 135;
            this.txtTransferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtYape
            // 
            this.txtYape.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtYape.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtYape.Location = new System.Drawing.Point(155, 48);
            this.txtYape.Multiline = true;
            this.txtYape.Name = "txtYape";
            this.txtYape.Size = new System.Drawing.Size(87, 21);
            this.txtYape.TabIndex = 134;
            this.txtYape.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEfectivo.Location = new System.Drawing.Point(155, 25);
            this.txtEfectivo.Multiline = true;
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(87, 21);
            this.txtEfectivo.TabIndex = 117;
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTarjeta.Location = new System.Drawing.Point(155, 94);
            this.txtTarjeta.Multiline = true;
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(87, 21);
            this.txtTarjeta.TabIndex = 137;
            this.txtTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rbEfectivo
            // 
            this.rbEfectivo.AutoSize = true;
            this.rbEfectivo.Location = new System.Drawing.Point(8, 22);
            this.rbEfectivo.Name = "rbEfectivo";
            this.rbEfectivo.Size = new System.Drawing.Size(71, 21);
            this.rbEfectivo.TabIndex = 129;
            this.rbEfectivo.TabStop = true;
            this.rbEfectivo.Text = "Efectivo";
            this.rbEfectivo.UseVisualStyleBackColor = true;
            // 
            // rbYape
            // 
            this.rbYape.AutoSize = true;
            this.rbYape.Location = new System.Drawing.Point(8, 46);
            this.rbYape.Name = "rbYape";
            this.rbYape.Size = new System.Drawing.Size(54, 21);
            this.rbYape.TabIndex = 130;
            this.rbYape.TabStop = true;
            this.rbYape.Text = "Yape";
            this.rbYape.UseVisualStyleBackColor = true;
            // 
            // rbTransferencia
            // 
            this.rbTransferencia.AutoSize = true;
            this.rbTransferencia.Location = new System.Drawing.Point(8, 70);
            this.rbTransferencia.Name = "rbTransferencia";
            this.rbTransferencia.Size = new System.Drawing.Size(103, 21);
            this.rbTransferencia.TabIndex = 131;
            this.rbTransferencia.TabStop = true;
            this.rbTransferencia.Text = "Transferencia";
            this.rbTransferencia.UseVisualStyleBackColor = true;
            // 
            // rbMixto
            // 
            this.rbMixto.AutoSize = true;
            this.rbMixto.Location = new System.Drawing.Point(8, 119);
            this.rbMixto.Name = "rbMixto";
            this.rbMixto.Size = new System.Drawing.Size(59, 21);
            this.rbMixto.TabIndex = 132;
            this.rbMixto.TabStop = true;
            this.rbMixto.Text = "Mixto";
            this.rbMixto.UseVisualStyleBackColor = true;
            // 
            // rbCredito
            // 
            this.rbCredito.AutoSize = true;
            this.rbCredito.Location = new System.Drawing.Point(8, 143);
            this.rbCredito.Name = "rbCredito";
            this.rbCredito.Size = new System.Drawing.Size(69, 21);
            this.rbCredito.TabIndex = 133;
            this.rbCredito.TabStop = true;
            this.rbCredito.Text = "Crédito";
            this.rbCredito.UseVisualStyleBackColor = true;
            // 
            // rbTarjeta
            // 
            this.rbTarjeta.AutoSize = true;
            this.rbTarjeta.Location = new System.Drawing.Point(8, 94);
            this.rbTarjeta.Name = "rbTarjeta";
            this.rbTarjeta.Size = new System.Drawing.Size(65, 21);
            this.rbTarjeta.TabIndex = 136;
            this.rbTarjeta.TabStop = true;
            this.rbTarjeta.Text = "Tarjeta";
            this.rbTarjeta.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(45)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(145, 683);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 32);
            this.btnCancelar.TabIndex = 142;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnCobrar
            // 
            this.btnCobrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCobrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.btnCobrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCobrar.FlatAppearance.BorderSize = 0;
            this.btnCobrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(220)))), ((int)(((byte)(0)))));
            this.btnCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCobrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnCobrar.Location = new System.Drawing.Point(290, 683);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(120, 32);
            this.btnCobrar.TabIndex = 139;
            this.btnCobrar.Text = "Cobrar";
            this.btnCobrar.UseVisualStyleBackColor = false;
            // 
            // lblLineaDivisora4
            // 
            this.lblLineaDivisora4.AutoSize = true;
            this.lblLineaDivisora4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.lblLineaDivisora4.Location = new System.Drawing.Point(14, 568);
            this.lblLineaDivisora4.Name = "lblLineaDivisora4";
            this.lblLineaDivisora4.Size = new System.Drawing.Size(0, 13);
            this.lblLineaDivisora4.TabIndex = 138;
            // 
            // txtVuelto
            // 
            this.txtVuelto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVuelto.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtVuelto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVuelto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtVuelto.Location = new System.Drawing.Point(396, 540);
            this.txtVuelto.Multiline = true;
            this.txtVuelto.Name = "txtVuelto";
            this.txtVuelto.Size = new System.Drawing.Size(90, 25);
            this.txtVuelto.TabIndex = 136;
            this.txtVuelto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblVuelto
            // 
            this.lblVuelto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVuelto.AutoSize = true;
            this.lblVuelto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblVuelto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVuelto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblVuelto.Location = new System.Drawing.Point(324, 544);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Size = new System.Drawing.Size(56, 17);
            this.lblVuelto.TabIndex = 137;
            this.lblVuelto.Text = "VUELTO:";
            // 
            // txtRecibido
            // 
            this.txtRecibido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecibido.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtRecibido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRecibido.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRecibido.Location = new System.Drawing.Point(396, 510);
            this.txtRecibido.Multiline = true;
            this.txtRecibido.Name = "txtRecibido";
            this.txtRecibido.Size = new System.Drawing.Size(90, 25);
            this.txtRecibido.TabIndex = 134;
            this.txtRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRecibido
            // 
            this.lblRecibido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecibido.AutoSize = true;
            this.lblRecibido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRecibido.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecibido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblRecibido.Location = new System.Drawing.Point(324, 512);
            this.lblRecibido.Name = "lblRecibido";
            this.lblRecibido.Size = new System.Drawing.Size(66, 17);
            this.lblRecibido.TabIndex = 135;
            this.lblRecibido.Text = "RECIBIDO:";
            // 
            // lblLineaDivisora3
            // 
            this.lblLineaDivisora3.AutoSize = true;
            this.lblLineaDivisora3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.lblLineaDivisora3.Location = new System.Drawing.Point(14, 465);
            this.lblLineaDivisora3.Name = "lblLineaDivisora3";
            this.lblLineaDivisora3.Size = new System.Drawing.Size(0, 13);
            this.lblLineaDivisora3.TabIndex = 127;
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalPagar.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtTotalPagar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalPagar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPagar.Location = new System.Drawing.Point(345, 437);
            this.txtTotalPagar.Multiline = true;
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.Size = new System.Drawing.Size(141, 25);
            this.txtTotalPagar.TabIndex = 125;
            this.txtTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalPagar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblTotalPagar.Location = new System.Drawing.Point(14, 441);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(111, 17);
            this.lblTotalPagar.TabIndex = 126;
            this.lblTotalPagar.Text = "TOTAL A PAGAR:";
            // 
            // lblLineaDivisora2
            // 
            this.lblLineaDivisora2.AutoSize = true;
            this.lblLineaDivisora2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.lblLineaDivisora2.Location = new System.Drawing.Point(14, 422);
            this.lblLineaDivisora2.Name = "lblLineaDivisora2";
            this.lblLineaDivisora2.Size = new System.Drawing.Size(0, 13);
            this.lblLineaDivisora2.TabIndex = 124;
            // 
            // txtIGV
            // 
            this.txtIGV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIGV.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtIGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIGV.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtIGV.Location = new System.Drawing.Point(396, 392);
            this.txtIGV.Multiline = true;
            this.txtIGV.Name = "txtIGV";
            this.txtIGV.Size = new System.Drawing.Size(90, 25);
            this.txtIGV.TabIndex = 122;
            this.txtIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIGV
            // 
            this.lblIGV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIGV.AutoSize = true;
            this.lblIGV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblIGV.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIGV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblIGV.Location = new System.Drawing.Point(14, 396);
            this.lblIGV.Name = "lblIGV";
            this.lblIGV.Size = new System.Drawing.Size(68, 17);
            this.lblIGV.TabIndex = 123;
            this.lblIGV.Text = "IGV (18%):";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescuento.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescuento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDescuento.Location = new System.Drawing.Point(396, 364);
            this.txtDescuento.Multiline = true;
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(90, 25);
            this.txtDescuento.TabIndex = 120;
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDescuento
            // 
            this.lblDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDescuento.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblDescuento.Location = new System.Drawing.Point(14, 368);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(84, 17);
            this.lblDescuento.TabIndex = 121;
            this.lblDescuento.Text = "DESCUENTO:";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubtotal.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubtotal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSubtotal.Location = new System.Drawing.Point(396, 336);
            this.txtSubtotal.Multiline = true;
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(90, 25);
            this.txtSubtotal.TabIndex = 117;
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblSubTotal.Location = new System.Drawing.Point(14, 340);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(76, 17);
            this.lblSubTotal.TabIndex = 118;
            this.lblSubTotal.Text = "BASE IMP.:";
            // 
            // dgvCarritoVenta
            // 
            this.dgvCarritoVenta.AllowUserToAddRows = false;
            this.dgvCarritoVenta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCarritoVenta.BackgroundColor = System.Drawing.Color.White;
            this.dgvCarritoVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCarritoVenta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCarritoVenta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCarritoVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarritoVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductoDV,
            this.colPresentacionDV,
            this.colCantPres,
            this.colDisminuir,
            this.colCantidad,
            this.colAumentar,
            this.colTotalDV,
            this.colEliminar});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCarritoVenta.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCarritoVenta.EnableHeadersVisualStyles = false;
            this.dgvCarritoVenta.Location = new System.Drawing.Point(17, 204);
            this.dgvCarritoVenta.Name = "dgvCarritoVenta";
            this.dgvCarritoVenta.RowHeadersVisible = false;
            this.dgvCarritoVenta.RowTemplate.Height = 44;
            this.dgvCarritoVenta.Size = new System.Drawing.Size(485, 126);
            this.dgvCarritoVenta.TabIndex = 114;
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
            this.colPresentacionDV.Width = 70;
            //
            // colCantPres
            //
            this.colCantPres.HeaderText = "Pres. (ref.)";
            this.colCantPres.Name = "colCantPres";
            this.colCantPres.ReadOnly = true;
            this.colCantPres.Width = 90;
            //
            // colDisminuir
            // 
            this.colDisminuir.HeaderText = "";
            this.colDisminuir.Name = "colDisminuir";
            this.colDisminuir.ReadOnly = true;
            this.colDisminuir.Width = 25;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Width = 70;
            // 
            // colAumentar
            // 
            this.colAumentar.HeaderText = "";
            this.colAumentar.Name = "colAumentar";
            this.colAumentar.ReadOnly = true;
            this.colAumentar.Width = 25;
            // 
            // colTotalDV
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTotalDV.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTotalDV.HeaderText = "Total";
            this.colTotalDV.Name = "colTotalDV";
            this.colTotalDV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTotalDV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTotalDV.Width = 70;
            // 
            // colEliminar
            // 
            this.colEliminar.HeaderText = "";
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.Width = 25;
            // 
            // lblLineaDivisora
            // 
            this.lblLineaDivisora.AutoSize = true;
            this.lblLineaDivisora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.lblLineaDivisora.Location = new System.Drawing.Point(14, 322);
            this.lblLineaDivisora.Name = "lblLineaDivisora";
            this.lblLineaDivisora.Size = new System.Drawing.Size(0, 13);
            this.lblLineaDivisora.TabIndex = 119;
            // 
            // pnlDetalleCliente
            // 
            this.pnlDetalleCliente.BackColor = System.Drawing.Color.White;
            this.pnlDetalleCliente.Controls.Add(this.cmbClientes);
            this.pnlDetalleCliente.Controls.Add(this.cmbTipoComprobante);
            this.pnlDetalleCliente.Controls.Add(this.lblTipoComprobante);
            this.pnlDetalleCliente.Controls.Add(this.lblDNICliente);
            this.pnlDetalleCliente.Controls.Add(this.lblCliente);
            this.pnlDetalleCliente.Controls.Add(this.lblNombreCliente);
            this.pnlDetalleCliente.Controls.Add(this.btnBuscarCliente);
            this.pnlDetalleCliente.Location = new System.Drawing.Point(17, 47);
            this.pnlDetalleCliente.Name = "pnlDetalleCliente";
            this.pnlDetalleCliente.Size = new System.Drawing.Size(485, 143);
            this.pnlDetalleCliente.TabIndex = 117;
            // 
            // cmbClientes
            // 
            this.cmbClientes.BackColor = System.Drawing.Color.White;
            this.cmbClientes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(66, 10);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(380, 25);
            this.cmbClientes.TabIndex = 119;
            // 
            // cmbTipoComprobante
            // 
            this.cmbTipoComprobante.BackColor = System.Drawing.Color.White;
            this.cmbTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbTipoComprobante.FormattingEnabled = true;
            this.cmbTipoComprobante.Items.AddRange(new object[] {
            "BOLETA",
            "FACTURA",
            "NOTA_VENTA"});
            this.cmbTipoComprobante.Location = new System.Drawing.Point(179, 86);
            this.cmbTipoComprobante.Name = "cmbTipoComprobante";
            this.cmbTipoComprobante.Size = new System.Drawing.Size(267, 25);
            this.cmbTipoComprobante.TabIndex = 2;
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoComprobante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblTipoComprobante.Location = new System.Drawing.Point(10, 89);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(141, 17);
            this.lblTipoComprobante.TabIndex = 118;
            this.lblTipoComprobante.Text = "Tipo de Comprobante:";
            // 
            // lblDNICliente
            // 
            this.lblDNICliente.AutoSize = true;
            this.lblDNICliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDNICliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblDNICliente.Location = new System.Drawing.Point(270, 51);
            this.lblDNICliente.Name = "lblDNICliente";
            this.lblDNICliente.Size = new System.Drawing.Size(95, 17);
            this.lblDNICliente.TabIndex = 116;
            this.lblDNICliente.Text = "DNI del Cliente";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblCliente.Location = new System.Drawing.Point(10, 13);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(50, 17);
            this.lblCliente.TabIndex = 113;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNombreCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblNombreCliente.Location = new System.Drawing.Point(10, 51);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(183, 17);
            this.lblNombreCliente.TabIndex = 115;
            this.lblNombreCliente.Text = "Nombre Completo del Cliente";
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
            this.btnBuscarCliente.Location = new System.Drawing.Point(452, 12);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(21, 21);
            this.btnBuscarCliente.TabIndex = 114;
            this.btnBuscarCliente.Text = "🔍";
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            // 
            // lblSubTitulo2
            // 
            this.lblSubTitulo2.AutoSize = true;
            this.lblSubTitulo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubTitulo2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitulo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblSubTitulo2.Location = new System.Drawing.Point(13, 13);
            this.lblSubTitulo2.Name = "lblSubTitulo2";
            this.lblSubTitulo2.Size = new System.Drawing.Size(107, 13);
            this.lblSubTitulo2.TabIndex = 12;
            this.lblSubTitulo2.Text = "DETALLE DE VENTA";
            // 
            // btnHistorial
            // 
            this.btnHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHistorial.BackColor = System.Drawing.Color.White;
            this.btnHistorial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorial.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.btnHistorial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnHistorial.Location = new System.Drawing.Point(1152, 13);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(120, 32);
            this.btnHistorial.TabIndex = 141;
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.UseVisualStyleBackColor = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(173, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Punto de Venta";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.btnHistorial);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 10, 20, 5);
            this.pnlHeader.Size = new System.Drawing.Size(1284, 55);
            this.pnlHeader.TabIndex = 144;
            // 
            // colNumero
            // 
            this.colNumero.HeaderText = "#";
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            this.colNumero.Width = 30;
            // 
            // colImagen
            // 
            this.colImagen.HeaderText = "Imagen";
            this.colImagen.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colImagen.Name = "colImagen";
            this.colImagen.ReadOnly = true;
            this.colImagen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colImagen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colProducto
            // 
            this.colProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProducto.HeaderText = "Productos";
            this.colProducto.Name = "colProducto";
            this.colProducto.ReadOnly = true;
            // 
            // colPresentacion
            // 
            this.colPresentacion.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colPresentacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colPresentacion.HeaderText = "Presentación";
            this.colPresentacion.Name = "colPresentacion";
            this.colPresentacion.Width = 180;
            // 
            // colPrecioUnit
            // 
            this.colPrecioUnit.HeaderText = "Precio Unit.";
            this.colPrecioUnit.Name = "colPrecioUnit";
            this.colPrecioUnit.ReadOnly = true;
            this.colPrecioUnit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPrecioUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1284, 824);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlDetalleVenta);
            this.Controls.Add(this.pnlBusqueda);
            this.Name = "FormVentas";
            this.Text = "FormVentas";
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.pnlDetalleVenta.ResumeLayout(false);
            this.pnlDetalleVenta.PerformLayout();
            this.grpMetodoPago.ResumeLayout(false);
            this.grpMetodoPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarritoVenta)).EndInit();
            this.pnlDetalleCliente.ResumeLayout(false);
            this.pnlDetalleCliente.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Panel pnlDetalleVenta;
        private System.Windows.Forms.Label lblSubTitulo2;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.DataGridView dgvCarritoVenta;
        private System.Windows.Forms.Panel pnlDetalleCliente;
        private System.Windows.Forms.Label lblDNICliente;
        private System.Windows.Forms.Label lblLineaDivisora2;
        private System.Windows.Forms.TextBox txtIGV;
        private System.Windows.Forms.Label lblIGV;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblLineaDivisora;
        private System.Windows.Forms.Label lblLineaDivisora3;
        private System.Windows.Forms.TextBox txtTotalPagar;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.RadioButton rbCredito;
        private System.Windows.Forms.RadioButton rbTarjeta;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.RadioButton rbMixto;
        private System.Windows.Forms.RadioButton rbTransferencia;
        private System.Windows.Forms.RadioButton rbYape;
        private System.Windows.Forms.RadioButton rbEfectivo;
        private System.Windows.Forms.Label lblLineaDivisora4;
        private System.Windows.Forms.TextBox txtVuelto;
        private System.Windows.Forms.Label lblVuelto;
        private System.Windows.Forms.TextBox txtRecibido;
        private System.Windows.Forms.Label lblRecibido;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grpMetodoPago;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.TextBox txtTransferencia;
        private System.Windows.Forms.TextBox txtYape;
        private System.Windows.Forms.ComboBox cboIGV;
        private System.Windows.Forms.Label lblTipoComprobante;
        private System.Windows.Forms.ComboBox cmbTipoComprobante;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductoDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPresentacionDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantPres;
        private System.Windows.Forms.DataGridViewImageColumn colDisminuir;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewImageColumn colAumentar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalDV;
        private System.Windows.Forms.DataGridViewImageColumn colEliminar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewImageColumn colImagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioUnit;
    }
}