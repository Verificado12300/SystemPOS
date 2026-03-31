namespace SistemaPOS.Forms.Ventas
{
    partial class FormPreviewTicket
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.pnlVistaTicket = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlScroll.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.BackColor = System.Drawing.SystemColors.Control;
            this.pnlScroll.Controls.Add(this.pnlVistaTicket);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.Location = new System.Drawing.Point(0, 0);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(360, 739);
            this.pnlScroll.TabIndex = 0;
            // 
            // pnlVistaTicket
            // 
            this.pnlVistaTicket.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlVistaTicket.Location = new System.Drawing.Point(25, 12);
            this.pnlVistaTicket.Name = "pnlVistaTicket";
            this.pnlVistaTicket.Size = new System.Drawing.Size(310, 721);
            this.pnlVistaTicket.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Controls.Add(this.btnImprimir);
            this.pnlBottom.Controls.Add(this.btnCerrar);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 739);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.pnlBottom.Size = new System.Drawing.Size(360, 52);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(10, 9);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(130, 34);
            this.btnImprimir.TabIndex = 0;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(240, 9);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(110, 34);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // FormPreviewTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 791);
            this.Controls.Add(this.pnlScroll);
            this.Controls.Add(this.pnlBottom);
            this.MinimumSize = new System.Drawing.Size(320, 500);
            this.Name = "FormPreviewTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vista Previa — Ticket";
            this.pnlScroll.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel  pnlScroll;
        private System.Windows.Forms.Panel  pnlVistaTicket;
        private System.Windows.Forms.Panel  pnlBottom;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCerrar;
    }
}
