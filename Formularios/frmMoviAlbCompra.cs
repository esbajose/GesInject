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
using GesInject.Datasets;
using jControles.Clases;


namespace GesInject.Formularios
{
    public partial class frmMoviAlbCompra : Form
    {
        cAlbaranesCompra.LinAlbCompra oLinAlb = new cAlbaranesCompra.LinAlbCompra();
        cAlbaranesCompra.CabAlbCompra oCabCompra = new cAlbaranesCompra.CabAlbCompra();

        string vError = "";
        public frmMoviAlbCompra()
        {
            InitializeComponent();
        }

        #region Procesos locales
        private void sbrCarga()
        {

            string vSql = cConstantes.SQL_AlbCompraPen_Lista;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));


            grLista.DataSource = null;
            grLista.DataSource = dt.DefaultView;

            grLista.Columns["ID"].Visible = false;

        }


        private void sbrCargaLinea(int vFil)
        {
            sbrLimpiaEnt();




            string vId = grLista.Rows[vFil].Cells["Id"].Value.ToString();
            string vCan = grLista.Rows[vFil].Cells["Cantidad"].Value.ToString();
            string vLote = grLista.Rows[vFil].Cells["Lote"].Value.ToString();
            string vObs = grLista.Rows[vFil].Cells["Obs"].Value.ToString();
            string vPed = grLista.Rows[vFil].Cells["NumPed"].Value.ToString();
            string vRecep = grLista.Rows[vFil].Cells["RecepcionadoPor"].Value.ToString();
            string vCert = grLista.Rows[vFil].Cells["Cert"].Value.ToString();
            string vProd = grLista.Rows[vFil].Cells["Producto"].Value.ToString();
            string vDesProd = grLista.Rows[vFil].Cells["Descripción"].Value.ToString();
            string vError = grLista.Rows[vFil].Cells["error"].Value.ToString();
            string vUbi = grLista.Rows[vFil].Cells["Ubi"].Value.ToString();
            string vNumSerie = grLista.Rows[vFil].Cells["NumSerie"].Value.ToString();
            string vCertSN = "NO";

            

            oLinAlb.Cantidad = Convert.ToDecimal(vCan);
            oLinAlb.Lote = vLote;
            oLinAlb.RecepcionadoPor = vRecep;
            if (vCert != "") vCertSN = "SI";
            oLinAlb.Cert = vCertSN;
            oLinAlb.Producto = vProd;
            oLinAlb.Descripción = vDesProd;
            oLinAlb.CodProv = grLista.Rows[vFil].Cells["CodProv"].Value.ToString();
            oLinAlb.NombreProv = grLista.Rows[vFil].Cells["NombreProv"].Value.ToString();
            oLinAlb.SuAlb = grLista.Rows[vFil].Cells["SuAlbaran"].Value.ToString();
            oLinAlb.RecepcionadoPor = vRecep;
            oLinAlb.FechaEntrega = Convert.ToDateTime(grLista.Rows[vFil].Cells["FechaEntrega"].Value.ToString());
            oLinAlb.NumAlb = grLista.Rows[vFil].Cells["NumAlb"].Value.ToString();
            oLinAlb.Ubi = vUbi;
            oLinAlb.NumSerie = vNumSerie;

            txId.Text = vId;
            txCan.Text = vCan;
            txLote.Text = vLote;
            txObs.Text = vObs;
            txPedido.Text = vPed;
            txRecepPor.Text = vRecep;
            txCert.Text = vCert;
            txProd.Text = vProd;
            txDesProd.Text = vDesProd;
            txUbi.Text = vUbi;

            txSuAlbaran.Text = "";
            if (oCabCompra.fncExiste(cParamXml.Emp, oLinAlb.NumAlb))
            {
                txSuAlbaran.Text = oCabCompra.SuAlbaran;
            }


            btEtiqueta.Visible = false;


            if (txCan.Text != "0")
            {
                btGrabar.Visible = true;
                btEtiqueta.Visible = true;
            }

            if (vError == "Pendiente de Grabar")
            {
                btGrabar.Visible = false;

            }
            return;
        }
        private void sbrLimpiaEnt()
        {
            txId.Text = "";
            txCan.Text = "";
            txRecepPor.Text = "";
            txObs.Text = "";
            txLote.Text = "";
            txCert.Text = "";
            txPedido.Text = "";
            txProd.Text = "";
            txUbi.Text = "";

            btGrabar.Visible = false;

        }

        private bool fncGrabaLinea()
        {
            bool vOk = false;
            cAlbaranesCompra.LinAlbCompra cLinCompra = new cAlbaranesCompra.LinAlbCompra();
            cAlbaranesCompra.CabAlbCompra cCabCompra = new cAlbaranesCompra.CabAlbCompra();



            try
            {
                int vId = Convert.ToInt32(txId.Text);
                cLinCompra.Id = vId;


                string vCT = "Cantidad";
                string vTx = txCan.Text.Replace(",",".");
                cLinCompra.fncGrabaCampo(vCT, vTx);

                vCT = "Lote";
                vTx = txLote.Text;
                cLinCompra.fncGrabaCampo(vCT, vTx);

                vCT = "Obs";
                vTx = txObs.Text;
                cLinCompra.fncGrabaCampo(vCT, vTx);

                vCT = "NumPed";
                vTx = txPedido.Text;
                cLinCompra.fncGrabaCampo(vCT, vTx);

                vCT = "RecepcionadoPor";
                vTx = txRecepPor.Text;
                cLinCompra.fncGrabaCampo(vCT, vTx);

                vCT = "Cert";
                vTx = txCert.Text;
                cLinCompra.fncGrabaCampo(vCT, vTx);

                vCT = "Ubi";
                vTx = txUbi.Text;
                cLinCompra.fncGrabaCampo(vCT, vTx);

                vCT = "Grabado";
                vTx = "0";
                cLinCompra.fncGrabaCampo(vCT, vTx);




                if (cCabCompra.fncExiste(cParamXml.Emp, oLinAlb.NumAlb))
                {
                    vCT = "SuAlbaran";
                    vTx = txSuAlbaran.Text;
                    cCabCompra.fncGrabaCampo(vCT, vTx);
                }
                

                vOk = fncGrabaCert(txCert.Text,txProd.Text,txLote.Text);
            }
            catch (Exception ex) { vError = ex.Message; }

            return vOk;

        }

        private bool fncGrabaCert(string vFich,string vProd,string vLote)
        {
            bool vOk = false;

            

            string vNomFich = Path.GetFileName(vFich);

            string vSql = cConstantes.SQL_Delete_LoteCert;
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?Producto]", vProd);
            vSql = vSql.Replace("[?Lote]", vLote);

            int viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConec);



            vSql = cConstantes.SQL_Insert_LoteCert;
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?Producto]", vProd);
            vSql = vSql.Replace("[?Lote]", vLote);
            vSql = vSql.Replace("[?Cert]", vNomFich);

            viOk = SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConec);

            //if (viOk == 0) return vOk;



            if (cParamXml.DirCerMat == "")
            {
                MessageBox.Show("No esta configurado el directorio de Certificados");
                return vOk;
            }

            if (!Directory.Exists(cParamXml.DirCerMat))
            {
                MessageBox.Show("No existe el directorio de Certificados: " + cParamXml.DirCerMat );
                return vOk;

            }
            if (vFich == "")
            {
                MessageBox.Show("No se ha informado el Certificados");
                return vOk;
            }
            if (!Directory.Exists(cParamXml.DirCerMat + @"\" + vProd))
            {
                Directory.CreateDirectory(cParamXml.DirCerMat + @"\" + vProd);
            }


            string vFichDest = cParamXml.DirCerMat + @"\" + vProd + @"\" + vNomFich;

            vOk = true;

            cUtil oUtil = new cUtil();
            if (vFich.LastIndexOf(@"\") != -1)
            {
                vOk = oUtil.fncCopiaFichero(vFich, vFichDest, false, false, true);
            }



            return vOk;
        }


        #endregion

        private void frmMoviAlbCompra_Load(object sender, EventArgs e)
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
            cUtil.sbrCreaExcel(dtLista, "MoviPendAlbCompra");

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
                    string vError = dr.Cells["Error"].Value.ToString();
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

        private void grLista_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            sbrCargaLinea(e.RowIndex);

        }

        private void btCert_Click(object sender, EventArgs e)
        {
            if (txCert.Text != "")
            {
                string vMen = "Ya hay un certificado para este lote.¿Desea continuar?";
                string vTit = "Certificados";
                if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

            }

            FD1.Filter = "Ficheros PDF|*.PDF|Todos|*.*";
            System.Windows.Forms.DialogResult vRes = DialogResult.Abort;
            vRes = FD1.ShowDialog();
            if (vRes == System.Windows.Forms.DialogResult.OK)
            {
                txCert.Text = FD1.FileName;
            }
            if (vRes == System.Windows.Forms.DialogResult.Cancel)
            {
                if (txCert.Text != "")
                {
                    string vMen = "Se ha selecionado Cancelar.¿Desea Borrar el dato actual?";
                    string vTit = "Certificados";
                    if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txCert.Text = "";
                    }
                }
            }

        }

        private void btGrabar_Click(object sender, EventArgs e)
        {
            vError = "";
            if (fncGrabaLinea())
            {
                sbrLimpiaEnt();
                sbrCarga();
            }
            else
            {
                MessageBox.Show("Se ha producido un error al grabar la linea : " + vError);
            }
        }

        private void btEtiqueta_Click(object sender, EventArgs e)
        {
            string vCan = cUtil.InPutBox("", "Cantidad", "1", "1");
            if (vCan == "*****Cancelado*****")
            {
                return;
            }

            int viCan = 1;
            try { viCan = int.Parse(vCan); }
            catch 
            {
                MessageBox.Show("La Cantidad tiene que ser numérica");
                return;
            }



            cInformes.Imp = (cParamXml.Imp == "True") ? true : false;
            cInformes.sbrImprimeEtiEntrada(oLinAlb, viCan);
        }

        private void btRecep_Click(object sender, EventArgs e)
        {
            string vTabla = "GC_Operarios";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "IdOper", txRecepPor.Text, "", "", "", false, "", "", "", "SQL");

            if (vRes != "")
            {

                txRecepPor.Text = vRes;
                txRecepPor.Focus();
            }

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
    }
}
