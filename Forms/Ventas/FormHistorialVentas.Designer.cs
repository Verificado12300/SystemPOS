namespace SistemaPOS.Forms.Ventas
{
    partial class FormHistorialVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHistorialVentas));
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.pnlResumenCantidades = new System.Windows.Forms.Panel();
            this.txtTotalCantidad = new System.Windows.Forms.TextBox();
            this.txtEfectivoCantidad = new System.Windows.Forms.TextBox();
            this.txtCreditoCantidad = new System.Windows.Forms.TextBox();
            this.txtTransferenciaCantidad = new System.Windows.Forms.TextBox();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.lblYape = new System.Windows.Forms.Label();
            this.txtYapeCantidad = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSeparador = new System.Windows.Forms.Label();
            this.lblTransferencia = new System.Windows.Forms.Label();
            this.lblCredito = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lblVentasPeriodo = new System.Windows.Forms.Label();
            this.lblSubTitulo2 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVerDetalle = new System.Windows.Forms.DataGridViewImageColumn();
            this.colReimprimir = new System.Windows.Forms.DataGridViewImageColumn();
            this.colAnular = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.cmbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.lblSubTitulo = new System.Windows.Forms.Label();
            this.txtNumComprobante = new System.Windows.Forms.TextBox();
            this.lblNumComprobante = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlListado = new System.Windows.Forms.Panel();
            this.lblSubTitulo3 = new System.Windows.Forms.Label();
            this.pnlResumen.SuspendLayout();
            this.pnlResumenCantidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.pnlFiltro.SuspendLayout();
            this.pnlListado.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlResumen
            // 
            this.pnlResumen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlResumen.BackColor = System.Drawing.Color.White;
            this.pnlResumen.Controls.Add(this.pnlResumenCantidades);
            this.pnlResumen.Controls.Add(this.btnCerrar);
            this.pnlResumen.Controls.Add(this.btnExportar);
            this.pnlResumen.Controls.Add(this.lblVentasPeriodo);
            this.pnlResumen.Controls.Add(this.lblSubTitulo2);
            this.pnlResumen.Location = new System.Drawing.Point(835, 47);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(337, 602);
            this.pnlResumen.TabIndex = 135;
            // 
            // pnlResumenCantidades
            // 
            this.pnlResumenCantidades.Controls.Add(this.txtTotalCantidad);
            this.pnlResumenCantidades.Controls.Add(this.txtEfectivoCantidad);
            this.pnlResumenCantidades.Controls.Add(this.txtCreditoCantidad);
            this.pnlResumenCantidades.Controls.Add(this.txtTransferenciaCantidad);
            this.pnlResumenCantidades.Controls.Add(this.lblEfectivo);
            this.pnlResumenCantidades.Controls.Add(this.lblYape);
            this.pnlResumenCantidades.Controls.Add(this.txtYapeCantidad);
            this.pnlResumenCantidades.Controls.Add(this.lblTotal);
            this.pnlResumenCantidades.Controls.Add(this.lblSeparador);
            this.pnlResumenCantidades.Controls.Add(this.lblTransferencia);
            this.pnlResumenCantidades.Controls.Add(this.lblCredito);
            this.pnlResumenCantidades.Location = new System.Drawing.Point(15, 72);
            this.pnlResumenCantidades.Name = "pnlResumenCantidades";
            this.pnlResumenCantidades.Size = new System.Drawing.Size(317, 193);
            this.pnlResumenCantidades.TabIndex = 10017;
            // 
            // txtTotalCantidad
            // 
            this.txtTotalCantidad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTotalCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalCantidad.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCantidad.Location = new System.Drawing.Point(190, 144);
            this.txtTotalCantidad.Multiline = true;
            this.txtTotalCantidad.Name = "txtTotalCantidad";
            this.txtTotalCantidad.ReadOnly = true;
            this.txtTotalCantidad.Size = new System.Drawing.Size(110, 20);
            this.txtTotalCantidad.TabIndex = 10022;
            this.txtTotalCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEfectivoCantidad
            // 
            this.txtEfectivoCantidad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEfectivoCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEfectivoCantidad.Location = new System.Drawing.Point(190, 18);
            this.txtEfectivoCantidad.Multiline = true;
            this.txtEfectivoCantidad.Name = "txtEfectivoCantidad";
            this.txtEfectivoCantidad.ReadOnly = true;
            this.txtEfectivoCantidad.Size = new System.Drawing.Size(110, 20);
            this.txtEfectivoCantidad.TabIndex = 10018;
            this.txtEfectivoCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCreditoCantidad
            // 
            this.txtCreditoCantidad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCreditoCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCreditoCantidad.Location = new System.Drawing.Point(190, 102);
            this.txtCreditoCantidad.Multiline = true;
            this.txtCreditoCantidad.Name = "txtCreditoCantidad";
            this.txtCreditoCantidad.ReadOnly = true;
            this.txtCreditoCantidad.Size = new System.Drawing.Size(110, 20);
            this.txtCreditoCantidad.TabIndex = 10021;
            this.txtCreditoCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTransferenciaCantidad
            // 
            this.txtTransferenciaCantidad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTransferenciaCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTransferenciaCantidad.Location = new System.Drawing.Point(190, 74);
            this.txtTransferenciaCantidad.Multiline = true;
            this.txtTransferenciaCantidad.Name = "txtTransferenciaCantidad";
            this.txtTransferenciaCantidad.ReadOnly = true;
            this.txtTransferenciaCantidad.Size = new System.Drawing.Size(110, 20);
            this.txtTransferenciaCantidad.TabIndex = 10020;
            this.txtTransferenciaCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblEfectivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfectivo.Location = new System.Drawing.Point(3, 21);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(52, 15);
            this.lblEfectivo.TabIndex = 168;
            this.lblEfectivo.Text = "Efectivo:";
            // 
            // lblYape
            // 
            this.lblYape.AutoSize = true;
            this.lblYape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblYape.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYape.Location = new System.Drawing.Point(3, 49);
            this.lblYape.Name = "lblYape";
            this.lblYape.Size = new System.Drawing.Size(35, 15);
            this.lblYape.TabIndex = 163;
            this.lblYape.Text = "Yape:";
            // 
            // txtYapeCantidad
            // 
            this.txtYapeCantidad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtYapeCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtYapeCantidad.Location = new System.Drawing.Point(190, 46);
            this.txtYapeCantidad.Multiline = true;
            this.txtYapeCantidad.Name = "txtYapeCantidad";
            this.txtYapeCantidad.ReadOnly = true;
            this.txtYapeCantidad.Size = new System.Drawing.Size(110, 20);
            this.txtYapeCantidad.TabIndex = 10019;
            this.txtYapeCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(3, 144);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(58, 20);
            this.lblTotal.TabIndex = 164;
            this.lblTotal.Text = "TOTAL:";
            // 
            // lblSeparador
            // 
            this.lblSeparador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.lblSeparador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.lblSeparador.Location = new System.Drawing.Point(3, 128);
            this.lblSeparador.Name = "lblSeparador";
            this.lblSeparador.Size = new System.Drawing.Size(305, 1);
            this.lblSeparador.TabIndex = 165;
            // 
            // lblTransferencia
            // 
            this.lblTransferencia.AutoSize = true;
            this.lblTransferencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTransferencia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransferencia.Location = new System.Drawing.Point(3, 77);
            this.lblTransferencia.Name = "lblTransferencia";
            this.lblTransferencia.Size = new System.Drawing.Size(79, 15);
            this.lblTransferencia.TabIndex = 166;
            this.lblTransferencia.Text = "Transferencia:";
            // 
            // lblCredito
            // 
            this.lblCredito.AutoSize = true;
            this.lblCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCredito.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredito.Location = new System.Drawing.Point(4, 104);
            this.lblCredito.Name = "lblCredito";
            this.lblCredito.Size = new System.Drawing.Size(60, 15);
            this.lblCredito.TabIndex = 167;
            this.lblCredito.Text = "A Crédito:";
            //
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(45)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(118, 557);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(98, 27);
            this.btnCerrar.TabIndex = 10015;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.White;
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnExportar.Location = new System.Drawing.Point(15, 557);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(98, 27);
            this.btnExportar.TabIndex = 10014;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            // 
            // lblVentasPeriodo
            // 
            this.lblVentasPeriodo.AutoSize = true;
            this.lblVentasPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblVentasPeriodo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentasPeriodo.Location = new System.Drawing.Point(15, 54);
            this.lblVentasPeriodo.Name = "lblVentasPeriodo";
            this.lblVentasPeriodo.Size = new System.Drawing.Size(122, 15);
            this.lblVentasPeriodo.TabIndex = 161;
            this.lblVentasPeriodo.Text = "Ventas del período: 45";
            // 
            // lblSubTitulo2
            // 
            this.lblSubTitulo2.AutoSize = true;
            this.lblSubTitulo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubTitulo2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitulo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSubTitulo2.Location = new System.Drawing.Point(14, 11);
            this.lblSubTitulo2.Name = "lblSubTitulo2";
            this.lblSubTitulo2.Size = new System.Drawing.Size(79, 20);
            this.lblSubTitulo2.TabIndex = 115;
            this.lblSubTitulo2.Text = "RESUMEN";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnLimpiar.Location = new System.Drawing.Point(407, 136);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(105, 28);
            this.btnLimpiar.TabIndex = 142;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnBuscar.Location = new System.Drawing.Point(273, 136);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(105, 28);
            this.btnBuscar.TabIndex = 141;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // dgvVentas
            // 
            this.dgvVentas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumero,
            this.colFechaHora,
            this.colComprobante,
            this.colCliente,
            this.colItems,
            this.colMetodoPago,
            this.colTotal,
            this.colEstado,
            this.colVerDetalle,
            this.colReimprimir,
            this.colAnular});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVentas.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVentas.EnableHeadersVisualStyles = false;
            this.dgvVentas.Location = new System.Drawing.Point(0, 54);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.RowHeadersVisible = false;
            this.dgvVentas.RowTemplate.Height = 50;
            this.dgvVentas.Size = new System.Drawing.Size(812, 304);
            this.dgvVentas.TabIndex = 128;
            // 
            // colNumero
            // 
            this.colNumero.HeaderText = "#";
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            this.colNumero.Width = 25;
            // 
            // colFechaHora
            // 
            this.colFechaHora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colFechaHora.HeaderText = "Fecha y Hora";
            this.colFechaHora.Name = "colFechaHora";
            this.colFechaHora.ReadOnly = true;
            // 
            // colComprobante
            // 
            this.colComprobante.HeaderText = "Comprobante";
            this.colComprobante.Name = "colComprobante";
            this.colComprobante.ReadOnly = true;
            this.colComprobante.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colComprobante.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colComprobante.Width = 120;
            // 
            // colCliente
            // 
            this.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            // 
            // colItems
            // 
            this.colItems.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colItems.FillWeight = 90F;
            this.colItems.HeaderText = "Items";
            this.colItems.Name = "colItems";
            this.colItems.ReadOnly = true;
            this.colItems.Width = 60;
            // 
            // colMetodoPago
            // 
            this.colMetodoPago.HeaderText = "Método de Pago";
            this.colMetodoPago.Name = "colMetodoPago";
            this.colMetodoPago.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 80;
            // 
            // colEstado
            // 
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // colVerDetalle
            // 
            this.colVerDetalle.HeaderText = "";
            this.colVerDetalle.Image = ((System.Drawing.Image)(resources.GetObject("colVerDetalle.Image")));
            this.colVerDetalle.Name = "colVerDetalle";
            this.colVerDetalle.ReadOnly = true;
            this.colVerDetalle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colVerDetalle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colVerDetalle.Width = 25;
            // 
            // colReimprimir
            // 
            this.colReimprimir.HeaderText = "";
            this.colReimprimir.Image = ((System.Drawing.Image)(resources.GetObject("colReimprimir.Image")));
            this.colReimprimir.Name = "colReimprimir";
            this.colReimprimir.ReadOnly = true;
            this.colReimprimir.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colReimprimir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colReimprimir.Width = 25;
            // 
            // colAnular
            // 
            this.colAnular.HeaderText = "";
            this.colAnular.Image = ((System.Drawing.Image)(resources.GetObject("colAnular.Image")));
            this.colAnular.Name = "colAnular";
            this.colAnular.Width = 25;
            //
            // pnlFiltro
            // 
            this.pnlFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltro.BackColor = System.Drawing.Color.White;
            this.pnlFiltro.Controls.Add(this.btnBuscar);
            this.pnlFiltro.Controls.Add(this.btnLimpiar);
            this.pnlFiltro.Controls.Add(this.lblEstado);
            this.pnlFiltro.Controls.Add(this.cmbEstado);
            this.pnlFiltro.Controls.Add(this.cmbCliente);
            this.pnlFiltro.Controls.Add(this.lblProveedor);
            this.pnlFiltro.Controls.Add(this.cmbTipoComprobante);
            this.pnlFiltro.Controls.Add(this.lblTipoComprobante);
            this.pnlFiltro.Controls.Add(this.lblSubTitulo);
            this.pnlFiltro.Controls.Add(this.txtNumComprobante);
            this.pnlFiltro.Controls.Add(this.lblNumComprobante);
            this.pnlFiltro.Location = new System.Drawing.Point(16, 47);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(813, 180);
            this.pnlFiltro.TabIndex = 134;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(464, 57);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(45, 15);
            this.lblEstado.TabIndex = 135;
            this.lblEstado.Text = "Estado:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(573, 54);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(175, 21);
            this.cmbEstado.TabIndex = 134;
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(150, 54);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(228, 21);
            this.cmbCliente.TabIndex = 133;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProveedor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(15, 57);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(47, 15);
            this.lblProveedor.TabIndex = 132;
            this.lblProveedor.Text = "Cliente:";
            // 
            // cmbTipoComprobante
            // 
            this.cmbTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoComprobante.FormattingEnabled = true;
            this.cmbTipoComprobante.Items.AddRange(new object[] {
            "Factura",
            "Boleta",
            "Nota de Venta"});
            this.cmbTipoComprobante.Location = new System.Drawing.Point(150, 89);
            this.cmbTipoComprobante.Name = "cmbTipoComprobante";
            this.cmbTipoComprobante.Size = new System.Drawing.Size(228, 21);
            this.cmbTipoComprobante.TabIndex = 122;
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoComprobante.Location = new System.Drawing.Point(15, 94);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(110, 15);
            this.lblTipoComprobante.TabIndex = 121;
            this.lblTipoComprobante.Text = "Tipo Comprobante:";
            // 
            // lblSubTitulo
            // 
            this.lblSubTitulo.AutoSize = true;
            this.lblSubTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSubTitulo.Location = new System.Drawing.Point(14, 11);
            this.lblSubTitulo.Name = "lblSubTitulo";
            this.lblSubTitulo.Size = new System.Drawing.Size(161, 20);
            this.lblSubTitulo.TabIndex = 115;
            this.lblSubTitulo.Text = "FILTRO DE BÚSQUEDA";
            // 
            // txtNumComprobante
            // 
            this.txtNumComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumComprobante.Location = new System.Drawing.Point(573, 88);
            this.txtNumComprobante.Multiline = true;
            this.txtNumComprobante.Name = "txtNumComprobante";
            this.txtNumComprobante.Size = new System.Drawing.Size(175, 20);
            this.txtNumComprobante.TabIndex = 116;
            // 
            // lblNumComprobante
            // 
            this.lblNumComprobante.AutoSize = true;
            this.lblNumComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNumComprobante.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumComprobante.Location = new System.Drawing.Point(464, 91);
            this.lblNumComprobante.Name = "lblNumComprobante";
            this.lblNumComprobante.Size = new System.Drawing.Size(101, 15);
            this.lblNumComprobante.TabIndex = 117;
            this.lblNumComprobante.Text = "N° Comprobante:";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta.Location = new System.Drawing.Point(664, 19);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(40, 15);
            this.lblHasta.TabIndex = 10013;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(713, 16);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(82, 20);
            this.dtpHasta.TabIndex = 10012;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.Location = new System.Drawing.Point(432, 19);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(42, 15);
            this.lblDesde.TabIndex = 10011;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(484, 16);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(83, 20);
            this.dtpDesde.TabIndex = 10010;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(146, 21);
            this.lblTitulo.TabIndex = 133;
            this.lblTitulo.Text = "Historial de Ventas";
            // 
            // pnlListado
            // 
            this.pnlListado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlListado.BackColor = System.Drawing.Color.White;
            this.pnlListado.Controls.Add(this.lblHasta);
            this.pnlListado.Controls.Add(this.lblSubTitulo3);
            this.pnlListado.Controls.Add(this.dgvVentas);
            this.pnlListado.Controls.Add(this.dtpDesde);
            this.pnlListado.Controls.Add(this.dtpHasta);
            this.pnlListado.Controls.Add(this.lblDesde);
            this.pnlListado.Location = new System.Drawing.Point(16, 233);
            this.pnlListado.Name = "pnlListado";
            this.pnlListado.Size = new System.Drawing.Size(813, 416);
            this.pnlListado.TabIndex = 135;
            // 
            // lblSubTitulo3
            // 
            this.lblSubTitulo3.AutoSize = true;
            this.lblSubTitulo3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubTitulo3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitulo3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSubTitulo3.Location = new System.Drawing.Point(14, 17);
            this.lblSubTitulo3.Name = "lblSubTitulo3";
            this.lblSubTitulo3.Size = new System.Drawing.Size(149, 20);
            this.lblSubTitulo3.TabIndex = 145;
            this.lblSubTitulo3.Text = "LISTADO DE VENTAS";
            // 
            // FormHistorialVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlListado);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.pnlFiltro);
            this.Controls.Add(this.lblTitulo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHistorialVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormHistorialVentas";
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.pnlResumenCantidades.ResumeLayout(false);
            this.pnlResumenCantidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            this.pnlListado.ResumeLayout(false);
            this.pnlListado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Label lblSubTitulo2;
        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.ComboBox cmbTipoComprobante;
        private System.Windows.Forms.Label lblTipoComprobante;
        private System.Windows.Forms.Label lblSubTitulo;
        private System.Windows.Forms.TextBox txtNumComprobante;
        private System.Windows.Forms.Label lblNumComprobante;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlListado;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblSubTitulo3;
        private System.Windows.Forms.Label lblEfectivo;
        private System.Windows.Forms.Label lblCredito;
        private System.Windows.Forms.Label lblTransferencia;
        private System.Windows.Forms.Label lblSeparador;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblYape;
        private System.Windows.Forms.Label lblVentasPeriodo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Panel pnlResumenCantidades;
        private System.Windows.Forms.TextBox txtEfectivoCantidad;
        private System.Windows.Forms.TextBox txtYapeCantidad;
        private System.Windows.Forms.TextBox txtTotalCantidad;
        private System.Windows.Forms.TextBox txtCreditoCantidad;
        private System.Windows.Forms.TextBox txtTransferenciaCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMetodoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewImageColumn colVerDetalle;
        private System.Windows.Forms.DataGridViewImageColumn colReimprimir;
        private System.Windows.Forms.DataGridViewImageColumn colAnular;
    }
}