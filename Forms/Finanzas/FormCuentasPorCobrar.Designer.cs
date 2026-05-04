namespace SistemaPOS.Forms.Finanzas
{
    partial class FormCuentasPorCobrar
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlHeader         = new System.Windows.Forms.Panel();
            this.lblTitulo         = new System.Windows.Forms.Label();
            this.lblHeaderSub      = new System.Windows.Forms.Label();

            this.pnlKpi            = new System.Windows.Forms.Panel();
            this.pnlKpi1           = new System.Windows.Forms.Panel();
            this.pnlKpi1Accent     = new System.Windows.Forms.Panel();
            this.lblKpi1Val        = new System.Windows.Forms.Label();
            this.lblKpi1Lbl        = new System.Windows.Forms.Label();
            this.pnlKpi2           = new System.Windows.Forms.Panel();
            this.pnlKpi2Accent     = new System.Windows.Forms.Panel();
            this.lblKpi2Val        = new System.Windows.Forms.Label();
            this.lblKpi2Lbl        = new System.Windows.Forms.Label();
            this.pnlKpi3           = new System.Windows.Forms.Panel();
            this.pnlKpi3Accent     = new System.Windows.Forms.Panel();
            this.lblKpi3Val        = new System.Windows.Forms.Label();
            this.lblKpi3Lbl        = new System.Windows.Forms.Label();

            this.pnlFiltros        = new System.Windows.Forms.Panel();
            this.lblBuscar         = new System.Windows.Forms.Label();
            this.txtBuscar         = new System.Windows.Forms.TextBox();
            this.lblEstado         = new System.Windows.Forms.Label();
            this.cmbEstado         = new System.Windows.Forms.ComboBox();
            this.lblDesde          = new System.Windows.Forms.Label();
            this.dtpDesde          = new System.Windows.Forms.DateTimePicker();
            this.lblHasta          = new System.Windows.Forms.Label();
            this.dtpHasta          = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar        = new System.Windows.Forms.Button();

            this.pnlContent        = new System.Windows.Forms.Panel();
            this.dgvCuentas        = new System.Windows.Forms.DataGridView();
            this.colNumero         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente        = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocumentos     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalVentas    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPagado    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetalle        = new System.Windows.Forms.DataGridViewButtonColumn();

            this.pnlResumen        = new System.Windows.Forms.Panel();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.lblTotalPendiente = new System.Windows.Forms.Label();
            this.txtTotalPendiente = new System.Windows.Forms.TextBox();

            this.pnlHeader.SuspendLayout();
            this.pnlKpi.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            this.pnlResumen.SuspendLayout();
            this.SuspendLayout();

            // ─── pnlHeader ──────────────────────────────────────────────────
            // CxC uses a teal/emerald accent — distinct brand
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 118, 110);   // Teal-700
            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock   = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 84;
            this.pnlHeader.Name   = "pnlHeader";

            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(24, 14);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Text      = "Cuentas por Cobrar";

            this.lblHeaderSub.AutoSize  = true;
            this.lblHeaderSub.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(153, 246, 228);   // Teal-200
            this.lblHeaderSub.Location  = new System.Drawing.Point(26, 48);
            this.lblHeaderSub.Name      = "lblHeaderSub";
            this.lblHeaderSub.Text      = "Créditos pendientes por cliente";

            // ─── pnlKpi ─────────────────────────────────────────────────────
            this.pnlKpi.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlKpi.Controls.Add(this.pnlKpi1);
            this.pnlKpi.Controls.Add(this.pnlKpi2);
            this.pnlKpi.Controls.Add(this.pnlKpi3);
            this.pnlKpi.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi.Height    = 108;
            this.pnlKpi.Name      = "pnlKpi";

            // Card 1 — Total por cobrar (teal accent)
            this.pnlKpi1.BackColor = System.Drawing.Color.White;
            this.pnlKpi1.Controls.Add(this.pnlKpi1Accent);
            this.pnlKpi1.Controls.Add(this.lblKpi1Val);
            this.pnlKpi1.Controls.Add(this.lblKpi1Lbl);
            this.pnlKpi1.Location  = new System.Drawing.Point(20, 14);
            this.pnlKpi1.Name      = "pnlKpi1";
            this.pnlKpi1.Size      = new System.Drawing.Size(260, 80);

            this.pnlKpi1Accent.BackColor = System.Drawing.Color.FromArgb(15, 118, 110);
            this.pnlKpi1Accent.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlKpi1Accent.Name      = "pnlKpi1Accent";
            this.pnlKpi1Accent.Width     = 5;

            this.lblKpi1Val.AutoSize  = true;
            this.lblKpi1Val.Font      = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblKpi1Val.ForeColor = System.Drawing.Color.FromArgb(15, 118, 110);
            this.lblKpi1Val.Location  = new System.Drawing.Point(18, 10);
            this.lblKpi1Val.Name      = "lblKpi1Val";
            this.lblKpi1Val.Text      = "S/ 0.00";

            this.lblKpi1Lbl.AutoSize  = true;
            this.lblKpi1Lbl.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpi1Lbl.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpi1Lbl.Location  = new System.Drawing.Point(18, 54);
            this.lblKpi1Lbl.Name      = "lblKpi1Lbl";
            this.lblKpi1Lbl.Text      = "TOTAL POR COBRAR";

            // Card 2 — Clientes (indigo)
            this.pnlKpi2.BackColor = System.Drawing.Color.White;
            this.pnlKpi2.Controls.Add(this.pnlKpi2Accent);
            this.pnlKpi2.Controls.Add(this.lblKpi2Val);
            this.pnlKpi2.Controls.Add(this.lblKpi2Lbl);
            this.pnlKpi2.Location  = new System.Drawing.Point(296, 14);
            this.pnlKpi2.Name      = "pnlKpi2";
            this.pnlKpi2.Size      = new System.Drawing.Size(220, 80);

            this.pnlKpi2Accent.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.pnlKpi2Accent.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlKpi2Accent.Name      = "pnlKpi2Accent";
            this.pnlKpi2Accent.Width     = 5;

            this.lblKpi2Val.AutoSize  = true;
            this.lblKpi2Val.Font      = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblKpi2Val.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblKpi2Val.Location  = new System.Drawing.Point(18, 10);
            this.lblKpi2Val.Name      = "lblKpi2Val";
            this.lblKpi2Val.Text      = "0";

            this.lblKpi2Lbl.AutoSize  = true;
            this.lblKpi2Lbl.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpi2Lbl.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpi2Lbl.Location  = new System.Drawing.Point(18, 54);
            this.lblKpi2Lbl.Name      = "lblKpi2Lbl";
            this.lblKpi2Lbl.Text      = "CLIENTES";

            // Card 3 — Documentos (amber)
            this.pnlKpi3.BackColor = System.Drawing.Color.White;
            this.pnlKpi3.Controls.Add(this.pnlKpi3Accent);
            this.pnlKpi3.Controls.Add(this.lblKpi3Val);
            this.pnlKpi3.Controls.Add(this.lblKpi3Lbl);
            this.pnlKpi3.Location  = new System.Drawing.Point(532, 14);
            this.pnlKpi3.Name      = "pnlKpi3";
            this.pnlKpi3.Size      = new System.Drawing.Size(220, 80);

            this.pnlKpi3Accent.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.pnlKpi3Accent.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlKpi3Accent.Name      = "pnlKpi3Accent";
            this.pnlKpi3Accent.Width     = 5;

            this.lblKpi3Val.AutoSize  = true;
            this.lblKpi3Val.Font      = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblKpi3Val.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblKpi3Val.Location  = new System.Drawing.Point(18, 10);
            this.lblKpi3Val.Name      = "lblKpi3Val";
            this.lblKpi3Val.Text      = "0";

            this.lblKpi3Lbl.AutoSize  = true;
            this.lblKpi3Lbl.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpi3Lbl.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpi3Lbl.Location  = new System.Drawing.Point(18, 54);
            this.lblKpi3Lbl.Name      = "lblKpi3Lbl";
            this.lblKpi3Lbl.Text      = "DOCUMENTOS";

            // ─── pnlFiltros ──────────────────────────────────────────────────
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Controls.Add(this.lblBuscar);
            this.pnlFiltros.Controls.Add(this.txtBuscar);
            this.pnlFiltros.Controls.Add(this.lblEstado);
            this.pnlFiltros.Controls.Add(this.cmbEstado);
            this.pnlFiltros.Controls.Add(this.lblDesde);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.btnFiltrar);
            this.pnlFiltros.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Height    = 90;
            this.pnlFiltros.Name      = "pnlFiltros";

            this.lblBuscar.AutoSize  = true;
            this.lblBuscar.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblBuscar.Location  = new System.Drawing.Point(20, 8);
            this.lblBuscar.Name      = "lblBuscar";
            this.lblBuscar.Text      = "BUSCAR CLIENTE";

            this.txtBuscar.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(20, 26);
            this.txtBuscar.Name     = "txtBuscar";
            this.txtBuscar.Size     = new System.Drawing.Size(260, 26);
            this.txtBuscar.TabIndex = 0;

            this.lblEstado.AutoSize  = true;
            this.lblEstado.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEstado.Location  = new System.Drawing.Point(296, 8);
            this.lblEstado.Name      = "lblEstado";
            this.lblEstado.Text      = "ESTADO";

            this.cmbEstado.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font              = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] { "Todos los estados", "PENDIENTE", "CANCELADO" });
            this.cmbEstado.Location          = new System.Drawing.Point(296, 26);
            this.cmbEstado.Name              = "cmbEstado";
            this.cmbEstado.Size              = new System.Drawing.Size(172, 26);
            this.cmbEstado.TabIndex          = 1;

            this.lblDesde.AutoSize  = true;
            this.lblDesde.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDesde.Location  = new System.Drawing.Point(20, 58);
            this.lblDesde.Name      = "lblDesde";
            this.lblDesde.Text      = "DESDE";

            this.dtpDesde.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpDesde.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(70, 56);
            this.dtpDesde.Name     = "dtpDesde";
            this.dtpDesde.Size     = new System.Drawing.Size(118, 26);
            this.dtpDesde.Value    = System.DateTime.Now.AddMonths(-3);

            this.lblHasta.AutoSize  = true;
            this.lblHasta.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHasta.Location  = new System.Drawing.Point(202, 58);
            this.lblHasta.Name      = "lblHasta";
            this.lblHasta.Text      = "HASTA";

            this.dtpHasta.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpHasta.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(252, 56);
            this.dtpHasta.Name     = "dtpHasta";
            this.dtpHasta.Size     = new System.Drawing.Size(118, 26);

            this.btnFiltrar.BackColor                         = System.Drawing.Color.FromArgb(240, 253, 250);
            this.btnFiltrar.Cursor                            = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderColor        = System.Drawing.Color.FromArgb(153, 246, 228);
            this.btnFiltrar.FlatAppearance.BorderSize         = 1;
            this.btnFiltrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(209, 250, 229);
            this.btnFiltrar.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font                              = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor                         = System.Drawing.Color.FromArgb(15, 118, 110);
            this.btnFiltrar.Location                          = new System.Drawing.Point(386, 55);
            this.btnFiltrar.Name                              = "btnFiltrar";
            this.btnFiltrar.Size                              = new System.Drawing.Size(90, 27);
            this.btnFiltrar.TabIndex                          = 2;
            this.btnFiltrar.Text                              = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor           = false;
            this.btnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);

            // ─── pnlResumen ──────────────────────────────────────────────────
            this.pnlResumen.BackColor = System.Drawing.Color.White;
            this.pnlResumen.Controls.Add(this.lblTotalRegistros);
            this.pnlResumen.Controls.Add(this.lblTotalPendiente);
            this.pnlResumen.Controls.Add(this.txtTotalPendiente);
            this.pnlResumen.Dock   = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumen.Height = 44;
            this.pnlResumen.Name   = "pnlResumen";

            this.lblTotalRegistros.AutoSize  = true;
            this.lblTotalRegistros.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalRegistros.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTotalRegistros.Location  = new System.Drawing.Point(20, 14);
            this.lblTotalRegistros.Name      = "lblTotalRegistros";
            this.lblTotalRegistros.Text      = "0 clientes";

            this.lblTotalPendiente.Anchor    = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.lblTotalPendiente.AutoSize  = true;
            this.lblTotalPendiente.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalPendiente.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTotalPendiente.Location  = new System.Drawing.Point(920, 14);
            this.lblTotalPendiente.Name      = "lblTotalPendiente";
            this.lblTotalPendiente.Text      = "Total por cobrar:";

            this.txtTotalPendiente.Anchor      = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.txtTotalPendiente.BackColor   = System.Drawing.Color.White;
            this.txtTotalPendiente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalPendiente.Font        = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtTotalPendiente.ForeColor   = System.Drawing.Color.FromArgb(15, 118, 110);
            this.txtTotalPendiente.Location    = new System.Drawing.Point(1058, 11);
            this.txtTotalPendiente.Name        = "txtTotalPendiente";
            this.txtTotalPendiente.ReadOnly    = true;
            this.txtTotalPendiente.Size        = new System.Drawing.Size(128, 22);
            this.txtTotalPendiente.Text        = "S/ 0.00";
            this.txtTotalPendiente.TextAlign   = System.Windows.Forms.HorizontalAlignment.Right;

            // ─── pnlContent + dgvCuentas ─────────────────────────────────────
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlContent.Controls.Add(this.dgvCuentas);
            this.pnlContent.Dock    = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Name    = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(16, 10, 16, 0);

            var hdrStyle = new System.Windows.Forms.DataGridViewCellStyle();
            var rowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            var altStyle = new System.Windows.Forms.DataGridViewCellStyle();

            hdrStyle.Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            hdrStyle.BackColor          = System.Drawing.Color.FromArgb(241, 245, 249);
            hdrStyle.Font               = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            hdrStyle.ForeColor          = System.Drawing.Color.FromArgb(100, 116, 139);
            hdrStyle.SelectionBackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            hdrStyle.SelectionForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            hdrStyle.Padding            = new System.Windows.Forms.Padding(8, 0, 4, 0);

            rowStyle.Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            rowStyle.BackColor          = System.Drawing.Color.White;
            rowStyle.Font               = new System.Drawing.Font("Segoe UI", 9.5F);
            rowStyle.ForeColor          = System.Drawing.Color.FromArgb(30, 41, 59);
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(240, 253, 250);
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            rowStyle.Padding            = new System.Windows.Forms.Padding(8, 0, 4, 0);

            altStyle.BackColor          = System.Drawing.Color.FromArgb(248, 250, 252);
            altStyle.SelectionBackColor = System.Drawing.Color.FromArgb(240, 253, 250);
            altStyle.Padding            = new System.Windows.Forms.Padding(8, 0, 4, 0);

            this.dgvCuentas.AllowUserToAddRows              = false;
            this.dgvCuentas.AllowUserToDeleteRows           = false;
            this.dgvCuentas.AllowUserToResizeRows           = false;
            this.dgvCuentas.BackgroundColor                 = System.Drawing.Color.FromArgb(248, 250, 252);
            this.dgvCuentas.BorderStyle                     = System.Windows.Forms.BorderStyle.None;
            this.dgvCuentas.CellBorderStyle                 = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCuentas.ColumnHeadersBorderStyle        = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCuentas.ColumnHeadersDefaultCellStyle   = hdrStyle;
            this.dgvCuentas.ColumnHeadersHeight             = 38;
            this.dgvCuentas.ColumnHeadersHeightSizeMode     = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCuentas.DefaultCellStyle                = rowStyle;
            this.dgvCuentas.AlternatingRowsDefaultCellStyle = altStyle;
            this.dgvCuentas.Dock                            = System.Windows.Forms.DockStyle.Fill;
            this.dgvCuentas.EnableHeadersVisualStyles       = false;
            this.dgvCuentas.GridColor                       = System.Drawing.Color.FromArgb(226, 232, 240);
            this.dgvCuentas.Name                            = "dgvCuentas";
            this.dgvCuentas.ReadOnly                        = true;
            this.dgvCuentas.RowHeadersVisible               = false;
            this.dgvCuentas.RowTemplate.Height              = 44;
            this.dgvCuentas.SelectionMode                   = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNumero, this.colCliente, this.colDocumentos,
                this.colTotalVentas, this.colTotalPagado, this.colTotalPendiente,
                this.colEstado, this.colDetalle });

            this.dgvCuentas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCuentas_CellContentClick);

            this.colNumero.HeaderText = "#";
            this.colNumero.Name       = "colNumero";
            this.colNumero.ReadOnly   = true;
            this.colNumero.Width      = 50;
            this.colNumero.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colNumero.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.colNumero.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);

            this.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCliente.HeaderText   = "CLIENTE";
            this.colCliente.Name         = "colCliente";
            this.colCliente.ReadOnly     = true;

            this.colDocumentos.HeaderText = "DOCS";
            this.colDocumentos.Name       = "colDocumentos";
            this.colDocumentos.ReadOnly   = true;
            this.colDocumentos.Width      = 60;
            this.colDocumentos.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDocumentos.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.colDocumentos.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(15, 118, 110);

            this.colTotalVentas.HeaderText = "TOTAL";
            this.colTotalVentas.Name       = "colTotalVentas";
            this.colTotalVentas.ReadOnly   = true;
            this.colTotalVentas.Width      = 120;
            this.colTotalVentas.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colTotalPagado.HeaderText = "COBRADO";
            this.colTotalPagado.Name       = "colTotalPagado";
            this.colTotalPagado.ReadOnly   = true;
            this.colTotalPagado.Width      = 118;
            this.colTotalPagado.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTotalPagado.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.colTotalPagado.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            this.colTotalPendiente.HeaderText = "PENDIENTE";
            this.colTotalPendiente.Name       = "colTotalPendiente";
            this.colTotalPendiente.ReadOnly   = true;
            this.colTotalPendiente.Width      = 118;
            this.colTotalPendiente.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTotalPendiente.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(15, 118, 110);
            this.colTotalPendiente.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.colEstado.HeaderText = "ESTADO";
            this.colEstado.Name       = "colEstado";
            this.colEstado.ReadOnly   = true;
            this.colEstado.Width      = 108;
            this.colEstado.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colDetalle.FlatStyle                   = System.Windows.Forms.FlatStyle.Flat;
            this.colDetalle.HeaderText                  = "";
            this.colDetalle.Name                        = "colDetalle";
            this.colDetalle.ReadOnly                    = false;
            this.colDetalle.Text                        = "Ver detalle";
            this.colDetalle.UseColumnTextForButtonValue = true;
            this.colDetalle.Width                       = 90;

            // ─── FormCuentasPorCobrar ────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize          = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlKpi);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlResumen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name            = "FormCuentasPorCobrar";
            this.Text            = "Cuentas por Cobrar";
            this.Load += new System.EventHandler(this.FormCuentasPorCobrar_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlKpi.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel    pnlHeader;
        private System.Windows.Forms.Label    lblTitulo;
        private System.Windows.Forms.Label    lblHeaderSub;

        private System.Windows.Forms.Panel    pnlKpi;
        private System.Windows.Forms.Panel    pnlKpi1;
        private System.Windows.Forms.Panel    pnlKpi1Accent;
        private System.Windows.Forms.Label    lblKpi1Val;
        private System.Windows.Forms.Label    lblKpi1Lbl;
        private System.Windows.Forms.Panel    pnlKpi2;
        private System.Windows.Forms.Panel    pnlKpi2Accent;
        private System.Windows.Forms.Label    lblKpi2Val;
        private System.Windows.Forms.Label    lblKpi2Lbl;
        private System.Windows.Forms.Panel    pnlKpi3;
        private System.Windows.Forms.Panel    pnlKpi3Accent;
        private System.Windows.Forms.Label    lblKpi3Val;
        private System.Windows.Forms.Label    lblKpi3Lbl;

        private System.Windows.Forms.Panel    pnlFiltros;
        private System.Windows.Forms.Label    lblBuscar;
        private System.Windows.Forms.TextBox  txtBuscar;
        private System.Windows.Forms.Label    lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label    lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label    lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button   btnFiltrar;

        private System.Windows.Forms.Panel    pnlContent;
        private System.Windows.Forms.DataGridView dgvCuentas;
        private System.Windows.Forms.Panel    pnlResumen;
        private System.Windows.Forms.Label    lblTotalRegistros;
        private System.Windows.Forms.Label    lblTotalPendiente;
        private System.Windows.Forms.TextBox  txtTotalPendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn   colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn   colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn   colDocumentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn   colTotalVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn   colTotalPagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn   colTotalPendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn   colEstado;
        private System.Windows.Forms.DataGridViewButtonColumn    colDetalle;
    }
}
