namespace SistemaPOS.Forms.Finanzas
{
    partial class FormAperturaCaja
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
            this.pnlCard = new System.Windows.Forms.Panel();
            this.pnlCardFooter = new System.Windows.Forms.Panel();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.pnlFooterLine = new System.Windows.Forms.Panel();
            this.chkCapitalInicial = new System.Windows.Forms.CheckBox();
            this.pnlChipNoche = new System.Windows.Forms.Panel();
            this.lblChipNoche = new System.Windows.Forms.Label();
            this.pnlChipTarde = new System.Windows.Forms.Panel();
            this.lblChipTarde = new System.Windows.Forms.Label();
            this.pnlChipMañana = new System.Windows.Forms.Panel();
            this.lblChipMañana = new System.Windows.Forms.Label();
            this.rbNoche = new System.Windows.Forms.RadioButton();
            this.rbTarde = new System.Windows.Forms.RadioButton();
            this.rbMañana = new System.Windows.Forms.RadioButton();
            this.lblSecTurno = new System.Windows.Forms.Label();
            this.pnlLineMonto = new System.Windows.Forms.Panel();
            this.pnlMontoWrapper = new System.Windows.Forms.Panel();
            this.lblCurrencyPrefix = new System.Windows.Forms.Label();
            this.txtMontoInicial = new System.Windows.Forms.TextBox();
            this.lblSecMonto = new System.Windows.Forms.Label();
            this.pnlDiv1 = new System.Windows.Forms.Panel();
            this.pnlUserRow = new System.Windows.Forms.Panel();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblDateDisplay = new System.Windows.Forms.Label();
            this.pnlCardHeader = new System.Windows.Forms.Panel();
            this.lblCardTitle = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.pnlCard.SuspendLayout();
            this.pnlCardFooter.SuspendLayout();
            this.pnlChipNoche.SuspendLayout();
            this.pnlChipTarde.SuspendLayout();
            this.pnlChipMañana.SuspendLayout();
            this.pnlMontoWrapper.SuspendLayout();
            this.pnlUserRow.SuspendLayout();
            this.pnlCardHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.pnlCardFooter);
            this.pnlCard.Controls.Add(this.chkCapitalInicial);
            this.pnlCard.Controls.Add(this.pnlChipNoche);
            this.pnlCard.Controls.Add(this.pnlChipTarde);
            this.pnlCard.Controls.Add(this.pnlChipMañana);
            this.pnlCard.Controls.Add(this.rbNoche);
            this.pnlCard.Controls.Add(this.rbTarde);
            this.pnlCard.Controls.Add(this.rbMañana);
            this.pnlCard.Controls.Add(this.lblSecTurno);
            this.pnlCard.Controls.Add(this.pnlMontoWrapper);
            this.pnlCard.Controls.Add(this.lblSecMonto);
            this.pnlCard.Controls.Add(this.pnlDiv1);
            this.pnlCard.Controls.Add(this.pnlUserRow);
            this.pnlCard.Controls.Add(this.pnlCardHeader);
            this.pnlCard.Location = new System.Drawing.Point(17, 23);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(457, 413);
            this.pnlCard.TabIndex = 0;
            // 
            // pnlCardFooter
            // 
            this.pnlCardFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlCardFooter.Controls.Add(this.btnAbrir);
            this.pnlCardFooter.Controls.Add(this.pnlFooterLine);
            this.pnlCardFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCardFooter.Location = new System.Drawing.Point(0, 364);
            this.pnlCardFooter.Name = "pnlCardFooter";
            this.pnlCardFooter.Size = new System.Drawing.Size(457, 49);
            this.pnlCardFooter.TabIndex = 11;
            // 
            // btnAbrir
            // 
            this.btnAbrir.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAbrir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrir.FlatAppearance.BorderSize = 0;
            this.btnAbrir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAbrir.ForeColor = System.Drawing.Color.White;
            this.btnAbrir.Location = new System.Drawing.Point(12, 9);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(433, 31);
            this.btnAbrir.TabIndex = 1;
            this.btnAbrir.Text = "ABRIR CAJA  →";
            this.btnAbrir.UseVisualStyleBackColor = false;
            // 
            // pnlFooterLine
            // 
            this.pnlFooterLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlFooterLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFooterLine.Location = new System.Drawing.Point(0, 0);
            this.pnlFooterLine.Name = "pnlFooterLine";
            this.pnlFooterLine.Size = new System.Drawing.Size(457, 1);
            this.pnlFooterLine.TabIndex = 0;
            // 
            // chkCapitalInicial
            // 
            this.chkCapitalInicial.AutoSize = true;
            this.chkCapitalInicial.Font = new System.Drawing.Font("Inter V Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCapitalInicial.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.chkCapitalInicial.Location = new System.Drawing.Point(104, 216);
            this.chkCapitalInicial.Name = "chkCapitalInicial";
            this.chkCapitalInicial.Size = new System.Drawing.Size(240, 23);
            this.chkCapitalInicial.TabIndex = 10;
            this.chkCapitalInicial.Text = "Registrar como capital inicial";
            this.chkCapitalInicial.UseVisualStyleBackColor = true;
            // 
            // pnlChipNoche
            // 
            this.pnlChipNoche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlChipNoche.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChipNoche.Controls.Add(this.lblChipNoche);
            this.pnlChipNoche.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlChipNoche.Location = new System.Drawing.Point(286, 308);
            this.pnlChipNoche.Name = "pnlChipNoche";
            this.pnlChipNoche.Size = new System.Drawing.Size(96, 28);
            this.pnlChipNoche.TabIndex = 9;
            // 
            // lblChipNoche
            // 
            this.lblChipNoche.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChipNoche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChipNoche.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblChipNoche.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblChipNoche.Location = new System.Drawing.Point(0, 0);
            this.lblChipNoche.Name = "lblChipNoche";
            this.lblChipNoche.Size = new System.Drawing.Size(94, 26);
            this.lblChipNoche.TabIndex = 0;
            this.lblChipNoche.Text = "Noche";
            this.lblChipNoche.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlChipTarde
            // 
            this.pnlChipTarde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlChipTarde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChipTarde.Controls.Add(this.lblChipTarde);
            this.pnlChipTarde.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlChipTarde.Location = new System.Drawing.Point(177, 308);
            this.pnlChipTarde.Name = "pnlChipTarde";
            this.pnlChipTarde.Size = new System.Drawing.Size(91, 28);
            this.pnlChipTarde.TabIndex = 8;
            // 
            // lblChipTarde
            // 
            this.lblChipTarde.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChipTarde.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChipTarde.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblChipTarde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblChipTarde.Location = new System.Drawing.Point(0, 0);
            this.lblChipTarde.Name = "lblChipTarde";
            this.lblChipTarde.Size = new System.Drawing.Size(89, 26);
            this.lblChipTarde.TabIndex = 0;
            this.lblChipTarde.Text = "Tarde";
            this.lblChipTarde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlChipMañana
            // 
            this.pnlChipMañana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlChipMañana.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChipMañana.Controls.Add(this.lblChipMañana);
            this.pnlChipMañana.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlChipMañana.Location = new System.Drawing.Point(68, 309);
            this.pnlChipMañana.Name = "pnlChipMañana";
            this.pnlChipMañana.Size = new System.Drawing.Size(91, 28);
            this.pnlChipMañana.TabIndex = 7;
            // 
            // lblChipMañana
            // 
            this.lblChipMañana.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChipMañana.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChipMañana.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblChipMañana.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblChipMañana.Location = new System.Drawing.Point(0, 0);
            this.lblChipMañana.Name = "lblChipMañana";
            this.lblChipMañana.Size = new System.Drawing.Size(89, 26);
            this.lblChipMañana.TabIndex = 0;
            this.lblChipMañana.Text = "Mañana";
            this.lblChipMañana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbNoche
            // 
            this.rbNoche.Location = new System.Drawing.Point(0, 0);
            this.rbNoche.Name = "rbNoche";
            this.rbNoche.Size = new System.Drawing.Size(1, 1);
            this.rbNoche.TabIndex = 22;
            this.rbNoche.Visible = false;
            // 
            // rbTarde
            // 
            this.rbTarde.Location = new System.Drawing.Point(0, 0);
            this.rbTarde.Name = "rbTarde";
            this.rbTarde.Size = new System.Drawing.Size(1, 1);
            this.rbTarde.TabIndex = 21;
            this.rbTarde.Visible = false;
            // 
            // rbMañana
            // 
            this.rbMañana.Location = new System.Drawing.Point(0, 0);
            this.rbMañana.Name = "rbMañana";
            this.rbMañana.Size = new System.Drawing.Size(1, 1);
            this.rbMañana.TabIndex = 20;
            this.rbMañana.Visible = false;
            // 
            // lblSecTurno
            // 
            this.lblSecTurno.AutoSize = true;
            this.lblSecTurno.Font = new System.Drawing.Font("Be Vietnam Pro", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecTurno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblSecTurno.Location = new System.Drawing.Point(190, 278);
            this.lblSecTurno.Name = "lblSecTurno";
            this.lblSecTurno.Size = new System.Drawing.Size(49, 17);
            this.lblSecTurno.TabIndex = 6;
            this.lblSecTurno.Text = "TURNO";
            // 
            // pnlLineMonto
            // 
            this.pnlLineMonto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlLineMonto.Location = new System.Drawing.Point(23, 69);
            this.pnlLineMonto.Name = "pnlLineMonto";
            this.pnlLineMonto.Size = new System.Drawing.Size(291, 2);
            this.pnlLineMonto.TabIndex = 5;
            // 
            // pnlMontoWrapper
            // 
            this.pnlMontoWrapper.BackColor = System.Drawing.Color.White;
            this.pnlMontoWrapper.Controls.Add(this.pnlLineMonto);
            this.pnlMontoWrapper.Controls.Add(this.lblCurrencyPrefix);
            this.pnlMontoWrapper.Controls.Add(this.txtMontoInicial);
            this.pnlMontoWrapper.Location = new System.Drawing.Point(54, 116);
            this.pnlMontoWrapper.Name = "pnlMontoWrapper";
            this.pnlMontoWrapper.Size = new System.Drawing.Size(346, 94);
            this.pnlMontoWrapper.TabIndex = 4;
            // 
            // lblCurrencyPrefix
            // 
            this.lblCurrencyPrefix.Font = new System.Drawing.Font("Be Vietnam Pro", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrencyPrefix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblCurrencyPrefix.Location = new System.Drawing.Point(11, 14);
            this.lblCurrencyPrefix.Name = "lblCurrencyPrefix";
            this.lblCurrencyPrefix.Size = new System.Drawing.Size(65, 57);
            this.lblCurrencyPrefix.TabIndex = 0;
            this.lblCurrencyPrefix.Text = "S/";
            this.lblCurrencyPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMontoInicial
            // 
            this.txtMontoInicial.BackColor = System.Drawing.Color.White;
            this.txtMontoInicial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMontoInicial.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.txtMontoInicial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtMontoInicial.Location = new System.Drawing.Point(79, 16);
            this.txtMontoInicial.Name = "txtMontoInicial";
            this.txtMontoInicial.Size = new System.Drawing.Size(198, 47);
            this.txtMontoInicial.TabIndex = 1;
            this.txtMontoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSecMonto
            // 
            this.lblSecMonto.AutoSize = true;
            this.lblSecMonto.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblSecMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblSecMonto.Location = new System.Drawing.Point(164, 86);
            this.lblSecMonto.Name = "lblSecMonto";
            this.lblSecMonto.Size = new System.Drawing.Size(120, 12);
            this.lblSecMonto.TabIndex = 3;
            this.lblSecMonto.Text = "EFECTIVO DE APERTURA";
            // 
            // pnlDiv1
            // 
            this.pnlDiv1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlDiv1.Location = new System.Drawing.Point(0, 75);
            this.pnlDiv1.Name = "pnlDiv1";
            this.pnlDiv1.Size = new System.Drawing.Size(326, 1);
            this.pnlDiv1.TabIndex = 2;
            // 
            // pnlUserRow
            // 
            this.pnlUserRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlUserRow.Controls.Add(this.txtUsuario);
            this.pnlUserRow.Controls.Add(this.dtpFecha);
            this.pnlUserRow.Controls.Add(this.lblDateDisplay);
            this.pnlUserRow.Location = new System.Drawing.Point(0, 42);
            this.pnlUserRow.Name = "pnlUserRow";
            this.pnlUserRow.Size = new System.Drawing.Size(457, 33);
            this.pnlUserRow.TabIndex = 1;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtUsuario.Location = new System.Drawing.Point(32, 7);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(154, 17);
            this.txtUsuario.TabIndex = 0;
            // 
            // lblDateDisplay
            // 
            this.lblDateDisplay.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDateDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblDateDisplay.Location = new System.Drawing.Point(190, 10);
            this.lblDateDisplay.Name = "lblDateDisplay";
            this.lblDateDisplay.Size = new System.Drawing.Size(127, 14);
            this.lblDateDisplay.TabIndex = 1;
            this.lblDateDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlCardHeader
            // 
            this.pnlCardHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.pnlCardHeader.Controls.Add(this.lblCardTitle);
            this.pnlCardHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCardHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlCardHeader.Name = "pnlCardHeader";
            this.pnlCardHeader.Size = new System.Drawing.Size(457, 42);
            this.pnlCardHeader.TabIndex = 0;
            // 
            // lblCardTitle
            // 
            this.lblCardTitle.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblCardTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCardTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle.ForeColor = System.Drawing.Color.White;
            this.lblCardTitle.Location = new System.Drawing.Point(0, 0);
            this.lblCardTitle.Name = "lblCardTitle";
            this.lblCardTitle.Size = new System.Drawing.Size(457, 42);
            this.lblCardTitle.TabIndex = 0;
            this.lblCardTitle.Text = "APERTURA DE CAJA";
            this.lblCardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(393, 3);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(86, 20);
            this.lblFecha.TabIndex = 82;
            this.lblFecha.Visible = false;
            // 
            // dtpHora
            // 
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(194, 0);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.Size = new System.Drawing.Size(80, 20);
            this.dtpHora.TabIndex = 81;
            this.dtpHora.Visible = false;
            this.dtpHora.ValueChanged += new System.EventHandler(this.dtpHora_ValueChanged);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(366, 4);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(79, 20);
            this.dtpFecha.TabIndex = 80;
            this.dtpFecha.Visible = false;
            // 
            // FormAperturaCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(491, 455);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.dtpHora);
            this.Controls.Add(this.lblFecha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAperturaCaja";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apertura de Caja";
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.pnlCardFooter.ResumeLayout(false);
            this.pnlChipNoche.ResumeLayout(false);
            this.pnlChipTarde.ResumeLayout(false);
            this.pnlChipMañana.ResumeLayout(false);
            this.pnlMontoWrapper.ResumeLayout(false);
            this.pnlMontoWrapper.PerformLayout();
            this.pnlUserRow.ResumeLayout(false);
            this.pnlUserRow.PerformLayout();
            this.pnlCardHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel   pnlCard;
        private System.Windows.Forms.Panel   pnlCardHeader;
        private System.Windows.Forms.Label   lblCardTitle;
        private System.Windows.Forms.Panel   pnlUserRow;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label   lblDateDisplay;
        private System.Windows.Forms.Panel   pnlDiv1;

        private System.Windows.Forms.Label   lblSecMonto;
        private System.Windows.Forms.Panel   pnlMontoWrapper;
        private System.Windows.Forms.Label   lblCurrencyPrefix;
        private System.Windows.Forms.TextBox txtMontoInicial;
        private System.Windows.Forms.Panel   pnlLineMonto;

        private System.Windows.Forms.Label       lblSecTurno;
        private System.Windows.Forms.Panel       pnlChipMañana;
        private System.Windows.Forms.Label       lblChipMañana;
        private System.Windows.Forms.Panel       pnlChipTarde;
        private System.Windows.Forms.Label       lblChipTarde;
        private System.Windows.Forms.Panel       pnlChipNoche;
        private System.Windows.Forms.Label       lblChipNoche;
        private System.Windows.Forms.RadioButton rbMañana;
        private System.Windows.Forms.RadioButton rbTarde;
        private System.Windows.Forms.RadioButton rbNoche;
        private System.Windows.Forms.Label          lblFecha;

        private System.Windows.Forms.CheckBox chkCapitalInicial;
        private System.Windows.Forms.Panel    pnlCardFooter;
        private System.Windows.Forms.Panel    pnlFooterLine;
        private System.Windows.Forms.Button   btnAbrir;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.DateTimePicker dtpFecha;
    }
}
