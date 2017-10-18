Insert into GesInject.dbo.GC_CabPedido
SELECT 1 AS Empresas, pedclit.nnumped AS NumPed, isnull(pedclit.cestado,'') as Estado, pedclit.dfecped AS [Fecha Pedido], 
		isnull(pedclit.dfecent,'01/01/1900') AS [Fecha Entrega], pedclit.ccodcli AS CodCli, clientes.cnomcli AS NomCli, 
		clientes.cdircli AS Dirección, clientes.cpobcli AS Población, isnull(clientes.ccodprov,'') AS Provincia, 
		isnull(clientes.cptlcli,'') AS CP, pedclit.ccodpago AS FPago, pedclit.ccoddiv AS Divisa, isnull(pedclit.csuped,'') AS SuPedido, 
		pedclit.ndpp AS DtoPP, pedclit.ndtoesp AS DtoESP
FROM pedclit INNER JOIN
             clientes ON pedclit.ccodcli = clientes.ccodcli
