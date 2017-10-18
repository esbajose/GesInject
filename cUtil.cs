using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using GesInject.Formularios;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Net;
using jControles.Formularios;





namespace GesInject.Clases
{
    class cUtil
    {
        private string _Error = "";
        private int _NumError = 0;
        public string Error
        {
            get { return _Error; }
            set { _Error = value; }
        }
        public int NumError
        {
            get { return _NumError; }
            set { _NumError = value; }
        }

        public static string[] vNombreCampo;
        public static string[] vNombreCol;


        public int asc(char[] c)
        {
            return (int)c[0];
        }

        public bool fncCopiaFichero(string vOrig, string vDest, bool vBorrarOrig)
        {
            try
            {
                File.Copy(vOrig, vDest);
                if (vBorrarOrig) { File.Delete(vOrig); }

                _Error = "";
                return true;
            }
            catch (Exception ex)
            {
                _Error = ex.Message;

                if (_Error.LastIndexOf("ya existe") > 0)
                {
                    if (vBorrarOrig) { File.Delete(vOrig); }
                }

                return false;
            }

        }
        public void sbrExtraeDatos(string vLinea, int[] Pos, ref string[] Campos)
        {
            int vPos = 0;
            for (int i = 0; i < Campos.Length; i++)
            {
                Campos[i] = "";
            }
            for (int i = 0; i < Pos.Length; i++)
            {
                Campos[i + 1] = vLinea.Substring(vPos, Pos[i]).Trim();
                vPos = vPos + Pos[i];
            }

        }
        public string fncFechaStr()
        {
            string vAny = DateTime.Now.Year.ToString();
            string vMes = DateTime.Now.Month.ToString();
            string vDia = DateTime.Now.Day.ToString();
            string vHora = DateTime.Now.Hour.ToString();
            string vMin = DateTime.Now.Minute.ToString();
            string vSeg = DateTime.Now.Second.ToString();
            string vFecha = vAny + vMes + vDia + vHora + vMin + vSeg;
            return vFecha;
        }
        public static bool IsFileInUse(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    using (FileStream inputStream = File.Open(filename,
                                                                    FileMode.Open,
                                                                    FileAccess.Read,
                                                                    FileShare.None))
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            catch (IOException)
            {
                return true;
            }
        }
        public static void SaveSetting(string appName, string section, string key, string setting)
        {
            // Los datos se guardan en:
            // HKEY_CURRENT_USER\Software\VB and VBA Program Settings
            RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\VB and VBA Program Settings\" +
                                                                appName + "\\" + section);
            rk.SetValue(key, setting);

        }
        public static string GetSetting(string appName, string section, string key)
        {
            return GetSetting(appName, section, key, "");
        }
        public static string GetSetting(string appName, string section, string key, string sDefault)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\VB and VBA Program Settings\" +
                                                              appName + "\\" + section);
            string s = sDefault;
            if (rk != null)
                s = (string)rk.GetValue(key);
            //
            return s;
        }
        public static void LogonSaveSetting(string key, string setting)
        {

            // Los datos se guardan en:
            // HKEY_CURRENT_USER\Software\VB and VBA Program Settings
            try
            {

                RegistryKey rk = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Winlogon");
                rk.SetValue(key, setting);

            }
            catch
            {
                //string vError = "error";
            }
        }
        public static string Piece(string vtxt, string vcar, int pos)
        {
            int[] PosSep;
            int n;
            int Pini;
            int Pfin;
            int Tlon;
            PosSep = new int[2250];
            PosSep[0] = 0;
            n = 0;
            if (vtxt == null) { return ""; }
            if (vtxt.Length == 0) { return ""; }
            vtxt = vtxt + vcar;
            for (int T1 = 1; T1 < vtxt.Length; T1++)
            {
                n = vtxt.IndexOf(vcar, n);
                if (n == -1) { break; }
                PosSep[T1] = n;
                n = n + 1;
                if (T1 == pos)
                {
                    if ((T1 - 1) == 0) { Pini = PosSep[T1 - 1]; }
                    else { Pini = PosSep[T1 - 1] + 1; }

                    Pfin = n - 1;
                    Tlon = Pfin - Pini;
                    return vtxt.Substring(Pini, Tlon);
                }
            }
            return "";
        }
        public static string Piece(string vtxt, string vcar, int pos, int pos2)
        {
            string vRes = "";
            for (int T1 = pos; T1 < (pos2 + 1); T1++)
            {
                vRes = vRes + Piece(vtxt, vcar, T1) + vcar;
            }
            vRes = vRes.Substring(0, vRes.Length - 1);
            return vRes;
        }
        public static string SetPiece(string vtxt, string vcar, int pos, string vValor)
        {

            string[] vDatos = vtxt.Split('#');
            vDatos[pos - 1] = vValor;
            string vNewLit = "";
            for (int i = 0; i < vDatos.Length; i++)
            {
                vNewLit = vNewLit + vcar + vDatos[i];
            }
            vNewLit = vNewLit.Substring(1, vNewLit.Length - 1);

            return vNewLit;
        }

        public static bool fncVerifSQLConec(string vstrconec)
        {
            bool vOk = false;
            SqlConnection ConecSQL = new SqlConnection(vstrconec);
            try
            {
                ConecSQL.Open();
                vOk = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                vOk = false;
            }
            return vOk;
        }

        public static SqlConnection SQLConec(string vstrconec)
        {
            SqlConnection ConecSQL = new SqlConnection(vstrconec);
            return ConecSQL;
        }

        public static string fncCargaValoresDBF(string vDBF, string vTabla)
        {
            DataTable dt;
            OleDbDataAdapter da;
            string vValues = "";
            int vCont = 0;
            string vSql = "";
            string vTipo = "";

            System.Data.OleDb.OleDbConnection dbConec = new System.Data.OleDb.OleDbConnection();
            dbConec.ConnectionString = @"PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + vDBF;
            dbConec.Open();
            try
            {
                vSql = "Select * From " + vTabla;

                da = new OleDbDataAdapter(vSql, dbConec);
                dt = new DataTable();
                da.Fill(dt);
                vValues = "Values (";
                vCont = 0;
                foreach (DataColumn dc in dt.Columns)
                {
                    vCont = vCont + 1;
                    vTipo = dc.DataType.ToString();
                    if (vTipo == "System.DateTime")
                    {
                        vValues = vValues + "'" + "[?" + vCont.ToString() + "T]',";
                    }
                    if (vTipo == "System.Decimal")
                    {
                        vValues = vValues + "" + "[?" + vCont.ToString() + "D],";
                    }
                    if (vTipo == "System.String")
                    {
                        vValues = vValues + "'" + "[?" + vCont.ToString() + "S]',";
                    }
                    if (vTipo == "System.Double")
                    {
                        vValues = vValues + "" + "[?" + vCont.ToString() + "D],";
                    }
                    if (vTipo == "System.Boolean")
                    {
                        vValues = vValues + "" + "[?" + vCont.ToString() + "B],";
                    }
                    if (vTipo == "System.Int32")
                    {
                        vValues = vValues + "" + "[?" + vCont.ToString() + "D],";
                    }

                }
                vValues = vValues.Substring(0, vValues.Length - 1);
                vValues = vValues + ")";


                dbConec.Close();
                return vValues;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al conectar o recuperar los datos:\n" +
                    ex.Message, "Conectar con la base",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }


        }
        public static string fncCargaValoresDBF(string vDBF, string vTabla, string[] vDatos)
        {
            DataTable dt;
            OleDbDataAdapter da;
            string vValues = "";
            int vCont = 0;
            string vSql = "";
            string vTipo = "";

            System.Data.OleDb.OleDbConnection dbConec = new System.Data.OleDb.OleDbConnection();
            dbConec.ConnectionString = @"PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + vDBF;
            dbConec.Open();
            try
            {
                vSql = "Select * From " + vTabla;

                da = new OleDbDataAdapter(vSql, dbConec);
                dt = new DataTable();
                da.Fill(dt);
                vValues = "Values (";
                vCont = 0;
                foreach (DataColumn dc in dt.Columns)
                {
                    vCont = vCont + 1;
                    vTipo = dc.DataType.ToString();
                    if (vTipo == "System.DateTime")
                    {
                        if (vDatos[vCont] == "") { vDatos[vCont] = "01/01/2010"; }
                        vValues = vValues + "'" + vDatos[vCont] + "',";
                    }
                    if (vTipo == "System.Decimal")
                    {
                        if (vDatos[vCont] == "") { vDatos[vCont] = "0"; }
                        vValues = vValues + vDatos[vCont] + ",";
                    }
                    if (vTipo == "System.String")
                    {
                        vValues = vValues + "'" + vDatos[vCont] + "',";
                    }
                    if (vTipo == "System.Double")
                    {
                        if (vDatos[vCont] == "") { vDatos[vCont] = "0"; }
                        vValues = vValues + vDatos[vCont] + ",";
                    }
                    if (vTipo == "System.Boolean")
                    {
                        if (vDatos[vCont] == "") { vDatos[vCont] = "0"; }
                        vValues = vValues + vDatos[vCont] + ",";
                    }

                }
                vValues = vValues.Substring(0, vValues.Length - 1);
                vValues = vValues + ")";


                dbConec.Close();
                return vValues;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al conectar o recuperar los datos:\n" +
                    ex.Message, "Conectar con la base",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }


        }
        public static string fncCargaValoresDBF(string vDBF, string vTabla, string[] vDatos, ref string vCampos)
        {
            DataTable dt;
            OleDbDataAdapter da;
            string vValues = "";
            int vCont = 0;
            string vSql = "";
            string vTipo = "";

            System.Data.OleDb.OleDbConnection dbConec = new System.Data.OleDb.OleDbConnection();
            dbConec.ConnectionString = @"PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + vDBF;
            dbConec.Open();
            try
            {
                vSql = "Select * From " + vTabla;

                da = new OleDbDataAdapter(vSql, dbConec);
                dt = new DataTable();
                da.Fill(dt);
                vValues = "Values (";
                vCampos = "(";
                vCont = 0;
                foreach (DataColumn dc in dt.Columns)
                {
                    vCont = vCont + 1;
                    vTipo = dc.DataType.ToString();
                    if (vDatos[vCont] != "")
                    {
                        vCampos = vCampos + dc.ColumnName.ToString() + ",";
                        if (vTipo == "System.DateTime")
                        {
                            vValues = vValues + "'" + vDatos[vCont] + "',";
                        }
                        if (vTipo == "System.Decimal")
                        {
                            if (vDatos[vCont] == "") { vDatos[vCont] = "0"; }
                            vValues = vValues + vDatos[vCont] + ",";
                        }
                        if (vTipo == "System.String")
                        {
                            vValues = vValues + "'" + vDatos[vCont] + "',";
                        }
                        if (vTipo == "System.Double")
                        {
                            if (vDatos[vCont] == "") { vDatos[vCont] = "0"; }
                            vValues = vValues + vDatos[vCont] + ",";
                        }
                        if (vTipo == "System.Boolean")
                        {
                            if (vDatos[vCont] == "") { vDatos[vCont] = "0"; }
                            vValues = vValues + vDatos[vCont] + ",";
                        }
                    }
                }
                vValues = vValues.Substring(0, vValues.Length - 1);
                vValues = vValues + ")";

                vCampos = vCampos.Substring(0, vCampos.Length - 1);
                vCampos = vCampos + ")";


                dbConec.Close();
                return vValues;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al conectar o recuperar los datos:\n" +
                    ex.Message, "Conectar con la base",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }


        }
        public static string fncReplaceValoresDBF(string[] vDatos, string vCampos, int vNumCampos)
        {
            try
            {
                for (int i = 1; i < vNumCampos; i++)
                {
                    //string vBusca = "[?" + i.ToString();
                    string vBusca = "]";
                    int vPos = vCampos.IndexOf(vBusca);
                    string vLetra = vCampos.Substring(vPos - 1, 1);
                    string vDato = vDatos[i];
                    if (vLetra == "D")
                    {
                        if (vDato == "") { vDato = "0"; }
                        vCampos = vCampos.Replace("[?" + i.ToString() + "D]", vDato);
                    }
                    if (vLetra == "S")
                    {
                        vCampos = vCampos.Replace("[?" + i.ToString() + "S]", vDato);
                    }
                    if (vLetra == "B")
                    {
                        if (vDato == "") { vDato = "0"; }
                        vCampos = vCampos.Replace("[?" + i.ToString() + "B]", vDato);
                    }
                    if (vLetra == "T")
                    {
                        if (vDato == "") { vDato = "01/01/1753"; }
                        //if (vDato == "") { vDato = "01/01/2000"; }
                        vCampos = vCampos.Replace("[?" + i.ToString() + "T]", vDato);
                    }
                }
                return vCampos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }


        }

        public static string fncCargaValoresSQL(string vTabla)
        {
            return fncCargaValoresSQL(vTabla, true);

        }
        public static string fncCargaValoresSQL(string vTabla, bool Parentesis)
        {
            DataTable dt;
            SqlDataAdapter da;
            string vValues = "";
            string vCamposFalta = "";
            int vCont = 0;
            string vSql = "";
            string vTipo = "";
            string vCampo = "";
            string vCampos = "";
            bool vOk = false;
            SqlConnection dbConec = new SqlConnection();
            dbConec.ConnectionString = cParamXml.strConec;
            dbConec.Open();
            try
            {

                //vSql = "SELECT COLUMN_NAME AS Campo,ORDINAL_POSITION AS No,DATA_TYPE AS Tipo FROM information_schema.columns WHERE table_name = '" + vTabla + "'";
                vSql = "Select top(1) * from " + vTabla;
                da = new SqlDataAdapter(vSql, dbConec);
                dt = new DataTable();
                da.Fill(dt);
                vValues = "Values (";
                if (Parentesis)
                {
                    vCampos = "(";
                }
                else
                {
                    vCampos = "";
                }
                vCont = 1;
                //foreach (DataRow dr in dt.Rows )
                foreach (DataColumn dc in dt.Columns)
                {
                    vTipo = dc.DataType.ToString();
                    vCampo = dc.ColumnName.ToString();
                    //vTipo = dr["Tipo"].ToString();
                    //vCampo = dr["Campo"].ToString();

                    if (vTipo == "System.DateTime")
                    {
                        vValues = vValues + "'" + "[?" + vCont.ToString() + "T]',";
                        vCampos = vCampos + "[" + vCampo + "],";
                        vOk = true;
                    }
                    if (vTipo == "System.Decimal")
                    {
                        vValues = vValues + "" + "[?" + vCont.ToString() + "D],";
                        vCampos = vCampos + "[" + vCampo + "],";
                        vOk = true;
                    }
                    if (vTipo == "System.String")
                    {
                        vValues = vValues + "'" + "[?" + vCont.ToString() + "S]',";
                        vCampos = vCampos + "[" + vCampo + "],";
                        vOk = true;
                    }
                    if (vTipo == "System.Double")
                    {
                        vValues = vValues + "" + "[?" + vCont.ToString() + "D],";
                        vCampos = vCampos + "[" + vCampo + "],";
                        vOk = true;
                    }
                    if (vTipo == "System.Boolean")
                    {
                        vValues = vValues + "" + "[?" + vCont.ToString() + "B],";
                        vCampos = vCampos + "[" + vCampo + "],";
                        vOk = true;
                    }
                    if ((vTipo == "System.Byte[]") & (vCampo != "timestamp"))
                    {
                        vValues = vValues + "'" + "[?" + vCont.ToString() + "M]',";
                        vCampos = vCampos + "[" + vCampo + "],";
                        vOk = true;
                    }

                    if (vTipo == "System.Int32")
                    {
                        vValues = vValues + "" + "[?" + vCont.ToString() + "D],";
                        vCampos = vCampos + "[" + vCampo + "],";
                        vOk = true;
                    }
                    if (vTipo == "System.Byte")
                    {
                        vValues = vValues + "" + "[?" + vCont.ToString() + "Y],";
                        vCampos = vCampos + "[" + vCampo + "],";
                        vOk = true;
                    }

                    if (vOk == false)
                    {
                        vCamposFalta = vCamposFalta + "---" + vTipo;
                    }
                    else
                    {
                        vCont = vCont + 1;

                    }
                    vOk = false;
                }
                vValues = vValues.Substring(0, vValues.Length - 1);
                vValues = vValues + ")";
                vCampos = vCampos.Substring(0, vCampos.Length - 1);
                if (Parentesis)
                {
                    vCampos = vCampos + ")";
                }

                dbConec.Close();
                return vValues + "#" + vCampos + "#" + vCont;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al conectar o recuperar los datos:\n" +
                    ex.Message, "Conectar con la base",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }


        }
        public static string fncCargaValoresSQL(string vTabla, string vStrConec, string vCampoEx)
        {
            DataTable dt;
            SqlDataAdapter da;
            string vValues = "";
            string vCamposFalta = "";
            int vCont = 0;
            string vSql = "";
            string vTipo = "";
            string vCampo = "";
            string vCampos = "";
            bool vOk = false;
            SqlConnection dbConec = new SqlConnection();
            if (vStrConec == "")
            {
                dbConec.ConnectionString = cParamXml.strConec;
            }
            else
            {
                dbConec.ConnectionString = vStrConec;
            }
            dbConec.Open();
            try
            {

                //vSql = "SELECT COLUMN_NAME AS Campo,ORDINAL_POSITION AS No,DATA_TYPE AS Tipo FROM information_schema.columns WHERE table_name = '" + vTabla + "'";
                vSql = "Select top(1) * from " + vTabla;
                da = new SqlDataAdapter(vSql, dbConec);
                dt = new DataTable();
                da.Fill(dt);
                vValues = "Values (";
                vCampos = "(";
                vCont = 1;
                //foreach (DataRow dr in dt.Rows )
                foreach (DataColumn dc in dt.Columns)
                {
                    vTipo = dc.DataType.ToString();
                    vCampo = dc.ColumnName.ToString();

                    //vTipo = dr["Tipo"].ToString();
                    //vCampo = dr["Campo"].ToString();
                    int vEx = ("," + vCampoEx + ",").LastIndexOf(("," + vCampo + ","));
                    if ((vEx == -1) | (vCampoEx == ""))
                    {
                        if (vTipo == "System.DateTime")
                        {
                            vValues = vValues + "'" + "[?" + vCont.ToString() + "T]',";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if (vTipo == "System.Decimal")
                        {
                            vValues = vValues + "" + "[?" + vCont.ToString() + "D],";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if (vTipo == "System.String")
                        {
                            vValues = vValues + "'" + "[?" + vCont.ToString() + "S]',";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if (vTipo == "System.Double")
                        {
                            vValues = vValues + "" + "[?" + vCont.ToString() + "D],";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if (vTipo == "System.Boolean")
                        {
                            vValues = vValues + "" + "[?" + vCont.ToString() + "B],";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if ((vTipo == "System.Byte[]") & (vCampo != "timestamp"))
                        {
                            vValues = vValues + "'" + "[?" + vCont.ToString() + "M]',";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }

                        if (vTipo == "System.Int32")
                        {
                            vValues = vValues + "" + "[?" + vCont.ToString() + "D],";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if (vTipo == "System.Byte")
                        {
                            vValues = vValues + "" + "[?" + vCont.ToString() + "Y],";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                    }

                    if (vOk == false)
                    {
                        vCamposFalta = vCamposFalta + "---" + vTipo;
                    }
                    else
                    {
                        vCont = vCont + 1;

                    }
                    vOk = false;
                }
                vValues = vValues.Substring(0, vValues.Length - 1);
                vValues = vValues + ")";
                vCampos = vCampos.Substring(0, vCampos.Length - 1);
                vCampos = vCampos + ")";


                dbConec.Close();
                return vValues + "#" + vCampos + "#" + vCont;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al conectar o recuperar los datos:\n" +
                    ex.Message, "Conectar con la base",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }


        }

        public static string fncCargaValoresSQL(DataTable dt, string vCampoEx)
        {
            string vValues = "";
            string vCamposFalta = "";
            int vCont = 0;
            //string vSql = "";
            string vTipo = "";
            string vTipos = "";
            string vCampo = "";
            string vCampos = "";
            bool vOk = false;
            try
            {
                vValues = "Values (";
                vCampos = "(";
                vCont = 1;
                //foreach (DataRow dr in dt.Rows )
                foreach (DataColumn dc in dt.Columns)
                {
                    vTipo = dc.DataType.ToString();
                    vCampo = dc.ColumnName.ToString();

                    //vTipo = dr["Tipo"].ToString();
                    //vCampo = dr["Campo"].ToString();
                    int vEx = vCampoEx.LastIndexOf(vCampo);
                    if ((vEx == -1) | (vCampoEx == ""))
                    {
                        if (vTipo == "System.DateTime")
                        {
                            vValues = vValues + "'" + "[?" + vCont.ToString() + "T]',";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if (vTipo == "System.Decimal")
                        {
                            vValues = vValues + "" + "[?" + vCont.ToString() + "D],";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if (vTipo == "System.String")
                        {
                            vValues = vValues + "'" + "[?" + vCont.ToString() + "S]',";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if (vTipo == "System.Double")
                        {
                            vValues = vValues + "" + "[?" + vCont.ToString() + "D],";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if (vTipo == "System.Boolean")
                        {
                            vValues = vValues + "" + "[?" + vCont.ToString() + "B],";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if ((vTipo == "System.Byte[]") & (vCampo != "timestamp"))
                        {
                            vValues = vValues + "'" + "[?" + vCont.ToString() + "M]',";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }

                        if (vTipo == "System.Int32")
                        {
                            vValues = vValues + "" + "[?" + vCont.ToString() + "D],";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if (vTipo == "System.Byte")
                        {
                            vValues = vValues + "" + "[?" + vCont.ToString() + "Y],";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                    }

                    if (vOk == false)
                    {
                        vCamposFalta = vCamposFalta + "---" + vTipo;
                    }
                    else
                    {
                        vTipos = vTipos + vTipo + ",";
                        vCont = vCont + 1;

                    }
                    vOk = false;
                }
                vValues = vValues.Substring(0, vValues.Length - 1);
                vValues = vValues + ")";
                vCampos = vCampos.Substring(0, vCampos.Length - 1);
                vCampos = vCampos + ")";


                return vValues + "#" + vCampos + "#" + vCont + "#" + vTipos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al conectar o recuperar los datos:\n" +
                    ex.Message, "Conectar con la base",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }


        }


        public static string fncReplaceValoresSQL(string[] vDatos, string vCampos, int vNumCampos)
        {
            try
            {
                for (int i = 1; i < vNumCampos; i++)
                {
                    //string vBusca = "[?" + i.ToString();
                    string vBusca = "]";
                    int vPos = vCampos.IndexOf(vBusca);
                    string vLetra = vCampos.Substring(vPos - 1, 1);
                    string vDato = vDatos[i];
                    if (vLetra == "D")
                    {
                        if (vDato == "") { vDato = "0"; }
                        vCampos = vCampos.Replace("[?" + i.ToString() + "D]", vDato);
                    }
                    if (vLetra == "S")
                    {
                        vCampos = vCampos.Replace("[?" + i.ToString() + "S]", vDato);
                    }
                    if (vLetra == "M")
                    {
                        vCampos = vCampos.Replace("[?" + i.ToString() + "M]", vDato);
                    }
                    if (vLetra == "B")
                    {
                        if (vDato == "") { vDato = "0"; }
                        vCampos = vCampos.Replace("[?" + i.ToString() + "B]", vDato);
                    }
                    if (vLetra == "Y")
                    {
                        if (vDato == "") { vDato = "0"; }
                        vCampos = vCampos.Replace("[?" + i.ToString() + "Y]", vDato);
                    }
                    if (vLetra == "T")
                    {
                        if (vDato == "") { vDato = "01/01/1753"; }
                        //if (vDato == "") { vDato = "01/01/2000"; }
                        vCampos = vCampos.Replace("[?" + i.ToString() + "T]", vDato);
                    }
                }
                return vCampos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }


        }


        //public static string InPutBox(string vTexto, string vTitulo, string vEAN, string btDefault)
        //{
        //    frmInput.vTexto = vTexto;
        //    frmInput.vTit = vTitulo;
        //    frmInput.vRes = vEAN;
        //    frmInput.vBt = btDefault;
        //    Form frm = new frmInput();
        //    frm.ShowDialog();
        //    return frmInput.vRes;
        //}
        //public static string InPutBox(string vTexto, string vTitulo, string vEAN, string btDefault, string[] vlista)
        //{
        //    frmInput.vTexto = vTexto;
        //    frmInput.vTit = vTitulo;
        //    frmInput.vRes = vEAN;
        //    frmInput.vBt = btDefault;
        //    frmInput.vLista = vlista;
        //    Form frm = new frmInput();
        //    frm.ShowDialog();
        //    return frmInput.vRes;
        //}
        //public static string InPutBox(string vTexto, string vTitulo, string vEAN, string btDefault, string[] vlista, bool vOpt)
        //{
        //    frmInput.vTexto = vTexto;
        //    frmInput.vTit = vTitulo;
        //    frmInput.vRes = vEAN;
        //    frmInput.vBt = btDefault;
        //    frmInput.vLista = vlista;
        //    frmInput.vOpt = vOpt;

        //    Form frm = new frmInput();
        //    frm.ShowDialog();
        //    return frmInput.vRes;
        //}


        public static string fncBuscaFichEnDirs(string vRuta, string vFich)
        {

            string vPath = "";
            DirectoryInfo DirO = new DirectoryInfo(vRuta);

            DirectoryInfo[] Dirs = DirO.GetDirectories();

            foreach (DirectoryInfo Dir in Dirs)
            {
                int vFiles = Dir.GetFiles(vFich).GetLength(0);
                if (vFiles > 0)
                {
                    vPath = Dir.FullName.ToString();
                    return vPath + "#" + Dir.Name;
                }
            }

            return vPath;
        }


        public static OleDbConnection oleSQLConec(string vstrconec)
        {
            OleDbConnection ConecSQL = new OleDbConnection(vstrconec);
            ConecSQL.Open();
            return ConecSQL;
        }

        public static string fncCargaValoresSQLparaComand(string vTabla)
        {
            return fncCargaValoresSQLparaComand(vTabla, true);

        }
        public static string fncCargaValoresSQLparaComand(string vTabla, bool vParen)
        {
            DataTable dt;
            SqlDataAdapter da;
            string vValues = "";
            string vCamposFalta = "";
            bool Parentesis = vParen;
            int vCont = 0;
            string vSql = "";
            string vTipo = "";
            string vTipos = "";
            string vLong = "";
            string vLongs = "";
            string vCampo = "";
            string vCampos = "";
            bool vOk = false;
            SqlConnection dbConec = new SqlConnection();
            dbConec.ConnectionString = cParamXml.strConec;
            dbConec.Open();
            try
            {
                string[] mTabla = vTabla.Split('.');
                if (mTabla.Length > 1)
                {
                    vTabla = mTabla[mTabla.Length - 1].ToString();
                }


                vSql = "SELECT COLUMN_NAME AS Campo,ORDINAL_POSITION AS No,DATA_TYPE AS Tipo,isnull(CHARACTER_MAXIMUM_LENGTH,0) As Long FROM information_schema.columns WHERE table_name = '" + vTabla + "'";
                if (vSql.LastIndexOf("$") > -1)
                {
                    vSql = vSql.Replace("[", "");
                    vSql = vSql.Replace("]", "");
                }

                //vSql = "Select top(1) * from " + vTabla;
                da = new SqlDataAdapter(vSql, dbConec);
                dt = new DataTable();
                da.Fill(dt);
                vValues = "Values (";
                if (Parentesis)
                {
                    vCampos = "(";
                }
                else
                {
                    vCampos = "";
                }
                vCont = 1;
                foreach (DataRow dr in dt.Rows)
                //foreach (DataColumn dc in dt.Columns)
                {
                    //vTipo = dc.DataType.ToString();
                    //vCampo = dc.ColumnName.ToString();
                    vTipo = dr["Tipo"].ToString();
                    vCampo = dr["Campo"].ToString();
                    vLong = dr["Long"].ToString();
                    if (vCampo != "IDUnic")
                    {
                        vTipos = vTipos + vTipo + ",";
                        vLongs = vLongs + vLong + ",";

                        if (vTipo == "datetime")
                        {
                            vValues = vValues + "'" + "[?" + vCont.ToString() + "T]',";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if (vTipo == "time")
                        {
                            vValues = vValues + "'" + "[?" + vCont.ToString() + "T]',";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if (vTipo == "date")
                        {
                            vValues = vValues + "'" + "[?" + vCont.ToString() + "T]',";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if (vTipo == "decimal")
                        {
                            vValues = vValues + "" + "[?" + vCont.ToString() + "D],";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if (vTipo == "varchar")
                        {
                            vValues = vValues + "'" + "[?" + vCont.ToString() + "S]',";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if (vTipo == "ntext")
                        {
                            vValues = vValues + "'" + "[?" + vCont.ToString() + "S]',";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if (vTipo == "nvarchar")
                        {
                            vValues = vValues + "'" + "[?" + vCont.ToString() + "S]',";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if (vTipo == "double")
                        {
                            vValues = vValues + "" + "[?" + vCont.ToString() + "D],";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if (vTipo == "boolean")
                        {
                            vValues = vValues + "" + "[?" + vCont.ToString() + "B],";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if ((vTipo == "byte[]") & (vCampo != "timestamp"))
                        {
                            vValues = vValues + "'" + "[?" + vCont.ToString() + "M]',";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }

                        if (vTipo == "int")
                        {
                            vValues = vValues + "" + "[?" + vCont.ToString() + "D],";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                        if (vTipo == "tinyint")
                        {
                            vValues = vValues + "" + "[?" + vCont.ToString() + "D],";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }

                        if (vTipo == "byte")
                        {
                            vValues = vValues + "" + "[?" + vCont.ToString() + "Y],";
                            vCampos = vCampos + "[" + vCampo + "],";
                            vOk = true;
                        }
                    }
                    if (vOk == false)
                    {
                        vCamposFalta = vCamposFalta + "---" + vTipo;
                    }
                    else
                    {
                        vCont = vCont + 1;

                    }
                    vOk = false;
                }
                vValues = vValues.Substring(0, vValues.Length - 1);
                vValues = vValues + ")";
                vCampos = vCampos.Substring(0, vCampos.Length - 1);
                vTipos = vTipos.Substring(0, vTipos.Length - 1);
                vLongs = vLongs.Substring(0, vLongs.Length - 1);
                if (Parentesis)
                {
                    vCampos = vCampos + ")";
                }

                dbConec.Close();
                return vValues + "#" + vCampos + "#" + vCont + "#" + vTipos + "#" + vLongs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al conectar o recuperar los datos:\n" +
                    ex.Message, "Conectar con la base",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }


        }

        public static string fncComandInsert(string vTabla, string vStrTabla)
        {
            string vRet = "";
            string vstrCampos = cUtil.Piece(vStrTabla, "#", 2);

            int vNum = Convert.ToInt16(cUtil.Piece(vStrTabla, "#", 3));
            //vstrCampos = vstrCampos.Replace("(", "");
            //vstrCampos = vstrCampos.Replace(")", "");
            if (vstrCampos.Substring(0, 1) == "(") { vstrCampos = vstrCampos.Substring(1, vstrCampos.Length - 2); }

            vRet = "Insert Into " + vTabla + " (" + vstrCampos.Substring(0, vstrCampos.Length) + ") ";

            vstrCampos = vstrCampos.Replace("[", "");
            vstrCampos = vstrCampos.Replace("]", "");
            vstrCampos = vstrCampos.Replace(" ", "_");
            vstrCampos = vstrCampos.Replace("%", "_");
            vstrCampos = vstrCampos.Replace("-", "_");
            vstrCampos = vstrCampos.Replace("(", "_");
            vstrCampos = vstrCampos.Replace(")", "_");

            string[] varCampos = vstrCampos.Split(',');


            vRet = vRet + "Values (";
            for (int i = 0; i < vNum - 1; i++)
            {
                vRet = vRet + "@" + varCampos[i] + ",";
            }
            vRet = vRet.Substring(0, vRet.Length - 1) + ")";

            return vRet;
        }
        public static string fncComandUpdate(string vTabla, string vStrTabla)
        {
            string vRet = "";
            string vstrCampos = cUtil.Piece(vStrTabla, "#", 2);

            int vNum = Convert.ToInt16(cUtil.Piece(vStrTabla, "#", 3));
            vstrCampos = vstrCampos.Replace("[", "");
            vstrCampos = vstrCampos.Replace("]", "");
            vstrCampos = vstrCampos.Replace("(", "");
            vstrCampos = vstrCampos.Replace(")", "");
            string[] varCampos = vstrCampos.Split(',');

            vRet = "Update " + vTabla + " Set ";
            for (int i = 1; i < vNum - 1; i++)
            {
                vRet = vRet + "@" + varCampos[i] + " = " + varCampos[i] + ",";
            }
            vRet = vRet.Substring(0, vRet.Length - 1);


            return vRet;
        }
        public static string fncComandDelete(string vTabla, string vStrTabla)
        {
            return fncComandDelete(vTabla, vStrTabla, "");
        }
        public static string fncComandDelete(string vTabla, string vStrTabla, string vIndices)
        {
            string vRet = "";
            string vstrCampos = cUtil.Piece(vStrTabla, "#", 2);

            int vNum = Convert.ToInt16(cUtil.Piece(vStrTabla, "#", 3));
            if (vstrCampos.Substring(0, 1) == "(") { vstrCampos = vstrCampos.Substring(1, vstrCampos.Length - 2); }

            vRet = "Delete From " + vTabla + " "; // +" (" + vstrCampos.Substring(0, vstrCampos.Length) + ") ";

            vRet = vRet + "Where ";
            string[] vStr = vstrCampos.Split(',');
            for (int i = 0; i < vStr.Length; i++)
            {
                string vCa = vStr[i];

                if (vIndices != "")
                {
                    string vInd = "," + vIndices + ",";
                    if (vInd.LastIndexOf("," + vCa + ",") == -1)
                    {
                        vCa = "";
                    }
                }
                if (vCa != "")
                {
                    vRet = vRet + "(" + vCa + " = ";

                    vCa = vCa.Replace("[", "");
                    vCa = vCa.Replace("]", "");
                    vCa = vCa.Replace(" ", "_");
                    vCa = vCa.Replace("%", "_");
                    vCa = vCa.Replace("-", "_");
                    vCa = vCa.Replace("(", "_");
                    vCa = vCa.Replace(")", "_");
                    vRet = vRet + "@" + vCa + ") and ";
                }
            }

            vRet = vRet.Substring(0, vRet.Length - 4);

            return vRet;
        }

        public static void fncComandParam(ref SqlCommand cm, string vTabla, string[] vCampos, string[] vTipos, string[] vLongs, string vtCommand, string vStrTabla)
        {

            string vstrCampos = cUtil.Piece(vStrTabla, "#", 2);

            int vNum = Convert.ToInt16(cUtil.Piece(vStrTabla, "#", 3));
            //vstrCampos = vstrCampos.Replace("(", "");
            //vstrCampos = vstrCampos.Replace(")", "");
            if (vstrCampos.Substring(0, 1) == "(") { vstrCampos = vstrCampos.Substring(1, vstrCampos.Length - 2); }

            vstrCampos = vstrCampos.Replace("[", "");
            vstrCampos = vstrCampos.Replace("]", "");

            string[] vCamposO = vstrCampos.Split(',');
            for (int i = 0; i < vCampos.Length; i++)
            {
                SqlDbType sqlt;
                string vTipo = vTipos[i].ToString();
                switch (vTipo)
                {
                    case "varchar":
                        sqlt = SqlDbType.VarChar;
                        break;
                    case "nvarchar":
                        sqlt = SqlDbType.NVarChar;
                        break;
                    case "int":
                        sqlt = SqlDbType.Int;
                        break;
                    case "decimal":
                        sqlt = SqlDbType.Decimal;
                        break;
                    case "datetime":
                        sqlt = SqlDbType.DateTime;
                        break;
                    case "tinyint":
                        sqlt = SqlDbType.TinyInt;
                        break;
                    default:
                        sqlt = SqlDbType.VarChar;
                        break;
                }
                string vParamName = vCampos[i].ToString();
                int vsqlSice = Convert.ToInt16(vLongs[i]);
                string vSource = vCamposO[i].ToString();


                vParamName = vParamName.Replace("%", "_");
                vParamName = vParamName.Replace("-", "_");
                vParamName = vParamName.Replace(")", "_");
                vParamName = vParamName.Replace("(", "_");

                cm.Parameters.Add("@" + vParamName, sqlt, vsqlSice, vSource);
            }

            return;
        }

        public static string fncValoresOrig(DataGridView grUP, int vRow, string vStrTabla)
        {

            sbrNombreCol(grUP);
            int vNumCampos = Convert.ToInt16(cUtil.Piece(vStrTabla, "#", 3));

            Array.Resize(ref vNombreCampo, vNumCampos);
            string vCampos = cUtil.Piece(vStrTabla, "#", 2);
            vCampos = vCampos.Substring(1, vCampos.Length - 2);
            vNombreCampo = vCampos.Split(',');

            string vValoresWhere = "";
            try
            {
                string[] vDatos = new string[vNumCampos];

                for (int i = 0; i < vNumCampos - 1; i++)
                {
                    string vNomCampo = vNombreCol[i];
                    if (cUtil.Piece(vNomCampo, "#", 2) == "")
                    {

                        vNomCampo = vNomCampo.Replace("[", "");
                        vNomCampo = vNomCampo.Replace("]", "");

                        string vTipo = grUP.Rows[vRow].Cells[vNomCampo].ValueType.ToString();
                        string vValor = grUP.Rows[vRow].Cells[vNomCampo].Value.ToString();
                        string vName = grUP.Columns[vNomCampo].Name.ToString();
                        string vNCampo = grUP.Columns[vNomCampo].DataPropertyName.ToString();
                        string vTag = "";
                        string vOld = "";
                        if (grUP.Rows[vRow].Cells[vNomCampo].Tag != null)
                        {
                            vTag = grUP.Rows[vRow].Cells[vNomCampo].Tag.ToString();
                            vOld = cUtil.Piece(vTag, "#", 1);
                            if (vOld == "") { vOld = "[?]"; };

                        }

                        string vCom = "'";
                        if (vTipo == "System.Decimal")
                        {
                            vCom = "";
                            vValor = vValor.Replace(".", "");
                            vValor = vValor.Replace(",", ".");
                            vOld = vOld.Replace(".", "");
                            vOld = vOld.Replace(",", ".");
                        }
                        if (vOld != "") { vValor = vOld; }
                        if (vValor == "[?]") { vValor = ""; }

                        vValoresWhere = vValoresWhere + "([" + vNCampo + "] = " + vCom + vValor + vCom + ") and ";
                    }
                }
            }
            catch { }

            vValoresWhere = vValoresWhere.Substring(0, vValoresWhere.Length - 5);
            return vValoresWhere;
        }
        public static string fncValoresActu(DataGridView grUP, int vRow, string vStrTabla, string vSinCampo)
        {

            sbrNombreCol(grUP);
            int vNumCampos = Convert.ToInt16(cUtil.Piece(vStrTabla, "#", 3));
            vSinCampo = "," + vSinCampo + ",";
            Array.Resize(ref vNombreCampo, vNumCampos);
            string vCampos = cUtil.Piece(vStrTabla, "#", 2);
            vCampos = vCampos.Substring(1, vCampos.Length - 2);
            vNombreCampo = vCampos.Split(',');

            string vValoresWhere = "";
            try
            {
                string[] vDatos = new string[vNumCampos];

                for (int i = 0; i < vNumCampos - 1; i++)
                {
                    string vNomCampo = vNombreCol[i];
                    if (cUtil.Piece(vNomCampo, "#", 2) == "")
                    {

                        vNomCampo = vNomCampo.Replace("[", "");
                        vNomCampo = vNomCampo.Replace("]", "");

                        if (vSinCampo.LastIndexOf("," + vNomCampo + ",") == -1)
                        {
                            string vTipo = grUP.Rows[vRow].Cells[vNomCampo].ValueType.ToString();
                            string vValor = grUP.Rows[vRow].Cells[vNomCampo].Value.ToString();
                            string vName = grUP.Columns[vNomCampo].Name.ToString();
                            string vNCampo = grUP.Columns[vNomCampo].DataPropertyName.ToString();

                            string vCom = "'";
                            if (vTipo == "System.Decimal")
                            {
                                vCom = "";
                                vValor = vValor.Replace(".", "");
                                vValor = vValor.Replace(",", ".");
                            }

                            vValoresWhere = vValoresWhere + "([" + vNCampo + "] = " + vCom + vValor + vCom + ") and ";
                        }
                    }
                }
            }
            catch { }

            vValoresWhere = vValoresWhere.Substring(0, vValoresWhere.Length - 5);
            return vValoresWhere;
        }
        public static string fncValoresInd(DataGridView grUP, int vRow, string vStrTabla, string vInd)
        {

            sbrNombreCol(grUP);
            int vNumCampos = Convert.ToInt16(cUtil.Piece(vStrTabla, "#", 3));
            vInd = "," + vInd + ",";
            Array.Resize(ref vNombreCampo, vNumCampos);
            string vCampos = cUtil.Piece(vStrTabla, "#", 2);
            vCampos = vCampos.Substring(1, vCampos.Length - 2);
            vNombreCampo = vCampos.Split(',');

            string vValoresWhere = "";
            try
            {
                string[] vDatos = new string[vNumCampos];

                for (int i = 0; i < vNumCampos - 1; i++)
                {
                    string vNomCampo = vNombreCol[i];
                    if (cUtil.Piece(vNomCampo, "#", 2) == "")
                    {

                        vNomCampo = vNomCampo.Replace("[", "");
                        vNomCampo = vNomCampo.Replace("]", "");

                        if (vInd.LastIndexOf("," + vNomCampo + ",") != -1)
                        {
                            string vTipo = grUP.Rows[vRow].Cells[vNomCampo].ValueType.ToString();
                            string vValor = grUP.Rows[vRow].Cells[vNomCampo].Value.ToString();
                            string vName = grUP.Columns[vNomCampo].Name.ToString();
                            string vNCampo = grUP.Columns[vNomCampo].DataPropertyName.ToString();

                            string vCom = "'";
                            if (vTipo == "System.Decimal")
                            {
                                vCom = "";
                                vValor = vValor.Replace(".", "");
                                vValor = vValor.Replace(",", ".");
                            }

                            vValoresWhere = vValoresWhere + "([" + vNCampo + "] = " + vCom + vValor + vCom + ") and ";
                        }
                    }
                }
            }
            catch { }

            vValoresWhere = vValoresWhere.Substring(0, vValoresWhere.Length - 5);
            return vValoresWhere;
        }

        public static void sbrNombreCol(DataGridView grUP)
        {

            string vColumnas = "";
            int vContCol = 0;
            foreach (DataGridViewColumn dc in grUP.Columns)
            {
                string vNCol = dc.Name;
                if (cUtil.Piece(vNCol, "#", 2) == "")
                {
                    vColumnas = vColumnas + dc.Name + ",";
                    vContCol++;
                }
            }
            vColumnas = vColumnas.Substring(0, vColumnas.Length - 1);
            Array.Resize(ref vNombreCol, vContCol);
            vNombreCol = vColumnas.Split(',');
        }


        static public ADODB.Recordset ConvertToRecordset(DataTable inTable)
        {
            
            ADODB.Recordset result = new ADODB.Recordset();
            result.CursorLocation = ADODB.CursorLocationEnum.adUseClient;

            ADODB.Fields resultFields = result.Fields;
            System.Data.DataColumnCollection inColumns = inTable.Columns;

            foreach (DataColumn inColumn in inColumns)
            {
                resultFields.Append(inColumn.ColumnName, TranslateType(inColumn.DataType)
                , inColumn.MaxLength,
                inColumn.AllowDBNull ? ADODB.FieldAttributeEnum.adFldIsNullable : ADODB.FieldAttributeEnum.adFldUnspecified
                , null);
            }

            result.Open(System.Reflection.Missing.Value
            , System.Reflection.Missing.Value
            , ADODB.CursorTypeEnum.adOpenStatic
            , ADODB.LockTypeEnum.adLockOptimistic, 0);
            int vContRow = 0;
            foreach (DataRow dr in inTable.Rows)
            {
                vContRow++;

                if (vContRow % 50 == 0)
                {
                    frmInformacion.vNReg = vContRow;
                    Application.DoEvents();
                }

                result.AddNew(System.Reflection.Missing.Value, System.Reflection.Missing.Value);

                for (int columnIndex = 0; columnIndex < inColumns.Count; columnIndex++)
                {
                    resultFields[columnIndex].Value = dr[columnIndex];
                }
            }

            return result;
        }

        static ADODB.DataTypeEnum TranslateType(Type columnType)
        {
            switch (columnType.UnderlyingSystemType.ToString())
            {
                case "System.Boolean":
                    return ADODB.DataTypeEnum.adBoolean;

                case "System.Byte[]":
                    return ADODB.DataTypeEnum.adBinary;

                case "System.Byte":
                    return ADODB.DataTypeEnum.adUnsignedTinyInt;

                case "System.Char":
                    return ADODB.DataTypeEnum.adChar;

                case "System.DateTime":
                    return ADODB.DataTypeEnum.adDate;

                case "System.Decimal":
                    return ADODB.DataTypeEnum.adCurrency;

                case "System.Double":
                    return ADODB.DataTypeEnum.adDouble;

                case "System.Int16":
                    return ADODB.DataTypeEnum.adSmallInt;

                case "System.Int32":
                    return ADODB.DataTypeEnum.adInteger;

                case "System.Int64":
                    return ADODB.DataTypeEnum.adBigInt;

                case "System.SByte":
                    return ADODB.DataTypeEnum.adTinyInt;

                case "System.Single":
                    return ADODB.DataTypeEnum.adSingle;

                case "System.UInt16":
                    return ADODB.DataTypeEnum.adUnsignedSmallInt;

                case "System.UInt32":
                    return ADODB.DataTypeEnum.adUnsignedInt;

                case "System.UInt64":
                    return ADODB.DataTypeEnum.adUnsignedBigInt;

                case "System.SmallInt":
                    return ADODB.DataTypeEnum.adSmallInt;

                case "System.String":
                default:
                    return ADODB.DataTypeEnum.adVarChar;
            }
        }


        public static string fncNombreMes(int vMes)
        {
            string vnMes = "";
            switch (vMes)
            {
                case 1:
                    vnMes = "Enero";
                    break;
                case 2:
                    vnMes = "Febrero";
                    break;
                case 3:
                    vnMes = "Marzo";
                    break;
                case 4:
                    vnMes = "Abril";
                    break;
                case 5:
                    vnMes = "Mayo";
                    break;
                case 6:
                    vnMes = "Junio";
                    break;
                case 7:
                    vnMes = "Julio";
                    break;
                case 8:
                    vnMes = "Agosto";
                    break;
                case 9:
                    vnMes = "Septiembre";
                    break;
                case 10:
                    vnMes = "Octubre";
                    break;
                case 11:
                    vnMes = "Noviembre";
                    break;
                case 12:
                    vnMes = "Diciembre";
                    break;
                default:
                    vnMes = "Error";
                    break;
            }
            return vnMes;

        }
        public static int fncNumeroMes(string vMes)
        {
            int vnMes = 0;
            switch (vMes)
            {
                case "Enero":
                    vnMes = 1;
                    break;
                case "Febrero":
                    vnMes = 2;
                    break;
                case "Marzo":
                    vnMes = 3;
                    break;
                case "Abril":
                    vnMes = 4;
                    break;
                case "Mayo":
                    vnMes = 5;
                    break;
                case "Junio":
                    vnMes = 6;
                    break;
                case "Julio":
                    vnMes = 7;
                    break;
                case "Agosto":
                    vnMes = 8;
                    break;
                case "Septiembre":
                    vnMes = 9;
                    break;
                case "Octubre":
                    vnMes = 10;
                    break;
                case "Noviembre":
                    vnMes = 11;
                    break;
                case "Diciembre":
                    vnMes = 12;
                    break;
                default:
                    vnMes = 99;
                    break;
            }
            return vnMes;

        }
        public static int fncColorMesXls(int vMes)
        {
            int vnMes = 0;
            switch (vMes)
            {
                case 1:
                    vnMes = 65535;
                    break;
                case 2:
                    vnMes = 13395711;
                    break;
                case 3:
                    vnMes = 16750848;
                    break;
                case 4:
                    vnMes = 3381555;
                    break;
                case 5:
                    vnMes = 39423;
                    break;
                case 6:
                    vnMes = 16711782;
                    break;
                case 7:
                    vnMes = 16764108;
                    break;
                case 8:
                    vnMes = 10040319;
                    break;
                case 9:
                    vnMes = 128;
                    break;
                case 10:
                    vnMes = 13434726;
                    break;
                case 11:
                    vnMes = 6750207;
                    break;
                case 12:
                    vnMes = 10092441;
                    break;
                default:
                    vnMes = 0;
                    break;
            }
            return vnMes;

        }

        public static string fncNombreDiaSem(DayOfWeek vDia, bool vCorto)
        {
            string vnDia = "";
            switch (vDia)
            {
                case DayOfWeek.Monday:
                    if (vCorto) { vnDia = "L"; } else { vnDia = "Lunes"; }
                    break;
                case DayOfWeek.Tuesday:
                    if (vCorto) { vnDia = "M"; } else { vnDia = "Martes"; }
                    break;
                case DayOfWeek.Wednesday:
                    if (vCorto) { vnDia = "X"; } else { vnDia = "Miercoles"; }
                    break;
                case DayOfWeek.Thursday:
                    if (vCorto) { vnDia = "J"; } else { vnDia = "Jueves"; }
                    break;
                case DayOfWeek.Friday:
                    if (vCorto) { vnDia = "V"; } else { vnDia = "Viernes"; }
                    break;
                case DayOfWeek.Saturday:
                    if (vCorto) { vnDia = "S"; } else { vnDia = "Sabado"; }
                    break;
                case DayOfWeek.Sunday:
                    if (vCorto) { vnDia = "D"; } else { vnDia = "Domingo"; }
                    break;
                default:
                    if (vCorto) { vnDia = ""; } else { vnDia = ""; }
                    break;
            }
            return vnDia;

        }
        public static string fncNombreDiaSem(int vDia, bool vCorto)
        {
            string vnDia = "";
            switch (vDia)
            {
                case 1:
                    if (vCorto) { vnDia = "L"; } else { vnDia = "Lunes"; }
                    break;
                case 2:
                    if (vCorto) { vnDia = "M"; } else { vnDia = "Martes"; }
                    break;
                case 3:
                    if (vCorto) { vnDia = "X"; } else { vnDia = "Miercoles"; }
                    break;
                case 4:
                    if (vCorto) { vnDia = "J"; } else { vnDia = "Jueves"; }
                    break;
                case 5:
                    if (vCorto) { vnDia = "V"; } else { vnDia = "Viernes"; }
                    break;
                case 6:
                    if (vCorto) { vnDia = "S"; } else { vnDia = "Sabado"; }
                    break;
                case 0:
                    if (vCorto) { vnDia = "D"; } else { vnDia = "Domingo"; }
                    break;
                default:
                    if (vCorto) { vnDia = ""; } else { vnDia = ""; }
                    break;
            }
            return vnDia;

        }
        public static string fncNombreDiaSem(string vDia, bool vCorto)
        {
            string vnDia = "";
            switch (vDia)
            {
                case "L":
                    if (vCorto) { vnDia = "L"; } else { vnDia = "Lunes"; }
                    break;
                case "M":
                    if (vCorto) { vnDia = "M"; } else { vnDia = "Martes"; }
                    break;
                case "X":
                    if (vCorto) { vnDia = "X"; } else { vnDia = "Miercoles"; }
                    break;
                case "J":
                    if (vCorto) { vnDia = "J"; } else { vnDia = "Jueves"; }
                    break;
                case "V":
                    if (vCorto) { vnDia = "V"; } else { vnDia = "Viernes"; }
                    break;
                case "S":
                    if (vCorto) { vnDia = "S"; } else { vnDia = "Sabado"; }
                    break;
                case "D":
                    if (vCorto) { vnDia = "D"; } else { vnDia = "Domingo"; }
                    break;
                default:
                    if (vCorto) { vnDia = ""; } else { vnDia = ""; }
                    break;
            }
            return vnDia;

        }
        public static string fncNombreLV(string vDia)
        {
            string vnDia = "";
            switch (vDia)
            {
                case "L":
                    vnDia = "Laborable";
                    break;
                case "V":
                    vnDia = "Vacaciones";
                    break;
                case "D":
                    vnDia = "Fin de Semana";
                    break;
                case "F":
                    vnDia = "Festivo";
                    break;
                default:
                    vnDia = "";
                    break;
            }
            return vnDia;

        }


        public static Font ChangeFontSize(Font font, float fontSize)
        {
            return ChangeFontSize(font, fontSize, false);
        }

        public static Font ChangeFontSize(Font font, float fontSize, bool Cursiva)
        {
            if (font != null)
            {
                float currentSize = font.Size;
                if (currentSize != fontSize)
                {
                    font = new Font(font.Name, fontSize,
                        font.Style, font.Unit,
                        font.GdiCharSet, font.GdiVerticalFont);
                }
            }

            return font;
        }




        public static string fncLista(string vTabla, string vStrConec, string vCampoPos, string vValorPos,
                                      string vWhere, string vSQL, string vNoVis, bool vTodos, string vRes,
                                      string vCampoBus, string vDatoBus)
        {
            Form frm = new frmLista();
            frmLista.vTabla = vTabla;
            frmLista.vCampoPos = vCampoPos;
            frmLista.vValorPos = vValorPos;
            frmLista.vWhere = vWhere;
            frmLista.vSqlOrig = vSQL;
            frmLista.vTableData = true;
            frmLista.vTipoTabla = "SQL";
            frmLista.vStrConec = vStrConec;
            frmLista.vNoVisibleGR = vNoVis;
            frmLista.vRes = vRes;
            frmLista.vCampoBus = vCampoBus;
            frmLista.vValorBus = vDatoBus;
            frm.ShowDialog();
            string vValor = frmLista.vSelec;
            if (vTodos) { vValor = frmLista.vSelecTot; }
            return vValor;
        }

        public static string fncLista(string vTabla, string vStrConec, string vCampoPos, string vValorPos,
                                      string vWhere, string vSQL, string vNoVis, bool vTodos, string vRes)
        {
            return fncLista(vTabla, vStrConec, vCampoPos, vValorPos, vWhere, vSQL, vNoVis, vTodos, vRes, "", "");
        }

        public static string fncLista(string vTabla, string vStrConec, string vCampoPos, string vValorPos,
                                      string vWhere, string vSQL, string vNoVis)
        {
            return fncLista(vTabla, vStrConec, vCampoPos, vValorPos, vWhere, vSQL, vNoVis, false, "");
        }

        public static string fncLista(string vTabla, string vStrConec, string vCampoPos, string vValorPos,
                                      string vWhere)
        {
            return fncLista(vTabla, vStrConec, vCampoPos, vValorPos, vWhere, "", "", false, "");
        }

        public static string fncLista(string vTabla, string vStrConec, string vCampoPos, string vValorPos)
        {
            return fncLista(vTabla, vStrConec, vCampoPos, vValorPos, "", "", "", false, "");
        }

        public static string fncLista(string vTabla, string vStrConec)
        {
            return fncLista(vTabla, vStrConec, "", "", "", "", "", false, "");
        }

        public static string fncSumaHorasMin(string vtH1, string vtH2)
        {
            string vHM = "";

            string vsHE = cUtil.Piece(vtH1, ":", 1);
            string vsME = cUtil.Piece(vtH1, ":", 2);

            if (vtH2 == "") { vtH2 = "00:00"; }
            string vsHS = cUtil.Piece(vtH2, ":", 1);
            string vsMS = cUtil.Piece(vtH2, ":", 2);

            if (vsHE.Trim() == "") { vsHE = "0"; };
            if (vsME.Trim() == "") { vsME = "0"; };
            if (vsHS.Trim() == "") { vsHS = "0"; };
            if (vsMS.Trim() == "") { vsMS = "0"; };

            int vHE = Convert.ToInt32(vsHE);
            int vME = Convert.ToInt32(vsME);
            int vHS = Convert.ToInt32(vsHS);
            int vMS = Convert.ToInt32(vsMS);

            //Minutos Hora 1
            if (vHE < 0) { vME = vME * -1; }
            int vMiE = (vHE * 60) + vME;
            //Minutos Hora 2
            if (vHS < 0) { vMS = vMS * -1; }
            int vMiS = (vHS * 60) + vMS;
            //Suma Minutos
            int vMiSum = vMiS + vMiE;

            //Convertir los minutos de diferencia en hh:mm
            int vHorasR = vMiSum / 60;
            int vMinR = vMiSum - (vHorasR * 60);

            //Sumo horas y minutos al dia
            int vHT = vHorasR;
            int vMT = vMinR;


            //Si los minutos superan los 60 sumo una hora y resto los minutos
            if (vMT > 59)
            {
                vHT = vHT + 1;
                vMT = vMT - 60;
            }
            string vsHT = vHT.ToString();
            if (vMT < 0) { vMT = vMT * -1; }
            string vsMT = vMT.ToString();

            vHM = vsHT.PadLeft(2, '0') + ":" + vsMT.PadLeft(2, '0');
            return vHM;
        }

        public static string fncRestaHorasMin(string vtH1, string vtH2)
        {
            string vHM = "";

            string vsHE = cUtil.Piece(vtH1, ":", 1);
            string vsME = cUtil.Piece(vtH1, ":", 2);

            string vsHS = cUtil.Piece(vtH2, ":", 1);
            string vsMS = cUtil.Piece(vtH2, ":", 2);

            if (vsHE.Trim() == "") { vsHE = "0"; };
            if (vsME.Trim() == "") { vsME = "0"; };
            if (vsHS.Trim() == "") { vsHS = "0"; };
            if (vsMS.Trim() == "") { vsMS = "0"; };

            int vHE = Convert.ToInt32(vsHE);
            int vME = Convert.ToInt32(vsME);
            int vHS = Convert.ToInt32(vsHS);
            int vMS = Convert.ToInt32(vsMS);

            //Minutos Hora 1
            if (vHE < 0) { vME = vME * -1; }
            int vMiE = (vHE * 60) + vME;
            //Minutos Hora 2
            if (vHS < 0) { vMS = vMS * -1; }
            int vMiS = (vHS * 60) + vMS;
            //Suma Minutos
            int vMiSum = vMiE - vMiS;
            string vSigno = "";
            if (vMiSum < 0) { vSigno = "-"; vMiSum = vMiSum * -1; }


            //Convertir los minutos de diferencia en hh:mm
            int vHorasR = vMiSum / 60;
            int vMinR = vMiSum - (vHorasR * 60);

            //Sumo horas y minutos al dia
            int vHT = vHorasR;
            int vMT = vMinR;

            //Si los minutos superan los 60 sumo una hora y resto los minutos
            if (vMT > 59)
            {
                vHT = vHT + 1;
                vMT = vMT - 60;
            }
            string vsHT = vHT.ToString();
            string vsMT = vMT.ToString();

            vHM = vSigno + vsHT.PadLeft(2, '0') + ":" + vsMT.PadLeft(2, '0');
            return vHM;
        }

        public static string fncMultiHorasMin(string vtH1, int vInt)
        {
            string vHM = "";

            string vsHE = cUtil.Piece(vtH1, ":", 1);
            string vsME = cUtil.Piece(vtH1, ":", 2);


            if (vsHE.Trim() == "") { vsHE = "0"; };
            if (vsME.Trim() == "") { vsME = "0"; };

            int vHE = Convert.ToInt16(vsHE);
            int vME = Convert.ToInt16(vsME);

            //Minutos Hora 1
            if (vHE < 0) { vME = vME * -1; }
            int vMiE = (vHE * 60) + vME;
            //Multiplica Minutos por Entero
            int vMiSum = vMiE * vInt;

            //Convertir los minutos de diferencia en hh:mm
            int vHorasR = vMiSum / 60;
            int vMinR = vMiSum - (vHorasR * 60);

            //Sumo horas y minutos al dia
            int vHT = vHorasR;
            int vMT = vMinR;


            //Si los minutos superan los 60 sumo una hora y resto los minutos
            if (vMT > 59)
            {
                vHT = vHT + 1;
                vMT = vMT - 60;
            }
            string vsHT = vHT.ToString();
            if (vMT < 0) { vMT = vMT * -1; }
            string vsMT = vMT.ToString();

            vHM = vsHT.PadLeft(2, '0') + ":" + vsMT.PadLeft(2, '0');
            return vHM;
        }


        public static string fncDifHorasMin(string vtHE, string vtHS, bool vSeg)
        {
            if (vtHE == null) { vtHE = "00:00"; }
            if (vtHS == null) { vtHS = "00:00"; }
            string vHM = "";

            string vsHE = cUtil.Piece(vtHE, ":", 1);
            string vsME = cUtil.Piece(vtHE, ":", 2);

            string vsHS = cUtil.Piece(vtHS, ":", 1);
            string vsMS = cUtil.Piece(vtHS, ":", 2);

            if ((vsHE.Trim() == "") | (vsHE.Trim() == "****No****")) { vsHE = "0"; };
            if ((vsME.Trim() == "") | (vsME.Trim() == "****No****")) { vsME = "0"; };
            if ((vsHS.Trim() == "") | (vsHS.Trim() == "****No****")) { vsHS = "0"; };
            if ((vsMS.Trim() == "") | (vsMS.Trim() == "****No****")) { vsMS = "0"; };

            int vHE = Convert.ToInt16(vsHE);
            int vME = Convert.ToInt16(vsME);
            int vHS = Convert.ToInt16(vsHS);
            int vMS = Convert.ToInt16(vsMS);

            //Minutos Hora 1
            if (vHE < 0) { vME = vME * -1; }
            int vMiE = (vHE * 60) + vME;
            //Minutos Hora 2
            if (vHS < 0) { vMS = vMS * -1; }
            int vMiS = (vHS * 60) + vMS;
            //Suma Minutos
            int vMiDif = vMiS - vMiE;
            if (vMiS == 0) { vMiDif = 0; }

            ////Minutos Entrada
            //int vMiE = (vHE * 60) + vME;
            ////Minutos Salida
            //int vMiS = (vHS * 60) + vMS;
            ////Minutos de Diferencia
            //int vMiDif = vMiS - vMiE;


            //Convertir los minutos de diferencia en hh:mm
            int vHorasR = vMiDif / 60;
            int vMinR = vMiDif - (vHorasR * 60);

            //Sumo horas y minutos al dia
            int vHT = vHorasR;
            int vMT = vMinR;


            //Si los minutos superan los 60 sumo una hora y resto los minutos
            if (vMT > 59)
            {
                vHT = vHT + 1;
                vMT = vMT - 60;
            }
            string vsHT = vHT.ToString();
            if (vMT < 0) { vMT = vMT * -1; }
            string vsMT = vMT.ToString();

            vHM = vsHT.PadLeft(2, '0') + ":" + vsMT.PadLeft(2, '0');
            if (vSeg) { return vMiDif.ToString(); }
            return vHM;
        }

        public static string fncDifHorasMin(string vtHE, string vtHS)
        {
            return fncDifHorasMin(vtHE, vtHS, false);
        }

        public static string fncComparaHorasMin(string vtH1, string vtH2, ref string vtRes)
        {
            string vSig = "";
            try
            {
                if (vtH1.Substring(0, 1) == "-")
                {
                    vtRes = fncSumaHorasMin(vtH1, vtH2);
                    vSig = "-";
                    return vSig;
                }
                else
                {
                    vtRes = fncRestaHorasMin(vtH1, vtH2);
                }
                if (vtRes == "00:00") { vSig = "="; return vSig; }
                if (vtRes.Substring(0, 1) == "-")
                {
                    vSig = "-";
                }
                else
                {
                    vSig = "+";
                }
            }
            catch { }

            return vSig;
        }


        public static string fncHorasDia(string vHoras, string _HorasDia)
        {

            return fncHorasDia(vHoras, _HorasDia, "00:00");
        }

        public static string fncHorasDia(string vHoras, string _HorasDia, string vDescanso)
        {
            if (vDescanso == null) { vDescanso = "00:00"; }
            if (vDescanso == "****No****") { vDescanso = "00:00"; }
            string vHorasDia = "";
            string vME = Piece(vHoras, "#", 1);
            string vMS = Piece(vHoras, "#", 2);
            string vTE = Piece(vHoras, "#", 3);
            string vTS = Piece(vHoras, "#", 4);
            string vHorasM = fncDifHorasMin(vME, vMS);
            string vhorasT = fncDifHorasMin(vTE, vTS);
            vHorasDia = fncSumaHorasMin(vHorasM, vhorasT);
            if ((vHorasDia == "") | (vHorasDia == "00:00"))
            {
                vHorasDia = _HorasDia;
            }
            if (vDescanso != "00:00")
            {
                vHorasDia = fncRestaHorasMin(vHorasDia, vDescanso);
            }

            return vHorasDia;
        }

        public static void fncGuardaEstado(Form vfrm)
        {
            string vFich = cParamXml.DirMisDoc() + @"\Param" + Application.ProductName + ".xml";
            cXml.fncGuardaDato(vFich, "Estado", "Top", vfrm.Top.ToString());
            cXml.fncGuardaDato(vFich, "Estado", "Left", vfrm.Left.ToString());
            cXml.fncGuardaDato(vFich, "Estado", "Width", vfrm.Width.ToString());
            cXml.fncGuardaDato(vFich, "Estado", "Height", vfrm.Height.ToString());
        }

        public static void fncRecuperaEstado(Form vfrm, string vTit)
        {
            string vFich = cParamXml.DirMisDoc() + @"\Param" + Application.ProductName + ".xml";
            vfrm.Top = Convert.ToInt32(cXml.fncLeeDato(vFich, "Estado", "Top", "100"));
            vfrm.Left = Convert.ToInt32(cXml.fncLeeDato(vFich, "Estado", "Left", "100"));
            vfrm.Width = Convert.ToInt32(cXml.fncLeeDato(vFich, "Estado", "Width", "5000"));
            vfrm.Height = Convert.ToInt32(cXml.fncLeeDato(vFich, "Estado", "Height", "5000"));
            vfrm.Text = vTit + "" + " Versión :" + Application.ProductVersion.ToString();

        }

        public static int fncDifMin(string vtHE, string vtHS)
        {

            if (vtHE == null) { vtHE = "00:00"; }
            if (vtHS == null) { vtHS = "00:00"; }


            string vsHE = cUtil.Piece(vtHE, ":", 1);
            string vsME = cUtil.Piece(vtHE, ":", 2);

            string vsHS = cUtil.Piece(vtHS, ":", 1);
            string vsMS = cUtil.Piece(vtHS, ":", 2);

            if ((vsHE.Trim() == "") | (vsHE.Trim() == "****No****")) { vsHE = "0"; };
            if ((vsME.Trim() == "") | (vsME.Trim() == "****No****")) { vsME = "0"; };
            if ((vsHS.Trim() == "") | (vsHS.Trim() == "****No****")) { vsHS = "0"; };
            if ((vsMS.Trim() == "") | (vsMS.Trim() == "****No****")) { vsMS = "0"; };

            int vHE = Convert.ToInt16(vsHE);
            int vME = Convert.ToInt16(vsME);
            int vHS = Convert.ToInt16(vsHS);
            int vMS = Convert.ToInt16(vsMS);


            //Minutos Entrada
            int vMiE = (vHE * 60) + vME;
            //Minutos Salida
            int vMiS = (vHS * 60) + vMS;
            //Minutos de Diferencia
            int vMiDif = vMiS - vMiE;

            return vMiDif;
        }

        public static int fncSeg(string vtHE)
        {

            if (vtHE == null) { vtHE = "00:00"; }


            string vsHE = cUtil.Piece(vtHE, ":", 1);
            string vsME = cUtil.Piece(vtHE, ":", 2);


            if ((vsHE.Trim() == "") | (vsHE.Trim() == "****No****")) { vsHE = "0"; };
            if ((vsME.Trim() == "") | (vsME.Trim() == "****No****")) { vsME = "0"; };

            int vHE = Convert.ToInt16(vsHE);
            int vME = Convert.ToInt16(vsME);


            //Minutos Entrada
            int vMiE = (vHE * 60) + vME;

            return vMiE;
        }
        public static int fncMin(string vtHE)
        {
            return fncMin(vtHE, true);
        }
        public static int fncMin(string vtHE, bool vSig)
        {

            if (vtHE == null) { vtHE = "00:00"; }


            string vsHE = cUtil.Piece(vtHE, ":", 1);
            string vsME = cUtil.Piece(vtHE, ":", 2);


            if ((vsHE.Trim() == "") | (vsHE.Trim() == "****No****")) { vsHE = "0"; };
            if ((vsME.Trim() == "") | (vsME.Trim() == "****No****")) { vsME = "0"; };

            int vHE = Convert.ToInt16(vsHE);
            int vME = Convert.ToInt16(vsME);
            if (vSig) { if (vHE < 0) { vHE = vHE * -1; } }

            int vMiE = (vHE * 60) + vME;

            return vMiE;
        }


        public static string InPutBox(string vTexto, string vTitulo, string vEAN, string btDefault)
        {
            frmInput.vTexto = vTexto;
            frmInput.vTit = vTitulo;
            frmInput.vRes = vEAN;
            frmInput.vBt = btDefault;
            Form frm = new frmInput();
            frm.ShowDialog();
            return frmInput.vRes;
        }
        public static string InPutBox(string vTexto, string vTitulo, string vEAN, string btDefault, string[] vlista)
        {
            frmInput.vTexto = vTexto;
            frmInput.vTit = vTitulo;
            frmInput.vRes = vEAN;
            frmInput.vBt = btDefault;
            frmInput.vLista = vlista;
            Form frm = new frmInput();
            frm.ShowDialog();
            return frmInput.vRes;
        }
        public static string InPutBox(string vTexto, string vTitulo, string vEAN, string btDefault, string[] vlista, bool vOpt, bool vCh)
        {
            return InPutBox(vTexto, vTitulo, vEAN, btDefault, vlista, vOpt, vCh, false, "");
        }
        public static string InPutBox(string vTexto, string vTitulo, string vEAN, string btDefault, string[] vlista, bool vOpt, bool vCh, bool vMulti, string vSep)
        {
            frmInput.vTexto = vTexto;
            frmInput.vTit = vTitulo;
            frmInput.vRes = vEAN;
            frmInput.vBt = btDefault;
            frmInput.vLista = vlista;
            frmInput.vOpt = vOpt;
            frmInput.vCh = vCh;
            frmInput.vMulti = vMulti;
            frmInput.vSep = vSep;
            Form frm = new frmInput();
            frm.ShowDialog();
            return frmInput.vRes;
        }
        public static string InPutBox(string vTexto, string vTitulo, string vEAN, string btDefault, string vRel, string vCampoRel)
        {
            frmInput.vTexto = vTexto;
            frmInput.vTit = vTitulo;
            frmInput.vRes = vEAN;
            frmInput.vBt = btDefault;
            frmInput.vRel = vRel;
            frmInput.vCampoRel = vCampoRel;
            Form frm = new frmInput();
            frm.ShowDialog();
            return frmInput.vRes;
        }
        public static string InPutBox(string vTexto, string vTitulo, string vEAN, string btDefault, string vRel, string vCampoRel, bool vRelTot)
        {
            frmInput.vTexto = vTexto;
            frmInput.vTit = vTitulo;
            frmInput.vRes = vEAN;
            frmInput.vBt = btDefault;
            frmInput.vRel = vRel;
            frmInput.vCampoRel = vCampoRel;
            Form frm = new frmInput();
            frm.ShowDialog();
            string vRespuesta = "";
            if (vRelTot) { vRespuesta = frmInput.vRelTot; } else { vRespuesta = frmInput.vRes; }

            return vRespuesta;
        }


        public static DataTable TraeDBF(string vSql, String vDBF)
        {

            System.Data.OleDb.OleDbConnection dbConec = new System.Data.OleDb.OleDbConnection();
            dbConec.ConnectionString = @"PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + vDBF;
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                dbConec.Open();
                da = new OleDbDataAdapter(vSql, dbConec);
                dt = new DataTable();
                // Llenar la tabla con los datos indicados
                da.Fill(dt);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

            return dt;
        }

        public static int fncCargaTablaSQL(string vTabla, DataTable dt)
        {
            Application.DoEvents();
            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(cParamXml.strConec))
            {
                Application.DoEvents();
                bulkcopy.DestinationTableName = vTabla;
                try
                {
                    bulkcopy.BulkCopyTimeout = 2500;
                    Application.DoEvents();
                    foreach (DataColumn cl in dt.Columns)
                    {
                        string vCol = cl.ColumnName;
                        bulkcopy.ColumnMappings.Add(vCol, vCol);
                    }

                    bulkcopy.WriteToServer(dt);
                    return 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }

        public static void sbrAgregaColumn(ref DataGridView grUP, string vFormatoC, string vNombre)
        {
            sbrAgregaColumn(ref grUP, vFormatoC, vNombre, "", vNombre);
        }

        public static void sbrAgregaColumn(ref DataGridView grUP, string vFormatoC, string vNombre, string vTxCAb)
        {
            sbrAgregaColumn(ref grUP, vFormatoC, vNombre, "", vTxCAb);
        }

        public static void sbrAgregaColumn(ref DataGridView grUP, string vFormatoC, string vNombre, string vTipoC, string vTxCab)
        {
            sbrAgregaColumn(ref grUP, vFormatoC, vNombre, "", vTxCab,9999);

        }
        public static void sbrAgregaColumn(ref DataGridView grUP, string vFormatoC, string vNombre, string vTipoC, string vTxCab, int vNColum)
        {
            DataGridViewTextBoxColumn vtxColumn = new DataGridViewTextBoxColumn();
            DataGridViewButtonColumn vbtColumn = new DataGridViewButtonColumn();
            DataGridViewCheckBoxColumn vchColumn = new DataGridViewCheckBoxColumn();
            DataGridViewComboBoxColumn vcbColumn = new DataGridViewComboBoxColumn();
            DataGridViewMaskedTextColumn vmkColumn = new DataGridViewMaskedTextColumn();

            int vNumColumn = vNColum;
            if (vNumColumn == 9999) 
            {
                vNumColumn = grUP.Columns[vNombre].Index;
                grUP.Columns.RemoveAt(vNumColumn);
            }



            string vTipo = cUtil.Piece(vFormatoC, "#", 1);
            string vtxName = vNombre;
            string vtxCab = vTxCab;

            if (vTipo == "Tx")
            {
                vtxColumn.Name = vtxName;
                vtxColumn.HeaderText = vtxCab;
                vtxColumn.DataPropertyName = vNombre;
                grUP.Columns.Insert(vNumColumn, vtxColumn);

                if (vTipoC == "System.Int32")
                {
                    try
                    {
                        vtxColumn.DefaultCellStyle.Format = "n0";

                    }
                    catch { }

                }


                if (vTipoC == "System.Decimal")
                {
                    try
                    {
                        vtxColumn.DefaultCellStyle.Format = "n4";

                    }
                    catch { }

                }

                //vNumColumn++;
            }

            if (vTipo == "cb")
            {
                string vcb = cUtil.Piece(vFormatoC, "#", 2);

                string vSql = cConstantes.SQL_Combos;
                vSql = vSql.Replace("[?1]", vcb);
                DataTable dtCombo = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

                vcbColumn.DataSource = dtCombo;
                vcbColumn.DisplayMember = dtCombo.Columns["Valores"].ToString();
                vcbColumn.ValueMember = dtCombo.Columns["ValorID"].ToString();
                vcbColumn.Name = vtxName;
                vcbColumn.HeaderText = vtxCab;
                vcbColumn.DataPropertyName = vNombre;
                grUP.Columns.Insert(vNumColumn, vcbColumn);
                //vNumColumn++;
            }
            if (vTipo == "cb2")
            {
                string vcb = cUtil.Piece(vFormatoC, "#", 2);

                string vSql = cConstantes.SQL_Combos;
                vSql = vSql.Replace("[?1]", vcb);
                DataTable dtCombo = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

                vcbColumn.DataSource = dtCombo;
                vcbColumn.DisplayMember = dtCombo.Columns["Valores"].ToString();
                vcbColumn.ValueMember = dtCombo.Columns["Valores"].ToString();
                vcbColumn.Name = vtxName;
                vcbColumn.HeaderText = vtxCab;
                vcbColumn.DataPropertyName = vNombre;
                grUP.Columns.Insert(vNumColumn, vcbColumn);
                //vNumColumn++;
            }


            if (vTipo == "cbtext")
            {

                string vcbt = cUtil.Piece(vFormatoC, "#", 2);
                string vColcb = cUtil.Piece(vcbt, "|", 1);
                string vdatcb = cUtil.Piece(vcbt, "|", 2);

                DataTable dtCombo = cUtil.fncCreaDt(vColcb, "");
                string[] vmdatcb = vdatcb.Split(',');
                for (int i = 0; i < vmdatcb.Length; i++)
                {
                    string vDato = vmdatcb[i];
                    sbrAgregaRowaDt(ref dtCombo, vDato);
                }
                vcbColumn.DataSource = dtCombo;
                vcbColumn.DisplayMember = dtCombo.Columns[vColcb].ToString();
                vcbColumn.ValueMember = dtCombo.Columns[vColcb].ToString();
                vcbColumn.Name = vtxName;
                vcbColumn.HeaderText = vtxCab;
                vcbColumn.DataPropertyName = vNombre;
                grUP.Columns.Insert(vNumColumn, vcbColumn);
                //vNumColumn++;
            }




            if (vTipo == "rel")
            {
                vtxColumn.Name = vtxName;
                vtxColumn.HeaderText = vtxCab;
                vtxColumn.DataPropertyName = vNombre;
                //vtxColumn.ReadOnly = true;
                grUP.Columns.Insert(vNumColumn, vtxColumn);
                vNumColumn++;

                string vrel = cUtil.Piece(vFormatoC, "#", 2);
                string vwhere = cUtil.Piece(vFormatoC, "#", 3);
                string vRes = cUtil.Piece(vFormatoC, "#", 4);
                string vResD = cUtil.Piece(vFormatoC, "#", 5);

                vbtColumn.Name = "bt#" + vtxName;
                vbtColumn.HeaderText = "";
                vbtColumn.Text = "...";
                vbtColumn.Tag = vrel + "#" + vwhere + "#" + vRes + "#" + vResD;
                vbtColumn.Width = 20;
                //vbtColumn.Visible = !vSoloLectura;

                grUP.Columns.Insert(vNumColumn, vbtColumn);
                //vNumColumn++;


            }


            if (vTipo == "bt")
            {

                string vrel = cUtil.Piece(vFormatoC, "#", 2);
                string vwhere = cUtil.Piece(vFormatoC, "#", 3);
                string vRes = cUtil.Piece(vFormatoC, "#", 4);
                string vResD = cUtil.Piece(vFormatoC, "#", 5);

                vbtColumn.Name = "bt#" + vtxName;
                vbtColumn.HeaderText = "";
                vbtColumn.Text = vtxCab;
                vbtColumn.Width = 30;
                

                grUP.Columns.Insert(vNumColumn, vbtColumn);
                vNumColumn++;

            }



            if (vTipo == "Color")
            {
                vtxColumn.Name = vtxName;
                vtxColumn.HeaderText = vtxCab;
                vtxColumn.DataPropertyName = vNombre;
                vtxColumn.ReadOnly = true;
                grUP.Columns.Insert(vNumColumn, vtxColumn);
                vNumColumn++;

                vbtColumn.Name = "bt#" + vtxName;
                vbtColumn.HeaderText = "";
                vbtColumn.Text = "...";
                vbtColumn.Tag = vtxName;
                vbtColumn.Width = 20;
                //vbtColumn.Visible = !vSoloLectura;

                grUP.Columns.Insert(vNumColumn, vbtColumn);
                //vNumColumn++;



            }

            if (vTipo == "ch")
            {
                vchColumn.Name = vtxName;
                vchColumn.HeaderText = vtxCab;
                vchColumn.DataPropertyName = vNombre;
                grUP.Columns.Insert(vNumColumn, vchColumn);
                //vNumColumn++;
            }

            if (vTipo == "mk")
            {
                string vmask = cUtil.Piece(vFormatoC, "#", 2);

                vmkColumn.Name = vtxName;
                vmkColumn.HeaderText = vtxCab;
                vmkColumn.DataPropertyName = vNombre;
                vmkColumn.Mask = vmask;
                grUP.Columns.Insert(vNumColumn, vmkColumn);

                //vNumColumn++;
            }

        }

        public static void sbrAgregaRowaDt(ref DataTable dt, string vDatos)
        {
            DataRow row;

            string[] vmDatos = vDatos.Split(',');

            row = dt.NewRow();

            for (int i = 0; i < vmDatos.Length; i++)
            {
                row[i] = vmDatos[i];
            }
            dt.Rows.Add(row);

        }

        public static DataTable fncCreaDt(string vColumns, string vTipos)
        {
            // Create new DataTable and DataSource objects.
            DataTable table = new DataTable();

            // Declare DataColumn and DataRow variables.
            DataColumn column;

            string[] vmColumns = vColumns.Split(',');

            for (int i = 0; i < vmColumns.Length; i++)
            {
                // Create new DataColumn, set DataType, ColumnName and add to DataTable.    
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = vmColumns[i];
                table.Columns.Add(column);

            }

            return table;
        }

        //public static string fncTraeCampo(string vCampo, string vTabla, string vWhere)
        //{
        //    string vDato = "";
        //    string vSql = "Select [?0] from [?1] " +
        //    "Where [?3]";
        //    DataAccess DALLayer = DataAccessHelper.GetDataAccess();
        //    vSql = vSql.Replace("[?0]", "[" + vCampo + "]");
        //    vSql = vSql.Replace("[?1]", vTabla);
        //    vSql = vSql.Replace("[?3]", vWhere);
        //    DataTable dt = DALLayer.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

        //    if (dt.Rows.Count > 0)
        //    {
        //        vDato = dt.Rows[0][vCampo].ToString();
        //    }

        //    return vDato;
        //}
        public static string fncTraeCampo(string vCampo, string vTabla, string vWhere)
        {
            return fncTraeCampo(vCampo, vTabla, vWhere, "");
        }
        public static string fncTraeCampo(string vCampo, string vTabla, string vWhere, string vFormul)
        {
            string vDato = "";
            string vSql = "Select [?0] from [?1] ";
            if (vWhere != "")
            {
                vSql = vSql + "Where [?3]";
            }

            if (vFormul == "") { vSql = vSql.Replace("[?0]", "[" + vCampo + "]"); } else { vSql = vSql.Replace("[?0]", vFormul); }
            vSql = vSql.Replace("[?1]", vTabla);
            vSql = vSql.Replace("[?3]", vWhere);
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

            if (dt.Rows.Count > 0)
            {
                vDato = dt.Rows[0][vCampo].ToString();
            }

            return vDato;
        }

        public static bool fncActuCampo(string vCampo, string vTabla, string vWhere, string vFormul, string vValor)
        {
            bool vOk = false;
            try
            {
                string vSql =
                        "Update [?99] " +
                        "With(RowLock) " +
                           "Set [?1] = '[?2]' ";
                if (vWhere != "")
                {
                    vSql = vSql + "Where [?3]";
                }

                if (vFormul == "") { vSql = vSql.Replace("[?1]", "[" + vCampo + "]"); } else { vSql = vSql.Replace("[?1]", vFormul); }
                vSql = vSql.Replace("[?99]", vTabla);
                vSql = vSql.Replace("[?2]", vValor);
                vSql = vSql.Replace("[?3]", vWhere);
                DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));
                vOk = true;
            }
            catch { }
            return vOk;
        }

        public static DataRow fncTraeCampos(string vTabla, string vWhere)
        {
            DataRow dr = null;
            string vSql = "Select * from [?1] ";
            if (vWhere != "")
            {
                vSql = vSql + "Where [?3]";
            }
            vSql = vSql.Replace("[?1]", vTabla);
            vSql = vSql.Replace("[?3]", vWhere);
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }

            return dr;
        }

        public static string fncLetraCol(int vCol)
        {
            //string vLetra = "A";
            //int vNumLetra = 64 + vCol;
            //vLetra = Convert.ToChar(vNumLetra).ToString();

            //return vLetra;

            return fncLetraCol(vCol, true);
        }

        public static string fncLetraCol(int number, bool isCaps)
        {
            int number1 = number / 27;
            int number2 = number - (number1 * 26);
            if (number2 > 26)
            {
                number1 = number1 + 1; number2 = number - (number1 * 26);
            }
            Char a = (Char)((isCaps ? 65 : 97) + (number1 - 1));
            Char b = (Char)((isCaps ? 65 : 97) + (number2 - 1));
            Char c = (Char)((isCaps ? 65 : 97) + (number - 1));
            string d = String.Concat(a, b);
            if (number <= 26) return c.ToString(); else return d;
        }

        public static int fncColor(int vNum)
        {
            vNum = vNum % 10;
            if (vNum == 0) { vNum = 1; }
            int vColor = 255;
            if (vNum == 1) { vColor = 16764057; }
            if (vNum == 2) { vColor = 10092543; }
            if (vNum == 3) { vColor = 5296274; }
            if (vNum == 4) { vColor = 49407; }
            if (vNum == 5) { vColor = 255; }
            if (vNum == 6) { vColor = 10040319; }
            if (vNum == 7) { vColor = 5263615; }
            if (vNum == 8) { vColor = 13408767; }
            if (vNum == 9) { vColor = 39372; }
            if (vNum == 10) { vColor = 16738047; }


            return vColor;

        }

        public static string Pass()
        {
            return "blOck07";
        }

        public static void ControlMenus(Control.ControlCollection vControls)
        {
            //MenuStrip vMs = new MenuStrip();

            //frmRRHH ofrmPrinc = new frmRRHH();


            //foreach (Control obj in vControls)
            //{
            //    string vName = obj.Name;
            //    string vTipo = obj.GetType().ToString();
            //    if (vTipo == "System.Windows.Forms.MenuStrip")
            //    {
            //        vMs = (System.Windows.Forms.MenuStrip)obj;
            //    }
            //}

            ////vMs = ofrmPrinc.mnuPrinc;

            //foreach (ToolStripMenuItem vtsm in vMs.Items)
            //{
            //    string vMenu = vtsm.Text;
            //    vMenu = vMenu.Replace("&", "");
            //    //TreeNode nuevoNodo = trMenus.Nodes.Add(vMenu, vMenu);

            //    string vCheck = cUtil.GetSetting(Application.ProductName, "Menus", vMenu, "False");
            //    string vSis = "";
            //    if (vtsm.Tag != null)
            //    {
            //        vSis = vtsm.Tag.ToString();
            //    }

            //    if (vSis == "")
            //    {
            //        if (vCheck == "True")
            //        {
            //            vtsm.Visible = true;
            //        }
            //        else
            //        {
            //            vtsm.Visible = false;
            //        }
            //    }
            //    else
            //    {
            //        vtsm.Visible = true;
            //    }

            //    if (vtsm.DropDownItems.Count > 0)
            //    {
            //        SubMenu(vtsm.DropDownItems);
            //    }
            //}


        }

        public static void SubMenu(ToolStripItemCollection vtsm)
        {

            foreach (ToolStripItem vtsm2 in vtsm)
            {
                string vInf = vtsm2.Text;
                string vName = vtsm2.Name;

                string vTipomnu = vtsm2.GetType().ToString();
                if (vTipomnu != "System.Windows.Forms.ToolStripSeparator")
                {
                    string vSis = "";
                    if (vtsm2.Tag != null)
                    {
                        vSis = vtsm2.Tag.ToString();
                    }



                    vInf = vInf.Replace("&", "");
                    //TreeNode nuevoNodo2 = nuevoNodo.Nodes.Add(vInf, vInf);
                    string vCheck = cUtil.GetSetting(Application.ProductName, "Menus", vInf, "False");

                    if (vSis == "")
                    {

                        if (vCheck == "True")
                        {
                            vtsm2.Visible = true;
                        }
                        else
                        {
                            vtsm2.Visible = false;
                        }
                    }
                    else
                    {
                        vtsm2.Visible = true;
                    }

                    if (((ToolStripMenuItem)vtsm2).DropDownItems.Count > 0)
                    {
                        SubMenu(((ToolStripMenuItem)vtsm2).DropDownItems);
                    }

                }
            }

        }

        public static string fncformateaHora(string vDif)
        {
            string vSigno = vDif.Substring(0, 1);
            if (vSigno != "-")
            {
                vSigno = "";
            }
            else
            {
                vDif = vDif.Substring(1, vDif.Length - 1);
            }

            string vDif1 = cUtil.Piece(vDif, ":", 1);
            vDif1 = vDif1.PadLeft(2, '0');

            string vDif2 = cUtil.Piece(vDif, ":", 2);
            vDif2 = vDif2.PadLeft(2, '0');
            vDif = vSigno + vDif1 + ":" + vDif2;

            return vDif;

        }

        public static Bitmap CreateBitmap(byte[] bytes, int width, int height)
        {
            byte[] rgbBytes = new byte[bytes.Length * 3];

            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                rgbBytes[(i * 3)] = bytes[i];
                rgbBytes[(i * 3) + 1] = bytes[i];
                rgbBytes[(i * 3) + 2] = bytes[i];
            }
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            for (int i = 0; i <= bmp.Height - 1; i++)
            {
                IntPtr p = new IntPtr(data.Scan0.ToInt64() + data.Stride * i);
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3);
            }

            bmp.UnlockBits(data);

            return bmp;
        }

        public static bool fncEnEjecucion(string vApli)
        {
            string vProg = vApli;
            ////MessageBox.Show(vProg);
            //System.Threading.Mutex miMutex;
            //bool nuevaInstancia;
            ////
            //miMutex = new System.Threading.Mutex(true, vProg, out nuevaInstancia);

            bool enEjecucion = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1;

            // comprobando el límite superior del array
            enEjecucion = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).GetUpperBound(0) > 0;




            //return !nuevaInstancia;
            return enEjecucion;

        }

        public static int fncIntervaloFechas(DateTime oldDate, DateTime newDate)
        {

            // Difference in days, hours, and minutes.
            TimeSpan ts = newDate - oldDate;

            // Difference in days.
            int differenceInDays = ts.Days;

            return differenceInDays;

        }

        public static bool fncPosTxEnCell(ref DataGridView gr)
        {
            bool vOk = true;

            int vCol = gr.CurrentCellAddress.X;
            int vFil = gr.CurrentCellAddress.Y;

            //int vTop = 0;
            ////Calculamos vTop
            //foreach (DataRow dr in gr.Rows[1].Cells[1].ContentBounds.Bottom.ToString()




            return vOk;
        }


        public class DateTimeEnumerator : System.Collections.IEnumerable
        {
            private DateTime begin;
            private DateTime end;

            public DateTimeEnumerator(DateTime begin, DateTime end)
            {
                this.begin = begin;
                this.end = end;
            }
            public System.Collections.IEnumerator GetEnumerator()
            {
                for (DateTime date = begin; date < end; date = date.AddDays(1))
                {
                    yield return date;
                }
            }
        }

        public static void EnviarMensaje(string mensaje, string vMail, string vFich)
        {
            EnviarMensaje(mensaje, vMail, vFich, "Error de Proceso:", "demon@icosmic.com", "demon@icosmic.com", false);
        }
        public static void EnviarMensaje(string mensaje, string vMail, string vFich, string vSubject, string vFrom, string vRepli, bool vHTML)
        {
            //bool result = false;
            string emailFrom = string.Empty;
            string emailTo = string.Empty;
            string emailSubject = string.Empty;
            string emailBody = string.Empty;
            string emailReplyTo = string.Empty;
            string mensajeAux = string.Empty;

            emailFrom = vFrom;
            emailReplyTo = vRepli;
            emailTo = vMail;
            emailSubject = vSubject;
            emailBody = mensaje;

            // Construye el mensaje de correo electrónico
            // Formato HTML
            //cEnvioMail oMensaje = new cEnvioMail(emailFrom, emailTo, emailSubject, emailBody, string.Empty, true, emailReplyTo);
            cEnvioMail oMensaje = new cEnvioMail(emailFrom, emailTo, emailSubject, emailBody, vFich, vHTML, emailReplyTo);

            // Envío del mensaje
            if (oMensaje.Send())
            {
            }
            else
            {
            }

        }


        public ArrayList LeeFicheroTexto(string vPath)
        {
            ArrayList vArrL = new ArrayList();
            try
            {
                StreamReader sw = new StreamReader(vPath, Encoding.Default);
                //StreamReader sw = new StreamReader(vPath);
                string vLinea = "";

                while (vLinea != null)
                {
                    vLinea = sw.ReadLine();
                    if (vLinea != null)
                    {
                        vArrL.Add(vLinea);
                    }
                }
                sw.Close();
                _Error = "";
                return vArrL;
            }
            catch (Exception ex)
            {

                _Error = ex.Message;
                _NumError = 0;
                if (_Error.Substring(0, 31) == "No se pudo encontrar el archivo") { _NumError = 1; }
                return vArrL;
            }
        }
        public static string fncLeeFicheroTexto(string vPath)
        {
            string vTextos = "";
            try
            {
                StreamReader sw = new StreamReader(vPath, Encoding.Default);
                //StreamReader sw = new StreamReader(vPath);
                string vLinea = "";

                while (vLinea != null)
                {
                    vLinea = sw.ReadLine();
                    if (vLinea != null)
                    {
                        vTextos += vLinea;
                    }
                }
                sw.Close();
                return vTextos;
            }
            catch (Exception ex)
            {

                return vTextos;
            }
        }


        private int FtpUpload(string server, string user, string pass, string origen, string rutadestino, string nombredestino)
        {

            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(server + rutadestino + "/" + nombredestino);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(user, pass);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;
                FileStream stream = File.OpenRead(origen);
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                stream.Close();
                System.IO.Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Flush();
                reqStream.Close();

                return 1;
            }
            catch (Exception ex)
            {
                _Error = ex.Message.ToString();
                return 0;
            }

        }



        /// Upload File to Specified FTP Url with username and password and Upload Directory 
        ///if need to upload in sub folders 
        ///Base FtpUrl of FTP Server
        ///Local Filename to Upload
        ///Username of FTP Server
        ///Password of FTP Server
        ///[Optional]Specify sub Folder if any
        /// Status String from Server
        public static string UploadFile(string FtpUrl, string fileName, string userName,
                                        string password, string UploadDirectory = "")
        {
            try
            {
                string PureFileName = new FileInfo(fileName).Name;
                String uploadUrl = String.Format("{0}{1}/{2}", FtpUrl, UploadDirectory, PureFileName);
                FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(uploadUrl);
                req.Proxy = null;
                req.Method = WebRequestMethods.Ftp.UploadFile;
                req.Credentials = new NetworkCredential(userName, password);
                req.UseBinary = true;
                req.UsePassive = true;
                byte[] data = File.ReadAllBytes(fileName);
                req.ContentLength = data.Length;
                System.IO.Stream stream = req.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();
                FtpWebResponse res = (FtpWebResponse)req.GetResponse();
                return res.StatusDescription;
            }
            catch (Exception ex)
            { return ex.Message; }
        }



        /// Download File From FTP Server /// 
        ///Base url of FTP Server
        ///if file is in root then write FileName Only if is in use like "subdir1/subdir2/filename.ext"
        ///Username of FTP Server
        ///Password of FTP Server
        ///Folderpath where you want to Download the File
        /// Status String from Server
        public static string DownloadFile(string FtpUrl, string FileNameToDownload,
                                          string userName, string password, string tempDirPath)
        {
            try
            {
                string ResponseDescription = "";
                string PureFileName = new FileInfo(FileNameToDownload).Name;
                string DownloadedFilePath = tempDirPath + "/" + PureFileName;
                string downloadUrl = String.Format("{0}/{1}", FtpUrl, FileNameToDownload);
                FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(downloadUrl);
                req.Method = WebRequestMethods.Ftp.DownloadFile;
                req.Credentials = new NetworkCredential(userName, password);
                req.UseBinary = true;
                req.Proxy = null;
                try
                {
                    FtpWebResponse response = (FtpWebResponse)req.GetResponse();
                    System.IO.Stream stream = response.GetResponseStream();
                    byte[] buffer = new byte[2048];
                    FileStream fs = new FileStream(DownloadedFilePath, FileMode.Create);
                    int ReadCount = stream.Read(buffer, 0, buffer.Length);
                    while (ReadCount > 0)
                    {
                        fs.Write(buffer, 0, ReadCount);
                        ReadCount = stream.Read(buffer, 0, buffer.Length);
                    }
                    ResponseDescription = response.StatusDescription;
                    fs.Close();
                    stream.Close();
                }
                catch (Exception e)
                {
                    return e.Message;
                }
                return ResponseDescription;
            }
            catch (Exception ex)
            { return ex.Message; }
        }



        public static DataSet Trae(string vSql, DataSet ds, string vTableName, SqlConnection oSqlConec)
        {
            SqlDataAdapter da = new SqlDataAdapter();

            SqlCommand sc = new SqlCommand(vSql, oSqlConec);
            sc.CommandTimeout = 1200;

            da = new SqlDataAdapter(sc);
            // Llenar la tabla con los datos indicados
            try
            {

                da.Fill(ds, vTableName);
            }
            catch { }

            return ds;
        }



        //public void fncCapturarPantalla(string vFich)
        //{
        //    // Capturar todo el área del formulario

        //    Graphics gr = this.CreateGraphics();
        //    // Tamaño de lo que queremos copiar
        //    Size fSize = this.Size;
        //    // Creamos el bitmap con el área que vamos a capturar
        //    // En este caso, con el tamaño del formulario actual
        //    Bitmap bm = new Bitmap(fSize.Width, fSize.Height, gr);
        //    // Un objeto Graphics a partir del bitmap
        //    Graphics gr2 = Graphics.FromImage(bm);
        //    // Copiar el área de la pantalla que ocupa el formulario
        //    gr2.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, fSize);

        //    // Asignamos la imagen al PictureBox
        //    //this.picCaptura.Image = bm;

        //    // Guardarlo como JPG
        //    bm.Save(vfich, System.Drawing.Imaging.ImageFormat.Jpeg);
        //}
    }

}
