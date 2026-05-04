using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SistemaPOS.Controls
{
    /// <summary>
    /// ComboBox con bordes redondeados, colores temáticos y OwnerDraw para el dropdown.
    /// Usa SetWindowTheme para render clásico controlable + WM_PAINT override para el borde.
    /// </summary>
    public class RoundedComboBox : ComboBox
    {
        // ── Colores del borde según estado ──────────────────────────────────────
        private Color _borderColor      = Color.FromArgb(203, 213, 225);
        private Color _borderHoverColor = Color.FromArgb(148, 163, 184);
        private Color _borderFocusColor = Color.FromArgb(99, 102, 241);
        private int   _borderRadius     = 8;
        private bool  _isHovered;

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        public RoundedComboBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            DrawMode  = DrawMode.OwnerDrawFixed;
            FlatStyle = FlatStyle.Flat;
            ItemHeight = 22;
            BackColor  = Color.White;
            ForeColor  = Color.FromArgb(15, 23, 42);
            Font       = new Font("Segoe UI", 9.5f);
        }

        // ── Propiedades públicas ────────────────────────────────────────────────

        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        public Color BorderFocusColor
        {
            get => _borderFocusColor;
            set { _borderFocusColor = value; Invalidate(); }
        }

        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; Invalidate(); }
        }

        // ── Handle creado: deshabilitar temas visuales para control total ──────

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetWindowTheme(Handle, "", "");
        }

        // ── Hover tracking ──────────────────────────────────────────────────────

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            Invalidate();
        }

        // ── Owner-draw: items del dropdown ──────────────────────────────────────

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0 || Items.Count == 0) return;

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            var bounds = e.Bounds;

            // Fondo del item
            using (var backBr = new SolidBrush(selected
                ? Color.FromArgb(238, 242, 255)
                : Color.White))
                e.Graphics.FillRectangle(backBr, bounds);

            // Acento lateral cuando está seleccionado
            if (selected)
            {
                using (var accentBr = new SolidBrush(Color.FromArgb(99, 102, 241)))
                    e.Graphics.FillRectangle(accentBr, bounds.X, bounds.Y, 3, bounds.Height);
            }

            // Texto del item
            var textColor = selected ? Color.FromArgb(79, 70, 229) : Color.FromArgb(15, 23, 42);
            using (var textBr = new SolidBrush(textColor))
            {
                var sf = new StringFormat { LineAlignment = StringAlignment.Center };
                e.Graphics.DrawString(
                    Items[e.Index].ToString(),
                    Font, textBr,
                    new RectangleF(bounds.X + 10, bounds.Y, bounds.Width - 10, bounds.Height),
                    sf);
            }
        }

        // ── WndProc: borde redondeado post-paint ────────────────────────────────

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0xF) // WM_PAINT
            {
                PaintRoundedBorder();
            }
        }

        private void PaintRoundedBorder()
        {
            if (!IsHandleCreated) return;

            using (var g = Graphics.FromHwnd(Handle))
            {
                g.SmoothingMode     = SmoothingMode.AntiAlias;
                g.PixelOffsetMode   = PixelOffsetMode.HighQuality;

                var outerRect  = new Rectangle(0, 0, Width, Height);
                var borderRect = new Rectangle(0, 0, Width - 1, Height - 1);

                // 1. Enmascarar esquinas con el color de fondo del padre
                var parentBg = Parent?.BackColor ?? Color.FromArgb(244, 244, 250);
                using (var roundedPath = GetRoundedPath(borderRect, _borderRadius))
                using (var region = new Region(outerRect))
                {
                    region.Exclude(roundedPath);
                    using (var br = new SolidBrush(parentBg))
                        g.FillRegion(br, region);
                }

                // 2. Dibujar borde redondeado encima del borde nativo
                bool focused = ContainsFocus;
                var borderColor = focused   ? _borderFocusColor
                               : _isHovered ? _borderHoverColor
                               : _borderColor;

                using (var path = GetRoundedPath(borderRect, _borderRadius))
                using (var pen  = new Pen(borderColor, focused ? 2f : 1.5f))
                    g.DrawPath(pen, path);
            }
        }

        // ── Helper: ruta redondeada ─────────────────────────────────────────────

        private static GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            int d = Math.Min(radius * 2, Math.Min(rect.Width, rect.Height));
            var path = new GraphicsPath();
            path.AddArc(rect.X,                rect.Y,                d, d, 180, 90);
            path.AddArc(rect.Right - d,        rect.Y,                d, d, 270, 90);
            path.AddArc(rect.Right - d,        rect.Bottom - d,       d, d,   0, 90);
            path.AddArc(rect.X,                rect.Bottom - d,       d, d,  90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
