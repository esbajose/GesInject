insert into GC_ProductoMaterial
SELECT 1 AS Empresa, tmpProdMaterial.[REF# SP] AS Producto, tmpProdMaterial.Denominación AS Descripción,
		 tmpProdMaterial.[REF# MAT#] AS Material, isnull(articulo.CDETALLE,'') as desMaterial, 
         tmpProdMaterial.MATERIAL AS TipoMaterial,'' as CodProv,'' as NombreProv,0 as Precio
FROM   tmpProdMaterial LEFT OUTER JOIN
           articulo ON tmpProdMaterial.[REF# MAT#] = articulo.CREF
WHERE     (tmpProdMaterial.[REF# SP] IS NOT NULL) 
			AND (tmpProdMaterial.[REF# MAT#] IS NOT NULL 
			AND tmpProdMaterial.[REF# MAT#] <> N'')