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
    public partial class frmDirEntrega : Form
    {
        public static string vCliente="";
        public static int vIdEnt = 0;
        public static string vDirección = "";
        public static string vPoblación = "";
        public static string vProvincia = "";
        public static string vCP = "";

        private bool vRemoto = false;
        public frmDirEntrega()
        {
            InitializeComponent();
        }


        #region Binding (DirEntregas)


        public void sbrBindCampos(Control vControles)
        {
            foreach (Control vctl in vControles.Controls)
            {
                if (vctl.Controls.Count > 0)
                {
                    sbrBindCampos(vctl);
                }
                int vBinding = vctl.DataBindings.Count;

                if ((vctl.Tag != null)&(vBinding == 0))
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
            Control ctl;
            ctl = (Control)sender;
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
        }

        #endregion


        #region Procesos

        private void sbrCargaDir()
        {
            try
            {

                bS1.DataSource = cClientes.Lista(txCodCli.Text);
                Navi1.BindingSource = bS1;
                if (bS1.Count == 0)
                {
                    btDel.Enabled = false;
                    //Si No hay Ninguna Dirección de entrega se Crea la 0 con los datos del cliente
                    fncCreaDir0(txCodCli.Text);
                    bS1.DataSource = cClientes.Lista(txCodCli.Text);
                    Navi1.BindingSource = bS1;
                    if (bS1.Count == 0)
                    {
                        MessageBox.Show("Se ha producido un error al crear la dirección 0");
                        return;
                    }



                }
                else
                {
                    btDel.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                this.Close();
            }
        }
        private void sbrActuDatos()
        {
            bS1.DataSource = cClientes.Lista(txCodCli.Text);
        }

        private void fncCreaDir0(string vCli)
        {
            DataRow dr;
            string vDir = "";
            string vPobla = "";
            string vProv = "";
            string vCP = "00000";
            
            string vWhere = " ccodcli = '" + txCodCli.Text + "' ";
            dr = cUtil.fncTraeCampos("clientes", vWhere, cParamXml.strOleDBConecDbf, "DBF");

            if (dr != null)
            {
                vDir = dr["cdircli"].ToString();
                vPobla = dr["cpobcli"].ToString();
                vCP = dr["cptlcli"].ToString();
                vProv = dr["cpobcli"].ToString();
            }

            cClientes.DirEntrega oDir = new cClientes.DirEntrega();
            oDir.Dirección = vDir;
            oDir.Empresa = cParamXml.Emp;
            oDir.CodCli = vCli;
            oDir.CP = vCP;
            oDir.Población = vPobla;
            oDir.fncAlta0(0);


        }
        private void sbrBuscaCli()
        {
            string vTabla = "clientes";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "ccodcli", txCodCli.Text, "", "", "", false, "", "", "", "DBF");

            if (vRes != "")
            {
                txCodCli.Text = vRes;
                Application.DoEvents();
                panel2.Enabled = true;
                sbrCargaDir();
                sbrBindCampos(this);
                panel1.Enabled = false;
                txdirección.Focus();
            }

        }

        private void sbrBuscaDir(string vCli)
        {
            //string vTabla = "[GC_DirEntregas]";
            //string vWhere = " Where empresa = " + cParamXml.Emp + " and Codcli ='" + vCli + "'";
            //string vRes = cUtil.fncLista(vTabla, cParamXml.strConec, "IdEntrega", "", vWhere);

            //if (vRes != "")
            //{
            //    int vReg = cPedidosVenta.fncBuscaIndexCabPed (bS1, vRes);
            //    bS1.Position = vReg;
            //}

        }


        private void sbrAltaDir()
        {
            
            try
            {

                cClientes.DirEntrega dirent = (cClientes.DirEntrega)bS1.Current;
                int vId = dirent.fncAlta();
                if (vId == 0)
                {
                    MessageBox.Show("No se ha podido dar de Alta la Dirección de Entrega");
                    return;
                }

                sbrActuDatos();

                bS1.MoveLast();
                btDel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido dar de Alta el Pedido :'" + ex.Message + "'");
                bS1.CancelEdit();

            }

        }

        private void sbrModifCampo(string vCampo, string vValor)
        {
            cClientes.DirEntrega dirent = (cClientes.DirEntrega)bS1.Current;

            if (dirent.aCampoModif != "") { vCampo = dirent.aCampoModif; }
            if (dirent.aValor != "") { vValor = dirent.aValor; }

            if (!dirent.fncGrabaCampo(vCampo, vValor))
            {
                MessageBox.Show("No se ha podido Grabar el Dato");
                bS1.CancelEdit();
            }

        }

        public void sbrBusca()
        {
            string vTabla = "";
            string vWhere = "";
            string vRes = "";

                sbrBuscaCli();



        }

        #endregion


        private void btCliente_Click(object sender, EventArgs e)
        {
            sbrBuscaCli();
        }

        private void btAlta_Click(object sender, EventArgs e)
        {
            string vMen = "¿Dar de Alta un nueva dirección de entrega?";
            string vTit = "Clientes";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sbrAltaDir();
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
                //    txdirección.Text = dr["cdircli"].ToString();
                //    txPoblación.Text = dr["cpobcli"].ToString();
                //    txCP.Text = dr["cptlcli"].ToString();
                //    txProvincia.Text = dr["cpobcli"].ToString();
            }

        }

        private void toolBus_Click(object sender, EventArgs e)
        {
            sbrBuscaCli();
        }

        private void frmDirEntrega_Load(object sender, EventArgs e)
        {
            btSel.Visible = false;
            btCancel.Visible = true;
            vRemoto = false;

            vIdEnt = 0;
            if (vCliente != "")
            {
                txCodCli.Text = vCliente;
                vCliente = "";
                vDirección = "";
                vPoblación = "";
                vProvincia = "";
                vCP = "";
                panel1.Enabled = false;
                panel2.Enabled = true;
                btSel.Visible = true;
                vRemoto = true;

                sbrCargaDir();
                sbrBindCampos(this);
                txdirección.Focus();


            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (vRemoto) { this.Close(); return; }
            txCodCli.Text = "";
            txCP.Text="";
            txdirección.Text = "";
            txPoblación.Text = "";
            txProvincia.Text = "";
            lbNomCli.Text = "";
            panel2.Enabled = false;
            panel1.Enabled = true;
            txCodCli.Focus();
        }

        private void frmDirEntrega_KeyUp(object sender, KeyEventArgs e)
        {
            Control ctl;
            ctl = (Control)sender;
            string vControl = ctl.Name;

            string vTecla = e.KeyCode.ToString();
            //if ((vTecla == "F3") | (vTecla == "Escape") | (vTecla == "Tab"))
            //{
            //    sbrTecla(vTecla);
            //    e.Handled = true;
            //}

            if (e.Control && e.KeyCode == Keys.B)
            {
                try
                {
                    if (panel1.Enabled) { sbrBuscaCli(); }
                    //if (panel2.Enabled) { sbrBuscaDir(); }
                    e.Handled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
                return;
            }
        }

        private void btSel_Click(object sender, EventArgs e)
        {
            vIdEnt = Convert.ToInt32(txId.Text);
            vDirección = txdirección.Text;
            vPoblación = txPoblación.Text;
            vProvincia = txProvincia.Text;
            vCP = txCP.Text;
            this.Close();
        }
    }
}
