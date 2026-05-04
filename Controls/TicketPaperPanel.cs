using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaPOS.Controls
{
    /// <summary>
    /// Panel que dibuja un "papel de ticket" blanco con dientes de corte en los bordes
    /// superior e inferior. El fondo lo controla BackColor (propiedad estándar).
    /// </summary>
    public class TicketPaperPanel : Panel
    {
        // ── Propiedades configurables ───────────────────────────────────────────
        public Color PaperColor    { get; set; } = Color.White;
        public Color ShadowColor   { get; set; } = Color.FromArgb(35, 0, 0, 0);
        public int   ToothSize     { get; set; } = 10;   // altura del diente en px
        public int   ToothWidth    { get; set; } = 16;   // ancho de cada diente en px
        public int   PaperPaddingX { get; set; } = 16;   // margen horizontal del papel

        // ── Constructor ────────────────────────────────────────────────────────
        public TicketPaperPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw   = true;
        }

        // ── Pintura ────────────────────────────────────────────────────────────
        // OnPaintBackground rellena con BackColor automáticamente (WinForms estándar).
        // OnPaint solo dibuja el papel encima — el fondo queda 100% en manos del BackColor.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode   = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            // Calcular dimensiones del papel
            int padX       = PaperPaddingX;
            int tH         = ToothSize;
            int tW         = ToothWidth;
            int paperLeft  = padX;
            int paperRight = Width - padX;
            int paperWidth = paperRight - paperLeft;
            if (paperWidth <= 0 || Height <= tH * 2) return;

            int   numTeeth = Math.Max(1, paperWidth / tW);
            float fw       = (float)paperWidth / numTeeth;

            // Construir path con forma de ticket (zigzag arriba y abajo)
            var pts = new List<PointF>();

            // BORDE SUPERIOR — dientes apuntando hacia arriba (izq → der)
            pts.Add(new PointF(paperLeft, tH));
            for (int i = 0; i < numTeeth; i++)
            {
                float x0   = paperLeft + i * fw;
                float xMid = x0 + fw / 2f;
                float x1   = x0 + fw;
                pts.Add(new PointF(xMid, 0));
                pts.Add(new PointF(x1,  tH));
            }

            // LADO DERECHO
            pts.Add(new PointF(paperRight, Height - tH));

            // BORDE INFERIOR — dientes apuntando hacia abajo (der → izq)
            for (int i = numTeeth - 1; i >= 0; i--)
            {
                float x0   = paperLeft + i * fw;
                float xMid = x0 + fw / 2f;
                pts.Add(new PointF(xMid, Height));
                pts.Add(new PointF(x0,   Height - tH));
            }

            using (var path = new GraphicsPath())
            {
                path.AddPolygon(pts.ToArray());

                // Sombra suave
                using (var shadowPath = (GraphicsPath)path.Clone())
                {
                    var mx = new Matrix();
                    mx.Translate(3, 4);
                    shadowPath.Transform(mx);
                    using (var sb = new SolidBrush(ShadowColor))
                        g.FillPath(sb, shadowPath);
                }

                // Papel blanco
                using (var wb = new SolidBrush(PaperColor))
                    g.FillPath(wb, path);
            }
        }
    }
}
