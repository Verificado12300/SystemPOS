using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaPOS.Data;

namespace SistemaPOS.Forms.Configuracion
{
    public partial class FormLimpiarSistema : Form
    {
        private List<CheckBox> _checkboxes;

        public FormLimpiarSistema()
        {
            InitializeComponent();
            _checkboxes = new List<CheckBox>
            {
                chkVentas, chkCompras, chkGastos, chkCaja,
                chkContabilidad, chkConfiguraciones,
                chkCxC, chkCxP, chkProductos, chkClientes, chkProveedores
            };
        }

        private void BtnSelTodo_Click(object sender, EventArgs e) =>
            _checkboxes.ForEach(c => c.Checked = true);

        private void BtnDesel_Click(object sender, EventArgs e) =>
            _checkboxes.ForEach(c => c.Checked = false);

        private void BtnCerrar_Click(object sender, EventArgs e) => Close();

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            var seleccionados = new List<string>();
            var etiquetas     = new List<string>();

            foreach (var chk in _checkboxes)
            {
                if (chk.Checked)
                {
                    seleccionados.Add((string)chk.Tag);
                    etiquetas.Add("  •  " + chk.Text.TrimStart());
                }
            }

            if (seleccionados.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un módulo para limpiar.",
                    "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string listaTexto = string.Join("\n", etiquetas);
            var resp1 = MessageBox.Show(
                "⚠  ADVERTENCIA — Esta acción es IRREVERSIBLE.\n\n" +
                "Se eliminarán todos los registros de:\n" + listaTexto + "\n\n" +
                "¿Está completamente seguro de continuar?",
                "Confirmar limpieza",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (resp1 != DialogResult.Yes) return;

            var resp2 = MessageBox.Show(
                "Segunda confirmación requerida.\n\n" +
                "Una vez eliminados, los datos NO pueden recuperarse.\n\n" +
                "¿Confirma la eliminación permanente?",
                "Segunda confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (resp2 != DialogResult.Yes) return;

            btnLimpiar.Enabled = false;
            try
            {
                int filas = LimpiarSistemaService.Limpiar(seleccionados);
                MessageBox.Show(
                    $"✓  Limpieza completada.\n\n" +
                    $"Módulos procesados: {seleccionados.Count}\n" +
                    $"Registros eliminados: {filas}",
                    "Limpieza exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                _checkboxes.ForEach(c => c.Checked = false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante la limpieza:\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLimpiar.Enabled = true;
            }
        }
    }
}
