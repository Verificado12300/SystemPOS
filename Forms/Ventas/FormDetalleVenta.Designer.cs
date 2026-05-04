namespace SistemaPOS.Forms.Ventas
{
    partial class FormDetalleVenta
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
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle  = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvDefaultStyle = new System.Windows.Forms.DataGridViewCellStyle();

            // ── Declarations ──────────────────────────────────────────────────
            // Header
            this.pnlHeaderDetalle   = new System.Windows.Forms.Panel();
            this.lblTitulo          = new System.Windows.Forms.Label();
            this.lblSubTituloDetalle = new System.Windows.Forms.Label();

            // Info card panel (reemplaza pnlComprobante + pnlCliente)
            this.pnlComprobante     = new System.Windows.Forms.Panel();
            this.lblSubTitulo       = new System.Windows.Forms.Label();
            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.txtTipoComprobante = new System.Windows.Forms.TextBox();
            this.lblNumeroSerie     = new System.Windows.Forms.Label();
            this.txtNumeroSerie     = new System.Windows.Forms.TextBox();
            this.lblFecha           = new System.Windows.Forms.Label();
            this.txtFecha           = new System.Windows.Forms.TextBox();
            this.lblHora            = new System.Windows.Forms.Label();
            this.txtHora            = new System.Windows.Forms.TextBox();
            this.lblEstado          = new System.Windows.Forms.Label();
            this.txtEstado          = new System.Windows.Forms.TextBox();
            this.lblEncargado       = new System.Windows.Forms.Label();
            this.txtEncargado       = new System.Windows.Forms.TextBox();

            this.pnlCliente         = new System.Windows.Forms.Panel();
            this.lblSubTitulo2      = new System.Windows.Forms.Label();
            this.lblNombreRazonSocial = new System.Windows.Forms.Label();
            this.txtNombreRazonSocial = new System.Windows.Forms.TextBox();
            this.lblDNIRUC          = new System.Windows.Forms.Label();
            this.txtDNIRUC          = new System.Windows.Forms.TextBox();
            this.lblTelefono        = new System.Windows.Forms.Label();
            this.txtTelefono        = new System.Windows.Forms.TextBox();
            this.lblDireccion       = new System.Windows.Forms.Label();
            this.txtDireccion       = new System.Windows.Forms.TextBox();

            // Grid de productos
            this.pnlGridDetalle     = new System.Windows.Forms.Panel();
            this.lblSubTitulo3      = new System.Windows.Forms.Label();
            this.dgvDetalleProductos = new System.Windows.Forms.DataGridView();
            this.colNumero          = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductoDV      = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPresentacionDV  = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad        = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioUnitario  = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubTotal        = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // Totales
            this.pnlTotalesDetalle  = new System.Windows.Forms.Panel();
            this.lblMetodoPago      = new System.Windows.Forms.Label();
            this.txtMetodoPago      = new System.Windows.Forms.TextBox();
            this.lblRecibido        = new System.Windows.Forms.Label();
            this.txtRecibido        = new System.Windows.Forms.TextBox();
            this.lblVuelto          = new System.Windows.Forms.Label();
            this.txtVuelto          = new System.Windows.Forms.TextBox();
            this.lblSubTotal        = new System.Windows.Forms.Label();
            this.txtSubTotal        = new System.Windows.Forms.TextBox();
            this.lblDescuento       = new System.Windows.Forms.Label();
            this.txtDescuento       = new System.Windows.Forms.TextBox();
            this.lblIGV             = new System.Windows.Forms.Label();
            this.txtIGV             = new System.Windows.Forms.TextBox();
            this.lblLineaDivisora2  = new System.Windows.Forms.Label();
            this.lblTotal           = new System.Windows.Forms.Label();
            this.txtTotal           = new System.Windows.Forms.TextBox();
            this.lblObservaciones   = new System.Windows.Forms.Label();
            this.txtObservaciones   = new System.Windows.Forms.TextBox();

            // Footer
            this.pnlFooterDetalle   = new System.Windows.Forms.Panel();
            this.btnImprimir        = new System.Windows.Forms.Button();
            this.btnCerrar          = new System.Windows.Forms.Button();

            // ── SuspendLayouts ────────────────────────────────────────────────
            this.pnlHeaderDetalle.SuspendLayout();
            this.pnlComprobante.SuspendLayout();
            this.pnlCliente.SuspendLayout();
            this.pnlGridDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleProductos)).BeginInit();
            this.pnlTotalesDetalle.SuspendLayout();
            this.pnlFooterDetalle.SuspendLayout();
            this.SuspendLayout();

            // ══════════════════════════════════════════════════════════════════
            // pnlHeaderDetalle  (Dock=Top, oscuro)
            // ══════════════════════════════════════════════════════════════════
            this.pnlHeaderDetalle.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.pnlHeaderDetalle.Controls.Add(this.lblSubTituloDetalle);
            this.pnlHeaderDetalle.Controls.Add(this.lblTitulo);
            this.pnlHeaderDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderDetalle.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderDetalle.Name = "pnlHeaderDetalle";
            this.pnlHeaderDetalle.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.pnlHeaderDetalle.Size = new System.Drawing.Size(860, 68);
            this.pnlHeaderDetalle.TabIndex = 0;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(16, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.TabIndex = 139;
            this.lblTitulo.Text = "Detalle de Venta";

            this.lblSubTituloDetalle.AutoSize = true;
            this.lblSubTituloDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTituloDetalle.ForeColor = System.Drawing.Color.FromArgb(180, 190, 190);
            this.lblSubTituloDetalle.Location = new System.Drawing.Point(18, 40);
            this.lblSubTituloDetalle.Name = "lblSubTituloDetalle";
            this.lblSubTituloDetalle.TabIndex = 140;
            this.lblSubTituloDetalle.Text = "";

            // ══════════════════════════════════════════════════════════════════
            // pnlFooterDetalle  (Dock=Bottom)
            // ══════════════════════════════════════════════════════════════════
            this.pnlFooterDetalle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlFooterDetalle.Controls.Add(this.btnCerrar);
            this.pnlFooterDetalle.Controls.Add(this.btnImprimir);
            this.pnlFooterDetalle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterDetalle.Name = "pnlFooterDetalle";
            this.pnlFooterDetalle.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlFooterDetalle.Size = new System.Drawing.Size(860, 56);
            this.pnlFooterDetalle.TabIndex = 10;

            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(16, 10);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(140, 36);
            this.btnImprimir.TabIndex = 10018;
            this.btnImprimir.Text = "\U0001F5A8\uFE0F Reimprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;

            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(736, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(108, 36);
            this.btnCerrar.TabIndex = 10017;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;

            // ══════════════════════════════════════════════════════════════════
            // pnlTotalesDetalle  (Dock=Bottom, encima del footer)
            // ══════════════════════════════════════════════════════════════════
            this.pnlTotalesDetalle.BackColor = System.Drawing.Color.White;
            this.pnlTotalesDetalle.Controls.Add(this.txtObservaciones);
            this.pnlTotalesDetalle.Controls.Add(this.lblObservaciones);
            this.pnlTotalesDetalle.Controls.Add(this.lblLineaDivisora2);
            this.pnlTotalesDetalle.Controls.Add(this.txtTotal);
            this.pnlTotalesDetalle.Controls.Add(this.lblTotal);
            this.pnlTotalesDetalle.Controls.Add(this.txtIGV);
            this.pnlTotalesDetalle.Controls.Add(this.lblIGV);
            this.pnlTotalesDetalle.Controls.Add(this.txtDescuento);
            this.pnlTotalesDetalle.Controls.Add(this.lblDescuento);
            this.pnlTotalesDetalle.Controls.Add(this.txtSubTotal);
            this.pnlTotalesDetalle.Controls.Add(this.lblSubTotal);
            this.pnlTotalesDetalle.Controls.Add(this.txtVuelto);
            this.pnlTotalesDetalle.Controls.Add(this.lblVuelto);
            this.pnlTotalesDetalle.Controls.Add(this.txtRecibido);
            this.pnlTotalesDetalle.Controls.Add(this.lblRecibido);
            this.pnlTotalesDetalle.Controls.Add(this.txtMetodoPago);
            this.pnlTotalesDetalle.Controls.Add(this.lblMetodoPago);
            this.pnlTotalesDetalle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotalesDetalle.Name = "pnlTotalesDetalle";
            this.pnlTotalesDetalle.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlTotalesDetalle.Size = new System.Drawing.Size(860, 130);
            this.pnlTotalesDetalle.TabIndex = 9;

            // Lado izquierdo: método pago, recibido, vuelto, observaciones
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMetodoPago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMetodoPago.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblMetodoPago.Location = new System.Drawing.Point(16, 14);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.TabIndex = 151;
            this.lblMetodoPago.Text = "Método de Pago:";

            this.txtMetodoPago.BackColor = System.Drawing.Color.White;
            this.txtMetodoPago.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMetodoPago.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtMetodoPago.Location = new System.Drawing.Point(130, 12);
            this.txtMetodoPago.Multiline = true;
            this.txtMetodoPago.Name = "txtMetodoPago";
            this.txtMetodoPago.ReadOnly = true;
            this.txtMetodoPago.Size = new System.Drawing.Size(160, 20);
            this.txtMetodoPago.TabIndex = 10031;
            this.txtMetodoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;

            this.lblRecibido.AutoSize = true;
            this.lblRecibido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRecibido.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRecibido.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblRecibido.Location = new System.Drawing.Point(16, 40);
            this.lblRecibido.Name = "lblRecibido";
            this.lblRecibido.TabIndex = 149;
            this.lblRecibido.Text = "Recibido:";

            this.txtRecibido.BackColor = System.Drawing.Color.White;
            this.txtRecibido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRecibido.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRecibido.Location = new System.Drawing.Point(130, 38);
            this.txtRecibido.Multiline = true;
            this.txtRecibido.Name = "txtRecibido";
            this.txtRecibido.ReadOnly = true;
            this.txtRecibido.Size = new System.Drawing.Size(110, 20);
            this.txtRecibido.TabIndex = 10025;
            this.txtRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblVuelto.AutoSize = true;
            this.lblVuelto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblVuelto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVuelto.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblVuelto.Location = new System.Drawing.Point(16, 64);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.TabIndex = 150;
            this.lblVuelto.Text = "Vuelto:";

            this.txtVuelto.BackColor = System.Drawing.Color.White;
            this.txtVuelto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVuelto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtVuelto.Location = new System.Drawing.Point(130, 62);
            this.txtVuelto.Multiline = true;
            this.txtVuelto.Name = "txtVuelto";
            this.txtVuelto.ReadOnly = true;
            this.txtVuelto.Size = new System.Drawing.Size(110, 20);
            this.txtVuelto.TabIndex = 10026;
            this.txtVuelto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblObservaciones.Location = new System.Drawing.Point(16, 92);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.TabIndex = 156;
            this.lblObservaciones.Text = "Observaciones:";

            this.txtObservaciones.BackColor = System.Drawing.Color.White;
            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtObservaciones.Location = new System.Drawing.Point(130, 90);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(240, 26);
            this.txtObservaciones.TabIndex = 157;

            // Lado derecho: totales
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubTotal.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblSubTotal.Location = new System.Drawing.Point(478, 14);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.TabIndex = 145;
            this.lblSubTotal.Text = "SUBTOTAL:";

            this.txtSubTotal.BackColor = System.Drawing.Color.White;
            this.txtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSubTotal.Location = new System.Drawing.Point(680, 12);
            this.txtSubTotal.Multiline = true;
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(150, 20);
            this.txtSubTotal.TabIndex = 10027;
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblDescuento.AutoSize = true;
            this.lblDescuento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDescuento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescuento.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblDescuento.Location = new System.Drawing.Point(478, 38);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.TabIndex = 146;
            this.lblDescuento.Text = "DESCUENTO:";

            this.txtDescuento.BackColor = System.Drawing.Color.White;
            this.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescuento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescuento.Location = new System.Drawing.Point(680, 36);
            this.txtDescuento.Multiline = true;
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.ReadOnly = true;
            this.txtDescuento.Size = new System.Drawing.Size(150, 20);
            this.txtDescuento.TabIndex = 10028;
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblIGV.AutoSize = true;
            this.lblIGV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblIGV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIGV.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblIGV.Location = new System.Drawing.Point(478, 62);
            this.lblIGV.Name = "lblIGV";
            this.lblIGV.TabIndex = 147;
            this.lblIGV.Text = "IGV (18%):";

            this.txtIGV.BackColor = System.Drawing.Color.White;
            this.txtIGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIGV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIGV.Location = new System.Drawing.Point(680, 60);
            this.txtIGV.Multiline = true;
            this.txtIGV.Name = "txtIGV";
            this.txtIGV.ReadOnly = true;
            this.txtIGV.Size = new System.Drawing.Size(150, 20);
            this.txtIGV.TabIndex = 10029;
            this.txtIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblLineaDivisora2.BackColor = System.Drawing.Color.FromArgb(223, 228, 234);
            this.lblLineaDivisora2.ForeColor = System.Drawing.Color.FromArgb(223, 228, 234);
            this.lblLineaDivisora2.Location = new System.Drawing.Point(478, 88);
            this.lblLineaDivisora2.Name = "lblLineaDivisora2";
            this.lblLineaDivisora2.Size = new System.Drawing.Size(356, 1);
            this.lblLineaDivisora2.TabIndex = 158;

            this.lblTotal.AutoSize = true;
            this.lblTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblTotal.Location = new System.Drawing.Point(478, 96);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.TabIndex = 148;
            this.lblTotal.Text = "TOTAL:";

            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.txtTotal.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.txtTotal.Location = new System.Drawing.Point(600, 92);
            this.txtTotal.Multiline = true;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(234, 26);
            this.txtTotal.TabIndex = 10030;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // ══════════════════════════════════════════════════════════════════
            // pnlGridDetalle  (Dock=Fill — fila central)
            // ══════════════════════════════════════════════════════════════════
            this.pnlGridDetalle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlGridDetalle.Controls.Add(this.dgvDetalleProductos);
            this.pnlGridDetalle.Controls.Add(this.lblSubTitulo3);
            this.pnlGridDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridDetalle.Name = "pnlGridDetalle";
            this.pnlGridDetalle.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.pnlGridDetalle.TabIndex = 8;

            this.lblSubTitulo3.AutoSize = true;
            this.lblSubTitulo3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubTitulo3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSubTitulo3.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblSubTitulo3.Location = new System.Drawing.Point(12, 8);
            this.lblSubTitulo3.Name = "lblSubTitulo3";
            this.lblSubTitulo3.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblSubTitulo3.TabIndex = 140;
            this.lblSubTitulo3.Text = "🛒  DETALLE DE PRODUCTOS";

            // ── dgvDetalleProductos ──────────────────────────────────────────
            dgvHeaderStyle.BackColor    = System.Drawing.Color.FromArgb(45, 52, 54);
            dgvHeaderStyle.ForeColor    = System.Drawing.Color.White;
            dgvHeaderStyle.Font         = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            dgvHeaderStyle.SelectionForeColor = System.Drawing.Color.White;

            dgvDefaultStyle.BackColor   = System.Drawing.Color.White;
            dgvDefaultStyle.ForeColor   = System.Drawing.Color.FromArgb(45, 52, 54);
            dgvDefaultStyle.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            dgvDefaultStyle.SelectionBackColor = System.Drawing.Color.White;
            dgvDefaultStyle.SelectionForeColor = System.Drawing.Color.FromArgb(45, 52, 54);

            this.dgvDetalleProductos.AutoSizeRowsMode         = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.dgvDetalleProductos.BackgroundColor          = System.Drawing.Color.White;
            this.dgvDetalleProductos.BorderStyle              = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalleProductos.CellBorderStyle          = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDetalleProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDetalleProductos.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvDetalleProductos.ColumnHeadersHeight      = 36;
            this.dgvDetalleProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetalleProductos.DefaultCellStyle         = dgvDefaultStyle;
            this.dgvDetalleProductos.Dock                     = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalleProductos.EnableHeadersVisualStyles= false;
            this.dgvDetalleProductos.GridColor                = System.Drawing.Color.FromArgb(235, 237, 240);
            this.dgvDetalleProductos.Name                     = "dgvDetalleProductos";
            this.dgvDetalleProductos.RowHeadersVisible        = false;
            this.dgvDetalleProductos.RowTemplate.Height       = 40;
            this.dgvDetalleProductos.TabIndex                 = 144;
            this.dgvDetalleProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNumero, this.colProductoDV, this.colPresentacionDV,
                this.colCantidad, this.colPrecioUnitario, this.colSubTotal });

            this.colNumero.HeaderText = "#";
            this.colNumero.Name       = "colNumero";
            this.colNumero.ReadOnly   = true;
            this.colNumero.Width      = 50;

            this.colProductoDV.AutoSizeMode  = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProductoDV.MinimumWidth  = 200;
            this.colProductoDV.HeaderText    = "Productos";
            this.colProductoDV.Name          = "colProductoDV";
            this.colProductoDV.ReadOnly      = true;

            this.colPresentacionDV.HeaderText = "Presentacion";
            this.colPresentacionDV.Name       = "colPresentacionDV";
            this.colPresentacionDV.ReadOnly   = true;
            this.colPresentacionDV.Resizable  = System.Windows.Forms.DataGridViewTriState.True;
            this.colPresentacionDV.SortMode   = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPresentacionDV.Width      = 180;

            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name       = "colCantidad";
            this.colCantidad.ReadOnly   = true;
            this.colCantidad.Width      = 100;

            this.colPrecioUnitario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPrecioUnitario.FillWeight   = 90F;
            this.colPrecioUnitario.HeaderText   = "Precio Unit.";
            this.colPrecioUnitario.Name         = "colPrecioUnitario";
            this.colPrecioUnitario.ReadOnly     = true;
            this.colPrecioUnitario.Width        = 130;

            this.colSubTotal.HeaderText = "SubTotal";
            this.colSubTotal.Name       = "colSubTotal";
            this.colSubTotal.ReadOnly   = true;
            this.colSubTotal.Width      = 130;

            // ══════════════════════════════════════════════════════════════════
            // pnlComprobante  (Dock=Top — comprobante info)
            // ══════════════════════════════════════════════════════════════════
            this.pnlComprobante.BackColor = System.Drawing.Color.FromArgb(250, 251, 253);
            this.pnlComprobante.Controls.Add(this.txtEncargado);
            this.pnlComprobante.Controls.Add(this.txtEstado);
            this.pnlComprobante.Controls.Add(this.txtHora);
            this.pnlComprobante.Controls.Add(this.txtFecha);
            this.pnlComprobante.Controls.Add(this.txtNumeroSerie);
            this.pnlComprobante.Controls.Add(this.txtTipoComprobante);
            this.pnlComprobante.Controls.Add(this.lblNumeroSerie);
            this.pnlComprobante.Controls.Add(this.lblEstado);
            this.pnlComprobante.Controls.Add(this.lblHora);
            this.pnlComprobante.Controls.Add(this.lblEncargado);
            this.pnlComprobante.Controls.Add(this.lblFecha);
            this.pnlComprobante.Controls.Add(this.lblTipoComprobante);
            this.pnlComprobante.Controls.Add(this.lblSubTitulo);
            this.pnlComprobante.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlComprobante.Name = "pnlComprobante";
            this.pnlComprobante.Padding = new System.Windows.Forms.Padding(16, 10, 16, 8);
            this.pnlComprobante.Size = new System.Drawing.Size(860, 110);
            this.pnlComprobante.TabIndex = 138;

            this.lblSubTitulo.AutoSize = true;
            this.lblSubTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblSubTitulo.Location = new System.Drawing.Point(16, 10);
            this.lblSubTitulo.Name = "lblSubTitulo";
            this.lblSubTitulo.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblSubTitulo.TabIndex = 12;
            this.lblSubTitulo.Text = "📋  COMPROBANTE";

            // Fila 1: Tipo / N° Serie
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipoComprobante.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblTipoComprobante.Location = new System.Drawing.Point(16, 32);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.TabIndex = 130;
            this.lblTipoComprobante.Text = "Tipo:";

            this.txtTipoComprobante.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtTipoComprobante.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtTipoComprobante.Location = new System.Drawing.Point(90, 30);
            this.txtTipoComprobante.Name = "txtTipoComprobante";
            this.txtTipoComprobante.ReadOnly = true;
            this.txtTipoComprobante.Size = new System.Drawing.Size(160, 18);
            this.txtTipoComprobante.TabIndex = 200;

            this.lblNumeroSerie.AutoSize = true;
            this.lblNumeroSerie.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNumeroSerie.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblNumeroSerie.Location = new System.Drawing.Point(290, 32);
            this.lblNumeroSerie.Name = "lblNumeroSerie";
            this.lblNumeroSerie.TabIndex = 140;
            this.lblNumeroSerie.Text = "Serie-Número:";

            this.txtNumeroSerie.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtNumeroSerie.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumeroSerie.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtNumeroSerie.Location = new System.Drawing.Point(390, 30);
            this.txtNumeroSerie.Name = "txtNumeroSerie";
            this.txtNumeroSerie.ReadOnly = true;
            this.txtNumeroSerie.Size = new System.Drawing.Size(180, 18);
            this.txtNumeroSerie.TabIndex = 201;

            // Fila 2: Fecha / Hora / Estado / Encargado
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblFecha.Location = new System.Drawing.Point(16, 60);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.TabIndex = 133;
            this.lblFecha.Text = "Fecha:";

            this.txtFecha.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFecha.Location = new System.Drawing.Point(90, 58);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(160, 18);
            this.txtFecha.TabIndex = 202;

            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHora.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblHora.Location = new System.Drawing.Point(290, 60);
            this.lblHora.Name = "lblHora";
            this.lblHora.TabIndex = 138;
            this.lblHora.Text = "Hora:";

            this.txtHora.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtHora.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHora.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtHora.Location = new System.Drawing.Point(390, 58);
            this.txtHora.Name = "txtHora";
            this.txtHora.ReadOnly = true;
            this.txtHora.Size = new System.Drawing.Size(140, 18);
            this.txtHora.TabIndex = 203;

            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblEstado.Location = new System.Drawing.Point(570, 60);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.TabIndex = 139;
            this.lblEstado.Text = "Estado:";

            this.txtEstado.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtEstado.Location = new System.Drawing.Point(630, 58);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(130, 18);
            this.txtEstado.TabIndex = 204;

            this.lblEncargado.AutoSize = true;
            this.lblEncargado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEncargado.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblEncargado.Location = new System.Drawing.Point(16, 86);
            this.lblEncargado.Name = "lblEncargado";
            this.lblEncargado.TabIndex = 136;
            this.lblEncargado.Text = "Encargado:";

            this.txtEncargado.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtEncargado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEncargado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtEncargado.Location = new System.Drawing.Point(90, 84);
            this.txtEncargado.Name = "txtEncargado";
            this.txtEncargado.ReadOnly = true;
            this.txtEncargado.Size = new System.Drawing.Size(280, 18);
            this.txtEncargado.TabIndex = 205;

            // ══════════════════════════════════════════════════════════════════
            // pnlCliente  (Dock=Top — info del cliente)
            // ══════════════════════════════════════════════════════════════════
            this.pnlCliente.BackColor = System.Drawing.Color.FromArgb(250, 251, 253);
            this.pnlCliente.Controls.Add(this.txtDireccion);
            this.pnlCliente.Controls.Add(this.txtTelefono);
            this.pnlCliente.Controls.Add(this.txtNombreRazonSocial);
            this.pnlCliente.Controls.Add(this.txtDNIRUC);
            this.pnlCliente.Controls.Add(this.lblDireccion);
            this.pnlCliente.Controls.Add(this.lblTelefono);
            this.pnlCliente.Controls.Add(this.lblNombreRazonSocial);
            this.pnlCliente.Controls.Add(this.lblDNIRUC);
            this.pnlCliente.Controls.Add(this.lblSubTitulo2);
            this.pnlCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCliente.Name = "pnlCliente";
            this.pnlCliente.Padding = new System.Windows.Forms.Padding(16, 6, 16, 6);
            this.pnlCliente.Size = new System.Drawing.Size(860, 90);
            this.pnlCliente.TabIndex = 143;

            this.lblSubTitulo2.AutoSize = true;
            this.lblSubTitulo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubTitulo2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSubTitulo2.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblSubTitulo2.Location = new System.Drawing.Point(16, 8);
            this.lblSubTitulo2.Name = "lblSubTitulo2";
            this.lblSubTitulo2.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblSubTitulo2.TabIndex = 12;
            this.lblSubTitulo2.Text = "👤  CLIENTE";

            this.lblNombreRazonSocial.AutoSize = true;
            this.lblNombreRazonSocial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombreRazonSocial.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblNombreRazonSocial.Location = new System.Drawing.Point(16, 30);
            this.lblNombreRazonSocial.Name = "lblNombreRazonSocial";
            this.lblNombreRazonSocial.TabIndex = 136;
            this.lblNombreRazonSocial.Text = "Nombre:";

            this.txtNombreRazonSocial.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtNombreRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreRazonSocial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtNombreRazonSocial.Location = new System.Drawing.Point(90, 28);
            this.txtNombreRazonSocial.Name = "txtNombreRazonSocial";
            this.txtNombreRazonSocial.ReadOnly = true;
            this.txtNombreRazonSocial.Size = new System.Drawing.Size(270, 18);
            this.txtNombreRazonSocial.TabIndex = 206;

            this.lblDNIRUC.AutoSize = true;
            this.lblDNIRUC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDNIRUC.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblDNIRUC.Location = new System.Drawing.Point(400, 30);
            this.lblDNIRUC.Name = "lblDNIRUC";
            this.lblDNIRUC.TabIndex = 133;
            this.lblDNIRUC.Text = "DNI/RUC:";

            this.txtDNIRUC.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtDNIRUC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDNIRUC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDNIRUC.Location = new System.Drawing.Point(468, 28);
            this.txtDNIRUC.Name = "txtDNIRUC";
            this.txtDNIRUC.ReadOnly = true;
            this.txtDNIRUC.Size = new System.Drawing.Size(140, 18);
            this.txtDNIRUC.TabIndex = 207;

            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblTelefono.Location = new System.Drawing.Point(16, 56);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.TabIndex = 138;
            this.lblTelefono.Text = "Teléfono:";

            this.txtTelefono.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTelefono.Location = new System.Drawing.Point(90, 54);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(160, 18);
            this.txtTelefono.TabIndex = 208;

            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblDireccion.Location = new System.Drawing.Point(290, 56);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.TabIndex = 139;
            this.lblDireccion.Text = "Dirección:";

            this.txtDireccion.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDireccion.Location = new System.Drawing.Point(370, 54);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(250, 18);
            this.txtDireccion.TabIndex = 209;

            // ══════════════════════════════════════════════════════════════════
            // FormDetalleVenta
            // ══════════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(860, 600);
            this.Controls.Add(this.pnlGridDetalle);
            this.Controls.Add(this.pnlTotalesDetalle);
            this.Controls.Add(this.pnlCliente);
            this.Controls.Add(this.pnlComprobante);
            this.Controls.Add(this.pnlFooterDetalle);
            this.Controls.Add(this.pnlHeaderDetalle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDetalleVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";

            // ── ResumeLayouts ─────────────────────────────────────────────────
            this.pnlHeaderDetalle.ResumeLayout(false);
            this.pnlHeaderDetalle.PerformLayout();
            this.pnlComprobante.ResumeLayout(false);
            this.pnlComprobante.PerformLayout();
            this.pnlCliente.ResumeLayout(false);
            this.pnlCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleProductos)).EndInit();
            this.pnlGridDetalle.ResumeLayout(false);
            this.pnlGridDetalle.PerformLayout();
            this.pnlTotalesDetalle.ResumeLayout(false);
            this.pnlTotalesDetalle.PerformLayout();
            this.pnlFooterDetalle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Header
        private System.Windows.Forms.Panel   pnlHeaderDetalle;
        private System.Windows.Forms.Label   lblTitulo;
        private System.Windows.Forms.Label   lblSubTituloDetalle;

        // Comprobante panel
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

        // Cliente panel
        private System.Windows.Forms.Panel   pnlCliente;
        private System.Windows.Forms.Label   lblSubTitulo2;
        private System.Windows.Forms.Label   lblNombreRazonSocial;
        private System.Windows.Forms.TextBox txtNombreRazonSocial;
        private System.Windows.Forms.Label   lblDNIRUC;
        private System.Windows.Forms.TextBox txtDNIRUC;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubTotal;

        // Totales
        private System.Windows.Forms.Panel   pnlTotalesDetalle;
        private System.Windows.Forms.Label   lblMetodoPago;
        private System.Windows.Forms.TextBox txtMetodoPago;
        private System.Windows.Forms.Label   lblRecibido;
        private System.Windows.Forms.TextBox txtRecibido;
        private System.Windows.Forms.Label   lblVuelto;
        private System.Windows.Forms.TextBox txtVuelto;
        private System.Windows.Forms.Label   lblSubTotal;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label   lblDescuento;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label   lblIGV;
        private System.Windows.Forms.TextBox txtIGV;
        private System.Windows.Forms.Label   lblLineaDivisora2;
        private System.Windows.Forms.Label   lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label   lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;

        // Footer
        private System.Windows.Forms.Panel   pnlFooterDetalle;
        private System.Windows.Forms.Button  btnImprimir;
        private System.Windows.Forms.Button  btnCerrar;
    }
}
