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
                        // Calcular costo unitario ANTES del INSERT para no contaminar
                        // el cálculo de promedio con el movimiento que vamos a insertar
                        decimal costoUnit = ContabilidadRepository
                            .ObtenerCostoPromedioUnitarioProducto(productoID, connection, transaction);

                        // Insertar el ajuste (incluye CostoUnitario para auditoría)
                        string queryAjuste = @"
                            INSERT INTO Ajustes
                            (ProductoID, TipoAjuste, Cantidad, StockAnterior, StockNuevo, CostoUnitario, Motivo, UsuarioID, Fecha)
                            VALUES
                            (@ProductoID, @TipoAjuste, @Cantidad, @StockAnterior, @StockNuevo, @CostoUnitario, @Motivo, @UsuarioID, @Fecha)";

                        using (var cmd = new SQLiteCommand(queryAjuste, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ProductoID", productoID);
                            cmd.Parameters.AddWithValue("@TipoAjuste", tipoAjuste);
                            cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                            cmd.Parameters.AddWithValue("@StockAnterior", stockAnterior);
                            cmd.Parameters.AddWithValue("@StockNuevo", stockNuevo);
                            cmd.Parameters.AddWithValue("@CostoUnitario", costoUnit);
                            cmd.Parameters.AddWithValue("@Motivo", motivo ?? "");
                            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
                            cmd.Parameters.AddWithValue("@Fecha", fecha.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.ExecuteNonQuery();
                        }

                        long ajusteID = connection.LastInsertRowId;

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

                        // Asiento contable (skip silencioso si costo == 0)
                        ContabilidadService.RegistrarAjusteInventario(
                            (int)ajusteID, productoID, tipoAjuste,
                            stockAnterior, stockNuevo, costoUnit,
                            motivo, usuarioID, fecha,
                            connection, transaction);

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
                               COALESCE(u.NombreCompleto, 'Usuario eliminado') as NombreUsuario
                        FROM Ajustes a
                        INNER JOIN Productos p ON a.ProductoID = p.ProductoID
                        LEFT JOIN Usuarios u ON a.UsuarioID = u.UsuarioID
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
                                    NombreUsuario = reader.IsDBNull(11) ? "Usuario eliminado" : reader.GetString(11)
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
