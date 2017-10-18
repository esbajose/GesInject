namespace GesInject.Formularios
{
    partial class frmSelecciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelecciones));
            this.pSel1 = new System.Windows.Forms.Panel();
            this.lbdHasta = new System.Windows.Forms.Label();
            this.lbdDesde = new System.Windows.Forms.Label();
            this.btHasta = new System.Windows.Forms.Button();
            this.btDesde = new System.Windows.Forms.Button();
            this.txHasta = new System.Windows.Forms.TextBox();
            this.txDesde = new System.Windows.Forms.TextBox();
            this.lbHasta = new System.Windows.Forms.Label();
            this.lbDesde = new System.Windows.Forms.Label();
            this.pSelFec = new System.Windows.Forms.Panel();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btAcceptar = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.pSel2 = new System.Windows.Forms.Panel();
            this.lbdHasta2 = new System.Windows.Forms.Label();
            this.lbdDesde2 = new System.Windows.Forms.Label();
            this.btHasta2 = new System.Windows.Forms.Button();
            this.btDesde2 = new System.Windows.Forms.Button();
            this.txHasta2 = new System.Windows.Forms.TextBox();
            this.txDesde2 = new System.Windows.Forms.TextBox();
            this.lbHasta2 = new System.Windows.Forms.Label();
            this.lbDesde2 = new System.Windows.Forms.Label();
            this.pSel1.SuspendLayout();
            this.pSelFec.SuspendLayout();
            this.pSel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pSel1
            // 
            this.pSel1.Controls.Add(this.lbdHasta);
            this.pSel1.Controls.Add(this.lbdDesde);
            this.pSel1.Controls.Add(this.btHasta);
            this.pSel1.Controls.Add(this.btDesde);
            this.pSel1.Controls.Add(this.txHasta);
            this.pSel1.Controls.Add(this.txDesde);
            this.pSel1.Controls.Add(this.lbHasta);
            this.pSel1.Controls.Add(this.lbDesde);
            this.pSel1.Location = new System.Drawing.Point(12, 12);
            this.pSel1.Name = "pSel1";
            this.pSel1.Size = new System.Drawing.Size(518, 82);
            this.pSel1.TabIndex = 0;
            // 
            // lbdHasta
            // 
            this.lbdHasta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbdHasta.Location = new System.Drawing.Point(254, 47);
            this.lbdHasta.Name = "lbdHasta";
            this.lbdHasta.Size = new System.Drawing.Size(253, 23);
            this.lbdHasta.TabIndex = 69;
            // 
            // lbdDesde
            // 
            this.lbdDesde.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbdDesde.Location = new System.Drawing.Point(254, 9);
            this.lbdDesde.Name = "lbdDesde";
            this.lbdDesde.Size = new System.Drawing.Size(253, 23);
            this.lbdDesde.TabIndex = 68;
            // 
            // btHasta
            // 
            this.btHasta.Image = ((System.Drawing.Image)(resources.GetObject("btHasta.Image")));
            this.btHasta.Location = new System.Drawing.Point(215, 47);
            this.btHasta.Name = "btHasta";
            this.btHasta.Size = new System.Drawing.Size(33, 24);
            this.btHasta.TabIndex = 67;
            this.btHasta.UseVisualStyleBackColor = true;
            this.btHasta.Click += new System.EventHandler(this.btHasta_Click);
            // 
            // btDesde
            // 
            this.btDesde.Image = ((System.Drawing.Image)(resources.GetObject("btDesde.Image")));
            this.btDesde.Location = new System.Drawing.Point(215, 9);
            this.btDesde.Name = "btDesde";
            this.btDesde.Size = new System.Drawing.Size(33, 24);
            this.btDesde.TabIndex = 66;
            this.btDesde.UseVisualStyleBackColor = true;
            this.btDesde.Click += new System.EventHandler(this.btDesde_Click);
            // 
            // txHasta
            // 
            this.txHasta.Location = new System.Drawing.Point(127, 50);
            this.txHasta.Name = "txHasta";
            this.txHasta.Size = new System.Drawing.Size(87, 20);
            this.txHasta.TabIndex = 4;
            this.txHasta.TextChanged += new System.EventHandler(this.txHasta_TextChanged);
            // 
            // txDesde
            // 
            this.txDesde.Location = new System.Drawing.Point(127, 12);
            this.txDesde.Name = "txDesde";
            this.txDesde.Size = new System.Drawing.Size(87, 20);
            this.txDesde.TabIndex = 3;
            this.txDesde.TextChanged += new System.EventHandler(this.txDesde_TextChanged);
            // 
            // lbHasta
            // 
            this.lbHasta.AutoSize = true;
            this.lbHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHasta.Location = new System.Drawing.Point(3, 51);
            this.lbHasta.Name = "lbHasta";
            this.lbHasta.Size = new System.Drawing.Size(49, 16);
            this.lbHasta.TabIndex = 2;
            this.lbHasta.Text = "Hasta";
            // 
            // lbDesde
            // 
            this.lbDesde.AutoSize = true;
            this.lbDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDesde.Location = new System.Drawing.Point(3, 16);
            this.lbDesde.Name = "lbDesde";
            this.lbDesde.Size = new System.Drawing.Size(58, 16);
            this.lbDesde.TabIndex = 1;
            this.lbDesde.Text = "Desde ";
            // 
            // pSelFec
            // 
            this.pSelFec.Controls.Add(this.dtHasta);
            this.pSelFec.Controls.Add(this.label2);
            this.pSelFec.Controls.Add(this.dtDesde);
            this.pSelFec.Controls.Add(this.label1);
            this.pSelFec.Location = new System.Drawing.Point(12, 220);
            this.pSelFec.Name = "pSelFec";
            this.pSelFec.Size = new System.Drawing.Size(518, 49);
            this.pSelFec.TabIndex = 5;
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(389, 13);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(105, 20);
            this.dtHasta.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(270, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hasta la Fecha";
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(127, 13);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(105, 20);
            this.dtDesde.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Desde la Fecha";
            // 
            // btAcceptar
            // 
            this.btAcceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAcceptar.Location = new System.Drawing.Point(3, 300);
            this.btAcceptar.Name = "btAcceptar";
            this.btAcceptar.Size = new System.Drawing.Size(103, 31);
            this.btAcceptar.TabIndex = 7;
            this.btAcceptar.Text = "Aceptar";
            this.btAcceptar.UseVisualStyleBackColor = true;
            this.btAcceptar.Click += new System.EventHandler(this.btAcceptar_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(421, 300);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(103, 31);
            this.btCancel.TabIndex = 6;
            this.btCancel.Text = "Cancelar";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // pSel2
            // 
            this.pSel2.Controls.Add(this.lbdHasta2);
            this.pSel2.Controls.Add(this.lbdDesde2);
            this.pSel2.Controls.Add(this.btHasta2);
            this.pSel2.Controls.Add(this.btDesde2);
            this.pSel2.Controls.Add(this.txHasta2);
            this.pSel2.Controls.Add(this.txDesde2);
            this.pSel2.Controls.Add(this.lbHasta2);
            this.pSel2.Controls.Add(this.lbDesde2);
            this.pSel2.Location = new System.Drawing.Point(12, 115);
            this.pSel2.Name = "pSel2";
            this.pSel2.Size = new System.Drawing.Size(518, 82);
            this.pSel2.TabIndex = 8;
            // 
            // lbdHasta2
            // 
            this.lbdHasta2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbdHasta2.Location = new System.Drawing.Point(254, 47);
            this.lbdHasta2.Name = "lbdHasta2";
            this.lbdHasta2.Size = new System.Drawing.Size(253, 23);
            this.lbdHasta2.TabIndex = 69;
            // 
            // lbdDesde2
            // 
            this.lbdDesde2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbdDesde2.Location = new System.Drawing.Point(254, 9);
            this.lbdDesde2.Name = "lbdDesde2";
            this.lbdDesde2.Size = new System.Drawing.Size(253, 23);
            this.lbdDesde2.TabIndex = 68;
            // 
            // btHasta2
            // 
            this.btHasta2.Image = ((System.Drawing.Image)(resources.GetObject("btHasta2.Image")));
            this.btHasta2.Location = new System.Drawing.Point(215, 47);
            this.btHasta2.Name = "btHasta2";
            this.btHasta2.Size = new System.Drawing.Size(33, 24);
            this.btHasta2.TabIndex = 67;
            this.btHasta2.UseVisualStyleBackColor = true;
            this.btHasta2.Click += new System.EventHandler(this.btHasta2_Click);
            // 
            // btDesde2
            // 
            this.btDesde2.Image = ((System.Drawing.Image)(resources.GetObject("btDesde2.Image")));
            this.btDesde2.Location = new System.Drawing.Point(215, 9);
            this.btDesde2.Name = "btDesde2";
            this.btDesde2.Size = new System.Drawing.Size(33, 24);
            this.btDesde2.TabIndex = 66;
            this.btDesde2.UseVisualStyleBackColor = true;
            this.btDesde2.Click += new System.EventHandler(this.btDesde2_Click);
            // 
            // txHasta2
            // 
            this.txHasta2.Location = new System.Drawing.Point(127, 50);
            this.txHasta2.Name = "txHasta2";
            this.txHasta2.Size = new System.Drawing.Size(87, 20);
            this.txHasta2.TabIndex = 4;
            this.txHasta2.TextChanged += new System.EventHandler(this.txHasta2_TextChanged);
            // 
            // txDesde2
            // 
            this.txDesde2.Location = new System.Drawing.Point(127, 12);
            this.txDesde2.Name = "txDesde2";
            this.txDesde2.Size = new System.Drawing.Size(87, 20);
            this.txDesde2.TabIndex = 3;
            this.txDesde2.TextChanged += new System.EventHandler(this.txDesde2_TextChanged);
            // 
            // lbHasta2
            // 
            this.lbHasta2.AutoSize = true;
            this.lbHasta2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHasta2.Location = new System.Drawing.Point(3, 51);
            this.lbHasta2.Name = "lbHasta2";
            this.lbHasta2.Size = new System.Drawing.Size(49, 16);
            this.lbHasta2.TabIndex = 2;
            this.lbHasta2.Text = "Hasta";
            // 
            // lbDesde2
            // 
            this.lbDesde2.AutoSize = true;
            this.lbDesde2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDesde2.Location = new System.Drawing.Point(3, 16);
            this.lbDesde2.Name = "lbDesde2";
            this.lbDesde2.Size = new System.Drawing.Size(58, 16);
            this.lbDesde2.TabIndex = 1;
            this.lbDesde2.Text = "Desde ";
            // 
            // frmSelecciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 343);
            this.Controls.Add(this.pSel2);
            this.Controls.Add(this.btAcceptar);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.pSelFec);
            this.Controls.Add(this.pSel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSelecciones";
            this.Text = "Selecciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSelecciones_FormClosing);
            this.Load += new System.EventHandler(this.frmSelecciones_Load);
            this.pSel1.ResumeLayout(false);
            this.pSel1.PerformLayout();
            this.pSelFec.ResumeLayout(false);
            this.pSelFec.PerformLayout();
            this.pSel2.ResumeLayout(false);
            this.pSel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pSel1;
        private System.Windows.Forms.TextBox txHasta;
        private System.Windows.Forms.TextBox txDesde;
        private System.Windows.Forms.Label lbHasta;
        private System.Windows.Forms.Label lbDesde;
        private System.Windows.Forms.Panel pSelFec;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btDesde;
        private System.Windows.Forms.Label lbdDesde;
        private System.Windows.Forms.Button btHasta;
        private System.Windows.Forms.Label lbdHasta;
        private System.Windows.Forms.Button btAcceptar;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Panel pSel2;
        private System.Windows.Forms.Label lbdHasta2;
        private System.Windows.Forms.Label lbdDesde2;
        private System.Windows.Forms.Button btHasta2;
        private System.Windows.Forms.Button btDesde2;
        private System.Windows.Forms.TextBox txHasta2;
        private System.Windows.Forms.TextBox txDesde2;
        private System.Windows.Forms.Label lbHasta2;
        private System.Windows.Forms.Label lbDesde2;
    }
}