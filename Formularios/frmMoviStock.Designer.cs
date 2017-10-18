namespace GesInject.Formularios
{
    partial class frmMoviStock
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
            this.grMovi = new System.Windows.Forms.DataGridView();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Fecha = new DataGridViewMaskedTextColumn();
            this.FechaHora = new DataGridViewMaskedTextColumn();
            this.Almacen = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btProducto = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Descripción = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OFL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ubi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txFecha = new System.Windows.Forms.MaskedTextBox();
            this.cbAlm = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btGrabar = new System.Windows.Forms.Button();
            this.btCrearExcel = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewMaskedTextColumn1 = new DataGridViewMaskedTextColumn();
            this.dataGridViewMaskedTextColumn2 = new DataGridViewMaskedTextColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btImportar = new System.Windows.Forms.Button();
            this.FD1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.grMovi)).BeginInit();
            this.SuspendLayout();
            // 
            // grMovi
            // 
            this.grMovi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grMovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grMovi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Empresa,
            this.Tipo,
            this.Fecha,
            this.FechaHora,
            this.Almacen,
            this.Producto,
            this.btProducto,
            this.Descripción,
            this.Cantidad,
            this.Documento,
            this.OFL,
            this.Ubi,
            this.Lote});
            this.grMovi.Location = new System.Drawing.Point(15, 55);
            this.grMovi.Name = "grMovi";
            this.grMovi.Size = new System.Drawing.Size(881, 370);
            this.grMovi.TabIndex = 0;
            this.grMovi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grMovi_CellContentClick);
            this.grMovi.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grMovi_CellValidating);
            this.grMovi.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grMovi_DataError);
            this.grMovi.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grMovi_RowValidating);
            // 
            // Empresa
            // 
            this.Empresa.DataPropertyName = "Empresa";
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.Name = "Empresa";
            this.Empresa.Visible = false;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Items.AddRange(new object[] {
            "Entrada",
            "Salida",
            "Entrada Producción",
            "Entrada Compra",
            "Salida Producción",
            "Salida Compra"});
            this.Tipo.Name = "Tipo";
            this.Tipo.Width = 80;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Mask = "00/00/0000";
            this.Fecha.Name = "Fecha";
            // 
            // FechaHora
            // 
            this.FechaHora.DataPropertyName = "FechaHora";
            this.FechaHora.HeaderText = "FechaHora";
            this.FechaHora.Mask = "00/00/0000";
            this.FechaHora.Name = "FechaHora";
            this.FechaHora.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FechaHora.Visible = false;
            // 
            // Almacen
            // 
            this.Almacen.DataPropertyName = "Almacen";
            this.Almacen.HeaderText = "Almacen";
            this.Almacen.Items.AddRange(new object[] {
            "Principal"});
            this.Almacen.Name = "Almacen";
            this.Almacen.Width = 80;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "Producto";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
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
            // OFL
            // 
            this.OFL.DataPropertyName = "OFL";
            this.OFL.HeaderText = "OFL";
            this.OFL.Name = "OFL";
            this.OFL.Width = 60;
            // 
            // Ubi
            // 
            this.Ubi.DataPropertyName = "Ubi";
            this.Ubi.HeaderText = "Ubicación";
            this.Ubi.Name = "Ubi";
            this.Ubi.Width = 60;
            // 
            // Lote
            // 
            this.Lote.DataPropertyName = "Lote";
            this.Lote.HeaderText = "Lote";
            this.Lote.Name = "Lote";
            this.Lote.Width = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo";
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "Entrada",
            "Salida",
            "Entrada Producción",
            "Entrada Compra",
            "Salida Producción",
            "Salida Compra"});
            this.cbTipo.Location = new System.Drawing.Point(46, 25);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(99, 21);
            this.cbTipo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha";
            // 
            // txFecha
            // 
            this.txFecha.Location = new System.Drawing.Point(214, 26);
            this.txFecha.Mask = "00/00/0000";
            this.txFecha.Name = "txFecha";
            this.txFecha.Size = new System.Drawing.Size(100, 20);
            this.txFecha.TabIndex = 4;
            // 
            // cbAlm
            // 
            this.cbAlm.FormattingEnabled = true;
            this.cbAlm.Items.AddRange(new object[] {
            "Principal"});
            this.cbAlm.Location = new System.Drawing.Point(399, 28);
            this.cbAlm.Name = "cbAlm";
            this.cbAlm.Size = new System.Drawing.Size(99, 21);
            this.cbAlm.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Almacen";
            // 
            // btGrabar
            // 
            this.btGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btGrabar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btGrabar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGrabar.Location = new System.Drawing.Point(12, 440);
            this.btGrabar.Name = "btGrabar";
            this.btGrabar.Size = new System.Drawing.Size(174, 44);
            this.btGrabar.TabIndex = 7;
            this.btGrabar.Text = "&Grabar";
            this.btGrabar.UseVisualStyleBackColor = false;
            this.btGrabar.Click += new System.EventHandler(this.btGrabar_Click);
            // 
            // btCrearExcel
            // 
            this.btCrearExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCrearExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCrearExcel.Location = new System.Drawing.Point(269, 441);
            this.btCrearExcel.Name = "btCrearExcel";
            this.btCrearExcel.Size = new System.Drawing.Size(155, 44);
            this.btCrearExcel.TabIndex = 8;
            this.btCrearExcel.Text = "Crear Excel";
            this.btCrearExcel.UseVisualStyleBackColor = true;
            this.btCrearExcel.Click += new System.EventHandler(this.btCrearExcel_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Empresa";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewMaskedTextColumn1
            // 
            this.dataGridViewMaskedTextColumn1.HeaderText = "Fecha";
            this.dataGridViewMaskedTextColumn1.Mask = "00/00/0000";
            this.dataGridViewMaskedTextColumn1.Name = "dataGridViewMaskedTextColumn1";
            // 
            // dataGridViewMaskedTextColumn2
            // 
            this.dataGridViewMaskedTextColumn2.HeaderText = "FechaHora";
            this.dataGridViewMaskedTextColumn2.Mask = "00/00/0000";
            this.dataGridViewMaskedTextColumn2.Name = "dataGridViewMaskedTextColumn2";
            this.dataGridViewMaskedTextColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMaskedTextColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle2.Format = "n4";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn4.HeaderText = "Cantidad";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Documento";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "OFL";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Ubicación";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Lote";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 60;
            // 
            // btImportar
            // 
            this.btImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImportar.Location = new System.Drawing.Point(505, 441);
            this.btImportar.Name = "btImportar";
            this.btImportar.Size = new System.Drawing.Size(155, 44);
            this.btImportar.TabIndex = 9;
            this.btImportar.Text = "Importar CSV";
            this.btImportar.UseVisualStyleBackColor = true;
            this.btImportar.Click += new System.EventHandler(this.btImportar_Click);
            // 
            // FD1
            // 
            this.FD1.FileName = "openFileDialog1";
            // 
            // frmMoviStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 496);
            this.Controls.Add(this.btImportar);
            this.Controls.Add(this.btCrearExcel);
            this.Controls.Add(this.btGrabar);
            this.Controls.Add(this.cbAlm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grMovi);
            this.Name = "frmMoviStock";
            this.Text = "Movimientos de Stock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMoviStock_FormClosing);
            this.Load += new System.EventHandler(this.frmMoviStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMovi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grMovi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txFecha;
        private System.Windows.Forms.ComboBox cbAlm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btGrabar;
        private System.Windows.Forms.Button btCrearExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewMaskedTextColumn dataGridViewMaskedTextColumn1;
        private DataGridViewMaskedTextColumn dataGridViewMaskedTextColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Button btImportar;
        private System.Windows.Forms.OpenFileDialog FD1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.DataGridViewComboBoxColumn Tipo;
        private DataGridViewMaskedTextColumn Fecha;
        private DataGridViewMaskedTextColumn FechaHora;
        private System.Windows.Forms.DataGridViewComboBoxColumn Almacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewButtonColumn btProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripción;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn OFL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
    }
}