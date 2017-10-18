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
using GesInject.Datasets;
using jControles.Clases;
using System.Data.SqlClient;

namespace GesInject.Formularios
{
    public partial class frmEntregaMerc : Form
    {


        public string vProd="";
        public string vDes="";
        public int vNumPrep = 0;
        public int vLin = 0;

        public int vNumPed = 0;
        public int vLinPed = 0;


        public decimal vCanOrig = 0;
        public decimal vCanGrab = 0;
        
        private decimal vDispo = 0;
        private cEntregas.CabPrepEntrega oCab = new cEntregas.CabPrepEntrega();
       


        #region Procesos Locales

        private decimal fncTraeStock(string vProducto)
        {
            decimal vStock = 0;

            string vWhere = "  (Producto = N'" + vProducto + "') AND (Empresa = 1) AND (Almacen = N'Principal')";
            string vCan = cUtil.fncTraeCampo("Cantidad", "GC_Ind_ProductoCan", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", false);
            if (vCan == "") vCan = "0";

            vStock = Convert.ToDecimal(vCan);

            vDispo = vStock;


            return vStock;
        }
        private decimal fncTraeStockUbi(string vProducto,string vUbi)
        {
            decimal vStock = 0;

            string vWhere = " (Empresa = " + cParamXml.Emp.ToString() + ") AND (Almacen = N'Principal') AND  (Producto = N'" + vProducto + "') AND (Cantidad > 0) AND (Ubi = N'" + vUbi + "')";
            string vCan = cUtil.fncTraeCampo("Cantidad", "GC_Ind_ProductoUbiCan", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", false);
            if (vCan == "") vCan = "0";

            vStock = Convert.ToDecimal(vCan);

            vDispo = vStock;


            return vStock;
        }
        private decimal fncTraeStockUbiLote(string vProducto, string vUbi,string vLote)
        {
            decimal vStock = 0;


            string vWhere = " (Empresa = " + cParamXml.Emp.ToString() + ") AND (Almacen = N'Principal') AND  (Producto = N'" + vProducto + "') AND (Cantidad > 0) AND (Ubi = N'" + vUbi + "')  AND (Lote = N'" + vLote + "')";
            string vCan = cUtil.fncTraeCampo("Cantidad", "GC_Ind_ProductoUbiCanLote", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", false);
            if (vCan == "") vCan = "0";

            vStock = Convert.ToDecimal(vCan);

            vDispo = vStock;


            return vStock;
        }
        private decimal fncTraeStockUbiLoteOFL(string vProducto, string vUbi, string vLote,string vOFL)
        {
            decimal vStock = 0;


            string vWhere = " (Empresa = " + cParamXml.Emp.ToString() + ") AND (Almacen = N'Principal') AND  (Producto = N'" + vProducto + "') AND (Cantidad > 0) AND (Ubi = N'" + vUbi + "')  AND (Lote = N'" + vLote + "' AND (OFL = N'" + vOFL + "'))";
            string vCan = cUtil.fncTraeCampo("Cantidad", "GC_Ind_ProductoUbiCanLoteOFL", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", false);
            if (vCan == "") vCan = "0";

            vStock = Convert.ToDecimal(vCan);

            vDispo = vStock;


            return vStock;
        }
        private bool fncEntregar(string vProducto, string vUbi, string vLote, decimal vCan, string vCajas,string vOFL)
        {
            bool vOk = false;

            using (SqlConnection dbConec = new SqlConnection(cParamXml.strConecProduc_Prueb))
            {
                dbConec.Open();
                SqlTransaction dbTr = dbConec.BeginTransaction();
                try
                {
                    //Damos de alta la cabecera
                    cAlbaranesVenta.CabAlb oCabAlb = new cAlbaranesVenta.CabAlb();
                    int vNumAlb = 0;
                    if (oCabAlb.fncAltaCab(oCab, "S", dbConec, dbTr,ref vNumAlb))
                    {
                        //Damos de alta la linea
                        cAlbaranesVenta.LinAlb oLinAlb = new cAlbaranesVenta.LinAlb();
                        oLinAlb.Empresa = cParamXml.Emp;
                        oLinAlb.NumAlb = vNumAlb;
                        oLinAlb.Producto = vProd;
                        oLinAlb.Descripción = txDesProd.Text;
                        oLinAlb.Cantidad = vCan;
                        string vLoteOfl = vLote;
                        if (vOFL != "") vLoteOfl += " | " + vOFL;
                        oLinAlb.Lote = vLoteOfl;
                        oLinAlb.Cajas = vCajas;
                        oLinAlb.Impresiones = 0;
                        oLinAlb.NumPrep = vNumPrep;
                        if (oLinAlb.fncAltaLin(dbConec,dbTr))
                        {
                            //Grabamos la cantridad entregada de la preparación
                            if (cEntregas.LinPrepEntregas.fncMasCantidadServida(cParamXml.Emp.ToString(),vNumPrep,vLin,vCan.ToString(),dbConec,dbTr))
                            {
                                //Si la entrega es de un pedido de modifica la cantidad entregada del pedido
                                if (vNumPed != 0)
                                {
                                    if (!cPedidosVenta.LinVenta.fncMasCantidadServida(cParamXml.Emp.ToString(),vNumPed,vLinPed,vCan.ToString(),dbConec,dbTr))
                                    {
                                        return vOk;
                                    }
                                }
                                //Movimientos de Producto
                                cMovimientos.Articulo oMov = new cMovimientos.Articulo();
                                decimal vdCan = vCan * -1;
                                if (oMov.fncAlta(cParamXml.Emp, "Salida", DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vProd, txDesProd.Text,
                                                vdCan.ToString(), vNumPrep.ToString(),vOFL, vUbi, vLote))
                                {
                                    vOk = true;
                                }                                
                            }
                        }
                    }

                    //Descactivamos las cajas seleccionadas
                    if ((vCajas != "")&(vOFL !=""))
                    {
                        string[] vmCajas = vCajas.Split(',');
                        for (int i = 0; i < vmCajas.Length; i++)
                        {
                            string vSql = "";
                            string vTabla = " GC_OrdenProdCajas";
                            string vCampo = "Entregada";
                            string vWhere = " IdOF = '" + vOFL + "' AND (NumCajaBolsa = " + vmCajas[i] + ")";
                            vSql = cConstantes.SQL_UP_Update;
                            vSql = vSql.Replace("[?1]", "[" + vCampo + "]");
                            vSql = vSql.Replace("[?2]", "1");
                            vSql = vSql.Replace("[?3]", vWhere);
                            vSql = vSql.Replace("[?99]", vTabla);
                            int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);

                        }
                    }



                }
                catch{}

                if (vOk)
                {
                    //Al terminar correctamente los cambios se graban
                    dbTr.Commit();
                    vOk = true;
                }
                else
                {
                    //Al terminar con error se revierten los cambios
                    dbTr.Rollback();
                    vOk = false;
                }


            }


            return vOk;
        }


        private void sbrCargaCajas(string vOFL)
        {
            string vSql = cConstantes.SQL_CajasOF_Lista;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?OFL]", vOFL);
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

            grLista.DataSource = null;
            grLista.DataSource = dt.DefaultView;

            sbrformatogrLista();
        }


        private void sbrformatogrLista()
        {
            string vFCampo = "";
            string vFor = "";
            vFCampo = "Sel";
            vFor = "ch#";
            cUtil.sbrAgregaColumn(ref grLista, vFor, vFCampo);

            grLista.Columns["Sel"].Width = 50;
            grLista.Columns["Caja"].Width = 50;

        }

        #endregion

        public frmEntregaMerc()
        {
            InitializeComponent();
        }

        private void frmEntregaMerc_Load(object sender, EventArgs e)
        {
            if (vProd == "")
            {
                MessageBox.Show("No se ha seleccionado un Producto");
                this.Close();
                return;
            }

            lbProd.Text = vProd;
            txDesProd.Text = vDes;

            decimal vStock = fncTraeStockUbi(vProd,"");
            lbDisp.Text = string.Format("{0:n2}", vStock);

            oCab.fncTrae(vNumPrep);


        }

        private void btUbi_Click(object sender, EventArgs e)
        {
            string vTabla = "GC_Ubicaciones";


            string vSql = cConstantes.SQL_Prod_Ubi;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?Prod]", vProd);

            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "Ubi", txUbi.Text, "", vSql, "", false, "", "", "", "SQL");

            if (vRes != "")
            {
                txUbi.Text = vRes;

            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {

            vCanGrab = 0;
            this.Close();
        }

        private void txCan_TextChanged(object sender, EventArgs e)
        {
            if (txCan.Text != "0")
            {
                decimal vdCan = 0;
                if (txCan.Text != "") vdCan = Convert.ToDecimal(txCan.Text);

                if (vdCan > vDispo)
                {
                    MessageBox.Show("La cantidad no puede ser superior a la disponible");
                    txCan.Text = string.Format("{0:n2}",vDispo);
                    return;
                }


            }
        }

        private void txUbi_TextChanged(object sender, EventArgs e)
        {
            decimal vStock = fncTraeStockUbi(vProd, txUbi.Text);
            lbDisp.Text = string.Format("{0:n2}", vStock);
        }

        private void txLote_TextChanged(object sender, EventArgs e)
        {
            if (txLote.Text != "")
            {
                decimal vStock = 0;
                if (lbOFL.Text != "")
                {
                    vStock = fncTraeStockUbiLoteOFL(vProd, txUbi.Text, txLote.Text,lbOFL.Text);
                    lbDisp.Text = string.Format("{0:n2}", vStock);
                }
                else
                {
                    vStock = fncTraeStockUbiLote(vProd, txUbi.Text, txLote.Text);
                    lbDisp.Text = string.Format("{0:n2}", vStock);

                }
            }

        }

        private void btLote_Click(object sender, EventArgs e)
        {

            lbOFL.Text = "";

            string vSql = cConstantes.SQL_Prod_Ubi_Lote_OFL;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?Prod]", vProd);

            if (txUbi.Text != "")
            {
                vSql += " and (Ubi = '" + txUbi.Text + "') ";
            }


            string vRes = cUtil.fncLista("GC_Ind_ProductoUbiCanLoteOFL", cParamXml.strConecProduc_Prueb, "Lote", txLote.Text, "", vSql, "", true, "", "", "", "SQL");

            if (vRes != "")
            {
                string vUbi = cUtil.Piece(vRes, "#", 2);
                string vOFL = cUtil.Piece(vRes, "#", 4);
                lbOFL.Text = vOFL;
                txUbi.Text = vUbi;
                txLote.Text = cUtil.Piece(vRes, "#", 1);


                sbrCargaCajas(vOFL);

            }



        }

        private void btEntregar_Click(object sender, EventArgs e)
        {
            decimal vdCan=Convert.ToDecimal(txCan.Text);
            if (fncEntregar(vProd, txUbi.Text, txLote.Text, vdCan,txCajas.Text,lbOFL.Text))
            {
                vCanGrab = vdCan;
                this.Close();
            }
            else
            {
                MessageBox.Show("Se ha producido un error al grabar la entrega");
                return;
            }
        }

        private void grLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string vCampo = grLista.Columns[e.ColumnIndex].Name;
            //string vValor = grLista[e.ColumnIndex, e.RowIndex].Value.ToString();

            //if (vCampo == "Sel")
            //{
            //    string vCan = grLista["Cantidad", e.RowIndex].Value.ToString();
            //    decimal vdCan = Convert.ToDecimal(vCan);

            //    string vCanT = txCan.Text;
            //    decimal vdCanT = Convert.ToDecimal(vCanT);

            //    decimal vCanR = 0;
            //    if (vValor == "0") vCanR = vdCanT + vdCan;
            //    if (vValor == "1") vCanR = vdCanT - vdCan;
            //    if (vdCanT < 0) vdCanT = 0;


            //    string vDis = lbDisp.Text;
            //    decimal vdDis = Convert.ToDecimal(vDis);


            //    if (vCanR > vdDis)
            //    {

            //        MessageBox.Show("La cantidad seleccionada supera lo disponible");
            //        grLista[e.ColumnIndex, e.RowIndex].Value = 0;
            //        return;
            //    }

            //    txCan.Text = vCanR.ToString();


            //}

        }

        private void grLista_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //string vCampo = grLista.Columns[e.ColumnIndex].Name;
            //string vValor = grLista[e.ColumnIndex, e.RowIndex].Value.ToString();

            //if (vCampo == "Sel")
            //{

            //    decimal vCanR = 0;
            //    foreach (DataGridViewRow dr in grLista.Rows)
            //    {
            //        try
            //        {
            //            vValor = dr.Cells[0].Value.ToString();
            //            string vCaja = dr.Cells["Caja"].Value.ToString();

            //            if (vValor == "1")
            //            {
            //                string vCan = dr.Cells["Cantidad"].Value.ToString();
            //                decimal vdCan = Convert.ToDecimal(vCan);

            //                vCanR += vdCan;
            //            }
            //        }
            //        catch { }
            //    }


            //    //string vCan = grLista["Cantidad", e.RowIndex].Value.ToString();
            //    //decimal vdCan = Convert.ToDecimal(vCan);

            //    //string vCanT = txCan.Text;
            //    //decimal vdCanT = Convert.ToDecimal(vCanT);

            //    //decimal vCanR = 0;
            //    //if (vValor == "0") vCanR = vdCanT + vdCan;
            //    //if (vValor == "1") vCanR = vdCanT - vdCan;
            //    //if (vdCanT < 0) vdCanT = 0;


            //    string vDis = lbDisp.Text;
            //    decimal vdDis = Convert.ToDecimal(vDis);


            //    if (vCanR > vdDis)
            //    {

            //        MessageBox.Show("La cantidad seleccionada supera lo disponible");
            //        e.Cancel = true;
            //        return;
            //    }

            //    txCan.Text = vCanR.ToString();


            //}
        }

        private void grLista_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            string vCampo = grLista.Columns[e.ColumnIndex].Name;
            string vValor = grLista[e.ColumnIndex, e.RowIndex].Value.ToString();

            if (vCampo == "Sel")
            {
                string vCajas = "";
                decimal vCanR = 0;
                foreach (DataGridViewRow dr in grLista.Rows)
                {
                    try
                    {
                        vValor = dr.Cells[0].Value.ToString();
                        string vCaja = dr.Cells["Caja"].Value.ToString();

                        if (vValor == "1")
                        {
                            string vCan = dr.Cells["Cantidad"].Value.ToString();
                            decimal vdCan = Convert.ToDecimal(vCan);

                            vCanR += vdCan;
                            vCajas += vCaja + ",";


                        }
                    }
                    catch { }
                }


                //string vCan = grLista["Cantidad", e.RowIndex].Value.ToString();
                //decimal vdCan = Convert.ToDecimal(vCan);

                //string vCanT = txCan.Text;
                //decimal vdCanT = Convert.ToDecimal(vCanT);

                //decimal vCanR = 0;
                //if (vValor == "0") vCanR = vdCanT + vdCan;
                //if (vValor == "1") vCanR = vdCanT - vdCan;
                //if (vdCanT < 0) vdCanT = 0;


                string vDis = lbDisp.Text;
                decimal vdDis = Convert.ToDecimal(vDis);


                if (vCanR > vdDis)
                {

                    MessageBox.Show("La cantidad seleccionada supera lo disponible");
                    e.Cancel = true;
                    return;
                }
                if (vCajas != "") vCajas = vCajas.Substring(0, vCajas.Length - 1);

                txCajas.Text = vCajas;

                txCan.Text = vCanR.ToString();


            }
        }
    }
}
