using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using jControles.Clases;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;



namespace GesInject.Clases
{
    class cAlbaranesVenta
    {

        public static int vCont = 0;
        public static List<CabAlb> Lista()
        {

            List<CabAlb> listaProy = new List<CabAlb>();

            using (SqlConnection vConnec = new SqlConnection(cParamXml.strConecProduc_Prueb))
            {
                vConnec.Open();
                string vSql = cConstantes.SQL_CabAlb;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());

                SqlDataReader dr = cUtil.fncTraeDataReader(vSql, vConnec);
                if (dr.HasRows == true) while (dr.Read()) listaProy.Add(new CabAlb((int)dr[0], (int)dr[1], (int)dr[2], dr[3].ToString(), (DateTime)dr[4], (DateTime)dr[5],
                                                                                     dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(),
                                                                                     dr[10].ToString(), dr[11].ToString(), dr[12].ToString(), dr[13].ToString(),
                                                                                     (Decimal)dr[14], (Decimal)dr[15], dr[16].ToString(), dr[17].ToString(),
                                                                                     dr[18].ToString(), dr[19].ToString(), (int)dr[20]));
                vConnec.Close();
            }

            return listaProy;
        }
        public class CabAlb : Entidad
        {
            private string _Error = "";
            private int _Id = 0;                                //0
            private int _Empresa = 1;                           //1
            private int _NumAlb = 0;                            //2
            private string _Estado = "";                        //3
            private DateTime _FechaAlbaran = DateTime.UtcNow;   //4
            private DateTime _FechaEntrega = DateTime.UtcNow;   //5
            private string _CodCli = "";                        //6
            private string _NomCli = "";                        //7
            private string _Dirección = "";                     //8
            private string _Población = "";                     //9
            private string _Provincia = "";                     //10
            private string _CP = "";                            //11
            private string _FPago = "";                         //12
            private string _Divisa = "";                        //13
            private decimal _DtoPP = 0;                         //14
            private decimal _DtoESP = 0;                        //15
            private string _Ent_Dirección = "";                 //16
            private string _Ent_Población = "";                 //17
            private string _Ent_Provincia = "";                 //18
            private string _Ent_CP = "";                        //19
            private int _Ent_ID = 0;                            //20

            private string vCamposIndice = ",Empresa,NumAlb,";
            private string vTabla = "[GC_CabAlbCli]";

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
            public int NumAlb
            {
                get { return _NumAlb; }
                set
                {
                    sbrPropiAdi("NumAlb", _NumAlb.ToString(), value.ToString());
                    _NumAlb = value;
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
            public DateTime FechaEntrega
            {
                get { return _FechaEntrega; }
                set
                {
                    sbrPropiAdi("FechaEntrega", _FechaEntrega.ToString(), value.ToString());
                    _FechaEntrega = value;
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
            public string FPago
            {
                get { return _FPago; }
                set
                {
                    sbrPropiAdi("FPago", _FPago.ToString(), value.ToString());
                    _FPago = value;
                }
            }
            public string Divisa
            {
                get { return _Divisa; }
                set
                {
                    sbrPropiAdi("Divisa", _Divisa.ToString(), value.ToString());
                    _Divisa = value;
                }
            }
            public decimal DtoPP
            {
                get { return _DtoPP; }
                set
                {
                    sbrPropiAdi("DtoPP", _DtoPP.ToString(), value.ToString());
                    _DtoPP = value;
                }
            }
            public decimal DtoESP
            {
                get { return _DtoESP; }
                set
                {
                    sbrPropiAdi("DtoESP", _DtoESP.ToString(), value.ToString());
                    _DtoESP = value;
                }
            }
            public string Ent_Dirección
            {
                get { return _Ent_Dirección; }
                set
                {
                    sbrPropiAdi("Ent_Dirección", _Ent_Dirección.ToString(), value.ToString());
                    _Ent_Dirección = value;
                }
            }
            public string Ent_Población
            {
                get { return _Ent_Población; }
                set
                {
                    sbrPropiAdi("Ent_Población", _Ent_Población.ToString(), value.ToString());
                    _Ent_Población = value;
                }
            }
            public string Ent_Provincia
            {
                get { return _Ent_Provincia; }
                set
                {
                    sbrPropiAdi("Ent_Provincia", _Ent_Provincia.ToString(), value.ToString());
                    _Ent_Provincia = value;
                }
            }
            public string Ent_CP
            {
                get { return _Ent_CP; }
                set
                {
                    sbrPropiAdi("Ent_CP", _Ent_CP.ToString(), value.ToString());
                    _Ent_CP = value;
                }
            }
            public int Ent_Id
            {
                get { return _Ent_ID; }
                set
                {
                    sbrPropiAdi("Ent_Id", _Ent_ID.ToString(), value.ToString());
                    _Ent_ID = value;
                }
            }



            #endregion

            #region Constructor
            public CabAlb()
            {
                aNuevo = true;
            }
            public CabAlb(int vId, int vEmpresa, int vNumAlb, string vEstado, DateTime vFechaAlbaran, DateTime vFechaEntrega,
                            string vCodCli, string vNomCli, string vDireccion, string vPoblacion,
                            string vProvincia, string vCP, string vFPago, string vDivisa,
                            decimal vDtoPP, decimal vDtoESP, string vEnt_Direccion, string vEnt_Poblacion,
                            string vEnt_Provincia, string vEnt_CP, int vEnt_Id)
            {
                _Id = vId;
                _Empresa = vEmpresa;
                _NumAlb = vNumAlb;
                _Estado = vEstado;
                _FechaAlbaran = vFechaAlbaran;
                _FechaEntrega = vFechaEntrega;
                _CodCli = vCodCli;
                _NomCli = vNomCli;
                _Dirección = vDireccion;
                _Población = vPoblacion;
                _Provincia = vProvincia;
                _CP = vCP;
                _FPago = vFPago;
                _Divisa = vDivisa;
                _DtoPP = vDtoPP;
                _DtoESP = vDtoESP;
                _Ent_Dirección = vEnt_Direccion;
                _Ent_Población = vEnt_Poblacion;
                _Ent_Provincia = vEnt_Provincia;
                _Ent_CP = vEnt_CP;
                _Ent_ID = vEnt_Id;


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

                string vNumSerie = SQLDataAccess.GenTraeNumSerie(cParamXml.NSerAlbCli, true, cParamXml.strConec);
                int vNumSer = Convert.ToInt32(vNumSerie);


                string vValores = cUtil.fncCargaValoresSQLDefault(vTabla, cParamXml.strConec, "Id", "NumAlb,Empresa,Estado,FechaAlbaran", vNumSer.ToString() + "," + cParamXml.Emp + ",P," + DateTime.Now.ToShortDateString());
                string vCampos = cUtil.Piece(vValores, "#", 2);
                string vValoresDef = cUtil.Piece(vValores, "#", 5);

                string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresDef;
                int vIdentity = 0;
                try
                {
                    vIdentity = SQLDataAccess.GEN_ExecuteScalarIdentity(vSql, cParamXml.strConec);
                    _Id = vIdentity;
                    //_NumPed = 0;
                    _FechaAlbaran = DateTime.Now;
                    _FechaEntrega = DateTime.Now;
                    _CodCli = "";
                    _NomCli = "";
                    _Dirección = "";
                    _Población = "";
                    _Provincia = "";
                    _CP = "";
                    _FPago = "";
                    _Divisa = "";
                    _DtoPP = 0;
                    _DtoESP = 0;
                }
                catch { }

                return vIdentity;
            }
            public bool fncAltaCab()
            {
                bool vOk = false;
                try
                {
                    string vTabla = "GC_CabAlbCli";

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
                    vDatos[2] = _NumAlb.ToString();
                    vDatos[3] = _Estado;
                    vDatos[4] = _FechaAlbaran.ToShortDateString();
                    vDatos[5] = _FechaEntrega.ToShortDateString();
                    vDatos[6] = _CodCli;
                    vDatos[7] = _NomCli;
                    vDatos[8] = _Dirección;
                    vDatos[9] = _Población;

                    vDatos[10] = _Provincia;
                    vDatos[11] = _CP;
                    vDatos[12] = _FPago;
                    vDatos[13] = _Divisa;
                    vDatos[14] = _DtoPP.ToString().Replace(",", ".");
                    vDatos[15] = _DtoESP.ToString().Replace(",", ".");
                    vDatos[16] = _Ent_Dirección;
                    vDatos[17] = _Ent_Población;
                    vDatos[18] = _Ent_Provincia;
                    vDatos[19] = _Ent_CP;
                    vDatos[20] = _Ent_ID.ToString();

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
            public bool fncAltaCab(cEntregas.CabPrepEntrega oCab,string vEstado,SqlConnection vConec,SqlTransaction vTr,ref int vNumAlb)
            {
                bool vOk = false;
                try
                {
                    string vTabla = "GC_CabAlbCli";

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

                    string vNumSerie = SQLDataAccess.GenTraeNumSerie(cParamXml.NSerAlbCli, true, cParamXml.strConec);
                    vNumAlb = Convert.ToInt32(vNumSerie);
                    
                    vDatos[1] = oCab.Empresa.ToString();
                    vDatos[2] = vNumAlb.ToString();
                    vDatos[3] = vEstado;
                    vDatos[4] = DateTime.Now.ToShortDateString();
                    vDatos[5] = DateTime.Now.ToShortDateString();
                    vDatos[6] = oCab.CodCli;
                    vDatos[7] = oCab.NomCli;
                    vDatos[8] = oCab.Dirección;
                    vDatos[9] = oCab.Población;

                    vDatos[10] = oCab.Provincia;
                    vDatos[11] = oCab.CP;
                    vDatos[12] = oCab.FPago;
                    vDatos[13] = oCab.Divisa;
                    vDatos[14] = oCab.DtoPP.ToString().Replace(",", ".");
                    vDatos[15] = oCab.DtoESP.ToString().Replace(",", ".");
                    vDatos[16] = oCab.Ent_Dirección;
                    vDatos[17] = oCab.Ent_Población;
                    vDatos[18] = oCab.Ent_Provincia;
                    vDatos[19] = oCab.Ent_CP;
                    vDatos[20] = oCab.Ent_Id.ToString();

                    string vValoresNew = cUtil.fncReplaceValoresSQL(vDatos, vValoresCab, vNumCampos);
                    string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresNew;
                    int vCor = SQLDataAccess.GEN_ExecuteNonQueryTransac(vSql,vConec,vTr);
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


            public bool fncTrae(int vAlb)
            {
                bool vOk = true;

                try
                {
                    //Traemos los datos del pedido
                    string vWhere = " Empresa = " + cParamXml.Emp + " and NumAlb = " + vAlb.ToString() + " ";
                    DataRow drp = cUtil.fncTraeCampos("GC_CabAlbCli", vWhere, cParamXml.strConecProduc_Prueb, "SQL");

                    _Id = (int)drp["Id"];
                    _Empresa = (int)drp["Empresa"];
                    _NumAlb = vAlb;
                    _Estado = drp["Estado"].ToString();
                    _FechaAlbaran = (DateTime)drp["FechaAlbaran"];
                    _FechaEntrega = (DateTime)drp["FechaEntrega"];
                    _CodCli = drp["CodCli"].ToString();
                    _NomCli = drp["NomCli"].ToString();
                    _Dirección = drp["Dirección"].ToString();
                    _Población = drp["Población"].ToString();
                    _Provincia = drp["Provincia"].ToString();
                    _CP = drp["CP"].ToString();
                    _FPago = drp["FPago"].ToString();
                    _Divisa = drp["Divisa"].ToString();
                    _DtoPP = (Decimal)drp["DtoPP"];
                    _DtoESP = (Decimal)drp["DtoEsp"];
                    _Ent_Dirección = drp["Ent_Dirección"].ToString();
                    _Ent_Población = drp["Ent_Población"].ToString();
                    _Ent_Provincia = drp["Ent_Provincia"].ToString();
                    _Ent_CP = drp["Ent_CP"].ToString();
                    _Ent_ID = (int)drp["Ent_ID"];

                }
                catch { vOk = false; }

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
        public static int fncBuscaIndexCabAlb(BindingSource bS, string vProy)
        {
            int vReg = 0;

            if (bS.SupportsSearching)
            {
                vReg = bS.Find("NumAlb", vProy);
            }
            else
            {
                List<cAlbaranesVenta.CabAlb> lista = (List<cAlbaranesVenta.CabAlb>)bS.List;

                cAlbaranesVenta.CabAlb result = lista.Find(
                delegate(cAlbaranesVenta.CabAlb bus)
                {
                    return bus.NumAlb == Convert.ToInt32(vProy);
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

        public static List<LinAlb> ListaLineas(string vPed)
        {
            List<LinAlb> listaLineas = new List<LinAlb>();

            using (SqlConnection vConnec = new SqlConnection(cParamXml.strConecProduc_Prueb))
            {
                vConnec.Open();
                string vSql = cConstantes.SQL_LinPedido;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?Ped]", vPed);

                SqlDataReader dr = cUtil.fncTraeDataReader(vSql, vConnec);
                if (dr.HasRows == true) while (dr.Read())
                        listaLineas.Add(new LinAlb((int)dr[0], (int)dr[1], (int)dr[2], (int)dr[3], dr[4].ToString(), dr[5].ToString(),
                                                    (Decimal)dr[6], dr[7].ToString(), dr[8].ToString(), (int)dr[9], (int)dr[10]));
                vConnec.Close();
            }



            return listaLineas;

        }
        public class LinAlb : Entidad
        {

            private string _Error = "";
            private int _Id = 0;                //0
            private int _Empresa = 1;           //1
            private int _NumAlb = 0;            //2
            private int _Linea = 0;             //3
            private string _Producto = "";      //4
            private string _Descripción = "";   //5
            private decimal _Cantidad = 0;      //6
            private string _Lote = "";          //7
            private string _Cajas = "";         //8
            private int _Impresiones = 0;       //9
            private int _NumPrep = 0;           //10

            private string vCamposIndice = ",Empresa,NumAlb,Linea";
            private string vTabla = "[GC_LinAlbCli]";

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
            public int NumAlb
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
            public string Cajas
            {
                get { return _Cajas; }
                set
                {
                    sbrPropiAdi("Cajas", _Cajas.ToString(), value.ToString());
                    _Cajas = value;
                }
            }
            public int Impresiones
            {
                get { return _Impresiones; }
                set
                {
                    sbrPropiAdi("Impresiones", _Impresiones.ToString(), value.ToString());
                    _Impresiones = value;
                }
            }
            public int NumPrep
            {
                get { return _NumPrep; }
                set
                {
                    sbrPropiAdi("NumPrep", _NumPrep.ToString(), value.ToString());
                    _NumPrep = value;
                }
            }

            public string ValAnt
            {
                set
                {
                    sbrPropiAdi("", value, "");
                }
            }


            #endregion

            #region Constructor
            public LinAlb()
            {
                aNuevo = true;
            }
            public LinAlb(int vId, int vEmpresa, int vNumAlb, int vLinea, string vProducto,
                            string vDescripción, Decimal vCantidad, string vLote,string vCajas,int vImpresiones,int vNumPrep)
            {
                _Id = vId;
                _Empresa = vEmpresa;
                _NumAlb = vNumAlb;
                _Linea = vLinea;
                _Producto = vProducto;
                _Descripción = vDescripción;
                _Cantidad = vCantidad;
                _Lote = vLote;
                _Cajas = vCajas;
                _Impresiones = vImpresiones;
                _NumPrep = vNumPrep;

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
            public bool fncBaja(int vID, SqlConnection vConec, SqlTransaction vTr)
            {
                bool vOk = false;
                string vSql = "";
                if (vID != 0) _Id = vID;
                string vWhere = " Id = " + _Id;
                vSql = cConstantes.SQL_UP_Delete;
                vSql = vSql.Replace("[?1]", vWhere);
                vSql = vSql.Replace("[?99]", vTabla);
                int viOk = SQLDataAccess.GEN_ExecuteNonQueryTransac(vSql, vConec, vTr);
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
                    _NumAlb = 0;
                    _Linea = 0;
                    _Producto = "";
                    _Descripción = "";
                    _Cantidad = 0;
                    _Lote = "";
                    _Cajas = "";
                    _Impresiones = 0;
                    _NumPrep = 0;
                }
                catch { }

                return vIdentity;
            }
            public bool fncAltaLin()
            {
                bool vOk = false;
                try
                {
                    string vTabla = "GC_LinAlbCli";

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

                    int vLin = fncNumLinea(_NumAlb.ToString());

                    vDatos[1] = _Empresa.ToString();
                    vDatos[2] = _NumAlb.ToString();
                    vDatos[3] = vLin.ToString();
                    vDatos[4] = _Producto;
                    vDatos[5] = _Descripción;
                    vDatos[6] = _Cantidad.ToString().Replace(",", ".");
                    vDatos[7] = "0";
                    vDatos[8] = _Lote;
                    vDatos[9] = _Cajas;
                    vDatos[10] = _Impresiones.ToString().Replace(",", ".");
                    vDatos[11] = _NumPrep.ToString().Replace(",", ".");
 

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
            public bool fncAltaLin(SqlConnection vConec,SqlTransaction vTr)
            {
                bool vOk = false;
                try
                {
                    string vTabla = "GC_LinAlbCli";

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

                    int vLin = fncNumLinea(_NumAlb.ToString());

                    vDatos[1] = _Empresa.ToString();
                    vDatos[2] = _NumAlb.ToString();
                    vDatos[3] = vLin.ToString();
                    vDatos[4] = _Producto;
                    vDatos[5] = _Descripción;
                    vDatos[6] = _Cantidad.ToString().Replace(",", ".");
                    vDatos[7] = _Lote;
                    vDatos[8] = _Cajas;
                    vDatos[9] = _Impresiones.ToString().Replace(",", ".");
                    vDatos[10] = _NumPrep.ToString().Replace(",", ".");


                    string vValoresNew = cUtil.fncReplaceValoresSQL(vDatos, vValoresCab, vNumCampos);
                    string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresNew;
                    int vCor = SQLDataAccess.GEN_ExecuteNonQueryTransac(vSql,vConec,vTr);
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
                string vSql = cConstantes.SQL_NumLinAlb;
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

            public bool fncTrae(int vAlb, int vLin)
            {
                bool vOk = true;

                try
                {
                    //Traemos los datos del pedido
                    string vWhere = " Empresa = " + cParamXml.Emp + " and NumAlb = " + vAlb.ToString() + "  and Linea = " + vLin.ToString() + " ";
                    DataRow drp = cUtil.fncTraeCampos("GC_LinAlbCli", vWhere, cParamXml.strConecProduc_Prueb, "SQL");

                    _Id = (int)drp["Id"];
                    _Empresa = (int)drp["Empresa"];
                    _NumAlb = vAlb;
                    _Linea = vLin;
                    _Producto = drp["Producto"].ToString();
                    _Descripción = drp["Descripción"].ToString();
                    _Cantidad = (Decimal)drp["Cantidad"];
                    _Lote = drp["Lote"].ToString();
                    _Cajas = drp["Cajas"].ToString();
                    _Impresiones = (int)drp["Impresiones"];
                    _NumPrep = (int)drp["NumPrep"];

                }
                catch { vOk = false; }

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
        public static int fncBuscaIndexLinAlb(BindingSource bS, string vAlb)
        {
            int vReg = 0;

            if (bS.SupportsSearching)
            {
                vReg = bS.Find("NumAlb", vAlb);
            }
            else
            {
                List<cAlbaranesVenta.LinAlb> lista = (List<cAlbaranesVenta.LinAlb>)bS.List;
                cAlbaranesVenta.LinAlb result = lista.Find(
                delegate(cAlbaranesVenta.LinAlb bus)
                {
                    return bus.NumAlb == Convert.ToInt32(vAlb);
                }
                );


                if (result != null)
                {
                    vReg = bS.IndexOf(result);

                }

            }

            return vReg;
        }


        public class LinAlbVenta2
        {

            private string _Error = "";
            private int _Id = 0;
            private int _Empresa = 1;
            private string _NumAlb = "0";
            private int _Linea = 0;
            private DateTime _FechaEntrega = DateTime.UtcNow;
            private string _Producto = "";
            private string _Descripción = "";
            private string _CodCli = "";
            private string _NombreCli = "";
            private decimal _Cantidad = 0;
            private string _Lote = "";
            private int _Grabado = 0;

            private string vCamposIndice = ",Empresa,NumAlb,Linea";
            private string vTabla = "[GC_AlbCli]";

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
                    _Id = value;
                }
            }
            public int Empresa
            {
                get { return _Empresa; }
                set
                {
                    _Empresa = value;
                }
            }
            public string NumAlb
            {
                get { return _NumAlb; }
                set { _NumAlb = value; }
            }
            public int Linea
            {
                get { return _Linea; }
                set { _Linea = value; }
            }
            public DateTime FechaEntrega
            {
                get { return _FechaEntrega; }
                set
                {
                    _FechaEntrega = value;
                }
            }
            public string Producto
            {
                get { return _Producto; }
                set
                {
                    _Producto = value;
                }
            }
            public string Descripción
            {
                get { return _Descripción; }
                set
                {
                    _Descripción = value;
                }
            }
            public string CodCli
            {
                get { return _CodCli; }
                set
                {
                    _CodCli = value;
                }
            }
            public string NombreCli
            {
                get { return _NombreCli; }
                set
                {
                    _NombreCli = value;
                }
            }
            public decimal Cantidad
            {
                get { return _Cantidad; }
                set
                {
                    _Cantidad = value;
                }
            }
            public string Lote
            {
                get { return _Lote; }
                set
                {
                    _Lote = value;
                }
            }

            public int Grabado
            {
                get { return _Grabado; }
                set
                {
                    _Grabado = value;
                }
            }


            #endregion

            #region Constructor
            public LinAlbVenta2()
            {
                //aNuevo = true;
            }
            public LinAlbVenta2(int vId, int vEmpresa, string vNumAlb, int vLinea, DateTime vFechaEntrega, string vProducto,
                            string vDescripción, string vCodCli, string vNombreCli, Decimal vCantidad,
                            string vLote, int vGrabado)
            {
                _Id = vId;
                _Empresa = vEmpresa;
                _NumAlb = vNumAlb;
                _Linea = vLinea;
                _FechaEntrega = vFechaEntrega;
                _Producto = vProducto;
                _Descripción = vDescripción;
                _CodCli = vCodCli;
                _NombreCli = vNombreCli;
                _Cantidad = vCantidad;
                _Lote = vLote;
                _Grabado = vGrabado;

            }

            #endregion

            #region Metodos

            public bool fncGrabaCampo(string vCampo, string vValor)
            {
                bool vOk = false;
                int viOk = 1;
                if ((vCamposIndice.LastIndexOf("," + vCampo + ",") == -1))
                {
                    string vSql = "";
                    string vWhere = " Id = " + _Id;
                    vSql = cConstantes.SQL_UP_Update;
                    vSql = vSql.Replace("[?1]", "[" + vCampo + "]");
                    vSql = vSql.Replace("[?2]", vValor);
                    vSql = vSql.Replace("[?3]", vWhere);
                    vSql = vSql.Replace("[?99]", vTabla);
                    viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);

                    if (viOk == 1)
                    {
                        vOk = true;
                    }
                }
                else
                {
                    vOk = false;
                }
                return vOk;
            }

            //public bool fncBaja(string vID)
            //{
            //    bool vOk = false;
            //    string vSql = "";
            //    string vWhere = " Id = " + _Id;
            //    vSql = cConstantes.SQL_UP_Delete;
            //    vSql = vSql.Replace("[?1]", vWhere);
            //    vSql = vSql.Replace("[?99]", vTabla);
            //    int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
            //    if (viOk == 1)
            //    {
            //        vOk = true;
            //        aCampoModif = "";
            //        aValor = "";
            //        aValorAnt = "";
            //    }


            //    return vOk;
            //}
            //public int fncAlta()
            //{
            //    string vValores = cUtil.fncCargaValoresSQLDefault(vTabla, "", "Id", "Empresa,NumPed,LinPed", cParamXml.Emp + "," + _NumPed + ",");
            //    string vCampos = cUtil.Piece(vValores, "#", 2);
            //    string vValoresDef = cUtil.Piece(vValores, "#", 5);

            //    string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresDef;
            //    int vIdentity = 0;
            //    try
            //    {
            //        vIdentity = SQLDataAccess.GEN_ExecuteScalarIdentity(vSql, cParamXml.strConecProduc_Prueb);
            //        _Id = vIdentity;
            //        _NumPed = "0";
            //        _LinPed = 0;
            //        _Producto = "";
            //        _Descripción = "";
            //        _Cantidad = 0;
            //        _CantidadEntregada = 0;
            //        _IVA = 0;
            //        _Precio = 0;
            //        _DTO = 0;
            //    }
            //    catch { }

            //    return vIdentity;
            //}
            public bool fncAltaLin()
            {
                bool vOk = false;
                try
                {
                    string vTabla = "GC_AlbCli";

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
                    vDatos[7] = _CodCli;
                    vDatos[8] = _NombreCli;
                    vDatos[9] = _Cantidad.ToString().Replace(",", ".");
                    vDatos[10] = _Lote;
                    vDatos[11] = _Grabado.ToString().Replace(",", ".");


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
                string vSql = cConstantes.SQL_NumLinAlbVenta;
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


            //private void sbrPropiAdi(string vCampo, string vValorAnt, string vValor)
            //{
            //    //RaisePropertyChanged(vCampo);
            //    IsDirty = true;
            //    aCampoModif = vCampo;
            //    aValorAnt = vValorAnt;
            //    aValor = vValor;
            //}


            //private void sbrRollback()
            //{
            //    PropertyInfo vProp = GetType().GetProperty(aCampoModif);
            //    if (vProp != null)
            //    {
            //        if (vProp.PropertyType != typeof(string))
            //        {
            //            if (vProp.PropertyType == typeof(Boolean)) { vProp.SetValue(this, Convert.ToBoolean(aValorAnt), null); }
            //            if (vProp.PropertyType == typeof(DateTime)) { vProp.SetValue(this, Convert.ToDateTime(aValorAnt), null); }
            //            if (vProp.PropertyType == typeof(Decimal)) { vProp.SetValue(this, Convert.ToDecimal(aValorAnt), null); }
            //            if (vProp.PropertyType == typeof(Double)) { vProp.SetValue(this, Convert.ToDouble(aValorAnt), null); }
            //            if (vProp.PropertyType == typeof(Int16)) { vProp.SetValue(this, Convert.ToInt16(aValorAnt), null); }
            //            if (vProp.PropertyType == typeof(Int32)) { vProp.SetValue(this, Convert.ToInt32(aValorAnt), null); }
            //            if (vProp.PropertyType == typeof(Int64)) { vProp.SetValue(this, Convert.ToInt64(aValorAnt), null); }
            //            if (vProp.PropertyType == typeof(Byte)) { vProp.SetValue(this, Convert.ToByte(aValorAnt), null); }
            //        }
            //        else
            //        {
            //            vProp.SetValue(this, aValorAnt, null);
            //        }
            //    }

            //}

            #endregion

        }


    }
}
