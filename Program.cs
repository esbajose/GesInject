using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.Net;




namespace GesInject
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
            GesInject.Clases.cParamXml.Usuario = name;
            GesInject.Clases.cParamXml.PC = Dns.GetHostName();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form frmp = new GesInject.Formularios.frmParametros();
            bool vOk = GesInject.Clases.cParamXml.Carga(frmp);
            if (!vOk)
            {
                GesInject.Formularios.frmParametros.vInicio = "Conec";
                Form frm = new GesInject.Formularios.frmParametros();
                frm.ShowDialog();
                return;
            }
            GesInject.Clases.cParamXml.Carga();
            GesInject.Clases.cParamXml.Carga(frmp);
            GesInject.Clases.cParamXml.Emp = 1;

            Application.Run(new GesInject.Formularios.frmPrinc());
            //Application.Run(new Form1());
        }
    }
}
