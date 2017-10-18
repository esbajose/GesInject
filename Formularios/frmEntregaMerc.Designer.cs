namespace GesInject.Formularios
{
    partial class frmEntregaMerc
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
            this.lbtitProd = new System.Windows.Forms.Label();
            this.lbProd = new System.Windows.Forms.Label();
            this.txDesProd = new System.Windows.Forms.TextBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btEntregar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btUbi = new System.Windows.Forms.Button();
            this.txUbi = new System.Windows.Forms.TextBox();
            this.txCan = new jControles.jTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txLote = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbDisp = new System.Windows.Forms.Label();
            this.btLote = new System.Windows.Forms.Button();
            this.grLista = new System.Windows.Forms.DataGridView();
            this.Sel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txCajas = new System.Windows.Forms.TextBox();
            this.lbOFL = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grLista)).BeginInit();
            this.SuspendLayout();
            // 
            // lbtitProd
            // 
            this.lbtitProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtitProd.Location = new System.Drawing.Point(16, 21);
            this.lbtitProd.Name = "lbtitProd";
            this.lbtitProd.Size = new System.Drawing.Size(432, 23);
            this.lbtitProd.TabIndex = 0;
            this.lbtitProd.Text = "Producto";
            this.lbtitProd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbProd
            // 
            this.lbProd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProd.Location = new System.Drawing.Point(12, 61);
            this.lbProd.Name = "lbProd";
            this.lbProd.Size = new System.Drawing.Size(125, 27);
            this.lbProd.TabIndex = 1;
            // 
            // txDesProd
            // 
            this.txDesProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txDesProd.Location = new System.Drawing.Point(144, 61);
            this.txDesProd.Multiline = true;
            this.txDesProd.Name = "txDesProd";
            this.txDesProd.ReadOnly = true;
            this.txDesProd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txDesProd.Size = new System.Drawing.Size(304, 70);
            this.txDesProd.TabIndex = 2;
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.Location = new System.Drawing.Point(313, 581);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(147, 64);
            this.btCancel.TabIndex = 14;
            this.btCancel.Text = "&Cancelar";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btEntregar
            // 
            this.btEntregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btEntregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEntregar.Location = new System.Drawing.Point(24, 581);
            this.btEntregar.Name = "btEntregar";
            this.btEntregar.Size = new System.Drawing.Size(147, 64);
            this.btEntregar.TabIndex = 15;
            this.btEntregar.Text = "&Entregar";
            this.btEntregar.UseVisualStyleBackColor = false;
            this.btEntregar.Click += new System.EventHandler(this.btEntregar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 117;
            this.label2.Text = "Ubicación";
            // 
            // btUbi
            // 
            this.btUbi.Location = new System.Drawing.Point(213, 162);
            this.btUbi.Name = "btUbi";
            this.btUbi.Size = new System.Drawing.Size(27, 26);
            this.btUbi.TabIndex = 116;
            this.btUbi.Text = "...";
            this.btUbi.UseVisualStyleBackColor = true;
            this.btUbi.Click += new System.EventHandler(this.btUbi_Click);
            // 
            // txUbi
            // 
            this.txUbi.AcceptsReturn = true;
            this.txUbi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txUbi.Location = new System.Drawing.Point(106, 161);
            this.txUbi.Name = "txUbi";
            this.txUbi.Size = new System.Drawing.Size(107, 26);
            this.txUbi.TabIndex = 11;
            this.txUbi.Tag = "Ubi";
            this.txUbi.TextChanged += new System.EventHandler(this.txUbi_TextChanged);
            // 
            // txCan
            // 
            this.txCan.Decimales = 0;
            this.txCan.EnterTab = false;
            this.txCan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txCan.Location = new System.Drawing.Point(106, 523);
            this.txCan.Name = "txCan";
            this.txCan.Numerico = true;
            this.txCan.Size = new System.Drawing.Size(107, 26);
            this.txCan.TabIndex = 14;
            this.txCan.Tag = "bind#Cantidad#Text";
            this.txCan.Text = "0";
            this.txCan.TextChanged += new System.EventHandler(this.txCan_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 530);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 118;
            this.label1.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 121;
            this.label3.Text = "Lote";
            // 
            // txLote
            // 
            this.txLote.AcceptsReturn = true;
            this.txLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txLote.Location = new System.Drawing.Point(106, 209);
            this.txLote.Name = "txLote";
            this.txLote.Size = new System.Drawing.Size(254, 26);
            this.txLote.TabIndex = 12;
            this.txLote.Tag = "";
            this.txLote.TextChanged += new System.EventHandler(this.txLote_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 122;
            this.label4.Text = "Disponible : ";
            // 
            // lbDisp
            // 
            this.lbDisp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDisp.Location = new System.Drawing.Point(355, 367);
            this.lbDisp.Name = "lbDisp";
            this.lbDisp.Size = new System.Drawing.Size(105, 23);
            this.lbDisp.TabIndex = 123;
            // 
            // btLote
            // 
            this.btLote.Location = new System.Drawing.Point(360, 210);
            this.btLote.Name = "btLote";
            this.btLote.Size = new System.Drawing.Size(27, 26);
            this.btLote.TabIndex = 124;
            this.btLote.Text = "...";
            this.btLote.UseVisualStyleBackColor = true;
            this.btLote.Click += new System.EventHandler(this.btLote_Click);
            // 
            // grLista
            // 
            this.grLista.AllowUserToAddRows = false;
            this.grLista.AllowUserToDeleteRows = false;
            this.grLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sel});
            this.grLista.Location = new System.Drawing.Point(16, 259);
            this.grLista.Name = "grLista";
            this.grLista.Size = new System.Drawing.Size(262, 241);
            this.grLista.TabIndex = 125;
            this.grLista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grLista_CellContentClick);
            this.grLista.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grLista_CellValidating);
            this.grLista.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grLista_RowValidating);
            // 
            // Sel
            // 
            this.Sel.DataPropertyName = "Sel";
            this.Sel.HeaderText = "Sel";
            this.Sel.Name = "Sel";
            this.Sel.Width = 50;
            // 
            // txCajas
            // 
            this.txCajas.Location = new System.Drawing.Point(252, 529);
            this.txCajas.Name = "txCajas";
            this.txCajas.Size = new System.Drawing.Size(180, 20);
            this.txCajas.TabIndex = 126;
            this.txCajas.Visible = false;
            // 
            // lbOFL
            // 
            this.lbOFL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOFL.Location = new System.Drawing.Point(356, 290);
            this.lbOFL.Name = "lbOFL";
            this.lbOFL.Size = new System.Drawing.Size(105, 23);
            this.lbOFL.TabIndex = 128;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 127;
            this.label6.Text = "OFL : ";
            // 
            // frmEntregaMerc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 657);
            this.ControlBox = false;
            this.Controls.Add(this.lbOFL);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txCajas);
            this.Controls.Add(this.grLista);
            this.Controls.Add(this.btLote);
            this.Controls.Add(this.lbDisp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txLote);
            this.Controls.Add(this.txCan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btUbi);
            this.Controls.Add(this.txUbi);
            this.Controls.Add(this.btEntregar);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.txDesProd);
            this.Controls.Add(this.lbProd);
            this.Controls.Add(this.lbtitProd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmEntregaMerc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrega de Mercancia";
            this.Load += new System.EventHandler(this.frmEntregaMerc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbtitProd;
        private System.Windows.Forms.Label lbProd;
        private System.Windows.Forms.TextBox txDesProd;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btEntregar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btUbi;
        private System.Windows.Forms.TextBox txUbi;
        private jControles.jTextBox txCan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txLote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbDisp;
        private System.Windows.Forms.Button btLote;
        private System.Windows.Forms.DataGridView grLista;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sel;
        private System.Windows.Forms.TextBox txCajas;
        private System.Windows.Forms.Label lbOFL;
        private System.Windows.Forms.Label label6;
    }
}