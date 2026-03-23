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
        private bool _actualizandoDesdeEdicion;
        private decimal _tasaIGV = 0.18m;
        private decimal _rawCartTotal = 0m;
        private bool _vistaCards = true;
        private int _ultimaVentaID = 0;

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
            CargarCards();
            CargarClientes();

            // Restringir descuentos
            var usr = SesionActual.Usuario;
            bool puedeDescontar = usr != null && (usr.PermisoDescuentos || usr.RolID == 1);
            txtDescuento.ReadOnly = !puedeDescontar;
            txtDescuento.BackColor = puedeDescontar
                ? Color.FromArgb(248, 249, 250) : Color.FromArgb(235, 236, 238);

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

            // carrito
            dgvCarritoVenta.CellClick += DgvCarritoVenta_CellClick;
            dgvCarritoVenta.CellEndEdit += DgvCarritoVenta_CellEndEdit;
            dgvCarritoVenta.CellFormatting += DgvCarritoVenta_CellFormatting;

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

            dgvCarritoVenta.AutoGenerateColumns = false;
            dgvCarritoVenta.AllowUserToAddRows = false;
            dgvCarritoVenta.SelectionMode = DataGridViewSelectionMode.CellSelect;
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
            else
            { MessageBox.Show("No hay caja abierta", "Error"); this.Close(); return; }

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
            AgregarChipCategoria("Todos", true);
        }

        private void AgregarChipCategoria(string nombre, bool activo)
        {
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
            };
            btn.FlatAppearance.BorderColor = activo
                ? Color.FromArgb(50, 82, 220) : Color.FromArgb(200, 210, 230);
            btn.FlatAppearance.BorderSize = 1;
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
                var productos = ProductoRepository.BuscarProductos(busqueda);
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
                var productos = ProductoRepository.BuscarProductos(busqueda);
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
            decimal enCarrito = 0;
            foreach (DataGridViewRow r in dgvCarritoVenta.Rows)
            {
                if (r.Tag == null) continue;
                var it = (dynamic)r.Tag;
                if (it.ProductoID == productoID)
                {
                    var v = r.Cells["colCantidad"].Value;
                    enCarrito += (v != null && decimal.TryParse(v.ToString(), out decimal cv)) ? cv : 0m;
                }
            }

            var prod = ProductoRepository.ObtenerPorID(productoID);
            decimal stock = prod?.StockTotal ?? 0;
            decimal unidades = presentacion.CantidadUnidades;

            if (enCarrito + unidades > stock)
            {
                MessageBox.Show(
                    $"Stock insuficiente para '{nombreProducto}'.\nDisponible: {stock:N2}  |  En carrito: {enCarrito:N2}",
                    "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si ya existe en carrito, sumar
            foreach (DataGridViewRow r in dgvCarritoVenta.Rows)
            {
                if (r.Tag == null) continue;
                var it = (dynamic)r.Tag;
                if (it.ProductoID == productoID && it.PresentacionID == presentacion.ProductoPresentacionID)
                {
                    var v = r.Cells["colCantidad"].Value;
                    decimal cant = (v != null && decimal.TryParse(v.ToString(), out decimal cv)) ? cv : 0m;
                    r.Cells["colCantidad"].Value = cant + presentacion.CantidadUnidades;
                    ActualizarTotalFila(r.Index);
                    return;
                }
            }

            if (dgvCarritoVenta.Rows.Count == 0 && presentacion.PrecioIncluyeIGV && cboIGV.SelectedIndex == 0)
                cboIGV.SelectedIndex = 1;

            int idx = dgvCarritoVenta.Rows.Add();
            var row = dgvCarritoVenta.Rows[idx];
            string nomPres = ObtenerNombrePresentacion(presentacion.PresentacionID);

            row.Cells["colProductoDV"].Value   = nombreProducto;
            row.Cells["colPresentacionDV"].Value = nomPres;
            row.Cells["colCantidad"].Value     = presentacion.CantidadUnidades;
            row.Cells["colTotalDV"].Value      = "S/ " + presentacion.PrecioVenta.ToString("N2");

            row.Tag = new
            {
                ProductoID      = productoID,
                PresentacionID  = presentacion.ProductoPresentacionID,
                PrecioUnitario  = presentacion.PrecioVenta,
                CantidadUnidades = presentacion.CantidadUnidades,
                UnidadSimbolo   = unidadSimbolo,
                PrecioIncluyeIGV = presentacion.PrecioIncluyeIGV
            };

            CalcularTotales();
        }

        // ══════════════════════════════════════════════════════════════
        // CARRITO – EDICIÓN / ELIMINAR
        // ══════════════════════════════════════════════════════════════

        private void DgvCarritoVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvCarritoVenta.Rows[e.RowIndex];
            string col = dgvCarritoVenta.Columns[e.ColumnIndex].Name;

            if (col == "colAumentar")
            {
                var v = row.Cells["colCantidad"].Value;
                decimal cant = (v != null && decimal.TryParse(v.ToString(), out decimal cv)) ? cv : 0m;
                decimal step = (decimal)((dynamic)row.Tag).CantidadUnidades;
                row.Cells["colCantidad"].Value = cant + step;
                ActualizarTotalFila(e.RowIndex);
            }
            else if (col == "colDisminuir")
            {
                var v = row.Cells["colCantidad"].Value;
                decimal cant = (v != null && decimal.TryParse(v.ToString(), out decimal cv)) ? cv : 0m;
                decimal step = (decimal)((dynamic)row.Tag).CantidadUnidades;
                if (cant > step)
                { row.Cells["colCantidad"].Value = cant - step; ActualizarTotalFila(e.RowIndex); }
                else if (cant > 0.01m)
                { row.Cells["colCantidad"].Value = Math.Max(0.01m, cant - 0.1m); ActualizarTotalFila(e.RowIndex); }
            }
            else if (col == "colEliminar")
            {
                dgvCarritoVenta.Rows.RemoveAt(e.RowIndex);
                CalcularTotales();
            }
        }

        private void DgvCarritoVenta_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCarritoVenta.Columns[e.ColumnIndex].Name != "colCantidad") return;
            var row = dgvCarritoVenta.Rows[e.RowIndex];
            if (row.Tag == null || e.Value == null) return;
            if (decimal.TryParse(e.Value.ToString(), out decimal cant))
            {
                var item = (dynamic)row.Tag;
                string u = item.UnidadSimbolo ?? "";
                e.Value = cant.ToString("0.00#") + (string.IsNullOrEmpty(u) ? "" : " " + u);
                e.FormattingApplied = true;
            }
        }

        private void DgvCarritoVenta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _actualizandoDesdeEdicion) return;
            var row = dgvCarritoVenta.Rows[e.RowIndex];
            if (row.Tag == null) return;
            var item = (dynamic)row.Tag;
            decimal precioUnit = item.PrecioUnitario;
            string colName = dgvCarritoVenta.Columns[e.ColumnIndex].Name;

            _actualizandoDesdeEdicion = true;
            try
            {
                if (colName == "colCantidad")
                {
                    string s = row.Cells["colCantidad"].Value?.ToString() ?? "";
                    s = new string(s.Where(c => char.IsDigit(c) || c == '.' || c == ',').ToArray());
                    decimal cantUnidades = (decimal)item.CantidadUnidades;
                    if (decimal.TryParse(s, out decimal cantBase) && cantBase > 0)
                    {
                        cantBase = Math.Round(cantBase, 3);
                        row.Cells["colCantidad"].Value = cantBase;
                        row.Cells["colTotalDV"].Value  = "S/ " + (cantBase / cantUnidades * precioUnit).ToString("N2");
                    }
                    else
                    {
                        row.Cells["colCantidad"].Value = cantUnidades;
                        row.Cells["colTotalDV"].Value  = "S/ " + precioUnit.ToString("N2");
                    }
                    CalcularTotales();
                }
                else if (colName == "colTotalDV")
                {
                    string s = (row.Cells["colTotalDV"].Value?.ToString() ?? "0").Replace("S/", "").Replace("s/", "").Trim();
                    decimal cantUnidades = (decimal)item.CantidadUnidades;
                    if (decimal.TryParse(s, out decimal total) && total > 0 && precioUnit > 0)
                    {
                        decimal cantPres = Math.Round(total / precioUnit, 3);
                        row.Cells["colCantidad"].Value = cantPres * cantUnidades;
                        row.Cells["colTotalDV"].Value  = "S/ " + total.ToString("N2");
                    }
                    else
                    {
                        row.Cells["colCantidad"].Value = cantUnidades;
                        row.Cells["colTotalDV"].Value  = "S/ " + precioUnit.ToString("N2");
                    }
                    CalcularTotales();
                }
            }
            finally { _actualizandoDesdeEdicion = false; }
        }

        private void ActualizarTotalFila(int rowIndex)
        {
            var row = dgvCarritoVenta.Rows[rowIndex];
            var v = row.Cells["colCantidad"].Value;
            decimal cantBase = (v != null && decimal.TryParse(v.ToString(), out decimal cv)) ? cv : 0m;
            var item = (dynamic)row.Tag;
            decimal cantUnidades = (decimal)item.CantidadUnidades;
            if (cantUnidades <= 0) return;
            decimal total = (cantBase / cantUnidades) * (decimal)item.PrecioUnitario;
            row.Cells["colTotalDV"].Value = "S/ " + total.ToString("N2");
            CalcularTotales();
        }

        // ══════════════════════════════════════════════════════════════
        // TOTALES
        // ══════════════════════════════════════════════════════════════

        private void CalcularTotales()
        {
            decimal rawTotal = 0m;
            foreach (DataGridViewRow row in dgvCarritoVenta.Rows)
            {
                if (row.Tag == null) continue;
                if (TryParseMonto(row.Cells["colTotalDV"].Value?.ToString() ?? "0", out decimal f))
                    rawTotal += f;
            }
            _rawCartTotal = rawTotal;

            int tipo = cboIGV.SelectedIndex;
            decimal totalBase, totalIGV, total;
            if (tipo == 1)
            { totalBase = Math.Round(rawTotal / (1m + _tasaIGV), 2); totalIGV = rawTotal - totalBase; total = rawTotal; }
            else if (tipo == 2)
            { totalBase = rawTotal; totalIGV = Math.Round(rawTotal * _tasaIGV, 2); total = rawTotal + totalIGV; }
            else
            { totalBase = rawTotal; totalIGV = 0m; total = rawTotal; }

            decimal desc = decimal.TryParse(txtDescuento.Text, out decimal d) ? d : 0m;
            if (desc < 0) desc = 0m;
            if (desc > total) desc = total;
            total -= desc;

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
            if (!ValidarVenta()) return;
            if (!TryParseMonto(txtTotalPagar.Text, out decimal total)) return;
            if (!TryParseMonto(txtSubtotal.Text,   out decimal baseImp)) return;
            if (!TryParseMonto(txtIGV.Text,        out decimal igv)) return;
            decimal subTotal = _rawCartTotal;

            using (var formPago = new FormPago(total))
            {
                if (formPago.ShowDialog(this) != DialogResult.OK) return;

                if (formPago.MetodoPago == "CREDITO" && (_clienteID <= 1))
                {
                    MessageBox.Show("No se puede vender a crédito sin un cliente registrado.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbClientes.Focus(); return;
                }

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
                        IGV                = igv,
                        TipoIGV            = cboIGV.SelectedIndex,
                        BaseImponible      = baseImp,
                        Total              = total,
                        MetodoPago         = formPago.MetodoPago,
                        MontoEfectivo      = formPago.MontoEfectivo,
                        MontoYape          = formPago.MontoYape,
                        MontoTarjeta       = formPago.MontoTarjeta,
                        MontoTransferencia = formPago.MontoTransferencia,
                        Estado             = formPago.MetodoPago == "CREDITO" ? "CREDITO" : "COMPLETADA",
                        CajaID             = _cajaID,
                        UsuarioID          = SesionActual.Usuario.UsuarioID
                    };

                    var detalles = new List<VentaDetalle>();
                    foreach (DataGridViewRow row in dgvCarritoVenta.Rows)
                    {
                        if (row.IsNewRow) continue;
                        var item = (dynamic)row.Tag;
                        var cv = row.Cells["colCantidad"].Value;
                        decimal cantBase = (cv != null && decimal.TryParse(cv.ToString(), out decimal p)) ? p : 0m;
                        decimal cantUnidades = (decimal)item.CantidadUnidades;
                        if (cantUnidades <= 0) continue;
                        decimal cantPres = cantBase / cantUnidades;
                        detalles.Add(new VentaDetalle
                        {
                            ProductoID             = item.ProductoID,
                            ProductoPresentacionID = item.PresentacionID,
                            Cantidad               = cantPres,
                            PrecioUnitario         = item.PrecioUnitario,
                            Subtotal               = cantPres * (decimal)item.PrecioUnitario,
                            CantidadUnidadesBase   = cantBase
                        });
                    }

                    if (VentaRepository.Crear(venta, detalles))
                    {
                        EmpresaRepository.GuardarConfiguracionFacturacion(configFact);
                        _ultimaVentaID = VentaRepository.ObtenerVentaIDPorNumero(venta.NumeroVenta);

                        decimal vuelto = formPago.MetodoPago == "EFECTIVO"
                            ? formPago.Recibido - venta.Total : 0m;

                        MostrarTicketVenta(_ultimaVentaID, formPago.Recibido, vuelto);
                        LimpiarVenta();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al procesar venta: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarVenta()
        {
            if (dgvCarritoVenta.Rows.Count == 0)
            { MessageBox.Show("Agrega productos al carrito", "Validación"); return false; }
            if (!TryParseMonto(txtTotalPagar.Text, out decimal total) || total <= 0)
            { MessageBox.Show("El total de la venta es inválido", "Validación"); return false; }
            return true;
        }

        // ══════════════════════════════════════════════════════════════
        // VISTA PREVIA / IMPRIMIR
        // ══════════════════════════════════════════════════════════════

        private void BtnPreviewVenta_Click(object sender, EventArgs e)
        {
            // Post-venta: mostrar ticket de la venta recién guardada
            if (_ultimaVentaID > 0)
            {
                MostrarTicketVenta(_ultimaVentaID, 0m, 0m);
                return;
            }

            // Pre-venta: construir DataTable desde el carrito actual
            if (dgvCarritoVenta.Rows.Count == 0)
            {
                MessageBox.Show("Agrega productos al carrito para ver la vista previa.",
                    "Vista previa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var dt = new DataTable("DetalleVenta");
                dt.Columns.Add("Numero",         typeof(string));
                dt.Columns.Add("Producto",        typeof(string));
                dt.Columns.Add("Presentacion",    typeof(string));
                dt.Columns.Add("Cantidad",        typeof(decimal));
                dt.Columns.Add("PrecioUnitario",  typeof(decimal));
                dt.Columns.Add("SubTotal",        typeof(decimal));

                int num = 1;
                foreach (DataGridViewRow row in dgvCarritoVenta.Rows)
                {
                    if (row.IsNewRow) continue;
                    var item = (dynamic)row.Tag;
                    var cv = row.Cells["colCantidad"].Value;
                    decimal cantBase = (cv != null && decimal.TryParse(cv.ToString(), out decimal pb)) ? pb : 0m;
                    decimal cantUnidades = (decimal)item.CantidadUnidades;
                    if (cantUnidades <= 0) continue;
                    decimal cantPres = cantBase / cantUnidades;
                    decimal precio   = (decimal)item.PrecioUnitario;
                    string nomPres   = (string)item.UnidadSimbolo;

                    dt.Rows.Add(
                        num++.ToString(),
                        row.Cells["colProductoDV"].Value?.ToString() ?? "",
                        nomPres,
                         cantBase,
                        precio,
                        cantPres * precio);
                }

                if (!decimal.TryParse(txtSubtotal.Text,   out decimal baseImp)) baseImp = 0;
                if (!decimal.TryParse(txtIGV.Text,        out decimal igvPrev)) igvPrev = 0;
                if (!decimal.TryParse(txtDescuento.Text,  out decimal desc))    desc    = 0;
                if (!decimal.TryParse(txtTotalPagar.Text, out decimal total))   total   = 0;

                var parametros = ReportHelper.GetCompanyParameters();
                parametros["pTipoComprobante"] = cmbTipoComprobante.Text;
                parametros["pNumeroVenta"]     = "";
                parametros["pFecha"]           = DateTime.Now.ToString("dd/MM/yyyy");
                parametros["pHora"]            = DateTime.Now.ToString("HH:mm");
                parametros["pEstado"]          = "";
                parametros["pMetodoPago"]      = "-";
                parametros["pSubTotal"]        = baseImp.ToString("N2");
                parametros["pDescuento"]       = desc.ToString("N2");
                parametros["pIGV"]             = igvPrev.ToString("N2");
                parametros["pTotal"]           = total.ToString("N2");
                parametros["pCliente"]         = _clienteNombre;
                parametros["pDocCliente"]      = _clienteDoc;
                parametros["pEncargado"]       = SesionActual.Usuario?.NombreCompleto ?? SesionActual.Usuario?.NombreUsuario ?? "";

                using (var preview = new FormPreviewTicket(dt, parametros))
                    preview.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en vista previa: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga los datos del ticket desde la BD y abre FormPreviewTicket.
        /// Si recibido > 0 agrega montoRecibido/vuelto al ticket.
        /// </summary>
        private void MostrarTicketVenta(int ventaID, decimal recibido, decimal vuelto)
        {
            try
            {
                var parametros = ReportHelper.GetCompanyParameters();
                var dt = ReportDataSourceHelper.ObtenerDatosTicketVenta(ventaID, parametros);

                if (recibido > 0)
                    parametros["pMontoRecibido"] = recibido.ToString("N2");
                if (vuelto > 0)
                    parametros["pVuelto"] = vuelto.ToString("N2");

                // Mensaje pie desde configuración
                string pie1 = EmpresaRepository.ObtenerConfiguracion("TICKET_PIE_LINEA1", "¡Gracias por su compra!");
                string pie2 = EmpresaRepository.ObtenerConfiguracion("TICKET_PIE_LINEA2", "");
                if (!string.IsNullOrWhiteSpace(pie1)) parametros["pMensajePie1"] = pie1;
                if (!string.IsNullOrWhiteSpace(pie2)) parametros["pMensajePie2"] = pie2;

                using (var preview = new FormPreviewTicket(dt, parametros))
                    preview.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar ticket: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════
        // CANCELAR / HISTORIAL / LIMPIAR
        // ══════════════════════════════════════════════════════════════

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvCarritoVenta.Rows.Count > 0 &&
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
            dgvCarritoVenta.Rows.Clear();
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
