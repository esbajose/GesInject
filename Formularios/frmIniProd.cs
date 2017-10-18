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
    public partial class frmIniProd : Form
    {
        public static string vOper = "";
        public static string vDesOper = "";
        public static string vMaq = "";
        public static string vDesMaq = "";
        public static bool vCancel = false;
        public static bool vVerOper = true;
        public static bool vVerMaq = true;


        #region Procesos locales

        private void sbrBuscaOper()
        {
            string vTabla = "GC_Operarios";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "IdOper", txOper.Text, "", "", "", false, "", "", "", "SQL");

            if (vRes != "")
            {

                txOper.Text = vRes;
                txOper.Focus();
            }


        }
        private void sbrBuscaMaq()
        {
            string vTabla = "GC_Maquinas";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "IdMaquina", txMaq.Text, "", "", "", false, "", "", "", "SQL");

            if (vRes != "")
            {

                txMaq.Text = vRes;
                txMaq.Focus();
            }
        }
        #endregion
        public frmIniProd()
        {
            InitializeComponent();
        }

        private void frmIniProd_Load(object sender, EventArgs e)
        {
            panelOper.Visible = vVerOper;
            panelMaq.Visible = vVerMaq;

            if (vOper != "") { txOper.Text = vOper; }

            if (vMaq != "") { txMaq.Text = vMaq; }



            vCancel = false;
        }

        private void txOper_TextChanged(object sender, EventArgs e)
        {
            if (txOper.Text != "")
            {
                DataRow dr;
                string vWhere = " Empresa = " + cParamXml.Emp + " and IdOper = '" + txOper.Text + "' ";
                dr = cUtil.fncTraeCampos("GC_Operarios", vWhere, cParamXml.strConecProduc_Prueb, "SQL");
                lbOper.Text = "";
                if (dr != null)
                {
                    lbOper.Text = dr["Nombre"].ToString();
                }
            }

        }

        private void txMaq_TextChanged(object sender, EventArgs e)
        {
            if (txMaq.Text != "")
            {
                DataRow dr;
                string vWhere = " Empresa = " + cParamXml.Emp + " and IdMaquina = '" + txMaq.Text + "' ";
                dr = cUtil.fncTraeCampos("GC_Maquinas", vWhere, cParamXml.strConecProduc_Prueb, "SQL");
                lbMaq.Text = "";
                if (dr != null)
                {
                    lbMaq.Text = dr["Descripción"].ToString();
                }
            }

        }

 
        private void btCancel_Click(object sender, EventArgs e)
        {
            vCancel = true;
            this.Close();

        }

        private void btIni_Click(object sender, EventArgs e)
        {

            if ((lbOper.Text == "")&vVerOper)
            {
                MessageBox.Show("No se ha selecionado un Operario");
                return;
            }
            if ((lbMaq.Text == "") & vVerMaq)
            {
                MessageBox.Show("No se ha selecionado una Maquina");
                return;
            }

            vCancel = false;
            vOper = txOper.Text;
            vDesOper = lbOper.Text;
            vMaq = txMaq.Text;
            vDesMaq = lbMaq.Text;

            this.Close();
        }

        private void btOper_Click(object sender, EventArgs e)
        {
            sbrBuscaOper();
        }

        private void btMaq_Click(object sender, EventArgs e)
        {
            sbrBuscaMaq();


        }

        private void frmIniProd_KeyUp(object sender, KeyEventArgs e)
        {
            string vTecla = e.KeyCode.ToString();
            if (vTecla == "F5")
            {
                sbrBuscaOper();
                e.Handled = true;
            }
            if (vTecla == "F6")
            {
                sbrBuscaMaq();
                e.Handled = true;
            }

        }

        private void frmIniProd_FormClosing(object sender, FormClosingEventArgs e)
        {
            vVerOper = true;
            vVerMaq = true;
        }
    }
}
