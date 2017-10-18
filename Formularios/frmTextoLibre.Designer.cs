namespace GesInject.Formularios
{
    partial class frmTextoLibre
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
            this.nuLineas = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chLogo = new System.Windows.Forms.CheckBox();
            this.chCentra = new System.Windows.Forms.CheckBox();
            this.panelAct = new System.Windows.Forms.Panel();
            this.btImprimir = new System.Windows.Forms.Button();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.btCerrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numCan = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nuLineas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCan)).BeginInit();
            this.SuspendLayout();
            // 
            // nuLineas
            // 
            this.nuLineas.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuLineas.Location = new System.Drawing.Point(170, 20);
            this.nuLineas.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nuLineas.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nuLineas.Name = "nuLineas";
            this.nuLineas.Size = new System.Drawing.Size(53, 47);
            this.nuLineas.TabIndex = 0;
            this.nuLineas.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nuLineas.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nº de Lineas";
            // 
            // chLogo
            // 
            this.chLogo.AutoSize = true;
            this.chLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chLogo.Location = new System.Drawing.Point(247, 12);
            this.chLogo.Name = "chLogo";
            this.chLogo.Size = new System.Drawing.Size(132, 29);
            this.chLogo.TabIndex = 2;
            this.chLogo.Text = "Con Logo";
            this.chLogo.UseVisualStyleBackColor = true;
            // 
            // chCentra
            // 
            this.chCentra.AutoSize = true;
            this.chCentra.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chCentra.Location = new System.Drawing.Point(247, 47);
            this.chCentra.Name = "chCentra";
            this.chCentra.Size = new System.Drawing.Size(193, 29);
            this.chCentra.TabIndex = 3;
            this.chCentra.Text = "Texto Centrado";
            this.chCentra.UseVisualStyleBackColor = true;
            // 
            // panelAct
            // 
            this.panelAct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAct.Location = new System.Drawing.Point(12, 79);
            this.panelAct.Name = "panelAct";
            this.panelAct.Size = new System.Drawing.Size(486, 331);
            this.panelAct.TabIndex = 4;
            // 
            // btImprimir
            // 
            this.btImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImprimir.Location = new System.Drawing.Point(16, 485);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(112, 43);
            this.btImprimir.TabIndex = 5;
            this.btImprimir.Text = "&Imprimir";
            this.btImprimir.UseVisualStyleBackColor = false;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // btLimpiar
            // 
            this.btLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLimpiar.Location = new System.Drawing.Point(179, 485);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(112, 43);
            this.btLimpiar.TabIndex = 6;
            this.btLimpiar.Text = "&Limpiar";
            this.btLimpiar.UseVisualStyleBackColor = false;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // btCerrar
            // 
            this.btCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCerrar.Location = new System.Drawing.Point(386, 485);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(112, 43);
            this.btCerrar.TabIndex = 7;
            this.btCerrar.Text = "&Cerrar";
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 430);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nº de Etiquetas";
            // 
            // numCan
            // 
            this.numCan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numCan.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCan.Location = new System.Drawing.Point(198, 421);
            this.numCan.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numCan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCan.Name = "numCan";
            this.numCan.Size = new System.Drawing.Size(81, 40);
            this.numCan.TabIndex = 8;
            this.numCan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmTextoLibre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 533);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numCan);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.btLimpiar);
            this.Controls.Add(this.btImprimir);
            this.Controls.Add(this.panelAct);
            this.Controls.Add(this.chCentra);
            this.Controls.Add(this.chLogo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nuLineas);
            this.Name = "frmTextoLibre";
            this.Text = "Etiqueta de Texto Libre";
            this.Load += new System.EventHandler(this.frmTextoLibre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nuLineas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nuLineas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chLogo;
        private System.Windows.Forms.CheckBox chCentra;
        private System.Windows.Forms.Panel panelAct;
        private System.Windows.Forms.Button btImprimir;
        private System.Windows.Forms.Button btLimpiar;
        private System.Windows.Forms.Button btCerrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numCan;
    }
}