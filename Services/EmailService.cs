using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace SistemaPOS.Services
{
    public static class EmailService
    {
        private static string SmtpHost     => ConfigurationManager.AppSettings["SmtpHost"]     ?? "smtp.gmail.com";
        private static int    SmtpPort     => int.TryParse(ConfigurationManager.AppSettings["SmtpPort"], out int p) ? p : 587;
        private static string SmtpUser     => ConfigurationManager.AppSettings["SmtpUser"]     ?? "";
        private static string SmtpPass     => ConfigurationManager.AppSettings["SmtpPass"]     ?? "";
        private static string RemitenteName => ConfigurationManager.AppSettings["SmtpRemitente"] ?? "SystemPOS";

        public static void EnviarCodigoRecuperacion(string destinatario, string codigo, string nombreCompleto)
        {
            using (var client = new SmtpClient(SmtpHost, SmtpPort))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(SmtpUser, SmtpPass);
                client.Timeout = 15000;

                var mail = new MailMessage
                {
                    From = new MailAddress(SmtpUser, RemitenteName),
                    Subject = "Código de recuperación de contraseña",
                    IsBodyHtml = false,
                    Body =
                        $"Hola {nombreCompleto},\n\n" +
                        $"Tu código de recuperación de contraseña es:\n\n" +
                        $"    {codigo}\n\n" +
                        $"Este código es válido por 15 minutos.\n\n" +
                        $"Si no solicitaste este código, ignora este mensaje. Tu contraseña no ha sido cambiada.\n\n" +
                        $"-- {RemitenteName}"
                };
                mail.To.Add(destinatario);

                client.Send(mail);
            }
        }

        public static bool VerificarConfiguracion() =>
            !string.IsNullOrEmpty(SmtpUser) && !string.IsNullOrEmpty(SmtpPass);
    }
}
