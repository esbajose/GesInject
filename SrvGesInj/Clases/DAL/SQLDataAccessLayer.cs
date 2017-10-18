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
using SrvGesInj.Clases;





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

}
