namespace GesInject.Formularios
{
    partial class frmInputDatosOF
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
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.lbDesde = new System.Windows.Forms.Label();
            this.lbHasta = new System.Windows.Forms.Label();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btSemana = new System.Windows.Forms.Button();
            this.btMes = new System.Windows.Forms.Button();
            this.chTerminadas = new System.Windows.Forms.CheckBox();
            this.chAcabadas = new System.Windows.Forms.CheckBox();
            this.chProducción = new System.Windows.Forms.CheckBox();
            this.chLanzadas = new System.Windows.Forms.CheckBox();
            this.chPlanificadas = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(101, 19);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(113, 20);
            this.dtDesde.TabIndex = 0;
            this.dtDesde.ValueChanged += new System.EventHandler(this.dtDesde_ValueChanged);
            // 
            // lbDesde
            // 
            this.lbDesde.AutoSize = true;
            this.lbDesde.Location = new System.Drawing.Point(13, 25);
            this.lbDesde.Name = "lbDesde";
            this.lbDesde.Size = new System.Drawing.Size(82, 13);
            this.lbDesde.TabIndex = 1;
            this.lbDesde.Text = "Desde la Fecha";
            // 
            // lbHasta
            // 
            this.lbHasta.AutoSize = true;
            this.lbHasta.Location = new System.Drawing.Point(242, 25);
            this.lbHasta.Name = "lbHasta";
            this.lbHasta.Size = new System.Drawing.Size(79, 13);
            this.lbHasta.TabIndex = 2;
            this.lbHasta.Text = "Hasta la Fecha";
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(327, 19);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(113, 20);
            this.dtHasta.TabIndex = 3;
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelar.Location = new System.Drawing.Point(355, 151);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(84, 28);
            this.btCancelar.TabIndex = 5;
            this.btCancelar.Text = "&Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btAceptar.Location = new System.Drawing.Point(16, 151);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(90, 28);
            this.btAceptar.TabIndex = 4;
            this.btAceptar.Text = "&Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btSemana
            // 
            this.btSemana.Location = new System.Drawing.Point(154, 45);
            this.btSemana.Name = "btSemana";
            this.btSemana.Size = new System.Drawing.Size(60, 23);
            this.btSemana.TabIndex = 6;
            this.btSemana.Text = "&Semana";
            this.btSemana.UseVisualStyleBackColor = true;
            this.btSemana.Click += new System.EventHandler(this.btSemana_Click);
            // 
            // btMes
            // 
            this.btMes.Location = new System.Drawing.Point(245, 45);
            this.btMes.Name = "btMes";
            this.btMes.Size = new System.Drawing.Size(60, 23);
            this.btMes.TabIndex = 7;
            this.btMes.Text = "&Mes";
            this.btMes.UseVisualStyleBackColor = true;
            this.btMes.Click += new System.EventHandler(this.btMes_Click);
            // 
            // chTerminadas
            // 
            this.chTerminadas.AutoSize = true;
            this.chTerminadas.Checked = true;
            this.chTerminadas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chTerminadas.Enabled = false;
            this.chTerminadas.Location = new System.Drawing.Point(16, 98);
            this.chTerminadas.Name = "chTerminadas";
            this.chTerminadas.Size = new System.Drawing.Size(81, 17);
            this.chTerminadas.TabIndex = 8;
            this.chTerminadas.Text = "Terminadas";
            this.chTerminadas.UseVisualStyleBackColor = true;
            // 
            // chAcabadas
            // 
            this.chAcabadas.AutoSize = true;
            this.chAcabadas.Location = new System.Drawing.Point(103, 98);
            this.chAcabadas.Name = "chAcabadas";
            this.chAcabadas.Size = new System.Drawing.Size(74, 17);
            this.chAcabadas.TabIndex = 9;
            this.chAcabadas.Text = "Acabadas";
            this.chAcabadas.UseVisualStyleBackColor = true;
            // 
            // chProducción
            // 
            this.chProducción.AutoSize = true;
            this.chProducción.Location = new System.Drawing.Point(183, 98);
            this.chProducción.Name = "chProducción";
            this.chProducción.Size = new System.Drawing.Size(80, 17);
            this.chProducción.TabIndex = 10;
            this.chProducción.Text = "Producción";
            this.chProducción.UseVisualStyleBackColor = true;
            // 
            // chLanzadas
            // 
            this.chLanzadas.AutoSize = true;
            this.chLanzadas.Location = new System.Drawing.Point(269, 98);
            this.chLanzadas.Name = "chLanzadas";
            this.chLanzadas.Size = new System.Drawing.Size(72, 17);
            this.chLanzadas.TabIndex = 11;
            this.chLanzadas.Text = "Lanzadas";
            this.chLanzadas.UseVisualStyleBackColor = true;
            // 
            // chPlanificadas
            // 
            this.chPlanificadas.AutoSize = true;
            this.chPlanificadas.Location = new System.Drawing.Point(347, 98);
            this.chPlanificadas.Name = "chPlanificadas";
            this.chPlanificadas.Size = new System.Drawing.Size(83, 17);
            this.chPlanificadas.TabIndex = 12;
            this.chPlanificadas.Text = "Planificadas";
            this.chPlanificadas.UseVisualStyleBackColor = true;
            // 
            // frmInputDatosOF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 191);
            this.ControlBox = false;
            this.Controls.Add(this.chPlanificadas);
            this.Controls.Add(this.chLanzadas);
            this.Controls.Add(this.chProducción);
            this.Controls.Add(this.chAcabadas);
            this.Controls.Add(this.chTerminadas);
            this.Controls.Add(this.btMes);
            this.Controls.Add(this.btSemana);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.lbHasta);
            this.Controls.Add(this.lbDesde);
            this.Controls.Add(this.dtDesde);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmInputDatosOF";
            this.Text = "Selección de Fecha";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInputDatosOF_FormClosing);
            this.Load += new System.EventHandler(this.frmInputDatosOF_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label lbDesde;
        private System.Windows.Forms.Label lbHasta;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btSemana;
        private System.Windows.Forms.Button btMes;
        private System.Windows.Forms.CheckBox chTerminadas;
        private System.Windows.Forms.CheckBox chAcabadas;
        private System.Windows.Forms.CheckBox chProducción;
        private System.Windows.Forms.CheckBox chLanzadas;
        private System.Windows.Forms.CheckBox chPlanificadas;
    }
}