namespace SistemaPOS.Forms.Finanzas
{
    partial class FormCuentasPorPagar
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.dgvCuentas = new System.Windows.Forms.DataGridView();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMontoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMontoPagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMontoPendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVerPagos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colRegistrarPago = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlResumen = new System.Windows.Forms.Panel();
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
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 68;
            this.pnlHeader.Name = "pnlHeader";
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Cuentas por Pagar";
            //
            // lblHeaderSub
            //
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(178, 190, 195);
            this.lblHeaderSub.Location = new System.Drawing.Point(22, 42);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Text = "Gestión de obligaciones con proveedores";
            //
            // pnlFiltros
            //
            this.pnlFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Controls.Add(this.lblProveedor);
            this.pnlFiltros.Controls.Add(this.cmbProveedor);
            this.pnlFiltros.Controls.Add(this.lblEstado);
            this.pnlFiltros.Controls.Add(this.cmbEstado);
            this.pnlFiltros.Controls.Add(this.lblTipo);
            this.pnlFiltros.Controls.Add(this.cmbTipo);
            this.pnlFiltros.Controls.Add(this.btnFiltrar);
            this.pnlFiltros.Controls.Add(this.btnExportar);
            this.pnlFiltros.Location = new System.Drawing.Point(0, 68);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1200, 60);
            this.pnlFiltros.TabIndex = 1;
            //
            // lblProveedor
            //
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblProveedor.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblProveedor.Location = new System.Drawing.Point(15, 8);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Text = "Proveedor:";
            //
            // cmbProveedor
            //
            this.cmbProveedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(15, 28);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(260, 23);
            this.cmbProveedor.TabIndex = 0;
            //
            // lblEstado
            //
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblEstado.Location = new System.Drawing.Point(290, 8);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text = "Estado:";
            //
            // cmbEstado
            //
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] { "TODOS", "PENDIENTE", "PARCIAL", "PAGADO" });
            this.cmbEstado.Location = new System.Drawing.Point(290, 28);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(185, 23);
            this.cmbEstado.TabIndex = 1;
            //
            // lblTipo
            //
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblTipo.Location = new System.Drawing.Point(490, 8);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Text = "Tipo:";
            //
            // cmbTipo
            //
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] { "TODOS", "COMPRA", "GASTO" });
            this.cmbTipo.Location = new System.Drawing.Point(490, 28);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(140, 23);
            this.cmbTipo.TabIndex = 4;
            //
            // btnFiltrar
            //
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnFiltrar.FlatAppearance.BorderSize = 1;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.btnFiltrar.Location = new System.Drawing.Point(645, 27);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(100, 26);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);
            //
            // btnExportar
            //
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnExportar.FlatAppearance.BorderSize = 1;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.btnExportar.Location = new System.Drawing.Point(1085, 27);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(100, 26);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            //
            // dgvCuentas
            //
            this.dgvCuentas.AllowUserToAddRows = false;
            this.dgvCuentas.AllowUserToDeleteRows = false;
            this.dgvCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCuentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvCuentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCuentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            hdrStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            hdrStyle.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            hdrStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            hdrStyle.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            hdrStyle.SelectionBackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            hdrStyle.SelectionForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            hdrStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCuentas.ColumnHeadersDefaultCellStyle = hdrStyle;
            this.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNumero, this.colTipo, this.colCompra, this.colProveedor, this.colFechaCompra,
                this.colMontoTotal, this.colMontoPagado, this.colMontoPendiente,
                this.colVencimiento, this.colEstado, this.colVerPagos, this.colRegistrarPago, this.colEliminar });
            rowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(232, 245, 215);
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.dgvCuentas.DefaultCellStyle = rowStyle;
            this.dgvCuentas.EnableHeadersVisualStyles = false;
            this.dgvCuentas.Location = new System.Drawing.Point(0, 128);
            this.dgvCuentas.Name = "dgvCuentas";
            this.dgvCuentas.ReadOnly = true;
            this.dgvCuentas.RowHeadersVisible = false;
            this.dgvCuentas.RowTemplate.Height = 40;
            this.dgvCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuentas.Size = new System.Drawing.Size(1200, 490);
            this.dgvCuentas.TabIndex = 2;
            this.dgvCuentas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCuentas_CellContentClick);
            //
            // colNumero
            //
            this.colNumero.HeaderText = "#";
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            this.colNumero.Width = 50;
            //
            // colTipo
            //
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            this.colTipo.Width = 70;
            //
            // colCompra
            //
            this.colCompra.HeaderText = "Referencia";
            this.colCompra.Name = "colCompra";
            this.colCompra.ReadOnly = true;
            this.colCompra.Width = 120;
            //
            // colProveedor
            //
            this.colProveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProveedor.HeaderText = "Proveedor";
            this.colProveedor.Name = "colProveedor";
            this.colProveedor.ReadOnly = true;
            //
            // colFechaCompra
            //
            this.colFechaCompra.HeaderText = "Fecha Compra";
            this.colFechaCompra.Name = "colFechaCompra";
            this.colFechaCompra.ReadOnly = true;
            this.colFechaCompra.Width = 110;
            //
            // colMontoTotal
            //
            this.colMontoTotal.HeaderText = "Monto Total";
            this.colMontoTotal.Name = "colMontoTotal";
            this.colMontoTotal.ReadOnly = true;
            this.colMontoTotal.Width = 100;
            //
            // colMontoPagado
            //
            this.colMontoPagado.HeaderText = "Pagado";
            this.colMontoPagado.Name = "colMontoPagado";
            this.colMontoPagado.ReadOnly = true;
            this.colMontoPagado.Width = 100;
            //
            // colMontoPendiente
            //
            this.colMontoPendiente.HeaderText = "Pendiente";
            this.colMontoPendiente.Name = "colMontoPendiente";
            this.colMontoPendiente.ReadOnly = true;
            this.colMontoPendiente.Width = 100;
            //
            // colVencimiento
            //
            this.colVencimiento.HeaderText = "Vencimiento";
            this.colVencimiento.Name = "colVencimiento";
            this.colVencimiento.ReadOnly = true;
            this.colVencimiento.Width = 110;
            //
            // colEstado
            //
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 90;
            //
            // colVerPagos
            //
            this.colVerPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colVerPagos.HeaderText = "";
            this.colVerPagos.Name = "colVerPagos";
            this.colVerPagos.ReadOnly = false;
            this.colVerPagos.Text = "Ver Pagos";
            this.colVerPagos.UseColumnTextForButtonValue = true;
            this.colVerPagos.Width = 80;
            //
            // colRegistrarPago
            //
            this.colRegistrarPago.HeaderText = "";
            this.colRegistrarPago.Name = "colRegistrarPago";
            this.colRegistrarPago.ReadOnly = true;
            this.colRegistrarPago.Text = "Pagar";
            this.colRegistrarPago.UseColumnTextForButtonValue = true;
            this.colRegistrarPago.Width = 80;
            //
            // colEliminar
            //
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.HeaderText = "";
            this.colEliminar.Text = "Eliminar";
            this.colEliminar.UseColumnTextForButtonValue = true;
            this.colEliminar.Width = 75;
            this.colEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEliminar.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.colEliminar.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.colEliminar.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            //
            // pnlResumen
            //
            this.pnlResumen.BackColor = System.Drawing.Color.White;
            this.pnlResumen.Controls.Add(this.lblTotalRegistros);
            this.pnlResumen.Controls.Add(this.lblTotalPendiente);
            this.pnlResumen.Controls.Add(this.txtTotalPendiente);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumen.Height = 50;
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.TabIndex = 3;
            //
            // lblTotalRegistros
            //
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalRegistros.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblTotalRegistros.Location = new System.Drawing.Point(15, 17);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Text = "Total: 0 registros";
            //
            // lblTotalPendiente
            //
            this.lblTotalPendiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPendiente.AutoSize = true;
            this.lblTotalPendiente.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalPendiente.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblTotalPendiente.Location = new System.Drawing.Point(940, 14);
            this.lblTotalPendiente.Name = "lblTotalPendiente";
            this.lblTotalPendiente.Text = "Total Pendiente:";
            //
            // txtTotalPendiente
            //
            this.txtTotalPendiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalPendiente.BackColor = System.Drawing.Color.White;
            this.txtTotalPendiente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalPendiente.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalPendiente.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.txtTotalPendiente.Location = new System.Drawing.Point(1075, 14);
            this.txtTotalPendiente.Name = "txtTotalPendiente";
            this.txtTotalPendiente.ReadOnly = true;
            this.txtTotalPendiente.Size = new System.Drawing.Size(110, 22);
            this.txtTotalPendiente.TabIndex = 2;
            this.txtTotalPendiente.Text = "S/ 0.00";
            this.txtTotalPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // FormCuentasPorPagar
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.ClientSize = new System.Drawing.Size(1200, 670);
            this.Controls.Add(this.dgvCuentas);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCuentasPorPagar";
            this.Text = "Cuentas por Pagar";
            this.Load += new System.EventHandler(this.FormCuentasPorPagar_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridView dgvCuentas;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.Label lblTotalPendiente;
        private System.Windows.Forms.TextBox txtTotalPendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontoPagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontoPendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewButtonColumn colVerPagos;
        private System.Windows.Forms.DataGridViewButtonColumn colRegistrarPago;
        private System.Windows.Forms.DataGridViewButtonColumn colEliminar;
    }
}
