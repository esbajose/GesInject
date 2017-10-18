using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GesInject.Clases;

namespace GesInject.Controles
{
    public partial class jDataGridView : UserControl
    {

        private bool vBorrar = true;
        public object DataSource
        {
            get { return gr1.DataSource; }
            set 
            {
                gr1.DataSource = value;
                sbrCreagr2();
            }
        }
        public string DataMember
        {
            get { return gr1.DataMember; }
            set { gr1.DataMember = value; }
        }
        public DataGridViewRowCollection Rows
        {
            get { return gr1.Rows; }
        }




        #region Eventos
            public static event DataGridViewCellEventHandler CellEnter;
        #endregion

        #region Procesos locales
            private void sbrCreagr2()
            {
                try
                {
                    gr2.Columns.Clear();
                    DataTable dt = ((DataView)gr1.DataSource).Table.Clone();
                    dt.Rows.Add();
                    gr2.DataSource = dt;

                    string vFCampo = "";
                    string vFor = "";
                    vFCampo = "DelFiltro";
                    vFor = "bt#";
                    cUtil.sbrAgregaColumn(ref gr2, vFor, vFCampo, "", "X", 0);
                    gr2.Rows[0].Cells[0].Value = "X";



                    foreach (DataGridViewColumn dc in gr2.Columns)
                    {
                        string vType = dc.GetType().ToString();
                        if (vType == "System.Windows.Forms.DataGridViewCheckBoxColumn")
                        {
                            //DataGridViewCheckBoxCell cel = (DataGridViewCheckBoxCell)gr2.Rows[0].Cells[dc.Name];

                            ((DataGridViewCheckBoxCell)gr2.Rows[0].Cells[dc.Name]).FalseValue = 0;
                            ((DataGridViewCheckBoxCell)gr2.Rows[0].Cells[dc.Name]).IndeterminateValue = 2;
                            ((DataGridViewCheckBoxCell)gr2.Rows[0].Cells[dc.Name]).TrueValue = 1;
                            gr2.Rows[0].Cells[dc.Name].Value = DBNull.Value;
                        }
                    }



                }
                catch
                {

                }
            }

            private void sbrFiltros()
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (DataGridViewColumn dc in this.gr2.Columns)
                    {
                        string vVal = gr2.Rows[0].Cells[dc.Name].EditedFormattedValue.ToString();

                        if (gr2.Rows[0].Cells[dc.Name].Tag == null) { vVal = ""; }

                        //string vVal = gr2.Rows[0].Cells[dc.Name].Value.ToString();
                        if (vVal != "")
                        {
                            if (sb.Length > 0)
                            {
                                sb.Append(" AND ");
                            }
                            string vCampo = dc.Name;
                            if (vCampo != "bt#DelFiltro")
                            {
                                if (vCampo.LastIndexOf('[') == -1) { vCampo = "[" + vCampo + "]"; }

                                string vTipo = dc.ValueType.ToString();
                                switch (vTipo)
                                {
                                    case "System.Double":
                                        sb.Append(vCampo + " = " + vVal);
                                        break;
                                    case "System.Boolean":
                                        if (vVal == "True") { vBorrar = false; }
                                        if (vBorrar == false) { sb.Append(vCampo + " = " + vVal); }
                                        break;
                                    default:
                                        sb.Append(vCampo + " like " + "'*" + vVal + "*'");
                                        break;
                                }

                                if (dc.GetType() == typeof(decimal))
                                {

                                }
                            }
                        }
                    }
                    // Filtrado de datos
                    ((DataView)gr1.DataSource).Table.DefaultView.RowFilter = sb.ToString();

                }

        #endregion


        public jDataGridView()
        {
            InitializeComponent();
        }

        private void jDataGridView_Load(object sender, EventArgs e)
        {
            sbrCreagr2();

        }

        private void gr1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CellEnter(gr1, new DataGridViewCellEventArgs(e.ColumnIndex, e.RowIndex));
            }
            catch { }
        }

        private void gr2_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                gr1.Columns[e.Column.Name].Width = e.Column.Width;
            }
            catch
            {
                if (e.Column.Name.LastIndexOf("DelFiltro") != -1) { gr1.RowHeadersWidth = e.Column.Width + 10; }
            }

        }

        private void gr2_RowHeadersWidthChanged(object sender, EventArgs e)
        {
            
            gr1.RowHeadersWidth = gr2.RowHeadersWidth;
        }

        private void gr2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            DataGridViewColumn dc = gr1.Columns[e.ColumnIndex];
            if (gr2.SortOrder == SortOrder.Ascending) 
            {
                gr1.Sort(dc, ListSortDirection.Ascending);
            }
            else
            { gr1.Sort(dc, ListSortDirection.Descending); }

        }

        private void gr1_Scroll(object sender, ScrollEventArgs e)
        {
            gr2.HorizontalScrollingOffset = gr1.HorizontalScrollingOffset;
        }

        private void gr1_Resize(object sender, EventArgs e)
        {
            gr2.HorizontalScrollingOffset = gr1.HorizontalScrollingOffset;

        }

        private void gr2_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void gr2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

           
        }

        private void gr2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (gr2.Columns[e.ColumnIndex].Name == "bt#DelFiltro") { return; }
            gr2.Rows[0].Cells[e.ColumnIndex].Tag = "Sel";
            if (gr2.Rows[0].Cells[e.ColumnIndex].EditedFormattedValue.ToString() == "")
            {
                gr2.Rows[0].Cells[e.ColumnIndex].Tag = null;
            }

            sbrFiltros();

        }

        private void gr2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string vCampo = gr2.Columns[e.ColumnIndex].Name;
            if (vCampo ==  "bt#DelFiltro")
            {
                foreach (DataGridViewColumn dc in gr2.Columns)
                {
                    string vCol = dc.Name;
                    if (vCol != "bt#DelFiltro")
                    {
                        gr2.Rows[0].Cells[vCol].Value = DBNull.Value;
                        gr2.Rows[0].Cells[vCol].Tag = null;
                        Application.DoEvents();
                    }
                }

                sbrFiltros();
            }
        }

        private void gr2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            int vColError = e.ColumnIndex;
        }


       
    }
}
