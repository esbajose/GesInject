using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GesInject.Clases;

namespace GesInject.Formularios
{

    public partial class frmInput : Form
    {
        public static string vTexto = "";
        public static string vRes = "";
        public static string vTit = "";
        public static string vBt = "";
        public static bool vOpt = false;
        public static bool vCh = false;
        public static bool vMulti = false;
        public static string vSep = "";

        public static string[] vLista;
        private string vtxOpt = "";
        public static string vRel = "";
        public static string vRelTot = "";
        public static string vCampoRel = "";

        #region Procesos Locales

        private void sbrCreaOpt()
        {
            this.Width = 400;
            if (!vCh)
            {
                for (int i = 0; i < vLista.Length; i++)
                {

                    int vTop = (i + 1) * 20;
                    RadioButton ch = new RadioButton();
                    ch.Name = "chek" + i.ToString();
                    ch.AutoSize = true;
                    ch.Left = 20;
                    //ch.CheckAlign = ContentAlignment.MiddleRight;
                    ch.Visible = true;
                    ch.Text = vLista[i].ToString();
                    ch.Top = vTop;
                    ch.CheckedChanged += new System.EventHandler(this.ch_CheckedChanged);
                    if (i == 0) { ch.Checked = true; }
                    this.Controls.Add(ch);
                }
                this.Height = (vLista.Length * 20) + 80;
            }
            else
            {
                for (int i = 0; i < vLista.Length; i++)
                {

                    int vTop = (i + 1) * 20;
                    CheckBox ch = new CheckBox();
                    ch.Name = "chek" + i.ToString();
                    ch.AutoSize = true;
                    ch.Left = 20;
                    //ch.CheckAlign = ContentAlignment.MiddleRight;
                    ch.Visible = true;
                    ch.Text = vLista[i].ToString();
                    ch.Top = vTop;
                    ch.CheckedChanged += new System.EventHandler(this.ch_CheckedChanged);
                    //if (i == 0) { ch.Checked = true; }
                    this.Controls.Add(ch);
                }
            }
            this.Height = (vLista.Length * 20) + 80;

        }

        #endregion

        public frmInput()
        {
            InitializeComponent();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            vRes = "*****Cancelado*****";
            vLista = null;
            vRel = "";
            vCampoRel = "";
            this.Close();
        }

        private void frmInput_Load(object sender, EventArgs e)
        {
            vRelTot = "";
            btRel.Visible = false;
            if (!vOpt)
            {
                lbText.Text = vTexto;
                cbLista.Top = txRes.Top;
                txRes.Text = vRes;
                this.Text = vTit;
                if ((vLista != null))
                {
                    cbLista.Items.Clear();
                    for (int i = 0; i < vLista.Length; i++)
                    {

                        cbLista.Items.Add(vLista[i].ToString());
                    }
                    cbLista.Visible = true;
                    txRes.Visible = false;
                    cbLista.Focus();
                }
                else
                {
                    cbLista.Visible = false;
                    txRes.Visible = true;
                    txRes.Focus();
                }
            }
            if (vOpt)
            {
                lbText.Text = vTexto;
                txRes.Text = vRes;
                this.Text = vTit;
                cbLista.Visible = false;
                txRes.Visible = false;
                lbText.Visible = false;
                sbrCreaOpt();
            }
            if (vRel != "")
            {
                cbLista.Visible = false;
                btRel.Visible = true;
                txRes.Visible = true;

            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if ((vLista != null))
            {
                txRes.Text = cbLista.Text;
            }
            if (vOpt)
            {
                txRes.Text = vtxOpt;
            }
            if (vMulti)
            {
                txRes.Text = "";
                foreach (Control vctl in this.Controls)
                {
                    string vName = vctl.Name;
                    string vDes = vctl.Text;
                    string vCod = cUtil.Piece(vDes,vSep,1);
                    if (vName.LastIndexOf("chek") !=-1)
                    {
                        bool vcheck = ((CheckBox)vctl).Checked;
                        if (vcheck)
                        {
                            txRes.Text = txRes.Text + vCod + vSep; 
                        }
                    }
                }
                if (txRes.Text != "") { txRes.Text = txRes.Text.Substring(0, txRes.Text.Length - 1); }
            }
 
            vRes = txRes.Text;
            if (vRelTot == "") { vRelTot = vRes; }
            vLista = null;
            this.Close();
        }

        private void txRes_TextChanged(object sender, EventArgs e)
        {

        }

        private void txRes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (vBt == "1")
                {
                    btAceptar.Focus();
                }
                else
                {
                    btCancelar.Focus();
                }
            }
        }

        private void frmInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            vLista = null;
            vRel = "";
            vCampoRel = "";
            vOpt = false;
            vCh = false;
        }

        private void ch_CheckedChanged(object sender, EventArgs e)
        {
            if (!vCh)
            {
                RadioButton rb = new RadioButton();
                rb = (RadioButton)sender;

                if (rb.Checked)
                {
                    vtxOpt = rb.Text;
                }
                else
                {
                    vtxOpt = "";
                }
            }
            else
            {
                CheckBox rb = new CheckBox();
                rb = (CheckBox)sender;

                if (rb.Checked)
                {
                    vtxOpt = rb.Text;
                }
                else
                {
                    vtxOpt = "";
                }

           }
        }

        private void btRel_Click(object sender, EventArgs e)
        {
            string vTabla = vRel;
            string vRes = cUtil.fncLista(vTabla, cConstantes.NaviConecStrCosmic, vCampoRel, txRes.Text );

            if (vRes != "")
            {
                vRelTot = vRes;
                txRes.Text = cUtil.Piece(vRes, "#", 1);
            }

        }

    }
}