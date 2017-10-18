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
using System.Data.SqlClient;

namespace GesInject.Formularios
{
    public partial class frmPrepEntregas : Form
    {
        private bool vCancel = false;
        private bool vIni = true;
        private bool vCab = false;
        private bool vLin = false;
        private string vCampo = "";
        private string vCampoT = "";
        private string vVal = "";
        public string vPrepExt = "";



        public frmPrepEntregas()
        {
            InitializeComponent();
        }

        #region Objetos Form
        private void frmPrepEntregas_Load(object sender, EventArgs e)
        {
            this.Text = "Preparación Entregas";

            cUtil.fncRecuperaEstado(this, "Preparación Entregas");


            sbrCargaPrepEntregas();
            sbrBindCampos(this);
            vIni = true;

            if (vPrepExt != "")
            {
                int vReg = cEntregas.fncBuscaIndexCabPrep(bS1, vPrepExt);
                bS1.Position = vReg;

            }

        }
        private void frmPrepEntregas_KeyUp(object sender, KeyEventArgs e)
        {
            Control ctl;
            ctl = (Control)sender;
            string vControl = ctl.Name;

            string vTecla = e.KeyCode.ToString();
            if ((vTecla == "F3") | (vTecla == "Escape") | (vTecla == "Tab"))
            {
                sbrTecla(vTecla);
                e.Handled = true;
            }
            if (vTecla == "Down")
            {
                try
                {
                    bS2.MoveNext();
                }
                catch { }
                e.Handled = true;
            }
            if (vTecla == "Up")
            {
                try
                {
                    bS2.MovePrevious();
                }
                catch { }
                e.Handled = true;
            }

            if (e.Control && e.KeyCode == Keys.B)
            {
                try
                {
                    sbrBusca(vCampo);
                    e.Handled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
                return;
            }
        }
        private void btDel_Click(object sender, EventArgs e)
        {
            sbrBajaPrepEntrega();
        }
        private void btAlta_Click(object sender, EventArgs e)
        {
            string vMen = "¿Dar de Alta una Nueva Preparación?";
            string vTit = "Preparaciones";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sbrAltaPrepEntrega();
                vCab = true;
                txCodCli.Focus();
            }
        }
        private void btRefrescar_Click(object sender, EventArgs e)
        {
            //sbrRefrescar();
            //sbrRefrescarLin();
        }

        #endregion


        #region Procesos
        public void sbrTool(string vTipo)
        {
            if (vTipo == "Cortar")
            {
                Control obj = this.ActiveControl;
                if (obj.GetType() == typeof(TextBox))
                {
                    Clipboard.SetText(obj.Text);
                    obj.Text = "";
                }
            }
            if (vTipo == "Copiar")
            {
                Control obj = this.ActiveControl;
                if (obj.GetType() == typeof(TextBox))
                {
                    Clipboard.SetText(obj.Text);
                }
            }
            if (vTipo == "Pegar")
            {
                Control obj = this.ActiveControl;
                if (obj.GetType() == typeof(TextBox))
                {
                    obj.Text = Clipboard.GetText();
                }
            }

        }

        #region CabPrepEntregas
        private void sbrCargaPrepEntregas()
        {
            //btDel.Visible = false;
            try
            {
                bS1.DataSource = cEntregas.Lista();
                Navi1.BindingSource = bS1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                this.Close();
            }
        }
        private void sbrActuDatos()
        {
            bS1.DataSource = cEntregas.Lista();
        }
        private void sbrAltaPrepEntrega()
        {
            try
            {
                cEntregas.CabPrepEntrega cabvEnt = (cEntregas.CabPrepEntrega)bS1.Current;
                int vId = cabvEnt.fncAlta();
                if (vId == 0)
                {
                    MessageBox.Show("No se ha podido dar de Alta la Preparación de Entrega");
                    return;
                }

                sbrActuDatos();

                bS1.MoveLast();
                txCodCli.Focus();
                btDel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido dar de Alta la Preparación de Entrega :'" + ex.Message + "'");
                bS1.CancelEdit();

            }
        }
        private void sbrBajaPrepEntrega()
        {
            if (bS1.Current != null)
            {

                if (grLinPrep.RowCount > 0)
                {
                    MessageBox.Show("La Preparación de Entrega tiene lineas, NO se puede eliminar");
                    return;

                }


                string vMen = "Esta seguro de Eliminar el registro actual?";
                string vTit = "Eliminar";
                if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        cEntregas.CabPrepEntrega cabvPrep = (cEntregas.CabPrepEntrega)bS1.Current;
                        if (!cabvPrep.fncBaja(cabvPrep.NumPrep.ToString()))
                        {
                            MessageBox.Show("No se ha podido Eliminar la Preparación de Entrega");
                            bS1.CancelEdit();
                        }
                        else
                        {
                            bS1.Remove(cabvPrep);
                            sbrCargaPrepEntregas();

                            cEntregas.CabPrepEntrega cabventa = (cEntregas.CabPrepEntrega)bS1.Current;
                            sbrCargaLineas(cabventa.NumPrep.ToString());
                            
                            Application.DoEvents();
                            //btDel.Visible = false;

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se ha podido Eliminar la Preparación de Entrega :'" + ex.Message + "'");
                        bS1.CancelEdit();

                    }

                }

            }

        }
        private void sbrModifCampo(string vCampo, string vValor)
        {
            cEntregas.CabPrepEntrega cabPrep = (cEntregas.CabPrepEntrega)bS1.Current;

            if (cabPrep.aCampoModif != "") { vCampo = cabPrep.aCampoModif; }
            if (cabPrep.aValor != "") { vValor = cabPrep.aValor; }

            if (!cabPrep.fncGrabaCampo(vCampo, vValor))
            {
                MessageBox.Show("No se ha podido Grabar el Dato");
                bS1.CancelEdit();
            }

            if (vCampo == "CodCli")
            {
                sbrActuCli(vValor);
            }

        }
        private void sbrRefrescar()
        {
            cEntregas.CabPrepEntrega cabPrep = (cEntregas.CabPrepEntrega)bS1.Current;
            string vcabPrep = cabPrep.NumPrep.ToString();
            int vReg = bS1.Position;
            sbrActuDatos();
            vReg = cEntregas.fncBuscaIndexCabPrep(bS1, vcabPrep);
            //vReg = cPedidosVenta.fncBuscaIndexCabPed(bS1, vcabPrep);
            bS1.Position = vReg;
            //if (txPrep.Text != "") { btDel.Visible = false; }
        }
        public void sbrTecla(string vTecla)
        {
            switch (vTecla)
            {
                case "F3":
                    sbrAltaPrepEntrega();
                    break;
                case "Escape":
                    this.ActiveControl.BackColor = Color.White;
                    sbrRefrescar();

                    break;

            }
        }
        public void sbrBusca(string vCampo)
        {
            string vTabla = "";
            string vWhere = "";
            string vRes = "";

            if (vCampo == "txPrep")
            {
                vTabla = "[GC_CabPrepEntregas]";
                vWhere = "";
                vRes = cUtil.fncLista(vTabla, cParamXml.strConec, "NumPrep", txPrep.Text, vWhere);

                if (vRes != "")
                {

                    int vReg = cEntregas.fncBuscaIndexCabPrep(bS1, vRes);
                    bS1.Position = vReg;
                }
            }
            if (vCampo == "txCodCli")
            {

                btCliente_Click(btCliente, null);

            }

            //if (vCampo == "txProd")
            //{
            //    vTabla = "articulo";
            //    vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "cref", txProd.Text, "", "", "", false, "", "", "", "DBF");

            //    if (vRes != "")
            //    {
            //        txProd.Text = vRes;
            //    }

            //}



            //if (vCampo == "txFPago")
            //{
            //    vTabla = "fpago";
            //    vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "ccodpago", txFPago.Text, "", "", "", false, "", "", "", "DBF");

            //    if (vRes != "")
            //    {
            //        txFPago.Text = vRes;
            //        Application.DoEvents();
            //        sbrRefrescar();
            //    }
            //}
            //if (vCampo == "txDivisa")
            //{
            //    vTabla = "divisas";
            //    vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "ccoddiv", txDivisa.Text, "", "", "", false, "", "", "", "DBF");

            //    if (vRes != "")
            //    {
            //        txDivisa.Text = vRes;
            //        Application.DoEvents();
            //        sbrRefrescar();
            //    }
            //}



        }
        private void sbrActuCli(string vCli)
        {
            DataRow dr;
            string vWhere = " ccodcli = '" + vCli + "' ";
            dr = cUtil.fncTraeCampos("clientes", vWhere, cParamXml.strOleDBConecDbf, "DBF");
            //lbNomCli.Text = "";
            if (dr != null)
            {

                sbrModifCampo("nomcli", dr["cnomcli"].ToString());
                sbrModifCampo("dirección", dr["cdircli"].ToString());
                sbrModifCampo("Población", dr["cpobcli"].ToString());
                sbrModifCampo("CP", dr["cptlcli"].ToString());
                sbrModifCampo("Provincia", dr["cpobcli"].ToString());
                sbrModifCampo("FPago", dr["ccodpago"].ToString());
                sbrModifCampo("Divisa", dr["ccodDiv"].ToString());
                sbrModifCampo("Ent_Dirección", dr["cdircli"].ToString());
                sbrModifCampo("Ent_Población", dr["cpobcli"].ToString());
                sbrModifCampo("Ent_CP", dr["cptlcli"].ToString());
                sbrModifCampo("Ent_Provincia", dr["cpobcli"].ToString());
                sbrModifCampo("Ent_Id", "0");
                Application.DoEvents();

            }
            DataRow dr2;
            vWhere = " codcli = '" + vCli + "' and Empresa=" + cParamXml.Emp + " and IdEntrega = 0 ";
            dr2 = cUtil.fncTraeCampos("GC_DirEntregas", vWhere, cParamXml.strConec, "SQL");
            if (dr2 != null)
            {
                sbrModifCampo("Ent_Dirección", dr2["Dirección"].ToString());
                sbrModifCampo("Ent_Población", dr2["Población"].ToString());
                sbrModifCampo("Ent_CP", dr2["CP"].ToString());
                sbrModifCampo("Ent_Provincia", dr2["Provincia"].ToString());
                sbrModifCampo("Ent_Id", dr2["IdEntrega"].ToString());

            }
            else
            {
                cClientes.DirEntrega oDir = new cClientes.DirEntrega();
                oDir.Provincia = dr["cpobcli"].ToString();
                oDir.Población = dr["cpobcli"].ToString();
                oDir.Empresa = cParamXml.Emp;
                oDir.Dirección = dr["cdircli"].ToString();
                oDir.CP = dr["cptlcli"].ToString();
                oDir.CodCli = vCli;
                oDir.fncAlta0(0);
            }

        }


        #endregion

        #region LinPrepEntregas

        private void sbrCargaLineas(string vPrep)
        {
            try
            {
                this.bS2.DataSource = cEntregas.ListaLineas(vPrep);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void sbrModifCampoLineas(string vCampo, string vValor)
        {
            cPedidosVenta.LinVenta linp = (cPedidosVenta.LinVenta)bS2.Current;

            if (linp.aCampoModif != "") { vCampo = linp.aCampoModif; }
            if (linp.aValor != "") { vValor = linp.aValor; }

            if (!linp.fncGrabaCampo(vCampo, vValor))
            {
                if ((linp.aError != "") & (linp.aError != null)) { MessageBox.Show(linp.aError); }
                bS2.CancelEdit();
            }

            if (vCampo == "Producto")
            {
                sbrActuProd(vValor);
            }


        }

        private void sbrActuProd(string vProd)
        {


            //Busco Campos del Producto
            string vWhere = " Empresa = " + cParamXml.Emp + " and Producto = '" + vProd + "' ";
            DataRow drm = cUtil.fncTraeCampos("GC_ProductoAnexos", vWhere, cParamXml.strConecProduc_Prueb, "SQL");



            txDesProd.Text = "";
            if (drm != null)
            {
                txDesProd.Text = drm["Descripción"].ToString();

                txPedCli.Text = txSuPed.Text;

            }

        }


        private void sbrFormatgrPropiedades()
        {
            //foreach (C1.Win.C1TrueDBGrid.C1DataColumn cl in grPropiedades.Columns)
            //{
            //    string vNCol = cl.DataField.ToString();
            //    vNCol = vNCol.Replace("ç", " ");
            //    vNCol = vNCol.Replace("_", ".");
            //    cl.Caption = vNCol;
            //}
        }

        private void sbrActuDatosLinPed(string vPed)
        {
            bS2.DataSource = cPedidosVenta.ListaLineas(vPed);

        }

        //private string fncFiltros()
        //{
        //    string vFil = "";
        //    StringBuilder sb = new StringBuilder();
        //    foreach (C1.Win.C1TrueDBGrid.C1DataColumn dc in this.grPropiedades.Columns)
        //    {
        //        if (dc.FilterText.Length > 0)
        //        {
        //            //if (sb.Length > 0)
        //            //{
        //            sb.Append(" AND ");
        //            //}
        //            string vCampo = dc.DataField;
        //            vCampo = vCampo.Replace("ç", " ");
        //            if (vCampo.LastIndexOf('[') == -1) { vCampo = "[" + vCampo + "]"; }
        //            sb.Append("(" + vCampo + " like " + "'%" + dc.FilterText + "%'" + ")");
        //        }
        //    }
        //    // Filtrado de datos

        //    vFil = sb.ToString();


        //    return vFil;
        //}

        private void sbrRefrescarLinPed()
        {
            cPedidosVenta.LinVenta linp = (cPedidosVenta.LinVenta)bS2.Current;
            int vPed = linp.NumPed;
            int vReg = bS2.Position;
            sbrActuDatosLinPed(linp.NumPed.ToString());
            vReg = cPedidosVenta.fncBuscaIndexLinPed(bS2, vPed.ToString());
            bS2.Position = vReg;
        }

        private bool fncBajaLinea()
        {
            bool vOk = true;
            if (bS2.Current != null)
            {

                cEntregas.LinPrepEntregas linp = (cEntregas.LinPrepEntregas)bS2.Current;
                if (linp.CantidadServida > 0)
                {
                    //MessageBox.Show("Esta Linea tiene cantidad servida NO se puede eliminar");
                    //bS2.CancelEdit();
                    //vOk = false;

                    vOk = fncBajaCaja(linp);
                    cEntregas.CabPrepEntrega cabventa = (cEntregas.CabPrepEntrega)bS1.Current;
                    vIni = true;
                    sbrLimpiaEnt();
                    sbrCargaLineas(cabventa.NumPrep.ToString());
                    Application.DoEvents();
                    vIni = false;


                    return vOk;
                }
                string vMen = "Esta seguro de Eliminar la linea?";
                string vTit = "Eliminar";
                if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        if (!linp.fncBaja(linp.NumPrep.ToString()))
                        {
                            MessageBox.Show("No se ha podido Eliminar la propiedad");
                            bS2.CancelEdit();
                            vOk = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se ha podido Eliminar la linea :'" + ex.Message + "'");
                        bS2.CancelEdit();
                        vOk = false;

                    }

                }
                else
                {
                    bS2.CancelEdit();
                    vOk = false;
                }

            }
            return vOk;
        }

        private bool fncBajaCaja(cEntregas.LinPrepEntregas linp)
        {
            bool vOk = false;
            string vSql = "";
            DataTable dt2;

            //vSql = cConstantes.SQL_Alb_Entrega;
            //vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            //vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            //vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            //vSql = vSql.Replace("[?NumPrep]", linp.NumPrep.ToString());
            //vSql = vSql.Replace("[?Prod]", linp.Producto);
            //DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));
            //if (dt.Rows.Count > 0)
            //{
            //    string vProd = "";
            //    string vDesProd = "";
               
            //    string vWhere = "";
            //    foreach(DataRow dr in dt.Rows)
            //    {
            //        string vLotes = dr["Lote"].ToString();
            //        string vCajas = dr["Cajas"].ToString();

            //        string vOF = cUtil.Piece(vLotes, "|", 2);
            //        if (vOF != "")
            //        {
            //            vWhere += "(IdOF = '" + vOF.Trim() + "') AND (NumCajaBolsa IN (" + vCajas + ")) OR ";
            //        }


            //    }



            //    if (vWhere != "")
            //    {
            //        vWhere = "Where " + vWhere.Substring(0, vWhere.Length - 3);
            //    }



            //    if (vWhere != "")
            //    {
            //        vSql = cConstantes.SQL_ElimCajaEntrega;
            //        vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            //        vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            //        vSql = vSql.Replace("[?Filtro]", vWhere);
            //        dt2 = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));
            //    }
            //    else
            //    {
            //        vSql = cConstantes.SQL_ElimAlbEntrega;
            //        vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            //        vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            //        vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            //        vSql = vSql.Replace("[?NumPrep]", linp.NumPrep.ToString());
            //        dt2 = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

            //    }


                vSql = cConstantes.SQL_Alb_Entrega;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?NumPrep]", linp.NumPrep.ToString());
                vSql = vSql.Replace("[?Prod]", linp.Producto);
                dt2 = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));


                if (dt2.Rows.Count > 0)
                {
                    frmElimCajasPrep frm = new frmElimCajasPrep();
                    frm.dt = dt2;
                    frm.Prep = linp.NumPrep+"#"+linp.Producto+"#"+linp.Descripción;
                    frm.ShowDialog();

                    string vElim = frm.Res;

                    string[] vmElim = vElim.Split('|');
                    for (int i = 0; i < vmElim.Length;i++ )
                    {
                        string[] vmCaja = vmElim[i].Split('#');
                        if (vmCaja.Length > 1)
                        {
                            string vOF = vmCaja[0];
                            string vNumCaja = vmCaja[1];
                        }


                    }

                        
                    if (vElim !="") fncElimEntregar(vElim);
                //}




            }

            return vOk;
        }
        private void sbrCargaLinea(int vFil)
        {
            sbrLimpiaEnt();
            //if (vIni) { return; }

            string vLin = grLinPrep.Rows[vFil].Cells["LinPrep"].Value.ToString();
            string vProd = grLinPrep.Rows[vFil].Cells["Producto"].Value.ToString();
            string vDes = grLinPrep.Rows[vFil].Cells["Descripción"].Value.ToString();
            string vCan = grLinPrep.Rows[vFil].Cells["Cantidad"].Value.ToString();
            string vCanSer = grLinPrep.Rows[vFil].Cells["CantidadServida"].Value.ToString();
            string vFechaEnt = grLinPrep.Rows[vFil].Cells["FechaEntrega"].Value.ToString();
            string vLote = grLinPrep.Rows[vFil].Cells["Lote"].Value.ToString();
            string vPedCli = grLinPrep.Rows[vFil].Cells["PedCliente"].Value.ToString();
            string vPedLocal = grLinPrep.Rows[vFil].Cells["PedLocal"].Value.ToString();
            string vLinPedLocal = grLinPrep.Rows[vFil].Cells["LinPedLocal"].Value.ToString();

            decimal vdCan = Convert.ToDecimal(vCan);
            decimal vdCanSer = Convert.ToDecimal(vCanSer);
            decimal vdCanPen = vdCan - vdCanSer;
            if (vdCanPen < 0) vdCanPen = 0;
            

            txLinPrep.Text = vLin;
            txProd.Text = vProd;
            txDesProd.Text = vDes;
            txCan.Text = vdCanPen.ToString();
            txCanSer.Text = vCanSer;
            dTEntrega.Value = Convert.ToDateTime(vFechaEnt);
            txLote.Text = vLote;
            txPedCli.Text = vPedCli;

            txPed.Text = vPedLocal;
            txLinPed.Text = vLinPedLocal;

            btElim.Visible = true;
            //btGrabar.Visible = true;
            btCancel.Visible = true;
            //lbSitu.Text = "Modificación";

            if (vdCanPen !=0)
            {
                btEntregar.Visible = true;
            }
            else
            {
                btEntregar.Visible = false;
            }

            return;
        }

        private void sbrLimpiaEnt()
        {
            txLinPrep.Text = "";
            txProd.Text = "";
            txDesProd.Text = "";
            txCan.Text = "";
            txCanSer.Text = "";
            dTEntrega.Value = DateTime.Now;
            txLote.Text = "";
            txPedCli.Text = "";
            txPed.Text = "";
            txLinPed.Text = "";


            btElim.Visible = false;
            btGrabar.Visible = false;
            btCancel.Visible = false;

            lbSitu.Text = "";
            lbSitu.Visible = false;
            //txProd.Focus();
        }

        private bool fncAltaLinea()
        {
            bool vOk = false;

            cEntregas.LinPrepEntregas cPrepEnt = new cEntregas.LinPrepEntregas();

            if (txCan.Text == "") { txCan.Text = "0"; }


            cPrepEnt.Empresa = cParamXml.Emp;
            cPrepEnt.NumPrep = Convert.ToInt32(txPrep.Text);
            cPrepEnt.Producto = txProd.Text;
            cPrepEnt.Descripción = txDesProd.Text;
            cPrepEnt.Cantidad = Convert.ToDecimal(txCan.Text);
            cPrepEnt.Lote = txLote.Text;
            cPrepEnt.CantidadServida = 0;
            cPrepEnt.CanPen = Convert.ToDecimal(txCan.Text);
            cPrepEnt.FechaEntrega = dTEntrega.Value;
            cPrepEnt.PedLocal = "";
            cPrepEnt.LinPedLocal = 0;
            cPrepEnt.PedCliente = txPedCli.Text;
            vOk = cPrepEnt.fncAltaLin();

            return vOk;

        }

        #endregion

        private DataTable fncCargaPrep()
        {
            

            string vSql = cConstantes.SQL_PrepPen_Lista;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));


            return dt;

        }


        private bool fncElimEntregar(string vReg)
        {
            //_Res += ID + "#" +vAlb + "#" + vLin + "#" + vIdOF + "#" + vCaja + "#" + vCan + "#" + vLote + "|";

            bool vOk = false;
            cEntregas.LinPrepEntregas linp = (cEntregas.LinPrepEntregas)bS2.Current;
            int vNumPrep = linp.NumPrep;
            int vLinPrep = linp.LinPrep;
            string vsNumPed = linp.PedLocal;
            if (vsNumPed == "") vsNumPed = "0";
            int vNumPed = Convert.ToInt32(vsNumPed);
            int vLinPed = linp.LinPedLocal;
            string vProd = linp.Producto;


            using (SqlConnection dbConec = new SqlConnection(cParamXml.strConecProduc_Prueb))
            {
                dbConec.Open();
                SqlTransaction dbTr = dbConec.BeginTransaction();
                try
                {
                    string[] vmReg = vReg.Split('|');
                    for (int i = 0; i < vmReg.Length; i++)
                    {
                        string vR = vmReg[i].ToString();
                        if (vR.Length < 2) break;

                        string[] vmR = vR.Split('#');

                        int vID = Convert.ToInt32(vmR[0].ToString());
                        string vOFL = vmR[3].ToString();
                        string vCajas = vmR[4].ToString();
                        string vCan = vmR[5].ToString();
                        string vLote = vmR[6].ToString();
                        string vUbi = cMovimientos.Articulo.fncTraeUbi(cParamXml.Emp, vNumPrep.ToString(), vProd, "Salida", "-"+vCan, vLote);
                       
                        int vNumAlb = 0;
                        //Damos de Baja la linea
                        cAlbaranesVenta.LinAlb oLinAlb = new cAlbaranesVenta.LinAlb();
                        if (oLinAlb.fncBaja(vID, dbConec, dbTr))
                        {
                            //Grabamos la cantridad entregada de la preparación
                            if (cEntregas.LinPrepEntregas.fncMenosCantidadServida(cParamXml.Emp.ToString(), vNumPrep, vLinPrep, vCan.ToString(), dbConec, dbTr))
                            {
                                //Si la entrega es de un pedido de modifica la cantidad entregada del pedido
                                if (vNumPed != 0)
                                {
                                    if (!cPedidosVenta.LinVenta.fncMenosCantidadServida(cParamXml.Emp.ToString(), vNumPed, vLinPed, vCan.ToString(), dbConec, dbTr))
                                    {
                                        return vOk;
                                    }
                                }
                                //Movimientos de Producto
                                cMovimientos.Articulo oMov = new cMovimientos.Articulo();

                                if (oMov.fncAlta(cParamXml.Emp, "Entrada", DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vProd, txDesProd.Text,
                                                vCan.ToString(), vNumPrep.ToString(), vOFL, vUbi, vLote))
                                {
                                    vOk = true;
                                }
                            }
                        }

                        //Descactivamos las cajas seleccionadas
                        if ((vCajas != "") & (vOFL != ""))
                        {
                            string[] vmCajas = vCajas.Split(',');
                            for (int i2 = 0; i2 < vmCajas.Length; i2++)
                            {
                                string vSql = "";
                                string vTabla = " GC_OrdenProdCajas";
                                string vCampo = "Entregada";
                                string vWhere = " IdOF = '" + vOFL.Trim() + "' AND (NumCajaBolsa = " + vmCajas[i2] + ")";
                                vSql = cConstantes.SQL_UP_Update;
                                vSql = vSql.Replace("[?1]", "[" + vCampo + "]");
                                vSql = vSql.Replace("[?2]", "0");
                                vSql = vSql.Replace("[?3]", vWhere);
                                vSql = vSql.Replace("[?99]", vTabla);
                                int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);

                            }
                        }

                    }
                }
                catch { vOk = false; }

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


        #endregion

        #region Binding (CabPrepEntregas)


        public void sbrBindCampos(Control vControles)
        {
            foreach (Control vctl in vControles.Controls)
            {
                if (vctl.Controls.Count > 0)
                {
                    sbrBindCampos(vctl);
                }
                if (vctl.Tag != null)
                {
                    string vTipo = vctl.GetType().ToString();
                    string vTagOp = vctl.Tag.ToString();
                    string vbind = cUtil.Piece(vTagOp, "#", 1);

                    if (vbind == "bind")
                    {
                        string vCampo = cUtil.Piece(vTagOp, "#", 2);
                        string vTipoCampo = cUtil.Piece(vTagOp, "#", 3);
                        string vTipoC = cUtil.Piece(vTagOp, "#", 4);
                        Binding b = new Binding(vTipoCampo, bS1, vCampo);

                        if (vTipoC == "System.Decimal")
                        {
                            try
                            {
                                b.FormattingEnabled = true;
                                b.FormatString = "n4";
                            }
                            catch { }
                        }
                        try
                        {
                            vctl.DataBindings.Add(b);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        vctl.KeyUp += new KeyEventHandler(tx_KeyUp);
                        vctl.Leave += new EventHandler(tx_Leave);
                        vctl.Validating += new CancelEventHandler(tx_Validating);
                        vctl.Enter += tx_Enter;

                    }
                }
            }

        }

        private void tx_Validating(object sender, CancelEventArgs e)
        {
            Control ctl;
            ctl = (Control)sender;
            string vName = ctl.Name;
            string vTex = ctl.Text;


            if (vName == "txPed")
            {
                if (vTex == "")
                {
                    MessageBox.Show("El Campo 'Nº Pedido' es un Indice,NO puede estar en blanco");
                    e.Cancel = true;
                    btDel.Visible = true;
                }
            }

        }
        private void tx_KeyUp(object sender, KeyEventArgs e)
        {
            Control ctl;
            ctl = (Control)sender;
            ctl.BackColor = Color.LightBlue;

            if (e.KeyCode == Keys.Enter)
            {
                string vCampo = ((TextBox)ctl).DataBindings["Text"].BindingMemberInfo.BindingField;
                ctl.BackColor = Color.White;
                bS1.RaiseListChangedEvents = true;
                bS1.EndEdit();
                //sbrRefrescar();
                Application.DoEvents();
            }

        }
        private void tx_Leave(object sender, EventArgs e)
        {
            Control ctl;
            ctl = (Control)sender;
            ctl.BackColor = Color.White;

        }
        private void tx_Enter(object sender, EventArgs e)
        {
            vCab = true;
            vLin = false;
            Control ctl;
            ctl = (Control)sender;
            vCampo = ctl.Name;
        }

        #endregion

        #region Binding (LinPrepEntregas)

        private void txLin_Validating(object sender, CancelEventArgs e)
        {
            //if (vCancel) { vCancel = false; return; }

            //Control ctl;
            //ctl = (Control)sender;
            //string vName = ctl.Name;
            //string vTex = ctl.Text;


            //if (vName == "txProd")
            //{
            //    if (vTex == "")
            //    {
            //        //MessageBox.Show("El Campo 'Producto' ,NO puede estar en blanco");
            //        //e.Cancel = true;
            //    }
            //    else
            //    {

            //        string vWhere = " cREF = '" + txProd.Text + "' ";
            //        string vDes = cUtil.fncTraeCampo("cdetalle", "articulo", vWhere, "", cParamXml.strOleDBConecDbf, "DBF",true);                   
            //        if (vDes =="***Inex***")
            //        {
            //            MessageBox.Show("Producto Inexistente");
            //            e.Cancel = true;

            //        }
            //    }
            //}
            sbrActuProd(txProd.Text);

        }


        private void txLin_KeyUp(object sender, KeyEventArgs e)
        {
            Control ctl;
            ctl = (Control)sender;

            if (Char.IsPunctuation(Convert.ToChar(e.KeyValue))) { e.Handled = true; return; }


            ctl.BackColor = Color.LightBlue;

            if (txLinPrep.Text == "")
            {
                lbSitu.Text = "Alta";

            }
            else
            {
                lbSitu.Text = "Modificación";
            }

            lbSitu.Visible = true;
            btGrabar.Visible = true;
            btCancel.Visible = true;
        }
        private void txLin_Leave(object sender, EventArgs e)
        {
            Control ctl;
            ctl = (Control)sender;

            try
            {
                if (txLinPrep.Text != "")
                {
                    DataGridViewRow dr = grLinPrep.CurrentRow;
                    string vVal = dr.Cells[vCampoT].Value.ToString();

                    string vNewVal = ctl.Text;
                    if (vVal != vNewVal) { return; }

                }
            }
            catch { }

            ctl.BackColor = Color.White;
        }
        private void txLin_Enter(object sender, EventArgs e)
        {
            vCab = false;
            vLin = true;
            Control ctl;
            ctl = (Control)sender;
            vCampo = ctl.Name;
            vCampoT = ctl.Tag.ToString();

        }

        #endregion


        #region Datos bS1 (BindingSource 'CabPrepEntregas')

        private void bS1_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {
            MessageBox.Show(this, "DataError bS1 : " + e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void bS1_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType.ToString() == "ItemChanged")
            {
                if (bS1.Current != null)
                {
                    sbrModifCampo("", "");

                }
            }

        }
        private void bS1_PositionChanged(object sender, EventArgs e)
        {

            cEntregas.CabPrepEntrega cabventa = (cEntregas.CabPrepEntrega)bS1.Current;
            vIni = true;
            sbrLimpiaEnt();
            sbrCargaLineas(cabventa.NumPrep.ToString());
            Application.DoEvents();
            vIni = false;
        }
        private void bS1_CurrentItemChanged(object sender, EventArgs e)
        {
        }

        #endregion

        #region Datos bS2 (BindingSource 'LinPrepEntregas')
        private void bS2_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {
            MessageBox.Show(this, "DataError bS2 : " + e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bS2_ListChanged(object sender, ListChangedEventArgs e)
        {
            //if (e.ListChangedType == ListChangedType.ItemChanged)
            //{
            //    if (bS2.Current != null)
            //    {
            //        sbrModifCampoLineas("", "");
            //    }
            //}
            //if (e.ListChangedType == ListChangedType.ItemAdded)
            //{

            //    ((cPedidosVenta.LinVenta)bS2[e.NewIndex]).Empresa = cParamXml.Emp;
            //    ((cPedidosVenta.LinVenta)bS2[e.NewIndex]).NumPed = Convert.ToInt32(txPed.Text);
            //    ((cPedidosVenta.LinVenta)bS2[e.NewIndex]).LinPed = cPedidosVenta.LinVenta.fncNumLinea(txPed.Text);
            //}

            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {

            }
        }

        private void bS2_CurrentItemChanged(object sender, EventArgs e)
        {

        }


        #endregion

        public void btCliente_Click(object sender, EventArgs e)
        {
            string vTabla = "clientes";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "ccodcli", txCodCli.Text, "", "", "", false, "", "", "", "DBF");

            if (vRes != "")
            {
                txCodCli.Text = vRes;
                bS1.RaiseListChangedEvents = true;
                bS1.EndEdit();
                sbrRefrescar();
                Application.DoEvents();
                txCodCli.Text = vRes;
                Application.DoEvents();
            }
        }

        private void frmPrepEntregas_FormClosing(object sender, FormClosingEventArgs e)
        {
            cUtil.fncGuardaEstado(this);

        }

        private void frmPrepEntregas_Shown(object sender, EventArgs e)
        {
            if (cUtil.fncExisteVentanaMDI((Form)this.MdiParent, "frmPrepEntregas", 1))
            {
                MessageBox.Show("Ya existe una ventana de 'Preparación Entregas' abierta");
                this.Close();
                return;

            }

        }

        private void grLinPrep_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            sbrCargaLinea(e.RowIndex);

        }

        private void txEstado_TextChanged(object sender, EventArgs e)
        {
            lbEstado.Text = "";
            if (txEstado.Text.Trim() == "s") { lbEstado.Text = "Parcial"; }
            if (txEstado.Text.Trim() == "T") { lbEstado.Text = "Servido"; }
            if (txEstado.Text.Trim() == "P") { lbEstado.Text = "Pendiente"; }

        }

        private void toolBus_Click(object sender, EventArgs e)
        {
            sbrBusca(vCampo);

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            vCancel = true;
            sbrLimpiaEnt();
            txProd.Focus();

        }

        private void btElim_Click(object sender, EventArgs e)
        {
            if (fncBajaLinea())
            {
                sbrCargaLineas(txPrep.Text);
                sbrLimpiaEnt();
                txProd.Focus();

            }

        }

        private void btGrabar_Click(object sender, EventArgs e)
        {
            if (lbSitu.Text == "Modificación")
            {
                if (txCanSer.Text != "")
                {
                    decimal vCanSer = Convert.ToDecimal(txCanSer.Text);
                    decimal vCan = Convert.ToDecimal(txCan.Text);
                    if (vCan < vCanSer)
                    {
                        MessageBox.Show("La cantidad no puede ser menor que la cantidad servida");
                        return;

                    }

                }

                cEntregas.LinPrepEntregas cPrepEnt = new cEntregas.LinPrepEntregas();

                DataGridViewRow dr = grLinPrep.CurrentRow;
                int vId = Convert.ToInt32(dr.Cells["Id"].Value.ToString());
                cPrepEnt.Id = vId;


                string vCT = txProd.Tag.ToString();
                string vTx = txProd.Text;
                string vVal = dr.Cells[vCT].Value.ToString();
                if (vTx != vVal) { cPrepEnt.fncGrabaCampo(vCT, vTx); }

                vCT = txDesProd.Tag.ToString();
                vTx = txDesProd.Text;
                vVal = dr.Cells[vCT].Value.ToString();
                if (vTx != vVal) { cPrepEnt.fncGrabaCampo(vCT, vTx); }



                vCT = txCan.Tag.ToString();
                vTx = txCan.Text;
                vVal = dr.Cells[vCT].Value.ToString();
                if (vTx != vVal) {
                    cPrepEnt.fncGrabaCampo(vCT, vTx);
                    cPrepEnt.fncCantidadPendiente();
                }

                vCT = dTEntrega.Tag.ToString();
                vTx = dTEntrega.Text;
                vVal = dr.Cells[vCT].Value.ToString();
                if (vTx != vVal) { cPrepEnt.fncGrabaCampo(vCT, vTx); }

                vCT = txLote.Tag.ToString();
                vTx = txLote.Text;
                vVal = dr.Cells[vCT].Value.ToString();
                if (vTx != vVal) { cPrepEnt.fncGrabaCampo(vCT, vTx); }

                vCT = txPedCli.Tag.ToString();
                vTx = txPedCli.Text;
                vVal = dr.Cells[vCT].Value.ToString();
                if (vTx != vVal) { cPrepEnt.fncGrabaCampo(vCT, vTx); }

                sbrCargaLineas(txPrep.Text);
                sbrLimpiaEnt();
                txProd.Focus();

            }

            if (lbSitu.Text == "Alta")
            {
                if (txProd.Text == "")
                {
                    MessageBox.Show("El Producto NO esta informado");
                    txProd.Focus();
                    return;
                }
                if ((txCan.Text == "") | (txCan.Text == "0"))
                {
                    MessageBox.Show("La cantidad NO esta informada");
                    txCan.Focus();
                    return;
                }

                if (fncAltaLinea())
                {
                    sbrCargaLineas(txPrep.Text);
                    sbrLimpiaEnt();
                    txProd.Focus();
                }



            }
        }

        private void btProducto_Click(object sender, EventArgs e)
        {
            string vTabla = "GC_ProductoAnexos";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "Producto", txProd.Text, "", "", "ID,Empresa", false, "", "", "", "SQL");

            if (vRes != "")
            {
                txProd.Text = vRes;
                //bS1.RaiseListChangedEvents = true;
                //bS1.EndEdit();
                //sbrRefrescar();
                Application.DoEvents();
                txProd.Text = vRes;
                Application.DoEvents();
                txProd.Focus();
            }

        }

        private void txProd_TextChanged(object sender, EventArgs e)
        {
            sbrActuProd(txProd.Text);
        }

        private void txProd_Validating(object sender, CancelEventArgs e)
        {
            sbrActuProd(txProd.Text);


            if (txProd.Text != "")
            {
                if (txLinPrep.Text == "")
                {
                    lbSitu.Text = "Alta";

                }
                else
                {
                    lbSitu.Text = "Modificación";
                }

                lbSitu.Visible = true;
                btGrabar.Visible = true;
                btCancel.Visible = true;
            }


        }

        private void btEntregar_Click(object sender, EventArgs e)
        {

            frmEntregaMerc frm = new frmEntregaMerc();
            frm.vProd = txProd.Text;
            frm.vDes = txDesProd.Text;
            frm.vCanOrig = Convert.ToDecimal(txCan.Text);
            frm.vLin = Convert.ToInt32(txLinPrep.Text);
            frm.vNumPrep = Convert.ToInt32(txPrep.Text);
            if (txPed.Text == "") txPed.Text = "0";
            if (txLinPed.Text == "") txLinPed.Text = "0";
            frm.vNumPed = Convert.ToInt32(txPed.Text);
            frm.vLinPed = Convert.ToInt32(txLinPed.Text);


            frm.ShowDialog();

            decimal vCanGrab = frm.vCanGrab;

            if (vCanGrab != 0)
            {
                cEntregas.CabPrepEntrega cabventa = (cEntregas.CabPrepEntrega)bS1.Current;
                vIni = true;
                sbrLimpiaEnt();
                sbrCargaLineas(cabventa.NumPrep.ToString());
                Application.DoEvents();
                vIni = false;
               
            }


        }

        private void btImprimir_Click(object sender, EventArgs e)
        {

            DataTable dt = fncCargaPrep();

            DataView dtv = dt.DefaultView;
            dtv.RowFilter = "numprep = " + txPrep.Text;   
            DataTable dtLista = dtv.ToTable();
            cInformes.Imp = (cParamXml.Imp == "True") ? true : false;
            cInformes.sbrPrintPrepPen(cParamXml.Emp.ToString(), dtLista);

        }

        private void btPrintCertCal_Click(object sender, EventArgs e)
        {
            string vSql = cConstantes.SQL_Cert_Calc1;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?Prep]", txPrep.Text);
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));

            cInformes.Imp = (cParamXml.Imp == "True") ? true : false;
            cInformes.sbrPrintCertCal(cParamXml.Emp.ToString(), dt);


        }


    }
}
