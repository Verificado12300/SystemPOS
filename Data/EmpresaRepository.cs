using System;
using System.Data.SQLite;
using SistemaPOS.Models;

namespace SistemaPOS.Data
{
    public class EmpresaRepository
    {
        /// <summary>
        /// Obtiene la empresa principal (siempre ID = 1)
        /// </summary>
        public static Empresa ObtenerEmpresa()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT EmpresaID, RUC, RazonSocial, NombreComercial, Direccion,
                                        Departamento, Provincia, Distrito, Ubigeo, Telefono,
                                        Email, Web, Logo, FechaRegistro, Activo
                                 FROM Empresa WHERE EmpresaID = 1";

                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Empresa
                        {
                            EmpresaID = reader.GetInt32(0),
                            RUC = reader.IsDBNull(1) ? "" : reader.GetString(1),
                            RazonSocial = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            NombreComercial = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            Direccion = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            Departamento = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            Provincia = reader.IsDBNull(6) ? "" : reader.GetString(6),
                            Distrito = reader.IsDBNull(7) ? "" : reader.GetString(7),
                            Ubigeo = reader.IsDBNull(8) ? "" : reader.GetString(8),
                            Telefono = reader.IsDBNull(9) ? "" : reader.GetString(9),
                            Email = reader.IsDBNull(10) ? "" : reader.GetString(10),
                            Web = reader.IsDBNull(11) ? "" : reader.GetString(11),
                            Logo = reader.IsDBNull(12) ? null : (byte[])reader[12],
                            FechaRegistro = reader.IsDBNull(13) ? DateTime.Now : DateTime.Parse(reader.GetString(13)),
                            Activo = reader.IsDBNull(14) || reader.GetInt32(14) == 1
                        };
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Guarda o actualiza los datos de la empresa
        /// </summary>
        public static bool GuardarEmpresa(Empresa empresa)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    // Verificar si existe
                    string checkQuery = "SELECT COUNT(*) FROM Empresa WHERE EmpresaID = 1";
                    bool exists;

                    using (var checkCmd = new SQLiteCommand(checkQuery, connection))
                    {
                        exists = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;
                    }

                    string query;
                    if (exists)
                    {
                        query = @"UPDATE Empresa SET
                            RUC = @ruc,
                            RazonSocial = @razonSocial,
                            NombreComercial = @nombreComercial,
                            Direccion = @direccion,
                            Departamento = @departamento,
                            Provincia = @provincia,
                            Distrito = @distrito,
                            Ubigeo = @ubigeo,
                            Telefono = @telefono,
                            Email = @email,
                            Web = @web,
                            Logo = @logo
                        WHERE EmpresaID = 1";
                    }
                    else
                    {
                        query = @"INSERT INTO Empresa (
                            EmpresaID, RUC, RazonSocial, NombreComercial, Direccion,
                            Departamento, Provincia, Distrito, Ubigeo, Telefono,
                            Email, Web, Logo, Activo
                        ) VALUES (
                            1, @ruc, @razonSocial, @nombreComercial, @direccion,
                            @departamento, @provincia, @distrito, @ubigeo, @telefono,
                            @email, @web, @logo, 1
                        )";
                    }

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ruc", empresa.RUC ?? "");
                        cmd.Parameters.AddWithValue("@razonSocial", empresa.RazonSocial ?? "");
                        cmd.Parameters.AddWithValue("@nombreComercial", empresa.NombreComercial ?? "");
                        cmd.Parameters.AddWithValue("@direccion", empresa.Direccion ?? "");
                        cmd.Parameters.AddWithValue("@departamento", empresa.Departamento ?? "");
                        cmd.Parameters.AddWithValue("@provincia", empresa.Provincia ?? "");
                        cmd.Parameters.AddWithValue("@distrito", empresa.Distrito ?? "");
                        cmd.Parameters.AddWithValue("@ubigeo", empresa.Ubigeo ?? "");
                        cmd.Parameters.AddWithValue("@telefono", empresa.Telefono ?? "");
                        cmd.Parameters.AddWithValue("@email", empresa.Email ?? "");
                        cmd.Parameters.AddWithValue("@web", empresa.Web ?? "");
                        cmd.Parameters.AddWithValue("@logo", empresa.Logo ?? (object)DBNull.Value);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar empresa: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Actualiza solo el logo de la empresa
        /// </summary>
        public static bool ActualizarLogo(byte[] logo)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = "UPDATE Empresa SET Logo = @logo WHERE EmpresaID = 1";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@logo", logo ?? (object)DBNull.Value);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar el logo: {ex.Message}", ex);
            }
        }

        #region ConfigGeneral

        /// <summary>
        /// Obtiene un valor de configuración
        /// </summary>
        public static string ObtenerConfiguracion(string clave, string valorPorDefecto = "")
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT Valor FROM ConfigGeneral WHERE Clave = @clave";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@clave", clave);
                        var result = cmd.ExecuteScalar();
                        return result != null && result != DBNull.Value ? result.ToString() : valorPorDefecto;
                    }
                }
            }
            catch
            {
                return valorPorDefecto;
            }
        }

        /// <summary>
        /// Guarda un valor de configuración
        /// </summary>
        public static bool GuardarConfiguracion(string clave, string valor, string tipo = "STRING", string categoria = "Sistema", string descripcion = "")
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    // Verificar si existe
                    string checkQuery = "SELECT COUNT(*) FROM ConfigGeneral WHERE Clave = @clave";
                    bool exists;

                    using (var checkCmd = new SQLiteCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@clave", clave);
                        exists = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;
                    }

                    string query;
                    if (exists)
                    {
                        query = "UPDATE ConfigGeneral SET Valor = @valor WHERE Clave = @clave";
                    }
                    else
                    {
                        query = @"INSERT INTO ConfigGeneral (Clave, Valor, Tipo, Categoria, Descripcion)
                                  VALUES (@clave, @valor, @tipo, @categoria, @descripcion)";
                    }

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@clave", clave);
                        cmd.Parameters.AddWithValue("@valor", valor ?? "");
                        if (!exists)
                        {
                            cmd.Parameters.AddWithValue("@tipo", tipo);
                            cmd.Parameters.AddWithValue("@categoria", categoria);
                            cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        }

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Obtiene la configuración de facturación electrónica
        /// </summary>
        public static ConfiguracionFacturacion ObtenerConfiguracionFacturacion()
        {
            return new ConfiguracionFacturacion
            {
                Moneda = ObtenerConfiguracion("MONEDA", "PEN"),
                SimboloMoneda = ObtenerConfiguracion("SIMBOLO_MONEDA", "S/"),
                UsuarioSOL = ObtenerConfiguracion("USUARIO_SOL", ""),
                ClaveSOL = ObtenerConfiguracion("CLAVE_SOL", ""),
                SerieNotaVenta = ObtenerConfiguracion("SERIE_NOTA_VENTA", "NV01"),
                CorrelativoNotaVenta = int.Parse(ObtenerConfiguracion("CORRELATIVO_NOTA_VENTA", "0")),
                SerieBoleta = ObtenerConfiguracion("SERIE_BOLETA", "B001"),
                CorrelativoBoleta = int.Parse(ObtenerConfiguracion("CORRELATIVO_BOLETA", "0")),
                SerieFactura = ObtenerConfiguracion("SERIE_FACTURA", "F001"),
                CorrelativoFactura = int.Parse(ObtenerConfiguracion("CORRELATIVO_FACTURA", "0"))
            };
        }

        /// <summary>
        /// Guarda la configuración de facturación electrónica
        /// </summary>
        public static bool GuardarConfiguracionFacturacion(ConfiguracionFacturacion config)
        {
            try
            {
                GuardarConfiguracion("MONEDA", config.Moneda, "STRING", "Facturacion", "Código de moneda");
                GuardarConfiguracion("SIMBOLO_MONEDA", config.SimboloMoneda, "STRING", "Facturacion", "Símbolo de la moneda");
                GuardarConfiguracion("USUARIO_SOL", config.UsuarioSOL, "STRING", "Facturacion", "Usuario SOL para facturación electrónica");
                GuardarConfiguracion("CLAVE_SOL", config.ClaveSOL, "STRING", "Facturacion", "Clave SOL para facturación electrónica");
                GuardarConfiguracion("SERIE_NOTA_VENTA", config.SerieNotaVenta, "STRING", "Facturacion", "Serie para notas de venta");
                GuardarConfiguracion("CORRELATIVO_NOTA_VENTA", config.CorrelativoNotaVenta.ToString(), "INTEGER", "Facturacion", "Correlativo actual de notas de venta");
                GuardarConfiguracion("SERIE_BOLETA", config.SerieBoleta, "STRING", "Facturacion", "Serie para boletas");
                GuardarConfiguracion("CORRELATIVO_BOLETA", config.CorrelativoBoleta.ToString(), "INTEGER", "Facturacion", "Correlativo actual de boletas");
                GuardarConfiguracion("SERIE_FACTURA", config.SerieFactura, "STRING", "Facturacion", "Serie para facturas");
                GuardarConfiguracion("CORRELATIVO_FACTURA", config.CorrelativoFactura.ToString(), "INTEGER", "Facturacion", "Correlativo actual de facturas");

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }

    /// <summary>
    /// Modelo para configuración de facturación
    /// </summary>
    public class ConfiguracionFacturacion
    {
        public string Moneda { get; set; } = "PEN";
        public string SimboloMoneda { get; set; } = "S/";
        public string UsuarioSOL { get; set; } = "";
        public string ClaveSOL { get; set; } = "";
        public string SerieNotaVenta { get; set; } = "NV01";
        public int CorrelativoNotaVenta { get; set; } = 0;
        public string SerieBoleta { get; set; } = "B001";
        public int CorrelativoBoleta { get; set; } = 0;
        public string SerieFactura { get; set; } = "F001";
        public int CorrelativoFactura { get; set; } = 0;
    }
}
