using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GesInject.Clases;
using jControles.Clases;
using Cryp;


namespace GesInject.Formularios
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

                if ((txPasCan.Text != ""))
                {
                    txPasCan.Text = oCrypto.Decryp(txPasCan.Text, cConstantes.Cyptokey);

                }

                if ((txPasAnex.Text != ""))
                {
                    txPasAnex.Text = oCrypto.Decryp(txPasAnex.Text, cConstantes.Cyptokey);

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

        private void btProducto_Click(object sender, EventArgs e)
        {


            jControles.Formularios.frmAuto frm = new jControles.Formularios.frmAuto();
            frm.Tabla = "GC_NumSerie";
            frm.Where = "WHERE (Empresa = " + cParamXml.Emp + ")";
            frm.Edit = "E2";
            frm.CamposVis = "2,3,4";
            frm.TextoCab = "";
            frm.Titulo = "Contadores";
            frm.Default = "Empresa#" + cParamXml.Emp;
            frm.Conexion = cParamXml.strConec;
            frm.ShowDialog();
            string vRes = frm.Res;
            frm.Dispose();

            if (vRes != "")
            {
                txPedCli.Text = vRes;
                Application.DoEvents();
                txPedCli.Focus();
            }






            //string vTabla = "GC_NumSerie";
            //string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "Serie", txPedCli.Text, "", "", "", false, "", "", "", "SQL");

            //if (vRes != "")
            //{
            //    txPedCli.Text = vRes;
            //    Application.DoEvents();
            //    txPedCli.Focus();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vTabla = "GC_NumSerie";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "Serie", txPedProv.Text, "", "", "", false, "", "", "", "SQL");

            if (vRes != "")
            {
                txPedProv.Text = vRes;
                Application.DoEvents();
                txPedProv.Focus();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string vTabla = "GC_NumSerie";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "Serie", txOrdProd.Text, "", "", "", false, "", "", "", "SQL");

            if (vRes != "")
            {
                txOrdProd.Text = vRes;
                Application.DoEvents();
                txOrdProd.Focus();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btDirImProd_Click(object sender, EventArgs e)
        {
            if (txDirImProd.Text != "") { fB1.SelectedPath = txDirImProd.Text; }
            System.Windows.Forms.DialogResult vRes = DialogResult.Abort;
            vRes = fB1.ShowDialog();
            if (vRes == System.Windows.Forms.DialogResult.OK)
            {
                txDirImProd.Text = fB1.SelectedPath;
            }
            if (vRes == System.Windows.Forms.DialogResult.Cancel)
            {
                if (txDirImProd.Text != "")
                {
                    string vMen = "Se ha selecionado Cancelar.¿Desea Borrar el dato actual?";
                    string vTit = "";
                    if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txDirImProd.Text = "";
                    }
                }
            }
        }

        private void btDirDocProd_Click(object sender, EventArgs e)
        {
            if (txDirDocProd.Text != "") { fB1.SelectedPath = txDirDocProd.Text; }
            System.Windows.Forms.DialogResult vRes = DialogResult.Abort;
            vRes = fB1.ShowDialog();
            if (vRes == System.Windows.Forms.DialogResult.OK)
            {
                txDirDocProd.Text = fB1.SelectedPath;
            }
            if (vRes == System.Windows.Forms.DialogResult.Cancel)
            {
                if (txDirDocProd.Text != "")
                {
                    string vMen = "Se ha selecionado Cancelar.¿Desea Borrar el dato actual?";
                    string vTit = "";
                    if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txDirDocProd.Text = "";
                    }
                }
            }
        }

        private void btPrintGen_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult vRes = DialogResult.Abort;
            vRes = print1.ShowDialog();
            if (vRes == System.Windows.Forms.DialogResult.OK)
            {
                txPrintGen.Text = print1.PrinterSettings.PrinterName.ToString();
            }
            if (vRes == System.Windows.Forms.DialogResult.Cancel)
            {
                if (txPrintGen.Text != "")
                {
                    string vMen = "Se ha selecionado Cancelar.¿Desea Borrar el dato actual?";
                    string vTit = "Parametros";
                    if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txPrintGen.Text = "";
                    }
                }
            }
        }

        private void btPrintEtiCajaBolsa_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult vRes = DialogResult.Abort;
            vRes = print1.ShowDialog();
            if (vRes == System.Windows.Forms.DialogResult.OK)
            {
                txPrintEtiCajaBolsa.Text = print1.PrinterSettings.PrinterName.ToString();
            }
            if (vRes == System.Windows.Forms.DialogResult.Cancel)
            {
                if (txPrintEtiCajaBolsa.Text != "")
                {
                    string vMen = "Se ha selecionado Cancelar.¿Desea Borrar el dato actual?";
                    string vTit = "Parametros";
                    if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txPrintEtiCajaBolsa.Text = "";
                    }
                }
            }
        }

        private void btDirCerMat_Click(object sender, EventArgs e)
        {
            if (txDirCerMat.Text != "") { fB1.SelectedPath = txDirCerMat.Text; }
            System.Windows.Forms.DialogResult vRes = DialogResult.Abort;
            vRes = fB1.ShowDialog();
            if (vRes == System.Windows.Forms.DialogResult.OK)
            {
                txDirCerMat.Text = fB1.SelectedPath;
            }
            if (vRes == System.Windows.Forms.DialogResult.Cancel)
            {
                if (txDirCerMat.Text != "")
                {
                    string vMen = "Se ha selecionado Cancelar.¿Desea Borrar el dato actual?";
                    string vTit = "";
                    if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txDirCerMat.Text = "";
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string vTabla = "GC_NumSerie";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "Serie", txOrdPrep.Text, "", "", "", false, "", "", "", "SQL");

            if (vRes != "")
            {
                txOrdPrep.Text = vRes;
                Application.DoEvents();
                txOrdPrep.Focus();
            }

        }

        private void btAlbCli_Click(object sender, EventArgs e)
        {

            string vTabla = "GC_NumSerie";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "Serie", txAlbCli.Text, "", "", "", false, "", "", "", "SQL");

            if (vRes != "")
            {
                txAlbCli.Text = vRes;
                Application.DoEvents();
                txAlbCli.Focus();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {

            jControles.Formularios.frmAuto frm = new jControles.Formularios.frmAuto();
            frm.Tabla = "GC_NumSerie";
            frm.Where = "WHERE (Empresa = " + cParamXml.Emp + ")";
            frm.Edit = "E2";
            frm.CamposVis = "2,3,4";
            frm.TextoCab = "";
            frm.Titulo = "Contadores";
            frm.Default = "Empresa#" + cParamXml.Emp;
            frm.Conexion = cParamXml.strConec;
            frm.ShowDialog();
            string vRes = frm.Res;
            frm.Dispose();

            if (vRes != "")
            {
                txPedCliMan.Text = vRes;
                Application.DoEvents();
                txPedCliMan.Focus();
            }


        }
    }
}
