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
    class cMovimientos
    {



        public class Articulo : Entidad
        {
            private int _Id = 0;
            private int _Empresa = 1;
            private string _Tipo = "";
            private DateTime _Fecha = DateTime.Now;
            private DateTime _FechaHora = DateTime.Now;
            private string _Almacen = "";
            private string _Producto = "";
            private string _Descripción = "";
            private decimal _Cantidad = 0;            
            private string _Documento = "";
            private string _OFL = "";
            private string _Ubi = "";
            private string _Lote = "";
            

            private string vCamposIndice = "";
            private string vTabla = "GC_MovProducto";

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
            public string Tipo
            {
                get { return _Tipo; }
                set
                {
                    sbrPropiAdi("Tipo", _Tipo.ToString(), value.ToString());
                    _Tipo = value;
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
            public DateTime FechaHora
            {
                get { return _FechaHora; }
                set
                {
                    sbrPropiAdi("FechaHora", _FechaHora.ToString(), value.ToString());
                    _FechaHora = value;
                }
            }
            public string Almacen
            {
                get { return _Almacen; }
                set
                {
                    sbrPropiAdi("Almacen", _Almacen.ToString(), value.ToString());
                    _Almacen = value;
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
            public string Documento
            {
                get { return _Documento; }
                set
                {
                    sbrPropiAdi("Documento", _Documento.ToString(), value.ToString());
                    _Documento = value;
                }
            }
            public string OFL
            {
                get { return _OFL; }
                set
                {
                    sbrPropiAdi("OFL", _OFL.ToString(), value.ToString());
                    _OFL = value;
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
            public string Lote
            {
                get { return _Lote; }
                set
                {
                    sbrPropiAdi("Lote", _Lote.ToString(), value.ToString());
                    _Lote = value;
                }
            }
            

            #endregion

            #region Constructor
            public Articulo()
            {
                aNuevo = true;
            }
            public Articulo(int vId, int vEmpresa, string vTipo, DateTime vFecha, DateTime vFechaHora, string vAlmacen, string vProducto,
                            string vDescripción, decimal vCantidad, string vDocumento, string vOFL, string vUbicación, string vLote)
            {
                _Id = vId;
                _Empresa = vEmpresa;
                _Tipo=vTipo;
                _Fecha=vFecha;
                _FechaHora=vFechaHora;
                _Almacen=vAlmacen;
                _Producto = vProducto;
                _Descripción = vDescripción;
                _Cantidad=vCantidad;
                _Documento=vDocumento;
                _OFL=vOFL;
                _Ubi = vUbicación;
                _Lote = vLote;


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

                string vValores = cUtil.fncCargaValoresSQLDefault(vTabla, cParamXml.strConec, "Id", "Empresa", cParamXml.Emp.ToString());
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
            public bool fncAlta(DataGridViewRow dr)
            {
                bool vOk = false;
                try
                {
               

                    string vValoresCab = cUtil.fncCargaValoresSQLparaComand(vTabla,cParamXml.strConecProduc_Prueb);
                    int vNumCampos = Convert.ToInt16(cUtil.Piece(vValoresCab, "#", 3));
                    string vCampos = cUtil.Piece(vValoresCab, "#", 2);
                    vValoresCab = cUtil.Piece(vValoresCab, "#", 1);
                    string vCamposRelp = vCampos.Substring(1, vCampos.Length - 2);


                    int vCont = 1;
                    string[] vDatos = new string[vNumCampos];
                    for (int i = 0; i < vNumCampos; i++)
                    {
                        string vCampo = dr.Cells[i].OwningColumn.Name;
                        if (vCampo.LastIndexOf("bt") == -1)
                        {
                            string vValor = "";
                            if (dr.Cells[i].Value != null) vValor = dr.Cells[i].Value.ToString();
                            if (vCampo == "Empresa") vValor = "1";

                            vDatos[vCont] = vValor;
                            vCont++;
                        }
                        else
                        {
                            //vNumCampos++;
                        }
                    }

                
                    string vValoresNew = cUtil.fncReplaceValoresSQL(vDatos, vValoresCab, vNumCampos);
                    string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresNew;
                    int vCor =  SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConec);
                    if (vCor == 1)
                    {
                        vOk = true;
                    }
                }
                catch(Exception ex)
                {
                    vOk = false;
                }
                return vOk;
            }
            public bool fncAlta(int vEmpresa, string vTipo, DateTime vFecha, DateTime vFechaHora, 
                                string vAlmacen, string vProducto, string vDescripción, string vCantidad, 
                                string vDocumento, string vOFL,string vUbicación,string vLote)
            {
                bool vOk = false;
                SqlConnection dbConec = new SqlConnection(cParamXml.strConec);
                dbConec.Open();
                SqlTransaction dbTr = dbConec.BeginTransaction();
                try
                {

                    vOk = fncAlta( vEmpresa,  vTipo,  vFecha,  vFechaHora, 
                                 vAlmacen,  vProducto,  vDescripción,  vCantidad, 
                                 vDocumento,  vOFL, vUbicación, vLote,dbConec,dbTr);

                }
                catch
                {
                    vOk = false;
                }


                if (vOk)
                {
                    //Al terminar correctamente los cambios se graban
                    dbTr.Commit();
                    dbConec.Close();
                    dbConec.Dispose();
                }
                else
                {
                    //Al terminar con error se revierten los cambios
                    dbTr.Rollback();
                    dbConec.Close();
                    dbConec.Dispose();
                }
                return vOk;
            }


            public bool fncAlta(int vEmpresa, string vTipo, DateTime vFecha, DateTime vFechaHora,
                                string vAlmacen, string vProducto, string vDescripción, string vCantidad,
                                string vDocumento, string vOFL, string vUbicación, string vLote,SqlConnection dbconec,SqlTransaction dbTr)
            {
                bool vOk = false;
                try
                {


                    string vValoresCab = cUtil.fncCargaValoresSQLparaComand(vTabla, cParamXml.strConecProduc_Prueb);
                    int vNumCampos = Convert.ToInt16(cUtil.Piece(vValoresCab, "#", 3));
                    string vCampos = cUtil.Piece(vValoresCab, "#", 2);
                    vValoresCab = cUtil.Piece(vValoresCab, "#", 1);
                    string vCamposRelp = vCampos.Substring(1, vCampos.Length - 2);


                    int vCont = 1;
                    string[] vDatos = new string[vNumCampos];
                    for (int i = 0; i < vNumCampos; i++)
                    {
                        vDatos[i] = "";
                    }

                    if (vEmpresa == 0) vEmpresa = 1;

                    vDatos[1] = vEmpresa.ToString();
                    vDatos[2] = vTipo;
                    vDatos[3] = vFecha.ToShortDateString();
                    vDatos[4] = vFechaHora.ToString();
                    vDatos[5] = vAlmacen;
                    vDatos[6] = vProducto;
                    vDatos[7] = vDescripción;
                    vDatos[8] = vCantidad.ToString().Replace(",", ".");
                    vDatos[9] = vDocumento;
                    vDatos[10] = vOFL;
                    vDatos[11] = vUbicación;
                    vDatos[12] = vLote;

                    string vValoresNew = cUtil.fncReplaceValoresSQL(vDatos, vValoresCab, vNumCampos);
                    string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresNew;
                    int vCor = SQLDataAccess.GEN_ExecuteNonQueryTransac(vSql,dbconec,dbTr);
                    if (vCor == 1)
                    {
                        vOk = true;
                    }
                }
                catch (Exception ex)
                {
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
            public static DataTable fncProdAnexos(int vEmp, string vProd)
            {
                string vSql = cConstantes.SQL_Articulo_anexos;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?CodProd]", vProd);

                DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

                return dt;
            }

            public static string fncTraeUbi(int vEmp,string vDoc,string vProd,string vTipo,string vCan,string vLote)
            {    

                string vUbi = "";
                string vSql = cConstantes.SQL_Movi_TraeUbi;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", vEmp.ToString());
                vSql = vSql.Replace("[?Doc]", vDoc);
                vSql = vSql.Replace("[?Prod]", vProd);
                vSql = vSql.Replace("[?Tipo]", vTipo);
                vSql = vSql.Replace("[?Can]", vCan.Replace(",","."));
                vSql = vSql.Replace("[?Lote]", vLote);
                DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));

                if (dt.Rows.Count > 0)
                {
                    vUbi = dt.Rows[0]["Ubi"].ToString();
                }



                return vUbi;
            }

            #endregion


        }


    }
}
