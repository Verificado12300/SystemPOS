namespace SistemaPOS.Forms.Ventas
{
    partial class FormHistorialVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHistorialVentas));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubTituloHeader = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.cmbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.lblSubTitulo = new System.Windows.Forms.Label();
            this.txtNumComprobante = new System.Windows.Forms.TextBox();
            this.lblNumComprobante = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.pnlListado = new System.Windows.Forms.Panel();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVerDetalle = new System.Windows.Forms.DataGridViewImageColumn();
            this.colReimprimir = new System.Windows.Forms.DataGridViewImageColumn();
            this.colAnular = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblSubTitulo3 = new System.Windows.Forms.Label();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.txtEfectivoCantidad = new System.Windows.Forms.TextBox();
            this.lblYape = new System.Windows.Forms.Label();
            this.txtYapeCantidad = new System.Windows.Forms.TextBox();
            this.lblTarjeta = new System.Windows.Forms.Label();
            this.txtTarjetaCantidad = new System.Windows.Forms.TextBox();
            this.lblTransferencia = new System.Windows.Forms.Label();
            this.txtTransferenciaCantidad = new System.Windows.Forms.TextBox();
            this.lblCredito = new System.Windows.Forms.Label();
            this.txtCreditoCantidad = new System.Windows.Forms.TextBox();
            this.lblSepVertical = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotalCantidad = new System.Windows.Forms.TextBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            this.pnlListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlHeader.Controls.Add(this.lblSubTituloHeader);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(18, 0, 18, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1184, 68);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubTituloHeader
            // 
            this.lblSubTituloHeader.AutoSize = true;
            this.lblSubTituloHeader.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTituloHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.lblSubTituloHeader.Location = new System.Drawing.Point(20, 40);
            this.lblSubTituloHeader.Name = "lblSubTituloHeader";
            this.lblSubTituloHeader.Size = new System.Drawing.Size(225, 15);
            this.lblSubTituloHeader.TabIndex = 134;
            this.lblSubTituloHeader.Text = "Consulta y gestiona las ventas registradas";
            // 
            // lblTitulo
            // 
            this.lblTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(18, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 28);
            this.lblTitulo.TabIndex = 133;
            this.lblTitulo.Text = "📋  Historial de Ventas";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltro.BackColor = System.Drawing.Color.White;
            this.pnlFiltro.Controls.Add(this.btnBuscar);
            this.pnlFiltro.Controls.Add(this.btnLimpiar);
            this.pnlFiltro.Controls.Add(this.lblEstado);
            this.pnlFiltro.Controls.Add(this.cmbEstado);
            this.pnlFiltro.Controls.Add(this.cmbCliente);
            this.pnlFiltro.Controls.Add(this.lblProveedor);
            this.pnlFiltro.Controls.Add(this.cmbTipoComprobante);
            this.pnlFiltro.Controls.Add(this.lblTipoComprobante);
            this.pnlFiltro.Controls.Add(this.lblSubTitulo);
            this.pnlFiltro.Controls.Add(this.txtNumComprobante);
            this.pnlFiltro.Controls.Add(this.lblNumComprobante);
            this.pnlFiltro.Controls.Add(this.dtpHasta);
            this.pnlFiltro.Controls.Add(this.lblHasta);
            this.pnlFiltro.Controls.Add(this.dtpDesde);
            this.pnlFiltro.Controls.Add(this.lblDesde);
            this.pnlFiltro.Location = new System.Drawing.Point(25, 92);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlFiltro.Size = new System.Drawing.Size(1134, 110);
            this.pnlFiltro.TabIndex = 134;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(1000, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 30);
            this.btnBuscar.TabIndex = 141;
            this.btnBuscar.Text = "🔍 Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnLimpiar.Location = new System.Drawing.Point(1118, 10);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(50, 30);
            this.btnLimpiar.TabIndex = 142;
            this.btnLimpiar.Text = "✕";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblEstado.Location = new System.Drawing.Point(608, 14);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(45, 15);
            this.lblEstado.TabIndex = 135;
            this.lblEstado.Text = "Estado:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(658, 11);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(150, 23);
            this.cmbEstado.TabIndex = 134;
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(392, 11);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(200, 23);
            this.cmbCliente.TabIndex = 133;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProveedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProveedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblProveedor.Location = new System.Drawing.Point(340, 14);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(47, 15);
            this.lblProveedor.TabIndex = 132;
            this.lblProveedor.Text = "Cliente:";
            // 
            // cmbTipoComprobante
            // 
            this.cmbTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipoComprobante.FormattingEnabled = true;
            this.cmbTipoComprobante.Items.AddRange(new object[] {
            "Factura",
            "Boleta",
            "Nota de Venta"});
            this.cmbTipoComprobante.Location = new System.Drawing.Point(118, 47);
            this.cmbTipoComprobante.Name = "cmbTipoComprobante";
            this.cmbTipoComprobante.Size = new System.Drawing.Size(160, 23);
            this.cmbTipoComprobante.TabIndex = 122;
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipoComprobante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblTipoComprobante.Location = new System.Drawing.Point(16, 50);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(84, 15);
            this.lblTipoComprobante.TabIndex = 121;
            this.lblTipoComprobante.Text = "Comprobante:";
            // 
            // lblSubTitulo
            // 
            this.lblSubTitulo.AutoSize = true;
            this.lblSubTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblSubTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblSubTitulo.Name = "lblSubTitulo";
            this.lblSubTitulo.Size = new System.Drawing.Size(0, 15);
            this.lblSubTitulo.TabIndex = 115;
            this.lblSubTitulo.Visible = false;
            // 
            // txtNumComprobante
            // 
            this.txtNumComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumComprobante.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNumComprobante.Location = new System.Drawing.Point(406, 47);
            this.txtNumComprobante.Name = "txtNumComprobante";
            this.txtNumComprobante.Size = new System.Drawing.Size(150, 23);
            this.txtNumComprobante.TabIndex = 116;
            // 
            // lblNumComprobante
            // 
            this.lblNumComprobante.AutoSize = true;
            this.lblNumComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNumComprobante.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNumComprobante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblNumComprobante.Location = new System.Drawing.Point(295, 50);
            this.lblNumComprobante.Name = "lblNumComprobante";
            this.lblNumComprobante.Size = new System.Drawing.Size(101, 15);
            this.lblNumComprobante.TabIndex = 117;
            this.lblNumComprobante.Text = "N° Comprobante:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(224, 11);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpHasta.TabIndex = 10012;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblHasta.Location = new System.Drawing.Point(178, 14);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(40, 15);
            this.lblHasta.TabIndex = 10013;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(64, 11);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpDesde.TabIndex = 10010;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblDesde.Location = new System.Drawing.Point(16, 14);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(42, 15);
            this.lblDesde.TabIndex = 10011;
            this.lblDesde.Text = "Desde:";
            // 
            // pnlListado
            // 
            this.pnlListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlListado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlListado.Controls.Add(this.dgvVentas);
            this.pnlListado.Location = new System.Drawing.Point(25, 210);
            this.pnlListado.Name = "pnlListado";
            this.pnlListado.Padding = new System.Windows.Forms.Padding(10);
            this.pnlListado.Size = new System.Drawing.Size(1134, 363);
            this.pnlListado.TabIndex = 135;
            // 
            // dgvVentas
            // 
            this.dgvVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVentas.ColumnHeadersHeight = 36;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumero,
            this.colFechaHora,
            this.colComprobante,
            this.colCliente,
            this.colItems,
            this.colMetodoPago,
            this.colTotal,
            this.colEstado,
            this.colVerDetalle,
            this.colReimprimir,
            this.colAnular});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVentas.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVentas.EnableHeadersVisualStyles = false;
            this.dgvVentas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(240)))));
            this.dgvVentas.Location = new System.Drawing.Point(10, 10);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.RowHeadersVisible = false;
            this.dgvVentas.RowTemplate.Height = 40;
            this.dgvVentas.Size = new System.Drawing.Size(1114, 343);
            this.dgvVentas.TabIndex = 128;
            // 
            // colNumero
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.colNumero.DefaultCellStyle = dataGridViewCellStyle2;
            this.colNumero.HeaderText = "#";
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            this.colNumero.Width = 52;
            // 
            // colFechaHora
            // 
            this.colFechaHora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.colFechaHora.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFechaHora.HeaderText = "Fecha y Hora";
            this.colFechaHora.Name = "colFechaHora";
            this.colFechaHora.ReadOnly = true;
            this.colFechaHora.Width = 145;
            // 
            // colComprobante
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colComprobante.DefaultCellStyle = dataGridViewCellStyle4;
            this.colComprobante.HeaderText = "Comprobante";
            this.colComprobante.Name = "colComprobante";
            this.colComprobante.ReadOnly = true;
            this.colComprobante.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colComprobante.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colComprobante.Width = 145;
            // 
            // colCliente
            // 
            this.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.colCliente.DefaultCellStyle = dataGridViewCellStyle5;
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            // 
            // colItems
            // 
            this.colItems.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.colItems.DefaultCellStyle = dataGridViewCellStyle6;
            this.colItems.FillWeight = 90F;
            this.colItems.HeaderText = "Ítems";
            this.colItems.Name = "colItems";
            this.colItems.ReadOnly = true;
            this.colItems.Width = 70;
            // 
            // colMetodoPago
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colMetodoPago.DefaultCellStyle = dataGridViewCellStyle7;
            this.colMetodoPago.HeaderText = "Método";
            this.colMetodoPago.Name = "colMetodoPago";
            this.colMetodoPago.ReadOnly = true;
            this.colMetodoPago.Width = 112;
            // 
            // colTotal
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(120)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle8;
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 112;
            // 
            // colEstado
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.colEstado.DefaultCellStyle = dataGridViewCellStyle9;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 108;
            // 
            // colVerDetalle
            // 
            this.colVerDetalle.HeaderText = "";
            this.colVerDetalle.Image = ((System.Drawing.Image)(resources.GetObject("colVerDetalle.Image")));
            this.colVerDetalle.Name = "colVerDetalle";
            this.colVerDetalle.ReadOnly = true;
            this.colVerDetalle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colVerDetalle.Width = 40;
            // 
            // colReimprimir
            // 
            this.colReimprimir.HeaderText = "";
            this.colReimprimir.Image = ((System.Drawing.Image)(resources.GetObject("colReimprimir.Image")));
            this.colReimprimir.Name = "colReimprimir";
            this.colReimprimir.ReadOnly = true;
            this.colReimprimir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colReimprimir.Width = 40;
            // 
            // colAnular
            // 
            this.colAnular.HeaderText = "";
            this.colAnular.Image = ((System.Drawing.Image)(resources.GetObject("colAnular.Image")));
            this.colAnular.Name = "colAnular";
            this.colAnular.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAnular.Width = 40;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.lblSubTitulo3);
            this.pnlFooter.Controls.Add(this.lblEfectivo);
            this.pnlFooter.Controls.Add(this.txtEfectivoCantidad);
            this.pnlFooter.Controls.Add(this.lblYape);
            this.pnlFooter.Controls.Add(this.txtYapeCantidad);
            this.pnlFooter.Controls.Add(this.lblTarjeta);
            this.pnlFooter.Controls.Add(this.txtTarjetaCantidad);
            this.pnlFooter.Controls.Add(this.lblTransferencia);
            this.pnlFooter.Controls.Add(this.txtTransferenciaCantidad);
            this.pnlFooter.Controls.Add(this.lblCredito);
            this.pnlFooter.Controls.Add(this.txtCreditoCantidad);
            this.pnlFooter.Controls.Add(this.lblSepVertical);
            this.pnlFooter.Controls.Add(this.lblTotal);
            this.pnlFooter.Controls.Add(this.txtTotalCantidad);
            this.pnlFooter.Controls.Add(this.btnExportar);
            this.pnlFooter.Controls.Add(this.btnCerrar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 599);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(16, 6, 16, 6);
            this.pnlFooter.Size = new System.Drawing.Size(1184, 62);
            this.pnlFooter.TabIndex = 136;
            // 
            // lblSubTitulo3
            // 
            this.lblSubTitulo3.AutoSize = true;
            this.lblSubTitulo3.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSubTitulo3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubTitulo3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTitulo3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblSubTitulo3.Location = new System.Drawing.Point(16, 6);
            this.lblSubTitulo3.Name = "lblSubTitulo3";
            this.lblSubTitulo3.Size = new System.Drawing.Size(130, 15);
            this.lblSubTitulo3.TabIndex = 145;
            this.lblSubTitulo3.Text = "0 registros encontrados";
            this.lblSubTitulo3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEfectivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblEfectivo.Location = new System.Drawing.Point(16, 36);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(52, 15);
            this.lblEfectivo.TabIndex = 146;
            this.lblEfectivo.Text = "Efectivo:";
            // 
            // txtEfectivoCantidad
            // 
            this.txtEfectivoCantidad.BackColor = System.Drawing.Color.White;
            this.txtEfectivoCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEfectivoCantidad.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtEfectivoCantidad.Location = new System.Drawing.Point(67, 34);
            this.txtEfectivoCantidad.Name = "txtEfectivoCantidad";
            this.txtEfectivoCantidad.ReadOnly = true;
            this.txtEfectivoCantidad.Size = new System.Drawing.Size(72, 16);
            this.txtEfectivoCantidad.TabIndex = 10026;
            this.txtEfectivoCantidad.Text = "S/ 0.00";
            // 
            // lblYape
            // 
            this.lblYape.AutoSize = true;
            this.lblYape.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblYape.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblYape.Location = new System.Drawing.Point(150, 36);
            this.lblYape.Name = "lblYape";
            this.lblYape.Size = new System.Drawing.Size(74, 15);
            this.lblYape.TabIndex = 147;
            this.lblYape.Text = "Yape/Digital:";
            // 
            // txtYapeCantidad
            // 
            this.txtYapeCantidad.BackColor = System.Drawing.Color.White;
            this.txtYapeCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtYapeCantidad.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtYapeCantidad.Location = new System.Drawing.Point(228, 34);
            this.txtYapeCantidad.Name = "txtYapeCantidad";
            this.txtYapeCantidad.ReadOnly = true;
            this.txtYapeCantidad.Size = new System.Drawing.Size(72, 16);
            this.txtYapeCantidad.TabIndex = 10027;
            this.txtYapeCantidad.Text = "S/ 0.00";
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.AutoSize = true;
            this.lblTarjeta.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblTarjeta.Location = new System.Drawing.Point(312, 36);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(44, 15);
            this.lblTarjeta.TabIndex = 148;
            this.lblTarjeta.Text = "Tarjeta:";
            // 
            // txtTarjetaCantidad
            // 
            this.txtTarjetaCantidad.BackColor = System.Drawing.Color.White;
            this.txtTarjetaCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTarjetaCantidad.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtTarjetaCantidad.Location = new System.Drawing.Point(363, 34);
            this.txtTarjetaCantidad.Name = "txtTarjetaCantidad";
            this.txtTarjetaCantidad.ReadOnly = true;
            this.txtTarjetaCantidad.Size = new System.Drawing.Size(72, 16);
            this.txtTarjetaCantidad.TabIndex = 10028;
            this.txtTarjetaCantidad.Text = "S/ 0.00";
            // 
            // lblTransferencia
            // 
            this.lblTransferencia.AutoSize = true;
            this.lblTransferencia.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTransferencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblTransferencia.Location = new System.Drawing.Point(448, 36);
            this.lblTransferencia.Name = "lblTransferencia";
            this.lblTransferencia.Size = new System.Drawing.Size(54, 15);
            this.lblTransferencia.TabIndex = 149;
            this.lblTransferencia.Text = "Transfer.:";
            // 
            // txtTransferenciaCantidad
            // 
            this.txtTransferenciaCantidad.BackColor = System.Drawing.Color.White;
            this.txtTransferenciaCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTransferenciaCantidad.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtTransferenciaCantidad.Location = new System.Drawing.Point(506, 34);
            this.txtTransferenciaCantidad.Name = "txtTransferenciaCantidad";
            this.txtTransferenciaCantidad.ReadOnly = true;
            this.txtTransferenciaCantidad.Size = new System.Drawing.Size(72, 16);
            this.txtTransferenciaCantidad.TabIndex = 10029;
            this.txtTransferenciaCantidad.Text = "S/ 0.00";
            // 
            // lblCredito
            // 
            this.lblCredito.AutoSize = true;
            this.lblCredito.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCredito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblCredito.Location = new System.Drawing.Point(590, 36);
            this.lblCredito.Name = "lblCredito";
            this.lblCredito.Size = new System.Drawing.Size(49, 15);
            this.lblCredito.TabIndex = 150;
            this.lblCredito.Text = "Crédito:";
            // 
            // txtCreditoCantidad
            // 
            this.txtCreditoCantidad.BackColor = System.Drawing.Color.White;
            this.txtCreditoCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCreditoCantidad.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtCreditoCantidad.Location = new System.Drawing.Point(638, 34);
            this.txtCreditoCantidad.Name = "txtCreditoCantidad";
            this.txtCreditoCantidad.ReadOnly = true;
            this.txtCreditoCantidad.Size = new System.Drawing.Size(72, 16);
            this.txtCreditoCantidad.TabIndex = 10030;
            this.txtCreditoCantidad.Text = "S/ 0.00";
            // 
            // lblSepVertical
            // 
            this.lblSepVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblSepVertical.Location = new System.Drawing.Point(722, 8);
            this.lblSepVertical.Name = "lblSepVertical";
            this.lblSepVertical.Size = new System.Drawing.Size(1, 46);
            this.lblSepVertical.TabIndex = 151;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblTotal.Location = new System.Drawing.Point(734, 8);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(93, 15);
            this.lblTotal.TabIndex = 152;
            this.lblTotal.Text = "TOTAL VENTAS:";
            // 
            // txtTotalCantidad
            // 
            this.txtTotalCantidad.BackColor = System.Drawing.Color.White;
            this.txtTotalCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalCantidad.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtTotalCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.txtTotalCantidad.Location = new System.Drawing.Point(845, 4);
            this.txtTotalCantidad.Name = "txtTotalCantidad";
            this.txtTotalCantidad.ReadOnly = true;
            this.txtTotalCantidad.Size = new System.Drawing.Size(105, 20);
            this.txtTotalCantidad.TabIndex = 10031;
            this.txtTotalCantidad.Text = "S/ 0.00";
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.White;
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnExportar.Location = new System.Drawing.Point(970, 14);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(100, 30);
            this.btnExportar.TabIndex = 10014;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(45)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1078, 14);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(90, 30);
            this.btnCerrar.TabIndex = 10015;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // FormHistorialVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlListado);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlFiltro);
            this.Controls.Add(this.pnlHeader);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHistorialVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de Ventas";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            this.pnlListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // Header
        private System.Windows.Forms.Panel   pnlHeader;
        private System.Windows.Forms.Label   lblSubTituloHeader;

        // Filtros
        private System.Windows.Forms.Panel   pnlFiltro;
        private System.Windows.Forms.Label   lblSubTitulo;
        private System.Windows.Forms.Label   lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label   lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label   lblProveedor;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label   lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label   lblTipoComprobante;
        private System.Windows.Forms.ComboBox cmbTipoComprobante;
        private System.Windows.Forms.Label   lblNumComprobante;
        private System.Windows.Forms.TextBox txtNumComprobante;
        private System.Windows.Forms.Button  btnBuscar;
        private System.Windows.Forms.Button  btnLimpiar;

        // Grid
        private System.Windows.Forms.Panel   pnlListado;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMetodoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewImageColumn   colVerDetalle;
        private System.Windows.Forms.DataGridViewImageColumn   colReimprimir;
        private System.Windows.Forms.DataGridViewImageColumn   colAnular;

        // Footer
        private System.Windows.Forms.Panel   pnlFooter;
        private System.Windows.Forms.Label   lblSubTitulo3;
        private System.Windows.Forms.Label   lblEfectivo;
        private System.Windows.Forms.TextBox txtEfectivoCantidad;
        private System.Windows.Forms.Label   lblYape;
        private System.Windows.Forms.TextBox txtYapeCantidad;
        private System.Windows.Forms.Label   lblTarjeta;
        private System.Windows.Forms.TextBox txtTarjetaCantidad;
        private System.Windows.Forms.Label   lblTransferencia;
        private System.Windows.Forms.TextBox txtTransferenciaCantidad;
        private System.Windows.Forms.Label   lblCredito;
        private System.Windows.Forms.TextBox txtCreditoCantidad;
        private System.Windows.Forms.Label   lblSepVertical;
        private System.Windows.Forms.Label   lblTotal;
        private System.Windows.Forms.TextBox txtTotalCantidad;
        private System.Windows.Forms.Button  btnExportar;
        private System.Windows.Forms.Button  btnCerrar;

        // Título
        private System.Windows.Forms.Label   lblTitulo;
    }
}
