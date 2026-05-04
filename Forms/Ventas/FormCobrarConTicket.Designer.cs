namespace SistemaPOS.Forms.Ventas
{
    partial class FormCobrarConTicket
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTicketSide      = new System.Windows.Forms.Panel();
            this.pnlTicketHeader    = new System.Windows.Forms.Panel();
            this.lblTicketTitle     = new System.Windows.Forms.Label();
            this.pnlScrollTicket    = new System.Windows.Forms.Panel();
            this.pnlVistaTicket     = new SistemaPOS.Controls.TicketPaperPanel();
            this.pnlPagoSide        = new System.Windows.Forms.Panel();
            this.pnlPagoHeader      = new System.Windows.Forms.Panel();
            this.lblTotalLabel      = new System.Windows.Forms.Label();
            this.lblTotalAmount     = new System.Windows.Forms.Label();
            this.pnlMetodosLista    = new System.Windows.Forms.Panel();
            this.rdbEfectivo        = new System.Windows.Forms.RadioButton();
            this.txtMontoEfectivo   = new System.Windows.Forms.TextBox();
            this.rdbYape            = new System.Windows.Forms.RadioButton();
            this.txtMontoYape       = new System.Windows.Forms.TextBox();
            this.rdbTransferencia   = new System.Windows.Forms.RadioButton();
            this.txtMontoTransferencia = new System.Windows.Forms.TextBox();
            this.rdbTarjeta         = new System.Windows.Forms.RadioButton();
            this.txtMontoTarjeta    = new System.Windows.Forms.TextBox();
            this.rdbCredito         = new System.Windows.Forms.RadioButton();
            this.lblCreditoInfoMini = new System.Windows.Forms.Label();
            this.lblSepResumen      = new System.Windows.Forms.Label();
            this.lblResumenPago     = new System.Windows.Forms.Label();
            this.pnlBottom          = new System.Windows.Forms.Panel();
            this.btnConfirmar       = new System.Windows.Forms.Button();
            this.btnCancelar        = new System.Windows.Forms.Button();

            this.pnlTicketSide.SuspendLayout();
            this.pnlTicketHeader.SuspendLayout();
            this.pnlScrollTicket.SuspendLayout();
            this.pnlPagoSide.SuspendLayout();
            this.pnlPagoHeader.SuspendLayout();
            this.pnlMetodosLista.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // ── pnlBottom ─────────────────────────────────────────────────────
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Controls.Add(this.btnConfirmar);
            this.pnlBottom.Controls.Add(this.btnCancelar);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlBottom.Size = new System.Drawing.Size(880, 60);
            this.pnlBottom.TabIndex = 0;

            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnCancelar.Location = new System.Drawing.Point(12, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 40);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;

            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(716, 10);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(152, 40);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = "Confirmar método";
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;

            // ── pnlTicketSide ─────────────────────────────────────────────────
            this.pnlTicketSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlTicketSide.Controls.Add(this.pnlScrollTicket);
            this.pnlTicketSide.Controls.Add(this.pnlTicketHeader);
            this.pnlTicketSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTicketSide.Name = "pnlTicketSide";
            this.pnlTicketSide.Size = new System.Drawing.Size(340, 520);
            this.pnlTicketSide.TabIndex = 1;

            this.pnlTicketHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlTicketHeader.Controls.Add(this.lblTicketTitle);
            this.pnlTicketHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTicketHeader.Name = "pnlTicketHeader";
            this.pnlTicketHeader.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.pnlTicketHeader.Size = new System.Drawing.Size(340, 36);
            this.pnlTicketHeader.TabIndex = 0;

            this.lblTicketTitle.AutoSize = true;
            this.lblTicketTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTicketTitle.ForeColor = System.Drawing.Color.White;
            this.lblTicketTitle.Location = new System.Drawing.Point(14, 10);
            this.lblTicketTitle.Name = "lblTicketTitle";
            this.lblTicketTitle.TabIndex = 0;
            this.lblTicketTitle.Text = "Vista Previa del Ticket";

            this.pnlScrollTicket.AutoScroll = true;
            this.pnlScrollTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlScrollTicket.Controls.Add(this.pnlVistaTicket);
            this.pnlScrollTicket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScrollTicket.Name = "pnlScrollTicket";
            this.pnlScrollTicket.Padding = new System.Windows.Forms.Padding(14, 16, 14, 16);
            this.pnlScrollTicket.TabIndex = 1;

            this.pnlVistaTicket.Location = new System.Drawing.Point(14, 16);
            this.pnlVistaTicket.Margin = new System.Windows.Forms.Padding(0);
            this.pnlVistaTicket.Name = "pnlVistaTicket";
            this.pnlVistaTicket.PaperColor = System.Drawing.Color.White;
            this.pnlVistaTicket.PaperPaddingX = 16;
            this.pnlVistaTicket.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlVistaTicket.Size = new System.Drawing.Size(300, 400);
            this.pnlVistaTicket.TabIndex = 0;
            this.pnlVistaTicket.ToothSize = 10;
            this.pnlVistaTicket.ToothWidth = 16;

            // ── pnlPagoSide ───────────────────────────────────────────────────
            this.pnlPagoSide.BackColor = System.Drawing.Color.White;
            this.pnlPagoSide.Controls.Add(this.pnlMetodosLista);
            this.pnlPagoSide.Controls.Add(this.pnlPagoHeader);
            this.pnlPagoSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPagoSide.Name = "pnlPagoSide";
            this.pnlPagoSide.TabIndex = 2;

            this.pnlPagoHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.pnlPagoHeader.Controls.Add(this.lblTotalAmount);
            this.pnlPagoHeader.Controls.Add(this.lblTotalLabel);
            this.pnlPagoHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPagoHeader.Name = "pnlPagoHeader";
            this.pnlPagoHeader.Size = new System.Drawing.Size(540, 80);
            this.pnlPagoHeader.TabIndex = 0;

            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.lblTotalLabel.Location = new System.Drawing.Point(20, 14);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.TabIndex = 0;
            this.lblTotalLabel.Text = "TOTAL A PAGAR";

            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.White;
            this.lblTotalAmount.Location = new System.Drawing.Point(16, 32);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "S/ 0.00";

            // ── pnlMetodosLista ───────────────────────────────────────────────
            this.pnlMetodosLista.BackColor = System.Drawing.Color.White;
            this.pnlMetodosLista.Controls.Add(this.rdbEfectivo);
            this.pnlMetodosLista.Controls.Add(this.txtMontoEfectivo);
            this.pnlMetodosLista.Controls.Add(this.rdbYape);
            this.pnlMetodosLista.Controls.Add(this.txtMontoYape);
            this.pnlMetodosLista.Controls.Add(this.rdbTransferencia);
            this.pnlMetodosLista.Controls.Add(this.txtMontoTransferencia);
            this.pnlMetodosLista.Controls.Add(this.rdbTarjeta);
            this.pnlMetodosLista.Controls.Add(this.txtMontoTarjeta);
            this.pnlMetodosLista.Controls.Add(this.rdbCredito);
            this.pnlMetodosLista.Controls.Add(this.lblCreditoInfoMini);
            this.pnlMetodosLista.Controls.Add(this.lblSepResumen);
            this.pnlMetodosLista.Controls.Add(this.lblResumenPago);
            this.pnlMetodosLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMetodosLista.Name = "pnlMetodosLista";
            this.pnlMetodosLista.TabIndex = 1;

            // Row 0 — Efectivo  (Y=20)
            this.rdbEfectivo.AutoCheck = false;
            this.rdbEfectivo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.rdbEfectivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.rdbEfectivo.Location = new System.Drawing.Point(20, 22);
            this.rdbEfectivo.Name = "rdbEfectivo";
            this.rdbEfectivo.Size = new System.Drawing.Size(160, 28);
            this.rdbEfectivo.TabIndex = 0;
            this.rdbEfectivo.Text = "\U0001F4B5  Efectivo";
            this.rdbEfectivo.Cursor = System.Windows.Forms.Cursors.Hand;

            this.txtMontoEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoEfectivo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMontoEfectivo.Location = new System.Drawing.Point(190, 20);
            this.txtMontoEfectivo.Name = "txtMontoEfectivo";
            this.txtMontoEfectivo.Size = new System.Drawing.Size(280, 30);
            this.txtMontoEfectivo.TabIndex = 1;
            this.txtMontoEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoEfectivo.Enabled = false;

            // Row 1 — Yape  (Y=64)
            this.rdbYape.AutoCheck = false;
            this.rdbYape.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.rdbYape.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.rdbYape.Location = new System.Drawing.Point(20, 66);
            this.rdbYape.Name = "rdbYape";
            this.rdbYape.Size = new System.Drawing.Size(160, 28);
            this.rdbYape.TabIndex = 2;
            this.rdbYape.Text = "\U0001F4F1  Yape";
            this.rdbYape.Cursor = System.Windows.Forms.Cursors.Hand;

            this.txtMontoYape.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoYape.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMontoYape.Location = new System.Drawing.Point(190, 64);
            this.txtMontoYape.Name = "txtMontoYape";
            this.txtMontoYape.Size = new System.Drawing.Size(280, 30);
            this.txtMontoYape.TabIndex = 3;
            this.txtMontoYape.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoYape.Enabled = false;

            // Row 2 — Transferencia  (Y=108)
            this.rdbTransferencia.AutoCheck = false;
            this.rdbTransferencia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.rdbTransferencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.rdbTransferencia.Location = new System.Drawing.Point(20, 110);
            this.rdbTransferencia.Name = "rdbTransferencia";
            this.rdbTransferencia.Size = new System.Drawing.Size(160, 28);
            this.rdbTransferencia.TabIndex = 4;
            this.rdbTransferencia.Text = "\U0001F3E6  Transfer.";
            this.rdbTransferencia.Cursor = System.Windows.Forms.Cursors.Hand;

            this.txtMontoTransferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoTransferencia.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMontoTransferencia.Location = new System.Drawing.Point(190, 108);
            this.txtMontoTransferencia.Name = "txtMontoTransferencia";
            this.txtMontoTransferencia.Size = new System.Drawing.Size(280, 30);
            this.txtMontoTransferencia.TabIndex = 5;
            this.txtMontoTransferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoTransferencia.Enabled = false;

            // Row 3 — Tarjeta  (Y=152)
            this.rdbTarjeta.AutoCheck = false;
            this.rdbTarjeta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.rdbTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.rdbTarjeta.Location = new System.Drawing.Point(20, 154);
            this.rdbTarjeta.Name = "rdbTarjeta";
            this.rdbTarjeta.Size = new System.Drawing.Size(160, 28);
            this.rdbTarjeta.TabIndex = 6;
            this.rdbTarjeta.Text = "\U0001F4B3  Tarjeta";
            this.rdbTarjeta.Cursor = System.Windows.Forms.Cursors.Hand;

            this.txtMontoTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoTarjeta.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMontoTarjeta.Location = new System.Drawing.Point(190, 152);
            this.txtMontoTarjeta.Name = "txtMontoTarjeta";
            this.txtMontoTarjeta.Size = new System.Drawing.Size(280, 30);
            this.txtMontoTarjeta.TabIndex = 7;
            this.txtMontoTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoTarjeta.Enabled = false;

            // Row 4 — Crédito  (Y=196)
            this.rdbCredito.AutoCheck = false;
            this.rdbCredito.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.rdbCredito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.rdbCredito.Location = new System.Drawing.Point(20, 198);
            this.rdbCredito.Name = "rdbCredito";
            this.rdbCredito.Size = new System.Drawing.Size(160, 28);
            this.rdbCredito.TabIndex = 8;
            this.rdbCredito.Text = "\U0001F4CB  Crédito";
            this.rdbCredito.Cursor = System.Windows.Forms.Cursors.Hand;

            this.lblCreditoInfoMini.AutoSize = false;
            this.lblCreditoInfoMini.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCreditoInfoMini.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblCreditoInfoMini.Location = new System.Drawing.Point(190, 196);
            this.lblCreditoInfoMini.Name = "lblCreditoInfoMini";
            this.lblCreditoInfoMini.Size = new System.Drawing.Size(280, 30);
            this.lblCreditoInfoMini.TabIndex = 9;
            this.lblCreditoInfoMini.Text = "Genera Cuenta por Cobrar";
            this.lblCreditoInfoMini.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCreditoInfoMini.Visible = false;

            // Separator
            this.lblSepResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(236)))));
            this.lblSepResumen.Location = new System.Drawing.Point(20, 238);
            this.lblSepResumen.Name = "lblSepResumen";
            this.lblSepResumen.Size = new System.Drawing.Size(450, 1);
            this.lblSepResumen.TabIndex = 10;

            // Resumen
            this.lblResumenPago.AutoSize = true;
            this.lblResumenPago.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResumenPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblResumenPago.Location = new System.Drawing.Point(20, 248);
            this.lblResumenPago.Name = "lblResumenPago";
            this.lblResumenPago.TabIndex = 11;
            this.lblResumenPago.Text = "Suma: S/ 0.00   /   Total: S/ 0.00";

            // ── Form ──────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 580);
            this.Controls.Add(this.pnlPagoSide);
            this.Controls.Add(this.pnlTicketSide);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCobrarConTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cobrar";

            this.pnlTicketSide.ResumeLayout(false);
            this.pnlTicketHeader.ResumeLayout(false);
            this.pnlTicketHeader.PerformLayout();
            this.pnlScrollTicket.ResumeLayout(false);
            this.pnlPagoSide.ResumeLayout(false);
            this.pnlPagoHeader.ResumeLayout(false);
            this.pnlPagoHeader.PerformLayout();
            this.pnlMetodosLista.ResumeLayout(false);
            this.pnlMetodosLista.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel               pnlTicketSide;
        private System.Windows.Forms.Panel               pnlTicketHeader;
        private System.Windows.Forms.Label               lblTicketTitle;
        private System.Windows.Forms.Panel               pnlScrollTicket;
        private SistemaPOS.Controls.TicketPaperPanel     pnlVistaTicket;
        private System.Windows.Forms.Panel               pnlPagoSide;
        private System.Windows.Forms.Panel               pnlPagoHeader;
        private System.Windows.Forms.Label               lblTotalLabel;
        private System.Windows.Forms.Label               lblTotalAmount;
        private System.Windows.Forms.Panel               pnlMetodosLista;
        private System.Windows.Forms.RadioButton         rdbEfectivo;
        private System.Windows.Forms.TextBox             txtMontoEfectivo;
        private System.Windows.Forms.RadioButton         rdbYape;
        private System.Windows.Forms.TextBox             txtMontoYape;
        private System.Windows.Forms.RadioButton         rdbTransferencia;
        private System.Windows.Forms.TextBox             txtMontoTransferencia;
        private System.Windows.Forms.RadioButton         rdbTarjeta;
        private System.Windows.Forms.TextBox             txtMontoTarjeta;
        private System.Windows.Forms.RadioButton         rdbCredito;
        private System.Windows.Forms.Label               lblCreditoInfoMini;
        private System.Windows.Forms.Label               lblSepResumen;
        private System.Windows.Forms.Label               lblResumenPago;
        private System.Windows.Forms.Panel               pnlBottom;
        private System.Windows.Forms.Button              btnConfirmar;
        private System.Windows.Forms.Button              btnCancelar;
    }
}
