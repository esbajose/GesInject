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
    public partial class frmVisor : Form
    {
        public frmVisor()
        {
            InitializeComponent();
        }
        public static object orpt;
 
        private void frmVisor_Load(object sender, EventArgs e)
        {
            cR1.ReportSource = orpt;
        }
    }
}
