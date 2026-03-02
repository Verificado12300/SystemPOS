using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using SistemaPOS.Data;

namespace SistemaPOS.Forms.Finanzas
{
    public partial class FormConciliacionInventario : Form
    {
        public FormConciliacionInventario()
        {
            InitializeComponent();
            dtpHasta.Value = DateTime.Today;
        }

        private void BtnConciliar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvDetalle.DataSource = null;
                lblSaldo140.Text      = "S/ 0.00";
                lblValorKardex.Text   = "S/ 0.00";
                lblDiferencia.Text    = "S/ 0.00";
                lblDiferencia.ForeColor = System.Drawing.Color.Black;

                DateTime hasta = dtpHasta.Value.Date;

                // 1) Saldo contable cuenta 140 (Inventario)
                decimal saldo140 = Math.Round(
                    ContabilidadRepository.ObtenerSaldoCuentaHasta("140", hasta), 2);

                // 2) Valor Kardex: recorre todos los movimientos hasta fechaHasta,
                //    agrupa por producto y obtiene el valor final (CostoSaldo del último mov.)
                var kardexMovs = KardexRepository.ObtenerMovimientos(
                    productoID: null,
                    fechaDesde: null,
                    fechaHasta: hasta,
                    metodoValorizacion: "PROMEDIO");

                // Mantener el último estado por producto
                var estadoPorProducto = new Dictionary<int, KardexProductoFinal>();
                foreach (var m in kardexMovs)
                {
                    var tipo  = m.GetType();
                    int  pid   = (int)   tipo.GetProperty("ProductoID")   .GetValue(m, null);
                    string pnombre = (string) tipo.GetProperty("ProductoNombre").GetValue(m, null);
                    decimal stock  = (decimal)tipo.GetProperty("StockPosterior").GetValue(m, null);
                    decimal costoSaldo = (decimal)tipo.GetProperty("CostoSaldo").GetValue(m, null);
                    decimal cprom  = (decimal)tipo.GetProperty("CostoPromedio").GetValue(m, null);

                    estadoPorProducto[pid] = new KardexProductoFinal
                    {
                        ProductoID    = pid,
                        Nombre        = pnombre,
                        StockFinal    = stock,
                        CostoPromFinal= cprom,
                        ValorFinal    = costoSaldo
                    };
                }

                // Construir filas detalle
                var filas = new List<FilaConciliacion>();
                decimal totalKardex = 0m;
                foreach (var kv in estadoPorProducto.Values)
                {
                    decimal valorRedondeado = Math.Round(kv.ValorFinal, 2);
                    filas.Add(new FilaConciliacion
                    {
                        ProductoID     = kv.ProductoID,
                        Nombre         = kv.Nombre,
                        StockFinal     = Math.Round(kv.StockFinal, 4),
                        CostoPromFinal = Math.Round(kv.CostoPromFinal, 4),
                        ValorFinal     = valorRedondeado
                    });
                    totalKardex += valorRedondeado;
                }
                totalKardex = Math.Round(totalKardex, 2);

                decimal diferencia = Math.Round(saldo140 - totalKardex, 2);

                // Mostrar resumen
                lblSaldo140.Text    = $"S/ {saldo140:N2}";
                lblValorKardex.Text = $"S/ {totalKardex:N2}";
                lblDiferencia.Text  = $"S/ {diferencia:N2}";
                lblDiferencia.ForeColor = diferencia == 0m
                    ? System.Drawing.Color.Green
                    : System.Drawing.Color.Red;

                // Cargar grilla
                dgvDetalle.DataSource = filas;
                ConfigurarColumnas();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ConciliacionInventario] Error: {ex.Message}");
                MessageBox.Show($"Error al conciliar:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvDetalle.Columns.Count == 0) return;
            if (dgvDetalle.Columns.Contains("ProductoID"))     dgvDetalle.Columns["ProductoID"].HeaderText     = "ID";
            if (dgvDetalle.Columns.Contains("Nombre"))         dgvDetalle.Columns["Nombre"].HeaderText         = "Producto";
            if (dgvDetalle.Columns.Contains("StockFinal"))     dgvDetalle.Columns["StockFinal"].HeaderText     = "Stock Final";
            if (dgvDetalle.Columns.Contains("CostoPromFinal")) dgvDetalle.Columns["CostoPromFinal"].HeaderText = "Costo Prom.";
            if (dgvDetalle.Columns.Contains("ValorFinal"))     dgvDetalle.Columns["ValorFinal"].HeaderText     = "Valor Kardex";
            if (dgvDetalle.Columns.Contains("Nombre"))         dgvDetalle.Columns["Nombre"].Width              = 200;
        }

        // Modelo auxiliar
        private sealed class KardexProductoFinal
        {
            public int     ProductoID     { get; set; }
            public string  Nombre         { get; set; }
            public decimal StockFinal     { get; set; }
            public decimal CostoPromFinal { get; set; }
            public decimal ValorFinal     { get; set; }
        }
    }

    // Clase de datos para la grilla (propiedades públicas para DataGridView binding)
    public sealed class FilaConciliacion
    {
        public int     ProductoID     { get; set; }
        public string  Nombre         { get; set; }
        public decimal StockFinal     { get; set; }
        public decimal CostoPromFinal { get; set; }
        public decimal ValorFinal     { get; set; }
    }
}
