Delete from GC_Ind_ProductoUbiCanLote

insert into GC_Ind_ProductoUbiCanLote
SELECT     Empresa, Almacen, Producto, Ubi, SUM(Cantidad) AS Cantidad, Lote
FROM         GC_MovProducto
GROUP BY Empresa, Almacen, Producto, Ubi, Lote

Delete from GC_Ind_ProductoUbiCan

insert into GC_Ind_ProductoUbiCan
SELECT     Empresa, Almacen, Producto, Ubi, SUM(Cantidad) AS Cantidad
FROM         GC_MovProducto
GROUP BY Empresa, Almacen, Producto, Ubi


Delete from GC_Ind_ProductoCan

insert into GC_Ind_ProductoCan
SELECT     Empresa, Almacen, Producto, SUM(Cantidad) AS Cantidad
FROM         GC_MovProducto
GROUP BY Empresa, Almacen, Producto


Delete from GC_Ind_ProductoUbiCanLoteOFL

insert into GC_Ind_ProductoUbiCanLoteOFL( Empresa, Almacen, Producto, Ubi, Cantidad, Lote, OFL)
SELECT     Empresa, Almacen, Producto, Ubi, SUM(Cantidad) AS Cantidad, Lote, OFL
FROM         GC_MovProducto
GROUP BY Empresa, Almacen, Producto, Ubi, Lote,OFL

