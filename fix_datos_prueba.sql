BEGIN TRANSACTION;

DELETE FROM CompraDetalles WHERE CompraID = 2;
DELETE FROM CreditosCompras WHERE CompraID = 2;
DELETE FROM CuentasPorPagar WHERE CompraID = 2;
DELETE FROM Compras WHERE CompraID = 2;

UPDATE Productos
SET StockTotal = (
    SELECT COALESCE(SUM(cd.CantidadUnidadesBase), 0)
    FROM CompraDetalles cd
    INNER JOIN Compras c ON c.CompraID = cd.CompraID
    WHERE cd.ProductoID = Productos.ProductoID
      AND c.Estado != 'ANULADA'
) - (
    SELECT COALESCE(SUM(vd.CantidadUnidadesBase), 0)
    FROM VentaDetalles vd
    INNER JOIN Ventas v ON v.VentaID = vd.VentaID
    WHERE vd.ProductoID = Productos.ProductoID
      AND v.Estado != 'ANULADA'
);

COMMIT;

SELECT 'OK: StockTotal recalculado', ProductoID, Nombre, StockTotal FROM Productos;
