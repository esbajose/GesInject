using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using jControles.Clases;
using GesInject.Clases;

namespace GesInject.Formularios
{
    public partial class frmElimCajasPrep : Form
    {
        private DataTable _dt = new DataTable(); public DataTable dt { set { _dt = value; } }
        private string _Prep = ""; public string Prep { set { _Prep = value; } }

        private string _Res = ""; public string Res { get { return _Res; } }


        public frmElimCajasPrep()
        {
            InitializeComponent();
        }

        private void frmElimCajasPrep_Load(object sender, EventArgs e)
        {
            string vNumPrep = cUtil.Piece(_Prep, "#", 1);
            string vProd = cUtil.Piece(_Prep, "#", 2);
            string vDesProd = cUtil.Piece(_Prep, "#", 3);

            lbNumPrep.Text = vNumPrep;
            lbProd.Text = vProd;
            lbNomProd.Text = vDesProd;

            grCajas.DataSource = null;
            grCajas.DataSource = _dt;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            _Res = "";
            this.Close();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            _Res = "";
            foreach (DataGridViewRow dr in grCajas.Rows)
            {
                string vSel = "";
                string vIdOF = "";
                string vCaja = "";
                string vLotes = "";
                string vAlb = "";
                string vLin = "";
                string vCan = "";
                string vLote = "";
                string vId = "";

                if (dr.Cells[0].Value != null) vSel = dr.Cells[0].Value.ToString();
                if (dr.Cells["Caja"].Value != null) vCaja = dr.Cells["Caja"].Value.ToString();
                if (dr.Cells["Lote"].Value != null) vLotes = dr.Cells["Lote"].Value.ToString();
                if (dr.Cells["NumAlb"].Value != null) vAlb = dr.Cells["NumAlb"].Value.ToString();
                if (dr.Cells["Linea"].Value != null) vLin = dr.Cells["Linea"].Value.ToString();
                if (dr.Cells["Cantidad"].Value != null) vCan = dr.Cells["Cantidad"].Value.ToString();
                if (dr.Cells["ID"].Value != null) vId = dr.Cells["ID"].Value.ToString();

                vIdOF = cUtil.Piece(vLotes, "|", 2);
                vLote = cUtil.Piece(vLotes, "|", 1);

                if (vSel == "1")
                {
                    _Res += vId + "#" + vAlb + "#" + vLin + "#" + vIdOF + "#" + vCaja + "#" + vCan + "#" + vLote + "|";
                    Application.DoEvents();
                }

            }

            if (_Res == "")
            {
                MessageBox.Show("No se ha selecionado ningun caja");
                return;
            }

            this.Close();

        }
    }
}
