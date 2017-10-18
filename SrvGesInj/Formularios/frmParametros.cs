using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SrvGesInj.Clases;
using jControles.Clases;
using Cryp;


namespace SrvGesInj.Formularios
{
    public partial class frmParametros : Form
    {
        public static string vInicio = "";
        public frmParametros()
        {
            InitializeComponent();
        }

        private void btGrabar_Click(object sender, EventArgs e)
        {
            vInicio = "";
            cParam.Graba(this.Controls, false, false);
            vInicio = "";
            cParamXml.Carga();
            this.Close();

        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmParametros_Load(object sender, EventArgs e)
        {
            try
            {



                Crypto oCrypto = new Crypto();
                
                foreach (Control obj in this.Controls)
                {
                    cParam.fncCargaParam(obj.Controls);
                }
                if ((txPassUserDB.Text != ""))
                {
                    txPassUserDB.Text = oCrypto.Decryp(txPassUserDB.Text, cConstantes.Cyptokey);

                }

                if ((txPassAdmin.Text != ""))
                {
                    txPassAdmin.Text = oCrypto.Decryp(txPassAdmin.Text, cConstantes.Cyptokey);

                }

            }
            catch
            {
            }
        }

        private void txPass_TextChanged(object sender, EventArgs e)
        {

            Crypto oCrypto = new Crypto();
            string vPass = txPass.Text;
            string vPassAdmin = cParamXml.PassAdmin;
            if (vPass == vPassAdmin)
            {
                tabControl1.Enabled = true;
                txPass.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btDirDocMec_Click(object sender, EventArgs e)
        {

            if (txDirDBF.Text != "") { fB1.SelectedPath = txDirDBF.Text; }
            System.Windows.Forms.DialogResult vRes = DialogResult.Abort;
            vRes = fB1.ShowDialog();
            if (vRes == System.Windows.Forms.DialogResult.OK)
            {
                txDirDBF.Text = fB1.SelectedPath;
            }
            if (vRes == System.Windows.Forms.DialogResult.Cancel)
            {
                if (txDirDBF.Text != "")
                {
                    string vMen = "Se ha selecionado Cancelar.¿Desea Borrar el dato actual?";
                    string vTit = "";
                    if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txDirDBF.Text = "";
                    }
                }
            }

        }


        private void btDirXml_Click(object sender, EventArgs e)
        {
            if (txDirXML.Text != "") { fB1.SelectedPath = txDirXML.Text; }
            System.Windows.Forms.DialogResult vRes = DialogResult.Abort;
            vRes = fB1.ShowDialog();
            if (vRes == System.Windows.Forms.DialogResult.OK)
            {
                txDirXML.Text = fB1.SelectedPath;
            }
            if (vRes == System.Windows.Forms.DialogResult.Cancel)
            {
                if (txDirXML.Text != "")
                {
                    string vMen = "Se ha selecionado Cancelar.¿Desea Borrar el dato actual?";
                    string vTit = "";
                    if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txDirXML.Text = "";
                    }
                }
            }

        }

        private void btSerProv_Click(object sender, EventArgs e)
        {
            string vTabla = "GC_NumSerie";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "Serie", txOrdAlbProv.Text, "", "", "", false, "", "", "", "SQL");

            if (vRes != "")
            {

                txOrdAlbProv.Text = vRes;
                Application.DoEvents();
                txOrdAlbProv.Focus();
            }

        }

        private void btSerCli_Click(object sender, EventArgs e)
        {
            string vTabla = "GC_NumSerie";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "Serie", txOrdAlbCli.Text, "", "", "", false, "", "", "", "SQL");

            if (vRes != "")
            {
                txOrdAlbCli.Text = vRes;
                Application.DoEvents();
                txOrdAlbCli.Focus();
            }

        }

        private void btSerPedCli_Click(object sender, EventArgs e)
        {
            string vTabla = "GC_NumSerie";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "Serie", txOrdPedCli.Text, "", "", "", false, "", "", "", "SQL");

            if (vRes != "")
            {
                txOrdPedCli.Text = vRes;
                Application.DoEvents();
                txOrdPedCli.Focus();
            }
        }

    }
}
