using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Forms.Shared;
using SistemaPOS.Reports.DataSources;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Ventas
{
    public partial class FormHistorialVentas : Form
    {
        private List<dynamic> _todosLosClientes;
        private int _cajaActualID;

        public FormHistorialVentas()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            ObtenerCajaActual();
            ConfigurarEventos();
            ConfigurarDataGridView();
            InicializarFiltros();
            CargarClientes();
            CargarVentas();
        }

        private void ObtenerCajaActual()
        {
            var caja = CajaRepository.ObtenerCajaAbierta();
            _cajaActualID = caja?.CajaID ?? 0;
        }

        private void ConfigurarEventos()
        {
            btnBuscar.Click += BtnBuscar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
            btnExportar.Click += BtnExportar_Click;
            btnCerrar.Click += (s, e) => this.Close();
            dgvVentas.CellClick += DgvVentas_CellClick;

            // Buscar al presionar Enter en los filtros
            cmbCliente.KeyDown += Filtros_KeyDown;
            cmbEstado.KeyDown += Filtros_KeyDown;
            cmbTipoComprobante.KeyDown += Filtros_KeyDown;

            // Buscar al cambiar selección en combos
            cmbCliente.SelectedIndexChanged += (s, e) => CargarVentas();
            cmbEstado.SelectedIndexChanged += (s, e) => CargarVentas();
            cmbTipoComprobante.SelectedIndexChanged += (s, e) => CargarVentas();
            dtpDesde.ValueChanged += (s, e) => CargarVentas();
            dtpHasta.ValueChanged += (s, e) => CargarVentas();
        }

        private void Filtros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarVentas();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvVentas.AutoGenerateColumns = false;
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.ReadOnly = true;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void InicializarFiltros()
        {
            // ComboBox Estado
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("TODOS");
            cmbEstado.Items.Add("COMPLETADA");
            cmbEstado.Items.Add("CREDITO");
            cmbEstado.Items.Add("ANULADA");
            cmbEstado.SelectedIndex = 0;

            // ComboBox Tipo Comprobante
            cmbTipoComprobante.Items.Clear();
            cmbTipoComprobante.Items.Add("TODOS");
            cmbTipoComprobante.Items.Add("NOTA_VENTA");
            cmbTipoComprobante.Items.Add("BOLETA");
            cmbTipoComprobante.Items.Add("FACTURA");
            cmbTipoComprobante.SelectedIndex = 0;

            // Fechas
            dtpHasta.Value = DateTime.Now;
            dtpDesde.Value = DateTime.Now.AddMonths(-1);

        }

        private void CargarClientes()
        {
            try
            {
                _todosLosClientes = ClienteRepository.Listar()
                    .Cast<dynamic>()
                    .Where(c => c.ClienteID != 1)  // Filtrar Cliente General
                    .ToList();

                cmbCliente.Items.Clear();
                cmbCliente.Items.Add("TODOS");

                foreach (var cliente in _todosLosClientes)
                {
                    string display = $"{cliente.NombreCompleto} - {cliente.NumeroDocumento}";
                    cmbCliente.Items.Add(display);
                }

                cmbCliente.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error");
            }
        }

        private void CargarVentas()
        {
            try
            {
                int? clienteID = null;
                if (cmbCliente.SelectedIndex > 0)
                {
                    clienteID = _todosLosClientes[cmbCliente.SelectedIndex - 1].ClienteID;
                }
                string estado = cmbEstado.SelectedIndex == 0 ? null : cmbEstado.Text;
                string tipoComprobante = cmbTipoComprobante.SelectedIndex == 0 ? null : cmbTipoComprobante.Text;
                DateTime fechaDesde = dtpDesde.Value.Date;
                DateTime fechaHasta = dtpHasta.Value.Date;

                // El admin ve todas las cajas; los demás solo la caja actual si hay una abierta
                var usuario = SesionActual.Usuario;
                bool esAdmin = usuario != null && usuario.RolID == 1;
                int? cajaID = esAdmin ? (int?)null : (_cajaActualID > 0 ? _cajaActualID : (int?)null);
                var ventas = VentaRepository.Listar(clienteID, estado, tipoComprobante, fechaDesde, fechaHasta, cajaID);
                dgvVentas.Rows.Clear();
                int numero = 1;
                foreach (var venta in ventas)
                {
                    int index = dgvVentas.Rows.Add();
                    DataGridViewRow row = dgvVentas.Rows[index];
                    row.Cells["colNumero"].Value = numero++;
                    row.Cells["colFechaHora"].Value = venta.Fecha.ToString("dd/MM/yyyy") + " " + venta.Hora.ToString(@"hh\:mm");
                    row.Cells["colComprobante"].Value = venta.TipoComprobante + "\n" + venta.NumeroVenta;
                    row.Cells["colCliente"].Value = venta.NombreCliente;
                    row.Cells["colItems"].Value = venta.CantidadItems.ToString() + " items";
                    row.Cells["colMetodoPago"].Value = venta.MetodoPago;
                    row.Cells["colTotal"].Value = "S/ " + venta.Total.ToString("N2");
                    row.Cells["colEstado"].Value = venta.Estado;

                    if (venta.Estado == "COMPLETADA")
                        row.Cells["colEstado"].Style.ForeColor = Color.Green;
                    else if (venta.Estado == "CREDITO" || venta.Estado == "PENDIENTE")
                        row.Cells["colEstado"].Style.ForeColor = Color.Orange;
                    else if (venta.Estado == "ANULADA")
                        row.Cells["colEstado"].Style.ForeColor = Color.Red;

                    row.Tag = venta.VentaID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ventas: {ex.Message}", "Error");
            }
        }

        private void DgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int ventaID = Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Tag);
            string estado = dgvVentas.Rows[e.RowIndex].Cells["colEstado"].Value.ToString();

            string columnName = dgvVentas.Columns[e.ColumnIndex].Name;

            // Botón Ver Detalle
            if (columnName == "colVerDetalle")
            {
                VerDetalleVenta(ventaID);
            }
            // Botón Imprimir
            else if (columnName == "colImprimir")
            {
                ImprimirVenta(ventaID);
            }
            // Botón Anular / Eliminar inteligente (un solo botón, routing automático)
            else if (columnName == "colAnular")
            {
                var usuarioObj = SesionActual.Usuario;
                if (usuarioObj == null || (!usuarioObj.PermisoAnularVentas && usuarioObj.RolID != 1))
                {
                    MessageBox.Show("No tienes permiso para anular ventas.", "Acceso denegado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (estado == "ANULADA")
                {
                    MessageBox.Show("Esta venta ya está anulada.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                AnularEliminarVenta(ventaID, usuarioObj.NombreUsuario);
            }
        }

        private void AnularEliminarVenta(int ventaID, string usuario)
        {
            bool tieneImpacto = PapeleraService.TieneImpactoContable("VENTA", ventaID);

            string mensaje = tieneImpacto
                ? "Esta venta tiene asiento contable.\n\nSe ANULARÁ (revertirá el stock y la contabilidad).\n\n¿Continuar?"
                : "Esta venta no tiene asiento contable.\n\nSe enviará a la PAPELERA (podrá recuperarse).\n\n¿Continuar?";

            if (MessageBox.Show(mensaje, "Confirmar acción",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                VentaRepository.EliminarInteligente(ventaID, usuario);
                string ok = tieneImpacto ? "Venta anulada correctamente." : "Venta enviada a la papelera.";
                MessageBox.Show(ok, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VerDetalleVenta(int ventaID)
        {
            try
            {
                var formDetalle = new FormDetalleVenta(ventaID);
                formDetalle.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ver detalle: {ex.Message}", "Error");
            }
        }

        private void ImprimirVenta(int ventaID)
        {
            try
            {
                var parametros = ReportHelper.GetCompanyParameters();
                var dt = ReportDataSourceHelper.ObtenerDatosTicketVenta(ventaID, parametros);

                using (var preview = new FormPreviewTicket(dt, parametros))
                    preview.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarVentas();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            cmbCliente.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            cmbTipoComprobante.SelectedIndex = 0;
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
            dtpHasta.Value = DateTime.Now;
            CargarVentas();
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            GenerarReporte("exportar");
        }

        private void GenerarReporte(string accion)
        {
            try
            {
                var dt = ObtenerDatosReporteVentas();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show($"No hay ventas para {accion}", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var dataSources = new Dictionary<string, DataTable> { { "DsVentas", dt } };
                var parameters = ReportHelper.GetCompanyParameters();
                parameters["pPeriodo"] = $"Período: {dtpDesde.Value:dd/MM/yyyy} - {dtpHasta.Value:dd/MM/yyyy}";

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Tabular\RptHistorialVentas.rdlc"),
                    dataSources, parameters, "historial_ventas");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ObtenerDatosReporteVentas()
        {
            int? clienteID = null;
            if (cmbCliente.SelectedIndex > 0)
                clienteID = _todosLosClientes[cmbCliente.SelectedIndex - 1].ClienteID;

            string estado = cmbEstado.SelectedIndex == 0 ? null : cmbEstado.Text;
            string tipoComprobante = cmbTipoComprobante.SelectedIndex == 0 ? null : cmbTipoComprobante.Text;
            var usuario = SesionActual.Usuario;
            bool esAdmin = usuario != null && usuario.RolID == 1;
            int? cajaID = esAdmin ? (int?)null : (_cajaActualID > 0 ? _cajaActualID : (int?)null);

            return ReportDataSourceHelper.ObtenerDatosHistorialVentas(
                clienteID, estado, tipoComprobante, dtpDesde.Value.Date, dtpHasta.Value.Date, cajaID);
        }
    }
}
