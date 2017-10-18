insert into GC_Moldes
SELECT     1 AS Empresa, molde AS CodMolde, '' AS Descripción, ISNULL(Cavidades, '') AS Cavidades, ISNULL(Ubicación, '') AS Ubicación
FROM         tmpMoldes
GROUP BY molde, ISNULL(Cavidades, ''), ISNULL(Ubicación, '')
