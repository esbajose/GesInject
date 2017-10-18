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
using GesInject.Datasets;


namespace GesInject.Formularios
{
    public partial class frmListadosOFL : Form
    {
        public frmListadosOFL()
        {
            InitializeComponent();
        }
        #region Procesos locales
        private void sbrCarga()
        {

            string[][] vFil = filtrosBD1.fncCargaFiltros(false);
            string vFiltros = (vFil[2][0] != "") ? " AND " + vFil[2][0] : "";

            string vSql = cConstantes.SQL_OFL_Lista;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?Fil]", vFiltros);
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

            grLista.DataSource = null;
            grLista.DataSource = dt.DefaultView;



        }





        #endregion

        private void frmListadosOFL_Load(object sender, EventArgs e)
        {
            string vSql = cConstantes.SQL_OFL_Lista;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?Fil]", "");


            filtrosBD1.vTabla = "dbo.GC_OrdenProd";
            filtrosBD1.vGenFil = "ListaOF";
            filtrosBD1.vEmpresa = "Cronomol";
            filtrosBD1.vStrConec = cParamXml.strConecProduc_Prueb;
            filtrosBD1.vSqlExt = vSql;
            filtrosBD1.vObjeto = "ListaOF";
            filtrosBD1.Inicia();

        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            if (grLista.Rows.Count == 0) { MessageBox.Show("No hay nada que Exportar"); return; }
            DataView dtv = (DataView)grLista.DataSource;
            DataTable dtLista = dtv.ToTable();
            cUtil.sbrCreaExcel(dtLista, "Lista de O.F.");

        }

        private void btActu_Click(object sender, EventArgs e)
        {
            sbrCarga();
        }
    }
}
