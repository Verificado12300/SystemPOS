namespace SistemaPOS.Forms.Principal
{
    partial class FormDashboard
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlPeriodToggle = new System.Windows.Forms.Panel();
            this.btnMes = new System.Windows.Forms.Button();
            this.btnSemana = new System.Windows.Forms.Button();
            this.btnDia = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlKPIVentas = new System.Windows.Forms.Panel();
            this.lblIcoVentas = new System.Windows.Forms.Label();
            this.pnlAccentVentas = new System.Windows.Forms.Panel();
            this.lblKPIVentasCant = new System.Windows.Forms.Label();
            this.lblKPIVentasValor = new System.Windows.Forms.Label();
            this.lblKPIVentasTitulo = new System.Windows.Forms.Label();
            this.pnlKPIUtilidad = new System.Windows.Forms.Panel();
            this.lblIcoUtilidad = new System.Windows.Forms.Label();
            this.pnlAccentUtilidad = new System.Windows.Forms.Panel();
            this.lblKPIUtilidadPorcentaje = new System.Windows.Forms.Label();
            this.lblKPIUtilidadValor = new System.Windows.Forms.Label();
            this.lblKPIUtilidadTitulo = new System.Windows.Forms.Label();
            this.pnlKPIAlertas = new System.Windows.Forms.Panel();
            this.lblIcoAlertas = new System.Windows.Forms.Label();
            this.pnlAccentAlertas = new System.Windows.Forms.Panel();
            this.lblKPIAlertasDetalle = new System.Windows.Forms.Label();
            this.lblKPIAlertasValor = new System.Windows.Forms.Label();
            this.lblKPIAlertasTitulo = new System.Windows.Forms.Label();
            this.pnlGrafico = new System.Windows.Forms.Panel();
            this.lblIcoGrafico = new System.Windows.Forms.Label();
            this.chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblGraficoTitulo = new System.Windows.Forms.Label();
            this.pnlTopProductos = new System.Windows.Forms.Panel();
            this.lblIcoTop = new System.Windows.Forms.Label();
            this.pnlTopLista = new System.Windows.Forms.Panel();
            this.lblTopTitulo = new System.Windows.Forms.Label();
            this.pnlOperaciones = new System.Windows.Forms.Panel();
            this.lblIcoOps = new System.Windows.Forms.Label();
            this.dgvOperaciones = new System.Windows.Forms.DataGridView();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblOperacionesTitulo = new System.Windows.Forms.Label();
            this.pnlKPICxP = new System.Windows.Forms.Panel();
            this.lblIcoCxP = new System.Windows.Forms.Label();
            this.pnlAccentCxP = new System.Windows.Forms.Panel();
            this.lblKPICxPCant = new System.Windows.Forms.Label();
            this.lblKPICxPValor = new System.Windows.Forms.Label();
            this.lblKPICxPTitulo = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlPeriodToggle.SuspendLayout();
            this.pnlKPIVentas.SuspendLayout();
            this.pnlKPIUtilidad.SuspendLayout();
            this.pnlKPIAlertas.SuspendLayout();
            this.pnlGrafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).BeginInit();
            this.pnlTopProductos.SuspendLayout();
            this.pnlOperaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperaciones)).BeginInit();
            this.pnlKPICxP.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.pnlHeader.Controls.Add(this.pnlPeriodToggle);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 10, 20, 5);
            this.pnlHeader.Size = new System.Drawing.Size(1444, 55);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlPeriodToggle
            // 
            this.pnlPeriodToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPeriodToggle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(244)))));
            this.pnlPeriodToggle.Controls.Add(this.btnMes);
            this.pnlPeriodToggle.Controls.Add(this.btnSemana);
            this.pnlPeriodToggle.Controls.Add(this.btnDia);
            this.pnlPeriodToggle.Location = new System.Drawing.Point(1052, 10);
            this.pnlPeriodToggle.Name = "pnlPeriodToggle";
            this.pnlPeriodToggle.Padding = new System.Windows.Forms.Padding(3);
            this.pnlPeriodToggle.Size = new System.Drawing.Size(372, 34);
            this.pnlPeriodToggle.TabIndex = 1;
            // 
            // btnMes
            // 
            this.btnMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(244)))));
            this.btnMes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMes.FlatAppearance.BorderSize = 0;
            this.btnMes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.btnMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnMes.Location = new System.Drawing.Point(250, 3);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(121, 30);
            this.btnMes.TabIndex = 2;
            this.btnMes.Text = "Mes";
            this.btnMes.UseVisualStyleBackColor = false;
            // 
            // btnSemana
            // 
            this.btnSemana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(244)))));
            this.btnSemana.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSemana.FlatAppearance.BorderSize = 0;
            this.btnSemana.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.btnSemana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSemana.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSemana.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnSemana.Location = new System.Drawing.Point(125, 3);
            this.btnSemana.Name = "btnSemana";
            this.btnSemana.Size = new System.Drawing.Size(121, 30);
            this.btnSemana.TabIndex = 1;
            this.btnSemana.Text = "Semana";
            this.btnSemana.UseVisualStyleBackColor = false;
            // 
            // btnDia
            // 
            this.btnDia.BackColor = System.Drawing.Color.White;
            this.btnDia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDia.FlatAppearance.BorderSize = 0;
            this.btnDia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.btnDia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnDia.Location = new System.Drawing.Point(0, 3);
            this.btnDia.Name = "btnDia";
            this.btnDia.Size = new System.Drawing.Size(121, 30);
            this.btnDia.TabIndex = 0;
            this.btnDia.Text = "Dia";
            this.btnDia.UseVisualStyleBackColor = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(126, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Dashboard";
            // 
            // pnlKPIVentas
            // 
            this.pnlKPIVentas.BackColor = System.Drawing.Color.White;
            this.pnlKPIVentas.Controls.Add(this.lblIcoVentas);
            this.pnlKPIVentas.Controls.Add(this.pnlAccentVentas);
            this.pnlKPIVentas.Controls.Add(this.lblKPIVentasCant);
            this.pnlKPIVentas.Controls.Add(this.lblKPIVentasValor);
            this.pnlKPIVentas.Controls.Add(this.lblKPIVentasTitulo);
            this.pnlKPIVentas.Location = new System.Drawing.Point(20, 65);
            this.pnlKPIVentas.Name = "pnlKPIVentas";
            this.pnlKPIVentas.Size = new System.Drawing.Size(340, 100);
            this.pnlKPIVentas.TabIndex = 1;
            // 
            // lblIcoVentas
            // 
            this.lblIcoVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(244)))), ((int)(((byte)(253)))));
            this.lblIcoVentas.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblIcoVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.lblIcoVentas.Location = new System.Drawing.Point(280, 26);
            this.lblIcoVentas.Name = "lblIcoVentas";
            this.lblIcoVentas.Size = new System.Drawing.Size(44, 44);
            this.lblIcoVentas.TabIndex = 10;
            this.lblIcoVentas.Text = "↑";
            this.lblIcoVentas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlAccentVentas
            // 
            this.pnlAccentVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlAccentVentas.Location = new System.Drawing.Point(0, 0);
            this.pnlAccentVentas.Name = "pnlAccentVentas";
            this.pnlAccentVentas.Size = new System.Drawing.Size(5, 100);
            this.pnlAccentVentas.TabIndex = 5;
            // 
            // lblKPIVentasCant
            // 
            this.lblKPIVentasCant.AutoSize = true;
            this.lblKPIVentasCant.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKPIVentasCant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblKPIVentasCant.Location = new System.Drawing.Point(20, 78);
            this.lblKPIVentasCant.Name = "lblKPIVentasCant";
            this.lblKPIVentasCant.Size = new System.Drawing.Size(80, 15);
            this.lblKPIVentasCant.TabIndex = 0;
            this.lblKPIVentasCant.Text = "0 operaciones";
            // 
            // lblKPIVentasValor
            // 
            this.lblKPIVentasValor.AutoSize = true;
            this.lblKPIVentasValor.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKPIVentasValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblKPIVentasValor.Location = new System.Drawing.Point(15, 38);
            this.lblKPIVentasValor.Name = "lblKPIVentasValor";
            this.lblKPIVentasValor.Size = new System.Drawing.Size(115, 41);
            this.lblKPIVentasValor.TabIndex = 1;
            this.lblKPIVentasValor.Text = "S/ 0.00";
            // 
            // lblKPIVentasTitulo
            // 
            this.lblKPIVentasTitulo.AutoSize = true;
            this.lblKPIVentasTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKPIVentasTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblKPIVentasTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblKPIVentasTitulo.Name = "lblKPIVentasTitulo";
            this.lblKPIVentasTitulo.Size = new System.Drawing.Size(99, 15);
            this.lblKPIVentasTitulo.TabIndex = 2;
            this.lblKPIVentasTitulo.Text = "VENTAS DEL DIA";
            // 
            // pnlKPIUtilidad
            // 
            this.pnlKPIUtilidad.BackColor = System.Drawing.Color.White;
            this.pnlKPIUtilidad.Controls.Add(this.lblIcoUtilidad);
            this.pnlKPIUtilidad.Controls.Add(this.pnlAccentUtilidad);
            this.pnlKPIUtilidad.Controls.Add(this.lblKPIUtilidadPorcentaje);
            this.pnlKPIUtilidad.Controls.Add(this.lblKPIUtilidadValor);
            this.pnlKPIUtilidad.Controls.Add(this.lblKPIUtilidadTitulo);
            this.pnlKPIUtilidad.Location = new System.Drawing.Point(375, 65);
            this.pnlKPIUtilidad.Name = "pnlKPIUtilidad";
            this.pnlKPIUtilidad.Size = new System.Drawing.Size(340, 100);
            this.pnlKPIUtilidad.TabIndex = 2;
            // 
            // lblIcoUtilidad
            // 
            this.lblIcoUtilidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(250)))), ((int)(((byte)(238)))));
            this.lblIcoUtilidad.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblIcoUtilidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(220)))), ((int)(((byte)(185)))));
            this.lblIcoUtilidad.Location = new System.Drawing.Point(280, 26);
            this.lblIcoUtilidad.Name = "lblIcoUtilidad";
            this.lblIcoUtilidad.Size = new System.Drawing.Size(44, 44);
            this.lblIcoUtilidad.TabIndex = 10;
            this.lblIcoUtilidad.Text = "%";
            this.lblIcoUtilidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlAccentUtilidad
            // 
            this.pnlAccentUtilidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.pnlAccentUtilidad.Location = new System.Drawing.Point(0, 0);
            this.pnlAccentUtilidad.Name = "pnlAccentUtilidad";
            this.pnlAccentUtilidad.Size = new System.Drawing.Size(5, 100);
            this.pnlAccentUtilidad.TabIndex = 5;
            // 
            // lblKPIUtilidadPorcentaje
            // 
            this.lblKPIUtilidadPorcentaje.AutoSize = true;
            this.lblKPIUtilidadPorcentaje.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKPIUtilidadPorcentaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblKPIUtilidadPorcentaje.Location = new System.Drawing.Point(20, 78);
            this.lblKPIUtilidadPorcentaje.Name = "lblKPIUtilidadPorcentaje";
            this.lblKPIUtilidadPorcentaje.Size = new System.Drawing.Size(70, 15);
            this.lblKPIUtilidadPorcentaje.TabIndex = 0;
            this.lblKPIUtilidadPorcentaje.Text = "Margen: 0%";
            // 
            // lblKPIUtilidadValor
            // 
            this.lblKPIUtilidadValor.AutoSize = true;
            this.lblKPIUtilidadValor.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKPIUtilidadValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblKPIUtilidadValor.Location = new System.Drawing.Point(15, 38);
            this.lblKPIUtilidadValor.Name = "lblKPIUtilidadValor";
            this.lblKPIUtilidadValor.Size = new System.Drawing.Size(115, 41);
            this.lblKPIUtilidadValor.TabIndex = 1;
            this.lblKPIUtilidadValor.Text = "S/ 0.00";
            // 
            // lblKPIUtilidadTitulo
            // 
            this.lblKPIUtilidadTitulo.AutoSize = true;
            this.lblKPIUtilidadTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKPIUtilidadTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblKPIUtilidadTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblKPIUtilidadTitulo.Name = "lblKPIUtilidadTitulo";
            this.lblKPIUtilidadTitulo.Size = new System.Drawing.Size(126, 15);
            this.lblKPIUtilidadTitulo.TabIndex = 2;
            this.lblKPIUtilidadTitulo.Text = "UTILIDAD ESTIMADA";
            // 
            // pnlKPIAlertas
            // 
            this.pnlKPIAlertas.BackColor = System.Drawing.Color.White;
            this.pnlKPIAlertas.Controls.Add(this.lblIcoAlertas);
            this.pnlKPIAlertas.Controls.Add(this.pnlAccentAlertas);
            this.pnlKPIAlertas.Controls.Add(this.lblKPIAlertasDetalle);
            this.pnlKPIAlertas.Controls.Add(this.lblKPIAlertasValor);
            this.pnlKPIAlertas.Controls.Add(this.lblKPIAlertasTitulo);
            this.pnlKPIAlertas.Location = new System.Drawing.Point(730, 65);
            this.pnlKPIAlertas.Name = "pnlKPIAlertas";
            this.pnlKPIAlertas.Size = new System.Drawing.Size(340, 100);
            this.pnlKPIAlertas.TabIndex = 3;
            // 
            // lblIcoAlertas
            // 
            this.lblIcoAlertas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.lblIcoAlertas.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblIcoAlertas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(180)))), ((int)(((byte)(120)))));
            this.lblIcoAlertas.Location = new System.Drawing.Point(280, 26);
            this.lblIcoAlertas.Name = "lblIcoAlertas";
            this.lblIcoAlertas.Size = new System.Drawing.Size(44, 44);
            this.lblIcoAlertas.TabIndex = 10;
            this.lblIcoAlertas.Text = "⚠";
            this.lblIcoAlertas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlAccentAlertas
            // 
            this.pnlAccentAlertas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.pnlAccentAlertas.Location = new System.Drawing.Point(0, 0);
            this.pnlAccentAlertas.Name = "pnlAccentAlertas";
            this.pnlAccentAlertas.Size = new System.Drawing.Size(5, 100);
            this.pnlAccentAlertas.TabIndex = 5;
            // 
            // lblKPIAlertasDetalle
            // 
            this.lblKPIAlertasDetalle.AutoSize = true;
            this.lblKPIAlertasDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKPIAlertasDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblKPIAlertasDetalle.Location = new System.Drawing.Point(20, 78);
            this.lblKPIAlertasDetalle.Name = "lblKPIAlertasDetalle";
            this.lblKPIAlertasDetalle.Size = new System.Drawing.Size(163, 15);
            this.lblKPIAlertasDetalle.TabIndex = 0;
            this.lblKPIAlertasDetalle.Text = "productos bajo stock minimo";
            // 
            // lblKPIAlertasValor
            // 
            this.lblKPIAlertasValor.AutoSize = true;
            this.lblKPIAlertasValor.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKPIAlertasValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblKPIAlertasValor.Location = new System.Drawing.Point(15, 38);
            this.lblKPIAlertasValor.Name = "lblKPIAlertasValor";
            this.lblKPIAlertasValor.Size = new System.Drawing.Size(35, 41);
            this.lblKPIAlertasValor.TabIndex = 1;
            this.lblKPIAlertasValor.Text = "0";
            // 
            // lblKPIAlertasTitulo
            // 
            this.lblKPIAlertasTitulo.AutoSize = true;
            this.lblKPIAlertasTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKPIAlertasTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblKPIAlertasTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblKPIAlertasTitulo.Name = "lblKPIAlertasTitulo";
            this.lblKPIAlertasTitulo.Size = new System.Drawing.Size(115, 15);
            this.lblKPIAlertasTitulo.TabIndex = 2;
            this.lblKPIAlertasTitulo.Text = "ALERTAS DE STOCK";
            // 
            // pnlGrafico
            // 
            this.pnlGrafico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrafico.BackColor = System.Drawing.Color.White;
            this.pnlGrafico.Controls.Add(this.lblIcoGrafico);
            this.pnlGrafico.Controls.Add(this.chartVentas);
            this.pnlGrafico.Controls.Add(this.lblGraficoTitulo);
            this.pnlGrafico.Location = new System.Drawing.Point(20, 189);
            this.pnlGrafico.Name = "pnlGrafico";
            this.pnlGrafico.Size = new System.Drawing.Size(824, 318);
            this.pnlGrafico.TabIndex = 4;
            // 
            // lblIcoGrafico
            // 
            this.lblIcoGrafico.AutoSize = true;
            this.lblIcoGrafico.BackColor = System.Drawing.Color.Transparent;
            this.lblIcoGrafico.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIcoGrafico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.lblIcoGrafico.Location = new System.Drawing.Point(20, 13);
            this.lblIcoGrafico.Name = "lblIcoGrafico";
            this.lblIcoGrafico.Size = new System.Drawing.Size(18, 15);
            this.lblIcoGrafico.TabIndex = 10;
            this.lblIcoGrafico.Text = "▶";
            // 
            // chartVentas
            // 
            this.chartVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartVentas.BorderlineWidth = 0;
            chartArea1.Name = "ChartArea1";
            this.chartVentas.ChartAreas.Add(chartArea1);
            this.chartVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chartVentas.Location = new System.Drawing.Point(10, 38);
            this.chartVentas.Name = "chartVentas";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chartVentas.Series.Add(series1);
            this.chartVentas.Size = new System.Drawing.Size(799, 270);
            this.chartVentas.TabIndex = 0;
            // 
            // lblGraficoTitulo
            // 
            this.lblGraficoTitulo.AutoSize = true;
            this.lblGraficoTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGraficoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblGraficoTitulo.Location = new System.Drawing.Point(38, 12);
            this.lblGraficoTitulo.Name = "lblGraficoTitulo";
            this.lblGraficoTitulo.Size = new System.Drawing.Size(117, 19);
            this.lblGraficoTitulo.TabIndex = 1;
            this.lblGraficoTitulo.Text = "VENTAS DE HOY";
            // 
            // pnlTopProductos
            // 
            this.pnlTopProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTopProductos.BackColor = System.Drawing.Color.White;
            this.pnlTopProductos.Controls.Add(this.lblIcoTop);
            this.pnlTopProductos.Controls.Add(this.pnlTopLista);
            this.pnlTopProductos.Controls.Add(this.lblTopTitulo);
            this.pnlTopProductos.Location = new System.Drawing.Point(868, 189);
            this.pnlTopProductos.Name = "pnlTopProductos";
            this.pnlTopProductos.Size = new System.Drawing.Size(556, 318);
            this.pnlTopProductos.TabIndex = 5;
            // 
            // lblIcoTop
            // 
            this.lblIcoTop.AutoSize = true;
            this.lblIcoTop.BackColor = System.Drawing.Color.Transparent;
            this.lblIcoTop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIcoTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.lblIcoTop.Location = new System.Drawing.Point(20, 13);
            this.lblIcoTop.Name = "lblIcoTop";
            this.lblIcoTop.Size = new System.Drawing.Size(18, 15);
            this.lblIcoTop.TabIndex = 10;
            this.lblIcoTop.Text = "★";
            // 
            // pnlTopLista
            // 
            this.pnlTopLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTopLista.AutoScroll = true;
            this.pnlTopLista.Location = new System.Drawing.Point(38, 40);
            this.pnlTopLista.Name = "pnlTopLista";
            this.pnlTopLista.Size = new System.Drawing.Size(478, 259);
            this.pnlTopLista.TabIndex = 0;
            // 
            // lblTopTitulo
            // 
            this.lblTopTitulo.AutoSize = true;
            this.lblTopTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTopTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblTopTitulo.Location = new System.Drawing.Point(38, 12);
            this.lblTopTitulo.Name = "lblTopTitulo";
            this.lblTopTitulo.Size = new System.Drawing.Size(180, 19);
            this.lblTopTitulo.TabIndex = 1;
            this.lblTopTitulo.Text = "TOP PRODUCTOS DEL DIA";
            // 
            // pnlOperaciones
            // 
            this.pnlOperaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOperaciones.BackColor = System.Drawing.Color.White;
            this.pnlOperaciones.Controls.Add(this.lblIcoOps);
            this.pnlOperaciones.Controls.Add(this.dgvOperaciones);
            this.pnlOperaciones.Controls.Add(this.lblOperacionesTitulo);
            this.pnlOperaciones.Location = new System.Drawing.Point(20, 533);
            this.pnlOperaciones.Name = "pnlOperaciones";
            this.pnlOperaciones.Size = new System.Drawing.Size(1404, 242);
            this.pnlOperaciones.TabIndex = 6;
            // 
            // lblIcoOps
            // 
            this.lblIcoOps.AutoSize = true;
            this.lblIcoOps.BackColor = System.Drawing.Color.Transparent;
            this.lblIcoOps.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblIcoOps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.lblIcoOps.Location = new System.Drawing.Point(20, 11);
            this.lblIcoOps.Name = "lblIcoOps";
            this.lblIcoOps.Size = new System.Drawing.Size(21, 21);
            this.lblIcoOps.TabIndex = 10;
            this.lblIcoOps.Text = "≡";
            // 
            // dgvOperaciones
            // 
            this.dgvOperaciones.AllowUserToAddRows = false;
            this.dgvOperaciones.AllowUserToDeleteRows = false;
            this.dgvOperaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOperaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvOperaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOperaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOperaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOperaciones.ColumnHeadersHeight = 35;
            this.dgvOperaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumero,
            this.colCliente,
            this.colMetodoPago,
            this.colMonto,
            this.colFechaHora});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOperaciones.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvOperaciones.EnableHeadersVisualStyles = false;
            this.dgvOperaciones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dgvOperaciones.Location = new System.Drawing.Point(15, 40);
            this.dgvOperaciones.Name = "dgvOperaciones";
            this.dgvOperaciones.ReadOnly = true;
            this.dgvOperaciones.RowHeadersVisible = false;
            this.dgvOperaciones.RowTemplate.Height = 32;
            this.dgvOperaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOperaciones.Size = new System.Drawing.Size(1362, 199);
            this.dgvOperaciones.TabIndex = 0;
            // 
            // colNumero
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Be Vietnam Pro Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNumero.DefaultCellStyle = dataGridViewCellStyle2;
            this.colNumero.HeaderText = "#";
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            this.colNumero.Width = 150;
            // 
            // colCliente
            // 
            this.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Be Vietnam Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCliente.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            // 
            // colMetodoPago
            // 
            this.colMetodoPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Be Vietnam Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMetodoPago.DefaultCellStyle = dataGridViewCellStyle4;
            this.colMetodoPago.HeaderText = "Metodo de Pago";
            this.colMetodoPago.Name = "colMetodoPago";
            this.colMetodoPago.ReadOnly = true;
            // 
            // colMonto
            // 
            this.colMonto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Be Vietnam Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.colMonto.DefaultCellStyle = dataGridViewCellStyle5;
            this.colMonto.HeaderText = "Monto";
            this.colMonto.Name = "colMonto";
            this.colMonto.ReadOnly = true;
            // 
            // colFechaHora
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Be Vietnam Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colFechaHora.DefaultCellStyle = dataGridViewCellStyle6;
            this.colFechaHora.HeaderText = "Fecha y Hora";
            this.colFechaHora.Name = "colFechaHora";
            this.colFechaHora.ReadOnly = true;
            this.colFechaHora.Width = 250;
            // 
            // lblOperacionesTitulo
            // 
            this.lblOperacionesTitulo.AutoSize = true;
            this.lblOperacionesTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOperacionesTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblOperacionesTitulo.Location = new System.Drawing.Point(38, 12);
            this.lblOperacionesTitulo.Name = "lblOperacionesTitulo";
            this.lblOperacionesTitulo.Size = new System.Drawing.Size(161, 19);
            this.lblOperacionesTitulo.TabIndex = 1;
            this.lblOperacionesTitulo.Text = "OPERACIONES DEL DIA";
            // 
            // pnlKPICxP
            // 
            this.pnlKPICxP.BackColor = System.Drawing.Color.White;
            this.pnlKPICxP.Controls.Add(this.lblIcoCxP);
            this.pnlKPICxP.Controls.Add(this.pnlAccentCxP);
            this.pnlKPICxP.Controls.Add(this.lblKPICxPCant);
            this.pnlKPICxP.Controls.Add(this.lblKPICxPValor);
            this.pnlKPICxP.Controls.Add(this.lblKPICxPTitulo);
            this.pnlKPICxP.Location = new System.Drawing.Point(1085, 65);
            this.pnlKPICxP.Name = "pnlKPICxP";
            this.pnlKPICxP.Size = new System.Drawing.Size(340, 100);
            this.pnlKPICxP.TabIndex = 7;
            // 
            // lblIcoCxP
            // 
            this.lblIcoCxP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.lblIcoCxP.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblIcoCxP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(155)))), ((int)(((byte)(220)))));
            this.lblIcoCxP.Location = new System.Drawing.Point(280, 26);
            this.lblIcoCxP.Name = "lblIcoCxP";
            this.lblIcoCxP.Size = new System.Drawing.Size(44, 44);
            this.lblIcoCxP.TabIndex = 10;
            this.lblIcoCxP.Text = "$";
            this.lblIcoCxP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlAccentCxP
            // 
            this.pnlAccentCxP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.pnlAccentCxP.Location = new System.Drawing.Point(0, 0);
            this.pnlAccentCxP.Name = "pnlAccentCxP";
            this.pnlAccentCxP.Size = new System.Drawing.Size(5, 100);
            this.pnlAccentCxP.TabIndex = 5;
            // 
            // lblKPICxPCant
            // 
            this.lblKPICxPCant.AutoSize = true;
            this.lblKPICxPCant.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKPICxPCant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblKPICxPCant.Location = new System.Drawing.Point(20, 78);
            this.lblKPICxPCant.Name = "lblKPICxPCant";
            this.lblKPICxPCant.Size = new System.Drawing.Size(83, 15);
            this.lblKPICxPCant.TabIndex = 0;
            this.lblKPICxPCant.Text = "0 documentos";
            // 
            // lblKPICxPValor
            // 
            this.lblKPICxPValor.AutoSize = true;
            this.lblKPICxPValor.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKPICxPValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.lblKPICxPValor.Location = new System.Drawing.Point(15, 38);
            this.lblKPICxPValor.Name = "lblKPICxPValor";
            this.lblKPICxPValor.Size = new System.Drawing.Size(115, 41);
            this.lblKPICxPValor.TabIndex = 1;
            this.lblKPICxPValor.Text = "S/ 0.00";
            // 
            // lblKPICxPTitulo
            // 
            this.lblKPICxPTitulo.AutoSize = true;
            this.lblKPICxPTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKPICxPTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblKPICxPTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblKPICxPTitulo.Name = "lblKPICxPTitulo";
            this.lblKPICxPTitulo.Size = new System.Drawing.Size(94, 15);
            this.lblKPICxPTitulo.TabIndex = 2;
            this.lblKPICxPTitulo.Text = "CxP PENDIENTE";
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1444, 800);
            this.Controls.Add(this.pnlOperaciones);
            this.Controls.Add(this.pnlTopProductos);
            this.Controls.Add(this.pnlGrafico);
            this.Controls.Add(this.pnlKPICxP);
            this.Controls.Add(this.pnlKPIAlertas);
            this.Controls.Add(this.pnlKPIUtilidad);
            this.Controls.Add(this.pnlKPIVentas);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormDashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.FormDashboard_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlPeriodToggle.ResumeLayout(false);
            this.pnlKPIVentas.ResumeLayout(false);
            this.pnlKPIVentas.PerformLayout();
            this.pnlKPIUtilidad.ResumeLayout(false);
            this.pnlKPIUtilidad.PerformLayout();
            this.pnlKPIAlertas.ResumeLayout(false);
            this.pnlKPIAlertas.PerformLayout();
            this.pnlGrafico.ResumeLayout(false);
            this.pnlGrafico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).EndInit();
            this.pnlTopProductos.ResumeLayout(false);
            this.pnlTopProductos.PerformLayout();
            this.pnlOperaciones.ResumeLayout(false);
            this.pnlOperaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperaciones)).EndInit();
            this.pnlKPICxP.ResumeLayout(false);
            this.pnlKPICxP.PerformLayout();
            this.ResumeLayout(false);

        }

        // Header
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;

        // KPI Iconos temporales
        private System.Windows.Forms.Label lblIcoVentas;
        private System.Windows.Forms.Label lblIcoUtilidad;
        private System.Windows.Forms.Label lblIcoAlertas;
        private System.Windows.Forms.Label lblIcoCxP;
        private System.Windows.Forms.Label lblIcoGrafico;
        private System.Windows.Forms.Label lblIcoTop;
        private System.Windows.Forms.Label lblIcoOps;

        // KPI Accents
        private System.Windows.Forms.Panel pnlAccentVentas;
        private System.Windows.Forms.Panel pnlAccentUtilidad;
        private System.Windows.Forms.Panel pnlAccentAlertas;
        private System.Windows.Forms.Panel pnlAccentCxP;

        // KPI CxP
        private System.Windows.Forms.Panel pnlKPICxP;
        private System.Windows.Forms.Label lblKPICxPTitulo;
        private System.Windows.Forms.Label lblKPICxPValor;
        private System.Windows.Forms.Label lblKPICxPCant;
        private System.Windows.Forms.Panel pnlPeriodToggle;
        private System.Windows.Forms.Button btnDia;
        private System.Windows.Forms.Button btnSemana;
        private System.Windows.Forms.Button btnMes;

        // KPIs
        private System.Windows.Forms.Panel pnlKPIVentas;
        private System.Windows.Forms.Label lblKPIVentasTitulo;
        private System.Windows.Forms.Label lblKPIVentasValor;
        private System.Windows.Forms.Label lblKPIVentasCant;

        private System.Windows.Forms.Panel pnlKPIUtilidad;
        private System.Windows.Forms.Label lblKPIUtilidadTitulo;
        private System.Windows.Forms.Label lblKPIUtilidadValor;
        private System.Windows.Forms.Label lblKPIUtilidadPorcentaje;

        private System.Windows.Forms.Panel pnlKPIAlertas;
        private System.Windows.Forms.Label lblKPIAlertasTitulo;
        private System.Windows.Forms.Label lblKPIAlertasValor;
        private System.Windows.Forms.Label lblKPIAlertasDetalle;

        // Grafico
        private System.Windows.Forms.Panel pnlGrafico;
        private System.Windows.Forms.Label lblGraficoTitulo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentas;

        // Top productos
        private System.Windows.Forms.Panel pnlTopProductos;
        private System.Windows.Forms.Label lblTopTitulo;
        private System.Windows.Forms.Panel pnlTopLista;

        // Operaciones recientes
        private System.Windows.Forms.Panel pnlOperaciones;
        private System.Windows.Forms.Label lblOperacionesTitulo;
        private System.Windows.Forms.DataGridView dgvOperaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMetodoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaHora;
    }
}
