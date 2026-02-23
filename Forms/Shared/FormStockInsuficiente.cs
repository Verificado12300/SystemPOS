using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaPOS.Forms.Shared
{
    public partial class FormStockInsuficiente : Form
    {
        // ── Paleta de colores ────────────────────────────────────────────────
        private static readonly Color ColorBorde = Color.FromArgb(243, 156, 18);

        // ── Constructor ──────────────────────────────────────────────────────
        private FormStockInsuficiente(
            string  productoNombre,
            decimal stockDisponible,
            decimal cantidadSolicitada)
        {
            InitializeComponent();

            lblProdValor.Text   = productoNombre ?? string.Empty;
            lblStockValor.Text  = stockDisponible.ToString("N2");
            lblSolValor.Text    = cantidadSolicitada.ToString("N2");

            KeyDown += (_, e) =>
            {
                if (e.KeyCode == Keys.Escape) Close();
            };
        }

        // ── Borde personalizado ───────────────────────────────────────────────
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var pen = new Pen(ColorBorde, 1))
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        }

        // ── API pública ───────────────────────────────────────────────────────

        /// <summary>
        /// Muestra el diálogo de stock insuficiente de forma modal.
        /// </summary>
        /// <param name="owner">Ventana padre (puede ser null).</param>
        /// <param name="productoNombre">Nombre del producto.</param>
        /// <param name="stockDisponible">Stock disponible en el sistema.</param>
        /// <param name="cantidadSolicitada">Cantidad que se intentó operar.</param>
        public static void Mostrar(
            IWin32Window owner,
            string       productoNombre,
            decimal      stockDisponible,
            decimal      cantidadSolicitada)
        {
            using (var dlg = new FormStockInsuficiente(productoNombre, stockDisponible, cantidadSolicitada))
            {
                if (owner != null)
                    dlg.ShowDialog(owner);
                else
                    dlg.ShowDialog();
            }
        }
    }
}
