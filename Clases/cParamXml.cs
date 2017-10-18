using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.Xml;
using Microsoft.Win32;
using jControles.Clases;

namespace GesInject.Clases
{
    public class cParamXml
    {

        #region Parametros Generales
        private static int _Pruebas = 0;
        private static string _ErrorFich = string.Empty;
        private static string _Usuario = "";
        private static string _PC = "";

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
        public static string PC
        {
            get { return _PC; }
            set { _PC = value; }
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
        private static string _DirCerMat = "";
        private static string _AlmacenMat = "";

        private static string _PrintGen = "";
        private static string _PrintEtiCajaBolsa = "";
        private static string _ImpEtCajaBolsa = "";
        private static string _ImpCBOF = "";



        private static string _PassAdmin = "";
        private static string _PassCan = "";
        private static string _PassAnex = "";
        private static string _Pass = "";
        private static string _PassUserBD = "";

        private static string _strConec = "";
        private static string _strOleDBConec = "";
        private static string _strOleDBConecDbf = "";
        private static string _strConecProduc_Prueb = "";

        private static string _Debug = "";

        
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
        public static string DirCerMat
        {
            get { return _DirCerMat; }
            set { _DirCerMat = value; }
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
        public static string ImpEtCajaBolsa
        {
            get { return _ImpEtCajaBolsa; }
            set { _ImpEtCajaBolsa = value; }
        }
        public static string ImpCBOF
        {
            get { return _ImpCBOF; }
            set { _ImpCBOF = value; }
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
        public static string PassCan
        {
            get { return _PassCan; }
            set { _PassCan = value; }
        }
        public static string PassAnex
        {
            get { return _PassAnex; }
            set { _PassAnex = value; }
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
        public static string Debug
        {
            get { return _Debug; }
            set { _Debug = value; }
        }
      

        #endregion


        #region Numeros de Serie
        private static string _NSerPedCli = "";
        private static string _NSerPedCliMan = "";
        private static string _NSerPrep = "";
        private static string _NSerPedProv = "";
        private static string _NSerOrdProd = "";
        private static string _NSerAlbProv = "";
        private static string _NSerAlbCli = "";

        public static string NSerPedCli
        {
            get { return _NSerPedCli; }
            set { _NSerPedCli = value; }
        }
        public static string NSerPedCliMan
        {
            get { return _NSerPedCliMan; }
            set { _NSerPedCliMan = value; }
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
        public static string NSerAlbProv
        {
            get { return _NSerAlbProv; }
            set { _NSerAlbProv = value; }
        }
        public static string NSerPrep
        {
            get { return _NSerPrep; }
            set { _NSerPrep = value; }
        }
        public static string NSerAlbCli
        {
            get { return _NSerAlbCli; }
            set { _NSerAlbCli = value; }
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

                if ((_Srv == "")|(_Srv == null))
                {
                    _Srv = "";
                    _Srv = cXml.fncLeeDato(cParam.DirMisDoc() + @"\Param" + Application.ProductName + ".xml", "Parametros", "Srv");
                    if ((_Srv == "") | (_Srv == null)) { _Srv = cUtil.GetSetting(Application.ProductName, "Param", "Srv"); }
                    if ((_Srv == "") | (_Srv == null)) { _Srv = cXml.fncLeeDato(Application.StartupPath + @"\Param" + Application.ProductName + ".xml", "Parametros", "Srv"); }
                }

                if ((_BD == "")|(_BD == null))
                {
                    _BD = "";
                    //_NaviBD = cXml.fncLeeDato(Application.StartupPath + @"\Param" + Application.ProductName + ".xml", "Parametros", "NaviBD");
                    _BD = cXml.fncLeeDato(cParam.DirMisDoc() + @"\Param" + Application.ProductName + ".xml", "Parametros", "BD");
                    if ((_BD == "")|(_BD == null)) { _BD = cUtil.GetSetting(Application.ProductName, "Param", "BD"); }
                    if ((_BD == "")|(_BD == null)) { _BD = cXml.fncLeeDato(Application.StartupPath + @"\Param" + Application.ProductName + ".xml", "Parametros", "BD"); }
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

                    bool vOk = cParam.fncLeeParam(obj.Controls,new cParamXml());
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }



        //public static void fncCargaParam(Control.ControlCollection vControls, string vClave, string vValor)
        //{
        //    string vTag = "";
        //    string vClaveObj = "";
        //    Cryp.Crypto oCryp = new Cryp.Crypto();

        //    foreach (Control obj in vControls)
        //    {
        //        if (obj.Controls.Count > 0)
        //        {
        //            fncCargaParam(obj.Controls, vClave, vValor);
        //        }
        //        vTag = "";
        //        if (obj.Tag != null)
        //        {
        //            vTag = obj.Tag.ToString();
        //            //int vPos = vTag.LastIndexOf("#");
        //            //vClaveObj  = vTag.Substring(0, vPos);
        //            vClaveObj = cUtil.Piece(vTag, "#", 1);

        //            if (vValor == "") { vValor = cUtil.Piece(vTag, "#", 4); }
        //            if (vClaveObj == vClave)
        //            {
        //                string vPass = vClave.Substring(0, 4);
        //                if (vPass == "Pass")
        //                {
        //                    if (vValor != null)
        //                    {
        //                        vValor = oCryp.Decryp(vValor, cConstantes.Cyptokey);
        //                    }
        //                }

        //                if (obj.GetType().ToString() == "System.Windows.Forms.CheckBox")
        //                {
        //                    ((CheckBox)obj).Checked = Convert.ToBoolean(vValor);
        //                }

        //                if (obj.GetType().ToString() == "System.Windows.Forms.TextBox")
        //                {
        //                    obj.Text = vValor;
        //                }

        //            }
        //        }

        //    }
        //}
        //public static void fncCargaParam(Control.ControlCollection vControls)
        //{
        //    string vTag = "";
        //    string vClaveObj = "";
        //    string vClave = "";
        //    string vDes = "";
        //    string vValor = "";
        //    string vSis = "";
        //    string vDef = "";

        //    Cryp.Crypto oCryp = new Cryp.Crypto();


        //    foreach (Control obj in vControls)
        //    {
        //        if (obj.Controls.Count > 0)
        //        {
        //            fncCargaParam(obj.Controls);
        //        }
        //        vTag = "";
        //        if (obj.Tag != null)
        //        {
        //            vTag = obj.Tag.ToString();
        //        }
        //        if (vTag != "")
        //        {
        //            vClave = cUtil.Piece(vTag, "#", 1);
        //            vDes = cUtil.Piece(vTag, "#", 2);
        //            vSis = cUtil.Piece(vTag, "#", 3);
        //            vDef = cUtil.Piece(vTag, "#", 4);
        //            if (vDef == "Pass")
        //            {
        //                vDef = cUtil.Piece(vTag, "#", 5);
        //                vDef = oCryp.Encryp(vDef, cConstantes.Cyptokey);
        //            }
        //            //vValor = cXml.fncLeeDato(Application.StartupPath + @"\Param" + Application.ProductName + ".xml", "Parametros", vClave);
        //            vValor = cXml.fncLeeDato(DirMisDoc() + @"\Param" + Application.ProductName + ".xml", "Parametros", vClave);
        //            if (vValor == "") { vValor = cUtil.GetSetting(Application.ProductName, "Param", vClave); }
        //            if (vValor == "") { vValor = cXml.fncLeeDato(Application.StartupPath + @"\Param" + Application.ProductName + ".xml", "Parametros", vClave); }
        //            if ((vValor == "") | (vValor == null)) { vValor = vDef; }

        //            vClaveObj = cUtil.Piece(vTag, "#", 1);
        //            if (vClaveObj == vClave)
        //            {
        //                string vPass = vClave.Substring(0, 4);
        //                if (vPass == "Pass")
        //                {
        //                    if (vValor != null)
        //                    {
        //                        vValor = oCryp.Decryp(vValor, cConstantes.Cyptokey);
        //                    }
        //                }

        //                if (obj.GetType().ToString() == "System.Windows.Forms.CheckBox")
        //                {
        //                    ((CheckBox)obj).Checked = Convert.ToBoolean(vValor);
        //                }


        //                if (obj.GetType().ToString() == "System.Windows.Forms.TextBox")
        //                {
        //                    obj.Text = vValor;
        //                }

        //            }
        //        }
        //    }
        //}


        //public static bool Graba(Control.ControlCollection vControls, bool vSistema)
        //{

        //    return Graba(vControls, vSistema, false);
        //}

        //public static bool Graba(Control.ControlCollection vControls, bool vSistema, bool vEnOrigen)
        //{
        //    XmlTextWriter textWriter = null;
        //    if (vEnOrigen)
        //    {
        //        textWriter = cXml.fncGrabaIni(Application.StartupPath + @"\Param" + Application.ProductName + ".xml",
        //                         "Parametros para la aplicación " + Application.ProductName, "Parametros");
        //    }
        //    else
        //    {
        //        textWriter = cXml.fncGrabaIni(DirMisDoc() + @"\Param" + Application.ProductName + ".xml",
        //                         "Parametros para la aplicación " + Application.ProductName, "Parametros");
        //    }

        //    GrabaXml(vControls, vSistema, textWriter);

        //    cXml.fncGrabaEnd(textWriter);

        //    return true;
        //}

        //public static bool GrabaXml(Control.ControlCollection vControls, bool vSistema, XmlTextWriter textWriter)
        //{
        //    string vClave = "";
        //    string vDes = "";
        //    string vTag = "";
        //    string vValor = "";
        //    string vSis = "";

        //    //Crypto oCrypto = new Crypto();
        //    foreach (Control obj in vControls)
        //    {
        //        if (obj.Controls.Count > 0)
        //        {
        //            GrabaXml(obj.Controls, vSistema, textWriter);
        //        }
        //        vTag = "";
        //        if (obj.Tag != null)
        //        {
        //            vTag = obj.Tag.ToString();
        //        }
        //        if (vTag != "")
        //        {
        //            vClave = cUtil.Piece(vTag, "#", 1);
        //            vDes = cUtil.Piece(vTag, "#", 2);
        //            vSis = cUtil.Piece(vTag, "#", 3);
        //            vValor = obj.Text;

        //            if (obj.GetType().ToString() == "System.Windows.Forms.CheckBox")
        //            {
        //                vValor = ((CheckBox)obj).Checked.ToString();
        //            }


        //            if (vValor != "")
        //            {
        //                if ((vSistema == false) & (vSis != "L"))
        //                {
        //                    cXml.fncGrabaValor(textWriter, vClave, vValor);
        //                }
        //            }
        //            if (vSis == "L")
        //            {
        //                //if (vClave == "PassAdmin")
        //                //{
        //                //    vValor = oCrypto.Encryp(vValor, cConstantes.Cyptokey);
        //                //}

        //                cXml.fncGrabaValor(textWriter, vClave, vValor);
        //            }

        //        }


        //    }

        //    return true;
        //}
        //public static bool GrabaXml(Control gr, XmlTextWriter textWriter)
        //{
        //    cXml.fncGrabaValor(textWriter, "Width", gr.Width.ToString());
        //    cXml.fncGrabaValor(textWriter, "Heigth", gr.Height.ToString());
        //    cXml.fncGrabaValor(textWriter, "Top", gr.Top.ToString());
        //    cXml.fncGrabaValor(textWriter, "Left", gr.Left.ToString());
        //    return true;
        //}
        //public static void fncGrabaParam(Control.ControlCollection vControls, bool vSistema)
        //{
        //    string vClave = "";
        //    string vDes = "";
        //    string vTag = "";
        //    string vValor = "";
        //    string vSis = "";

        //    //Crypto oCrypto = new Crypto();
        //    foreach (Control obj in vControls)
        //    {
        //        if (obj.Controls.Count > 0)
        //        {
        //            fncGrabaParam(obj.Controls, vSistema);
        //        }
        //        vTag = "";
        //        if (obj.Tag != null)
        //        {
        //            vTag = obj.Tag.ToString();
        //        }
        //        if (vTag != "")
        //        {
        //            vClave = cUtil.Piece(vTag, "#", 1);
        //            vDes = cUtil.Piece(vTag, "#", 2);
        //            vSis = cUtil.Piece(vTag, "#", 3);
        //            vValor = obj.Text;


        //            if (obj.GetType().ToString() == "System.Windows.Forms.CheckBox")
        //            {
        //                vValor = ((CheckBox)obj).Checked.ToString();
        //            }

        //            if (vValor != "")
        //            {
        //                if ((vSistema == false) & (vSis != "L"))
        //                {
        //                    //cUtil.SaveSetting(Application.ProductName, "Param", vClave, vValor);
        //                    //cXml.fncGuardaDato(Application.StartupPath + @"\Param" + Application.ProductName + ".xml", "Parametros", vClave, vValor);
        //                    cXml.fncGuardaDato(DirMisDoc() + @"\Param" + Application.ProductName + ".xml", "Parametros", vClave, vValor);

        //                }
        //            }
        //            if (vSis == "L")
        //            {
        //                //if (vClave == "PassAdmin")
        //                //{
        //                //    vValor = oCrypto.Encryp(vValor, cConstantes.Cyptokey);
        //                //}

        //                //cUtil.SaveSetting(Application.ProductName, "Param", vClave, vValor);
        //                //cXml.fncGuardaDato(Application.StartupPath + @"\Param" + Application.ProductName + ".xml", "Parametros", vClave, vValor);
        //                cXml.fncGuardaDato(DirMisDoc() + @"\Param" + Application.ProductName + ".xml", "Parametros", vClave, vValor);

        //            }

        //        }

        //    }
        //}

        //public static void fncGrabaParamXml(string vClave, string vValor)
        //{
        //    cXml.fncGuardaDato(DirMisDoc() + @"\Param" + Application.ProductName + ".xml", "Parametros", vClave, vValor);

        //}


        //public static bool fncLeeParam(Control.ControlCollection vControls)
        //{
        //    Cryp.Crypto oCryp = new Cryp.Crypto();

        //    string vClave = "";
        //    string vDes = "";
        //    string vTag = "";
        //    string vValor = "";
        //    string vSis = "";
        //    string vDef = "";

        //    foreach (Control obj in vControls)
        //    {
        //        if (obj.Controls.Count > 0)
        //        {
        //            fncLeeParam(obj.Controls);
        //        }
        //        vTag = "";
        //        if (obj.Tag != null)
        //        {
        //            vTag = obj.Tag.ToString();
        //        }
        //        if (vTag != "")
        //        {
        //            vClave = cUtil.Piece(vTag, "#", 1);
        //            vDes = cUtil.Piece(vTag, "#", 2);
        //            vSis = cUtil.Piece(vTag, "#", 3);
        //            vDef = cUtil.Piece(vTag, "#", 4);
        //            if (vDef == "Pass")
        //            {
        //                vDef = cUtil.Piece(vTag, "#", 5);
        //                vDef = oCryp.Encryp(vDef, cConstantes.Cyptokey);
        //            }
        //            //vValor = cXml.fncLeeDato(Application.StartupPath + @"\Param" + Application.ProductName + ".xml", "Parametros", vClave);
        //            vValor = cXml.fncLeeDato(DirMisDoc() + @"\Param" + Application.ProductName + ".xml", "Parametros", vClave);
        //            if (vValor == "")
        //            {
        //                vValor = cUtil.GetSetting(Application.ProductName, "Param", vClave);
        //            }
        //            if (vValor == "")
        //            {
        //                vValor = cXml.fncLeeDato(Application.StartupPath + @"\Param" + Application.ProductName + ".xml", "Parametros", vClave);
        //            }
        //            if ((vValor == "") | (vValor == null)) { vValor = vDef; }
        //            string vPass = vClave.Substring(0, 4);
        //            if (vPass == "Pass")
        //            {
        //                if (vValor != null)
        //                {
        //                    vValor = oCryp.Decryp(vValor, cConstantes.Cyptokey);
        //                }
        //            }


        //            cParamXml oParam = new cParamXml();
        //            PropertyInfo vProp = oParam.GetType().GetProperty(vClave);
        //            if (vProp != null)
        //            {
        //                string vVal = vValor;
        //                vProp.SetValue(oParam, vVal, null);
        //            }

        //        }

        //    }
        //    return true;
        //}

        //public static string DirMisDoc()
        //{
        //    RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders");
        //    string s = "";
        //    if (rk != null)
        //        s = (string)rk.GetValue("Personal");
        //    //
        //    return s;
        //}


    }
}