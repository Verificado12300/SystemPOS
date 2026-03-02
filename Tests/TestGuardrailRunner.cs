using System;
using System.Data.SQLite;
using System.IO;
using System.Text;
using SistemaPOS.Data;

namespace SistemaPOS.Tests
{
    internal static class TestGuardrailRunner
    {
        public static void Run(string logPath)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"=== TEST GUARDRAIL CONTABLE — {DateTime.Now:yyyy-MM-dd HH:mm:ss} ===");

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var tx  = conn.BeginTransaction())
                {
                    try
                    {
                        // Obtener CuentaID válido (cuenta 101 Caja)
                        int cuentaID;
                        using (var cmd = new SQLiteCommand(
                            "SELECT CuentaID FROM CuentasContables WHERE Codigo='101' LIMIT 1",
                            conn, tx))
                        {
                            var r = cmd.ExecuteScalar();
                            if (r == null || r == DBNull.Value)
                                throw new Exception("Cuenta 101 no encontrada.");
                            cuentaID = Convert.ToInt32(r);
                        }

                        // Insertar cabecera asiento TEST (fecha futura para no confundir reportes)
                        long asientoID;
                        using (var cmd = new SQLiteCommand(@"
                            INSERT INTO Asientos
                                (Fecha, Hora, TipoOperacion, Documento, ReferenciaID,
                                 UsuarioID, Glosa, TotalDebe, TotalHaber)
                            VALUES
                                ('2099-12-31','00:00:00','TEST','TEST-GUARDRAIL',
                                 NULL, NULL, 'Test guardrail descuadrado', 10, 0)",
                            conn, tx))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (var cmd = new SQLiteCommand("SELECT last_insert_rowid()", conn, tx))
                        {
                            asientoID = (long)cmd.ExecuteScalar();
                        }
                        sb.AppendLine($"Asiento TEST insertado: ID={asientoID}");

                        // Insertar 1 detalle descuadrado: Debe=10 Haber=0
                        using (var cmd = new SQLiteCommand(@"
                            INSERT INTO AsientosDetalle (AsientoID, CuentaID, Debe, Haber, Descripcion)
                            VALUES (@A, @C, 10, 0, 'Test descuadrado')",
                            conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@A", asientoID);
                            cmd.Parameters.AddWithValue("@C", cuentaID);
                            cmd.ExecuteNonQuery();
                        }
                        sb.AppendLine("Detalle insertado: Debe=10 Haber=0 (descuadrado a propósito)");

                        // Llamar ValidarAsientoCuadrado — DEBE lanzar [GUARDRAIL]
                        bool threw = false;
                        try
                        {
                            ContabilidadRepository.ValidarAsientoCuadrado((int)asientoID, conn, tx);
                        }
                        catch (InvalidOperationException ex) when (ex.Message.Contains("[GUARDRAIL]"))
                        {
                            threw = true;
                            sb.AppendLine("[PASS] GUARDRAIL lanzó excepción correctamente:");
                            sb.AppendLine($"       {ex.Message}");
                        }

                        if (!threw)
                            sb.AppendLine("[FAIL] GUARDRAIL no lanzó excepción — guardrail ROTO.");
                    }
                    finally
                    {
                        tx.Rollback();   // SIEMPRE — no ensuciar la DB
                        sb.AppendLine("[OK] Rollback ejecutado — DB sin cambios.");
                    }
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine($"[ERROR] {ex.Message}");
            }

            sb.AppendLine("=== FIN TEST ===");
            File.WriteAllText(logPath, sb.ToString());
        }
    }
}
