using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jControles.Clases;
using System.Data;


namespace SrvGesInj.Clases
{
    class cConfig
    {
        private string _Error = "";
        private string _Clave = "";
        private string _Valor = "";

        private const string Sql_Busca = "Select Valor From GC_NumSerie where Clave = '[?1]'";
        private const string Sql_Modif = "Update GC_NumSerie set Valor = '[?2]' where Clave = '[?1]'";
        private const string Sql_Alta = "insert into GC_NumSerie Values('[?1]','[?2]')";

        public string Error
        {
            get { return _Error; }
            set { _Error = value; }
        }
        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }
        public string Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }


        public string fncBusca(string vClave, bool incrementar, string vValIni)
        {

            string vRes = "";
            string vSql = Sql_Busca;
            vSql = vSql.Replace("[?1]", vClave);

            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));

            if (dt.Rows.Count == 0)
            {
                vRes = "**Inexistente**";
                if (vValIni != "")
                {
                    fncAlta(vClave, vValIni);
                    vRes = vValIni;
                }
            }
            else
            {
                vRes = dt.Rows[0]["Valor"].ToString();
            }

            if ((incrementar) & (vRes != "**Inexistente**"))
            {
                int viValor = Convert.ToInt32(vRes);
                viValor++;
                fncModif(vClave, viValor.ToString());
            }

            return vRes;
        }

        public bool fncModif(string vClave, string vValor)
        {
            bool vOk = false;
            string vSql = Sql_Modif;
            vSql = vSql.Replace("[?1]", vClave);
            vSql = vSql.Replace("[?2]", vValor);
            try
            {
                SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                vOk = true;
            }
            catch
            {
                vOk = false;
            }
            return vOk;
        }

        public bool fncAlta(string vClave, string vValor)
        {
            bool vOk = false;
            string vSql = Sql_Alta;
            vSql = vSql.Replace("[?1]", vClave);
            vSql = vSql.Replace("[?2]", vValor);
            try
            {
                SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                vOk = true;
            }
            catch
            {
                vOk = false;
            }
            return vOk;
        }


    }
}
