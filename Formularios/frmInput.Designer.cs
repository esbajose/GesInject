namespace GesInject.Formularios
{
    partial class frmInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInput));
            this.btAceptar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.txRes = new System.Windows.Forms.TextBox();
            this.lbText = new System.Windows.Forms.Label();
            this.cbLista = new System.Windows.Forms.ComboBox();
            this.btRel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btAceptar
            // 
            this.btAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btAceptar.Location = new System.Drawing.Point(12, 67);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 2;
            this.btAceptar.Text = "&Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelar.Location = new System.Drawing.Point(147, 67);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 3;
            this.btCancelar.Text = "&Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // txRes
            // 
            this.txRes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txRes.Location = new System.Drawing.Point(12, 26);
            this.txRes.Name = "txRes";
            this.txRes.Size = new System.Drawing.Size(198, 20);
            this.txRes.TabIndex = 1;
            this.txRes.Visible = false;
            this.txRes.TextChanged += new System.EventHandler(this.txRes_TextChanged);
            this.txRes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txRes_KeyUp);
            // 
            // lbText
            // 
            this.lbText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbText.Location = new System.Drawing.Point(12, 9);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(210, 14);
            this.lbText.TabIndex = 3;
            // 
            // cbLista
            // 
            this.cbLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLista.FormattingEnabled = true;
            this.cbLista.Location = new System.Drawing.Point(15, 25);
            this.cbLista.Name = "cbLista";
            this.cbLista.Size = new System.Drawing.Size(207, 21);
            this.cbLista.TabIndex = 4;
            this.cbLista.Visible = false;
            this.cbLista.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txRes_KeyUp);
            // 
            // btRel
            // 
            this.btRel.Image = ((System.Drawing.Image)(resources.GetObject("btRel.Image")));
            this.btRel.Location = new System.Drawing.Point(210, 26);
            this.btRel.Name = "btRel";
            this.btRel.Size = new System.Drawing.Size(20, 20);
            this.btRel.TabIndex = 39;
            this.btRel.UseVisualStyleBackColor = true;
            this.btRel.Visible = false;
            this.btRel.Click += new System.EventHandler(this.btRel_Click);
            // 
            // frmInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 91);
            this.Controls.Add(this.btRel);
            this.Controls.Add(this.cbLista);
            this.Controls.Add(this.lbText);
            this.Controls.Add(this.txRes);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Name = "frmInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInput_FormClosing);
            this.Load += new System.EventHandler(this.frmInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.TextBox txRes;
        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.ComboBox cbLista;
        private System.Windows.Forms.Button btRel;
    }
}