using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using jControles.Clases;

namespace GesInject.Clases
{
    class cEntregas
    {
        public static int vCont = 0;
        public static List<CabPrepEntrega> Lista()
        {

            List<CabPrepEntrega> listaProy = new List<CabPrepEntrega>();

            using (SqlConnection vConnec = new SqlConnection(cParamXml.strConecProduc_Prueb))
            {
                vConnec.Open();
                string vSql = cConstantes.SQL_CabPrepEntrega;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());

                SqlDataReader dr = cUtil.fncTraeDataReader(vSql, vConnec);
                if (dr.HasRows == true) while (dr.Read()) listaProy.Add(new CabPrepEntrega((int)dr[0], (int)dr[1], (int)dr[2], dr[3].ToString(), (DateTime)dr[4], (DateTime)dr[5],
                                                                                     dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(),
                                                                                     dr[10].ToString(), dr[11].ToString(), dr[12].ToString(), dr[13].ToString(),
                                                                                     dr[14].ToString(), (Decimal)dr[15], (Decimal)dr[16], dr[17].ToString(), dr[18].ToString(),
                                                                                     dr[19].ToString(), dr[20].ToString(), (int)dr[21]));
                vConnec.Close();
            }

            return listaProy;
        }
        public class CabPrepEntrega : Entidad
        {
            private string _Error = "";
            private int _Id = 0;
            private int _Empresa = 1;
            private int _NumPrep = 0;
            private string _Estado = "";
            private DateTime _FechaPrep = DateTime.UtcNow;
            private DateTime _FechaEntrega = DateTime.UtcNow;
            private string _CodCli = "";
            private string _NomCli = "";
            private string _Dirección = "";
            private string _Población = "";
            private string _Provincia = "";
            private string _CP = "";
            private string _FPago = "";
            private string _Divisa = "";
            private string _SuPedido = "";
            private decimal _DtoPP = 0;
            private decimal _DtoESP = 0;
            private string _Ent_Dirección = "";
            private string _Ent_Población = "";
            private string _Ent_Provincia = "";
            private string _Ent_CP = "";
            private int _Ent_ID = 0;

            private string vCamposIndice = ",Empresa,NumPrep,";
            private string vTabla = "[GC_CabPrepEntregas]";

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
            public int NumPrep
            {
                get { return _NumPrep; }
                set
                {
                    sbrPropiAdi("NumPrep", _NumPrep.ToString(), value.ToString());
                    _NumPrep = value;
                }
            }
            public DateTime FechaPrep
            {
                get { return _FechaPrep; }
                set
                {
                    sbrPropiAdi("FechaPrep", _FechaPrep.ToString(), value.ToString());
                    _FechaPrep = value;
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
            public string SuPedido
            {
                get { return _SuPedido; }
                set
                {
                    sbrPropiAdi("SuPedido", _SuPedido.ToString(), value.ToString());
                    _SuPedido = value;
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
            public CabPrepEntrega()
            {
                aNuevo = true;
            }
            public CabPrepEntrega(int vId, int vEmpresa, int vNumPrep, string vEstado, DateTime vFechaPrep, DateTime vFechaEntrega,
                            string vCodCli, string vNomCli, string vDireccion, string vPoblacion,
                            string vProvincia, string vCP, string vFPago, string vDivisa, string vSuPedido,
                            decimal vDtoPP, decimal vDtoESP, string vEnt_Direccion, string vEnt_Poblacion,
                            string vEnt_Provincia, string vEnt_CP, int vEnt_Id)
            {
                _Id = vId;
                _Empresa = vEmpresa;
                _NumPrep = vNumPrep;
                _Estado = vEstado;
                _FechaPrep = vFechaPrep;
                _FechaEntrega = vFechaEntrega;
                _CodCli = vCodCli;
                _NomCli = vNomCli;
                _Dirección = vDireccion;
                _Población = vPoblacion;
                _Provincia = vProvincia;
                _CP = vCP;
                _FPago = vFPago;
                _Divisa = vDivisa;
                _SuPedido = vSuPedido;
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

                //int vNumSer = cUtil.fncTraeNumSerIntDbf("claves", "NPEDCLI", true, cParamXml.strOleDBConecDbf);
                string vNumSerie = SQLDataAccess.GenTraeNumSerie(cParamXml.NSerPrep, true, cParamXml.strConec);
                int vNumSer = Convert.ToInt32(vNumSerie);


                string vValores = cUtil.fncCargaValoresSQLDefault(vTabla, cParamXml.strConec, "Id,Estado", "NumPrep,Empresa,FechaPrep", vNumSer.ToString() + "," + cParamXml.Emp + "," + DateTime.Now.ToShortDateString());
                string vCampos = cUtil.Piece(vValores, "#", 2);
                string vValoresDef = cUtil.Piece(vValores, "#", 5);

                string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresDef;
                int vIdentity = 0;
                try
                {
                    vIdentity = SQLDataAccess.GEN_ExecuteScalarIdentity(vSql, cParamXml.strConec);
                    _Id = vIdentity;
                    _Estado = "P";
                    //_NumPed = 0;
                    _FechaPrep = DateTime.Now;
                    _FechaEntrega = DateTime.Now;
                    _CodCli = "";
                    _NomCli = "";
                    _Dirección = "";
                    _Población = "";
                    _Provincia = "";
                    _CP = "";
                    _FPago = "";
                    _Divisa = "";
                    _SuPedido = "";
                    _DtoPP = 0;
                    _DtoESP = 0;
                }
                catch { }

                return vIdentity;
            }

            public bool fncAltaCab(ref int vPrep)
            {
                bool vOk = false;
                try
                {
                    string vTabla = "GC_CabPrepEntregas";

                    string vNumSerie = SQLDataAccess.GenTraeNumSerie(cParamXml.NSerPrep, true, cParamXml.strConec);
                    int vNumSer = Convert.ToInt32(vNumSerie);
                    vPrep = vNumSer;

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
                    vDatos[2] =  vNumSer.ToString();
                    vDatos[3] = _Estado;
                    vDatos[4] = _FechaPrep.ToShortDateString();
                    vDatos[5] = _FechaEntrega.ToShortDateString();
                    vDatos[6] = _CodCli;
                    vDatos[7] = _NomCli;
                    vDatos[8] = _Dirección;
                    vDatos[9] = _Población;
                    vDatos[10] = _Provincia;
                    vDatos[11] = _CP;
                    vDatos[12] = _FPago;
                    vDatos[13] = _Divisa;
                    vDatos[14] = _SuPedido;
                    vDatos[15] = _DtoPP.ToString().Replace(",", ".");
                    vDatos[16] = _DtoESP.ToString().Replace(",", ".");
                    vDatos[17] = _Ent_Dirección;
                    vDatos[18] = _Ent_Población;
                    vDatos[19] = _Ent_Provincia;
                    vDatos[20] = _Ent_CP;
                    vDatos[21] = _Ent_ID.ToString();


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

            public bool fncTrae(int vPrep)
            {
                bool vOk = true;

                try
                {
                    //Traemos los datos del pedido
                    string vWhere = " Empresa = " + cParamXml.Emp + " and NumPrep = " + vPrep.ToString() + " ";
                    DataRow drp = cUtil.fncTraeCampos("GC_CabPrepEntregas", vWhere, cParamXml.strConecProduc_Prueb, "SQL");

                    _Id = (int)drp["Id"];
                    _Empresa = (int)drp["Empresa"];
                    _NumPrep = vPrep;
                    _Estado = drp["Estado"].ToString();
                    _FechaPrep = (DateTime)drp["FechaPrep"];
                    _FechaEntrega = (DateTime)drp["FechaEntrega"];
                    _CodCli = drp["CodCli"].ToString();
                    _NomCli = drp["NomCli"].ToString();
                    _Dirección = drp["Dirección"].ToString();
                    _Población = drp["Población"].ToString();
                    _Provincia = drp["Provincia"].ToString();
                    _CP = drp["CP"].ToString();
                    _FPago = drp["FPago"].ToString();
                    _Divisa = drp["Divisa"].ToString();
                    _SuPedido = drp["SuPedido"].ToString();
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
        public static int fncBuscaIndexCabPrep(BindingSource bS, string vProy)
        {
            int vReg = 0;

            if (bS.SupportsSearching)
            {
                vReg = bS.Find("NumPrep", vProy);
            }
            else
            {
                List<cEntregas.CabPrepEntrega> lista = (List<cEntregas.CabPrepEntrega>)bS.List;

                cEntregas.CabPrepEntrega result = lista.Find(
                delegate(cEntregas.CabPrepEntrega bus)
                {
                    return bus.NumPrep == Convert.ToInt32(vProy);
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



        public static List<LinPrepEntregas> ListaLineas(string vPrep)
        {
            List<LinPrepEntregas> listaLineas = new List<LinPrepEntregas>();

            using (SqlConnection vConnec = new SqlConnection(cParamXml.strConecProduc_Prueb))
            {
                vConnec.Open();
                string vSql = cConstantes.SQL_LinPrep;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?Prep]", vPrep);

                SqlDataReader dr = cUtil.fncTraeDataReader(vSql, vConnec);
                if (dr.HasRows == true) while (dr.Read())
                        listaLineas.Add(new LinPrepEntregas((int)dr["Id"], (int)dr["Empresa"], (int)dr["NumPrep"], (int)dr["LinPrep"], dr["Producto"].ToString(), dr["DEscripción"].ToString(),
                                                    (Decimal)dr["Cantidad"], dr["Lote"].ToString(), (Decimal)dr["CantidadServida"], (Decimal)dr["CanPen"], (DateTime)dr["FechaEntrega"],
                                                    dr["PedLocal"].ToString(), (int)dr["LinPedLocal"],dr["PedCliente"].ToString()));
                vConnec.Close();
            }



            return listaLineas;

        }
        public class LinPrepEntregas : Entidad
        {

            private string _Error = "";
            private int _Id = 0;
            private int _Empresa = 1;
            private int _NumPrep = 0;
            private int _LinPrep = 0;
            private string _Producto = "";
            private string _Descripción = "";
            private decimal _Cantidad = 0;
            private string _Lote = "";
            private decimal _CantidadServida = 0;
            private decimal _CanPen = 0;
            private DateTime _FechaEntrega = DateTime.UtcNow;
            private string _PedLocal = "";
            private int _LinPedLocal = 0;
            private string _PedCliente = "";

            private string vCamposIndice = ",Empresa,NumPrep,LinPrep";
            private string vTabla = "[GC_LinPrepEntregas]";

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
            public int NumPrep
            {
                get { return _NumPrep; }
                set
                {
                    sbrPropiAdi("NumPrep", _NumPrep.ToString(), value.ToString());
                    _NumPrep = value;
                }
            }
            public int LinPrep
            {
                get { return _LinPrep; }
                set
                {
                    sbrPropiAdi("LinPrep", _LinPrep.ToString(), value.ToString());
                    _LinPrep = value;
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
            public decimal CantidadServida
            {
                get { return _CantidadServida; }
                set
                {
                    sbrPropiAdi("CantidadServida", _CantidadServida.ToString(), value.ToString());
                    _CantidadServida = value;
                }
            }
            public decimal CanPen
            {
                get { return _CanPen; }
                set
                {
                    sbrPropiAdi("CanPen", _CanPen.ToString(), value.ToString());
                    _CanPen = value;
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
            public string PedLocal
            {
                get { return _PedLocal; }
                set
                {
                    sbrPropiAdi("PedLocal", _PedLocal.ToString(), value.ToString());
                    _PedLocal = value;
                }
            }
            public int LinPedLocal
            {
                get { return _LinPedLocal; }
                set
                {
                    sbrPropiAdi("LinPedLocal", _LinPedLocal.ToString(), value.ToString());
                    _LinPedLocal = value;
                }
            }
            public string PedCliente
            {
                get { return _PedCliente; }
                set
                {
                    sbrPropiAdi("PedCliente", _PedCliente.ToString(), value.ToString());
                    _PedCliente = value;
                }
            }

            #endregion

            #region Constructor
            public LinPrepEntregas()
            {
                aNuevo = true;
            }
            public LinPrepEntregas(int vId, int vEmpresa, int vNumPrep, int vLinprep, string vProducto,
                            string vDescripción, Decimal vCantidad, string vLote, Decimal vCantidadServida,
                            decimal vCanPen, DateTime vFechaEntrega, string vPedLocal,int vLinPedLocal,string vPedCliente) 
            {
                _Id = vId;
                _Empresa = vEmpresa;
                _NumPrep = vNumPrep;
                _LinPrep = vLinprep;
                _Producto = vProducto;
                _Descripción = vDescripción;
                _Cantidad = vCantidad;
                _Lote = vLote;
                _CantidadServida = vCantidadServida;
                _CanPen = vCantidad - vCantidadServida;
                _FechaEntrega = vFechaEntrega;
                _PedLocal = vPedLocal;
                _LinPedLocal = vLinPedLocal;
                _PedCliente = vPedCliente;

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
                string vValores = cUtil.fncCargaValoresSQLDefault(vTabla, "", "Id", "Empresa,NumPrep,LinPrep", cParamXml.Emp + "," + _NumPrep + ",");
                string vCampos = cUtil.Piece(vValores, "#", 2);
                string vValoresDef = cUtil.Piece(vValores, "#", 5);

                string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresDef;
                int vIdentity = 0;
                try
                {
                    vIdentity = SQLDataAccess.GEN_ExecuteScalarIdentity(vSql, cParamXml.strConecProduc_Prueb);
                    _Id = vIdentity;
                    _NumPrep = 0;
                    _LinPrep = 0;
                    _Producto = "";
                    _Descripción = "";
                    _Cantidad = 0;
                    _Lote = "";
                    _CantidadServida = 0;
                    _CanPen = 0;
                    _FechaEntrega = DateTime.Now;
                    _PedLocal = "";
                    _LinPedLocal = 0;
                    _PedCliente = "";
                }
                catch { }

                return vIdentity;
            }
            public bool fncAltaLin()
            {
                bool vOk = false;
                try
                {
                    string vTabla = "GC_LinPrepEntregas";

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

                    int vLin = fncNumLinea(_NumPrep.ToString());

                    vDatos[1] = _Empresa.ToString();
                    vDatos[2] = _NumPrep.ToString();
                    vDatos[3] = vLin.ToString();
                    vDatos[4] = _Producto;
                    vDatos[5] = _Descripción;
                    vDatos[6] = _Cantidad.ToString().Replace(",", ".");
                    vDatos[7] = _Lote;
                    vDatos[8] = "0";
                    vDatos[9] = _Cantidad.ToString().Replace(",", ".");
                    vDatos[10] = _FechaEntrega.ToShortDateString();
                    vDatos[11] = _PedLocal;
                    vDatos[12] = _LinPedLocal.ToString();
                    vDatos[13] = _PedCliente;

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

            public bool fncCantidadPendiente()
            {
                bool vOk = false;

                string vSql = cConstantes.SQL_Entrega_Update_CanPendiente;
                vSql = vSql.Replace("[?id]", _Id.ToString());

                int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);

                if (viOk == 1) vOk = true;

                return vOk;
            }


            public static int fncNumLinea(string vNumPrep)
            {
                int vNumLin = 0;
                string vSql = cConstantes.SQL_NumLinPrep;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?NumPrep]", vNumPrep);

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

            public static bool fncCantidadServida(string vEmpresa, int vEnt, int vLin, string vCan,SqlConnection vConec,SqlTransaction vTr)
            {
                bool vOk = false;

                string vSql = cConstantes.SQL_Entrega_Update_CanServida;
                vSql = vSql.Replace("[?2]", vCan);
                vSql = vSql.Replace("[?3]", " Empresa = " + vEmpresa + " and NumPrep =" + vEnt + " and LinPrep =" + vLin + " ");

                int viOk = SQLDataAccess.GEN_ExecuteNonQueryTransac(vSql,vConec,vTr );

                if (viOk == 1) vOk = true;

                return vOk;
            }
            public static bool fncMasCantidadServida(string vEmpresa, int vEnt, int vLin, string vCan, SqlConnection vConec, SqlTransaction vTr)
            {
                bool vOk = false;

                string vSql = cConstantes.SQL_Entrega_Update_MasCanServida;
                vSql = vSql.Replace("[?2]", vCan);
                vSql = vSql.Replace("[?3]", " Empresa = " + vEmpresa + " and NumPrep =" + vEnt + " and LinPrep =" + vLin + " ");

                int viOk = SQLDataAccess.GEN_ExecuteNonQueryTransac(vSql, vConec, vTr);

                if (viOk == 1) vOk = true;

                return vOk;
            }

            public static bool fncMenosCantidadServida(string vEmpresa, int vEnt, int vLin, string vCan, SqlConnection vConec, SqlTransaction vTr)
            {
                bool vOk = false;

                string vSql = cConstantes.SQL_Entrega_Update_MenosCanServida;
                vSql = vSql.Replace("[?2]", vCan.Replace(",","."));
                vSql = vSql.Replace("[?3]", " Empresa = " + vEmpresa + " and NumPrep =" + vEnt + " and LinPrep =" + vLin + " ");

                int viOk = SQLDataAccess.GEN_ExecuteNonQueryTransac(vSql, vConec, vTr);

                if (viOk == 1) vOk = true;

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
        public static int fncBuscaIndexLinPrep(BindingSource bS, string vPrep)
        {
            int vReg = 0;

            if (bS.SupportsSearching)
            {
                vReg = bS.Find("NumPrep", vPrep);
            }
            else
            {
                List<cEntregas.LinPrepEntregas> lista = (List<cEntregas.LinPrepEntregas>)bS.List;
                cEntregas.LinPrepEntregas result = lista.Find(
                delegate(cEntregas.LinPrepEntregas bus)
                {
                    return bus.NumPrep == Convert.ToInt32(vPrep);
                }
                );


                if (result != null)
                {
                    vReg = bS.IndexOf(result);

                }

            }

            return vReg;
        }
        public static decimal fncEnPrep(string vPed,int vLin)
        {
            decimal vEnPrep = 0;

            using (SqlConnection cnn = new SqlConnection( cParamXml.strConecProduc_Prueb))
            {

                cnn.Open();
                SqlCommand cmd = new SqlCommand("GC_Entregas_EnPrep", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SQLDataAccess.AddParamToSQLCmd(cmd, "@Pedido", SqlDbType.VarChar, 20, ParameterDirection.Input, vPed);
                SQLDataAccess.AddParamToSQLCmd(cmd, "@Lin", SqlDbType.Int, 0, ParameterDirection.Input, vLin);
                SQLDataAccess.AddParamToSQLCmd(cmd, "@Res", SqlDbType.Decimal, 0, ParameterDirection.Output, null);

                
                cmd.ExecuteScalar();

                string vsEn = cmd.Parameters["@Res"].Value.ToString();
                vEnPrep = Convert.ToDecimal(vsEn);
                cnn.Close();
            }

            return vEnPrep;

        }
        public static string fncNumEnPrep(string vPed, int vLin)
        {
            string vEnPrep = "";

            using (SqlConnection cnn = new SqlConnection(cParamXml.strConecProduc_Prueb))
            {

                cnn.Open();
                SqlCommand cmd = new SqlCommand("GC_Entregas_NumEnPrep", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SQLDataAccess.AddParamToSQLCmd(cmd, "@Pedido", SqlDbType.VarChar, 20, ParameterDirection.Input, vPed);
                SQLDataAccess.AddParamToSQLCmd(cmd, "@Lin", SqlDbType.Int, 0, ParameterDirection.Input, vLin);
                SQLDataAccess.AddParamToSQLCmd(cmd, "@Res", SqlDbType.VarChar, 20, ParameterDirection.Output, null);


                cmd.ExecuteScalar();

                vEnPrep = cmd.Parameters["@Res"].Value.ToString();
                cnn.Close();
            }

            return vEnPrep;

        }


        //private static void AddParamToSQLCmd(SqlCommand sqlCmd,
        //                      string paramId,
        //                      SqlDbType sqlType,
        //                      int paramSize,
        //                      ParameterDirection paramDirection,
        //                      object paramvalue)
        //{

        //    if (sqlCmd == null)
        //        throw (new ArgumentNullException("sqlCmd"));
        //    if (paramId == string.Empty)
        //        throw (new ArgumentOutOfRangeException("paramId"));

        //    SqlParameter newSqlParam = new SqlParameter();

        //    newSqlParam.ParameterName = paramId;
        //    newSqlParam.SqlDbType = sqlType;
        //    newSqlParam.Direction = paramDirection;

        //    if (paramSize > 0)
        //        newSqlParam.Size = paramSize;

        //    if (paramvalue != null)
        //        newSqlParam.Value = paramvalue;

        //    sqlCmd.Parameters.Add(newSqlParam);

        //}



    }
}
