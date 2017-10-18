namespace GesInject.Formularios
{
    partial class frmDirEntrega
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDirEntrega));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCliente = new System.Windows.Forms.Button();
            this.lbNomCli = new System.Windows.Forms.Label();
            this.txCodCli = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.txId = new jControles.jTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txCP = new jControles.jTextBox();
            this.txProvincia = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txPoblación = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txdirección = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Navi1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btDel = new System.Windows.Forms.ToolStripButton();
            this.btAlta = new System.Windows.Forms.ToolStripButton();
            this.tool1 = new System.Windows.Forms.ToolStrip();
            this.toolImp = new System.Windows.Forms.ToolStripButton();
            this.toolVis = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolCortar = new System.Windows.Forms.ToolStripButton();
            this.toolCopiar = new System.Windows.Forms.ToolStripButton();
            this.toolPegar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolDes = new System.Windows.Forms.ToolStripButton();
            this.toolBus = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolFiltroCampo = new System.Windows.Forms.ToolStripButton();
            this.toolFiltroTabla = new System.Windows.Forms.ToolStripButton();
            this.toolQuitar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolLista = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ayudaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.bS1 = new System.Windows.Forms.BindingSource(this.components);
            this.btSel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Navi1)).BeginInit();
            this.Navi1.SuspendLayout();
            this.tool1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bS1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btCliente);
            this.panel1.Controls.Add(this.lbNomCli);
            this.panel1.Controls.Add(this.txCodCli);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(0, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 42);
            this.panel1.TabIndex = 0;
            // 
            // btCliente
            // 
            this.btCliente.Image = ((System.Drawing.Image)(resources.GetObject("btCliente.Image")));
            this.btCliente.Location = new System.Drawing.Point(173, 9);
            this.btCliente.Name = "btCliente";
            this.btCliente.Size = new System.Drawing.Size(21, 22);
            this.btCliente.TabIndex = 43;
            this.btCliente.UseVisualStyleBackColor = true;
            this.btCliente.Click += new System.EventHandler(this.btCliente_Click);
            // 
            // lbNomCli
            // 
            this.lbNomCli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNomCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNomCli.Location = new System.Drawing.Point(194, 9);
            this.lbNomCli.Name = "lbNomCli";
            this.lbNomCli.Size = new System.Drawing.Size(426, 21);
            this.lbNomCli.TabIndex = 42;
            this.lbNomCli.Tag = "";
            // 
            // txCodCli
            // 
            this.txCodCli.BackColor = System.Drawing.Color.White;
            this.txCodCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txCodCli.Location = new System.Drawing.Point(68, 8);
            this.txCodCli.Name = "txCodCli";
            this.txCodCli.Size = new System.Drawing.Size(105, 21);
            this.txCodCli.TabIndex = 40;
            this.txCodCli.Tag = "";
            this.txCodCli.TextChanged += new System.EventHandler(this.txCodCli_TextChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 41;
            this.label5.Text = "Cliente";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btSel);
            this.panel2.Controls.Add(this.btCancel);
            this.panel2.Controls.Add(this.txId);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txCP);
            this.panel2.Controls.Add(this.txProvincia);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.txPoblación);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txdirección);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.Navi1);
            this.panel2.Controls.Add(this.tool1);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(0, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(647, 279);
            this.panel2.TabIndex = 1;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.Location = new System.Drawing.Point(487, 209);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(138, 54);
            this.btCancel.TabIndex = 62;
            this.btCancel.Text = "&Cancelar";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // txId
            // 
            this.txId.Decimales = 0;
            this.txId.Enabled = false;
            this.txId.Location = new System.Drawing.Point(68, 47);
            this.txId.Name = "txId";
            this.txId.Numerico = true;
            this.txId.Size = new System.Drawing.Size(50, 20);
            this.txId.TabIndex = 61;
            this.txId.Tag = "bind#IdEntrega#Text";
            this.txId.Text = "0";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 60;
            this.label1.Text = "ID";
            // 
            // txCP
            // 
            this.txCP.Decimales = 0;
            this.txCP.Location = new System.Drawing.Point(383, 121);
            this.txCP.Name = "txCP";
            this.txCP.Numerico = true;
            this.txCP.Size = new System.Drawing.Size(50, 20);
            this.txCP.TabIndex = 58;
            this.txCP.Tag = "bind#CP#Text";
            this.txCP.Text = "00000";
            // 
            // txProvincia
            // 
            this.txProvincia.BackColor = System.Drawing.Color.White;
            this.txProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txProvincia.Location = new System.Drawing.Point(68, 146);
            this.txProvincia.Name = "txProvincia";
            this.txProvincia.Size = new System.Drawing.Size(284, 21);
            this.txProvincia.TabIndex = 56;
            this.txProvincia.Tag = "bind#Provincia#Text";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(4, 149);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 20);
            this.label15.TabIndex = 57;
            this.label15.Text = "Provincia";
            // 
            // txPoblación
            // 
            this.txPoblación.BackColor = System.Drawing.Color.White;
            this.txPoblación.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txPoblación.Location = new System.Drawing.Point(68, 119);
            this.txPoblación.Name = "txPoblación";
            this.txPoblación.Size = new System.Drawing.Size(284, 21);
            this.txPoblación.TabIndex = 54;
            this.txPoblación.Tag = "bind#Población#Text";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(4, 122);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 20);
            this.label13.TabIndex = 55;
            this.label13.Text = "Población";
            // 
            // txdirección
            // 
            this.txdirección.BackColor = System.Drawing.Color.White;
            this.txdirección.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txdirección.Location = new System.Drawing.Point(68, 92);
            this.txdirección.Name = "txdirección";
            this.txdirección.Size = new System.Drawing.Size(419, 21);
            this.txdirección.TabIndex = 52;
            this.txdirección.Tag = "bind#Dirección#Text";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(4, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 20);
            this.label12.TabIndex = 53;
            this.label12.Text = "Dirección";
            // 
            // Navi1
            // 
            this.Navi1.AddNewItem = null;
            this.Navi1.CountItem = this.bindingNavigatorCountItem;
            this.Navi1.DeleteItem = null;
            this.Navi1.Dock = System.Windows.Forms.DockStyle.None;
            this.Navi1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.btDel,
            this.btAlta});
            this.Navi1.Location = new System.Drawing.Point(173, 0);
            this.Navi1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.Navi1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.Navi1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.Navi1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.Navi1.Name = "Navi1";
            this.Navi1.PositionItem = this.bindingNavigatorPositionItem;
            this.Navi1.Size = new System.Drawing.Size(257, 25);
            this.Navi1.TabIndex = 16;
            this.Navi1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btDel
            // 
            this.btDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btDel.Image = ((System.Drawing.Image)(resources.GetObject("btDel.Image")));
            this.btDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(23, 22);
            this.btDel.Text = "Eliminar (F4)";
            // 
            // btAlta
            // 
            this.btAlta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btAlta.Image = ((System.Drawing.Image)(resources.GetObject("btAlta.Image")));
            this.btAlta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAlta.Name = "btAlta";
            this.btAlta.Size = new System.Drawing.Size(23, 22);
            this.btAlta.Text = "Nuevo (F3)";
            this.btAlta.Click += new System.EventHandler(this.btAlta_Click);
            // 
            // tool1
            // 
            this.tool1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tool1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tool1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolImp,
            this.toolVis,
            this.toolStripSeparator1,
            this.toolCortar,
            this.toolCopiar,
            this.toolPegar,
            this.toolStripSeparator2,
            this.toolDes,
            this.toolBus,
            this.toolStripSeparator3,
            this.toolFiltroCampo,
            this.toolFiltroTabla,
            this.toolQuitar,
            this.toolStripSeparator4,
            this.toolLista,
            this.toolStripSeparator5,
            this.ayudaToolStripButton});
            this.tool1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tool1.Location = new System.Drawing.Point(0, 0);
            this.tool1.Name = "tool1";
            this.tool1.Size = new System.Drawing.Size(643, 25);
            this.tool1.TabIndex = 15;
            this.tool1.Text = "toolStrip1";
            // 
            // toolImp
            // 
            this.toolImp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolImp.Image = ((System.Drawing.Image)(resources.GetObject("toolImp.Image")));
            this.toolImp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolImp.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.toolImp.MergeIndex = 1;
            this.toolImp.Name = "toolImp";
            this.toolImp.Size = new System.Drawing.Size(23, 22);
            this.toolImp.Text = "Imprimir";
            this.toolImp.Visible = false;
            // 
            // toolVis
            // 
            this.toolVis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolVis.Image = ((System.Drawing.Image)(resources.GetObject("toolVis.Image")));
            this.toolVis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolVis.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.toolVis.MergeIndex = 2;
            this.toolVis.Name = "toolVis";
            this.toolVis.Size = new System.Drawing.Size(23, 22);
            this.toolVis.Text = "Vista Preliminar";
            this.toolVis.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolCortar
            // 
            this.toolCortar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCortar.Image = ((System.Drawing.Image)(resources.GetObject("toolCortar.Image")));
            this.toolCortar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCortar.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.toolCortar.MergeIndex = 3;
            this.toolCortar.Name = "toolCortar";
            this.toolCortar.Size = new System.Drawing.Size(23, 22);
            // 
            // toolCopiar
            // 
            this.toolCopiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCopiar.Image = ((System.Drawing.Image)(resources.GetObject("toolCopiar.Image")));
            this.toolCopiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCopiar.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.toolCopiar.MergeIndex = 4;
            this.toolCopiar.Name = "toolCopiar";
            this.toolCopiar.Size = new System.Drawing.Size(23, 22);
            this.toolCopiar.Text = "Copiar";
            // 
            // toolPegar
            // 
            this.toolPegar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPegar.Image = ((System.Drawing.Image)(resources.GetObject("toolPegar.Image")));
            this.toolPegar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPegar.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.toolPegar.MergeIndex = 5;
            this.toolPegar.Name = "toolPegar";
            this.toolPegar.Size = new System.Drawing.Size(23, 22);
            this.toolPegar.Text = "Pegar";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolDes
            // 
            this.toolDes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDes.Image = ((System.Drawing.Image)(resources.GetObject("toolDes.Image")));
            this.toolDes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDes.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.toolDes.MergeIndex = 6;
            this.toolDes.Name = "toolDes";
            this.toolDes.Size = new System.Drawing.Size(23, 22);
            this.toolDes.Text = "Deshacer";
            this.toolDes.Visible = false;
            // 
            // toolBus
            // 
            this.toolBus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBus.Image = ((System.Drawing.Image)(resources.GetObject("toolBus.Image")));
            this.toolBus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBus.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.toolBus.MergeIndex = 7;
            this.toolBus.Name = "toolBus";
            this.toolBus.Size = new System.Drawing.Size(23, 22);
            this.toolBus.Text = "Buscar (Ctrl+B)";
            this.toolBus.Click += new System.EventHandler(this.toolBus_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolFiltroCampo
            // 
            this.toolFiltroCampo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolFiltroCampo.Image = ((System.Drawing.Image)(resources.GetObject("toolFiltroCampo.Image")));
            this.toolFiltroCampo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFiltroCampo.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.toolFiltroCampo.MergeIndex = 8;
            this.toolFiltroCampo.Name = "toolFiltroCampo";
            this.toolFiltroCampo.Size = new System.Drawing.Size(23, 22);
            this.toolFiltroCampo.Text = "Filtro de Campo";
            // 
            // toolFiltroTabla
            // 
            this.toolFiltroTabla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolFiltroTabla.Image = ((System.Drawing.Image)(resources.GetObject("toolFiltroTabla.Image")));
            this.toolFiltroTabla.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFiltroTabla.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.toolFiltroTabla.MergeIndex = 9;
            this.toolFiltroTabla.Name = "toolFiltroTabla";
            this.toolFiltroTabla.Size = new System.Drawing.Size(23, 22);
            this.toolFiltroTabla.Text = "Filtro de Tabla";
            this.toolFiltroTabla.Visible = false;
            // 
            // toolQuitar
            // 
            this.toolQuitar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolQuitar.Image = ((System.Drawing.Image)(resources.GetObject("toolQuitar.Image")));
            this.toolQuitar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolQuitar.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.toolQuitar.MergeIndex = 10;
            this.toolQuitar.Name = "toolQuitar";
            this.toolQuitar.Size = new System.Drawing.Size(23, 22);
            this.toolQuitar.Text = "Quitar Filtros";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolLista
            // 
            this.toolLista.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolLista.Image = ((System.Drawing.Image)(resources.GetObject("toolLista.Image")));
            this.toolLista.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLista.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.toolLista.MergeIndex = 15;
            this.toolLista.Name = "toolLista";
            this.toolLista.Size = new System.Drawing.Size(23, 22);
            this.toolLista.Text = "Lista";
            this.toolLista.Visible = false;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // ayudaToolStripButton
            // 
            this.ayudaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ayudaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ayudaToolStripButton.Image")));
            this.ayudaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ayudaToolStripButton.Name = "ayudaToolStripButton";
            this.ayudaToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ayudaToolStripButton.Text = "Ay&uda";
            // 
            // bS1
            // 
            this.bS1.DataSource = typeof(GesInject.Clases.cClientes.DirEntrega);
            this.bS1.CurrentItemChanged += new System.EventHandler(this.bS1_CurrentItemChanged);
            this.bS1.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bS1_ListChanged);
            this.bS1.PositionChanged += new System.EventHandler(this.bS1_PositionChanged);
            // 
            // btSel
            // 
            this.btSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btSel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSel.Location = new System.Drawing.Point(10, 209);
            this.btSel.Name = "btSel";
            this.btSel.Size = new System.Drawing.Size(138, 54);
            this.btSel.TabIndex = 63;
            this.btSel.Text = "&Seleccionar";
            this.btSel.UseVisualStyleBackColor = false;
            this.btSel.Visible = false;
            this.btSel.Click += new System.EventHandler(this.btSel_Click);
            // 
            // frmDirEntrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 344);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frmDirEntrega";
            this.Text = "Direcciones de entrega";
            this.Load += new System.EventHandler(this.frmDirEntrega_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmDirEntrega_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Navi1)).EndInit();
            this.Navi1.ResumeLayout(false);
            this.Navi1.PerformLayout();
            this.tool1.ResumeLayout(false);
            this.tool1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bS1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btCliente;
        private System.Windows.Forms.Label lbNomCli;
        private System.Windows.Forms.TextBox txCodCli;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingNavigator Navi1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton btDel;
        private System.Windows.Forms.ToolStripButton btAlta;
        private System.Windows.Forms.ToolStrip tool1;
        public System.Windows.Forms.ToolStripButton toolImp;
        private System.Windows.Forms.ToolStripButton toolVis;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolCortar;
        private System.Windows.Forms.ToolStripButton toolCopiar;
        private System.Windows.Forms.ToolStripButton toolPegar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolDes;
        private System.Windows.Forms.ToolStripButton toolBus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolFiltroCampo;
        private System.Windows.Forms.ToolStripButton toolFiltroTabla;
        private System.Windows.Forms.ToolStripButton toolQuitar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolLista;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton ayudaToolStripButton;
        private System.Windows.Forms.BindingSource bS1;
        private System.Windows.Forms.Label label1;
        private jControles.jTextBox txCP;
        private System.Windows.Forms.TextBox txProvincia;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txPoblación;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txdirección;
        private System.Windows.Forms.Label label12;
        private jControles.jTextBox txId;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btSel;
    }
}