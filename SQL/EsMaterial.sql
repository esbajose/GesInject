UPDATE    GC_ProductoAnexos
SET              EsMaterial = 1
FROM         GC_ProductoMaterial LEFT OUTER JOIN
                      GC_ProductoAnexos ON GC_ProductoMaterial.Material = GC_ProductoAnexos.Producto AND GC_ProductoMaterial.Empresa = GC_ProductoAnexos.Empresa
WHERE     (GC_ProductoAnexos.EsMaterial IS NOT NULL)