namespace GesInject.Formularios
{
    partial class frmIniProd
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txOper = new System.Windows.Forms.TextBox();
            this.btOper = new System.Windows.Forms.Button();
            this.lbOper = new System.Windows.Forms.Label();
            this.txMaq = new System.Windows.Forms.TextBox();
            this.btMaq = new System.Windows.Forms.Button();
            this.lbMaq = new System.Windows.Forms.Label();
            this.btIni = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.panelOper = new System.Windows.Forms.Panel();
            this.panelMaq = new System.Windows.Forms.Panel();
            this.panelOper.SuspendLayout();
            this.panelMaq.SuspendLayout();
            this.SuspendLayout();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Maquina";
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
            // lbOper
            // 
            this.lbOper.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbOper.Location = new System.Drawing.Point(226, 17);
            this.lbOper.Name = "lbOper";
            this.lbOper.Size = new System.Drawing.Size(296, 23);
            this.lbOper.TabIndex = 4;
            // 
            // txMaq
            // 
            this.txMaq.Location = new System.Drawing.Point(86, 13);
            this.txMaq.Name = "txMaq";
            this.txMaq.Size = new System.Drawing.Size(48, 20);
            this.txMaq.TabIndex = 5;
            this.txMaq.TextChanged += new System.EventHandler(this.txMaq_TextChanged);
            // 
            // btMaq
            // 
            this.btMaq.Location = new System.Drawing.Point(143, 10);
            this.btMaq.Name = "btMaq";
            this.btMaq.Size = new System.Drawing.Size(82, 23);
            this.btMaq.TabIndex = 6;
            this.btMaq.Text = "Maquina (F6)";
            this.btMaq.UseVisualStyleBackColor = true;
            this.btMaq.Click += new System.EventHandler(this.btMaq_Click);
            // 
            // lbMaq
            // 
            this.lbMaq.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbMaq.Location = new System.Drawing.Point(231, 10);
            this.lbMaq.Name = "lbMaq";
            this.lbMaq.Size = new System.Drawing.Size(296, 23);
            this.lbMaq.TabIndex = 7;
            // 
            // btIni
            // 
            this.btIni.BackColor = System.Drawing.Color.LightGreen;
            this.btIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIni.Location = new System.Drawing.Point(12, 144);
            this.btIni.Name = "btIni";
            this.btIni.Size = new System.Drawing.Size(161, 78);
            this.btIni.TabIndex = 8;
            this.btIni.Text = "&Iniciar";
            this.btIni.UseVisualStyleBackColor = false;
            this.btIni.Click += new System.EventHandler(this.btIni_Click);
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.Location = new System.Drawing.Point(369, 144);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(161, 78);
            this.btCancel.TabIndex = 9;
            this.btCancel.Text = "&Cancelar";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // panelOper
            // 
            this.panelOper.Controls.Add(this.lbOper);
            this.panelOper.Controls.Add(this.label1);
            this.panelOper.Controls.Add(this.txOper);
            this.panelOper.Controls.Add(this.btOper);
            this.panelOper.Location = new System.Drawing.Point(12, 12);
            this.panelOper.Name = "panelOper";
            this.panelOper.Size = new System.Drawing.Size(527, 59);
            this.panelOper.TabIndex = 10;
            // 
            // panelMaq
            // 
            this.panelMaq.Controls.Add(this.lbMaq);
            this.panelMaq.Controls.Add(this.label2);
            this.panelMaq.Controls.Add(this.txMaq);
            this.panelMaq.Controls.Add(this.btMaq);
            this.panelMaq.Location = new System.Drawing.Point(12, 77);
            this.panelMaq.Name = "panelMaq";
            this.panelMaq.Size = new System.Drawing.Size(536, 42);
            this.panelMaq.TabIndex = 11;
            // 
            // frmIniProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 230);
            this.ControlBox = false;
            this.Controls.Add(this.panelMaq);
            this.Controls.Add(this.panelOper);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btIni);
            this.KeyPreview = true;
            this.Name = "frmIniProd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de Producción";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIniProd_FormClosing);
            this.Load += new System.EventHandler(this.frmIniProd_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmIniProd_KeyUp);
            this.panelOper.ResumeLayout(false);
            this.panelOper.PerformLayout();
            this.panelMaq.ResumeLayout(false);
            this.panelMaq.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txOper;
        private System.Windows.Forms.Button btOper;
        private System.Windows.Forms.Label lbOper;
        private System.Windows.Forms.TextBox txMaq;
        private System.Windows.Forms.Button btMaq;
        private System.Windows.Forms.Label lbMaq;
        private System.Windows.Forms.Button btIni;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Panel panelOper;
        private System.Windows.Forms.Panel panelMaq;
    }
}