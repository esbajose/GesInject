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
using jControles.Formularios;

namespace GesInject.Formularios
{
    public partial class frmProdAnexos : Form
    {
        private string vCampo = "";
        public string vProdExt = "";

        public frmProdAnexos()
        {
            InitializeComponent();
        }

        #region Objetos Form
        private void frmProdAnexos_Load(object sender, EventArgs e)
        {
            this.Text = "Anexos de Producto ";
            cbAlm.SelectedIndex = 0;
            dtDFecha.Value = DateTime.Now;
            dtHFecha.Value = DateTime.Now;

            sbrCargaProducto();
            sbrBindCampos(this);

            if (vProdExt !="")
            {
                bool vOk = fncBuscaProdExt(vProdExt);

                if (!vOk) this.Close();
            }

            sbrCargaCli();
        }
        private void frmProdAnexos_KeyUp(object sender, KeyEventArgs e)
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

            //if (vTecla == "Down")
            //{
            //    try
            //    {
            //        bS1.MoveNext();
            //    }
            //    catch { }
            //    e.Handled = true;
            //}
            //if (vTecla == "Up")
            //{
            //    try
            //    {
            //        bS1.MovePrevious();
            //    }
            //    catch { }
            //    e.Handled = true;
            //}

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
            sbrBajaProducto();
        }
        private void btAlta_Click(object sender, EventArgs e)
        {
            string vMen = "¿Dar de Alta un Nuevo Producto?";
            string vTit = "Articulos";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmNuevoAnexo frm = new frmNuevoAnexo();
                frm.ShowDialog();
                string vProd = frm.vProd;

                if (vProd != "")
                {
                    sbrActuDatos();

                    int vReg = cProducto.fncBuscaIndexOF(bS1, vProd);
                    if (vReg != -1)
                    {
                        bS1.Position = vReg;
                    }

                }


                //sbrAltaProducto();
                //txProducto.Focus();
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
        private void sbrCargaProducto()
        {
            btDel.Visible = false;
            try
            {
                bS1.DataSource = cProducto.Lista();
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
            bS1.DataSource = cProducto.Lista();
        }

        private void sbrAltaProducto()
        {
            try
            {
                int vId = 0;
                cProducto.Articulo articulo = (cProducto.Articulo)bS1.Current;
                if (articulo == null)
                {
                    cProducto.Articulo articulo2 = new cProducto.Articulo();
                    vId = articulo2.fncAlta();

                }
                else
                {
                    vId = articulo.fncAlta();
                }

                if (vId == 0)
                {
                    MessageBox.Show("No se ha podido dar de Alta el Producto");
                    return;
                }

                sbrActuDatos();

                bS1.MoveLast();
                txProducto.Focus();
                btDel.Visible = true;
                //btProducto.Visible = true;

                string vTabla = "articulo";
                string vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "CREF", txProducto.Text, "", "", "", false, "", "", "", "DBF");


                if (vRes != "")
                {
                    txProducto.Text = vRes;
                    sbrModifCampo("Producto", vRes);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido dar de Alta el Producto :'" + ex.Message + "'");
                bS1.CancelEdit();

            }
        }
        private void sbrBajaProducto()
        {
            if (bS1.Current != null)
            {
                string vMen = "Esta seguro de Eliminar el registro actual?";
                string vTit = "Eliminar";
                if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        cProducto.Articulo articulo = (cProducto.Articulo)bS1.Current;
                        if (!articulo.fncBaja(articulo.Producto))
                        {
                            MessageBox.Show("No se ha podido Eliminar el Producto");
                            bS1.CancelEdit();
                        }
                        else
                        {
                            bS1.Remove(articulo);
                            sbrCargaProducto();
                            btDel.Visible = false;

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se ha podido Eliminar el Producto :'" + ex.Message + "'");
                        bS1.CancelEdit();

                    }

                }

            }

        }
        public void sbrTecla(string vTecla)
        {
            switch (vTecla)
            {
                case "F3":
                    sbrAltaProducto();
                    break;
                case "Escape":
                    this.ActiveControl.BackColor = Color.White;

                    break;

            }
        }

        public void sbrBusca(string vCampo)
        {
            string vTabla = "";
            string vWhere = "";
            string vRes = "";
            if (vCampo == "") vCampo = "txProducto";

            if (vCampo == "txProducto")
            {
                vTabla = "articulo";
                vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "CREF", txProducto.Text, "", "", "", false, "", "", "", "DBF");


                if (vRes != "")
                {
                    if (btDel.Visible)
                    {
                        txProducto.Text = vRes;
                        sbrModifCampo("Producto", vRes);
                    }
                    int vReg = cProducto.fncBuscaIndexOF(bS1, vRes);
                    if (vReg != -1)
                    {
                        bS1.Position = vReg;
                    }
                    else
                    {
                        MessageBox.Show("El producto: " + vRes + " NO esta dado de alta");
                    }
                }
            }

            if (vCampo == "txCodProv")
            {

                btProveedor_Click(btProveedor, null);

            }



        }

        public bool fncBuscaProdExt(string vProd)
        {
            bool vOk = false;
            int vReg = cProducto.fncBuscaIndexOF(bS1, vProd);
            if (vReg != -1)
            {
                bS1.Position = vReg;
                vOk = true;
            }
            else
            {
                MessageBox.Show("El producto: " + vProd + " NO esta dado de alta");
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
            cProducto.Articulo articulo = (cProducto.Articulo)bS1.Current;

            if ((articulo.aCampoModif != "") & (articulo.aCampoModif != null)) { vCampo = articulo.aCampoModif; }
            if ((articulo.aValor != "") & (articulo.aValor != null)) { vValor = articulo.aValor; }

            if (!articulo.fncGrabaCampo(vCampo, vValor))
            {
                MessageBox.Show("No se ha podido Grabar el Dato");
                bS1.CancelEdit();
            }

            //if (vCampo == "CodCli")
            //{
            //    sbrActuCli(vValor);
            //}

        }

        private void sbrActuSitu(string vProd,string vAlm)
        {
            DataTable dt = cProducto.Articulo.fncProdSitu(cParamXml.Emp, vProd, vAlm);
            txStock.Text = "0";
            if (dt.Rows.Count > 0)
            {
                string vStock = dt.Rows[0]["Cantidad"].ToString();
                txStock.Text = vStock;
            }

            try
            {
                string vImagen = txImagen.Text;
                if (vImagen != "") vImagen = cParamXml.DirImProd + @"\" + vImagen;
                picFoto.Image = null;
                picFoto.Load(vImagen);
            }
            catch { }

            sbrCargaHist();


        }

        private void sbrCargaMat(string vProd)
        {
            DataTable dt = cProducto.Articulo.fncProdMat(cParamXml.Emp, vProd);

            grCompo.DataSource = null;
            grCompo.DataSource = dt.DefaultView;


        }


        private void  sbrCargaCli()
        {
            DataRow dr;
            //string vWhere = " (CodCli = N'" + txCodCli.Text + "') AND (Empresa = 1) AND (Producto = N'" + txProducto.Text + "')";
            string vWhere = " (Empresa = 1) AND (Producto = N'" + txProducto.Text + "')";
            dr = cUtil.fncTraeCampos("GC_ClienteProducto", vWhere, cParamXml.strConecProduc_Prueb, "SQL");
            txCodCli.Text="";
            lbNomCli.Text = "";
            if (dr != null)
            {
                lbNomCli.Text = dr["NomCli"].ToString();
                txCodCli.Text = dr["CodCli"].ToString();
            }
        }

        private void sbrCargaHist()
        {
            DateTime vtDFecha = dtDFecha.Value;
            if (!dtDFecha.Checked) { vtDFecha = Convert.ToDateTime("01/01/1900"); }

            DateTime vtHFecha = dtHFecha.Value;
            if (!dtHFecha.Checked) { vtHFecha = Convert.ToDateTime("01/01/2180"); }

            string vDFecha = string.Format("{0:yyyy-MM-dd}", vtDFecha);
            string vHFecha = string.Format("{0:yyyy-MM-dd}", vtHFecha);

            //string vDFecha = "1900/01/01";
            //string vHFecha = "2190/12/31";


            string vFil = " and Producto = '" + txProducto.Text + "' ";
            string vSql = cConstantes.SQL_Movi_Lista;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?DFecha]", vDFecha);
            vSql = vSql.Replace("[?HFecha]", vHFecha);
            vSql = vSql.Replace("[?Fil]", vFil);
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

            grLista.DataSource = null;
            grLista.DataSource = dt.DefaultView;



        }


        private bool fncGrabaCliProd()
        {
            bool vOk = false;
            cClientes.ClienteProducto oCliProd = new cClientes.ClienteProducto();

            oCliProd.Empresa = cParamXml.Emp;
            oCliProd.CodCli = txCodCli.Text;
            oCliProd.NomCli = lbNomCli.Text;
            oCliProd.Producto = txProducto.Text;
            oCliProd.Descripción = lbProd.Text;
            oCliProd.ProductoCli = txProdCli.Text;
            oCliProd.EtiCli = 0;
            oCliProd.EtiDes = "";
            vOk = oCliProd.fncAlta();



            return vOk;

        }

        private bool fncSeguridad(string vTexto, string vContra)
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

        #endregion

        #region Binding (Producto)


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


            if (vName == "txProducto")
            {
                if (vTex == "")
                {
                    MessageBox.Show("El Campo 'Producto' es un Indice,NO puede estar en blanco");
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
        }
        private void bS1_CurrentItemChanged(object sender, EventArgs e)
        {
                if (bS1.Current != null)
                {
                    cProducto.Articulo articulo = (cProducto.Articulo)bS1.Current;
                    string vMolde = articulo.CodMolde;
                    string vWhere = " Empresa = " + cParamXml.Emp + " and CodMolde ='" + vMolde + "' ";
                    string vMolBloq = cUtil.fncTraeCampo("Bloqueado", "GC_Moldes", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", true);
                    if ((vMolde != "0") & (vMolde != ""))
                    {
                        btBlockMOlde.Visible = true;
                    }
                    else
                    {
                        btBlockMOlde.Visible = false;

                    }

                    if (vMolBloq == "True")
                    {
                        lbMolBloq.Text = "Molde Bloqueado";
                        lbMolBloq.BackColor  = Color.Red;
                        txMolde.BackColor = Color.Red;
                        btBlockMOlde.Text = "Desbloquear Molde";
                        btBlockMOlde.BackColor = Color.Green;
                    }
                    else
                    {
                        lbMolBloq.Text = "";
                        lbMolBloq.BackColor = Color.White;
                        txMolde.BackColor = Color.White;
                        btBlockMOlde.Text = "Bloquear Molde";
                        btBlockMOlde.BackColor = Color.Red;
                    }

                    sbrActuSitu(articulo.Producto, cbAlm.Text);
                    sbrCargaMat(articulo.Producto);
                    sbrCargaCli();
                    
                }
        }

        #endregion

        public void btProveedor_Click(object sender, EventArgs e)
        {
            string vTabla = "proveedo";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "ccodpro", txCodProv.Text, "", "", "", false, "", "", "", "DBF");

            if (vRes != "")
            {
                txCodProv.Text = vRes;
                bS1.RaiseListChangedEvents = true;
                bS1.EndEdit();
                Application.DoEvents();
                txCodProv.Text = vRes;
                Application.DoEvents();
            }

        }

        private void btMolde_Click(object sender, EventArgs e)
        {
            string vTabla = "GC_Moldes";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "CodMolde", txMolde.Text, "", "", "", false, "", "", "", "SQL");

            if (vRes != "")
            {
                
                txMolde.Text = vRes;
                bS1.RaiseListChangedEvents = true;
                bS1.EndEdit();
                
                Application.DoEvents();
                txMolde.Focus();
            }
        }

        private void btProducto_Click(object sender, EventArgs e)
        {
            string vTabla = "articulo";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "CREF", txProducto.Text, "", "", "", false, "", "", "", "DBF");


            if (vRes != "")
            {
                txProducto.Text = vRes;
                int vReg = cProducto.fncBuscaIndexOF(bS1, vRes);
                bS1.Position = vReg;
            }
        }

        private void txProducto_TextChanged(object sender, EventArgs e)
        {
            string vWhere = " CREF = '" + txProducto.Text.Trim() + "' ";
            DataRow dr;

            dr = cUtil.fncTraeCampos("articulo", vWhere, cParamXml.strOleDBConecDbf, "DBF");

            lbProd.Text = "";
            if (dr != null)
            {
                lbProd.Text = dr["cdetalle"].ToString();
                //txPrecio.Text = dr["NPVP"].ToString();
                //string vTIva = dr["CTIPOIVA"].ToString();

            }


        }

        private void btCompo_Click(object sender, EventArgs e)
        {
            string[,] vFormatoCampos = new string[4, 2];
            vFormatoCampos[0, 0] = "CodProv";
            string vResRel = "ccodpro,cnompro";
            string vResDes = "codprov,NombreProv";
            vFormatoCampos[0, 1] = "rel#proveedo##" + vResRel + "#" + vResDes + "#DBF#" + cParamXml.strOleDBConecDbf;


            vFormatoCampos[1, 0] = "Material";
            vResRel = "cref,cdetalle";
            vResDes = "Material,DesMaterial";
            vFormatoCampos[1, 1] = "rel#articulo##" + vResRel + "#" + vResDes + "#DBF#" + cParamXml.strOleDBConecDbf;

            vFormatoCampos[2, 0] = "TipoMaterial";
            vResRel = "Material";
            vResDes = "TipoMaterial";
            vFormatoCampos[2, 1] = "rel#GC_Materiales##" + vResRel + "#" + vResDes + "#SQL#" + cParamXml.strConecProduc_Prueb;

            vFormatoCampos[3, 0] = "Activo";
            vFormatoCampos[3, 1] = "ch#";



            string[] vCamposWhere = new string[2];
            vCamposWhere[0] = "Producto#" + txProducto.Text;
            vCamposWhere[1] = "Descripción#" + lbProd.Text;


            jControles.Formularios.frmControlGr frm = new jControles.Formularios.frmControlGr();
            frm.Tabla = "GC_ProductoMaterial";
            frm.Where = "WHERE (Empresa = " + cParamXml.Emp + ") and (Producto ='" + txProducto.Text + "')";
            frm.SoloLectura = false;
            frm.CamposVis = "Activo,Material,DesMaterial,TipoMaterial,CodProv,NombreProv,Precio,Peso";
            frm.NoVisible = "Id,Empresa,Producto,Descripción";
            frm.TextoCab = "Act.,Material,Descripción,Tipo Material,Cod.Prov.,Nombre,Precio,Peso";
            frm.Titulo = "Producto Material";
            frm.Default = "Empresa#" + cParamXml.Emp;
            frm.Conexion = cParamXml.strConec;
            frm.NoEdit = "CodProv,NombreProv,Material,DesMaterial";
            frm.CamposWhere = vCamposWhere;
            frm.FormatoCampo = vFormatoCampos;
            frm.ShowDialog();
            frm.Dispose();


            sbrCargaMat(txProducto.Text);

        }

        private void btDocumentación_Click(object sender, EventArgs e)
        {
            if (txDocumentación.Text != "")
            {
                fB1.InitialDirectory = txDocumentación.Text;
                fB1.FileName = txDocumentación.Text;
            }

            System.Windows.Forms.DialogResult vRes = DialogResult.Abort;
            vRes = fB1.ShowDialog();
            if (vRes == System.Windows.Forms.DialogResult.OK)
            {

                string vDir = fB1.FileName.Substring(0, fB1.FileName.LastIndexOf(@"\"));

                txDocumentación.Text = fB1.SafeFileName;
            }
            if (vRes == System.Windows.Forms.DialogResult.Cancel)
            {
                if (txDocumentación.Text != "")
                {
                    string vMen = "Se ha selecionado Cancelar.¿Desea Borrar el dato actual?";
                    string vTit = "Anexo Productos";
                    if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txDocumentación.Text = "";
                    }
                }
            }
        }

        private void btImagen_Click(object sender, EventArgs e)
        {
            if (txImagen.Text != "")
            {
                fB1.InitialDirectory = txImagen.Text;
                fB1.FileName = txImagen.Text;
            }

            System.Windows.Forms.DialogResult vRes = DialogResult.Abort;
            vRes = fB1.ShowDialog();
            if (vRes == System.Windows.Forms.DialogResult.OK)
            {

                string vDir = fB1.FileName.Substring(0, fB1.FileName.LastIndexOf(@"\"));

                txImagen.Text = fB1.SafeFileName;
            }
            if (vRes == System.Windows.Forms.DialogResult.Cancel)
            {
                if (txImagen.Text != "")
                {
                    string vMen = "Se ha selecionado Cancelar.¿Desea Borrar el dato actual?";
                    string vTit = "Anexo Productos";
                    if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txImagen.Text = "";
                    }
                }
            }

        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            if (grLista.Rows.Count == 0) { MessageBox.Show("No hay nada que Exportar"); return; }
            DataView dtv = (DataView)grLista.DataSource;
            DataTable dtLista = dtv.ToTable();
            cUtil.sbrCreaExcel(dtLista, "Movimientos de " + txProducto.Text);

        }

        private void btAct_Click(object sender, EventArgs e)
        {
            sbrCargaHist();
        }

        private void btCli_Click(object sender, EventArgs e)
        {
            string vTabla = "clientes";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "ccodcli", txCodCli.Text, "", "", "", false, "", "", "", "DBF");

            if (vRes != "")
            {
                txCodCli.Text = vRes;
                Application.DoEvents();
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

                vWhere = " (CodCli = N'" + txCodCli.Text + "') AND (Empresa = 1) AND (Producto = N'" + txProducto.Text + "')";
                string vProdCli = cUtil.fncTraeCampo("ProductoCli", "GC_ClienteProducto", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", false);


                txProdCli.Text = vProdCli;

            }

        }

        private void txProdCli_TextChanged(object sender, EventArgs e)
        {
            string vWhere = " (CodCli = N'" + txCodCli.Text + "') AND (Empresa = 1) AND (Producto = N'" + txProducto.Text + "')  AND (ProductoCli = N'" + txProdCli.Text + "')";
            string vProdCli = cUtil.fncTraeCampo("ProductoCli", "GC_ClienteProducto", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", false);
            


            tx1.Text = vProdCli;
            btGrabarCli.Visible = false;
            if (vProdCli == "")
            {
                btGrabarCli.Visible = true;
            }
        }

        private void btGrabarCli_Click(object sender, EventArgs e)
        {
            if (!fncGrabaCliProd())
            {
                MessageBox.Show("Se ha producido un error al grabar el Producto del Cliente");
                return;
            }

            btGrabarCli.Visible=false;
        }

        private void btMaterial_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btPrioMaq1_Click(object sender, EventArgs e)
        {
            string vTabla = "GC_Maquinas";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "IdMaquina", txPrioMaq1.Text, "", "", "", false, "", "", "", "SQL");

            if (vRes != "")
            {

                txPrioMaq1.Text = vRes;
                bS1.RaiseListChangedEvents = true;
                bS1.EndEdit();

                Application.DoEvents();
                txPrioMaq1.Focus();
            }

        }

        private void btPrioMaq2_Click(object sender, EventArgs e)
        {
            string vTabla = "GC_Maquinas";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "IdMaquina", txPrioMaq2.Text, "", "", "", false, "", "", "", "SQL");

            if (vRes != "")
            {

                txPrioMaq2.Text = vRes;
                bS1.RaiseListChangedEvents = true;
                bS1.EndEdit();

                Application.DoEvents();
                txPrioMaq2.Focus();
            }

        }

        private void btPrioMaq3_Click(object sender, EventArgs e)
        {
            string vTabla = "GC_Maquinas";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "IdMaquina", txPrioMaq3.Text, "", "", "", false, "", "", "", "SQL");

            if (vRes != "")
            {

                txPrioMaq3.Text = vRes;
                bS1.RaiseListChangedEvents = true;
                bS1.EndEdit();

                Application.DoEvents();
                txPrioMaq3.Focus();
            }

        }

        private void btBlockMOlde_Click(object sender, EventArgs e)
        {
            string vstrBlo = "";
            if (btBlockMOlde.BackColor == Color.Red)
            {
                vstrBlo = "bloquear";
            }
            else
            {
                vstrBlo = "desbloquear";

            }
            if (txMolde.Text == "")
            {
                MessageBox.Show("No hay molde para " + vstrBlo);
                return;
            }



            string vMen = vstrBlo + " el molde ,¿Es correcto?";
            string vTit = "OF";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            if (!fncSeguridad("",""))
            {
                MessageBox.Show("Sin Permiso");
                return;
            }

            if (btBlockMOlde.BackColor == Color.Red)
            {
                cProduc.Moldes.fncActuCampoMoldes(cParamXml.Emp.ToString(), txMolde.Text, "Bloqueado", "1");
                lbMolBloq.Text = "Molde Bloqueado";
                lbMolBloq.BackColor = Color.Red;
                txMolde.BackColor = Color.Red;
                btBlockMOlde.Text = "Desbloquear Molde";
                btBlockMOlde.BackColor = Color.Green;
            }
            else
            {
                cProduc.Moldes.fncActuCampoMoldes(cParamXml.Emp.ToString(), txMolde.Text, "Bloqueado", "0");
                lbMolBloq.Text = "";
                lbMolBloq.BackColor = Color.White;
                txMolde.BackColor = Color.White;
                btBlockMOlde.Text = "Bloquear Molde";
                btBlockMOlde.BackColor = Color.Red;

            }
            

        }


    }
}
