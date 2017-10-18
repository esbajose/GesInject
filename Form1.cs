using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using jControles;
using jControles.Formularios;
using GesInject.Clases;
using jControles.Clases;


namespace GesInject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitialiceComponentLocal();
            
        }
        private void InitialiceComponentLocal()
        {
            //grCli.CellEnter += gr1_CellEnter;
            
        }

        #region Eventos
            private void gr1_CellEnter(object sender, DataGridViewCellEventArgs e)
            {
                //string vTx = grCli.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        #endregion




        private void button1_Click(object sender, EventArgs e)
        {
            cParamXml.Emp = 1;
            cParamXml.Srv = "localhost";
            cParamXml.BD = "GesInject";
            cParamXml.UsuarioBD = "UserGesInject";
            cParamXml.PassUserBD = "C0ntra$ena";
            cParamXml.Carga();
            string[,] vFormatoCampos = new string[2, 2];
            vFormatoCampos[0, 0] = "CodCli";
            string vResRel = "ccodcli,cnomcli";
            string vResDes = "codcli,nomcli";
            vFormatoCampos[0, 1] = "rel#clientes##" + vResRel + "#" + vResDes + "#DBF#" + cParamXml.strOleDBConecDbf;
            vFormatoCampos[1, 0] = "Producto";
            vResRel = "cref,cdetalle";
            vResDes = "Producto,Descripción";
            vFormatoCampos[1, 1] = "rel#articulo##" + vResRel + "#" + vResDes + "#DBF#" + cParamXml.strOleDBConecDbf;


            jControles.Formularios.frmControlGr frm = new jControles.Formularios.frmControlGr();
            frm.Tabla = "GC_ClienteProducto";
            frm.Where = "WHERE (Empresa = " + cParamXml.Emp + ")";
            frm.SoloLectura = false;
            frm.CamposVis = "CodCli,NomCli,Producto,Descripción,ProductoCli";
            frm.NoVisible = "Id,Empresa";
            frm.TextoCab = "Cliente,Nombre,Producto,Descripción,Prod. Cliente";
            frm.Titulo = "Cliente Producto";
            frm.Default = "Empresa#" + cParamXml.Emp;
            frm.Conexion = cParamXml.strConec;
            frm.NoEdit = "CodCli,NomCli,Producto,Descripción";
            frm.FormatoCampo = vFormatoCampos;
            frm.ShowDialog();
            frm.Dispose();
    


            //jControles.Formularios.frmControlGr frm = new jControles.Formularios.frmControlGr();
            //frm.Tabla = "Prueba1";
            //frm.Where = "WHERE (Empresa = 1)";
            //frm.SoloLectura= false;
            //frm.CamposVis  = "2,3,4,5,6";
            //frm.NoVisible = "0,1";
            //frm.TextoCab = "Cliente,Nombre,Producto,Descripción,Prod. Cliente";
            //frm.Titulo = "Cliente Producto";
            //frm.Default = "Empresa#" + cParamXml.Emp;
            //frm.Conexion = cParamXml.strConec;
            //frm.NoEdit = "CodCli,NomCli,Producto,Descripción";
            //frm.FormatoCampo = vFormatoCampos;
            //frm.ShowDialog();
            //frm.Dispose();

            //string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=dBASE IV;Data Source='" + @"C:\GrupoSP\FAE08R01\Dbf01" + "'";
            ////connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=dBASE IV;Data Source='" + @"J:\Soft\GESTION\DBF06" + "'";
            //OleDbConnection con = new OleDbConnection(connectionString);

            
            //DataSet ds = new DataSet();
            //string sql = "select * from facclil";
            //OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
            //da.Fill(ds, "miTabla2");

            //grCli.DataSource = ds.Tables[0].DefaultView;


            //cParamXml.Srv = "srv-dbc";
            //cParamXml.BD = "RRHH";
            //string vTabla = "Calendarios";
            //string vWhere = " Where ([Empresa] = '1') ";
            //string vRes = cUtil.fncLista(vTabla, cParamXml.strConec, "Codigo","", vWhere, "", "Empresa");

            //if (vRes != "")
            //{
            //}
            //cUtil.Piece("a,s,d,r", ",", 2);
            
            //con.Close();
            //con.Dispose();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmLista frm = new frmLista();


            //gr1.ShowRowErrors  
        }
    }
}
