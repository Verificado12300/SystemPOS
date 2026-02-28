namespace SistemaPOS.Forms.Contactos
{
    partial class FormRegistrarPago
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
            this.lblSaldoActual = new System.Windows.Forms.Label();
            this.txtSaldoActual = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlCardObs = new System.Windows.Forms.Panel();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.pnlCardMixto = new System.Windows.Forms.Panel();
            this.lblCardMixtoTitulo = new System.Windows.Forms.Label();
            this.lblEfLabel = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.lblYpLabel = new System.Windows.Forms.Label();
            this.txtYape = new System.Windows.Forms.TextBox();
            this.lblTrLabel = new System.Windows.Forms.Label();
            this.txtTransferencia = new System.Windows.Forms.TextBox();
            this.pnlCardMetodo = new System.Windows.Forms.Panel();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.rbEfectivo = new System.Windows.Forms.RadioButton();
            this.rbYape = new System.Windows.Forms.RadioButton();
            this.rbTransferencia = new System.Windows.Forms.RadioButton();
            this.rbMixto = new System.Windows.Forms.RadioButton();
            this.pnlCardDatos = new System.Windows.Forms.Panel();
            this.lblCardDatosTitulo = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblMontoPagar = new System.Windows.Forms.Label();
            this.txtMontoPagar = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlCardObs.SuspendLayout();
            this.pnlCardMixto.SuspendLayout();
            this.pnlCardMetodo.SuspendLayout();
            this.pnlCardDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlHeader.Controls.Add(this.lblSaldoActual);
            this.pnlHeader.Controls.Add(this.txtSaldoActual);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(403, 59);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSaldoActual
            // 
            this.lblSaldoActual.AutoSize = true;
            this.lblSaldoActual.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSaldoActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(190)))), ((int)(((byte)(195)))));
            this.lblSaldoActual.Location = new System.Drawing.Point(14, 38);
            this.lblSaldoActual.Name = "lblSaldoActual";
            this.lblSaldoActual.Size = new System.Drawing.Size(95, 15);
            this.lblSaldoActual.TabIndex = 1;
            this.lblSaldoActual.Text = "Saldo pendiente:";
            // 
            // txtSaldoActual
            // 
            this.txtSaldoActual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.txtSaldoActual.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSaldoActual.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtSaldoActual.ForeColor = System.Drawing.Color.White;
            this.txtSaldoActual.Location = new System.Drawing.Point(113, 36);
            this.txtSaldoActual.Name = "txtSaldoActual";
            this.txtSaldoActual.ReadOnly = true;
            this.txtSaldoActual.Size = new System.Drawing.Size(154, 18);
            this.txtSaldoActual.TabIndex = 2;
            this.txtSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(14, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(117, 21);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registrar Pago";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.btnRegistrarPago);
            this.pnlFooter.Controls.Add(this.btnCancelar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 454);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(403, 49);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnRegistrarPago
            // 
            this.btnRegistrarPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.btnRegistrarPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarPago.FlatAppearance.BorderSize = 0;
            this.btnRegistrarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarPago.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarPago.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarPago.Location = new System.Drawing.Point(14, 11);
            this.btnRegistrarPago.Name = "btnRegistrarPago";
            this.btnRegistrarPago.Size = new System.Drawing.Size(163, 26);
            this.btnRegistrarPago.TabIndex = 0;
            this.btnRegistrarPago.Text = "Registrar Pago";
            this.btnRegistrarPago.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(190, 11);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(170, 26);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.pnlBody.Controls.Add(this.pnlCardObs);
            this.pnlBody.Controls.Add(this.pnlCardMixto);
            this.pnlBody.Controls.Add(this.pnlCardMetodo);
            this.pnlBody.Controls.Add(this.pnlCardDatos);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 59);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(403, 395);
            this.pnlBody.TabIndex = 1;
            // 
            // pnlCardObs
            // 
            this.pnlCardObs.BackColor = System.Drawing.Color.White;
            this.pnlCardObs.Controls.Add(this.lblObservaciones);
            this.pnlCardObs.Controls.Add(this.txtObservaciones);
            this.pnlCardObs.Location = new System.Drawing.Point(9, 296);
            this.pnlCardObs.Name = "pnlCardObs";
            this.pnlCardObs.Size = new System.Drawing.Size(382, 78);
            this.pnlCardObs.TabIndex = 3;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblObservaciones.Location = new System.Drawing.Point(12, 9);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(102, 15);
            this.lblObservaciones.TabIndex = 0;
            this.lblObservaciones.Text = "OBSERVACIONES";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservaciones.Location = new System.Drawing.Point(12, 26);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(367, 42);
            this.txtObservaciones.TabIndex = 1;
            // 
            // pnlCardMixto
            // 
            this.pnlCardMixto.BackColor = System.Drawing.Color.White;
            this.pnlCardMixto.Controls.Add(this.lblCardMixtoTitulo);
            this.pnlCardMixto.Controls.Add(this.lblEfLabel);
            this.pnlCardMixto.Controls.Add(this.txtEfectivo);
            this.pnlCardMixto.Controls.Add(this.lblYpLabel);
            this.pnlCardMixto.Controls.Add(this.txtYape);
            this.pnlCardMixto.Controls.Add(this.lblTrLabel);
            this.pnlCardMixto.Controls.Add(this.txtTransferencia);
            this.pnlCardMixto.Location = new System.Drawing.Point(9, 218);
            this.pnlCardMixto.Name = "pnlCardMixto";
            this.pnlCardMixto.Size = new System.Drawing.Size(382, 71);
            this.pnlCardMixto.TabIndex = 2;
            // 
            // lblCardMixtoTitulo
            // 
            this.lblCardMixtoTitulo.AutoSize = true;
            this.lblCardMixtoTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCardMixtoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblCardMixtoTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblCardMixtoTitulo.Name = "lblCardMixtoTitulo";
            this.lblCardMixtoTitulo.Size = new System.Drawing.Size(143, 15);
            this.lblCardMixtoTitulo.TabIndex = 0;
            this.lblCardMixtoTitulo.Text = "DESGLOSE PAGO MIXTO";
            // 
            // lblEfLabel
            // 
            this.lblEfLabel.AutoSize = true;
            this.lblEfLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEfLabel.Location = new System.Drawing.Point(12, 38);
            this.lblEfLabel.Name = "lblEfLabel";
            this.lblEfLabel.Size = new System.Drawing.Size(52, 15);
            this.lblEfLabel.TabIndex = 1;
            this.lblEfLabel.Text = "Efectivo:";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEfectivo.Location = new System.Drawing.Point(68, 35);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(55, 20);
            this.txtEfectivo.TabIndex = 2;
            // 
            // lblYpLabel
            // 
            this.lblYpLabel.AutoSize = true;
            this.lblYpLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblYpLabel.Location = new System.Drawing.Point(137, 38);
            this.lblYpLabel.Name = "lblYpLabel";
            this.lblYpLabel.Size = new System.Drawing.Size(35, 15);
            this.lblYpLabel.TabIndex = 3;
            this.lblYpLabel.Text = "Yape:";
            // 
            // txtYape
            // 
            this.txtYape.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYape.Location = new System.Drawing.Point(182, 35);
            this.txtYape.Name = "txtYape";
            this.txtYape.Size = new System.Drawing.Size(60, 20);
            this.txtYape.TabIndex = 4;
            // 
            // lblTrLabel
            // 
            this.lblTrLabel.AutoSize = true;
            this.lblTrLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTrLabel.Location = new System.Drawing.Point(247, 38);
            this.lblTrLabel.Name = "lblTrLabel";
            this.lblTrLabel.Size = new System.Drawing.Size(44, 15);
            this.lblTrLabel.TabIndex = 5;
            this.lblTrLabel.Text = "Transf.:";
            // 
            // txtTransferencia
            // 
            this.txtTransferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransferencia.Location = new System.Drawing.Point(297, 35);
            this.txtTransferencia.Name = "txtTransferencia";
            this.txtTransferencia.Size = new System.Drawing.Size(60, 20);
            this.txtTransferencia.TabIndex = 6;
            // 
            // pnlCardMetodo
            // 
            this.pnlCardMetodo.BackColor = System.Drawing.Color.White;
            this.pnlCardMetodo.Controls.Add(this.lblMetodoPago);
            this.pnlCardMetodo.Controls.Add(this.rbEfectivo);
            this.pnlCardMetodo.Controls.Add(this.rbYape);
            this.pnlCardMetodo.Controls.Add(this.rbTransferencia);
            this.pnlCardMetodo.Controls.Add(this.rbMixto);
            this.pnlCardMetodo.Location = new System.Drawing.Point(9, 111);
            this.pnlCardMetodo.Name = "pnlCardMetodo";
            this.pnlCardMetodo.Size = new System.Drawing.Size(382, 100);
            this.pnlCardMetodo.TabIndex = 1;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMetodoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblMetodoPago.Location = new System.Drawing.Point(12, 9);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(111, 15);
            this.lblMetodoPago.TabIndex = 0;
            this.lblMetodoPago.Text = "MÉTODO DE PAGO";
            // 
            // rbEfectivo
            // 
            this.rbEfectivo.AutoSize = true;
            this.rbEfectivo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rbEfectivo.Location = new System.Drawing.Point(12, 33);
            this.rbEfectivo.Name = "rbEfectivo";
            this.rbEfectivo.Size = new System.Drawing.Size(71, 21);
            this.rbEfectivo.TabIndex = 1;
            this.rbEfectivo.TabStop = true;
            this.rbEfectivo.Text = "Efectivo";
            this.rbEfectivo.UseVisualStyleBackColor = true;
            // 
            // rbYape
            // 
            this.rbYape.AutoSize = true;
            this.rbYape.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rbYape.Location = new System.Drawing.Point(12, 55);
            this.rbYape.Name = "rbYape";
            this.rbYape.Size = new System.Drawing.Size(54, 21);
            this.rbYape.TabIndex = 2;
            this.rbYape.TabStop = true;
            this.rbYape.Text = "Yape";
            this.rbYape.UseVisualStyleBackColor = true;
            // 
            // rbTransferencia
            // 
            this.rbTransferencia.AutoSize = true;
            this.rbTransferencia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rbTransferencia.Location = new System.Drawing.Point(12, 78);
            this.rbTransferencia.Name = "rbTransferencia";
            this.rbTransferencia.Size = new System.Drawing.Size(103, 21);
            this.rbTransferencia.TabIndex = 3;
            this.rbTransferencia.TabStop = true;
            this.rbTransferencia.Text = "Transferencia";
            this.rbTransferencia.UseVisualStyleBackColor = true;
            // 
            // rbMixto
            // 
            this.rbMixto.AutoSize = true;
            this.rbMixto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rbMixto.Location = new System.Drawing.Point(189, 33);
            this.rbMixto.Name = "rbMixto";
            this.rbMixto.Size = new System.Drawing.Size(59, 21);
            this.rbMixto.TabIndex = 4;
            this.rbMixto.TabStop = true;
            this.rbMixto.Text = "Mixto";
            this.rbMixto.UseVisualStyleBackColor = true;
            // 
            // pnlCardDatos
            // 
            this.pnlCardDatos.BackColor = System.Drawing.Color.White;
            this.pnlCardDatos.Controls.Add(this.lblCardDatosTitulo);
            this.pnlCardDatos.Controls.Add(this.lblFecha);
            this.pnlCardDatos.Controls.Add(this.dtpFecha);
            this.pnlCardDatos.Controls.Add(this.lblMontoPagar);
            this.pnlCardDatos.Controls.Add(this.txtMontoPagar);
            this.pnlCardDatos.Location = new System.Drawing.Point(9, 9);
            this.pnlCardDatos.Name = "pnlCardDatos";
            this.pnlCardDatos.Size = new System.Drawing.Size(382, 95);
            this.pnlCardDatos.TabIndex = 0;
            // 
            // lblCardDatosTitulo
            // 
            this.lblCardDatosTitulo.AutoSize = true;
            this.lblCardDatosTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCardDatosTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblCardDatosTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblCardDatosTitulo.Name = "lblCardDatosTitulo";
            this.lblCardDatosTitulo.Size = new System.Drawing.Size(105, 15);
            this.lblCardDatosTitulo.TabIndex = 0;
            this.lblCardDatosTitulo.Text = "DATOS DEL PAGO";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFecha.Location = new System.Drawing.Point(12, 33);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(87, 15);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha de pago:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(12, 49);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(138, 20);
            this.dtpFecha.TabIndex = 2;
            // 
            // lblMontoPagar
            // 
            this.lblMontoPagar.AutoSize = true;
            this.lblMontoPagar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMontoPagar.Location = new System.Drawing.Point(171, 33);
            this.lblMontoPagar.Name = "lblMontoPagar";
            this.lblMontoPagar.Size = new System.Drawing.Size(68, 15);
            this.lblMontoPagar.TabIndex = 3;
            this.lblMontoPagar.Text = "Monto (S/):";
            // 
            // txtMontoPagar
            // 
            this.txtMontoPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoPagar.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.txtMontoPagar.Location = new System.Drawing.Point(171, 47);
            this.txtMontoPagar.Name = "txtMontoPagar";
            this.txtMontoPagar.Size = new System.Drawing.Size(175, 31);
            this.txtMontoPagar.TabIndex = 4;
            this.txtMontoPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FormRegistrarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(403, 503);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRegistrarPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Pago";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlCardObs.ResumeLayout(false);
            this.pnlCardObs.PerformLayout();
            this.pnlCardMixto.ResumeLayout(false);
            this.pnlCardMixto.PerformLayout();
            this.pnlCardMetodo.ResumeLayout(false);
            this.pnlCardMetodo.PerformLayout();
            this.pnlCardDatos.ResumeLayout(false);
            this.pnlCardDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSaldoActual;
        private System.Windows.Forms.TextBox txtSaldoActual;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnRegistrarPago;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlCardDatos;
        private System.Windows.Forms.Label lblCardDatosTitulo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblMontoPagar;
        private System.Windows.Forms.TextBox txtMontoPagar;
        private System.Windows.Forms.Panel pnlCardMetodo;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.RadioButton rbEfectivo;
        private System.Windows.Forms.RadioButton rbYape;
        private System.Windows.Forms.RadioButton rbTransferencia;
        private System.Windows.Forms.RadioButton rbMixto;
        private System.Windows.Forms.Panel pnlCardMixto;
        private System.Windows.Forms.Label lblCardMixtoTitulo;
        private System.Windows.Forms.Label lblEfLabel;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.Label lblYpLabel;
        private System.Windows.Forms.TextBox txtYape;
        private System.Windows.Forms.Label lblTrLabel;
        private System.Windows.Forms.TextBox txtTransferencia;
        private System.Windows.Forms.Panel pnlCardObs;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
    }
}
