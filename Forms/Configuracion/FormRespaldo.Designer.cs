namespace SistemaPOS.Forms.Configuracion
{
    partial class FormRespaldo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.tlpCards = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCardBackup = new System.Windows.Forms.Panel();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.btnUbicacionRespaldo = new System.Windows.Forms.Button();
            this.lblNombreArchivo = new System.Windows.Forms.Label();
            this.txtNombreArchivo = new System.Windows.Forms.TextBox();
            this.chkIncluirDatosVentas = new System.Windows.Forms.CheckBox();
            this.chkIncluirDatosInventario = new System.Windows.Forms.CheckBox();
            this.chkIncluirConfiguraciones = new System.Windows.Forms.CheckBox();
            this.btnCrearRespaldo = new System.Windows.Forms.Button();
            this.pnlHdrBackup = new System.Windows.Forms.Panel();
            this.lblTitleBackup = new System.Windows.Forms.Label();
            this.lblIconBackup = new System.Windows.Forms.Label();
            this.pnlCardRestore = new System.Windows.Forms.Panel();
            this.lblArchivoRespaldo = new System.Windows.Forms.Label();
            this.txtArchivoRespaldo = new System.Windows.Forms.TextBox();
            this.btnArchivoRespaldo = new System.Windows.Forms.Button();
            this.lblAdvertencia = new System.Windows.Forms.Label();
            this.btnRestaurarDatos = new System.Windows.Forms.Button();
            this.pnlHdrRestore = new System.Windows.Forms.Panel();
            this.lblTitleRestore = new System.Windows.Forms.Label();
            this.lblIconRestore = new System.Windows.Forms.Label();
            this.pnlCardAuto = new System.Windows.Forms.Panel();
            this.chkActivarRespaldoAuto = new System.Windows.Forms.CheckBox();
            this.lblFrecuencia = new System.Windows.Forms.Label();
            this.rbDiario = new System.Windows.Forms.RadioButton();
            this.rbSemanal = new System.Windows.Forms.RadioButton();
            this.rbMensual = new System.Windows.Forms.RadioButton();
            this.lblDiaEnvio = new System.Windows.Forms.Label();
            this.cmbDiaEnvio = new System.Windows.Forms.ComboBox();
            this.lblHoraAuto = new System.Windows.Forms.Label();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.lblConservar = new System.Windows.Forms.Label();
            this.txtDiasRespaldo = new System.Windows.Forms.TextBox();
            this.lblDiasUnidad = new System.Windows.Forms.Label();
            this.pnlAutoButtons = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlHdrAuto = new System.Windows.Forms.Panel();
            this.lblTitleAuto = new System.Windows.Forms.Label();
            this.lblIconAuto = new System.Windows.Forms.Label();
            this.pnlHistory = new System.Windows.Forms.Panel();
            this.pnlGridWrap = new System.Windows.Forms.Panel();
            this.dgvHistorialRespaldos = new System.Windows.Forms.DataGridView();
            this.colFechayHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTamano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUbicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRestaurar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlHistHdr = new System.Windows.Forms.Panel();
            this.lblMostrar = new System.Windows.Forms.Label();
            this.btnAbrirCarpeta = new System.Windows.Forms.Button();
            this.lblIconHist = new System.Windows.Forms.Label();
            this.lblHistTitle = new System.Windows.Forms.Label();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.lblResumen = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.tlpCards.SuspendLayout();
            this.pnlCardBackup.SuspendLayout();
            this.pnlHdrBackup.SuspendLayout();
            this.pnlCardRestore.SuspendLayout();
            this.pnlHdrRestore.SuspendLayout();
            this.pnlCardAuto.SuspendLayout();
            this.pnlAutoButtons.SuspendLayout();
            this.pnlHdrAuto.SuspendLayout();
            this.pnlHistory.SuspendLayout();
            this.pnlGridWrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialRespaldos)).BeginInit();
            this.pnlHistHdr.SuspendLayout();
            this.pnlResumen.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1512, 64);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblHeaderSub
            // 
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(190)))), ((int)(((byte)(195)))));
            this.lblHeaderSub.Location = new System.Drawing.Point(22, 40);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(600, 18);
            this.lblHeaderSub.TabIndex = 0;
            this.lblHeaderSub.Text = "Crea, restaura y programa respaldos automaticos de la base de datos";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 28);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Respaldo de Datos";
            // 
            // pnlCards
            // 
            this.pnlCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlCards.Controls.Add(this.tlpCards);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 64);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1512, 330);
            this.pnlCards.TabIndex = 2;
            // 
            // tlpCards
            // 
            this.tlpCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.tlpCards.ColumnCount = 3;
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.26613F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.26613F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpCards.Controls.Add(this.pnlCardBackup, 0, 0);
            this.tlpCards.Controls.Add(this.pnlCardRestore, 1, 0);
            this.tlpCards.Controls.Add(this.pnlCardAuto, 2, 0);
            this.tlpCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCards.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlpCards.Location = new System.Drawing.Point(0, 0);
            this.tlpCards.Name = "tlpCards";
            this.tlpCards.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.tlpCards.RowCount = 1;
            this.tlpCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCards.Size = new System.Drawing.Size(1512, 330);
            this.tlpCards.TabIndex = 0;
            // 
            // pnlCardBackup
            // 
            this.pnlCardBackup.BackColor = System.Drawing.Color.White;
            this.pnlCardBackup.Controls.Add(this.lblUbicacion);
            this.pnlCardBackup.Controls.Add(this.txtUbicacion);
            this.pnlCardBackup.Controls.Add(this.btnUbicacionRespaldo);
            this.pnlCardBackup.Controls.Add(this.lblNombreArchivo);
            this.pnlCardBackup.Controls.Add(this.txtNombreArchivo);
            this.pnlCardBackup.Controls.Add(this.chkIncluirDatosVentas);
            this.pnlCardBackup.Controls.Add(this.chkIncluirDatosInventario);
            this.pnlCardBackup.Controls.Add(this.chkIncluirConfiguraciones);
            this.pnlCardBackup.Controls.Add(this.btnCrearRespaldo);
            this.pnlCardBackup.Controls.Add(this.pnlHdrBackup);
            this.pnlCardBackup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardBackup.Location = new System.Drawing.Point(12, 10);
            this.pnlCardBackup.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.pnlCardBackup.Name = "pnlCardBackup";
            this.pnlCardBackup.Size = new System.Drawing.Size(487, 310);
            this.pnlCardBackup.TabIndex = 0;
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblUbicacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(135)))));
            this.lblUbicacion.Location = new System.Drawing.Point(12, 50);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(220, 15);
            this.lblUbicacion.TabIndex = 0;
            this.lblUbicacion.Text = "Carpeta de destino";
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtUbicacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUbicacion.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.txtUbicacion.Location = new System.Drawing.Point(12, 67);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.ReadOnly = true;
            this.txtUbicacion.Size = new System.Drawing.Size(330, 23);
            this.txtUbicacion.TabIndex = 1;
            // 
            // btnUbicacionRespaldo
            // 
            this.btnUbicacionRespaldo.BackColor = System.Drawing.Color.White;
            this.btnUbicacionRespaldo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUbicacionRespaldo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(224)))));
            this.btnUbicacionRespaldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUbicacionRespaldo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUbicacionRespaldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnUbicacionRespaldo.Location = new System.Drawing.Point(348, 66);
            this.btnUbicacionRespaldo.Name = "btnUbicacionRespaldo";
            this.btnUbicacionRespaldo.Size = new System.Drawing.Size(38, 26);
            this.btnUbicacionRespaldo.TabIndex = 2;
            this.btnUbicacionRespaldo.Text = "...";
            this.btnUbicacionRespaldo.UseVisualStyleBackColor = false;
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNombreArchivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(135)))));
            this.lblNombreArchivo.Location = new System.Drawing.Point(12, 102);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(220, 15);
            this.lblNombreArchivo.TabIndex = 3;
            this.lblNombreArchivo.Text = "Nombre del archivo";
            // 
            // txtNombreArchivo
            // 
            this.txtNombreArchivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreArchivo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.txtNombreArchivo.Location = new System.Drawing.Point(12, 119);
            this.txtNombreArchivo.Name = "txtNombreArchivo";
            this.txtNombreArchivo.Size = new System.Drawing.Size(374, 23);
            this.txtNombreArchivo.TabIndex = 4;
            // 
            // chkIncluirDatosVentas
            // 
            this.chkIncluirDatosVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkIncluirDatosVentas.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkIncluirDatosVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(85)))));
            this.chkIncluirDatosVentas.Location = new System.Drawing.Point(12, 158);
            this.chkIncluirDatosVentas.Name = "chkIncluirDatosVentas";
            this.chkIncluirDatosVentas.Size = new System.Drawing.Size(100, 20);
            this.chkIncluirDatosVentas.TabIndex = 5;
            this.chkIncluirDatosVentas.Text = "Ventas";
            // 
            // chkIncluirDatosInventario
            // 
            this.chkIncluirDatosInventario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkIncluirDatosInventario.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkIncluirDatosInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(85)))));
            this.chkIncluirDatosInventario.Location = new System.Drawing.Point(118, 158);
            this.chkIncluirDatosInventario.Name = "chkIncluirDatosInventario";
            this.chkIncluirDatosInventario.Size = new System.Drawing.Size(100, 20);
            this.chkIncluirDatosInventario.TabIndex = 6;
            this.chkIncluirDatosInventario.Text = "Inventario";
            // 
            // chkIncluirConfiguraciones
            // 
            this.chkIncluirConfiguraciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkIncluirConfiguraciones.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkIncluirConfiguraciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(85)))));
            this.chkIncluirConfiguraciones.Location = new System.Drawing.Point(224, 158);
            this.chkIncluirConfiguraciones.Name = "chkIncluirConfiguraciones";
            this.chkIncluirConfiguraciones.Size = new System.Drawing.Size(130, 20);
            this.chkIncluirConfiguraciones.TabIndex = 7;
            this.chkIncluirConfiguraciones.Text = "Configuraciones";
            // 
            // btnCrearRespaldo
            // 
            this.btnCrearRespaldo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(153)))), ((int)(((byte)(82)))));
            this.btnCrearRespaldo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearRespaldo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCrearRespaldo.FlatAppearance.BorderSize = 0;
            this.btnCrearRespaldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearRespaldo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCrearRespaldo.ForeColor = System.Drawing.Color.White;
            this.btnCrearRespaldo.Location = new System.Drawing.Point(0, 266);
            this.btnCrearRespaldo.Name = "btnCrearRespaldo";
            this.btnCrearRespaldo.Size = new System.Drawing.Size(487, 44);
            this.btnCrearRespaldo.TabIndex = 8;
            this.btnCrearRespaldo.Text = "Crear Respaldo Ahora";
            this.btnCrearRespaldo.UseVisualStyleBackColor = false;
            // 
            // pnlHdrBackup
            // 
            this.pnlHdrBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(153)))), ((int)(((byte)(82)))));
            this.pnlHdrBackup.Controls.Add(this.lblTitleBackup);
            this.pnlHdrBackup.Controls.Add(this.lblIconBackup);
            this.pnlHdrBackup.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHdrBackup.Location = new System.Drawing.Point(0, 0);
            this.pnlHdrBackup.Name = "pnlHdrBackup";
            this.pnlHdrBackup.Size = new System.Drawing.Size(487, 40);
            this.pnlHdrBackup.TabIndex = 9;
            // 
            // lblTitleBackup
            // 
            this.lblTitleBackup.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleBackup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitleBackup.ForeColor = System.Drawing.Color.White;
            this.lblTitleBackup.Location = new System.Drawing.Point(40, 11);
            this.lblTitleBackup.Name = "lblTitleBackup";
            this.lblTitleBackup.Size = new System.Drawing.Size(300, 18);
            this.lblTitleBackup.TabIndex = 0;
            this.lblTitleBackup.Text = "CREAR RESPALDO";
            // 
            // lblIconBackup
            // 
            this.lblIconBackup.BackColor = System.Drawing.Color.Transparent;
            this.lblIconBackup.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14F);
            this.lblIconBackup.ForeColor = System.Drawing.Color.White;
            this.lblIconBackup.Location = new System.Drawing.Point(12, 9);
            this.lblIconBackup.Name = "lblIconBackup";
            this.lblIconBackup.Size = new System.Drawing.Size(22, 22);
            this.lblIconBackup.TabIndex = 1;
            this.lblIconBackup.Text = "";
            // 
            // pnlCardRestore
            // 
            this.pnlCardRestore.BackColor = System.Drawing.Color.White;
            this.pnlCardRestore.Controls.Add(this.lblArchivoRespaldo);
            this.pnlCardRestore.Controls.Add(this.txtArchivoRespaldo);
            this.pnlCardRestore.Controls.Add(this.btnArchivoRespaldo);
            this.pnlCardRestore.Controls.Add(this.lblAdvertencia);
            this.pnlCardRestore.Controls.Add(this.btnRestaurarDatos);
            this.pnlCardRestore.Controls.Add(this.pnlHdrRestore);
            this.pnlCardRestore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardRestore.Location = new System.Drawing.Point(511, 10);
            this.pnlCardRestore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pnlCardRestore.Name = "pnlCardRestore";
            this.pnlCardRestore.Size = new System.Drawing.Size(487, 310);
            this.pnlCardRestore.TabIndex = 1;
            // 
            // lblArchivoRespaldo
            // 
            this.lblArchivoRespaldo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblArchivoRespaldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(135)))));
            this.lblArchivoRespaldo.Location = new System.Drawing.Point(12, 50);
            this.lblArchivoRespaldo.Name = "lblArchivoRespaldo";
            this.lblArchivoRespaldo.Size = new System.Drawing.Size(220, 15);
            this.lblArchivoRespaldo.TabIndex = 0;
            this.lblArchivoRespaldo.Text = "Archivo de respaldo (.db)";
            // 
            // txtArchivoRespaldo
            // 
            this.txtArchivoRespaldo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtArchivoRespaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArchivoRespaldo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.txtArchivoRespaldo.Location = new System.Drawing.Point(12, 67);
            this.txtArchivoRespaldo.Name = "txtArchivoRespaldo";
            this.txtArchivoRespaldo.ReadOnly = true;
            this.txtArchivoRespaldo.Size = new System.Drawing.Size(408, 23);
            this.txtArchivoRespaldo.TabIndex = 1;
            // 
            // btnArchivoRespaldo
            // 
            this.btnArchivoRespaldo.BackColor = System.Drawing.Color.White;
            this.btnArchivoRespaldo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArchivoRespaldo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(224)))));
            this.btnArchivoRespaldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchivoRespaldo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnArchivoRespaldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnArchivoRespaldo.Location = new System.Drawing.Point(435, 67);
            this.btnArchivoRespaldo.Name = "btnArchivoRespaldo";
            this.btnArchivoRespaldo.Size = new System.Drawing.Size(38, 26);
            this.btnArchivoRespaldo.TabIndex = 2;
            this.btnArchivoRespaldo.Text = "...";
            this.btnArchivoRespaldo.UseVisualStyleBackColor = false;
            // 
            // lblAdvertencia
            // 
            this.lblAdvertencia.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblAdvertencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.lblAdvertencia.Location = new System.Drawing.Point(12, 104);
            this.lblAdvertencia.Name = "lblAdvertencia";
            this.lblAdvertencia.Size = new System.Drawing.Size(370, 44);
            this.lblAdvertencia.TabIndex = 3;
            this.lblAdvertencia.Text = "Esta accion reemplaza todos los datos actuales. Se creara un respaldo previo de s" +
    "eguridad automaticamente.";
            // 
            // btnRestaurarDatos
            // 
            this.btnRestaurarDatos.BackColor = System.Drawing.Color.White;
            this.btnRestaurarDatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurarDatos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRestaurarDatos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(69)))), ((int)(((byte)(0)))));
            this.btnRestaurarDatos.FlatAppearance.BorderSize = 2;
            this.btnRestaurarDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurarDatos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRestaurarDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(69)))), ((int)(((byte)(0)))));
            this.btnRestaurarDatos.Location = new System.Drawing.Point(0, 266);
            this.btnRestaurarDatos.Name = "btnRestaurarDatos";
            this.btnRestaurarDatos.Size = new System.Drawing.Size(487, 44);
            this.btnRestaurarDatos.TabIndex = 4;
            this.btnRestaurarDatos.Text = "Restaurar Base de Datos";
            this.btnRestaurarDatos.UseVisualStyleBackColor = false;
            // 
            // pnlHdrRestore
            // 
            this.pnlHdrRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(69)))), ((int)(((byte)(0)))));
            this.pnlHdrRestore.Controls.Add(this.lblTitleRestore);
            this.pnlHdrRestore.Controls.Add(this.lblIconRestore);
            this.pnlHdrRestore.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHdrRestore.Location = new System.Drawing.Point(0, 0);
            this.pnlHdrRestore.Name = "pnlHdrRestore";
            this.pnlHdrRestore.Size = new System.Drawing.Size(487, 40);
            this.pnlHdrRestore.TabIndex = 5;
            // 
            // lblTitleRestore
            // 
            this.lblTitleRestore.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleRestore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitleRestore.ForeColor = System.Drawing.Color.White;
            this.lblTitleRestore.Location = new System.Drawing.Point(40, 11);
            this.lblTitleRestore.Name = "lblTitleRestore";
            this.lblTitleRestore.Size = new System.Drawing.Size(300, 18);
            this.lblTitleRestore.TabIndex = 0;
            this.lblTitleRestore.Text = "RESTAURAR DATOS";
            // 
            // lblIconRestore
            // 
            this.lblIconRestore.BackColor = System.Drawing.Color.Transparent;
            this.lblIconRestore.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14F);
            this.lblIconRestore.ForeColor = System.Drawing.Color.White;
            this.lblIconRestore.Location = new System.Drawing.Point(12, 9);
            this.lblIconRestore.Name = "lblIconRestore";
            this.lblIconRestore.Size = new System.Drawing.Size(22, 22);
            this.lblIconRestore.TabIndex = 1;
            this.lblIconRestore.Text = "";
            // 
            // pnlCardAuto
            // 
            this.pnlCardAuto.BackColor = System.Drawing.Color.White;
            this.pnlCardAuto.Controls.Add(this.chkActivarRespaldoAuto);
            this.pnlCardAuto.Controls.Add(this.lblFrecuencia);
            this.pnlCardAuto.Controls.Add(this.rbDiario);
            this.pnlCardAuto.Controls.Add(this.rbSemanal);
            this.pnlCardAuto.Controls.Add(this.rbMensual);
            this.pnlCardAuto.Controls.Add(this.lblDiaEnvio);
            this.pnlCardAuto.Controls.Add(this.cmbDiaEnvio);
            this.pnlCardAuto.Controls.Add(this.lblHoraAuto);
            this.pnlCardAuto.Controls.Add(this.dtpHora);
            this.pnlCardAuto.Controls.Add(this.lblConservar);
            this.pnlCardAuto.Controls.Add(this.txtDiasRespaldo);
            this.pnlCardAuto.Controls.Add(this.lblDiasUnidad);
            this.pnlCardAuto.Controls.Add(this.pnlAutoButtons);
            this.pnlCardAuto.Controls.Add(this.pnlHdrAuto);
            this.pnlCardAuto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardAuto.Location = new System.Drawing.Point(1010, 10);
            this.pnlCardAuto.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.pnlCardAuto.Name = "pnlCardAuto";
            this.pnlCardAuto.Size = new System.Drawing.Size(490, 310);
            this.pnlCardAuto.TabIndex = 2;
            // 
            // chkActivarRespaldoAuto
            // 
            this.chkActivarRespaldoAuto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkActivarRespaldoAuto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.chkActivarRespaldoAuto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.chkActivarRespaldoAuto.Location = new System.Drawing.Point(12, 52);
            this.chkActivarRespaldoAuto.Name = "chkActivarRespaldoAuto";
            this.chkActivarRespaldoAuto.Size = new System.Drawing.Size(240, 20);
            this.chkActivarRespaldoAuto.TabIndex = 0;
            this.chkActivarRespaldoAuto.Text = "Activar respaldo automatico";
            // 
            // lblFrecuencia
            // 
            this.lblFrecuencia.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblFrecuencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(135)))));
            this.lblFrecuencia.Location = new System.Drawing.Point(12, 86);
            this.lblFrecuencia.Name = "lblFrecuencia";
            this.lblFrecuencia.Size = new System.Drawing.Size(80, 14);
            this.lblFrecuencia.TabIndex = 1;
            this.lblFrecuencia.Text = "Frecuencia";
            // 
            // rbDiario
            // 
            this.rbDiario.AutoSize = true;
            this.rbDiario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbDiario.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.rbDiario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(85)))));
            this.rbDiario.Location = new System.Drawing.Point(12, 104);
            this.rbDiario.Name = "rbDiario";
            this.rbDiario.Size = new System.Drawing.Size(56, 19);
            this.rbDiario.TabIndex = 2;
            this.rbDiario.Text = "Diario";
            // 
            // rbSemanal
            // 
            this.rbSemanal.AutoSize = true;
            this.rbSemanal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbSemanal.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.rbSemanal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(85)))));
            this.rbSemanal.Location = new System.Drawing.Point(90, 104);
            this.rbSemanal.Name = "rbSemanal";
            this.rbSemanal.Size = new System.Drawing.Size(70, 19);
            this.rbSemanal.TabIndex = 3;
            this.rbSemanal.Text = "Semanal";
            // 
            // rbMensual
            // 
            this.rbMensual.AutoSize = true;
            this.rbMensual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbMensual.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.rbMensual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(85)))));
            this.rbMensual.Location = new System.Drawing.Point(178, 104);
            this.rbMensual.Name = "rbMensual";
            this.rbMensual.Size = new System.Drawing.Size(70, 19);
            this.rbMensual.TabIndex = 4;
            this.rbMensual.Text = "Mensual";
            // 
            // lblDiaEnvio
            // 
            this.lblDiaEnvio.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDiaEnvio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(135)))));
            this.lblDiaEnvio.Location = new System.Drawing.Point(12, 136);
            this.lblDiaEnvio.Name = "lblDiaEnvio";
            this.lblDiaEnvio.Size = new System.Drawing.Size(34, 14);
            this.lblDiaEnvio.TabIndex = 5;
            this.lblDiaEnvio.Text = "Dia";
            this.lblDiaEnvio.Visible = false;
            // 
            // cmbDiaEnvio
            // 
            this.cmbDiaEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiaEnvio.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.cmbDiaEnvio.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes",
            "Sabado",
            "Domingo"});
            this.cmbDiaEnvio.Location = new System.Drawing.Point(12, 152);
            this.cmbDiaEnvio.Name = "cmbDiaEnvio";
            this.cmbDiaEnvio.Size = new System.Drawing.Size(120, 21);
            this.cmbDiaEnvio.TabIndex = 6;
            this.cmbDiaEnvio.Visible = false;
            // 
            // lblHoraAuto
            // 
            this.lblHoraAuto.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblHoraAuto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(135)))));
            this.lblHoraAuto.Location = new System.Drawing.Point(148, 136);
            this.lblHoraAuto.Name = "lblHoraAuto";
            this.lblHoraAuto.Size = new System.Drawing.Size(34, 14);
            this.lblHoraAuto.TabIndex = 7;
            this.lblHoraAuto.Text = "Hora";
            // 
            // dtpHora
            // 
            this.dtpHora.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(148, 152);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(150, 23);
            this.dtpHora.TabIndex = 8;
            // 
            // lblConservar
            // 
            this.lblConservar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblConservar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(135)))));
            this.lblConservar.Location = new System.Drawing.Point(12, 196);
            this.lblConservar.Name = "lblConservar";
            this.lblConservar.Size = new System.Drawing.Size(110, 14);
            this.lblConservar.TabIndex = 9;
            this.lblConservar.Text = "Conservar ultimas";
            // 
            // txtDiasRespaldo
            // 
            this.txtDiasRespaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiasRespaldo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiasRespaldo.Location = new System.Drawing.Point(128, 192);
            this.txtDiasRespaldo.Name = "txtDiasRespaldo";
            this.txtDiasRespaldo.Size = new System.Drawing.Size(46, 23);
            this.txtDiasRespaldo.TabIndex = 10;
            this.txtDiasRespaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDiasUnidad
            // 
            this.lblDiasUnidad.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDiasUnidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(135)))));
            this.lblDiasUnidad.Location = new System.Drawing.Point(180, 196);
            this.lblDiasUnidad.Name = "lblDiasUnidad";
            this.lblDiasUnidad.Size = new System.Drawing.Size(50, 14);
            this.lblDiasUnidad.TabIndex = 11;
            this.lblDiasUnidad.Text = "copias";
            // 
            // pnlAutoButtons
            // 
            this.pnlAutoButtons.BackColor = System.Drawing.Color.White;
            this.pnlAutoButtons.Controls.Add(this.btnCancelar);
            this.pnlAutoButtons.Controls.Add(this.btnGuardar);
            this.pnlAutoButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAutoButtons.Location = new System.Drawing.Point(0, 266);
            this.pnlAutoButtons.Name = "pnlAutoButtons";
            this.pnlAutoButtons.Size = new System.Drawing.Size(490, 44);
            this.pnlAutoButtons.TabIndex = 12;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(224)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(125)))));
            this.btnCancelar.Location = new System.Drawing.Point(358, 0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(132, 44);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Descartar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(73)))), ((int)(((byte)(171)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(0, 0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(358, 44);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar Config.";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // pnlHdrAuto
            // 
            this.pnlHdrAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(73)))), ((int)(((byte)(171)))));
            this.pnlHdrAuto.Controls.Add(this.lblTitleAuto);
            this.pnlHdrAuto.Controls.Add(this.lblIconAuto);
            this.pnlHdrAuto.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHdrAuto.Location = new System.Drawing.Point(0, 0);
            this.pnlHdrAuto.Name = "pnlHdrAuto";
            this.pnlHdrAuto.Size = new System.Drawing.Size(490, 40);
            this.pnlHdrAuto.TabIndex = 13;
            // 
            // lblTitleAuto
            // 
            this.lblTitleAuto.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleAuto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitleAuto.ForeColor = System.Drawing.Color.White;
            this.lblTitleAuto.Location = new System.Drawing.Point(40, 11);
            this.lblTitleAuto.Name = "lblTitleAuto";
            this.lblTitleAuto.Size = new System.Drawing.Size(300, 18);
            this.lblTitleAuto.TabIndex = 0;
            this.lblTitleAuto.Text = "RESPALDO AUTOMATICO";
            // 
            // lblIconAuto
            // 
            this.lblIconAuto.BackColor = System.Drawing.Color.Transparent;
            this.lblIconAuto.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14F);
            this.lblIconAuto.ForeColor = System.Drawing.Color.White;
            this.lblIconAuto.Location = new System.Drawing.Point(12, 9);
            this.lblIconAuto.Name = "lblIconAuto";
            this.lblIconAuto.Size = new System.Drawing.Size(22, 22);
            this.lblIconAuto.TabIndex = 1;
            this.lblIconAuto.Text = "";
            // 
            // pnlHistory
            // 
            this.pnlHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlHistory.Controls.Add(this.pnlGridWrap);
            this.pnlHistory.Controls.Add(this.pnlHistHdr);
            this.pnlHistory.Location = new System.Drawing.Point(12, 417);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Size = new System.Drawing.Size(1488, 351);
            this.pnlHistory.TabIndex = 0;
            // 
            // pnlGridWrap
            // 
            this.pnlGridWrap.BackColor = System.Drawing.Color.White;
            this.pnlGridWrap.Controls.Add(this.dgvHistorialRespaldos);
            this.pnlGridWrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridWrap.Location = new System.Drawing.Point(0, 50);
            this.pnlGridWrap.Name = "pnlGridWrap";
            this.pnlGridWrap.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.pnlGridWrap.Size = new System.Drawing.Size(1488, 301);
            this.pnlGridWrap.TabIndex = 0;
            // 
            // dgvHistorialRespaldos
            // 
            this.dgvHistorialRespaldos.AllowUserToAddRows = false;
            this.dgvHistorialRespaldos.AllowUserToDeleteRows = false;
            this.dgvHistorialRespaldos.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorialRespaldos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorialRespaldos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvHistorialRespaldos.ColumnHeadersHeight = 36;
            this.dgvHistorialRespaldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHistorialRespaldos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFechayHora,
            this.colTamano,
            this.colUbicacion,
            this.colRestaurar});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistorialRespaldos.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvHistorialRespaldos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorialRespaldos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.dgvHistorialRespaldos.Location = new System.Drawing.Point(20, 12);
            this.dgvHistorialRespaldos.MultiSelect = false;
            this.dgvHistorialRespaldos.Name = "dgvHistorialRespaldos";
            this.dgvHistorialRespaldos.ReadOnly = true;
            this.dgvHistorialRespaldos.RowHeadersVisible = false;
            this.dgvHistorialRespaldos.RowTemplate.Height = 34;
            this.dgvHistorialRespaldos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorialRespaldos.Size = new System.Drawing.Size(1448, 277);
            this.dgvHistorialRespaldos.TabIndex = 0;
            // 
            // colFechayHora
            // 
            this.colFechayHora.HeaderText = "Fecha y Hora";
            this.colFechayHora.Name = "colFechayHora";
            this.colFechayHora.ReadOnly = true;
            this.colFechayHora.Width = 160;
            // 
            // colTamano
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTamano.DefaultCellStyle = dataGridViewCellStyle8;
            this.colTamano.HeaderText = "Tamaño";
            this.colTamano.Name = "colTamano";
            this.colTamano.ReadOnly = true;
            this.colTamano.Width = 90;
            // 
            // colUbicacion
            // 
            this.colUbicacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUbicacion.HeaderText = "Ruta";
            this.colUbicacion.Name = "colUbicacion";
            this.colUbicacion.ReadOnly = true;
            // 
            // colRestaurar
            // 
            this.colRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colRestaurar.HeaderText = "Accion";
            this.colRestaurar.Name = "colRestaurar";
            this.colRestaurar.ReadOnly = true;
            this.colRestaurar.Text = "Restaurar";
            this.colRestaurar.UseColumnTextForButtonValue = true;
            this.colRestaurar.Width = 90;
            // 
            // pnlHistHdr
            // 
            this.pnlHistHdr.BackColor = System.Drawing.Color.White;
            this.pnlHistHdr.Controls.Add(this.lblMostrar);
            this.pnlHistHdr.Controls.Add(this.btnAbrirCarpeta);
            this.pnlHistHdr.Controls.Add(this.lblIconHist);
            this.pnlHistHdr.Controls.Add(this.lblHistTitle);
            this.pnlHistHdr.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHistHdr.Location = new System.Drawing.Point(0, 0);
            this.pnlHistHdr.Name = "pnlHistHdr";
            this.pnlHistHdr.Size = new System.Drawing.Size(1488, 50);
            this.pnlHistHdr.TabIndex = 1;
            // 
            // lblMostrar
            // 
            this.lblMostrar.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMostrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(135)))));
            this.lblMostrar.Location = new System.Drawing.Point(280, 18);
            this.lblMostrar.Name = "lblMostrar";
            this.lblMostrar.Size = new System.Drawing.Size(600, 16);
            this.lblMostrar.TabIndex = 0;
            this.lblMostrar.Text = "Sin respaldos guardados";
            // 
            // btnAbrirCarpeta
            // 
            this.btnAbrirCarpeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbrirCarpeta.BackColor = System.Drawing.Color.White;
            this.btnAbrirCarpeta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirCarpeta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(224)))));
            this.btnAbrirCarpeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirCarpeta.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnAbrirCarpeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnAbrirCarpeta.Location = new System.Drawing.Point(2338, 12);
            this.btnAbrirCarpeta.Name = "btnAbrirCarpeta";
            this.btnAbrirCarpeta.Size = new System.Drawing.Size(118, 28);
            this.btnAbrirCarpeta.TabIndex = 1;
            this.btnAbrirCarpeta.Text = "Abrir carpeta";
            this.btnAbrirCarpeta.UseVisualStyleBackColor = false;
            // 
            // lblIconHist
            // 
            this.lblIconHist.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F);
            this.lblIconHist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblIconHist.Location = new System.Drawing.Point(16, 14);
            this.lblIconHist.Name = "lblIconHist";
            this.lblIconHist.Size = new System.Drawing.Size(22, 22);
            this.lblIconHist.TabIndex = 2;
            this.lblIconHist.Text = "";
            // 
            // lblHistTitle
            // 
            this.lblHistTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHistTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblHistTitle.Location = new System.Drawing.Point(44, 15);
            this.lblHistTitle.Name = "lblHistTitle";
            this.lblHistTitle.Size = new System.Drawing.Size(220, 20);
            this.lblHistTitle.TabIndex = 3;
            this.lblHistTitle.Text = "Historial de Respaldos";
            // 
            // pnlResumen
            // 
            this.pnlResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlResumen.Controls.Add(this.lblResumen);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumen.Location = new System.Drawing.Point(0, 784);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(1512, 36);
            this.pnlResumen.TabIndex = 1;
            // 
            // lblResumen
            // 
            this.lblResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(190)))), ((int)(((byte)(195)))));
            this.lblResumen.Location = new System.Drawing.Point(0, 0);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblResumen.Size = new System.Drawing.Size(1512, 36);
            this.lblResumen.TabIndex = 0;
            this.lblResumen.Text = "Ultimo auto-respaldo: (nunca ejecutado)";
            this.lblResumen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormRespaldo
            // 
            this.ClientSize = new System.Drawing.Size(1512, 820);
            this.Controls.Add(this.pnlHistory);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(820, 600);
            this.Name = "FormRespaldo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Respaldo de Datos";
            this.pnlHeader.ResumeLayout(false);
            this.pnlCards.ResumeLayout(false);
            this.tlpCards.ResumeLayout(false);
            this.pnlCardBackup.ResumeLayout(false);
            this.pnlCardBackup.PerformLayout();
            this.pnlHdrBackup.ResumeLayout(false);
            this.pnlCardRestore.ResumeLayout(false);
            this.pnlCardRestore.PerformLayout();
            this.pnlHdrRestore.ResumeLayout(false);
            this.pnlCardAuto.ResumeLayout(false);
            this.pnlCardAuto.PerformLayout();
            this.pnlAutoButtons.ResumeLayout(false);
            this.pnlHdrAuto.ResumeLayout(false);
            this.pnlHistory.ResumeLayout(false);
            this.pnlGridWrap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialRespaldos)).EndInit();
            this.pnlHistHdr.ResumeLayout(false);
            this.pnlResumen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel    pnlHeader;
        private System.Windows.Forms.Label    lblTitulo;
        private System.Windows.Forms.Label    lblHeaderSub;
        private System.Windows.Forms.Panel    pnlCards;
        private System.Windows.Forms.TableLayoutPanel tlpCards;
        private System.Windows.Forms.Panel    pnlCardBackup;
        private System.Windows.Forms.Panel    pnlHdrBackup;
        private System.Windows.Forms.Label    lblIconBackup;
        private System.Windows.Forms.Label    lblTitleBackup;
        private System.Windows.Forms.Label    lblUbicacion;
        private System.Windows.Forms.TextBox  txtUbicacion;
        private System.Windows.Forms.Button   btnUbicacionRespaldo;
        private System.Windows.Forms.Label    lblNombreArchivo;
        private System.Windows.Forms.TextBox  txtNombreArchivo;
        private System.Windows.Forms.CheckBox chkIncluirDatosVentas;
        private System.Windows.Forms.CheckBox chkIncluirDatosInventario;
        private System.Windows.Forms.CheckBox chkIncluirConfiguraciones;
        private System.Windows.Forms.Button   btnCrearRespaldo;
        private System.Windows.Forms.Panel    pnlCardRestore;
        private System.Windows.Forms.Panel    pnlHdrRestore;
        private System.Windows.Forms.Label    lblIconRestore;
        private System.Windows.Forms.Label    lblTitleRestore;
        private System.Windows.Forms.Label    lblArchivoRespaldo;
        private System.Windows.Forms.TextBox  txtArchivoRespaldo;
        private System.Windows.Forms.Button   btnArchivoRespaldo;
        private System.Windows.Forms.Label    lblAdvertencia;
        private System.Windows.Forms.Button   btnRestaurarDatos;
        private System.Windows.Forms.Panel    pnlCardAuto;
        private System.Windows.Forms.Panel    pnlHdrAuto;
        private System.Windows.Forms.Label    lblIconAuto;
        private System.Windows.Forms.Label    lblTitleAuto;
        private System.Windows.Forms.CheckBox chkActivarRespaldoAuto;
        private System.Windows.Forms.Label    lblFrecuencia;
        private System.Windows.Forms.RadioButton rbDiario;
        private System.Windows.Forms.RadioButton rbSemanal;
        private System.Windows.Forms.RadioButton rbMensual;
        private System.Windows.Forms.Label    lblDiaEnvio;
        private System.Windows.Forms.ComboBox cmbDiaEnvio;
        private System.Windows.Forms.Label    lblHoraAuto;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Label    lblConservar;
        private System.Windows.Forms.TextBox  txtDiasRespaldo;
        private System.Windows.Forms.Label    lblDiasUnidad;
        private System.Windows.Forms.Panel    pnlAutoButtons;
        private System.Windows.Forms.Button   btnGuardar;
        private System.Windows.Forms.Button   btnCancelar;
        private System.Windows.Forms.Panel    pnlHistory;
        private System.Windows.Forms.Panel    pnlHistHdr;
        private System.Windows.Forms.Label    lblIconHist;
        private System.Windows.Forms.Label    lblHistTitle;
        private System.Windows.Forms.Label    lblMostrar;
        private System.Windows.Forms.Button   btnAbrirCarpeta;
        private System.Windows.Forms.Panel    pnlGridWrap;
        private System.Windows.Forms.DataGridView dgvHistorialRespaldos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechayHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTamano;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUbicacion;
        private System.Windows.Forms.DataGridViewButtonColumn  colRestaurar;
        private System.Windows.Forms.Panel    pnlResumen;
        private System.Windows.Forms.Label    lblResumen;
    }
}
