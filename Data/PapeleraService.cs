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
                case "GASTO":  return "Gastos";
                case "VENTA":  return "Ventas";
                case "COMPRA": return "Compras";
                default: throw new ArgumentException($"Entidad desconocida: {entidad}");
            }
        }

        private static string GetPK(string entidad)
        {
            switch (entidad)
            {
                case "GASTO":  return "GastoID";
                case "VENTA":  return "VentaID";
                case "COMPRA": return "CompraID";
                default: throw new ArgumentException($"Entidad desconocida: {entidad}");
            }
        }

        private static void InsertarLog(string entidad, int id, string accion,
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
                cmd.Parameters.AddWithValue("@res", resumen);
                cmd.ExecuteNonQuery();
            }
        }

        // ----------------------------------------------------------------
        // Validación: bloquear soft-delete si el registro ya tiene impacto contable
        // ----------------------------------------------------------------
        private static void ValidarSinImpactoContable(
            string entidad, int id, SQLiteConnection conn, SQLiteTransaction tx)
        {
            // 1. ¿Existe asiento contable para este registro?
            //    TipoOperacion = "GASTO" | "VENTA" | "COMPRA" coincide con el entidad
            int nAsientos;
            using (var cmd = new SQLiteCommand(
                "SELECT COUNT(*) FROM Asientos WHERE TipoOperacion=@tipo AND ReferenciaID=@id",
                conn, tx))
            {
                cmd.Parameters.AddWithValue("@tipo", entidad);
                cmd.Parameters.AddWithValue("@id",   id);
                nAsientos = Convert.ToInt32(cmd.ExecuteScalar());
            }
            if (nAsientos > 0)
                throw new InvalidOperationException(
                    "No se puede eliminar este registro porque ya tiene impacto contable registrado.\n" +
                    "Use la opción 'Anular' para revertir sus efectos en la contabilidad.");

            // 2. Verificaciones adicionales por entidad
            if (entidad == "VENTA")
            {
                int nCxC;
                using (var cmd = new SQLiteCommand(
                    "SELECT COUNT(*) FROM CuentasPorCobrar WHERE VentaID=@id AND Estado != 'PAGADO'",
                    conn, tx))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    nCxC = Convert.ToInt32(cmd.ExecuteScalar());
                }
                if (nCxC > 0)
                    throw new InvalidOperationException(
                        "No se puede eliminar esta venta porque tiene cobros pendientes.\n" +
                        "Use la opción 'Anular' para revertir sus efectos.");
            }
            else if (entidad == "COMPRA")
            {
                int nCxP;
                using (var cmd = new SQLiteCommand(
                    "SELECT COUNT(*) FROM CuentasPorPagar WHERE CompraID=@id",
                    conn, tx))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    nCxP = Convert.ToInt32(cmd.ExecuteScalar());
                }
                if (nCxP > 0)
                    throw new InvalidOperationException(
                        "No se puede eliminar esta compra porque tiene cuentas por pagar vinculadas.\n" +
                        "Use la opción 'Anular' para revertir sus efectos.");
            }
            // GASTO: el guard de pagos activos ya existe en GastoRepository.Eliminar()
            // antes de llegar aquí. No se duplica.
        }

        // ----------------------------------------------------------------
        // SoftDelete — ejecuta dentro de la conn+tx del llamador
        // ----------------------------------------------------------------
        public static void SoftDelete(string entidad, int id, string resumen,
            string usuario, SQLiteConnection conn, SQLiteTransaction tx)
        {
            ValidarSinImpactoContable(entidad, id, conn, tx);

            string tabla = GetTabla(entidad);
            string pk    = GetPK(entidad);
            string now   = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            using (var cmd = new SQLiteCommand(
                $"UPDATE {tabla} SET Eliminado=1, EliminadoFecha=@f, EliminadoPor=@u WHERE {pk}=@id",
                conn, tx))
            {
                cmd.Parameters.AddWithValue("@f",  now);
                cmd.Parameters.AddWithValue("@u",  usuario);
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
            using (var conn = DatabaseConnection.GetConnection())
            using (var tx  = conn.BeginTransaction())
            {
                try
                {
                    string tabla = GetTabla(entidad);
                    string pk    = GetPK(entidad);
                    string now   = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    using (var cmd = new SQLiteCommand(
                        $"UPDATE {tabla} SET Eliminado=0, RestauradoFecha=@f, RestauradoPor=@u WHERE {pk}=@id",
                        conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@f",  now);
                        cmd.Parameters.AddWithValue("@u",  usuario);
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
        // ListarPapelera — abre su propia conn, solo lectura
        // ----------------------------------------------------------------
        public static List<PapeleraEntrada> ListarPapelera(
            DateTime? desde, DateTime? hasta, string entidad, string textoBusqueda)
        {
            var resultado = new List<PapeleraEntrada>();

            string sql = @"
                SELECT 'GASTO' AS Entidad, GastoID AS EntidadId,
                       Concepto   AS Referencia, Monto,
                       EliminadoFecha, EliminadoPor
                FROM Gastos WHERE Eliminado = 1
                UNION ALL
                SELECT 'VENTA', VentaID, NumeroVenta, Total,
                       EliminadoFecha, EliminadoPor
                FROM Ventas WHERE Eliminado = 1
                UNION ALL
                SELECT 'COMPRA', CompraID, NumeroCompra, Total,
                       EliminadoFecha, EliminadoPor
                FROM Compras WHERE Eliminado = 1
                ORDER BY EliminadoFecha DESC";

            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd  = new SQLiteCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string ent       = reader.GetString(0);
                    int    entId     = reader.GetInt32(1);
                    string referencia = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    decimal monto    = reader.IsDBNull(3) ? 0m : Convert.ToDecimal(reader.GetValue(3));
                    string fechaStr  = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    string usuStr    = reader.IsDBNull(5) ? "" : reader.GetString(5);

                    // Filtros en memoria (sencillo para volumen pequeño)
                    if (!string.IsNullOrEmpty(entidad) && ent != entidad)
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
                        Monto          = monto,
                        FechaEliminado = fechaElim,
                        UsuarioElimino = usuStr
                    });
                }
            }

            return resultado;
        }
    }
}
