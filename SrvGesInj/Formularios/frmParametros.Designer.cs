namespace SrvGesInj.Formularios
{
    partial class frmParametros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametros));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chActCli = new System.Windows.Forms.CheckBox();
            this.chActProv = new System.Windows.Forms.CheckBox();
            this.btSerCli = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txOrdAlbCli = new System.Windows.Forms.TextBox();
            this.btSerProv = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txOrdAlbProv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txPassAdmin = new System.Windows.Forms.TextBox();
            this.gB1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txUsuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txPassUserDB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txBDProd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txSrvProd = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txDirXML = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btDirXml = new System.Windows.Forms.Button();
            this.txDirDBF = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btDirDocMec = new System.Windows.Forms.Button();
            this.btCerrar = new System.Windows.Forms.Button();
            this.btGrabar = new System.Windows.Forms.Button();
            this.txPass = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.fB1 = new System.Windows.Forms.FolderBrowserDialog();
            this.print1 = new System.Windows.Forms.PrintDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btSerPedCli = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txOrdPedCli = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gB1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(12, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(565, 428);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.btSerPedCli);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txOrdPedCli);
            this.tabPage1.Controls.Add(this.chActCli);
            this.tabPage1.Controls.Add(this.chActProv);
            this.tabPage1.Controls.Add(this.btSerCli);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txOrdAlbCli);
            this.tabPage1.Controls.Add(this.btSerProv);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txOrdAlbProv);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txPassAdmin);
            this.tabPage1.Controls.Add(this.gB1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(557, 402);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Base de Datos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chActCli
            // 
            this.chActCli.AutoSize = true;
            this.chActCli.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chActCli.Location = new System.Drawing.Point(182, 209);
            this.chActCli.Name = "chActCli";
            this.chActCli.Size = new System.Drawing.Size(132, 17);
            this.chActCli.TabIndex = 83;
            this.chActCli.Tag = "ActCli#Activar proceso Clientes#L#False";
            this.chActCli.Text = "Activar Albares Cliente";
            this.chActCli.UseVisualStyleBackColor = true;
            // 
            // chActProv
            // 
            this.chActProv.AutoSize = true;
            this.chActProv.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chActProv.Location = new System.Drawing.Point(182, 183);
            this.chActProv.Name = "chActProv";
            this.chActProv.Size = new System.Drawing.Size(149, 17);
            this.chActProv.TabIndex = 82;
            this.chActProv.Tag = "ActProv#Activar proceso Proveedores#L#False";
            this.chActProv.Text = "Activar Albares Proveedor";
            this.chActProv.UseVisualStyleBackColor = true;
            // 
            // btSerCli
            // 
            this.btSerCli.Image = ((System.Drawing.Image)(resources.GetObject("btSerCli.Image")));
            this.btSerCli.Location = new System.Drawing.Point(155, 206);
            this.btSerCli.Name = "btSerCli";
            this.btSerCli.Size = new System.Drawing.Size(21, 22);
            this.btSerCli.TabIndex = 69;
            this.btSerCli.UseVisualStyleBackColor = true;
            this.btSerCli.Click += new System.EventHandler(this.btSerCli_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Serie AlbCli";
            // 
            // txOrdAlbCli
            // 
            this.txOrdAlbCli.Location = new System.Drawing.Point(89, 206);
            this.txOrdAlbCli.Name = "txOrdAlbCli";
            this.txOrdAlbCli.Size = new System.Drawing.Size(65, 20);
            this.txOrdAlbCli.TabIndex = 68;
            this.txOrdAlbCli.Tag = "NSerOrdAlbCli#Numero de serie Albaranes de Clientes#L";
            // 
            // btSerProv
            // 
            this.btSerProv.Image = ((System.Drawing.Image)(resources.GetObject("btSerProv.Image")));
            this.btSerProv.Location = new System.Drawing.Point(155, 180);
            this.btSerProv.Name = "btSerProv";
            this.btSerProv.Size = new System.Drawing.Size(21, 22);
            this.btSerProv.TabIndex = 66;
            this.btSerProv.UseVisualStyleBackColor = true;
            this.btSerProv.Click += new System.EventHandler(this.btSerProv_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 64;
            this.label8.Text = "Serie AlbProv";
            // 
            // txOrdAlbProv
            // 
            this.txOrdAlbProv.Location = new System.Drawing.Point(89, 180);
            this.txOrdAlbProv.Name = "txOrdAlbProv";
            this.txOrdAlbProv.Size = new System.Drawing.Size(65, 20);
            this.txOrdAlbProv.TabIndex = 65;
            this.txOrdAlbProv.Tag = "NSerOrdAlbProv#Numero de serie Albaranes de Proveedor#L";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Contraseña de Administrador";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txPassAdmin
            // 
            this.txPassAdmin.Location = new System.Drawing.Point(155, 358);
            this.txPassAdmin.Name = "txPassAdmin";
            this.txPassAdmin.PasswordChar = '*';
            this.txPassAdmin.Size = new System.Drawing.Size(179, 20);
            this.txPassAdmin.TabIndex = 29;
            this.txPassAdmin.Tag = "PassAdmin#Password Administrador#P";
            // 
            // gB1
            // 
            this.gB1.Controls.Add(this.label6);
            this.gB1.Controls.Add(this.txUsuario);
            this.gB1.Controls.Add(this.label5);
            this.gB1.Controls.Add(this.txPassUserDB);
            this.gB1.Controls.Add(this.label3);
            this.gB1.Controls.Add(this.txBDProd);
            this.gB1.Controls.Add(this.label2);
            this.gB1.Controls.Add(this.txSrvProd);
            this.gB1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gB1.Location = new System.Drawing.Point(6, 6);
            this.gB1.Name = "gB1";
            this.gB1.Size = new System.Drawing.Size(433, 135);
            this.gB1.TabIndex = 23;
            this.gB1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(231, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Contraseña";
            // 
            // txUsuario
            // 
            this.txUsuario.Location = new System.Drawing.Point(9, 88);
            this.txUsuario.Name = "txUsuario";
            this.txUsuario.Size = new System.Drawing.Size(125, 20);
            this.txUsuario.TabIndex = 26;
            this.txUsuario.TabStop = false;
            this.txUsuario.Tag = "UsuarioBD#Usuario#L";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Usuario";
            // 
            // txPassUserDB
            // 
            this.txPassUserDB.Location = new System.Drawing.Point(234, 88);
            this.txPassUserDB.Name = "txPassUserDB";
            this.txPassUserDB.PasswordChar = '*';
            this.txPassUserDB.Size = new System.Drawing.Size(179, 20);
            this.txPassUserDB.TabIndex = 27;
            this.txPassUserDB.Tag = "PassUserBD#Password Usuario#P";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Base de Datos (Producción)";
            // 
            // txBDProd
            // 
            this.txBDProd.Location = new System.Drawing.Point(234, 32);
            this.txBDProd.Name = "txBDProd";
            this.txBDProd.Size = new System.Drawing.Size(179, 20);
            this.txBDProd.TabIndex = 23;
            this.txBDProd.Tag = "BD#Base de datos #L";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Servidor (Producción)";
            // 
            // txSrvProd
            // 
            this.txSrvProd.Location = new System.Drawing.Point(6, 32);
            this.txSrvProd.Name = "txSrvProd";
            this.txSrvProd.Size = new System.Drawing.Size(171, 20);
            this.txSrvProd.TabIndex = 21;
            this.txSrvProd.TabStop = false;
            this.txSrvProd.Tag = "Srv#Servidor #L";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txDirXML);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.btDirXml);
            this.tabPage3.Controls.Add(this.txDirDBF);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.btDirDocMec);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(557, 344);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Directorios";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txDirXML
            // 
            this.txDirXML.AcceptsReturn = true;
            this.txDirXML.Location = new System.Drawing.Point(12, 69);
            this.txDirXML.Name = "txDirXML";
            this.txDirXML.ReadOnly = true;
            this.txDirXML.Size = new System.Drawing.Size(407, 20);
            this.txDirXML.TabIndex = 84;
            this.txDirXML.TabStop = false;
            this.txDirXML.Tag = "DirXML#Directorio para Ficheros XML#L";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 13);
            this.label9.TabIndex = 85;
            this.label9.Text = "Directorio para Ficheros XML";
            // 
            // btDirXml
            // 
            this.btDirXml.Location = new System.Drawing.Point(420, 66);
            this.btDirXml.Name = "btDirXml";
            this.btDirXml.Size = new System.Drawing.Size(21, 23);
            this.btDirXml.TabIndex = 86;
            this.btDirXml.Text = "...";
            this.btDirXml.UseVisualStyleBackColor = true;
            this.btDirXml.Click += new System.EventHandler(this.btDirXml_Click);
            // 
            // txDirDBF
            // 
            this.txDirDBF.AcceptsReturn = true;
            this.txDirDBF.Location = new System.Drawing.Point(12, 29);
            this.txDirDBF.Name = "txDirDBF";
            this.txDirDBF.ReadOnly = true;
            this.txDirDBF.Size = new System.Drawing.Size(407, 20);
            this.txDirDBF.TabIndex = 81;
            this.txDirDBF.TabStop = false;
            this.txDirDBF.Tag = "DirDocDbf#Directorio para bases de datos dbf#L";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(172, 13);
            this.label17.TabIndex = 82;
            this.label17.Text = "Directorio para Bases de Datos dbf";
            // 
            // btDirDocMec
            // 
            this.btDirDocMec.Location = new System.Drawing.Point(420, 26);
            this.btDirDocMec.Name = "btDirDocMec";
            this.btDirDocMec.Size = new System.Drawing.Size(21, 23);
            this.btDirDocMec.TabIndex = 83;
            this.btDirDocMec.Text = "...";
            this.btDirDocMec.UseVisualStyleBackColor = true;
            this.btDirDocMec.Click += new System.EventHandler(this.btDirDocMec_Click);
            // 
            // btCerrar
            // 
            this.btCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerrar.Location = new System.Drawing.Point(498, 482);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(75, 23);
            this.btCerrar.TabIndex = 9;
            this.btCerrar.Text = "&Cerrar";
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // btGrabar
            // 
            this.btGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btGrabar.Location = new System.Drawing.Point(12, 482);
            this.btGrabar.Name = "btGrabar";
            this.btGrabar.Size = new System.Drawing.Size(75, 23);
            this.btGrabar.TabIndex = 8;
            this.btGrabar.Text = "&Grabar";
            this.btGrabar.UseVisualStyleBackColor = true;
            this.btGrabar.Click += new System.EventHandler(this.btGrabar_Click);
            // 
            // txPass
            // 
            this.txPass.Location = new System.Drawing.Point(214, 12);
            this.txPass.Name = "txPass";
            this.txPass.PasswordChar = '*';
            this.txPass.Size = new System.Drawing.Size(179, 20);
            this.txPass.TabIndex = 71;
            this.txPass.TextChanged += new System.EventHandler(this.txPass_TextChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(15, 17);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(193, 15);
            this.label30.TabIndex = 70;
            this.label30.Text = "Contraseña de Administrador";
            // 
            // print1
            // 
            this.print1.UseEXDialog = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Location = new System.Drawing.Point(182, 246);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(135, 17);
            this.checkBox1.TabIndex = 87;
            this.checkBox1.Tag = "ActPedCli#Activar proceso Pedidos Clientes#L#False";
            this.checkBox1.Text = "Activar Pedidos Cliente";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btSerPedCli
            // 
            this.btSerPedCli.Image = ((System.Drawing.Image)(resources.GetObject("btSerPedCli.Image")));
            this.btSerPedCli.Location = new System.Drawing.Point(155, 243);
            this.btSerPedCli.Name = "btSerPedCli";
            this.btSerPedCli.Size = new System.Drawing.Size(21, 22);
            this.btSerPedCli.TabIndex = 86;
            this.btSerPedCli.UseVisualStyleBackColor = true;
            this.btSerPedCli.Click += new System.EventHandler(this.btSerPedCli_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 84;
            this.label7.Text = "Serie PedCli";
            // 
            // txOrdPedCli
            // 
            this.txOrdPedCli.Location = new System.Drawing.Point(89, 243);
            this.txOrdPedCli.Name = "txOrdPedCli";
            this.txOrdPedCli.Size = new System.Drawing.Size(65, 20);
            this.txOrdPedCli.TabIndex = 85;
            this.txOrdPedCli.Tag = "NSerPedCli#Numero de serie Pedidos de Clientes#L";
            // 
            // frmParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 517);
            this.Controls.Add(this.txPass);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.btGrabar);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmParametros";
            this.Text = "Parametros de la Aplicación";
            this.Load += new System.EventHandler(this.frmParametros_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gB1.ResumeLayout(false);
            this.gB1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gB1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txPassUserDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txBDProd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txSrvProd;
        private System.Windows.Forms.Button btCerrar;
        private System.Windows.Forms.Button btGrabar;
        private System.Windows.Forms.TextBox txPass;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txPassAdmin;
        private System.Windows.Forms.FolderBrowserDialog fB1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txDirXML;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btDirXml;
        private System.Windows.Forms.TextBox txDirDBF;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btDirDocMec;
        private System.Windows.Forms.PrintDialog print1;
        private System.Windows.Forms.Button btSerProv;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txOrdAlbProv;
        private System.Windows.Forms.Button btSerCli;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txOrdAlbCli;
        private System.Windows.Forms.CheckBox chActCli;
        private System.Windows.Forms.CheckBox chActProv;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btSerPedCli;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txOrdPedCli;
    }
}