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
    class cPedidosVenta
    {
        public static int vCont = 0;
        public static List<CabVenta> Lista()
        {
            
            List<CabVenta> listaProy = new List<CabVenta>();

            using (SqlConnection vConnec = new SqlConnection(cParamXml.strConecProduc_Prueb))
            {
                vConnec.Open();
                string vSql = cConstantes.SQL_CabPedido;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());

                SqlDataReader dr = cUtil.fncTraeDataReader(vSql, vConnec);
                if (dr.HasRows == true) while (dr.Read()) listaProy.Add(new CabVenta((int)dr[0], (int)dr[1], (int)dr[2], dr[3].ToString(), (DateTime)dr[4],(DateTime)dr[5],
                                                                                     dr[6].ToString(),dr[7].ToString(),dr[8].ToString(),dr[9].ToString(),
                                                                                     dr[10].ToString(),dr[11].ToString(),dr[12].ToString(),dr[13].ToString(),
                                                                                     dr[14].ToString(), (Decimal)dr[15], (Decimal)dr[16], dr[17].ToString(), dr[18].ToString(),
                                                                                     dr[19].ToString(), dr[20].ToString(), (int)dr[21]));
                vConnec.Close();
            }

            return listaProy;
        }
        public class CabVenta:Entidad
        {
            private int _Id = 0;
            private int _Empresa = 1;
            private int _NumPed = 0;
            private string _Estado = "";
            private DateTime _FechaPedido = DateTime.UtcNow;
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

            private string vCamposIndice = ",Empresa,NumPed,";
            private string vTabla = "[GC_CabPedido]";

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
            public int NumPed
            {
                get { return _NumPed; }
                set
                {
                    sbrPropiAdi("NumPed", _NumPed.ToString(), value.ToString());
                    _NumPed = value;
                }
            }
            public DateTime FechaPedido
            {
                get { return _FechaPedido; }
                set
                {
                    sbrPropiAdi("FechaPedido", _FechaPedido.ToString(), value.ToString());
                    _FechaPedido = value;
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
            public CabVenta()
            {
                aNuevo = true;
            }
            public CabVenta(int vId,int vEmpresa, int vNumPed,string vEstado, DateTime vFechaPedido, DateTime vFechaEntrega,
                            string vCodCli, string vNomCli, string vDireccion, string vPoblacion,
                            string vProvincia, string vCP, string vFPago, string vDivisa, string vSuPedido,
                            decimal vDtoPP, decimal vDtoESP, string vEnt_Direccion, string vEnt_Poblacion,
                            string vEnt_Provincia, string vEnt_CP, int vEnt_Id)
            {
                _Id = vId;
                _Empresa = vEmpresa;
                _NumPed = vNumPed;
                _Estado = vEstado;
                _FechaPedido = vFechaPedido;
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
                string vNumSerie = SQLDataAccess.GenTraeNumSerie(cParamXml.NSerPedCliMan, true, cParamXml.strConec);
                int vNumSer = Convert.ToInt32(vNumSerie);


                string vValores = cUtil.fncCargaValoresSQLDefault(vTabla, cParamXml.strConec, "Id","NumPed,Empresa,Estado,FechaPedido",vNumSer.ToString() + "," + cParamXml.Emp + ",P," + DateTime.Now.ToShortDateString());
                string vCampos = cUtil.Piece(vValores, "#", 2);
                string vValoresDef = cUtil.Piece(vValores, "#", 5);

                string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresDef;
                int vIdentity = 0;
                try
                {
                    vIdentity = SQLDataAccess.GEN_ExecuteScalarIdentity(vSql, cParamXml.strConec);
                    _Id = vIdentity;
                    //_NumPed = 0;
                    _FechaPedido = DateTime.Now;
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

            public bool fncTrae(int vPed)
            {
                bool vOk = true;

                try
                {
                    //Traemos los datos del pedido
                    string vWhere = " Empresa = " + cParamXml.Emp + " and NumPed = " + vPed.ToString() + " ";
                    DataRow drp = cUtil.fncTraeCampos("GC_CabPedido", vWhere, cParamXml.strConecProduc_Prueb, "SQL");
                    
                    _Id = (int)drp["Id"];
                    _Empresa = (int)drp["Empresa"];
                    _NumPed = vPed;
                    _Estado = drp["Estado"].ToString();
                    _FechaPedido = (DateTime)drp["FechaPedido"];
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
                catch { vOk = false;}

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
        public static int fncBuscaIndexCabPed(BindingSource bS, string vProy)
        {
            int vReg = 0;

            if (bS.SupportsSearching)
            {
                vReg = bS.Find("NumPed", vProy);
            }
            else
            {
                List<cPedidosVenta.CabVenta> lista = (List<cPedidosVenta.CabVenta>)bS.List;

                cPedidosVenta.CabVenta result = lista.Find(
                delegate(cPedidosVenta.CabVenta bus)
                {
                    return bus.NumPed == Convert.ToInt32(vProy);
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

        public static List<LinVenta> ListaLineas(string vPed)
        {
            List<LinVenta> listaLineas = new List<LinVenta>();

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
                                                listaLineas.Add(new LinVenta((int)dr[0], (int)dr[1], (int)dr[2], (int)dr[3], dr[4].ToString(), dr[5].ToString(),
                                                                            (Decimal)dr[6], (Decimal)dr[7], (DateTime)dr[8], dr[9].ToString(), (int)dr[10],
                                                                            (Decimal)dr[11], (Decimal)dr[12], (Decimal)dr[13], (Decimal)dr[14], (int)dr[15]));
                vConnec.Close();
            }



            return listaLineas;

        }
        public class LinVenta:Entidad
        {

            private string _Error = "";
            private int _Id = 0;
            private int _Empresa = 1;
            private int _NumPed = 0;
            private int _LinPed = 0;
            private string _Producto = "";
            private string _Descripción = "";
            private decimal _Cantidad = 0;
            private decimal _CantidadServida = 0;
            private decimal _CantidadPendiente = 0;
            private DateTime _FechaEntrega = DateTime.UtcNow;
            private string _Lote = "";
            private int _IVA = 0;
            private decimal _Cajas = 0;
            private decimal _Precio = 0;
            private decimal _DTO = 0;
            private decimal _DTOLin = 0;
            private int _Prioridad = 0;

            private string vCamposIndice = ",Empresa,NumPed,LinPed";
            private string vTabla = "[GC_LinPedido]";

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
            public int NumPed
            {
                get { return _NumPed; }
                set
                {
                    sbrPropiAdi("NumPed", _NumPed.ToString(), value.ToString());
                    _NumPed = value;
                }
            }
            public int LinPed
            {
                get { return _LinPed; }
                set
                {
                    sbrPropiAdi("LinPed", _LinPed.ToString(), value.ToString());
                    _LinPed = value;
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
            public decimal CantidadServida
            {
                get { return _CantidadServida; }
                set
                {
                    sbrPropiAdi("CantidadServida", _CantidadServida.ToString(), value.ToString());
                    _CantidadServida = value;
                }
            }
            public decimal CantidadPendiente
            {
                get { return _CantidadPendiente; }
                set
                {
                    sbrPropiAdi("CantidadPendiente", _CantidadPendiente.ToString(), value.ToString());
                    _CantidadPendiente = value;
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
            public string Lote
            {
                get { return _Lote; }
                set
                {
                    sbrPropiAdi("Lote", _Lote.ToString(), value.ToString());
                    _Lote = value;
                }
            }
            public int IVA
            {
                get { return _IVA; }
                set
                {
                    sbrPropiAdi("IVA", _IVA.ToString(), value.ToString());
                    _IVA = value;
                }
            }
            public decimal Cajas
            {
                get { return _Cajas; }
                set
                {
                    sbrPropiAdi("Cajas", _Cajas.ToString(), value.ToString());
                    _Cajas = value;
                }
            }
            public decimal Precio
            {
                get { return _Precio; }
                set
                {
                    sbrPropiAdi("Precio", _Precio.ToString(), value.ToString());
                    _Precio = value;
                }
            }
            public decimal DTO
            {
                get { return _DTO; }
                set
                {
                    sbrPropiAdi("DTO", _DTO.ToString(), value.ToString());
                    _DTO = value;
                }
            }
            public decimal DTOLin
            {
                get { return _DTOLin; }
                set
                {
                    sbrPropiAdi("DTOLin", _DTOLin.ToString(), value.ToString());
                    _DTOLin = value;
                }
            }
            public int Prioridad
            {
                get { return _Prioridad; }
                set
                {
                    sbrPropiAdi("Prioridad", _Prioridad.ToString(), value.ToString());
                    _Prioridad = value;
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
                public LinVenta()
            {
                aNuevo = true;
            }
                public LinVenta(int vId,int vEmpresa, int vNumPed,int vLinped, string vProducto,
                                string vDescripción, Decimal vCantidad, Decimal vCantidadServida,
                                DateTime vFechaEntrega,string vLote,int vIVA,decimal vCajas,decimal vPrecio,
                                decimal vDTO,decimal vDTOLin,int vPrioridad)
                {
                    _Id = vId;
                    _Empresa = vEmpresa;
                    _NumPed = vNumPed;
                    _LinPed = vLinped;
                    _Producto = vProducto;
                    _Descripción = vDescripción;
                    _Cantidad = vCantidad;
                    _CantidadServida = vCantidadServida;
                    _CantidadPendiente = vCantidad - vCantidadServida;
                    _FechaEntrega = vFechaEntrega;
                    _Lote = vLote;
                    _IVA = vIVA;
                    _Cajas = vCajas;
                    _Precio = vPrecio;
                    _DTO = vDTO;
                    _DTOLin = vDTOLin;
                    _Prioridad = vPrioridad;

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
                string vValores = cUtil.fncCargaValoresSQLDefault(vTabla, "", "Id","Empresa,NumPed,LinPed",cParamXml.Emp + "," + _NumPed + ",");
                string vCampos = cUtil.Piece(vValores, "#", 2);
                string vValoresDef = cUtil.Piece(vValores, "#", 5);

                string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresDef;
                int vIdentity = 0;
                try
                {
                    vIdentity = SQLDataAccess.GEN_ExecuteScalarIdentity(vSql, cParamXml.strConecProduc_Prueb);
                    _Id = vIdentity;
                    _NumPed = 0;
                    _LinPed = 0;
                    _Producto = "";
                    _Descripción = "";
                    _Cantidad = 0;
                    _CantidadServida = 0;
                    _CantidadPendiente = 0;
                    _FechaEntrega = DateTime.Now;
                    _Lote = "";
                    _IVA = 0;
                    _Cajas = 0;
                    _Precio = 0;
                    _DTO = 0;
                    _DTOLin = 0;
                    _Prioridad = 0;
                }
                catch { }

                return vIdentity;
            }
            public bool fncAltaLin()
            {
                bool vOk = false;
                try
                {
                    string vTabla = "GC_LinPedido";

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

                    int vLin = fncNumLinea(_NumPed.ToString());

                    vDatos[1] = _Empresa.ToString();
                    vDatos[2] = _NumPed.ToString();
                    vDatos[3] = vLin.ToString();
                    vDatos[4] = _Producto;
                    vDatos[5] = _Descripción;
                    vDatos[6] = _Cantidad.ToString().Replace(",", ".");
                    vDatos[7] = "0";
                    vDatos[8] = _FechaEntrega.ToShortDateString();
                    vDatos[9] = _Lote;
                    vDatos[10] = _IVA.ToString().Replace(",", ".");
                    vDatos[11] = _Cajas.ToString().Replace(",", ".");
                    vDatos[12] = _Precio.ToString().Replace(",", ".");
                    vDatos[13] = _DTO.ToString().Replace(",", ".");
                    vDatos[14] = _DTOLin.ToString().Replace(",", ".");
                    vDatos[15] = _Prioridad.ToString();
 

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
            public static int fncNumLinea(string vNumPed)
            {
                int vNumLin = 0;
                string vSql=cConstantes.SQL_NumLinPed;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?NumPed]", vNumPed);

                DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));
                if (dt.Rows.Count>0)
                {
                    string vNL = dt.Rows[0]["NumLin"].ToString();
                    if (vNL == "") { vNL = "0"; }
                    vNumLin = Convert.ToInt16(vNL);
                }
                vNumLin++;
                return vNumLin;
            }
            public bool fncTrae(int vPed,int vLin)
            {
                bool vOk = true;

                try
                {
                    //Traemos los datos del pedido
                    string vWhere = " Empresa = " + cParamXml.Emp + " and NumPed = " + vPed.ToString() + "  and LinPed = " + vLin.ToString() + " ";
                    DataRow drp = cUtil.fncTraeCampos("GC_LinPedido", vWhere, cParamXml.strConecProduc_Prueb, "SQL");

                    _Id = (int)drp["Id"];
                    _Empresa = (int)drp["Empresa"];
                    _NumPed = vPed;
                    _LinPed = vLin;
                    _Producto = drp["Producto"].ToString();
                    _Descripción = drp["Descripción"].ToString();
                    _Cantidad = (Decimal)drp["Cantidad"];
                    _CantidadServida = (Decimal)drp["CantidadServida"];
                    _CantidadPendiente = (Decimal)drp["Cantidad"] - (Decimal)drp["CantidadServida"];
                    _FechaEntrega = (DateTime)drp["FechaEntrega"];
                    _Lote = drp["Lote"].ToString();
                    _IVA = (int)drp["IVA"];
                    _Cajas = (Decimal)drp["Cajas"];
                    _Precio = (Decimal)drp["Precio"];
                    _DTO = (Decimal)drp["DTO"];
                    _DTOLin = (Decimal)drp["DTOLin"];
                    _Prioridad = (int)drp["Prioridad"];

                }
                catch { vOk = false; }

                return vOk;
            }

            public static bool fncCantidadServida(string vEmpresa, int vPed, int vLin, string vCan, SqlConnection vConec, SqlTransaction vTr)
            {
                bool vOk = false;

                string vSql = cConstantes.SQL_PedidoVenta_Update_CanServida;
                vSql = vSql.Replace("[?2]", vCan);
                vSql = vSql.Replace("[?3]", " Empresa = " + vEmpresa + " and NumPed =" + vPed + " and LinPed =" + vLin + " ");

                int viOk = SQLDataAccess.GEN_ExecuteNonQueryTransac(vSql, vConec, vTr);

                if (viOk == 1) vOk = true;

                return vOk;
            }
            public static bool fncMasCantidadServida(string vEmpresa, int vPed, int vLin, string vCan, SqlConnection vConec, SqlTransaction vTr)
            {
                bool vOk = false;

                string vSql = cConstantes.SQL_PedidoVenta_Update_MasCanServida;
                vSql = vSql.Replace("[?2]", vCan);
                vSql = vSql.Replace("[?3]", " Empresa = " + vEmpresa + " and NumPed =" + vPed + " and LinPed =" + vLin + " ");

                int viOk = SQLDataAccess.GEN_ExecuteNonQueryTransac(vSql, vConec, vTr);

                if (viOk == 1) vOk = true;

                return vOk;
            }
            public static bool fncMenosCantidadServida(string vEmpresa, int vPed, int vLin, string vCan, SqlConnection vConec, SqlTransaction vTr)
            {
                bool vOk = false;

                string vSql = cConstantes.SQL_PedidoVenta_Update_MenosCanServida;
                vSql = vSql.Replace("[?2]", vCan.Replace(",","."));
                vSql = vSql.Replace("[?3]", " Empresa = " + vEmpresa + " and NumPed =" + vPed + " and LinPed =" + vLin + " ");

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
        public static int fncBuscaIndexLinPed(BindingSource bS, string vPed)
        {
            int vReg = 0;

            if (bS.SupportsSearching)
            {
                vReg = bS.Find("NumPed", vPed);
            }
            else
            {
                List<cPedidosVenta.LinVenta> lista = (List<cPedidosVenta.LinVenta>)bS.List;
                cPedidosVenta.LinVenta result = lista.Find(
                delegate(cPedidosVenta.LinVenta bus)
                {
                    return bus.NumPed == Convert.ToInt32(vPed);
                }
                );


                if (result != null)
                {
                    vReg = bS.IndexOf(result);

                }

            }

            return vReg;
        }





    }
}
