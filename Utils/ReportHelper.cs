using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Reporting.WinForms;
using SistemaPOS.Data;
using System.Globalization;

namespace SistemaPOS.Utils
{
    public static class ReportHelper
    {
        /// <summary>
        /// Obtiene la ruta absoluta de un archivo .rdlc
        /// </summary>
        public static string GetRdlcPath(string relativeReportPath)
        {
            return Path.Combine(Application.StartupPath, "Reports", relativeReportPath);
        }

        /// <summary>
        /// Obtiene los parametros comunes de la empresa para los reportes
        /// </summary>
        public static Dictionary<string, string> GetCompanyParameters()
        {
            var parameters = new Dictionary<string, string>();

            try
            {
                var empresa = EmpresaRepository.ObtenerEmpresa();
                if (empresa != null)
                {
                    string nombre = !string.IsNullOrWhiteSpace(empresa.NombreComercial)
                        ? empresa.NombreComercial
                        : (empresa.RazonSocial ?? "");
                    parameters["pEmpresaNombre"]    = nombre;
                    parameters["pEmpresaRUC"]       = empresa.RUC       ?? "";
                    parameters["pEmpresaDireccion"] = empresa.Direccion  ?? "";
                    parameters["pEmpresaTelefono"]  = empresa.Telefono   ?? "";
                    parameters["pEmpresaEmail"]     = empresa.Email      ?? "";
                }
                else
                {
                    parameters["pEmpresaNombre"]    = "";
                    parameters["pEmpresaRUC"]       = "";
                    parameters["pEmpresaDireccion"] = "";
                    parameters["pEmpresaTelefono"]  = "";
                    parameters["pEmpresaEmail"]     = "";
                }
            }
            catch
            {
                parameters["pEmpresaNombre"]    = "";
                parameters["pEmpresaRUC"]       = "";
                parameters["pEmpresaDireccion"] = "";
                parameters["pEmpresaTelefono"]  = "";
                parameters["pEmpresaEmail"]     = "";
            }

            parameters["pFechaGeneracion"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            return parameters;
        }

        /// <summary>
        /// Renderiza un reporte programaticamente sin mostrar el visor.
        /// Formatos: "PDF", "Excel", "Word"
        /// </summary>
        public static byte[] RenderReport(string rdlcPath,
            Dictionary<string, DataTable> dataSources,
            Dictionary<string, string> parameters,
            string format = "PDF")
        {
            // Mapear nombres a formatos RDLC correctos
            string rdlcFormat;
            switch (format.ToUpper())
            {
                case "EXCEL":
                    rdlcFormat = "EXCELOPENXML";
                    break;
                case "WORD":
                    rdlcFormat = "WORDOPENXML";
                    break;
                default:
                    rdlcFormat = "PDF";
                    break;
            }

            using (var localReport = new LocalReport())
            {
                localReport.ReportPath = rdlcPath;

                foreach (var ds in dataSources)
                    localReport.DataSources.Add(new ReportDataSource(ds.Key, ds.Value));

                // Asignar parametros de forma segura:
                // solo los que realmente existen en el RDLC.
                // Si falta alguno, enviar cadena vacia para evitar errores de render.
                var reportParamInfos = localReport.GetParameters();
                if (reportParamInfos != null && reportParamInfos.Count > 0)
                {
                    var paramLookup = parameters ?? new Dictionary<string, string>();
                    var reportParams = reportParamInfos
                        .Select(p =>
                        {
                            string value;
                            if (!paramLookup.TryGetValue(p.Name, out value) || value == null)
                                value = string.Empty;
                            return new ReportParameter(p.Name, value);
                        })
                        .ToList();

                    localReport.SetParameters(reportParams);
                }

                string mimeType, encoding, extension;
                Warning[] warnings;
                string[] streamIds;
                return localReport.Render(rdlcFormat, null,
                    out mimeType, out encoding, out extension,
                    out streamIds, out warnings);
            }
        }

        /// <summary>
        /// Exporta un reporte a archivo y lo abre
        /// </summary>
        public static void ExportarYAbrir(string rdlcPath,
            Dictionary<string, DataTable> dataSources,
            Dictionary<string, string> parameters,
            string format, string defaultFileName)
        {
            string filter;
            string ext;

            switch (format.ToUpper())
            {
                case "PDF":
                    filter = "PDF (*.pdf)|*.pdf";
                    ext = ".pdf";
                    break;
                case "EXCEL":
                    filter = "Excel (*.xlsx)|*.xlsx";
                    ext = ".xlsx";
                    break;
                default:
                    filter = "Word (*.docx)|*.docx";
                    ext = ".docx";
                    break;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = filter;
                sfd.FileName = defaultFileName + ext;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    byte[] bytes = RenderReport(rdlcPath, dataSources, parameters, format);
                    if (format.ToUpper() == "EXCEL")
                        bytes = FixExcelStyles(bytes);
                    File.WriteAllBytes(sfd.FileName, bytes);
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
            }
        }

        /// <summary>
        /// Renderiza el reporte como PDF y lo abre directamente (sin guardar).
        /// </summary>
        public static void MostrarVistaPrevia(string rdlcPath,
            Dictionary<string, DataTable> dataSources,
            Dictionary<string, string> parameters)
        {
            try
            {
                byte[] pdfBytes = RenderReport(rdlcPath, dataSources, parameters, "PDF");
                string tempFile = Path.Combine(Path.GetTempPath(),
                    "preview_ticket_" + DateTime.Now.Ticks + ".pdf");
                File.WriteAllBytes(tempFile, pdfBytes);
                System.Diagnostics.Process.Start(tempFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar vista previa: " + ex.Message,
                    "Vista previa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Muestra un dialogo para elegir formato y exporta el reporte directamente.
        /// </summary>
        public static void MostrarDialogoExportacion(string rdlcPath,
            Dictionary<string, DataTable> dataSources,
            Dictionary<string, string> parameters,
            string defaultFileName)
        {
            using (var form = new Form())
            {
                form.Text = "Exportar Reporte";
                form.Size = new System.Drawing.Size(280, 220);
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                var lbl = new Label
                {
                    Text = "Seleccione el formato:",
                    Left = 20, Top = 15, Width = 230,
                    Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold)
                };

                var rbPdf = new RadioButton { Text = "PDF", Left = 30, Top = 45, Width = 200, Checked = true };
                var rbExcel = new RadioButton { Text = "Excel (.xlsx)", Left = 30, Top = 70, Width = 200 };
                var rbWord = new RadioButton { Text = "Word (.docx)", Left = 30, Top = 95, Width = 200 };

                var btnExportar = new Button
                {
                    Text = "Exportar",
                    Left = 30, Top = 135, Width = 100, Height = 32,
                    DialogResult = DialogResult.OK
                };
                var btnCancelar = new Button
                {
                    Text = "Cancelar",
                    Left = 140, Top = 135, Width = 100, Height = 32,
                    DialogResult = DialogResult.Cancel
                };

                form.AcceptButton = btnExportar;
                form.CancelButton = btnCancelar;
                form.Controls.AddRange(new Control[] { lbl, rbPdf, rbExcel, rbWord, btnExportar, btnCancelar });

                if (form.ShowDialog() == DialogResult.OK)
                {
                    string formato = rbPdf.Checked ? "PDF" : rbExcel.Checked ? "EXCEL" : "WORD";
                    ExportarYAbrir(rdlcPath, dataSources, parameters, formato, defaultFileName);
                }
            }
        }
        /// <summary>
        /// Reemplaza el styles.xml dentro del xlsx con uno limpio y valido.
        /// Elimina toda la seccion numFmts y pone todo en formato General.
        /// </summary>
        private static byte[] FixExcelStyles(byte[] xlsxBytes)
        {
            string tempFile = Path.Combine(Path.GetTempPath(), "rdlc_export_temp.xlsx");
            try
            {
                File.WriteAllBytes(tempFile, xlsxBytes);

                using (var zip = ZipFile.Open(tempFile, ZipArchiveMode.Update))
                {
                    var entry = zip.GetEntry("xl/styles.xml");
                    if (entry == null) return xlsxBytes;

                    string originalXml;
                    using (var sr = new StreamReader(entry.Open()))
                        originalXml = sr.ReadToEnd();

                    XDocument doc = XDocument.Parse(originalXml);
                    XNamespace ns = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
                    var root = doc.Root;

                    // 1. ELIMINAR toda la seccion numFmts (causa del problema)
                    var numFmtsEl = root.Element(ns + "numFmts");
                    if (numFmtsEl != null)
                        numFmtsEl.Remove();

                    // 2. Poner todos los numFmtId a 0 (General) en cellXfs y cellStyleXfs
                    foreach (string section in new[] { "cellXfs", "cellStyleXfs" })
                    {
                        var sectionEl = root.Element(ns + section);
                        if (sectionEl == null) continue;
                        foreach (var xf in sectionEl.Elements(ns + "xf"))
                        {
                            var attr = xf.Attribute("numFmtId");
                            if (attr != null) attr.Value = "0";
                        }
                    }

                    // 3. Ajustar tamaños de fuente: reducir fuentes <= 10pt a 8pt
                    var fontsEl = root.Element(ns + "fonts");
                    if (fontsEl != null)
                    {
                        foreach (var font in fontsEl.Elements(ns + "font"))
                        {
                            var szEl = font.Element(ns + "sz");
                            if (szEl != null)
                            {
                                double currentVal;
                                string valStr = szEl.Attribute("val")?.Value ?? "0";
                                if (double.TryParse(valStr, System.Globalization.NumberStyles.Any,
                                    CultureInfo.InvariantCulture, out currentVal)
                                    && currentVal <= 10)
                                {
                                    szEl.SetAttributeValue("val", "8");
                                }
                            }
                            else if (!font.HasElements)
                            {
                                font.Add(new XElement(ns + "sz", new XAttribute("val", "8")));
                                font.Add(new XElement(ns + "name", new XAttribute("val", "Calibri")));
                            }
                        }
                    }

                    // 4. Asegurar count en todas las colecciones
                    foreach (var pair in new[] {
                        new[] { "fonts", "font" }, new[] { "fills", "fill" },
                        new[] { "borders", "border" }, new[] { "cellStyleXfs", "xf" },
                        new[] { "cellXfs", "xf" }, new[] { "cellStyles", "cellStyle" } })
                    {
                        var el = root.Element(ns + pair[0]);
                        if (el != null)
                            el.SetAttributeValue("count", el.Elements(ns + pair[1]).Count());
                    }

                    var dxfsEl = root.Element(ns + "dxfs");
                    if (dxfsEl != null)
                        dxfsEl.SetAttributeValue("count", dxfsEl.Elements(ns + "dxf").Count());

                    // 5. Limpiar namespaces innecesarios
                    root.Attributes().Where(a =>
                        a.IsNamespaceDeclaration && a.Value != ns.NamespaceName)
                        .ToList().ForEach(a => a.Remove());

                    // 6. Generar XML limpio con encoding UTF-8 correcto
                    byte[] fixedBytes;
                    var settings = new System.Xml.XmlWriterSettings
                    {
                        Encoding = new UTF8Encoding(false),
                        Indent = false,
                        OmitXmlDeclaration = false
                    };
                    using (var xmlMs = new MemoryStream())
                    {
                        using (var xw = System.Xml.XmlWriter.Create(xmlMs, settings))
                            doc.Save(xw);
                        fixedBytes = xmlMs.ToArray();
                    }

                    // 7. Reemplazar en el ZIP
                    entry.Delete();
                    var newEntry = zip.CreateEntry("xl/styles.xml");
                    using (var stream = newEntry.Open())
                        stream.Write(fixedBytes, 0, fixedBytes.Length);
                }

                return File.ReadAllBytes(tempFile);
            }
            catch
            {
                return xlsxBytes;
            }
            finally
            {
                try { File.Delete(tempFile); } catch { }
            }
        }
    }
}
