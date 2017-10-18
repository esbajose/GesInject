insert into GC_ProductoAnexos

SELECT 1 AS Empresa, tmpProdAnex.[REF# SP] AS Producto, isnull(articulo.CDETALLE,'') AS Descripción, isnull(tmpProdAnex.MATERIAL,'') AS Material, '' AS Color, '' AS CodProv,  
          '' AS NombreProv,isnull(tmpProdAnex.[Nº DE MOLDE],'') AS CodMolde, 0 AS Precio, isnull(tmpProdAnex.[PESO NETO UN# ( g )],0) AS PesoNeto, isnull(tmpProdAnex.[PIEZAS / HORA],0) AS PiezasHora, isnull(tmpProdAnex.BOLSA,'') AS Bolsa, 
          isnull(tmpProdAnex.[Piezas Bolsa],0) AS PiezasBolsa, isnull(tmpProdAnex.CAJA,'') AS Caja, isnull(tmpProdAnex.[PIEZAS / CAJA],0) AS PiezasCaja, tmpProdAnex.IMAGEN AS Imagen, 
          isnull(tmpProdAnex.[ENLACE DOCUMENTACIÓN],'') AS Documentación
FROM  tmpProdAnex LEFT OUTER JOIN
            articulo ON tmpProdAnex.[REF# SP] = articulo.CREF
WHERE (NOT (tmpProdAnex.[REF# SP] IS NULL))
ORDER BY Descripción