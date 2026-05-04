using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Reports.DataSources;
using SistemaPOS.Utils;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormMoneteo : Form
    {
        private readonly int _cajaID;
        public decimal TotalMoneteo { get; private set; }

        // Denominaciones peruanas: billetes y monedas
        private static readonly decimal[] Denominaciones =
        {
            200m, 100m, 50m, 20m, 10m,       // billetes
            5m, 2m, 1m, 0.50m, 0.20m, 0.10m  // monedas
        };

        // Controles generados dinámicamente por fila
        private NumericUpDown[] _numCantidades;
        private Label[]         _lblSubtotales;

        public FormMoneteo() { InitializeComponent(); }

        public FormMoneteo(int cajaID)
        {
            InitializeComponent();
            _cajaID = cajaID;
            CrearFilasDenominaciones();
            CargarMoneteoExistente();
        }

        private void CrearFilasDenominaciones()
        {
            int n = Denominaciones.Length;
            _numCantidades = new NumericUpDown[n];
            _lblSubtotales = new Label[n];

            int y = 10;

            // Encabezados de columna
            var hDen  = new Label { Text = "Denominación",  Font = new Font("Segoe UI", 8.5f, FontStyle.Bold), ForeColor = Color.FromArgb(99, 110, 114), Location = new Point(14, y), AutoSize = true };
            var hCant = new Label { Text = "Cantidad",       Font = new Font("Segoe UI", 8.5f, FontStyle.Bold), ForeColor = Color.FromArgb(99, 110, 114), Location = new Point(160, y), AutoSize = true };
            var hSub  = new Label { Text = "Subtotal",       Font = new Font("Segoe UI", 8.5f, FontStyle.Bold), ForeColor = Color.FromArgb(99, 110, 114), Location = new Point(270, y), AutoSize = true };
            pnlGrid.Controls.Add(hDen);
            pnlGrid.Controls.Add(hCant);
            pnlGrid.Controls.Add(hSub);
            y += 24;

            // Separador visual entre billetes y monedas
            bool separadorAgregado = false;

            for (int i = 0; i < n; i++)
            {
                // Separador antes de las monedas (denominación < 10)
                if (!separadorAgregado && Denominaciones[i] < 10m)
                {
                    var sep = new Label
                    {
                        AutoSize = false,
                        BackColor = Color.FromArgb(223, 228, 234),
                        Location = new Point(14, y),
                        Size = new Size(340, 1)
                    };
                    var lblMonedas = new Label
                    {
                        Text = "MONEDAS",
                        Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                        ForeColor = Color.FromArgb(99, 110, 114),
                        AutoSize = true,
                        Location = new Point(14, y + 4)
                    };
                    pnlGrid.Controls.Add(sep);
                    pnlGrid.Controls.Add(lblMonedas);
                    y += 20;
                    separadorAgregado = true;
                }
                else if (i == 0)
                {
                    var lblBilletes = new Label
                    {
                        Text = "BILLETES",
                        Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                        ForeColor = Color.FromArgb(99, 110, 114),
                        AutoSize = true,
                        Location = new Point(14, y)
                    };
                    pnlGrid.Controls.Add(lblBilletes);
                    y += 18;
                }

                decimal den = Denominaciones[i];

                var lblDen = new Label
                {
                    Text = $"S/ {den:N2}",
                    Font = new Font("Segoe UI", 9.5f),
                    ForeColor = Color.FromArgb(45, 52, 54),
                    Location = new Point(14, y + 3),
                    AutoSize = true
                };

                var num = new NumericUpDown
                {
                    Location = new Point(155, y),
                    Size = new Size(90, 24),
                    Font = new Font("Segoe UI", 9.5f),
                    Minimum = 0,
                    Maximum = 9999,
                    Value = 0,
                    TextAlign = HorizontalAlignment.Center,
                    Tag = i
                };
                num.ValueChanged += Num_ValueChanged;

                var lblSub = new Label
                {
                    Text = "S/ 0.00",
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(45, 52, 54),
                    Location = new Point(262, y + 3),
                    AutoSize = true
                };

                pnlGrid.Controls.Add(lblDen);
                pnlGrid.Controls.Add(num);
                pnlGrid.Controls.Add(lblSub);

                _numCantidades[i] = num;
                _lblSubtotales[i] = lblSub;

                y += 30;
            }
        }

        private void Num_ValueChanged(object sender, EventArgs e)
        {
            int idx = (int)((NumericUpDown)sender).Tag;
            decimal sub = _numCantidades[idx].Value * Denominaciones[idx];
            _lblSubtotales[idx].Text = $"S/ {sub:N2}";
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            decimal total = 0;
            for (int i = 0; i < Denominaciones.Length; i++)
                total += _numCantidades[i].Value * Denominaciones[i];

            TotalMoneteo = total;
            lblTotal.Text = $"S/ {total:N2}";
        }

        private void CargarMoneteoExistente()
        {
            try
            {
                var guardado = CajaRepository.ObtenerMoneteo(_cajaID);
                foreach (var d in guardado)
                {
                    for (int i = 0; i < Denominaciones.Length; i++)
                    {
                        if (Denominaciones[i] == d.Denominacion)
                        {
                            _numCantidades[i].Value = d.Cantidad;
                            break;
                        }
                    }
                }
            }
            catch { /* Si no hay moneteo previo, ignorar */ }
        }

        private void BtnUsarEfectivoReal_Click(object sender, EventArgs e)
        {
            GuardarMoneteo();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            GuardarMoneteo();
            MessageBox.Show($"Moneteo guardado.\nTotal: S/ {TotalMoneteo:N2}", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = System.Windows.Forms.DialogResult.No; // guardado sin usar
            this.Close();
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                // Guardar primero para que los datos estén en BD
                GuardarMoneteo();

                var parametros = ReportHelper.GetCompanyParameters();
                parametros["pEncargado"] = UsuarioRepository.ObtenerNombreCompletoPorID(SesionActual.Usuario.UsuarioID);
                parametros["pFecha"]     = DateTime.Today.ToString("dd/MM/yyyy");
                parametros["pHora"]      = DateTime.Now.ToString(@"hh\:mm\:ss");

                var dataSources = new Dictionary<string, DataTable>
                {
                    ["DsMoneteoCaja"] = ReportDataSourceHelper.ObtenerDatosMoneteo(_cajaID)
                };

                ReportHelper.MostrarDialogoExportacion(
                    ReportHelper.GetRdlcPath(@"Documents\RptMoneteo.rdlc"),
                    dataSources, parametros, "moneteo_caja");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarMoneteo()
        {
            var detalles = new List<CajaMoneteoDetalle>();
            for (int i = 0; i < Denominaciones.Length; i++)
            {
                if (_numCantidades[i].Value > 0)
                {
                    detalles.Add(new CajaMoneteoDetalle
                    {
                        Denominacion = Denominaciones[i],
                        Cantidad     = (int)_numCantidades[i].Value,
                        Subtotal     = _numCantidades[i].Value * Denominaciones[i]
                    });
                }
            }
            CajaRepository.RegistrarMoneteo(_cajaID, detalles);
        }
    }
}
