namespace SrvGesInj.Formularios
{
    partial class frmSrvGesInj
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSrvGesInj));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametrosDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btActivar = new System.Windows.Forms.Button();
            this.tiProces = new System.Windows.Forms.Timer(this.components);
            this.Icon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.pB1 = new System.Windows.Forms.ProgressBar();
            this.tipB = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbMen = new System.Windows.Forms.Label();
            this.lbError = new System.Windows.Forms.Label();
            this.txSql = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(304, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parametrosDelSistemaToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Tag = "Sistema";
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // parametrosDelSistemaToolStripMenuItem
            // 
            this.parametrosDelSistemaToolStripMenuItem.Name = "parametrosDelSistemaToolStripMenuItem";
            this.parametrosDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.parametrosDelSistemaToolStripMenuItem.Tag = "";
            this.parametrosDelSistemaToolStripMenuItem.Text = "&Parametros del sistema";
            this.parametrosDelSistemaToolStripMenuItem.Click += new System.EventHandler(this.parametrosDelSistemaToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.salirToolStripMenuItem.Tag = "Sistema";
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // btActivar
            // 
            this.btActivar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActivar.Location = new System.Drawing.Point(60, 107);
            this.btActivar.Name = "btActivar";
            this.btActivar.Size = new System.Drawing.Size(195, 93);
            this.btActivar.TabIndex = 7;
            this.btActivar.Text = "&Detener";
            this.btActivar.UseVisualStyleBackColor = true;
            this.btActivar.Click += new System.EventHandler(this.btActivar_Click);
            // 
            // tiProces
            // 
            this.tiProces.Enabled = true;
            this.tiProces.Interval = 20000;
            this.tiProces.Tick += new System.EventHandler(this.tiProces_Tick);
            // 
            // Icon1
            // 
            this.Icon1.Icon = ((System.Drawing.Icon)(resources.GetObject("Icon1.Icon")));
            this.Icon1.Text = "Servicios GesInject";
            this.Icon1.Visible = true;
            this.Icon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Icon1_MouseDoubleClick);
            // 
            // pB1
            // 
            this.pB1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pB1.Location = new System.Drawing.Point(0, 529);
            this.pB1.Name = "pB1";
            this.pB1.Size = new System.Drawing.Size(304, 18);
            this.pB1.TabIndex = 8;
            // 
            // tipB
            // 
            this.tipB.Enabled = true;
            this.tipB.Interval = 500;
            this.tipB.Tick += new System.EventHandler(this.tipB_Tick);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(120, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(120, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Inmediato";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbMen
            // 
            this.lbMen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbMen.Location = new System.Drawing.Point(0, 217);
            this.lbMen.Name = "lbMen";
            this.lbMen.Size = new System.Drawing.Size(304, 23);
            this.lbMen.TabIndex = 11;
            this.lbMen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMen.DoubleClick += new System.EventHandler(this.lbMen_DoubleClick);
            // 
            // lbError
            // 
            this.lbError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbError.Location = new System.Drawing.Point(0, 271);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(304, 255);
            this.lbError.TabIndex = 12;
            this.lbError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txSql
            // 
            this.txSql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txSql.Location = new System.Drawing.Point(12, 284);
            this.txSql.Multiline = true;
            this.txSql.Name = "txSql";
            this.txSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txSql.Size = new System.Drawing.Size(280, 229);
            this.txSql.TabIndex = 13;
            this.txSql.Visible = false;
            // 
            // frmSrvGesInj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 547);
            this.Controls.Add(this.txSql);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.lbMen);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pB1);
            this.Controls.Add(this.btActivar);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmSrvGesInj";
            this.Text = "Servicios GesInject";
            this.Load += new System.EventHandler(this.frmSrvGesInj_Load);
            this.Resize += new System.EventHandler(this.frmSrvGesInj_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametrosDelSistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Button btActivar;
        private System.Windows.Forms.Timer tiProces;
        private System.Windows.Forms.NotifyIcon Icon1;
        private System.Windows.Forms.ProgressBar pB1;
        private System.Windows.Forms.Timer tipB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbMen;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.TextBox txSql;
    }
}