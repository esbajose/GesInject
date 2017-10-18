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
    public partial class frmMoviStock : Form
    {
        public string vProd = "";
        public frmMoviStock()
        {
            InitializeComponent();
        }

        #region Procesos Locales

        private bool fncGrabar()
        {
            bool vOk = false;


            try
            {

                cMovimientos.Articulo cArticulo = new cMovimientos.Articulo();
                foreach (DataGridViewRow dr in grMovi.Rows)
                {
                    if (!dr.IsNewRow)
                    {
                        string vProd = dr.Cells["Producto"].Value.ToString();
                        string vCan = dr.Cells["Cantidad"].Value.ToString();
                        decimal vdCan = Convert.ToDecimal(vCan);
                        string vUbi = (dr.Cells["Ubi"].Value != null) ? dr.Cells["Ubi"].Value.ToString():""; 
                        string vLote = (dr.Cells["Lote"].Value != null) ? dr.Cells["Lote"].Value.ToString():"" ;
                        string vDoc = (dr.Cells["Documento"].Value != null) ? dr.Cells["Documento"].Value.ToString():"";
                        string vOFL = (dr.Cells["OFL"].Value != null) ? dr.Cells["OFL"].Value.ToString():"";
                        string vDes = (dr.Cells["Descripción"].Value != null) ? dr.Cells["Descripción"].Value.ToString():"";
                        try
                        {
                            string vTipo = "Entrada";
                            if (vdCan < 0) vTipo = "Salida";
                            //Crear movimientos de producto y materia prima
                            cMovimientos.Articulo oMov = new cMovimientos.Articulo();

                            //Movimiento de producto
                            oMov.fncAlta(cParamXml.Emp, vTipo, DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vProd, vDes,
                                            vCan, vDoc, vOFL, vUbi, vLote);

                        }
                        catch (Exception ex) { string vEr = ex.Message; }
                    }
                }                
                
                
                
                //cMovimientos.Articulo cArticulo = new cMovimientos.Articulo();
                //foreach (DataGridViewRow dr in grMovi.Rows)
                //{
                //    if (!dr.IsNewRow)
                //    {
                //        bool vOk2= cArticulo.fncAlta(dr);
                //        if (vOk2)
                //        {
                //            //dr.Cells["Sel"].Value = false;

                //        }

                //    }
                //}

                vOk = true;
            }
            catch (Exception ex) { string vEr = ex.Message; }

            return vOk;
        }
        public void sbrCreaExcel(DataTable dtb, string vNomHoja)
        {
            frmInformacion.vTexto = "Creando Hoja Excel";
            Form frm = new frmInformacion();
            frm.Show();
            Application.DoEvents();

            DataTable dtEx = dtb.DefaultView.ToTable();

            cOffice oOffice = new cOffice();

            oOffice.AbreExcel(false);
            Application.DoEvents();
            oOffice.Visible = false;
            Application.DoEvents();
            oOffice.CargaExcel(dtEx, 1);
            Application.DoEvents();
            if (vNomHoja != "")
            {
                oOffice.NombreHoja(vNomHoja);
            }
            oOffice.Visible = true;
            Application.DoEvents();

            oOffice.LimpiaExcel();
            Application.DoEvents();

            frm.Close();
            Application.DoEvents();


        }

        public void sbrImportarExcel()
        {
            FD1.Filter = "Ficheros xls|*.xls|Todos|*.*";
            if (FD1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string vFich = FD1.FileName;

                cOffice oOffice = new cOffice();
                DataTable dt = oOffice.ImportExcelXLS(vFich, true,"ListaMovimientos$");
                grMovi.DataSource = null;
                grMovi.DataSource = dt.DefaultView;
            }


        }
        public void sbrImportarCSV()
        {
            FD1.Filter = "Ficheros csv|*.csv|Todos|*.*";
            if (FD1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string vFich = FD1.FileName;

                //cOffice oOffice = new cOffice();
                //DataTable dt = oOffice.ImportExcelXLS(vFich, true,"ListaMovimientos$");
                //DataTable dt = cUtil.CsvFileToDatatable(vFich,true);
                DataTable dt = cUtil.GridToDataTable(grMovi, "MoviStock");
                dt.Rows.Clear();
                cUtil.TransferCSVToTable(dt, vFich,true);

                grMovi.DataSource = null;
                grMovi.DataSource = dt.DefaultView;
            }


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
                    //grMovi.Rows[vFil].Cells["Producto"].Value = vRes;
                    grMovi.EndEdit();
                    Application.DoEvents();

                    //grMovi.CurrentCell = grMovi.Rows[vFil].Cells["Producto"];

                        
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
            string vTipo = grMovi.Rows[vFil].Cells["Tipo"].EditedFormattedValue.ToString();
            string vAlm = grMovi.Rows[vFil].Cells["Almacen"].EditedFormattedValue.ToString();
            string vFecha = grMovi.Rows[vFil].Cells["Fecha"].EditedFormattedValue.ToString();
            string vProd = grMovi.Rows[vFil].Cells["Producto"].EditedFormattedValue.ToString();
            string vCan = grMovi.Rows[vFil].Cells["Cantidad"].EditedFormattedValue.ToString();

            //if (vProd == "")
            //{
            //    MessageBox.Show("No se ha informado el Producto");
            //    e.Cancel = true;
            //}
            //if ((vCan == "")|(vCan == "0"))
            //{
            //    MessageBox.Show("No se ha informado la cantidad");
            //    e.Cancel = true;
            //}

            if (vTipo == "")
            {
                grMovi.Rows[vFil].Cells["Tipo"].Value = cbTipo.Text; ;
            }

            if (vAlm == "")
            {
                grMovi.Rows[vFil].Cells["Almacen"].Value = cbAlm.Text ;
            }

            if (vFecha == "")
            {
                grMovi.Rows[vFil].Cells["Fecha"].Value = txFecha.Text;
            }

            grMovi.Rows[vFil].Cells["Empresa"].Value = cParamXml.Emp;
            grMovi.Rows[vFil].Cells["FechaHora"].Value = grMovi.Rows[vFil].Cells["Fecha"].Value;



        }
        private void grMovi_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string vError = "";
        }

        private void frmMoviStock_Load(object sender, EventArgs e)
        {
            cbTipo.SelectedIndex = 0;
            cbAlm.SelectedIndex = 0;
            txFecha.Text = DateTime.Now.ToShortDateString();


            if (vProd != "")
            {
                grMovi.Rows[0].Cells["Producto"].Value = vProd;

            }
        }

        private void btGrabar_Click(object sender, EventArgs e)
        {
            string vMen = "¿Procesar los movimientos? " + cConstantes.vbCtr + cConstantes.vbLF;
            string vTit = "Movimientos de Stock";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }






            if (!fncGrabar())
            {
                MessageBox.Show("Se ha producido un error al Grabar");
                return;
            }

            try
            {
                MessageBox.Show("Los movimientos se han grabado con exito");
                DataTable dt = cUtil.GridToDataTable(grMovi, "MoviStock");
                dt.Rows.Clear();
                grMovi.DataSource = null;
                grMovi.DataSource = dt.DefaultView;
            }
            catch { }


        }

        private void frmMoviStock_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (grMovi.RowCount > 1)
            {
                string vMen = "Existen Movimientos por grabar.Esta seguro de cerrar (se perderan dichos movimientos) ?";
                string vTit = "Eliminar";
                if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
                {

                    e.Cancel = true;
                    return;
                }
            }
        }

        private void btCrearExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = cUtil.GridToDataTable(grMovi, "MoviStock");


            sbrCreaExcel(dt, "ListaMovimientos");

        }

        private void btImportar_Click(object sender, EventArgs e)
        {
            sbrImportarCSV();
        }

     }
}
