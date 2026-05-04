using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SistemaPOS.Models;
using SistemaPOS.Utils;

namespace SistemaPOS.Data
{
    public class ProductoRepository
    {
        /// <summary>
        /// Devuelve todos los productos activos (ID, Codigo, Nombre) para poblar combos de búsqueda.
        /// No usa JOINs para garantizar que aparezcan aunque falte Categoría o UnidadBase.
        /// </summary>
        public static List<Producto> ObtenerCatalogoBusqueda()
        {
            var productos = new List<Producto>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                        SELECT ProductoID, Codigo, Nombre
                        FROM Productos
                        WHERE Activo = 1
                        ORDER BY Nombre";

                    using (var cmd = new SQLiteCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add(new Producto
                            {
                                ProductoID = reader.GetInt32(0),
                                Codigo     = reader.IsDBNull(1) ? "" : reader.GetString(1),
                                Nombre     = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar catálogo de productos: {ex.Message}");
            }
            return productos;
        }

        public static List<Producto> BuscarProductos(string busqueda = "", int? categoriaID = null)
        {
            var productos = new List<Producto>();

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                        SELECT p.ProductoID, p.Codigo, p.Nombre, p.StockTotal,
                               c.Nombre as CategoriaNombre, u.Nombre as UnidadNombre,
                               p.CategoriaID, p.UnidadBaseID, p.StockMinimo, p.StockMaximo,
                               p.ProveedorID, p.Activo, p.Descripcion, p.CodigoBarras,
                               p.Imagen, p.FechaCreacion, p.FechaUltimaModificacion
                        FROM Productos p
                        INNER JOIN Categorias c ON p.CategoriaID = c.CategoriaID
                        INNER JOIN UnidadesBase u ON p.UnidadBaseID = u.UnidadID
                        WHERE p.Activo = 1
                        AND (p.Nombre LIKE @Busqueda OR p.Codigo LIKE @Busqueda)
                        AND (@CategoriaID IS NULL OR p.CategoriaID = @CategoriaID)
                        ORDER BY p.Nombre
                        LIMIT 50";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Busqueda", "%" + busqueda + "%");
                        cmd.Parameters.AddWithValue("@CategoriaID", (object)categoriaID ?? DBNull.Value);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                productos.Add(new Producto
                                {
                                    ProductoID = reader.GetInt32(0),
                                    Codigo = reader.GetString(1),
                                    Nombre = reader.GetString(2),
                                    StockTotal = reader.GetDecimal(3),
                                    CategoriaID = reader.GetInt32(6),
                                    UnidadBaseID = reader.GetInt32(7),
                                    StockMinimo = reader.GetDecimal(8),
                                    StockMaximo = reader.GetDecimal(9),
                                    Imagen = reader.IsDBNull(14) ? null : (byte[])reader[14]
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar productos: {ex.Message}");
            }

            return productos;
        }

        public static List<dynamic> BuscarProductosConDetalles(string busqueda = "")
        {
            var productos = new List<dynamic>();

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                SELECT
                    p.ProductoID,
                    p.Codigo,
                    p.Nombre,
                    c.Nombre as Categoria,
                    u.Simbolo as UnidadBase,
                    p.StockTotal,
                    p.StockMinimo,
                    GROUP_CONCAT(pr.Nombre, CHAR(10)) as Presentaciones,
                    GROUP_CONCAT('S/ ' || PRINTF('%.2f', pp.PrecioVenta), CHAR(10)) as Precios
                FROM Productos p
                INNER JOIN Categorias c ON p.CategoriaID = c.CategoriaID
                INNER JOIN UnidadesBase u ON p.UnidadBaseID = u.UnidadID
                LEFT JOIN ProductoPresentaciones pp ON pp.ProductoID = p.ProductoID AND pp.Activo = 1
                LEFT JOIN Presentaciones pr ON pp.PresentacionID = pr.PresentacionID
                WHERE p.Activo = 1
                AND (p.Nombre LIKE @Busqueda OR p.Codigo LIKE @Busqueda)
                GROUP BY p.ProductoID
                ORDER BY p.Nombre
                LIMIT 50";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Busqueda", "%" + busqueda + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                productos.Add(new
                                {
                                    ProductoID = reader.GetInt32(0),
                                    Codigo = reader.GetString(1),
                                    Nombre = reader.GetString(2),
                                    Categoria = reader.GetString(3),
                                    UnidadBase = reader.GetString(4),
                                    StockTotal = reader.GetDecimal(5),
                                    StockMinimo = reader.GetDecimal(6),
                                    Presentaciones = reader.IsDBNull(7) ? "" : reader.GetString(7),
                                    Precio = reader.IsDBNull(8) ? "" : reader.GetString(8)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar productos: {ex.Message}");
            }

            return productos;
        }

        public static Producto ObtenerPorID(int productoID)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                        SELECT ProductoID, Codigo, Nombre, CategoriaID, UnidadBaseID,
                               StockTotal, StockMinimo, StockMaximo, ProveedorID, Imagen
                        FROM Productos
                        WHERE ProductoID = @ProductoID";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ProductoID", productoID);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Producto
                                {
                                    ProductoID = reader.GetInt32(0),
                                    Codigo = reader.GetString(1),
                                    Nombre = reader.GetString(2),
                                    CategoriaID = reader.GetInt32(3),
                                    UnidadBaseID = reader.GetInt32(4),
                                    StockTotal = reader.GetDecimal(5),
                                    StockMinimo = reader.GetDecimal(6),
                                    StockMaximo = reader.GetDecimal(7),
                                    ProveedorID = reader.IsDBNull(8) ? (int?)null : reader.GetInt32(8),
                                    Imagen = reader.IsDBNull(9) ? null : (byte[])reader["Imagen"]
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener producto ID {productoID}: {ex.Message}", ex);
            }

            return null;
        }

        public static List<ProductoPresentacion> ObtenerPresentaciones(int productoID)
        {
            var presentaciones = new List<ProductoPresentacion>();

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                        SELECT pp.ProductoPresentacionID, pp.PresentacionID, pp.PrecioVenta,
                               pp.CantidadUnidades, pp.CostoBase, pp.Ganancia,
                               p.Nombre as NombrePresentacion,
                               pp.PrecioIncluyeIGV
                        FROM ProductoPresentaciones pp
                        INNER JOIN Presentaciones p ON pp.PresentacionID = p.PresentacionID
                        WHERE pp.ProductoID = @ProductoID AND pp.Activo = 1";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ProductoID", productoID);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                presentaciones.Add(new ProductoPresentacion
                                {
                                    ProductoPresentacionID = reader.GetInt32(0),
                                    PresentacionID = reader.GetInt32(1),
                                    PrecioVenta = reader.GetDecimal(2),
                                    CantidadUnidades = reader.GetDecimal(3),
                                    CostoBase = reader.GetDecimal(4),
                                    Ganancia = reader.IsDBNull(5) ? (decimal?)null : reader.GetDecimal(5),
                                    ProductoID = productoID,
                                    PrecioIncluyeIGV = !reader.IsDBNull(7) && reader.GetInt32(7) == 1
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al obtener presentaciones del producto {productoID}: {ex.Message}");
            }

            return presentaciones;
        }

        public static bool Crear(Producto producto, List<ProductoPresentacion> presentaciones)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insertar producto
                        string queryProducto = @"
                            INSERT INTO Productos 
                            (Codigo, Nombre, CategoriaID, UnidadBaseID, StockTotal, StockMinimo, 
                             StockMaximo, ProveedorID, Imagen, Activo)
                            VALUES 
                            (@Codigo, @Nombre, @CategoriaID, @UnidadBaseID, @StockTotal, @StockMinimo,
                             @StockMaximo, @ProveedorID, @Imagen, 1);
                            SELECT last_insert_rowid();";

                        int productoID;
                        using (var cmd = new SQLiteCommand(queryProducto, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
                            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                            cmd.Parameters.AddWithValue("@CategoriaID", producto.CategoriaID);
                            cmd.Parameters.AddWithValue("@UnidadBaseID", producto.UnidadBaseID);
                            cmd.Parameters.AddWithValue("@StockTotal", producto.StockTotal);
                            cmd.Parameters.AddWithValue("@StockMinimo", producto.StockMinimo);
                            cmd.Parameters.AddWithValue("@StockMaximo", producto.StockMaximo);
                            cmd.Parameters.AddWithValue("@ProveedorID",
                                producto.ProveedorID.HasValue ? (object)producto.ProveedorID.Value : DBNull.Value);
                            cmd.Parameters.AddWithValue("@Imagen",
                                producto.Imagen != null ? (object)producto.Imagen : DBNull.Value);

                            productoID = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Insertar presentaciones
                        string queryPresentacion = @"
                            INSERT INTO ProductoPresentaciones
                            (ProductoID, PresentacionID, CantidadUnidades, CostoBase, PrecioVenta, Ganancia, Activo, PrecioIncluyeIGV)
                            VALUES
                            (@ProductoID, @PresentacionID, @CantidadUnidades, @CostoBase, @PrecioVenta, @Ganancia, 1, @PrecioIncluyeIGV)";

                        foreach (var presentacion in presentaciones)
                        {
                            using (var cmd = new SQLiteCommand(queryPresentacion, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@ProductoID", productoID);
                                cmd.Parameters.AddWithValue("@PresentacionID", presentacion.PresentacionID);
                                cmd.Parameters.AddWithValue("@CantidadUnidades", presentacion.CantidadUnidades);
                                cmd.Parameters.AddWithValue("@CostoBase", presentacion.CostoBase);
                                cmd.Parameters.AddWithValue("@PrecioVenta", presentacion.PrecioVenta);
                                cmd.Parameters.AddWithValue("@Ganancia", presentacion.Ganancia ?? 0);
                                cmd.Parameters.AddWithValue("@PrecioIncluyeIGV", presentacion.PrecioIncluyeIGV ? 1 : 0);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Crear movimiento de stock inicial en Kardex (automático, sin UI).
                        // Se almacena como TipoAjuste='ENTRADA' + Motivo='Stock inicial' (idempotente).
                        if (producto.StockTotal > 0)
                        {
                            string checkSI = @"SELECT COUNT(*) FROM Ajustes
                                               WHERE ProductoID = @PID
                                                 AND TipoAjuste = 'ENTRADA'
                                                 AND Motivo     = 'Stock inicial'";
                            long yaExiste;
                            using (var cmd = new SQLiteCommand(checkSI, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@PID", productoID);
                                yaExiste = (long)cmd.ExecuteScalar();
                            }

                            if (yaExiste == 0)
                            {
                                decimal costoUnitario = CalcularCostoUnitarioBase(presentaciones, productoID, connection, transaction);
                                int usuarioID = SesionActual.Usuario?.UsuarioID ?? 1;

                                string queryStockInicial = @"
                                    INSERT INTO Ajustes
                                    (ProductoID, TipoAjuste, Cantidad, StockAnterior, StockNuevo, CostoUnitario, Motivo, UsuarioID, Fecha)
                                    VALUES
                                    (@ProductoID, 'ENTRADA', @Cantidad, 0, @StockNuevo, @CostoUnitario,
                                     'Stock inicial', @UsuarioID, @Fecha)";

                                using (var cmd = new SQLiteCommand(queryStockInicial, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@ProductoID", productoID);
                                    cmd.Parameters.AddWithValue("@Cantidad", producto.StockTotal);
                                    cmd.Parameters.AddWithValue("@StockNuevo", producto.StockTotal);
                                    cmd.Parameters.AddWithValue("@CostoUnitario", costoUnitario);
                                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
                                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    cmd.ExecuteNonQuery();
                                }

                                // Asiento de apertura de inventario (skip silencioso si costo == 0)
                                ContabilidadService.RegistrarInventarioInicial(
                                    productoID, producto.Nombre,
                                    producto.StockTotal, costoUnitario,
                                    usuarioID, connection, transaction);
                            }
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

        /// <summary>
        /// Calcula el costo unitario base (S/ por u.b.) para registrar el STOCK_INICIAL.
        /// Prioridad:
        ///   1. Presentación "Granel" (nombre exacto, ignorando mayúsculas): CostoBase / CantidadUnidades.
        ///   2. Primera presentación en memoria con CantidadUnidades == 1.
        ///   3. Mínimo de (CostoBase / CantidadUnidades) entre todas las presentaciones.
        /// Si ninguna presentación tiene costo > 0, retorna 0.
        /// </summary>
        private static decimal CalcularCostoUnitarioBase(
            List<ProductoPresentacion> presentaciones,
            int productoID,
            SQLiteConnection connection,
            SQLiteTransaction transaction)
        {
            // 1. Buscar presentación "Granel" en BD (ya insertada dentro de la misma transacción)
            string queryGranel = @"
                SELECT pp.CostoBase, pp.CantidadUnidades
                FROM ProductoPresentaciones pp
                INNER JOIN Presentaciones pr ON pr.PresentacionID = pp.PresentacionID
                WHERE pp.ProductoID = @ProductoID
                  AND pp.Activo = 1
                  AND LOWER(pr.Nombre) = 'granel'
                LIMIT 1";

            using (var cmd = new SQLiteCommand(queryGranel, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@ProductoID", productoID);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        decimal costoGranel = reader.GetDecimal(0);
                        decimal cantGranel = reader.GetDecimal(1);
                        if (costoGranel > 0 && cantGranel > 0)
                            return costoGranel / cantGranel;
                    }
                }
            }

            // 2. Presentación en memoria con CantidadUnidades == 1 (unidad base)
            foreach (var p in presentaciones)
            {
                if (p.CantidadUnidades == 1m && p.CostoBase > 0)
                    return p.CostoBase;
            }

            // 3. Mínimo de CostoBase / CantidadUnidades (normaliza cualquier presentación a u.b.)
            decimal costoMin = decimal.MaxValue;
            foreach (var p in presentaciones)
            {
                if (p.CantidadUnidades > 0 && p.CostoBase > 0)
                {
                    decimal costoUnitario = p.CostoBase / p.CantidadUnidades;
                    if (costoUnitario < costoMin)
                        costoMin = costoUnitario;
                }
            }

            return costoMin == decimal.MaxValue ? 0m : costoMin;
        }

        public static string GenerarCodigoProducto()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Productos";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    long count = (long)cmd.ExecuteScalar();
                    return "PROD" + (count + 1).ToString("D4");
                }
            }
        }

        public static bool Actualizar(Producto producto, List<ProductoPresentacion> presentaciones)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Leer StockTotal actual antes de modificarlo (para CORRECCION si cambia)
                        decimal stockAnterior = 0m;
                        using (var cmd = new SQLiteCommand(
                            "SELECT StockTotal FROM Productos WHERE ProductoID = @ID",
                            connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ID", producto.ProductoID);
                            var val = cmd.ExecuteScalar();
                            if (val != null && val != DBNull.Value)
                                stockAnterior = Convert.ToDecimal(val);
                        }

                        // Actualizar producto
                        string queryProducto = @"
                    UPDATE Productos SET
                        Codigo = @Codigo,
                        Nombre = @Nombre,
                        CategoriaID = @CategoriaID,
                        UnidadBaseID = @UnidadBaseID,
                        StockTotal = @StockTotal,
                        StockMinimo = @StockMinimo,
                        StockMaximo = @StockMaximo,
                        ProveedorID = @ProveedorID,
                        Imagen = @Imagen,
                        FechaUltimaModificacion = @Fecha
                    WHERE ProductoID = @ProductoID";

                        using (var cmd = new SQLiteCommand(queryProducto, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ProductoID", producto.ProductoID);
                            cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
                            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                            cmd.Parameters.AddWithValue("@CategoriaID", producto.CategoriaID);
                            cmd.Parameters.AddWithValue("@UnidadBaseID", producto.UnidadBaseID);
                            cmd.Parameters.AddWithValue("@StockTotal", producto.StockTotal);
                            cmd.Parameters.AddWithValue("@StockMinimo", producto.StockMinimo);
                            cmd.Parameters.AddWithValue("@StockMaximo", producto.StockMaximo);
                            cmd.Parameters.AddWithValue("@ProveedorID",
                                producto.ProveedorID.HasValue ? (object)producto.ProveedorID.Value : DBNull.Value);
                            cmd.Parameters.AddWithValue("@Imagen",
                                producto.Imagen != null ? (object)producto.Imagen : DBNull.Value);
                            cmd.Parameters.AddWithValue("@Fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                            cmd.ExecuteNonQuery();
                        }

                        // Desactivar todas las presentaciones existentes (soft delete para no romper FK de VentaDetalles)
                        string deactivateQuery = "UPDATE ProductoPresentaciones SET Activo = 0 WHERE ProductoID = @ProductoID";
                        using (var cmd = new SQLiteCommand(deactivateQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ProductoID", producto.ProductoID);
                            cmd.ExecuteNonQuery();
                        }

                        // Para cada presentacion: actualizar si existe o insertar nueva
                        string updatePresQuery = @"
                    UPDATE ProductoPresentaciones SET
                        CantidadUnidades = @CantidadUnidades,
                        CostoBase = @CostoBase,
                        PrecioVenta = @PrecioVenta,
                        Ganancia = @Ganancia,
                        PrecioIncluyeIGV = @PrecioIncluyeIGV,
                        Activo = 1
                    WHERE ProductoID = @ProductoID AND PresentacionID = @PresentacionID";

                        string insertPresQuery = @"
                    INSERT INTO ProductoPresentaciones
                    (ProductoID, PresentacionID, CantidadUnidades, CostoBase, PrecioVenta, Ganancia, Activo, PrecioIncluyeIGV)
                    VALUES
                    (@ProductoID, @PresentacionID, @CantidadUnidades, @CostoBase, @PrecioVenta, @Ganancia, 1, @PrecioIncluyeIGV)";

                        foreach (var presentacion in presentaciones)
                        {
                            // Intentar actualizar primero
                            int rowsAffected;
                            using (var cmd = new SQLiteCommand(updatePresQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@ProductoID", producto.ProductoID);
                                cmd.Parameters.AddWithValue("@PresentacionID", presentacion.PresentacionID);
                                cmd.Parameters.AddWithValue("@CantidadUnidades", presentacion.CantidadUnidades);
                                cmd.Parameters.AddWithValue("@CostoBase", presentacion.CostoBase);
                                cmd.Parameters.AddWithValue("@PrecioVenta", presentacion.PrecioVenta);
                                cmd.Parameters.AddWithValue("@Ganancia", presentacion.Ganancia ?? 0);
                                cmd.Parameters.AddWithValue("@PrecioIncluyeIGV", presentacion.PrecioIncluyeIGV ? 1 : 0);
                                rowsAffected = cmd.ExecuteNonQuery();
                            }

                            // Si no existia, insertar nueva
                            if (rowsAffected == 0)
                            {
                                using (var cmd = new SQLiteCommand(insertPresQuery, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@ProductoID", producto.ProductoID);
                                    cmd.Parameters.AddWithValue("@PresentacionID", presentacion.PresentacionID);
                                    cmd.Parameters.AddWithValue("@CantidadUnidades", presentacion.CantidadUnidades);
                                    cmd.Parameters.AddWithValue("@CostoBase", presentacion.CostoBase);
                                    cmd.Parameters.AddWithValue("@PrecioVenta", presentacion.PrecioVenta);
                                    cmd.Parameters.AddWithValue("@Ganancia", presentacion.Ganancia ?? 0);
                                    cmd.Parameters.AddWithValue("@PrecioIncluyeIGV", presentacion.PrecioIncluyeIGV ? 1 : 0);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // Si el stock cambió por edición directa, registrar CORRECCION en Kardex
                        decimal stockNuevo = producto.StockTotal;
                        if (stockNuevo != stockAnterior)
                        {
                            decimal diferencia = Math.Abs(stockNuevo - stockAnterior);
                            int usuarioID = SesionActual.Usuario?.UsuarioID ?? 1;

                            string queryCorreccion = @"
                                INSERT INTO Ajustes
                                (ProductoID, TipoAjuste, Cantidad, StockAnterior, StockNuevo, CostoUnitario, Motivo, UsuarioID, Fecha)
                                VALUES
                                (@ProductoID, 'CORRECCION', @Cantidad, @StockAnterior, @StockNuevo, 0,
                                 'Corrección manual de stock', @UsuarioID, @Fecha)";

                            using (var cmd = new SQLiteCommand(queryCorreccion, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@ProductoID", producto.ProductoID);
                                cmd.Parameters.AddWithValue("@Cantidad", diferencia);
                                cmd.Parameters.AddWithValue("@StockAnterior", stockAnterior);
                                cmd.Parameters.AddWithValue("@StockNuevo", stockNuevo);
                                cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
                                cmd.Parameters.AddWithValue("@Fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                cmd.ExecuteNonQuery();
                            }
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

        public static bool Eliminar(int productoID)
        {
            try
            {
                string user = SesionActual.Usuario?.NombreUsuario ?? "Sistema";

                using (var conn = DatabaseConnection.GetConnection())
                using (var tx   = conn.BeginTransaction())
                {
                    try
                    {
                        string resumen;
                        using (var cmd = new SQLiteCommand(
                            "SELECT Nombre FROM Productos WHERE ProductoID=@id", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@id", productoID);
                            resumen = cmd.ExecuteScalar()?.ToString() ?? $"Producto #{productoID}";
                        }

                        PapeleraService.SoftDelete("PRODUCTO", productoID, resumen, user, conn, tx);
                        tx.Commit();
                        return true;
                    }
                    catch { tx.Rollback(); throw; }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar producto: {ex.Message}", ex);
            }
        }
    }
}