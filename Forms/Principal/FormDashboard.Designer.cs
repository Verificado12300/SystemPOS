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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlPeriodToggle = new System.Windows.Forms.Panel();
            this.btnMes = new System.Windows.Forms.Button();
            this.btnSemana = new System.Windows.Forms.Button();
            this.btnDia = new System.Windows.Forms.Button();
            this.pnlKPIVentas = new System.Windows.Forms.Panel();
            this.lblKPIVentasCant = new System.Windows.Forms.Label();
            this.lblKPIVentasValor = new System.Windows.Forms.Label();
            this.lblKPIVentasTitulo = new System.Windows.Forms.Label();
            this.pnlKPIUtilidad = new System.Windows.Forms.Panel();
            this.lblKPIUtilidadPorcentaje = new System.Windows.Forms.Label();
            this.lblKPIUtilidadValor = new System.Windows.Forms.Label();
            this.lblKPIUtilidadTitulo = new System.Windows.Forms.Label();
            this.pnlKPIAlertas = new System.Windows.Forms.Panel();
            this.lblKPIAlertasDetalle = new System.Windows.Forms.Label();
            this.lblKPIAlertasValor = new System.Windows.Forms.Label();
            this.lblKPIAlertasTitulo = new System.Windows.Forms.Label();
            this.pnlGrafico = new System.Windows.Forms.Panel();
            this.chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblGraficoTitulo = new System.Windows.Forms.Label();
            this.pnlTopProductos = new System.Windows.Forms.Panel();
            this.pnlTopLista = new System.Windows.Forms.Panel();
            this.lblTopTitulo = new System.Windows.Forms.Label();
            this.pnlOperaciones = new System.Windows.Forms.Panel();
            this.dgvOperaciones = new System.Windows.Forms.DataGridView();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblOperacionesTitulo = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 10, 20, 5);
            this.pnlHeader.Size = new System.Drawing.Size(1721, 55);
            this.pnlHeader.TabIndex = 0;
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
            // pnlPeriodToggle
            // 
            this.pnlPeriodToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPeriodToggle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(244)))));
            this.pnlPeriodToggle.Controls.Add(this.btnMes);
            this.pnlPeriodToggle.Controls.Add(this.btnSemana);
            this.pnlPeriodToggle.Controls.Add(this.btnDia);
            this.pnlPeriodToggle.Location = new System.Drawing.Point(1329, 131);
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
            // pnlKPIVentas
            // 
            this.pnlKPIVentas.BackColor = System.Drawing.Color.White;
            this.pnlKPIVentas.Controls.Add(this.lblKPIVentasCant);
            this.pnlKPIVentas.Controls.Add(this.lblKPIVentasValor);
            this.pnlKPIVentas.Controls.Add(this.lblKPIVentasTitulo);
            this.pnlKPIVentas.Location = new System.Drawing.Point(20, 65);
            this.pnlKPIVentas.Name = "pnlKPIVentas";
            this.pnlKPIVentas.Size = new System.Drawing.Size(353, 100);
            this.pnlKPIVentas.TabIndex = 1;
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
            this.pnlKPIUtilidad.Controls.Add(this.lblKPIUtilidadPorcentaje);
            this.pnlKPIUtilidad.Controls.Add(this.lblKPIUtilidadValor);
            this.pnlKPIUtilidad.Controls.Add(this.lblKPIUtilidadTitulo);
            this.pnlKPIUtilidad.Location = new System.Drawing.Point(439, 65);
            this.pnlKPIUtilidad.Name = "pnlKPIUtilidad";
            this.pnlKPIUtilidad.Size = new System.Drawing.Size(368, 100);
            this.pnlKPIUtilidad.TabIndex = 2;
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
            this.pnlKPIAlertas.Controls.Add(this.lblKPIAlertasDetalle);
            this.pnlKPIAlertas.Controls.Add(this.lblKPIAlertasValor);
            this.pnlKPIAlertas.Controls.Add(this.lblKPIAlertasTitulo);
            this.pnlKPIAlertas.Location = new System.Drawing.Point(873, 65);
            this.pnlKPIAlertas.Name = "pnlKPIAlertas";
            this.pnlKPIAlertas.Size = new System.Drawing.Size(368, 100);
            this.pnlKPIAlertas.TabIndex = 3;
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
            this.pnlGrafico.Controls.Add(this.chartVentas);
            this.pnlGrafico.Controls.Add(this.lblGraficoTitulo);
            this.pnlGrafico.Location = new System.Drawing.Point(20, 189);
            this.pnlGrafico.Name = "pnlGrafico";
            this.pnlGrafico.Size = new System.Drawing.Size(1088, 318);
            this.pnlGrafico.TabIndex = 4;
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
            this.chartVentas.Size = new System.Drawing.Size(1063, 270);
            this.chartVentas.TabIndex = 0;
            // 
            // lblGraficoTitulo
            // 
            this.lblGraficoTitulo.AutoSize = true;
            this.lblGraficoTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGraficoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblGraficoTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblGraficoTitulo.Name = "lblGraficoTitulo";
            this.lblGraficoTitulo.Size = new System.Drawing.Size(117, 19);
            this.lblGraficoTitulo.TabIndex = 1;
            this.lblGraficoTitulo.Text = "VENTAS DE HOY";
            // 
            // pnlTopProductos
            // 
            this.pnlTopProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTopProductos.BackColor = System.Drawing.Color.White;
            this.pnlTopProductos.Controls.Add(this.pnlTopLista);
            this.pnlTopProductos.Controls.Add(this.lblTopTitulo);
            this.pnlTopProductos.Location = new System.Drawing.Point(1145, 189);
            this.pnlTopProductos.Name = "pnlTopProductos";
            this.pnlTopProductos.Size = new System.Drawing.Size(556, 318);
            this.pnlTopProductos.TabIndex = 5;
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
            this.lblTopTitulo.Location = new System.Drawing.Point(20, 12);
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
            this.pnlOperaciones.Controls.Add(this.dgvOperaciones);
            this.pnlOperaciones.Controls.Add(this.lblOperacionesTitulo);
            this.pnlOperaciones.Location = new System.Drawing.Point(20, 533);
            this.pnlOperaciones.Name = "pnlOperaciones";
            this.pnlOperaciones.Size = new System.Drawing.Size(1681, 242);
            this.pnlOperaciones.TabIndex = 6;
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
            this.dgvOperaciones.Size = new System.Drawing.Size(1639, 199);
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
            this.lblOperacionesTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblOperacionesTitulo.Name = "lblOperacionesTitulo";
            this.lblOperacionesTitulo.Size = new System.Drawing.Size(161, 19);
            this.lblOperacionesTitulo.TabIndex = 1;
            this.lblOperacionesTitulo.Text = "OPERACIONES DEL DIA";
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1721, 800);
            this.Controls.Add(this.pnlPeriodToggle);
            this.Controls.Add(this.pnlOperaciones);
            this.Controls.Add(this.pnlTopProductos);
            this.Controls.Add(this.pnlGrafico);
            this.Controls.Add(this.pnlKPIAlertas);
            this.Controls.Add(this.pnlKPIUtilidad);
            this.Controls.Add(this.pnlKPIVentas);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
            this.ResumeLayout(false);

        }

        // Header
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
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
