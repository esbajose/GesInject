using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using GesInject.Clases;
using System.Xml;
using System.IO;


namespace GesInject.Formularios
{
    public partial class frmLista : Form
    {
        public static DataTable dtLista = new DataTable();
        BindingSource vBinding = new BindingSource();
        public static string vTabla="";
        public static string vSelec = "";
        public static string vSelecTot = "";
        public static string vWhere = "";
        public static string vSqlOrig = "";

        public static string vCamposSelec = "";
        public static string vTipoCampo = "";
        public static string vTipoTabla = "";
        public static string vTablaRel = "";
        public static string vCampoRel = "";
        public static string vValorPos = "";
        public static string vCampoPos = "";
        public static string vCamposLista = "";
        public static string vRes = "";
        public static string vValorBus = "";
        public static string vCampoBus = "";

        public static string vNoVisibleGR = "";


#region Filtros
        private string vCampoCell = "";
        private string vDatoCampo = "";
        private string[] vNombreCampo;
        private string[] vFiltroCampo;
        private string vCampos = "";
        int vNumCampos = 0;
        string vValores = "";
        private string vFiltro = "";

#endregion

        public static bool vSelecionar = false;
        public static bool vTableData = false;
        public static string vStrConec = "";
        public frmLista()
        {
            InitializeComponent();
        }

        private void frmLista_Load(object sender, EventArgs e)
        {
            if (vTabla == "") 
            {
                MessageBox.Show("No se ha definido una Tabla");                
                this.Close();
                return;
            }
            if (vStrConec == "") { vStrConec = cConstantes.NaviConecStrCosmic; }

            if (vRes == "") { vRes = vCampoPos; }

            if (vTipoTabla == "")
            {
                if (vTabla.LastIndexOf("$") > 0)
                {
                    vTipoTabla = "Navi";
                }
            }
            string vSql = "";
            if (vTipoTabla == "")
            {
                vSql = "SELECT COLUMN_NAME AS Campo,ORDINAL_POSITION AS No,DATA_TYPE AS Tipo FROM information_schema.columns WHERE table_name = '" + vTabla + "'";
            }
            if (vTipoTabla == "Navi")
            {
                vSql = "SELECT FieldName AS Campo, [Field Caption] AS Caption, [Type Name] AS Tipo, TableRelation,FieldRelation " +
                   "FROM TablasNav " +
                   "WHERE (Tabla = '" + vTabla + "')";
            }
            if (vTableData)
            {
                if ((vTipoTabla == "")|(vTipoTabla == "SQL"))
                {
                    string[] mTabla = vTabla.Split('.');
                    if (mTabla.Length > 1)
                    {
                        vTabla = mTabla[mTabla.Length - 1].ToString();
                    }
                    vTabla = vTabla.Replace("[", "");
                    vTabla = vTabla.Replace("]", "");
                    vSql = "SELECT COLUMN_NAME AS Campo,ORDINAL_POSITION AS No,DATA_TYPE AS Tipo FROM information_schema.columns WHERE table_name = '" + vTabla + "'";
                }

                if (vTipoTabla == "Navi")
                {
                    vSql = "SELECT FieldName AS Campo, [Field Caption] AS Caption, [Type Name] AS Tipo, TableRelation,FieldRelation " +
                       "FROM TablasNav " +
                       "WHERE (Tabla = '" + vTabla + "')";
                }

                vSql = "Select " + fncCamposTabla(vSql) + " From " + "[" + vTabla + "]";
            }

            if (vWhere != "")
            {
                vSql = vSql + " " + vWhere;
            }
            if (vSqlOrig != "")
            {
                vSql = vSqlOrig;
            }

            dtLista =fncCreaLista(vSql);

            vBinding.DataSource = dtLista;
            sbrCargaLista(dtLista );
            sbrCargaCB(dtLista );

            sbrLeeConf();

            sbrCargachLista();

            Application.DoEvents();
            if (vCampoBus != "")
            {
                cblista.Text = vCampoBus;
            }
            if (vValorBus != "")
            {
                txBusca.Text = vValorBus;
            }

            txBusca.Focus();
            txBusca.SelectionStart = txBusca.TextLength;

        }

        #region Procesos locales

        private DataTable fncCreaLista(string vSql)
        {
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));
            return dt;        
        }

        private void sbrCargaCB(DataTable dt)
        {
            foreach (DataColumn co in dt.Columns)
            {
                cblista.Items.Add(co.ColumnName);
                cblista.SelectedIndex = 0;
            }
        }

        private void sbrCargaLista(DataTable dt)
        {
            grLista.DataSource = dt.DefaultView;
            if ((vCampoPos != "")&(vValorPos !=""))
            {
                try
                {
                    int vReg = vBinding.Find(vCampoPos, vValorPos);
                    grLista.FirstDisplayedScrollingRowIndex = vReg;
                    grLista.Select();
                }
                catch { }
            }


            sbrFormatoGr();
        }

        private void sbrCargachLista()
        {
            foreach (DataGridViewColumn cl in grLista.Columns)
            {
                chLista.Items.Add(cl.Name ,cl.Visible);
            }
        }

        private void sbrFormatoGr()
        {
            if (vNoVisibleGR != "")
            {
                foreach (DataGridViewColumn cl in grLista.Columns)
                {
                    string vNombreC = cl.Name;
                    if (vNoVisibleGR.LastIndexOf(vNombreC) > -1)
                    {
                        cl.Visible = false;
                    }
                }
            }

            string vFichParam = cParamXml.DirMisDoc() + @"\Cfg_Lista_" + vTabla + "_" + Application.ProductName + ".xml";
            if (File.Exists(vFichParam))
            {
                foreach (DataGridViewColumn cl in grLista.Columns)
                {
                    string vNomCol = cl.Name;
                    vNomCol = vNomCol.Replace(" ", "_");

                    cl.Width = Convert.ToInt16(cXml.fncLeeDato(cParamXml.DirMisDoc() + @"\Cfg_Lista_" + vTabla + "_" + Application.ProductName + ".xml",
                                                "Parametros", "ColAncho_" + vNomCol, "100"));

                    cl.Visible = Convert.ToBoolean(cXml.fncLeeDato(cParamXml.DirMisDoc() + @"\Cfg_Lista_" + vTabla + "_" + Application.ProductName + ".xml",
                                                "Parametros", "ColVis_" + vNomCol, "true"));

                }
            }


        }

        private void sbrGrabaConf()
        {
            XmlTextWriter textWriter = null;
            textWriter = cXml.fncGrabaIni(cParamXml.DirMisDoc() + @"\Cfg_Lista_" + vTabla + "_" + Application.ProductName + ".xml",
                                "Configuración Lista " + Application.ProductName, "Parametros");

 
            cXml.fncGrabaValor(textWriter, "Pos_Left", this.Left.ToString());
            cXml.fncGrabaValor(textWriter, "Pos_Top", this.Top.ToString());
            cXml.fncGrabaValor(textWriter, "Pos_Ancho", this.Width.ToString());
            cXml.fncGrabaValor(textWriter, "Pos_Alto", this.Height.ToString());
            cXml.fncGrabaValor(textWriter, "Busca_Campo", cblista.Text);

            foreach (DataGridViewColumn cl in grLista.Columns)
            {
                string vNomCol = cl.Name;
                vNomCol = vNomCol.Replace(" ", "_");

                cXml.fncGrabaValor(textWriter, "ColAncho_" + vNomCol, cl.Width.ToString());
            }



            for (int i = 0; i < chLista.Items.Count; i++)
            {
                string vNomCol = chLista.Items[i].ToString();
                vNomCol = vNomCol.Replace(" ", "_");

                bool vCheck = chLista.GetItemChecked(i);

                cXml.fncGrabaValor(textWriter, "ColVis_" + vNomCol, vCheck.ToString());

            }


            cXml.fncGrabaEnd(textWriter);
        }

        private void sbrLeeConf()
        {
            this.Left = Convert.ToInt16(cXml.fncLeeDato(cParamXml.DirMisDoc() + @"\Cfg_Lista_" + vTabla + "_" + Application.ProductName + ".xml", "Parametros", "Pos_Left", "50"));
            this.Top = Convert.ToInt16(cXml.fncLeeDato(cParamXml.DirMisDoc() + @"\Cfg_Lista_" + vTabla + "_" + Application.ProductName + ".xml", "Parametros", "Pos_Top", "50"));
            this.Width = Convert.ToInt16(cXml.fncLeeDato(cParamXml.DirMisDoc() + @"\Cfg_Lista_" + vTabla + "_" + Application.ProductName + ".xml", "Parametros", "Pos_Ancho", "500"));
            this.Height = Convert.ToInt16(cXml.fncLeeDato(cParamXml.DirMisDoc() + @"\Cfg_Lista_" + vTabla + "_" + Application.ProductName + ".xml", "Parametros", "Pos_Alto", "500"));
            
            foreach (DataGridViewColumn cl in grLista.Columns)
            {
                string vNomCol = cl.Name;
                vNomCol = vNomCol.Replace(" ", "_");

                cl.Width = Convert.ToInt16(cXml.fncLeeDato(cParamXml.DirMisDoc() + @"\Cfg_Lista_" + vTabla + "_" + Application.ProductName + ".xml", 
                                            "Parametros", "ColAncho_" + vNomCol ,"100"));

                cl.Visible = Convert.ToBoolean(cXml.fncLeeDato(cParamXml.DirMisDoc() + @"\Cfg_Lista_" + vTabla + "_" + Application.ProductName + ".xml",
                                            "Parametros", "ColVis_" + vNomCol, "true"));



            }

            cblista.Text = cXml.fncLeeDato(cParamXml.DirMisDoc() + @"\Cfg_Lista_" + vTabla + "_" + Application.ProductName + ".xml", "Parametros", "Busca_Campo", "Codigo");          



        }

        private string fncCamposTabla(string vSql)
        {
            string vListaCampos = "";
            DataTable dtC = fncCreaLista(vSql);
            foreach (DataRow dr in dtC.Rows)
            {
                string vCampo = dr["Campo"].ToString();
                if ((vCampo != "timestamp") & (vCampo != "IDUnic"))
                {
                    vListaCampos = vListaCampos + "[" + vCampo + "]" + ",";
                }
            }
            if (vListaCampos != "")
            {
                vListaCampos = vListaCampos.Substring(0, vListaCampos.Length - 1);
            }

            return vListaCampos;
        }

        #endregion

        #region  Busqueda y Filtros
        //Busqueda y Filtros
        public string fncBuscaFiltroCampo()
        {
            int vInd = 0;
            string vDato = "";

            vInd = Array.IndexOf(vNombreCampo, vCampoCell);
            vDato = vFiltroCampo[vInd];

            if (vDato == null) { vDato = ""; }
            return vDato;
        }
        public void fncActFiltro(string vDato)
        {
            int vInd = 0;
            string vCampo2 = vCampoCell;

            vInd = Array.IndexOf(vNombreCampo, vCampo2);
            vFiltroCampo[vInd] = vDato;
            fncFormaFiltro(vFiltroCampo, vNombreCampo, ref vFiltro);



        }
        private string fncFormaFiltro(string[] vFiltroCampo0, string[] vNombreCampo0, ref string vFiltro0)
        {
            string vFil = "";
            vFiltro0 = "";
            int vCont = 0;
            int vContFil = 0;
            bool vEsp = false;
            foreach (string vLin in vFiltroCampo0)
            {
                string vLinea = vLin;
                if ((vLinea != "") & (vLinea != null))
                {
                    vEsp = false;
                    if (vContFil > 0)
                    {
                        vFiltro0 = vFiltro0 + " and ";
                    }
                    vContFil++;

                    if (vLinea.LastIndexOf("*") > -1)
                    {
                        vEsp = true;
                        vLinea = vLinea.Replace("*", "%");
                        vFiltro0 = vFiltro0 + vNombreCampo0[vCont] + " Like '" + vLinea + "' ";

                    }

                    if (vLinea.LastIndexOf(">") > -1)
                    {
                        vEsp = true;
                        vFiltro0 = vFiltro0 + vNombreCampo0[vCont] + " > '" + vLinea + "' ";
                    }

                    if (vLinea.LastIndexOf("<") > -1)
                    {
                        vEsp = true;
                        vFiltro0 = vFiltro0 + vNombreCampo0[vCont] + " < '" + vLinea + "' ";
                    }

                    if (vLinea.LastIndexOf("=") > -1)
                    {
                        vEsp = true;
                        vFiltro0 = vFiltro0 + vNombreCampo0[vCont] + " = '" + vLinea + "' ";
                    }
                    if (vLinea.LastIndexOf("..") > -1)
                    {
                        vEsp = true;
                        string[] vVarios = vLinea.Split('.');
                        vFiltro0 = vFiltro0 + "(";
                        vFiltro0 = vFiltro0 + vNombreCampo0[vCont] + " >= '" + vVarios[0] + "' and ";
                        vFiltro0 = vFiltro0 + vNombreCampo0[vCont] + " <= '" + vVarios[2] + "'";
                        vFiltro0 = vFiltro0 + ")";
                    }


                    if (vLinea.LastIndexOf("|") > -1)
                    {
                        vEsp = true;
                        string[] vVarios = vLinea.Split('|');
                        vFiltro0 = vFiltro0 + "(";
                        foreach (string vVar in vVarios)
                        {

                            vFiltro0 = vFiltro0 + vNombreCampo0[vCont] + " = '" + vVar + "' or ";
                        }
                        vFiltro0 = vFiltro.Substring(0, vFiltro0.Length - 4);
                        vFiltro0 = vFiltro0 + ")";

                    }
                    if (vEsp == false)
                    {
                        vFiltro0 = vFiltro0 + vNombreCampo0[vCont] + " = '" + vLinea + "' ";
                    }

                }

                vCont++;
            }


            return vFil;
        }
        private void sbrFiltraDatos()
        {
            //bS1.Filter = vFiltro;

            dtLista.DefaultView.RowFilter = vFiltro;

            sbrCargaLista(dtLista);
            //bS1.DataSource = dtLista;
            //Navi1.BindingSource = bS1;
            Application.DoEvents();
            lbFiltros.Text = "Filtro : " + vFiltro;

        }

        #endregion

        private void txBusca_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView();
            dv = dtLista.DefaultView;
            string vDt = dv.Table.Columns[cblista.Text].DataType.ToString();
            try
            {
                if (vDt == "System.String")
                {
                    dv.RowFilter = "[" + cblista.Text + "] like '%" + txBusca.Text + "%'";
                }

                if (vDt == "System.Int32")
                {
                    if (txBusca.Text != "")
                    {
                        dv.RowFilter = cblista.Text + " = " + txBusca.Text + "";
                    }
                    else
                    {
                        dv.RowFilter = "";
                    }
                }
            }
            catch
            {
                dv.RowFilter = "";
            }

            grLista.DataSource = null;
            grLista.DataSource = dv;
            sbrFormatoGr();

            txBusca.Focus();
        }

        private void grLista_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            vSelecionar = true;
            this.Close();
        }

        private void grLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (vTableData)
            //    {
            //        vSelec = grLista.Rows[e.RowIndex].Cells[0].Value.ToString();
            //    }
            //    else
            //    {
            //        vSelec = grLista.Rows[e.RowIndex].Cells[0].Value.ToString();
            //        vTipoCampo = grLista.Rows[e.RowIndex].Cells[2].Value.ToString();
            //        vTablaRel = grLista.Rows[e.RowIndex].Cells[3].Value.ToString();
            //        vCampoRel = grLista.Rows[e.RowIndex].Cells[4].Value.ToString();
            //    }
            //}
            //catch { }
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            vSelec = "";
            vTipoCampo = "";
            vTablaRel = "";
            vCampoRel = "";
            this.Close();

        }

        private void grLista_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (vTableData)
                {

                    vSelec = "";
                    if (vRes != "")
                    {
                        string[] vR = vRes.Split(',');
                        for (int i = 0; i < vR.Length; i++)
                        {
                            vSelec = vSelec +  grLista.Rows[e.RowIndex].Cells[vR[i]].Value.ToString() + "#";
                        }
                        vSelec = vSelec.Substring(0, vSelec.Length - 1);
                    }
                    else
                    {
                        vSelec = grLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                    }
                    vSelecTot = "";
                    foreach (DataGridViewCell cl in grLista.Rows[e.RowIndex].Cells)
                    {
                        vSelecTot = vSelecTot + cl.Value.ToString() + "#";
                    }

                }
                else
                {

                    vSelec = grLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                    vTipoCampo = grLista.Rows[e.RowIndex].Cells[2].Value.ToString();
                    vTablaRel = grLista.Rows[e.RowIndex].Cells[3].Value.ToString();
                    vCampoRel = grLista.Rows[e.RowIndex].Cells[4].Value.ToString();
                }
            }
            catch { }
            
        }

        private void btSelec_Click(object sender, EventArgs e)
        {
            vSelecionar = true;
            this.Close();

        }

        private void frmLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (vSelecionar == false)
            {
                vSelec = ""; vSelecTot = ""; vTipoCampo = ""; vTablaRel = ""; vCampoRel = ""; vWhere = "";
                vCampoPos = ""; vValorPos = ""; vSqlOrig = ""; vCampoBus = ""; vValorBus = ""; 
            }
            vSelecionar = false;
            vTableData = false;
        }

        private void frmLista_KeyPress(object sender, KeyPressEventArgs e)
        {
               txBusca.Focus();
        }

        private void frmLista_FormClosing(object sender, FormClosingEventArgs e)
        {
            sbrGrabaConf();
        }

        private void chLista_Leave(object sender, EventArgs e)
        {

            if (!chLista.Visible) { chLista.Visible = false; }

        }

        private void chLista_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckState cs = e.NewValue;
            string vCampo = chLista.Items[e.Index].ToString();
            bool vChec = Convert.ToBoolean(cs);
            grLista.Columns[vCampo].Visible = vChec;

        }

        private void btCampos_Click(object sender, EventArgs e)
        {
            chLista.Visible = !chLista.Visible;
        }

        private void txBusca_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                vSelecionar = true;
                this.Close();

            }
            else
            {
                txBusca.Focus();
            }
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

        private void btExcel_Click(object sender, EventArgs e)
        {
            sbrCreaExcel(dtLista, "Lista" + vTabla);
        }

        private void frmLista_MouseEnter(object sender, EventArgs e)
        {
            txBusca.Focus();
        }

        private void frmLista_MouseMove(object sender, MouseEventArgs e)
        {
            txBusca.Focus();
        }

        private void grLista_MouseEnter(object sender, EventArgs e)
        {
            txBusca.Focus();
        }

        private void grLista_MouseMove(object sender, MouseEventArgs e)
        {
            txBusca.Focus();

        }

        private void frmLista_KeyUp(object sender, KeyEventArgs e)
        {
            string vTecla = e.KeyCode.ToString();
            if (vTecla == "Escape")
            {
                vSelecionar = false;
                this.Close();
            }

        }

        private void toolFiltroTabla_Click(object sender, EventArgs e)
        {
            Form frmFil = new frmFiltros();
            frmFiltros.vTabla = vTabla;
            frmFiltros.vEmpresa = "";

            frmFiltros.vStrConec = cParamXml.strConec;
            frmFiltros.vGenFil = "T" + vTabla;
            frmFil.ShowDialog();

            vFiltro = frmFiltros.vFiltros;

            vFiltro = vFiltro.Trim();

            sbrFiltraDatos();

        }

        private void toolQuitar_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < vFiltroCampo.Length; i++)
            //{
            //    vFiltroCampo[i] = "";
            //}

            vFiltro = "";

            sbrFiltraDatos();
        }



    }
}