using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jControles.Clases;
using System.Windows.Forms;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;

namespace GesInject.Clases
{
    class cClientes
    {
        public static int vCont = 0;
        public static List<DirEntrega> Lista(string vCli)
        {

            List<DirEntrega> listaDir = new List<DirEntrega>();

            using (SqlConnection vConnec = new SqlConnection(cParamXml.strConecProduc_Prueb))
            {
                vConnec.Open();
                string vSql = cConstantes.SQL_DirEntrega;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?CodCli]", vCli);

                SqlDataReader dr = cUtil.fncTraeDataReader(vSql, vConnec);
                if (dr.HasRows == true) while (dr.Read())
                        listaDir.Add(new DirEntrega((int)dr[0], (int)dr[1], dr[2].ToString(), (int)dr[3],
                                                            dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString()));
                vConnec.Close();
            }

            return listaDir;
        }
        
        public class DirEntrega:Entidad
        {
            private string _Error = "";
            private int _Id = 0;
            private int _Empresa = 1;
            private string _CodCli = "";
            private int _IdEntrega = 0;
            private string _Dirección = "";
            private string _Población = "";
            private string _Provincia = "";
            private string _CP = "";

            private string vCamposIndice = ",Empresa,CodCli,IdEntrega";
            private string vTabla = "[GC_DirEntregas]";

            #region Propiedades
            public string Error
            {
                get { return _Error; }
                set { _Error = value; }
            }
            public int Id
            {
                get { return _Id; }
                set
                {
                    sbrPropiAdi("Id", _Id.ToString(), value.ToString());
                    _Id = value;
                }
            }
            public int Empresa
            {
                get { return _Empresa; }
                set
                {
                    sbrPropiAdi("Empresa", _Empresa.ToString(), value.ToString());
                    _Empresa = value;
                }
            }
            public string CodCli
            {
                get { return _CodCli; }
                set
                {
                    sbrPropiAdi("CodCli", _CodCli.ToString(), value.ToString());
                    _CodCli = value;
                }
            }
            public int IdEntrega
            {
                get { return _IdEntrega; }
                set
                {
                    sbrPropiAdi("NumPed", _IdEntrega.ToString(), value.ToString());
                    _IdEntrega = value;
                }
            }
            public string Dirección
            {
                get { return _Dirección; }
                set
                {
                    sbrPropiAdi("Dirección", _Dirección.ToString(), value.ToString());
                    _Dirección = value;
                }
            }
            public string Población
            {
                get { return _Población; }
                set
                {
                    sbrPropiAdi("Población", _Población.ToString(), value.ToString());
                    _Población = value;
                }
            }
            public string Provincia
            {
                get { return _Provincia; }
                set
                {
                    sbrPropiAdi("Provincia", _Provincia.ToString(), value.ToString());
                    _Provincia = value;
                }
            }
            public string CP
            {
                get { return _CP; }
                set
                {
                    sbrPropiAdi("CP", _CP.ToString(), value.ToString());
                    _CP = value;
                }
            }


            #endregion

            #region Constructor
            public DirEntrega()
            {}
            public DirEntrega(int vId, int vEmpresa, string vCodCli, int vIdEntrega, string vDireccion, 
                            string vPoblacion,string vProvincia, string vCP)
            {
                _Id = vId;
                _Empresa = vEmpresa;
                _IdEntrega = vIdEntrega;
                _CodCli = vCodCli;
                _Dirección = vDireccion;
                _Población = vPoblacion;
                _Provincia = vProvincia;
                _CP = vCP;
            }

        #endregion

            #region Metodos

            public bool fncGrabaCampo(string vCampo, string vValor)
            {
                bool vOk = false;
                int viOk = 1;
                if ((vCamposIndice.LastIndexOf("," + vCampo + ",") == -1) | (aValorAnt == ""))
                {
                    if (vValor != aValorAnt)
                    {
                        string vSql = "";
                        string vWhere = " Id = " + _Id;
                        vSql = cConstantes.SQL_UP_Update;
                        vSql = vSql.Replace("[?1]", "[" + vCampo + "]");
                        vSql = vSql.Replace("[?2]", vValor);
                        vSql = vSql.Replace("[?3]", vWhere);
                        vSql = vSql.Replace("[?99]", vTabla);
                        viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                    }

                    if (viOk == 1)
                    {
                        vOk = true;
                        aCampoModif = "";
                        aValor = "";
                        aValorAnt = "";
                    }
                    else
                    {
                        sbrRollback();
                    }
                }
                else
                {
                    if (vValor != "")
                    {
                        MessageBox.Show(string.Format("El Campo:{0} es un indice,NO se puede Modificar", aCampoModif));
                    }
                    else
                    {
                        MessageBox.Show(string.Format("El Campo:{0} es un indice,NO se puede quedar en blanco", aCampoModif));
                    }

                    sbrRollback();
                }
                return vOk;
            }
            public bool fncBaja(string vID)
            {
                bool vOk = false;
                string vSql = "";
                string vWhere = " Id = " + _Id;
                vSql = cConstantes.SQL_UP_Delete;
                vSql = vSql.Replace("[?1]", vWhere);
                vSql = vSql.Replace("[?99]", vTabla);
                int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                if (viOk == 1)
                {
                    vOk = true;
                    aCampoModif = "";
                    aValor = "";
                    aValorAnt = "";
                }


                return vOk;
            }
            public int fncAlta()
            {

                int vNumSer = fncTraeIdDir(cParamXml.Emp,_CodCli);

                string vValores = cUtil.fncCargaValoresSQLDefault(vTabla, cParamXml.strConec, "Id", "Empresa,CodCli,IdEntrega,", cParamXml.Emp + "," + _CodCli + "," + vNumSer.ToString());
                string vCampos = cUtil.Piece(vValores, "#", 2);
                string vValoresDef = cUtil.Piece(vValores, "#", 5);

                string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresDef;
                int vIdentity = 0;
                try
                {
                    vIdentity = SQLDataAccess.GEN_ExecuteScalarIdentity(vSql, cParamXml.strConec);
                    _Id = vIdentity;
                    //_NumPed = 0;
                    //_CodCli = "";
                    _Dirección = "";
                    _Población = "";
                    _Provincia = "";
                    _CP = "";
                }
                catch { }

                return vIdentity;
            }
            public bool fncAlta0(int vIdEnt)
            {
                bool vOk = false;
                try
                {
                    string vTabla = "GC_DirEntregas";
                    
                    string vValoresCab = cUtil.fncCargaValoresSQL(vTabla, cParamXml.strConec, "Id");
                    int vNumCampos = Convert.ToInt16(cUtil.Piece(vValoresCab, "#", 3));
                    string vCampos = cUtil.Piece(vValoresCab, "#", 2);
                    vValoresCab = cUtil.Piece(vValoresCab, "#", 1);
                    string vCamposRelp = vCampos.Substring(1, vCampos.Length - 2);

                    string[] vDatos = new string[vNumCampos];
                    for (int i = 0; i < vNumCampos; i++)
                    {
                        vDatos[i] = "";
                    }

                    string vDir = _Dirección.Replace("'", " ");
                    vDir = vDir.Replace(",", " ");
                    string vPob = _Población.Replace("'", " ");
                    vDir = vDir.Replace(",", " ");
                    string vProv = _Provincia.Replace("'", " ");
                    vDir = vDir.Replace(",", " ");

                    vDatos[1] = _Empresa.ToString();
                    vDatos[2] = _CodCli;
                    vDatos[3] = vIdEnt.ToString();
                    vDatos[4] = vDir;
                    vDatos[5] = vPob;
                    vDatos[6] = vProv;
                    vDatos[7] = _CP;


                    string vValoresNew = cUtil.fncReplaceValoresSQL(vDatos, vValoresCab, vNumCampos);
                    string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresNew;
                    int vCor = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                    if (vCor == 1)
                    {
                        vOk = true;
                    }
                    else
                    {
                        _Error = "Error al dar de Alta";
                    }
                }
                catch (Exception ex)
                {
                    _Error = ex.Message;
                    vOk = false;
                }
                return vOk;
            }


            private void sbrPropiAdi(string vCampo, string vValorAnt, string vValor)
            {
                //RaisePropertyChanged(vCampo);
                IsDirty = true;
                aCampoModif = vCampo;
                aValorAnt = vValorAnt;
                aValor = vValor;
            }
            private void sbrRollback()
            {
                PropertyInfo vProp = GetType().GetProperty(aCampoModif);
                if (vProp != null)
                {
                    if (vProp.PropertyType != typeof(string))
                    {
                        if (vProp.PropertyType == typeof(Boolean)) { vProp.SetValue(this, Convert.ToBoolean(aValorAnt), null); }
                        if (vProp.PropertyType == typeof(DateTime)) { vProp.SetValue(this, Convert.ToDateTime(aValorAnt), null); }
                        if (vProp.PropertyType == typeof(Decimal)) { vProp.SetValue(this, Convert.ToDecimal(aValorAnt), null); }
                        if (vProp.PropertyType == typeof(Double)) { vProp.SetValue(this, Convert.ToDouble(aValorAnt), null); }
                        if (vProp.PropertyType == typeof(Int16)) { vProp.SetValue(this, Convert.ToInt16(aValorAnt), null); }
                        if (vProp.PropertyType == typeof(Int32)) { vProp.SetValue(this, Convert.ToInt32(aValorAnt), null); }
                        if (vProp.PropertyType == typeof(Int64)) { vProp.SetValue(this, Convert.ToInt64(aValorAnt), null); }
                        if (vProp.PropertyType == typeof(Byte)) { vProp.SetValue(this, Convert.ToByte(aValorAnt), null); }
                    }
                    else
                    {
                        vProp.SetValue(this, aValorAnt, null);
                    }
                }

            }
            
        #endregion

            #region Metodos Staticos
            public static int fncTraeIdDir(int vEmp,string vCli)
            {
                int vNum = 0;
                string vSql = cConstantes.SQL_NumId;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?CodCli]", vCli);

                DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));
                if (dt.Rows.Count > 0)
                {
                    vNum = Convert.ToInt32(dt.Rows[0]["IdEnt"].ToString());
                }

                vNum++;

                return vNum;
            }

            #endregion



        }

        //--------------------------------------------------------------------------------------------------

        public class ClienteProducto : Entidad
        {

            #region Variable Locales

            private string _Error = "";
            private int _Id = 0;
            private int _Empresa = 1;
            private string _CodCli = "";
            private string _NomCli = "";
            private string _Producto = "";
            private string _Descripción = "";
            private string _ProductoCli = "";
            private int _EtiCli = 0;
            private string _EtiDes = "";

            #endregion

            private string vCamposIndice = ",Empresa,CodCli,Producto,ProductoCli";
            private string vTabla = "[GC_ClienteProducto]";

            #region Propiedades
            public string Error
            {
                get { return _Error; }
                set { _Error = value; }
            }
            public int Id
            {
                get { return _Id; }
                set
                {
                    sbrPropiAdi("Id", _Id.ToString(), value.ToString());
                    _Id = value;
                }
            }
            public int Empresa
            {
                get { return _Empresa; }
                set
                {
                    sbrPropiAdi("Empresa", _Empresa.ToString(), value.ToString());
                    _Empresa = value;
                }
            }
            public string CodCli
            {
                get { return _CodCli; }
                set
                {
                    sbrPropiAdi("CodCli", _CodCli.ToString(), value.ToString());
                    _CodCli = value;
                }
            }
            public string NomCli
            {
                get { return _NomCli; }
                set
                {
                    sbrPropiAdi("NomCli", _NomCli.ToString(), value.ToString());
                    _NomCli = value;
                }
            }
            public string Producto
            {
                get { return _Producto; }
                set
                {
                    sbrPropiAdi("Producto", _Producto.ToString(), value.ToString());
                    _Producto = value;
                }
            }
            public string Descripción
            {
                get { return _Descripción; }
                set
                {
                    sbrPropiAdi("Descripción", _Descripción.ToString(), value.ToString());
                    _Descripción = value;
                }
            }
            public string ProductoCli
            {
                get { return ProductoCli; }
                set
                {
                    sbrPropiAdi("ProductoCli", _ProductoCli.ToString(), value.ToString());
                    _ProductoCli = value;
                }
            }
            public int EtiCli
            {
                get { return _EtiCli; }
                set
                {
                    sbrPropiAdi("EtiCli", _EtiCli.ToString(), value.ToString());
                    _EtiCli = value;
                }
            }
            public string EtiDes
            {
                get { return _EtiDes; }
                set
                {
                    sbrPropiAdi("EtiDes", _EtiDes.ToString(), value.ToString());
                    _EtiDes = value;
                }
            }

            #endregion

            #region Constructor
            public ClienteProducto()
            {
                aNuevo = true;
            }

            public ClienteProducto(SqlDataReader dr)
            {
                _Id = (int)dr["Id"];
                _Empresa = (int)dr["Empresa"];
                _CodCli = dr["CodCli"].ToString();
                _NomCli = dr["NomCli"].ToString();
                _Producto = dr["Producto"].ToString();
                _Descripción = dr["Descripción"].ToString();
                _ProductoCli = dr["ProductoCli"].ToString();
                _EtiCli = (int)dr["EtiCli"];
                _EtiDes = dr["EtiDes"].ToString();

            }

            #endregion

            #region Metodos

            public bool fncGrabaCampo(string vCampo, string vValor)
            {
                bool vOk = false;
                int viOk = 1;
                if ((vCamposIndice.LastIndexOf("," + vCampo + ",") == -1) | (aValorAnt == ""))
                {
                    if (vValor != aValorAnt)
                    {
                        string vSql = "";
                        string vWhere = " Id = " + _Id;
                        vSql = cConstantes.SQL_UP_Update;
                        vSql = vSql.Replace("[?1]", "[" + vCampo + "]");
                        vSql = vSql.Replace("[?2]", vValor);
                        vSql = vSql.Replace("[?3]", vWhere);
                        vSql = vSql.Replace("[?99]", vTabla);
                        viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                    }

                    if (viOk == 1)
                    {
                        vOk = true;
                        aCampoModif = "";
                        aValor = "";
                        aValorAnt = "";
                    }
                    else
                    {
                        sbrRollback();
                    }
                }
                else
                {
                    if (vValor != "")
                    {
                        MessageBox.Show(string.Format("El Campo:{0} es un indice,NO se puede Modificar", aCampoModif));
                    }
                    else
                    {
                        MessageBox.Show(string.Format("El Campo:{0} es un indice,NO se puede quedar en blanco", aCampoModif));
                    }

                    sbrRollback();
                }
                return vOk;

                //bool vOk = false;
                //int viOk = 1;
                //if ((vCamposIndice.LastIndexOf("," + vCampo + ",") == -1))
                //{
                //    string vSql = "";
                //    string vWhere = " Id = " + _Id;
                //    vSql = cConstantes.SQL_UP_Update;
                //    vSql = vSql.Replace("[?1]", "[" + vCampo + "]");
                //    vSql = vSql.Replace("[?2]", vValor);
                //    vSql = vSql.Replace("[?3]", vWhere);
                //    vSql = vSql.Replace("[?99]", vTabla);
                //    viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);

                //    if (viOk == 1)
                //    {
                //        vOk = true;
                //    }
                //}
                //else
                //{
                //    vOk = false;
                //}
                //return vOk;
            }
            public bool fncBaja(string vID)
            {
                bool vOk = false;
                string vSql = "";
                string vWhere = " Id = " + _Id;
                vSql = cConstantes.SQL_UP_Delete;
                vSql = vSql.Replace("[?1]", vWhere);
                vSql = vSql.Replace("[?99]", vTabla);
                int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                if (viOk == 1)
                {
                    vOk = true;
                    aCampoModif = "";
                    aValor = "";
                    aValorAnt = "";
                }


                return vOk;
            }

            public bool fncAlta()
            {
                bool vOk = false;
                try
                {

                    string vValoresCab = cUtil.fncCargaValoresSQL(vTabla, cParamXml.strConec, "Id");
                    int vNumCampos = Convert.ToInt16(cUtil.Piece(vValoresCab, "#", 3));
                    string vCampos = cUtil.Piece(vValoresCab, "#", 2);
                    vValoresCab = cUtil.Piece(vValoresCab, "#", 1);
                    string vCamposRelp = vCampos.Substring(1, vCampos.Length - 2);

                    string[] vDatos = new string[vNumCampos];
                    for (int i = 0; i < vNumCampos; i++)
                    {
                        vDatos[i] = "";
                    }

                    vDatos[1] = _Empresa.ToString();
                    vDatos[2] = _CodCli;
                    vDatos[3] = _NomCli;
                    vDatos[4] = _Producto;
                    vDatos[5] = _Descripción;
                    vDatos[6] = _ProductoCli;
                    vDatos[7] = _EtiCli.ToString();
                    vDatos[8] = _EtiDes;


                    string vValoresNew = cUtil.fncReplaceValoresSQL(vDatos, vValoresCab, vNumCampos);
                    string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresNew;
                    int vCor = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                    if (vCor == 1)
                    {
                        vOk = true;
                    }
                    else
                    {
                        _Error = "Error al dar de Alta";
                    }
                }
                catch (Exception ex)
                {
                    _Error = ex.Message;
                    vOk = false;
                }
                return vOk;
            }

            private void sbrPropiAdi(string vCampo, string vValorAnt, string vValor)
            {
                //RaisePropertyChanged(vCampo);
                IsDirty = true;
                aCampoModif = vCampo;
                aValorAnt = vValorAnt;
                aValor = vValor;
            }
            private void sbrRollback()
            {
                PropertyInfo vProp = GetType().GetProperty(aCampoModif);
                if (vProp != null)
                {
                    if (vProp.PropertyType != typeof(string))
                    {
                        if (vProp.PropertyType == typeof(Boolean)) { vProp.SetValue(this, Convert.ToBoolean(aValorAnt), null); }
                        if (vProp.PropertyType == typeof(DateTime)) { vProp.SetValue(this, Convert.ToDateTime(aValorAnt), null); }
                        if (vProp.PropertyType == typeof(Decimal)) { vProp.SetValue(this, Convert.ToDecimal(aValorAnt), null); }
                        if (vProp.PropertyType == typeof(Double)) { vProp.SetValue(this, Convert.ToDouble(aValorAnt), null); }
                        if (vProp.PropertyType == typeof(Int16)) { vProp.SetValue(this, Convert.ToInt16(aValorAnt), null); }
                        if (vProp.PropertyType == typeof(Int32)) { vProp.SetValue(this, Convert.ToInt32(aValorAnt), null); }
                        if (vProp.PropertyType == typeof(Int64)) { vProp.SetValue(this, Convert.ToInt64(aValorAnt), null); }
                        if (vProp.PropertyType == typeof(Byte)) { vProp.SetValue(this, Convert.ToByte(aValorAnt), null); }
                    }
                    else
                    {
                        vProp.SetValue(this, aValorAnt, null);
                    }
                }

            }

            #endregion



        }


    }
}
