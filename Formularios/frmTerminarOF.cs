using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using GesInject.Clases;
using jControles.Clases;


namespace GesInject.Formularios
{
    public partial class frmTerminarOF : Form
    {
        public frmTerminarOF()
        {
            InitializeComponent();
        }


        #region Procesos locales
        private void sbrCargar()
        {
            int vFil = 0;

            try { vFil = grOFL.CurrentCell.RowIndex ; }
            catch { }


            //string vTodas = " and (GC_OrdenProd.CantidadFab = GC_OrdenProd.Cantidad) ";
            string vTodas = "";

            string vSql = cConstantes.SQL_Terminar_OF;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?Todas]", vTodas);



            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

            grOFL.DataSource = null;

            grOFL.DataSource = dt.DefaultView;

            if (dt.Rows.Count != 0)
            {

            }

            sbrFormatoGr();

            try { grOFL.CurrentCell = this.grOFL["IdOF", vFil]; }
            catch { }
        }

        private DataRow sbrCargarOF(string vOF)
        {
            DataRow dr=null;

            string vSql = cConstantes.SQL_Terminar_OF_2;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?OF]", vOF);



            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

            if (dt.Rows.Count > 0) dr = dt.Rows[0];

            return dr;
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

        }


        private void sbrFormatoGr()
        {
            foreach (DataGridViewColumn dl in grOFL.Columns)
            {
                dl.ReadOnly = true;
            }

            grOFL.Columns["Sel"].Visible = false;
            grOFL.Columns["Sel"].ReadOnly = true;

            grOFL.Columns["Id"].Visible = false;
            grOFL.Columns["Empresa"].Visible = false;
            grOFL.Columns["Operario"].Visible = false;
            grOFL.Columns["Maquina"].Visible = false;
            grOFL.Columns["CodCli"].Visible = false;
            grOFL.Columns["FechaEntrega"].Visible = false;
            grOFL.Columns["FechaInicio"].Visible = false;
            grOFL.Columns["FechaFin"].Visible = false;
            grOFL.Columns["Lote"].Visible = false;

            grOFL.Columns["IdOF"].Visible = true;
            grOFL.Columns["IdOF"].Width = 70;
            
            grOFL.Columns["Estado"].Visible = true;
            grOFL.Columns["Estado"].Width = 70;

            grOFL.Columns["Articulo"].Visible = true;
            grOFL.Columns["Articulo"].Width = 100;

            grOFL.Columns["Descripción"].Visible = true;
            grOFL.Columns["Descripción"].Width = 200;

            grOFL.Columns["ArticuloCli"].Visible = true;
            grOFL.Columns["ArticuloCli"].Width = 100;

            grOFL.Columns["Cantidad"].Visible = true;
            grOFL.Columns["Cantidad"].Width = 100;

            grOFL.Columns["PiezasNoOk"].HeaderText = "Sobrante";
            
        }

        private bool fncTerminarOFL(string vLote,string vUbiPie,string vLotePie)
        {
            bool vOk = true;
           
            ////Recorro la lista de la OFL a Cerrar
            foreach (DataGridViewRow dr in grOFL.Rows)
            {
                string vOFL = dr.Cells["IdOF"].Value.ToString();
                if (vOFL == txOF.Text)
                {

                    string vTodas = " and (GC_OrdenProd.IdOF = '"+ vOFL + "') ";

                    string vSql = cConstantes.SQL_Terminar_OF;
                    vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                    vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                    vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                    vSql = vSql.Replace("[?Todas]", vTodas);

                    DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

                    string vProd = dt.Rows[0]["Articulo"].ToString();
                    string vMat = dt.Rows[0]["Material"].ToString();
                    string vSob = dt.Rows[0]["PiezasNoOk"].ToString();
                    string vUbi = dt.Rows[0]["Ubi"].ToString();
                    string vCanFab = dt.Rows[0]["CantidadFab"].ToString();



                    //string vProd = dr.Cells["Articulo"].Value.ToString();
                    //string vMat = dr.Cells["Material"].Value.ToString();
                    //string vSob = dr.Cells["PiezasNoOk"].Value.ToString();
                    //string vUbi = dr.Cells["Ubi"].Value.ToString();
                    //string vCanFab = dr.Cells["CantidadFab"].Value.ToString();

                    cMovimientos.Articulo oMov = new cMovimientos.Articulo();
                    SqlConnection dbConec = new SqlConnection(cParamXml.strConec);
                    dbConec.Open();
                    SqlTransaction dbTr = dbConec.BeginTransaction();

                    try
                    {
                        //Movimientos de la cantidad sobrante
                        decimal vdSob = Convert.ToDecimal(vSob);


                        vSql = cConstantes.SQL_Produc_Pie_Produc_Lote_OF;
                        vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                        vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                        vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                        vSql = vSql.Replace("[?OF]", vOFL);
                        vSql = vSql.Replace("[?Compo]", vMat);

                        DataTable dtc = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));


                        vSql = cConstantes.SQL_Produc_Pie_Fab_Lote_OF;
                        vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                        vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                        vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                        vSql = vSql.Replace("[?OF]", vOFL);
                        vSql = vSql.Replace("[?Prod]", vProd);

                        DataTable dtp = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));


                        if (vOk)
                        {
                            decimal vdCanMat = vdSob * -1;


                            foreach (DataRow drc in dtc.Rows)
                            {
                                string vLotec = drc["Lote"].ToString();
                                string vCans = drc["Cantidad"].ToString();
                                decimal vdCans = Convert.ToDecimal(vCans);
                                vdCanMat = vdCans * -1;

                                vOk = oMov.fncAlta(cParamXml.Emp, "Salida", DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vMat, "",
                                                    vdCanMat.ToString(), vProd, vOFL, "PRODUC", vLotec, dbConec, dbTr);

                                if (!vOk) break;

                            }


                        }

                        if (vOk)
                        {
                            vOk = oMov.fncAlta(cParamXml.Emp, "Entrada", DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vMat, "",
                                              vdSob.ToString(), vProd, "", vUbi, vLote, dbConec, dbTr);
                        }
                        

                        //Movimientos de las Piezas
                        decimal vdPiezas = Convert.ToDecimal(vCanFab);

                        

                        if (vOk)
                        {
                            decimal vdCanPie = vdPiezas * -1;
                            vdPiezas = 0;

                            foreach (DataRow drc in dtp.Rows)
                            {
                                string vLotep = drc["Lote"].ToString();
                                string vCans = drc["Cantidad"].ToString();
                                decimal vdCanp = Convert.ToDecimal(vCans);
                                vdCanPie = vdCanp * -1;

                                oMov.fncAlta(cParamXml.Emp, "Salida", DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vProd, "",
                                                vdCanPie.ToString(), vOFL, vOFL, "FAB", vLotep, dbConec, dbTr);

                                vdPiezas += vdCanPie*-1;

                                if (!vOk) break;

                            }





                        }

                        if (vOk)
                        {
                            oMov.fncAlta(cParamXml.Emp, "Entrada", DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vProd, "",
                                             vdPiezas.ToString(), "", vOFL, vUbiPie, vLotePie, dbConec, dbTr);
                        }

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
                        cProduc.OF.fncCambiarEstado(cParamXml.Emp.ToString(), txOF.Text, "Terminada");

                        sbrCargar();
                    }
                    else
                    {
                        //Al terminar con error se revierten los cambios
                        dbTr.Rollback();
                        dbConec.Close();
                        dbConec.Dispose();
                    }


                }

            }


            return vOk;
        }


 
        #endregion


        private void frmTerminarOF_Load(object sender, EventArgs e)
        {
            sbrCargar();

            //cUtil.fncRecuperaEstado(this, "Terminar Ordenes");

        }

        private void frmTerminarOF_FormClosing(object sender, FormClosingEventArgs e)
        {
            //cUtil.fncGuardaEstado(this);

        }

        private void btSelTot_Click(object sender, EventArgs e)
        {
            string vMen = "¿Marcar todos los registros?";
            string vTit = "Terminar OFL";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sbrMarcarTodo(true);
            }

        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            sbrLimpiar();

        }

        private void opTodas_CheckedChanged(object sender, EventArgs e)
        {
            sbrCargar();
        }

        private void opCompletas_CheckedChanged(object sender, EventArgs e)
        {
            sbrCargar();
        }

        private void btTerminar_Click(object sender, EventArgs e)
        {

            try
            {
                DataGridViewColumn cl = null;
                ListSortDirection ld = ListSortDirection.Ascending;
                if (grOFL.SortedColumn != null)
                {
                    cl = grOFL.SortedColumn;
                    if (grOFL.SortOrder == System.Windows.Forms.SortOrder.Ascending)
                    {
                        ld = ListSortDirection.Ascending;
                    }
                    else
                    {
                        ld = ListSortDirection.Descending;

                    }

                }


                frmAnexoOFL frm = new frmAnexoOFL();
                frm.dr = sbrCargarOF(txOF.Text);
                frm.ShowDialog();


                if (frm.Terminar) fncTerminarOFL(frm.Lote,frm.UbiPie,frm.LotePie);

                //grOFL.Sort(cl, ld);
            }
            catch { }

        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grOFL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txOF.Text = grOFL.Rows[e.RowIndex].Cells["IdOF"].Value.ToString();
            }
            catch { }

        }

        private void grOFL_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewColumn cl = null;
                ListSortDirection ld = ListSortDirection.Ascending;
                if (grOFL.SortedColumn != null)
                {
                    cl = grOFL.SortedColumn;
                    if (grOFL.SortOrder == System.Windows.Forms.SortOrder.Ascending)
                    {
                        ld = ListSortDirection.Ascending;
                    }
                    else
                    {
                        ld = ListSortDirection.Descending;

                    }

                }
                
                
                
                string vOF = grOFL.Rows[e.RowIndex].Cells["IdOF"].Value.ToString();
                string vCol = grOFL.Columns[e.ColumnIndex].Name;

                frmAnexoOFL frm = new frmAnexoOFL();
                frm.dr = sbrCargarOF(vOF);
                frm.ShowDialog();

 

                if (frm.Terminar) fncTerminarOFL(frm.Lote, frm.UbiPie, frm.LotePie);

                sbrCargar();

                //grOFL.Sort(cl, ld);


            }
            catch { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
