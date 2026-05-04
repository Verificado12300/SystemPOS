namespace SistemaPOS.Forms.Finanzas
{
    partial class FormMoneteo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader          = new System.Windows.Forms.Panel();
            this.lblTitulo          = new System.Windows.Forms.Label();
            this.lblHeaderSub       = new System.Windows.Forms.Label();
            this.pnlBody            = new System.Windows.Forms.Panel();
            this.pnlGrid            = new System.Windows.Forms.Panel();
            this.pnlTotalBar        = new System.Windows.Forms.Panel();
            this.lblTotalLabel      = new System.Windows.Forms.Label();
            this.lblTotal           = new System.Windows.Forms.Label();
            this.pnlFooter          = new System.Windows.Forms.Panel();
            this.btnUsarEfectivoReal = new System.Windows.Forms.Button();
            this.btnGuardar         = new System.Windows.Forms.Button();
            this.btnExportar        = new System.Windows.Forms.Button();
            this.btnCancelar        = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlTotalBar.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 60;
            this.pnlHeader.Name = "pnlHeader";

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(16, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Moneteo de Caja";

            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(178, 190, 195);
            this.lblHeaderSub.Location = new System.Drawing.Point(18, 36);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Text = "Conteo de billetes y monedas en caja";

            // pnlBody
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.pnlBody.Controls.Add(this.pnlTotalBar);
            this.pnlBody.Controls.Add(this.pnlGrid);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(10);

            // pnlGrid  (scrollable card)
            this.pnlGrid.AutoScroll = true;
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Location = new System.Drawing.Point(10, 10);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(440, 390);
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);

            // pnlTotalBar
            this.pnlTotalBar.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.pnlTotalBar.Controls.Add(this.lblTotalLabel);
            this.pnlTotalBar.Controls.Add(this.lblTotal);
            this.pnlTotalBar.Location = new System.Drawing.Point(10, 408);
            this.pnlTotalBar.Name = "pnlTotalBar";
            this.pnlTotalBar.Size = new System.Drawing.Size(440, 44);

            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.ForeColor = System.Drawing.Color.White;
            this.lblTotalLabel.Location = new System.Drawing.Point(16, 12);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Text = "TOTAL EN CAJA:";

            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblTotal.Location = new System.Drawing.Point(240, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Text = "S/ 0.00";

            // pnlFooter
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnUsarEfectivoReal);
            this.pnlFooter.Controls.Add(this.btnGuardar);
            this.pnlFooter.Controls.Add(this.btnExportar);
            this.pnlFooter.Controls.Add(this.btnCancelar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 55;
            this.pnlFooter.Name = "pnlFooter";

            this.btnUsarEfectivoReal.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnUsarEfectivoReal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsarEfectivoReal.FlatAppearance.BorderSize = 0;
            this.btnUsarEfectivoReal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsarEfectivoReal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnUsarEfectivoReal.ForeColor = System.Drawing.Color.White;
            this.btnUsarEfectivoReal.Location = new System.Drawing.Point(10, 12);
            this.btnUsarEfectivoReal.Name = "btnUsarEfectivoReal";
            this.btnUsarEfectivoReal.Size = new System.Drawing.Size(150, 32);
            this.btnUsarEfectivoReal.Text = "Usar como Efectivo Real";
            this.btnUsarEfectivoReal.UseVisualStyleBackColor = false;
            this.btnUsarEfectivoReal.Click += new System.EventHandler(this.BtnUsarEfectivoReal_Click);

            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(9, 132, 227);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(168, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(82, 32);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);

            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(258, 12);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(82, 32);
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.BtnExportar_Click);

            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.btnCancelar.Location = new System.Drawing.Point(348, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(82, 32);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;

            // FormMoneteo
            this.CancelButton = this.btnCancelar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.ClientSize = new System.Drawing.Size(460, 520);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMoneteo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Moneteo de Caja";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlTotalBar.ResumeLayout(false);
            this.pnlTotalBar.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlTotalBar;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnUsarEfectivoReal;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
