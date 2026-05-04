using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Inventario
{
    public partial class FormAjustes : Form
    {
        private Producto _productoSeleccionado = null;
        private List<Producto> _todosLosProductos = new List<Producto>();

        public FormAjustes()
        {
            InitializeComponent();
            ConfigurarEventos();
            ConfigurarControles();
        }

        private void ConfigurarEventos()
        {
            btnGuardarAjuste.Click += BtnGuardarAjuste_Click;
            btnCancelar.Click += BtnCancelar_Click;
            cmbBuscarProducto.SelectedIndexChanged += CmbBuscarProducto_SelectedIndexChanged;
            rbEntrada.CheckedChanged += TipoAjuste_CheckedChanged;
            rbSalida.CheckedChanged += TipoAjuste_CheckedChanged;
            numCantidadAjustar.ValueChanged += NumCantidadAjustar_ValueChanged;
            rbOtros.CheckedChanged += RbOtros_CheckedChanged;
        }

        private void ConfigurarControles()
        {
            dtpFecha.MaxDate = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
            dtpFecha.Value = DateTime.Now;

            rbEntrada.Checked = true;
            rbInventarioFisico.Checked = true;
            ActualizarEstiloTipo();

            numCantidadAjustar.Minimum = 0;
            numCantidadAjustar.Maximum = 99999;
            numCantidadAjustar.DecimalPlaces = 2;
            numCantidadAjustar.Value = 0;

            txtStockActualResumen.ReadOnly = true;
            txtAjuste.ReadOnly = true;
            txtNuevoStock.ReadOnly = true;

            // Configurar columnas del historial
            dgvHistorialProducto.Columns.Clear();
            dgvHistorialProducto.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colFecha",    HeaderText = "FECHA",          Width = 80,  ReadOnly = true });
            dgvHistorialProducto.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colTipo",     HeaderText = "TIPO",           Width = 70,  ReadOnly = true });
            dgvHistorialProducto.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colCantidad", HeaderText = "CANTIDAD",       Width = 80,  ReadOnly = true });
            dgvHistorialProducto.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colAnterior", HeaderText = "STOCK ANT.",     Width = 90,  ReadOnly = true });
            dgvHistorialProducto.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colNuevo",    HeaderText = "STOCK NUEVO",    Width = 90,  ReadOnly = true });
            dgvHistorialProducto.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colMotivo",   HeaderText = "MOTIVO",         AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill, ReadOnly = true });
            dgvHistorialProducto.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colUsuario",  HeaderText = "USUARIO",        Width = 90,  ReadOnly = true });
            DgvStyleHelper.Aplicar(dgvHistorialProducto);

            CargarProductosEnCombo();
            LimpiarResumen();
        }

        private void ActualizarEstiloTipo()
        {
            if (rbEntrada.Checked)
            {
                rbEntrada.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
                rbEntrada.ForeColor = System.Drawing.Color.White;
                rbEntrada.FlatAppearance.BorderSize = 0;
                rbSalida.BackColor  = System.Drawing.Color.FromArgb(245, 247, 250);
                rbSalida.ForeColor  = System.Drawing.Color.FromArgb(192, 57, 43);
                rbSalida.FlatAppearance.BorderSize = 1;
            }
            else
            {
                rbSalida.BackColor  = System.Drawing.Color.FromArgb(192, 57, 43);
                rbSalida.ForeColor  = System.Drawing.Color.White;
                rbSalida.FlatAppearance.BorderSize = 0;
                rbEntrada.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
                rbEntrada.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
                rbEntrada.FlatAppearance.BorderSize = 1;
            }
        }

        private void CargarProductosEnCombo()
        {
            try
            {
                _todosLosProductos = ProductoRepository.BuscarProductos("");
                cmbBuscarProducto.Items.Clear();
                cmbBuscarProducto.Items.Add("-- Seleccione un producto --");

                foreach (var p in _todosLosProductos)
                {
                    cmbBuscarProducto.Items.Add($"{p.Codigo} - {p.Nombre} (Stock: {p.StockTotal:N2})");
                }

                cmbBuscarProducto.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbBuscarProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cmbBuscarProducto.SelectedIndex;

            if (idx <= 0 || idx > _todosLosProductos.Count)
            {
                _productoSeleccionado = null;
                LimpiarResumen();
                return;
            }

            _productoSeleccionado = _todosLosProductos[idx - 1];

            decimal stockActual = AjusteRepository.ObtenerStockActual(_productoSeleccionado.ProductoID);
            _productoSeleccionado.StockTotal = stockActual;

            lblNombreProducto.Text  = _productoSeleccionado.Nombre;
            lblInfoProducto.Text    = $"Código: {_productoSeleccionado.Codigo}   |   Stock en sistema: {stockActual:N2}";

            txtStockActualResumen.Text = stockActual.ToString("N2");
            ActualizarResumen();
            CargarHistorialProducto(_productoSeleccionado.ProductoID);
            numCantidadAjustar.Focus();
        }

        private void TipoAjuste_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarEstiloTipo();
            ActualizarResumen();
        }

        private void NumCantidadAjustar_ValueChanged(object sender, EventArgs e)
        {
            ActualizarResumen();
        }

        private void RbOtros_CheckedChanged(object sender, EventArgs e)
        {
            txtMotivo.Enabled = rbOtros.Checked;
            if (!rbOtros.Checked)
                txtMotivo.Text = "";
            else
                txtMotivo.Focus();
        }

        private void ActualizarResumen()
        {
            if (_productoSeleccionado == null)
            {
                LimpiarResumen();
                return;
            }

            decimal stockActual = _productoSeleccionado.StockTotal;
            decimal cantidad = numCantidadAjustar.Value;
            decimal nuevoStock;

            if (rbEntrada.Checked)
            {
                nuevoStock = stockActual + cantidad;
                txtAjuste.Text = $"+{cantidad:N2}";
                txtAjuste.ForeColor = Color.Green;
            }
            else
            {
                nuevoStock = stockActual - cantidad;
                txtAjuste.Text = $"-{cantidad:N2}";
                txtAjuste.ForeColor = Color.Red;
            }

            txtStockActualResumen.Text = stockActual.ToString("N2");
            txtNuevoStock.Text = nuevoStock.ToString("N2");
            txtNuevoStock.ForeColor = nuevoStock < 0 ? Color.Red : Color.Black;
        }

        private void CargarHistorialProducto(int productoID)
        {
            try
            {
                dgvHistorialProducto.Rows.Clear();
                var lista = AjusteRepository.ObtenerAjustesPorProducto(productoID);
                // Mostrar los más recientes primero, máximo 20
                for (int i = lista.Count - 1; i >= 0 && dgvHistorialProducto.Rows.Count < 20; i--)
                {
                    var a = lista[i];
                    var row = dgvHistorialProducto.Rows[dgvHistorialProducto.Rows.Add()];
                    row.Cells["colFecha"].Value    = a.Fecha.ToString("dd/MM/yy");
                    row.Cells["colTipo"].Value     = a.TipoAjuste;
                    row.Cells["colCantidad"].Value = a.Cantidad.ToString("N2");
                    row.Cells["colAnterior"].Value = a.StockAnterior.ToString("N2");
                    row.Cells["colNuevo"].Value    = a.StockNuevo.ToString("N2");
                    row.Cells["colMotivo"].Value   = a.Motivo;
                    row.Cells["colUsuario"].Value  = a.NombreUsuario ?? a.UsuarioID.ToString();

                    // Color de fila por tipo
                    if (a.TipoAjuste == "ENTRADA")
                        row.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
                    else if (a.TipoAjuste == "SALIDA")
                        row.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
                }
                if (dgvHistorialProducto.Rows.Count == 0)
                {
                    var row = dgvHistorialProducto.Rows[dgvHistorialProducto.Rows.Add()];
                    row.Cells["colMotivo"].Value = "Sin ajustes previos para este producto";
                    row.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(160, 170, 180);
                }
            }
            catch { /* silencioso: historial es informativo */ }
        }

        private void LimpiarResumen()
        {
            lblNombreProducto.Text  = "— Seleccione un producto —";
            lblInfoProducto.Text    = "";
            txtStockActualResumen.Text = "";
            txtAjuste.Text = "";
            txtNuevoStock.Text = "";
            dgvHistorialProducto.Rows.Clear();
        }

        private string ObtenerMotivoSeleccionado()
        {
            if (rbInventarioFisico.Checked)
                return "Inventario fisico (diferencia encontrada)";
            else if (rbProductoDañado.Checked)
                return "Producto dañado / Merma";
            else if (rbErrorAnterior.Checked)
                return "Error en registro anterior";
            else if (rbDevolucionCliente.Checked)
                return "Devolucion de cliente";
            else if (rbOtros.Checked)
                return txtMotivo.Text.Trim();

            return "";
        }

        private void BtnGuardarAjuste_Click(object sender, EventArgs e)
        {
            if (_productoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un producto", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBuscarProducto.Focus();
                return;
            }

            if (numCantidadAjustar.Value <= 0)
            {
                MessageBox.Show("Ingrese una cantidad valida mayor a cero", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCantidadAjustar.Focus();
                return;
            }

            string motivo = ObtenerMotivoSeleccionado();
            if (rbOtros.Checked && string.IsNullOrWhiteSpace(motivo))
            {
                MessageBox.Show("Ingrese el motivo del ajuste", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivo.Focus();
                return;
            }

            decimal stockActual = _productoSeleccionado.StockTotal;
            decimal cantidad = numCantidadAjustar.Value;
            string tipoAjuste = rbEntrada.Checked ? "ENTRADA" : "SALIDA";
            decimal nuevoStock = rbEntrada.Checked ? stockActual + cantidad : stockActual - cantidad;

            if (nuevoStock < 0)
            {
                MessageBox.Show(
                    $"No se puede realizar la salida.\n\n" +
                    $"Stock actual: {stockActual:N2}\n" +
                    $"Cantidad a retirar: {cantidad:N2}\n\n" +
                    $"La cantidad a retirar supera el stock disponible.",
                    "Stock insuficiente",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCantidadAjustar.Focus();
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Confirmar el siguiente ajuste?\n\n" +
                $"Producto: {_productoSeleccionado.Nombre}\n" +
                $"Tipo: {(rbEntrada.Checked ? "Entrada (+)" : "Salida (-)")}\n" +
                $"Cantidad: {cantidad:N2}\n" +
                $"Stock actual: {stockActual:N2}\n" +
                $"Nuevo stock: {nuevoStock:N2}\n" +
                $"Motivo: {motivo}",
                "Confirmar Ajuste",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                int usuarioID = SesionActual.Usuario?.UsuarioID ?? 1;
                DateTime fecha = dtpFecha.Value;

                bool resultado = AjusteRepository.RegistrarAjuste(
                    _productoSeleccionado.ProductoID,
                    tipoAjuste,
                    cantidad,
                    stockActual,
                    nuevoStock,
                    motivo,
                    usuarioID,
                    fecha);

                if (resultado)
                {
                    MessageBox.Show("Ajuste registrado exitosamente", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar ajuste: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (_productoSeleccionado != null || numCantidadAjustar.Value > 0)
            {
                var result = MessageBox.Show("Desea cancelar el ajuste actual?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;
            }

            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            _productoSeleccionado = null;
            CargarProductosEnCombo();
            numCantidadAjustar.Value = 0;
            rbEntrada.Checked = true;
            rbInventarioFisico.Checked = true;
            txtMotivo.Text = "";
            txtMotivo.Enabled = false;
            dtpFecha.MaxDate = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
            dtpFecha.Value = DateTime.Now;
            LimpiarResumen();
            cmbBuscarProducto.Focus();
        }
    }
}
