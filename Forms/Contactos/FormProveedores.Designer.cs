namespace SistemaPOS.Forms.Contactos
{
    partial class FormProveedores
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProveedores));

            // ── Header ───────────────────────────────────────────────
            this.pnlHeader    = new System.Windows.Forms.Panel();
            this.lblTitulo    = new System.Windows.Forms.Label();
            this.lblHeaderSub = new System.Windows.Forms.Label();

            // ── Card de datos (wrapper + card + header interno) ───────
            this.pnlFormWrapper = new System.Windows.Forms.Panel();
            this.pnlDatos       = new System.Windows.Forms.Panel();
            this.pnlHdrDatos    = new System.Windows.Forms.Panel();
            this.lblSubTitulo2  = new System.Windows.Forms.Label();
            this.btnGuardar     = new System.Windows.Forms.Button();
            this.btnNuevo       = new System.Windows.Forms.Button();
            this.btnCancelar    = new System.Windows.Forms.Button();

            // Campos
            this.lblRUC             = new System.Windows.Forms.Label();
            this.txtRUC             = new System.Windows.Forms.TextBox();
            this.btnBuscar          = new System.Windows.Forms.Button();
            this.lblRazonSocial     = new System.Windows.Forms.Label();
            this.txtRazonSocial     = new System.Windows.Forms.TextBox();
            this.lblDireccion       = new System.Windows.Forms.Label();
            this.txtDireccion       = new System.Windows.Forms.TextBox();
            this.lblNombreComercial = new System.Windows.Forms.Label();
            this.txtNombreComercial = new System.Windows.Forms.TextBox();
            this.lblTelefono        = new System.Windows.Forms.Label();
            this.txtTelefono        = new System.Windows.Forms.TextBox();
            this.lblEmail           = new System.Windows.Forms.Label();
            this.txtEmail           = new System.Windows.Forms.TextBox();
            this.chkProveedorActivo = new System.Windows.Forms.CheckBox();

            // ── Barra de búsqueda ─────────────────────────────────────
            this.pnlSearch  = new System.Windows.Forms.Panel();
            this.lblBuscar  = new System.Windows.Forms.Label();
            this.txtBuscar  = new System.Windows.Forms.TextBox();

            // ── Grid ─────────────────────────────────────────────────
            this.pnlGridWrap      = new System.Windows.Forms.Panel();
            this.dgvProveedores   = new System.Windows.Forms.DataGridView();
            this.colNumero        = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRUC           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRazonSocial   = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono      = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado        = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar        = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEliminar      = new System.Windows.Forms.DataGridViewImageColumn();

            // ── Barra de estado ───────────────────────────────────────
            this.pnlStatusBar = new System.Windows.Forms.Panel();
            this.lblMostrar   = new System.Windows.Forms.Label();

            // ── Suspend ───────────────────────────────────────────────
            this.pnlHeader.SuspendLayout();
            this.pnlFormWrapper.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            this.pnlHdrDatos.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlGridWrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvProveedores).BeginInit();
            this.pnlStatusBar.SuspendLayout();
            this.SuspendLayout();

            // ════════════════════════════════════════════════════════════
            // pnlHeader   Dock=Top  68px
            // ════════════════════════════════════════════════════════════
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 68;
            this.pnlHeader.TabIndex  = 200;

            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(22, 10);
            this.lblTitulo.Text      = "Gestión de Proveedores";

            this.lblHeaderSub.AutoSize  = true;
            this.lblHeaderSub.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.lblHeaderSub.Location  = new System.Drawing.Point(22, 40);
            this.lblHeaderSub.Text      = "Registro y administración de proveedores";

            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Controls.Add(this.lblTitulo);

            // ════════════════════════════════════════════════════════════
            // pnlHdrDatos   header oscuro interno del card (0,0,full,40)
            // ════════════════════════════════════════════════════════════
            this.pnlHdrDatos.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.pnlHdrDatos.Location  = new System.Drawing.Point(0, 0);
            this.pnlHdrDatos.Size      = new System.Drawing.Size(1156, 40);
            this.pnlHdrDatos.TabIndex  = 300;

            this.lblSubTitulo2.AutoSize  = true;
            this.lblSubTitulo2.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSubTitulo2.ForeColor = System.Drawing.Color.White;
            this.lblSubTitulo2.Location  = new System.Drawing.Point(14, 11);
            this.lblSubTitulo2.Text      = "DATOS DEL PROVEEDOR";

            // Botones dentro del header (anclados a la derecha)
            this.btnCancelar.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnCancelar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(160, 168, 174);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnCancelar.Location  = new System.Drawing.Point(1052, 6);
            this.btnCancelar.Size      = new System.Drawing.Size(90, 28);
            this.btnCancelar.TabIndex  = 164;
            this.btnCancelar.Text      = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;

            this.btnNuevo.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnNuevo.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 148, 80);
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location  = new System.Drawing.Point(952, 6);
            this.btnNuevo.Size      = new System.Drawing.Size(90, 28);
            this.btnNuevo.TabIndex  = 165;
            this.btnNuevo.Text      = "+ Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;

            this.btnGuardar.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnGuardar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(21, 101, 175);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location  = new System.Drawing.Point(852, 6);
            this.btnGuardar.Size      = new System.Drawing.Size(90, 28);
            this.btnGuardar.TabIndex  = 169;
            this.btnGuardar.Text      = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;

            this.pnlHdrDatos.Controls.Add(this.lblSubTitulo2);
            this.pnlHdrDatos.Controls.Add(this.btnCancelar);
            this.pnlHdrDatos.Controls.Add(this.btnNuevo);
            this.pnlHdrDatos.Controls.Add(this.btnGuardar);

            // ════════════════════════════════════════════════════════════
            // Campos del formulario — 3 columnas
            // Col A (X=14):  RUC | Razón Social | Dirección
            // Col B (X=455): Nombre Comercial
            // Col C (X=810): Teléfono | Email
            // ════════════════════════════════════════════════════════════

            // ── Columna A ──────────────────────────────────────────────
            this.lblRUC.AutoSize  = true;
            this.lblRUC.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRUC.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblRUC.Location  = new System.Drawing.Point(14, 58);
            this.lblRUC.Text      = "RUC:";

            this.txtRUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRUC.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRUC.Location    = new System.Drawing.Point(130, 55);
            this.txtRUC.Size        = new System.Drawing.Size(200, 24);
            this.txtRUC.TabIndex    = 128;

            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(210, 215, 220);
            this.btnBuscar.FlatAppearance.BorderSize  = 1;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location  = new System.Drawing.Point(334, 55);
            this.btnBuscar.Size      = new System.Drawing.Size(24, 24);
            this.btnBuscar.TabIndex  = 170;
            this.btnBuscar.Text      = "🔍";
            this.btnBuscar.UseVisualStyleBackColor = false;

            this.lblRazonSocial.AutoSize  = true;
            this.lblRazonSocial.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRazonSocial.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblRazonSocial.Location  = new System.Drawing.Point(14, 93);
            this.lblRazonSocial.Text      = "Razón Social:";

            this.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRazonSocial.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRazonSocial.Location    = new System.Drawing.Point(130, 90);
            this.txtRazonSocial.Size        = new System.Drawing.Size(200, 24);
            this.txtRazonSocial.TabIndex    = 159;

            this.lblDireccion.AutoSize  = true;
            this.lblDireccion.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblDireccion.Location  = new System.Drawing.Point(14, 128);
            this.lblDireccion.Text      = "Dirección:";

            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDireccion.Location    = new System.Drawing.Point(130, 125);
            this.txtDireccion.Size        = new System.Drawing.Size(200, 24);
            this.txtDireccion.TabIndex    = 161;

            // ── Columna B ──────────────────────────────────────────────
            this.lblNombreComercial.AutoSize  = true;
            this.lblNombreComercial.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNombreComercial.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblNombreComercial.Location  = new System.Drawing.Point(458, 58);
            this.lblNombreComercial.Text      = "Nombre Comercial:";

            this.txtNombreComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreComercial.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombreComercial.Location    = new System.Drawing.Point(590, 55);
            this.txtNombreComercial.Size        = new System.Drawing.Size(200, 24);
            this.txtNombreComercial.TabIndex    = 166;

            // ── Columna C ──────────────────────────────────────────────
            this.lblTelefono.AutoSize  = true;
            this.lblTelefono.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblTelefono.Location  = new System.Drawing.Point(820, 58);
            this.lblTelefono.Text      = "Teléfono:";

            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTelefono.Location    = new System.Drawing.Point(910, 55);
            this.txtTelefono.Size        = new System.Drawing.Size(220, 24);
            this.txtTelefono.TabIndex    = 172;

            this.lblEmail.AutoSize  = true;
            this.lblEmail.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblEmail.Location  = new System.Drawing.Point(820, 93);
            this.lblEmail.Text      = "Email:";

            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEmail.Location    = new System.Drawing.Point(910, 90);
            this.txtEmail.Size        = new System.Drawing.Size(220, 24);
            this.txtEmail.TabIndex    = 174;

            // ── Checkbox ───────────────────────────────────────────────
            this.chkProveedorActivo.AutoSize  = true;
            this.chkProveedorActivo.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkProveedorActivo.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.chkProveedorActivo.Location  = new System.Drawing.Point(14, 160);
            this.chkProveedorActivo.Text      = "Proveedor activo";
            this.chkProveedorActivo.TabIndex  = 171;
            this.chkProveedorActivo.UseVisualStyleBackColor = true;

            // Ensamblar pnlDatos
            this.pnlDatos.BackColor   = System.Drawing.Color.White;
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Location    = new System.Drawing.Point(14, 8);
            this.pnlDatos.Size        = new System.Drawing.Size(1156, 192);
            this.pnlDatos.TabIndex    = 168;
            this.pnlDatos.Controls.Add(this.pnlHdrDatos);
            this.pnlDatos.Controls.Add(this.lblRUC);
            this.pnlDatos.Controls.Add(this.txtRUC);
            this.pnlDatos.Controls.Add(this.btnBuscar);
            this.pnlDatos.Controls.Add(this.lblRazonSocial);
            this.pnlDatos.Controls.Add(this.txtRazonSocial);
            this.pnlDatos.Controls.Add(this.lblDireccion);
            this.pnlDatos.Controls.Add(this.txtDireccion);
            this.pnlDatos.Controls.Add(this.lblNombreComercial);
            this.pnlDatos.Controls.Add(this.txtNombreComercial);
            this.pnlDatos.Controls.Add(this.lblTelefono);
            this.pnlDatos.Controls.Add(this.txtTelefono);
            this.pnlDatos.Controls.Add(this.lblEmail);
            this.pnlDatos.Controls.Add(this.txtEmail);
            this.pnlDatos.Controls.Add(this.chkProveedorActivo);

            // ════════════════════════════════════════════════════════════
            // pnlFormWrapper   Dock=Top  208px — da márgenes laterales al card
            // ════════════════════════════════════════════════════════════
            this.pnlFormWrapper.BackColor = System.Drawing.Color.FromArgb(236, 240, 245);
            this.pnlFormWrapper.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlFormWrapper.Height    = 208;
            this.pnlFormWrapper.TabIndex  = 201;
            this.pnlFormWrapper.Controls.Add(this.pnlDatos);

            // ════════════════════════════════════════════════════════════
            // pnlSearch   Dock=Top  52px — barra de búsqueda
            // ════════════════════════════════════════════════════════════
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Height    = 52;
            this.pnlSearch.TabIndex  = 202;

            this.lblBuscar.AutoSize  = true;
            this.lblBuscar.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(80, 90, 95);
            this.lblBuscar.Location  = new System.Drawing.Point(18, 17);
            this.lblBuscar.Text      = "Buscar proveedor:";

            this.txtBuscar.Anchor      = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location    = new System.Drawing.Point(130, 14);
            this.txtBuscar.Size        = new System.Drawing.Size(1040, 26);
            this.txtBuscar.TabIndex    = 164;

            this.pnlSearch.Controls.Add(this.lblBuscar);
            this.pnlSearch.Controls.Add(this.txtBuscar);

            // ════════════════════════════════════════════════════════════
            // pnlStatusBar   Dock=Bottom  34px
            // ════════════════════════════════════════════════════════════
            this.pnlStatusBar.BackColor = System.Drawing.Color.White;
            this.pnlStatusBar.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatusBar.Height    = 34;
            this.pnlStatusBar.TabIndex  = 204;

            this.lblMostrar.AutoSize  = true;
            this.lblMostrar.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMostrar.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblMostrar.Location  = new System.Drawing.Point(16, 10);
            this.lblMostrar.Text      = "Mostrando 0 proveedores";

            this.pnlStatusBar.Controls.Add(this.lblMostrar);

            // ════════════════════════════════════════════════════════════
            // dgvProveedores (dentro de pnlGridWrap con padding)
            // ════════════════════════════════════════════════════════════
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

            this.dgvProveedores.AllowUserToAddRows    = false;
            this.dgvProveedores.AllowUserToDeleteRows = false;
            this.dgvProveedores.AllowUserToResizeRows = false;
            this.dgvProveedores.AutoGenerateColumns   = false;
            this.dgvProveedores.BackgroundColor       = System.Drawing.Color.White;
            this.dgvProveedores.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvProveedores.CellBorderStyle       = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProveedores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvProveedores.ColumnHeadersDefaultCellStyle = styleHeader;
            this.dgvProveedores.ColumnHeadersHeight   = 34;
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProveedores.DefaultCellStyle      = styleRow;
            this.dgvProveedores.AlternatingRowsDefaultCellStyle = styleAlt;
            this.dgvProveedores.Dock                  = System.Windows.Forms.DockStyle.Fill;
            this.dgvProveedores.EnableHeadersVisualStyles = false;
            this.dgvProveedores.GridColor             = System.Drawing.Color.FromArgb(225, 230, 235);
            this.dgvProveedores.MultiSelect           = false;
            this.dgvProveedores.ReadOnly              = true;
            this.dgvProveedores.RowHeadersVisible     = false;
            this.dgvProveedores.RowTemplate.Height    = 38;
            this.dgvProveedores.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.TabIndex              = 167;

            // Columnas
            this.colNumero.HeaderText = "#";
            this.colNumero.Name       = "colNumero";
            this.colNumero.ReadOnly   = true;
            this.colNumero.Width      = 44;
            this.colNumero.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colNumero.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(130, 140, 150);

            this.colRUC.HeaderText = "RUC";
            this.colRUC.Name       = "colRUC";
            this.colRUC.ReadOnly   = true;
            this.colRUC.Width      = 145;

            this.colRazonSocial.AutoSizeMode  = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRazonSocial.HeaderText    = "Razón Social";
            this.colRazonSocial.Name          = "colRazonSocial";
            this.colRazonSocial.ReadOnly      = true;
            this.colRazonSocial.MinimumWidth  = 200;

            this.colTelefono.HeaderText = "Teléfono";
            this.colTelefono.Name       = "colTelefono";
            this.colTelefono.ReadOnly   = true;
            this.colTelefono.Width      = 122;

            this.colEmail.HeaderText = "Email";
            this.colEmail.Name       = "colEmail";
            this.colEmail.ReadOnly   = true;
            this.colEmail.Width      = 210;

            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name       = "colEstado";
            this.colEstado.ReadOnly   = true;
            this.colEstado.Width      = 90;
            this.colEstado.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEstado.DefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.colEditar.HeaderText = "";
            this.colEditar.Image      = ((System.Drawing.Image)(resources.GetObject("colEditar.Image")));
            this.colEditar.Name       = "colEditar";
            this.colEditar.Width      = 40;
            this.colEditar.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colEliminar.HeaderText = "";
            this.colEliminar.Image      = ((System.Drawing.Image)(resources.GetObject("colEliminar.Image")));
            this.colEliminar.Name       = "colEliminar";
            this.colEliminar.ReadOnly   = true;
            this.colEliminar.Width      = 40;
            this.colEliminar.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.dgvProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNumero, this.colRUC, this.colRazonSocial,
                this.colTelefono, this.colEmail, this.colEstado,
                this.colEditar, this.colEliminar
            });

            this.pnlGridWrap.BackColor = System.Drawing.Color.FromArgb(236, 240, 245);
            this.pnlGridWrap.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridWrap.Padding   = new System.Windows.Forms.Padding(14, 8, 14, 0);
            this.pnlGridWrap.TabIndex  = 203;
            this.pnlGridWrap.Controls.Add(this.dgvProveedores);

            // ════════════════════════════════════════════════════════════
            // Form
            // ════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(236, 240, 245);
            this.ClientSize          = new System.Drawing.Size(1184, 680);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.None;
            this.Name                = "FormProveedores";
            this.Text                = "FormProveedores";

            // Orden de Add: Fill primero, Bottom al final, Top en orden inverso al visual
            this.Controls.Add(this.pnlGridWrap);       // Fill
            this.Controls.Add(this.pnlSearch);          // Top — 3.° desde arriba
            this.Controls.Add(this.pnlFormWrapper);     // Top — 2.° desde arriba
            this.Controls.Add(this.pnlHeader);          // Top — 1.° (lo más arriba)
            this.Controls.Add(this.pnlStatusBar);       // Bottom

            // ── Resume ───────────────────────────────────────────────
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlHdrDatos.ResumeLayout(false);
            this.pnlHdrDatos.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlFormWrapper.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlGridWrap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvProveedores).EndInit();
            this.pnlStatusBar.ResumeLayout(false);
            this.pnlStatusBar.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel   pnlHeader;
        private System.Windows.Forms.Label   lblTitulo;
        private System.Windows.Forms.Label   lblHeaderSub;

        private System.Windows.Forms.Panel   pnlFormWrapper;
        private System.Windows.Forms.Panel   pnlDatos;
        private System.Windows.Forms.Panel   pnlHdrDatos;
        private System.Windows.Forms.Label   lblSubTitulo2;
        private System.Windows.Forms.Button  btnGuardar;
        private System.Windows.Forms.Button  btnNuevo;
        private System.Windows.Forms.Button  btnCancelar;

        private System.Windows.Forms.Label    lblRUC;
        private System.Windows.Forms.TextBox  txtRUC;
        private System.Windows.Forms.Button   btnBuscar;
        private System.Windows.Forms.Label    lblRazonSocial;
        private System.Windows.Forms.TextBox  txtRazonSocial;
        private System.Windows.Forms.Label    lblDireccion;
        private System.Windows.Forms.TextBox  txtDireccion;
        private System.Windows.Forms.Label    lblNombreComercial;
        private System.Windows.Forms.TextBox  txtNombreComercial;
        private System.Windows.Forms.Label    lblTelefono;
        private System.Windows.Forms.TextBox  txtTelefono;
        private System.Windows.Forms.Label    lblEmail;
        private System.Windows.Forms.TextBox  txtEmail;
        private System.Windows.Forms.CheckBox chkProveedorActivo;

        private System.Windows.Forms.Panel   pnlSearch;
        private System.Windows.Forms.Label   lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;

        private System.Windows.Forms.Panel   pnlGridWrap;
        private System.Windows.Forms.DataGridView              dgvProveedores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRUC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewImageColumn   colEditar;
        private System.Windows.Forms.DataGridViewImageColumn   colEliminar;

        private System.Windows.Forms.Panel pnlStatusBar;
        private System.Windows.Forms.Label lblMostrar;
    }
}
