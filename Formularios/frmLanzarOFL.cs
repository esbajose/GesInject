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


namespace GesInject.Formularios
{
    public partial class frmLanzarOFL : Form
    {
        public frmLanzarOFL()
        {
            InitializeComponent();
        }


        #region Procesos locales
        private void sbrCargar()
        {
            try
            {
                string vSql = cConstantes.SQL_OFL_Planif;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());



                DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

                grOFL.DataSource = null;

                grOFL.DataSource = dt.DefaultView;

                if (dt.Rows.Count != 0)
                {

                }

                sbrFormatoGr();
            }
            catch { }
        }

        private void sbrMarcarTodo(bool vMarcar)
        {
            foreach (DataGridViewRow dr in grOFL.Rows)
            {
                try
                {
                    if (dr.Visible)
                    {
                        dr.Cells["Sel"].Value = vMarcar;
                    }
                }
                catch { }
            }
        }
        private void sbrLimpiar()
        {
            foreach (DataGridViewRow dr in grOFL.Rows)
            {
                try
                {
                    if (dr.Visible)
                    {
                        dr.Cells["Sel"].Value = false;
                        dr.DefaultCellStyle.BackColor = Color.White;
                    }
                }
                catch { }
            }

            grMat.DataSource = null;
        }

        
        private void sbrFormatoGr()
        {
            foreach(DataGridViewColumn dl in grOFL.Columns)
            {
                dl.Visible = false;
            }

            grOFL.Columns["Sel"].Visible = true;

            grOFL.Columns["IdOF"].Visible = true;
            grOFL.Columns["IdOF"].Width = 100;

            grOFL.Columns["Articulo"].Visible = true;
            grOFL.Columns["Articulo"].Width = 100;

            grOFL.Columns["Descripción"].Visible = true;
            grOFL.Columns["Descripción"].Width = 200;

            grOFL.Columns["ArticuloCli"].Visible = true;
            grOFL.Columns["ArticuloCli"].Width = 100;

            grOFL.Columns["Cantidad"].Visible = true;
            grOFL.Columns["Cantidad"].Width = 100;


        }

        private bool fncProcesar()
        {
            bool vOk = true;

            //Recojo todas la necesidades de componente y su Stock Libre  /////////////////////////////////////////////////////
            string vSql = cConstantes.SQL_OFL_Calc;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?Alm]", cParamXml.AlmacenMat);

            string vOFLs = "";
            foreach (DataGridViewRow dr in grOFL.Rows)
            {
                string vSel = "";
                string vOFL = "";
                string vCan = "";
                if (dr.Cells[0].Value !=null) vSel = dr.Cells[0].Value.ToString();
                if (dr.Cells["IdOF"].Value != null) vOFL = dr.Cells["IdOF"].Value.ToString();
                if (dr.Cells["Cantidad"].Value != null) vCan = dr.Cells["Cantidad"].Value.ToString();

                if (vSel == "True")
                {
                    //Recojo todas la necesidades de material

                    vOFLs += "(OFL.IdOF = N'" + vOFL + "') or " + cConstantes.vbCtr + cConstantes.vbLF;
                    Application.DoEvents();

                }

            }

            if (vOFLs != "")
            {
                vOFLs = " and (" + vOFLs.Substring(0, vOFLs.Length - 6) + ")";
            }
            else
            {
                MessageBox.Show("No se seleccionado ninguna OFL");
                return vOk;
            }

            vSql += vOFLs;
            vSql += " group by OFL.Empresa,Material " + cConstantes.vbCtr + cConstantes.vbLF;

            DataTable dtNece = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));

            ////////////////////////////////////////////////////////////////////////////////////////////////////////


            ////Limpio la lista de la OFL a lanzar
            foreach (DataGridViewRow dr in grOFL.Rows)
            {
                dr.DefaultCellStyle.BackColor = Color.White;
            }
            Application.DoEvents();

            ////Recorro la lista de la OFL a lanzar
            foreach (DataGridViewRow dr in grOFL.Rows)
            {
                string vSel = "";
                string vOFL = "";
                string vCan = "";
                string vProd = "";
                if (dr.Cells[0].Value != null) vSel = dr.Cells[0].Value.ToString();
                if (dr.Cells["IdOF"].Value != null) vOFL = dr.Cells["IdOF"].Value.ToString();
                if (dr.Cells["Cantidad"].Value != null) vCan = dr.Cells["Cantidad"].Value.ToString();
                if (dr.Cells["Articulo"].Value != null) vProd = dr.Cells["Articulo"].Value.ToString();

                if (vSel == "True")
                {
                    //Busco el Peso de la pieza
                    //string vWhere = " Empresa = " + cParamXml.Emp + " and Producto = N'" + vProd + "'";
                    //string vPeso = cUtil.fncTraeCampo("PesoNeto", "GC_ProductoAnexos", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", true);
                    //if (vPeso == "***Inex***")
                    //{
                    //    vPeso = "0";
                    //}

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

                    //Busco los materiales a utilizar en la producción de la pieza
                    string vMateriales = "";
                    DataTable dtMat = cProducto.Articulo.fncProdMat(cParamXml.Emp, vProd, "1");
                    foreach (DataRow drM in dtMat.Rows)
                    {
                        string vMat = drM["Material"].ToString();
                        string vPeso = drM["Peso"].ToString();
                        decimal vdPeso = Convert.ToDecimal(vPeso.Replace(".", ","));
                        if (vdPeso == 0)
                        {
                            //Se cambia el color a Marron y se desmarca
                            dr.DefaultCellStyle.BackColor = Color.Brown;
                            dr.Cells["Sel"].Value = false;
                        }

                        if (vCan == "") vCan = "0";

                        decimal vdCan = Convert.ToDecimal(vCan.Replace(".", ","));
                        decimal vCanMat = vdCan * vdPeso / 1000;

                        //Busco el material en el Datatable del stock de necesidades
                        DataRow[] BusRows;
                        BusRows = dtNece.Select("Material = '" + vMat + "'");
                        if (BusRows.Length > 0)
                        {
                            decimal vCanStock = Convert.ToDecimal(BusRows[0]["Stock"].ToString().Replace(".", ","));
                            decimal vCanNece = Convert.ToDecimal(BusRows[0]["NeceTot"].ToString().Replace(".", ","));
                            decimal vCanAct = Convert.ToDecimal(BusRows[0]["NeceAct"].ToString().Replace(".", ","));
                            decimal vLibre = vCanStock - vCanNece;
                            if (vLibre >= vCanMat)
                            {
                                if (vCanMat != 0)
                                {
                                    vCanNece += vCanMat;
                                    BusRows[0]["NeceTot"] = vCanNece;
                                    vMateriales = vMat + "#" + vCanMat.ToString() + "|";
                                    //Se cambia el color a Verde 
                                    if (dr.DefaultCellStyle.BackColor != Color.Red)
                                    {
                                        dr.DefaultCellStyle.BackColor = Color.Green;
                                        vOk = true;
                                    }
                                }
                            }
                            else
                            {
                                //Se cambia el color a Rojo y se desmarca
                                dr.DefaultCellStyle.BackColor = Color.Red;
                                dr.Cells["Sel"].Value = false;

                                //En el caso de que solo Material NO tenga stock se anulan todos
                                string[] vMats = vMateriales.Split('|');
                                for (int i = 0; i < vMats.Length; i++)
                                {
                                    string vM = cUtil.Piece(vMats[i], "#", 1);
                                    string vc = cUtil.Piece(vMats[i], "#", 2);
                                    if (vM != "")
                                    {
                                        decimal vdc = Convert.ToDecimal(vc.Replace(".", ","));
                                        DataRow[] BusRows2;
                                        BusRows2 = dtNece.Select("Material = '" + vM + "'");
                                        if (BusRows2.Length > 0)
                                        {
                                            vCanNece = Convert.ToDecimal(BusRows2[0]["NeceTot"].ToString().Replace(".", ","));
                                            vCanNece -= vdc;
                                            BusRows2[0]["NeceTot"] = vCanNece;
                                        }
                                    }
                                }

                            }
                            BusRows[0]["NeceAct"] = vCanAct + vCanMat;
                        }

                    }

                    if (vBolsa != "")
                    {
                        if (vPiezasBolsa == 0)
                        {
                            //Se cambia el color a Amarillo y se desmarca
                            dr.DefaultCellStyle.BackColor = Color.Yellow;
                            dr.Cells["Sel"].Value = false;
                        }
                    }
                    if (vCaja != "")
                    {
                        if (vPiezasCaja == 0)
                        {
                            //Se cambia el color a Azul y se desmarca
                            dr.DefaultCellStyle.BackColor = Color.Aqua;
                            dr.Cells["Sel"].Value = false;
                        }
                    }


                    Application.DoEvents();

                }

            }

            grMat.DataSource = null;
            grMat.DataSource = dtNece.DefaultView;


            return vOk;
        }

        private bool fncLanzarOFL()
        {
            bool vOk = true;

            ////Recorro la lista de la OFL a lanzar
            foreach (DataGridViewRow dr in grOFL.Rows)
            {
                string vSel = "";
                string vOFL = "";
                string vCan = "";
                string vProd = "";
                if (dr.Cells[0].Value != null) vSel = dr.Cells[0].Value.ToString();
                if (dr.Cells["IdOF"].Value != null) vOFL = dr.Cells["IdOF"].Value.ToString();
                if (dr.Cells["Cantidad"].Value != null) vCan = dr.Cells["Cantidad"].Value.ToString();
                if (dr.Cells["Articulo"].Value != null) vProd = dr.Cells["Articulo"].Value.ToString();

                if (vSel == "True")
                {
                    ////Busco el Peso de la pieza
                    //string vWhere = " Empresa = " + cParamXml.Emp + " and Producto = N'" + vProd + "'";
                    //string vPeso = cUtil.fncTraeCampo("PesoNeto", "GC_ProductoAnexos", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", true);
                    //if (vPeso == "***Inex***")
                    //{
                    //    vPeso = "0";
                    //}

                    //Busco los materiales a utilizar en la producción de la pieza
                    DataTable dtMat = cProducto.Articulo.fncProdMat(cParamXml.Emp, vProd, "1");
                    foreach (DataRow drM in dtMat.Rows)
                    {
                        string vMat = drM["Material"].ToString();
                        string vPeso = drM["Peso"].ToString();

                        decimal vdCan = Convert.ToDecimal(vCan.Replace(".", ","));
                        decimal vdPeso = Convert.ToDecimal(vPeso.Replace(".", ","));
                        decimal vdPen = vdCan * vdPeso / 1000;

                        bool vok2= cProduc.OF.fncLanzaOF(cParamXml.Emp, vOFL,vMat, vdPeso,vdCan,vdPen, cParamXml.AlmacenMat);
                        if (vok2)
                        {
                            cInformes.Imp = (cParamXml.Imp == "True") ? true : false;
                            cInformes.sbrPrintOFL(cParamXml.Emp.ToString(), vOFL);


                        }

                    }
                    



                }

            }


            sbrCargar();

            return vOk;
        }

        #endregion

        private void frmLanzarOFL_Load(object sender, EventArgs e)
        {
            sbrCargar();

            cUtil.fncRecuperaEstado(this, "Lanzar Ordenes");
        }

        private void btSelTot_Click(object sender, EventArgs e)
        {
            string vMen = "¿Marcar todos los registros?";
            string vTit = "Lanzar OFL";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sbrMarcarTodo(true);
            }

        }

        private void btDesSelTot_Click(object sender, EventArgs e)
        {
            string vMen = "¿Desmarcar todos los registros?";
            string vTit = "Lanzar OFL";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sbrLimpiar();
                //sbrMarcarTodo(false);
            }

        }

        private void frmLanzarOFL_FormClosing(object sender, FormClosingEventArgs e)
        {
            cUtil.fncGuardaEstado(this);

        }

        private void btProcesar_Click(object sender, EventArgs e)
        {
            string vMen = "¿Procesar la OFLs selecionadas? " + cConstantes.vbCtr + cConstantes.vbLF;
            string vTit = "Lanzar OFL";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            if (!fncProcesar())
            {
                return;
            }
            btLanzar.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sbrLimpiar();
        }

        private void btLanzar_Click(object sender, EventArgs e)
        {
            string vMen = "¿Lanzar las OFLs selecionadas? " + cConstantes.vbCtr + cConstantes.vbLF;
            string vTit = "Lanzar OFL";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            if (!fncProcesar())
            {
                return;
            }

            fncLanzarOFL();

        }

        private void btEntraStock_Click(object sender, EventArgs e)
        {

            string vProd = "";
            try { vProd = grMat.Rows[grMat.CurrentCell.RowIndex].Cells["Material"].Value.ToString(); }
            catch { }
            if (vProd != "")
            {
                frmMoviStock frm = new frmMoviStock();
                frm.vProd = vProd;
                frm.ShowDialog();
            }

        }

        private void btAnex_Click(object sender, EventArgs e)
        {
            string vProd = "";
            try { vProd = grMat.Rows[grMat.CurrentCell.RowIndex].Cells["Material"].Value.ToString(); }
            catch { }
            if (vProd != "")
            {
                frmProdAnexos frm = new frmProdAnexos();
                frm.vProdExt = vProd;
                frm.ShowDialog();
            }

        }

        private void btAnex2_Click(object sender, EventArgs e)
        {
            string vProd = "";
            try { vProd = grOFL.Rows[grOFL.CurrentCell.RowIndex].Cells["Articulo"].Value.ToString(); }
            catch { }
            if (vProd != "")
            {
                frmProdAnexos frm = new frmProdAnexos();
                frm.vProdExt = vProd;
                frm.ShowDialog();
            }

        }

        private void btOFL_Click(object sender, EventArgs e)
        {
            string vOF = "";
            try { vOF = grOFL.Rows[grOFL.CurrentCell.RowIndex].Cells["IdOF"].Value.ToString(); }
            catch { }
            if (vOF != "")
            {
                frmOF frm = new frmOF();
                frm.vOFExt = vOF;
                frm.ShowDialog();
            }

        }
    }
}
