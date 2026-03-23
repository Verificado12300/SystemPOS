namespace SistemaPOS.Controls
{
    partial class TicketPreviewControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvItems               = new System.Windows.Forms.DataGridView();
            this.lblUnidad              = new System.Windows.Forms.Label();
            this.pbQR                   = new System.Windows.Forms.PictureBox();
            this.label37                = new System.Windows.Forms.Label();
            this.lblCantidad            = new System.Windows.Forms.Label();
            this.lblPiePagina           = new System.Windows.Forms.Label();
            this.label35                = new System.Windows.Forms.Label();
            this.label33                = new System.Windows.Forms.Label();
            this.lblVueltoCantidad      = new System.Windows.Forms.Label();
            this.label31                = new System.Windows.Forms.Label();
            this.lblRecibidoCantidad    = new System.Windows.Forms.Label();
            this.lblMetodoPago          = new System.Windows.Forms.Label();
            this.lblMetodoPagoSeleccion = new System.Windows.Forms.Label();
            this.lblTotal               = new System.Windows.Forms.Label();
            this.lblTotalCantidad       = new System.Windows.Forms.Label();
            this.lblIGV                 = new System.Windows.Forms.Label();
            this.lblIGVCantidad         = new System.Windows.Forms.Label();
            this.lblSubTotal            = new System.Windows.Forms.Label();
            this.lblSubTotalCantidad    = new System.Windows.Forms.Label();
            this.label22                = new System.Windows.Forms.Label();
            this.label11                = new System.Windows.Forms.Label();
            this.pnlLineaDivisora       = new System.Windows.Forms.Panel();
            this.lblCosto               = new System.Windows.Forms.Label();
            this.lblDescripcion         = new System.Windows.Forms.Label();
            this.lblDNI                 = new System.Windows.Forms.Label();
            this.lblCliente             = new System.Windows.Forms.Label();
            this.lblFecha               = new System.Windows.Forms.Label();
            this.lblnumSerie            = new System.Windows.Forms.Label();
            this.lblComprobante         = new System.Windows.Forms.Label();
            this.label3                 = new System.Windows.Forms.Label();
            this.lblEmail               = new System.Windows.Forms.Label();
            this.lblTelfono             = new System.Windows.Forms.Label();
            this.lblDireccion           = new System.Windows.Forms.Label();
            this.pbLogo                 = new System.Windows.Forms.PictureBox();
            this.lblRuc                 = new System.Windows.Forms.Label();
            this.lblNombreNegocio       = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            //
            // dgvItems
            //
            this.dgvItems.AllowUserToAddRows          = false;
            this.dgvItems.AllowUserToDeleteRows       = false;
            this.dgvItems.AllowUserToResizeColumns    = false;
            this.dgvItems.AllowUserToResizeRows       = false;
            this.dgvItems.BackgroundColor             = System.Drawing.Color.White;
            this.dgvItems.BorderStyle                 = System.Windows.Forms.BorderStyle.None;
            this.dgvItems.CellBorderStyle             = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvItems.ColumnHeadersBorderStyle    = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.ColumnHeadersVisible        = false;
            this.dgvItems.GridColor                   = System.Drawing.Color.White;
            this.dgvItems.Location                    = new System.Drawing.Point(14, 340);
            this.dgvItems.Name                        = "dgvItems";
            this.dgvItems.ReadOnly                    = true;
            this.dgvItems.RowHeadersVisible           = false;
            this.dgvItems.RowHeadersWidth             = 51;
            this.dgvItems.ScrollBars                  = System.Windows.Forms.ScrollBars.None;
            this.dgvItems.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size                        = new System.Drawing.Size(257, 56);
            this.dgvItems.TabIndex                    = 120;
            this.dgvItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvItems_CellFormatting);
            //
            // lblUnidad
            //
            this.lblUnidad.AutoSize  = true;
            this.lblUnidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUnidad.Font      = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblUnidad.Location  = new System.Drawing.Point(136, 316);
            this.lblUnidad.Name      = "lblUnidad";
            this.lblUnidad.TabIndex  = 106;
            this.lblUnidad.Text      = "Unid.";
            //
            // pbQR
            //
            this.pbQR.Location = new System.Drawing.Point(97, 584);
            this.pbQR.Name     = "pbQR";
            this.pbQR.Size     = new System.Drawing.Size(100, 100);
            this.pbQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbQR.TabIndex = 105;
            this.pbQR.TabStop  = false;
            //
            // label37  (separador pie)
            //
            this.label37.AutoSize  = true;
            this.label37.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label37.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.label37.Location  = new System.Drawing.Point(13, 546);
            this.label37.Name      = "label37";
            this.label37.TabIndex  = 104;
            this.label37.Text      = "---------------------------------------------------";
            //
            // lblCantidad  (encabezado columna)
            //
            this.lblCantidad.AutoSize  = true;
            this.lblCantidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCantidad.Font      = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblCantidad.Location  = new System.Drawing.Point(158, 316);
            this.lblCantidad.Name      = "lblCantidad";
            this.lblCantidad.TabIndex  = 78;
            this.lblCantidad.Text      = "Cant.";
            //
            // lblPiePagina
            //
            this.lblPiePagina.AutoSize  = true;
            this.lblPiePagina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPiePagina.Font      = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblPiePagina.Location  = new System.Drawing.Point(59, 561);
            this.lblPiePagina.Name      = "lblPiePagina";
            this.lblPiePagina.TabIndex  = 103;
            this.lblPiePagina.Text      = "¡Gracias por su Compra!";
            //
            // label35  (separador info pago)
            //
            this.label35.AutoSize  = true;
            this.label35.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label35.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.label35.Location  = new System.Drawing.Point(13, 475);
            this.label35.Name      = "label35";
            this.label35.TabIndex  = 102;
            this.label35.Text      = "---------------------------------------------------";
            //
            // label33  (vuelto label)
            //
            this.label33.AutoSize  = true;
            this.label33.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label33.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.label33.Location  = new System.Drawing.Point(12, 531);
            this.label33.Name      = "label33";
            this.label33.TabIndex  = 101;
            this.label33.Text      = "Vuelto:";
            //
            // lblVueltoCantidad
            //
            this.lblVueltoCantidad.AutoSize  = false;
            this.lblVueltoCantidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblVueltoCantidad.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVueltoCantidad.Location  = new System.Drawing.Point(189, 531);
            this.lblVueltoCantidad.Name      = "lblVueltoCantidad";
            this.lblVueltoCantidad.Size      = new System.Drawing.Size(82, 15);
            this.lblVueltoCantidad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblVueltoCantidad.TabIndex  = 100;
            //
            // label31  (recibido label)
            //
            this.label31.AutoSize  = true;
            this.label31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label31.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.label31.Location  = new System.Drawing.Point(12, 510);
            this.label31.Name      = "label31";
            this.label31.TabIndex  = 99;
            this.label31.Text      = "Recibido:";
            //
            // lblRecibidoCantidad
            //
            this.lblRecibidoCantidad.AutoSize  = false;
            this.lblRecibidoCantidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRecibidoCantidad.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRecibidoCantidad.Location  = new System.Drawing.Point(189, 510);
            this.lblRecibidoCantidad.Name      = "lblRecibidoCantidad";
            this.lblRecibidoCantidad.Size      = new System.Drawing.Size(82, 15);
            this.lblRecibidoCantidad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblRecibidoCantidad.TabIndex  = 98;
            //
            // lblMetodoPago
            //
            this.lblMetodoPago.AutoSize  = true;
            this.lblMetodoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMetodoPago.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMetodoPago.Location  = new System.Drawing.Point(12, 489);
            this.lblMetodoPago.Name      = "lblMetodoPago";
            this.lblMetodoPago.TabIndex  = 97;
            this.lblMetodoPago.Text      = "Método de Pago:";
            //
            // lblMetodoPagoSeleccion
            //
            this.lblMetodoPagoSeleccion.AutoSize  = false;
            this.lblMetodoPagoSeleccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMetodoPagoSeleccion.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMetodoPagoSeleccion.Location  = new System.Drawing.Point(189, 489);
            this.lblMetodoPagoSeleccion.Name      = "lblMetodoPagoSeleccion";
            this.lblMetodoPagoSeleccion.Size      = new System.Drawing.Size(82, 15);
            this.lblMetodoPagoSeleccion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblMetodoPagoSeleccion.TabIndex  = 96;
            //
            // lblTotal
            //
            this.lblTotal.AutoSize  = true;
            this.lblTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotal.Font      = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location  = new System.Drawing.Point(12, 456);
            this.lblTotal.Name      = "lblTotal";
            this.lblTotal.TabIndex  = 95;
            this.lblTotal.Text      = "TOTAL:";
            //
            // lblTotalCantidad
            //
            this.lblTotalCantidad.AutoSize  = false;
            this.lblTotalCantidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalCantidad.Font      = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalCantidad.Location  = new System.Drawing.Point(185, 456);
            this.lblTotalCantidad.Name      = "lblTotalCantidad";
            this.lblTotalCantidad.Size      = new System.Drawing.Size(86, 20);
            this.lblTotalCantidad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblTotalCantidad.TabIndex  = 94;
            //
            // lblIGV
            //
            this.lblIGV.AutoSize  = true;
            this.lblIGV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblIGV.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIGV.Location  = new System.Drawing.Point(12, 437);
            this.lblIGV.Name      = "lblIGV";
            this.lblIGV.TabIndex  = 93;
            this.lblIGV.Text      = "IGV (18%):";
            //
            // lblIGVCantidad
            //
            this.lblIGVCantidad.AutoSize  = false;
            this.lblIGVCantidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblIGVCantidad.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIGVCantidad.Location  = new System.Drawing.Point(189, 437);
            this.lblIGVCantidad.Name      = "lblIGVCantidad";
            this.lblIGVCantidad.Size      = new System.Drawing.Size(82, 15);
            this.lblIGVCantidad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblIGVCantidad.TabIndex  = 92;
            //
            // lblSubTotal
            //
            this.lblSubTotal.AutoSize  = true;
            this.lblSubTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubTotal.Font      = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubTotal.Location  = new System.Drawing.Point(12, 418);
            this.lblSubTotal.Name      = "lblSubTotal";
            this.lblSubTotal.TabIndex  = 90;
            this.lblSubTotal.Text      = "SUBTOTAL:";
            //
            // lblSubTotalCantidad
            //
            this.lblSubTotalCantidad.AutoSize  = false;
            this.lblSubTotalCantidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubTotalCantidad.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTotalCantidad.Location  = new System.Drawing.Point(189, 418);
            this.lblSubTotalCantidad.Name      = "lblSubTotalCantidad";
            this.lblSubTotalCantidad.Size      = new System.Drawing.Size(82, 15);
            this.lblSubTotalCantidad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblSubTotalCantidad.TabIndex  = 87;
            //
            // label22  (separador sub DGV)
            //
            this.label22.AutoSize  = true;
            this.label22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label22.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.label22.Location  = new System.Drawing.Point(13, 399);
            this.label22.Name      = "label22";
            this.label22.TabIndex  = 86;
            this.label22.Text      = "---------------------------------------------------";
            //
            // label11  (separador encabezado detalle)
            //
            this.label11.AutoSize  = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.label11.Location  = new System.Drawing.Point(13, 303);
            this.label11.Name      = "label11";
            this.label11.TabIndex  = 85;
            this.label11.Text      = "---------------------------------------------------";
            //
            // pnlLineaDivisora
            //
            this.pnlLineaDivisora.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlLineaDivisora.Location  = new System.Drawing.Point(14, 333);
            this.pnlLineaDivisora.Name      = "pnlLineaDivisora";
            this.pnlLineaDivisora.Size      = new System.Drawing.Size(257, 1);
            this.pnlLineaDivisora.TabIndex  = 81;
            //
            // lblCosto  (encabezado columna Total)
            //
            this.lblCosto.AutoSize  = true;
            this.lblCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCosto.Font      = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblCosto.Location  = new System.Drawing.Point(196, 316);
            this.lblCosto.Name      = "lblCosto";
            this.lblCosto.TabIndex  = 76;
            this.lblCosto.Text      = "Total";
            //
            // lblDescripcion  (encabezado columna)
            //
            this.lblDescripcion.AutoSize  = true;
            this.lblDescripcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDescripcion.Font      = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblDescripcion.Location  = new System.Drawing.Point(14, 316);
            this.lblDescripcion.Name      = "lblDescripcion";
            this.lblDescripcion.TabIndex  = 75;
            this.lblDescripcion.Text      = "Descripción";
            //
            // lblDNI
            //
            this.lblDNI.AutoSize  = true;
            this.lblDNI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDNI.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDNI.Location  = new System.Drawing.Point(12, 289);
            this.lblDNI.Name      = "lblDNI";
            this.lblDNI.TabIndex  = 74;
            this.lblDNI.Text      = "DNI               :    12345678";
            //
            // lblCliente
            //
            this.lblCliente.AutoSize  = true;
            this.lblCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCliente.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCliente.Location  = new System.Drawing.Point(12, 273);
            this.lblCliente.Name      = "lblCliente";
            this.lblCliente.TabIndex  = 72;
            this.lblCliente.Text      = "Cliente         :    —";
            //
            // lblFecha
            //
            this.lblFecha.AutoSize  = true;
            this.lblFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFecha.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFecha.Location  = new System.Drawing.Point(12, 258);
            this.lblFecha.Name      = "lblFecha";
            this.lblFecha.TabIndex  = 71;
            this.lblFecha.Text      = "Fecha           :    —";
            //
            // lblnumSerie
            //
            this.lblnumSerie.AutoSize  = false;
            this.lblnumSerie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblnumSerie.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblnumSerie.Location  = new System.Drawing.Point(12, 237);
            this.lblnumSerie.Name      = "lblnumSerie";
            this.lblnumSerie.Size      = new System.Drawing.Size(264, 15);
            this.lblnumSerie.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblnumSerie.TabIndex  = 70;
            //
            // lblComprobante
            //
            this.lblComprobante.AutoSize  = false;
            this.lblComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblComprobante.Font      = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblComprobante.Location  = new System.Drawing.Point(12, 217);
            this.lblComprobante.Name      = "lblComprobante";
            this.lblComprobante.Size      = new System.Drawing.Size(264, 20);
            this.lblComprobante.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblComprobante.TabIndex  = 69;
            this.lblComprobante.Text      = "NOTA DE VENTA";
            //
            // label3  (separador encabezado empresa)
            //
            this.label3.AutoSize  = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location  = new System.Drawing.Point(12, 206);
            this.label3.Name      = "label3";
            this.label3.TabIndex  = 68;
            this.label3.Text      = "---------------------------------------------------";
            //
            // lblEmail
            //
            this.lblEmail.AutoSize  = false;
            this.lblEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblEmail.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmail.Location  = new System.Drawing.Point(12, 192);
            this.lblEmail.Name      = "lblEmail";
            this.lblEmail.Size      = new System.Drawing.Size(264, 15);
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblEmail.TabIndex  = 113;
            //
            // lblTelfono
            //
            this.lblTelfono.AutoSize  = false;
            this.lblTelfono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTelfono.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTelfono.Location  = new System.Drawing.Point(12, 176);
            this.lblTelfono.Name      = "lblTelfono";
            this.lblTelfono.Size      = new System.Drawing.Size(264, 15);
            this.lblTelfono.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTelfono.TabIndex  = 67;
            //
            // lblDireccion
            //
            this.lblDireccion.AutoSize  = false;
            this.lblDireccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDireccion.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDireccion.Location  = new System.Drawing.Point(12, 160);
            this.lblDireccion.Name      = "lblDireccion";
            this.lblDireccion.Size      = new System.Drawing.Size(264, 15);
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblDireccion.TabIndex  = 66;
            //
            // pbLogo
            //
            this.pbLogo.Location = new System.Drawing.Point(69, 13);
            this.pbLogo.Name     = "pbLogo";
            this.pbLogo.Size     = new System.Drawing.Size(150, 90);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 65;
            this.pbLogo.TabStop  = false;
            //
            // lblRuc
            //
            this.lblRuc.AutoSize  = false;
            this.lblRuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRuc.Font      = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblRuc.Location  = new System.Drawing.Point(12, 133);
            this.lblRuc.Name      = "lblRuc";
            this.lblRuc.Size      = new System.Drawing.Size(264, 17);
            this.lblRuc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblRuc.TabIndex  = 64;
            //
            // lblNombreNegocio
            //
            this.lblNombreNegocio.AutoSize  = false;
            this.lblNombreNegocio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNombreNegocio.Font      = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblNombreNegocio.Location  = new System.Drawing.Point(12, 111);
            this.lblNombreNegocio.Name      = "lblNombreNegocio";
            this.lblNombreNegocio.Size      = new System.Drawing.Size(264, 20);
            this.lblNombreNegocio.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblNombreNegocio.TabIndex  = 47;
            //
            // TicketPreviewControl  (plantilla maestra única)
            //
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.lblUnidad);
            this.Controls.Add(this.pbQR);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblPiePagina);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.lblVueltoCantidad);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.lblRecibidoCantidad);
            this.Controls.Add(this.lblMetodoPago);
            this.Controls.Add(this.lblMetodoPagoSeleccion);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalCantidad);
            this.Controls.Add(this.lblIGV);
            this.Controls.Add(this.lblIGVCantidad);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.lblSubTotalCantidad);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pnlLineaDivisora);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblnumSerie);
            this.Controls.Add(this.lblComprobante);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblTelfono);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.lblRuc);
            this.Controls.Add(this.lblNombreNegocio);
            this.Name = "TicketPreviewControl";
            this.Size = new System.Drawing.Size(288, 697);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Label        lblUnidad;
        private System.Windows.Forms.PictureBox   pbQR;
        private System.Windows.Forms.Label        label37;
        private System.Windows.Forms.Label        lblCantidad;
        private System.Windows.Forms.Label        lblPiePagina;
        private System.Windows.Forms.Label        label35;
        private System.Windows.Forms.Label        label33;
        private System.Windows.Forms.Label        lblVueltoCantidad;
        private System.Windows.Forms.Label        label31;
        private System.Windows.Forms.Label        lblRecibidoCantidad;
        private System.Windows.Forms.Label        lblMetodoPago;
        private System.Windows.Forms.Label        lblMetodoPagoSeleccion;
        private System.Windows.Forms.Label        lblTotal;
        private System.Windows.Forms.Label        lblTotalCantidad;
        private System.Windows.Forms.Label        lblIGV;
        private System.Windows.Forms.Label        lblIGVCantidad;
        private System.Windows.Forms.Label        lblSubTotal;
        private System.Windows.Forms.Label        lblSubTotalCantidad;
        private System.Windows.Forms.Label        label22;
        private System.Windows.Forms.Label        label11;
        private System.Windows.Forms.Panel        pnlLineaDivisora;
        private System.Windows.Forms.Label        lblCosto;
        private System.Windows.Forms.Label        lblDescripcion;
        private System.Windows.Forms.Label        lblDNI;
        private System.Windows.Forms.Label        lblCliente;
        private System.Windows.Forms.Label        lblFecha;
        private System.Windows.Forms.Label        lblnumSerie;
        private System.Windows.Forms.Label        lblComprobante;
        private System.Windows.Forms.Label        label3;
        private System.Windows.Forms.Label        lblEmail;
        private System.Windows.Forms.Label        lblTelfono;
        private System.Windows.Forms.Label        lblDireccion;
        private System.Windows.Forms.PictureBox   pbLogo;
        private System.Windows.Forms.Label        lblRuc;
        private System.Windows.Forms.Label        lblNombreNegocio;
    }
}
