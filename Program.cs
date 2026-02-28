using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using SistemaPOS.Data;

namespace SistemaPOS
{
    static class Program
    {
        [STAThread]
        static void Main(string[] cmdArgs)
        {
            if (cmdArgs != null && Array.IndexOf(cmdArgs, "--test-guardrail") >= 0)
            {
                DatabaseConnection.Initialize();
                string logPath = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "test_guardrail.log");
                Tests.TestGuardrailRunner.Run(logPath);
                return;
            }

            string startupLogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "startup_error.log");

            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                try
                {
                    string requestedName = new AssemblyName(args.Name).Name;
                    if (requestedName == "System.Resources.Extensions"
                        || requestedName == "System.Memory"
                        || requestedName == "System.Buffers"
                        || requestedName == "System.Runtime.CompilerServices.Unsafe"
                        || requestedName == "System.Reflection.Metadata"
                        || requestedName == "System.Formats.Nrbf"
                        || requestedName == "System.Collections.Immutable"
                        || requestedName == "System.ValueTuple"
                        || requestedName == "Microsoft.Bcl.HashCode")
                    {
                        string localPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, requestedName + ".dll");
                        if (File.Exists(localPath))
                            return Assembly.LoadFrom(localPath);
                    }
                }
                catch
                {
                    // Ignorar y permitir que continue la resolución estándar.
                }
                return null;
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                DatabaseConnection.Initialize();

                if (!DatabaseConnection.ExistenUsuarios())
                {
                    var formRegistro = new Forms.Principal.FormRegistroInicial();
                    if (formRegistro.ShowDialog() == DialogResult.OK)
                    {
                        Application.Run(new Forms.Principal.FormLogin());
                    }
                }
                else
                {
                    Application.Run(new Forms.Principal.FormLogin());
                }
            }
            catch (Exception ex)
            {
                try
                {
                    File.WriteAllText(startupLogPath,
                        $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}{Environment.NewLine}{ex}{Environment.NewLine}");
                }
                catch { }

                MessageBox.Show($"Error al iniciar: {ex.Message}\n\nDetalle en: {startupLogPath}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
