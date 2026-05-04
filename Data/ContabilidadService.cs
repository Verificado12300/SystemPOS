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
        ///   EFECTIVO                 : Dr 101 Caja   = Total
        ///   YAPE / TARJETA / TRANSF  : Dr 102 Bancos  = Total
        ///   CREDITO                  : Dr 120 CxC     = Total
        ///   MIXTO                    : Dr 101 = Efectivo, Dr 102 = (Yape+Tarjeta+Transf)
        ///                              Cr 400 Ventas  = Total
        /// </summary>
        public static void RegistrarVenta(
            long ventaID, string numeroVenta, DateTime fecha, TimeSpan hora,
            decimal total, string metodoPago,
            decimal montoEfectivo, decimal montoYape,
            decimal montoTarjeta, decimal montoTransferencia,
            decimal igv,
            int usuarioID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            if (total <= 0m) return;

            var asiento = BuildAsiento("VENTA", numeroVenta, ventaID, usuarioID,
                fecha, hora, $"Venta {numeroVenta}", "VENTA");

            // Dr Caja / Bancos / CxC = total cobrado
            BuildDebitLinesVenta(asiento, total, metodoPago,
                montoEfectivo, montoYape, montoTarjeta, montoTransferencia,
                false, conn, tx);

            if (igv > 0m)
            {
                // Cr 400 Ventas = base imponible; Cr 210 IGV por pagar = igv
                decimal base400 = total - igv;
                var c400 = GetCuenta("400", conn, tx);
                var c210 = GetCuenta("210", conn, tx);
                AddLine(asiento, c400.CuentaID, 0m, base400, "Ingresos por ventas (base imponible)");
                AddLine(asiento, c210.CuentaID, 0m, igv,     "IGV por pagar");
            }
            else
            {
                var c400 = GetCuenta("400", conn, tx);
                AddLine(asiento, c400.CuentaID, 0m, total, "Ingresos por ventas");
            }

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
                                  UsuarioID, IGV
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
                    int usuarioID            = r.IsDBNull(9)  ? 1  : r.GetInt32(9);
                    decimal igvOrig          = r.IsDBNull(10) ? 0m : r.GetDecimal(10);

                    if (total <= 0m) return;

                    // Guard: bloquear anulación si la venta original es de período cerrado
                    PeriodosContablesRepository.ValidarFechaNoBloqueada(fecha, conn, tx);

                    var asiento = BuildAsiento("ANULACION", numeroVenta, ventaID, usuarioID,
                        DateTime.Now.Date, DateTime.Now.TimeOfDay,
                        $"Anulación venta {numeroVenta}", "VENTA");

                    // Dr 400 Ventas (base) + Dr 210 IGV (si aplica)
                    if (igvOrig > 0m)
                    {
                        decimal base400 = total - igvOrig;
                        var c400 = GetCuenta("400", conn, tx);
                        var c210 = GetCuenta("210", conn, tx);
                        AddLine(asiento, c400.CuentaID, base400,  0m, "Anulación ingresos (base imponible)");
                        AddLine(asiento, c210.CuentaID, igvOrig,  0m, "Anulación IGV por pagar");
                    }
                    else
                    {
                        var c400 = GetCuenta("400", conn, tx);
                        AddLine(asiento, c400.CuentaID, total, 0m, "Anulación ingresos por ventas");
                    }

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
                fecha, hora, $"Costo de venta {numeroVenta}", "VENTA");

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

                    // Guard: bloquear reversión COGS si la venta original es de período cerrado
                    PeriodosContablesRepository.ValidarFechaNoBloqueada(fecha, conn, tx);

                    var asiento = BuildAsiento("ANULACION", numVenta, ventaID, usuarioID,
                        DateTime.Now.Date, DateTime.Now.TimeOfDay,
                        $"Reversión costo venta {numVenta}", "VENTA");

                    var cuentaInv  = GetCuenta("140", conn, tx);
                    var cuentaCOGS = GetCuenta("500", conn, tx);
                    AddLine(asiento, cuentaInv.CuentaID,  monto, 0m, "Devolución de inventario");
                    AddLine(asiento, cuentaCOGS.CuentaID, 0m, monto, "Reversión costo de ventas");

                    ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
                }
            }
        }

        /// <summary>
        /// Asiento ÚNICO que combina ingreso + costo de ventas en una sola partida.
        ///   Debe:
        ///     101/102/120 (según forma de pago)  = Total cobrado
        ///     500 Costo de Ventas                = Costo total consolidado (si > 0)
        ///   Haber:
        ///     400 Ventas                         = Base imponible (o Total si sin IGV)
        ///     210 Tributos por pagar             = IGV (si igv > 0)
        ///     140 Inventario                     = Costo total consolidado (si > 0)
        /// Cuadre: Debe = Total + COGS = Haber.
        /// Si COGS = 0 (ningún producto tiene costo calculable) se omiten líneas 500 y 140.
        /// </summary>
        public static void RegistrarVentaConCosto(
            long ventaID, string numeroVenta, DateTime fecha, TimeSpan hora,
            decimal total, string metodoPago,
            decimal montoEfectivo, decimal montoYape,
            decimal montoTarjeta, decimal montoTransferencia,
            decimal igv,
            System.Collections.Generic.List<(int ProductoID, decimal CantidadBase)> detalles,
            int usuarioID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            if (total <= 0m) return;

            // Calcular costo total consolidado (igual que RegistrarCostoVenta)
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

                if (costoUnit <= 0m) continue;
                totalCOGS += costoUnit * d.CantidadBase;
            }
            totalCOGS = Math.Round(totalCOGS, 2, MidpointRounding.AwayFromZero);

            var asiento = BuildAsiento("VENTA", numeroVenta, ventaID, usuarioID,
                fecha, hora, $"Venta {numeroVenta}", "VENTA");

            // Dr Caja / Bancos / CxC = total cobrado
            BuildDebitLinesVenta(asiento, total, metodoPago,
                montoEfectivo, montoYape, montoTarjeta, montoTransferencia,
                false, conn, tx);

            // Dr 500 Costo de ventas = costo total (si hay costo calculable)
            if (totalCOGS > 0m)
            {
                var cuentaCOGS = GetCuenta("500", conn, tx);
                AddLine(asiento, cuentaCOGS.CuentaID, totalCOGS, 0m, "Costo de ventas");
            }

            // Cr 400 Ventas + Cr 210 IGV (si aplica) = total
            if (igv > 0m)
            {
                decimal base400 = total - igv;
                var c400 = GetCuenta("400", conn, tx);
                var c210 = GetCuenta("210", conn, tx);
                AddLine(asiento, c400.CuentaID, 0m, base400, "Ingresos por ventas (base imponible)");
                AddLine(asiento, c210.CuentaID, 0m, igv,     "IGV por pagar");
            }
            else
            {
                var c400 = GetCuenta("400", conn, tx);
                AddLine(asiento, c400.CuentaID, 0m, total, "Ingresos por ventas");
            }

            // Cr 140 Inventario = costo total (si hay costo calculable)
            if (totalCOGS > 0m)
            {
                var cuentaInv = GetCuenta("140", conn, tx);
                AddLine(asiento, cuentaInv.CuentaID, 0m, totalCOGS, "Salida de inventario por venta");
            }

            ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
        }

        /// <summary>
        /// Reverso del asiento al anular una venta.
        /// Detecta si el asiento original fue COMBINADO (nuevo) o SPLIT (histórico):
        ///   - Combinado (1 asiento con líneas 500+140): genera 1 asiento de anulación completo.
        ///   - Split (2 asientos separados): llama a ReversarVenta + ReversarCostoVenta.
        /// </summary>
        public static void ReversarVentaConCosto(int ventaID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            // Detectar cuántos asientos VENTA existen para esta venta
            const string sqlCount = @"
                SELECT COUNT(DISTINCT a.AsientoID)
                FROM   Asientos a
                WHERE  a.ReferenciaID = @VentaID
                  AND  a.TipoOperacion = 'VENTA'";

            int countAsientos;
            using (var cmd = new SQLiteCommand(sqlCount, conn, tx))
            {
                cmd.Parameters.AddWithValue("@VentaID", ventaID);
                var r = cmd.ExecuteScalar();
                countAsientos = (r == null || r == DBNull.Value) ? 0 : Convert.ToInt32(r);
            }

            if (countAsientos == 0) return; // Sin asiento contable: nada que revertir

            if (countAsientos >= 2)
            {
                // Asientos históricos split — usar métodos originales
                ReversarVenta(ventaID, conn, tx);
                ReversarCostoVenta(ventaID, conn, tx);
                return;
            }

            // === Asiento combinado nuevo — revertir en un solo asiento ===

            string   numeroVenta = null;
            DateTime fecha       = DateTime.Now.Date;
            TimeSpan hora        = DateTime.Now.TimeOfDay;
            decimal  total       = 0m, igvOrig = 0m;
            string   metodoPago  = null;
            decimal  montoEf = 0m, montoYape = 0m, montoTarjeta = 0m, montoTransf = 0m;
            int      usuarioID   = 1;

            const string sqlVenta = @"
                SELECT NumeroVenta, Fecha, Hora, Total, MetodoPago,
                       MontoEfectivo, MontoYape, MontoTarjeta, MontoTransferencia,
                       UsuarioID, IGV
                FROM   Ventas WHERE VentaID = @ID";
            using (var cmd = new SQLiteCommand(sqlVenta, conn, tx))
            {
                cmd.Parameters.AddWithValue("@ID", ventaID);
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return;
                    numeroVenta  = r.GetString(0);
                    fecha        = DateTime.Parse(r.GetString(1));
                    hora         = TimeSpan.Parse(r.GetString(2));
                    total        = r.GetDecimal(3);
                    metodoPago   = r.GetString(4);
                    montoEf      = r.IsDBNull(5)  ? 0m : r.GetDecimal(5);
                    montoYape    = r.IsDBNull(6)  ? 0m : r.GetDecimal(6);
                    montoTarjeta = r.IsDBNull(7)  ? 0m : r.GetDecimal(7);
                    montoTransf  = r.IsDBNull(8)  ? 0m : r.GetDecimal(8);
                    usuarioID    = r.IsDBNull(9)  ? 1  : r.GetInt32(9);
                    igvOrig      = r.IsDBNull(10) ? 0m : r.GetDecimal(10);
                }
            }

            if (total <= 0m) return;

            // Guard: bloquear anulación si la venta original es de período cerrado
            PeriodosContablesRepository.ValidarFechaNoBloqueada(fecha, conn, tx);

            // Leer COGS del asiento original (línea 500)
            const string sqlCOGS = @"
                SELECT ad.Debe
                FROM   Asientos a
                JOIN   AsientosDetalle ad ON a.AsientoID = ad.AsientoID
                JOIN   CuentasContables cc ON ad.CuentaID = cc.CuentaID
                WHERE  a.ReferenciaID  = @VentaID
                  AND  a.TipoOperacion = 'VENTA'
                  AND  cc.Codigo       = '500'
                LIMIT  1";
            decimal totalCOGS = 0m;
            using (var cmd = new SQLiteCommand(sqlCOGS, conn, tx))
            {
                cmd.Parameters.AddWithValue("@VentaID", ventaID);
                var r = cmd.ExecuteScalar();
                if (r != null && r != DBNull.Value)
                    totalCOGS = Convert.ToDecimal(r);
            }

            var asiento = BuildAsiento("ANULACION", numeroVenta, ventaID, usuarioID,
                DateTime.Now.Date, DateTime.Now.TimeOfDay,
                $"Anulación venta {numeroVenta}", "VENTA");

            // Dr 400 Ventas + Dr 210 IGV (si aplica)
            if (igvOrig > 0m)
            {
                decimal base400 = total - igvOrig;
                var c400 = GetCuenta("400", conn, tx);
                var c210 = GetCuenta("210", conn, tx);
                AddLine(asiento, c400.CuentaID, base400, 0m, "Anulación ingresos (base imponible)");
                AddLine(asiento, c210.CuentaID, igvOrig, 0m, "Anulación IGV por pagar");
            }
            else
            {
                var c400 = GetCuenta("400", conn, tx);
                AddLine(asiento, c400.CuentaID, total, 0m, "Anulación ingresos por ventas");
            }

            // Dr 140 Inventario = costo (reversa de la salida de inventario)
            if (totalCOGS > 0m)
            {
                var cuentaInv = GetCuenta("140", conn, tx);
                AddLine(asiento, cuentaInv.CuentaID, totalCOGS, 0m, "Devolución de inventario");
            }

            // Cr Caja/Bancos/CxC = total (reversa del ingreso)
            BuildDebitLinesVenta(asiento, total, metodoPago,
                montoEf, montoYape, montoTarjeta, montoTransf,
                true, conn, tx);

            // Cr 500 Costo de ventas = costo (reversa del costo)
            if (totalCOGS > 0m)
            {
                var cuentaCOGS = GetCuenta("500", conn, tx);
                AddLine(asiento, cuentaCOGS.CuentaID, 0m, totalCOGS, "Reversión costo de ventas");
            }

            ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
        }

        // ==================================================================
        // COMPRAS
        // ==================================================================

        /// <summary>
        ///   Dr 140 Inventario        = base (total − igv)
        ///   Dr 4012 IGV Cred.Fiscal  = igv  (solo si igv > 0)
        ///   Cr 101 Caja / 102 Bancos / 200 CxP  = total (según MetodoPago)
        /// </summary>
        public static void RegistrarCompra(
            long compraID, string numeroCompra, DateTime fecha, TimeSpan hora,
            decimal total, decimal igv, string metodoPago, int usuarioID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            if (total <= 0m) return;
            decimal baseImp = total - igv;

            var asiento = BuildAsiento("COMPRA", numeroCompra, compraID, usuarioID,
                fecha, hora, $"Compra {numeroCompra}", "COMPRA");

            // Dr 140 Inventario = base imponible (sin IGV)
            var cuentaInv = GetCuenta("140", conn, tx);
            AddLine(asiento, cuentaInv.CuentaID, baseImp, 0m, "Ingreso de mercadería");

            // Dr 4012 IGV Crédito Fiscal = igv (solo si aplica)
            if (igv > 0m)
            {
                var c4012 = GetCuenta("4012", conn, tx);
                AddLine(asiento, c4012.CuentaID, igv, 0m, "IGV Crédito Fiscal");
            }

            // Cr Caja/Bancos/CxP = total
            string codigoCr = MetodoPagoCompraACuenta(metodoPago);
            var cuentaCr = GetCuenta(codigoCr, conn, tx);
            AddLine(asiento, cuentaCr.CuentaID, 0m, total, $"Pago compra ({metodoPago})");

            ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
        }

        /// <summary>
        /// Reverso del asiento de compra al anular.
        /// </summary>
        public static void ReversarCompra(int compraID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            string sql = @"SELECT NumeroCompra, Fecha, Hora, Total, MetodoPago, UsuarioID, IGV
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
                    int usuarioID       = r.IsDBNull(5) ? 1  : r.GetInt32(5);
                    decimal igvOrig     = r.IsDBNull(6) ? 0m : r.GetDecimal(6);
                    decimal baseOrig    = total - igvOrig;

                    if (total <= 0m) return;

                    // Guard: bloquear anulación si la compra original es de período cerrado
                    PeriodosContablesRepository.ValidarFechaNoBloqueada(fecha, conn, tx);

                    var asiento = BuildAsiento("ANULACION", numeroCompra, compraID, usuarioID,
                        DateTime.Now.Date, DateTime.Now.TimeOfDay,
                        $"Anulación compra {numeroCompra}", "COMPRA");

                    // Dr Caja/Bancos/CxP = total (reverso del crédito original)
                    string codigoDr = MetodoPagoCompraACuenta(metodoPago);
                    var cuentaDr = GetCuenta(codigoDr, conn, tx);
                    AddLine(asiento, cuentaDr.CuentaID, total, 0m,
                        $"Anulación pago compra ({metodoPago})");

                    // Cr 140 Inventario = base imponible
                    var cuentaInv = GetCuenta("140", conn, tx);
                    AddLine(asiento, cuentaInv.CuentaID, 0m, baseOrig,
                        "Anulación ingreso de mercadería");

                    // Cr 4012 IGV Crédito Fiscal = igv (si aplica)
                    if (igvOrig > 0m)
                    {
                        var c4012 = GetCuenta("4012", conn, tx);
                        AddLine(asiento, c4012.CuentaID, 0m, igvOrig,
                            "Anulación IGV Crédito Fiscal");
                    }

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
                $"Stock inicial: {nombreProducto}", "INVENTARIO");

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
                $"Ajuste inventario ({glosaDir}): {motivo}", "INVENTARIO");

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
        /// EFECTIVO → 101;  YAPE/TARJETA/TRANSFERENCIA → 102;  CREDITO → 200
        /// </summary>
        public static void RegistrarGasto(
            long gastoID, string concepto, DateTime fecha, TimeSpan hora,
            decimal total, decimal igv, string metodoPago, int usuarioID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            if (total <= 0m) return;
            decimal baseImp = total - igv;

            var asiento = BuildAsiento("GASTO", $"GASTO-{gastoID}", gastoID, usuarioID,
                fecha, hora, $"Gasto: {concepto}", "GASTO");

            // Dr 600 Gastos Operativos = base imponible (sin IGV)
            var cuentaGastos = GetCuenta("600", conn, tx);
            AddLine(asiento, cuentaGastos.CuentaID, baseImp, 0m, $"Gasto operativo: {concepto}");

            // Dr 4012 IGV Crédito Fiscal = igv (solo si aplica)
            if (igv > 0m)
            {
                var c4012 = GetCuenta("4012", conn, tx);
                AddLine(asiento, c4012.CuentaID, igv, 0m, "IGV Crédito Fiscal gasto");
            }

            // Cr 101/102/200 = total
            string codigoCr = MetodoPagoCompraACuenta(metodoPago);
            var cuentaCr = GetCuenta(codigoCr, conn, tx);
            AddLine(asiento, cuentaCr.CuentaID, 0m, total, $"Pago gasto ({metodoPago})");

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
                SELECT Concepto, Fecha, Hora, Monto, MetodoPago, UsuarioID,
                       COALESCE(BaseImponible, Monto) as BaseImponible
                FROM   Gastos WHERE GastoID = @ID";

            using (var cmd = new SQLiteCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@ID", gastoID);
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return;

                    string concepto  = r.GetString(0);
                    DateTime fecha   = DateTime.Parse(r.GetString(1));
                    TimeSpan hora    = TimeSpan.Parse(r.GetString(2));
                    decimal monto    = r.GetDecimal(3);
                    string metodo    = r.GetString(4);
                    int usuarioID    = r.IsDBNull(5) ? 1 : r.GetInt32(5);
                    decimal baseOrig = r.GetDecimal(6);
                    decimal igvOrig  = monto - baseOrig;

                    if (monto <= 0m) return;

                    // Guard: bloquear anulación si el gasto original es de período cerrado
                    PeriodosContablesRepository.ValidarFechaNoBloqueada(fecha, conn, tx);

                    var asiento = BuildAsiento("ANULACION", $"GASTO-{gastoID}", gastoID, usuarioID,
                        DateTime.Now.Date, DateTime.Now.TimeOfDay,
                        $"Anulación gasto: {concepto}", "GASTO");

                    // Dr 101/102/200 = total (reversa del Cr original)
                    string codigoDr = MetodoPagoCompraACuenta(metodo);
                    var cuentaDr = GetCuenta(codigoDr, conn, tx);
                    AddLine(asiento, cuentaDr.CuentaID, monto, 0m, $"Anulación pago gasto ({metodo})");

                    // Cr 600 = base imponible (reversa del Dr 600 original)
                    var cuentaGastos = GetCuenta("600", conn, tx);
                    AddLine(asiento, cuentaGastos.CuentaID, 0m, baseOrig, $"Anulación gasto: {concepto}");

                    // Cr 4012 = igv (reversa del Dr 4012 original, si aplica)
                    if (igvOrig > 0m)
                    {
                        var c4012 = GetCuenta("4012", conn, tx);
                        AddLine(asiento, c4012.CuentaID, 0m, igvOrig, "Anulación IGV Crédito Fiscal gasto");
                    }

                    ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
                }
            }
        }

        // ==================================================================
        // CIERRE MENSUAL
        // ==================================================================

        /// <summary>
        /// Genera el asiento de cierre mensual (TipoOperacion='CIERRE_MES').
        ///
        /// Regla contable:
        ///   • Cuentas INGRESO (saldo natural Cr = Haber-Debe):
        ///       → Dr por su saldo neto para dejarlas en 0.
        ///   • Cuentas GASTO (saldo natural Dr = Debe-Haber):
        ///       → Cr por su saldo neto para dejarlas en 0.
        ///   • Contrapartida → 390 Utilidad del Ejercicio:
        ///       Cr si utilidad (ingresos > gastos)
        ///       Dr si pérdida  (gastos > ingresos)
        ///
        /// Seguridad:
        ///   - Lanza InvalidOperationException si ya existe CIERRE_MES con mismo Documento.
        ///   - El guard de período (en CrearAsientoCompleto) bloquea si el período está cerrado
        ///     (Fecha=FechaFin del mes). Generar ANTES de cerrar.
        ///   - ModuloOrigen='CIERRE', OrigenId=PeriodoId (si existe registro).
        ///   - Si no hay movimientos de resultado: retorna silenciosamente.
        /// </summary>
        public static void GenerarAsientoCierreMensual(
            int year, int month, int usuarioID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            int      diasMes       = DateTime.DaysInMonth(year, month);
            DateTime fechaAsiento  = new DateTime(year, month, diasMes);
            string   fechaIniStr   = new DateTime(year, month, 1).ToString("yyyy-MM-dd");
            string   fechaFinStr   = fechaAsiento.ToString("yyyy-MM-dd");
            string   documento     = $"CIERRE {year:D4}-{month:D2}";

            // --- Guard duplicado ---
            const string sqlDup =
                "SELECT COUNT(*) FROM Asientos " +
                "WHERE TipoOperacion = 'CIERRE_MES' AND Documento = @Doc";
            using (var cmd = new SQLiteCommand(sqlDup, conn, tx))
            {
                cmd.Parameters.AddWithValue("@Doc", documento);
                if ((long)cmd.ExecuteScalar() > 0)
                    throw new InvalidOperationException(
                        $"Ya existe un asiento de cierre para {documento}. " +
                        "Solo se permite uno por período.");
            }

            // --- Garantizar que exista registro de período (crea ABIERTO si no existe) ---
            // OrigenId nunca queda NULL → trazabilidad garantizada.
            using (var cmdChk = new SQLiteCommand(
                "SELECT COUNT(*) FROM PeriodosContables WHERE FechaInicio=@FI AND FechaFin=@FF",
                conn, tx))
            {
                cmdChk.Parameters.AddWithValue("@FI", fechaIniStr);
                cmdChk.Parameters.AddWithValue("@FF", fechaFinStr);
                if ((long)cmdChk.ExecuteScalar() == 0)
                {
                    using (var ins = new SQLiteCommand(
                        "INSERT INTO PeriodosContables (FechaInicio, FechaFin, Cerrado) VALUES (@FI, @FF, 0)",
                        conn, tx))
                    {
                        ins.Parameters.AddWithValue("@FI", fechaIniStr);
                        ins.Parameters.AddWithValue("@FF", fechaFinStr);
                        ins.ExecuteNonQuery();
                    }
                }
            }
            int periodoId;
            using (var cmdPer = new SQLiteCommand(
                "SELECT PeriodoId FROM PeriodosContables WHERE FechaInicio=@FI AND FechaFin=@FF LIMIT 1",
                conn, tx))
            {
                cmdPer.Parameters.AddWithValue("@FI", fechaIniStr);
                cmdPer.Parameters.AddWithValue("@FF", fechaFinStr);
                periodoId = Convert.ToInt32(cmdPer.ExecuteScalar());
            }

            // --- Saldos por cuenta de resultado (excluye CIERRE_MES previos) ---
            // Misma convención que Estado de Resultados:
            //   INGRESO: saldo neto = Haber - Debe
            //   GASTO:   saldo neto = Debe  - Haber
            const string sqlSaldos = @"
                SELECT cc.CuentaID, cc.Nombre, cc.Tipo,
                       COALESCE(SUM(ad.Debe),  0) AS TotalDebe,
                       COALESCE(SUM(ad.Haber), 0) AS TotalHaber
                FROM   CuentasContables cc
                JOIN   AsientosDetalle ad ON ad.CuentaID  = cc.CuentaID
                JOIN   Asientos a         ON a.AsientoID  = ad.AsientoID
                WHERE  cc.Tipo IN ('INGRESO', 'GASTO')
                  AND  a.Fecha  >= @FI AND a.Fecha <= @FF
                  AND  a.TipoOperacion != 'CIERRE_MES'
                GROUP  BY cc.CuentaID, cc.Nombre, cc.Tipo
                HAVING SUM(ad.Debe) != 0 OR SUM(ad.Haber) != 0";

            var filas = new List<(int CuentaID, string Nombre, string Tipo, decimal Debe, decimal Haber)>();
            using (var cmd = new SQLiteCommand(sqlSaldos, conn, tx))
            {
                cmd.Parameters.AddWithValue("@FI", fechaIniStr);
                cmd.Parameters.AddWithValue("@FF", fechaFinStr);
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        filas.Add((
                            r.GetInt32(0),
                            r.GetString(1),
                            r.GetString(2),
                            r.GetDecimal(3),
                            r.GetDecimal(4)));
            }

            if (filas.Count == 0) return;   // Sin movimientos de resultado — nada que cerrar

            // --- Calcular neto del período ---
            decimal sumaIngresos = 0m;   // Haber - Debe (saldo crédito)
            decimal sumaGastos   = 0m;   // Debe  - Haber (saldo débito)
            foreach (var f in filas)
            {
                if      (f.Tipo == "INGRESO") sumaIngresos += f.Haber - f.Debe;
                else if (f.Tipo == "GASTO")   sumaGastos   += f.Debe  - f.Haber;
            }

            if (sumaIngresos == 0m && sumaGastos == 0m) return;   // Saldos netos = 0

            decimal neto = sumaIngresos - sumaGastos;   // >0 utilidad; <0 pérdida

            // --- Construir asiento ---
            var asiento = new AsientoContable
            {
                Fecha         = fechaAsiento,
                Hora          = new TimeSpan(23, 59, 59),
                TipoOperacion = "CIERRE_MES",
                Documento     = documento,
                ReferenciaID  = null,
                UsuarioID     = usuarioID,
                Glosa         = $"Cierre mensual {documento}",
                ModuloOrigen  = "CIERRE",
                OrigenId      = periodoId,
                Detalles      = new List<AsientoDetalleContable>()
            };

            // Cuentas INGRESO → Dr para cerrarlas
            foreach (var f in filas)
            {
                if (f.Tipo != "INGRESO") continue;
                decimal saldo = f.Haber - f.Debe;
                if (saldo == 0m) continue;
                AddLine(asiento, f.CuentaID,
                    saldo > 0 ?  saldo : 0m,    // Dr (saldo crédito normal → cerrar con Dr)
                    saldo < 0 ? -saldo : 0m,    // Cr (saldo débito atípico → cerrar con Cr)
                    $"Cierre {f.Nombre}");
            }

            // Cuentas GASTO → Cr para cerrarlas
            foreach (var f in filas)
            {
                if (f.Tipo != "GASTO") continue;
                decimal saldo = f.Debe - f.Haber;
                if (saldo == 0m) continue;
                AddLine(asiento, f.CuentaID,
                    saldo < 0 ? -saldo : 0m,    // Dr (saldo crédito atípico → cerrar con Dr)
                    saldo > 0 ?  saldo : 0m,    // Cr (saldo débito normal → cerrar con Cr)
                    $"Cierre {f.Nombre}");
            }

            // Contrapartida → 390 Utilidad del Ejercicio
            if (neto != 0m)
            {
                var cuentaUtil = GetCuenta("390", conn, tx);
                AddLine(asiento, cuentaUtil.CuentaID,
                    neto < 0 ? -neto : 0m,    // Dr 390 si pérdida
                    neto > 0 ?  neto : 0m,    // Cr 390 si utilidad
                    neto > 0
                        ? $"Utilidad período {documento}"
                        : $"Pérdida período {documento}");
            }
            // Si neto == 0: sumaIngresos == sumaGastos → las líneas ya cuadran sin 390

            ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
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
                decimal cash = montoEfectivo;
                decimal bank = montoYape + montoTarjeta + montoTransferencia;

                if (cash > 0m)
                {
                    var caja = GetCuenta("101", conn, tx);
                    if (invertir)
                        AddLine(asiento, caja.CuentaID, 0m, cash, "Anulación caja (efectivo)");
                    else
                        AddLine(asiento, caja.CuentaID, cash, 0m, "Cobro efectivo");
                }
                if (bank > 0m)
                {
                    var bancos = GetCuenta("102", conn, tx);
                    if (invertir)
                        AddLine(asiento, bancos.CuentaID, 0m, bank, "Anulación bancos (Yape/tarjeta/transf.)");
                    else
                        AddLine(asiento, bancos.CuentaID, bank, 0m, "Cobro Yape/tarjeta/transferencia");
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
                case "CREDITO":      return "200"; // Cuentas por Pagar
                case "TRANSFERENCIA":
                case "TARJETA":
                case "YAPE":         return "102"; // Bancos / medios digitales
                default:             return "101"; // Caja (solo EFECTIVO)
            }
        }

        private static AsientoContable BuildAsiento(
            string tipo, string documento, long referenciaID,
            int usuarioID, DateTime fecha, TimeSpan hora, string glosa,
            string moduloOrigen = "SISTEMA")
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
                Detalles      = new List<AsientoDetalleContable>(),
                ModuloOrigen = moduloOrigen,
                OrigenId     = (int)referenciaID
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
                    COALESCE(SUM(CASE WHEN cc.Codigo='101'  THEN ad.Debe-ad.Haber ELSE 0 END),0),  -- 0 Caja
                    COALESCE(SUM(CASE WHEN cc.Codigo='102'  THEN ad.Debe-ad.Haber ELSE 0 END),0),  -- 1 Bancos
                    COALESCE(SUM(CASE WHEN cc.Codigo='120'  THEN ad.Debe-ad.Haber ELSE 0 END),0),  -- 2 CxC
                    COALESCE(SUM(CASE WHEN cc.Codigo='140'  THEN ad.Debe-ad.Haber ELSE 0 END),0),  -- 3 Inventario
                    COALESCE(SUM(CASE WHEN cc.Codigo='4012' THEN ad.Debe-ad.Haber ELSE 0 END),0),  -- 4 IGV Crédito Fiscal
                    COALESCE(SUM(CASE WHEN cc.Codigo='200'  THEN ad.Haber-ad.Debe ELSE 0 END),0),  -- 5 CxP
                    COALESCE(SUM(CASE WHEN cc.Codigo='210'  THEN ad.Haber-ad.Debe ELSE 0 END),0),  -- 6 Tributos
                    COALESCE(SUM(CASE WHEN cc.Codigo='300'  THEN ad.Haber-ad.Debe ELSE 0 END),0),  -- 7 Capital
                    COALESCE(SUM(CASE WHEN cc.Codigo='400'  THEN ad.Haber-ad.Debe ELSE 0 END),0),  -- 8 Ventas
                    COALESCE(SUM(CASE WHEN cc.Codigo='500'  THEN ad.Debe-ad.Haber ELSE 0 END),0),  -- 9 COGS
                    COALESCE(SUM(CASE WHEN cc.Codigo='600'  THEN ad.Debe-ad.Haber ELSE 0 END),0)   -- 10 Gastos
                FROM   AsientosDetalle ad
                JOIN   CuentasContables cc ON ad.CuentaID  = cc.CuentaID
                JOIN   Asientos a          ON ad.AsientoID = a.AsientoID
                WHERE  a.Fecha <= @FechaCorte
                  AND  cc.Codigo IN ('101','102','120','140','4012','200','210','300','400','500','600')";

            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd  = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@FechaCorte", fechaCorte.ToString("yyyy-MM-dd"));

                using (var r = cmd.ExecuteReader())
                {
                    var dto = new BalanceGeneralDTO();
                    if (r.Read())
                    {
                        dto.Caja              = r.IsDBNull(0)  ? 0m : r.GetDecimal(0);
                        dto.Bancos            = r.IsDBNull(1)  ? 0m : r.GetDecimal(1);
                        dto.CxC               = r.IsDBNull(2)  ? 0m : r.GetDecimal(2);
                        dto.Inventario        = r.IsDBNull(3)  ? 0m : r.GetDecimal(3);
                        dto.IGVCreditoFiscal  = r.IsDBNull(4)  ? 0m : r.GetDecimal(4);
                        dto.CxP               = r.IsDBNull(5)  ? 0m : r.GetDecimal(5);
                        dto.Tributos          = r.IsDBNull(6)  ? 0m : r.GetDecimal(6);
                        dto.Capital           = r.IsDBNull(7)  ? 0m : r.GetDecimal(7);
                        decimal ventas        = r.IsDBNull(8)  ? 0m : r.GetDecimal(8);
                        decimal costo         = r.IsDBNull(9)  ? 0m : r.GetDecimal(9);
                        decimal gastos        = r.IsDBNull(10) ? 0m : r.GetDecimal(10);
                        dto.Utilidad          = ventas - costo - gastos;
                    }
                    return dto;
                }
            }
        }

        // ==================================================================
        // CAPITAL INICIAL
        // ==================================================================

        /// <summary>
        /// Genera asiento Dr 101 Caja / Cr 300 Capital para el monto inicial
        /// de apertura de caja marcado como "capital inicial".
        /// Bloquea duplicados por OrigenId y respeta el guardrail de período.
        /// </summary>
        public static void RegistrarCapitalInicial(
            DateTime fecha, TimeSpan hora, decimal monto, int usuarioID,
            int origenId, SQLiteConnection conn, SQLiteTransaction tx)
        {
            if (monto <= 0) return;

            // Guard duplicado
            using (var cmd = new SQLiteCommand(
                "SELECT COUNT(*) FROM Asientos WHERE TipoOperacion='CAPITAL_INICIAL' AND OrigenId=@OId",
                conn, tx))
            {
                cmd.Parameters.AddWithValue("@OId", origenId);
                if ((long)cmd.ExecuteScalar() > 0)
                    throw new InvalidOperationException(
                        $"Ya existe un asiento de capital inicial para la caja #{origenId}. " +
                        "No se permite duplicar.");
            }

            var c101 = GetCuenta("101", conn, tx);
            var c300 = GetCuenta("300", conn, tx);

            var asiento = new AsientoContable
            {
                Fecha         = fecha,
                Hora          = hora,
                TipoOperacion = "CAPITAL_INICIAL",
                Documento     = $"CAPITAL-{origenId}",
                ReferenciaID  = null,
                UsuarioID     = usuarioID,
                Glosa         = $"Capital inicial caja #{origenId}",
                ModuloOrigen  = "CAPITAL",
                OrigenId      = origenId,
                Detalles      = new List<AsientoDetalleContable>
                {
                    new AsientoDetalleContable { CuentaID = c101.CuentaID, Debe = monto, Haber = 0m,
                        Descripcion = "Capital inicial — Caja" },
                    new AsientoDetalleContable { CuentaID = c300.CuentaID, Debe = 0m, Haber = monto,
                        Descripcion = "Capital inicial — Capital" },
                }
            };

            ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
        }

        // ==================================================================
        // CUENTAS POR PAGAR — PAGOS
        // ==================================================================

        /// <summary>
        /// Asiento cuando se paga una Cuenta por Pagar (compra o gasto al crédito).
        ///   Dr 200 Cuentas por Pagar = monto
        ///   Cr 101 Caja    = monto  (EFECTIVO/YAPE)
        ///   Cr 102 Bancos  = monto  (TARJETA/TRANSFERENCIA)
        /// </summary>
        public static void PagarCuentaPorPagar(
            long pagoID, long cxpId, string referencia,
            DateTime fecha, TimeSpan hora,
            decimal monto, string metodoPago, int usuarioID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            if (monto <= 0m) return;

            var asiento = BuildAsiento("PAGO_CXP", $"PAGO-CXP-{cxpId}", pagoID, usuarioID,
                fecha, hora, $"Pago CxP #{cxpId}: {referencia}", "CXP");

            // Dr 200 Cuentas por Pagar
            var c200 = GetCuenta("200", conn, tx);
            AddLine(asiento, c200.CuentaID, monto, 0m, "Cancelación deuda proveedor");

            // Cr 101 Caja o 102 Bancos según método
            string codigoCr = (metodoPago?.ToUpper() == "TRANSFERENCIA" ||
                               metodoPago?.ToUpper() == "TARJETA"       ||
                               metodoPago?.ToUpper() == "YAPE") ? "102" : "101";
            var cuentaCr = GetCuenta(codigoCr, conn, tx);
            AddLine(asiento, cuentaCr.CuentaID, 0m, monto,
                $"Pago a proveedor ({metodoPago})");

            ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
        }

        /// <summary>
        /// Asiento inverso cuando se anula un pago de CxP.
        ///   Dr 101 Caja   = monto  (EFECTIVO/YAPE)
        ///   Dr 102 Bancos = monto  (TARJETA/TRANSFERENCIA)
        ///   Cr 200 Cuentas por Pagar = monto
        /// </summary>
        public static void ReversarPagoCxP(
            long pagoID, long cxpId, string referencia,
            DateTime fecha, TimeSpan hora,
            decimal monto, string metodoPago, int usuarioID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            if (monto <= 0m) return;

            PeriodosContablesRepository.ValidarFechaNoBloqueada(fecha, conn, tx);

            var asiento = BuildAsiento(
                "REVERSAR_PAGO_CXP",
                $"ANUL-PAGO-{pagoID}",
                pagoID,
                usuarioID,
                fecha, hora,
                $"Anulación pago CxP #{cxpId}: {referencia}",
                "CXP");

            // Dr 101 Caja o 102 Bancos (inverso del Cr original)
            string codigoDr = (metodoPago?.ToUpper() == "TRANSFERENCIA" ||
                               metodoPago?.ToUpper() == "TARJETA"       ||
                               metodoPago?.ToUpper() == "YAPE") ? "102" : "101";
            var cuentaDr = GetCuenta(codigoDr, conn, tx);
            AddLine(asiento, cuentaDr.CuentaID, monto, 0m, $"Devolución pago ({metodoPago})");

            // Cr 200 Cuentas por Pagar (restitución de la deuda)
            var c200 = GetCuenta("200", conn, tx);
            AddLine(asiento, c200.CuentaID, 0m, monto, "Restitución deuda proveedor");

            ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
        }

        // ==================================================================
        // COBRO DE CRÉDITO (CxC)
        // ==================================================================

        /// <summary>
        /// Asiento COBRO de venta a crédito.
        ///   Dr 101 Caja o Dr 102 Bancos = monto cobrado  (proporcional si MIXTO)
        ///   Cr 120 Cuentas por Cobrar   = monto cobrado
        /// Se genera por cada venta que recibe un pago (parcial o total).
        /// </summary>
        public static int RegistrarCobroCxC(
            int ventaID, string numeroVenta, decimal monto,
            string metodoPago,
            decimal montoEfectivo, decimal montoYape, decimal montoTransferencia,
            decimal totalPago,
            DateTime fecha, int usuarioID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            if (monto <= 0m) return 0;

            PeriodosContablesRepository.ValidarFechaNoBloqueada(fecha, conn, tx);

            var hora = TimeSpan.FromSeconds((int)DateTime.Now.TimeOfDay.TotalSeconds);
            var asiento = BuildAsiento(
                "COBRO", numeroVenta, ventaID, usuarioID,
                fecha, hora,
                $"Cobro crédito {numeroVenta}", "VENTA");

            // Dr 101/102 según método de pago (proporcional cuando MIXTO)
            if (metodoPago?.ToUpper() == "MIXTO" && totalPago > 0)
            {
                decimal ef   = Math.Round(montoEfectivo                      * monto / totalPago, 2);
                decimal bank = Math.Round((montoYape + montoTransferencia)   * monto / totalPago, 2);
                decimal adj  = monto - ef - bank;   // absorbe diferencia de redondeo
                bank += adj;
                if (ef   > 0) { var c101 = GetCuenta("101", conn, tx); AddLine(asiento, c101.CuentaID, ef,   0m, "Cobro efectivo"); }
                if (bank > 0) { var c102 = GetCuenta("102", conn, tx); AddLine(asiento, c102.CuentaID, bank, 0m, "Cobro Yape/transferencia"); }
            }
            else
            {
                string cod = (metodoPago?.ToUpper() == "TRANSFERENCIA" ||
                              metodoPago?.ToUpper() == "TARJETA"       ||
                              metodoPago?.ToUpper() == "YAPE") ? "102" : "101";
                var cDr = GetCuenta(cod, conn, tx);
                AddLine(asiento, cDr.CuentaID, monto, 0m, $"Cobro crédito ({metodoPago})");
            }

            // Cr 120 CxC
            var c120 = GetCuenta("120", conn, tx);
            AddLine(asiento, c120.CuentaID, 0m, monto, $"Cancelación CxC {numeroVenta}");

            return ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
        }

        /// <summary>
        /// Asiento inverso de un cobro anulado (ANULACION_COBRO).
        ///   Dr 120 CxC                = monto  (restitución de la deuda)
        ///   Cr 101 Caja o 102 Bancos  = monto  (proporcional si MIXTO)
        /// </summary>
        public static void RegistrarAnulacionCobroCxC(
            int pagoVentaID, int ventaID, string numeroVenta, decimal monto,
            string metodoPago,
            decimal montoEfectivo, decimal montoYape, decimal montoTransferencia,
            decimal totalPago,
            DateTime fecha, int usuarioID,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            if (monto <= 0m) return;

            PeriodosContablesRepository.ValidarFechaNoBloqueada(fecha, conn, tx);

            var hora = TimeSpan.FromSeconds((int)DateTime.Now.TimeOfDay.TotalSeconds);
            var asiento = BuildAsiento(
                "ANULACION_COBRO", $"COBRO-{pagoVentaID}", ventaID, usuarioID,
                fecha, hora,
                $"Anulación cobro {numeroVenta} (PV#{pagoVentaID})", "VENTA");

            // Dr 120 CxC (restitución de la deuda)
            var c120 = GetCuenta("120", conn, tx);
            AddLine(asiento, c120.CuentaID, monto, 0m, $"Restitución CxC {numeroVenta}");

            // Cr 101/102 (proporcional si MIXTO)
            if (metodoPago?.ToUpper() == "MIXTO" && totalPago > 0)
            {
                decimal ef   = Math.Round(montoEfectivo                    * monto / totalPago, 2);
                decimal bank = Math.Round((montoYape + montoTransferencia) * monto / totalPago, 2);
                decimal adj  = monto - ef - bank;
                bank += adj;
                if (ef   > 0) { var c101 = GetCuenta("101", conn, tx); AddLine(asiento, c101.CuentaID, 0m, ef,   "Devolución efectivo"); }
                if (bank > 0) { var c102 = GetCuenta("102", conn, tx); AddLine(asiento, c102.CuentaID, 0m, bank, "Devolución Yape/transferencia"); }
            }
            else
            {
                string cod = (metodoPago?.ToUpper() == "TRANSFERENCIA" ||
                              metodoPago?.ToUpper() == "TARJETA"       ||
                              metodoPago?.ToUpper() == "YAPE") ? "102" : "101";
                var cCr = GetCuenta(cod, conn, tx);
                AddLine(asiento, cCr.CuentaID, 0m, monto, $"Devolución cobro ({metodoPago})");
            }

            ContabilidadRepository.CrearAsientoCompleto(asiento, conn, tx);
        }
    }
}
