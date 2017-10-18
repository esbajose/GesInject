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
    class cProducto
    {
        public static List<Articulo> Lista()
        {

            List<Articulo> listaArticulo = new List<Articulo>();

            using (SqlConnection vConnec = new SqlConnection(cParamXml.strConecProduc_Prueb))
            {
                vConnec.Open();
                string vSql = cConstantes.SQL_Articulo;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());

                SqlDataReader dr = cUtil.fncTraeDataReader(vSql, vConnec);
                if (dr.HasRows == true) while (dr.Read())
                        listaArticulo.Add(new Articulo((int)dr["Id"], (int)dr["Empresa"], dr["Producto"].ToString(), dr["Descripción"].ToString(),
                                            dr["Material"].ToString(), dr["Color"].ToString(), dr["CodProv"].ToString(),
                                            dr["NombreProv"].ToString(), dr["CodMolde"].ToString(), (decimal)dr["Precio"],
                                             (decimal)dr["PesoNeto"], (int)dr["PiezasHora"], dr["Bolsa"].ToString(), (int)dr["PiezasBolsa"],
                                            dr["Caja"].ToString(), (int)dr["PiezasCaja"], dr["Imagen"].ToString(), dr["Documentación"].ToString(),
                                            (decimal)dr["StockMinimo"], (decimal)dr["PVP"], (int)dr["EsMaterial"], dr["PrioMaq1"].ToString(),
                                            dr["PrioMaq2"].ToString(), dr["PrioMaq3"].ToString(), (int)dr["LogoCaja"], (int)dr["LogoBolsa"]));
                vConnec.Close();
            }

            return listaArticulo;
        }
        public static int fncBuscaIndexOF(BindingSource bS, string vProducto)
        {
            int vReg = 0;

            if (bS.SupportsSearching)
            {
                vReg = bS.Find("Producto", vProducto);
            }
            else
            {
                List<Articulo> lista = (List<Articulo>)bS.List;
                Articulo result = lista.Find(bus => bus.Producto == vProducto);

                if (result != null)
                {
                    vReg = bS.IndexOf(result);

                }
                else
                {
                    vReg = -1;
                }

            }

            return vReg;
        }

        public class Articulo : Entidad
        {
            private int _Id = 0;
            private int _Empresa = 1;
            private string _Producto = "";
            private string _Descripción = "";
            private string _Material = "";
            private string _Color = "";
            private string _CodProv = "";
            private string _NombreProv = "";
            private string _CodMolde = "";
            private decimal _Precio = 0;
            private decimal _PesoNeto = 0;
            private int _PiezasHora = 0;
            private string _Bolsa = "";
            private int _PiezasBolsa = 0;
            private string _Caja = "";
            private int _PiezasCaja = 0;
            private string _Imagen = "";
            private string _Documentación = "";
            private decimal _StockMinimo = 0;
            private decimal _PVP = 0;
            private int _EsMaterial = 0;
            private string _PrioMaq1 = "";
            private string _PrioMaq2 = "";
            private string _PrioMaq3 = "";
            private int _LogoCaja = 0;
            private int _LogoBolsa = 0;



            private string vCamposIndice = ",Empresa,Producto,";
            private string vTabla = "[GC_ProductoAnexos]";

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
            public string Material
            {
                get { return _Material; }
                set
                {
                    sbrPropiAdi("Material", _Material.ToString(), value.ToString());
                    _Material = value;
                }
            }
            public string Color
            {
                get { return _Color; }
                set
                {
                    sbrPropiAdi("Color", _Color.ToString(), value.ToString());
                    _Color = value;
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
            public string CodMolde
            {
                get { return _CodMolde; }
                set
                {
                    sbrPropiAdi("CodMolde", _CodMolde.ToString(), value.ToString());
                    _CodMolde = value;
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
            public decimal PesoNeto
            {
                get { return _PesoNeto; }
                set
                {
                    sbrPropiAdi("PesoNeto", _PesoNeto.ToString(), value.ToString());
                    _PesoNeto = value;
                }
            }
            public int PiezasHora
            {
                get { return _PiezasHora; }
                set
                {
                    sbrPropiAdi("PiezasHora", _PiezasHora.ToString(), value.ToString());
                    _PiezasHora = value;
                }
            }
            public string Bolsa
            {
                get { return _Bolsa; }
                set
                {
                    sbrPropiAdi("Bolsa", _Bolsa.ToString(), value.ToString());
                    _Bolsa = value;
                }
            }
            public int PiezasBolsa
            {
                get { return _PiezasBolsa; }
                set
                {
                    sbrPropiAdi("PiezasBolsa", _PiezasBolsa.ToString(), value.ToString());
                    _PiezasBolsa = value;
                }
            }
            public string Caja
            {
                get { return _Caja; }
                set
                {
                    sbrPropiAdi("Caja", _Caja.ToString(), value.ToString());
                    _Caja = value;
                }
            }
            public int PiezasCaja
            {
                get { return _PiezasCaja; }
                set
                {
                    sbrPropiAdi("PiezasCaja", _PiezasCaja.ToString(), value.ToString());
                    _PiezasCaja = value;
                }
            }
            public string Imagen
            {
                get { return _Imagen; }
                set
                {
                    sbrPropiAdi("Imagen", _Imagen.ToString(), value.ToString());
                    _Imagen = value;
                }
            }
            public string Documentación
            {
                get { return _Documentación; }
                set
                {
                    sbrPropiAdi("Documentación", _Documentación.ToString(), value.ToString());
                    _Documentación = value;
                }
            }
            public decimal StockMinimo
            {
                get { return _StockMinimo; }
                set
                {
                    sbrPropiAdi("StockMinimo", _StockMinimo.ToString(), value.ToString());
                    _StockMinimo = value;
                }
            }
            public decimal PVP
            {
                get { return _PVP; }
                set
                {
                    sbrPropiAdi("PVP", _PVP.ToString(), value.ToString());
                    _PVP = value;
                }
            }
            public int EsMaterial
            {
                get { return _EsMaterial; }
                set
                {
                    sbrPropiAdi("EsMaterial", _EsMaterial.ToString(), value.ToString());
                    _EsMaterial = value;
                }
            }
            public string PrioMaq1
            {
                get { return _PrioMaq1; }
                set
                {
                    sbrPropiAdi("PrioMaq1", _PrioMaq1.ToString(), value.ToString());
                    _PrioMaq1 = value;
                }
            }
            public string PrioMaq2
            {
                get { return _PrioMaq2; }
                set
                {
                    sbrPropiAdi("PrioMaq2", _PrioMaq2.ToString(), value.ToString());
                    _PrioMaq2 = value;
                }
            }
            public string PrioMaq3
            {
                get { return _PrioMaq3; }
                set
                {
                    sbrPropiAdi("PrioMaq3", _PrioMaq3.ToString(), value.ToString());
                    _PrioMaq3 = value;
                }
            }
            public int LogoCaja
            {
                get { return _LogoCaja; }
                set
                {
                    sbrPropiAdi("LogoCaja", _LogoCaja.ToString(), value.ToString());
                    _LogoCaja = value;
                }
            }
            public int LogoBolsa
            {
                get { return _LogoBolsa; }
                set
                {
                    sbrPropiAdi("LogoBolsa", _LogoBolsa.ToString(), value.ToString());
                    _LogoBolsa = value;
                }
            }


            #endregion

            #region Constructor
            public Articulo()
            {
                aNuevo = true;
            }
            public Articulo(int vId, int vEmpresa,string vProducto,string vDescripción,string vMaterial,
                            string vColor,string vCodProv,string vNombreProv,string vCodMolde,decimal vPrecio,
                            decimal vPesoNeto,int vPiezasHora,string vBolsa,int vPiezasBolsa,string vCaja,
                            int vPiezasCaja,string vImagen,string vDocumentación,decimal vStockMinimo,decimal vPvp,int vEsMaterial,
                            string vPrioMaq1, string vPrioMaq2, string vPrioMaq3,int vLogoCaja,int vLogoBolsa)
            {
                _Id = vId;
                _Empresa = vEmpresa;
                _Producto = vProducto;
                _Descripción = vDescripción;
                _Material = vMaterial;
                _Color = vColor;
                _CodProv = vCodProv;
                _NombreProv = vNombreProv;
                _CodMolde = vCodMolde;
                _Precio = vPrecio;
                _PesoNeto = vPesoNeto;
                _PiezasHora = vPiezasHora;
                _Bolsa = vBolsa;
                _PiezasBolsa = vPiezasBolsa;
                _Caja = vCaja;
                _PiezasCaja = vPiezasCaja;
                _Imagen = vImagen;
                _Documentación = vDocumentación;
                _StockMinimo = vStockMinimo;
                _PVP = vPvp;
                _EsMaterial = vEsMaterial;
                _PrioMaq1 = vPrioMaq1;
                _PrioMaq2 = vPrioMaq2;
                _PrioMaq3 = vPrioMaq3;
                _LogoCaja = vLogoCaja;
                _LogoBolsa = vLogoBolsa;

            }

            #endregion

            #region Metodos

            public bool fncGrabaCampo(string vCampo, string vValor)
            {
                bool vOk = false;
                int viOk = 1;
                //if ((vCamposIndice.LastIndexOf("," + vCampo + ",") == -1) | (aValorAnt == ""))
                //{
                    if (vValor != aValorAnt)
                    {
                        string vSql = "";
                        string vWhere = " Id = " + _Id;
                        vSql = cConstantes.SQL_UP_Update;
                        vSql = vSql.Replace("[?1]", "[" + vCampo + "]");
                        vSql = vSql.Replace("[?2]", vValor.Replace(",","."));
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
                //}
                //else
                //{
                ////    if (vValor != "")
                //    {
                //        MessageBox.Show(string.Format("El Campo:{0} es un indice,NO se puede Modificar", aCampoModif));
                //    }
                //    else
                //    {
                //        MessageBox.Show(string.Format("El Campo:{0} es un indice,NO se puede quedar en blanco", aCampoModif));
                //    }

                //    sbrRollback();
                //}
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

                string vValores = cUtil.fncCargaValoresSQLDefault(vTabla, cParamXml.strConec, "Id","Empresa",cParamXml.Emp.ToString());
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

            public int fncAltaProducto(string vProd,string vDes)
            {

                string vValores = cUtil.fncCargaValoresSQLDefault(vTabla, cParamXml.strConec, "Id", "Empresa,Producto,Descripción", cParamXml.Emp.ToString() + "," + vProd + "," + vDes);
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
            public static DataTable fncProdSitu(int vEmp, string vProd,string vAlm)
            {
                string vSql = cConstantes.SQL_Prod_Situ;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?CodProd]", vProd);
                vSql = vSql.Replace("[?Alm]", vAlm);

                DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

                return dt;
            }
            public static DataTable fncProdMat(int vEmp, string vProd)
            {
                return fncProdMat(vEmp,vProd,"");
            }
            public static DataTable fncProdMat(int vEmp, string vProd,string vActivo)
            {
                return fncProdMat(vEmp,vProd,vActivo,0);
            }
            public static DataTable fncProdMat(int vEmp, string vProd, string vActivo,int vCan)
            {
                string vFilActivo = "";
                if (vActivo != "") { vFilActivo = " AND (Activo = " + vActivo + ") "; }
                string vSql = cConstantes.SQL_Prod_Mat;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?CodProd]", vProd);
                vSql = vSql.Replace("[?FilActivo]", vFilActivo);
                vSql = vSql.Replace("[?Can]", vCan.ToString());

                DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

                return dt;
            }

            public static string fncTraeC(string vCampo,string vProd)
            {
                string vValor = "";
                DataTable dt = new DataTable();
                dt = fncProdAnexos(cParamXml.Emp, vProd);
                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        vValor = dt.Rows[0][vCampo].ToString();
                    }
                    catch { }
                }

                return vValor;
            }
            public static string fncPesoMat(string vProd,string vMat)
            {


                string vWhere = "  (Producto = N'" + vProd + "') AND (Empresa = 1) AND (Material = N'" + vMat + "')";
                string vPeso = cUtil.fncTraeCampo("Peso", "GC_ProductoMaterial", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", false);

                return vPeso;
            }


            #endregion

        }

    }
}
