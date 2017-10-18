using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using GesInject.Clases;


namespace GesInject.Formularios
{
    public partial class frmFiltros : Form
    {
        public static string vTabla = "";
        public static string vGenFil = "";
        public static string vEmpresa = "";
        public static string vStrConec = "";
        public static string vFiltros = "";
        public static string vSqlFil = "";
        public static string vObjeto = "";

        public static bool vConEmp = false;


        public frmFiltros()
        {
            InitializeComponent();
        }

        private void frmFiltros_Load(object sender, EventArgs e)
        {
            filtrosBD.vTabla = vTabla;
            filtrosBD.vGenFil = vGenFil;
            filtrosBD.vEmpresa = vEmpresa;
            filtrosBD.vStrConec = vStrConec;
            filtrosBD.vSqlExt = vSqlFil;
            filtrosBD.vObjeto = vObjeto;
            filtrosBD.Inicia();
            sbrLeeConf();

        }

        #region Procesos locales
        private void sbrGrabaConf()
        {
            XmlTextWriter textWriter = null;
            textWriter = cXml.fncGrabaIni(cParamXml.DirMisDoc() + @"\Cfg_Filtros_" + vGenFil + "_" + Application.ProductName + ".xml",
                                "Configuración Filtros " + Application.ProductName, "Parametros");


            cXml.fncGrabaValor(textWriter, "Pos_Left", this.Left.ToString());
            cXml.fncGrabaValor(textWriter, "Pos_Top", this.Top.ToString());
            cXml.fncGrabaValor(textWriter, "Pos_Ancho", this.Width.ToString());
            cXml.fncGrabaValor(textWriter, "Pos_Alto", this.Height.ToString());


            cXml.fncGrabaEnd(textWriter);
        }

        private void sbrLeeConf()
        {
            this.Left = Convert.ToInt16(cXml.fncLeeDato(cParamXml.DirMisDoc() + @"\Cfg_Filtros_" + vGenFil + "_" + Application.ProductName + ".xml", "Parametros", "Pos_Left", "50"));
            this.Top = Convert.ToInt16(cXml.fncLeeDato(cParamXml.DirMisDoc() + @"\Cfg_Filtros_" + vGenFil + "_" + Application.ProductName + ".xml", "Parametros", "Pos_Top", "50"));
            this.Width = Convert.ToInt16(cXml.fncLeeDato(cParamXml.DirMisDoc() + @"\Cfg_Filtros_" + vGenFil + "_" + Application.ProductName + ".xml", "Parametros", "Pos_Ancho", "500"));
            this.Height = Convert.ToInt16(cXml.fncLeeDato(cParamXml.DirMisDoc() + @"\Cfg_Filtros_" + vGenFil + "_" + Application.ProductName + ".xml", "Parametros", "Pos_Alto", "500"));

        }

        #endregion


        private void btAcceptar_Click(object sender, EventArgs e)
        {
            string[][] vFil;

            
            vFil = filtrosBD.fncCargaFiltros(vConEmp);
            vFiltros = vFil[2][0];
            this.Close();

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            vFiltros = "";
            this.Close();

        }

        private void frmFiltros_FormClosing(object sender, FormClosingEventArgs e)
        {
            sbrGrabaConf();
            vTabla = "";
            vGenFil = "";
            vEmpresa = "";
            vStrConec = "";
            vObjeto = "";
            vConEmp = false;

        }
    }
}
