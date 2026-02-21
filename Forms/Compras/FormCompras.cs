using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Compras
{
    public partial class FormCompras : Form
    {
        private int _proveedorID;
        private List<Proveedor> _proveedores;
        private List<Producto> _productosCatalogo;
        private List<Producto> _productosEncontrados;
        private Producto _productoSeleccionado;
        private string _unidadBaseSimboloSeleccionado = "";
        private string _nombrePresentacionSeleccionada = "";
        private bool _actualizandoBusqueda;
        private Timer _timerBusqueda;

        public FormCompras()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            ConfigurarEventos();
            ConfigurarControles();
            InicializarFormulario();
        }

        private void ConfigurarEventos()
        {
            cmbBuscarProveedor.SelectionChangeCommitted += CmbBuscarProveedor_SelectionChangeCommitted;
            btnBuscarCliente.Click += BtnBuscarProveedor_Click;

            // TextUpdate solo se dispara cuando el usuario escribe, no al cambiar Items programaticamente
            cmbBuscarProducto.TextUpdate += CmbBuscarProducto_TextUpdate;
            // SelectionChangeCommitted solo se dispara cuando el usuario selecciona, no programaticamente
            cmbBuscarProducto.SelectionChangeCommitted += CmbBuscarProducto_SelectionChangeCommitted;
            cmbBuscarProducto.KeyDown += CmbBuscarProducto_KeyDown;
            cmbBuscarProducto.DropDown += CmbBuscarProducto_DropDown;

            cmbPresentacion.SelectedIndexChanged += CmbPresentacion_SelectedIndexChanged;
            numCantidad.ValueChanged += (_, __) => RecalcularDetalleSeleccionado();
            btnAgregarProducto.Click += BtnAgregarProducto_Click;
            dgvProductos.CellClick += DgvProductos_CellClick;
            chkIncluirIGV.CheckedChanged += ChkIncluirIGV_CheckedChanged;
            rbCredito.CheckedChanged += RbCredito_CheckedChanged;
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            txtCostoUnitario.KeyPress += TxtSoloNumeros_KeyPress;
            txtCostoUnitario.TextChanged += (_, __) => RecalcularDetalleSeleccionado();
            btnHistorial.Click += BtnHistorial_Click;

            // Timer para debounce de busqueda
            _timerBusqueda = new Timer();
            _timerBusqueda.Interval = 400;
            _timerBusqueda.Tick += (s, e) =>
            {
                _timerBusqueda.Stop();
                EjecutarBusquedaProducto();
            };
        }

        private void ConfigurarControles()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            txtSubtotal.ReadOnly = true;
            txtIGV.ReadOnly = true;
            txtTotal.ReadOnly = true;

            numCantidad.Minimum = 1;
            numCantidad.Maximum = 99999;
            numCantidad.DecimalPlaces = 0;
            numCantidad.Value = 1;

            cmbTipoComprobante.Items.Clear();
            cmbTipoComprobante.Items.Add("FACTURA");
            cmbTipoComprobante.Items.Add("BOLETA");
            cmbTipoComprobante.Items.Add("GUIA");
            cmbTipoComprobante.SelectedIndex = 0;

            AplicarConfiguracionSeguraCombo(cmbBuscarProveedor, false);
            AplicarConfiguracionSeguraCombo(cmbTipoComprobante, false);
            AplicarConfiguracionSeguraCombo(cmbPresentacion, false);
            AplicarConfiguracionSeguraCombo(cmbBuscarProducto, true);
            ValidarConfiguracionesCombo();

            dtpVencimiento.Visible = false;
            lblVencimiento.Visible = false;

            txtCantidadBase.ReadOnly = true;
            txtCantidadBase.Font = new System.Drawing.Font(txtCantidadBase.Font, System.Drawing.FontStyle.Bold);
            txtCostoUnitarioBase.ReadOnly = true;
            ActualizarEtiquetasUnidadBase(string.Empty);
        }

        private void InicializarFormulario()
        {
            _proveedorID = 0;
            _proveedores = ProveedorRepository.ObtenerTodos();
            _productosCatalogo = new List<Producto>();
            _productosEncontrados = new List<Producto>();
            _productoSeleccionado = null;
            lblNombreRazonSocial.Text = "";

            CargarProveedoresEnCombo();
            CargarCatalogoProductos();

            dtpFecha.Value = DateTime.Now;
            rbContado.Checked = true;

            txtSubtotal.Text = "0.00";
            txtIGV.Text = "0.00";
            txtTotal.Text = "0.00";
        }

        // ===== PROVEEDOR =====

        private void CargarProveedoresEnCombo()
        {
            cmbBuscarProveedor.Items.Clear();
            cmbBuscarProveedor.Items.Add("-- Seleccionar Proveedor --");
            foreach (var p in _proveedores)
                cmbBuscarProveedor.Items.Add(p.RazonSocial);
            cmbBuscarProveedor.SelectedIndex = 0;
        }

        private void CmbBuscarProveedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbBuscarProveedor.SelectedIndex <= 0)
            {
                _proveedorID = 0;
                lblNombreRazonSocial.Text = "";
                return;
            }

            var proveedor = _proveedores[cmbBuscarProveedor.SelectedIndex - 1];
            _proveedorID = proveedor.ProveedorID;
            lblNombreRazonSocial.Text = proveedor.RazonSocial;
        }

        private void BtnBuscarProveedor_Click(object sender, EventArgs e)
        {
            if (cmbBuscarProveedor.SelectedIndex > 0)
            {
                var proveedor = _proveedores[cmbBuscarProveedor.SelectedIndex - 1];
                _proveedorID = proveedor.ProveedorID;
                lblNombreRazonSocial.Text = proveedor.RazonSocial;
            }
        }

        // ===== PRODUCTO =====

        private void CmbBuscarProducto_TextUpdate(object sender, EventArgs e)
        {
            if (_actualizandoBusqueda) return;
            // Reiniciar timer en cada tecleo (debounce)
            _timerBusqueda.Stop();
            _timerBusqueda.Start();
        }

        private void EjecutarBusquedaProducto()
        {
            if (_actualizandoBusqueda) return;

            string busqueda = (cmbBuscarProducto.Text ?? string.Empty).Trim();
            if (_productosCatalogo == null || _productosCatalogo.Count == 0)
                CargarCatalogoProductos();

            List<Producto> filtrados;
            if (string.IsNullOrWhiteSpace(busqueda))
            {
                filtrados = new List<Producto>(_productosCatalogo);
            }
            else
            {
                filtrados = _productosCatalogo
                    .Where(p =>
                        (!string.IsNullOrWhiteSpace(p.Nombre) && p.Nombre.IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (!string.IsNullOrWhiteSpace(p.Codigo) && p.Codigo.IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0))
                    .ToList();
            }

            _productosEncontrados = filtrados;
            RefrescarComboProductosManteniendoTexto(filtrados, busqueda, true);
        }

        private void CmbBuscarProducto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_actualizandoBusqueda) return;
            if (cmbBuscarProducto.SelectedIndex < 0) return;
            if (_productosEncontrados == null || cmbBuscarProducto.SelectedIndex >= _productosEncontrados.Count) return;

            _productoSeleccionado = _productosEncontrados[cmbBuscarProducto.SelectedIndex];
            CargarPresentaciones(_productoSeleccionado.ProductoID);
            RecalcularDetalleSeleccionado();
        }

        private void CmbBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _timerBusqueda.Stop();
                if (_productosEncontrados == null || _productosEncontrados.Count == 0)
                    return;

                if (cmbBuscarProducto.SelectedIndex >= 0)
                {
                    _productoSeleccionado = _productosEncontrados[cmbBuscarProducto.SelectedIndex];
                }
                else
                {
                    _productoSeleccionado = _productosEncontrados[0];
                }
                CargarPresentaciones(_productoSeleccionado.ProductoID);

                _actualizandoBusqueda = true;
                cmbBuscarProducto.Text = $"{_productoSeleccionado.Codigo} - {_productoSeleccionado.Nombre}";
                _actualizandoBusqueda = false;

                cmbBuscarProducto.DroppedDown = false;
                cmbPresentacion.Focus();
                RecalcularDetalleSeleccionado();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void CmbBuscarProducto_DropDown(object sender, EventArgs e)
        {
            if (_actualizandoBusqueda) return;
            if (_productosCatalogo == null || _productosCatalogo.Count == 0)
                CargarCatalogoProductos();

            string busqueda = (cmbBuscarProducto.Text ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(busqueda))
            {
                _productosEncontrados = new List<Producto>(_productosCatalogo);
                RefrescarComboProductosManteniendoTexto(_productosEncontrados, busqueda, false);
            }
        }

        private void CargarPresentaciones(int productoID)
        {
            var presentaciones = ProductoRepository.ObtenerPresentaciones(productoID);
            string simboloUnidad = ObtenerSimboloUnidadBase(_productoSeleccionado.UnidadBaseID);
            _unidadBaseSimboloSeleccionado = simboloUnidad ?? string.Empty;
            ActualizarEtiquetasUnidadBase(_unidadBaseSimboloSeleccionado);

            var items = new List<object>();
            foreach (var pres in presentaciones)
            {
                string nombrePres = ObtenerNombrePresentacion(pres.PresentacionID);
                items.Add(new
                {
                    Display = $"{nombrePres} ({pres.CantidadUnidades} {simboloUnidad})",
                    Value = pres.ProductoPresentacionID,
                    Presentacion = pres
                });
            }

            cmbPresentacion.DataSource = items;
            cmbPresentacion.DisplayMember = "Display";
            cmbPresentacion.ValueMember = "Value";

            if (items.Count > 0)
            {
                cmbPresentacion.SelectedIndex = 0;
                var pres = ((dynamic)items[0]).Presentacion;
                txtCostoUnitario.Text = pres.CostoBase.ToString("N2");
                _nombrePresentacionSeleccionada = ObtenerNombrePresentacion((int)pres.PresentacionID);
            }

            ActualizarEtiquetasUnidadBase(_unidadBaseSimboloSeleccionado);
            RecalcularDetalleSeleccionado();
        }

        private void CmbPresentacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPresentacion.SelectedItem == null) return;

            try
            {
                var item = (dynamic)cmbPresentacion.SelectedItem;
                var pres = item.Presentacion;
                txtCostoUnitario.Text = ((decimal)pres.CostoBase).ToString("N2");
                _nombrePresentacionSeleccionada = ObtenerNombrePresentacion((int)pres.PresentacionID);
                ActualizarEtiquetasUnidadBase(_unidadBaseSimboloSeleccionado);
                RecalcularDetalleSeleccionado();
            }
            catch { }
        }

        private string ObtenerSimboloUnidadBase(int unidadBaseID)
        {
            return UnidadRepository.ObtenerSimboloPorID(unidadBaseID);
        }

        private string ObtenerNombrePresentacion(int presentacionID)
        {
            return PresentacionRepository.ObtenerNombrePorID(presentacionID);
        }

        // ===== GRILLA =====

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (_productoSeleccionado == null)
            {
                MessageBox.Show("Busca y selecciona un producto", "Validación");
                cmbBuscarProducto.Focus();
                return;
            }

            if (cmbPresentacion.SelectedItem == null)
            {
                MessageBox.Show("Selecciona una presentación", "Validación");
                return;
            }

            if (!decimal.TryParse(txtCostoUnitario.Text, out decimal costo) || costo <= 0)
            {
                MessageBox.Show("Ingresa un costo válido", "Validación");
                txtCostoUnitario.Focus();
                return;
            }

            var itemPres = (dynamic)cmbPresentacion.SelectedItem;
            var presentacion = itemPres.Presentacion;
            decimal factorPresentacion = (decimal)presentacion.CantidadUnidades;
            decimal cantidadPresentaciones = numCantidad.Value;
            decimal cantidadBase = cantidadPresentaciones * factorPresentacion;
            decimal costoUnitarioBase = factorPresentacion > 0 ? (costo / factorPresentacion) : 0m;
            decimal subtotal = cantidadBase * costoUnitarioBase;
            string unidad = _unidadBaseSimboloSeleccionado ?? string.Empty;
            string cantidadBaseTexto = string.IsNullOrWhiteSpace(unidad)
                ? $"{cantidadBase:N2}"
                : $"{cantidadBase:N2} {unidad}";
            string nombrePresentacion = ObtenerNombrePresentacion((int)presentacion.PresentacionID);
            string cantPresTexto = cantidadPresentaciones == Math.Floor(cantidadPresentaciones)
                ? $"{(int)cantidadPresentaciones} {nombrePresentacion}"
                : $"{cantidadPresentaciones:N2} {nombrePresentacion}";

            // Validación: advertir si el costo calculado por unidad base difiere > 50% del precio de referencia
            decimal refCostoBase = factorPresentacion > 0
                ? (decimal)presentacion.CostoBase / factorPresentacion
                : 0m;
            if (refCostoBase > 0 && costoUnitarioBase > 0)
            {
                decimal desviacion = Math.Abs(costoUnitarioBase - refCostoBase) / refCostoBase;
                if (desviacion > 0.5m)
                {
                    string unidadLabel = UiUnitsHelper.NormalizeUnit(unidad);
                    string advertencia =
                        $"El costo calculado por {unidadLabel} (S/ {costoUnitarioBase:N4}) " +
                        $"difiere más del 50% del precio de referencia (S/ {refCostoBase:N4}).\n\n" +
                        $"¿Deseas continuar de todas formas?";
                    var respuesta = MessageBox.Show(advertencia, "Advertencia de Costo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta != DialogResult.Yes) return;
                }
            }

            int index = dgvProductos.Rows.Add();
            DataGridViewRow row = dgvProductos.Rows[index];

            string unidadLabel2 = UiUnitsHelper.NormalizeUnit(unidad);
            row.Cells["colNumero"].Value = dgvProductos.Rows.Count;
            row.Cells["colProductoDV"].Value = _productoSeleccionado.Nombre;
            row.Cells["colPresentacionDV"].Value = cmbPresentacion.Text;
            row.Cells["colCantidadPres"].Value = cantPresTexto;
            row.Cells["colCantidadBase"].Value = cantidadBaseTexto;
            row.Cells["colCostoUnitario"].Value = $"S/ {costo:N2}/{nombrePresentacion}  (= S/ {costoUnitarioBase:N4}/{unidadLabel2})";
            row.Cells["colSubTotal"].Value = "S/ " + subtotal.ToString("N2");

            row.Tag = new
            {
                ProductoID = _productoSeleccionado.ProductoID,
                ProductoPresentacionID = (int)presentacion.ProductoPresentacionID,
                CostoPresentacion = costo,
                CostoUnitarioBase = costoUnitarioBase,
                FactorPresentacion = factorPresentacion,
                CantidadPresentaciones = cantidadPresentaciones,
                CantidadBase = cantidadBase,
                UnidadBaseSimbolo = unidad
            };

            LimpiarCamposProducto();
            CalcularTotales();
            cmbBuscarProducto.Focus();
        }

        private void LimpiarCamposProducto()
        {
            _actualizandoBusqueda = true;
            cmbBuscarProducto.Text = "";
            _actualizandoBusqueda = false;

            cmbPresentacion.DataSource = null;
            txtCostoUnitario.Clear();
            numCantidad.Value = 1;
            if (txtCantidadBase != null) txtCantidadBase.Text = "0.00";
            if (txtCostoUnitarioBase != null) txtCostoUnitarioBase.Text = "0.00";
            _unidadBaseSimboloSeleccionado = string.Empty;
            _nombrePresentacionSeleccionada = string.Empty;
            ActualizarEtiquetasUnidadBase(_unidadBaseSimboloSeleccionado);
            _productoSeleccionado = null;
        }

        private void DgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvProductos.Columns[e.ColumnIndex].Name == "colEliminar")
            {
                dgvProductos.Rows.RemoveAt(e.RowIndex);
                RenumerarFilas();
                CalcularTotales();
            }
        }

        private void RenumerarFilas()
        {
            for (int i = 0; i < dgvProductos.Rows.Count; i++)
                dgvProductos.Rows[i].Cells["colNumero"].Value = i + 1;
        }

        // ===== TOTALES =====

        private void CalcularTotales()
        {
            decimal subtotal = 0;

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                var item = (dynamic)row.Tag;
                subtotal += (decimal)item.CantidadBase * (decimal)item.CostoUnitarioBase;
            }

            decimal igv = chkIncluirIGV.Checked ? subtotal * 0.18m : 0;
            decimal total = subtotal + igv;

            txtSubtotal.Text = subtotal.ToString("N2");
            txtIGV.Text = igv.ToString("N2");
            txtTotal.Text = total.ToString("N2");
        }

        private void ChkIncluirIGV_CheckedChanged(object sender, EventArgs e)
        {
            CalcularTotales();
        }

        private void RbCredito_CheckedChanged(object sender, EventArgs e)
        {
            dtpVencimiento.Visible = rbCredito.Checked;
            lblVencimiento.Visible = rbCredito.Checked;
            if (rbCredito.Checked)
                dtpVencimiento.Value = DateTime.Now.AddDays(30);
        }

        // ===== GUARDAR =====

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            var confirmacion = MessageBox.Show(
                $"¿Registrar compra por S/ {txtTotal.Text}?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion != DialogResult.Yes) return;

            try
            {
                if (!TryParseDecimal(txtSubtotal.Text, out decimal subTotal)
                    || !TryParseDecimal(txtIGV.Text, out decimal igv)
                    || !TryParseDecimal(txtTotal.Text, out decimal total))
                {
                    MessageBox.Show("No se pudo interpretar los totales de la compra.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var compra = new Compra
                {
                    NumeroCompra = CompraRepository.GenerarNumeroCompra(),
                    Fecha = dtpFecha.Value.Date,
                    Hora = DateTime.Now.TimeOfDay,
                    ProveedorID = _proveedorID,
                    TipoComprobante = cmbTipoComprobante.Text,
                    Serie = cmbTipoComprobante.Text == "FACTURA" ? "F001" : (cmbTipoComprobante.Text == "BOLETA" ? "B001" : "G001"),
                    Numero = txtNumero.Text.Trim(),
                    IncluyeIGV = chkIncluirIGV.Checked,
                    SubTotal = subTotal,
                    IGV = igv,
                    Total = total,
                    MetodoPago = rbContado.Checked ? "EFECTIVO" : "CREDITO",
                    Estado = rbCredito.Checked ? "CREDITO" : "COMPLETADA",
                    UsuarioID = SesionActual.Usuario.UsuarioID,
                    Observaciones = txtObservaciones.Text.Trim()
                };

                var detalles = new List<CompraDetalle>();

                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    var item = (dynamic)row.Tag;
                    decimal cantidadPresentaciones = (decimal)item.CantidadPresentaciones;
                    decimal cantidadBase = (decimal)item.CantidadBase;
                    decimal costoUnitarioBase = (decimal)item.CostoUnitarioBase;

                    detalles.Add(new CompraDetalle
                    {
                        ProductoID = item.ProductoID,
                        ProductoPresentacionID = item.ProductoPresentacionID,
                        Cantidad = cantidadPresentaciones,
                        CostoUnitario = costoUnitarioBase,
                        CostoPresentacion = (decimal)item.CostoPresentacion,
                        Subtotal = cantidadBase * costoUnitarioBase,
                        CantidadUnidadesBase = cantidadBase
                    });
                }

                DateTime? fechaVencimiento = rbCredito.Checked ? (DateTime?)dtpVencimiento.Value.Date : null;

                if (CompraRepository.Crear(compra, detalles, fechaVencimiento))
                {
                    MessageBox.Show(
                        $"Compra registrada exitosamente\n\nN°: {compra.NumeroCompra}\nTotal: S/ {compra.Total:N2}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar compra: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormulario()
        {
            if (_proveedorID == 0)
            {
                MessageBox.Show("Selecciona un proveedor", "Validación");
                cmbBuscarProveedor.Focus();
                return false;
            }

            if (dgvProductos.Rows.Count == 0)
            {
                MessageBox.Show("Agrega al menos un producto", "Validación");
                return false;
            }

            if (!rbContado.Checked && !rbCredito.Checked)
            {
                MessageBox.Show("Selecciona un método de pago", "Validación");
                return false;
            }

            return true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.Rows.Count > 0)
            {
                var resultado = MessageBox.Show("¿Cancelar compra actual?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.No) return;
            }
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            dgvProductos.Rows.Clear();
            cmbBuscarProveedor.SelectedIndex = 0;
            lblNombreRazonSocial.Text = "";
            _proveedorID = 0;

            LimpiarCamposProducto();

            txtNumero.Clear();
            txtNumero.Clear();
            txtObservaciones.Clear();
            txtSubtotal.Text = "0.00";
            txtIGV.Text = "0.00";
            txtTotal.Text = "0.00";
            chkIncluirIGV.Checked = false;
            rbContado.Checked = true;
            dtpFecha.Value = DateTime.Now;
            cmbTipoComprobante.SelectedIndex = 0;
        }

        private void TxtSoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void BtnHistorial_Click(object sender, EventArgs e)
        {
            var formHistorial = new FormHistorialCompras();
            formHistorial.ShowDialog();
        }

        private void CargarCatalogoProductos()
        {
            _productosCatalogo = ProductoRepository.BuscarProductos("");
            _productosEncontrados = new List<Producto>(_productosCatalogo);
            RefrescarComboProductosManteniendoTexto(_productosEncontrados, string.Empty, false);
        }

        private static void AplicarConfiguracionSeguraCombo(ComboBox combo, bool habilitarBusqueda)
        {
            if (combo == null) return;

            if (habilitarBusqueda)
            {
                combo.DropDownStyle = ComboBoxStyle.DropDown;
                combo.AutoCompleteSource = AutoCompleteSource.ListItems;
                combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            else
            {
                combo.DropDownStyle = ComboBoxStyle.DropDownList;
                combo.AutoCompleteMode = AutoCompleteMode.None;
                combo.AutoCompleteSource = AutoCompleteSource.None;
            }
        }

        private void ValidarConfiguracionesCombo()
        {
            var combos = new[] { cmbBuscarProveedor, cmbTipoComprobante, cmbPresentacion, cmbBuscarProducto };
            foreach (var combo in combos)
            {
                if (combo == null) continue;

                bool invalido =
                    combo.DropDownStyle == ComboBoxStyle.DropDownList &&
                    combo.AutoCompleteMode != AutoCompleteMode.None &&
                    combo.AutoCompleteSource != AutoCompleteSource.ListItems;

                if (invalido)
                {
                    combo.AutoCompleteMode = AutoCompleteMode.None;
                    combo.AutoCompleteSource = AutoCompleteSource.None;
                }
            }
        }

        private void RefrescarComboProductosManteniendoTexto(List<Producto> productos, string texto, bool abrirDropdown)
        {
            _actualizandoBusqueda = true;
            try
            {
                cmbBuscarProducto.BeginUpdate();
                cmbBuscarProducto.Items.Clear();
                foreach (var p in productos)
                    cmbBuscarProducto.Items.Add($"{p.Codigo} - {p.Nombre}");
                cmbBuscarProducto.EndUpdate();

                cmbBuscarProducto.Text = texto;
                cmbBuscarProducto.SelectionStart = cmbBuscarProducto.Text.Length;
                cmbBuscarProducto.SelectionLength = 0;
                if (abrirDropdown)
                    cmbBuscarProducto.DroppedDown = true;
            }
            finally
            {
                _actualizandoBusqueda = false;
            }
        }

        private void RecalcularDetalleSeleccionado()
        {
            if (_productoSeleccionado == null || cmbPresentacion.SelectedItem == null)
            {
                if (txtCantidadBase != null) txtCantidadBase.Text = "0.00";
                if (txtCostoUnitarioBase != null) txtCostoUnitarioBase.Text = "0.00";
                ActualizarEtiquetasUnidadBase(string.Empty);
                return;
            }

            var item = (dynamic)cmbPresentacion.SelectedItem;
            var presentacion = item.Presentacion;
            decimal factorPresentacion = (decimal)presentacion.CantidadUnidades;
            decimal cantidadPresentaciones = numCantidad.Value;
            decimal cantidadBase = cantidadPresentaciones * factorPresentacion;

            decimal costoPresentacion = 0m;
            TryParseDecimal(txtCostoUnitario.Text, out costoPresentacion);
            decimal costoUnitarioBase = factorPresentacion > 0
                ? (costoPresentacion / factorPresentacion)
                : 0m;

            if (txtCantidadBase != null) txtCantidadBase.Text = cantidadBase.ToString("N2");
            if (txtCostoUnitarioBase != null) txtCostoUnitarioBase.Text = costoUnitarioBase.ToString("N4");
            ActualizarEtiquetasUnidadBase(_unidadBaseSimboloSeleccionado);
        }

        private void ActualizarEtiquetasUnidadBase(string simbolo)
        {
            string unidad = UiUnitsHelper.NormalizeUnit(simbolo);
            string pres   = string.IsNullOrWhiteSpace(_nombrePresentacionSeleccionada)
                            ? "pres." : _nombrePresentacionSeleccionada;

            if (lblCostoUnitario != null)     lblCostoUnitario.Text     = $"Costo por {pres} (S/):";
            if (lblCantidad != null)          lblCantidad.Text           = $"Cantidad ({pres}):";
            if (lblCantidadBase != null)      lblCantidadBase.Text       = $"Equivalente ({unidad}):";
            if (lblCostoUnitarioBase != null) lblCostoUnitarioBase.Text  = UiUnitsHelper.FormatMoneyPerUnit("Costo unitario", simbolo) + ":";
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timerBusqueda?.Dispose();
            base.OnFormClosed(e);
        }

        private static bool TryParseDecimal(string texto, out decimal valor)
        {
            if (decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out valor))
                return true;

            return decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out valor);
        }
    }
}
