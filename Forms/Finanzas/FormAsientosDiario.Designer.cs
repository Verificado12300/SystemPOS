namespace SistemaPOS.Forms.Finanzas
{
    partial class FormAsientosDiario
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
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lblTotalAsientos = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cboTipoOperacion = new System.Windows.Forms.ComboBox();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.cboCuenta = new System.Windows.Forms.ComboBox();
            this.lblBuscarTxt = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblMontoMin = new System.Windows.Forms.Label();
            this.txtMontoMin = new System.Windows.Forms.TextBox();
            this.lblMontoMax = new System.Windows.Forms.Label();
            this.txtMontoMax = new System.Windows.Forms.TextBox();
            this.dgvAsientos = new System.Windows.Forms.DataGridView();
            this.pnlPaginacion = new System.Windows.Forms.Panel();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.lblPagina = new System.Windows.Forms.Label();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblDetalleHeader = new System.Windows.Forms.Label();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.pnlFiltros.SuspendLayout();
            this.pnlPaginacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.SuspendLayout();
            //
            // pnlFiltros
            //
            this.pnlFiltros.Controls.Add(this.lblDesde);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.btnBuscar);
            this.pnlFiltros.Controls.Add(this.btnExportar);
            this.pnlFiltros.Controls.Add(this.lblTotalAsientos);
            this.pnlFiltros.Controls.Add(this.lblTipo);
            this.pnlFiltros.Controls.Add(this.cboTipoOperacion);
            this.pnlFiltros.Controls.Add(this.lblCuenta);
            this.pnlFiltros.Controls.Add(this.cboCuenta);
            this.pnlFiltros.Controls.Add(this.lblBuscarTxt);
            this.pnlFiltros.Controls.Add(this.txtBuscar);
            this.pnlFiltros.Controls.Add(this.lblMontoMin);
            this.pnlFiltros.Controls.Add(this.txtMontoMin);
            this.pnlFiltros.Controls.Add(this.lblMontoMax);
            this.pnlFiltros.Controls.Add(this.txtMontoMax);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1458, 62);
            this.pnlFiltros.TabIndex = 0;
            //
            // lblDesde
            //
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(10, 12);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde:";
            //
            // dtpDesde
            //
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(56, 8);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpDesde.TabIndex = 1;
            //
            // lblHasta
            //
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(164, 12);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta:";
            //
            // dtpHasta
            //
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(206, 8);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpHasta.TabIndex = 3;
            //
            // btnBuscar
            //
            this.btnBuscar.Location = new System.Drawing.Point(314, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 24);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            //
            // btnExportar
            //
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnExportar.Location = new System.Drawing.Point(1330, 6);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(120, 24);
            this.btnExportar.TabIndex = 20;
            this.btnExportar.Text = "⬇ Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.Click += new System.EventHandler(this.BtnExportar_Click);
            //
            // lblTotalAsientos
            //
            this.lblTotalAsientos.AutoSize = true;
            this.lblTotalAsientos.Location = new System.Drawing.Point(402, 12);
            this.lblTotalAsientos.Name = "lblTotalAsientos";
            this.lblTotalAsientos.Size = new System.Drawing.Size(85, 13);
            this.lblTotalAsientos.TabIndex = 5;
            this.lblTotalAsientos.Text = "Total: 0 asientos";
            //
            // lblTipo
            //
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(10, 40);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 10;
            this.lblTipo.Text = "Tipo:";
            //
            // cboTipoOperacion
            //
            this.cboTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOperacion.Location = new System.Drawing.Point(46, 36);
            this.cboTipoOperacion.Name = "cboTipoOperacion";
            this.cboTipoOperacion.Size = new System.Drawing.Size(130, 21);
            this.cboTipoOperacion.TabIndex = 11;
            //
            // lblCuenta
            //
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(184, 40);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(44, 13);
            this.lblCuenta.TabIndex = 12;
            this.lblCuenta.Text = "Cuenta:";
            //
            // cboCuenta
            //
            this.cboCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCuenta.Location = new System.Drawing.Point(232, 36);
            this.cboCuenta.Name = "cboCuenta";
            this.cboCuenta.Size = new System.Drawing.Size(200, 21);
            this.cboCuenta.TabIndex = 13;
            //
            // lblBuscarTxt
            //
            this.lblBuscarTxt.AutoSize = true;
            this.lblBuscarTxt.Location = new System.Drawing.Point(440, 40);
            this.lblBuscarTxt.Name = "lblBuscarTxt";
            this.lblBuscarTxt.Size = new System.Drawing.Size(43, 13);
            this.lblBuscarTxt.TabIndex = 14;
            this.lblBuscarTxt.Text = "Buscar:";
            //
            // txtBuscar
            //
            this.txtBuscar.Location = new System.Drawing.Point(486, 36);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(180, 20);
            this.txtBuscar.TabIndex = 15;
            //
            // lblMontoMin
            //
            this.lblMontoMin.AutoSize = true;
            this.lblMontoMin.Location = new System.Drawing.Point(674, 40);
            this.lblMontoMin.Name = "lblMontoMin";
            this.lblMontoMin.Size = new System.Drawing.Size(49, 13);
            this.lblMontoMin.TabIndex = 16;
            this.lblMontoMin.Text = "Monto>=";
            //
            // txtMontoMin
            //
            this.txtMontoMin.Location = new System.Drawing.Point(726, 36);
            this.txtMontoMin.Name = "txtMontoMin";
            this.txtMontoMin.Size = new System.Drawing.Size(80, 20);
            this.txtMontoMin.TabIndex = 17;
            //
            // lblMontoMax
            //
            this.lblMontoMax.AutoSize = true;
            this.lblMontoMax.Location = new System.Drawing.Point(814, 40);
            this.lblMontoMax.Name = "lblMontoMax";
            this.lblMontoMax.Size = new System.Drawing.Size(49, 13);
            this.lblMontoMax.TabIndex = 18;
            this.lblMontoMax.Text = "Monto<=";
            //
            // txtMontoMax
            //
            this.txtMontoMax.Location = new System.Drawing.Point(866, 36);
            this.txtMontoMax.Name = "txtMontoMax";
            this.txtMontoMax.Size = new System.Drawing.Size(80, 20);
            this.txtMontoMax.TabIndex = 19;
            //
            // dgvAsientos  (top half — ~60% del área disponible)
            //
            this.dgvAsientos.AllowUserToAddRows = false;
            this.dgvAsientos.AllowUserToDeleteRows = false;
            this.dgvAsientos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAsientos.Location = new System.Drawing.Point(12, 74);
            this.dgvAsientos.MultiSelect = false;
            this.dgvAsientos.Name = "dgvAsientos";
            this.dgvAsientos.ReadOnly = true;
            this.dgvAsientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsientos.Size = new System.Drawing.Size(1434, 380);
            this.dgvAsientos.TabIndex = 1;
            this.dgvAsientos.SelectionChanged += new System.EventHandler(this.DgvAsientos_SelectionChanged);
            //
            // pnlPaginacion
            //
            this.pnlPaginacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPaginacion.Controls.Add(this.btnAnterior);
            this.pnlPaginacion.Controls.Add(this.lblPagina);
            this.pnlPaginacion.Controls.Add(this.btnSiguiente);
            this.pnlPaginacion.Location = new System.Drawing.Point(12, 462);
            this.pnlPaginacion.Name = "pnlPaginacion";
            this.pnlPaginacion.Size = new System.Drawing.Size(1434, 32);
            this.pnlPaginacion.TabIndex = 2;
            //
            // btnAnterior
            //
            this.btnAnterior.Enabled = false;
            this.btnAnterior.Location = new System.Drawing.Point(0, 4);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(90, 24);
            this.btnAnterior.TabIndex = 0;
            this.btnAnterior.Text = "< Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.BtnAnterior_Click);
            //
            // lblPagina
            //
            this.lblPagina.Location = new System.Drawing.Point(96, 8);
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Size = new System.Drawing.Size(160, 18);
            this.lblPagina.TabIndex = 1;
            this.lblPagina.Text = "Página 1 de 1";
            this.lblPagina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnSiguiente
            //
            this.btnSiguiente.Enabled = false;
            this.btnSiguiente.Location = new System.Drawing.Point(262, 4);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(90, 24);
            this.btnSiguiente.TabIndex = 2;
            this.btnSiguiente.Text = "Siguiente >";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.BtnSiguiente_Click);
            //
            // lblDetalleHeader
            //
            this.lblDetalleHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetalleHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDetalleHeader.Location = new System.Drawing.Point(12, 502);
            this.lblDetalleHeader.Name = "lblDetalleHeader";
            this.lblDetalleHeader.Size = new System.Drawing.Size(300, 16);
            this.lblDetalleHeader.TabIndex = 3;
            this.lblDetalleHeader.Text = "Detalle del asiento seleccionado";
            //
            // dgvDetalles  (bottom ~38% del área disponible)
            //
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalles.Location = new System.Drawing.Point(12, 522);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(1434, 228);
            this.dgvDetalles.TabIndex = 4;
            this.dgvDetalles.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DgvDetalles_DataBindingComplete);
            //
            // FormAsientosDiario
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1458, 762);
            this.Controls.Add(this.dgvDetalles);
            this.Controls.Add(this.lblDetalleHeader);
            this.Controls.Add(this.pnlPaginacion);
            this.Controls.Add(this.dgvAsientos);
            this.Controls.Add(this.pnlFiltros);
            this.Name = "FormAsientosDiario";
            this.Text = "Asientos";
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlPaginacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label lblTotalAsientos;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cboTipoOperacion;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.ComboBox cboCuenta;
        private System.Windows.Forms.Label lblBuscarTxt;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblMontoMin;
        private System.Windows.Forms.TextBox txtMontoMin;
        private System.Windows.Forms.Label lblMontoMax;
        private System.Windows.Forms.TextBox txtMontoMax;
        private System.Windows.Forms.DataGridView dgvAsientos;
        private System.Windows.Forms.Panel pnlPaginacion;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblDetalleHeader;
        private System.Windows.Forms.DataGridView dgvDetalles;
    }
}
