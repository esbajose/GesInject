using System;
using System.Collections.Generic;
using System.Text;
using GesInject.Clases;

    class cConstantes
    {
        public const string DataAccessLayerType = "SQLDataAccess";
        public const string AdoConecStrCosmic = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=STD;Data Source=SPD;Connect Timeout=15;Packet Size=4096";
        public const string NaviConecStrCosmic = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Cosmic;Data Source=SPD;Connect Timeout=15;Packet Size=4096";
        public const string Cyptokey = "arFtuHGfYjcdTyuIhjHgFdR567YhFdErDFFGFDDDddDEDDFdfrtgYYhgfpOiuygtEdsqWsxxcVggyyuJmnbvdfghjuikolpAqSwDeFrGtHyJu";
  
  
        //ODBC
        //string vstrConec = "ODBC;DRIVER=SQL Server;SERVER=srv-dbc;UID=ODBCUSER;pwd=0odbcuser;APP=Microsoft Data Access Components;DATABASE=Cosmic";

        //System.Data.Odbc.OdbcConnection dbconec = new OdbcConnection();
        //dbconec.ConnectionString = vstrConec;
        //dbconec.Open();

        //dbconec.Close();
      

        
        public const char Comi = (char)34;
        public const char vbLF = (char)10;
        public const char vbCtr = (char)13;
        public const string shutdown_Reinicio = "-r";
        public const string shutdown_Apagar = "-s";
        public const string shutdown_LogOff = "-l";
        public const string shutdown_Abortar = "-a";
        public const string LDAP = "LDAP://192.168.0.10";

        //public const char vbCtrLF = vbCtr & vbLF;
        public const string Ceros = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
        //public const string[] TipoArt = { "Producto", "PV", "Pedido Especial", "Varios", "Componente" };
        //vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
        //vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
        //vSql = vSql.Replace("[?1]", cParamXml.Empresa);
        //vSql = vSql.Replace("[?2]", UpAny.Value.ToString());

        public const string CabHTMP =
                "<html xmlns='http://www.w3.org/1999/xhtml\'>" +
                "<head>" +
                "<title></title>" +
                "<style type='text/css'>" +
                "p.MsoPlainText" +
                "{margin-bottom:.0001pt;" +
                "font-size:10.5pt;" +
                "font-family:Consolas;" +
                "margin-left: 0cm;" +
                "margin-right: 0cm;" +
                "margin-top: 0cm;" +
                "}" +
                "</style>" +
                "</head>" +
                "<body>";

        public const string PieHTMP =
                "</body>" +
                "</html>";



        public const string SQL_Combos =
            "SELECT Valores, ValorID " +
            "FROM TablaOptions " +
            "WHERE (ID = '[?1]')";

        public const string SQL_Ubis_Lista =
            "SELECT Ubi " +
            "FROM GC_Ubicaciones " +
            "WHERE (Empresa = [?Emp]) ";

        public const string SQL_UP_Delete =
            "Delete From [?99] " +
            "Where  [?1]";

        public const string SQL_UP_Update =
            "Update [?99] " +
               "Set [?1] = '[?2]' " +
            "Where [?3]";


        public const string SQL_CabPedido =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_CabPedido " + "[?vbCr][?vbLf]" +
            "Where Empresa = [?Emp] " + "[?vbCr][?vbLf]" +
            "Order by Id asc " + "[?vbCr][?vbLf]";

        public const string SQL_LinPedido =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_LinPedido " + "[?vbCr][?vbLf]" +
            "Where Empresa = [?Emp] and [NumPed] = [?Ped] " + "[?vbCr][?vbLf]";

        public const string SQL_NumLinPed =
            "SELECT MAX(LinPed) AS NumLin " + "[?vbCr][?vbLf]" +
            "FROM  GC_LinPedido " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (NumPed = [?NumPed]) " + "[?vbCr][?vbLf]";


        public const string SQL_DirEntrega =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_DirEntregas " + "[?vbCr][?vbLf]" +
            "Where (Empresa = [?Emp]) and (CodCli = '[?CodCli]') " + "[?vbCr][?vbLf]" +
            "Order by Id asc " + "[?vbCr][?vbLf]";

        public const string SQL_NumId =
            "SELECT MAX(IdEntrega) AS IdEnt " + "[?vbCr][?vbLf]" +
            "FROM  GC_DirEntregas " + "[?vbCr][?vbLf]" +
            "GROUP BY Id, Empresa, CodCli " + "[?vbCr][?vbLf]" +
            "HAVING      (Empresa = [?Emp]) AND (CodCli = N'[?CodCli]') " + "[?vbCr][?vbLf]";

        public const string SQL_CabCompra =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_CabCompra " + "[?vbCr][?vbLf]" +
            "Where Empresa = [?Emp] " + "[?vbCr][?vbLf]" +
            "Order by Id asc " + "[?vbCr][?vbLf]";

        public const string SQL_LinCompra =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_LinCompra " + "[?vbCr][?vbLf]" +
            "Where Empresa = [?Emp] and [NumPed] = '[?Ped]' " + "[?vbCr][?vbLf]";

        public const string SQL_NumLinPedCompra =
            "SELECT MAX(LinPed) AS NumLin " + "[?vbCr][?vbLf]" +
            "FROM  GC_LinCompra " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (NumPed = '[?NumPed]') " + "[?vbCr][?vbLf]";


        public const string SQL_OF =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_OrdenProd " + "[?vbCr][?vbLf]" +
            "Where Empresa = [?Emp] " + "[?vbCr][?vbLf]" +
            "Order by IdOF asc " + "[?vbCr][?vbLf]";

        public const string SQL_Articulo =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_ProductoAnexos " + "[?vbCr][?vbLf]" +
            "Where Empresa = [?Emp] " + "[?vbCr][?vbLf]" +
            "Order by Id asc " + "[?vbCr][?vbLf]";


        public const string SQL_Articulo_anexos =
            "SELECT tProdA.Id, tProdA.Empresa, tProdA.Producto, tProdA.Descripción,  " + "[?vbCr][?vbLf]" +
		    "        tProdA.Color, tProdA.CodMolde, tProdA.PesoNeto, tProdA.PiezasHora,  " + "[?vbCr][?vbLf]" +
		    "        tProdA.Bolsa, tProdA.PiezasBolsa, tProdA.Caja,  " + "[?vbCr][?vbLf]" +
	        "        tProdA.PiezasCaja, tProdA.Imagen, tProdA.Documentación, tMol.Ubicación, " + "[?vbCr][?vbLf]" +
	        "        tMol.Cavidades, tMol.Fechador, tMol.Descripción AS DesMolde,  " + "[?vbCr][?vbLf]" +
	        "        tProdMat.Material, tProdMat.DesMaterial,  " + "[?vbCr][?vbLf]" +
            "        tProdMat.TipoMaterial, tProdMat.CodProv, tProdMat.NombreProv, tProdMat.Precio,tProdA.PVP,tProdA.EsMaterial, " + "[?vbCr][?vbLf]" +
            "        tProdA.PrioMaq1,tProdA.PrioMaq2,tProdA.PrioMaq3, " + "[?vbCr][?vbLf]" +
            "        tProdA.LogoCaja,tProdA.LogoBolsa " + "[?vbCr][?vbLf]" +
            "FROM GC_ProductoAnexos AS tProdA LEFT OUTER JOIN " + "[?vbCr][?vbLf]" +
            "          GC_ProductoMaterial AS tProdMat ON tProdA.Producto = tProdMat.Producto  " + "[?vbCr][?vbLf]" +
		    "		            AND tProdA.Empresa = tProdMat.Empresa LEFT OUTER JOIN " + "[?vbCr][?vbLf]" +
            "          GC_Moldes AS tMol ON tProdA.CodMolde = tMol.CodMolde  " + "[?vbCr][?vbLf]" +
			"	            AND tProdA.Empresa = tMol.Empresa " + "[?vbCr][?vbLf]" +
            "WHERE     (tProdA.Producto = N'[?CodProd]') AND (tProdA.Empresa = [?Emp]) " + "[?vbCr][?vbLf]";


        public const string SQL_OFL_Planif =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_OrdenProd " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (Estado = N'Planificada') " + "[?vbCr][?vbLf]";

        public const string SQL_OFL_Calc =
            "SELECT tMat.Material,dbo.fncProd_Stock(OFL.Empresa,tMat.Material,'[?Alm]') as Stock,dbo.fncProd_NeceEncurso([?Emp],tMat.Material) as NeceTot,0 as NeceAct " + "[?vbCr][?vbLf]" +
            "FROM GC_OrdenProd AS OFL INNER JOIN " + "[?vbCr][?vbLf]" +
            "       GC_ProductoMaterial AS tMat ON OFL.Empresa = tMat.Empresa AND OFL.Articulo = tMat.Producto " + "[?vbCr][?vbLf]" +
            "WHERE (OFL.Empresa = [?Emp]) AND (Activo = 1) " + "[?vbCr][?vbLf]";


        public const string SQL_Prod_Situ =
            "SELECT TOP (1) Id, Empresa, Almacen, Producto, Cantidad " + "[?vbCr][?vbLf]" +
            "FROM GC_Ind_ProductoCan " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (Producto = N'[?CodProd]')  AND (Almacen = N'[?Alm]') " + "[?vbCr][?vbLf]";

        public const string SQL_Prod_Mat=
            "SELECT Activo, Material, DesMaterial, TipoMaterial, CodProv, NombreProv, Precio,Peso, convert(decimal(10,2),((peso*[?Can])/1000)) as Kilos " + "[?vbCr][?vbLf]" +
            "FROM  GC_ProductoMaterial " + "[?vbCr][?vbLf]" +
            "WHERE (Producto = N'[?CodProd]') AND (Empresa = [?Emp]) [?FilActivo] " + "[?vbCr][?vbLf]" +
            "GROUP BY Activo ,Material, DesMaterial, TipoMaterial, CodProv, NombreProv, Precio,Peso " + "[?vbCr][?vbLf]";


           //"SELECT Material, DesMaterial, TipoMaterial, CodProv, NombreProv, Precio " + "[?vbCr][?vbLf]" +
           // "FROM  GC_ProductoMaterial " + "[?vbCr][?vbLf]" +
           // "WHERE (Producto = N'[?CodProd]') AND (Empresa = [?Emp]) " + "[?vbCr][?vbLf]" +
           // "GROUP BY Material, DesMaterial, TipoMaterial, CodProv, NombreProv, Precio " + "[?vbCr][?vbLf]";


                //decimal vKilos = (vdPeso * vof.Cantidad)/1000;
                //txKilos.Text = string.Format("{0:n2}", vKilos) + " kg";


        public const string SQL_Prod_Anex_Var=
            "SELECT TOP (1) [?CAmpo] " + "[?vbCr][?vbLf]" +
            "FROM GC_ProductoAnexos " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (Producto = N'[?CodProd]') " + "[?vbCr][?vbLf]";

        public const string SQL_OFL_Alta_Compo=
            "Insert into GC_OrdenProdCompo " + "[?vbCr][?vbLf]" +
            "SELECT GC_OrdenProd.Empresa, 'Lanzada' AS Estado, GC_OrdenProd.IdOF, GC_OrdenProd.Articulo,  " + "[?vbCr][?vbLf]" +
            "       GC_ProductoMaterial.Material AS Compo, [?CanPor] AS CantidadPor,GC_OrdenProd.Cantidad AS CantidadProd,  " + "[?vbCr][?vbLf]" +
            "        GC_OrdenProd.Cantidad * [?CanPor] / 1000 AS CantidadPen, '[?Alm]' AS Almacen " + "[?vbCr][?vbLf]" +
            "FROM GC_OrdenProd INNER JOIN " + "[?vbCr][?vbLf]" +
            "         GC_ProductoMaterial ON GC_OrdenProd.Empresa = GC_ProductoMaterial.Empresa  " + "[?vbCr][?vbLf]" +
            "                    AND GC_OrdenProd.Articulo = GC_ProductoMaterial.Producto " + "[?vbCr][?vbLf]" +
            "WHERE (GC_OrdenProd.Empresa = [?Emp]) AND (GC_OrdenProd.IdOF = N'[?OFL]') " + "[?vbCr][?vbLf]";

        public const string SQL_OFL_Imp=
            "SELECT distinct  OFL.IdOF, OFL.Fecha,tCliProd.CodCli, " + "[?vbCr][?vbLf]" + 
		    "                (SELECT TOP (1) NomCli " + "[?vbCr][?vbLf]" +
			"                    FROM GC_ClienteProducto " + "[?vbCr][?vbLf]" +
            "                    WHERE (CodCli = tCliProd.CodCli)) as NomCli,  " + "[?vbCr][?vbLf]" +           
            "        OFL.Articulo, OFL.Descripción, OFL.ArticuloCli, " + "[?vbCr][?vbLf]" +
            "        OFL.Cantidad, OFL.FechaEntrega, tProdMat.Material, tProdMat.DesMaterial, tProdMat.TipoMaterial, " + "[?vbCr][?vbLf]" +
            "        tPAnex.PesoNeto, tPAnex.PiezasHora, tPAnex.Bolsa, tPAnex.PiezasBolsa, tPAnex.Caja, tPAnex.PiezasCaja, " + "[?vbCr][?vbLf]" +
            "        '' as Imagen, tPAnex.CodMolde,tMoldes.Cavidades, tMoldes.Ubicación,'' as PathImagen " + "[?vbCr][?vbLf]" +
            "FROM GC_ProductoAnexos AS tPAnex RIGHT OUTER JOIN " + "[?vbCr][?vbLf]" +
            "        GC_OrdenProd AS OFL LEFT OUTER JOIN " + "[?vbCr][?vbLf]" +
            "        GC_ClienteProducto AS tCliProd ON OFL.Empresa = tCliProd.Empresa AND OFL.CodCli = tCliProd.CodCli LEFT OUTER JOIN " + "[?vbCr][?vbLf]" +
            "        GC_ProductoMaterial AS tProdMat ON OFL.Empresa = tProdMat.Empresa AND OFL.Articulo = tProdMat.Producto ON tPAnex.Producto = OFL.Articulo AND " + "[?vbCr][?vbLf]" + 
            "        tPAnex.Empresa = OFL.Empresa LEFT OUTER JOIN " + "[?vbCr][?vbLf]" +
            "        GC_Moldes AS tMoldes ON tPAnex.Empresa = tMoldes.Empresa AND tPAnex.CodMolde = tMoldes.CodMolde " + "[?vbCr][?vbLf]" +
            "WHERE (OFL.Empresa = [?Emp]) AND (OFL.IdOF = N'[?OFL]') AND (tProdMat.Activo = 1) " + "[?vbCr][?vbLf]";

            //"FROM GC_OrdenProd AS OFL LEFT OUTER JOIN " + "[?vbCr][?vbLf]" +
            //"         GC_Moldes AS tMoldes ON OFL.Empresa = tMoldes.Empresa LEFT OUTER JOIN " + "[?vbCr][?vbLf]" +
            //"         GC_ClienteProducto AS tCliProd ON OFL.Empresa = tCliProd.Empresa AND OFL.CodCli = tCliProd.CodCli LEFT OUTER JOIN " + "[?vbCr][?vbLf]" +
            //"         GC_ProductoMaterial AS tProdMat ON OFL.Empresa = tProdMat.Empresa AND OFL.Articulo = tProdMat.Producto RIGHT OUTER JOIN " + "[?vbCr][?vbLf]" +
            //"         GC_ProductoAnexos AS tPAnex ON tMoldes.CodMolde = tPAnex.CodMolde AND OFL.Articulo = tPAnex.Producto AND OFL.Empresa = tPAnex.Empresa " + "[?vbCr][?vbLf]" +



        public const string SQL_OFL_EnProd_Lista =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_EnProducción " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (idOF = N'[?OFL]') " + "[?vbCr][?vbLf]";

        public const string SQL_OFL_Cajas_Lista =
            "SELECT  * " + "[?vbCr][?vbLf]" +
		    "        ,case when Tipo='C' then CanProd " + "[?vbCr][?vbLf]" +
			"            when Tipo = 'B' then " + "[?vbCr][?vbLf]" +
			"            isnull((SELECT top(1) 0 " + "[?vbCr][?vbLf]" +
		    "  	            FROM  GC_OrdenProdCajas " + "[?vbCr][?vbLf]" +
		    "	            WHERE (Empresa = OC.Empresa)  " + "[?vbCr][?vbLf]" +
		    "		            AND (IdOF = OC.IdOF) " + "[?vbCr][?vbLf]" +
		    "		            and Tipo = 'C' " + "[?vbCr][?vbLf]" +
		    "		            and Codigo = SUBSTRING(OC.Codigo,0,CHARINDEX('.',OC.Codigo,0)) " + "[?vbCr][?vbLf]" +
		    "	            ),OC.CanProd)" + "[?vbCr][?vbLf]" +
		    "          end as CantidadProd " + "[?vbCr][?vbLf]" +
            "FROM  GC_OrdenProdCajas as OC " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (idOF = N'[?OFL]') " + "[?vbCr][?vbLf]" +
            "Order by Fecha desc " + "[?vbCr][?vbLf]";

        public const string SQL_OFL_Bolsas_Lista =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_OrdenProdCajas " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (idOF = N'[?OFL]')  AND (Codigo LIKE N'[?Caja].%') " + "[?vbCr][?vbLf]";


        public const string SQL_OFL_Coment_Lista =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_OrdenProdComenProduc " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (idOF = N'[?OFL]') " + "[?vbCr][?vbLf]";

        public const string SQL_OFL_Verif_Lista =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_OrdenProdVerif " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (idOF = N'[?OFL]') " + "[?vbCr][?vbLf]";

        public const string SQL_OrdenProd_Update_CanFac =
            "Update GC_OrdenProd " +
               "Set CantidadFab = CantidadFab + '[?2]' " +
            "Where [?3]";

        public const string SQL_OrdenProd_Update_Can =
            "Update GC_OrdenProd " +
               "Set Cantidad = '[?2]' " +
            "Where [?3]";


        public const string SQL_OF_FinJornada =
            "UPDATE GC_EnProducción " + "[?vbCr][?vbLf]" +
            "SET IdOper = N'', NombreOper = N'' " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (IdOper = N'[?Oper]') " + "[?vbCr][?vbLf]";

        public const string SQL_OF_Cerrar_CajaBolsas =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_OrdenProdCajas " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (IdOF = N'[?OFL]') AND (Codigo LIKE N'[?Caja].%')  AND (Tipo = 'B')" + "[?vbCr][?vbLf] ";

        public const string SQL_OF_Graba_CajaBolsas =
            "Update GC_OrdenProdCajas " + "[?vbCr][?vbLf]" +
            "set Caja = [?Caja] " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (IdOF = N'[?OFL]') AND (Caja = N'')  AND (Tipo = 'B') " + "[?vbCr][?vbLf]";

        public const string SQL_OF_ProducLista =
            "SELECT GC_OrdenProd.Id, GC_OrdenProd.Empresa, GC_OrdenProd.IdOF, GC_OrdenProd.Fecha, GC_OrdenProd.Estado, " + "[?vbCr][?vbLf]" +
            "        isnull(GC_EnProducción.NombreOper,'') AS Operario,  " + "[?vbCr][?vbLf]" +
            "        isnull(GC_EnProducción.DesMaquina,'') AS Maquina, GC_OrdenProd.CodCli, GC_OrdenProd.Articulo, " + "[?vbCr][?vbLf]" +
            "        GC_OrdenProd.Descripción, " + "[?vbCr][?vbLf]" +
            "        --GC_ProductoMaterial.Material,GC_ProductoMaterial.DesMaterial, " + "[?vbCr][?vbLf]" +
            "        GC_OrdenProd.ArticuloCli, GC_OrdenProd.Cantidad, GC_OrdenProd.CantidadFab,(GC_OrdenProd.Cantidad - GC_OrdenProd.CantidadFab) as CanPend, GC_OrdenProd.Lote, " + "[?vbCr][?vbLf]" + 
            "        GC_OrdenProd.FechaEntrega, GC_OrdenProd.FechaInicio, GC_OrdenProd.FechaFin" + "[?vbCr][?vbLf]" +
            "FROM GC_OrdenProd LEFT OUTER JOIN " + "[?vbCr][?vbLf]" +
            "       --GC_ProductoMaterial ON GC_OrdenProd.Empresa = GC_ProductoMaterial.Empresa AND GC_OrdenProd.Articulo = GC_ProductoMaterial.Producto LEFT OUTER JOIN " + "[?vbCr][?vbLf]" +
            "       GC_EnProducción ON GC_OrdenProd.Empresa = GC_EnProducción.Empresa AND GC_OrdenProd.IdOF = GC_EnProducción.idOF " + "[?vbCr][?vbLf]" +
            " where GC_OrdenProd.Empresa = [?Emp] and (GC_OrdenProd.Estado = 'Lanzada' or GC_OrdenProd.Estado = 'Producción') and (GC_OrdenProd.Cantidad - GC_OrdenProd.CantidadFab) > 0 " + "[?vbCr][?vbLf]" +
            "ORDER BY MAQUINA DESC " + "[?vbCr][?vbLf]";

        public const string SQL_OF_ImpLista =
            "SELECT GC_OrdenProd.Id, GC_OrdenProd.Empresa, GC_OrdenProd.IdOF, GC_OrdenProd.Fecha, GC_OrdenProd.Estado, " + "[?vbCr][?vbLf]" +
            "        isnull(GC_EnProducción.NombreOper,'') AS Operario,  " + "[?vbCr][?vbLf]" +
            "        isnull(GC_EnProducción.DesMaquina,'') AS Maquina, GC_OrdenProd.CodCli, GC_OrdenProd.Articulo, " + "[?vbCr][?vbLf]" +
            "        GC_OrdenProd.Descripción, " + "[?vbCr][?vbLf]" +
            "        GC_ProductoMaterial.Material,GC_ProductoMaterial.DesMaterial, " + "[?vbCr][?vbLf]" +
            "        GC_OrdenProd.ArticuloCli, GC_OrdenProd.Cantidad, GC_OrdenProd.Lote, " + "[?vbCr][?vbLf]" +
            "        GC_OrdenProd.FechaEntrega, GC_OrdenProd.FechaInicio, GC_OrdenProd.FechaFin, GC_OrdenProd.CantidadFab, GC_ProductoAnexos.CodMolde " + "[?vbCr][?vbLf]" +
            "FROM GC_OrdenProd LEFT OUTER JOIN " + "[?vbCr][?vbLf]" +
            "       GC_ProductoAnexos ON GC_OrdenProd.Articulo = GC_ProductoAnexos.Producto AND GC_OrdenProd.Empresa = GC_ProductoAnexos.Empresa LEFT OUTER JOIN " + "[?vbCr][?vbLf]" +
            "       GC_ProductoMaterial ON GC_OrdenProd.Empresa = GC_ProductoMaterial.Empresa AND GC_OrdenProd.Articulo = GC_ProductoMaterial.Producto LEFT OUTER JOIN " + "[?vbCr][?vbLf]" +
            "       GC_EnProducción ON GC_OrdenProd.Empresa = GC_EnProducción.Empresa AND GC_OrdenProd.IdOF = GC_EnProducción.idOF " + "[?vbCr][?vbLf]" +
            " where GC_OrdenProd.Empresa = [?Emp] [?FilEstado] " + "[?vbCr][?vbLf]";


        public const string SQL_Mat_ImpLista =
            "SELECT GC_ProductoMaterial.Empresa, GC_ProductoMaterial.Material, GC_ProductoMaterial.DesMaterial, " + "[?vbCr][?vbLf]" +
            "        GC_ProductoMaterial.CodProv,GC_ProductoMaterial.NombreProv, GC_ProductoMaterial.Precio,  " + "[?vbCr][?vbLf]" +
            "        dbo.fncProd_NeceEncurso(GC_ProductoMaterial.Empresa, GC_ProductoMaterial.Material) AS Necesidad,  " + "[?vbCr][?vbLf]" +
            "        dbo.fncProd_MatReservado(GC_ProductoMaterial.Empresa, GC_ProductoMaterial.Material) AS Reserva,  " + "[?vbCr][?vbLf]" +
            "        GC_Ind_ProductoCan.Cantidad AS Stock " + "[?vbCr][?vbLf]" +
            "FROM GC_ProductoMaterial INNER JOIN " + "[?vbCr][?vbLf]" +
            "      GC_Ind_ProductoCan ON GC_ProductoMaterial.Empresa = GC_Ind_ProductoCan.Empresa  " + "[?vbCr][?vbLf]" +
            "      AND GC_ProductoMaterial.Material = GC_Ind_ProductoCan.Producto " + "[?vbCr][?vbLf]" +
            "GROUP BY GC_ProductoMaterial.Empresa, GC_ProductoMaterial.Material, GC_ProductoMaterial.DesMaterial, " + "[?vbCr][?vbLf]" +
            "          GC_ProductoMaterial.CodProv, GC_ProductoMaterial.NombreProv, GC_ProductoMaterial.Precio,  " + "[?vbCr][?vbLf]" +
            "          dbo.fncProd_NeceEncurso(GC_ProductoMaterial.Empresa, GC_ProductoMaterial.Material),  " + "[?vbCr][?vbLf]" +
            "          dbo.fncProd_MatReservado(GC_ProductoMaterial.Empresa, GC_ProductoMaterial.Material),  " + "[?vbCr][?vbLf]" +
            "          GC_Ind_ProductoCan.Cantidad " + "[?vbCr][?vbLf]" +
            "HAVING (GC_ProductoMaterial.Empresa = [?Emp]) " + "[?vbCr][?vbLf]";

        public const string SQL_Prod_ImpLista0 =
            "SELECT distinct tmpMat.Empresa, tmpMat.Producto, isnull(tmpMat.Descripción,'') as Descripción, " + "[?vbCr][?vbLf]" +
            "        (SELECT  top(1) GC_ClienteProducto.CodCli " + "[?vbCr][?vbLf]" +
            "            FROM GC_ProductoAnexos  " + "[?vbCr][?vbLf]" +
            "		             INNER JOIN GC_ClienteProducto ON GC_ProductoAnexos.Empresa = GC_ClienteProducto.Empresa AND GC_ProductoAnexos.Producto = GC_ClienteProducto.Producto " + "[?vbCr][?vbLf]" +
            "            WHERE (GC_ProductoAnexos.Producto = tmpMat.Producto)) as Cliente, " + "[?vbCr][?vbLf]" +
            "        (SELECT  top(1) GC_ClienteProducto.NomCli " + "[?vbCr][?vbLf]" +
            "            FROM GC_ProductoAnexos  " + "[?vbCr][?vbLf]" +
            "		             INNER JOIN GC_ClienteProducto ON GC_ProductoAnexos.Empresa = GC_ClienteProducto.Empresa AND GC_ProductoAnexos.Producto = GC_ClienteProducto.Producto " + "[?vbCr][?vbLf]" +
            "            WHERE (GC_ProductoAnexos.Producto = tmpMat.Producto)) as Nombre, " + "[?vbCr][?vbLf]" +
            "        isnull(tmpMat.PVP,0) as Precio,    " + "[?vbCr][?vbLf]" +
            "        0 AS Necesidad, 0 AS Reserva, GC_Ind_ProductoCan.Cantidad AS Stock,tmpMat.StockMinimo   " + "[?vbCr][?vbLf]" +
            "FROM GC_ProductoAnexos  as tmpMat  " + "[?vbCr][?vbLf]" +
            "     INNER JOIN GC_Ind_ProductoCan ON tmpMat.Empresa = GC_Ind_ProductoCan.Empresa    " + "[?vbCr][?vbLf]" +
            "            AND tmpMat.Producto = GC_Ind_ProductoCan.Producto    " + "[?vbCr][?vbLf]" +
            "Where (tmpMat.Empresa = 1) and EsMaterial=0  " + "[?vbCr][?vbLf]";


            //"SELECT distinct tmpMat.Empresa, tmpMat.Producto, isnull(tmpMat.Descripción,'') as Descripción,  " + "[?vbCr][?vbLf]" +
            //"        isnull(tmpMat.CodProv,'') as CodProv, isnull(tmpMat.NombreProv,'') as NombreProv,  " + "[?vbCr][?vbLf]" +
            //"        isnull(tmpMat.Precio,0) as Precio,   " + "[?vbCr][?vbLf]" +
            //"        0 AS Necesidad, 0 AS Reserva, GC_Ind_ProductoCan.Cantidad AS Stock  " + "[?vbCr][?vbLf]" +
            //"FROM GC_ProductoAnexos  as tmpMat " + "[?vbCr][?vbLf]" +
            //"     INNER JOIN GC_Ind_ProductoCan ON tmpMat.Empresa = GC_Ind_ProductoCan.Empresa   " + "[?vbCr][?vbLf]" +
            //"            AND tmpMat.Producto = GC_Ind_ProductoCan.Producto   " + "[?vbCr][?vbLf]" +
            //"Where (tmpMat.Empresa = 1) and EsMaterial=0 " + "[?vbCr][?vbLf]";



        public const string SQL_Mat_ImpLista0 =
            "SELECT distinct tmpMat.Empresa, tmpMat.Producto as Material, isnull(tmpMat.Descripción,'') as Descripción,  " + "[?vbCr][?vbLf]" +
            "        isnull(tmpMat.CodProv,'') as CodProv, isnull(tmpMat.NombreProv,'') as NombreProv,  " + "[?vbCr][?vbLf]" +
            "        isnull(tmpMat.Precio,0) as Precio,   " + "[?vbCr][?vbLf]" +
            "        0 AS Necesidad, 0 AS Reserva, isnull(GC_Ind_ProductoCan.Cantidad,0) AS Stock ,tmpmat.StockMinimo   " + "[?vbCr][?vbLf]" +
            "FROM GC_ProductoAnexos  as tmpMat " + "[?vbCr][?vbLf]" +
            "     left outer JOIN GC_Ind_ProductoCan ON tmpMat.Empresa = GC_Ind_ProductoCan.Empresa   " + "[?vbCr][?vbLf]" +
            "            AND tmpMat.Producto = GC_Ind_ProductoCan.Producto   " + "[?vbCr][?vbLf]" +
            "Where (tmpMat.Empresa = 1) and EsMaterial=1 " + "[?vbCr][?vbLf]";




            //"SELECT     Empresa, Material " + "[?vbCr][?vbLf]" +
            //"into #tmpMat " + "[?vbCr][?vbLf]" +
            //"FROM         GC_ProductoMaterial " + "[?vbCr][?vbLf]" +
            //"GROUP BY Empresa, Material " + "[?vbCr][?vbLf]" +
            //"HAVING (GC_ProductoMaterial.Empresa = [?Emp]) " + "[?vbCr][?vbLf]" +
            //" " + "[?vbCr][?vbLf]" +
            //"SELECT distinct #tmpMat.Empresa, #tmpMat.Material, isnull(GC_ProductoAnexos.Descripción,'') as Descripción, " + "[?vbCr][?vbLf]" +
            //"        isnull(GC_ProductoAnexos.CodProv,'') as CodProv, isnull(GC_ProductoAnexos.NombreProv,'') as NombreProv, " + "[?vbCr][?vbLf]" +
            //"        isnull(GC_ProductoAnexos.Precio,0) as Precio,  " + "[?vbCr][?vbLf]" +
            //"        0 AS Necesidad, 0 AS Reserva, GC_Ind_ProductoCan.Cantidad AS Stock " + "[?vbCr][?vbLf]" +
            //"FROM #tmpMat  " + "[?vbCr][?vbLf]" +
            //"     INNER JOIN GC_Ind_ProductoCan ON #tmpMat.Empresa = GC_Ind_ProductoCan.Empresa  " + "[?vbCr][?vbLf]" +
            //"            AND #tmpMat.Material = GC_Ind_ProductoCan.Producto  " + "[?vbCr][?vbLf]" +
            //"     LEFT OUTER JOIN GC_ProductoAnexos ON #tmpMat.Empresa = GC_ProductoAnexos.Empresa  " + "[?vbCr][?vbLf]" +
            //"            AND #tmpMat.Material = GC_ProductoAnexos.Producto " + "[?vbCr][?vbLf]" +
            //"Where (#tmpMat.Empresa = [?Emp]) " + "[?vbCr][?vbLf]";


            //"SELECT GC_ProductoMaterial.Empresa, GC_ProductoMaterial.Material, GC_ProductoMaterial.DesMaterial, " + "[?vbCr][?vbLf]" +
            //"        GC_ProductoMaterial.CodProv, GC_ProductoMaterial.NombreProv, GC_ProductoAnexos.Precio,  " + "[?vbCr][?vbLf]" +
            //"        0 AS Necesidad, 0 AS Reserva, GC_Ind_ProductoCan.Cantidad AS Stock " + "[?vbCr][?vbLf]" +
            //"FROM GC_ProductoMaterial  " + "[?vbCr][?vbLf]" +
            //"     INNER JOIN GC_Ind_ProductoCan ON GC_ProductoMaterial.Empresa = GC_Ind_ProductoCan.Empresa  " + "[?vbCr][?vbLf]" +
            //"            AND GC_ProductoMaterial.Material = GC_Ind_ProductoCan.Producto  " + "[?vbCr][?vbLf]" +
            //"     LEFT OUTER JOIN GC_ProductoAnexos ON GC_ProductoMaterial.Empresa = GC_ProductoAnexos.Empresa  " + "[?vbCr][?vbLf]" +
            //"            AND GC_ProductoMaterial.Producto = GC_ProductoAnexos.Producto " + "[?vbCr][?vbLf]" +
            //"GROUP BY GC_ProductoMaterial.Empresa, GC_ProductoMaterial.Material, GC_ProductoMaterial.DesMaterial, " + "[?vbCr][?vbLf]" + 
            //"            GC_ProductoMaterial.CodProv, GC_ProductoMaterial.NombreProv, GC_ProductoMaterial.Precio,  " + "[?vbCr][?vbLf]" +
            //"                      GC_Ind_ProductoCan.Cantidad, GC_ProductoAnexos.Precio " + "[?vbCr][?vbLf]" +
            //"HAVING (GC_ProductoMaterial.Empresa = [?Emp]) " + "[?vbCr][?vbLf]";
                      
            
            //"SELECT GC_ProductoMaterial.Empresa, GC_ProductoMaterial.Material, GC_ProductoMaterial.DesMaterial, " + "[?vbCr][?vbLf]" +
            //"        GC_ProductoMaterial.CodProv,GC_ProductoMaterial.NombreProv, GC_ProductoMaterial.Precio,  " + "[?vbCr][?vbLf]" +
            //"        0 AS Necesidad,  " + "[?vbCr][?vbLf]" +
            //"        0 AS Reserva,  " + "[?vbCr][?vbLf]" +
            //"        GC_Ind_ProductoCan.Cantidad AS Stock " + "[?vbCr][?vbLf]" +
            //"FROM GC_ProductoMaterial INNER JOIN " + "[?vbCr][?vbLf]" +
            //"      GC_Ind_ProductoCan ON GC_ProductoMaterial.Empresa = GC_Ind_ProductoCan.Empresa  " + "[?vbCr][?vbLf]" +
            //"      AND GC_ProductoMaterial.Material = GC_Ind_ProductoCan.Producto " + "[?vbCr][?vbLf]" +
            //"GROUP BY GC_ProductoMaterial.Empresa, GC_ProductoMaterial.Material, GC_ProductoMaterial.DesMaterial, " + "[?vbCr][?vbLf]" +
            //"          GC_ProductoMaterial.CodProv, GC_ProductoMaterial.NombreProv, GC_ProductoMaterial.Precio,  " + "[?vbCr][?vbLf]" +
            //"          GC_Ind_ProductoCan.Cantidad " + "[?vbCr][?vbLf]" +
            //"HAVING (GC_ProductoMaterial.Empresa = [?Emp]) " + "[?vbCr][?vbLf]";


        public const string SQL_Terminar_OF_2 =
           "SELECT	tOF.Id, tOF.Empresa, tOF.IdOF, tOF.Fecha, tOF.Estado, ISNULL(tEnP.NombreOper, N'') AS Operario,  " + "[?vbCr][?vbLf]" +
           "        ISNULL(tEnP.DesMaquina, N'') AS Maquina, tOF.CodCli, " + "[?vbCr][?vbLf]" +
           "        (SELECT TOP (1) NomCli " + "[?vbCr][?vbLf]" +
           "         FROM  GC_ClienteProducto " + "[?vbCr][?vbLf]" +
           "         WHERE (CodCli = tOF.CodCli)) as NomCli, " + "[?vbCr][?vbLf]" +
           "        tOF.Articulo, tOF.Descripción,tOF.ArticuloCli, " + "[?vbCr][?vbLf]" +
           "        tOF.Cantidad, tOF.Lote, tOF.FechaEntrega,tOF.Kilos, tOF.FechaInicio, tOF.FechaFin, tOF.CantidadFab, " + "[?vbCr][?vbLf]" +
           "        tOF.Horas,tOF.PiezasReales,tOF.PiezasNoOk,tOF.Maquina as NoMaquina,tOF.Ubi, " + "[?vbCr][?vbLf]" +
           "        dbo.fncOFL_KilosId([?Emp],'[?OF]') as KilosId,  " + "[?vbCr][?vbLf]" +
           "        dbo.fncOFL_KilosProduc([?Emp],'[?OF]','') as KilosServ,  " + "[?vbCr][?vbLf]" +
           "        dbo.fncOFL_KilosProduc([?Emp],'[?OF]','Todos')*-1 as KilosConsum,GC_ProductoMaterial.Material  " + "[?vbCr][?vbLf]" +
           " FROM  GC_OrdenProd AS tOF  " + "[?vbCr][?vbLf]" +
            "      LEFT OUTER JOIN GC_ProductoMaterial ON tOF.Empresa = GC_ProductoMaterial.Empresa AND tOF.Articulo = GC_ProductoMaterial.Producto " + "[?vbCr][?vbLf]" +
           "       LEFT OUTER JOIN GC_EnProducción AS tEnP ON tOF.Empresa = tEnP.Empresa AND tOF.IdOF = tEnP.idOF " + "[?vbCr][?vbLf]" +
           " WHERE (tOF.Empresa = [?Emp])  " + "[?vbCr][?vbLf]" +
           "         AND (tOF.Estado = 'Acabada') " + "[?vbCr][?vbLf]" +
           "         AND (tOF.IdOF = '[?OF]') " + "[?vbCr][?vbLf]";


        public const string SQL_Terminar_OF =
            "SELECT GC_OrdenProd.Id, GC_OrdenProd.Empresa, GC_OrdenProd.IdOF, GC_OrdenProd.Fecha, GC_OrdenProd.Estado, " + "[?vbCr][?vbLf]" +
            "        isnull(GC_EnProducción.NombreOper,'') AS Operario,  " + "[?vbCr][?vbLf]" +
            "        isnull(GC_EnProducción.DesMaquina,'') AS Maquina, GC_OrdenProd.CodCli, GC_OrdenProd.Articulo, " + "[?vbCr][?vbLf]" +
            "        GC_OrdenProd.Descripción, " + "[?vbCr][?vbLf]" +
            "        GC_ProductoMaterial.Material,GC_ProductoMaterial.DesMaterial, " + "[?vbCr][?vbLf]" +
            "        GC_OrdenProd.ArticuloCli, GC_OrdenProd.Cantidad, GC_OrdenProd.Lote, " + "[?vbCr][?vbLf]" +
            "        GC_OrdenProd.FechaEntrega, GC_OrdenProd.FechaInicio, GC_OrdenProd.FechaFin, GC_OrdenProd.CantidadFab, " + "[?vbCr][?vbLf]" +
            "        GC_OrdenProd.Horas,GC_OrdenProd.PiezasReales,GC_OrdenProd.PiezasNoOk,GC_OrdenProd.Kilos,GC_OrdenProd.Maquina as NoMaquina,GC_OrdenProd.Ubi " + "[?vbCr][?vbLf]" +
            "FROM GC_OrdenProd LEFT OUTER JOIN " + "[?vbCr][?vbLf]" +
            "       GC_ProductoMaterial ON GC_OrdenProd.Empresa = GC_ProductoMaterial.Empresa AND GC_OrdenProd.Articulo = GC_ProductoMaterial.Producto LEFT OUTER JOIN " + "[?vbCr][?vbLf]" +
            "       GC_EnProducción ON GC_OrdenProd.Empresa = GC_EnProducción.Empresa AND GC_OrdenProd.IdOF = GC_EnProducción.idOF " + "[?vbCr][?vbLf]" +
            " where GC_OrdenProd.Empresa = [?Emp] and (GC_OrdenProd.Estado = 'Acabada')  and (GC_ProductoMaterial.Activo = 1) [?Todas] " + "[?vbCr][?vbLf]" +
            "Order by GC_OrdenProd.IdOF " + "[?vbCr][?vbLf]";

        public const string SQL_OF_Terminada_Fecha =
            "SELECT distinct GC_OrdenProd.IdOF, GC_OrdenProd.CodCli,GC_OrdenProd.Articulo,GC_OrdenProd.ArticuloCli,GC_OrdenProd.Descripción, " + "[?vbCr][?vbLf]" +
            "        GC_OrdenProd.Fecha, " + "[?vbCr][?vbLf]" +
            "        case when GC_OrdenProd.FechaInicio <> '1753-01-01' then GC_OrdenProd.FechaInicio else '1900-01-01' end as FechaInicio, " + "[?vbCr][?vbLf]" +
            "        case when GC_OrdenProd.FechaFin <> '1753-01-01' then GC_OrdenProd.FechaFin else '1900-01-01' end as FechaFin, " + "[?vbCr][?vbLf]" +
            "        GC_OrdenProd.Cantidad,GC_OrdenProd.Horas as [Horas Reales], " + "[?vbCr][?vbLf]" +
            "        GC_OrdenProd.Kilos as [Kilos Reales], " + "[?vbCr][?vbLf]" +
            "        convert(money,iif(GC_OrdenProd.Horas > 0,(GC_OrdenProd.Cantidad / GC_OrdenProd.Horas),0)) as PiezasHora,GC_OrdenProd.Estado  as '    ','' as ' ','' as '  ', " + "[?vbCr][?vbLf]" +
            "        GC_OrdenProd.CantidadFab as Piezas,GC_OrdenProd.PiezasReales,(GC_OrdenProd.PiezasReales - GC_OrdenProd.CantidadFab) as Merma,'' as '   ', " + "[?vbCr][?vbLf]" +
            "        GC_OrdenProd.Maquina as NoMaquina, " + "[?vbCr][?vbLf]" +
            "        isnull(GC_EnProducción.DesMaquina,'') AS Maquina,  " + "[?vbCr][?vbLf]" +
            "        isnull(GC_EnProducción.NombreOper,'') AS Operario,  " + "[?vbCr][?vbLf]" +
            "        GC_OrdenProd.Ubi,GC_ProductoMaterial.Material,GC_ProductoMaterial.DesMaterial, " + "[?vbCr][?vbLf]" +
            "        GC_OrdenProd.Lote, " + "[?vbCr][?vbLf]" +
            "        convert(money,dbo.fncProd_Material(GC_OrdenProd.Empresa, GC_OrdenProd.Articulo,GC_ProductoMaterial.Material,'Peso')*GC_OrdenProd.Cantidad/1000) as [Kilos Teoricos], " + "[?vbCr][?vbLf]" +
            "        convert(money,iif(dbo.fncProd_Anex(GC_OrdenProd.Empresa, GC_OrdenProd.Articulo,'PiezasHora') > 0,GC_OrdenProd.Cantidad/dbo.fncProd_Anex(GC_OrdenProd.Empresa, GC_OrdenProd.Articulo,'PiezasHora'),0)) as [Horas Teoricas] " + "[?vbCr][?vbLf]" +
            "FROM GC_OrdenProd LEFT OUTER JOIN " + "[?vbCr][?vbLf]" +
            "       GC_ProductoMaterial ON GC_OrdenProd.Empresa = GC_ProductoMaterial.Empresa AND GC_OrdenProd.Articulo = GC_ProductoMaterial.Producto LEFT OUTER JOIN " + "[?vbCr][?vbLf]" +
            "       GC_EnProducción ON GC_OrdenProd.Empresa = GC_EnProducción.Empresa AND GC_OrdenProd.IdOF = GC_EnProducción.idOF " + "[?vbCr][?vbLf]" +
            " where GC_OrdenProd.Empresa = [?Emp] " + "[?vbCr][?vbLf]" +
            "       AND (GC_OrdenProd.Fecha >= CONVERT(DATETIME, '[?DFecha] 00:00:00', 103) " + "[?vbCr][?vbLf]" +
            "       AND GC_OrdenProd.Fecha <= CONVERT(DATETIME, '[?HFecha] 00:00:00', 103)) " + "[?vbCr][?vbLf]" +
            "       AND GC_ProductoMaterial.Activo = 1 " + "[?vbCr][?vbLf]" +
            "       [?fil] " + "[?vbCr][?vbLf]" +
            "Order by GC_OrdenProd.IdOF " + "[?vbCr][?vbLf]";

        		

            //"SELECT GC_OrdenProd.Id, GC_OrdenProd.Empresa, GC_OrdenProd.IdOF, GC_OrdenProd.Fecha,  " + "[?vbCr][?vbLf]" +
            //"        isnull(GC_EnProducción.NombreOper,'') AS Operario,  " + "[?vbCr][?vbLf]" +
            //"        isnull(GC_EnProducción.DesMaquina,'') AS Maquina, GC_OrdenProd.CodCli, GC_OrdenProd.Articulo, " + "[?vbCr][?vbLf]" +
            //"        GC_OrdenProd.Descripción, " + "[?vbCr][?vbLf]" +
            //"        GC_ProductoMaterial.Material,GC_ProductoMaterial.DesMaterial, " + "[?vbCr][?vbLf]" +
            //"        GC_OrdenProd.ArticuloCli, GC_OrdenProd.Cantidad, GC_OrdenProd.Lote, " + "[?vbCr][?vbLf]" +
            //"        GC_OrdenProd.FechaInicio, GC_OrdenProd.FechaFin, GC_OrdenProd.CantidadFab, " + "[?vbCr][?vbLf]" +
            //"        GC_OrdenProd.Horas as [Horas Reales],GC_OrdenProd.PiezasReales,GC_OrdenProd.Kilos as [Kilos Reales],GC_OrdenProd.Maquina as NoMaquina,GC_OrdenProd.Ubi, " + "[?vbCr][?vbLf]" +
            //"        convert(money,dbo.fncProd_Material(GC_OrdenProd.Empresa, GC_OrdenProd.Articulo,GC_ProductoMaterial.Material,'Peso')*GC_OrdenProd.Cantidad/1000) as [Kilos Teoricos], " + "[?vbCr][?vbLf]" +
            //"        convert(money,iif(dbo.fncProd_Anex(GC_OrdenProd.Empresa, GC_OrdenProd.Articulo,'PiezasHora') > 0,GC_OrdenProd.Cantidad/dbo.fncProd_Anex(GC_OrdenProd.Empresa, GC_OrdenProd.Articulo,'PiezasHora'),0)) as [Horas Teoricas] " + "[?vbCr][?vbLf]" +


        public const string SQL_Movi_Lista =
            "SELECT Tipo, Fecha, FechaHora, Almacen, Producto, Descripción, Cantidad, Documento, OFL, Ubi, Lote " + "[?vbCr][?vbLf]" +
            "FROM GC_MovProducto " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (Fecha >= CONVERT(DATETIME, '[?DFecha] 00:00:00', 102) " + "[?vbCr][?vbLf]" + 
            "           AND Fecha <= CONVERT(DATETIME, '[?HFecha] 00:00:00', 102)) [?Fil]" + "[?vbCr][?vbLf]";


        public const string SQL_OFL_Lista =
            "SELECT IdOF, convert(varchar(10),Fecha,103) as Fecha, Estado, CodCli, Articulo, Descripción, ArticuloCli, Cantidad,  " + "[?vbCr][?vbLf]" +
            "    Lote, convert(varchar(10),FechaEntrega,103) as FechaEntrega, convert(varchar(10),FechaInicio,103) as FechaInicio, convert(varchar(10),FechaFin,103) as FechaFin, CantidadFab " + "[?vbCr][?vbLf]" +
            "FROM  GC_OrdenProd " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) [?Fil] " + "[?vbCr][?vbLf]";

        public const string SQL_ProdMat_Lista =
            "SELECT Id, Empresa, Producto, Activo, Descripción, Material, DesMaterial, TipoMaterial, CodProv, NombreProv, Precio, Peso " + "[?vbCr][?vbLf]" +
            "FROM GC_ProductoMaterial " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) and (Producto ='[?Prod]')";

        public const string SQL_MaqProd_Lista =
            "SELECT 1 AS Sel, idOF, FechaInicio, IdOper, NombreOper, IdMaquina, DesMaquina, Lote " + "[?vbCr][?vbLf]" +
            "FROM GC_EnProducción " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (IdOper = N'') " + "[?vbCr][?vbLf]";

        public const string SQL_AlbCompraPen_Lista =
            "SELECT GC_AlbProv.Id,GC_AlbProv.NumAlb,GC_AlbProv.Linea, GC_AlbProv.FechaEntrega, GC_AlbProv.Producto, " + "[?vbCr][?vbLf]" +
            "        GC_AlbProv.Descripción, GC_AlbProv.CodProv, GC_AlbProv.NombreProv,GC_CabAlbProv.SuAlbaran, GC_AlbProv.Cantidad," + "[?vbCr][?vbLf]" +
            "        GC_AlbProv.Lote, GC_AlbProv.RecepcionadoPor, GC_AlbProv.NumPed, " + "[?vbCr][?vbLf]" +
            "       isnull(GC_LoteCertificado.Cert,'') as Cert,Obs, " + "[?vbCr][?vbLf]" +
            "        (case when  Grabado = 11 then 'Error al Grabar' " + "[?vbCr][?vbLf]" +
            "              when Grabado = 12 then 'Producto NO existe' " + "[?vbCr][?vbLf]" +
            "              when Grabado = 10 then 'Para procesar' " + "[?vbCr][?vbLf]" +
            "              when Grabado = 14 then 'No se ha informado el Certificado' " + "[?vbCr][?vbLf]" +
            "              when Grabado = 15 then 'No se ha informado el Lote' " + "[?vbCr][?vbLf]" +
            "              when Grabado = 16 then 'No se ha informado el Recepcionado Por' " + "[?vbCr][?vbLf]" +
            "              when Grabado = 0 then 'Pendiente de Grabar' " + "[?vbCr][?vbLf]" +
            "         end) as Error,Ubi,NumSerie " + "[?vbCr][?vbLf]" +
            "FROM GC_AlbProv " + "[?vbCr][?vbLf]" +
            "        LEFT OUTER JOIN GC_CabAlbProv ON GC_AlbProv.Empresa = GC_CabAlbProv.Empresa " + "[?vbCr][?vbLf]" +			
            "                               AND GC_AlbProv.NumAlb = GC_CabAlbProv.NumAlb " + "[?vbCr][?vbLf]" +
            "        left outer JOIN GC_LoteCertificado ON GC_AlbProv.Empresa = GC_LoteCertificado.Empresa  " + "[?vbCr][?vbLf]" +
		    "			                    AND GC_AlbProv.Lote = GC_LoteCertificado.Lote  " + "[?vbCr][?vbLf]" +
            "			                    AND GC_AlbProv.Producto = GC_LoteCertificado.Producto " + "[?vbCr][?vbLf]" +
            "WHERE (GC_AlbProv.Grabado = 0 or GC_AlbProv.Grabado > 1) AND (GC_AlbProv.Empresa = [?Emp]) " + "[?vbCr][?vbLf]";


        public const string SQL_AlbCompraReg_Lista =
            "SELECT GC_AlbProv.Id,GC_AlbProv.NumAlb,GC_AlbProv.Linea, GC_AlbProv.FechaEntrega, GC_AlbProv.Producto, " + "[?vbCr][?vbLf]" +
            "        GC_AlbProv.Descripción, GC_AlbProv.CodProv, GC_AlbProv.NombreProv,GC_CabAlbProv.SuAlbaran, GC_AlbProv.Cantidad," + "[?vbCr][?vbLf]" +
            "        GC_AlbProv.Lote, GC_AlbProv.RecepcionadoPor, GC_AlbProv.NumPed, " + "[?vbCr][?vbLf]" +
            "       isnull(GC_LoteCertificado.Cert,'') as Cert,Obs, " + "[?vbCr][?vbLf]" +
            "        (case when  Grabado = 11 then 'Error al Grabar' " + "[?vbCr][?vbLf]" +
            "              when Grabado = 12 then 'Producto NO existe' " + "[?vbCr][?vbLf]" +
            "              when Grabado = 10 then 'Para procesar' " + "[?vbCr][?vbLf]" +
            "              when Grabado = 14 then 'No se ha informado el Certificado' " + "[?vbCr][?vbLf]" +
            "              when Grabado = 15 then 'No se ha informado el Lote' " + "[?vbCr][?vbLf]" +
            "              when Grabado = 16 then 'No se ha informado el Recepcionado Por' " + "[?vbCr][?vbLf]" +
            "              when Grabado = 0 then 'Pendiente de Grabar' " + "[?vbCr][?vbLf]" +
            "         end) as Error,Ubi,NumSerie " + "[?vbCr][?vbLf]" +
            "FROM GC_AlbProv " + "[?vbCr][?vbLf]" +
            "        LEFT OUTER JOIN GC_CabAlbProv ON GC_AlbProv.Empresa = GC_CabAlbProv.Empresa " + "[?vbCr][?vbLf]" +
            "                               AND GC_AlbProv.NumAlb = GC_CabAlbProv.NumAlb " + "[?vbCr][?vbLf]" +
            "        left outer JOIN GC_LoteCertificado ON GC_AlbProv.Empresa = GC_LoteCertificado.Empresa  " + "[?vbCr][?vbLf]" +
            "			                    AND GC_AlbProv.Lote = GC_LoteCertificado.Lote  " + "[?vbCr][?vbLf]" +
            "			                    AND GC_AlbProv.Producto = GC_LoteCertificado.Producto " + "[?vbCr][?vbLf]" +
            "WHERE (GC_AlbProv.Grabado = 0 or GC_AlbProv.Grabado = 1) AND (GC_AlbProv.Empresa = [?Emp]) " + "[?vbCr][?vbLf]" +
            "       AND (GC_AlbProv.FechaEntrega >= CONVERT(DATETIME, '[?DFecha] 00:00:00', 102) " + "[?vbCr][?vbLf]" +
            "       AND GC_AlbProv.FechaEntrega <= CONVERT(DATETIME, '[?HFecha] 00:00:00', 102)) " + "[?vbCr][?vbLf]";




        public const string SQL_NumLinAlbCompra =
            "SELECT MAX(Linea) AS NumLin " + "[?vbCr][?vbLf]" +
            "FROM  GC_AlbProv " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (NumAlb = '[?NumAlb]') " + "[?vbCr][?vbLf]";

        public const string SQL_AlbCompra_Pend =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_AlbProv " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (Grabado [?Grabado]) " + "[?vbCr][?vbLf]";


        public const string SQL_AlbVentaPen_Lista =
            "SELECT Id,NumAlb, Linea, FechaEntrega, Producto, Descripción, CodProv, NombreProv, Cantidad," + "[?vbCr][?vbLf]" +
            "        Lote, NumPed, " + "[?vbCr][?vbLf]" +
            "        (case when  Grabado = 11 then 'Error al Grabar' " + "[?vbCr][?vbLf]" +
            "              when Grabado = 12 then 'Producto NO existe' " + "[?vbCr][?vbLf]" +
            "              when Grabado = 0 then 'Para procesar' " + "[?vbCr][?vbLf]" +
            "         end) as Error " + "[?vbCr][?vbLf]" +
            "FROM GC_AlbCli " + "[?vbCr][?vbLf]" +
            "WHERE (Grabado > 1) AND (Empresa = [?Emp]) " + "[?vbCr][?vbLf]";

        public const string SQL_NumLinAlbVenta =
            "SELECT MAX(Linea) AS NumLin " + "[?vbCr][?vbLf]" +
            "FROM  GC_AlbCli " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (NumAlb = '[?NumAlb]') " + "[?vbCr][?vbLf]";


        public const string SQL_AlbVenta_Pend =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_AlbCli " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (Grabado [?Grabado]) " + "[?vbCr][?vbLf]";


        public const string SQL_CabAlbCompra =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_CabAlbProv " + "[?vbCr][?vbLf]" +
            "Where Empresa = [?Emp] " + "[?vbCr][?vbLf]" +
            "Order by Id asc " + "[?vbCr][?vbLf]";

        public const string SQL_CabAlbCompra_Alb =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_CabAlbProv " + "[?vbCr][?vbLf]" +
            "Where Empresa = [?Emp] and NumAlb = '[?Alb]' " + "[?vbCr][?vbLf]" +
            "Order by Id asc " + "[?vbCr][?vbLf]";


        public const string SQL_LinAlbCompra =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_AlbProv " + "[?vbCr][?vbLf]" +
            "Where Empresa = [?Emp] and [NumAlb] = '[?Alb]' " + "[?vbCr][?vbLf]";


        public const string SQL_Insert_Cab_AlbProv =
            "insert into GC_CabAlbProv  " + "[?vbCr][?vbLf]" +
            "SELECT GC_AlbProv.Empresa, GC_AlbProv.NumAlb,'Reg' as Estado, GC_AlbProv.FechaEntrega AS FechaAlbaran, " + "[?vbCr][?vbLf]" + 
		    "        GC_AlbProv.CodProv, GC_AlbProv.NombreProv, GC_AlbProv.RecepcionadoPor, GC_AlbProv.NumPed ,'' as SuAlbaran " + "[?vbCr][?vbLf]" +
            "FROM GC_AlbProv LEFT OUTER JOIN  " + "[?vbCr][?vbLf]" +
            "                      GC_CabAlbProv ON GC_AlbProv.NumAlb = GC_CabAlbProv.NumAlb  " + "[?vbCr][?vbLf]" +
            "WHERE     (GC_CabAlbProv.NumAlb IS NULL)  " + "[?vbCr][?vbLf]" +
            "GROUP BY GC_AlbProv.Empresa, GC_AlbProv.NumAlb,   " + "[?vbCr][?vbLf]" +
            "            GC_AlbProv.FechaEntrega, GC_AlbProv.CodProv,   " + "[?vbCr][?vbLf]" +
            "            GC_AlbProv.NombreProv, GC_AlbProv.RecepcionadoPor,   " + "[?vbCr][?vbLf]" +
            "            GC_AlbProv.NumPed " + "[?vbCr][?vbLf]";


        public const string SQL_Insert_LoteCert =
            " insert into GC_LoteCertificado values ('[?Emp]','[?Producto]','[?Lote]','[?Cert]') ";

        public const string SQL_Delete_LoteCert =
            " Delete From GC_LoteCertificado Where Empresa ='[?Emp]' and Producto = '[?Producto]' and Lote = '[?Lote]'";

        public const string SQL_LoteCert_Busca =
            "SELECT Id, Empresa, Producto, Lote, Cert " + "[?vbCr][?vbLf]" +
            "FROM GC_LoteCertificado " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (Producto = N'[?Prod]') AND (Lote = N'[?Lote]') " + "[?vbCr][?vbLf]";

        public const string SQL_LogErrores_Lista =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_Error " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (Fecha >= CONVERT(DATETIME, '[?DFecha] 00:00:00', 102) " + "[?vbCr][?vbLf]" +
            "           AND Fecha <= CONVERT(DATETIME, '[?HFecha] 23:59:59', 102)) [?Fil]" + "[?vbCr][?vbLf]";

        public const string SQL_ElimStockPL =
            "SELECT     Id, Empresa, Almacen, Producto, Ubi, Cantidad, Lote, Cantidad * - 1 AS canreg,OFL " +
            "FROM         GC_Ind_ProductoUbiCanLoteOFL             " +
            "WHERE     (Cantidad <> 0) AND (Producto LIKE N'PL-%') ";

        public const string SQL_ElimStockPZ =
            "SELECT     Id, Empresa, Almacen, Producto, Ubi, Cantidad, Lote, Cantidad * - 1 AS canreg,OFL " +
            "FROM         GC_Ind_ProductoUbiCanLoteOFL             " +
            "WHERE     (Cantidad <> 0) AND (Producto LIKE N'PZ-%') ";

        public const string SQL_ElimStockRef =
            "SELECT Id, Empresa, Almacen, Producto, Ubi, Cantidad, Lote, Cantidad * - 1 AS canreg,OFL " +
            "FROM GC_Ind_ProductoUbiCanLoteOFL             " +
            "WHERE (Cantidad <> 0) AND (Producto = N'[?Ref]') ";



        public const string SQL_Stock_Ubi_Lote =
            "SELECT Producto, Ubi, convert(money,Cantidad) as Cantidad, Lote " + "[?vbCr][?vbLf]" +
            "FROM GC_Ind_ProductoUbiCanLote " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (Almacen = N'[?Alm]') AND (Cantidad <> 0) " + "[?vbCr][?vbLf]";


        public const string SQL_Stock_Ubi_Lote_OFL =
            "SELECT Producto, Ubi, convert(money,Sum(Cantidad)) as Cantidad,Lote,OFL " + "[?vbCr][?vbLf]" +
            "FROM GC_Ind_ProductoUbiCanLoteOFL " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (Almacen = N'[?Alm]') " + "[?vbCr][?vbLf]" +
            "GROUP BY Producto, Ubi, Lote, OFL " + "[?vbCr][?vbLf]" +
            "HAVING (SUM(Cantidad) > 0) " + "[?vbCr][?vbLf]";


        public const string SQL_Stock_Fab =
            "SELECT Producto, Ubi, convert(money,Sum(Cantidad)) as Cantidad,Lote,OFL " + "[?vbCr][?vbLf]" +
            "FROM GC_Ind_ProductoUbiCanLoteOFL " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (Almacen = N'[?Alm]') AND (Ubi = N'Fab') " + "[?vbCr][?vbLf]" +
            "GROUP BY Producto, Ubi, Lote, OFL " + "[?vbCr][?vbLf]" +
            "HAVING (SUM(Cantidad) > 0) " + "[?vbCr][?vbLf]";


        public const string SQL_Stock_PRODUC =
            "SELECT GC_Ind_ProductoUbiCanLoteOFL.Id, GC_Ind_ProductoUbiCanLoteOFL.Empresa, GC_Ind_ProductoUbiCanLoteOFL.Almacen,  " + "[?vbCr][?vbLf]" +
		    "        GC_Ind_ProductoUbiCanLoteOFL.Producto,  " + "[?vbCr][?vbLf]" +
            "       GC_Ind_ProductoUbiCanLoteOFL.Ubi, GC_Ind_ProductoUbiCanLoteOFL.Cantidad, GC_Ind_ProductoUbiCanLoteOFL.Lote,  " + "[?vbCr][?vbLf]" +
            "       GC_Ind_ProductoUbiCanLoteOFL.OFL,isnull(GC_ProductoAnexos.EsMaterial,1) as EsMaterial " + "[?vbCr][?vbLf]" +
            "into #tmpStock " + "[?vbCr][?vbLf]" +
            "FROM GC_Ind_ProductoUbiCanLoteOFL  " + "[?vbCr][?vbLf]" +
	        "    LEFT OUTER JOIN GC_ProductoAnexos ON GC_Ind_ProductoUbiCanLoteOFL.Producto = GC_ProductoAnexos.Producto  " + "[?vbCr][?vbLf]" +
    		"            AND GC_Ind_ProductoUbiCanLoteOFL.Empresa = GC_ProductoAnexos.Empresa " + "[?vbCr][?vbLf]" +                                            
            
            "SELECT Producto, Ubi, convert(money,Sum(Cantidad)) as Cantidad,Lote,OFL " + "[?vbCr][?vbLf]" +
            "FROM #tmpStock " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (Almacen = N'[?Alm]') AND (Ubi = N'PRODUC') and EsMaterial=1 " + "[?vbCr][?vbLf]" +
            "GROUP BY Producto, Ubi, Lote, OFL,EsMaterial " + "[?vbCr][?vbLf]" +
            "HAVING (SUM(Cantidad) > 0) " + "[?vbCr][?vbLf]";


        public const string SQL_Stock_A_Produc =
            "SELECT GC_Ind_ProductoUbiCanLoteOFL.Id, GC_Ind_ProductoUbiCanLoteOFL.Empresa, GC_Ind_ProductoUbiCanLoteOFL.Almacen,  " + "[?vbCr][?vbLf]" +
            "        GC_Ind_ProductoUbiCanLoteOFL.Producto,  " + "[?vbCr][?vbLf]" +
            "       GC_Ind_ProductoUbiCanLoteOFL.Ubi, GC_Ind_ProductoUbiCanLoteOFL.Cantidad, GC_Ind_ProductoUbiCanLoteOFL.Lote,  " + "[?vbCr][?vbLf]" +
            "       GC_Ind_ProductoUbiCanLoteOFL.OFL,isnull(GC_ProductoAnexos.EsMaterial,1) as EsMaterial " + "[?vbCr][?vbLf]" +
            "into #tmpStock " + "[?vbCr][?vbLf]" +
            "FROM GC_Ind_ProductoUbiCanLoteOFL  " + "[?vbCr][?vbLf]" +
            "    LEFT OUTER JOIN GC_ProductoAnexos ON GC_Ind_ProductoUbiCanLoteOFL.Producto = GC_ProductoAnexos.Producto  " + "[?vbCr][?vbLf]" +
            "            AND GC_Ind_ProductoUbiCanLoteOFL.Empresa = GC_ProductoAnexos.Empresa " + "[?vbCr][?vbLf]" +
            "SELECT Producto, Ubi, convert(money,Sum(Cantidad)) as Cantidad,Lote,OFL " + "[?vbCr][?vbLf]" +
            "FROM #tmpStock " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (Almacen = N'[?Alm]') AND (Ubi <> N'PRODUC') and EsMaterial=1 " + "[?vbCr][?vbLf]" +
            "GROUP BY Producto, Ubi, Lote, OFL,EsMaterial " + "[?vbCr][?vbLf]" +
            "HAVING (SUM(Cantidad) > 0)  " + "[?vbCr][?vbLf]";


            //"SELECT Producto, Ubi, convert(money,Sum(Cantidad)) as Cantidad,Lote,OFL " + "[?vbCr][?vbLf]" +
            //"FROM GC_Ind_ProductoUbiCanLoteOFL " + "[?vbCr][?vbLf]" +
            //"WHERE (Empresa = [?Emp]) AND (Almacen = N'[?Alm]') AND (Ubi <> N'PRODUC') " + "[?vbCr][?vbLf]" +
            //"GROUP BY Producto, Ubi, Lote, OFL " + "[?vbCr][?vbLf]" +
            //"HAVING (SUM(Cantidad) > 0) " + "[?vbCr][?vbLf]";




        public const string SQL_CabPrepEntrega =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_CabPrepEntregas " + "[?vbCr][?vbLf]" +
            "Where Empresa = [?Emp] " + "[?vbCr][?vbLf]" +
            "Order by Id asc " + "[?vbCr][?vbLf]";


        public const string SQL_LinPrep =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_LinPrepEntregas " + "[?vbCr][?vbLf]" +
            "Where Empresa = [?Emp] and [NumPrep] = [?Prep] " + "[?vbCr][?vbLf]";


        public const string SQL_NumLinPrep =
            "SELECT MAX(LinPrep) AS NumLin " + "[?vbCr][?vbLf]" +
            "FROM  GC_LinPrepEntregas " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (NumPrep = [?NumPrep]) " + "[?vbCr][?vbLf]";

        public const string SQL_Prep_Entre =
            "SELECT 0 as Sel, GC_LinPedido.Id,GC_CabPedido.CodCli, GC_CabPedido.NomCli, GC_CabPedido.NumPed, GC_CabPedido.FechaPedido, GC_CabPedido.FechaEntrega,  " + "[?vbCr][?vbLf]" +
            "        GC_LinPedido.LinPed, GC_LinPedido.Producto,GC_LinPedido.Descripción, " + "[?vbCr][?vbLf]" +
            "        (GC_LinPedido.Cantidad - GC_LinPedido.CantidadServida) AS Cantidad, GC_LinPedido.Prioridad " + "[?vbCr][?vbLf]" +
            "FROM GC_CabPedido  " + "[?vbCr][?vbLf]" +
            "          INNER JOIN GC_LinPedido ON GC_CabPedido.Empresa = GC_LinPedido.Empresa AND GC_CabPedido.NumPed = GC_LinPedido.NumPed " + "[?vbCr][?vbLf]" +
            "WHERE (GC_CabPedido.Empresa = [?Emp]) AND (GC_CabPedido.Estado = 'P') " + "[?vbCr][?vbLf]" +
            "       and (GC_LinPedido.Cantidad - GC_LinPedido.CantidadServida - dbo.fncPed_EnPrep(GC_CabPedido.Empresa,GC_CabPedido.NumPed,GC_LinPedido.LinPed)) > 0 " + "[?vbCr][?vbLf]" +
            "Order by GC_LinPedido.Prioridad desc,GC_CabPedido.FechaPedido,GC_CabPedido.CodCli " + "[?vbCr][?vbLf]";

        public const string SQL_Entregas_Calc =
            "SELECT tMat.Producto,dbo.fncProd_Stock(tMat.Empresa,tMat.Producto,'Principal') as Stock, " + "[?vbCr][?vbLf]" +
            "dbo.fncProd_PrepEntrega(1,tMat.Producto) as NeceTot,0 as NeceAct,dbo.fncOFL_CanPen(1, tMat.Producto) as CanEnOF " + "[?vbCr][?vbLf]" +
            "FROM GC_ProductoAnexos as tMat " + "[?vbCr][?vbLf]" +
            "WHERE (tMat.Empresa = 1)  " + "[?vbCr][?vbLf]";

        public const string SQL_CabAlb =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_CabAlbCli " + "[?vbCr][?vbLf]" +
            "Where Empresa = [?Emp] " + "[?vbCr][?vbLf]" +
            "Order by Id asc " + "[?vbCr][?vbLf]";


        public const string SQL_NumLinAlb =
            "SELECT MAX(Linea) AS NumLin " + "[?vbCr][?vbLf]" +
            "FROM  GC_LinAlbCli " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (NumAlb = [?NumAlb]) " + "[?vbCr][?vbLf]";


        public const string SQL_Prod_Ubi_Lote =
            "SELECT Lote, Ubi, Cantidad, OFL " + "[?vbCr][?vbLf]" +
            "FROM GC_Ind_ProductoUbiCanLoteOFL " + "[?vbCr][?vbLf]" +
            "WHERE (Producto = N'[?Prod]') AND (Empresa = [?Emp]) AND (OFL = N'[?OFL]') AND (Almacen = N'Principal') AND (Cantidad > 0) " + "[?vbCr][?vbLf]";

        public const string SQL_Prod_Ubi_Lote_OFL =
            "SELECT Lote, Ubi, Sum(Cantidad) as Cantidad,OFL " + "[?vbCr][?vbLf]" +
            "FROM GC_Ind_ProductoUbiCanLoteOFL " + "[?vbCr][?vbLf]" +
            "WHERE (Producto = N'[?Prod]') AND (Empresa = [?Emp]) AND (Almacen = N'Principal') " + "[?vbCr][?vbLf]" +
            "GROUP BY Lote, Ubi, OFL " + "[?vbCr][?vbLf]" +
            "HAVING (SUM(Cantidad) > 0) " + "[?vbCr][?vbLf]";

        public const string SQL_Prod_Ubi =
            "SELECT Ubi, Cantidad " + "[?vbCr][?vbLf]" +
            "FROM  GC_Ind_ProductoUbiCan " + "[?vbCr][?vbLf]" +
            "WHERE (Producto = N'[?Prod]') AND (Cantidad > 0) " + "[?vbCr][?vbLf]";

        public const string SQL_Entrega_Update_CanPendiente =
            "Update GC_LinPrepEntregas " +
               "Set CanPen = Cantidad - CantidadServida " +
            "Where Id = [?id]";


        public const string SQL_Entrega_Update_CanServida =
            "Update GC_LinPrepEntregas " +
               "Set CantidadServida = '[?2]' " +
            "Where [?3]";


        public const string SQL_Entrega_Update_MasCanServida =
            "Update GC_LinPrepEntregas " +
               "Set CantidadServida = CantidadServida + [?2],CanPen = Cantidad - CantidadServida - [?2] " +
            "Where [?3]";

        public const string SQL_Entrega_Update_MenosCanServida =
            "Update GC_LinPrepEntregas " +
               "Set CantidadServida = CantidadServida - [?2],CanPen = Cantidad - CantidadServida + [?2] " +
            "Where [?3]";

        public const string SQL_PedidoVenta_Update_CanServida =
            "Update GC_LinPedido " +
               "Set CantidadServida = '[?2]' " +
            "Where [?3]";

        public const string SQL_PedidoVenta_Update_MasCanServida =
            "Update GC_LinPedido " +
               "Set CantidadServida = CantidadServida + '[?2]' " +
            "Where [?3]";

        public const string SQL_PedidoVenta_Update_MenosCanServida =
            "Update GC_LinPedido " +
               "Set CantidadServida = CantidadServida - '[?2]' " +
            "Where [?3]";


        public const string SQL_OFL_Lista_CanPen =
            "SELECT IdOF, Fecha, Estado, CodCli, Articulo, Descripción, ArticuloCli,  " + "[?vbCr][?vbLf]" +
            "       Cantidad, CantidadFab, Cantidad - CantidadFab AS CanPen, Lote " + "[?vbCr][?vbLf]" +
            "FROM GC_OrdenProd " + "[?vbCr][?vbLf]" +
            "WHERE (Cantidad - CantidadFab > 0) AND (Empresa = [?Emp]) AND (Articulo = N'[?Prod]') AND (Estado <> N'Terminada') " + "[?vbCr][?vbLf]";

        public const string SQL_PrepPen_Lista =
            "SELECT GC_CabPrepEntregas.FechaEntrega,GC_CabPrepEntregas.NumPrep, GC_CabPrepEntregas.NomCli, GC_ClienteProducto.ProductoCli, GC_LinPrepEntregas.Producto, GC_LinPrepEntregas.CanPen, " + "[?vbCr][?vbLf]" +
            "           CONVERT(int,ROUND(CASE WHEN GC_ProductoAnexos.PiezasCaja > 0 THEN GC_LinPrepEntregas.CanPen / GC_ProductoAnexos.PiezasCaja ELSE 1 END, 0)) AS Cajas,  " + "[?vbCr][?vbLf]" +
            "           GC_ProductoAnexos.PiezasCaja,'' as Observaciones, " + "[?vbCr][?vbLf]" +
		    "           GC_ProductoAnexos.PesoNeto as PesoUni_gr, " + "[?vbCr][?vbLf]" +
		    "           convert(decimal(10,2),(GC_ProductoAnexos.PesoNeto*GC_LinPrepEntregas.CanPen)/1000) AS Peso_Kg, " + "[?vbCr][?vbLf]" +
            "           convert(decimal(10,2),(GC_ProductoAnexos.PesoNeto*GC_ProductoAnexos.PiezasCaja)/1000) AS PesoCaja_Kg " + "[?vbCr][?vbLf]" +
            "FROM GC_CabPrepEntregas  " + "[?vbCr][?vbLf]" +
            "        INNER JOIN GC_LinPrepEntregas ON GC_CabPrepEntregas.Empresa = GC_LinPrepEntregas.Empresa AND GC_CabPrepEntregas.NumPrep = GC_LinPrepEntregas.NumPrep  " + "[?vbCr][?vbLf]" +
            "        LEFT OUTER JOIN GC_ProductoAnexos ON GC_CabPrepEntregas.Empresa = GC_ProductoAnexos.Empresa AND GC_LinPrepEntregas.Producto = GC_ProductoAnexos.Producto  " + "[?vbCr][?vbLf]" +
            "        LEFT OUTER JOIN GC_ClienteProducto ON GC_CabPrepEntregas.Empresa = GC_ClienteProducto.Empresa  " + "[?vbCr][?vbLf]" +
            "                AND GC_CabPrepEntregas.CodCli = GC_ClienteProducto.CodCli  " + "[?vbCr][?vbLf]" +
            "                AND GC_LinPrepEntregas.Producto = GC_ClienteProducto.Producto " + "[?vbCr][?vbLf]" +
            "WHERE     (GC_CabPrepEntregas.Empresa = [?Emp]) AND (GC_LinPrepEntregas.CanPen > 0) " + "[?vbCr][?vbLf]" +
            "ORDER BY GC_CabPrepEntregas.NomCli " + "[?vbCr][?vbLf]";

        public const string SQL_CajasOF_Lista =
            "SELECT 0 as Sel,NumCajaBolsa as Caja, CanProd as Cantidad" + "[?vbCr][?vbLf]" +
            "FROM  GC_OrdenProdCajas " + "[?vbCr][?vbLf]" +
            "WHERE (IdOF = N'[?OFL]') AND (Tipo = 'C') AND (Entregada = 0) " + "[?vbCr][?vbLf]" +
            "ORDER BY NumCajaBolsa " + "[?vbCr][?vbLf]";

        public const string SQL_PakingList_Lista =
            "SELECT  GC_LinAlbCli.NumPrep, GC_CabAlbCli.NumAlb, GC_CabAlbCli.FechaAlbaran, GC_CabAlbCli.FechaEntrega, GC_CabAlbCli.CodCli,  " + "[?vbCr][?vbLf]" +
            "       GC_CabAlbCli.NomCli, GC_CabAlbCli.Dirección, GC_CabAlbCli.Población,  " + "[?vbCr][?vbLf]" +
            "       GC_CabAlbCli.Provincia, GC_CabAlbCli.CP, GC_LinAlbCli.Linea, GC_LinAlbCli.Producto,  " + "[?vbCr][?vbLf]" +
            "       GC_LinAlbCli.Descripción, GC_LinAlbCli.Cantidad, GC_LinAlbCli.Lote, GC_LinAlbCli.Cajas, GC_CabAlbCli.Id,  " + "[?vbCr][?vbLf]" +
            "       GC_LinAlbCli.Impresiones " + "[?vbCr][?vbLf]" +
            "FROM GC_CabAlbCli  " + "[?vbCr][?vbLf]" +
            "          INNER JOIN GC_LinAlbCli ON GC_CabAlbCli.Empresa = GC_LinAlbCli.Empresa AND GC_CabAlbCli.NumAlb = GC_LinAlbCli.NumAlb " + "[?vbCr][?vbLf]" +
            "WHERE (GC_CabAlbCli.Empresa = [?Emp]) " + "[?vbCr][?vbLf]";

        public const string SQL_Prep_Nece =
            "Select GC_LinPrepEntregas.NumPrep, GC_LinPrepEntregas.LinPrep, GC_LinPrepEntregas.Producto, " + "[?vbCr][?vbLf]" +
            "       GC_LinPrepEntregas.Descripción, GC_LinPrepEntregas.Cantidad, GC_LinPrepEntregas.Lote,  " + "[?vbCr][?vbLf]" +
            "       GC_LinPrepEntregas.CantidadServida, GC_LinPrepEntregas.CanPen, GC_LinPrepEntregas.FechaEntrega, " + "[?vbCr][?vbLf]" +
            "       GC_LinPrepEntregas.PedLocal, GC_LinPrepEntregas.LinPedLocal,  " + "[?vbCr][?vbLf]" +
            "       GC_LinPrepEntregas.PedCliente " + "[?vbCr][?vbLf]" +
            "FROM GC_CabPrepEntregas  " + "[?vbCr][?vbLf]" +
            "           INNER JOIN GC_LinPrepEntregas ON GC_CabPrepEntregas.Empresa = GC_LinPrepEntregas.Empresa  " + "[?vbCr][?vbLf]" +
            "                       AND GC_CabPrepEntregas.NumPrep = GC_LinPrepEntregas.NumPrep " + "[?vbCr][?vbLf]" +
            "WHERE (GC_CabPrepEntregas.Empresa = [?Emp])  " + "[?vbCr][?vbLf]" +
            "        AND (GC_CabPrepEntregas.Estado = 'P')  " + "[?vbCr][?vbLf]" +
            "        AND (GC_LinPrepEntregas.Producto = '[?Prod]') " + "[?vbCr][?vbLf]";


        public const string SQL_Produc_Mat_Entr_Consum =
            "SELECT  SUM(Cantidad)" + "[?vbCr][?vbLf]" +
            "FROM  GC_MovProducto " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) " + "[?vbCr][?vbLf]" +
            "GROUP BY Documento, OFL, Ubi, Lote " + "[?vbCr][?vbLf]" +
            "HAVING (Ubi = N'PRODUC') AND (OFL = N'[?OFL]') AND (Documento = N'[?Doc]') " + "[?vbCr][?vbLf]" +
            "ORDER BY OFL DESC " + "[?vbCr][?vbLf]";


        public const string SQL_Produc_Mat_Ubi_Ant =
            "SELECT TOP (1) Ubi,Lote " + "[?vbCr][?vbLf]" +
            "FROM GC_MovProducto " + "[?vbCr][?vbLf]" +
            "WHERE  (Empresa = [?Emp]) and (Id = [?ID]) AND (Tipo = N'Salida') --AND (Producto = N'[?Compo]') " + "[?vbCr][?vbLf]";



        public const string SQL_Produc_Pie_Ubi_Ant =
            "SELECT TOP (1) Ubi,Lote " + "[?vbCr][?vbLf]" +
            "FROM GC_MovProducto " + "[?vbCr][?vbLf]" +
            "WHERE  (Empresa = [?Emp]) AND (Almacen = N'Principal') and (Producto = '[?Prod]') AND (Ubi <> N'FAB')  " + "[?vbCr][?vbLf]" +
            "ORDER BY Id DESC " + "[?vbCr][?vbLf]";


        public const string SQL_Produc_Pie_Produc_Lote_OF =
            "SELECT Ubi, Cantidad, Lote, OFL " + "[?vbCr][?vbLf]" +
            "FROM  GC_Ind_ProductoUbiCanLoteOFL " + "[?vbCr][?vbLf]" +
            "WHERE (Producto = N'[?Compo]') AND (Ubi = N'PRODUC') AND (Cantidad <> 0) AND (OFL = N'[?OF]') " + "[?vbCr][?vbLf]";


        public const string SQL_Produc_Pie_Fab_Lote_OF =
            "SELECT Ubi, Cantidad, Lote, OFL " + "[?vbCr][?vbLf]" +
            "FROM GC_Ind_ProductoUbiCanLoteOFL " + "[?vbCr][?vbLf]" +
            "WHERE (Producto = N'[?Prod]') AND (Ubi = N'FAB') AND (Cantidad <> 0) AND (OFL = N'[?OF]') " + "[?vbCr][?vbLf]";


        public const string SQL_Produc_Actu_Des =
        "SELECT Id, Empresa, Producto, Descripción " + "[?vbCr][?vbLf]" +
        "FROM GC_ProductoAnexos " + "[?vbCr][?vbLf]" +
        "WHERE (Descripción = N'') " + "[?vbCr][?vbLf]";


        public const string SQL_Cert_Calc1 =
            "SELECT GC_LinAlbCli.Empresa, GC_LinAlbCli.Producto, GC_LinAlbCli.Descripción, GC_LinAlbCli.Cantidad AS Cantidad, GC_CabAlbCli.CodCli, GC_CabAlbCli.NomCli,    " + "[?vbCr][?vbLf]" +
            "       isnull(GC_ClienteProducto.ProductoCli,'') as ProductoCli, GC_LinAlbCli.NumPrep,	    " + "[?vbCr][?vbLf]" +
	        "       dbo.fncPrep_LoteOF(GC_LinAlbCli.Lote,'OF') as OFL, " + "[?vbCr][?vbLf]" +
	        "       dbo.fncPrep_LoteOF(GC_LinAlbCli.Lote,'Lote') as Lote, " + "[?vbCr][?vbLf]" +
	        "        GC_LinAlbCli.Cajas " + "[?vbCr][?vbLf]" +
            "FROM GC_LinAlbCli    " + "[?vbCr][?vbLf]" +
            "        INNER JOIN GC_CabAlbCli ON GC_LinAlbCli.Empresa = GC_CabAlbCli.Empresa AND GC_LinAlbCli.NumAlb = GC_CabAlbCli.NumAlb    " + "[?vbCr][?vbLf]" +
            "        LEFT OUTER JOIN GC_ClienteProducto ON GC_LinAlbCli.Empresa = GC_ClienteProducto.Empresa AND GC_CabAlbCli.CodCli = GC_ClienteProducto.CodCli AND  " + "[?vbCr][?vbLf]" +  
            "                         GC_LinAlbCli.Producto = GC_ClienteProducto.Producto   " + "[?vbCr][?vbLf]" +
            "where (GC_LinAlbCli.Empresa = 1) AND (GC_LinAlbCli.NumPrep = [?Prep]) " + "[?vbCr][?vbLf]";




            //"SELECT GC_LinAlbCli.Empresa, GC_LinAlbCli.Producto, GC_LinAlbCli.Descripción, SUM(GC_LinAlbCli.Cantidad) AS Cantidad, GC_CabAlbCli.CodCli, GC_CabAlbCli.NomCli,   " + "[?vbCr][?vbLf]" +
            //"       isnull(GC_ClienteProducto.ProductoCli,'') as ProductoCli, GC_LinAlbCli.NumPrep,  " + "[?vbCr][?vbLf]" +
            //"       dbo.fncProd_MoviDatos(GC_LinAlbCli.Empresa,GC_LinAlbCli.Producto,GC_LinAlbCli.NumPrep,'OFL') as OFL,  " + "[?vbCr][?vbLf]" +
            //"       dbo.fncProd_MoviDatos(GC_LinAlbCli.Empresa,GC_LinAlbCli.Producto,GC_LinAlbCli.NumPrep,'Lote') as Lote  " + "[?vbCr][?vbLf]" +
            //"Into #tmpCajas " + "[?vbCr][?vbLf]" +
            //"FROM GC_LinAlbCli   " + "[?vbCr][?vbLf]" +
            //"        INNER JOIN GC_CabAlbCli ON GC_LinAlbCli.Empresa = GC_CabAlbCli.Empresa AND GC_LinAlbCli.NumAlb = GC_CabAlbCli.NumAlb   " + "[?vbCr][?vbLf]" +
            //"        LEFT OUTER JOIN GC_ClienteProducto ON GC_LinAlbCli.Empresa = GC_ClienteProducto.Empresa AND GC_CabAlbCli.CodCli = GC_ClienteProducto.CodCli AND   " + "[?vbCr][?vbLf]" +
            //"                         GC_LinAlbCli.Producto = GC_ClienteProducto.Producto  " + "[?vbCr][?vbLf]" +
            //"GROUP BY GC_LinAlbCli.Producto, GC_LinAlbCli.Descripción, GC_CabAlbCli.CodCli, GC_CabAlbCli.NomCli, ISNULL(GC_ClienteProducto.ProductoCli, N''), GC_LinAlbCli.NumPrep,   " + "[?vbCr][?vbLf]" +
            //"                            dbo.fncProd_MoviDatos(GC_LinAlbCli.Empresa, GC_LinAlbCli.Producto, GC_LinAlbCli.NumPrep, N'OFL'), dbo.fncProd_MoviDatos(GC_LinAlbCli.Empresa,   " + "[?vbCr][?vbLf]" +
            //"                            GC_LinAlbCli.Producto, GC_LinAlbCli.NumPrep, N'Lote'), GC_LinAlbCli.Empresa,GC_ClienteProducto.ProductoCli  " + "[?vbCr][?vbLf]" +
            //"HAVING (GC_LinAlbCli.Empresa = [?Emp]) AND (GC_LinAlbCli.NumPrep = [?Prep])  " + "[?vbCr][?vbLf]" +
            //"Select *,dbo.fncPrep_Cajas(Empresa,Producto,NumPrep,Lote) as Cajas " + "[?vbCr][?vbLf]" +
            //"from #tmpCajas " + "[?vbCr][?vbLf]";



            //"SELECT GC_LinAlbCli.Empresa, GC_LinAlbCli.Producto, GC_LinAlbCli.Descripción, SUM(GC_LinAlbCli.Cantidad) AS cANTIDAD, GC_CabAlbCli.CodCli, GC_CabAlbCli.NomCli,  " + "[?vbCr][?vbLf]" +
            //"       isnull(GC_ClienteProducto.ProductoCli,'') as ProductoCli, GC_LinAlbCli.NumPrep, " + "[?vbCr][?vbLf]" +
            //"       dbo.fncProd_MoviDatos(GC_LinAlbCli.Empresa,GC_LinAlbCli.Producto,GC_LinAlbCli.NumPrep,'OFL') as OFL, " + "[?vbCr][?vbLf]" +
            //"       dbo.fncProd_MoviDatos(GC_LinAlbCli.Empresa,GC_LinAlbCli.Producto,GC_LinAlbCli.NumPrep,'Lote') as Lote " + "[?vbCr][?vbLf]" +
            //"FROM GC_LinAlbCli  " + "[?vbCr][?vbLf]" +
            //"        INNER JOIN GC_CabAlbCli ON GC_LinAlbCli.Empresa = GC_CabAlbCli.Empresa AND GC_LinAlbCli.NumAlb = GC_CabAlbCli.NumAlb  " + "[?vbCr][?vbLf]" +
            //"        LEFT OUTER JOIN GC_ClienteProducto ON GC_LinAlbCli.Empresa = GC_ClienteProducto.Empresa AND GC_CabAlbCli.CodCli = GC_ClienteProducto.CodCli AND  " + "[?vbCr][?vbLf]" +
            //"                         GC_LinAlbCli.Producto = GC_ClienteProducto.Producto " + "[?vbCr][?vbLf]" +
            //"GROUP BY GC_LinAlbCli.Producto, GC_LinAlbCli.Descripción, GC_CabAlbCli.CodCli, GC_CabAlbCli.NomCli, ISNULL(GC_ClienteProducto.ProductoCli, N''), GC_LinAlbCli.NumPrep,  " + "[?vbCr][?vbLf]" +
            //"                            dbo.fncProd_MoviDatos(GC_LinAlbCli.Empresa, GC_LinAlbCli.Producto, GC_LinAlbCli.NumPrep, N'OFL'), dbo.fncProd_MoviDatos(GC_LinAlbCli.Empresa,  " + "[?vbCr][?vbLf]" +
            //"                            GC_LinAlbCli.Producto, GC_LinAlbCli.NumPrep, N'Lote'), GC_LinAlbCli.Empresa,GC_ClienteProducto.ProductoCli  " + "[?vbCr][?vbLf]" +
            //"HAVING (GC_LinAlbCli.Empresa = [?Emp]) AND (GC_LinAlbCli.NumPrep = [?Prep]) " + "[?vbCr][?vbLf]";




        public const string SQL_Cert_Calc2 =
            "SELECT  GC_OrdenProd.IdOF, GC_OrdenProd.CodCli, GC_OrdenProd.Articulo, GC_OrdenProd.Descripción, GC_OrdenProd.ArticuloCli, GC_OrdenProd.FechaEntrega,  " + "[?vbCr][?vbLf]" +
            "        GC_OrdenProd.CantidadFab, GC_OrdenProd.Maquina, GC_OrdenProdCompo.Compo, " + "[?vbCr][?vbLf]" +
            "        dbo.fncProd_Material(GC_OrdenProd.Empresa,GC_OrdenProd.Articulo,GC_OrdenProdCompo.Compo,'DesMat') as DesMat, " + "[?vbCr][?vbLf]" +
            "        '' as Lotes , '' as Cajas,'' as NomCli,'' as Foto,'' as Entrega " + "[?vbCr][?vbLf]" +
            "FROM GC_OrdenProd LEFT OUTER JOIN " + "[?vbCr][?vbLf]" +
            "                         GC_OrdenProdCompo ON GC_OrdenProd.Empresa = GC_OrdenProdCompo.Empresa AND GC_OrdenProd.IdOF = GC_OrdenProdCompo.IdOF " + "[?vbCr][?vbLf]" +
            "WHERE        (GC_OrdenProd.IdOF = N'[?OFL]') AND (GC_OrdenProd.Empresa = [?Emp]) " + "[?vbCr][?vbLf]";


        public const string SQL_Alb_Entrega =
            "SELECT  0 as Sel,NumAlb, Linea, Producto, Descripción, Cantidad, Lote, Cajas as Caja, Impresiones, NumPrep,ID " + "[?vbCr][?vbLf]" +
            "FROM GC_LinAlbCli " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (NumPrep = [?NumPrep]) AND (Producto = N'[?Prod]') " + "[?vbCr][?vbLf]";



        public const string SQL_ElimCajaEntrega =
            "SELECT 0 as Sel,IdOF,NumCajaBolsa as Caja, PiezasCaja,  CanProd, Material, CanMat, Lote " + "[?vbCr][?vbLf]" + 
            "FROM GC_OrdenProdCajas " + "[?vbCr][?vbLf]" +
            "[?Filtro] " + "[?vbCr][?vbLf]" +
            "order by IdOF,NumCajaBolsa " + "[?vbCr][?vbLf]";


        //WHERE (IdOF = 'N105833') AND (NumCajaBolsa IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17)) OR
        //                         (IdOF = 'N105832') AND (NumCajaBolsa IN (1, 2, 3))
        //order by IdOF,NumCajaBolsa

        //public const string SQL_ElimAlbEntrega =
        //    "SELECT NumAlb, Linea, Producto, Descripción, Cantidad, Lote, Cajas as Caja, Impresiones, NumPrep " + "[?vbCr][?vbLf]" +
        //    "FROM  GC_LinAlbCli " + "[?vbCr][?vbLf]" +
        //    "WHERE (Empresa = [?Emp]) AND (NumPrep = [?NumPrep]) " + "[?vbCr][?vbLf]";


        public const string SQL_Movi_TraeUbi =
          "SELECT TOP (1) Ubi " + "[?vbCr][?vbLf]" +
           "FROM GC_MovProducto " + "[?vbCr][?vbLf]" +
           "WHERE (Empresa = [?Emp]) AND (Documento = N'[?Doc]') AND (Producto = N'[?Prod]') AND (Tipo = N'[?Tipo]') AND (Cantidad = [?Can]) AND (Lote = N'[?Lote]') " + "[?vbCr][?vbLf]" +
           "ORDER BY Id DESC " + "[?vbCr][?vbLf]";

        public const string SQL_Moldes_Lista =
           "SELECT * " + "[?vbCr][?vbLf]" +
           "FROM GC_Moldes" + "[?vbCr][?vbLf]" +
           "WHERE (Empresa = 1)" + "[?vbCr][?vbLf]";


        public static string Conexion(int vPrueba)
        {
            string strConexion = "";

            if (vPrueba == 1)
            {
                strConexion = cParamXml.strConec;
            }
            else
            {
                strConexion = cParamXml.strConec;

            }
            return strConexion;
        }

    }


