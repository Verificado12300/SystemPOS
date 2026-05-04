namespace SistemaPOS.Forms.Compras
{
    partial class FormHistorialCompras
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
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle      = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvDefaultStyle     = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvAltStyle         = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvActionStyle      = new System.Windows.Forms.DataGridViewCellStyle();

            // ── Declarations ──────────────────────────────────────────────────
            // Header
            this.pnlHeader              = new System.Windows.Forms.Panel();
            this.lblTitulo              = new System.Windows.Forms.Label();
            this.lblHeaderSub           = new System.Windows.Forms.Label();

            // Filter bar
            this.pnlFiltro              = new System.Windows.Forms.Panel();
            this.pnlFiltroSep           = new System.Windows.Forms.Panel();
            this.lblDesde               = new System.Windows.Forms.Label();
            this.dtpDesde               = new System.Windows.Forms.DateTimePicker();
            this.lblHasta               = new System.Windows.Forms.Label();
            this.dtpHasta               = new System.Windows.Forms.DateTimePicker();
            this.lblProveedor           = new System.Windows.Forms.Label();
            this.cmbProveedor           = new System.Windows.Forms.ComboBox();
            this.lblEstado              = new System.Windows.Forms.Label();
            this.cmbEstado              = new System.Windows.Forms.ComboBox();
            this.lblTipoComprobante     = new System.Windows.Forms.Label();
            this.cmbTipoComprobante     = new System.Windows.Forms.ComboBox();
            this.lblNumComprobante      = new System.Windows.Forms.Label();
            this.txtNumComprobante      = new System.Windows.Forms.TextBox();
            this.btnBuscar              = new System.Windows.Forms.Button();
            this.btnLimpiar             = new System.Windows.Forms.Button();
            this.lblSubTitulo           = new System.Windows.Forms.Label();

            // Grid
            this.pnlListado             = new System.Windows.Forms.Panel();
            this.dgvCompras             = new System.Windows.Forms.DataGridView();
            this.colNumero              = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaHora           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComprobante         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProveedor           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItems               = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMetodoPago          = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal               = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado              = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVerDetalle          = new System.Windows.Forms.DataGridViewImageColumn();
            this.colImprimir            = new System.Windows.Forms.DataGridViewImageColumn();
            this.colAnular              = new System.Windows.Forms.DataGridViewImageColumn();

            // Footer
            this.pnlFooter              = new System.Windows.Forms.Panel();
            this.pnlFooterSep           = new System.Windows.Forms.Panel();
            this.lblOperaciones         = new System.Windows.Forms.Label();
            this.lblEfectivo            = new System.Windows.Forms.Label();
            this.txtEfectivoCantidad    = new System.Windows.Forms.TextBox();
            this.lbllblYape             = new System.Windows.Forms.Label();
            this.txtYapeCantidad        = new System.Windows.Forms.TextBox();
            this.lblTransferencia       = new System.Windows.Forms.Label();
            this.txtTransferenciaCantidad = new System.Windows.Forms.TextBox();
            this.lblCredito             = new System.Windows.Forms.Label();
            this.txtCreditoCantidad     = new System.Windows.Forms.TextBox();
            this.lblSeparador           = new System.Windows.Forms.Label();
            this.lblTotal               = new System.Windows.Forms.Label();
            this.txtTotalCantidad       = new System.Windows.Forms.TextBox();
            this.lblPorPagar            = new System.Windows.Forms.Label();
            this.txtPorPagar            = new System.Windows.Forms.TextBox();
            this.btnExportar            = new System.Windows.Forms.Button();
            this.btnCerrar              = new System.Windows.Forms.Button();
            this.lblSubTitulo2          = new System.Windows.Forms.Label();

            // ── SuspendLayouts ────────────────────────────────────────────────
            this.pnlHeader.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            this.pnlListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // ══════════════════════════════════════════════════════════════════
            // pnlHeader  (Dock=Top — gradiente oscuro, más alto para respirar)
            // ══════════════════════════════════════════════════════════════════
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 36, 40);
            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1280, 80);
            this.pnlHeader.TabIndex = 0;

            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(22, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(520, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "📋  Historial de Compras";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(160, 175, 180);
            this.lblHeaderSub.Location = new System.Drawing.Point(24, 52);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.TabIndex = 1;
            this.lblHeaderSub.Text = "Consulta, filtra y gestiona todas las compras registradas";

            // ══════════════════════════════════════════════════════════════════
            // pnlFiltro  (Dock=Top — panel de filtros con 2 filas)
            // ══════════════════════════════════════════════════════════════════
            this.pnlFiltro.BackColor = System.Drawing.Color.FromArgb(252, 252, 253);
            this.pnlFiltro.Padding = new System.Windows.Forms.Padding(16, 8, 16, 0);
            this.pnlFiltro.Controls.Add(this.pnlFiltroSep);
            this.pnlFiltro.Controls.Add(this.btnBuscar);
            this.pnlFiltro.Controls.Add(this.btnLimpiar);
            this.pnlFiltro.Controls.Add(this.lblEstado);
            this.pnlFiltro.Controls.Add(this.cmbEstado);
            this.pnlFiltro.Controls.Add(this.cmbProveedor);
            this.pnlFiltro.Controls.Add(this.lblProveedor);
            this.pnlFiltro.Controls.Add(this.lblSubTitulo);
            this.pnlFiltro.Controls.Add(this.cmbTipoComprobante);
            this.pnlFiltro.Controls.Add(this.lblTipoComprobante);
            this.pnlFiltro.Controls.Add(this.txtNumComprobante);
            this.pnlFiltro.Controls.Add(this.lblNumComprobante);
            this.pnlFiltro.Controls.Add(this.dtpHasta);
            this.pnlFiltro.Controls.Add(this.lblHasta);
            this.pnlFiltro.Controls.Add(this.dtpDesde);
            this.pnlFiltro.Controls.Add(this.lblDesde);
            this.pnlFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltro.Location = new System.Drawing.Point(25, 104);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(1230, 76);
            this.pnlFiltro.TabIndex = 1;

            // Separador inferior del panel de filtros
            this.pnlFiltroSep.BackColor = System.Drawing.Color.FromArgb(218, 220, 224);
            this.pnlFiltroSep.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFiltroSep.Location = new System.Drawing.Point(0, 125);
            this.pnlFiltroSep.Name = "pnlFiltroSep";
            this.pnlFiltroSep.Size = new System.Drawing.Size(1280, 1);
            this.pnlFiltroSep.TabIndex = 200;

            // lblSubTitulo — compatibilidad (Visible=false)
            this.lblSubTitulo.AutoSize = true;
            this.lblSubTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblSubTitulo.Name = "lblSubTitulo";
            this.lblSubTitulo.TabIndex = 115;
            this.lblSubTitulo.Text = "";
            this.lblSubTitulo.Visible = false;

            // ── Fila 1: DESDE · HASTA · PROVEEDOR · ESTADO ───────────────────
            // Labels uppercase pequeños (estilo moderno)
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblDesde.Location = new System.Drawing.Point(18, 14);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.TabIndex = 10011;
            this.lblDesde.Text = "DESDE";

            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpDesde.Location = new System.Drawing.Point(18, 30);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(118, 24);
            this.dtpDesde.TabIndex = 10010;

            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblHasta.Location = new System.Drawing.Point(150, 14);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.TabIndex = 10013;
            this.lblHasta.Text = "HASTA";

            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpHasta.Location = new System.Drawing.Point(150, 30);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(118, 24);
            this.dtpHasta.TabIndex = 10012;

            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblProveedor.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblProveedor.Location = new System.Drawing.Point(286, 14);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.TabIndex = 132;
            this.lblProveedor.Text = "PROVEEDOR";

            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProveedor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbProveedor.Location = new System.Drawing.Point(286, 30);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(230, 24);
            this.cmbProveedor.TabIndex = 133;

            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblEstado.Location = new System.Drawing.Point(530, 14);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.TabIndex = 135;
            this.lblEstado.Text = "ESTADO";

            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbEstado.Location = new System.Drawing.Point(530, 30);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(165, 24);
            this.cmbEstado.TabIndex = 134;

            // ── Fila 1 cont.: TIPO COMPROBANTE · N° COMPROBANTE ─────────────────
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblTipoComprobante.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblTipoComprobante.Location = new System.Drawing.Point(608, 14);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.TabIndex = 121;
            this.lblTipoComprobante.Text = "TIPO COMPROBANTE";

            this.cmbTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbTipoComprobante.Location = new System.Drawing.Point(608, 30);
            this.cmbTipoComprobante.Name = "cmbTipoComprobante";
            this.cmbTipoComprobante.Size = new System.Drawing.Size(150, 24);
            this.cmbTipoComprobante.TabIndex = 122;

            this.lblNumComprobante.AutoSize = true;
            this.lblNumComprobante.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblNumComprobante.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblNumComprobante.Location = new System.Drawing.Point(770, 14);
            this.lblNumComprobante.Name = "lblNumComprobante";
            this.lblNumComprobante.TabIndex = 117;
            this.lblNumComprobante.Text = "N° COMPROBANTE";

            this.txtNumComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumComprobante.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNumComprobante.Location = new System.Drawing.Point(770, 30);
            this.txtNumComprobante.Name = "txtNumComprobante";
            this.txtNumComprobante.Size = new System.Drawing.Size(150, 24);
            this.txtNumComprobante.TabIndex = 116;

            // ── Botones (anclados a la derecha) ───────────────────────────────
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(50, 78, 210);
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(1102, 26);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(120, 30);
            this.btnBuscar.TabIndex = 141;
            this.btnBuscar.Text = "🔍  Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;

            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(210, 214, 220);
            this.btnLimpiar.FlatAppearance.BorderSize = 1;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.btnLimpiar.Location = new System.Drawing.Point(968, 26);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(124, 30);
            this.btnLimpiar.TabIndex = 142;
            this.btnLimpiar.Text = "✕  Limpiar filtros";
            this.btnLimpiar.UseVisualStyleBackColor = false;

            // ══════════════════════════════════════════════════════════════════
            // pnlFooter  (Dock=Bottom — resumen financiero)
            // ══════════════════════════════════════════════════════════════════
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.pnlFooterSep);
            this.pnlFooter.Controls.Add(this.lblSubTitulo2);
            this.pnlFooter.Controls.Add(this.lblOperaciones);
            this.pnlFooter.Controls.Add(this.lblEfectivo);
            this.pnlFooter.Controls.Add(this.txtEfectivoCantidad);
            this.pnlFooter.Controls.Add(this.lbllblYape);
            this.pnlFooter.Controls.Add(this.txtYapeCantidad);
            this.pnlFooter.Controls.Add(this.lblTransferencia);
            this.pnlFooter.Controls.Add(this.txtTransferenciaCantidad);
            this.pnlFooter.Controls.Add(this.lblCredito);
            this.pnlFooter.Controls.Add(this.txtCreditoCantidad);
            this.pnlFooter.Controls.Add(this.lblSeparador);
            this.pnlFooter.Controls.Add(this.lblTotal);
            this.pnlFooter.Controls.Add(this.txtTotalCantidad);
            this.pnlFooter.Controls.Add(this.lblPorPagar);
            this.pnlFooter.Controls.Add(this.txtPorPagar);
            this.pnlFooter.Controls.Add(this.btnExportar);
            this.pnlFooter.Controls.Add(this.btnCerrar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1280, 76);
            this.pnlFooter.TabIndex = 3;

            // Separador superior del footer
            this.pnlFooterSep.BackColor = System.Drawing.Color.FromArgb(218, 220, 224);
            this.pnlFooterSep.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFooterSep.Location = new System.Drawing.Point(0, 0);
            this.pnlFooterSep.Name = "pnlFooterSep";
            this.pnlFooterSep.Size = new System.Drawing.Size(1280, 1);
            this.pnlFooterSep.TabIndex = 200;

            // lblSubTitulo2 — compatibilidad (Visible=false)
            this.lblSubTitulo2.AutoSize = true;
            this.lblSubTitulo2.Location = new System.Drawing.Point(0, 0);
            this.lblSubTitulo2.Name = "lblSubTitulo2";
            this.lblSubTitulo2.TabIndex = 115;
            this.lblSubTitulo2.Text = "";
            this.lblSubTitulo2.Visible = false;

            // lblOperaciones — conteo de compras
            this.lblOperaciones.AutoSize = true;
            this.lblOperaciones.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblOperaciones.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblOperaciones.Location = new System.Drawing.Point(18, 8);
            this.lblOperaciones.Name = "lblOperaciones";
            this.lblOperaciones.TabIndex = 161;
            this.lblOperaciones.Text = "0 compras del período";

            // ── Desglose de pagos (fila inferior, Y=36) ───────────────────────
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEfectivo.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblEfectivo.Location = new System.Drawing.Point(18, 38);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.TabIndex = 168;
            this.lblEfectivo.Text = "Efectivo";

            this.txtEfectivoCantidad.BackColor = System.Drawing.Color.White;
            this.txtEfectivoCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEfectivoCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtEfectivoCantidad.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.txtEfectivoCantidad.Location = new System.Drawing.Point(18, 52);
            this.txtEfectivoCantidad.Name = "txtEfectivoCantidad";
            this.txtEfectivoCantidad.ReadOnly = true;
            this.txtEfectivoCantidad.Size = new System.Drawing.Size(88, 18);
            this.txtEfectivoCantidad.TabIndex = 10026;
            this.txtEfectivoCantidad.Text = "S/ 0.00";

            this.lbllblYape.AutoSize = true;
            this.lbllblYape.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbllblYape.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lbllblYape.Location = new System.Drawing.Point(118, 38);
            this.lbllblYape.Name = "lbllblYape";
            this.lbllblYape.TabIndex = 163;
            this.lbllblYape.Text = "Yape / Digital";

            this.txtYapeCantidad.BackColor = System.Drawing.Color.White;
            this.txtYapeCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtYapeCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtYapeCantidad.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.txtYapeCantidad.Location = new System.Drawing.Point(118, 52);
            this.txtYapeCantidad.Name = "txtYapeCantidad";
            this.txtYapeCantidad.ReadOnly = true;
            this.txtYapeCantidad.Size = new System.Drawing.Size(88, 18);
            this.txtYapeCantidad.TabIndex = 10027;
            this.txtYapeCantidad.Text = "S/ 0.00";

            this.lblTransferencia.AutoSize = true;
            this.lblTransferencia.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTransferencia.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblTransferencia.Location = new System.Drawing.Point(218, 38);
            this.lblTransferencia.Name = "lblTransferencia";
            this.lblTransferencia.TabIndex = 166;
            this.lblTransferencia.Text = "Transferencia";

            this.txtTransferenciaCantidad.BackColor = System.Drawing.Color.White;
            this.txtTransferenciaCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTransferenciaCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtTransferenciaCantidad.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.txtTransferenciaCantidad.Location = new System.Drawing.Point(218, 52);
            this.txtTransferenciaCantidad.Name = "txtTransferenciaCantidad";
            this.txtTransferenciaCantidad.ReadOnly = true;
            this.txtTransferenciaCantidad.Size = new System.Drawing.Size(88, 18);
            this.txtTransferenciaCantidad.TabIndex = 10028;
            this.txtTransferenciaCantidad.Text = "S/ 0.00";

            this.lblCredito.AutoSize = true;
            this.lblCredito.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCredito.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblCredito.Location = new System.Drawing.Point(318, 38);
            this.lblCredito.Name = "lblCredito";
            this.lblCredito.TabIndex = 167;
            this.lblCredito.Text = "A Crédito";

            this.txtCreditoCantidad.BackColor = System.Drawing.Color.White;
            this.txtCreditoCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCreditoCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtCreditoCantidad.ForeColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.txtCreditoCantidad.Location = new System.Drawing.Point(318, 52);
            this.txtCreditoCantidad.Name = "txtCreditoCantidad";
            this.txtCreditoCantidad.ReadOnly = true;
            this.txtCreditoCantidad.Size = new System.Drawing.Size(88, 18);
            this.txtCreditoCantidad.TabIndex = 10029;
            this.txtCreditoCantidad.Text = "S/ 0.00";

            // ── Separador vertical ────────────────────────────────────────────
            this.lblSeparador.BackColor = System.Drawing.Color.FromArgb(218, 220, 224);
            this.lblSeparador.Location = new System.Drawing.Point(422, 8);
            this.lblSeparador.Name = "lblSeparador";
            this.lblSeparador.Size = new System.Drawing.Size(1, 60);
            this.lblSeparador.TabIndex = 165;

            // ── Sección TOTAL (derecha del separador) ─────────────────────────
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblTotal.Location = new System.Drawing.Point(434, 8);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.TabIndex = 164;
            this.lblTotal.Text = "TOTAL COMPRAS";

            this.txtTotalCantidad.BackColor = System.Drawing.Color.White;
            this.txtTotalCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalCantidad.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.txtTotalCantidad.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.txtTotalCantidad.Location = new System.Drawing.Point(432, 24);
            this.txtTotalCantidad.Name = "txtTotalCantidad";
            this.txtTotalCantidad.ReadOnly = true;
            this.txtTotalCantidad.Size = new System.Drawing.Size(160, 28);
            this.txtTotalCantidad.TabIndex = 10030;
            this.txtTotalCantidad.Text = "S/ 0.00";

            this.lblPorPagar.AutoSize = true;
            this.lblPorPagar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPorPagar.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblPorPagar.Location = new System.Drawing.Point(604, 8);
            this.lblPorPagar.Name = "lblPorPagar";
            this.lblPorPagar.TabIndex = 10017;
            this.lblPorPagar.Text = "POR PAGAR";

            this.txtPorPagar.BackColor = System.Drawing.Color.White;
            this.txtPorPagar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPorPagar.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.txtPorPagar.ForeColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.txtPorPagar.Location = new System.Drawing.Point(602, 24);
            this.txtPorPagar.Name = "txtPorPagar";
            this.txtPorPagar.ReadOnly = true;
            this.txtPorPagar.Size = new System.Drawing.Size(150, 28);
            this.txtPorPagar.TabIndex = 10031;
            this.txtPorPagar.Text = "S/ 0.00";

            // ── Botones (anclados a la derecha) ───────────────────────────────
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.White;
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(210, 214, 220);
            this.btnExportar.FlatAppearance.BorderSize = 1;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.btnExportar.Location = new System.Drawing.Point(1060, 20);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(116, 36);
            this.btnExportar.TabIndex = 10014;
            this.btnExportar.Text = "📥  Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;

            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(200, 60, 45);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1184, 20);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(80, 36);
            this.btnCerrar.TabIndex = 10015;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;

            // ══════════════════════════════════════════════════════════════════
            // pnlListado  (Dock=Fill — área del grid)
            // ══════════════════════════════════════════════════════════════════
            this.pnlListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlListado.BackColor = System.Drawing.Color.FromArgb(244, 246, 250);
            this.pnlListado.Controls.Add(this.dgvCompras);
            this.pnlListado.Location = new System.Drawing.Point(25, 188);
            this.pnlListado.Name = "pnlListado";
            this.pnlListado.Padding = new System.Windows.Forms.Padding(10);
            this.pnlListado.Size = new System.Drawing.Size(1230, 450);
            this.pnlListado.TabIndex = 2;

            // ── dgvCompras ───────────────────────────────────────────────────
            dgvHeaderStyle.BackColor           = System.Drawing.Color.FromArgb(30, 36, 40);
            dgvHeaderStyle.ForeColor           = System.Drawing.Color.FromArgb(200, 210, 215);
            dgvHeaderStyle.Font                = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.Padding             = new System.Windows.Forms.Padding(8, 0, 4, 0);
            dgvHeaderStyle.SelectionBackColor  = System.Drawing.Color.FromArgb(30, 36, 40);
            dgvHeaderStyle.SelectionForeColor  = System.Drawing.Color.White;

            dgvDefaultStyle.BackColor          = System.Drawing.Color.White;
            dgvDefaultStyle.ForeColor          = System.Drawing.Color.FromArgb(45, 52, 54);
            dgvDefaultStyle.Font               = new System.Drawing.Font("Segoe UI", 9.5F);
            dgvDefaultStyle.Padding            = new System.Windows.Forms.Padding(8, 0, 4, 0);
            dgvDefaultStyle.SelectionBackColor = System.Drawing.Color.FromArgb(235, 240, 255);
            dgvDefaultStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 36, 40);

            dgvAltStyle.BackColor              = System.Drawing.Color.FromArgb(248, 250, 253);
            dgvAltStyle.ForeColor              = System.Drawing.Color.FromArgb(45, 52, 54);

            dgvActionStyle.Alignment           = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dgvActionStyle.BackColor           = System.Drawing.Color.White;

            this.dgvCompras.AllowUserToAddRows             = false;
            this.dgvCompras.AllowUserToDeleteRows          = false;
            this.dgvCompras.AllowUserToResizeRows          = false;
            this.dgvCompras.AutoSizeRowsMode               = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.dgvCompras.BackgroundColor                = System.Drawing.Color.White;
            this.dgvCompras.BorderStyle                    = System.Windows.Forms.BorderStyle.None;
            this.dgvCompras.CellBorderStyle                = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCompras.ColumnHeadersBorderStyle       = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCompras.ColumnHeadersDefaultCellStyle  = dgvHeaderStyle;
            this.dgvCompras.ColumnHeadersHeight            = 40;
            this.dgvCompras.ColumnHeadersHeightSizeMode    = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCompras.DefaultCellStyle               = dgvDefaultStyle;
            this.dgvCompras.AlternatingRowsDefaultCellStyle = dgvAltStyle;
            this.dgvCompras.Dock                           = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompras.EnableHeadersVisualStyles      = false;
            this.dgvCompras.GridColor                      = System.Drawing.Color.FromArgb(230, 233, 238);
            this.dgvCompras.Location                       = new System.Drawing.Point(12, 12);
            this.dgvCompras.Name                           = "dgvCompras";
            this.dgvCompras.ReadOnly                       = true;
            this.dgvCompras.RowHeadersVisible              = false;
            this.dgvCompras.RowTemplate.Height             = 44;
            this.dgvCompras.SelectionMode                  = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompras.TabIndex                       = 128;
            this.dgvCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNumero, this.colFechaHora, this.colComprobante, this.colProveedor,
                this.colItems, this.colMetodoPago, this.colTotal, this.colEstado,
                this.colVerDetalle, this.colImprimir, this.colAnular });

            // ── Columnas ──────────────────────────────────────────────────────
            // Regla: HeaderCell.Style.Alignment siempre coincide con DefaultCellStyle.Alignment

            this.colNumero.HeaderText  = "#";
            this.colNumero.Name        = "colNumero";
            this.colNumero.ReadOnly    = true;
            this.colNumero.Width       = 52;
            this.colNumero.DefaultCellStyle.Alignment  = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colNumero.DefaultCellStyle.ForeColor  = System.Drawing.Color.FromArgb(140, 150, 160);
            this.colNumero.DefaultCellStyle.Font       = new System.Drawing.Font("Segoe UI", 8.5F);
            this.colNumero.HeaderCell.Style.Alignment  = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colFechaHora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colFechaHora.HeaderText   = "Fecha y Hora";
            this.colFechaHora.Name         = "colFechaHora";
            this.colFechaHora.ReadOnly     = true;
            this.colFechaHora.Width        = 145;
            this.colFechaHora.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.colFechaHora.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colFechaHora.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;

            this.colComprobante.HeaderText = "Comprobante";
            this.colComprobante.Name       = "colComprobante";
            this.colComprobante.ReadOnly   = true;
            this.colComprobante.Resizable  = System.Windows.Forms.DataGridViewTriState.True;
            this.colComprobante.SortMode   = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colComprobante.Width      = 145;
            this.colComprobante.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colComprobante.DefaultCellStyle.WrapMode  = System.Windows.Forms.DataGridViewTriState.True;
            this.colComprobante.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.colComprobante.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;

            this.colProveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProveedor.HeaderText   = "Proveedor";
            this.colProveedor.Name         = "colProveedor";
            this.colProveedor.ReadOnly     = true;
            this.colProveedor.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colProveedor.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.colProveedor.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;

            this.colItems.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colItems.HeaderText   = "Ítems";
            this.colItems.Name         = "colItems";
            this.colItems.ReadOnly     = true;
            this.colItems.Width        = 70;
            this.colItems.DefaultCellStyle.Alignment  = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colItems.DefaultCellStyle.Font       = new System.Drawing.Font("Segoe UI", 9F);
            this.colItems.HeaderCell.Style.Alignment  = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colMetodoPago.HeaderText = "Método";
            this.colMetodoPago.Name       = "colMetodoPago";
            this.colMetodoPago.ReadOnly   = true;
            this.colMetodoPago.Width      = 112;
            this.colMetodoPago.DefaultCellStyle.Alignment  = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colMetodoPago.HeaderCell.Style.Alignment  = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colTotal.HeaderText = "Total";
            this.colTotal.Name       = "colTotal";
            this.colTotal.ReadOnly   = true;
            this.colTotal.Width      = 112;
            this.colTotal.DefaultCellStyle.Alignment  = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTotal.DefaultCellStyle.Padding    = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.colTotal.DefaultCellStyle.Font       = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.colTotal.DefaultCellStyle.ForeColor  = System.Drawing.Color.FromArgb(39, 120, 60);
            this.colTotal.HeaderCell.Style.Alignment  = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTotal.HeaderCell.Style.Padding    = new System.Windows.Forms.Padding(0, 0, 10, 0);

            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name       = "colEstado";
            this.colEstado.ReadOnly   = true;
            this.colEstado.Width      = 110;
            this.colEstado.DefaultCellStyle.Alignment  = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEstado.DefaultCellStyle.Font       = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.colEstado.HeaderCell.Style.Alignment  = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            // Columnas de acción — sin texto en header, centradas
            this.colVerDetalle.HeaderText  = "";
            this.colVerDetalle.Name        = "colVerDetalle";
            this.colVerDetalle.ReadOnly    = true;
            this.colVerDetalle.Resizable   = System.Windows.Forms.DataGridViewTriState.False;
            this.colVerDetalle.SortMode    = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colVerDetalle.Width       = 40;
            this.colVerDetalle.DefaultCellStyle = dgvActionStyle;

            this.colImprimir.HeaderText    = "";
            this.colImprimir.Name          = "colImprimir";
            this.colImprimir.ReadOnly      = true;
            this.colImprimir.Resizable     = System.Windows.Forms.DataGridViewTriState.False;
            this.colImprimir.SortMode      = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colImprimir.Width         = 40;
            this.colImprimir.DefaultCellStyle = dgvActionStyle;

            this.colAnular.HeaderText      = "";
            this.colAnular.Name            = "colAnular";
            this.colAnular.ReadOnly        = true;
            this.colAnular.Resizable       = System.Windows.Forms.DataGridViewTriState.False;
            this.colAnular.SortMode        = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAnular.Width           = 40;
            this.colAnular.DefaultCellStyle = dgvActionStyle;

            // ══════════════════════════════════════════════════════════════════
            // FormHistorialCompras
            // ══════════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 250);
            this.ClientSize = new System.Drawing.Size(1280, 740);
            this.Controls.Add(this.pnlListado);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlFiltro);
            this.Controls.Add(this.pnlHeader);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FormHistorialCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de Compras";

            // ── ResumeLayouts ─────────────────────────────────────────────────
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            this.pnlListado.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Header
        private System.Windows.Forms.Panel   pnlHeader;
        private System.Windows.Forms.Label   lblTitulo;
        private System.Windows.Forms.Label   lblHeaderSub;

        // Filtros
        private System.Windows.Forms.Panel   pnlFiltro;
        private System.Windows.Forms.Panel   pnlFiltroSep;
        private System.Windows.Forms.Label   lblSubTitulo;
        private System.Windows.Forms.Label   lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label   lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label   lblProveedor;
        private System.Windows.Forms.ComboBox cmbProveedor;
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
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMetodoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewImageColumn   colVerDetalle;
        private System.Windows.Forms.DataGridViewImageColumn   colImprimir;
        private System.Windows.Forms.DataGridViewImageColumn   colAnular;

        // Footer
        private System.Windows.Forms.Panel   pnlFooter;
        private System.Windows.Forms.Panel   pnlFooterSep;
        private System.Windows.Forms.Label   lblOperaciones;
        private System.Windows.Forms.Label   lblEfectivo;
        private System.Windows.Forms.TextBox txtEfectivoCantidad;
        private System.Windows.Forms.Label   lbllblYape;
        private System.Windows.Forms.TextBox txtYapeCantidad;
        private System.Windows.Forms.Label   lblTransferencia;
        private System.Windows.Forms.TextBox txtTransferenciaCantidad;
        private System.Windows.Forms.Label   lblCredito;
        private System.Windows.Forms.TextBox txtCreditoCantidad;
        private System.Windows.Forms.Label   lblSeparador;
        private System.Windows.Forms.Label   lblTotal;
        private System.Windows.Forms.TextBox txtTotalCantidad;
        private System.Windows.Forms.Label   lblPorPagar;
        private System.Windows.Forms.TextBox txtPorPagar;
        private System.Windows.Forms.Button  btnExportar;
        private System.Windows.Forms.Button  btnCerrar;
        private System.Windows.Forms.Label   lblSubTitulo2;
    }
}
