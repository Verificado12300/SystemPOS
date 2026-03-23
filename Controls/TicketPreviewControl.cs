using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SistemaPOS.Data;
using SistemaPOS.Models;

namespace SistemaPOS.Controls
{
    /// <summary>
    /// PLANTILLA MAESTRA ÚNICA del ticket de venta.
    /// Hereda de TicketDesignPanel para reutilizar RenderForPrint (celda-a-celda DGV).
    ///
    /// Usuarios:
    ///   - FormPreviewTicket  → LlenarDatos(dt, parametros)
    ///   - FormImpresoras     → LlenarDatosDemo(config)
    ///   - Impresión real     → RenderForPrint(g, dest, h)   (heredado)
    ///   - Historial/reimpres → LlenarDatos(dt, parametros)
    /// </summary>
    public partial class TicketPreviewControl : TicketDesignPanel
    {
        // ── Snapshot posiciones Designer (inmutables) ─────────────────────────
        private readonly Dictionary<Control, int> _designerTop = new Dictionary<Control, int>();
        private int _designerDgvH;

        // ── Configuración centralizada del ticket ─────────────────────────────
        private TicketConfig _config;

        // ── Columnas DGV (creadas en código para evitar conflictos Designer) ──
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colUnidad;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colTotal;

        public TicketPreviewControl()
        {
            InitializeComponent();

            // Capturar posiciones del Designer antes de cualquier reflow
            foreach (Control c in Controls)
                _designerTop[c] = c.Top;
            _designerDgvH = dgvItems.Height;

            ConfigurarColumnasDgv();
        }

        // ═══════════════════════════════════════════════════════════════════════
        // API PÚBLICA
        // ═══════════════════════════════════════════════════════════════════════

        /// <summary>Llena con datos reales de una venta. Si config es null, lee desde BD.</summary>
        public void LlenarDatos(DataTable detalle, Dictionary<string, string> p, TicketConfig config = null)
        {
            _config = config ?? TicketConfig.CargarDesdeDB();
            CompletarEmpresa(p);
            Llenar(detalle, p);
        }

        /// <summary>Llena con datos de demo usando la configuración provista. No lee BD. Para FormImpresoras.</summary>
        public void LlenarDatosDemo(TicketConfig config)
        {
            _config = config;

            var dt = new DataTable();
            dt.Columns.Add("Numero",       typeof(int));
            dt.Columns.Add("Producto",     typeof(string));
            dt.Columns.Add("Presentacion", typeof(string));
            dt.Columns.Add("Cantidad",     typeof(decimal));
            dt.Columns.Add("SubTotal",     typeof(decimal));
            dt.Rows.Add(1, "Crecimiento Pollo", "Saco",   2m,  240.00m);
            dt.Rows.Add(2, "Pienso Engorde",    "Granel", 10m, 280.00m);

            var p = new Dictionary<string, string>
            {
                ["pTipoComprobante"] = "NOTA DE VENTA",
                ["pNumeroVenta"]     = "N001-00000001",
                ["pFecha"]           = DateTime.Now.ToString("dd/MM/yyyy"),
                ["pHora"]            = DateTime.Now.ToString("HH:mm"),
                ["pCliente"]         = "Cliente Demo",
                ["pDocCliente"]      = _config.MostrarDNI ? "12345678" : "",
                ["pSubTotal"]        = "508.47",
                ["pIGV"]             = "91.53",
                ["pTotal"]           = "600.00",
                ["pMetodoPago"]      = "EFECTIVO",
                ["pMontoRecibido"]   = "600.00",
                ["pVuelto"]          = "0.00",
            };
            CompletarEmpresa(p);
            Llenar(dt, p);
        }

        /// <summary>Re-aplica el reflow (útil tras OnShown cuando el DGV ya calculó alturas de fila).</summary>
        public void Reflow() => ReflowTicket();

        /// <summary>Alto del contenido tras el último reflow.</summary>
        public int ContentHeight => Height;

        /// <summary>Ancho lógico del ticket.</summary>
        public int ContentWidth => Width;

        /// <summary>Crea un Bitmap del estado actual (para historial / reimpresión estática).</summary>
        public Bitmap RenderToBitmap()
        {
            int w = Math.Max(1, Width);
            int h = Math.Max(1, Height);
            var bmp = new Bitmap(w, h);
            using (var g = Graphics.FromImage(bmp))
                RenderForPrint(g, new Rectangle(0, 0, w, h), h);
            return bmp;
        }

        // ═══════════════════════════════════════════════════════════════════════
        // PRIVADOS
        // ═══════════════════════════════════════════════════════════════════════

        private void ConfigurarColumnasDgv()
        {
            var estiloIzq = new DataGridViewCellStyle
            {
                BackColor          = Color.White,
                Font               = new Font("Segoe UI", 9F),
                ForeColor          = Color.Black,
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.Black,
                Alignment          = DataGridViewContentAlignment.MiddleLeft,
                WrapMode           = DataGridViewTriState.True
            };
            var estiloDer = new DataGridViewCellStyle
            {
                BackColor          = Color.White,
                Font               = new Font("Segoe UI", 9F),
                ForeColor          = Color.Black,
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.Black,
                Alignment          = DataGridViewContentAlignment.MiddleRight
            };

            // Col 1: Descripción (producto) — peso 122
            colDescripcion = new DataGridViewTextBoxColumn
            {
                AutoSizeMode     = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "Producto",
                DefaultCellStyle = estiloIzq,
                FillWeight       = 122F,
                HeaderText       = "Descripcion",
                MinimumWidth     = 40,
                Name             = "colDescripcion",
                ReadOnly         = true,
                SortMode         = DataGridViewColumnSortMode.NotSortable
            };
            // Col 2: Unid. (presentación) — peso 22
            colUnidad = new DataGridViewTextBoxColumn
            {
                AutoSizeMode     = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "Presentacion",
                DefaultCellStyle = estiloIzq,
                FillWeight       = 22F,
                HeaderText       = "Unid.",
                MinimumWidth     = 20,
                Name             = "colUnidad",
                ReadOnly         = true,
                SortMode         = DataGridViewColumnSortMode.NotSortable
            };
            // Col 3: Cant. — peso 38
            colCantidad = new DataGridViewTextBoxColumn
            {
                AutoSizeMode     = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "Cantidad",
                DefaultCellStyle = estiloDer,
                FillWeight       = 38F,
                HeaderText       = "Cant.",
                MinimumWidth     = 22,
                Name             = "colCantidad",
                ReadOnly         = true,
                SortMode         = DataGridViewColumnSortMode.NotSortable
            };
            // Col 4: Total — peso 75
            colTotal = new DataGridViewTextBoxColumn
            {
                AutoSizeMode     = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "SubTotal",
                DefaultCellStyle = estiloDer,
                FillWeight       = 75F,
                HeaderText       = "Total",
                MinimumWidth     = 70,
                Name             = "colTotal",
                ReadOnly         = true,
                SortMode         = DataGridViewColumnSortMode.NotSortable
            };

            dgvItems.AutoGenerateColumns = false;
            dgvItems.AutoSizeRowsMode    = DataGridViewAutoSizeRowsMode.AllCells;
            dgvItems.Columns.AddRange(new DataGridViewColumn[]
            {
                colDescripcion, colUnidad, colCantidad, colTotal
            });
        }

        // ── Completar parámetros de empresa desde BD si faltan ────────────────
        private static void CompletarEmpresa(Dictionary<string, string> p)
        {
            if (p == null) return;
            bool fN = !p.ContainsKey("pEmpresaNombre")   || string.IsNullOrWhiteSpace(p["pEmpresaNombre"]);
            bool fR = !p.ContainsKey("pEmpresaRUC");
            bool fD = !p.ContainsKey("pEmpresaDireccion");
            bool fT = !p.ContainsKey("pEmpresaTelefono");
            bool fE = !p.ContainsKey("pEmpresaEmail");
            if (!fN && !fR && !fD && !fT && !fE) return;
            try
            {
                var emp = EmpresaRepository.ObtenerEmpresa();
                if (emp == null) return;
                string nombre = !string.IsNullOrWhiteSpace(emp.NombreComercial)
                    ? emp.NombreComercial : (emp.RazonSocial ?? "");
                if (fN) p["pEmpresaNombre"]    = nombre;
                if (fR) p["pEmpresaRUC"]       = emp.RUC      ?? "";
                if (fD) p["pEmpresaDireccion"] = emp.Direccion ?? "";
                if (fT) p["pEmpresaTelefono"]  = emp.Telefono  ?? "";
                if (fE) p["pEmpresaEmail"]     = emp.Email     ?? "";
            }
            catch { }
        }

        // ── Llenar controles con datos ────────────────────────────────────────
        private void Llenar(DataTable detalle, Dictionary<string, string> p)
        {
            // Logo
            pbLogo.Visible = false;
            if (_config.MostrarLogo)
            {
                try
                {
                    byte[] bytes = EmpresaRepository.ObtenerEmpresa()?.Logo;
                    if (bytes != null && bytes.Length > 0)
                    {
                        pbLogo.Image   = Image.FromStream(new MemoryStream(bytes));
                        pbLogo.Visible = true;
                    }
                }
                catch { }
            }

            // Empresa
            lblNombreNegocio.Visible = true;
            lblNombreNegocio.Text    = Get(p, "pEmpresaNombre", "").ToUpper();

            lblRuc.Visible = _config.MostrarRUC;
            lblRuc.Text    = string.IsNullOrWhiteSpace(Get(p, "pEmpresaRUC")) ? "" : "RUC: " + Get(p, "pEmpresaRUC");

            lblDireccion.Visible = _config.MostrarDireccion;
            lblDireccion.Text    = Get(p, "pEmpresaDireccion");

            lblTelfono.Visible = _config.MostrarTelefono;
            lblTelfono.Text    = string.IsNullOrWhiteSpace(Get(p, "pEmpresaTelefono")) ? "" : "Tel: " + Get(p, "pEmpresaTelefono");

            lblEmail.Visible = _config.MostrarEmail;
            lblEmail.Text    = Get(p, "pEmpresaEmail");

            // Comprobante
            lblComprobante.Visible = true;
            lblComprobante.Text    = Get(p, "pTipoComprobante", "NOTA DE VENTA").ToUpper();

            lblnumSerie.Visible = true;
            lblnumSerie.Text    = Get(p, "pNumeroVenta");

            // Fecha y hora
            lblFecha.Visible = true;
            lblFecha.Text    = "Fecha : " + Get(p, "pFecha", DateTime.Now.ToString("dd/MM/yyyy"))
                             + "  " + Get(p, "pHora", DateTime.Now.ToString("HH:mm"));

            // Cliente
            string cliente = Get(p, "pCliente");
            if (string.IsNullOrWhiteSpace(cliente)) cliente = "CLIENTE GENERAL";
            lblCliente.Visible = true;
            lblCliente.Text    = "Cliente : " + cliente;

            // DNI — solo si tiene valor real y no es cliente general
            string doc    = Get(p, "pDocCliente");
            bool   esGen  = string.IsNullOrWhiteSpace(Get(p, "pCliente"))
                            || Get(p, "pCliente").IndexOf("GENERAL", StringComparison.OrdinalIgnoreCase) >= 0
                            || Get(p, "pCliente").IndexOf("VARIOS",  StringComparison.OrdinalIgnoreCase) >= 0;
            bool   docOK  = !string.IsNullOrWhiteSpace(doc) && doc != "00000000" && doc != "0";
            lblDNI.Visible = _config.MostrarDNI && docOK && !esGen;
            lblDNI.Text    = "DNI : " + doc;

            // Detalle (única lógica: Descripcion | Unid | Cant | Total)
            dgvItems.DataSource = detalle;
            dgvItems.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

            // Totales
            lblSubTotal.Visible         = true;
            lblSubTotalCantidad.Visible = true;
            lblSubTotalCantidad.Text    = Fmt(Get(p, "pSubTotal", "0.00"));

            lblIGV.Visible         = true;
            lblIGVCantidad.Visible = true;
            lblIGVCantidad.Text    = Fmt(Get(p, "pIGV", "0.00"));

            lblTotal.Visible         = true;
            lblTotalCantidad.Visible = true;
            lblTotalCantidad.Text    = Fmt(Get(p, "pTotal", "0.00"));

            // Info de pago
            decimal.TryParse(Get(p, "pMontoRecibido"), out decimal recibido);
            decimal.TryParse(Get(p, "pVuelto"),        out decimal vuelto);

            label35.Visible                = _config.MostrarInfoPago;
            lblMetodoPago.Visible          = _config.MostrarInfoPago;
            lblMetodoPagoSeleccion.Visible = _config.MostrarInfoPago;
            lblMetodoPagoSeleccion.Text    = Get(p, "pMetodoPago");

            label31.Visible             = _config.MostrarInfoPago && recibido > 0;
            lblRecibidoCantidad.Visible = _config.MostrarInfoPago && recibido > 0;
            if (_config.MostrarInfoPago && recibido > 0)
                lblRecibidoCantidad.Text = Fmt(recibido.ToString("N2"));

            label33.Visible           = _config.MostrarInfoPago && vuelto > 0;
            lblVueltoCantidad.Visible = _config.MostrarInfoPago && vuelto > 0;
            if (_config.MostrarInfoPago && vuelto > 0)
                lblVueltoCantidad.Text = Fmt(vuelto.ToString("N2"));

            // Pie de página
            bool mostrarPie = _config.MostrarPie && !string.IsNullOrWhiteSpace(_config.MensajePie);
            label37.Visible      = mostrarPie;
            lblPiePagina.Visible = mostrarPie;
            lblPiePagina.Text    = _config.MensajePie ?? "";

            // QR
            pbQR.Visible = _config.MostrarQR;

            ReflowTicket();
        }

        // ── Reflow: reposicionar controles colapsando los ocultos ─────────────
        private void ReflowTicket()
        {
            int offset = 0;

            // Delta entre dos controles en el Designer
            int D(Control a, Control b) => _designerTop[b] - _designerTop[a];

            // Si está oculto: acumula el hueco. Si está visible: coloca en posición diseño - offset.
            void CP(Control c, int slot)
            {
                if (c.Visible) c.Top = _designerTop[c] - offset;
                else           offset += slot;
            }

            // ── Cabecera empresa ──────────────────────────────────────────────
            CP(pbLogo, D(pbLogo, lblNombreNegocio));

            lblNombreNegocio.Height = lblNombreNegocio.PreferredHeight;
            lblNombreNegocio.Top    = _designerTop[lblNombreNegocio] - offset;

            CP(lblRuc,       D(lblRuc,       lblDireccion));
            CP(lblDireccion, D(lblDireccion, lblTelfono));
            CP(lblTelfono,   D(lblTelfono,   lblEmail));
            CP(lblEmail,     D(lblEmail,     label3));

            // ── Fijos: separador, comprobante, número, fecha, cliente ─────────
            foreach (var c in new Control[] { label3, lblComprobante, lblnumSerie, lblFecha, lblCliente })
                c.Top = _designerTop[c] - offset;

            // ── DNI (opcional) ────────────────────────────────────────────────
            CP(lblDNI, D(lblDNI, label11));

            // ── Cabecera detalle + DGV ────────────────────────────────────────
            foreach (var c in new Control[] { label11, lblDescripcion, lblUnidad, lblCantidad, lblCosto, pnlLineaDivisora })
                c.Top = _designerTop[c] - offset;

            dgvItems.Top = _designerTop[dgvItems] - offset;

            // Ajustar altura del DGV a las filas reales
            if (dgvItems.Rows.Count > 0)
            {
                int h = 0;
                foreach (DataGridViewRow row in dgvItems.Rows) h += row.Height;
                if (h > 0) dgvItems.Height = h;
            }

            // ── Footer: relativo al fondo del DGV ────────────────────────────
            // gap Designer entre fondo-DGV y label22
            int y = dgvItems.Bottom + (_designerTop[label22] - (_designerTop[dgvItems] + _designerDgvH));

            label22.Top = y;
            y += D(label22, lblSubTotal);

            lblSubTotal.Top = lblSubTotalCantidad.Top = y;
            if (lblIGV.Visible)
            {
                y += D(lblSubTotal, lblIGV);
                lblIGV.Top = lblIGVCantidad.Top = y;
                y += D(lblIGV, lblTotal);
            }
            else
                y += lblSubTotal.Height + 4;

            lblTotal.Top = lblTotalCantidad.Top = y;
            y += D(lblTotal, label35);

            if (label35.Visible) { label35.Top = y; y += D(label35, lblMetodoPago); }
            if (lblMetodoPago.Visible)
            {
                lblMetodoPago.Top = lblMetodoPagoSeleccion.Top = y;
                y += D(lblMetodoPago, label31);
                if (label31.Visible) { label31.Top = lblRecibidoCantidad.Top = y; y += D(label31, label33); }
                if (label33.Visible) { label33.Top = lblVueltoCantidad.Top   = y; y += D(label33, label37); }
            }

            if (label37.Visible)      { label37.Top      = y; y += D(label37, lblPiePagina); }
            if (lblPiePagina.Visible) { lblPiePagina.Top = y; y += D(lblPiePagina, pbQR); }
            if (pbQR.Visible)         { pbQR.Top         = y; y += pbQR.Height + 5; }

            // El control ajusta su propia altura
            this.Height = y + 13;
        }

        // ── Formato de celdas DGV ─────────────────────────────────────────────
        private void DgvItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value) return;
            string col = dgvItems.Columns[e.ColumnIndex].Name;
            if (col == "colCantidad")
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal d))
                    e.Value = d.ToString("N2");
                e.FormattingApplied = true;
            }
            else if (col == "colTotal")
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal d))
                    e.Value = "S/ " + d.ToString("N2");
                e.FormattingApplied = true;
            }
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        private static string Get(Dictionary<string, string> p, string k, string def = "")
        {
            string v;
            return p != null && p.TryGetValue(k, out v) && v != null ? v : def;
        }

        private static string Fmt(string raw)
        {
            raw = raw?.Trim() ?? "0.00";
            if (raw == "" || raw == "0" || raw == "0.00") return "S/ 0.00";
            return raw.StartsWith("S/") ? raw : "S/ " + raw;
        }
    }
}
