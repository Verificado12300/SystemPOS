using System;
using System.IO;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaPOS.Data;

namespace SistemaPOS.Utils
{
    /// <summary>
    /// Reproduce sonidos del sistema. Carga WAV desde disco o genera un tono
    /// en memoria como fallback. Siempre asíncrono — nunca bloquea la UI.
    /// </summary>
    public static class SonidoHelper
    {
        // ── API pública ──────────────────────────────────────────────────────

        /// <summary>Reproduce el sonido configurado para confirmación de venta.</summary>
        public static void ReproducirVenta()   => ReproducirConClave("SONIDO_VENTA_HABILITADO",  "SONIDO_VENTA_ARCHIVO",  TipoTono.VentaOk);

        /// <summary>Reproduce el sonido configurado para confirmación de compra.</summary>
        public static void ReproducirCompra()  => ReproducirConClave("SONIDO_COMPRA_HABILITADO", "SONIDO_COMPRA_ARCHIVO", TipoTono.VentaOk);

        /// <summary>Reproduce el sonido configurado para agregar producto al carrito.</summary>
        public static void ReproducirCarrito() => ReproducirConClave("SONIDO_CARRITO_HABILITADO", "SONIDO_CARRITO_ARCHIVO", TipoTono.Carrito);

        // ── Internos ─────────────────────────────────────────────────────────

        private enum TipoTono { VentaOk, Carrito }

        private static void ReproducirConClave(string claveHabilitado, string claveArchivo, TipoTono tono)
        {
            try
            {
                bool habilitado = EmpresaRepository.ObtenerConfiguracion(claveHabilitado, "1") != "0";
                if (!habilitado) return;

                string archivo = EmpresaRepository.ObtenerConfiguracion(claveArchivo, "");
                string defaultWavName = tono == TipoTono.Carrito ? "carrito.wav" : "venta.wav";
                string defaultWav = Path.Combine(
                    Path.GetDirectoryName(Application.ExecutablePath) ?? "",
                    "Sounds", defaultWavName);

                string ruta = null;
                if (!string.IsNullOrWhiteSpace(archivo) && File.Exists(archivo))
                    ruta = archivo;
                else if (File.Exists(defaultWav))
                    ruta = defaultWav;

                if (ruta != null)
                    Task.Run(() => PlayFile(ruta));
                else
                    Task.Run(() => PlayTono(tono));
            }
            catch { }
        }

        private static void PlayFile(string ruta)
        {
            try
            {
                using (var p = new SoundPlayer(ruta))
                    p.PlaySync();
            }
            catch { }
        }

        private static void PlayTono(TipoTono tono)
        {
            try
            {
                byte[] wav;
                if (tono == TipoTono.Carrito)
                    // Nota corta y suave: 1047 Hz (60 ms) — Do5
                    wav = MezclarTonos(new[] { 1047 }, new[] { 60 }, new[] { 0.45 });
                else
                    // Dos notas ascendentes: 880 Hz (80 ms) → 1320 Hz (130 ms)
                    wav = MezclarTonos(
                        new[] { 880,   1320  },
                        new[] { 80,    130   },
                        new[] { 0.65,  0.65  });

                using (var ms = new MemoryStream(wav))
                using (var p = new SoundPlayer(ms))
                    p.PlaySync();
            }
            catch { }
        }

        // ── Generador WAV en memoria ─────────────────────────────────────────

        /// <summary>
        /// Genera un WAV PCM 16-bit mono 44100 Hz con varias notas consecutivas.
        /// Cada nota tiene fade-out en el último 30%.
        /// </summary>
        private static byte[] MezclarTonos(int[] freqs, int[] duracionesMs, double[] volumenes)
        {
            const int sampleRate = 44100;

            // Calcular total de muestras
            int totalSamples = 0;
            for (int i = 0; i < freqs.Length; i++)
                totalSamples += sampleRate * duracionesMs[i] / 1000;

            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                int dataBytes = totalSamples * 2; // 16-bit = 2 bytes/sample

                // RIFF header
                bw.Write(new byte[] { 0x52, 0x49, 0x46, 0x46 }); // "RIFF"
                bw.Write(36 + dataBytes);
                bw.Write(new byte[] { 0x57, 0x41, 0x56, 0x45 }); // "WAVE"

                // fmt chunk
                bw.Write(new byte[] { 0x66, 0x6D, 0x74, 0x20 }); // "fmt "
                bw.Write(16);                   // chunk size
                bw.Write((short)1);             // PCM
                bw.Write((short)1);             // mono
                bw.Write(sampleRate);
                bw.Write(sampleRate * 2);       // byte rate
                bw.Write((short)2);             // block align
                bw.Write((short)16);            // bits per sample

                // data chunk
                bw.Write(new byte[] { 0x64, 0x61, 0x74, 0x61 }); // "data"
                bw.Write(dataBytes);

                for (int n = 0; n < freqs.Length; n++)
                {
                    int samples = sampleRate * duracionesMs[n] / 1000;
                    double vol  = volumenes[n];
                    int    freq = freqs[n];
                    double fadeStart = samples * 0.70; // fade comienza al 70%

                    for (int i = 0; i < samples; i++)
                    {
                        double t      = (double)i / sampleRate;
                        double fade   = i < fadeStart ? 1.0 : 1.0 - (i - fadeStart) / (samples - fadeStart);
                        double value  = Math.Sin(2.0 * Math.PI * freq * t) * 32767.0 * vol * fade;
                        bw.Write((short)Math.Round(value));
                    }
                }

                return ms.ToArray();
            }
        }
    }
}
