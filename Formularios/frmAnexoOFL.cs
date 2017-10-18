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
    public partial class frmAnexoOFL : Form
    {
        public frmAnexoOFL()
        {
            InitializeComponent();
        }

        
        DataRow _dr;
        Boolean _Terminar = false;
        bool vIni = true;
        string _Lote = "";
        string _LotePie = "";
        string _UbiPie = "";

        public DataRow dr
        {
            get { return _dr; }
            set { _dr = value;}
        }
        public Boolean Terminar
        {
            get { return _Terminar; }
            set { _Terminar = value; }
        }

        public string Lote
        {
            get { return _Lote; }
            set { _Lote = value; }
        }
        public string LotePie
        {
            get { return _LotePie; }
            set { _LotePie = value; }
        }
        public string UbiPie
        {
            get { return _UbiPie; }
            set { _UbiPie = value; }
        }



        #region Procesos locales
        private void sbrCargaRow()
        {
            if (_dr == null)
            {
                MessageBox.Show("No se ha selecionado un registro");
                this.Close();
                return;
            }
            lbOF.Text = _dr["IdOF"].ToString();
            lbCodCli.Text = _dr["CodCli"].ToString();
            lbNomCli.Text = _dr["NomCli"].ToString();
            lbRef.Text = _dr["Articulo"].ToString();
            lbDesRef.Text = _dr["Descripción"].ToString();
            lbRefCli.Text = _dr["ArticuloCli"].ToString();
            lbCantidad.Text = _dr["Cantidad"].ToString();
            lbFecha.Text = _dr["Fecha"].ToString();
            lbFechaIni.Text = _dr["FechaInicio"].ToString();
            lbFechaFin.Text = _dr["FechaFin"].ToString();
            txPiezas.Text = _dr["CantidadFab"].ToString();
            txId.Text = _dr["Id"].ToString();
            txHoras.Text = _dr["Horas"].ToString();
            txPiezasReales.Text = _dr["PiezasReales"].ToString();
            txPiezasNoOK.Text = _dr["PiezasNoOk"].ToString();
            txMaquina.Text = _dr["NoMaquina"].ToString();
            cbUbi.Text = _dr["Ubi"].ToString();
            txKilosAsing.Text = _dr["KilosServ"].ToString();
            string vMaterial = _dr["Material"].ToString();
            lbMat.Text = vMaterial;
            lbDesMat.Text = "";
            DataTable dtMat = cProducto.Articulo.fncProdMat(cParamXml.Emp, lbRef.Text, "1");

            if (dtMat.Rows.Count >0) lbDesMat.Text = dtMat.Rows[0]["DesMaterial"].ToString();
            

            if (Convert.ToDecimal(txKilosAsing.Text) == 0)
            {
                string vPeso = cProducto.Articulo.fncPesoMat(_dr["Articulo"].ToString(), vMaterial);
                decimal vdPeso = Convert.ToDecimal(vPeso);
                decimal vCan = Convert.ToDecimal(lbCantidad.Text);

                decimal vKilos = (vdPeso * vCan) / 1000;
                txKilosAsing.Text = string.Format("{0:n2}", vKilos);

            }


            txKilos.Text = _dr["Kilos"].ToString();
            if (Convert.ToDecimal(txKilos.Text) == 0) txKilos.Text = _dr["KilosConsum"].ToString();


            if (txKilos.Text != "")
            {
                string vKilosServ = txKilosAsing.Text;
                decimal vdKilosServ = Convert.ToDecimal(vKilosServ);
                decimal vdKilos = Convert.ToDecimal(txKilos.Text);
                decimal vdSobra = vdKilosServ - vdKilos;

                txSobrante.Text = string.Format("{0:n2}", vdSobra);

            }

            if ((cbUbi.Text == "") | (txLote.Text == ""))
            {
                string vId = _dr["KilosId"].ToString();
                int viId = Convert.ToInt32(vId);
                viId = viId - 1;
                vId = viId.ToString();
                string vSql = cConstantes.SQL_Produc_Mat_Ubi_Ant;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?ID]", vId.ToString());
                DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));
                if (dt.Rows.Count > 0)
                {
                    string vUbi = dt.Rows[0]["Ubi"].ToString();
                    string vLote = dt.Rows[0]["Lote"].ToString();
                    cbUbi.Text = vUbi;
                    txLote.Text = vLote;
                    _Lote = vLote;
                }
            }
            if ((cbUbiPiezas.Text == "") | (txLotePie.Text == ""))
            {
                string vSql = cConstantes.SQL_Produc_Pie_Ubi_Ant;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?Prod]", lbRef.Text);
                DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));
                if (dt.Rows.Count > 0)
                {
                    string vUbi = dt.Rows[0]["Ubi"].ToString();
                    string vLote = dt.Rows[0]["Lote"].ToString();
                    cbUbiPiezas.Text = vUbi;
                    txLotePie.Text = vLote;
                    _LotePie = vLote;
                    _UbiPie = vUbi;
                }
            }



            vIni = false;
        }

        private void sbrCargacb()
        {
            string vSql = cConstantes.SQL_Ubis_Lista;
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            DataTable dtCombo = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));
            DataTable dtCombo2 = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));

            cbUbi.DataSource = dtCombo;
            cbUbi.DisplayMember = dtCombo.Columns["Ubi"].ToString();
            cbUbi.ValueMember = dtCombo.Columns["Ubi"].ToString();

            cbUbiPiezas.DataSource = dtCombo2;
            cbUbiPiezas.DisplayMember = dtCombo2.Columns["Ubi"].ToString();
            cbUbiPiezas.ValueMember = dtCombo2.Columns["Ubi"].ToString();

        }

        #endregion
        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAnexoOFL_Load(object sender, EventArgs e)
        {
            _Terminar = false;
            sbrCargacb();
            sbrCargaRow();

        }

        private void txHoras_TextChanged(object sender, EventArgs e)
        {
            if ((txHoras.Text != "0")&(txHoras.Text != ""))
            {
                string vPiezas = txPiezas.Text;
                decimal vdPiezas = Convert.ToDecimal(vPiezas);
                decimal vdHoras = Convert.ToDecimal(txHoras.Text);
                if (vdHoras != 0)
                {
                    decimal vdPiezasH = vdPiezas / vdHoras;
                    txPiezasHora.Text = string.Format("{0:n2}", vdPiezasH);

                    if (!vIni) btGrabar.Visible = true;
                }

            }
        }

        private void txPiezasReales_TextChanged(object sender, EventArgs e)
        {
            if ((txPiezasReales.Text != "0") & (txPiezasReales.Text != ""))
            {
                string vPiezas = txPiezas.Text;
                decimal vdPiezas = Convert.ToDecimal(vPiezas);
                decimal vdPiezasReales = Convert.ToDecimal(txPiezasReales.Text);
                if (vdPiezasReales != 0)
                {
                    decimal vdMerma = vdPiezasReales - vdPiezas;
                    txMerma.Text = string.Format("{0:n2}", vdMerma);

                    if (!vIni) btGrabar.Visible = true;
                }

            }

        }

        private void txGrabar_Click(object sender, EventArgs e)
        {
            cProduc.OF oProduc = new cProduc.OF();

            oProduc.Id = Convert.ToInt32(txId.Text);
            oProduc.fncGrabaCampo("Horas", txHoras.Text.Replace(",", "."));
            oProduc.fncGrabaCampo("PiezasReales", txPiezasReales.Text.Replace(",", "."));
            oProduc.fncGrabaCampo("PiezasNoOk", txSobrante.Text.Replace(",", "."));
            oProduc.fncGrabaCampo("Kilos", txKilos.Text.Replace(",", "."));
            oProduc.fncGrabaCampo("Maquina", txMaquina.Text);
            oProduc.fncGrabaCampo("Ubi", cbUbi.Text);


            btGrabar.Visible = false;

            //this.Close();


        }

        private void btTerminar_Click(object sender, EventArgs e)
        {
            cProduc.OF oProduc = new cProduc.OF();
            _Terminar = false;

            if (cbUbi.Text == "")
            {
                MessageBox.Show("No se ha informado la Ubicación de destino del material sobrante");
                return;
            }

            if (cbUbiPiezas.Text == "")
            {
                MessageBox.Show("No se ha informado la Ubicación de destino de las Piezas");
                return;
            }



            oProduc.Id = Convert.ToInt32(txId.Text);
            oProduc.fncGrabaCampo("Horas", txHoras.Text.Replace(",", "."));
            oProduc.fncGrabaCampo("PiezasReales", txPiezasReales.Text.Replace(",", "."));
            oProduc.fncGrabaCampo("PiezasNoOk", txSobrante.Text.Replace(",", "."));
            oProduc.fncGrabaCampo("Kilos", txKilos.Text.Replace(",", "."));
            //oProduc.fncGrabaCampo("NoMaquina", txMaquina.Text);
            oProduc.fncGrabaCampo("Ubi", cbUbi.Text);


            string vMen = "Se Terminaran la O.F.L. " + lbOF.Text + " .Esta seguro?";
            string vTit = "Terminar O.F.L.";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            _UbiPie = cbUbiPiezas.Text;
            _Terminar = true;

            this.Close();

        }

        private void txPiezasNoOK_TextChanged(object sender, EventArgs e)
        {
            if (!vIni) btGrabar.Visible = true;

        }

        private void txKilos_TextChanged(object sender, EventArgs e)
        {
            if (cUtil.IsFocused(txKilos.Handle))
            {
               if (txKilos.Text != "")
                {
                    string vKilosServ = txKilosAsing.Text;
                    decimal vdKilosServ = Convert.ToDecimal(vKilosServ);
                    decimal vdKilos = Convert.ToDecimal(txKilos.Text);
                    decimal vdSobra = vdKilosServ - vdKilos;
                    if (vdSobra < 0) vdSobra = 0;
                    txSobrante.Text = string.Format("{0:n2}", vdSobra);

                    if (!vIni) btGrabar.Visible = true;

                }
            }

        }

        private void txMaquina_TextChanged(object sender, EventArgs e)
        {
            
            if (!vIni) btGrabar.Visible = true;

        }

        private void txSobrante_TextChanged(object sender, EventArgs e)
        {
            if (cUtil.IsFocused(txSobrante.Handle))
            {
                if (txSobrante.Text != "")
                {
                    string vKilosServ = txKilosAsing.Text;
                    decimal vdKilosServ = Convert.ToDecimal(vKilosServ);
                    decimal vdSob = Convert.ToDecimal(txSobrante.Text);
                    decimal vdKilos = vdKilosServ - vdSob;

                    txKilos.Text = string.Format("{0:n2}", vdKilos);

                    if (!vIni) btGrabar.Visible = true;
                }
            }
        }

        private void txSobrante_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void txKilos_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void btStockMat_Click(object sender, EventArgs e)
        {
            frmProducStock frm = new frmProducStock();
            frm.pTop = this.Top;
            frm.pLeft = this.Left + this.Width;
            frm.pHeight = this.Height;
            frm.Mat = lbMat.Text;
            frm.ShowDialog();

        }

        private void btStockArt_Click(object sender, EventArgs e)
        {
            frmProducStock frm = new frmProducStock();
            frm.pTop = this.Top;
            frm.pLeft = this.Left + this.Width;
            frm.pHeight = this.Height;
            frm.Mat = lbRef.Text;
            frm.ShowDialog();

        }

        private void txLote_TextChanged(object sender, EventArgs e)
        {
            _Lote = txLote.Text;

        }
    }
}
