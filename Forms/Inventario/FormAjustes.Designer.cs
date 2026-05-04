namespace SistemaPOS.Forms.Inventario
{
    partial class FormAjustes
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
            // ── Declaraciones ────────────────────────────────────────────────────
            this.pnlHeader            = new System.Windows.Forms.Panel();
            this.lblTituloHeader      = new System.Windows.Forms.Label();
            this.lblSubTituloHeader   = new System.Windows.Forms.Label();

            this.pnlLeft              = new System.Windows.Forms.Panel();
            // Sección 1 — Datos
            this.lblSec1              = new System.Windows.Forms.Label();
            this.pnlSec1Bar           = new System.Windows.Forms.Panel();
            this.lblProductoField     = new System.Windows.Forms.Label();
            this.cmbBuscarProducto    = new System.Windows.Forms.ComboBox();
            this.lblFechaField        = new System.Windows.Forms.Label();
            this.dtpFecha             = new System.Windows.Forms.DateTimePicker();
            // Sección 2 — Tipo y Cantidad
            this.pnlSep1              = new System.Windows.Forms.Panel();
            this.lblSec2              = new System.Windows.Forms.Label();
            this.pnlSec2Bar           = new System.Windows.Forms.Panel();
            this.rbEntrada            = new System.Windows.Forms.RadioButton();
            this.rbSalida             = new System.Windows.Forms.RadioButton();
            this.lblCantidadField     = new System.Windows.Forms.Label();
            this.numCantidadAjustar   = new System.Windows.Forms.NumericUpDown();
            // Sección 3 — Motivo
            this.pnlSep2              = new System.Windows.Forms.Panel();
            this.lblSec3              = new System.Windows.Forms.Label();
            this.pnlSec3Bar           = new System.Windows.Forms.Panel();
            this.rbInventarioFisico   = new System.Windows.Forms.RadioButton();
            this.rbProductoDañado     = new System.Windows.Forms.RadioButton();
            this.rbErrorAnterior      = new System.Windows.Forms.RadioButton();
            this.rbDevolucionCliente  = new System.Windows.Forms.RadioButton();
            this.rbOtros              = new System.Windows.Forms.RadioButton();
            this.lblMotivoObs         = new System.Windows.Forms.Label();
            this.txtMotivo            = new System.Windows.Forms.TextBox();

            this.pnlRight             = new System.Windows.Forms.Panel();
            // Tarjeta producto
            this.lblResumenTitle      = new System.Windows.Forms.Label();
            this.pnlResBar            = new System.Windows.Forms.Panel();
            this.lblNombreProducto    = new System.Windows.Forms.Label();
            this.lblInfoProducto      = new System.Windows.Forms.Label();
            // Tiles
            this.pnlTileActual        = new System.Windows.Forms.Panel();
            this.lblTitleActual       = new System.Windows.Forms.Label();
            this.txtStockActualResumen= new System.Windows.Forms.TextBox();
            this.lblArrow1            = new System.Windows.Forms.Label();
            this.pnlTileDelta         = new System.Windows.Forms.Panel();
            this.lblTitleDelta        = new System.Windows.Forms.Label();
            this.txtAjuste            = new System.Windows.Forms.TextBox();
            this.lblArrow2            = new System.Windows.Forms.Label();
            this.pnlTileNuevo         = new System.Windows.Forms.Panel();
            this.lblTitleNuevo        = new System.Windows.Forms.Label();
            this.txtNuevoStock        = new System.Windows.Forms.TextBox();
            // Historial
            this.lblHistorialTitle    = new System.Windows.Forms.Label();
            this.pnlHistBar           = new System.Windows.Forms.Panel();
            this.dgvHistorialProducto = new System.Windows.Forms.DataGridView();

            this.pnlFooter            = new System.Windows.Forms.Panel();
            this.pnlFooterSep         = new System.Windows.Forms.Panel();
            this.btnCancelar          = new System.Windows.Forms.Button();
            this.btnGuardarAjuste     = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadAjustar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialProducto)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlTileActual.SuspendLayout();
            this.pnlTileDelta.SuspendLayout();
            this.pnlTileNuevo.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // ════════════════════════════════════════════════════════════════════
            // pnlHeader
            // ════════════════════════════════════════════════════════════════════
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 36, 40);
            this.pnlHeader.Controls.Add(this.lblSubTituloHeader);
            this.pnlHeader.Controls.Add(this.lblTituloHeader);
            this.pnlHeader.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name     = "pnlHeader";
            this.pnlHeader.Size     = new System.Drawing.Size(1280, 80);
            this.pnlHeader.TabIndex = 0;

            this.lblTituloHeader.AutoSize  = false;
            this.lblTituloHeader.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location  = new System.Drawing.Point(20, 12);
            this.lblTituloHeader.Name      = "lblTituloHeader";
            this.lblTituloHeader.Size      = new System.Drawing.Size(600, 32);
            this.lblTituloHeader.TabIndex  = 0;
            this.lblTituloHeader.Text      = "Ajuste de Inventario";
            this.lblTituloHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblSubTituloHeader.AutoSize  = true;
            this.lblSubTituloHeader.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTituloHeader.ForeColor = System.Drawing.Color.FromArgb(140, 160, 170);
            this.lblSubTituloHeader.Location  = new System.Drawing.Point(22, 50);
            this.lblSubTituloHeader.Name      = "lblSubTituloHeader";
            this.lblSubTituloHeader.TabIndex  = 1;
            this.lblSubTituloHeader.Text      = "Registra entradas, salidas y correcciones de stock";

            // ════════════════════════════════════════════════════════════════════
            // pnlFooter
            // ════════════════════════════════════════════════════════════════════
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.pnlFooterSep);
            this.pnlFooter.Controls.Add(this.btnCancelar);
            this.pnlFooter.Controls.Add(this.btnGuardarAjuste);
            this.pnlFooter.Dock     = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 690);
            this.pnlFooter.Name     = "pnlFooter";
            this.pnlFooter.Size     = new System.Drawing.Size(1280, 70);
            this.pnlFooter.TabIndex = 3;

            this.pnlFooterSep.BackColor = System.Drawing.Color.FromArgb(220, 224, 230);
            this.pnlFooterSep.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlFooterSep.Name      = "pnlFooterSep";
            this.pnlFooterSep.Size      = new System.Drawing.Size(1280, 1);
            this.pnlFooterSep.TabIndex  = 0;

            // btnGuardarAjuste — primary green
            this.btnGuardarAjuste.Anchor    = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarAjuste.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnGuardarAjuste.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarAjuste.FlatAppearance.BorderSize          = 0;
            this.btnGuardarAjuste.FlatAppearance.MouseOverBackColor  = System.Drawing.Color.FromArgb(30, 140, 75);
            this.btnGuardarAjuste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarAjuste.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarAjuste.ForeColor = System.Drawing.Color.White;
            this.btnGuardarAjuste.Location  = new System.Drawing.Point(970, 16);
            this.btnGuardarAjuste.Name      = "btnGuardarAjuste";
            this.btnGuardarAjuste.Size      = new System.Drawing.Size(160, 38);
            this.btnGuardarAjuste.TabIndex  = 1;
            this.btnGuardarAjuste.Text      = "Guardar Ajuste";
            this.btnGuardarAjuste.UseVisualStyleBackColor = false;

            // btnCancelar — secondary
            this.btnCancelar.Anchor    = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor        = System.Drawing.Color.FromArgb(200, 210, 220);
            this.btnCancelar.FlatAppearance.BorderSize         = 1;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 246, 250);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(100, 110, 120);
            this.btnCancelar.Location  = new System.Drawing.Point(1142, 16);
            this.btnCancelar.Name      = "btnCancelar";
            this.btnCancelar.Size      = new System.Drawing.Size(114, 38);
            this.btnCancelar.TabIndex  = 2;
            this.btnCancelar.Text      = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;

            // ════════════════════════════════════════════════════════════════════
            // pnlLeft
            // ════════════════════════════════════════════════════════════════════
            this.pnlLeft.Anchor    = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.lblSec1);
            this.pnlLeft.Controls.Add(this.pnlSec1Bar);
            this.pnlLeft.Controls.Add(this.lblProductoField);
            this.pnlLeft.Controls.Add(this.cmbBuscarProducto);
            this.pnlLeft.Controls.Add(this.lblFechaField);
            this.pnlLeft.Controls.Add(this.dtpFecha);
            this.pnlLeft.Controls.Add(this.pnlSep1);
            this.pnlLeft.Controls.Add(this.lblSec2);
            this.pnlLeft.Controls.Add(this.pnlSec2Bar);
            this.pnlLeft.Controls.Add(this.rbEntrada);
            this.pnlLeft.Controls.Add(this.rbSalida);
            this.pnlLeft.Controls.Add(this.lblCantidadField);
            this.pnlLeft.Controls.Add(this.numCantidadAjustar);
            this.pnlLeft.Controls.Add(this.pnlSep2);
            this.pnlLeft.Controls.Add(this.lblSec3);
            this.pnlLeft.Controls.Add(this.pnlSec3Bar);
            this.pnlLeft.Controls.Add(this.rbInventarioFisico);
            this.pnlLeft.Controls.Add(this.rbProductoDañado);
            this.pnlLeft.Controls.Add(this.rbErrorAnterior);
            this.pnlLeft.Controls.Add(this.rbDevolucionCliente);
            this.pnlLeft.Controls.Add(this.rbOtros);
            this.pnlLeft.Controls.Add(this.lblMotivoObs);
            this.pnlLeft.Controls.Add(this.txtMotivo);
            this.pnlLeft.Location  = new System.Drawing.Point(25, 104);
            this.pnlLeft.Name      = "pnlLeft";
            this.pnlLeft.Size      = new System.Drawing.Size(560, 556);
            this.pnlLeft.TabIndex  = 10;

            // ── Sección 1: DATOS DEL AJUSTE ──────────────────────────────────────
            this.lblSec1.AutoSize  = false;
            this.lblSec1.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSec1.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblSec1.Location  = new System.Drawing.Point(20, 18);
            this.lblSec1.Name      = "lblSec1";
            this.lblSec1.Size      = new System.Drawing.Size(520, 18);
            this.lblSec1.TabIndex  = 0;
            this.lblSec1.Text      = "DATOS DEL AJUSTE";

            this.pnlSec1Bar.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.pnlSec1Bar.Location  = new System.Drawing.Point(20, 38);
            this.pnlSec1Bar.Name      = "pnlSec1Bar";
            this.pnlSec1Bar.Size      = new System.Drawing.Size(520, 2);
            this.pnlSec1Bar.TabIndex  = 1;

            this.lblProductoField.AutoSize  = true;
            this.lblProductoField.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblProductoField.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblProductoField.Location  = new System.Drawing.Point(20, 52);
            this.lblProductoField.Name      = "lblProductoField";
            this.lblProductoField.TabIndex  = 2;
            this.lblProductoField.Text      = "PRODUCTO";

            this.cmbBuscarProducto.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuscarProducto.Font              = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbBuscarProducto.FormattingEnabled = true;
            this.cmbBuscarProducto.Location          = new System.Drawing.Point(20, 70);
            this.cmbBuscarProducto.Name              = "cmbBuscarProducto";
            this.cmbBuscarProducto.Size              = new System.Drawing.Size(518, 25);
            this.cmbBuscarProducto.TabIndex          = 3;

            this.lblFechaField.AutoSize  = true;
            this.lblFechaField.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblFechaField.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblFechaField.Location  = new System.Drawing.Point(20, 108);
            this.lblFechaField.Name      = "lblFechaField";
            this.lblFechaField.TabIndex  = 4;
            this.lblFechaField.Text      = "FECHA DEL AJUSTE";

            this.dtpFecha.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFecha.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(20, 126);
            this.dtpFecha.Name     = "dtpFecha";
            this.dtpFecha.Size     = new System.Drawing.Size(200, 25);
            this.dtpFecha.TabIndex = 5;

            // ── Separador ────────────────────────────────────────────────────────
            this.pnlSep1.BackColor = System.Drawing.Color.FromArgb(220, 224, 230);
            this.pnlSep1.Location  = new System.Drawing.Point(20, 168);
            this.pnlSep1.Name      = "pnlSep1";
            this.pnlSep1.Size      = new System.Drawing.Size(520, 1);
            this.pnlSep1.TabIndex  = 6;

            // ── Sección 2: TIPO Y CANTIDAD ────────────────────────────────────────
            this.lblSec2.AutoSize  = false;
            this.lblSec2.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSec2.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblSec2.Location  = new System.Drawing.Point(20, 180);
            this.lblSec2.Name      = "lblSec2";
            this.lblSec2.Size      = new System.Drawing.Size(520, 18);
            this.lblSec2.TabIndex  = 7;
            this.lblSec2.Text      = "TIPO DE AJUSTE";

            this.pnlSec2Bar.BackColor = System.Drawing.Color.FromArgb(9, 132, 227);
            this.pnlSec2Bar.Location  = new System.Drawing.Point(20, 200);
            this.pnlSec2Bar.Name      = "pnlSec2Bar";
            this.pnlSec2Bar.Size      = new System.Drawing.Size(520, 2);
            this.pnlSec2Bar.TabIndex  = 8;

            // rbEntrada — toggle card verde
            this.rbEntrada.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbEntrada.BackColor  = System.Drawing.Color.FromArgb(39, 174, 96);
            this.rbEntrada.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.rbEntrada.FlatAppearance.BorderColor        = System.Drawing.Color.FromArgb(39, 174, 96);
            this.rbEntrada.FlatAppearance.BorderSize         = 0;
            this.rbEntrada.FlatAppearance.CheckedBackColor   = System.Drawing.Color.FromArgb(39, 174, 96);
            this.rbEntrada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 150, 80);
            this.rbEntrada.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.rbEntrada.Font       = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.rbEntrada.ForeColor  = System.Drawing.Color.White;
            this.rbEntrada.Location   = new System.Drawing.Point(20, 212);
            this.rbEntrada.Name       = "rbEntrada";
            this.rbEntrada.Size       = new System.Drawing.Size(246, 60);
            this.rbEntrada.TabIndex   = 9;
            this.rbEntrada.Text       = "▲  ENTRADA  (+)";
            this.rbEntrada.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbEntrada.UseVisualStyleBackColor = false;

            // rbSalida — toggle card rojo
            this.rbSalida.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbSalida.BackColor  = System.Drawing.Color.FromArgb(245, 247, 250);
            this.rbSalida.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.rbSalida.FlatAppearance.BorderColor        = System.Drawing.Color.FromArgb(220, 224, 230);
            this.rbSalida.FlatAppearance.BorderSize         = 1;
            this.rbSalida.FlatAppearance.CheckedBackColor   = System.Drawing.Color.FromArgb(192, 57, 43);
            this.rbSalida.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.rbSalida.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.rbSalida.Font       = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.rbSalida.ForeColor  = System.Drawing.Color.FromArgb(192, 57, 43);
            this.rbSalida.Location   = new System.Drawing.Point(290, 212);
            this.rbSalida.Name       = "rbSalida";
            this.rbSalida.Size       = new System.Drawing.Size(248, 60);
            this.rbSalida.TabIndex   = 10;
            this.rbSalida.Text       = "▼  SALIDA  (−)";
            this.rbSalida.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbSalida.UseVisualStyleBackColor = false;

            this.lblCantidadField.AutoSize  = true;
            this.lblCantidadField.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCantidadField.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblCantidadField.Location  = new System.Drawing.Point(20, 286);
            this.lblCantidadField.Name      = "lblCantidadField";
            this.lblCantidadField.TabIndex  = 11;
            this.lblCantidadField.Text      = "CANTIDAD A AJUSTAR";

            this.numCantidadAjustar.DecimalPlaces = 2;
            this.numCantidadAjustar.Font          = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.numCantidadAjustar.Location      = new System.Drawing.Point(20, 304);
            this.numCantidadAjustar.Maximum       = new decimal(new int[] { 99999, 0, 0, 0 });
            this.numCantidadAjustar.Minimum       = new decimal(new int[] { 0, 0, 0, 0 });
            this.numCantidadAjustar.Name          = "numCantidadAjustar";
            this.numCantidadAjustar.Size          = new System.Drawing.Size(200, 34);
            this.numCantidadAjustar.TabIndex      = 12;
            this.numCantidadAjustar.Value         = new decimal(new int[] { 0, 0, 0, 0 });

            // ── Separador ────────────────────────────────────────────────────────
            this.pnlSep2.BackColor = System.Drawing.Color.FromArgb(220, 224, 230);
            this.pnlSep2.Location  = new System.Drawing.Point(20, 354);
            this.pnlSep2.Name      = "pnlSep2";
            this.pnlSep2.Size      = new System.Drawing.Size(520, 1);
            this.pnlSep2.TabIndex  = 13;

            // ── Sección 3: MOTIVO DEL AJUSTE ─────────────────────────────────────
            this.lblSec3.AutoSize  = false;
            this.lblSec3.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSec3.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblSec3.Location  = new System.Drawing.Point(20, 366);
            this.lblSec3.Name      = "lblSec3";
            this.lblSec3.Size      = new System.Drawing.Size(520, 18);
            this.lblSec3.TabIndex  = 14;
            this.lblSec3.Text      = "MOTIVO DEL AJUSTE";

            this.pnlSec3Bar.BackColor = System.Drawing.Color.FromArgb(108, 92, 231);
            this.pnlSec3Bar.Location  = new System.Drawing.Point(20, 386);
            this.pnlSec3Bar.Name      = "pnlSec3Bar";
            this.pnlSec3Bar.Size      = new System.Drawing.Size(520, 2);
            this.pnlSec3Bar.TabIndex  = 15;

            // RadioButtons de motivo
            System.Drawing.Font fontRadio = new System.Drawing.Font("Segoe UI", 9F);
            System.Drawing.Color colorRadio = System.Drawing.Color.FromArgb(45, 52, 54);

            this.rbInventarioFisico.AutoSize  = true;
            this.rbInventarioFisico.Font      = fontRadio;
            this.rbInventarioFisico.ForeColor = colorRadio;
            this.rbInventarioFisico.Location  = new System.Drawing.Point(20, 400);
            this.rbInventarioFisico.Name      = "rbInventarioFisico";
            this.rbInventarioFisico.Size      = new System.Drawing.Size(300, 19);
            this.rbInventarioFisico.TabIndex  = 16;
            this.rbInventarioFisico.Text      = "Inventario físico (diferencia encontrada)";
            this.rbInventarioFisico.UseVisualStyleBackColor = true;

            this.rbProductoDañado.AutoSize  = true;
            this.rbProductoDañado.Font      = fontRadio;
            this.rbProductoDañado.ForeColor = colorRadio;
            this.rbProductoDañado.Location  = new System.Drawing.Point(20, 424);
            this.rbProductoDañado.Name      = "rbProductoDañado";
            this.rbProductoDañado.Size      = new System.Drawing.Size(300, 19);
            this.rbProductoDañado.TabIndex  = 17;
            this.rbProductoDañado.Text      = "Producto dañado / Merma";
            this.rbProductoDañado.UseVisualStyleBackColor = true;

            this.rbErrorAnterior.AutoSize  = true;
            this.rbErrorAnterior.Font      = fontRadio;
            this.rbErrorAnterior.ForeColor = colorRadio;
            this.rbErrorAnterior.Location  = new System.Drawing.Point(20, 448);
            this.rbErrorAnterior.Name      = "rbErrorAnterior";
            this.rbErrorAnterior.Size      = new System.Drawing.Size(300, 19);
            this.rbErrorAnterior.TabIndex  = 18;
            this.rbErrorAnterior.Text      = "Error en registro anterior";
            this.rbErrorAnterior.UseVisualStyleBackColor = true;

            this.rbDevolucionCliente.AutoSize  = true;
            this.rbDevolucionCliente.Font      = fontRadio;
            this.rbDevolucionCliente.ForeColor = colorRadio;
            this.rbDevolucionCliente.Location  = new System.Drawing.Point(20, 472);
            this.rbDevolucionCliente.Name      = "rbDevolucionCliente";
            this.rbDevolucionCliente.Size      = new System.Drawing.Size(300, 19);
            this.rbDevolucionCliente.TabIndex  = 19;
            this.rbDevolucionCliente.Text      = "Devolución de cliente";
            this.rbDevolucionCliente.UseVisualStyleBackColor = true;

            this.rbOtros.AutoSize  = true;
            this.rbOtros.Font      = fontRadio;
            this.rbOtros.ForeColor = colorRadio;
            this.rbOtros.Location  = new System.Drawing.Point(20, 496);
            this.rbOtros.Name      = "rbOtros";
            this.rbOtros.Size      = new System.Drawing.Size(300, 19);
            this.rbOtros.TabIndex  = 20;
            this.rbOtros.Text      = "Otros (especificar abajo)";
            this.rbOtros.UseVisualStyleBackColor = true;

            this.lblMotivoObs.AutoSize  = true;
            this.lblMotivoObs.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblMotivoObs.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblMotivoObs.Location  = new System.Drawing.Point(20, 526);
            this.lblMotivoObs.Name      = "lblMotivoObs";
            this.lblMotivoObs.TabIndex  = 21;
            this.lblMotivoObs.Text      = "OBSERVACIONES (solo para \"Otros\")";

            this.txtMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotivo.Enabled     = false;
            this.txtMotivo.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMotivo.Location    = new System.Drawing.Point(20, 544);
            this.txtMotivo.Multiline   = true;
            this.txtMotivo.Name        = "txtMotivo";
            this.txtMotivo.Size        = new System.Drawing.Size(518, 0);
            this.txtMotivo.TabIndex    = 22;

            // ════════════════════════════════════════════════════════════════════
            // pnlRight
            // ════════════════════════════════════════════════════════════════════
            this.pnlRight.Anchor    = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.lblResumenTitle);
            this.pnlRight.Controls.Add(this.pnlResBar);
            this.pnlRight.Controls.Add(this.lblNombreProducto);
            this.pnlRight.Controls.Add(this.lblInfoProducto);
            this.pnlRight.Controls.Add(this.pnlTileActual);
            this.pnlRight.Controls.Add(this.lblArrow1);
            this.pnlRight.Controls.Add(this.pnlTileDelta);
            this.pnlRight.Controls.Add(this.lblArrow2);
            this.pnlRight.Controls.Add(this.pnlTileNuevo);
            this.pnlRight.Controls.Add(this.lblHistorialTitle);
            this.pnlRight.Controls.Add(this.pnlHistBar);
            this.pnlRight.Controls.Add(this.dgvHistorialProducto);
            this.pnlRight.Location  = new System.Drawing.Point(609, 104);
            this.pnlRight.Name      = "pnlRight";
            this.pnlRight.Size      = new System.Drawing.Size(646, 556);
            this.pnlRight.TabIndex  = 11;

            // ── Cabecera ──────────────────────────────────────────────────────────
            this.lblResumenTitle.AutoSize  = false;
            this.lblResumenTitle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblResumenTitle.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblResumenTitle.Location  = new System.Drawing.Point(20, 18);
            this.lblResumenTitle.Name      = "lblResumenTitle";
            this.lblResumenTitle.Size      = new System.Drawing.Size(606, 18);
            this.lblResumenTitle.TabIndex  = 0;
            this.lblResumenTitle.Text      = "RESUMEN DEL AJUSTE";

            this.pnlResBar.BackColor = System.Drawing.Color.FromArgb(108, 92, 231);
            this.pnlResBar.Location  = new System.Drawing.Point(20, 38);
            this.pnlResBar.Name      = "pnlResBar";
            this.pnlResBar.Size      = new System.Drawing.Size(606, 2);
            this.pnlResBar.TabIndex  = 1;

            // ── Tarjeta de producto ───────────────────────────────────────────────
            this.lblNombreProducto.AutoSize    = false;
            this.lblNombreProducto.Font        = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblNombreProducto.ForeColor   = System.Drawing.Color.FromArgb(67, 97, 238);
            this.lblNombreProducto.Location    = new System.Drawing.Point(20, 50);
            this.lblNombreProducto.Name        = "lblNombreProducto";
            this.lblNombreProducto.Size        = new System.Drawing.Size(606, 28);
            this.lblNombreProducto.TabIndex    = 2;
            this.lblNombreProducto.Text        = "— Seleccione un producto —";
            this.lblNombreProducto.TextAlign   = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblInfoProducto.AutoSize    = false;
            this.lblInfoProducto.Font        = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblInfoProducto.ForeColor   = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblInfoProducto.Location    = new System.Drawing.Point(20, 80);
            this.lblInfoProducto.Name        = "lblInfoProducto";
            this.lblInfoProducto.Size        = new System.Drawing.Size(606, 18);
            this.lblInfoProducto.TabIndex    = 3;
            this.lblInfoProducto.Text        = "";
            this.lblInfoProducto.TextAlign   = System.Drawing.ContentAlignment.MiddleLeft;

            // ── Tiles: Stock Actual → Ajuste → Nuevo Stock ────────────────────────
            // Tile STOCK ACTUAL (X=20, W=184)
            this.pnlTileActual.BackColor   = System.Drawing.Color.White;
            this.pnlTileActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTileActual.Controls.Add(this.lblTitleActual);
            this.pnlTileActual.Controls.Add(this.txtStockActualResumen);
            this.pnlTileActual.Location    = new System.Drawing.Point(20, 110);
            this.pnlTileActual.Name        = "pnlTileActual";
            this.pnlTileActual.Size        = new System.Drawing.Size(184, 120);
            this.pnlTileActual.TabIndex    = 4;

            this.lblTitleActual.AutoSize  = false;
            this.lblTitleActual.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblTitleActual.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblTitleActual.Location  = new System.Drawing.Point(0, 10);
            this.lblTitleActual.Name      = "lblTitleActual";
            this.lblTitleActual.Size      = new System.Drawing.Size(184, 16);
            this.lblTitleActual.TabIndex  = 0;
            this.lblTitleActual.Text      = "STOCK ACTUAL";
            this.lblTitleActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.txtStockActualResumen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStockActualResumen.Font        = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.txtStockActualResumen.ForeColor   = System.Drawing.Color.FromArgb(45, 52, 54);
            this.txtStockActualResumen.Location    = new System.Drawing.Point(8, 38);
            this.txtStockActualResumen.Name        = "txtStockActualResumen";
            this.txtStockActualResumen.ReadOnly    = true;
            this.txtStockActualResumen.Size        = new System.Drawing.Size(168, 42);
            this.txtStockActualResumen.TabIndex    = 1;
            this.txtStockActualResumen.TabStop     = false;
            this.txtStockActualResumen.TextAlign   = System.Windows.Forms.HorizontalAlignment.Center;

            // Flecha 1
            this.lblArrow1.AutoSize  = true;
            this.lblArrow1.Font      = new System.Drawing.Font("Segoe UI", 22F);
            this.lblArrow1.ForeColor = System.Drawing.Color.FromArgb(180, 190, 200);
            this.lblArrow1.Location  = new System.Drawing.Point(211, 154);
            this.lblArrow1.Name      = "lblArrow1";
            this.lblArrow1.TabIndex  = 5;
            this.lblArrow1.Text      = "›";

            // Tile AJUSTE (X=232, W=184)
            this.pnlTileDelta.BackColor   = System.Drawing.Color.White;
            this.pnlTileDelta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTileDelta.Controls.Add(this.lblTitleDelta);
            this.pnlTileDelta.Controls.Add(this.txtAjuste);
            this.pnlTileDelta.Location    = new System.Drawing.Point(232, 110);
            this.pnlTileDelta.Name        = "pnlTileDelta";
            this.pnlTileDelta.Size        = new System.Drawing.Size(184, 120);
            this.pnlTileDelta.TabIndex    = 6;

            this.lblTitleDelta.AutoSize  = false;
            this.lblTitleDelta.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblTitleDelta.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblTitleDelta.Location  = new System.Drawing.Point(0, 10);
            this.lblTitleDelta.Name      = "lblTitleDelta";
            this.lblTitleDelta.Size      = new System.Drawing.Size(184, 16);
            this.lblTitleDelta.TabIndex  = 0;
            this.lblTitleDelta.Text      = "AJUSTE";
            this.lblTitleDelta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.txtAjuste.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAjuste.Font        = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.txtAjuste.ForeColor   = System.Drawing.Color.FromArgb(45, 52, 54);
            this.txtAjuste.Location    = new System.Drawing.Point(8, 38);
            this.txtAjuste.Name        = "txtAjuste";
            this.txtAjuste.ReadOnly    = true;
            this.txtAjuste.Size        = new System.Drawing.Size(168, 42);
            this.txtAjuste.TabIndex    = 1;
            this.txtAjuste.TabStop     = false;
            this.txtAjuste.TextAlign   = System.Windows.Forms.HorizontalAlignment.Center;

            // Flecha 2
            this.lblArrow2.AutoSize  = true;
            this.lblArrow2.Font      = new System.Drawing.Font("Segoe UI", 22F);
            this.lblArrow2.ForeColor = System.Drawing.Color.FromArgb(180, 190, 200);
            this.lblArrow2.Location  = new System.Drawing.Point(423, 154);
            this.lblArrow2.Name      = "lblArrow2";
            this.lblArrow2.TabIndex  = 7;
            this.lblArrow2.Text      = "›";

            // Tile NUEVO STOCK (X=444, W=182)
            this.pnlTileNuevo.BackColor   = System.Drawing.Color.White;
            this.pnlTileNuevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTileNuevo.Controls.Add(this.lblTitleNuevo);
            this.pnlTileNuevo.Controls.Add(this.txtNuevoStock);
            this.pnlTileNuevo.Location    = new System.Drawing.Point(444, 110);
            this.pnlTileNuevo.Name        = "pnlTileNuevo";
            this.pnlTileNuevo.Size        = new System.Drawing.Size(182, 120);
            this.pnlTileNuevo.TabIndex    = 8;

            this.lblTitleNuevo.AutoSize  = false;
            this.lblTitleNuevo.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblTitleNuevo.ForeColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.lblTitleNuevo.Location  = new System.Drawing.Point(0, 10);
            this.lblTitleNuevo.Name      = "lblTitleNuevo";
            this.lblTitleNuevo.Size      = new System.Drawing.Size(182, 16);
            this.lblTitleNuevo.TabIndex  = 0;
            this.lblTitleNuevo.Text      = "NUEVO STOCK";
            this.lblTitleNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.txtNuevoStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNuevoStock.Font        = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.txtNuevoStock.ForeColor   = System.Drawing.Color.FromArgb(45, 52, 54);
            this.txtNuevoStock.Location    = new System.Drawing.Point(8, 38);
            this.txtNuevoStock.Name        = "txtNuevoStock";
            this.txtNuevoStock.ReadOnly    = true;
            this.txtNuevoStock.Size        = new System.Drawing.Size(166, 42);
            this.txtNuevoStock.TabIndex    = 1;
            this.txtNuevoStock.TabStop     = false;
            this.txtNuevoStock.TextAlign   = System.Windows.Forms.HorizontalAlignment.Center;

            // ── Historial del producto ────────────────────────────────────────────
            this.lblHistorialTitle.AutoSize  = false;
            this.lblHistorialTitle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHistorialTitle.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblHistorialTitle.Location  = new System.Drawing.Point(20, 248);
            this.lblHistorialTitle.Name      = "lblHistorialTitle";
            this.lblHistorialTitle.Size      = new System.Drawing.Size(606, 18);
            this.lblHistorialTitle.TabIndex  = 9;
            this.lblHistorialTitle.Text      = "ÚLTIMOS AJUSTES DE ESTE PRODUCTO";

            this.pnlHistBar.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.pnlHistBar.Location  = new System.Drawing.Point(20, 268);
            this.pnlHistBar.Name      = "pnlHistBar";
            this.pnlHistBar.Size      = new System.Drawing.Size(606, 2);
            this.pnlHistBar.TabIndex  = 10;

            // dgvHistorialProducto
            this.dgvHistorialProducto.AllowUserToAddRows          = false;
            this.dgvHistorialProducto.AllowUserToDeleteRows       = false;
            this.dgvHistorialProducto.AllowUserToResizeRows       = false;
            this.dgvHistorialProducto.Anchor                      = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorialProducto.BackgroundColor             = System.Drawing.Color.FromArgb(248, 249, 250);
            this.dgvHistorialProducto.BorderStyle                 = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorialProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialProducto.Location                    = new System.Drawing.Point(20, 278);
            this.dgvHistorialProducto.MultiSelect                 = false;
            this.dgvHistorialProducto.Name                        = "dgvHistorialProducto";
            this.dgvHistorialProducto.ReadOnly                    = true;
            this.dgvHistorialProducto.RowHeadersVisible           = false;
            this.dgvHistorialProducto.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorialProducto.Size                        = new System.Drawing.Size(606, 258);
            this.dgvHistorialProducto.TabIndex                    = 11;
            this.dgvHistorialProducto.TabStop                     = false;

            // ════════════════════════════════════════════════════════════════════
            // FormAjustes
            // ════════════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(244, 246, 250);
            this.ClientSize          = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize         = new System.Drawing.Size(900, 600);
            this.Name                = "FormAjustes";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Ajuste de Inventario";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadAjustar)).EndInit();
            this.pnlTileActual.ResumeLayout(false);
            this.pnlTileActual.PerformLayout();
            this.pnlTileDelta.ResumeLayout(false);
            this.pnlTileDelta.PerformLayout();
            this.pnlTileNuevo.ResumeLayout(false);
            this.pnlTileNuevo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialProducto)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ── Declaraciones privadas ───────────────────────────────────────────────
        private System.Windows.Forms.Panel     pnlHeader;
        private System.Windows.Forms.Label     lblTituloHeader;
        private System.Windows.Forms.Label     lblSubTituloHeader;

        private System.Windows.Forms.Panel     pnlLeft;
        private System.Windows.Forms.Label     lblSec1;
        private System.Windows.Forms.Panel     pnlSec1Bar;
        private System.Windows.Forms.Label     lblProductoField;
        private System.Windows.Forms.ComboBox  cmbBuscarProducto;
        private System.Windows.Forms.Label     lblFechaField;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Panel     pnlSep1;
        private System.Windows.Forms.Label     lblSec2;
        private System.Windows.Forms.Panel     pnlSec2Bar;
        private System.Windows.Forms.RadioButton rbEntrada;
        private System.Windows.Forms.RadioButton rbSalida;
        private System.Windows.Forms.Label     lblCantidadField;
        private System.Windows.Forms.NumericUpDown numCantidadAjustar;
        private System.Windows.Forms.Panel     pnlSep2;
        private System.Windows.Forms.Label     lblSec3;
        private System.Windows.Forms.Panel     pnlSec3Bar;
        private System.Windows.Forms.RadioButton rbInventarioFisico;
        private System.Windows.Forms.RadioButton rbProductoDañado;
        private System.Windows.Forms.RadioButton rbErrorAnterior;
        private System.Windows.Forms.RadioButton rbDevolucionCliente;
        private System.Windows.Forms.RadioButton rbOtros;
        private System.Windows.Forms.Label     lblMotivoObs;
        private System.Windows.Forms.TextBox   txtMotivo;

        private System.Windows.Forms.Panel     pnlRight;
        private System.Windows.Forms.Label     lblResumenTitle;
        private System.Windows.Forms.Panel     pnlResBar;
        private System.Windows.Forms.Label     lblNombreProducto;
        private System.Windows.Forms.Label     lblInfoProducto;
        private System.Windows.Forms.Panel     pnlTileActual;
        private System.Windows.Forms.Label     lblTitleActual;
        private System.Windows.Forms.TextBox   txtStockActualResumen;
        private System.Windows.Forms.Label     lblArrow1;
        private System.Windows.Forms.Panel     pnlTileDelta;
        private System.Windows.Forms.Label     lblTitleDelta;
        private System.Windows.Forms.TextBox   txtAjuste;
        private System.Windows.Forms.Label     lblArrow2;
        private System.Windows.Forms.Panel     pnlTileNuevo;
        private System.Windows.Forms.Label     lblTitleNuevo;
        private System.Windows.Forms.TextBox   txtNuevoStock;
        private System.Windows.Forms.Label     lblHistorialTitle;
        private System.Windows.Forms.Panel     pnlHistBar;
        private System.Windows.Forms.DataGridView dgvHistorialProducto;

        private System.Windows.Forms.Panel     pnlFooter;
        private System.Windows.Forms.Panel     pnlFooterSep;
        private System.Windows.Forms.Button    btnGuardarAjuste;
        private System.Windows.Forms.Button    btnCancelar;
    }
}
