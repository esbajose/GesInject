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

namespace GesInject.Formularios
{
    public partial class frmOF : Form
    {
        private string vCampo = "";
        public string vOFExt = "";
        
        public bool vOFNueva = false;
        public string vProdNuevo = "";
        public string vDesProdNuevo = "";



        public frmOF()
        {
            InitializeComponent();
        }

        #region Objetos Form

        private void frmOF_Load(object sender, EventArgs e)
        {
            this.Text = "Ordenes de Producción ";
            sbrCargaOF();
            sbrBindCampos(this);

            if (vOFExt != "")
            {
                bool vOk = fncBuscaOFExt(vOFExt);

                if (!vOk) this.Close();
            }

            if (vOFNueva)
            {
                sbrAltaOF();

                txProd.Text = vProdNuevo;
                lbNomProd.Text = vDesProdNuevo;
                sbrActuProd(vProdNuevo);
                Application.DoEvents();
                txProd.Focus();

            }


        }
        private void frmOF_KeyUp(object sender, KeyEventArgs e)
        {
            string vTecla = e.KeyCode.ToString();

            if ((vTecla == "F3"))
            {
                string vMen = "¿Dar de Alta una Nueva O.F.?";
                string vTit = "Pedidos";
                if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sbrAltaOF();
                } 
                e.Handled = true;
            }
            if ((vTecla == "F4"))
            {
                sbrBajaOF();
                e.Handled = true;
            }
            if ((vTecla == "F5"))
            {
                string vMen = "¿Dar de Alta una Nueva O.F. con Numeración Manual?";
                string vTit = "Pedidos";
                if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    sbrAltaOF();
                }
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
            sbrBajaOF();
        }
        private void btAlta_Click(object sender, EventArgs e)
        {
            string vMen = "¿Dar de Alta una Nueva O.F.?";
            string vTit = "Pedidos";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sbrAltaOF();
            }

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


        #region procesos locales
        private void sbrCargaOF()
        {
            //btDel.Visible = false;
            try
            {
                bS1.DataSource = cProduc.Lista();
                Navi1.BindingSource = bS1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                this.Close();
            }
        }
        private void sbrActuCli(string vCli)
        {
            DataRow dr;
            string vWhere = " Empresa = " + cParamXml.Emp + " and codcli = '" + vCli + "' ";
            dr = cUtil.fncTraeCampos("GC_ClienteProducto", vWhere, cParamXml.strConec, "SQL");
            //lbNomCli.Text = "";
            if (dr != null)
            {
                txProd.Text = dr["Producto"].ToString();
                lbNomProd.Text = dr["Descripción"].ToString();
                txProdCli.Text = dr["ProductoCli"].ToString();

                if (dr.Table.Rows.Count > 1)
                {
                    string vTabla = "GC_ClienteProducto";
                    vWhere = " Where empresa =" + cParamXml.Emp + " and CodCli ='" + vCli + "'";
                    string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "Producto", vCli, vWhere, "", "", true, "", "", "", "SQL");

                    if (vRes != "")
                    {
                        txProdCli.Text = cUtil.Piece(vRes, "#", 7);
                        txProd.Text = cUtil.Piece(vRes, "#", 5);
                        lbNomProd.Text = cUtil.Piece(vRes, "#", 6);

                    }
                }


                cProduc.OF cOF = (cProduc.OF)bS1.Current;


                sbrModifCampo("CodCli", vCli);
                cOF.CodCli = vCli;
                sbrModifCampo("Articulo", txProd.Text);
                cOF.Articulo = txProd.Text;
                sbrModifCampo("Descripción", lbNomProd.Text);
                cOF.Descripción = lbNomProd.Text;
                sbrModifCampo("ArticuloCli", txProdCli.Text);
                cOF.ArticuloCli = txProdCli.Text;
                Application.DoEvents();

            }

        }
        private void sbrActuProd(string vProd)
        {
            DataRow dr;
            string vWhere = " Empresa = " + cParamXml.Emp + " and producto = '" + vProd + "' ";
            dr = cUtil.fncTraeCampos("GC_ClienteProducto", vWhere, cParamXml.strConec, "SQL");
            //lbNomCli.Text = "";
            if (dr != null)
            {

                txProd.Text = dr["Producto"].ToString();
                lbNomProd.Text = dr["Descripción"].ToString();
                txProdCli.Text = dr["ProductoCli"].ToString();
                txCodCli.Text = dr["CodCli"].ToString();
                lbNomCli.Text = dr["NomCli"].ToString();
                
                if (dr.Table.Rows.Count > 1)
                {
                    string vTabla = "GC_ClienteProducto";
                    vWhere = " Where empresa =" + cParamXml.Emp + " and Producto ='" + txProd.Text + "'" ;
                    string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "CodCli", txProd.Text,vWhere, "", "", true, "", "", "", "SQL");

                    if (vRes != "")
                    {
                        txProdCli.Text = cUtil.Piece(vRes,"#",7);
                        txCodCli.Text = cUtil.Piece(vRes, "#", 3);
                        lbNomCli.Text = cUtil.Piece(vRes, "#", 4);

                    }
                }

                cProduc.OF cOF = (cProduc.OF)bS1.Current;

                sbrModifCampo("Articulo", txProd.Text);
                cOF.Articulo = txProd.Text;
                sbrModifCampo("Descripción", lbNomProd.Text);
                cOF.Descripción=lbNomProd.Text;
                sbrModifCampo("ArticuloCli", txProdCli.Text);
                cOF.ArticuloCli = txProdCli.Text;
                sbrModifCampo("CodCli", txCodCli.Text);
                cOF.CodCli = txCodCli.Text;
                Application.DoEvents();

            }
            //else
            //{
            //    string vTabla = "articulo";
            //    string vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "Cdetalle", txProd.Text, "", "", "", false, "", "", "", "DBF");

            //    if (vRes != "")
            //    {
            //        lbNomProd.Text = vRes;
            //        sbrModifCampo("Descripción", lbNomProd.Text);
            //        Application.DoEvents();
            //        txProd.Focus();
            //    }

            //}

        }
        private void sbrActuDatos()
        {
            bS1.DataSource = cProduc.Lista();
        }

        private void sbrAltaOF()
        {
            sbrAltaOF("");
        }

        private void sbrAltaOF(string vNumSer)
        {
            try
            {
                int vId = 0;
                cProduc.OF of = (cProduc.OF)bS1.Current;
                if (of == null)
                {
                    cProduc.OF of2 = new cProduc.OF();

                    if (vNumSer != "")
                    {
                        vId = of2.fncAlta(vNumSer);
                    }
                    else
                    {
                        vId = of2.fncAlta();

                    }

                }
                else
                {
                    if (vNumSer != "")
                    {
                        vId = of.fncAlta(vNumSer);
                    }
                    else
                    {
                        vId = of.fncAlta();

                    }
                }


                if (vId == 0)
                {
                    MessageBox.Show("No se ha podido dar de Alta la O.F.");
                    return;
                }

                sbrActuDatos();

                bS1.MoveLast();
                txProd.Focus();
                btDel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido dar de Alta la O.F. :'" + ex.Message + "'");
                bS1.CancelEdit();

            }
        }

        private void sbrBajaOF()
        {
            if (bS1.Current != null)
            {
                if (((cProduc.OF)bS1.Current).CantidadFab != 0)
                {
                    MessageBox.Show("Ya hay cantidad Fabricada, NO se piede eliminar");
                    return;
                }
                if (((cProduc.OF)bS1.Current).Estado == "Producción")
                {
                    MessageBox.Show("Esta OF esta en 'Producción', NO se piede eliminar");
                    return;
                }

                

                string vMen = "Esta seguro de Eliminar el registro actual?";
                string vTit = "Eliminar";
                if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        cProduc.OF of = (cProduc.OF)bS1.Current;
                        if (!of.fncBaja(of.IdOF))
                        {
                            MessageBox.Show("No se ha podido Eliminar la O.F.");
                            bS1.CancelEdit();
                        }
                        else
                        {
                            bS1.Remove(of);
                            sbrCargaOF();
                            //btDel.Visible = false;

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se ha podido Eliminar la O.F. :'" + ex.Message + "'");
                        bS1.CancelEdit();

                    }

                }

            }

        }

        public void sbrBusca(string vCampo)
        {
            string vTabla = "";
            string vWhere = "";
            string vRes = "";

            if (vCampo == "txOF")
            {
                vTabla = "[GC_OrdenProd]";
                vWhere = " Where empresa =" + cParamXml.Emp;
                vRes = cUtil.fncLista(vTabla, cParamXml.strConec, "IdOF", txOF.Text, vWhere);

                if (vRes != "")
                {
                    int vReg =  cProduc.fncBuscaIndexOF(bS1, vRes);
                    bS1.Position = vReg;
                }
            }
            if (vCampo == "txCodCli")
            {

                btCliente_Click(btCliente, null);

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

        public bool fncBuscaOFExt(string vOF)
        {
            bool vOk = false;

            int vReg = cProduc.fncBuscaIndexOF(bS1, vOF);
            if (vReg != -1)
            {
                bS1.Position = vReg;
                vOk = true;
            }
            else
            {
                MessageBox.Show("La O.F.: " + vOF + " NO Existe");
            }


            return vOk;
        }

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

        private void sbrModifCampo(string vCampo, string vValor)
        {
            cProduc.OF of = (cProduc.OF)bS1.Current;

            if ((of.aCampoModif != "") & (of.aCampoModif != null)) { vCampo = of.aCampoModif; }
            if ((of.aValor != "") & (of.aValor != null)) { vValor = of.aValor; }

            if (!of.fncGrabaCampo(vCampo, vValor))
            {
                MessageBox.Show("No se ha podido Grabar el Dato");
                bS1.CancelEdit();
            }

            //if (vCampo == "CodCli")
            //{
            //    sbrActuCli(vValor);
            //}

        }

        private void sbrCargaPropiedades(cProduc.OF vof)
        {
            sbrLimpiaPropiedades();
            DataTable dt = cProducto.Articulo.fncProdAnexos(vof.Empresa, vof.Articulo);

             if (dt.Rows.Count > 0)
            {

                string vPeso = "0";
                string vMat = "";
                string vDesMat = "";

                ////Busco los materiales a utilizar en la producción de la pieza
                //string vMateriales = "";
                //DataTable dtMat = cProducto.Articulo.fncProdMat(cParamXml.Emp, vof.Articulo, "1", Convert.ToInt32(vof.Cantidad));
                //foreach (DataRow drM in dtMat.Rows)
                //{
                //    vMat = drM["Material"].ToString();
                //    vDesMat = drM["DesMaterial"].ToString();
                //    vPeso = drM["Peso"].ToString();


                //    //decimal vdCan = Convert.ToDecimal(vCan.Replace(".", ","));
                //    //decimal vCanMat = vdCan * vdPeso / 1000;


                //}




                //txDesMaterial.Text = vDesMat;
                //txMat.Text = vMat;


                txTipo.Text = dt.Rows[0]["TipoMaterial"].ToString();
                txMolde.Text = dt.Rows[0]["CodMolde"].ToString();
                txUbic.Text = dt.Rows[0]["Ubicación"].ToString();
                txPeso.Text = vPeso;
                txPiezasHora.Text = dt.Rows[0]["PiezasHora"].ToString();
                txPiezasCaja.Text = dt.Rows[0]["PiezasCaja"].ToString();
                txTipoCaja.Text = dt.Rows[0]["Caja"].ToString();
                txTipoBolsa.Text = dt.Rows[0]["Bolsa"].ToString();
                txPiezasBolsa.Text = dt.Rows[0]["PiezasBolsa"].ToString();
                txCavidades.Text = dt.Rows[0]["Cavidades"].ToString();

                string vMolde = dt.Rows[0]["CodMolde"].ToString();
                string vWhere = " Empresa = " + cParamXml.Emp + " and CodMolde ='" + vMolde + "' ";
                string vMolBloq = cUtil.fncTraeCampo("Bloqueado", "GC_Moldes", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", true);
                if (vMolBloq == "True")
                {
                    lbMolBloq.Text = "Molde Bloqueado";
                    lbMolBloq.BackColor = Color.Red;
                    txMolde.BackColor = Color.Red;

                }
                else
                {
                    lbMolBloq.Text = "";
                    lbMolBloq.BackColor = Control.DefaultBackColor;
                    txMolde.BackColor = Control.DefaultBackColor;
                }





                if (txPiezasHora.Text == ""){txPiezasHora.Text = "0";}
                int viPiezasHora = Convert.ToInt32(txPiezasHora.Text);
                decimal vHoras = 0;

                if (viPiezasHora > 0) vHoras = vof.Cantidad / viPiezasHora;
                txHoras.Text = string.Format("{0:n2}", vHoras) + " h.";

                if (txPeso.Text == "") { txPeso.Text = "0"; }
                decimal vdPeso = Convert.ToDecimal(txPeso.Text);

                //decimal vKilos = (vdPeso * vof.Cantidad)/1000;
                //txKilos.Text = string.Format("{0:n2}", vKilos) + " kg";

                string vImagen = cProducto.Articulo.fncTraeC("Imagen", txProd.Text);
                if (vImagen != "") vImagen = cParamXml.DirImProd + @"\" + vImagen;
                try
                {
                    picFoto.Image = null;
                    picFoto.Load(vImagen);
                }
                catch { }



            }

        }
        private void sbrLimpiaPropiedades()
        {
                txDesMaterial.Text = "";
                txMat.Text = "";
                txTipo.Text = "";
                txMolde.Text = "";
                txUbic.Text = "";
                txPeso.Text = "";
                txPiezasHora.Text = "";
                txPiezasCaja.Text = "";
                txTipoCaja.Text = "";
                txTipoBolsa.Text = "";
                txPiezasBolsa.Text = "";
                txCavidades.Text = "";

                txHoras.Text = "";

                txKilos.Text = "";



        }

        private bool fncTerminarOFL(string vOFL)
        {
            bool vOk = true;

            //string vMen = "Se Terminaran la O.F.L.:" + vOFL + ".Esta seguro?";
            //string vTit = "Terminar O.F.L.";
            //if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
            //{
            //    return vOk;
            //}

            cProduc.OF.fncCambiarEstado(cParamXml.Emp.ToString(), vOFL, "Terminada");

            return vOk;
        }

        private void sbrCargaCajas()
        {
            string vSql = cConstantes.SQL_OFL_Cajas_Lista;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?OFL]", txOF.Text);
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
            vSql = vSql.Replace("[?OFL]", txOF.Text);
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


        private DataRow sbrCargarOF(string vOF)
        {
            DataRow dr = null;

            string vSql = cConstantes.SQL_Terminar_OF_2;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?OF]", vOF);



            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

            if (dt.Rows.Count > 0) dr = dt.Rows[0];

            return dr;
        }

        private void sbrCargaMat(string vProd)
        {
            DataTable dt = cProducto.Articulo.fncProdMat(cParamXml.Emp, vProd, "1", Convert.ToInt32(((cProduc.OF)bS1.Current).Cantidad));

            grCompo.DataSource = null;
            grCompo.DataSource = dt.DefaultView;


        }



        #endregion


        #region Binding (OF)


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

            if (vName == "txProd")
            {
                if (ctl.Text != "")
                {
                    string vWhere = " cREF = '" + txProd.Text + "' ";
                    string vDes = cUtil.fncTraeCampo("cdetalle", "articulo", vWhere, "", cParamXml.strOleDBConecDbf, "DBF", true);
                    if (vDes == "***Inex***")
                    {
                        MessageBox.Show("Producto Inexistente");
                        e.Cancel = true;
                        bS1.CancelEdit();
                        btDel.Visible = true;
                        return;

                    }

                    sbrActuProd(txProd.Text);
                    Application.DoEvents();
                    lbNomProd.Text = vDes;
                    sbrModifCampo("Descripción", lbNomProd.Text);
                    ((cProduc.OF)bS1.Current).Descripción = vDes;
                    Application.DoEvents();





                }
            }

            if (vName == "txCan")
            {
                decimal vdCan = Convert.ToDecimal(txCan.Text);
                decimal vdCanFab = Convert.ToDecimal(txCanFab.Text);

                if (vdCan < vdCanFab)
                {
                    MessageBox.Show("La Cantidad NO puede ser menor que la Cantidad fabricada");
                    e.Cancel = true;
                    return;
                }
                if (vdCan > vdCanFab)
                {
                    if (cbEstado.Text == "Acabada")
                    {
                        bool vOk = cProduc.OF.fncCambiarEstado(cParamXml.Emp.ToString(), txOF.Text, "Lanzada");
                        cbEstado.Text = "Lanzada";
                    }
                }

            }

            if (vName == "txOF")
            {
                if (vTex == "")
                {
                    MessageBox.Show("El Campo 'Nº O.F.' es un Indice,NO puede estar en blanco");
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
                string vType = ctl.GetType().ToString(); 
                if (ctl.GetType() == typeof(TextBox))
                {
                    vCampo = ((TextBox)ctl).DataBindings["Text"].BindingMemberInfo.BindingField;
                }
                if (ctl.GetType() == typeof(jControles.jTextBox))
                {
                    vCampo = ((TextBox)ctl).DataBindings["Text"].BindingMemberInfo.BindingField;
                }
                if (ctl.GetType() == typeof(DateTimePicker))
                {
                    vCampo = ((DateTimePicker)ctl).DataBindings["Value"].BindingMemberInfo.BindingField;
                }

                if (vCampo == "Articulo")
                {
                    string vWhere = " cREF = '" + txProd.Text + "' ";
                    string vDes = cUtil.fncTraeCampo("cdetalle", "articulo", vWhere, "", cParamXml.strOleDBConecDbf, "DBF", true);
                    if (vDes == "***Inex***")
                    {
                        MessageBox.Show("Producto Inexistente");
                        bS1.CancelEdit();
                        btDel.Visible = true;
                        return;

                    }


                    sbrActuProd(txProd.Text);
                    Application.DoEvents();
                    lbNomProd.Text = vDes;
                    sbrModifCampo("Descripción", lbNomProd.Text);
                    Application.DoEvents();
                    txProd.Focus();
                    sbrCargaPropiedades((cProduc.OF)bS1.Current);

                }


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
            Control ctl;
            ctl = (Control)sender;
            vCampo = ctl.Name;



        }

        #endregion

        #region Datos bS1 (BindingSource OF)

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
                    cProduc.OF cOF = (cProduc.OF)bS1.Current;
                    if (cOF.Cantidad < cOF.CantidadFab)
                    {
                        bS1.CancelEdit();
                        return;
                    }
                    


                    sbrModifCampo("", "");

                }
            }

        }
        private void bS1_PositionChanged(object sender, EventArgs e)
        {
            sbrCargaCajas();
            sbrCargaComentarios();
           
        }
        private void bS1_CurrentItemChanged(object sender, EventArgs e)
        {
            sbrCargaPropiedades((cProduc.OF)bS1.Current);

            sbrCargaMat(((cProduc.OF)bS1.Current).Articulo);
            
        }

        #endregion

        private void btCliente_Click(object sender, EventArgs e)
        {
            string vTabla = "clientes";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "ccodcli", txCodCli.Text, "", "", "", false, "", "", "", "DBF");

            if (vRes != "")
            {
                txCodCli.Text = vRes;

                ////bS1.RaiseListChangedEvents = true;
                ////bS1.EndEdit();
                sbrActuCli(vRes);                
                Application.DoEvents();
            }

        }

        private void btProd_Click(object sender, EventArgs e)
        {
            string vTabla = "articulo";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "CREF", txProd.Text, "", "", "", true, "", "", "", "DBF");

            if (vRes != "")
            {
                txProd.Text = cUtil.Piece(vRes,"#",1);
                lbNomProd.Text = cUtil.Piece(vRes, "#", 2);
                sbrActuProd(cUtil.Piece(vRes, "#", 1));
                Application.DoEvents();
                txProd.Focus();
            }
        }

        private void txCodCli_TextChanged(object sender, EventArgs e)
        {
            DataRow dr;
            string vWhere = " ccodcli = '" + txCodCli.Text + "' ";
            dr = cUtil.fncTraeCampos("clientes", vWhere, cParamXml.strOleDBConecDbf, "DBF");
            lbNomCli.Text = "";
            if (dr != null)
            {
                lbNomCli.Text = dr["cnomcli"].ToString();
            }

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }


        private void btPrint_Click(object sender, EventArgs e)
        {

            cInformes.Imp = (cParamXml.Imp == "True") ? true : false;
            cInformes.sbrPrintOFL(cParamXml.Emp.ToString(), txOF.Text);

        }

        private void bS1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void terminarOFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string vEstado = cbEstado.Text;



            if (vEstado != "Acabada")
            {
                MessageBox.Show("la O.F.L. tiene que estar Acabada para poderla Terminar");
                return;
            }

            try
            {

                frmAnexoOFL frm = new frmAnexoOFL();
                frm.dr = sbrCargarOF(txOF.Text);
                frm.ShowDialog();

                if (frm.Terminar) fncTerminarOFL(txOF.Text);
            }
            catch { }



            

            sbrCargaOF();

        }

        private void btPrinEti_Click(object sender, EventArgs e)
        {

            if (grProduc.Rows.Count == 0) { MessageBox.Show("No hay Cajas/Bolsas para imprimir"); return; }
            if (grProduc.SelectedRows.Count == 0) { MessageBox.Show("No se selecionado ninguna fila para imprimir"); return; }

            string vNomCli = lbNomCli.Text;
            string vProd = txProd.Text;
            string vNomProd = lbNomProd.Text;
            string vNOF = txOF.Text;
            string vProdCli = txProdCli.Text;

            DataRow drCli;
            string vWhere = " Empresa = " + cParamXml.Emp + " and codcli = '" + txCodCli.Text + "' ";
            drCli = cUtil.fncTraeCampos("GC_ClienteProducto", vWhere, cParamXml.strConec, "SQL");

            string vLogoCaja = cProducto.Articulo.fncTraeC("LogoCaja", vProd);
            bool vConLogo = true;
            if (vLogoCaja == "0") vConLogo = false;

            string vEtiCli = "";
            string vEt = "";
            if (drCli != null)
            {
                vEt = drCli["EtiCli"].ToString();
                if (vEt == "1")
                {
                    vEtiCli = drCli["EtiDes"].ToString();
                    if (vEtiCli == "") vEtiCli = vNomCli;
                }
            }

            foreach(DataGridViewRow dr in grProduc.SelectedRows)
            {
                
                string vFecha = Convert.ToDateTime(dr.Cells["Fecha"].Value.ToString()).ToShortDateString();
                string vOper = cUtil.Piece(dr.Cells["IdOper"].Value.ToString(),"-",1);
                string vCaja = dr.Cells["NumCajaBolsa"].Value.ToString();
                string vPiezasCaja = dr.Cells["CanProd"].Value.ToString();
                string vTipo = dr.Cells["Tipo"].Value.ToString();
                string vCodigo = dr.Cells["codigo"].Value.ToString();
                string vsNumCajaBolsa = "";
                if (vTipo != "B")
                {
                    vsNumCajaBolsa = vCaja.ToString();
                }
                else
                {
                    vsNumCajaBolsa = vCodigo;

                }


                dtsEtiCaja dts = new dtsEtiCaja();
                DataTable dt = new DataTable();
                dt = dts.Tables["dtEtiCaja"].Clone();
                DataRow dr2 = dt.NewRow();

                dr2.BeginEdit();
                dr2["Producto"] = vProd;
                dr2["Cliente"] = vNomCli;
                dr2["Pieza"] = vProdCli;
                dr2["DesProd"] = vNomProd;
                dr2["Lote"] = vNOF;
                if (vPiezasCaja == "") vPiezasCaja = "0";
                dr2["PiezasCaja"] = Convert.ToInt32(vPiezasCaja);
                dr2["Fecha"] = Convert.ToDateTime(dr.Cells["Fecha"].Value.ToString());
                dr2["Operario"] = vOper;
                if (vsNumCajaBolsa == "") vsNumCajaBolsa = "0";
                dr2["Caja"] = vsNumCajaBolsa;
                dr2["Imagen"] = cUtil.imageToByteArray(picFoto.Image);
                dr2["EtiCliente"] = vEtiCli;

                dr2.EndEdit();

                dt.Rows.Add(dr2);

                int vAncho = 1;
                int vAlto = 1;
                if (picFoto.Image != null)
                {
                    vAncho = picFoto.Image.Width;
                    vAlto = picFoto.Image.Height;
                }

                cInformes.Imp = (cParamXml.Imp == "True") ? true : false;
                cInformes.sbrEtiCaja(dt, vAlto, vAncho,vEt,vConLogo);

                //cInformes.sbrEtiCaja(vNomCli, vProd, vNomProd, vNOF, vPiezasCaja, vFecha, vOper, vCaja,vProdCli);


            }


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string vNumSer = cUtil.InPutBox("Nº OFL", "Ordenes de Producción", "", "1");
            if (vNumSer != "*****Cancelado*****")
            {
                string vWhere = " Empresa = " + cParamXml.Emp + " and IdOF ='" + vNumSer + "' ";
                string vOF = cUtil.fncTraeCampo("IdOF", "GC_OrdenProd", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", true);
                if (vOF != "***Inex***")
                {
                    MessageBox.Show("Este Nº de O.F. ya existe");
                    return;
                }

                sbrAltaOF(vNumSer);


            }
        }

        private void txCan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txHoras_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void acabarOFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string vEstado = cbEstado.Text;

            string vtxCan = txCanFab.Text;

            decimal vCan = Convert.ToDecimal(vtxCan);

            if (vCan==0)
            {
                MessageBox.Show("No hay cantidad fabricada");
                return;
                
            }


            if (vEstado == "Acabada")
            {
                MessageBox.Show("la O.F.L. ya esta acabada");
                return;
            }
            if (vEstado == "Terminada")
            {
                MessageBox.Show("la O.F.L. ya esta terminada");
                return;
            }


            try
            {
                
                string vMen = "Se igualara la cantidad a la cantidad fabricada y se acabara la O.F..¿Es correcto?";
                string vTit = "OF";
                if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return ;
                }

                txCan.Text = vCan.ToString();

                cProduc.OF.fncCambiarEstado(cParamXml.Emp.ToString(), txOF.Text, "Acabada");

                cProduc.OF cOF = (cProduc.OF)bS1.Current;
                

                sbrModifCampo("Cantidad", vCan.ToString().Replace(",","."));
                cOF.Cantidad = vCan;


            }
            catch { }





            sbrCargaOF();
        }


     }
}
