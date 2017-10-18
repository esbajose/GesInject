namespace GesInject.Formularios
{
    partial class frmLista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLista));
            this.grLista = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txBusca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cblista = new System.Windows.Forms.ComboBox();
            this.btCerrar = new System.Windows.Forms.Button();
            this.btSelec = new System.Windows.Forms.Button();
            this.chLista = new System.Windows.Forms.CheckedListBox();
            this.btCampos = new System.Windows.Forms.Button();
            this.btExcel = new System.Windows.Forms.Button();
            this.Navi1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolFiltroCampo = new System.Windows.Forms.ToolStripButton();
            this.toolFiltroTabla = new System.Windows.Forms.ToolStripButton();
            this.toolQuitar = new System.Windows.Forms.ToolStripButton();
            this.lbFiltros = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Navi1)).BeginInit();
            this.Navi1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grLista
            // 
            this.grLista.AllowUserToAddRows = false;
            this.grLista.AllowUserToDeleteRows = false;
            this.grLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grLista.Location = new System.Drawing.Point(12, 57);
            this.grLista.MultiSelect = false;
            this.grLista.Name = "grLista";
            this.grLista.ReadOnly = true;
            this.grLista.Size = new System.Drawing.Size(772, 352);
            this.grLista.TabIndex = 0;
            this.grLista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grLista_CellContentClick);
            this.grLista.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grLista_CellContentDoubleClick);
            this.grLista.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grLista_RowEnter);
            this.grLista.MouseEnter += new System.EventHandler(this.grLista_MouseEnter);
            this.grLista.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grLista_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buscar literal ";
            // 
            // txBusca
            // 
            this.txBusca.Location = new System.Drawing.Point(77, 4);
            this.txBusca.Name = "txBusca";
            this.txBusca.Size = new System.Drawing.Size(100, 20);
            this.txBusca.TabIndex = 2;
            this.txBusca.TextChanged += new System.EventHandler(this.txBusca_TextChanged);
            this.txBusca.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txBusca_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "en";
            // 
            // cblista
            // 
            this.cblista.FormattingEnabled = true;
            this.cblista.Location = new System.Drawing.Point(203, 4);
            this.cblista.Name = "cblista";
            this.cblista.Size = new System.Drawing.Size(170, 21);
            this.cblista.TabIndex = 4;
            // 
            // btCerrar
            // 
            this.btCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerrar.Location = new System.Drawing.Point(667, 440);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(111, 34);
            this.btCerrar.TabIndex = 5;
            this.btCerrar.Text = "&Cerrar";
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // btSelec
            // 
            this.btSelec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSelec.Location = new System.Drawing.Point(6, 440);
            this.btSelec.Name = "btSelec";
            this.btSelec.Size = new System.Drawing.Size(111, 34);
            this.btSelec.TabIndex = 6;
            this.btSelec.Text = "&Seleccionar";
            this.btSelec.UseVisualStyleBackColor = true;
            this.btSelec.Click += new System.EventHandler(this.btSelec_Click);
            // 
            // chLista
            // 
            this.chLista.FormattingEnabled = true;
            this.chLista.Location = new System.Drawing.Point(378, 33);
            this.chLista.Name = "chLista";
            this.chLista.Size = new System.Drawing.Size(89, 184);
            this.chLista.TabIndex = 7;
            this.chLista.Visible = false;
            this.chLista.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chLista_ItemCheck);
            this.chLista.Leave += new System.EventHandler(this.chLista_Leave);
            // 
            // btCampos
            // 
            this.btCampos.Location = new System.Drawing.Point(379, 4);
            this.btCampos.Name = "btCampos";
            this.btCampos.Size = new System.Drawing.Size(88, 23);
            this.btCampos.TabIndex = 8;
            this.btCampos.Text = "Campos";
            this.btCampos.UseVisualStyleBackColor = true;
            this.btCampos.Click += new System.EventHandler(this.btCampos_Click);
            // 
            // btExcel
            // 
            this.btExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExcel.Location = new System.Drawing.Point(179, 440);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(114, 33);
            this.btExcel.TabIndex = 9;
            this.btExcel.Text = "Crear Excel";
            this.btExcel.UseVisualStyleBackColor = true;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // Navi1
            // 
            this.Navi1.AddNewItem = null;
            this.Navi1.CountItem = null;
            this.Navi1.DeleteItem = null;
            this.Navi1.Dock = System.Windows.Forms.DockStyle.None;
            this.Navi1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator,
            this.toolFiltroCampo,
            this.toolFiltroTabla,
            this.toolQuitar,
            this.lbFiltros});
            this.Navi1.Location = new System.Drawing.Point(6, 29);
            this.Navi1.MoveFirstItem = null;
            this.Navi1.MoveLastItem = null;
            this.Navi1.MoveNextItem = null;
            this.Navi1.MovePreviousItem = null;
            this.Navi1.Name = "Navi1";
            this.Navi1.PositionItem = null;
            this.Navi1.Size = new System.Drawing.Size(101, 25);
            this.Navi1.TabIndex = 10;
            this.Navi1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
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
            this.toolFiltroCampo.Visible = false;
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
            this.toolFiltroTabla.Click += new System.EventHandler(this.toolFiltroTabla_Click);
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
            this.toolQuitar.Click += new System.EventHandler(this.toolQuitar_Click);
            // 
            // lbFiltros
            // 
            this.lbFiltros.Name = "lbFiltros";
            this.lbFiltros.Size = new System.Drawing.Size(37, 22);
            this.lbFiltros.Text = "Filtro:";
            // 
            // frmLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 486);
            this.Controls.Add(this.Navi1);
            this.Controls.Add(this.btExcel);
            this.Controls.Add(this.btCampos);
            this.Controls.Add(this.chLista);
            this.Controls.Add(this.btSelec);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.cblista);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txBusca);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grLista);
            this.KeyPreview = true;
            this.Name = "frmLista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLista_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLista_FormClosed);
            this.Load += new System.EventHandler(this.frmLista_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmLista_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmLista_KeyUp);
            this.MouseEnter += new System.EventHandler(this.frmLista_MouseEnter);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmLista_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.grLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Navi1)).EndInit();
            this.Navi1.ResumeLayout(false);
            this.Navi1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grLista;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txBusca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cblista;
        private System.Windows.Forms.Button btCerrar;
        private System.Windows.Forms.Button btSelec;
        private System.Windows.Forms.CheckedListBox chLista;
        private System.Windows.Forms.Button btCampos;
        private System.Windows.Forms.Button btExcel;
        private System.Windows.Forms.BindingNavigator Navi1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripButton toolFiltroCampo;
        private System.Windows.Forms.ToolStripButton toolFiltroTabla;
        private System.Windows.Forms.ToolStripButton toolQuitar;
        private System.Windows.Forms.ToolStripLabel lbFiltros;
    }
}