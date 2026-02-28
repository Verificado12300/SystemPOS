using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SistemaPOS.Models;

namespace SistemaPOS.Data
{
    public class ProveedorRepository
    {
        public static List<Proveedor> ObtenerTodos()
        {
            var proveedores = new List<Proveedor>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT ProveedorID, RUC, RazonSocial, NombreComercial,
                                        Direccion, Telefono, Email, Contacto, TelefonoContacto,
                                        FechaRegistro, Activo
                                 FROM Proveedores
                                 WHERE Activo = 1
                                 ORDER BY RazonSocial";

                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        proveedores.Add(MapearProveedor(reader));
                    }
                }
            }

            return proveedores;
        }

        public static List<Proveedor> Listar(string busqueda = null, bool? activo = null)
        {
            var proveedores = new List<Proveedor>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT ProveedorID, RUC, RazonSocial, NombreComercial,
                                        Direccion, Telefono, Email, Contacto, TelefonoContacto,
                                        FechaRegistro, Activo
                                 FROM Proveedores
                                 WHERE 1=1";

                if (!string.IsNullOrEmpty(busqueda))
                    query += " AND (RUC LIKE @busqueda OR RazonSocial LIKE @busqueda OR NombreComercial LIKE @busqueda)";

                if (activo.HasValue)
                    query += " AND Activo = @activo";

                query += " ORDER BY RazonSocial";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(busqueda))
                        cmd.Parameters.AddWithValue("@busqueda", $"%{busqueda}%");

                    if (activo.HasValue)
                        cmd.Parameters.AddWithValue("@activo", activo.Value ? 1 : 0);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            proveedores.Add(MapearProveedor(reader));
                        }
                    }
                }
            }

            return proveedores;
        }

        public static Proveedor ObtenerPorID(int proveedorID)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT ProveedorID, RUC, RazonSocial, NombreComercial,
                                        Direccion, Telefono, Email, Contacto, TelefonoContacto,
                                        FechaRegistro, Activo
                                 FROM Proveedores
                                 WHERE ProveedorID = @id";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", proveedorID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return MapearProveedor(reader);
                    }
                }
            }

            return null;
        }

        public static Proveedor ObtenerPorRUC(string ruc)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT ProveedorID, RUC, RazonSocial, NombreComercial,
                                        Direccion, Telefono, Email, Contacto, TelefonoContacto,
                                        FechaRegistro, Activo
                                 FROM Proveedores
                                 WHERE RUC = @ruc";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ruc", ruc);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return MapearProveedor(reader);
                    }
                }
            }

            return null;
        }

        public static bool Crear(Proveedor proveedor)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"INSERT INTO Proveedores
                                 (RUC, RazonSocial, NombreComercial, Direccion, Telefono, Email,
                                  Contacto, TelefonoContacto, FechaRegistro, Activo)
                                 VALUES
                                 (@ruc, @razonSocial, @nombreComercial, @direccion, @telefono, @email,
                                  @contacto, @telefonoContacto, @fechaRegistro, @activo)";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ruc", proveedor.RUC ?? "");
                    cmd.Parameters.AddWithValue("@razonSocial", proveedor.RazonSocial);
                    cmd.Parameters.AddWithValue("@nombreComercial", proveedor.NombreComercial ?? "");
                    cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion ?? "");
                    cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono ?? "");
                    cmd.Parameters.AddWithValue("@email", proveedor.Email ?? "");
                    cmd.Parameters.AddWithValue("@contacto", proveedor.Contacto ?? "");
                    cmd.Parameters.AddWithValue("@telefonoContacto", proveedor.TelefonoContacto ?? "");
                    cmd.Parameters.AddWithValue("@fechaRegistro", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@activo", proveedor.Activo ? 1 : 0);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool Actualizar(Proveedor proveedor)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"UPDATE Proveedores SET
                                 RUC = @ruc,
                                 RazonSocial = @razonSocial,
                                 NombreComercial = @nombreComercial,
                                 Direccion = @direccion,
                                 Telefono = @telefono,
                                 Email = @email,
                                 Contacto = @contacto,
                                 TelefonoContacto = @telefonoContacto,
                                 Activo = @activo
                                 WHERE ProveedorID = @id";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", proveedor.ProveedorID);
                    cmd.Parameters.AddWithValue("@ruc", proveedor.RUC ?? "");
                    cmd.Parameters.AddWithValue("@razonSocial", proveedor.RazonSocial);
                    cmd.Parameters.AddWithValue("@nombreComercial", proveedor.NombreComercial ?? "");
                    cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion ?? "");
                    cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono ?? "");
                    cmd.Parameters.AddWithValue("@email", proveedor.Email ?? "");
                    cmd.Parameters.AddWithValue("@contacto", proveedor.Contacto ?? "");
                    cmd.Parameters.AddWithValue("@telefonoContacto", proveedor.TelefonoContacto ?? "");
                    cmd.Parameters.AddWithValue("@activo", proveedor.Activo ? 1 : 0);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool Eliminar(int proveedorID)
        {
            string user = SistemaPOS.Utils.SesionActual.Usuario?.NombreUsuario ?? "Sistema";

            using (var conn = DatabaseConnection.GetConnection())
            using (var tx   = conn.BeginTransaction())
            {
                try
                {
                    string resumen;
                    using (var cmd = new SQLiteCommand(
                        "SELECT RazonSocial FROM Proveedores WHERE ProveedorID=@id", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@id", proveedorID);
                        resumen = cmd.ExecuteScalar()?.ToString() ?? $"Proveedor #{proveedorID}";
                    }

                    PapeleraService.SoftDelete("PROVEEDOR", proveedorID, resumen, user, conn, tx);
                    tx.Commit();
                    return true;
                }
                catch { tx.Rollback(); throw; }
            }
        }

        public static Proveedor ObtenerInfoBasica(int proveedorID)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT ProveedorID, RUC, RazonSocial, NombreComercial, Direccion, Telefono, Email, Contacto, TelefonoContacto, FechaRegistro, Activo FROM Proveedores WHERE ProveedorID = @id";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", proveedorID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return MapearProveedor(reader);
                    }
                }
            }
            return null;
        }

        public static bool ExisteRUC(string ruc, int? exceptoProveedorID = null)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Proveedores WHERE RUC = @ruc";
                if (exceptoProveedorID.HasValue)
                    query += " AND ProveedorID != @exceptoId";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ruc", ruc);
                    if (exceptoProveedorID.HasValue)
                        cmd.Parameters.AddWithValue("@exceptoId", exceptoProveedorID.Value);

                    return (long)cmd.ExecuteScalar() > 0;
                }
            }
        }

        private static Proveedor MapearProveedor(SQLiteDataReader reader)
        {
            return new Proveedor
            {
                ProveedorID = reader.GetInt32(reader.GetOrdinal("ProveedorID")),
                RUC = reader.IsDBNull(reader.GetOrdinal("RUC")) ? "" : reader.GetString(reader.GetOrdinal("RUC")),
                RazonSocial = reader.GetString(reader.GetOrdinal("RazonSocial")),
                NombreComercial = reader.IsDBNull(reader.GetOrdinal("NombreComercial")) ? "" : reader.GetString(reader.GetOrdinal("NombreComercial")),
                Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? "" : reader.GetString(reader.GetOrdinal("Direccion")),
                Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? "" : reader.GetString(reader.GetOrdinal("Telefono")),
                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? "" : reader.GetString(reader.GetOrdinal("Email")),
                Contacto = reader.IsDBNull(reader.GetOrdinal("Contacto")) ? "" : reader.GetString(reader.GetOrdinal("Contacto")),
                TelefonoContacto = reader.IsDBNull(reader.GetOrdinal("TelefonoContacto")) ? "" : reader.GetString(reader.GetOrdinal("TelefonoContacto")),
                FechaRegistro = DateTime.Parse(reader.GetString(reader.GetOrdinal("FechaRegistro"))),
                Activo = reader.GetInt32(reader.GetOrdinal("Activo")) == 1
            };
        }
    }
}
