namespace SistemaPOS.Forms.Finanzas
{
    partial class FormGastos
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            // ── Palette (SaaS Indigo) ─────────────────────────────────────────
            // Primary:   (79,70,229)   | PrimaryDark: (55,48,163)
            // Danger:    (239,68,68)   | Warning: (245,158,11)
            // Success:   (16,185,129)  | Bg: (248,250,252)  Surface: (241,245,249)
            // TextPri:   (30,41,59)    | TextSec: (100,116,139)

            // ── Declare all controls ──────────────────────────────────────────
            this.pnlHeader         = new System.Windows.Forms.Panel();
            this.lblTitulo         = new System.Windows.Forms.Label();
            this.lblHeaderSub      = new System.Windows.Forms.Label();
            this.btnNuevo          = new System.Windows.Forms.Button();
            this.btnExportar       = new System.Windows.Forms.Button();

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

            this.pnlToolbar        = new System.Windows.Forms.Panel();
            this.lblDesde          = new System.Windows.Forms.Label();
            this.dtpDesde          = new System.Windows.Forms.DateTimePicker();
            this.lblHasta          = new System.Windows.Forms.Label();
            this.dtpHasta          = new System.Windows.Forms.DateTimePicker();
            this.lblCategoria      = new System.Windows.Forms.Label();
            this.cmbCategoria      = new System.Windows.Forms.ComboBox();
            this.btnBuscar         = new System.Windows.Forms.Button();

            this.pnlContent        = new System.Windows.Forms.Panel();
            this.dgvGastos         = new System.Windows.Forms.DataGridView();
            this.colNumero         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha          = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHora           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConcepto       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria      = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonto          = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMetodoPago     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComprobante    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar         = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEliminar       = new System.Windows.Forms.DataGridViewButtonColumn();

            this.pnlResumen        = new System.Windows.Forms.Panel();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.lblTotal          = new System.Windows.Forms.Label();
            this.txtTotalGastos    = new System.Windows.Forms.TextBox();

            this.pnlHeader.SuspendLayout();
            this.pnlKpi.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastos)).BeginInit();
            this.pnlResumen.SuspendLayout();
            this.SuspendLayout();

            // ═══════════════════════════════════════════════════════════════════
            // pnlHeader  ─ Indigo solid, 84px
            // ═══════════════════════════════════════════════════════════════════
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.pnlHeader.Controls.Add(this.btnExportar);
            this.pnlHeader.Controls.Add(this.btnNuevo);
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
            this.lblTitulo.Text      = "Gastos Operativos";

            this.lblHeaderSub.AutoSize  = true;
            this.lblHeaderSub.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(196, 196, 255);
            this.lblHeaderSub.Location  = new System.Drawing.Point(26, 48);
            this.lblHeaderSub.Name      = "lblHeaderSub";
            this.lblHeaderSub.Text      = "Registro y control de egresos del negocio";

            // btnNuevo — white pill, right-anchored
            this.btnNuevo.Anchor                            = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnNuevo.BackColor                         = System.Drawing.Color.White;
            this.btnNuevo.Cursor                            = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize         = 0;
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(238, 242, 255);
            this.btnNuevo.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font                              = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor                         = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnNuevo.Location                          = new System.Drawing.Point(1088, 24);
            this.btnNuevo.Name                              = "btnNuevo";
            this.btnNuevo.Size                              = new System.Drawing.Size(100, 36);
            this.btnNuevo.Text                              = "+ Nuevo Gasto";
            this.btnNuevo.UseVisualStyleBackColor           = false;
            this.btnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);

            // btnExportar — ghost/transparent, right of Nuevo
            this.btnExportar.Anchor                            = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnExportar.BackColor                         = System.Drawing.Color.FromArgb(99, 90, 255);
            this.btnExportar.Cursor                            = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderColor        = System.Drawing.Color.FromArgb(180, 180, 255);
            this.btnExportar.FlatAppearance.BorderSize         = 1;
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(85, 80, 220);
            this.btnExportar.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font                              = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor                         = System.Drawing.Color.White;
            this.btnExportar.Location                          = new System.Drawing.Point(976, 24);
            this.btnExportar.Name                              = "btnExportar";
            this.btnExportar.Size                              = new System.Drawing.Size(104, 36);
            this.btnExportar.Text                              = "Exportar PDF";
            this.btnExportar.UseVisualStyleBackColor           = false;

            // ═══════════════════════════════════════════════════════════════════
            // pnlKpi  ─ Slate-50 strip, 108px, 3 metric cards
            // ═══════════════════════════════════════════════════════════════════
            this.pnlKpi.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlKpi.Controls.Add(this.pnlKpi1);
            this.pnlKpi.Controls.Add(this.pnlKpi2);
            this.pnlKpi.Controls.Add(this.pnlKpi3);
            this.pnlKpi.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi.Height    = 108;
            this.pnlKpi.Name      = "pnlKpi";

            // ── KPI Card 1: Total período ─ Red accent ──────────────
            this.pnlKpi1.BackColor   = System.Drawing.Color.White;
            this.pnlKpi1.Controls.Add(this.pnlKpi1Accent);
            this.pnlKpi1.Controls.Add(this.lblKpi1Val);
            this.pnlKpi1.Controls.Add(this.lblKpi1Lbl);
            this.pnlKpi1.Location    = new System.Drawing.Point(20, 14);
            this.pnlKpi1.Name        = "pnlKpi1";
            this.pnlKpi1.Size        = new System.Drawing.Size(248, 80);

            this.pnlKpi1Accent.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.pnlKpi1Accent.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlKpi1Accent.Name      = "pnlKpi1Accent";
            this.pnlKpi1Accent.Width     = 5;

            this.lblKpi1Val.AutoSize  = true;
            this.lblKpi1Val.Font      = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblKpi1Val.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblKpi1Val.Location  = new System.Drawing.Point(18, 10);
            this.lblKpi1Val.Name      = "lblKpi1Val";
            this.lblKpi1Val.Text      = "S/ 0.00";

            this.lblKpi1Lbl.AutoSize  = true;
            this.lblKpi1Lbl.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpi1Lbl.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpi1Lbl.Location  = new System.Drawing.Point(18, 54);
            this.lblKpi1Lbl.Name      = "lblKpi1Lbl";
            this.lblKpi1Lbl.Text      = "TOTAL PERÍODO";

            // ── KPI Card 2: Registros ─ Indigo accent ──────────────
            this.pnlKpi2.BackColor   = System.Drawing.Color.White;
            this.pnlKpi2.Controls.Add(this.pnlKpi2Accent);
            this.pnlKpi2.Controls.Add(this.lblKpi2Val);
            this.pnlKpi2.Controls.Add(this.lblKpi2Lbl);
            this.pnlKpi2.Location    = new System.Drawing.Point(284, 14);
            this.pnlKpi2.Name        = "pnlKpi2";
            this.pnlKpi2.Size        = new System.Drawing.Size(248, 80);

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
            this.lblKpi2Lbl.Text      = "REGISTROS";

            // ── KPI Card 3: Promedio ─ Amber accent ────────────────
            this.pnlKpi3.BackColor   = System.Drawing.Color.White;
            this.pnlKpi3.Controls.Add(this.pnlKpi3Accent);
            this.pnlKpi3.Controls.Add(this.lblKpi3Val);
            this.pnlKpi3.Controls.Add(this.lblKpi3Lbl);
            this.pnlKpi3.Location    = new System.Drawing.Point(548, 14);
            this.pnlKpi3.Name        = "pnlKpi3";
            this.pnlKpi3.Size        = new System.Drawing.Size(248, 80);

            this.pnlKpi3Accent.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.pnlKpi3Accent.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlKpi3Accent.Name      = "pnlKpi3Accent";
            this.pnlKpi3Accent.Width     = 5;

            this.lblKpi3Val.AutoSize  = true;
            this.lblKpi3Val.Font      = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblKpi3Val.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblKpi3Val.Location  = new System.Drawing.Point(18, 10);
            this.lblKpi3Val.Name      = "lblKpi3Val";
            this.lblKpi3Val.Text      = "S/ 0.00";

            this.lblKpi3Lbl.AutoSize  = true;
            this.lblKpi3Lbl.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpi3Lbl.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpi3Lbl.Location  = new System.Drawing.Point(18, 54);
            this.lblKpi3Lbl.Name      = "lblKpi3Lbl";
            this.lblKpi3Lbl.Text      = "PROMEDIO / GASTO";

            // ═══════════════════════════════════════════════════════════════════
            // pnlToolbar (pnlFiltros alias)  ─ White, 62px, filter row
            // ═══════════════════════════════════════════════════════════════════
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.lblDesde);
            this.pnlToolbar.Controls.Add(this.dtpDesde);
            this.pnlToolbar.Controls.Add(this.lblHasta);
            this.pnlToolbar.Controls.Add(this.dtpHasta);
            this.pnlToolbar.Controls.Add(this.lblCategoria);
            this.pnlToolbar.Controls.Add(this.cmbCategoria);
            this.pnlToolbar.Controls.Add(this.btnBuscar);
            this.pnlToolbar.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Height    = 62;
            this.pnlToolbar.Name      = "pnlToolbar";

            // Labels use small-caps style
            this.lblDesde.AutoSize  = true;
            this.lblDesde.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDesde.Location  = new System.Drawing.Point(20, 10);
            this.lblDesde.Name      = "lblDesde";
            this.lblDesde.Text      = "DESDE";

            this.dtpDesde.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpDesde.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(20, 28);
            this.dtpDesde.Name     = "dtpDesde";
            this.dtpDesde.Size     = new System.Drawing.Size(122, 26);

            this.lblHasta.AutoSize  = true;
            this.lblHasta.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHasta.Location  = new System.Drawing.Point(156, 10);
            this.lblHasta.Name      = "lblHasta";
            this.lblHasta.Text      = "HASTA";

            this.dtpHasta.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpHasta.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(156, 28);
            this.dtpHasta.Name     = "dtpHasta";
            this.dtpHasta.Size     = new System.Drawing.Size(122, 26);

            this.lblCategoria.AutoSize  = true;
            this.lblCategoria.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCategoria.Location  = new System.Drawing.Point(294, 10);
            this.lblCategoria.Name      = "lblCategoria";
            this.lblCategoria.Text      = "CATEGORÍA";

            this.cmbCategoria.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FlatStyle         = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategoria.Font              = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location          = new System.Drawing.Point(294, 28);
            this.cmbCategoria.Name              = "cmbCategoria";
            this.cmbCategoria.Size              = new System.Drawing.Size(195, 26);

            this.btnBuscar.BackColor                         = System.Drawing.Color.FromArgb(238, 242, 255);
            this.btnBuscar.Cursor                            = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor        = System.Drawing.Color.FromArgb(199, 210, 254);
            this.btnBuscar.FlatAppearance.BorderSize         = 1;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(224, 231, 255);
            this.btnBuscar.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font                              = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor                         = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnBuscar.Location                          = new System.Drawing.Point(503, 27);
            this.btnBuscar.Name                              = "btnBuscar";
            this.btnBuscar.Size                              = new System.Drawing.Size(92, 27);
            this.btnBuscar.Text                              = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor           = false;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);

            // ═══════════════════════════════════════════════════════════════════
            // pnlResumen  ─ White footer, 44px
            // ═══════════════════════════════════════════════════════════════════
            this.pnlResumen.BackColor = System.Drawing.Color.White;
            this.pnlResumen.Controls.Add(this.lblTotalRegistros);
            this.pnlResumen.Controls.Add(this.lblTotal);
            this.pnlResumen.Controls.Add(this.txtTotalGastos);
            this.pnlResumen.Dock   = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumen.Height = 44;
            this.pnlResumen.Name   = "pnlResumen";

            this.lblTotalRegistros.AutoSize  = true;
            this.lblTotalRegistros.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalRegistros.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTotalRegistros.Location  = new System.Drawing.Point(20, 14);
            this.lblTotalRegistros.Name      = "lblTotalRegistros";
            this.lblTotalRegistros.Text      = "0 registros encontrados";

            this.lblTotal.Anchor    = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.lblTotal.AutoSize  = true;
            this.lblTotal.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTotal.Location  = new System.Drawing.Point(930, 14);
            this.lblTotal.Name      = "lblTotal";
            this.lblTotal.Text      = "Total del período:";

            this.txtTotalGastos.Anchor      = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.txtTotalGastos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalGastos.Font        = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtTotalGastos.ForeColor   = System.Drawing.Color.FromArgb(239, 68, 68);
            this.txtTotalGastos.Location    = new System.Drawing.Point(1060, 11);
            this.txtTotalGastos.Name        = "txtTotalGastos";
            this.txtTotalGastos.ReadOnly    = true;
            this.txtTotalGastos.Size        = new System.Drawing.Size(128, 22);
            this.txtTotalGastos.Text        = "S/ 0.00";
            this.txtTotalGastos.TextAlign   = System.Windows.Forms.HorizontalAlignment.Right;

            // ═══════════════════════════════════════════════════════════════════
            // pnlContent  ─ Slate-50 fill, padding around grid
            // ═══════════════════════════════════════════════════════════════════
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlContent.Controls.Add(this.dgvGastos);
            this.pnlContent.Dock    = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Name    = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(16, 10, 16, 0);

            // ═══════════════════════════════════════════════════════════════════
            // dgvGastos  ─ Clean modern table
            // ═══════════════════════════════════════════════════════════════════
            var hdrStyle = new System.Windows.Forms.DataGridViewCellStyle();
            var rowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            var altStyle = new System.Windows.Forms.DataGridViewCellStyle();
            var btnStyle = new System.Windows.Forms.DataGridViewCellStyle();

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
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(238, 242, 255);
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            rowStyle.Padding            = new System.Windows.Forms.Padding(8, 0, 4, 0);

            altStyle.BackColor          = System.Drawing.Color.FromArgb(248, 250, 252);
            altStyle.SelectionBackColor = System.Drawing.Color.FromArgb(238, 242, 255);
            altStyle.Padding            = new System.Windows.Forms.Padding(8, 0, 4, 0);

            btnStyle.Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            btnStyle.Font               = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            btnStyle.Padding            = new System.Windows.Forms.Padding(0);

            this.dgvGastos.AllowUserToAddRows              = false;
            this.dgvGastos.AllowUserToDeleteRows           = false;
            this.dgvGastos.AllowUserToResizeRows           = false;
            this.dgvGastos.BackgroundColor                 = System.Drawing.Color.FromArgb(248, 250, 252);
            this.dgvGastos.BorderStyle                     = System.Windows.Forms.BorderStyle.None;
            this.dgvGastos.CellBorderStyle                 = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvGastos.ColumnHeadersBorderStyle        = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvGastos.ColumnHeadersDefaultCellStyle   = hdrStyle;
            this.dgvGastos.ColumnHeadersHeight             = 38;
            this.dgvGastos.ColumnHeadersHeightSizeMode     = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvGastos.DefaultCellStyle                = rowStyle;
            this.dgvGastos.AlternatingRowsDefaultCellStyle = altStyle;
            this.dgvGastos.Dock                            = System.Windows.Forms.DockStyle.Fill;
            this.dgvGastos.EnableHeadersVisualStyles       = false;
            this.dgvGastos.GridColor                       = System.Drawing.Color.FromArgb(226, 232, 240);
            this.dgvGastos.Name                            = "dgvGastos";
            this.dgvGastos.ReadOnly                        = true;
            this.dgvGastos.RowHeadersVisible               = false;
            this.dgvGastos.RowTemplate.Height              = 44;
            this.dgvGastos.SelectionMode                   = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvGastos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNumero, this.colFecha, this.colHora, this.colConcepto,
                this.colCategoria, this.colMonto, this.colMetodoPago, this.colComprobante,
                this.colEditar, this.colEliminar });

            this.dgvGastos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvGastos_CellContentClick);

            // Columns
            this.colNumero.HeaderText   = "#";
            this.colNumero.Name         = "colNumero";
            this.colNumero.ReadOnly     = true;
            this.colNumero.Width        = 50;
            this.colNumero.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colNumero.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.colNumero.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);

            this.colFecha.HeaderText = "FECHA";
            this.colFecha.Name       = "colFecha";
            this.colFecha.ReadOnly   = true;
            this.colFecha.Width      = 102;

            this.colHora.HeaderText = "HORA";
            this.colHora.Name       = "colHora";
            this.colHora.ReadOnly   = true;
            this.colHora.Width      = 72;
            this.colHora.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);

            this.colConcepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colConcepto.HeaderText   = "CONCEPTO";
            this.colConcepto.Name         = "colConcepto";
            this.colConcepto.ReadOnly     = true;

            this.colCategoria.HeaderText = "CATEGORÍA";
            this.colCategoria.Name       = "colCategoria";
            this.colCategoria.ReadOnly   = true;
            this.colCategoria.Width      = 130;

            this.colMonto.HeaderText = "MONTO";
            this.colMonto.Name       = "colMonto";
            this.colMonto.ReadOnly   = true;
            this.colMonto.Width      = 110;
            this.colMonto.DefaultCellStyle.Alignment  = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colMonto.DefaultCellStyle.Font       = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.colMonto.DefaultCellStyle.ForeColor  = System.Drawing.Color.FromArgb(239, 68, 68);

            this.colMetodoPago.HeaderText = "MÉTODO";
            this.colMetodoPago.Name       = "colMetodoPago";
            this.colMetodoPago.ReadOnly   = true;
            this.colMetodoPago.Width      = 110;
            this.colMetodoPago.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colComprobante.HeaderText = "COMPROBANTE";
            this.colComprobante.Name       = "colComprobante";
            this.colComprobante.ReadOnly   = true;
            this.colComprobante.Width      = 120;
            this.colComprobante.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);

            // Action buttons — styled as text links
            this.colEditar.DefaultCellStyle          = btnStyle;
            this.colEditar.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.colEditar.HeaderText                = "";
            this.colEditar.Name                      = "colEditar";
            this.colEditar.ReadOnly                  = true;
            this.colEditar.Text                      = "Editar";
            this.colEditar.UseColumnTextForButtonValue = true;
            this.colEditar.Width                     = 66;

            this.colEliminar.DefaultCellStyle          = btnStyle;
            this.colEliminar.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.colEliminar.HeaderText                = "";
            this.colEliminar.Name                      = "colEliminar";
            this.colEliminar.ReadOnly                  = true;
            this.colEliminar.Text                      = "Eliminar";
            this.colEliminar.UseColumnTextForButtonValue = true;
            this.colEliminar.Width                     = 72;

            // ═══════════════════════════════════════════════════════════════════
            // FormGastos
            // ═══════════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize          = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlKpi);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlResumen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name            = "FormGastos";
            this.Text            = "Gastos Operativos";
            this.Load += new System.EventHandler(this.FormGastos_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlKpi.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastos)).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.ResumeLayout(false);
        }

        // ── Fields ─────────────────────────────────────────────────────────────
        private System.Windows.Forms.Panel              pnlHeader;
        private System.Windows.Forms.Label              lblTitulo;
        private System.Windows.Forms.Label              lblHeaderSub;
        private System.Windows.Forms.Button             btnNuevo;
        private System.Windows.Forms.Button             btnExportar;

        private System.Windows.Forms.Panel              pnlKpi;
        private System.Windows.Forms.Panel              pnlKpi1;
        private System.Windows.Forms.Panel              pnlKpi1Accent;
        private System.Windows.Forms.Label              lblKpi1Val;
        private System.Windows.Forms.Label              lblKpi1Lbl;
        private System.Windows.Forms.Panel              pnlKpi2;
        private System.Windows.Forms.Panel              pnlKpi2Accent;
        private System.Windows.Forms.Label              lblKpi2Val;
        private System.Windows.Forms.Label              lblKpi2Lbl;
        private System.Windows.Forms.Panel              pnlKpi3;
        private System.Windows.Forms.Panel              pnlKpi3Accent;
        private System.Windows.Forms.Label              lblKpi3Val;
        private System.Windows.Forms.Label              lblKpi3Lbl;

        private System.Windows.Forms.Panel              pnlToolbar;
        private System.Windows.Forms.Label              lblDesde;
        private System.Windows.Forms.DateTimePicker     dtpDesde;
        private System.Windows.Forms.Label              lblHasta;
        private System.Windows.Forms.DateTimePicker     dtpHasta;
        private System.Windows.Forms.Label              lblCategoria;
        private System.Windows.Forms.ComboBox           cmbCategoria;
        private System.Windows.Forms.Button             btnBuscar;

        private System.Windows.Forms.Panel              pnlContent;
        private System.Windows.Forms.DataGridView       dgvGastos;
        private System.Windows.Forms.DataGridViewTextBoxColumn  colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn  colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn  colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn  colConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn  colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn  colMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn  colMetodoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn  colComprobante;
        private System.Windows.Forms.DataGridViewButtonColumn   colEditar;
        private System.Windows.Forms.DataGridViewButtonColumn   colEliminar;

        private System.Windows.Forms.Panel              pnlResumen;
        private System.Windows.Forms.Label              lblTotalRegistros;
        private System.Windows.Forms.Label              lblTotal;
        private System.Windows.Forms.TextBox            txtTotalGastos;
    }
}
