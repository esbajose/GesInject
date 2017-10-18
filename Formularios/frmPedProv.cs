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
    public partial class frmPedProv : Form
    {
        private bool vCancel = false;
        private bool vIni = true;
        private bool vCab = false;
        private bool vLin = false;
        private string vCampo = "";
        private string vCampoT = "";
        private string vVal = "";

        #region Objetos Form

        public frmPedProv()
        {
            InitializeComponent();
        }

        private void frmPedProv_Load(object sender, EventArgs e)
        {
            this.Text = "Pedidos Proveedores ";
            sbrCargaPedidos();
            sbrBindCampos(this);
            vIni = true;

        }
        private void frmPedProv_KeyUp(object sender, KeyEventArgs e)
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
            sbrBajaPedido();
        }
        private void btAlta_Click(object sender, EventArgs e)
        {
            string vMen = "¿Dar de Alta un Nuevo Pedido?";
            string vTit = "Pedidos";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sbrAltaPedido();
                vCab = true;
                txCodProv.Focus();
            }

        }
        private void btRefrescar_Click(object sender, EventArgs e)
        {
            //sbrRefrescar();
            //sbrRefrescarLin();
        }


        #region Tool

        private void toolBus_Click(object sender, EventArgs e)
        {
            sbrBusca(vCampo);
        }

        private void toolCopiar_Click(object sender, EventArgs e)
        {
            sbrTool("Copiar");
        }

        private void toolCortar_Click(object sender, EventArgs e)
        {
            sbrTool("Cortar");

        }

        private void toolPegar_Click(object sender, EventArgs e)
        {
            sbrTool("Pegar");
        }


        #endregion


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

        #region CabPedidos
        private void sbrCargaPedidos()
        {
            btDel.Visible = false;
            try
            {
                bS1.DataSource = cPedidosCompra.Lista();
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
            bS1.DataSource = cPedidosCompra.Lista();
        }
        private void sbrAltaPedido()
        {
            try
            {
                int vId = 0;
                cPedidosCompra.CabCompra cabcompra = (cPedidosCompra.CabCompra)bS1.Current;
                if (cabcompra==null)
                {
                    cPedidosCompra.CabCompra cabcompra2 =new cPedidosCompra.CabCompra();
                    vId = cabcompra2.fncAlta();

                }
                else
                {
                    vId = cabcompra.fncAlta();
                }
                if (vId == 0)
                {
                    MessageBox.Show("No se ha podido dar de Alta el Pedido");
                    return;
                }

                sbrActuDatos();

                bS1.MoveLast();
                //bS1.Add(cabven);
                //bS1.MoveLast();
                txCodProv.Focus();
                btDel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido dar de Alta el Pedido :'" + ex.Message + "'");
                bS1.CancelEdit();

            }
        }
        private void sbrBajaPedido()
        {
            if (bS1.Current != null)
            {
                string vMen = "Esta seguro de Eliminar el registro actual?";
                string vTit = "Eliminar";
                if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        cPedidosCompra.CabCompra cabCompra = (cPedidosCompra.CabCompra)bS1.Current;
                        if (!cabCompra.fncBaja(cabCompra.NumPed.ToString()))
                        {
                            MessageBox.Show("No se ha podido Eliminar el Pedido");
                            bS1.CancelEdit();
                        }
                        else
                        {
                            bS1.Remove(cabCompra);
                            sbrCargaPedidos();
                            btDel.Visible = false;

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se ha podido Eliminar el Pedido :'" + ex.Message + "'");
                        bS1.CancelEdit();

                    }

                }

            }

        }
        private void sbrModifCampo(string vCampo, string vValor)
        {
            cPedidosCompra.CabCompra cabCompra = (cPedidosCompra.CabCompra)bS1.Current;

            if (cabCompra.aCampoModif != "") { vCampo = cabCompra.aCampoModif; }
            if (cabCompra.aValor != "") { vValor = cabCompra.aValor; }

            if (!cabCompra.fncGrabaCampo(vCampo, vValor))
            {
                MessageBox.Show("No se ha podido Grabar el Dato");
                bS1.CancelEdit();
            }

            if (vCampo == "CodProv")
            {
                sbrActuProv(vValor);
            }

        }
        private void sbrRefrescar()
        {
            cPedidosCompra.CabCompra cabCompra = (cPedidosCompra.CabCompra)bS1.Current;
            string vcabCompra = cabCompra.NumPed.ToString();
            int vReg = bS1.Position;
            sbrActuDatos();
            vReg = cPedidosCompra.fncBuscaIndexCabPed(bS1, vcabCompra);
            bS1.Position = vReg;
            if (txPed.Text != "") { btDel.Visible = false; }
        }
        public void sbrTecla(string vTecla)
        {
            switch (vTecla)
            {
                case "F3":
                    sbrAltaPedido();
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

            if (vCampo == "txPed")
            {
                vTabla = "[GC_CabPedido]";
                vWhere = "";
                vRes = cUtil.fncLista(vTabla, cParamXml.strConec, "NumPed", txPed.Text, vWhere);

                if (vRes != "")
                {
                    int vReg = cPedidosCompra.fncBuscaIndexCabPed(bS1, vRes);
                    bS1.Position = vReg;
                }
            }
            if (vCampo == "txCodProv")
            {

                btProveedor_Click(btProveedor, null);

            }

            if (vCampo == "txProd")
            {
                vTabla = "articulo";
                vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "cref", txProd.Text, "", "", "", false, "", "", "", "DBF");

                if (vRes != "")
                {
                    txProd.Text = vRes;
                }

            }



            if (vCampo == "txFPago")
            {
                vTabla = "fpago";
                vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "ccodpago", txFPago.Text, "", "", "", false, "", "", "", "DBF");

                if (vRes != "")
                {
                    txFPago.Text = vRes;
                    Application.DoEvents();
                    sbrRefrescar();
                }
            }
            if (vCampo == "txDivisa")
            {
                vTabla = "divisas";
                vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "ccoddiv", txDivisa.Text, "", "", "", false, "", "", "", "DBF");

                if (vRes != "")
                {
                    txDivisa.Text = vRes;
                    Application.DoEvents();
                    sbrRefrescar();
                }
            }



        }
        private void sbrActuProv(string vProv)
        {
            DataRow dr;
            string vWhere = " ccodpro = '" + vProv + "' ";
            dr = cUtil.fncTraeCampos("proveedo", vWhere, cParamXml.strOleDBConecDbf, "DBF");
            //lbNomCli.Text = "";
            if (dr != null)
            {

                sbrModifCampo("nomprov", dr["cnompro"].ToString());
                sbrModifCampo("dirección", dr["cdirpro"].ToString());
                sbrModifCampo("Población", dr["cpobpro"].ToString());
                sbrModifCampo("CP", dr["cptlpro"].ToString());
                sbrModifCampo("Provincia", dr["cpobpro"].ToString());
                sbrModifCampo("FPago", dr["ccodpago"].ToString());
                sbrModifCampo("Divisa", dr["ccodDiv"].ToString());
                Application.DoEvents();

            }
        }


        #endregion

        #region LinPedidos

        private void sbrCargaLineas(string vPedido)
        {
            try
            {
                this.bS2.DataSource = cPedidosCompra.ListaLineas(vPedido);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void sbrModifCampoLineas(string vCampo, string vValor)
        {
            cPedidosCompra.LinCompra linp = (cPedidosCompra.LinCompra)bS2.Current;

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

        private void sbrActuProd(string vCli)
        {
            string vWhere = " CREF = '" + txProd.Text.Trim() + "' ";
            DataRow dr;

            dr = cUtil.fncTraeCampos("articulo", vWhere, cParamXml.strOleDBConecDbf, "DBF");

            txDesProd.Text = "";
            if (dr != null)
            {
                txDesProd.Text = dr["cdetalle"].ToString();
                txPrecio.Text = dr["NPVP"].ToString();
                string vTIva = dr["CTIPOIVA"].ToString();

                string vWherei = " ctipoiva = '" + vTIva + "' ";
                string vDesIva = cUtil.fncTraeCampo("nporciva", "ivas", vWherei, "", cParamXml.strOleDBConecDbf, "DBF", false);
                if (vDesIva == "")
                {
                    txIva.Text = "0";
                }
                else
                {
                    txIva.Text = vDesIva;
                }

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
            bS2.DataSource = cPedidosCompra.ListaLineas(vPed);

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
            cPedidosCompra.LinCompra linp = (cPedidosCompra.LinCompra)bS2.Current;
            string vPed = linp.NumPed;
            int vReg = bS2.Position;
            sbrActuDatosLinPed(linp.NumPed.ToString());
            vReg = cPedidosCompra.fncBuscaIndexLinPed(bS2, vPed);
            bS2.Position = vReg;
        }

        private bool fncBajaLinea()
        {
            bool vOk = true;
            if (bS2.Current != null)
            {

                cPedidosCompra.LinCompra linp = (cPedidosCompra.LinCompra)bS2.Current;
                if (linp.CantidadEntregada > 0)
                {
                    MessageBox.Show("Esta Linea tiene cantidad servida NO se puede eliminar");
                    bS2.CancelEdit();
                    vOk = false;
                    return vOk;
                }
                string vMen = "Esta seguro de Eliminar la linea?";
                string vTit = "Eliminar";
                if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        if (!linp.fncBaja(linp.NumPed.ToString()))
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

        private void sbrCargaLinea(int vFil)
        {
            sbrLimpiaEnt();
            //if (vIni) { return; }

            string vLin = grLinPed.Rows[vFil].Cells["LinPed"].Value.ToString();
            string vProd = grLinPed.Rows[vFil].Cells["Producto"].Value.ToString();
            string vDes = grLinPed.Rows[vFil].Cells["Descripción"].Value.ToString();
            string vCan = grLinPed.Rows[vFil].Cells["Cantidad"].Value.ToString();
            string vCanEnt = grLinPed.Rows[vFil].Cells["CantidadEntregada"].Value.ToString();
            string vIva = grLinPed.Rows[vFil].Cells["IVA"].Value.ToString();
            string vPrecio = grLinPed.Rows[vFil].Cells["Precio"].Value.ToString();
            string vDTO = grLinPed.Rows[vFil].Cells["DTO"].Value.ToString();

            txLinPed.Text = vLin;
            txProd.Text = vProd;
            txDesProd.Text = vDes;
            txCan.Text = vCan;
            txCanEnt.Text = vCanEnt;
            txIva.Text = vIva;
            txPrecio.Text = vPrecio;
            txDTO.Text = vDTO;

            btElim.Visible = true;
            //btGrabar.Visible = true;
            btCancel.Visible = true;
            //lbSitu.Text = "Modificación";



            return;
        }

        private void sbrLimpiaEnt()
        {
            txLinPed.Text = "";
            txProd.Text = "";
            txDesProd.Text = "";
            txCan.Text = "";
            txCanEnt.Text = "";
            txIva.Text = "";
            txPrecio.Text = "";
            txDTO.Text = "";

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
            cPedidosCompra.LinCompra cLinCompra = new cPedidosCompra.LinCompra();
            if (txCan.Text == "") { txCan.Text = "0"; }
            if (txDTO.Text == "") { txDTO.Text = "0"; }
            if (txIva.Text == "") { txIva.Text = "0"; }
            if (txPrecio.Text == "") { txPrecio.Text = "0"; }


            cLinCompra.Cantidad = Convert.ToDecimal(txCan.Text);
            cLinCompra.CantidadEntregada = 0;
            cLinCompra.Descripción = txDesProd.Text;
            cLinCompra.DTO = Convert.ToDecimal(txDTO.Text);
            cLinCompra.Empresa = cParamXml.Emp;
            cLinCompra.IVA = Convert.ToInt16(txIva.Text);
            cLinCompra.NumPed = txPed.Text;
            cLinCompra.Precio = Convert.ToDecimal(txPrecio.Text);
            cLinCompra.Producto = txProd.Text;
            vOk = cLinCompra.fncAltaLin();

            return vOk;

        }

        #endregion

        #endregion

        #region Binding (CabPedidos)


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

        #region Binding (LinPedidos)

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

        }


        private void txLin_KeyUp(object sender, KeyEventArgs e)
        {

            Control ctl;
            ctl = (Control)sender;

            if (Char.IsPunctuation(Convert.ToChar(e.KeyValue))) { e.Handled = true; return; }


            ctl.BackColor = Color.LightBlue;

            if (txLinPed.Text == "")
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
                if (txLinPed.Text != "")
                {
                    DataGridViewRow dr = grLinPed.CurrentRow;
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


        #region Datos bS1 (BindingSource 'CabPedidos')

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
            cPedidosCompra.CabCompra cabcompra = (cPedidosCompra.CabCompra)bS1.Current;
            vIni = true;
            sbrLimpiaEnt();
            sbrCargaLineas(cabcompra.NumPed);
            Application.DoEvents();
            vIni = false;

        }

        #endregion

        #region Datos bS2 (BindingSource 'LinPedidos')
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

            //    ((cPedidosCompra.LinCompra)bS2[e.NewIndex]).Empresa = cParamXml.Emp;
            //    ((cPedidosCompra.LinCompra)bS2[e.NewIndex]).NumPed = Convert.ToInt32(txPed.Text);
            //    ((cPedidosCompra.LinCompra)bS2[e.NewIndex]).LinPed = cPedidosCompra.LinCompra.fncNumLinea(txPed.Text);
            //}

            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {

            }
        }



        #endregion




        private void txEstado_TextChanged(object sender, EventArgs e)
        {
            lbEstado.Text = "";
            if (txEstado.Text.Trim() == "s") { lbEstado.Text = "Parcial"; }
            if (txEstado.Text.Trim() == "S") { lbEstado.Text = "Servido"; }
            if (txEstado.Text.Trim() == "P") { lbEstado.Text = "Pendiente"; }
        }

        private void bindingNavigatorPositionItem_TextChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorPositionItem_Validated(object sender, EventArgs e)
        {

        }

        public void btProveedor_Click(object sender, EventArgs e)
        {
            string vTabla = "proveedo";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "ccodpro", txCodProv.Text, "", "", "", false, "", "", "", "DBF");

            if (vRes != "")
            {
                txCodProv.Text = vRes;
                bS1.RaiseListChangedEvents = true;
                bS1.EndEdit();
                sbrRefrescar();
                Application.DoEvents();
                txCodProv.Text = vRes;
                Application.DoEvents();
            }

        }

        private void txCodProv_TextChanged(object sender, EventArgs e)
        {
            //DataRow dr;
            //string vWhere = " ccodcli = '" + txCodCli.Text + "' ";
            //dr = cUtil.fncTraeCampos("clientes", vWhere, cParamXml.strOleDBConecDbf, "DBF");
            //lbNomCli.Text = "";
            //if (dr != null)
            //{
            //    lbNomCli.Text = dr["cnomcli"].ToString();
            ////    txdirección.Text = dr["cdircli"].ToString();
            ////    txPoblación.Text = dr["cpobcli"].ToString();
            ////    txCP.Text = dr["cptlcli"].ToString();
            ////    txProvincia.Text = dr["cpobcli"].ToString();
            //}

        }

        private void grLinPed_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            sbrCargaLinea(e.RowIndex);

        }

        private void grLinPed_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //sbrCargaLinea(e.RowIndex);

        }

        private void grLinPed_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = !fncBajaLinea();

        }


        private void btCancel_Click(object sender, EventArgs e)
        {
            vCancel = true;
            sbrLimpiaEnt();
            txProd.Focus();
        }

        private void txProd_TextChanged(object sender, EventArgs e)
        {

            sbrActuProd(txProd.Text);


        }

        private void btGrabar_Click(object sender, EventArgs e)
        {
            if (lbSitu.Text == "Modificación")
            {
                if (txCanEnt.Text != "")
                {
                    decimal vCanSer = Convert.ToDecimal(txCanEnt.Text);
                    decimal vCan = Convert.ToDecimal(txCan.Text);
                    if (vCan < vCanSer)
                    {
                        MessageBox.Show("La cantidad no puede ser menor que la cantidad servida");
                        return;

                    }

                }
                cPedidosCompra.LinCompra cLinCompra = new cPedidosCompra.LinCompra();

                DataGridViewRow dr = grLinPed.CurrentRow;
                int vId = Convert.ToInt32(dr.Cells["Id"].Value.ToString());
                cLinCompra.Id = vId;


                string vCT = txProd.Tag.ToString();
                string vTx = txProd.Text;
                string vVal = dr.Cells[vCT].Value.ToString();
                if (vTx != vVal) { cLinCompra.fncGrabaCampo(vCT, vTx); }

                vCT = txDesProd.Tag.ToString();
                vTx = txDesProd.Text;
                vVal = dr.Cells[vCT].Value.ToString();
                if (vTx != vVal) { cLinCompra.fncGrabaCampo(vCT, vTx); }


                vCT = txPrecio.Tag.ToString();
                vTx = txPrecio.Text;
                vVal = dr.Cells[vCT].Value.ToString();
                if (vTx != vVal) { cLinCompra.fncGrabaCampo(vCT, vTx); }

                vCT = txIva.Tag.ToString();
                vTx = txIva.Text;
                vVal = dr.Cells[vCT].Value.ToString();
                if (vTx != vVal) { cLinCompra.fncGrabaCampo(vCT, vTx); }

                vCT = txCan.Tag.ToString();
                vTx = txCan.Text;
                vVal = dr.Cells[vCT].Value.ToString();
                if (vTx != vVal) { cLinCompra.fncGrabaCampo(vCT, vTx); }


                sbrCargaLineas(txPed.Text);
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
                    sbrCargaLineas(txPed.Text);
                    sbrLimpiaEnt();
                    txProd.Focus();
                }



            }
        }

        private void btFPago_Click(object sender, EventArgs e)
        {

        }

        private void btDivisa_Click(object sender, EventArgs e)
        {
            string vTabla = "divisas";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "ccoddiv", txDivisa.Text, "", "", "", false, "", "", "", "DBF");

            if (vRes != "")
            {
                txDivisa.Text = vRes;
                bS1.RaiseListChangedEvents = true;
                bS1.EndEdit();
                sbrRefrescar();
            }

        }

        private void btProducto_Click(object sender, EventArgs e)
        {
            string vTabla = "articulo";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "CREF", txProd.Text, "", "", "", false, "", "", "", "DBF");

            if (vRes != "")
            {
                txProd.Text = vRes;
                Application.DoEvents();
                txProd.Text = vRes;
                Application.DoEvents();
                txProd.Focus();
            }
        }

        private void btElim_Click(object sender, EventArgs e)
        {
            if (fncBajaLinea())
            {
                sbrCargaLineas(txPed.Text);
                sbrLimpiaEnt();
                txProd.Focus();

            }
        }

        private void bS2_CurrentChanged(object sender, EventArgs e)
        {

        }


    }
}
