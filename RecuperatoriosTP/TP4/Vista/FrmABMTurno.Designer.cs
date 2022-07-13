namespace Vista
{
    partial class FrmABMTurno
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
            this.grpMascota = new System.Windows.Forms.GroupBox();
            this.txtFechaNacimiento = new System.Windows.Forms.TextBox();
            this.txtIdMascota = new System.Windows.Forms.TextBox();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.txtPeso = new System.Windows.Forms.NumericUpDown();
            this.lblPeso = new System.Windows.Forms.Label();
            this.txtNombreMascota = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.lblIdMascota = new System.Windows.Forms.Label();
            this.grpTurno = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbHoraHasta = new System.Windows.Forms.ComboBox();
            this.cmbHoraDesde = new System.Windows.Forms.ComboBox();
            this.txtComentario = new System.Windows.Forms.RichTextBox();
            this.dtFechaTurno = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblComentario = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpMascota.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeso)).BeginInit();
            this.grpTurno.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMascota
            // 
            this.grpMascota.Controls.Add(this.txtFechaNacimiento);
            this.grpMascota.Controls.Add(this.txtIdMascota);
            this.grpMascota.Controls.Add(this.lblFechaNacimiento);
            this.grpMascota.Controls.Add(this.txtPeso);
            this.grpMascota.Controls.Add(this.lblPeso);
            this.grpMascota.Controls.Add(this.txtNombreMascota);
            this.grpMascota.Controls.Add(this.lblNombreCliente);
            this.grpMascota.Controls.Add(this.lblIdMascota);
            this.grpMascota.Enabled = false;
            this.grpMascota.Location = new System.Drawing.Point(12, 12);
            this.grpMascota.Name = "grpMascota";
            this.grpMascota.Size = new System.Drawing.Size(371, 119);
            this.grpMascota.TabIndex = 12;
            this.grpMascota.TabStop = false;
            this.grpMascota.Text = "Mascota";
            // 
            // txtFechaNacimiento
            // 
            this.txtFechaNacimiento.Enabled = false;
            this.txtFechaNacimiento.Location = new System.Drawing.Point(251, 37);
            this.txtFechaNacimiento.Name = "txtFechaNacimiento";
            this.txtFechaNacimiento.Size = new System.Drawing.Size(101, 23);
            this.txtFechaNacimiento.TabIndex = 22;
            // 
            // txtIdMascota
            // 
            this.txtIdMascota.Enabled = false;
            this.txtIdMascota.Location = new System.Drawing.Point(11, 36);
            this.txtIdMascota.Name = "txtIdMascota";
            this.txtIdMascota.Size = new System.Drawing.Size(100, 23);
            this.txtIdMascota.TabIndex = 21;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(251, 19);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(101, 15);
            this.lblFechaNacimiento.TabIndex = 20;
            this.lblFechaNacimiento.Text = "Fecha nacimiento";
            // 
            // txtPeso
            // 
            this.txtPeso.DecimalPlaces = 2;
            this.txtPeso.Enabled = false;
            this.txtPeso.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtPeso.Location = new System.Drawing.Point(146, 37);
            this.txtPeso.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(75, 23);
            this.txtPeso.TabIndex = 18;
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(146, 19);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(57, 15);
            this.lblPeso.TabIndex = 17;
            this.lblPeso.Text = "Peso (Kg)";
            // 
            // txtNombreMascota
            // 
            this.txtNombreMascota.Enabled = false;
            this.txtNombreMascota.Location = new System.Drawing.Point(11, 90);
            this.txtNombreMascota.Name = "txtNombreMascota";
            this.txtNombreMascota.Size = new System.Drawing.Size(341, 23);
            this.txtNombreMascota.TabIndex = 14;
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(6, 72);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(51, 15);
            this.lblNombreCliente.TabIndex = 12;
            this.lblNombreCliente.Text = "Nombre";
            // 
            // lblIdMascota
            // 
            this.lblIdMascota.AutoSize = true;
            this.lblIdMascota.Location = new System.Drawing.Point(11, 19);
            this.lblIdMascota.Name = "lblIdMascota";
            this.lblIdMascota.Size = new System.Drawing.Size(18, 15);
            this.lblIdMascota.TabIndex = 11;
            this.lblIdMascota.Text = "ID";
            // 
            // grpTurno
            // 
            this.grpTurno.Controls.Add(this.label2);
            this.grpTurno.Controls.Add(this.label1);
            this.grpTurno.Controls.Add(this.cmbHoraHasta);
            this.grpTurno.Controls.Add(this.cmbHoraDesde);
            this.grpTurno.Controls.Add(this.txtComentario);
            this.grpTurno.Controls.Add(this.dtFechaTurno);
            this.grpTurno.Controls.Add(this.lblFecha);
            this.grpTurno.Controls.Add(this.lblComentario);
            this.grpTurno.Location = new System.Drawing.Point(12, 153);
            this.grpTurno.Name = "grpTurno";
            this.grpTurno.Size = new System.Drawing.Size(371, 173);
            this.grpTurno.TabIndex = 15;
            this.grpTurno.TabStop = false;
            this.grpTurno.Text = "Turno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "Hora hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Hora desde";
            // 
            // cmbHoraHasta
            // 
            this.cmbHoraHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoraHasta.Enabled = false;
            this.cmbHoraHasta.FormattingEnabled = true;
            this.cmbHoraHasta.Location = new System.Drawing.Point(193, 140);
            this.cmbHoraHasta.Name = "cmbHoraHasta";
            this.cmbHoraHasta.Size = new System.Drawing.Size(63, 23);
            this.cmbHoraHasta.TabIndex = 19;
            // 
            // cmbHoraDesde
            // 
            this.cmbHoraDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoraDesde.Enabled = false;
            this.cmbHoraDesde.FormattingEnabled = true;
            this.cmbHoraDesde.Location = new System.Drawing.Point(112, 140);
            this.cmbHoraDesde.Name = "cmbHoraDesde";
            this.cmbHoraDesde.Size = new System.Drawing.Size(63, 23);
            this.cmbHoraDesde.TabIndex = 18;
            this.cmbHoraDesde.SelectedIndexChanged += new System.EventHandler(this.cmbHoraDesde_SelectedIndexChanged);
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(6, 38);
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(346, 81);
            this.txtComentario.TabIndex = 17;
            this.txtComentario.Text = "";
            // 
            // dtFechaTurno
            // 
            this.dtFechaTurno.CustomFormat = "dd/MM/yyyy";
            this.dtFechaTurno.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaTurno.Location = new System.Drawing.Point(6, 140);
            this.dtFechaTurno.MaxDate = new System.DateTime(2022, 6, 17, 0, 0, 0, 0);
            this.dtFechaTurno.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dtFechaTurno.Name = "dtFechaTurno";
            this.dtFechaTurno.Size = new System.Drawing.Size(100, 23);
            this.dtFechaTurno.TabIndex = 15;
            this.dtFechaTurno.Value = new System.DateTime(2022, 6, 17, 0, 0, 0, 0);
            this.dtFechaTurno.ValueChanged += new System.EventHandler(this.dtFechaTurno_ValueChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(6, 122);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(38, 15);
            this.lblFecha.TabIndex = 14;
            this.lblFecha.Text = "Fecha";
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Location = new System.Drawing.Point(11, 22);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(70, 15);
            this.lblComentario.TabIndex = 12;
            this.lblComentario.Text = "Comentario";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(229, 13);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(77, 23);
            this.btnAceptar.TabIndex = 13;
            this.btnAceptar.Text = "Agregar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(312, 13);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(77, 23);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnAceptar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 332);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 42);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // FrmABMTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 374);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpTurno);
            this.Controls.Add(this.grpMascota);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmABMTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carga de turno";
            this.Load += new System.EventHandler(this.FrmCargarTurno_Load);
            this.grpMascota.ResumeLayout(false);
            this.grpMascota.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeso)).EndInit();
            this.grpTurno.ResumeLayout(false);
            this.grpTurno.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMascota;
        private System.Windows.Forms.TextBox txtNombreMascota;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Label lblIdMascota;
        private System.Windows.Forms.NumericUpDown txtPeso;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.GroupBox grpTurno;
        private System.Windows.Forms.DateTimePicker dtFechaTurno;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIdMascota;
        private System.Windows.Forms.RichTextBox txtComentario;
        private System.Windows.Forms.TextBox txtFechaNacimiento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbHoraHasta;
        private System.Windows.Forms.ComboBox cmbHoraDesde;
    }
}