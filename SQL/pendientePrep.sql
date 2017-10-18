SELECT GC_LinPedido.Id,GC_CabPedido.CodCli, GC_CabPedido.NomCli, GC_CabPedido.NumPed, GC_CabPedido.FechaPedido, GC_CabPedido.FechaEntrega, 
		GC_LinPedido.LinPed, GC_LinPedido.Producto,GC_LinPedido.Descripción,
		(GC_LinPedido.Cantidad - GC_LinPedido.CantidadServida) AS Cantidad, GC_LinPedido.Prioridad
FROM GC_CabPedido 
          INNER JOIN GC_LinPedido ON GC_CabPedido.Empresa = GC_LinPedido.Empresa AND GC_CabPedido.NumPed = GC_LinPedido.NumPed
WHERE (GC_CabPedido.Empresa = 1) AND (GC_CabPedido.Estado = 'P')
Order by GC_LinPedido.Prioridad,GC_CabPedido.FechaPedido,GC_CabPedido.CodCli