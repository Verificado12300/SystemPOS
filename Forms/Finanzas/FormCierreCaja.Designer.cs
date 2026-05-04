namespace SistemaPOS.Forms.Finanzas
{
    partial class FormCierreCaja
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // ── Declarations ──────────────────────────────────────────────────
            this.pnlCierreHeader     = new System.Windows.Forms.Panel();
            this.lblCierreTitulo     = new System.Windows.Forms.Label();
            this.lblPasoIndicador    = new System.Windows.Forms.Label();

            // Paso 1 – Moneteo
            this.pnlPaso1            = new System.Windows.Forms.Panel();
            this.pnlPaso1Top         = new System.Windows.Forms.Panel();
            this.lblPaso1Titulo      = new System.Windows.Forms.Label();
            this.pnlPaso1Buttons     = new System.Windows.Forms.Panel();
            this.btnPaso1Cancelar    = new System.Windows.Forms.Button();
            this.btnPaso1Siguiente   = new System.Windows.Forms.Button();
            this.pnlMoneteoWrapper   = new System.Windows.Forms.Panel();
            this.pnlMoneteoTotal     = new System.Windows.Forms.Panel();
            this.lblMoneteoTotalTxt  = new System.Windows.Forms.Label();
            this.lblMoneteoTotalMonto = new System.Windows.Forms.Label();
            this.dgvMoneteo          = new System.Windows.Forms.DataGridView();
            this.colMonDenominacion  = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonCantidad      = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonSubtotal      = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // Paso 2 – Verificación
            this.pnlPaso2            = new System.Windows.Forms.Panel();
            this.pnlPaso2Top         = new System.Windows.Forms.Panel();
            this.lblPaso2Titulo      = new System.Windows.Forms.Label();
            this.pnlPaso2Buttons     = new System.Windows.Forms.Panel();
            this.chkImprimirCierre   = new System.Windows.Forms.CheckBox();
            this.btnPaso2Atras       = new System.Windows.Forms.Button();
            this.btnPaso2Confirmar   = new System.Windows.Forms.Button();
            this.pnlResumenWrapper   = new System.Windows.Forms.Panel();
            this.pnlResumenContent   = new System.Windows.Forms.Panel();
            this.lblResVentasTxt     = new System.Windows.Forms.Label();
            this.lblResVentasVal     = new System.Windows.Forms.Label();
            this.lblResEfectivoTxt   = new System.Windows.Forms.Label();
            this.lblResEfectivoVal   = new System.Windows.Forms.Label();
            this.lblResYapeTxt       = new System.Windows.Forms.Label();
            this.lblResYapeVal       = new System.Windows.Forms.Label();
            this.lblResTransferenciaTxt = new System.Windows.Forms.Label();
            this.lblResTransferenciaVal = new System.Windows.Forms.Label();
            this.lblResCreditoTxt    = new System.Windows.Forms.Label();
            this.lblResCreditoVal    = new System.Windows.Forms.Label();
            this.lblResGastosTxt     = new System.Windows.Forms.Label();
            this.lblResGastosVal     = new System.Windows.Forms.Label();
            this.lblResSep1          = new System.Windows.Forms.Label();
            this.lblResArqueoTitulo  = new System.Windows.Forms.Label();
            this.lblResFondoTxt      = new System.Windows.Forms.Label();
            this.lblResFondoVal      = new System.Windows.Forms.Label();
            this.lblResEsperadoTxt   = new System.Windows.Forms.Label();
            this.lblResEsperadoVal   = new System.Windows.Forms.Label();
            this.lblResMoneteoTxt    = new System.Windows.Forms.Label();
            this.lblResMoneteoVal    = new System.Windows.Forms.Label();
            this.lblResSep2          = new System.Windows.Forms.Label();
            this.lblResDiferenciaTxt = new System.Windows.Forms.Label();
            this.lblResDiferenciaVal = new System.Windows.Forms.Label();
            this.lblResObsTxt        = new System.Windows.Forms.Label();
            this.txtObservacionCierre = new System.Windows.Forms.TextBox();
            this.lblSecVentas         = new System.Windows.Forms.Label();

            // Paso 3 – Confirmación
            this.pnlPaso3               = new System.Windows.Forms.Panel();
            this.lblPaso3Icono          = new System.Windows.Forms.Label();
            this.lblPaso3Titulo         = new System.Windows.Forms.Label();
            this.lblPaso3Sub            = new System.Windows.Forms.Label();
            this.lblResumenFinalTurno   = new System.Windows.Forms.Label();
            this.lblResumenFinalTotal   = new System.Windows.Forms.Label();
            this.lblResumenFinalDuracion = new System.Windows.Forms.Label();
            this.btnPaso3Cerrar         = new System.Windows.Forms.Button();

            // ── SuspendLayouts ────────────────────────────────────────────────
            this.pnlCierreHeader.SuspendLayout();
            this.pnlPaso1.SuspendLayout();
            this.pnlPaso1Top.SuspendLayout();
            this.pnlPaso1Buttons.SuspendLayout();
            this.pnlMoneteoWrapper.SuspendLayout();
            this.pnlMoneteoTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoneteo)).BeginInit();
            this.pnlPaso2.SuspendLayout();
            this.pnlPaso2Top.SuspendLayout();
            this.pnlPaso2Buttons.SuspendLayout();
            this.pnlResumenWrapper.SuspendLayout();
            this.pnlResumenContent.SuspendLayout();
            this.pnlPaso3.SuspendLayout();
            this.SuspendLayout();

            // ══════════════════════════════════════════════════════════════════
            // CIERRE HEADER
            // ══════════════════════════════════════════════════════════════════
            this.pnlCierreHeader.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.pnlCierreHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlCierreHeader.Height    = 68;
            this.pnlCierreHeader.Name      = "pnlCierreHeader";

            this.lblCierreTitulo.AutoSize  = true;
            this.lblCierreTitulo.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCierreTitulo.ForeColor = System.Drawing.Color.White;
            this.lblCierreTitulo.Location  = new System.Drawing.Point(20, 10);
            this.lblCierreTitulo.Text      = "Cierre de Turno";

            this.lblPasoIndicador.AutoSize  = true;
            this.lblPasoIndicador.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPasoIndicador.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.lblPasoIndicador.Location  = new System.Drawing.Point(22, 38);
            this.lblPasoIndicador.Name      = "lblPasoIndicador";
            this.lblPasoIndicador.Text      = "Paso 1 de 3  —  Conteo de Efectivo (Moneteo)";

            this.pnlCierreHeader.Controls.Add(this.lblPasoIndicador);
            this.pnlCierreHeader.Controls.Add(this.lblCierreTitulo);

            // ══════════════════════════════════════════════════════════════════
            // PASO 1 – MONETEO
            // ══════════════════════════════════════════════════════════════════
            this.pnlPaso1.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.pnlPaso1.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlPaso1.Name      = "pnlPaso1";
            this.pnlPaso1.Visible   = true;

            // Top label
            this.pnlPaso1Top.BackColor   = System.Drawing.Color.White;
            this.pnlPaso1Top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPaso1Top.Dock        = System.Windows.Forms.DockStyle.Top;
            this.pnlPaso1Top.Height      = 46;
            this.pnlPaso1Top.Name        = "pnlPaso1Top";

            this.lblPaso1Titulo.AutoSize  = true;
            this.lblPaso1Titulo.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPaso1Titulo.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblPaso1Titulo.Location  = new System.Drawing.Point(16, 13);
            this.lblPaso1Titulo.Text      = "Ingrese la cantidad de cada denominación para calcular el total en caja";

            this.pnlPaso1Top.Controls.Add(this.lblPaso1Titulo);

            // Buttons
            this.pnlPaso1Buttons.BackColor   = System.Drawing.Color.White;
            this.pnlPaso1Buttons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPaso1Buttons.Dock        = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPaso1Buttons.Height      = 54;
            this.pnlPaso1Buttons.Name        = "pnlPaso1Buttons";

            this.btnPaso1Cancelar.BackColor         = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnPaso1Cancelar.FlatAppearance.BorderSize = 0;
            this.btnPaso1Cancelar.FlatStyle         = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaso1Cancelar.Font              = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPaso1Cancelar.ForeColor         = System.Drawing.Color.White;
            this.btnPaso1Cancelar.Location          = new System.Drawing.Point(10, 11);
            this.btnPaso1Cancelar.Name              = "btnPaso1Cancelar";
            this.btnPaso1Cancelar.Size              = new System.Drawing.Size(120, 32);
            this.btnPaso1Cancelar.Text              = "← Cancelar";
            this.btnPaso1Cancelar.Cursor            = System.Windows.Forms.Cursors.Hand;

            this.btnPaso1Siguiente.BackColor         = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnPaso1Siguiente.FlatAppearance.BorderSize = 0;
            this.btnPaso1Siguiente.FlatStyle         = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaso1Siguiente.Font              = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPaso1Siguiente.ForeColor         = System.Drawing.Color.White;
            this.btnPaso1Siguiente.Location          = new System.Drawing.Point(590, 11);
            this.btnPaso1Siguiente.Name              = "btnPaso1Siguiente";
            this.btnPaso1Siguiente.Size              = new System.Drawing.Size(110, 32);
            this.btnPaso1Siguiente.Text              = "Siguiente →";
            this.btnPaso1Siguiente.Cursor            = System.Windows.Forms.Cursors.Hand;

            this.pnlPaso1Buttons.Controls.Add(this.btnPaso1Siguiente);
            this.pnlPaso1Buttons.Controls.Add(this.btnPaso1Cancelar);

            // Moneteo wrapper
            this.pnlMoneteoWrapper.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.pnlMoneteoWrapper.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlMoneteoWrapper.Name      = "pnlMoneteoWrapper";
            this.pnlMoneteoWrapper.Padding   = new System.Windows.Forms.Padding(12, 8, 12, 8);

            // Total indicator
            this.pnlMoneteoTotal.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.pnlMoneteoTotal.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlMoneteoTotal.Height    = 44;
            this.pnlMoneteoTotal.Name      = "pnlMoneteoTotal";

            this.lblMoneteoTotalTxt.AutoSize  = true;
            this.lblMoneteoTotalTxt.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMoneteoTotalTxt.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.lblMoneteoTotalTxt.Location  = new System.Drawing.Point(12, 14);
            this.lblMoneteoTotalTxt.Text      = "TOTAL CONTADO:";

            this.lblMoneteoTotalMonto.AutoSize  = true;
            this.lblMoneteoTotalMonto.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblMoneteoTotalMonto.ForeColor = System.Drawing.Color.White;
            this.lblMoneteoTotalMonto.Location  = new System.Drawing.Point(140, 9);
            this.lblMoneteoTotalMonto.Name      = "lblMoneteoTotalMonto";
            this.lblMoneteoTotalMonto.Text      = "S/ 0.00";

            this.pnlMoneteoTotal.Controls.Add(this.lblMoneteoTotalMonto);
            this.pnlMoneteoTotal.Controls.Add(this.lblMoneteoTotalTxt);

            // DGV Moneteo
            this.dgvMoneteo.BackgroundColor  = System.Drawing.Color.White;
            this.dgvMoneteo.BorderStyle       = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvMoneteo.Dock              = System.Windows.Forms.DockStyle.Fill;
            this.dgvMoneteo.Name              = "dgvMoneteo";
            this.dgvMoneteo.ReadOnly          = false;
            this.dgvMoneteo.AllowUserToAddRows = false;
            this.dgvMoneteo.RowHeadersVisible  = false;
            this.dgvMoneteo.SelectionMode      = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMoneteo.GridColor          = System.Drawing.Color.FromArgb(235, 237, 240);
            this.dgvMoneteo.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvMoneteo.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.dgvMoneteo.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMoneteo.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvMoneteo.ColumnHeadersHeight = 32;
            this.dgvMoneteo.EnableHeadersVisualStyles = false;
            this.dgvMoneteo.RowTemplate.Height = 34;
            this.dgvMoneteo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colMonDenominacion, this.colMonCantidad, this.colMonSubtotal });

            this.colMonDenominacion.HeaderText = "Denominación";  this.colMonDenominacion.Name = "colMonDenominacion"; this.colMonDenominacion.Width = 220; this.colMonDenominacion.ReadOnly = true;
            this.colMonDenominacion.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colMonCantidad.HeaderText = "Cantidad";          this.colMonCantidad.Name = "colMonCantidad";         this.colMonCantidad.Width = 160;
            this.colMonCantidad.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colMonSubtotal.HeaderText = "Subtotal";          this.colMonSubtotal.Name = "colMonSubtotal";         this.colMonSubtotal.ReadOnly = true;
            this.colMonSubtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMonSubtotal.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.pnlMoneteoWrapper.Controls.Add(this.dgvMoneteo);
            this.pnlMoneteoWrapper.Controls.Add(this.pnlMoneteoTotal);

            this.pnlPaso1.Controls.Add(this.pnlMoneteoWrapper);
            this.pnlPaso1.Controls.Add(this.pnlPaso1Buttons);
            this.pnlPaso1.Controls.Add(this.pnlPaso1Top);

            // ══════════════════════════════════════════════════════════════════
            // PASO 2 – VERIFICACIÓN
            // ══════════════════════════════════════════════════════════════════
            this.pnlPaso2.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.pnlPaso2.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlPaso2.Name      = "pnlPaso2";
            this.pnlPaso2.Visible   = false;

            this.pnlPaso2Top.BackColor   = System.Drawing.Color.White;
            this.pnlPaso2Top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPaso2Top.Dock        = System.Windows.Forms.DockStyle.Top;
            this.pnlPaso2Top.Height      = 46;
            this.pnlPaso2Top.Name        = "pnlPaso2Top";

            this.lblPaso2Titulo.AutoSize  = true;
            this.lblPaso2Titulo.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPaso2Titulo.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblPaso2Titulo.Location  = new System.Drawing.Point(16, 13);
            this.lblPaso2Titulo.Text      = "Verifique los datos del turno antes de confirmar el cierre";

            this.pnlPaso2Top.Controls.Add(this.lblPaso2Titulo);

            // Buttons
            this.pnlPaso2Buttons.BackColor   = System.Drawing.Color.White;
            this.pnlPaso2Buttons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPaso2Buttons.Dock        = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPaso2Buttons.Height      = 54;
            this.pnlPaso2Buttons.Name        = "pnlPaso2Buttons";

            this.chkImprimirCierre.AutoSize  = true;
            this.chkImprimirCierre.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.chkImprimirCierre.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.chkImprimirCierre.Location  = new System.Drawing.Point(10, 18);
            this.chkImprimirCierre.Name      = "chkImprimirCierre";
            this.chkImprimirCierre.Text      = "Imprimir comprobante de cierre";

            this.btnPaso2Atras.BackColor         = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnPaso2Atras.FlatAppearance.BorderSize = 0;
            this.btnPaso2Atras.FlatStyle         = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaso2Atras.Font              = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPaso2Atras.ForeColor         = System.Drawing.Color.White;
            this.btnPaso2Atras.Location          = new System.Drawing.Point(502, 11);
            this.btnPaso2Atras.Name              = "btnPaso2Atras";
            this.btnPaso2Atras.Size              = new System.Drawing.Size(90, 32);
            this.btnPaso2Atras.Text              = "← Atrás";
            this.btnPaso2Atras.Cursor            = System.Windows.Forms.Cursors.Hand;

            this.btnPaso2Confirmar.BackColor         = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnPaso2Confirmar.FlatAppearance.BorderSize = 0;
            this.btnPaso2Confirmar.FlatStyle         = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaso2Confirmar.Font              = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPaso2Confirmar.ForeColor         = System.Drawing.Color.White;
            this.btnPaso2Confirmar.Location          = new System.Drawing.Point(604, 11);
            this.btnPaso2Confirmar.Name              = "btnPaso2Confirmar";
            this.btnPaso2Confirmar.Size              = new System.Drawing.Size(106, 32);
            this.btnPaso2Confirmar.Text              = "Confirmar ✓";
            this.btnPaso2Confirmar.Cursor            = System.Windows.Forms.Cursors.Hand;

            this.pnlPaso2Buttons.Controls.Add(this.btnPaso2Confirmar);
            this.pnlPaso2Buttons.Controls.Add(this.btnPaso2Atras);
            this.pnlPaso2Buttons.Controls.Add(this.chkImprimirCierre);

            // Resumen wrapper
            this.pnlResumenWrapper.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.pnlResumenWrapper.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlResumenWrapper.Name      = "pnlResumenWrapper";
            this.pnlResumenWrapper.Padding   = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlResumenWrapper.AutoScroll = true;

            // Resumen content panel
            this.pnlResumenContent.BackColor   = System.Drawing.Color.White;
            this.pnlResumenContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResumenContent.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.pnlResumenContent.Name        = "pnlResumenContent";
            this.pnlResumenContent.Padding     = new System.Windows.Forms.Padding(20, 12, 20, 12);

            this.lblSecVentas.AutoSize  = false;
            this.lblSecVentas.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSecVentas.ForeColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.lblSecVentas.Location  = new System.Drawing.Point(20, 14);
            this.lblSecVentas.Name      = "lblSecVentas";
            this.lblSecVentas.Size      = new System.Drawing.Size(300, 18);
            this.lblSecVentas.Text      = "VENTAS DEL TURNO";
            this.pnlResumenContent.Controls.Add(this.lblSecVentas);

            this.lblResVentasTxt.AutoSize  = false;
            this.lblResVentasTxt.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblResVentasTxt.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResVentasTxt.Location  = new System.Drawing.Point(20, 36);
            this.lblResVentasTxt.Name      = "lblResVentasTxt";
            this.lblResVentasTxt.Size      = new System.Drawing.Size(300, 22);
            this.lblResVentasTxt.Text      = "Total Ventas:";
            this.lblResVentasVal.AutoSize  = false;
            this.lblResVentasVal.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblResVentasVal.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResVentasVal.Location  = new System.Drawing.Point(400, 36);
            this.lblResVentasVal.Name      = "lblResVentasVal";
            this.lblResVentasVal.Size      = new System.Drawing.Size(180, 22);
            this.lblResVentasVal.Text      = "S/ 0.00";
            this.lblResVentasVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pnlResumenContent.Controls.Add(this.lblResVentasTxt);
            this.pnlResumenContent.Controls.Add(this.lblResVentasVal);

            this.lblResEfectivoTxt.AutoSize  = false;
            this.lblResEfectivoTxt.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblResEfectivoTxt.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResEfectivoTxt.Location  = new System.Drawing.Point(20, 62);
            this.lblResEfectivoTxt.Name      = "lblResEfectivoTxt";
            this.lblResEfectivoTxt.Size      = new System.Drawing.Size(300, 22);
            this.lblResEfectivoTxt.Text      = "  Efectivo:";
            this.lblResEfectivoVal.AutoSize  = false;
            this.lblResEfectivoVal.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblResEfectivoVal.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResEfectivoVal.Location  = new System.Drawing.Point(400, 62);
            this.lblResEfectivoVal.Name      = "lblResEfectivoVal";
            this.lblResEfectivoVal.Size      = new System.Drawing.Size(180, 22);
            this.lblResEfectivoVal.Text      = "S/ 0.00";
            this.lblResEfectivoVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pnlResumenContent.Controls.Add(this.lblResEfectivoTxt);
            this.pnlResumenContent.Controls.Add(this.lblResEfectivoVal);

            this.lblResYapeTxt.AutoSize  = false;
            this.lblResYapeTxt.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblResYapeTxt.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResYapeTxt.Location  = new System.Drawing.Point(20, 88);
            this.lblResYapeTxt.Name      = "lblResYapeTxt";
            this.lblResYapeTxt.Size      = new System.Drawing.Size(300, 22);
            this.lblResYapeTxt.Text      = "  Yape:";
            this.lblResYapeVal.AutoSize  = false;
            this.lblResYapeVal.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblResYapeVal.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResYapeVal.Location  = new System.Drawing.Point(400, 88);
            this.lblResYapeVal.Name      = "lblResYapeVal";
            this.lblResYapeVal.Size      = new System.Drawing.Size(180, 22);
            this.lblResYapeVal.Text      = "S/ 0.00";
            this.lblResYapeVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pnlResumenContent.Controls.Add(this.lblResYapeTxt);
            this.pnlResumenContent.Controls.Add(this.lblResYapeVal);

            this.lblResTransferenciaTxt.AutoSize  = false;
            this.lblResTransferenciaTxt.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblResTransferenciaTxt.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResTransferenciaTxt.Location  = new System.Drawing.Point(20, 114);
            this.lblResTransferenciaTxt.Name      = "lblResTransferenciaTxt";
            this.lblResTransferenciaTxt.Size      = new System.Drawing.Size(300, 22);
            this.lblResTransferenciaTxt.Text      = "  Transferencia:";
            this.lblResTransferenciaVal.AutoSize  = false;
            this.lblResTransferenciaVal.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblResTransferenciaVal.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResTransferenciaVal.Location  = new System.Drawing.Point(400, 114);
            this.lblResTransferenciaVal.Name      = "lblResTransferenciaVal";
            this.lblResTransferenciaVal.Size      = new System.Drawing.Size(180, 22);
            this.lblResTransferenciaVal.Text      = "S/ 0.00";
            this.lblResTransferenciaVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pnlResumenContent.Controls.Add(this.lblResTransferenciaTxt);
            this.pnlResumenContent.Controls.Add(this.lblResTransferenciaVal);

            this.lblResCreditoTxt.AutoSize  = false;
            this.lblResCreditoTxt.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblResCreditoTxt.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResCreditoTxt.Location  = new System.Drawing.Point(20, 140);
            this.lblResCreditoTxt.Name      = "lblResCreditoTxt";
            this.lblResCreditoTxt.Size      = new System.Drawing.Size(300, 22);
            this.lblResCreditoTxt.Text      = "  Crédito:";
            this.lblResCreditoVal.AutoSize  = false;
            this.lblResCreditoVal.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblResCreditoVal.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResCreditoVal.Location  = new System.Drawing.Point(400, 140);
            this.lblResCreditoVal.Name      = "lblResCreditoVal";
            this.lblResCreditoVal.Size      = new System.Drawing.Size(180, 22);
            this.lblResCreditoVal.Text      = "S/ 0.00";
            this.lblResCreditoVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pnlResumenContent.Controls.Add(this.lblResCreditoTxt);
            this.pnlResumenContent.Controls.Add(this.lblResCreditoVal);

            this.lblResSep1.BackColor = System.Drawing.Color.FromArgb(220, 221, 225);
            this.lblResSep1.AutoSize  = false;
            this.lblResSep1.Location  = new System.Drawing.Point(20, 168);
            this.lblResSep1.Name      = "lblResSep1";
            this.lblResSep1.Size      = new System.Drawing.Size(560, 1);
            this.pnlResumenContent.Controls.Add(this.lblResSep1);

            this.lblResGastosTxt.AutoSize  = false;
            this.lblResGastosTxt.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblResGastosTxt.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResGastosTxt.Location  = new System.Drawing.Point(20, 176);
            this.lblResGastosTxt.Name      = "lblResGastosTxt";
            this.lblResGastosTxt.Size      = new System.Drawing.Size(300, 22);
            this.lblResGastosTxt.Text      = "Gastos en Efectivo:";
            this.lblResGastosVal.AutoSize  = false;
            this.lblResGastosVal.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblResGastosVal.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblResGastosVal.Location  = new System.Drawing.Point(400, 176);
            this.lblResGastosVal.Name      = "lblResGastosVal";
            this.lblResGastosVal.Size      = new System.Drawing.Size(180, 22);
            this.lblResGastosVal.Text      = "S/ 0.00";
            this.lblResGastosVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pnlResumenContent.Controls.Add(this.lblResGastosTxt);
            this.pnlResumenContent.Controls.Add(this.lblResGastosVal);

            this.lblResArqueoTitulo.AutoSize  = false;
            this.lblResArqueoTitulo.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblResArqueoTitulo.ForeColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.lblResArqueoTitulo.Location  = new System.Drawing.Point(20, 216);
            this.lblResArqueoTitulo.Name      = "lblResArqueoTitulo";
            this.lblResArqueoTitulo.Size      = new System.Drawing.Size(300, 18);
            this.lblResArqueoTitulo.Text      = "ARQUEO DE EFECTIVO";
            this.pnlResumenContent.Controls.Add(this.lblResArqueoTitulo);

            this.lblResFondoTxt.AutoSize  = false;
            this.lblResFondoTxt.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblResFondoTxt.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResFondoTxt.Location  = new System.Drawing.Point(20, 238);
            this.lblResFondoTxt.Name      = "lblResFondoTxt";
            this.lblResFondoTxt.Size      = new System.Drawing.Size(300, 22);
            this.lblResFondoTxt.Text      = "Fondo Inicial:";
            this.lblResFondoVal.AutoSize  = false;
            this.lblResFondoVal.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblResFondoVal.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResFondoVal.Location  = new System.Drawing.Point(400, 238);
            this.lblResFondoVal.Name      = "lblResFondoVal";
            this.lblResFondoVal.Size      = new System.Drawing.Size(180, 22);
            this.lblResFondoVal.Text      = "S/ 0.00";
            this.lblResFondoVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pnlResumenContent.Controls.Add(this.lblResFondoTxt);
            this.pnlResumenContent.Controls.Add(this.lblResFondoVal);

            this.lblResEsperadoTxt.AutoSize  = false;
            this.lblResEsperadoTxt.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblResEsperadoTxt.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResEsperadoTxt.Location  = new System.Drawing.Point(20, 264);
            this.lblResEsperadoTxt.Name      = "lblResEsperadoTxt";
            this.lblResEsperadoTxt.Size      = new System.Drawing.Size(300, 22);
            this.lblResEsperadoTxt.Text      = "Efectivo Esperado:";
            this.lblResEsperadoVal.AutoSize  = false;
            this.lblResEsperadoVal.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblResEsperadoVal.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResEsperadoVal.Location  = new System.Drawing.Point(400, 264);
            this.lblResEsperadoVal.Name      = "lblResEsperadoVal";
            this.lblResEsperadoVal.Size      = new System.Drawing.Size(180, 22);
            this.lblResEsperadoVal.Text      = "S/ 0.00";
            this.lblResEsperadoVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pnlResumenContent.Controls.Add(this.lblResEsperadoTxt);
            this.pnlResumenContent.Controls.Add(this.lblResEsperadoVal);

            this.lblResMoneteoTxt.AutoSize  = false;
            this.lblResMoneteoTxt.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblResMoneteoTxt.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResMoneteoTxt.Location  = new System.Drawing.Point(20, 290);
            this.lblResMoneteoTxt.Name      = "lblResMoneteoTxt";
            this.lblResMoneteoTxt.Size      = new System.Drawing.Size(300, 22);
            this.lblResMoneteoTxt.Text      = "Efectivo Real (contado):";
            this.lblResMoneteoVal.AutoSize  = false;
            this.lblResMoneteoVal.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblResMoneteoVal.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResMoneteoVal.Location  = new System.Drawing.Point(400, 290);
            this.lblResMoneteoVal.Name      = "lblResMoneteoVal";
            this.lblResMoneteoVal.Size      = new System.Drawing.Size(180, 22);
            this.lblResMoneteoVal.Text      = "S/ 0.00";
            this.lblResMoneteoVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pnlResumenContent.Controls.Add(this.lblResMoneteoTxt);
            this.pnlResumenContent.Controls.Add(this.lblResMoneteoVal);

            this.lblResSep2.BackColor = System.Drawing.Color.FromArgb(220, 221, 225);
            this.lblResSep2.AutoSize  = false;
            this.lblResSep2.Location  = new System.Drawing.Point(20, 318);
            this.lblResSep2.Name      = "lblResSep2";
            this.lblResSep2.Size      = new System.Drawing.Size(560, 1);
            this.pnlResumenContent.Controls.Add(this.lblResSep2);

            this.lblResDiferenciaTxt.AutoSize  = false;
            this.lblResDiferenciaTxt.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblResDiferenciaTxt.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResDiferenciaTxt.Location  = new System.Drawing.Point(20, 326);
            this.lblResDiferenciaTxt.Name      = "lblResDiferenciaTxt";
            this.lblResDiferenciaTxt.Size      = new System.Drawing.Size(300, 24);
            this.lblResDiferenciaTxt.Text      = "Diferencia:";
            this.lblResDiferenciaVal.AutoSize  = false;
            this.lblResDiferenciaVal.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblResDiferenciaVal.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblResDiferenciaVal.Location  = new System.Drawing.Point(400, 324);
            this.lblResDiferenciaVal.Name      = "lblResDiferenciaVal";
            this.lblResDiferenciaVal.Size      = new System.Drawing.Size(180, 28);
            this.lblResDiferenciaVal.Text      = "S/ 0.00";
            this.lblResDiferenciaVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pnlResumenContent.Controls.Add(this.lblResDiferenciaTxt);
            this.pnlResumenContent.Controls.Add(this.lblResDiferenciaVal);

            this.lblResObsTxt.AutoSize  = false;
            this.lblResObsTxt.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblResObsTxt.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblResObsTxt.Location  = new System.Drawing.Point(20, 362);
            this.lblResObsTxt.Name      = "lblResObsTxt";
            this.lblResObsTxt.Size      = new System.Drawing.Size(300, 20);
            this.lblResObsTxt.Text      = "Observación (requerida por diferencia):";
            this.lblResObsTxt.Visible   = false;
            this.pnlResumenContent.Controls.Add(this.lblResObsTxt);

            this.txtObservacionCierre.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtObservacionCierre.Location = new System.Drawing.Point(20, 386);
            this.txtObservacionCierre.Name     = "txtObservacionCierre";
            this.txtObservacionCierre.Size     = new System.Drawing.Size(560, 23);
            this.txtObservacionCierre.Visible  = false;
            this.pnlResumenContent.Controls.Add(this.txtObservacionCierre);

            this.pnlResumenWrapper.Controls.Add(this.pnlResumenContent);

            this.pnlPaso2.Controls.Add(this.pnlResumenWrapper);
            this.pnlPaso2.Controls.Add(this.pnlPaso2Buttons);
            this.pnlPaso2.Controls.Add(this.pnlPaso2Top);

            // ══════════════════════════════════════════════════════════════════
            // PASO 3 – CONFIRMACIÓN
            // ══════════════════════════════════════════════════════════════════
            this.pnlPaso3.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.pnlPaso3.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlPaso3.Name      = "pnlPaso3";
            this.pnlPaso3.Visible   = false;

            this.lblPaso3Icono.AutoSize  = false;
            this.lblPaso3Icono.Font      = new System.Drawing.Font("Segoe UI", 36F);
            this.lblPaso3Icono.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblPaso3Icono.Location  = new System.Drawing.Point(310, 60);
            this.lblPaso3Icono.Name      = "lblPaso3Icono";
            this.lblPaso3Icono.Size      = new System.Drawing.Size(100, 64);
            this.lblPaso3Icono.Text      = "✓";
            this.lblPaso3Icono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblPaso3Titulo.AutoSize  = false;
            this.lblPaso3Titulo.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPaso3Titulo.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblPaso3Titulo.Location  = new System.Drawing.Point(100, 136);
            this.lblPaso3Titulo.Name      = "lblPaso3Titulo";
            this.lblPaso3Titulo.Size      = new System.Drawing.Size(520, 40);
            this.lblPaso3Titulo.Text      = "¡Turno cerrado exitosamente!";
            this.lblPaso3Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblPaso3Sub.AutoSize  = false;
            this.lblPaso3Sub.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPaso3Sub.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblPaso3Sub.Location  = new System.Drawing.Point(100, 182);
            this.lblPaso3Sub.Name      = "lblPaso3Sub";
            this.lblPaso3Sub.Size      = new System.Drawing.Size(520, 22);
            this.lblPaso3Sub.Text      = "El turno ha sido registrado y los datos guardados correctamente.";
            this.lblPaso3Sub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblResumenFinalTurno.AutoSize  = false;
            this.lblResumenFinalTurno.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblResumenFinalTurno.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResumenFinalTurno.Location  = new System.Drawing.Point(100, 222);
            this.lblResumenFinalTurno.Name      = "lblResumenFinalTurno";
            this.lblResumenFinalTurno.Size      = new System.Drawing.Size(520, 26);
            this.lblResumenFinalTurno.Text      = "";
            this.lblResumenFinalTurno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblResumenFinalTotal.AutoSize  = false;
            this.lblResumenFinalTotal.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.lblResumenFinalTotal.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblResumenFinalTotal.Location  = new System.Drawing.Point(100, 253);
            this.lblResumenFinalTotal.Name      = "lblResumenFinalTotal";
            this.lblResumenFinalTotal.Size      = new System.Drawing.Size(520, 22);
            this.lblResumenFinalTotal.Text      = "";
            this.lblResumenFinalTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblResumenFinalDuracion.AutoSize  = false;
            this.lblResumenFinalDuracion.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.lblResumenFinalDuracion.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblResumenFinalDuracion.Location  = new System.Drawing.Point(100, 279);
            this.lblResumenFinalDuracion.Name      = "lblResumenFinalDuracion";
            this.lblResumenFinalDuracion.Size      = new System.Drawing.Size(520, 22);
            this.lblResumenFinalDuracion.Text      = "";
            this.lblResumenFinalDuracion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.btnPaso3Cerrar.BackColor         = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnPaso3Cerrar.FlatAppearance.BorderSize = 0;
            this.btnPaso3Cerrar.FlatStyle         = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaso3Cerrar.Font              = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPaso3Cerrar.ForeColor         = System.Drawing.Color.White;
            this.btnPaso3Cerrar.Location          = new System.Drawing.Point(270, 325);
            this.btnPaso3Cerrar.Name              = "btnPaso3Cerrar";
            this.btnPaso3Cerrar.Size              = new System.Drawing.Size(180, 44);
            this.btnPaso3Cerrar.Text              = "Cerrar";
            this.btnPaso3Cerrar.Cursor            = System.Windows.Forms.Cursors.Hand;

            this.pnlPaso3.Controls.Add(this.btnPaso3Cerrar);
            this.pnlPaso3.Controls.Add(this.lblResumenFinalDuracion);
            this.pnlPaso3.Controls.Add(this.lblResumenFinalTotal);
            this.pnlPaso3.Controls.Add(this.lblResumenFinalTurno);
            this.pnlPaso3.Controls.Add(this.lblPaso3Sub);
            this.pnlPaso3.Controls.Add(this.lblPaso3Titulo);
            this.pnlPaso3.Controls.Add(this.lblPaso3Icono);

            // Add pasos to form body (Fill panels; only one visible at a time)
            this.Controls.Add(this.pnlPaso1);
            this.Controls.Add(this.pnlPaso2);
            this.Controls.Add(this.pnlPaso3);
            this.Controls.Add(this.pnlCierreHeader);

            // ══════════════════════════════════════════════════════════════════
            // FORM
            // ══════════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(730, 590);
            this.Font                = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.Name                = "FormCierreCaja";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text                = "Cierre de Turno";

            // ── ResumeLayouts ─────────────────────────────────────────────────
            this.pnlCierreHeader.ResumeLayout(false);
            this.pnlCierreHeader.PerformLayout();
            this.pnlPaso1Top.ResumeLayout(false);
            this.pnlPaso1Top.PerformLayout();
            this.pnlPaso1Buttons.ResumeLayout(false);
            this.pnlMoneteoTotal.ResumeLayout(false);
            this.pnlMoneteoTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoneteo)).EndInit();
            this.pnlMoneteoWrapper.ResumeLayout(false);
            this.pnlPaso1.ResumeLayout(false);
            this.pnlPaso2Top.ResumeLayout(false);
            this.pnlPaso2Top.PerformLayout();
            this.pnlPaso2Buttons.ResumeLayout(false);
            this.pnlPaso2Buttons.PerformLayout();
            this.pnlResumenContent.ResumeLayout(false);
            this.pnlResumenContent.PerformLayout();
            this.pnlResumenWrapper.ResumeLayout(false);
            this.pnlPaso2.ResumeLayout(false);
            this.pnlPaso3.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ── Field declarations ─────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlCierreHeader;
        private System.Windows.Forms.Label lblCierreTitulo;
        private System.Windows.Forms.Label lblPasoIndicador;
        // Paso 1
        private System.Windows.Forms.Panel  pnlPaso1;
        private System.Windows.Forms.Panel  pnlPaso1Top;
        private System.Windows.Forms.Label  lblPaso1Titulo;
        private System.Windows.Forms.Panel  pnlPaso1Buttons;
        private System.Windows.Forms.Button btnPaso1Cancelar;
        private System.Windows.Forms.Button btnPaso1Siguiente;
        private System.Windows.Forms.Panel  pnlMoneteoWrapper;
        private System.Windows.Forms.Panel  pnlMoneteoTotal;
        private System.Windows.Forms.Label  lblMoneteoTotalTxt;
        private System.Windows.Forms.Label  lblMoneteoTotalMonto;
        private System.Windows.Forms.DataGridView              dgvMoneteo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonDenominacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonSubtotal;
        // Paso 2
        private System.Windows.Forms.Panel    pnlPaso2;
        private System.Windows.Forms.Panel    pnlPaso2Top;
        private System.Windows.Forms.Label    lblPaso2Titulo;
        private System.Windows.Forms.Panel    pnlPaso2Buttons;
        private System.Windows.Forms.CheckBox chkImprimirCierre;
        private System.Windows.Forms.Button   btnPaso2Atras;
        private System.Windows.Forms.Button   btnPaso2Confirmar;
        private System.Windows.Forms.Panel    pnlResumenWrapper;
        private System.Windows.Forms.Panel    pnlResumenContent;
        private System.Windows.Forms.Label    lblSecVentas;
        private System.Windows.Forms.Label    lblResVentasTxt;
        private System.Windows.Forms.Label    lblResVentasVal;
        private System.Windows.Forms.Label    lblResEfectivoTxt;
        private System.Windows.Forms.Label    lblResEfectivoVal;
        private System.Windows.Forms.Label    lblResYapeTxt;
        private System.Windows.Forms.Label    lblResYapeVal;
        private System.Windows.Forms.Label    lblResTransferenciaTxt;
        private System.Windows.Forms.Label    lblResTransferenciaVal;
        private System.Windows.Forms.Label    lblResCreditoTxt;
        private System.Windows.Forms.Label    lblResCreditoVal;
        private System.Windows.Forms.Label    lblResGastosTxt;
        private System.Windows.Forms.Label    lblResGastosVal;
        private System.Windows.Forms.Label    lblResSep1;
        private System.Windows.Forms.Label    lblResArqueoTitulo;
        private System.Windows.Forms.Label    lblResFondoTxt;
        private System.Windows.Forms.Label    lblResFondoVal;
        private System.Windows.Forms.Label    lblResEsperadoTxt;
        private System.Windows.Forms.Label    lblResEsperadoVal;
        private System.Windows.Forms.Label    lblResMoneteoTxt;
        private System.Windows.Forms.Label    lblResMoneteoVal;
        private System.Windows.Forms.Label    lblResSep2;
        private System.Windows.Forms.Label    lblResDiferenciaTxt;
        private System.Windows.Forms.Label    lblResDiferenciaVal;
        private System.Windows.Forms.Label    lblResObsTxt;
        private System.Windows.Forms.TextBox  txtObservacionCierre;
        // Paso 3
        private System.Windows.Forms.Panel  pnlPaso3;
        private System.Windows.Forms.Label  lblPaso3Icono;
        private System.Windows.Forms.Label  lblPaso3Titulo;
        private System.Windows.Forms.Label  lblPaso3Sub;
        private System.Windows.Forms.Label  lblResumenFinalTurno;
        private System.Windows.Forms.Label  lblResumenFinalTotal;
        private System.Windows.Forms.Label  lblResumenFinalDuracion;
        private System.Windows.Forms.Button btnPaso3Cerrar;
    }
}
