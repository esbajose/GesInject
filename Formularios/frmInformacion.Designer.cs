    partial class frmInformacion
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbTexto = new System.Windows.Forms.Label();
            this.PB1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTexto
            // 
            this.lbTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTexto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTexto.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTexto.Location = new System.Drawing.Point(12, 9);
            this.lbTexto.Name = "lbTexto";
            this.lbTexto.Size = new System.Drawing.Size(706, 95);
            this.lbTexto.TabIndex = 0;
            this.lbTexto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PB1
            // 
            this.PB1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PB1.Location = new System.Drawing.Point(12, 107);
            this.PB1.Name = "PB1";
            this.PB1.Size = new System.Drawing.Size(706, 10);
            this.PB1.TabIndex = 1;
            this.PB1.Click += new System.EventHandler(this.PB1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.Location = new System.Drawing.Point(12, 123);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(706, 23);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Cancelar";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // frmInformacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 147);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.PB1);
            this.Controls.Add(this.lbTexto);
            this.Name = "frmInformacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Información del Sistema";
            this.Load += new System.EventHandler(this.frmInformacion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTexto;
        private System.Windows.Forms.ProgressBar PB1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btCancel;
    }
