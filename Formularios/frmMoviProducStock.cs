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
    public partial class frmMoviProducStock : Form

    {
        public frmMoviProducStock()
        {
            InitializeComponent();
        }

        #region Procesos Locales

        private bool fncGrabar()
        {
            bool vOk = false;
            //Crear movimientos
            cMovimientos.Articulo oMov = new cMovimientos.Articulo();

            try
            {
                foreach (DataGridViewRow dr in grMovi.Rows)
                {
                    if (!dr.IsNewRow)
                    {
                        string vProd = dr.Cells["Producto"].EditedFormattedValue.ToString();
                        string vDescripción = dr.Cells["Descripción"].EditedFormattedValue.ToString();
                        string vCan = dr.Cells["Cantidad"].EditedFormattedValue.ToString();
                        string vAUbi = dr.Cells["AUbi"].EditedFormattedValue.ToString();
                        string vDbi = dr.Cells["DUbi"].EditedFormattedValue.ToString();
                        string vLote = dr.Cells["Lote"].EditedFormattedValue.ToString();
                        string vOFL = dr.Cells["OFL"].EditedFormattedValue.ToString();
                        string vDoc = dr.Cells["Documento"].EditedFormattedValue.ToString();

                        string vWhere = " Empresa = " + cParamXml.Emp + " and Almacen = 'Principal' and Producto = N'" + vProd + "'";
                        vWhere += " and Ubi = '" + vDbi + "' and Lote='" + vLote + "' and OFL='" + vOFL + "'";
                        string vCanSt = cUtil.fncTraeCampo("Cantidad", "GC_Ind_ProductoUbiCanLoteOFL", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", true);
                        decimal vdCansT = Convert.ToDecimal(vCanSt);
                        decimal vdCan = Convert.ToDecimal(vCan);

                        if (vdCan > vdCansT)
                        {
                            MessageBox.Show("La cantidad a sacar es superior al stock");
                            return vOk;
                        }
                        //Movimiento de salida
                        oMov.fncAlta(cParamXml.Emp, "Salida", DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vProd, vDescripción,
                                        "-" + vCan, vDoc, vOFL, vDbi, vLote);
                        //Movimiento de entrada
                        oMov.fncAlta(cParamXml.Emp, "Entrada", DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vProd, vDescripción,
                                        vCan, vDoc, "", vAUbi, vLote);

                    }
                }

                vOk = true;
            }
            catch { }

            return vOk;
        }

        private void sbrCargacb()
        {
            string vSql = cConstantes.SQL_Ubis_Lista;
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            DataTable dtCombo = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));

            cbUbi.DataSource = dtCombo;
            cbUbi.DisplayMember = dtCombo.Columns["Ubi"].ToString();
            cbUbi.ValueMember = dtCombo.Columns["Ubi"].ToString();

            ((DataGridViewComboBoxColumn)grMovi.Columns["AUbi"]).DataSource = dtCombo;
            ((DataGridViewComboBoxColumn)grMovi.Columns["AUbi"]).DisplayMember = dtCombo.Columns["Ubi"].ToString();
            ((DataGridViewComboBoxColumn)grMovi.Columns["AUbi"]).ValueMember = dtCombo.Columns["Ubi"].ToString();

        }
        private void sbrCargaStock()
        {
            
            //string vSql = cConstantes.SQL_Stock_Fab;
            string vSql = cConstantes.SQL_Stock_PRODUC;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?Alm]", "Principal");
            
            DataTable dtStock = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));
            grStock.DataSource = null;
            grStock.DataSource = dtStock.DefaultView;

        }


        #endregion


        private void grMovi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int vCol = e.ColumnIndex;
            int vFil = e.RowIndex;
            string vCampo = grMovi.Columns[vCol].Name;
            string vValor = "";
            if (grMovi.Rows[vFil].Cells[vCol].EditedFormattedValue != null) vValor = grMovi.Rows[vFil].Cells[vCol].EditedFormattedValue.ToString();

            if (vCampo == "btProducto")
            {
                string vTabla = "articulo";
                string vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "CREF", "", "", "", "", false, "", "", "", "DBF");


                if (vRes != "")
                {

                    string vWhere = " cREF = '" + vRes + "' ";
                    string vDes = cUtil.fncTraeCampo("cdetalle", "articulo", vWhere, "", cParamXml.strOleDBConecDbf, "DBF", true);
                    if (vDes == "***Inex***")
                    {
                        MessageBox.Show("Producto Inexistente");
                        return;

                    }


                    grMovi.Rows[vFil].Cells["Descripción"].Value = vDes;


                    grMovi.CurrentCell = grMovi.Rows[vFil].Cells["Producto"];
                    grMovi.BeginEdit(true);
                    Application.DoEvents();
                    grMovi.CurrentCell.Value = vRes;
                    Application.DoEvents();
                    grMovi.EndEdit();
                    Application.DoEvents();

                }
            }



        }
        private void grMovi_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int vCol = e.ColumnIndex;
            int vFil = e.RowIndex;
            string vCampo = grMovi.Columns[vCol].Name;
            string vValor = "";
            if (grMovi.Rows[vFil].Cells[vCol].EditedFormattedValue != null)
            {
                vValor = grMovi.Rows[vFil].Cells[vCol].EditedFormattedValue.ToString().ToUpper();
                grMovi.Rows[vFil].Cells[vCol].Value = vValor;
            }
            if (vCampo == "Producto")
            {
                grMovi.Rows[vFil].Cells["Descripción"].Value = "";
                if (vValor != "")
                {
                    string vWhere = " cREF = '" + vValor + "' ";
                    string vDes = cUtil.fncTraeCampo("cdetalle", "articulo", vWhere, "", cParamXml.strOleDBConecDbf, "DBF", true);
                    if (vDes == "***Inex***")
                    {
                        MessageBox.Show("Producto Inexistente");
                        e.Cancel = true;
                        return;

                    }
                    grMovi.Rows[vFil].Cells["Descripción"].Value = vDes;


                }
            }
        }
        private void grMovi_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            int vFil = e.RowIndex;
            string vProd = grMovi.Rows[vFil].Cells["Producto"].EditedFormattedValue.ToString();
            string vCan = grMovi.Rows[vFil].Cells["Cantidad"].EditedFormattedValue.ToString();
            string vAUbi = grMovi.Rows[vFil].Cells["AUbi"].EditedFormattedValue.ToString();
            string vDbi = grMovi.Rows[vFil].Cells["DUbi"].EditedFormattedValue.ToString();

            //if (vDbi == "")
            //{
            //    MessageBox.Show("No se ha informado 'De la Ubicación'");
            //    e.Cancel = true;
            //}

            //if ((vCan == "")|(vCan == "0"))
            //{
            //    MessageBox.Show("No se ha informado la cantidad");
            //    e.Cancel = true;
            //}

            if (vAUbi == "")
            {
                grMovi.Rows[vFil].Cells["AUbi"].Value = cbUbi.Text; ;
            }


        }
        private void grMovi_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string vError = "";
        }

        private void btUbi_Click(object sender, EventArgs e)
        {
            string vTabla = "GC_Ubicaciones";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "Ubi", txUbi.Text, "", "", "", false, "", "", "", "SQL");

            if (vRes != "")
            {
                txUbi.Text = vRes;
            }

        }

        private void frmMoviProducStock_Load(object sender, EventArgs e)
        {
            sbrCargacb();
            sbrCargaStock();
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btGrabar_Click(object sender, EventArgs e)
        {
            string vMen = "¿Procesar los movimientos? " + cConstantes.vbCtr + cConstantes.vbLF;
            string vTit = "Traspaso entre Ubicaciones";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            if (!fncGrabar())
            {
                MessageBox.Show("Se ha producido un error al Grabar");
                return;
            }

            grMovi.Rows.Clear();

        }

        private void btActu_Click(object sender, EventArgs e)
        {
            sbrCargaStock();

        }

        private void btTras_Click(object sender, EventArgs e)
        {
            int vRow=grStock.CurrentCell.RowIndex;
            string vProd = grStock.Rows[vRow].Cells["Producto"].Value.ToString();
            string vUbi = grStock.Rows[vRow].Cells["Ubi"].Value.ToString();
            string vCantidad = grStock.Rows[vRow].Cells["Cantidad"].Value.ToString();
            string vLote = grStock.Rows[vRow].Cells["Lote"].Value.ToString();
            string vOFL = grStock.Rows[vRow].Cells["OFL"].Value.ToString();
            string vWhere = " Empresa = " + cParamXml.Emp + " and Producto = N'" + vProd + "'";
            string vDes = cUtil.fncTraeCampo("Descripción", "GC_ProductoAnexos", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", true);
            if (vDes == "***Inex***")
            {
                vDes = "";
            }



            grMovi.Rows.Add(vLote, vOFL, vProd, "", vDes, "0", "", vUbi, "");
            
            //int vRowMov = grMovi.CurrentCell.RowIndex;
            //grMovi.Rows[vRowMov].Cells["Producto"].Value = vProd;
            //grMovi.Rows[vRowMov].Cells["DUbi"].Value = vUbi;
            //grMovi.Rows[vRowMov].Cells["Cantidad"].Value = vCantidad;
            //grMovi.Rows[vRowMov].Cells["Lote"].Value = vLote;

        }
    }
}
