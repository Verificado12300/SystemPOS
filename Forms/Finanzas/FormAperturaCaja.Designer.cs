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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtituloHeader = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlCardMonto = new System.Windows.Forms.Panel();
            this.lblMontoInicial = new System.Windows.Forms.Label();
            this.txtMontoInicial = new System.Windows.Forms.TextBox();
            this.chkCapitalInicial = new System.Windows.Forms.CheckBox();
            this.pnlCardTurno = new System.Windows.Forms.Panel();
            this.lblCardTurnoTitulo = new System.Windows.Forms.Label();
            this.rbMañana = new System.Windows.Forms.RadioButton();
            this.rbTarde = new System.Windows.Forms.RadioButton();
            this.rbNoche = new System.Windows.Forms.RadioButton();
            this.pnlCardDatos = new System.Windows.Forms.Panel();
            this.lblCardDatosTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblHora = new System.Windows.Forms.Label();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlCardMonto.SuspendLayout();
            this.pnlCardTurno.SuspendLayout();
            this.pnlCardDatos.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.pnlHeader.Controls.Add(this.lblSubtituloHeader);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 68;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(16, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(150, 21);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Apertura de Caja";
            //
            // lblSubtituloHeader
            //
            this.lblSubtituloHeader.AutoSize = true;
            this.lblSubtituloHeader.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtituloHeader.ForeColor = System.Drawing.Color.FromArgb(178, 190, 195);
            this.lblSubtituloHeader.Location = new System.Drawing.Point(16, 42);
            this.lblSubtituloHeader.Name = "lblSubtituloHeader";
            this.lblSubtituloHeader.Size = new System.Drawing.Size(90, 15);
            this.lblSubtituloHeader.TabIndex = 1;
            this.lblSubtituloHeader.Text = "Inicio de turno";
            //
            // pnlFooter
            //
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.btnAbrir);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 56;
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.TabIndex = 2;
            //
            // btnAbrir
            //
            this.btnAbrir.BackColor = System.Drawing.Color.FromArgb(0, 184, 148);
            this.btnAbrir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrir.FlatAppearance.BorderSize = 0;
            this.btnAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrir.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAbrir.ForeColor = System.Drawing.Color.White;
            this.btnAbrir.Location = new System.Drawing.Point(16, 13);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(388, 30);
            this.btnAbrir.TabIndex = 0;
            this.btnAbrir.Text = "Abrir Caja";
            this.btnAbrir.UseVisualStyleBackColor = false;
            //
            // pnlBody
            //
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
            this.pnlBody.Controls.Add(this.pnlCardMonto);
            this.pnlBody.Controls.Add(this.pnlCardTurno);
            this.pnlBody.Controls.Add(this.pnlCardDatos);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.TabIndex = 1;
            //
            // pnlCardDatos
            //
            this.pnlCardDatos.BackColor = System.Drawing.Color.White;
            this.pnlCardDatos.Controls.Add(this.lblCardDatosTitulo);
            this.pnlCardDatos.Controls.Add(this.lblUsuario);
            this.pnlCardDatos.Controls.Add(this.txtUsuario);
            this.pnlCardDatos.Controls.Add(this.lblFecha);
            this.pnlCardDatos.Controls.Add(this.dtpFecha);
            this.pnlCardDatos.Controls.Add(this.lblHora);
            this.pnlCardDatos.Controls.Add(this.dtpHora);
            this.pnlCardDatos.Location = new System.Drawing.Point(10, 10);
            this.pnlCardDatos.Name = "pnlCardDatos";
            this.pnlCardDatos.Size = new System.Drawing.Size(398, 108);
            this.pnlCardDatos.TabIndex = 0;
            //
            // lblCardDatosTitulo
            //
            this.lblCardDatosTitulo.AutoSize = true;
            this.lblCardDatosTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCardDatosTitulo.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblCardDatosTitulo.Location = new System.Drawing.Point(14, 10);
            this.lblCardDatosTitulo.Name = "lblCardDatosTitulo";
            this.lblCardDatosTitulo.Size = new System.Drawing.Size(110, 13);
            this.lblCardDatosTitulo.TabIndex = 0;
            this.lblCardDatosTitulo.Text = "DATOS DE SESIÓN";
            //
            // lblUsuario
            //
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsuario.Location = new System.Drawing.Point(14, 38);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(50, 15);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario:";
            //
            // txtUsuario
            //
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsuario.Location = new System.Drawing.Point(76, 34);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(308, 26);
            this.txtUsuario.TabIndex = 2;
            //
            // lblFecha
            //
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFecha.Location = new System.Drawing.Point(14, 74);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(41, 15);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha:";
            //
            // dtpFecha
            //
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(62, 70);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(150, 24);
            this.dtpFecha.TabIndex = 4;
            //
            // lblHora
            //
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHora.Location = new System.Drawing.Point(224, 74);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(36, 15);
            this.lblHora.TabIndex = 5;
            this.lblHora.Text = "Hora:";
            //
            // dtpHora
            //
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(260, 70);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.Size = new System.Drawing.Size(124, 24);
            this.dtpHora.TabIndex = 6;
            //
            // pnlCardTurno
            //
            this.pnlCardTurno.BackColor = System.Drawing.Color.White;
            this.pnlCardTurno.Controls.Add(this.lblCardTurnoTitulo);
            this.pnlCardTurno.Controls.Add(this.rbMañana);
            this.pnlCardTurno.Controls.Add(this.rbTarde);
            this.pnlCardTurno.Controls.Add(this.rbNoche);
            this.pnlCardTurno.Location = new System.Drawing.Point(10, 126);
            this.pnlCardTurno.Name = "pnlCardTurno";
            this.pnlCardTurno.Size = new System.Drawing.Size(398, 70);
            this.pnlCardTurno.TabIndex = 1;
            //
            // lblCardTurnoTitulo
            //
            this.lblCardTurnoTitulo.AutoSize = true;
            this.lblCardTurnoTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCardTurnoTitulo.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblCardTurnoTitulo.Location = new System.Drawing.Point(14, 10);
            this.lblCardTurnoTitulo.Name = "lblCardTurnoTitulo";
            this.lblCardTurnoTitulo.Size = new System.Drawing.Size(140, 13);
            this.lblCardTurnoTitulo.TabIndex = 0;
            this.lblCardTurnoTitulo.Text = "TURNO (REFERENCIAL)";
            //
            // rbMañana
            //
            this.rbMañana.AutoSize = true;
            this.rbMañana.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rbMañana.Location = new System.Drawing.Point(14, 36);
            this.rbMañana.Name = "rbMañana";
            this.rbMañana.Size = new System.Drawing.Size(75, 21);
            this.rbMañana.TabIndex = 1;
            this.rbMañana.TabStop = true;
            this.rbMañana.Text = "Mañana";
            this.rbMañana.UseVisualStyleBackColor = true;
            //
            // rbTarde
            //
            this.rbTarde.AutoSize = true;
            this.rbTarde.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rbTarde.Location = new System.Drawing.Point(110, 36);
            this.rbTarde.Name = "rbTarde";
            this.rbTarde.Size = new System.Drawing.Size(60, 21);
            this.rbTarde.TabIndex = 2;
            this.rbTarde.TabStop = true;
            this.rbTarde.Text = "Tarde";
            this.rbTarde.UseVisualStyleBackColor = true;
            //
            // rbNoche
            //
            this.rbNoche.AutoSize = true;
            this.rbNoche.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rbNoche.Location = new System.Drawing.Point(185, 36);
            this.rbNoche.Name = "rbNoche";
            this.rbNoche.Size = new System.Drawing.Size(63, 21);
            this.rbNoche.TabIndex = 3;
            this.rbNoche.TabStop = true;
            this.rbNoche.Text = "Noche";
            this.rbNoche.UseVisualStyleBackColor = true;
            //
            // pnlCardMonto
            //
            this.pnlCardMonto.BackColor = System.Drawing.Color.White;
            this.pnlCardMonto.Controls.Add(this.lblMontoInicial);
            this.pnlCardMonto.Controls.Add(this.txtMontoInicial);
            this.pnlCardMonto.Controls.Add(this.chkCapitalInicial);
            this.pnlCardMonto.Location = new System.Drawing.Point(10, 204);
            this.pnlCardMonto.Name = "pnlCardMonto";
            this.pnlCardMonto.Size = new System.Drawing.Size(398, 130);
            this.pnlCardMonto.TabIndex = 2;
            //
            // lblMontoInicial
            //
            this.lblMontoInicial.AutoSize = true;
            this.lblMontoInicial.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMontoInicial.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblMontoInicial.Location = new System.Drawing.Point(14, 10);
            this.lblMontoInicial.Name = "lblMontoInicial";
            this.lblMontoInicial.Size = new System.Drawing.Size(130, 13);
            this.lblMontoInicial.TabIndex = 0;
            this.lblMontoInicial.Text = "MONTO INICIAL (S/)";
            //
            // txtMontoInicial
            //
            this.txtMontoInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoInicial.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.txtMontoInicial.Location = new System.Drawing.Point(99, 34);
            this.txtMontoInicial.Multiline = false;
            this.txtMontoInicial.Name = "txtMontoInicial";
            this.txtMontoInicial.Size = new System.Drawing.Size(200, 48);
            this.txtMontoInicial.TabIndex = 1;
            this.txtMontoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // chkCapitalInicial
            //
            this.chkCapitalInicial.AutoSize = true;
            this.chkCapitalInicial.Checked = false;
            this.chkCapitalInicial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkCapitalInicial.ForeColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.chkCapitalInicial.Location = new System.Drawing.Point(14, 96);
            this.chkCapitalInicial.Name = "chkCapitalInicial";
            this.chkCapitalInicial.Size = new System.Drawing.Size(260, 19);
            this.chkCapitalInicial.TabIndex = 2;
            this.chkCapitalInicial.Text = "Es capital inicial (genera asiento contable)";
            this.chkCapitalInicial.UseVisualStyleBackColor = true;
            //
            // FormAperturaCaja
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 470);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAperturaCaja";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apertura de Caja";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlCardDatos.ResumeLayout(false);
            this.pnlCardDatos.PerformLayout();
            this.pnlCardTurno.ResumeLayout(false);
            this.pnlCardTurno.PerformLayout();
            this.pnlCardMonto.ResumeLayout(false);
            this.pnlCardMonto.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtituloHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlCardDatos;
        private System.Windows.Forms.Label lblCardDatosTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Panel pnlCardTurno;
        private System.Windows.Forms.Label lblCardTurnoTitulo;
        private System.Windows.Forms.RadioButton rbMañana;
        private System.Windows.Forms.RadioButton rbTarde;
        private System.Windows.Forms.RadioButton rbNoche;
        private System.Windows.Forms.Panel pnlCardMonto;
        private System.Windows.Forms.Label lblMontoInicial;
        private System.Windows.Forms.TextBox txtMontoInicial;
        private System.Windows.Forms.CheckBox chkCapitalInicial;
    }
}
