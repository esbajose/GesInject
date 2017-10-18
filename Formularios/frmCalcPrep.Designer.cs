namespace GesInject.Formularios
{
    partial class frmCalcPrep
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewRow dataGridViewRow1 = new System.Windows.Forms.DataGridViewRow();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.btSelTot = new System.Windows.Forms.Button();
            this.grPrep2 = new System.Windows.Forms.DataGridView();
            this.Sel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.upPrio = new System.Windows.Forms.NumericUpDown();
            this.btCambiar = new System.Windows.Forms.Button();
            this.txID = new System.Windows.Forms.TextBox();
            this.txPrio = new System.Windows.Forms.TextBox();
            this.btProcesar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btCrear = new System.Windows.Forms.Button();
            this.grMat = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grPrep = new jControles.jDataGridView();
            this.btOFL = new System.Windows.Forms.Button();
            this.btActu = new System.Windows.Forms.Button();
            this.btMarcSel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grPrep2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upPrio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grMat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btLimpiar
            // 
            this.btLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btLimpiar.Location = new System.Drawing.Point(278, 12);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(99, 34);
            this.btLimpiar.TabIndex = 54;
            this.btLimpiar.Text = "&Limpiar";
            this.btLimpiar.UseVisualStyleBackColor = false;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // btSelTot
            // 
            this.btSelTot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btSelTot.Location = new System.Drawing.Point(3, 12);
            this.btSelTot.Name = "btSelTot";
            this.btSelTot.Size = new System.Drawing.Size(99, 34);
            this.btSelTot.TabIndex = 53;
            this.btSelTot.Text = "&Marcar Todo";
            this.btSelTot.UseVisualStyleBackColor = false;
            this.btSelTot.Click += new System.EventHandler(this.btSelTot_Click);
            // 
            // grPrep2
            // 
            this.grPrep2.AllowUserToAddRows = false;
            this.grPrep2.AllowUserToDeleteRows = false;
            this.grPrep2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grPrep2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grPrep2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sel});
            this.grPrep2.Location = new System.Drawing.Point(133, 395);
            this.grPrep2.Name = "grPrep2";
            this.grPrep2.Size = new System.Drawing.Size(127, 32);
            this.grPrep2.TabIndex = 55;
            this.grPrep2.Visible = false;
            this.grPrep2.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.grPrep_CellValidated);
            this.grPrep2.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grPrep_RowEnter);
            // 
            // Sel
            // 
            this.Sel.DataPropertyName = "Sel";
            this.Sel.HeaderText = "Sel";
            this.Sel.Name = "Sel";
            this.Sel.Width = 50;
            // 
            // upPrio
            // 
            this.upPrio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.upPrio.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upPrio.Location = new System.Drawing.Point(563, 551);
            this.upPrio.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.upPrio.Name = "upPrio";
            this.upPrio.Size = new System.Drawing.Size(117, 40);
            this.upPrio.TabIndex = 56;
            this.upPrio.Visible = false;
            // 
            // btCambiar
            // 
            this.btCambiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCambiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCambiar.Location = new System.Drawing.Point(814, 558);
            this.btCambiar.Name = "btCambiar";
            this.btCambiar.Size = new System.Drawing.Size(105, 33);
            this.btCambiar.TabIndex = 58;
            this.btCambiar.Text = "Cambiar prioridad";
            this.btCambiar.UseVisualStyleBackColor = true;
            this.btCambiar.Visible = false;
            this.btCambiar.Click += new System.EventHandler(this.btCambiar_Click);
            // 
            // txID
            // 
            this.txID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txID.Location = new System.Drawing.Point(165, 526);
            this.txID.Name = "txID";
            this.txID.Size = new System.Drawing.Size(67, 20);
            this.txID.TabIndex = 59;
            this.txID.Visible = false;
            // 
            // txPrio
            // 
            this.txPrio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txPrio.Location = new System.Drawing.Point(165, 567);
            this.txPrio.Name = "txPrio";
            this.txPrio.Size = new System.Drawing.Size(67, 20);
            this.txPrio.TabIndex = 60;
            this.txPrio.Visible = false;
            // 
            // btProcesar
            // 
            this.btProcesar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btProcesar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btProcesar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btProcesar.Location = new System.Drawing.Point(3, 540);
            this.btProcesar.Name = "btProcesar";
            this.btProcesar.Size = new System.Drawing.Size(143, 52);
            this.btProcesar.TabIndex = 61;
            this.btProcesar.Text = "&Procesar";
            this.btProcesar.UseVisualStyleBackColor = false;
            this.btProcesar.Click += new System.EventHandler(this.btProcesar_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Green;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(553, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 42);
            this.label3.TabIndex = 63;
            this.label3.Text = "Se puede Preparar";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(431, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 42);
            this.label1.TabIndex = 62;
            this.label1.Text = "Estock insuficiente";
            // 
            // btCrear
            // 
            this.btCrear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCrear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCrear.Location = new System.Drawing.Point(296, 540);
            this.btCrear.Name = "btCrear";
            this.btCrear.Size = new System.Drawing.Size(143, 52);
            this.btCrear.TabIndex = 64;
            this.btCrear.Text = "&Crer Preparación";
            this.btCrear.UseVisualStyleBackColor = false;
            this.btCrear.Visible = false;
            this.btCrear.Click += new System.EventHandler(this.btCrear_Click);
            // 
            // grMat
            // 
            this.grMat.AllowUserToAddRows = false;
            this.grMat.AllowUserToDeleteRows = false;
            this.grMat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grMat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grMat.Location = new System.Drawing.Point(3, 3);
            this.grMat.Name = "grMat";
            this.grMat.ReadOnly = true;
            this.grMat.Size = new System.Drawing.Size(278, 377);
            this.grMat.TabIndex = 65;
            this.grMat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grMat_CellContentClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 62);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grPrep);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btOFL);
            this.splitContainer1.Panel2.Controls.Add(this.grPrep2);
            this.splitContainer1.Panel2.Controls.Add(this.grMat);
            this.splitContainer1.Size = new System.Drawing.Size(919, 458);
            this.splitContainer1.SplitterDistance = 631;
            this.splitContainer1.TabIndex = 66;
            // 
            // grPrep
            // 
            this.grPrep.AllowUserToAddRows = false;
            this.grPrep.AllowUserToDeleteRows = false;
            this.grPrep.AllowUserToOrderColumns = false;
            this.grPrep.AllowUserToResizeColumns = true;
            this.grPrep.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grPrep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grPrep.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.grPrep.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.grPrep.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.grPrep.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.grPrep.BorderStyleGR = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grPrep.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.grPrep.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.grPrep.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.grPrep.ColumnHeadersHeight = 23;
            this.grPrep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grPrep.ColumnHeadersVisible = false;
            this.grPrep.ConFiltro = true;
            this.grPrep.DataMember = "";
            this.grPrep.DataSource = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grPrep.DefaultCellStyle = dataGridViewCellStyle2;
            this.grPrep.EnableHeadersVisualStyles = true;
            this.grPrep.FiltroCampos = "";
            this.grPrep.FirstDisplayedScrollingRowIndex = -1;
            this.grPrep.GridColor = System.Drawing.SystemColors.ControlDark;
            this.grPrep.Location = new System.Drawing.Point(3, 3);
            this.grPrep.MultiSelect = true;
            this.grPrep.Name = "grPrep";
            this.grPrep.ReadOnly = true;
            this.grPrep.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grPrep.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grPrep.RowHeadersVisible = true;
            this.grPrep.RowHeadersWidth = 41;
            this.grPrep.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grPrep.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grPrep.RowTemplate = dataGridViewRow1;
            this.grPrep.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.grPrep.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
            this.grPrep.ShowCellErrors = true;
            this.grPrep.ShowCellToolTips = true;
            this.grPrep.ShowEditingIcon = true;
            this.grPrep.ShowRowErrors = true;
            this.grPrep.Size = new System.Drawing.Size(625, 443);
            this.grPrep.TabIndex = 56;
            this.grPrep.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grPrep_RowEnter);
            // 
            // btOFL
            // 
            this.btOFL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btOFL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btOFL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOFL.Location = new System.Drawing.Point(3, 395);
            this.btOFL.Name = "btOFL";
            this.btOFL.Size = new System.Drawing.Size(112, 51);
            this.btOFL.TabIndex = 66;
            this.btOFL.Text = "Crear OFL";
            this.btOFL.UseVisualStyleBackColor = false;
            this.btOFL.Click += new System.EventHandler(this.btOFL_Click);
            // 
            // btActu
            // 
            this.btActu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btActu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btActu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActu.Location = new System.Drawing.Point(733, 12);
            this.btActu.Name = "btActu";
            this.btActu.Size = new System.Drawing.Size(189, 44);
            this.btActu.TabIndex = 67;
            this.btActu.Text = "&Actualizar";
            this.btActu.UseVisualStyleBackColor = false;
            this.btActu.Click += new System.EventHandler(this.btActu_Click);
            // 
            // btMarcSel
            // 
            this.btMarcSel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btMarcSel.Location = new System.Drawing.Point(131, 12);
            this.btMarcSel.Name = "btMarcSel";
            this.btMarcSel.Size = new System.Drawing.Size(113, 34);
            this.btMarcSel.TabIndex = 68;
            this.btMarcSel.Text = "&Marcar Seleccionados";
            this.btMarcSel.UseVisualStyleBackColor = false;
            this.btMarcSel.Click += new System.EventHandler(this.btMarcSel_Click);
            // 
            // frmCalcPrep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 604);
            this.Controls.Add(this.btMarcSel);
            this.Controls.Add(this.btActu);
            this.Controls.Add(this.upPrio);
            this.Controls.Add(this.btCambiar);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btCrear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btProcesar);
            this.Controls.Add(this.txPrio);
            this.Controls.Add(this.txID);
            this.Controls.Add(this.btLimpiar);
            this.Controls.Add(this.btSelTot);
            this.Name = "frmCalcPrep";
            this.Text = "Calcular Prepararaciones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCalcPrep_FormClosing);
            this.Load += new System.EventHandler(this.frmCalcPrep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grPrep2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upPrio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grMat)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btLimpiar;
        private System.Windows.Forms.Button btSelTot;
        private System.Windows.Forms.DataGridView grPrep2;
        private System.Windows.Forms.NumericUpDown upPrio;
        private System.Windows.Forms.Button btCambiar;
        private System.Windows.Forms.TextBox txID;
        private System.Windows.Forms.TextBox txPrio;
        private System.Windows.Forms.Button btProcesar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCrear;
        private System.Windows.Forms.DataGridView grMat;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btActu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sel;
        private System.Windows.Forms.Button btOFL;
        private jControles.jDataGridView grPrep;
        private System.Windows.Forms.Button btMarcSel;
    }
}