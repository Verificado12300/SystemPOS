namespace SistemaPOS.Forms.Finanzas
{
    partial class FormConciliacionInventario
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
            this.pnlTop       = new System.Windows.Forms.Panel();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.dtpHasta     = new System.Windows.Forms.DateTimePicker();
            this.btnConciliar = new System.Windows.Forms.Button();
            this.pnlResumen   = new System.Windows.Forms.Panel();
            this.lblTit140    = new System.Windows.Forms.Label();
            this.lblSaldo140  = new System.Windows.Forms.Label();
            this.lblTitKardex = new System.Windows.Forms.Label();
            this.lblValorKardex = new System.Windows.Forms.Label();
            this.lblTitDif    = new System.Windows.Forms.Label();
            this.lblDiferencia = new System.Windows.Forms.Label();
            this.dgvDetalle   = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            //
            // pnlTop
            //
            this.pnlTop.Controls.Add(this.lblFechaHasta);
            this.pnlTop.Controls.Add(this.dtpHasta);
            this.pnlTop.Controls.Add(this.btnConciliar);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 40;
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(8, 8, 8, 4);
            //
            // lblFechaHasta
            //
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Location = new System.Drawing.Point(8, 12);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Text = "Hasta:";
            //
            // dtpHasta
            //
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(55, 8);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(110, 20);
            //
            // btnConciliar
            //
            this.btnConciliar.Location = new System.Drawing.Point(175, 6);
            this.btnConciliar.Name = "btnConciliar";
            this.btnConciliar.Size = new System.Drawing.Size(90, 26);
            this.btnConciliar.Text = "Conciliar";
            this.btnConciliar.Click += new System.EventHandler(this.BtnConciliar_Click);
            //
            // pnlResumen
            //
            this.pnlResumen.Controls.Add(this.lblTit140);
            this.pnlResumen.Controls.Add(this.lblSaldo140);
            this.pnlResumen.Controls.Add(this.lblTitKardex);
            this.pnlResumen.Controls.Add(this.lblValorKardex);
            this.pnlResumen.Controls.Add(this.lblTitDif);
            this.pnlResumen.Controls.Add(this.lblDiferencia);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResumen.Height = 70;
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.pnlResumen.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            //
            // lblTit140
            //
            this.lblTit140.AutoSize = true;
            this.lblTit140.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTit140.Location = new System.Drawing.Point(10, 10);
            this.lblTit140.Text = "Saldo Contable (Cta. 140):";
            //
            // lblSaldo140
            //
            this.lblSaldo140.AutoSize = true;
            this.lblSaldo140.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblSaldo140.Location = new System.Drawing.Point(10, 30);
            this.lblSaldo140.Name = "lblSaldo140";
            this.lblSaldo140.Text = "S/ 0.00";
            //
            // lblTitKardex
            //
            this.lblTitKardex.AutoSize = true;
            this.lblTitKardex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitKardex.Location = new System.Drawing.Point(220, 10);
            this.lblTitKardex.Text = "Valor Kardex:";
            //
            // lblValorKardex
            //
            this.lblValorKardex.AutoSize = true;
            this.lblValorKardex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblValorKardex.Location = new System.Drawing.Point(220, 30);
            this.lblValorKardex.Name = "lblValorKardex";
            this.lblValorKardex.Text = "S/ 0.00";
            //
            // lblTitDif
            //
            this.lblTitDif.AutoSize = true;
            this.lblTitDif.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitDif.Location = new System.Drawing.Point(400, 10);
            this.lblTitDif.Text = "Diferencia:";
            //
            // lblDiferencia
            //
            this.lblDiferencia.AutoSize = true;
            this.lblDiferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblDiferencia.Location = new System.Drawing.Point(400, 28);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Text = "S/ 0.00";
            //
            // dgvDetalle
            //
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.TabIndex = 0;
            //
            // FormConciliacionInventario
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 580);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "FormConciliacionInventario";
            this.Text = "Conciliación Inventario — Cuenta 140 vs Kardex";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel     pnlTop;
        private System.Windows.Forms.Label     lblFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button    btnConciliar;
        private System.Windows.Forms.Panel     pnlResumen;
        private System.Windows.Forms.Label     lblTit140;
        private System.Windows.Forms.Label     lblSaldo140;
        private System.Windows.Forms.Label     lblTitKardex;
        private System.Windows.Forms.Label     lblValorKardex;
        private System.Windows.Forms.Label     lblTitDif;
        private System.Windows.Forms.Label     lblDiferencia;
        private System.Windows.Forms.DataGridView dgvDetalle;
    }
}
