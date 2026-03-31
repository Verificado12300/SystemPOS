namespace SistemaPOS.Controls
{
    partial class TicketPreviewControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pbLogo     = new System.Windows.Forms.PictureBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.rtbTicket  = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            //
            // pbLogo — ocupa todo el ancho; altura fija; visible solo si hay imagen
            //
            this.pbLogo.Location = new System.Drawing.Point(0, 3);
            this.pbLogo.Name     = "pbLogo";
            this.pbLogo.Size     = new System.Drawing.Size(298, 60);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop  = false;
            this.pbLogo.Visible  = false;
            //
            // lblEmpresa — nombre de empresa centrado, Consolas 13F Bold
            //
            this.lblEmpresa.BackColor  = System.Drawing.Color.White;
            this.lblEmpresa.Font       = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblEmpresa.ForeColor  = System.Drawing.Color.Black;
            this.lblEmpresa.Location   = new System.Drawing.Point(0, 3);
            this.lblEmpresa.Name       = "lblEmpresa";
            this.lblEmpresa.Size       = new System.Drawing.Size(298, 26);
            this.lblEmpresa.TabIndex   = 2;
            this.lblEmpresa.Text       = "";
            this.lblEmpresa.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmpresa.Visible    = false;
            //
            // rtbTicket — RUC, dirección, artículos, totales...  (2px izq)
            //
            this.rtbTicket.BackColor   = System.Drawing.Color.White;
            this.rtbTicket.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbTicket.Font        = new System.Drawing.Font("Consolas", 8.25F);
            this.rtbTicket.ForeColor   = System.Drawing.Color.Black;
            this.rtbTicket.Location    = new System.Drawing.Point(2, 3);
            this.rtbTicket.Name        = "rtbTicket";
            this.rtbTicket.HideSelection = true;
            this.rtbTicket.ReadOnly    = true;
            this.rtbTicket.ScrollBars  = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbTicket.Size        = new System.Drawing.Size(294, 600);
            this.rtbTicket.TabIndex    = 1;
            this.rtbTicket.TabStop     = false;
            this.rtbTicket.WordWrap    = false;
            //
            // TicketPreviewControl
            //
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.rtbTicket);
            this.Name = "TicketPreviewControl";
            this.Size = new System.Drawing.Size(298, 620);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox  pbLogo;
        private System.Windows.Forms.Label       lblEmpresa;
        private System.Windows.Forms.RichTextBox rtbTicket;
    }
}
