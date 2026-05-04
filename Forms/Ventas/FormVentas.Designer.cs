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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlProductosHeader = new System.Windows.Forms.Panel();
            this.lblProductosHeaderTitle = new System.Windows.Forms.Label();
            this.pnlClienteHeader = new System.Windows.Forms.Panel();
            this.pnlResumenHeader = new System.Windows.Forms.Panel();
            this.lblResumenHeaderTitle = new System.Windows.Forms.Label();
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
            this.lblResultados = new System.Windows.Forms.Label();
            this.btnVistaCards = new System.Windows.Forms.Button();
            this.btnVistaLista = new System.Windows.Forms.Button();
            this.pnlCategorias = new System.Windows.Forms.Panel();
            this.flpCategorias = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscarIcon = new System.Windows.Forms.Label();
            this.pnlCarrito = new System.Windows.Forms.Panel();
            this.pnlScrollCarrito = new System.Windows.Forms.Panel();
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
            this.pnlProductosHeader.SuspendLayout();
            this.pnlClienteHeader.SuspendLayout();
            this.pnlResumenHeader.SuspendLayout();
            this.pnlProductos.SuspendLayout();
            this.pnlListaProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.pnlVistaToggle.SuspendLayout();
            this.pnlCategorias.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
            this.pnlCarrito.SuspendLayout();
            this.pnlResumen.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.pnlDetalleCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlHeader.Controls.Add(this.btnHistorial);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(18, 0, 18, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1300, 68);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnHistorial
            // 
            this.btnHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(68)))), ((int)(((byte)(70)))));
            this.btnHistorial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorial.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(100)))), ((int)(((byte)(102)))));
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnHistorial.ForeColor = System.Drawing.Color.White;
            this.btnHistorial.Location = new System.Drawing.Point(1137, 17);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnHistorial.Size = new System.Drawing.Size(145, 34);
            this.btnHistorial.TabIndex = 0;
            this.btnHistorial.Text = "📋  Historial";
            this.btnHistorial.UseVisualStyleBackColor = false;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(20, 40);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(127, 15);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Registra ventas rápidas";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(18, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(340, 28);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "🛒  Punto de Venta";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tblMain
            // 
            this.tblMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 480F));
            this.tblMain.Controls.Add(this.pnlProductos, 0, 0);
            this.tblMain.Controls.Add(this.pnlCarrito, 1, 0);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 68);
            this.tblMain.Name = "tblMain";
            this.tblMain.Padding = new System.Windows.Forms.Padding(25, 24, 25, 26);
            this.tblMain.RowCount = 1;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Size = new System.Drawing.Size(1300, 772);
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
            this.pnlProductos.Controls.Add(this.pnlProductosHeader);
            this.pnlProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProductos.Location = new System.Drawing.Point(10, 8);
            this.pnlProductos.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlProductos.Name = "pnlProductos";
            this.pnlProductos.Size = new System.Drawing.Size(794, 754);
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
            this.flpCardsProductos.Size = new System.Drawing.Size(794, 616);
            this.flpCardsProductos.TabIndex = 4;
            // 
            // pnlListaProductos
            // 
            this.pnlListaProductos.BackColor = System.Drawing.Color.White;
            this.pnlListaProductos.Controls.Add(this.dgvProductos);
            this.pnlListaProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListaProductos.Location = new System.Drawing.Point(0, 138);
            this.pnlListaProductos.Name = "pnlListaProductos";
            this.pnlListaProductos.Size = new System.Drawing.Size(794, 616);
            this.pnlListaProductos.TabIndex = 3;
            this.pnlListaProductos.Visible = false;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvProductos.ColumnHeadersHeight = 36;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumero,
            this.colImagen,
            this.colProducto,
            this.colPresentacion,
            this.colPrecioUnit});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgvProductos.Location = new System.Drawing.Point(0, 0);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowTemplate.Height = 40;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(794, 616);
            this.dgvProductos.TabIndex = 0;
            // 
            // colNumero
            // 
            this.colNumero.HeaderText = "#";
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            this.colNumero.Width = 55;
            //
            // colImagen
            //
            this.colImagen.HeaderText = "";
            this.colImagen.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colImagen.Name = "colImagen";
            this.colImagen.ReadOnly = true;
            this.colImagen.Width = 75;
            //
            // colProducto
            //
            this.colProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProducto.MinimumWidth = 180;
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
            this.colPresentacion.Width = 290;
            //
            // colPrecioUnit
            //
            this.colPrecioUnit.HeaderText = "Precio";
            this.colPrecioUnit.Name = "colPrecioUnit";
            this.colPrecioUnit.ReadOnly = true;
            this.colPrecioUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPrecioUnit.Width = 140;
            // 
            // pnlVistaToggle
            // 
            this.pnlVistaToggle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlVistaToggle.Controls.Add(this.lblResultados);
            this.pnlVistaToggle.Controls.Add(this.btnVistaCards);
            this.pnlVistaToggle.Controls.Add(this.btnVistaLista);
            this.pnlVistaToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlVistaToggle.Location = new System.Drawing.Point(0, 102);
            this.pnlVistaToggle.Name = "pnlVistaToggle";
            this.pnlVistaToggle.Padding = new System.Windows.Forms.Padding(12, 4, 8, 4);
            this.pnlVistaToggle.Size = new System.Drawing.Size(794, 36);
            this.pnlVistaToggle.TabIndex = 2;
            // 
            // lblResultados
            // 
            this.lblResultados.AutoSize = true;
            this.lblResultados.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblResultados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblResultados.Location = new System.Drawing.Point(12, 9);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(113, 15);
            this.lblResultados.TabIndex = 3;
            this.lblResultados.Text = "Todos los productos";
            this.lblResultados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnVistaCards
            // 
            this.btnVistaCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.btnVistaCards.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnVistaCards.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.btnVistaCards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVistaCards.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVistaCards.ForeColor = System.Drawing.Color.White;
            this.btnVistaCards.Location = new System.Drawing.Point(718, 4);
            this.btnVistaCards.Name = "btnVistaCards";
            this.btnVistaCards.Size = new System.Drawing.Size(34, 28);
            this.btnVistaCards.TabIndex = 1;
            this.btnVistaCards.Text = "⊞";
            this.btnVistaCards.UseVisualStyleBackColor = false;
            // 
            // btnVistaLista
            // 
            this.btnVistaLista.BackColor = System.Drawing.Color.White;
            this.btnVistaLista.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnVistaLista.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnVistaLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVistaLista.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVistaLista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnVistaLista.Location = new System.Drawing.Point(752, 4);
            this.btnVistaLista.Name = "btnVistaLista";
            this.btnVistaLista.Size = new System.Drawing.Size(34, 28);
            this.btnVistaLista.TabIndex = 2;
            this.btnVistaLista.Text = "☰";
            this.btnVistaLista.UseVisualStyleBackColor = false;
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
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.txtBuscar.Location = new System.Drawing.Point(46, 19);
            this.txtBuscar.Multiline = true;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(736, 24);
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
            this.lblBuscarIcon.Size = new System.Drawing.Size(28, 38);
            this.lblBuscarIcon.TabIndex = 1;
            this.lblBuscarIcon.Text = "🔍";
            this.lblBuscarIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // pnlProductosHeader
            //
            this.pnlProductosHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlProductosHeader.Controls.Add(this.lblProductosHeaderTitle);
            this.pnlProductosHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProductosHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlProductosHeader.Name = "pnlProductosHeader";
            this.pnlProductosHeader.Size = new System.Drawing.Size(794, 38);
            this.pnlProductosHeader.TabIndex = 5;
            //
            // lblProductosHeaderTitle
            //
            this.lblProductosHeaderTitle.AutoSize = true;
            this.lblProductosHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblProductosHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblProductosHeaderTitle.Location = new System.Drawing.Point(14, 11);
            this.lblProductosHeaderTitle.Name = "lblProductosHeaderTitle";
            this.lblProductosHeaderTitle.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblProductosHeaderTitle.TabIndex = 0;
            this.lblProductosHeaderTitle.Text = "📦  PRODUCTOS DISPONIBLES";
            //
            // pnlCarrito
            //
            this.pnlCarrito.BackColor = System.Drawing.Color.White;
            this.pnlCarrito.Controls.Add(this.pnlScrollCarrito);
            this.pnlCarrito.Controls.Add(this.pnlResumen);
            this.pnlCarrito.Controls.Add(this.lblCarritoTitulo);
            this.pnlCarrito.Controls.Add(this.pnlDetalleCliente);
            this.pnlCarrito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCarrito.Location = new System.Drawing.Point(816, 8);
            this.pnlCarrito.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.pnlCarrito.Name = "pnlCarrito";
            this.pnlCarrito.Size = new System.Drawing.Size(474, 754);
            this.pnlCarrito.TabIndex = 1;
            // 
            // pnlScrollCarrito
            // 
            this.pnlScrollCarrito.AutoScroll = true;
            this.pnlScrollCarrito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlScrollCarrito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScrollCarrito.Location = new System.Drawing.Point(0, 146);
            this.pnlScrollCarrito.Name = "pnlScrollCarrito";
            this.pnlScrollCarrito.Size = new System.Drawing.Size(474, 413);
            this.pnlScrollCarrito.TabIndex = 2;
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
            this.pnlResumen.Controls.Add(this.pnlResumenHeader);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumen.Location = new System.Drawing.Point(0, 521);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(474, 233);
            this.pnlResumen.TabIndex = 3;
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.BackColor = System.Drawing.Color.White;
            this.pnlAcciones.Controls.Add(this.btnCobrar);
            this.pnlAcciones.Controls.Add(this.btnCancelar);
            this.pnlAcciones.Controls.Add(this.btnPreviewVenta);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAcciones.Location = new System.Drawing.Point(0, 130);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Padding = new System.Windows.Forms.Padding(8);
            this.pnlAcciones.Size = new System.Drawing.Size(474, 65);
            this.pnlAcciones.TabIndex = 5;
            // 
            // btnCobrar
            // 
            this.btnCobrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCobrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnCobrar.FlatAppearance.BorderSize = 0;
            this.btnCobrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(143)))), ((int)(((byte)(79)))));
            this.btnCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCobrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCobrar.ForeColor = System.Drawing.Color.White;
            this.btnCobrar.Location = new System.Drawing.Point(194, 8);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(272, 48);
            this.btnCobrar.TabIndex = 2;
            this.btnCobrar.Text = "✓  COBRAR";
            this.btnCobrar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnCancelar.Location = new System.Drawing.Point(96, 8);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 48);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "✕ Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnPreviewVenta
            // 
            this.btnPreviewVenta.BackColor = System.Drawing.Color.White;
            this.btnPreviewVenta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnPreviewVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviewVenta.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnPreviewVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnPreviewVenta.Location = new System.Drawing.Point(8, 8);
            this.btnPreviewVenta.Name = "btnPreviewVenta";
            this.btnPreviewVenta.Size = new System.Drawing.Size(80, 48);
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
            this.txtTotalPagar.Location = new System.Drawing.Point(196, 128);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.ReadOnly = true;
            this.txtTotalPagar.Size = new System.Drawing.Size(272, 32);
            this.txtTotalPagar.TabIndex = 4;
            this.txtTotalPagar.Text = "0.00";
            this.txtTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalPagar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(50)))));
            this.lblTotalPagar.Location = new System.Drawing.Point(12, 136);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(131, 21);
            this.lblTotalPagar.TabIndex = 6;
            this.lblTotalPagar.Text = "TOTAL A PAGAR:";
            // 
            // lblSepTotal
            // 
            this.lblSepTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(236)))));
            this.lblSepTotal.Location = new System.Drawing.Point(12, 124);
            this.lblSepTotal.Name = "lblSepTotal";
            this.lblSepTotal.Size = new System.Drawing.Size(456, 1);
            this.lblSepTotal.TabIndex = 7;
            // 
            // txtIGV
            // 
            this.txtIGV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtIGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIGV.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtIGV.Location = new System.Drawing.Point(318, 98);
            this.txtIGV.Name = "txtIGV";
            this.txtIGV.ReadOnly = true;
            this.txtIGV.Size = new System.Drawing.Size(150, 17);
            this.txtIGV.TabIndex = 3;
            this.txtIGV.Text = "0.00";
            this.txtIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIGV
            // 
            this.lblIGV.AutoSize = true;
            this.lblIGV.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblIGV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblIGV.Location = new System.Drawing.Point(12, 100);
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
            this.txtDescuento.Location = new System.Drawing.Point(318, 72);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(150, 17);
            this.txtDescuento.TabIndex = 2;
            this.txtDescuento.Text = "0.00";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDescuento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblDescuento.Location = new System.Drawing.Point(12, 74);
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
            this.cboIGV.Location = new System.Drawing.Point(150, 43);
            this.cboIGV.Name = "cboIGV";
            this.cboIGV.Size = new System.Drawing.Size(148, 21);
            this.cboIGV.TabIndex = 1;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubtotal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSubtotal.Location = new System.Drawing.Point(318, 46);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(150, 17);
            this.txtSubtotal.TabIndex = 0;
            this.txtSubtotal.Text = "0.00";
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblSubTotal.Location = new System.Drawing.Point(12, 48);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(64, 15);
            this.lblSubTotal.TabIndex = 10;
            this.lblSubTotal.Text = "BASE IMP.:";
            //
            // pnlResumenHeader
            //
            this.pnlResumenHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlResumenHeader.Controls.Add(this.lblResumenHeaderTitle);
            this.pnlResumenHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResumenHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlResumenHeader.Name = "pnlResumenHeader";
            this.pnlResumenHeader.Size = new System.Drawing.Size(474, 38);
            this.pnlResumenHeader.TabIndex = 11;
            //
            // lblResumenHeaderTitle
            //
            this.lblResumenHeaderTitle.AutoSize = true;
            this.lblResumenHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblResumenHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblResumenHeaderTitle.Location = new System.Drawing.Point(14, 11);
            this.lblResumenHeaderTitle.Name = "lblResumenHeaderTitle";
            this.lblResumenHeaderTitle.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblResumenHeaderTitle.TabIndex = 0;
            this.lblResumenHeaderTitle.Text = "📊  RESUMEN DE VENTA";
            //
            // lblCarritoTitulo
            //
            this.lblCarritoTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblCarritoTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCarritoTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCarritoTitulo.ForeColor = System.Drawing.Color.White;
            this.lblCarritoTitulo.Location = new System.Drawing.Point(0, 116);
            this.lblCarritoTitulo.Name = "lblCarritoTitulo";
            this.lblCarritoTitulo.Padding = new System.Windows.Forms.Padding(14, 0, 20, 0);
            this.lblCarritoTitulo.Size = new System.Drawing.Size(474, 38);
            this.lblCarritoTitulo.TabIndex = 1;
            this.lblCarritoTitulo.Text = "🛒  ARTÍCULOS EN EL CARRITO";
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
            this.pnlDetalleCliente.Controls.Add(this.pnlClienteHeader);
            this.pnlDetalleCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetalleCliente.Location = new System.Drawing.Point(0, 0);
            this.pnlDetalleCliente.Name = "pnlDetalleCliente";
            this.pnlDetalleCliente.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlDetalleCliente.Size = new System.Drawing.Size(474, 154);
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
            this.cmbTipoComprobante.Location = new System.Drawing.Point(12, 114);
            this.cmbTipoComprobante.Name = "cmbTipoComprobante";
            this.cmbTipoComprobante.Size = new System.Drawing.Size(448, 23);
            this.cmbTipoComprobante.TabIndex = 2;
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTipoComprobante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblTipoComprobante.Location = new System.Drawing.Point(12, 96);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(91, 13);
            this.lblTipoComprobante.TabIndex = 3;
            this.lblTipoComprobante.Text = "COMPROBANTE";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.White;
            this.btnBuscarCliente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBuscarCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnBuscarCliente.Location = new System.Drawing.Point(432, 62);
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
            this.cmbClientes.Location = new System.Drawing.Point(12, 62);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(416, 25);
            this.cmbClientes.TabIndex = 0;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblCliente.Location = new System.Drawing.Point(12, 62);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(45, 15);
            this.lblCliente.TabIndex = 6;
            this.lblCliente.Text = "Buscar:";
            this.lblCliente.Visible = false;
            //
            // pnlClienteHeader
            //
            this.pnlClienteHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlClienteHeader.Controls.Add(this.lblClienteHeader);
            this.pnlClienteHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlClienteHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlClienteHeader.Name = "pnlClienteHeader";
            this.pnlClienteHeader.Size = new System.Drawing.Size(474, 38);
            this.pnlClienteHeader.TabIndex = 8;
            //
            // lblClienteHeader
            //
            this.lblClienteHeader.AutoSize = true;
            this.lblClienteHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblClienteHeader.ForeColor = System.Drawing.Color.White;
            this.lblClienteHeader.Location = new System.Drawing.Point(14, 11);
            this.lblClienteHeader.Name = "lblClienteHeader";
            this.lblClienteHeader.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblClienteHeader.Size = new System.Drawing.Size(160, 17);
            this.lblClienteHeader.TabIndex = 7;
            this.lblClienteHeader.Text = "👤  DATOS DEL CLIENTE";
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1300, 840);
            this.Controls.Add(this.tblMain);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormVentas";
            this.Text = "Punto de Venta";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlProductosHeader.ResumeLayout(false);
            this.pnlProductosHeader.PerformLayout();
            this.pnlClienteHeader.ResumeLayout(false);
            this.pnlClienteHeader.PerformLayout();
            this.pnlResumenHeader.ResumeLayout(false);
            this.pnlResumenHeader.PerformLayout();
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
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.pnlAcciones.ResumeLayout(false);
            this.pnlDetalleCliente.ResumeLayout(false);
            this.pnlDetalleCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #region Fields
        private System.Windows.Forms.Panel            pnlHeader;
        private System.Windows.Forms.Label            lblTitulo;
        private System.Windows.Forms.Label            lblSubtitulo;
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
        // sub-headers
        private System.Windows.Forms.Panel            pnlProductosHeader;
        private System.Windows.Forms.Label            lblProductosHeaderTitle;
        private System.Windows.Forms.Panel            pnlClienteHeader;
        private System.Windows.Forms.Panel            pnlResumenHeader;
        private System.Windows.Forms.Label            lblResumenHeaderTitle;
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
        private System.Windows.Forms.Panel            pnlScrollCarrito;
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
