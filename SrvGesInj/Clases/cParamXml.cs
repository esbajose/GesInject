using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.Xml;
using Microsoft.Win32;
using jControles.Clases;


namespace SrvGesInj.Clases
{
    public class cParamXml
    {

        #region Parametros Generales
        private static int _Pruebas = 0;
        private static string _ErrorFich = string.Empty;
        private static string _Usuario = "";

        public static int Pruebas
        {
            get { return _Pruebas; }
            set { _Pruebas = value; }
        }
        public static string ErrorFich
        {
            get { return _ErrorFich; }
            set { _ErrorFich = value; }
        }
        public static string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }


        #region parametros de Conexion
        private static string _UsuarioBD = "";
        private static int _Emp = 1;
        private static string _Srv = "";
        private static string _BD = "";
        private static string _Fich = "";
        private static string _Imp = "";
        private static string _Form = "";
        private static string _DirDocDbf = "";
        private static string _DirXML = "";
        private static string _DirImProd = "";
        private static string _DirDocProd = "";
        private static string _AlmacenMat = "";

        private static string _PrintGen = "";
        private static string _PrintEtiCajaBolsa = "";

        private static string _PassAdmin = "";
        private static string _Pass = "";
        private static string _PassUserBD = "";

        private static string _strConec = "";
        private static string _strOleDBConec = "";
        private static string _strOleDBConecDbf = "";
        private static string _strConecProduc_Prueb = "";

        public static string AlmacenMat
        {
            get { return _AlmacenMat; }
            set { _AlmacenMat = value; }
        }
        public static string UsuarioBD
        {
            get { return _UsuarioBD; }
            set { _UsuarioBD = value; }
        }
        public static string DirDocDbf
        {
            get { return _DirDocDbf; }
            set { _DirDocDbf = value; }
        }
        public static string DirXML
        {
            get { return _DirXML; }
            set { _DirXML = value; }
        }
        public static string DirImProd
        {
            get { return _DirImProd; }
            set { _DirImProd = value; }
        }
        public static string DirDocProd
        {
            get { return _DirDocProd; }
            set { _DirDocProd = value; }
        }
        public static string PrintGen
        {
            get { return _PrintGen; }
            set { _PrintGen = value; }
        }
        public static string PrintEtiCajaBolsa
        {
            get { return _PrintEtiCajaBolsa; }
            set { _PrintEtiCajaBolsa = value; }
        }
        public static int Emp
        {
            get { return _Emp; }
            set { _Emp = value; }
        }
        public static string Imp
        {
            get { return _Imp; }
            set { _Imp = value; }
        }
        public static string Srv
        {
            get { return _Srv; }
            set { _Srv = value; }
        }
        public static string BD
        {
            get { return _BD; }
            set { _BD = value; }
        }
        public static string Fich
        {
            get { return _Fich; }
            set { _Fich = value; }
        }
        public static string Form
        {
            get { return _Form; }
            set { _Form = value; }
        }
        public static string PassAdmin
        {
            get { return _PassAdmin; }
            set { _PassAdmin = value; }
        }
        public static string PassUserBD
        {
            get { return _PassUserBD; }
            set { _PassUserBD = value; }
        }
        public static string Pass
        {
            get { return _Pass; }
            set { _Pass = value; }
        }
        public static string strConec
        {
            get
            {
                if (_strConec == "")
                {
                    Carga();
                }
                return _strConec;
            }
            set { _strConec = value; }
        }
        public static string strConecProduc_Prueb
        {
            get { return _strConecProduc_Prueb; }
            set { _strConecProduc_Prueb = value; }
        }
        public static string strOleDBConec
        {
            get { return _strOleDBConec; }
            set { _strOleDBConec = value; }
        }
        public static string strOleDBConecDbf
        {
            get { return _strOleDBConecDbf; }
            set { _strOleDBConecDbf = value; }
        }

        #endregion


        #region Numeros de Serie
        private static string _NSerPedCli = "";
        private static string _NSerPedProv = "";
        private static string _NSerOrdProd = "";
        private static string _NSerOrdAlbProv = "";
        private static string _NSerOrdAlbCli = "";
        private static string _ActProv = "False";
        private static string _ActCli = "False";
        private static string _ActPedCli = "False";


        public static string NSerPedCli
        {
            get { return _NSerPedCli; }
            set { _NSerPedCli = value; }
        }
        public static string NSerPedProv
        {
            get { return _NSerPedProv; }
            set { _NSerPedProv = value; }
        }
        public static string NSerOrdProd
        {
            get { return _NSerOrdProd; }
            set { _NSerOrdProd = value; }
        }
        public static string NSerOrdAlbProv
        {
            get { return _NSerOrdAlbProv; }
            set { _NSerOrdAlbProv = value; }
        }
        public static string NSerOrdAlbCli
        {
            get { return _NSerOrdAlbCli; }
            set { _NSerOrdAlbCli = value; }
        }
        public static string ActProv
        {
            get { return _ActProv; }
            set { _ActProv = value; }
        }
        public static string ActCli
        {
            get { return _ActCli; }
            set { _ActCli = value; }
        }
        public static string ActPedCli
        {
            get { return _ActPedCli; }
            set { _ActPedCli = value; }
        }

        #endregion




        #endregion


        public static bool Carga()
        {
            try
            {
                //_EstdSrv = cUtil.GetSetting(Application.ProductName, "Param", "EstdSrv");
                //_EstdBD = cUtil.GetSetting(Application.ProductName, "Param", "EstdBD");
                //_NaviSrv  = cXml.fncLeeDato(Application.StartupPath + @"\Param" + Application.ProductName + ".xml", "Parametros", "NaviSrv");

                if ((_Srv == "") | (_Srv == null))
                {
                    _Srv = "";
                    _Srv = cXml.fncLeeDato(cParam.DirMisDoc() + @"\Param" + Application.ProductName + ".xml", "Parametros", "Srv");
                    if ((_Srv == "") | (_Srv == null)) { _Srv = cUtil.GetSetting(Application.ProductName, "Param", "Srv"); }
                    if ((_Srv == "") | (_Srv == null)) { _Srv = cXml.fncLeeDato(Application.StartupPath + @"\Param" + Application.ProductName + ".xml", "Parametros", "Srv"); }
                }

                if ((_BD == "") | (_BD == null))
                {
                    _BD = "";
                    //_NaviBD = cXml.fncLeeDato(Application.StartupPath + @"\Param" + Application.ProductName + ".xml", "Parametros", "NaviBD");
                    _BD = cXml.fncLeeDato(cParam.DirMisDoc() + @"\Param" + Application.ProductName + ".xml", "Parametros", "BD");
                    if ((_BD == "") | (_BD == null)) { _BD = cUtil.GetSetting(Application.ProductName, "Param", "BD"); }
                    if ((_BD == "") | (_BD == null)) { _BD = cXml.fncLeeDato(Application.StartupPath + @"\Param" + Application.ProductName + ".xml", "Parametros", "BD"); }
                }

                _strConec = "Server=" + cParamXml.Srv +
                    "; " + "database=" + cParamXml.BD +
                    "; integrated security=no;User Id = " + cParamXml.UsuarioBD +
                    ";Password = " + cParamXml.PassUserBD;

                if ((cParamXml.BD == "") | (cParamXml.Srv == ""))
                {
                    return false;
                }
                else
                {
                    //_strConecCosmic = "Server=" + cParamXml.NaviSrv +
                    //    "; " + "database=" + cParamXml.NaviBD +
                    //    "; integrated security=yes";

                    _strConec = "Server=" + cParamXml.Srv +
                        "; " + "database=" + cParamXml.BD +
                        "; integrated security=no;User Id = " + cParamXml.UsuarioBD +
                        ";Password = " + cParamXml.PassUserBD;
                    //"; integrated security=no;User Id = ODBCUSER;Password = 0odbcuser";
                    _strConecProduc_Prueb = _strConec;

                    _strOleDBConec = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False" +
                        ";Initial Catalog=" + cParamXml.BD +
                        ";Data Source=" + cParamXml.Srv +
                        ";Connect Timeout=15;Packet Size=4096";



                    _strOleDBConecDbf = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=dBASE IV;Data Source='" + cParamXml.DirDocDbf + "'";

                    return true;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool Carga(Form frm)
        {
            try
            {
                foreach (Control obj in frm.Controls)
                {

                    bool vOk = cParam.fncLeeParam(obj.Controls, new cParamXml());
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }



    }
}