using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace SistemaPOS.Controls
{
    public class TicketDesignPanel : Panel
    {
        public TicketDesignPanel()
        {
            DoubleBuffered = true;
            BackColor = Color.White;
        }

        public void RenderForPrint(Graphics g, Rectangle destino, int sourceHeight = 0)
        {
            if (g == null || destino.Width <= 0 || destino.Height <= 0)
            {
                return;
            }

            int logicalHeight = sourceHeight > 0 ? Math.Min(sourceHeight, Height) : Height;
            logicalHeight = Math.Max(1, logicalHeight);

            GraphicsState state = g.Save();
            try
            {
                g.SetClip(destino);
                g.TranslateTransform(destino.X, destino.Y);
                g.ScaleTransform(
                    destino.Width / (float)Math.Max(1, Width),
                    destino.Height / (float)logicalHeight);

                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                using (var bg = new SolidBrush(Color.White))
                {
                    g.FillRectangle(bg, 0, 0, Width, logicalHeight);
                }

                DrawChildrenRecursive(this, g, Point.Empty);
            }
            finally
            {
                g.Restore(state);
            }
        }

        private static void DrawChildrenRecursive(Control parent, Graphics g, Point offset)
        {
            for (int i = parent.Controls.Count - 1; i >= 0; i--)
            {
                Control c = parent.Controls[i];
                if (!c.Visible) continue;

                Rectangle rect = new Rectangle(offset.X + c.Left, offset.Y + c.Top, c.Width, c.Height);

                if (c is Panel p)
                {
                    if (p.BackColor.A > 0 && p.BackColor != Color.Transparent)
                    {
                        using (var b = new SolidBrush(p.BackColor))
                            g.FillRectangle(b, rect);
                    }
                }
                else if (c is Label lbl)
                {
                    string lblText = lbl.Text ?? string.Empty;
                    using (var b = new SolidBrush(lbl.ForeColor))
                    {
                        if (lbl.AutoSize)
                            g.DrawString(lblText, lbl.Font, b, new PointF(rect.X, rect.Y));
                        else
                        {
                            using (var sf = CreateStringFormat(lbl.TextAlign))
                                g.DrawString(lblText, lbl.Font, b, rect, sf);
                        }
                    }
                }
                else if (c is PictureBox pb && pb.Image != null)
                {
                    Rectangle img = GetImageRect(pb, rect);
                    g.DrawImage(pb.Image, img);
                }
                else if (c is DataGridView dgv)
                {
                    // DataGridView no es renderizado por DrawToBitmap/HasChildren —
                    // se dibuja manualmente celda por celda para que salga en impresión.
                    using (var wb = new SolidBrush(Color.White))
                        g.FillRectangle(wb, rect);

                    int rowY = rect.Y;

                    // ── ISSUE 1: encabezados de columna ───────────────────────────
                    if (dgv.ColumnHeadersVisible)
                    {
                        int hH     = dgv.ColumnHeadersHeight;
                        var hStyle = dgv.ColumnHeadersDefaultCellStyle;
                        var hFont  = hStyle.Font     ?? dgv.Font;
                        var hFc    = hStyle.ForeColor != Color.Empty ? hStyle.ForeColor : Color.Black;

                        g.FillRectangle(Brushes.White, rect.X, rowY, rect.Width, hH);

                        // Clip strictly to header band so no glyph anti-aliasing bleeds below.
                        var headerClipRegion = new System.Drawing.Region(new RectangleF(rect.X, rowY, rect.Width, hH));
                        var savedClip = g.Clip;
                        g.Clip = headerClipRegion;

                        int colX = rect.X;
                        foreach (DataGridViewColumn col in dgv.Columns)
                        {
                            if (!col.Visible) { colX += col.Width; continue; }
                            var chStyle = col.HeaderCell.InheritedStyle;
                            var chFont  = chStyle.Font     ?? hFont;
                            var chFc    = chStyle.ForeColor != Color.Empty ? chStyle.ForeColor : hFc;
                            var chAlignDgv = chStyle.Alignment != DataGridViewContentAlignment.NotSet
                                            ? chStyle.Alignment
                                            : DataGridViewContentAlignment.MiddleLeft;
                            var chAlign = DgvAlignToContent(chAlignDgv);
                            var hRect   = new Rectangle(colX, rowY, col.Width, hH);
                            var inner   = Rectangle.Inflate(hRect, 0, 0);
                            if (inner.Width > 0 && inner.Height > 0)
                            {
                                using (var b  = new SolidBrush(chFc))
                                using (var sf = CreateStringFormat(chAlign))
                                {
                                    sf.FormatFlags &= ~StringFormatFlags.NoWrap;
                                    sf.Trimming     = StringTrimming.None;
                                    g.DrawString(col.HeaderText, chFont, b, inner, sf);
                                }
                            }
                            colX += col.Width;
                        }

                        g.Clip = savedClip;
                        headerClipRegion.Dispose();
                        rowY += hH;
                    }

                    // ── Filas de datos ─────────────────────────────────────────
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        int colX = rect.X;
                        foreach (DataGridViewColumn col in dgv.Columns)
                        {
                            if (!col.Visible) { colX += col.Width; continue; }
                            var cell     = row.Cells[col.Index];
                            string txt   = cell.FormattedValue?.ToString() ?? "";
                            var cellRect = new Rectangle(colX, rowY, col.Width, row.Height);
                            var style    = cell.InheritedStyle;
                            var font     = style.Font ?? dgv.Font;
                            var fc       = style.ForeColor != Color.Empty ? style.ForeColor : Color.Black;
                            var align    = DgvAlignToContent(style.Alignment);
                            var inner    = Rectangle.Inflate(cellRect, -2, -1);
                            if (inner.Width > 0 && inner.Height > 0)
                            {
                                using (var b  = new SolidBrush(fc))
                                using (var sf = CreateStringFormat(align))
                                {
                                    sf.FormatFlags &= ~StringFormatFlags.NoWrap;
                                    sf.Trimming     = StringTrimming.None;
                                    g.DrawString(txt, font, b, inner, sf);
                                }
                            }
                            colX += col.Width;
                        }
                        rowY += row.Height;
                    }
                    continue; // HasChildren de DGV son controles nativos — no iterar
                }

                if (c.HasChildren)
                    DrawChildrenRecursive(c, g, new Point(rect.X, rect.Y));
            }
        }

        private static Rectangle GetImageRect(PictureBox pb, Rectangle rect)
        {
            if (pb.Image == null)
            {
                return rect;
            }

            if (pb.SizeMode == PictureBoxSizeMode.StretchImage)
            {
                return rect;
            }

            if (pb.SizeMode == PictureBoxSizeMode.Normal)
            {
                return new Rectangle(rect.X, rect.Y, Math.Min(rect.Width, pb.Image.Width), Math.Min(rect.Height, pb.Image.Height));
            }

            float rw = rect.Width / (float)Math.Max(1, pb.Image.Width);
            float rh = rect.Height / (float)Math.Max(1, pb.Image.Height);
            float ratio = Math.Min(rw, rh);
            int w = Math.Max(1, (int)Math.Round(pb.Image.Width * ratio));
            int h = Math.Max(1, (int)Math.Round(pb.Image.Height * ratio));
            int x = rect.X + (rect.Width - w) / 2;
            int y = rect.Y + (rect.Height - h) / 2;
            return new Rectangle(x, y, w, h);
        }

        private static StringFormat CreateStringFormat(ContentAlignment align)
        {
            var sf = new StringFormat(StringFormatFlags.NoClip | StringFormatFlags.NoWrap)
            {
                Trimming = StringTrimming.None
            };

            switch (align)
            {
                case ContentAlignment.TopLeft:
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleLeft:
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleCenter:
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleRight:
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomRight:
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Far;
                    break;
                default:
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    break;
            }

            return sf;
        }

        private static ContentAlignment DgvAlignToContent(DataGridViewContentAlignment a)
        {
            switch (a)
            {
                case DataGridViewContentAlignment.TopLeft:      return ContentAlignment.TopLeft;
                case DataGridViewContentAlignment.TopCenter:    return ContentAlignment.TopCenter;
                case DataGridViewContentAlignment.TopRight:     return ContentAlignment.TopRight;
                case DataGridViewContentAlignment.MiddleLeft:   return ContentAlignment.MiddleLeft;
                case DataGridViewContentAlignment.MiddleCenter: return ContentAlignment.MiddleCenter;
                case DataGridViewContentAlignment.MiddleRight:  return ContentAlignment.MiddleRight;
                case DataGridViewContentAlignment.BottomLeft:   return ContentAlignment.BottomLeft;
                case DataGridViewContentAlignment.BottomCenter: return ContentAlignment.BottomCenter;
                case DataGridViewContentAlignment.BottomRight:  return ContentAlignment.BottomRight;
                default:                                         return ContentAlignment.MiddleLeft;
            }
        }
    }
}
