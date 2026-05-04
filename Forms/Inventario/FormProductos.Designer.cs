namespace SistemaPOS.Forms.Inventario
{
    partial class FormProductos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProductos));
            this.pnlHeader       = new System.Windows.Forms.Panel();
            this.lblSubTitulo    = new System.Windows.Forms.Label();
            this.lblTitulo       = new System.Windows.Forms.Label();
            this.pnlFiltros      = new System.Windows.Forms.Panel();
            this.pnlFiltroSep    = new System.Windows.Forms.Panel();
            this.btnNuevo        = new System.Windows.Forms.Button();
            this.btnExportar     = new System.Windows.Forms.Button();
            this.btnImportar     = new System.Windows.Forms.Button();
            this.cmbFiltroStock  = new System.Windows.Forms.ComboBox();
            this.lblStock        = new System.Windows.Forms.Label();
            this.cmbCategoria    = new System.Windows.Forms.ComboBox();
            this.lblCategoria    = new System.Windows.Forms.Label();
            this.txtBuscar       = new System.Windows.Forms.TextBox();
            this.lblBuscar       = new System.Windows.Forms.Label();
            this.dgvProductos    = new System.Windows.Forms.DataGridView();
            this.colNumero       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidadBase   = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPresentaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockTotal   = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar       = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEliminar     = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlFooter       = new System.Windows.Forms.Panel();
            this.pnlFooterSep    = new System.Windows.Forms.Panel();
            this.lblRegistros    = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader — dark top bar ───────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 36, 40);
            this.pnlHeader.Controls.Add(this.lblSubTitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location  = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name      = "pnlHeader";
            this.pnlHeader.Size      = new System.Drawing.Size(1280, 80);
            this.pnlHeader.TabIndex  = 0;

            // lblTitulo
            this.lblTitulo.AutoSize  = false;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Size      = new System.Drawing.Size(520, 32);
            this.lblTitulo.TabIndex  = 0;
            this.lblTitulo.Text      = "📦  Productos / Inventario";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblSubTitulo
            this.lblSubTitulo.AutoSize  = true;
            this.lblSubTitulo.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(140, 160, 170);
            this.lblSubTitulo.Location  = new System.Drawing.Point(22, 50);
            this.lblSubTitulo.Name      = "lblSubTitulo";
            this.lblSubTitulo.TabIndex  = 1;
            this.lblSubTitulo.Text      = "Gestión de productos y control de inventario";

            // ── pnlFiltros — filter bar ────────────────────────────────────────
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(252, 252, 253);
            this.pnlFiltros.Padding   = new System.Windows.Forms.Padding(16, 8, 16, 0);
            this.pnlFiltros.Controls.Add(this.pnlFiltroSep);
            this.pnlFiltros.Controls.Add(this.btnNuevo);
            this.pnlFiltros.Controls.Add(this.btnExportar);
            this.pnlFiltros.Controls.Add(this.btnImportar);
            this.pnlFiltros.Controls.Add(this.cmbFiltroStock);
            this.pnlFiltros.Controls.Add(this.lblStock);
            this.pnlFiltros.Controls.Add(this.cmbCategoria);
            this.pnlFiltros.Controls.Add(this.lblCategoria);
            this.pnlFiltros.Controls.Add(this.txtBuscar);
            this.pnlFiltros.Controls.Add(this.lblBuscar);
            this.pnlFiltros.Anchor    = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.Location  = new System.Drawing.Point(25, 104);
            this.pnlFiltros.Name      = "pnlFiltros";
            this.pnlFiltros.Size      = new System.Drawing.Size(1230, 90);
            this.pnlFiltros.TabIndex  = 1;

            // pnlFiltroSep — 1px bottom border
            this.pnlFiltroSep.BackColor = System.Drawing.Color.FromArgb(220, 224, 230);
            this.pnlFiltroSep.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFiltroSep.Location  = new System.Drawing.Point(0, 125);
            this.pnlFiltroSep.Name      = "pnlFiltroSep";
            this.pnlFiltroSep.Size      = new System.Drawing.Size(1280, 1);
            this.pnlFiltroSep.TabIndex  = 9;

            // lblBuscar
            this.lblBuscar.AutoSize  = true;
            this.lblBuscar.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblBuscar.Location  = new System.Drawing.Point(20, 14);
            this.lblBuscar.Name      = "lblBuscar";
            this.lblBuscar.TabIndex  = 0;
            this.lblBuscar.Text      = "BUSCAR";

            // txtBuscar
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location    = new System.Drawing.Point(20, 34);
            this.txtBuscar.Name        = "txtBuscar";
            this.txtBuscar.Size        = new System.Drawing.Size(360, 24);
            this.txtBuscar.TabIndex    = 1;

            // lblCategoria
            this.lblCategoria.AutoSize  = true;
            this.lblCategoria.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblCategoria.Location  = new System.Drawing.Point(398, 14);
            this.lblCategoria.Name      = "lblCategoria";
            this.lblCategoria.TabIndex  = 2;
            this.lblCategoria.Text      = "CATEGORÍA";

            // cmbCategoria
            this.cmbCategoria.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Font              = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location          = new System.Drawing.Point(398, 34);
            this.cmbCategoria.Name              = "cmbCategoria";
            this.cmbCategoria.Size              = new System.Drawing.Size(160, 24);
            this.cmbCategoria.TabIndex          = 3;

            // lblStock
            this.lblStock.AutoSize  = true;
            this.lblStock.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblStock.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblStock.Location  = new System.Drawing.Point(576, 14);
            this.lblStock.Name      = "lblStock";
            this.lblStock.TabIndex  = 4;
            this.lblStock.Text      = "STOCK";

            // cmbFiltroStock
            this.cmbFiltroStock.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroStock.Font              = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbFiltroStock.FormattingEnabled = true;
            this.cmbFiltroStock.Items.AddRange(new object[] { "Todos", "Con Stock", "Sin Stock", "Stock Bajo" });
            this.cmbFiltroStock.Location          = new System.Drawing.Point(576, 34);
            this.cmbFiltroStock.Name              = "cmbFiltroStock";
            this.cmbFiltroStock.Size              = new System.Drawing.Size(140, 24);
            this.cmbFiltroStock.TabIndex          = 5;

            // btnNuevo — primary action, green
            this.btnNuevo.Anchor              = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor           = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnNuevo.Cursor              = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize         = 0;
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 140, 75);
            this.btnNuevo.FlatStyle           = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font                = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor           = System.Drawing.Color.White;
            this.btnNuevo.Location            = new System.Drawing.Point(1030, 44);
            this.btnNuevo.Name                = "btnNuevo";
            this.btnNuevo.Size                = new System.Drawing.Size(180, 36);
            this.btnNuevo.TabIndex            = 6;
            this.btnNuevo.Text                = "+  Nuevo Producto";
            this.btnNuevo.UseVisualStyleBackColor = false;

            // btnExportar — secondary
            this.btnExportar.Anchor              = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor           = System.Drawing.Color.White;
            this.btnExportar.Cursor              = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderColor         = System.Drawing.Color.FromArgb(200, 210, 220);
            this.btnExportar.FlatAppearance.BorderSize          = 1;
            this.btnExportar.FlatAppearance.MouseOverBackColor  = System.Drawing.Color.FromArgb(244, 246, 250);
            this.btnExportar.FlatStyle           = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font                = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor           = System.Drawing.Color.FromArgb(45, 52, 54);
            this.btnExportar.Location            = new System.Drawing.Point(898, 44);
            this.btnExportar.Name                = "btnExportar";
            this.btnExportar.Size                = new System.Drawing.Size(122, 36);
            this.btnExportar.TabIndex            = 7;
            this.btnExportar.Text                = "📥  Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;

            // btnImportar — secondary
            this.btnImportar.Anchor              = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportar.BackColor           = System.Drawing.Color.White;
            this.btnImportar.Cursor              = System.Windows.Forms.Cursors.Hand;
            this.btnImportar.FlatAppearance.BorderColor         = System.Drawing.Color.FromArgb(200, 210, 220);
            this.btnImportar.FlatAppearance.BorderSize          = 1;
            this.btnImportar.FlatAppearance.MouseOverBackColor  = System.Drawing.Color.FromArgb(244, 246, 250);
            this.btnImportar.FlatStyle           = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.Font                = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnImportar.ForeColor           = System.Drawing.Color.FromArgb(45, 52, 54);
            this.btnImportar.Location            = new System.Drawing.Point(766, 44);
            this.btnImportar.Name                = "btnImportar";
            this.btnImportar.Size                = new System.Drawing.Size(122, 36);
            this.btnImportar.TabIndex            = 8;
            this.btnImportar.Text                = "📤  Importar";
            this.btnImportar.UseVisualStyleBackColor = false;

            // ── dgvProductos — Dock=Fill ───────────────────────────────────────
            this.dgvProductos.AllowUserToAddRows       = false;
            this.dgvProductos.AutoSizeRowsMode         = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProductos.BackgroundColor          = System.Drawing.Color.White;
            this.dgvProductos.BorderStyle              = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.CellBorderStyle          = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProductos.ColumnHeadersHeight      = 40;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNumero,
                this.colCodigo,
                this.colProducto,
                this.colCategoria,
                this.colUnidadBase,
                this.colPresentaciones,
                this.colPrecio,
                this.colStockTotal,
                this.colEditar,
                this.colEliminar });
            this.dgvProductos.Anchor                 = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.GridColor              = System.Drawing.Color.FromArgb(235, 237, 240);
            this.dgvProductos.Location               = new System.Drawing.Point(25, 202);
            this.dgvProductos.Name                   = "dgvProductos";
            this.dgvProductos.ReadOnly               = true;
            this.dgvProductos.RowHeadersVisible      = false;
            this.dgvProductos.SelectionMode          = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size                   = new System.Drawing.Size(1230, 462);
            this.dgvProductos.TabIndex               = 2;

            // colNumero
            this.colNumero.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colNumero.HeaderText = "#";
            this.colNumero.Name       = "colNumero";
            this.colNumero.ReadOnly   = true;
            this.colNumero.Width      = 52;

            // colCodigo
            this.colCodigo.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colCodigo.HeaderText = "CÓDIGO";
            this.colCodigo.Name       = "colCodigo";
            this.colCodigo.ReadOnly   = true;
            this.colCodigo.Width      = 120;

            // colProducto
            this.colProducto.AutoSizeMode                    = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProducto.DefaultCellStyle.Alignment      = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colProducto.DefaultCellStyle.Font           = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.colProducto.HeaderText = "PRODUCTO";
            this.colProducto.Name       = "colProducto";
            this.colProducto.ReadOnly   = true;

            // colCategoria
            this.colCategoria.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colCategoria.HeaderText = "CATEGORÍA";
            this.colCategoria.Name       = "colCategoria";
            this.colCategoria.ReadOnly   = true;
            this.colCategoria.Width      = 150;

            // colUnidadBase
            this.colUnidadBase.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colUnidadBase.HeaderText = "UNIDAD";
            this.colUnidadBase.Name       = "colUnidadBase";
            this.colUnidadBase.ReadOnly   = true;
            this.colUnidadBase.Width      = 90;

            // colPresentaciones
            this.colPresentaciones.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colPresentaciones.DefaultCellStyle.WrapMode  = System.Windows.Forms.DataGridViewTriState.True;
            this.colPresentaciones.HeaderText = "PRESENTACIONES";
            this.colPresentaciones.Name       = "colPresentaciones";
            this.colPresentaciones.ReadOnly   = true;
            this.colPresentaciones.Width      = 180;

            // colPrecio
            this.colPrecio.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPrecio.DefaultCellStyle.Padding   = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.colPrecio.DefaultCellStyle.WrapMode  = System.Windows.Forms.DataGridViewTriState.True;
            this.colPrecio.HeaderText = "PRECIO";
            this.colPrecio.Name       = "colPrecio";
            this.colPrecio.ReadOnly   = true;
            this.colPrecio.Width      = 140;

            // colStockTotal
            this.colStockTotal.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colStockTotal.HeaderText = "STOCK";
            this.colStockTotal.Name       = "colStockTotal";
            this.colStockTotal.ReadOnly   = true;
            this.colStockTotal.Width      = 120;

            // colEditar
            this.colEditar.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEditar.HeaderText = "";
            this.colEditar.Image      = ((System.Drawing.Image)(resources.GetObject("colEditar.Image")));
            this.colEditar.Name       = "colEditar";
            this.colEditar.ReadOnly   = true;
            this.colEditar.Resizable  = System.Windows.Forms.DataGridViewTriState.False;
            this.colEditar.SortMode   = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colEditar.Width      = 40;

            // colEliminar
            this.colEliminar.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEliminar.HeaderText = "";
            this.colEliminar.Image      = ((System.Drawing.Image)(resources.GetObject("colEliminar.Image")));
            this.colEliminar.Name       = "colEliminar";
            this.colEliminar.ReadOnly   = true;
            this.colEliminar.Resizable  = System.Windows.Forms.DataGridViewTriState.False;
            this.colEliminar.SortMode   = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colEliminar.Width      = 40;

            // ── pnlFooter — status bar ─────────────────────────────────────────
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.pnlFooterSep);
            this.pnlFooter.Controls.Add(this.lblRegistros);
            this.pnlFooter.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location  = new System.Drawing.Point(0, 690);
            this.pnlFooter.Name      = "pnlFooter";
            this.pnlFooter.Size      = new System.Drawing.Size(1280, 50);
            this.pnlFooter.TabIndex  = 3;

            // pnlFooterSep — 1px top border
            this.pnlFooterSep.BackColor = System.Drawing.Color.FromArgb(220, 224, 230);
            this.pnlFooterSep.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlFooterSep.Location  = new System.Drawing.Point(0, 0);
            this.pnlFooterSep.Name      = "pnlFooterSep";
            this.pnlFooterSep.Size      = new System.Drawing.Size(1280, 1);
            this.pnlFooterSep.TabIndex  = 0;

            // lblRegistros
            this.lblRegistros.AutoSize  = true;
            this.lblRegistros.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRegistros.ForeColor = System.Drawing.Color.FromArgb(100, 110, 120);
            this.lblRegistros.Location  = new System.Drawing.Point(20, 16);
            this.lblRegistros.Name      = "lblRegistros";
            this.lblRegistros.TabIndex  = 1;
            this.lblRegistros.Text      = "Mostrando 0 de 0 productos";

            // ── FormProductos ──────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(244, 246, 250);
            this.ClientSize          = new System.Drawing.Size(1280, 740);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize         = new System.Drawing.Size(1000, 600);
            this.Name                = "FormProductos";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Productos / Inventario";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubTitulo;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Panel pnlFiltroSep;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.ComboBox cmbFiltroStock;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidadBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPresentaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockTotal;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewImageColumn colEliminar;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlFooterSep;
        private System.Windows.Forms.Label lblRegistros;
    }
}
