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
    class cProduc
    {
        public static List<OF> Lista()
        {

            List<OF> listaOF = new List<OF>();

            using (SqlConnection vConnec = new SqlConnection(cParamXml.strConecProduc_Prueb))
            {
                vConnec.Open();
                string vSql = cConstantes.SQL_OF;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());

                SqlDataReader dr = cUtil.fncTraeDataReader(vSql, vConnec);
                if (dr.HasRows == true) while (dr.Read()) 
                    listaOF.Add(new OF((int)dr["Id"], (int)dr["Empresa"],dr["IdOF"].ToString(),
                                        (DateTime)dr["Fecha"],dr["Estado"].ToString(),dr["CodCli"].ToString(),dr["Articulo"].ToString(),
                                        dr["Descripción"].ToString(),dr["ArticuloCli"].ToString(),(decimal)dr["Cantidad"],
                                        dr["Lote"].ToString(),(DateTime)dr["FechaEntrega"],(DateTime)dr["FechaInicio"],
                                        (DateTime)dr["FechaFin"],(decimal)dr["CantidadFab"]));
                vConnec.Close();
            }

            return listaOF;
        }
        public static int fncBuscaIndexOF(BindingSource bS, string vOF)
        {
            int vReg = 0;

            if (bS.SupportsSearching)
            {
                vReg = bS.Find("IdOF", vOF);
            }
            else
            {
                List<OF> lista = (List<OF>)bS.List;

                OF result = lista.Find(
                delegate(OF bus)
                {
                    return bus.IdOF == vOF;
                }
                );


                if (result != null)
                {
                    vReg = bS.IndexOf(result);

                }

            }

            return vReg;
        }

        public class OF:Entidad
        {
            private int _Id = 0;
            private int _Empresa = 1;
            private string _IdOF = "";
            private DateTime _Fecha = DateTime.UtcNow;
            private string _Estado = "Planificada";
            private string _CodCli = "";
            private string _Articulo = "";
            private string _Descripción = "";
            private string _ArticuloCli = "";
            private Decimal _Cantidad = 0;
            private string _Lote = "";
            private DateTime _FechaEntrega = DateTime.UtcNow;
            private DateTime _FechaInicio = DateTime.UtcNow;
            private DateTime _FechaFin = DateTime.UtcNow;
            private Decimal _CantidadFab = 0;



            private string vCamposIndice = ",Empresa,IdOF,";
            private string vTabla = "[GC_OrdenProd]";

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
            public string IdOF
            {
                get { return _IdOF; }
                set
                {
                    sbrPropiAdi("IdOF", _IdOF.ToString(), value.ToString());
                    _IdOF = value;
                }
            }
            public DateTime Fecha
            {
                get { return _Fecha; }
                set
                {
                    sbrPropiAdi("Fecha", _Fecha.ToString(), value.ToString());
                    _Fecha = value;
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
            public string Articulo
            {
                get { return _Articulo; }
                set
                {
                    sbrPropiAdi("Articulo", _Articulo.ToString(), value.ToString());
                    _Articulo = value;
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
            public string ArticuloCli
            {
                get { return _ArticuloCli; }
                set
                {
                    sbrPropiAdi("ArticuloCli", _ArticuloCli.ToString(), value.ToString());
                    _ArticuloCli = value;
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
            public DateTime FechaEntrega
            {
                get { return _FechaEntrega; }
                set
                {
                    sbrPropiAdi("FechaEntrega", _FechaEntrega.ToString(), value.ToString());
                    _FechaEntrega = value;
                }
            }
            public DateTime FechaInicio
            {
                get { return _FechaInicio; }
                set
                {
                    sbrPropiAdi("FechaInicio", _FechaInicio.ToString(), value.ToString());
                    _FechaInicio = value;
                }
            }
            public DateTime FechaFin
            {
                get { return _FechaFin; }
                set
                {
                    sbrPropiAdi("FechaFin", _FechaFin.ToString(), value.ToString());
                    _FechaFin = value;
                }
            }
            public decimal CantidadFab
            {
                get { return _CantidadFab; }
                set
                {
                    sbrPropiAdi("CantidadFab", _CantidadFab.ToString(), value.ToString());
                    _CantidadFab = value;
                }
            }


            #endregion

            #region Constructor
            public OF()
            {
                aNuevo = true;
            }
            public OF(int vId, int vEmpresa,string vIdOF,DateTime vFecha,string vEstado,string vCodCli,
                      string vArticulo,string vDescripción,string vArticulocli,decimal vCantidad,
                      string vLote,DateTime vFechaEntrega,DateTime vFechaInicio,DateTime vFechaFin,
                      decimal vCantidadFab)
            {
                _Id = vId;
                _Empresa = vEmpresa;
                _IdOF = vIdOF;
                _Fecha = vFecha;
                _Estado = vEstado;
                _CodCli = vCodCli;
                _Articulo = vArticulo;
                _Descripción = vDescripción;
                _ArticuloCli = vArticulocli;
                _Cantidad = vCantidad;
                _Lote = vLote;
                _FechaEntrega = vFechaEntrega;
                _FechaInicio = vFechaInicio;
                _FechaFin = vFechaFin;
                _CantidadFab = vCantidadFab;

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
                        MessageBox.Show(SQLDataAccess.Error);
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
                string vNumSerie = SQLDataAccess.GenTraeNumSerie(cParamXml.NSerOrdProd, true, cParamXml.strConec);

                return fncAlta(vNumSerie);

            }
            public int fncAlta(string vNumSerie)
            {

                string vValores = cUtil.fncCargaValoresSQLDefault(vTabla, cParamXml.strConec, "Id,CantidadFab", "IdOF,Empresa,Estado,Fecha,FechaEntrega",
                                                                vNumSerie + "," + cParamXml.Emp + ",Planificada," + DateTime.Now.ToShortDateString() + "," + DateTime.Now.ToShortDateString());
                string vCampos = cUtil.Piece(vValores, "#", 2);
                string vValoresDef = cUtil.Piece(vValores, "#", 5);

                string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresDef;
                int vIdentity = 0;
                try
                {
                    vIdentity = SQLDataAccess.GEN_ExecuteScalarIdentity(vSql, cParamXml.strConec);
                    _Id = vIdentity;
                }
                catch { }

                return vIdentity;
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


            public static bool fncLanzaOF(int vEmp, string vOFL,string vCompo,
                                          decimal vCanPor,decimal vCanProd,
                                          decimal vCanPen,string vAlm)
            {
                bool vOk = false;
                try
                {
                    string vTabla = "GC_OrdenProdCompo";

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


                    vDatos[1] = vEmp.ToString();
                    vDatos[2] = "Lanzada";
                    vDatos[3] = vOFL;
                    vDatos[4] = vCompo;
                    vDatos[5] = vCanPor.ToString().Replace(",",".");
                    vDatos[6] = vCanProd.ToString().Replace(",", "."); ;
                    vDatos[7] = vCanPen.ToString().Replace(",", "."); ;
                    vDatos[8] = vAlm;


                    string vValoresNew = cUtil.fncReplaceValoresSQL(vDatos, vValoresCab, vNumCampos);
                    string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresNew;
                    int vCor = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                    if (vCor == 1)
                    {                        
                        vOk = fncCambiarEstado(vEmp.ToString(), vOFL,"Lanzada");
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                    vOk = false;
                }

                return vOk;
            }
            public static bool fncCambiarEstado(string vEmpresa ,string vOFL,string vEstado)
            {
                bool vOk = false;
                
                string vSql = cConstantes.SQL_UP_Update;
                vSql = vSql.Replace("[?1]", "[" + "Estado" + "]");
                vSql = vSql.Replace("[?2]", vEstado);
                vSql = vSql.Replace("[?3]", " Empresa = " + vEmpresa + " and IdOF ='" + vOFL + "' ");
                vSql = vSql.Replace("[?99]", "GC_OrdenProd");
                int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);

                if (viOk == 1) vOk = true;

                return vOk;
            }
            public static bool fncAltaEnprod(int vEmp, string vOFL,string vFechaIni,
                                           string vOper,string vNombre,string vMaq,string vDesMaq,string vLote)
            {
                bool vOk = false;
                try
                {
                    string vTabla = "GC_EnProducción";

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


                    vDatos[1] = vEmp.ToString();
                    vDatos[2] = vOFL;
                    vDatos[3] = vFechaIni;
                    vDatos[4] = vOper;
                    vDatos[5] = vNombre;
                    vDatos[6] = vMaq;
                    vDatos[7] = vDesMaq;
                    vDatos[8] = vLote;


                    string vValoresNew = cUtil.fncReplaceValoresSQL(vDatos, vValoresCab, vNumCampos);
                    string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresNew;
                    int vCor = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                    if (vCor == 1)
                    {
                        vOk = true;
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                    vOk = false;
                }





                return vOk;

            }
            public static bool fncBajaEnprod(int vEmp, string vOFL)
            {
                bool vOk = false;

                string vSql = cConstantes.SQL_UP_Delete;
                vSql = vSql.Replace("[?1]", " Empresa = " + vEmp + " and IdOF ='" + vOFL + "' ");
                vSql = vSql.Replace("[?99]", "GC_EnProducción");
                int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);

                if (viOk == 1) vOk = true;

                return vOk;

            }
            public static string fncTraeLotes(string vEmp,string vOFL)
            {
                string vLotes = "";

                string vSql = cConstantes.SQL_OFL_Cajas_Lista;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", vEmp);
                vSql = vSql.Replace("[?OFL]", vOFL);
                DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));
            
                foreach (DataRow dr in dt.Rows)
                {
                    string vLote = dr["Lote"].ToString();

                    string[] vmLote = vLote.Split(',');

                    for (int i = 0; i < vmLote.Length; i++)
                    {
                        vLote = vmLote[i];
                        if (vLotes.LastIndexOf(vLote) == -1)
                        {
                            vLotes += vLote + ",";
                        }
                    }
                }

                //if (vLotes != "")
                //{
                //    vLotes = vLotes.Substring(0, vLotes.Length - 1);
                //}

                return vLotes;
            }
            public static int fncTraeNumCaja(string vEmp, string vOFL)
            {
                int vNumCaja = 0;

                string vSql = cConstantes.SQL_OFL_Cajas_Lista;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", vEmp);
                vSql = vSql.Replace("[?OFL]", vOFL);
                DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

                foreach (DataRow dr in dt.Rows)
                {
                    int vNCaja = Convert.ToInt16(dr["NUmCajaBolsa"].ToString());
                    string vTipo = dr["Tipo"].ToString();
                    if ((vTipo.Trim() == "C") & (vNCaja > vNumCaja)) vNumCaja = vNCaja;
                }


                return vNumCaja+1;
            }
            public static int fncTraeNumBolsa(string vEmp, string vOFL,string vCaja)
            {
                int vNumBolsa = 0;

                string vSql = cConstantes.SQL_OFL_Bolsas_Lista;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", vEmp);
                vSql = vSql.Replace("[?OFL]", vOFL);
                vSql = vSql.Replace("[?Caja]", vCaja);
                DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

                foreach (DataRow dr in dt.Rows)
                {
                    int vNBolsa = Convert.ToInt16(dr["NUmCajaBolsa"].ToString());
                    string vTipo = dr["Tipo"].ToString();
                    if ((vTipo.Trim() == "B") & (vNBolsa > vNumBolsa)) vNumBolsa = vNBolsa;
                }


                return vNumBolsa+1;
            }
            public static int fncTraeCanProd(string vEmp, string vOFL)
            {
                int vCanTot = 0;

                string vSql = cConstantes.SQL_OFL_Cajas_Lista;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", vEmp);
                vSql = vSql.Replace("[?OFL]", vOFL);
                DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

                foreach (DataRow dr in dt.Rows)
                {
                    int vCanProd = Convert.ToInt32(dr["CantidadProd"].ToString());
                    vCanTot += vCanProd;
                }


                return vCanTot;
            }
            public static bool fncAltaCajaBolsa(int vEmp, string vOFL,string vTipo,string vCodigo, int vNumCajaBolsa,string vCaja,int vPiezasCaja,
                                            string vBolsa, int vPiezasBolsa, string vProd, int vCan, string vMat,
                                            decimal vCanMat,DateTime vFecha,string vIdOper,string vLote,string vMaquina)
            {
                bool vOk = false;
                try
                {
                    string vTabla = "GC_OrdenProdCajas";

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


                    vDatos[1] = vEmp.ToString();
                    vDatos[2] = vOFL;
                    vDatos[3] = vTipo;
                    vDatos[4] = vCodigo;
                    vDatos[5] = vNumCajaBolsa.ToString();
                    vDatos[6] = vCaja;
                    vDatos[7] = vPiezasCaja.ToString();
                    vDatos[8] = vBolsa;
                    vDatos[9] = vPiezasBolsa.ToString();
                    vDatos[10] = vProd;
                    vDatos[11] = vCan.ToString();
                    vDatos[12] = vMat;
                    vDatos[13] = vCanMat.ToString().Replace(",",".");
                    vDatos[14] = vFecha.ToString();
                    vDatos[15] = vIdOper;
                    vDatos[16] = vLote;
                    vDatos[17] = "0";
                    vDatos[18] = vMaquina;


                    string vValoresNew = cUtil.fncReplaceValoresSQL(vDatos, vValoresCab, vNumCampos);
                    string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresNew;
                    int vCor = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                    if (vCor == 1)
                    {
                        vOk = true;
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                    vOk = false;
                }


                return vOk;

            }

            public static bool fncBajaCajaBolsa(string vID)
            {
                bool vOk = false;
                string vTablaCaja = "GC_OrdenProdCajas";
                string vSql = "";
                string vWhere = " Id = " + vID;
                vSql = cConstantes.SQL_UP_Delete;
                vSql = vSql.Replace("[?1]", vWhere);
                vSql = vSql.Replace("[?99]", vTablaCaja);
                int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                if (viOk == 1)
                {
                    vOk = true;
                }


                return vOk;
            }


            public static bool fncAltaVerif(int vEmp, string vOFL, string vObs, string vDia, string vHora, string vNombre,
                                string P1, string P2, string P3, string P4, string P5, string P6, string P7,
                                string P8, string P9, string P10,string vVal)
            {
                bool vOk = false;
                try
                {
                    string vTabla = "GC_OrdenProdVerif";

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


                    vDatos[1] = vEmp.ToString();
                    vDatos[2] = vOFL;
                    vDatos[3] = vDia;
                    vDatos[4] = vHora;
                    vDatos[5] = vNombre;
                    vDatos[6] = P1;
                    vDatos[7] = P2;
                    vDatos[8] = P3;
                    vDatos[9] = P4;
                    vDatos[10] = P5;
                    vDatos[11] = P6;
                    vDatos[12] = P7;
                    vDatos[13] = P8;
                    vDatos[14] = P9;
                    vDatos[15] = P10;
                    vDatos[16] = vVal;
                    vDatos[17] = vObs;


                    string vValoresNew = cUtil.fncReplaceValoresSQL(vDatos, vValoresCab, vNumCampos);
                    string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresNew;
                    int vCor = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                    if (vCor == 1)
                    {
                        vOk = true;
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                    vOk = false;
                }





                return vOk;

            }
            public static bool fncGrabaCampoVerif(string vId ,string vCampo, string vValor)
            {
                bool vOk = false;
                int viOk = 1;
                string vSql = "";
                string vWhere = " Id = " + vId;
                vSql = cConstantes.SQL_UP_Update;
                vSql = vSql.Replace("[?1]", "[" + vCampo + "]");
                vSql = vSql.Replace("[?2]", vValor);
                vSql = vSql.Replace("[?3]", vWhere);
                vSql = vSql.Replace("[?99]", "GC_OrdenProdVerif");
                viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);
                return vOk;
            }

            public static bool fncBajaVerif(int vId)
            {
                bool vOk = false;

                string vSql = cConstantes.SQL_UP_Delete;
                vSql = vSql.Replace("[?1]", " Id = " + vId );
                vSql = vSql.Replace("[?99]", "GC_OrdenProdVerif");
                int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);

                if (viOk == 1) vOk = true;

                return vOk;

            }


            public static bool fncMasCantidadFAb(string vEmpresa, string vOFL, string vCanFab)
            {
                bool vOk = false;

                //string vSql = cConstantes.SQL_OrdenProd_Update_CanFac;
                //vSql = vSql.Replace("[?2]", vCanFab);
                //vSql = vSql.Replace("[?3]", " Empresa = " + vEmpresa + " and IdOF ='" + vOFL + "' ");

                //int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);

                //if (viOk == 1) vOk = true;

                vOk = true;
                return vOk;
            }
            public static bool fncCantidadFAb(string vEmpresa, string vOFL, string vCan)
            {
                bool vOk = false;

                string vSql = cConstantes.SQL_OrdenProd_Update_Can;
                vSql = vSql.Replace("[?2]", vCan);
                vSql = vSql.Replace("[?3]", " Empresa = " + vEmpresa + " and IdOF ='" + vOFL + "' ");

                int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);

                if (viOk == 1) vOk = true;

                return vOk;
            }

            public static bool fncFinJornada(int vEmp, string vOper)
            {
                bool vOk = false;

                string vSql = cConstantes.SQL_OF_FinJornada;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", vEmp.ToString());
                vSql = vSql.Replace("[?Oper]", vOper);
                int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);

                if (viOk == 1) vOk = true;

                return vOk;

            }

            public static bool fncGrabaCajaBolsas(string vEmpresa, string vOFL, string vCaja)
            {
                bool vOk = false;
                string vSql = cConstantes.SQL_OF_Graba_CajaBolsas;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", vEmpresa);
                vSql = vSql.Replace("[?OFL]", vOFL);
                vSql = vSql.Replace("[?Caja]", vCaja);

                int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);

                if (viOk == 1) vOk = true;
                
                return vOk;
            }


            public static bool fncActuCampoOF(string vEmpresa, string vOFL, string vCampo, string vValor)
            {
                bool vOk = false;

                string vSql = cConstantes.SQL_UP_Update;
                vSql = vSql.Replace("[?1]", "[" + vCampo + "]");
                vSql = vSql.Replace("[?2]", vValor);
                vSql = vSql.Replace("[?3]", " Empresa = " + vEmpresa + " and IdOF ='" + vOFL + "' ");
                vSql = vSql.Replace("[?99]", "GC_OrdenProd");
                int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);

                if (viOk == 1) vOk = true;

                return vOk;
            }

            public static bool fncActuCampoModes(string vEmpresa, string vMolde, string vCampo, string vValor)
            {
                bool vOk = false;

                string vSql = cConstantes.SQL_UP_Update;
                vSql = vSql.Replace("[?1]", "[" + vCampo + "]");
                vSql = vSql.Replace("[?2]", vValor);
                vSql = vSql.Replace("[?3]", " Empresa = " + vEmpresa + " and CodMolde ='" + vMolde + "' ");
                vSql = vSql.Replace("[?99]", "GC_Moldes");
                int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);

                if (viOk == 1) vOk = true;

                return vOk;
            }

            #endregion



        }

        public class Moldes : Entidad
        {
            private int _Id = 0;
            private int _Empresa = 1;
            private string _CodMolde = "";
            private string _Descripción = "";
            private int _Cavidades = 0;
            private string _Ubicación = "";
            private string _Fechador = "";
            private bool _Bloqueado = false;
 


            private string vCamposIndice = ",Empresa,CodMolde,";
            private string vTabla = "[GC_Moldes]";

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
            public string CodMolde
            {
                get { return _CodMolde; }
                set
                {
                    sbrPropiAdi("CodMolde", _CodMolde.ToString(), value.ToString());
                    _CodMolde = value;
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
            public int Cavidades
            {
                get { return _Cavidades; }
                set
                {
                    sbrPropiAdi("Cavidades", _Cavidades.ToString(), value.ToString());
                    _Cavidades = value;
                }
            }
            public string Ubicación
            {
                get { return _Ubicación; }
                set
                {
                    sbrPropiAdi("Ubicación", _Ubicación.ToString(), value.ToString());
                    _Ubicación = value;
                }
            }
            public string Fechador
            {
                get { return _Fechador; }
                set
                {
                    sbrPropiAdi("Fechador", _Fechador.ToString(), value.ToString());
                    _Fechador = value;
                }
            }
            public bool Bloqueado
            {
                get { return _Bloqueado; }
                set
                {
                    sbrPropiAdi("Bloqueado", _Bloqueado.ToString(), value.ToString());
                    _Bloqueado = value;
                }
            }


            #endregion

            #region Constructor
            public Moldes()
            {
                aNuevo = true;
            }
            public Moldes(int vId, int vEmpresa, string vCodMolde, string vDescripción, int vCavidades,
                      string vUbicación, string vFechador, bool vBloqueado)
            {
                _Id = vId;
                _Empresa = vEmpresa;
                _CodMolde = vCodMolde;
                _Descripción = vDescripción;
                _Cavidades = vCavidades;
                _Ubicación = vUbicación;
                _Fechador = vFechador;
                _Bloqueado = vBloqueado;

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
                        MessageBox.Show(SQLDataAccess.Error);
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

                return fncAlta("1");

            }
            public int fncAlta(string vNumSerie)
            {

                //string vValores = cUtil.fncCargaValoresSQLDefault(vTabla, cParamXml.strConec, "Id,CantidadFab", "IdOF,Empresa,Estado,Fecha,FechaEntrega",
                //                                                vNumSerie + "," + cParamXml.Emp + ",Planificada," + DateTime.Now.ToShortDateString() + "," + DateTime.Now.ToShortDateString());
                //string vCampos = cUtil.Piece(vValores, "#", 2);
                //string vValoresDef = cUtil.Piece(vValores, "#", 5);

                //string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresDef;
                int vIdentity = 0;
                //try
                //{
                //    vIdentity = SQLDataAccess.GEN_ExecuteScalarIdentity(vSql, cParamXml.strConec);
                //    _Id = vIdentity;
                //}
                //catch { }

                return vIdentity;
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
            public static bool fncActuCampoMoldes(string vEmpresa, string vMolde, string vCampo, string vValor)
            {
                bool vOk = false;

                string vSql = cConstantes.SQL_UP_Update;
                vSql = vSql.Replace("[?1]", "[" + vCampo + "]");
                vSql = vSql.Replace("[?2]", vValor);
                vSql = vSql.Replace("[?3]", " Empresa = " + vEmpresa + " and CodMolde ='" + vMolde + "' ");
                vSql = vSql.Replace("[?99]", "GC_Moldes");
                int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);

                if (viOk == 1) vOk = true;

                return vOk;
            }

            #endregion



        }


        public class Informes
        {


            #region Metodos Staticos




            #endregion

        }

        //--------------------------------------------------------------------------------------------------


    }
}
