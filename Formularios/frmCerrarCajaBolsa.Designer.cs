namespace GesInject.Formularios
{
    partial class frmCerrarCajaBolsa
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
            this.opCaja = new System.Windows.Forms.RadioButton();
            this.opBolsa = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txCan = new jControles.jTextBox();
            this.btCerrar = new System.Windows.Forms.Button();
            this.btValidar = new System.Windows.Forms.Button();
            this.lbOper = new System.Windows.Forms.Label();
            this.btCambiarCan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // opCaja
            // 
            this.opCaja.AutoSize = true;
            this.opCaja.Checked = true;
            this.opCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opCaja.Location = new System.Drawing.Point(26, 31);
            this.opCaja.Name = "opCaja";
            this.opCaja.Size = new System.Drawing.Size(74, 29);
            this.opCaja.TabIndex = 0;
            this.opCaja.TabStop = true;
            this.opCaja.Text = "Caja";
            this.opCaja.UseVisualStyleBackColor = true;
            this.opCaja.CheckedChanged += new System.EventHandler(this.opCaja_CheckedChanged);
            // 
            // opBolsa
            // 
            this.opBolsa.AutoSize = true;
            this.opBolsa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opBolsa.Location = new System.Drawing.Point(168, 31);
            this.opBolsa.Name = "opBolsa";
            this.opBolsa.Size = new System.Drawing.Size(84, 29);
            this.opBolsa.TabIndex = 1;
            this.opBolsa.Text = "Bolsa";
            this.opBolsa.UseVisualStyleBackColor = true;
            this.opBolsa.CheckedChanged += new System.EventHandler(this.opBolsa_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cantidad";
            // 
            // txCan
            // 
            this.txCan.Decimales = 0;
            this.txCan.Enabled = false;
            this.txCan.EnterTab = false;
            this.txCan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txCan.Location = new System.Drawing.Point(118, 142);
            this.txCan.Name = "txCan";
            this.txCan.Numerico = true;
            this.txCan.ReadOnly = true;
            this.txCan.Size = new System.Drawing.Size(176, 31);
            this.txCan.TabIndex = 64;
            this.txCan.Tag = "bind#Cantidad#Text";
            this.txCan.Text = "0";
            // 
            // btCerrar
            // 
            this.btCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCerrar.Location = new System.Drawing.Point(195, 231);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(114, 50);
            this.btCerrar.TabIndex = 65;
            this.btCerrar.Text = "&Cancelar";
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // btValidar
            // 
            this.btValidar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btValidar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btValidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btValidar.Location = new System.Drawing.Point(6, 231);
            this.btValidar.Name = "btValidar";
            this.btValidar.Size = new System.Drawing.Size(114, 50);
            this.btValidar.TabIndex = 66;
            this.btValidar.Text = "&Validar";
            this.btValidar.UseVisualStyleBackColor = false;
            this.btValidar.Click += new System.EventHandler(this.btValidar_Click);
            // 
            // lbOper
            // 
            this.lbOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOper.Location = new System.Drawing.Point(14, 90);
            this.lbOper.Name = "lbOper";
            this.lbOper.Size = new System.Drawing.Size(295, 25);
            this.lbOper.TabIndex = 67;
            this.lbOper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btCambiarCan
            // 
            this.btCambiarCan.BackColor = System.Drawing.Color.IndianRed;
            this.btCambiarCan.Location = new System.Drawing.Point(118, 179);
            this.btCambiarCan.Name = "btCambiarCan";
            this.btCambiarCan.Size = new System.Drawing.Size(176, 34);
            this.btCambiarCan.TabIndex = 68;
            this.btCambiarCan.Text = "Cambiar Cantidad";
            this.btCambiarCan.UseVisualStyleBackColor = false;
            this.btCambiarCan.Click += new System.EventHandler(this.btCambiarCan_Click);
            // 
            // frmCerrarCajaBolsa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 293);
            this.Controls.Add(this.btCambiarCan);
            this.Controls.Add(this.lbOper);
            this.Controls.Add(this.btValidar);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.txCan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.opBolsa);
            this.Controls.Add(this.opCaja);
            this.Name = "frmCerrarCajaBolsa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cerrar Caja/Bolsa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCerrarCajaBolsa_FormClosing);
            this.Load += new System.EventHandler(this.frmCerrarCajaBolsa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton opCaja;
        private System.Windows.Forms.RadioButton opBolsa;
        private System.Windows.Forms.Label label1;
        private jControles.jTextBox txCan;
        private System.Windows.Forms.Button btCerrar;
        private System.Windows.Forms.Button btValidar;
        private System.Windows.Forms.Label lbOper;
        private System.Windows.Forms.Button btCambiarCan;
    }
}