namespace SistemaPOS.Forms.Ventas
{
    partial class FormVentas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlProductos = new System.Windows.Forms.Panel();
            this.flpCardsProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlListaProductos = new System.Windows.Forms.Panel();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImagen = new System.Windows.Forms.DataGridViewImageColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPresentacion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPrecioUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlVistaToggle = new System.Windows.Forms.Panel();
            this.btnVistaLista = new System.Windows.Forms.Button();
            this.btnVistaCards = new System.Windows.Forms.Button();
            this.lblResultados = new System.Windows.Forms.Label();
            this.pnlCategorias = new System.Windows.Forms.Panel();
            this.flpCategorias = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscarIcon = new System.Windows.Forms.Label();
            this.pnlCarrito = new System.Windows.Forms.Panel();
            this.dgvCarritoVenta = new System.Windows.Forms.DataGridView();
            this.colProductoDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPresentacionDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantPres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisminuir = new System.Windows.Forms.DataGridViewImageColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAumentar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colTotalDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnPreviewVenta = new System.Windows.Forms.Button();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.lblSepTotal = new System.Windows.Forms.Label();
            this.txtIGV = new System.Windows.Forms.TextBox();
            this.lblIGV = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.cboIGV = new System.Windows.Forms.ComboBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblCarritoTitulo = new System.Windows.Forms.Label();
            this.pnlDetalleCliente = new System.Windows.Forms.Panel();
            this.cmbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblClienteHeader = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.tblMain.SuspendLayout();
            this.pnlProductos.SuspendLayout();
            this.pnlListaProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.pnlVistaToggle.SuspendLayout();
            this.pnlCategorias.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
            this.pnlCarrito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarritoVenta)).BeginInit();
            this.pnlResumen.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.pnlDetalleCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnHistorial);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(18, 0, 18, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1300, 56);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnHistorial
            // 
            this.btnHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorial.BackColor = System.Drawing.Color.White;
            this.btnHistorial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorial.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnHistorial.Location = new System.Drawing.Point(1152, 10);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(130, 36);
            this.btnHistorial.TabIndex = 0;
            this.btnHistorial.Text = "📋  Historial";
            this.btnHistorial.UseVisualStyleBackColor = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblTitulo.Location = new System.Drawing.Point(18, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(182, 25);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "🛒  Punto de Venta";
            // 
            // tblMain
            // 
            this.tblMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 480F));
            this.tblMain.Controls.Add(this.pnlProductos, 0, 0);
            this.tblMain.Controls.Add(this.pnlCarrito, 1, 0);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 56);
            this.tblMain.Name = "tblMain";
            this.tblMain.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.tblMain.RowCount = 1;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Size = new System.Drawing.Size(1300, 784);
            this.tblMain.TabIndex = 1;
            // 
            // pnlProductos
            // 
            this.pnlProductos.BackColor = System.Drawing.Color.White;
            this.pnlProductos.Controls.Add(this.flpCardsProductos);
            this.pnlProductos.Controls.Add(this.pnlListaProductos);
            this.pnlProductos.Controls.Add(this.pnlVistaToggle);
            this.pnlProductos.Controls.Add(this.pnlCategorias);
            this.pnlProductos.Controls.Add(this.pnlBusqueda);
            this.pnlProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProductos.Location = new System.Drawing.Point(10, 8);
            this.pnlProductos.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlProductos.Name = "pnlProductos";
            this.pnlProductos.Size = new System.Drawing.Size(794, 766);
            this.pnlProductos.TabIndex = 0;
            // 
            // flpCardsProductos
            // 
            this.flpCardsProductos.AutoScroll = true;
            this.flpCardsProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.flpCardsProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCardsProductos.Location = new System.Drawing.Point(0, 138);
            this.flpCardsProductos.Name = "flpCardsProductos";
            this.flpCardsProductos.Padding = new System.Windows.Forms.Padding(8, 8, 0, 8);
            this.flpCardsProductos.Size = new System.Drawing.Size(794, 628);
            this.flpCardsProductos.TabIndex = 4;
            // 
            // pnlListaProductos
            // 
            this.pnlListaProductos.BackColor = System.Drawing.Color.White;
            this.pnlListaProductos.Controls.Add(this.dgvProductos);
            this.pnlListaProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListaProductos.Location = new System.Drawing.Point(0, 138);
            this.pnlListaProductos.Name = "pnlListaProductos";
            this.pnlListaProductos.Size = new System.Drawing.Size(794, 628);
            this.pnlListaProductos.TabIndex = 3;
            this.pnlListaProductos.Visible = false;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumero,
            this.colImagen,
            this.colProducto,
            this.colPresentacion,
            this.colPrecioUnit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgvProductos.Location = new System.Drawing.Point(0, 0);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowTemplate.Height = 52;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(794, 628);
            this.dgvProductos.TabIndex = 0;
            // 
            // colNumero
            // 
            this.colNumero.HeaderText = "#";
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            this.colNumero.Width = 36;
            // 
            // colImagen
            // 
            this.colImagen.HeaderText = "";
            this.colImagen.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colImagen.Name = "colImagen";
            this.colImagen.ReadOnly = true;
            this.colImagen.Width = 56;
            // 
            // colProducto
            // 
            this.colProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.ReadOnly = true;
            // 
            // colPresentacion
            // 
            this.colPresentacion.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colPresentacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colPresentacion.HeaderText = "Presentación";
            this.colPresentacion.Name = "colPresentacion";
            this.colPresentacion.Width = 230;
            // 
            // colPrecioUnit
            // 
            this.colPrecioUnit.HeaderText = "Precio";
            this.colPrecioUnit.Name = "colPrecioUnit";
            this.colPrecioUnit.ReadOnly = true;
            this.colPrecioUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPrecioUnit.Width = 110;
            // 
            // pnlVistaToggle
            // 
            this.pnlVistaToggle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlVistaToggle.Controls.Add(this.btnVistaLista);
            this.pnlVistaToggle.Controls.Add(this.btnVistaCards);
            this.pnlVistaToggle.Controls.Add(this.lblResultados);
            this.pnlVistaToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlVistaToggle.Location = new System.Drawing.Point(0, 102);
            this.pnlVistaToggle.Name = "pnlVistaToggle";
            this.pnlVistaToggle.Padding = new System.Windows.Forms.Padding(12, 4, 8, 4);
            this.pnlVistaToggle.Size = new System.Drawing.Size(794, 36);
            this.pnlVistaToggle.TabIndex = 2;
            // 
            // btnVistaLista
            // 
            this.btnVistaLista.BackColor = System.Drawing.Color.White;
            this.btnVistaLista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVistaLista.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnVistaLista.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnVistaLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVistaLista.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVistaLista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnVistaLista.Location = new System.Drawing.Point(718, 4);
            this.btnVistaLista.Name = "btnVistaLista";
            this.btnVistaLista.Size = new System.Drawing.Size(34, 28);
            this.btnVistaLista.TabIndex = 2;
            this.btnVistaLista.Text = "☰";
            this.btnVistaLista.UseVisualStyleBackColor = false;
            // 
            // btnVistaCards
            // 
            this.btnVistaCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.btnVistaCards.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVistaCards.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnVistaCards.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.btnVistaCards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVistaCards.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVistaCards.ForeColor = System.Drawing.Color.White;
            this.btnVistaCards.Location = new System.Drawing.Point(752, 4);
            this.btnVistaCards.Name = "btnVistaCards";
            this.btnVistaCards.Size = new System.Drawing.Size(34, 28);
            this.btnVistaCards.TabIndex = 1;
            this.btnVistaCards.Text = "⊞";
            this.btnVistaCards.UseVisualStyleBackColor = false;
            // 
            // lblResultados
            // 
            this.lblResultados.AutoSize = true;
            this.lblResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResultados.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblResultados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblResultados.Location = new System.Drawing.Point(12, 4);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(113, 15);
            this.lblResultados.TabIndex = 3;
            this.lblResultados.Text = "Todos los productos";
            this.lblResultados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCategorias
            // 
            this.pnlCategorias.BackColor = System.Drawing.Color.White;
            this.pnlCategorias.Controls.Add(this.flpCategorias);
            this.pnlCategorias.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCategorias.Location = new System.Drawing.Point(0, 56);
            this.pnlCategorias.Name = "pnlCategorias";
            this.pnlCategorias.Padding = new System.Windows.Forms.Padding(12, 4, 12, 4);
            this.pnlCategorias.Size = new System.Drawing.Size(794, 46);
            this.pnlCategorias.TabIndex = 1;
            // 
            // flpCategorias
            // 
            this.flpCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCategorias.Location = new System.Drawing.Point(12, 4);
            this.flpCategorias.Name = "flpCategorias";
            this.flpCategorias.Size = new System.Drawing.Size(770, 38);
            this.flpCategorias.TabIndex = 0;
            this.flpCategorias.WrapContents = false;
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.BackColor = System.Drawing.Color.White;
            this.pnlBusqueda.Controls.Add(this.txtBuscar);
            this.pnlBusqueda.Controls.Add(this.lblBuscarIcon);
            this.pnlBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBusqueda.Location = new System.Drawing.Point(0, 0);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Padding = new System.Windows.Forms.Padding(12, 10, 12, 8);
            this.pnlBusqueda.Size = new System.Drawing.Size(794, 56);
            this.pnlBusqueda.TabIndex = 0;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.txtBuscar.Location = new System.Drawing.Point(46, 10);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(736, 20);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.Text = "Buscar productos...";
            // 
            // lblBuscarIcon
            // 
            this.lblBuscarIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblBuscarIcon.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblBuscarIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lblBuscarIcon.Location = new System.Drawing.Point(12, 10);
            this.lblBuscarIcon.Name = "lblBuscarIcon";
            this.lblBuscarIcon.Size = new System.Drawing.Size(34, 38);
            this.lblBuscarIcon.TabIndex = 1;
            this.lblBuscarIcon.Text = "🔍";
            this.lblBuscarIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCarrito
            // 
            this.pnlCarrito.BackColor = System.Drawing.Color.White;
            this.pnlCarrito.Controls.Add(this.dgvCarritoVenta);
            this.pnlCarrito.Controls.Add(this.pnlResumen);
            this.pnlCarrito.Controls.Add(this.lblCarritoTitulo);
            this.pnlCarrito.Controls.Add(this.pnlDetalleCliente);
            this.pnlCarrito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCarrito.Location = new System.Drawing.Point(816, 8);
            this.pnlCarrito.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.pnlCarrito.Name = "pnlCarrito";
            this.pnlCarrito.Size = new System.Drawing.Size(474, 766);
            this.pnlCarrito.TabIndex = 1;
            // 
            // dgvCarritoVenta
            // 
            this.dgvCarritoVenta.AllowUserToAddRows = false;
            this.dgvCarritoVenta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCarritoVenta.BackgroundColor = System.Drawing.Color.White;
            this.dgvCarritoVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCarritoVenta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCarritoVenta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCarritoVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCarritoVenta.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCarritoVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarritoVenta.EnableHeadersVisualStyles = false;
            this.dgvCarritoVenta.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgvCarritoVenta.Location = new System.Drawing.Point(0, 146);
            this.dgvCarritoVenta.Name = "dgvCarritoVenta";
            this.dgvCarritoVenta.RowHeadersVisible = false;
            this.dgvCarritoVenta.RowTemplate.Height = 54;
            this.dgvCarritoVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCarritoVenta.Size = new System.Drawing.Size(474, 392);
            this.dgvCarritoVenta.TabIndex = 2;
            // 
            // colProductoDV
            // 
            this.colProductoDV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProductoDV.HeaderText = "Producto";
            this.colProductoDV.Name = "colProductoDV";
            this.colProductoDV.ReadOnly = true;
            // 
            // colPresentacionDV
            // 
            this.colPresentacionDV.HeaderText = "Pres.";
            this.colPresentacionDV.Name = "colPresentacionDV";
            this.colPresentacionDV.ReadOnly = true;
            this.colPresentacionDV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPresentacionDV.Width = 60;
            // 
            // colCantPres
            // 
            this.colCantPres.HeaderText = "Ref.";
            this.colCantPres.Name = "colCantPres";
            this.colCantPres.ReadOnly = true;
            this.colCantPres.Width = 50;
            // 
            // colDisminuir
            // 
            this.colDisminuir.HeaderText = "";
            this.colDisminuir.Name = "colDisminuir";
            this.colDisminuir.ReadOnly = true;
            this.colDisminuir.Width = 24;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cant.";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Width = 56;
            // 
            // colAumentar
            // 
            this.colAumentar.HeaderText = "";
            this.colAumentar.Name = "colAumentar";
            this.colAumentar.ReadOnly = true;
            this.colAumentar.Width = 24;
            // 
            // colTotalDV
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTotalDV.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTotalDV.HeaderText = "Total";
            this.colTotalDV.Name = "colTotalDV";
            this.colTotalDV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTotalDV.Width = 70;
            // 
            // colEliminar
            // 
            this.colEliminar.HeaderText = "";
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.Width = 24;
            // 
            // pnlResumen
            // 
            this.pnlResumen.BackColor = System.Drawing.Color.White;
            this.pnlResumen.Controls.Add(this.pnlAcciones);
            this.pnlResumen.Controls.Add(this.txtTotalPagar);
            this.pnlResumen.Controls.Add(this.lblTotalPagar);
            this.pnlResumen.Controls.Add(this.lblSepTotal);
            this.pnlResumen.Controls.Add(this.txtIGV);
            this.pnlResumen.Controls.Add(this.lblIGV);
            this.pnlResumen.Controls.Add(this.txtDescuento);
            this.pnlResumen.Controls.Add(this.lblDescuento);
            this.pnlResumen.Controls.Add(this.cboIGV);
            this.pnlResumen.Controls.Add(this.txtSubtotal);
            this.pnlResumen.Controls.Add(this.lblSubTotal);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumen.Location = new System.Drawing.Point(0, 538);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(474, 228);
            this.pnlResumen.TabIndex = 3;
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.BackColor = System.Drawing.Color.White;
            this.pnlAcciones.Controls.Add(this.btnCobrar);
            this.pnlAcciones.Controls.Add(this.btnCancelar);
            this.pnlAcciones.Controls.Add(this.btnPreviewVenta);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAcciones.Location = new System.Drawing.Point(0, 162);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Padding = new System.Windows.Forms.Padding(10);
            this.pnlAcciones.Size = new System.Drawing.Size(474, 66);
            this.pnlAcciones.TabIndex = 5;
            // 
            // btnCobrar
            // 
            this.btnCobrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.btnCobrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCobrar.FlatAppearance.BorderSize = 0;
            this.btnCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCobrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCobrar.ForeColor = System.Drawing.Color.White;
            this.btnCobrar.Location = new System.Drawing.Point(210, 10);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(192, 44);
            this.btnCobrar.TabIndex = 2;
            this.btnCobrar.Text = "$ Cobrar";
            this.btnCobrar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnCancelar.Location = new System.Drawing.Point(106, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(96, 44);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "✕ Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnPreviewVenta
            // 
            this.btnPreviewVenta.BackColor = System.Drawing.Color.White;
            this.btnPreviewVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreviewVenta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnPreviewVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviewVenta.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnPreviewVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnPreviewVenta.Location = new System.Drawing.Point(10, 10);
            this.btnPreviewVenta.Name = "btnPreviewVenta";
            this.btnPreviewVenta.Size = new System.Drawing.Size(88, 44);
            this.btnPreviewVenta.TabIndex = 0;
            this.btnPreviewVenta.Text = "👁 Preview";
            this.btnPreviewVenta.UseVisualStyleBackColor = false;
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.BackColor = System.Drawing.Color.White;
            this.txtTotalPagar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalPagar.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.txtTotalPagar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.txtTotalPagar.Location = new System.Drawing.Point(186, 100);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.ReadOnly = true;
            this.txtTotalPagar.Size = new System.Drawing.Size(276, 32);
            this.txtTotalPagar.TabIndex = 4;
            this.txtTotalPagar.Text = "0.00";
            this.txtTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalPagar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(50)))));
            this.lblTotalPagar.Location = new System.Drawing.Point(12, 110);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(131, 21);
            this.lblTotalPagar.TabIndex = 6;
            this.lblTotalPagar.Text = "TOTAL A PAGAR:";
            // 
            // lblSepTotal
            // 
            this.lblSepTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(236)))));
            this.lblSepTotal.Location = new System.Drawing.Point(12, 96);
            this.lblSepTotal.Name = "lblSepTotal";
            this.lblSepTotal.Size = new System.Drawing.Size(450, 1);
            this.lblSepTotal.TabIndex = 7;
            // 
            // txtIGV
            // 
            this.txtIGV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtIGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIGV.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtIGV.Location = new System.Drawing.Point(306, 66);
            this.txtIGV.Name = "txtIGV";
            this.txtIGV.ReadOnly = true;
            this.txtIGV.Size = new System.Drawing.Size(156, 17);
            this.txtIGV.TabIndex = 3;
            this.txtIGV.Text = "0.00";
            this.txtIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIGV
            // 
            this.lblIGV.AutoSize = true;
            this.lblIGV.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblIGV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblIGV.Location = new System.Drawing.Point(12, 69);
            this.lblIGV.Name = "lblIGV";
            this.lblIGV.Size = new System.Drawing.Size(61, 15);
            this.lblIGV.TabIndex = 8;
            this.lblIGV.Text = "IGV (18%):";
            // 
            // txtDescuento
            // 
            this.txtDescuento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescuento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDescuento.Location = new System.Drawing.Point(306, 36);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(156, 17);
            this.txtDescuento.TabIndex = 2;
            this.txtDescuento.Text = "0.00";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDescuento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblDescuento.Location = new System.Drawing.Point(12, 40);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(75, 15);
            this.lblDescuento.TabIndex = 9;
            this.lblDescuento.Text = "DESCUENTO:";
            // 
            // cboIGV
            // 
            this.cboIGV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIGV.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.cboIGV.Items.AddRange(new object[] {
            "Sin IGV",
            "IGV Incluido",
            "IGV Adicional"});
            this.cboIGV.Location = new System.Drawing.Point(150, 5);
            this.cboIGV.Name = "cboIGV";
            this.cboIGV.Size = new System.Drawing.Size(148, 21);
            this.cboIGV.TabIndex = 1;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubtotal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSubtotal.Location = new System.Drawing.Point(306, 6);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(156, 17);
            this.txtSubtotal.TabIndex = 0;
            this.txtSubtotal.Text = "0.00";
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblSubTotal.Location = new System.Drawing.Point(12, 10);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(64, 15);
            this.lblSubTotal.TabIndex = 10;
            this.lblSubTotal.Text = "BASE IMP.:";
            // 
            // lblCarritoTitulo
            // 
            this.lblCarritoTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.lblCarritoTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCarritoTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCarritoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.lblCarritoTitulo.Location = new System.Drawing.Point(0, 116);
            this.lblCarritoTitulo.Name = "lblCarritoTitulo";
            this.lblCarritoTitulo.Padding = new System.Windows.Forms.Padding(14, 6, 12, 6);
            this.lblCarritoTitulo.Size = new System.Drawing.Size(474, 30);
            this.lblCarritoTitulo.TabIndex = 1;
            this.lblCarritoTitulo.Text = "ARTÍCULOS EN EL CARRITO";
            this.lblCarritoTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDetalleCliente
            // 
            this.pnlDetalleCliente.BackColor = System.Drawing.Color.White;
            this.pnlDetalleCliente.Controls.Add(this.cmbTipoComprobante);
            this.pnlDetalleCliente.Controls.Add(this.lblTipoComprobante);
            this.pnlDetalleCliente.Controls.Add(this.btnBuscarCliente);
            this.pnlDetalleCliente.Controls.Add(this.cmbClientes);
            this.pnlDetalleCliente.Controls.Add(this.lblCliente);
            this.pnlDetalleCliente.Controls.Add(this.lblClienteHeader);
            this.pnlDetalleCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetalleCliente.Location = new System.Drawing.Point(0, 0);
            this.pnlDetalleCliente.Name = "pnlDetalleCliente";
            this.pnlDetalleCliente.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlDetalleCliente.Size = new System.Drawing.Size(474, 116);
            this.pnlDetalleCliente.TabIndex = 0;
            // 
            // cmbTipoComprobante
            // 
            this.cmbTipoComprobante.BackColor = System.Drawing.Color.White;
            this.cmbTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipoComprobante.FormattingEnabled = true;
            this.cmbTipoComprobante.Items.AddRange(new object[] {
            "BOLETA",
            "FACTURA",
            "NOTA_VENTA"});
            this.cmbTipoComprobante.Location = new System.Drawing.Point(12, 76);
            this.cmbTipoComprobante.Name = "cmbTipoComprobante";
            this.cmbTipoComprobante.Size = new System.Drawing.Size(450, 23);
            this.cmbTipoComprobante.TabIndex = 2;
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTipoComprobante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblTipoComprobante.Location = new System.Drawing.Point(12, 58);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(97, 15);
            this.lblTipoComprobante.TabIndex = 3;
            this.lblTipoComprobante.Text = "COMPROBANTE:";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.White;
            this.btnBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCliente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBuscarCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnBuscarCliente.Location = new System.Drawing.Point(426, 24);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(28, 25);
            this.btnBuscarCliente.TabIndex = 1;
            this.btnBuscarCliente.Text = "🔍";
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            // 
            // cmbClientes
            // 
            this.cmbClientes.BackColor = System.Drawing.Color.White;
            this.cmbClientes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(12, 24);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(410, 25);
            this.cmbClientes.TabIndex = 0;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblCliente.Location = new System.Drawing.Point(12, 24);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(45, 15);
            this.lblCliente.TabIndex = 6;
            this.lblCliente.Text = "Buscar:";
            this.lblCliente.Visible = false;
            // 
            // lblClienteHeader
            // 
            this.lblClienteHeader.AutoSize = true;
            this.lblClienteHeader.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblClienteHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblClienteHeader.Location = new System.Drawing.Point(12, 8);
            this.lblClienteHeader.Name = "lblClienteHeader";
            this.lblClienteHeader.Size = new System.Drawing.Size(51, 13);
            this.lblClienteHeader.TabIndex = 7;
            this.lblClienteHeader.Text = "CLIENTE:";
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1300, 840);
            this.Controls.Add(this.tblMain);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FormVentas";
            this.Text = "Punto de Venta";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tblMain.ResumeLayout(false);
            this.pnlProductos.ResumeLayout(false);
            this.pnlListaProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.pnlVistaToggle.ResumeLayout(false);
            this.pnlVistaToggle.PerformLayout();
            this.pnlCategorias.ResumeLayout(false);
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.pnlCarrito.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarritoVenta)).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.pnlAcciones.ResumeLayout(false);
            this.pnlDetalleCliente.ResumeLayout(false);
            this.pnlDetalleCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #region Fields
        private System.Windows.Forms.Panel            pnlHeader;
        private System.Windows.Forms.Label            lblTitulo;
        private System.Windows.Forms.Button           btnHistorial;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        // productos
        private System.Windows.Forms.Panel            pnlProductos;
        private System.Windows.Forms.Panel            pnlBusqueda;
        private System.Windows.Forms.Label            lblBuscarIcon;
        private System.Windows.Forms.TextBox          txtBuscar;
        private System.Windows.Forms.Panel            pnlCategorias;
        private System.Windows.Forms.FlowLayoutPanel  flpCategorias;
        private System.Windows.Forms.Panel            pnlVistaToggle;
        private System.Windows.Forms.Label            lblResultados;
        private System.Windows.Forms.Button           btnVistaCards;
        private System.Windows.Forms.Button           btnVistaLista;
        private System.Windows.Forms.Panel            pnlListaProductos;
        private System.Windows.Forms.DataGridView     dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn   colNumero;
        private System.Windows.Forms.DataGridViewImageColumn     colImagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn   colProducto;
        private System.Windows.Forms.DataGridViewComboBoxColumn  colPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn   colPrecioUnit;
        private System.Windows.Forms.FlowLayoutPanel  flpCardsProductos;
        // carrito
        private System.Windows.Forms.Panel            pnlCarrito;
        private System.Windows.Forms.Panel            pnlDetalleCliente;
        private System.Windows.Forms.Label            lblClienteHeader;
        private System.Windows.Forms.Label            lblCliente;
        private System.Windows.Forms.ComboBox         cmbClientes;
        private System.Windows.Forms.Button           btnBuscarCliente;
        private System.Windows.Forms.Label            lblTipoComprobante;
        private System.Windows.Forms.ComboBox         cmbTipoComprobante;
        private System.Windows.Forms.Label            lblCarritoTitulo;
        private System.Windows.Forms.DataGridView     dgvCarritoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn   colProductoDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn   colPresentacionDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn   colCantPres;
        private System.Windows.Forms.DataGridViewImageColumn     colDisminuir;
        private System.Windows.Forms.DataGridViewTextBoxColumn   colCantidad;
        private System.Windows.Forms.DataGridViewImageColumn     colAumentar;
        private System.Windows.Forms.DataGridViewTextBoxColumn   colTotalDV;
        private System.Windows.Forms.DataGridViewImageColumn     colEliminar;
        private System.Windows.Forms.Panel            pnlResumen;
        private System.Windows.Forms.Label            lblSubTotal;
        private System.Windows.Forms.TextBox          txtSubtotal;
        private System.Windows.Forms.ComboBox         cboIGV;
        private System.Windows.Forms.Label            lblDescuento;
        private System.Windows.Forms.TextBox          txtDescuento;
        private System.Windows.Forms.Label            lblIGV;
        private System.Windows.Forms.TextBox          txtIGV;
        private System.Windows.Forms.Label            lblSepTotal;
        private System.Windows.Forms.Label            lblTotalPagar;
        private System.Windows.Forms.TextBox          txtTotalPagar;
        private System.Windows.Forms.Panel            pnlAcciones;
        private System.Windows.Forms.Button           btnPreviewVenta;
        private System.Windows.Forms.Button           btnCancelar;
        private System.Windows.Forms.Button           btnCobrar;
        #endregion
    }
}
