namespace Vista
{
    partial class FrmProximoTurno
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
            this.lblHoraActual = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHoraProximoTurno = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHoraRestante = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHoraActual
            // 
            this.lblHoraActual.AutoSize = true;
            this.lblHoraActual.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHoraActual.Location = new System.Drawing.Point(205, 9);
            this.lblHoraActual.Name = "lblHoraActual";
            this.lblHoraActual.Size = new System.Drawing.Size(176, 21);
            this.lblHoraActual.TabIndex = 1;
            this.lblHoraActual.Text = "DD/MM/YYYY HH:MI:SS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hora actual:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Próximo turno:";
            // 
            // lblHoraProximoTurno
            // 
            this.lblHoraProximoTurno.AutoSize = true;
            this.lblHoraProximoTurno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHoraProximoTurno.Location = new System.Drawing.Point(205, 51);
            this.lblHoraProximoTurno.Name = "lblHoraProximoTurno";
            this.lblHoraProximoTurno.Size = new System.Drawing.Size(176, 21);
            this.lblHoraProximoTurno.TabIndex = 3;
            this.lblHoraProximoTurno.Text = "DD/MM/YYYY HH:MI:SS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tiempo restante próximo:";
            // 
            // lblHoraRestante
            // 
            this.lblHoraRestante.AutoSize = true;
            this.lblHoraRestante.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHoraRestante.Location = new System.Drawing.Point(205, 96);
            this.lblHoraRestante.Name = "lblHoraRestante";
            this.lblHoraRestante.Size = new System.Drawing.Size(176, 21);
            this.lblHoraRestante.TabIndex = 5;
            this.lblHoraRestante.Text = "DD/MM/YYYY HH:MI:SS";
            // 
            // FrmProximoTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 140);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblHoraRestante);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHoraProximoTurno);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHoraActual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProximoTurno";
            this.Text = "Próximo turno";
            this.Load += new System.EventHandler(this.FrmProximoTurno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHoraActual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHoraProximoTurno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHoraRestante;
    }
}