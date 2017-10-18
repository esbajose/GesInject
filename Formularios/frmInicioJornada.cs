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
    public partial class frmInicioJornada : Form
    {
        public frmInicioJornada()
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

        private void sbrCargaMaq()
        {
            string vSql = cConstantes.SQL_MaqProd_Lista;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());

            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));

            grMaq.DataSource = "";
            grMaq.DataSource = dt.DefaultView;



        }

        private void sbrMarcarTodo(bool vMarcar)
        {
            foreach (DataGridViewRow dr in grMaq.Rows)
            {
                try
                {
                    if (dr.Visible)
                    {
                        dr.Cells["Sel"].Value = vMarcar;
                    }
                }
                catch { }
            }
        }

        private void sbrIniJornada()
        {

            foreach (DataGridViewRow dr in grMaq.Rows)
            {
                string vSel = "";
                string vOFL = "";
                string vLote = "";
                string vMaq = "";
                string vDesMaq = "";
                if (dr.Cells[0].Value != null) vSel = dr.Cells[0].Value.ToString();
                if (dr.Cells["IdOF"].Value != null) vOFL = dr.Cells["IdOF"].Value.ToString();
                if (dr.Cells["Lote"].Value != null) vLote = dr.Cells["Lote"].Value.ToString();
                if (dr.Cells["IdMaquina"].Value != null) vMaq = dr.Cells["IdMaquina"].Value.ToString();
                if (dr.Cells["DesMaquina"].Value != null) vDesMaq = dr.Cells["DesMaquina"].Value.ToString();

                if (vSel == "1")
                {


                    string vTabla = "GC_EnProducción";
                    string vWhere = " Empresa = " + cParamXml.Emp.ToString() + " and IdOF ='" + vOFL + "'";

                    cUtil.fncActuCampo("IdOper", vTabla, vWhere, "", txOper.Text);
                    cUtil.fncActuCampo("NombreOper", vTabla, vWhere, "", lbOper.Text);
                }
            }

        }

        #endregion

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
                    grupoMaq.Enabled = true;
                   
                }
                else
                {
                    grupoMaq.Enabled = false;
                    grMaq.DataSource = null;

                }
            }
        }

        private void btOper_Click(object sender, EventArgs e)
        {
            sbrBuscaOper();

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInicioJornada_Load(object sender, EventArgs e)
        {
            sbrCargaMaq();

        }

        private void frmInicioJornada_KeyUp(object sender, KeyEventArgs e)
        {
            string vTecla = e.KeyCode.ToString();
            if (vTecla == "F5")
            {
                sbrBuscaOper();
                e.Handled = true;
            }

        }

        private void btIni_Click(object sender, EventArgs e)
        {
            if (lbOper.Text == "")
            {
                MessageBox.Show("No se ha selecionado un Operario");
                return;
            }
            sbrIniJornada();
            this.Close();
        }

        private void btSelTot_Click(object sender, EventArgs e)
        {
            string vMen = "¿Marcar todos los registros?";
            string vTit = "Iniciar Jornada";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sbrMarcarTodo(true);
            }

        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            string vMen = "¿Desmarcar todos los registros?";
            string vTit = "Iniciar Jornada";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sbrMarcarTodo(false);
            }
        }
    }
}
