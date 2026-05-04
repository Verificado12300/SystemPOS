using System.Drawing;
using System.Windows.Forms;

namespace SistemaPOS.Utils
{
    /// <summary>
    /// Aplica el estilo visual unificado (referencia: FormHistorialCompras) a cualquier DataGridView.
    /// Llamar después de InitializeComponent(), antes de cargar datos.
    /// </summary>
    public static class DgvStyleHelper
    {
        private static readonly Color ColorHover  = Color.FromArgb(235, 240, 255);
        private static readonly Color ColorNormal = Color.Empty; // vacío → deja ver AlternatingRows

        public static void Aplicar(DataGridView dgv)
        {
            if (dgv == null) return;

            // ── Estructura ────────────────────────────────────────────────────
            dgv.BorderStyle              = BorderStyle.None;
            dgv.BackgroundColor          = Color.White;
            dgv.GridColor                = Color.FromArgb(235, 237, 240);
            dgv.CellBorderStyle          = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.RowHeadersVisible        = false;
            dgv.RowTemplate.Height       = 44;
            dgv.SelectionMode            = DataGridViewSelectionMode.FullRowSelect;
            dgv.EnableHeadersVisualStyles = false;

            // ── Celdas ───────────────────────────────────────────────────────
            dgv.Font                                = new Font("Segoe UI", 9.5F);
            dgv.DefaultCellStyle.Font               = new Font("Segoe UI", 9.5F);
            dgv.DefaultCellStyle.ForeColor          = Color.FromArgb(45, 52, 54);
            dgv.DefaultCellStyle.Padding            = new Padding(8, 0, 4, 0);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 240, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(45, 52, 54);

            dgv.AlternatingRowsDefaultCellStyle.BackColor          = Color.FromArgb(248, 250, 253);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 250, 253);

            // ── Encabezado ───────────────────────────────────────────────────
            dgv.ColumnHeadersHeight         = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 36, 40);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(200, 210, 215);
            dgv.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding   = new Padding(8, 0, 4, 0);

            // ── Sincronizar alineación header ↔ datos ────────────────────────
            // Si una columna tiene alineación explícita en DefaultCellStyle,
            // se aplica la misma al header para que queden alineados.
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                var align = col.DefaultCellStyle.Alignment;
                if (align != DataGridViewContentAlignment.NotSet)
                    col.HeaderCell.Style.Alignment = align;
            }

            // ── DataError silencioso ─────────────────────────────────────────
            dgv.DataError += (s, e) => { e.ThrowException = false; };

            // ── Hover / selección visual ─────────────────────────────────────
            dgv.RowPrePaint += (s, e) =>
            {
                e.PaintParts &= ~DataGridViewPaintParts.SelectionBackground;
            };

            int filaHover = -1;

            dgv.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                filaHover = e.RowIndex;
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = ColorHover;
            };

            dgv.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = ColorNormal;
                filaHover = -1;
            };

            dgv.Leave += (s, e) =>
            {
                dgv.ClearSelection();
                foreach (DataGridViewRow row in dgv.Rows)
                    row.DefaultCellStyle.BackColor = ColorNormal;
            };
        }
    }
}
