namespace SistemaPOS.Forms.Finanzas
{
    partial class FormHistorialPagosCxP
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
            System.Windows.Forms.DataGridViewCellStyle rowStyle  = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader     = new System.Windows.Forms.Panel();
            this.lblTitulo     = new System.Windows.Forms.Label();
            this.lblSub        = new System.Windows.Forms.Label();
            this.pnlInfo       = new System.Windows.Forms.Panel();
            this.lblLblRef     = new System.Windows.Forms.Label();
            this.lblInfoRef    = new System.Windows.Forms.Label();
            this.lblLblProv    = new System.Windows.Forms.Label();
            this.lblInfoProv   = new System.Windows.Forms.Label();
            this.lblLblTotal   = new System.Windows.Forms.Label();
            this.lblInfoTotal  = new System.Windows.Forms.Label();
            this.lblLblEstado  = new System.Windows.Forms.Label();
            this.lblInfoEstado = new System.Windows.Forms.Label();
            this.dgvPagos      = new System.Windows.Forms.DataGridView();
            this.colNro        = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha      = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonto      = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMetodo     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAsiento    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstadoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnular     = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlFooter     = new System.Windows.Forms.Panel();
            this.btnCerrar     = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblSub);
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
            this.lblTitulo.Text = "Historial de Pagos";
            //
            // lblSub
            //
            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(178, 190, 195);
            this.lblSub.Location = new System.Drawing.Point(22, 42);
            this.lblSub.Name = "lblSub";
            this.lblSub.Text = "Cargando...";
            //
            // pnlInfo
            //
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Controls.Add(this.lblLblRef);
            this.pnlInfo.Controls.Add(this.lblInfoRef);
            this.pnlInfo.Controls.Add(this.lblLblProv);
            this.pnlInfo.Controls.Add(this.lblInfoProv);
            this.pnlInfo.Controls.Add(this.lblLblTotal);
            this.pnlInfo.Controls.Add(this.lblInfoTotal);
            this.pnlInfo.Controls.Add(this.lblLblEstado);
            this.pnlInfo.Controls.Add(this.lblInfoEstado);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Height = 52;
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            //
            // lblLblRef
            //
            this.lblLblRef.AutoSize = true;
            this.lblLblRef.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLblRef.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblLblRef.Location = new System.Drawing.Point(14, 8);
            this.lblLblRef.Name = "lblLblRef";
            this.lblLblRef.Text = "REFERENCIA";
            //
            // lblInfoRef
            //
            this.lblInfoRef.AutoSize = true;
            this.lblInfoRef.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInfoRef.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblInfoRef.Location = new System.Drawing.Point(14, 26);
            this.lblInfoRef.Name = "lblInfoRef";
            this.lblInfoRef.Text = "—";
            //
            // lblLblProv
            //
            this.lblLblProv.AutoSize = true;
            this.lblLblProv.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLblProv.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblLblProv.Location = new System.Drawing.Point(220, 8);
            this.lblLblProv.Name = "lblLblProv";
            this.lblLblProv.Text = "PROVEEDOR";
            //
            // lblInfoProv
            //
            this.lblInfoProv.AutoSize = true;
            this.lblInfoProv.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfoProv.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblInfoProv.Location = new System.Drawing.Point(220, 26);
            this.lblInfoProv.Name = "lblInfoProv";
            this.lblInfoProv.Text = "—";
            //
            // lblLblTotal
            //
            this.lblLblTotal.AutoSize = true;
            this.lblLblTotal.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLblTotal.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblLblTotal.Location = new System.Drawing.Point(490, 8);
            this.lblLblTotal.Name = "lblLblTotal";
            this.lblLblTotal.Text = "MONTO TOTAL";
            //
            // lblInfoTotal
            //
            this.lblInfoTotal.AutoSize = true;
            this.lblInfoTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInfoTotal.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblInfoTotal.Location = new System.Drawing.Point(490, 26);
            this.lblInfoTotal.Name = "lblInfoTotal";
            this.lblInfoTotal.Text = "S/ 0.00";
            //
            // lblLblEstado
            //
            this.lblLblEstado.AutoSize = true;
            this.lblLblEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLblEstado.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblLblEstado.Location = new System.Drawing.Point(640, 8);
            this.lblLblEstado.Name = "lblLblEstado";
            this.lblLblEstado.Text = "ESTADO CXP";
            //
            // lblInfoEstado
            //
            this.lblInfoEstado.AutoSize = true;
            this.lblInfoEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInfoEstado.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblInfoEstado.Location = new System.Drawing.Point(640, 26);
            this.lblInfoEstado.Name = "lblInfoEstado";
            this.lblInfoEstado.Text = "—";
            //
            // dgvPagos
            //
            hdrStyle.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            hdrStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            hdrStyle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvPagos.AllowUserToAddRows    = false;
            this.dgvPagos.AllowUserToDeleteRows = false;
            this.dgvPagos.AutoGenerateColumns   = false;
            this.dgvPagos.BackgroundColor       = System.Drawing.Color.FromArgb(245, 246, 250);
            this.dgvPagos.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvPagos.ColumnHeadersDefaultCellStyle = hdrStyle;
            this.dgvPagos.ColumnHeadersHeight   = 36;
            this.dgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPagos.DefaultCellStyle      = rowStyle;
            this.dgvPagos.Dock                  = System.Windows.Forms.DockStyle.Fill;
            this.dgvPagos.EnableHeadersVisualStyles = false;
            this.dgvPagos.GridColor             = System.Drawing.Color.FromArgb(220, 221, 225);
            this.dgvPagos.Name                  = "dgvPagos";
            this.dgvPagos.ReadOnly              = true;
            this.dgvPagos.RowHeadersVisible     = false;
            this.dgvPagos.RowTemplate.Height    = 36;
            this.dgvPagos.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNro, this.colFecha, this.colMonto, this.colMetodo,
                this.colComprobante, this.colAsiento, this.colEstadoPago, this.colAnular });
            this.dgvPagos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPagos_CellContentClick);
            //
            // colNro
            //
            this.colNro.HeaderText = "#";
            this.colNro.Name = "colNro";
            this.colNro.ReadOnly = true;
            this.colNro.Width = 40;
            //
            // colFecha
            //
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 90;
            //
            // colMonto
            //
            this.colMonto.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colMonto.HeaderText = "Monto";
            this.colMonto.Name = "colMonto";
            this.colMonto.ReadOnly = true;
            this.colMonto.Width = 95;
            //
            // colMetodo
            //
            this.colMetodo.HeaderText = "Método";
            this.colMetodo.Name = "colMetodo";
            this.colMetodo.ReadOnly = true;
            this.colMetodo.Width = 110;
            //
            // colComprobante
            //
            this.colComprobante.HeaderText = "Comprobante";
            this.colComprobante.Name = "colComprobante";
            this.colComprobante.ReadOnly = true;
            this.colComprobante.Width = 110;
            //
            // colAsiento
            //
            this.colAsiento.HeaderText = "Asiento ID";
            this.colAsiento.Name = "colAsiento";
            this.colAsiento.ReadOnly = true;
            this.colAsiento.Width = 80;
            //
            // colEstadoPago
            //
            this.colEstadoPago.HeaderText = "Estado";
            this.colEstadoPago.Name = "colEstadoPago";
            this.colEstadoPago.ReadOnly = true;
            this.colEstadoPago.Width = 80;
            //
            // colAnular
            //
            this.colAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colAnular.HeaderText = "";
            this.colAnular.Name = "colAnular";
            this.colAnular.ReadOnly = false;
            this.colAnular.Text = "Anular";
            this.colAnular.UseColumnTextForButtonValue = true;
            this.colAnular.Width = 80;
            //
            // pnlFooter
            //
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnCerrar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 48;
            this.pnlFooter.Name = "pnlFooter";
            //
            // btnCerrar
            //
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(340, 8);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(130, 32);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            //
            // FormHistorialPagosCxP
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.ClientSize = new System.Drawing.Size(820, 560);
            this.Controls.Add(this.dgvPagos);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHistorialPagosCxP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Historial de Pagos";
            this.Load += new System.EventHandler(this.FormHistorialPagosCxP_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblLblRef;
        private System.Windows.Forms.Label lblInfoRef;
        private System.Windows.Forms.Label lblLblProv;
        private System.Windows.Forms.Label lblInfoProv;
        private System.Windows.Forms.Label lblLblTotal;
        private System.Windows.Forms.Label lblInfoTotal;
        private System.Windows.Forms.Label lblLblEstado;
        private System.Windows.Forms.Label lblInfoEstado;
        private System.Windows.Forms.DataGridView dgvPagos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMetodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAsiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoPago;
        private System.Windows.Forms.DataGridViewButtonColumn colAnular;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCerrar;
    }
}
