namespace SistemaPOS.Forms.Finanzas
{
    partial class FormRegistrarGasto
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
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlCardFecha = new System.Windows.Forms.Panel();
            this.lblCardFechaTitulo = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblHora = new System.Windows.Forms.Label();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.pnlCardConcepto = new System.Windows.Forms.Panel();
            this.lblCardConceptoTitulo = new System.Windows.Forms.Label();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.pnlCardMontoCategoria = new System.Windows.Forms.Panel();
            this.lblCardMCTitulo = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.numMonto = new System.Windows.Forms.NumericUpDown();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblTipoIGV = new System.Windows.Forms.Label();
            this.cboIGV = new System.Windows.Forms.ComboBox();
            this.lblBaseImpHeader = new System.Windows.Forms.Label();
            this.lblIGVHeader = new System.Windows.Forms.Label();
            this.lblTotalHeader = new System.Windows.Forms.Label();
            this.txtBaseImponible = new System.Windows.Forms.TextBox();
            this.txtIGVGasto = new System.Windows.Forms.TextBox();
            this.txtGastoTotal = new System.Windows.Forms.TextBox();
            this.pnlCardMetodo = new System.Windows.Forms.Panel();
            this.lblCardMetodoTitulo = new System.Windows.Forms.Label();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.txtComprobante = new System.Windows.Forms.TextBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.pnlCardObs = new System.Windows.Forms.Panel();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlCardFecha.SuspendLayout();
            this.pnlCardConcepto.SuspendLayout();
            this.pnlCardMontoCategoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).BeginInit();
            this.pnlCardMetodo.SuspendLayout();
            this.pnlCardObs.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 68;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(16, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(150, 22);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registrar Gasto";
            //
            // lblHeaderSub
            //
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(178, 190, 195);
            this.lblHeaderSub.Location = new System.Drawing.Point(16, 42);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(200, 15);
            this.lblHeaderSub.TabIndex = 1;
            this.lblHeaderSub.Text = "Complete los datos del gasto";
            //
            // pnlFooter
            //
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.btnGuardar);
            this.pnlFooter.Controls.Add(this.btnCancelar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 56;
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.TabIndex = 2;
            //
            // btnGuardar
            //
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(0, 184, 148);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(16, 13);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(256, 30);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            //
            // btnCancelar
            //
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(286, 13);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(298, 30);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            //
            // pnlBody
            //
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
            this.pnlBody.Controls.Add(this.pnlCardObs);
            this.pnlBody.Controls.Add(this.pnlCardMetodo);
            this.pnlBody.Controls.Add(this.pnlCardMontoCategoria);
            this.pnlBody.Controls.Add(this.pnlCardConcepto);
            this.pnlBody.Controls.Add(this.pnlCardFecha);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.TabIndex = 1;
            //
            // pnlCardFecha
            //
            this.pnlCardFecha.BackColor = System.Drawing.Color.White;
            this.pnlCardFecha.Controls.Add(this.lblCardFechaTitulo);
            this.pnlCardFecha.Controls.Add(this.lblFecha);
            this.pnlCardFecha.Controls.Add(this.dtpFecha);
            this.pnlCardFecha.Controls.Add(this.lblHora);
            this.pnlCardFecha.Controls.Add(this.dtpHora);
            this.pnlCardFecha.Location = new System.Drawing.Point(10, 10);
            this.pnlCardFecha.Name = "pnlCardFecha";
            this.pnlCardFecha.Size = new System.Drawing.Size(578, 90);
            this.pnlCardFecha.TabIndex = 0;
            //
            // lblCardFechaTitulo
            //
            this.lblCardFechaTitulo.AutoSize = true;
            this.lblCardFechaTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCardFechaTitulo.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblCardFechaTitulo.Location = new System.Drawing.Point(14, 10);
            this.lblCardFechaTitulo.Name = "lblCardFechaTitulo";
            this.lblCardFechaTitulo.Size = new System.Drawing.Size(90, 13);
            this.lblCardFechaTitulo.TabIndex = 0;
            this.lblCardFechaTitulo.Text = "FECHA Y HORA";
            //
            // lblFecha
            //
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFecha.Location = new System.Drawing.Point(14, 36);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(55, 15);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha: *";
            //
            // dtpFecha
            //
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(14, 54);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(268, 24);
            this.dtpFecha.TabIndex = 2;
            //
            // lblHora
            //
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHora.Location = new System.Drawing.Point(300, 36);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(46, 15);
            this.lblHora.TabIndex = 3;
            this.lblHora.Text = "Hora: *";
            //
            // dtpHora
            //
            this.dtpHora.CustomFormat = "HH:mm";
            this.dtpHora.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHora.Location = new System.Drawing.Point(300, 54);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(264, 24);
            this.dtpHora.TabIndex = 4;
            //
            // pnlCardConcepto
            //
            this.pnlCardConcepto.BackColor = System.Drawing.Color.White;
            this.pnlCardConcepto.Controls.Add(this.lblCardConceptoTitulo);
            this.pnlCardConcepto.Controls.Add(this.lblConcepto);
            this.pnlCardConcepto.Controls.Add(this.txtConcepto);
            this.pnlCardConcepto.Location = new System.Drawing.Point(10, 108);
            this.pnlCardConcepto.Name = "pnlCardConcepto";
            this.pnlCardConcepto.Size = new System.Drawing.Size(578, 68);
            this.pnlCardConcepto.TabIndex = 1;
            //
            // lblCardConceptoTitulo
            //
            this.lblCardConceptoTitulo.AutoSize = true;
            this.lblCardConceptoTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCardConceptoTitulo.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblCardConceptoTitulo.Location = new System.Drawing.Point(14, 10);
            this.lblCardConceptoTitulo.Name = "lblCardConceptoTitulo";
            this.lblCardConceptoTitulo.Size = new System.Drawing.Size(80, 13);
            this.lblCardConceptoTitulo.TabIndex = 0;
            this.lblCardConceptoTitulo.Text = "CONCEPTO";
            //
            // lblConcepto
            //
            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConcepto.Location = new System.Drawing.Point(14, 36);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(72, 15);
            this.lblConcepto.TabIndex = 1;
            this.lblConcepto.Text = "Concepto: *";
            //
            // txtConcepto
            //
            this.txtConcepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConcepto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtConcepto.Location = new System.Drawing.Point(90, 32);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(474, 26);
            this.txtConcepto.TabIndex = 2;
            //
            // pnlCardMontoCategoria
            //
            this.pnlCardMontoCategoria.BackColor = System.Drawing.Color.White;
            this.pnlCardMontoCategoria.Controls.Add(this.lblCardMCTitulo);
            this.pnlCardMontoCategoria.Controls.Add(this.lblMonto);
            this.pnlCardMontoCategoria.Controls.Add(this.numMonto);
            this.pnlCardMontoCategoria.Controls.Add(this.lblCategoria);
            this.pnlCardMontoCategoria.Controls.Add(this.cmbCategoria);
            this.pnlCardMontoCategoria.Controls.Add(this.lblTipoIGV);
            this.pnlCardMontoCategoria.Controls.Add(this.cboIGV);
            this.pnlCardMontoCategoria.Controls.Add(this.lblBaseImpHeader);
            this.pnlCardMontoCategoria.Controls.Add(this.lblIGVHeader);
            this.pnlCardMontoCategoria.Controls.Add(this.lblTotalHeader);
            this.pnlCardMontoCategoria.Controls.Add(this.txtBaseImponible);
            this.pnlCardMontoCategoria.Controls.Add(this.txtIGVGasto);
            this.pnlCardMontoCategoria.Controls.Add(this.txtGastoTotal);
            this.pnlCardMontoCategoria.Location = new System.Drawing.Point(10, 184);
            this.pnlCardMontoCategoria.Name = "pnlCardMontoCategoria";
            this.pnlCardMontoCategoria.Size = new System.Drawing.Size(578, 190);
            this.pnlCardMontoCategoria.TabIndex = 2;
            //
            // lblCardMCTitulo
            //
            this.lblCardMCTitulo.AutoSize = true;
            this.lblCardMCTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCardMCTitulo.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblCardMCTitulo.Location = new System.Drawing.Point(14, 10);
            this.lblCardMCTitulo.Name = "lblCardMCTitulo";
            this.lblCardMCTitulo.Size = new System.Drawing.Size(140, 13);
            this.lblCardMCTitulo.TabIndex = 0;
            this.lblCardMCTitulo.Text = "MONTO Y CATEGORÍA";
            //
            // lblMonto
            //
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMonto.Location = new System.Drawing.Point(14, 36);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(54, 15);
            this.lblMonto.TabIndex = 1;
            this.lblMonto.Text = "Monto: *";
            //
            // numMonto
            //
            this.numMonto.DecimalPlaces = 2;
            this.numMonto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numMonto.Location = new System.Drawing.Point(14, 54);
            this.numMonto.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            this.numMonto.Name = "numMonto";
            this.numMonto.Size = new System.Drawing.Size(268, 26);
            this.numMonto.TabIndex = 2;
            this.numMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lblCategoria
            //
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategoria.Location = new System.Drawing.Point(300, 36);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(70, 15);
            this.lblCategoria.TabIndex = 3;
            this.lblCategoria.Text = "Categoría: *";
            //
            // cmbCategoria
            //
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(300, 54);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(264, 26);
            this.cmbCategoria.TabIndex = 4;
            //
            // lblTipoIGV
            //
            this.lblTipoIGV.AutoSize = true;
            this.lblTipoIGV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipoIGV.Location = new System.Drawing.Point(14, 92);
            this.lblTipoIGV.Name = "lblTipoIGV";
            this.lblTipoIGV.Size = new System.Drawing.Size(65, 15);
            this.lblTipoIGV.TabIndex = 5;
            this.lblTipoIGV.Text = "Tipo IGV:";
            //
            // cboIGV
            //
            this.cboIGV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIGV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboIGV.FormattingEnabled = true;
            this.cboIGV.Items.AddRange(new object[] {
            "Sin IGV",
            "IGV Incluido (18%)",
            "IGV Adicional (18%)"});
            this.cboIGV.Location = new System.Drawing.Point(90, 88);
            this.cboIGV.Name = "cboIGV";
            this.cboIGV.Size = new System.Drawing.Size(190, 26);
            this.cboIGV.TabIndex = 6;
            //
            // lblBaseImpHeader
            //
            this.lblBaseImpHeader.AutoSize = true;
            this.lblBaseImpHeader.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBaseImpHeader.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblBaseImpHeader.Location = new System.Drawing.Point(14, 122);
            this.lblBaseImpHeader.Name = "lblBaseImpHeader";
            this.lblBaseImpHeader.Size = new System.Drawing.Size(90, 13);
            this.lblBaseImpHeader.TabIndex = 7;
            this.lblBaseImpHeader.Text = "Base Imp. (S/):";
            //
            // lblIGVHeader
            //
            this.lblIGVHeader.AutoSize = true;
            this.lblIGVHeader.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblIGVHeader.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblIGVHeader.Location = new System.Drawing.Point(200, 122);
            this.lblIGVHeader.Name = "lblIGVHeader";
            this.lblIGVHeader.Size = new System.Drawing.Size(55, 13);
            this.lblIGVHeader.TabIndex = 8;
            this.lblIGVHeader.Text = "IGV (S/):";
            //
            // lblTotalHeader
            //
            this.lblTotalHeader.AutoSize = true;
            this.lblTotalHeader.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalHeader.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblTotalHeader.Location = new System.Drawing.Point(390, 122);
            this.lblTotalHeader.Name = "lblTotalHeader";
            this.lblTotalHeader.Size = new System.Drawing.Size(60, 13);
            this.lblTotalHeader.TabIndex = 9;
            this.lblTotalHeader.Text = "Total (S/):";
            //
            // txtBaseImponible
            //
            this.txtBaseImponible.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.txtBaseImponible.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBaseImponible.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBaseImponible.Location = new System.Drawing.Point(14, 138);
            this.txtBaseImponible.Name = "txtBaseImponible";
            this.txtBaseImponible.ReadOnly = true;
            this.txtBaseImponible.Size = new System.Drawing.Size(168, 24);
            this.txtBaseImponible.TabIndex = 10;
            this.txtBaseImponible.Text = "0.00";
            this.txtBaseImponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // txtIGVGasto
            //
            this.txtIGVGasto.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.txtIGVGasto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIGVGasto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIGVGasto.Location = new System.Drawing.Point(196, 138);
            this.txtIGVGasto.Name = "txtIGVGasto";
            this.txtIGVGasto.ReadOnly = true;
            this.txtIGVGasto.Size = new System.Drawing.Size(168, 24);
            this.txtIGVGasto.TabIndex = 11;
            this.txtIGVGasto.Text = "0.00";
            this.txtIGVGasto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // txtGastoTotal
            //
            this.txtGastoTotal.BackColor = System.Drawing.Color.FromArgb(220, 237, 222);
            this.txtGastoTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGastoTotal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtGastoTotal.Location = new System.Drawing.Point(378, 138);
            this.txtGastoTotal.Name = "txtGastoTotal";
            this.txtGastoTotal.ReadOnly = true;
            this.txtGastoTotal.Size = new System.Drawing.Size(186, 24);
            this.txtGastoTotal.TabIndex = 12;
            this.txtGastoTotal.Text = "0.00";
            this.txtGastoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // pnlCardMetodo
            //
            this.pnlCardMetodo.BackColor = System.Drawing.Color.White;
            this.pnlCardMetodo.Controls.Add(this.lblCardMetodoTitulo);
            this.pnlCardMetodo.Controls.Add(this.lblMetodoPago);
            this.pnlCardMetodo.Controls.Add(this.cmbMetodoPago);
            this.pnlCardMetodo.Controls.Add(this.lblComprobante);
            this.pnlCardMetodo.Controls.Add(this.txtComprobante);
            this.pnlCardMetodo.Controls.Add(this.lblProveedor);
            this.pnlCardMetodo.Controls.Add(this.cmbProveedor);
            this.pnlCardMetodo.Location = new System.Drawing.Point(10, 382);
            this.pnlCardMetodo.Name = "pnlCardMetodo";
            this.pnlCardMetodo.Size = new System.Drawing.Size(578, 106);
            this.pnlCardMetodo.TabIndex = 3;
            //
            // lblCardMetodoTitulo
            //
            this.lblCardMetodoTitulo.AutoSize = true;
            this.lblCardMetodoTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCardMetodoTitulo.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblCardMetodoTitulo.Location = new System.Drawing.Point(14, 10);
            this.lblCardMetodoTitulo.Name = "lblCardMetodoTitulo";
            this.lblCardMetodoTitulo.Size = new System.Drawing.Size(240, 13);
            this.lblCardMetodoTitulo.TabIndex = 0;
            this.lblCardMetodoTitulo.Text = "MÉTODO DE PAGO Y COMPROBANTE";
            //
            // lblMetodoPago
            //
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMetodoPago.Location = new System.Drawing.Point(14, 38);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(111, 15);
            this.lblMetodoPago.TabIndex = 1;
            this.lblMetodoPago.Text = "Método de Pago: *";
            //
            // cmbMetodoPago
            //
            this.cmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Items.AddRange(new object[] {
            "EFECTIVO",
            "YAPE",
            "TRANSFERENCIA",
            "TARJETA",
            "CREDITO"});
            this.cmbMetodoPago.Location = new System.Drawing.Point(130, 34);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(190, 26);
            this.cmbMetodoPago.TabIndex = 2;
            //
            // lblComprobante
            //
            this.lblComprobante.AutoSize = true;
            this.lblComprobante.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblComprobante.Location = new System.Drawing.Point(336, 38);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(78, 15);
            this.lblComprobante.TabIndex = 3;
            this.lblComprobante.Text = "Comprobante:";
            //
            // txtComprobante
            //
            this.txtComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComprobante.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtComprobante.Location = new System.Drawing.Point(420, 34);
            this.txtComprobante.Name = "txtComprobante";
            this.txtComprobante.Size = new System.Drawing.Size(144, 26);
            this.txtComprobante.TabIndex = 4;
            //
            // lblProveedor (dentro de pnlCardMetodo)
            //
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProveedor.Location = new System.Drawing.Point(14, 76);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(72, 15);
            this.lblProveedor.TabIndex = 5;
            this.lblProveedor.Text = "Proveedor:";
            this.lblProveedor.Visible = false;
            //
            // cmbProveedor (dentro de pnlCardMetodo)
            //
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(96, 72);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(468, 26);
            this.cmbProveedor.TabIndex = 6;
            this.cmbProveedor.Visible = false;
            //
            // pnlCardObs
            //
            this.pnlCardObs.BackColor = System.Drawing.Color.White;
            this.pnlCardObs.Controls.Add(this.lblObservaciones);
            this.pnlCardObs.Controls.Add(this.txtObservaciones);
            this.pnlCardObs.Location = new System.Drawing.Point(10, 496);
            this.pnlCardObs.Name = "pnlCardObs";
            this.pnlCardObs.Size = new System.Drawing.Size(578, 72);
            this.pnlCardObs.TabIndex = 4;
            //
            // lblObservaciones
            //
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblObservaciones.Location = new System.Drawing.Point(14, 10);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(110, 13);
            this.lblObservaciones.TabIndex = 0;
            this.lblObservaciones.Text = "OBSERVACIONES";
            //
            // txtObservaciones
            //
            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtObservaciones.Location = new System.Drawing.Point(14, 30);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(550, 32);
            this.txtObservaciones.TabIndex = 1;
            //
            // FormRegistrarGasto
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
            this.ClientSize = new System.Drawing.Size(600, 716);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRegistrarGasto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Gasto";
            this.Load += new System.EventHandler(this.FormRegistrarGasto_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlCardFecha.ResumeLayout(false);
            this.pnlCardFecha.PerformLayout();
            this.pnlCardConcepto.ResumeLayout(false);
            this.pnlCardConcepto.PerformLayout();
            this.pnlCardMontoCategoria.ResumeLayout(false);
            this.pnlCardMontoCategoria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).EndInit();
            this.pnlCardMetodo.ResumeLayout(false);
            this.pnlCardMetodo.PerformLayout();
            this.pnlCardObs.ResumeLayout(false);
            this.pnlCardObs.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlCardFecha;
        private System.Windows.Forms.Label lblCardFechaTitulo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Panel pnlCardConcepto;
        private System.Windows.Forms.Label lblCardConceptoTitulo;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Panel pnlCardMontoCategoria;
        private System.Windows.Forms.Label lblCardMCTitulo;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.NumericUpDown numMonto;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Panel pnlCardMetodo;
        private System.Windows.Forms.Label lblCardMetodoTitulo;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Label lblComprobante;
        private System.Windows.Forms.TextBox txtComprobante;
        private System.Windows.Forms.Panel pnlCardObs;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblTipoIGV;
        private System.Windows.Forms.ComboBox cboIGV;
        private System.Windows.Forms.Label lblBaseImpHeader;
        private System.Windows.Forms.Label lblIGVHeader;
        private System.Windows.Forms.Label lblTotalHeader;
        private System.Windows.Forms.TextBox txtBaseImponible;
        private System.Windows.Forms.TextBox txtIGVGasto;
        private System.Windows.Forms.TextBox txtGastoTotal;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.ComboBox cmbProveedor;
    }
}
