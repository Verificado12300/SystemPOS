namespace SistemaPOS.Forms.Reportes
{
    partial class FormBalanceComprobacion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle hdrStyle  = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle rowStyle  = new System.Windows.Forms.DataGridViewCellStyle();

            this.lblTitulo       = new System.Windows.Forms.Label();
            this.pnlFiltros      = new System.Windows.Forms.Panel();
            this.lblDesde        = new System.Windows.Forms.Label();
            this.dtpDesde        = new System.Windows.Forms.DateTimePicker();
            this.lblHasta        = new System.Windows.Forms.Label();
            this.dtpHasta        = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar       = new System.Windows.Forms.Button();
            this.dgvComprobacion = new System.Windows.Forms.DataGridView();
            this.colCodigo       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebe         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHaber        = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldo        = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlResumen      = new System.Windows.Forms.Panel();
            this.lblCapDiferencia = new System.Windows.Forms.Label();
            this.lblDiferencia   = new System.Windows.Forms.Label();
            this.lblCapTotalHaber = new System.Windows.Forms.Label();
            this.lblTotalHaber   = new System.Windows.Forms.Label();
            this.lblCapTotalDebe = new System.Windows.Forms.Label();
            this.lblTotalDebe    = new System.Windows.Forms.Label();

            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobacion)).BeginInit();
            this.pnlResumen.SuspendLayout();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblTitulo.Location  = new System.Drawing.Point(15, 15);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Text      = "Balance de Comprobación";

            // pnlFiltros
            this.pnlFiltros.Anchor    = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Controls.Add(this.btnBuscar);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.lblDesde);
            this.pnlFiltros.Location  = new System.Drawing.Point(20, 50);
            this.pnlFiltros.Name      = "pnlFiltros";
            this.pnlFiltros.Size      = new System.Drawing.Size(1160, 60);

            // lblDesde
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesde.Location = new System.Drawing.Point(15, 10);
            this.lblDesde.Text     = "Desde:";

            // dtpDesde
            this.dtpDesde.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDesde.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(15, 28);
            this.dtpDesde.Size     = new System.Drawing.Size(140, 23);
            this.dtpDesde.Name     = "dtpDesde";

            // lblHasta
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHasta.Location = new System.Drawing.Point(175, 10);
            this.lblHasta.Text     = "Hasta:";

            // dtpHasta
            this.dtpHasta.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHasta.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(175, 28);
            this.dtpHasta.Size     = new System.Drawing.Size(140, 23);
            this.dtpHasta.Name     = "dtpHasta";

            // btnBuscar
            this.btnBuscar.BackColor  = System.Drawing.Color.White;
            this.btnBuscar.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.FlatAppearance.BorderColor         = System.Drawing.Color.FromArgb(223, 228, 234);
            this.btnBuscar.FlatAppearance.MouseOverBackColor  = System.Drawing.Color.FromArgb(244, 244, 250);
            this.btnBuscar.Font       = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor  = System.Drawing.Color.FromArgb(45, 52, 54);
            this.btnBuscar.Location   = new System.Drawing.Point(335, 24);
            this.btnBuscar.Name       = "btnBuscar";
            this.btnBuscar.Size       = new System.Drawing.Size(90, 28);
            this.btnBuscar.Text       = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;

            // dgvComprobacion
            hdrStyle.Alignment        = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            hdrStyle.BackColor        = System.Drawing.Color.FromArgb(240, 242, 245);
            hdrStyle.Font             = new System.Drawing.Font("Segoe UI", 9.5F);
            hdrStyle.ForeColor        = System.Drawing.Color.FromArgb(45, 52, 54);
            hdrStyle.SelectionBackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            hdrStyle.SelectionForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            hdrStyle.WrapMode         = System.Windows.Forms.DataGridViewTriState.True;

            rowStyle.Alignment        = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            rowStyle.BackColor        = System.Drawing.Color.White;
            rowStyle.Font             = new System.Drawing.Font("Segoe UI", 9.5F);
            rowStyle.ForeColor        = System.Drawing.Color.FromArgb(45, 52, 54);
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(232, 245, 215);
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            rowStyle.WrapMode         = System.Windows.Forms.DataGridViewTriState.False;

            this.dgvComprobacion.AllowUserToAddRows    = false;
            this.dgvComprobacion.AllowUserToDeleteRows = false;
            this.dgvComprobacion.Anchor               = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvComprobacion.BackgroundColor       = System.Drawing.Color.White;
            this.dgvComprobacion.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvComprobacion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvComprobacion.ColumnHeadersDefaultCellStyle = hdrStyle;
            this.dgvComprobacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComprobacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCodigo, this.colNombre, this.colTipo,
                this.colDebe, this.colHaber, this.colSaldo });
            this.dgvComprobacion.DefaultCellStyle      = rowStyle;
            this.dgvComprobacion.EnableHeadersVisualStyles = false;
            this.dgvComprobacion.Location              = new System.Drawing.Point(20, 125);
            this.dgvComprobacion.Name                  = "dgvComprobacion";
            this.dgvComprobacion.ReadOnly              = true;
            this.dgvComprobacion.RowHeadersVisible     = false;
            this.dgvComprobacion.RowTemplate.Height    = 30;
            this.dgvComprobacion.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComprobacion.Size                  = new System.Drawing.Size(1160, 460);

            // colCodigo
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name       = "colCodigo";
            this.colCodigo.ReadOnly   = true;
            this.colCodigo.Width      = 80;

            // colNombre
            this.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombre.HeaderText   = "Nombre";
            this.colNombre.Name         = "colNombre";
            this.colNombre.ReadOnly     = true;

            // colTipo
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name       = "colTipo";
            this.colTipo.ReadOnly   = true;
            this.colTipo.Width      = 120;

            // colDebe
            this.colDebe.HeaderText = "Debe";
            this.colDebe.Name       = "colDebe";
            this.colDebe.ReadOnly   = true;
            this.colDebe.Width      = 150;

            // colHaber
            this.colHaber.HeaderText = "Haber";
            this.colHaber.Name       = "colHaber";
            this.colHaber.ReadOnly   = true;
            this.colHaber.Width      = 150;

            // colSaldo
            this.colSaldo.HeaderText = "Saldo";
            this.colSaldo.Name       = "colSaldo";
            this.colSaldo.ReadOnly   = true;
            this.colSaldo.Width      = 150;

            // pnlResumen
            this.pnlResumen.Anchor    = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlResumen.BackColor = System.Drawing.Color.White;
            this.pnlResumen.Controls.Add(this.lblCapTotalDebe);
            this.pnlResumen.Controls.Add(this.lblTotalDebe);
            this.pnlResumen.Controls.Add(this.lblCapTotalHaber);
            this.pnlResumen.Controls.Add(this.lblTotalHaber);
            this.pnlResumen.Controls.Add(this.lblCapDiferencia);
            this.pnlResumen.Controls.Add(this.lblDiferencia);
            this.pnlResumen.Location  = new System.Drawing.Point(20, 598);
            this.pnlResumen.Name      = "pnlResumen";
            this.pnlResumen.Size      = new System.Drawing.Size(1160, 55);

            // lblCapTotalDebe
            this.lblCapTotalDebe.AutoSize  = true;
            this.lblCapTotalDebe.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCapTotalDebe.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblCapTotalDebe.Location  = new System.Drawing.Point(10, 8);
            this.lblCapTotalDebe.Text      = "Total Debe:";

            // lblTotalDebe
            this.lblTotalDebe.AutoSize  = true;
            this.lblTotalDebe.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalDebe.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblTotalDebe.Location  = new System.Drawing.Point(10, 28);
            this.lblTotalDebe.Name      = "lblTotalDebe";
            this.lblTotalDebe.Text      = "S/ 0.00";

            // lblCapTotalHaber
            this.lblCapTotalHaber.AutoSize  = true;
            this.lblCapTotalHaber.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCapTotalHaber.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblCapTotalHaber.Location  = new System.Drawing.Point(200, 8);
            this.lblCapTotalHaber.Text      = "Total Haber:";

            // lblTotalHaber
            this.lblTotalHaber.AutoSize  = true;
            this.lblTotalHaber.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalHaber.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblTotalHaber.Location  = new System.Drawing.Point(200, 28);
            this.lblTotalHaber.Name      = "lblTotalHaber";
            this.lblTotalHaber.Text      = "S/ 0.00";

            // lblCapDiferencia
            this.lblCapDiferencia.AutoSize  = true;
            this.lblCapDiferencia.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCapDiferencia.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblCapDiferencia.Location  = new System.Drawing.Point(400, 8);
            this.lblCapDiferencia.Text      = "Diferencia (Debe - Haber):";

            // lblDiferencia
            this.lblDiferencia.AutoSize  = true;
            this.lblDiferencia.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiferencia.ForeColor = System.Drawing.Color.Green;
            this.lblDiferencia.Location  = new System.Drawing.Point(400, 28);
            this.lblDiferencia.Name      = "lblDiferencia";
            this.lblDiferencia.Text      = "S/ 0.00";

            // FormBalanceComprobacion
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(244, 244, 250);
            this.ClientSize          = new System.Drawing.Size(1200, 670);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.dgvComprobacion);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.None;
            this.Name                = "FormBalanceComprobacion";
            this.Text                = "Balance de Comprobación";
            this.Load               += new System.EventHandler(this.FormBalanceComprobacion_Load);

            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobacion)).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label         lblTitulo;
        private System.Windows.Forms.Panel         pnlFiltros;
        private System.Windows.Forms.Label         lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label         lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button        btnBuscar;
        private System.Windows.Forms.DataGridView  dgvComprobacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHaber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldo;
        private System.Windows.Forms.Panel         pnlResumen;
        private System.Windows.Forms.Label         lblCapTotalDebe;
        private System.Windows.Forms.Label         lblTotalDebe;
        private System.Windows.Forms.Label         lblCapTotalHaber;
        private System.Windows.Forms.Label         lblTotalHaber;
        private System.Windows.Forms.Label         lblCapDiferencia;
        private System.Windows.Forms.Label         lblDiferencia;
    }
}
