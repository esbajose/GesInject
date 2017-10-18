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
using GesInject.Clases;
using jControles.Formularios;

namespace GesInject.Formularios
{
    public partial class frmPrinc : Form
    {
        public frmPrinc()
        {
            InitializeComponent();
        }



        #region Procesos locales

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


        #endregion

        private void frmPrinc_Load(object sender, EventArgs e)
        {
            stalbUser.Text = cParamXml.Usuario;
            
            cParamXml.AlmacenMat = "Principal";
            
            stalbFecha.Text = DateTime.Now.ToShortDateString();
            //string vTit = "G.C.- Gestión Cronomol " + "" + " Versión :" + Application.ProductVersion.ToString() + "  Conectado con: " + cParamXml.Srv + " (" + cParamXml.BD + ")";
            string vTit = "G.C.- Gestión Cronomol " +  "  Conectado con: " + cParamXml.Srv + " (" + cParamXml.BD + ")";
            cUtil.fncRecuperaEstado(this, vTit);
            cUtil.ControlMenus(this.Controls);

            cActuDB.sbrActuSql();
            
            

        }

        private void frmPrinc_FormClosing(object sender, FormClosingEventArgs e)
        {
            cUtil.fncGuardaEstado(this);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void selecciónDeMenusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cParamXml.PassAdmin == "") { cParamXml.PassAdmin = "pepito"; }
            if (cParamXml.DirXML == "") { cParamXml.DirXML = @"C:\Xml"; }
            Form frm = new frmSeguridad();
            frmSeguridad.frm = this;
            frmSeguridad.vPassAdmin = cParamXml.PassAdmin;
            frmSeguridad.vDirXML = cParamXml.DirXML;
            frmSeguridad.vMs = menuStrip1;
            frm.ShowDialog();

        }

        private void parametrosDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmParametros();
            frm.ShowDialog();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void direccionesDeEntregaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmDirEntrega();
            frm.MdiParent = this;
            frm.Show();

        }

        private void pedidosClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmPedcli();
            frm.MdiParent = this;
            frm.Show();

        }

        private void pedidosProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmPedProv();
            frm.MdiParent = this;
            frm.Show();

        }

        private void contadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jControles.Formularios.frmAuto frm = new jControles.Formularios.frmAuto();
            frm.Tabla = "GC_NumSerie";
            frm.Where = "WHERE (Empresa = " + cParamXml.Emp + ")";
            frm.Edit = "S";
            frm.CamposVis = "2,3,4";
            frm.TextoCab = "";
            frm.Titulo = "Contadores";
            frm.Default = "Empresa#" + cParamXml.Emp;
            frm.Conexion = cParamXml.strConec;
            frm.ShowDialog();
            string vRes = frm.Res;
            frm.Dispose();

            if (vRes != "")
            {
            }
        }

        private void clienteProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[,] vFormatoCampos = new string[3, 2];
            vFormatoCampos[0, 0] = "CodCli";
            string vResRel = "ccodcli,cnomcli";
            string vResDes = "codcli,nomcli";
            vFormatoCampos[0, 1] = "rel#clientes##" + vResRel + "#" + vResDes + "#DBF#" + cParamXml.strOleDBConecDbf;
            vFormatoCampos[1, 0] = "Producto";
            vResRel = "cref,cdetalle";
            vResDes = "Producto,Descripción";
            vFormatoCampos[1, 1] = "rel#articulo##" + vResRel + "#" + vResDes + "#DBF#" + cParamXml.strOleDBConecDbf;
            vFormatoCampos[2, 0] = "EtiCli";
            vFormatoCampos[2, 1] = "ch#";


            jControles.Formularios.frmControlGr frm = new jControles.Formularios.frmControlGr();
            frm.Tabla = "GC_ClienteProducto";
            frm.Where = "WHERE (Empresa = " + cParamXml.Emp + ")";
            frm.SoloLectura = false;
            frm.CamposVis = "CodCli,NomCli,Producto,Descripción,ProductoCli,EtiCli,EtiDes";
            frm.NoVisible = "Id,Empresa";
            frm.TextoCab = "Cliente,Nombre,Producto,Descripción,Prod. Cliente,Etiqueta,Des.Etiqueta";
            frm.Titulo = "Cliente Producto";
            frm.Default = "Empresa#" + cParamXml.Emp;
            frm.Conexion = cParamXml.strConec;
            frm.NoEdit = "CodCli,NomCli,Producto,Descripción";
            frm.FormatoCampo = vFormatoCampos;
            frm.ShowDialog();
            frm.Dispose();

        }

        private void ordenesDeProducciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmOF();
            frm.MdiParent = this;
            frm.Show();


        }

        private void productoMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmProdAnexos();
            frm.MdiParent = this;
            frm.Show();


            //string[,] vFormatoCampos = new string[3, 2];
            //vFormatoCampos[0, 0] = "CodProv";
            //string vResRel = "ccodpro,cnompro";
            //string vResDes = "codproV,NombreProv";
            //vFormatoCampos[0, 1] = "rel#proveedo##" + vResRel + "#" + vResDes + "#DBF#" + cParamXml.strOleDBConecDbf;
            
            //vFormatoCampos[1, 0] = "Producto";
            //vResRel = "cref,cdetalle";
            //vResDes = "Producto,Descripción";
            //vFormatoCampos[1, 1] = "rel#articulo##" + vResRel + "#" + vResDes + "#DBF#" + cParamXml.strOleDBConecDbf;
            
            //vFormatoCampos[2, 0] = "Material";
            //vResRel = "Material,Descripción";
            //vResDes = "Material";
            //vFormatoCampos[2, 1] = "rel#GC_Materiales##" + vResRel + "#" + vResDes + "#SQL#" + cParamXml.strConecProduc_Prueb;


            //jControles.Formularios.frmControlGr frm = new jControles.Formularios.frmControlGr();
            //frm.Tabla = "GC_ProductoMat";
            //frm.Where = "WHERE (Empresa = " + cParamXml.Emp + ")";
            //frm.SoloLectura = false;
            //frm.CamposVis = "Producto,Descripción,Material,Color,CodProv,NombreProv,Precio";
            //frm.NoVisible = "Id,Empresa";
            //frm.TextoCab = "Producto,Descripción,Material,Color,Cod.Prov,Nombre Prov.,Precio";
            //frm.Titulo = "Producto Material";
            //frm.Default = "Empresa#" + cParamXml.Emp;
            //frm.Conexion = cParamXml.strConec;
            //frm.NoEdit = "CodProv,NombreProv,Producto,Descripción,Material";
            //frm.FormatoCampo = vFormatoCampos;
            //frm.ShowDialog();
            //frm.Dispose();


        }

        private void materialesToolStripMenuItem_Click(object sender, EventArgs e)
        {


            jControles.Formularios.frmControlGr frm = new jControles.Formularios.frmControlGr();
            frm.Tabla = "GC_Materiales";
            frm.Where = "WHERE (Empresa = " + cParamXml.Emp + ")";
            frm.SoloLectura = false;
            frm.CamposVis = "Material,Descripción";
            frm.NoVisible = "Id,Empresa";
            frm.TextoCab = "Material,Descripción";
            frm.Titulo = "Materiales";
            frm.Default = "Empresa#" + cParamXml.Emp;
            frm.Conexion = cParamXml.strConec;
            frm.NoEdit = "";
            frm.ShowDialog();
            frm.Dispose();


        }

        private void moldesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string[,] vFormatoCampos = new string[1, 2];

            vFormatoCampos[0, 0] = "Bloqueado";
            vFormatoCampos[0, 1] = "ch#";


            jControles.Formularios.frmControlGr frm = new jControles.Formularios.frmControlGr();
            frm.Tabla = "GC_Moldes";
            frm.Where = "WHERE (Empresa = " + cParamXml.Emp + ")";
            frm.SoloLectura = false;
            frm.CamposVis = "CodMolde,Descripción,Cavidades,Ubicación,Fechador,Bloqueado";
            frm.NoVisible = "Id,Empresa";
            frm.TextoCab = "CodMolde,Descripción,Cavidades,Ubicación,Fechador,Bloqueado";
            frm.Titulo = "Moldes";
            frm.Default = "Empresa#" + cParamXml.Emp;
            frm.Conexion = cParamXml.strConec;
            frm.FormatoCampo = vFormatoCampos;
            frm.NoEdit = "";
            frm.ShowDialog();
            frm.Dispose();

        }

        private void maestrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void movimientosStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMoviStock frm = new frmMoviStock();
            frm.Show();
        }

        private void lanzarOrdenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLanzarOFL frm = new frmLanzarOFL();
            frm.Show();
        }

        private void operariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jControles.Formularios.frmControlGr frm = new jControles.Formularios.frmControlGr();
            frm.Tabla = "GC_Operarios";
            frm.Where = "WHERE (Empresa = " + cParamXml.Emp + ")";
            frm.SoloLectura = false;
            frm.CamposVis = "IdOper,Nombre";
            frm.NoVisible = "Id,Empresa";
            frm.TextoCab = "Operario,Nombre";
            frm.Titulo = "Operarios";
            frm.Default = "Empresa#" + cParamXml.Emp;
            frm.Conexion = cParamXml.strConec;
            frm.NoEdit = "";
            frm.ShowDialog();
            frm.Dispose();

        }

        private void maquinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jControles.Formularios.frmControlGr frm = new jControles.Formularios.frmControlGr();
            frm.Tabla = "GC_Maquinas";
            frm.Where = "WHERE (Empresa = " + cParamXml.Emp + ")";
            frm.SoloLectura = false;
            frm.CamposVis = "IdMaquina,Descripción";
            frm.NoVisible = "Id,Empresa";
            frm.TextoCab = "Maquina,Descripción";
            frm.Titulo = "Maquinas";
            frm.Default = "Empresa#" + cParamXml.Emp;
            frm.Conexion = cParamXml.strConec;
            frm.NoEdit = "";
            frm.ShowDialog();
            frm.Dispose();


        }

        private void iniciarProducciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducción frm = new frmProducción();
            frm.MdiParent = this; 
            frm.Show();
        }

        private void finDeJornadaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmFinJornada frm = new frmFinJornada();
            frm.MdiParent = this; 
            frm.Show();
        }

        private void oFLanzadasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            cInformes.Imp = (cParamXml.Imp == "True") ? true : false;
            cInformes.sbrImpListOF("Lanzada");

        }

        private void oFEnProducciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cInformes.Imp = (cParamXml.Imp == "True") ? true : false;
            cInformes.sbrImpListOF("Producción");

        }

        private void stockMaterialesTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cInformes.Imp = (cParamXml.Imp == "True") ? true : false;
            cInformes.sbrImpMateriales("Total");

        }

        private void stockMaterialesReservadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cInformes.Imp = (cParamXml.Imp == "True") ? true : false;
            cInformes.sbrImpMateriales("Reserva");

        }

        private void necesidadesDeMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cInformes.Imp = (cParamXml.Imp == "True") ? true : false;
            cInformes.sbrImpMateriales("Necesidad");

        }

        private void terminarOFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTerminarOF frm = new frmTerminarOF();
            frm.MdiParent = this;
            frm.Show();

        }

        private void cajaBolsaManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEtiCajaMan frm = new frmEtiCajaMan();
            frm.MdiParent = this;
            frm.Show();

        }

        private void textoLibreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTextoLibre frm = new frmTextoLibre();
            frm.MdiParent = this;
            frm.Show();

        }

        private void consultaMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmMoviProd frm = new frmMoviProd();
            frm.MdiParent = this;
            frm.Show();

        }

        private void oFTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadosOFL frm = new frmListadosOFL();
            frm.MdiParent = this;
            frm.Show();

        }

        private void inicioDeJornadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInicioJornada frm = new frmInicioJornada();
            frm.MdiParent = this;
            frm.Show();

        }

        private void movimientosDeAlbaranCompraPendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMoviAlbCompra frm = new frmMoviAlbCompra();
            frm.MdiParent = this;
            frm.Show();

        }

        private void movimientosDeAlbaranVentaPendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMoviAlbVenta frm = new frmMoviAlbVenta();
            frm.MdiParent = this;
            frm.Show();

        }

        private void albaranesProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAlbProv();
            frm.MdiParent = this;
            frm.Show();

        }

        private void líneasDeAlbaranRegistradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLineasAlbCompraReg frm = new frmLineasAlbCompraReg();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ubicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jControles.Formularios.frmControlGr frm = new jControles.Formularios.frmControlGr();
            frm.Tabla = "GC_Ubicaciones";
            frm.Where = "WHERE (Empresa = " + cParamXml.Emp + ")";
            frm.SoloLectura = false;
            frm.CamposVis = "Ubi";
            frm.NoVisible = "Id,Empresa";
            frm.TextoCab = "Ubicación";
            frm.Titulo = "Ubicaciones";
            frm.Default = "Empresa#" + cParamXml.Emp;
            frm.Conexion = cParamXml.strConec;
            frm.NoEdit = "";
            frm.ShowDialog();
            frm.Dispose();
        }

        private void movimientosEntreUbicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMovimientosEntreUbi frm = new frmMovimientosEntreUbi();
            frm.MdiParent = this;
            frm.Show();

        }

        private void logDeErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogErrores frm = new frmLogErrores();
            frm.MdiParent = this;
            frm.Show();

        }

        private void eliminarStockDePLsToolStripMenuItem_Click(object sender, EventArgs e)
        {


            string vMen = "Este proceso eliminara TODO el Stock de los Productos 'PL-' (Mat.Prima),Esta seguro ?";
            string vTit = "Eliminar";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
            {

                return;
            }


            vMen = "Peroooo Seguro, seguro ?";
            vTit = "Eliminar";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
            {

                return;
            }

            frmInformacion frm = new frmInformacion();
            frm.vTex = "Eliminando Stock de 'PL-'";
            frm.Show();
            Application.DoEvents();

            string vID = System.Guid.NewGuid().ToString();

            string vSql = cConstantes.SQL_ElimStockPL;
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));

            foreach (DataRow dr in dt.Rows)
            {
                string vProd = dr["Producto"].ToString();
                string vCan = dr["canreg"].ToString();
                decimal vdCan = Convert.ToDecimal(vCan);
                string vUbi = dr["Ubi"].ToString();
                string vLote = dr["Lote"].ToString();
                string vOFL = dr["OFL"].ToString();
                try
                {
                    string vTipo="Entrada";
                    if (vdCan < 0) vTipo = "Salida"; 
                    //Crear movimientos de producto y materia prima
                    cMovimientos.Articulo oMov = new cMovimientos.Articulo();

                    //Movimiento de producto
                    oMov.fncAlta(cParamXml.Emp, vTipo, DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vProd, "",
                                    vCan, "Inv_" + vID, vOFL, vUbi, vLote);

                }
                catch {}
            }

            frm.Close();

            MessageBox.Show("Se han eliminado todo el Stock del los Productos 'PL-'");

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string vTabla = "albprol";
            vTabla = "pedclit";
            string vWhere = " Where DFecPed >= #01/01/2015# ";
            //vWhere = " ";
            string vSql =
                "SELECT pedclit.NNUMPED, pedclit.CCODCLI, pedclit.DFECPED, pedclit.CESTADO, pedclil.* " +
                "FROM pedclit INNER JOIN pedclil ON pedclit.NNUMPED = pedclil.NNUMPED " +
                " Where DFecPed >= #01/01/2015# ";

            string vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "nnumped", "", vWhere, vSql, "", false, "", "", "", "DBF");

            if (vRes != "")
            {

            }



            vTabla = "albprol";
            vTabla = "pedclil";
            vWhere = " Where DFecStock >= #01/01/2015# and NNumAlb > 1400240 ";
            vWhere = " where ((ncanped - ncanent) > 0) ";
            vRes = cUtil.fncLista(vTabla, cParamXml.strOleDBConecDbf, "nnumped", "", vWhere, "", "", false, "", "", "", "DBF");

            if (vRes != "")
            {

            }

        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void preparaciónEntregasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPrepEntregas frm = new frmPrepEntregas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void calcularPreparacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCalcPrep frm = new frmCalcPrep();
            frm.MdiParent = this;
            frm.Show();
            
        }

        private void preparacionesPendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrepPen frm = new frmPrepPen();
            frm.MdiParent = this;
            frm.Show();

        }

        private void impresiónDePackingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPakingList frm = new frmPakingList();
            frm.MdiParent = this;
            frm.Show();

        }

        private void eliminarStockDePZsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string vMen = "Este proceso eliminara TODO el Stock de los Productos 'PZ-' (Producto Terminado),Esta seguro ?";
            string vTit = "Eliminar";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
            {

                return;
            }


            vMen = "Peroooo Seguro, seguro ?";
            vTit = "Eliminar";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
            {

                return;
            }

            frmInformacion frm = new frmInformacion();
            frm.vTex = "Eliminando Stock de 'PZ-'";
            frm.Show();
            Application.DoEvents();

            string vID = System.Guid.NewGuid().ToString();

            string vSql = cConstantes.SQL_ElimStockPZ;
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));

            foreach (DataRow dr in dt.Rows)
            {
                string vProd = dr["Producto"].ToString();
                string vCan = dr["canreg"].ToString();
                decimal vdCan = Convert.ToDecimal(vCan);
                string vUbi = dr["Ubi"].ToString();
                string vLote = dr["Lote"].ToString();
                string vOFL = dr["OFL"].ToString();
                try
                {
                    string vTipo = "Entrada";
                    if (vdCan < 0) vTipo = "Salida";
                    //Crear movimientos de producto y materia prima
                    cMovimientos.Articulo oMov = new cMovimientos.Articulo();

                    //Movimiento de producto
                    oMov.fncAlta(cParamXml.Emp, vTipo, DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vProd, "",
                                    vCan, "Inv_" + vID,vOFL, vUbi, vLote);

                }
                catch { }
            }

            frm.Close();

            MessageBox.Show("Se han eliminado todo el Stock del los Productos 'PZ-'");
        }

        private void eliminarStockDePZsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string vTabla = "GC_Ind_ProductoUbiCanLoteOFL";
            string vRes = cUtil.fncLista(vTabla, cParamXml.strConecProduc_Prueb, "Producto", "", "", "", "ID,Empresa", false, "", "", "", "SQL");

            if (vRes == "")
            {
                return;
            }



            string vMen = "Este proceso eliminara TODO el Stock de la Referencia:" + vRes + ",Esta seguro ?";
            string vTit = "Eliminar";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
            {

                return;
            }


            vMen = "Peroooo Seguro, seguro ?";
            vTit = "Eliminar";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
            {

                return;
            }

            frmInformacion frm = new frmInformacion();
            frm.vTex = "Eliminando Stock de la Referencia:" + vRes;
            frm.Show();
            Application.DoEvents();

            string vID = System.Guid.NewGuid().ToString();

            string vSql = cConstantes.SQL_ElimStockRef;
            vSql = vSql.Replace("[?Ref]", vRes);
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));

            foreach (DataRow dr in dt.Rows)
            {
                string vProd = dr["Producto"].ToString();
                string vCan = dr["canreg"].ToString();
                decimal vdCan = Convert.ToDecimal(vCan);
                string vUbi = dr["Ubi"].ToString();
                string vLote = dr["Lote"].ToString();
                string vOFL = dr["OFL"].ToString();
                try
                {
                    string vTipo = "Entrada";
                    if (vdCan < 0) vTipo = "Salida";
                    //Crear movimientos de producto y materia prima
                    cMovimientos.Articulo oMov = new cMovimientos.Articulo();

                    //Movimiento de producto
                    oMov.fncAlta(cParamXml.Emp, vTipo, DateTime.Now, DateTime.Now, cParamXml.AlmacenMat, vProd, "",
                                    vCan, "Inv_" + vID, vOFL, vUbi, vLote);

                }
                catch { }
            }

            frm.Close();

            MessageBox.Show("Se han eliminado todo el Stock del Producto:" + vRes);

        }

        private void stockPiezaTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cInformes.Imp = (cParamXml.Imp == "True") ? true : false;
            cInformes.sbrImpProductos("Total");

        }

        private void movimientosDeFabAUbiDeStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMoviProducStock frm = new frmMoviProducStock();
            frm.MdiParent = this;
            frm.Show();

        }

        private void mocimientosDeStockAProducToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMoviStockProduc frm = new frmMoviStockProduc();
            frm.MdiParent = this;
            frm.Show();

        }

        private void oFDatosExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInputDatosOF frmIm = new frmInputDatosOF();
            frmIm.ShowDialog();

            DateTime dtDesde = frmInputDatosOF.vdtDesde;
            DateTime dtHasta = frmInputDatosOF.vdtHasta;
            bool vCancel=frmInputDatosOF.vCancel;
            bool vTerMinada = frmInputDatosOF.vTerminadas;
            bool vAcabada = frmInputDatosOF.vAcabadas;
            bool vProducción = frmInputDatosOF.vProducción;
            bool vLanzada = frmInputDatosOF.vLanzadas;
            bool vPlanificada = frmInputDatosOF.vPlanificadas;
            string vFilTipo="";
            if (vTerMinada) vFilTipo += " and ((GC_OrdenProd.Estado = 'Terminada') ";
            if (vAcabada) vFilTipo += " or (GC_OrdenProd.Estado = 'Acabada') ";
            if (vProducción) vFilTipo += " or (GC_OrdenProd.Estado = 'Producción') ";
            if (vLanzada) vFilTipo += " or (GC_OrdenProd.Estado = 'Lanzada') ";
            if (vPlanificada) vFilTipo += " or (GC_OrdenProd.Estado = 'Planificada') ";
            vFilTipo += ")";
             
            if (!vCancel)
            {
                string vSql = cConstantes.SQL_OF_Terminada_Fecha;
                vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
                vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
                vSql = vSql.Replace("[?Emp]", cParamXml.Emp.ToString());
                vSql = vSql.Replace("[?DFecha]", dtDesde.ToShortDateString());
                vSql = vSql.Replace("[?HFecha]", dtHasta.ToShortDateString());
                vSql = vSql.Replace("[?fil]", vFilTipo);

                DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConec));

                sbrCreaExcel(dt, "Datos");

            }




        }

        private void descripciónDeProduToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string vMen = "Se actualizaran las descripciones (vacias) de la tabla de Anexos de producto,Esta seguro ?";
            string vTit = "Actualizar";
            if (MessageBox.Show(vMen, vTit, MessageBoxButtons.YesNo) == DialogResult.No)
            {

                return;
            }

            string vSql = cConstantes.SQL_Produc_Actu_Des;
            vSql = vSql.Replace("[?vbCr]", cConstantes.vbCtr.ToString());
            vSql = vSql.Replace("[?vbLf]", cConstantes.vbLF.ToString());
            DataTable dt = SQLDataAccess.Trae(vSql, cUtil.SQLConec(cParamXml.strConecProduc_Prueb));
            cProducto.Articulo oProd = new cProducto.Articulo();

            foreach (DataRow dr in dt.Rows )
            {
                string vProd = dr["Producto"].ToString();
                string vId = dr["Id"].ToString();
                string vWhere = " CREF = '" + vProd.Trim() + "' ";
                DataRow dr2;
                stalbProyecto.Text = "Actualizando Descripción de :" + vProd ;
                Application.DoEvents();

                dr2 = cUtil.fncTraeCampos("articulo", vWhere, cParamXml.strOleDBConecDbf, "DBF");
                if (dr2 != null)
                {
                    string vDes = dr2["cdetalle"].ToString();
                    oProd.Id = Convert.ToInt32(vId);
                    oProd.fncGrabaCampo("Descripción", vDes);

                }

            }

            stalbProyecto.Text = "Proyecto:";
            Application.DoEvents();
            MessageBox.Show("Termino");




        }
    }
}
