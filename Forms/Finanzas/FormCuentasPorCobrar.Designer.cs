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
            System.Windows.Forms.DataGridViewCellStyle centerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle rightStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.chkSoloVencidas = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEstadoCuenta = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.colVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.lblResumen = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
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
            this.lblTitulo.Text = "Cuentas por Cobrar";
            //
            // lblHeaderSub
            //
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(178, 190, 195);
            this.lblHeaderSub.Location = new System.Drawing.Point(22, 42);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Text = "Seguimiento de créditos a clientes";
            //
            // pnlFiltros
            //
            this.pnlFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Controls.Add(this.cmbCliente);
            this.pnlFiltros.Controls.Add(this.cmbEstado);
            this.pnlFiltros.Controls.Add(this.txtBuscar);
            this.pnlFiltros.Controls.Add(this.chkSoloVencidas);
            this.pnlFiltros.Controls.Add(this.btnBuscar);
            this.pnlFiltros.Controls.Add(this.btnEstadoCuenta);
            this.pnlFiltros.Controls.Add(this.btnExportar);
            this.pnlFiltros.Location = new System.Drawing.Point(0, 68);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1075, 60);
            this.pnlFiltros.TabIndex = 1;
            //
            // cmbCliente
            //
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(10, 20);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(235, 25);
            this.cmbCliente.TabIndex = 0;
            //
            // cmbEstado
            //
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(255, 20);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(115, 25);
            this.cmbEstado.TabIndex = 1;
            //
            // txtBuscar
            //
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(380, 20);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(145, 24);
            this.txtBuscar.TabIndex = 2;
            //
            // chkSoloVencidas
            //
            this.chkSoloVencidas.AutoSize = true;
            this.chkSoloVencidas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkSoloVencidas.Location = new System.Drawing.Point(535, 23);
            this.chkSoloVencidas.Name = "chkSoloVencidas";
            this.chkSoloVencidas.Size = new System.Drawing.Size(98, 19);
            this.chkSoloVencidas.TabIndex = 3;
            this.chkSoloVencidas.Text = "Solo vencidas";
            //
            // btnBuscar
            //
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(9, 132, 227);
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(643, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 26);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            //
            // btnEstadoCuenta
            //
            this.btnEstadoCuenta.BackColor = System.Drawing.Color.FromArgb(108, 92, 231);
            this.btnEstadoCuenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstadoCuenta.FlatAppearance.BorderSize = 0;
            this.btnEstadoCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadoCuenta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEstadoCuenta.ForeColor = System.Drawing.Color.White;
            this.btnEstadoCuenta.Location = new System.Drawing.Point(733, 19);
            this.btnEstadoCuenta.Name = "btnEstadoCuenta";
            this.btnEstadoCuenta.Size = new System.Drawing.Size(130, 26);
            this.btnEstadoCuenta.TabIndex = 5;
            this.btnEstadoCuenta.Text = "Estado de Cuenta";
            this.btnEstadoCuenta.UseVisualStyleBackColor = false;
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
            this.btnExportar.Location = new System.Drawing.Point(873, 19);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(88, 26);
            this.btnExportar.TabIndex = 6;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            //
            // dgv
            //
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            hdrStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            hdrStyle.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            hdrStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            hdrStyle.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            hdrStyle.SelectionBackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            hdrStyle.SelectionForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.dgv.ColumnHeadersDefaultCellStyle = hdrStyle;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colVenta, this.colCliente, this.colFecha, this.colVence,
                this.colDias, this.colTotal, this.colPagado, this.colSaldo, this.colEstado });
            rowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(232, 245, 215);
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.dgv.DefaultCellStyle = rowStyle;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Location = new System.Drawing.Point(0, 128);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 32;
            this.dgv.Size = new System.Drawing.Size(1075, 394);
            this.dgv.TabIndex = 2;
            //
            // colVenta
            //
            this.colVenta.HeaderText = "Nro. Venta";
            this.colVenta.Name = "colVenta";
            this.colVenta.Width = 120;
            //
            // colCliente
            //
            this.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.MinimumWidth = 180;
            this.colCliente.Name = "colCliente";
            //
            // colFecha
            //
            this.colFecha.HeaderText = "Fecha Venta";
            this.colFecha.Name = "colFecha";
            this.colFecha.Width = 110;
            //
            // colVence
            //
            this.colVence.HeaderText = "Vencimiento";
            this.colVence.Name = "colVence";
            this.colVence.Width = 110;
            //
            // colDias
            //
            centerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDias.DefaultCellStyle = centerStyle;
            this.colDias.HeaderText = "Días venc.";
            this.colDias.Name = "colDias";
            this.colDias.Width = 90;
            //
            // colTotal
            //
            rightStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTotal.DefaultCellStyle = rightStyle;
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.Width = 110;
            //
            // colPagado
            //
            System.Windows.Forms.DataGridViewCellStyle rightStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            rightStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPagado.DefaultCellStyle = rightStyle2;
            this.colPagado.HeaderText = "Pagado";
            this.colPagado.Name = "colPagado";
            this.colPagado.Width = 110;
            //
            // colSaldo
            //
            System.Windows.Forms.DataGridViewCellStyle rightStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            rightStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colSaldo.DefaultCellStyle = rightStyle3;
            this.colSaldo.HeaderText = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.Width = 110;
            //
            // colEstado
            //
            System.Windows.Forms.DataGridViewCellStyle centerStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            centerStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEstado.DefaultCellStyle = centerStyle2;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.Width = 90;
            //
            // pnlResumen
            //
            this.pnlResumen.BackColor = System.Drawing.Color.White;
            this.pnlResumen.Controls.Add(this.lblResumen);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumen.Height = 42;
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.TabIndex = 3;
            //
            // lblResumen
            //
            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblResumen.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblResumen.Location = new System.Drawing.Point(10, 13);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Text = "Resumen";
            //
            // FormCuentasPorCobrar
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.ClientSize = new System.Drawing.Size(1075, 572);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FormCuentasPorCobrar";
            this.Text = "Cuentas por Cobrar";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.CheckBox chkSoloVencidas;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnEstadoCuenta;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVence;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblResumen;
    }
}
