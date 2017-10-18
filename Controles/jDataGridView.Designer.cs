namespace GesInject.Controles
{
    partial class jDataGridView
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gr1 = new System.Windows.Forms.DataGridView();
            this.gr2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr2)).BeginInit();
            this.SuspendLayout();
            // 
            // gr1
            // 
            this.gr1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gr1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gr1.ColumnHeadersVisible = false;
            this.gr1.Location = new System.Drawing.Point(3, 83);
            this.gr1.Name = "gr1";
            this.gr1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gr1.Size = new System.Drawing.Size(474, 304);
            this.gr1.TabIndex = 0;
            this.gr1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gr1_CellEnter);
            this.gr1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gr1_Scroll);
            this.gr1.Resize += new System.EventHandler(this.gr1_Resize);
            // 
            // gr2
            // 
            this.gr2.AllowUserToAddRows = false;
            this.gr2.AllowUserToDeleteRows = false;
            this.gr2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gr2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gr2.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.gr2.Location = new System.Drawing.Point(3, 31);
            this.gr2.MultiSelect = false;
            this.gr2.Name = "gr2";
            this.gr2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gr2.RowHeadersWidth = 10;
            this.gr2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gr2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.gr2.Size = new System.Drawing.Size(474, 51);
            this.gr2.TabIndex = 1;
            this.gr2.RowHeadersWidthChanged += new System.EventHandler(this.gr2_RowHeadersWidthChanged);
            this.gr2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gr2_CellContentClick);
            this.gr2.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gr2_CellValidating);
            this.gr2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gr2_CellValueChanged);
            this.gr2.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gr2_ColumnHeaderMouseClick);
            this.gr2.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.gr2_ColumnWidthChanged);
            this.gr2.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gr2_DataError);
            this.gr2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gr2_KeyUp);
            // 
            // jDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.gr2);
            this.Controls.Add(this.gr1);
            this.Name = "jDataGridView";
            this.Size = new System.Drawing.Size(480, 390);
            this.Load += new System.EventHandler(this.jDataGridView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gr1;
        private System.Windows.Forms.DataGridView gr2;
    }
}
