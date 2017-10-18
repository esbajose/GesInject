using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GesInject.Clases;
using GesInject.Datasets;
using jControles.Clases;

namespace GesInject.Formularios
{
    public partial class frmTextoLibre : Form
    {
        public frmTextoLibre()
        {
            InitializeComponent();
        }


        #region Procesos locales

        private void sbrCreaLineas()
        {
            int vTop = 20;
            panelAct.Controls.Clear();
            for (int i=1;i<nuLineas.Value+1;i++)
            {
                Label lbc = new Label();
                lbc.AutoSize = false;
                //lbc.Height = 19;
                lbc.Text = "Linea " + i.ToString();
                lbc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbc.Name = "lbc" + i.ToString();
                lbc.Top = vTop;
                lbc.Left = 3;
                panelAct.Controls.Add(lbc);
                Application.DoEvents();

                vTop += 25;
                TextBox txt = new TextBox();
                txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txt.Top = vTop;
                txt.Name = "textBox" + i.ToString();
                txt.Size = new System.Drawing.Size(437, 26);
                txt.TabIndex = 1;
                panelAct.Controls.Add(txt);
                Application.DoEvents();

                vTop += 40;


            }


        }
        #endregion
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            sbrCreaLineas();
        }

        private void frmTextoLibre_Load(object sender, EventArgs e)
        {
            sbrCreaLineas();
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            foreach (Control obj in panelAct.Controls)
            {
                string vTipo = obj.GetType().ToString();
                if (vTipo == "System.Windows.Forms.TextBox") obj.Text = "";
                if (vTipo == "System.Windows.Forms.PictureBox") ((System.Windows.Forms.PictureBox)obj).Image = null;
                if (vTipo == "System.Windows.Forms.DateTimePicker") ((System.Windows.Forms.DateTimePicker)obj).Value = DateTime.Now;

            }
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
 
            string[] vLineas = new string[Convert.ToInt16(nuLineas.Value)];

            for (int i = 0; i < nuLineas.Value; i++)
            {
                foreach (Control ctl in panelAct.Controls)
                {
                    if (ctl.Name == "textBox" + (i + 1).ToString())
                    {
                        vLineas[i] = ctl.Text;
                    }
                }
            }


            cInformes.Imp = (cParamXml.Imp == "True") ? true : false;

            cInformes.sbrEtiTextoLibre(Convert.ToInt16(nuLineas.Value), vLineas, chLogo.Checked, chCentra.Checked);

        }
    }
}
