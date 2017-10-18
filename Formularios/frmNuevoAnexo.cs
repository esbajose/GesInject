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
    public partial class frmNuevoAnexo : Form
    {
        public string vProd= "";
        public frmNuevoAnexo()
        {
            InitializeComponent();
        }


        #region Procesos locales

        private bool fncVerif(string vProd)
        {

            bool vOk = false;
            DataTable dt = cProducto.Articulo.fncProdAnexos(cParamXml.Emp, vProd);
            if (dt.Rows.Count >0)
            {
                string vDes = dt.Rows[0]["Descripción"].ToString();
                MessageBox.Show("El Producto " + vProd + "-" + vDes + " ya existe en la tabla de anexos");
                return vOk;
            }
            vOk = true;

            return vOk;
        }

        #endregion

        private void frmNuevoAnexo_Load(object sender, EventArgs e)
        {
            vProd = "";
        }

        private void btTraer_Click(object sender, EventArgs e)
        {
            string vTabla = "articulo";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "CREF", txProducto.Text, "", "", "", true, "", "", "", "DBF");


            if (vRes != "")
            {
                string vDes = cUtil.Piece(vRes, "#", 2);
                vRes = cUtil.Piece(vRes, "#", 1);

                if (fncVerif(vRes))
                {
                    txProducto.Text = vRes;
                    txDesProducto.Text = vDes;
                }

            }

        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btLimpia_Click(object sender, EventArgs e)
        {
            txDesProducto.Text = "";
            txProducto.Text = "";

            txProducto.Focus();

        }

        private void btAlta_Click(object sender, EventArgs e)
        {
            if (txProducto.Text != "")
            {
                if (fncVerif(txProducto.Text))
                {
                    string vDes = txDesProducto.Text;

                    cProducto.Articulo oProd = new cProducto.Articulo();
                    int vID = oProd.fncAltaProducto(txProducto.Text, vDes);
                    if (vID != 0)
                    {
                        vProd = txProducto.Text;

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Se ha producido un error al dar de Alta");
                    }


                }
            }
        }
    }
}
