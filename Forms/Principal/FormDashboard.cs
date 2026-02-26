using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SistemaPOS.Controls;
using SistemaPOS.Data;
using SistemaPOS.Models;

namespace SistemaPOS.Forms.Principal
{
    public partial class FormDashboard : Form
    {
        private Timer timerRefresh;
        private int periodoActual = 0; // 0=dia, 1=semana, 2=mes

        private readonly Color colorTextoActivo = Color.FromArgb(52, 73, 94);
        private readonly Color colorTextoInactivo = Color.FromArgb(127, 140, 141);

        // Tooltip custom moderno
        private Panel pnlTooltip;
        private Label lblTooltipEtiqueta;
        private Label lblTooltipValor;
        private int lastTooltipIndex = -1;

        public FormDashboard()
        {
            InitializeComponent();
            ConfigurarChart();
            ConfigurarBotonesToggle();
            // Layout se controla desde el Designer con Anchors
        }

        private void ConfigurarBotonesToggle()
        {
            btnDia.Click += (s, e) => SeleccionarPeriodo(0);
            btnSemana.Click += (s, e) => SeleccionarPeriodo(1);
            btnMes.Click += (s, e) => SeleccionarPeriodo(2);
        }

        private void SeleccionarPeriodo(int periodo)
        {
            periodoActual = periodo;
            ActualizarEstadoBotones();
            CargarTodo();
        }

        private void ActualizarEstadoBotones()
        {
            Button[] botones = { btnDia, btnSemana, btnMes };

            for (int i = 0; i < botones.Length; i++)
            {
                if (i == periodoActual)
                {
                    botones[i].BackColor = Color.White;
                    botones[i].ForeColor = colorTextoActivo;
                    botones[i].Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else
                {
                    botones[i].BackColor = Color.FromArgb(233, 236, 244);
                    botones[i].ForeColor = colorTextoInactivo;
                    botones[i].Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                }
            }
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                ActualizarEstadoBotones();
                CargarTodo();
                timerRefresh = new Timer();
                timerRefresh.Interval = 60000;
                timerRefresh.Tick += (s, ev) => CargarTodo();
                timerRefresh.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar dashboard: {ex.Message}\n\n{ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerPeriodo()
        {
            switch (periodoActual)
            {
                case 1: return "semana";
                case 2: return "mes";
                default: return "dia";
            }
        }

        private string ObtenerTituloPeriodo()
        {
            switch (periodoActual)
            {
                case 1: return "DE LA SEMANA";
                case 2: return "DEL MES";
                default: return "DEL DIA";
            }
        }

        private (DateTime desde, DateTime hasta) ObtenerRangoDates(string periodo)
        {
            DateTime hoy = DateTime.Today;
            switch (periodo)
            {
                case "semana":
                    int diasDesdelunes = ((int)hoy.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
                    return (hoy.AddDays(-diasDesdelunes), hoy.AddDays(6 - diasDesdelunes));
                case "mes":
                    return (new DateTime(hoy.Year, hoy.Month, 1),
                            new DateTime(hoy.Year, hoy.Month,
                                         DateTime.DaysInMonth(hoy.Year, hoy.Month)));
                default: // "dia"
                    return (hoy, hoy);
            }
        }

        private void CargarTodo()
        {
            try
            {
                string periodo = ObtenerPeriodo();
                string tituloPeriodo = ObtenerTituloPeriodo();

                switch (periodoActual)
                {
                    case 1: lblGraficoTitulo.Text = "VENTAS DE LA SEMANA"; break;
                    case 2: lblGraficoTitulo.Text = "VENTAS DEL MES"; break;
                    default: lblGraficoTitulo.Text = "VENTAS DE HOY"; break;
                }
                lblTopTitulo.Text = $"TOP PRODUCTOS {tituloPeriodo}";
                lblOperacionesTitulo.Text = $"OPERACIONES {tituloPeriodo}";

                var (desde, hasta) = ObtenerRangoDates(periodo);
                var er = ContabilidadService.ObtenerEstadoResultados(desde, hasta);

                CargarKPIVentas(periodo, er);
                CargarKPIUtilidad(er);
                CargarKPIAlertas();
                CargarGrafico(periodo);
                CargarTopProductos(periodo);
                CargarOperacionesRecientes();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error Dashboard: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"Error al cargar datos del dashboard:\n{ex.Message}",
                    "Error Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarKPIVentas(string periodo, EstadoResultadosDTO er)
        {
            var (_, cantidad) = DashboardRepository.ObtenerVentasPorPeriodo(periodo);
            lblKPIVentasTitulo.Text = $"VENTAS {ObtenerTituloPeriodo()}";
            lblKPIVentasValor.Text  = $"S/ {er.Ventas:N2}";
            lblKPIVentasCant.Text   = $"{cantidad} operaciones";
        }

        private void CargarKPIUtilidad(EstadoResultadosDTO er)
        {
            decimal margen = er.Ventas > 0
                ? er.UtilidadOperativa / er.Ventas * 100m
                : 0m;
            lblKPIUtilidadTitulo.Text     = $"UTILIDAD {ObtenerTituloPeriodo()}";
            lblKPIUtilidadValor.Text      = $"S/ {er.UtilidadOperativa:N2}";
            lblKPIUtilidadPorcentaje.Text = $"Margen: {margen:N1}%";
            lblKPIUtilidadValor.ForeColor = er.UtilidadOperativa >= 0
                ? Color.FromArgb(39, 174, 96)
                : Color.FromArgb(231, 76, 60);
        }

        private void CargarKPIAlertas()
        {
            int alertas = DashboardRepository.ObtenerProductosBajoStock();
            lblKPIAlertasValor.Text = alertas.ToString();
            lblKPIAlertasDetalle.Text = alertas == 1
                ? "producto bajo stock minimo"
                : "productos bajo stock minimo";
        }

        private void ConfigurarChart()
        {
            chartVentas.ChartAreas.Clear();
            chartVentas.Series.Clear();
            chartVentas.Legends.Clear();
            chartVentas.BackColor = Color.White;
            chartVentas.BorderSkin.SkinStyle = BorderSkinStyle.None;

            // Bloquear seleccion y foco del chart (evita el margen/borde al hacer click)
            chartVentas.TabStop = false;
            chartVentas.MouseDown += (s, e) => { pnlGrafico.Focus(); };

            var area = new ChartArea("Main");
            area.BackColor = Color.White;

            // Deshabilitar seleccion al hacer click (quita el borde azul)
            area.CursorX.IsUserEnabled = false;
            area.CursorX.IsUserSelectionEnabled = false;
            area.CursorY.IsUserEnabled = false;
            area.CursorY.IsUserSelectionEnabled = false;

            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.MinorGrid.Enabled = false;
            area.AxisX.LineColor = Color.FromArgb(230, 230, 235);
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8F);
            area.AxisX.LabelStyle.ForeColor = Color.FromArgb(160, 160, 170);
            area.AxisX.MajorTickMark.Enabled = false;
            area.AxisX.IsMarginVisible = true;

            area.AxisY.MajorGrid.LineColor = Color.FromArgb(240, 240, 245);
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            area.AxisY.MinorGrid.Enabled = false;
            area.AxisY.LineColor = Color.Transparent;
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8F);
            area.AxisY.LabelStyle.ForeColor = Color.FromArgb(160, 160, 170);
            area.AxisY.LabelStyle.Format = "S/ #,##0";
            area.AxisY.MajorTickMark.Enabled = false;
            area.AxisY.Minimum = 0;

            area.BorderColor = Color.Transparent;
            area.BorderWidth = 0;
            area.InnerPlotPosition = new ElementPosition(8, 5, 90, 85);

            chartVentas.ChartAreas.Add(area);

            var seriesArea = new Series("VentasArea");
            seriesArea.ChartType = SeriesChartType.SplineArea;
            seriesArea.Color = Color.FromArgb(40, 52, 152, 219);
            seriesArea.BorderColor = Color.FromArgb(52, 152, 219);
            seriesArea.BorderWidth = 3;
            seriesArea.MarkerStyle = MarkerStyle.Circle;
            seriesArea.MarkerSize = 7;
            seriesArea.MarkerColor = Color.White;
            seriesArea.MarkerBorderColor = Color.FromArgb(52, 152, 219);
            seriesArea.MarkerBorderWidth = 2;
            seriesArea.BackGradientStyle = GradientStyle.TopBottom;
            seriesArea.BackSecondaryColor = Color.FromArgb(5, 52, 152, 219);
            chartVentas.Series.Add(seriesArea);

            // Tooltip custom moderno (reemplaza el nativo)
            CrearTooltipCustom();
            chartVentas.MouseMove += ChartVentas_MouseMove;
            chartVentas.MouseLeave += (s, e) => OcultarTooltip();

            MostrarGraficoVacio();
        }

        private void CrearTooltipCustom()
        {
            pnlTooltip = new Panel
            {
                Size = new Size(160, 58),
                BackColor = Color.FromArgb(30, 39, 56),
                Visible = false,
                Padding = new Padding(12, 8, 12, 8)
            };
            pnlTooltip.Paint += (s, e) =>
            {
                // Fondo con bordes redondeados
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(0, 0, pnlTooltip.Width - 1, pnlTooltip.Height - 1);
                using (var path = new GraphicsPath())
                {
                    int r = 10;
                    path.AddArc(rect.X, rect.Y, r, r, 180, 90);
                    path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
                    path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
                    path.CloseFigure();
                    using (var brush = new SolidBrush(Color.FromArgb(30, 39, 56)))
                        g.FillPath(brush, path);
                }
            };

            lblTooltipEtiqueta = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(160, 180, 210),
                BackColor = Color.Transparent,
                Location = new Point(12, 8)
            };

            lblTooltipValor = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 200, 255),
                BackColor = Color.Transparent,
                Location = new Point(12, 28)
            };

            pnlTooltip.Controls.Add(lblTooltipEtiqueta);
            pnlTooltip.Controls.Add(lblTooltipValor);

            // Hacer transparente el fondo del panel (solo se pinta lo redondeado)
            pnlTooltip.Region = null;

            chartVentas.Controls.Add(pnlTooltip);
            pnlTooltip.BringToFront();
        }

        private void ChartVentas_MouseMove(object sender, MouseEventArgs e)
        {
            var hit = chartVentas.HitTest(e.X, e.Y);

            if (hit.ChartElementType == ChartElementType.DataPoint && hit.PointIndex >= 0)
            {
                int index = hit.PointIndex;
                var point = chartVentas.Series["VentasArea"].Points[index];

                // Solo actualizar si cambio el punto
                if (index != lastTooltipIndex)
                {
                    lastTooltipIndex = index;
                    string etiqueta = point.AxisLabel;
                    decimal valor = (decimal)point.YValues[0];

                    lblTooltipEtiqueta.Text = etiqueta;
                    lblTooltipValor.Text = $"S/ {valor:N2}";

                    // Ajustar tamanio del tooltip al contenido
                    int anchoTexto = Math.Max(
                        TextRenderer.MeasureText(lblTooltipEtiqueta.Text, lblTooltipEtiqueta.Font).Width,
                        TextRenderer.MeasureText(lblTooltipValor.Text, lblTooltipValor.Font).Width
                    );
                    pnlTooltip.Width = anchoTexto + 28;

                    // Resaltar punto activo
                    for (int i = 0; i < chartVentas.Series["VentasArea"].Points.Count; i++)
                    {
                        var p = chartVentas.Series["VentasArea"].Points[i];
                        if (p.MarkerStyle == MarkerStyle.None) continue;
                        if (i == index)
                        {
                            p.MarkerSize = 10;
                            p.MarkerBorderWidth = 3;
                            p.MarkerColor = Color.FromArgb(52, 152, 219);
                            p.MarkerBorderColor = Color.White;
                        }
                        else
                        {
                            p.MarkerSize = 7;
                            p.MarkerBorderWidth = 2;
                            p.MarkerColor = Color.White;
                            p.MarkerBorderColor = Color.FromArgb(52, 152, 219);
                        }
                    }
                }

                // Posicionar tooltip cerca del cursor, arriba y centrado
                int tooltipX = e.X - (pnlTooltip.Width / 2);
                int tooltipY = e.Y - pnlTooltip.Height - 15;

                // Mantener dentro de los limites del chart
                if (tooltipX < 0) tooltipX = 0;
                if (tooltipX + pnlTooltip.Width > chartVentas.Width)
                    tooltipX = chartVentas.Width - pnlTooltip.Width;
                if (tooltipY < 0) tooltipY = e.Y + 20;

                pnlTooltip.Location = new Point(tooltipX, tooltipY);
                pnlTooltip.Visible = true;
            }
            else
            {
                OcultarTooltip();
            }
        }

        private void OcultarTooltip()
        {
            if (pnlTooltip != null && pnlTooltip.Visible)
            {
                pnlTooltip.Visible = false;
                lastTooltipIndex = -1;

                // Restaurar marcadores a su estado normal
                foreach (var p in chartVentas.Series["VentasArea"].Points)
                {
                    if (p.MarkerStyle == MarkerStyle.None) continue;
                    p.MarkerSize = 7;
                    p.MarkerBorderWidth = 2;
                    p.MarkerColor = Color.White;
                    p.MarkerBorderColor = Color.FromArgb(52, 152, 219);
                }
            }
        }

        private void MostrarGraficoVacio()
        {
            var series = chartVentas.Series["VentasArea"];
            series.Points.Clear();

            var area = chartVentas.ChartAreas["Main"];
            area.AxisY.Maximum = 100;
            area.AxisY.Interval = 25;
            area.AxisX.Interval = 1;

            string[] etiquetas;
            switch (periodoActual)
            {
                case 1:
                    etiquetas = new[] { "Lun", "Mar", "Mie", "Jue", "Vie", "Sab", "Dom" };
                    break;
                case 2:
                    etiquetas = new[] { "Sem 1", "Sem 2", "Sem 3", "Sem 4" };
                    break;
                default:
                    etiquetas = new[] { "00-06", "06-10", "10-14", "14-18", "18-22", "22-24" };
                    break;
            }

            foreach (var etiqueta in etiquetas)
            {
                var point = series.Points.Add(0);
                point.AxisLabel = etiqueta;
                point.MarkerStyle = MarkerStyle.None;
            }
        }

        private void CargarGrafico(string periodo)
        {
            var datos = DashboardRepository.ObtenerTendenciaVentas(periodo);
            var series = chartVentas.Series["VentasArea"];
            series.Points.Clear();

            var area = chartVentas.ChartAreas["Main"];

            if (datos.Count == 0)
            {
                MostrarGraficoVacio();
                return;
            }

            // Verificar si todos los valores son 0
            bool todosEnCero = true;
            foreach (var (_, total) in datos)
            {
                if (total > 0) { todosEnCero = false; break; }
            }

            if (todosEnCero)
            {
                area.AxisY.Maximum = 100;
                area.AxisY.Interval = 25;
            }
            else
            {
                area.AxisY.Maximum = double.NaN;
                area.AxisY.Interval = double.NaN;
            }

            // Configurar eje X
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = 0;

            foreach (var (etiqueta, total) in datos)
            {
                var point = series.Points.Add((double)total);
                point.AxisLabel = etiqueta;

                // Solo mostrar marcador en puntos con valor > 0
                if (total == 0)
                    point.MarkerStyle = MarkerStyle.None;
                else
                    point.MarkerStyle = MarkerStyle.Circle;
            }
        }

        private void CargarTopProductos(string periodo)
        {
            pnlTopLista.Controls.Clear();
            var productos = DashboardRepository.ObtenerProductosMasVendidos(periodo, 5);

            if (productos.Count == 0)
            {
                var lblVacio = new Label
                {
                    Text = "Sin ventas en este periodo",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(160, 160, 170),
                    AutoSize = true,
                    Location = new Point(10, 20)
                };
                pnlTopLista.Controls.Add(lblVacio);
                return;
            }

            decimal maxTotal = productos[0].Total;
            int y = 2;

            Color[][] colores = new Color[][]
            {
                new Color[] { Color.FromArgb(52, 152, 219), Color.FromArgb(41, 128, 185) },
                new Color[] { Color.FromArgb(46, 204, 113), Color.FromArgb(39, 174, 96) },
                new Color[] { Color.FromArgb(155, 89, 182), Color.FromArgb(142, 68, 173) },
                new Color[] { Color.FromArgb(243, 156, 18), Color.FromArgb(230, 126, 34) },
                new Color[] { Color.FromArgb(231, 76, 60), Color.FromArgb(192, 57, 43) }
            };

            for (int i = 0; i < productos.Count; i++)
            {
                var (nombre, total, cantidad) = productos[i];

                int anchoDisponible = pnlTopLista.ClientSize.Width - 4;
                int anchoMonto = 110;

                var lblNombre = new Label
                {
                    Text = nombre,
                    Font = new Font("Segoe UI", 8.5F),
                    ForeColor = Color.FromArgb(55, 65, 70),
                    Location = new Point(0, y),
                    Size = new Size(anchoDisponible - anchoMonto, 18),
                    AutoEllipsis = true,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };
                pnlTopLista.Controls.Add(lblNombre);

                var lblMonto = new Label
                {
                    Text = $"S/ {total:N2}",
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(55, 65, 70),
                    TextAlign = ContentAlignment.TopRight,
                    Location = new Point(anchoDisponible - anchoMonto, y),
                    Size = new Size(anchoMonto, 18),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right
                };
                pnlTopLista.Controls.Add(lblMonto);

                y += 20;

                int percent = maxTotal > 0 ? Math.Min(100, (int)((total / maxTotal) * 100)) : 0;
                var pb = new ModernProgressBar
                {
                    Location = new Point(0, y),
                    Size = new Size(anchoDisponible, 8),
                    Minimum = 0,
                    Maximum = 100,
                    Value = percent,
                    BorderRadius = 4,
                    BarColor = colores[i % colores.Length][0],
                    BarColorEnd = colores[i % colores.Length][1],
                    TrackColor = Color.FromArgb(241, 243, 245),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };
                pnlTopLista.Controls.Add(pb);

                y += 12;

                var lblCant = new Label
                {
                    Text = $"{cantidad} unidades vendidas",
                    Font = new Font("Segoe UI", 7.5F),
                    ForeColor = Color.FromArgb(160, 165, 170),
                    Location = new Point(0, y),
                    AutoSize = true
                };
                pnlTopLista.Controls.Add(lblCant);

                y += 22;
            }
        }

        // Layout se maneja 100% desde el Designer usando Anchors nativos de WinForms.
        // No se sobreescribe ninguna posicion ni tamaño por codigo.

        private void CargarOperacionesRecientes()
        {
            dgvOperaciones.Rows.Clear();
            var operaciones = DashboardRepository.ObtenerOperacionesRecientes(20);

            foreach (var (numero, cliente, metodo, monto, fechaHora) in operaciones)
            {
                dgvOperaciones.Rows.Add(numero, cliente, metodo, $"S/ {monto:N2}", fechaHora);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                timerRefresh?.Stop();
                timerRefresh?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
