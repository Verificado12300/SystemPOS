using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SistemaPOS.Services
{
    public static class UpdateChecker
    {
        private const string ApiUrl =
            "https://api.github.com/repos/Verificado12300/SystemPOS/releases/latest";

        public static (bool HayActualizacion, string VersionNueva, string UrlDescarga) CheckForUpdates()
        {
            string json = DescargarJson();

            string tag = ExtraerCampo(json, "tag_name");
            string url = ExtraerUrlExe(json);

            if (string.IsNullOrEmpty(tag))
                return (false, null, null);

            string vStr  = tag.TrimStart('v', 'V');
            string[] pts = vStr.Split('.');
            while (pts.Length < 4) { vStr += ".0"; pts = vStr.Split('.'); }

            if (!Version.TryParse(vStr, out Version remota))
                return (false, null, null);

            var local = Assembly.GetExecutingAssembly().GetName().Version;
            bool hayUpdate = remota > local;

            return (hayUpdate, tag, hayUpdate ? url : null);
        }

        private static string DescargarJson()
        {
            var req = (HttpWebRequest)WebRequest.Create(ApiUrl);
            req.UserAgent = "SystemPOS-Updater/1.0";
            req.Accept    = "application/vnd.github+json";
            req.Timeout   = 10000;
            using (var resp   = (HttpWebResponse)req.GetResponse())
            using (var reader = new StreamReader(resp.GetResponseStream()))
                return reader.ReadToEnd();
        }

        private static string ExtraerCampo(string json, string campo)
        {
            var m = Regex.Match(json, $@"""{campo}""\s*:\s*""([^""]+)""");
            return m.Success ? m.Groups[1].Value : null;
        }

        private static string ExtraerUrlExe(string json)
        {
            var matches = Regex.Matches(json,
                @"""browser_download_url""\s*:\s*""([^""]+\.exe)""");
            return matches.Count > 0 ? matches[0].Groups[1].Value : null;
        }
    }
}
