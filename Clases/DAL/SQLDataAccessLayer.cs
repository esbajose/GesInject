using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using GesInject.Clases;





public class SQLDataAccess2
{

    // Clase delegada
    private delegate void TGenerateListFromReader<T>(SqlDataReader returnData, ref List<T> tempList);

    
    private const string GEN_SQL_ALTA_TRANSACCION =
        "GEN_ALTA_TRANSACCION";

    private const string GEN_SQL_BAJA_TRANSACCION =
        "GEN_BAJA_TRANSACCION";


    private const string GEN_SQL_GET_NEWID =
        "GEN_GET_NEWID";

    private const string GEN_SQL_GET_NUMSERIE =
    "GEN_GET_NUMSERIE";


    //Funciones



    public static DataTable Trae(string vSql, SqlConnection oSqlConec)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();

        SqlCommand sc = new SqlCommand(vSql, oSqlConec);
        sc.CommandTimeout = 1200;

        da = new SqlDataAdapter(sc);
        dt = new DataTable();
        // Llenar la tabla con los datos indicados
        try
        {
            da.Fill(dt);
        }
        catch (Exception ex)
        { MessageBox.Show(ex.Message); }

        return dt;
    }
    public static DataSet Trae(string vSql, ref DataSet ds, string vTableName, SqlConnection oSqlConec)
    {
        SqlDataAdapter da = new SqlDataAdapter();

        SqlCommand sc = new SqlCommand(vSql, oSqlConec);
        sc.CommandTimeout = 1200;

        da = new SqlDataAdapter(sc);
        // Llenar la tabla con los datos indicados
        try
        {
            da.Fill(ds, vTableName);
        }
        catch { }

        return ds;
    }





    //public static void Update(string vTabla, SqlConnection oSqlConec, DataTable dt)
    //{
    //    Update(vTabla, oSqlConec, dt, "");
    //}

    //public static void Update(string vTabla, SqlConnection oSqlConec, DataTable dt, string vIndices)
    //{
    //    SqlDataAdapter da = new SqlDataAdapter();

    //    string vStrTabla = cUtil.fncCargaValoresSQLparaComand(vTabla);
    //    string vstrCampos = cUtil.Piece(vStrTabla, "#", 2);
    //    int vnc = Convert.ToInt16(cUtil.Piece(vStrTabla, "#", 3));
    //    string vstrTipos = cUtil.Piece(vStrTabla, "#", 4);
    //    string vstrLongs = cUtil.Piece(vStrTabla, "#", 5);
    //    vstrCampos = cUtil.Piece(vstrCampos, ",", 1, vnc);


    //    vstrCampos = vstrCampos.Replace("[", "");
    //    vstrCampos = vstrCampos.Replace("]", "");
    //    vstrCampos = vstrCampos.Replace(" ", "_");
    //    //vstrCampos = vstrCampos.Replace("(", "");
    //    //vstrCampos = vstrCampos.Replace(")", "");

    //    if (vstrCampos.Substring(0, 1) == "(") { vstrCampos = vstrCampos.Substring(1, vstrCampos.Length - 3); }
    //    vstrTipos = cUtil.Piece(vstrTipos, ",", 1, vnc);
    //    vstrLongs = cUtil.Piece(vstrLongs, ",", 1, vnc);
    //    string[] vCampos = vstrCampos.Split(',');


    //    string[] vTipos = vstrTipos.Split(',');
    //    string[] vLongs = vstrLongs.Split(',');

    //    string vinsert = cUtil.fncComandInsert(vTabla, vStrTabla);
    //    string vdelete = cUtil.fncComandDelete(vTabla, vStrTabla,vIndices);

    //    SqlCommand sc = new SqlCommand(vinsert, oSqlConec);
    //    sc.CommandType = CommandType.Text;
    //    sc.CommandTimeout = 1200;

    //    SqlCommand sd = new SqlCommand(vdelete, oSqlConec);
    //    sd.CommandType = CommandType.Text;

    //    cUtil.fncComandParam(ref sc, vTabla, vCampos, vTipos, vLongs, "Insert", vStrTabla);
    //    cUtil.fncComandParam(ref sd, vTabla, vCampos, vTipos, vLongs, "Delete", vStrTabla);
    //    da.InsertCommand = sc;

    //    da.UpdateCommand = oSqlConec.CreateCommand();
    //    da.DeleteCommand = sd;


    //    // Actualizar la tabla con los datos indicados
    //    try
    //    {

    //        //da.ContinueUpdateOnError = true;

    //        // Primero procesamos las eliminaciones        
    //        DataRow[] dtr = dt.Select("", "", DataViewRowState.Deleted);
    //        da.Update(dt.Select("", "", DataViewRowState.Deleted));

    //        //// Después las actualizaciones        
    //        //da.Update(dt.Select("","", DataViewRowState.ModifiedCurrent));

    //        //Y por último las 
    //        dtr = dt.Select("", "", DataViewRowState.Added);
    //        da.Update(dt.Select("", "", DataViewRowState.Added));

    //        da.Dispose();


    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(ex.Message);
    //        da.Dispose();
    //    }
    //}

    //public static string GenTraeNumSerie(string vSerie)
    //{
    //    return GenTraeNumSerie(vSerie, true);
    //}








    //public static string GenTraeNumSerie(string vSerie, bool vGrabar)
    //{
    //    int vGraba = 0;
    //    if (vGrabar) { vGraba = 1; }

    //    SqlCommand sqlCmd = new SqlCommand();
    //    AddParamToSQLCmd(sqlCmd, "@Serie", SqlDbType.VarChar, 20, ParameterDirection.Input, vSerie);
    //    AddParamToSQLCmd(sqlCmd, "@Grabar", SqlDbType.Int, 0, ParameterDirection.Input, vGraba);
    //    AddParamToSQLCmd(sqlCmd, "@Res", SqlDbType.NVarChar, 20, ParameterDirection.Output, null);

    //    SetCommandType(sqlCmd, CommandType.StoredProcedure, GEN_SQL_GET_NUMSERIE);
    //    ExecuteScalarCmd(sqlCmd,cParamXml.strConecProduc_Prueb);

    //    string returnValue = sqlCmd.Parameters["@Res"].Value.ToString();
    //    sqlCmd.Connection.Close();
    //    sqlCmd.Dispose();

    //    return returnValue;


    //}

    //public static int GEN_ExecuteNonQuery(string vSql, SqlConnection dbconec, SqlCommand sqlCmd)
    //{

    //    SetCommandType(sqlCmd, CommandType.Text, vSql);

    //    bool vError = false;

    //    vError = ExecuteNonQuery(sqlCmd, dbconec);

    //    int returnValue = 0;

    //    if (vError == true)
    //    {
    //        //Correcto
    //        returnValue = 1;
    //    }
    //    else
    //    {
    //        //Error
    //        returnValue = 0;
    //    }
    //    sqlCmd.Connection.Close();
    //    sqlCmd.Dispose();
    //    return returnValue;
    //}

    //public static int GEN_ExecuteNonQuery(string vSql, string ConnectionStr, SqlCommand sqlCmd)
    //{

    //    SetCommandType(sqlCmd, CommandType.Text, vSql);

    //    bool vError = false;

    //    vError = ExecuteNonQuery(sqlCmd, ConnectionStr);

    //    int returnValue = 0;

    //    if (vError == true)
    //    {
    //        //Correcto
    //        returnValue = 1;
    //    }
    //    else
    //    {
    //        //Error
    //        returnValue = 0;
    //    }
    //    sqlCmd.Connection.Close();
    //    sqlCmd.Dispose();
    //    return returnValue;
    //}

    //public static int GEN_ExecuteNonQuery(string vSql, string ConnectionStr, string TComand)
    //{
    //    int returnValue = 0;
    //   if (TComand == "SQL")
    //    {
    //        SqlCommand sqlCmd = new SqlCommand();
    //        returnValue = GEN_ExecuteNonQuery(vSql, ConnectionStr, sqlCmd);
    //    }

    //    return returnValue;
    //}

    //public static int GEN_ExecuteNonQuery(string vSql,string ConnectionStr)
    //{
    //    SqlCommand sqlCmd = new SqlCommand();

    //    SetCommandType(sqlCmd, CommandType.Text ,vSql);

    //    bool vError = false;

    //    vError = ExecuteNonQuery(sqlCmd, ConnectionStr);

    //    int returnValue = 0;

    //    if (vError == true)
    //    {
    //        //Correcto
    //        returnValue = 1;
    //    }
    //    else
    //    {
    //        //Error
    //        returnValue = 0;
    //    }
    //    sqlCmd.Connection.Close();
    //    sqlCmd.Dispose();
    //    return returnValue;
    //}

    //public static int GEN_ExecuteNonQuery(string vSql, SqlConnection dbconec)
    //{
    //    int returnValue = 0;
    //    SqlCommand sqlCmd = new SqlCommand();
    //    returnValue = GEN_ExecuteNonQuery(vSql, dbconec, sqlCmd);

    //    return returnValue;
    //}


    //public static string GetNewId()
    //{
    //    SqlCommand sqlCmd = new SqlCommand();
    //    AddParamToSQLCmd(sqlCmd, "@Res", SqlDbType.NVarChar, 20, ParameterDirection.Output, null);

    //    SetCommandType(sqlCmd, CommandType.StoredProcedure, GEN_SQL_GET_NEWID);
    //    ExecuteScalarCmd(sqlCmd, cParamXml.strConecProduc_Prueb);

    //    string returnValue = sqlCmd.Parameters["@Res"].Value.ToString();
    //    sqlCmd.Connection.Close();
    //    sqlCmd.Dispose();

    //    return returnValue;

    //}
    //public static bool  VerifConec(string vStrConec)
    //{
    //    bool vOk = false;
    //    SqlConnection vConec = new SqlConnection(vStrConec);
    //    try
    //    {
    //        vConec.Open();
    //        vOk = true;
    //        vConec.Close();

    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(ex.Message);
    //        vOk = false;
    //    }

    //    return vOk ;

    //}


    //private static void AddParamToSQLCmd(SqlCommand sqlCmd,
    //                              string paramId,
    //                              SqlDbType sqlType,
    //                              int paramSize,
    //                              ParameterDirection paramDirection,
    //                              object paramvalue)
    //{

    //    if (sqlCmd == null)
    //        throw (new ArgumentNullException("sqlCmd"));
    //    if (paramId == string.Empty)
    //        throw (new ArgumentOutOfRangeException("paramId"));

    //    SqlParameter newSqlParam = new SqlParameter();

    //    newSqlParam.ParameterName = paramId;
    //    newSqlParam.SqlDbType = sqlType;
    //    newSqlParam.Direction = paramDirection;

    //    if (paramSize > 0)
    //        newSqlParam.Size = paramSize;

    //    if (paramvalue != null)
    //        newSqlParam.Value = paramvalue;

    //    sqlCmd.Parameters.Add(newSqlParam);

    //}

    //private static void ExecuteScalarCmd(SqlCommand sqlCmd)
    //{
    //    try
    //    {
    //        if (cParamXml.strConecProduc_Prueb == string.Empty)
    //            throw (new ArgumentOutOfRangeException("ConnectionString"));

    //        if (sqlCmd == null)
    //            throw (new ArgumentNullException("sqlCmd"));

    //        using (SqlConnection cn = new SqlConnection(cParamXml.strConecProduc_Prueb))
    //        {

    //            sqlCmd.Connection = cn;
    //            cn.Open();
    //            sqlCmd.ExecuteScalar();
    //        }
    //    }
    //    catch { }

    //}
    //private static void ExecuteScalarCmd(SqlCommand sqlCmd, string connectString)
    //{
    //    try
    //    {
    //        using (SqlConnection cn = new SqlConnection(connectString))
    //        {
    //            sqlCmd.Connection = cn;
    //            sqlCmd.Connection.Open();
    //            sqlCmd.ExecuteScalar();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        string vError = ex.Message + "#" + ex.Source + "#" + ex.TargetSite;
    //        //MessageBox.Show(vError);
    //    }

    //}
    //private static object ExecuteScalarCmdResult(SqlCommand sqlCmd)
    //{
    //    object result = null;
    //    try
    //    {


    //        if (cParamXml.strConecProduc_Prueb == string.Empty)
    //            throw (new ArgumentOutOfRangeException("ConnectionString"));

    //        if (sqlCmd == null)
    //            throw (new ArgumentNullException("sqlCmd"));

    //        using (SqlConnection cn = new SqlConnection(cParamXml.strConecProduc_Prueb))
    //        {
    //            sqlCmd.Connection = cn;
    //            cn.Open();
    //            try
    //            {
    //                result = sqlCmd.ExecuteScalar();
    //            }
    //            catch
    //            {
    //                result = null;
    //            }
    //        }
    //    }
    //    catch
    //    {
    //        result = null;

    //    }
    //    return result;
    //}


    //private bool ExecuteNonQueryAsin(SqlCommand sqlCmd, 
    //                                 string connectString,
    //                                 ref ToolStripStatusLabel tslEspera,
    //                                 int vEspera)
    //{
    //    try
    //    {
    //        using (SqlConnection cn = new SqlConnection(connectString))
    //        {
    //            sqlCmd.Connection = cn;
    //            sqlCmd.Connection.Open();

    //            IAsyncResult result = sqlCmd.BeginExecuteNonQuery();
    //            int vContSeg = 0;
    //            while (!result.IsCompleted)
    //            {
    //                vContSeg = vContSeg + 1;

    //                ((ToolStripStatusLabel)tslEspera).Text = "Tiempo de espera : " + vContSeg.ToString();
    //                System.Threading.Thread.Sleep(1000);
    //                Application.DoEvents();
    //                if (vContSeg > vEspera)
    //                {
    //                    sqlCmd.EndExecuteNonQuery(result);
    //                    return false;
    //                }
    //            }
    //            sqlCmd.EndExecuteNonQuery(result);
    //            return true;

    //        }
    //    }
    //    catch
    //    {
    //        return false;
    //    }

    //}
    //private static bool ExecuteNonQuery(SqlCommand sqlCmd,string connectString)
    //{
    //    try
    //    {

    //        using (SqlConnection cn = new SqlConnection(connectString))
    //        {
    //            sqlCmd.Connection = cn;
    //            sqlCmd.Connection.Open();

    //            sqlCmd.ExecuteNonQuery();
    //            return true;

    //        }
    //    }
    //    catch
    //    {
    //        return false;
    //    }

    //}

    //private static bool ExecuteNonQuery(SqlCommand sqlCmd, SqlConnection dbconec)
    //{
    //    try
    //    {

    //        sqlCmd.Connection = dbconec;
    //        sqlCmd.CommandTimeout = 1200;
    //        //sqlCmd.Connection.Open();

    //        sqlCmd.ExecuteNonQuery();
    //        return true;

    //    }
    //    catch
    //    {
    //        return false;
    //    }

    //}


    //private static void SetCommandType(SqlCommand sqlCmd, CommandType cmdType, string cmdText)
    //{
    //    sqlCmd.CommandType = cmdType;
    //    sqlCmd.CommandText = cmdText;
    //}
    //private void TExecuteReaderCmd<T>(SqlCommand sqlCmd, TGenerateListFromReader<T> gcfr, ref List<T> List)
    //{
    //    try
    //    {
    //        if (cParamXml.strConecProduc_Prueb == string.Empty)
    //            throw (new ArgumentOutOfRangeException("ConnectionString"));

    //        if (sqlCmd == null)
    //            throw (new ArgumentNullException("sqlCmd"));

    //        using (SqlConnection cn = new SqlConnection(cParamXml.strConecProduc_Prueb))
    //        {
    //            sqlCmd.Connection = cn;
    //            cn.Open();
    //            gcfr(sqlCmd.ExecuteReader(), ref List);
    //        }
    //    }
    //    catch { }
    //}
    //private DataSet toDataset(string vXml)
    //{
    //    DataSet vDs = new DataSet();
    //    System.Xml.XmlDocument oXml = new System.Xml.XmlDocument();

    //    if (vXml != "")
    //    {
    //        vXml = "<ROOT>" + vXml + "</ROOT>";

    //        oXml.LoadXml(vXml);

    //        StringReader vStr = new StringReader(vXml);
    //        XmlTextReader rXml = new XmlTextReader(vStr);
    //        vDs.ReadXml(rXml);

    //    }
    //    return vDs;

    //}


    ////Funciones GesWeb


}
