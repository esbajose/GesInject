namespace GesInject.Formularios
{
    partial class frmLogErrores
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
            this.grLista = new jControles.jDataGridView();
            this.dtDFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtHFecha = new System.Windows.Forms.DateTimePicker();
            this.btAct = new System.Windows.Forms.Button();
            this.btExcel = new System.Windows.Forms.Button();
            this.btCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.grLista.Location = new System.Drawing.Point(12, 85);
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
            this.grLista.Size = new System.Drawing.Size(676, 401);
            this.grLista.TabIndex = 12;
            // 
            // dtDFecha
            // 
            this.dtDFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDFecha.Location = new System.Drawing.Point(115, 12);
            this.dtDFecha.Name = "dtDFecha";
            this.dtDFecha.ShowCheckBox = true;
            this.dtDFecha.Size = new System.Drawing.Size(122, 20);
            this.dtDFecha.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Desde la Fecha : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Hasta la Fecha : ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dtHFecha
            // 
            this.dtHFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHFecha.Location = new System.Drawing.Point(115, 38);
            this.dtHFecha.Name = "dtHFecha";
            this.dtHFecha.ShowCheckBox = true;
            this.dtHFecha.Size = new System.Drawing.Size(122, 20);
            this.dtHFecha.TabIndex = 15;
            // 
            // btAct
            // 
            this.btAct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btAct.Location = new System.Drawing.Point(257, 12);
            this.btAct.Name = "btAct";
            this.btAct.Size = new System.Drawing.Size(103, 46);
            this.btAct.TabIndex = 17;
            this.btAct.Text = "&Actualizar";
            this.btAct.UseVisualStyleBackColor = false;
            this.btAct.Click += new System.EventHandler(this.btAct_Click);
            // 
            // btExcel
            // 
            this.btExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExcel.Location = new System.Drawing.Point(12, 500);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(114, 33);
            this.btExcel.TabIndex = 18;
            this.btExcel.Text = "Crear Excel";
            this.btExcel.UseVisualStyleBackColor = true;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // btCerrar
            // 
            this.btCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerrar.Location = new System.Drawing.Point(577, 499);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(111, 34);
            this.btCerrar.TabIndex = 19;
            this.btCerrar.Text = "&Cerrar";
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // frmLogErrores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 545);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.btExcel);
            this.Controls.Add(this.btAct);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtHFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtDFecha);
            this.Controls.Add(this.grLista);
            this.Name = "frmLogErrores";
            this.Text = "Log de Errores";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLogErrores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private jControles.jDataGridView grLista;
        private System.Windows.Forms.DateTimePicker dtDFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtHFecha;
        private System.Windows.Forms.Button btAct;
        private System.Windows.Forms.Button btExcel;
        private System.Windows.Forms.Button btCerrar;
    }
}