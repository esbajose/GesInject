namespace GesInject.Formularios
{
    partial class frmNuevoAnexo
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
            this.label1 = new System.Windows.Forms.Label();
            this.txProducto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txDesProducto = new System.Windows.Forms.TextBox();
            this.btTraer = new System.Windows.Forms.Button();
            this.btAlta = new System.Windows.Forms.Button();
            this.btLimpia = new System.Windows.Forms.Button();
            this.btCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código Producto";
            // 
            // txProducto
            // 
            this.txProducto.Location = new System.Drawing.Point(129, 16);
            this.txProducto.Name = "txProducto";
            this.txProducto.Size = new System.Drawing.Size(156, 20);
            this.txProducto.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción Producto";
            // 
            // txDesProducto
            // 
            this.txDesProducto.Location = new System.Drawing.Point(129, 58);
            this.txDesProducto.Name = "txDesProducto";
            this.txDesProducto.Size = new System.Drawing.Size(408, 20);
            this.txDesProducto.TabIndex = 3;
            // 
            // btTraer
            // 
            this.btTraer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTraer.Location = new System.Drawing.Point(299, 14);
            this.btTraer.Name = "btTraer";
            this.btTraer.Size = new System.Drawing.Size(157, 38);
            this.btTraer.TabIndex = 4;
            this.btTraer.Text = "Traer";
            this.btTraer.UseVisualStyleBackColor = true;
            this.btTraer.Click += new System.EventHandler(this.btTraer_Click);
            // 
            // btAlta
            // 
            this.btAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAlta.Location = new System.Drawing.Point(24, 115);
            this.btAlta.Name = "btAlta";
            this.btAlta.Size = new System.Drawing.Size(155, 58);
            this.btAlta.TabIndex = 5;
            this.btAlta.Text = "&Alta";
            this.btAlta.UseVisualStyleBackColor = true;
            this.btAlta.Click += new System.EventHandler(this.btAlta_Click);
            // 
            // btLimpia
            // 
            this.btLimpia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLimpia.Location = new System.Drawing.Point(221, 115);
            this.btLimpia.Name = "btLimpia";
            this.btLimpia.Size = new System.Drawing.Size(155, 58);
            this.btLimpia.TabIndex = 6;
            this.btLimpia.Text = "&Limpiar";
            this.btLimpia.UseVisualStyleBackColor = true;
            this.btLimpia.Click += new System.EventHandler(this.btLimpia_Click);
            // 
            // btCerrar
            // 
            this.btCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCerrar.Location = new System.Drawing.Point(495, 115);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(155, 58);
            this.btCerrar.TabIndex = 7;
            this.btCerrar.Text = "&Cerrar";
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // frmNuevoAnexo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 187);
            this.ControlBox = false;
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.btLimpia);
            this.Controls.Add(this.btAlta);
            this.Controls.Add(this.btTraer);
            this.Controls.Add(this.txDesProducto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txProducto);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmNuevoAnexo";
            this.Text = "Nuevo Anexo Articulo";
            this.Load += new System.EventHandler(this.frmNuevoAnexo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txDesProducto;
        private System.Windows.Forms.Button btTraer;
        private System.Windows.Forms.Button btAlta;
        private System.Windows.Forms.Button btLimpia;
        private System.Windows.Forms.Button btCerrar;
    }
}