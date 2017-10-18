namespace GesInject.Formularios
{
    partial class frmTerminarOF
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
            this.opTodas = new System.Windows.Forms.RadioButton();
            this.opCompletas = new System.Windows.Forms.RadioButton();
            this.grOFL = new System.Windows.Forms.DataGridView();
            this.Sel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.btSelTot = new System.Windows.Forms.Button();
            this.btTerminar = new System.Windows.Forms.Button();
            this.btSalir = new System.Windows.Forms.Button();
            this.txOF = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grOFL)).BeginInit();
            this.SuspendLayout();
            // 
            // opTodas
            // 
            this.opTodas.AutoSize = true;
            this.opTodas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.opTodas.Checked = true;
            this.opTodas.Location = new System.Drawing.Point(344, 409);
            this.opTodas.Name = "opTodas";
            this.opTodas.Size = new System.Drawing.Size(55, 17);
            this.opTodas.TabIndex = 1;
            this.opTodas.TabStop = true;
            this.opTodas.Text = "Todas";
            this.opTodas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.opTodas.UseVisualStyleBackColor = true;
            this.opTodas.Visible = false;
            this.opTodas.CheckedChanged += new System.EventHandler(this.opTodas_CheckedChanged);
            // 
            // opCompletas
            // 
            this.opCompletas.AutoSize = true;
            this.opCompletas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.opCompletas.Location = new System.Drawing.Point(170, 404);
            this.opCompletas.Name = "opCompletas";
            this.opCompletas.Size = new System.Drawing.Size(98, 17);
            this.opCompletas.TabIndex = 2;
            this.opCompletas.Text = "Solo Completas";
            this.opCompletas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.opCompletas.UseVisualStyleBackColor = true;
            this.opCompletas.Visible = false;
            this.opCompletas.CheckedChanged += new System.EventHandler(this.opCompletas_CheckedChanged);
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
            this.grOFL.Location = new System.Drawing.Point(12, 27);
            this.grOFL.Name = "grOFL";
            this.grOFL.Size = new System.Drawing.Size(569, 336);
            this.grOFL.TabIndex = 43;
            this.grOFL.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grOFL_CellClick);
            this.grOFL.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grOFL_CellDoubleClick);
            // 
            // Sel
            // 
            this.Sel.HeaderText = "Sel";
            this.Sel.Name = "Sel";
            this.Sel.Visible = false;
            this.Sel.Width = 30;
            // 
            // btLimpiar
            // 
            this.btLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btLimpiar.Location = new System.Drawing.Point(364, 371);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(47, 23);
            this.btLimpiar.TabIndex = 54;
            this.btLimpiar.Text = "&Limpiar";
            this.btLimpiar.UseVisualStyleBackColor = false;
            this.btLimpiar.Visible = false;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // btSelTot
            // 
            this.btSelTot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btSelTot.Location = new System.Drawing.Point(311, 380);
            this.btSelTot.Name = "btSelTot";
            this.btSelTot.Size = new System.Drawing.Size(47, 23);
            this.btSelTot.TabIndex = 53;
            this.btSelTot.Text = "&Marcar Todo";
            this.btSelTot.UseVisualStyleBackColor = false;
            this.btSelTot.Visible = false;
            this.btSelTot.Click += new System.EventHandler(this.btSelTot_Click);
            // 
            // btTerminar
            // 
            this.btTerminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btTerminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btTerminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTerminar.Location = new System.Drawing.Point(12, 369);
            this.btTerminar.Name = "btTerminar";
            this.btTerminar.Size = new System.Drawing.Size(143, 52);
            this.btTerminar.TabIndex = 55;
            this.btTerminar.Text = "&Terminar";
            this.btTerminar.UseVisualStyleBackColor = false;
            this.btTerminar.Click += new System.EventHandler(this.btTerminar_Click);
            // 
            // btSalir
            // 
            this.btSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSalir.Location = new System.Drawing.Point(435, 371);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(146, 51);
            this.btSalir.TabIndex = 56;
            this.btSalir.Text = "Salir";
            this.btSalir.UseVisualStyleBackColor = true;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // txOF
            // 
            this.txOF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txOF.Location = new System.Drawing.Point(205, 383);
            this.txOF.Name = "txOF";
            this.txOF.Size = new System.Drawing.Size(100, 20);
            this.txOF.TabIndex = 57;
            this.txOF.Visible = false;
            // 
            // frmTerminarOF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 427);
            this.Controls.Add(this.txOF);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.btTerminar);
            this.Controls.Add(this.btLimpiar);
            this.Controls.Add(this.btSelTot);
            this.Controls.Add(this.grOFL);
            this.Controls.Add(this.opCompletas);
            this.Controls.Add(this.opTodas);
            this.Name = "frmTerminarOF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Terminar Orden de Fabricación";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTerminarOF_FormClosing);
            this.Load += new System.EventHandler(this.frmTerminarOF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grOFL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton opTodas;
        private System.Windows.Forms.RadioButton opCompletas;
        private System.Windows.Forms.DataGridView grOFL;
        private System.Windows.Forms.Button btLimpiar;
        private System.Windows.Forms.Button btSelTot;
        private System.Windows.Forms.Button btTerminar;
        private System.Windows.Forms.Button btSalir;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sel;
        private System.Windows.Forms.TextBox txOF;
    }
}