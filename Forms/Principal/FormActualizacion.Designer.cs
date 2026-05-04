namespace SistemaPOS.Forms.Principal
{
    partial class FormActualizacion
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
            this.pnlHeader        = new System.Windows.Forms.Panel();
            this.lblIconUpdate    = new System.Windows.Forms.Label();
            this.lblTitulo        = new System.Windows.Forms.Label();
            this.pnlBody          = new System.Windows.Forms.Panel();
            this.lblVersionNueva  = new System.Windows.Forms.Label();
            this.lblDescripcion   = new System.Windows.Forms.Label();
            this.pnlProgreso      = new System.Windows.Forms.Panel();
            this.lblEstadoDescarga = new System.Windows.Forms.Label();
            this.progressBar      = new System.Windows.Forms.ProgressBar();
            this.pnlBotones       = new System.Windows.Forms.Panel();
            this.btnAhora         = new System.Windows.Forms.Button();
            this.btnLuego         = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlProgreso.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblIconUpdate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(500, 64);
            this.pnlHeader.TabIndex = 0;
            //
            // lblIconUpdate
            //
            this.lblIconUpdate.Font = new System.Drawing.Font("Segoe MDL2 Assets", 18F);
            this.lblIconUpdate.ForeColor = System.Drawing.Color.FromArgb(100, 180, 230);
            this.lblIconUpdate.Location = new System.Drawing.Point(14, 16);
            this.lblIconUpdate.Name = "lblIconUpdate";
            this.lblIconUpdate.Size = new System.Drawing.Size(34, 32);
            this.lblIconUpdate.TabIndex = 0;
            this.lblIconUpdate.Text = "";
            this.lblIconUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTitulo
            //
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(54, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(432, 28);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Actualización disponible";
            //
            // pnlBody
            //
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.pnlProgreso);
            this.pnlBody.Controls.Add(this.lblDescripcion);
            this.pnlBody.Controls.Add(this.lblVersionNueva);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 64);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(500, 146);
            this.pnlBody.TabIndex = 1;
            //
            // lblVersionNueva
            //
            this.lblVersionNueva.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblVersionNueva.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblVersionNueva.Location = new System.Drawing.Point(24, 20);
            this.lblVersionNueva.Name = "lblVersionNueva";
            this.lblVersionNueva.Size = new System.Drawing.Size(452, 26);
            this.lblVersionNueva.TabIndex = 0;
            this.lblVersionNueva.Text = "Nueva versión disponible: v1.0.1";
            //
            // lblDescripcion
            //
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(100, 110, 120);
            this.lblDescripcion.Location = new System.Drawing.Point(24, 50);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(452, 34);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Hay una nueva versión de SystemPOS disponible.\r\n¿Desea actualizar ahora?";
            //
            // pnlProgreso
            //
            this.pnlProgreso.Controls.Add(this.lblEstadoDescarga);
            this.pnlProgreso.Controls.Add(this.progressBar);
            this.pnlProgreso.Location = new System.Drawing.Point(24, 90);
            this.pnlProgreso.Name = "pnlProgreso";
            this.pnlProgreso.Size = new System.Drawing.Size(452, 48);
            this.pnlProgreso.TabIndex = 2;
            this.pnlProgreso.Visible = false;
            //
            // lblEstadoDescarga
            //
            this.lblEstadoDescarga.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEstadoDescarga.ForeColor = System.Drawing.Color.FromArgb(80, 90, 100);
            this.lblEstadoDescarga.Location = new System.Drawing.Point(0, 0);
            this.lblEstadoDescarga.Name = "lblEstadoDescarga";
            this.lblEstadoDescarga.Size = new System.Drawing.Size(452, 18);
            this.lblEstadoDescarga.TabIndex = 0;
            this.lblEstadoDescarga.Text = "Descargando...";
            //
            // progressBar
            //
            this.progressBar.Location = new System.Drawing.Point(0, 22);
            this.progressBar.Maximum = 100;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(452, 20);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 1;
            //
            // pnlBotones
            //
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(244, 246, 250);
            this.pnlBotones.Controls.Add(this.btnLuego);
            this.pnlBotones.Controls.Add(this.btnAhora);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 210);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(500, 60);
            this.pnlBotones.TabIndex = 2;
            //
            // btnAhora
            //
            this.btnAhora.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnAhora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAhora.FlatAppearance.BorderSize = 0;
            this.btnAhora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAhora.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAhora.ForeColor = System.Drawing.Color.White;
            this.btnAhora.Location = new System.Drawing.Point(148, 12);
            this.btnAhora.Name = "btnAhora";
            this.btnAhora.Size = new System.Drawing.Size(160, 36);
            this.btnAhora.TabIndex = 0;
            this.btnAhora.Text = "Actualizar Ahora";
            this.btnAhora.UseVisualStyleBackColor = false;
            //
            // btnLuego
            //
            this.btnLuego.BackColor = System.Drawing.Color.FromArgb(200, 208, 216);
            this.btnLuego.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuego.FlatAppearance.BorderSize = 0;
            this.btnLuego.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuego.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLuego.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.btnLuego.Location = new System.Drawing.Point(320, 12);
            this.btnLuego.Name = "btnLuego";
            this.btnLuego.Size = new System.Drawing.Size(164, 36);
            this.btnLuego.TabIndex = 1;
            this.btnLuego.Text = "Actualizar Más Tarde";
            this.btnLuego.UseVisualStyleBackColor = false;
            //
            // FormActualizacion
            //
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 270);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormActualizacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualización de SystemPOS";
            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlProgreso.ResumeLayout(false);
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel       pnlHeader;
        private System.Windows.Forms.Label       lblIconUpdate;
        private System.Windows.Forms.Label       lblTitulo;
        private System.Windows.Forms.Panel       pnlBody;
        private System.Windows.Forms.Label       lblVersionNueva;
        private System.Windows.Forms.Label       lblDescripcion;
        private System.Windows.Forms.Panel       pnlProgreso;
        private System.Windows.Forms.Label       lblEstadoDescarga;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel       pnlBotones;
        private System.Windows.Forms.Button      btnAhora;
        private System.Windows.Forms.Button      btnLuego;
    }
}
