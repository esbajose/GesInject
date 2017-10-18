using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using jControles.Clases;


namespace SrvGesInj.Clases
{
    class cClientes
    {

        public static string fncTraeC(string vCampo, string vCli)
        {
            string vValor = "";
            DataRow dr;
            string vWhere = " ccodcli = '" + vCli + "' ";
            dr = cUtil.fncTraeCampos("clientes", vWhere, cParamXml.strOleDBConecDbf, "DBF");
            if (dr != null)
            {
                vValor = dr[vCampo].ToString();
            }
            return vValor;
        }
        

    }
}
