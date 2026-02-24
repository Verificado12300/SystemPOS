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
            this.components = new System.ComponentModel.Container();
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
            this.tabControl.Size = new System.Drawing.Size(900, 700);
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
            this.tabAsientos.Location = new System.Drawing.Point(4, 22);
            this.tabAsientos.Name = "tabAsientos";
            this.tabAsientos.Padding = new System.Windows.Forms.Padding(3);
            this.tabAsientos.Size = new System.Drawing.Size(892, 674);
            this.tabAsientos.TabIndex = 0;
            this.tabAsientos.Text = "Asientos";
            this.tabAsientos.UseVisualStyleBackColor = true;
            //
            // lblDesde
            //
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(10, 14);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(38, 13);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde:";
            //
            // dtpDesde
            //
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(55, 10);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpDesde.TabIndex = 1;
            //
            // lblHasta
            //
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(165, 14);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(35, 13);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta:";
            //
            // dtpHasta
            //
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(205, 10);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpHasta.TabIndex = 3;
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
            // dgvAsientos
            //
            this.dgvAsientos.AllowUserToAddRows = false;
            this.dgvAsientos.AllowUserToDeleteRows = false;
            this.dgvAsientos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAsientos.Location = new System.Drawing.Point(10, 40);
            this.dgvAsientos.MultiSelect = false;
            this.dgvAsientos.Name = "dgvAsientos";
            this.dgvAsientos.ReadOnly = true;
            this.dgvAsientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsientos.Size = new System.Drawing.Size(870, 280);
            this.dgvAsientos.TabIndex = 5;
            this.dgvAsientos.SelectionChanged += new System.EventHandler(this.DgvAsientos_SelectionChanged);
            //
            // lblDetalles
            //
            this.lblDetalles.AutoSize = true;
            this.lblDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDetalles.Location = new System.Drawing.Point(10, 330);
            this.lblDetalles.Name = "lblDetalles";
            this.lblDetalles.Size = new System.Drawing.Size(113, 13);
            this.lblDetalles.TabIndex = 6;
            this.lblDetalles.Text = "Detalle del asiento:";
            //
            // dgvDetalles
            //
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalles.Location = new System.Drawing.Point(10, 350);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(870, 280);
            this.dgvDetalles.TabIndex = 7;
            //
            // lblTotalAsientos
            //
            this.lblTotalAsientos.AutoSize = true;
            this.lblTotalAsientos.Location = new System.Drawing.Point(410, 14);
            this.lblTotalAsientos.Name = "lblTotalAsientos";
            this.lblTotalAsientos.Size = new System.Drawing.Size(75, 13);
            this.lblTotalAsientos.TabIndex = 8;
            this.lblTotalAsientos.Text = "Total: 0 asientos";
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
            this.tabCuentas.Size = new System.Drawing.Size(892, 674);
            this.tabCuentas.TabIndex = 1;
            this.tabCuentas.Text = "Cuentas";
            this.tabCuentas.UseVisualStyleBackColor = true;
            //
            // lblDesdeC
            //
            this.lblDesdeC.AutoSize = true;
            this.lblDesdeC.Location = new System.Drawing.Point(10, 14);
            this.lblDesdeC.Name = "lblDesdeC";
            this.lblDesdeC.Size = new System.Drawing.Size(38, 13);
            this.lblDesdeC.TabIndex = 0;
            this.lblDesdeC.Text = "Desde:";
            //
            // dtpDesdeC
            //
            this.dtpDesdeC.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesdeC.Location = new System.Drawing.Point(55, 10);
            this.dtpDesdeC.Name = "dtpDesdeC";
            this.dtpDesdeC.Size = new System.Drawing.Size(100, 20);
            this.dtpDesdeC.TabIndex = 1;
            //
            // lblHastaC
            //
            this.lblHastaC.AutoSize = true;
            this.lblHastaC.Location = new System.Drawing.Point(165, 14);
            this.lblHastaC.Name = "lblHastaC";
            this.lblHastaC.Size = new System.Drawing.Size(35, 13);
            this.lblHastaC.TabIndex = 2;
            this.lblHastaC.Text = "Hasta:";
            //
            // dtpHastaC
            //
            this.dtpHastaC.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHastaC.Location = new System.Drawing.Point(205, 10);
            this.dtpHastaC.Name = "dtpHastaC";
            this.dtpHastaC.Size = new System.Drawing.Size(100, 20);
            this.dtpHastaC.TabIndex = 3;
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
            // dgvCuentas
            //
            this.dgvCuentas.AllowUserToAddRows = false;
            this.dgvCuentas.AllowUserToDeleteRows = false;
            this.dgvCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCuentas.Location = new System.Drawing.Point(10, 40);
            this.dgvCuentas.Name = "dgvCuentas";
            this.dgvCuentas.ReadOnly = true;
            this.dgvCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuentas.Size = new System.Drawing.Size(870, 620);
            this.dgvCuentas.TabIndex = 5;
            //
            // FormContabilidad
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 700);
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
    }
}
