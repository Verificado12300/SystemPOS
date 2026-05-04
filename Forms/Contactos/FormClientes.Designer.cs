namespace SistemaPOS.Forms.Contactos
{
    partial class FormClientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClientes));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlCard4 = new System.Windows.Forms.Panel();
            this.lblCardTitle4 = new System.Windows.Forms.Label();
            this.lblCardVal4 = new System.Windows.Forms.Label();
            this.pnlAccent4 = new System.Windows.Forms.Panel();
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.lblCardTitle3 = new System.Windows.Forms.Label();
            this.lblCardVal3 = new System.Windows.Forms.Label();
            this.pnlAccent3 = new System.Windows.Forms.Panel();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblCardTitle2 = new System.Windows.Forms.Label();
            this.lblCardVal2 = new System.Windows.Forms.Label();
            this.pnlAccent2 = new System.Windows.Forms.Panel();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.lblCardTitle1 = new System.Windows.Forms.Label();
            this.lblCardVal1 = new System.Windows.Forms.Label();
            this.pnlAccent1 = new System.Windows.Forms.Panel();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblFiltrar = new System.Windows.Forms.Label();
            this.cmbFiltrar = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.pnlGridWrap = new System.Windows.Forms.Panel();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.lblMostrar = new System.Windows.Forms.Label();
            this.lblRojo = new System.Windows.Forms.Label();
            this.lblVerde = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlCard4.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            this.pnlGridWrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.pnlResumen.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlHeader.Controls.Add(this.btnNuevoCliente);
            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1284, 68);
            this.pnlHeader.TabIndex = 200;
            // 
            // lblHeaderSub
            // 
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.lblHeaderSub.Location = new System.Drawing.Point(22, 40);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(195, 15);
            this.lblHeaderSub.TabIndex = 0;
            this.lblHeaderSub.Text = "Listado y administración de clientes";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(22, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(181, 25);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Gestión de Clientes";
            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.pnlStats.Controls.Add(this.pnlCard4);
            this.pnlStats.Controls.Add(this.pnlCard3);
            this.pnlStats.Controls.Add(this.pnlCard2);
            this.pnlStats.Controls.Add(this.pnlCard1);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Location = new System.Drawing.Point(0, 68);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(1284, 88);
            this.pnlStats.TabIndex = 201;
            // 
            // pnlCard4
            // 
            this.pnlCard4.BackColor = System.Drawing.Color.White;
            this.pnlCard4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard4.Controls.Add(this.lblCardTitle4);
            this.pnlCard4.Controls.Add(this.lblCardVal4);
            this.pnlCard4.Controls.Add(this.pnlAccent4);
            this.pnlCard4.Location = new System.Drawing.Point(964, 12);
            this.pnlCard4.Name = "pnlCard4";
            this.pnlCard4.Size = new System.Drawing.Size(304, 64);
            this.pnlCard4.TabIndex = 3;
            // 
            // lblCardTitle4
            // 
            this.lblCardTitle4.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblCardTitle4.Location = new System.Drawing.Point(18, 41);
            this.lblCardTitle4.Name = "lblCardTitle4";
            this.lblCardTitle4.Size = new System.Drawing.Size(282, 16);
            this.lblCardTitle4.TabIndex = 2;
            this.lblCardTitle4.Text = "DEUDA TOTAL CxC";
            // 
            // lblCardVal4
            // 
            this.lblCardVal4.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblCardVal4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.lblCardVal4.Location = new System.Drawing.Point(18, 9);
            this.lblCardVal4.Name = "lblCardVal4";
            this.lblCardVal4.Size = new System.Drawing.Size(282, 28);
            this.lblCardVal4.TabIndex = 1;
            this.lblCardVal4.Text = "S/ 0.00";
            // 
            // pnlAccent4
            // 
            this.pnlAccent4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.pnlAccent4.Location = new System.Drawing.Point(0, 0);
            this.pnlAccent4.Name = "pnlAccent4";
            this.pnlAccent4.Size = new System.Drawing.Size(6, 64);
            this.pnlAccent4.TabIndex = 0;
            // 
            // pnlCard3
            // 
            this.pnlCard3.BackColor = System.Drawing.Color.White;
            this.pnlCard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard3.Controls.Add(this.lblCardTitle3);
            this.pnlCard3.Controls.Add(this.lblCardVal3);
            this.pnlCard3.Controls.Add(this.pnlAccent3);
            this.pnlCard3.Location = new System.Drawing.Point(648, 12);
            this.pnlCard3.Name = "pnlCard3";
            this.pnlCard3.Size = new System.Drawing.Size(304, 64);
            this.pnlCard3.TabIndex = 2;
            // 
            // lblCardTitle3
            // 
            this.lblCardTitle3.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.lblCardTitle3.Location = new System.Drawing.Point(18, 41);
            this.lblCardTitle3.Name = "lblCardTitle3";
            this.lblCardTitle3.Size = new System.Drawing.Size(282, 16);
            this.lblCardTitle3.TabIndex = 2;
            this.lblCardTitle3.Text = "CON SALDO PENDIENTE";
            // 
            // lblCardVal3
            // 
            this.lblCardVal3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblCardVal3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.lblCardVal3.Location = new System.Drawing.Point(18, 9);
            this.lblCardVal3.Name = "lblCardVal3";
            this.lblCardVal3.Size = new System.Drawing.Size(282, 28);
            this.lblCardVal3.TabIndex = 1;
            this.lblCardVal3.Text = "0";
            // 
            // pnlAccent3
            // 
            this.pnlAccent3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.pnlAccent3.Location = new System.Drawing.Point(0, 0);
            this.pnlAccent3.Name = "pnlAccent3";
            this.pnlAccent3.Size = new System.Drawing.Size(6, 64);
            this.pnlAccent3.TabIndex = 0;
            // 
            // pnlCard2
            // 
            this.pnlCard2.BackColor = System.Drawing.Color.White;
            this.pnlCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard2.Controls.Add(this.lblCardTitle2);
            this.pnlCard2.Controls.Add(this.lblCardVal2);
            this.pnlCard2.Controls.Add(this.pnlAccent2);
            this.pnlCard2.Location = new System.Drawing.Point(332, 12);
            this.pnlCard2.Name = "pnlCard2";
            this.pnlCard2.Size = new System.Drawing.Size(304, 64);
            this.pnlCard2.TabIndex = 1;
            // 
            // lblCardTitle2
            // 
            this.lblCardTitle2.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblCardTitle2.Location = new System.Drawing.Point(18, 41);
            this.lblCardTitle2.Name = "lblCardTitle2";
            this.lblCardTitle2.Size = new System.Drawing.Size(282, 16);
            this.lblCardTitle2.TabIndex = 2;
            this.lblCardTitle2.Text = "CLIENTES ACTIVOS";
            // 
            // lblCardVal2
            // 
            this.lblCardVal2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblCardVal2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.lblCardVal2.Location = new System.Drawing.Point(18, 9);
            this.lblCardVal2.Name = "lblCardVal2";
            this.lblCardVal2.Size = new System.Drawing.Size(282, 28);
            this.lblCardVal2.TabIndex = 1;
            this.lblCardVal2.Text = "0";
            // 
            // pnlAccent2
            // 
            this.pnlAccent2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.pnlAccent2.Location = new System.Drawing.Point(0, 0);
            this.pnlAccent2.Name = "pnlAccent2";
            this.pnlAccent2.Size = new System.Drawing.Size(6, 64);
            this.pnlAccent2.TabIndex = 0;
            // 
            // pnlCard1
            // 
            this.pnlCard1.BackColor = System.Drawing.Color.White;
            this.pnlCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard1.Controls.Add(this.lblCardTitle1);
            this.pnlCard1.Controls.Add(this.lblCardVal1);
            this.pnlCard1.Controls.Add(this.pnlAccent1);
            this.pnlCard1.Location = new System.Drawing.Point(16, 12);
            this.pnlCard1.Name = "pnlCard1";
            this.pnlCard1.Size = new System.Drawing.Size(304, 64);
            this.pnlCard1.TabIndex = 0;
            // 
            // lblCardTitle1
            // 
            this.lblCardTitle1.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lblCardTitle1.Location = new System.Drawing.Point(18, 41);
            this.lblCardTitle1.Name = "lblCardTitle1";
            this.lblCardTitle1.Size = new System.Drawing.Size(282, 16);
            this.lblCardTitle1.TabIndex = 2;
            this.lblCardTitle1.Text = "TOTAL REGISTRADOS";
            // 
            // lblCardVal1
            // 
            this.lblCardVal1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblCardVal1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.lblCardVal1.Location = new System.Drawing.Point(18, 9);
            this.lblCardVal1.Name = "lblCardVal1";
            this.lblCardVal1.Size = new System.Drawing.Size(282, 28);
            this.lblCardVal1.TabIndex = 1;
            this.lblCardVal1.Text = "0";
            // 
            // pnlAccent1
            // 
            this.pnlAccent1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.pnlAccent1.Location = new System.Drawing.Point(0, 0);
            this.pnlAccent1.Name = "pnlAccent1";
            this.pnlAccent1.Size = new System.Drawing.Size(6, 64);
            this.pnlAccent1.TabIndex = 0;
            // 
            // pnlDatos
            // 
            this.pnlDatos.BackColor = System.Drawing.Color.White;
            this.pnlDatos.Controls.Add(this.lblBuscar);
            this.pnlDatos.Controls.Add(this.txtBuscar);
            this.pnlDatos.Controls.Add(this.lblFiltrar);
            this.pnlDatos.Controls.Add(this.cmbFiltrar);
            this.pnlDatos.Controls.Add(this.lblEstado);
            this.pnlDatos.Controls.Add(this.cmbEstado);
            this.pnlDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDatos.Location = new System.Drawing.Point(0, 156);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(1284, 56);
            this.pnlDatos.TabIndex = 202;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(90)))), ((int)(((byte)(95)))));
            this.lblBuscar.Location = new System.Drawing.Point(18, 19);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(49, 17);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(75, 15);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(370, 24);
            this.txtBuscar.TabIndex = 1;
            // 
            // lblFiltrar
            // 
            this.lblFiltrar.AutoSize = true;
            this.lblFiltrar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFiltrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(90)))), ((int)(((byte)(95)))));
            this.lblFiltrar.Location = new System.Drawing.Point(460, 19);
            this.lblFiltrar.Name = "lblFiltrar";
            this.lblFiltrar.Size = new System.Drawing.Size(37, 17);
            this.lblFiltrar.TabIndex = 2;
            this.lblFiltrar.Text = "Tipo:";
            // 
            // cmbFiltrar
            // 
            this.cmbFiltrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltrar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbFiltrar.FormattingEnabled = true;
            this.cmbFiltrar.Location = new System.Drawing.Point(502, 15);
            this.cmbFiltrar.Name = "cmbFiltrar";
            this.cmbFiltrar.Size = new System.Drawing.Size(148, 25);
            this.cmbFiltrar.TabIndex = 3;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(90)))), ((int)(((byte)(95)))));
            this.lblEstado.Location = new System.Drawing.Point(664, 19);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(51, 17);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "Estado:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(718, 15);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(138, 25);
            this.cmbEstado.TabIndex = 5;
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnNuevoCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoCliente.FlatAppearance.BorderSize = 0;
            this.btnNuevoCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(148)))), ((int)(((byte)(80)))));
            this.btnNuevoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNuevoCliente.ForeColor = System.Drawing.Color.White;
            this.btnNuevoCliente.Location = new System.Drawing.Point(1113, 21);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(152, 34);
            this.btnNuevoCliente.TabIndex = 0;
            this.btnNuevoCliente.Text = "+ Nuevo Cliente";
            this.btnNuevoCliente.UseVisualStyleBackColor = false;
            // 
            // pnlGridWrap
            // 
            this.pnlGridWrap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.pnlGridWrap.Controls.Add(this.dgvClientes);
            this.pnlGridWrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridWrap.Location = new System.Drawing.Point(0, 212);
            this.pnlGridWrap.Name = "pnlGridWrap";
            this.pnlGridWrap.Padding = new System.Windows.Forms.Padding(14, 10, 14, 0);
            this.pnlGridWrap.Size = new System.Drawing.Size(1284, 472);
            this.pnlGridWrap.TabIndex = 204;
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.dgvClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClientes.ColumnHeadersHeight = 34;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumero,
            this.colDocumento,
            this.colCliente,
            this.colEmail,
            this.colTelefono,
            this.colDireccion,
            this.colSaldo,
            this.colEstado,
            this.colEditar,
            this.colEliminar});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientes.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientes.EnableHeadersVisualStyles = false;
            this.dgvClientes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.dgvClientes.Location = new System.Drawing.Point(14, 10);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.RowTemplate.Height = 40;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(1256, 462);
            this.dgvClientes.TabIndex = 0;
            // 
            // colNumero
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(140)))), ((int)(((byte)(150)))));
            this.colNumero.DefaultCellStyle = dataGridViewCellStyle3;
            this.colNumero.HeaderText = "#";
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            this.colNumero.Width = 44;
            // 
            // colDocumento
            // 
            this.colDocumento.HeaderText = "Documento";
            this.colDocumento.Name = "colDocumento";
            this.colDocumento.ReadOnly = true;
            this.colDocumento.Width = 158;
            // 
            // colCliente
            // 
            this.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCliente.HeaderText = "Nombre / Razón Social";
            this.colCliente.MinimumWidth = 180;
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Width = 185;
            // 
            // colTelefono
            // 
            this.colTelefono.HeaderText = "Teléfono";
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.ReadOnly = true;
            this.colTelefono.Width = 118;
            // 
            // colDireccion
            // 
            this.colDireccion.HeaderText = "Dirección";
            this.colDireccion.Name = "colDireccion";
            this.colDireccion.ReadOnly = true;
            this.colDireccion.Width = 168;
            // 
            // colSaldo
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.colSaldo.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSaldo.HeaderText = "Saldo CxC";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.ReadOnly = true;
            this.colSaldo.Width = 110;
            // 
            // colEstado
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.colEstado.DefaultCellStyle = dataGridViewCellStyle5;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 92;
            // 
            // colEditar
            // 
            this.colEditar.HeaderText = "";
            this.colEditar.Image = ((System.Drawing.Image)(resources.GetObject("colEditar.Image")));
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Width = 40;
            // 
            // colEliminar
            // 
            this.colEliminar.HeaderText = "";
            this.colEliminar.Image = ((System.Drawing.Image)(resources.GetObject("colEliminar.Image")));
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.ReadOnly = true;
            this.colEliminar.Width = 40;
            // 
            // pnlResumen
            // 
            this.pnlResumen.BackColor = System.Drawing.Color.White;
            this.pnlResumen.Controls.Add(this.lblMostrar);
            this.pnlResumen.Controls.Add(this.lblRojo);
            this.pnlResumen.Controls.Add(this.lblVerde);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumen.Location = new System.Drawing.Point(0, 684);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(1284, 36);
            this.pnlResumen.TabIndex = 203;
            // 
            // lblMostrar
            // 
            this.lblMostrar.AutoSize = true;
            this.lblMostrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMostrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblMostrar.Location = new System.Drawing.Point(16, 11);
            this.lblMostrar.Name = "lblMostrar";
            this.lblMostrar.Size = new System.Drawing.Size(117, 15);
            this.lblMostrar.TabIndex = 0;
            this.lblMostrar.Text = "Mostrando 0 clientes";
            // 
            // lblRojo
            // 
            this.lblRojo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRojo.AutoSize = true;
            this.lblRojo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRojo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.lblRojo.Location = new System.Drawing.Point(2074, 11);
            this.lblRojo.Name = "lblRojo";
            this.lblRojo.Size = new System.Drawing.Size(140, 15);
            this.lblRojo.TabIndex = 1;
            this.lblRojo.Text = "● Rojo = Saldo pendiente";
            // 
            // lblVerde
            // 
            this.lblVerde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVerde.AutoSize = true;
            this.lblVerde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVerde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblVerde.Location = new System.Drawing.Point(2241, 11);
            this.lblVerde.Name = "lblVerde";
            this.lblVerde.Size = new System.Drawing.Size(128, 15);
            this.lblVerde.TabIndex = 2;
            this.lblVerde.Text = "● Verde = Saldo a favor";
            // 
            // FormClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1284, 720);
            this.Controls.Add(this.pnlGridWrap);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlResumen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormClientes";
            this.Text = "FormClientes";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlCard4.ResumeLayout(false);
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard1.ResumeLayout(false);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlGridWrap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // ── Declaraciones ─────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblHeaderSub;

        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlCard1, pnlCard2, pnlCard3, pnlCard4;
        private System.Windows.Forms.Panel pnlAccent1, pnlAccent2, pnlAccent3, pnlAccent4;
        private System.Windows.Forms.Label lblCardVal1, lblCardVal2, lblCardVal3, lblCardVal4;
        private System.Windows.Forms.Label lblCardTitle1, lblCardTitle2, lblCardTitle3, lblCardTitle4;

        private System.Windows.Forms.Panel    pnlDatos;
        private System.Windows.Forms.Label    lblBuscar;
        private System.Windows.Forms.TextBox  txtBuscar;
        private System.Windows.Forms.Label    lblFiltrar;
        private System.Windows.Forms.ComboBox cmbFiltrar;
        private System.Windows.Forms.Label    lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button   btnNuevoCliente;

        private System.Windows.Forms.Panel pnlGridWrap;
        private System.Windows.Forms.DataGridView              dgvClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewImageColumn   colEditar;
        private System.Windows.Forms.DataGridViewImageColumn   colEliminar;

        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblMostrar;
        private System.Windows.Forms.Label lblRojo;
        private System.Windows.Forms.Label lblVerde;
    }
}
