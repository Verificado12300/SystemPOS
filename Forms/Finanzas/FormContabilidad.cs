using System.Drawing;
using System.Windows.Forms;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormContabilidad : Form
    {
        private Form _subFormActivo;

        // Paleta de estados de tab
        private static readonly Color _accentBlue  = Color.FromArgb(67,  97,  238);
        private static readonly Color _activeBg    = Color.FromArgb(238, 242, 255);
        private static readonly Color _inactiveFg  = Color.FromArgb(90,  100, 116);

        public FormContabilidad()
        {
            InitializeComponent();
            // Tab 1 ya está activo visualmente por el Designer; sincronizar lógica
            CargarSubFormulario(new Reportes.FormEstadoResultados());
        }

        // ── Tab state ────────────────────────────────────────────────────────

        private void SetActiveTab(Button activeBtn)
        {
            (Button btn, Panel indicator, Panel container)[] tabs =
            {
                (btnEstadoResultados, pnlIndicator1, pnlTab1),
                (btnFlujoCaja,        pnlIndicator2, pnlTab2),
                (btnBalanceGeneral,   pnlIndicator3, pnlTab3),
                (btnAsientos,         pnlIndicator4, pnlTab4),
                (btnPeriodos,         pnlIndicator5, pnlTab5),
            };

            foreach (var (btn, ind, container) in tabs)
            {
                bool active = btn == activeBtn;

                container.BackColor = active ? _activeBg   : Color.White;
                ind.BackColor       = active ? _accentBlue : Color.White;

                btn.ForeColor = active ? _accentBlue : _inactiveFg;
                btn.Font      = active
                    ? new Font("Segoe UI", 9.5F, FontStyle.Bold)
                    : new Font("Segoe UI", 9.5F, FontStyle.Regular);

                btn.FlatAppearance.MouseOverBackColor = active
                    ? Color.FromArgb(224, 230, 255)
                    : Color.FromArgb(245, 247, 250);
            }
        }

        // ── Sub-form loader ───────────────────────────────────────────────────

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

        // ── Click handlers ────────────────────────────────────────────────────

        private void BtnEstadoResultados_Click(object sender, System.EventArgs e)
        {
            SetActiveTab(btnEstadoResultados);
            CargarSubFormulario(new Reportes.FormEstadoResultados());
        }

        private void BtnFlujoCaja_Click(object sender, System.EventArgs e)
        {
            SetActiveTab(btnFlujoCaja);
            CargarSubFormulario(new Reportes.FormFlujoCaja());
        }

        private void BtnBalanceGeneral_Click(object sender, System.EventArgs e)
        {
            SetActiveTab(btnBalanceGeneral);
            CargarSubFormulario(new Reportes.FormBalanceGeneral());
        }

        private void BtnAsientos_Click(object sender, System.EventArgs e)
        {
            SetActiveTab(btnAsientos);
            CargarSubFormulario(new FormAsientosDiario());
        }

        private void BtnPeriodos_Click(object sender, System.EventArgs e)
        {
            SetActiveTab(btnPeriodos);
            CargarSubFormulario(new FormPeriodosContables());
        }
    }
}
