namespace GesInject.Formularios
{
    partial class frmFinJornada
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelOper = new System.Windows.Forms.Panel();
            this.lbOper = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txOper = new System.Windows.Forms.TextBox();
            this.btOper = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btIni = new System.Windows.Forms.Button();
            this.panelOper.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOper
            // 
            this.panelOper.Controls.Add(this.lbOper);
            this.panelOper.Controls.Add(this.label1);
            this.panelOper.Controls.Add(this.txOper);
            this.panelOper.Controls.Add(this.btOper);
            this.panelOper.Location = new System.Drawing.Point(12, 26);
            this.panelOper.Name = "panelOper";
            this.panelOper.Size = new System.Drawing.Size(527, 59);
            this.panelOper.TabIndex = 11;
            // 
            // lbOper
            // 
            this.lbOper.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbOper.Location = new System.Drawing.Point(226, 17);
            this.lbOper.Name = "lbOper";
            this.lbOper.Size = new System.Drawing.Size(296, 23);
            this.lbOper.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Operario";
            // 
            // txOper
            // 
            this.txOper.Location = new System.Drawing.Point(84, 15);
            this.txOper.Name = "txOper";
            this.txOper.Size = new System.Drawing.Size(48, 20);
            this.txOper.TabIndex = 2;
            this.txOper.TextChanged += new System.EventHandler(this.txOper_TextChanged);
            // 
            // btOper
            // 
            this.btOper.Location = new System.Drawing.Point(138, 16);
            this.btOper.Name = "btOper";
            this.btOper.Size = new System.Drawing.Size(82, 23);
            this.btOper.TabIndex = 3;
            this.btOper.Text = "Operario (F5)";
            this.btOper.UseVisualStyleBackColor = true;
            this.btOper.Click += new System.EventHandler(this.btOper_Click);
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.Location = new System.Drawing.Point(378, 162);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(161, 78);
            this.btCancel.TabIndex = 13;
            this.btCancel.Text = "&Cancelar";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btIni
            // 
            this.btIni.BackColor = System.Drawing.Color.LightGreen;
            this.btIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIni.Location = new System.Drawing.Point(12, 162);
            this.btIni.Name = "btIni";
            this.btIni.Size = new System.Drawing.Size(200, 78);
            this.btIni.TabIndex = 12;
            this.btIni.Text = "&Finalizar Jornada";
            this.btIni.UseVisualStyleBackColor = false;
            this.btIni.Click += new System.EventHandler(this.btIni_Click);
            // 
            // frmFinJornada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 261);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btIni);
            this.Controls.Add(this.panelOper);
            this.KeyPreview = true;
            this.Name = "frmFinJornada";
            this.Text = "Fin de Jornada";
            this.Load += new System.EventHandler(this.frmFinJornada_Load);
            this.Shown += new System.EventHandler(this.frmFinJornada_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmFinJornada_KeyUp);
            this.panelOper.ResumeLayout(false);
            this.panelOper.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelOper;
        private System.Windows.Forms.Label lbOper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txOper;
        private System.Windows.Forms.Button btOper;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btIni;
    }
}