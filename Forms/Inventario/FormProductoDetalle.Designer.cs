namespace SistemaPOS.Forms.Inventario
{
    partial class FormProductoDetalle
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
            this.lblInformacion = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblUnidadBase = new System.Windows.Forms.Label();
            this.cmbUnidadBase = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.lblImagen = new System.Windows.Forms.Label();
            this.pbImagenProducto = new System.Windows.Forms.PictureBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.lblPresentacionyPrecio = new System.Windows.Forms.Label();
            this.lblPresentacion = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.cmbPresentacion = new System.Windows.Forms.ComboBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.dgvPresentaciones = new System.Windows.Forms.DataGridView();
            this.colPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidadBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGanancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtStockMinimo = new System.Windows.Forms.TextBox();
            this.lblStockMinimo = new System.Windows.Forms.Label();
            this.txtStockMaximo = new System.Windows.Forms.TextBox();
            this.lblStockMaximo = new System.Windows.Forms.Label();
            this.txtCostoBase = new System.Windows.Forms.TextBox();
            this.lblCosto = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnAgregarPres = new System.Windows.Forms.Button();
            this.chkPrecioIncluyeIGV = new System.Windows.Forms.CheckBox();
            this.colIGVPres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresentaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInformacion
            // 
            this.lblInformacion.AutoSize = true;
            this.lblInformacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblInformacion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformacion.Location = new System.Drawing.Point(13, 60);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(175, 20);
            this.lblInformacion.TabIndex = 12;
            this.lblInformacion.Text = "INFORMACIÓN BÁSICA";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(16, 210);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(167, 21);
            this.cmbCategoria.TabIndex = 11;
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.White;
            this.btnCargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.btnCargar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCargar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnCargar.Location = new System.Drawing.Point(575, 117);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(71, 23);
            this.btnCargar.TabIndex = 10;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(259, 21);
            this.lblTitulo.TabIndex = 9;
            this.lblTitulo.Text = "Nuevo Producto / Editar Producto";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Location = new System.Drawing.Point(16, 117);
            this.txtCodigo.Multiline = true;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(316, 20);
            this.txtCodigo.TabIndex = 8;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(13, 99);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(49, 15);
            this.lblCodigo.TabIndex = 13;
            this.lblCodigo.Text = "Código:";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(13, 145);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(59, 15);
            this.lblProducto.TabIndex = 15;
            this.lblProducto.Text = "Producto:";
            // 
            // txtProducto
            // 
            this.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProducto.Location = new System.Drawing.Point(16, 163);
            this.txtProducto.Multiline = true;
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(316, 20);
            this.txtProducto.TabIndex = 14;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(13, 192);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(61, 15);
            this.lblCategoria.TabIndex = 17;
            this.lblCategoria.Text = "Categoría:";
            // 
            // lblUnidadBase
            // 
            this.lblUnidadBase.AutoSize = true;
            this.lblUnidadBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUnidadBase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidadBase.Location = new System.Drawing.Point(13, 240);
            this.lblUnidadBase.Name = "lblUnidadBase";
            this.lblUnidadBase.Size = new System.Drawing.Size(75, 15);
            this.lblUnidadBase.TabIndex = 19;
            this.lblUnidadBase.Text = "Unidad Base:";
            // 
            // cmbUnidadBase
            // 
            this.cmbUnidadBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidadBase.FormattingEnabled = true;
            this.cmbUnidadBase.Location = new System.Drawing.Point(16, 258);
            this.cmbUnidadBase.Name = "cmbUnidadBase";
            this.cmbUnidadBase.Size = new System.Drawing.Size(167, 21);
            this.cmbUnidadBase.TabIndex = 18;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProveedor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(13, 289);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(64, 15);
            this.lblProveedor.TabIndex = 21;
            this.lblProveedor.Text = "Proveedor:";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(16, 307);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(167, 21);
            this.cmbProveedor.TabIndex = 20;
            // 
            // lblImagen
            // 
            this.lblImagen.AutoSize = true;
            this.lblImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblImagen.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImagen.Location = new System.Drawing.Point(366, 60);
            this.lblImagen.Name = "lblImagen";
            this.lblImagen.Size = new System.Drawing.Size(185, 20);
            this.lblImagen.TabIndex = 22;
            this.lblImagen.Text = "IMAGEN DEL PRODUCTO";
            // 
            // pbImagenProducto
            // 
            this.pbImagenProducto.Location = new System.Drawing.Point(369, 117);
            this.pbImagenProducto.Name = "pbImagenProducto";
            this.pbImagenProducto.Size = new System.Drawing.Size(200, 200);
            this.pbImagenProducto.TabIndex = 23;
            this.pbImagenProducto.TabStop = false;
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.White;
            this.btnQuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.btnQuitar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnQuitar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnQuitar.Location = new System.Drawing.Point(575, 150);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(71, 23);
            this.btnQuitar.TabIndex = 24;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = false;
            // 
            // lblPresentacionyPrecio
            // 
            this.lblPresentacionyPrecio.AutoSize = true;
            this.lblPresentacionyPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPresentacionyPrecio.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresentacionyPrecio.Location = new System.Drawing.Point(13, 365);
            this.lblPresentacionyPrecio.Name = "lblPresentacionyPrecio";
            this.lblPresentacionyPrecio.Size = new System.Drawing.Size(189, 20);
            this.lblPresentacionyPrecio.TabIndex = 25;
            this.lblPresentacionyPrecio.Text = "PRESENTACIÓN Y PRECIO";
            // 
            // lblPresentacion
            // 
            this.lblPresentacion.AutoSize = true;
            this.lblPresentacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPresentacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresentacion.Location = new System.Drawing.Point(13, 409);
            this.lblPresentacion.Name = "lblPresentacion";
            this.lblPresentacion.Size = new System.Drawing.Size(78, 15);
            this.lblPresentacion.TabIndex = 26;
            this.lblPresentacion.Text = "Presentación:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(433, 409);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(57, 15);
            this.lblPrecio.TabIndex = 27;
            this.lblPrecio.Text = "Precio S/:";
            // 
            // cmbPresentacion
            // 
            this.cmbPresentacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPresentacion.FormattingEnabled = true;
            this.cmbPresentacion.Items.AddRange(new object[] {
            "Saco",
            "Bolsa",
            "Frasco",
            "Granel",
            "Unidad"});
            this.cmbPresentacion.Location = new System.Drawing.Point(16, 427);
            this.cmbPresentacion.Name = "cmbPresentacion";
            this.cmbPresentacion.Size = new System.Drawing.Size(132, 21);
            this.cmbPresentacion.TabIndex = 28;
            // 
            // txtPrecio
            // 
            this.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecio.Location = new System.Drawing.Point(436, 428);
            this.txtPrecio.Multiline = true;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(88, 20);
            this.txtPrecio.TabIndex = 29;
            // 
            // dgvPresentaciones
            // 
            this.dgvPresentaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPresentaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPresentaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPresentacion,
            this.colCantidad,
            this.colUnidadBase,
            this.colCosto,
            this.colPrecio,
            this.colGanancia,
            this.colIGVPres,
            this.colEliminar});
            this.dgvPresentaciones.Location = new System.Drawing.Point(16, 494);
            this.dgvPresentaciones.Name = "dgvPresentaciones";
            this.dgvPresentaciones.RowHeadersVisible = false;
            this.dgvPresentaciones.Size = new System.Drawing.Size(654, 123);
            this.dgvPresentaciones.TabIndex = 30;
            // 
            // colPresentacion
            // 
            this.colPresentacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPresentacion.HeaderText = "Presentación";
            this.colPresentacion.Name = "colPresentacion";
            this.colPresentacion.ReadOnly = true;
            // 
            // colCantidad
            // 
            this.colCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            // 
            // colUnidadBase
            // 
            this.colUnidadBase.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUnidadBase.HeaderText = "Unidad Base";
            this.colUnidadBase.Name = "colUnidadBase";
            this.colUnidadBase.ReadOnly = true;
            // 
            // colCosto
            // 
            this.colCosto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCosto.HeaderText = "Costo Base S/";
            this.colCosto.Name = "colCosto";
            this.colCosto.ReadOnly = true;
            // 
            // colPrecio
            // 
            this.colPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPrecio.HeaderText = "Precio S/";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            // 
            // colGanancia
            // 
            this.colGanancia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGanancia.HeaderText = "Ganancia %";
            this.colGanancia.Name = "colGanancia";
            this.colGanancia.ReadOnly = true;
            // 
            // colEliminar
            // 
            this.colEliminar.HeaderText = "";
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.ReadOnly = true;
            this.colEliminar.Width = 25;
            // 
            // txtStockMinimo
            // 
            this.txtStockMinimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStockMinimo.Location = new System.Drawing.Point(282, 263);
            this.txtStockMinimo.Multiline = true;
            this.txtStockMinimo.Name = "txtStockMinimo";
            this.txtStockMinimo.Size = new System.Drawing.Size(50, 20);
            this.txtStockMinimo.TabIndex = 32;
            // 
            // lblStockMinimo
            // 
            this.lblStockMinimo.AutoSize = true;
            this.lblStockMinimo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStockMinimo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockMinimo.Location = new System.Drawing.Point(189, 264);
            this.lblStockMinimo.Name = "lblStockMinimo";
            this.lblStockMinimo.Size = new System.Drawing.Size(84, 15);
            this.lblStockMinimo.TabIndex = 31;
            this.lblStockMinimo.Text = "Stock Mínimo:";
            // 
            // txtStockMaximo
            // 
            this.txtStockMaximo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStockMaximo.Location = new System.Drawing.Point(282, 311);
            this.txtStockMaximo.Multiline = true;
            this.txtStockMaximo.Name = "txtStockMaximo";
            this.txtStockMaximo.Size = new System.Drawing.Size(50, 20);
            this.txtStockMaximo.TabIndex = 35;
            // 
            // lblStockMaximo
            // 
            this.lblStockMaximo.AutoSize = true;
            this.lblStockMaximo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStockMaximo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockMaximo.Location = new System.Drawing.Point(189, 312);
            this.lblStockMaximo.Name = "lblStockMaximo";
            this.lblStockMaximo.Size = new System.Drawing.Size(86, 15);
            this.lblStockMaximo.TabIndex = 34;
            this.lblStockMaximo.Text = "Stock Máximo:";
            // 
            // txtCostoBase
            // 
            this.txtCostoBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCostoBase.Location = new System.Drawing.Point(307, 427);
            this.txtCostoBase.Multiline = true;
            this.txtCostoBase.Name = "txtCostoBase";
            this.txtCostoBase.Size = new System.Drawing.Size(88, 20);
            this.txtCostoBase.TabIndex = 37;
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCosto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosto.Location = new System.Drawing.Point(304, 408);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(82, 15);
            this.lblCosto.TabIndex = 36;
            this.lblCosto.Text = "Costo Base S/:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(220)))), ((int)(((byte)(0)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnGuardar.Location = new System.Drawing.Point(204, 635);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(128, 38);
            this.btnGuardar.TabIndex = 38;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(45)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(358, 635);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(128, 38);
            this.btnCancelar.TabIndex = 39;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // txtStock
            // 
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStock.Location = new System.Drawing.Point(282, 211);
            this.txtStock.Multiline = true;
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(50, 20);
            this.txtStock.TabIndex = 41;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(233, 212);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(39, 15);
            this.lblStock.TabIndex = 40;
            this.lblStock.Text = "Stock:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Location = new System.Drawing.Point(192, 427);
            this.txtCantidad.Multiline = true;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(72, 20);
            this.txtCantidad.TabIndex = 43;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(189, 408);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(58, 15);
            this.lblCantidad.TabIndex = 42;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // btnAgregarPres
            // 
            this.btnAgregarPres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.btnAgregarPres.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarPres.FlatAppearance.BorderSize = 0;
            this.btnAgregarPres.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(220)))), ((int)(((byte)(0)))));
            this.btnAgregarPres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPres.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAgregarPres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnAgregarPres.Location = new System.Drawing.Point(575, 424);
            this.btnAgregarPres.Name = "btnAgregarPres";
            this.btnAgregarPres.Size = new System.Drawing.Size(95, 23);
            this.btnAgregarPres.TabIndex = 44;
            this.btnAgregarPres.Text = "Agregar";
            this.btnAgregarPres.UseVisualStyleBackColor = false;
            //
            // chkPrecioIncluyeIGV
            //
            this.chkPrecioIncluyeIGV.AutoSize = true;
            this.chkPrecioIncluyeIGV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkPrecioIncluyeIGV.Location = new System.Drawing.Point(436, 453);
            this.chkPrecioIncluyeIGV.Name = "chkPrecioIncluyeIGV";
            this.chkPrecioIncluyeIGV.Size = new System.Drawing.Size(120, 19);
            this.chkPrecioIncluyeIGV.TabIndex = 45;
            this.chkPrecioIncluyeIGV.Text = "Precio incluye IGV";
            //
            // colIGVPres
            //
            this.colIGVPres.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colIGVPres.HeaderText = "IGV inc.";
            this.colIGVPres.Name = "colIGVPres";
            this.colIGVPres.ReadOnly = true;
            this.colIGVPres.Width = 55;
            //
            // FormProductoDetalle
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(684, 685);
            this.Controls.Add(this.chkPrecioIncluyeIGV);
            this.Controls.Add(this.btnAgregarPres);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtCostoBase);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.txtStockMaximo);
            this.Controls.Add(this.lblStockMaximo);
            this.Controls.Add(this.txtStockMinimo);
            this.Controls.Add(this.lblStockMinimo);
            this.Controls.Add(this.dgvPresentaciones);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.cmbPresentacion);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblPresentacion);
            this.Controls.Add(this.lblPresentacionyPrecio);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.pbImagenProducto);
            this.Controls.Add(this.lblImagen);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.cmbProveedor);
            this.Controls.Add(this.lblUnidadBase);
            this.Controls.Add(this.cmbUnidadBase);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lblInformacion);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtCodigo);
            this.Name = "FormProductoDetalle";
            this.Text = "FormProductoDetalle";
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresentaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInformacion;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblUnidadBase;
        private System.Windows.Forms.ComboBox cmbUnidadBase;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label lblImagen;
        private System.Windows.Forms.PictureBox pbImagenProducto;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label lblPresentacionyPrecio;
        private System.Windows.Forms.Label lblPresentacion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.ComboBox cmbPresentacion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.DataGridView dgvPresentaciones;
        private System.Windows.Forms.TextBox txtStockMinimo;
        private System.Windows.Forms.Label lblStockMinimo;
        private System.Windows.Forms.TextBox txtStockMaximo;
        private System.Windows.Forms.Label lblStockMaximo;
        private System.Windows.Forms.TextBox txtCostoBase;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidadBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGanancia;
        private System.Windows.Forms.DataGridViewImageColumn colEliminar;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnAgregarPres;
        private System.Windows.Forms.CheckBox chkPrecioIncluyeIGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIGVPres;
    }
}