namespace SistemaPOS.Forms.Inventario
{
    partial class FormKardex
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader          = new System.Windows.Forms.Panel();
            this.lblSubTitulo       = new System.Windows.Forms.Label();
            this.lblTitulo          = new System.Windows.Forms.Label();
            this.pnlFiltros         = new System.Windows.Forms.Panel();
            this.pnlFiltroSep       = new System.Windows.Forms.Panel();
            this.btnExportar        = new System.Windows.Forms.Button();
            this.btnLimpiar         = new System.Windows.Forms.Button();
            this.btnBuscar          = new System.Windows.Forms.Button();
            this.chkVerPresentacion = new System.Windows.Forms.CheckBox();
            this.cmbMetodo          = new System.Windows.Forms.ComboBox();
            this.lblMetodo          = new System.Windows.Forms.Label();
            this.dtpHasta           = new System.Windows.Forms.DateTimePicker();
            this.lblHasta           = new System.Windows.Forms.Label();
            this.dtpDesde           = new System.Windows.Forms.DateTimePicker();
            this.lblDesde           = new System.Windows.Forms.Label();
            this.cmbProducto        = new System.Windows.Forms.ComboBox();
            this.lblProducto        = new System.Windows.Forms.Label();
            this.dgvKardex          = new System.Windows.Forms.DataGridView();
            this.colFecha           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto        = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo            = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocumento       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPresentaciones  = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntrada         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalida          = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockPosterior  = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoUnit       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoPromedio   = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFooter          = new System.Windows.Forms.Panel();
            this.pnlFooterSep       = new System.Windows.Forms.Panel();
            this.lblResumen         = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ────────────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 36, 40);
            this.pnlHeader.Controls.Add(this.lblSubTitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name     = "pnlHeader";
            this.pnlHeader.Size     = new System.Drawing.Size(1280, 80);
            this.pnlHeader.TabIndex = 0;

            this.lblTitulo.AutoSize  = false;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Size      = new System.Drawing.Size(520, 32);
            this.lblTitulo.TabIndex  = 0;
            this.lblTitulo.Text      = "📋  Kardex de Inventario";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblSubTitulo.AutoSize  = true;
            this.lblSubTitulo.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(140, 160, 170);
            this.lblSubTitulo.Location  = new System.Drawing.Point(22, 50);
            this.lblSubTitulo.Name      = "lblSubTitulo";
            this.lblSubTitulo.TabIndex  = 1;
            this.lblSubTitulo.Text      = "Historial de movimientos y valorización de inventario";

            // ── pnlFiltros ───────────────────────────────────────────────────────
            this.pnlFiltros.Anchor    = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(252, 252, 253);
            this.pnlFiltros.Controls.Add(this.pnlFiltroSep);
            this.pnlFiltros.Controls.Add(this.btnExportar);
            this.pnlFiltros.Controls.Add(this.btnLimpiar);
            this.pnlFiltros.Controls.Add(this.btnBuscar);
            this.pnlFiltros.Controls.Add(this.chkVerPresentacion);
            this.pnlFiltros.Controls.Add(this.cmbMetodo);
            this.pnlFiltros.Controls.Add(this.lblMetodo);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.lblDesde);
            this.pnlFiltros.Controls.Add(this.cmbProducto);
            this.pnlFiltros.Controls.Add(this.lblProducto);
            this.pnlFiltros.Location  = new System.Drawing.Point(25, 104);
            this.pnlFiltros.Name      = "pnlFiltros";
            this.pnlFiltros.Padding   = new System.Windows.Forms.Padding(16, 8, 16, 0);
            this.pnlFiltros.Size      = new System.Drawing.Size(1230, 90);
            this.pnlFiltros.TabIndex  = 1;

            this.pnlFiltroSep.BackColor = System.Drawing.Color.FromArgb(220, 224, 230);
            this.pnlFiltroSep.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFiltroSep.Location  = new System.Drawing.Point(0, 89);
            this.pnlFiltroSep.Name      = "pnlFiltroSep";
            this.pnlFiltroSep.Size      = new System.Drawing.Size(1230, 1);
            this.pnlFiltroSep.TabIndex  = 12;

            // lblProducto / cmbProducto
            this.lblProducto.AutoSize  = true;
            this.lblProducto.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblProducto.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblProducto.Location  = new System.Drawing.Point(16, 14);
            this.lblProducto.Name      = "lblProducto";
            this.lblProducto.TabIndex  = 0;
            this.lblProducto.Text      = "PRODUCTO";

            this.cmbProducto.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.Font              = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location          = new System.Drawing.Point(16, 34);
            this.cmbProducto.Name              = "cmbProducto";
            this.cmbProducto.Size              = new System.Drawing.Size(340, 25);
            this.cmbProducto.TabIndex          = 1;

            // lblDesde / dtpDesde
            this.lblDesde.AutoSize  = true;
            this.lblDesde.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblDesde.Location  = new System.Drawing.Point(372, 14);
            this.lblDesde.Name      = "lblDesde";
            this.lblDesde.TabIndex  = 2;
            this.lblDesde.Text      = "DESDE";

            this.dtpDesde.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpDesde.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(372, 34);
            this.dtpDesde.Name     = "dtpDesde";
            this.dtpDesde.Size     = new System.Drawing.Size(120, 25);
            this.dtpDesde.TabIndex = 3;

            // lblHasta / dtpHasta
            this.lblHasta.AutoSize  = true;
            this.lblHasta.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblHasta.Location  = new System.Drawing.Point(508, 14);
            this.lblHasta.Name      = "lblHasta";
            this.lblHasta.TabIndex  = 4;
            this.lblHasta.Text      = "HASTA";

            this.dtpHasta.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpHasta.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(508, 34);
            this.dtpHasta.Name     = "dtpHasta";
            this.dtpHasta.Size     = new System.Drawing.Size(120, 25);
            this.dtpHasta.TabIndex = 5;

            // lblMetodo / cmbMetodo
            this.lblMetodo.AutoSize  = true;
            this.lblMetodo.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblMetodo.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblMetodo.Location  = new System.Drawing.Point(644, 14);
            this.lblMetodo.Name      = "lblMetodo";
            this.lblMetodo.TabIndex  = 6;
            this.lblMetodo.Text      = "VALUACIÓN";

            this.cmbMetodo.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodo.Font              = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbMetodo.FormattingEnabled = true;
            this.cmbMetodo.Location          = new System.Drawing.Point(644, 34);
            this.cmbMetodo.Name              = "cmbMetodo";
            this.cmbMetodo.Size              = new System.Drawing.Size(120, 25);
            this.cmbMetodo.TabIndex          = 7;

            // chkVerPresentacion
            this.chkVerPresentacion.AutoSize  = true;
            this.chkVerPresentacion.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.chkVerPresentacion.ForeColor = System.Drawing.Color.FromArgb(80, 90, 100);
            this.chkVerPresentacion.Location  = new System.Drawing.Point(780, 36);
            this.chkVerPresentacion.Name      = "chkVerPresentacion";
            this.chkVerPresentacion.Size      = new System.Drawing.Size(140, 19);
            this.chkVerPresentacion.TabIndex  = 8;
            this.chkVerPresentacion.Text      = "Ver presentación";

            // btnBuscar — primary blue (Anchor Top|Right)
            this.btnBuscar.Anchor    = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(9, 132, 227);
            this.btnBuscar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize          = 0;
            this.btnBuscar.FlatAppearance.MouseOverBackColor  = System.Drawing.Color.FromArgb(0, 110, 200);
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location  = new System.Drawing.Point(888, 24);
            this.btnBuscar.Name      = "btnBuscar";
            this.btnBuscar.Size      = new System.Drawing.Size(110, 34);
            this.btnBuscar.TabIndex  = 9;
            this.btnBuscar.Text      = "🔍  Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;

            // btnLimpiar — secondary
            this.btnLimpiar.Anchor    = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor        = System.Drawing.Color.FromArgb(200, 210, 220);
            this.btnLimpiar.FlatAppearance.BorderSize         = 1;
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 246, 250);
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.btnLimpiar.Location  = new System.Drawing.Point(1006, 24);
            this.btnLimpiar.Name      = "btnLimpiar";
            this.btnLimpiar.Size      = new System.Drawing.Size(94, 34);
            this.btnLimpiar.TabIndex  = 10;
            this.btnLimpiar.Text      = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;

            // btnExportar — secondary
            this.btnExportar.Anchor    = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.White;
            this.btnExportar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderColor        = System.Drawing.Color.FromArgb(200, 210, 220);
            this.btnExportar.FlatAppearance.BorderSize         = 1;
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 246, 250);
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.btnExportar.Location  = new System.Drawing.Point(1108, 24);
            this.btnExportar.Name      = "btnExportar";
            this.btnExportar.Size      = new System.Drawing.Size(106, 34);
            this.btnExportar.TabIndex  = 11;
            this.btnExportar.Text      = "📥  Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;

            // ── dgvKardex ────────────────────────────────────────────────────────
            this.dgvKardex.Anchor          = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKardex.BackgroundColor = System.Drawing.Color.White;
            this.dgvKardex.BorderStyle     = System.Windows.Forms.BorderStyle.None;
            this.dgvKardex.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colFecha,
                this.colProducto,
                this.colTipo,
                this.colDocumento,
                this.colUsuario,
                this.colPresentaciones,
                this.colEntrada,
                this.colSalida,
                this.colStockPosterior,
                this.colCostoUnit,
                this.colValorMovimiento,
                this.colCostoPromedio });
            this.dgvKardex.EnableHeadersVisualStyles = false;
            this.dgvKardex.GridColor    = System.Drawing.Color.FromArgb(235, 237, 240);
            this.dgvKardex.Location     = new System.Drawing.Point(25, 202);
            this.dgvKardex.Name         = "dgvKardex";
            this.dgvKardex.RowHeadersVisible = false;
            this.dgvKardex.RowTemplate.Height = 38;
            this.dgvKardex.Size         = new System.Drawing.Size(1230, 462);
            this.dgvKardex.TabIndex     = 2;

            this.colFecha.HeaderText = "FECHA / HORA";          this.colFecha.Name = "colFecha";          this.colFecha.Width = 130;
            this.colProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProducto.HeaderText = "PRODUCTO";             this.colProducto.Name = "colProducto";
            this.colTipo.HeaderText = "MOVIMIENTO";              this.colTipo.Name = "colTipo";            this.colTipo.Width = 120;
            this.colDocumento.HeaderText = "DOCUMENTO";           this.colDocumento.Name = "colDocumento";   this.colDocumento.Width = 120;
            this.colUsuario.HeaderText = "USUARIO";               this.colUsuario.Name = "colUsuario";       this.colUsuario.Width = 110;
            this.colPresentaciones.HeaderText = "PRESENTACIÓN";   this.colPresentaciones.Name = "colPresentaciones"; this.colPresentaciones.Width = 100; this.colPresentaciones.ReadOnly = true;
            this.colEntrada.HeaderText = "ENTRADA";               this.colEntrada.Name = "colEntrada";       this.colEntrada.Width = 90;
            this.colSalida.HeaderText = "SALIDA";                 this.colSalida.Name = "colSalida";         this.colSalida.Width = 90;
            this.colStockPosterior.HeaderText = "STOCK";          this.colStockPosterior.Name = "colStockPosterior"; this.colStockPosterior.Width = 90;
            this.colCostoUnit.HeaderText = "COSTO UNIT.";         this.colCostoUnit.Name = "colCostoUnit";   this.colCostoUnit.Width = 100;
            this.colValorMovimiento.HeaderText = "VALOR MOV.";    this.colValorMovimiento.Name = "colValorMovimiento"; this.colValorMovimiento.Width = 100;
            this.colCostoPromedio.HeaderText = "COSTO PROM.";     this.colCostoPromedio.Name = "colCostoPromedio"; this.colCostoPromedio.Width = 105;

            // ── pnlFooter ────────────────────────────────────────────────────────
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.pnlFooterSep);
            this.pnlFooter.Controls.Add(this.lblResumen);
            this.pnlFooter.Dock     = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 690);
            this.pnlFooter.Name     = "pnlFooter";
            this.pnlFooter.Size     = new System.Drawing.Size(1280, 50);
            this.pnlFooter.TabIndex = 3;

            this.pnlFooterSep.BackColor = System.Drawing.Color.FromArgb(220, 224, 230);
            this.pnlFooterSep.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlFooterSep.Location  = new System.Drawing.Point(0, 0);
            this.pnlFooterSep.Name      = "pnlFooterSep";
            this.pnlFooterSep.Size      = new System.Drawing.Size(1280, 1);
            this.pnlFooterSep.TabIndex  = 0;

            this.lblResumen.AutoSize  = true;
            this.lblResumen.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblResumen.ForeColor = System.Drawing.Color.FromArgb(100, 110, 120);
            this.lblResumen.Location  = new System.Drawing.Point(20, 16);
            this.lblResumen.Name      = "lblResumen";
            this.lblResumen.TabIndex  = 1;
            this.lblResumen.Text      = "Movimientos: 0";

            // ── FormKardex ───────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(244, 246, 250);
            this.ClientSize          = new System.Drawing.Size(1280, 740);
            this.Controls.Add(this.dgvKardex);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize         = new System.Drawing.Size(1000, 600);
            this.Name                = "FormKardex";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Kardex de Inventario";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel     pnlHeader;
        private System.Windows.Forms.Label     lblTitulo;
        private System.Windows.Forms.Label     lblSubTitulo;
        private System.Windows.Forms.Panel     pnlFiltros;
        private System.Windows.Forms.Panel     pnlFiltroSep;
        private System.Windows.Forms.Button    btnExportar;
        private System.Windows.Forms.Button    btnLimpiar;
        private System.Windows.Forms.Button    btnBuscar;
        private System.Windows.Forms.CheckBox  chkVerPresentacion;
        private System.Windows.Forms.ComboBox  cmbMetodo;
        private System.Windows.Forms.Label     lblMetodo;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label     lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label     lblDesde;
        private System.Windows.Forms.ComboBox  cmbProducto;
        private System.Windows.Forms.Label     lblProducto;
        private System.Windows.Forms.DataGridView dgvKardex;
        private System.Windows.Forms.Panel     pnlFooter;
        private System.Windows.Forms.Panel     pnlFooterSep;
        private System.Windows.Forms.Label     lblResumen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPresentaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockPosterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoPromedio;
    }
}
