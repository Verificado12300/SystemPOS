using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Reports.DataSources;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Inventario
{
    public partial class FormProductos : Form
    {
        private List<Categoria> _categorias = new List<Categoria>();
        private Timer _timerDebounce;

        public FormProductos()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            ConfigurarEventos();
            ConfigurarDataGridView();
            CargarCategorias();
            CargarProductos();
        }

        private void ConfigurarEventos()
        {
            // Debounce de 400ms en búsqueda
            _timerDebounce = new Timer { Interval = 400 };
            _timerDebounce.Tick += (s, e) =>
            {
                _timerDebounce.Stop();
                CargarProductos(txtBuscar.Text.Trim());
            };

            btnNuevo.Click += BtnNuevo_Click;
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            txtBuscar.KeyDown += TxtBuscar_KeyDown;
            dgvProductos.CellClick += DgvProductos_CellClick;
            btnExportar.Click += BtnExportar_Click;
            btnImportar.Click += BtnImportar_Click;
            cmbCategoria.SelectedIndexChanged += Filtros_Changed;
            cmbFiltroStock.SelectedIndexChanged += Filtros_Changed;
        }

        private void TxtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarProductos(txtBuscar.Text.Trim());
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.AllowUserToAddRows  = false;
            dgvProductos.ReadOnly            = true;
            DgvStyleHelper.Aplicar(dgvProductos);

            // WrapMode already set in Designer; keep AutoSizeRows for multi-line cells
            dgvProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Configurar combo de filtro de stock
            cmbFiltroStock.Items.Clear();
            cmbFiltroStock.Items.AddRange(new object[] { "Todos", "Con Stock", "Sin Stock", "Stock Bajo" });
            cmbFiltroStock.SelectedIndex = 0;
        }

        private void CargarCategorias()
        {
            try
            {
                _categorias = CategoriaRepository.ObtenerTodas();

                cmbCategoria.Items.Clear();
                cmbCategoria.Items.Add("Todas las categorías");

                foreach (var categoria in _categorias)
                {
                    cmbCategoria.Items.Add(categoria.Nombre);
                }

                cmbCategoria.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductos(string busqueda = "")
        {
            try
            {
                dgvProductos.Rows.Clear();

                var productos = ProductoRepository.BuscarProductosConDetalles(busqueda);

                // Aplicar filtro de categoria
                string categoriaSeleccionada = cmbCategoria.SelectedIndex > 0 ? cmbCategoria.SelectedItem.ToString() : null;
                if (!string.IsNullOrEmpty(categoriaSeleccionada))
                {
                    productos = productos.Where(p => p.Categoria == categoriaSeleccionada).ToList();
                }

                // Aplicar filtro de stock
                string filtroStock = cmbFiltroStock.SelectedItem?.ToString() ?? "Todos";
                switch (filtroStock)
                {
                    case "Con Stock":
                        productos = productos.Where(p => p.StockTotal > 0).ToList();
                        break;
                    case "Sin Stock":
                        productos = productos.Where(p => p.StockTotal <= 0).ToList();
                        break;
                    case "Stock Bajo":
                        productos = productos.Where(p => p.StockTotal > 0 && p.StockTotal <= p.StockMinimo).ToList();
                        break;
                }

                int numero = 1;
                foreach (var producto in productos)
                {
                    int index = dgvProductos.Rows.Add();
                    DataGridViewRow row = dgvProductos.Rows[index];

                    row.Cells["colNumero"].Value = numero++;
                    row.Cells["colCodigo"].Value = producto.Codigo;
                    row.Cells["colProducto"].Value = producto.Nombre;
                    row.Cells["colCategoria"].Value = producto.Categoria;
                    row.Cells["colUnidadBase"].Value = producto.UnidadBase;
                    row.Cells["colPresentaciones"].Value = producto.Presentaciones;
                    row.Cells["colPrecio"].Value = producto.Precio;
                    row.Cells["colStockTotal"].Value = $"{producto.StockTotal:N2} {producto.UnidadBase}";

                    // Guardar ID oculto en Tag
                    row.Tag = producto.ProductoID;
                }

                int total = productos.Count;
                lblRegistros.Text = $"{total} producto{(total != 1 ? "s" : "")} encontrado{(total != 1 ? "s" : "")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            _timerDebounce.Stop();
            _timerDebounce.Start();
        }

        private void Filtros_Changed(object sender, EventArgs e)
        {
            CargarProductos(txtBuscar.Text.Trim());
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            var formDetalle = new FormProductoDetalle();
            if (formDetalle.ShowDialog() == DialogResult.OK)
            {
                CargarProductos();
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                string busqueda = txtBuscar.Text.Trim();
                string categoriaSeleccionada = cmbCategoria.SelectedIndex > 0 ? cmbCategoria.SelectedItem.ToString() : null;
                string filtroStock = cmbFiltroStock.SelectedItem?.ToString() ?? "Todos";

                var dt = ReportDataSourceHelper.ObtenerDatosProductos(busqueda, categoriaSeleccionada, filtroStock);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay productos para exportar", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var dataSources = new Dictionary<string, DataTable>
                {
                    { "DsProductos", dt }
                };

                var parameters = ReportHelper.GetCompanyParameters();
                parameters["pResumen"] = $"Total: {dt.Rows.Count} productos";

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Tabular\RptListadoProductos.rdlc"),
                    dataSources, parameters, "listado_productos");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnImportar_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "La importación masiva de productos puede sobreescribir datos existentes.\n\n" +
                "Asegúrese de tener un respaldo antes de continuar.\n\n" +
                "¿Desea iniciar la importación?",
                "Confirmar importación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            MessageBox.Show("La función de importación estará disponible próximamente.", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AbrirFormEnPanel(Form form)
        {
            // Buscar el panel contenedor del formulario padre
            var parent = this.Parent;
            if (parent != null)
            {
                for (int i = parent.Controls.Count - 1; i >= 0; i--)
                {
                    var control = parent.Controls[i];
                    if (control is Form)
                    {
                        parent.Controls.RemoveAt(i);
                        control.Dispose();
                    }
                }
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                parent.Controls.Add(form);
                form.Show();
            }
            else
            {
                // Si no hay panel padre, abrir como diálogo
                form.ShowDialog();
            }
        }

        private void DgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvProductos.Rows[e.RowIndex];

            // Validar Tag (seguridad)
            if (row.Tag == null) return;

            int productoID = (int)row.Tag;

            // Editar
            if (dgvProductos.Columns[e.ColumnIndex].Name == "colEditar")
            {
                var formDetalle = new FormProductoDetalle(productoID);
                if (formDetalle.ShowDialog() == DialogResult.OK)
                {
                    CargarProductos();
                }
            }
            // Eliminar
            else if (dgvProductos.Columns[e.ColumnIndex].Name == "colEliminar")
            {
                var usuarioActual = SesionActual.Usuario;
                if (usuarioActual == null || (!usuarioActual.PermisoEliminarRegistros && usuarioActual.RolID != 1))
                {
                    MessageBox.Show("No tienes permiso para eliminar registros.", "Acceso denegado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombreProducto = row.Cells["colProducto"].Value?.ToString() ?? "";

                var resultado = MessageBox.Show(
                    $"¿Está seguro de eliminar el producto '{nombreProducto}'?\n\n" +
                    "Esta acción no se puede deshacer.",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        if (ProductoRepository.Eliminar(productoID))
                        {
                            MessageBox.Show("Producto eliminado correctamente", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarProductos();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el producto", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
