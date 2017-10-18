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
    public partial class frmLogErrores : Form
    {
        public frmLogErrores()
        {
            InitializeComponent();
        }

        #region Procesos locales
        private void sbrCarga()
        {
            DateTime vtDFecha = dtDFecha.Value;
            if (!dtDFecha.Checked) { vtDFecha = Convert.ToDateTime("01/01/1753"); }

            DateTime vtHFecha = dtHFecha.Value;
            if (!dtHFecha.Checked) { vtHFecha = Convert.ToDateTime("01/01/2080"); }

            string vDFecha = string.Format("{0:yyyy-MM-dd}", vtDFecha);
            string vHFecha = string.Format("{0:yyyy-MM-dd}", vtHFecha);

            string vSql = cConstantes.SQL_LogErrores_Lista;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?DFecha]", vDFecha);
            vSql = vSql.Replace("[?HFecha]", vHFecha);
            vSql = vSql.Replace("[?Fil]", "");
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

            grLista.DataSource = null;
            grLista.DataSource = dt.DefaultView;

            sbrFormatoGr();

        }


        private void sbrFormatoGr()
        {
            grLista.Columns["Id"].Visible = false;
            grLista.Columns["Empresa"].Visible = false;
        }


        #endregion

        private void frmLogErrores_Load(object sender, EventArgs e)
        {
            dtDFecha.Value = DateTime.Now.AddDays(-365);
            dtHFecha.Value = DateTime.Now;

            sbrCarga();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btAct_Click(object sender, EventArgs e)
        {
            sbrCarga();
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            DataView dtv = (DataView)grLista.DataSource;
            DataTable dtLista = dtv.ToTable();
            cUtil.sbrCreaExcel(dtLista, "Lista de Errores");

        }
    }
}
