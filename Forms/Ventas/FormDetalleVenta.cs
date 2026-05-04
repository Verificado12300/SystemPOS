using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Reports.DataSources;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Ventas
{
    public partial class FormDetalleVenta : Form
    {
        private int _ventaID;

        public FormDetalleVenta(int ventaID)
        {
            InitializeComponent();
            _ventaID = ventaID;
            ConfigurarEventos();
            ConfigurarDataGridView();
            CargarDatosVenta();
        }

        private void ConfigurarEventos()
        {
            btnCerrar.Click += (s, e) => this.Close();
            btnImprimir.Click += BtnImprimir_Click;

            this.Shown += (s, e) =>
            {
                dgvDetalleProductos.Columns["colNumero"].Width         = 60;
                dgvDetalleProductos.Columns["colPresentacionDV"].Width = 200;
                dgvDetalleProductos.Columns["colCantidad"].Width       = 130;
                dgvDetalleProductos.Columns["colPrecioUnitario"].Width = 160;
                dgvDetalleProductos.Columns["colSubTotal"].Width       = 150;
            };
        }

        private void ConfigurarDataGridView()
        {
            dgvDetalleProductos.AutoGenerateColumns = false;
            DgvStyleHelper.Aplicar(dgvDetalleProductos);
            dgvDetalleProductos.AllowUserToAddRows = false;
            dgvDetalleProductos.ReadOnly = true;

        }

        private void CargarDatosVenta()
        {
            try
            {
                var venta = VentaRepository.ObtenerPorID(_ventaID);

                if (venta == null)
                {
                    MessageBox.Show("Venta no encontrada", "Error");
                    this.Close();
                    return;
                }

                // Datos del comprobante
                txtTipoComprobante.Text = venta.TipoComprobante;
                txtNumeroSerie.Text = $"{venta.Serie}-{venta.Numero}";
                txtFecha.Text = venta.Fecha.ToString("dd/MM/yyyy");
                txtHora.Text = venta.Hora.ToString(@"hh\:mm\:ss");

                // Usuario encargado
                var usuario = ObtenerUsuario(venta.UsuarioID);
                txtEncargado.Text = usuario;

                // Estado
                string estadoTexto = venta.Estado == "COMPLETADA" ? "Completada" :
                                   venta.Estado == "CREDITO" ? "Credito" :
                                   venta.Estado == "ANULADA" ? "Anulada" : venta.Estado;
                txtEstado.Text = estadoTexto;

                // Datos del cliente
                var cliente = (venta.ClienteID.HasValue && venta.ClienteID.Value > 0) ? ClienteRepository.ObtenerPorID(venta.ClienteID.Value) : null;
                if (cliente != null)
                {
                    lblDNIRUC.Text = $"{cliente.TipoDocumento}:";
                    txtDNIRUC.Text = cliente.NumeroDocumento;
                    txtNombreRazonSocial.Text = cliente.TipoDocumento == "RUC" ?
                        cliente.RazonSocial : $"{cliente.Nombres} {cliente.Apellidos}";
                    txtTelefono.Text = cliente.Telefono;
                    txtDireccion.Text = cliente.Direccion;
                }

                // Método de pago
                lblMetodoPago.Text = "Método de Pago:";
                txtMetodoPago.Text = venta.MetodoPago;

                // Totales
                txtSubTotal.Text = $"S/ {venta.SubTotal:N2}";
                decimal descuento = venta.SubTotal + venta.IGV - venta.Total;
                txtDescuento.Text = $"S/ {descuento:N2}";
                txtIGV.Text = $"S/ {venta.IGV:N2}";
                txtTotal.Text = $"S/ {venta.Total:N2}";

                // Recibido y vuelto (solo si no es crédito)
                if (venta.MetodoPago != "CREDITO")
                {
                    decimal totalRecibido = venta.MontoEfectivo + venta.MontoYape +
                                          venta.MontoTarjeta + venta.MontoTransferencia;
                    decimal vuelto = totalRecibido - venta.Total;

                    txtRecibido.Text = $"S/ {totalRecibido:N2}";
                    txtVuelto.Text = $"S/ {vuelto:N2}";
                }
                else
                {
                    txtRecibido.Text = "S/ 0.00";
                    txtVuelto.Text = "S/ 0.00";
                }

                // Cargar productos
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
                var detalles = VentaRepository.ObtenerDetalles(_ventaID);

                dgvDetalleProductos.Rows.Clear();
                int numero = 1;

                foreach (var detalle in detalles)
                {
                    int index = dgvDetalleProductos.Rows.Add();
                    var row = dgvDetalleProductos.Rows[index];

                    string simbolo = detalle.UnidadSimbolo ?? "";
                    decimal cantPres = (decimal)detalle.Cantidad;
                    decimal cantBase = (decimal)detalle.CantidadUnidadesBase;
                    string presStr = cantPres == Math.Floor(cantPres) ? $"{(int)cantPres}" : cantPres.ToString("N2");
                    string baseStr = string.IsNullOrEmpty(simbolo) ? cantBase.ToString("N2") : $"{cantBase:N2} {simbolo}";

                    row.Cells["colNumero"].Value = numero++;
                    row.Cells["colProductoDV"].Value = detalle.Producto;
                    row.Cells["colPresentacionDV"].Value = detalle.Presentacion;
                    row.Cells["colCantidad"].Value = $"{presStr} {detalle.Presentacion}\n({baseStr})";
                    string presNombreVenta = string.IsNullOrWhiteSpace(detalle.Presentacion?.ToString())
                        ? "pres." : detalle.Presentacion.ToString();
                    row.Cells["colPrecioUnitario"].Value = $"S/ {(decimal)detalle.PrecioUnitario:N2} / {presNombreVenta}";
                    row.Cells["colSubTotal"].Value = "S/ " + ((decimal)detalle.Subtotal).ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error");
            }
        }

        private string ObtenerUsuario(int usuarioID)
        {
            return UsuarioRepository.ObtenerNombreCompletoPorID(usuarioID);
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var parametros = ReportHelper.GetCompanyParameters();
                var dt = ReportDataSourceHelper.ObtenerDatosTicketVenta(_ventaID, parametros);

                using (var preview = new FormCobrarConTicket(dt, parametros))
                    preview.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}