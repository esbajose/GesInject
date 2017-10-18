using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;

namespace SrvGesInj
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            string name = wi.Name;
            SrvGesInj.Clases.cParamXml.Usuario = name;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form frmp = new SrvGesInj.Formularios.frmParametros();
            bool vOk = SrvGesInj.Clases.cParamXml.Carga(frmp);
            if (!vOk)
            {
                SrvGesInj.Formularios.frmParametros.vInicio = "Conec";
                Form frm = new SrvGesInj.Formularios.frmParametros();
                frm.ShowDialog();
                return;
            }
            SrvGesInj.Clases.cParamXml.Carga();
            SrvGesInj.Clases.cParamXml.Carga(frmp);
            SrvGesInj.Clases.cParamXml.Emp = 1;


            Application.Run(new SrvGesInj.Formularios.frmSrvGesInj());
        }
    }
}
