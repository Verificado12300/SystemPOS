namespace SistemaPOS.Forms.Finanzas
{
    partial class FormContabilidad
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAsientos = new System.Windows.Forms.TabPage();
            this.lblTotalAsientos = new System.Windows.Forms.Label();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.dgvAsientos = new System.Windows.Forms.DataGridView();
            this.btnBuscarAsientos = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cboTipoOperacion = new System.Windows.Forms.ComboBox();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.cboCuenta = new System.Windows.Forms.ComboBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblMontoMin = new System.Windows.Forms.Label();
            this.txtMontoMin = new System.Windows.Forms.TextBox();
            this.lblMontoMax = new System.Windows.Forms.Label();
            this.txtMontoMax = new System.Windows.Forms.TextBox();
            this.tabCuentas = new System.Windows.Forms.TabPage();
            this.dgvCuentas = new System.Windows.Forms.DataGridView();
            this.btnBuscarCuentas = new System.Windows.Forms.Button();
            this.dtpHastaC = new System.Windows.Forms.DateTimePicker();
            this.lblHastaC = new System.Windows.Forms.Label();
            this.dtpDesdeC = new System.Windows.Forms.DateTimePicker();
            this.lblDesdeC = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabAsientos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientos)).BeginInit();
            this.tabCuentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabAsientos);
            this.tabControl.Controls.Add(this.tabCuentas);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1466, 837);
            this.tabControl.TabIndex = 0;
            // 
            // tabAsientos
            // 
            this.tabAsientos.Controls.Add(this.lblTotalAsientos);
            this.tabAsientos.Controls.Add(this.dgvDetalles);
            this.tabAsientos.Controls.Add(this.lblDetalles);
            this.tabAsientos.Controls.Add(this.dgvAsientos);
            this.tabAsientos.Controls.Add(this.btnBuscarAsientos);
            this.tabAsientos.Controls.Add(this.dtpHasta);
            this.tabAsientos.Controls.Add(this.lblHasta);
            this.tabAsientos.Controls.Add(this.dtpDesde);
            this.tabAsientos.Controls.Add(this.lblDesde);
            this.tabAsientos.Controls.Add(this.lblTipo);
            this.tabAsientos.Controls.Add(this.cboTipoOperacion);
            this.tabAsientos.Controls.Add(this.lblCuenta);
            this.tabAsientos.Controls.Add(this.cboCuenta);
            this.tabAsientos.Controls.Add(this.lblBuscar);
            this.tabAsientos.Controls.Add(this.txtBuscar);
            this.tabAsientos.Controls.Add(this.lblMontoMin);
            this.tabAsientos.Controls.Add(this.txtMontoMin);
            this.tabAsientos.Controls.Add(this.lblMontoMax);
            this.tabAsientos.Controls.Add(this.txtMontoMax);
            this.tabAsientos.Location = new System.Drawing.Point(4, 22);
            this.tabAsientos.Name = "tabAsientos";
            this.tabAsientos.Padding = new System.Windows.Forms.Padding(3);
            this.tabAsientos.Size = new System.Drawing.Size(1458, 811);
            this.tabAsientos.TabIndex = 0;
            this.tabAsientos.Text = "Asientos";
            this.tabAsientos.UseVisualStyleBackColor = true;
            // 
            // lblTotalAsientos
            // 
            this.lblTotalAsientos.AutoSize = true;
            this.lblTotalAsientos.Location = new System.Drawing.Point(410, 14);
            this.lblTotalAsientos.Name = "lblTotalAsientos";
            this.lblTotalAsientos.Size = new System.Drawing.Size(85, 13);
            this.lblTotalAsientos.TabIndex = 8;
            this.lblTotalAsientos.Text = "Total: 0 asientos";
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalles.Location = new System.Drawing.Point(895, 70);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(555, 733);
            this.dgvDetalles.TabIndex = 7;
            // 
            // lblDetalles
            // 
            this.lblDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetalles.AutoSize = true;
            this.lblDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDetalles.Location = new System.Drawing.Point(1133, 54);
            this.lblDetalles.Name = "lblDetalles";
            this.lblDetalles.Size = new System.Drawing.Size(117, 13);
            this.lblDetalles.TabIndex = 6;
            this.lblDetalles.Text = "Detalle del asiento:";
            // 
            // dgvAsientos
            // 
            this.dgvAsientos.AllowUserToAddRows = false;
            this.dgvAsientos.AllowUserToDeleteRows = false;
            this.dgvAsientos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAsientos.Location = new System.Drawing.Point(10, 70);
            this.dgvAsientos.MultiSelect = false;
            this.dgvAsientos.Name = "dgvAsientos";
            this.dgvAsientos.ReadOnly = true;
            this.dgvAsientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsientos.Size = new System.Drawing.Size(879, 733);
            this.dgvAsientos.TabIndex = 5;
            this.dgvAsientos.SelectionChanged += new System.EventHandler(this.DgvAsientos_SelectionChanged);
            // 
            // btnBuscarAsientos
            // 
            this.btnBuscarAsientos.Location = new System.Drawing.Point(315, 8);
            this.btnBuscarAsientos.Name = "btnBuscarAsientos";
            this.btnBuscarAsientos.Size = new System.Drawing.Size(80, 24);
            this.btnBuscarAsientos.TabIndex = 4;
            this.btnBuscarAsientos.Text = "Buscar";
            this.btnBuscarAsientos.UseVisualStyleBackColor = true;
            this.btnBuscarAsientos.Click += new System.EventHandler(this.BtnBuscarAsientos_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(205, 10);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpHasta.TabIndex = 3;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(165, 14);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(55, 10);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpDesde.TabIndex = 1;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(10, 14);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(10, 42);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 20;
            this.lblTipo.Text = "Tipo:";
            // 
            // cboTipoOperacion
            // 
            this.cboTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOperacion.Location = new System.Drawing.Point(45, 38);
            this.cboTipoOperacion.Name = "cboTipoOperacion";
            this.cboTipoOperacion.Size = new System.Drawing.Size(120, 21);
            this.cboTipoOperacion.TabIndex = 21;
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(175, 42);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(44, 13);
            this.lblCuenta.TabIndex = 22;
            this.lblCuenta.Text = "Cuenta:";
            // 
            // cboCuenta
            // 
            this.cboCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCuenta.Location = new System.Drawing.Point(225, 38);
            this.cboCuenta.Name = "cboCuenta";
            this.cboCuenta.Size = new System.Drawing.Size(200, 21);
            this.cboCuenta.TabIndex = 23;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(435, 42);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(43, 13);
            this.lblBuscar.TabIndex = 24;
            this.lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(480, 38);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(180, 20);
            this.txtBuscar.TabIndex = 25;
            // 
            // lblMontoMin
            // 
            this.lblMontoMin.AutoSize = true;
            this.lblMontoMin.Location = new System.Drawing.Point(670, 42);
            this.lblMontoMin.Name = "lblMontoMin";
            this.lblMontoMin.Size = new System.Drawing.Size(49, 13);
            this.lblMontoMin.TabIndex = 26;
            this.lblMontoMin.Text = "Monto>=";
            // 
            // txtMontoMin
            // 
            this.txtMontoMin.Location = new System.Drawing.Point(725, 38);
            this.txtMontoMin.Name = "txtMontoMin";
            this.txtMontoMin.Size = new System.Drawing.Size(80, 20);
            this.txtMontoMin.TabIndex = 27;
            // 
            // lblMontoMax
            // 
            this.lblMontoMax.AutoSize = true;
            this.lblMontoMax.Location = new System.Drawing.Point(815, 42);
            this.lblMontoMax.Name = "lblMontoMax";
            this.lblMontoMax.Size = new System.Drawing.Size(49, 13);
            this.lblMontoMax.TabIndex = 28;
            this.lblMontoMax.Text = "Monto<=";
            // 
            // txtMontoMax
            // 
            this.txtMontoMax.Location = new System.Drawing.Point(868, 38);
            this.txtMontoMax.Name = "txtMontoMax";
            this.txtMontoMax.Size = new System.Drawing.Size(80, 20);
            this.txtMontoMax.TabIndex = 29;
            // 
            // tabCuentas
            // 
            this.tabCuentas.Controls.Add(this.dgvCuentas);
            this.tabCuentas.Controls.Add(this.btnBuscarCuentas);
            this.tabCuentas.Controls.Add(this.dtpHastaC);
            this.tabCuentas.Controls.Add(this.lblHastaC);
            this.tabCuentas.Controls.Add(this.dtpDesdeC);
            this.tabCuentas.Controls.Add(this.lblDesdeC);
            this.tabCuentas.Location = new System.Drawing.Point(4, 22);
            this.tabCuentas.Name = "tabCuentas";
            this.tabCuentas.Padding = new System.Windows.Forms.Padding(3);
            this.tabCuentas.Size = new System.Drawing.Size(1458, 811);
            this.tabCuentas.TabIndex = 1;
            this.tabCuentas.Text = "Cuentas";
            this.tabCuentas.UseVisualStyleBackColor = true;
            // 
            // dgvCuentas
            // 
            this.dgvCuentas.AllowUserToAddRows = false;
            this.dgvCuentas.AllowUserToDeleteRows = false;
            this.dgvCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCuentas.Location = new System.Drawing.Point(10, 40);
            this.dgvCuentas.Name = "dgvCuentas";
            this.dgvCuentas.ReadOnly = true;
            this.dgvCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuentas.Size = new System.Drawing.Size(870, 620);
            this.dgvCuentas.TabIndex = 5;
            // 
            // btnBuscarCuentas
            // 
            this.btnBuscarCuentas.Location = new System.Drawing.Point(315, 8);
            this.btnBuscarCuentas.Name = "btnBuscarCuentas";
            this.btnBuscarCuentas.Size = new System.Drawing.Size(80, 24);
            this.btnBuscarCuentas.TabIndex = 4;
            this.btnBuscarCuentas.Text = "Buscar";
            this.btnBuscarCuentas.UseVisualStyleBackColor = true;
            this.btnBuscarCuentas.Click += new System.EventHandler(this.BtnBuscarCuentas_Click);
            // 
            // dtpHastaC
            // 
            this.dtpHastaC.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHastaC.Location = new System.Drawing.Point(205, 10);
            this.dtpHastaC.Name = "dtpHastaC";
            this.dtpHastaC.Size = new System.Drawing.Size(100, 20);
            this.dtpHastaC.TabIndex = 3;
            // 
            // lblHastaC
            // 
            this.lblHastaC.AutoSize = true;
            this.lblHastaC.Location = new System.Drawing.Point(165, 14);
            this.lblHastaC.Name = "lblHastaC";
            this.lblHastaC.Size = new System.Drawing.Size(38, 13);
            this.lblHastaC.TabIndex = 2;
            this.lblHastaC.Text = "Hasta:";
            // 
            // dtpDesdeC
            // 
            this.dtpDesdeC.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesdeC.Location = new System.Drawing.Point(55, 10);
            this.dtpDesdeC.Name = "dtpDesdeC";
            this.dtpDesdeC.Size = new System.Drawing.Size(100, 20);
            this.dtpDesdeC.TabIndex = 1;
            // 
            // lblDesdeC
            // 
            this.lblDesdeC.AutoSize = true;
            this.lblDesdeC.Location = new System.Drawing.Point(10, 14);
            this.lblDesdeC.Name = "lblDesdeC";
            this.lblDesdeC.Size = new System.Drawing.Size(41, 13);
            this.lblDesdeC.TabIndex = 0;
            this.lblDesdeC.Text = "Desde:";
            // 
            // FormContabilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1466, 837);
            this.Controls.Add(this.tabControl);
            this.Name = "FormContabilidad";
            this.Text = "Contabilidad - Libro Diario";
            this.tabControl.ResumeLayout(false);
            this.tabAsientos.ResumeLayout(false);
            this.tabAsientos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientos)).EndInit();
            this.tabCuentas.ResumeLayout(false);
            this.tabCuentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAsientos;
        private System.Windows.Forms.TabPage tabCuentas;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnBuscarAsientos;
        private System.Windows.Forms.DataGridView dgvAsientos;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.Label lblTotalAsientos;
        private System.Windows.Forms.Label lblDesdeC;
        private System.Windows.Forms.DateTimePicker dtpDesdeC;
        private System.Windows.Forms.Label lblHastaC;
        private System.Windows.Forms.DateTimePicker dtpHastaC;
        private System.Windows.Forms.Button btnBuscarCuentas;
        private System.Windows.Forms.DataGridView dgvCuentas;
        // filtros avanzados
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cboTipoOperacion;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.ComboBox cboCuenta;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblMontoMin;
        private System.Windows.Forms.TextBox txtMontoMin;
        private System.Windows.Forms.Label lblMontoMax;
        private System.Windows.Forms.TextBox txtMontoMax;
    }
}
