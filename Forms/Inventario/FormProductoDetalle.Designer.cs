namespace SistemaPOS.Forms.Inventario
{
    partial class FormProductoDetalle
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
            var dgvAlt    = new System.Windows.Forms.DataGridViewCellStyle();
            var dgvHdr    = new System.Windows.Forms.DataGridViewCellStyle();
            var dgvCell   = new System.Windows.Forms.DataGridViewCellStyle();
            var dgvRight  = new System.Windows.Forms.DataGridViewCellStyle();
            var dgvCenter = new System.Windows.Forms.DataGridViewCellStyle();

            // ── Declarations ──────────────────────────────────────────────────
            this.pnlHeader       = new System.Windows.Forms.Panel();
            this.pnlHeaderLine   = new System.Windows.Forms.Panel();
            this.pnlIconBox      = new System.Windows.Forms.Panel();
            this.lblIcono        = new System.Windows.Forms.Label();
            this.lblTitulo       = new System.Windows.Forms.Label();
            this.lblSubtitulo    = new System.Windows.Forms.Label();
            this.lblBadge        = new System.Windows.Forms.Label();

            this.pnlFooter       = new System.Windows.Forms.Panel();
            this.pnlFooterLine   = new System.Windows.Forms.Panel();
            this.lblShortcut     = new System.Windows.Forms.Label();
            this.btnCancelar     = new System.Windows.Forms.Button();
            this.btnGuardar      = new System.Windows.Forms.Button();

            this.pnlBody         = new System.Windows.Forms.Panel();

            // Fila principal (imagen izq + formulario der)
            this.pnlTopRow       = new System.Windows.Forms.Panel();

            // ── Tarjeta imagen (izquierda grande) ─────────────────────────────
            this.pnlLeft         = new System.Windows.Forms.Panel();
            this.pnlSec1Hdr      = new System.Windows.Forms.Panel();
            this.pnlAccentInfo   = new System.Windows.Forms.Panel();
            this.lblSeccionInfo  = new System.Windows.Forms.Label();
            this.pnlImgFrame     = new System.Windows.Forms.Panel();
            this.pbImagenProducto = new System.Windows.Forms.PictureBox();
            this.btnCargar       = new System.Windows.Forms.Button();
            this.btnQuitar       = new System.Windows.Forms.Button();

            // Separador imagen–formulario
            this.pnlDivH1        = new System.Windows.Forms.Panel();

            // ── Columna derecha (info + stock apilados) ───────────────────────
            this.pnlRight        = new System.Windows.Forms.Panel();

            // Tarjeta info básica
            this.pnlImagenWrap   = new System.Windows.Forms.Panel();
            this.pnlImgHdr       = new System.Windows.Forms.Panel();
            this.pnlAccentImg    = new System.Windows.Forms.Panel();
            this.lblSeccionImagen = new System.Windows.Forms.Label();
            this.lblCodigo       = new System.Windows.Forms.Label();
            this.txtCodigo       = new System.Windows.Forms.TextBox();
            this.lblProducto     = new System.Windows.Forms.Label();
            this.txtProducto     = new System.Windows.Forms.TextBox();
            this.lblCategoria    = new System.Windows.Forms.Label();
            this.cmbCategoria    = new System.Windows.Forms.ComboBox();
            this.lblUnidadBase   = new System.Windows.Forms.Label();
            this.cmbUnidadBase   = new System.Windows.Forms.ComboBox();
            this.lblProveedor    = new System.Windows.Forms.Label();
            this.cmbProveedor    = new System.Windows.Forms.ComboBox();

            // Gap entre info y stock
            this.pnlDivH2        = new System.Windows.Forms.Panel();

            // Tarjeta stock/inventario
            this.pnlStockCard    = new System.Windows.Forms.Panel();
            this.pnlSec2Hdr      = new System.Windows.Forms.Panel();
            this.pnlAccentInv    = new System.Windows.Forms.Panel();
            this.lblSeccionInv   = new System.Windows.Forms.Label();
            this.pnlStatStock    = new System.Windows.Forms.Panel();
            this.lblStatTitle1   = new System.Windows.Forms.Label();
            this.txtStock        = new System.Windows.Forms.TextBox();
            this.pnlStatMin      = new System.Windows.Forms.Panel();
            this.lblStatTitle2   = new System.Windows.Forms.Label();
            this.txtStockMinimo  = new System.Windows.Forms.TextBox();
            this.pnlStatMax      = new System.Windows.Forms.Panel();
            this.lblStatTitle3   = new System.Windows.Forms.Label();
            this.txtStockMaximo  = new System.Windows.Forms.TextBox();
            this.pnlTip          = new System.Windows.Forms.Panel();
            this.lblTip          = new System.Windows.Forms.Label();
            // reservados (no referenciados en .cs)
            this.lblStock        = new System.Windows.Forms.Label();
            this.lblStockMinimo  = new System.Windows.Forms.Label();
            this.lblStockMaximo  = new System.Windows.Forms.Label();

            // Gap entre fila principal y presentaciones
            this.pnlGap          = new System.Windows.Forms.Panel();

            // ── Tarjeta presentaciones (full-width) ───────────────────────────
            this.pnlPresWrap     = new System.Windows.Forms.Panel();
            this.pnlPresHeader   = new System.Windows.Forms.Panel();
            this.pnlPresHdrBand  = new System.Windows.Forms.Panel();
            this.pnlAccentPres   = new System.Windows.Forms.Panel();
            this.lblSeccionPres  = new System.Windows.Forms.Label();
            this.lblPresentacion = new System.Windows.Forms.Label();
            this.cmbPresentacion = new System.Windows.Forms.ComboBox();
            this.lblCantidad     = new System.Windows.Forms.Label();
            this.txtCantidad     = new System.Windows.Forms.TextBox();
            this.lblCosto        = new System.Windows.Forms.Label();
            this.txtCostoBase    = new System.Windows.Forms.TextBox();
            this.lblPrecio       = new System.Windows.Forms.Label();
            this.txtPrecio       = new System.Windows.Forms.TextBox();
            this.chkPrecioIncluyeIGV = new System.Windows.Forms.CheckBox();
            this.btnAgregarPres  = new System.Windows.Forms.Button();
            this.pnlPresGrid     = new System.Windows.Forms.Panel();
            this.dgvPresentaciones = new System.Windows.Forms.DataGridView();
            this.colPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidadBase   = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCosto        = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGanancia     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIGVPres      = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEliminar     = new System.Windows.Forms.DataGridViewImageColumn();

            // Suspend
            this.pnlHeader.SuspendLayout();
            this.pnlIconBox.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlTopRow.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlSec1Hdr.SuspendLayout();
            this.pnlImgFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenProducto)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlImagenWrap.SuspendLayout();
            this.pnlImgHdr.SuspendLayout();
            this.pnlStockCard.SuspendLayout();
            this.pnlSec2Hdr.SuspendLayout();
            this.pnlStatStock.SuspendLayout();
            this.pnlStatMin.SuspendLayout();
            this.pnlStatMax.SuspendLayout();
            this.pnlTip.SuspendLayout();
            this.pnlPresWrap.SuspendLayout();
            this.pnlPresHeader.SuspendLayout();
            this.pnlPresHdrBand.SuspendLayout();
            this.pnlPresGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresentaciones)).BeginInit();
            this.SuspendLayout();

            // ═════════════════════════════════════════════════════════════════
            // HEADER  — azul corporativo bancario #003087
            // ═════════════════════════════════════════════════════════════════
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 48, 135);
            this.pnlHeader.Controls.Add(this.lblBadge);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.pnlIconBox);
            this.pnlHeader.Controls.Add(this.pnlHeaderLine);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(1020, 70);

            // Línea accent inferior del header (azul más claro)
            this.pnlHeaderLine.BackColor = System.Drawing.Color.FromArgb(66, 133, 244);
            this.pnlHeaderLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHeaderLine.Size = new System.Drawing.Size(1020, 3);

            // Caja del ícono — blanco sobre azul
            this.pnlIconBox.BackColor = System.Drawing.Color.White;
            this.pnlIconBox.Controls.Add(this.lblIcono);
            this.pnlIconBox.Location = new System.Drawing.Point(20, 13);
            this.pnlIconBox.Size = new System.Drawing.Size(44, 44);

            this.lblIcono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIcono.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
            this.lblIcono.ForeColor = System.Drawing.Color.FromArgb(0, 48, 135);
            this.lblIcono.Text = "\U0001F4E6";
            this.lblIcono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(76, 10);
            this.lblTitulo.Text = "Nuevo Producto";

            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(179, 205, 255);
            this.lblSubtitulo.Location = new System.Drawing.Point(76, 38);
            this.lblSubtitulo.Text = "Complete la información del producto";

            this.lblBadge.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblBadge.AutoSize = false;
            this.lblBadge.BackColor = System.Drawing.Color.FromArgb(0, 82, 204);
            this.lblBadge.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblBadge.ForeColor = System.Drawing.Color.FromArgb(179, 217, 255);
            this.lblBadge.Location = new System.Drawing.Point(838, 22);
            this.lblBadge.Size = new System.Drawing.Size(158, 26);
            this.lblBadge.Text = "● NUEVO REGISTRO";
            this.lblBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ═════════════════════════════════════════════════════════════════
            // FOOTER  — blanco limpio, línea sutil arriba
            // ═════════════════════════════════════════════════════════════════
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.lblShortcut);
            this.pnlFooter.Controls.Add(this.btnCancelar);
            this.pnlFooter.Controls.Add(this.btnGuardar);
            this.pnlFooter.Controls.Add(this.pnlFooterLine);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Size = new System.Drawing.Size(1020, 58);

            this.pnlFooterLine.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlFooterLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFooterLine.Size = new System.Drawing.Size(1020, 1);

            this.lblShortcut.AutoSize = true;
            this.lblShortcut.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblShortcut.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            this.lblShortcut.Location = new System.Drawing.Point(20, 21);
            this.lblShortcut.Text = "Ctrl+S  guardar   |   Esc  cancelar";

            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.btnCancelar.FlatAppearance.BorderSize = 1;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.btnCancelar.Location = new System.Drawing.Point(680, 11);
            this.btnCancelar.Size = new System.Drawing.Size(148, 36);
            this.btnCancelar.TabIndex = 50;
            this.btnCancelar.Text = "Cancelar";

            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(0, 48, 135);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 35, 100);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(844, 11);
            this.btnGuardar.Size = new System.Drawing.Size(158, 36);
            this.btnGuardar.TabIndex = 51;
            this.btnGuardar.Text = "Guardar producto";

            // ═════════════════════════════════════════════════════════════════
            // BODY  — fondo azul-gris muy sutil, padding 10
            // ═════════════════════════════════════════════════════════════════
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(240, 244, 250);
            this.pnlBody.Controls.Add(this.pnlPresWrap);
            this.pnlBody.Controls.Add(this.pnlGap);
            this.pnlBody.Controls.Add(this.pnlTopRow);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(10);

            // ─────────────────────────────────────────────────────────────────
            // FILA PRINCIPAL: imagen izquierda grande + formulario derecha
            // ─────────────────────────────────────────────────────────────────
            this.pnlTopRow.BackColor = System.Drawing.Color.FromArgb(240, 244, 250);
            this.pnlTopRow.Controls.Add(this.pnlRight);
            this.pnlTopRow.Controls.Add(this.pnlDivH1);
            this.pnlTopRow.Controls.Add(this.pnlLeft);
            this.pnlTopRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopRow.Size = new System.Drawing.Size(1000, 430);

            // ─── TARJETA IMAGEN (izquierda, 300px) ────────────────────────────
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.btnQuitar);
            this.pnlLeft.Controls.Add(this.btnCargar);
            this.pnlLeft.Controls.Add(this.pnlImgFrame);
            this.pnlLeft.Controls.Add(this.pnlSec1Hdr);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Size = new System.Drawing.Size(316, 430);

            // Encabezado tarjeta imagen
            this.pnlSec1Hdr.BackColor = System.Drawing.Color.White;
            this.pnlSec1Hdr.Controls.Add(this.lblSeccionInfo);
            this.pnlSec1Hdr.Controls.Add(this.pnlAccentInfo);
            this.pnlSec1Hdr.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSec1Hdr.Size = new System.Drawing.Size(316, 40);

            this.pnlAccentInfo.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlAccentInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAccentInfo.Size = new System.Drawing.Size(316, 1);

            this.lblSeccionInfo.AutoSize = false;
            this.lblSeccionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSeccionInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSeccionInfo.ForeColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.lblSeccionInfo.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblSeccionInfo.Text = "Fotografía del producto";
            this.lblSeccionInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Marco de imagen — grande, ocupa la mayor parte de la tarjeta
            this.pnlImgFrame.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlImgFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlImgFrame.Controls.Add(this.pbImagenProducto);
            this.pnlImgFrame.Location = new System.Drawing.Point(14, 48);
            this.pnlImgFrame.Size = new System.Drawing.Size(288, 322);

            this.pbImagenProducto.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pbImagenProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImagenProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagenProducto.TabStop = false;

            // Botones de imagen (compactos, bajo la foto)
            this.btnCargar.BackColor = System.Drawing.Color.White;
            this.btnCargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 48, 135);
            this.btnCargar.FlatAppearance.BorderSize = 1;
            this.btnCargar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(239, 246, 255);
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnCargar.ForeColor = System.Drawing.Color.FromArgb(0, 48, 135);
            this.btnCargar.Location = new System.Drawing.Point(14, 378);
            this.btnCargar.Size = new System.Drawing.Size(138, 30);
            this.btnCargar.TabIndex = 20;
            this.btnCargar.Text = "\U0001F4C2  Cargar foto";

            this.btnQuitar.BackColor = System.Drawing.Color.White;
            this.btnQuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnQuitar.FlatAppearance.BorderSize = 1;
            this.btnQuitar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 245, 246);
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnQuitar.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnQuitar.Location = new System.Drawing.Point(160, 378);
            this.btnQuitar.Size = new System.Drawing.Size(138, 30);
            this.btnQuitar.TabIndex = 21;
            this.btnQuitar.Text = "\U0001F5D1  Quitar foto";

            // Separador imagen – columna formulario
            this.pnlDivH1.BackColor = System.Drawing.Color.FromArgb(240, 244, 250);
            this.pnlDivH1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDivH1.Size = new System.Drawing.Size(10, 430);

            // ─── COLUMNA DERECHA: info + stock apilados ────────────────────────
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(240, 244, 250);
            this.pnlRight.Controls.Add(this.pnlStockCard);
            this.pnlRight.Controls.Add(this.pnlDivH2);
            this.pnlRight.Controls.Add(this.pnlImagenWrap);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;

            // ── Tarjeta "Información básica" ──────────────────────────────────
            this.pnlImagenWrap.BackColor = System.Drawing.Color.White;
            this.pnlImagenWrap.Controls.Add(this.cmbProveedor);
            this.pnlImagenWrap.Controls.Add(this.lblProveedor);
            this.pnlImagenWrap.Controls.Add(this.cmbUnidadBase);
            this.pnlImagenWrap.Controls.Add(this.lblUnidadBase);
            this.pnlImagenWrap.Controls.Add(this.cmbCategoria);
            this.pnlImagenWrap.Controls.Add(this.lblCategoria);
            this.pnlImagenWrap.Controls.Add(this.txtProducto);
            this.pnlImagenWrap.Controls.Add(this.lblProducto);
            this.pnlImagenWrap.Controls.Add(this.txtCodigo);
            this.pnlImagenWrap.Controls.Add(this.lblCodigo);
            this.pnlImagenWrap.Controls.Add(this.pnlImgHdr);
            this.pnlImagenWrap.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlImagenWrap.Size = new System.Drawing.Size(694, 222);

            // Encabezado "Información básica"
            this.pnlImgHdr.BackColor = System.Drawing.Color.White;
            this.pnlImgHdr.Controls.Add(this.lblSeccionImagen);
            this.pnlImgHdr.Controls.Add(this.pnlAccentImg);
            this.pnlImgHdr.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlImgHdr.Size = new System.Drawing.Size(694, 40);

            this.pnlAccentImg.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlAccentImg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAccentImg.Size = new System.Drawing.Size(694, 1);

            this.lblSeccionImagen.AutoSize = false;
            this.lblSeccionImagen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSeccionImagen.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSeccionImagen.ForeColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.lblSeccionImagen.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblSeccionImagen.Text = "Información básica";
            this.lblSeccionImagen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Campos — Fila 1: Código (izq) + Nombre (der)
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblCodigo.Location = new System.Drawing.Point(16, 48);
            this.lblCodigo.Text = "CÓDIGO DEL PRODUCTO";

            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCodigo.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.txtCodigo.Location = new System.Drawing.Point(16, 63);
            this.txtCodigo.Size = new System.Drawing.Size(190, 26);
            this.txtCodigo.TabIndex = 1;

            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblProducto.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblProducto.Location = new System.Drawing.Point(222, 48);
            this.lblProducto.Text = "NOMBRE DEL PRODUCTO  *";

            this.txtProducto.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtProducto.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.txtProducto.Location = new System.Drawing.Point(222, 63);
            this.txtProducto.Size = new System.Drawing.Size(454, 26);
            this.txtProducto.TabIndex = 2;

            // Fila 2: Categoría + Unidad base
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblCategoria.Location = new System.Drawing.Point(16, 104);
            this.lblCategoria.Text = "CATEGORÍA  *";

            this.cmbCategoria.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(16, 119);
            this.cmbCategoria.Size = new System.Drawing.Size(200, 26);
            this.cmbCategoria.TabIndex = 3;

            this.lblUnidadBase.AutoSize = true;
            this.lblUnidadBase.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblUnidadBase.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblUnidadBase.Location = new System.Drawing.Point(232, 104);
            this.lblUnidadBase.Text = "UNIDAD BASE  *";

            this.cmbUnidadBase.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.cmbUnidadBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidadBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUnidadBase.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbUnidadBase.FormattingEnabled = true;
            this.cmbUnidadBase.Location = new System.Drawing.Point(232, 119);
            this.cmbUnidadBase.Size = new System.Drawing.Size(200, 26);
            this.cmbUnidadBase.TabIndex = 4;

            // Fila 3: Proveedor (ancho completo)
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblProveedor.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblProveedor.Location = new System.Drawing.Point(16, 160);
            this.lblProveedor.Text = "PROVEEDOR";

            this.cmbProveedor.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProveedor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(16, 175);
            this.cmbProveedor.Size = new System.Drawing.Size(660, 26);
            this.cmbProveedor.TabIndex = 5;

            // Gap entre info y stock
            this.pnlDivH2.BackColor = System.Drawing.Color.FromArgb(240, 244, 250);
            this.pnlDivH2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDivH2.Size = new System.Drawing.Size(694, 10);

            // ── Tarjeta "Control de inventario" (KPI widgets) ─────────────────
            this.pnlStockCard.BackColor = System.Drawing.Color.White;
            this.pnlStockCard.Controls.Add(this.pnlTip);
            this.pnlStockCard.Controls.Add(this.pnlStatMax);
            this.pnlStockCard.Controls.Add(this.pnlStatMin);
            this.pnlStockCard.Controls.Add(this.pnlStatStock);
            this.pnlStockCard.Controls.Add(this.pnlSec2Hdr);
            this.pnlStockCard.Dock = System.Windows.Forms.DockStyle.Fill;

            // Encabezado "Control de inventario"
            this.pnlSec2Hdr.BackColor = System.Drawing.Color.White;
            this.pnlSec2Hdr.Controls.Add(this.lblSeccionInv);
            this.pnlSec2Hdr.Controls.Add(this.pnlAccentInv);
            this.pnlSec2Hdr.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSec2Hdr.Size = new System.Drawing.Size(694, 40);

            this.pnlAccentInv.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlAccentInv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAccentInv.Size = new System.Drawing.Size(694, 1);

            this.lblSeccionInv.AutoSize = false;
            this.lblSeccionInv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSeccionInv.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSeccionInv.ForeColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.lblSeccionInv.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblSeccionInv.Text = "Control de inventario";
            this.lblSeccionInv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // KPI: Stock actual  (verde)
            this.pnlStatStock.BackColor = System.Drawing.Color.FromArgb(240, 253, 244);
            this.pnlStatStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatStock.Controls.Add(this.txtStock);
            this.pnlStatStock.Controls.Add(this.lblStatTitle1);
            this.pnlStatStock.Location = new System.Drawing.Point(16, 50);
            this.pnlStatStock.Size = new System.Drawing.Size(196, 72);

            this.lblStatTitle1.AutoSize = false;
            this.lblStatTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatTitle1.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblStatTitle1.ForeColor = System.Drawing.Color.FromArgb(22, 101, 52);
            this.lblStatTitle1.Padding = new System.Windows.Forms.Padding(10, 6, 0, 0);
            this.lblStatTitle1.Size = new System.Drawing.Size(194, 24);
            this.lblStatTitle1.Text = "STOCK ACTUAL";

            this.txtStock.BackColor = System.Drawing.Color.FromArgb(240, 253, 244);
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStock.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.txtStock.ForeColor = System.Drawing.Color.FromArgb(22, 101, 52);
            this.txtStock.Location = new System.Drawing.Point(4, 30);
            this.txtStock.Size = new System.Drawing.Size(184, 30);
            this.txtStock.TabIndex = 6;
            this.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // KPI: Mínimo  (ámbar)
            this.pnlStatMin.BackColor = System.Drawing.Color.FromArgb(255, 253, 235);
            this.pnlStatMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatMin.Controls.Add(this.txtStockMinimo);
            this.pnlStatMin.Controls.Add(this.lblStatTitle2);
            this.pnlStatMin.Location = new System.Drawing.Point(228, 50);
            this.pnlStatMin.Size = new System.Drawing.Size(196, 72);

            this.lblStatTitle2.AutoSize = false;
            this.lblStatTitle2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatTitle2.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblStatTitle2.ForeColor = System.Drawing.Color.FromArgb(120, 53, 15);
            this.lblStatTitle2.Padding = new System.Windows.Forms.Padding(10, 6, 0, 0);
            this.lblStatTitle2.Size = new System.Drawing.Size(194, 24);
            this.lblStatTitle2.Text = "STOCK MÍNIMO";

            this.txtStockMinimo.BackColor = System.Drawing.Color.FromArgb(255, 253, 235);
            this.txtStockMinimo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStockMinimo.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.txtStockMinimo.ForeColor = System.Drawing.Color.FromArgb(120, 53, 15);
            this.txtStockMinimo.Location = new System.Drawing.Point(4, 30);
            this.txtStockMinimo.Size = new System.Drawing.Size(184, 30);
            this.txtStockMinimo.TabIndex = 7;
            this.txtStockMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // KPI: Máximo  (azul)
            this.pnlStatMax.BackColor = System.Drawing.Color.FromArgb(239, 246, 255);
            this.pnlStatMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatMax.Controls.Add(this.txtStockMaximo);
            this.pnlStatMax.Controls.Add(this.lblStatTitle3);
            this.pnlStatMax.Location = new System.Drawing.Point(440, 50);
            this.pnlStatMax.Size = new System.Drawing.Size(196, 72);

            this.lblStatTitle3.AutoSize = false;
            this.lblStatTitle3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatTitle3.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblStatTitle3.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblStatTitle3.Padding = new System.Windows.Forms.Padding(10, 6, 0, 0);
            this.lblStatTitle3.Size = new System.Drawing.Size(194, 24);
            this.lblStatTitle3.Text = "STOCK MÁXIMO";

            this.txtStockMaximo.BackColor = System.Drawing.Color.FromArgb(239, 246, 255);
            this.txtStockMaximo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStockMaximo.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.txtStockMaximo.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.txtStockMaximo.Location = new System.Drawing.Point(4, 30);
            this.txtStockMaximo.Size = new System.Drawing.Size(184, 30);
            this.txtStockMaximo.TabIndex = 8;
            this.txtStockMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // Tip informativo bajo los KPIs
            this.pnlTip.BackColor = System.Drawing.Color.FromArgb(239, 246, 255);
            this.pnlTip.Controls.Add(this.lblTip);
            this.pnlTip.Location = new System.Drawing.Point(16, 134);
            this.pnlTip.Size = new System.Drawing.Size(640, 32);

            this.lblTip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTip.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblTip.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblTip.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblTip.Text = "ℹ  El stock se actualiza automáticamente al registrar ventas, compras y ajustes de inventario.";
            this.lblTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ─────────────────────────────────────────────────────────────────
            // GAP entre fila principal y presentaciones
            // ─────────────────────────────────────────────────────────────────
            this.pnlGap.BackColor = System.Drawing.Color.FromArgb(240, 244, 250);
            this.pnlGap.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGap.Size = new System.Drawing.Size(1000, 10);

            // ═════════════════════════════════════════════════════════════════
            // TARJETA PRESENTACIONES  — full width, fills resto del body
            // ═════════════════════════════════════════════════════════════════
            this.pnlPresWrap.BackColor = System.Drawing.Color.White;
            this.pnlPresWrap.Controls.Add(this.pnlPresGrid);
            this.pnlPresWrap.Controls.Add(this.pnlPresHeader);
            this.pnlPresWrap.Dock = System.Windows.Forms.DockStyle.Fill;

            // Encabezado + fila de inputs
            this.pnlPresHeader.BackColor = System.Drawing.Color.White;
            this.pnlPresHeader.Controls.Add(this.btnAgregarPres);
            this.pnlPresHeader.Controls.Add(this.chkPrecioIncluyeIGV);
            this.pnlPresHeader.Controls.Add(this.txtPrecio);
            this.pnlPresHeader.Controls.Add(this.lblPrecio);
            this.pnlPresHeader.Controls.Add(this.txtCostoBase);
            this.pnlPresHeader.Controls.Add(this.lblCosto);
            this.pnlPresHeader.Controls.Add(this.txtCantidad);
            this.pnlPresHeader.Controls.Add(this.lblCantidad);
            this.pnlPresHeader.Controls.Add(this.cmbPresentacion);
            this.pnlPresHeader.Controls.Add(this.lblPresentacion);
            this.pnlPresHeader.Controls.Add(this.pnlPresHdrBand);
            this.pnlPresHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPresHeader.Size = new System.Drawing.Size(1000, 88);

            // Banda título presentaciones
            this.pnlPresHdrBand.BackColor = System.Drawing.Color.White;
            this.pnlPresHdrBand.Controls.Add(this.lblSeccionPres);
            this.pnlPresHdrBand.Controls.Add(this.pnlAccentPres);
            this.pnlPresHdrBand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPresHdrBand.Size = new System.Drawing.Size(1000, 40);

            this.pnlAccentPres.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlAccentPres.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAccentPres.Size = new System.Drawing.Size(1000, 1);

            this.lblSeccionPres.AutoSize = false;
            this.lblSeccionPres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSeccionPres.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSeccionPres.ForeColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.lblSeccionPres.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblSeccionPres.Text = "Presentaciones y precios";
            this.lblSeccionPres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Fila inputs: labels Y=46  inputs Y=60
            this.lblPresentacion.AutoSize = true;
            this.lblPresentacion.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblPresentacion.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblPresentacion.Location = new System.Drawing.Point(16, 46);
            this.lblPresentacion.Text = "PRESENTACIÓN";

            this.cmbPresentacion.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.cmbPresentacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPresentacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPresentacion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPresentacion.FormattingEnabled = true;
            this.cmbPresentacion.Location = new System.Drawing.Point(16, 60);
            this.cmbPresentacion.Size = new System.Drawing.Size(156, 24);
            this.cmbPresentacion.TabIndex = 30;

            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblCantidad.Location = new System.Drawing.Point(180, 46);
            this.lblCantidad.Text = "CANT.";

            this.txtCantidad.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCantidad.Location = new System.Drawing.Point(180, 60);
            this.txtCantidad.Size = new System.Drawing.Size(62, 24);
            this.txtCantidad.TabIndex = 31;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblCosto.AutoSize = true;
            this.lblCosto.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCosto.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblCosto.Location = new System.Drawing.Point(250, 46);
            this.lblCosto.Text = "COSTO S/";

            this.txtCostoBase.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.txtCostoBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCostoBase.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCostoBase.Location = new System.Drawing.Point(250, 60);
            this.txtCostoBase.Size = new System.Drawing.Size(82, 24);
            this.txtCostoBase.TabIndex = 32;
            this.txtCostoBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblPrecio.Location = new System.Drawing.Point(340, 46);
            this.lblPrecio.Text = "PRECIO S/";

            this.txtPrecio.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPrecio.Location = new System.Drawing.Point(340, 60);
            this.txtPrecio.Size = new System.Drawing.Size(82, 24);
            this.txtPrecio.TabIndex = 33;
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.chkPrecioIncluyeIGV.AutoSize = true;
            this.chkPrecioIncluyeIGV.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkPrecioIncluyeIGV.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.chkPrecioIncluyeIGV.Location = new System.Drawing.Point(432, 63);
            this.chkPrecioIncluyeIGV.Size = new System.Drawing.Size(72, 19);
            this.chkPrecioIncluyeIGV.TabIndex = 34;
            this.chkPrecioIncluyeIGV.Text = "IGV inc.";

            this.btnAgregarPres.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnAgregarPres.BackColor = System.Drawing.Color.FromArgb(0, 48, 135);
            this.btnAgregarPres.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarPres.FlatAppearance.BorderSize = 0;
            this.btnAgregarPres.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 35, 100);
            this.btnAgregarPres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPres.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarPres.ForeColor = System.Drawing.Color.White;
            this.btnAgregarPres.Location = new System.Drawing.Point(856, 52);
            this.btnAgregarPres.Size = new System.Drawing.Size(128, 34);
            this.btnAgregarPres.TabIndex = 35;
            this.btnAgregarPres.Text = "+ Agregar";

            // Grid de presentaciones
            this.pnlPresGrid.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.pnlPresGrid.Controls.Add(this.dgvPresentaciones);
            this.pnlPresGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPresGrid.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);

            // Estilos DGV — cabecera azul corporativo, filas limpias
            dgvAlt.BackColor = System.Drawing.Color.FromArgb(250, 252, 255);
            dgvHdr.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvHdr.BackColor = System.Drawing.Color.FromArgb(0, 48, 135);
            dgvHdr.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            dgvHdr.ForeColor = System.Drawing.Color.FromArgb(186, 209, 255);
            dgvHdr.SelectionBackColor = System.Drawing.Color.FromArgb(0, 48, 135);
            dgvHdr.SelectionForeColor = System.Drawing.Color.White;
            dgvCell.BackColor = System.Drawing.Color.White;
            dgvCell.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvCell.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            dgvCell.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
            dgvCell.SelectionForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            dgvRight.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dgvRight.BackColor = System.Drawing.Color.White;
            dgvRight.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvRight.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            dgvRight.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
            dgvRight.SelectionForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            dgvCenter.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dgvCenter.BackColor = System.Drawing.Color.White;
            dgvCenter.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            dgvCenter.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
            dgvCenter.SelectionForeColor = System.Drawing.Color.FromArgb(17, 24, 39);

            this.dgvPresentaciones.AllowUserToAddRows = false;
            this.dgvPresentaciones.AllowUserToDeleteRows = false;
            this.dgvPresentaciones.AllowUserToResizeRows = false;
            this.dgvPresentaciones.AlternatingRowsDefaultCellStyle = dgvAlt;
            this.dgvPresentaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvPresentaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPresentaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPresentaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPresentaciones.ColumnHeadersDefaultCellStyle = dgvHdr;
            this.dgvPresentaciones.ColumnHeadersHeight = 36;
            this.dgvPresentaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPresentaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colPresentacion, this.colCantidad, this.colUnidadBase,
                this.colCosto, this.colPrecio, this.colGanancia,
                this.colIGVPres, this.colEliminar });
            this.dgvPresentaciones.DefaultCellStyle = dgvCell;
            this.dgvPresentaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPresentaciones.EnableHeadersVisualStyles = false;
            this.dgvPresentaciones.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.dgvPresentaciones.MultiSelect = false;
            this.dgvPresentaciones.RowHeadersVisible = false;
            this.dgvPresentaciones.RowTemplate.Height = 38;
            this.dgvPresentaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.colPresentacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPresentacion.HeaderText = "Presentación";
            this.colPresentacion.MinimumWidth = 120;
            this.colPresentacion.Name = "colPresentacion";
            this.colPresentacion.ReadOnly = true;

            this.colCantidad.DefaultCellStyle = dgvCenter;
            this.colCantidad.HeaderText = "Cant.";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            this.colCantidad.Width = 60;

            this.colUnidadBase.DefaultCellStyle = dgvCenter;
            this.colUnidadBase.HeaderText = "Unidad";
            this.colUnidadBase.Name = "colUnidadBase";
            this.colUnidadBase.ReadOnly = true;
            this.colUnidadBase.Width = 64;

            this.colCosto.DefaultCellStyle = dgvRight;
            this.colCosto.HeaderText = "Costo S/";
            this.colCosto.Name = "colCosto";
            this.colCosto.ReadOnly = true;
            this.colCosto.Width = 86;

            this.colPrecio.DefaultCellStyle = dgvRight;
            this.colPrecio.HeaderText = "Precio S/";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            this.colPrecio.Width = 86;

            this.colGanancia.DefaultCellStyle = dgvCenter;
            this.colGanancia.HeaderText = "Ganancia";
            this.colGanancia.Name = "colGanancia";
            this.colGanancia.ReadOnly = true;
            this.colGanancia.Width = 76;

            this.colIGVPres.DefaultCellStyle = dgvCenter;
            this.colIGVPres.HeaderText = "IGV inc.";
            this.colIGVPres.Name = "colIGVPres";
            this.colIGVPres.ReadOnly = true;
            this.colIGVPres.Width = 58;

            this.colEliminar.HeaderText = "";
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.ReadOnly = true;
            this.colEliminar.Width = 36;

            // ═════════════════════════════════════════════════════════════════
            // FORM
            // ═════════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 244, 250);
            this.ClientSize = new System.Drawing.Size(1020, 790);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.MinimumSize = new System.Drawing.Size(940, 720);
            this.Name = "FormProductoDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Producto";

            // Resume
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlIconBox.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlTopRow.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlSec1Hdr.ResumeLayout(false);
            this.pnlImgFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenProducto)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlImagenWrap.ResumeLayout(false);
            this.pnlImagenWrap.PerformLayout();
            this.pnlImgHdr.ResumeLayout(false);
            this.pnlStockCard.ResumeLayout(false);
            this.pnlSec2Hdr.ResumeLayout(false);
            this.pnlStatStock.ResumeLayout(false);
            this.pnlStatStock.PerformLayout();
            this.pnlStatMin.ResumeLayout(false);
            this.pnlStatMin.PerformLayout();
            this.pnlStatMax.ResumeLayout(false);
            this.pnlStatMax.PerformLayout();
            this.pnlTip.ResumeLayout(false);
            this.pnlPresWrap.ResumeLayout(false);
            this.pnlPresHeader.ResumeLayout(false);
            this.pnlPresHeader.PerformLayout();
            this.pnlPresHdrBand.ResumeLayout(false);
            this.pnlPresGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresentaciones)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // ── Field declarations ─────────────────────────────────────────────────
        private System.Windows.Forms.Panel   pnlHeader;
        private System.Windows.Forms.Panel   pnlHeaderLine;
        private System.Windows.Forms.Panel   pnlIconBox;
        private System.Windows.Forms.Label   lblIcono;
        private System.Windows.Forms.Label   lblTitulo;
        private System.Windows.Forms.Label   lblSubtitulo;
        private System.Windows.Forms.Label   lblBadge;

        private System.Windows.Forms.Panel   pnlFooter;
        private System.Windows.Forms.Panel   pnlFooterLine;
        private System.Windows.Forms.Label   lblShortcut;
        private System.Windows.Forms.Button  btnGuardar;
        private System.Windows.Forms.Button  btnCancelar;

        private System.Windows.Forms.Panel   pnlBody;
        private System.Windows.Forms.Panel   pnlTopRow;
        private System.Windows.Forms.Panel   pnlGap;

        // Tarjeta imagen (izquierda)
        private System.Windows.Forms.Panel      pnlLeft;
        private System.Windows.Forms.Panel      pnlSec1Hdr;
        private System.Windows.Forms.Panel      pnlAccentInfo;
        private System.Windows.Forms.Label      lblSeccionInfo;
        private System.Windows.Forms.Panel      pnlImgFrame;
        private System.Windows.Forms.PictureBox pbImagenProducto;
        private System.Windows.Forms.Button     btnCargar;
        private System.Windows.Forms.Button     btnQuitar;

        private System.Windows.Forms.Panel   pnlDivH1;

        // Columna derecha
        private System.Windows.Forms.Panel   pnlRight;

        // Tarjeta info básica
        private System.Windows.Forms.Panel    pnlImagenWrap;
        private System.Windows.Forms.Panel    pnlImgHdr;
        private System.Windows.Forms.Panel    pnlAccentImg;
        private System.Windows.Forms.Label    lblSeccionImagen;
        private System.Windows.Forms.Label    lblCodigo;
        private System.Windows.Forms.TextBox  txtCodigo;
        private System.Windows.Forms.Label    lblProducto;
        private System.Windows.Forms.TextBox  txtProducto;
        private System.Windows.Forms.Label    lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label    lblUnidadBase;
        private System.Windows.Forms.ComboBox cmbUnidadBase;
        private System.Windows.Forms.Label    lblProveedor;
        private System.Windows.Forms.ComboBox cmbProveedor;

        private System.Windows.Forms.Panel   pnlDivH2;

        // Tarjeta inventario / KPIs
        private System.Windows.Forms.Panel   pnlStockCard;
        private System.Windows.Forms.Panel   pnlSec2Hdr;
        private System.Windows.Forms.Panel   pnlAccentInv;
        private System.Windows.Forms.Label   lblSeccionInv;
        private System.Windows.Forms.Panel   pnlStatStock;
        private System.Windows.Forms.Label   lblStatTitle1;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Panel   pnlStatMin;
        private System.Windows.Forms.Label   lblStatTitle2;
        private System.Windows.Forms.TextBox txtStockMinimo;
        private System.Windows.Forms.Panel   pnlStatMax;
        private System.Windows.Forms.Label   lblStatTitle3;
        private System.Windows.Forms.TextBox txtStockMaximo;
        private System.Windows.Forms.Panel   pnlTip;
        private System.Windows.Forms.Label   lblTip;
        private System.Windows.Forms.Label   lblStock;
        private System.Windows.Forms.Label   lblStockMinimo;
        private System.Windows.Forms.Label   lblStockMaximo;

        // Tarjeta presentaciones
        private System.Windows.Forms.Panel      pnlPresWrap;
        private System.Windows.Forms.Panel      pnlPresHeader;
        private System.Windows.Forms.Panel      pnlPresHdrBand;
        private System.Windows.Forms.Panel      pnlAccentPres;
        private System.Windows.Forms.Label      lblSeccionPres;
        private System.Windows.Forms.Label      lblPresentacion;
        private System.Windows.Forms.ComboBox   cmbPresentacion;
        private System.Windows.Forms.Label      lblCantidad;
        private System.Windows.Forms.TextBox    txtCantidad;
        private System.Windows.Forms.Label      lblCosto;
        private System.Windows.Forms.TextBox    txtCostoBase;
        private System.Windows.Forms.Label      lblPrecio;
        private System.Windows.Forms.TextBox    txtPrecio;
        private System.Windows.Forms.CheckBox   chkPrecioIncluyeIGV;
        private System.Windows.Forms.Button     btnAgregarPres;
        private System.Windows.Forms.Panel      pnlPresGrid;
        private System.Windows.Forms.DataGridView               dgvPresentaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn  colPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn  colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn  colUnidadBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn  colCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn  colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn  colGanancia;
        private System.Windows.Forms.DataGridViewTextBoxColumn  colIGVPres;
        private System.Windows.Forms.DataGridViewImageColumn    colEliminar;
    }
}
