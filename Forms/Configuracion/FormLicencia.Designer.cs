namespace SistemaPOS.Forms.Configuracion
{
    partial class FormLicencia
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubHeader = new System.Windows.Forms.Label();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lblIconHeader = new System.Windows.Forms.Label();
            this.pnlHero = new System.Windows.Forms.Panel();
            this.pnlEstadoBadge = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlHeroTitle = new System.Windows.Forms.Panel();
            this.lblProductoNombre = new System.Windows.Forms.Label();
            this.pnlHeroIcon = new System.Windows.Forms.Panel();
            this.lblIconShield = new System.Windows.Forms.Label();
            this.pnlInfoRow = new System.Windows.Forms.Panel();
            this.tlpInfo = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCardVersion = new System.Windows.Forms.Panel();
            this.lblCardVerTit = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pnlCardVenc = new System.Windows.Forms.Panel();
            this.lblCardVencTit = new System.Windows.Forms.Label();
            this.lblVencimiento = new System.Windows.Forms.Label();
            this.pnlCardDias = new System.Windows.Forms.Panel();
            this.lblCardDiasTit = new System.Windows.Forms.Label();
            this.lblDiasRestantes = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.lblCodigoLicencia = new System.Windows.Forms.Label();
            this.txtCodigoLicencia = new System.Windows.Forms.TextBox();
            this.lblHintFormato = new System.Windows.Forms.Label();
            this.btnActivar = new System.Windows.Forms.Button();
            this.pnlFooterBar = new System.Windows.Forms.Panel();
            this.lblActualizacion = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlHero.SuspendLayout();
            this.pnlEstadoBadge.SuspendLayout();
            this.pnlHeroTitle.SuspendLayout();
            this.pnlHeroIcon.SuspendLayout();
            this.pnlInfoRow.SuspendLayout();
            this.tlpInfo.SuspendLayout();
            this.pnlCardVersion.SuspendLayout();
            this.pnlCardVenc.SuspendLayout();
            this.pnlCardDias.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.pnlFooterBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlHeader.Controls.Add(this.lblSubHeader);
            this.pnlHeader.Controls.Add(this.lblTituloHeader);
            this.pnlHeader.Controls.Add(this.lblIconHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1570, 64);
            this.pnlHeader.TabIndex = 4;
            // 
            // lblSubHeader
            // 
            this.lblSubHeader.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(185)))), ((int)(((byte)(205)))));
            this.lblSubHeader.Location = new System.Drawing.Point(60, 40);
            this.lblSubHeader.Name = "lblSubHeader";
            this.lblSubHeader.Size = new System.Drawing.Size(500, 16);
            this.lblSubHeader.TabIndex = 0;
            this.lblSubHeader.Text = "Gestione su licencia y verifique el estado de activación";
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(58, 10);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(500, 28);
            this.lblTituloHeader.TabIndex = 1;
            this.lblTituloHeader.Text = "Activación del Sistema";
            // 
            // lblIconHeader
            // 
            this.lblIconHeader.Font = new System.Drawing.Font("Segoe MDL2 Assets", 18F);
            this.lblIconHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(230)))));
            this.lblIconHeader.Location = new System.Drawing.Point(20, 16);
            this.lblIconHeader.Name = "lblIconHeader";
            this.lblIconHeader.Size = new System.Drawing.Size(30, 30);
            this.lblIconHeader.TabIndex = 2;
            this.lblIconHeader.Text = "";
            this.lblIconHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHero
            // 
            this.pnlHero.BackColor = System.Drawing.Color.White;
            this.pnlHero.Controls.Add(this.pnlEstadoBadge);
            this.pnlHero.Controls.Add(this.pnlHeroTitle);
            this.pnlHero.Controls.Add(this.pnlHeroIcon);
            this.pnlHero.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHero.Location = new System.Drawing.Point(0, 64);
            this.pnlHero.Name = "pnlHero";
            this.pnlHero.Size = new System.Drawing.Size(1570, 196);
            this.pnlHero.TabIndex = 3;
            // 
            // pnlEstadoBadge
            // 
            this.pnlEstadoBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.pnlEstadoBadge.Controls.Add(this.lblEstado);
            this.pnlEstadoBadge.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEstadoBadge.Location = new System.Drawing.Point(0, 150);
            this.pnlEstadoBadge.Name = "pnlEstadoBadge";
            this.pnlEstadoBadge.Size = new System.Drawing.Size(1570, 46);
            this.pnlEstadoBadge.TabIndex = 0;
            // 
            // lblEstado
            // 
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.White;
            this.lblEstado.Location = new System.Drawing.Point(0, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(1570, 46);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.Text = "SISTEMA NO ACTIVADO";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHeroTitle
            // 
            this.pnlHeroTitle.BackColor = System.Drawing.Color.White;
            this.pnlHeroTitle.Controls.Add(this.lblProductoNombre);
            this.pnlHeroTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeroTitle.Location = new System.Drawing.Point(0, 102);
            this.pnlHeroTitle.Name = "pnlHeroTitle";
            this.pnlHeroTitle.Size = new System.Drawing.Size(1570, 48);
            this.pnlHeroTitle.TabIndex = 1;
            // 
            // lblProductoNombre
            // 
            this.lblProductoNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductoNombre.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblProductoNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblProductoNombre.Location = new System.Drawing.Point(0, 0);
            this.lblProductoNombre.Name = "lblProductoNombre";
            this.lblProductoNombre.Size = new System.Drawing.Size(1570, 48);
            this.lblProductoNombre.TabIndex = 0;
            this.lblProductoNombre.Text = "SystemPOS";
            this.lblProductoNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHeroIcon
            // 
            this.pnlHeroIcon.BackColor = System.Drawing.Color.White;
            this.pnlHeroIcon.Controls.Add(this.lblIconShield);
            this.pnlHeroIcon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeroIcon.Location = new System.Drawing.Point(0, 0);
            this.pnlHeroIcon.Name = "pnlHeroIcon";
            this.pnlHeroIcon.Size = new System.Drawing.Size(1570, 102);
            this.pnlHeroIcon.TabIndex = 2;
            // 
            // lblIconShield
            // 
            this.lblIconShield.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconShield.Font = new System.Drawing.Font("Segoe MDL2 Assets", 46F);
            this.lblIconShield.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblIconShield.Location = new System.Drawing.Point(0, 0);
            this.lblIconShield.Name = "lblIconShield";
            this.lblIconShield.Size = new System.Drawing.Size(1570, 102);
            this.lblIconShield.TabIndex = 0;
            this.lblIconShield.Text = "";
            this.lblIconShield.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlInfoRow
            // 
            this.pnlInfoRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlInfoRow.Controls.Add(this.tlpInfo);
            this.pnlInfoRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfoRow.Location = new System.Drawing.Point(0, 260);
            this.pnlInfoRow.Name = "pnlInfoRow";
            this.pnlInfoRow.Size = new System.Drawing.Size(1570, 106);
            this.pnlInfoRow.TabIndex = 2;
            // 
            // tlpInfo
            // 
            this.tlpInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.tlpInfo.ColumnCount = 3;
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpInfo.Controls.Add(this.pnlCardVersion, 0, 0);
            this.tlpInfo.Controls.Add(this.pnlCardVenc, 1, 0);
            this.tlpInfo.Controls.Add(this.pnlCardDias, 2, 0);
            this.tlpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInfo.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlpInfo.Location = new System.Drawing.Point(0, 0);
            this.tlpInfo.Name = "tlpInfo";
            this.tlpInfo.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.tlpInfo.RowCount = 1;
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInfo.Size = new System.Drawing.Size(1570, 106);
            this.tlpInfo.TabIndex = 0;
            // 
            // pnlCardVersion
            // 
            this.pnlCardVersion.BackColor = System.Drawing.Color.White;
            this.pnlCardVersion.Controls.Add(this.lblCardVerTit);
            this.pnlCardVersion.Controls.Add(this.lblVersion);
            this.pnlCardVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardVersion.Location = new System.Drawing.Point(16, 10);
            this.pnlCardVersion.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlCardVersion.Name = "pnlCardVersion";
            this.pnlCardVersion.Size = new System.Drawing.Size(506, 86);
            this.pnlCardVersion.TabIndex = 0;
            // 
            // lblCardVerTit
            // 
            this.lblCardVerTit.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblCardVerTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(140)))), ((int)(((byte)(155)))));
            this.lblCardVerTit.Location = new System.Drawing.Point(14, 10);
            this.lblCardVerTit.Name = "lblCardVerTit";
            this.lblCardVerTit.Size = new System.Drawing.Size(200, 14);
            this.lblCardVerTit.TabIndex = 0;
            this.lblCardVerTit.Text = "VERSIÓN";
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblVersion.Location = new System.Drawing.Point(12, 28);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(220, 34);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "1.0.0";
            // 
            // pnlCardVenc
            // 
            this.pnlCardVenc.BackColor = System.Drawing.Color.White;
            this.pnlCardVenc.Controls.Add(this.lblCardVencTit);
            this.pnlCardVenc.Controls.Add(this.lblVencimiento);
            this.pnlCardVenc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardVenc.Location = new System.Drawing.Point(534, 10);
            this.pnlCardVenc.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.pnlCardVenc.Name = "pnlCardVenc";
            this.pnlCardVenc.Size = new System.Drawing.Size(500, 86);
            this.pnlCardVenc.TabIndex = 1;
            // 
            // lblCardVencTit
            // 
            this.lblCardVencTit.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblCardVencTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(140)))), ((int)(((byte)(155)))));
            this.lblCardVencTit.Location = new System.Drawing.Point(14, 10);
            this.lblCardVencTit.Name = "lblCardVencTit";
            this.lblCardVencTit.Size = new System.Drawing.Size(200, 14);
            this.lblCardVencTit.TabIndex = 0;
            this.lblCardVencTit.Text = "VENCIMIENTO";
            // 
            // lblVencimiento
            // 
            this.lblVencimiento.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblVencimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblVencimiento.Location = new System.Drawing.Point(12, 28);
            this.lblVencimiento.Name = "lblVencimiento";
            this.lblVencimiento.Size = new System.Drawing.Size(220, 34);
            this.lblVencimiento.TabIndex = 1;
            this.lblVencimiento.Text = "--/--/----";
            // 
            // pnlCardDias
            // 
            this.pnlCardDias.BackColor = System.Drawing.Color.White;
            this.pnlCardDias.Controls.Add(this.lblCardDiasTit);
            this.pnlCardDias.Controls.Add(this.lblDiasRestantes);
            this.pnlCardDias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardDias.Location = new System.Drawing.Point(1046, 10);
            this.pnlCardDias.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.pnlCardDias.Name = "pnlCardDias";
            this.pnlCardDias.Size = new System.Drawing.Size(508, 86);
            this.pnlCardDias.TabIndex = 2;
            // 
            // lblCardDiasTit
            // 
            this.lblCardDiasTit.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblCardDiasTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(140)))), ((int)(((byte)(155)))));
            this.lblCardDiasTit.Location = new System.Drawing.Point(14, 10);
            this.lblCardDiasTit.Name = "lblCardDiasTit";
            this.lblCardDiasTit.Size = new System.Drawing.Size(200, 14);
            this.lblCardDiasTit.TabIndex = 0;
            this.lblCardDiasTit.Text = "DÍAS RESTANTES";
            // 
            // lblDiasRestantes
            // 
            this.lblDiasRestantes.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblDiasRestantes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblDiasRestantes.Location = new System.Drawing.Point(12, 28);
            this.lblDiasRestantes.Name = "lblDiasRestantes";
            this.lblDiasRestantes.Size = new System.Drawing.Size(220, 34);
            this.lblDiasRestantes.TabIndex = 1;
            this.lblDiasRestantes.Text = "--";
            // 
            // pnlInput
            // 
            this.pnlInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInput.BackColor = System.Drawing.Color.White;
            this.pnlInput.Controls.Add(this.lblCodigoLicencia);
            this.pnlInput.Controls.Add(this.txtCodigoLicencia);
            this.pnlInput.Controls.Add(this.lblHintFormato);
            this.pnlInput.Controls.Add(this.btnActivar);
            this.pnlInput.Location = new System.Drawing.Point(12, 384);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(1546, 347);
            this.pnlInput.TabIndex = 0;
            // 
            // lblCodigoLicencia
            // 
            this.lblCodigoLicencia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCodigoLicencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(85)))));
            this.lblCodigoLicencia.Location = new System.Drawing.Point(32, 22);
            this.lblCodigoLicencia.Name = "lblCodigoLicencia";
            this.lblCodigoLicencia.Size = new System.Drawing.Size(400, 20);
            this.lblCodigoLicencia.TabIndex = 0;
            this.lblCodigoLicencia.Text = "Código de Licencia";
            // 
            // txtCodigoLicencia
            // 
            this.txtCodigoLicencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigoLicencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtCodigoLicencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoLicencia.Font = new System.Drawing.Font("Courier New", 17F, System.Drawing.FontStyle.Bold);
            this.txtCodigoLicencia.Location = new System.Drawing.Point(32, 45);
            this.txtCodigoLicencia.Name = "txtCodigoLicencia";
            this.txtCodigoLicencia.Size = new System.Drawing.Size(1482, 33);
            this.txtCodigoLicencia.TabIndex = 1;
            this.txtCodigoLicencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblHintFormato
            // 
            this.lblHintFormato.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblHintFormato.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(185)))));
            this.lblHintFormato.Location = new System.Drawing.Point(34, 90);
            this.lblHintFormato.Name = "lblHintFormato";
            this.lblHintFormato.Size = new System.Drawing.Size(600, 16);
            this.lblHintFormato.TabIndex = 2;
            this.lblHintFormato.Text = "Formato: XXXX-XXXX-XXXX-XXXX   (letras y números, sin espacios)";
            // 
            // btnActivar
            // 
            this.btnActivar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActivar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnActivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivar.FlatAppearance.BorderSize = 0;
            this.btnActivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnActivar.ForeColor = System.Drawing.Color.White;
            this.btnActivar.Location = new System.Drawing.Point(32, 109);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(1482, 54);
            this.btnActivar.TabIndex = 3;
            this.btnActivar.Text = "Activar Licencia";
            this.btnActivar.UseVisualStyleBackColor = false;
            // 
            // pnlFooterBar
            // 
            this.pnlFooterBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlFooterBar.Controls.Add(this.lblActualizacion);
            this.pnlFooterBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterBar.Location = new System.Drawing.Point(0, 747);
            this.pnlFooterBar.Name = "pnlFooterBar";
            this.pnlFooterBar.Size = new System.Drawing.Size(1570, 44);
            this.pnlFooterBar.TabIndex = 1;
            // 
            // lblActualizacion
            // 
            this.lblActualizacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActualizacion.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblActualizacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblActualizacion.Location = new System.Drawing.Point(0, 0);
            this.lblActualizacion.Name = "lblActualizacion";
            this.lblActualizacion.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.lblActualizacion.Size = new System.Drawing.Size(1570, 44);
            this.lblActualizacion.TabIndex = 0;
            this.lblActualizacion.Text = "Última actualización: --/--/----";
            this.lblActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormLicencia
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1570, 791);
            this.Controls.Add(this.pnlInput);
            this.Controls.Add(this.pnlFooterBar);
            this.Controls.Add(this.pnlInfoRow);
            this.Controls.Add(this.pnlHero);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(700, 560);
            this.Name = "FormLicencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Activación del Sistema";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHero.ResumeLayout(false);
            this.pnlEstadoBadge.ResumeLayout(false);
            this.pnlHeroTitle.ResumeLayout(false);
            this.pnlHeroIcon.ResumeLayout(false);
            this.pnlInfoRow.ResumeLayout(false);
            this.tlpInfo.ResumeLayout(false);
            this.pnlCardVersion.ResumeLayout(false);
            this.pnlCardVenc.ResumeLayout(false);
            this.pnlCardDias.ResumeLayout(false);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.pnlFooterBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel         pnlHeader;
        private System.Windows.Forms.Label         lblIconHeader;
        private System.Windows.Forms.Label         lblTituloHeader;
        private System.Windows.Forms.Label         lblSubHeader;
        private System.Windows.Forms.Panel         pnlHero;
        private System.Windows.Forms.Panel         pnlHeroIcon;
        private System.Windows.Forms.Label         lblIconShield;
        private System.Windows.Forms.Panel         pnlHeroTitle;
        private System.Windows.Forms.Label         lblProductoNombre;
        private System.Windows.Forms.Panel         pnlEstadoBadge;
        private System.Windows.Forms.Label         lblEstado;
        private System.Windows.Forms.Panel         pnlInfoRow;
        private System.Windows.Forms.TableLayoutPanel tlpInfo;
        private System.Windows.Forms.Panel         pnlCardVersion;
        private System.Windows.Forms.Label         lblCardVerTit;
        private System.Windows.Forms.Label         lblVersion;
        private System.Windows.Forms.Panel         pnlCardVenc;
        private System.Windows.Forms.Label         lblCardVencTit;
        private System.Windows.Forms.Label         lblVencimiento;
        private System.Windows.Forms.Panel         pnlCardDias;
        private System.Windows.Forms.Label         lblCardDiasTit;
        private System.Windows.Forms.Label         lblDiasRestantes;
        private System.Windows.Forms.Panel         pnlInput;
        private System.Windows.Forms.Label         lblCodigoLicencia;
        private System.Windows.Forms.TextBox       txtCodigoLicencia;
        private System.Windows.Forms.Label         lblHintFormato;
        private System.Windows.Forms.Button        btnActivar;
        private System.Windows.Forms.Panel         pnlFooterBar;
        private System.Windows.Forms.Label         lblActualizacion;
    }
}
