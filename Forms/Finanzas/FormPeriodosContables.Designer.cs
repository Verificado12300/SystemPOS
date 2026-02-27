namespace SistemaPOS.Forms.Finanzas
{
    partial class FormPeriodosContables
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
            this.pnlTop       = new System.Windows.Forms.Panel();
            this.lblAnio      = new System.Windows.Forms.Label();
            this.nudAnio      = new System.Windows.Forms.NumericUpDown();
            this.lblMes       = new System.Windows.Forms.Label();
            this.cmbMes       = new System.Windows.Forms.ComboBox();
            this.btnCerrar         = new System.Windows.Forms.Button();
            this.btnReabrir        = new System.Windows.Forms.Button();
            this.btnActualizar     = new System.Windows.Forms.Button();
            this.btnGenerarCierre  = new System.Windows.Forms.Button();
            this.lblCierreInfo     = new System.Windows.Forms.Label();
            this.dgvPeriodos       = new System.Windows.Forms.DataGridView();
            this.lblEstado         = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodos)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(240, 245, 255);
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.lblAnio);
            this.pnlTop.Controls.Add(this.nudAnio);
            this.pnlTop.Controls.Add(this.lblMes);
            this.pnlTop.Controls.Add(this.cmbMes);
            this.pnlTop.Controls.Add(this.btnCerrar);
            this.pnlTop.Controls.Add(this.btnReabrir);
            this.pnlTop.Controls.Add(this.btnActualizar);
            this.pnlTop.Controls.Add(this.lblCierreInfo);
            this.pnlTop.Controls.Add(this.btnGenerarCierre);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 100;
            this.pnlTop.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);

            // lblAnio
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(12, 22);
            this.lblAnio.Text = "Año:";

            // nudAnio
            this.nudAnio.Location = new System.Drawing.Point(48, 18);
            this.nudAnio.Minimum = 2000;
            this.nudAnio.Maximum = 2100;
            this.nudAnio.Size = new System.Drawing.Size(72, 23);

            // lblMes
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(134, 22);
            this.lblMes.Text = "Mes:";

            // cmbMes
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.Location = new System.Drawing.Point(168, 18);
            this.cmbMes.Size = new System.Drawing.Size(120, 23);
            this.cmbMes.Items.AddRange(new object[] {
                "Enero","Febrero","Marzo","Abril","Mayo","Junio",
                "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre"
            });

            // btnCerrar
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Location = new System.Drawing.Point(308, 15);
            this.btnCerrar.Size = new System.Drawing.Size(120, 30);
            this.btnCerrar.Text = "Cerrar Período";
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);

            // btnReabrir
            this.btnReabrir.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnReabrir.ForeColor = System.Drawing.Color.White;
            this.btnReabrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReabrir.Location = new System.Drawing.Point(440, 15);
            this.btnReabrir.Size = new System.Drawing.Size(120, 30);
            this.btnReabrir.Text = "Reabrir Período";
            this.btnReabrir.Click += new System.EventHandler(this.BtnReabrir_Click);

            // btnActualizar
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Location = new System.Drawing.Point(574, 15);
            this.btnActualizar.Size = new System.Drawing.Size(90, 30);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);

            // lblCierreInfo (fila 2, descriptivo)
            this.lblCierreInfo.AutoSize = true;
            this.lblCierreInfo.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblCierreInfo.Location = new System.Drawing.Point(12, 63);
            this.lblCierreInfo.Text = "Asiento de cierre (opcional — generar ANTES de cerrar el período):";

            // btnGenerarCierre (fila 2)
            this.btnGenerarCierre.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnGenerarCierre.ForeColor = System.Drawing.Color.White;
            this.btnGenerarCierre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarCierre.Location = new System.Drawing.Point(440, 58);
            this.btnGenerarCierre.Size = new System.Drawing.Size(224, 30);
            this.btnGenerarCierre.Text = "Generar Asiento de Cierre";
            this.btnGenerarCierre.Click += new System.EventHandler(this.BtnGenerarCierre_Click);

            // dgvPeriodos
            this.dgvPeriodos.AllowUserToAddRows = false;
            this.dgvPeriodos.AllowUserToDeleteRows = false;
            this.dgvPeriodos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPeriodos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPeriodos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPeriodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeriodos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPeriodos.ReadOnly = true;
            this.dgvPeriodos.RowHeadersVisible = false;
            this.dgvPeriodos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // lblEstado
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblEstado.Height = 22;
            this.lblEstado.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblEstado.Text = "";

            // FormPeriodosContables
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 480);
            this.Controls.Add(this.dgvPeriodos);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.lblEstado);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "FormPeriodosContables";
            this.Text = "Cierre de Período Contable";

            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodos)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.NumericUpDown nudAnio;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnReabrir;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnGenerarCierre;
        private System.Windows.Forms.Label  lblCierreInfo;
        private System.Windows.Forms.DataGridView dgvPeriodos;
        private System.Windows.Forms.Label lblEstado;
    }
}
