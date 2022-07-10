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
            this.dtgTurnos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgTurnos
            // 
            this.dtgTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTurnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgTurnos.Location = new System.Drawing.Point(0, 0);
            this.dtgTurnos.Name = "dtgTurnos";
            this.dtgTurnos.RowTemplate.Height = 25;
            this.dtgTurnos.Size = new System.Drawing.Size(852, 450);
            this.dtgTurnos.TabIndex = 0;
            this.dtgTurnos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTurnos_CellClick);
            this.dtgTurnos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTurnos_CellDoubleClick);
            // 
            // FrmListadoDeTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 450);
            this.Controls.Add(this.dtgTurnos);
            this.Name = "FrmListadoDeTurnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de turnos";
            this.Load += new System.EventHandler(this.FrmListadoDeTurnos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTurnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgTurnos;
    }
}