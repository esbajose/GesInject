USE [Cosmic]
GO

/****** Object:  StoredProcedure [dbo].[SWEB_GET_PRODUCTOS]    Script Date: 11/18/2014 20:25:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SWEB_GET_PRODUCTOS] 
 	@Producto nVarchar(20)

AS

declare @vCampo varchar(50)
declare @vCampos varchar(max)
	set @vCampos=''
	set @vCampo=''

	--Crea cursor 
	Declare cCampos Cursor For
	SELECT COLUMN_NAME
	FROM INFORMATION_SCHEMA.COLUMNS 
	WHERE TABLE_NAME='INDUSTRIAS COSMIC, S_A_U_$Item' 
			AND COLUMN_NAME!='timestamp'		
			--AND COLUMN_NAME!='Picture'		
	--Recorre Cursor
	Open cCampos
	Fetch Next From cCampos
		Into @vCampo
	While @@Fetch_Status = 0
	Begin

		set @vCampos = @vCampos + ',[' + @vCampo + ']'

		Fetch Next From cCampos
			Into @vCampo
	end
	Close cCampos
	Deallocate cCampos
	--Fin de cursor

	set @vCampos=substring(@vCampos,2,Len(@vCampos));

if @Producto = ''
	begin
	    exec('select ' + @vCampos + ' from dbo.[INDUSTRIAS COSMIC, S_A_U_$Item] as Prods ');
	end
if @Producto != ''
	begin
		--Select @vCampos
	    exec('select ' + @vCampos + ' from dbo.[INDUSTRIAS COSMIC, S_A_U_$Item] as Prods	where [No_] = ''' + @Producto + '''');
	end


--    select (SELECT COLUMN_NAME
--			FROM INFORMATION_SCHEMA.COLUMNS 
--			WHERE TABLE_NAME='INDUSTRIAS COSMIC, S_A_U_$Customer' 
--			AND COLUMN_NAME!='Picture')
--	from dbo.[INDUSTRIAS COSMIC, S_A_U_$Customer] as Cli;









GO

/****** Object:  StoredProcedure [dbo].[SWEB_GET_CLIENTES]    Script Date: 11/18/2014 20:25:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SWEB_GET_CLIENTES] 
 	@Cliente nVarchar(20)

AS
if @Cliente = ''
	begin
		SELECT     No_, [Name], [Search Name], [Name 2], Address, [Address 2], City, Contact, [Phone No_], [Telex No_], [Our Account No_], [Territory Code] 
							  ,[Global Dimension 1 Code], [Global Dimension 2 Code], [Chain Name], [Budgeted Amount], [Credit Limit (LCY)], [Customer Posting Group] 
							  ,[Currency Code], [Customer Price Group], [Language Code], [Statistics Group], [Payment Terms Code], [Fin_ Charge Terms Code], [Salesperson Code] 
							  ,[Shipment Method Code], [Shipping Agent Code], [Place of Export], [Invoice Disc_ Code], [Customer Disc_ Group], [Country Code], [Collection Method] 
							  ,Amount, Blocked, [Invoice Copies], [Last Statement No_], [Print Statements], [Bill-to Customer No_], Priority, [Payment Method Code] 
--							  ,[Last Date Modified], [Application Method], [Prices Including VAT], [Location Code], [Fax No_], [Telex Answer Back], [VAT Registration No_] 
--							  ,[Combine Shipments], [Gen_ Bus_ Posting Group], [Post Code], County, [E-Mail], [Home Page], [Reminder Terms Code], [No_ Series], [Tax Area Code] 
--							  ,[Tax Liable], [VAT Bus_ Posting Group], Reserve, [Allow Payment Tolerance], [Primary Contact No_], [Responsibility Center], [Shipping Advice] 
--							  ,[Shipping Time], [Shipping Agent Service Code], [Service Zone Code], [Customer Template], [Notification Process Code], [Queue Priority] 
--							  ,[Allow Line Disc_], [Base Calendar Code], [Payment Days Code], [Non-Paymt_ Periods Code], [Tiene Ref_ Cruzada], [Contacto contabilidad] 
--							  ,[Correo-e contabilidad], [Contacto ATC], [E-Mail ATC], [Excluir mod_ 347], [Último traspaso], Tipo, [Direcc_ Envío por defecto], [Cargo Cto_ Contabilidad] 
--							  ,[Cargo Cto_ ATC], [Cargo Cto_ Comercial], [No Notificado cambio tarifa], [Factura intrastat], Consumo, Clasificación, [Albarán Valorado] 
--							  ,[Copia Factura Castellano], [Con Restos de Pedidos], [No Mostrar Descuentos], [Excluir Entrega Automática], [Nº Copias Albarán], [Bloqueado Ventas] 
--							  ,[Nivel de Prioridad], [Nuestro Banco], [Naturaleza Transacción], [Especificación Transacción], [Modo Transporte], [Puerto _ Aerop_ descarga] 
--							  ,[Cód_ Provincia], [No imprimir albarán], [Nº copias castellano], [Plazo de Expedición], [Notificar PV], [Notificar Expedición], [E-Mail Notificación PV] 
--							  ,[E-Mail Copia Notificación PV], [E-Mail Notificación Expe], [E-Mail Copia Notificación Expe], [Prioridad Expedición], Marca, [Palet Plástico], Promociones
--							  ,[Localización establecimiento], Aparcamiento, [Superficie establecimiento], [Superficie ntra_ Exposición], [Objetivo facturación], [Nº_ Ruta] 
--							  ,[Frecuencia visita], [Día Entrega], Clasifica, [Num_ Proveedor], [xNº Cop_ L_ Contenido], Instrastat, xObjetivo, [Tipo Negocio], [Fecha Alta], Rappel 
--							  ,[Factura por Albarán], [Día Facturación], [A cargo de], Responsabilidad, Zona, [Punto Operacional], [Fecha CP->Cli], [Desviación días pago] 
--							  ,[xCód_ Tarifa], [Default Bank Acc_ Code], Potencialidad, [Clasificación Excepcional], VentaPD2008, VentaPD2009, [Viene de], [Pasa a] 
--							  ,[Motivo excepcionalidad], [Crédito Sobrepasado], IdentFiltros, VentaDL, Provisión, [Fecha marcado Provisión]
				
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Customer] AS Clientes		
	end
if @Cliente != ''
	begin
		SELECT     No_, [Name], [Search Name], [Name 2], Address, [Address 2], City, Contact, [Phone No_], [Telex No_], [Our Account No_], [Territory Code] 
							  ,[Global Dimension 1 Code], [Global Dimension 2 Code], [Chain Name], [Budgeted Amount], [Credit Limit (LCY)], [Customer Posting Group] 
							  ,[Currency Code], [Customer Price Group], [Language Code], [Statistics Group], [Payment Terms Code], [Fin_ Charge Terms Code], [Salesperson Code] 
							  ,[Shipment Method Code], [Shipping Agent Code], [Place of Export], [Invoice Disc_ Code], [Customer Disc_ Group], [Country Code], [Collection Method] 
							  ,Amount, Blocked, [Invoice Copies], [Last Statement No_], [Print Statements], [Bill-to Customer No_], Priority, [Payment Method Code] 
							  ,[Last Date Modified], [Application Method], [Prices Including VAT], [Location Code], [Fax No_], [Telex Answer Back], [VAT Registration No_] 
							  ,[Combine Shipments], [Gen_ Bus_ Posting Group], [Post Code], County, [E-Mail], [Home Page], [Reminder Terms Code], [No_ Series], [Tax Area Code] 
							  ,[Tax Liable], [VAT Bus_ Posting Group], Reserve, [Allow Payment Tolerance], [Primary Contact No_], [Responsibility Center], [Shipping Advice] 
							  ,[Shipping Time], [Shipping Agent Service Code], [Service Zone Code], [Customer Template], [Notification Process Code], [Queue Priority] 
							  ,[Allow Line Disc_], [Base Calendar Code], [Payment Days Code], [Non-Paymt_ Periods Code], [Tiene Ref_ Cruzada], [Contacto contabilidad] 
							  ,[Correo-e contabilidad], [Contacto ATC], [E-Mail ATC], [Excluir mod_ 347], [Último traspaso], Tipo, [Direcc_ Envío por defecto], [Cargo Cto_ Contabilidad] 
							  ,[Cargo Cto_ ATC], [Cargo Cto_ Comercial], [No Notificado cambio tarifa], [Factura intrastat], Consumo, Clasificación, [Albarán Valorado]
							  ,[Copia Factura Castellano], [Con Restos de Pedidos], [No Mostrar Descuentos], [Excluir Entrega Automática], [Nº Copias Albarán], [Bloqueado Ventas] 
							  ,[Nivel de Prioridad], [Nuestro Banco], [Naturaleza Transacción], [Especificación Transacción], [Modo Transporte], [Puerto _ Aerop_ descarga] 
							  ,[Cód_ Provincia], [No imprimir albarán], [Nº copias castellano], [Plazo de Expedición], [Notificar PV], [Notificar Expedición], [E-Mail Notificación PV] 
							  ,[E-Mail Copia Notificación PV], [E-Mail Notificación Expe], [E-Mail Copia Notificación Expe], [Prioridad Expedición], Marca, [Palet Plástico], Promociones
							  ,[Localización establecimiento], Aparcamiento, [Superficie establecimiento], [Superficie ntra_ Exposición], [Objetivo facturación], [Nº_ Ruta] 
							  ,[Frecuencia visita], [Día Entrega], Clasifica, [Num_ Proveedor], [xNº Cop_ L_ Contenido], Instrastat, xObjetivo, [Tipo Negocio], [Fecha Alta], Rappel 
							  ,[Factura por Albarán], [Día Facturación], [A cargo de], Responsabilidad, Zona, [Punto Operacional], [Fecha CP->Cli], [Desviación días pago] 
							  ,[xCód_ Tarifa], [Default Bank Acc_ Code], Potencialidad, [Clasificación Excepcional], VentaPD2008, VentaPD2009, [Viene de], [Pasa a] 
							  ,[Motivo excepcionalidad], [Crédito Sobrepasado], IdentFiltros, VentaDL, Provisión, [Fecha marcado Provisión]
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Customer] AS Clientes		
		where [No_] = @Cliente

		SELECT        [Customer No_], Code, Name, [Name 2], Address, [Address 2], City, Contact, [Phone No_], [Telex No_], [Shipment Method Code] 
						  ,[Shipping Agent Code], [Place of Export], [Country Code], [Last Date Modified], [Location Code], [Fax No_], [Telex Answer Back], [Post Code], County 
						  ,[E-Mail], [Home Page], [Tax Area Code], [Tax Liable], [Shipping Agent Service Code], [Service Zone Code], [Contacto contabilidad] 
						  ,[Correo-e contabilidad], [Cód_ Vendedor], [Envío material], Documentación, [Punto de venta], Intrastat, [Cliente referente zona] 
						  ,[Cargo Cto_ Comercial], [Punto Operacional], [Nota Entrega], Marca
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Ship-to Address] as DirEnv
		WHERE [Customer No_] = @Cliente

	end


--    select (SELECT COLUMN_NAME
--			FROM INFORMATION_SCHEMA.COLUMNS 
--			WHERE TABLE_NAME='INDUSTRIAS COSMIC, S_A_U_$Customer' 
--			AND COLUMN_NAME!='Picture')
--	from dbo.[INDUSTRIAS COSMIC, S_A_U_$Customer] as Cli;












GO

/****** Object:  StoredProcedure [dbo].[GEN_ALTA_MOVIADICIONAL]    Script Date: 11/18/2014 20:25:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_ALTA_MOVIADICIONAL]
	@TipoMov as int,
	@No as nvarchar(20),
	@Situacion as nvarchar(10),
	@Fecha as nvarchar(20),
	@Nota as nvarchar(100),
	@Usuario as nvarchar(20),
	@Hora as nvarchar(20),
	@ide as Bigint,
	@FechaMovimiento as nvarchar(20),
	@TipoReferencia as int,
	@Hueco as int,
	@Pedido as nvarchar(10),
	@CodigoAlmacen as nvarchar(10),
	@E_add_S_Parcial as int,
	@LoteFabricacionProducto as nvarchar(10),
	@MatriculaPalet as nvarchar(10),
	@HoraMovimiento as nvarchar(20),
	@MatPaletDest_origen as nvarchar(10),
	@CantidadDec as decimal(38,20),
	@TipoPalet as int,
	
	@NEP as nvarchar(20),
	@SeleccionRA as int,
	@IdeRA as nvarchar(10),
	@CodAlmacenFisico as nvarchar(15),
	@ZonaAlmacen as nvarchar(20),
	@Externo as int,
	@Res int output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    declare @vFechaMov varchar(20)
    declare @vHora varchar(20)
	declare @vNEp varchar(20)
	declare @CanMov decimal(18,4)
	declare @IdKey integer
	
    set @vFechaMov = convert(varchar,datepart(day,GETDATE())) + '/' + convert(varchar,datepart(month,GETDATE())) + '/' + convert(varchar,datepart(year,GETDATE())) + ' 0:00:00'
    set @vHora = '01/01/1754 ' + convert(varchar,datepart(hh,GETDATE())) + ':' + convert(varchar,datepart(n,GETDATE())) + ':' + convert(varchar,datepart(s,GETDATE()))
    set @vFechaMov = @Fecha
	set @vHora = @Hora
	
	--insert into dbo.[INDUSTRIAS COSMIC, S_A_U_$MoviAdicional]([Tipo Movimiento],[Nº],
 --              [Situación],[Fecha],[Hora],[Nota],[ide],[Matrícula Palet],
	--		   [Fecha del Movimiento],[Hora del Movimiento],[Usuario],[Tipo Referencia],
	--		   [Hueco],[Pedido],[Código Almacen],[E_Añadir_S_Parcial],[Lote Fabricación Producto],
	--		   [Mat Palet Dest_origen],[Cantidad Dec],[Tipo Palet],[Nº EP],[SelecciónRA],[ideRA],
	--		   [Cód_ Almacén Físico],[Zona Almacén],[Externo],[Destino Final])
	--				values(@TipoMov,@No,@Situacion,@vFechaMov,@vHora,@Nota,
	--						@ide,@MatriculaPalet,@FechaMovimiento,@HoraMovimiento,@Usuario,
	--						@TipoReferencia,@Hueco,@Pedido,@CodigoAlmacen,@E_add_S_Parcial,
	--						@LoteFabricacionProducto,@MatPaletDest_origen,@CantidadDec,
	--						@TipoPalet,@NEP,@SeleccionRA,@IdeRA,@CodAlmacenFisico,@ZonaAlmacen,@Externo,'')
	
	SELECT  @IdKey = max(ideKey)+1
	FROM  [INDUSTRIAS COSMIC, S_A_U_$MoviAdicional]

	insert into dbo.[INDUSTRIAS COSMIC, S_A_U_$MoviAdicional]([Tipo Movimiento],[Nº],
               [Situación],[Fecha],[Hora],[Nota],[ide],[Matrícula Palet],
			   [Fecha del Movimiento],[Hora del Movimiento],[Usuario],[Tipo Referencia],
			   [Hueco],[Pedido],[Código Almacen],[Lote Fabricación Producto],
			   [Cantidad Dec],[Tipo Palet],[Nº EP],[SelecciónRA],[ideRA],
			   [Cód_ Almacén Físico],[Zona Almacén],[Externo],[Destino Final],[ideKey])
					values(@TipoMov,@No,@Situacion,@vFechaMov,@vHora,@Nota,
							@ide,@MatriculaPalet,@FechaMovimiento,@HoraMovimiento,@Usuario,
							@TipoReferencia,@Hueco,@Pedido,@CodigoAlmacen,
							@LoteFabricacionProducto,@CantidadDec,
							@TipoPalet,@NEP,@SeleccionRA,@IdeRA,@CodAlmacenFisico,@ZonaAlmacen,@Externo,'',@IdKey)

	
	begin try
		SELECT @CanMov = SUM([Cantidad Dec])
		FROM [INDUSTRIAS COSMIC, S_A_U_$MoviAdicional]
		WHERE (ide = @ide)	
		
		if (@CanMov > 0)
			begin
				UPDATE [INDUSTRIAS COSMIC, S_A_U_$Zona Adicional]
				SET Q = @CanMov
				WHERE (ide = @ide)
			
			end	
			
			set @Res=1								
	end try
	begin catch 
			set @Res = 0
	end catch
	
	
								

	
END
















GO

/****** Object:  StoredProcedure [dbo].[GEN_GET_NUMSERIE]    Script Date: 11/18/2014 20:25:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_GET_NUMSERIE] 
	@Serie Varchar(20),
	@Grabar int,
	@Res Varchar(20) output
AS
BEGIN
	Declare @UltNum Varchar(20)
	Declare @Line int
	Declare @NewNum varchar(20)

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	set @UltNum = (
		Select Top(1) [Last No_ Used] from [INDUSTRIAS COSMIC, S_A_U_$No_ Series Line]
			where [Series Code] = @Serie 
			order by [Line No_] desc
				   )
	set @Line = (
		Select Top(1) [Line No_] from [INDUSTRIAS COSMIC, S_A_U_$No_ Series Line]
			where [Series Code] = @Serie 
			order by [Line No_] desc
				   )
    

	set @NewNum = dbo.fncIncNumSer(@UltNum)
    if (@Grabar = 1)
		begin
			Update [INDUSTRIAS COSMIC, S_A_U_$No_ Series Line] set [Last No_ Used] = @NewNum
				where (([Series Code] = @Serie)  and ([Line No_] = @Line))

		end
	
	set @Res=@NewNum
END








GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_09]    Script Date: 11/18/2014 20:25:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_09]
	@Web int, 
	@Res Varchar(200) output

AS
BEGIN
	--- 'PRODUCTOACABADO  09'
begin try	
    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end

    Exec('
		delete from ' + @Tabla + '.dbo.ProductoAcabado 


		Insert into ' + @Tabla + '.dbo.ProductoAcabado 

		SELECT     tTexAca.[Cód_ Acabado] AS IdAcabado, 
					SUBSTRING(tTexAca.[Cód_ Acabado], 2, LEN(tTexAca.[Cód_ Acabado]) - 1) AS Acabado, 
					''1'' AS Accesorio,tTexAca.[Cód_ Acabado] + ''.jpg'' as Imagen
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Textos Acabados] AS tTexAca 
							--INNER JOIN
							--[INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd ON tTexAca.[Cód_ Acabado] = tProd.[Cód acabado]
		WHERE     (tTexAca.[Cód_ Idioma] = ''ESPAÑOL'')  and tTexAca.[Cód_ Acabado] > '''' --and tProd.Marca = 1
		group by tTexAca.[Cód_ Acabado]
	')
	
	Set @Res = @@Rowcount

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch

END


GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_90]    Script Date: 11/18/2014 20:25:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_90] 
	@Web int,
	@Res nVarchar(200) output

AS
BEGIN

	--- 'Unificar Idioma 90'
	SET @Res = ''

begin try

    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end
    declare @Sql nvarchar(2500)
    
    declare @ParamDefinition nvarchar(500)
    set @ParamDefinition  = '@ResOut nvarchar(2000) output'

  --  set @Sql = '
		--begin try
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''en-US'',''es-ES'',''Ingles'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''en-US'',''en-US'',''English'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''en-US'',''fr'',''Anglais'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''en-US'',''de'',''German'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''en-US'',''ru'',''Ingles'')
		--		set @ResOut = @ResOut + ''1-OK'' + CHAR(13) + CHAR(10)
		--	end try
		--	begin catch 
		--		set @ResOut = @ResOut + ''1-('' + ERROR_MESSAGE() + '')'' + CHAR(13) + CHAR(10)
		--	end catch

		--begin try
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''es-ES'',''es-ES'',''Español'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''es-ES'',''en-US'',''Spanish'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''es-ES'',''fr'',''Espagnol'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''es-ES'',''de'',''Spanisch'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''es-ES'',''ru'',''Español'')
		--		set @ResOut = @ResOut + '' -- 2-OK'' + CHAR(13) + CHAR(10)
		--	end try
		--	begin catch
		--		set @ResOut = @ResOut + '' -- 2-('' + ERROR_MESSAGE() + '')'' + CHAR(13) + CHAR(10)
		--	end catch

		--begin try
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''fr'',''es-ES'',''Francés'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''fr'',''en-US'',''French'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''fr'',''fr'',''Français'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''fr'',''de'',''Frances'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''fr'',''ru'',''Frances'')
		--		set @ResOut = @ResOut + '' -- 3-OK'' + CHAR(13) + CHAR(10)
		--	end try
		--	begin catch
		--		set @ResOut = @ResOut + '' -- 3-('' + ERROR_MESSAGE() + '')'' + CHAR(13) + CHAR(10)
		--	end catch

		--begin try
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''de'',''es-ES'',''Alemán'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''de'',''en-US'',''German'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''de'',''fr'',''Allemand'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''de'',''de'',''Deutsch'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''de'',''ru'',''Alemán'')
		--		set @ResOut = @ResOut + '' -- 3-OK'' + CHAR(13) + CHAR(10)
		--	end try
		--	begin catch
		--		set @ResOut = @ResOut + '' -- 3-('' + ERROR_MESSAGE() + '')'' + CHAR(13) + CHAR(10)
		--	end catch

		--begin try
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''ru'',''es-ES'',''Ruso'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''ru'',''en-US'',''Ruso'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''ru'',''fr'',''Ruso'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''ru'',''de'',''Ruso'')
		--	insert into ' + @Tabla + '.dbo.Traduccion values(''ru'',''ru'',''Ruso'')
		--		set @ResOut = @ResOut + '' -- 3-OK'' + CHAR(13) + CHAR(10)
		--	end try
		--	begin catch
		--		set @ResOut = @ResOut + '' -- 3-('' + ERROR_MESSAGE() + '')'' + CHAR(13) + CHAR(10)
		--	end catch


		--begin try
		--	update ' + @Tabla + '.dbo.Traduccion
		--	Set Idioma = ''en-US''
		--	WHERE     (Idioma = ''en-GB'')
		--		set @ResOut = @ResOut + '' -- 4-OK'' + CHAR(13) + CHAR(10)
		--	end try
		--	begin catch
		--		set @ResOut = @ResOut + '' -- 4-('' + ERROR_MESSAGE() + '')'' + CHAR(13) + CHAR(10)
		--		--set @ResOut = @ResOut + '' -- 4-OK'' + CHAR(13) + CHAR(10)
		--	end catch
			
		--	--Set @ResOut = @@Rowcount


		--begin try
		--	update ' + @Tabla + '.dbo.Noticia
		--	Set Idioma = ''en-US''
		--	WHERE     (Idioma = ''en-GB'')
		--		set @ResOut = @ResOut + '' -- 5-OK'' + CHAR(13) + CHAR(10)
		--	end try
		--	begin catch
		--		set @ResOut = @ResOut + '' -- 5-('' + ERROR_MESSAGE() + '')'' + CHAR(13) + CHAR(10)
		--	end catch
		--'
		
		--exec sp_executesql @Sql,@ParamDefinition,@ResOut=@Res output


    exec('
		declare @ResOut nvarchar(2000)
		begin try
			insert into ' + @Tabla + '.dbo.Traduccion values(''en-US'',''es-ES'',''Ingles'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''en-US'',''en-US'',''English'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''en-US'',''fr'',''Anglais'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''en-US'',''de'',''Englisch'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''en-US'',''pt'',''Inglês'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''en-US'',''it'',''Inglese'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''en-US'',''ru'',''Ingles'')
				set @ResOut = @ResOut + ''1-OK'' + CHAR(13) + CHAR(10)
			end try
			begin catch 
				set @ResOut = @ResOut + ''1-('' + ERROR_MESSAGE() + '')'' + CHAR(13) + CHAR(10)
			end catch

		begin try
			insert into ' + @Tabla + '.dbo.Traduccion values(''es-ES'',''es-ES'',''Español'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''es-ES'',''en-US'',''Spanish'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''es-ES'',''fr'',''Espagnol'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''es-ES'',''de'',''Spanisch'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''es-ES'',''pt'',''espanhol'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''es-ES'',''it'',''spagnolo'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''es-ES'',''ru'',''Español'')
				set @ResOut = @ResOut + '' -- 2-OK'' + CHAR(13) + CHAR(10)
			end try
			begin catch
				set @ResOut = @ResOut + '' -- 2-('' + ERROR_MESSAGE() + '')'' + CHAR(13) + CHAR(10)
			end catch

		begin try
			insert into ' + @Tabla + '.dbo.Traduccion values(''fr'',''es-ES'',''Francés'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''fr'',''en-US'',''French'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''fr'',''fr'',''Français'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''fr'',''de'',''Frances'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''fr'',''pt'',''Francês'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''fr'',''it'',''Francese'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''fr'',''ru'',''Francés'')
				set @ResOut = @ResOut + '' -- 3-OK'' + CHAR(13) + CHAR(10)
			end try
			begin catch
				set @ResOut = @ResOut + '' -- 3-('' + ERROR_MESSAGE() + '')'' + CHAR(13) + CHAR(10)
			end catch

		begin try
			insert into ' + @Tabla + '.dbo.Traduccion values(''de'',''es-ES'',''Alemán'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''de'',''en-US'',''German'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''de'',''fr'',''Allemand'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''de'',''de'',''Deutsch'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''de'',''pt'',''Alemão'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''de'',''it'',''Tedesco'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''de'',''ru'',''Alemán'')
				set @ResOut = @ResOut + '' -- 3-OK'' + CHAR(13) + CHAR(10)
			end try
			begin catch
				set @ResOut = @ResOut + '' -- 3-('' + ERROR_MESSAGE() + '')'' + CHAR(13) + CHAR(10)
			end catch

		begin try
			insert into ' + @Tabla + '.dbo.Traduccion values(''pt'',''es-ES'',''Portugues'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''pt'',''en-US'',''Portuguese'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''pt'',''fr'',''Portugais'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''pt'',''de'',''Portugiesisch'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''pt'',''pt'',''Português'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''pt'',''it'',''Portoghese'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''pt'',''ru'',''Portugues'')
				set @ResOut = @ResOut + '' -- 3-OK'' + CHAR(13) + CHAR(10)
			end try
			begin catch
				set @ResOut = @ResOut + '' -- 3-('' + ERROR_MESSAGE() + '')'' + CHAR(13) + CHAR(10)
			end catch

		begin try
			insert into ' + @Tabla + '.dbo.Traduccion values(''it'',''es-ES'',''Italiano'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''it'',''en-US'',''Italian'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''it'',''fr'',''Italien'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''it'',''de'',''Italienisch'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''it'',''pt'',''Italiano'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''it'',''it'',''Italiano'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''it'',''ru'',''Italiano'')
				set @ResOut = @ResOut + '' -- 3-OK'' + CHAR(13) + CHAR(10)
			end try
			begin catch
				set @ResOut = @ResOut + '' -- 3-('' + ERROR_MESSAGE() + '')'' + CHAR(13) + CHAR(10)
			end catch

		begin try
			insert into ' + @Tabla + '.dbo.Traduccion values(''ru'',''es-ES'',''Ruso'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''ru'',''en-US'',''Ruso'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''ru'',''fr'',''Ruso'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''ru'',''de'',''Ruso'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''ru'',''pt'',''Ruso'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''ru'',''it'',''Ruso'')
			insert into ' + @Tabla + '.dbo.Traduccion values(''ru'',''ru'',''Ruso'')
				set @ResOut = @ResOut + '' -- 4-OK'' + CHAR(13) + CHAR(10)
			end try
			begin catch
				set @ResOut = @ResOut + '' -- 4-('' + ERROR_MESSAGE() + '')'' + CHAR(13) + CHAR(10)
			end catch


		begin try
			update ' + @Tabla + '.dbo.Traduccion
			Set Idioma = ''en-US''
			WHERE     (Idioma = ''en-GB'')
				set @ResOut = @ResOut + '' -- 5-OK'' + CHAR(13) + CHAR(10)
			end try
			begin catch
				set @ResOut = @ResOut + '' -- 5-('' + ERROR_MESSAGE() + '')'' + CHAR(13) + CHAR(10)
				--set @ResOut = @ResOut + '' -- 5-OK'' + CHAR(13) + CHAR(10)
			end catch
			
			--Set @ResOut = @@Rowcount


		begin try
			update ' + @Tabla + '.dbo.Noticia
			Set Idioma = ''en-US''
			WHERE     (Idioma = ''en-GB'')
				set @ResOut = @ResOut + '' -- 6-OK'' + CHAR(13) + CHAR(10)
			end try
			begin catch
				set @ResOut = @ResOut + '' -- 6-('' + ERROR_MESSAGE() + '')'' + CHAR(13) + CHAR(10)
			end catch
		')
		

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch



END


GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_16]    Script Date: 11/18/2014 20:25:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_16] 
	@Web int,
	@Res Varchar(200) output

AS
BEGIN
	--- 'CONFIGURACION  16'

begin try
    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end

    Exec('
		delete from ' + @Tabla + '.dbo.Configuracion

		Insert into ' + @Tabla + '.dbo.Configuracion 

		SELECT  [Link Inicio 1] as Link1, 
				[Texto Inicio 1] as Nombre1,
				[Imagen Inicio 1] as Imagen1,
				[Link Inicio 2] as Link2,
				[Texto Inicio 2] as Nombre2,
				[Imagen Inicio 2] as Imagen2,
				[Link Inicio 3] as Link3,
				[Texto Inicio 3] as Nombre3,
				[Imagen Inicio 3] as Imagen3,
				[Link Inicio 3_2] as Link3_2
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Configuración Web]
		WHERE     (Id = ''INICIO'') AND (Activo = 1) and (Web = ' + @Web + ')
	')

	Set @Res = @@Rowcount

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch

END


GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_18]    Script Date: 11/18/2014 20:25:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Batch submitted through debugger: SQLQuery17.sql|7|0|C:\Users\JMEscorihuela.COSMIC\AppData\Local\Temp\~vs34F9.sql
-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_18] 
	@Web int, 
	@Res Varchar(200) output
AS
BEGIN
	--- 'EMPRESA  18'


begin try

    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end

    Exec('

		declare @Id varchar(100)
		declare @Idioma varchar(20)
		declare @Valor varchar(200)
		declare @Cont int
		declare @SQL varchar(max)
		

		Declare ctmpEmpresaI Cursor for
			SELECT tTexArti.Código AS IdTraduccion,tLang.[Cod_ Intenacional] AS Idioma, tTexArti.Texto AS Valor
			FROM   [INDUSTRIAS COSMIC, S_A_U_$Traducciones] AS tTexArti left outer JOIN
						  [INDUSTRIAS COSMIC, S_A_U_$Language] AS tLang ON tTexArti.[Cód_ Idioma] = tLang.Code
			WHERE     ((tTexArti.Tipo = 7) and (tTexArti.[Código] = ''GENERAL'') and (tTexArti.Web = ' + @Web + '))

			Open ctmpEmpresaI

				Fetch Next From ctmpEmpresaI
					Into @Id,@Idioma,@Valor
						
				While @@Fetch_Status = 0
				Begin				
					
					set @Cont = 0
					delete from ' + @Tabla + '.dbo.tmpEmpresa
					
					set @SQL = ''INSERT INTO ' + @Tabla + '.dbo.tmpEmpresa 
								SELECT * FROM OPENROWSET(BULK '''''' + @Valor + '''''', SINGLE_NCLOB) AS e''							
								
					EXEC (@SQL);
		                                   
					declare @Html0 nvarchar(MAX)
					declare @Html nvarchar(MAX)

					Declare ctmpEmpresa Cursor for
						SELECT *
						FROM  ' + @Tabla + '.dbo.tmpEmpresa
					Open ctmpEmpresa
							
					Fetch Next From ctmpEmpresa
						Into @Html0
					
					set @Html = ''''		
					While @@Fetch_Status = 0
					Begin	
					   if (@Html0 <> '''')
 					   begin			
							--if (@Cont = 0)
							--begin
							--   set @Html0 = RIGHT(@Html0,len(@Html0)-3)
							--end
							
							set @Cont = @Cont +1

							set @Html += @Html0		
							
					  End
					  
					  Fetch Next From ctmpEmpresa
					  Into @Html0

					end
					Close ctmpEmpresa
					Deallocate ctmpEmpresa
					
					
					IF EXISTS (SELECT * FROM ' + @Tabla + '.dbo.Traduccion WHERE IdTraduccion = ''DesEmpresa'' and Idioma = @Idioma)
						update ' + @Tabla + '.dbo.Traduccion
						set Valor = @Html
						where IdTraduccion = ''DesEmpresa'' and Idioma = @Idioma 				
					ELSE
						INSERT INTO ' + @Tabla + '.dbo.Traduccion VALUES (''DesEmpresa'',@Idioma,@Html)			
			
						
					Fetch Next From ctmpEmpresaI
						Into @Id,@Idioma,@Valor
				end
				Close ctmpEmpresaI
				Deallocate ctmpEmpresaI
		')
		
	Set @Res = 'Correcto'

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch


--Close ctmpEmpresaI
--Deallocate ctmpEmpresaI

-----print 'EMPRESA  18_AVISO'
begin try
    Exec('

		declare @Id varchar(100)
		declare @Idioma varchar(20)
		declare @Valor varchar(200)
		declare @Cont int
		declare @SQL varchar(max)
		
		Declare ctmpEmpresaI Cursor for
		SELECT tTexArti.Código AS IdTraduccion,tLang.[Cod_ Intenacional] AS Idioma, tTexArti.Texto AS Valor
		FROM   [INDUSTRIAS COSMIC, S_A_U_$Traducciones] AS tTexArti INNER JOIN
					  [INDUSTRIAS COSMIC, S_A_U_$Language] AS tLang ON tTexArti.[Cód_ Idioma] = tLang.Code
		WHERE     ((tTexArti.Tipo = 7) and (tTexArti.[Código] = ''AVISO LEGAL'') and (tTexArti.Web = ' + @Web + '))

		Open ctmpEmpresaI

			Fetch Next From ctmpEmpresaI
				Into @Id,@Idioma,@Valor
					
			While @@Fetch_Status = 0
			Begin				
				
				set @Cont = 0
				delete from ' + @Tabla + '.dbo.tmpEmpresa
				            
				set @SQL = ''INSERT INTO ' + @Tabla + '.dbo.tmpEmpresa 
							SELECT * FROM OPENROWSET(BULK '''''' + @Valor + '''''', SINGLE_NCLOB) AS e''
				EXEC (@SQL);

				declare @Html0 nvarchar(MAX)
				declare @Html nvarchar(MAX)

	                                   
				Declare ctmpEmpresa Cursor for
					SELECT *
					FROM  ' + @Tabla + '.dbo.tmpEmpresa
				Open ctmpEmpresa
						
				Fetch Next From ctmpEmpresa
					Into @Html0
				
				set @Html = ''''		
				While @@Fetch_Status = 0
				Begin	
				   if (@Html0 <> '''')
 				   begin			
						--if (@Cont = 0)
						--begin
						--   set @Html0 = RIGHT(@Html0,len(@Html0)-3)
						--end
						set @Cont = @Cont +1

						set @Html += @Html0		
						
				  End
				  
				  Fetch Next From ctmpEmpresa
				  Into @Html0

				end
				Close ctmpEmpresa
				Deallocate ctmpEmpresa
				
				
				IF EXISTS (SELECT * FROM ' + @Tabla + '.dbo.Traduccion WHERE IdTraduccion = ''AvisoLegalInfo'' and Idioma = @Idioma)
					update ' + @Tabla + '.dbo.Traduccion
					set Valor = @Html
					where IdTraduccion = ''AvisoLegalInfo'' and Idioma = @Idioma				
				ELSE
					INSERT INTO ' + @Tabla + '.dbo.Traduccion VALUES (''AvisoLegalInfo'',@Idioma,@Html)			
		
					
				Fetch Next From ctmpEmpresaI
					Into @Id,@Idioma,@Valor
			end
			Close ctmpEmpresaI
			Deallocate ctmpEmpresaI
		')
		
	Set @Res = 'Correcto'

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessageAviso;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch

--Close ctmpEmpresaI
--Deallocate ctmpEmpresaI

--------------------------------------------------------------------------------------------------------

print 'EMPRESA  18_COPYRIGHT'


begin try
    Exec('

		declare @Id varchar(100)
		declare @Idioma varchar(20)
		declare @Valor varchar(200)
		declare @Cont int
		declare @SQL varchar(max)
		
		Declare ctmpEmpresaI Cursor for
		SELECT tTexArti.Código AS IdTraduccion,tLang.[Cod_ Intenacional] AS Idioma, tTexArti.Texto AS Valor
		FROM   [INDUSTRIAS COSMIC, S_A_U_$Traducciones] AS tTexArti INNER JOIN
					  [INDUSTRIAS COSMIC, S_A_U_$Language] AS tLang ON tTexArti.[Cód_ Idioma] = tLang.Code
		WHERE     ((tTexArti.Tipo = 7) and (tTexArti.[Código] = ''COPYRIGHT'') and (tTexArti.Web = ' + @Web + '))

		Open ctmpEmpresaI

			Fetch Next From ctmpEmpresaI
				Into @Id,@Idioma,@Valor
					
			While @@Fetch_Status = 0
			Begin				
				
				set @Cont = 0
				delete from ' + @Tabla + '.dbo.tmpEmpresa
				            
				set @SQL = ''INSERT INTO ' + @Tabla + '.dbo.tmpEmpresa 
							SELECT * FROM OPENROWSET(BULK '''''' + @Valor + '''''', SINGLE_NCLOB) AS e''
				EXEC (@SQL);
	                                   
				declare @Html0 nvarchar(MAX)
				declare @Html nvarchar(MAX)


				Declare ctmpEmpresa Cursor for
					SELECT *
					FROM  ' + @Tabla + '.dbo.tmpEmpresa
				Open ctmpEmpresa
						
				Fetch Next From ctmpEmpresa
					Into @Html0
				
				set @Html = ''''		
				While @@Fetch_Status = 0
				Begin	
				   if (@Html0 <> '''')
 				   begin			
						--if (@Cont = 0)
						--begin
						--   set @Html0 = RIGHT(@Html0,len(@Html0)-3)
						--end
						set @Cont = @Cont +1

						set @Html += @Html0		
						
				  End
				  
				  Fetch Next From ctmpEmpresa
				  Into @Html0

				end
				Close ctmpEmpresa
				Deallocate ctmpEmpresa
				
				
				IF EXISTS (SELECT * FROM ' + @Tabla + '.dbo.Traduccion WHERE IdTraduccion = ''CopyrightInfo'' and Idioma = @Idioma)
					update ' + @Tabla + '.dbo.Traduccion
					set Valor = @Html
					where IdTraduccion = ''CopyrightInfo'' and Idioma = @Idioma				
				ELSE
					INSERT INTO ' + @Tabla + '.dbo.Traduccion VALUES (''CopyrightInfo'',@Idioma,@Html)			
		
					
				Fetch Next From ctmpEmpresaI
					Into @Id,@Idioma,@Valor
			end
			Close ctmpEmpresaI
			Deallocate ctmpEmpresaI
		')
		
	Set @Res = 'Correcto'

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessageCopy;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch

--------------------------------------------------------------------------------------------------------


END


GO

/****** Object:  StoredProcedure [dbo].[ProdSD_Produc_Calc]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ProdSD_Produc_Calc]
	@Fecha nVarchar(50)

AS
BEGIN

		declare @Hoy datetime
		
		set @Hoy = GETDATE()
		--Drop Table #tmpMampPedPen
		--Drop Table #tmpMampPen
		--drop table #tmpPenORFA
		
		--set @Fecha='2012-10-02 12:43:38'
		
		
		--Analizo primero los productos del ORFANATO
		SELECT tLinPed.No_,SUM(tLinPed.[Outstanding Quantity]) AS cAN
		into #tmpPenORFA
		FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line] as tLinPed INNER JOIN
                 [INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd ON tLinPed.No_ = tProd.No_
		WHERE     (tLinPed.[Subtipo Pdo_] = 0) 
				AND (tLinPed.[Document Type] = 1) 
				AND (tLinPed.Marca = 2 OR tLinPed.Marca = 4)
				AND (tLinPed.[Fecha Orfanato] = '1753-01-01 00:00:00.000')
				AND (tLinPed.[SIP Pedido] = '')
				AND (tLinPed.[Roca Cant Confirmada] = 0)
				AND (tLinPed.[Roca Estudiado NO Confirmado] = 0)
				--AND (tLinPed.[Fecha Alta] = @Hoy)
				AND (tLinPed.[Type] = 2) 
			    AND (tProd.[Nombre colección] <> 'VICTORIA')
			    AND (tProd.[Nombre colección] <> 'EASY')			    
				AND (tLinPed.[Outstanding Quantity] > 0) 
				AND (tLinPed.[Location Code] <> 'ORFANATO')
				AND (tLinPed.[Location Code] <> 'ESPECIAL')
				AND (tLinPed.[Location Code] <> 'ABONOS')
		GROUP BY tLinPed.No_


		SELECT #tmpPenORFA.No_ as Producto, CalProductoAlmacen.Stock as Stock, CalProductoAlmacen.PVPen as PVPen,
				(CalProductoAlmacen.Stock - CalProductoAlmacen.PVPen) AS Libre
		Into #tmpStockORFA
		FROM  #tmpPenORFA INNER JOIN
				  CalProductoAlmacen ON #tmpPenORFA.No_ = CalProductoAlmacen.Producto
		WHERE (CalProductoAlmacen.Almacen = N'ORFANATO')
				and (CalProductoAlmacen.Stock > 0)
	
	--Select *
	--From #tmpStockORFA
	
	--Repartimos el stock del ORFANATO entre los pedidos pendientes
	declare @ORProducto as varchar(20)
	declare @ORStock as Decimal(20,4)
	declare @ORPVPen as Decimal(20,4)
	declare @ORLibre as Decimal(20,4)
	declare @ORCanPen as Decimal(20,4)
	declare @ORPedido as varchar(20)
	declare @ORLin as int
    declare @vFechaMov varchar(20)
    declare @OFL varchar(20)
	
    --set @vFechaMov = convert(varchar,datepart(day,GETDATE())) + '/' + convert(varchar,datepart(month,GETDATE())) + '/' + convert(varchar,datepart(year,GETDATE())) + ' 0:00:00'
    set @vFechaMov = convert(varchar,datepart(year,GETDATE())) + '-' + convert(varchar,datepart(month,GETDATE())) + '-' + convert(varchar,datepart(day,GETDATE())) + ' 0:00:00'

				
	--Cursor de productos pendientes con stock en ORFANATO
	Declare ctmpPenORF Cursor for
		SELECT Producto,Stock,PVPen,Libre
		FROM #tmpStockORFA
		
	--Recorre cursor de Faltas
	Open ctmpPenORF

	Fetch Next From ctmpPenORF
		Into @ORProducto,@ORStock,@ORPVPen,@ORLibre

	While @@Fetch_Status = 0
	Begin				
		
		--Repartimos el stock entre los pedidos pendientes		
		Declare ctmpPedidos Cursor for
			SELECT tLinPed.[Outstanding Quantity],tLinPed.[Document No_],tLinPed.[Line No_]
			FROM  [INDUSTRIAS COSMIC, S_A_U_$Sales Line] as tLinPed INNER JOIN
                 [INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd ON tLinPed.No_ = tProd.No_
			WHERE (tLinPed.[Subtipo Pdo_] = 0) 
					AND (tLinPed.[Document Type] = 1) 
					AND (tLinPed.Marca = 2 OR tLinPed.Marca = 4)
					AND (tLinPed.Type = 2) 
					AND (tLinPed.[Fecha Orfanato] = '1753-01-01 00:00:00.000')
					AND (tLinPed.[SIP Pedido] = '')
					AND (tLinPed.[Roca Cant Confirmada] = 0)
					AND (tLinPed.[Roca Estudiado NO Confirmado] = 0)
					--AND (tLinPed.[Fecha Alta] = @Hoy)
					AND (tLinPed.No_ = @ORProducto)
	    		    AND (tProd.[Nombre colección] <> 'VICTORIA')
				    AND (tProd.[Nombre colección] <> 'EASY')			    
					AND (tLinPed.[Outstanding Quantity] > 0) 
					AND (tLinPed.[Location Code] <> 'ESPECIAL')
					AND (tLinPed.[Location Code] <> 'ABONOS')
					AND (tLinPed.[Location Code] <> 'ORFANATO')
		Open ctmpPedidos
				
		Fetch Next From ctmpPedidos
			Into @ORCanPen,@ORPedido,@ORLin

			--Actualizo a True la marca de "Estudio Orfanato"
		   Update [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
		   set [Estudio Orfanato] = 1
		   where [Document No_] = @ORPedido 
				and [Line No_] = @ORLin				   
					
			While @@Fetch_Status = 0
			Begin				
				if (@ORLibre >= @ORCanPen)
					begin
					   SET @OFL = ''
					   SET @OFL = dbo.fncProdOFPed(@ORPedido,@ORLin)
					   if @OFL = ''
					   begin
						   SET @ORLibre = @ORLibre - @ORCanPen
						   --Modificamos la lines del pedido
						   Update [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
						   set [Location Code] = 'ORFANATO',[Fecha Orfanato] = CONVERT(datetime,@vFechaMov,102)
						   where [Document No_] = @ORPedido 
								and [Line No_] = @ORLin				   
						end
					end						
					
				Fetch Next From ctmpPedidos
					Into @ORCanPen,@ORPedido,@ORLin
			end
			Close ctmpPedidos
			Deallocate ctmpPedidos
			--Fin de Reparto 		
				
				
		Fetch Next From ctmpPenORF
		Into @ORProducto,@ORStock,@ORPVPen,@ORLibre

	end
	Close ctmpPenORF
	Deallocate ctmpPenORF
	--Fin del cursor de productos pendientes con stock en ORFANATO
		
	
	
	
		
		
		
		--Creo la tabla de Mamparas Pendientes Normales

		SELECT DISTINCT 
			  tLinPed.No_ as Producto,tLinPed.[Location Code] as Almacen, 
			  SUM(tLinPed.[Outstanding Quantity]) AS PVPen,
			  (dbo.fncProdSt(tLinPed.No_, tLinPed.[Location Code]) + 
			  dbo.fncProdOFabDH(tLinPed.No_, tLinPed.[Location Code],2,3)) as StockT,
			  SUM(tLinPed.[Outstanding Quantity]) - (dbo.fncProdSt(tLinPed.No_, tLinPed.[Location Code]) + 
			  dbo.fncProdOFabDH(tLinPed.No_, tLinPed.[Location Code],2,3)) as Nece			  			  		      
			  
		into #tmpMampPen
		      
		FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line] AS tLinPed LEFT OUTER JOIN
				[INDUSTRIAS COSMIC, S_A_U_$Production Forecast Entry] AS tPrevi ON tLinPed.No_ = tPrevi.[Item No_] LEFT OUTER JOIN
				[INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd ON tLinPed.No_ = tProd.No_
		WHERE (tLinPed.[Document Type] = 1) AND (tLinPed.Type = 2)
				--AND ((tProd.[Nº I_P_] <> ''))
				AND ([Tipo MRP-MPS] > 0)
				and (tProd.[Excluir MRP-MPS] = 0)
				and (tLinPed.[Roca Ref_ Especial] = 0)
				AND (tLinPed.[Location Code] <> 'ORFANATO')
				AND (tLinPed.[Location Code] <> 'ESPECIAL')
				AND (tLinPed.[Location Code] <> 'ABONOS')
				and (tPrevi.[Sección] is Null)
				--and (dbo.fncProdPrevi(tLinPed.No_, tLinPed.[Location Code]) = 0)
		GROUP BY tLinPed.[Location Code], tLinPed.No_
		HAVING  (SUM(tLinPed.[Outstanding Quantity]) > 0)		


		--Creo la Tabla de Pedidos pendientes 
	
		SELECT tLinPed.[Document No_] as Pedido, tLinPed.[Line No_] AS Linea, tLinPed.No_ as Producto, tLinPed.[Location Code] as Almacen,
				 tLinPed.Description as Descripción, tLinPed.[Outstanding Quantity] as Cantidad,
				 dbo.fncProdOFabPV(tLinPed.No_,tLinPed.[Document No_], tLinPed.[Line No_]) as CanOFL,0 as Fab,
			(case when tLinPed.[Plazo Estándar] = '1753-01-01 00:00:00.000' then CONVERT(DATETIME,'2212-12-31 00:00:00',102) else tLinPed.[Plazo Estándar] end) as [Plazo Estándar]
		INTO #tmpMampPedPen
		FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line] AS tLinPed INNER JOIN
				 #tmpMampPen ON tLinPed.[Location Code] = #tmpMampPen.Almacen AND tLinPed.No_ = #tmpMampPen.Producto
		WHERE (tLinPed.[Document Type] = 1) 
				AND (tLinPed.[Outstanding Quantity] <> 0) 
				AND (CONVERT(money, Nece) > 0)	
				and (tLinPed.[Document No_] not like 'SP%')
				AND (tLinPed.[Location Code] <> 'ORFANATO')
				AND (tLinPed.[Location Code] <> 'ESPECIAL')
				AND (tLinPed.[Location Code] <> 'ABONOS')
		order by tLinPed.[Plazo Estándar] desc
		
		
		
	---------------------------------------------------------------------------------------------
	--Proceso de Calculo de Producción
	declare @Pedido as varchar(20)
	declare @Linea as int
	declare @Producto as varchar(20)
	declare @Almacen as varchar(20)
	declare @Descripcion as varchar(50)
	declare @Can as decimal(38,18)
	declare @CanOF as decimal(38,18)
	declare @ID as int
	declare @RCount as int

	declare @Falta as decimal(38,18)
	declare @Nece as decimal(38,18)
	declare @Fab as decimal(38,18)

	--Cursor de Tabla Mampara Pendientes
	Declare ctmpPedPen Cursor for
		SELECT Pedido, Linea, Producto, Almacen, Descripción, Cantidad, CanOFL
		FROM #tmpMampPedPen
		order by [Plazo Estándar] desc,Pedido desc,Linea Desc
		
	--Recorre cursor de Faltas
	Open ctmpPedPen

	Fetch Next From ctmpPedPen
		Into @Pedido,@Linea,@Producto,@Almacen,@Descripcion,@Can,@CanOF

	While @@Fetch_Status = 0
	Begin
		--Busco la cantidad de Stock libre
		SELECT  @Nece=isnull(Nece,0)
		FROM  #tmpMampPen 
		where Producto = @Producto and Almacen = @Almacen

				
		set @Falta = @Can - @CanOF
		if @Falta < 0 begin set @Falta = 0 end
		
		
		if @Falta > 0
		   begin		
			if @Nece >= @Falta
				begin
				   set @Fab = @Falta
				end
				
			if @Nece < @Falta
				begin
				   set @Fab = @Nece
				end



		  --Grabo la nueva Cantidad de Necesidad
		  Update #tmpMampPen With(RowLock)
			set Nece = (@Nece - @Fab)
			where Producto = @Producto and Almacen = @Almacen
				
			if (@Fab > 0)
			begin
				--Actualizo la tabla de Faltas
				update #tmpMampPedPen With(RowLock)
				set Fab = @Fab
				Where Pedido = @Pedido
						AND Linea = @Linea
						and Producto = @Producto						
				set @RCount = @@Rowcount
			end
			end
			
		Fetch Next From ctmpPedPen
			Into @Pedido,@Linea,@Producto,@Almacen,@Descripcion,@Can,@CanOF

	end
	Close ctmpPedPen
	Deallocate ctmpPedPen
	--Fin del cursor de Faltas
	
	--Inserto el Resultado en el Diario de Producción
	Insert into [INDUSTRIAS COSMIC, S_A_U_$SIP Diario de Producción](Fecha, Tipo, Producto, CanPen, Stock, Embalando,
																	 Reserva, Encajado, OEA, StLibre, OFSIP, Fab, [Enviado SIP], 
																	 [SIP Pedido], [SIP Lin Pedido],Almacen,[Ref_ Venta], NoCredito,
																	  NoAcumular)	
	SELECT convert(datetime,@Fecha,102) as Fecha, Pedido + '_' + convert(varchar(20),Linea) AS Tipo, 
			Producto,Cantidad AS CanPen, 
			0 AS Stock,  
			0 AS Embalando,  
			0 AS Reserva,  
			0 AS Encajado,  
			0 AS OEA,   
			0 AS StLibre, 
			0 AS OFSIP,  
			Fab, 
			'' as [Enviado SIP],'' as [SIP Pedido],0 as [SIP Lin Pedido], 
			Almacen,Producto as RefVenta, 
			0 as NoCredito, 
			0 as NoAcumular 
	From #tmpMampPedPen
	Where Fab <> 0	
		
		
		--Selecciono el resultado
		
	SELECT convert(datetime,@Fecha,102) as Fecha, Pedido + '_' + convert(varchar(20),Linea) AS Tipo, 
			Producto,Cantidad AS CanPen, 
			0 AS Stock,  
			0 AS Embalando,  
			0 AS Reserva,  
			0 AS Encajado,  
			0 AS OEA,   
			0 AS StLibre, 
			0 AS OFSIP,  
			Fab, 
			'' as [Enviado SIP],'' as [SIP Pedido],0 as [SIP Lin Pedido], 
			Almacen,Producto as RefVenta, 
			0 as NoCredito, 
			0 as NoAcumular 
	From #tmpMampPedPen
	Where Fab <> 0	
			
	set @RCount = @@Rowcount


END






GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_20]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_20] 
	@Web int,
	@Res Varchar(200) output

AS
BEGIN
	--- 'Imagen Slider Colección  20'

begin try
    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end

    Exec('
		Delete 
		From ' + @Tabla + '.dbo.ImagenSliderColeccion

		Insert Into ' + @Tabla + '.dbo.ImagenSliderColeccion ( IdColeccion, Orden, RutaImagen)

		SELECT  Codigo as IdColeccion,  Orden,[RutaImagen Not Web] as RutaImagen
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Configuración Web]
		WHERE     (Id = ''IMSLCOL'') AND (Activo = 1) and (Web = ' + @Web + ')
		')
		
	Set @Res = @@Rowcount

end try
begin catch
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch

begin try

    Exec('
		Delete 
		From ' + @Tabla + '.dbo.ImagenSliderPrincipal

		Insert Into ' + @Tabla + '.dbo.ImagenSliderPrincipal ( Orden, RutaImagen)

		SELECT  Orden,[Imagen Slider Prin] as RutaImagen
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Configuración Web]
		WHERE     (Id = ''IMSLPRIN'') AND (Activo = 1) and (Web = ' + @Web + ')
		')
		
	Set @Res = @@Rowcount

end try
begin catch
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch

END


GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_19]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_19]
	@Web int,  
	@Res Varchar(200) output
AS
BEGIN
	--- 'Web configuración Htmls   19'


begin try
    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end

    Exec('
		declare @Id varchar(100)
		declare @Idioma varchar(20)
		declare @Valor varchar(200)
		declare @Cont int
		declare @SQL varchar(max)

		Declare ctmpEmpresaI Cursor for
		SELECT     tTexArti.Código AS IdTraduccion, tLang.[Cod_ Intenacional] AS Idioma, tTexArti.Texto AS Valor
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Configuración Web] AS tConfig INNER JOIN
							  [INDUSTRIAS COSMIC, S_A_U_$Traducciones] AS tTexArti ON tConfig.[Imagen Inicio 1] = tTexArti.Código INNER JOIN
							  [INDUSTRIAS COSMIC, S_A_U_$Language] AS tLang ON tTexArti.[Cód_ Idioma] = tLang.Code
		WHERE     (tConfig.Id = ''INICIO'') AND (tConfig.Activo = 1) AND (tTexArti.Tipo = 6) AND (tTexArti.Texto <> '''') and (tTexArti.Web = ' + @Web + ')

		union all

		SELECT     tTexArti.Código AS IdTraduccion, tLang.[Cod_ Intenacional] AS Idioma, tTexArti.Texto AS Valor
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Configuración Web] AS tConfig INNER JOIN
							  [INDUSTRIAS COSMIC, S_A_U_$Traducciones] AS tTexArti ON tConfig.[Imagen Inicio 2] = tTexArti.Código INNER JOIN
							  [INDUSTRIAS COSMIC, S_A_U_$Language] AS tLang ON tTexArti.[Cód_ Idioma] = tLang.Code
		WHERE     (tConfig.Id = ''INICIO'') AND (tConfig.Activo = 1) AND (tTexArti.Tipo = 6) AND (tTexArti.Texto <> '''') and (tTexArti.Web = ' + @Web + ')

		union all

		SELECT     tTexArti.Código AS IdTraduccion, tLang.[Cod_ Intenacional] AS Idioma, tTexArti.Texto AS Valor
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Configuración Web] AS tConfig INNER JOIN
							  [INDUSTRIAS COSMIC, S_A_U_$Traducciones] AS tTexArti ON tConfig.[Imagen Inicio 3] = tTexArti.Código INNER JOIN
							  [INDUSTRIAS COSMIC, S_A_U_$Language] AS tLang ON tTexArti.[Cód_ Idioma] = tLang.Code
		WHERE     (tConfig.Id = ''INICIO'') AND (tConfig.Activo = 1) AND (tTexArti.Tipo = 6) AND (tTexArti.Texto <> '''') and (tTexArti.Web = ' + @Web + ')


			Open ctmpEmpresaI

				Fetch Next From ctmpEmpresaI
					Into @Id,@Idioma,@Valor
						
				While @@Fetch_Status = 0
				Begin				
					
					set @Cont = 0
					delete from ' + @Tabla + '.dbo.tmpEmpresa
		            
					set @SQL = ''INSERT INTO ' + @Tabla + '.dbo.tmpEmpresa 
								SELECT * FROM OPENROWSET(BULK '''''' + @Valor + '''''', SINGLE_NCLOB) AS e''
					EXEC (@SQL);
		                                   
					declare @Html0 nvarchar(MAX)
					declare @Html nvarchar(MAX)
					declare @vCont int

					Declare ctmpEmpresa Cursor for
						SELECT *
						FROM  ' + @Tabla + '.dbo.tmpEmpresa
					Open ctmpEmpresa
							
					Fetch Next From ctmpEmpresa
						Into @Html0
					
					set @Html = ''''		
					While @@Fetch_Status = 0
					Begin	
					   if (@Html0 <> '''')
					   begin			
							if (@Cont = 0)
							--begin
							--   set @Html0 = RIGHT(@Html0,len(@Html0)-3)
							--end
							set @Cont = @Cont +1

							set @Html += @Html0		
							
					  End
					  
					  Fetch Next From ctmpEmpresa
					  Into @Html0

					end
					Close ctmpEmpresa
					Deallocate ctmpEmpresa
					
					
					IF EXISTS (SELECT * FROM ' + @Tabla + '.dbo.Traduccion WHERE IdTraduccion = @Id and Idioma = @Idioma)
						update ' + @Tabla + '.dbo.Traduccion
						set Valor = @Html
						where IdTraduccion = @Id and Idioma = @Idioma				
					ELSE
						INSERT INTO ' + @Tabla + '.dbo.Traduccion VALUES (@Id,@Idioma,@Html)			
			
						
					Fetch Next From ctmpEmpresaI
						Into @Id,@Idioma,@Valor
				end
				Close ctmpEmpresaI
				Deallocate ctmpEmpresaI
			')
			
			
	Set @Res = 'Correcto'

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch
			

END


GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_17]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_17]
	@Web int, 
	@Res Varchar(200) output

AS
BEGIN
	--- 'TRADUCCION  17'

begin try
    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end

    Exec('
		Delete 
		From ' + @Tabla + '.dbo.Traduccion

		--Acabados
		Insert into ' + @Tabla + '.dbo.Traduccion

		SELECT  tTexAca.[Cód_ Acabado] AS IdTraduccion, tLang.[Cod_ Intenacional] AS Idioma, tTexAca.Texto AS Valor
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Textos Acabados] AS tTexAca INNER JOIN
							  [INDUSTRIAS COSMIC, S_A_U_$Language] AS tLang ON tTexAca.[Cód_ Idioma] = tLang.Code
		Where tLang.[Cod_ Intenacional] <> ''''


		--Productos
		Insert into ' + @Tabla + '.dbo.Traduccion

		SELECT  ''Prod_'' + tTexArti.[Cód_ artículo] AS IdTraduccion, tLang.[Cod_ Intenacional] AS Idioma, tTexArti.Texto AS Valor
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Textos Artículos] AS tTexArti INNER JOIN
							  [INDUSTRIAS COSMIC, S_A_U_$Language] AS tLang ON tTexArti.[Cód_ Idioma] = tLang.Code
		Where tLang.[Cod_ Intenacional] <> ''''


		--Comentarios Web
		Insert into ' + @Tabla + '.dbo.Traduccion

		SELECT ''Comen_'' + tTexArti.Código AS IdTraduccion,tLang.[Cod_ Intenacional] AS Idioma, tTexArti.Texto AS Valor
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Traducciones] AS tTexArti INNER JOIN
							  [INDUSTRIAS COSMIC, S_A_U_$Language] AS tLang ON tTexArti.[Cód_ Idioma] = tLang.Code
		WHERE     (tTexArti.Tipo = 10) and (tTexArti.Web = ' + @Web + ')

		--Materiales Web
	DECLARE @NextString NVARCHAR(40)
	DECLARE @NewRes NVARCHAR(40)
	DECLARE @Pos INT
	DECLARE @NextPos INT
	DECLARE @String NVARCHAR(40)
	DECLARE @Delimiter NVARCHAR(40)
	declare @Idi nvarchar(20)
	declare @Trad nvarchar(20)
	Declare @Mat nvarchar(50)
	Declare @IdProd nvarchar(50)
	declare @Cont int
	declare @Inter varchar(20)
	Set @Cont = 0
	declare ctmpProd Cursor for
		Select IdProducto,Materiales from ' + @Tabla + '.dbo.Producto AS tProd
		Where Materiales > ''''
		
		Open ctmpProd
		fetch next From ctmpProd
			Into @IdProd,@Mat
		while @@FETCH_STATUS = 0
		begin
			declare ctmpLang Cursor for
			Select [Code],[Cod_ Intenacional] from [INDUSTRIAS COSMIC, S_A_U_$Language] AS tLang
			 
			Open ctmpLang
			Fetch next From ctmpLang
				Into  @Idi,@Inter

			while @@FETCH_STATUS =0 
			begin
				if @Idi <> '''' and @Inter <> ''''
				begin
					SET @String =@Mat 
					SET @Delimiter = '',''
					SET @NewRes = '''';
					SET @String = @String + @Delimiter
					SET @Pos = charindex(@Delimiter,@String)	
				
					WHILE (@pos <> 0)
					BEGIN
						SET @NextString = substring(@String,1,@Pos - 1)
						--Buscamos la traducción de @NexString segun el Idioma @Idi
						SET @Trad = ''''
						Select @Trad = isnull(Texto,'''') 
						From [INDUSTRIAS COSMIC, S_A_U_$Textos Materiales]
						Where [Cód_ Material] = @NextString and [Cód_ Idioma] = @Idi
						
						if @Cont = 0 begin SET @NewRes = @Trad end
						if @Cont > 0 begin SET @NewRes = @NewRes + '','' + @Trad end
						Set @Cont = @Cont + 1
						
						
						
						SET @String = substring(@String,@pos+1,len(@String))
						SET @pos = charindex(@Delimiter,@String)
					END
					

					if @NewRes <> ''''and @NewRes <> '','' and  @NewRes <> '',,'' and @NewRes <> '',,,'' and @NewRes <> '',,,,''
					begin
						begin try
							insert into ' + @Tabla + '.dbo.Traduccion(IdTraduccion,Idioma,Valor) 
								Values(@Mat ,@Inter,@NewRes) 
						end try
						begin catch
						end catch
					end
				
				end			
				SET @Cont = 0
				Fetch next From ctmpLang
					Into  @Idi,@Inter
			end
			close ctmpLang
			deallocate ctmpLang	
			fetch next From ctmpProd
				Into @IdProd,@Mat
						
		end
		close ctmpProd
		deallocate ctmpProd


		--Colecciones Código
		Insert into ' + @Tabla + '.dbo.Traduccion

		SELECT ''Col_'' + tTexArti.Código AS IdTraduccion,tLang.[Cod_ Intenacional] AS Idioma, tTexArti.Texto AS Valor
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Traducciones] AS tTexArti INNER JOIN
							  [INDUSTRIAS COSMIC, S_A_U_$Language] AS tLang ON tTexArti.[Cód_ Idioma] = tLang.Code
		WHERE     (tTexArti.Tipo = 3) and (tTexArti.Web = ' + @Web + ')

				--Si hay Colecciones sin traducir graba el Codigo en ESPAÑOL
				drop table tmpColDes

				SELECT Código, [Cód_ Idioma], Texto
				INTO tmpColDes
				FROM         [INDUSTRIAS COSMIC, S_A_U_$Traducciones]
				WHERE     (Tipo = 3) AND ([Cód_ Idioma] = ''ESPAÑOL'')


				Insert into ' + @Tabla + '.dbo.Traduccion

				SELECT ''Col_'' + tColWeb.Código AS IdTraduccion,''es-ES'' AS Idioma, tColWeb.Código AS Valor
				FROM         [INDUSTRIAS COSMIC, S_A_U_$Maestro de códigos] AS tColWeb LEFT OUTER JOIN
									  tmpColDes ON tColWeb.Código = tmpColDes.Código
				WHERE     (tColWeb.Filtro = ''COLECCIONWEB'') AND (tmpColDes.Texto IS NULL)




		--Colecciones Descripción
		Insert into ' + @Tabla + '.dbo.Traduccion

		SELECT ''ColDes_'' + tTexArti.Código AS IdTraduccion,tLang.[Cod_ Intenacional] AS Idioma, tTexArti.Texto AS Valor
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Traducciones] AS tTexArti INNER JOIN
							  [INDUSTRIAS COSMIC, S_A_U_$Language] AS tLang ON tTexArti.[Cód_ Idioma] = tLang.Code
		WHERE     (tTexArti.Tipo = 4) and (tTexArti.Web = ' + @Web + ')


				--Si hay Colecciones sin traducir graba el texto ''''
				drop table tmpColDes

				SELECT Código, [Cód_ Idioma], Texto
				INTO tmpColDes
				FROM         [INDUSTRIAS COSMIC, S_A_U_$Traducciones]
				WHERE     (Tipo = 4) AND ([Cód_ Idioma] = ''ESPAÑOL'')


				Insert into ' + @Tabla + '.dbo.Traduccion

				SELECT ''ColDes_'' + tColWeb.Código AS IdTraduccion,''es-ES'' AS Idioma, '''' AS Valor
				FROM         [INDUSTRIAS COSMIC, S_A_U_$Maestro de códigos] AS tColWeb LEFT OUTER JOIN
									  tmpColDes ON tColWeb.Código = tmpColDes.Código
				WHERE     (tColWeb.Filtro = ''COLECCIONWEB'') AND (tmpColDes.Texto IS NULL)



		--Categorias
		Insert into ' + @Tabla + '.dbo.Traduccion

		SELECT tTexArti.Código AS IdTraduccion,tLang.[Cod_ Intenacional] AS Idioma, tTexArti.Texto AS Valor
		FROM   [INDUSTRIAS COSMIC, S_A_U_$Traducciones] AS tTexArti INNER JOIN
					  [INDUSTRIAS COSMIC, S_A_U_$Language] AS tLang ON tTexArti.[Cód_ Idioma] = tLang.Code
		WHERE     (tTexArti.Tipo = 5) and (tTexArti.Web = ' + @Web + ')


		--Web Configuración Inicio

		Insert into ' + @Tabla + '.dbo.Traduccion

		SELECT tTexArti.Código AS IdTraduccion,tLang.[Cod_ Intenacional] AS Idioma, tTexArti.Texto AS Valor
		FROM   [INDUSTRIAS COSMIC, S_A_U_$Traducciones] AS tTexArti INNER JOIN
					  [INDUSTRIAS COSMIC, S_A_U_$Language] AS tLang ON tTexArti.[Cód_ Idioma] = tLang.Code
		WHERE     (tTexArti.Tipo = 6) and (tTexArti.Web = ' + @Web + ')
	')
	
	Set @Res = @@Rowcount

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch


END


GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_14]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_14] 
	@Web int, 
	@Res Varchar(200) output

AS
BEGIN
	--- 'PRODUCTO_PARTEPRODUCTO  14'

begin try
    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end

    Exec('

		Delete 
		From  ' + @Tabla + '.dbo.Producto_ParteProducto


		Insert Into  ' + @Tabla + '.dbo.Producto_ParteProducto ( IdProducto, IdParteProducto, Orden)

		SELECT  Codigo as IdProducto, [Mueble Producto Web] as IdParteProducto, Orden
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Configuración Web]
		WHERE     (Id = ''MUEBLES'') AND (Activo = 1) and (Web = ' + @Web + ')


		Insert Into  ' + @Tabla + '.dbo.Producto (IdProducto, Nombre, IdCategoria, IdAcabado, IdMedida, Referencia, RutaImagenMini, RutaImagenNormal, RutaImagenGrande, RutaFicheroMedidas, 
							  RutaArchivos2D3D, RutaArchivosInstrucciones, RutaImagenMobiliario, Visible ,[Producto Web],FicheroDOP,IdAcabado2)

		SELECT Codigo AS IdProducto, Codigo AS Nombre, ''MUEBLES'' AS IdCategoria,  
				'''' AS IdAcabado, 
				'''' AS IdMedida, Codigo AS Referencia, 
				[Mueble Foto Web]+''_120.jpg'' AS RutaImagenMini, [Mueble Foto Web]+''_380.jpg'' AS RutaImagenNormal, 
				[Mueble Foto Web]+''_600.jpg'' AS RutaImagenGrande, '''' AS RutaFicheroMedidas, 
				'''' AS RutaArchivos2D3D, '''' AS rutaArchivosInstrucciones,
				--[Mueble Foto Desp] AS RutaImagenMobiliario, 1 AS Visible,[Mueble Producto Web] as [Producto Web],
				[Mueble Foto Desp]+''.jpg'' AS RutaImagenMobiliario, 1 AS Visible,Codigo as [Producto Web],
				'''' as FicheroDOP,'''' AS IdAcabado2
		FROM [INDUSTRIAS COSMIC, S_A_U_$Configuración Web]
		WHERE   (Id = ''MUEBLES'') AND (Activo = 1) and (Web = ' + @Web + ')
		GROUP BY Codigo, [Mueble Foto Web] + ''_120.jpg'', [Mueble Foto Web] + ''_380.jpg'', [Mueble Foto Web] + ''_600.jpg'', [Mueble Foto Desp]+''.jpg''


		Insert Into  ' + @Tabla + '.dbo.Producto_ProductoColeccion (IdProducto, IdColeccion,Orden)

		SELECT Codigo AS IdProducto, Colección as IdColeccion,[Mueble Orden] as Orden  

		FROM [INDUSTRIAS COSMIC, S_A_U_$Configuración Web]
		WHERE   (Id = ''MUEBLES'') AND (Activo = 1) and (Web = ' + @Web + ')
		GROUP BY Codigo, Colección,[Mueble Orden]



		Insert Into  ' + @Tabla + '.dbo.Producto_ProductoGrupo (IdProducto, IdGrupo)

		SELECT Codigo AS IdProducto, ''MOBILIARIO'' AS IdGrupo

		FROM [INDUSTRIAS COSMIC, S_A_U_$Configuración Web]
		WHERE   (Id = ''MUEBLES'') AND (Activo = 1) and (Web = ' + @Web + ')
		GROUP BY Codigo, Colección
		')

		Set @Res = @@Rowcount

		--Desactivo los productos que son parte de un Mueble
		exec('UPDATE  ' + @Tabla + '.dbo.Producto
			SET  Visible = 0
			FROM   ' + @Tabla + '.dbo.Producto_ParteProducto INNER JOIN
						  ' + @Tabla + '.dbo.Producto ON
							 ' + @Tabla + '.dbo.Producto_ParteProducto.IdParteProducto = ' + @Tabla + '.dbo.Producto.[Producto Web]
			')
	

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch
					
					
END


GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_13]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_13] 
	@Web int, 
	@Res Varchar(200) output

AS
BEGIN
	---- 'PRODUCTOMEDIDA  13'
	
begin try	
    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end

    Exec('
		delete from ' + @Tabla + '.dbo.ProductoMedida 

		Insert into ' + @Tabla + '.dbo.ProductoMedida 

		SELECT     [Texto medidas] AS IdMedida, [Texto medidas] AS Medida
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd
		WHERE     (Web = ' + @Web + ') AND ([Producto en Web] = 1)
		group by [Texto medidas]
		')
	Set @Res = @@Rowcount

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch

END


GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_12]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_12] 
	@Web int, 
	@Res Varchar(200) output

AS
BEGIN
	--- 'PRODUCTOGRUPO  12'
begin try	
    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end

    Exec('
		delete from ' + @Tabla + '.dbo.ProductoGrupo 

		Insert Into ' + @Tabla + '.dbo.ProductoGrupo 
				
		SELECT     tProdCol.[Grupo Web] AS IdGrupo, tProdCol.[Grupo Web] AS Grupo, isnull(tMaes.Entero1,0) AS Orden
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd INNER JOIN
							  [INDUSTRIAS COSMIC, S_A_U_$Producto Colección Web] AS tProdCol ON tProd.No_ = tProdCol.[Nº Producto] LEFT OUTER JOIN
									  [INDUSTRIAS COSMIC, S_A_U_$Maestro de códigos] AS tMaes ON tProdCol.[Grupo Web] = tMaes.Código
		WHERE     (tProd.Web = ' + @Web + ') AND (tProd.[Producto en Web] = 1) AND (tMaes.Filtro = ''GRUPOWEB'') AND  (tProdCol.[Grupo Web] <> '''')
		GROUP BY tProdCol.[Grupo Web],isnull(tMaes.Entero1,0)
		
		
		
	')


		--SELECT     tProdCol.[Grupo Web] AS IdGrupo, tProdCol.[Grupo Web] AS Grupo
		--FROM         [INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd INNER JOIN
		--					  [INDUSTRIAS COSMIC, S_A_U_$Producto Colección Web] AS tProdCol ON tProd.No_ = tProdCol.[Nº Producto]
		--WHERE     (tProd.Web = ' + @Web + ') AND (tProd.[Producto en Web] = 1)
		--GROUP BY tProdCol.[Grupo Web]
		--HAVING      (tProdCol.[Grupo Web] <> '''')


	Set @Res = @@Rowcount

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch


END


GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_11]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_11]
	@Web int, 
	@Res Varchar(200) output
 
AS
BEGIN
	--- 'PRODUCTOCOLECCION 11'
begin try

    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end

    Exec('
		delete from ' + @Tabla + '.dbo.ProductoColeccion 
		Insert Into ' + @Tabla + '.dbo.ProductoColeccion 
		
		SELECT  Código AS IdColeccion, Código AS Coleccion, [Valor 1] AS RutaArchivo, [Valor 2] AS RutaImagen, [Valor 3] AS RutaImagenCuadrada, logico1 AS Accesorio, TextoLargo AS Descripcion, 
							  [Código 2] AS Adjetivo, Entero1 AS Orden, [Código 3] AS Amigable,logico1 as Visible

		FROM        [Srv-dbc].Cosmic.dbo.[INDUSTRIAS COSMIC, S_A_U_$Maestro de códigos]
		WHERE     (Filtro = ''COLECCIONWEB'') and ([Entero 3] = ' + @Web + ')
		order by IdColeccion
		')

	Set @Res = @@Rowcount

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch

END


GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_10]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_10]
	@Web int, 
	@Res Varchar(200) output
 
AS
BEGIN
	--- 'PRODUCTOCATEGORIA 10'
	
begin try	
    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end

    Exec('
		delete from ' + @Tabla + '.dbo.ProductoCategoria 


		Insert into ' + @Tabla + '.dbo.ProductoCategoria 

		SELECT     Familia AS IdCategoria, Familia AS IdCategoria,1 as Accesorio,
				ROW_NUMBER() over ( order by tProd.[Familia] asc) as Orden
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd
		WHERE     (Web = ' + @Web + ') AND ([Producto en Web] = 1)
		group by Familia
		')
	
	Set @Res = @@Rowcount

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch
	

END


GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_08]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_08]
	@Web int, 
	@Res Varchar(200) output
 
AS
BEGIN
	--- 'PRODUCTO_PRODUCTOGRUPO  08'
	
begin try	
    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end

    Exec('
		delete from ' + @Tabla + '.dbo.Producto_ProductoGrupo 

		insert into ' + @Tabla + '.dbo.Producto_ProductoGrupo		
		SELECT     tProdCol.[Nº Producto], tProdCol.[Grupo Web]
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Producto Colección Web] AS tProdCol INNER JOIN
							  [INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd ON tProdCol.[Nº Producto] = tProd.No_ 
		GROUP BY tProdCol.[Nº Producto], tProdCol.[Grupo Web], tProd.Web, tProd.[Producto en Web]
		HAVING      (tProdCol.[Grupo Web] > '''') AND (tProd.Web = ' + @Web + ') AND (tProd.[Producto en Web] = 1)									
	')
	
	Set @Res = @@Rowcount

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch


END


GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_07]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_07]
	@Web int, 
	@Res Varchar(200) output
 
AS
BEGIN
	--- 'PRODUCTO_PRODUCTOCOLECCION  07'
begin try
    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end

    Exec('
		delete from ' + @Tabla + '.dbo.Producto_ProductoColeccion 

		insert into ' + @Tabla + '.dbo.Producto_ProductoColeccion
		SELECT tProdCol.[Nº Producto], tProdCol.[Colección Web], tProdCol.[Orden Web], tProdCol.[Orden Colección]
		FROM [INDUSTRIAS COSMIC, S_A_U_$Producto Colección Web] AS tProdCol INNER JOIN
			  [INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd ON tProdCol.[Nº Producto] = tProd.No_
		GROUP BY tProdCol.[Nº Producto], tProdCol.[Colección Web], tProdCol.[Orden Web], tProdCol.[Orden Colección], tProd.Web
		HAVING (tProdCol.[Colección Web] > '''') and (tProd.Web = ' + @Web + ')
	')


	Set @Res = @@Rowcount
	
end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch


END


GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_06]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_06]
	@Web int, 
	@Res Varchar(200) output
 
AS
BEGIN
	--- 'PRODUCTO  06'
begin try

    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end

    Exec('
		delete from ' + @Tabla + '.dbo.Producto 

		Insert Into ' + @Tabla + '.dbo.Producto (IdProducto, Nombre, IdCategoria, IdAcabado, 
					IdMedida, Referencia, RutaImagenMini, RutaImagenNormal, RutaImagenGrande, RutaFicheroMedidas, 
					RutaArchivos2D3D, RutaArchivosInstrucciones, RutaImagenMobiliario, Visible ,[Producto Web],
					FicheroDOP,IdAcabado2,Materiales,Comentario,TituloAcabado1,TituloAcabado2,PrefijoAcabado1,PrefijoAcabado2)

		SELECT No_ AS IdProducto, ''Prod_'' + [Cód_ artículo] AS Nombre, [Familia] AS IdCategoria,  
				(case when [Cód acabado Web 1] <>'''' then [Cód acabado Web 1] else [Cód acabado] end) AS IdAcabado, 
				[Texto medidas] AS IdMedida, No_ AS Referencia, 
				[Foto Web]+''_120.jpg'' AS RutaImagenMini, [Foto Web]+''_380.jpg'' AS RutaImagenNormal, 
				[Foto Web]+''_600.jpg'' AS RutaImagenGrande, [Esquema Web] + ''.pdf'' AS RutaFicheroMedidas, 
				Vistas AS RutaArchivos2D3D, [Cód_ Hoja Instrucciones] AS rutaArchivosInstrucciones,
				'''' AS RutaImagenMobiliario, [Producto en Web] AS Visible,[Cod_ Producto Web] as [Producto Web],
				[Declaración de Prestaciones]+''.pdf'' as FicheroDOP,[Cód acabado Web 2] AS IdAcabado2,
			dbo.fncProdMateriales(No_)  as Materiales,''Comen_'' + No_ as Comentario,[Titulo acabado Web 1] as TituloAcabado1,
			[Titulo acabado Web 2] as TituloAcabado2,[Prefijo acabado Web 1] as PrefijoAcabado1,[Prefijo acabado Web 2] as PrefijoAcabado2
		FROM [INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd
		WHERE   (Web = ' + @Web + ') AND ([Producto en Web] = 1)
	')

	Set @Res = @@Rowcount

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch

END


GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_05]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_05]
	@Web int, 
	@Res Varchar(200) output
 
AS
BEGIN
--- 'CATALOGOS  05'
begin try
    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end

    Exec('
		delete from ' + @Tabla + '.dbo.Catalogo 


		SELECT IDENTITY(INT, 1,1) AS IdCAtalogo, Codigo as Catalogo, [Link Catálogo] as Url,
				 Orden,[Master Catálogo] as [Master]
		into #tmpCatalogos
		FROM [INDUSTRIAS COSMIC, S_A_U_$Configuración Web]
		WHERE (Id = ''CATALOGOS'') AND (Activo = 1) AND (Web = ' + @Web + ')


		Insert into ' + @Tabla + '.dbo.Catalogo 
		SELECT  *
		FROM   #tmpCatalogos
	')

	Set @Res = @@Rowcount

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch


END







GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_04]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_04]
	@Web int, 
	@Res Varchar(200) output
 
AS
BEGIN
--- 'POBLACION  04'

begin try

    declare @vWeb varchar(20)
    set @vWeb =''
    
    SELECT @vWeb = isnull(Valores,'')
	FROM TablaOptions
	WHERE (ID = 'WebsN') AND (ValorID = @Web)
    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end
    
    Exec('
	delete from ' + @Tabla + '.dbo.Poblacion 

	SELECT    tdirEnt.City as IdPoblacion , tdirEnt.City AS Poblacion, tdirEnt.County AS IdProvincia,replace(tdirEnt.[Country Code],''.'',''_'') as IdPais
	Into #ttt2
	FROM         [INDUSTRIAS COSMIC, S_A_U_$Ship-to Address] AS tdirEnt LEFT OUTER JOIN
		  [INDUSTRIAS COSMIC, S_A_U_$Maestro de códigos] AS Webs ON tdirEnt.Code = Webs.[Filtro 3] AND tdirEnt.[Customer No_] = Webs.[Filtro 2]
	WHERE     (tdirEnt.City > '''') AND (Webs.Código = ''' + @vWeb + ''')
	group by tdirEnt.City,tdirEnt.County,tdirEnt.[Country Code]

	insert Into ' + @Tabla + '.dbo.Poblacion 
	Select * 
	From #ttt2
	Group by IdPoblacion,Poblacion,IdProvincia,IdPais
	')

	Set @Res = @@Rowcount

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch


END







GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_03]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_03] 
	@Web int, 
	@Res Varchar(200) output

AS
BEGIN
--- 'PROVINCIA  03'

begin try

    declare @vWeb varchar(20)
    set @vWeb =''
    
    SELECT @vWeb = isnull(Valores,'')
	FROM TablaOptions
	WHERE (ID = 'WebsN') AND (ValorID = @Web)
    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end


	exec('delete from ' + @Tabla + '.dbo.Provincia 

		SELECT     tdirEnt.County AS IdProvincia, tdirEnt.County AS Provincia, replace(tdirEnt.[Country Code],''.'',''_'') AS IdPais
		Into #ttt1
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Ship-to Address] AS tdirEnt LEFT OUTER JOIN
			  [INDUSTRIAS COSMIC, S_A_U_$Maestro de códigos] AS Webs ON tdirEnt.Code = Webs.[Filtro 3] AND tdirEnt.[Customer No_] = Webs.[Filtro 2]
		WHERE     (tdirEnt.County > '''') and tdirEnt.[Country Code] > ''''  AND (Webs.Código = ''' + @vWeb + ''')
		group by tdirEnt.County,tdirEnt.[Country Code]

		insert Into  ' + @Tabla + '.dbo.Provincia 
		Select * 
		From #ttt1
		Group by IdProvincia,Provincia,IdPais')
		
	Set @Res = @@Rowcount

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch


END







GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_02]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_02] 
	@Web int, 
	@Res Varchar(200) output

AS
BEGIN
	--- 'PAIS  02'
begin try	
    declare @vWeb varchar(20)
    set @vWeb =''
    
    SELECT @vWeb = isnull(Valores,'')
	FROM TablaOptions
	WHERE (ID = 'WebsN') AND (ValorID = @Web)

    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end


	exec('delete from ' + @Tabla + '.dbo.Pais

		SELECT REPLACE(tdirEnt.[Country Code], ''.'', ''_'') AS IdPais, 
				(CASE WHEN tPais.Name <> '''' THEN tPais.Name ELSE replace(tdirEnt.[Country Code], ''.'', ''_'') END) AS Pais
		Into #ttt
		FROM [INDUSTRIAS COSMIC, S_A_U_$Ship-to Address] AS tdirEnt LEFT OUTER JOIN
			  [INDUSTRIAS COSMIC, S_A_U_$Maestro de códigos] AS Webs ON tdirEnt.Code = Webs.[Filtro 3] AND tdirEnt.[Customer No_] = Webs.[Filtro 2] INNER JOIN
			  [INDUSTRIAS COSMIC, S_A_U_$Country] AS tPais ON tdirEnt.[Country Code] = tPais.Code
		WHERE (tdirEnt.[Country Code] > '''') AND (Webs.Código = ''' + @vWeb + ''')
		GROUP BY tdirEnt.[Country Code], tPais.Name

		Insert Into ' + @Tabla + '.dbo.Pais
		Select * 
		From #ttt')

	Set @Res = @@Rowcount

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch

END







GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_01]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_01]
	@Web int,  
	@Res Varchar(200) output
AS
BEGIN
begin try
    declare @vWeb varchar(20)
    set @vWeb =''
    
    SELECT @vWeb = isnull(Valores,'')
	FROM TablaOptions
	WHERE (ID = 'WebsN') AND (ValorID = @Web)
    
    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end
    
    declare @Sql varchar(max)
		
	exec('Delete From ' + @Tabla + '.dbo.Distribuidor   
		
		Insert Into ' + @Tabla + '.dbo.Distribuidor  
		SELECT tEnv.[Customer No_] + tEnv.Code AS IdDistribuidor, tEnv.Name AS Nombre, tEnv.Address + tEnv.[Address 2] AS Direccion, tEnv.[Post Code] AS CP, 
				  tEnv.City AS IdPoblacion, tEnv.[Phone No_] AS Telefono, tEnv.[Fax No_] AS Fax, tEnv.[Home Page] AS Web, tEnv.[E-Mail] AS Email, tEnv.[Customer No_] AS Cliente, 
				  tEnv.Code AS Codigo
		FROM  [INDUSTRIAS COSMIC, S_A_U_$Ship-to Address] AS tEnv LEFT OUTER JOIN
			  [INDUSTRIAS COSMIC, S_A_U_$Maestro de códigos] AS Webs ON tEnv.Code = Webs.[Filtro 3] AND tEnv.[Customer No_] = Webs.[Filtro 2]
		WHERE (Webs.Código = ''' + @vWeb + ''')')
		
	
	Set @Res = @@Rowcount

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
end catch

END







GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Datos_15]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Datos_15] 
	@Web int,
	@Res Varchar(200) output

AS
BEGIN


	---- 'NOTICIASWEB  15'

	declare @vError varchar(max)

begin try
    declare @Tabla varchar(150)
    set @Tabla='WebPomDor'
    if @Web=0 begin set @Tabla='WebCosmic' end

    Exec('
		declare @Id varchar(100)
		declare @Idioma varchar(20)
		declare @Codigo varchar(20)
		declare @Valor varchar(200)
		declare @Cont int
		declare @SQL varchar(max)

		Delete 
		From ' + @Tabla + '.dbo.NoticiaImagen


		Insert into ' + @Tabla + '.dbo.NoticiaImagen
		SELECT     Codigo AS IdNoticia, Orden, [RutaImagen Not Web] AS RutaImagen
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Configuración Web]
		WHERE     (Id = ''IMGNOT'') AND (Activo = 1) and (Web = ' + @Web + ')

		Delete 
		From ' + @Tabla + '.dbo.Noticia

		insert into ' + @Tabla + '.dbo.Noticia
		SELECT     tNotWeb.Codigo AS Noticia, tlang.[Cod_ Intenacional] AS Idioma, tTrad.Texto AS Titulo, '''' AS Contenido, '''' AS MiniContenido, GETDATE() AS FechaCreacion, 
							  tNotWeb.[ArchivoAdjunto Not] AS ArchivoAdjunto, tNotWeb.[ArchivoFotos Not] AS ArchivoFotos
		FROM         [INDUSTRIAS COSMIC, S_A_U_$Configuración Web] AS tNotWeb INNER JOIN
							  [INDUSTRIAS COSMIC, S_A_U_$Traducciones] AS tTrad ON tNotWeb.[Titulo Not] = tTrad.Código INNER JOIN
							  [INDUSTRIAS COSMIC, S_A_U_$Language] AS tlang ON tTrad.[Cód_ Idioma] = tlang.Code
		WHERE     (tNotWeb.Id = ''NOTICIAS'') AND (tNotWeb.Activo = 1) AND (tTrad.Tipo = 8) and (tNotWeb.Web = ' + @Web + ')



		---Extraemos el texto del documento de Contenido y lo grabamos en la base de datos
		Declare ctmpEmpresaI Cursor for
			SELECT tTexArti.Código AS IdTraduccion, tLang.[Cod_ Intenacional] AS Idioma, tTexArti.Texto AS Valor, [INDUSTRIAS COSMIC, S_A_U_$Configuración Web].Codigo
			FROM   [INDUSTRIAS COSMIC, S_A_U_$Traducciones] AS tTexArti INNER JOIN
					  [INDUSTRIAS COSMIC, S_A_U_$Language] AS tLang ON tTexArti.[Cód_ Idioma] = tLang.Code INNER JOIN
					  [INDUSTRIAS COSMIC, S_A_U_$Configuración Web] ON tTexArti.Código = [INDUSTRIAS COSMIC, S_A_U_$Configuración Web].[Contenido Not]
			WHERE     (tTexArti.Tipo = 8) and ([INDUSTRIAS COSMIC, S_A_U_$Configuración Web].Web = ' + @Web + ')
			Open ctmpEmpresaI

				Fetch Next From ctmpEmpresaI
					Into @Id,@Idioma,@Valor,@Codigo
						
				While @@Fetch_Status = 0
				Begin				
					
					set @Cont = 0
					delete from ' + @Tabla + '.dbo.tmpEmpresa
					
					Select @Valor as Fichero
					            
					set @SQL = ''INSERT INTO ' + @Tabla + '.dbo.tmpEmpresa 
								SELECT * FROM OPENROWSET(BULK '''''' + @Valor + '''''', SINGLE_NCLOB) AS e''
					EXEC (@SQL);
		                                   
					declare @Html0 nvarchar(MAX)
					declare @Html nvarchar(MAX)
					declare @vCont int

					Declare ctmpEmpresa Cursor for
						SELECT *
						FROM  ' + @Tabla + '.dbo.tmpEmpresa
					Open ctmpEmpresa
							
					Fetch Next From ctmpEmpresa
						Into @Html0
					
					set @Html = ''''		
					While @@Fetch_Status = 0
					Begin	
					   if (@Html0 <> '''')
 					   begin			
							set @Html += @Html0		
							
					  End
					  
					  Fetch Next From ctmpEmpresa
					  Into @Html0

					end
					
					Close ctmpEmpresa
					Deallocate ctmpEmpresa
					
					update ' + @Tabla + '.dbo.Noticia
					set Contenido = @Html
					where IdNoticia = @Codigo and Idioma = @Idioma				
					
			
						
					Fetch Next From ctmpEmpresaI
						Into @Id,@Idioma,@Valor,@Codigo
				end
				Close ctmpEmpresaI
				Deallocate ctmpEmpresaI
				
				
				
				
				
		set @Html = ''''
		set @Html0 = ''''
				
		---Extraemos el texto del documento de MiniContenido y lo grabamos en la base de datos
		Declare ctmpEmpresaI Cursor for
			SELECT tTexArti.Código AS IdTraduccion, tLang.[Cod_ Intenacional] AS Idioma, tTexArti.Texto AS Valor, [INDUSTRIAS COSMIC, S_A_U_$Configuración Web].Codigo
			FROM   [INDUSTRIAS COSMIC, S_A_U_$Traducciones] AS tTexArti INNER JOIN
					  [INDUSTRIAS COSMIC, S_A_U_$Language] AS tLang ON tTexArti.[Cód_ Idioma] = tLang.Code INNER JOIN
					  [INDUSTRIAS COSMIC, S_A_U_$Configuración Web] ON tTexArti.Código = [INDUSTRIAS COSMIC, S_A_U_$Configuración Web].[MiniContenido Not]
			WHERE     (tTexArti.Tipo = 8) and ([INDUSTRIAS COSMIC, S_A_U_$Configuración Web].Web = ' + @Web + ')
			Open ctmpEmpresaI

				Fetch Next From ctmpEmpresaI
					Into @Id,@Idioma,@Valor,@Codigo
						
				While @@Fetch_Status = 0
				Begin				
					
					set @Cont = 0
					delete from ' + @Tabla + '.dbo.tmpEmpresa
					
					Select @Valor as FicheroNini
					            
					set @SQL = ''INSERT INTO ' + @Tabla + '.dbo.tmpEmpresa 
								SELECT * FROM OPENROWSET(BULK '''''' + @Valor + '''''', SINGLE_NCLOB) AS e''
					EXEC (@SQL);
		                                   
					Declare ctmpEmpresa Cursor for
						SELECT *
						FROM  ' + @Tabla + '.dbo.tmpEmpresa
					Open ctmpEmpresa
							
					Fetch Next From ctmpEmpresa
						Into @Html0
					
					set @Html = ''''		
					While @@Fetch_Status = 0
					Begin	
					   if (@Html0 <> '''')
 					   begin			
							set @Html += @Html0		
							
					  End
					  
					  Fetch Next From ctmpEmpresa
					  Into @Html0

					end
					Close ctmpEmpresa
					Deallocate ctmpEmpresa
					
					update ' + @Tabla + '.dbo.Noticia
					set MiniContenido = @Html
					where IdNoticia = @Codigo and Idioma = @Idioma				
					
			
						
					Fetch Next From ctmpEmpresaI
						Into @Id,@Idioma,@Valor,@Codigo
				end
				Close ctmpEmpresaI
				Deallocate ctmpEmpresaI	
	')
			
			
				
	Set @Res = 'Correcto'

end try
begin catch
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	Set @Res = 'Error:' + ERROR_MESSAGE();
	Set @vError  =ERROR_MESSAGE()
end catch


END


GO

/****** Object:  StoredProcedure [dbo].[GEN_GET_PALET]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_GET_PALET] 
	@Palet nVarchar(50),
	@Producto nVarchar(50),
    @Situ nVarchar(50)
AS
BEGIN
		if @Producto = ''
			begin
				SELECT		*,
				CONVERT(int,ISNULL((SELECT SUM([Cantidad Dec])
						FROM [INDUSTRIAS COSMIC, S_A_U_$MoviAdicional]
						WHERE ([Nº] = ZA.[Nº] and [Matrícula Palet] = @Palet and [Cantidad Dec] <> 0 and ide = ZA.ide)), 0)) AS Canti

				FROM        [INDUSTRIAS COSMIC, S_A_U_$Zona Adicional] as ZA
			
				where      ([Cód_ Situación] = @Situ AND [Matrícula Palet] = @Palet) 
			end

		if @Producto <> ''
			begin
				SELECT		*,
				CONVERT(int,ISNULL((SELECT SUM([Cantidad Dec])
						FROM [INDUSTRIAS COSMIC, S_A_U_$MoviAdicional]
						WHERE ([Nº] = ZA.[Nº] and [Matrícula Palet] = @Palet and [Cantidad Dec] <> 0 and ide = ZA.ide)), 0)) AS Canti

				FROM        [INDUSTRIAS COSMIC, S_A_U_$Zona Adicional] as ZA
			
				where      ([Cód_ Situación] = @Situ AND [Matrícula Palet] = @Palet AND [Nº] = @Producto) 
			end

END












GO

/****** Object:  StoredProcedure [dbo].[GEN_ALTA_ZONAADICIONAL2]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[GEN_ALTA_ZONAADICIONAL2]
	@Situ as varchar(10),
	@TipoRef as int,
	@Pedido as varchar(10),
	@Prod as varchar(20),
	@Fecha as varchar(20),
	@MatriculaPalet as varchar(10),
	@Nota as varchar(100),
	@Hora as varchar(20),
	@CodigoAlmacen as varchar(10),
	@LoteFabricacionProducto as varchar(10),
	@FechaCad as varchar(20),
	@TipoPalet as int,
	@SituPick as varchar(10),
	@Consumir as int,
	@Block as int,
	@LoteFifo as varchar(20),
	@NEP as varchar(20),
	@vRefXPalet int,	
	@vIdeRA varchar(20),
	@vSelecRA int,
	@vAlmFis varchar(20),
	@ZonaAlm varchar(20),
	@vExterno int,
	@vQ decimal(38,10),	
	@Res int output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @vIDE int
	

	set @vIDE=isnull((	
						SELECT ide
						FROM [INDUSTRIAS COSMIC, S_A_U_$Zona Adicional]
						WHERE ([Matrícula Palet] = @MatriculaPalet) AND (Nº = @Prod)	
					  ),0)

    if @vIDE = 0
		begin
			set @vIDE=isnull((
						SELECT MAX(ide) AS Ide
						FROM [INDUSTRIAS COSMIC, S_A_U_$Zona Adicional]
					  ),0)

			set @vIDE=@vIDE+1
	

			insert into dbo.[INDUSTRIAS COSMIC, S_A_U_$Zona Adicional](ide,[Cód_ Situación],[Tipo Referencia],
										Pedido,[Nº],Fecha,[Matrícula Palet],[Nota],Hora,[Código Almacén],[Lote Fabricación Producto],
										[Fecha Caducidad],[Tipo Palet],[Cód_ Situ_ Picking],[Consumir primero],
										[Bloqueado],[Lote FIFO],[Nº EP],[Cant Ref x Palet],ideRA,[SelecciónRA],[Cód_ Almacén Físico],
										[Zona Almacén],Externo,Q)
										
							values(@vIDE,@Situ,@TipoRef,@Pedido,@Prod,@Fecha,@MatriculaPalet,
									@Nota,@Hora,@CodigoAlmacen,@LoteFabricacionProducto,
									@FechaCad,@TipoPalet,@SituPick,@Consumir,@Block,
									@LoteFifo,@NEP,@vRefXPalet,@vIdeRA,@vSelecRA,@vAlmFis,@ZonaAlm,@vExterno,@vQ)
		end

	set @Res=@vIDE
END





















GO

/****** Object:  StoredProcedure [dbo].[GEN_GET_ULTIDEZA]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[GEN_GET_ULTIDEZA] 
	@Res int output
AS
BEGIN
	Declare @UltIDE int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	set @UltIDE = (
		Select max([ide]) from [INDUSTRIAS COSMIC, S_A_U_$Zona Adicional]
				   )

	set @Res = @UltIDE

END





GO

/****** Object:  StoredProcedure [dbo].[GEN_MRP_RETRASAFECHAS]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[GEN_MRP_RETRASAFECHAS] 
	@Retrasar int
AS
BEGIN
	declare @Atrasada int
	declare @Dias int

	set @Atrasada = 1
	set @Dias = 365


	if @Retrasar = 1
		begin
			set @Atrasada = 0
			set @Dias = -365
		end


	---Cabecera pedido
	Update [INDUSTRIAS COSMIC, S_A_U_$Purchase Header]
		Set [Fecha Atrasada] = @Retrasar,
		[Due Date] = (CASE when [Due Date] = '01/01/1753' then '01/01/1753' else [Due Date] + @Dias end),
		[INDUSTRIAS COSMIC, S_A_U_$Purchase Header].[Expected Receipt Date] = (CASE when tCabPed.[Expected Receipt Date] = '01/01/1753' then '01/01/1753' else tCabPed.[Expected Receipt Date] + @Dias end)
	FROM [INDUSTRIAS COSMIC, S_A_U_$Purchase Header] AS tCabPed INNER JOIN
		  [INDUSTRIAS COSMIC, S_A_U_$Purchase Line] AS tLinPed ON tCabPed.[Document Type] = tLinPed.[Document Type] AND 
		  tCabPed.No_ = tLinPed.[Document No_]
	WHERE     (tCabPed.[Document Type] = 1) 
			AND (tLinPed.[Outstanding Quantity] > 0) 
			AND (tCabPed.[No atrasar Fecha] = 0) 
			AND (tCabPed.[Fecha Atrasada] = @Atrasada)
			
			
	---Lineas pedido
	Update [INDUSTRIAS COSMIC, S_A_U_$Purchase Line]
		Set [Fecha Atrasada] = @Retrasar,
		[INDUSTRIAS COSMIC, S_A_U_$Purchase Line].[Planning Flexibility] = (Case when @Retrasar = 1 then 1 else tLinPed.[Planning Flexibility] end),
		[INDUSTRIAS COSMIC, S_A_U_$Purchase Line].[Expected Receipt Date] = (CASE when tLinPed.[Expected Receipt Date] = '01/01/1753' then '01/01/1753' else tLinPed.[Expected Receipt Date] + @Dias end)
	FROM [INDUSTRIAS COSMIC, S_A_U_$Purchase Header] AS tCabPed INNER JOIN
		  [INDUSTRIAS COSMIC, S_A_U_$Purchase Line] AS tLinPed ON tCabPed.[Document Type] = tLinPed.[Document Type] AND 
		  tCabPed.No_ = tLinPed.[Document No_]
	WHERE     (tCabPed.[Document Type] = 1) 
			AND (tLinPed.[Outstanding Quantity] > 0) 
			AND (tLinPed.[No atrasar Fecha] = 0) 
			AND (tLinPed.[Fecha Atrasada] = @Atrasada)		
			
			
	---Cabecera Orden Produción
	Update [INDUSTRIAS COSMIC, S_A_U_$Production Order]
		Set [Fecha Atrasada] = @Retrasar,
		[INDUSTRIAS COSMIC, S_A_U_$Production Order].[Due Date] = (CASE when tCabOF.[Due Date] = '01/01/1753' then '01/01/1753' else tCabOF.[Due Date] + @Dias end),
		[INDUSTRIAS COSMIC, S_A_U_$Production Order].[Ending Date] = (CASE when tCabOF.[Ending Date] = '01/01/1753' then '01/01/1753' else tCabOF.[Ending Date] + @Dias end),
		[INDUSTRIAS COSMIC, S_A_U_$Production Order].[Finished Date] = (CASE when tCabOF.[Finished Date] = '01/01/1753' then '01/01/1753' else tCabOF.[Finished Date] + @Dias end)
	FROM [INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Line] AS tLinOF INNER JOIN
		  [INDUSTRIAS COSMIC, S_A_U_$Production Order] AS tCabOF ON tLinOF.Status = tCabOF.Status AND tLinOF.[Prod_ Order No_] = tCabOF.No_ INNER JOIN
		  [INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Routing Line] AS tRutOF ON tLinOF.Status = tRutOF.Status AND 
		  tLinOF.[Prod_ Order No_] = tRutOF.[Prod_ Order No_]
	WHERE (tLinOF.Status = 3) 
			AND (tLinOF.[Remaining Quantity] > 0) 
			AND (tLinOF.[No atrasar Fecha] = 0)	
			AND (tCabOF.[Fecha Atrasada] = @Atrasada)		


	---Lineas Orden Produción
	Update [INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Line]
		Set [Fecha Atrasada] = @Retrasar,
		[INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Line].[Due Date] = (CASE when tLinOF.[Due Date] = '01/01/1753' then '01/01/1753' else tLinOF.[Due Date] + @Dias end),
		[INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Line].[Starting Date] = (CASE when tLinOF.[Starting Date] = '01/01/1753' then '01/01/1753' else tLinOF.[Starting Date] + @Dias end),
		[INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Line].[Ending Date] = (CASE when tLinOF.[Ending Date] = '01/01/1753' then '01/01/1753' else tLinOF.[Ending Date] + @Dias end)
	FROM [INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Line] AS tLinOF INNER JOIN
		  [INDUSTRIAS COSMIC, S_A_U_$Production Order] AS tCabOF ON tLinOF.Status = tCabOF.Status AND tLinOF.[Prod_ Order No_] = tCabOF.No_ INNER JOIN
		  [INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Routing Line] AS tRutOF ON tLinOF.Status = tRutOF.Status AND 
		  tLinOF.[Prod_ Order No_] = tRutOF.[Prod_ Order No_]
	WHERE (tLinOF.Status = 3) 
			AND (tLinOF.[Remaining Quantity] > 0) 
			AND (tLinOF.[No atrasar Fecha] = 0)	
			AND (tLinOF.[Fecha Atrasada] = @Atrasada)		
			
			
			
	---Rutas Orden Produción
	Update [INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Routing Line]
		Set [Fecha Atrasada] = @Retrasar,
		[INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Routing Line].[Starting Date] = (CASE when tRutOF.[Starting Date] = '01/01/1753' then '01/01/1753' else tRutOF.[Starting Date] + @Dias end),
		[INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Routing Line].[Ending Date] = (CASE when tRutOF.[Ending Date] = '01/01/1753' then '01/01/1753' else tRutOF.[Ending Date] + @Dias end)
	FROM [INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Line] AS tLinOF INNER JOIN
		  [INDUSTRIAS COSMIC, S_A_U_$Production Order] AS tCabOF ON tLinOF.Status = tCabOF.Status AND tLinOF.[Prod_ Order No_] = tCabOF.No_ INNER JOIN
		  [INDUSTRIAS COSMIC, S_A_U_$Prod_ Order Routing Line] AS tRutOF ON tLinOF.Status = tRutOF.Status AND 
		  tLinOF.[Prod_ Order No_] = tRutOF.[Prod_ Order No_]
	WHERE (tLinOF.Status = 3) 
			AND (tLinOF.[Remaining Quantity] > 0) 
			AND (tLinOF.[No atrasar Fecha] = 0)	
			AND (tRutOF.[Fecha Atrasada] = @Atrasada)		
		

END














GO

/****** Object:  StoredProcedure [dbo].[GEN_LINVTA_FECHAENVIO]    Script Date: 11/18/2014 20:25:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_LINVTA_FECHAENVIO]
	@Res int output
AS
BEGIN
    --cmasana070714
    UPDATE lin
    SET    lin.[Fec_ envío inicial] =lin.[Shipment Date],
           lin.[Shipment Date]=lin.[Shipment Date]-CAB.[Seguridad Plazo]
    FROM   [INDUSTRIAS COSMIC, S_A_U_$Sales Line] as Lin 
           INNER JOIN [INDUSTRIAS COSMIC, S_A_U_$Sales Header]as CAB
           ON Lin.[Document No_]= CAB.[No_]
    WHERE  (CAB.[Seguridad Plazo]<>0) and (lin.[Fec_ envío inicial] <= 01/01/1753)


	update [INDUSTRIAS COSMIC, S_A_U_$Sales Line]
		--set [Shipment Date] = convert(varchar,datepart(day,GETDATE()+1)) + '/' + convert(varchar,datepart(month,GETDATE()+1)) + '/' + convert(varchar,datepart(year,GETDATE()+1)) + ' 0:00:00'
		set [Shipment Date] =  convert(varchar,datepart(day,GETDATE())) + '/' + convert(varchar,datepart(month,GETDATE())) + '/' + convert(varchar,datepart(year,GETDATE())) + ' 0:00:00'
	WHERE ([Shipment Date] < GETDATE()) AND ([Document Type] = 1) AND ([Outstanding Quantity] > 0) AND ((Type = 2) or (Type = 7))
	
    set @Res = 1

END







GO

/****** Object:  StoredProcedure [dbo].[GeoLocalizacion]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[GeoLocalizacion]
	-- Add the parameters for the stored procedure here
	@IP float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	SELECT     TOP (1) ip_Desde, ip_Hasta, Cod_Pais, Nom_Pais, Provincia, Ciudad, latitud, longitud, CP, Zona_Horaria
	FROM         iplocation
	WHERE     (ip_Desde <= @IP) AND (ip_Hasta >= @IP)
	ORDER BY ip_Desde
	
END

GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Pruebas_0]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_Pruebas_0] 
	@Res Varchar(20) output
AS
BEGIN
begin try

	DECLARE @returncode int
	
	--EXEC @returncode = xp_cmdshell 'dtexec /f "\\srv-dbc\Web\Server\ActualizarDatosWeb.dtsx" /Password "blOck07"'
	EXEC @returncode = xp_cmdshell 'dtexec /DECRYPT "blOck07" /f "\\srv-dbc\Web\Server\ActualizarDatosWebPrueba_0.dtsx"'
		
	Set @Res = @returncode

end try
begin catch
	Set @Res = 'Error'
end catch

END







GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_0]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[Web_Actu_0] 
	@Res Varchar(20) output
AS
BEGIN
begin try

	DECLARE @returncode int
	
	--EXEC @returncode = xp_cmdshell 'dtexec /f "\\srv-dbc\Web\Server\ActualizarDatosWeb.dtsx" /Password "blOck07"'
	EXEC @returncode = xp_cmdshell 'dtexec /DECRYPT "blOck07" /f "\\srv-dbc\Web\Server\ActualizarDatosWeb_0.dtsx"'
		
	Set @Res = @returncode

end try
begin catch
	Set @Res = 'Error'
end catch

END







GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_1]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
create PROCEDURE [dbo].[Web_Actu_1] 
	@Res Varchar(20) output
AS
BEGIN
begin try

	DECLARE @returncode int
	
	--EXEC @returncode = xp_cmdshell 'dtexec /f "\\srv-dbc\Web\Server\ActualizarDatosWeb.dtsx" /Password "blOck07"'
	EXEC @returncode = xp_cmdshell 'dtexec /DECRYPT "blOck07" /f "\\srv-dbc\Web\Server\ActualizarDatosWeb_1.dtsx"'
		
	Set @Res = @returncode

end try
begin catch
	Set @Res = 'Error'
end catch

END







GO

/****** Object:  StoredProcedure [dbo].[Web_Actu_Pruebas_1]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
create PROCEDURE [dbo].[Web_Actu_Pruebas_1] 
	@Res Varchar(20) output
AS
BEGIN
begin try

	DECLARE @returncode int
	
	--EXEC @returncode = xp_cmdshell 'dtexec /f "\\srv-dbc\Web\Server\ActualizarDatosWeb.dtsx" /Password "blOck07"'
	EXEC @returncode = xp_cmdshell 'dtexec /DECRYPT "blOck07" /f "\\srv-dbc\Web\Server\ActualizarDatosWebPrueba_1.dtsx"'
		
	Set @Res = @returncode

end try
begin catch
	Set @Res = 'Error'
end catch

END







GO

/****** Object:  StoredProcedure [dbo].[Web_Actu1]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<J.M Escorihuela>
-- Create date: <24/09/2013>
-- Description:	<>
-- =============================================
create PROCEDURE [dbo].[Web_Actu1] 
	@Res Varchar(20) output
AS
BEGIN
begin try

	DECLARE @returncode int
	
	--EXEC @returncode = xp_cmdshell 'dtexec /f "\\srv-dbc\Web\Server\ActualizarDatosWeb.dtsx" /Password "blOck07"'
	EXEC @returncode = xp_cmdshell 'dtexec /DECRYPT "blOck07" /f "\\srv-dbc\Web\Server\ActualizarDatosWeb1.dtsx"'
		
	Set @Res = @returncode

end try
begin catch
	Set @Res = 'Error'
end catch

END







GO

/****** Object:  StoredProcedure [dbo].[GEN_GET_Fecha]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[GEN_GET_Fecha] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT GETDATE() AS FECHA

END












GO

/****** Object:  StoredProcedure [dbo].[ProdSD_Produc_Hist]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ProdSD_Produc_Hist]
	@Fecha nVarchar(50)

AS
BEGIN
	declare @RCount as int
	

	insert into ProdSD_Produccion_Hist(ID, Carro, OFL, Producto, Nivel, IP, Tipo, Compo, Cantidad, Registrado, Tipologia, PPrep, AcumuladoPrep, [Fecha Acumulado], [Fecha Prep], UM, Long, 
			  CanUM, DesIP, DesCompo, Restos, CantProd, CantPor, PorReg, AProd, EnProd, Prioridad, AcumulaPrep, SubPrioridad, NoPreparar, AProdIP, 
			  ProductoIP, MedCorte, Estado, Imp, NivelT, CanOF, CierreOF, CanBarra, OrdenCorte)
	SELECT ID, Carro, OFL, Producto, Nivel, IP, Tipo, Compo, Cantidad, Registrado, Tipologia, PPrep, AcumuladoPrep, [Fecha Acumulado], [Fecha Prep], UM, Long, 
			  CanUM, DesIP, DesCompo, Restos, CantProd, CantPor, PorReg, AProd, EnProd, ProdSD_Produccion.Prioridad, AcumulaPrep, SubPrioridad, NoPreparar, AProdIP, 
			  ProductoIP, MedCorte, ProdSD_Produccion.Estado, Imp, NivelT, CanOF, CierreOF, CanBarra, OrdenCorte
	FROM   ProdSD_Produccion  INNER JOIN
				ProdSD_Carros ON ProdSD_Produccion.Carro = ProdSD_Carros.NCarro AND ProdSD_Produccion.OFL = ProdSD_Carros.NOF
	     
	WHERE     (ProdSD_Produccion.Estado = 0) AND (ProdSD_Carros.[Fecha alta] < CONVERT(DATETIME, @Fecha, 102))

	


	insert into ProdSD_Produccion_IP_Hist(ID, Carro, OFL, Producto, Nivel, IP, Tipo, Compo, Cantidad, Registrado, Tipologia, PPrep, AcumuladoPrep, [Fecha Acumulado], [Fecha Prep], UM, Long, 
			  CanUM, DesIP, DesCompo, Restos, CantProd, CantPor, PorReg, AProd, EnProd, Prioridad, AcumulaPrep, SubPrioridad, NoPreparar, AProdIP, 
			  ProductoIP, MedCorte, Estado, Imp, NivelT, CanOF, CierreOF, CanBarra, OrdenCorte)
	SELECT ID, Carro, OFL, Producto, Nivel, IP, Tipo, Compo, Cantidad, Registrado, Tipologia, PPrep, AcumuladoPrep, [Fecha Acumulado], [Fecha Prep], UM, Long, 
			  CanUM, DesIP, DesCompo, Restos, CantProd, CantPor, PorReg, AProd, EnProd, ProdSD_Produccion_IP.Prioridad, AcumulaPrep, SubPrioridad, NoPreparar, AProdIP, 
			  ProductoIP, MedCorte, ProdSD_Produccion_IP.Estado, Imp, NivelT, CanOF, CierreOF, CanBarra, OrdenCorte
	FROM   ProdSD_Produccion_IP  INNER JOIN
				ProdSD_Carros ON ProdSD_Produccion_IP.Carro = ProdSD_Carros.NCarro AND ProdSD_Produccion_IP.OFL = ProdSD_Carros.NOF    
	WHERE     (ProdSD_Produccion_IP.Estado = 0) AND (ProdSD_Carros.[Fecha alta] < CONVERT(DATETIME, @Fecha, 102))

	

	DELETE FROM ProdSD_Produccion
	FROM ProdSD_Produccion  INNER JOIN
			 ProdSD_Carros ON ProdSD_Produccion.Carro = ProdSD_Carros.NCarro AND ProdSD_Produccion.OFL = ProdSD_Carros.NOF    
	WHERE  (ProdSD_Produccion.Estado = 0) AND (ProdSD_Carros.[Fecha alta] < CONVERT(DATETIME, @Fecha, 102))

	

	DELETE FROM ProdSD_Produccion_IP
	FROM   ProdSD_Produccion_IP  INNER JOIN
				ProdSD_Carros ON ProdSD_Produccion_IP.Carro = ProdSD_Carros.NCarro AND ProdSD_Produccion_IP.OFL = ProdSD_Carros.NOF    
	WHERE     (ProdSD_Produccion_IP.Estado = 0) AND (ProdSD_Carros.[Fecha alta] < CONVERT(DATETIME, @Fecha, 102))

	
			
	set @RCount = @@Rowcount


END






GO

/****** Object:  StoredProcedure [dbo].[GEN_MoviPickCao_Calc]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GEN_MoviPickCao_Calc] 
	@Res int output
AS
BEGIN
	SET NOCOUNT ON;

begin try
   drop table tmpMovPickCao
end try
begin catch
	Set @Res = 0
end catch


SELECT tMovPickCao.[Item No_]as No_, tMovPickCao.[Bin Code],tMovPickCao.[Location Code], 
isnull((SELECT tAlmFis.Externo
		FROM [INDUSTRIAS COSMIC, S_A_U_$Mapa almacén] AS tMapaAlm INNER JOIN
				[INDUSTRIAS COSMIC, S_A_U_$Almacenes físicos] AS tAlmFis ON tMapaAlm.[Almacén físico] = tAlmFis.[Cód_ Almacén Físico]
		WHERE (tMapaAlm.[Cód_ Situación] = tMovPickCao.[Bin Code])),0) as Externo,
'' as Catalogación,
'' as Destino,
MAX(tMovPickCao.Usuario) as [Último Usuario Movi],
Case When tMovPickCao.[Bin Code] = 'RECEPCAO' then 1 else 0 end as [Mostra CuaT Recep],
Case When tMovPickCao.[Bin Code] = 'MONTAJECAO' then 1 else 0 end as [Mostra CuaT Montaje],
Case When tMovPickCao.[Bin Code] = 'PREPARCAO' then 1 else 0 end as [Mostra CuaT Lanza],
MAX(tMovPickCao.[Posting Date]) AS [Fecha Último Movi],
(SELECT top(1) Hora
	FROM [INDUSTRIAS COSMIC, S_A_U_$Mov_ PickCaotic]
	WHERE ([Item No_] = tMovPickCao.[Item No_]) 
		AND ([Posting Date] = MAX(DISTINCT tMovPickCao.[Posting Date]))
	order by Hora desc) as [Hora Último Movi],

tProd.Description,
(SELECT  [Shelf_Bin No_]
	FROM [INDUSTRIAS COSMIC, S_A_U_$Item]
	WHERE (No_ = tMovPickCao.[Item No_])) as [Situación Picking],
Case When tMovPickCao.[Bin Code] = 'MAMPARACAO' then 1 else 0 end as [Mostra CuaT Mamp],

(SELECT sum(Quantity)
	FROM [INDUSTRIAS COSMIC, S_A_U_$Mov_ PickCaotic]
	WHERE ([Item No_] = tMovPickCao.[Item No_]) 
		AND ([Bin Code] = tMovPickCao.[Bin Code])) as Cantidad


into tmpMovPickCao
FROM         [INDUSTRIAS COSMIC, S_A_U_$Mov_ PickCaotic] AS tMovPickCao INNER JOIN
                      [INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd ON tMovPickCao.[Item No_] = tProd.No_
GROUP BY tMovPickCao.[Item No_], tMovPickCao.[Bin Code], tProd.Description,tMovPickCao.[Location Code]
HAVING      (tMovPickCao.[Item No_] > '')

--Una vez agrupados los movimientos selecionamos los registros
Insert Into [INDUSTRIAS COSMIC, S_A_U_$Producto Ubicación] ( No_, [Bin Code], 
															[Location Code],
															Externo, 
															Catalogación, Destino, 
															[Último Usuario Movi], [Mostra CuaT Recep], [Mostra CuaT Montaje], 
															[Mostra CuaT Lanza],  
															[Fecha Último Movi], [Hora Último Movi],
															Description, 
															[Situación Picking], [Mostra CuaT Mamp])

SELECT  tmpMovPickCao.No_, tmpMovPickCao.[Bin Code], 
		tmpMovPickCao.[Location Code], 
		tmpMovPickCao.Externo, 
		tmpMovPickCao.Catalogación, tmpMovPickCao.Destino, 
        substring(tmpMovPickCao.[Último Usuario Movi],0,10) as [Último Usuario Movi],
        tmpMovPickCao.[Mostra CuaT Recep], 
        tmpMovPickCao.[Mostra CuaT Montaje], tmpMovPickCao.[Mostra CuaT Lanza], 
        tmpMovPickCao.[Fecha Último Movi], tmpMovPickCao.[Hora Último Movi], 
        substring(tmpMovPickCao.Description,1,68) as Description, tmpMovPickCao.[Situación Picking], 
        tmpMovPickCao.[Mostra CuaT Mamp]
FROM  tmpMovPickCao LEFT OUTER JOIN
          [INDUSTRIAS COSMIC, S_A_U_$Producto Ubicación] ON tmpMovPickCao.No_ = [INDUSTRIAS COSMIC, S_A_U_$Producto Ubicación].No_
WHERE ([INDUSTRIAS COSMIC, S_A_U_$Producto Ubicación].No_ IS NULL) and (tmpMovPickCao.Cantidad <> 0)



	set @Res = @@rowcount

END
	








GO

/****** Object:  StoredProcedure [dbo].[GEN_GET_PT]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_GET_PT] 
	@Ip as varchar(30),
	@PT as varchar(20)
AS
BEGIN
with RecIP (IP,IPr,PT) 
as ( 	
	SELECT    [IP No_],[INDUSTRIAS COSMIC, S_A_U_$IP Line].No_,[Tipo] 	
	FROM  [INDUSTRIAS COSMIC, S_A_U_$IP Line] inner join [INDUSTRIAS COSMIC, S_A_U_$IP Header] 			
			on [INDUSTRIAS COSMIC, S_A_U_$IP Line].[No_] = [INDUSTRIAS COSMIC, S_A_U_$IP Header].No_ 	
	WHERE     ([IP No_] = @Ip) AND (Type = 3) 	
	union all 
		Select m.IP,e.No_,h.[Tipo] 		
		from [INDUSTRIAS COSMIC, S_A_U_$IP Line] as e inner join [INDUSTRIAS COSMIC, S_A_U_$IP Header] as h 			
			on e.[No_] = h.No_ Inner Join RecIP as m 				
			on e.[IP No_] = m.IPr 		
		WHERE (Type = 3) 
	) 
Select * from RecIP where  (PT = @PT) 

UNION ALL

SELECT No_,@Ip, Tipo
FROM         [INDUSTRIAS COSMIC, S_A_U_$IP Header]
WHERE     (No_ = @Ip) AND (Tipo = @PT)	
	
return @@RowCount
	
END








GO

/****** Object:  StoredProcedure [dbo].[Pruebas2]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Pruebas2]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @IP varchar(50)
	declare @Res varchar(512)
	
	Set @IP = 'T96R0911922035060'
	set @Res = dbo.fncProdSD_ComentIP(@IP);

	
END









GO

/****** Object:  StoredProcedure [dbo].[GEN_ALTA_DEMONIOS]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_ALTA_DEMONIOS]
	@ID as nvarchar(50),
	@Proceso as nvarchar(50),
	@IdProc varchar(100),	
	@Can int,
	@Res int output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    declare @vFechaMov varchar(20)
    declare @vHora varchar(20)

    set @vFechaMov = convert(varchar,datepart(day,GETDATE())) + '/' + convert(varchar,datepart(month,GETDATE())) + '/' + convert(varchar,datepart(year,GETDATE())) + ' 0:00:00'
    set @vHora = '01/01/1753 ' + convert(varchar,datepart(hh,GETDATE())) + ':' + convert(varchar,datepart(n,GETDATE())) + ':' + convert(varchar,datepart(s,GETDATE()))

    if @ID <> 'FICHERO'
    BEGIN
		insert into dbo.[INDUSTRIAS COSMIC, S_A_U_$Demonios](ID,Proceso,IdProceso,Cantidad)
						values(@ID,@Proceso,@IdProc,@Can)
    END
    
	begin try	
		insert into dbo.Demonios2(ID,Proceso,IdProceso,Cantidad,Fecha,Hora)
						values(@ID,@Proceso,@IdProc,@Can,@vFechaMov,@vHora)
	end try
	begin catch
		Set @Res = 1
	end catch

	set @Res=1
END








GO

/****** Object:  StoredProcedure [dbo].[Proc_CalProductoAlmacen]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

		CREATE PROC [dbo].[Proc_CalProductoAlmacen]
		AS
		BEGIN
		
			drop table dbo.CalProductoAlmacen2
			SELECT Producto, Almacen, 
					convert(money,isnull((SELECT s12
						FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] AS Mov 
						WHERE (bucket = 4) AND (f2 = CalProductoAlmacen.Producto)  AND (f8 = CalProductoAlmacen.Almacen)),0)) as Stock,

					convert(money,isnull((SELECT s61
						FROM [INDUSTRIAS COSMIC, S_A_U_$5407$2] AS Mov 
						WHERE (bucket = 3) AND (f1 = 3) AND (f11 = CalProductoAlmacen.Producto)  AND (f30 = CalProductoAlmacen.Almacen)),0)) as CdadCompLanz,

					convert(money,isnull((SELECT sum(s61)
						FROM [INDUSTRIAS COSMIC, S_A_U_$5407$2] AS Mov 
						WHERE (bucket = 3) AND (f1 = 1 or f1 = 2) AND (f11 = CalProductoAlmacen.Producto)  AND (f30 = CalProductoAlmacen.Almacen)),0)) as CdadCompPlan  
			INTO dbo.CalProductoAlmacen2
			FROM  CalProductoAlmacen
			WHERE  (Almacen = N'NORMAL') OR
				  (Almacen LIKE N'PV%') OR
				  (Almacen LIKE N'457%') OR
				  (Almacen = N'MATPRIMA')	
				  
				  	
		END

GO

/****** Object:  StoredProcedure [dbo].[Proc_CalProductoAlmacenLibre]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

		create PROC [dbo].[Proc_CalProductoAlmacenLibre]
		AS
		BEGIN
		
			drop table dbo.CalProdAlmacen3
			SELECT Producto, Almacen, dbo.fncProdStDisponible(Producto,Almacen) as Stock
			INTO dbo.CalProdAlmacen3
			FROM  CalProductoAlmacen
			WHERE  (Almacen = N'NORMAL') OR
				  (Almacen LIKE N'PV%') OR
				  (Almacen LIKE N'457%') OR
				  (Almacen = N'MATPRIMA')				  
				  	
		END

GO

/****** Object:  StoredProcedure [dbo].[GEN_ALTA_ZONAADICIONAL]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[GEN_ALTA_ZONAADICIONAL]
	@Situ as varchar(10),
	@TipoRef as int,
	@Pedido as varchar(10),
	@Prod as varchar(20),
	@Fecha as varchar(20),
	@MatriculaPalet as varchar(10),
	@Nota as varchar(100),
	@Hora as varchar(20),
	@CodigoAlmacen as varchar(10),
	@LoteFabricacionProducto as varchar(10),
	@FechaCad as varchar(20),
	@TipoPalet as int,
	@SituPick as varchar(10),
	@Consumir as int,
	@Block as int,
	@LoteFifo as varchar(20),
	@NEP as varchar(20),
	@Res int output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @vIDE int
	DECLARE @vRefXPalet int
	
	DECLARE @vIdeRA varchar(20)
	DECLARE @vSelecRA int
	DECLARE @vAlmFis varchar(20)
	DECLARE @ZonaAlm varchar(20)
	DECLARE @vExterno int
	DECLARE @vQ decimal(38,10)

	set @vRefXPalet = 0
	set @vIdeRA = ''
	set @vSelecRA = 0
	set @vAlmFis = ''
	set @ZonaAlm = ''
	set @vExterno = 0
	set @vQ = 0

	set @vIDE=isnull((	
						SELECT ide
						FROM [INDUSTRIAS COSMIC, S_A_U_$Zona Adicional]
						WHERE ([Matrícula Palet] = @MatriculaPalet) AND (Nº = @Prod)	
					  ),0)

    if @vIDE = 0
		begin
			set @vIDE=isnull((
						SELECT MAX(ide) AS Ide
						FROM [INDUSTRIAS COSMIC, S_A_U_$Zona Adicional]
					  ),0)

			set @vIDE=@vIDE+1
	

			insert into dbo.[INDUSTRIAS COSMIC, S_A_U_$Zona Adicional](ide,[Cód_ Situación],[Tipo Referencia],
										Pedido,[Nº],Fecha,[Matrícula Palet],[Nota],Hora,[Código Almacén],[Lote Fabricación Producto],
										[Fecha Caducidad],[Tipo Palet],[Cód_ Situ_ Picking],[Consumir primero],
										[Bloqueado],[Lote FIFO],[Nº EP],[Cant Ref x Palet],ideRA,[SelecciónRA],[Cód_ Almacén Físico],
										[Zona Almacén],Externo,Q)
										
							values(@vIDE,@Situ,@TipoRef,@Pedido,@Prod,@Fecha,@MatriculaPalet,
									@Nota,@Hora,@CodigoAlmacen,@LoteFabricacionProducto,
									@FechaCad,@TipoPalet,@SituPick,@Consumir,@Block,
									@LoteFifo,@NEP,@vRefXPalet,@vIdeRA,@vSelecRA,@vAlmFis,@ZonaAlm,@vExterno,@vQ)
		end

	set @Res=@vIDE
END





















GO

/****** Object:  StoredProcedure [dbo].[GEN_ALTA_MOVIPICKING]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
 CREATE PROCEDURE [dbo].[GEN_ALTA_MOVIPICKING]
	@TipoMov as int,
	@No as nvarchar(20),
	@Cantidad as int,
	@StockAnt as int,
	@Nota as nvarchar(100),
	@Fecha as nvarchar(20),
	@Usuario as nvarchar(20),
	@Hora as nvarchar(20),
	@Documento as nvarchar(20),
	@Linea as Bigint,
	@CantidadDec as decimal(38,20),
	@Res int output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    declare @vFechaMov varchar(20)
    declare @vHora varchar(20)
	declare @CanOEA int
	declare @StockPicking int
    declare @StockLibre int

    set @vFechaMov = convert(varchar,datepart(day,GETDATE())) + '/' + convert(varchar,datepart(month,GETDATE())) + '/' + convert(varchar,datepart(year,GETDATE())) + ' 0:00:00'
    set @vHora = '01/01/1754 ' + convert(varchar,datepart(hh,GETDATE())) + ':' + convert(varchar,datepart(n,GETDATE())) + ':' + convert(varchar,datepart(s,GETDATE()))
	
    insert into dbo.[INDUSTRIAS COSMIC, S_A_U_$MoviPicking]([Tipo Movimiento],[Nº],
               [Cantidad],[Fecha],[Hora],[Nº Documento],[Nº Línea],[Stock anterior],
			   [Nota],[Usuario],[Cantidad Dec],[Cód_ Situación],[Cód_ Almacén Físico])
					values(@TipoMov,@No,@Cantidad,@vFechaMov,@vHora,@Documento,
							@Linea,@StockAnt,@Nota,@Usuario,@CantidadDec,'','')

    set @StockPicking = CONVERT(int,ISNULL((SELECT [Stock Picking]
					FROM [INDUSTRIAS COSMIC, S_A_U_$Item]
					WHERE [No_] = @No), 0)) 

    set @CanOEA = CONVERT(int,ISNULL((SELECT SUM(Cantidad)
					FROM [INDUSTRIAS COSMIC, S_A_U_$OEA Lineas]
					WHERE ([Situación Línea] = 0) 
							AND ([Código Almacén] = 'normal') 
							AND (Nº = @No)), 0))
    set @StockPicking = @StockPicking + @Cantidad

    set @StockLibre = @StockPicking - @CanOEA

    Update [INDUSTRIAS COSMIC, S_A_U_$Item] set [Stock Picking] = @StockPicking
           where [No_] = @No

    Update [INDUSTRIAS COSMIC, S_A_U_$Reponer] set [Picking Libre] = @StockLibre
           where ([No_] = @No) AND (Almacén = 'NORMAL')

	set @Res=1
END














GO

/****** Object:  StoredProcedure [dbo].[GEN_MODIF_SITROBOT]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_MODIF_SITROBOT]
	@Palet nvarchar(20),
	@SituDesde nvarchar(20),
	@SituHasta nvarchar(20),
	@Res int output

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
			Update [INDUSTRIAS COSMIC, S_A_U_$Matrícula de Palet]
				set [Cód_ Situación] = @SituHasta,[Último Usuario Movi] = 'ROBOT',
				[Destino] = '',[Situ Origen] = '',[Usuari Voy] = ''
			where [Matrícula Palet] = @Palet and [Cód_ Situación] = @SituDesde

			Update [INDUSTRIAS COSMIC, S_A_U_$Zona Adicional]
				set [Cód_ Situación] = @SituHasta
			where [Matrícula Palet] = @Palet and [Cód_ Situación] = @SituDesde

	set @Res = 1
END










GO

/****** Object:  StoredProcedure [dbo].[PLAN_LOG_ALTA]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PLAN_LOG_ALTA] 
	@Tipo as nvarchar(150),
	@Tabla as nvarchar(250),	
	@Campo as nvarchar(50),
	@ValorAnt as nvarchar(50),
	@ValorNue as nvarchar(50),
	@Usuario as nvarchar(50),
	@Plantilla as nvarchar(50),
	@Res int output
AS
BEGIN
    declare @vFecha varchar(20)
    declare @vHora varchar(20)
    set @vFecha = convert(varchar,datepart(day,GETDATE())) + '/' + convert(varchar,datepart(month,GETDATE())) + '/' + convert(varchar,datepart(year,GETDATE())) + ' 0:00:00'
    set @vHora = '01/01/1754 ' + convert(varchar,datepart(hh,GETDATE())) + ':' + convert(varchar,datepart(n,GETDATE())) + ':' + convert(varchar,datepart(s,GETDATE()))

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    INSERT INTO dbo.[Plantillas Log] 
			VALUES (@Tipo,@Tabla,@Campo,@ValorAnt,@ValorNue,@Usuario,@vFecha,@vHora,@Plantilla)

	set @Res = @@Rowcount

END







GO

/****** Object:  StoredProcedure [dbo].[Pruebas]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Batch submitted through debugger: SQLQuery62.sql|7|0|C:\Users\JMEscorihuela.COSMIC\AppData\Local\Temp\~vsAE3B.sql


CREATE PROCEDURE [dbo].[Pruebas]
	@Par1 nVarchar(50)

AS
BEGIN

	declare @Count int

Select round(((dbo.fncProdSD_MiniReg('MOL3',IP,ofl)*CanUM)/100),1) as a,Registrado,* 
from ProdSD_Produccion  
WHERE (Tipologia = 'MOL3') and (Estado = 1 ) and OFL = 'OL13-04463'


END






GO

/****** Object:  StoredProcedure [dbo].[ProdSD_Faltas_Compo]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[ProdSD_Faltas_Compo]
AS
BEGIN

		--Drop Table tmpMampDesp
		--Drop Table tmpMampPen
		--Drop Table tmpMampPedPen
		--Drop Table tmpMampFalta
		--Drop Table tmpMampStoI
		--Drop Table tmpFalta


		----Creo la tabla de Despieces
		WITH CTE_Componentes (Orig,LM,No_,Tipo,Cant) 
		AS 
		( 
		SELECT Produc.No_ AS Orig, lm.[Production BOM No_], lm.No_, lm.Type, lm.[Quantity per] 
		FROM [INDUSTRIAS COSMIC, S_A_U_$Production BOM Line] AS lm INNER JOIN 
		[INDUSTRIAS COSMIC, S_A_U_$Item] AS Produc ON Produc.[Production BOM No_] = lm.[Production BOM No_] INNER JOIN 
		[INDUSTRIAS COSMIC, S_A_U_$Production BOM Header] AS CabLM ON lm.[Production BOM No_] = CabLM.No_ 
		WHERE (CabLM.Status = 1) 
		AND ((Produc.[Nº I_P_] <> '') ) 
		UNION ALL 
		SELECT cte.Orig as Orig,e.[Production BOM No_],e.[No_],e.[Type],convert(decimal(38,20),(e.[Quantity per]*cte.cant)) as Canti  FROM [INDUSTRIAS COSMIC, S_A_U_$Production BOM Line] e 
		INNER JOIN CTE_Componentes cte ON e.[Production BOM No_] = cte.[No_] 
		where cte.Tipo = 2 
		) 
		SELECT Orig as ref,No_ as rp,cant as np 
		into #tmpMampDesp
		FROM CTE_Componentes where tipo=1 
		
		--Creo la tabla de Mamparas Pendientes Normales

		SELECT DISTINCT 
			  tLinPed.[Location Code], tLinPed.No_, tProd.[Excluir MRP-MPS] AS NoMRP, 
			  tLinPed.[Roca Ref_ para SIP], tLinPed.[Roca Ref_ Especial], 
			  tLinPed.[SIP Pedido], 
			  SUM(tLinPed.[Outstanding Quantity]) AS PVPen,
			  dbo.fncProdSt(tLinPed.No_, tLinPed.[Location Code]) AS Stock,
			  dbo.fncProdOFabPen(tLinPed.No_, tLinPed.[Location Code],3) AS OFPen 
		      
		into #tmpMampPen
		      
		FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line] AS tLinPed LEFT OUTER JOIN
			  [INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd ON tLinPed.No_ = tProd.No_
		WHERE (tLinPed.[Document Type] = 1) AND (tLinPed.Type = 2)
				AND ((tProd.[Nº I_P_] <> ''))
				and (tLinPed.[Roca Ref_ para SIP] = '')
				and (tLinPed.[Roca Ref_ Especial] = 0)
		GROUP BY tLinPed.[Location Code], tLinPed.No_, tLinPed.[Roca Ref_ para SIP], 
				tLinPed.[SIP Pedido], tLinPed.[Roca Ref_ Especial], tProd.[Excluir MRP-MPS]
		HAVING  (SUM(tLinPed.[Outstanding Quantity]) > 0)		


		--Creo la tabla de Mamparas Pendientes Especiales
		insert into #tmpMampPen
		SELECT DISTINCT 
			  tLinPed.[Location Code], tLinPed.[Roca Ref_ para SIP] as No_, tProd.[Excluir MRP-MPS] AS NoMRP, 
			  tLinPed.[Roca Ref_ para SIP], tLinPed.[Roca Ref_ Especial], 
			  tLinPed.[SIP Pedido], 
			  SUM(tLinPed.[Outstanding Quantity]) AS PVPen,
			  dbo.fncProdSt(tLinPed.[Roca Ref_ para SIP], tLinPed.[Location Code]) AS Stock,
			  dbo.fncProdOFabPen(tLinPed.[Roca Ref_ para SIP], tLinPed.[Location Code],3) AS OFPen 
		      
		      
		FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line] AS tLinPed LEFT OUTER JOIN
			  [INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd ON tLinPed.[Roca Ref_ para SIP] = tProd.No_
		WHERE (tLinPed.[Document Type] = 1) AND (tLinPed.Type = 2)
				AND ((tProd.[Nº I_P_] <> '') )
				and (tLinPed.[Roca Ref_ para SIP] <> '')
				and (tLinPed.[Roca Ref_ Especial] = 1)
		GROUP BY tLinPed.[Location Code], tLinPed.No_, tLinPed.[Roca Ref_ para SIP], 
				tLinPed.[SIP Pedido], tLinPed.[Roca Ref_ Especial], tProd.[Excluir MRP-MPS]
		HAVING  (SUM(tLinPed.[Outstanding Quantity]) > 0)		



	--Creo la Tabla de Pedidos pendientes 
	
	SELECT tLinPed.[Document No_],tLinPed.[Line No_] as Linea, tLinPed.No_, tLinPed.[Location Code], 
			(case when tLinPed.[Plazo Estándar] = '1753-01-01 00:00:00.000' then tLinPed.[Plazo Producción] else tLinPed.[Plazo Estándar] end) as [Plazo Estándar] , 
			tLinPed.Description, 
			tLinPed.[Outstanding Quantity],0 as Nece
	into #tmpMampPedPen
	FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line] AS tLinPed INNER JOIN
		   #tmpMampPen ON tLinPed.[Location Code] = #tmpMampPen.[Location Code] AND tLinPed.No_ = #tmpMampPen.No_
	WHERE (tLinPed.[Document Type] = 1) AND (tLinPed.[Outstanding Quantity] <> 0) AND (CONVERT(money, 
		   #tmpMampPen.PVPen - (#tmpMampPen.OFPen + #tmpMampPen.Stock)) > 0)
	order by tLinPed.[Plazo Estándar], tLinPed.No_
	
	--Creo la Tabla de Pedidos pendientes Especiales

	insert into #tmpMampPedPen	
	SELECT tLinPed.[Document No_],tLinPed.[Line No_] as Linea, tLinPed.[Roca Ref_ para SIP] as No_, tLinPed.[Location Code], 
			(case when tLinPed.[Plazo Estándar] = '1753-01-01 00:00:00.000' then tLinPed.[Plazo Producción] else tLinPed.[Plazo Estándar] end) as [Plazo Estándar] , 
			tLinPed.Description, 
			tLinPed.[Outstanding Quantity],0 as Nece
	FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Line] AS tLinPed INNER JOIN
		   #tmpMampPen ON tLinPed.[Location Code] = #tmpMampPen.[Location Code] AND tLinPed.[Roca Ref_ para SIP] = #tmpMampPen.No_
	WHERE (tLinPed.[Document Type] = 1) AND (tLinPed.[Outstanding Quantity] <> 0) AND (CONVERT(money, 
		   #tmpMampPen.PVPen - (#tmpMampPen.OFPen + #tmpMampPen.Stock)) > 0)
	order by tLinPed.[Plazo Estándar], tLinPed.[Roca Ref_ para SIP]
	
	------------------------------------------------------------------------------------------------------
	--Estudio los productos que se esta fabricando
	--Creo la tabla de Stock libre inicial del producto

	SELECT      #tmpMampPen.No_ as Producto, #tmpMampPen.[Location Code] as Almacen,CONVERT(money, dbo.fncProdStLibre(#tmpMampPen.No_ ,#tmpMampPen.[Location Code])) AS Stock
	into #tmpMampStoIP
	FROM         #tmpMampPen

		-------------------------------------------------
		--Estudio
		
		--Proceso de Calculo de Necesidad de Producto
		declare @Pedido as varchar(20)
		declare @Linea as int
		declare @Producto as varchar(20)
		declare @Almacen as varchar(20)
		declare @Plazo as varchar(20)
		declare @Descripcion as varchar(50)
		declare @Can as decimal(38,18)
		declare @Compo as varchar(20)
		declare @CanCompo as decimal(38,18)
		declare @CanNece as decimal(38,18)
		declare @Nece as decimal(38,18)
		declare @Fab as decimal(38,18)
		declare @Des as decimal(38,18)
		declare @ID as int
		declare @RCount as int

		declare @Falta as decimal(38,18)
		declare @StockI as decimal(38,18)
				
		--Cursor de Tabla Mampara Pendientes
		Declare ctmpPedPen Cursor for
			SELECT [Document No_], Linea, No_, [Location Code], [Plazo Estándar], Description, [Outstanding Quantity], Nece
			FROM #tmpMampPedPen
			order by  [Plazo Estándar], No_
			
		--Recorre cursor de Mampara Pendientes
		Open ctmpPedPen

		Fetch Next From ctmpPedPen
			Into @Pedido,@Linea,@Producto,@Almacen,@Plazo,@Descripcion,@Can,@Nece
		
		While @@Fetch_Status = 0
		Begin
			--Busco la cantidad de Stock libre
			SELECT  @StockI=isnull(stock,0)
			FROM  #tmpMampStoIP 
			where Producto = @Producto and Almacen = @Almacen
			
			if (@Stocki >= @Can)
				begin
				   set @Des = @Can
				   set @Fab = 0
				end
				
			if (@Stocki < @Can)
				begin
				   set @Des = @StockI
				   set @Fab = @Can - @StockI
				end
			
			  --Grabo la nueva Cantidad de Necesidad
			if (@Des > 0)
			begin
			  Update #tmpMampStoIP With(RowLock)
			  	set stock = (@StockI - @Des)
				where Producto = @Producto and Almacen = @Almacen
			end
				
			--Actualizo la tabla de Mampara Pendientes
			if (@Fab > 0)
			begin
				update #tmpMampPedPen With(RowLock)
				set Nece = @Can - @Des
				Where [Document No_] = @Pedido
						AND Linea = @Linea
						and No_ = @Producto						
						
				set @RCount = @@Rowcount
			end
			
		Fetch Next From ctmpPedPen
			Into @Pedido,@Linea,@Producto,@Almacen,@Plazo,@Descripcion,@Can,@Nece

	end
	Close ctmpPedPen
	Deallocate ctmpPedPen
	--Fin del cursor de Mampara Pendientes


	----------------------------------------------------------------------------------------------

	--Creo la tabla Final de Faltas

	SELECT ROW_NUMBER() over (Partition by #tmpMampPedPen.[Document No_], #tmpMampPedPen.Linea order by #tmpMampPedPen.Linea ) as ID,
			#tmpMampPedPen.[Document No_], #tmpMampPedPen.Linea, #tmpMampPedPen.No_, #tmpMampPedPen.[Location Code], #tmpMampPedPen.[Plazo Estándar], 
			#tmpMampPedPen.Description, convert(money,#tmpMampPedPen.Nece) as Cantidad, #tmpMampDesp.rp as Compo,convert(money,#tmpMampDesp.np) as CanCompo, 
			convert(money,#tmpMampPedPen.Nece * #tmpMampDesp.np) AS Nece,convert(decimal(38,18),'0.0') as Falta
	into #tmpMampFalta
	FROM #tmpMampPedPen INNER JOIN
				   #tmpMampDesp ON #tmpMampPedPen.No_ = #tmpMampDesp.ref
	ORDER BY #tmpMampPedPen.[Plazo Estándar],#tmpMampPedPen.No_


	------------------------------------------------------------------------------------------------
	--Creo la tabla de Stock libre inicial

	SELECT      #tmpMampDesp.rp as Compo,  CONVERT(money, dbo.fncProdStLibre(#tmpMampDesp.rp,'MATPRIMA')) AS Stock
	into #tmpMampStoI
	FROM         #tmpMampPedPen INNER JOIN #tmpMampDesp ON #tmpMampPedPen.No_ = #tmpMampDesp.ref
	GROUP BY #tmpMampDesp.rp


	---------------------------------------------------------------------------------------------
	--Proceso de Calculo de Faltas
	SET @Pedido = ''
	SET @Linea = 0
	SET @Producto = ''
	SET @Almacen = ''
	SET @Plazo = ''
	SET @Descripcion = ''
	SET @Can = 0
	SET @Compo = ''
	SET @CanCompo = 0
	SET @CanNece = 0
	SET @ID = 0
	SET @RCount = 0

	SET @Falta = 0
	SET @StockI = 0

	--Cursor de Tabla Faltas
	Declare c#tmpFaltas Cursor for
		SELECT ID, [Document No_], Linea, No_, [Location Code], [Plazo Estándar], Description, Cantidad, Compo, CanCompo, Nece
		FROM #tmpMampFalta
		ORDER BY #tmpMampFalta.[Plazo Estándar],#tmpMampFalta.No_
		
	--Recorre cursor de Faltas
	Open c#tmpFaltas

	Fetch Next From c#tmpFaltas
		Into @ID,@Pedido,@Linea,@Producto,@Almacen,@Plazo,@Descripcion,@Can,@Compo,@CanCompo,@CanNece

	While @@Fetch_Status = 0
	Begin
		--Busco la cantidad de Stock libre
		SELECT  @StockI=isnull(stock,0)
		FROM  #tmpMampStoI 
		where Compo = @Compo
		
		set @Falta = 0
		
		if @stocki > @CanNece
			begin
			  set @Falta = 0
			  --Grabo la nueva Cantidad de Stock
			  Update #tmpMampStoI With(RowLock)
				set Stock = (@StockI - @CanNece)
				where Compo = @Compo
			end
			
		if @stocki = @CanNece
			begin
			  set @Falta = 0
			  --Grabo la nueva Cantidad de Stock
			  Update #tmpMampStoI With(RowLock)
				set Stock = (@StockI - @CanNece)
				where Compo = @Compo
			end

		if @stocki < @CanNece
			begin
			  set @Falta = @CanNece - @StockI
			  --Grabo la nueva Cantidad de Stock
			  Update #tmpMampStoI With(RowLock)
				set Stock = 0
				where Compo = @Compo
			end
			
			if (@Falta > 0)
			begin
				--Actualizo la tabla de Faltas
				update #tmpMampFalta With(RowLock)
				set Falta = @Falta
				Where [Document No_] = @Pedido
						AND Linea = @Linea
						and Compo = @Compo
						and ID = @ID
				set @RCount = @@Rowcount
			end

		Fetch Next From c#tmpFaltas
			Into @ID,@Pedido,@Linea,@Producto,@Almacen,@Plazo,@Descripcion,@Can,@Compo,@CanCompo,@CanNece

	end
	Close c#tmpFaltas
	Deallocate c#tmpFaltas
	--Fin del cursor de Faltas
	
	--Seleciono el resultado		

SELECT     #tmpMampFalta.[Document No_], #tmpMampFalta.Linea,tLinVen.[Fecha Alta], 
			(case when  tLinVen.[Fecha Entrada Sistema] = '1753-01-01 00:00:00.000' then CONVERT(DATETIME, '1901-01-01 00:00:00', 102) else tLinVen.[Fecha Entrada Sistema] end) as [Fecha Entrada Sistema],
			#tmpMampFalta.No_, tProd2.[Excluir MRP-MPS] AS NoMRP, tLinVen.[Roca nLin P] as [Linea Pedido Roca],tLinVen.[Roca Pedido] as [Pedido Roca], #tmpMampFalta.[Location Code],
			(case when  #tmpMampFalta.[Plazo Estándar] = '1753-01-01 00:00:00.000' then CONVERT(DATETIME, '1901-01-01 00:00:00', 102) else #tmpMampFalta.[Plazo Estándar] end) as [Plazo Estándar],
                      #tmpMampFalta.Description, #tmpMampFalta.Cantidad, #tmpMampFalta.Compo, tProd.Description AS DesCompo, #tmpMampFalta.CanCompo, #tmpMampFalta.Nece, 
                      #tmpMampFalta.Falta,
                          isnull((SELECT TOP (1) [Document No_] AS Can
                            FROM [INDUSTRIAS COSMIC, S_A_U_$Purchase Line] AS tLinPed2
                            WHERE ([Document Type] = 1) AND (No_ = #tmpMampFalta.Compo)
                            GROUP BY [Document No_]
                            HAVING (SUM([Outstanding Quantity]) <> 0)),'') AS PedCompra, tProd.[Vendor No_] AS Proveedor,
                          isnull((SELECT SUM([Outstanding Quantity]) AS Can
                            FROM [INDUSTRIAS COSMIC, S_A_U_$Purchase Line]
                            WHERE ([Document Type] = 1)
                            GROUP BY No_
                            HAVING (SUM([Outstanding Quantity]) <> 0) AND (No_ = #tmpMampFalta.Compo)),0) AS CanPed,
                          isnull((SELECT TOP (1) [Expected Receipt Date] AS Can
                            FROM [INDUSTRIAS COSMIC, S_A_U_$Purchase Line] AS tLinPed2
                            WHERE ([Document Type] = 1) AND (No_ = #tmpMampFalta.Compo)
                            GROUP BY [Document No_], [Expected Receipt Date]
                            HAVING (SUM([Outstanding Quantity]) <> 0)),'') AS FecRecep                                                          
Into #tmpFalta                                                       
FROM #tmpMampFalta INNER JOIN
	  [INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd ON #tmpMampFalta.Compo = tProd.No_  INNER JOIN
	  [INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd2 ON #tmpMampFalta.No_ = tProd2.No_  INNER JOIN
	  [INDUSTRIAS COSMIC, S_A_U_$Sales Line] AS tLinVen ON #tmpMampFalta.[Document No_] = tLinVen.[Document No_] 
												AND #tmpMampFalta.Linea = tLinVen.[Line No_]



Select [Document No_], Linea,[Fecha Alta],[Fecha Entrada Sistema],[Pedido Roca],[Linea Pedido Roca],
		No_,NoMrp, [Location Code],[Plazo Estándar], Description, Cantidad, Compo, CanCompo, Nece,convert(money, Falta) as Falta,
		PedCompra,Proveedor,convert(money,Canped) as Canped,FecRecep,
		isnull((SELECT (convert(varchar(10),Date,103) + '--' + Comment)
					FROM [INDUSTRIAS COSMIC, S_A_U_$Purch_ Comment Line]
					WHERE ([Document Type] = 1) AND (No_ = PedCompra)),'') as Coment                            

From #tmpFalta
Where Falta <> 0	

END


GO

/****** Object:  StoredProcedure [dbo].[ProdSD_Produc_Previ]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Batch submitted through debugger: SQLQuery62.sql|7|0|C:\Users\JMEscorihuela.COSMIC\AppData\Local\Temp\~vsAE3B.sql


CREATE PROCEDURE [dbo].[ProdSD_Produc_Previ]

AS
BEGIN
	--drop table #tmpPrevi
	--drop table #tmpStoPrevi

	--Creo tabla temporal de Stock
	SELECT tPrevi.[Item No_] AS Producto, tPrevi.[Location Code] AS Almacen,
	(dbo.fncProdOFabDH(tPrevi.[Item No_],tPrevi.[Location Code],2,3) + 
	dbo.fncProdSt(tPrevi.[Item No_],tPrevi.[Location Code]) - 
	dbo.fncProdPVPen(tPrevi.[Item No_],tPrevi.[Location Code])) as OFPen
	into #tmpStoPrevi
	FROM [INDUSTRIAS COSMIC, S_A_U_$Production Forecast Entry] AS tPrevi INNER JOIN
		[INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd ON tPrevi.[Item No_] = tProd.No_
	WHERE (tProd.[Nº I_P_] <> '') 
			AND (tProd.[Excluir MRP-MPS] = 0)
	group by tPrevi.[Item No_], tPrevi.[Location Code]

	--Creo tabla de Previsiones
	SELECT     tPrevi.Sección AS Sec, tPrevi.[Item No_] AS Producto, tPrevi.[Forecast Date] AS Fecha, ROUND(tPrevi.[Forecast Quantity], 0) AS Can, tPrevi.[Location Code] AS Almacen
	into #tmpPrevi
	FROM         [INDUSTRIAS COSMIC, S_A_U_$Production Forecast Entry] AS tPrevi INNER JOIN
						  [INDUSTRIAS COSMIC, S_A_U_$Item] AS tProd ON tPrevi.[Item No_] = tProd.No_ 
	WHERE     (tProd.[Nº I_P_] <> '') 
        --AND (tProd.[No_] = 'TKACX4R20107870787A')		
		AND (tProd.[Excluir MRP-MPS] = 0)


	--Proceso de Ajuste de Previsión
		declare @Sec as varchar(20)
		declare @Producto as varchar(20)
		declare @Fecha as varchar(20)
		declare @Can as decimal(38,18)
		declare @Almacen as varchar(20)
		declare @CanOF as decimal(38,18)
		declare @RCount as int
		
		declare @Dif as decimal(38,18)

		--Cursor de Tabla Previsión Mamparas 
		Declare c#tmpPrevi Cursor for
			SELECT Sec,Producto, Fecha, Can, Almacen
			FROM #tmpPrevi
			
		--Recorre cursor de Previsiones
		Open c#tmpPrevi

		Fetch Next From c#tmpPrevi
			Into @Sec,@Producto,@Fecha,@Can,@Almacen

		While @@Fetch_Status = 0
		Begin
			
			--Busco la cantidad de Stock libre
			SELECT  @CanOF=isnull(OFPen,0)
			FROM  #tmpStoPrevi 
			where Producto = @Producto and Almacen = @Almacen
		
			if (@Can >= @CanOF)
				begin
					set @Dif = @CanOF
				end	
		
			if (@Can < @CanOF)
				begin
					set @Dif = @Can
				end	
				
			  --Grabo la nueva Cantidad de Stock
			  Update #tmpStoPrevi With(RowLock)
				set OFPen = (@CanOF - @Dif)
				where Producto = @Producto and Almacen = @Almacen
				
				
			  --Actualizo cantidad de Prevision
				Update #tmpPrevi
				set Can = (@Can - @Dif)
				Where Sec = @Sec and Producto = @Producto
				
				set @RCount = @@Rowcount

			Fetch Next From c#tmpPrevi
				Into @Sec,@Producto,@Fecha,@Can,@Almacen

		end
		Close c#tmpPrevi
		Deallocate c#tmpPrevi
		--Fin del cursor de Previsiones
		
		
		--Seleciono el resultado
	Select *
	From #tmpPrevi
	Where Can > 0

END






GO

/****** Object:  StoredProcedure [dbo].[ProdSD_Log_ALTA]    Script Date: 11/18/2014 20:25:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProdSD_Log_ALTA] 
	@Proceso as nvarchar(150),
	@Fecha as nvarchar(50),
	@Error as nvarchar(250),
	@SQL as nvarchar(Max),
	@Usuario as nvarchar(50),
	@Res int output
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
   INSERT INTO dbo.ProdSD_Log VALUES (@Proceso,@Fecha,@Error,@SQL,0,@Usuario)

	set @Res = @@Rowcount

END






GO

/****** Object:  StoredProcedure [dbo].[Proc_Varios]    Script Date: 11/18/2014 20:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

		CREATE PROC [dbo].[Proc_Varios] @SQL varchar(4000), @rs decimal(18,2) OUTPUT
		AS
		BEGIN
			DECLARE @cmd varchar(255)

			CREATE TABLE #myTable (col1 varchar(8000))

			
			SELECT @cmd = 'INSERT INTO #myTable99(col1) ' + @SQL
			EXEC(@cmd)
			
			SELECT col1 FROM #myTable
		END

GO

/****** Object:  StoredProcedure [dbo].[GEN_SET_NUMSERIE]    Script Date: 11/18/2014 20:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[GEN_SET_NUMSERIE] 
	@Serie Varchar(20),
	@Grabar varchar(20),
	@Res Varchar(20) output
AS
BEGIN
	Declare @UltNum Varchar(20)
	Declare @Line int
	Declare @NewNum varchar(20)

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	set @UltNum = (
		Select Top(1) [Last No_ Used] from [INDUSTRIAS COSMIC, S_A_U_$No_ Series Line]
			where [Series Code] = @Serie 
			order by [Line No_] desc
				   )
	set @Line = (
		Select Top(1) [Line No_] from [INDUSTRIAS COSMIC, S_A_U_$No_ Series Line]
			where [Series Code] = @Serie 
			order by [Line No_] desc
				   )
    

	Update [INDUSTRIAS COSMIC, S_A_U_$No_ Series Line] set [Last No_ Used] = @Grabar
		where (([Series Code] = @Serie)  and ([Line No_] = @Line))
	
	set @Res=@UltNum
END








GO

/****** Object:  StoredProcedure [dbo].[DEM_GET_ENPROCESO]    Script Date: 11/18/2014 20:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DEM_GET_ENPROCESO]
	@Res varchar(50) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @Process varchar(50)
    -- Insert statements for procedure here
	set @Process = (
			SELECT top(1) Proceso from [dbo].[INDUSTRIAS COSMIC, S_A_U_$Demonios]
			where Id = 'ENPROCESO'
					)
	
	set @Res = @Process

END








GO

/****** Object:  StoredProcedure [dbo].[GEN_BAJA_DEMONIOS]    Script Date: 11/18/2014 20:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[GEN_BAJA_DEMONIOS]
	@IdProc varchar(100),	
	@Res int output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	delete dbo.[INDUSTRIAS COSMIC, S_A_U_$Demonios] Where IdProceso = @IdProc
	
	set @Res=1
END








GO

/****** Object:  StoredProcedure [dbo].[PROC_ERROR_ALTA]    Script Date: 11/18/2014 20:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PROC_ERROR_ALTA] 
	@Proceso as nvarchar(150),
	@Fecha as nvarchar(50),
	@Error as nvarchar(250),
	@SQL as nvarchar(Max),
	@Res int output
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
   INSERT INTO dbo.ProcesError VALUES (@Proceso,@Fecha,@Error,@SQL,0)

	set @Res = @@Rowcount

END







GO

/****** Object:  StoredProcedure [dbo].[GEN_GET_IDPROD_IP]    Script Date: 11/18/2014 20:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_GET_IDPROD_IP] 
	@Res int output


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @Id int;
	select @Id=Isnull(max(id),0)
	From ProdSD_Produccion
	
	set @Res = @Id + 1

END












GO

/****** Object:  StoredProcedure [dbo].[DEM_TRA_VERIF_CAN]    Script Date: 11/18/2014 20:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DEM_TRA_VERIF_CAN]
	@idProc varchar(40),
	@Res int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    DECLARE @vCan int

    -- Insert statements for procedure here
	SELECT top(1) @vCan=Cantidad
	from [dbo].[INDUSTRIAS COSMIC, S_A_U_$Demonios]
	where Id = 'ENPROCESO' AND IdProceso = @idProc
	
	set @Res = isnull(@vCan,0)

END






GO

/****** Object:  StoredProcedure [dbo].[SWEB_BAJA_LINPED]    Script Date: 11/18/2014 20:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SWEB_BAJA_LINPED]
	@Pedido as varchar(20),
	@Linea as varchar(60),
	@Res varchar(20) output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	

	Delete from PedidosWeb Where Pedido = @Pedido and Linea = @Linea


	set @Res='ok'
END













GO

/****** Object:  StoredProcedure [dbo].[SWEB_GET_PEDIDO_WEB_ALTA]    Script Date: 11/18/2014 20:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SWEB_GET_PEDIDO_WEB_ALTA]
	@Comercial Varchar(20),
    @Cliente Varchar(20),
    @Estado Varchar(20)
AS
BEGIN
		Select * from dbo.PedidosWeb
		where Comercial = @Comercial and Cliente = @Cliente and Estado = @Estado
		order by Pedido,Linea

END









GO

/****** Object:  StoredProcedure [dbo].[GEN_ALTA_MOVIPROD]    Script Date: 11/18/2014 20:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GEN_ALTA_MOVIPROD]
	@CAMPOS as VARCHAR(250),
	@VALORES as VARCHAR(250),
	@Res int output
	
AS
BEGIN
	SET NOCOUNT ON;
    declare @vFechaMov varchar(20)
    declare @vHora varchar(20)
	declare @vNumMov int
	declare @vSQL varchar(540)
	
	set @vNumMov = (Select max([Entry No_]) 
					from dbo.[INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry])

	set @VALORES = replace(@VALORES,'[?1]',@vNumMov)

    set @vFechaMov = convert(varchar,datepart(day,GETDATE())) + '/' + convert(varchar,datepart(month,GETDATE())) + '/' + convert(varchar,datepart(year,GETDATE())) + ' 0:00:00'
    set @vHora = '01/01/1754 ' + convert(varchar,datepart(hh,GETDATE())) + ':' + convert(varchar,datepart(n,GETDATE())) + ':' + convert(varchar,datepart(s,GETDATE()))
  
    set @vSQL = 'INSERT INTO dbo.[INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]' + @CAMPOS + ' ' + @VALORES;
	
	EXECUTE(@vSQL)

	set @Res=1
END












GO

/****** Object:  StoredProcedure [dbo].[SWEB_VALIDAR_USUARIO]    Script Date: 11/18/2014 20:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SWEB_VALIDAR_USUARIO]
	@UserID nVarchar(50),
	@Pass nvarchar(250),
    @Valid int output,
	@Tipo varchar(50) output,
	@Codigo varchar(50) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   DECLARE @PassNav nvarchar(250)
   declare @TipoUser varchar(50)
   declare @CodigoUser varchar(50)

   SET @PassNav = (Select [Password] FROM [dbo].[INDUSTRIAS COSMIC, S_A_U_$Contact] where [Login ID] = @UserID)
   SET @TipoUser = (Select [Online User Type] FROM [dbo].[INDUSTRIAS COSMIC, S_A_U_$Contact] where [Login ID] = @UserID)
   SET @CodigoUser = (Select [On Behalf Of] FROM [dbo].[INDUSTRIAS COSMIC, S_A_U_$Contact] where [Login ID] = @UserID)
   
   if @PassNav = @Pass
	begin
		SET @Valid = 1
		set @Tipo = @TipoUser
		set @Codigo = @CodigoUser
	end
	else
	begin
		SET @Valid = 0
		set @Tipo = ''
		set @Codigo = ''
   end

END




GO

/****** Object:  StoredProcedure [dbo].[SWEB_GET_RELLENOPASS]    Script Date: 11/18/2014 20:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SWEB_GET_RELLENOPASS] 
	@UserID Varchar(50),
	@Relleno Varchar(150) output
AS
BEGIN
	declare @Ret varchar(150)
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @Ret = '';
    -- Insert statements for procedure here
	SELECT distinct @Ret = [Contacto].[Password Padding]
		FROM Cosmic.dbo.[INDUSTRIAS COSMIC, S_A_U_$Contact] as Contacto
		WHERE [Contacto].[Login ID] = @UserID;

END
SET @Relleno = @Ret;















GO

/****** Object:  StoredProcedure [dbo].[SWEB_GET_PRODUCTO]    Script Date: 11/18/2014 20:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SWEB_GET_PRODUCTO] 
	@IDTipo nVarchar(50),
    @Almacen nVarchar(50),
	@Res xml output
AS
BEGIN
	if @Almacen = ''
		begin
		set @Res = (
		
			SELECT		Productos.No_, 
			            Productos.Description,
						Productos.[Nombre colección],
						ISNULL((SELECT SUM(Quantity) AS Expr1
                               FROM [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
                               WHERE ([Item No_] = Productos.No_)), 0) AS Existencias
			FROM        [INDUSTRIAS COSMIC, S_A_U_$Item] as Productos
		
			where      (Productos.No_ = @IDTipo) 
			for xml auto
	
					)
		end

	if @Almacen != ''
		begin
		set @Res = (
		
			SELECT		Productos.No_, 
			            Productos.Description,
						Productos.[Nombre colección],
						ISNULL((SELECT SUM(Quantity) AS Expr1
                               FROM [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
                               WHERE ([Item No_] = Productos.No_ and [Location Code] = @Almacen)), 0) AS Existencias
			
			FROM        [INDUSTRIAS COSMIC, S_A_U_$Item] as Productos
		
			where      (Productos.No_ = @IDTipo)
 
			for xml auto
	
					)
		end

END







GO

/****** Object:  StoredProcedure [dbo].[SWEB_GET_COLECCION]    Script Date: 11/18/2014 20:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SWEB_GET_COLECCION]
	@IDTipo nVarchar(50),
    @Almacen nVarchar(50),
	@Res xml output
AS
BEGIN
	if @Almacen = ''
		begin
		set @Res = (
		
			SELECT		Productos.No_, 
			            Productos.Description,
						Productos.[Nombre colección],
						ISNULL((SELECT SUM(Quantity) AS Expr1
                               FROM [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
                               WHERE ([Item No_] = Productos.No_)), 0) AS Existencias
			FROM        [INDUSTRIAS COSMIC, S_A_U_$Item] as Productos
		
			where      ([Nombre colección] = @IDTipo) 
			for xml auto
	
					)
		end

	if @Almacen != ''
		begin
		set @Res = (
		
			SELECT		Productos.No_, 
			            Productos.Description,
						Productos.[Nombre colección],
						ISNULL((SELECT SUM(Quantity) AS Expr1
                               FROM [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
                               WHERE ([Item No_] = Productos.No_ and [Location Code] = @Almacen)), 0) AS Existencias
			
			FROM        [INDUSTRIAS COSMIC, S_A_U_$Item] as Productos
		
			where      ([Nombre colección] = @IDTipo)
 
			for xml auto
	
					)
		end

END







GO

/****** Object:  StoredProcedure [dbo].[GEN_VERIF_DEMONIOS]    Script Date: 11/18/2014 20:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_VERIF_DEMONIOS]
	@ID as nvarchar(50),
	@Proceso as nvarchar(50),
	@Res int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from [dbo].[INDUSTRIAS COSMIC, S_A_U_$Demonios]
	where Id = @ID AND Proceso = @Proceso
	
	set @Res = @@Rowcount
END





GO

/****** Object:  StoredProcedure [dbo].[GEN_TRA_PROCESOS]    Script Date: 11/18/2014 20:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_TRA_PROCESOS]
	@Proceso as nvarchar(50),
	@Res xml output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
set @Res = (	

	select 	[Id] as Id ,
			[Proceso] as Proceso,
			[Campo1] as Campo1,
			[Campo2] as Campo2,
			[Campo3] as Campo3,
			[Campo4] as Campo4,
			[Campo5] as Campo5,
			[Campo6] as Campo6,
			[Campo7] as Campo7,
			[Campo8] as Campo8,
			[Campo9] as Campo9,
			[Campo10] as Campo10,
			[Campo11] as Campo11,
			[Campo12] as Campo12,
			[Campo13] as Campo13,
			[Campo14] as Campo14,
			[Campo15] as Campo15,
			[Campo16] as Campo16,
			[Campo17] as Campo17,
			[Campo18] as Campo18,
			[Campo19] as Campo19,
			[Campo20] as Campo20,
			[Campo21] as Campo21,
			[Campo22] as Campo22,
			[Campo23] as Campo23,
			[Campo24] as Campo24,
			[Campo25] as Campo25,
			[Campo26] as Campo26,
			[Campo27] as Campo27,
			[Campo28] as Campo28,
			[Campo29] as Campo29,
			[Campo30] as Campo30,
			[IdProceso] as IdProceso,
			[Estado] as Estado

	from [dbo].[INDUSTRIAS COSMIC, S_A_U_$Transacciones] as Transac
		where (Transac.Proceso = @Proceso)	
		for xml auto
			)
END



GO

/****** Object:  StoredProcedure [dbo].[GEN_ProductoAlmacen_Calc]    Script Date: 11/18/2014 20:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_ProductoAlmacen_Calc] 
	@Res int output
AS
BEGIN
	SET NOCOUNT ON;


	Drop table AICalProductoAlmacen
	SELECT [Item No_] as Producto, [Location Code] as Almacen,
		   ISNULL((SELECT Producto
				   FROM CalProductoAlmacen
				   WHERE (Producto = Mov.[Item No_]) AND (Almacen = Mov.[Location Code])),'NULO') AS Actu
	INTO AICalProductoAlmacen
	FROM         [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry] AS Mov
	GROUP BY [Item No_], [Location Code]
	
	insert into dbo.AICalProductoAlmacen (Producto,Almacen,Actu)
			SELECT [No_],'',
     		   ISNULL((SELECT Producto
				   FROM CalProductoAlmacen
				   WHERE (Producto = Prod.[No_]) AND (Almacen = '')),'NULO') AS Actu
			FROM dbo.[INDUSTRIAS COSMIC, S_A_U_$Item] as Prod

	INSERT INTO dbo.CalProductoAlmacen (Producto,Almacen) 
			SELECT Producto,Almacen
			FROM AICalProductoAlmacen
			WHERE (Actu = 'NULO')


	set @Res = @@rowcount

END
	








GO

/****** Object:  StoredProcedure [dbo].[GEN_MODIF_SITROBOTPICKING]    Script Date: 11/18/2014 20:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_MODIF_SITROBOTPICKING]
	@Palet nvarchar(20),
	@SituDesde nvarchar(20),
	@SituHasta nvarchar(20),
	@Res int output

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
			Update [INDUSTRIAS COSMIC, S_A_U_$Matrícula de Palet]
				set [Cód_ Situación] = 'PICKING'
			where [Matrícula Palet] = @Palet and [Cód_ Situación] = @SituDesde

			Delete from [INDUSTRIAS COSMIC, S_A_U_$Zona Adicional]
				where [Matrícula Palet] = @Palet and [Cód_ Situación] = @SituDesde

	set @Res = 1
END












GO

/****** Object:  StoredProcedure [dbo].[GEN_MODIF_PROD_ROBOT]    Script Date: 11/18/2014 20:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_MODIF_PROD_ROBOT]
	@Prod varchar(20),
	@ABM varchar(1),
	@Res int output


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
			if @ABM = 'M'
				begin
					Update [INDUSTRIAS COSMIC, S_A_U_$Item]
						set [Traspasable Robot] = 1,
						[Fecha Ult Traspaso Robot] = '01/01/1753 0:00:00'
					where [No_] = @Prod
				end

			if @ABM = 'A'
				begin
					Update [INDUSTRIAS COSMIC, S_A_U_$Item]
						set [Traspasable Robot] = 1,
						[Fecha Ult Traspaso Robot] = '01/01/1753 0:00:00',
						[Traspasado Robot] = 0
					where [No_] = @Prod
				end



	set @Res = 1
END











GO

/****** Object:  StoredProcedure [dbo].[GEN_MODIF_IMP_OEA]    Script Date: 11/18/2014 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_MODIF_IMP_OEA]
	@OEA varchar(20),
	@Res int output


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		Update [INDUSTRIAS COSMIC, S_A_U_$OEA Cabecera]
			set [Nº Impresiones] = 1
		where [OEA] = @OEA
	set @Res = 1
END













GO

/****** Object:  StoredProcedure [dbo].[GEN_MEDLINVENTA_PRODUCTOS]    Script Date: 11/18/2014 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_MEDLINVENTA_PRODUCTOS]
	@Res int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Declare @Producto nvarchar(20)
	Declare @Meses int



	--Cursor tabla Productos
	Declare cProducto Cursor For
		SELECT  No_
		FROM  [INDUSTRIAS COSMIC, S_A_U_$Item]
		WHERE ([Componente] = 0)

		--Recorre Cursor de Producto
		Open cProducto
		Fetch Next From cProducto
			Into @Producto
		While @@Fetch_Status = 0
		Begin
            Set @Meses = CONVERT(int,ISNULL((
							SELECT TOP (1) DATEDIFF(day, [Fecha registro], GETDATE()) / 30 AS Meses
							FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Invoice Line]
							WHERE (No_ = @Producto) AND (Type = 2) AND ([Fecha registro] > convert(varchar,datepart(day,GETDATE()-365)) + '/' + convert(varchar,datepart(month,GETDATE()-365)) + '/' + convert(varchar,datepart(year,GETDATE()-365)) + ' 0:00:00')
							ORDER BY [Fecha registro]
						 ), 0))
			if (@Meses = 0) 
			Begin
				set @Meses = 1
            end
			update [INDUSTRIAS COSMIC, S_A_U_$Item]
			set [Media Lineas Venta]=CONVERT(int,ISNULL((
										SELECT (COUNT([Line No_]) / @Meses) AS Lineas
										FROM [INDUSTRIAS COSMIC, S_A_U_$Sales Invoice Line]
										WHERE (Type = 2) AND ([Fecha registro] > convert(varchar,datepart(day,GETDATE()-365)) + '/' + convert(varchar,datepart(month,GETDATE()-365)) + '/' + convert(varchar,datepart(year,GETDATE()-365)) + ' 0:00:00')
										GROUP BY No_
										HAVING (No_ = @Producto)
									), 0))
			where (No_ = @Producto)

			Fetch Next From cProducto
				Into @Producto
		end
		Close cProducto
		Deallocate cProducto
		--Fin de Productos

	set @Res = 1
END





GO

/****** Object:  StoredProcedure [dbo].[GEN_LIQ_MOVIMIENTOS]    Script Date: 11/18/2014 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_LIQ_MOVIMIENTOS]
	@Res int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	Declare @Producto nvarchar(20)
	Declare @Descripcion nvarchar(100)
	Declare @vStock int
	Declare @vStockI int
	Declare @vStockPen int
	Declare @vDif int
	Declare @vMov int
	Declare @vCan int
	Declare @vCanPen int
	Declare @vOpen int
	Declare @vAlm nvarchar(20)

	declare @Des as nvarchar(150)

--Elimina Pendiente de Movimientos Negativos
Update    [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
   set [Open] = 0,[Remaining Quantity] = 0
WHERE  ([Open] = 1) AND (Quantity < 0)	


--Elimina Tabla Temporal de Almacenes
Drop table ATmpAlms


--Crea tabla temporal de Almacenes
SELECT [Location Code],
		SUM(Quantity) AS Stock,
		sum([Remaining Quantity]) as StockPen,
		(SUM([Remaining Quantity]) - SUM(Quantity)) AS Dif

into AtmpAlms
FROM [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
group by [Location Code]


--Cursor de Tabla Temporal de almacenes
Declare cAlms Cursor for
	SELECT [Location Code]
	FROM AtmpAlms
	WHERE (Dif <> 0)
	
--Recorre cursor de almacenes
Open cAlms

Fetch Next From cAlms
	Into @vAlm

While @@Fetch_Status = 0
Begin
	
	--Elimina tabla temporal de movimientos pendientes de Liquidar
	drop table ATmpLiq
	
	--Crea tabla temporal de movimientos pendientes de Liquidar
	SELECT	Productos.No_, 
			Productos.Description,

			CONVERT(int,ISNULL((SELECT SUM(Quantity)
					FROM [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
					WHERE ([Item No_] = Productos.No_ and [Location Code] = @vAlm)), 0)) AS Stock,

			CONVERT(int,ISNULL((SELECT SUM([Remaining Quantity])
					FROM [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
					WHERE ([Item No_] = Productos.No_ and 
						   [Location Code] = @vAlm and
						   [Open] = 1)), 0)) as StockPen,

			(CONVERT(int,ISNULL((SELECT SUM([Remaining Quantity])
					FROM [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
					WHERE ([Item No_] = Productos.No_ and 
						   [Location Code] = @vAlm and
						   [Open] = 1)), 0)) -

			CONVERT(int,ISNULL((SELECT SUM(Quantity)
					FROM [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
					WHERE ([Item No_] = Productos.No_ and [Location Code] = @vAlm)), 0))) AS Dif
			

	INTO ATmpLiq
	FROM        [INDUSTRIAS COSMIC, S_A_U_$Item] as Productos
	where Componente = 0
    --Fin de creacion de tabla temporal de liquidaciones

	--Cursor tabla temporal de liquidaciones
	Declare cDiferencias Cursor For
		SELECT  No_, Description, Stock, StockPen, Dif
		FROM  ATmpLiq
		WHERE (Dif <> 0)
		
		--Recorre Cursor de liquidaciones
		Open cDiferencias

		Fetch Next From cDiferencias
			Into 	 @Producto,@Descripcion,@vStockI,@vStockPen,@vDif

		SET @vStock = @vStockI
		While @@Fetch_Status = 0
		Begin
			
			-- Tratamiento de las difrencias
			if (@vDif <> 0) 
			Begin
				--Crea cursor de Movimientos a liquidar
				Declare cMov Cursor For
				SELECT [Entry No_], Quantity, [Remaining Quantity], [Open]
				FROM   [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
				WHERE  ([Item No_] = @Producto) AND ([Location Code] = @vAlm) AND (Quantity > 0)
				ORDER BY [Entry No_] DESC
				--Recorre Movimientos a liquidar
				Open cMov

				Fetch Next From cMov
					Into @vMov,@vCan,@vCanPen,@vOpen
				While @@Fetch_Status = 0
				Begin
					if (@vStock > 0)
					begin
						
						if (@vCan = @vStock)
						Begin
							Update [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
								set [Open] = 1,[Remaining Quantity] = @vStock
								WHERE ([Entry No_] = @vMov)	

							set @vStock = 0				
							set @vCan = 0				
						end

						if (@vCan > @vStock)
						Begin
						
							Update [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
								set [Open] = 1,[Remaining Quantity] = @vStock
								WHERE ([Entry No_] = @vMov)	

							set @vStock = 0				
							set @vCan = 0				
						end

						if (@vCan < @vStock)
						Begin
						
							Update [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
								set [Open] = 1,[Remaining Quantity] = @vCan
								WHERE ([Entry No_] = @vMov)	

							set @vStock = @vStock - @vCan
						end
						
					end
					else
					begin
						
						Update [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
							set [Open] = 0,[Remaining Quantity] = 0
							WHERE ([Entry No_] = @vMov)					
					end


					Fetch Next From cMov
						Into @vMov,@vCan,@vCanPen,@vOpen
				end
				Close cMov
				Deallocate cMov
				--Fin de movimientos a liquidar
			end
			-- Fin del Tratamiento de las diferencias
			
			
			Fetch Next From cDiferencias
				Into 	 @Producto,@Descripcion,@vStockI,@vStockPen,@vDif

			SET @vStock = @vStockI
		End
		Close cDiferencias
		Deallocate cDiferencias
		--Fin del cursor de Liquidaciones

	Fetch Next From cAlms
		Into @vAlm

end
Close cAlms
Deallocate cAlms
--Fin del cursor de Almacenes



--set @Des = 'se han contado ' + convert(nvarchar,@vRegs) + '-' 
--		 + convert(nvarchar,@vRegs1) + '-'
--		 + convert(nvarchar,@vRegMov) + '-'
--		 + convert(nvarchar,@vRegStock) + '-'
--		 + convert(nvarchar,@vRegCan) + '-'
--		 + convert(nvarchar,@vRegs2) + '-'
--		 + convert(nvarchar,@vRegs3) + '-'
--         + ' con stock ' + convert(nvarchar,@vStock)
--raiserror(@Des,16,1)

set @Res = 1

RETURN @Res
END





GO

/****** Object:  StoredProcedure [dbo].[GEN_GET_ULTMOVITEM]    Script Date: 11/18/2014 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_GET_ULTMOVITEM] 
	@Res int output
AS
BEGIN
	Declare @UltMov int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	set @UltMov = (
		Select max([Entry No_]) from [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
				   )

	set @Res = @UltMov

END





GO

/****** Object:  StoredProcedure [dbo].[GEN_GET_SITUPALET]    Script Date: 11/18/2014 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO











-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_GET_SITUPALET] 
	@Palet nVarchar(50),
	@Producto nVarchar(50),
	@Res varchar(50) output
AS
BEGIN
	set @Res = (	
		SELECT top(1) [Cód_ Situación]
		FROM [INDUSTRIAS COSMIC, S_A_U_$Zona Adicional] as ZA	
		where ([Matrícula Palet] = @Palet)		
				)


		if @Producto <> ''
			begin
				set @Res = (
					SELECT top(1) [Cód_ Situación]
					FROM [INDUSTRIAS COSMIC, S_A_U_$Zona Adicional] as ZA	
					where ([Matrícula Palet] = @Palet)   AND ([Nº] = @Producto)
						)
			end


END














GO

/****** Object:  StoredProcedure [dbo].[GEN_GET_PRODUCTO2]    Script Date: 11/18/2014 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_GET_PRODUCTO2] 
	@Producto nVarchar(50),
	@Res xml output
AS
BEGIN
		if @Producto <> ''
			begin
				set @Res = (				
					SELECT		No_,
								Description,
								[Shelf_Bin No_Dynamic],
								[Shelf_Bin No_],
								[Stock Picking]

					FROM        [INDUSTRIAS COSMIC, S_A_U_$Item] as Productos
				
					where      (Productos.No_ = @Producto) 
					for xml auto		
							)
			end

		if @Producto = ''
			begin
				set @Res = (				
					SELECT		No_,
								convert(ntext,replace(Description,'<>/&;','_____')) as Description,
								[Shelf_Bin No_Dynamic],
								[Shelf_Bin No_],
								[Stock Picking]

					FROM        [INDUSTRIAS COSMIC, S_A_U_$Item] as Productos
					
					for xml auto
							)
			end

END




GO

/****** Object:  StoredProcedure [dbo].[GEN_GET_PRODUCTO]    Script Date: 11/18/2014 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GEN_GET_PRODUCTO] 
	@Producto nVarchar(50),
	@Res xml output
AS
BEGIN
		if @Producto <> ''
			begin
				set @Res = (				
					SELECT		No_,
								Description,
								[Shelf_Bin No_Dynamic],
								[Shelf_Bin No_],
								[Stock Picking],
								CONVERT(int,ISNULL((SELECT Sum(s12) 
											FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] 
											WHERE (f8 = 'NORMAL' OR f8 = 'MATPRIMA')
											Group By bucket,f2
											HAVING (f2 = Productos.[No_]) AND (bucket = 4)), 0)) AS stock


					FROM        [INDUSTRIAS COSMIC, S_A_U_$Item] as Productos
				
					where      (Productos.No_ = @Producto) 
					for xml auto		
							)
			end

		if @Producto = ''
			begin
				set @Res = (				
					SELECT		No_,
								Description,
								[Shelf_Bin No_Dynamic],
								[Shelf_Bin No_],
								[Stock Picking],
								CONVERT(int,ISNULL((SELECT Sum(s12) 
											FROM [INDUSTRIAS COSMIC, S_A_U_$32$0] 
											WHERE (f8 = 'NORMAL' OR f8 = 'MATPRIMA')
											Group By bucket,f2
											HAVING (f2 = Productos.[No_]) AND (bucket = 4)), 0)) AS stock

					FROM        [INDUSTRIAS COSMIC, S_A_U_$Item] as Productos
					
					for xml auto
							)
			end

END




GO

/****** Object:  StoredProcedure [dbo].[GEN_GET_PALETROBOT]    Script Date: 11/18/2014 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_GET_PALETROBOT] 
	@Palet nVarchar(50),
	@Producto nVarchar(50),
    @Situ nVarchar(50),
	@Res xml output
AS
BEGIN
		if @Producto = ''
			begin
			set @Res = (
			
				SELECT		*,
				CONVERT(int,ISNULL((SELECT SUM([Cantidad Dec])
						FROM [INDUSTRIAS COSMIC, S_A_U_$MoviAdicional]
						WHERE ([Nº] = ZA.[Nº] and [Matrícula Palet] = @Palet and [Cantidad Dec] <> 0 and ide = ZA.ide)), 0)) AS Canti

				FROM        [INDUSTRIAS COSMIC, S_A_U_$Zona Adicional] as ZA
			
				where      ([Cód_ Situación] = @Situ AND [Matrícula Palet] = @Palet) 
				for xml auto
		
						)
			end

		if @Producto <> ''
			begin
			set @Res = (
			
				SELECT		*,
				CONVERT(int,ISNULL((SELECT SUM([Cantidad Dec])
						FROM [INDUSTRIAS COSMIC, S_A_U_$MoviAdicional]
						WHERE ([Nº] = ZA.[Nº] and [Matrícula Palet] = @Palet and [Cantidad Dec] <> 0 and ide = ZA.ide)), 0)) AS Canti

				FROM        [INDUSTRIAS COSMIC, S_A_U_$Zona Adicional] as ZA
			
				where      ([Cód_ Situación] = @Situ AND [Matrícula Palet] = @Palet AND [Nº] = @Producto) 
				for xml auto
		
						)
			end

END












GO

/****** Object:  StoredProcedure [dbo].[GEN_GET_CONFIGEXIST]    Script Date: 11/18/2014 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_GET_CONFIGEXIST] 
	@Res xml output
AS
BEGIN

	set @Res = (				
		SELECT *
		FROM [INDUSTRIAS COSMIC, S_A_U_$Inventory Setup] as ConfigExist		
		for xml auto
				)

END





GO

/****** Object:  StoredProcedure [dbo].[GEN_ERROR_TRANSACCION]    Script Date: 11/18/2014 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_ERROR_TRANSACCION] 
	@idProc varchar(50),
	@Res int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	-- Update [dbo].[INDUSTRIAS COSMIC, S_A_U_$Transacciones] set Estado = 2
		--where IdProceso = @idProc
	 Delete  from [dbo].[INDUSTRIAS COSMIC, S_A_U_$Transacciones]
		where IdProceso = @idProc

	 Delete  from [dbo].[INDUSTRIAS COSMIC, S_A_U_$Demonios]
		where Id = 'ENPROCESO' AND IdProceso = @idProc

	 Delete  from [dbo].[INDUSTRIAS COSMIC, S_A_U_$Demonios]
		where Id = 'FICHERO' AND IdProceso = @idProc

	set @Res = 1

END






GO

/****** Object:  StoredProcedure [dbo].[GEN_DEL_PALETZA]    Script Date: 11/18/2014 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GEN_DEL_PALETZA]
	@Palet nvarchar(20),
	@SituDesde nvarchar(20),
	@Prod nvarchar(20),
	@Res int output

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	declare @vCont int

	SET NOCOUNT ON;
			Delete from [INDUSTRIAS COSMIC, S_A_U_$Zona Adicional]
				where [Matrícula Palet] = @Palet and [Cód_ Situación] = @SituDesde
						AND (Nº = @Prod)
            
			set @vCont = (SELECT count([Matrícula Palet])
				   			 from [INDUSTRIAS COSMIC, S_A_U_$Zona Adicional]
							 where [Matrícula Palet] = @Palet)

			if @vCont = 0
				begin
					Delete from [INDUSTRIAS COSMIC, S_A_U_$Matrícula de Palet]
						where [Matrícula Palet] = @Palet and [Cód_ Situación] = @SituDesde
				end

	set @Res = 1
END

















GO

/****** Object:  StoredProcedure [dbo].[GEN_BAJA_TRANSACCION]    Script Date: 11/18/2014 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_BAJA_TRANSACCION] 
	@Proc varchar(50),
	@idProc varchar(50),
	@Res int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	 Delete  from [dbo].[INDUSTRIAS COSMIC, S_A_U_$Transacciones]
		where ((Proceso = @Proc) and (IdProceso = @idProc))

	set @Res = 1
END



GO

/****** Object:  StoredProcedure [dbo].[GEN_ALTA_TRANSACCION]    Script Date: 11/18/2014 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_ALTA_TRANSACCION]
	@ID as nvarchar(50),
	@Campo1 as nvarchar(100),
	@Campo2 as nvarchar(100),
	@Campo3 as nvarchar(100),
	@Campo4 as nvarchar(100),
	@Campo5 as nvarchar(100),
	@Campo6 as nvarchar(100),
	@Campo7 as nvarchar(100),
	@Campo8 as nvarchar(100),
	@Campo9 as nvarchar(100),
	@Campo10 as nvarchar(100),
	@Campo11 as nvarchar(100),
	@Campo12 as nvarchar(100),
	@Campo13 as nvarchar(100),
	@Campo14 as nvarchar(100),
	@Campo15 as nvarchar(100),
	@Campo16 as nvarchar(100),
	@Campo17 as nvarchar(100),
	@Campo18 as nvarchar(100),
	@Campo19 as nvarchar(100),
	@Campo20 as nvarchar(100),
	@Campo21 as nvarchar(100),
	@Campo22 as nvarchar(100),
	@Campo23 as nvarchar(100),
	@Campo24 as nvarchar(100),
	@Campo25 as nvarchar(100),
	@Campo26 as nvarchar(100),
	@Campo27 as nvarchar(100),
	@Campo28 as nvarchar(100),
	@Campo29 as nvarchar(100),
	@Campo30 as nvarchar(100),

	@IdProc varchar(100),	
	@Res int output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	insert into dbo.[INDUSTRIAS COSMIC, S_A_U_$Transacciones](Proceso,Campo1,
               Campo2,Campo3,Campo4,Campo5,Campo6,Campo7,Campo8,Campo9,Campo10
			  ,Campo11,Campo12,Campo13,Campo14,Campo15,Campo16,Campo17,Campo18,Campo19,Campo20
			  ,Campo21,Campo22,Campo23,Campo24,Campo25,Campo26,Campo27,Campo28,Campo29,Campo30,IdProceso,Estado)
					values(@ID,@Campo1,@Campo2,@Campo3,@Campo4,@Campo5,@Campo6,@Campo7,@Campo8,@Campo9,
							@Campo10,@Campo11,@Campo12,@Campo13,@Campo14,@Campo15,@Campo16,@Campo17,
							@Campo18,@Campo19,@Campo20,@Campo21,@Campo22,@Campo23,@Campo24,
							@Campo25,@Campo26,@Campo27,@Campo28,@Campo29,@Campo30,@IdProc,0)

	set @Res=1
END








GO

/****** Object:  StoredProcedure [dbo].[GEN_ALTA_RESPUESTAS_ROBOT]    Script Date: 11/18/2014 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO











-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_ALTA_RESPUESTAS_ROBOT]
	@Fichero as nvarchar(30),
	@Proceso as nvarchar(10),
	@IdProceso as nvarchar(20),
	@Tipo as nvarchar(10),
	@Campo1 as nvarchar(80),
	@Campo2 as nvarchar(80),
	@Campo3 as nvarchar(80),
	@Campo4 as nvarchar(80),
	@Campo5 as nvarchar(80),
	@Campo6 as nvarchar(80),
	@Campo7 as nvarchar(80),
	@Campo8 as nvarchar(80),
	@Campo9 as nvarchar(80),
	@Campo10 as nvarchar(80),
	@Campo11 as nvarchar(80),
	@Campo12 as nvarchar(80),
	@Campo13 as nvarchar(80),
	@Campo14 as nvarchar(80),
	@Campo15 as nvarchar(80),
	@Campo16 as nvarchar(80),
	@Campo17 as nvarchar(80),
	@Campo18 as nvarchar(80),
	@Campo19 as nvarchar(80),
	@Campo20 as nvarchar(80),
	@Campo21 as nvarchar(80),
	@Campo22 as nvarchar(80),
	@Campo23 as nvarchar(80),
	@Campo24 as nvarchar(80),
	@Campo25 as nvarchar(80),
	@Campo26 as nvarchar(80),
	@Campo27 as nvarchar(80),
	@Campo28 as nvarchar(80),
	@Campo29 as nvarchar(80),
	@Campo30 as nvarchar(80),
	@Campo31 as nvarchar(80),
	@Campo32 as nvarchar(80),
	@Campo33 as nvarchar(80),
	@Campo34 as nvarchar(80),
	@Campo35 as nvarchar(80),
	@Campo36 as nvarchar(80),
	@Campo37 as nvarchar(80),
	@Campo38 as nvarchar(80),
	@Campo39 as nvarchar(80),
	@Campo40 as nvarchar(80),
	@Res int output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    declare @vFecha varchar(150)
    set @vFecha = convert(varchar,datepart(day,GETDATE())) + '/' + convert(varchar,datepart(month,GETDATE())) + '/' + convert(varchar,datepart(year,GETDATE())) + ' 0:00:00'
	insert into dbo.[INDUSTRIAS COSMIC, S_A_U_$Respuestas Robot](Fichero,Proceso,IdProceso,Tipo,Fecha,Campo1,
               Campo2,Campo3,Campo4,Campo5,Campo6,Campo7,Campo8,Campo9,Campo10
			  ,Campo11,Campo12,Campo13,Campo14,Campo15,Campo16,Campo17,Campo18,Campo19,Campo20
			  ,Campo21,Campo22,Campo23,Campo24,Campo25,Campo26,Campo27,Campo28,Campo29,Campo30
			  ,Campo31,Campo32,Campo33,Campo34,Campo35,Campo36,Campo37,Campo38,Campo39,Campo40)
					values(@Fichero,@Proceso,@IdProceso,@Tipo,@vFecha,@Campo1,@Campo2,@Campo3,@Campo4,@Campo5,@Campo6,@Campo7,@Campo8,@Campo9,
							@Campo10,@Campo11,@Campo12,@Campo13,@Campo14,@Campo15,@Campo16,@Campo17,
							@Campo18,@Campo19,@Campo20,@Campo21,@Campo22,@Campo23,@Campo24,
							@Campo25,@Campo26,@Campo27,@Campo28,@Campo29,@Campo30,
							@Campo31,@Campo32,@Campo33,@Campo34,@Campo35,@Campo36,
							@Campo37,@Campo38,@Campo39,@Campo40)

	set @Res=1
END











GO

/****** Object:  StoredProcedure [dbo].[GEN_ALTA_MOVIMAT]    Script Date: 11/18/2014 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO











-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_ALTA_MOVIMAT]
	@TipoMov as int,
	@Palet as nvarchar(10),
	@CodSitu as nvarchar(10),
	@FechaReg as nvarchar(20),
	@Nota as nvarchar(30),
	@Usuario as nvarchar(20),
	@Hora as nvarchar(20),
	@FechaMov as nvarchar(20),
	@Almacen as nvarchar(20),
	@TipoPalet as int,
	@Res int output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    declare @vFechaMov varchar(20)
    declare @vHora varchar(20)

    set @vFechaMov = convert(varchar,datepart(day,GETDATE())) + '/' + convert(varchar,datepart(month,GETDATE())) + '/' + convert(varchar,datepart(year,GETDATE())) + ' 0:00:00'
    set @vHora = '01/01/1754 ' + convert(varchar,datepart(hh,GETDATE())) + ':' + convert(varchar,datepart(n,GETDATE())) + ':' + convert(varchar,datepart(s,GETDATE()))

	insert into dbo.[INDUSTRIAS COSMIC, S_A_U_$MoviMat]([Tipo Movimiento],[Matrícula Palet],
               [Fecha Movimiento],[Hora],[Cód_ Situación],[Fecha Reg_ Palet],[Nota],[Usuario]
			  ,[Código Almacén],[Tipo Palet])
					values(@TipoMov,@Palet,@vFechaMov,@vHora,@CodSitu,
							@FechaReg,@Nota,@Usuario,@Almacen,@TipoPalet)

	set @Res=1
END











GO

/****** Object:  StoredProcedure [dbo].[GEN_ALTA_AVISOROCA]    Script Date: 11/18/2014 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GEN_ALTA_AVISOROCA]
	@Fecha  nvarchar(20),
	@Interface nvarchar(30),
	@Direccion  int,
	@Producto  nvarchar(20),
	@Obs  nvarchar(200),
	@Tipo int,
	@Documento  nvarchar(20),
    @Fichero as varchar(200),
	@Linea as varchar(10),
	@Res int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @Iden as int
	declare @Estado as int
    declare @Comentario as varchar(150)

	set @Iden = CONVERT(int,ISNULL((Select top(1) [Ide] 
								   From dbo.[INDUSTRIAS COSMIC, S_A_U_$Roca Avisos]
								   ORDER by [Ide] desc),0))
--	set @Fichero = ''
--	set @Linea = ''
	set @Estado = 0
	set @Comentario = ''


	set @Iden = @Iden + 1
	
--CONVERT(DATETIME, @Fecha, 102)
	insert into dbo.[INDUSTRIAS COSMIC, S_A_U_$Roca Avisos](Ide,Fecha,
               Interfase,[Dirección],[Ref_ Producto],Observaciones,Tipo,
				[Nº Documento],[Fichero],[Linea],[Estado],[Comentarios])
					values(@Iden,@Fecha,@Interface,@Direccion,@Producto,@Obs,
							@Tipo,@Documento,@Fichero,@Linea,@Estado,@Comentario)

	set @Res=@Iden
END













GO

/****** Object:  StoredProcedure [dbo].[DEM_TRA_VERIF]    Script Date: 11/18/2014 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DEM_TRA_VERIF]
	@idProc varchar(40),
	@Res int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from [dbo].[INDUSTRIAS COSMIC, S_A_U_$Demonios]
	where Id = 'ENPROCESO' AND IdProceso = @idProc
	
	set @Res = @@Rowcount

END






GO

/****** Object:  StoredProcedure [dbo].[DEM_TRA_PEDVTA]    Script Date: 11/18/2014 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DEM_TRA_PEDVTA] 
	@Res xml output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

set @Res = (	

	select [No_] as Num ,[Sell-to Customer No_] as CodCli,convert(varchar,datepart(day,[Order Date])) + '/' + convert(varchar,datepart(month,[Order Date])) + '/' + convert(varchar,datepart(year,[Order Date]))  as Fecha 

	from [dbo].[INDUSTRIAS COSMIC, S_A_U_$Sales Header] as CabPed
		where (CabPed.[Document Type] = 1) and (Marca = 1)	
		for xml auto
			)

END














GO

/****** Object:  StoredProcedure [dbo].[SWEB_ALTA_LINPED]    Script Date: 11/18/2014 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[SWEB_ALTA_LINPED]
	@Comercial as varchar(20),
	@NomComercial as varchar(60),
	@Cliente as varchar(20),
	@NomCliente as varchar(60),
	@Estado as varchar(20),
	@Pedido as varchar(20),
	@Producto as varchar(20),
	@Descripcion as varchar(60),
	@Cantidad decimal(18,0),
	@Precio decimal(18,2),
	@Total decimal(18,2),
	@EnvNom as varchar(60),
	@EnvDir as varchar(60),
	@EnvPob as varchar(60),
	@EnvProv as varchar(60),
	@EnvPais as varchar(60),
	@Res varchar(20) output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    declare @vFechaMov varchar(20)
    declare @vHora varchar(20)
	declare @Ped varchar(20)
	Declare @UltNum Varchar(20)
	Declare @Line int
	Declare @NewNum varchar(20)
	Declare @Serie Varchar(20)
	Declare @LinPed int	
	Declare @Dto decimal(18,2)
	Declare @Tarifa varchar(20)
	Declare @DtoCli varchar(20)
	Declare @DtoFac varchar(20)
	Declare @CodDtoProd varchar(20)
	Declare @PorDtoCli decimal(18,2)
	Declare @PorDtoFac decimal(18,2)
	Declare @IDto decimal(18,2)
	Declare @TDto decimal(18,2)
	Declare @Pvp decimal(18,2)
	Declare @GrIvaCli varchar(20)
	Declare @GrIvaProd varchar(20)
	Declare @PorIva decimal(18,2)



    set @vFechaMov = convert(varchar,datepart(day,GETDATE())) + '/' + convert(varchar,datepart(month,GETDATE())) + '/' + convert(varchar,datepart(year,GETDATE())) + ' 0:00:00'
    set @vHora = '01/01/1754 ' + convert(varchar,datepart(hh,GETDATE())) + ':' + convert(varchar,datepart(n,GETDATE())) + ':' + convert(varchar,datepart(s,GETDATE()))
	set @Ped=@Pedido
	set @Serie='PEDWEB'
	set @LinPed = 0	
	
	if @Ped <> ''
		begin
			set @LinPed = isnull((Select top(1) Linea from dbo.PedidosWeb
						Where Comercial = @Comercial 
						  and Cliente = @Cliente
						  and Pedido = @Ped
						  and Estado = 'Alta' order by Linea Desc),0)
			
		end
	
	if @Ped = ''
		begin
			set @Ped = isnull((Select top(1) Pedido from dbo.PedidosWeb
						Where Comercial = @Comercial 
						  and Cliente = @Cliente
						  and Estado = 'Alta'),'')
			set @LinPed = isnull((Select top(1) Linea from dbo.PedidosWeb
						Where Comercial = @Comercial 
						  and Cliente = @Cliente
						  and Estado = 'Alta' order by Linea Desc),0)
			
		end

	if @Ped =''
		begin
			set @UltNum = (
				Select Top(1) [Last No_ Used] from [INDUSTRIAS COSMIC, S_A_U_$No_ Series Line]
					where [Series Code] = @Serie 
					order by [Line No_] desc
						   )
			set @Line = (
				Select Top(1) [Line No_] from [INDUSTRIAS COSMIC, S_A_U_$No_ Series Line]
					where [Series Code] = @Serie 
					order by [Line No_] desc
						   )
		    

			set @NewNum = dbo.fncIncNumSer(@UltNum)
			Update [INDUSTRIAS COSMIC, S_A_U_$No_ Series Line] set [Last No_ Used] = @NewNum
				where (([Series Code] = @Serie)  and ([Line No_] = @Line))

			set @Ped = @NewNum
		end
	set @LinPed = @LinPed + 10000	

	--Cursor de Tabla de Clientes
	Declare cCli Cursor for
		SELECT [Customer Price Group],[Customer Disc_ Group],[Invoice Disc_ Code],
				[VAT Bus_ Posting Group]
		FROM dbo.[INDUSTRIAS COSMIC, S_A_U_$Customer]
		where  [No_]= @Cliente

	Open cCli
	
	set @Tarifa = ''
	set @DtoCli =''
	set @DtoFac = '0'
	set @GrIvaCli ='18'
	Fetch Next From cCli
		Into @Tarifa,@DtoCli,@DtoFac,@GrIvaCli
	
	
	Deallocate cCli
	--Fin del cursor de Referencias

	set @CodDtoProd = (Select [Item Disc_ Group]
						From dbo.[INDUSTRIAS COSMIC, S_A_U_$Item]
						Where [No_] = @Producto)

	set @GrIvaProd = (Select [VAT Prod_ Posting Group]
						From dbo.[INDUSTRIAS COSMIC, S_A_U_$Item]
						Where [No_] = @Producto)


	set @Pvp = isnull((Select top(1) [Unit Price]
					from dbo.[INDUSTRIAS COSMIC, S_A_U_$Sales Price]
					Where [Sales Type] = 1 and [Item No_] = @Producto
							and [Sales Code] = @Tarifa),0)
	
	set @PorIva = isnull((Select [VAT %]
					From dbo.[INDUSTRIAS COSMIC, S_A_U_$VAT Posting Setup]
					Where [VAT Bus_ Posting Group] = @GrIvaCli
							and [VAT Prod_ Posting Group] = @GrIvaProd),0)


	set @PorDtoCli = (Select [Line Discount %]
						From dbo.[INDUSTRIAS COSMIC, S_A_U_$Sales Line Discount]
						Where [Type] = 1 and [Code] = @CodDtoProd
										 and [Sales Type] = 1
										 and [Sales Code] = @DtoCli)

	set @PorDtoFac = isnull((Select top(1) [Discount %]	
						From dbo.[INDUSTRIAS COSMIC, S_A_U_$Cust_ Invoice Disc_]
						Where [Code] = @DtoFac),0)
	Set @Precio = @Pvp

	Set @IDto = 0
	if @PorDtoCli <> 0
		begin
			set @IDto = (@PorDtoCli * @Precio) / 100
		end
	set @Precio = @Precio - @IDto

	Set @IDto = 0
	if @PorDtoFac <> 0
		begin
			set @IDto = (@PorDtoFac * @Precio) / 100
		end
	set @Precio = @Precio - @IDto
	
	set @Dto = @Pvp - @Precio
	
	set @Total = @Precio * @Cantidad

	insert into PedidosWeb Values(@Comercial,@NomComercial,@Cliente,@NomCliente
									,@Estado,@Ped,@LinPed,@Producto,@Descripcion
									,@Cantidad,@Pvp,@Dto,@Total,@PorIva,@EnvNom
									,@EnvDir,@EnvPob,@EnvProv,@EnvPais)


	set @Res=@Ped
END















GO

/****** Object:  StoredProcedure [dbo].[GEN_GET_MATRICULAPALET]    Script Date: 11/18/2014 20:25:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GEN_GET_MATRICULAPALET] 
	@Palet nVarchar(50)
AS
BEGIN
		SELECT Matricula.[Matrícula Palet], Matricula.[Cód_ Situación] as Situ, Matricula.[Fecha Registro Palet],
			   Matricula.Usuario, Matricula.[Descripción Palet], 
  			   Matricula.Tipo, Matricula.Largo, Matricula.Ancho, Matricula.Alto, 
			   Matricula.[Capacidad Utilizada], Matricula.[Hora Registro Palet], Matricula.[Tipo Palet], 
			   Matricula.Desactivar, Matricula.[Control Stock], Matricula.[Nº Impresiones], 
			   Matricula.[Almacén físico], Matricula.[Nº EP], 
			   Mapa.[Manipulación Matrícula] AS Manipula, '' AS Pedido, '' AS TipoRef
		FROM   [INDUSTRIAS COSMIC, S_A_U_$Matrícula de Palet] AS Matricula INNER JOIN
				[INDUSTRIAS COSMIC, S_A_U_$Mapa almacén] AS Mapa ON 
				Matricula.[Cód_ Situación] = Mapa.[Cód_ Situación]
		where (Matricula.[Matrícula Palet] = @Palet)	
	

END
















GO

/****** Object:  StoredProcedure [dbo].[DEM_TRA_LINVTA]    Script Date: 11/18/2014 20:25:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DEM_TRA_LINVTA] 
	@Res xml output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

set @Res = (	

	select 	[Document No_] as Num ,
			[Sell-to Customer No_] as CodCli,
			[Line No_] as Linea,
			[No_] as Producto,
			convert(varchar,datepart(day,[Shipment Date])) + '/' + convert(varchar,datepart(month,[Shipment Date])) + '/' + convert(varchar,datepart(year,[Shipment Date]))  as Fecha,
			[Outstanding Quantity] as CanPen,
			[Outstanding Qty_ (Base)] as CanBase,
			[Qty_ to Ship] as CanEnv,
			[Type] as Tipo,
			[Location Code] as Almacen,
			[Outstanding Amount] as ImpPen,
			[Description] as Descripcion

	from [dbo].[INDUSTRIAS COSMIC, S_A_U_$Sales Line] as LinPed
		where (LinPed.[Document Type] = 1) and (Marca = 1)	
		for xml auto
			)

END






GO

/****** Object:  StoredProcedure [dbo].[DEM_TRA_INIFIN]    Script Date: 11/18/2014 20:25:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DEM_TRA_INIFIN] 
	@idProc varchar(40),
	@IdP varchar(150),
	@IniFin varchar(20),
	@Res varchar(150) output


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @IdProceso varchar(150)
	set @IdProceso = @IdP
    if @IdP = ''
		begin
			set @IdProceso = Newid()
		end

	Insert Into [dbo].[INDUSTRIAS COSMIC, S_A_U_$Transacciones](Proceso,Campo1,
               Campo2,Campo3,Campo4,Campo5,Campo6,Campo7,Campo8,Campo9,Campo10
			  ,Campo11,Campo12,Campo13,Campo14,Campo15,Campo16,Campo17,Campo18,Campo19,Campo20
			  ,Campo21,Campo22,Campo23,Campo24,Campo25,Campo26,Campo27,Campo28,Campo29,Campo30,IdProceso,Estado)
			Values(@idProc,@IniFin,'','','','','','','','','','','','','','','','','','','','','','','',
								   '','','','','','',@IdProceso,0)

	IF @IniFin = 'FIN'
		begin
			Insert Into [dbo].[INDUSTRIAS COSMIC, S_A_U_$Demonios](Id,IdProceso,Proceso,Cantidad)
				values('ENPROCESO',@IdProceso,@idProc,0)
			
		end

	set @Res = @IdProceso

END












GO

/****** Object:  StoredProcedure [dbo].[DEM_ROCA_STOCKI03]    Script Date: 11/18/2014 20:25:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DEM_ROCA_STOCKI03]
	@Almacen nvarchar(50),
	@Fecha nvarchar(20),
	@NunMov int,
	@UltNunMov int,
	@Tipo nvarchar(10),
	@Res xml output
AS
BEGIN
	set @Res = (
		
			SELECT	Productos.No_, 
			        Productos.Description,
					Productos.[Nombre colección],
					@Tipo as Tipo,
					
					CONVERT(int,ISNULL((SELECT SUM(Quantity)
                            FROM [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry]
                            WHERE ([Item No_] = Productos.No_ and [Location Code] = @Almacen)), 0)) AS stock,
					
					CONVERT(int,ISNULL((SELECT SUM(Cantidad)
							FROM [INDUSTRIAS COSMIC, S_A_U_$OEA Lineas]
							WHERE ([Nº] = Productos.No_ AND ([Situación Línea] != 3) 
							AND [Código Almacén] = @Almacen)),0)) as Expedir,
					
					CONVERT(int,ISNULL((SELECT SUM(LinOEA.Cantidad)
							FROM [INDUSTRIAS COSMIC, S_A_U_$OEA Cabecera] AS CabOEA INNER JOIN
							[INDUSTRIAS COSMIC, S_A_U_$OEA Lineas] AS LinOEA ON CabOEA.OEA = LinOEA.OEA
							WHERE ((CabOEA.Situación = 3) AND (CabOEA.[Fecha Salida] < CONVERT(DATETIME, '1800-01-01 00:00:00', 102)) 
							AND (LinOEA.Nº = Productos.No_ ) 
							AND (LinOEA.[Código Almacén] = @Almacen))),0)) AS [Exp],

					CONVERT(int,ISNULL((SELECT SUM(LinOEA.Cantidad)
							FROM [INDUSTRIAS COSMIC, S_A_U_$OEA Cabecera] AS CabOEA INNER JOIN
							[INDUSTRIAS COSMIC, S_A_U_$OEA Lineas] AS LinOEA ON CabOEA.OEA = LinOEA.OEA
							WHERE ((CabOEA.Situación = 3) AND (CabOEA.[Fecha Salida] = CONVERT(DATETIME, @Fecha, 102)) 
							AND (LinOEA.Nº = Productos.No_ ) 
							AND (LinOEA.[Código Almacén] = @Almacen))),0)) AS ExpFs,

					CONVERT(int,ISNULL((SELECT SUM(Quantity)
							FROM [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry] AS tMov
							WHERE ([Entry Type] >= 2) AND ([Entry No_] >= @NunMov ) AND ([Entry No_] <= @UltNunMov )   
							AND ([Document No_] LIKE 'FAB%') 
							AND ([Entry Type] <= 4) 
							AND ([Item No_] = Productos.No_ ) 
							AND ([Posting Date] = CONVERT(DATETIME, @Fecha, 102)) 
							AND ([Location Code] = @Almacen)),0)) as Fabrica,

					CONVERT(int,ISNULL((SELECT SUM(Quantity)
							FROM [INDUSTRIAS COSMIC, S_A_U_$Item Ledger Entry] AS tMov
							WHERE ([Entry Type] >= 2) AND ([Entry No_] >= @NunMov)  and ([Entry No_] <= @UltNunMov )
							AND ([Document No_] NOT LIKE 'FAB%') 
							AND ([Entry Type] <= 4) 
							AND ([Item No_] = Productos.No_ ) 
							AND ([Posting Date] = CONVERT(DATETIME, @Fecha, 102)) 
							AND ([Location Code] = @Almacen)),0)) as Otros

			
			FROM        [INDUSTRIAS COSMIC, S_A_U_$Item] as Productos
			WHERE		[Roca Centro Codificador] = 'A'
			ORDER BY Productos.No_
		 
			for xml auto
	
					)
END








GO

/****** Object:  StoredProcedure [dbo].[DEM_ROCA_PRODUCTO]    Script Date: 11/18/2014 20:25:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DEM_ROCA_PRODUCTO]
	@ID nvarchar(20),
	@Cod nvarchar(20),
	@Des nvarchar(20),
	@CB nvarchar(20),
	@Tipo int,
	@BUM nvarchar(20),
	@PxBolsa int,
	@BxCaja int,
	@CxPalet int,
	@PxNivel int,
	@PesoEmb as decimal(38,20),
	@PesoPalet as decimal(38,20),
	@VolxPieza as decimal(38,20),
	@PesoNeto as decimal(38,20),
	@CC nvarchar(20),
	@Fecha nvarchar(20),	
	@Res int output

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
			Update [INDUSTRIAS COSMIC, S_A_U_$Item]
				set [Description] = @Des,
				[Código de Barras] = @CB,
				[Base Unit of Measure] = @BUM,
				[Blocked] = 0,
				[Roca Pzs x Bolsa] = @PxBolsa,
				[Roca Bolsas x Cjas] = @BxCaja,
				[Roca Cjas x Pallet] = @CxPalet,
				[Roca Pzs por Nivel] = @PxNivel,
				[Roca Peso Embalaje] = @PesoEmb,
				[Roca Total Pallet] = @PesoPalet,
				[Roca Volumen x Pza] = @VolxPieza,
				[Net Weight] = @PesoNeto,
				[Roca Centro Codificador] = @CC,
				[Last Date Modified] = @Fecha
			where [No_] = @Cod

			Update [INDUSTRIAS COSMIC, S_A_U_$Item Unit of Measure]
				set [Weight] = [Qty_ per Unit of Measure] * @PesoNeto
			where [Item No_] = @Cod

	set @Res = 1
		
END












GO

/****** Object:  StoredProcedure [dbo].[DEM_ROCA_PARAM]    Script Date: 11/18/2014 20:25:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DEM_ROCA_PARAM] 
	@Param nvarchar(50),
	@Res xml output
AS
BEGIN
	Declare @Dato nvarchar(150)
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;

	set @Res = (	
		Select  Ruta,Departamento,Secuencia,[Fecha último envío] as Fecha,NEntry,[NEntry E5] as NEntryE5
		From [dbo].[INDUSTRIAS COSMIC, S_A_U_$ROCA Gestor Documental] as ParamRoca
		where ParamRoca.[Código] = @Param
		for xml auto	
				)



END








GO

/****** Object:  StoredProcedure [dbo].[DEM_ROCA_GRABAPARAM]    Script Date: 11/18/2014 20:25:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DEM_ROCA_GRABAPARAM]
	@Codigo nvarchar(50),
	@Campo nvarchar(50),
	@Valor nvarchar(150),
	@Res int output

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if @Campo = 'Ruta'
		begin
			Update [INDUSTRIAS COSMIC, S_A_U_$ROCA Gestor Documental]
				set Ruta = @Valor
			where [Código] = @Codigo
		end

	if @Campo = 'Departamento'
		begin
			Update [INDUSTRIAS COSMIC, S_A_U_$ROCA Gestor Documental]
				set Departamento = @Valor
			where [Código] = @Codigo
		end


	if @Campo = 'Secuencia'
		begin
			Update [INDUSTRIAS COSMIC, S_A_U_$ROCA Gestor Documental]
				set Secuencia = @Valor
			where [Código] = @Codigo
		end

	if @Campo = 'Fecha'
		begin
			Update [INDUSTRIAS COSMIC, S_A_U_$ROCA Gestor Documental]
				set [Fecha último envío] = @Valor
			where [Código] = @Codigo
		end

	if @Campo = 'NEntry'
		begin
			Update [INDUSTRIAS COSMIC, S_A_U_$ROCA Gestor Documental]
				set NEntry = @Valor
			where [Código] = @Codigo
		end

	if @Campo = 'NEntryE5'
		begin
			Update [INDUSTRIAS COSMIC, S_A_U_$ROCA Gestor Documental]
				set [NEntry E5] = @Valor
			where [Código] = @Codigo
		end

	set @Res = 1
END






GO

/****** Object:  StoredProcedure [dbo].[DEM_GESTOR_DOC]    Script Date: 11/18/2014 20:25:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DEM_GESTOR_DOC]
	@Param nvarchar(50),
	@Res xml output
AS
BEGIN
	Declare @Dato nvarchar(150)
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;

	set @Res = (	
		Select  Ruta as Valor,Departamento
		From [dbo].[INDUSTRIAS COSMIC, S_A_U_$Gestor Documental] as Gestor
		where Gestor.[Código] = @Param
		for xml auto	
				)



END



GO

/****** Object:  StoredProcedure [dbo].[SWEB_GET_COLECCIONES]    Script Date: 11/18/2014 20:25:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SWEB_GET_COLECCIONES] 
AS

SELECT	[Código] AS ID, [Colección web] AS Nombre
FROM	[INDUSTRIAS COSMIC, S_A_U_$Colecciones productos] AS ColWeb
WHERE	([Id Web] > 0)

SELECT	[Código] AS ID, [Colección web] AS Nombre
FROM	[INDUSTRIAS COSMIC, S_A_U_$Colecciones productos] AS Colecciones





GO

/****** Object:  StoredProcedure [dbo].[DEM_SET_ENPROCESO]    Script Date: 11/18/2014 20:25:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[DEM_SET_ENPROCESO]
    @IDProc varchar(50),
	@Proceso varchar(50),
	@Res varchar(50) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @Process varchar(50)
    -- Insert statements for procedure here
    insert into [dbo].[INDUSTRIAS COSMIC, S_A_U_$Demonios](Id,IdProceso,Proceso,Cantidad) values('ENPROCESO',@IDProc,@Proceso,1)

	set @Res = 'OK'

END









GO

/****** Object:  StoredProcedure [dbo].[GEN_MODIF_VOY_COMPO]    Script Date: 11/18/2014 20:25:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GEN_MODIF_VOY_COMPO]
	@Usuario varchar(20),
	@Prod varchar(20),
	@Almacen varchar(20),
	@Res int output

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		Update [INDUSTRIAS COSMIC, S_A_U_$Reponer componentes]
			set [Usuario] = @Usuario,Voy = 1
		where [No_] = @Prod and [Almacén] = @Almacen
	set @Res = 1
END















GO

/****** Object:  StoredProcedure [dbo].[GEN_MODIF_VOY_PROD]    Script Date: 11/18/2014 20:25:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GEN_MODIF_VOY_PROD]
	@Usuario varchar(20),
	@Prod varchar(20),
	@Almacen varchar(20),
	@Res int output

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		Update [INDUSTRIAS COSMIC, S_A_U_$Reponer]
			set [Usuario] = @Usuario,Voy = 1
		where [No_] = @Prod and [Almacén] = @Almacen
	set @Res = 1
END














GO

/****** Object:  StoredProcedure [dbo].[GEN_BAJA_ZONAADICIONAL]    Script Date: 11/18/2014 20:25:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[GEN_BAJA_ZONAADICIONAL]
	@Prod as varchar(20),
	@MatriculaPalet as varchar(10),
	@Res int output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Delete
	FROM [INDUSTRIAS COSMIC, S_A_U_$Zona Adicional]
	WHERE ([Matrícula Palet] = @MatriculaPalet) AND (Nº = @Prod)	

	set @Res=1
END





















GO

/****** Object:  StoredProcedure [dbo].[CMP_CREA_TABLA]    Script Date: 11/18/2014 20:25:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO











-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CMP_CREA_TABLA]
	@Periodo as nvarchar(50),
	@Tabla as nvarchar(100),
	@Res int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @vSQL as nvarchar(200)

--	set @vSQL = 'if exists (select * from dbo.sysobjects where id =
--					object_id(N''[dbo].[' + @Periodo + @Tabla + ']'') and OBJECTPROPERTY(id, N''IsUserTable'') = 1)
--					drop table [dbo].[' + @Periodo + @Tabla + ']'
--
--	--set @vSQL = 'Drop Table [' + @Periodo + @Tabla + ']'
--	exec(@vSQL)
	BEGIN TRY
			set @vSQL = 'Drop Table [' + @Periodo + @Tabla + ']'
			exec(@vSQL)
	END TRY
	BEGIN CATCH
	END CATCH

	set @vSQL = 'Select * into [' + @Periodo + @Tabla + '] From [INDUSTRIAS COSMIC, S_A_U_$' + @Tabla + ']'
    exec(@vSQL)


	set @Res=1
END

















GO

/****** Object:  StoredProcedure [dbo].[GEN_GET_NEWID]    Script Date: 11/18/2014 20:25:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[GEN_GET_NEWID] 
	@Res varchar(150) output


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @IdProceso varchar(150)
			set @IdProceso = Newid()


	set @Res = @IdProceso

END












GO

