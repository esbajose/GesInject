using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GesInject.Clases;
using jControles.Clases;


namespace GesInject.Formularios
{
    public partial class frmAlbProv : Form
    {
        private bool vCancel = false;
        private bool vIni = true;
        private bool vCab = false;
        private bool vLin = false;
        private string vCampo = "";
        private string vCampoT = "";
        private string vVal = "";
        public ToolStripStatusLabel stalb = null;


        cAlbaranesCompra.LinAlbCompra oLinAlb = new cAlbaranesCompra.LinAlbCompra();

        #region Objetos Form

        public frmAlbProv()
        {
            InitializeComponent();
        }

        private void frmAlbProv_Load(object sender, EventArgs e)
        {

            ((frmPrinc)this.MdiParent).stalbProyecto.Text = "Proyecto:";
            this.Text = "Albaranes Proveedores ";
            sbrCargaAlbaranes();
            sbrBindCampos(this);
            vIni = true;

        }
        private void frmAlbProv_KeyUp(object sender, KeyEventArgs e)
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
            sbrBajaAlbaran();
        }
        private void btAlta_Click(object sender, EventArgs e)
        {
            string vMen = "¿Dar de Alta un Nuevo Albaran?";
            string vTit = "Albaranes";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sbrAltaAlbaran();
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

        #region CabAlbaranes
        private void sbrCargaAlbaranes()
        {
            btDel.Visible = false;
            try
            {
                bS1.DataSource = cAlbaranesCompra.Lista();
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
            bS1.DataSource = cAlbaranesCompra.Lista();
        }
        private void sbrAltaAlbaran()
        {
            try
            {
                int vId = 0;
                cAlbaranesCompra.CabAlbCompra cabcompra = (cAlbaranesCompra.CabAlbCompra)bS1.Current;
                if (cabcompra==null)
                {
                    cAlbaranesCompra.CabAlbCompra cabcompra2 = new cAlbaranesCompra.CabAlbCompra();
                    vId = cabcompra2.fncAlta();

                }
                else
                {
                    vId = cabcompra.fncAlta();
                }
                if (vId == 0)
                {
                    MessageBox.Show("No se ha podido dar de Alta el Albaran");
                    return;
                }

                sbrActuDatos();

                bS1.MoveLast();
                txCodProv.Focus();
                btDel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido dar de Alta el Albaran :'" + ex.Message + "'");
                bS1.CancelEdit();

            }
        }
        private void sbrBajaAlbaran()
        {
            if (bS1.Current != null)
            {
                string vMen = "Esta seguro de Eliminar el registro actual?";
                string vTit = "Eliminar";
                if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        cAlbaranesCompra.CabAlbCompra cabCompra = (cAlbaranesCompra.CabAlbCompra)bS1.Current;
                        if (!cabCompra.fncBaja(cabCompra.NumPed.ToString()))
                        {
                            MessageBox.Show("No se ha podido Eliminar el Albaran");
                            bS1.CancelEdit();
                        }
                        else
                        {
                            bS1.Remove(cabCompra);
                            sbrCargaAlbaranes();
                            btDel.Visible = false;

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se ha podido Eliminar el Albaran :'" + ex.Message + "'");
                        bS1.CancelEdit();

                    }

                }

            }

        }
        private void sbrModifCampo(string vCampo, string vValor)
        {
            cAlbaranesCompra.CabAlbCompra cabCompra = (cAlbaranesCompra.CabAlbCompra)bS1.Current;

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
            cAlbaranesCompra.CabAlbCompra cabCompra = (cAlbaranesCompra.CabAlbCompra)bS1.Current;
            string vcabCompra = cabCompra.NumPed.ToString();
            int vReg = bS1.Position;
            sbrActuDatos();
            vReg = cAlbaranesCompra.fncBuscaIndexCabAlb(bS1, vcabCompra);
            bS1.Position = vReg;
            if (txAlb.Text != "") { btDel.Visible = false; }
        }
        public void sbrTecla(string vTecla)
        {
            switch (vTecla)
            {
                case "F3":
                    sbrAltaAlbaran();
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

            if (vCampo == "txAlb")
            {
                vTabla = "[GC_CabAlbProv]";
                vWhere = "";
                vRes = cUtil.fncLista(vTabla, cParamXml.strConec, "NumAlb", txAlb.Text, vWhere);

                if (vRes != "")
                {
                    int vReg = cAlbaranesCompra.fncBuscaIndexCabAlb(bS1, vRes);
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

        #region LinAlbaranes

        private void sbrCargaLineas(string vAlbaran)
        {
            try
            {
                this.bS2.DataSource = cAlbaranesCompra.ListaLineas(vAlbaran);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void sbrModifCampoLineas(string vCampo, string vValor)
        {
            cAlbaranesCompra.LinAlbCompra linp = (cAlbaranesCompra.LinAlbCompra)bS2.Current;

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
                txLote.Text = dr["NPVP"].ToString();
                string vTIva = dr["CTIPOIVA"].ToString();

                string vWherei = " ctipoiva = '" + vTIva + "' ";
                string vDesIva = cUtil.fncTraeCampo("nporciva", "ivas", vWherei, "", cParamXml.strOleDBConecDbf, "DBF", false);
                if (vDesIva == "")
                {
                    txRecepPor.Text = "0";
                }
                else
                {
                    txRecepPor.Text = vDesIva;
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
            bS2.DataSource = cAlbaranesCompra.ListaLineas(vPed);

        }

        public void sbrGrabado(Control vControles,bool vGrab)
        {
            foreach (Control vctl in vControles.Controls)
            {
                if (vctl.Controls.Count > 0)
                {
                    sbrGrabado(vctl,vGrab);
                }
                if (vctl.Tag != null)
                {
                    string vTipo = vctl.GetType().ToString();
                    string vTagOp = vctl.Tag.ToString();
                    //string vbind = cUtil.Piece(vTagOp, "#", 1);

                    vctl.Enabled = !vGrab;

                }
            }

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
            cAlbaranesCompra.LinAlbCompra linp = (cAlbaranesCompra.LinAlbCompra)bS2.Current;
            string vPed = linp.NumAlb;
            int vReg = bS2.Position;
            sbrActuDatosLinPed(linp.NumAlb.ToString());
            vReg = cAlbaranesCompra.fncBuscaIndexLinPed(bS2, vPed);
            bS2.Position = vReg;
        }

        private bool fncBajaLinea()
        {
            bool vOk = true;
            if (bS2.Current != null)
            {

                cAlbaranesCompra.LinAlbCompra linp = (cAlbaranesCompra.LinAlbCompra)bS2.Current;

                //if (linp.CantidadEntregada > 0)
                //{
                //    MessageBox.Show("Esta Linea tiene cantidad servida NO se puede eliminar");
                //    bS2.CancelEdit();
                //    vOk = false;
                //    return vOk;
                //}


                string vMen = "Esta seguro de Eliminar la linea?";
                string vTit = "Eliminar";
                if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        if (!linp.fncBaja(linp.NumAlb.ToString()))
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
           
            if (cParamXml.Debug == "True") {((frmPrinc)this.MdiParent).stalbProyecto.Text = "Proyecto: Paso 1";Application.DoEvents();}

            string vLin = grLinAlb.Rows[vFil].Cells["Linea"].Value.ToString();
            string vProd = grLinAlb.Rows[vFil].Cells["Producto"].Value.ToString();
            string vDes = grLinAlb.Rows[vFil].Cells["Descripción"].Value.ToString();
            string vCan = grLinAlb.Rows[vFil].Cells["Cantidad"].Value.ToString();
            string vLote = grLinAlb.Rows[vFil].Cells["Lote"].Value.ToString();
            string vObs = grLinAlb.Rows[vFil].Cells["Obs"].Value.ToString();
            string vGrabado = grLinAlb.Rows[vFil].Cells["Grabado"].Value.ToString();
            string vRecep = grLinAlb.Rows[vFil].Cells["RecepcionadoPor"].Value.ToString();
            string vUbi = grLinAlb.Rows[vFil].Cells["Ubi"].Value.ToString();
            string vNumSerie = grLinAlb.Rows[vFil].Cells["NumSerie"].Value.ToString();


            cAlbaranesCompra.LoteCert oCert = new cAlbaranesCompra.LoteCert();

            oCert.fncExiste(cParamXml.Emp, vProd, vLote);


            txCert.Text = oCert.Cert;

            
            txLinAlb.Text = vLin;
            txProd.Text = vProd;

            txDesProd.Text = vDes;
            txCan.Text = vCan;
            txLote.Text = vLote;
            txObs.Text = vObs;



            string vCertSN = "NO";
            oLinAlb.Cantidad = Convert.ToDecimal(vCan);
            oLinAlb.Lote = vLote;
            oLinAlb.RecepcionadoPor = txRecepPor.Text;
            if (txCert.Text != "") vCertSN = "SI";
            oLinAlb.Cert = vCertSN;
            oLinAlb.Producto = vProd;
            oLinAlb.Descripción = vDes;
            oLinAlb.CodProv =txCodProv.Text;
            oLinAlb.NombreProv = lbNomCli.Text;
            oLinAlb.SuAlb = txSuAlb.Text;
            oLinAlb.Ubi = vUbi;
            oLinAlb.NumSerie = vNumSerie;


            if (vGrabado == "1")
            {
                btElim.Visible = false;
                sbrGrabado(panel1, true);
            }
            else
            {
                btElim.Visible = true;
                sbrGrabado(panel1, false);

            }



            btEtiqueta.Visible = true;
            btCancel.Visible = true;



            return;
        }

        private void sbrLimpiaEnt()
        {
            txLinAlb.Text = "";
            txProd.Text = "";
            txDesProd.Text = "";
            txCan.Text = "";
            txRecepPor.Text = "";
            txObs.Text = "";
            txLote.Text = "";
            txCert.Text = "";

            btElim.Visible = false;
            btEtiqueta.Visible = false;
            btGrabar.Visible = false;
            btCancel.Visible = false;

            lbSitu.Text = "";
            lbSitu.Visible = false;
            //txProd.Focus();
        }

        private bool fncAltaLinea()
        {
            bool vOk = false;
            cAlbaranesCompra.LinAlbCompra cLinCompra = new cAlbaranesCompra.LinAlbCompra();
            if (txCan.Text == "") { txCan.Text = "0"; }
            if (txRecepPor.Text == "") { txRecepPor.Text = "0"; }
            if (txLote.Text == "") { txLote.Text = "0"; }


            cLinCompra.Cantidad = Convert.ToDecimal(txCan.Text);
            cLinCompra.Descripción = txDesProd.Text;
            cLinCompra.Empresa = cParamXml.Emp;
            cLinCompra.Producto = txProd.Text;
            vOk = cLinCompra.fncAltaLin();

            return vOk;

        }


        private bool fncGrabaLinea()
        {
            bool vOk = false;
            //if (txCanEnt.Text != "")
            //{
            //    decimal vCanSer = Convert.ToDecimal(txCanEnt.Text);
            //    decimal vCan = Convert.ToDecimal(txCan.Text);
            //    if (vCan < vCanSer)
            //    {
            //        MessageBox.Show("La cantidad no puede ser menor que la cantidad servida");
            //        return;

            //    }

            //}

            cAlbaranesCompra.LinAlbCompra cLinCompra = new cAlbaranesCompra.LinAlbCompra();

            DataGridViewRow dr = grLinAlb.CurrentRow;
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


            vCT = txLote.Tag.ToString();
            vTx = txLote.Text;
            vVal = dr.Cells[vCT].Value.ToString();
            if (vTx != vVal) { cLinCompra.fncGrabaCampo(vCT, vTx); }

            vCT = txRecepPor.Tag.ToString();
            vTx = txRecepPor.Text;
            vVal = dr.Cells[vCT].Value.ToString();
            if (vTx != vVal) { cLinCompra.fncGrabaCampo(vCT, vTx); }

            vCT = txCan.Tag.ToString();
            vTx = txCan.Text;
            vVal = dr.Cells[vCT].Value.ToString();
            if (vTx != vVal) { cLinCompra.fncGrabaCampo(vCT, vTx); }

            vCT = txObs.Tag.ToString();
            vTx = txObs.Text;
            vVal = dr.Cells[vCT].Value.ToString();
            if (vTx != vVal) { cLinCompra.fncGrabaCampo(vCT, vTx); }

            vCT = txPedido.Tag.ToString();
            vTx = txPedido.Text;
            vVal = dr.Cells[vCT].Value.ToString();
            if (vTx != vVal) { cLinCompra.fncGrabaCampo(vCT, vTx); }
            
            vOk = fncGrabaCert(txCert.Text, txProd.Text, txLote.Text);


            vOk = true;

            return vOk;

        }


        private bool fncGrabaCert(string vFich, string vProd, string vLote)
        {
            bool vOk = false;



            string vNomFich = Path.GetFileName(vFich);

            string vSql = cConstantes.SQL_Delete_LoteCert;
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?Producto]", vProd);
            vSql = vSql.Replace("[?Lote]", vLote);

            int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConec);



            vSql = cConstantes.SQL_Insert_LoteCert;
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?Producto]", vProd);
            vSql = vSql.Replace("[?Lote]", vLote);
            vSql = vSql.Replace("[?Cert]", vNomFich);

            viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConec);

            //if (viOk == 0) return vOk;



            if (cParamXml.DirCerMat == "")
            {
                MessageBox.Show("No esta configurado el directorio de Certificados");
                return vOk;
            }

            if (!Directory.Exists(cParamXml.DirCerMat))
            {
                MessageBox.Show("No existe el directorio de Certificados: " + cParamXml.DirCerMat);
                return vOk;

            }
            if (vFich == "")
            {
                MessageBox.Show("No se ha informado el Certificados");
                return vOk;
            }

            string vFichDest = cParamXml.DirCerMat + @"\" + vNomFich;

            vOk = true;

            cUtil oUtil = new cUtil();
            if (vFich.LastIndexOf(@"\") != -1)
            {
                vOk = oUtil.fncCopiaFichero(vFich, vFichDest, false, false, true);
            }



            return vOk;
        }

        #endregion

        #endregion

        #region Binding (CabAlbaranes)

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

                        vctl.KeyUp += new KeyEventHandler(txLin_KeyUp);
                        vctl.Leave += new EventHandler(txLin_Leave);
                        vctl.Validating += new CancelEventHandler(txLin_Validating);
                        vctl.Enter += txLin_Enter;

                    }
                }
            }

        }

        //private void tx_Validating(object sender, CancelEventArgs e)
        //{
        //    Control ctl;
        //    ctl = (Control)sender;
        //    string vName = ctl.Name;
        //    string vTex = ctl.Text;


        //    if (vName == "txPed")
        //    {
        //        if (vTex == "")
        //        {
        //            MessageBox.Show("El Campo 'Nº Albaran' es un Indice,NO puede estar en blanco");
        //            e.Cancel = true;
        //            btDel.Visible = true;
        //        }
        //    }

        //}
        //private void tx_Leave(object sender, EventArgs e)
        //{
        //    Control ctl;
        //    ctl = (Control)sender;
        //    ctl.BackColor = Color.White;

        //}
        //private void tx_Enter(object sender, EventArgs e)
        //{
        //    vCab = true;
        //    vLin = false;
        //    Control ctl;
        //    ctl = (Control)sender;
        //    vCampo = ctl.Name;
        //}

        #endregion

        #region Binding (LinAlbaranes)

        private void txLin_Validating(object sender, CancelEventArgs e)
        {
            Control ctl;
            ctl = (Control)sender;
            string vName = ctl.Name;
            string vTex = ctl.Text;


            //if (vName == "txPed")
            //{
            //    if (vTex == "")
            //    {
            //        MessageBox.Show("El Campo 'Nº Albaran' es un Indice,NO puede estar en blanco");
            //        e.Cancel = true;
            //        btDel.Visible = true;
            //    }
            //}


        }
        private void txLin_KeyUp(object sender, KeyEventArgs e)
        {
            Control ctl;
            ctl = (Control)sender;

            if (Char.IsPunctuation(Convert.ToChar(e.KeyValue))) { e.Handled = true; return; }


            ctl.BackColor = Color.LightBlue;

            if (txLinAlb.Text == "")
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
                if (txLinAlb.Text != "")
                {
                    DataGridViewRow dr = grLinAlb.CurrentRow;
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


        #region Datos bS1 (BindingSource 'CabAlbaranes')

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
            cAlbaranesCompra.CabAlbCompra cabcompra = (cAlbaranesCompra.CabAlbCompra)bS1.Current;
            vIni = true;
            sbrLimpiaEnt();
            sbrCargaLineas(cabcompra.NumAlb);
            Application.DoEvents();
            vIni = false;

        }

        #endregion

        #region Datos bS2 (BindingSource 'LinAlbaranes')
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

            //    ((cAlbaranesCompra.LinCompra)bS2[e.NewIndex]).Empresa = cParamXml.Emp;
            //    ((cAlbaranesCompra.LinCompra)bS2[e.NewIndex]).NumPed = Convert.ToInt32(txPed.Text);
            //    ((cAlbaranesCompra.LinCompra)bS2[e.NewIndex]).LinPed = cAlbaranesCompra.LinCompra.fncNumLinea(txPed.Text);
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

                if (fncGrabaLinea())
                {
                    sbrCargaLineas(txAlb.Text);
                    sbrLimpiaEnt();
                    txProd.Focus();
                }

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
                    sbrCargaLineas(txAlb.Text);
                    sbrLimpiaEnt();
                    txProd.Focus();
                }
            }
        }

        private void btFPago_Click(object sender, EventArgs e)
        {

        }

        //private void btDivisa_Click(object sender, EventArgs e)
        //{
        //    string vTabla = "divisas";
        //    string vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "ccoddiv", txDivisa.Text, "", "", "", false, "", "", "", "DBF");

        //    if (vRes != "")
        //    {
        //        txDivisa.Text = vRes;
        //        bS1.RaiseListChangedEvents = true;
        //        bS1.EndEdit();
        //        sbrRefrescar();
        //    }

        //}

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
                sbrCargaLineas(txAlb.Text);
                sbrLimpiaEnt();
                txProd.Focus();

            }
        }

        private void bS2_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btRecep_Click(object sender, EventArgs e)
        {
            string vTabla = "GC_Operarios";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "IdOper", txRecepPor.Text, "", "", "", false, "", "", "", "SQL");

            if (vRes != "")
            {

                txRecepPor.Text = vRes;
                txRecepPor.Focus();
            }

        }

        private void btCert_Click(object sender, EventArgs e)
        {
            if (txCert.Text != "")
            {
                string vMen = "Ya hay un certificado para este lote.¿Desea continuar?";
                string vTit = "Certificados";
                if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

            }

            FD1.Filter = "Ficheros PDF|*.PDF|Todos|*.*";
            System.Windows.Forms.DialogResult vRes = DialogResult.Abort;
            vRes = FD1.ShowDialog();
            if (vRes == System.Windows.Forms.DialogResult.OK)
            {
                txCert.Text = FD1.FileName;
                if (txLinAlb.Text == "")
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
            if (vRes == System.Windows.Forms.DialogResult.Cancel)
            {
                if (txCert.Text != "")
                {
                    string vMen = "Se ha selecionado Cancelar.¿Desea Borrar el dato actual?";
                    string vTit = "Certificados";
                    if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txCert.Text = "";
                    }
                }
            }

        }

        private void btEtiqueta_Click(object sender, EventArgs e)
        {
            string vCan = cUtil.InPutBox("", "Cantidad", "1", "1");
            if (vCan == "*****Cancelado*****")
            {
                return;
            }

            int viCan = 1;
            try { viCan = int.Parse(vCan); }
            catch
            {
                MessageBox.Show("La Cantidad tiene que ser numérica");
                return;
            }



            cInformes.Imp = (cParamXml.Imp == "True") ? true : false;
            cInformes.sbrImprimeEtiEntrada(oLinAlb, viCan);
        }


    }
}
