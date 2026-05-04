namespace SistemaPOS.Forms.Configuracion
{
    partial class FormLimpiarSistema
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
            this.pnlAccent = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlWarn = new System.Windows.Forms.Panel();
            this.lblWarn = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.pnlChecks = new System.Windows.Forms.Panel();
            this.chkVentas = new System.Windows.Forms.CheckBox();
            this.chkCompras = new System.Windows.Forms.CheckBox();
            this.chkGastos = new System.Windows.Forms.CheckBox();
            this.chkCaja = new System.Windows.Forms.CheckBox();
            this.chkContabilidad = new System.Windows.Forms.CheckBox();
            this.chkConfiguraciones = new System.Windows.Forms.CheckBox();
            this.chkCxC = new System.Windows.Forms.CheckBox();
            this.chkCxP = new System.Windows.Forms.CheckBox();
            this.chkProductos = new System.Windows.Forms.CheckBox();
            this.chkClientes = new System.Windows.Forms.CheckBox();
            this.chkProveedores = new System.Windows.Forms.CheckBox();
            this.lblNota = new System.Windows.Forms.Label();
            this.btnSelTodo = new System.Windows.Forms.Button();
            this.btnDesel = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlWarn.SuspendLayout();
            this.pnlChecks.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
            this.pnlHeader.Controls.Add(this.lblSub);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.pnlAccent);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(960, 80);
            this.pnlHeader.TabIndex = 0;
            //
            // pnlAccent
            //
            this.pnlAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.pnlAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAccent.Location = new System.Drawing.Point(0, 0);
            this.pnlAccent.Name = "pnlAccent";
            this.pnlAccent.Size = new System.Drawing.Size(5, 80);
            this.pnlAccent.TabIndex = 0;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(22, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(560, 36);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "⚠   Limpiar Sistema";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblSub
            //
            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.lblSub.Location = new System.Drawing.Point(24, 52);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(200, 15);
            this.lblSub.TabIndex = 2;
            this.lblSub.Text = "Elimina datos de prueba o históricos. Los Usuarios nunca se eliminan.";
            //
            // pnlContent
            //
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlContent.Controls.Add(this.btnCerrar);
            this.pnlContent.Controls.Add(this.btnLimpiar);
            this.pnlContent.Controls.Add(this.btnDesel);
            this.pnlContent.Controls.Add(this.btnSelTodo);
            this.pnlContent.Controls.Add(this.pnlChecks);
            this.pnlContent.Controls.Add(this.lblSec);
            this.pnlContent.Controls.Add(this.pnlWarn);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(960, 500);
            this.pnlContent.TabIndex = 1;
            //
            // pnlWarn
            //
            this.pnlWarn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(205)))));
            this.pnlWarn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWarn.Controls.Add(this.lblWarn);
            this.pnlWarn.Location = new System.Drawing.Point(30, 22);
            this.pnlWarn.Name = "pnlWarn";
            this.pnlWarn.Size = new System.Drawing.Size(900, 58);
            this.pnlWarn.TabIndex = 0;
            //
            // lblWarn
            //
            this.lblWarn.AutoSize = false;
            this.lblWarn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblWarn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(70)))), ((int)(((byte)(0)))));
            this.lblWarn.Location = new System.Drawing.Point(10, 8);
            this.lblWarn.Name = "lblWarn";
            this.lblWarn.Size = new System.Drawing.Size(875, 42);
            this.lblWarn.TabIndex = 0;
            this.lblWarn.Text = "⚠  ADVERTENCIA: Esta acción elimina datos de forma permanente e IRREVERSIBLE.\r\n" +
                                "     Haga un respaldo antes de continuar. Usuarios, roles y ajustes del sistema NO se eliminan.";
            //
            // lblSec
            //
            this.lblSec.AutoSize = true;
            this.lblSec.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
            this.lblSec.Location = new System.Drawing.Point(30, 100);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(210, 19);
            this.lblSec.TabIndex = 1;
            this.lblSec.Text = "Seleccione los módulos a limpiar:";
            //
            // pnlChecks
            //
            this.pnlChecks.BackColor = System.Drawing.Color.White;
            this.pnlChecks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChecks.Controls.Add(this.lblNota);
            this.pnlChecks.Controls.Add(this.chkProveedores);
            this.pnlChecks.Controls.Add(this.chkClientes);
            this.pnlChecks.Controls.Add(this.chkProductos);
            this.pnlChecks.Controls.Add(this.chkCxP);
            this.pnlChecks.Controls.Add(this.chkCxC);
            this.pnlChecks.Controls.Add(this.chkConfiguraciones);
            this.pnlChecks.Controls.Add(this.chkContabilidad);
            this.pnlChecks.Controls.Add(this.chkCaja);
            this.pnlChecks.Controls.Add(this.chkGastos);
            this.pnlChecks.Controls.Add(this.chkCompras);
            this.pnlChecks.Controls.Add(this.chkVentas);
            this.pnlChecks.Location = new System.Drawing.Point(30, 128);
            this.pnlChecks.Name = "pnlChecks";
            this.pnlChecks.Size = new System.Drawing.Size(900, 276);
            this.pnlChecks.TabIndex = 2;
            //
            // chkVentas
            //
            this.chkVentas.AutoSize = false;
            this.chkVentas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
            this.chkVentas.Location = new System.Drawing.Point(18, 12);
            this.chkVentas.Name = "chkVentas";
            this.chkVentas.Size = new System.Drawing.Size(420, 34);
            this.chkVentas.TabIndex = 0;
            this.chkVentas.Tag = "Ventas";
            this.chkVentas.Text = "Ventas (facturas, boletas, historial)";
            //
            // chkCompras
            //
            this.chkCompras.AutoSize = false;
            this.chkCompras.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkCompras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
            this.chkCompras.Location = new System.Drawing.Point(18, 52);
            this.chkCompras.Name = "chkCompras";
            this.chkCompras.Size = new System.Drawing.Size(420, 34);
            this.chkCompras.TabIndex = 1;
            this.chkCompras.Tag = "Compras";
            this.chkCompras.Text = "Compras (órdenes y historial)";
            //
            // chkGastos
            //
            this.chkGastos.AutoSize = false;
            this.chkGastos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkGastos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
            this.chkGastos.Location = new System.Drawing.Point(18, 92);
            this.chkGastos.Name = "chkGastos";
            this.chkGastos.Size = new System.Drawing.Size(420, 34);
            this.chkGastos.TabIndex = 2;
            this.chkGastos.Tag = "Gastos";
            this.chkGastos.Text = "Gastos Operativos";
            //
            // chkCaja
            //
            this.chkCaja.AutoSize = false;
            this.chkCaja.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkCaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
            this.chkCaja.Location = new System.Drawing.Point(18, 132);
            this.chkCaja.Name = "chkCaja";
            this.chkCaja.Size = new System.Drawing.Size(420, 34);
            this.chkCaja.TabIndex = 3;
            this.chkCaja.Tag = "Caja";
            this.chkCaja.Text = "Caja / Turnos";
            //
            // chkContabilidad
            //
            this.chkContabilidad.AutoSize = false;
            this.chkContabilidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkContabilidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
            this.chkContabilidad.Location = new System.Drawing.Point(18, 172);
            this.chkContabilidad.Name = "chkContabilidad";
            this.chkContabilidad.Size = new System.Drawing.Size(420, 34);
            this.chkContabilidad.TabIndex = 4;
            this.chkContabilidad.Tag = "Contabilidad";
            this.chkContabilidad.Text = "Movimientos Contables (asientos diario)";
            //
            // chkConfiguraciones
            //
            this.chkConfiguraciones.AutoSize = false;
            this.chkConfiguraciones.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkConfiguraciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
            this.chkConfiguraciones.Location = new System.Drawing.Point(18, 212);
            this.chkConfiguraciones.Name = "chkConfiguraciones";
            this.chkConfiguraciones.Size = new System.Drawing.Size(420, 34);
            this.chkConfiguraciones.TabIndex = 5;
            this.chkConfiguraciones.Tag = "Configuraciones";
            this.chkConfiguraciones.Text = "Configuraciones (categorías, unidades, pres.)";
            //
            // chkCxC
            //
            this.chkCxC.AutoSize = false;
            this.chkCxC.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkCxC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
            this.chkCxC.Location = new System.Drawing.Point(458, 12);
            this.chkCxC.Name = "chkCxC";
            this.chkCxC.Size = new System.Drawing.Size(420, 34);
            this.chkCxC.TabIndex = 6;
            this.chkCxC.Tag = "CxC";
            this.chkCxC.Text = "Cuentas por Cobrar (créditos y cobros)";
            //
            // chkCxP
            //
            this.chkCxP.AutoSize = false;
            this.chkCxP.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkCxP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
            this.chkCxP.Location = new System.Drawing.Point(458, 52);
            this.chkCxP.Name = "chkCxP";
            this.chkCxP.Size = new System.Drawing.Size(420, 34);
            this.chkCxP.TabIndex = 7;
            this.chkCxP.Tag = "CxP";
            this.chkCxP.Text = "Cuentas por Pagar (deudas y pagos)";
            //
            // chkProductos
            //
            this.chkProductos.AutoSize = false;
            this.chkProductos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
            this.chkProductos.Location = new System.Drawing.Point(458, 92);
            this.chkProductos.Name = "chkProductos";
            this.chkProductos.Size = new System.Drawing.Size(420, 34);
            this.chkProductos.TabIndex = 8;
            this.chkProductos.Tag = "Productos";
            this.chkProductos.Text = "Productos y Presentaciones";
            //
            // chkClientes
            //
            this.chkClientes.AutoSize = false;
            this.chkClientes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
            this.chkClientes.Location = new System.Drawing.Point(458, 132);
            this.chkClientes.Name = "chkClientes";
            this.chkClientes.Size = new System.Drawing.Size(420, 34);
            this.chkClientes.TabIndex = 9;
            this.chkClientes.Tag = "Clientes";
            this.chkClientes.Text = "Clientes  (se conserva el Cliente General)";
            //
            // chkProveedores
            //
            this.chkProveedores.AutoSize = false;
            this.chkProveedores.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkProveedores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
            this.chkProveedores.Location = new System.Drawing.Point(458, 172);
            this.chkProveedores.Name = "chkProveedores";
            this.chkProveedores.Size = new System.Drawing.Size(420, 34);
            this.chkProveedores.TabIndex = 10;
            this.chkProveedores.Tag = "Proveedores";
            this.chkProveedores.Text = "Proveedores";
            //
            // lblNota
            //
            this.lblNota.AutoSize = false;
            this.lblNota.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblNota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(100)))), ((int)(((byte)(116)))));
            this.lblNota.Location = new System.Drawing.Point(18, 250);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(860, 18);
            this.lblNota.TabIndex = 11;
            this.lblNota.Text = "* Usuarios, roles, configuración general del sistema y datos semilla nunca se eliminan.";
            //
            // btnSelTodo
            //
            this.btnSelTodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.btnSelTodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelTodo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.btnSelTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelTodo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSelTodo.ForeColor = System.Drawing.Color.White;
            this.btnSelTodo.Location = new System.Drawing.Point(30, 422);
            this.btnSelTodo.Name = "btnSelTodo";
            this.btnSelTodo.Size = new System.Drawing.Size(160, 34);
            this.btnSelTodo.TabIndex = 10;
            this.btnSelTodo.Text = "Seleccionar Todo";
            this.btnSelTodo.UseVisualStyleBackColor = false;
            this.btnSelTodo.Click += new System.EventHandler(this.BtnSelTodo_Click);
            //
            // btnDesel
            //
            this.btnDesel.BackColor = System.Drawing.Color.White;
            this.btnDesel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
            this.btnDesel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDesel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(100)))), ((int)(((byte)(116)))));
            this.btnDesel.Location = new System.Drawing.Point(200, 422);
            this.btnDesel.Name = "btnDesel";
            this.btnDesel.Size = new System.Drawing.Size(170, 34);
            this.btnDesel.TabIndex = 11;
            this.btnDesel.Text = "Deseleccionar Todo";
            this.btnDesel.UseVisualStyleBackColor = false;
            this.btnDesel.Click += new System.EventHandler(this.BtnDesel_Click);
            //
            // btnLimpiar
            //
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(590, 420);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(210, 38);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "🗑   Limpiar Seleccionados";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            //
            // btnCerrar
            //
            this.btnCerrar.BackColor = System.Drawing.Color.White;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(100)))), ((int)(((byte)(116)))));
            this.btnCerrar.Location = new System.Drawing.Point(810, 420);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(110, 38);
            this.btnCerrar.TabIndex = 13;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            //
            // FormLimpiarSistema
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(960, 580);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLimpiarSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Limpiar Sistema";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlWarn.ResumeLayout(false);
            this.pnlChecks.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlAccent;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlWarn;
        private System.Windows.Forms.Label lblWarn;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Panel pnlChecks;
        private System.Windows.Forms.CheckBox chkVentas;
        private System.Windows.Forms.CheckBox chkCompras;
        private System.Windows.Forms.CheckBox chkGastos;
        private System.Windows.Forms.CheckBox chkCaja;
        private System.Windows.Forms.CheckBox chkContabilidad;
        private System.Windows.Forms.CheckBox chkConfiguraciones;
        private System.Windows.Forms.CheckBox chkCxC;
        private System.Windows.Forms.CheckBox chkCxP;
        private System.Windows.Forms.CheckBox chkProductos;
        private System.Windows.Forms.CheckBox chkClientes;
        private System.Windows.Forms.CheckBox chkProveedores;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Button btnSelTodo;
        private System.Windows.Forms.Button btnDesel;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCerrar;
    }
}
