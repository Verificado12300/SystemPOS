using SistemaPOS.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;

namespace SistemaPOS.Data
{
    public static class KardexRepository
    {
        private sealed class KardexEstado
        {
            public decimal Stock { get; set; }
            public decimal Valor { get; set; }
            public decimal CostoPromedio => Stock <= 0 ? 0 : Valor / Stock;
            public Queue<KardexLote> Lotes { get; } = new Queue<KardexLote>();
        }

        private sealed class KardexLote
        {
            public decimal Cantidad { get; set; }
            public decimal CostoUnitario { get; set; }
        }

        private class MovimientoRaw
        {
            public int ProductoID { get; set; }
            public string ProductoCodigo { get; set; }
            public string ProductoNombre { get; set; }
            public string UnidadSimbolo { get; set; }
            public DateTime FechaHora { get; set; }
            public string TipoMovimiento { get; set; }
            public string Documento { get; set; }
            public decimal Entrada { get; set; }
            public decimal Salida { get; set; }
            public decimal CostoUnitario { get; set; }
            public decimal CostoMovimiento { get; set; }
            public string Observacion { get; set; }
            public string UsuarioNombre { get; set; }
            public int OrdenTipo { get; set; }
            public int ReferenciaID { get; set; }
            public int ReferenciaDetalleID { get; set; }
            public string PresentacionInfo { get; set; }
        }

        public static List<dynamic> ListarProductos()
        {
            var lista = new List<dynamic>();
            using (var connection = DatabaseConnection.GetConnection())
            using (var cmd = new SQLiteCommand(
                @"SELECT ProductoID, Codigo, Nombre
                  FROM Productos
                  WHERE Activo = 1
                  ORDER BY Nombre;", connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(new
                    {
                        ProductoID = reader.GetInt32(0),
                        Codigo = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Nombre = reader.GetString(2)
                    });
                }
            }
            return lista;
        }

        public static List<KardexMovimiento> ObtenerMovimientos(int? productoID, DateTime? fechaDesde, DateTime? fechaHasta, string metodoValorizacion = "PROMEDIO")
        {
            var movimientos = ObtenerMovimientosRaw(productoID, fechaHasta);
            var desde = fechaDesde?.Date;
            var estados = new Dictionary<int, KardexEstado>();
            var costosSalidaAplicados = new Dictionary<string, decimal>();
            var resultado = new List<KardexMovimiento>();
            bool usarPeps = string.Equals(metodoValorizacion, "PEPS", StringComparison.OrdinalIgnoreCase);

            foreach (var m in movimientos)
            {
                if (string.Equals(m.TipoMovimiento, "ANULACION_VENTA", StringComparison.OrdinalIgnoreCase))
                {
                    var keyAnulacion = BuildSalidaKey(m);
                    decimal costoSalidaAplicado;
                    if (costosSalidaAplicados.TryGetValue(keyAnulacion, out costoSalidaAplicado) && costoSalidaAplicado > 0)
                        m.CostoUnitario = costoSalidaAplicado;
                }

                var estado = ObtenerEstado(estados, m.ProductoID);
                var stockAnterior = estado.Stock;

                decimal costoUnitarioAplicado;
                decimal costoMovimiento;
                AplicarMovimiento(estado, m, usarPeps, out costoUnitarioAplicado, out costoMovimiento);
                var stockPosterior = estado.Stock;

                if (string.Equals(m.TipoMovimiento, "VENTA", StringComparison.OrdinalIgnoreCase) && m.Salida > 0)
                    costosSalidaAplicados[BuildSalidaKey(m)] = costoUnitarioAplicado;

                if (desde.HasValue && m.FechaHora.Date < desde.Value)
                {
                    continue;
                }

                resultado.Add(new KardexMovimiento
                {
                    ProductoID = m.ProductoID,
                    ProductoCodigo = m.ProductoCodigo,
                    ProductoNombre = m.ProductoNombre,
                    UnidadSimbolo = m.UnidadSimbolo,
                    FechaHora = m.FechaHora,
                    TipoMovimiento = m.TipoMovimiento,
                    Documento = m.Documento,
                    Entrada = m.Entrada,
                    Salida = m.Salida,
                    CostoUnitario = costoUnitarioAplicado,
                    CostoMovimiento = costoMovimiento,
                    CostoSaldo = estado.Valor,
                    CostoPromedio = estado.CostoPromedio,
                    StockAnterior = stockAnterior,
                    StockPosterior = stockPosterior,
                    Observacion = m.Observacion,
                    UsuarioNombre = m.UsuarioNombre,
                    PresentacionInfo = m.PresentacionInfo
                });
            }

            return resultado;
        }

        private static KardexEstado ObtenerEstado(Dictionary<int, KardexEstado> estados, int productoID)
        {
            KardexEstado estado;
            if (!estados.TryGetValue(productoID, out estado))
            {
                estado = new KardexEstado();
                estados[productoID] = estado;
            }
            return estado;
        }

        private static void AplicarMovimiento(
            KardexEstado estado,
            MovimientoRaw movimiento,
            bool usarPeps,
            out decimal costoUnitarioAplicado,
            out decimal costoMovimiento)
        {
            costoUnitarioAplicado = 0m;
            costoMovimiento = 0m;

            if (movimiento.Entrada > 0)
            {
                costoUnitarioAplicado = movimiento.CostoUnitario > 0 ? movimiento.CostoUnitario : estado.CostoPromedio;
                costoMovimiento = movimiento.Entrada * costoUnitarioAplicado;

                estado.Stock += movimiento.Entrada;
                estado.Valor += costoMovimiento;

                if (usarPeps)
                {
                    estado.Lotes.Enqueue(new KardexLote
                    {
                        Cantidad = movimiento.Entrada,
                        CostoUnitario = costoUnitarioAplicado
                    });
                }
                return;
            }

            if (movimiento.Salida > 0)
            {
                if (usarPeps)
                {
                    decimal restante = movimiento.Salida;
                    decimal costoPeps = 0m;

                    while (restante > 0)
                    {
                        if (estado.Lotes.Count == 0)
                        {
                            decimal costoFallback = estado.CostoPromedio;
                            costoPeps += restante * costoFallback;
                            restante = 0;
                            break;
                        }

                        var lote = estado.Lotes.Peek();
                        decimal consumo = Math.Min(restante, lote.Cantidad);
                        costoPeps += consumo * lote.CostoUnitario;
                        lote.Cantidad -= consumo;
                        restante -= consumo;

                        if (lote.Cantidad <= 0)
                            estado.Lotes.Dequeue();
                    }

                    costoMovimiento = costoPeps;
                    costoUnitarioAplicado = movimiento.Salida > 0 ? costoMovimiento / movimiento.Salida : 0m;
                }
                else
                {
                    costoUnitarioAplicado = estado.CostoPromedio > 0 ? estado.CostoPromedio : movimiento.CostoUnitario;
                    costoMovimiento = movimiento.Salida * costoUnitarioAplicado;
                }

                estado.Stock -= movimiento.Salida;
                estado.Valor -= costoMovimiento;

                if (estado.Stock < 0)
                {
                    estado.Stock = 0;
                    estado.Valor = 0;
                    estado.Lotes.Clear();
                }

                if (estado.Valor < 0 && estado.Stock == 0)
                    estado.Valor = 0;
            }
        }

        private static List<MovimientoRaw> ObtenerMovimientosRaw(int? productoID, DateTime? fechaHasta)
        {
            var lista = new List<MovimientoRaw>();

            using (var connection = DatabaseConnection.GetConnection())
            using (var cmd = new SQLiteCommand(BuildQuery(), connection))
            {
                cmd.Parameters.AddWithValue("@ProductoID", (object)productoID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta.HasValue ? fechaHasta.Value.Date.ToString("yyyy-MM-dd") : (object)DBNull.Value);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new MovimientoRaw
                        {
                            ProductoID = reader.GetInt32(0),
                            ProductoCodigo = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            ProductoNombre = reader.GetString(2),
                            UnidadSimbolo = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                            FechaHora = ParseFechaHora(reader.GetString(4)),
                            TipoMovimiento = reader.GetString(5),
                            Documento = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                            Entrada = ToDecimal(reader.GetValue(7)),
                            Salida = ToDecimal(reader.GetValue(8)),
                            CostoUnitario = ToDecimal(reader.GetValue(9)),
                            CostoMovimiento = ToDecimal(reader.GetValue(10)),
                            Observacion = reader.IsDBNull(11) ? string.Empty : reader.GetString(11),
                            UsuarioNombre = reader.IsDBNull(12) ? string.Empty : reader.GetString(12),
                            OrdenTipo = Convert.ToInt32(reader.GetValue(13)),
                            ReferenciaID = Convert.ToInt32(reader.GetValue(14)),
                            ReferenciaDetalleID = Convert.ToInt32(reader.GetValue(15)),
                            PresentacionInfo = reader.FieldCount > 16 && !reader.IsDBNull(16) ? reader.GetString(16) : string.Empty
                        });
                    }
                }
            }

            return lista
                .OrderBy(x => x.FechaHora)
                .ThenBy(x => x.OrdenTipo)
                .ThenBy(x => x.ReferenciaID)
                .ThenBy(x => x.ReferenciaDetalleID)
                .ThenBy(x => x.ProductoNombre)
                .ToList();
        }

        private static string BuildSalidaKey(MovimientoRaw movimiento)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}|{1}|{2}",
                movimiento.ProductoID,
                movimiento.ReferenciaID,
                movimiento.ReferenciaDetalleID);
        }

        private static string BuildQuery()
        {
            return @"
                SELECT * FROM (
                    SELECT
                        p.ProductoID,
                        p.Codigo AS ProductoCodigo,
                        p.Nombre AS ProductoNombre,
                        ub.Simbolo AS UnidadSimbolo,
                        datetime(c.Fecha || ' ' || c.Hora) AS FechaHora,
                        'COMPRA' AS TipoMovimiento,
                        c.NumeroCompra AS Documento,
                        cd.CantidadUnidadesBase AS Entrada,
                        0 AS Salida,
                        CASE
                            WHEN cd.CantidadUnidadesBase > 0 THEN (cd.Subtotal / cd.CantidadUnidadesBase)
                            ELSE 0
                        END AS CostoUnitario,
                        cd.Subtotal AS CostoMovimiento,
                        COALESCE(c.Observaciones, '') AS Observacion,
                        COALESCE(u.NombreCompleto, '') AS UsuarioNombre,
                        10 AS OrdenTipo,
                        c.CompraID AS ReferenciaID,
                        cd.CompraDetalleID AS ReferenciaDetalleID,
                        CASE WHEN cd.Cantidad > 0 AND prn.Nombre IS NOT NULL
                            THEN (printf('%g', cd.Cantidad) || ' ' || prn.Nombre)
                            ELSE '' END AS PresentacionInfo
                    FROM CompraDetalles cd
                    INNER JOIN Compras c ON c.CompraID = cd.CompraID
                    INNER JOIN Productos p ON p.ProductoID = cd.ProductoID
                    INNER JOIN UnidadesBase ub ON ub.UnidadID = p.UnidadBaseID
                    LEFT JOIN Usuarios u ON u.UsuarioID = c.UsuarioID
                    LEFT JOIN ProductoPresentaciones ppj ON ppj.ProductoPresentacionID = cd.ProductoPresentacionID
                    LEFT JOIN Presentaciones prn ON prn.PresentacionID = ppj.PresentacionID
                    UNION ALL

                    SELECT
                        p.ProductoID,
                        p.Codigo AS ProductoCodigo,
                        p.Nombre AS ProductoNombre,
                        ub.Simbolo AS UnidadSimbolo,
                        datetime(v.Fecha || ' ' || v.Hora) AS FechaHora,
                        'VENTA' AS TipoMovimiento,
                        v.NumeroVenta AS Documento,
                        0 AS Entrada,
                        vd.CantidadUnidadesBase AS Salida,
                        0 AS CostoUnitario,
                        0 AS CostoMovimiento,
                        COALESCE(v.Observaciones, '') AS Observacion,
                        COALESCE(u.NombreCompleto, '') AS UsuarioNombre,
                        20 AS OrdenTipo,
                        v.VentaID AS ReferenciaID,
                        vd.VentaDetalleID AS ReferenciaDetalleID,
                        CASE WHEN vd.Cantidad > 0 AND prn.Nombre IS NOT NULL
                            THEN (printf('%g', vd.Cantidad) || ' ' || prn.Nombre)
                            ELSE '' END AS PresentacionInfo
                    FROM VentaDetalles vd
                    INNER JOIN Ventas v ON v.VentaID = vd.VentaID
                    INNER JOIN Productos p ON p.ProductoID = vd.ProductoID
                    INNER JOIN UnidadesBase ub ON ub.UnidadID = p.UnidadBaseID
                    LEFT JOIN Usuarios u ON u.UsuarioID = v.UsuarioID
                    LEFT JOIN ProductoPresentaciones ppj ON ppj.ProductoPresentacionID = vd.ProductoPresentacionID
                    LEFT JOIN Presentaciones prn ON prn.PresentacionID = ppj.PresentacionID
                    UNION ALL

                    SELECT
                        p.ProductoID,
                        p.Codigo AS ProductoCodigo,
                        p.Nombre AS ProductoNombre,
                        ub.Simbolo AS UnidadSimbolo,
                        datetime(c.FechaAnulacion) AS FechaHora,
                        'ANULACION_COMPRA' AS TipoMovimiento,
                        (c.NumeroCompra || '-ANUL') AS Documento,
                        0 AS Entrada,
                        cd.CantidadUnidadesBase AS Salida,
                        CASE
                            WHEN cd.CantidadUnidadesBase > 0 THEN (cd.Subtotal / cd.CantidadUnidadesBase)
                            ELSE 0
                        END AS CostoUnitario,
                        cd.Subtotal AS CostoMovimiento,
                        COALESCE(c.MotivoAnulacion, '') AS Observacion,
                        COALESCE(u.NombreCompleto, '') AS UsuarioNombre,
                        30 AS OrdenTipo,
                        c.CompraID AS ReferenciaID,
                        cd.CompraDetalleID AS ReferenciaDetalleID,
                        CASE WHEN cd.Cantidad > 0 AND prn.Nombre IS NOT NULL
                            THEN (printf('%g', cd.Cantidad) || ' ' || prn.Nombre)
                            ELSE '' END AS PresentacionInfo
                    FROM CompraDetalles cd
                    INNER JOIN Compras c ON c.CompraID = cd.CompraID
                    INNER JOIN Productos p ON p.ProductoID = cd.ProductoID
                    INNER JOIN UnidadesBase ub ON ub.UnidadID = p.UnidadBaseID
                    LEFT JOIN Usuarios u ON u.UsuarioID = c.UsuarioID
                    LEFT JOIN ProductoPresentaciones ppj ON ppj.ProductoPresentacionID = cd.ProductoPresentacionID
                    LEFT JOIN Presentaciones prn ON prn.PresentacionID = ppj.PresentacionID
                    WHERE c.Estado = 'ANULADA' AND c.FechaAnulacion IS NOT NULL

                    UNION ALL

                    SELECT
                        p.ProductoID,
                        p.Codigo AS ProductoCodigo,
                        p.Nombre AS ProductoNombre,
                        ub.Simbolo AS UnidadSimbolo,
                        datetime(v.FechaAnulacion) AS FechaHora,
                        'ANULACION_VENTA' AS TipoMovimiento,
                        (v.NumeroVenta || '-ANUL') AS Documento,
                        vd.CantidadUnidadesBase AS Entrada,
                        0 AS Salida,
                        0 AS CostoUnitario,
                        0 AS CostoMovimiento,
                        COALESCE(v.MotivoAnulacion, '') AS Observacion,
                        COALESCE(u.NombreCompleto, '') AS UsuarioNombre,
                        40 AS OrdenTipo,
                        v.VentaID AS ReferenciaID,
                        vd.VentaDetalleID AS ReferenciaDetalleID,
                        CASE WHEN vd.Cantidad > 0 AND prn.Nombre IS NOT NULL
                            THEN (printf('%g', vd.Cantidad) || ' ' || prn.Nombre)
                            ELSE '' END AS PresentacionInfo
                    FROM VentaDetalles vd
                    INNER JOIN Ventas v ON v.VentaID = vd.VentaID
                    INNER JOIN Productos p ON p.ProductoID = vd.ProductoID
                    INNER JOIN UnidadesBase ub ON ub.UnidadID = p.UnidadBaseID
                    LEFT JOIN Usuarios u ON u.UsuarioID = v.UsuarioID
                    LEFT JOIN ProductoPresentaciones ppj ON ppj.ProductoPresentacionID = vd.ProductoPresentacionID
                    LEFT JOIN Presentaciones prn ON prn.PresentacionID = ppj.PresentacionID
                    WHERE v.Estado = 'ANULADA' AND v.FechaAnulacion IS NOT NULL

                    UNION ALL

                    SELECT
                        p.ProductoID,
                        p.Codigo AS ProductoCodigo,
                        p.Nombre AS ProductoNombre,
                        ub.Simbolo AS UnidadSimbolo,
                        datetime(a.Fecha) AS FechaHora,
                        CASE
                            WHEN a.TipoAjuste = 'ENTRADA' AND a.Motivo = 'Stock inicial' THEN 'STOCK_INICIAL'
                            WHEN a.TipoAjuste = 'ENTRADA' THEN 'AJUSTE_ENTRADA'
                            WHEN a.TipoAjuste = 'SALIDA' THEN 'AJUSTE_SALIDA'
                            ELSE 'AJUSTE_CORRECCION'
                        END AS TipoMovimiento,
                        CASE
                            WHEN a.TipoAjuste = 'ENTRADA' AND a.Motivo = 'Stock inicial' THEN ('INI-' || a.ProductoID)
                            ELSE ('AJ-' || a.AjusteID)
                        END AS Documento,
                        CASE
                            WHEN a.TipoAjuste = 'ENTRADA' THEN a.Cantidad
                            WHEN a.TipoAjuste = 'CORRECCION' AND (a.StockNuevo - a.StockAnterior) > 0 THEN (a.StockNuevo - a.StockAnterior)
                            ELSE 0
                        END AS Entrada,
                        CASE
                            WHEN a.TipoAjuste = 'SALIDA' THEN a.Cantidad
                            WHEN a.TipoAjuste = 'CORRECCION' AND (a.StockAnterior - a.StockNuevo) > 0 THEN (a.StockAnterior - a.StockNuevo)
                            ELSE 0
                        END AS Salida,
                        a.CostoUnitario AS CostoUnitario,
                        0 AS CostoMovimiento,
                        COALESCE(a.Motivo, '') AS Observacion,
                        COALESCE(u.NombreCompleto, '') AS UsuarioNombre,
                        CASE WHEN a.TipoAjuste = 'ENTRADA' AND a.Motivo = 'Stock inicial' THEN 5 ELSE 50 END AS OrdenTipo,
                        a.AjusteID AS ReferenciaID,
                        a.AjusteID AS ReferenciaDetalleID,
                        '' AS PresentacionInfo
                    FROM Ajustes a
                    INNER JOIN Productos p ON p.ProductoID = a.ProductoID
                    INNER JOIN UnidadesBase ub ON ub.UnidadID = p.UnidadBaseID
                    LEFT JOIN Usuarios u ON u.UsuarioID = a.UsuarioID
                ) k
                WHERE (@ProductoID IS NULL OR k.ProductoID = @ProductoID)
                  AND (@FechaHasta IS NULL OR date(k.FechaHora) <= date(@FechaHasta))
                ORDER BY datetime(k.FechaHora), k.OrdenTipo, k.ReferenciaID, k.ReferenciaDetalleID, k.ProductoNombre;";
        }

        private static DateTime ParseFechaHora(string value)
        {
            if (DateTime.TryParse(value, out var dt))
                return dt;

            if (DateTime.TryParseExact(value, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                return dt;

            return DateTime.MinValue;
        }

        private static decimal ToDecimal(object value)
        {
            if (value == null || value == DBNull.Value) return 0m;
            return Convert.ToDecimal(value);
        }
    }
}
