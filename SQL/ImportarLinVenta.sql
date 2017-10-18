insert into  GesInject.dbo.GC_LinPedido
SELECT  1 AS Empresa, nnumped AS NumPed, nlinea AS LinPed, isnull(cref,'') AS Producto, 
		cdetalle AS Descripción, ncanped AS Cantidad, ncanent AS [Cantidad Servida], 
		'01/01/1900' AS [Fecha Entrega], isnull(clote,'') AS Lote,niva AS IVA, nunidades AS Cajas, 
		npreunit AS Precio, ndto AS DTO, ndtolin AS DTOLin
FROM         pedclil
--WHERE     (nnumped = '1400779')