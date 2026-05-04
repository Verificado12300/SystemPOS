namespace SistemaPOS.Forms.Contactos
{
    partial class FormEstadoCuenta
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
            this.pnlHeader        = new System.Windows.Forms.Panel();
            this.lblTitulo        = new System.Windows.Forms.Label();

            this.pnlInfo          = new System.Windows.Forms.Panel();
            this.lblNombreLbl     = new System.Windows.Forms.Label();
            this.lblNombreVal     = new System.Windows.Forms.Label();
            this.lblDocLbl        = new System.Windows.Forms.Label();
            this.lblDocVal        = new System.Windows.Forms.Label();
            this.lblEstadoBadge   = new System.Windows.Forms.Label();
            this.lblSep1          = new System.Windows.Forms.Label();
            this.lblLimCredLbl    = new System.Windows.Forms.Label();
            this.lblLimCredVal    = new System.Windows.Forms.Label();
            this.lblCredUsadoLbl  = new System.Windows.Forms.Label();
            this.lblCredUsadoVal  = new System.Windows.Forms.Label();
            this.lblDisponibleLbl = new System.Windows.Forms.Label();
            this.lblDisponibleVal = new System.Windows.Forms.Label();

            this.pnlFiltros       = new System.Windows.Forms.Panel();
            this.lblDesde         = new System.Windows.Forms.Label();
            this.dtpDesde         = new System.Windows.Forms.DateTimePicker();
            this.lblHasta         = new System.Windows.Forms.Label();
            this.dtpHasta         = new System.Windows.Forms.DateTimePicker();
            this.lblBuscar        = new System.Windows.Forms.Label();
            this.txtBuscar        = new System.Windows.Forms.TextBox();
            this.btnFiltrar       = new System.Windows.Forms.Button();

            this.pnlBotones       = new System.Windows.Forms.Panel();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.btnImprimir      = new System.Windows.Forms.Button();
            this.btnCerrar        = new System.Windows.Forms.Button();

            this.dgvMovimientos   = new System.Windows.Forms.DataGridView();

            // Columnas DGV
            this.colFecha     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo      = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMetodo    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCargo     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAbono     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldo     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccion    = new System.Windows.Forms.DataGridViewButtonColumn();

            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvMovimientos).BeginInit();
            this.SuspendLayout();

            // ─── FORM ───────────────────────────────────────────────
            this.Text            = "Estado de Cuenta";
            this.ClientSize      = new System.Drawing.Size(980, 620);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.BackColor       = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Font            = new System.Drawing.Font("Segoe UI", 9F);

            // ─── pnlHeader (48 px) ──────────────────────────────────
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 48;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.pnlHeader.Padding   = new System.Windows.Forms.Padding(14, 0, 8, 0);

            this.lblTitulo.AutoSize  = false;
            this.lblTitulo.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Text      = "Estado de Cuenta";

            this.pnlHeader.Controls.Add(this.lblTitulo);

            // ─── pnlInfo (48 px) ────────────────────────────────────
            this.pnlInfo.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Height    = 48;
            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);

            int iy = 7;

            this.lblNombreLbl.AutoSize  = true;
            this.lblNombreLbl.Location  = new System.Drawing.Point(14, iy);
            this.lblNombreLbl.ForeColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.lblNombreLbl.Font      = new System.Drawing.Font("Segoe UI", 7F);
            this.lblNombreLbl.Text      = "CLIENTE";

            this.lblNombreVal.AutoSize  = true;
            this.lblNombreVal.Location  = new System.Drawing.Point(14, iy + 13);
            this.lblNombreVal.ForeColor = System.Drawing.Color.White;
            this.lblNombreVal.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombreVal.Text      = "—";

            this.lblDocLbl.AutoSize  = true;
            this.lblDocLbl.Location  = new System.Drawing.Point(210, iy);
            this.lblDocLbl.ForeColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.lblDocLbl.Font      = new System.Drawing.Font("Segoe UI", 7F);
            this.lblDocLbl.Text      = "DOCUMENTO";

            this.lblDocVal.AutoSize  = true;
            this.lblDocVal.Location  = new System.Drawing.Point(210, iy + 13);
            this.lblDocVal.ForeColor = System.Drawing.Color.White;
            this.lblDocVal.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDocVal.Text      = "—";

            this.lblEstadoBadge.AutoSize  = false;
            this.lblEstadoBadge.Size      = new System.Drawing.Size(66, 20);
            this.lblEstadoBadge.Location  = new System.Drawing.Point(360, iy + 5);
            this.lblEstadoBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEstadoBadge.ForeColor = System.Drawing.Color.White;
            this.lblEstadoBadge.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblEstadoBadge.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblEstadoBadge.Text      = "ACTIVO";

            this.lblSep1.AutoSize  = false;
            this.lblSep1.Size      = new System.Drawing.Size(1, 32);
            this.lblSep1.Location  = new System.Drawing.Point(450, 8);
            this.lblSep1.BackColor = System.Drawing.Color.FromArgb(80, 100, 115);

            int cx = 464;
            this.lblLimCredLbl.AutoSize  = true;
            this.lblLimCredLbl.Location  = new System.Drawing.Point(cx, iy);
            this.lblLimCredLbl.ForeColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.lblLimCredLbl.Font      = new System.Drawing.Font("Segoe UI", 7F);
            this.lblLimCredLbl.Text      = "LÍM. CRÉDITO";

            this.lblLimCredVal.AutoSize  = true;
            this.lblLimCredVal.Location  = new System.Drawing.Point(cx, iy + 13);
            this.lblLimCredVal.ForeColor = System.Drawing.Color.White;
            this.lblLimCredVal.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLimCredVal.Text      = "S/ 0.00";

            cx += 120;
            this.lblCredUsadoLbl.AutoSize  = true;
            this.lblCredUsadoLbl.Location  = new System.Drawing.Point(cx, iy);
            this.lblCredUsadoLbl.ForeColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.lblCredUsadoLbl.Font      = new System.Drawing.Font("Segoe UI", 7F);
            this.lblCredUsadoLbl.Text      = "USADO";

            this.lblCredUsadoVal.AutoSize  = true;
            this.lblCredUsadoVal.Location  = new System.Drawing.Point(cx, iy + 13);
            this.lblCredUsadoVal.ForeColor = System.Drawing.Color.White;
            this.lblCredUsadoVal.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCredUsadoVal.Text      = "S/ 0.00";

            cx += 100;
            this.lblDisponibleLbl.AutoSize  = true;
            this.lblDisponibleLbl.Location  = new System.Drawing.Point(cx, iy);
            this.lblDisponibleLbl.ForeColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.lblDisponibleLbl.Font      = new System.Drawing.Font("Segoe UI", 7F);
            this.lblDisponibleLbl.Text      = "DISPONIBLE";

            this.lblDisponibleVal.AutoSize  = true;
            this.lblDisponibleVal.Location  = new System.Drawing.Point(cx, iy + 13);
            this.lblDisponibleVal.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblDisponibleVal.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDisponibleVal.Text      = "S/ 0.00";

            this.pnlInfo.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblNombreLbl, lblNombreVal,
                lblDocLbl, lblDocVal,
                lblEstadoBadge, lblSep1,
                lblLimCredLbl, lblLimCredVal,
                lblCredUsadoLbl, lblCredUsadoVal,
                lblDisponibleLbl, lblDisponibleVal
            });

            // ─── pnlFiltros (40 px) ─────────────────────────────────
            this.pnlFiltros.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Height    = 40;
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(236, 240, 243);

            int fx = 10, fy = 8;

            this.lblDesde.AutoSize  = true;
            this.lblDesde.Location  = new System.Drawing.Point(fx, fy + 2);
            this.lblDesde.Text      = "Desde:";
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(60, 70, 80);

            this.dtpDesde.Location  = new System.Drawing.Point(fx + 48, fy);
            this.dtpDesde.Size      = new System.Drawing.Size(110, 22);
            this.dtpDesde.Format    = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblHasta.AutoSize  = true;
            this.lblHasta.Location  = new System.Drawing.Point(fx + 170, fy + 2);
            this.lblHasta.Text      = "Hasta:";
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(60, 70, 80);

            this.dtpHasta.Location  = new System.Drawing.Point(fx + 216, fy);
            this.dtpHasta.Size      = new System.Drawing.Size(110, 22);
            this.dtpHasta.Format    = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblBuscar.AutoSize  = true;
            this.lblBuscar.Location  = new System.Drawing.Point(fx + 340, fy + 2);
            this.lblBuscar.Text      = "Buscar:";
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(60, 70, 80);

            this.txtBuscar.Location  = new System.Drawing.Point(fx + 386, fy);
            this.txtBuscar.Size      = new System.Drawing.Size(170, 22);

            this.btnFiltrar.Location  = new System.Drawing.Point(fx + 566, fy - 1);
            this.btnFiltrar.Size      = new System.Drawing.Size(74, 24);
            this.btnFiltrar.Text      = "Filtrar";
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);

            this.pnlFiltros.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblDesde, dtpDesde, lblHasta, dtpHasta,
                lblBuscar, txtBuscar, btnFiltrar
            });

            // ─── pnlBotones (44 px) — anclado al fondo ──────────────
            this.pnlBotones.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Height    = 44;
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(236, 240, 243);

            this.btnRegistrarPago.Location  = new System.Drawing.Point(10, 8);
            this.btnRegistrarPago.Size      = new System.Drawing.Size(132, 28);
            this.btnRegistrarPago.Text      = "Registrar Pago";
            this.btnRegistrarPago.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnRegistrarPago.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarPago.FlatAppearance.BorderSize = 0;
            this.btnRegistrarPago.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.btnImprimir.Location  = new System.Drawing.Point(152, 8);
            this.btnImprimir.Size      = new System.Drawing.Size(108, 28);
            this.btnImprimir.Text      = "Imprimir / PDF";
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.Font      = new System.Drawing.Font("Segoe UI", 9F);

            this.btnCerrar.Anchor    = System.Windows.Forms.AnchorStyles.Top
                                     | System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.Size      = new System.Drawing.Size(80, 28);
            this.btnCerrar.Location  = new System.Drawing.Point(890, 8);
            this.btnCerrar.Text      = "Cerrar";
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.Font      = new System.Drawing.Font("Segoe UI", 9F);

            this.pnlBotones.Controls.AddRange(new System.Windows.Forms.Control[] {
                btnRegistrarPago, btnImprimir, btnCerrar
            });

            // ─── DGV — Fill sin espacio muerto ───────────────────────
            this.dgvMovimientos.Dock                  = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovimientos.BackgroundColor        = System.Drawing.Color.White;
            this.dgvMovimientos.BorderStyle            = System.Windows.Forms.BorderStyle.None;
            this.dgvMovimientos.RowHeadersVisible      = false;
            this.dgvMovimientos.GridColor              = System.Drawing.Color.FromArgb(225, 230, 235);
            this.dgvMovimientos.SelectionMode          = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.AllowUserToAddRows     = false;
            this.dgvMovimientos.AllowUserToResizeRows  = false;
            this.dgvMovimientos.RowTemplate.Height     = 27;
            this.dgvMovimientos.Font                   = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvMovimientos.AutoGenerateColumns    = false;
            this.dgvMovimientos.ReadOnly               = false;

            this.dgvMovimientos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvMovimientos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMovimientos.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.dgvMovimientos.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvMovimientos.ColumnHeadersHeight          = 30;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode  =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMovimientos.EnableHeadersVisualStyles    = false;

            this.dgvMovimientos.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(248, 250, 252);

            // Columnas
            this.colFecha.Name       = "colFecha";
            this.colFecha.HeaderText = "Fecha / Hora";
            this.colFecha.Width      = 126;
            this.colFecha.ReadOnly   = true;

            this.colTipo.Name       = "colTipo";
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Width      = 86;
            this.colTipo.ReadOnly   = true;

            this.colDocumento.Name        = "colDocumento";
            this.colDocumento.HeaderText  = "Documento";
            this.colDocumento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDocumento.MinimumWidth = 110;
            this.colDocumento.ReadOnly    = true;

            this.colMetodo.Name       = "colMetodo";
            this.colMetodo.HeaderText = "Método";
            this.colMetodo.Width      = 105;
            this.colMetodo.ReadOnly   = true;

            this.colCargo.Name      = "colCargo";
            this.colCargo.HeaderText = "Cargo";
            this.colCargo.Width     = 98;
            this.colCargo.ReadOnly  = true;
            this.colCargo.DefaultCellStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colAbono.Name       = "colAbono";
            this.colAbono.HeaderText = "Abono";
            this.colAbono.Width      = 98;
            this.colAbono.ReadOnly   = true;
            this.colAbono.DefaultCellStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colSaldo.Name       = "colSaldo";
            this.colSaldo.HeaderText = "Saldo";
            this.colSaldo.Width      = 106;
            this.colSaldo.ReadOnly   = true;
            this.colSaldo.DefaultCellStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colAccion.Name       = "colAccion";
            this.colAccion.HeaderText = "Acción";
            this.colAccion.Width      = 68;
            this.colAccion.ReadOnly   = false;
            this.colAccion.DefaultCellStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAccion.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;

            this.dgvMovimientos.Columns.AddRange(
                colFecha, colTipo, colDocumento, colMetodo,
                colCargo, colAbono, colSaldo, colAccion);

            this.dgvMovimientos.CellClick += DgvMovimientos_CellClick;

            // ─── Orden de controles (Dock apila de abajo a arriba) ───
            // Bottom → pnlBotones  |  Top (primero que se apila)  → pnlHeader
            // Fill → dgvMovimientos (queda en el espacio central)
            this.Controls.Add(this.dgvMovimientos);   // Fill → primero en Add
            this.Controls.Add(this.pnlFiltros);       // Top
            this.Controls.Add(this.pnlInfo);          // Top
            this.Controls.Add(this.pnlHeader);        // Top (más arriba de todo)
            this.Controls.Add(this.pnlBotones);       // Bottom

            this.pnlHeader.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvMovimientos).EndInit();
            this.ResumeLayout(false);
        }

        // ─── Declaración de controles ────────────────────────────────
        private System.Windows.Forms.Panel  pnlHeader;
        private System.Windows.Forms.Label  lblTitulo;

        private System.Windows.Forms.Panel  pnlInfo;
        private System.Windows.Forms.Label  lblNombreLbl, lblNombreVal;
        private System.Windows.Forms.Label  lblDocLbl, lblDocVal;
        private System.Windows.Forms.Label  lblEstadoBadge;
        private System.Windows.Forms.Label  lblSep1;
        private System.Windows.Forms.Label  lblLimCredLbl, lblLimCredVal;
        private System.Windows.Forms.Label  lblCredUsadoLbl, lblCredUsadoVal;
        private System.Windows.Forms.Label  lblDisponibleLbl, lblDisponibleVal;

        private System.Windows.Forms.Panel           pnlFiltros;
        private System.Windows.Forms.Label           lblDesde, lblHasta, lblBuscar;
        private System.Windows.Forms.DateTimePicker  dtpDesde, dtpHasta;
        private System.Windows.Forms.TextBox         txtBuscar;
        private System.Windows.Forms.Button          btnFiltrar;

        private System.Windows.Forms.Panel  pnlBotones;
        private System.Windows.Forms.Button btnRegistrarPago;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCerrar;

        private System.Windows.Forms.DataGridView            dgvMovimientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMetodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAbono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldo;
        private System.Windows.Forms.DataGridViewButtonColumn  colAccion;
    }
}
