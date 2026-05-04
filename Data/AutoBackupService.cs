using System;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace SistemaPOS.Data
{
    public static class AutoBackupService
    {
        private static readonly string BackupFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "SystemPOS", "Backups");

        private static readonly string LastBackupFile = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "SystemPOS", "last_auto_backup.txt");

        private const int MaxBackups = 7;

        public static DateTime? ObtenerFechaUltimoRespaldo()
        {
            if (!File.Exists(LastBackupFile)) return null;
            string text = File.ReadAllText(LastBackupFile).Trim();
            if (DateTime.TryParse(text, out DateTime dt)) return dt;
            return null;
        }

        public static void VerificarYEjecutar()
        {
            try
            {
                var last = ObtenerFechaUltimoRespaldo();
                if (last.HasValue && (DateTime.Now - last.Value).TotalHours < 24)
                    return;

                Ejecutar();
            }
            catch { /* silencioso — no bloquear inicio */ }
        }

        public static void Ejecutar()
        {
            Directory.CreateDirectory(BackupFolder);

            string dbPath = DatabaseConnection.GetDatabasePath();
            string backupName = $"sistema_pos_{DateTime.Now:yyyy-MM-dd}.db";
            string backupPath = Path.Combine(BackupFolder, backupName);

            using (var source = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            using (var dest = new SQLiteConnection($"Data Source={backupPath};Version=3;"))
            {
                source.Open();
                dest.Open();
                source.BackupDatabase(dest, "main", "main", -1, null, 0);
            }

            File.WriteAllText(LastBackupFile, DateTime.Now.ToString("o"));

            // Mantener solo los últimos MaxBackups respaldos
            var files = Directory.GetFiles(BackupFolder, "sistema_pos_*.db")
                .OrderByDescending(f => File.GetCreationTime(f))
                .ToList();

            for (int i = MaxBackups; i < files.Count; i++)
            {
                try { File.Delete(files[i]); } catch { }
            }
        }

        public static string ObtenerRutaCarpeta() => BackupFolder;
    }
}
