namespace GesInject.Formularios
{
    partial class frmMoviAlbCompra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewRow dataGridViewRow3 = new System.Windows.Forms.DataGridViewRow();
            this.btCerrar = new System.Windows.Forms.Button();
            this.btExcel = new System.Windows.Forms.Button();
            this.btRepro = new System.Windows.Forms.Button();
            this.grLista = new jControles.jDataGridView();
            this.btActu = new System.Windows.Forms.Button();
            this.txPedido = new jControles.jTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txLote = new jControles.jTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txRecepPor = new jControles.jTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.FD1 = new System.Windows.Forms.OpenFileDialog();
            this.label14 = new System.Windows.Forms.Label();
            this.btCert = new System.Windows.Forms.Button();
            this.txCert = new System.Windows.Forms.TextBox();
            this.txCan = new jControles.jTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txObs = new jControles.jTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txId = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txSuAlbaran = new jControles.jTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btRecep = new System.Windows.Forms.Button();
            this.txDesProd = new System.Windows.Forms.TextBox();
            this.txProd = new System.Windows.Forms.TextBox();
            this.btGrabar = new System.Windows.Forms.Button();
            this.btEtiqueta = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btUbi = new System.Windows.Forms.Button();
            this.txUbi = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCerrar
            // 
            this.btCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerrar.Location = new System.Drawing.Point(705, 608);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(111, 34);
            this.btCerrar.TabIndex = 21;
            this.btCerrar.Text = "&Cerrar";
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // btExcel
            // 
            this.btExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExcel.Location = new System.Drawing.Point(12, 608);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(114, 33);
            this.btExcel.TabIndex = 20;
            this.btExcel.Text = "Crear Excel";
            this.btExcel.UseVisualStyleBackColor = true;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // btRepro
            // 
            this.btRepro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btRepro.Location = new System.Drawing.Point(12, 12);
            this.btRepro.Name = "btRepro";
            this.btRepro.Size = new System.Drawing.Size(114, 33);
            this.btRepro.TabIndex = 22;
            this.btRepro.Text = "Reprocesar";
            this.btRepro.UseVisualStyleBackColor = false;
            this.btRepro.Click += new System.EventHandler(this.btRepro_Click);
            // 
            // grLista
            // 
            this.grLista.AllowUserToAddRows = false;
            this.grLista.AllowUserToDeleteRows = false;
            this.grLista.AllowUserToOrderColumns = false;
            this.grLista.AllowUserToResizeColumns = true;
            this.grLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.grLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.grLista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.grLista.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.grLista.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.grLista.BorderStyleGR = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grLista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.grLista.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.grLista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.grLista.ColumnHeadersHeight = 23;
            this.grLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grLista.ColumnHeadersVisible = false;
            this.grLista.ConFiltro = true;
            this.grLista.DataMember = "";
            this.grLista.DataSource = null;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grLista.DefaultCellStyle = dataGridViewCellStyle10;
            this.grLista.EnableHeadersVisualStyles = true;
            this.grLista.FirstDisplayedScrollingRowIndex = -1;
            this.grLista.GridColor = System.Drawing.SystemColors.ControlDark;
            this.grLista.Location = new System.Drawing.Point(12, 51);
            this.grLista.MultiSelect = true;
            this.grLista.Name = "grLista";
            this.grLista.ReadOnly = true;
            this.grLista.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.grLista.RowHeadersVisible = true;
            this.grLista.RowHeadersWidth = 41;
            this.grLista.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grLista.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.grLista.RowTemplate = dataGridViewRow3;
            this.grLista.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.grLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
            this.grLista.ShowCellErrors = true;
            this.grLista.ShowCellToolTips = true;
            this.grLista.ShowEditingIcon = true;
            this.grLista.ShowRowErrors = true;
            this.grLista.Size = new System.Drawing.Size(804, 343);
            this.grLista.TabIndex = 13;
            this.grLista.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grLista_RowEnter);
            // 
            // btActu
            // 
            this.btActu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btActu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btActu.Location = new System.Drawing.Point(702, 12);
            this.btActu.Name = "btActu";
            this.btActu.Size = new System.Drawing.Size(114, 33);
            this.btActu.TabIndex = 23;
            this.btActu.Text = "Actualizar";
            this.btActu.UseVisualStyleBackColor = false;
            this.btActu.Click += new System.EventHandler(this.btActu_Click);
            // 
            // txPedido
            // 
            this.txPedido.Decimales = 0;
            this.txPedido.Location = new System.Drawing.Point(403, 5);
            this.txPedido.Name = "txPedido";
            this.txPedido.Numerico = false;
            this.txPedido.Size = new System.Drawing.Size(94, 20);
            this.txPedido.TabIndex = 61;
            this.txPedido.Tag = "NumPed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "Nº Pedido";
            // 
            // txLote
            // 
            this.txLote.Decimales = 0;
            this.txLote.Location = new System.Drawing.Point(223, 5);
            this.txLote.Name = "txLote";
            this.txLote.Numerico = false;
            this.txLote.Size = new System.Drawing.Size(99, 20);
            this.txLote.TabIndex = 59;
            this.txLote.Tag = "Lote";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(168, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 60;
            this.label7.Text = "Lote";
            // 
            // txRecepPor
            // 
            this.txRecepPor.Decimales = 0;
            this.txRecepPor.Location = new System.Drawing.Point(615, 5);
            this.txRecepPor.Name = "txRecepPor";
            this.txRecepPor.Numerico = true;
            this.txRecepPor.Size = new System.Drawing.Size(38, 20);
            this.txRecepPor.TabIndex = 63;
            this.txRecepPor.Tag = "RecepcionadoPor";
            this.txRecepPor.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(516, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 64;
            this.label10.Text = "RecepcionadoPor";
            // 
            // FD1
            // 
            this.FD1.FileName = "openFileDialog1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 101;
            this.label14.Text = "Certificado";
            // 
            // btCert
            // 
            this.btCert.Location = new System.Drawing.Point(220, 44);
            this.btCert.Name = "btCert";
            this.btCert.Size = new System.Drawing.Size(21, 23);
            this.btCert.TabIndex = 100;
            this.btCert.Text = "...";
            this.btCert.UseVisualStyleBackColor = true;
            this.btCert.Click += new System.EventHandler(this.btCert_Click);
            // 
            // txCert
            // 
            this.txCert.AcceptsReturn = true;
            this.txCert.Location = new System.Drawing.Point(69, 46);
            this.txCert.Name = "txCert";
            this.txCert.ReadOnly = true;
            this.txCert.Size = new System.Drawing.Size(150, 20);
            this.txCert.TabIndex = 99;
            this.txCert.Tag = "";
            // 
            // txCan
            // 
            this.txCan.Decimales = 0;
            this.txCan.Location = new System.Drawing.Point(69, 5);
            this.txCan.Name = "txCan";
            this.txCan.Numerico = true;
            this.txCan.Size = new System.Drawing.Size(78, 20);
            this.txCan.TabIndex = 102;
            this.txCan.Tag = "Cantidad";
            this.txCan.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 103;
            this.label8.Text = "Cantidad";
            // 
            // txObs
            // 
            this.txObs.Decimales = 0;
            this.txObs.Location = new System.Drawing.Point(384, 44);
            this.txObs.Multiline = true;
            this.txObs.Name = "txObs";
            this.txObs.Numerico = false;
            this.txObs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txObs.Size = new System.Drawing.Size(417, 67);
            this.txObs.TabIndex = 104;
            this.txObs.Tag = "Obs";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(300, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 105;
            this.label9.Text = "Observaciones";
            // 
            // txId
            // 
            this.txId.Location = new System.Drawing.Point(643, 117);
            this.txId.Name = "txId";
            this.txId.Size = new System.Drawing.Size(23, 20);
            this.txId.TabIndex = 106;
            this.txId.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btUbi);
            this.panel1.Controls.Add(this.txUbi);
            this.panel1.Controls.Add(this.txSuAlbaran);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btRecep);
            this.panel1.Controls.Add(this.txDesProd);
            this.panel1.Controls.Add(this.txProd);
            this.panel1.Controls.Add(this.txObs);
            this.panel1.Controls.Add(this.txId);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txLote);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txCan);
            this.panel1.Controls.Add(this.txPedido);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txRecepPor);
            this.panel1.Controls.Add(this.btCert);
            this.panel1.Controls.Add(this.txCert);
            this.panel1.Location = new System.Drawing.Point(12, 418);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 149);
            this.panel1.TabIndex = 107;
            // 
            // txSuAlbaran
            // 
            this.txSuAlbaran.Decimales = 0;
            this.txSuAlbaran.Location = new System.Drawing.Point(69, 83);
            this.txSuAlbaran.Name = "txSuAlbaran";
            this.txSuAlbaran.Numerico = false;
            this.txSuAlbaran.Size = new System.Drawing.Size(150, 20);
            this.txSuAlbaran.TabIndex = 111;
            this.txSuAlbaran.Tag = "Lote";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 110;
            this.label1.Text = "Su Albaran";
            // 
            // btRecep
            // 
            this.btRecep.Location = new System.Drawing.Point(654, 2);
            this.btRecep.Name = "btRecep";
            this.btRecep.Size = new System.Drawing.Size(21, 23);
            this.btRecep.TabIndex = 109;
            this.btRecep.Text = "...";
            this.btRecep.UseVisualStyleBackColor = true;
            this.btRecep.Click += new System.EventHandler(this.btRecep_Click);
            // 
            // txDesProd
            // 
            this.txDesProd.Location = new System.Drawing.Point(597, 117);
            this.txDesProd.Name = "txDesProd";
            this.txDesProd.Size = new System.Drawing.Size(23, 20);
            this.txDesProd.TabIndex = 108;
            this.txDesProd.Visible = false;
            // 
            // txProd
            // 
            this.txProd.Location = new System.Drawing.Point(523, 117);
            this.txProd.Name = "txProd";
            this.txProd.Size = new System.Drawing.Size(23, 20);
            this.txProd.TabIndex = 107;
            this.txProd.Visible = false;
            // 
            // btGrabar
            // 
            this.btGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btGrabar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btGrabar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGrabar.Location = new System.Drawing.Point(167, 604);
            this.btGrabar.Name = "btGrabar";
            this.btGrabar.Size = new System.Drawing.Size(103, 37);
            this.btGrabar.TabIndex = 108;
            this.btGrabar.Text = "&Grabar";
            this.btGrabar.UseVisualStyleBackColor = false;
            this.btGrabar.Visible = false;
            this.btGrabar.Click += new System.EventHandler(this.btGrabar_Click);
            // 
            // btEtiqueta
            // 
            this.btEtiqueta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btEtiqueta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEtiqueta.Location = new System.Drawing.Point(302, 605);
            this.btEtiqueta.Name = "btEtiqueta";
            this.btEtiqueta.Size = new System.Drawing.Size(103, 37);
            this.btEtiqueta.TabIndex = 109;
            this.btEtiqueta.Text = "&Etiqueta";
            this.btEtiqueta.UseVisualStyleBackColor = false;
            this.btEtiqueta.Click += new System.EventHandler(this.btEtiqueta_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 114;
            this.label2.Text = "Ubicación";
            // 
            // btUbi
            // 
            this.btUbi.Location = new System.Drawing.Point(346, 81);
            this.btUbi.Name = "btUbi";
            this.btUbi.Size = new System.Drawing.Size(21, 23);
            this.btUbi.TabIndex = 113;
            this.btUbi.Text = "...";
            this.btUbi.UseVisualStyleBackColor = true;
            this.btUbi.Click += new System.EventHandler(this.btUbi_Click);
            // 
            // txUbi
            // 
            this.txUbi.AcceptsReturn = true;
            this.txUbi.Location = new System.Drawing.Point(290, 83);
            this.txUbi.Name = "txUbi";
            this.txUbi.ReadOnly = true;
            this.txUbi.Size = new System.Drawing.Size(54, 20);
            this.txUbi.TabIndex = 112;
            this.txUbi.Tag = "Ubi";
            // 
            // frmMoviAlbCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 653);
            this.Controls.Add(this.btEtiqueta);
            this.Controls.Add(this.btGrabar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btActu);
            this.Controls.Add(this.btRepro);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.btExcel);
            this.Controls.Add(this.grLista);
            this.Name = "frmMoviAlbCompra";
            this.Text = "Movimientos de Albaranes de Compra Pendientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMoviAlbCompra_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private jControles.jDataGridView grLista;
        private System.Windows.Forms.Button btCerrar;
        private System.Windows.Forms.Button btExcel;
        private System.Windows.Forms.Button btRepro;
        private System.Windows.Forms.Button btActu;
        private jControles.jTextBox txPedido;
        private System.Windows.Forms.Label label4;
        private jControles.jTextBox txLote;
        private System.Windows.Forms.Label label7;
        private jControles.jTextBox txRecepPor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.OpenFileDialog FD1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btCert;
        private System.Windows.Forms.TextBox txCert;
        private jControles.jTextBox txCan;
        private System.Windows.Forms.Label label8;
        private jControles.jTextBox txObs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txId;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btGrabar;
        private System.Windows.Forms.TextBox txProd;
        private System.Windows.Forms.Button btEtiqueta;
        private System.Windows.Forms.TextBox txDesProd;
        private System.Windows.Forms.Button btRecep;
        private jControles.jTextBox txSuAlbaran;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btUbi;
        private System.Windows.Forms.TextBox txUbi;
    }
}