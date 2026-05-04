namespace SistemaPOS.Forms.Compras
{
    partial class FormDetalleCompra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubTituloDetalle = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlComprobante = new System.Windows.Forms.Panel();
            this.txtEncargado = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtNumeroSerie = new System.Windows.Forms.TextBox();
            this.txtTipoComprobante = new System.Windows.Forms.TextBox();
            this.lblEncargado = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblNumeroSerie = new System.Windows.Forms.Label();
            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.lblSubTitulo = new System.Windows.Forms.Label();
            this.pnlProveedor = new System.Windows.Forms.Panel();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.txtRUC = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.lblDNIRUC = new System.Windows.Forms.Label();
            this.lblSubTitulo2 = new System.Windows.Forms.Label();
            this.pnlGridDetalle = new System.Windows.Forms.Panel();
            this.dgvDetalleProductos = new System.Windows.Forms.DataGridView();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductoDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPresentacionDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSubTitulo3 = new System.Windows.Forms.Label();
            this.pnlTotales = new System.Windows.Forms.Panel();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.lblTipoIGVBadge = new System.Windows.Forms.Label();
            this.lblTipoIGVLabel = new System.Windows.Forms.Label();
            this.txtRecibido = new System.Windows.Forms.TextBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.lblLineaDivisora2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtFlete = new System.Windows.Forms.TextBox();
            this.lblFlete = new System.Windows.Forms.Label();
            this.txtIGV = new System.Windows.Forms.TextBox();
            this.lblIGV = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlComprobante.SuspendLayout();
            this.pnlProveedor.SuspendLayout();
            this.pnlGridDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleProductos)).BeginInit();
            this.pnlTotales.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlHeader.Controls.Add(this.lblSubTituloDetalle);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.pnlHeader.Size = new System.Drawing.Size(860, 68);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubTituloDetalle
            // 
            this.lblSubTituloDetalle.AutoSize = true;
            this.lblSubTituloDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTituloDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.lblSubTituloDetalle.Location = new System.Drawing.Point(18, 40);
            this.lblSubTituloDetalle.Name = "lblSubTituloDetalle";
            this.lblSubTituloDetalle.Size = new System.Drawing.Size(0, 15);
            this.lblSubTituloDetalle.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(16, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(167, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Detalle de Compra";
            // 
            // pnlComprobante
            // 
            this.pnlComprobante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.pnlComprobante.Controls.Add(this.txtEncargado);
            this.pnlComprobante.Controls.Add(this.txtEstado);
            this.pnlComprobante.Controls.Add(this.txtHora);
            this.pnlComprobante.Controls.Add(this.txtFecha);
            this.pnlComprobante.Controls.Add(this.txtNumeroSerie);
            this.pnlComprobante.Controls.Add(this.txtTipoComprobante);
            this.pnlComprobante.Controls.Add(this.lblEncargado);
            this.pnlComprobante.Controls.Add(this.lblEstado);
            this.pnlComprobante.Controls.Add(this.lblHora);
            this.pnlComprobante.Controls.Add(this.lblFecha);
            this.pnlComprobante.Controls.Add(this.lblNumeroSerie);
            this.pnlComprobante.Controls.Add(this.lblTipoComprobante);
            this.pnlComprobante.Controls.Add(this.lblSubTitulo);
            this.pnlComprobante.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlComprobante.Location = new System.Drawing.Point(0, 68);
            this.pnlComprobante.Name = "pnlComprobante";
            this.pnlComprobante.Padding = new System.Windows.Forms.Padding(16, 10, 16, 8);
            this.pnlComprobante.Size = new System.Drawing.Size(860, 110);
            this.pnlComprobante.TabIndex = 138;
            // 
            // txtEncargado
            // 
            this.txtEncargado.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtEncargado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEncargado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtEncargado.Location = new System.Drawing.Point(90, 84);
            this.txtEncargado.Name = "txtEncargado";
            this.txtEncargado.ReadOnly = true;
            this.txtEncargado.Size = new System.Drawing.Size(300, 16);
            this.txtEncargado.TabIndex = 205;
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtEstado.Location = new System.Drawing.Point(624, 58);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(140, 16);
            this.txtEstado.TabIndex = 204;
            // 
            // txtHora
            // 
            this.txtHora.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtHora.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHora.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtHora.Location = new System.Drawing.Point(384, 58);
            this.txtHora.Name = "txtHora";
            this.txtHora.ReadOnly = true;
            this.txtHora.Size = new System.Drawing.Size(140, 16);
            this.txtHora.TabIndex = 203;
            // 
            // txtFecha
            // 
            this.txtFecha.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFecha.Location = new System.Drawing.Point(90, 58);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(168, 16);
            this.txtFecha.TabIndex = 202;
            // 
            // txtNumeroSerie
            // 
            this.txtNumeroSerie.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtNumeroSerie.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumeroSerie.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtNumeroSerie.Location = new System.Drawing.Point(384, 32);
            this.txtNumeroSerie.Name = "txtNumeroSerie";
            this.txtNumeroSerie.ReadOnly = true;
            this.txtNumeroSerie.Size = new System.Drawing.Size(160, 16);
            this.txtNumeroSerie.TabIndex = 201;
            // 
            // txtTipoComprobante
            // 
            this.txtTipoComprobante.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtTipoComprobante.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtTipoComprobante.Location = new System.Drawing.Point(90, 32);
            this.txtTipoComprobante.Name = "txtTipoComprobante";
            this.txtTipoComprobante.ReadOnly = true;
            this.txtTipoComprobante.Size = new System.Drawing.Size(168, 16);
            this.txtTipoComprobante.TabIndex = 200;
            // 
            // lblEncargado
            // 
            this.lblEncargado.AutoSize = true;
            this.lblEncargado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEncargado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblEncargado.Location = new System.Drawing.Point(16, 86);
            this.lblEncargado.Name = "lblEncargado";
            this.lblEncargado.Size = new System.Drawing.Size(66, 15);
            this.lblEncargado.TabIndex = 136;
            this.lblEncargado.Text = "Encargado:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblEstado.Location = new System.Drawing.Point(568, 60);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(45, 15);
            this.lblEstado.TabIndex = 139;
            this.lblEstado.Text = "Estado:";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblHora.Location = new System.Drawing.Point(292, 60);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(36, 15);
            this.lblHora.TabIndex = 138;
            this.lblHora.Text = "Hora:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblFecha.Location = new System.Drawing.Point(16, 60);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(41, 15);
            this.lblFecha.TabIndex = 133;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblNumeroSerie
            // 
            this.lblNumeroSerie.AutoSize = true;
            this.lblNumeroSerie.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNumeroSerie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblNumeroSerie.Location = new System.Drawing.Point(292, 34);
            this.lblNumeroSerie.Name = "lblNumeroSerie";
            this.lblNumeroSerie.Size = new System.Drawing.Size(84, 15);
            this.lblNumeroSerie.TabIndex = 140;
            this.lblNumeroSerie.Text = "Serie-Número:";
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipoComprobante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblTipoComprobante.Location = new System.Drawing.Point(16, 34);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(33, 15);
            this.lblTipoComprobante.TabIndex = 130;
            this.lblTipoComprobante.Text = "Tipo:";
            // 
            // lblSubTitulo
            // 
            this.lblSubTitulo.AutoSize = true;
            this.lblSubTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSubTitulo.Location = new System.Drawing.Point(16, 10);
            this.lblSubTitulo.Name = "lblSubTitulo";
            this.lblSubTitulo.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblSubTitulo.Size = new System.Drawing.Size(150, 17);
            this.lblSubTitulo.TabIndex = 12;
            this.lblSubTitulo.Text = "📋  COMPROBANTE";
            // 
            // pnlProveedor
            // 
            this.pnlProveedor.BackColor = System.Drawing.Color.White;
            this.pnlProveedor.Controls.Add(this.txtDireccion);
            this.pnlProveedor.Controls.Add(this.txtTelefono);
            this.pnlProveedor.Controls.Add(this.txtRazonSocial);
            this.pnlProveedor.Controls.Add(this.txtRUC);
            this.pnlProveedor.Controls.Add(this.lblDireccion);
            this.pnlProveedor.Controls.Add(this.lblTelefono);
            this.pnlProveedor.Controls.Add(this.lblRazonSocial);
            this.pnlProveedor.Controls.Add(this.lblDNIRUC);
            this.pnlProveedor.Controls.Add(this.lblSubTitulo2);
            this.pnlProveedor.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProveedor.Location = new System.Drawing.Point(0, 178);
            this.pnlProveedor.Name = "pnlProveedor";
            this.pnlProveedor.Padding = new System.Windows.Forms.Padding(16, 6, 16, 6);
            this.pnlProveedor.Size = new System.Drawing.Size(860, 90);
            this.pnlProveedor.TabIndex = 143;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.GhostWhite;
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDireccion.Location = new System.Drawing.Point(356, 54);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(360, 16);
            this.txtDireccion.TabIndex = 209;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.GhostWhite;
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTelefono.Location = new System.Drawing.Point(100, 54);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(160, 16);
            this.txtTelefono.TabIndex = 208;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BackColor = System.Drawing.Color.GhostWhite;
            this.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRazonSocial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtRazonSocial.Location = new System.Drawing.Point(100, 28);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(280, 16);
            this.txtRazonSocial.TabIndex = 206;
            // 
            // txtRUC
            // 
            this.txtRUC.BackColor = System.Drawing.Color.GhostWhite;
            this.txtRUC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRUC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRUC.Location = new System.Drawing.Point(458, 28);
            this.txtRUC.Name = "txtRUC";
            this.txtRUC.ReadOnly = true;
            this.txtRUC.Size = new System.Drawing.Size(160, 16);
            this.txtRUC.TabIndex = 207;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblDireccion.Location = new System.Drawing.Point(292, 56);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(60, 15);
            this.lblDireccion.TabIndex = 139;
            this.lblDireccion.Text = "Dirección:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblTelefono.Location = new System.Drawing.Point(16, 56);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(55, 15);
            this.lblTelefono.TabIndex = 138;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRazonSocial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblRazonSocial.Location = new System.Drawing.Point(16, 30);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(76, 15);
            this.lblRazonSocial.TabIndex = 136;
            this.lblRazonSocial.Text = "Razón Social:";
            // 
            // lblDNIRUC
            // 
            this.lblDNIRUC.AutoSize = true;
            this.lblDNIRUC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDNIRUC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblDNIRUC.Location = new System.Drawing.Point(420, 30);
            this.lblDNIRUC.Name = "lblDNIRUC";
            this.lblDNIRUC.Size = new System.Drawing.Size(33, 15);
            this.lblDNIRUC.TabIndex = 133;
            this.lblDNIRUC.Text = "RUC:";
            // 
            // lblSubTitulo2
            // 
            this.lblSubTitulo2.AutoSize = true;
            this.lblSubTitulo2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSubTitulo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSubTitulo2.Location = new System.Drawing.Point(16, 8);
            this.lblSubTitulo2.Name = "lblSubTitulo2";
            this.lblSubTitulo2.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblSubTitulo2.Size = new System.Drawing.Size(132, 17);
            this.lblSubTitulo2.TabIndex = 12;
            this.lblSubTitulo2.Text = "🏭  PROVEEDOR";
            // 
            // pnlGridDetalle
            // 
            this.pnlGridDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlGridDetalle.Controls.Add(this.dgvDetalleProductos);
            this.pnlGridDetalle.Controls.Add(this.lblSubTitulo3);
            this.pnlGridDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridDetalle.Location = new System.Drawing.Point(0, 268);
            this.pnlGridDetalle.Name = "pnlGridDetalle";
            this.pnlGridDetalle.Padding = new System.Windows.Forms.Padding(12, 6, 12, 4);
            this.pnlGridDetalle.Size = new System.Drawing.Size(860, 176);
            this.pnlGridDetalle.TabIndex = 8;
            // 
            // dgvDetalleProductos
            // 
            this.dgvDetalleProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDetalleProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalleProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalleProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDetalleProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDetalleProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalleProductos.ColumnHeadersHeight = 36;
            this.dgvDetalleProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetalleProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumero,
            this.colProductoDV,
            this.colPresentacionDV,
            this.colCantidad,
            this.colCostoUnitario,
            this.colSubTotal});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleProductos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalleProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalleProductos.EnableHeadersVisualStyles = false;
            this.dgvDetalleProductos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(240)))));
            this.dgvDetalleProductos.Location = new System.Drawing.Point(12, 6);
            this.dgvDetalleProductos.Name = "dgvDetalleProductos";
            this.dgvDetalleProductos.RowHeadersVisible = false;
            this.dgvDetalleProductos.RowTemplate.Height = 44;
            this.dgvDetalleProductos.Size = new System.Drawing.Size(836, 166);
            this.dgvDetalleProductos.TabIndex = 144;
            // 
            // colNumero
            // 
            this.colNumero.HeaderText = "#";
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            this.colNumero.Width = 42;
            // 
            // colProductoDV
            // 
            this.colProductoDV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProductoDV.HeaderText = "Producto";
            this.colProductoDV.MinimumWidth = 180;
            this.colProductoDV.Name = "colProductoDV";
            this.colProductoDV.ReadOnly = true;
            // 
            // colPresentacionDV
            // 
            this.colPresentacionDV.HeaderText = "Presentación";
            this.colPresentacionDV.Name = "colPresentacionDV";
            this.colPresentacionDV.ReadOnly = true;
            this.colPresentacionDV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPresentacionDV.Width = 140;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            this.colCantidad.Width = 110;
            // 
            // colCostoUnitario
            // 
            this.colCostoUnitario.HeaderText = "Costo Unitario";
            this.colCostoUnitario.Name = "colCostoUnitario";
            this.colCostoUnitario.ReadOnly = true;
            this.colCostoUnitario.Width = 190;
            // 
            // colSubTotal
            // 
            this.colSubTotal.HeaderText = "Subtotal";
            this.colSubTotal.Name = "colSubTotal";
            this.colSubTotal.ReadOnly = true;
            this.colSubTotal.Width = 110;
            // 
            // lblSubTitulo3
            // 
            this.lblSubTitulo3.AutoSize = true;
            this.lblSubTitulo3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSubTitulo3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSubTitulo3.Location = new System.Drawing.Point(12, 8);
            this.lblSubTitulo3.Name = "lblSubTitulo3";
            this.lblSubTitulo3.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblSubTitulo3.Size = new System.Drawing.Size(212, 17);
            this.lblSubTitulo3.TabIndex = 140;
            this.lblSubTitulo3.Text = "📦  DETALLE DE PRODUCTOS";
            // 
            // pnlTotales
            // 
            this.pnlTotales.BackColor = System.Drawing.Color.White;
            this.pnlTotales.Controls.Add(this.txtObservaciones);
            this.pnlTotales.Controls.Add(this.lblObservaciones);
            this.pnlTotales.Controls.Add(this.lblTipoIGVBadge);
            this.pnlTotales.Controls.Add(this.lblTipoIGVLabel);
            this.pnlTotales.Controls.Add(this.txtRecibido);
            this.pnlTotales.Controls.Add(this.lblMetodoPago);
            this.pnlTotales.Controls.Add(this.lblLineaDivisora2);
            this.pnlTotales.Controls.Add(this.txtTotal);
            this.pnlTotales.Controls.Add(this.lblTotal);
            this.pnlTotales.Controls.Add(this.txtFlete);
            this.pnlTotales.Controls.Add(this.lblFlete);
            this.pnlTotales.Controls.Add(this.txtIGV);
            this.pnlTotales.Controls.Add(this.lblIGV);
            this.pnlTotales.Controls.Add(this.txtSubTotal);
            this.pnlTotales.Controls.Add(this.lblSubTotal);
            this.pnlTotales.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotales.Location = new System.Drawing.Point(0, 444);
            this.pnlTotales.Name = "pnlTotales";
            this.pnlTotales.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlTotales.Size = new System.Drawing.Size(860, 140);
            this.pnlTotales.TabIndex = 9;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtObservaciones.Location = new System.Drawing.Point(136, 70);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ReadOnly = true;
            this.txtObservaciones.Size = new System.Drawing.Size(280, 44);
            this.txtObservaciones.TabIndex = 10038;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblObservaciones.Location = new System.Drawing.Point(16, 72);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(87, 15);
            this.lblObservaciones.TabIndex = 154;
            this.lblObservaciones.Text = "Observaciones:";
            // 
            // lblTipoIGVBadge
            // 
            this.lblTipoIGVBadge.AutoSize = true;
            this.lblTipoIGVBadge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipoIGVBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTipoIGVBadge.Location = new System.Drawing.Point(136, 42);
            this.lblTipoIGVBadge.Name = "lblTipoIGVBadge";
            this.lblTipoIGVBadge.Size = new System.Drawing.Size(48, 15);
            this.lblTipoIGVBadge.TabIndex = 153;
            this.lblTipoIGVBadge.Text = "Sin IGV";
            // 
            // lblTipoIGVLabel
            // 
            this.lblTipoIGVLabel.AutoSize = true;
            this.lblTipoIGVLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipoIGVLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblTipoIGVLabel.Location = new System.Drawing.Point(16, 42);
            this.lblTipoIGVLabel.Name = "lblTipoIGVLabel";
            this.lblTipoIGVLabel.Size = new System.Drawing.Size(54, 15);
            this.lblTipoIGVLabel.TabIndex = 152;
            this.lblTipoIGVLabel.Text = "Tipo IGV:";
            // 
            // txtRecibido
            // 
            this.txtRecibido.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtRecibido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRecibido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtRecibido.Location = new System.Drawing.Point(136, 12);
            this.txtRecibido.Multiline = true;
            this.txtRecibido.Name = "txtRecibido";
            this.txtRecibido.ReadOnly = true;
            this.txtRecibido.Size = new System.Drawing.Size(220, 20);
            this.txtRecibido.TabIndex = 10045;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMetodoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblMetodoPago.Location = new System.Drawing.Point(16, 14);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(98, 15);
            this.lblMetodoPago.TabIndex = 151;
            this.lblMetodoPago.Text = "Método de Pago:";
            // 
            // lblLineaDivisora2
            // 
            this.lblLineaDivisora2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.lblLineaDivisora2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.lblLineaDivisora2.Location = new System.Drawing.Point(480, 96);
            this.lblLineaDivisora2.Name = "lblLineaDivisora2";
            this.lblLineaDivisora2.Size = new System.Drawing.Size(354, 1);
            this.lblLineaDivisora2.TabIndex = 10039;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.txtTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.txtTotal.Location = new System.Drawing.Point(604, 100);
            this.txtTotal.Multiline = true;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(230, 26);
            this.txtTotal.TabIndex = 10048;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblTotal.Location = new System.Drawing.Point(480, 104);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(54, 20);
            this.lblTotal.TabIndex = 148;
            this.lblTotal.Text = "TOTAL:";
            // 
            // txtFlete
            // 
            this.txtFlete.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtFlete.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFlete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFlete.Location = new System.Drawing.Point(680, 68);
            this.txtFlete.Multiline = true;
            this.txtFlete.Name = "txtFlete";
            this.txtFlete.ReadOnly = true;
            this.txtFlete.Size = new System.Drawing.Size(154, 20);
            this.txtFlete.TabIndex = 10050;
            this.txtFlete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblFlete
            // 
            this.lblFlete.AutoSize = true;
            this.lblFlete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFlete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblFlete.Location = new System.Drawing.Point(480, 70);
            this.lblFlete.Name = "lblFlete";
            this.lblFlete.Size = new System.Drawing.Size(40, 15);
            this.lblFlete.TabIndex = 10049;
            this.lblFlete.Text = "FLETE:";
            // 
            // txtIGV
            // 
            this.txtIGV.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtIGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIGV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIGV.Location = new System.Drawing.Point(680, 40);
            this.txtIGV.Multiline = true;
            this.txtIGV.Name = "txtIGV";
            this.txtIGV.ReadOnly = true;
            this.txtIGV.Size = new System.Drawing.Size(154, 20);
            this.txtIGV.TabIndex = 10047;
            this.txtIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIGV
            // 
            this.lblIGV.AutoSize = true;
            this.lblIGV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIGV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblIGV.Location = new System.Drawing.Point(480, 42);
            this.lblIGV.Name = "lblIGV";
            this.lblIGV.Size = new System.Drawing.Size(61, 15);
            this.lblIGV.TabIndex = 147;
            this.lblIGV.Text = "IGV (18%):";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSubTotal.Location = new System.Drawing.Point(680, 12);
            this.txtSubTotal.Multiline = true;
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(154, 20);
            this.txtSubTotal.TabIndex = 10046;
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblSubTotal.Location = new System.Drawing.Point(480, 14);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(65, 15);
            this.lblSubTotal.TabIndex = 145;
            this.lblSubTotal.Text = "BASE IMP.:";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlFooter.Controls.Add(this.btnCerrar);
            this.pnlFooter.Controls.Add(this.btnImprimir);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 584);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlFooter.Size = new System.Drawing.Size(860, 56);
            this.pnlFooter.TabIndex = 10;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(736, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(108, 36);
            this.btnCerrar.TabIndex = 10040;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(16, 10);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(140, 36);
            this.btnImprimir.TabIndex = 10041;
            this.btnImprimir.Text = "Exportar";
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // FormDetalleCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(860, 640);
            this.Controls.Add(this.pnlGridDetalle);
            this.Controls.Add(this.pnlTotales);
            this.Controls.Add(this.pnlProveedor);
            this.Controls.Add(this.pnlComprobante);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDetalleCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlComprobante.ResumeLayout(false);
            this.pnlComprobante.PerformLayout();
            this.pnlProveedor.ResumeLayout(false);
            this.pnlProveedor.PerformLayout();
            this.pnlGridDetalle.ResumeLayout(false);
            this.pnlGridDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleProductos)).EndInit();
            this.pnlTotales.ResumeLayout(false);
            this.pnlTotales.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // Header
        private System.Windows.Forms.Panel   pnlHeader;
        private System.Windows.Forms.Label   lblTitulo;
        private System.Windows.Forms.Label   lblSubTituloDetalle;

        // Comprobante
        private System.Windows.Forms.Panel   pnlComprobante;
        private System.Windows.Forms.Label   lblSubTitulo;
        private System.Windows.Forms.Label   lblTipoComprobante;
        private System.Windows.Forms.TextBox txtTipoComprobante;
        private System.Windows.Forms.Label   lblNumeroSerie;
        private System.Windows.Forms.TextBox txtNumeroSerie;
        private System.Windows.Forms.Label   lblFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label   lblHora;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Label   lblEstado;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label   lblEncargado;
        private System.Windows.Forms.TextBox txtEncargado;

        // Proveedor
        private System.Windows.Forms.Panel   pnlProveedor;
        private System.Windows.Forms.Label   lblSubTitulo2;
        private System.Windows.Forms.Label   lblRazonSocial;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label   lblDNIRUC;
        private System.Windows.Forms.TextBox txtRUC;
        private System.Windows.Forms.Label   lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label   lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;

        // Grid
        private System.Windows.Forms.Panel   pnlGridDetalle;
        private System.Windows.Forms.Label   lblSubTitulo3;
        private System.Windows.Forms.DataGridView dgvDetalleProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductoDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPresentacionDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubTotal;

        // Totales
        private System.Windows.Forms.Panel   pnlTotales;
        private System.Windows.Forms.Label   lblMetodoPago;
        private System.Windows.Forms.TextBox txtRecibido;
        private System.Windows.Forms.Label   lblTipoIGVLabel;
        private System.Windows.Forms.Label   lblTipoIGVBadge;
        private System.Windows.Forms.Label   lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label   lblSubTotal;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label   lblIGV;
        private System.Windows.Forms.TextBox txtIGV;
        private System.Windows.Forms.Label   lblFlete;
        private System.Windows.Forms.TextBox txtFlete;
        private System.Windows.Forms.Label   lblLineaDivisora2;
        private System.Windows.Forms.Label   lblTotal;
        private System.Windows.Forms.TextBox txtTotal;

        // Footer
        private System.Windows.Forms.Panel   pnlFooter;
        private System.Windows.Forms.Button  btnImprimir;
        private System.Windows.Forms.Button  btnCerrar;
    }
}
