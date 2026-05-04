using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Reports.DataSources;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Ventas
{
    public partial class FormVentas : Form
    {
        private int    _clienteID;
        private string _clienteNombre = "CLIENTE GENERAL";
        private string _clienteDoc    = "00000000";
        private int _cajaID;
        private List<dynamic> _todosLosClientes;
        private decimal _tasaIGV = 0.18m;
        private decimal _rawCartTotal = 0m;
        private bool _vistaCards = false;
        private int? _categoriaFiltro = null;
        private int _ultimaVentaID = 0;
        private readonly List<CartItem> _cartItems = new List<CartItem>();

        // ── Estado de pago ────────────────────────────────────────────────────
        private bool    _esperandoConfirmacion   = false;
        private string  _pagoMetodo              = "";
        private decimal _pagoMontoEfectivo;
        private decimal _pagoMontoYape;
        private decimal _pagoMontoTarjeta;
        private decimal _pagoMontoTransferencia;
        private decimal _pagoRecibido;

        private class CartItem
        {
            public int     ProductoID         { get; set; }
            public int     PresentacionID     { get; set; }
            public string  Nombre             { get; set; }
            public string  NombrePresentacion { get; set; }
            public decimal PrecioUnitario     { get; set; }
            public decimal CantidadUnidades   { get; set; }
            public decimal Cantidad           { get; set; }
            public string  UnidadSimbolo      { get; set; }
            public bool    PrecioIncluyeIGV   { get; set; }
            public decimal CantPres => CantidadUnidades > 0 ? Cantidad / CantidadUnidades : 0;
            public decimal Total    => CantPres * PrecioUnitario;
        }

        // placeholder
        private const string PLACEHOLDER_BUSCAR = "Buscar productos...";

        public FormVentas()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            ConfigurarEventos();
            ConfigurarDataGridViews();
            ConfigurarComboClientes();
            InicializarVenta();
            CargarCategorias();
            MostrarVistaLista();
            CargarClientes();

            // Restringir descuentos
            var usr = SesionActual.Usuario;
            bool puedeDescontar = usr != null && (usr.PermisoDescuentos || usr.RolID == 1);
            txtDescuento.ReadOnly = !puedeDescontar;
            txtDescuento.BackColor = puedeDescontar
                ? Color.FromArgb(248, 249, 250) : Color.FromArgb(235, 236, 238);

            // Tooltips para campos bloqueados
            var tooltip = new ToolTip();
            if (!puedeDescontar)
                tooltip.SetToolTip(txtDescuento, "No tiene permiso para aplicar descuentos. Contacte al administrador.");
            tooltip.SetToolTip(txtSubtotal, "Campo de solo lectura. Calculado automáticamente.");
            tooltip.SetToolTip(txtIGV, "Campo de solo lectura. Calculado según el tipo de IGV seleccionado.");
            tooltip.SetToolTip(txtTotalPagar, "Campo de solo lectura. Total a cobrar al cliente.");

            // Leer tasa IGV
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = new System.Data.SQLite.SQLiteCommand(
                    "SELECT Valor FROM ConfigGeneral WHERE Clave = 'IGV' LIMIT 1", conn))
                {
                    var v = cmd.ExecuteScalar()?.ToString();
                    if (decimal.TryParse(v, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out decimal tasa))
                        _tasaIGV = tasa / 100m;
                }
            }
            catch { }
        }

        // ══════════════════════════════════════════════════════════════
        // CONFIGURACIÓN
        // ══════════════════════════════════════════════════════════════

        private void ConfigurarEventos()
        {
            // búsqueda con placeholder
            txtBuscar.Enter += TxtBuscar_Enter;
            txtBuscar.Leave += TxtBuscar_Leave;
            txtBuscar.TextChanged += TxtBuscar_TextChanged;

            // vista toggle
            btnVistaCards.Click += (s, e) => MostrarVistaCards();
            btnVistaLista.Click += (s, e) => MostrarVistaLista();

            // dgvProductos (lista)
            dgvProductos.CellDoubleClick += DgvProductos_CellDoubleClick;
            dgvProductos.EditingControlShowing += DgvProductos_EditingControlShowing;
            dgvProductos.CellValueChanged += DgvProductos_CellValueChanged;
            dgvProductos.CurrentCellDirtyStateChanged += DgvProductos_CurrentCellDirtyStateChanged;

            // totales
            cboIGV.SelectedIndexChanged += (s, e) => CalcularTotales();
            txtDescuento.KeyPress += TxtDescuento_KeyPress;
            txtDescuento.Leave += TxtDescuento_Leave;

            // cliente
            btnBuscarCliente.Click += BtnBuscarCliente_Click;
            cmbClientes.SelectedIndexChanged += CmbClientes_SelectedIndexChanged;
            cmbClientes.TextChanged += CmbClientes_TextChanged;

            // acciones
            btnCobrar.Click += BtnCobrar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            btnHistorial.Click += BtnHistorial_Click;
            btnPreviewVenta.Click += BtnPreviewVenta_Click;
        }

        private void ConfigurarDataGridViews()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.ReadOnly = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.EditMode = DataGridViewEditMode.EditOnEnter;



            // Eliminar fondo de selección y alternado de WinForms
            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvProductos.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.White;
            dgvProductos.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(45, 52, 54);
            dgvProductos.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(45, 52, 54);

            dgvProductos.RowPrePaint += (s, e) =>
            {
                e.PaintParts &= ~DataGridViewPaintParts.SelectionBackground;
            };

            dgvProductos.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                dgvProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);
            };
            dgvProductos.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                dgvProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            };

            pnlScrollCarrito.Resize += (s, e) => RenderCarrito();
        }

        private void ConfigurarComboClientes()
        {
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDown;
            cmbClientes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbClientes.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        // ══════════════════════════════════════════════════════════════
        // INICIALIZACIÓN
        // ══════════════════════════════════════════════════════════════

        private void InicializarVenta()
        {
            var clienteGeneral = ClienteRepository.ObtenerClienteGeneral();
            _clienteID = clienteGeneral != null ? clienteGeneral.ClienteID : 1;
            _clienteNombre = "CLIENTE GENERAL";
            _clienteDoc = "00000000";

            var caja = CajaRepository.ObtenerCajaAbierta();
            if (caja != null)
                _cajaID = caja.CajaID;

            txtSubtotal.Text   = "0.00";
            txtIGV.Text        = "0.00";
            txtDescuento.Text  = "0.00";
            txtTotalPagar.Text = "0.00";

            cmbTipoComprobante.Text = "NOTA_VENTA";
        }

        // ══════════════════════════════════════════════════════════════
        // PLACEHOLDER BÚSQUEDA
        // ══════════════════════════════════════════════════════════════

        private void TxtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == PLACEHOLDER_BUSCAR)
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.FromArgb(45, 52, 54);
            }
        }

        private void TxtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = PLACEHOLDER_BUSCAR;
                txtBuscar.ForeColor = Color.FromArgb(170, 170, 170);
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == PLACEHOLDER_BUSCAR) return;
            string q = txtBuscar.Text.Trim();
            if (_vistaCards)
                CargarCards(q);
            else
                CargarProductos(q);
        }

        // ══════════════════════════════════════════════════════════════
        // TOGGLE VISTA
        // ══════════════════════════════════════════════════════════════

        private void MostrarVistaCards()
        {
            _vistaCards = true;
            pnlListaProductos.Visible = false;
            flpCardsProductos.Visible = true;
            pnlProductos.PerformLayout();

            btnVistaCards.BackColor = Color.FromArgb(67, 97, 238);
            btnVistaCards.ForeColor = Color.White;
            btnVistaCards.FlatAppearance.BorderColor = Color.FromArgb(67, 97, 238);
            btnVistaLista.BackColor = Color.White;
            btnVistaLista.ForeColor = Color.FromArgb(45, 52, 54);
            btnVistaLista.FlatAppearance.BorderColor = Color.FromArgb(220, 221, 225);

            string q = txtBuscar.Text == PLACEHOLDER_BUSCAR ? "" : txtBuscar.Text.Trim();
            CargarCards(q);
        }

        private void MostrarVistaLista()
        {
            _vistaCards = false;
            flpCardsProductos.Visible = false;
            pnlListaProductos.Visible = true;
            pnlProductos.PerformLayout();

            dgvProductos.Columns["colNumero"].Width      = 60;
            dgvProductos.Columns["colImagen"].Width      = 80;
            dgvProductos.Columns["colPresentacion"].Width = 310;
            dgvProductos.Columns["colPrecioUnit"].Width  = 160;

            btnVistaLista.BackColor = Color.FromArgb(67, 97, 238);
            btnVistaLista.ForeColor = Color.White;
            btnVistaLista.FlatAppearance.BorderColor = Color.FromArgb(67, 97, 238);
            btnVistaCards.BackColor = Color.White;
            btnVistaCards.ForeColor = Color.FromArgb(45, 52, 54);
            btnVistaCards.FlatAppearance.BorderColor = Color.FromArgb(220, 221, 225);

            string q = txtBuscar.Text == PLACEHOLDER_BUSCAR ? "" : txtBuscar.Text.Trim();
            CargarProductos(q);
        }

        // ══════════════════════════════════════════════════════════════
        // CATEGORÍAS (chips)
        // ══════════════════════════════════════════════════════════════

        private void CargarCategorias()
        {
            flpCategorias.Controls.Clear();
            AgregarChipCategoria("Todos", null);

            try
            {
                var categorias = CategoriaRepository.ObtenerTodas();
                foreach (var cat in categorias)
                    AgregarChipCategoria(cat.Nombre, cat.CategoriaID);
            }
            catch { }
        }

        private void AgregarChipCategoria(string nombre, int? categoriaID)
        {
            bool activo = categoriaID == _categoriaFiltro;
            var btn = new Button
            {
                Text = nombre,
                AutoSize = true,
                Margin = new Padding(0, 3, 8, 3),
                Padding = new Padding(14, 4, 14, 4),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 9F, activo ? FontStyle.Bold : FontStyle.Regular),
                BackColor = activo ? Color.FromArgb(67, 97, 238) : Color.FromArgb(245, 247, 252),
                ForeColor = activo ? Color.White : Color.FromArgb(60, 70, 90),
                Tag = categoriaID
            };
            btn.FlatAppearance.BorderColor = activo
                ? Color.FromArgb(50, 82, 220) : Color.FromArgb(200, 210, 230);
            btn.FlatAppearance.BorderSize = 1;
            btn.Click += (s, e) =>
            {
                _categoriaFiltro = categoriaID;
                // Actualizar estilo de todos los chips
                foreach (Control c in flpCategorias.Controls)
                {
                    if (!(c is Button b)) continue;
                    bool sel = (b.Tag as int?) == _categoriaFiltro;
                    b.BackColor = sel ? Color.FromArgb(67, 97, 238) : Color.FromArgb(245, 247, 252);
                    b.ForeColor = sel ? Color.White : Color.FromArgb(60, 70, 90);
                    b.Font = new Font("Segoe UI", 9F, sel ? FontStyle.Bold : FontStyle.Regular);
                    b.FlatAppearance.BorderColor = sel
                        ? Color.FromArgb(50, 82, 220) : Color.FromArgb(200, 210, 230);
                }
                string q = txtBuscar.Text == PLACEHOLDER_BUSCAR ? "" : txtBuscar.Text.Trim();
                if (_vistaCards) CargarCards(q);
                else CargarProductos(q);
            };
            flpCategorias.Controls.Add(btn);
        }

        // ══════════════════════════════════════════════════════════════
        // VISTA CARDS
        // ══════════════════════════════════════════════════════════════

        private void CargarCards(string busqueda = "")
        {
            flpCardsProductos.SuspendLayout();
            flpCardsProductos.Controls.Clear();

            try
            {
                var productos = ProductoRepository.BuscarProductos(busqueda, _categoriaFiltro);
                int count = 0;
                foreach (var producto in productos)
                {
                    var presentaciones = ProductoRepository.ObtenerPresentaciones(producto.ProductoID);
                    if (presentaciones.Count == 0) continue;
                    count++;

                    var card = CrearCard(producto, presentaciones);
                    flpCardsProductos.Controls.Add(card);
                }
                lblResultados.Text = $"{count} producto(s)";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("CargarCards: " + ex.Message);
            }
            finally
            {
                flpCardsProductos.ResumeLayout();
            }
        }

        private Panel CrearCard(dynamic producto, List<ProductoPresentacion> presentaciones)
        {
            bool multiPres = presentaciones.Count > 1;
            int cardHeight = multiPres ? 234 : 210;

            var card = new Panel
            {
                Size = new Size(178, cardHeight),
                BackColor = Color.White,
                Margin = new Padding(0, 0, 10, 10),
                Cursor = Cursors.Hand,
                Tag = new { Producto = producto, Presentaciones = presentaciones }
            };
            card.Paint += Card_Paint;

            // Imagen
            var pic = new PictureBox
            {
                Size = new Size(178, 108),
                Location = new Point(0, 0),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(238, 242, 252),
            };
            if (producto.Imagen != null && ((byte[])producto.Imagen).Length > 0)
            {
                try
                {
                    using (var ms = new System.IO.MemoryStream((byte[])producto.Imagen))
                    using (var img = Image.FromStream(ms))
                        pic.Image = new Bitmap(img);
                }
                catch { }
            }
            card.Controls.Add(pic);

            // Nombre
            var lblNombre = new Label
            {
                Text = producto.Nombre?.ToString() ?? "",
                Location = new Point(8, 114),
                Size = new Size(162, 36),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 36, 50),
            };
            card.Controls.Add(lblNombre);

            // Precio (se actualiza cuando cambia la selección)
            var lblPrecio = new Label
            {
                Text = "S/ " + presentaciones[0].PrecioVenta.ToString("N2"),
                Location = new Point(8, multiPres ? 178 : 148),
                Size = new Size(162, 26),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(67, 97, 238),
            };
            card.Controls.Add(lblPrecio);

            if (multiPres)
            {
                // ComboBox con todas las presentaciones
                var cboPres = new ComboBox
                {
                    Location = new Point(8, 148),
                    Size = new Size(162, 24),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Font = new Font("Segoe UI", 7.5F),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(248, 249, 250),
                    Cursor = Cursors.Hand,
                    Name = "cboPres_" + producto.ProductoID,
                };
                foreach (var p in presentaciones)
                {
                    string nom = ObtenerNombrePresentacion(p.PresentacionID);
                    cboPres.Items.Add(new ComboPresItem { Display = $"{nom} - S/ {p.PrecioVenta:N2}", Pres = p });
                }
                cboPres.DisplayMember = "Display";
                cboPres.SelectedIndex = 0;
                cboPres.SelectedIndexChanged += (s, ev) =>
                {
                    if (cboPres.SelectedItem is ComboPresItem sel)
                        lblPrecio.Text = "S/ " + sel.Pres.PrecioVenta.ToString("N2");
                };
                card.Controls.Add(cboPres);

                EventHandler addToCart = (s, ev) =>
                {
                    if (s is ComboBox) return;
                    try
                    {
                        var tag = (dynamic)card.Tag;
                        ProductoPresentacion pres = presentaciones[0];
                        if (cboPres.SelectedItem is ComboPresItem sel) pres = sel.Pres;
                        string unidad = ObtenerSimboloUnidad(tag.Producto.UnidadBaseID);
                        AgregarAlCarrito(tag.Producto.ProductoID,
                                         tag.Producto.Nombre?.ToString() ?? "", pres, unidad);
                    }
                    catch (Exception ex) { MessageBox.Show("Error: " + ex.Message, "Error"); }
                };
                card.Click      += addToCart;
                pic.Click       += addToCart;
                lblNombre.Click += addToCart;
                lblPrecio.Click += addToCart;
            }
            else
            {
                // Una sola presentación: mostrar nombre de presentación como subtexto
                string nomPres = ObtenerNombrePresentacion(presentaciones[0].PresentacionID);
                var lblPres = new Label
                {
                    Text = nomPres,
                    Location = new Point(8, 176),
                    Size = new Size(162, 18),
                    Font = new Font("Segoe UI", 8F),
                    ForeColor = Color.FromArgb(130, 140, 155),
                };
                card.Controls.Add(lblPres);

                EventHandler addToCart = (s, ev) =>
                {
                    try
                    {
                        var tag = (dynamic)card.Tag;
                        var pres = ((List<ProductoPresentacion>)tag.Presentaciones)[0];
                        string unidad = ObtenerSimboloUnidad(tag.Producto.UnidadBaseID);
                        AgregarAlCarrito(tag.Producto.ProductoID,
                                         tag.Producto.Nombre?.ToString() ?? "", pres, unidad);
                    }
                    catch (Exception ex) { MessageBox.Show("Error: " + ex.Message, "Error"); }
                };
                card.Click      += addToCart;
                pic.Click       += addToCart;
                lblNombre.Click += addToCart;
                lblPrecio.Click += addToCart;
                lblPres.Click   += addToCart;
            }

            return card;
        }

        private class ComboPresItem
        {
            public string Display { get; set; }
            public ProductoPresentacion Pres { get; set; }
            public override string ToString() => Display;
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            var p = (Panel)sender;
            var g = e.Graphics;
            // Borde principal
            using (var pen = new Pen(Color.FromArgb(210, 218, 240), 1.5f))
                g.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
            // Sombra inferior (efecto profundidad)
            using (var pen = new Pen(Color.FromArgb(195, 200, 220), 1))
            {
                g.DrawLine(pen, 2, p.Height - 1, p.Width - 1, p.Height - 1);
                g.DrawLine(pen, p.Width - 1, 2, p.Width - 1, p.Height - 1);
            }
        }

        // ══════════════════════════════════════════════════════════════
        // VISTA LISTA (dgvProductos)
        // ══════════════════════════════════════════════════════════════

        private void CargarProductos(string busqueda = "")
        {
            try
            {
                dgvProductos.Rows.Clear();
                var productos = ProductoRepository.BuscarProductos(busqueda, _categoriaFiltro);
                int numero = 1;
                foreach (var producto in productos)
                {
                    var presentaciones = ProductoRepository.ObtenerPresentaciones(producto.ProductoID);
                    if (presentaciones.Count == 0) continue;

                    int index = dgvProductos.Rows.Add();
                    var row = dgvProductos.Rows[index];

                    row.Cells["colNumero"].Value = numero++;
                    row.Cells["colProducto"].Value = producto.Nombre;

                    if (producto.Imagen != null && ((byte[])producto.Imagen).Length > 0)
                    {
                        try
                        {
                            using (var ms = new System.IO.MemoryStream((byte[])producto.Imagen))
                            using (var img = Image.FromStream(ms))
                                row.Cells["colImagen"].Value = new Bitmap(img);
                        }
                        catch { }
                    }

                    var comboPres = row.Cells["colPresentacion"] as DataGridViewComboBoxCell;
                    if (comboPres != null)
                    {
                        var items = new List<object>();
                        foreach (var pres in presentaciones)
                        {
                            string nom = ObtenerNombrePresentacion(pres.PresentacionID);
                            items.Add(new
                            {
                                Display = $"{nom} - S/ {pres.PrecioVenta:N2}",
                                Value   = pres.ProductoPresentacionID,
                                Presentacion = pres
                            });
                        }
                        comboPres.DataSource    = items;
                        comboPres.DisplayMember = "Display";
                        comboPres.ValueMember   = "Value";
                        if (items.Count > 0)
                        {
                            comboPres.Value = ((dynamic)items[0]).Value;
                            row.Cells["colPrecioUnit"].Value = "S/ " + presentaciones[0].PrecioVenta.ToString("N2");
                        }
                    }

                    row.Tag = new
                    {
                        ProductoID    = producto.ProductoID,
                        UnidadBaseID  = producto.UnidadBaseID,
                        Presentaciones = presentaciones
                    };
                }
                lblResultados.Text = $"{numero - 1} producto(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error");
            }
        }

        private string ObtenerNombrePresentacion(int id) =>
            PresentacionRepository.ObtenerNombrePorID(id);

        private string ObtenerSimboloUnidad(int id) =>
            UnidadRepository.ObtenerSimboloPorID(id);

        // ══════════════════════════════════════════════════════════════
        // CLIENTES
        // ══════════════════════════════════════════════════════════════

        private void CargarClientes()
        {
            try
            {
                _todosLosClientes = ClienteRepository.Listar().Cast<dynamic>().ToList();
                cmbClientes.Items.Clear();
                cmbClientes.Items.Add("CLIENTE GENERAL");
                foreach (var c in _todosLosClientes)
                    cmbClientes.Items.Add($"{c.NombreCompleto} - {c.NumeroDocumento}");
                cmbClientes.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error");
            }
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            cmbClientes.Focus();
            cmbClientes.DroppedDown = true;
        }

        private void CmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedIndex == 0)
            {
                _clienteID = 1;
                _clienteNombre = "CLIENTE GENERAL";
                _clienteDoc    = "00000000";
            }
            else if (cmbClientes.SelectedIndex > 0 &&
                     cmbClientes.SelectedIndex - 1 < _todosLosClientes.Count)
            {
                var c = _todosLosClientes[cmbClientes.SelectedIndex - 1];
                _clienteID            = c.ClienteID;
                _clienteNombre = c.NombreCompleto;
                _clienteDoc    = c.NumeroDocumento;
            }
        }

        private void CmbClientes_TextChanged(object sender, EventArgs e)
        {
            string q = cmbClientes.Text.ToLower().Trim();
            if (string.IsNullOrEmpty(q)) return;
            var found = _todosLosClientes?.FirstOrDefault(c =>
                c.NombreCompleto.ToString().ToLower().Contains(q) ||
                c.NumeroDocumento.ToString().Contains(q));
            if (found != null)
            {
                _clienteID            = found.ClienteID;
                _clienteNombre = found.NombreCompleto;
                _clienteDoc    = found.NumeroDocumento;
            }
        }

        // ══════════════════════════════════════════════════════════════
        // CARRITO – AGREGAR
        // ══════════════════════════════════════════════════════════════

        private void DgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                var item = (dynamic)dgvProductos.Rows[e.RowIndex].Tag;
                string nombre = dgvProductos.Rows[e.RowIndex].Cells["colProducto"].Value.ToString();
                var combo = dgvProductos.Rows[e.RowIndex].Cells["colPresentacion"] as DataGridViewComboBoxCell;
                if (combo?.Value == null) return;
                int presID = Convert.ToInt32(combo.Value);
                List<ProductoPresentacion> pres = item.Presentaciones;
                var p = pres.Find(x => x.ProductoPresentacionID == presID);
                if (p != null)
                    AgregarAlCarrito(item.ProductoID, nombre, p, ObtenerSimboloUnidad(item.UnidadBaseID));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private void AgregarAlCarrito(int productoID, string nombreProducto,
                                       ProductoPresentacion presentacion, string unidadSimbolo)
        {
            decimal enCarrito = _cartItems
                .Where(i => i.ProductoID == productoID)
                .Sum(i => i.Cantidad);

            var prod = ProductoRepository.ObtenerPorID(productoID);
            decimal stock    = prod?.StockTotal ?? 0;
            decimal unidades = presentacion.CantidadUnidades;

            if (enCarrito + unidades > stock)
            {
                MessageBox.Show(
                    $"Stock insuficiente para '{nombreProducto}'.\nDisponible: {stock:N2}  |  En carrito: {enCarrito:N2}",
                    "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si ya existe el mismo producto+presentación, sumar cantidad
            var existing = _cartItems.FirstOrDefault(i =>
                i.ProductoID == productoID && i.PresentacionID == presentacion.ProductoPresentacionID);
            if (existing != null)
            {
                existing.Cantidad += unidades;
                RenderCarrito();
                SonidoHelper.ReproducirCarrito();
                return;
            }

            if (_cartItems.Count == 0 && presentacion.PrecioIncluyeIGV && cboIGV.SelectedIndex == 0)
                cboIGV.SelectedIndex = 1;

            _cartItems.Add(new CartItem
            {
                ProductoID         = productoID,
                PresentacionID     = presentacion.ProductoPresentacionID,
                Nombre             = nombreProducto,
                NombrePresentacion = ObtenerNombrePresentacion(presentacion.PresentacionID),
                PrecioUnitario     = presentacion.PrecioVenta,
                CantidadUnidades   = unidades,
                Cantidad           = unidades,
                UnidadSimbolo      = unidadSimbolo,
                PrecioIncluyeIGV   = presentacion.PrecioIncluyeIGV
            });
            RenderCarrito();
            SonidoHelper.ReproducirCarrito();
        }

        // ══════════════════════════════════════════════════════════════
        // CARRITO – RENDER (ecommerce-style)
        // ══════════════════════════════════════════════════════════════

        private void RenderCarrito()
        {
            pnlScrollCarrito.SuspendLayout();
            pnlScrollCarrito.Controls.Clear();

            int w = Math.Max(340, pnlScrollCarrito.ClientSize.Width);
            int y = 0;
            for (int i = 0; i < _cartItems.Count; i++)
            {
                var row = CrearFilaCarrito(_cartItems[i], i, w);
                row.Location = new Point(0, y);
                pnlScrollCarrito.Controls.Add(row);
                y += row.Height;
            }
            pnlScrollCarrito.ResumeLayout(true);
            CalcularTotales();
        }

        private Panel CrearFilaCarrito(CartItem item, int index, int rowW)
        {
            // ── Layout constants ─────────────────────────────────────────────
            const int rowH  = 72;
            const int pad   = 10;
            const int btnSz = 28;
            const int gapQ  = 4;

            // Column widths – 50 / 25 / 20 / 5 %
            int nameW = (int)(rowW * 0.50);
            int qtyW  = (int)(rowW * 0.25);
            int subW  = (int)(rowW * 0.20);
            int delW  = rowW - nameW - qtyW - subW; // ~5%

            // Vertical centre for qty controls & subtotal
            int ctrlY = (rowH - btnSz) / 2;

            // Qty block: [btnMinus][gap][txtCant][gap][btnPlus] centred inside qtyW
            int txtCantW  = Math.Max(36, qtyW - btnSz * 2 - gapQ * 2);
            int qtyContentW = btnSz + gapQ + txtCantW + gapQ + btnSz;
            int qtyX      = nameW + (qtyW - qtyContentW) / 2;

            Color bgNormal = Color.White;
            Color bgHover  = Color.FromArgb(245, 248, 255);

            var row = new Panel { Width = rowW, Height = rowH, BackColor = bgNormal, Tag = item };
            row.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(228, 230, 238), 1))
                    e.Graphics.DrawLine(pen, 0, row.Height - 1, row.Width, row.Height - 1);
            };

            // ── Name block (left 50%) ─────────────────────────────────────────
            int textW = nameW - pad - 4;
            var lblNombre = new Label
            {
                Text      = item.Nombre,
                Location  = new Point(pad, 10),
                Size      = new Size(textW, 22),
                Font      = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(20, 20, 20),
                BackColor = bgNormal,
                AutoSize  = false,
                TextAlign = ContentAlignment.MiddleLeft
            };
            var lblPres = new Label
            {
                Text      = item.NombrePresentacion,
                Location  = new Point(pad, 33),
                Size      = new Size(textW, 17),
                Font      = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(100, 100, 100),
                BackColor = bgNormal,
                AutoSize  = false
            };
            var lblPrecioU = new Label
            {
                Text      = $"S/ {item.PrecioUnitario:N2} c/u",
                Location  = new Point(pad, 51),
                Size      = new Size(textW, 17),
                Font      = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(130, 130, 130),
                BackColor = bgNormal,
                AutoSize  = false
            };

            // ── Qty controls (centre 25%) ─────────────────────────────────────
            var btnMinus = new Button
            {
                Text      = "−",
                Location  = new Point(qtyX, ctrlY),
                Size      = new Size(btnSz, btnSz),
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 12F, FontStyle.Bold),
                BackColor = Color.FromArgb(67, 97, 238),
                ForeColor = Color.White,
                Cursor    = Cursors.Hand,
                TabStop   = false
            };
            btnMinus.FlatAppearance.BorderSize = 0;

            var txtCant = new TextBox
            {
                Text        = item.Cantidad.ToString("0.##"),
                Location    = new Point(qtyX + btnSz + gapQ, ctrlY),
                Size        = new Size(txtCantW, btnSz),
                Font        = new Font("Segoe UI", 10F),
                TextAlign   = HorizontalAlignment.Center,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor   = Color.White,
                ForeColor   = Color.FromArgb(20, 20, 20)
            };

            var btnPlus = new Button
            {
                Text      = "+",
                Location  = new Point(qtyX + btnSz + gapQ + txtCantW + gapQ, ctrlY),
                Size      = new Size(btnSz, btnSz),
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 12F, FontStyle.Bold),
                BackColor = Color.FromArgb(67, 97, 238),
                ForeColor = Color.White,
                Cursor    = Cursors.Hand,
                TabStop   = false
            };
            btnPlus.FlatAppearance.BorderSize = 0;

            // ── Subtotal (right 20%) ──────────────────────────────────────────
            int subX = nameW + qtyW;
            var lblSubtotal = new Label
            {
                Text      = $"S/ {item.Total:N2}",
                Location  = new Point(subX, ctrlY),
                Size      = new Size(subW - 4, btnSz),
                Font      = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(20, 20, 20),
                BackColor = bgNormal,
                TextAlign = ContentAlignment.MiddleRight,
                AutoSize  = false
            };

            // ── Delete button (top-right ~5%) ─────────────────────────────────
            const int delBtnSz = 22;
            var btnDel = new Button
            {
                Text      = "×",
                Location  = new Point(subX + subW + (delW - delBtnSz) / 2, 4),
                Size      = new Size(delBtnSz, delBtnSz),
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(255, 236, 234),
                ForeColor = Color.FromArgb(192, 57, 43),
                Cursor    = Cursors.Hand,
                TabStop   = false
            };
            btnDel.FlatAppearance.BorderSize = 0;

            // ── Events ───────────────────────────────────────────────────────
            btnMinus.Click += (s, e) =>
            {
                decimal step = item.CantidadUnidades;
                if (item.Cantidad > step)          item.Cantidad -= step;
                else if (item.Cantidad > 0.01m)    item.Cantidad = Math.Max(0.01m, item.Cantidad - 0.1m);
                BeginInvoke((Action)RenderCarrito);
            };
            btnPlus.Click += (s, e) =>
            {
                item.Cantidad += item.CantidadUnidades;
                BeginInvoke((Action)RenderCarrito);
            };
            btnDel.Click += (s, e) =>
            {
                _cartItems.Remove(item);
                BeginInvoke((Action)RenderCarrito);
            };
            txtCant.Leave += (s, e) =>
            {
                string raw = new string(txtCant.Text.Where(c => char.IsDigit(c) || c == '.' || c == ',').ToArray());
                if (decimal.TryParse(raw, out decimal v) && v > 0)
                { item.Cantidad = Math.Round(v, 3); BeginInvoke((Action)RenderCarrito); }
                else
                    txtCant.Text = item.Cantidad.ToString("0.##");
            };
            txtCant.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { e.Handled = true; e.SuppressKeyPress = true; row.Focus(); }
            };

            // ── Hover ────────────────────────────────────────────────────────
            Label[] bgLabels = { lblNombre, lblPres, lblPrecioU, lblSubtotal };
            EventHandler onEnter = (s, e) => { row.BackColor = bgHover; foreach (var l in bgLabels) l.BackColor = bgHover; };
            EventHandler onLeave = (s, e) => { row.BackColor = bgNormal; foreach (var l in bgLabels) l.BackColor = bgNormal; };
            foreach (Control c in new Control[] { row, lblNombre, lblPres, lblPrecioU, lblSubtotal })
            { c.MouseEnter += onEnter; c.MouseLeave += onLeave; }

            row.Controls.AddRange(new Control[]
                { lblNombre, lblPres, lblPrecioU, btnMinus, txtCant, btnPlus, lblSubtotal, btnDel });
            return row;
        }

        // ══════════════════════════════════════════════════════════════
        // TOTALES
        // ══════════════════════════════════════════════════════════════

        private void CalcularTotales()
        {
            decimal rawTotal = _cartItems.Sum(i => i.Total);
            _rawCartTotal = rawTotal;

            decimal desc = decimal.TryParse(txtDescuento.Text, out decimal d) ? d : 0m;
            if (desc < 0) desc = 0m;

            int tipo = cboIGV.SelectedIndex;
            decimal totalBase, totalIGV, total;

            if (tipo == 1) // IGV incluido: el descuento se aplica al total y se recalcula la base
            {
                total = rawTotal - desc;
                if (total < 0) { total = 0; desc = rawTotal; }
                totalBase = Math.Round(total / (1m + _tasaIGV), 2);
                totalIGV  = total - totalBase;
            }
            else if (tipo == 2) // IGV adicional: el descuento reduce la base imponible
            {
                totalBase = rawTotal - desc;
                if (totalBase < 0) { totalBase = 0; desc = rawTotal; }
                totalIGV = Math.Round(totalBase * _tasaIGV, 2);
                total    = totalBase + totalIGV;
            }
            else // Sin IGV
            {
                total = rawTotal - desc;
                if (total < 0) { total = 0; desc = rawTotal; }
                totalBase = total;
                totalIGV  = 0m;
            }

            txtSubtotal.Text   = totalBase.ToString("N2");
            txtIGV.Text        = totalIGV.ToString("N2");
            txtTotalPagar.Text = total.ToString("N2");
        }

        // ══════════════════════════════════════════════════════════════
        // DESCUENTO
        // ══════════════════════════════════════════════════════════════

        private void TxtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ','
                && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            { e.Handled = true; return; }
            if (e.KeyChar == (char)Keys.Enter) { e.Handled = true; CalcularTotales(); }
        }

        private void TxtDescuento_Leave(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtDescuento.Text, out decimal d))
                d = 0m;
            if (d < 0) d = 0m;
            else
            {
                decimal st = decimal.TryParse(txtSubtotal.Text, out decimal s) ? s : 0;
                decimal igv = decimal.TryParse(txtIGV.Text, out decimal iv) ? iv : 0;
                if (d > st + igv) d = st + igv;
            }
            txtDescuento.Text = d.ToString("N2");
            CalcularTotales();
        }

        // ══════════════════════════════════════════════════════════════
        // COBRAR → abre FormPago
        // ══════════════════════════════════════════════════════════════

        private void BtnCobrar_Click(object sender, EventArgs e)
        {
            // Fase 2: método ya seleccionado → registrar la venta
            if (_esperandoConfirmacion)
            {
                RegistrarVentaConfirmada();
                return;
            }

            // Fase 1: seleccionar método de pago
            AbrirSeleccionPago();
        }

        private void BtnPreviewVenta_Click(object sender, EventArgs e)
        {
            // Siempre abre el ticket con selección de pago (permite cambiar método)
            AbrirSeleccionPago();
        }

        /// <summary>Abre FormCobrarConTicket para ver el ticket y seleccionar/cambiar el método de pago.</summary>
        private void AbrirSeleccionPago()
        {
            if (!ValidarVenta()) return;
            if (!TryParseMonto(txtTotalPagar.Text, out decimal total)) return;
            if (!TryParseMonto(txtSubtotal.Text,   out decimal baseImp)) return;
            if (!TryParseMonto(txtIGV.Text,        out decimal igv)) return;

            var dt = new DataTable("DetalleVenta");
            dt.Columns.Add("Numero",        typeof(string));
            dt.Columns.Add("Producto",       typeof(string));
            dt.Columns.Add("Presentacion",   typeof(string));
            dt.Columns.Add("Cantidad",       typeof(decimal));
            dt.Columns.Add("PrecioUnitario", typeof(decimal));
            dt.Columns.Add("SubTotal",       typeof(decimal));
            int numRow = 1;
            foreach (var item in _cartItems)
            {
                if (item.CantidadUnidades <= 0) continue;
                dt.Rows.Add(numRow++.ToString(), item.Nombre, item.UnidadSimbolo,
                            item.Cantidad, item.PrecioUnitario, item.Total);
            }

            if (!decimal.TryParse(txtDescuento.Text, out decimal desc)) desc = 0;
            var parametros = ReportHelper.GetCompanyParameters();
            parametros["pTipoComprobante"] = cmbTipoComprobante.Text.Replace("_", " ");
            parametros["pNumeroVenta"]     = "";
            parametros["pFecha"]           = DateTime.Now.ToString("dd/MM/yyyy");
            parametros["pHora"]            = DateTime.Now.ToString("HH:mm");
            parametros["pEstado"]          = "";
            parametros["pSubTotal"]        = baseImp.ToString("N2");
            parametros["pDescuento"]       = desc.ToString("N2");
            parametros["pIGV"]             = igv.ToString("N2");
            parametros["pTotal"]           = total.ToString("N2");
            parametros["pCliente"]         = _clienteNombre;
            parametros["pDocCliente"]      = _clienteDoc;
            parametros["pEncargado"]       = SesionActual.Usuario?.NombreCompleto ?? SesionActual.Usuario?.NombreUsuario ?? "";

            using (var formCobrar = new FormCobrarConTicket(total, dt, parametros))
            {
                if (formCobrar.ShowDialog(this) != DialogResult.OK) return;

                if (formCobrar.MetodoPago == "CREDITO" && (_clienteID <= 1))
                {
                    MessageBox.Show("No se puede vender a crédito sin un cliente registrado.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbClientes.Focus(); return;
                }

                _pagoMetodo             = formCobrar.MetodoPago;
                _pagoMontoEfectivo      = formCobrar.MontoEfectivo;
                _pagoMontoYape          = formCobrar.MontoYape;
                _pagoMontoTarjeta       = formCobrar.MontoTarjeta;
                _pagoMontoTransferencia = formCobrar.MontoTransferencia;
                _pagoRecibido           = formCobrar.Recibido;
                _esperandoConfirmacion  = true;

                btnCobrar.Text      = "✓  CONFIRMAR VENTA";
                btnCobrar.BackColor = Color.FromArgb(67, 97, 238);
            }
        }

        private void RegistrarVentaConfirmada()
        {
            if (!TryParseMonto(txtTotalPagar.Text, out decimal total)) return;
            if (!TryParseMonto(txtSubtotal.Text,   out decimal baseImp)) return;
            if (!TryParseMonto(txtIGV.Text,        out decimal igv)) return;
            decimal subTotal = _rawCartTotal;
            decimal descuento = decimal.TryParse(txtDescuento.Text, out decimal dv) ? Math.Max(dv, 0m) : 0m;

            try
            {
                var configFact = EmpresaRepository.ObtenerConfiguracionFacturacion();
                string tipoComp = cmbTipoComprobante.Text;
                string serie;
                int correlativo;
                switch (tipoComp)
                {
                    case "BOLETA":
                        serie = configFact.SerieBoleta;
                        correlativo = configFact.CorrelativoBoleta + 1;
                        configFact.CorrelativoBoleta = correlativo; break;
                    case "FACTURA":
                        serie = configFact.SerieFactura;
                        correlativo = configFact.CorrelativoFactura + 1;
                        configFact.CorrelativoFactura = correlativo; break;
                    default:
                        serie = configFact.SerieNotaVenta;
                        correlativo = configFact.CorrelativoNotaVenta + 1;
                        configFact.CorrelativoNotaVenta = correlativo; break;
                }

                var venta = new Venta
                {
                    NumeroVenta        = VentaRepository.GenerarNumeroVenta(),
                    Fecha              = DateTime.Now.Date,
                    Hora               = DateTime.Now.TimeOfDay,
                    ClienteID          = _clienteID,
                    TipoComprobante    = tipoComp,
                    Serie              = serie,
                    Numero             = correlativo.ToString("D8"),
                    SubTotal           = subTotal,
                    Descuento          = descuento,
                    IGV                = igv,
                    TipoIGV            = cboIGV.SelectedIndex,
                    BaseImponible      = baseImp,
                    Total              = total,
                    MetodoPago         = _pagoMetodo,
                    MontoEfectivo      = _pagoMontoEfectivo,
                    MontoYape          = _pagoMontoYape,
                    MontoTarjeta       = _pagoMontoTarjeta,
                    MontoTransferencia = _pagoMontoTransferencia,
                    Estado             = _pagoMetodo == "CREDITO" ? "CREDITO" : "COMPLETADA",
                    CajaID             = _cajaID,
                    UsuarioID          = SesionActual.Usuario.UsuarioID
                };

                var detalles = new List<VentaDetalle>();
                foreach (var item in _cartItems)
                {
                    if (item.CantidadUnidades <= 0) continue;
                    detalles.Add(new VentaDetalle
                    {
                        ProductoID             = item.ProductoID,
                        ProductoPresentacionID = item.PresentacionID,
                        Cantidad               = item.CantPres,
                        PrecioUnitario         = item.PrecioUnitario,
                        Subtotal               = item.Total,
                        CantidadUnidadesBase   = item.Cantidad
                    });
                }

                if (VentaRepository.Crear(venta, detalles))
                {
                    EmpresaRepository.GuardarConfiguracionFacturacion(configFact);
                    _ultimaVentaID = VentaRepository.ObtenerVentaIDPorNumero(venta.NumeroVenta);
                    SonidoHelper.ReproducirVenta();
                    LimpiarVenta();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar venta: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetearBtnCobrar();
            }
        }

        private void ResetearBtnCobrar()
        {
            _esperandoConfirmacion = false;
            _pagoMetodo            = "";
            btnCobrar.Text         = "✓  COBRAR";
            btnCobrar.BackColor    = Color.FromArgb(39, 174, 96);
        }

        private bool ValidarVenta()
        {
            if (_cartItems.Count == 0)
            { MessageBox.Show("Agrega productos al carrito", "Validación"); return false; }
            if (!TryParseMonto(txtTotalPagar.Text, out decimal total) || total <= 0)
            { MessageBox.Show("El total de la venta es inválido", "Validación"); return false; }
            return true;
        }

        // ══════════════════════════════════════════════════════════════
        // VISTA PREVIA / IMPRIMIR
        // ══════════════════════════════════════════════════════════════

        // ══════════════════════════════════════════════════════════════
        // CANCELAR / HISTORIAL / LIMPIAR
        // ══════════════════════════════════════════════════════════════

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (_cartItems.Count > 0 &&
                MessageBox.Show("¿Cancelar venta actual?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                LimpiarVenta();
        }

        private void BtnHistorial_Click(object sender, EventArgs e)
        {
            new FormHistorialVentas().ShowDialog();
        }

        private void LimpiarVenta()
        {
            ResetearBtnCobrar();
            _cartItems.Clear();
            RenderCarrito();
            txtSubtotal.Text   = "0.00";
            txtIGV.Text        = "0.00";
            txtDescuento.Text  = "0.00";
            txtTotalPagar.Text = "0.00";
            cboIGV.SelectedIndex = 0;
            cmbClientes.SelectedIndex = 0;
            var cg = ClienteRepository.ObtenerClienteGeneral();
            _clienteID = cg != null ? cg.ClienteID : 1;
            _clienteNombre = "CLIENTE GENERAL";
            _clienteDoc    = "00000000";
        }

        // ══════════════════════════════════════════════════════════════
        // LISTA – COMBOBOX PRESENTACIÓN
        // ══════════════════════════════════════════════════════════════

        private void DgvProductos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!(e.Control is ComboBox combo)) return;
            combo.DropDown  -= ComboBox_DropDown;
            combo.DrawItem  -= ComboBox_DrawItem;
            combo.BackColor  = Color.White;
            combo.ForeColor  = Color.Black;
            combo.FlatStyle  = FlatStyle.Popup;
            combo.DrawMode   = DrawMode.OwnerDrawFixed;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.DropDown  += ComboBox_DropDown;
            combo.DrawItem  += ComboBox_DrawItem;
        }

        private void ComboBox_DropDown(object sender, EventArgs e)
        {
            if (sender is ComboBox c) { c.BackColor = Color.White; c.ForeColor = Color.Black; }
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || !(sender is ComboBox combo)) return;
            e.DrawBackground();
            bool sel = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            using (var bb = new SolidBrush(sel ? Color.FromArgb(235, 239, 255) : Color.White))
            using (var fb = new SolidBrush(sel ? Color.FromArgb(45, 52, 54) : Color.Black))
            {
                e.Graphics.FillRectangle(bb, e.Bounds);
                e.Graphics.DrawString(combo.GetItemText(combo.Items[e.Index]), e.Font, fb, e.Bounds);
            }
            e.DrawFocusRectangle();
        }

        private void DgvProductos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvProductos.IsCurrentCellDirty)
                dgvProductos.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DgvProductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvProductos.Columns[e.ColumnIndex].Name != "colPresentacion") return;
            try
            {
                var item = (dynamic)dgvProductos.Rows[e.RowIndex].Tag;
                var combo = dgvProductos.Rows[e.RowIndex].Cells["colPresentacion"] as DataGridViewComboBoxCell;
                if (combo?.Value == null) return;
                int presID = Convert.ToInt32(combo.Value);
                List<ProductoPresentacion> pres = item.Presentaciones;
                var p = pres.Find(x => x.ProductoPresentacionID == presID);
                if (p != null)
                    dgvProductos.Rows[e.RowIndex].Cells["colPrecioUnit"].Value = "S/ " + p.PrecioVenta.ToString("N2");
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        // ══════════════════════════════════════════════════════════════
        // UTILIDADES
        // ══════════════════════════════════════════════════════════════

        private bool TryParseMonto(string valor, out decimal monto)
        {
            valor = (valor ?? "").Trim().Replace("S/ ", "").Replace("S/", "");
            return decimal.TryParse(valor, NumberStyles.Number, CultureInfo.CurrentCulture, out monto)
                || decimal.TryParse(valor, NumberStyles.Number, CultureInfo.InvariantCulture, out monto);
        }
    }
}
