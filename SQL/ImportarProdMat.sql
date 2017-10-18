insert into GC_ProductoMat
SELECT 1 AS empresa, tmpProdMat.Producto, articulo.CDETALLE AS Descripción, tmpProdMat.Material,
		tmpProdMat.Color, '' AS CodProvr, '' AS NombreProv, 
		CONVERT(decimal(18, 4), isnull(tmpProdMat.Precio,0)) AS Precio
FROM tmpProdMat INNER JOIN
              articulo ON tmpProdMat.Producto = articulo.CREF