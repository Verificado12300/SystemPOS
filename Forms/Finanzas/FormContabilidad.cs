using System.Windows.Forms;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormContabilidad : Form
    {
        private Form _subFormActivo;

        public FormContabilidad()
        {
            InitializeComponent();
            CargarSubFormulario(new Reportes.FormEstadoResultados());
        }

        private void CargarSubFormulario(Form form)
        {
            if (_subFormActivo != null)
            {
                _subFormActivo.Close();
                panelContenidoContabilidad.Controls.Clear();
            }

            _subFormActivo = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContenidoContabilidad.Controls.Add(form);
            form.Show();
        }

        private void BtnEstadoResultados_Click(object sender, System.EventArgs e)
        {
            CargarSubFormulario(new Reportes.FormEstadoResultados());
        }

        private void BtnFlujoCaja_Click(object sender, System.EventArgs e)
        {
            CargarSubFormulario(new Reportes.FormFlujoCaja());
        }

        private void BtnBalanceGeneral_Click(object sender, System.EventArgs e)
        {
            CargarSubFormulario(new Reportes.FormBalanceGeneral());
        }

        private void BtnAsientos_Click(object sender, System.EventArgs e)
        {
            CargarSubFormulario(new FormAsientosDiario());
        }
    }
}
