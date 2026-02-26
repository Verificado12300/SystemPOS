using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SistemaPOS.Models;

namespace SistemaPOS.Data
{
    /// <summary>
    /// Servicio de contabilidad de partida doble.
    /// Todos los métodos operan DENTRO de la conexión y transacción que reciben
    /// (la misma que usa la operación de negocio). Nunca abren conexión propia.
    ///
    /// Reglas:
    ///   - Si monto == 0  → retorna silenciosamente (sin MessageBox, sin excepción).
    ///   - Si cuenta no existe → lanza excepción → rollback en el llamador.
    ///   - Siempre Debe == Haber; lo valida ContabilidadRepository.CrearAsientoCompleto.
    /// </summary>
    public static class ContabilidadService
    {
        // ==================================================================
        // VENTAS
        // ==================================================================

        /// <summary>
        /// Asiento de INGRESO (solo). Costo de Ventas → segunda etapa.
        ///   EFECTIVO / YAPE          : Dr 101 Caja   = Total
        ///   TARJETA / TRANSFERENCIA  : Dr 102 Bancos  = Total
        ///   CREDITO                  : Dr 120 CxC     = Total
        ///   MIXTO                    : Dr 101 = (Efectivo+Yape), Dr 102 = (Tarjeta+Transf)
        ///                              Cr 400 Ventas  = Total
        /// </summary>
        public static void RegistrarVenta(
            long ventaID, string numeroVenta, DateTime fecha, TimeSpan hora,
            decimal total, string metodoPago,
            decimal montoEfectivo, decimal montoYape,
            decimal montoTarjeta, decimal montoTransferencia,
            int usuarioID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            if (total <= 0m) return;

            var asiento = BuildAsiento("VENTA", numeroVenta, ventaID, usuarioID,
                fecha, hora, $"Venta {numeroVenta}");

            BuildDebitLinesVenta(asiento, total, metodoPago,
                montoEfectivo, montoYape, montoTarjeta, montoTransferencia,
                false, conn, tx);

            var cuentaVentas = GetCuenta("400", conn, tx);
            AddLine(asiento, cuentaVentas.CuentaID, 0m, total, "Ingresos por ventas");

            ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
        }

        /// <summary>
        /// Reverso del asiento de venta al anular.
        ///   Dr 400 Ventas  = Total
        ///   Cr 101/102/120 = Total  (según MetodoPago original)
        /// Consulta los datos de la venta desde la misma transacción activa.
        /// </summary>
        public static void ReversarVenta(int ventaID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            // Leer datos de la venta desde la misma tx (ya está marcada ANULADA en este punto)
            string sql = @"SELECT NumeroVenta, Fecha, Hora, Total, MetodoPago,
                                  MontoEfectivo, MontoYape, MontoTarjeta, MontoTransferencia,
                                  UsuarioID
                           FROM Ventas WHERE VentaID = @ID";
            using (var cmd = new SQLiteCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@ID", ventaID);
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return;

                    string numeroVenta   = r.GetString(0);
                    DateTime fecha       = DateTime.Parse(r.GetString(1));
                    TimeSpan hora        = TimeSpan.Parse(r.GetString(2));
                    decimal total        = r.GetDecimal(3);
                    string metodoPago    = r.GetString(4);
                    decimal montoEfectivo    = r.IsDBNull(5) ? 0m : r.GetDecimal(5);
                    decimal montoYape        = r.IsDBNull(6) ? 0m : r.GetDecimal(6);
                    decimal montoTarjeta     = r.IsDBNull(7) ? 0m : r.GetDecimal(7);
                    decimal montoTransf      = r.IsDBNull(8) ? 0m : r.GetDecimal(8);
                    int usuarioID            = r.IsDBNull(9) ? 1  : r.GetInt32(9);

                    if (total <= 0m) return;

                    var asiento = BuildAsiento("ANULACION", numeroVenta, ventaID, usuarioID,
                        DateTime.Now.Date, DateTime.Now.TimeOfDay,
                        $"Anulación venta {numeroVenta}");

                    // Dr 400 Ventas
                    var cuentaVentas = GetCuenta("400", conn, tx);
                    AddLine(asiento, cuentaVentas.CuentaID, total, 0m, "Anulación ingresos por ventas");

                    // Cr Caja/Bancos/CxC (lado opuesto)
                    BuildDebitLinesVenta(asiento, total, metodoPago,
                        montoEfectivo, montoYape, montoTarjeta, montoTransf,
                        true, conn, tx);

                    ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
                }
            }
        }

        /// <summary>
        /// Asiento de COSTO DE VENTAS al registrar una venta.
        ///   Dr 500 Costo de Ventas = Σ(costo_promedio × cantidad) por producto
        ///   Cr 140 Inventario       = mismo total
        /// Si no hay costo calculable para un ítem se usa fallback (CostoPromPonderado del producto).
        /// Si el total sigue en 0, omite silenciosamente sin romper la transacción.
        /// </summary>
        public static void RegistrarCostoVenta(
            long ventaID, string numeroVenta, DateTime fecha, TimeSpan hora,
            System.Collections.Generic.List<(int ProductoID, decimal CantidadBase)> detalles,
            int usuarioID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            decimal totalCOGS = 0m;
            foreach (var d in detalles)
            {
                decimal costoUnit = ContabilidadRepository
                    .ObtenerCostoPromedioUnitarioProducto(d.ProductoID, conn, tx);

                if (costoUnit <= 0m)
                {
                    costoUnit = ObtenerCostoProdFallback(d.ProductoID, conn, tx);
                    if (costoUnit > 0m)
                        System.Diagnostics.Debug.WriteLine(
                            $"[COGS] Fallback costo para productoID={d.ProductoID}: {costoUnit:N2}");
                }

                if (costoUnit <= 0m) continue; // producto sin precio de costo: omitir silenciosamente
                totalCOGS += costoUnit * d.CantidadBase;
            }

            if (totalCOGS <= 0m) return;

            var asiento = BuildAsiento("VENTA", numeroVenta, ventaID, usuarioID,
                fecha, hora, $"Costo de venta {numeroVenta}");

            var cuentaCOGS = GetCuenta("500", conn, tx);
            var cuentaInv  = GetCuenta("140", conn, tx);
            AddLine(asiento, cuentaCOGS.CuentaID, totalCOGS, 0m,       "Costo de ventas");
            AddLine(asiento, cuentaInv.CuentaID,  0m, totalCOGS, "Salida de inventario por venta");

            ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
        }

        /// <summary>
        /// Reverso exacto del asiento de costo al anular una venta.
        /// Busca el monto COGS del asiento original (TipoOperacion='VENTA', cuenta 500)
        /// y genera la entrada inversa: Dr 140 / Cr 500.
        /// Si la venta original no tenía asiento de costo, retorna silenciosamente.
        /// </summary>
        public static void ReversarCostoVenta(int ventaID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            // Obtener el monto COGS del asiento original de esta venta
            const string sqlCOGS = @"
                SELECT ad.Debe
                FROM   Asientos a
                JOIN   AsientosDetalle ad ON a.AsientoID = ad.AsientoID
                JOIN   CuentasContables cc ON ad.CuentaID = cc.CuentaID
                WHERE  a.ReferenciaID   = @VentaID
                  AND  a.TipoOperacion  = 'VENTA'
                  AND  cc.Codigo        = '500'
                LIMIT 1";

            decimal monto = 0m;
            using (var cmd = new SQLiteCommand(sqlCOGS, conn, tx))
            {
                cmd.Parameters.AddWithValue("@VentaID", ventaID);
                var r = cmd.ExecuteScalar();
                if (r == null || r == DBNull.Value) return; // no había COGS → nada que revertir
                monto = Convert.ToDecimal(r);
            }
            if (monto <= 0m) return;

            // Obtener metadatos de la venta para el asiento de reversión
            const string sqlVenta = @"
                SELECT NumeroVenta, Fecha, Hora, UsuarioID
                FROM   Ventas WHERE VentaID = @ID";
            using (var cmd = new SQLiteCommand(sqlVenta, conn, tx))
            {
                cmd.Parameters.AddWithValue("@ID", ventaID);
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return;

                    string numVenta = r.GetString(0);
                    DateTime fecha  = DateTime.Parse(r.GetString(1));
                    TimeSpan hora   = TimeSpan.Parse(r.GetString(2));
                    int usuarioID   = r.IsDBNull(3) ? 1 : r.GetInt32(3);

                    var asiento = BuildAsiento("ANULACION", numVenta, ventaID, usuarioID,
                        DateTime.Now.Date, DateTime.Now.TimeOfDay,
                        $"Reversión costo venta {numVenta}");

                    var cuentaInv  = GetCuenta("140", conn, tx);
                    var cuentaCOGS = GetCuenta("500", conn, tx);
                    AddLine(asiento, cuentaInv.CuentaID,  monto, 0m, "Devolución de inventario");
                    AddLine(asiento, cuentaCOGS.CuentaID, 0m, monto, "Reversión costo de ventas");

                    ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
                }
            }
        }

        // ==================================================================
        // COMPRAS
        // ==================================================================

        /// <summary>
        ///   Dr 140 Inventario = Total
        ///   Cr 101 Caja / 102 Bancos / 200 CxP  (según MetodoPago)
        /// </summary>
        public static void RegistrarCompra(
            long compraID, string numeroCompra, DateTime fecha, TimeSpan hora,
            decimal total, string metodoPago, int usuarioID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            if (total <= 0m) return;

            var asiento = BuildAsiento("COMPRA", numeroCompra, compraID, usuarioID,
                fecha, hora, $"Compra {numeroCompra}");

            var cuentaInv = GetCuenta("140", conn, tx);
            AddLine(asiento, cuentaInv.CuentaID, total, 0m, "Ingreso de mercadería");

            string codigoCr = MetodoPagoCompraACuenta(metodoPago);
            var cuentaCr = GetCuenta(codigoCr, conn, tx);
            AddLine(asiento, cuentaCr.CuentaID, 0m, total,
                $"Pago compra ({metodoPago})");

            ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
        }

        /// <summary>
        /// Reverso del asiento de compra al anular.
        /// </summary>
        public static void ReversarCompra(int compraID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            string sql = @"SELECT NumeroCompra, Fecha, Hora, Total, MetodoPago, UsuarioID
                           FROM Compras WHERE CompraID = @ID";
            using (var cmd = new SQLiteCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@ID", compraID);
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return;

                    string numeroCompra = r.GetString(0);
                    DateTime fecha      = DateTime.Parse(r.GetString(1));
                    TimeSpan hora       = TimeSpan.Parse(r.GetString(2));
                    decimal total       = r.GetDecimal(3);
                    string metodoPago   = r.GetString(4);
                    int usuarioID       = r.IsDBNull(5) ? 1 : r.GetInt32(5);

                    if (total <= 0m) return;

                    var asiento = BuildAsiento("ANULACION", numeroCompra, compraID, usuarioID,
                        DateTime.Now.Date, DateTime.Now.TimeOfDay,
                        $"Anulación compra {numeroCompra}");

                    // Dr Caja/Bancos/CxP (reverso del crédito original)
                    string codigoDr = MetodoPagoCompraACuenta(metodoPago);
                    var cuentaDr = GetCuenta(codigoDr, conn, tx);
                    AddLine(asiento, cuentaDr.CuentaID, total, 0m,
                        $"Anulación pago compra ({metodoPago})");

                    // Cr 140 Inventario
                    var cuentaInv = GetCuenta("140", conn, tx);
                    AddLine(asiento, cuentaInv.CuentaID, 0m, total,
                        "Anulación ingreso de mercadería");

                    ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
                }
            }
        }

        // ==================================================================
        // INVENTARIO INICIAL (apertura)
        // ==================================================================

        /// <summary>
        ///   Dr 140 Inventario = cantidad × costoUnitario
        ///   Cr 300 Capital    = cantidad × costoUnitario
        /// Si el costo es 0, omite silenciosamente.
        /// </summary>
        public static void RegistrarInventarioInicial(
            int productoID, string nombreProducto,
            decimal cantidad, decimal costoUnitario, int usuarioID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            decimal monto = cantidad * costoUnitario;
            if (monto <= 0m) return;

            var asiento = BuildAsiento("APERTURA", $"PROD-{productoID}", productoID, usuarioID,
                DateTime.Now.Date, DateTime.Now.TimeOfDay,
                $"Stock inicial: {nombreProducto}");

            var cuentaInv = GetCuenta("140", conn, tx);
            AddLine(asiento, cuentaInv.CuentaID, monto, 0m,
                $"Stock inicial {nombreProducto}");

            var cuentaCap = GetCuenta("300", conn, tx);
            AddLine(asiento, cuentaCap.CuentaID, 0m, monto, "Aporte de capital - inventario");

            ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
        }

        // ==================================================================
        // AJUSTES DE INVENTARIO
        // ==================================================================

        /// <summary>
        /// ENTRADA  → Dr 140 Inventario / Cr 300 Capital
        /// SALIDA   → Dr 503 Ajuste Inventario / Cr 140 Inventario
        /// CORRECCION → igual que ENTRADA o SALIDA según si stockNuevo > stockAnterior
        /// Si costoUnitario == 0 → omite silenciosamente.
        /// </summary>
        public static void RegistrarAjusteInventario(
            int ajusteID, int productoID, string tipoAjuste,
            decimal stockAnterior, decimal stockNuevo,
            decimal costoUnitario, string motivo, int usuarioID, DateTime fecha,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            if (costoUnitario <= 0m) return;

            // Determinar dirección y cantidad efectiva
            bool esEntrada;
            decimal cantidadEfectiva;

            if (tipoAjuste == "CORRECCION")
            {
                decimal delta = stockNuevo - stockAnterior;
                if (delta == 0m) return;
                esEntrada = delta > 0m;
                cantidadEfectiva = Math.Abs(delta);
            }
            else
            {
                esEntrada = tipoAjuste == "ENTRADA";
                cantidadEfectiva = Math.Abs(stockNuevo - stockAnterior);
                if (cantidadEfectiva == 0m) return;
            }

            decimal monto = cantidadEfectiva * costoUnitario;
            if (monto <= 0m) return;

            string docRef   = $"AJ-{ajusteID}";
            string glosaDir = esEntrada ? "Entrada" : "Salida";
            var asiento = BuildAsiento("AJUSTE", docRef, ajusteID, usuarioID,
                fecha.Date, fecha.TimeOfDay,
                $"Ajuste inventario ({glosaDir}): {motivo}");

            if (esEntrada)
            {
                // Dr 140 Inventario / Cr 300 Capital
                var cuentaInv = GetCuenta("140", conn, tx);
                AddLine(asiento, cuentaInv.CuentaID, monto, 0m,
                    $"Ajuste entrada inventario");

                var cuentaCap = GetCuenta("300", conn, tx);
                AddLine(asiento, cuentaCap.CuentaID, 0m, monto,
                    "Ajuste inventario - capital");
            }
            else
            {
                // Dr 503 Ajuste Inventario / Cr 140 Inventario
                var cuentaAjuste = GetCuenta("503", conn, tx);
                AddLine(asiento, cuentaAjuste.CuentaID, monto, 0m,
                    $"Ajuste salida/merma: {motivo}");

                var cuentaInv = GetCuenta("140", conn, tx);
                AddLine(asiento, cuentaInv.CuentaID, 0m, monto,
                    "Reducción de inventario por ajuste");
            }

            ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
        }

        // ==================================================================
        // GASTOS OPERATIVOS
        // ==================================================================

        /// <summary>
        /// Asiento al registrar un gasto operativo.
        ///   Dr 600 Gastos Operativos = Monto
        ///   Cr 101 Caja / 102 Bancos / 200 CxP  (según MetodoPago)
        /// EFECTIVO/YAPE → 101;  TARJETA/TRANSFERENCIA → 102;  CREDITO → 200
        /// </summary>
        public static void RegistrarGasto(
            long gastoID, string concepto, DateTime fecha, TimeSpan hora,
            decimal monto, string metodoPago, int usuarioID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            if (monto <= 0m) return;

            var asiento = BuildAsiento("GASTO", $"GASTO-{gastoID}", gastoID, usuarioID,
                fecha, hora, $"Gasto: {concepto}");

            var cuentaGastos = GetCuenta("600", conn, tx);
            AddLine(asiento, cuentaGastos.CuentaID, monto, 0m, $"Gasto operativo: {concepto}");

            string codigoCr = MetodoPagoCompraACuenta(metodoPago); // reutiliza mapping existente
            var cuentaCr = GetCuenta(codigoCr, conn, tx);
            AddLine(asiento, cuentaCr.CuentaID, 0m, monto, $"Pago gasto ({metodoPago})");

            ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
        }

        /// <summary>
        /// Reverso del asiento de gasto al eliminar/anular.
        /// Debe llamarse ANTES de borrar el registro de la tabla Gastos
        /// para poder leer los datos del gasto dentro de la misma transacción.
        ///   Dr 101/102/200  (según MetodoPago original)
        ///   Cr 600 Gastos Operativos
        /// Si el gastoID no existe, retorna silenciosamente.
        /// </summary>
        public static void ReversarGasto(int gastoID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            const string sql = @"
                SELECT Concepto, Fecha, Hora, Monto, MetodoPago, UsuarioID
                FROM   Gastos WHERE GastoID = @ID";

            using (var cmd = new SQLiteCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@ID", gastoID);
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return;

                    string concepto = r.GetString(0);
                    DateTime fecha  = DateTime.Parse(r.GetString(1));
                    TimeSpan hora   = TimeSpan.Parse(r.GetString(2));
                    decimal monto   = r.GetDecimal(3);
                    string metodo   = r.GetString(4);
                    int usuarioID   = r.IsDBNull(5) ? 1 : r.GetInt32(5);

                    if (monto <= 0m) return;

                    var asiento = BuildAsiento("ANULACION", $"GASTO-{gastoID}", gastoID, usuarioID,
                        DateTime.Now.Date, DateTime.Now.TimeOfDay,
                        $"Anulación gasto: {concepto}");

                    // Cr Caja/Bancos/CxP → lado opuesto, ahora es Debe
                    string codigoDr = MetodoPagoCompraACuenta(metodo);
                    var cuentaDr = GetCuenta(codigoDr, conn, tx);
                    AddLine(asiento, cuentaDr.CuentaID, monto, 0m, $"Anulación pago gasto ({metodo})");

                    // Dr 600 → lado opuesto, ahora es Haber
                    var cuentaGastos = GetCuenta("600", conn, tx);
                    AddLine(asiento, cuentaGastos.CuentaID, 0m, monto, $"Anulación gasto: {concepto}");

                    ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
                }
            }
        }

        // ==================================================================
        // HELPERS PRIVADOS
        // ==================================================================

        /// <summary>
        /// Construye la línea(s) de débito de una venta.
        /// Si invertir==true devuelve las mismas líneas pero en el lado Haber
        /// (para anulaciones).
        /// </summary>
        private static void BuildDebitLinesVenta(
            AsientoContable asiento,
            decimal total, string metodoPago,
            decimal montoEfectivo, decimal montoYape,
            decimal montoTarjeta, decimal montoTransferencia,
            bool invertir,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            string mp = metodoPago?.ToUpper() ?? "";

            if (mp == "CREDITO")
            {
                var cxc = GetCuenta("120", conn, tx);
                if (invertir)
                    AddLine(asiento, cxc.CuentaID, 0m, total, "Anulación CxC cliente");
                else
                    AddLine(asiento, cxc.CuentaID, total, 0m, "Venta a crédito");
            }
            else if (mp == "MIXTO")
            {
                decimal cash = montoEfectivo + montoYape;
                decimal bank = montoTarjeta + montoTransferencia;

                if (cash > 0m)
                {
                    var caja = GetCuenta("101", conn, tx);
                    if (invertir)
                        AddLine(asiento, caja.CuentaID, 0m, cash, "Anulación caja (efectivo/Yape)");
                    else
                        AddLine(asiento, caja.CuentaID, cash, 0m, "Cobro efectivo/Yape");
                }
                if (bank > 0m)
                {
                    var bancos = GetCuenta("102", conn, tx);
                    if (invertir)
                        AddLine(asiento, bancos.CuentaID, 0m, bank, "Anulación bancos (tarjeta/transf.)");
                    else
                        AddLine(asiento, bancos.CuentaID, bank, 0m, "Cobro tarjeta/transferencia");
                }
            }
            else
            {
                string codigo = ContabilidadRepository.ObtenerCodigoCuentaEfectivo(metodoPago);
                string desc   = codigo == "102" ? "Bancos" : "Caja";
                var cuenta    = GetCuenta(codigo, conn, tx);
                if (invertir)
                    AddLine(asiento, cuenta.CuentaID, 0m, total, $"Anulación cobro {desc}");
                else
                    AddLine(asiento, cuenta.CuentaID, total, 0m, $"Cobro {desc} ({metodoPago})");
            }
        }

        /// <summary>Mapea MetodoPago de compra al código de cuenta acredora.</summary>
        private static string MetodoPagoCompraACuenta(string metodoPago)
        {
            switch (metodoPago?.ToUpper())
            {
                case "CREDITO": return "200"; // Cuentas por Pagar
                case "TRANSFERENCIA": return "102"; // Bancos
                default: return "101"; // Caja (EFECTIVO)
            }
        }

        private static AsientoContable BuildAsiento(
            string tipo, string documento, long referenciaID,
            int usuarioID, DateTime fecha, TimeSpan hora, string glosa)
        {
            return new AsientoContable
            {
                Fecha         = fecha,
                Hora          = hora,
                TipoOperacion = tipo,
                Documento     = documento,
                ReferenciaID  = (int)referenciaID,
                UsuarioID     = usuarioID,
                Glosa         = glosa,
                Detalles      = new List<AsientoDetalleContable>()
            };
        }

        private static void AddLine(AsientoContable asiento, int cuentaID,
            decimal debe, decimal haber, string descripcion)
        {
            asiento.Detalles.Add(new AsientoDetalleContable
            {
                CuentaID    = cuentaID,
                Debe        = debe,
                Haber       = haber,
                Descripcion = descripcion
            });
        }

        /// <summary>
        /// Fallback de costo cuando el kardex histórico retorna 0.
        /// Orden de prioridad:
        ///   2) Productos.CostoPromPonderado   (campo estático, actualizable por el usuario)
        ///   3) MIN(ProductoPresentaciones.CostoBase / CantidadUnidades)  (último precio de compra conocido)
        ///   4) 0  (sin error; el asiento COGS se omite silenciosamente)
        /// </summary>
        private static decimal ObtenerCostoProdFallback(int productoID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            // PRIORIDAD 2: CostoPromPonderado en tabla Productos
            const string sql2 = "SELECT COALESCE(CostoPromPonderado, 0) FROM Productos WHERE ProductoID = @id";
            using (var cmd = new SQLiteCommand(sql2, conn, tx))
            {
                cmd.Parameters.AddWithValue("@id", productoID);
                var r = cmd.ExecuteScalar();
                decimal v = (r != null && r != DBNull.Value) ? Convert.ToDecimal(r) : 0m;
                if (v > 0m)
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"[COGS Fallback P2] ProductoID={productoID} CostoPromPonderado={v:N4}");
                    return v;
                }
            }

            // PRIORIDAD 3: costo base por unidad desde presentaciones activas
            const string sql3 = @"
                SELECT MIN(CASE WHEN pp.CantidadUnidades > 0
                                THEN pp.CostoBase / pp.CantidadUnidades
                                ELSE 0 END)
                FROM   ProductoPresentaciones pp
                WHERE  pp.ProductoID = @id
                  AND  pp.Activo = 1
                  AND  pp.CostoBase > 0";
            using (var cmd = new SQLiteCommand(sql3, conn, tx))
            {
                cmd.Parameters.AddWithValue("@id", productoID);
                var r = cmd.ExecuteScalar();
                decimal v = (r != null && r != DBNull.Value) ? Convert.ToDecimal(r) : 0m;
                if (v > 0m)
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"[COGS Fallback P3] ProductoID={productoID} CostoBase/Unidades={v:N4}");
                    return v;
                }
            }

            // PRIORIDAD 4: sin costo conocido — el llamador omitirá el asiento COGS
            System.Diagnostics.Debug.WriteLine(
                $"[COGS Fallback P4] ProductoID={productoID} sin costo, asiento COGS omitido");
            return 0m;
        }

        private static CuentaContable GetCuenta(string codigo,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            var cuenta = ContabilidadRepository.ObtenerCuentaPorCodigo(codigo, conn, tx);
            if (cuenta == null)
                throw new Exception(
                    $"Cuenta contable '{codigo}' no encontrada o inactiva. " +
                    "Verifique el plan de cuentas en Configuración.");
            return cuenta;
        }

        // ==================================================================
        // ESTADO DE RESULTADOS (solo lectura desde asientos)
        // ==================================================================

        /// <summary>
        /// Lee saldos de AsientosDetalle para las cuentas 400, 500 y 600
        /// en el rango de fechas indicado y devuelve el Estado de Resultados.
        /// Solo lectura. Abre su propia conexión (no recibe tx).
        /// Si no hay asientos en el período devuelve 0 en todos los campos.
        ///   Ventas       = SUM(Haber - Debe) cuenta 400
        ///   CostoVentas  = SUM(Debe - Haber) cuenta 500
        ///   Gastos       = SUM(Debe - Haber) cuenta 600
        /// </summary>
        // ==================================================================
        // FLUJO DE CAJA (solo lectura desde asientos)
        // ==================================================================

        /// <summary>
        /// Calcula el Flujo de Caja leyendo movimientos de cuentas 101 (Caja)
        /// y 102 (Bancos) desde AsientosDetalle. Una sola pasada SQL.
        ///   Entrada = ad.Debe  cuando cc.Codigo IN ('101','102')
        ///   Salida  = ad.Haber cuando cc.Codigo IN ('101','102')
        /// Asientos que no tocan 101/102 quedan automáticamente excluidos.
        ///
        /// Verificación de consistencia (SQL directo en DB):
        ///   SELECT SUM(ad.Debe - ad.Haber)
        ///   FROM   AsientosDetalle ad
        ///   JOIN   CuentasContables cc ON ad.CuentaID  = cc.CuentaID
        ///   JOIN   Asientos a          ON ad.AsientoID = a.AsientoID
        ///   WHERE  cc.Codigo IN ('101','102')
        ///     AND  a.Fecha >= '@Desde' AND a.Fecha &lt;= '@Hasta';
        ///   -- debe coincidir con DTO.Neto (TotalEntradas - TotalSalidas)
        /// </summary>
        public static FlujoCajaDTO ObtenerFlujoCaja(DateTime desde, DateTime hasta)
        {
            const string sql = @"
                SELECT
                    a.Fecha,
                    cc.Codigo,
                    COALESCE(SUM(ad.Debe),  0) AS Entradas,
                    COALESCE(SUM(ad.Haber), 0) AS Salidas
                FROM   AsientosDetalle ad
                JOIN   CuentasContables cc ON ad.CuentaID  = cc.CuentaID
                JOIN   Asientos a          ON ad.AsientoID = a.AsientoID
                WHERE  cc.Codigo IN ('101', '102')
                  AND  a.Fecha >= @Desde AND a.Fecha <= @Hasta
                GROUP  BY a.Fecha, cc.Codigo
                ORDER  BY a.Fecha, cc.Codigo";

            var dto      = new FlujoCajaDTO();
            var porFecha = new Dictionary<DateTime, FlujoCajaDiaDTO>();

            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd  = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Desde", desde.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Hasta", hasta.ToString("yyyy-MM-dd"));

                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        DateTime fecha    = DateTime.Parse(r.GetString(0));
                        string   codigo   = r.GetString(1);
                        decimal  entradas = r.GetDecimal(2);
                        decimal  salidas  = r.GetDecimal(3);

                        // Acumular por origen
                        if (codigo == "101")
                        {
                            dto.EntradasCaja   += entradas;
                            dto.SalidasCaja    += salidas;
                        }
                        else
                        {
                            dto.EntradasBancos += entradas;
                            dto.SalidasBancos  += salidas;
                        }

                        // Acumular por día (suma 101+102)
                        if (!porFecha.ContainsKey(fecha))
                            porFecha[fecha] = new FlujoCajaDiaDTO { Fecha = fecha };
                        porFecha[fecha].Entradas += entradas;
                        porFecha[fecha].Salidas  += salidas;
                    }
                }
            }

            dto.TotalEntradas = dto.EntradasCaja + dto.EntradasBancos;
            dto.TotalSalidas  = dto.SalidasCaja  + dto.SalidasBancos;

            foreach (var kv in porFecha)
                dto.DetallesPorDia.Add(kv.Value);
            dto.DetallesPorDia.Sort((a, b) => a.Fecha.CompareTo(b.Fecha));

            return dto;
        }

        public static SistemaPOS.Models.EstadoResultadosDTO ObtenerEstadoResultados(
            DateTime desde, DateTime hasta)
        {
            const string sql = @"
                SELECT
                    COALESCE(SUM(CASE WHEN cc.Codigo = '400' THEN ad.Haber - ad.Debe ELSE 0 END), 0),
                    COALESCE(SUM(CASE WHEN cc.Codigo = '500' THEN ad.Debe - ad.Haber ELSE 0 END), 0),
                    COALESCE(SUM(CASE WHEN cc.Codigo = '600' THEN ad.Debe - ad.Haber ELSE 0 END), 0)
                FROM   AsientosDetalle ad
                JOIN   CuentasContables cc ON ad.CuentaID = cc.CuentaID
                JOIN   Asientos a          ON ad.AsientoID = a.AsientoID
                WHERE  a.Fecha >= @Desde AND a.Fecha <= @Hasta";

            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Desde", desde.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Hasta", hasta.ToString("yyyy-MM-dd"));

                using (var r = cmd.ExecuteReader())
                {
                    var dto = new SistemaPOS.Models.EstadoResultadosDTO();
                    if (r.Read())
                    {
                        dto.Ventas      = r.IsDBNull(0) ? 0m : r.GetDecimal(0);
                        dto.CostoVentas = r.IsDBNull(1) ? 0m : r.GetDecimal(1);
                        dto.Gastos      = r.IsDBNull(2) ? 0m : r.GetDecimal(2);
                    }
                    dto.UtilidadBruta     = dto.Ventas - dto.CostoVentas;
                    dto.UtilidadOperativa = dto.UtilidadBruta - dto.Gastos;
                    return dto;
                }
            }
        }

        // ==================================================================
        // BALANCE DE COMPROBACIÓN (solo lectura desde asientos)
        // ==================================================================

        /// <summary>
        /// Devuelve una fila por cuenta con los movimientos Debe/Haber
        /// acumulados en el rango de fechas. Saldo = Debe - Haber.
        /// Ordenado por cc.Codigo. Lista vacía si no hay movimientos.
        ///
        /// Verificación SQL directa equivalente:
        ///   SELECT cc.Codigo, cc.Nombre, cc.Tipo,
        ///          COALESCE(SUM(ad.Debe),0)  AS Debe,
        ///          COALESCE(SUM(ad.Haber),0) AS Haber,
        ///          COALESCE(SUM(ad.Debe),0) - COALESCE(SUM(ad.Haber),0) AS Saldo
        ///   FROM   AsientosDetalle ad
        ///   JOIN   CuentasContables cc ON ad.CuentaID  = cc.CuentaID
        ///   JOIN   Asientos a          ON ad.AsientoID = a.AsientoID
        ///   WHERE  a.Fecha &gt;= '@Desde' AND a.Fecha &lt;= '@Hasta'
        ///   GROUP  BY cc.CuentaID, cc.Codigo, cc.Nombre, cc.Tipo
        ///   ORDER  BY cc.Codigo;
        ///   -- En partida doble perfecta: SUM(Debe) == SUM(Haber)
        /// </summary>
        public static List<BalanceComprobacionItemDTO> ObtenerBalanceComprobacion(
            DateTime desde, DateTime hasta)
        {
            const string sql = @"
                SELECT
                    cc.Codigo,
                    cc.Nombre,
                    cc.Tipo,
                    COALESCE(SUM(ad.Debe),  0) AS Debe,
                    COALESCE(SUM(ad.Haber), 0) AS Haber
                FROM   AsientosDetalle ad
                JOIN   CuentasContables cc ON ad.CuentaID  = cc.CuentaID
                JOIN   Asientos a          ON ad.AsientoID = a.AsientoID
                WHERE  a.Fecha >= @Desde AND a.Fecha <= @Hasta
                GROUP  BY cc.CuentaID, cc.Codigo, cc.Nombre, cc.Tipo
                ORDER  BY cc.Codigo";

            var lista = new List<BalanceComprobacionItemDTO>();

            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd  = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Desde", desde.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Hasta", hasta.ToString("yyyy-MM-dd"));

                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new BalanceComprobacionItemDTO
                        {
                            Codigo = r.GetString(0),
                            Nombre = r.GetString(1),
                            Tipo   = r.GetString(2),
                            Debe   = r.IsDBNull(3) ? 0m : r.GetDecimal(3),
                            Haber  = r.IsDBNull(4) ? 0m : r.GetDecimal(4)
                        });
                    }
                }
            }

            return lista;
        }

        // ==================================================================
        // BALANCE GENERAL (solo lectura desde asientos — acumulado)
        // ==================================================================

        /// <summary>
        /// Calcula el Balance General acumulado hasta la fecha de corte
        /// leyendo saldos de AsientosDetalle. Una sola pasada SQL.
        ///
        /// NOTA fecha: Asientos.Fecha = "yyyy-MM-dd" (sin hora).
        /// El patrón a.Fecha &lt;= @FechaCorte ya incluye todos los
        /// asientos del día de corte. Si en el futuro se almacenara hora,
        /// usar a.Fecha &lt; fechaCorte.AddDays(1).ToString("yyyy-MM-dd").
        ///
        /// Verificación de cuadratura (SQL directo):
        ///   SELECT
        ///     SUM(CASE WHEN cc.Codigo IN ('101','102','120','140') THEN ad.Debe-ad.Haber ELSE 0 END)
        ///    -SUM(CASE WHEN cc.Codigo IN ('200','300','400') THEN ad.Haber-ad.Debe ELSE 0 END)
        ///    +SUM(CASE WHEN cc.Codigo IN ('500','600')       THEN ad.Debe-ad.Haber ELSE 0 END)
        ///   FROM AsientosDetalle ad
        ///   JOIN CuentasContables cc ON ad.CuentaID=cc.CuentaID
        ///   JOIN Asientos a ON ad.AsientoID=a.AsientoID
        ///   WHERE a.Fecha &lt;= '@FechaCorte';
        ///   -- debe retornar 0.00 (o &lt; 0.01 por redondeos)
        /// </summary>
        public static BalanceGeneralDTO ObtenerBalanceGeneral(DateTime fechaCorte)
        {
            const string sql = @"
                SELECT
                    COALESCE(SUM(CASE WHEN cc.Codigo='101' THEN ad.Debe-ad.Haber ELSE 0 END),0),
                    COALESCE(SUM(CASE WHEN cc.Codigo='102' THEN ad.Debe-ad.Haber ELSE 0 END),0),
                    COALESCE(SUM(CASE WHEN cc.Codigo='120' THEN ad.Debe-ad.Haber ELSE 0 END),0),
                    COALESCE(SUM(CASE WHEN cc.Codigo='140' THEN ad.Debe-ad.Haber ELSE 0 END),0),
                    COALESCE(SUM(CASE WHEN cc.Codigo='200' THEN ad.Haber-ad.Debe ELSE 0 END),0),
                    COALESCE(SUM(CASE WHEN cc.Codigo='300' THEN ad.Haber-ad.Debe ELSE 0 END),0),
                    COALESCE(SUM(CASE WHEN cc.Codigo='400' THEN ad.Haber-ad.Debe ELSE 0 END),0),
                    COALESCE(SUM(CASE WHEN cc.Codigo='500' THEN ad.Debe-ad.Haber ELSE 0 END),0),
                    COALESCE(SUM(CASE WHEN cc.Codigo='600' THEN ad.Debe-ad.Haber ELSE 0 END),0)
                FROM   AsientosDetalle ad
                JOIN   CuentasContables cc ON ad.CuentaID  = cc.CuentaID
                JOIN   Asientos a          ON ad.AsientoID = a.AsientoID
                WHERE  a.Fecha <= @FechaCorte
                  AND  cc.Codigo IN ('101','102','120','140','200','300','400','500','600')";

            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd  = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@FechaCorte", fechaCorte.ToString("yyyy-MM-dd"));

                using (var r = cmd.ExecuteReader())
                {
                    var dto = new BalanceGeneralDTO();
                    if (r.Read())
                    {
                        dto.Caja       = r.IsDBNull(0) ? 0m : r.GetDecimal(0);
                        dto.Bancos     = r.IsDBNull(1) ? 0m : r.GetDecimal(1);
                        dto.CxC        = r.IsDBNull(2) ? 0m : r.GetDecimal(2);
                        dto.Inventario = r.IsDBNull(3) ? 0m : r.GetDecimal(3);
                        dto.CxP        = r.IsDBNull(4) ? 0m : r.GetDecimal(4);
                        dto.Capital    = r.IsDBNull(5) ? 0m : r.GetDecimal(5);
                        decimal ventas = r.IsDBNull(6) ? 0m : r.GetDecimal(6);
                        decimal costo  = r.IsDBNull(7) ? 0m : r.GetDecimal(7);
                        decimal gastos = r.IsDBNull(8) ? 0m : r.GetDecimal(8);
                        dto.Utilidad   = ventas - costo - gastos;
                    }
                    return dto;
                }
            }
        }
    }
}
