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
            // Header
            this.pnlHeader       = new System.Windows.Forms.Panel();
            this.pnlHeaderAccent = new System.Windows.Forms.Panel();
            this.lblTitulo       = new System.Windows.Forms.Label();
            this.lblSubtitulo    = new System.Windows.Forms.Label();

            // Nav tabs
            this.pnlNav        = new System.Windows.Forms.Panel();
            this.pnlNavSep     = new System.Windows.Forms.Panel();
            this.pnlTab1       = new System.Windows.Forms.Panel();
            this.pnlIndicator1 = new System.Windows.Forms.Panel();
            this.btnEstadoResultados = new System.Windows.Forms.Button();
            this.pnlTab2       = new System.Windows.Forms.Panel();
            this.pnlIndicator2 = new System.Windows.Forms.Panel();
            this.btnFlujoCaja  = new System.Windows.Forms.Button();
            this.pnlTab3       = new System.Windows.Forms.Panel();
            this.pnlIndicator3 = new System.Windows.Forms.Panel();
            this.btnBalanceGeneral = new System.Windows.Forms.Button();
            this.pnlTab4       = new System.Windows.Forms.Panel();
            this.pnlIndicator4 = new System.Windows.Forms.Panel();
            this.btnAsientos   = new System.Windows.Forms.Button();
            this.pnlTab5       = new System.Windows.Forms.Panel();
            this.pnlIndicator5 = new System.Windows.Forms.Panel();
            this.btnPeriodos   = new System.Windows.Forms.Button();

            // Content
            this.panelContenidoContabilidad = new System.Windows.Forms.Panel();

            // ── SuspendLayouts ────────────────────────────────────────────────
            this.pnlHeader.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.pnlTab1.SuspendLayout();
            this.pnlTab2.SuspendLayout();
            this.pnlTab3.SuspendLayout();
            this.pnlTab4.SuspendLayout();
            this.pnlTab5.SuspendLayout();
            this.SuspendLayout();

            // ══════════════════════════════════════════════════════════════════
            // pnlHeader  (Dock=Top, 80px, oscuro con accent strip)
            // ══════════════════════════════════════════════════════════════════
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 36, 40);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.pnlHeaderAccent);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1466, 80);
            this.pnlHeader.TabIndex = 0;

            // Accent strip izquierdo
            this.pnlHeaderAccent.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.pnlHeaderAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlHeaderAccent.Name = "pnlHeaderAccent";
            this.pnlHeaderAccent.Width = 5;
            this.pnlHeaderAccent.TabIndex = 2;

            // lblTitulo — grande, con emoji
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(22, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(560, 36);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "📊  Contabilidad";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblSubtitulo — descripción pequeña
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(160, 175, 180);
            this.lblSubtitulo.Location = new System.Drawing.Point(24, 52);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Informes financieros  ·  Libro diario  ·  Balance";

            // ══════════════════════════════════════════════════════════════════
            // pnlNav  (Dock=Top, 56px, blanco, con tabs y separador)
            // ══════════════════════════════════════════════════════════════════
            this.pnlNav.BackColor = System.Drawing.Color.White;
            this.pnlNav.Controls.Add(this.pnlNavSep);
            this.pnlNav.Controls.Add(this.pnlTab1);
            this.pnlNav.Controls.Add(this.pnlTab2);
            this.pnlNav.Controls.Add(this.pnlTab3);
            this.pnlNav.Controls.Add(this.pnlTab4);
            this.pnlNav.Controls.Add(this.pnlTab5);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(1466, 56);
            this.pnlNav.TabIndex = 1;

            // Separador inferior del nav
            this.pnlNavSep.BackColor = System.Drawing.Color.FromArgb(218, 220, 224);
            this.pnlNavSep.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavSep.Height = 1;
            this.pnlNavSep.Name = "pnlNavSep";
            this.pnlNavSep.TabIndex = 200;

            // ── TAB 1 — Estado de Resultados (ACTIVO por defecto) ─────────────
            this.pnlTab1.BackColor = System.Drawing.Color.FromArgb(238, 242, 255);
            this.pnlTab1.Controls.Add(this.btnEstadoResultados);
            this.pnlTab1.Controls.Add(this.pnlIndicator1);
            this.pnlTab1.Location = new System.Drawing.Point(0, 0);
            this.pnlTab1.Name = "pnlTab1";
            this.pnlTab1.Size = new System.Drawing.Size(215, 55);
            this.pnlTab1.TabIndex = 0;

            this.pnlIndicator1.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.pnlIndicator1.Location = new System.Drawing.Point(0, 52);
            this.pnlIndicator1.Name = "pnlIndicator1";
            this.pnlIndicator1.Size = new System.Drawing.Size(215, 3);
            this.pnlIndicator1.TabIndex = 1;

            this.btnEstadoResultados.BackColor = System.Drawing.Color.Transparent;
            this.btnEstadoResultados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstadoResultados.FlatAppearance.BorderSize = 0;
            this.btnEstadoResultados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(224, 230, 255);
            this.btnEstadoResultados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadoResultados.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEstadoResultados.ForeColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.btnEstadoResultados.Location = new System.Drawing.Point(0, 0);
            this.btnEstadoResultados.Name = "btnEstadoResultados";
            this.btnEstadoResultados.Size = new System.Drawing.Size(215, 52);
            this.btnEstadoResultados.TabIndex = 0;
            this.btnEstadoResultados.Text = "📈  Estado de Resultados";
            this.btnEstadoResultados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEstadoResultados.UseVisualStyleBackColor = false;
            this.btnEstadoResultados.Click += new System.EventHandler(this.BtnEstadoResultados_Click);

            // ── TAB 2 — Flujo de Caja ─────────────────────────────────────────
            this.pnlTab2.BackColor = System.Drawing.Color.White;
            this.pnlTab2.Controls.Add(this.btnFlujoCaja);
            this.pnlTab2.Controls.Add(this.pnlIndicator2);
            this.pnlTab2.Location = new System.Drawing.Point(215, 0);
            this.pnlTab2.Name = "pnlTab2";
            this.pnlTab2.Size = new System.Drawing.Size(175, 55);
            this.pnlTab2.TabIndex = 1;

            this.pnlIndicator2.BackColor = System.Drawing.Color.White;
            this.pnlIndicator2.Location = new System.Drawing.Point(0, 52);
            this.pnlIndicator2.Name = "pnlIndicator2";
            this.pnlIndicator2.Size = new System.Drawing.Size(175, 3);
            this.pnlIndicator2.TabIndex = 1;

            this.btnFlujoCaja.BackColor = System.Drawing.Color.Transparent;
            this.btnFlujoCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFlujoCaja.FlatAppearance.BorderSize = 0;
            this.btnFlujoCaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.btnFlujoCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlujoCaja.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnFlujoCaja.ForeColor = System.Drawing.Color.FromArgb(90, 100, 116);
            this.btnFlujoCaja.Location = new System.Drawing.Point(0, 0);
            this.btnFlujoCaja.Name = "btnFlujoCaja";
            this.btnFlujoCaja.Size = new System.Drawing.Size(175, 52);
            this.btnFlujoCaja.TabIndex = 0;
            this.btnFlujoCaja.Text = "💵  Flujo de Caja";
            this.btnFlujoCaja.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFlujoCaja.UseVisualStyleBackColor = false;
            this.btnFlujoCaja.Click += new System.EventHandler(this.BtnFlujoCaja_Click);

            // ── TAB 3 — Balance General ───────────────────────────────────────
            this.pnlTab3.BackColor = System.Drawing.Color.White;
            this.pnlTab3.Controls.Add(this.btnBalanceGeneral);
            this.pnlTab3.Controls.Add(this.pnlIndicator3);
            this.pnlTab3.Location = new System.Drawing.Point(390, 0);
            this.pnlTab3.Name = "pnlTab3";
            this.pnlTab3.Size = new System.Drawing.Size(180, 55);
            this.pnlTab3.TabIndex = 2;

            this.pnlIndicator3.BackColor = System.Drawing.Color.White;
            this.pnlIndicator3.Location = new System.Drawing.Point(0, 52);
            this.pnlIndicator3.Name = "pnlIndicator3";
            this.pnlIndicator3.Size = new System.Drawing.Size(180, 3);
            this.pnlIndicator3.TabIndex = 1;

            this.btnBalanceGeneral.BackColor = System.Drawing.Color.Transparent;
            this.btnBalanceGeneral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBalanceGeneral.FlatAppearance.BorderSize = 0;
            this.btnBalanceGeneral.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.btnBalanceGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBalanceGeneral.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBalanceGeneral.ForeColor = System.Drawing.Color.FromArgb(90, 100, 116);
            this.btnBalanceGeneral.Location = new System.Drawing.Point(0, 0);
            this.btnBalanceGeneral.Name = "btnBalanceGeneral";
            this.btnBalanceGeneral.Size = new System.Drawing.Size(180, 52);
            this.btnBalanceGeneral.TabIndex = 0;
            this.btnBalanceGeneral.Text = "📋  Balance General";
            this.btnBalanceGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBalanceGeneral.UseVisualStyleBackColor = false;
            this.btnBalanceGeneral.Click += new System.EventHandler(this.BtnBalanceGeneral_Click);

            // ── TAB 4 — Asientos Diario ───────────────────────────────────────
            this.pnlTab4.BackColor = System.Drawing.Color.White;
            this.pnlTab4.Controls.Add(this.btnAsientos);
            this.pnlTab4.Controls.Add(this.pnlIndicator4);
            this.pnlTab4.Location = new System.Drawing.Point(570, 0);
            this.pnlTab4.Name = "pnlTab4";
            this.pnlTab4.Size = new System.Drawing.Size(170, 55);
            this.pnlTab4.TabIndex = 3;

            this.pnlIndicator4.BackColor = System.Drawing.Color.White;
            this.pnlIndicator4.Location = new System.Drawing.Point(0, 52);
            this.pnlIndicator4.Name = "pnlIndicator4";
            this.pnlIndicator4.Size = new System.Drawing.Size(170, 3);
            this.pnlIndicator4.TabIndex = 1;

            this.btnAsientos.BackColor = System.Drawing.Color.Transparent;
            this.btnAsientos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsientos.FlatAppearance.BorderSize = 0;
            this.btnAsientos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.btnAsientos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsientos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnAsientos.ForeColor = System.Drawing.Color.FromArgb(90, 100, 116);
            this.btnAsientos.Location = new System.Drawing.Point(0, 0);
            this.btnAsientos.Name = "btnAsientos";
            this.btnAsientos.Size = new System.Drawing.Size(170, 52);
            this.btnAsientos.TabIndex = 0;
            this.btnAsientos.Text = "📓  Asientos Diario";
            this.btnAsientos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAsientos.UseVisualStyleBackColor = false;
            this.btnAsientos.Click += new System.EventHandler(this.BtnAsientos_Click);

            // ── TAB 5 — Períodos Contables ────────────────────────────────────
            this.pnlTab5.BackColor = System.Drawing.Color.White;
            this.pnlTab5.Controls.Add(this.btnPeriodos);
            this.pnlTab5.Controls.Add(this.pnlIndicator5);
            this.pnlTab5.Location = new System.Drawing.Point(740, 0);
            this.pnlTab5.Name = "pnlTab5";
            this.pnlTab5.Size = new System.Drawing.Size(190, 55);
            this.pnlTab5.TabIndex = 4;

            this.pnlIndicator5.BackColor = System.Drawing.Color.White;
            this.pnlIndicator5.Location = new System.Drawing.Point(0, 52);
            this.pnlIndicator5.Name = "pnlIndicator5";
            this.pnlIndicator5.Size = new System.Drawing.Size(190, 3);
            this.pnlIndicator5.TabIndex = 1;

            this.btnPeriodos.BackColor = System.Drawing.Color.Transparent;
            this.btnPeriodos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPeriodos.FlatAppearance.BorderSize = 0;
            this.btnPeriodos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.btnPeriodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPeriodos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnPeriodos.ForeColor = System.Drawing.Color.FromArgb(90, 100, 116);
            this.btnPeriodos.Location = new System.Drawing.Point(0, 0);
            this.btnPeriodos.Name = "btnPeriodos";
            this.btnPeriodos.Size = new System.Drawing.Size(190, 52);
            this.btnPeriodos.TabIndex = 0;
            this.btnPeriodos.Text = "📅  Períodos Contables";
            this.btnPeriodos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPeriodos.UseVisualStyleBackColor = false;
            this.btnPeriodos.Click += new System.EventHandler(this.BtnPeriodos_Click);

            // ══════════════════════════════════════════════════════════════════
            // panelContenidoContabilidad  (Dock=Fill)
            // ══════════════════════════════════════════════════════════════════
            this.panelContenidoContabilidad.BackColor = System.Drawing.Color.FromArgb(244, 246, 250);
            this.panelContenidoContabilidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenidoContabilidad.Name = "panelContenidoContabilidad";
            this.panelContenidoContabilidad.TabIndex = 2;

            // ══════════════════════════════════════════════════════════════════
            // FormContabilidad
            // ══════════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 250);
            this.ClientSize = new System.Drawing.Size(1466, 837);
            // Add order: Fill → Top (last = topmost en dock stack)
            this.Controls.Add(this.panelContenidoContabilidad);
            this.Controls.Add(this.pnlNav);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FormContabilidad";
            this.Text = "Contabilidad";

            // ── ResumeLayouts ─────────────────────────────────────────────────
            this.pnlTab1.ResumeLayout(false);
            this.pnlTab2.ResumeLayout(false);
            this.pnlTab3.ResumeLayout(false);
            this.pnlTab4.ResumeLayout(false);
            this.pnlTab5.ResumeLayout(false);
            this.pnlNav.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        // Header
        private System.Windows.Forms.Panel  pnlHeader;
        private System.Windows.Forms.Panel  pnlHeaderAccent;
        private System.Windows.Forms.Label  lblTitulo;
        private System.Windows.Forms.Label  lblSubtitulo;

        // Nav
        private System.Windows.Forms.Panel  pnlNav;
        private System.Windows.Forms.Panel  pnlNavSep;
        private System.Windows.Forms.Panel  pnlTab1;
        private System.Windows.Forms.Panel  pnlIndicator1;
        private System.Windows.Forms.Button btnEstadoResultados;
        private System.Windows.Forms.Panel  pnlTab2;
        private System.Windows.Forms.Panel  pnlIndicator2;
        private System.Windows.Forms.Button btnFlujoCaja;
        private System.Windows.Forms.Panel  pnlTab3;
        private System.Windows.Forms.Panel  pnlIndicator3;
        private System.Windows.Forms.Button btnBalanceGeneral;
        private System.Windows.Forms.Panel  pnlTab4;
        private System.Windows.Forms.Panel  pnlIndicator4;
        private System.Windows.Forms.Button btnAsientos;
        private System.Windows.Forms.Panel  pnlTab5;
        private System.Windows.Forms.Panel  pnlIndicator5;
        private System.Windows.Forms.Button btnPeriodos;

        // Content
        private System.Windows.Forms.Panel  panelContenidoContabilidad;
    }
}
