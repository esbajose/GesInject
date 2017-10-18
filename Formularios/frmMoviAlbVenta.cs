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
    public partial class frmMoviAlbVenta : Form
    {
        cAlbaranesVenta.LinAlbVenta2 oLinAlb = new cAlbaranesVenta.LinAlbVenta2();
        public frmMoviAlbVenta()
        {
            InitializeComponent();
        }
        #region Procesos locales
        private void sbrCarga()
        {

            string vSql = cConstantes.SQL_AlbVentaPen_Lista;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));


            grLista.DataSource = null;
            grLista.DataSource = dt.DefaultView;

            grLista.Columns["ID"].Visible = false;

        }





        #endregion

        private void frmMoviAlbVenta_Load(object sender, EventArgs e)
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
            cUtil.sbrCreaExcel(dtLista, "MoviPendAlbVenta");

        }

        private void btRepro_Click(object sender, EventArgs e)
        {
            if (grLista.SelectedRows.Count == 0) { MessageBox.Show("No se ha selecionado ninguna fila"); return; }

            string vMen = "Esta seguro de Reprocesar el/los registro/s marcado/s?";
            string vTit = "Eliminar";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow dr in grLista.SelectedRows)
                {
                    string vId = dr.Cells["ID"].Value.ToString();
                    oLinAlb.Id = Convert.ToInt32(vId);
                    oLinAlb.fncGrabaCampo("Grabado", "0");

                }

                sbrCarga();
            }
        }

        private void btActu_Click(object sender, EventArgs e)
        {
            sbrCarga();

        }
    }
}
