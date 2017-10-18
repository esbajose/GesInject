namespace GesInject.Formularios
{
    partial class frmListadosOFL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewRow dataGridViewRow1 = new System.Windows.Forms.DataGridViewRow();
            this.filtrosBD1 = new Fil.FiltrosBD();
            this.btActu = new System.Windows.Forms.Button();
            this.grLista = new jControles.jDataGridView();
            this.btExcel = new System.Windows.Forms.Button();
            this.btCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // filtrosBD1
            // 
            this.filtrosBD1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filtrosBD1.Location = new System.Drawing.Point(12, 12);
            this.filtrosBD1.Name = "filtrosBD1";
            this.filtrosBD1.Size = new System.Drawing.Size(578, 193);
            this.filtrosBD1.TabIndex = 0;
            // 
            // btActu
            // 
            this.btActu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btActu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btActu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActu.Location = new System.Drawing.Point(596, 74);
            this.btActu.Name = "btActu";
            this.btActu.Size = new System.Drawing.Size(107, 66);
            this.btActu.TabIndex = 1;
            this.btActu.Text = "&Actualizar";
            this.btActu.UseVisualStyleBackColor = false;
            this.btActu.Click += new System.EventHandler(this.btActu_Click);
            // 
            // grLista
            // 
            this.grLista.AllowUserToAddRows = false;
            this.grLista.AllowUserToDeleteRows = false;
            this.grLista.AllowUserToOrderColumns = false;
            this.grLista.AllowUserToResizeColumns = true;
            this.grLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.grLista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.grLista.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.grLista.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.grLista.BorderStyleGR = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grLista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.grLista.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.grLista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.grLista.ColumnHeadersHeight = 23;
            this.grLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grLista.ColumnHeadersVisible = false;
            this.grLista.ConFiltro = true;
            this.grLista.DataMember = "";
            this.grLista.DataSource = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grLista.DefaultCellStyle = dataGridViewCellStyle2;
            this.grLista.EnableHeadersVisualStyles = true;
            this.grLista.FirstDisplayedScrollingRowIndex = -1;
            this.grLista.GridColor = System.Drawing.SystemColors.ControlDark;
            this.grLista.Location = new System.Drawing.Point(12, 211);
            this.grLista.MultiSelect = true;
            this.grLista.Name = "grLista";
            this.grLista.ReadOnly = false;
            this.grLista.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grLista.RowHeadersVisible = true;
            this.grLista.RowHeadersWidth = 41;
            this.grLista.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grLista.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grLista.RowTemplate = dataGridViewRow1;
            this.grLista.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.grLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
            this.grLista.ShowCellErrors = true;
            this.grLista.ShowCellToolTips = true;
            this.grLista.ShowEditingIcon = true;
            this.grLista.ShowRowErrors = true;
            this.grLista.Size = new System.Drawing.Size(691, 285);
            this.grLista.TabIndex = 13;
            // 
            // btExcel
            // 
            this.btExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExcel.Location = new System.Drawing.Point(12, 538);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(118, 66);
            this.btExcel.TabIndex = 19;
            this.btExcel.Text = "Crear &Excel";
            this.btExcel.UseVisualStyleBackColor = true;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // btCerrar
            // 
            this.btCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCerrar.Location = new System.Drawing.Point(592, 538);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(111, 66);
            this.btCerrar.TabIndex = 20;
            this.btCerrar.Text = "&Cerrar";
            this.btCerrar.UseVisualStyleBackColor = true;
            // 
            // frmListadosOFL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 616);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.btExcel);
            this.Controls.Add(this.grLista);
            this.Controls.Add(this.btActu);
            this.Controls.Add(this.filtrosBD1);
            this.Name = "frmListadosOFL";
            this.Text = "Listado Ordenes de Fabricación";
            this.Load += new System.EventHandler(this.frmListadosOFL_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Fil.FiltrosBD filtrosBD1;
        private System.Windows.Forms.Button btActu;
        private jControles.jDataGridView grLista;
        private System.Windows.Forms.Button btExcel;
        private System.Windows.Forms.Button btCerrar;



    }
}