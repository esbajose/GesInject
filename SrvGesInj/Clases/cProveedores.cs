using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using jControles.Clases;


namespace SrvGesInj.Clases
{
    class cProveedores
    {



        public static string fncTraeC(string vCampo, string vProv)
        {
            string vValor = "";
            DataRow dr;
            string vWhere = " ccodpro = '" + vProv + "' ";
            dr = cUtil.fncTraeCampos("proveedo", vWhere, cParamXml.strOleDBConecDbf, "DBF");
            if (dr != null)
            {
                vValor = dr[vCampo].ToString();
            }
            return vValor;
        }
        

    }
}
