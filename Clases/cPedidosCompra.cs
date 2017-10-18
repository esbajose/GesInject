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
    class cPedidosCompra
    {
        public static int vCont = 0;
        public static List<CabCompra> Lista()
        {

            List<CabCompra> listaProy = new List<CabCompra>();

            using (SqlConnection vConnec = new SqlConnection(cParamXml.strConecProduc_Prueb))
            {
                vConnec.Open();
                string vSql = cConstantes.SQL_CabCompra;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());

                SqlDataReader dr = cUtil.fncTraeDataReader(vSql, vConnec);
                if (dr.HasRows == true) while (dr.Read()) listaProy.Add(new CabCompra((int)dr["Id"], (int)dr["Empresa"], dr["NumPed"].ToString(), dr["Estado"].ToString(), (DateTime)dr["FechaPedido"], (DateTime)dr["FechaEntrega"],
                                                                                     dr["CodProv"].ToString(), dr["NomProv"].ToString(), dr["Dirección"].ToString(), dr["Población"].ToString(),
                                                                                     dr["Provincia"].ToString(), dr["CP"].ToString(), dr["FPago"].ToString(), dr["Divisa"].ToString(),
                                                                                     dr["SuPedido"].ToString()));
                vConnec.Close();
            }

            return listaProy;
        }
        public class CabCompra : Entidad
        {
            private int _Id = 0;
            private int _Empresa = 1;
            private string _NumPed = "0";
            private string _Estado = "";
            private DateTime _FechaPedido = DateTime.UtcNow;
            private DateTime _FechaEntrega = DateTime.UtcNow;
            private string _CodProv = "";
            private string _NomProv = "";
            private string _Dirección = "";
            private string _Población = "";
            private string _Provincia = "";
            private string _CP = "";
            private string _FPago = "";
            private string _Divisa = "";
            private string _SuPedido = "";

            private string vCamposIndice = ",Empresa,NumPed,";
            private string vTabla = "[GC_CabCompra]";

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
            public string NumPed
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
            public string CodProv
            {
                get { return _CodProv; }
                set
                {
                    sbrPropiAdi("CodProv", _CodProv.ToString(), value.ToString());
                    _CodProv = value;
                }
            }
            public string NomProv
            {
                get { return _NomProv; }
                set
                {
                    sbrPropiAdi("NomCli", _NomProv.ToString(), value.ToString());
                    _NomProv = value;
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




            #endregion

            #region Constructor
            public CabCompra()
            {
                aNuevo = true;
            }
            public CabCompra(int vId, int vEmpresa, string vNumPed, string vEstado, DateTime vFechaPedido, DateTime vFechaEntrega,
                            string vCodProv, string vNomProv, string vDireccion, string vPoblacion,
                            string vProvincia, string vCP, string vFPago, string vDivisa, string vSuPedido)
            {
                _Id = vId;
                _Empresa = vEmpresa;
                _NumPed = vNumPed;
                _Estado = vEstado;
                _FechaPedido = vFechaPedido;
                _FechaEntrega = vFechaEntrega;
                _CodProv = vCodProv;
                _NomProv = vNomProv;
                _Dirección = vDireccion;
                _Población = vPoblacion;
                _Provincia = vProvincia;
                _CP = vCP;
                _FPago = vFPago;
                _Divisa = vDivisa;
                _SuPedido = vSuPedido;


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

                string vNumSer = SQLDataAccess.GenTraeNumSerie(cParamXml.NSerPedProv, true, cParamXml.strConec);

                string vValores = cUtil.fncCargaValoresSQLDefault(vTabla, cParamXml.strConec, "Id", "NumPed,Empresa,Estado,FechaPedido", vNumSer.ToString() + "," + cParamXml.Emp + ",P," + DateTime.Now.ToShortDateString());
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
                    _CodProv = "";
                    _NomProv = "";
                    _Dirección = "";
                    _Población = "";
                    _Provincia = "";
                    _CP = "";
                    _FPago = "";
                    _Divisa = "";
                    _SuPedido = "";
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
                List<cPedidosCompra.CabCompra> lista = (List<cPedidosCompra.CabCompra>)bS.List;

                cPedidosCompra.CabCompra result = lista.Find(
                delegate(cPedidosCompra.CabCompra bus)
                {
                    return bus.NumPed == vProy;
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

        public static List<LinCompra> ListaLineas(string vPed)
        {
            List<LinCompra> listaLineas = new List<LinCompra>();

            using (SqlConnection vConnec = new SqlConnection(cParamXml.strConecProduc_Prueb))
            {
                vConnec.Open();
                string vSql = cConstantes.SQL_LinCompra;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?Ped]", vPed);

                SqlDataReader dr = cUtil.fncTraeDataReader(vSql, vConnec);
                if (dr.HasRows == true) while (dr.Read())
                        listaLineas.Add(new LinCompra((int)dr["Id"], (int)dr["Empresa"], dr["NumPed"].ToString(), 
                                                        (int)dr["LinPed"], dr["Producto"].ToString(), 
                                                        dr["Descripción"].ToString(),(Decimal)dr["Cantidad"], 
                                                        (Decimal)dr["CantidadEntregada"], (int)dr["IVA"],
                                                        (Decimal)dr["Precio"],(Decimal)dr["DTO"]));
                vConnec.Close();
            }



            return listaLineas;

        }
        public class LinCompra : Entidad
        {

            private string _Error = "";
            private int _Id = 0;
            private int _Empresa = 1;
            private string _NumPed = "0";
            private int _LinPed = 0;
            private string _Producto = "";
            private string _Descripción = "";
            private decimal _Cantidad = 0;
            private decimal _CantidadEntregada = 0;
            private int _IVA = 0;
            private decimal _Precio = 0;
            private decimal _DTO = 0;

            private string vCamposIndice = ",Empresa,NumPed,LinPed";
            private string vTabla = "[GC_LinCompra]";

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
            public string NumPed
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
            public decimal CantidadEntregada
            {
                get { return _CantidadEntregada; }
                set
                {
                    sbrPropiAdi("CantidadEntregada", _CantidadEntregada.ToString(), value.ToString());
                    _CantidadEntregada = value;
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




            #endregion

            #region Constructor
            public LinCompra()
            {
                aNuevo = true;
            }
            public LinCompra(int vId, int vEmpresa, string vNumPed, int vLinped, string vProducto,
                            string vDescripción, Decimal vCantidad, Decimal vCantidadEntregada,
                            int vIVA, decimal vPrecio,decimal vDTO)
            {
                _Id = vId;
                _Empresa = vEmpresa;
                _NumPed = vNumPed;
                _LinPed = vLinped;
                _Producto = vProducto;
                _Descripción = vDescripción;
                _Cantidad = vCantidad;
                _CantidadEntregada = vCantidadEntregada;
                _IVA = vIVA;
                _Precio = vPrecio;
                _DTO = vDTO;

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
                string vValores = cUtil.fncCargaValoresSQLDefault(vTabla, "", "Id", "Empresa,NumPed,LinPed", cParamXml.Emp + "," + _NumPed + ",");
                string vCampos = cUtil.Piece(vValores, "#", 2);
                string vValoresDef = cUtil.Piece(vValores, "#", 5);

                string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresDef;
                int vIdentity = 0;
                try
                {
                    vIdentity = SQLDataAccess.GEN_ExecuteScalarIdentity(vSql, cParamXml.strConecProduc_Prueb);
                    _Id = vIdentity;
                    _NumPed = "0";
                    _LinPed = 0;
                    _Producto = "";
                    _Descripción = "";
                    _Cantidad = 0;
                    _CantidadEntregada = 0;
                    _IVA = 0;
                    _Precio = 0;
                    _DTO = 0;
                }
                catch { }

                return vIdentity;
            }
            public bool fncAltaLin()
            {
                bool vOk = false;
                try
                {
                    string vTabla = "GC_LinCompra";

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
                    vDatos[8] = _IVA.ToString().Replace(",", ".");
                    vDatos[9] = _Precio.ToString().Replace(",", ".");
                    vDatos[10] = _DTO.ToString().Replace(",", ".");


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
                string vSql = cConstantes.SQL_NumLinPedCompra;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?NumPed]", vNumPed);

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
                vReg = bS.Find("NumPed", vPed);
            }
            else
            {
                List<cPedidosCompra.LinCompra> lista = (List<cPedidosCompra.LinCompra>)bS.List;
                cPedidosCompra.LinCompra result = lista.Find(
                delegate(cPedidosCompra.LinCompra bus)
                {
                    return bus.NumPed == vPed;
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
