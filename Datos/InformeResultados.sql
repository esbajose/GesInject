SELECT        tOFL.IdOF, CASE WHEN FechaInicio = '1753-01-01' THEN Fecha ELSE FechaInicio END AS FechaInicio, 
                         CASE WHEN FechaFin = '1753-01-01' THEN FechaEntrega ELSE FechaFin END AS FechaFin, '' AS DuraciónHMS, '' AS duraciónH, tOFL.Maquina, tOFL.Articulo, 
                         '' AS ReferCli, '' AS ReferPZA, tProd.CodMolde, tMol.Cavidades, tProd.PVP, tProd.Descripción, CONVERT(int, tOFL.PiezasReales) AS PiezasReales, CONVERT(int, 
                         tOFL.CantidadFab) AS CantidadFab, CONVERT(int, tOFL.PiezasReales - tOFL.CantidadFab) AS Merma, CONVERT(decimal(10, 2), 
                         (tOFL.PiezasReales - tOFL.CantidadFab) * 100 / case when tOFL.CantidadFab > 0 then tOFL.CantidadFab else 1 end) AS PorMerma, tOFL.Horas, tOFL.Kilos, tProd.PiezasHora AS UDSTeor, CONVERT(int, 
                         tOFL.PiezasReales / case when tOFL.Horas > 0 then tOFL.Horas else 1 end) AS UDSReal, 0 AS CicloTeo, 0 AS CicloReal, 0 AS DesvCiclo, 0 AS Ocu, 0 AS TasaHMaq, 0 AS TasaHOper, 0 AS PonerSacarMol, 
                         0 AS INYMaq, 0 AS INYOper, 0 AS TotINY, tProd.PiezasCaja, tProd.PiezasBolsa, tProd.Caja, 0 AS CostaCaja, tProd.Bolsa, 0 AS CosteBolsa, 0 AS CosteCajas, 
                         0 AS CosteBolsas, 0 AS TotalEMB, tMat.Material, tMat.TipoMaterial, tMat.Color, tMat.Precio, 0 AS TotalMP
FROM            GC_OrdenProd AS tOFL INNER JOIN
                         GC_ProductoAnexos AS tProd ON tOFL.Empresa = tProd.Empresa AND tOFL.Articulo = tProd.Producto INNER JOIN
                         GC_Moldes AS tMol ON tOFL.Empresa = tMol.Empresa AND tProd.CodMolde = tMol.CodMolde INNER JOIN
                         GC_ProductoMaterial AS tMat ON tOFL.Empresa = tMat.Empresa AND tProd.Producto = tMat.Producto
WHERE        (tOFL.Estado = N'terminada') AND (tOFL.Empresa = 1) AND (tOFL.Fecha > CONVERT(DATETIME, '2016-01-01 00:00:00', 102)) 
--AND (tOFL.IdOF = N'N107207')