namespace Vista
{
    partial class FrmListadoDeTurnos
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
            this.cmbEstadoTurno = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEstadoTurno = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgTurnos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEstadoTurno
            // 
            this.cmbEstadoTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoTurno.FormattingEnabled = true;
            this.cmbEstadoTurno.Location = new System.Drawing.Point(6, 40);
            this.cmbEstadoTurno.Name = "cmbEstadoTurno";
            this.cmbEstadoTurno.Size = new System.Drawing.Size(121, 23);
            this.cmbEstadoTurno.TabIndex = 1;
            this.cmbEstadoTurno.SelectedIndexChanged += new System.EventHandler(this.cmbEstadoTurno_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblEstadoTurno);
            this.groupBox1.Controls.Add(this.cmbEstadoTurno);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(828, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // lblEstadoTurno
            // 
            this.lblEstadoTurno.AutoSize = true;
            this.lblEstadoTurno.Location = new System.Drawing.Point(6, 22);
            this.lblEstadoTurno.Name = "lblEstadoTurno";
            this.lblEstadoTurno.Size = new System.Drawing.Size(42, 15);
            this.lblEstadoTurno.TabIndex = 2;
            this.lblEstadoTurno.Text = "Estado";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgTurnos);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(818, 320);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Turnos";
            // 
            // dtgTurnos
            // 
            this.dtgTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTurnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgTurnos.Location = new System.Drawing.Point(3, 19);
            this.dtgTurnos.Name = "dtgTurnos";
            this.dtgTurnos.RowTemplate.Height = 25;
            this.dtgTurnos.Size = new System.Drawing.Size(812, 298);
            this.dtgTurnos.TabIndex = 1;
            this.dtgTurnos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTurnos_CellClick);
            this.dtgTurnos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTurnos_CellDoubleClick);
            // 
            // FrmListadoDeTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmListadoDeTurnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de turnos";
            this.Load += new System.EventHandler(this.FrmListadoDeTurnos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTurnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEstadoTurno;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgTurnos;
        private System.Windows.Forms.Label lblEstadoTurno;
    }
}