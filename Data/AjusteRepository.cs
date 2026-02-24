using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SistemaPOS.Models;

namespace SistemaPOS.Data
{
    public class AjusteConDetalle : Ajuste
    {
        public string NombreProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreUsuario { get; set; }
    }

    public class AjusteRepository
    {
        public static bool RegistrarAjuste(int productoID, string tipoAjuste, decimal cantidad,
            decimal stockAnterior, decimal stockNuevo, string motivo, int usuarioID, DateTime fecha)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insertar el ajuste
                        string queryAjuste = @"
                            INSERT INTO Ajustes
                            (ProductoID, TipoAjuste, Cantidad, StockAnterior, StockNuevo, Motivo, UsuarioID, Fecha)
                            VALUES
                            (@ProductoID, @TipoAjuste, @Cantidad, @StockAnterior, @StockNuevo, @Motivo, @UsuarioID, @Fecha)";

                        using (var cmd = new SQLiteCommand(queryAjuste, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ProductoID", productoID);
                            cmd.Parameters.AddWithValue("@TipoAjuste", tipoAjuste);
                            cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                            cmd.Parameters.AddWithValue("@StockAnterior", stockAnterior);
                            cmd.Parameters.AddWithValue("@StockNuevo", stockNuevo);
                            cmd.Parameters.AddWithValue("@Motivo", motivo ?? "");
                            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
                            cmd.Parameters.AddWithValue("@Fecha", fecha.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.ExecuteNonQuery();
                        }

                        // Actualizar el stock del producto
                        string queryStock = @"
                            UPDATE Productos
                            SET StockTotal = @StockNuevo,
                                FechaUltimaModificacion = @Fecha
                            WHERE ProductoID = @ProductoID";

                        using (var cmd = new SQLiteCommand(queryStock, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ProductoID", productoID);
                            cmd.Parameters.AddWithValue("@StockNuevo", stockNuevo);
                            cmd.Parameters.AddWithValue("@Fecha", fecha.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.ExecuteNonQuery();
                        }

                        // ===== ASIENTO CONTABLE =====
                        try
                        {
                            // Obtener ID del ajuste recien insertado para usarlo como referencia
                            int ajusteID;
                            using (var cmd2 = new SQLiteCommand("SELECT last_insert_rowid()", connection, transaction))
                                ajusteID = Convert.ToInt32(cmd2.ExecuteScalar());

                            decimal costoUnitario = ContabilidadRepository.ObtenerCostoPromedioUnitarioProducto(productoID, connection, transaction);

                            bool esEntrada = tipoAjuste == "ENTRADA"
                                || (tipoAjuste == "CORRECCION" && stockNuevo > stockAnterior);
                            bool esSalida = tipoAjuste == "SALIDA"
                                || (tipoAjuste == "CORRECCION" && stockNuevo < stockAnterior);

                            decimal cantidadNeta = tipoAjuste == "CORRECCION"
                                ? Math.Abs(stockNuevo - stockAnterior)
                                : cantidad;

                            decimal valorAjuste = cantidadNeta * costoUnitario;

                            if (valorAjuste > 0.001m)
                            {
                                var asiento = new Models.AsientoContable
                                {
                                    Fecha = fecha,
                                    Hora = fecha.TimeOfDay,
                                    TipoOperacion = "AJUSTE",
                                    Documento = $"AJ-{ajusteID}",
                                    ReferenciaID = ajusteID,
                                    UsuarioID = usuarioID,
                                    Glosa = $"Ajuste inventario {tipoAjuste}: {motivo ?? ""}"
                                };

                                var ctaInv = ContabilidadRepository.ObtenerCuentaPorCodigo("201", connection, transaction);

                                if (esEntrada && ctaInv != null)
                                {
                                    var ctaCapital = ContabilidadRepository.ObtenerCuentaPorCodigo("701", connection, transaction);
                                    if (ctaCapital != null)
                                    {
                                        asiento.Detalles.Add(new Models.AsientoDetalleContable { CuentaID = ctaInv.CuentaID, Debe = valorAjuste, Descripcion = "Entrada inventario ajuste" });
                                        asiento.Detalles.Add(new Models.AsientoDetalleContable { CuentaID = ctaCapital.CuentaID, Haber = valorAjuste, Descripcion = "Ajuste inventario" });
                                    }
                                }
                                else if (esSalida && ctaInv != null)
                                {
                                    var ctaCosto = ContabilidadRepository.ObtenerCuentaPorCodigo("501", connection, transaction);
                                    if (ctaCosto != null)
                                    {
                                        asiento.Detalles.Add(new Models.AsientoDetalleContable { CuentaID = ctaCosto.CuentaID, Debe = valorAjuste, Descripcion = "Salida inventario ajuste" });
                                        asiento.Detalles.Add(new Models.AsientoDetalleContable { CuentaID = ctaInv.CuentaID, Haber = valorAjuste, Descripcion = "Salida inventario ajuste" });
                                    }
                                }

                                if (asiento.Detalles.Count >= 2)
                                    ContabilidadRepository.CrearAsientoCompleto(asiento, connection, transaction);
                            }
                        }
                        catch
                        {
                            // No bloquear el ajuste si falla el asiento contable
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static List<AjusteConDetalle> ObtenerHistorialAjustes(DateTime? fechaInicio = null, DateTime? fechaFin = null,
            int? productoID = null, string tipoAjuste = null, int limite = 100)
        {
            var ajustes = new List<AjusteConDetalle>();

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                        SELECT a.AjusteID, a.ProductoID, a.TipoAjuste, a.Cantidad,
                               a.StockAnterior, a.StockNuevo, a.Motivo, a.UsuarioID, a.Fecha,
                               p.Nombre as NombreProducto, p.Codigo as CodigoProducto,
                               u.NombreCompleto as NombreUsuario
                        FROM Ajustes a
                        INNER JOIN Productos p ON a.ProductoID = p.ProductoID
                        INNER JOIN Usuarios u ON a.UsuarioID = u.UsuarioID
                        WHERE 1=1";

                    if (fechaInicio.HasValue)
                        query += " AND DATE(a.Fecha) >= @FechaInicio";
                    if (fechaFin.HasValue)
                        query += " AND DATE(a.Fecha) <= @FechaFin";
                    if (productoID.HasValue)
                        query += " AND a.ProductoID = @ProductoID";
                    if (!string.IsNullOrEmpty(tipoAjuste))
                        query += " AND a.TipoAjuste = @TipoAjuste";

                    query += " ORDER BY a.Fecha DESC LIMIT @Limite";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        if (fechaInicio.HasValue)
                            cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio.Value.ToString("yyyy-MM-dd"));
                        if (fechaFin.HasValue)
                            cmd.Parameters.AddWithValue("@FechaFin", fechaFin.Value.ToString("yyyy-MM-dd"));
                        if (productoID.HasValue)
                            cmd.Parameters.AddWithValue("@ProductoID", productoID.Value);
                        if (!string.IsNullOrEmpty(tipoAjuste))
                            cmd.Parameters.AddWithValue("@TipoAjuste", tipoAjuste);
                        cmd.Parameters.AddWithValue("@Limite", limite);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ajustes.Add(new AjusteConDetalle
                                {
                                    AjusteID = reader.GetInt32(0),
                                    ProductoID = reader.GetInt32(1),
                                    TipoAjuste = reader.GetString(2),
                                    Cantidad = reader.GetDecimal(3),
                                    StockAnterior = reader.GetDecimal(4),
                                    StockNuevo = reader.GetDecimal(5),
                                    Motivo = reader.IsDBNull(6) ? "" : reader.GetString(6),
                                    UsuarioID = reader.GetInt32(7),
                                    Fecha = DateTime.Parse(reader.GetString(8)),
                                    NombreProducto = reader.GetString(9),
                                    CodigoProducto = reader.GetString(10),
                                    NombreUsuario = reader.GetString(11)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener historial de ajustes: {ex.Message}");
            }

            return ajustes;
        }

        public static List<AjusteConDetalle> ObtenerAjustesPorProducto(int productoID)
        {
            return ObtenerHistorialAjustes(productoID: productoID);
        }

        public static decimal ObtenerStockActual(int productoID)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT StockTotal FROM Productos WHERE ProductoID = @ProductoID";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ProductoID", productoID);
                        var result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}
