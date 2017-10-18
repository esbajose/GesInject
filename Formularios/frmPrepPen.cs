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


namespace GesInject.Formularios
{
    public partial class frmPrepPen : Form
    {
        public frmPrepPen()
        {
            InitializeComponent();
        }

        #region Procesos locales
        private void sbrCarga()
        {

            string vSql = cConstantes.SQL_PrepPen_Lista;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));


            grLista.DataSource = null;
            grLista.DataSource = dt.DefaultView;

            //grLista.Columns["ID"].Visible = false;

        }





        #endregion

        private void frmPrepPen_Load(object sender, EventArgs e)
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

        private void btImprimir_Click(object sender, EventArgs e)
        {
            DataView dtv = (DataView)grLista.DataSource;
            DataTable dtLista = dtv.ToTable();
            cInformes.Imp = (cParamXml.Imp == "True") ? true : false;
            cInformes.sbrPrintPrepPen(cParamXml.Emp.ToString(), dtLista);

        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
