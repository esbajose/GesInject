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
    public partial class frmCalcPrep : Form
    {
        public frmCalcPrep()
        {
            InitializeComponent();
        }

        #region Procesos locales
        private void sbrCargar()
        {

            string vSql = cConstantes.SQL_Prep_Entre;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());



            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

            grPrep.DataSource = null;

            grPrep.DataSource = dt.DefaultView;

            grPrep2.DataSource = null;
            grPrep2.DataSource = dt.DefaultView;

            if (dt.Rows.Count != 0)
            {

            }

            sbrFormatoGr();
            sbrFormatoGrLista();
        }

        private void sbrMarcarTodo(bool vMarcar)
        {
            foreach (DataGridViewRow dr in grPrep.Rows)
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
        private void sbrMarcarSelec(bool vMarcar)
        {
            DataGridViewSelectedRowCollection drsel=grPrep.SelectedRows;
            foreach (DataGridViewRow dr in drsel)
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
            foreach (DataGridViewRow dr in grPrep.Rows)
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
            grPrep.ReadOnly = false;
            foreach (DataGridViewColumn dl in grPrep.Columns)
            {
                dl.ReadOnly = true;
            }

            grPrep.Columns["Sel"].ReadOnly = false;
            grPrep.Columns["Prioridad"].ReadOnly = false;

            grPrep.Columns["Id"].Visible = false;
            
            grPrep.Columns["LinPed"].Width = 50;
            
            grPrep.Columns["Prioridad"].Width = 50;


            string vFCampo = "";
            string vFor = "";
            vFCampo = "Sel";
            vFor = "ch#";
            cUtil.sbrAgregaColumn(ref grPrep, vFor, vFCampo);

            grPrep.Columns["Sel"].Width = 50;


        }
        private void sbrFormatoGrLista()
        {

            foreach (DataGridViewColumn dl in grPrep2.Columns)
            {
                dl.ReadOnly = true;
            }

            grPrep2.Columns["Sel"].ReadOnly = false;
            grPrep2.Columns["Prioridad"].ReadOnly = false;

            grPrep2.Columns["Id"].Visible = false;

            grPrep2.Columns["LinPed"].Width = 50;

            grPrep2.Columns["Prioridad"].Width = 50;


            //string vFCampo = "";
            //string vFor = "";
            //vFCampo = "Sel";
            //vFor = "ch#";
            //cUtil.sbrAgregaColumn(ref (DataGridView)grLista, vFor, vFCampo);

            grPrep2.Columns["Sel"].Width = 50;


        }

        private void sbrFormatoGrMat()
        {

            foreach (DataGridViewColumn dl in grMat.Columns)
            {
                dl.ReadOnly = true;
            }


            string vFCampo = "";
            string vFor = "";
            vFCampo = "CanEnOF";
            vFor = "bt";
            cUtil.sbrAgregaColumn(ref grMat, vFor, vFCampo);

            vFCampo = "";
            vFor = "";
            vFCampo = "NeceTot";
            vFor = "bt";
            cUtil.sbrAgregaColumn(ref grMat, vFor, vFCampo);

            grMat.Columns["NeceTot"].Width = 150;
            grMat.Columns["CanEnOF"].Width = 150;


        }


        private bool fncProcesar()
        {
            bool vOk = true;




            //Recojo todas la necesidades de Producto y su Stock Libre  /////////////////////////////////////////////////////
            string vSql = cConstantes.SQL_Entregas_Calc;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?Alm]", cParamXml.AlmacenMat);

            string vProds = "";
            foreach (DataGridViewRow dr in grPrep.Rows)
            {
                string vSel = "";
                string vProducto = "";
                string vCan = "";
                if (dr.Cells[0].Value != null) vSel = dr.Cells[0].Value.ToString();
                if (dr.Cells["Producto"].Value != null) vProducto = dr.Cells["Producto"].Value.ToString();
                if (dr.Cells["Cantidad"].Value != null) vCan = dr.Cells["Cantidad"].Value.ToString();

                if (vSel == "1")
                {
                    //Recojo todas la necesidades de los Productos

                    vProds += "(tMat.Producto = N'" + vProducto + "') or " + cConstantes.vbCtr + cConstantes.vbLF;
                    Application.DoEvents();

                }

            }



            if (vProds != "")
            {
                vProds = " and (" + vProds.Substring(0, vProds.Length - 6) + ")";
            }
            else
            {
                MessageBox.Show("No se seleccionado ningun Producto");
                return vOk;
            }

            vSql += vProds;

            DataTable dtNece = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));

            ////////////////////////////////////////////////////////////////////////////////////////////////////////           
            grPrep.Sort(grPrep.Columns["Prioridad"], ListSortDirection.Descending);

            ////Recorro la lista de los Pedidos a preparar
            foreach (DataGridViewRow dr in grPrep.Rows)
            {
                string vSel = "";
                string vOFL = "";
                string vCan = "";
                string vProd = "";
                if (dr.Cells[0].Value != null) vSel = dr.Cells[0].Value.ToString();
                if (dr.Cells["Cantidad"].Value != null) vCan = dr.Cells["Cantidad"].Value.ToString();
                if (dr.Cells["Producto"].Value != null) vProd = dr.Cells["Producto"].Value.ToString();
                decimal vCanProd = Convert.ToDecimal(vCan);

                if (vSel == "1")
                {

                    //Busco el producto en el Datatable del stock de necesidades
                    DataRow[] BusRows;
                    BusRows = dtNece.Select("Producto = '" + vProd + "'");
                    if (BusRows.Length > 0)
                    {

                        decimal vCanStock = Convert.ToDecimal(BusRows[0]["Stock"].ToString().Replace(".", ","));
                        decimal vCanNece = Convert.ToDecimal(BusRows[0]["NeceTot"].ToString().Replace(".", ","));
                        decimal vCanAct = Convert.ToDecimal(BusRows[0]["NeceAct"].ToString().Replace(".", ","));
                        decimal vLibre = vCanStock - vCanNece;
                        if (vLibre >= vCanProd)
                        {
                            if (vCanProd != 0)
                            {
                                vCanNece += vCanProd;
                                BusRows[0]["NeceTot"] = vCanNece;
                                //Se cambia el color a Verde
                                dr.DefaultCellStyle.BackColor = Color.Green;
                                vOk = true;
                            }
                        }
                        else
                        {
                            //Se cambia el color a Rojo y se desmarca
                            dr.DefaultCellStyle.BackColor = Color.Red;
                            //dr.Cells["Sel"].Value = false;

                        }
                        BusRows[0]["NeceAct"] = vCanAct + vCanProd;

                    }

                    Application.DoEvents();

                }

            }

            grMat.DataSource = null;
            grMat.DataSource = dtNece.DefaultView;
            sbrFormatoGrMat();

            return vOk;
        }

        private bool fncCreaCabPrep(int vPed,ref int vPrep)
        {
            bool vOk = false;

            try
            {
                cPedidosVenta.CabVenta oCabVenta = new cPedidosVenta.CabVenta();
                cEntregas.CabPrepEntrega oCabEnt = new cEntregas.CabPrepEntrega();

                //Traemos los datos de la cabezera del Pedido
                oCabVenta.fncTrae(vPed);

                //Los cargamos en la cabecera de entrega
                oCabEnt.Empresa = oCabVenta.Empresa;
                oCabEnt.Estado = "P";
                oCabEnt.FechaPrep = DateTime.Now;
                oCabEnt.FechaEntrega = oCabVenta.FechaEntrega;
                oCabEnt.CodCli = oCabVenta.CodCli;
                oCabEnt.NomCli = oCabVenta.NomCli;
                oCabEnt.Dirección = oCabVenta.Dirección;
                oCabEnt.Población = oCabVenta.Población;
                oCabEnt.Provincia = oCabVenta.Provincia;
                oCabEnt.CP = oCabVenta.CP;
                oCabEnt.FPago = oCabVenta.FPago;
                oCabEnt.Divisa = oCabVenta.Divisa;
                oCabEnt.SuPedido = oCabVenta.SuPedido;
                oCabEnt.DtoPP = oCabVenta.DtoPP;
                oCabEnt.DtoESP = oCabVenta.DtoESP;
                oCabEnt.Ent_Dirección = oCabVenta.Ent_Dirección;
                oCabEnt.Ent_Población = oCabVenta.Ent_Población;
                oCabEnt.Ent_Provincia = oCabVenta.Ent_Provincia;
                oCabEnt.Ent_CP = oCabVenta.Ent_CP;
                oCabEnt.Ent_Id = oCabVenta.Ent_Id;

                //Damos de alta la cabecera de la Preparación
                vOk = oCabEnt.fncAltaCab(ref vPrep);

            }
            catch { vOk = false; }

            return vOk;
        }

        private bool fncCreaLinea(int vPrep , int vPed,int vLin)
        {
            bool vOk = false;

            try
            {
                cPedidosVenta.CabVenta oCabVenta = new cPedidosVenta.CabVenta();
                cPedidosVenta.LinVenta oLinVenta = new cPedidosVenta.LinVenta();
                cEntregas.LinPrepEntregas oLinEnt = new cEntregas.LinPrepEntregas();

                //Traemos los datos de la cabezera del Pedido
                oCabVenta.fncTrae(vPed);

                //Traemos loa datos de la linea del pedido
                oLinVenta.fncTrae(vPed, vLin);

                //Los cargamos en la linea de la entrega
                oLinEnt.Empresa = oLinVenta.Empresa;
                oLinEnt.NumPrep = vPrep;
                oLinEnt.Producto = oLinVenta.Producto;
                oLinEnt.Descripción = oLinVenta.Descripción;
                oLinEnt.Cantidad = oLinVenta.CantidadPendiente;
                oLinEnt.Lote = oLinVenta.Lote;
                oLinEnt.CantidadServida = 0;
                oLinEnt.CanPen = oLinVenta.CantidadPendiente;
                oLinEnt.FechaEntrega = oLinVenta.FechaEntrega;
                oLinEnt.PedLocal = vPed.ToString();
                oLinEnt.LinPedLocal = vLin;
                oLinEnt.PedCliente = oCabVenta.SuPedido;

                //Damos de alta la linea
                vOk = oLinEnt.fncAltaLin();
            }
            catch { vOk = false; }

            return vOk;
        }


        private bool fncCrearPrep()
        {
            bool vOk = false;

            try
            {
                string vCliOld = "";
                int vPrep = 0;

                //Se ordena el grid por Nº de pedido
                grPrep.Sort(grPrep.Columns["CodCli"], ListSortDirection.Ascending);

                ////Recorro la lista de los Pedidos a Preparar
                foreach (DataGridViewRow dr in grPrep.Rows)
                {
                    string vSel = "";
                    string vPed = "";
                    string vCli = "";
                    string vLinPed = "0";
                    string vCan = "";
                    string vProd = "";
                    if (dr.Cells[0].Value != null) vSel = dr.Cells[0].Value.ToString();
                    if (dr.Cells["NumPed"].Value != null) vPed = dr.Cells["NumPed"].Value.ToString();
                    if (dr.Cells["LinPed"].Value != null) vLinPed = dr.Cells["LinPed"].Value.ToString();
                    if (dr.Cells["Cantidad"].Value != null) vCan = dr.Cells["Cantidad"].Value.ToString();
                    if (dr.Cells["Producto"].Value != null) vProd = dr.Cells["Producto"].Value.ToString();
                    if (dr.Cells["CodCli"].Value != null) vCli = dr.Cells["CodCli"].Value.ToString();


                    if (vSel == "1")
                    {
                        if (vCli != vCliOld)
                        {
                            vPrep = 0;
                            vCliOld = vCli;
                            if (fncCreaCabPrep(Convert.ToInt32(vPed), ref vPrep))
                            {
                                if (!fncCreaLinea(vPrep, Convert.ToInt32(vPed), Convert.ToInt32(vLinPed)))
                                {
                                    //Se cambia el color a Amarillo y se desmarca
                                    dr.DefaultCellStyle.BackColor = Color.Yellow;
                                    dr.Cells["Sel"].Value = false;

                                }
                            }
                            else
                            {
                                //Se cambia el color a Amarillo y se desmarca
                                dr.DefaultCellStyle.BackColor = Color.Yellow;
                                dr.Cells["Sel"].Value = false;

                            }

                        }
                        else
                        {
                            if (!fncCreaLinea(vPrep, Convert.ToInt32(vPed), Convert.ToInt32(vLinPed)))
                            {
                                //Se cambia el color a Amarillo y se desmarca
                                dr.DefaultCellStyle.BackColor = Color.Yellow;
                                dr.Cells["Sel"].Value = false;

                            }

                        }





                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sbrCargar();

            return vOk;
        }

        #endregion


        private void frmCalcPrep_Load(object sender, EventArgs e)
        {
            cUtil.fncRecuperaEstado(this, "Calcular Preparación de Entregas");
            sbrCargar();

        }
        private void frmCalcPrep_FormClosing(object sender, FormClosingEventArgs e)
        {
            cUtil.fncGuardaEstado(this);

        }

        private void btSelTot_Click(object sender, EventArgs e)
        {
            string vMen = "¿Marcar todos los registros?";
            string vTit = "Preparación Entregas";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sbrMarcarTodo(true);
            }

        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            sbrLimpiar();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void grPrep_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int vRow = e.RowIndex;
            string vPrio = grPrep.Rows[vRow].Cells["Prioridad"].Value.ToString();
            string vId = grPrep.Rows[vRow].Cells["Id"].Value.ToString();
            int viPrio = (vPrio == "") ? 0 : Convert.ToInt32(vPrio);
            upPrio.Value = viPrio;
            txPrio.Text = viPrio.ToString();
            txID.Text = vId;
         }

        private void btCambiar_Click(object sender, EventArgs e)
        {
            string vMen = "Se cambiara la prioridad de la lina selecionada.Esta seguro?";
            string vTit = "Prioridades";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
            {            
                return;
            }

            cPedidosVenta.LinVenta oLinventa = new cPedidosVenta.LinVenta();

            oLinventa.Id = Convert.ToInt32(txID.Text);
            oLinventa.ValAnt = txPrio.Text;

            if (oLinventa.fncGrabaCampo("Prioridad", upPrio.Value.ToString()))
            {
                sbrCargar();
            }

        }

        private void btProcesar_Click(object sender, EventArgs e)
        {
            string vMen = "¿Procesar la lineas selecionadas? " + cConstantes.vbCtr + cConstantes.vbLF;
            string vTit = "Entregas";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            if (!fncProcesar())
            {
                return;
            }
            btCrear.Visible = true;
        }

        private void grPrep_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            string vVal = "0";
            try
            {
                vVal = grPrep.Rows[e.RowIndex].Cells["Prioridad"].Value.ToString();
            }
            catch { }
            cPedidosVenta.LinVenta oLinventa = new cPedidosVenta.LinVenta();

            oLinventa.Id = Convert.ToInt32(txID.Text);
            oLinventa.ValAnt = txPrio.Text;

            if (oLinventa.fncGrabaCampo("Prioridad", vVal))
            {
            }
        }

        private void btActu_Click(object sender, EventArgs e)
        {
            sbrCargar();
        }

        private void btCrear_Click(object sender, EventArgs e)
        {
            string vMen = "¿Crear las preparaciones selecionadas? " + cConstantes.vbCtr + cConstantes.vbLF;
            string vTit = "Crear Preparación";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            //if (!fncProcesar())
            //{
            //    return;
            //}

            fncCrearPrep();

        }

        private void btOFL_Click(object sender, EventArgs e)
        {

            string vProd = "";
            try { vProd = grMat.CurrentRow.Cells["Producto"].Value.ToString(); }
            catch { return; }
            if (vProd == "") return;


            string vMen = "Se creara una OFL para el producto: '" + vProd + "' .Esta seguro?";
            string vTit = "Preparaciones";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }


            string vWhere = " Empresa = " + cParamXml.Emp + " and Producto = N'" + vProd + "'";
            string vDes = cUtil.fncTraeCampo("Descripción", "GC_ProductoAnexos", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", true);
            if (vDes == "***Inex***")
            {
                vDes = "";
            }

            if (vProd != "")
            {
                frmOF frm = new frmOF();
                frm.vProdNuevo = vProd;
                frm.vDesProdNuevo=vDes;
                frm.vOFNueva = true;
                frm.ShowDialog();
            }

        }

        private void grMat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int vCol = e.ColumnIndex;
            int vFil = e.RowIndex;
            string vCampo = grMat.Columns[vCol].Name;
            string vProd = grMat.CurrentRow.Cells["Producto"].Value.ToString();

            if (vCampo == "CanEnOF")
            {
                string vSql = cConstantes.SQL_OFL_Lista_CanPen;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?Prod]", vProd);


                string vTabla = "GC_OrdenProd";
                string vWhere = " where Empresa = [?Emp] and (Estado = 'Lanzada' or Estado = 'Producción') ";
                vWhere = "";
                string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "IdOF", "", vWhere, vSql, "", false, "", "", "", "SQL");

                if (vRes != "")
                {
                    frmOF frm = new frmOF();
                    frm.vOFExt = vRes;
                    frm.ShowDialog();
                   
                }
            }

            if (vCampo == "NeceTot")
            {
                string vSql = cConstantes.SQL_Prep_Nece;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?Prod]", vProd);


                string vTabla = "GC_CabPrepEntregas";
                string vWhere = "";
                string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "IdOF", "", vWhere, vSql, "", false, "", "", "", "SQL");

                if (vRes != "")
                {
                    frmOF frm = new frmOF();
                    frm.vOFExt = vRes;
                    frm.ShowDialog();

                }
            }



        }

        private void btMarcSel_Click(object sender, EventArgs e)
        {
            string vMen = "¿Marcar los registros seleccionados?";
            string vTit = "Preparación Entregas";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sbrMarcarSelec(true);
            }

        }
    }
}
