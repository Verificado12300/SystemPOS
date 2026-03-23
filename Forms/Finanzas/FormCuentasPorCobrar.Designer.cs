namespace SistemaPOS.Forms.Finanzas
{
    partial class FormCuentasPorCobrar
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
            System.Windows.Forms.DataGridViewCellStyle hdrStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle rowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader         = new System.Windows.Forms.Panel();
            this.lblTitulo         = new System.Windows.Forms.Label();
            this.lblHeaderSub      = new System.Windows.Forms.Label();
            this.pnlFiltros        = new System.Windows.Forms.Panel();
            this.lblBuscar         = new System.Windows.Forms.Label();
            this.txtBuscar         = new System.Windows.Forms.TextBox();
            this.lblEstado         = new System.Windows.Forms.Label();
            this.cmbEstado         = new System.Windows.Forms.ComboBox();
            this.btnFiltrar        = new System.Windows.Forms.Button();
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
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            this.pnlResumen.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Dock   = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 68;
            this.pnlHeader.Name   = "pnlHeader";
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Text      = "Cuentas por Cobrar";
            //
            // lblHeaderSub
            //
            this.lblHeaderSub.AutoSize  = true;
            this.lblHeaderSub.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(178, 190, 195);
            this.lblHeaderSub.Location  = new System.Drawing.Point(22, 42);
            this.lblHeaderSub.Name      = "lblHeaderSub";
            this.lblHeaderSub.Text      = "Resumen de créditos por cliente";
            //
            // pnlFiltros
            //
            this.pnlFiltros.Anchor    = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Controls.Add(this.lblBuscar);
            this.pnlFiltros.Controls.Add(this.txtBuscar);
            this.pnlFiltros.Controls.Add(this.lblEstado);
            this.pnlFiltros.Controls.Add(this.cmbEstado);
            this.pnlFiltros.Controls.Add(this.btnFiltrar);
            this.pnlFiltros.Location  = new System.Drawing.Point(0, 68);
            this.pnlFiltros.Name      = "pnlFiltros";
            this.pnlFiltros.Size      = new System.Drawing.Size(1200, 60);
            this.pnlFiltros.TabIndex  = 1;
            //
            // lblBuscar
            //
            this.lblBuscar.AutoSize  = true;
            this.lblBuscar.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblBuscar.Location  = new System.Drawing.Point(15, 8);
            this.lblBuscar.Name      = "lblBuscar";
            this.lblBuscar.Text      = "Buscar cliente:";
            //
            // txtBuscar
            //
            this.txtBuscar.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(15, 28);
            this.txtBuscar.Name     = "txtBuscar";
            this.txtBuscar.Size     = new System.Drawing.Size(260, 23);
            this.txtBuscar.TabIndex = 0;
            //
            // lblEstado
            //
            this.lblEstado.AutoSize  = true;
            this.lblEstado.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblEstado.Location  = new System.Drawing.Point(290, 8);
            this.lblEstado.Name      = "lblEstado";
            this.lblEstado.Text      = "Estado:";
            //
            // cmbEstado
            //
            this.cmbEstado.DropDownStyle    = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font             = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] { "TODOS", "PENDIENTE", "CANCELADO" });
            this.cmbEstado.Location         = new System.Drawing.Point(290, 28);
            this.cmbEstado.Name             = "cmbEstado";
            this.cmbEstado.Size             = new System.Drawing.Size(160, 23);
            this.cmbEstado.TabIndex         = 1;
            //
            // btnFiltrar
            //
            this.btnFiltrar.BackColor                         = System.Drawing.Color.FromArgb(245, 246, 250);
            this.btnFiltrar.Cursor                            = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderColor        = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnFiltrar.FlatAppearance.BorderSize         = 1;
            this.btnFiltrar.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font                              = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor                         = System.Drawing.Color.FromArgb(45, 52, 54);
            this.btnFiltrar.Location                          = new System.Drawing.Point(465, 27);
            this.btnFiltrar.Name                              = "btnFiltrar";
            this.btnFiltrar.Size                              = new System.Drawing.Size(100, 26);
            this.btnFiltrar.TabIndex                          = 2;
            this.btnFiltrar.Text                              = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor           = false;
            this.btnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);
            //
            // dgvCuentas
            //
            this.dgvCuentas.AllowUserToAddRows        = false;
            this.dgvCuentas.AllowUserToDeleteRows     = false;
            this.dgvCuentas.Anchor                    = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCuentas.BackgroundColor           = System.Drawing.Color.White;
            this.dgvCuentas.BorderStyle               = System.Windows.Forms.BorderStyle.None;
            this.dgvCuentas.ColumnHeadersBorderStyle  = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            hdrStyle.Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            hdrStyle.BackColor          = System.Drawing.Color.FromArgb(240, 242, 245);
            hdrStyle.Font               = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            hdrStyle.ForeColor          = System.Drawing.Color.FromArgb(45, 52, 54);
            hdrStyle.SelectionBackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            hdrStyle.SelectionForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            hdrStyle.WrapMode           = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCuentas.ColumnHeadersDefaultCellStyle    = hdrStyle;
            this.dgvCuentas.ColumnHeadersHeightSizeMode      = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNumero, this.colCliente, this.colDocumentos,
                this.colTotalVentas, this.colTotalPagado, this.colTotalPendiente,
                this.colEstado, this.colDetalle });
            rowStyle.Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            rowStyle.BackColor          = System.Drawing.Color.White;
            rowStyle.Font               = new System.Drawing.Font("Segoe UI", 9.5F);
            rowStyle.ForeColor          = System.Drawing.Color.FromArgb(45, 52, 54);
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(232, 245, 215);
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.dgvCuentas.DefaultCellStyle              = rowStyle;
            this.dgvCuentas.EnableHeadersVisualStyles     = false;
            this.dgvCuentas.Location                      = new System.Drawing.Point(0, 128);
            this.dgvCuentas.Name                          = "dgvCuentas";
            this.dgvCuentas.ReadOnly                      = true;
            this.dgvCuentas.RowHeadersVisible             = false;
            this.dgvCuentas.RowTemplate.Height            = 40;
            this.dgvCuentas.SelectionMode                 = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuentas.Size                          = new System.Drawing.Size(1200, 490);
            this.dgvCuentas.TabIndex                      = 2;
            this.dgvCuentas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCuentas_CellContentClick);
            //
            // colNumero
            //
            this.colNumero.HeaderText = "#";
            this.colNumero.Name       = "colNumero";
            this.colNumero.ReadOnly   = true;
            this.colNumero.Width      = 45;
            //
            // colCliente
            //
            this.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCliente.HeaderText   = "Cliente";
            this.colCliente.Name         = "colCliente";
            this.colCliente.ReadOnly     = true;
            //
            // colDocumentos
            //
            this.colDocumentos.HeaderText = "Docs";
            this.colDocumentos.Name       = "colDocumentos";
            this.colDocumentos.ReadOnly   = true;
            this.colDocumentos.Width      = 55;
            this.colDocumentos.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //
            // colTotalVentas
            //
            this.colTotalVentas.HeaderText = "Total Ventas";
            this.colTotalVentas.Name       = "colTotalVentas";
            this.colTotalVentas.ReadOnly   = true;
            this.colTotalVentas.Width      = 120;
            this.colTotalVentas.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            //
            // colTotalPagado
            //
            this.colTotalPagado.HeaderText = "Pagado";
            this.colTotalPagado.Name       = "colTotalPagado";
            this.colTotalPagado.ReadOnly   = true;
            this.colTotalPagado.Width      = 115;
            this.colTotalPagado.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            //
            // colTotalPendiente
            //
            this.colTotalPendiente.HeaderText = "Pendiente";
            this.colTotalPendiente.Name       = "colTotalPendiente";
            this.colTotalPendiente.ReadOnly   = true;
            this.colTotalPendiente.Width      = 115;
            this.colTotalPendiente.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            //
            // colEstado
            //
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name       = "colEstado";
            this.colEstado.ReadOnly   = true;
            this.colEstado.Width      = 100;
            this.colEstado.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //
            // colDetalle
            //
            this.colDetalle.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.colDetalle.HeaderText                = "";
            this.colDetalle.Name                      = "colDetalle";
            this.colDetalle.ReadOnly                  = false;
            this.colDetalle.Text                      = "Detalle";
            this.colDetalle.UseColumnTextForButtonValue = true;
            this.colDetalle.Width                     = 90;
            //
            // pnlResumen
            //
            this.pnlResumen.BackColor = System.Drawing.Color.White;
            this.pnlResumen.Controls.Add(this.lblTotalRegistros);
            this.pnlResumen.Controls.Add(this.lblTotalPendiente);
            this.pnlResumen.Controls.Add(this.txtTotalPendiente);
            this.pnlResumen.Dock     = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumen.Height   = 50;
            this.pnlResumen.Name     = "pnlResumen";
            this.pnlResumen.TabIndex = 3;
            //
            // lblTotalRegistros
            //
            this.lblTotalRegistros.AutoSize  = true;
            this.lblTotalRegistros.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalRegistros.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblTotalRegistros.Location  = new System.Drawing.Point(15, 17);
            this.lblTotalRegistros.Name      = "lblTotalRegistros";
            this.lblTotalRegistros.Text      = "Total: 0 clientes";
            //
            // lblTotalPendiente
            //
            this.lblTotalPendiente.Anchor    = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPendiente.AutoSize  = true;
            this.lblTotalPendiente.Font      = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalPendiente.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblTotalPendiente.Location  = new System.Drawing.Point(940, 14);
            this.lblTotalPendiente.Name      = "lblTotalPendiente";
            this.lblTotalPendiente.Text      = "Total Pendiente:";
            //
            // txtTotalPendiente
            //
            this.txtTotalPendiente.Anchor      = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalPendiente.BackColor   = System.Drawing.Color.White;
            this.txtTotalPendiente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalPendiente.Font        = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalPendiente.ForeColor   = System.Drawing.Color.FromArgb(192, 57, 43);
            this.txtTotalPendiente.Location    = new System.Drawing.Point(1075, 14);
            this.txtTotalPendiente.Name        = "txtTotalPendiente";
            this.txtTotalPendiente.ReadOnly    = true;
            this.txtTotalPendiente.Size        = new System.Drawing.Size(110, 22);
            this.txtTotalPendiente.TabIndex    = 2;
            this.txtTotalPendiente.Text        = "S/ 0.00";
            this.txtTotalPendiente.TextAlign   = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // FormCuentasPorCobrar
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(245, 246, 250);
            this.ClientSize          = new System.Drawing.Size(1200, 670);
            this.Controls.Add(this.dgvCuentas);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.None;
            this.Name                = "FormCuentasPorCobrar";
            this.Text                = "Cuentas por Cobrar";
            this.Load               += new System.EventHandler(this.FormCuentasPorCobrar_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel                       pnlHeader;
        private System.Windows.Forms.Label                       lblTitulo;
        private System.Windows.Forms.Label                       lblHeaderSub;
        private System.Windows.Forms.Panel                       pnlFiltros;
        private System.Windows.Forms.Label                       lblBuscar;
        private System.Windows.Forms.TextBox                     txtBuscar;
        private System.Windows.Forms.Label                       lblEstado;
        private System.Windows.Forms.ComboBox                    cmbEstado;
        private System.Windows.Forms.Button                      btnFiltrar;
        private System.Windows.Forms.DataGridView                dgvCuentas;
        private System.Windows.Forms.Panel                       pnlResumen;
        private System.Windows.Forms.Label                       lblTotalRegistros;
        private System.Windows.Forms.Label                       lblTotalPendiente;
        private System.Windows.Forms.TextBox                     txtTotalPendiente;
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
