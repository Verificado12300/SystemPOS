namespace SistemaPOS.Forms.Finanzas
{
    partial class FormPapeleraGlobal
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
            System.Windows.Forms.DataGridViewCellStyle dgvAltStyle     = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvActionStyle  = new System.Windows.Forms.DataGridViewCellStyle();

            // ── Declarations ──────────────────────────────────────────────────
            // Header
            this.pnlHeader      = new System.Windows.Forms.Panel();
            this.lblTitulo      = new System.Windows.Forms.Label();
            this.lblSubtitulo   = new System.Windows.Forms.Label();

            // Filter bar
            this.pnlFiltro      = new System.Windows.Forms.Panel();
            this.pnlFiltroSep   = new System.Windows.Forms.Panel();
            this.lblDesde       = new System.Windows.Forms.Label();
            this.dtpDesde       = new System.Windows.Forms.DateTimePicker();
            this.lblHasta       = new System.Windows.Forms.Label();
            this.dtpHasta       = new System.Windows.Forms.DateTimePicker();
            this.lblEntidad     = new System.Windows.Forms.Label();
            this.cmbEntidad     = new System.Windows.Forms.ComboBox();
            this.lblBuscar      = new System.Windows.Forms.Label();
            this.txtBuscar      = new System.Windows.Forms.TextBox();
            this.btnBuscar      = new System.Windows.Forms.Button();
            this.btnLimpiar     = new System.Windows.Forms.Button();

            // Grid
            this.pnlListado     = new System.Windows.Forms.Panel();
            this.dgvPapelera    = new System.Windows.Forms.DataGridView();
            this.colEntidad     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId          = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReferencia  = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonto       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaElim   = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuarioElim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRestaurar   = new System.Windows.Forms.DataGridViewButtonColumn();

            // Footer
            this.pnlFooter      = new System.Windows.Forms.Panel();
            this.pnlFooterSep   = new System.Windows.Forms.Panel();
            this.lblConteo      = new System.Windows.Forms.Label();

            // ── SuspendLayouts ────────────────────────────────────────────────
            this.pnlHeader.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            this.pnlListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPapelera)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // ══════════════════════════════════════════════════════════════════
            // pnlHeader  (Dock=Top — oscuro)
            // ══════════════════════════════════════════════════════════════════
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 36, 40);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 72);
            this.pnlHeader.TabIndex = 0;

            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(22, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(520, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "\uD83D\uDDD1\uFE0F  Papelera Global";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(160, 175, 180);
            this.lblSubtitulo.Location = new System.Drawing.Point(24, 46);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Registros eliminados del sistema — restaure si fue un error";

            // ══════════════════════════════════════════════════════════════════
            // pnlFiltro  (Dock=Top — filtros en una fila)
            // ══════════════════════════════════════════════════════════════════
            this.pnlFiltro.BackColor = System.Drawing.Color.FromArgb(252, 252, 253);
            this.pnlFiltro.Controls.Add(this.pnlFiltroSep);
            this.pnlFiltro.Controls.Add(this.btnBuscar);
            this.pnlFiltro.Controls.Add(this.btnLimpiar);
            this.pnlFiltro.Controls.Add(this.txtBuscar);
            this.pnlFiltro.Controls.Add(this.lblBuscar);
            this.pnlFiltro.Controls.Add(this.cmbEntidad);
            this.pnlFiltro.Controls.Add(this.lblEntidad);
            this.pnlFiltro.Controls.Add(this.dtpHasta);
            this.pnlFiltro.Controls.Add(this.lblHasta);
            this.pnlFiltro.Controls.Add(this.dtpDesde);
            this.pnlFiltro.Controls.Add(this.lblDesde);
            this.pnlFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Padding = new System.Windows.Forms.Padding(16, 8, 16, 0);
            this.pnlFiltro.Size = new System.Drawing.Size(1100, 60);
            this.pnlFiltro.TabIndex = 1;

            // Separador inferior del panel de filtros
            this.pnlFiltroSep.BackColor = System.Drawing.Color.FromArgb(218, 220, 224);
            this.pnlFiltroSep.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFiltroSep.Name = "pnlFiltroSep";
            this.pnlFiltroSep.Size = new System.Drawing.Size(1100, 1);
            this.pnlFiltroSep.TabIndex = 200;

            // ── DESDE ─────────────────────────────────────────────────────────
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblDesde.Location = new System.Drawing.Point(18, 12);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.TabIndex = 10;
            this.lblDesde.Text = "DESDE";

            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpDesde.Location = new System.Drawing.Point(18, 28);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(110, 24);
            this.dtpDesde.TabIndex = 11;

            // ── HASTA ─────────────────────────────────────────────────────────
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblHasta.Location = new System.Drawing.Point(142, 12);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.TabIndex = 12;
            this.lblHasta.Text = "HASTA";

            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpHasta.Location = new System.Drawing.Point(142, 28);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(110, 24);
            this.dtpHasta.TabIndex = 13;

            // ── TIPO ──────────────────────────────────────────────────────────
            this.lblEntidad.AutoSize = true;
            this.lblEntidad.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblEntidad.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblEntidad.Location = new System.Drawing.Point(266, 12);
            this.lblEntidad.Name = "lblEntidad";
            this.lblEntidad.TabIndex = 14;
            this.lblEntidad.Text = "TIPO";

            this.cmbEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEntidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEntidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbEntidad.Items.AddRange(new object[] { "TODOS", "GASTO", "VENTA", "COMPRA", "CLIENTE", "PROVEEDOR", "PRODUCTO", "CXP" });
            this.cmbEntidad.Location = new System.Drawing.Point(266, 28);
            this.cmbEntidad.Name = "cmbEntidad";
            this.cmbEntidad.Size = new System.Drawing.Size(130, 24);
            this.cmbEntidad.TabIndex = 15;

            // ── BUSCAR (text) ─────────────────────────────────────────────────
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblBuscar.Location = new System.Drawing.Point(410, 12);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.TabIndex = 16;
            this.lblBuscar.Text = "BUSCAR";

            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(410, 28);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(330, 24);
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                    System.Windows.Forms.AnchorStyles.Left |
                                    System.Windows.Forms.AnchorStyles.Right;
            this.txtBuscar.TabIndex = 17;

            // ── Botón Buscar ──────────────────────────────────────────────────
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(50, 78, 210);
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(870, 24);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 30);
            this.btnBuscar.TabIndex = 18;
            this.btnBuscar.Text = "\uD83D\uDD0D  Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);

            // ── Botón Limpiar ─────────────────────────────────────────────────
            this.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(210, 214, 220);
            this.btnLimpiar.FlatAppearance.BorderSize = 1;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.btnLimpiar.Location = new System.Drawing.Point(990, 24);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 30);
            this.btnLimpiar.TabIndex = 19;
            this.btnLimpiar.Text = "\u2715  Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);

            // ══════════════════════════════════════════════════════════════════
            // pnlListado  (Dock=Fill — área del grid)
            // ══════════════════════════════════════════════════════════════════
            this.pnlListado.BackColor = System.Drawing.Color.FromArgb(244, 246, 250);
            this.pnlListado.Controls.Add(this.dgvPapelera);
            this.pnlListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListado.Name = "pnlListado";
            this.pnlListado.Padding = new System.Windows.Forms.Padding(10);
            this.pnlListado.TabIndex = 2;

            // ── dgvPapelera ───────────────────────────────────────────────────
            dgvHeaderStyle.BackColor          = System.Drawing.Color.FromArgb(30, 36, 40);
            dgvHeaderStyle.ForeColor          = System.Drawing.Color.FromArgb(200, 210, 215);
            dgvHeaderStyle.Font               = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.Padding            = new System.Windows.Forms.Padding(8, 0, 4, 0);
            dgvHeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(30, 36, 40);
            dgvHeaderStyle.SelectionForeColor = System.Drawing.Color.White;

            dgvDefaultStyle.BackColor          = System.Drawing.Color.White;
            dgvDefaultStyle.ForeColor          = System.Drawing.Color.FromArgb(45, 52, 54);
            dgvDefaultStyle.Font               = new System.Drawing.Font("Segoe UI", 9.5F);
            dgvDefaultStyle.Padding            = new System.Windows.Forms.Padding(8, 0, 4, 0);
            dgvDefaultStyle.SelectionBackColor = System.Drawing.Color.FromArgb(235, 240, 255);
            dgvDefaultStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 36, 40);

            dgvAltStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);
            dgvAltStyle.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);

            dgvActionStyle.Alignment  = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dgvActionStyle.BackColor  = System.Drawing.Color.White;

            this.dgvPapelera.AllowUserToAddRows             = false;
            this.dgvPapelera.AllowUserToDeleteRows          = false;
            this.dgvPapelera.AllowUserToResizeRows          = false;
            this.dgvPapelera.AutoGenerateColumns            = false;
            this.dgvPapelera.AutoSizeRowsMode               = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.dgvPapelera.BackgroundColor                = System.Drawing.Color.White;
            this.dgvPapelera.BorderStyle                    = System.Windows.Forms.BorderStyle.None;
            this.dgvPapelera.CellBorderStyle                = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPapelera.ColumnHeadersBorderStyle       = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPapelera.ColumnHeadersDefaultCellStyle  = dgvHeaderStyle;
            this.dgvPapelera.ColumnHeadersHeight            = 40;
            this.dgvPapelera.ColumnHeadersHeightSizeMode    = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPapelera.DefaultCellStyle               = dgvDefaultStyle;
            this.dgvPapelera.AlternatingRowsDefaultCellStyle = dgvAltStyle;
            this.dgvPapelera.Dock                           = System.Windows.Forms.DockStyle.Fill;
            this.dgvPapelera.EnableHeadersVisualStyles      = false;
            this.dgvPapelera.GridColor                      = System.Drawing.Color.FromArgb(230, 233, 238);
            this.dgvPapelera.Name                           = "dgvPapelera";
            this.dgvPapelera.ReadOnly                       = true;
            this.dgvPapelera.RowHeadersVisible              = false;
            this.dgvPapelera.RowTemplate.Height             = 44;
            this.dgvPapelera.SelectionMode                  = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPapelera.TabIndex                       = 0;
            this.dgvPapelera.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colEntidad, this.colId, this.colReferencia,
                this.colMonto, this.colFechaElim, this.colUsuarioElim, this.colRestaurar
            });
            this.dgvPapelera.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPapelera_CellContentClick);

            // colEntidad
            this.colEntidad.HeaderText = "TIPO";
            this.colEntidad.Name       = "colEntidad";
            this.colEntidad.ReadOnly   = true;
            this.colEntidad.Width      = 90;
            this.colEntidad.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEntidad.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.colEntidad.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            // colId
            this.colId.HeaderText = "ID";
            this.colId.Name       = "colId";
            this.colId.ReadOnly   = true;
            this.colId.Width      = 56;
            this.colId.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colId.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.colId.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(140, 150, 160);
            this.colId.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            // colReferencia
            this.colReferencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colReferencia.HeaderText   = "REFERENCIA / CONCEPTO";
            this.colReferencia.Name         = "colReferencia";
            this.colReferencia.ReadOnly     = true;
            this.colReferencia.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colReferencia.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.colReferencia.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;

            // colMonto
            this.colMonto.HeaderText = "MONTO";
            this.colMonto.Name       = "colMonto";
            this.colMonto.ReadOnly   = true;
            this.colMonto.Width      = 105;
            this.colMonto.DefaultCellStyle.Alignment  = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colMonto.DefaultCellStyle.Padding    = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.colMonto.DefaultCellStyle.Font       = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.colMonto.DefaultCellStyle.ForeColor  = System.Drawing.Color.FromArgb(39, 120, 60);
            this.colMonto.HeaderCell.Style.Alignment  = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colMonto.HeaderCell.Style.Padding    = new System.Windows.Forms.Padding(0, 0, 10, 0);

            // colFechaElim
            this.colFechaElim.HeaderText = "ELIMINADO EL";
            this.colFechaElim.Name       = "colFechaElim";
            this.colFechaElim.ReadOnly   = true;
            this.colFechaElim.Width      = 145;
            this.colFechaElim.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colFechaElim.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.colFechaElim.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;

            // colUsuarioElim
            this.colUsuarioElim.HeaderText = "POR";
            this.colUsuarioElim.Name       = "colUsuarioElim";
            this.colUsuarioElim.ReadOnly   = true;
            this.colUsuarioElim.Width      = 120;
            this.colUsuarioElim.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colUsuarioElim.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.colUsuarioElim.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;

            // colRestaurar — acción
            this.colRestaurar.HeaderText                  = "";
            this.colRestaurar.Name                        = "colRestaurar";
            this.colRestaurar.Text                        = "Restaurar";
            this.colRestaurar.UseColumnTextForButtonValue = true;
            this.colRestaurar.Resizable                   = System.Windows.Forms.DataGridViewTriState.False;
            this.colRestaurar.SortMode                    = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRestaurar.Width                       = 106;
            this.colRestaurar.FlatStyle                   = System.Windows.Forms.FlatStyle.Flat;
            this.colRestaurar.DefaultCellStyle.Alignment  = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colRestaurar.DefaultCellStyle.BackColor  = System.Drawing.Color.FromArgb(39, 174, 96);
            this.colRestaurar.DefaultCellStyle.ForeColor  = System.Drawing.Color.White;
            this.colRestaurar.DefaultCellStyle.Font       = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);

            // ══════════════════════════════════════════════════════════════════
            // pnlFooter  (Dock=Bottom — blanco, conteo + cerrar)
            // ══════════════════════════════════════════════════════════════════
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.pnlFooterSep);
            this.pnlFooter.Controls.Add(this.lblConteo);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1100, 36);
            this.pnlFooter.TabIndex = 3;

            // Separador superior del footer
            this.pnlFooterSep.BackColor = System.Drawing.Color.FromArgb(218, 220, 224);
            this.pnlFooterSep.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFooterSep.Name = "pnlFooterSep";
            this.pnlFooterSep.Size = new System.Drawing.Size(1100, 1);
            this.pnlFooterSep.TabIndex = 200;

            // lblConteo — barra de estado
            this.lblConteo.AutoSize  = false;
            this.lblConteo.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblConteo.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblConteo.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblConteo.Name      = "lblConteo";
            this.lblConteo.Padding   = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.lblConteo.TabIndex  = 0;
            this.lblConteo.Text      = "Sin registros";
            this.lblConteo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ══════════════════════════════════════════════════════════════════
            // FormPapeleraGlobal
            // ══════════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 250);
            this.ClientSize = new System.Drawing.Size(1100, 680);
            // Add order: Fill → Bottom → Top
            this.Controls.Add(this.pnlListado);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlFiltro);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(860, 520);
            this.Name = "FormPapeleraGlobal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Papelera Global";
            this.Load += new System.EventHandler(this.FormPapeleraGlobal_Load);

            // ── ResumeLayouts ─────────────────────────────────────────────────
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPapelera)).EndInit();
            this.pnlListado.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Header
        private System.Windows.Forms.Panel     pnlHeader;
        private System.Windows.Forms.Label     lblTitulo;
        private System.Windows.Forms.Label     lblSubtitulo;

        // Filtros
        private System.Windows.Forms.Panel     pnlFiltro;
        private System.Windows.Forms.Panel     pnlFiltroSep;
        private System.Windows.Forms.Label     lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label     lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label     lblEntidad;
        private System.Windows.Forms.ComboBox  cmbEntidad;
        private System.Windows.Forms.Label     lblBuscar;
        private System.Windows.Forms.TextBox   txtBuscar;
        private System.Windows.Forms.Button    btnBuscar;
        private System.Windows.Forms.Button    btnLimpiar;

        // Grid
        private System.Windows.Forms.Panel     pnlListado;
        private System.Windows.Forms.DataGridView dgvPapelera;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaElim;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuarioElim;
        private System.Windows.Forms.DataGridViewButtonColumn  colRestaurar;

        // Footer
        private System.Windows.Forms.Panel     pnlFooter;
        private System.Windows.Forms.Panel     pnlFooterSep;
        private System.Windows.Forms.Label     lblConteo;
    }
}
