namespace SistemaPOS.Forms.Ventas
{
    partial class FormPago
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader           = new System.Windows.Forms.Panel();
            this.lblTotalLabel       = new System.Windows.Forms.Label();
            this.lblTotalAmount      = new System.Windows.Forms.Label();
            this.pnlMetodos          = new System.Windows.Forms.Panel();
            this.tlpMetodos          = new System.Windows.Forms.TableLayoutPanel();
            this.btnEfectivo         = new System.Windows.Forms.Button();
            this.btnYape             = new System.Windows.Forms.Button();
            this.btnTransferencia    = new System.Windows.Forms.Button();
            this.btnTarjeta          = new System.Windows.Forms.Button();
            this.btnMixto            = new System.Windows.Forms.Button();
            this.btnCredito          = new System.Windows.Forms.Button();
            this.pnlInputsContainer  = new System.Windows.Forms.Panel();
            this.pnlSinCambio        = new System.Windows.Forms.Panel();
            this.lblSinCambioInfo    = new System.Windows.Forms.Label();
            this.pnlCredito          = new System.Windows.Forms.Panel();
            this.lblCreditoInfo      = new System.Windows.Forms.Label();
            this.pnlMixto            = new System.Windows.Forms.Panel();
            this.lblMixtoRestante    = new System.Windows.Forms.Label();
            this.lblTarjetaMixto     = new System.Windows.Forms.Label();
            this.txtTarjetaPago      = new System.Windows.Forms.TextBox();
            this.lblTransferenciaMixto = new System.Windows.Forms.Label();
            this.txtTransferenciaPago  = new System.Windows.Forms.TextBox();
            this.lblYapeMixto        = new System.Windows.Forms.Label();
            this.txtYapePago         = new System.Windows.Forms.TextBox();
            this.lblEfectivoMixto    = new System.Windows.Forms.Label();
            this.txtEfectivoPago     = new System.Windows.Forms.TextBox();
            this.pnlEfectivo         = new System.Windows.Forms.Panel();
            this.lblVueltoPago       = new System.Windows.Forms.Label();
            this.lblVueltoLabel      = new System.Windows.Forms.Label();
            this.lblSeparadorEf      = new System.Windows.Forms.Label();
            this.txtRecibidoPago     = new System.Windows.Forms.TextBox();
            this.lblRecibidoLabel    = new System.Windows.Forms.Label();
            this.pnlBottomActions    = new System.Windows.Forms.Panel();
            this.btnCancelarPago     = new System.Windows.Forms.Button();
            this.btnConfirmar        = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlMetodos.SuspendLayout();
            this.tlpMetodos.SuspendLayout();
            this.pnlInputsContainer.SuspendLayout();
            this.pnlSinCambio.SuspendLayout();
            this.pnlCredito.SuspendLayout();
            this.pnlMixto.SuspendLayout();
            this.pnlEfectivo.SuspendLayout();
            this.pnlBottomActions.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ─────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.pnlHeader.Controls.Add(this.lblTotalAmount);
            this.pnlHeader.Controls.Add(this.lblTotalLabel);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(480, 80);
            this.pnlHeader.TabIndex = 0;

            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalLabel.ForeColor = System.Drawing.Color.FromArgb(200, 210, 255);
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

            // ── pnlMetodos ────────────────────────────────────────────
            this.pnlMetodos.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlMetodos.Controls.Add(this.tlpMetodos);
            this.pnlMetodos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMetodos.Location = new System.Drawing.Point(0, 80);
            this.pnlMetodos.Name = "pnlMetodos";
            this.pnlMetodos.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlMetodos.Size = new System.Drawing.Size(480, 106);
            this.pnlMetodos.TabIndex = 1;

            // tlpMetodos
            this.tlpMetodos.ColumnCount = 3;
            this.tlpMetodos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpMetodos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpMetodos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpMetodos.Controls.Add(this.btnEfectivo,      0, 0);
            this.tlpMetodos.Controls.Add(this.btnYape,          1, 0);
            this.tlpMetodos.Controls.Add(this.btnTransferencia, 2, 0);
            this.tlpMetodos.Controls.Add(this.btnTarjeta,       0, 1);
            this.tlpMetodos.Controls.Add(this.btnMixto,         1, 1);
            this.tlpMetodos.Controls.Add(this.btnCredito,       2, 1);
            this.tlpMetodos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMetodos.Name = "tlpMetodos";
            this.tlpMetodos.RowCount = 2;
            this.tlpMetodos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMetodos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMetodos.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
            this.tlpMetodos.TabIndex = 0;

            // ── botones método ────────────────────────────────────────
            this.btnEfectivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEfectivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEfectivo.FlatAppearance.BorderSize = 1;
            this.btnEfectivo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 221, 225);
            this.btnEfectivo.BackColor = System.Drawing.Color.White;
            this.btnEfectivo.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.btnEfectivo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnEfectivo.Text = "\U0001F4B5  Efectivo";
            this.btnEfectivo.Tag = "EFECTIVO";
            this.btnEfectivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEfectivo.Margin = new System.Windows.Forms.Padding(2);
            this.btnEfectivo.Name = "btnEfectivo";
            this.btnEfectivo.TabIndex = 0;

            this.btnYape.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnYape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYape.FlatAppearance.BorderSize = 1;
            this.btnYape.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 221, 225);
            this.btnYape.BackColor = System.Drawing.Color.White;
            this.btnYape.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.btnYape.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnYape.Text = "\U0001F4F1  Yape";
            this.btnYape.Tag = "YAPE";
            this.btnYape.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYape.Margin = new System.Windows.Forms.Padding(2);
            this.btnYape.Name = "btnYape";
            this.btnYape.TabIndex = 1;

            this.btnTransferencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTransferencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransferencia.FlatAppearance.BorderSize = 1;
            this.btnTransferencia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 221, 225);
            this.btnTransferencia.BackColor = System.Drawing.Color.White;
            this.btnTransferencia.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.btnTransferencia.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnTransferencia.Text = "\U0001F3E6  Transfer.";
            this.btnTransferencia.Tag = "TRANSFERENCIA";
            this.btnTransferencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransferencia.Margin = new System.Windows.Forms.Padding(2);
            this.btnTransferencia.Name = "btnTransferencia";
            this.btnTransferencia.TabIndex = 2;

            this.btnTarjeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTarjeta.FlatAppearance.BorderSize = 1;
            this.btnTarjeta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 221, 225);
            this.btnTarjeta.BackColor = System.Drawing.Color.White;
            this.btnTarjeta.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.btnTarjeta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnTarjeta.Text = "\U0001F4B3  Tarjeta";
            this.btnTarjeta.Tag = "TARJETA";
            this.btnTarjeta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTarjeta.Margin = new System.Windows.Forms.Padding(2);
            this.btnTarjeta.Name = "btnTarjeta";
            this.btnTarjeta.TabIndex = 3;

            this.btnMixto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMixto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMixto.FlatAppearance.BorderSize = 1;
            this.btnMixto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 221, 225);
            this.btnMixto.BackColor = System.Drawing.Color.White;
            this.btnMixto.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.btnMixto.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnMixto.Text = "\u26A1  Mixto";
            this.btnMixto.Tag = "MIXTO";
            this.btnMixto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMixto.Margin = new System.Windows.Forms.Padding(2);
            this.btnMixto.Name = "btnMixto";
            this.btnMixto.TabIndex = 4;

            this.btnCredito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCredito.FlatAppearance.BorderSize = 1;
            this.btnCredito.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 221, 225);
            this.btnCredito.BackColor = System.Drawing.Color.White;
            this.btnCredito.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.btnCredito.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnCredito.Text = "\U0001F4CB  Credito";
            this.btnCredito.Tag = "CREDITO";
            this.btnCredito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCredito.Margin = new System.Windows.Forms.Padding(2);
            this.btnCredito.Name = "btnCredito";
            this.btnCredito.TabIndex = 5;

            // ── pnlBottomActions ──────────────────────────────────────
            this.pnlBottomActions.BackColor = System.Drawing.Color.White;
            this.pnlBottomActions.Controls.Add(this.btnConfirmar);
            this.pnlBottomActions.Controls.Add(this.btnCancelarPago);
            this.pnlBottomActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomActions.Location = new System.Drawing.Point(0, 520);
            this.pnlBottomActions.Name = "pnlBottomActions";
            this.pnlBottomActions.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlBottomActions.Size = new System.Drawing.Size(480, 60);
            this.pnlBottomActions.TabIndex = 2;

            this.btnCancelarPago.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelarPago.BackColor = System.Drawing.Color.White;
            this.btnCancelarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarPago.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 221, 225);
            this.btnCancelarPago.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancelarPago.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.btnCancelarPago.Location = new System.Drawing.Point(12, 8);
            this.btnCancelarPago.Name = "btnCancelarPago";
            this.btnCancelarPago.Size = new System.Drawing.Size(140, 40);
            this.btnCancelarPago.TabIndex = 0;
            this.btnCancelarPago.Text = "Cancelar";
            this.btnCancelarPago.Cursor = System.Windows.Forms.Cursors.Hand;

            this.btnConfirmar.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(316, 8);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(152, 40);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = "Confirmar pago";
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;

            // ── pnlInputsContainer ────────────────────────────────────
            this.pnlInputsContainer.BackColor = System.Drawing.Color.White;
            this.pnlInputsContainer.Controls.Add(this.pnlSinCambio);
            this.pnlInputsContainer.Controls.Add(this.pnlCredito);
            this.pnlInputsContainer.Controls.Add(this.pnlMixto);
            this.pnlInputsContainer.Controls.Add(this.pnlEfectivo);
            this.pnlInputsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInputsContainer.Location = new System.Drawing.Point(0, 186);
            this.pnlInputsContainer.Name = "pnlInputsContainer";
            this.pnlInputsContainer.Padding = new System.Windows.Forms.Padding(20, 12, 20, 8);
            this.pnlInputsContainer.Size = new System.Drawing.Size(480, 334);
            this.pnlInputsContainer.TabIndex = 3;

            // ── pnlEfectivo ───────────────────────────────────────────
            this.pnlEfectivo.BackColor = System.Drawing.Color.White;
            this.pnlEfectivo.Controls.Add(this.lblVueltoPago);
            this.pnlEfectivo.Controls.Add(this.lblVueltoLabel);
            this.pnlEfectivo.Controls.Add(this.lblSeparadorEf);
            this.pnlEfectivo.Controls.Add(this.txtRecibidoPago);
            this.pnlEfectivo.Controls.Add(this.lblRecibidoLabel);
            this.pnlEfectivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEfectivo.Name = "pnlEfectivo";
            this.pnlEfectivo.TabIndex = 3;
            this.pnlEfectivo.Visible = true;

            this.lblRecibidoLabel.AutoSize = true;
            this.lblRecibidoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRecibidoLabel.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblRecibidoLabel.Location = new System.Drawing.Point(0, 8);
            this.lblRecibidoLabel.Name = "lblRecibidoLabel";
            this.lblRecibidoLabel.TabIndex = 0;
            this.lblRecibidoLabel.Text = "Monto recibido (S/)";

            this.txtRecibidoPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecibidoPago.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.txtRecibidoPago.Location = new System.Drawing.Point(0, 28);
            this.txtRecibidoPago.Name = "txtRecibidoPago";
            this.txtRecibidoPago.Size = new System.Drawing.Size(440, 46);
            this.txtRecibidoPago.TabIndex = 1;
            this.txtRecibidoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblSeparadorEf.BackColor = System.Drawing.Color.FromArgb(230, 232, 236);
            this.lblSeparadorEf.Location = new System.Drawing.Point(0, 84);
            this.lblSeparadorEf.Name = "lblSeparadorEf";
            this.lblSeparadorEf.Size = new System.Drawing.Size(440, 1);
            this.lblSeparadorEf.TabIndex = 2;

            this.lblVueltoLabel.AutoSize = true;
            this.lblVueltoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVueltoLabel.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblVueltoLabel.Location = new System.Drawing.Point(0, 96);
            this.lblVueltoLabel.Name = "lblVueltoLabel";
            this.lblVueltoLabel.TabIndex = 3;
            this.lblVueltoLabel.Text = "VUELTO:";

            this.lblVueltoPago.AutoSize = true;
            this.lblVueltoPago.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblVueltoPago.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblVueltoPago.Location = new System.Drawing.Point(0, 116);
            this.lblVueltoPago.Name = "lblVueltoPago";
            this.lblVueltoPago.TabIndex = 4;
            this.lblVueltoPago.Text = "S/ 0.00";

            // ── pnlMixto ──────────────────────────────────────────────
            this.pnlMixto.BackColor = System.Drawing.Color.White;
            this.pnlMixto.Controls.Add(this.lblMixtoRestante);
            this.pnlMixto.Controls.Add(this.lblTarjetaMixto);
            this.pnlMixto.Controls.Add(this.txtTarjetaPago);
            this.pnlMixto.Controls.Add(this.lblTransferenciaMixto);
            this.pnlMixto.Controls.Add(this.txtTransferenciaPago);
            this.pnlMixto.Controls.Add(this.lblYapeMixto);
            this.pnlMixto.Controls.Add(this.txtYapePago);
            this.pnlMixto.Controls.Add(this.lblEfectivoMixto);
            this.pnlMixto.Controls.Add(this.txtEfectivoPago);
            this.pnlMixto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMixto.Name = "pnlMixto";
            this.pnlMixto.TabIndex = 2;
            this.pnlMixto.Visible = false;

            this.lblEfectivoMixto.AutoSize = true;
            this.lblEfectivoMixto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEfectivoMixto.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblEfectivoMixto.Location = new System.Drawing.Point(0, 7);
            this.lblEfectivoMixto.Name = "lblEfectivoMixto";
            this.lblEfectivoMixto.TabIndex = 0;
            this.lblEfectivoMixto.Text = "Efectivo";

            this.txtEfectivoPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEfectivoPago.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEfectivoPago.Location = new System.Drawing.Point(160, 4);
            this.txtEfectivoPago.Name = "txtEfectivoPago";
            this.txtEfectivoPago.Size = new System.Drawing.Size(280, 26);
            this.txtEfectivoPago.TabIndex = 1;
            this.txtEfectivoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblYapeMixto.AutoSize = true;
            this.lblYapeMixto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblYapeMixto.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblYapeMixto.Location = new System.Drawing.Point(0, 45);
            this.lblYapeMixto.Name = "lblYapeMixto";
            this.lblYapeMixto.TabIndex = 2;
            this.lblYapeMixto.Text = "Yape";

            this.txtYapePago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYapePago.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtYapePago.Location = new System.Drawing.Point(160, 42);
            this.txtYapePago.Name = "txtYapePago";
            this.txtYapePago.Size = new System.Drawing.Size(280, 26);
            this.txtYapePago.TabIndex = 3;
            this.txtYapePago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblTransferenciaMixto.AutoSize = true;
            this.lblTransferenciaMixto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTransferenciaMixto.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblTransferenciaMixto.Location = new System.Drawing.Point(0, 83);
            this.lblTransferenciaMixto.Name = "lblTransferenciaMixto";
            this.lblTransferenciaMixto.TabIndex = 4;
            this.lblTransferenciaMixto.Text = "Transferencia";

            this.txtTransferenciaPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransferenciaPago.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTransferenciaPago.Location = new System.Drawing.Point(160, 80);
            this.txtTransferenciaPago.Name = "txtTransferenciaPago";
            this.txtTransferenciaPago.Size = new System.Drawing.Size(280, 26);
            this.txtTransferenciaPago.TabIndex = 5;
            this.txtTransferenciaPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblTarjetaMixto.AutoSize = true;
            this.lblTarjetaMixto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTarjetaMixto.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblTarjetaMixto.Location = new System.Drawing.Point(0, 121);
            this.lblTarjetaMixto.Name = "lblTarjetaMixto";
            this.lblTarjetaMixto.TabIndex = 6;
            this.lblTarjetaMixto.Text = "Tarjeta";

            this.txtTarjetaPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTarjetaPago.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTarjetaPago.Location = new System.Drawing.Point(160, 118);
            this.txtTarjetaPago.Name = "txtTarjetaPago";
            this.txtTarjetaPago.Size = new System.Drawing.Size(280, 26);
            this.txtTarjetaPago.TabIndex = 7;
            this.txtTarjetaPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblMixtoRestante.AutoSize = true;
            this.lblMixtoRestante.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMixtoRestante.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblMixtoRestante.Location = new System.Drawing.Point(0, 162);
            this.lblMixtoRestante.Name = "lblMixtoRestante";
            this.lblMixtoRestante.TabIndex = 8;
            this.lblMixtoRestante.Text = "Suma: S/ 0.00  /  Total: S/ 0.00";

            // ── pnlCredito ────────────────────────────────────────────
            this.pnlCredito.BackColor = System.Drawing.Color.White;
            this.pnlCredito.Controls.Add(this.lblCreditoInfo);
            this.pnlCredito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCredito.Name = "pnlCredito";
            this.pnlCredito.TabIndex = 1;
            this.pnlCredito.Visible = false;

            this.lblCreditoInfo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCreditoInfo.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblCreditoInfo.Location = new System.Drawing.Point(0, 40);
            this.lblCreditoInfo.Name = "lblCreditoInfo";
            this.lblCreditoInfo.Size = new System.Drawing.Size(440, 60);
            this.lblCreditoInfo.TabIndex = 0;
            this.lblCreditoInfo.Text = "Se generara una Cuenta por Cobrar.\nEl cliente debe estar registrado.";
            this.lblCreditoInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── pnlSinCambio ──────────────────────────────────────────
            this.pnlSinCambio.BackColor = System.Drawing.Color.White;
            this.pnlSinCambio.Controls.Add(this.lblSinCambioInfo);
            this.pnlSinCambio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSinCambio.Name = "pnlSinCambio";
            this.pnlSinCambio.TabIndex = 0;
            this.pnlSinCambio.Visible = false;

            this.lblSinCambioInfo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSinCambioInfo.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblSinCambioInfo.Location = new System.Drawing.Point(0, 40);
            this.lblSinCambioInfo.Name = "lblSinCambioInfo";
            this.lblSinCambioInfo.Size = new System.Drawing.Size(440, 40);
            this.lblSinCambioInfo.TabIndex = 0;
            this.lblSinCambioInfo.Text = "Pago exacto — no se requiere monto adicional.";
            this.lblSinCambioInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── FormPago ──────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 580);
            this.Controls.Add(this.pnlInputsContainer);
            this.Controls.Add(this.pnlBottomActions);
            this.Controls.Add(this.pnlMetodos);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pago";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMetodos.ResumeLayout(false);
            this.tlpMetodos.ResumeLayout(false);
            this.pnlInputsContainer.ResumeLayout(false);
            this.pnlSinCambio.ResumeLayout(false);
            this.pnlSinCambio.PerformLayout();
            this.pnlCredito.ResumeLayout(false);
            this.pnlMixto.ResumeLayout(false);
            this.pnlMixto.PerformLayout();
            this.pnlEfectivo.ResumeLayout(false);
            this.pnlEfectivo.PerformLayout();
            this.pnlBottomActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #region Fields
        private System.Windows.Forms.Panel            pnlHeader;
        private System.Windows.Forms.Label            lblTotalLabel;
        private System.Windows.Forms.Label            lblTotalAmount;
        private System.Windows.Forms.Panel            pnlMetodos;
        private System.Windows.Forms.TableLayoutPanel tlpMetodos;
        private System.Windows.Forms.Button           btnEfectivo;
        private System.Windows.Forms.Button           btnYape;
        private System.Windows.Forms.Button           btnTransferencia;
        private System.Windows.Forms.Button           btnTarjeta;
        private System.Windows.Forms.Button           btnMixto;
        private System.Windows.Forms.Button           btnCredito;
        private System.Windows.Forms.Panel            pnlInputsContainer;
        private System.Windows.Forms.Panel            pnlEfectivo;
        private System.Windows.Forms.Label            lblRecibidoLabel;
        private System.Windows.Forms.TextBox          txtRecibidoPago;
        private System.Windows.Forms.Label            lblSeparadorEf;
        private System.Windows.Forms.Label            lblVueltoLabel;
        private System.Windows.Forms.Label            lblVueltoPago;
        private System.Windows.Forms.Panel            pnlMixto;
        private System.Windows.Forms.Label            lblEfectivoMixto;
        private System.Windows.Forms.TextBox          txtEfectivoPago;
        private System.Windows.Forms.Label            lblYapeMixto;
        private System.Windows.Forms.TextBox          txtYapePago;
        private System.Windows.Forms.Label            lblTransferenciaMixto;
        private System.Windows.Forms.TextBox          txtTransferenciaPago;
        private System.Windows.Forms.Label            lblTarjetaMixto;
        private System.Windows.Forms.TextBox          txtTarjetaPago;
        private System.Windows.Forms.Label            lblMixtoRestante;
        private System.Windows.Forms.Panel            pnlCredito;
        private System.Windows.Forms.Label            lblCreditoInfo;
        private System.Windows.Forms.Panel            pnlSinCambio;
        private System.Windows.Forms.Label            lblSinCambioInfo;
        private System.Windows.Forms.Panel            pnlBottomActions;
        private System.Windows.Forms.Button           btnCancelarPago;
        private System.Windows.Forms.Button           btnConfirmar;
        #endregion
    }
}
