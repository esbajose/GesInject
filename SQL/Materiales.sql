insert into GC_Materiales
SELECT     1 AS empresa, [20300] AS Material, '' AS Descripción
FROM         tmpMat
GROUP BY [20300]