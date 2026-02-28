using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormPapeleraGlobal : Form
    {
        public FormPapeleraGlobal()
        {
            InitializeComponent();
        }

        private void FormPapeleraGlobal_Load(object sender, EventArgs e)
        {
            try
            {
                dtpDesde.Value = DateTime.Today.AddDays(-30);
                dtpHasta.Value = DateTime.Today;
                cmbEntidad.SelectedIndex = 0;
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar papelera: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos()
        {
            try
            {
                string entFiltro = cmbEntidad.SelectedIndex > 0 ? cmbEntidad.Text : null;
                string busqueda  = txtBuscar.Text.Trim();

                var lista = PapeleraService.ListarPapelera(
                    dtpDesde.Value.Date,
                    dtpHasta.Value.Date,
                    entFiltro,
                    string.IsNullOrEmpty(busqueda) ? null : busqueda);

                dgvPapelera.Rows.Clear();

                foreach (var e in lista)
                {
                    int idx = dgvPapelera.Rows.Add();
                    var row = dgvPapelera.Rows[idx];

                    row.Cells["colEntidad"].Value     = e.Entidad;
                    row.Cells["colId"].Value          = e.EntidadId;
                    row.Cells["colReferencia"].Value  = e.Referencia;
                    row.Cells["colFechaElim"].Value   = e.FechaEliminado != DateTime.MinValue
                        ? e.FechaEliminado.ToString("dd/MM/yyyy HH:mm")
                        : "-";
                    row.Cells["colUsuarioElim"].Value = string.IsNullOrEmpty(e.UsuarioElimino)
                        ? "Sistema"
                        : e.UsuarioElimino;
                    row.Tag = e;
                }

                lblConteo.Text = $"Total: {lista.Count} registro(s) en papelera";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void DgvPapelera_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if (dgvPapelera.Columns[e.ColumnIndex].Name != "colRestaurar") return;

                var entrada = dgvPapelera.Rows[e.RowIndex].Tag as PapeleraEntrada;
                if (entrada == null) return;

                var confirm = MessageBox.Show(
                    $"¿Restaurar {entrada.Entidad} #{entrada.EntidadId}?\n\n" +
                    $"{entrada.Referencia}\n\n" +
                    "El registro volverá a aparecer en su módulo original.",
                    "Confirmar restauración",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                string usuario = SesionActual.Usuario?.NombreUsuario ?? "Sistema";
                PapeleraService.Restaurar(entrada.Entidad, entrada.EntidadId, usuario);

                CargarDatos();

                MessageBox.Show("Registro restaurado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al restaurar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
