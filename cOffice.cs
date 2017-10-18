using System;
using System.Collections.Generic;
using System.Text;
using Office = Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelApp = Microsoft.Office.Interop.Excel;
using System.Collections;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using GesInject.Clases;





namespace GesInject.Clases
{
    class cOffice
    {
        private static object vk_missing = System.Reflection.Missing.Value;
        private static object vk_visible = true;
        private static object vk_false = false;
        private static object vk_true = true;
        #region OPEN WORKBOOK VARIABLES
        private static object vk_update_links = 0;
        private static object vk_read_only = vk_true;
        private static object vk_No_read_only = vk_false;
        private static object vk_format = 1;
        private static object vk_password = vk_missing;
        private static object vk_write_res_password = vk_missing;
        private static object vk_ignore_read_only_recommend = vk_true;
        private static object vk_read_only_recommend = vk_false;
        private static object vk_origin = vk_missing;
        private static object vk_delimiter = vk_missing;
        private static object vk_editable = vk_false;
        private static object vk_notify = vk_false;
        private static object vk_converter = vk_missing;
        private static object vk_add_to_mru = vk_false;
        private static object vk_local = vk_false;
        private static object vk_corrupt_load = vk_false;
        private static object vk_MaxRows = vk_missing;
        private static object vk_MaxColumns = vk_missing;

        #endregion
        private string _Fichero = "";
        private string _Hoja = "";
        private string _Error = "";
        private int _UltimaFila = 0;
        private int _UltimaFilaGrupo = 0;
        private int _UltimaCol = 0;
        private string _DatoGrupo = "";
        private int[] FilasG = new int[1];
        private int[] FilasG2 = new int[1];
        private int vContFilasG = 0;
        private Microsoft.Office.Interop.Excel.Application exApli;
        private Microsoft.Office.Interop.Excel.Workbook exLibro;
        private Microsoft.Office.Interop.Excel.Worksheet exHoja1;
        private StatusStrip _sta = new StatusStrip();

        public string Fichero
        {
            get { return _Fichero; }
            set { _Fichero = value; }
        }
        public bool Visible
        {
            get { return exApli.Visible; }
            set { exApli.Visible = value; }
        }
        public string Error
        {
            get { return _Error; }
            set { _Error = value; }
        }
        public int UltimaFila
        {
            get { return _UltimaFila; }
            set { _UltimaFila = value; }
        }
        public int UltimaCol
        {
            get { return _UltimaCol; }
            set { _UltimaCol = value; }
        }

        public StatusStrip sta
        {
            get { return _sta; }
            set { _sta = value; }
        }


        public string Hoja
        {
            get { return _Hoja; }
            set { _Hoja = value; }
        }
        public bool CargaExcel(ArrayList vArr)
        {
            int vFila = 0;
            int vCol = 0;
            string vTipo = "";
            string vIdProceso = "";
            try
            {
                foreach (ArrayList vAr in vArr)
                {
                    vFila = vFila + 1;
                    vCol = 0;
                    foreach (string[,] vmCampos in vAr)
                    {
                        for (int i = 1; i < 41; i++)
                        {
                            vCol = vCol + 1;
                            string vDat = vmCampos[i, 1];
                            if (vDat == null) { vDat = ""; }

                            exHoja1.Cells[vFila, vCol] = vDat;
                            _UltimaFila = vFila;
                            _UltimaCol = vCol;

                        }
                        vIdProceso = vmCampos[1, 2];
                        vTipo = vmCampos[1, 3];

                    }
                }
                _Error = "";
                return true;
            }
            catch (Exception ex)
            {
                _Error = ex.Message + "-" + ex.Source.ToString();
                return false;
            }


        }

        public bool CargaExcel(DataTable dt, int vNumHoja)
        {
            return CargaExcel(dt, vNumHoja, "");
        }
        public bool CargaExcel(DataTable dt, int vNumHoja, string Grupo)
        {
            exHoja1 = null;
            try
            {
                exHoja1 = new Microsoft.Office.Interop.Excel.Worksheet();
            }
            catch { }
            exHoja1 = (Microsoft.Office.Interop.Excel.Worksheet)exLibro.Worksheets.get_Item(vNumHoja);
            Excel.Range range;

            decimal vver = Convert.ToDecimal(exApli.Version.ToString());
            int vFila = 0;
            int vCol = 0;

            try
            {
                if (vver > 80000)
                {
                    frmInformacion.vTotReg = dt.Rows.Count;
                    Application.DoEvents();

                    ADODB.Recordset rs = new ADODB.Recordset();
                    rs = cUtil.ConvertToRecordset(dt);

                    exHoja1.Cells.CopyFromRecordset(rs, vk_MaxRows, vk_MaxColumns);
                    Excel.Range exR = (Excel.Range)exHoja1.Cells[1, 1];
                    Excel.Range row = (Excel.Range)exR.EntireRow;
                    row.Insert(Excel.XlInsertShiftDirection.xlShiftDown, false);
                    foreach (DataColumn dc in dt.Columns)
                    {
                        vFila = 1;
                        vCol = vCol + 1;
                        exHoja1.Cells[vFila, vCol] = dc.ColumnName;

                    }

                    return true;
                }
            }
            catch { }

            try
            {


                Excel.Range oRange;

                foreach (DataColumn dc in dt.Columns)
                {
                    vFila = 1;
                    vCol = vCol + 1;
                    exHoja1.Cells[vFila, vCol] = dc.ColumnName;

                    Application.DoEvents();
                }

                string vGrupNew = "";
                frmInformacion.vTotReg = dt.Rows.Count;
                Application.DoEvents();
                int vContRow = 0;

                object[] vArr = new object[dt.Columns.Count];

                foreach (DataRow dr in dt.Rows)
                {
                    if (frmInformacion.vCancel) { return true; }
                    vContRow++;
                    if (vContRow % 50 == 0)
                    {
                        frmInformacion.vNReg = vContRow;
                        Application.DoEvents();
                    }
                    vFila = vFila + 1;
                    vCol = 0;
                    if (Grupo != "")
                    {
                        int vColGrupo = Convert.ToInt16(Grupo);
                        vGrupNew = dr[vColGrupo].ToString();
                        if ((_DatoGrupo != vGrupNew) & (_DatoGrupo != ""))
                        {
                            _DatoGrupo = vGrupNew;
                            Array.Resize(ref FilasG, vContFilasG + 2);
                            FilasG[vContFilasG] = vFila;
                            vContFilasG++;
                            vFila = vFila + 1;
                            _UltimaFilaGrupo = vFila;
                        }

                        if ((_DatoGrupo == ""))
                        {
                            _DatoGrupo = vGrupNew;
                        }
                    }


                    vArr = dr.ItemArray;
                    string vtFila = "A" + vFila.ToString() + ":" + cUtil.fncLetraCol(vArr.Length) + vFila.ToString();
                    range = exHoja1.get_Range(vtFila);


                    range.set_Value(vk_missing, vArr);
                    _UltimaFila = vFila;
                    _UltimaCol = vCol;

                }

                if ((_UltimaFilaGrupo != _UltimaFila))
                {
                    vFila = vFila + 1;
                    _DatoGrupo = vGrupNew;
                    Array.Resize(ref FilasG, vContFilasG + 2);
                    FilasG[vContFilasG] = vFila;
                    vContFilasG++;
                    vFila = vFila + 1;
                    _UltimaFila = vFila;
                }

                foreach (DataColumn dc in dt.Columns)
                {

                    string vTipo = dt.Columns[vCol - 1].DataType.ToString();
                    if (vTipo == "System.DateTime")
                    {
                        string vRango = vCol + ":" + vCol;

                        oRange = exHoja1.get_Range(vRango);
                        oRange.NumberFormat = "mm/dd/yy;@";
                    }

                    Application.DoEvents();
                }



                _Error = "";
                return true;
            }
            catch (Exception ex)
            {
                _Error = ex.Message + "-" + ex.Source.ToString();
                return false;
            }

        }

        public bool BorrarCol(string vCol)
        {
            Microsoft.Office.Interop.Excel.Range oR = exHoja1.get_Range(vCol, vCol);
            oR.Delete(Microsoft.Office.Interop.Excel.XlDeleteShiftDirection.xlShiftToLeft);
            return true;
        }

        public bool AbreExcel(bool vAdd)
        {

            exApli = new Microsoft.Office.Interop.Excel.Application();

            exApli.Visible = false;

            if (_Fichero != "")
            {
                if (File.Exists(_Fichero))
                {
                    if (vAdd)
                    {
                        exLibro = exApli.Workbooks.Open(_Fichero, vk_update_links, vk_No_read_only, vk_format, vk_password,
                                                            vk_write_res_password, vk_ignore_read_only_recommend, vk_origin,
                                                            vk_delimiter, vk_editable, vk_notify, vk_converter, vk_add_to_mru,
                                                            vk_local, vk_corrupt_load);
                    }
                    else
                    {
                        File.Delete(_Fichero);
                        exLibro = exApli.Workbooks.Add(vk_missing);
                    }
                }
                else
                {
                    exLibro = exApli.Workbooks.Add(vk_missing);
                }
            }
            else
            {
                exLibro = exApli.Workbooks.Add(vk_missing);
            }


            //if (_Fichero != "")
            //{
            //    exApli.Visible = true;
            //}
            //else
            //{
            //    exApli.Visible = true;
            //}


            exApli.Visible = false;
            return true;

        }

        public void Totales(string[] Cols)
        {
            Totales(Cols, "");
        }
        public void Totales(string[] Cols, string Grupo)
        {
            int vUltFila = UltFila();
            for (int i = 0; i < Cols.Length; i++)
            {
                int vFila = vUltFila + 2;
                string vCol = Cols[i].ToString();
                string vFormula = "=Suma(" + vCol + "1:" + vCol + vUltFila.ToString() + ")";
                if (Grupo != "") { vFormula = "=Suma(" + vCol + "1:" + vCol + vUltFila.ToString() + ")/2"; }
                exHoja1.Cells[vFila, vCol] = vFormula;
                string vRango = vCol + ":" + vCol;

                Excel.Range oRange;
                oRange = exHoja1.get_Range(vRango);
                oRange.NumberFormat = "#.##0,00 €";


                vRango = "A" + (vFila);
                oRange = exHoja1.get_Range(vRango);
                string vTxGr = "Total General";
                exHoja1.Cells[vFila, 1] = vTxGr;

                vRango = vFila + ":" + vFila;
                oRange = exHoja1.get_Range(vRango);
                oRange.Font.Bold = true;
                oRange.NumberFormat = "#.##0,00 €";


            }

        }
        public void Formula(string[] Cols, string vFormul, string vTipo)
        {
            int vUltFila = UltFila();
            for (int i = 0; i < Cols.Length; i++)
            {
                int vFila = vUltFila + 2;
                string vCol = Cols[i].ToString();
                string vFormula = vFormul.Replace("[?1]", vFila.ToString());
                exHoja1.Cells[(vFila), vCol] = vFormula;
                string vRango = vCol + vFila.ToString();

                Excel.Range oRange;
                oRange = exHoja1.get_Range(vRango);
                oRange.Select();
                oRange.NumberFormat = "0%";


            }

        }

        public void TotalesGrupo(string[] Cols)
        {
            int vUltima = fncFilasG();
            Excel.Range oRange;

            for (int g = 0; g < FilasG.Length - 1; g++)
            {
                int vFila = FilasG[g];
                string vRango = "";
                for (int i = 0; i < Cols.Length; i++)
                {
                    string vCol = Cols[i].ToString();
                    int vFilaAnt = 0;
                    int vFilaFin = vFila - 1;
                    if (g != 0) { vFilaAnt = FilasG[g - 1] + 1; } else { vFilaAnt = 2; }
                    string vFormula = "=Suma(" + vCol + vFilaAnt.ToString() + ":" + vCol + vFilaFin.ToString() + ")";
                    exHoja1.Cells[vFila, vCol] = vFormula;
                }

                vRango = "A" + (vFila - 1);
                oRange = exHoja1.get_Range(vRango);
                string vTxGr = "Total " + oRange.Text.ToString();
                exHoja1.Cells[vFila, 1] = vTxGr;

                vRango = vFila + ":" + vFila;
                oRange = exHoja1.get_Range(vRango);
                oRange.Font.Bold = true;
                oRange.NumberFormat = "#.##0,00 €";

            }

        }

        public int UltFila()
        {
            return fncFilasG();

        }
        public int fncFilasG()
        {
            vContFilasG = 0;
            Excel.Range oRange;
            oRange = exHoja1.get_Range("A1");
            int vFila = 1;
            bool vOk = true;
            while (vOk)
            {
                oRange = exHoja1.get_Range("A" + vFila.ToString());
                string vTexto = oRange.Text.ToString();
                int vUlt = 0;
                vUlt = oRange.CurrentRegion.Rows.Count;
                if (vTexto != "")
                {
                    vFila += (vUlt + 1);
                    Array.Resize(ref FilasG, vContFilasG + 2);
                    FilasG[vContFilasG] = vFila - 1;
                    vContFilasG++;

                }
                if (vTexto == "") { vOk = false; }
            }

            return vFila - 2;
        }

        public void AgregarHoja()
        {

            Microsoft.Office.Interop.Excel.Worksheet newWorksheet;
            newWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)exLibro.Worksheets.Add(vk_missing, vk_missing, vk_missing, vk_missing);
        }

        public void NombreHoja(string vNomHoja)
        {
            vNomHoja = vNomHoja.Replace("INDUSTRIAS COSMIC, S_A_U_$", " ");
            exHoja1.Name = vNomHoja;
        }

        public bool CierraExcel(bool vSave)
        {
            if (vSave)
            {
                //if (File.Exists(_Fichero)) { File.Delete(_Fichero); }
                exLibro.SaveAs(_Fichero + ".xls", Excel.XlFileFormat.xlWorkbookNormal, vk_missing, vk_missing, vk_missing, vk_missing, Excel.XlSaveAsAccessMode.xlExclusive, vk_missing, vk_missing, vk_missing, vk_missing, vk_missing);
                //csharp.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue
            }

            exLibro.Close(vSave, vk_missing, vk_missing);
            exApli.Workbooks.Close();
            exApli.Quit();
            exHoja1 = null;
            exApli = null;
            exLibro = null;
            GC.Collect();
            return true;

        }
        public bool LimpiaExcel()
        {
            exHoja1 = null;
            exApli = null;
            exLibro = null;
            GC.Collect();
            return true;

        }


        public DataTable Excel2Data(string vFich, string vHoja)
        {

            return Excel2Data(vFich, vHoja, "");
        }

        public DataTable Excel2Data(string vFich, string vHoja, string vSelect)
        {
            DataTable dt = new DataTable(vHoja);

            OleDbConnection dbConn = null;
            // Build connection string.
            string connString = "Provider=Microsoft.Jet.OLEDB.12.0;" +
            "Data Source=" + vFich + ";Extended Properties=Excel 8.0;";

            // Create connection and open it.
            dbConn = new OleDbConnection(connString);
            dbConn.Open();


            if (!vHoja.EndsWith("$"))
            {
                vHoja += '$';
            }
            if (vSelect == "") { vSelect = "*"; }

            string query = string.Format("SELECT " + vSelect + " FROM [{0}]", vHoja);
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, dbConn))
            {
                adapter.Fill(dt);
            }


            return dt;
        }

        public DataTable XML2Data(string vFich, string vHoja)
        {
            DataTable dt = new DataTable(vHoja);


            DataSet dts = new DataSet();
            dts.ReadXml(vFich);




            if (dts.Tables.Count != 0)
            {
                //for (int i = 0; i < dts.Tables.Count; i++)
                //{
                //    MessageBox.Show(dts.Tables[i].TableName);
                //}

                dt = dts.Tables["Cell"];
            }
            return dt;
        }


        public DataTable ImportExcelXLS(string FileName, bool hasHeaders)
        {
            string HDR = hasHeaders ? "Yes" : "No";
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                             FileName + ";Extended Properties=\"Excel 8.0;HDR=" +
                             HDR + ";IMEX=1\"";

            DataSet output = new DataSet();
            DataTable schemaTable = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                schemaTable = conn.GetOleDbSchemaTable(
                 OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow schemaRow in schemaTable.Rows)
                {
                    string sheet = schemaRow["TABLE_NAME"].ToString();

                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                    cmd.CommandType = CommandType.Text;

                    DataTable outputTable = new DataTable(sheet);
                    output.Tables.Add(outputTable);
                    new OleDbDataAdapter(cmd).Fill(outputTable);

                    return outputTable;
                }
            }
            return schemaTable;
        }


        public void fncCopiarLinea(string vFich)
        {

            Fichero = vFich;
            AbreExcel(true);
            Visible = false;
            exHoja1 = null;
            exHoja1 = new Microsoft.Office.Interop.Excel.Worksheet();
            exHoja1 = (Microsoft.Office.Interop.Excel.Worksheet)exLibro.Worksheets.get_Item(1);
            Excel.Range oRange;


            oRange = exHoja1.get_Range("2:2");
            oRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
            //oRange = exHoja1.get_Range("1:1");
            //oRange.Select();
            //oRange2 = exHoja1.get_Range("2:2");
            //exHoja1.UsedRange.Copy(oRange2);

            //oRange=oRange.EntireRow;
            //oRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);

            //oRange = exHoja1.get_Range("2:2");
            ////exHoja1.UsedRange.Insert(Type.Missing, Type.Missing);
            //exHoja1.Paste(Type.Missing, Type.Missing);
            CierraExcel(true);
            LimpiaExcel();

            //Selection.Copy
            //Rows("2:2").Select
            //Selection.Insert Shift:=xlDown
            //Application.CutCopyMode = False


            //rng = (Excel.Range)rng.Cells[rng.Rows.Count, 1];

            //rng = rng.EntireRow;

            //rng.Insert(Excel.XlInsertShiftDirection.xlShiftDown, missing);


        }



        public static void Export(DataTable dt, string filepath, string tablename)
        {
            //excel 2003
            //string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
            //       filepath + ";Extended Properties=Excel 8.0;";
            //Excel 2007
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                   filepath + ";Extended Properties=Excel 12.0 Xml;";
            try
            {
                using (OleDbConnection con = new OleDbConnection(connString))
                {
                    con.Open();
                    StringBuilder strSQL = new StringBuilder();
                    strSQL.Append("CREATE TABLE ").Append("[" + tablename + "]");
                    strSQL.Append("(");
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        strSQL.Append("[" + dt.Columns[i].ColumnName + "] text,");
                    }
                    strSQL = strSQL.Remove(strSQL.Length - 1, 1);
                    strSQL.Append(")");

                    OleDbCommand cmd = new OleDbCommand(strSQL.ToString(), con);
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strSQL.Clear();
                        StringBuilder strfield = new StringBuilder();
                        StringBuilder strvalue = new StringBuilder();
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            strfield.Append("[" + dt.Columns[j].ColumnName + "]");
                            strvalue.Append("'" + dt.Rows[i][j].ToString() + "'");
                            if (j != dt.Columns.Count - 1)
                            {
                                strfield.Append(",");
                                strvalue.Append(",");
                            }
                            else
                            {
                            }
                        }
                        cmd.CommandText = strSQL.Append(" insert into [" + tablename + "]( ")
                            .Append(strfield.ToString())
                            .Append(") values (").Append(strvalue).Append(")").ToString();
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                Console.WriteLine("OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Export(DataTable dt, string filepath)
        {
            ExcelApp.Application myExcel = new ExcelApp.Application();
            //Create a New file
            ExcelApp._Workbook mybook = myExcel.Workbooks.Add();
            //Open the exist file
            //ExcelApp._Workbook mybook = myExcel.Workbooks.Open(filepath,
            //          Type.Missing, Type.Missing, Type.Missing,
            //    Type.Missing,Type.Missing, Type.Missing, Type.Missing,
            //    Type.Missing, Type.Missing, Type.Missing,
            //    Type.Missing, Type.Missing,Type.Missing, Type.Missing);
            //ExcelApp._Workbook mybook = myExcel.Workbooks.Open(Filename: filepath);
            myExcel.Visible = true;
            try
            {
                mybook.Activate();
                ExcelApp._Worksheet mysheet = mybook.Worksheets.Add();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ExcelApp.Range cell =
                          mysheet.get_Range(((char)(65 + j)).ToString() + (i + 1).ToString());
                        cell.Select();
                        cell.Cells.FormulaR1C1 = dt.Rows[i][j] ?? "";
                    }
                }
                //mybook.SaveAs(Filename: filepath);
                mybook.Save();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                mybook.Close();
                myExcel.Quit();
                GC.Collect();
            }
        }


    }

}