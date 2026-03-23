namespace SistemaPOS.Forms.Finanzas
{
    partial class FormContabilidad
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlTarjetas = new System.Windows.Forms.Panel();
            this.btnEstadoResultados = new System.Windows.Forms.Button();
            this.btnFlujoCaja = new System.Windows.Forms.Button();
            this.btnBalanceGeneral = new System.Windows.Forms.Button();
            this.btnAsientos = new System.Windows.Forms.Button();
            this.panelContenidoContabilidad = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.pnlTarjetas.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1466, 50);
            this.pnlHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(16, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(140, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Contabilidad";
            //
            // pnlTarjetas
            //
            this.pnlTarjetas.Controls.Add(this.btnEstadoResultados);
            this.pnlTarjetas.Controls.Add(this.btnFlujoCaja);
            this.pnlTarjetas.Controls.Add(this.btnBalanceGeneral);
            this.pnlTarjetas.Controls.Add(this.btnAsientos);
            this.pnlTarjetas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTarjetas.Location = new System.Drawing.Point(0, 50);
            this.pnlTarjetas.Name = "pnlTarjetas";
            this.pnlTarjetas.Size = new System.Drawing.Size(1466, 80);
            this.pnlTarjetas.TabIndex = 1;
            //
            // btnEstadoResultados
            //
            this.btnEstadoResultados.Location = new System.Drawing.Point(20, 12);
            this.btnEstadoResultados.Name = "btnEstadoResultados";
            this.btnEstadoResultados.Size = new System.Drawing.Size(200, 56);
            this.btnEstadoResultados.TabIndex = 0;
            this.btnEstadoResultados.Text = "Estado de\r\nResultados";
            this.btnEstadoResultados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEstadoResultados.UseVisualStyleBackColor = true;
            this.btnEstadoResultados.Click += new System.EventHandler(this.BtnEstadoResultados_Click);
            //
            // btnFlujoCaja
            //
            this.btnFlujoCaja.Location = new System.Drawing.Point(232, 12);
            this.btnFlujoCaja.Name = "btnFlujoCaja";
            this.btnFlujoCaja.Size = new System.Drawing.Size(200, 56);
            this.btnFlujoCaja.TabIndex = 1;
            this.btnFlujoCaja.Text = "Flujo de Caja";
            this.btnFlujoCaja.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFlujoCaja.UseVisualStyleBackColor = true;
            this.btnFlujoCaja.Click += new System.EventHandler(this.BtnFlujoCaja_Click);
            //
            // btnBalanceGeneral
            //
            this.btnBalanceGeneral.Location = new System.Drawing.Point(444, 12);
            this.btnBalanceGeneral.Name = "btnBalanceGeneral";
            this.btnBalanceGeneral.Size = new System.Drawing.Size(200, 56);
            this.btnBalanceGeneral.TabIndex = 2;
            this.btnBalanceGeneral.Text = "Balance General";
            this.btnBalanceGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBalanceGeneral.UseVisualStyleBackColor = true;
            this.btnBalanceGeneral.Click += new System.EventHandler(this.BtnBalanceGeneral_Click);
            //
            // btnAsientos
            //
            this.btnAsientos.Location = new System.Drawing.Point(656, 12);
            this.btnAsientos.Name = "btnAsientos";
            this.btnAsientos.Size = new System.Drawing.Size(200, 56);
            this.btnAsientos.TabIndex = 3;
            this.btnAsientos.Text = "Asientos";
            this.btnAsientos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAsientos.UseVisualStyleBackColor = true;
            this.btnAsientos.Click += new System.EventHandler(this.BtnAsientos_Click);
            //
            // panelContenidoContabilidad
            //
            this.panelContenidoContabilidad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContenidoContabilidad.Location = new System.Drawing.Point(12, 142);
            this.panelContenidoContabilidad.Name = "panelContenidoContabilidad";
            this.panelContenidoContabilidad.Size = new System.Drawing.Size(1442, 683);
            this.panelContenidoContabilidad.TabIndex = 2;
            //
            // FormContabilidad
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1466, 837);
            this.Controls.Add(this.panelContenidoContabilidad);
            this.Controls.Add(this.pnlTarjetas);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FormContabilidad";
            this.Text = "Contabilidad";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTarjetas.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlTarjetas;
        private System.Windows.Forms.Button btnEstadoResultados;
        private System.Windows.Forms.Button btnFlujoCaja;
        private System.Windows.Forms.Button btnBalanceGeneral;
        private System.Windows.Forms.Button btnAsientos;
        private System.Windows.Forms.Panel panelContenidoContabilidad;
    }
}
