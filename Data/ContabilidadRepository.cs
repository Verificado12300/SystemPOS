using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SistemaPOS.Models;

namespace SistemaPOS.Data
{
    public static class ContabilidadRepository
    {
        // =====================================================================
        // Obtiene una cuenta contable por su codigo dentro de una transaccion
        // =====================================================================
        public static CuentaContable ObtenerCuentaPorCodigo(string codigo, SQLiteConnection conn, SQLiteTransaction tx)
        {
            string query = "SELECT CuentaID, Codigo, Nombre, Tipo, Activa FROM CuentasContables WHERE Codigo = @Codigo AND Activa = 1";
            using (var cmd = tx != null
                ? new SQLiteCommand(query, conn, tx)
                : new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new CuentaContable
                        {
                            CuentaID = reader.GetInt32(0),
                            Codigo = reader.GetString(1),
                            Nombre = reader.GetString(2),
                            Tipo = reader.GetString(3),
                            Activa = reader.GetInt32(4) == 1
                        };
                    }
                }
            }
            return null;
        }

        // =====================================================================
        // Crea un asiento contable completo (cabecera + detalles).
        // Valida que suma Debe == suma Haber y > 0.
        // Retorna el AsientoID creado.
        // =====================================================================
        public static int CrearAsientoCompleto(AsientoContable asiento, SQLiteConnection conn, SQLiteTransaction tx)
        {
            if (asiento == null || asiento.Detalles == null || asiento.Detalles.Count == 0)
                throw new Exception("El asiento no tiene detalles.");

            // Guard de período cerrado — lanza InvalidOperationException si bloqueado,
            // lo que provoca rollback en el llamador antes de cualquier INSERT.
            PeriodosContablesRepository.ValidarFechaNoBloqueada(asiento.Fecha, conn, tx);

            // Redondear cada detalle a 2 decimales ANTES de validar y guardar.
            // Esto evita que diferencias de punto flotante descuadren el asiento.
            foreach (var d in asiento.Detalles)
            {
                d.Debe  = Math.Round(d.Debe,  2, MidpointRounding.AwayFromZero);
                d.Haber = Math.Round(d.Haber, 2, MidpointRounding.AwayFromZero);
            }

            decimal sumDebe = 0m;
            decimal sumHaber = 0m;
            foreach (var d in asiento.Detalles)
            {
                sumDebe  += d.Debe;
                sumHaber += d.Haber;
            }
            sumDebe  = Math.Round(sumDebe,  2, MidpointRounding.AwayFromZero);
            sumHaber = Math.Round(sumHaber, 2, MidpointRounding.AwayFromZero);

            if (sumDebe == 0m && sumHaber == 0m)
                throw new Exception("El asiento no tiene montos: suma Debe y Haber son cero.");

            if (Math.Abs(sumDebe - sumHaber) > 0.01m)
                throw new Exception($"El asiento no cuadra: Debe={sumDebe:F2} Haber={sumHaber:F2}.");

            // Insertar cabecera
            string queryAsiento = @"
                INSERT INTO Asientos
                    (Fecha, Hora, TipoOperacion, Documento, ReferenciaID, UsuarioID, Glosa, TotalDebe, TotalHaber,
                     ModuloOrigen, OrigenId)
                VALUES
                    (@Fecha, @Hora, @TipoOperacion, @Documento, @ReferenciaID, @UsuarioID, @Glosa, @TotalDebe, @TotalHaber,
                     @ModuloOrigen, @OrigenId)";

            using (var cmd = tx != null
                ? new SQLiteCommand(queryAsiento, conn, tx)
                : new SQLiteCommand(queryAsiento, conn))
            {
                cmd.Parameters.AddWithValue("@Fecha", asiento.Fecha.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Hora", $"{asiento.Hora.Hours:D2}:{asiento.Hora.Minutes:D2}:{asiento.Hora.Seconds:D2}");
                cmd.Parameters.AddWithValue("@TipoOperacion", asiento.TipoOperacion);
                cmd.Parameters.AddWithValue("@Documento", (object)asiento.Documento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ReferenciaID", (object)asiento.ReferenciaID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UsuarioID", (object)asiento.UsuarioID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Glosa", (object)asiento.Glosa ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TotalDebe", sumDebe);
                cmd.Parameters.AddWithValue("@TotalHaber", sumHaber);
                cmd.Parameters.AddWithValue("@ModuloOrigen", asiento.ModuloOrigen ?? "SISTEMA");
                cmd.Parameters.AddWithValue("@OrigenId",     (object)asiento.OrigenId     ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }

            long asientoID;
            using (var cmd = tx != null
                ? new SQLiteCommand("SELECT last_insert_rowid()", conn, tx)
                : new SQLiteCommand("SELECT last_insert_rowid()", conn))
            {
                asientoID = (long)cmd.ExecuteScalar();
            }

            // Insertar detalles
            string queryDetalle = @"
                INSERT INTO AsientosDetalle (AsientoID, CuentaID, Debe, Haber, Descripcion)
                VALUES (@AsientoID, @CuentaID, @Debe, @Haber, @Descripcion)";

            foreach (var detalle in asiento.Detalles)
            {
                // Saltar líneas que quedaron en 0.00/0.00 tras el redondeo
                if (detalle.Debe == 0m && detalle.Haber == 0m) continue;

                using (var cmd = tx != null
                    ? new SQLiteCommand(queryDetalle, conn, tx)
                    : new SQLiteCommand(queryDetalle, conn))
                {
                    cmd.Parameters.AddWithValue("@AsientoID", asientoID);
                    cmd.Parameters.AddWithValue("@CuentaID", detalle.CuentaID);
                    cmd.Parameters.AddWithValue("@Debe",  detalle.Debe);
                    cmd.Parameters.AddWithValue("@Haber", detalle.Haber);
                    cmd.Parameters.AddWithValue("@Descripcion", (object)detalle.Descripcion ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }

            // GUARDRAIL POST-INSERT: verifica cuadratura en DB antes de retornar.
            // Si alguien alteró los detalles fuera del flujo normal esta línea lo atrapa.
            ValidarAsientoCuadrado((int)asientoID, conn, tx);

            return (int)asientoID;
        }

        // =====================================================================
        // GUARDRAIL CONTABLE: verifica que SUM(Debe) == SUM(Haber) en DB para
        // el asiento recién insertado. Lanza excepción si |Debe-Haber| > 0.01,
        // lo que fuerza rollback en el llamador antes de que se haga commit.
        // Público para poder llamarse desde ContabilidadService en flujos manuales.
        // =====================================================================
        public static void ValidarAsientoCuadrado(int asientoID, SQLiteConnection conn, SQLiteTransaction tx)
        {
            const string sql = @"
                SELECT SUM(Debe), SUM(Haber)
                FROM   AsientosDetalle
                WHERE  AsientoID = @AsientoID";

            using (var cmd = tx != null
                ? new SQLiteCommand(sql, conn, tx)
                : new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@AsientoID", asientoID);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        throw new InvalidOperationException(
                            $"[GUARDRAIL] Asiento {asientoID}: query SUM no devolvió fila.");

                    if (reader.IsDBNull(0) && reader.IsDBNull(1))
                        throw new InvalidOperationException(
                            $"[GUARDRAIL] Asiento {asientoID}: no existen detalles en AsientosDetalle.");

                    decimal debe  = reader.IsDBNull(0) ? 0m : reader.GetDecimal(0);
                    decimal haber = reader.IsDBNull(1) ? 0m : reader.GetDecimal(1);
                    decimal dif   = Math.Abs(debe - haber);

                    if (dif > 0.01m)
                        throw new InvalidOperationException(
                            $"[GUARDRAIL] Asiento {asientoID} descuadrado: " +
                            $"Debe={debe:F2} Haber={haber:F2} Diferencia={dif:F2}. " +
                            "La operación fue revertida.");
                }
            }
        }

        // =====================================================================
        // Retorna saldos por cuenta en un rango de fechas.
        // Key = Codigo de cuenta, Value = saldo (Debe - Haber o Haber - Debe segun tipo)
        // =====================================================================
        public static Dictionary<string, decimal> ObtenerSaldosPorCodigo(DateTime desde, DateTime hasta)
        {
            var result = new Dictionary<string, decimal>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT cc.Codigo, cc.Tipo,
                           COALESCE(SUM(ad.Debe), 0) as TotalDebe,
                           COALESCE(SUM(ad.Haber), 0) as TotalHaber
                    FROM CuentasContables cc
                    LEFT JOIN AsientosDetalle ad ON ad.CuentaID = cc.CuentaID
                    LEFT JOIN Asientos a ON a.AsientoID = ad.AsientoID
                        AND a.Fecha >= @FechaDesde AND a.Fecha <= @FechaHasta
                    WHERE cc.Activa = 1
                    GROUP BY cc.Codigo, cc.Tipo
                    ORDER BY cc.Codigo";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FechaDesde", desde.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@FechaHasta", hasta.ToString("yyyy-MM-dd"));

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string codigo = reader.GetString(0);
                            string tipo = reader.GetString(1);
                            decimal debe = reader.GetDecimal(2);
                            decimal haber = reader.GetDecimal(3);

                            // Para ACTIVO y GASTO: saldo natural es Debe - Haber
                            // Para PASIVO, PATRIMONIO, INGRESO: saldo natural es Haber - Debe
                            decimal saldo;
                            if (tipo == "ACTIVO" || tipo == "GASTO")
                                saldo = debe - haber;
                            else
                                saldo = haber - debe;

                            result[codigo] = saldo;
                        }
                    }
                }
            }

            return result;
        }

        // =====================================================================
        // Obtiene saldos detallados (Debe y Haber por separado) para la UI
        // =====================================================================
        public static List<dynamic> ObtenerSaldosDetallados(DateTime desde, DateTime hasta)
        {
            var result = new List<dynamic>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT cc.Codigo, cc.Nombre, cc.Tipo,
                           COALESCE(SUM(ad.Debe), 0) as TotalDebe,
                           COALESCE(SUM(ad.Haber), 0) as TotalHaber
                    FROM CuentasContables cc
                    LEFT JOIN AsientosDetalle ad ON ad.CuentaID = cc.CuentaID
                    LEFT JOIN Asientos a ON a.AsientoID = ad.AsientoID
                        AND a.Fecha >= @FechaDesde AND a.Fecha <= @FechaHasta
                    WHERE cc.Activa = 1
                    GROUP BY cc.Codigo, cc.Nombre, cc.Tipo
                    ORDER BY cc.Codigo";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FechaDesde", desde.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@FechaHasta", hasta.ToString("yyyy-MM-dd"));

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tipo = reader.GetString(2);
                            decimal debe = reader.GetDecimal(3);
                            decimal haber = reader.GetDecimal(4);
                            decimal saldo = (tipo == "ACTIVO" || tipo == "GASTO")
                                ? debe - haber
                                : haber - debe;

                            result.Add(new
                            {
                                Codigo = reader.GetString(0),
                                Nombre = reader.GetString(1),
                                Tipo = tipo,
                                Debe = debe,
                                Haber = haber,
                                Saldo = saldo
                            });
                        }
                    }
                }
            }

            return result;
        }

        // =====================================================================
        // Obtiene lista de asientos con su cabecera en un rango de fechas.
        // Todos los filtros adicionales son opcionales (null/empty = sin filtro).
        // =====================================================================
        public static List<dynamic> ObtenerAsientos(
            DateTime desde,
            DateTime hasta,
            string tipoOperacion = null,
            string cuentaCodigo  = null,
            string texto         = null,
            decimal? montoMin    = null,
            decimal? montoMax    = null)
        {
            var result = new List<dynamic>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                var sb = new System.Text.StringBuilder(@"
                    SELECT a.AsientoID, a.Fecha, a.Hora, a.TipoOperacion, a.Documento, a.Glosa, a.TotalDebe, a.TotalHaber
                    FROM Asientos a
                    WHERE a.Fecha >= @FechaDesde AND a.Fecha <= @FechaHasta");

                if (!string.IsNullOrWhiteSpace(tipoOperacion))
                    sb.Append(" AND a.TipoOperacion = @TipoOperacion");

                if (!string.IsNullOrWhiteSpace(texto))
                    sb.Append(" AND (a.Documento LIKE @Texto OR a.Glosa LIKE @Texto)");

                if (!string.IsNullOrWhiteSpace(cuentaCodigo))
                    sb.Append(@" AND EXISTS (
                        SELECT 1 FROM AsientosDetalle ad
                        INNER JOIN CuentasContables cc ON cc.CuentaID = ad.CuentaID
                        WHERE ad.AsientoID = a.AsientoID AND cc.Codigo = @CuentaCodigo)");

                if (montoMin.HasValue)
                    sb.Append(" AND a.TotalDebe >= @MontoMin");

                if (montoMax.HasValue)
                    sb.Append(" AND a.TotalDebe <= @MontoMax");

                sb.Append(" ORDER BY a.Fecha DESC, a.Hora DESC");

                using (var cmd = new SQLiteCommand(sb.ToString(), connection))
                {
                    cmd.Parameters.AddWithValue("@FechaDesde", desde.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@FechaHasta", hasta.ToString("yyyy-MM-dd"));

                    if (!string.IsNullOrWhiteSpace(tipoOperacion))
                        cmd.Parameters.AddWithValue("@TipoOperacion", tipoOperacion);

                    if (!string.IsNullOrWhiteSpace(texto))
                        cmd.Parameters.AddWithValue("@Texto", "%" + texto + "%");

                    if (!string.IsNullOrWhiteSpace(cuentaCodigo))
                        cmd.Parameters.AddWithValue("@CuentaCodigo", cuentaCodigo);

                    if (montoMin.HasValue)
                        cmd.Parameters.AddWithValue("@MontoMin", montoMin.Value);

                    if (montoMax.HasValue)
                        cmd.Parameters.AddWithValue("@MontoMax", montoMax.Value);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new
                            {
                                AsientoID     = reader.GetInt32(0),
                                Fecha         = reader.GetString(1),
                                Hora          = reader.GetString(2),
                                TipoOperacion = reader.GetString(3),
                                Documento     = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                Glosa         = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                TotalDebe     = reader.GetDecimal(6),
                                TotalHaber    = reader.GetDecimal(7)
                            });
                        }
                    }
                }
            }

            return result;
        }

        // =====================================================================
        // Obtiene los tipos de operación distintos para poblar el combo filtro
        // =====================================================================
        public static List<string> ObtenerTiposOperacion()
        {
            var lista = new List<string>();
            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new SQLiteCommand(
                "SELECT DISTINCT TipoOperacion FROM Asientos ORDER BY TipoOperacion", conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    lista.Add(reader.GetString(0));
            }
            return lista;
        }

        // =====================================================================
        // Obtiene todas las cuentas activas para poblar el combo filtro
        // =====================================================================
        public static List<dynamic> ObtenerCuentasActivas()
        {
            var lista = new List<dynamic>();
            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new SQLiteCommand(
                "SELECT Codigo, Nombre FROM CuentasContables WHERE Activa = 1 ORDER BY Codigo", conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(new
                    {
                        Codigo = reader.GetString(0),
                        Nombre = reader.GetString(1),
                        Display = reader.GetString(0) + " - " + reader.GetString(1)
                    });
                }
            }
            return lista;
        }

        // =====================================================================
        // Obtiene detalles de un asiento especifico
        // =====================================================================
        public static List<dynamic> ObtenerDetallesAsiento(int asientoID)
        {
            var result = new List<dynamic>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT ad.DetalleID, cc.Codigo, cc.Nombre, cc.Tipo, ad.Debe, ad.Haber, ad.Descripcion
                    FROM AsientosDetalle ad
                    INNER JOIN CuentasContables cc ON cc.CuentaID = ad.CuentaID
                    WHERE ad.AsientoID = @AsientoID
                    ORDER BY ad.DetalleID";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@AsientoID", asientoID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new
                            {
                                DetalleID = reader.GetInt32(0),
                                CuentaCodigo = reader.GetString(1),
                                CuentaNombre = reader.GetString(2),
                                CuentaTipo = reader.GetString(3),
                                Debe = reader.GetDecimal(4),
                                Haber = reader.GetDecimal(5),
                                Descripcion = reader.IsDBNull(6) ? "" : reader.GetString(6)
                            });
                        }
                    }
                }
            }

            return result;
        }

        // =====================================================================
        // Calcula el costo promedio unitario de un producto usando kardex promedio.
        // Se ejecuta dentro de la transaccion activa para evitar lecturas sucias.
        // =====================================================================
        public static decimal ObtenerCostoPromedioUnitarioProducto(int productoID, SQLiteConnection conn, SQLiteTransaction tx)
        {
            // Obtiene todos los movimientos en orden cronologico para calcular
            // el costo promedio ponderado movil (metodo promedio)
            string query = @"
                SELECT tipo, cantidad, costo FROM (
                    SELECT 'COMPRA' as tipo,
                           cd.CantidadUnidadesBase as cantidad,
                           cd.CostoUnitario as costo,
                           datetime(c.Fecha || ' ' || c.Hora) as fechahora
                    FROM CompraDetalles cd
                    INNER JOIN Compras c ON c.CompraID = cd.CompraID
                    WHERE cd.ProductoID = @ProductoID AND c.Estado != 'ANULADA'

                    UNION ALL

                    SELECT 'VENTA' as tipo,
                           vd.CantidadUnidadesBase as cantidad,
                           0.0 as costo,
                           datetime(v.Fecha || ' ' || v.Hora) as fechahora
                    FROM VentaDetalles vd
                    INNER JOIN Ventas v ON v.VentaID = vd.VentaID
                    WHERE vd.ProductoID = @ProductoID AND v.Estado != 'ANULADA'

                    UNION ALL

                    SELECT
                        CASE
                            WHEN a.TipoAjuste = 'ENTRADA' THEN 'ENTRADA'
                            WHEN a.TipoAjuste = 'SALIDA' THEN 'SALIDA'
                            WHEN a.TipoAjuste = 'CORRECCION' AND a.StockNuevo > a.StockAnterior THEN 'ENTRADA'
                            ELSE 'SALIDA'
                        END as tipo,
                        CASE
                            WHEN a.TipoAjuste = 'CORRECCION' THEN ABS(a.StockNuevo - a.StockAnterior)
                            ELSE a.Cantidad
                        END as cantidad,
                        a.CostoUnitario as costo,
                        a.Fecha as fechahora
                    FROM Ajustes a
                    WHERE a.ProductoID = @ProductoID
                ) ORDER BY fechahora ASC";

            decimal stockActual = 0m;
            decimal valorActual = 0m;

            using (var cmd = tx != null
                ? new SQLiteCommand(query, conn, tx)
                : new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ProductoID", productoID);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tipo = reader.GetString(0);
                        decimal cantidad = Convert.ToDecimal(reader.GetValue(1));
                        decimal costo = Convert.ToDecimal(reader.GetValue(2));

                        if (cantidad <= 0) continue;

                        if (tipo == "COMPRA" || tipo == "ENTRADA")
                        {
                            decimal costoUnitario = costo > 0 ? costo
                                : (stockActual > 0 ? valorActual / stockActual : 0);
                            stockActual += cantidad;
                            valorActual += cantidad * costoUnitario;
                        }
                        else if (tipo == "VENTA" || tipo == "SALIDA")
                        {
                            decimal costoPromedio = stockActual > 0 ? valorActual / stockActual : 0;
                            decimal salida = Math.Min(cantidad, stockActual);
                            stockActual -= salida;
                            valorActual -= salida * costoPromedio;
                            if (stockActual <= 0) { stockActual = 0; valorActual = 0; }
                            if (valorActual < 0) valorActual = 0;
                        }
                    }
                }
            }

            return stockActual > 0 ? valorActual / stockActual : 0m;
        }

        // =====================================================================
        // Saldo neto (Debe - Haber) de una cuenta contable hasta una fecha dada.
        // =====================================================================
        public static decimal ObtenerSaldoCuentaHasta(string codigoCuenta, DateTime hasta)
        {
            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new SQLiteCommand(@"
                SELECT COALESCE(SUM(ad.Debe), 0) - COALESCE(SUM(ad.Haber), 0)
                FROM AsientosDetalle ad
                INNER JOIN Asientos a ON a.AsientoID = ad.AsientoID
                INNER JOIN CuentasContables cc ON cc.CuentaID = ad.CuentaID
                WHERE cc.Codigo = @Codigo
                  AND a.Fecha <= @Hasta", conn))
            {
                cmd.Parameters.AddWithValue("@Codigo", codigoCuenta);
                cmd.Parameters.AddWithValue("@Hasta",  hasta.ToString("yyyy-MM-dd"));
                var result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value) return 0m;
                return Convert.ToDecimal(result);
            }
        }

        // =====================================================================
        // Construye el codigo de cuenta Caja/Bancos segun el metodo de pago
        // =====================================================================
        public static string ObtenerCodigoCuentaEfectivo(string metodoPago)
        {
            switch (metodoPago?.ToUpper())
            {
                case "TARJETA":
                case "TRANSFERENCIA":
                case "YAPE":
                    return "102"; // Bancos / medios digitales
                default:
                    return "101"; // Caja (solo EFECTIVO)
            }
        }
    }
}
