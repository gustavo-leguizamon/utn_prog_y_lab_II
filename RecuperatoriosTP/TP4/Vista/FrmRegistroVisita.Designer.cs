namespace Vista
{
    partial class FrmRegistroVisita
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.rtbObservaciones = new System.Windows.Forms.RichTextBox();
            this.txtPesoActual = new System.Windows.Forms.NumericUpDown();
            this.dtHoraLLegada = new System.Windows.Forms.DateTimePicker();
            this.dtHoraSalida = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtFechaVisita = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPesoActual)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAceptar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 42);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(203, 13);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(77, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(286, 13);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(77, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // rtbObservaciones
            // 
            this.rtbObservaciones.Location = new System.Drawing.Point(18, 86);
            this.rtbObservaciones.Name = "rtbObservaciones";
            this.rtbObservaciones.Size = new System.Drawing.Size(344, 96);
            this.rtbObservaciones.TabIndex = 5;
            this.rtbObservaciones.Text = "";
            // 
            // txtPesoActual
            // 
            this.txtPesoActual.DecimalPlaces = 2;
            this.txtPesoActual.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtPesoActual.Location = new System.Drawing.Point(295, 27);
            this.txtPesoActual.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.txtPesoActual.Name = "txtPesoActual";
            this.txtPesoActual.Size = new System.Drawing.Size(67, 23);
            this.txtPesoActual.TabIndex = 4;
            // 
            // dtHoraLLegada
            // 
            this.dtHoraLLegada.CustomFormat = "HH:mm";
            this.dtHoraLLegada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHoraLLegada.Location = new System.Drawing.Point(131, 27);
            this.dtHoraLLegada.Name = "dtHoraLLegada";
            this.dtHoraLLegada.ShowUpDown = true;
            this.dtHoraLLegada.Size = new System.Drawing.Size(62, 23);
            this.dtHoraLLegada.TabIndex = 2;
            // 
            // dtHoraSalida
            // 
            this.dtHoraSalida.CustomFormat = "HH:mm";
            this.dtHoraSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHoraSalida.Location = new System.Drawing.Point(209, 27);
            this.dtHoraSalida.Name = "dtHoraSalida";
            this.dtHoraSalida.ShowUpDown = true;
            this.dtHoraSalida.Size = new System.Drawing.Size(62, 23);
            this.dtHoraSalida.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Peso actual";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Salida";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Llegada";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Observaciones";
            // 
            // dtFechaVisita
            // 
            this.dtFechaVisita.CustomFormat = "dd/MM/yyyy";
            this.dtFechaVisita.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaVisita.Location = new System.Drawing.Point(18, 27);
            this.dtFechaVisita.Name = "dtFechaVisita";
            this.dtFechaVisita.Size = new System.Drawing.Size(96, 23);
            this.dtFechaVisita.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fecha";
            // 
            // FrmRegistroVisita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 227);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtFechaVisita);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtHoraSalida);
            this.Controls.Add(this.dtHoraLLegada);
            this.Controls.Add(this.txtPesoActual);
            this.Controls.Add(this.rtbObservaciones);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRegistroVisita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de visita";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRegistroVisita_FormClosing);
            this.Load += new System.EventHandler(this.FrmRegistroVisita_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPesoActual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.RichTextBox rtbObservaciones;
        private System.Windows.Forms.NumericUpDown txtPesoActual;
        private System.Windows.Forms.DateTimePicker dtHoraLLegada;
        private System.Windows.Forms.DateTimePicker dtHoraSalida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtFechaVisita;
        private System.Windows.Forms.Label label6;
    }
}