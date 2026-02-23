namespace SistemaPOS.Forms.Shared
{
    partial class FormStockInsuficiente
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlAccent       = new System.Windows.Forms.Panel();
            this.lblIcono        = new System.Windows.Forms.Label();
            this.lblTitulo       = new System.Windows.Forms.Label();
            this.lblSubtitulo    = new System.Windows.Forms.Label();
            this.pnlSep1         = new System.Windows.Forms.Panel();
            this.lblProdLabel    = new System.Windows.Forms.Label();
            this.lblProdValor    = new System.Windows.Forms.Label();
            this.lblStockLabel   = new System.Windows.Forms.Label();
            this.lblStockValor   = new System.Windows.Forms.Label();
            this.lblSolLabel     = new System.Windows.Forms.Label();
            this.lblSolValor     = new System.Windows.Forms.Label();
            this.pnlSep2         = new System.Windows.Forms.Panel();
            this.lblConsejo      = new System.Windows.Forms.Label();
            this.btnAceptar      = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // pnlAccent
            //
            this.pnlAccent.BackColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.pnlAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAccent.Location = new System.Drawing.Point(0, 0);
            this.pnlAccent.Name = "pnlAccent";
            this.pnlAccent.Size = new System.Drawing.Size(450, 5);
            this.pnlAccent.TabIndex = 0;
            //
            // lblIcono
            //
            this.lblIcono.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIcono.ForeColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.lblIcono.Location = new System.Drawing.Point(16, 16);
            this.lblIcono.Name = "lblIcono";
            this.lblIcono.Size = new System.Drawing.Size(56, 52);
            this.lblIcono.TabIndex = 1;
            this.lblIcono.Text = "⚠";
            this.lblIcono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTitulo
            //
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblTitulo.Location = new System.Drawing.Point(82, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(350, 30);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Stock insuficiente";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblSubtitulo.Location = new System.Drawing.Point(82, 50);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(350, 18);
            this.lblSubtitulo.TabIndex = 3;
            this.lblSubtitulo.Text = "No hay suficiente stock para completar esta operación.";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlSep1
            //
            this.pnlSep1.BackColor = System.Drawing.Color.FromArgb(250, 215, 160);
            this.pnlSep1.Location = new System.Drawing.Point(18, 78);
            this.pnlSep1.Name = "pnlSep1";
            this.pnlSep1.Size = new System.Drawing.Size(414, 1);
            this.pnlSep1.TabIndex = 4;
            //
            // lblProdLabel
            //
            this.lblProdLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdLabel.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblProdLabel.Location = new System.Drawing.Point(28, 92);
            this.lblProdLabel.Name = "lblProdLabel";
            this.lblProdLabel.Size = new System.Drawing.Size(155, 20);
            this.lblProdLabel.TabIndex = 5;
            this.lblProdLabel.Text = "Producto:";
            //
            // lblProdValor
            //
            this.lblProdValor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdValor.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblProdValor.Location = new System.Drawing.Point(190, 92);
            this.lblProdValor.Name = "lblProdValor";
            this.lblProdValor.Size = new System.Drawing.Size(242, 20);
            this.lblProdValor.TabIndex = 6;
            this.lblProdValor.Text = "";
            //
            // lblStockLabel
            //
            this.lblStockLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockLabel.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblStockLabel.Location = new System.Drawing.Point(28, 118);
            this.lblStockLabel.Name = "lblStockLabel";
            this.lblStockLabel.Size = new System.Drawing.Size(155, 20);
            this.lblStockLabel.TabIndex = 7;
            this.lblStockLabel.Text = "Stock disponible:";
            //
            // lblStockValor
            //
            this.lblStockValor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockValor.ForeColor = System.Drawing.Color.FromArgb(211, 84, 0);
            this.lblStockValor.Location = new System.Drawing.Point(190, 118);
            this.lblStockValor.Name = "lblStockValor";
            this.lblStockValor.Size = new System.Drawing.Size(242, 20);
            this.lblStockValor.TabIndex = 8;
            this.lblStockValor.Text = "";
            //
            // lblSolLabel
            //
            this.lblSolLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolLabel.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblSolLabel.Location = new System.Drawing.Point(28, 144);
            this.lblSolLabel.Name = "lblSolLabel";
            this.lblSolLabel.Size = new System.Drawing.Size(155, 20);
            this.lblSolLabel.TabIndex = 9;
            this.lblSolLabel.Text = "Cantidad solicitada:";
            //
            // lblSolValor
            //
            this.lblSolValor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolValor.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblSolValor.Location = new System.Drawing.Point(190, 144);
            this.lblSolValor.Name = "lblSolValor";
            this.lblSolValor.Size = new System.Drawing.Size(242, 20);
            this.lblSolValor.TabIndex = 10;
            this.lblSolValor.Text = "";
            //
            // pnlSep2
            //
            this.pnlSep2.BackColor = System.Drawing.Color.FromArgb(250, 215, 160);
            this.pnlSep2.Location = new System.Drawing.Point(18, 172);
            this.pnlSep2.Name = "pnlSep2";
            this.pnlSep2.Size = new System.Drawing.Size(414, 1);
            this.pnlSep2.TabIndex = 11;
            //
            // lblConsejo
            //
            this.lblConsejo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsejo.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblConsejo.Location = new System.Drawing.Point(18, 182);
            this.lblConsejo.Name = "lblConsejo";
            this.lblConsejo.Size = new System.Drawing.Size(414, 18);
            this.lblConsejo.TabIndex = 12;
            this.lblConsejo.Text = "Ajusta la cantidad o registra una compra.";
            this.lblConsejo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnAceptar
            //
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(243, 156, 18);
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(211, 135, 6);
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(165, 214);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(120, 36);
            this.btnAceptar.TabIndex = 13;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            //
            // FormStockInsuficiente
            //
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 253, 235);
            this.ClientSize = new System.Drawing.Size(450, 264);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblConsejo);
            this.Controls.Add(this.pnlSep2);
            this.Controls.Add(this.lblSolValor);
            this.Controls.Add(this.lblSolLabel);
            this.Controls.Add(this.lblStockValor);
            this.Controls.Add(this.lblStockLabel);
            this.Controls.Add(this.lblProdValor);
            this.Controls.Add(this.lblProdLabel);
            this.Controls.Add(this.pnlSep1);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblIcono);
            this.Controls.Add(this.pnlAccent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStockInsuficiente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stock insuficiente";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel  pnlAccent;
        private System.Windows.Forms.Label  lblIcono;
        private System.Windows.Forms.Label  lblTitulo;
        private System.Windows.Forms.Label  lblSubtitulo;
        private System.Windows.Forms.Panel  pnlSep1;
        private System.Windows.Forms.Label  lblProdLabel;
        private System.Windows.Forms.Label  lblProdValor;
        private System.Windows.Forms.Label  lblStockLabel;
        private System.Windows.Forms.Label  lblStockValor;
        private System.Windows.Forms.Label  lblSolLabel;
        private System.Windows.Forms.Label  lblSolValor;
        private System.Windows.Forms.Panel  pnlSep2;
        private System.Windows.Forms.Label  lblConsejo;
        private System.Windows.Forms.Button btnAceptar;
    }
}
