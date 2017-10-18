insert into GC_Moldes
SELECT     1 AS Empresa, molde AS CodMolde, '' AS Descripci�n, ISNULL(Cavidades, '') AS Cavidades, ISNULL(Ubicaci�n, '') AS Ubicaci�n
FROM         tmpMoldes
GROUP BY molde, ISNULL(Cavidades, ''), ISNULL(Ubicaci�n, '')
