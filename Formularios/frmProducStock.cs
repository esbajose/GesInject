using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GesInject.Clases;
using jControles.Clases;


namespace GesInject.Formularios
{
    public partial class frmProducStock : Form
    {

        public string _Mat="";
        public int _pTop = 0;
        public int _pLeft = 0;
        public int _pHeight = 0;

        #region Propiedades

            public string Mat { get { return _Mat; } set {_Mat = value;} }
            public int pTop { get { return _pTop; } set { _pTop = value; } }
            public int pLeft { get { return _pLeft; } set { _pLeft = value; } }
            public int pHeight { get { return _pHeight; } set { _pHeight = value; } }

        #endregion

        public frmProducStock()
        {
            InitializeComponent();
        }



        #region Procesos Locales

         private void sbrCargaStock()
        {
            
            //string vSql = cConstantes.SQL_Stock_Fab;
            string vSql = cConstantes.SQL_Stock_Ubi_Lote_OFL;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?Alm]", "Principal");
            
            DataTable dtStock = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));
            grStock.DataSource = null;
            grStock.DataSource = dtStock.DefaultView;

        }


        #endregion

       private void frmMoviProducStock_Load(object sender, EventArgs e)
        {
           sbrCargaStock();
           this.Top = _pTop;
           this.Left = _pLeft;
           this.Height = _pHeight;

           grStock.FiltroCampos = "Producto^" + _Mat + "#Ubi^";


        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
        private void btActu_Click(object sender, EventArgs e)
        {
            sbrCargaStock();

        }

    }
}
