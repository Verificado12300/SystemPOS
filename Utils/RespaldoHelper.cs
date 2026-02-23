using System;
using System.Data.SQLite;
using System.IO;
using SistemaPOS.Data;

namespace SistemaPOS.Utils
{
    /// <summary>
    /// Utilidad para crear y restaurar respaldos de la base de datos SQLite.
    /// Usa la API BackupDatabase de SQLite, que es segura aunque haya conexiones abiertas.
    /// </summary>
    public static class RespaldoHelper
    {
        private static string BuildConnectionString(string path) =>
            $"Data Source={path};Version=3;BusyTimeout=5000;";

        /// <summary>
        /// Crea un respaldo de la base de datos en la carpeta "Backups" junto al ejecutable.
        /// Nombre resultante: SistemaPOS_YYYYMMDD_HHMM.db
        /// </summary>
        /// <returns>Ruta completa del archivo de respaldo creado.</returns>
        public static string CrearRespaldo()
        {
            string dbPath = DatabaseConnection.GetDatabasePath();
            if (!File.Exists(dbPath))
                throw new FileNotFoundException("No se encontró la base de datos.", dbPath);

            string carpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");
            Directory.CreateDirectory(carpeta);

            string nombre = $"SistemaPOS_{DateTime.Now:yyyyMMdd_HHmm}.db";
            string destino = Path.Combine(carpeta, nombre);

            using (var src = new SQLiteConnection(BuildConnectionString(dbPath)))
            using (var dst = new SQLiteConnection(BuildConnectionString(destino)))
            {
                src.Open();
                dst.Open();
                src.BackupDatabase(dst, "main", "main", -1, null, 0);
            }

            return destino;
        }

        /// <summary>
        /// Restaura la base de datos desde un archivo de respaldo.
        /// Antes de restaurar crea un respaldo previo de los datos actuales.
        /// </summary>
        /// <param name="rutaRespaldo">Ruta del archivo .db a restaurar.</param>
        public static void RestaurarBD(string rutaRespaldo)
        {
            if (!File.Exists(rutaRespaldo))
                throw new FileNotFoundException("El archivo de respaldo no existe.", rutaRespaldo);

            string dbPath = DatabaseConnection.GetDatabasePath();

            // Respaldo previo de seguridad
            string carpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");
            Directory.CreateDirectory(carpeta);
            string preRestauracion = Path.Combine(carpeta,
                $"SistemaPOS_{DateTime.Now:yyyyMMdd_HHmm}_pre_restauracion.db");

            using (var src = new SQLiteConnection(BuildConnectionString(dbPath)))
            using (var dst = new SQLiteConnection(BuildConnectionString(preRestauracion)))
            {
                src.Open();
                dst.Open();
                src.BackupDatabase(dst, "main", "main", -1, null, 0);
            }

            // Restaurar el respaldo seleccionado
            using (var src = new SQLiteConnection(BuildConnectionString(rutaRespaldo)))
            using (var dst = new SQLiteConnection(BuildConnectionString(dbPath)))
            {
                src.Open();
                dst.Open();
                src.BackupDatabase(dst, "main", "main", -1, null, 0);
            }
        }
    }
}
