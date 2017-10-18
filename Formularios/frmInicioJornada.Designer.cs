namespace GesInject.Formularios
{
    partial class frmInicioJornada
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
            this.btCancel = new System.Windows.Forms.Button();
            this.btIni = new System.Windows.Forms.Button();
            this.panelOper = new System.Windows.Forms.Panel();
            this.lbOper = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txOper = new System.Windows.Forms.TextBox();
            this.btOper = new System.Windows.Forms.Button();
            this.grMaq = new System.Windows.Forms.DataGridView();
            this.grupoMaq = new System.Windows.Forms.GroupBox();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.btSelTot = new System.Windows.Forms.Button();
            this.Sel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelOper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grMaq)).BeginInit();
            this.grupoMaq.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.Location = new System.Drawing.Point(477, 484);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(161, 78);
            this.btCancel.TabIndex = 16;
            this.btCancel.Text = "&Cancelar";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btIni
            // 
            this.btIni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btIni.BackColor = System.Drawing.Color.LightGreen;
            this.btIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIni.Location = new System.Drawing.Point(12, 484);
            this.btIni.Name = "btIni";
            this.btIni.Size = new System.Drawing.Size(200, 78);
            this.btIni.TabIndex = 15;
            this.btIni.Text = "&Iniciar Jornada";
            this.btIni.UseVisualStyleBackColor = false;
            this.btIni.Click += new System.EventHandler(this.btIni_Click);
            // 
            // panelOper
            // 
            this.panelOper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOper.Controls.Add(this.lbOper);
            this.panelOper.Controls.Add(this.label1);
            this.panelOper.Controls.Add(this.txOper);
            this.panelOper.Controls.Add(this.btOper);
            this.panelOper.Location = new System.Drawing.Point(12, 22);
            this.panelOper.Name = "panelOper";
            this.panelOper.Size = new System.Drawing.Size(631, 59);
            this.panelOper.TabIndex = 14;
            // 
            // lbOper
            // 
            this.lbOper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOper.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbOper.Location = new System.Drawing.Point(226, 17);
            this.lbOper.Name = "lbOper";
            this.lbOper.Size = new System.Drawing.Size(400, 23);
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
            // grMaq
            // 
            this.grMaq.AllowUserToAddRows = false;
            this.grMaq.AllowUserToDeleteRows = false;
            this.grMaq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grMaq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grMaq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sel});
            this.grMaq.Location = new System.Drawing.Point(6, 69);
            this.grMaq.Name = "grMaq";
            this.grMaq.Size = new System.Drawing.Size(609, 297);
            this.grMaq.TabIndex = 43;
            // 
            // grupoMaq
            // 
            this.grupoMaq.Controls.Add(this.btLimpiar);
            this.grupoMaq.Controls.Add(this.btSelTot);
            this.grupoMaq.Controls.Add(this.grMaq);
            this.grupoMaq.Enabled = false;
            this.grupoMaq.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupoMaq.Location = new System.Drawing.Point(12, 97);
            this.grupoMaq.Name = "grupoMaq";
            this.grupoMaq.Size = new System.Drawing.Size(631, 372);
            this.grupoMaq.TabIndex = 44;
            this.grupoMaq.TabStop = false;
            this.grupoMaq.Text = "Máquinas en producción";
            // 
            // btLimpiar
            // 
            this.btLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btLimpiar.Location = new System.Drawing.Point(188, 23);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(145, 40);
            this.btLimpiar.TabIndex = 54;
            this.btLimpiar.Text = "&Desmarcar todo";
            this.btLimpiar.UseVisualStyleBackColor = false;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // btSelTot
            // 
            this.btSelTot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btSelTot.Location = new System.Drawing.Point(7, 23);
            this.btSelTot.Name = "btSelTot";
            this.btSelTot.Size = new System.Drawing.Size(145, 40);
            this.btSelTot.TabIndex = 53;
            this.btSelTot.Text = "&Marcar todo";
            this.btSelTot.UseVisualStyleBackColor = false;
            this.btSelTot.Click += new System.EventHandler(this.btSelTot_Click);
            // 
            // Sel
            // 
            this.Sel.DataPropertyName = "Sel";
            this.Sel.HeaderText = "Sel";
            this.Sel.Name = "Sel";
            this.Sel.Width = 50;
            // 
            // frmInicioJornada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 584);
            this.Controls.Add(this.grupoMaq);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btIni);
            this.Controls.Add(this.panelOper);
            this.KeyPreview = true;
            this.Name = "frmInicioJornada";
            this.Text = "Inicio de Jornada";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInicioJornada_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmInicioJornada_KeyUp);
            this.panelOper.ResumeLayout(false);
            this.panelOper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grMaq)).EndInit();
            this.grupoMaq.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btIni;
        private System.Windows.Forms.Panel panelOper;
        private System.Windows.Forms.Label lbOper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txOper;
        private System.Windows.Forms.Button btOper;
        private System.Windows.Forms.DataGridView grMaq;
        private System.Windows.Forms.GroupBox grupoMaq;
        private System.Windows.Forms.Button btLimpiar;
        private System.Windows.Forms.Button btSelTot;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sel;
    }
}