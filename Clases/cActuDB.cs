using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jControles.Clases;
using System.Data;

namespace GesInject.Clases
{
    class cActuDB
    {

        public static bool sbrActuSql()
        {
            bool vOK = false;

            vOK = sbrActuProductoAnexos();
            vOK = sbrActuClienteProducto();
            vOK = sbrActuProductoMaterial();
            vOK = sbrActuAlProv();
            vOK = sbrActuOrdenProd();
            vOK = sbrActuOrdenProdCajas();
            vOK = sbrActuMoldes();
            vOK = sbrActuMaquinas();
            vOK = sbrActuOperarios();

            return vOK;
        }

        public static bool sbrActuProductoAnexos()
        {
            bool vOk = false;

            string vSql = "ALTER TABLE dbo.GC_ProductoAnexos ADD " +
                        "StockMinimo decimal(18, 4) NOT NULL CONSTRAINT DF_GC_ProductoAnexos_StockMinimo DEFAULT 0 " +
                        "ALTER TABLE dbo.GC_ProductoAnexos SET (LOCK_ESCALATION = TABLE)";
            int viOk = 1;
            if (!fncExisteCampo("GC_ProductoAnexos", "StockMinimo"))
            {
                viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
            }

            if (viOk == 1)
            {
                vSql = "ALTER TABLE dbo.GC_ProductoAnexos ADD " +
                        "PrioMaq1 nvarchar(50) NOT NULL CONSTRAINT DF_GC_ProductoAnexos_PrioMaq1 DEFAULT '', " +
                        "PrioMaq2 nvarchar(50) NOT NULL CONSTRAINT DF_GC_ProductoAnexos_PrioMaq11 DEFAULT '', " +
                        "PrioMaq3 nvarchar(50) NOT NULL CONSTRAINT DF_GC_ProductoAnexos_PrioMaq11_1 DEFAULT '' " +
                      "ALTER TABLE dbo.GC_ProductoAnexos SET (LOCK_ESCALATION = TABLE)";

                if (!fncExisteCampo("GC_ProductoAnexos", "PrioMaq1"))
                {
                    viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                }
            }

            if (viOk == 1)
            {

                vSql="ALTER TABLE dbo.GC_ProductoAnexos ADD " +
	                    "LogoCaja int NOT NULL CONSTRAINT DF_GC_ProductoAnexos_LogoCaja DEFAULT 1, " +
	                    "LogoBolsa int NOT NULL CONSTRAINT DF_GC_ProductoAnexos_LogoBolsa DEFAULT 1 " +
                     "ALTER TABLE dbo.GC_ProductoAnexos SET (LOCK_ESCALATION = TABLE)";

                if (!fncExisteCampo("GC_ProductoAnexos", "LogoCaja"))
                {
                    viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                }
            }

            if (viOk == 1)
            {

                vSql = "ALTER TABLE dbo.GC_ProductoAnexos ADD " +
                        "Ocupación int NOT NULL CONSTRAINT DF_GC_ProductoAnexos_Ocupación DEFAULT 0 " +
                     "ALTER TABLE dbo.GC_ProductoAnexos SET (LOCK_ESCALATION = TABLE)";

                if (!fncExisteCampo("GC_ProductoAnexos", "Ocupación"))
                {
                    viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                }
            }



            if (viOk == 1)
            {
                vOk = true;
            }
            

            return vOk;

        }

        public static bool sbrActuProductoMaterial()
        {
            bool vOk = false;
            string vSql = "ALTER TABLE dbo.GC_ProductoMaterial ADD " +
	                    "Activo int NOT NULL CONSTRAINT DF_GC_ProductoMaterial_Activo DEFAULT 1, " +
	                    "Peso decimal(18, 4) NOT NULL CONSTRAINT DF_GC_ProductoMaterial_Peso DEFAULT 0 ";
            
            int viOk = 1;
            if (!fncExisteCampo("GC_ProductoMaterial", "Activo"))
            {
                viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);

            }

            vSql="ALTER TABLE dbo.GC_ProductoMaterial ADD " +
	                "Color nvarchar(50) NOT NULL CONSTRAINT DF_GC_ProductoMaterial_Color DEFAULT ''";

            viOk = 1;

            if (!fncExisteCampo("GC_ProductoMaterial", "Color"))
            {
                viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);

            }

            if (viOk == 1)
            {
                vOk = true;
            }


             return vOk;
       }

        public static bool sbrActuClienteProducto()
        {
            bool vOk = false;

            string vSql = "ALTER TABLE dbo.GC_ClienteProducto ADD EtiCli int NOT NULL CONSTRAINT DF_GC_ClienteProducto_EtiCli DEFAULT 0 " +
                          "ALTER TABLE dbo.GC_ClienteProducto SET (LOCK_ESCALATION = TABLE)";

            int viOk = 1;
            if (!fncExisteCampo("GC_ClienteProducto", "EtiCli"))
            {
                viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
            }

            vSql = "ALTER TABLE dbo.GC_ClienteProducto ADD EtiDes nvarchar(50) NOT NULL CONSTRAINT DF_GC_ClienteProducto_EtiDes DEFAULT '' " +
                   "ALTER TABLE dbo.GC_ClienteProducto SET (LOCK_ESCALATION = TABLE)";

            if (!fncExisteCampo("GC_ClienteProducto", "EtiDes"))
            {
                viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
            }

            if (viOk == 1)
            {
                vOk = true;
            }


            return vOk;

        }

        public static bool sbrActuAlProv()
        {
            bool vOk = false;

            string vSql = "CREATE TABLE GC_AlbProv " +
                            "( " +
                            "Id int NOT NULL, " +
                            "Empresa int NOT NULL, " +
                            "NumAlb nvarchar(50) NOT NULL, " +
                            "FechaEntrega date NOT NULL, " +
                            "Producto nvarchar(50) NOT NULL, " +
                            "Descripción nvarchar(100) NOT NULL, " +
                            "CodProv nvarchar(50) NOT NULL, " +
                            "NombreProv nvarchar(100) NOT NULL, " +
                            "Cantidad decimal(18, 2) NOT NULL, " +
                            "Lote nvarchar(50) NOT NULL, " +
                            "RecepcionadoPor nvarchar(50) NOT NULL " +
                            ")  ON [PRIMARY] " +
                            "ALTER TABLE GC_AlbProv ADD CONSTRAINT " +
                            "    DF_GC_AlbProv_Empresa DEFAULT ((1)) FOR Empresa " +
                            "ALTER TABLE GC_AlbProv ADD CONSTRAINT " +
                            "    DF_GC_AlbProv_NumAlb DEFAULT 0 FOR NumAlb " +
                            "ALTER TABLE GC_AlbProv ADD CONSTRAINT " +
                            "    DF_GC_AlbProv_Producto DEFAULT ('') FOR Producto " +
                            "ALTER TABLE GC_AlbProv ADD CONSTRAINT " +
                            "    DF_GC_AlbProv_Descripción DEFAULT ('') FOR Descripción " +
                            "ALTER TABLE GC_AlbProv ADD CONSTRAINT " +
                            "    DF_GC_AlbProv_CodProv DEFAULT ('') FOR CodProv " +
                            "ALTER TABLE GC_AlbProv ADD CONSTRAINT " +
                            "    DF_GC_AlbProv_NombreProv DEFAULT ('') FOR NombreProv " +
                            "ALTER TABLE GC_AlbProv ADD CONSTRAINT " +
                            "    DF_GC_AlbProv_Cantidad DEFAULT ((0)) FOR Cantidad " +
                            "ALTER TABLE GC_AlbProv ADD CONSTRAINT " +
                            "    DF_GC_AlbProv_Lote DEFAULT '' FOR Lote " +
                            "ALTER TABLE GC_AlbProv ADD CONSTRAINT " +
                            "    DF_GC_AlbProv_RecepcionadoPor DEFAULT '' FOR RecepcionadoPor " +
                            "ALTER TABLE GC_AlbProv SET (LOCK_ESCALATION = TABLE) ";

            int viOk = 1;
            if (!fncExisteTabla("GC_AlbProv"))
            {
                viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
            }

            return vOk;

        }

        public static bool sbrActuOrdenProd()
        {
            bool vOk = false;

            string vSql = "ALTER TABLE dbo.GC_OrdenProd ADD " +
	                      "Horas decimal(18, 4) NOT NULL CONSTRAINT DF_GC_OrdenProd_Horas DEFAULT 0, " +
	                      "PiezasReales decimal(18, 4) NOT NULL CONSTRAINT DF_GC_OrdenProd_PiezasReales DEFAULT 0, " +
	                      "PiezasNoOk decimal(18, 4) NOT NULL CONSTRAINT DF_GC_OrdenProd_PiezasNoOk DEFAULT 0, " +
    	                  "Kilos decimal(18, 4) NOT NULL CONSTRAINT DF_GC_OrdenProd_Kilos DEFAULT 0, " +
	                      "Maquina nvarchar(20) NOT NULL CONSTRAINT DF_GC_OrdenProd_Maquina DEFAULT '', " +
                          "Ubi nvarchar(50) NOT NULL CONSTRAINT DF_GC_OrdenProd_Ubi DEFAULT '' " +
                          "ALTER TABLE dbo.GC_OrdenProd SET (LOCK_ESCALATION = TABLE) ";

            int viOk = 1;
            if (!fncExisteCampo("GC_OrdenProd", "PiezasReales"))
            {
                viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
            }


            if (viOk == 1)
            {

                vSql = "ALTER TABLE dbo.GC_OrdenProd ADD " +
	                    "NMaquina  AS (replace(left([Maquina],charindex('-',[Maquina])),'-','')) " +
                        "ALTER TABLE dbo.GC_OrdenProd SET (LOCK_ESCALATION = TABLE) ";

                if (!fncExisteCampo("GC_OrdenProd", "NMaquina"))
                {
                    viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                }
            }


            if (viOk == 1)
            {
                vOk = true;
            }


            return vOk;

        }

        public static bool sbrActuOrdenProdCajas()
        {
            bool vOk = false;

            string vSql = "ALTER TABLE dbo.GC_OrdenProdCajas ADD " +
	                      "Maquina nvarchar(20) NOT NULL CONSTRAINT DF_GC_OrdenProdCajas_Maquina DEFAULT '' " +
                          "ALTER TABLE dbo.GC_OrdenProdCajas SET (LOCK_ESCALATION = TABLE) ";

            int viOk = 1;
            if (!fncExisteCampo("GC_OrdenProdCajas", "Maquina"))
            {
                viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
            }

            //vSql = "ALTER TABLE dbo.GC_ClienteProducto ADD EtiDes nvarchar(50) NOT NULL CONSTRAINT DF_GC_ClienteProducto_EtiDes DEFAULT '' " +
            //       "ALTER TABLE dbo.GC_ClienteProducto SET (LOCK_ESCALATION = TABLE)";

            //if (!fncExisteCampo("GC_ClienteProducto", "EtiDes"))
            //{
            //    viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
            //}

            if (viOk == 1)
            {
                vOk = true;
            }


            return vOk;

        }

        public static bool sbrActuMoldes()
        {
            bool vOk = false;

            string vSql = "ALTER TABLE dbo.GC_Moldes ADD Bloqueado bit NOT NULL CONSTRAINT DF_GC_Moldes_Bloqueado DEFAULT 0 " +
                          "ALTER TABLE dbo.GC_Moldes SET (LOCK_ESCALATION = TABLE)";

            int viOk = 1;
            if (!fncExisteCampo("GC_Moldes", "Bloqueado"))
            {
                viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
            }

            if (viOk == 1)
            {
                vOk = true;
            }


            return vOk;

        }

        public static bool sbrActuMaquinas()
        {
            bool vOk = false;
            string vSql = "";

            int viOk = 1;
            if (viOk == 1)
            {

                vSql = "ALTER TABLE dbo.GC_Maquinas ADD " +
                        "TasaHR int NOT NULL CONSTRAINT DF_GC_Maquinas_TasaHR DEFAULT 0 " +
                     "ALTER TABLE dbo.GC_Maquinas SET (LOCK_ESCALATION = TABLE)";

                if (!fncExisteCampo("GC_Maquinas", "TasaHR"))
                {
                    viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                }
            }

            if (viOk == 1)
            {

                vSql = "ALTER TABLE dbo.GC_Maquinas ADD " +
                        "PSMolde int NOT NULL CONSTRAINT DF_GC_Maquinas_PSMolde DEFAULT 0 " +
                     "ALTER TABLE dbo.GC_Maquinas SET (LOCK_ESCALATION = TABLE)";

                if (!fncExisteCampo("GC_Maquinas", "PSMolde"))
                {
                    viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                }
            }



            if (viOk == 1)
            {
                vOk = true;
            }


            return vOk;

        }

        public static bool sbrActuOperarios()
        {
            bool vOk = false;
            string vSql = "";

            int viOk = 1;
            if (viOk == 1)
            {

                vSql = "ALTER TABLE dbo.GC_Operarios ADD " +
                        "TasaHR int NOT NULL CONSTRAINT DF_GC_Operarios_TasaHR DEFAULT 0 " +
                     "ALTER TABLE dbo.GC_Operarios SET (LOCK_ESCALATION = TABLE)";

                if (!fncExisteCampo("GC_Operarios", "TasaHR"))
                {
                    viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                }
            }




            if (viOk == 1)
            {
                vOk = true;
            }


            return vOk;

        }

        private static bool fncExisteCampo(string vTabla,string vCampo)
        {
            bool vOk=false;

            string vSql="select * FROM INFORMATION_SCHEMA.COLUMNS AS c1 where c1.column_name = '" + vCampo + "' and c1.table_name = '" + vTabla + "'";

            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));

            if (dt.Rows.Count > 0) vOk = true;

            return vOk;
        }

        private static bool fncExisteTabla(string vTabla)
        {
            bool vOk = false;

            string vSql = "select * FROM INFORMATION_SCHEMA.COLUMNS AS c1 where c1.table_name = '" + vTabla + "'";

            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));

            if (dt.Rows.Count > 0) vOk = true;

            return vOk;
        }

    }
}
