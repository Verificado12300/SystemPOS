using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormPeriodosContables : Form
    {
        public FormPeriodosContables()
        {
            InitializeComponent();
            nudAnio.Value = DateTime.Today.Year;
            cmbMes.SelectedIndex = DateTime.Today.Month - 1;
            CargarPeriodos();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            int year  = (int)nudAnio.Value;
            int month = cmbMes.SelectedIndex + 1;
            string mes = cmbMes.SelectedItem?.ToString() ?? "";

            var confirm = MessageBox.Show(
                $"¿Cerrar el período {mes} {year}?\n\n" +
                "Una vez cerrado, no se podrán registrar ni anular operaciones " +
                "contables con fecha dentro de este período.",
                "Confirmar cierre de período",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                string usuarioId = SesionActual.Usuario?.NombreUsuario ?? "SISTEMA";
                using (var conn = DatabaseConnection.GetConnection())
                    PeriodosContablesRepository.CerrarMes(year, month, usuarioId, conn);

                CargarPeriodos();
                lblEstado.Text = $"Período {mes} {year} cerrado correctamente.";
                lblEstado.ForeColor = Color.DarkRed;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cerrar período: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReabrir_Click(object sender, EventArgs e)
        {
            int year  = (int)nudAnio.Value;
            int month = cmbMes.SelectedIndex + 1;
            string mes = cmbMes.SelectedItem?.ToString() ?? "";

            var confirm = MessageBox.Show(
                $"¿Reabrir el período {mes} {year}?\n\n" +
                "Esto permitirá nuevamente registrar y anular operaciones " +
                "contables con fecha dentro de este período.",
                "Confirmar reapertura de período",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                string usuarioId = SesionActual.Usuario?.NombreUsuario ?? "SISTEMA";
                using (var conn = DatabaseConnection.GetConnection())
                    PeriodosContablesRepository.ReabrirMes(year, month, usuarioId, conn);

                CargarPeriodos();
                lblEstado.Text = $"Período {mes} {year} reabierto.";
                lblEstado.ForeColor = Color.DarkGreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reabrir período: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGenerarCierre_Click(object sender, EventArgs e)
        {
            int    year  = (int)nudAnio.Value;
            int    month = cmbMes.SelectedIndex + 1;
            string mes   = cmbMes.SelectedItem?.ToString() ?? "";
            string doc   = $"CIERRE {year:D4}-{month:D2}";

            var confirm = MessageBox.Show(
                $"¿Generar asiento de cierre para {mes} {year}?\n\n" +
                $"Documento: {doc}\n" +
                "Cierra cuentas 400*/500*/600* contra 390 Utilidad del Ejercicio.\n\n" +
                "IMPORTANTE: el período debe estar ABIERTO.\n" +
                "Genera este asiento ANTES de cerrar el período.",
                "Confirmar asiento de cierre",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                int usuarioID = SesionActual.Usuario?.UsuarioID ?? 1;

                using (var conn = DatabaseConnection.GetConnection())
                {
                    using (var tx = conn.BeginTransaction())
                    {
                        try
                        {
                            ContabilidadService.GenerarAsientoCierreMensual(
                                year, month, usuarioID, conn, tx);
                            tx.Commit();
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }

                lblEstado.Text = $"Asiento de cierre {doc} generado correctamente.";
                lblEstado.ForeColor = Color.DarkGreen;
                CargarPeriodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo generar el asiento de cierre:\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblEstado.Text = $"Error: {ex.Message}";
                lblEstado.ForeColor = Color.Red;
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarPeriodos();
        }

        private void CargarPeriodos()
        {
            try
            {
                dgvPeriodos.DataSource = null;
                var lista = PeriodosContablesRepository.ObtenerTodos();
                dgvPeriodos.DataSource = lista;

                // Ajustar columnas visibles y headers
                if (dgvPeriodos.Columns.Count > 0)
                {
                    if (dgvPeriodos.Columns.Contains("PeriodoId"))   dgvPeriodos.Columns["PeriodoId"].Visible = false;
                    if (dgvPeriodos.Columns.Contains("FechaInicio")) dgvPeriodos.Columns["FechaInicio"].HeaderText = "Inicio";
                    if (dgvPeriodos.Columns.Contains("FechaFin"))    dgvPeriodos.Columns["FechaFin"].HeaderText = "Fin";
                    if (dgvPeriodos.Columns.Contains("Cerrado"))     dgvPeriodos.Columns["Cerrado"].Visible = false;
                    if (dgvPeriodos.Columns.Contains("CerradoEn"))   dgvPeriodos.Columns["CerradoEn"].HeaderText = "Fecha acción";
                    if (dgvPeriodos.Columns.Contains("CerradoPor"))  dgvPeriodos.Columns["CerradoPor"].HeaderText = "Usuario";
                    if (dgvPeriodos.Columns.Contains("Descripcion")) dgvPeriodos.Columns["Descripcion"].HeaderText = "Período";
                    if (dgvPeriodos.Columns.Contains("Estado"))      dgvPeriodos.Columns["Estado"].HeaderText = "Estado";

                    // Colorear filas según estado
                    foreach (DataGridViewRow row in dgvPeriodos.Rows)
                    {
                        if (row.DataBoundItem is SistemaPOS.Models.PeriodoContable p)
                        {
                            row.DefaultCellStyle.ForeColor = p.Cerrado
                                ? Color.DarkRed
                                : Color.DarkGreen;
                        }
                    }
                }

                lblEstado.Text = $"{lista.Count} período(s) registrados.";
                lblEstado.ForeColor = SystemColors.ControlText;
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"Error al cargar: {ex.Message}";
                lblEstado.ForeColor = Color.Red;
            }
        }
    }
}
