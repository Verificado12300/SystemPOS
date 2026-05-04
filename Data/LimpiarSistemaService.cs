using System.Collections.Generic;
using System.Data.SQLite;

namespace SistemaPOS.Data
{
    public static class LimpiarSistemaService
    {
        public static int Limpiar(List<string> modulos)
        {
            int total = 0;

            using (var conn = DatabaseConnection.GetConnection())
            {
                // PRAGMA foreign_keys debe configurarse ANTES de iniciar la transacción
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "PRAGMA foreign_keys = OFF";
                    cmd.ExecuteNonQuery();
                }

                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (var modulo in modulos)
                        {
                            switch (modulo)
                            {
                                case "Ventas":
                                    total += Exec(conn, tx, "DELETE FROM PagoVenta");
                                    total += Exec(conn, tx, "DELETE FROM CreditosVentas");
                                    total += Exec(conn, tx, "DELETE FROM VentaDetalles");
                                    total += Exec(conn, tx, "DELETE FROM Ventas");
                                    break;

                                case "Compras":
                                    total += Exec(conn, tx, "DELETE FROM CreditosCompras");
                                    total += Exec(conn, tx, "DELETE FROM CompraDetalles");
                                    total += Exec(conn, tx, "DELETE FROM Compras");
                                    break;

                                case "Gastos":
                                    total += Exec(conn, tx, "DELETE FROM Gastos");
                                    break;

                                case "Caja":
                                    total += Exec(conn, tx, "DELETE FROM Cajas");
                                    break;

                                case "Contabilidad":
                                    total += Exec(conn, tx, "DELETE FROM AsientosDetalle");
                                    total += Exec(conn, tx, "DELETE FROM Asientos");
                                    total += ExecSafe(conn, tx, "DELETE FROM PeriodosContables");
                                    break;

                                case "CxC":
                                    total += Exec(conn, tx, "DELETE FROM PagoVenta");
                                    total += Exec(conn, tx, "DELETE FROM Pagos");
                                    total += Exec(conn, tx, "DELETE FROM CreditosVentas");
                                    break;

                                case "CxP":
                                    total += Exec(conn, tx, "DELETE FROM PagosProveedores");
                                    total += Exec(conn, tx, "DELETE FROM CuentasPorPagar");
                                    break;

                                case "Productos":
                                    total += Exec(conn, tx, "DELETE FROM Ajustes");
                                    total += Exec(conn, tx, "DELETE FROM ProductoPresentaciones");
                                    total += Exec(conn, tx, "DELETE FROM Productos");
                                    break;

                                case "Clientes":
                                    // ClienteID = 1 (CLIENTE GENERAL) nunca se elimina
                                    total += Exec(conn, tx, "DELETE FROM Clientes WHERE ClienteID != 1");
                                    break;

                                case "Proveedores":
                                    total += Exec(conn, tx, "DELETE FROM Proveedores");
                                    break;

                                case "Configuraciones":
                                    total += Exec(conn, tx, "DELETE FROM Categorias");
                                    total += Exec(conn, tx, "DELETE FROM UnidadesBase");
                                    total += Exec(conn, tx, "DELETE FROM Presentaciones");
                                    break;
                            }
                        }

                        // Limpiar logs siempre que se limpie algo
                        ExecSafe(conn, tx, "DELETE FROM PapeleraLog");
                        ExecSafe(conn, tx, "DELETE FROM LogsAuditoria");

                        // Resetear contadores AUTOINCREMENT de las tablas vaciadas
                        ResetSecuencias(conn, tx, modulos);

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                    finally
                    {
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "PRAGMA foreign_keys = ON";
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            return total;
        }

        private static void ResetSecuencias(SQLiteConnection conn, SQLiteTransaction tx, List<string> modulos)
        {
            var tablas = new List<string>();

            if (modulos.Contains("Ventas"))
                tablas.AddRange(new[] { "Ventas", "VentaDetalles", "CreditosVentas", "PagoVenta" });
            if (modulos.Contains("Compras"))
                tablas.AddRange(new[] { "Compras", "CompraDetalles", "CreditosCompras" });
            if (modulos.Contains("Gastos"))
                tablas.Add("Gastos");
            if (modulos.Contains("Caja"))
                tablas.Add("Cajas");
            if (modulos.Contains("Contabilidad"))
                tablas.AddRange(new[] { "Asientos", "AsientosDetalle", "PeriodosContables" });
            if (modulos.Contains("CxC"))
                tablas.AddRange(new[] { "Pagos", "PagoVenta", "CreditosVentas" });
            if (modulos.Contains("CxP"))
                tablas.AddRange(new[] { "CuentasPorPagar", "PagosProveedores" });
            if (modulos.Contains("Productos"))
                tablas.AddRange(new[] { "Productos", "ProductoPresentaciones", "Ajustes" });
            // Clientes: NO resetear — ClienteID=1 debe permanecer intacto
            if (modulos.Contains("Proveedores"))
                tablas.Add("Proveedores");
            if (modulos.Contains("Configuraciones"))
                tablas.AddRange(new[] { "Categorias", "UnidadesBase", "Presentaciones" });

            if (tablas.Count == 0) return;

            string inClause = "'" + string.Join("','", tablas) + "'";
            ExecSafe(conn, tx, "DELETE FROM sqlite_sequence WHERE name IN (" + inClause + ")");
        }

        private static int Exec(SQLiteConnection conn, SQLiteTransaction tx, string sql)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.Transaction = tx;
                cmd.CommandText = sql;
                return cmd.ExecuteNonQuery();
            }
        }

        private static int ExecSafe(SQLiteConnection conn, SQLiteTransaction tx, string sql)
        {
            try { return Exec(conn, tx, sql); }
            catch { return 0; }
        }
    }
}
