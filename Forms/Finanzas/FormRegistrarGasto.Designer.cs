namespace SistemaPOS.Forms.Finanzas
{
    partial class FormRegistrarGasto
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlHeader        = new System.Windows.Forms.Panel();
            this.lblTitulo        = new System.Windows.Forms.Label();
            this.lblHeaderSub     = new System.Windows.Forms.Label();
            this.pnlFooter        = new System.Windows.Forms.Panel();
            this.btnGuardar       = new System.Windows.Forms.Button();
            this.btnCancelar      = new System.Windows.Forms.Button();
            this.pnlBody          = new System.Windows.Forms.Panel();
            // Card 1: Datos del Gasto
            this.pnlCardDatos     = new System.Windows.Forms.Panel();
            this.pnlHdrDatos      = new System.Windows.Forms.Panel();
            this.pnlHdrDatosAccent= new System.Windows.Forms.Panel();
            this.lblHdrDatos      = new System.Windows.Forms.Label();
            this.lblFecha         = new System.Windows.Forms.Label();
            this.dtpFecha         = new System.Windows.Forms.DateTimePicker();
            this.lblHora          = new System.Windows.Forms.Label();
            this.dtpHora          = new System.Windows.Forms.DateTimePicker();
            this.lblConcepto      = new System.Windows.Forms.Label();
            this.txtConcepto      = new System.Windows.Forms.TextBox();
            this.lblMonto         = new System.Windows.Forms.Label();
            this.numMonto         = new System.Windows.Forms.NumericUpDown();
            this.lblCategoria     = new System.Windows.Forms.Label();
            this.cmbCategoria     = new System.Windows.Forms.ComboBox();
            this.lblTipoIGV       = new System.Windows.Forms.Label();
            this.cboIGV           = new System.Windows.Forms.ComboBox();
            // IGV breakdown strip
            this.pnlIGVStrip      = new System.Windows.Forms.Panel();
            this.lblBaseImpHeader = new System.Windows.Forms.Label();
            this.txtBaseImponible = new System.Windows.Forms.TextBox();
            this.lblIGVHeader     = new System.Windows.Forms.Label();
            this.txtIGVGasto      = new System.Windows.Forms.TextBox();
            this.lblTotalHeader   = new System.Windows.Forms.Label();
            this.txtGastoTotal    = new System.Windows.Forms.TextBox();
            // Card 2: Pago y Comprobante
            this.pnlCardPago      = new System.Windows.Forms.Panel();
            this.pnlHdrPago       = new System.Windows.Forms.Panel();
            this.pnlHdrPagoAccent = new System.Windows.Forms.Panel();
            this.lblHdrPago       = new System.Windows.Forms.Label();
            this.lblMetodoPago    = new System.Windows.Forms.Label();
            this.cmbMetodoPago    = new System.Windows.Forms.ComboBox();
            this.lblComprobante   = new System.Windows.Forms.Label();
            this.txtComprobante   = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblProveedor     = new System.Windows.Forms.Label();
            this.cmbProveedor     = new System.Windows.Forms.ComboBox();

            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlCardDatos.SuspendLayout();
            this.pnlHdrDatos.SuspendLayout();
            this.pnlIGVStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).BeginInit();
            this.pnlCardPago.SuspendLayout();
            this.pnlHdrPago.SuspendLayout();
            this.SuspendLayout();

            // ═══════════════════════════════════════════════════════════════
            // pnlHeader — Indigo, 72px
            // ═══════════════════════════════════════════════════════════════
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height   = 72;
            this.pnlHeader.Name     = "pnlHeader";

            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Text      = "Registrar Gasto";

            this.lblHeaderSub.AutoSize  = true;
            this.lblHeaderSub.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(196, 196, 255);
            this.lblHeaderSub.Location  = new System.Drawing.Point(22, 42);
            this.lblHeaderSub.Name      = "lblHeaderSub";
            this.lblHeaderSub.Text      = "Complete los datos del gasto operativo";

            // ═══════════════════════════════════════════════════════════════
            // pnlFooter — White, 60px, action buttons
            // ═══════════════════════════════════════════════════════════════
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnGuardar);
            this.pnlFooter.Controls.Add(this.btnCancelar);
            this.pnlFooter.Dock     = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height   = 60;
            this.pnlFooter.Name     = "pnlFooter";

            this.btnGuardar.BackColor                         = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnGuardar.Cursor                            = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize         = 0;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(55, 48, 163);
            this.btnGuardar.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font                              = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor                         = System.Drawing.Color.White;
            this.btnGuardar.Location                          = new System.Drawing.Point(16, 14);
            this.btnGuardar.Name                              = "btnGuardar";
            this.btnGuardar.Size                              = new System.Drawing.Size(272, 34);
            this.btnGuardar.Text                              = "Guardar Gasto";
            this.btnGuardar.UseVisualStyleBackColor           = false;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);

            this.btnCancelar.BackColor                         = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnCancelar.Cursor                            = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult                      = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor        = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnCancelar.FlatAppearance.BorderSize         = 1;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnCancelar.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font                              = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor                         = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnCancelar.Location                          = new System.Drawing.Point(304, 14);
            this.btnCancelar.Name                              = "btnCancelar";
            this.btnCancelar.Size                              = new System.Drawing.Size(272, 34);
            this.btnCancelar.Text                              = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor           = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);

            // ═══════════════════════════════════════════════════════════════
            // pnlBody — Slate-50 fill
            // ═══════════════════════════════════════════════════════════════
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlBody.Controls.Add(this.pnlCardPago);
            this.pnlBody.Controls.Add(this.pnlCardDatos);
            this.pnlBody.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Name     = "pnlBody";
            this.pnlBody.Padding  = new System.Windows.Forms.Padding(16, 14, 16, 8);

            // ═══════════════════════════════════════════════════════════════
            // CARD 1 — Datos del Gasto  (white card, Y=0 within body)
            // ═══════════════════════════════════════════════════════════════
            this.pnlCardDatos.BackColor   = System.Drawing.Color.White;
            this.pnlCardDatos.Controls.Add(this.pnlHdrDatos);
            this.pnlCardDatos.Controls.Add(this.lblFecha);
            this.pnlCardDatos.Controls.Add(this.dtpFecha);
            this.pnlCardDatos.Controls.Add(this.lblHora);
            this.pnlCardDatos.Controls.Add(this.dtpHora);
            this.pnlCardDatos.Controls.Add(this.lblConcepto);
            this.pnlCardDatos.Controls.Add(this.txtConcepto);
            this.pnlCardDatos.Controls.Add(this.lblMonto);
            this.pnlCardDatos.Controls.Add(this.numMonto);
            this.pnlCardDatos.Controls.Add(this.lblCategoria);
            this.pnlCardDatos.Controls.Add(this.cmbCategoria);
            this.pnlCardDatos.Controls.Add(this.lblTipoIGV);
            this.pnlCardDatos.Controls.Add(this.cboIGV);
            this.pnlCardDatos.Controls.Add(this.pnlIGVStrip);
            this.pnlCardDatos.Location = new System.Drawing.Point(16, 14);
            this.pnlCardDatos.Name     = "pnlCardDatos";
            this.pnlCardDatos.Size     = new System.Drawing.Size(576, 308);

            // Card header with left accent
            this.pnlHdrDatos.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlHdrDatos.Controls.Add(this.pnlHdrDatosAccent);
            this.pnlHdrDatos.Controls.Add(this.lblHdrDatos);
            this.pnlHdrDatos.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHdrDatos.Height    = 40;
            this.pnlHdrDatos.Name      = "pnlHdrDatos";

            this.pnlHdrDatosAccent.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.pnlHdrDatosAccent.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlHdrDatosAccent.Name      = "pnlHdrDatosAccent";
            this.pnlHdrDatosAccent.Width     = 4;

            this.lblHdrDatos.AutoSize  = true;
            this.lblHdrDatos.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHdrDatos.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblHdrDatos.Location  = new System.Drawing.Point(18, 12);
            this.lblHdrDatos.Name      = "lblHdrDatos";
            this.lblHdrDatos.Text      = "DATOS DEL GASTO";

            // ── Fila 1: Fecha | Hora ───────────────────────────────────────
            this.lblFecha.AutoSize  = true;
            this.lblFecha.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblFecha.Location  = new System.Drawing.Point(16, 50);
            this.lblFecha.Name      = "lblFecha";
            this.lblFecha.Text      = "FECHA";

            this.dtpFecha.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFecha.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(16, 66);
            this.dtpFecha.Name     = "dtpFecha";
            this.dtpFecha.Size     = new System.Drawing.Size(256, 28);
            this.dtpFecha.TabIndex = 0;

            this.lblHora.AutoSize  = true;
            this.lblHora.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblHora.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHora.Location  = new System.Drawing.Point(286, 50);
            this.lblHora.Name      = "lblHora";
            this.lblHora.Text      = "HORA";

            this.dtpHora.CustomFormat = "HH:mm";
            this.dtpHora.Font         = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpHora.Format       = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHora.Location     = new System.Drawing.Point(286, 66);
            this.dtpHora.Name         = "dtpHora";
            this.dtpHora.ShowUpDown   = true;
            this.dtpHora.Size         = new System.Drawing.Size(274, 28);
            this.dtpHora.TabIndex     = 1;

            // ── Fila 2: Concepto ───────────────────────────────────────────
            this.lblConcepto.AutoSize  = true;
            this.lblConcepto.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblConcepto.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblConcepto.Location  = new System.Drawing.Point(16, 104);
            this.lblConcepto.Name      = "lblConcepto";
            this.lblConcepto.Text      = "CONCEPTO  *";

            this.txtConcepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConcepto.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtConcepto.Location    = new System.Drawing.Point(16, 120);
            this.txtConcepto.Name        = "txtConcepto";
            this.txtConcepto.Size        = new System.Drawing.Size(544, 28);
            this.txtConcepto.TabIndex    = 2;

            // ── Fila 3: Monto | Categoría ──────────────────────────────────
            this.lblMonto.AutoSize  = true;
            this.lblMonto.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblMonto.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblMonto.Location  = new System.Drawing.Point(16, 158);
            this.lblMonto.Name      = "lblMonto";
            this.lblMonto.Text      = "MONTO  *";

            this.numMonto.DecimalPlaces = 2;
            this.numMonto.Font          = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numMonto.Location      = new System.Drawing.Point(16, 174);
            this.numMonto.Maximum       = new decimal(new int[] { 999999, 0, 0, 0 });
            this.numMonto.Name          = "numMonto";
            this.numMonto.Size          = new System.Drawing.Size(256, 28);
            this.numMonto.TabIndex      = 3;
            this.numMonto.TextAlign     = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblCategoria.AutoSize  = true;
            this.lblCategoria.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCategoria.Location  = new System.Drawing.Point(286, 158);
            this.lblCategoria.Name      = "lblCategoria";
            this.lblCategoria.Text      = "CATEGORÍA  *";

            this.cmbCategoria.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Font              = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location          = new System.Drawing.Point(286, 174);
            this.cmbCategoria.Name              = "cmbCategoria";
            this.cmbCategoria.Size              = new System.Drawing.Size(274, 28);
            this.cmbCategoria.TabIndex          = 4;

            // ── Fila 4: Tipo IGV ───────────────────────────────────────────
            this.lblTipoIGV.AutoSize  = true;
            this.lblTipoIGV.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblTipoIGV.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTipoIGV.Location  = new System.Drawing.Point(16, 212);
            this.lblTipoIGV.Name      = "lblTipoIGV";
            this.lblTipoIGV.Text      = "TRATAMIENTO IGV";

            this.cboIGV.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIGV.Font              = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboIGV.FormattingEnabled = true;
            this.cboIGV.Items.AddRange(new object[] { "Sin IGV", "IGV Incluido (18%)", "IGV Adicional (18%)" });
            this.cboIGV.Location          = new System.Drawing.Point(16, 228);
            this.cboIGV.Name              = "cboIGV";
            this.cboIGV.Size              = new System.Drawing.Size(210, 28);
            this.cboIGV.TabIndex          = 5;

            // ── IGV Strip (3 readonly fields) ──────────────────────────────
            this.pnlIGVStrip.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlIGVStrip.Controls.Add(this.lblBaseImpHeader);
            this.pnlIGVStrip.Controls.Add(this.txtBaseImponible);
            this.pnlIGVStrip.Controls.Add(this.lblIGVHeader);
            this.pnlIGVStrip.Controls.Add(this.txtIGVGasto);
            this.pnlIGVStrip.Controls.Add(this.lblTotalHeader);
            this.pnlIGVStrip.Controls.Add(this.txtGastoTotal);
            this.pnlIGVStrip.Location = new System.Drawing.Point(0, 270);
            this.pnlIGVStrip.Name     = "pnlIGVStrip";
            this.pnlIGVStrip.Size     = new System.Drawing.Size(576, 38);

            this.lblBaseImpHeader.AutoSize  = true;
            this.lblBaseImpHeader.Font      = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.lblBaseImpHeader.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblBaseImpHeader.Location  = new System.Drawing.Point(14, 4);
            this.lblBaseImpHeader.Name      = "lblBaseImpHeader";
            this.lblBaseImpHeader.Text      = "BASE IMP. (S/)";

            this.txtBaseImponible.BackColor   = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtBaseImponible.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBaseImponible.Font        = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtBaseImponible.ForeColor   = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtBaseImponible.Location    = new System.Drawing.Point(100, 4);
            this.txtBaseImponible.Name        = "txtBaseImponible";
            this.txtBaseImponible.ReadOnly    = true;
            this.txtBaseImponible.Size        = new System.Drawing.Size(100, 22);
            this.txtBaseImponible.Text        = "0.00";
            this.txtBaseImponible.TextAlign   = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBaseImponible.TabIndex    = 6;

            this.lblIGVHeader.AutoSize  = true;
            this.lblIGVHeader.Font      = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.lblIGVHeader.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblIGVHeader.Location  = new System.Drawing.Point(216, 4);
            this.lblIGVHeader.Name      = "lblIGVHeader";
            this.lblIGVHeader.Text      = "IGV (S/)";

            this.txtIGVGasto.BackColor   = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtIGVGasto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIGVGasto.Font        = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtIGVGasto.ForeColor   = System.Drawing.Color.FromArgb(245, 158, 11);
            this.txtIGVGasto.Location    = new System.Drawing.Point(268, 4);
            this.txtIGVGasto.Name        = "txtIGVGasto";
            this.txtIGVGasto.ReadOnly    = true;
            this.txtIGVGasto.Size        = new System.Drawing.Size(90, 22);
            this.txtIGVGasto.Text        = "0.00";
            this.txtIGVGasto.TextAlign   = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIGVGasto.TabIndex    = 7;

            this.lblTotalHeader.AutoSize  = true;
            this.lblTotalHeader.Font      = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.lblTotalHeader.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.lblTotalHeader.Location  = new System.Drawing.Point(374, 4);
            this.lblTotalHeader.Name      = "lblTotalHeader";
            this.lblTotalHeader.Text      = "TOTAL (S/)";

            this.txtGastoTotal.BackColor   = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtGastoTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGastoTotal.Font        = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.txtGastoTotal.ForeColor   = System.Drawing.Color.FromArgb(79, 70, 229);
            this.txtGastoTotal.Location    = new System.Drawing.Point(444, 3);
            this.txtGastoTotal.Name        = "txtGastoTotal";
            this.txtGastoTotal.ReadOnly    = true;
            this.txtGastoTotal.Size        = new System.Drawing.Size(120, 26);
            this.txtGastoTotal.Text        = "0.00";
            this.txtGastoTotal.TextAlign   = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGastoTotal.TabIndex    = 8;

            // ═══════════════════════════════════════════════════════════════
            // CARD 2 — Pago y Comprobante
            // ═══════════════════════════════════════════════════════════════
            this.pnlCardPago.BackColor   = System.Drawing.Color.White;
            this.pnlCardPago.Controls.Add(this.pnlHdrPago);
            this.pnlCardPago.Controls.Add(this.lblMetodoPago);
            this.pnlCardPago.Controls.Add(this.cmbMetodoPago);
            this.pnlCardPago.Controls.Add(this.lblComprobante);
            this.pnlCardPago.Controls.Add(this.txtComprobante);
            this.pnlCardPago.Controls.Add(this.lblObservaciones);
            this.pnlCardPago.Controls.Add(this.txtObservaciones);
            this.pnlCardPago.Controls.Add(this.lblProveedor);
            this.pnlCardPago.Controls.Add(this.cmbProveedor);
            this.pnlCardPago.Location = new System.Drawing.Point(16, 332);
            this.pnlCardPago.Name     = "pnlCardPago";
            this.pnlCardPago.Size     = new System.Drawing.Size(576, 212);

            this.pnlHdrPago.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlHdrPago.Controls.Add(this.pnlHdrPagoAccent);
            this.pnlHdrPago.Controls.Add(this.lblHdrPago);
            this.pnlHdrPago.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHdrPago.Height    = 40;
            this.pnlHdrPago.Name      = "pnlHdrPago";

            this.pnlHdrPagoAccent.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.pnlHdrPagoAccent.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlHdrPagoAccent.Name      = "pnlHdrPagoAccent";
            this.pnlHdrPagoAccent.Width     = 4;

            this.lblHdrPago.AutoSize  = true;
            this.lblHdrPago.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHdrPago.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblHdrPago.Location  = new System.Drawing.Point(18, 12);
            this.lblHdrPago.Name      = "lblHdrPago";
            this.lblHdrPago.Text      = "MÉTODO DE PAGO Y COMPROBANTE";

            // ── Fila 1: Método | Comprobante ─────────────────────────────
            this.lblMetodoPago.AutoSize  = true;
            this.lblMetodoPago.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblMetodoPago.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblMetodoPago.Location  = new System.Drawing.Point(16, 50);
            this.lblMetodoPago.Name      = "lblMetodoPago";
            this.lblMetodoPago.Text      = "MÉTODO  *";

            this.cmbMetodoPago.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPago.Font              = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Items.AddRange(new object[] { "EFECTIVO", "YAPE", "TRANSFERENCIA", "TARJETA", "CREDITO" });
            this.cmbMetodoPago.Location          = new System.Drawing.Point(16, 66);
            this.cmbMetodoPago.Name              = "cmbMetodoPago";
            this.cmbMetodoPago.Size              = new System.Drawing.Size(256, 28);
            this.cmbMetodoPago.TabIndex          = 0;

            this.lblComprobante.AutoSize  = true;
            this.lblComprobante.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblComprobante.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblComprobante.Location  = new System.Drawing.Point(286, 50);
            this.lblComprobante.Name      = "lblComprobante";
            this.lblComprobante.Text      = "COMPROBANTE";

            this.txtComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComprobante.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtComprobante.Location    = new System.Drawing.Point(286, 66);
            this.txtComprobante.Name        = "txtComprobante";
            this.txtComprobante.Size        = new System.Drawing.Size(274, 28);
            this.txtComprobante.TabIndex    = 1;

            // ── Fila 2: Observaciones ────────────────────────────────────
            this.lblObservaciones.AutoSize  = true;
            this.lblObservaciones.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblObservaciones.Location  = new System.Drawing.Point(16, 104);
            this.lblObservaciones.Name      = "lblObservaciones";
            this.lblObservaciones.Text      = "OBSERVACIONES";

            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservaciones.Font        = new System.Drawing.Font("Segoe UI", 9F);
            this.txtObservaciones.Location    = new System.Drawing.Point(16, 120);
            this.txtObservaciones.Multiline   = true;
            this.txtObservaciones.Name        = "txtObservaciones";
            this.txtObservaciones.Size        = new System.Drawing.Size(544, 36);
            this.txtObservaciones.TabIndex    = 2;

            // ── Fila 3: Proveedor (CREDITO — hidden by default) ──────────
            this.lblProveedor.AutoSize  = true;
            this.lblProveedor.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblProveedor.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblProveedor.Location  = new System.Drawing.Point(16, 164);
            this.lblProveedor.Name      = "lblProveedor";
            this.lblProveedor.Text      = "PROVEEDOR (para crédito)";
            this.lblProveedor.Visible   = false;

            this.cmbProveedor.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.Font              = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location          = new System.Drawing.Point(16, 180);
            this.cmbProveedor.Name              = "cmbProveedor";
            this.cmbProveedor.Size              = new System.Drawing.Size(544, 28);
            this.cmbProveedor.TabIndex          = 3;
            this.cmbProveedor.Visible           = false;

            // ═══════════════════════════════════════════════════════════════
            // FormRegistrarGasto
            // ═══════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize          = new System.Drawing.Size(608, 634);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.Name            = "FormRegistrarGasto";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Registrar Gasto";
            this.Load += new System.EventHandler(this.FormRegistrarGasto_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlHdrDatos.ResumeLayout(false);
            this.pnlHdrDatos.PerformLayout();
            this.pnlIGVStrip.ResumeLayout(false);
            this.pnlIGVStrip.PerformLayout();
            this.pnlCardDatos.ResumeLayout(false);
            this.pnlCardDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).EndInit();
            this.pnlHdrPago.ResumeLayout(false);
            this.pnlHdrPago.PerformLayout();
            this.pnlCardPago.ResumeLayout(false);
            this.pnlCardPago.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel          pnlHeader;
        private System.Windows.Forms.Label          lblTitulo;
        private System.Windows.Forms.Label          lblHeaderSub;
        private System.Windows.Forms.Panel          pnlFooter;
        private System.Windows.Forms.Button         btnGuardar;
        private System.Windows.Forms.Button         btnCancelar;
        private System.Windows.Forms.Panel          pnlBody;
        // Card 1
        private System.Windows.Forms.Panel          pnlCardDatos;
        private System.Windows.Forms.Panel          pnlHdrDatos;
        private System.Windows.Forms.Panel          pnlHdrDatosAccent;
        private System.Windows.Forms.Label          lblHdrDatos;
        private System.Windows.Forms.Label          lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label          lblHora;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Label          lblConcepto;
        private System.Windows.Forms.TextBox        txtConcepto;
        private System.Windows.Forms.Label          lblMonto;
        private System.Windows.Forms.NumericUpDown  numMonto;
        private System.Windows.Forms.Label          lblCategoria;
        private System.Windows.Forms.ComboBox       cmbCategoria;
        private System.Windows.Forms.Label          lblTipoIGV;
        private System.Windows.Forms.ComboBox       cboIGV;
        private System.Windows.Forms.Panel          pnlIGVStrip;
        private System.Windows.Forms.Label          lblBaseImpHeader;
        private System.Windows.Forms.TextBox        txtBaseImponible;
        private System.Windows.Forms.Label          lblIGVHeader;
        private System.Windows.Forms.TextBox        txtIGVGasto;
        private System.Windows.Forms.Label          lblTotalHeader;
        private System.Windows.Forms.TextBox        txtGastoTotal;
        // Card 2
        private System.Windows.Forms.Panel          pnlCardPago;
        private System.Windows.Forms.Panel          pnlHdrPago;
        private System.Windows.Forms.Panel          pnlHdrPagoAccent;
        private System.Windows.Forms.Label          lblHdrPago;
        private System.Windows.Forms.Label          lblMetodoPago;
        private System.Windows.Forms.ComboBox       cmbMetodoPago;
        private System.Windows.Forms.Label          lblComprobante;
        private System.Windows.Forms.TextBox        txtComprobante;
        private System.Windows.Forms.Label          lblObservaciones;
        private System.Windows.Forms.TextBox        txtObservaciones;
        private System.Windows.Forms.Label          lblProveedor;
        private System.Windows.Forms.ComboBox       cmbProveedor;
    }
}
