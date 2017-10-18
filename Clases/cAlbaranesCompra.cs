using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;
using jControles.Clases;


namespace GesInject.Clases
{
    class cAlbaranesCompra
    {
        public static List<CabAlbCompra> Lista()
        {

            List<CabAlbCompra> listaProy = new List<CabAlbCompra>();

            using (SqlConnection vConnec = new SqlConnection(cParamXml.strConecProduc_Prueb))
            {
                vConnec.Open();
                string vSql = cConstantes.SQL_CabAlbCompra;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());

                SqlDataReader dr = cUtil.fncTraeDataReader(vSql, vConnec);
                //if (dr.HasRows == true) while (dr.Read()) listaProy.Add(new CabAlbCompra((int)dr["Id"], (int)dr["Empresa"], dr["NumAlb"].ToString(), dr["Estado"].ToString(), (DateTime)dr["FechaAlbaran"],
                //                                                                     dr["CodProv"].ToString(), dr["NombreProv"].ToString(), dr["RecepcionadoPor"].ToString(), dr["NumPed"].ToString(),  
                //                                                                     dr["SuAlbaran"].ToString()));
                if (dr.HasRows == true) while (dr.Read()) listaProy.Add(new CabAlbCompra(dr));

                vConnec.Close();
            }

            return listaProy;
        }

        public class CabAlbCompra : Entidad
        {
            private int _Id = 0;
            private int _Empresa = 1;
            private string _NumAlb = "0";
            private string _Estado = "";
            private DateTime _FechaAlbaran = DateTime.UtcNow;
            private string _CodProv = "";
            private string _NombreProv = "";
            private string _RecepcionadoPor = "";
            private string _NumPed = "";
            private string _SuAlbaran = "";

            private string vCamposIndice = ",Empresa,NumAlb,";
            private string vTabla = "[GC_CabAlbProv]";

            #region Propiedades
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
            public string NumAlb
            {
                get { return _NumAlb; }
                set
                {
                    sbrPropiAdi("NumAlb", _NumAlb.ToString(), value.ToString());
                    _NumAlb = value;
                }
            }
            public string Estado
            {
                get { return _Estado; }
                set
                {
                    sbrPropiAdi("Estado", _Estado.ToString(), value.ToString());
                    _Estado = value;
                }
            }
            public DateTime FechaAlbaran
            {
                get { return _FechaAlbaran; }
                set
                {
                    sbrPropiAdi("FechaAlbaran", _FechaAlbaran.ToString(), value.ToString());
                    _FechaAlbaran = value;
                }
            }
            public string CodProv
            {
                get { return _CodProv; }
                set
                {
                    sbrPropiAdi("CodProv", _CodProv.ToString(), value.ToString());
                    _CodProv = value;
                }
            }
            public string NombreProv
            {
                get { return _NombreProv; }
                set
                {
                    sbrPropiAdi("NombreProv", _NombreProv.ToString(), value.ToString());
                    _NombreProv = value;
                }
            }
            public string RecepcionadoPor
            {
                get { return _RecepcionadoPor; }
                set
                {
                    sbrPropiAdi("RecepcionadoPor", _RecepcionadoPor.ToString(), value.ToString());
                    _RecepcionadoPor = value;
                }
            }
            public string NumPed
            {
                get { return _NumPed; }
                set
                {
                    sbrPropiAdi("NumPed", _NumPed.ToString(), value.ToString());
                    _NumPed = value;
                }
            }
            public string SuAlbaran
            {
                get { return _SuAlbaran; }
                set
                {
                    sbrPropiAdi("SuAlbaran", _SuAlbaran.ToString(), value.ToString());
                    _SuAlbaran = value;
                }
            }




            #endregion

            #region Constructor
            public CabAlbCompra()
            {
                aNuevo = true;
            }
            //public CabAlbCompra(int vId, int vEmpresa, string vNumAlb, string vEstado, DateTime vFechaAlbaran,
            //                string vCodProv, string vNombreProv, string vRecepcionadoPor,
            //                string vNumPed, string vSuAlbaran)
            //{
            //    _Id = vId;
            //    _Empresa = vEmpresa;
            //    _NumAlb = vNumAlb;
            //    _Estado = vEstado;
            //    _FechaAlbaran = vFechaAlbaran;
            //    _CodProv = vCodProv;
            //    _NombreProv = vNombreProv;
            //    _RecepcionadoPor = vRecepcionadoPor;
            //    _NumPed = vNumPed;
            //    _SuAlbaran = vSuAlbaran;


            //}

            public CabAlbCompra(SqlDataReader dr)
            {
                fncCargaClase(dr);
            }


            #endregion

            #region Metodos Privados
            private void fncCargaClase(SqlDataReader dr)
            {
                _Id = (int)dr["Id"];
                _Empresa = (int)dr["Empresa"];
                _NumAlb = dr["NumAlb"].ToString();
                _Estado = dr["Estado"].ToString();
                _FechaAlbaran = (DateTime)dr["FechaAlbaran"];
                _CodProv = dr["CodProv"].ToString();
                _NombreProv = dr["NombreProv"].ToString();
                _RecepcionadoPor = dr["RecepcionadoPor"].ToString();
                _NumPed = dr["NumPed"].ToString();
                _SuAlbaran = dr["SuAlbaran"].ToString();

             }

            #endregion

            #region Metodos


            public bool fncGrabaCampo(string vCampo, string vValor)
            {
                vValor = vValor.Replace("'", " ");
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

                string vNumSer = SQLDataAccess.GenTraeNumSerie(cParamXml.NSerAlbProv, true, cParamXml.strConec);

                string vValores = cUtil.fncCargaValoresSQLDefault(vTabla, cParamXml.strConec, "Id", "NumAlb,Empresa,Estado,FechaAlbaran", vNumSer.ToString() + "," + cParamXml.Emp + ",P," + DateTime.Now.ToShortDateString());
                string vCampos = cUtil.Piece(vValores, "#", 2);
                string vValoresDef = cUtil.Piece(vValores, "#", 5);

                string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresDef;
                int vIdentity = 0;
                try
                {
                    vIdentity = SQLDataAccess.GEN_ExecuteScalarIdentity(vSql, cParamXml.strConec);
                    _Id = vIdentity;
                    _FechaAlbaran = DateTime.Now;
                    _CodProv = "";
                    _NombreProv = "";
                    _RecepcionadoPor = "";
                    _NumPed = "";
                    _SuAlbaran = "";
                }
                catch { }

                return vIdentity;
            }

            public bool fncExiste(int vEmpresa,string vAlb)
            {
                bool vOk = false;
                using (SqlConnection vConnec = new SqlConnection(cParamXml.strConecProduc_Prueb))
                {
                    vConnec.Open();
                    string vSql = cConstantes.SQL_CabAlbCompra_Alb;
                    vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                    vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                    vSql = vSql.Replace("[?Emp]", vEmpresa.ToString());
                    vSql = vSql.Replace("[?Alb]", vAlb);

                    SqlDataReader dr = cUtil.fncTraeDataReader(vSql, vConnec);

                    if (dr.HasRows == true)
                    {
                        dr.Read();
                        fncCargaClase(dr);
                        vOk = true;
                    }

                    vConnec.Close();
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
        public static int fncBuscaIndexCabAlb(BindingSource bS, string vAlb)
        {
            int vReg = 0;

            if (bS.SupportsSearching)
            {
                vReg = bS.Find("NumAlb", vAlb);
            }
            else
            {
                List<cAlbaranesCompra.CabAlbCompra> lista = (List<cAlbaranesCompra.CabAlbCompra>)bS.List;

                cAlbaranesCompra.CabAlbCompra result = lista.Find(
                delegate(cAlbaranesCompra.CabAlbCompra bus)
                {
                    return bus.NumAlb == vAlb;
                }
                );


                if (result != null)
                {
                    vReg = bS.IndexOf(result);

                }

            }

            return vReg;
        }

        //--------------------------------------------------------------------------------------------------

        public static List<LinAlbCompra> ListaLineas(string vAlb)
        {
            List<LinAlbCompra> listaLineas = new List<LinAlbCompra>();

            using (SqlConnection vConnec = new SqlConnection(cParamXml.strConecProduc_Prueb))
            {
                vConnec.Open();
                string vSql = cConstantes.SQL_LinAlbCompra;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?Alb]", vAlb);

                SqlDataReader dr = cUtil.fncTraeDataReader(vSql, vConnec);
                if (dr.HasRows == true) while (dr.Read())
                        listaLineas.Add(new LinAlbCompra(dr));

                        //listaLineas.Add(new LinAlbCompra((int)dr["Id"], (int)dr["Empresa"], dr["NumAlb"].ToString(),
                        //                                (int)dr["Linea"],(DateTime)dr["FechaEntrega"], dr["Producto"].ToString(),
                        //                                dr["Descripción"].ToString(), dr["CodProv"].ToString(), dr["NombreProv"].ToString(), (Decimal)dr["Cantidad"],
                        //                                dr["Lote"].ToString(), dr["RecepcionadoPor"].ToString(), (int)dr["Grabado"], dr["NUmPed"].ToString(),
                        //                                dr["Obs"].ToString()));
                vConnec.Close();
            }



            return listaLineas;

        }

        public class LinAlbCompra:Entidad
        {

            private string _Error = "";
            private int _Id = 0;
            private int _Empresa = 1;
            private string _NumAlb = "0";
            private int _Linea = 0;
            private DateTime _FechaEntrega = DateTime.UtcNow;
            private string _Producto = "";
            private string _Descripción = "";
            private string _CodProv = "";
            private string _NombreProv = "";
            private decimal _Cantidad = 0;
            private string _Lote = "";
            private string _RecepcionadoPor = "";
            private int _Grabado = 0;
            private string _NumPed = "";
            private string _Obs = "";
            private string _Cert = "";
            private string _SuAlb = "";
            private string _Ubi = "";
            private string _NumSerie = "";


            private string vCamposIndice = ",Empresa,NumAlb,Linea";
            private string vTabla = "[GC_AlbProv]";

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
            public string NumAlb
            {
                get { return _NumAlb; }
                set 
                {
                    sbrPropiAdi("NumAlb", _NumAlb.ToString(), value.ToString());
                    _NumAlb = value;
                }
            }
            public int Linea
            {
                get { return _Linea; }
                set 
                {
                    sbrPropiAdi("Linea", _Linea.ToString(), value.ToString());
                    _Linea = value;
                }
            }
            public DateTime FechaEntrega
            {
                get { return _FechaEntrega; }
                set
                {
                    sbrPropiAdi("FechaEntrega", _FechaEntrega.ToString(), value.ToString());
                    _FechaEntrega = value;
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
            public string CodProv
            {
                get { return _CodProv; }
                set
                {
                    sbrPropiAdi("CodProv", _CodProv.ToString(), value.ToString());
                    _CodProv = value;
                }
            }
            public string NombreProv
            {
                get { return _NombreProv; }
                set
                {
                    sbrPropiAdi("NombreProv", _NombreProv.ToString(), value.ToString());
                    _NombreProv = value;
                }
            }
            public decimal Cantidad
            {
                get { return _Cantidad; }
                set
                {
                    sbrPropiAdi("Cantidad", _Cantidad.ToString(), value.ToString());
                    _Cantidad = value;
                }
            }
            public string Lote
            {
                get { return _Lote; }
                set
                {
                    sbrPropiAdi("Lote", _Lote.ToString(), value.ToString());
                    _Lote = value;
                }
            }
            public string RecepcionadoPor
            {
                get { return _RecepcionadoPor; }
                set
                {
                    sbrPropiAdi("RecepcionadoPor", _RecepcionadoPor.ToString(), value.ToString());
                    _RecepcionadoPor = value;
                }
            }
            public int Grabado
            {
                get { return _Grabado; }
                set
                {
                    sbrPropiAdi("Grabado", _Grabado.ToString(), value.ToString());
                    _Grabado = value;
                }
            }
            public string NumPed
            {
                get { return _NumPed; }
                set
                {
                    sbrPropiAdi("NumPed", _NumPed.ToString(), value.ToString());
                    _NumPed = value;
                }
            }
            public string Obs
            {
                get { return _Obs; }
                set
                {
                    sbrPropiAdi("Obs", _Obs.ToString(), value.ToString());
                    _Obs = value;
                }
            }
            public string Cert
            {
                get { return _Cert; }
                set
                {
                    sbrPropiAdi("Cert", _Cert.ToString(), value.ToString());
                    _Cert = value;
                }
            }
            public string SuAlb
            {
                get { return _SuAlb; }
                set
                {
                    sbrPropiAdi("SuAlb", _SuAlb.ToString(), value.ToString());
                    _SuAlb = value;
                }
            }
            public string Ubi
            {
                get { return _Ubi; }
                set
                {
                    sbrPropiAdi("Ubi", _Ubi.ToString(), value.ToString());
                    _Ubi = value;
                }
            }
            public string NumSerie
            {
                get { return _NumSerie; }
                set
                {
                    _NumSerie = value;
                }
            }


            #endregion

            #region Constructor
            public LinAlbCompra()
            {
                aNuevo = true;
            }
            //public LinAlbCompra(int vId, int vEmpresa, string vNumAlb, int vLinea, DateTime vFechaEntrega, string vProducto,
            //                string vDescripción, string vCodProv, string vNombreProv, Decimal vCantidad,
            //                string vLote, string vRecepcionadoPor, int vGrabado, string vNumPed,string vObs)
            //{
            //    _Id = vId;
            //    _Empresa = vEmpresa;
            //    _NumAlb = vNumAlb;
            //    _Linea = vLinea;
            //    _FechaEntrega = vFechaEntrega;
            //    _Producto = vProducto;
            //    _Descripción = vDescripción;
            //    _CodProv = vCodProv;
            //    _NombreProv = vNombreProv;
            //    _Cantidad = vCantidad;
            //    _Lote = vLote;
            //    _RecepcionadoPor = vRecepcionadoPor;
            //    _Grabado = vGrabado;
            //    _NumPed = vNumPed;
            //    _Obs = vObs;

            //}

            public LinAlbCompra(SqlDataReader dr)
            {
                _Id = (int)dr["Id"];
                _Empresa = (int)dr["Empresa"];
                _NumAlb = dr["NumAlb"].ToString();
                _Linea = (int)dr["Linea"];
                _FechaEntrega = (DateTime)dr["FechaEntrega"];
                _Producto = dr["Producto"].ToString();
                _Descripción = dr["Descripción"].ToString();
                _CodProv = dr["CodProv"].ToString();
                _NombreProv = dr["NombreProv"].ToString();
                _Cantidad = (Decimal)dr["Cantidad"];
                _Lote =  dr["Lote"].ToString();
                _RecepcionadoPor = dr["RecepcionadoPor"].ToString();
                _Grabado =  (int)dr["Grabado"];
                _NumPed = dr["NUmPed"].ToString();
                _Obs = dr["Obs"].ToString();
                _Ubi = dr["Ubi"].ToString();
                _NumSerie = dr["NumSerie"].ToString();

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
            public int fncAlta()
            {
                string vValores = cUtil.fncCargaValoresSQLDefault(vTabla, "", "Id", "Empresa,NumAlb,Linea", cParamXml.Emp + "," + _NumAlb + ",");
                string vCampos = cUtil.Piece(vValores, "#", 2);
                string vValoresDef = cUtil.Piece(vValores, "#", 5);

                string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresDef;
                int vIdentity = 0;
                try
                {
                    vIdentity = SQLDataAccess.GEN_ExecuteScalarIdentity(vSql, cParamXml.strConecProduc_Prueb);
                    _Id = vIdentity;
                    _NumAlb = "0";
                    _Linea = 0;
                    _Producto = "";
                    _Descripción = "";
                    _Cantidad = 0;
                    _CodProv = "";
                    _NombreProv = "";
                    _Lote = "";
                    _RecepcionadoPor = "";
                    _Grabado = 0;
                    _NumPed = "";
                    _Obs = "";
                    _Cert = "";
                    _Ubi = "";
                    _NumSerie = "";
                }
                catch { }

                return vIdentity;
            }

            
            public bool fncAltaLin()
            {
                bool vOk = false;
                try
                {
                    string vTabla = "GC_AlbProv";
                    if (_NumSerie == "") _NumSerie = SQLDataAccess.GenTraeNumSerie("ProductoLote", true, cParamXml.strConec);

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

                    int vLin = _Linea;
                    if (vLin == 0) vLin = fncNumLinea(_NumAlb.ToString());

                    vDatos[1] = _Empresa.ToString();
                    vDatos[2] = _NumAlb.ToString();
                    vDatos[3] = vLin.ToString();
                    vDatos[4] = _FechaEntrega.ToShortDateString();
                    vDatos[5] = _Producto;
                    vDatos[6] = _Descripción;
                    vDatos[7] = _CodProv;
                    vDatos[8] = _NombreProv;
                    vDatos[9] = _Cantidad.ToString().Replace(",", ".");
                    vDatos[10] = _Lote;
                    vDatos[11] = _RecepcionadoPor;
                    vDatos[12] = _Grabado.ToString().Replace(",", ".");
                    vDatos[13] = _NumPed;
                    vDatos[14] = _Obs;
                    vDatos[15] = _Ubi;
                    vDatos[16] = _NumSerie;



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

            public static int fncNumLinea(string vNumAlb)
            {
                int vNumLin = 0;
                string vSql = cConstantes.SQL_NumLinAlbCompra;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?NumAlb]", vNumAlb);

                DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));
                if (dt.Rows.Count > 0)
                {
                    string vNL = dt.Rows[0]["NumLin"].ToString();
                    if (vNL == "") { vNL = "0"; }
                    vNumLin = Convert.ToInt16(vNL);
                }
                vNumLin++;
                return vNumLin;
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

        public static int fncBuscaIndexLinPed(BindingSource bS, string vPed)
        {
            int vReg = 0;

            if (bS.SupportsSearching)
            {
                vReg = bS.Find("NumAlb", vPed);
            }
            else
            {
                List<cAlbaranesCompra.LinAlbCompra> lista = (List<cAlbaranesCompra.LinAlbCompra>)bS.List;
                cAlbaranesCompra.LinAlbCompra result = lista.Find(
                delegate(cAlbaranesCompra.LinAlbCompra bus)
                {
                    return bus.NumAlb == vPed;
                }
                );


                if (result != null)
                {
                    vReg = bS.IndexOf(result);

                }

            }

            return vReg;
        }


        //--------------------------------------------------------------------------------------------------

        public class LoteCert : Entidad
        {

            private string _Error = "";
            private int _Id = 0;
            private int _Empresa = 1;
            private string _Producto = "";
            private string _Lote = "";
            private string _Cert = "";


            private string vCamposIndice = ",Empresa,Producto,Lote";
            private string vTabla = "[ GC_LoteCertificado]";

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
            public string Producto
            {
                get { return _Producto; }
                set
                {
                    sbrPropiAdi("Producto", _Producto.ToString(), value.ToString());
                    _Producto = value;
                }
            }
            public string Lote
            {
                get { return _Lote; }
                set
                {
                    sbrPropiAdi("Lote", _Lote.ToString(), value.ToString());
                    _Lote = value;
                }
            }
            public string Cert
            {
                get { return _Cert; }
                set
                {
                    sbrPropiAdi("Cert", _Cert.ToString(), value.ToString());
                    _Cert = value;
                }
            }


            #endregion

            #region Constructor
            public LoteCert()
            {
                aNuevo = true;
            }

            public LoteCert(SqlDataReader dr)
            {
                fncCargaClase(dr);
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
                string vValores = cUtil.fncCargaValoresSQLDefault(vTabla, "", "Id", "Empresa,Producto,Lote", cParamXml.Emp + "," + _Producto + "," + _Lote);
                string vCampos = cUtil.Piece(vValores, "#", 2);
                string vValoresDef = cUtil.Piece(vValores, "#", 5);

                string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresDef;
                int vIdentity = 0;
                try
                {
                    vIdentity = SQLDataAccess.GEN_ExecuteScalarIdentity(vSql, cParamXml.strConecProduc_Prueb);
                    _Id = vIdentity;
                    _Producto = "";
                    _Lote = "";
                    _Cert = "";
                }
                catch { }

                return vIdentity;
            }


            public bool fncAltaLin()
            {
                bool vOk = false;
                try
                {
                    string vTabla = "GC_LoteCertificado";

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
                    vDatos[2] = _Producto;
                    vDatos[3] = _Lote;
                    vDatos[4] = _Cert;


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

            public bool fncExiste(int vEmpresa, string vProd,string vLote)
            {
                bool vOk = false;
                using (SqlConnection vConnec = new SqlConnection(cParamXml.strConecProduc_Prueb))
                {
                    vConnec.Open();
                    string vSql = cConstantes.SQL_LoteCert_Busca;
                    vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                    vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                    vSql = vSql.Replace("[?Emp]", vEmpresa.ToString());
                    vSql = vSql.Replace("[?Prod]", vProd);
                    vSql = vSql.Replace("[?Lote]", vLote);

                    SqlDataReader dr = cUtil.fncTraeDataReader(vSql, vConnec);

                    if (dr.HasRows == true)
                    {
                        dr.Read();
                        fncCargaClase(dr);
                        vOk = true;
                    }

                    vConnec.Close();
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

            #region Metodos Privados
            private void fncCargaClase(SqlDataReader dr)
            {
                _Id = (int)dr["Id"];
                _Empresa = (int)dr["Empresa"];
                _Producto = dr["Producto"].ToString();
                _Lote = dr["Lote"].ToString();
                _Cert = dr["Cert"].ToString();

            }

            #endregion


        }

    }
}
