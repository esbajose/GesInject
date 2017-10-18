USE [Cosmic]
GO

/****** Object:  UserDefinedFunction [dbo].[fncProdStUbi]    Script Date: 11/18/2014 20:25:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncProdStUbi] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS varchar(250)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vUbi varchar(25),
		@vUbis varchar(250),
		@vCan decimal(18,0)
		

		set @vUbi = ''
		set @vUbis = ''

			
		--Cursor de Ubicaciones
		Declare cUbis Cursor for
		SELECT [Bin Code] as Ubi,SUM(Quantity) as Cantidad
		FROM [INDUSTRIAS COSMIC, S_A_U_$Mov_ PickCaotic]
		GROUP BY [Item No_], [Bin Code], [Location code]
		HAVING  ([Item No_] = @Producto) 
				AND (SUM(Quantity) > 0)
				AND ([Location Code] = @Almacen)				
		--Recorre cursor de Uvicaciones
		Open cUbis

		Fetch Next From cUbis
			Into @vUbi,@vCan

		While @@Fetch_Status = 0
		Begin
	    
					
			set @vUbis = @vUbis + @vUbi + '(' + convert(varchar(10),@vCan) + ')'+ CHAR(13) + CHAR(10)
				
			Fetch Next From cUbis
				Into @vUbi,@vCan

		end
		Close cUbis
		Deallocate cUbis	



	RETURN ISNULL(@vUbis,'')


END







GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_DesInci2]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create FUNCTION [dbo].[fncProdSD_DesInci2] 
(	
	@OFL varchar(20),
	@IP varchar(30),
	@Compo varchar(30)
)
RETURNS varchar(150)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vDesInci varchar(200),
		@vDesInciOFL varchar(200),
		@vRes varchar(150)
		
		set @vDesInci = '**Inex**'
		set @vDesInciOFL = '**Inex**'
		set @vRes = ''

		if @Compo = ''
			begin
				SELECT Top(1) @vDesInci = isnull(DesInci,'**Inex**')
				FROM ProdSD_Incidencias
				WHERE (OFL = @OFL) AND (IP = @IP)
			end
		if @Compo <> ''
			begin
				SELECT Top(1) @vDesInci = isnull(DesInci,'**Inex**')
				FROM ProdSD_Incidencias
				WHERE (OFL = @OFL) AND (IP = @IP) AND (Compo = @Compo)
			end

		SELECT Top(1) @vDesInciOFL = isnull(DesInci,'**Inex**')
		FROM ProdSD_Incidencias
		WHERE (OFL = @OFL) AND (IP = '') AND (Compo = '') AND (Estado = 'Pendiente')
				
		if @vDesInciOFL <> '**Inex**'
			begin
				set @vDesInci = @vDesInciOFL
			end

			
		if @vDesInci = '**Inex**'
			begin
				set @vRes = ''
			end
		if @vDesInci <> '**Inex**'
			begin
				set @vRes = @vDesInci
			end
		

RETURN ISNULL(@vRes,'')


END




















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_EsInci2]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create FUNCTION [dbo].[fncProdSD_EsInci2] 
(	
	@OFL varchar(20),
	@IP varchar(30),
	@Compo varchar(30)
)
RETURNS bit
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vDesInci varchar(200),
		@vDesInciOFL varchar(200),
		@vRes bit
		
		set @vDesInci = '**Inex**'
		set @vDesInciOFL = '**Inex**'
		set @vRes = 0

		if @Compo = ''
			begin
				SELECT Top(1) @vDesInci = isnull(DesInci,'**Inex**')
				FROM ProdSD_Incidencias
				WHERE (OFL = @OFL) AND (IP = @IP) AND (Estado = 'Pendiente')
			end
		if @Compo <> ''
			begin
				SELECT Top(1) @vDesInci = isnull(DesInci,'**Inex**')
				FROM ProdSD_Incidencias
				WHERE (OFL = @OFL) AND (IP = @IP) AND (Compo = @Compo) AND (Estado = 'Pendiente')
			end
			
			
		SELECT Top(1) @vDesInciOFL = isnull(DesInci,'**Inex**')
		FROM ProdSD_Incidencias
		WHERE (OFL = @OFL) AND (IP = '') AND (Compo = '') AND (Estado = 'Pendiente')
				
		if @vDesInciOFL <> '**Inex**'
			begin
				set @vDesInci = @vDesInciOFL
			end
			
		if @vDesInci = '**Inex**'
			begin
				set @vRes = 0
			end
		if @vDesInci <> '**Inex**'
			begin
				set @vRes = 1
			end
		

RETURN ISNULL(@vRes,0)


END




















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_OFL_Aca]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create FUNCTION [dbo].[fncProdSD_OFL_Aca] 
(	
    @OFL varchar(20)
)
RETURNS varchar(90)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vAca Varchar(90)
		
SELECT @vAca = [INDUSTRIAS COSMIC, S_A_U_$Textos Acabados].[Cód_ Acabado] + '-' + [INDUSTRIAS COSMIC, S_A_U_$Textos Acabados].Texto
FROM         ProdSD_Produccion_IP INNER JOIN
                      [INDUSTRIAS COSMIC, S_A_U_$Item] ON ProdSD_Produccion_IP.Producto = [INDUSTRIAS COSMIC, S_A_U_$Item].No_ INNER JOIN
                      [INDUSTRIAS COSMIC, S_A_U_$Textos Acabados] ON 
                      [INDUSTRIAS COSMIC, S_A_U_$Item].[Cód acabado] = [INDUSTRIAS COSMIC, S_A_U_$Textos Acabados].[Cód_ Acabado]
WHERE     (ProdSD_Produccion_IP.OFL = @OFL) AND ([INDUSTRIAS COSMIC, S_A_U_$Textos Acabados].[Cód_ Idioma] = 'ESPAÑOL')



RETURN ISNULL(@vAca,'')


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_IP_Picto]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncProdSD_IP_Picto] 
(	
    @OFL varchar(20)
)
RETURNS varchar(20)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vDeco Varchar(20)
		
		SELECT @vDeco = [INDUSTRIAS COSMIC, S_A_U_$IP Header].Decorado
		FROM ProdSD_Produccion_IP INNER JOIN
			 [INDUSTRIAS COSMIC, S_A_U_$IP Header] ON ProdSD_Produccion_IP.IP = [INDUSTRIAS COSMIC, S_A_U_$IP Header].No_
		WHERE (ProdSD_Produccion_IP.OFL = @OFL) AND ([INDUSTRIAS COSMIC, S_A_U_$IP Header].Decorado <> '')



RETURN ISNULL(@vDeco,'')


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_VerifCB]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create FUNCTION [dbo].[fncProdSD_VerifCB] 
(	
	@Compo varchar(30)
)
RETURNS bit
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vRes bit
		
		set @vRes = 0

		SELECT @vRes=[Validar CB]
		FROM [INDUSTRIAS COSMIC, S_A_U_$Item]
		WHERE (No_ = @Compo)
			

RETURN ISNULL(@vRes,0)


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_ComentIP]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[fncProdSD_ComentIP] 
(	
	@IP    varchar(20)

)
RETURNS varchar(Max)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vComent varchar(Max),
		@vComentLin varchar(250)
	
	SET @vComent=''	
	--Cursor de Comentarios de IP
	Declare cuComent Cursor for
			SELECT  Comment
			FROM [INDUSTRIAS COSMIC, S_A_U_$Manufacturing Comment Line]
			WHERE  ([Table Name] = 4) AND (No_ = @IP)
			
			
	--Recorre cursor de Comentarios
	Open cuComent

	Fetch Next From cuComent
		Into @vComentLin

	While @@Fetch_Status = 0
	Begin	
		SET @vComent = @vComent + @vComentLin + ' ' + CHAR(13) + CHAR(10)
	
				
		Fetch Next From cuComent
		Into @vComentLin

	end
	Close cuComent
	Deallocate cuComent



RETURN ISNULL(@vComent,'')


END

















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdStDisponible]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncProdStDisponible] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStock decimal(18,2),
		@vStRes decimal(18,2),
		@vStLibre decimal(18,2)


    set @vStLibre=0;
    set @vStock = 0;
    set @vStRes = 0;
	if @Almacen > ''
	begin
		SELECT @vStRes = s61
			FROM [INDUSTRIAS COSMIC, S_A_U_$5407$2] AS Mov 
			WHERE (bucket = 3) AND (f1 = 1 or f1 = 2 or f1 = 3) AND (f11 = @Producto)  AND (f30 = @Almacen)
			
		SELECT @vStock = s12
			FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] AS Mov 
			WHERE (bucket = 4) AND (f2 = @Producto)  AND (f8 = @Almacen)
			
	end
	
	
	if @Almacen = ''
	begin
		SELECT @vStRes = SUM(s61)
			FROM [INDUSTRIAS COSMIC, S_A_U_$5407$2] AS Mov 
			WHERE (bucket = 3) AND (f1 = 1 or f1 = 2 or f1 = 3) AND (f11 = @Producto)
			
		SELECT @vStock = s12
			FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] AS Mov 
			WHERE (bucket = 3) AND (f2 = @Producto)
			
	end
	
	set @vStLibre = @vStock - @vStRes

	RETURN ISNULL(@vStLibre,0)


END


GO

/****** Object:  UserDefinedFunction [dbo].[fncProdPaletAdi]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncProdPaletAdi] 
(	
	@Prod    varchar(20)
)
RETURNS varchar(250)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@Res varchar(250),
		@vAdi varchar(20),
		@vPalet varchar(20)
		Set @Res = ''

	--Cursor de Adicional
	Declare cAdi Cursor for
		SELECT TOP (10) [Cód_ Situación],[Matrícula Palet]
		FROM [INDUSTRIAS COSMIC, S_A_U_$Zona Adicional]
		WHERE (Nº = @Prod)
		GROUP BY [Cód_ Situación],[Matrícula Palet]
	
	--Recorre cursor de Adicional
	Open cAdi

	Fetch Next From cAdi
		Into @vAdi,@vPalet

	While @@Fetch_Status = 0
	Begin
		set @Res = @Res + @vPalet + ','; 
		
		Fetch Next From cAdi
			Into @vAdi,@vPalet
	end	
	Close cAdi
	Deallocate cAdi
	--Fin del cursor de Adicional
	
		
RETURN ISNULL(@Res,'')


END
GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_DesfaseReg]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[fncProdSD_DesfaseReg] 
(	
	@CanOrig decimal(18,5),
	@CanReg decimal(18,5),
    @PorDes decimal(18,5)

)
RETURNS decimal(12,4)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vReg decimal(12,4),
		@vCanDif decimal(12,4), 
		@vCanPor decimal(12,4)
		
		
	
		set @vCanPor = @PorDes * @CanOrig /100  --Cantidad maxima de desfase
		set @vCanDif = @CanOrig - @CanReg       --diferencia entre cantidad original y cantidad a registrar
		if @vCanDif < 0 begin set @vCanDif = @vCanDif * -1 end  --Diferencia siempre en positivo
		
		set @vReg =0
		if @vCanDif > @vCanPor begin set @vReg = @vCanDif end 		
		

RETURN ISNULL(@vReg,1)


END

















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdMarca]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create FUNCTION [dbo].[fncProdMarca] 
(	
	@Prod    varchar(20)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@Res int
		Set @Res = 0
		Select  @Res = Marca
		FROM [INDUSTRIAS COSMIC, S_A_U_$Item] AS Producto
		Where Producto.[No_] = @Prod			
		
RETURN ISNULL(@Res,0)

END
GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_IMGMeca]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncProdSD_IMGMeca] 
(	
    @IP varchar(20)
)
RETURNS varchar(60)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vImg Varchar(120)
		
		SELECT @vImg =ISNULL(Mecanizado,'')
		FROM [INDUSTRIAS COSMIC, S_A_U_$IP Header]
		WHERE (No_ = @IP)
		
		if (@vImg = '')
		begin
			SELECT @vImg =ISNULL(Planos,'')
			FROM [INDUSTRIAS COSMIC, S_A_U_$IP Header]
			WHERE (No_ = @IP)		
		end
		
RETURN ISNULL(@vImg,'')


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_CompoIMG]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncProdSD_CompoIMG] 
(	
    @Compo varchar(20)
)
RETURNS varchar(20)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vCompo Varchar(20),
		@vUltCompo Varchar(20),
		@vSigue int,
		@vConta int,
		@vMatriz varchar(20)
		
		set @vUltCompo = @Compo
		set @vSigue = 1
		set @vConta = 1
		while @vSigue = 1
		   begin
		    set @vConta = @vConta + 1
		    if @vConta > 500 begin set @vSigue = 0 end
			SELECT top(1) @Compo = ISNULL(Compo,'')
			FROM ProdSD_Produccion
			WHERE (IP = @vUltCompo)
			if @Compo = ''
			   begin
				set @vSigue =0
			   end		      
			if @Compo <> ''
			   begin
				set @vUltCompo = @Compo
				set @Compo = ''
			   end		      
		   end;

		SELECT @vMatriz =ISNULL(Matriz,'')
		FROM [INDUSTRIAS COSMIC, S_A_U_$Item]
		WHERE (No_ = @vUltCompo)

RETURN ISNULL(@vMatriz,'')


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_CarroAlta]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create FUNCTION [dbo].[fncProdSD_CarroAlta] 
(	
    @Carro varchar(20)
)
RETURNS datetime
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vAlta datetime

		Set @vAlta = CONVERT(datetime,'1753-01-01 00:00:00',102)
		
		SELECT TOP (1) @vAlta = [Fecha alta]
		FROM ProdSD_Carros
		WHERE (NCarro = @Carro)

RETURN ISNULL(@vAlta,CONVERT(datetime,'1753-01-01 00:00:00',102))


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdMateriales]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncProdMateriales] 
(	
	@Prod    varchar(20)
)
RETURNS varchar(200)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Res varchar(200)
	declare @Cod varchar(50)
	declare @Cont int
						
	Set @Res = ''
    Set @Cont = 0
Declare ctmpMat Cursor for
	Select [Cód_ Material]
	FROM [INDUSTRIAS COSMIC, S_A_U_$Producto Material] AS tMat
	Where tMat.[Nº Producto] = @Prod

	Open ctmpMat
		Fetch Next From ctmpMat
			Into @Cod
				
		While @@Fetch_Status = 0
		Begin	
			if @Cont = 0 begin Set @Res = @Cod end
			if @Cont > 0 begin Set @Res = @Res + ',' + @Cod end
			Set @Cont = @Cont + 1
			 
			Fetch Next From ctmpMat
				Into @Cod
		end
		Close ctmpMat
		Deallocate ctmpMat


		
RETURN ISNULL(@Res,'')


END
GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_CarroPrio]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create FUNCTION [dbo].[fncProdSD_CarroPrio] 
(	
    @Carro varchar(20)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vPrio int

		Set @vPrio = 0
		
		SELECT TOP (1) @vPrio = Prioridad
		FROM ProdSD_Carros
		WHERE (NCarro = @Carro)

RETURN ISNULL(@vPrio,0)


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdMampStock]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create FUNCTION [dbo].[fncProdMampStock] 
(	
	@Prod    varchar(20)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Res varchar(20)
		
	Set @Res = 0

	Select Top(1) @Res = [Mampara en Stock]
	FROM [INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd
	Where tProd.[No_] = @Prod

		
RETURN ISNULL(@Res,0)


END
GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_CanBarra]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create FUNCTION [dbo].[fncProdSD_CanBarra] 
(	
	@Acum    varchar(20),
	@PPrep   varchar(20),
    @Carro varchar(20),
    @Tipo varchar(20),
    @Compo varchar(20)
)
RETURNS decimal(12,6)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vCanBarra decimal(12,6)

		SELECT @vCanBarra = sum(CanBarra)
		FROM ProdSD_Produccion as Produc 
		WHERE (Produc.AcumuladoPrep = @Acum) 
			AND (Produc.PPrep = @PPrep)  
			and (DesCompo <> 'Hoja de Instrucciones')  
			AND Produc.Carro = @Carro  
			AND Produc.Tipologia = @Tipo  
			AND Produc.Compo = @Compo
			
			
RETURN ISNULL(@vCanBarra,0)


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncProducto]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fncProducto] 
(
	@Producto nvarchar(20),
	@Campo varchar(20)
)
RETURNS varchar(100)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vRes varchar(100)

		if @Campo = 'Nombre colección'
		begin
			set @vRes = CONVERT(varchar(100),ISNULL((SELECT [Nombre colección]
					FROM [INDUSTRIAS COSMIC, S_A_U_$Item]
					WHERE ([No_] = @Producto)),''))
        end
	
	RETURN ISNULL(@vRes,'')


END







GO

/****** Object:  UserDefinedFunction [dbo].[fncProdOFPed]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncProdOFPed] 
(
	@Pedido  varchar(20),
	@Linea int
)
RETURNS varchar(20)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@Res int,
		@Count int,
		@OFL varchar(20)
		
		

    Set @Res = 0
    Set @OFL = ''
	SELECT top(1) @OFL = [No_]
	FROM [INDUSTRIAS COSMIC, S_A_U_$Production Order]
	Where ([Pedido Venta] = @Pedido) AND ([Linea Pedido Venta] = @Linea)
	--GROUP BY [Pedido Venta], [Linea Pedido Venta]

    set @Res = @@Rowcount
    
	RETURN ISNULL(@OFL,'')

END


GO

/****** Object:  UserDefinedFunction [dbo].[fncPaymentTerms]    Script Date: 11/18/2014 20:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--  payment Terms
CREATE FUNCTION [dbo].[fncPaymentTerms] 
(
	@Codigo nvarchar(50),
	@Idioma nvarchar(20)
)
RETURNS varchar(200)
AS
BEGIN
    	DECLARE @Traduc varchar(200)
        DECLARE @metodoPago varchar(200)
	
		
		SELECT  @Traduc = isnull(T.texto,PT.Description)
		FROM    [INDUSTRIAS COSMIC, S_A_U_$Payment Terms] as PT
		INNER JOIN [INDUSTRIAS COSMIC, S_A_U_$Traducciones] as T ON (T.tipo = 0) and (T.Código = @Codigo ) and (T.[Cód_ Idioma] =@Idioma)
		WHERE     (PT.Code = @Codigo)
		
		
		
	
	RETURN ISNULL(@Traduc,'')

END

























GO

/****** Object:  UserDefinedFunction [dbo].[fncPayment]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--  payment method
CREATE FUNCTION [dbo].[fncPayment] 
(
	@Codigo nvarchar(50),
	@Idioma nvarchar(20)
)
RETURNS varchar(200)
AS
BEGIN
    	DECLARE @Traduc varchar(200)
        DECLARE @metodoPago varchar(200)
		
	
		SELECT  @Traduc = isnull(T.texto,PM.Description)
		FROM    [INDUSTRIAS COSMIC, S_A_U_$Payment Method] as PM
		INNER JOIN [INDUSTRIAS COSMIC, S_A_U_$Traducciones] as T ON (T.tipo = 1) and (T.Código = @Codigo ) and (T.[Cód_ Idioma] =@Idioma)
		WHERE     (PM.Code = @Codigo)
	
	
	RETURN ISNULL(@Traduc,'')

END

























GO

/****** Object:  UserDefinedFunction [dbo].[fnccalculImportLinia]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fnccalculImportLinia] 
(
	@Mostrar tinyint,
	@UnitPrice decimal (18,4),
	@CantPendent decimal (18,4),
	@tipusdt decimal (18,4),
	@DtoFa decimal (18,4),
	@DtoPP decimal (18,4)
)
RETURNS decimal (18,2)
AS
BEGIN
    DECLARE @Import1 decimal (18,2)
    DECLARE @DecDto decimal (18,2)
    DECLARE @Resultat decimal (18,2)
   	

	--IF (@Cant <> @CantPendent)
	--	begin
 --          set @Import1 = (@UnitPrice * @CantPendent)
	--	   if @tipusdt <> 0
	--		  begin
	--		   	set @DecDto = (@Import1 * @tipusdt) / 100
	--		   	set @DecDto = (-1)*@DecDto
	--		  end
	--		if @tipusdt = 0
	--		  begin  
	--		    set @DecDto = 0
	--		  end
	--		set @Resultat = @Import1 + @DecDto 
	--	end	
 --   IF (@Cant = @CantPendent)
	--	begin
 --          set @Resultat = @Amount 
 --            if (abs(@Resultat - @LineAmount) = 0.01) or (@Amount=0)
 --             begin
 --              set @Resultat = @LineAmount
 --             end;
 --          --set @Resultat = @Resultat - @LineAmount
	--	end		
	--RETURN ISNULL(@Resultat,0)
	
 IF (@Mostrar=0)
	begin
           set @Import1 = (@UnitPrice * @CantPendent)
		   if @tipusdt <> 0
			  begin
			   	set @DecDto = (@Import1 * @tipusdt) / 100
			   	set @DecDto = (-1)*@DecDto
			  end
			if @tipusdt = 0
			  begin  
			    set @DecDto = 0
			  end
			set @Resultat = @Import1 + @DecDto 
    end
IF (@Mostrar=1)
	begin
           set @Import1 = (@UnitPrice * @CantPendent)
		   if @tipusdt <> 0
			  begin
			   	set @DecDto = (@Import1 * @tipusdt) / 100
			   	set @DecDto = (-1)*@DecDto
			  end
			if @tipusdt = 0
			  begin  
			    set @DecDto = 0
			  end
			set @Resultat = @Import1 + @DecDto - @DtoFa - @DtoPP
    end	
    RETURN ISNULL(@Resultat,0)	

END

























GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_InciPPT]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[fncProdSD_InciPPT] 
(	
	@OFL varchar(20),
	@IP varchar(30),
	@Compo varchar(30)
)
RETURNS varchar(150)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vPPT varchar(20),
		@vRes varchar(150),
		@vAnul varchar(20)
		
		set @vPPT = '**Inex**'
		set @vAnul = '**Inex**'
		set @vRes = ''

		if @Compo = ''
			begin
				SELECT Top(1) @vPPT = isnull(PPT,'**Inex**')
				FROM ProdSD_Incidencias
				WHERE (OFL = @OFL) AND (IP = @IP)
			end
		if @Compo <> ''
			begin
				SELECT Top(1) @vPPT = isnull(PPT,'**Inex**')
				FROM ProdSD_Incidencias
				WHERE (OFL = @OFL) AND (IP = @IP) AND (Compo = @Compo)
			end
			
		if @vPPT = '**Inex**'
			begin
				set @vRes = ''
			end
		if @vPPT <> '**Inex**'
			begin
				set @vRes = @vPPT
			end

		SELECT Top(1) @vAnul = isnull(OFL,'**Inex**')
		FROM ProdSD_Incidencias
		WHERE (OFL = @OFL) AND (IP = '')
			
			
		if @vAnul <> '**Inex**'
			begin
				set @vRes = '9999'
			end
		

RETURN ISNULL(@vRes,'')


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncDescription]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncDescription] 
(
	@Codtem nvarchar(20),
	@Idioma nvarchar(20)
)
RETURNS varchar(200)
AS
BEGIN
    	DECLARE @Descript varchar(300)
    	
 
		SELECT  @Descript = isnull(Art.Texto,'')+' '+isnull(Acab.Texto,'')+' '+Item.[Texto medidas]+' '+Item.[Descripción libre]
		FROM       [INDUSTRIAS COSMIC, S_A_U_$Item] as Item
		LEFT OUTER JOIN [INDUSTRIAS COSMIC, S_A_U_$Textos Artículos] as Art 
		ON (Art.[Cód_ Artículo]= Item.[Cód_ Artículo]) and (Art.[Cód_ Idioma] = @Idioma)
		LEFT OUTER JOIN [INDUSTRIAS COSMIC, S_A_U_$Textos Acabados] as Acab 
		ON (Acab.[Cód_ Acabado]= Item.[Cód Acabado]) and (Acab.[Cód_ Idioma] = @Idioma)
		WHERE     ([No_] = @Codtem) and (Item.[Descrip básica en Imp]=0) 
			
	RETURN ISNULL(@Descript,'')
	

END

























GO

/****** Object:  UserDefinedFunction [dbo].[fncTraduc]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create FUNCTION [dbo].[fncTraduc] 
(
	@Codigo nvarchar(50),
	@Idioma nvarchar(20)
)
RETURNS varchar(200)
AS
BEGIN
    	DECLARE @Traduc varchar(200)

		SELECT  @Traduc = isnull(Traduc,'')
		FROM         TraducTextos
		WHERE     (Idioma = @Idioma) AND (Texto = @Codigo)
	
	RETURN ISNULL(@Traduc,'')

END

























GO

/****** Object:  UserDefinedFunction [dbo].[fncPed_RM]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[fncPed_RM] 
(
	@Ped nvarchar(20),
	@LinPed int
)
RETURNS nvarchar(50)
AS
BEGIN
	-- Declare the return variable here
	declare @ProdCial nvarchar(50)


	SELECT @ProdCial = isnull([Ref_ con +],'')
	FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
	WHERE ([Document No_] = @Ped) AND ([Line No_] = @LinPed ) AND (Parentesco = 1)
	
	if (@ProdCial <> '')
	begin
		Set @ProdCial = @Ped + '#' + convert(varchar(20),@LinPed) + '#' + @ProdCial 
	end
	
	RETURN ISNULL(@ProdCial ,'')

END






























GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_CC]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Batch submitted through debugger: SQLQuery145.sql|7|0|C:\Users\JMEscorihuela.COSMIC\AppData\Local\Temp\~vsA527.sql


CREATE FUNCTION [dbo].[fncProdSD_CC] 
(	
	@OFL   varchar(20),
    @Campo varchar(20)
)
RETURNS varchar(100)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vDato varchar(100),
		@vEstado varchar(20),
		@vFecha varchar(20),
		@vUsuario varchar(50),
		@vDesCC varchar(100),
		@vEntregada varchar(20)
		
		
		set @vDato	= ''
		set @vEstado = ''
		set @vFecha = ''
		set @vUsuario = ''
		set @vDesCC = ''
		set @vEntregada = '0'
		
		SELECT @vEstado=Estado, @vFecha=Fecha, @vUsuario=Usuario, @vDesCC=DesCC, @vEntregada=Entregada
		FROM ProdSD_ControlCalidad
		WHERE (OFL = @OFL)
		
		
		IF @Campo = 'Estado'
		begin
		  set @vDato = @vEstado
		end

		IF @Campo = 'Fecha'
		begin
		  set @vDato = @vFecha
		end
		
		IF @Campo = 'Usuario'
		begin
			set @vDato = @vUsuario
		end
		
		IF @Campo = 'DesCC'
		begin
			set @vDato = @vDesCC
		end

		IF @Campo = 'Entregada'
		begin
			set @vDato = @vEntregada
		end

		
RETURN ISNULL(@vDato,'')


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_CompoURG]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncProdSD_CompoURG] 
(	
    @Compo varchar(20),
    @URG int
)
RETURNS decimal(12,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vCan decimal(12,2)
		
		SELECT @vCan=ISNULL(SUM(tLinPed.[Outstanding Quantity]), 0)
		FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line] AS tLinPed RIGHT OUTER JOIN
			  [INDUSTRIAS COSMIC, S_A_U_$Production Order] AS tCabOFL ON tLinPed.[Document No_] = tCabOFL.[Pedido Venta] AND 
			  tLinPed.[Line No_] = tCabOFL.[Linea Pedido Venta] RIGHT OUTER JOIN
			  [INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Component] AS tLinCompo ON tCabOFL.No_ = tLinCompo.[Prod_ Order No_]
		WHERE (tLinCompo.[Item No_] = @Compo) 
				AND (tLinPed.Urgente = @URG)
				AND (tLinCompo.[Remaining Quantity] <> 0) 
				AND (tCabOFL.Status > 0 AND tCabOFL.Status < 3)


RETURN ISNULL(@vCan,0)


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncCdadCompoLanz2]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncCdadCompoLanz2] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStock decimal(18,2)

	if @Almacen > ''
	begin
		SELECT @vStock = s61
			FROM [INDUSTRIAS COSMIC, S_A_U_$5407$2] AS Mov 
			WHERE (bucket = 5) AND (f1 = 3) AND (f11 = @Producto)  AND (f30 = @Almacen) 
					AND (f50002 = CONVERT(DATETIME, '1753-01-01 00:00:00', 102))
	end
	if @Almacen = ''
	begin
		SELECT @vStock = SUM(s61)
			FROM [INDUSTRIAS COSMIC, S_A_U_$5407$2] AS Mov 
			WHERE (bucket = 5) AND (f1 = 3) AND (f11 = @Producto)
					AND (f50002 = CONVERT(DATETIME, '1753-01-01 00:00:00', 102))
	end

	RETURN ISNULL(@vStock,0)


END


GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_DatOFL]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Batch submitted through debugger: SQLQuery145.sql|7|0|C:\Users\JMEscorihuela.COSMIC\AppData\Local\Temp\~vsA527.sql


CREATE FUNCTION [dbo].[fncProdSD_DatOFL] 
(	
	@OFL   varchar(20),
    @Campo varchar(20)
)
RETURNS varchar(20)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vDato varchar(20),
		@vFecha datetime,
		@vPedido varchar(20),
		@vLinea int,
		@vCanPen decimal(20,4),
		@vCan decimal(20,4)
		
		set @vDato	= ''
		
			SELECT top(1) @vPedido=[Pedido Venta],@vLinea=[Linea Pedido Venta],
						  @vCanPen=[Remaining Quantity],@vCan=[Quantity]
			FROM [INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Line]
			WHERE ([Prod_ Order No_] = @OFL)
			
		IF @Campo = 'CanP'
		begin
		  set @vDato = @vCanPen
		end

		IF @Campo = 'Can'
		begin
		  set @vDato = @vCan
		end
		
		IF @Campo = 'PV'
		begin
			set @vDato = @vPedido
		end
		
		IF @Campo = 'LIN'
		begin
			set @vDato = @vLinea
		end
		
RETURN ISNULL(@vDato,'')


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_DatoLinPed_OFL]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Batch submitted through debugger: SQLQuery145.sql|7|0|C:\Users\JMEscorihuela.COSMIC\AppData\Local\Temp\~vsA527.sql


CREATE FUNCTION [dbo].[fncProdSD_DatoLinPed_OFL] 
(	
	@OFL   varchar(20),
    @Campo varchar(20)
)
RETURNS varchar(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vDato varchar(50),
		@vFecha datetime,
		@vPedido varchar(20),
		@vLinea int
		
		set @vDato	= ''
		
			SELECT top(1) @vPedido=[Pedido Venta],@vLinea=[Linea Pedido Venta]
			--FROM [INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Line]
			FROM [INDUSTRIAS COSMIC, S_A_U_$Production Order]			
			WHERE (No_ = @OFL)
			--WHERE ([Prod_ Order No_] = @OFL)
			
		IF @Campo = 'CC' or @Campo = 'RM' or @Campo = 'RMP' 
		begin
			set @vDato =isnull(dbo.fncProdSD_DatoLinPed(@vPedido,@vLinea,@Campo),'')
		end
		
		IF @Campo = 'PV'
		begin
			set @vDato = @vPedido
		end
		
		IF @Campo = 'LIN'
		begin
			set @vDato = @vLinea
		end
		
RETURN ISNULL(@vDato,'')


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_DatoLinPed]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Batch submitted through debugger: SQLQuery145.sql|7|0|C:\Users\JMEscorihuela.COSMIC\AppData\Local\Temp\~vsA527.sql


CREATE FUNCTION [dbo].[fncProdSD_DatoLinPed] 
(	
	@Pedido   varchar(20),
    @Linea int,
    @Campo varchar(20)
)
RETURNS varchar(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vDato varchar(50),
		@vDato2 varchar(50),
		@vFecha datetime,
		@viDato int
		
		set @vDato	= ''
		set @vDato2	= ''
		set @vFecha = ''
		
		if @Campo = 'Urgente'
		begin			
			SELECT  @vDato = isnull(Urgente,'False')
			FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
			WHERE ([Document No_] = @Pedido) AND ([Line No_] = @Linea)
			if @vDato = '' begin set @vDato = 'false' end
			if @vDato = '0' begin set @vDato = 'false' end
			if @vDato = '1' begin set @vDato = 'true' end
				
		end		
		
		--DATEDIFF(day,convert(datetime, '2005-12-31 23:59:59.999',102),convert(datetime, '2005-12-15 00:00:00.000',102));
		
		if @Campo = 'Plazo Estándar'
		begin			
			SELECT  @vDato = [Plazo Estándar]
			FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
			WHERE ([Document No_] = @Pedido) AND ([Line No_] = @Linea)		
			if @vDato = '' begin set @vDato = convert(datetime, '1753-01-01 00:00:00',102) end
		end		
		if @Campo = 'Plazo EOP'
		begin			
			SELECT  @vDato = [Plazo Estándar],@vDato2=[Plazo Producción],@viDato=DATEDIFF(day,[Plazo Estándar],[Plazo Producción])
			FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
			WHERE ([Document No_] = @Pedido) AND ([Line No_] = @Linea)
			if (@viDato < 0)
			begin
			   Set @vDato = @vDato2
			end
			
			if @vDato = '' begin set @vDato = convert(datetime, '1753-01-01 00:00:00',102) end
		end		

		if @Campo = 'CC'
		begin			
			SELECT  @vDato = isnull([Control Calidad],'')
			FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
			WHERE ([Document No_] = @Pedido) AND ([Line No_] = @Linea)				
		end		

		if @Campo = 'RM'
		begin			
			SELECT  @vDato = isnull([Ref_ con +],'')
			FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
			WHERE ([Document No_] = @Pedido) AND ([Line No_] = @Linea)				
		end		

		if @Campo = 'RMP'
		begin			
			SELECT  @vDato = isnull([Ref_ con +],''),@vDato2 = isnull([Nº Lin Ref con +],'') 			
			FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
			WHERE ([Document No_] = @Pedido) AND ([Line No_] = @Linea)				
			if @vDato <>'' begin set @vDato = @Pedido + '#' + @vDato2 + '#' + @vDato end
		end		


RETURN ISNULL(@vDato,'')


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdPrevi]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION [dbo].[fncProdPrevi] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,4)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vPrevi decimal(18,4)

	set @vPrevi = 0

	if @Almacen > ''
	begin
		SELECT @vPrevi = round(isnull(s8,0),0)
		FROM  [INDUSTRIAS COSMIC, S_A_U_$99000852$0]
		WHERE (f3 = @Producto) AND (bucket = 3) AND (f10 = @Almacen)			
	end
	if @Almacen = ''
	begin
		SELECT @vPrevi = sum(round(isnull(s8,0),0))
		FROM  [INDUSTRIAS COSMIC, S_A_U_$99000852$0]
		WHERE (f3 = @Producto) AND (bucket = 3)			
	end

	RETURN ISNULL(@vPrevi,0)


END







GO

/****** Object:  UserDefinedFunction [dbo].[fncProdOFabPV]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION [dbo].[fncProdOFabPV] 
(
	@Producto nvarchar(20),
	@Pedido  varchar(20),
	@Linea int
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vCan decimal(18,2)
		

    Set @vCan = 0
	SELECT @vCan = SUM([Remaining Quantity])
	FROM [INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Line]
	GROUP BY [Pedido Venta], [Linea Pedido Venta], [Item No_]
	HAVING ([Pedido Venta] = @Pedido) AND ([Linea Pedido Venta] = @Linea)

	RETURN ISNULL(@vCan,0)

END


GO

/****** Object:  UserDefinedFunction [dbo].[fncProdOFabDH]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION [dbo].[fncProdOFabDH] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20),
	@DesdeEstatus int,
	@HastaEstatus int
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vCan decimal(18,2),
		@vDesdeStatus int,
		@vHastaStatus int
		
    set @vDesdeStatus = @DesdeEstatus
    set @vHastaStatus = @HastaEstatus
    

    Set @vCan = 0
	if @Almacen > ''
	begin
		SELECT @vCan = SUM([Remaining Quantity])
		FROM [INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Line]
		Where (Status >= @vDesdeStatus and Status <= @vHastaStatus) 
		GROUP BY [Item No_], [Location Code]
		HAVING ([Item No_] = @Producto) AND ([Location Code] = @Almacen) AND (SUM([Remaining Quantity]) > 0)	
	end
	
	if @Almacen = ''
	begin
		SELECT @vCan = SUM([Remaining Quantity])
		FROM [INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Line]
		Where (Status >= @vDesdeStatus and Status <= @vHastaStatus) 
		GROUP BY [Item No_]
		HAVING ([Item No_] = @Producto) AND (SUM([Remaining Quantity]) > 0)
	end

	RETURN ISNULL(@vCan,0)

END




GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_OFLReg]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







CREATE FUNCTION [dbo].[fncProdSD_OFLReg] 
(	
	@OFL   varchar(20),
	@Tipo  varchar(10)

)
RETURNS varchar(20)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vRes varchar(20)
		Set @vRes=''
        if @Tipo = 'C'
			begin
			
				SELECT @vRes = convert(varchar(20),SUM(Cantidad))
				FROM  ProdSD_OFL_Reg
				GROUP BY OFL
				HAVING (OFL = @OFL)
				ORDER BY OFL				
			end

        if @Tipo = 'FR'
			begin			
				SELECT @vRes = convert(varchar(20),MAX(FechaReg),103)
				FROM  ProdSD_OFL_Reg
				GROUP BY OFL
				HAVING (OFL = @OFL)
				ORDER BY OFL				
			end
        if @Tipo = 'HR'
			begin			
				SELECT top(1) @vRes = convert(varchar(20),HoraReg)
				FROM  ProdSD_OFL_Reg
				GROUP BY OFL,FechaReg,HoraReg
				HAVING (OFL = @OFL)
				ORDER BY FechaReg desc				
			end
        if @Tipo = 'FRN'
			begin			
				SELECT @vRes = convert(varchar(20),MAX(FechaRegNavi),103)
				FROM  ProdSD_OFL_Reg
				GROUP BY OFL
				HAVING (OFL = @OFL)
				ORDER BY OFL				
			end


RETURN ISNULL(@vRes,'')


END

















GO

/****** Object:  UserDefinedFunction [dbo].[fncCdadCompoPlan]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncCdadCompoPlan] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStock decimal(18,2)

	if @Almacen > ''
	begin
		SELECT @vStock = sum(s61)
			FROM [INDUSTRIAS COSMIC, S_A_U_$5407$2] AS Mov 
			WHERE (bucket = 3) AND (f1 = 1 or f1 = 2) AND (f11 = @Producto)  AND (f30 = @Almacen)
	end
	if @Almacen = ''
	begin
		SELECT @vStock = SUM(s61)
			FROM [INDUSTRIAS COSMIC, S_A_U_$5407$2] AS Mov 
			WHERE (bucket = 3) AND (f1 = 1 or f1 = 2) AND (f11 = @Producto)
	end

	RETURN ISNULL(@vStock,0)


END


GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_Mecanizados]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncProdSD_Mecanizados] 
(	
	@IP    varchar(50),
	@Tipo  varchar(20)
)
RETURNS varchar(200)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vMeca varchar(200)
		set @vMeca = ''
		if @Tipo = 'BU'
		begin
			SELECT @vMeca = Mec.[MATRIZ ] + ' - ' + Mec.TOPE + ' - ' + Mec.[SECUENCIA MECANIZADO] + ' - ' + Mec.[INSTRUCCIÓN MECANIZADO]
			FROM  [INDUSTRIAS COSMIC, S_A_U_$IP Header] AS cIP LEFT OUTER JOIN
				  ProdSD_Mecanizados AS Mec ON cIP.Usuario = Mec.IP
			WHERE (cIP.No_ = @IP)
		end
		
		if @Tipo = 'CC'
		begin
			SELECT @vMeca = Mec.[CONTROL CALIDAD]
			FROM  [INDUSTRIAS COSMIC, S_A_U_$IP Header] AS cIP LEFT OUTER JOIN
				  ProdSD_Mecanizados AS Mec ON cIP.Usuario = Mec.IP
			WHERE (cIP.No_ = @IP)
		end

RETURN ISNULL(@vMeca,'')


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSt]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncProdSt] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,4)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStock decimal(18,4),
		@vStockAlm decimal(18,4),
		@vCdaLanz decimal(18,4),
		@vStockLibre decimal(18,4),
		@vAlm nvarchar(20)

	set @vStock = 0
	set @vStockAlm = 0
	set @vCdaLanz = 0

	if @Almacen > ''
	begin
		SELECT @vStock = isnull(s12,0)
			FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] AS Mov 
			WHERE (bucket = 4) AND (f2 = @Producto)  AND (f8 = @Almacen)
			
			--Cursor de Almacenes Anexos	
			Declare cAlms Cursor for
				SELECT Code
				FROM [INDUSTRIAS COSMIC, S_A_U_$Location]
				WHERE ([Suma Stock a Almacen] = @Almacen)	
				
			--Recorre cursor de Almacenes
			Open cAlms

			Fetch Next From cAlms
				Into @vAlm

			While @@Fetch_Status = 0
			Begin
		    
				set @vStockAlm = 0
				SELECT @vStockAlm = isnull(s12,0)
					FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] AS Mov 
					WHERE (bucket = 4) AND (f2 = @Producto)  AND (f8 = @vAlm)
						
				set @vStock = @vStock + @vStockAlm
					
				Fetch Next From cAlms
					Into @vAlm

			end
			Close cAlms
			Deallocate cAlms	
	
	
	
	
	
		
		

	end
	if @Almacen = ''
	begin
		SELECT @vStock = isnull(s12,0)
			FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] AS Mov 
			WHERE (bucket = 3) AND (f2 = @Producto)
		
	end
	set @vStockLibre = @vStock

	RETURN ISNULL(@vStockLibre,0)


END







GO

/****** Object:  UserDefinedFunction [dbo].[fncProdOFabPlanif]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION [dbo].[fncProdOFabPlanif] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vCan decimal(18,2)

    Set @vCan = 0
	if @Almacen > ''
	begin
		SELECT @vCan = SUM(Quantity)
		FROM [INDUSTRIAS COSMIC, S_A_U_$Requisition Line]
		GROUP BY [No_], [Location Code]
		HAVING ([No_] = @Producto) AND ([Location Code] = @Almacen) AND (SUM(Quantity) > 0)		
	end
	
	if @Almacen = ''
	begin
		SELECT @vCan = SUM(Quantity)
		FROM [INDUSTRIAS COSMIC, S_A_U_$Requisition Line]
		GROUP BY [No_]
		HAVING ([No_] = @Producto) AND (SUM(Quantity) > 0)		
	end

	RETURN ISNULL(@vCan,0)

END




GO

/****** Object:  UserDefinedFunction [dbo].[fncProdOFabPen]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncProdOFabPen] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20),
	@Estatus int
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vCan decimal(18,2),
		@vDesdeStatus int,
		@vHastaStatus int
		
    set @vDesdeStatus = 0
    set @vHastaStatus = 8
    
    if @Estatus <> 0
       begin
			set @vDesdeStatus = @Estatus
			set @vHastaStatus = @Estatus
       end		

    Set @vCan = 0
	if @Almacen > ''
	begin
		SELECT @vCan = SUM([Remaining Quantity])
		FROM [INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Line]
		Where (Status >= @vDesdeStatus and Status <= @vHastaStatus) 
		GROUP BY [Item No_], [Location Code]
		HAVING ([Item No_] = @Producto) AND ([Location Code] = @Almacen) AND (SUM([Remaining Quantity]) > 0)	
	end
	
	if @Almacen = ''
	begin
		SELECT @vCan = SUM([Remaining Quantity])
		FROM [INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Line]
		Where (Status >= @vDesdeStatus and Status <= @vHastaStatus) 
		GROUP BY [Item No_]
		HAVING ([Item No_] = @Producto) AND (SUM([Remaining Quantity]) > 0)
	end

	RETURN ISNULL(@vCan,0)

END




GO

/****** Object:  UserDefinedFunction [dbo].[fncProdCompraPen]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncProdCompraPen] 
(
	@Producto nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vCan decimal(18,2)

		SELECT @vCan = SUM(isnull([Outstanding Quantity],0))
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Purchase Line]
		WHERE     (No_ = @Producto)

	RETURN ISNULL(@vCan,0)

END




GO

/****** Object:  UserDefinedFunction [dbo].[fncProdStLibre3]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncProdStLibre3] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,4)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStock decimal(18,4),
		@vCdaLanz decimal(18,4),
		@vStockLibre decimal(18,4),
		@vCompo int

	set @vStock = 0
	set @vCdaLanz = 0


	SELECT @vCompo = isnull(Componente,0)
	FROM [INDUSTRIAS COSMIC, S_A_U_$Item]
	WHERE (No_ = @Producto)

	if @Almacen > ''
	begin
		SELECT @vStock = isnull(s12,0)
			FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] AS Mov 
			WHERE (bucket = 4) AND (f2 = @Producto)  AND (f8 = @Almacen)
		
		if (@vCompo = 1)
		begin
			SELECT @vCdaLanz = isnull(s61,0)
				FROM [INDUSTRIAS COSMIC, S_A_U_$5407$2] AS Mov 
				WHERE (bucket = 3) AND (f1 = 3) AND (f11 = @Producto)  AND (f30 = @Almacen)
		end
		
			
		if (@vCompo = 0)
		begin
			SELECT @vCdaLanz = s16
				FROM [INDUSTRIAS COSMIC, S_A_U_$37$2] AS Mov 
				WHERE (bucket = 4) and (f5 = 2) and (f1 = 1) AND (f6 = @Producto)  AND (f7 = @Almacen)
		end
			

	end
	if @Almacen = ''
	begin
		SELECT @vStock = isnull(s12,0)
			FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] AS Mov 
			WHERE (bucket = 3) AND (f2 = @Producto)
		
		if (@vCompo = 1)
		begin
			SELECT @vCdaLanz = isnull(SUM(s61),0)
				FROM [INDUSTRIAS COSMIC, S_A_U_$5407$2] AS Mov 
				WHERE (bucket = 3) AND (f1 = 3) AND (f11 = @Producto)
		end


		if (@vCompo = 0)
		begin
			SELECT @vCdaLanz = s16
				FROM [INDUSTRIAS COSMIC, S_A_U_$37$2] AS Mov 
				WHERE (bucket = 3) and (f5 = 2) and (f1 = 1) AND (f6 = @Producto)
		end
			

	end
	set @vStockLibre = @vStock - @vCdaLanz

	RETURN ISNULL(@vStockLibre,0)


END






GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_IpRegIP_2]    Script Date: 11/18/2014 20:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







CREATE FUNCTION [dbo].[fncProdSD_IpRegIP_2] 
(	
	@IP    varchar(20),
	@OFL   varchar(20),
    @Carro varchar(20)

)
RETURNS decimal(12,4)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vReg decimal(12,4)

        if @OFL = ''
			begin
				SELECT @vReg = Sum(Registrado)
				FROM ProdSD_Produccion_IP With(NoLock)
				WHERE (Compo = @IP) AND (Carro = @Carro)
			end

        if @OFL <> ''
			begin
				SELECT @vReg = Sum(Registrado)
				FROM ProdSD_Produccion_IP With(NoLock)
				WHERE (Compo = @IP) AND (OFL = @OFL)
			end


RETURN ISNULL(@vReg,0)


END

















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdUbiAdi]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncProdUbiAdi] 
(	
	@Prod    varchar(20)
)
RETURNS varchar(250)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@Res varchar(250),
		@vAdi varchar(20),
		@vPalet varchar(20)
		Set @Res = ''

	--Cursor de Adicional
	Declare cAdi Cursor for
		SELECT TOP (10) [Cód_ Situación],[Matrícula Palet]
		FROM [INDUSTRIAS COSMIC, S_A_U_$Zona Adicional]
		WHERE (Nº = @Prod) and ([Cód_ Almacén Físico] = 'COSMIC')
		GROUP BY [Cód_ Situación],[Matrícula Palet]
	
	--Recorre cursor de Adicional
	Open cAdi

	Fetch Next From cAdi
		Into @vAdi,@vPalet

	While @@Fetch_Status = 0
	Begin
		set @Res = @Res + '-' + @vAdi + ' (' + @vPalet + ')'; 
		
		Fetch Next From cAdi
			Into @vAdi,@vPalet
	end	
	Close cAdi
	Deallocate cAdi
	--Fin del cursor de Adicional
	
		
RETURN ISNULL(@Res,'')


END
GO

/****** Object:  UserDefinedFunction [dbo].[fncProdTraducSIP]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create FUNCTION [dbo].[fncProdTraducSIP] 
(	
	@Prod    varchar(20)
)
RETURNS varchar(30)
AS
BEGIN
	-- Declare the return variable here
	-- Es Padre
	DECLARE 
		@Res int,
		@Es varchar(40)
		
		Set @Res = 0
				
		SELECT  Top(1) @Es = isnull(ProdCosmic,'')
		FROM SD_FinSIP_Traduc_Prod
		WHERE  (ProdSIP = @Prod)				
				
				
		if (@Es = '')
			Begin
				Set @Es = @Prod
			end
		
RETURN ISNULL(@Es,@Prod)

END
GO

/****** Object:  UserDefinedFunction [dbo].[fncProdEsPadre]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncProdEsPadre] 
(	
	@Prod    varchar(20)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	-- Es Padre
	DECLARE 
		@Res int,
		@Es varchar(40)
		
		Set @Res = 0
				
		SELECT  Top(1) @Es = isnull([Ref_ Comercial],'')
		FROM [INDUSTRIAS COSMIC, S_A_U_$Ref_ con más de1bulto]
		WHERE ([Ref_ Comercial] = @Prod)				
				
		if (@Es <> '')
			Begin
				Set @Res = 1
			end
		
RETURN ISNULL(@Res,0)

END
GO

/****** Object:  UserDefinedFunction [dbo].[fncProdEsHijo]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncProdEsHijo] 
(	
	@Prod    varchar(20)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	-- Es Hijo
	DECLARE 
		@Res int,
		@Es varchar(40)
		
		Set @Res = 0
		
		SELECT  Top(1) @Es = isnull([Ref_ Bulto],'')
		FROM [INDUSTRIAS COSMIC, S_A_U_$Ref_ con más de1bulto]
		WHERE ([Ref_ Bulto] = @Prod)				
				
		if (@Es <> '')
			Begin
			Set @Res = 1
			end
		
RETURN ISNULL(@Res,0)

END
GO

/****** Object:  UserDefinedFunction [dbo].[fncProdStockCMP2]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncProdStockCMP2] 
(
	@Producto nvarchar(20),
	@Fecha nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS varchar(150)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStock decimal(18,2)
		
	set @vStock = 0

	if @Almacen > ''
	begin
		set @Almacen = replace(@Almacen,'"','''')
		--set @Almacen = replace(@Almacen,'.',',')
        SELECT @vStock = Sum(s12) 
                    FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] 
                    WHERE (f3 <= CONVERT(DATETIME, @Fecha + ' 00:00:00', 102)) 
							AND (f8 not in (@Almacen))
                    Group By bucket,f2 
                    HAVING (f2 = @Producto) AND (bucket = 8)

		

	end
	if @Almacen = ''
	begin
        SELECT @vStock = Sum(s12) 
                    FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] 
                    WHERE (f3 <= CONVERT(DATETIME, @Fecha + ' 00:00:00', 102)) 
                    Group By bucket,f2 
                    HAVING (f2 = @Producto) AND (bucket = 8)
		

	end

	RETURN ISNULL(@Almacen,'')


END







GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_EsInci]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncProdSD_EsInci] 
(	
	@OFL varchar(20),
	@IP varchar(30),
	@Compo varchar(30)
)
RETURNS bit
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vDesInci varchar(200),
		@vDesInciOFL varchar(200),
		@vRes bit
		
		set @vDesInci = '**Inex**'
		set @vDesInciOFL = '**Inex**'
		set @vRes = 0

		if @Compo = ''
			begin
				SELECT Top(1) @vDesInci = isnull(DesInci,'**Inex**')
				FROM ProdSD_Incidencias
				WHERE (OFL = @OFL) AND (IP = @IP) AND (Estado = 'Pendiente')
			end
		if @Compo <> ''
			begin
				SELECT Top(1) @vDesInci = isnull(DesInci,'**Inex**')
				FROM ProdSD_Incidencias
				WHERE (OFL = @OFL) AND (IP = @IP) AND (Compo = @Compo) AND (Estado = 'Pendiente')
			end
			
			
		SELECT Top(1) @vDesInciOFL = isnull(DesInci,'**Inex**')
		FROM ProdSD_Incidencias
		WHERE (OFL = @OFL) AND (IP = '') AND (Compo = '') AND (Estado = 'Pendiente')
				
		if @vDesInciOFL <> '**Inex**'
			begin
				set @vDesInci = @vDesInciOFL
			end
			
		if @vDesInci = '**Inex**'
			begin
				set @vRes = 0
			end
		if @vDesInci <> '**Inex**'
			begin
				set @vRes = 1
			end
		

RETURN ISNULL(@vRes,0)


END




















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_DesInci]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncProdSD_DesInci] 
(	
	@OFL varchar(20),
	@IP varchar(30),
	@Compo varchar(30)
)
RETURNS varchar(150)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vDesInci varchar(200),
		@vDesInciOFL varchar(200),
		@vRes varchar(150)
		
		set @vDesInci = '**Inex**'
		set @vDesInciOFL = '**Inex**'
		set @vRes = ''

		if @Compo = ''
			begin
				SELECT Top(1) @vDesInci = isnull(DesInci,'**Inex**')
				FROM ProdSD_Incidencias
				WHERE (OFL = @OFL) AND (IP = @IP)
			end
		if @Compo <> ''
			begin
				SELECT Top(1) @vDesInci = isnull(DesInci,'**Inex**')
				FROM ProdSD_Incidencias
				WHERE (OFL = @OFL) AND (IP = @IP) AND (Compo = @Compo)
			end

		SELECT Top(1) @vDesInciOFL = isnull(DesInci,'**Inex**')
		FROM ProdSD_Incidencias
		WHERE (OFL = @OFL) AND (IP = '') AND (Compo = '') AND (Estado = 'Pendiente')
				
		if @vDesInciOFL <> '**Inex**'
			begin
				set @vDesInci = @vDesInciOFL
			end

			
		if @vDesInci = '**Inex**'
			begin
				set @vRes = ''
			end
		if @vDesInci <> '**Inex**'
			begin
				set @vRes = @vDesInci
			end
		

RETURN ISNULL(@vRes,'')


END




















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_Inci]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[fncProdSD_Inci] 
(	
	@ID    INT
)
RETURNS VARCHAR(20)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vTramite varchar(20),
		@vPed varchar(20)
		set @vTramite = ''
		set @vPed = ''

		SELECT TOP (1) @vTramite =  ISNULL([ID Incidencia],'')
		FROM [INDUSTRIAS COSMIC, S_A_U_$Requisition Line]
		WHERE ([ID Incidencia] = @ID)

		SELECT TOP (1) @vPed =  ISNULL([Document No_],'')
		FROM [INDUSTRIAS COSMIC, S_A_U_$Purchase Line]
		WHERE ([ID Incidencia] = @ID)
	
		if (@vPed = '')
			begin
				set @vPed = @vTramite
			end
		

RETURN ISNULL(@vPed,'')


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdCoste]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fncProdCoste] 
(
	@Producto nvarchar(20),
	@Fecha varchar(20),
	@Tipo varchar(2)
)
RETURNS decimal(18,5)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vPrecio decimal(18,5),
		@vFecha varchar(20)
		set @vFecha = @Fecha + ' 00:00:00'
		
		if @Fecha = ''
			begin
				if @Tipo = 'M' or @Tipo = ''
					begin 
						SELECT top(1) @vPrecio = isnull([Medio Ponderado (DL)],0)
						--FROM  [INDUSTRIAS COSMIC, S_A_U_$Costes Productos]
						FROM  [INDUSTRIAS COSMIC, S_A_U_$Histórico Costes Producto]
						WHERE ( [Nº] = @Producto)
						order by [Fecha C_M_P_] desc
					end
				--if @Tipo = 'O'
				--	begin 
				--		SELECT top(1) @vPrecio = isnull([Objetivo (DL)],0)
				--		--FROM  [INDUSTRIAS COSMIC, S_A_U_$Costes Productos]
				--		FROM  [INDUSTRIAS COSMIC, S_A_U_$Histórico Costes Producto]
				--		WHERE ( [Nº] = @Producto)
				--		order by [Fecha C_M_P_] desc
				--	end
				--if @Tipo = 'P'
				--	begin 
				--		SELECT top(1) @vPrecio = isnull([Prioritario (DL)],0)
				--		--FROM  [INDUSTRIAS COSMIC, S_A_U_$Costes Productos]
				--		FROM  [INDUSTRIAS COSMIC, S_A_U_$Histórico Costes Producto]
				--		WHERE ( [Nº] = @Producto)
				--		order by [Fecha C_M_P_] desc
				--	end
					
			end
			
			
		if @Fecha <> ''
			begin
				if @Tipo = 'M' or @Tipo = ''
					begin 
						SELECT top(1) @vPrecio = isnull([Medio Ponderado (DL)],0)
						--FROM  [INDUSTRIAS COSMIC, S_A_U_$Costes Productos]
						FROM  [INDUSTRIAS COSMIC, S_A_U_$Histórico Costes Producto]
						WHERE ( [Nº] = @Producto) AND ([Fecha C_M_P_] = CONVERT(DATETIME, @vFecha, 102))
					end
				--if @Tipo = 'O'
				--	begin 
				--		SELECT top(1) @vPrecio = isnull([Objetivo (DL)],0)
				--		--FROM  [INDUSTRIAS COSMIC, S_A_U_$Costes Productos]
				--		FROM  [INDUSTRIAS COSMIC, S_A_U_$Histórico Costes Producto]
				--		WHERE ( [Nº] = @Producto) AND ([Fecha C_M_P_] = CONVERT(DATETIME, @vFecha, 102))
				--	end
				--if @Tipo = 'P'
				--	begin 
				--		SELECT top(1) @vPrecio = isnull([Prioritario (DL)],0)
				--		--FROM  [INDUSTRIAS COSMIC, S_A_U_$Costes Productos]
				--		FROM  [INDUSTRIAS COSMIC, S_A_U_$Histórico Costes Producto]
				--		WHERE ( [Nº] = @Producto) AND ([Fecha C_M_P_] = CONVERT(DATETIME, @vFecha, 102))
				--	end
					
			end			

	RETURN ISNULL(@vPrecio,0)

END







GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_Restos]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create FUNCTION [dbo].[fncProdSD_Restos] 
(	
	@OFL   varchar(20),
    @Compo varchar(20)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vRestos decimal(12,2)
		
		SELECT @vRestos = Sum(Restos)
		FROM ProdSD_Produccion
		WHERE (OFL = @OFL) AND (Compo = @Compo)
		group by OFL,Compo

RETURN ISNULL(@vRestos,0)


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_CarroFin]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncProdSD_CarroFin] 
(	
    @Carro varchar(20)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vAProd int

		SELECT @vAProd = count(OFL)
		FROM ProdSD_Produccion_IP
		where (Carro = @Carro) AND (Estado = 1)

RETURN ISNULL(@vAProd,0)


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncRelpCanAlb]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fncRelpCanAlb] 
(
	@RocaPedido nvarchar(20),
	@RocaLinPed int
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vNS int

		set @vNS = 	convert(int,isnull((SELECT sum([Quantity])
								FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Shipment Line] AS LinVenta 
								WHERE ([Roca Pedido] = @RocaPedido) AND 
										([Roca nLin P] = @RocaLinPed) and 
										(Parentesco < 2) ),0))

	
	RETURN ISNULL(@vNS,0)


END









GO

/****** Object:  UserDefinedFunction [dbo].[fncRelpCanAnul]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fncRelpCanAnul] 
(
	@RocaPedido nvarchar(20),
	@RocaLinPed int
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vNS int

		set @vNS = dbo.fncRelpCanNueva(@RocaPedido,@RocaLinPed) - 
			    dbo.fncRelpCanAlb(@RocaPedido,@RocaLinPed)
				--convert(int,isnull((SELECT sum([Quantity])
				--				FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Shipment Line] AS LinVenta 
				--				WHERE ([Roca Pedido] = @RocaPedido) AND 
				--						([Roca nLin P] = @RocaLinPed)),0))

	
	RETURN ISNULL(@vNS,0)


END









GO

/****** Object:  UserDefinedFunction [dbo].[fncRelpCanNueva]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create FUNCTION [dbo].[fncRelpCanNueva] 
(
	@RocaPedido nvarchar(20),
	@RocaLinPed int
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vNS int

            set @vNS = CONVERT(int,ISNULL((SELECT Cantidad
            FROM [INDUSTRIAS COSMIC, S_A_U_$RELP]
            WHERE ([Status Línea] = 0) and ([Nº Pedido Roca] = @RocaPedido) AND 
					([Nº Lin Roca] = @RocaLinPed)),0))
	
	RETURN ISNULL(@vNS,0)


END








GO

/****** Object:  UserDefinedFunction [dbo].[fncProdEsMon]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create FUNCTION [dbo].[fncProdEsMon] 
(	
	@Prod    varchar(20)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@Res int
		Set @Res = 0
		Select  @Res = [Es montaje]
		FROM [INDUSTRIAS COSMIC, S_A_U_$Item] AS Producto
		Where Producto.[No_] = @Prod			
		
RETURN ISNULL(@Res,0)

END
GO

/****** Object:  UserDefinedFunction [dbo].[fncProdStockCMP]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncProdStockCMP] 
(
	@Producto nvarchar(20),
	@Fecha nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStock decimal(18,2),
		@vCom varchar(250)
			
	set @vStock = 0
	
	if @Almacen > ''	
	begin
        SELECT @vStock = Sum(s12) 
                    FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] 
                    WHERE (f3 <= CONVERT(DATETIME, @Fecha + ' 00:00:00', 102)) 
							AND (f8 not in (@Almacen))
                    Group By bucket,f2 
                    HAVING (f2 = @Producto) AND (bucket = 8)

		--select @vCom = 'SELECT Sum(s12) as Stock
		--					FROM [INDUSTRIAS COSMIC, S_A_U_$32$0]
		--					into #myTable 
		--					WHERE (f3 <= CONVERT(DATETIME, ''' + @Fecha + ' 00:00:00'', 102)) 
		--							AND (F8 NOT in (' + @Almacen + ' )) 
		--					Group By bucket,f2                   
		--					HAVING (f2 = ''' + @Producto + ''') AND (bucket = 8)'
							
		--EXEC Proc_Varios @vCom, @vStock		
	end
	if @Almacen = ''
	begin
        SELECT @vStock = Sum(s12) 
                    FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] 
                    WHERE (f3 <= CONVERT(DATETIME, @Fecha + ' 00:00:00', 102)) 
                    Group By bucket,f2 
                    HAVING (f2 = @Producto) AND (bucket = 8)
		

	end

	RETURN ISNULL(@vStock,0)


END







GO

/****** Object:  UserDefinedFunction [dbo].[fncProdTiMon]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncProdTiMon] 
(	
	@Prod    varchar(20),
	@Tipo varchar(1)
)
RETURNS varchar(20)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@Res varchar(20)
		Set @Res = ''
		if @Tipo = 'T'
			begin
				Select  @Res = isnull(convert(varchar,convert(money,tRuta.[Run Time])),'0')
						FROM [INDUSTRIAS COSMIC, S_A_U_$Item] AS Producto LEFT OUTER JOIN
							[INDUSTRIAS COSMIC, S_A_U_$Routing Line] AS tRuta ON 
							Producto.[Routing No_] = tRuta.[Routing No_]
						Where Producto.[No_] = @Prod			
			end
		if @Tipo = 'U'
			begin
				Select  @Res = tRuta.[Run Time Unit of Meas_ Code]
						FROM [INDUSTRIAS COSMIC, S_A_U_$Item] AS Producto LEFT OUTER JOIN
							[INDUSTRIAS COSMIC, S_A_U_$Routing Line] AS tRuta ON 
							Producto.[Routing No_] = tRuta.[Routing No_]
						Where Producto.[No_] = @Prod			
			end
		
RETURN ISNULL(@Res,'')


END
GO

/****** Object:  UserDefinedFunction [dbo].[fncEntraCSC]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fncEntraCSC] 
(
	@Producto nvarchar(20),
	@Fecha datetime
)
RETURNS decimal(18,5)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@Entradas decimal(18,5)

		SELECT @Entradas = SUM(Quantity)
		FROM  [INDUSTRIAS COSMIC, S_A_U_$Purch_ Rcpt_ Line] 
		WHERE ([Fecha registro] > @Fecha) and
				(No_ = @Producto) and
				([Direct Unit Cost] > 0) and 
				(([Buy-from Vendor No_] = '40003258') or
				 ([Buy-from Vendor No_] = '40018201') or
				 ([Buy-from Vendor No_] = '40020020') or
				 ([Buy-from Vendor No_] = '40020024')) and
				([Gen_ Prod_ Posting Group] <> 'RECUPERACI') AND 
				([Gen_ Prod_ Posting Group] <> 'MONTAJEEXT') 
		GROUP BY No_
		
		RETURN ISNULL(@Entradas,0)


END







GO

/****** Object:  UserDefinedFunction [dbo].[fncFactorCSC]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fncFactorCSC] 
(
	@Prov varchar(20),
	@Producto nvarchar(20),
	@Peri datetime
)
RETURNS decimal(18,5)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vFactor decimal(18,5),
		@vFecha varchar(20),
		@vAny varchar(20),
		@vMes varchar(20)
		
		set @vAny =convert(varchar,datepart(year,@Peri))
		set @vMes =convert(varchar,datepart(month,@Peri))	
			
		if Len(@vMes) = 1
			begin
				set @vMes = '0' + @vMes
			end
			
		set @vFactor = 1				
    	set @vFecha = @vAny + @vMes	
    				
		if @Prov = '40003258'
			begin
				SELECT  @vFactor = Factor
				FROM  AFactorCSC
				WHERE (Periodo = @vFecha)	
			end
		RETURN ISNULL(@vFactor,1)


END







GO

/****** Object:  UserDefinedFunction [dbo].[fncProdCostePon]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fncProdCostePon] 
(
	@Producto nvarchar(20),
	@Fecha varchar(20)
)
RETURNS decimal(18,5)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vPrecio decimal(18,5),
		@vFecha varchar(20)
		set @vFecha = @Fecha + ' 00:00:00'
		
		SELECT @vPrecio = isnull((SUM([Direct Unit Cost] * Quantity) / SUM(Quantity)),0)
		FROM  [INDUSTRIAS COSMIC, S_A_U_$Purch_ Rcpt_ Line]
		WHERE ([Fecha registro] > CONVERT(DATETIME, @vFecha, 102)) AND ([Direct Unit Cost] > 0)
		GROUP BY No_
		HAVING (No_ = @Producto)


	RETURN ISNULL(@vPrecio,0)


END







GO

/****** Object:  UserDefinedFunction [dbo].[fncProdCMP]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create FUNCTION [dbo].[fncProdCMP] 
(
	@Producto nvarchar(20)
)
RETURNS decimal(18,5)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vPrecio decimal(18,5)

		SELECT Top(1) @vPrecio = [Medio Ponderado (DL)]
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Costes Productos]
		WHERE     (Nº = @Producto)
		ORDER BY [Fecha C_M_P_] DESC
	RETURN ISNULL(@vPrecio,0)


END







GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_IpRegIP]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







CREATE FUNCTION [dbo].[fncProdSD_IpRegIP] 
(	
	@IP    varchar(20),
	@OFL   varchar(20),
    @Carro varchar(20)

)
RETURNS decimal(12,4)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vReg decimal(12,4)

        if @OFL = ''
			begin
				SELECT @vReg = Sum(Registrado)
				FROM ProdSD_Produccion_IP With(NoLock)
				WHERE (Compo = @IP) AND (Carro = @Carro)
			end

        if @OFL <> ''
			begin
				SELECT @vReg = Sum(Registrado)
				FROM ProdSD_Produccion_IP With(NoLock)
				WHERE (Compo = @IP) AND (OFL = @OFL)
			end


RETURN ISNULL(@vReg,0)


END

















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_Tipologia]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create FUNCTION [dbo].[fncProdSD_Tipologia] 
(	
	@IP    varchar(20)
)
RETURNS varchar(20)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vTipoLog varchar(20)

		SELECT @vTipoLog = isnull(Tipo,'')
		FROM [INDUSTRIAS COSMIC, S_A_U_$IP Header]
		WHERE (No_ = @IP)


RETURN ISNULL(@vTipoLog,'')


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdMedi]    Script Date: 11/18/2014 20:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncProdMedi] 
(	
	@Prod    varchar(20),
	@UM   varchar(20),
	@Tipo varchar(3)
)
RETURNS varchar(20)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@Res varchar(20)
		Set @Res = ''
		if @Tipo = 'L'
			begin
				Select Top(1) @Res = convert(varchar,convert(int,tUnid.[Length]))
				FROM [INDUSTRIAS COSMIC, S_A_U_$Item Unit of Measure] AS tUnid
				Where tUnid.[Item No_] = @Prod AND tUnid.Code = @UM
			end
		if @Tipo = 'A'
			begin
				Select Top(1) @Res = convert(varchar,convert(int,tUnid.Height))
				FROM [INDUSTRIAS COSMIC, S_A_U_$Item Unit of Measure] AS tUnid
				Where tUnid.[Item No_] = @Prod AND tUnid.Code = @UM
			end
		if @Tipo = 'H'
			begin
				Select Top(1) @Res = convert(varchar,convert(int,tUnid.Width))
				FROM [INDUSTRIAS COSMIC, S_A_U_$Item Unit of Measure] AS tUnid
				Where tUnid.[Item No_] = @Prod AND tUnid.Code = @UM
			end
		
		if @Tipo = 'M'
			begin
				Select Top(1) @Res = convert(varchar,convert(int,tUnid.[Length])) + 'X' + convert(varchar,convert(int,tUnid.Width)) + 'X' + convert(varchar,convert(int,tUnid.Height))
				FROM [INDUSTRIAS COSMIC, S_A_U_$Item Unit of Measure] AS tUnid
				Where tUnid.[Item No_] = @Prod AND tUnid.Code = @UM
			end
		
		if @Tipo = 'G'
			begin
				Select Top(1) @Res = (case when tProd.Largo = '' then '0' else tProd.Largo end) 
				FROM [INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd
				Where tProd.[No_] = @Prod
				
				if @Res = 0
					begin
						SELECT Top(1) @Res = convert(varchar(20),convert(int,isnull([Medida corte],'0')))
						FROM [INDUSTRIAS COSMIC, S_A_U_$IP Header]
						WHERE (No_ = @Prod)
					end
				
			end
		if @Tipo = 'LW'
			begin
				Select Top(1) @Res = convert(varchar,convert(int,tUnid.[Length])) + 'x' + convert(varchar,convert(int,tUnid.Width)) --+ convert(varchar,convert(int,tUnid.Height))
				FROM [INDUSTRIAS COSMIC, S_A_U_$Item Unit of Measure] AS tUnid
				Where tUnid.[Item No_] = @Prod AND tUnid.Code = @UM
			end

		if @Tipo = 'TLW'
			begin
				Select Top(1) @Res = convert(varchar,(convert(decimal(13,4),tUnid.[Length])*convert(decimal(13,4),tUnid.Width))/1000000)  --convert(varchar,convert(int,tUnid.Width)) --+ convert(varchar,convert(int,tUnid.Height))
				FROM [INDUSTRIAS COSMIC, S_A_U_$Item Unit of Measure] AS tUnid
				Where tUnid.[Item No_] = @Prod AND tUnid.Code = @UM
			end
			
		
RETURN ISNULL(@Res,'1')


END
GO

/****** Object:  UserDefinedFunction [dbo].[fncProducDiarSIP]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[fncProducDiarSIP] 
(
	@Producto nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @vCan decimal(18,2)

		SELECT  @vCan = SUM(Quantity)
		FROM  [INDUSTRIAS COSMIC, S_A_U_$Item Journal Line] AS Diar
		GROUP BY [Journal Template Name], [Journal Batch Name], [Item No_]
		HAVING ([Journal Batch Name] = 'SIPPROD') AND 
				([Item No_] = @Producto) AND 
				([Journal Template Name] = 'PRODUCTO')
		
	
	RETURN ISNULL(@vCan,0)


END
















GO

/****** Object:  UserDefinedFunction [dbo].[fncLMCert]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncLMCert] 
(
	@LM nvarchar(10)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @vCert int

	SELECT @vCert = isnull([Status],0)
	FROM [INDUSTRIAS COSMIC, S_A_U_$Production BOM Header]
	WHERE ([No_] = @LM)
        
	RETURN ISNULL(@vCert,0)

END

























GO

/****** Object:  UserDefinedFunction [dbo].[fncProducMoviSIPHoy]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[fncProducMoviSIPHoy] 
(
	@Producto nvarchar(20),
	@Tipo varchar(50)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @vOF decimal(18,2)
	DECLARE @vAj decimal(18,2)
    declare @Hoy varchar(30)

   set @Hoy = convert(varchar(10),Year(getdate())) + '-' + 
			  convert(varchar(10),Month(getdate())) + '-' + 
			  convert(varchar(10),Day(getdate())) +  
			  convert(varchar(10),' 00:00:00')

		SELECT @vOF=isnull(convert(int,SUM(Quantity)),0)
		FROM [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
		WHERE ([Item No_] = @Producto) 
			AND ([Location Code]= 'NORMAL')  
			and (([Entry Type] = 2) or ([Entry Type] = 3))
			and ([Posting Date] > CONVERT(DATETIME, '2010-10-29 00:00:00', 102))
			and ([Posting Date] <= CONVERT(DATETIME, @Hoy, 102)) 
			and (([Document No_] like 'OFSIP%'))

		Set @vAj=0

		SELECT @vAj=isnull(convert(int,Sum(Cantidad)),0)
		FROM [SIP Ajustes Stock]
		WHERE (Producto = @Producto) and (Tipo = @Tipo)
--	
	
	set @vOF = @vOF + @vAj

	
	RETURN ISNULL(@vOF,0)


END
















GO

/****** Object:  UserDefinedFunction [dbo].[fntOrdenCK]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fntOrdenCK]
(
	@Nck nvarchar(10)
    
)
RETURNS int
AS
BEGIN
declare @ReturnOrden int
	-- Declare the return variable here
	-- DECLARE <@ResultVar, sysname, @Result> <Function_Data_Type, ,int>

	-- Add the T-SQL statements to compute the return value here

    SELECT @ReturnOrden=max(Orden) FROM  [ModificacionesCKLineas] WHERE NCK = @Nck
	-- Return the result of the function
	RETURN @ReturnOrden

END



GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_Aprod]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncProdSD_Aprod] 
(	
	@IP    varchar(20),
	@OFL   varchar(20),
    @Carro varchar(20)
)
RETURNS decimal(12,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vAProd decimal(12,2)

		SELECT @vAProd = Aprod
		FROM ProdSD_Produccion_IP
		GROUP BY Carro, OFL, IP, AProd
		HAVING (IP = @IP) AND (Carro = @Carro) AND (OFL = @OFL)

RETURN ISNULL(@vAProd,0)


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_IpReg]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







CREATE FUNCTION [dbo].[fncProdSD_IpReg] 
(	
	@IP    varchar(20),
	@OFL   varchar(20),
    @Carro varchar(20)

)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vReg decimal(12,2)

        if @OFL = ''
			begin
				SELECT @vReg = Sum(Registrado)
				FROM ProdSD_Produccion With(NoLock)
				WHERE (Compo = @IP) AND (Carro = @Carro)
			end

        if @OFL <> ''
			begin
				SELECT @vReg = Sum(Registrado)
				FROM ProdSD_Produccion With(NoLock)
				WHERE (Compo = @IP) AND (OFL = @OFL)
			end


RETURN ISNULL(@vReg,0)


END

















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdSD_MiniReg]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE FUNCTION [dbo].[fncProdSD_MiniReg] 
(
	@Tipo varchar(20),
	@IP   varchar(20),
	@OFL  varchar(20)

)
RETURNS decimal(12,4)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vMini decimal(12,4)
		if (@Tipo <> '')
			begin
				SELECT @vMini = isnull(MIN(PorReg),0)
				FROM ProdSD_Produccion  With(NoLock)
				WHERE (Tipologia = @Tipo) AND (IP = @IP) AND (OFL = @OFL)
			end
		if (@Tipo = '')
			begin
				SELECT @vMini = isnull(MIN(PorReg),0)
				FROM ProdSD_Produccion With(NoLock)
				WHERE (IP = @IP) AND (OFL = @OFL)
			end
	if @vMini > 100
		begin
			set @vMini = 100
		end

RETURN ISNULL(@vMini,0)


END














GO

/****** Object:  UserDefinedFunction [dbo].[fncPrioridadCarro]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create FUNCTION [dbo].[fncPrioridadCarro] 
(
	@Carro nvarchar(20)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vPrio int

			SELECT top(1) @vPrio = Prioridad
            FROM ProdSD_Carros
            WHERE (NCarro = @Carro)

	RETURN ISNULL(@vPrio,0)


END













GO

/****** Object:  UserDefinedFunction [dbo].[fncPrioridadOFL]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncPrioridadOFL] 
(
	@OFL nvarchar(20)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vPrio int

			SELECT @vPrio = Prioridad
            FROM ProdSD_Carros
            WHERE (NOF = @OFL)

	RETURN ISNULL(@vPrio,0)


END













GO

/****** Object:  UserDefinedFunction [dbo].[fncProducEpCarro]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE FUNCTION [dbo].[fncProducEpCarro] 
(
	@Producto nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @vCan decimal(18,2)



	SELECT @vCan = isnull(convert(decimal(18,2),SUM(LinEP.[Cantidad recibida]-LinEP.[Cant en OFL])),0)
	FROM  [INDUSTRIAS COSMIC, S_A_U_$Lín_ Entrada Ped_] as LinEP INNER JOIN
		  [INDUSTRIAS COSMIC, S_A_U_$Cab_ Entrada Ped_] AS CabEP ON 
		  LinEP.[Nº Doc_ entrada] = CabEP.No_
	WHERE (CabEP.[Es Contenedor] = 1) AND (LinEP.[Cantidad recibida]-LinEP.[Cant en OFL] > 0)
	GROUP BY LinEP.Nº
	HAVING (LinEP.Nº = @Producto)

	
	RETURN ISNULL(@vCan,0)


END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncImporteCabAbo]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create FUNCTION [dbo].[fncImporteCabAbo] 
(
	@NFAC nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
--	-- Declare the return variable here
	DECLARE @vVenta decimal(18,2)
		SELECT @vVenta = Sum(Amount)
			FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Cr_Memo Line]
			WHERE ([Document No_] = @NFAC)

	RETURN ISNULL(@vVenta,0)

END
















GO

/****** Object:  UserDefinedFunction [dbo].[fncProducMoviSIP]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[fncProducMoviSIP] 
(
	@Producto nvarchar(20),
	@Tipo varchar(50)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @vOF decimal(18,2)
	DECLARE @vAj decimal(18,2)
    declare @Hoy varchar(30)

   set @Hoy = convert(varchar(10),Year(getdate())) + '-' + 
			  convert(varchar(10),Month(getdate())) + '-' + 
			  convert(varchar(10),Day(getdate())) +  
			  convert(varchar(10),' 00:00:00')

		SELECT @vOF=isnull(convert(int,SUM(Quantity)),0)
		FROM [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
		WHERE ([Item No_] = @Producto) AND ([Location Code]= 'NORMAL') and 
			(([Entry Type] = 2) or ([Entry Type] = 3)) AND 
			([Posting Date] > CONVERT(DATETIME, '2010-10-29 00:00:00', 102)) and
			([Posting Date] < CONVERT(DATETIME, @Hoy, 102)) and 
			(([Document No_] like 'OFSIP%'))

		Set @vAj=0

		SELECT @vAj=isnull(convert(int,Sum(Cantidad)),0)
		FROM [SIP Ajustes Stock]
		WHERE (Producto = @Producto) and (Tipo = @Tipo)
--	
	
	set @vOF = @vOF + @vAj

	
	RETURN ISNULL(@vOF,0)


END
















GO

/****** Object:  UserDefinedFunction [dbo].[fncRelpAnul]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncRelpAnul] 
(
	@RocaPedido nvarchar(20),
	@RocaLinPed int
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vNS int

            set @vNS = CONVERT(int,ISNULL((SELECT Count([No_])
            FROM [INDUSTRIAS COSMIC, S_A_U_$RELP]
            WHERE ([Status Línea] = 3) and ([Nº Pedido Roca] = @RocaPedido) AND 
					([Nº Lin Roca] = @RocaLinPed)),0))
	
	RETURN ISNULL(@vNS,0)


END









GO

/****** Object:  UserDefinedFunction [dbo].[fncVen_Cli_Marca2]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







create FUNCTION [dbo].[fncVen_Cli_Marca2] 
(
	@Cli nvarchar(20),
	@Prod nvarchar(20)
)
RETURNS nvarchar(20)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @vMarca int
	declare @Ven as nvarchar(20)
	declare @Ven0 as nvarchar(20)

    
--	SELECT @Ven0=[Salesperson Code]
--	FROM [INDUSTRIAS COSMIC, S_A_U_$Customer]
--	WHERE (No_ = @Cli)
	
--	set @Ven0 = isnull(@Ven0,'')
	set @Ven0 = 'INEX'


	
	if (@Prod = '')
		begin
			set @Ven = @Ven0
			RETURN ISNULL(@Ven,'')
		end
		
	if (@Prod = null)
		begin
			set @Ven = @Ven0
			RETURN ISNULL(@Ven,'')
		end
		

	if (@Cli = '')
		begin
			set @Ven = @Ven0
			RETURN ISNULL(@Ven,'')
		end

	if (@Cli = null)
		begin
			set @Ven = @Ven0
			RETURN ISNULL(@Ven,'')
		end



	select @vMarca= isnull(Marca,99)
	From [INDUSTRIAS COSMIC, S_A_U_$Item]
	where No_ = @Prod


	SELECT @Ven=isnull([Cód_ vendedor],'')
	From [INDUSTRIAS COSMIC, S_A_U_$Cliente_Marca_Vendedor]
	where [Cód_ Cliente] = @Cli and Marca = @vMarca

	set @Ven = isnull(@Ven,@Ven0)

	RETURN ISNULL(@Ven,@Ven0)

END





























GO

/****** Object:  UserDefinedFunction [dbo].[fncProducSIP_OF]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




create FUNCTION [dbo].[fncProducSIP_OF] 
(
	@Producto nvarchar(20),
	@OF nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @vOF decimal(18,2)
		
		set @OF = 'OFSIP-' + @OF
		SELECT @vOF=convert(int,SUM(Quantity))
		FROM [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
		WHERE ([Item No_] = @Producto) AND 
				([Entry Type] = 2) AND 
				([Document No_] = @OF) AND 
				([Posting Date] > CONVERT(DATETIME, '2010-10-29 00:00:00', 102))


	RETURN ISNULL(@vOF,0)


END









GO

/****** Object:  UserDefinedFunction [dbo].[fncVendSMarca]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








CREATE FUNCTION [dbo].[fncVendSMarca] 
(
	@Cli nvarchar(20),
	@Marca int,
	@Tipo nvarchar(10)
)
RETURNS nvarchar(20)
AS
BEGIN
	-- Declare the return variable here
	declare @Ven as nvarchar(20)

    if @Tipo = 'V'
		begin 
			SELECT @Ven=isnull([Cód_ vendedor],'')
			From [INDUSTRIAS COSMIC, S_A_U_$Cliente_Marca_Vendedor]
			where [Cód_ Cliente] = @Cli and Marca = @Marca

			set @Ven = isnull(@Ven,'')
		end
    if @Tipo = 'F'
		begin 
			SELECT @Ven=isnull(convert(varchar(20),convert(int,[Objetivo Facturación])),'0')
			From [INDUSTRIAS COSMIC, S_A_U_$Cliente_Marca_Vendedor]
			where [Cód_ Cliente] = @Cli and Marca = @Marca

			set @Ven = isnull(@Ven,'0')
		end

	RETURN ISNULL(@Ven,'')

END






























GO

/****** Object:  UserDefinedFunction [dbo].[fncRelpUlt]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION [dbo].[fncRelpUlt] 
(
	@Pedido nvarchar(20),
	@Linea int
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	declare @vUlt int
    
	set @vUlt=999

	SELECT TOP (1) @vUlt=[Status Línea]
	FROM [INDUSTRIAS COSMIC, S_A_U_$RELP]
	WHERE ([Nº Pedido Roca] = @Pedido) AND ([Nº Lin Roca] = @Linea) AND 
			([Status Línea] = 0 OR [Status Línea] = 2 OR [Status Línea] = 3)
	ORDER BY [Nº Pedido Roca] DESC, [Nº Lin Roca] DESC, [Fecha Datos Roca2] DESC

	RETURN ISNULL(@vUlt,999)


END








GO

/****** Object:  UserDefinedFunction [dbo].[fncProdPVPenSIP]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncProdPVPenSIP] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20),
	@NoSIP int
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStock decimal(18,2)

	if @Almacen > ''
	begin
		SELECT @vStock = sum([Outstanding Quantity])
			FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line] AS LinVen 
			WHERE ([NO enviar SIP] = @NoSIP) AND ([Document Type] = 1) and ([No_] = @Producto) AND ([Location Code] = @Almacen)
	end
	if @Almacen = ''
	begin
		SELECT @vStock = sum([Outstanding Quantity])
			FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line] AS LinVen 
			WHERE ([NO enviar SIP] = @NoSIP) AND ([Document Type] = 1) AND ([No_] = @Producto)
	end

	RETURN ISNULL(@vStock,0)

END







GO

/****** Object:  UserDefinedFunction [dbo].[fncCli_Nombre]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






create FUNCTION [dbo].[fncCli_Nombre] 
(
	@Cliente nvarchar(20)
)
RETURNS nvarchar(60)
AS
BEGIN
	-- Declare the return variable here
	declare @vNombre nvarchar(60)	

	SELECT @vNombre = [Name]
	FROM [INDUSTRIAS COSMIC, S_A_U_$Customer]
	WHERE (No_ = @Cliente)	

	RETURN ISNULL(@vNombre,'')

END






















GO

/****** Object:  UserDefinedFunction [dbo].[fncVen_Comision]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[fncVen_Comision] 
(
	@Tipo nvarchar(5),
	@Vend nvarchar(20),
	@Cli nvarchar(20),
	@Prod nvarchar(20)
)
RETURNS decimal(20,4)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @vComi decimal(20,4)
	Declare @vCol nvarchar(30)
	Declare @vGProd nvarchar(30)
	Declare @vGCli nvarchar(30)
	Declare @vComiEsp decimal(20,4)
	Declare @vEspCli nvarchar(30)
	Declare @vEspProd nvarchar(30)
	Declare @vEspGCli nvarchar(30)
	Declare @vEspGProd nvarchar(30)
	Declare @vEspColec nvarchar(30)
    


	SELECT @vComi=isnull([Commission %],0)
	From [INDUSTRIAS COSMIC, S_A_U_$Salesperson_Purchaser]
	where [Code] = @Vend

    if (@Tipo) = '6'
		begin
			SELECT @vComi=isnull([% Comisión Proyecto],0)
			From [INDUSTRIAS COSMIC, S_A_U_$Salesperson_Purchaser]
			where [Code] = @Vend
--			if (@vComi = 0)
--				begin
--					set @vComi = 5
--				end
		end
    -------------------------------------------------------------------------------


    --Busco Registro de comisiones especiales
	SELECT @vEspCli=MAX([Cod Cliente]),
			 @vEspProd = MAX([Cod Producto]),
			 @vEspGCli = MAX([Grupo Cliente]),
			 @vEspGProd = MAX([Grupo Producto]), 
			 @vEspColec = MAX([Nombre colección])
	FROM [INDUSTRIAS COSMIC, S_A_U_$Comisiones especiales] AS ComEsp
	GROUP BY [Cod Vendedor]
	HAVING ([Cod Vendedor] = @Vend)
    -------------------------------------------------------------------------------
	
	if (@vEspGProd) > '' or (@vEspColec) > ''
		begin
			select @vCol= isnull([Nombre colección],''),
					@vGprod = isnull([Inventory Posting Group],'')
			From [INDUSTRIAS COSMIC, S_A_U_$Item]
			where No_ = @Prod			
		end


	SET @vComiEsp = 999999
	if (@vEspCli > '')
		begin   
			SELECT @vComiEsp=isnull([% Comisión],999999)
			From [INDUSTRIAS COSMIC, S_A_U_$Comisiones especiales]
			where [Cod Vendedor] = @Vend and [Cod Cliente] = @Cli
			
			if (@vComiEsp <> 999999)
				begin
					set @vComi =  @vComiEsp  
				end
		end


	SET @vComiEsp = 999999
	if (@vEspGCli > '')
		begin   

			SELECT @vGCli=[Customer Posting Group]
			FROM [INDUSTRIAS COSMIC, S_A_U_$Customer]
			WHERE (No_ = @Cli)


			SELECT @vComiEsp=isnull([% Comisión],999999)
			From [INDUSTRIAS COSMIC, S_A_U_$Comisiones especiales]
			where [Cod Vendedor] = @Vend and [Grupo Cliente] = @vGCli
			
			if (@vComiEsp <> 999999)
				begin
					set @vComi =  @vComiEsp  
				end
		end


	SET @vComiEsp = 999999
	if (@vEspGProd > '')
		begin   
			SELECT @vComiEsp=isnull([% Comisión],999999)
			From [INDUSTRIAS COSMIC, S_A_U_$Comisiones especiales]
			where [Cod Vendedor] = @Vend and [Grupo Producto] = @vGprod
			
			if (@vComiEsp <> 999999)
				begin
					set @vComi =  @vComiEsp  
				end
		end

	SET @vComiEsp = 999999
	if (@vEspColec > '')
		begin   

			SELECT @vComiEsp=isnull([% Comisión],999999)
			From [INDUSTRIAS COSMIC, S_A_U_$Comisiones especiales]
			where [Cod Vendedor] = @Vend and [Nombre colección] = @vCol
			
			if (@vComiEsp <> 999999)
				begin
					set @vComi =  @vComiEsp  
				end
		end

	SET @vComiEsp = 999999
	if (@vEspProd > '')
		begin   
			SELECT @vComiEsp=isnull([% Comisión],999999)
			From [INDUSTRIAS COSMIC, S_A_U_$Comisiones especiales]
			where [Cod Vendedor] = @Vend and [Cod Producto] = @Prod
			
			if (@vComiEsp <> 999999)
				begin
					set @vComi =  @vComiEsp  
				end
		end

	RETURN ISNULL(@vComi,0)

END



































GO

/****** Object:  UserDefinedFunction [dbo].[fncVen_Cta_LinPed]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create FUNCTION [dbo].[fncVen_Cta_LinPed] 
(
	@GenCli nvarchar(20),
	@GenProd nvarchar(20),
	@cCta nvarchar(1),
	@Digitos int
)
RETURNS nvarchar(20)
AS
BEGIN
	-- Declare the return variable here
	declare @Cta as nvarchar(20)
	declare @Cta0 as nvarchar(20)
	declare @Sql as nvarchar(200)
    
	set @Cta0 = 'INEX'



	
	if (@GenProd = '')
		begin
			set @Cta = @Cta0
			RETURN ISNULL(@Cta,'')
		end
		
	if (@GenProd = null)
		begin
			set @Cta = @Cta0
			RETURN ISNULL(@Cta,'')
		end
		

	if (@GenCli = '')
		begin
			set @Cta = @Cta0
			RETURN ISNULL(@Cta,'')
		end

	if (@GenCli = null)
		begin
			set @Cta = @Cta0
			RETURN ISNULL(@Cta,'')
		end


	if @cCta = 'F'
		begin
			SELECT @Cta=isnull([Sales Account],@Cta0)
			From [INDUSTRIAS COSMIC, S_A_U_$General Posting Setup]
			where [Gen_ Bus_ Posting Group] = @GenCli and [Gen_ Prod_ Posting Group] = @GenProd
		end
	if @cCta = 'A'
		begin
			SELECT @Cta=isnull([Sales Credit Memo Account],@Cta0)
			From [INDUSTRIAS COSMIC, S_A_U_$General Posting Setup]
			where [Gen_ Bus_ Posting Group] = @GenCli and [Gen_ Prod_ Posting Group] = @GenProd
		end	
	
	set @Cta = isnull(@Cta,@Cta0)
	set @Cta = Left(@Cta,@Digitos)
	RETURN ISNULL(@Cta,@Cta0)

END































GO

/****** Object:  UserDefinedFunction [dbo].[fncVen_Cta]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








CREATE FUNCTION [dbo].[fncVen_Cta] 
(
	@Cli nvarchar(20),
	@Prod nvarchar(20),
	@cCta nvarchar(1),
	@Digitos int
)
RETURNS nvarchar(20)
AS
BEGIN
	-- Declare the return variable here
	declare @GenCli nvarchar(20)
	declare @GenProd nvarchar(20)
	declare @Cta as nvarchar(20)
	declare @Cta0 as nvarchar(20)
	declare @Sql as nvarchar(200)
    
	set @Cta0 = 'INEX'



	
	if (@Prod = '')
		begin
			set @Cta = @Cta0
			RETURN ISNULL(@Cta,'')
		end
		
	if (@Prod = null)
		begin
			set @Cta = @Cta0
			RETURN ISNULL(@Cta,'')
		end
		

	if (@Cli = '')
		begin
			set @Cta = @Cta0
			RETURN ISNULL(@Cta,'')
		end

	if (@Cli = null)
		begin
			set @Cta = @Cta0
			RETURN ISNULL(@Cta,'')
		end

	select @GenProd= isnull([Gen_ Prod_ Posting Group],'')
	From [INDUSTRIAS COSMIC, S_A_U_$Item]
	where No_ = @Prod

	select @GenCli= isnull([Gen_ Bus_ Posting Group],'')
	From [INDUSTRIAS COSMIC, S_A_U_$Customer]
	where No_ = @Cli

	if @cCta = 'F'
		begin
			SELECT @Cta=isnull([Sales Account],@Cta0)
			From [INDUSTRIAS COSMIC, S_A_U_$General Posting Setup]
			where [Gen_ Bus_ Posting Group] = @GenCli and [Gen_ Prod_ Posting Group] = @GenProd
		end
	if @cCta = 'A'
		begin
			SELECT @Cta=isnull([Sales Credit Memo Account],@Cta0)
			From [INDUSTRIAS COSMIC, S_A_U_$General Posting Setup]
			where [Gen_ Bus_ Posting Group] = @GenCli and [Gen_ Prod_ Posting Group] = @GenProd
		end	
	
	set @Cta = isnull(@Cta,@Cta0)
	set @Cta = Left(@Cta,@Digitos)
	RETURN ISNULL(@Cta,@Cta0)

END






























GO

/****** Object:  UserDefinedFunction [dbo].[fncVen_Cli_Marca]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE FUNCTION [dbo].[fncVen_Cli_Marca] 
(
	@Cli nvarchar(20),
	@Prod nvarchar(20)
)
RETURNS nvarchar(20)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @vMarca int
	declare @Ven as nvarchar(20)
	declare @Ven0 as nvarchar(20)

    
--	SELECT @Ven0=[Salesperson Code]
--	FROM [INDUSTRIAS COSMIC, S_A_U_$Customer]
--	WHERE (No_ = @Cli)
	
--	set @Ven0 = isnull(@Ven0,'')
	set @Ven0 = 'INEX'


	
	if (@Prod = '')
		begin
			set @Ven = @Ven0
			RETURN ISNULL(@Ven,'')
		end
		
	if (@Prod = null)
		begin
			set @Ven = @Ven0
			RETURN ISNULL(@Ven,'')
		end
		

	if (@Cli = '')
		begin
			set @Ven = @Ven0
			RETURN ISNULL(@Ven,'')
		end

	if (@Cli = null)
		begin
			set @Ven = @Ven0
			RETURN ISNULL(@Ven,'')
		end



	select @vMarca= isnull(Marca,99)
	From [INDUSTRIAS COSMIC, S_A_U_$Item]
	where No_ = @Prod


	SELECT @Ven=isnull([Cód_ vendedor],'')
	From [INDUSTRIAS COSMIC, S_A_U_$Cliente_Marca_Vendedor]
	where [Cód_ Cliente] = @Cli and Marca = @vMarca

	set @Ven = isnull(@Ven,@Ven0)

	RETURN ISNULL(@Ven,@Ven0)

END




























GO

/****** Object:  UserDefinedFunction [dbo].[fncDiasLab]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[fncDiasLab] 
(
	@DFecha nvarchar(10),
	@HFecha nvarchar(10)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @vDias int
	declare @vDia int
	DECLARE @vRes int
	
	declare @DDFecha nvarchar(20)
	declare @HHFecha nvarchar(20)

	set @DDFecha = @DFecha + ' 00:00:00'
	set @HHFecha = @HFecha + ' 00:00:00'

    set @vDia = day(CONVERT(DATETIME, @HHFecha, 102))

	SELECT @vDias = COUNT(Festivo)
	FROM [INDUSTRIAS COSMIC, S_A_U_$Calendario de Festivos]
	WHERE (Festivo >= CONVERT(DATETIME, @DDFecha, 102)) AND (Festivo <= CONVERT(DATETIME, @HHFecha, 102))
        
    --set @vDias = 0
    
	set @vRes = @vDia - @vDias

    if @vRes < 0 
		begin
			set @vRes = 0
		end



	RETURN ISNULL(@vRes,0)

END

























GO

/****** Object:  UserDefinedFunction [dbo].[fncCli_AboDL_Fecha]    Script Date: 11/18/2014 20:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO











CREATE FUNCTION [dbo].[fncCli_AboDL_Fecha] 
(
	@Cliente nvarchar(20),
	@DFecha nvarchar(10),
	@HFecha nvarchar(10)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @vPen decimal(18,2)
	declare @DDFecha nvarchar(20)
	declare @HHFecha nvarchar(20)

	set @DDFecha = @DFecha + ' 00:00:00'
	set @HHFecha = @HFecha + ' 00:00:00'

	SELECT @vPen=SUM(LinFac.Amount)

	FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Cr_Memo Header] AS CabFac INNER JOIN
		 [INDUSTRIAS COSMIC, S_A_U_$Sales Cr_Memo Line] AS LinFac ON CabFac.No_ = LinFac.[Document No_]
	WHERE (CabFac.[Sell-to Customer No_] = @Cliente) 
			AND (CabFac.[Posting Date] >= CONVERT(DATETIME, @DDFecha, 102) 
			AND CabFac.[Posting Date] <= CONVERT(DATETIME, @HHFecha , 102))



	RETURN ISNULL(@vPen,0)

END























GO

/****** Object:  UserDefinedFunction [dbo].[fncCli_FacDL_Fecha]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO











CREATE FUNCTION [dbo].[fncCli_FacDL_Fecha] 
(
	@Cliente nvarchar(20),
	@DFecha nvarchar(10),
	@HFecha nvarchar(10)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @vPen decimal(18,2)
	declare @DDFecha nvarchar(20)
	declare @HHFecha nvarchar(20)

	set @DDFecha = @DFecha + ' 00:00:00'
	set @HHFecha = @HFecha + ' 00:00:00'

	SELECT @vPen=SUM(LinFac.Amount)

	FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Invoice Header] AS CabFac INNER JOIN
		 [INDUSTRIAS COSMIC, S_A_U_$Sales Invoice Line] AS LinFac ON CabFac.No_ = LinFac.[Document No_]
	WHERE (CabFac.[Sell-to Customer No_] = @Cliente) 
			AND (CabFac.[Posting Date] >= CONVERT(DATETIME, @DDFecha, 102) 
			AND CabFac.[Posting Date] <= CONVERT(DATETIME, @HHFecha, 102))



	RETURN ISNULL(@vPen,0)

END























GO

/****** Object:  UserDefinedFunction [dbo].[fncCli_AlbDL_Fecha]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[fncCli_AlbDL_Fecha] 
(
	@Cliente nvarchar(20),
	@DFecha nvarchar(10),
	@HFecha nvarchar(10)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @vPen decimal(18,2)
	declare @DDFecha nvarchar(20)
	declare @HHFecha nvarchar(20)

	set @DDFecha = @DFecha + ' 00:00:00'
	set @HHFecha = @HFecha + ' 00:00:00'

	SELECT @vPen=SUM([Shipped Not Invoiced (LCY)])

	FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Header] AS CabPed INNER JOIN
      [INDUSTRIAS COSMIC, S_A_U_$Sales Line] AS LinPed ON CabPed.[Document Type] = LinPed.[Document Type] AND 
      CabPed.No_ = LinPed.[Document No_]
	WHERE (CabPed.[Document Type] = 1)
			and (CabPed.[Sell-to Customer No_] = @Cliente) 
			AND (LinPed.[Shipment Date] >= CONVERT(DATETIME, @DDFecha , 102) 
			AND LinPed.[Shipment Date] <= CONVERT(DATETIME, @HHFecha , 102))



	RETURN ISNULL(@vPen,0)

END























GO

/****** Object:  UserDefinedFunction [dbo].[fncCli_PendDL_Fecha]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









CREATE FUNCTION [dbo].[fncCli_PendDL_Fecha] 
(
	@Cliente nvarchar(20),
	@DFecha nvarchar(10),
	@HFecha nvarchar(10)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @vPen decimal(18,2)
	declare @DDFecha nvarchar(20)
	declare @HHFecha nvarchar(20)

	set @DDFecha = @DFecha + ' 00:00:00'
	set @HHFecha = @HFecha + ' 00:00:00'


	SELECT @vPen=SUM([Outstanding Amount (LCY)])

	FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Header] AS CabPed INNER JOIN
      [INDUSTRIAS COSMIC, S_A_U_$Sales Line] AS LinPed ON CabPed.[Document Type] = LinPed.[Document Type] AND 
      CabPed.No_ = LinPed.[Document No_]
	WHERE (CabPed.[Document Type] = 1) and (LinPed.[Outstanding Amount (LCY)] > 0)
			and (CabPed.[Sell-to Customer No_] = @Cliente) 
			AND (CabPed.[Order Date] >= CONVERT(DATETIME, @DDFecha, 102) 
			AND CabPed.[Order Date] <= CONVERT(DATETIME, @HHFecha, 102))



	RETURN ISNULL(@vPen,0)

END





















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdStAdiCal]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION [dbo].[fncProdStAdiCal] 
(
	@Producto nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStock decimal(18,2)

		SELECT @vStock = s21
			FROM [INDUSTRIAS COSMIC, S_A_U_$52007$2] AS MovPick 
			WHERE (bucket = 1) AND (f2 = @Producto)

	RETURN ISNULL(@vStock,0)


END





GO

/****** Object:  UserDefinedFunction [dbo].[fncProdStPickCal]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION [dbo].[fncProdStPickCal] 
(
	@Producto nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStock decimal(18,2)

		SELECT @vStock = s13
			FROM [INDUSTRIAS COSMIC, S_A_U_$52003$0] AS MovPick 
			WHERE (bucket = 1) AND (f3 = @Producto)

	RETURN ISNULL(@vStock,0)


END





GO

/****** Object:  UserDefinedFunction [dbo].[fncProducSIP]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE FUNCTION [dbo].[fncProducSIP] 
(
	@Producto nvarchar(20),
	@Sin40 int
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vOF decimal(18,2)

	if @Sin40 = 0
		begin
			SELECT @vOF=convert(int,SUM(Quantity))
			FROM [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
			WHERE ([Item No_] = @Producto) AND ([Location Code]= 'NORMAL') and 
				(([Entry Type] = 2) or ([Entry Type] = 3)) AND 
				([Posting Date] > CONVERT(DATETIME, '2010-10-29 00:00:00', 102)) and
				(([Document No_] like 'OFSIP%') or ([Document No_] = '40'))
		end
	if @Sin40 = 1
		begin
			SELECT @vOF=convert(int,SUM(Quantity))
			FROM [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
			WHERE ([Item No_] = @Producto) AND ([Location Code]= 'NORMAL') and 
				(([Entry Type] = 2) or ([Entry Type] = 3)) AND 
				([Posting Date] > CONVERT(DATETIME, '2010-10-29 00:00:00', 102)) and
				(([Document No_] like 'OFSIP%'))
		end

	RETURN ISNULL(@vOF,0)


END











GO

/****** Object:  UserDefinedFunction [dbo].[fncProdPVPenEsp]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncProdPVPenEsp] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStock decimal(18,2)

	if @Almacen > ''
	begin
		SELECT @vStock = sum([Outstanding Quantity])
			FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line] AS LinVen 
			WHERE ([Roca Ref_ Especial] = 1) AND ([Roca Ref_ para SIP] = @Producto)  AND ([Location Code] = @Almacen)
	end
	if @Almacen = ''
	begin
		SELECT @vStock = sum([Outstanding Quantity])
			FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line] AS LinVen 
			WHERE ([Roca Ref_ Especial] = 1) AND ([Roca Ref_ para SIP] = @Producto)
	end

	RETURN ISNULL(@vStock,0)

END





GO

/****** Object:  UserDefinedFunction [dbo].[fncCli_Credito]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







CREATE FUNCTION [dbo].[fncCli_Credito] 
(
	@Cliente nvarchar(20),
	@HastaFac nvarchar(20),
	@HastaInc int
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @vCredit decimal(18,2)
	DECLARE @vLimite decimal(18,2)
	DECLARE @vClave varchar(20)
	
	set @vLimite = 0

	SELECT @vClave = [Clave CIF_NIF]
	FROM [INDUSTRIAS COSMIC, S_A_U_$Customer]
	WHERE (No_ = @Cliente)	


	SELECT @vLimite = sum([Credit Limit (LCY)])
	FROM [INDUSTRIAS COSMIC, S_A_U_$CIF_NIF Clave]
	WHERE ([CIF_NIF] = @vClave)	

	

	set @vCredit = @vLimite 
    				- dbo.fncCli_RiesgoActDL(@Cliente) 
	    			- dbo.fncCli_PendienteDL(@Cliente,@HastaFac,@HastaInc)
		    		- dbo.fncCli_EntNoFacDL(@Cliente,@HastaFac,@HastaInc)

   IF (@Cliente = '43117030')
		begin
			set @vCredit = 3999999
		end
   IF (@Cliente = '43117029')
		begin
			set @vCredit = 3999999
		end


	RETURN ISNULL(@vCredit,0)

END























GO

/****** Object:  UserDefinedFunction [dbo].[fncCli_EntNoFacDL]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







CREATE FUNCTION [dbo].[fncCli_EntNoFacDL] 
(
	@Cliente nvarchar(20),
	@HastaFac nvarchar(20),
	@HastaInc int
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @vPen decimal(18,2)

	DECLARE @vClave varchar(20)

	SELECT @vClave = [Clave CIF_NIF]
	FROM [INDUSTRIAS COSMIC, S_A_U_$Customer]
	WHERE (No_ = @Cliente)	



	if @HastaFac > ''
		begin
			if @HastaInc = 1
				begin
					SELECT @vPen=SUM([Shipped Not Invoiced (LCY)])
					FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
					WHERE ([Document Type] = 1) AND ([Document No_] <= @HastaFac) and 
						([Shipped Not Invoiced (LCY)] > 0) and ([Clave CIF_NIF] = @vClave) 
					GROUP BY [Clave CIF_NIF]
				end		
			if @HastaInc = 0
				begin
					SELECT @vPen=SUM([Shipped Not Invoiced (LCY)])
					FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
					WHERE ([Document Type] = 1) AND ([Document No_] < @HastaFac) and 
					([Shipped Not Invoiced (LCY)] > 0) and
					([Clave CIF_NIF] = @vClave)
					GROUP BY [Clave CIF_NIF]
				end		
		end

	if @HastaFac = ''
		begin
			SELECT @vPen=SUM([Shipped Not Invoiced (LCY)])
			FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
			WHERE ([Document Type] = 1) and ([Shipped Not Invoiced (LCY)] > 0) and
					([Clave CIF_NIF] = @vClave) 
			GROUP BY [Clave CIF_NIF]
		end




	RETURN ISNULL(@vPen,0)

END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncCli_PendienteDL]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







CREATE FUNCTION [dbo].[fncCli_PendienteDL] 
(
	@Cliente nvarchar(20),
	@HastaFac nvarchar(20),
	@HastaInc int
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @vPen decimal(18,2)


	DECLARE @vClave varchar(20)

	SELECT @vClave = [Clave CIF_NIF]
	FROM [INDUSTRIAS COSMIC, S_A_U_$Customer]
	WHERE (No_ = @Cliente)	


	if @HastaFac > ''
		begin
			if @HastaInc = 1
				begin
					SELECT @vPen=SUM([Outstanding Amount (LCY)])
					FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
					WHERE ([Document Type] = 1)
							and ([Outstanding Amount (LCY)] > 0)							
							 and ([Clave CIF_NIF] = @vClave) 
							 AND ([Document No_] <= @HastaFac) 
				end		
			if @HastaInc = 0
				begin
					SELECT @vPen=SUM([Outstanding Amount (LCY)])
					FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
					WHERE ([Document Type] = 1) AND ([Document No_] < @HastaFac) and ([Outstanding Amount (LCY)] > 0)
							and ([Clave CIF_NIF] = @vClave)
				end		
		end

	if @HastaFac = ''
		begin
			SELECT @vPen=SUM([Outstanding Amount (LCY)])
			FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
			WHERE ([Document Type] = 1) and ([Outstanding Amount (LCY)] > 0)
					and ([Clave CIF_NIF] = @vClave)
		end




	RETURN ISNULL(@vPen,0)

END



















GO

/****** Object:  UserDefinedFunction [dbo].[fncCli_RiesgoActDL]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE FUNCTION [dbo].[fncCli_RiesgoActDL] 
(
	@Cliente nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @vRiesgo decimal(18,2)

	DECLARE @vClave varchar(20)

	SELECT @vClave = [Clave CIF_NIF]
	FROM [INDUSTRIAS COSMIC, S_A_U_$Customer]
	WHERE (No_ = @Cliente)	


		SELECT @vRiesgo = sum(s8)
			FROM [INDUSTRIAS COSMIC, S_A_U_$379$13] 
			WHERE (bucket = 5) AND (f50002 = @vClave) AND (f7000004 = 0)


	RETURN ISNULL(@vRiesgo,0)

END


















GO

/****** Object:  UserDefinedFunction [dbo].[fncPrecioCompra]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fncPrecioCompra] 
(
	@Proveedor nvarchar(20),
	@Producto nvarchar(20)
)
RETURNS decimal(18,5)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vPrecio decimal(18,5)

		set @vPrecio = CONVERT(decimal(18,5),ISNULL((SELECT top(1) [Direct Unit Cost]
				FROM [INDUSTRIAS COSMIC, S_A_U_$Purchase Price]
				WHERE ([Vendor No_] = @Proveedor) AND 
						([Item No_] = @Producto) AND 
						([Ending Date] = CONVERT(DATETIME, '1753-01-01 00:00:00', 102))
				ORDER BY [Starting Date] DESC),'0'))

	RETURN ISNULL(@vPrecio,0)


END







GO

/****** Object:  UserDefinedFunction [dbo].[fncRelpNueva]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create FUNCTION [dbo].[fncRelpNueva] 
(
	@RocaPedido nvarchar(20),
	@RocaLinPed int
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vNS int

            set @vNS = CONVERT(int,ISNULL((SELECT Count([No_])
            FROM [INDUSTRIAS COSMIC, S_A_U_$RELP]
            WHERE ([Status Línea] = 0) and ([Nº Pedido Roca] = @RocaPedido) AND 
					([Nº Lin Roca] = @RocaLinPed)),0))
	
	RETURN ISNULL(@vNS,0)


END








GO

/****** Object:  UserDefinedFunction [dbo].[fncProdNOSIP]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fncProdNOSIP] 
(
	@Producto nvarchar(20)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vNS int

        set @vNS = CONVERT(int,ISNULL((SELECT [Excluido producción SIP]
		        FROM [INDUSTRIAS COSMIC, S_A_U_$Item]
                WHERE ([No_] = @Producto)),0))
	
	RETURN ISNULL(@vNS,1)


END







GO

/****** Object:  UserDefinedFunction [dbo].[fncProdTermStLibre]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO










-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncProdTermStLibre] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStockLibre decimal(18,2)


		set @vStockLibre = dbo.fncProductoAlmacen(@Producto,@Almacen) - 
			dbo.fncProdEmbalando(@Producto,@Almacen)
			 - dbo.fncProdReserva(@Producto,@Almacen)
			 - dbo.fncProdEncajado(@Producto,@Almacen)
			 - dbo.fncProdOEA(@Producto,@Almacen)
	
	RETURN ISNULL(@vStockLibre,0)


END










GO

/****** Object:  UserDefinedFunction [dbo].[fncProdOFSIP]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE FUNCTION [dbo].[fncProdOFSIP] 
(
	@Producto nvarchar(20),
	@ConSt int,
	@Alm nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vOF decimal(18,2)

		if @Alm <> ''
			begin
				if @ConSt = 0
					begin
						set @vOF = CONVERT(int,ISNULL((SELECT SUM(Cantidad)
								FROM [INDUSTRIAS COSMIC, S_A_U_$SIP OF]
								WHERE ([Producto] = @Producto) and ([Cód_ almacén] = @Alm)),0))
					end	
				if @ConSt = 1
					begin
						set @vOF = CONVERT(int,ISNULL((SELECT SUM(Cantidad + [Cantidad Stock])
								FROM [INDUSTRIAS COSMIC, S_A_U_$SIP OF]
								WHERE ([Producto] = @Producto) and ([Cód_ almacén] = @Alm) ),0))
					end	
			end

		if @Alm = ''
			begin
				if @ConSt = 0
					begin
						set @vOF = CONVERT(int,ISNULL((SELECT SUM(Cantidad)
								FROM [INDUSTRIAS COSMIC, S_A_U_$SIP OF]
								WHERE ([Producto] = @Producto)),0))
					end	
				if @ConSt = 1
					begin
						set @vOF = CONVERT(int,ISNULL((SELECT SUM(Cantidad + [Cantidad Stock])
								FROM [INDUSTRIAS COSMIC, S_A_U_$SIP OF]
								WHERE ([Producto] = @Producto)),0))
					end	
			end

    set @vOF=ISNULL(@vOF,0)
    if @vOF < 0
		begin
			set @vOF = 0
		end
	RETURN ISNULL(@vOF,0)


END









GO

/****** Object:  UserDefinedFunction [dbo].[fncProdOEA]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION [dbo].[fncProdOEA] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vOEA decimal(18,2)

	if @Almacen > ''
	begin
        set @vOEA = CONVERT(int,ISNULL((SELECT SUM(Cantidad)
		        FROM [INDUSTRIAS COSMIC, S_A_U_$OEA Lineas]
                WHERE ([Nº] = @Producto AND ([Situación Línea] != 3)
                AND [Código Almacén] = @Almacen)),0))


	end
	if @Almacen = ''
	begin
        set @vOEA = CONVERT(int,ISNULL((SELECT SUM(Cantidad)
		        FROM [INDUSTRIAS COSMIC, S_A_U_$OEA Lineas]
                WHERE ([Nº] = @Producto AND ([Situación Línea] != 3))),0))
	end

	RETURN ISNULL(@vOEA,0)


END






GO

/****** Object:  UserDefinedFunction [dbo].[fncProdEncajado]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION [dbo].[fncProdEncajado] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vEncajado decimal(18,2)

	if @Almacen > ''
	begin
        set @vEncajado = CONVERT(int,ISNULL((SELECT SUM([Outstanding Quantity])
		        FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
		        WHERE ([Document Type] = 1) AND (Embalandose = 0) AND
                    ([Location Code] = @Almacen) AND
			        (Encajado = 1) AND
			        ([Reserva Usuario] = 0) AND 
                    (No_ = @Producto)), 0))


	end
	if @Almacen = ''
	begin
        set @vEncajado = CONVERT(int,ISNULL((SELECT SUM([Outstanding Quantity])
		        FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
		        WHERE ([Document Type] = 1) AND (Embalandose = 0) AND
			        (Encajado = 1) AND
			        ([Reserva Usuario] = 0) AND 
                    (No_ = @Producto)), 0))
	end

	RETURN ISNULL(@vEncajado,0)


END






GO

/****** Object:  UserDefinedFunction [dbo].[fncProdReserva]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
Create FUNCTION [dbo].[fncProdReserva] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vReserva decimal(18,2)

	if @Almacen > ''
	begin
        set @vReserva = CONVERT(int,ISNULL((SELECT SUM([Outstanding Quantity])
		        FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
		        WHERE ([Document Type] = 1) AND
                    ([Location Code] = @Almacen) AND
			        ([Reserva Usuario] = 1) AND 
                    (No_ = @Producto)), 0))


	end
	if @Almacen = ''
	begin
        set @vReserva = CONVERT(int,ISNULL((SELECT SUM([Outstanding Quantity])
		        FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
		        WHERE ([Document Type] = 1) AND
			        ([Reserva Usuario] = 1) AND 
                    (No_ = @Producto)), 0))
	end

	RETURN ISNULL(@vReserva,0)


END





GO

/****** Object:  UserDefinedFunction [dbo].[fncProdEmbalando]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
Create FUNCTION [dbo].[fncProdEmbalando] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vEmbala decimal(18,2)

	if @Almacen > ''
	begin
        set @vEmbala = CONVERT(int,ISNULL((SELECT SUM([Outstanding Quantity])
		        FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
		        WHERE ([Document Type] = 1) AND (Embalandose = 1) AND
                    ([Location Code] = @Almacen) AND
			        (Encajado = 0) AND
			        ([Reserva Usuario] = 0) AND 
                    (No_ = @Producto)), 0))


	end
	if @Almacen = ''
	begin
        set @vEmbala = CONVERT(int,ISNULL((SELECT SUM([Outstanding Quantity])
		        FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
		        WHERE ([Document Type] = 1) AND (Embalandose = 1) AND
			        (Encajado = 0) AND
			        ([Reserva Usuario] = 0) AND 
                    (No_ = @Producto)), 0))
	end

	RETURN ISNULL(@vEmbala,0)


END





GO

/****** Object:  UserDefinedFunction [dbo].[fncImporteCabFac]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[fncImporteCabFac] 
(
	@NFAC nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
--	-- Declare the return variable here
	DECLARE @vVenta decimal(18,2)
		SELECT @vVenta = Sum(Amount)
			FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Invoice Line]
			WHERE ([Document No_] = @NFAC)

	RETURN ISNULL(@vVenta,0)

END















GO

/****** Object:  UserDefinedFunction [dbo].[fncProdStLibre2]    Script Date: 11/18/2014 20:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncProdStLibre2] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStock decimal(18,2),
		@vCdaLanz decimal(18,2),
		@vStockLibre decimal(18,2)

	set @vStock = 0
	set @vCdaLanz = 0

	if @Almacen > ''
	begin
		SELECT @vStock = isnull(s12,0)
			FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] AS Mov 
			WHERE (bucket = 4) AND (f2 = @Producto)  AND (f8 = @Almacen)
		
		SELECT @vCdaLanz = isnull(s61,0)
			FROM [INDUSTRIAS COSMIC, S_A_U_$5407$2] AS Mov 
			WHERE (bucket = 5) AND (f1 = 3) AND (f11 = @Producto)  AND (f30 = @Almacen) 
					AND (f50002 = CONVERT(DATETIME, '1753-01-01 00:00:00', 102))

	end
	if @Almacen = ''
	begin
		SELECT @vStock = isnull(s12,0)
			FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] AS Mov 
			WHERE (bucket = 3) AND (f2 = @Producto)
		
		SELECT @vCdaLanz = isnull(SUM(s61),0)
			FROM [INDUSTRIAS COSMIC, S_A_U_$5407$2] AS Mov 
			WHERE (bucket = 5) AND (f1 = 3) AND (f11 = @Producto)
					AND (f50002 = CONVERT(DATETIME, '1753-01-01 00:00:00', 102))

	end
	set @vStockLibre = @vStock - @vCdaLanz

	RETURN ISNULL(@vStockLibre,0)


END






GO

/****** Object:  UserDefinedFunction [dbo].[fncDesCriterio]    Script Date: 11/18/2014 20:26:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncDesCriterio] 
(
	@Nivel varchar(20)
)
RETURNS varchar(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @DesCrit varchar(50)
	declare @tNivel varchar(10)
	declare @valNivel varchar(10)

	set @DesCrit = ''
	set @tNivel = Left(@Nivel,5)
	set @valNivel = Right(@Nivel,1)
	if @tNivel = 'Nivel'
		begin
			if (@valNivel = 'A') or (@valNivel = 'B')
				begin
					set @DesCrit = 'Nivel'
				end
				else
				begin
					set @DesCrit = 'MedioNivel'
				end
		end

	if @tNivel = 'Combi'
		begin
			set @DesCrit = @valNivel + @tNivel
		end

	RETURN @DesCrit

END














GO

/****** Object:  UserDefinedFunction [dbo].[fncVentaDLCli]    Script Date: 11/18/2014 20:26:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncVentaDLCli] 
(
	@Cliente nvarchar(20),
	@Usuario nvarchar(50),
	@IdenFiltros nvarchar(50)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @vVenta decimal(18,2)
	DECLARE @Desde datetime
	DECLARE @Hasta datetime

    set @Desde = dbo.fncFiltroFechaDesde(@Usuario,@IdenFiltros)
    set @Hasta = dbo.fncFiltroFechaHasta(@Usuario,@IdenFiltros)


	if ((@Desde > '') and (@Hasta > ''))
	begin
		SELECT @vVenta = Sum(s18)
			FROM [INDUSTRIAS COSMIC, S_A_U_$21$1] AS Mov 
			WHERE (bucket = 7) and (f4 >= @Desde) AND (f4 <= @Hasta)  AND (f3 = @Cliente)
	end

--	if ((@Desde > '') and (@Hasta = ''))
--	begin
--		SELECT @vVenta = Sum(s18)
--			FROM [INDUSTRIAS COSMIC, S_A_U_$21$1] AS Mov 
--			WHERE (bucket = 7) and (f4 >= @Desde) AND (f3 = @Cliente)
--	end
--
--	if ((@Desde = '') and (@Hasta > ''))
--	begin
--		SELECT @vVenta = Sum(s18)
--			FROM [INDUSTRIAS COSMIC, S_A_U_$21$1] AS Mov 
--			WHERE (bucket = 7) and (f4 <= @Hasta)  AND (f3 = @Cliente)
--	end
--
--	if ((@Desde = '') and (@Hasta = ''))
--	begin
--		SELECT @vVenta = Sum(s18)
--			FROM [INDUSTRIAS COSMIC, S_A_U_$21$1] AS Mov 
--			WHERE (bucket = 1) AND (f3 = @Cliente)
--	end


	RETURN ISNULL(@vVenta,0)

END













GO

/****** Object:  UserDefinedFunction [dbo].[fncFiltroFechaDesde]    Script Date: 11/18/2014 20:26:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncFiltroFechaDesde] 
(
	@Usuario nvarchar(50),
	@IdenFil nvarchar(50)

)
RETURNS datetime
AS
BEGIN
	-- Declare the return variable here
		declare @DFecha datetime

		SELECT top(1) @DFecha = FiltroFechaDesde
			FROM [AFiltros] where IdentFiltros = @IdenFil



	RETURN ISNULL(@DFecha,'01/01/1753 0:00:00')

END














GO

/****** Object:  UserDefinedFunction [dbo].[fncFiltroFechaHasta]    Script Date: 11/18/2014 20:26:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncFiltroFechaHasta] 
(
	@Usuario nvarchar(50),
	@IdenFil nvarchar(50)

)
RETURNS datetime
AS
BEGIN
	-- Declare the return variable here
		declare @HFecha datetime

		SELECT top(1) @HFecha = FiltroFechaHasta
			FROM [AFiltros] where IdentFiltros = @IdenFil



	RETURN ISNULL(@HFecha,'01/01/1753 0:00:00')

END













GO

/****** Object:  UserDefinedFunction [dbo].[fncIncNumSer]    Script Date: 11/18/2014 20:26:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncIncNumSer] 
(
	@NumSer varchar(20)

)
RETURNS varchar(20)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ParteNum int
	DECLARE @ParteNumStr varchar(20)
	DECLARE @ParteNumMas int
	declare @NumCarNum int
	declare @NumCarTot int
	DECLARE @Ceros varchar(20)
    declare @ParteStr varchar(20)
	declare @NewNum varchar(20)
    declare @Cont int
    declare @Car nvarchar(1)
    

    set @ParteNumStr = Substring(@NumSer,CharIndex('-',@NumSer,0)+1,Len(@NumSer))
    set @ParteNumStr = @NumSer
    set @NumCarNum=len(@ParteNumStr)
    set @NumCarTot=len(@NumSer)
    
    if @ParteNumStr = @NumSer
		begin
			set @Cont = 0;
			Set @ParteNumStr = ''
			while @Cont < @NumCarNum
				begin
					Set @Car = substring(@NumSer,len(@NumSer)-@Cont,1)
					if (isnumeric(@Car)=0) or (@Car = '-')
						begin
							break
						end
						
						Set @ParteNumStr = @Car + @ParteNumStr
						Set @Cont = @Cont+1
				end
			Set @Cont = 0
				
				
		
		end
		
    set @NumCarNum=len(@ParteNumStr)
    set @ParteNum = convert(int,@ParteNumStr)
    set @Ceros = '00000000000000000000'

    --set @ParteStr=Substring(@NumSer,0,CharIndex('-',@NumSer,0))
    set @ParteStr=Substring(@NumSer,1,@NumCarTot-@NumCarNum)
    set @ParteNumMas=@ParteNum + 1
   
    set @NewNum = substring(@Ceros,1,(@NumCarNum - Len(@ParteNumMas))) + ltrim(str(@parteNumMas))
    
	if (@ParteStr <> '')
			begin
				--set @NewNum = @ParteStr + '-' + @NewNum
				set @NewNum = @ParteStr + @NewNum
			end
			else
			begin
				set @NewNum = ''
			end

	if ISNUMERIC(@NumSer) = 1
	begin
		set @NewNum = convert(int,@NumSer) + 1
	end

    RETURN ISNULL(@NewNum,0)

END





GO

/****** Object:  UserDefinedFunction [dbo].[fncProdStLibre]    Script Date: 11/18/2014 20:26:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncProdStLibre] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,4)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStock decimal(18,4),
		@vCdaLanz decimal(18,4),
		@vStockLibre decimal(18,4)

	set @vStock = 0
	set @vCdaLanz = 0

	if @Almacen > ''
	begin
		SELECT @vStock = isnull(s12,0)
			FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] AS Mov 
			WHERE (bucket = 4) AND (f2 = @Producto)  AND (f8 = @Almacen)
		
		SELECT @vCdaLanz = isnull(s61,0)
			FROM [INDUSTRIAS COSMIC, S_A_U_$5407$2] AS Mov 
			WHERE (bucket = 5) AND (f1 = 3) AND (f11 = @Producto)  AND (f30 = @Almacen) 
					AND (f50002 = CONVERT(DATETIME, '1753-01-01 00:00:00', 102))

	end
	if @Almacen = ''
	begin
		SELECT @vStock = isnull(s12,0)
			FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] AS Mov 
			WHERE (bucket = 3) AND (f2 = @Producto)
		
		SELECT @vCdaLanz = isnull(SUM(s61),0)
			FROM [INDUSTRIAS COSMIC, S_A_U_$5407$2] AS Mov 
			WHERE (bucket = 5) AND (f1 = 3) AND (f11 = @Producto)
					AND (f50002 = CONVERT(DATETIME, '1753-01-01 00:00:00', 102))

	end
	set @vStockLibre = @vStock - @vCdaLanz

	RETURN ISNULL(@vStockLibre,0)


END







GO

/****** Object:  UserDefinedFunction [dbo].[fncCdadCompoLanz]    Script Date: 11/18/2014 20:26:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
Create FUNCTION [dbo].[fncCdadCompoLanz] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStock decimal(18,2)

	if @Almacen > ''
	begin
		SELECT @vStock = s61
			FROM [INDUSTRIAS COSMIC, S_A_U_$5407$2] AS Mov 
			WHERE (bucket = 3) AND (f1 = 3) AND (f11 = @Producto)  AND (f30 = @Almacen)
	end
	if @Almacen = ''
	begin
		SELECT @vStock = SUM(s61)
			FROM [INDUSTRIAS COSMIC, S_A_U_$5407$2] AS Mov 
			WHERE (bucket = 3) AND (f1 = 3) AND (f11 = @Producto)
	end

	RETURN ISNULL(@vStock,0)


END


GO

/****** Object:  UserDefinedFunction [dbo].[fncProdDVPen]    Script Date: 11/18/2014 20:26:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncProdDVPen] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStock decimal(18,2)

	if @Almacen > ''
	begin
		SELECT @vStock = s16
			FROM [INDUSTRIAS COSMIC, S_A_U_$37$2] AS Mov 
			WHERE (bucket = 4) and (f1 = 5) AND (f6 = @Producto)  AND (f7 = @Almacen)
	end
	if @Almacen = ''
	begin
		SELECT @vStock = s16
			FROM [INDUSTRIAS COSMIC, S_A_U_$37$2] AS Mov 
			WHERE (bucket = 3) and (f1 = 5) AND (f6 = @Producto)
	end

	RETURN ISNULL(@vStock,0)

END



GO

/****** Object:  UserDefinedFunction [dbo].[fncProdABPen]    Script Date: 11/18/2014 20:26:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncProdABPen] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStock decimal(18,2)

	if @Almacen > ''
	begin
		SELECT @vStock = s16
			FROM [INDUSTRIAS COSMIC, S_A_U_$37$2] AS Mov 
			WHERE (bucket = 4) and (f1 = 3) AND (f6 = @Producto)  AND (f7 = @Almacen)
	end
	if @Almacen = ''
	begin
		SELECT @vStock = s16
			FROM [INDUSTRIAS COSMIC, S_A_U_$37$2] AS Mov 
			WHERE (bucket = 3) and (f1 = 3) AND (f6 = @Producto)
	end

	RETURN ISNULL(@vStock,0)

END



GO

/****** Object:  UserDefinedFunction [dbo].[fncProdOFPen]    Script Date: 11/18/2014 20:26:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncProdOFPen] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStock decimal(18,2)

	if @Almacen > ''
	begin
		SELECT @vStock = s16
			FROM [INDUSTRIAS COSMIC, S_A_U_$37$2] AS Mov 
			WHERE (bucket = 4) and (f1 = 0) AND (f6 = @Producto)  AND (f7 = @Almacen)
	end
	if @Almacen = ''
	begin
		SELECT @vStock = s16
			FROM [INDUSTRIAS COSMIC, S_A_U_$37$2] AS Mov 
			WHERE (bucket = 3) and (f1 = 0) AND (f6 = @Producto)
	end

	RETURN ISNULL(@vStock,0)

END



GO

/****** Object:  UserDefinedFunction [dbo].[fncProdPVPen]    Script Date: 11/18/2014 20:26:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncProdPVPen] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStock decimal(18,2)

	if @Almacen > ''
	begin
		SELECT @vStock = s16
			FROM [INDUSTRIAS COSMIC, S_A_U_$37$2] AS Mov 
			WHERE (bucket = 4) and (f5 = 2) and (f1 = 1) AND (f6 = @Producto)  AND (f7 = @Almacen)
	end
	if @Almacen = ''
	begin
		SELECT @vStock = s16
			FROM [INDUSTRIAS COSMIC, S_A_U_$37$2] AS Mov 
			WHERE (bucket = 3) and (f5 = 2) and (f1 = 1) AND (f6 = @Producto)
	end

	RETURN ISNULL(@vStock,0)

END




GO

/****** Object:  UserDefinedFunction [dbo].[fncProductoAlmacen]    Script Date: 11/18/2014 20:26:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fncProductoAlmacen] 
(
	@Producto nvarchar(20),
	@Almacen nvarchar(20)
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE 
		@vStock decimal(18,2)

	if @Almacen > ''
	begin
		SELECT @vStock = s12
			FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] AS Mov 
			WHERE (bucket = 4) AND (f2 = @Producto)  AND (f8 = @Almacen)
	end
	if @Almacen = ''
	begin
		SELECT @vStock = s12
			FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] AS Mov 
			WHERE (bucket = 3) AND (f2 = @Producto)
	end

	RETURN ISNULL(@vStock,0)


END




GO

