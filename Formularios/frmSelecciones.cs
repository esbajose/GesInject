using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GesInject.Clases;


namespace GesInject.Formularios
{
    public partial class frmSelecciones : Form
    {
        private int vTop = 12;

        public static bool vCancel = true;
        public static string vStrConec = "";
        public static DateTime vDesde = DateTime.Now;
        public static DateTime vHasta = DateTime.Now;
        public static bool vSel1 = true;
        public static bool vSel2 = false;
        public static bool vSelFec = true;


                
        public static string vTabla = "";
        public static string vWhere = "";
        public static string vDato = "";
        public static string vCampoParaRespuesta = "";
        public static string vCampoParaRespuestaTrae = "";
        public static string vResPuesta = "";
        public static string vlbDesde="";
        public static string vlbHasta="";
        public static string vtxDesde = "";
        public static string vtxHasta = "";

        public static string vTabla2 = "";
        public static string vWhere2 = "";
        public static string vDato2 = "";
        public static string vCampoParaRespuesta2 = "";
        public static string vCampoParaRespuestaTrae2 = "";
        public static string vResPuesta2 = "";
        public static string vlbDesde2 = "";
        public static string vlbHasta2 = "";
        public static string vtxDesde2 = "";
        public static string vtxHasta2 = "";
        public static string vFiltroSel1 = "";




        #region
        public string fncBusca()
        {
            vResPuesta = cUtil.fncLista(vTabla, vStrConec, vCampoParaRespuesta, vDato, vWhere, "", "",false, "");

            return vResPuesta;
        }
        public string fncBusca2()
        {
            string vTablaF = vTabla2;
            if (txDesde.Text == txHasta.Text)
            {
                if (vFiltroSel1 != "")
                {
                    vTablaF = "v" + vTabla2;
                    if (vWhere2 != "")
                    {
                        vWhere2 = vWhere2 + "  and " + vFiltroSel1 + " = '" + txDesde.Text + "'";
                    }
                    else
                    {
                        vWhere2 = " where  " + vFiltroSel1 + " = '" + txDesde.Text + "'";
                    }
                }
            }


            vResPuesta = cUtil.fncLista(vTablaF, vStrConec, vCampoParaRespuesta2, vDato2, vWhere2, "", "", false, "");

            return vResPuesta;
        }


        public string fncTrae(string vCampo)
        {
            string vDes="";
            string vWhere = vCampoParaRespuesta + " = '" + vCampo + "' ";
            vDes = cUtil.fncTraeCampo(vCampoParaRespuestaTrae, vTabla, vWhere);
            return vDes;
        }
        public string fncTrae2(string vCampo)
        {
            string vDes = "";
            string vWhere2 = vCampoParaRespuesta2 + " = '" + vCampo + "' ";
            vDes = cUtil.fncTraeCampo(vCampoParaRespuestaTrae2, vTabla2, vWhere2);
            return vDes;
        }

        #endregion



        public frmSelecciones()
        {
            InitializeComponent();
        }

        private void frmSelecciones_Load(object sender, EventArgs e)
        {
            pSel1.Visible = false;
            pSel2.Visible = false;
            pSelFec.Visible = false;

            if (vSel1) { pSel1.Top = vTop; vTop = vTop + pSel1.Height + 12; pSel1.Visible = true; }
            if (vSel2) { pSel2.Top = vTop; vTop = vTop + pSel2.Height + 12; pSel2.Visible = true; }
            if (vSelFec) { pSelFec.Top = vTop; vTop = vTop + pSelFec.Height + 12; pSelFec.Visible = true; }



            lbDesde.Text = vlbDesde;
            lbHasta.Text = vlbHasta;

            txDesde.Text = vtxDesde;
            txHasta.Text = vtxHasta;


            lbDesde2.Text = vlbDesde2;
            lbHasta2.Text = vlbHasta2;

            txDesde2.Text = vtxDesde2;
            txHasta2.Text = vtxHasta2;
            
            dtDesde.Value = vDesde;
            dtHasta.Value = vHasta;

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            vCancel = true;
            this.Close();
        }

        private void btAcceptar_Click(object sender, EventArgs e)
        {
            vDesde = dtDesde.Value;
            vHasta = dtHasta.Value;

            vtxDesde = txDesde.Text;
            vtxHasta = txHasta.Text;

            vtxDesde2 = txDesde2.Text;
            vtxHasta2 = txHasta2.Text;

            vCancel = false;
            this.Close();

        }

        private void btDesde_Click(object sender, EventArgs e)
        {
            string vDesde = fncBusca();

            txDesde.Text = vDesde;

        }

        private void btHasta_Click(object sender, EventArgs e)
        {
            txHasta.Text = fncBusca();

        }

        private void txDesde_TextChanged(object sender, EventArgs e)
        {
            if (txDesde.Text != "")
            {
                string vlbDesde = fncTrae(txDesde.Text);
                lbdDesde.Text = vlbDesde;
            }
            txHasta.Text = txDesde.Text;
        }

        private void txHasta_TextChanged(object sender, EventArgs e)
        {
            lbdHasta.Text = fncTrae(txHasta.Text);
        }

        private void btDesde2_Click(object sender, EventArgs e)
        {
            string vDesde = fncBusca2();

            txDesde2.Text = vDesde;
        }

        private void btHasta2_Click(object sender, EventArgs e)
        {
            txHasta2.Text = fncBusca2();

        }

        private void txDesde2_TextChanged(object sender, EventArgs e)
        {
            if (txDesde2.Text != "")
            {
                string vlbDesde = fncTrae2(txDesde2.Text);
                lbdDesde2.Text = vlbDesde;
            }

            txHasta2.Text = txDesde2.Text;

        }

        private void txHasta2_TextChanged(object sender, EventArgs e)
        {
            lbdHasta2.Text = fncTrae2(txHasta2.Text);

        }

        private void frmSelecciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            txDesde.Text = "";
            txHasta.Text = "";
            txDesde2.Text = "";
            txHasta2.Text = "";
            vWhere2 = "";
            vWhere = "";

        }

    }
}
