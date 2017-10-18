using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using jControles.Clases;
using GesInject.Informes;
using GesInject.Formularios;
using GesInject.Datasets;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;



namespace GesInject.Clases
{
    class cInformes
    {
        private static bool _Imp = false;

        public static bool Imp
        {
            get { return _Imp; }
            set { _Imp = value;}
        }

        public static void sbrPrintOFL(string vEmpresa,string vOFL)
        {
            string vSql = cConstantes.SQL_OFL_Imp;

            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", vEmpresa);
            vSql = vSql.Replace("[?OFL]", vOFL);
            
            DataSet dts = new DataSet();
            dts = SQLDataAccess.Trae(vSql, ref dts, "dtOFL", cUtil.SQLConec(cParamXml.strConecProduc_Prueb));


            string vsPeso = "";
            string vsPiezasHora = "";
            string vsCan = "";
            string vArtic = "";

            if (dts.Tables["dtOFL"].Rows.Count > 0)
            {
                vsPeso = (dts.Tables["dtOFL"].Rows[0]["PesoNeto"] != null) ? dts.Tables["dtOFL"].Rows[0]["PesoNeto"].ToString() : "";
                vsPiezasHora = (dts.Tables["dtOFL"].Rows[0]["PiezasHora"] != null) ? dts.Tables["dtOFL"].Rows[0]["PiezasHora"].ToString() : "";
                vsCan = (dts.Tables["dtOFL"].Rows[0]["Cantidad"] != null) ? dts.Tables["dtOFL"].Rows[0]["Cantidad"].ToString() : "";
                vArtic = (dts.Tables["dtOFL"].Rows[0]["Articulo"] != null) ? dts.Tables["dtOFL"].Rows[0]["Articulo"].ToString() : "";
            }

            decimal vdCan = Convert.ToDecimal(vsCan);
            int viPiezasHora = Convert.ToInt32(vsPiezasHora);
            decimal vHoras = 0;

            if (viPiezasHora > 0) vHoras = vdCan / viPiezasHora;
            string vsHoras = string.Format("{0:n2}", vHoras) ;

            decimal vdPeso = Convert.ToDecimal(vsPeso);

            decimal vKilos = (vdPeso * vdCan) / 1000;
            string vsKilos = string.Format("{0:n2}", vKilos) ;


            string vImagen = cProducto.Articulo.fncTraeC("Imagen", vArtic);
            PictureBox pic1 = new PictureBox();
            if (vImagen != "") vImagen = cParamXml.DirImProd + @"\" + vImagen;
            try
            {
                pic1.Image = null;
                pic1.Load(vImagen);
            }
            catch { }

            int vAncho = 1;
            int vAlto = 1;
            if (pic1.Image != null)
            {
                vAncho = pic1.Image.Width;
                vAlto = pic1.Image.Height;
            }

            if (dts.Tables["dtOFL"].Rows.Count > 0)
            {

                //Elimino y creo de nuevo el campo imagen porque al rellenarse con SQL se convierte en texto
                dts.Tables["dtOFL"].Columns.Remove("Imagen");
                dts.Tables["dtOFL"].Columns.Add("Imagen", typeof(byte[]));
                ////////////////////////////////////////////////////////////////////////////////////////////

                dts.Tables["dtOFL"].Rows[0].BeginEdit();
                dts.Tables["dtOFL"].Rows[0]["Imagen"] = cUtil.imageToByteArray(pic1.Image);
                dts.Tables["dtOFL"].Rows[0].EndEdit();
            }
            DataTable dt = dts.Tables["dtOFL"];

            rptOFL rpt = new rptOFL();
            rptCBOFL rptCB = new rptCBOFL();
            rptOFLCompo rptCompo = new rptOFLCompo();


            rpt.SetDataSource(dt);
            rptCB.SetDataSource(dt);
            rptCompo.SetDataSource(dt);


            if (vAlto != 0)
            {
                if (vAncho >= vAlto)
                {
                    vAlto = vAlto * rpt.ReportDefinition.Sections["Section2"].ReportObjects["Imagen1"].Width / vAncho;
                    vAncho = rpt.ReportDefinition.Sections["Section2"].ReportObjects["Imagen1"].Width;
                }
                else
                {
                    vAncho = vAncho * rpt.ReportDefinition.Sections["Section2"].ReportObjects["Imagen1"].Height / vAlto;
                    vAlto = rpt.ReportDefinition.Sections["Section2"].ReportObjects["Imagen1"].Height;
                }
            }

            if (vAlto != 0) rpt.ReportDefinition.Sections["Section2"].ReportObjects["Imagen1"].Height = vAlto;
            if (vAncho != 0) rpt.ReportDefinition.Sections["Section2"].ReportObjects["Imagen1"].Width = vAncho;



            rpt.DataDefinition.FormulaFields["fHoras"].Text = "'" + string.Format("{0:dd/MM/yyyy}", vsHoras) + "'";
            rpt.DataDefinition.FormulaFields["fKilos"].Text = "'" + string.Format("{0:dd/MM/yyyy}", vsKilos) + "'";
            rpt.DataDefinition.FormulaFields["fImagen"].Text = "'" + vImagen + "'";
            if (dt.Rows.Count > 1)
            {
                Application.DoEvents();
                rpt.ReportDefinition.Sections["Section2"].ReportObjects["DesMaterial1"].Height = 0;
                rpt.ReportDefinition.Sections["Section2"].ReportObjects["DesMaterial1"].Width = 0;
                rpt.ReportDefinition.Sections["Section2"].ReportObjects["Material1"].Height = 0;
                rpt.ReportDefinition.Sections["Section2"].ReportObjects["Material1"].Width = 0;
            }

            if (_Imp)
            {
                Application.DoEvents();
                rpt.PrintOptions.PrinterName = cParamXml.PrintGen;
                rpt.PrintToPrinter(1, false, 0, 0);
                Application.DoEvents();

                if (cParamXml.ImpCBOF == "True")
                {
                    Application.DoEvents();
                    rptCB.PrintOptions.PrinterName = cParamXml.PrintGen;
                    rptCB.PrintToPrinter(1, false, 0, 0);
                    Application.DoEvents();
                }

                if (dt.Rows.Count > 1)
                {
                    Application.DoEvents();

                    rptCompo.PrintOptions.PrinterName = cParamXml.PrintGen;
                    rptCompo.PrintToPrinter(1, false, 0, 0);
                    Application.DoEvents();

                }

            }
            else
            {
                Application.DoEvents();
                Form frm = new frmVisor();
                frmVisor.orpt = rpt;
                frm.ShowDialog();
                Application.DoEvents();

                if (cParamXml.ImpCBOF == "True")
                {
                    Application.DoEvents();
                    Form frm2 = new frmVisor();
                    frmVisor.orpt = rptCB;
                    frm2.ShowDialog();
                    Application.DoEvents();
                }

                if (dt.Rows.Count > 1)
                {
                    Application.DoEvents();
                    Form frm2 = new frmVisor();
                    frmVisor.orpt = rptCompo;
                    frm2.ShowDialog();
                    Application.DoEvents();
                }
            }

            Imp = false;
            Application.DoEvents();
            rpt.Close();
            rptCB.Close();
            Application.DoEvents();
            rpt.Dispose();
            rptCB.Dispose();
            Application.DoEvents();



        }

        public static void sbrImpListOF(string vTipo)
        {
            string vSql = cConstantes.SQL_OF_ImpLista;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());

            if (vTipo == "Lanzada")
            {
                string vFilEstado = " and (GC_OrdenProd.Estado = 'Lanzada') ";
                vSql = vSql.Replace("[?FilEstado]", vFilEstado);

                DataSet dts = new DataSet();
                dts = SQLDataAccess.Trae(vSql, ref dts, "dtsOFProduc", cUtil.SQLConec(cParamXml.strConecProduc_Prueb));

                rptOFLanz rpt = new rptOFLanz();
                rpt.SetDataSource(dts);
                if (_Imp)
                {
                    Application.DoEvents();
                    rpt.PrintOptions.PrinterName = cParamXml.PrintGen;
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Application.DoEvents();
                }
                else
                {
                    Application.DoEvents();
                    Form frm = new frmVisor();
                    frmVisor.orpt = rpt;
                    frm.ShowDialog();
                    Application.DoEvents();
                }

                Imp = false;
                Application.DoEvents();
                rpt.Close();
                Application.DoEvents();
                rpt.Dispose();
                Application.DoEvents();
            }

            if (vTipo == "Producción")
            {
                string vFilEstado = " and (GC_OrdenProd.Estado = 'Producción') ";
                vSql = vSql.Replace("[?FilEstado]", vFilEstado);

                DataSet dts = new DataSet();
                dts = SQLDataAccess.Trae(vSql, ref dts, "dtsOFProduc", cUtil.SQLConec(cParamXml.strConecProduc_Prueb));

                rptOFProduc rpt = new rptOFProduc();
                rpt.SetDataSource(dts);
                if (_Imp)
                {
                    Application.DoEvents();
                    //rpt.PrintOptions.PrinterName = cParam.PrintRobot.ToString();
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Application.DoEvents();
                }
                else
                {
                    Application.DoEvents();
                    Form frm = new frmVisor();
                    frmVisor.orpt = rpt;
                    frm.ShowDialog();
                    Application.DoEvents();
                }

                Imp = false;
                Application.DoEvents();
                rpt.Close();
                Application.DoEvents();
                rpt.Dispose();
                Application.DoEvents();
            }


        }

        public static void sbrImpMateriales(string vTipo)
        {
            string vSql = "";
            DataSet dts = new DataSet();

            if (vTipo == "Total")
            {

                vSql = cConstantes.SQL_Mat_ImpLista0;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());

                dts = SQLDataAccess.Trae(vSql, ref dts, "dtMatInf", cUtil.SQLConec(cParamXml.strConecProduc_Prueb));


                rptMatTotal rpt = new rptMatTotal();
                rpt.SetDataSource(dts);
                if (_Imp)
                {
                    Application.DoEvents();
                    rpt.PrintOptions.PrinterName = cParamXml.PrintGen;
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Application.DoEvents();
                }
                else
                {
                    Application.DoEvents();
                    Form frm = new frmVisor();
                    frmVisor.orpt = rpt;
                    frm.ShowDialog();
                    Application.DoEvents();
                }

                Imp = false;
                Application.DoEvents();
                rpt.Close();
                Application.DoEvents();
                rpt.Dispose();
                Application.DoEvents();

                return;
            }

            vSql = cConstantes.SQL_Mat_ImpLista;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());

            dts = SQLDataAccess.Trae(vSql, ref dts, "dtMatInf", cUtil.SQLConec(cParamXml.strConecProduc_Prueb));




            if (vTipo == "Reserva")
            {

                rptMatReserva rpt = new rptMatReserva();
                rpt.SetDataSource(dts);
                if (_Imp)
                {
                    Application.DoEvents();
                    //rpt.PrintOptions.PrinterName = cParam.PrintRobot.ToString();
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Application.DoEvents();
                }
                else
                {
                    Application.DoEvents();
                    Form frm = new frmVisor();
                    frmVisor.orpt = rpt;
                    frm.ShowDialog();
                    Application.DoEvents();
                }

                Imp = false;
                Application.DoEvents();
                rpt.Close();
                Application.DoEvents();
                rpt.Dispose();
                Application.DoEvents();
            }

            if (vTipo == "Necesidad")
            {

                rptMatNece rpt = new rptMatNece();
                rpt.SetDataSource(dts);
                if (_Imp)
                {
                    Application.DoEvents();
                    rpt.PrintOptions.PrinterName = cParamXml.PrintGen;
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Application.DoEvents();
                }
                else
                {
                    Application.DoEvents();
                    Form frm = new frmVisor();
                    frmVisor.orpt = rpt;
                    frm.ShowDialog();
                    Application.DoEvents();
                }

                Imp = false;
                Application.DoEvents();
                rpt.Close();
                Application.DoEvents();
                rpt.Dispose();
                Application.DoEvents();
            }

        }

        public static void sbrImpProductos(string vTipo)
        {
            string vSql = "";
            DataSet dts = new DataSet();

            if (vTipo == "Total")
            {

                vSql = cConstantes.SQL_Prod_ImpLista0;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());

                dts = SQLDataAccess.Trae(vSql, ref dts, "dtProdInf", cUtil.SQLConec(cParamXml.strConecProduc_Prueb));


                rptProdTotal rpt = new rptProdTotal();
                rpt.SetDataSource(dts);
                if (_Imp)
                {
                    Application.DoEvents();
                    rpt.PrintOptions.PrinterName = cParamXml.PrintGen;
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Application.DoEvents();
                }
                else
                {
                    Application.DoEvents();
                    Form frm = new frmVisor();
                    frmVisor.orpt = rpt;
                    frm.ShowDialog();
                    Application.DoEvents();
                }

                Imp = false;
                Application.DoEvents();
                rpt.Close();
                Application.DoEvents();
                rpt.Dispose();
                Application.DoEvents();

                return;
            }


        }


        public static void sbrEtiCaja(string vNomCli, string vProd, string vNomProd, string vNOF,string vPiezasCaja,
                                        string vFecha, string vOper, string vCaja,string vProdCli)
        {

            rptEtiCaja rpt = new rptEtiCaja();


            rpt.DataDefinition.FormulaFields["fCliente"].Text = "'" + vNomCli + "'";
            rpt.DataDefinition.FormulaFields["fRefPieza"].Text = "'" + vProdCli + "'";
            rpt.DataDefinition.FormulaFields["fNomPieza"].Text = "'" + vNomProd + "'";
            rpt.DataDefinition.FormulaFields["fNOF"].Text = "'" + vNOF + "'";
            rpt.DataDefinition.FormulaFields["fPiezasCaja"].Text = "'" + vPiezasCaja  + "'";
            rpt.DataDefinition.FormulaFields["fFecha"].Text = "'" + string.Format("{0:dd/MM/yyyy}", vFecha) + "'";
            rpt.DataDefinition.FormulaFields["fOperario"].Text = "'" + vOper + "'";
            rpt.DataDefinition.FormulaFields["fCaja"].Text = "'" + vCaja + "'";
            rpt.DataDefinition.FormulaFields["fProducto"].Text = "'" + vProd + "'";


            if (_Imp)
            {
                Application.DoEvents();
                rpt.PrintOptions.PrinterName = cParamXml.PrintEtiCajaBolsa;
                rpt.PrintToPrinter(1, false, 0, 0);
                Application.DoEvents();
            }
            else
            {
                Application.DoEvents();
                Form frm = new frmVisor();
                frmVisor.orpt = rpt;
                frm.ShowDialog();
                Application.DoEvents();
            }

            Imp = false;
            Application.DoEvents();
            rpt.Close();
            Application.DoEvents();
            rpt.Dispose();
            Application.DoEvents();



        }

        public static void sbrEtiCaja(DataTable dt,bool vConLogo)
        {

            sbrEtiCaja(dt, 0, 0,"",vConLogo);


        }

        public static void sbrEtiCaja(DataTable dt,int vAlto,int vAncho,string vEtiCli,bool vConLogo)
        {
            ReportClass rpt;
            if (vConLogo)
            {
                rpt = new rptEtiCajaBolsa();
            }
            else
            {
                rpt = new rptEtiCajaBolsaSinLogo();
            }

            rpt.SetDataSource(dt);

            if (vAlto != 0)
            {
                if (vAncho >= vAlto)
                {
                    vAlto = vAlto * rpt.ReportDefinition.Sections["Section2"].ReportObjects["Imagen1"].Width / vAncho;
                    vAncho = rpt.ReportDefinition.Sections["Section2"].ReportObjects["Imagen1"].Width;
                }
                else
                {
                    vAncho = vAncho * rpt.ReportDefinition.Sections["Section2"].ReportObjects["Imagen1"].Height / vAlto;
                    vAlto = rpt.ReportDefinition.Sections["Section2"].ReportObjects["Imagen1"].Height;
                }
            }

            if ( vAlto != 0) rpt.ReportDefinition.Sections["Section2"].ReportObjects["Imagen1"].Height = vAlto;
            if (vAncho != 0) rpt.ReportDefinition.Sections["Section2"].ReportObjects["Imagen1"].Width = vAncho;


            if (vEtiCli == "1")
            {
                rpt.ReportDefinition.ReportObjects["Picture1"].ObjectFormat.EnableSuppress = true;
                rpt.ReportDefinition.ReportObjects["EtiCliente1"].ObjectFormat.EnableSuppress = false;
            }

            string vNumCaja = dt.Rows[0]["Caja"].ToString();

            string vCaja = "Caja";
            if (vNumCaja.LastIndexOf(".") != -1) vCaja = "Bolsa";

            rpt.DataDefinition.FormulaFields["fCaja"].Text = "'" + vCaja + "'";


            if (_Imp)
            {
                Application.DoEvents();
                rpt.PrintOptions.PrinterName = cParamXml.PrintEtiCajaBolsa;
                rpt.PrintToPrinter(1, false, 0, 0);
                Application.DoEvents();
            }
            else
            {
                Application.DoEvents();
                Form frm = new frmVisor();
                frmVisor.orpt = rpt;
                frm.ShowDialog();
                Application.DoEvents();
            }

            Imp = false;
            Application.DoEvents();
            rpt.Close();
            Application.DoEvents();
            rpt.Dispose();
            Application.DoEvents();



        }

        public static void sbrEtiTextoLibre(int vNumLin, string[] vLins, bool vLogo, bool vCentra)
        {

            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

            if (vNumLin == 3) rpt = new rptEti3L();
            if (vNumLin == 4) rpt = new rptEti4L();
            if (vNumLin == 5) rpt = new rptEti5L();

            for (int i = 0; i < vNumLin; i++)
            {
                string vInf = "fLin" + (i+1).ToString();
                rpt.DataDefinition.FormulaFields[vInf].Text = "'" + vLins[i] + "'";
                if (vCentra) rpt.ReportDefinition.ReportObjects["Flin" + (i + 1).ToString() + "1"].ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign;
            }

            
            rpt.ReportDefinition.ReportObjects["Picture1"].ObjectFormat.EnableSuppress = !vLogo;

            if (_Imp)
            {
                Application.DoEvents();
                rpt.PrintOptions.PrinterName = cParamXml.PrintEtiCajaBolsa;
                rpt.PrintToPrinter(1, false, 0, 0);
                Application.DoEvents();
            }
            else
            {
                Application.DoEvents();
                Form frm = new frmVisor();
                frmVisor.orpt = rpt;
                frm.ShowDialog();
                Application.DoEvents();
            }

            Imp = false;
            Application.DoEvents();
            rpt.Close();
            Application.DoEvents();
            rpt.Dispose();
            Application.DoEvents();



        }

        public static void sbrImprimeEtiEntrada(cAlbaranesCompra.LinAlbCompra oLinalb,int viCanEt)
        {
            ReportDocument rpt = new ReportDocument();
            rpt = new rptEtiEntradas();
            int vConEt = 0;
            int vNumET = 2;

            dtsEtiEntradas dts = new dtsEtiEntradas();
            DataRow dr = dts.Tables["dtEtiEntradas"].NewRow();

            for (int n = 0; n < viCanEt; n++)
            {
                vConEt++;

                if (vConEt > vNumET)
                {
                    dts.Tables["dtEtiEntradas"].Rows.Add(dr);
                    dr = dts.Tables["dtEtiEntradas"].NewRow();
                    vConEt = 1;
                }

                string vstrCont = "";
                if (vConEt > 1) vstrCont = vConEt.ToString();

                dr["Material" + vstrCont] = oLinalb.Descripción;
                dr["Referencia" + vstrCont] = oLinalb.Producto;
                dr["Proveedor" + vstrCont] = oLinalb.CodProv + "-" + oLinalb.NombreProv;
                dr["Albaran" + vstrCont] = oLinalb.SuAlb;
                dr["Lote" + vstrCont] = oLinalb.Lote;
                dr["Cantidad" + vstrCont] = oLinalb.Cantidad;
                dr["Cert" + vstrCont] = oLinalb.Cert;
                dr["Calidad" + vstrCont] = "SI";
                dr["RecepPor" + vstrCont] = oLinalb.RecepcionadoPor;
                dr["Fecha" + vstrCont] = oLinalb.FechaEntrega.ToShortDateString();
                dr["Lote2"] = oLinalb.NumSerie;

            }

            dts.Tables["dtEtiEntradas"].Rows.Add(dr);

            rpt.SetDataSource(dts);

            if (_Imp)
            {
                Application.DoEvents();
                rpt.PrintOptions.PrinterName = cParamXml.PrintEtiCajaBolsa;
                rpt.PrintToPrinter(1, false, 0, 0);
                Application.DoEvents();
            }
            else
            {
                Application.DoEvents();
                Form frm = new frmVisor();
                frmVisor.orpt = rpt;
                frm.ShowDialog();
                Application.DoEvents();
            }

            Imp = false;
            Application.DoEvents();
            rpt.Close();
            Application.DoEvents();
            rpt.Dispose();
            Application.DoEvents();

        }

        public static void sbrPrintPrepPen(string vEmpresa, DataTable dt)
        {

            rptPrepPen rpt = new rptPrepPen();

            
            rpt.SetDataSource(dt);


            if (_Imp)
            {
                Application.DoEvents();
                rpt.PrintOptions.PrinterName = cParamXml.PrintGen;
                rpt.PrintToPrinter(1, false, 0, 0);
                Application.DoEvents();


            }
            else
            {
                Application.DoEvents();
                Form frm = new frmVisor();
                frmVisor.orpt = rpt;
                frm.ShowDialog();
                Application.DoEvents();

            }

            Imp = false;
            Application.DoEvents();
            rpt.Close();
            rpt.Dispose();
            Application.DoEvents();



        }

        public static void sbrPrintPakingList(string vEmpresa, DataTable dt,bool vLinea)
        {

            rptPackingList rpt = new rptPackingList();
            DataTable dt2 = dt.Clone();

            
            foreach (DataRow dr in dt.Rows)
            {
                string vCajas = dr["Cajas"].ToString();
                vCajas = vCajas.Replace(".", ",");
                string vLote = dr["Lote"].ToString();
                string vOFL = cUtil.Piece(vLote, "|", 2);
                vOFL = vOFL.Trim();

                if ((vOFL != "")&(vLinea))
                {
                    //DataRow drnew1 = dt2.NewRow();
                    //drnew1.ItemArray = dr.ItemArray;
                    //dt2.Rows.Add(drnew1);
                    
                    if (vCajas.LastIndexOf(",") != -1)
                    {
                        string[] vmCajas = vCajas.Split(',');
                        for (int i = 0; i < vmCajas.Length; i++)
                        {
                            string vCaja = vmCajas[i];

                            string vTabla="GC_OrdenProdCajas";
                            string vWhere = " (IdOF = N'" + vOFL + "') AND (NumCajaBolsa = " + vCaja + ")";
                            string vCan = cUtil.fncTraeCampo("CanProd", vTabla, vWhere, "", cParamXml.strConecProduc_Prueb);
                            if (vCaja != "")
                            {
                                DataRow drnew = dt2.NewRow();
                                drnew.ItemArray = dr.ItemArray;
                                drnew["Cantidad"] = vCan;
                                drnew["Cajas"] = vCaja;

                                dt2.Rows.Add(drnew);

                            }
                            else
                            {
                                DataRow drnew2 = dt2.NewRow();
                                drnew2.ItemArray = dr.ItemArray;
                                dt2.Rows.Add(drnew2);

                            }

                        }

                    }
                    else
                    {
                        DataRow drnew2 = dt2.NewRow();
                        drnew2.ItemArray = dr.ItemArray;
                        dt2.Rows.Add(drnew2);

                    }
                }
                else
                {
                    DataRow drnew2 = dt2.NewRow();
                    drnew2.ItemArray = dr.ItemArray;
                    dt2.Rows.Add(drnew2);

                }
            }


            rpt.SetDataSource(dt2);


            if (_Imp)
            {
                Application.DoEvents();
                rpt.PrintOptions.PrinterName = cParamXml.PrintGen;
                rpt.PrintToPrinter(1, false, 0, 0);
                Application.DoEvents();


            }
            else
            {
                Application.DoEvents();
                Form frm = new frmVisor();
                frmVisor.orpt = rpt;
                frm.ShowDialog();
                Application.DoEvents();

            }

            Imp = false;
            Application.DoEvents();
            rpt.Close();
            rpt.Dispose();
            Application.DoEvents();



        }

        public static void sbrPrintCertCal(string vEmpresa, DataTable dt)
        {

 

            foreach (DataRow dr in dt.Rows)
            {
                string vOFL = dr["OFL"].ToString();
                string vLote = dr["Lote"].ToString();
                string vCajas = dr["Cajas"].ToString();
                string vNomCli = dr["NomCli"].ToString();
                string vCantidad = dr["Cantidad"].ToString();
                string vEntrega = dr["NumPrep"].ToString();

                if (vOFL != "")
                {
                    string vSql = cConstantes.SQL_Cert_Calc2;
                    vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                    vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                    vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                    vSql = vSql.Replace("[?OFL]", vOFL.Trim());
                    DataTable dtCertCal = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));

                    string vArtic = dtCertCal.Rows[0]["Articulo"].ToString();

                    string vImagen = cProducto.Articulo.fncTraeC("Imagen", vArtic);
                    PictureBox pic1 = new PictureBox();
                    if (vImagen != "") vImagen = cParamXml.DirImProd + @"\" + vImagen;
                    try
                    {
                        pic1.Image = null;
                        pic1.Load(vImagen);
                    }
                    catch { }

                    int vAncho = 1;
                    int vAlto = 1;
                    if (pic1.Image != null)
                    {
                        vAncho = pic1.Image.Width;
                        vAlto = pic1.Image.Height;
                    }



                    dtCertCal.Rows[0].BeginEdit();

                    //Elimino y creo de nuevo el campo imagen porque al rellenarse con SQL se convierte en texto
                    dtCertCal.Columns.Remove("Foto");
                    dtCertCal.Columns.Add("Foto", typeof(byte[]));
                    ////////////////////////////////////////////////////////////////////////////////////////////



                    dtCertCal.Rows[0]["Lotes"] = vLote;
                    dtCertCal.Rows[0]["Cajas"] = vCajas;
                    dtCertCal.Rows[0]["CantidadFab"] = vCantidad;
                    dtCertCal.Rows[0]["NomCli"] = vNomCli;
                    dtCertCal.Rows[0]["Foto"] = cUtil.imageToByteArray(pic1.Image);
                    dtCertCal.Rows[0]["Entrega"] = vEntrega;

                    dtCertCal.Rows[0].EndEdit();

                    rptCertCalidad rpt = new rptCertCalidad();
                    rpt.SetDataSource(dtCertCal);

                    int viAlto = rpt.ReportDefinition.Sections["Section2"].ReportObjects["Foto1"].Height;
                    int viAncho = rpt.ReportDefinition.Sections["Section2"].ReportObjects["Foto1"].Width;

                    if (vAlto > 10)
                    {
                        if (vAncho >= vAlto)
                        {
                            vAlto = vAlto * rpt.ReportDefinition.Sections["Section2"].ReportObjects["Foto1"].Width / vAncho;
                            vAncho = rpt.ReportDefinition.Sections["Section2"].ReportObjects["Foto1"].Width;
                        }
                        else
                        {
                            vAncho = vAncho * rpt.ReportDefinition.Sections["Section2"].ReportObjects["Foto1"].Height / vAlto;
                            vAlto = rpt.ReportDefinition.Sections["Section2"].ReportObjects["Foto1"].Height;
                        }
                    }

                    if (vAlto != 0) rpt.ReportDefinition.Sections["Section2"].ReportObjects["Foto1"].Height = vAlto;
                    if (vAncho != 0) rpt.ReportDefinition.Sections["Section2"].ReportObjects["Foto1"].Width = vAncho;





                    if (_Imp)
                    {
                        Application.DoEvents();
                        rpt.PrintOptions.PrinterName = cParamXml.PrintGen;
                        rpt.PrintToPrinter(1, false, 0, 0);
                        Application.DoEvents();


                    }
                    else
                    {
                        Application.DoEvents();
                        Form frm = new frmVisor();
                        frmVisor.orpt = rpt;
                        frm.ShowDialog();
                        Application.DoEvents();

                    }

                    Imp = false;
                    Application.DoEvents();
                    rpt.Close();
                    rpt.Dispose();
                    Application.DoEvents();

                }
            }





        }


    }
}
