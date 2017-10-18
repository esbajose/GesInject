namespace GesInject.Formularios
{
    partial class frmEtiCajaMan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEtiCajaMan));
            this.btProd = new System.Windows.Forms.Button();
            this.txProd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txNomProd = new System.Windows.Forms.TextBox();
            this.txProdCli = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btCliente = new System.Windows.Forms.Button();
            this.txCodCli = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txNomCli = new System.Windows.Forms.TextBox();
            this.txLote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txPiezasCaja = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txOper = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txCaja = new System.Windows.Forms.TextBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.btImprimir = new System.Windows.Forms.Button();
            this.btCerrar = new System.Windows.Forms.Button();
            this.btLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // btProd
            // 
            this.btProd.Image = ((System.Drawing.Image)(resources.GetObject("btProd.Image")));
            this.btProd.Location = new System.Drawing.Point(217, 30);
            this.btProd.Name = "btProd";
            this.btProd.Size = new System.Drawing.Size(21, 22);
            this.btProd.TabIndex = 68;
            this.btProd.UseVisualStyleBackColor = true;
            this.btProd.Click += new System.EventHandler(this.btProd_Click);
            // 
            // txProd
            // 
            this.txProd.Location = new System.Drawing.Point(104, 31);
            this.txProd.Name = "txProd";
            this.txProd.Size = new System.Drawing.Size(113, 20);
            this.txProd.TabIndex = 66;
            this.txProd.Tag = "bind#Articulo#Text";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Prod. Cronomol";
            // 
            // txNomProd
            // 
            this.txNomProd.Location = new System.Drawing.Point(244, 31);
            this.txNomProd.Name = "txNomProd";
            this.txNomProd.Size = new System.Drawing.Size(325, 20);
            this.txNomProd.TabIndex = 69;
            this.txNomProd.Tag = "bind#Articulo#Text";
            // 
            // txProdCli
            // 
            this.txProdCli.Location = new System.Drawing.Point(103, 94);
            this.txProdCli.Name = "txProdCli";
            this.txProdCli.Size = new System.Drawing.Size(113, 20);
            this.txProdCli.TabIndex = 74;
            this.txProdCli.Tag = "bind#ArticuloCli#Text";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 75;
            this.label6.Text = "Prod. cliente";
            // 
            // btCliente
            // 
            this.btCliente.Image = ((System.Drawing.Image)(resources.GetObject("btCliente.Image")));
            this.btCliente.Location = new System.Drawing.Point(165, 64);
            this.btCliente.Name = "btCliente";
            this.btCliente.Size = new System.Drawing.Size(21, 22);
            this.btCliente.TabIndex = 73;
            this.btCliente.UseVisualStyleBackColor = true;
            this.btCliente.Click += new System.EventHandler(this.btCliente_Click);
            // 
            // txCodCli
            // 
            this.txCodCli.BackColor = System.Drawing.Color.White;
            this.txCodCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txCodCli.Location = new System.Drawing.Point(103, 63);
            this.txCodCli.Name = "txCodCli";
            this.txCodCli.Size = new System.Drawing.Size(60, 21);
            this.txCodCli.TabIndex = 70;
            this.txCodCli.Tag = "bind#CodCli#Text";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 71;
            this.label3.Text = "Cliente";
            // 
            // txNomCli
            // 
            this.txNomCli.BackColor = System.Drawing.Color.White;
            this.txNomCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txNomCli.Location = new System.Drawing.Point(192, 63);
            this.txNomCli.Name = "txNomCli";
            this.txNomCli.Size = new System.Drawing.Size(377, 21);
            this.txNomCli.TabIndex = 76;
            this.txNomCli.Tag = "bind#CodCli#Text";
            // 
            // txLote
            // 
            this.txLote.Location = new System.Drawing.Point(103, 128);
            this.txLote.Name = "txLote";
            this.txLote.Size = new System.Drawing.Size(113, 20);
            this.txLote.TabIndex = 77;
            this.txLote.Tag = "bind#ArticuloCli#Text";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "Nº OF / Lote";
            // 
            // txPiezasCaja
            // 
            this.txPiezasCaja.Location = new System.Drawing.Point(103, 164);
            this.txPiezasCaja.Name = "txPiezasCaja";
            this.txPiezasCaja.Size = new System.Drawing.Size(113, 20);
            this.txPiezasCaja.TabIndex = 79;
            this.txPiezasCaja.Tag = "bind#ArticuloCli#Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 80;
            this.label2.Text = "Piezas Caja/Bolsa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 82;
            this.label5.Text = "Fecha de Fabr:";
            // 
            // dateFecha
            // 
            this.dateFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFecha.Location = new System.Drawing.Point(103, 199);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(113, 20);
            this.dateFecha.TabIndex = 83;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 86;
            this.label8.Text = "Operario";
            // 
            // txOper
            // 
            this.txOper.Location = new System.Drawing.Point(104, 230);
            this.txOper.Name = "txOper";
            this.txOper.Size = new System.Drawing.Size(66, 20);
            this.txOper.TabIndex = 87;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 88;
            this.label9.Text = "Caja";
            // 
            // txCaja
            // 
            this.txCaja.Location = new System.Drawing.Point(104, 261);
            this.txCaja.Name = "txCaja";
            this.txCaja.Size = new System.Drawing.Size(66, 20);
            this.txCaja.TabIndex = 89;
            // 
            // pic1
            // 
            this.pic1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic1.Location = new System.Drawing.Point(255, 90);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(100, 127);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic1.TabIndex = 90;
            this.pic1.TabStop = false;
            // 
            // btImprimir
            // 
            this.btImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImprimir.Location = new System.Drawing.Point(12, 331);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(140, 60);
            this.btImprimir.TabIndex = 91;
            this.btImprimir.Text = "&Imprimir";
            this.btImprimir.UseVisualStyleBackColor = false;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // btCerrar
            // 
            this.btCerrar.BackColor = System.Drawing.SystemColors.Control;
            this.btCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCerrar.Location = new System.Drawing.Point(408, 331);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(140, 60);
            this.btCerrar.TabIndex = 92;
            this.btCerrar.Text = "&Salir";
            this.btCerrar.UseVisualStyleBackColor = false;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // btLimpiar
            // 
            this.btLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLimpiar.Location = new System.Drawing.Point(408, 120);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(140, 60);
            this.btLimpiar.TabIndex = 93;
            this.btLimpiar.Text = "&Limpiar";
            this.btLimpiar.UseVisualStyleBackColor = false;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // frmEtiCajaMan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 403);
            this.Controls.Add(this.btLimpiar);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.btImprimir);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txCaja);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txOper);
            this.Controls.Add(this.dateFecha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txPiezasCaja);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txLote);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txNomCli);
            this.Controls.Add(this.txProdCli);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btCliente);
            this.Controls.Add(this.txCodCli);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txNomProd);
            this.Controls.Add(this.btProd);
            this.Controls.Add(this.txProd);
            this.Controls.Add(this.label4);
            this.Name = "frmEtiCajaMan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Etiqueta Caja/Bolsa Manual";
            this.Load += new System.EventHandler(this.frmEtiCajaMan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btProd;
        private System.Windows.Forms.TextBox txProd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txNomProd;
        private System.Windows.Forms.TextBox txProdCli;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btCliente;
        private System.Windows.Forms.TextBox txCodCli;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txNomCli;
        private System.Windows.Forms.TextBox txLote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txPiezasCaja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txOper;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txCaja;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.Button btImprimir;
        private System.Windows.Forms.Button btCerrar;
        private System.Windows.Forms.Button btLimpiar;

    }
}