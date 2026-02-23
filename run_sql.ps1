$dll = "E:\SistemaPOS\bin\Debug\System.Data.SQLite.dll"
Add-Type -Path $dll

$dbPath = "E:\SistemaPOS\bin\Debug\sistema_pos.db"
$conn = New-Object System.Data.SQLite.SQLiteConnection("Data Source=$dbPath;Version=3;")
$conn.Open()

$statements = @(
    "DELETE FROM CompraDetalles WHERE CompraID = 2",
    "DELETE FROM CreditosCompras WHERE CompraID = 2",
    "DELETE FROM CuentasPorPagar WHERE CompraID = 2",
    "DELETE FROM Compras WHERE CompraID = 2",
    "UPDATE Productos SET StockTotal = (SELECT COALESCE(SUM(cd.CantidadUnidadesBase),0) FROM CompraDetalles cd INNER JOIN Compras c ON c.CompraID=cd.CompraID WHERE cd.ProductoID=Productos.ProductoID AND c.Estado!='ANULADA') - (SELECT COALESCE(SUM(vd.CantidadUnidadesBase),0) FROM VentaDetalles vd INNER JOIN Ventas v ON v.VentaID=vd.VentaID WHERE vd.ProductoID=Productos.ProductoID AND v.Estado!='ANULADA')"
)

$tx = $conn.BeginTransaction()
try {
    foreach ($sql in $statements) {
        $cmd = $conn.CreateCommand()
        $cmd.Transaction = $tx
        $cmd.CommandText = $sql
        $rows = $cmd.ExecuteNonQuery()
        Write-Host "OK: $sql => $rows filas afectadas"
    }
    $tx.Commit()
    Write-Host "COMMIT exitoso"
} catch {
    $tx.Rollback()
    Write-Host "ERROR: $_"
    exit 1
}

# Verify
$cmd2 = $conn.CreateCommand()
$cmd2.CommandText = "SELECT ProductoID, Nombre, StockTotal FROM Productos"
$r = $cmd2.ExecuteReader()
while ($r.Read()) {
    Write-Host "Stock verificado: ProductoID=$($r['ProductoID']) | $($r['Nombre']) | StockTotal=$($r['StockTotal'])"
}
$r.Close()

$cmd3 = $conn.CreateCommand()
$cmd3.CommandText = "SELECT COUNT(*) FROM Compras"
Write-Host "Compras restantes: $($cmd3.ExecuteScalar())"

$cmd4 = $conn.CreateCommand()
$cmd4.CommandText = "SELECT COUNT(*) FROM CompraDetalles"
Write-Host "Detalles compra restantes: $($cmd4.ExecuteScalar())"

$conn.Close()
