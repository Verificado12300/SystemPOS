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
    }
}
