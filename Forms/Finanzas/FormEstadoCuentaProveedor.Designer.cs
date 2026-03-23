namespace SistemaPOS.Forms.Finanzas
{
    partial class FormEstadoCuentaProveedor
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
            this.lblProveedorLbl  = new System.Windows.Forms.Label();
            this.lblProveedorVal  = new System.Windows.Forms.Label();

            this.pnlFiltros       = new System.Windows.Forms.Panel();
            this.lblDesde         = new System.Windows.Forms.Label();
            this.dtpDesde         = new System.Windows.Forms.DateTimePicker();
            this.lblHasta         = new System.Windows.Forms.Label();
            this.dtpHasta         = new System.Windows.Forms.DateTimePicker();
            this.lblBuscar        = new System.Windows.Forms.Label();
            this.txtBuscar        = new System.Windows.Forms.TextBox();
            this.btnFiltrar       = new System.Windows.Forms.Button();

            this.pnlResumen       = new System.Windows.Forms.Panel();
            this.pnlCardCompras   = new System.Windows.Forms.Panel();
            this.lblComprasLbl    = new System.Windows.Forms.Label();
            this.lblComprasVal    = new System.Windows.Forms.Label();
            this.pnlCardPagos     = new System.Windows.Forms.Panel();
            this.lblPagosLbl      = new System.Windows.Forms.Label();
            this.lblPagosVal      = new System.Windows.Forms.Label();
            this.pnlCardAnul      = new System.Windows.Forms.Panel();
            this.lblAnulLbl       = new System.Windows.Forms.Label();
            this.lblAnulVal       = new System.Windows.Forms.Label();
            this.pnlCardSaldo     = new System.Windows.Forms.Panel();
            this.lblSaldoLbl      = new System.Windows.Forms.Label();
            this.lblSaldoVal      = new System.Windows.Forms.Label();

            this.pnlBotones       = new System.Windows.Forms.Panel();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.btnCerrar        = new System.Windows.Forms.Button();

            this.dgvMovimientos   = new System.Windows.Forms.DataGridView();

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
            this.pnlResumen.SuspendLayout();
            this.pnlCardCompras.SuspendLayout();
            this.pnlCardPagos.SuspendLayout();
            this.pnlCardAnul.SuspendLayout();
            this.pnlCardSaldo.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvMovimientos).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────────
            this.Text            = "Estado de Cuenta Proveedor";
            this.ClientSize      = new System.Drawing.Size(1020, 640);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.BackColor       = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Font            = new System.Drawing.Font("Segoe UI", 9F);

            // ── pnlHeader (48 px) ────────────────────────────────────────
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 48;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.pnlHeader.Padding   = new System.Windows.Forms.Padding(14, 0, 8, 0);

            this.lblTitulo.AutoSize  = false;
            this.lblTitulo.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Text      = "Estado de Cuenta — Proveedor";

            this.pnlHeader.Controls.Add(this.lblTitulo);

            // ── pnlInfo (42 px) ──────────────────────────────────────────
            this.pnlInfo.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Height    = 42;
            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);

            this.lblProveedorLbl.AutoSize  = true;
            this.lblProveedorLbl.Location  = new System.Drawing.Point(14, 6);
            this.lblProveedorLbl.ForeColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.lblProveedorLbl.Font      = new System.Drawing.Font("Segoe UI", 7F);
            this.lblProveedorLbl.Text      = "PROVEEDOR";

            this.lblProveedorVal.AutoSize  = true;
            this.lblProveedorVal.Location  = new System.Drawing.Point(14, 19);
            this.lblProveedorVal.ForeColor = System.Drawing.Color.White;
            this.lblProveedorVal.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProveedorVal.Text      = "—";

            this.pnlInfo.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblProveedorLbl, lblProveedorVal
            });

            // ── pnlFiltros (40 px) ───────────────────────────────────────
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

            // ── pnlResumen (64 px) — 4 tarjetas ──────────────────────────
            this.pnlResumen.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlResumen.Height    = 64;
            this.pnlResumen.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlResumen.Padding   = new System.Windows.Forms.Padding(10, 6, 10, 6);

            _cardNextX = 10;
            InicializarCard(this.pnlCardCompras, this.lblComprasLbl, this.lblComprasVal,
                "TOTAL COMPRAS",    System.Drawing.Color.FromArgb(214, 48, 49));
            InicializarCard(this.pnlCardPagos,   this.lblPagosLbl,   this.lblPagosVal,
                "TOTAL PAGADO",     System.Drawing.Color.FromArgb(39, 174, 96));
            InicializarCard(this.pnlCardAnul,    this.lblAnulLbl,    this.lblAnulVal,
                "ANULACIONES",      System.Drawing.Color.FromArgb(149, 165, 166));
            InicializarCard(this.pnlCardSaldo,   this.lblSaldoLbl,   this.lblSaldoVal,
                "SALDO ACTUAL",     System.Drawing.Color.FromArgb(52, 152, 219));

            this.pnlResumen.Controls.AddRange(new System.Windows.Forms.Control[] {
                pnlCardCompras, pnlCardPagos, pnlCardAnul, pnlCardSaldo
            });

            // ── pnlBotones (44 px) — base ─────────────────────────────────
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
            this.btnRegistrarPago.Cursor    = System.Windows.Forms.Cursors.Hand;

            this.btnCerrar.Anchor    = System.Windows.Forms.AnchorStyles.Top
                                     | System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.Size      = new System.Drawing.Size(80, 28);
            this.btnCerrar.Location  = new System.Drawing.Point(930, 8);
            this.btnCerrar.Text      = "Cerrar";
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrar.Cursor    = System.Windows.Forms.Cursors.Hand;

            this.pnlBotones.Controls.AddRange(new System.Windows.Forms.Control[] {
                btnRegistrarPago, btnCerrar
            });

            // ── DGV ──────────────────────────────────────────────────────
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

            var hStyle = this.dgvMovimientos.ColumnHeadersDefaultCellStyle;
            hStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            hStyle.ForeColor = System.Drawing.Color.White;
            hStyle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            hStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvMovimientos.ColumnHeadersHeight         = 30;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMovimientos.EnableHeadersVisualStyles   = false;
            this.dgvMovimientos.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(248, 250, 252);

            // Columnas
            this.colFecha.Name       = "colFecha";
            this.colFecha.HeaderText = "Fecha / Hora";
            this.colFecha.Width      = 126;
            this.colFecha.ReadOnly   = true;

            this.colTipo.Name       = "colTipo";
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Width      = 100;
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

            this.colCargo.Name       = "colCargo";
            this.colCargo.HeaderText = "Cargo";
            this.colCargo.Width      = 100;
            this.colCargo.ReadOnly   = true;
            this.colCargo.DefaultCellStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colAbono.Name       = "colAbono";
            this.colAbono.HeaderText = "Abono";
            this.colAbono.Width      = 100;
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
            this.colAccion.Width      = 72;
            this.colAccion.ReadOnly   = false;
            this.colAccion.DefaultCellStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAccion.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;

            this.dgvMovimientos.Columns.AddRange(
                colFecha, colTipo, colDocumento, colMetodo,
                colCargo, colAbono, colSaldo, colAccion);

            this.dgvMovimientos.CellClick += DgvMovimientos_CellClick;

            // ── Orden de Add (Dock apila de abajo a arriba) ───────────────
            this.Controls.Add(this.dgvMovimientos);   // Fill
            this.Controls.Add(this.pnlResumen);       // Top
            this.Controls.Add(this.pnlFiltros);       // Top
            this.Controls.Add(this.pnlInfo);          // Top
            this.Controls.Add(this.pnlHeader);        // Top (más arriba)
            this.Controls.Add(this.pnlBotones);       // Bottom

            this.pnlHeader.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlResumen.ResumeLayout(false);
            this.pnlCardCompras.ResumeLayout(false);
            this.pnlCardPagos.ResumeLayout(false);
            this.pnlCardAnul.ResumeLayout(false);
            this.pnlCardSaldo.ResumeLayout(false);
            this.pnlBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvMovimientos).EndInit();
            this.ResumeLayout(false);
        }

        // ── Helper tarjetas ─────────────────────────────────────────────
        private static int _cardNextX;

        private void InicializarCard(
            System.Windows.Forms.Panel panel,
            System.Windows.Forms.Label lblTit,
            System.Windows.Forms.Label lblVal,
            string titulo,
            System.Drawing.Color acento)
        {
            panel.Size        = new System.Drawing.Size(236, 52);
            panel.Location    = new System.Drawing.Point(_cardNextX, 6);
            panel.BackColor   = System.Drawing.Color.White;
            panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            _cardNextX += 244;

            lblTit.AutoSize  = false;
            lblTit.Dock      = System.Windows.Forms.DockStyle.Top;
            lblTit.Height    = 17;
            lblTit.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            lblTit.Padding   = new System.Windows.Forms.Padding(7, 0, 0, 0);
            lblTit.Font      = new System.Drawing.Font("Segoe UI", 7F);
            lblTit.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            lblTit.Text      = titulo;

            lblVal.AutoSize  = false;
            lblVal.Dock      = System.Windows.Forms.DockStyle.Fill;
            lblVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblVal.Padding   = new System.Windows.Forms.Padding(7, 0, 0, 0);
            lblVal.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblVal.ForeColor = acento;
            lblVal.Text      = "S/ 0.00";

            panel.Controls.Add(lblVal);
            panel.Controls.Add(lblTit);
        }

        // ── Declaración de controles ─────────────────────────────────────
        private System.Windows.Forms.Panel  pnlHeader;
        private System.Windows.Forms.Label  lblTitulo;

        private System.Windows.Forms.Panel  pnlInfo;
        private System.Windows.Forms.Label  lblProveedorLbl, lblProveedorVal;

        private System.Windows.Forms.Panel           pnlFiltros;
        private System.Windows.Forms.Label           lblDesde, lblHasta, lblBuscar;
        private System.Windows.Forms.DateTimePicker  dtpDesde, dtpHasta;
        private System.Windows.Forms.TextBox         txtBuscar;
        private System.Windows.Forms.Button          btnFiltrar;

        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Panel pnlCardCompras, pnlCardPagos, pnlCardAnul, pnlCardSaldo;
        private System.Windows.Forms.Label lblComprasLbl, lblComprasVal;
        private System.Windows.Forms.Label lblPagosLbl,   lblPagosVal;
        private System.Windows.Forms.Label lblAnulLbl,    lblAnulVal;
        private System.Windows.Forms.Label lblSaldoLbl,   lblSaldoVal;

        private System.Windows.Forms.Panel  pnlBotones;
        private System.Windows.Forms.Button btnRegistrarPago;
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
