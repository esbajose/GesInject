using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GesInject.Formularios
{
    public partial class frmInputDatosOF : Form
    {

        public static bool vDesde = true;
        public static bool vHasta = true;
        public static bool vFec = false;
        public static bool vCancel = false;
        public static string vsDesde = "Desde la Fecha";
        public static string vsHasta = "Hasta la Fecha";
        public static bool vTerminadas = false;
        public static bool vAcabadas = false;
        public static bool vProducción = false;
        public static bool vLanzadas = false;
        public static bool vPlanificadas = false;

        public static DateTime vdtDesde;
        public static DateTime vdtHasta;

        public frmInputDatosOF()
        {
            InitializeComponent();
        }

        private void frmInputDatosOF_Load(object sender, EventArgs e)
        {
            Width = 460;
            lbDesde.Text = vsDesde;
            lbHasta.Text = vsHasta;
            if (vFec)
            {
                this.Width = 250;
                vDesde = false;
                vHasta = false;

            }
            
            if (vDesde)
            {
                this.Width = 250;
            }
            if (vHasta)
            {
                Width = 460;
            }

        }

        private void frmInputDatosOF_FormClosing(object sender, FormClosingEventArgs e)
        {
            vdtDesde = dtDesde.Value;
            vdtHasta = dtHasta.Value;

            vTerminadas = chTerminadas.Checked;
            vAcabadas = chAcabadas.Checked;
            vProducción = chProducción.Checked;
            vLanzadas = chLanzadas.Checked;
            vPlanificadas = chPlanificadas.Checked;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            vCancel = true;
            this.Close();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            vCancel = false;
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
        }

        private void btMes_Click(object sender, EventArgs e)
        {
            DateTime vFecha = dtDesde.Value;
            DateTime vMesSig = vFecha.AddMonths(1);
            int vMes = vMesSig.Month;
            DateTime vFechaSig = Convert.ToDateTime("01/" + vMes.ToString() + "/" + vMesSig.Year.ToString());
            DateTime vFechaIni = Convert.ToDateTime("01/" + vFecha.Month.ToString() + "/" + vFecha.Year.ToString());
            dtDesde.Value = vFechaIni;
            dtHasta.Value = vFechaSig.AddDays(-1);


        }

        private void btSemana_Click(object sender, EventArgs e)
        {

            int vDiasem = (int)dtDesde.Value.DayOfWeek;

            if (vDiasem == 0) { vDiasem = 7; }

            int vDesp = (7 - vDiasem);
            dtHasta.Value = dtDesde.Value.AddDays(vDesp);
            
            vDesp = (6 - (7 - vDiasem)) * -1;
            dtDesde.Value = dtDesde.Value.AddDays(vDesp);

            

        }
    }
}
