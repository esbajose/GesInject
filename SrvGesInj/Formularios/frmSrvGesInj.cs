using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using jControles.Clases;
using SrvGesInj.Clases;
using System.Threading;

namespace SrvGesInj.Formularios
{
    public partial class frmSrvGesInj : Form
    {
        public frmSrvGesInj()
        {
            InitializeComponent();
        }

        #region Procesos locales
        private void sbrProceso()
        {

            if (cParamXml.ActProv == "False") return;


            string vSql = cConstantes.SQL_Insert_Cab_AlbProv;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            SQLDataAccess.GEN_ExecuteNonQuery(vSql, cParamXml.strConec);



            tiProces.Enabled = false;
            lbMen.Text = "Procesando Albaranes de Proveedor";
            Application.DoEvents();
            DataTable dt = new DataTable();
            
            string vNumSerie = SQLDataAccess.GenTraeNumSerie(cParamXml.NSerOrdAlbProv, false, cParamXml.strConec);

            vSql = cConstantes.SQL_Alb_Dbf;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?NumAlb]", vNumSerie);

            lbMen.Text = "Procesando Albaranes de Proveedor: Captura de Datos";
            lbError.Text = vSql;
            Application.DoEvents();

            try
            {
                dt = SQLDataAccess.TraeDBF(vSql, cUtil.DBFConec(cParamXml.strOleDBConecDbf));
                cAlbaranesCompra.LinAlbCompra oLinAlb = new cAlbaranesCompra.LinAlbCompra();

                lbMen.Text = "Procesando Albaranes de Proveedor: Proceso";
                Application.DoEvents();
                foreach (DataRow dr in dt.Rows)
                {
                    string vNumAlb = dr["nnumalb"].ToString();
                    string vNumPed = dr["nnumped"].ToString();
                    string vProd = dr["CREF"].ToString();
                    string vNomProd = dr["cdetalle"].ToString();
                    string vCan = dr["NCANENT"].ToString();
                    string vFecha = dr["DFecAlb"].ToString();
                    string vProv = dr["ccodpro"].ToString();
                    string vNomProv = cProveedores.fncTraeC("cnompro", vProv);
                    string vLote = dr["cprop2"].ToString();
                    string vLinea = dr["nlinea"].ToString();
                    if (vLinea == "") vLinea = "0";
                    if (vCan == "") vCan = "0";
                    decimal vCanEnt = Convert.ToDecimal(vCan);
                    string vNumSer = SQLDataAccess.GenTraeNumSerie("ProductoLote", true, cParamXml.strConec);

                    oLinAlb.Empresa = cParamXml.Emp;
                    oLinAlb.NumAlb = vNumAlb;
                    oLinAlb.Linea = Convert.ToInt16(vLinea);
                    oLinAlb.FechaEntrega = Convert.ToDateTime(vFecha);
                    oLinAlb.Producto = vProd;
                    oLinAlb.Descripción = vNomProd;
                    oLinAlb.CodProv = vProv;
                    oLinAlb.NombreProv = vNomProv;
                    oLinAlb.Cantidad = vCanEnt;
                    oLinAlb.Lote = vLote;
                    oLinAlb.RecepcionadoPor = "";
                    oLinAlb.NumSerie = vNumSer;
                    oLinAlb.Grabado = 10;


                    lbMen.Text = "Procesando Albaranes de Proveedor: " + vNumAlb;
                    Application.DoEvents();
                    if (oLinAlb.fncAltaLin())
                    {
                        SQLDataAccess.GenSetNumSerie(cParamXml.NSerOrdAlbProv, vNumAlb, cParamXml.strConec);
                    }



                }
            }
            catch (Exception ex)
            {
                lbError.Text = DateTime.Now.ToLongDateString() + "-- " + ex.Message;
            }

            

            lbMen.Text="";
            Application.DoEvents();
            tiProces.Enabled = true;
        }
        private void sbrProcesoCli()
        {
            if (cParamXml.ActCli == "False") return;

            tiProces.Enabled = false;
            lbMen.Text = "Procesando Albaranes de Cliente";
            Application.DoEvents();
            DataTable dt = new DataTable();

            string vNumSerie = SQLDataAccess.GenTraeNumSerie(cParamXml.NSerOrdAlbCli, false, cParamXml.strConec);

            string vSql = cConstantes.SQL_Alb_Cli_Dbf;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?NumAlb]", vNumSerie);

            try
            {
                dt = SQLDataAccess.TraeDBF(vSql, cUtil.DBFConec(cParamXml.strOleDBConecDbf));
                cAlbaranesVenta.LinAlbVenta oLinAlb = new cAlbaranesVenta.LinAlbVenta();

                foreach (DataRow dr in dt.Rows)
                {
                    string vNumAlb = dr["nnumalb"].ToString();
                    string vNumPed = dr["nnumped"].ToString();
                    string vProd = dr["CREF"].ToString();
                    string vNomProd = dr["cdetalle"].ToString();
                    string vCan = dr["NCANENT"].ToString();
                    string vFecha = dr["DFecAlb"].ToString();
                    string vCli = dr["ccodcli"].ToString();
                    string vNomCli = cClientes.fncTraeC("cnomcli", vCli);
                    string vLote = dr["cprop2"].ToString();
                    string vLinea = dr["nlinea"].ToString();
                    if (vLinea == "") vLinea = "0";
                    if (vCan == "") vCan = "0";
                    decimal vCanEnt = Convert.ToDecimal(vCan);

                    oLinAlb.Empresa = cParamXml.Emp;
                    oLinAlb.NumAlb = vNumAlb;
                    oLinAlb.Linea = Convert.ToInt16(vLinea);
                    oLinAlb.FechaEntrega = Convert.ToDateTime(vFecha);
                    oLinAlb.Producto = vProd;
                    oLinAlb.Descripción = vNomProd;
                    oLinAlb.CodCli = vCli;
                    oLinAlb.NombreCli = vNomCli;
                    oLinAlb.Cantidad = vCanEnt;
                    oLinAlb.Lote = vLote;
                    oLinAlb.Grabado = 10;

                    if (oLinAlb.fncAltaLin())
                    {
                        SQLDataAccess.GenSetNumSerie(cParamXml.NSerOrdAlbCli, vNumAlb, cParamXml.strConec);
                    }



                }
            }
            catch(Exception ex)
            {
                lbError.Text = DateTime.Now.ToLongDateString() + "-- " + ex.Message;
            }


            lbMen.Text = "";
            Application.DoEvents();
            tiProces.Enabled = true;
        }
        private void sbrProcesoPedCli()
        {
            if (cParamXml.ActPedCli == "False") return;

            tiProces.Enabled = false;
            lbMen.Text = "Procesando Pedidos de Cliente";
            Application.DoEvents();
            DataTable dt = new DataTable();

            string vNumSerie = SQLDataAccess.GenTraeNumSerie(cParamXml.NSerPedCli, false, cParamXml.strConec);

            string vSql = cConstantes.SQL_CabPed_Dbf;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?NumPed]", vNumSerie);

            try
            {
                dt = SQLDataAccess.TraeDBF(vSql, cUtil.DBFConec(cParamXml.strOleDBConecDbf));
                cPedidosVenta.CabVenta oCabPed = new cPedidosVenta.CabVenta();
                cPedidosVenta.LinVenta oLinPed = new cPedidosVenta.LinVenta();
                string vNumPed ="";
                string vErr = "";
                foreach (DataRow dr in dt.Rows)
                {

                    vNumPed = dr["nnumped"].ToString();

                    if (oCabPed.fncAlta(dr))
                    {

                        string vSql2 = cConstantes.SQL_LinPed_Dbf;
                        vSql2 = vSql2.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                        vSql2 = vSql2.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                        vSql2 = vSql2.Replace("[?NumPed]", vNumPed);
                        DataTable dt2 = SQLDataAccess.TraeDBF(vSql2, cUtil.DBFConec(cParamXml.strOleDBConecDbf));
                        foreach (DataRow dr2 in dt2.Rows)
                        {
                            //DataRow dr2 = dt2.Rows[0];
                            if (!oLinPed.fncAltaLin(dr2))
                            {
                                vErr = oLinPed.Error;
                                lbError.Text = vErr;
                                Application.DoEvents();
                                Thread.Sleep(5000);

                            }
                        }
                    }
                    else
                    {
                        vErr = oCabPed.Error;
                        lbError.Text = vErr;
                        Application.DoEvents();
                        Thread.Sleep(5000);

                    }
                    SQLDataAccess.GenSetNumSerie(cParamXml.NSerPedCli, vNumPed, cParamXml.strConec);
                }

            }
            catch (Exception ex)
            {
                lbError.Text = DateTime.Now.ToLongDateString() + "-- " + ex.Message;
            }


            lbMen.Text = "";
            Application.DoEvents();
            tiProces.Enabled = true;
        }


        private void sbrGrabaMov()
        {
            if (cParamXml.ActProv == "False") return;
            
            tiProces.Enabled = false;
            lbMen.Text = "Grabando Movimientos de Proveedor";
            Application.DoEvents();
            DataTable dt = new DataTable();


            string vSql = cConstantes.SQL_AlbCompra_Pend;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?Grabado]", "= 0 ");

            dt = SQLDataAccess.Trae(vSql,cUtil.SQLConec(cParamXml.strConecProduc_Prueb));
            cAlbaranesCompra.LinAlbCompra oLinAlb = new cAlbaranesCompra.LinAlbCompra();

            foreach (DataRow dr in dt.Rows)
            {
                string vNumAlb = dr["NumAlb"].ToString();
                string vLinAlb = dr["Linea"].ToString();
                string vNumPed = dr["NumPed"].ToString();
                string vProd = dr["Producto"].ToString();
                string vNomProd = dr["Descripción"].ToString();
                string vCan = dr["Cantidad"].ToString();
                string vLote = dr["Lote"].ToString();
                string vRecep = dr["RecepcionadoPor"].ToString();
                string vCert = dr["Cert"].ToString();
                string vUbi = dr["Ubi"].ToString();
                string vSerie = dr["NumSerie"].ToString();




                int vId = Convert.ToInt32(dr["Id"].ToString());
                if (vCan == "") vCan = "0";
                decimal vCanEnt = Convert.ToDecimal(vCan);

                oLinAlb.Id = vId;

                if (vCert == "")
                {
                    oLinAlb.fncGrabaCampo("Grabado", "14");
                    lbMen.Text = "";
                    Application.DoEvents();
                    tiProces.Enabled = true;
                    return;
                }

                if (vLote == "")
                {
                    oLinAlb.fncGrabaCampo("Grabado", "15");
                    lbMen.Text = "";
                    Application.DoEvents();
                    tiProces.Enabled = true;
                    return;
                }

                //if (vRecep == "")
                //{
                //    oLinAlb.fncGrabaCampo("Grabado", "16");
                //    lbMen.Text = "";
                //    Application.DoEvents();
                //    tiProces.Enabled = true;
                //    return;
                //}




                //Busco el Producto en anexos
                string vWhere = " Empresa = " + cParamXml.Emp + " and Producto = N'" + vProd + "'";
                string vProdAnex = cUtil.fncTraeCampo("Producto", "GC_ProductoAnexos", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", true);
                if (vProdAnex == "***Inex***")
                {
                    oLinAlb.fncGrabaCampo("Grabado", "12");
                }
                else
                {
                    //Crear movimientos de producto y materia prima
                    cMovimientos.Articulo oMov = new cMovimientos.Articulo();
                    cProductoLote oPL = new cProductoLote();

                    //Movimiento de producto
                    if (oMov.fncAlta(cParamXml.Emp, "Entrada", DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vProd, vNomProd,
                                    vCan, vNumAlb, "", vUbi, vLote))
                    {
                        oLinAlb.fncGrabaCampo("Grabado", "1");
                        string vNumSer = vSerie;
                        if (vNumSer == "") vNumSer = SQLDataAccess.GenTraeNumSerie("ProductoLote", true, cParamXml.strConec);
                        oPL.fncAlta(cParamXml.Emp, vNumSer, vProd, vLote, vNumAlb, Convert.ToInt32(vLinAlb));
                    }
                    else
                    {
                        oLinAlb.fncGrabaCampo("Grabado", "11");
                    }
                }
            }



            lbMen.Text = "";
            Application.DoEvents();
            tiProces.Enabled = true;
        }
        private void sbrGrabaMovCli()
        {
            if (cParamXml.ActCli == "False") return;

            tiProces.Enabled = false;
            lbMen.Text = "Grabando Movimientos de Cliente";
            Application.DoEvents();
            DataTable dt = new DataTable();


            string vSql = cConstantes.SQL_AlbVenta_Pend;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
            vSql = vSql.Replace("[?Grabado]", "= 0 ");

            dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));
            cAlbaranesVenta.LinAlbVenta oLinAlb = new cAlbaranesVenta.LinAlbVenta();

            foreach (DataRow dr in dt.Rows)
            {
                string vNumAlb = dr["NumAlb"].ToString();
                string vNumPed = dr["NumPed"].ToString();
                string vProd = dr["Producto"].ToString();
                string vNomProd = dr["Descripción"].ToString();
                string vCan = dr["Cantidad"].ToString();
                string vLote = dr["Lote"].ToString();
                int vId = Convert.ToInt32(dr["Id"].ToString());
                if (vCan == "") vCan = "0";
                decimal vCanEnt = Convert.ToDecimal(vCan);

                oLinAlb.Id = vId;

                //Busco el Producto en anexos
                string vWhere = " Empresa = " + cParamXml.Emp + " and Producto = N'" + vProd + "'";
                string vProdAnex = cUtil.fncTraeCampo("Producto", "GC_ProductoAnexos", vWhere, "", cParamXml.strConecProduc_Prueb, "SQL", true);
                if (vProdAnex == "***Inex***")
                {

                    oLinAlb.fncGrabaCampo("Grabado", "12");
                }
                else
                {
                    //Crear movimientos de producto y materia prima
                    cMovimientos.Articulo oMov = new cMovimientos.Articulo();

                    //Movimiento de producto
                    if (vCanEnt == 0)
                    {
                        oLinAlb.fncGrabaCampo("Grabado", "13");
                    }
                    else if (oMov.fncAlta(cParamXml.Emp, "Salida", DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vProd, vNomProd,                                    ("-" + vCan), vNumAlb, "", "", vLote))
                    {
                        oLinAlb.fncGrabaCampo("Grabado", "1");
                    }
                    else
                    {
                        oLinAlb.fncGrabaCampo("Grabado", "11");
                    }
                }
            }



            lbMen.Text = "";
            Application.DoEvents();
            tiProces.Enabled = true;
        }


        #endregion


        #region Servicios

        #endregion

        private void parametrosDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmParametros();
            frm.ShowDialog();

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void tiProces_Tick(object sender, EventArgs e)
        {

            sbrProceso();
            sbrProcesoCli();
            sbrProcesoPedCli();

            sbrGrabaMov();
            sbrGrabaMovCli();


        }

        private void frmSrvGesInj_Load(object sender, EventArgs e)
        {

            if (cUtil.fncEnEjecucion(Application.ProductName.ToString()))
            {
                MessageBox.Show("Existe una copia de la aplicación en marcha.Acepte este mensaje y ejecute de nuevo el programa SrvGesInj");

                //Icon1.Visible = false;

                IntPtr vint = IntPtr.Zero;
                cUtil.fncCierraExe(vint, true, Application.ProductName.ToString());
                this.Close();
            }

            frmInformacion.vTexto = "Iniciando Servicios GesInject";
            Form frm = new frmInformacion();
            frm.Show();
            Application.DoEvents();
            
            frm.Close();
            Application.DoEvents();

            cParamXml.AlmacenMat = "Principal";

            string vTit = "Servicios  GesInject " + "" + " Versión :" + Application.ProductVersion.ToString() + "  Conectado con: " + cParamXml.Srv + " (" + cParamXml.BD + ")";
            this.Text = vTit;
            //Hacemos visible el formulario
            this.Show();
            this.WindowState = FormWindowState.Minimized;
            
            //Ocultamos el icono de la bandeja de sistema
            Icon1.Visible = true;
            this.Visible = false;
            this.Hide();
        }

        private void btActivar_Click(object sender, EventArgs e)
        {
            if (tiProces.Enabled == true)
            {
                btActivar.Text = "&Activar";
                pB1.Value = 0;
                tiProces.Enabled = false;
                tipB.Enabled = false;
            }
            else
            {
                btActivar.Text = "&Desactivar";
                tiProces.Enabled = true;
                tipB.Enabled = true;
            }
        }

        private void tipB_Tick(object sender, EventArgs e)
        {
            pB1.Value = pB1.Value + 2;
            if (pB1.Value > 95)
            {
                pB1.Value = 1;
            }
            Application.DoEvents();

        }

        private void Icon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Hacemos visible el formulario
            this.Show();
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            //Ocultamos el icono de la bandeja de sistema
            Icon1.Visible = false;

        }

        private void frmSrvGesInj_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.Visible = false;
                Icon1.Visible = true;
            }
            else
            {
                this.Show();
                this.Visible = true;
                Icon1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vTabla = "albprol";
            string vWhere = " Where DFecStock >= #01/01/2015# and NNumAlb > 1400240 ";
            //vWhere = " Where NNumAlb > 1400240 ";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "nnumalb", "", vWhere, "", "", false, "", "", "", "DBF");


            if (txSql.Text != "")
            {
                string vSql = txSql.Text;

                vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "", "", "", vSql, "", false, "", "", "", "DBF");

            }
            if (vRes != "")
            {

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sbrProceso();
            sbrProcesoCli();
            sbrProcesoPedCli();

            sbrGrabaMov();
            sbrGrabaMovCli();

        }

        private void lbMen_DoubleClick(object sender, EventArgs e)
        {
            txSql.Visible = !txSql.Visible;
        }
    }
}
