insert into GC_Materiales
SELECT     1 AS empresa, [20300] AS Material, '' AS Descripci�n
FROM         tmpMat
GROUP BY [20300]