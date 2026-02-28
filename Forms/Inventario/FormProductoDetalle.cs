using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;

namespace SistemaPOS.Forms.Inventario
{
    public partial class FormProductoDetalle : Form
    {
        private int? _productoID = null;
        private List<ProductoPresentacion> _presentaciones = new List<ProductoPresentacion>();
        private byte[] _imagenProducto = null;

        public FormProductoDetalle(int? productoID = null)
        {
            InitializeComponent();
            _productoID = productoID;
            ConfigurarEventos();
            CargarCombos();
            ConfigurarDataGridView();

            if (_productoID.HasValue)
            {
                // Modo edición
                this.Text = "Editar Producto";
                CargarDatosProducto(_productoID.Value);
            }
            else
            {
                // Modo nuevo
                txtCodigo.Text = ProductoRepository.GenerarCodigoProducto();
            }
        }

        private void ConfigurarEventos()
        {
            btnAgregarPres.Click += BtnAgregarPres_Click;
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            btnCargar.Click += BtnCargar_Click;
            btnQuitar.Click += BtnQuitar_Click;
            dgvPresentaciones.CellClick += DgvPresentaciones_CellClick;
        }

        private void ConfigurarDataGridView()
        {
            dgvPresentaciones.AutoGenerateColumns = false;
            dgvPresentaciones.AllowUserToAddRows = false;
        }

        private void CargarCombos()
        {
            // Categorías
            cmbCategoria.DataSource = CategoriaRepository.ObtenerTodas();
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "CategoriaID";
            cmbCategoria.SelectedIndex = -1;

            // Unidades Base
            cmbUnidadBase.DataSource = UnidadRepository.ObtenerTodas();
            cmbUnidadBase.DisplayMember = "Nombre";
            cmbUnidadBase.ValueMember = "UnidadID";
            cmbUnidadBase.SelectedIndex = -1;

            // Proveedores
            var proveedores = ProveedorRepository.ObtenerTodos();
            proveedores.Insert(0, new Proveedor { ProveedorID = 0, RazonSocial = "-- Sin proveedor --" });
            cmbProveedor.DataSource = proveedores;
            cmbProveedor.DisplayMember = "RazonSocial";
            cmbProveedor.ValueMember = "ProveedorID";
            cmbProveedor.SelectedIndex = 0;

            // Presentaciones
            cmbPresentacion.DataSource = PresentacionRepository.ObtenerTodas();
            cmbPresentacion.DisplayMember = "Nombre";
            cmbPresentacion.ValueMember = "PresentacionID";
            cmbPresentacion.SelectedIndex = -1;
        }

        private void CargarDatosProducto(int productoID)
        {
            try
            {
                var producto = ProductoRepository.ObtenerPorID(productoID);

                if (producto == null)
                {
                    MessageBox.Show("Producto no encontrado");
                    this.Close();
                    return;
                }

                txtCodigo.Text = producto.Codigo;
                txtProducto.Text = producto.Nombre;
                cmbCategoria.SelectedValue = producto.CategoriaID;
                cmbUnidadBase.SelectedValue = producto.UnidadBaseID;
                txtStock.Text = producto.StockTotal.ToString();
                txtStockMinimo.Text = producto.StockMinimo.ToString();
                txtStockMaximo.Text = producto.StockMaximo.ToString();

                if (producto.ProveedorID.HasValue)
                    cmbProveedor.SelectedValue = producto.ProveedorID.Value;

                if (producto.Imagen != null)
                {
                    using (var ms = new System.IO.MemoryStream(producto.Imagen))
                        pbImagenProducto.Image = new System.Drawing.Bitmap(ms);
                    pbImagenProducto.SizeMode = PictureBoxSizeMode.Zoom;
                    _imagenProducto = producto.Imagen;
                }

                // Cargar presentaciones
                var presentaciones = ProductoRepository.ObtenerPresentaciones(productoID);
                _presentaciones = presentaciones;

                foreach (var pres in presentaciones)
                {
                    // Obtener nombre de presentación
                    string nombrePres = "";
                    using (var conn = DatabaseConnection.GetConnection())
                    {
                        var cmd = new System.Data.SQLite.SQLiteCommand("SELECT Nombre FROM Presentaciones WHERE PresentacionID = @ID", conn);
                        cmd.Parameters.AddWithValue("@ID", pres.PresentacionID);
                        nombrePres = cmd.ExecuteScalar()?.ToString() ?? "";
                    }

                    int index = dgvPresentaciones.Rows.Add();
                    var row = dgvPresentaciones.Rows[index];
                    row.Cells["colPresentacion"].Value = nombrePres;
                    row.Cells["colCantidad"].Value = pres.CantidadUnidades;
                    row.Cells["colUnidadBase"].Value = cmbUnidadBase.Text;
                    row.Cells["colCosto"].Value = pres.CostoBase.ToString("N2");
                    row.Cells["colPrecio"].Value = pres.PrecioVenta.ToString("N2");
                    row.Cells["colGanancia"].Value = (pres.Ganancia ?? 0).ToString("N2") + "%";
                    row.Cells["colIGVPres"].Value = pres.PrecioIncluyeIGV ? "Sí" : "No";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                ofd.Title = "Seleccionar imagen del producto";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pbImagenProducto.Image = System.Drawing.Image.FromFile(ofd.FileName);
                        pbImagenProducto.SizeMode = PictureBoxSizeMode.Zoom;

                        // Convertir a byte[]
                        using (var ms = new System.IO.MemoryStream())
                        {
                            pbImagenProducto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            _imagenProducto = ms.ToArray();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar imagen: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            pbImagenProducto.Image = null;
            _imagenProducto = null;
        }

        private void BtnAgregarPres_Click(object sender, EventArgs e)
        {
            if (!ValidarPresentacion())
                return;

            int presentacionID = Convert.ToInt32(cmbPresentacion.SelectedValue);
            string nombrePresentacion = cmbPresentacion.Text;
            decimal cantidad = ParseDecimalOrZero(txtCantidad.Text);
            decimal costo = ParseDecimalOrZero(txtCostoBase.Text);
            decimal precio = ParseDecimalOrZero(txtPrecio.Text);
            decimal ganancia = ((precio - costo) / costo) * 100;

            // Agregar a la lista
            _presentaciones.Add(new ProductoPresentacion
            {
                PresentacionID = presentacionID,
                CantidadUnidades = cantidad,
                CostoBase = costo,
                PrecioVenta = precio,
                Ganancia = ganancia,
                PrecioIncluyeIGV = chkPrecioIncluyeIGV.Checked
            });

            // Agregar a la grilla
            int index = dgvPresentaciones.Rows.Add();
            var row = dgvPresentaciones.Rows[index];
            row.Cells["colPresentacion"].Value = nombrePresentacion;
            row.Cells["colCantidad"].Value = cantidad;
            row.Cells["colUnidadBase"].Value = cmbUnidadBase.Text;
            row.Cells["colCosto"].Value = costo.ToString("N2");
            row.Cells["colPrecio"].Value = precio.ToString("N2");
            row.Cells["colGanancia"].Value = ganancia.ToString("N2") + "%";
            row.Cells["colIGVPres"].Value = chkPrecioIncluyeIGV.Checked ? "Sí" : "No";

            // Limpiar campos
            cmbPresentacion.SelectedIndex = -1;
            txtCantidad.Clear();
            txtCostoBase.Clear();
            txtPrecio.Clear();
            chkPrecioIncluyeIGV.Checked = false;
        }

        private void DgvPresentaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvPresentaciones.Columns[e.ColumnIndex].Name == "colEliminar")
            {
                var resultado = MessageBox.Show(
                    "¿Eliminar esta presentación?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    _presentaciones.RemoveAt(e.RowIndex);
                    dgvPresentaciones.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarProducto())
                return;

            try
            {
                var producto = new Producto
                {
                    Codigo = txtCodigo.Text.Trim(),
                    Nombre = txtProducto.Text.Trim(),
                    CategoriaID = Convert.ToInt32(cmbCategoria.SelectedValue),
                    UnidadBaseID = Convert.ToInt32(cmbUnidadBase.SelectedValue),
                    StockTotal = ParseDecimalOrZero(txtStock.Text),
                    StockMinimo = ParseDecimalOrZero(txtStockMinimo.Text),
                    StockMaximo = ParseDecimalOrZero(txtStockMaximo.Text),
                    ProveedorID = Convert.ToInt32(cmbProveedor.SelectedValue) > 0
                        ? Convert.ToInt32(cmbProveedor.SelectedValue)
                        : (int?)null,
                    Imagen = _imagenProducto
                };

                bool resultado;
                string mensaje;

                if (_productoID.HasValue)
                {
                    // Modo edición
                    producto.ProductoID = _productoID.Value;
                    resultado = ProductoRepository.Actualizar(producto, _presentaciones);
                    mensaje = "Producto actualizado exitosamente";
                }
                else
                {
                    // Modo nuevo
                    resultado = ProductoRepository.Crear(producto, _presentaciones);
                    mensaje = "Producto guardado exitosamente";
                }

                if (resultado)
                {
                    MessageBox.Show(mensaje, "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarProducto()
        {
            if (string.IsNullOrWhiteSpace(txtProducto.Text))
            {
                MessageBox.Show("Ingresa el nombre del producto", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProducto.Focus();
                return false;
            }

            if (cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona una categoría", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbUnidadBase.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona una unidad base", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!TryParseDecimal(txtStock.Text, out decimal stock) || stock < 0)
            {
                MessageBox.Show("Ingresa un stock válido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return false;
            }

            if (!TryParseDecimal(txtStockMinimo.Text, out decimal stockMin) || stockMin < 0)
            {
                MessageBox.Show("Ingresa un stock mínimo válido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStockMinimo.Focus();
                return false;
            }

            if (!TryParseDecimal(txtStockMaximo.Text, out decimal stockMax) || stockMax < 0)
            {
                MessageBox.Show("Ingresa un stock máximo válido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStockMaximo.Focus();
                return false;
            }

            if (_presentaciones.Count == 0)
            {
                MessageBox.Show("Agrega al menos una presentación", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidarPresentacion()
        {
            if (cmbPresentacion.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona una presentación", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!TryParseDecimal(txtCantidad.Text, out decimal cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingresa una cantidad válida", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return false;
            }

            if (!TryParseDecimal(txtCostoBase.Text, out decimal costo) || costo <= 0)
            {
                MessageBox.Show("Ingresa un costo válido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCostoBase.Focus();
                return false;
            }

            if (!TryParseDecimal(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Ingresa un precio válido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }

            return true;
        }

        private static bool TryParseDecimal(string texto, out decimal valor)
        {
            if (decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out valor))
                return true;

            return decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out valor);
        }

        private static decimal ParseDecimalOrZero(string texto)
        {
            return TryParseDecimal(texto, out decimal valor) ? valor : 0m;
        }
    }
}
