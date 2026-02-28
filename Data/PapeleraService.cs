using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SistemaPOS.Models;

namespace SistemaPOS.Data
{
    public static class PapeleraService
    {
        // ----------------------------------------------------------------
        // Helpers de mapeo
        // ----------------------------------------------------------------
        private static string GetTabla(string entidad)
        {
            switch (entidad)
            {
                case "GASTO":     return "Gastos";
                case "VENTA":     return "Ventas";
                case "COMPRA":    return "Compras";
                case "CLIENTE":   return "Clientes";
                case "PROVEEDOR": return "Proveedores";
                case "PRODUCTO":  return "Productos";
                case "CXP":       return "CuentasPorPagar";
                default: throw new ArgumentException($"Entidad desconocida: {entidad}");
            }
        }

        private static string GetPK(string entidad)
        {
            switch (entidad)
            {
                case "GASTO":     return "GastoID";
                case "VENTA":     return "VentaID";
                case "COMPRA":    return "CompraID";
                case "CLIENTE":   return "ClienteID";
                case "PROVEEDOR": return "ProveedorID";
                case "PRODUCTO":  return "ProductoID";
                case "CXP":       return "CuentaPorPagarID";
                default: throw new ArgumentException($"Entidad desconocida: {entidad}");
            }
        }

        // Columna de fecha de eliminado (varía por entidad legacy vs nuevo)
        private static string GetColFechaElim(string entidad)
        {
            switch (entidad)
            {
                case "GASTO":
                case "VENTA":
                case "COMPRA":
                    return "EliminadoFecha";
                default:
                    return "FechaEliminado";
            }
        }

        // Entidades legacy GASTO/VENTA/COMPRA tienen columnas extra EliminadoPor / RestauradoFecha / RestauradoPor
        private static bool EsEntidadLegacy(string entidad)
            => entidad == "GASTO" || entidad == "VENTA" || entidad == "COMPRA";

        // Entidades con columna Activo que se debe poner a 0/1 al eliminar/restaurar
        private static bool TieneActivo(string entidad)
            => entidad == "CLIENTE" || entidad == "PROVEEDOR" || entidad == "PRODUCTO";

        // ----------------------------------------------------------------
        // InsertarLog — internal para que repos puedan llamarlo directamente
        // Solo para ELIMINAR (SoftDelete) y RESTAURAR — no para anulaciones.
        // ----------------------------------------------------------------
        internal static void InsertarLog(string entidad, int id, string accion,
            string fecha, string usuario, string resumen,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            using (var cmd = new SQLiteCommand(@"
                INSERT INTO PapeleraLog (Entidad, EntidadId, Accion, Fecha, Usuario, DatosResumen)
                VALUES (@ent, @id, @acc, @f, @u, @res)", conn, tx))
            {
                cmd.Parameters.AddWithValue("@ent", entidad);
                cmd.Parameters.AddWithValue("@id",  id);
                cmd.Parameters.AddWithValue("@acc", accion);
                cmd.Parameters.AddWithValue("@f",   fecha);
                cmd.Parameters.AddWithValue("@u",   usuario);
                cmd.Parameters.AddWithValue("@res", resumen ?? "");
                cmd.ExecuteNonQuery();
            }
        }

        // ----------------------------------------------------------------
        // TieneImpactoContable — retorna true si el registro ya tiene
        // asiento contable vinculado O tiene CxC/CxP activas pendientes.
        // ----------------------------------------------------------------
        public static bool TieneImpactoContable(string entidad, int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                return TieneImpactoContable(entidad, id, conn, null);
            }
        }

        public static bool TieneImpactoContable(string entidad, int id,
            SQLiteConnection conn, SQLiteTransaction tx)
        {
            int n;
            using (var cmd = new SQLiteCommand(
                "SELECT COUNT(*) FROM Asientos WHERE TipoOperacion=@tipo AND ReferenciaID=@id",
                conn, tx))
            {
                cmd.Parameters.AddWithValue("@tipo", entidad);
                cmd.Parameters.AddWithValue("@id",   id);
                n = Convert.ToInt32(cmd.ExecuteScalar());
            }

            if (n > 0) return true;

            if (entidad == "VENTA")
            {
                using (var cmd2 = new SQLiteCommand(
                    "SELECT COUNT(*) FROM CreditosVentas WHERE VentaID=@id AND Estado != 'PAGADO'",
                    conn, tx))
                {
                    cmd2.Parameters.AddWithValue("@id", id);
                    n = Convert.ToInt32(cmd2.ExecuteScalar());
                }
            }
            else if (entidad == "COMPRA")
            {
                using (var cmd2 = new SQLiteCommand(
                    "SELECT COUNT(*) FROM CuentasPorPagar WHERE CompraID=@id AND Estado NOT IN ('ANULADO','PAGADO')",
                    conn, tx))
                {
                    cmd2.Parameters.AddWithValue("@id", id);
                    n = Convert.ToInt32(cmd2.ExecuteScalar());
                }
            }

            return n > 0;
        }

        // ----------------------------------------------------------------
        // SoftDelete — ejecuta dentro de la conn+tx del llamador.
        // El routing (¿tiene asiento?) debe resolverse ANTES de llamar aquí.
        // ----------------------------------------------------------------
        public static void SoftDelete(string entidad, int id, string resumen,
            string usuario, SQLiteConnection conn, SQLiteTransaction tx)
        {
            string tabla    = GetTabla(entidad);
            string pk       = GetPK(entidad);
            string colFecha = GetColFechaElim(entidad);
            string now      = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string sql;
            if (EsEntidadLegacy(entidad))
                sql = $"UPDATE {tabla} SET Eliminado=1, {colFecha}=@f, EliminadoPor=@u WHERE {pk}=@id";
            else if (TieneActivo(entidad))
                sql = $"UPDATE {tabla} SET Eliminado=1, {colFecha}=@f, Activo=0 WHERE {pk}=@id";
            else
                sql = $"UPDATE {tabla} SET Eliminado=1, {colFecha}=@f WHERE {pk}=@id";

            using (var cmd = new SQLiteCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@f",  now);
                if (EsEntidadLegacy(entidad))
                    cmd.Parameters.AddWithValue("@u", usuario);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            InsertarLog(entidad, id, "ELIMINAR", now, usuario, resumen ?? "", conn, tx);
        }

        // ----------------------------------------------------------------
        // Restaurar — abre su propia conn+tx
        // ----------------------------------------------------------------
        public static void Restaurar(string entidad, int id, string usuario)
        {
            // Guard: no restaurar si tiene asiento contable
            if (TieneImpactoContable(entidad, id))
                throw new InvalidOperationException(
                    "No se puede restaurar este registro porque ya tiene impacto contable.\n" +
                    "El historial contable permanece intacto.");

            using (var conn = DatabaseConnection.GetConnection())
            using (var tx  = conn.BeginTransaction())
            {
                try
                {
                    string tabla    = GetTabla(entidad);
                    string pk       = GetPK(entidad);
                    string now      = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    string sql;
                    if (EsEntidadLegacy(entidad))
                        sql = $"UPDATE {tabla} SET Eliminado=0, RestauradoFecha=@f, RestauradoPor=@u WHERE {pk}=@id";
                    else if (TieneActivo(entidad))
                        sql = $"UPDATE {tabla} SET Eliminado=0, Activo=1 WHERE {pk}=@id";
                    else
                        sql = $"UPDATE {tabla} SET Eliminado=0 WHERE {pk}=@id";

                    using (var cmd = new SQLiteCommand(sql, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@f",  now);
                        if (EsEntidadLegacy(entidad))
                            cmd.Parameters.AddWithValue("@u", usuario);
                        cmd.Parameters.AddWithValue("@id", id);
                        if (cmd.ExecuteNonQuery() == 0)
                            throw new Exception("Registro no encontrado en papelera.");
                    }

                    InsertarLog(entidad, id, "RESTAURAR", now, usuario, "", conn, tx);
                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        // ----------------------------------------------------------------
        // ListarPapelera — abre su propia conn, solo lectura.
        // Solo muestra Eliminado=1 (soft-delete). No muestra anulados.
        // Columnas resultado: Entidad, EntidadId, Referencia, FechaEliminado, Usuario
        // ----------------------------------------------------------------
        public static List<PapeleraEntrada> ListarPapelera(
            DateTime? desde, DateTime? hasta, string entidad, string textoBusqueda)
        {
            var resultado = new List<PapeleraEntrada>();

            string sql = @"
                SELECT 'GASTO' AS Entidad, GastoID AS EntidadId,
                       Concepto AS Referencia,
                       EliminadoFecha, EliminadoPor
                FROM Gastos WHERE Eliminado = 1 AND (Anulado IS NULL OR Anulado = 0)
                UNION ALL
                SELECT 'VENTA', VentaID, NumeroVenta,
                       EliminadoFecha, EliminadoPor
                FROM Ventas WHERE Eliminado = 1
                UNION ALL
                SELECT 'COMPRA', CompraID, NumeroCompra,
                       EliminadoFecha, EliminadoPor
                FROM Compras WHERE Eliminado = 1
                UNION ALL
                SELECT 'CLIENTE', ClienteID,
                       TRIM(COALESCE(Nombres,'') || ' ' || COALESCE(Apellidos,'')),
                       FechaEliminado,
                       (SELECT pl.Usuario FROM PapeleraLog pl WHERE pl.Entidad='CLIENTE' AND pl.EntidadId=ClienteID ORDER BY pl.rowid DESC LIMIT 1)
                FROM Clientes WHERE Eliminado = 1
                UNION ALL
                SELECT 'PROVEEDOR', ProveedorID, RazonSocial,
                       FechaEliminado,
                       (SELECT pl.Usuario FROM PapeleraLog pl WHERE pl.Entidad='PROVEEDOR' AND pl.EntidadId=ProveedorID ORDER BY pl.rowid DESC LIMIT 1)
                FROM Proveedores WHERE Eliminado = 1
                UNION ALL
                SELECT 'PRODUCTO', ProductoID, Nombre,
                       FechaEliminado,
                       (SELECT pl.Usuario FROM PapeleraLog pl WHERE pl.Entidad='PRODUCTO' AND pl.EntidadId=ProductoID ORDER BY pl.rowid DESC LIMIT 1)
                FROM Productos WHERE Eliminado = 1
                UNION ALL
                SELECT 'CXP', CuentaPorPagarID,
                       COALESCE(ProveedorNombre, 'CxP #' || CAST(CuentaPorPagarID AS TEXT)),
                       FechaEliminado,
                       (SELECT pl.Usuario FROM PapeleraLog pl WHERE pl.Entidad='CXP' AND pl.EntidadId=CuentaPorPagarID ORDER BY pl.rowid DESC LIMIT 1)
                FROM CuentasPorPagar WHERE Eliminado = 1
                ORDER BY EliminadoFecha DESC";

            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd  = new SQLiteCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string ent        = reader.GetString(0);
                    int    entId      = reader.GetInt32(1);
                    string referencia = reader.IsDBNull(2) ? "" : reader.GetString(2).Trim();
                    string fechaStr   = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    string usuStr     = reader.IsDBNull(4) ? "" : reader.GetString(4);

                    // Filtros en memoria
                    if (!string.IsNullOrEmpty(entidad) && entidad != "TODOS" && ent != entidad)
                        continue;

                    if (!string.IsNullOrEmpty(textoBusqueda) &&
                        referencia.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) < 0)
                        continue;

                    DateTime fechaElim = DateTime.MinValue;
                    DateTime.TryParse(fechaStr, out fechaElim);

                    if (desde.HasValue && fechaElim.Date < desde.Value.Date) continue;
                    if (hasta.HasValue && fechaElim.Date > hasta.Value.Date)  continue;

                    resultado.Add(new PapeleraEntrada
                    {
                        Entidad        = ent,
                        EntidadId      = entId,
                        Referencia     = referencia,
                        Monto          = 0m,   // no se muestra en UI
                        FechaEliminado = fechaElim,
                        UsuarioElimino = usuStr
                    });
                }
            }

            return resultado;
        }
    }
}
