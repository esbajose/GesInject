using System;
using System.Collections.Generic;
using System.Text;
using SrvGesInj.Clases;

    class cConstantes
    {
        public const string DataAccessLayerType = "SQLDataAccess";
        public const string AdoConecStrCosmic = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Servidor;Data Source=BaseDatos;Connect Timeout=15;Packet Size=4096";
        public const string NaviConecStrCosmic = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BaseDatos;Data Source=Servidor;Connect Timeout=15;Packet Size=4096";
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

        public const string SQL_UP_Delete =
            "Delete From [?99] " +
            "Where  [?1]";

        public const string SQL_UP_Update =
            "Update [?99] " +
               "Set [?1] = '[?2]' " +
            "Where [?3]";

        public const string SQL_Alb_Dbf =
             "Select albprol.*,albprot.DFecAlb,albprot.ccodpro " +
             "From albprol inner join " +
                        " albprot on albprol.nnumalb = albprot.nnumalb " +
             "Where albprot.DFecAlb >=#01/01/2011# and albprot.NNumAlb >= [?NumAlb] ";

        public const string SQL_NumLinAlbCompra =
            "SELECT MAX(Linea) AS NumLin " + "[?vbCr][?vbLf]" +
            "FROM  GC_AlbProv " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (NumAlb = '[?NumAlb]') " + "[?vbCr][?vbLf]";

        public const string SQL_AlbCompra_Pend =
            "SELECT *,GC_LoteCertificado.Cert " + "[?vbCr][?vbLf]" +
            "FROM GC_AlbProv " + "[?vbCr][?vbLf]" +
            "        left outer JOIN GC_LoteCertificado ON GC_AlbProv.Empresa = GC_LoteCertificado.Empresa  " + "[?vbCr][?vbLf]" +
            "			                    AND GC_AlbProv.Lote = GC_LoteCertificado.Lote  " + "[?vbCr][?vbLf]" +
            "			                    AND GC_AlbProv.Producto = GC_LoteCertificado.Producto " + "[?vbCr][?vbLf]" +
            "WHERE (GC_AlbProv.Empresa = [?Emp]) AND (GC_AlbProv.Ubi <> '') AND (GC_AlbProv.Grabado [?Grabado]) " + "[?vbCr][?vbLf]";


        public const string SQL_Alb_Cli_Dbf =
             "Select albclil.*,albclit.DFecAlb,albclit.ccodcli " +
             "From albclil inner join " +
                        " albclit on albclil.nnumalb = albclit.nnumalb " +
             "Where albclit.DFecAlb >=#01/01/2011# and albclit.NNumAlb > [?NumAlb] ";

        public const string SQL_NumLinAlbVenta =
            "SELECT MAX(Linea) AS NumLin " + "[?vbCr][?vbLf]" +
            "FROM  GC_AlbCli " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (NumAlb = '[?NumAlb]') " + "[?vbCr][?vbLf]";

        public const string SQL_AlbVenta_Pend =
            "SELECT * " + "[?vbCr][?vbLf]" +
            "FROM GC_AlbCli " + "[?vbCr][?vbLf]" +
            "WHERE (Empresa = [?Emp]) AND (Grabado [?Grabado]) " + "[?vbCr][?vbLf]";


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



        public const string SQL_CabPed_Dbf =
            "SELECT 1 AS Empresa, pedclit.NNUMPED, pedclit.CESTADO, pedclit.DFECPED, pedclit.DFECENT,  " + "[?vbCr][?vbLf]" +
            "pedclit.CCODCLI, clientes.CNOMCLI, clientes.CDIRCLI, clientes.CPOBCLI, clientes.CCODPROV,  " + "[?vbCr][?vbLf]" +
            "clientes.CPTLCLI, pedclit.CCODPAGO, clientes.CCODDIV, pedclit.CSUPED, pedclit.NDPP, pedclit.NDTOESP,  " + "[?vbCr][?vbLf]" +
            "'' AS Ent_Dirección, '' AS Ent_Población, '' AS Ent_Provincia, '' AS Ent_CP, 0 AS Ent_Id, * " + "[?vbCr][?vbLf]" +
            "FROM pedclit INNER JOIN clientes ON pedclit.CCODCLI = clientes.CCODCLI " + "[?vbCr][?vbLf]" +
            "WHERE (((pedclit.DFECPED)>#1/1/2015#) AND ((pedclit.NNUMPED)>=[?NumPed])) " + "[?vbCr][?vbLf]" +
            "Order by pedclit.NNUMPED; " + "[?vbCr][?vbLf]";


        public const string SQL_LinPed_Dbf =
            "SELECT 1 AS Empresa, pedclil.NNUMPED, pedclil.NLINEA, pedclil.CREF, pedclil.CDETALLE, pedclil.NCANPED,  " + "[?vbCr][?vbLf]" +
            "pedclil.NCANENT, pedclil.CPROP1, pedclil.CLOTE, pedclil.NIVA,0 as Cajas, pedclil.NPREUNIT, pedclil.NDTO, 0 AS DtoLin,0 as Prioridad " + "[?vbCr][?vbLf]" +
            "FROM pedclil " + "[?vbCr][?vbLf]" +
            "WHERE (((pedclil.NNUMPED)=[?NumPed])) " + "[?vbCr][?vbLf]" +
            "ORDER BY pedclil.NNUMPED, pedclil.NLINEA; " + "[?vbCr][?vbLf]";


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

