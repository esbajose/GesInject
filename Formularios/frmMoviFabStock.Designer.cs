namespace GesInject.Formularios
{
    partial class frmMoviFabStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewRow dataGridViewRow1 = new System.Windows.Forms.DataGridViewRow();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grMovi = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btUbi = new System.Windows.Forms.Button();
            this.txUbi = new System.Windows.Forms.TextBox();
            this.btGrabar = new System.Windows.Forms.Button();
            this.btCerrar = new System.Windows.Forms.Button();
            this.cbUbi = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btActu = new System.Windows.Forms.Button();
            this.btTras = new System.Windows.Forms.Button();
            this.grStock = new jControles.jDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OFL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btProducto = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Descripción = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DUbi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AUbi = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grMovi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grMovi
            // 
            this.grMovi.AllowUserToAddRows = false;
            this.grMovi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grMovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grMovi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lote,
            this.OFL,
            this.Producto,
            this.btProducto,
            this.Descripción,
            this.Cantidad,
            this.Documento,
            this.DUbi,
            this.AUbi});
            this.grMovi.Location = new System.Drawing.Point(3, 3);
            this.grMovi.Name = "grMovi";
            this.grMovi.Size = new System.Drawing.Size(691, 416);
            this.grMovi.TabIndex = 1;
            this.grMovi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grMovi_CellContentClick);
            this.grMovi.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grMovi_CellValidating);
            this.grMovi.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grMovi_DataError);
            this.grMovi.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grMovi_RowValidating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 117;
            this.label2.Text = "A la Ubicación";
            // 
            // btUbi
            // 
            this.btUbi.Location = new System.Drawing.Point(464, 13);
            this.btUbi.Name = "btUbi";
            this.btUbi.Size = new System.Drawing.Size(21, 23);
            this.btUbi.TabIndex = 116;
            this.btUbi.Text = "...";
            this.btUbi.UseVisualStyleBackColor = true;
            this.btUbi.Visible = false;
            this.btUbi.Click += new System.EventHandler(this.btUbi_Click);
            // 
            // txUbi
            // 
            this.txUbi.AcceptsReturn = true;
            this.txUbi.Location = new System.Drawing.Point(408, 15);
            this.txUbi.Name = "txUbi";
            this.txUbi.ReadOnly = true;
            this.txUbi.Size = new System.Drawing.Size(54, 20);
            this.txUbi.TabIndex = 115;
            this.txUbi.Tag = "Ubi";
            this.txUbi.Visible = false;
            // 
            // btGrabar
            // 
            this.btGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btGrabar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btGrabar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGrabar.Location = new System.Drawing.Point(12, 493);
            this.btGrabar.Name = "btGrabar";
            this.btGrabar.Size = new System.Drawing.Size(174, 44);
            this.btGrabar.TabIndex = 118;
            this.btGrabar.Text = "&Grabar";
            this.btGrabar.UseVisualStyleBackColor = false;
            this.btGrabar.Click += new System.EventHandler(this.btGrabar_Click);
            // 
            // btCerrar
            // 
            this.btCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerrar.BackColor = System.Drawing.SystemColors.Control;
            this.btCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCerrar.Location = new System.Drawing.Point(991, 493);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(174, 44);
            this.btCerrar.TabIndex = 119;
            this.btCerrar.Text = "&Cerrar";
            this.btCerrar.UseVisualStyleBackColor = false;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // cbUbi
            // 
            this.cbUbi.FormattingEnabled = true;
            this.cbUbi.Location = new System.Drawing.Point(98, 16);
            this.cbUbi.Name = "cbUbi";
            this.cbUbi.Size = new System.Drawing.Size(92, 21);
            this.cbUbi.TabIndex = 120;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer1.Location = new System.Drawing.Point(19, 43);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.grMovi);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.btActu);
            this.splitContainer1.Panel2.Controls.Add(this.btTras);
            this.splitContainer1.Panel2.Controls.Add(this.grStock);
            this.splitContainer1.Size = new System.Drawing.Size(1176, 422);
            this.splitContainer1.SplitterDistance = 697;
            this.splitContainer1.TabIndex = 121;
            // 
            // btActu
            // 
            this.btActu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btActu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btActu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActu.Location = new System.Drawing.Point(350, 3);
            this.btActu.Name = "btActu";
            this.btActu.Size = new System.Drawing.Size(122, 37);
            this.btActu.TabIndex = 16;
            this.btActu.Text = "Actualizar";
            this.btActu.UseVisualStyleBackColor = false;
            this.btActu.Click += new System.EventHandler(this.btActu_Click);
            // 
            // btTras
            // 
            this.btTras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btTras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTras.Location = new System.Drawing.Point(3, 3);
            this.btTras.Name = "btTras";
            this.btTras.Size = new System.Drawing.Size(116, 37);
            this.btTras.TabIndex = 15;
            this.btTras.Text = "<<Traspasar";
            this.btTras.UseVisualStyleBackColor = false;
            this.btTras.Click += new System.EventHandler(this.btTras_Click);
            // 
            // grStock
            // 
            this.grStock.AllowUserToAddRows = false;
            this.grStock.AllowUserToDeleteRows = false;
            this.grStock.AllowUserToOrderColumns = false;
            this.grStock.AllowUserToResizeColumns = true;
            this.grStock.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.grStock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.grStock.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.grStock.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.grStock.BorderStyleGR = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grStock.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.grStock.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.grStock.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.grStock.ColumnHeadersHeight = 23;
            this.grStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grStock.ColumnHeadersVisible = false;
            this.grStock.ConFiltro = true;
            this.grStock.DataMember = "";
            this.grStock.DataSource = null;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grStock.DefaultCellStyle = dataGridViewCellStyle3;
            this.grStock.EnableHeadersVisualStyles = true;
            this.grStock.FirstDisplayedScrollingRowIndex = -1;
            this.grStock.GridColor = System.Drawing.SystemColors.ControlDark;
            this.grStock.Location = new System.Drawing.Point(3, 46);
            this.grStock.MultiSelect = true;
            this.grStock.Name = "grStock";
            this.grStock.ReadOnly = true;
            this.grStock.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grStock.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grStock.RowHeadersVisible = true;
            this.grStock.RowHeadersWidth = 41;
            this.grStock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grStock.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grStock.RowTemplate = dataGridViewRow1;
            this.grStock.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.grStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
            this.grStock.ShowCellErrors = true;
            this.grStock.ShowCellToolTips = true;
            this.grStock.ShowEditingIcon = true;
            this.grStock.ShowRowErrors = true;
            this.grStock.Size = new System.Drawing.Size(469, 373);
            this.grStock.TabIndex = 14;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Lote";
            this.dataGridViewTextBoxColumn1.HeaderText = "Lote";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Producto";
            this.dataGridViewTextBoxColumn2.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Descripción";
            this.dataGridViewTextBoxColumn3.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Cantidad";
            dataGridViewCellStyle6.Format = "n4";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn4.HeaderText = "Cantidad";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Documento";
            this.dataGridViewTextBoxColumn5.HeaderText = "Documento";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DUbi";
            this.dataGridViewTextBoxColumn6.FillWeight = 160F;
            this.dataGridViewTextBoxColumn6.HeaderText = "De la Ubicación";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "AUbi";
            this.dataGridViewTextBoxColumn7.FillWeight = 160F;
            this.dataGridViewTextBoxColumn7.HeaderText = "A la Ubicación";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // Lote
            // 
            this.Lote.DataPropertyName = "Lote";
            this.Lote.HeaderText = "Lote";
            this.Lote.Name = "Lote";
            this.Lote.ReadOnly = true;
            // 
            // OFL
            // 
            this.OFL.DataPropertyName = "OFL";
            this.OFL.HeaderText = "OFL";
            this.OFL.Name = "OFL";
            this.OFL.ReadOnly = true;
            this.OFL.Visible = false;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "Producto";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Producto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btProducto
            // 
            this.btProducto.DataPropertyName = "btProducto";
            this.btProducto.HeaderText = "...";
            this.btProducto.Name = "btProducto";
            this.btProducto.ReadOnly = true;
            this.btProducto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btProducto.Width = 30;
            // 
            // Descripción
            // 
            this.Descripción.DataPropertyName = "Descripción";
            this.Descripción.HeaderText = "Descripción";
            this.Descripción.Name = "Descripción";
            this.Descripción.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle1.Format = "n4";
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle1;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cantidad.Width = 70;
            // 
            // Documento
            // 
            this.Documento.DataPropertyName = "Documento";
            this.Documento.HeaderText = "Documento";
            this.Documento.Name = "Documento";
            // 
            // DUbi
            // 
            this.DUbi.DataPropertyName = "DUbi";
            this.DUbi.FillWeight = 160F;
            this.DUbi.HeaderText = "De la Ubicación";
            this.DUbi.Name = "DUbi";
            this.DUbi.ReadOnly = true;
            this.DUbi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DUbi.Visible = false;
            this.DUbi.Width = 80;
            // 
            // AUbi
            // 
            this.AUbi.DataPropertyName = "AUbi";
            this.AUbi.FillWeight = 160F;
            this.AUbi.HeaderText = "A la Ubicación";
            this.AUbi.Name = "AUbi";
            this.AUbi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AUbi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AUbi.Width = 80;
            // 
            // frmMoviFabStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 549);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cbUbi);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.btGrabar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btUbi);
            this.Controls.Add(this.txUbi);
            this.Name = "frmMoviFabStock";
            this.Text = "Movimientos entre Ubicaciones";
            this.Load += new System.EventHandler(this.frmMoviFabStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMovi)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grMovi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btUbi;
        private System.Windows.Forms.TextBox txUbi;
        private System.Windows.Forms.Button btGrabar;
        private System.Windows.Forms.Button btCerrar;
        private System.Windows.Forms.ComboBox cbUbi;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private jControles.jDataGridView grStock;
        private System.Windows.Forms.Button btActu;
        private System.Windows.Forms.Button btTras;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn OFL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewButtonColumn btProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripción;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DUbi;
        private System.Windows.Forms.DataGridViewComboBoxColumn AUbi;
    }
}