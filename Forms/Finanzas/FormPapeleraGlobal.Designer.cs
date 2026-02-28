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
            this.pnlHeader    = new System.Windows.Forms.Panel();
            this.lblTitulo    = new System.Windows.Forms.Label();
            this.pnlFiltros   = new System.Windows.Forms.Panel();
            this.lblDesde     = new System.Windows.Forms.Label();
            this.dtpDesde     = new System.Windows.Forms.DateTimePicker();
            this.lblHasta     = new System.Windows.Forms.Label();
            this.dtpHasta     = new System.Windows.Forms.DateTimePicker();
            this.lblEntidad   = new System.Windows.Forms.Label();
            this.cmbEntidad   = new System.Windows.Forms.ComboBox();
            this.txtBuscar    = new System.Windows.Forms.TextBox();
            this.btnFiltrar   = new System.Windows.Forms.Button();
            this.dgvPapelera  = new System.Windows.Forms.DataGridView();
            this.colEntidad   = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId        = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaElim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuarioElim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRestaurar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlFooter    = new System.Windows.Forms.Panel();
            this.lblConteo    = new System.Windows.Forms.Label();
            this.btnCerrar    = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPapelera)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 50;

            // lblTitulo
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Text = "Papelera Global";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitulo.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);

            // pnlFiltros
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Height = 55;
            this.pnlFiltros.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnlFiltros.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblDesde, this.dtpDesde,
                this.lblHasta, this.dtpHasta,
                this.lblEntidad, this.cmbEntidad,
                this.txtBuscar, this.btnFiltrar
            });

            // lblDesde
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblDesde.Location = new System.Drawing.Point(10, 18);
            this.lblDesde.Text = "Desde:";

            // dtpDesde
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.CustomFormat = "dd/MM/yyyy";
            this.dtpDesde.Location = new System.Drawing.Point(58, 14);
            this.dtpDesde.Size = new System.Drawing.Size(105, 23);

            // lblHasta
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblHasta.Location = new System.Drawing.Point(170, 18);
            this.lblHasta.Text = "Hasta:";

            // dtpHasta
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.CustomFormat = "dd/MM/yyyy";
            this.dtpHasta.Location = new System.Drawing.Point(212, 14);
            this.dtpHasta.Size = new System.Drawing.Size(105, 23);

            // lblEntidad
            this.lblEntidad.AutoSize = true;
            this.lblEntidad.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEntidad.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblEntidad.Location = new System.Drawing.Point(326, 18);
            this.lblEntidad.Text = "Tipo:";

            // cmbEntidad
            this.cmbEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEntidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbEntidad.Items.AddRange(new object[] { "TODOS", "GASTO", "VENTA", "COMPRA", "CLIENTE", "PROVEEDOR", "PRODUCTO", "CXP" });
            this.cmbEntidad.Location = new System.Drawing.Point(362, 14);
            this.cmbEntidad.Size = new System.Drawing.Size(110, 24);

            // txtBuscar
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(482, 14);
            this.txtBuscar.Size = new System.Drawing.Size(160, 24);

            // btnFiltrar
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(652, 12);
            this.btnFiltrar.Size = new System.Drawing.Size(80, 28);
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);

            // dgvPapelera
            this.dgvPapelera.AllowUserToAddRows    = false;
            this.dgvPapelera.AllowUserToDeleteRows = false;
            this.dgvPapelera.AutoGenerateColumns   = false;
            this.dgvPapelera.BackgroundColor = System.Drawing.Color.White;
            this.dgvPapelera.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPapelera.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPapelera.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.dgvPapelera.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.dgvPapelera.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.dgvPapelera.ColumnHeadersHeight = 36;
            this.dgvPapelera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPapelera.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvPapelera.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvPapelera.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(214, 234, 248);
            this.dgvPapelera.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvPapelera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPapelera.GridColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.dgvPapelera.ReadOnly = true;
            this.dgvPapelera.RowHeadersVisible = false;
            this.dgvPapelera.RowTemplate.Height = 36;
            this.dgvPapelera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPapelera.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colEntidad, this.colId, this.colReferencia,
                this.colFechaElim, this.colUsuarioElim,
                this.colRestaurar
            });
            this.dgvPapelera.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPapelera_CellContentClick);

            // colEntidad
            this.colEntidad.Name = "colEntidad";
            this.colEntidad.HeaderText = "Tipo";
            this.colEntidad.Width = 75;
            this.colEntidad.ReadOnly = true;

            // colId
            this.colId.Name = "colId";
            this.colId.HeaderText = "ID";
            this.colId.Width = 50;
            this.colId.ReadOnly = true;

            // colReferencia
            this.colReferencia.Name = "colReferencia";
            this.colReferencia.HeaderText = "Referencia / Concepto";
            this.colReferencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colReferencia.ReadOnly = true;

            // colFechaElim
            this.colFechaElim.Name = "colFechaElim";
            this.colFechaElim.HeaderText = "Eliminado el";
            this.colFechaElim.Width = 130;
            this.colFechaElim.ReadOnly = true;

            // colUsuarioElim
            this.colUsuarioElim.Name = "colUsuarioElim";
            this.colUsuarioElim.HeaderText = "Por";
            this.colUsuarioElim.Width = 100;
            this.colUsuarioElim.ReadOnly = true;

            // colRestaurar
            this.colRestaurar.Name = "colRestaurar";
            this.colRestaurar.HeaderText = "";
            this.colRestaurar.Text = "Restaurar";
            this.colRestaurar.UseColumnTextForButtonValue = true;
            this.colRestaurar.Width = 90;
            this.colRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colRestaurar.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.colRestaurar.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.colRestaurar.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);

            // pnlFooter
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 45;
            this.pnlFooter.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblConteo, this.btnCerrar
            });

            // lblConteo
            this.lblConteo.AutoSize = false;
            this.lblConteo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblConteo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblConteo.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblConteo.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.lblConteo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblConteo.Width = 300;

            // btnCerrar
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(795, 8);
            this.btnCerrar.Size = new System.Drawing.Size(90, 30);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);

            // FormPapeleraGlobal
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 580);
            this.Controls.Add(this.dgvPapelera);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPapeleraGlobal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Papelera Global";
            this.Load += new System.EventHandler(this.FormPapeleraGlobal_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPapelera)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblEntidad;
        private System.Windows.Forms.ComboBox cmbEntidad;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DataGridView dgvPapelera;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaElim;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuarioElim;
        private System.Windows.Forms.DataGridViewButtonColumn colRestaurar;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblConteo;
        private System.Windows.Forms.Button btnCerrar;
    }
}
