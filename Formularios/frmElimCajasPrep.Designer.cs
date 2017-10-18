namespace GesInject.Formularios
{
    partial class frmElimCajasPrep
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
            this.grCajas = new System.Windows.Forms.DataGridView();
            this.lbTitNumPrep = new System.Windows.Forms.Label();
            this.lbNumPrep = new System.Windows.Forms.Label();
            this.lbProd = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbNomProd = new System.Windows.Forms.Label();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.Sel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grCajas)).BeginInit();
            this.SuspendLayout();
            // 
            // grCajas
            // 
            this.grCajas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grCajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grCajas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sel});
            this.grCajas.Location = new System.Drawing.Point(12, 70);
            this.grCajas.Name = "grCajas";
            this.grCajas.Size = new System.Drawing.Size(752, 328);
            this.grCajas.TabIndex = 0;
            // 
            // lbTitNumPrep
            // 
            this.lbTitNumPrep.AutoSize = true;
            this.lbTitNumPrep.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitNumPrep.Location = new System.Drawing.Point(12, 9);
            this.lbTitNumPrep.Name = "lbTitNumPrep";
            this.lbTitNumPrep.Size = new System.Drawing.Size(146, 18);
            this.lbTitNumPrep.TabIndex = 1;
            this.lbTitNumPrep.Text = "Numero Preparación";
            // 
            // lbNumPrep
            // 
            this.lbNumPrep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbNumPrep.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumPrep.Location = new System.Drawing.Point(164, 9);
            this.lbNumPrep.Name = "lbNumPrep";
            this.lbNumPrep.Size = new System.Drawing.Size(146, 18);
            this.lbNumPrep.TabIndex = 2;
            // 
            // lbProd
            // 
            this.lbProd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProd.Location = new System.Drawing.Point(164, 36);
            this.lbProd.Name = "lbProd";
            this.lbProd.Size = new System.Drawing.Size(146, 18);
            this.lbProd.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Producto";
            // 
            // lbNomProd
            // 
            this.lbNomProd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNomProd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbNomProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNomProd.Location = new System.Drawing.Point(316, 35);
            this.lbNomProd.Name = "lbNomProd";
            this.lbNomProd.Size = new System.Drawing.Size(448, 18);
            this.lbNomProd.TabIndex = 5;
            // 
            // btEliminar
            // 
            this.btEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminar.Location = new System.Drawing.Point(15, 407);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(178, 63);
            this.btEliminar.TabIndex = 6;
            this.btEliminar.Text = "&Eliminar";
            this.btEliminar.UseVisualStyleBackColor = false;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.Location = new System.Drawing.Point(586, 407);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(178, 63);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "&Cancelar";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // Sel
            // 
            this.Sel.DataPropertyName = "Sel";
            this.Sel.Frozen = true;
            this.Sel.HeaderText = "Sel";
            this.Sel.Name = "Sel";
            this.Sel.Width = 30;
            // 
            // frmElimCajasPrep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 482);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.lbNomProd);
            this.Controls.Add(this.lbProd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbNumPrep);
            this.Controls.Add(this.lbTitNumPrep);
            this.Controls.Add(this.grCajas);
            this.Name = "frmElimCajasPrep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar Cajas de Preparación";
            this.Load += new System.EventHandler(this.frmElimCajasPrep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grCajas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grCajas;
        private System.Windows.Forms.Label lbTitNumPrep;
        private System.Windows.Forms.Label lbNumPrep;
        private System.Windows.Forms.Label lbProd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNomProd;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sel;
    }
}