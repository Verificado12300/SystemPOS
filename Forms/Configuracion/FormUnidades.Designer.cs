namespace SistemaPOS.Forms.Configuracion
{
    partial class FormUnidades
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
            // ── Header ───────────────────────────────────────────────────────
            this.pnlHeader    = new System.Windows.Forms.Panel();
            this.lblTitulo    = new System.Windows.Forms.Label();
            this.lblHeaderSub = new System.Windows.Forms.Label();

            // ── Stats ────────────────────────────────────────────────────────
            this.pnlStats      = new System.Windows.Forms.Panel();
            this.pnlCard1      = new System.Windows.Forms.Panel();
            this.pnlAccent1    = new System.Windows.Forms.Panel();
            this.lblCardVal1   = new System.Windows.Forms.Label();
            this.lblCardTitle1 = new System.Windows.Forms.Label();
            this.pnlCard2      = new System.Windows.Forms.Panel();
            this.pnlAccent2    = new System.Windows.Forms.Panel();
            this.lblCardVal2   = new System.Windows.Forms.Label();
            this.lblCardTitle2 = new System.Windows.Forms.Label();
            this.pnlCard3      = new System.Windows.Forms.Panel();
            this.pnlAccent3    = new System.Windows.Forms.Panel();
            this.lblCardVal3   = new System.Windows.Forms.Label();
            this.lblCardTitle3 = new System.Windows.Forms.Label();

            // ── Form panel (izquierda) ────────────────────────────────────────
            this.pnlForm        = new System.Windows.Forms.Panel();
            this.pnlFormHeader  = new System.Windows.Forms.Panel();
            this.pnlFormAccent  = new System.Windows.Forms.Panel();
            this.lblFormTitle   = new System.Windows.Forms.Label();
            this.pnlFormFields  = new System.Windows.Forms.Panel();
            this.lblNombreLbl   = new System.Windows.Forms.Label();
            this.txtNombre      = new System.Windows.Forms.TextBox();
            this.lblAbreviaturaLbl = new System.Windows.Forms.Label();
            this.txtAbreviatura = new System.Windows.Forms.TextBox();
            this.lblTipoLbl     = new System.Windows.Forms.Label();
            this.cmbTipo        = new System.Windows.Forms.ComboBox();
            this.lblEstadoLbl   = new System.Windows.Forms.Label();
            this.chkActivo      = new System.Windows.Forms.CheckBox();
            this.pnlFormButtons = new System.Windows.Forms.Panel();
            this.btnGuardar     = new System.Windows.Forms.Button();
            this.btnCancelar    = new System.Windows.Forms.Button();

            // ── Separador ────────────────────────────────────────────────────
            this.pnlSep = new System.Windows.Forms.Panel();

            // ── Lista (derecha) ───────────────────────────────────────────────
            this.pnlListArea   = new System.Windows.Forms.Panel();
            this.pnlToolbar    = new System.Windows.Forms.Panel();
            this.lblBuscarLbl  = new System.Windows.Forms.Label();
            this.txtBuscar     = new System.Windows.Forms.TextBox();
            this.pnlGridWrap   = new System.Windows.Forms.Panel();
            this.dgvUnidades   = new System.Windows.Forms.DataGridView();
            this.colNumero     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAbreviatura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto   = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar     = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEliminar   = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlResumen    = new System.Windows.Forms.Panel();
            this.lblMostrar    = new System.Windows.Forms.Label();

            // ── Suspend ───────────────────────────────────────────────────────
            this.pnlHeader.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlFormHeader.SuspendLayout();
            this.pnlFormFields.SuspendLayout();
            this.pnlFormButtons.SuspendLayout();
            this.pnlListArea.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlGridWrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvUnidades).BeginInit();
            this.pnlResumen.SuspendLayout();
            this.SuspendLayout();

            // ════════════════════════════════════════════════════════════════
            // pnlHeader   Dock=Top  68px
            // ════════════════════════════════════════════════════════════════
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 68;
            this.pnlHeader.TabIndex  = 100;

            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(22, 10);
            this.lblTitulo.Text      = "Unidades de Medida";

            this.lblHeaderSub.AutoSize  = true;
            this.lblHeaderSub.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.lblHeaderSub.Location  = new System.Drawing.Point(22, 40);
            this.lblHeaderSub.Text      = "Unidades base para inventario y ventas";

            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Controls.Add(this.lblTitulo);

            // ════════════════════════════════════════════════════════════════
            // pnlStats   Dock=Top  88px — 3 tarjetas
            // ════════════════════════════════════════════════════════════════
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(236, 240, 245);
            this.pnlStats.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Height    = 88;
            this.pnlStats.TabIndex  = 101;

            this.pnlAccent1.BackColor = System.Drawing.Color.FromArgb(57, 73, 171);
            this.pnlAccent1.Location  = new System.Drawing.Point(0, 0);
            this.pnlAccent1.Size      = new System.Drawing.Size(6, 64);
            this.lblCardVal1.AutoSize  = false;
            this.lblCardVal1.Location  = new System.Drawing.Point(18, 9);
            this.lblCardVal1.Size      = new System.Drawing.Size(334, 28);
            this.lblCardVal1.Font      = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblCardVal1.ForeColor = System.Drawing.Color.FromArgb(35, 45, 55);
            this.lblCardVal1.Text      = "0";
            this.lblCardTitle1.AutoSize  = false;
            this.lblCardTitle1.Location  = new System.Drawing.Point(18, 41);
            this.lblCardTitle1.Size      = new System.Drawing.Size(334, 16);
            this.lblCardTitle1.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle1.ForeColor = System.Drawing.Color.FromArgb(57, 73, 171);
            this.lblCardTitle1.Text      = "TOTAL UNIDADES";
            this.pnlCard1.BackColor   = System.Drawing.Color.White;
            this.pnlCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard1.Location    = new System.Drawing.Point(16, 12);
            this.pnlCard1.Size        = new System.Drawing.Size(356, 64);
            this.pnlCard1.Controls.Add(this.lblCardTitle1);
            this.pnlCard1.Controls.Add(this.lblCardVal1);
            this.pnlCard1.Controls.Add(this.pnlAccent1);

            this.pnlAccent2.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.pnlAccent2.Location  = new System.Drawing.Point(0, 0);
            this.pnlAccent2.Size      = new System.Drawing.Size(6, 64);
            this.lblCardVal2.AutoSize  = false;
            this.lblCardVal2.Location  = new System.Drawing.Point(18, 9);
            this.lblCardVal2.Size      = new System.Drawing.Size(334, 28);
            this.lblCardVal2.Font      = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblCardVal2.ForeColor = System.Drawing.Color.FromArgb(35, 45, 55);
            this.lblCardVal2.Text      = "0";
            this.lblCardTitle2.AutoSize  = false;
            this.lblCardTitle2.Location  = new System.Drawing.Point(18, 41);
            this.lblCardTitle2.Size      = new System.Drawing.Size(334, 16);
            this.lblCardTitle2.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle2.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblCardTitle2.Text      = "ACTIVAS";
            this.pnlCard2.BackColor   = System.Drawing.Color.White;
            this.pnlCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard2.Location    = new System.Drawing.Point(388, 12);
            this.pnlCard2.Size        = new System.Drawing.Size(356, 64);
            this.pnlCard2.Controls.Add(this.lblCardTitle2);
            this.pnlCard2.Controls.Add(this.lblCardVal2);
            this.pnlCard2.Controls.Add(this.pnlAccent2);

            this.pnlAccent3.BackColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.pnlAccent3.Location  = new System.Drawing.Point(0, 0);
            this.pnlAccent3.Size      = new System.Drawing.Size(6, 64);
            this.lblCardVal3.AutoSize  = false;
            this.lblCardVal3.Location  = new System.Drawing.Point(18, 9);
            this.lblCardVal3.Size      = new System.Drawing.Size(334, 28);
            this.lblCardVal3.Font      = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblCardVal3.ForeColor = System.Drawing.Color.FromArgb(35, 45, 55);
            this.lblCardVal3.Text      = "0";
            this.lblCardTitle3.AutoSize  = false;
            this.lblCardTitle3.Location  = new System.Drawing.Point(18, 41);
            this.lblCardTitle3.Size      = new System.Drawing.Size(334, 16);
            this.lblCardTitle3.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle3.ForeColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.lblCardTitle3.Text      = "CON PRODUCTOS";
            this.pnlCard3.BackColor   = System.Drawing.Color.White;
            this.pnlCard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard3.Location    = new System.Drawing.Point(760, 12);
            this.pnlCard3.Size        = new System.Drawing.Size(356, 64);
            this.pnlCard3.Controls.Add(this.lblCardTitle3);
            this.pnlCard3.Controls.Add(this.lblCardVal3);
            this.pnlCard3.Controls.Add(this.pnlAccent3);

            this.pnlStats.Controls.Add(this.pnlCard3);
            this.pnlStats.Controls.Add(this.pnlCard2);
            this.pnlStats.Controls.Add(this.pnlCard1);

            // ════════════════════════════════════════════════════════════════
            // pnlForm   Dock=Left  310px
            // ════════════════════════════════════════════════════════════════
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlForm.Width     = 310;
            this.pnlForm.TabIndex  = 102;

            this.pnlFormHeader.BackColor = System.Drawing.Color.White;
            this.pnlFormHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlFormHeader.Height    = 52;

            this.pnlFormAccent.BackColor = System.Drawing.Color.FromArgb(57, 73, 171);
            this.pnlFormAccent.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlFormAccent.Width     = 4;

            this.lblFormTitle.AutoSize  = false;
            this.lblFormTitle.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblFormTitle.Font      = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(35, 47, 62);
            this.lblFormTitle.Name      = "lblFormTitle";
            this.lblFormTitle.Padding   = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFormTitle.Text      = "Nueva Unidad";

            this.pnlFormHeader.Controls.Add(this.lblFormTitle);
            this.pnlFormHeader.Controls.Add(this.pnlFormAccent);

            this.pnlFormFields.BackColor = System.Drawing.Color.White;
            this.pnlFormFields.Dock      = System.Windows.Forms.DockStyle.Fill;

            this.lblNombreLbl.AutoSize  = true;
            this.lblNombreLbl.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombreLbl.ForeColor = System.Drawing.Color.FromArgb(70, 80, 90);
            this.lblNombreLbl.Location  = new System.Drawing.Point(18, 20);
            this.lblNombreLbl.Text      = "Nombre de la Unidad";

            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.Location    = new System.Drawing.Point(18, 42);
            this.txtNombre.Multiline   = true;
            this.txtNombre.Name        = "txtNombre";
            this.txtNombre.Size        = new System.Drawing.Size(272, 30);
            this.txtNombre.TabIndex    = 0;

            this.lblAbreviaturaLbl.AutoSize  = true;
            this.lblAbreviaturaLbl.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAbreviaturaLbl.ForeColor = System.Drawing.Color.FromArgb(70, 80, 90);
            this.lblAbreviaturaLbl.Location  = new System.Drawing.Point(18, 88);
            this.lblAbreviaturaLbl.Text      = "Símbolo / Abreviatura";

            this.txtAbreviatura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAbreviatura.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAbreviatura.Location    = new System.Drawing.Point(18, 110);
            this.txtAbreviatura.Multiline   = true;
            this.txtAbreviatura.Name        = "txtAbreviatura";
            this.txtAbreviatura.Size        = new System.Drawing.Size(272, 30);
            this.txtAbreviatura.TabIndex    = 1;

            this.lblTipoLbl.AutoSize  = true;
            this.lblTipoLbl.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipoLbl.ForeColor = System.Drawing.Color.FromArgb(70, 80, 90);
            this.lblTipoLbl.Location  = new System.Drawing.Point(18, 156);
            this.lblTipoLbl.Text      = "Tipo de Unidad";

            this.cmbTipo.DropDownStyle    = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Font             = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location         = new System.Drawing.Point(18, 178);
            this.cmbTipo.Name             = "cmbTipo";
            this.cmbTipo.Size             = new System.Drawing.Size(272, 27);
            this.cmbTipo.TabIndex         = 2;

            this.lblEstadoLbl.AutoSize  = true;
            this.lblEstadoLbl.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstadoLbl.ForeColor = System.Drawing.Color.FromArgb(70, 80, 90);
            this.lblEstadoLbl.Location  = new System.Drawing.Point(18, 220);
            this.lblEstadoLbl.Text      = "Estado";

            this.chkActivo.AutoSize  = true;
            this.chkActivo.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkActivo.ForeColor = System.Drawing.Color.FromArgb(50, 60, 70);
            this.chkActivo.Location  = new System.Drawing.Point(18, 243);
            this.chkActivo.Name      = "chkActivo";
            this.chkActivo.TabIndex  = 3;
            this.chkActivo.Text      = "Activo";

            this.pnlFormFields.Controls.Add(this.chkActivo);
            this.pnlFormFields.Controls.Add(this.lblEstadoLbl);
            this.pnlFormFields.Controls.Add(this.cmbTipo);
            this.pnlFormFields.Controls.Add(this.lblTipoLbl);
            this.pnlFormFields.Controls.Add(this.txtAbreviatura);
            this.pnlFormFields.Controls.Add(this.lblAbreviaturaLbl);
            this.pnlFormFields.Controls.Add(this.txtNombre);
            this.pnlFormFields.Controls.Add(this.lblNombreLbl);

            this.pnlFormButtons.BackColor = System.Drawing.Color.FromArgb(248, 249, 251);
            this.pnlFormButtons.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFormButtons.Height    = 64;

            this.btnGuardar.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.BackColor  = System.Drawing.Color.FromArgb(57, 73, 171);
            this.btnGuardar.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(48, 63, 159);
            this.btnGuardar.Font       = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor  = System.Drawing.Color.White;
            this.btnGuardar.Location   = new System.Drawing.Point(18, 14);
            this.btnGuardar.Name       = "btnGuardar";
            this.btnGuardar.Size       = new System.Drawing.Size(128, 36);
            this.btnGuardar.TabIndex   = 4;
            this.btnGuardar.Text       = "Guardar";

            this.btnCancelar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(180, 190, 200);
            this.btnCancelar.FlatAppearance.BorderSize  = 1;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(242, 244, 248);
            this.btnCancelar.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(80, 90, 100);
            this.btnCancelar.Location  = new System.Drawing.Point(158, 14);
            this.btnCancelar.Name      = "btnCancelar";
            this.btnCancelar.Size      = new System.Drawing.Size(108, 36);
            this.btnCancelar.TabIndex  = 5;
            this.btnCancelar.Text      = "Cancelar";

            this.pnlFormButtons.Controls.Add(this.btnCancelar);
            this.pnlFormButtons.Controls.Add(this.btnGuardar);

            this.pnlForm.Controls.Add(this.pnlFormFields);
            this.pnlForm.Controls.Add(this.pnlFormButtons);
            this.pnlForm.Controls.Add(this.pnlFormHeader);

            // ════════════════════════════════════════════════════════════════
            // pnlSep
            // ════════════════════════════════════════════════════════════════
            this.pnlSep.BackColor = System.Drawing.Color.FromArgb(218, 224, 232);
            this.pnlSep.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlSep.Width     = 1;
            this.pnlSep.TabIndex  = 103;

            // ════════════════════════════════════════════════════════════════
            // pnlListArea   Dock=Fill
            // ════════════════════════════════════════════════════════════════
            this.pnlListArea.BackColor = System.Drawing.Color.FromArgb(236, 240, 245);
            this.pnlListArea.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlListArea.TabIndex  = 104;

            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Height    = 52;

            this.lblBuscarLbl.AutoSize  = true;
            this.lblBuscarLbl.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBuscarLbl.ForeColor = System.Drawing.Color.FromArgb(80, 90, 95);
            this.lblBuscarLbl.Location  = new System.Drawing.Point(18, 18);
            this.lblBuscarLbl.Text      = "Buscar:";

            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location    = new System.Drawing.Point(78, 14);
            this.txtBuscar.Name        = "txtBuscar";
            this.txtBuscar.Size        = new System.Drawing.Size(340, 26);
            this.txtBuscar.TabIndex    = 10;

            this.pnlToolbar.Controls.Add(this.lblBuscarLbl);
            this.pnlToolbar.Controls.Add(this.txtBuscar);

            this.pnlGridWrap.BackColor = System.Drawing.Color.FromArgb(236, 240, 245);
            this.pnlGridWrap.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridWrap.Padding   = new System.Windows.Forms.Padding(14, 10, 14, 0);

            var styleHeader = new System.Windows.Forms.DataGridViewCellStyle();
            styleHeader.BackColor          = System.Drawing.Color.FromArgb(45, 52, 54);
            styleHeader.ForeColor          = System.Drawing.Color.White;
            styleHeader.Font               = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            styleHeader.Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            styleHeader.SelectionBackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            styleHeader.SelectionForeColor = System.Drawing.Color.White;

            var styleRow = new System.Windows.Forms.DataGridViewCellStyle();
            styleRow.BackColor          = System.Drawing.Color.White;
            styleRow.ForeColor          = System.Drawing.Color.FromArgb(45, 52, 54);
            styleRow.Font               = new System.Drawing.Font("Segoe UI", 9.5F);
            styleRow.Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            styleRow.SelectionBackColor = System.Drawing.Color.FromArgb(225, 243, 255);
            styleRow.SelectionForeColor = System.Drawing.Color.FromArgb(45, 52, 54);

            var styleAlt = new System.Windows.Forms.DataGridViewCellStyle();
            styleAlt.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);

            this.dgvUnidades.AllowUserToAddRows              = false;
            this.dgvUnidades.AllowUserToDeleteRows           = false;
            this.dgvUnidades.AllowUserToResizeRows           = false;
            this.dgvUnidades.AutoGenerateColumns             = false;
            this.dgvUnidades.AutoSizeRowsMode                = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.dgvUnidades.BackgroundColor                 = System.Drawing.Color.White;
            this.dgvUnidades.BorderStyle                     = System.Windows.Forms.BorderStyle.None;
            this.dgvUnidades.CellBorderStyle                 = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUnidades.ColumnHeadersBorderStyle        = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvUnidades.ColumnHeadersDefaultCellStyle   = styleHeader;
            this.dgvUnidades.ColumnHeadersHeight             = 34;
            this.dgvUnidades.ColumnHeadersHeightSizeMode     = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUnidades.DefaultCellStyle                = styleRow;
            this.dgvUnidades.AlternatingRowsDefaultCellStyle = styleAlt;
            this.dgvUnidades.Dock                            = System.Windows.Forms.DockStyle.Fill;
            this.dgvUnidades.EnableHeadersVisualStyles       = false;
            this.dgvUnidades.GridColor                       = System.Drawing.Color.FromArgb(225, 230, 235);
            this.dgvUnidades.MultiSelect                     = false;
            this.dgvUnidades.Name                            = "dgvUnidades";
            this.dgvUnidades.ReadOnly                        = false;
            this.dgvUnidades.RowHeadersVisible               = false;
            this.dgvUnidades.RowTemplate.Height              = 40;
            this.dgvUnidades.SelectionMode                   = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnidades.TabIndex                        = 0;

            this.colNumero.HeaderText = "#";
            this.colNumero.Name       = "colNumero";
            this.colNumero.ReadOnly   = true;
            this.colNumero.Width      = 44;
            this.colNumero.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colNumero.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(130, 140, 150);

            this.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombre.HeaderText   = "Nombre";
            this.colNombre.Name         = "colNombre";
            this.colNombre.ReadOnly     = true;
            this.colNombre.MinimumWidth = 120;

            this.colAbreviatura.HeaderText = "Símbolo";
            this.colAbreviatura.Name       = "colAbreviatura";
            this.colAbreviatura.ReadOnly   = true;
            this.colAbreviatura.Width      = 80;
            this.colAbreviatura.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name       = "colTipo";
            this.colTipo.ReadOnly   = true;
            this.colTipo.Width      = 110;

            this.colProducto.HeaderText = "Productos";
            this.colProducto.Name       = "colProducto";
            this.colProducto.ReadOnly   = true;
            this.colProducto.Width      = 90;
            this.colProducto.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name       = "colEstado";
            this.colEstado.ReadOnly   = true;
            this.colEstado.Width      = 90;
            this.colEstado.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEstado.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.colEditar.HeaderText = "";
            this.colEditar.Name       = "colEditar";
            this.colEditar.ReadOnly   = false;
            this.colEditar.Text       = "Editar";
            this.colEditar.UseColumnTextForButtonValue = true;
            this.colEditar.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.colEditar.Width      = 72;
            this.colEditar.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.colEditar.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colEliminar.HeaderText = "";
            this.colEliminar.Name       = "colEliminar";
            this.colEliminar.ReadOnly   = false;
            this.colEliminar.Text       = "Eliminar";
            this.colEliminar.UseColumnTextForButtonValue = true;
            this.colEliminar.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.colEliminar.Width      = 72;
            this.colEliminar.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.colEliminar.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.dgvUnidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNumero, this.colNombre, this.colAbreviatura, this.colTipo,
                this.colProducto, this.colEstado, this.colEditar, this.colEliminar
            });

            this.pnlGridWrap.Controls.Add(this.dgvUnidades);

            this.pnlResumen.BackColor = System.Drawing.Color.White;
            this.pnlResumen.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumen.Height    = 36;

            this.lblMostrar.AutoSize  = true;
            this.lblMostrar.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMostrar.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblMostrar.Location  = new System.Drawing.Point(16, 11);
            this.lblMostrar.Name      = "lblMostrar";
            this.lblMostrar.Text      = "Mostrando 0 unidades";

            this.pnlResumen.Controls.Add(this.lblMostrar);

            this.pnlListArea.Controls.Add(this.pnlGridWrap);
            this.pnlListArea.Controls.Add(this.pnlResumen);
            this.pnlListArea.Controls.Add(this.pnlToolbar);

            // ════════════════════════════════════════════════════════════════
            // Form
            // ════════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(236, 240, 245);
            this.ClientSize          = new System.Drawing.Size(1184, 611);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.None;
            this.Name                = "FormUnidades";
            this.Text                = "Unidades de Medida";

            this.Controls.Add(this.pnlListArea);
            this.Controls.Add(this.pnlSep);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlHeader);

            // ── Resume ────────────────────────────────────────────────────────
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard3.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlFormHeader.ResumeLayout(false);
            this.pnlFormFields.ResumeLayout(false);
            this.pnlFormFields.PerformLayout();
            this.pnlFormButtons.ResumeLayout(false);
            this.pnlListArea.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlGridWrap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvUnidades).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlCard1, pnlCard2, pnlCard3;
        private System.Windows.Forms.Panel pnlAccent1, pnlAccent2, pnlAccent3;
        private System.Windows.Forms.Label lblCardVal1, lblCardVal2, lblCardVal3;
        private System.Windows.Forms.Label lblCardTitle1, lblCardTitle2, lblCardTitle3;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Panel pnlFormHeader;
        private System.Windows.Forms.Panel pnlFormAccent;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlFormFields;
        private System.Windows.Forms.Label lblNombreLbl;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblAbreviaturaLbl;
        private System.Windows.Forms.TextBox txtAbreviatura;
        private System.Windows.Forms.Label lblTipoLbl;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblEstadoLbl;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Panel pnlFormButtons;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlSep;
        private System.Windows.Forms.Panel pnlListArea;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblBuscarLbl;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Panel pnlGridWrap;
        private System.Windows.Forms.DataGridView dgvUnidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAbreviatura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.DataGridViewButtonColumn colEliminar;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblMostrar;
    }
}
