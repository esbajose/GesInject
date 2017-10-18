using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using jControles.Clases;

namespace SrvGesInj.Clases
{
    class cAlbaranesCompra
    {


        public class LinAlbCompra
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
            private int _Grabado = 10;
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
            public string CodProv
            {
                get { return _CodProv; }
                set
                {
                    _CodProv = value;
                }
            }
            public string NombreProv
            {
                get { return _NombreProv; }
                set
                {
                    _NombreProv = value;
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
            public string RecepcionadoPor
            {
                get { return _RecepcionadoPor; }
                set
                {
                    _RecepcionadoPor = value;
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
                //aNuevo = true;
            }
            public LinAlbCompra(int vId, int vEmpresa, string vNumAlb, int vLinea, DateTime vFechaEntrega, string vProducto,
                            string vDescripción,string vCodProv,string vNombreProv, Decimal vCantidad,
                            string vLote, string vRecepcionadoPor,int vGrabado,string vNumSerie)
            {
                _Id = vId;
                _Empresa = vEmpresa;
                _NumAlb = vNumAlb;
                _Linea = vLinea;
                _FechaEntrega = vFechaEntrega;
                _Producto = vProducto;
                _Descripción = vDescripción;
                _CodProv = vCodProv;
                _NombreProv = vNombreProv;
                _Cantidad = vCantidad;
                _Lote = vLote;
                _RecepcionadoPor = vRecepcionadoPor;
                _Grabado = vGrabado;
                _NumSerie = vNumSerie;

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
                    string vTabla = "GC_AlbProv";

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

                    
                    if (_NumSerie == "") _NumSerie = SQLDataAccess.GenTraeNumSerie("ProductoLote", true, cParamXml.strConec);

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
