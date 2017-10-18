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


namespace SrvGesInj.Clases
{
    class cProductoLote : Entidad
    {

        private int _Id = 0;
        private int _Empresa = 1;
        private string _NumSerie = "";
        private string _Producto = "";
        private string _Lote = "";
        private string _NumAlb = "";
        private int _Linea = 0;


        private string vCamposIndice = "";
        private string vTabla = "GC_ProductoLote";

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
        public string NumSerie
        {
            get { return _NumSerie; }
            set
            {
                sbrPropiAdi("NumSerie", _NumSerie.ToString(), value.ToString());
                _NumSerie = value;
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


        #endregion

        #region Constructor
        public cProductoLote()
        {
            aNuevo = true;
        }
        public cProductoLote(int vId, int vEmpresa, string vNumSerie,string vProducto,string vLote,string vNumAlb,int vLinea)
        {
            _Id = vId;
            _Empresa = vEmpresa;
            _NumSerie = vNumSerie;
            _Producto = vProducto;
            _Lote = vLote;
            _NumAlb = vNumAlb;
            _Linea = vLinea;

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


                string vValoresCab = cUtil.fncCargaValoresSQLparaComand(vTabla, cParamXml.strConecProduc_Prueb);
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
                int vCor = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConec);
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
        public bool fncAlta(int vEmpresa, string vNumSerie, string vProducto, string vLote, string vNumAlb, int vLinea)
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


                vDatos[1] = vEmpresa.ToString();
                vDatos[2] = vNumSerie;
                vDatos[3] = vProducto;
                vDatos[4] = vLote;
                vDatos[5] = vNumAlb;
                vDatos[6] = vLinea.ToString();

                string vValoresNew = cUtil.fncReplaceValoresSQL(vDatos, vValoresCab, vNumCampos);
                string vSql = "INSERT INTO " + vTabla + vCampos + " " + vValoresNew;
                int vCor = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConec);
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

        #endregion




    }
}
