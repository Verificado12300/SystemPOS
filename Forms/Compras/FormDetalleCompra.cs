using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Reports.DataSources;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Compras
{
    public partial class FormDetalleCompra : Form
    {
        private int _compraID;

        public FormDetalleCompra(int compraID)
        {
            InitializeComponent();
            _compraID = compraID;
            ConfigurarEventos();
            ConfigurarDataGridView();
            CargarDatosCompra();
        }

        public FormDetalleCompra()
        {
            InitializeComponent();
        }

        private void ConfigurarEventos()
        {
            btnCerrar.Click += (s, e) => this.Close();
            btnImprimir.Click += BtnImprimir_Click;
        }

        private void ConfigurarDataGridView()
        {
            dgvDetalleProductos.AutoGenerateColumns = false;
            dgvDetalleProductos.AllowUserToAddRows = false;
            dgvDetalleProductos.ReadOnly = true;
            dgvDetalleProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void CargarDatosCompra()
        {
            try
            {
                var compra = CompraRepository.ObtenerPorID(_compraID);
                if (compra == null)
                {
                    MessageBox.Show("Compra no encontrada", "Error");
                    this.Close();
                    return;
                }

                // Comprobante
                lblTipoComprobante.Text = $"Tipo: {compra.TipoComprobante}";
                lblNumeroSerie.Text = $"Serie-Número: {compra.Serie}-{compra.Numero}";
                lblFecha.Text = $"Fecha: {compra.Fecha:dd/MM/yyyy}";
                lblHora.Text = $"Hora: {compra.Hora:hh\\:mm\\:ss}";

                string estadoTexto = compra.Estado == "COMPLETADA" ? "Completada" :
                                     compra.Estado == "CREDITO" ? "Crédito" :
                                     compra.Estado == "ANULADA" ? "Anulada" : compra.Estado;
                lblEstado.Text = $"Estado: {estadoTexto}";

                var usuario = ObtenerUsuario(compra.UsuarioID);
                lblEncargado.Text = $"Encargado: {usuario}";

                // Proveedor
                var proveedor = ObtenerProveedor(compra.ProveedorID);
                lblRazonSocial.Text = "Razón Social:";
                txtRazonSocial.Text = proveedor.RazonSocial;
                lblDNIRUC.Text = "RUC:";
                txtRUC.Text = proveedor.RUC;
                lblTelefono.Text = "Teléfono:";
                txtTelefono.Text = proveedor.Telefono;
                lblDireccion.Text = "Dirección:";
                txtDireccion.Text = proveedor.Direccion;

                // Metodo pago
                string metodoPagoTexto = compra.MetodoPago == "EFECTIVO" ? "Efectivo" :
                                         compra.MetodoPago == "TRANSFERENCIA" ? "Transferencia" :
                                         compra.MetodoPago == "CREDITO" ? "Crédito" : compra.MetodoPago;
                lblMetodoPago.Text = "Método de Pago:";
                txtRecibido.Text = metodoPagoTexto;

                // Crédito - mostrar info de vencimiento si aplica
                if (compra.Estado == "CREDITO")
                {
                    var credito = CompraRepository.ObtenerCreditoPorCompraID(_compraID);
                    if (credito != null)
                    {
                        txtRecibido.Text += $"  |  Vence: {credito.FechaVencimiento:dd/MM/yyyy}  |  Saldo: S/ {credito.Saldo:N2}";
                    }
                }

                // IGV
                chkIGVIncluido.Checked = compra.IncluyeIGV;
                chkIGVIncluido.Enabled = false;

                // Totales
                txtSubTotal.Text = $"S/ {compra.SubTotal:N2}";
                txtIGV.Text = $"S/ {compra.IGV:N2}";
                txtTotal.Text = $"S/ {compra.Total:N2}";

                // Observaciones
                txtObservaciones.Text = compra.Observaciones;
                txtObservaciones.ReadOnly = true;

                // Anulación
                if (compra.Estado == "ANULADA" && compra.FechaAnulacion.HasValue)
                {
                    txtObservaciones.Text = $"ANULADA: {compra.MotivoAnulacion} ({compra.FechaAnulacion.Value:dd/MM/yyyy HH:mm})";
                }

                CargarDetallesProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error");
            }
        }

        private void CargarDetallesProductos()
        {
            try
            {
                var detalles = CompraRepository.ObtenerDetalles(_compraID);

                dgvDetalleProductos.Rows.Clear();
                int numero = 1;

                foreach (var detalle in detalles)
                {
                    int index = dgvDetalleProductos.Rows.Add();
                    var row = dgvDetalleProductos.Rows[index];

                    row.Cells["colNumero"].Value = numero++;
                    row.Cells["colProductoDV"].Value = detalle.ProductoNombre;
                    row.Cells["colPresentacionDV"].Value = detalle.PresentacionNombre;
                    string simbolo = detalle.UnidadSimbolo ?? "";
                    decimal cantPres = (decimal)detalle.Cantidad;
                    decimal cantBase = (decimal)detalle.CantidadUnidadesBase;
                    string presStr = cantPres == Math.Floor(cantPres) ? $"{(int)cantPres}" : cantPres.ToString("N2");
                    string baseStr = string.IsNullOrEmpty(simbolo) ? cantBase.ToString("N2") : $"{cantBase:N2} {simbolo}";
                    row.Cells["colCantidad"].Value = $"{presStr} {detalle.PresentacionNombre}\n({baseStr})";
                    decimal costoPres = (decimal)detalle.CostoPresentacion;
                    decimal costoBase = (decimal)detalle.CostoUnitario;
                    string presLabel  = UiUnitsHelper.NormalizeUnit(simbolo);
                    row.Cells["colCostoUnitario"].Value =
                        $"S/ {costoPres:N2}/{detalle.PresentacionNombre}  (= S/ {costoBase:N4}/{presLabel})";
                    row.Cells["colSubTotal"].Value = "S/ " + ((decimal)detalle.Subtotal).ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error");
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var parametros = ReportHelper.GetCompanyParameters();
                var dt = ReportDataSourceHelper.ObtenerDatosDetalleCompra(_compraID, parametros);

                var dataSources = new Dictionary<string, DataTable> { { "DsDetalleCompra", dt } };

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Documents\RptDetalleCompra.rdlc"),
                    dataSources, parametros, "detalle_compra");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerUsuario(int usuarioID)
        {
            return UsuarioRepository.ObtenerNombreCompletoPorID(usuarioID);
        }

        private Proveedor ObtenerProveedor(int proveedorID)
        {
            return ProveedorRepository.ObtenerInfoBasica(proveedorID)
                ?? new Proveedor { RazonSocial = "Desconocido", RUC = "", Telefono = "", Direccion = "" };
        }
    }
}
