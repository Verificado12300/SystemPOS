namespace SistemaPOS.Forms.Finanzas
{
    partial class FormConversion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader     = new System.Windows.Forms.Panel();
            this.lblTitulo     = new System.Windows.Forms.Label();
            this.lblHeaderSub  = new System.Windows.Forms.Label();
            this.pnlBody       = new System.Windows.Forms.Panel();
            this.lblOrigen     = new System.Windows.Forms.Label();
            this.cboOrigen     = new System.Windows.Forms.ComboBox();
            this.lblFlecha     = new System.Windows.Forms.Label();
            this.lblDestino    = new System.Windows.Forms.Label();
            this.cboDestino    = new System.Windows.Forms.ComboBox();
            this.lblMonto      = new System.Windows.Forms.Label();
            this.numMonto      = new System.Windows.Forms.NumericUpDown();
            this.lblObs        = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.pnlFooter     = new System.Windows.Forms.Panel();
            this.btnGuardar    = new System.Windows.Forms.Button();
            this.btnCancelar   = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).BeginInit();
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
            this.lblTitulo.Text = "Conversión de Método de Pago";

            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(178, 190, 195);
            this.lblHeaderSub.Location = new System.Drawing.Point(18, 36);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Text = "Registra una reclasificación de efectivo a otro método o viceversa";

            // pnlBody
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.lblOrigen);
            this.pnlBody.Controls.Add(this.cboOrigen);
            this.pnlBody.Controls.Add(this.lblFlecha);
            this.pnlBody.Controls.Add(this.lblDestino);
            this.pnlBody.Controls.Add(this.cboDestino);
            this.pnlBody.Controls.Add(this.lblMonto);
            this.pnlBody.Controls.Add(this.numMonto);
            this.pnlBody.Controls.Add(this.lblObs);
            this.pnlBody.Controls.Add(this.txtObservacion);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(20, 16, 20, 10);
            this.pnlBody.Name = "pnlBody";

            // Origen / Flecha / Destino (misma fila)
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrigen.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblOrigen.Location = new System.Drawing.Point(20, 22);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Text = "Método Origen:";

            this.cboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrigen.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboOrigen.Location = new System.Drawing.Point(20, 42);
            this.cboOrigen.Name = "cboOrigen";
            this.cboOrigen.Size = new System.Drawing.Size(150, 24);

            this.lblFlecha.AutoSize = true;
            this.lblFlecha.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblFlecha.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblFlecha.Location = new System.Drawing.Point(180, 40);
            this.lblFlecha.Name = "lblFlecha";
            this.lblFlecha.Text = "→";

            this.lblDestino.AutoSize = true;
            this.lblDestino.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDestino.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblDestino.Location = new System.Drawing.Point(210, 22);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Text = "Método Destino:";

            this.cboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDestino.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboDestino.Location = new System.Drawing.Point(210, 42);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Size = new System.Drawing.Size(150, 24);

            // Monto
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMonto.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblMonto.Location = new System.Drawing.Point(20, 86);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Text = "Monto (S/):";

            this.numMonto.DecimalPlaces = 2;
            this.numMonto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numMonto.Location = new System.Drawing.Point(20, 106);
            this.numMonto.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            this.numMonto.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numMonto.Name = "numMonto";
            this.numMonto.Size = new System.Drawing.Size(160, 26);
            this.numMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // Observación
            this.lblObs.AutoSize = true;
            this.lblObs.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblObs.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblObs.Location = new System.Drawing.Point(20, 148);
            this.lblObs.Name = "lblObs";
            this.lblObs.Text = "Observación (opcional):";

            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtObservacion.Location = new System.Drawing.Point(20, 168);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(340, 50);

            // pnlFooter
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnGuardar);
            this.pnlFooter.Controls.Add(this.btnCancelar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 55;
            this.pnlFooter.Name = "pnlFooter";

            this.btnGuardar.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(130, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 32);
            this.btnGuardar.Text = "Registrar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);

            this.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.btnCancelar.Location = new System.Drawing.Point(250, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 32);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;

            // FormConversion
            this.AcceptButton = this.btnGuardar;
            this.CancelButton = this.btnCancelar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 360);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConversion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Conversión de Método";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.ComboBox cboOrigen;
        private System.Windows.Forms.Label lblFlecha;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.ComboBox cboDestino;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.NumericUpDown numMonto;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
