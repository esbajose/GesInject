using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GesInject.Clases;
using jControles.Clases;
using GesInject.Datasets;
using jControles.Formularios;



namespace GesInject.Formularios
{
    public partial class frmProducción : Form
    {
        private bool vEnProd=false;

        private string vProd = "";
        private string vMat = "";
        private string vBolsa = "";
        private int vPiezasBolsa = 0;
        private string vCaja = "";
        private int vPiezasCaja = 0;
        private string vPeso = "0";
        private string vDescripción = "";
        private bool vNuevoLote = false;
        private string vLoteAnt = "";
        private string vLectura = "";
        private string vTipoCierre = "";

        public frmProducción()
        {
            InitializeComponent();
        }

        #region Procesos locales

        private void sbrProduccion(bool vIni)
        {


            if (vIni)
            {
                frmIniProd frm = new frmIniProd();
                frmIniProd.vOper = txIdOper.Text;
                frmIniProd.vMaq = txidMaq.Text;
                
                frm.ShowDialog();

                if (frmIniProd.vCancel) return;

                txidMaq.Text = frmIniProd.vMaq;
                txIdOper.Text = frmIniProd.vOper;
                txMaq.Text = frmIniProd.vMaq + "-" + frmIniProd.vDesMaq;
                txOper.Text = frmIniProd.vOper + "-" + frmIniProd.vDesOper;
                txHoraIni.Text = DateTime.Now.ToString();

                btIni.Text = "Parar Producción";
                btIni.BackColor = Color.Red;
                vEnProd = true;

                cProduc.OF.fncCambiarEstado(cParamXml.Emp.ToString(), txOFL.Text, "Producción");
                cProduc.OF.fncAltaEnprod(cParamXml.Emp, txOFL.Text, txHoraIni.Text, frmIniProd.vOper, frmIniProd.vDesOper,
                                           frmIniProd.vMaq, frmIniProd.vDesMaq,txLotes.Text);

                string vWhere = " Empresa = " + cParamXml.Emp + " and IdOF ='" + txOFL.Text + "' ";
                string vFechaIni = cUtil.fncTraeCampo("FechaInicio", "GC_OrdenProd", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", true);
                DateTime vdtFIni = Convert.ToDateTime(vFechaIni);
                if (vFechaIni != "***Inex***")
                {
                    if (vdtFIni == Convert.ToDateTime("01/01/1753"))
                    {
                        cProduc.OF.fncActuCampoOF(cParamXml.Emp.ToString(), txOFL.Text, "FechaInicio", DateTime.Now.ToShortDateString());
                    }
                }




            }
            else
            {
                btIni.Text = "Iniciar Producción";
                btIni.BackColor = Color.LightGreen;
                vEnProd = false;
                cProduc.OF.fncCambiarEstado(cParamXml.Emp.ToString(), txOFL.Text, "Lanzada");
                cProduc.OF.fncBajaEnprod(cParamXml.Emp, txOFL.Text);

                sbrLimpia();

            }
            panel3.Enabled = !vIni;
            panel1.Enabled = vIni;


        }
        private void sbrBuscaOFL()
        {
            string vSql = cConstantes.SQL_OF_ProducLista;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());


            string vTabla = "GC_OrdenProd";
            string vWhere = " where Empresa = [?Emp] and (Estado = 'Lanzada' or Estado = 'Producción') ";
            vWhere = "";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "IdOF", txOFL.Text, vWhere,vSql, "", false, "", "", "", "SQL");

            if (vRes != "")
            {
                btBlockMOlde.Visible = false;
                txOFL.Text = vRes;
                txOFL.Focus();
                txOFL_KeyUp(this, new KeyEventArgs(Keys.Enter));
            }
        }
        private void sbrLimpia()
        {
            vEnProd = false;
            panel3.Enabled = !vEnProd;
            panel1.Enabled = vEnProd;
            btIni.Text = "Iniciar Producción";
            btIni.BackColor = Color.LightGreen;
            txHoraIni.Text = "";
            txidMaq.Text = "";
            txIdOper.Text = "";
            txMaq.Text = "";
            txOFL.Text = "";
            txOper.Text = "";
            lbCan.Text = "";
            lbCanProd.Text = "";
            lbProd.Text = "";
            lbMat.Text = "";
            txOFL.Focus();
            txLote.Text = "";
            txMolde.Text = "";
            btBlockMOlde.Visible = false;
            txLotes.Text = "";
            grProduc.DataSource = null;
            grVerif.DataSource = null;
            sbrLimpiaVerif();
            
        }
        private bool fncCambiarOper()
        {
            bool vOk = false;

            frmIniProd frm = new frmIniProd();
            frmIniProd.vOper = txIdOper.Text;
            frmIniProd.vVerMaq = false;

            frm.ShowDialog();

            if (frmIniProd.vCancel)
            {
                
                return vOk;
            }

            txIdOper.Text = frmIniProd.vOper;
            txOper.Text = frmIniProd.vOper + "-" + frmIniProd.vDesOper;

            string vTabla = "GC_EnProducción";
            string vWhere = " Empresa = " + cParamXml.Emp.ToString() + " and IdOF ='" + txOFL.Text + "'";

            cUtil.fncActuCampo("IdOper", vTabla, vWhere, "", frmIniProd.vOper);
            cUtil.fncActuCampo("NombreOper", vTabla, vWhere, "", frmIniProd.vDesOper);
            vOk = true;

            return vOk;
        }
        private bool fncCambiarMaq()
        {
            bool vOk = false;

            frmIniProd frm = new frmIniProd();
            frmIniProd.vOper = txIdOper.Text;
            frmIniProd.vVerOper = false;

            frm.ShowDialog();

            if (frmIniProd.vCancel)
            {
                
                return vOk;
            }

            txidMaq.Text = frmIniProd.vMaq;
            txMaq.Text = frmIniProd.vMaq + "-" + frmIniProd.vDesMaq;

            string vTabla = "GC_EnProducción";
            string vWhere = " Empresa = " + cParamXml.Emp.ToString() + " and IdOF ='" + txOFL.Text + "'";

            cUtil.fncActuCampo("IdMaquina", vTabla, vWhere, "", frmIniProd.vMaq);
            cUtil.fncActuCampo("DesMaquina", vTabla, vWhere, "", frmIniProd.vDesMaq);
            vOk = true;

            return vOk;
        }
        private bool fncLote()
        {
            bool vOk = false;


            //Busco los materiales a utilizar en la producción de la pieza
            string vLote = "";

            DataTable dtMat = cProducto.Articulo.fncProdMat(cParamXml.Emp, vProd, "1", 0);
            foreach (DataRow drM in dtMat.Rows)
            {
                vMat = drM["Material"].ToString();
                string vDesMat = drM["DesMaterial"].ToString();
                vPeso = drM["Peso"].ToString();




                string vSql = cConstantes.SQL_Prod_Ubi_Lote;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?Prod]", vMat);
                vSql = vSql.Replace("[?OFL]", txOFL.Text);

                vSql += " and (Ubi = 'PRODUC') ";


                string vRes = cUtil.fncLista("GC_Ind_ProductoUbiCanLoteOFL", cParamXml.strConecProduc_Prueb, "Lote", "", "", vSql, "", true, "", "", "", "SQL");

                if (vRes != "")
                {
                    vLote += cUtil.Piece(vRes, "#", 1) + "^";

                }
                else
                {
                    MessageBox.Show("No se ha selecionado un Lote");
                    txLote.Text = "";
                    vOk = false;
                    return vOk;
                }

            }

            if (vLote != "") vLote = vLote.Substring(0, vLote.Length - 1);
                 




            string vWhere = "";
            //string vLote = cUtil.InPutBox("Nº Lote", "Lote de producción", "", "1");
            //if (vLote != "*****Cancelado*****")
            //{
            //    string vCanst = "0";
            //    vWhere = " Empresa = " + cParamXml.Emp + " and Lote ='" + vLote + "' ";
            //    string vProd = cUtil.fncTraeCampo("Producto", "GC_LoteCertificado", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", true);
            //    if (vProd == "***Inex***")
            //    {
            //        MessageBox.Show("Este Lote no tiene informado un producto");
            //        cErrores.Error.fncAlta(cParamXml.Emp, "Lote", DateTime.Now, "Este Lote no tiene informado un producto",
            //            "", 0, cParamXml.Usuario, cParamXml.PC);
            //    }
            //    else
            //    {
            //        vWhere = " Empresa = " + cParamXml.Emp + " and Almacen ='Principal' and Ubi ='PRODUC' and Producto ='" + vProd + "' ";
            //        vCanst = cUtil.fncTraeCampo("Cantidad", "GC_Ind_ProductoUbiCan", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", true);
            //        if (vCanst == "***Inex***")
            //        {
            //            vCanst = "0";
            //        }
                    

            //    }

            //    if (vProd != "***Inex***")
            //    {
            //        decimal vdCan = Convert.ToDecimal(vCanst);
            //        if (vdCan == 0)
            //        {
            //            cErrores.Error.fncAlta(cParamXml.Emp, "Lote", DateTime.Now, "NO hay cantidad del producto (" + vProd + ") de este lote (" + vLote + ") en la Ubicación 'PRODUC'",
            //                                    "", 0, cParamXml.Usuario, cParamXml.PC);

            //            MessageBox.Show("NO hay cantidad del producto (" + vProd + ") de este lote (" + vLote + ") en la Ubicación 'PRODUC'");
            //        }
            //    }




                vLoteAnt = txLote.Text;
                txLote.Text = vLote;
                vNuevoLote = true;
                if (txLotes.Text.LastIndexOf(vLote) == -1)
                {
                    txLotes.Text += vLote + ",";
                }

            //}
            //else
            //{
            //    vOk = false;
            //    return vOk;
            //}

            string vTabla = "GC_EnProducción";
            vWhere = " Empresa = " + cParamXml.Emp.ToString() + " and IdOF ='" + txOFL.Text + "'";

            cUtil.fncActuCampo("Lote", vTabla, vWhere, "", vLote);
            vOk = true;

            return vOk;
        }
        private void sbrEnProducción(string vEmpresa,string vOFL)
        {

            string vSql = cConstantes.SQL_OFL_EnProd_Lista;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", vEmpresa);
            vSql = vSql.Replace("[?OFL]", vOFL);
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));
            if (dt.Rows.Count > 0)
            {
                txidMaq.Text = dt.Rows[0]["IdMaquina"].ToString();
                txIdOper.Text = dt.Rows[0]["IdOper"].ToString();
                txMaq.Text = dt.Rows[0]["IdMaquina"].ToString() +"-" + dt.Rows[0]["DesMaquina"].ToString(); ;
                txOper.Text = dt.Rows[0]["IdOper"].ToString() + "-" + dt.Rows[0]["NombreOper"].ToString();
                txHoraIni.Text = dt.Rows[0]["FechaInicio"].ToString();
                txLote.Text = dt.Rows[0]["Lote"].ToString();
                string vLotes = cProduc.OF.fncTraeLotes(vEmpresa,vOFL);
                txLotes.Text = vLotes;
                if (txLotes.Text.LastIndexOf(txLote.Text) == -1)
                {
                    txLotes.Text += txLote.Text + ",";
                }


                btIni.Text = "Parar Producción";
                btIni.BackColor = Color.Red;
                vEnProd = true;
                //btBlockMOlde.Visible = true;
                panel3.Enabled = !vEnProd;
                panel1.Enabled = vEnProd;

            }else
            {
                sbrLimpia();
                vEnProd = false;
                panel3.Enabled = !vEnProd;
                panel1.Enabled = vEnProd;
            }


        }
        private bool sbrCerrarCajaBolsas()
        {
            return sbrCerrarCajaBolsas(true);
        }
        private bool sbrCerrarCajaBolsas(bool vMensa)
        {
            bool vOk = false;
            int vNumCaja = cProduc.OF.fncTraeNumCaja(cParamXml.Emp.ToString(), txOFL.Text);

            string vSql = cConstantes.SQL_OF_Cerrar_CajaBolsas;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?OFL]", txOFL.Text);
            vSql = vSql.Replace("[?Caja]", vNumCaja.ToString());
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));
            
            if (dt.Rows.Count == 0)
            {
                if (vMensa) MessageBox.Show("No hay Bolsas para cerrar Caja");
                return vOk;
            }
            string vBolsas = "";
            string vLotes = "";
            int viCan = 0;
            int viCanCaja = 0;
            decimal vdCanMat = 0;
            foreach (DataRow dr in dt.Rows)
            {
                string vCodigo = dr["Codigo"].ToString();
                string vCan = dr["CanProd"].ToString();
                string vCanCaja = dr["PiezasCaja"].ToString();
                string vCanMat = dr["CanMat"].ToString();
                string vLote = dr["Lote"].ToString();
                viCan += Convert.ToInt32(vCan);
                viCanCaja = Convert.ToInt32(vCanCaja);
                
                vdCanMat += Convert.ToDecimal(vCanMat);
                if (vLotes.LastIndexOf(vLote) ==-1)
                {
                    vLotes += vLote;
                }


                vBolsas += vCodigo + ",";
            }

            if (viCan < viCanCaja)
            {
                string vTexto = "La Cantidad en bolsas (" + viCan.ToString() + ") NO coincide con la de la caja (" + viCanCaja.ToString() + ")";
                if (!fncSeguridad(vTexto))
                {
                    return vOk;
                }

            }

            if (vMensa)
            {
                string vMen = "Cerrar la caja Nº:" + vNumCaja.ToString() + " con las bolsas:" + vBolsas + "?";
                string vTit = "OF";
                if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return vOk;
                }
            }

            //cProduc.OF.fncGrabaCajaBolsas(cParamXml.Emp.ToString(), txOFL.Text, vNumCaja.ToString());

            //alta de la caja o bolsa
            if (cProduc.OF.fncAltaCajaBolsa(cParamXml.Emp, txOFL.Text, "C", vNumCaja.ToString(), vNumCaja, vCaja, vPiezasCaja, vBolsa,
                                            vPiezasBolsa, vProd, viCan, vMat, vdCanMat, DateTime.Now,
                                            txOper.Text, vLotes,txMaq.Text))
            { }


            //Movimiento de cajas
            //Busco las ubicaciones de la caja
            string vWhere = " Empresa = " + cParamXml.Emp + " and Producto = N'" + vProd + "'";
            string vCodCaja = cUtil.fncTraeCampo("Caja", "GC_ProductoAnexos", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", true);


            vSql = cConstantes.SQL_Prod_Ubi;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?Prod]", vCodCaja);

            DataTable dtMat = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));

            decimal vdCanC = 1;
            decimal vdCanCaja = vdCanC * -1;
            cMovimientos.Articulo oMov = new cMovimientos.Articulo();
            bool vMovCajaBolsa = false;
            foreach (DataRow drM in dtMat.Rows)
            {
                string vUbi = drM["Ubi"].ToString();
                string vCanUbi = drM["Cantidad"].ToString();

                decimal vdCanUbi = Convert.ToDecimal(vCanUbi.Replace(".", ","));

                if (vdCanUbi >= vdCanC)
                {
                    oMov.fncAlta(cParamXml.Emp, "Salida", DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vCodCaja, "",
                                    vdCanCaja.ToString(), txOFL.Text, txOFL.Text, vUbi, txLote.Text);
                    vMovCajaBolsa = true;
                    break;
                }

            }



            if (!vMovCajaBolsa)
            {
                MessageBox.Show("No hay suficientes cajas en el stock");
            }


            if (cParamXml.ImpEtCajaBolsa == "True")
            {
                sbrImprimeEtiqueta(vNumCaja.ToString(), viCan);
            }



            sbrCargaCajas();


            vOk = true;
            return vOk;
        }
        private string fncCerrarCajaBolsa()
        {
            string vOk = "Error";

            decimal vCanOF = Convert.ToDecimal(lbCan.Text);
            string vsCanFab = lbCanProd.Text;
            if (vsCanFab == "") vsCanFab = "0";
            decimal vCanFab = Convert.ToDecimal(vsCanFab);

            string vWhere = " Empresa = " + cParamXml.Emp + " and Producto = '" + vProd + "' ";
            DataRow drm = cUtil.fncTraeCampos("GC_ProductoAnexos", vWhere, cParamXml.strConecProduc_Prueb, "SQL");
            
            vBolsa = "";
            vPiezasBolsa = 0;
            vCaja = "";
            vPiezasCaja = 0;
            vPeso = "0";
            vDescripción="";

            if (drm != null)
            {
                vBolsa = drm["Bolsa"].ToString();
                vPiezasBolsa = (int)drm["PiezasBolsa"];
                vCaja = drm["Caja"].ToString();
                vPiezasCaja = (int)drm["PiezasCaja"];
                vPeso = drm["PesoNeto"].ToString();
                vDescripción = drm["Descripción"].ToString();
            }

            frmCerrarCajaBolsa frm = new frmCerrarCajaBolsa();
            frmCerrarCajaBolsa.vCanCaja = vPiezasCaja.ToString();
            frmCerrarCajaBolsa.vCanBolsa = vPiezasBolsa.ToString();
            frmCerrarCajaBolsa.vOperario = txOper.Text;
            frmCerrarCajaBolsa.vTipoCierre = vTipoCierre;


            frm.ShowDialog();

            vTipoCierre = "";
            if (frmCerrarCajaBolsa.vCancel) return vOk;



            bool vEsCaja = frmCerrarCajaBolsa.vCaja;
            string vCan = frmCerrarCajaBolsa.vCan;
            decimal vdPeso = Convert.ToDecimal(vPeso.Replace(".", ","));
            decimal vdCan = Convert.ToDecimal(vCan.Replace(".", ","));
            decimal vCanMat = vdCan * vdPeso / 1000;

            //Movimiento de Matprima
            //Busco los materiales a utilizar en la producción de la pieza
            DataTable dtMat = cProducto.Articulo.fncProdMat(cParamXml.Emp, vProd, "1");
            int vCont = 1;
            foreach (DataRow drM in dtMat.Rows)
            {
                vMat = drM["Material"].ToString();
                vPeso = drM["Peso"].ToString();
                vdPeso = Convert.ToDecimal(vPeso.Replace(".", ","));

                vCanMat = vdCan * vdPeso / 1000;

                decimal vdCanMat = vCanMat;

                string vWhere2 = " (Empresa = " + cParamXml.Emp.ToString() + ") AND (Producto = N'" + vMat + "') AND (Lote = N'" + cUtil.Piece(txLote.Text,"^",vCont) + "') AND (OFL = N'" + txOFL.Text + "') AND (Almacen = N'principal') AND (Ubi = N'PRODUC')";
                string vCanSt = cUtil.fncTraeCampo("Cantidad", "  GC_Ind_ProductoUbiCanLoteOFL", vWhere2, "", cParamXml.strConecProduc_Prueb, "SQL", false);
                if (vCanSt == "") vCanSt = "0";
                decimal vdCanSt = Convert.ToDecimal(vCanSt);
                if (vdCanSt < vdCanMat)
                {
                    string vLit = "NO hay suficiente Stock para esta producción.";                    
                    vLit +="Componente=" + vMat + "   ";
                    vLit +="Necesidad=" + vdCanMat.ToString() + "  Stock Actual en Ubicación 'PRODUC'=" + vdCanSt.ToString();
                    MessageBox.Show(vLit );
                    vLit = vLit.Replace(",", ".");
                    vLit = vLit.Replace("'", "''");

                    cErrores.Error.fncAlta(cParamXml.Emp, "Lote", DateTime.Now, vLit,"", 0, cParamXml.Usuario, cParamXml.PC);

                    return vOk;
                }
                vCont++;
            }

            if (!cUtil.fncVerifSQLConec(cParamXml.strConec))
            {
                MessageBox.Show("No hay conexión con la Base de datos");
                return vOk;
            }


            if ((vdCan + vCanFab) > vCanOF)
            {
                string vMen = "La cantidad Fabricada: " + vCan + " supera la cantidad pendiente de fabricar:" + (vCanOF-vCanFab).ToString() +", si continua se modificara la cantidad de la O.F.,¿Es correcto?";
                string vTit = "OF";
                if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return vOk;
                }

                //Actualizar la cantidad en la OF
                cProduc.OF.fncCantidadFAb(cParamXml.Emp.ToString(), txOFL.Text, (vdCan + vCanFab).ToString());

            }

            int vNumCajaBolsa=0;
            string vTipo="";
            string vNumCaja = "";
            if (vEsCaja)
            {

                vNumCaja = "";
                vNumCajaBolsa=cProduc.OF.fncTraeNumCaja(cParamXml.Emp.ToString(),txOFL.Text);

                string vSql = cConstantes.SQL_OF_Cerrar_CajaBolsas;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?OFL]", txOFL.Text);
                vSql = vSql.Replace("[?Caja]", vNumCajaBolsa.ToString());
                DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Hay Bolsas para cerrar Caja");
                    return vOk;
                }


                vTipo="C";
            }
            else
            {
                vNumCaja = cProduc.OF.fncTraeNumCaja(cParamXml.Emp.ToString(), txOFL.Text).ToString();
                vNumCajaBolsa=cProduc.OF.fncTraeNumBolsa(cParamXml.Emp.ToString(),txOFL.Text,vNumCaja.ToString());
                vTipo="B";
            }
            string vCodigo = vNumCaja + "." + vNumCajaBolsa.ToString();
            if (vNumCaja == "") vCodigo = vNumCajaBolsa.ToString();
            
            string vLote = txLote.Text;
            if ((vNuevoLote)& (vLoteAnt != ""))
            {
                vLote = vLoteAnt + "," + txLote.Text;
            }

            //alta de la caja o bolsa
            if (cProduc.OF.fncAltaCajaBolsa(cParamXml.Emp,txOFL.Text,vTipo,vCodigo,vNumCajaBolsa,vCaja,vPiezasCaja,vBolsa,
                                            vPiezasBolsa,vProd,Convert.ToInt32(vCan),vMat,vCanMat,DateTime.Now,
                                            txOper.Text,vLote,txMaq.Text))
            {
                //Actualizar la cantidad fabricada en la OF
                cProduc.OF.fncMasCantidadFAb(cParamXml.Emp.ToString(), txOFL.Text, vCan);

                //Crear movimientos de producto y materia prima
                cMovimientos.Articulo oMov = new cMovimientos.Articulo();
                
                //Movimiento de producto
                oMov.fncAlta(cParamXml.Emp, "Entrada", DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vProd, vDescripción,
                                vCan, txOFL.Text, txOFL.Text, "FAB", vLote);


                //Movimiento de Matprima
                //Busco los materiales a utilizar en la producción de la pieza
                dtMat = cProducto.Articulo.fncProdMat(cParamXml.Emp, vProd, "1");
                vCont = 1;
                foreach (DataRow drM in dtMat.Rows)
                {
                    vMat = drM["Material"].ToString();
                    vPeso = drM["Peso"].ToString();
                    vdPeso = Convert.ToDecimal(vPeso.Replace(".", ","));

                    vCanMat = vdCan * vdPeso / 1000;

                    decimal vdCanMat = vCanMat * -1;
                    oMov.fncAlta(cParamXml.Emp, "Salida", DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vMat, "",
                                    vdCanMat.ToString(), vProd, txOFL.Text, "PRODUC", cUtil.Piece(txLote.Text, "^", vCont));

                    vCont++;
                }

                bool vMovCajaBolsa = false;
                if (vEsCaja)
                {
                    //Movimiento de cajas
                    //Busco las ubicaciones de la caja
                    if (vCaja != "")
                    {
                        string vSql = cConstantes.SQL_Prod_Ubi;
                        vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                        vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                        vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                        vSql = vSql.Replace("[?Prod]", vCaja);

                        dtMat = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));

                        decimal vdCanC = 1;
                        decimal vdCanCaja = vdCanC * -1;

                        foreach (DataRow drM in dtMat.Rows)
                        {
                            string vUbi = drM["Ubi"].ToString();
                            string vCanUbi = drM["Cantidad"].ToString();
                            vdPeso = Convert.ToDecimal(vPeso.Replace(".", ","));

                            decimal vdCanUbi = Convert.ToDecimal(vCanUbi.Replace(".", ","));

                            if (vdCanUbi >= vdCanC)
                            {
                                oMov.fncAlta(cParamXml.Emp, "Salida", DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vCaja, "",
                                                vdCanCaja.ToString(), txOFL.Text, txOFL.Text, vUbi, txLote.Text);
                                vMovCajaBolsa = true;
                                break;

                            }

                        }
                    }
                }
                else
                {
                    //Movimiento de cajas
                    //Busco las ubicaciones de la bolsa
                    if (vBolsa != "")
                    {
                        string vSql = cConstantes.SQL_Prod_Ubi;
                        vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                        vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                        vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                        vSql = vSql.Replace("[?Prod]", vBolsa);

                        dtMat = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));

                        decimal vdCanB = 1;
                        decimal vdCanBolsa = vdCanB * -1;

                        foreach (DataRow drM in dtMat.Rows)
                        {
                            string vUbi = drM["Ubi"].ToString();
                            string vCanUbi = drM["Cantidad"].ToString();
                            vdPeso = Convert.ToDecimal(vPeso.Replace(".", ","));

                            decimal vdCanUbi = Convert.ToDecimal(vCanUbi.Replace(".", ","));

                            if (vdCanUbi >= vdCanB)
                            {
                                oMov.fncAlta(cParamXml.Emp, "Salida", DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vBolsa, "",
                                                vdCanBolsa.ToString(), txOFL.Text, txOFL.Text, vUbi, txLote.Text);
                                vMovCajaBolsa = true;
                                break;

                            }

                        }
                    }

                }

                if (!vMovCajaBolsa)
                {
                    if (vEsCaja)
                    {
                        MessageBox.Show("No hay suficientes cajas en el stock");
                    }
                    else
                    {
                        MessageBox.Show("No hay suficientes bolsas en el stock");

                    }
                }


                
            }

            if ((cParamXml.ImpEtCajaBolsa == "True")&(chPrinEti.Checked))
            {
                string vsNumCajaBolsa = "";
                if (vTipo!="B")
                {
                    vsNumCajaBolsa = vNumCajaBolsa.ToString();
                } 
                else
                {
                    vsNumCajaBolsa = vNumCaja.ToString() + "." + vNumCajaBolsa.ToString();

                }
                sbrImprimeEtiqueta(vsNumCajaBolsa, Convert.ToInt32(vCan));
            }

            vOk = vTipo;

            return vOk;
        }
        private void sbrCarga()
        {
            sbrCargaCajas();
            sbrCargaComentarios();
            sbrCargaVerif();
            sbrCargaMat(vProd);
        }
        private void sbrCargaCajas()
        {
            string vSql = cConstantes.SQL_OFL_Cajas_Lista;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?OFL]", txOFL.Text);
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));


            grProduc.DataSource = null;
            grProduc.DataSource = dt.DefaultView;

            sbrformatogrCajas();
        }
        private void sbrformatogrCajas()
        {

            grProduc.Columns["Id"].Visible = false;
            grProduc.Columns["Empresa"].Visible = false;
            grProduc.Columns["IdOF"].Visible = false;
        }
        private void sbrCargaComentarios()
        {
            string vSql = cConstantes.SQL_OFL_Coment_Lista;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?OFL]", txOFL.Text);
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

            grComent.DataSource = null;
            grComent.DataSource = dt.DefaultView;

            sbrformatogrComent();
        }
        private void sbrformatogrComent()
        {

            grComent.Columns["Id"].Visible = false;
            grComent.Columns["Empresa"].Visible = false;
            grComent.Columns["IdOF"].Visible = false;
            grComent.Columns["Comentario"].Width = 800;
        }
        private void sbrCargaVerif()
        {
            string vSql = cConstantes.SQL_OFL_Verif_Lista;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?OFL]", txOFL.Text);
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

            grVerif.DataSource = null;
            grVerif.DataSource = dt.DefaultView;

            sbrformatogrVerif();
        }
        private void sbrformatogrVerif()
        {

            grVerif.Columns["Id"].Visible = false;
            grVerif.Columns["Empresa"].Visible = false;
            grVerif.Columns["IdOF"].Visible = false;

            grVerif.Columns["Dia"].Width = 70;
            grVerif.Columns["Hora"].Width = 50;
            grVerif.Columns["Nombre"].Width = 60;
            grVerif.Columns["P1"].Width = 50;
            grVerif.Columns["P2"].Width = 50;
            grVerif.Columns["P3"].Width = 50;
            grVerif.Columns["P4"].Width = 50;
            grVerif.Columns["P5"].Width = 50;
            grVerif.Columns["P6"].Width = 50;
            grVerif.Columns["P7"].Width = 50;
            grVerif.Columns["P8"].Width = 50;
            grVerif.Columns["P9"].Width = 50;
            grVerif.Columns["P10"].Width = 50;
            grVerif.Columns["Observaciones"].Width = 300;


            foreach(DataGridViewRow dr in grVerif.Rows)
            {
                foreach(DataGridViewColumn cl in grVerif.Columns)
                {
                    string vName = cl.Name;
                    if ((vName == "P1")|(vName == "P2")|(vName == "P3")|(vName == "P4")|(vName == "P5")|(vName == "P6")|(vName == "P7")|(vName == "P8")|(vName == "P9")|(vName == "P10"))
                    {
                        string vVal = dr.Cells[vName].Value.ToString();
                        if (vVal.Trim() == "NoOk")
                        {
                            dr.Cells[vName].Style.BackColor = Color.Red;
                            Application.DoEvents();
                        }
                    }
                }

            }


        }   
        private void sbrActuOFL()
        {
            DataRow dr;
            string vWhere = " Empresa = " + cParamXml.Emp + " and IdOF = '" + txOFL.Text + "' ";
            dr = cUtil.fncTraeCampos("GC_OrdenProd", vWhere, cParamXml.strConecProduc_Prueb, "SQL");
            vWhere = " Empresa = " + cParamXml.Emp + " and Producto = '" + dr["Articulo"].ToString() + "' ";
            DataRow drm = cUtil.fncTraeCampos("GC_ProductoMaterial", vWhere, cParamXml.strConecProduc_Prueb, "SQL");


            lbProd.Text = "";
            lbMat.Text = "";

            if (dr != null)
            {
                vProd = dr["Articulo"].ToString();
                lbProd.Text = vProd + "-" + dr["Descripción"].ToString();
                vMat = drm["Material"].ToString();
                lbMat.Text = vMat + "-" + drm["DesMaterial"].ToString();
                lbCan.Text = dr["Cantidad"].ToString();
                lbCanProd.Text = dr["CantidadFab"].ToString();

                vWhere = " Empresa = " + cParamXml.Emp + " and Producto = '" + vProd + "' ";
                DataRow drax = cUtil.fncTraeCampos("GC_ProductoAnexos", vWhere, cParamXml.strConecProduc_Prueb, "SQL");
                txMolde.Text = drax["CodMolde"].ToString();

                bool vMolBloq = false;
                if (txMolde.Text != "")
                {
                    vWhere = " Empresa = " + cParamXml.Emp + " and CodMolde = '" + txMolde.Text + "' ";
                    DataRow drmol = cUtil.fncTraeCampos("GC_Moldes", vWhere, cParamXml.strConecProduc_Prueb, "SQL");
                    if (drmol != null)
                    {
                        vMolBloq = (bool)drmol["Bloqueado"];
                    }
                }
                if (vMolBloq)
                {
                    MessageBox.Show("El molde de esta producción esta bloqueado.No se puede iniciar");
                    sbrLimpia();
                    return;
                }
                
                string vEstado = dr["Estado"].ToString();
                if (vEstado == "Producción")
                {
                    sbrEnProducción(cParamXml.Emp.ToString(), txOFL.Text);

                    if ((txOper.Text == "") | (txOper.Text == "-"))
                    {
                        if (!fncCambiarOper())
                        {
                            sbrLimpia();
                        }
                    }
                }

            }
            string vImagen = cProducto.Articulo.fncTraeC("Imagen", vProd);
            if (vImagen != "") vImagen = cParamXml.DirImProd + @"\" + vImagen;
            try
            {
                picFoto.Image = null;
                picFoto.Load(vImagen);
            }
            catch { }


            lbCanProd.Text = cProduc.OF.fncTraeCanProd(cParamXml.Emp.ToString(), txOFL.Text).ToString();
            sbrCarga();
        }
        private void sbrLimpiaVerif()
        {
            tiFecha.Value = DateTime.Now;
            tiHora.Value = DateTime.Now;
            txNombre.Text = "";
            txVal.Text = "";
            txObs.Text = "";
            cbP1.Text = "";
            cbP2.Text = "";
            cbP3.Text = "";
            cbP4.Text = "";
            cbP5.Text = "";
            cbP6.Text = "";
            cbP7.Text = "";
            cbP8.Text = "";
            cbP9.Text = "";
            cbP10.Text = "";
            txIdVerif.Text = "";
            lbOper.Text = "";
        }
        private void sbrCargaLineaVerif(int vFil)
        {
            sbrLimpiaVerif();

            string vDia = grVerif.Rows[vFil].Cells["Dia"].Value.ToString();
            string vHora = grVerif.Rows[vFil].Cells["Hora"].Value.ToString();
            string vNombre = grVerif.Rows[vFil].Cells["Nombre"].Value.ToString();
            string vVal = grVerif.Rows[vFil].Cells["Val"].Value.ToString();
            string vObs = grVerif.Rows[vFil].Cells["Observaciones"].Value.ToString();
            string vP1 = grVerif.Rows[vFil].Cells["P1"].Value.ToString();
            string vP2 = grVerif.Rows[vFil].Cells["P2"].Value.ToString();
            string vP3 = grVerif.Rows[vFil].Cells["P3"].Value.ToString();
            string vP4 = grVerif.Rows[vFil].Cells["P4"].Value.ToString();
            string vP5 = grVerif.Rows[vFil].Cells["P5"].Value.ToString();
            string vP6 = grVerif.Rows[vFil].Cells["P6"].Value.ToString();
            string vP7 = grVerif.Rows[vFil].Cells["P7"].Value.ToString();
            string vP8 = grVerif.Rows[vFil].Cells["P8"].Value.ToString();
            string vP9 = grVerif.Rows[vFil].Cells["P9"].Value.ToString();
            string vP10 = grVerif.Rows[vFil].Cells["P10"].Value.ToString();
            string vId = grVerif.Rows[vFil].Cells["Id"].Value.ToString();


            tiFecha.Value = Convert.ToDateTime(vDia);
            tiHora.Value = Convert.ToDateTime(vHora);
            txNombre.Text = vNombre;
            txVal.Text = vVal;
            txObs.Text = vObs;
            txIdVerif.Text = vId;
            cbP1.Text = vP1;
            cbP2.Text = vP2;
            cbP3.Text = vP3;
            cbP4.Text = vP4;
            cbP5.Text = vP5;
            cbP6.Text = vP6;
            cbP7.Text = vP7;
            cbP8.Text = vP8;
            cbP9.Text = vP9;
            cbP10.Text = vP10;


            btCancel.Visible = true;

            return;
        }
        private void sbrBuscaNombre()
        {
            string vTabla = "GC_Operarios";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "IdOper", txNombre.Text, "", "", "", false, "", "", "", "SQL");

            if (vRes != "")
            {

                txNombre.Text = vRes;
                txNombre.Focus();
            }


        }
        public void sbrCreaExcel(DataTable dtb, string vNomHoja)
        {
            frmInformacion.vTexto = "Creando Hoja Excel";
            Form frm = new frmInformacion();
            frm.Show();
            Application.DoEvents();

            DataTable dtEx = dtb.DefaultView.ToTable();

            cOffice oOffice = new cOffice();

            oOffice.AbreExcel(false);
            Application.DoEvents();
            oOffice.Visible = false;
            Application.DoEvents();
            oOffice.CargaExcel(dtEx, 1);
            Application.DoEvents();
            if (vNomHoja != "")
            {
                oOffice.NombreHoja(vNomHoja);
            }
            oOffice.Visible = true;
            Application.DoEvents();

            oOffice.LimpiaExcel();
            Application.DoEvents();

            frm.Close();
            Application.DoEvents();


        }

        public void sbrImprimeEtiqueta(string vNumCaja, int vPiezasCaja)
        {

            string vWhere = " Empresa = " + cParamXml.Emp + " and IdOF ='" + txOFL.Text + "' ";
            string vCli = cUtil.fncTraeCampo("CodCli", "GC_OrdenProd", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", true);
            if (vCli == "***Inex***") vCli = "";
            string vProd = cUtil.fncTraeCampo("Articulo", "GC_OrdenProd", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", true);
            if (vProd == "***Inex***") vProd = "";
            string vProdcli = cUtil.fncTraeCampo("ArticuloCli", "GC_OrdenProd", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", true);
            if (vProdcli == "***Inex***") vProdcli = "";
            string vNomProd = cUtil.fncTraeCampo("Descripción", "GC_OrdenProd", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", true);
            if (vNomProd == "***Inex***") vNomProd = "";


            string vLogoCaja = cProducto.Articulo.fncTraeC("LogoCaja", vProd);
            bool vConLogo = true;
            if (vLogoCaja == "0") vConLogo = false;


            if (vCli == "")
            {
                string vTabla = "GC_ClienteProducto";
                vWhere = " Empresa =" + cParamXml.Emp + " and Producto ='" + vProd + "'";
                string vRes = cUtil.fncTraeCampo("CodCli", vTabla, vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", false);
                if (vRes != "")
                {
                    vCli = vRes;
                }

                vRes = cUtil.fncTraeCampo("ProductoCli", vTabla, vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", false);
                if (vRes != "")
                {
                    vProdcli = vRes;
                }


            }

            if (vProdcli == "")
            {
                string vTabla = "GC_ClienteProducto";
                vWhere = " Empresa =" + cParamXml.Emp + " and Producto ='" + vProd + "'";
                string vRes = cUtil.fncTraeCampo("ProductoCli", vTabla, vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", false);
                if (vRes != "")
                {
                    vProdcli = vRes;
                }

                vRes = cUtil.fncTraeCampo("CodCli", vTabla, vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", false);
                if (vRes != "")
                {
                    vCli = vRes;
                }

            }




            DataRow drCli;
            vWhere = " Empresa = " + cParamXml.Emp + " and codcli = '" + vCli + "' ";
            drCli = cUtil.fncTraeCampos("GC_ClienteProducto", vWhere, cParamXml.strConec, "SQL");

            string vEtiCli = "";
            string vEt = "";
            string vNomCli = "";
            if (drCli != null)
            {
                vEt = drCli["EtiCli"].ToString();
                if (vEt == "1")
                {
                    vEtiCli = drCli["EtiDes"].ToString();
                    vNomCli = drCli["NomCli"].ToString();
                    if (vEtiCli == "") vEtiCli = vNomCli;
                }
            }

            if (vNomCli == "")
            {
                string vTabla = "GC_ClienteProducto";
                vWhere = " Empresa =" + cParamXml.Emp + " and codcli ='" + vCli + "'";
                string vRes = cUtil.fncTraeCampo("NomCli", vTabla, vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", false);
                if (vRes != "")
                {
                    vNomCli = vRes;
                }

            }

            dtsEtiCaja dts = new dtsEtiCaja();
            DataTable dt = new DataTable();
            dt = dts.Tables["dtEtiCaja"].Clone();
            DataRow dr = dt.NewRow();

            dr.BeginEdit();
            dr["Producto"] = vProd;
            dr["Cliente"] = vNomCli;
            dr["Pieza"] = vProdcli;
            dr["DesProd"] = vNomProd;
            dr["Lote"] = txOFL.Text;
            dr["PiezasCaja"] = vPiezasCaja;
            dr["Fecha"] = DateTime.Now.ToShortDateString();
            dr["Operario"] = txOper.Text;
            dr["Caja"] = vNumCaja;
            dr["Imagen"] = cUtil.imageToByteArray(picFoto.Image);
            dr["EtiCliente"] = vEtiCli;
            dr.EndEdit();

            dt.Rows.Add(dr);


            int vAncho = 1;
            int vAlto = 1;
            if (picFoto.Image != null)
            {
                vAncho = picFoto.Image.Width;
                vAlto = picFoto.Image.Height;
            }

            cInformes.Imp = (cParamXml.Imp == "True") ? true : false;
            cInformes.sbrEtiCaja(dt, vAlto, vAncho, vEt,vConLogo);

        }

        private void sbrCargaMat(string vProd)
        {
            DataTable dt = cProducto.Articulo.fncProdMat(cParamXml.Emp, vProd, "1", Convert.ToInt32(cUtil.Piece(lbCan.Text,",",1)));

            grCompo.DataSource = null;
            grCompo.DataSource = dt.DefaultView;


        }




        #endregion
        private void txOFL_TextChanged(object sender, EventArgs e)
        {
            //if (txOFL.Text != "")
            //{
            //    sbrActuOFL();
            //}

        }

        private void btOFL_Click(object sender, EventArgs e)
        {
            sbrBuscaOFL();
        }
        private void btIni_Click(object sender, EventArgs e)
        {
            if (txOFL.Text == "")
            {
                MessageBox.Show("No se seleccionado una Orden de Producción");
                return;
            }
            sbrProduccion(!vEnProd);
        }
        private void frmProducción_KeyUp(object sender, KeyEventArgs e)
        {
            string vTecla = e.KeyCode.ToString();
            if (vTecla == "F5")
            {
                sbrBuscaOFL();
                e.Handled = true;
                //return;
            }
            if (vTecla == "F6")
            {
                sbrBuscaNombre();
                e.Handled = true;
                //return;
            }

            //vLectura += vTecla;

            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (vLectura != "")
            //    {
            //        if (vLectura.LastIndexOf("#") != -1)
            //        {
            //            string vtxOF = cUtil.Piece(txOFL.Text, "#", 1);
            //            string vTipo = cUtil.Piece(txOFL.Text, "#", 2);
            //            txOFL.Text = vtxOF;
            //        }
            //        vLectura = "";
            //        e.Handled = true;
            //    }

            //}



        }

        private void frmProducción_Load(object sender, EventArgs e)
        {
            
            cUtil.fncRecuperaEstado(this, "Producción");

            txOFL.Focus();
        }

        private void btLimpia_Click(object sender, EventArgs e)
        {
            sbrLimpia();
        }

        private void frmProducción_FormClosing(object sender, FormClosingEventArgs e)
        {
            cUtil.fncGuardaEstado(this);
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCAmbiar_Click(object sender, EventArgs e)
        {
            sbrLimpia();
            vEnProd = false;
            panel3.Enabled = !vEnProd;
            panel1.Enabled = vEnProd;

        }

        private void txOper_TextChanged(object sender, EventArgs e)
        {
            if (txOper.Text != "")
            {
                btCambiarOper.Visible = true;
            }
            else
            {
                btCambiarOper.Visible = false;

            }
        }

        private void btCambiarOper_Click(object sender, EventArgs e)
        {
            if (!fncCambiarOper())
            {
                sbrLimpia();
            }

        }

        private void btCambiarMaquina_Click(object sender, EventArgs e)
        {
            if (!fncCambiarMaq())
            {
                sbrLimpia();
            }

        }

        private void txMaq_TextChanged(object sender, EventArgs e)
        {
            if (txMaq.Text != "")
            {
                btCambiarMaquina.Visible = true;
            }
            else
            {
                btCambiarMaquina.Visible = false;

            }

        }

        private void btLote_Click(object sender, EventArgs e)
        {
            if (!fncLote())
            {
                
            }
        }

        private void btCaja_Click(object sender, EventArgs e)
        {
            if (txLote.Text == "")
            {
                MessageBox.Show("No se ha informado el Numero de Lote");
                return;
            }
            if (txOper.Text == "")
            {
                MessageBox.Show("No se ha informado del Operario");
                return;
            }
            if (txMaq.Text == "")
            {
                MessageBox.Show("No se ha informado de la Maquina");
                return;
            }


            //Busco Campos del Producto
            string vWhere = " Empresa = " + cParamXml.Emp + " and Producto = '" + vProd + "' ";
            DataRow drm = cUtil.fncTraeCampos("GC_ProductoAnexos", vWhere, cParamXml.strConecProduc_Prueb, "SQL");

            string vBolsa = "";
            int vPiezasBolsa = 0;
            string vCaja = "";
            int vPiezasCaja = 0;

            if (drm != null)
            {
                vBolsa = drm["Bolsa"].ToString();
                vPiezasBolsa = (int)drm["PiezasBolsa"];
                vCaja = drm["Caja"].ToString();
                vPiezasCaja = (int)drm["PiezasCaja"];
            }
            if (vBolsa != "")
            {
                if (vPiezasBolsa == 0)
                {
                    MessageBox.Show("Falta informar el Nº de piezas por Bolsa");
                    return;
                }
            }
            if (vCaja != "")
            {
                if (vPiezasCaja == 0)
                {
                    MessageBox.Show("Falta informar el Nº de piezas por Caja");
                    return;
                }
            }






            string vTipo = fncCerrarCajaBolsa();
            vNuevoLote = false;
            sbrCarga();
            sbrActuOFL();

            decimal vdCan = Convert.ToDecimal(lbCan.Text);
            decimal vdCanProd = Convert.ToDecimal(lbCanProd.Text);
            if (vdCan <= vdCanProd)
            {
                if (vTipo == "B")
                {
                    sbrCerrarCajaBolsas(false);

                }
                
                MessageBox.Show("Orden de Producción completa");

                cProduc.OF.fncCambiarEstado(cParamXml.Emp.ToString(), txOFL.Text, "Acabada");
                cProduc.OF.fncActuCampoOF(cParamXml.Emp.ToString(), txOFL.Text, "FechafIN", DateTime.Now.ToShortDateString());
                cProduc.OF.fncActuCampoOF(cParamXml.Emp.ToString(), txOFL.Text, "Maquina", txMaq.Text);
                cProduc.OF.fncBajaEnprod(cParamXml.Emp, txOFL.Text);
                sbrLimpia();
            }
        }

        private void btComent_Click(object sender, EventArgs e)
        {
            jControles.Formularios.frmControlGr frm = new jControles.Formularios.frmControlGr();
            frm.Tabla = "GC_OrdenProdComenProduc";
            frm.Where = "WHERE (Empresa = " + cParamXml.Emp + ") and IdOF ='" + txOFL.Text + "'";
            frm.SoloLectura = false;
            frm.CamposVis = "Comentario";
            frm.NoVisible = "Id,Empresa,IdOF";
            frm.TextoCab = "Comentario";
            frm.Titulo = "Comentarios Orden Producción : " + txOFL.Text;
            frm.Default = "Empresa,IdOF#" + cParamXml.Emp.ToString() + "," + txOFL.Text;
            frm.Conexion = cParamXml.strConec;
            frm.NoEdit = "";
            frm.ShowDialog();
            frm.Dispose();

            sbrCargaComentarios();

        }

        private void frmProducción_Shown(object sender, EventArgs e)
        {
            if (cUtil.fncExisteVentanaMDI((Form)this.MdiParent, "frmProducción",1))
            {
                MessageBox.Show("Ya existe una ventana de 'Producción' abierta");
                this.Close();
                return;

                //cUtil.fncCerrarVentanaMDI((Form)this.MdiParent, "frmProducción", true);

            }

        }

        private void btGrabar_Click(object sender, EventArgs e)
        {
            if (txNombre.Text == "")
            {
                MessageBox.Show("No se ha indicado un Nombre");
                return;
            }

            if (txIdVerif.Text == "")
            {
                if (cProduc.OF.fncAltaVerif(cParamXml.Emp, txOFL.Text, txObs.Text, tiFecha.Value.ToShortDateString(),
                                    tiHora.Value.ToShortTimeString(), lbOper.Text, cbP1.Text, cbP2.Text,
                                    cbP3.Text, cbP4.Text, cbP5.Text, cbP6.Text, cbP7.Text, cbP8.Text, cbP9.Text,
                                    cbP10.Text, txVal.Text))
                {
                }
            }
            else
            {
                string vId = txIdVerif.Text;
                cProduc.OF.fncGrabaCampoVerif(vId,"Dia" ,tiFecha.Value.ToShortDateString());
                cProduc.OF.fncGrabaCampoVerif(vId, "Hora", tiHora.Value.ToShortTimeString());
                cProduc.OF.fncGrabaCampoVerif(vId, "Nombre", txNombre.Text);
                cProduc.OF.fncGrabaCampoVerif(vId, "P1", cbP1.Text);
                cProduc.OF.fncGrabaCampoVerif(vId, "P2", cbP2.Text);
                cProduc.OF.fncGrabaCampoVerif(vId, "P3", cbP3.Text);
                cProduc.OF.fncGrabaCampoVerif(vId, "P4", cbP4.Text);
                cProduc.OF.fncGrabaCampoVerif(vId, "P5", cbP5.Text);
                cProduc.OF.fncGrabaCampoVerif(vId, "P6", cbP6.Text);
                cProduc.OF.fncGrabaCampoVerif(vId, "P7", cbP7.Text);
                cProduc.OF.fncGrabaCampoVerif(vId, "P8", cbP8.Text);
                cProduc.OF.fncGrabaCampoVerif(vId, "P9", cbP9.Text);
                cProduc.OF.fncGrabaCampoVerif(vId, "P10", cbP10.Text);
                cProduc.OF.fncGrabaCampoVerif(vId, "Val", txVal.Text);
                cProduc.OF.fncGrabaCampoVerif(vId, "Observaciones", txObs.Text);

            }

            sbrCargaVerif();
            sbrLimpiaVerif();

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            sbrLimpiaVerif();
        }

        private void grVerif_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            sbrCargaLineaVerif(e.RowIndex);
        }

        private void txNombre_TextChanged(object sender, EventArgs e)
        {
            if (txNombre.Text != "")
            {
                DataRow dr;
                string vWhere = " Empresa = " + cParamXml.Emp + " and IdOper = '" + txNombre.Text + "' ";
                dr = cUtil.fncTraeCampos("GC_Operarios", vWhere, cParamXml.strConecProduc_Prueb, "SQL");
                lbOper.Text = "";
                if (dr != null)
                {
                    lbOper.Text = dr["Nombre"].ToString();
                }
            }

        }

        private void btOper_Click(object sender, EventArgs e)
        {
            sbrBuscaNombre();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sbrCerrarCajaBolsas();
        }

        private void grVerif_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string vTab = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            if (vTab == "Verificaciones")
            {
                sbrformatogrVerif();
            }
        }

        private void btCrearExcel_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)(grVerif.DataSource);

            DataTable dt = dv.ToTable();          


            sbrCreaExcel(dt, "Verificaciones");

        }

        private void txOFL_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txOFL.Text != "")
                {
                    if (txOFL.Text.LastIndexOf("$") != -1)
                    {
                        string vtxOF = cUtil.Piece(txOFL.Text, "$", 1);
                        vTipoCierre = cUtil.Piece(txOFL.Text, "$", 2);
                        txOFL.Text = vtxOF;

                        sbrActuOFL();
                        if (vTipoCierre == "D")
                        {
                            sbrCerrarCajaBolsas();
                        }
                        else
                        {
                            btCaja_Click(btCaja, null);
                        }


                        sbrLimpia();
                        vEnProd = false;
                        panel3.Enabled = !vEnProd;
                        panel1.Enabled = vEnProd;
                        vTipoCierre = "";

                    }
                    else
                    {
                        sbrActuOFL();
                    }
                }

            }
        }

        private void grProduc_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            

            DataGridViewRow dr = e.Row;

            string vCanProd = dr.Cells["CanProd"].Value.ToString();
            string vCanMat = dr.Cells["CanMat"].Value.ToString();
            vProd = dr.Cells["Producto"].Value.ToString();
            string vLote = dr.Cells["Lote"].Value.ToString();
            string vMaterial = dr.Cells["Material"].Value.ToString();

            string vCodigo = dr.Cells["Codigo"].Value.ToString();
            vCodigo = vCodigo.Replace(".", ",");
            decimal vdCodigo = Convert.ToDecimal(vCodigo);

            string vTipo = dr.Cells["Tipo"].Value.ToString();
            string vId = dr.Cells["Id"].Value.ToString();
            int vdId = Convert.ToInt32(vId);


            //MessageBox.Show("borrando fila:" + dr.Index.ToString() + "  ID:" + dr.Cells["Id"].Value.ToString() + " - " + vCodigo);



            foreach(DataGridViewRow drg in grProduc.Rows)
            {
                string vCodigog = drg.Cells["Codigo"].Value.ToString();
                vCodigog = vCodigog.Replace(".", ",");
                decimal vdCodigog = Convert.ToDecimal(vCodigog);
                string vIdg = drg.Cells["Id"].Value.ToString();
                int vdIdg = Convert.ToInt32(vIdg);


                if (vdIdg > vdId)
                {
                    MessageBox.Show("No es la ultima Fila");
                    e.Cancel = true;
                    return;

                }

            }

            string vMen = "Se eliminara la Ultima Caja/Bolsa entrada. ¿Es correcto?";
            string vTit = "OF";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }


            e.Cancel = true;


            bool vMovis = false;
            if (vTipo == "B") vMovis = true;

            if (vTipo == "C")
            {
                vMovis = true;
                foreach (DataGridViewRow drg in grProduc.Rows)
                {
                    string vCodigog = drg.Cells["Codigo"].Value.ToString();
                    if (vCodigog.LastIndexOf(".") != -1)
                    {
                        vCodigog = cUtil.Piece(vCodigog, ".", 1);
                        decimal vdCodigog = Convert.ToDecimal(vCodigog);
                        if (vdCodigog == vdCodigo)
                        {
                            vMovis = false;

                        }
                    }

                }

            }


            //baja de la caja o bolsa
            if (cProduc.OF.fncBajaCajaBolsa(vId))
            {
                if (vMovis)
                {
                    decimal vdCanProd = Convert.ToDecimal(vCanProd.Replace(",", "."));
                    vCanProd = "-" + vCanProd;
                    //Actualizar la cantidad fabricada en la OF
                    cProduc.OF.fncMasCantidadFAb(cParamXml.Emp.ToString(), txOFL.Text, vCanProd);

                    //Crear movimientos de producto y materia prima
                    cMovimientos.Articulo oMov = new cMovimientos.Articulo();

                    //Movimiento de producto
                    oMov.fncAlta(cParamXml.Emp, "Salida", DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vProd, "Anulación Caja/bolsa",
                                    vCanProd, txOFL.Text, txOFL.Text, "FAB", vLote);

                    //Movimiento de Matprima
                    //Busco los materiales a utilizar en la producción de la pieza
                    DataTable dtMat = cProducto.Articulo.fncProdMat(cParamXml.Emp, vProd, "1");
                    int vCont = 1;
                    foreach (DataRow drM in dtMat.Rows)
                    {
                        vMat = drM["Material"].ToString();
                        vPeso = drM["Peso"].ToString();
                        decimal vdPeso = Convert.ToDecimal(vPeso.Replace(".", ","));

                        decimal vCanMate = vdCanProd * vdPeso / 1000;

                        string vLote0 = cUtil.Piece(vLote, "^", vCont);
                        //Movimiento de Matprima
                        oMov.fncAlta(cParamXml.Emp, "Entrada", DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vMat, "",
                                        vCanMate.ToString(), vProd, txOFL.Text, "PRODUC", vLote0);



                        vCont++;
                    }










                }
                sbrActuOFL();
            }
            else
            {
                MessageBox.Show("No se ha podido eliminar la Línea");
                e.Cancel = true;

            }

        }

        private void btAnex2_Click(object sender, EventArgs e)
        {
            if (fncSeguridad("",cParamXml.PassAnex))
            {
                if (vProd != "")
                {
                    frmProdAnexos frm = new frmProdAnexos();
                    frm.vProdExt = vProd;
                    frm.ShowDialog();
                }
            }


        }

        private void lbProd_TextChanged(object sender, EventArgs e)
        {
            if (lbProd.Text == "")
            {
                btAnex2.Visible = false;
            }
            else
            {
                btAnex2.Visible = true;

            }
        }

        private bool fncSeguridad()
        {
            return fncSeguridad("");
        }
        private bool fncSeguridad(string vTexto)
        {
            return fncSeguridad(vTexto,"");

        }
        private bool fncSeguridad(string vTexto,string vContra)
        {
            bool vOk = false;
            if (vContra == "") vContra = cParamXml.PassCan;
            if (vContra == "") vContra = "joselito";
            if (vContra != "")
            {
                Form frm = new frmContraseña();
                frmContraseña.vContra = vContra;
                frmContraseña.vTexto = vTexto;
                frm.ShowDialog();

                vOk = frmContraseña.vOk;
            }

            if (!vOk)
            {
                MessageBox.Show("contraseña Erronea");
            }

            return vOk;
        }


        private void btBlockMOlde_Click(object sender, EventArgs e)
        {
            if (txMolde.Text == "")
            {
                MessageBox.Show("No hay molde para bloquear");
                return;
            }



            string vMen = "Se bloqueara el molde ,¿Es correcto?";
            string vTit = "OF";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            if (!fncSeguridad())
            {
                MessageBox.Show("Sin Permiso");
                return;
            }

            cProduc.Moldes.fncActuCampoMoldes(cParamXml.Emp.ToString(), txMolde.Text, "Bloqueado", "1");

            sbrProduccion(!vEnProd);

        }


    }
}
