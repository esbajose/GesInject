namespace GesInject.Formularios
{
    partial class frmLanzarOFL
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
            this.grOFL = new System.Windows.Forms.DataGridView();
            this.Sel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btDesSelTot = new System.Windows.Forms.Button();
            this.btSelTot = new System.Windows.Forms.Button();
            this.btProcesar = new System.Windows.Forms.Button();
            this.btLanzar = new System.Windows.Forms.Button();
            this.grMat = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btOFL = new System.Windows.Forms.Button();
            this.btAnex2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btAnex = new System.Windows.Forms.Button();
            this.btEntraStock = new System.Windows.Forms.Button();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grOFL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grMat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grOFL
            // 
            this.grOFL.AllowUserToAddRows = false;
            this.grOFL.AllowUserToDeleteRows = false;
            this.grOFL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grOFL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grOFL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sel});
            this.grOFL.Location = new System.Drawing.Point(3, 45);
            this.grOFL.Name = "grOFL";
            this.grOFL.Size = new System.Drawing.Size(493, 345);
            this.grOFL.TabIndex = 42;
            // 
            // Sel
            // 
            this.Sel.HeaderText = "Sel";
            this.Sel.Name = "Sel";
            this.Sel.Width = 30;
            // 
            // btDesSelTot
            // 
            this.btDesSelTot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btDesSelTot.Location = new System.Drawing.Point(420, 12);
            this.btDesSelTot.Name = "btDesSelTot";
            this.btDesSelTot.Size = new System.Drawing.Size(45, 23);
            this.btDesSelTot.TabIndex = 47;
            this.btDesSelTot.Text = "&Desmarcar Todo";
            this.btDesSelTot.UseVisualStyleBackColor = false;
            this.btDesSelTot.Visible = false;
            this.btDesSelTot.Click += new System.EventHandler(this.btDesSelTot_Click);
            // 
            // btSelTot
            // 
            this.btSelTot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btSelTot.Location = new System.Drawing.Point(15, 12);
            this.btSelTot.Name = "btSelTot";
            this.btSelTot.Size = new System.Drawing.Size(99, 34);
            this.btSelTot.TabIndex = 46;
            this.btSelTot.Text = "&Marcar Todo";
            this.btSelTot.UseVisualStyleBackColor = false;
            this.btSelTot.Click += new System.EventHandler(this.btSelTot_Click);
            // 
            // btProcesar
            // 
            this.btProcesar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btProcesar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btProcesar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btProcesar.Location = new System.Drawing.Point(3, 405);
            this.btProcesar.Name = "btProcesar";
            this.btProcesar.Size = new System.Drawing.Size(143, 52);
            this.btProcesar.TabIndex = 48;
            this.btProcesar.Text = "&Procesar";
            this.btProcesar.UseVisualStyleBackColor = false;
            this.btProcesar.Click += new System.EventHandler(this.btProcesar_Click);
            // 
            // btLanzar
            // 
            this.btLanzar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btLanzar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btLanzar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLanzar.Location = new System.Drawing.Point(353, 405);
            this.btLanzar.Name = "btLanzar";
            this.btLanzar.Size = new System.Drawing.Size(143, 52);
            this.btLanzar.TabIndex = 49;
            this.btLanzar.Text = "Lanzar";
            this.btLanzar.UseVisualStyleBackColor = false;
            this.btLanzar.Visible = false;
            this.btLanzar.Click += new System.EventHandler(this.btLanzar_Click);
            // 
            // grMat
            // 
            this.grMat.AllowUserToAddRows = false;
            this.grMat.AllowUserToDeleteRows = false;
            this.grMat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grMat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grMat.Location = new System.Drawing.Point(3, 24);
            this.grMat.Name = "grMat";
            this.grMat.ReadOnly = true;
            this.grMat.Size = new System.Drawing.Size(310, 366);
            this.grMat.TabIndex = 50;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer1.Location = new System.Drawing.Point(12, 52);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.btOFL);
            this.splitContainer1.Panel1.Controls.Add(this.btAnex2);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.grOFL);
            this.splitContainer1.Panel1.Controls.Add(this.btProcesar);
            this.splitContainer1.Panel1.Controls.Add(this.btLanzar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.btAnex);
            this.splitContainer1.Panel2.Controls.Add(this.btEntraStock);
            this.splitContainer1.Panel2.Controls.Add(this.grMat);
            this.splitContainer1.Size = new System.Drawing.Size(819, 460);
            this.splitContainer1.SplitterDistance = 499;
            this.splitContainer1.TabIndex = 51;
            // 
            // btOFL
            // 
            this.btOFL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btOFL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btOFL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOFL.Location = new System.Drawing.Point(229, 405);
            this.btOFL.Name = "btOFL";
            this.btOFL.Size = new System.Drawing.Size(59, 51);
            this.btOFL.TabIndex = 54;
            this.btOFL.Text = "OFL";
            this.btOFL.UseVisualStyleBackColor = false;
            this.btOFL.Click += new System.EventHandler(this.btOFL_Click);
            // 
            // btAnex2
            // 
            this.btAnex2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAnex2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btAnex2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAnex2.Location = new System.Drawing.Point(152, 405);
            this.btAnex2.Name = "btAnex2";
            this.btAnex2.Size = new System.Drawing.Size(59, 51);
            this.btAnex2.TabIndex = 53;
            this.btAnex2.Text = "Anexo Prod";
            this.btAnex2.UseVisualStyleBackColor = false;
            this.btAnex2.Click += new System.EventHandler(this.btAnex2_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Green;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(425, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 42);
            this.label3.TabIndex = 52;
            this.label3.Text = "Se puede Lanzar";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Brown;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(108, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 42);
            this.label2.TabIndex = 51;
            this.label2.Text = "Falta informar Peso";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 42);
            this.label1.TabIndex = 50;
            this.label1.Text = "Estock insuficiente";
            // 
            // btAnex
            // 
            this.btAnex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAnex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btAnex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAnex.Location = new System.Drawing.Point(3, 405);
            this.btAnex.Name = "btAnex";
            this.btAnex.Size = new System.Drawing.Size(59, 52);
            this.btAnex.TabIndex = 52;
            this.btAnex.Text = "Anexo Prod";
            this.btAnex.UseVisualStyleBackColor = false;
            this.btAnex.Click += new System.EventHandler(this.btAnex_Click);
            // 
            // btEntraStock
            // 
            this.btEntraStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEntraStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btEntraStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEntraStock.Location = new System.Drawing.Point(244, 405);
            this.btEntraStock.Name = "btEntraStock";
            this.btEntraStock.Size = new System.Drawing.Size(62, 51);
            this.btEntraStock.TabIndex = 51;
            this.btEntraStock.Text = "Entrar Stock";
            this.btEntraStock.UseVisualStyleBackColor = false;
            this.btEntraStock.Click += new System.EventHandler(this.btEntraStock_Click);
            // 
            // btLimpiar
            // 
            this.btLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btLimpiar.Location = new System.Drawing.Point(177, 12);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(99, 34);
            this.btLimpiar.TabIndex = 52;
            this.btLimpiar.Text = "&Limpiar";
            this.btLimpiar.UseVisualStyleBackColor = false;
            this.btLimpiar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(207, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 42);
            this.label4.TabIndex = 55;
            this.label4.Text = "Faltan informar Piezas Bolsa";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Aqua;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(316, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 42);
            this.label5.TabIndex = 56;
            this.label5.Text = "Faltan informar Piezas Caja";
            // 
            // frmLanzarOFL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 520);
            this.Controls.Add(this.btLimpiar);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btDesSelTot);
            this.Controls.Add(this.btSelTot);
            this.Name = "frmLanzarOFL";
            this.Text = "Lanzar Ordenes de Producción";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLanzarOFL_FormClosing);
            this.Load += new System.EventHandler(this.frmLanzarOFL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grOFL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grMat)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grOFL;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sel;
        private System.Windows.Forms.Button btDesSelTot;
        private System.Windows.Forms.Button btSelTot;
        private System.Windows.Forms.Button btProcesar;
        private System.Windows.Forms.Button btLanzar;
        private System.Windows.Forms.DataGridView grMat;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btLimpiar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btEntraStock;
        private System.Windows.Forms.Button btAnex;
        private System.Windows.Forms.Button btAnex2;
        private System.Windows.Forms.Button btOFL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}