using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GesInject.Clases;


    public partial class frmInformacion : Form
    {
        public static string vTexto = "";
        public static int vTotReg = 0;
        public static int vNReg = 0;
        public static bool vCancel = false;

        public string vTex
        {
            set { vTexto  = value; }
        }

        public string vlbTex
        {
            set { vTexto = value; }
        }

        public frmInformacion()
        {
            InitializeComponent();
        }

        private void frmInformacion_Load(object sender, EventArgs e)
        {
            lbTexto.Text = vTexto;
        }

        private void PB1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                PB1.Maximum = vTotReg;
                PB1.Value = vNReg;
                lbTexto.Text = vTexto + " (" + vNReg.ToString() + "/" + vTotReg.ToString() + ")";
            }
            catch { }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            vCancel = true;
        }
    }
