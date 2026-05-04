using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaPOS.Forms.Shared
{
    public enum TipoAviso { Informacion, Advertencia, Error }

    public sealed class FormAviso : Form
    {
        // ── Colores por tipo ─────────────────────────────────────────────
        private static readonly Color ColIndigo  = Color.FromArgb(99, 102, 241);
        private static readonly Color ColAmbar   = Color.FromArgb(245, 158, 11);
        private static readonly Color ColRojo    = Color.FromArgb(239, 68, 68);
        private static readonly Color ColDark    = Color.FromArgb(15, 23, 42);
        private static readonly Color ColGris    = Color.FromArgb(100, 116, 139);

        // ── API pública ──────────────────────────────────────────────────
        public static void Mostrar(string mensaje,
                                   string titulo  = "Aviso",
                                   TipoAviso tipo = TipoAviso.Advertencia,
                                   IWin32Window owner = null)
        {
            using (var f = new FormAviso(mensaje, titulo, tipo))
            {
                if (owner != null) f.ShowDialog(owner);
                else               f.ShowDialog();
            }
        }

        // ── Constructor ──────────────────────────────────────────────────
        private FormAviso(string mensaje, string titulo, TipoAviso tipo)
        {
            Color acento = tipo == TipoAviso.Error        ? ColRojo
                         : tipo == TipoAviso.Advertencia  ? ColAmbar
                         : ColIndigo;

            string icono = tipo == TipoAviso.Error        ? "✕"
                         : tipo == TipoAviso.Advertencia  ? "!"
                         : "i";

            // ── Form ─────────────────────────────────────────────────────
            this.Text             = titulo;
            this.ClientSize       = new Size(370, 140);
            this.FormBorderStyle  = FormBorderStyle.FixedDialog;
            this.MaximizeBox      = false;
            this.MinimizeBox      = false;
            this.ShowIcon         = false;
            this.ShowInTaskbar    = false;
            this.StartPosition    = FormStartPosition.CenterParent;
            this.BackColor        = Color.White;
            this.Font             = new Font("Segoe UI", 9.5F);

            // ── Franja superior ──────────────────────────────────────────
            var stripe = new Panel
            {
                Dock      = DockStyle.Top,
                Height    = 3,
                BackColor = acento
            };

            // ── Círculo ícono ────────────────────────────────────────────
            var pnlIcon = new Panel
            {
                Location  = new Point(20, 22),
                Size      = new Size(32, 32),
                BackColor = Color.Transparent
            };
            pnlIcon.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (var b = new SolidBrush(Color.FromArgb(20, acento.R, acento.G, acento.B)))
                    e.Graphics.FillEllipse(b, 0, 0, 32, 32);
                using (var b = new SolidBrush(acento))
                using (var f2 = new Font("Segoe UI", 11F, FontStyle.Bold))
                {
                    var fmt = new StringFormat
                    {
                        Alignment     = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    e.Graphics.DrawString(icono, f2, b, new RectangleF(0, 0, 32, 32), fmt);
                }
            };

            // ── Mensaje ──────────────────────────────────────────────────
            var lblMensaje = new Label
            {
                Text      = mensaje,
                Location  = new Point(62, 18),
                Size      = new Size(290, 64),
                Font      = new Font("Segoe UI", 9.5F),
                ForeColor = ColDark,
                AutoSize  = false
            };

            // ── Separador ────────────────────────────────────────────────
            var sep = new Panel
            {
                Location  = new Point(0, 96),
                Size      = new Size(370, 1),
                BackColor = Color.FromArgb(226, 232, 240)
            };

            // ── Botón Aceptar ────────────────────────────────────────────
            var btnOk = new Button
            {
                Text      = "Aceptar",
                Location  = new Point(262, 106),
                Size      = new Size(88, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = acento,
                ForeColor = Color.White,
                Font      = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor    = Cursors.Hand,
                DialogResult = DialogResult.OK
            };
            btnOk.FlatAppearance.BorderSize = 0;

            this.Controls.AddRange(new Control[] { stripe, pnlIcon, lblMensaje, sep, btnOk });
            this.AcceptButton = btnOk;
        }
    }
}
