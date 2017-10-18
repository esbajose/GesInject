namespace GesInject.Formularios
{
    partial class frmPakingList
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
            this.btActu = new System.Windows.Forms.Button();
            this.btCerrar = new System.Windows.Forms.Button();
            this.btExcel = new System.Windows.Forms.Button();
            this.grLista = new jControles.jDataGridView();
            this.btImprimir = new System.Windows.Forms.Button();
            this.chPen = new System.Windows.Forms.RadioButton();
            this.chTodos = new System.Windows.Forms.RadioButton();
            this.chLinea = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btActu
            // 
            this.btActu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btActu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btActu.Location = new System.Drawing.Point(727, 24);
            this.btActu.Name = "btActu";
            this.btActu.Size = new System.Drawing.Size(114, 33);
            this.btActu.TabIndex = 31;
            this.btActu.Text = "Actualizar";
            this.btActu.UseVisualStyleBackColor = false;
            this.btActu.Click += new System.EventHandler(this.btActu_Click);
            // 
            // btCerrar
            // 
            this.btCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerrar.Location = new System.Drawing.Point(727, 555);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(111, 34);
            this.btCerrar.TabIndex = 30;
            this.btCerrar.Text = "&Cerrar";
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // btExcel
            // 
            this.btExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExcel.Location = new System.Drawing.Point(12, 556);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(114, 33);
            this.btExcel.TabIndex = 29;
            this.btExcel.Text = "Crear Excel";
            this.btExcel.UseVisualStyleBackColor = true;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
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
            this.grLista.Location = new System.Drawing.Point(12, 72);
            this.grLista.MultiSelect = true;
            this.grLista.Name = "grLista";
            this.grLista.ReadOnly = true;
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
            this.grLista.Size = new System.Drawing.Size(829, 442);
            this.grLista.TabIndex = 28;
            // 
            // btImprimir
            // 
            this.btImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImprimir.Location = new System.Drawing.Point(296, 535);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(221, 68);
            this.btImprimir.TabIndex = 32;
            this.btImprimir.Text = "&Imprimir";
            this.btImprimir.UseVisualStyleBackColor = false;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // chPen
            // 
            this.chPen.AutoSize = true;
            this.chPen.Checked = true;
            this.chPen.Location = new System.Drawing.Point(12, 40);
            this.chPen.Name = "chPen";
            this.chPen.Size = new System.Drawing.Size(161, 17);
            this.chPen.TabIndex = 33;
            this.chPen.TabStop = true;
            this.chPen.Text = "Solo Pendientes de Impreimir";
            this.chPen.UseVisualStyleBackColor = true;
            this.chPen.CheckedChanged += new System.EventHandler(this.chPen_CheckedChanged);
            // 
            // chTodos
            // 
            this.chTodos.AutoSize = true;
            this.chTodos.Location = new System.Drawing.Point(189, 40);
            this.chTodos.Name = "chTodos";
            this.chTodos.Size = new System.Drawing.Size(55, 17);
            this.chTodos.TabIndex = 34;
            this.chTodos.Text = "Todos";
            this.chTodos.UseVisualStyleBackColor = true;
            this.chTodos.CheckedChanged += new System.EventHandler(this.chTodos_CheckedChanged);
            // 
            // chLinea
            // 
            this.chLinea.AutoSize = true;
            this.chLinea.Checked = true;
            this.chLinea.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chLinea.Location = new System.Drawing.Point(296, 41);
            this.chLinea.Name = "chLinea";
            this.chLinea.Size = new System.Drawing.Size(94, 17);
            this.chLinea.TabIndex = 35;
            this.chLinea.Text = "Linea por Caja";
            this.chLinea.UseVisualStyleBackColor = true;
            // 
            // frmPakingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 608);
            this.Controls.Add(this.chLinea);
            this.Controls.Add(this.chTodos);
            this.Controls.Add(this.chPen);
            this.Controls.Add(this.btImprimir);
            this.Controls.Add(this.btActu);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.btExcel);
            this.Controls.Add(this.grLista);
            this.Name = "frmPakingList";
            this.Text = "Impresión de Paking List";
            this.Load += new System.EventHandler(this.frmPakingList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btActu;
        private System.Windows.Forms.Button btCerrar;
        private System.Windows.Forms.Button btExcel;
        private jControles.jDataGridView grLista;
        private System.Windows.Forms.Button btImprimir;
        private System.Windows.Forms.RadioButton chPen;
        private System.Windows.Forms.RadioButton chTodos;
        private System.Windows.Forms.CheckBox chLinea;
    }
}