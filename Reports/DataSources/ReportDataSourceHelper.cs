using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using SistemaPOS.Data;
using SistemaPOS.Models;

namespace SistemaPOS.Reports.DataSources
{
    /// <summary>
    /// Metodos que preparan DataTables para los reportes RDLC.
    /// Cada metodo consulta datos y retorna un DataTable listo para el reporte.
    /// </summary>
    public static class ReportDataSourceHelper
    {
        // =============================================
        // REPORTES TABULARES
        // =============================================

        /// <summary>
        /// Obtiene los datos de alertas de inventario para el reporte RDLC.
        /// Retorna todos los productos activos con su estado de stock.
        /// </summary>
        public static DataTable ObtenerDatosAlertasInventario()
        {
            var dt = new DataTable("AlertasInventario");
            dt.Columns.Add("Numero", typeof(int));
            dt.Columns.Add("Codigo", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Categoria", typeof(string));
            dt.Columns.Add("StockTotal", typeof(decimal));
            dt.Columns.Add("StockMinimo", typeof(decimal));
            dt.Columns.Add("Estado", typeof(string));

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT p.Codigo, p.Nombre, p.StockTotal, p.StockMinimo,
                           c.Nombre as CategoriaNombre
                    FROM Productos p
                    INNER JOIN Categorias c ON p.CategoriaID = c.CategoriaID
                    WHERE p.Activo = 1
                    ORDER BY p.StockTotal ASC";

                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    int numero = 1;
                    while (reader.Read())
                    {
                        decimal stockTotal = reader.GetDecimal(2);
                        decimal stockMinimo = reader.GetDecimal(3);

                        string estado;
                        if (stockTotal <= 0)
                            estado = "CRÍTICO";
                        else if (stockTotal <= stockMinimo)
                            estado = "ALERTA";
                        else
                            estado = "NORMAL";

                        dt.Rows.Add(numero++,
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetString(4),
                            stockTotal,
                            stockMinimo,
                            estado);
                    }
                }
            }

            return dt;
        }

        /// <summary>
        /// Obtiene los datos de gastos operativos para el reporte RDLC.
        /// </summary>
        public static DataTable ObtenerDatosGastos(DateTime? desde, DateTime? hasta, string categoria)
        {
            var dt = new DataTable("Gastos");
            dt.Columns.Add("Numero", typeof(int));
            dt.Columns.Add("Fecha", typeof(string));
            dt.Columns.Add("Hora", typeof(string));
            dt.Columns.Add("Concepto", typeof(string));
            dt.Columns.Add("Categoria", typeof(string));
            dt.Columns.Add("Monto", typeof(decimal));
            dt.Columns.Add("MetodoPago", typeof(string));
            dt.Columns.Add("Comprobante", typeof(string));

            var gastos = GastoRepository.Listar(desde, hasta, categoria);
            int numero = 1;
            foreach (var g in gastos)
            {
                dt.Rows.Add(numero++,
                    g.Fecha.ToString("dd/MM/yyyy"),
                    g.Hora.ToString(@"hh\:mm"),
                    g.Concepto,
                    g.Categoria,
                    g.Monto,
                    g.MetodoPago,
                    string.IsNullOrEmpty(g.Comprobante) ? "-" : g.Comprobante);
            }
            return dt;
        }

        /// <summary>
        /// Obtiene los datos del libro diario para el reporte RDLC.
        /// Calcula saldo acumulado en cada fila.
        /// </summary>
        public static DataTable ObtenerDatosLibroDiario(DateTime fechaDesde, DateTime fechaHasta, string tipoMovimiento)
        {
            var dt = new DataTable("LibroDiario");
            dt.Columns.Add("Numero", typeof(int));
            dt.Columns.Add("Fecha", typeof(string));
            dt.Columns.Add("Hora", typeof(string));
            dt.Columns.Add("Tipo", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("Ingreso", typeof(decimal));
            dt.Columns.Add("Egreso", typeof(decimal));
            dt.Columns.Add("Saldo", typeof(decimal));
            dt.Columns.Add("Usuario", typeof(string));

            var movimientos = LibroDiarioRepository.ObtenerMovimientos(fechaDesde, fechaHasta, tipoMovimiento);
            decimal saldoAcumulado = 0;
            int numero = 1;

            foreach (var mov in movimientos)
            {
                saldoAcumulado += mov.Ingreso - mov.Egreso;
                dt.Rows.Add(numero++,
                    mov.Fecha.ToString("dd/MM/yyyy"),
                    mov.Hora.ToString(@"hh\:mm"),
                    mov.Tipo,
                    mov.Descripcion,
                    mov.Ingreso,
                    mov.Egreso,
                    saldoAcumulado,
                    mov.Usuario);
            }
            return dt;
        }

        /// <summary>
        /// Obtiene los datos del historial de caja para el reporte RDLC.
        /// </summary>
        public static DataTable ObtenerDatosHistorialCaja(DateTime? fechaDesde, DateTime? fechaHasta, int? usuarioID)
        {
            var dt = new DataTable("HistorialCaja");
            dt.Columns.Add("Numero", typeof(int));
            dt.Columns.Add("Fecha", typeof(string));
            dt.Columns.Add("Apertura", typeof(string));
            dt.Columns.Add("Cierre", typeof(string));
            dt.Columns.Add("Duracion", typeof(string));
            dt.Columns.Add("Usuario", typeof(string));
            dt.Columns.Add("TotalVentas", typeof(decimal));

            var historial = CajaRepository.Listar(fechaDesde, fechaHasta, usuarioID);
            int numero = 1;

            foreach (var caja in historial)
            {
                dt.Rows.Add(numero++,
                    caja.FechaApertura.ToString("dd/MM/yyyy"),
                    caja.HoraApertura.ToString(@"hh\:mm"),
                    caja.HoraCierre?.ToString(@"hh\:mm") ?? "-",
                    caja.Duracion,
                    caja.NombreUsuario,
                    caja.TotalVentas);
            }
            return dt;
        }

        /// <summary>
        /// Obtiene los datos del listado de productos para el reporte RDLC.
        /// </summary>
        public static DataTable ObtenerDatosProductos(string busqueda, string categoria, string filtroStock)
        {
            var dt = new DataTable("Productos");
            dt.Columns.Add("Numero", typeof(int));
            dt.Columns.Add("Codigo", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Categoria", typeof(string));
            dt.Columns.Add("UnidadBase", typeof(string));
            dt.Columns.Add("Presentaciones", typeof(string));
            dt.Columns.Add("Precio", typeof(string));
            dt.Columns.Add("StockTotal", typeof(string));

            var productos = ProductoRepository.BuscarProductosConDetalles(busqueda ?? "");

            // Aplicar filtro de categoría
            if (!string.IsNullOrEmpty(categoria))
            {
                var filtrados = new List<dynamic>();
                foreach (var p in productos)
                    if ((string)p.Categoria == categoria)
                        filtrados.Add(p);
                productos = filtrados;
            }

            // Aplicar filtro de stock
            if (!string.IsNullOrEmpty(filtroStock) && filtroStock != "Todos")
            {
                var filtrados = new List<dynamic>();
                foreach (var p in productos)
                {
                    decimal stock = (decimal)p.StockTotal;
                    decimal stockMin = (decimal)p.StockMinimo;
                    switch (filtroStock)
                    {
                        case "Con Stock":
                            if (stock > 0) filtrados.Add(p);
                            break;
                        case "Sin Stock":
                            if (stock <= 0) filtrados.Add(p);
                            break;
                        case "Stock Bajo":
                            if (stock > 0 && stock <= stockMin) filtrados.Add(p);
                            break;
                        default:
                            filtrados.Add(p);
                            break;
                    }
                }
                productos = filtrados;
            }

            int numero = 1;
            foreach (var p in productos)
            {
                dt.Rows.Add(numero++,
                    (string)p.Codigo,
                    (string)p.Nombre,
                    (string)p.Categoria,
                    (string)p.UnidadBase,
                    (string)p.Presentaciones,
                    (string)p.Precio,
                    $"{(decimal)p.StockTotal:N2} {(string)p.UnidadBase}");
            }
            return dt;
        }

        /// <summary>
        /// Obtiene los datos del historial de ventas para el reporte RDLC.
        /// Incluye montos por método de pago para totales desglosados.
        /// </summary>
        public static DataTable ObtenerDatosHistorialVentas(int? clienteID, string estado, string tipoComprobante, DateTime fechaDesde, DateTime fechaHasta, int? cajaID)
        {
            var dt = new DataTable("HistorialVentas");
            dt.Columns.Add("Numero", typeof(int));
            dt.Columns.Add("FechaHora", typeof(string));
            dt.Columns.Add("Comprobante", typeof(string));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Items", typeof(string));
            dt.Columns.Add("MetodoPago", typeof(string));
            dt.Columns.Add("Total", typeof(decimal));
            dt.Columns.Add("Estado", typeof(string));
            dt.Columns.Add("MontoEfectivo", typeof(decimal));
            dt.Columns.Add("MontoYape", typeof(decimal));
            dt.Columns.Add("MontoTransferencia", typeof(decimal));

            var ventas = VentaRepository.Listar(clienteID, estado, tipoComprobante, fechaDesde, fechaHasta, cajaID);
            int numero = 1;
            foreach (var venta in ventas)
            {
                dt.Rows.Add(numero++,
                    ((DateTime)venta.Fecha).ToString("dd/MM/yyyy") + " " + ((TimeSpan)venta.Hora).ToString(@"hh\:mm"),
                    (string)venta.TipoComprobante + " / " + (string)venta.NumeroVenta,
                    (string)venta.NombreCliente,
                    ((int)venta.CantidadItems).ToString() + " items",
                    (string)venta.MetodoPago,
                    (decimal)venta.Total,
                    (string)venta.Estado,
                    (decimal)venta.MontoEfectivo,
                    (decimal)venta.MontoYape,
                    (decimal)venta.MontoTransferencia);
            }
            return dt;
        }

        /// <summary>
        /// Obtiene los datos del historial de compras para el reporte RDLC.
        /// </summary>
        public static DataTable ObtenerDatosHistorialCompras(int? proveedorID, string estado, string tipoComprobante, DateTime fechaDesde, DateTime fechaHasta, string numComprobante)
        {
            var dt = new DataTable("HistorialCompras");
            dt.Columns.Add("Numero", typeof(int));
            dt.Columns.Add("FechaHora", typeof(string));
            dt.Columns.Add("Comprobante", typeof(string));
            dt.Columns.Add("Proveedor", typeof(string));
            dt.Columns.Add("Items", typeof(string));
            dt.Columns.Add("MetodoPago", typeof(string));
            dt.Columns.Add("Total", typeof(decimal));
            dt.Columns.Add("Estado", typeof(string));

            var compras = CompraRepository.Listar(proveedorID, estado, tipoComprobante, fechaDesde, fechaHasta, numComprobante);
            int numero = 1;
            foreach (var compra in compras)
            {
                dt.Rows.Add(numero++,
                    ((DateTime)compra.Fecha).ToString("dd/MM/yyyy") + " " + ((TimeSpan)compra.Hora).ToString(@"hh\:mm"),
                    (string)compra.TipoComprobante + " / " + (string)compra.NumeroCompra,
                    (string)compra.NombreProveedor,
                    ((int)compra.CantidadItems).ToString() + " items",
                    (string)compra.MetodoPago,
                    (decimal)compra.Total,
                    (string)compra.Estado);
            }
            return dt;
        }

        /// <summary>
        /// Obtiene los datos del Kardex para el reporte RDLC.
        /// Permite valorizacion por PROMEDIO o PEPS.
        /// </summary>
        public static DataTable ObtenerDatosKardex(int? productoID, DateTime fechaDesde, DateTime fechaHasta, string metodoValorizacion)
        {
            var dt = new DataTable("Kardex");
            dt.Columns.Add("Numero", typeof(int));
            dt.Columns.Add("FechaHora", typeof(string));
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("TipoMovimiento", typeof(string));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Entrada", typeof(decimal));
            dt.Columns.Add("Salida", typeof(decimal));
            dt.Columns.Add("StockAnterior", typeof(decimal));
            dt.Columns.Add("StockPosterior", typeof(decimal));
            dt.Columns.Add("CostoUnitario", typeof(decimal));
            dt.Columns.Add("CostoMovimiento", typeof(decimal));
            dt.Columns.Add("CostoSaldo", typeof(decimal));
            dt.Columns.Add("CostoPromedio", typeof(decimal));
            dt.Columns.Add("Usuario", typeof(string));
            dt.Columns.Add("PresentacionInfo", typeof(string));

            List<KardexMovimiento> movimientos = KardexRepository.ObtenerMovimientos(
                productoID, fechaDesde, fechaHasta, metodoValorizacion);

            int numero = 1;
            foreach (var mov in movimientos)
            {
                dt.Rows.Add(
                    numero++,
                    mov.FechaHora.ToString("dd/MM/yyyy HH:mm"),
                    mov.ProductoNombre,
                    mov.TipoMovimiento,
                    mov.Documento,
                    mov.Entrada,
                    mov.Salida,
                    mov.StockAnterior,
                    mov.StockPosterior,
                    mov.CostoUnitario,
                    mov.CostoMovimiento,
                    mov.CostoSaldo,
                    mov.CostoPromedio,
                    mov.UsuarioNombre,
                    mov.PresentacionInfo ?? ""
                );
            }

            return dt;
        }

        /// <summary>
        /// Obtiene los datos tabulares de cuentas por cobrar.
        /// </summary>
        public static DataTable ObtenerDatosCuentasPorCobrar(int? clienteID, string estado, string busqueda, bool soloVencidas)
        {
            var dt = new DataTable("CuentasPorCobrar");
            dt.Columns.Add("Numero", typeof(int));
            dt.Columns.Add("NumeroVenta", typeof(string));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("FechaVenta", typeof(string));
            dt.Columns.Add("FechaVencimiento", typeof(string));
            dt.Columns.Add("DiasVencidos", typeof(int));
            dt.Columns.Add("TotalCredito", typeof(decimal));
            dt.Columns.Add("MontoPagado", typeof(decimal));
            dt.Columns.Add("SaldoPendiente", typeof(decimal));
            dt.Columns.Add("Estado", typeof(string));

            var cuentas = CuentaPorCobrarRepository.Listar(clienteID, estado, busqueda, soloVencidas);
            int numero = 1;
            foreach (var c in cuentas)
            {
                dt.Rows.Add(
                    numero++,
                    c.NumeroVenta,
                    c.NombreCliente,
                    c.FechaVenta.ToString("dd/MM/yyyy"),
                    c.FechaVencimiento.ToString("dd/MM/yyyy"),
                    c.DiasVencidos,
                    c.TotalCredito,
                    c.MontoPagado,
                    c.SaldoPendiente,
                    c.Estado
                );
            }

            return dt;
        }

        /// <summary>
        /// Obtiene los datos tabulares de cuentas por pagar.
        /// </summary>
        public static DataTable ObtenerDatosCuentasPorPagar(int? proveedorID, string estado)
        {
            var dt = new DataTable("CuentasPorPagar");
            dt.Columns.Add("Numero", typeof(int));
            dt.Columns.Add("NumeroCompra", typeof(string));
            dt.Columns.Add("Proveedor", typeof(string));
            dt.Columns.Add("FechaCompra", typeof(string));
            dt.Columns.Add("FechaVencimiento", typeof(string));
            dt.Columns.Add("MontoTotal", typeof(decimal));
            dt.Columns.Add("MontoPagado", typeof(decimal));
            dt.Columns.Add("MontoPendiente", typeof(decimal));
            dt.Columns.Add("Estado", typeof(string));

            var cuentas = CuentaPorPagarRepository.Listar(proveedorID, estado);
            int numero = 1;
            foreach (var c in cuentas)
            {
                dt.Rows.Add(
                    numero++,
                    c.Referencia,
                    c.NombreProveedor,
                    (c.FechaOrigen != DateTime.MinValue ? c.FechaOrigen.ToString("dd/MM/yyyy") : c.FechaEmision),
                    c.FechaVencimiento.HasValue ? c.FechaVencimiento.Value.ToString("dd/MM/yyyy") : "-",
                    c.MontoTotal,
                    c.MontoPagado,
                    c.MontoPendiente,
                    c.Estado
                );
            }

            return dt;
        }

        // =============================================
        // REPORTES TIPO DOCUMENTO
        // =============================================

        /// <summary>
        /// Obtiene datos del ticket de venta: detalles de productos y parámetros del encabezado.
        /// </summary>
        public static DataTable ObtenerDatosTicketVenta(int ventaID, Dictionary<string, string> parametros)
        {
            var dt = new DataTable("DetalleVenta");
            dt.Columns.Add("Numero", typeof(int));
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("Presentacion", typeof(string));
            dt.Columns.Add("Cantidad", typeof(decimal));
            dt.Columns.Add("PrecioUnitario", typeof(decimal));
            dt.Columns.Add("SubTotal", typeof(decimal));

            var venta = VentaRepository.ObtenerPorID(ventaID);
            if (venta == null) return dt;

            parametros["pTipoComprobante"] = venta.TipoComprobante;
            parametros["pNumeroVenta"] = venta.NumeroVenta;
            parametros["pFecha"] = venta.Fecha.ToString("dd/MM/yyyy");
            parametros["pHora"] = venta.Hora.ToString(@"hh\:mm\:ss");
            parametros["pEstado"] = venta.Estado;
            parametros["pMetodoPago"] = venta.MetodoPago;
            parametros["pSubTotal"] = $"S/ {venta.SubTotal:N2}";
            decimal descuento = venta.SubTotal + venta.IGV - venta.Total;
            parametros["pDescuento"] = $"S/ {descuento:N2}";
            parametros["pIGV"] = $"S/ {venta.IGV:N2}";
            parametros["pTotal"] = $"S/ {venta.Total:N2}";

            string nombreCliente = "CLIENTE GENERAL";
            string docCliente = "00000000";
            if (venta.ClienteID.HasValue && venta.ClienteID.Value > 0)
            {
                var cliente = ClienteRepository.ObtenerPorID(venta.ClienteID.Value);
                if (cliente != null)
                {
                    nombreCliente = cliente.TipoDocumento == "RUC" ? cliente.RazonSocial : $"{cliente.Nombres} {cliente.Apellidos}";
                    docCliente = cliente.NumeroDocumento;
                }
            }
            parametros["pCliente"] = nombreCliente;
            parametros["pDocCliente"] = docCliente;

            string encargado = "Usuario";
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT NombreCompleto FROM Usuarios WHERE UsuarioID = @ID", conn);
                    cmd.Parameters.AddWithValue("@ID", venta.UsuarioID);
                    encargado = cmd.ExecuteScalar()?.ToString() ?? "Usuario";
                }
            }
            catch { }
            parametros["pEncargado"] = encargado;

            var detalles = VentaRepository.ObtenerDetalles(ventaID);
            int numero = 1;
            foreach (var detalle in detalles)
            {
                dt.Rows.Add(numero++,
                    (string)detalle.Producto,
                    detalle.UnidadSimbolo ?? "",
                    (decimal)detalle.CantidadUnidadesBase,
                    (decimal)detalle.PrecioUnitario,
                    (decimal)detalle.Subtotal);
            }
            return dt;
        }

        /// <summary>
        /// Obtiene datos del detalle de compra: detalles de productos y parámetros del encabezado.
        /// </summary>
        public static DataTable ObtenerDatosDetalleCompra(int compraID, Dictionary<string, string> parametros)
        {
            var dt = new DataTable("DetalleCompra");
            dt.Columns.Add("Numero", typeof(int));
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("Presentacion", typeof(string));
            dt.Columns.Add("Cantidad", typeof(string));
            dt.Columns.Add("CostoUnitario", typeof(decimal));
            dt.Columns.Add("SubTotal", typeof(decimal));

            var compra = CompraRepository.ObtenerPorID(compraID);
            if (compra == null) return dt;

            parametros["pTipoComprobante"] = compra.TipoComprobante;
            parametros["pNumeroCompra"] = compra.NumeroCompra;
            parametros["pFecha"] = compra.Fecha.ToString("dd/MM/yyyy");
            parametros["pHora"] = compra.Hora.ToString(@"hh\:mm\:ss");
            parametros["pEstado"] = compra.Estado;
            parametros["pSubTotal"] = $"S/ {compra.SubTotal:N2}";
            parametros["pIGV"] = $"S/ {compra.IGV:N2}";
            parametros["pTotal"] = $"S/ {compra.Total:N2}";
            parametros["pObservaciones"] = compra.Observaciones ?? "";

            string proveedor = "Desconocido";
            string rucProveedor = "";
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT RazonSocial, RUC FROM Proveedores WHERE ProveedorID = @ID", conn);
                    cmd.Parameters.AddWithValue("@ID", compra.ProveedorID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            proveedor = reader.IsDBNull(0) ? "" : reader.GetString(0);
                            rucProveedor = reader.IsDBNull(1) ? "" : reader.GetString(1);
                        }
                    }
                }
            }
            catch { }
            parametros["pProveedor"] = proveedor;
            parametros["pRUCProveedor"] = rucProveedor;

            string encargado = "Desconocido";
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT NombreCompleto FROM Usuarios WHERE UsuarioID = @ID", conn);
                    cmd.Parameters.AddWithValue("@ID", compra.UsuarioID);
                    encargado = cmd.ExecuteScalar()?.ToString() ?? "Desconocido";
                }
            }
            catch { }
            parametros["pEncargado"] = encargado;
            parametros["pMetodoPago"] = compra.MetodoPago;

            var detalles = CompraRepository.ObtenerDetalles(compraID);
            int numero = 1;
            foreach (var detalle in detalles)
            {
                string simbolo = detalle.UnidadSimbolo ?? "";
                string cantidadTexto = ((decimal)detalle.CantidadUnidadesBase).ToString("N2")
                    + (string.IsNullOrEmpty(simbolo) ? "" : " " + simbolo);
                dt.Rows.Add(numero++,
                    (string)detalle.ProductoNombre,
                    (string)detalle.PresentacionNombre,
                    cantidadTexto,
                    (decimal)detalle.CostoUnitario,
                    (decimal)detalle.Subtotal);
            }
            return dt;
        }

        /// <summary>
        /// Obtiene datos del estado de cuenta de un cliente: movimientos y parámetros resumen.
        /// </summary>
        public static DataTable ObtenerDatosEstadoCuenta(int clienteID, DateTime? fechaDesde, DateTime? fechaHasta, Dictionary<string, string> parametros)
        {
            var dt = new DataTable("Movimientos");
            dt.Columns.Add("Numero", typeof(int));
            dt.Columns.Add("FechaHora", typeof(string));
            dt.Columns.Add("Tipo", typeof(string));
            dt.Columns.Add("Detalle", typeof(string));
            dt.Columns.Add("Cargo", typeof(decimal));
            dt.Columns.Add("Abono", typeof(decimal));
            dt.Columns.Add("Saldo", typeof(decimal));

            var estadoCuenta = ClienteRepository.ObtenerEstadoCuenta(clienteID);
            var cliente = estadoCuenta.Cliente;

            string nombreCliente = cliente.TipoDocumento == "RUC" ? cliente.RazonSocial : $"{cliente.Nombres} {cliente.Apellidos}";
            parametros["pCliente"] = nombreCliente;
            parametros["pDocumento"] = $"{cliente.TipoDocumento} - {cliente.NumeroDocumento}";
            parametros["pTotalVentas"] = $"S/ {estadoCuenta.TotalVentas:N2}";
            parametros["pTotalPagos"] = $"S/ {estadoCuenta.TotalPagos:N2}";
            parametros["pSaldoPendiente"] = $"S/ {estadoCuenta.SaldoPendiente:N2}";
            parametros["pLimiteCredito"] = $"S/ {estadoCuenta.LimiteCredito:N2}";
            parametros["pCreditoDisponible"] = $"S/ {estadoCuenta.CreditoDisponible:N2}";

            var movimientos = ClienteRepository.ObtenerMovimientos(clienteID, fechaDesde, fechaHasta);
            int numero = 1;
            foreach (var mov in movimientos)
            {
                dt.Rows.Add(numero++,
                    mov.Fecha.ToString("dd/MM/yyyy") + " " + mov.Hora.ToString(@"hh\:mm"),
                    (string)mov.Tipo,
                    (string)mov.Detalle,
                    (decimal)mov.Cargo,
                    (decimal)mov.Abono,
                    (decimal)mov.Saldo);
            }
            return dt;
        }

        /// <summary>
        /// Obtiene los parámetros del detalle/cierre de caja para el reporte RDLC (solo parámetros, sin dataset).
        /// </summary>
        public static void ObtenerParametrosDetalleCaja(int cajaID, Dictionary<string, string> parametros)
        {
            var caja = CajaRepository.ObtenerPorID(cajaID);
            if (caja == null) return;

            string encargado = "Desconocido";
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT NombreCompleto FROM Usuarios WHERE UsuarioID = @ID", conn);
                    cmd.Parameters.AddWithValue("@ID", caja.UsuarioID);
                    encargado = cmd.ExecuteScalar()?.ToString() ?? "Desconocido";
                }
            }
            catch { }

            int operaciones = 0;
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Ventas WHERE CajaID = @cajaID AND Estado != 'ANULADA'", conn);
                    cmd.Parameters.AddWithValue("@cajaID", cajaID);
                    operaciones = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch { }

            parametros["pEncargado"] = encargado;
            parametros["pTurno"] = caja.Turno;
            parametros["pFechaApertura"] = caja.FechaApertura.ToString("dd/MM/yyyy");
            parametros["pHoraApertura"] = caja.HoraApertura.ToString(@"hh\:mm\:ss");
            parametros["pHoraCierre"] = caja.HoraCierre?.ToString(@"hh\:mm") ?? "-";

            if (caja.HoraCierre.HasValue)
            {
                var duracion = caja.HoraCierre.Value - caja.HoraApertura;
                parametros["pDuracion"] = $"{(int)duracion.TotalHours}h {duracion.Minutes}m";
            }
            else
            {
                parametros["pDuracion"] = "En curso";
            }

            parametros["pOperaciones"] = operaciones.ToString();
            parametros["pEfectivo"] = $"S/ {caja.TotalEfectivo:N2}";
            parametros["pYape"] = $"S/ {caja.TotalYape:N2}";
            parametros["pTransferencia"] = $"S/ {caja.TotalTransferencia:N2}";
            parametros["pCredito"] = $"S/ {caja.TotalCredito:N2}";
            parametros["pTotalVentas"] = $"S/ {caja.TotalVentas:N2}";
            parametros["pGastos"] = $"S/ {caja.TotalGastos:N2}";
            parametros["pFondoInicial"] = $"S/ {caja.MontoInicial:N2}";
            parametros["pEfectivoVentas"] = $"S/ {caja.TotalEfectivo:N2}";
            parametros["pEfectivoEsperado"] = $"S/ {caja.EfectivoEsperado:N2}";
            parametros["pEfectivoReal"] = $"S/ {caja.EfectivoReal:N2}";
            parametros["pDiferencia"] = $"S/ {caja.Diferencia:N2}";
            parametros["pMotivo"] = caja.MotivoDiferencia ?? "";
        }

        // =============================================
        // REPORTES FINANCIEROS
        // =============================================

        /// <summary>
        /// Obtiene los datos del flujo de caja para el reporte RDLC.
        /// </summary>
        public static DataTable ObtenerDatosFlujoCaja(DateTime fechaDesde, DateTime fechaHasta)
        {
            var dt = new DataTable("FlujoCaja");
            dt.Columns.Add("Concepto", typeof(string));
            dt.Columns.Add("Ingreso", typeof(decimal));
            dt.Columns.Add("Egreso", typeof(decimal));
            dt.Columns.Add("Flujo", typeof(decimal));

            var items = FlujoCajaRepository.ObtenerFlujoCaja(fechaDesde, fechaHasta);
            foreach (var item in items)
            {
                dt.Rows.Add(item.Concepto, item.Ingreso, item.Egreso, item.Ingreso - item.Egreso);
            }
            return dt;
        }

        /// <summary>
        /// Obtiene los datos del estado de resultados para el reporte RDLC.
        /// Incluye campo Estilo para formato condicional (header, normal, total, result).
        /// </summary>
        public static DataTable ObtenerDatosEstadoResultados(DateTime fechaDesde, DateTime fechaHasta)
        {
            var dt = new DataTable("EstadoResultados");
            dt.Columns.Add("Concepto", typeof(string));
            dt.Columns.Add("Monto", typeof(string));
            dt.Columns.Add("MontoDecimal", typeof(decimal));
            dt.Columns.Add("Estilo", typeof(string));

            var estado = EstadoResultadosRepository.Calcular(fechaDesde, fechaHasta);

            dt.Rows.Add("INGRESOS", "", 0m, "header");
            dt.Rows.Add("  Ventas", $"S/ {estado.VentasBrutas:N2}", estado.VentasBrutas, "normal");

            dt.Rows.Add("COSTOS", "", 0m, "header");
            dt.Rows.Add("  Costo de Mercadería", $"S/ {estado.CostoMercaderia:N2}", estado.CostoMercaderia, "normal");

            dt.Rows.Add("UTILIDAD BRUTA", $"S/ {estado.UtilidadBruta:N2}", estado.UtilidadBruta, "total");

            dt.Rows.Add("GASTOS OPERATIVOS", "", 0m, "header");
            foreach (var gasto in estado.GastosPorCategoria)
            {
                dt.Rows.Add($"  {gasto.Key}", $"S/ {gasto.Value:N2}", gasto.Value, "normal");
            }
            dt.Rows.Add("  Total Gastos", $"S/ {estado.TotalGastos:N2}", estado.TotalGastos, "normal");

            dt.Rows.Add("UTILIDAD NETA", $"S/ {estado.UtilidadNeta:N2}", estado.UtilidadNeta, "result");

            return dt;
        }

        /// <summary>
        /// Obtiene los datos del balance general para el reporte RDLC.
        /// Incluye campo Estilo para formato condicional.
        /// </summary>
        public static DataTable ObtenerDatosBalanceGeneral(DateTime fechaCorte)
        {
            var dt = new DataTable("BalanceGeneral");
            dt.Columns.Add("Concepto", typeof(string));
            dt.Columns.Add("Monto", typeof(string));
            dt.Columns.Add("MontoDecimal", typeof(decimal));
            dt.Columns.Add("Estilo", typeof(string));

            var balance = BalanceRepository.Calcular(fechaCorte);

            dt.Rows.Add("ACTIVOS", "", 0m, "header");
            dt.Rows.Add("  Efectivo en Caja", $"S/ {balance.Efectivo:N2}", balance.Efectivo, "normal");
            dt.Rows.Add("  Inventario", $"S/ {balance.Inventario:N2}", balance.Inventario, "normal");
            dt.Rows.Add("  Cuentas por Cobrar", $"S/ {balance.CuentasPorCobrar:N2}", balance.CuentasPorCobrar, "normal");
            dt.Rows.Add("TOTAL ACTIVOS", $"S/ {balance.TotalActivos:N2}", balance.TotalActivos, "total-green");

            dt.Rows.Add("", "", 0m, "separator");

            dt.Rows.Add("PASIVOS", "", 0m, "header");
            dt.Rows.Add("  Cuentas por Pagar", $"S/ {balance.CuentasPorPagar:N2}", balance.CuentasPorPagar, "normal");
            dt.Rows.Add("TOTAL PASIVOS", $"S/ {balance.TotalPasivos:N2}", balance.TotalPasivos, "total-red");

            dt.Rows.Add("", "", 0m, "separator");

            dt.Rows.Add("PATRIMONIO", "", 0m, "header");
            dt.Rows.Add("  Capital", $"S/ {balance.Capital:N2}", balance.Capital, "normal");
            dt.Rows.Add("  Utilidad Acumulada", $"S/ {balance.UtilidadAcumulada:N2}", balance.UtilidadAcumulada, "normal");
            dt.Rows.Add("PATRIMONIO NETO", $"S/ {balance.TotalPatrimonio:N2}", balance.TotalPatrimonio, "result");

            return dt;
        }
    }
}
