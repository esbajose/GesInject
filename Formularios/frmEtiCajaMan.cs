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
    public partial class frmEtiCajaMan : Form
    {
        public frmEtiCajaMan()
        {
            InitializeComponent();
        }


        #region procesos locales
        private void sbrActuCli(string vCli)
        {
            DataRow dr;
            string vWhere = " Empresa = " + cParamXml.Emp + " and codcli = '" + vCli + "' ";
            dr = cUtil.fncTraeCampos("GC_ClienteProducto", vWhere, cParamXml.strConec, "SQL");
            if (dr != null)
            {
                txProd.Text = dr["Producto"].ToString();
                txNomProd.Text = dr["Descripción"].ToString();
                txProdCli.Text = dr["ProductoCli"].ToString();

                if (dr.Table.Rows.Count > 1)
                {
                    string vTabla = "GC_ClienteProducto";
                    vWhere = " Where empresa =" + cParamXml.Emp + " and CodCli ='" + vCli + "'";
                    string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "Producto", vCli, vWhere, "", "", true, "", "", "", "SQL");

                    if (vRes != "")
                    {
                        txProdCli.Text = cUtil.Piece(vRes, "#", 7);
                        txProd.Text = cUtil.Piece(vRes, "#", 5);
                        txNomProd.Text = cUtil.Piece(vRes, "#", 6);

                    }
                }

            }

        }
        private void sbrActuProd(string vProd)
        {
            DataRow dr;
            string vWhere = " Empresa = " + cParamXml.Emp + " and producto = '" + vProd + "' ";
            dr = cUtil.fncTraeCampos("GC_ClienteProducto", vWhere, cParamXml.strConec, "SQL");
            if (dr != null)
            {

                txProd.Text = dr["Producto"].ToString();
                txNomProd.Text = dr["Descripción"].ToString();
                txProdCli.Text = dr["ProductoCli"].ToString();
                txCodCli.Text = dr["CodCli"].ToString();
                txNomCli.Text = dr["NomCli"].ToString();

                if (dr.Table.Rows.Count > 1)
                {
                    string vTabla = "GC_ClienteProducto";
                    vWhere = " Where empresa =" + cParamXml.Emp + " and Producto ='" + txProd.Text + "'";
                    string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "CodCli", txProd.Text, vWhere, "", "", true, "", "", "", "SQL");

                    if (vRes != "")
                    {
                        txProdCli.Text = cUtil.Piece(vRes, "#", 7);
                        txCodCli.Text = cUtil.Piece(vRes, "#", 3);
                        txNomCli.Text = cUtil.Piece(vRes, "#", 4);

                    }
                }

            }


        }
 
        #endregion




        private void btProd_Click(object sender, EventArgs e)
        {
            string vTabla = "articulo";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "CREF", txProd.Text, "", "", "", true, "", "", "", "DBF");

            if (vRes != "")
            {
                txProd.Text = cUtil.Piece(vRes, "#", 1);
                txNomProd.Text = cUtil.Piece(vRes, "#", 2);
                sbrActuProd(cUtil.Piece(vRes, "#", 1));
                Application.DoEvents();
                txProd.Focus();
                string vImagen = cProducto.Articulo.fncTraeC("Imagen", txProd.Text);
                if (vImagen != "") vImagen = cParamXml.DirImProd + @"\" + vImagen;
                try
                {
                    pic1.Load(vImagen);
                }
                catch { }
            }

        }

        private void btCliente_Click(object sender, EventArgs e)
        {
            string vTabla = "clientes";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "ccodcli", txCodCli.Text, "", "", "", false, "", "", "", "DBF");

            if (vRes != "")
            {
                txCodCli.Text = vRes;

                sbrActuCli(vRes);
                Application.DoEvents();
            }

        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            foreach(Control obj in this.Controls)
            {
                string vTipo = obj.GetType().ToString();
                if (vTipo == "System.Windows.Forms.TextBox") obj.Text = "";
                if (vTipo == "System.Windows.Forms.PictureBox") ((System.Windows.Forms.PictureBox)obj).Image = null;
                if (vTipo == "System.Windows.Forms.DateTimePicker") ((System.Windows.Forms.DateTimePicker)obj).Value  = DateTime.Now;

            }
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {

            //System.Drawing.Image objImage = System.Drawing.Image.FromFile(pic1.ImageLocation);

            DataRow drCli;
            string vWhere = " Empresa = " + cParamXml.Emp + " and codcli = '" + txCodCli.Text + "' ";
            drCli = cUtil.fncTraeCampos("GC_ClienteProducto", vWhere, cParamXml.strConec, "SQL");

            string vEtiCli = "";
            string vEt = "";
            if (drCli != null)
            {
                vEt = drCli["EtiCli"].ToString();
                if (vEt == "1")
                {
                    vEtiCli = drCli["EtiDes"].ToString();
                    if (vEtiCli == "") vEtiCli = txNomCli.Text;
                }
            }


            string vLogoCaja = cProducto.Articulo.fncTraeC("LogoCaja", txProd.Text);
            bool vConLogo = true;
            if (vLogoCaja == "0") vConLogo = false;



            dtsEtiCaja dts = new dtsEtiCaja();
            DataTable dt = new DataTable();
            dt = dts.Tables["dtEtiCaja"].Clone();
            DataRow dr = dt.NewRow();

            dr.BeginEdit();
            dr["Producto"] = txProd.Text;
            dr["Cliente"] = txNomCli.Text;
            dr["Pieza"] = txProdCli.Text;
            dr["DesProd"] = txNomProd.Text;
            dr["Lote"] = txLote.Text;
            if (txPiezasCaja.Text == "") txPiezasCaja.Text = "0";
            dr["PiezasCaja"] = Convert.ToInt32(txPiezasCaja.Text);
            dr["Fecha"] = dateFecha.Value;
            dr["Operario"] = txOper.Text;
            if (txCaja.Text == "") txCaja.Text = "0";
            dr["Caja"] = txCaja.Text;
            dr["Imagen"] = cUtil.imageToByteArray(pic1.Image);
            dr["EtiCliente"] = vEtiCli;
            dr.EndEdit();


            dt.Rows.Add(dr);

            int vAncho = 1;
            int vAlto = 1;
            if (pic1.Image != null)
            {
                vAncho = pic1.Image.Width;
                vAlto = pic1.Image.Height;
            }


            //if (vAncho >= vAlto)
            //{
            //    vAlto = vAlto * 720 / vAncho;
            //    vAncho = 720;
            //}
            //else
            //{
            //    vAncho = vAncho * 840 / vAlto;
            //    vAlto = 840;
            //}


            cInformes.Imp = (cParamXml.Imp == "True") ? true : false;
            cInformes.sbrEtiCaja(dt, vAlto, vAncho,vEt,vConLogo);

            

        }

        private void frmEtiCajaMan_Load(object sender, EventArgs e)
        {
            
        }
    }
}
