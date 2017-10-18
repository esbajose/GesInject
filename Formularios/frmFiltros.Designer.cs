namespace GesInject.Formularios
{
    partial class frmFiltros
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
            this.filtrosBD = new Fil.FiltrosBD();
            this.btCancel = new System.Windows.Forms.Button();
            this.btAcceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // filtrosBD
            // 
            this.filtrosBD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filtrosBD.Location = new System.Drawing.Point(0, 0);
            this.filtrosBD.Name = "filtrosBD";
            this.filtrosBD.Size = new System.Drawing.Size(516, 169);
            this.filtrosBD.TabIndex = 0;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.Location = new System.Drawing.Point(385, 167);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(103, 31);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Cancelar";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btAcceptar
            // 
            this.btAcceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAcceptar.Location = new System.Drawing.Point(12, 167);
            this.btAcceptar.Name = "btAcceptar";
            this.btAcceptar.Size = new System.Drawing.Size(103, 31);
            this.btAcceptar.TabIndex = 2;
            this.btAcceptar.Text = "Aceptar";
            this.btAcceptar.UseVisualStyleBackColor = true;
            this.btAcceptar.Click += new System.EventHandler(this.btAcceptar_Click);
            // 
            // frmFiltros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 202);
            this.Controls.Add(this.btAcceptar);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.filtrosBD);
            this.Name = "frmFiltros";
            this.Text = "Filtros Tabla";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFiltros_FormClosing);
            this.Load += new System.EventHandler(this.frmFiltros_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Fil.FiltrosBD filtrosBD;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btAcceptar;

    }
}