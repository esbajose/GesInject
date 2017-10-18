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
    public partial class frmFinJornada : Form
    {
        public frmFinJornada()
        {
            InitializeComponent();
        }

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



        #endregion

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btIni_Click(object sender, EventArgs e)
        {
            if (lbOper.Text == "")
            {
                MessageBox.Show("No se ha selecionado un Operario");
                return;
            }

            string vMen = "Finalizar la jornada?";
            string vTit = "Jornada";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    cProduc.OF.fncFinJornada(cParamXml.Emp, txOper.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se ha podido finalizar la Jornada :'" + ex.Message + "'");

                }

                this.Close();
            }



        }

        private void frmFinJornada_Load(object sender, EventArgs e)
        {
            

        }

        private void frmFinJornada_Shown(object sender, EventArgs e)
        {
            if (cUtil.fncExisteVentanaMDI((Form)this.MdiParent, "frmProducción", 0))
            {
                //MessageBox.Show("Ya existe una ventana de 'Puestos de Trabajo' abierta");

                cUtil.fncCerrarVentanaMDI((Form)this.MdiParent, "frmProducción", false);

            }

        }

        private void btOper_Click(object sender, EventArgs e)
        {
            sbrBuscaOper();

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

        private void frmFinJornada_KeyUp(object sender, KeyEventArgs e)
        {
            string vTecla = e.KeyCode.ToString();
            if (vTecla == "F5")
            {
                sbrBuscaOper();
                e.Handled = true;
            }

        }
    }
}
