using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
            btnCerrar.Click   += (s, e) => this.Close();
            btnImprimir.Click += BtnImprimir_Click;
        }

        private void ConfigurarDataGridView()
        {
            dgvDetalleProductos.AutoGenerateColumns = false;
            DgvStyleHelper.Aplicar(dgvDetalleProductos);
            dgvDetalleProductos.AllowUserToAddRows = false;
            dgvDetalleProductos.ReadOnly           = true;
            dgvDetalleProductos.SelectionMode      = DataGridViewSelectionMode.FullRowSelect;
        }

        private void CargarDatosCompra()
        {
            try
            {
                var compra = CompraRepository.ObtenerPorID(_compraID);
                if (compra == null)
                {
                    MessageBox.Show("Compra no encontrada.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                // ── Header ────────────────────────────────────────────────────
                lblSubTituloDetalle.Text = $"N° {compra.Serie}-{compra.Numero}";

                // ── Comprobante ───────────────────────────────────────────────
                txtTipoComprobante.Text = compra.TipoComprobante;
                txtNumeroSerie.Text     = $"{compra.Serie}-{compra.Numero}";
                txtFecha.Text           = compra.Fecha.ToString("dd/MM/yyyy");
                txtHora.Text            = compra.Hora.ToString(@"hh\:mm\:ss");

                string estadoTexto = compra.Estado == "COMPLETADA" ? "Completada" :
                                     compra.Estado == "CREDITO"    ? "Crédito"    :
                                     compra.Estado == "ANULADA"    ? "Anulada"    : compra.Estado;
                txtEstado.Text      = estadoTexto;
                txtEstado.ForeColor = compra.Estado == "ANULADA"    ? Color.FromArgb(192, 57, 43) :
                                      compra.Estado == "CREDITO"    ? Color.FromArgb(211, 84, 0)  :
                                                                       Color.FromArgb(39, 174, 96);

                txtEncargado.Text = ObtenerUsuario(compra.UsuarioID);

                // ── Proveedor ─────────────────────────────────────────────────
                var prov = ObtenerProveedor(compra.ProveedorID);
                txtRazonSocial.Text = prov.RazonSocial;
                txtRUC.Text         = prov.RUC;
                txtTelefono.Text    = prov.Telefono;
                txtDireccion.Text   = prov.Direccion;

                // ── Método de pago ────────────────────────────────────────────
                string metodoPagoTexto = compra.MetodoPago == "EFECTIVO"      ? "Efectivo"      :
                                         compra.MetodoPago == "TRANSFERENCIA" ? "Transferencia" :
                                         compra.MetodoPago == "CREDITO"       ? "Crédito"       : compra.MetodoPago;
                txtRecibido.Text = metodoPagoTexto;

                if (compra.Estado == "CREDITO")
                {
                    var credito = CompraRepository.ObtenerCreditoPorCompraID(_compraID);
                    if (credito != null)
                        txtRecibido.Text += $"  |  Vence: {credito.FechaVencimiento:dd/MM/yyyy}  |  Saldo: S/ {credito.Saldo:N2}";
                }

                // ── Tipo IGV ──────────────────────────────────────────────────
                switch (compra.TipoIGV)
                {
                    case 1:
                        lblTipoIGVBadge.Text      = "IGV Incluido (18%)";
                        lblTipoIGVBadge.ForeColor = Color.FromArgb(39, 109, 195);
                        break;
                    case 2:
                        lblTipoIGVBadge.Text      = "IGV Adicional (18%)";
                        lblTipoIGVBadge.ForeColor = Color.FromArgb(39, 109, 195);
                        break;
                    default:
                        lblTipoIGVBadge.Text      = "Sin IGV";
                        lblTipoIGVBadge.ForeColor = Color.FromArgb(99, 110, 114);
                        break;
                }

                // ── Totales ───────────────────────────────────────────────────
                txtSubTotal.Text = $"S/ {compra.SubTotal:N2}";
                txtIGV.Text      = $"S/ {compra.IGV:N2}";
                txtTotal.Text    = $"S/ {compra.Total:N2}";

                bool tieneFlete = compra.Flete > 0m;
                lblFlete.Visible = tieneFlete;
                txtFlete.Visible = tieneFlete;
                if (tieneFlete)
                    txtFlete.Text = $"S/ {compra.Flete:N2}";

                // ── Observaciones ─────────────────────────────────────────────
                if (compra.Estado == "ANULADA" && compra.FechaAnulacion.HasValue)
                    txtObservaciones.Text = $"ANULADA: {compra.MotivoAnulacion} ({compra.FechaAnulacion.Value:dd/MM/yyyy HH:mm})";
                else
                    txtObservaciones.Text = compra.Observaciones;

                CargarDetallesProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    var row   = dgvDetalleProductos.Rows[index];

                    row.Cells["colNumero"].Value = numero++;
                    row.Cells["colProductoDV"].Value     = detalle.ProductoNombre;
                    row.Cells["colPresentacionDV"].Value = detalle.PresentacionNombre;

                    string simbolo  = detalle.UnidadSimbolo ?? "";
                    decimal cantPres = (decimal)detalle.Cantidad;
                    decimal cantBase = (decimal)detalle.CantidadUnidadesBase;
                    string presStr  = cantPres == Math.Floor(cantPres)
                        ? $"{(int)cantPres}"
                        : cantPres.ToString("N2");
                    string baseStr  = string.IsNullOrEmpty(simbolo)
                        ? cantBase.ToString("N2")
                        : $"{cantBase:N2} {simbolo}";
                    row.Cells["colCantidad"].Value = $"{presStr} {detalle.PresentacionNombre}\n({baseStr})";

                    decimal costoPres  = (decimal)detalle.CostoPresentacion;
                    decimal costoBase  = (decimal)detalle.CostoUnitario;
                    string presLabel   = UiUnitsHelper.NormalizeUnit(simbolo);
                    row.Cells["colCostoUnitario"].Value =
                        $"S/ {costoPres:N2}/{detalle.PresentacionNombre}  (= S/ {costoBase:N4}/{presLabel})";

                    row.Cells["colSubTotal"].Value = $"S/ {(decimal)detalle.Subtotal:N2}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var parametros  = ReportHelper.GetCompanyParameters();
                var dt          = ReportDataSourceHelper.ObtenerDatosDetalleCompra(_compraID, parametros);
                var dataSources = new Dictionary<string, DataTable> { { "DsDetalleCompra", dt } };

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Documents\RptDetalleCompra.rdlc"),
                    dataSources, parametros, "detalle_compra");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerUsuario(int usuarioID)
            => UsuarioRepository.ObtenerNombreCompletoPorID(usuarioID);

        private Proveedor ObtenerProveedor(int proveedorID)
            => ProveedorRepository.ObtenerInfoBasica(proveedorID)
               ?? new Proveedor { RazonSocial = "Desconocido", RUC = "", Telefono = "", Direccion = "" };
    }
}
