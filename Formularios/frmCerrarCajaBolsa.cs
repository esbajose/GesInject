using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using jControles.Formularios;
using GesInject.Clases;

namespace GesInject.Formularios
{
    public partial class frmCerrarCajaBolsa : Form
    {
        public static bool vCancel = false;
        public static bool vCaja = true;

        public static string vCanCaja = "0";
        public static string vCanBolsa = "0";
        public static string vCan = "0";
        public static string vOperario = "";
        public static string vTipoCierre = "";



        public frmCerrarCajaBolsa()
        {
            InitializeComponent();
        }

        private void frmCerrarCajaBolsa_Load(object sender, EventArgs e)
        {
            vCancel = true;
            txCan.ReadOnly = true;
            txCan.Enabled = false;

            if (vCanCaja == "0") opCaja.Visible = false;
            if (vCanBolsa == "0") opBolsa.Visible = false;

            if (vCan != "0") txCan.Text = vCan;

            if (vTipoCierre == "B")
            {
                opBolsa.Checked = true;
                opCaja.Checked = false;
            }

            if (opCaja.Checked) txCan.Text = vCanCaja;
            if (opBolsa.Checked) txCan.Text = vCanBolsa;
            lbOper.Text = vOperario;

            vCaja = true;

        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            vCancel = true;            
            this.Close();

        }
        private void btValidar_Click(object sender, EventArgs e)
        {

            vCan = txCan.Text;
            if (vCan == "") vCan = "0";
            
            if (vCan == "0")
            {
                MessageBox.Show("La Cantidad NO puede ser 0");
                return;
            }
            vCancel = false;
            if (opBolsa.Checked) vCaja = false;
            this.Close();

        }

        private void opCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (opCaja.Checked) txCan.Text = vCanCaja;
            if (opBolsa.Checked) txCan.Text = vCanBolsa;
        }

        private void opBolsa_CheckedChanged(object sender, EventArgs e)
        {
            if (opCaja.Checked) txCan.Text = vCanCaja;
            if (opBolsa.Checked) txCan.Text = vCanBolsa;
        }

        private void frmCerrarCajaBolsa_FormClosing(object sender, FormClosingEventArgs e)
        {
            vTipoCierre = "";
        }

        private void btCambiarCan_Click(object sender, EventArgs e)
        {
            if (fncSeguridad())
            {
                txCan.ReadOnly = false;
                txCan.Enabled = true;
            }
        }

        private bool fncSeguridad()
        {
            bool vOk = false;
            string vContra = cParamXml.PassCan;
            if (vContra == "") vContra = "joselito";
            if (vContra != "")
            {
                Form frm = new frmContraseña();
                frmContraseña.vContra = vContra;
                //frmContraseña.vOk = false;
                frm.ShowDialog();

                vOk = frmContraseña.vOk;
                
            }

            if (!vOk)
            {
                MessageBox.Show("contraseña Erronea");
            }

            return vOk;
        }


    }
}
