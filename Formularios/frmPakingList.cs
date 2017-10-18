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
using System.Data.SqlClient;


namespace GesInject.Formularios
{
    public partial class frmPakingList : Form
    {
        public frmPakingList()
        {
            InitializeComponent();
        }

        #region Procesos locales
        private void sbrCarga()
        {
            int vTodos = 0;
            if (chTodos.Checked) vTodos = 1;

            string vSql = cConstantes.SQL_PakingList_Lista;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?Impre]", vTodos.ToString());

            if (vTodos == 0)
            {
                vSql += " AND (GC_LinAlbCli.Impresiones = 0)";
            }


            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));


            grLista.DataSource = null;
            grLista.DataSource = dt.DefaultView;

            //grLista.Columns["ID"].Visible = false;

        }





        #endregion



        private void frmPakingList_Load(object sender, EventArgs e)
        {
            sbrCarga();

        }

        private void btActu_Click(object sender, EventArgs e)
        {
            sbrCarga();

        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            DataView dtv = (DataView)grLista.DataSource;
            DataTable dtLista = dtv.ToTable();
            cUtil.sbrCreaExcel(dtLista, "PackingList");

        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            DataView dtv = (DataView)grLista.DataSource;
            DataTable dtLista = dtv.ToTable();
            cInformes.Imp = (cParamXml.Imp == "True") ? true : false;
            cInformes.sbrPrintPakingList(cParamXml.Emp.ToString(), dtLista,chLinea.Checked);

            foreach (DataRow dr in dtLista.Rows)
            {
                string vAlb = dr["NumAlb"].ToString();
                string vLinea = dr["Linea"].ToString();
                int vImp = (int)dr["Impresiones"];
                vImp++;

                string vSql = cConstantes.SQL_UP_Update;
                vSql = vSql.Replace("[?1]", "[" + "Impresiones" + "]");
                vSql = vSql.Replace("[?2]", vImp.ToString());
                vSql = vSql.Replace("[?3]", " Empresa = " + cParamXml.Emp.ToString() + " and NumAlb ='" + vAlb + "' and Linea =" + vLinea + "");
                vSql = vSql.Replace("[?99]", "GC_LinAlbCli");
                int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConecProduc_Prueb);

            }

        }

        private void chPen_CheckedChanged(object sender, EventArgs e)
        {
            sbrCarga();

        }

        private void chTodos_CheckedChanged(object sender, EventArgs e)
        {
            sbrCarga();

        }
    }
}
