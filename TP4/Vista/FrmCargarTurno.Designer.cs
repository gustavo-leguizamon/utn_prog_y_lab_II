namespace Vista
{
    partial class FrmCargarTurno
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
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.dtFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.txtPeso = new System.Windows.Forms.NumericUpDown();
            this.lblPeso = new System.Windows.Forms.Label();
            this.txtNombreMascota = new System.Windows.Forms.TextBox();
            this.txtIdMascota = new System.Windows.Forms.NumericUpDown();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.lblIdMascota = new System.Windows.Forms.Label();
            this.grpTurno = new System.Windows.Forms.GroupBox();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblComentario = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpMascota.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdMascota)).BeginInit();
            this.grpTurno.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMascota
            // 
            this.grpMascota.Controls.Add(this.lblFechaNacimiento);
            this.grpMascota.Controls.Add(this.dtFechaNacimiento);
            this.grpMascota.Controls.Add(this.txtPeso);
            this.grpMascota.Controls.Add(this.lblPeso);
            this.grpMascota.Controls.Add(this.txtNombreMascota);
            this.grpMascota.Controls.Add(this.txtIdMascota);
            this.grpMascota.Controls.Add(this.lblNombreCliente);
            this.grpMascota.Controls.Add(this.lblIdMascota);
            this.grpMascota.Location = new System.Drawing.Point(12, 12);
            this.grpMascota.Name = "grpMascota";
            this.grpMascota.Size = new System.Drawing.Size(371, 119);
            this.grpMascota.TabIndex = 12;
            this.grpMascota.TabStop = false;
            this.grpMascota.Text = "Mascota";
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(157, 62);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(101, 15);
            this.lblFechaNacimiento.TabIndex = 20;
            this.lblFechaNacimiento.Text = "Fecha nacimiento";
            // 
            // dtFechaNacimiento
            // 
            this.dtFechaNacimiento.Enabled = false;
            this.dtFechaNacimiento.Location = new System.Drawing.Point(157, 81);
            this.dtFechaNacimiento.MaxDate = new System.DateTime(2022, 6, 17, 0, 0, 0, 0);
            this.dtFechaNacimiento.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dtFechaNacimiento.Name = "dtFechaNacimiento";
            this.dtFechaNacimiento.Size = new System.Drawing.Size(200, 23);
            this.dtFechaNacimiento.TabIndex = 19;
            this.dtFechaNacimiento.Value = new System.DateTime(2022, 6, 17, 0, 0, 0, 0);
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
            this.txtPeso.Location = new System.Drawing.Point(11, 81);
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
            this.lblPeso.Location = new System.Drawing.Point(11, 63);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(57, 15);
            this.lblPeso.TabIndex = 17;
            this.lblPeso.Text = "Peso (Kg)";
            // 
            // txtNombreMascota
            // 
            this.txtNombreMascota.Enabled = false;
            this.txtNombreMascota.Location = new System.Drawing.Point(157, 36);
            this.txtNombreMascota.Name = "txtNombreMascota";
            this.txtNombreMascota.Size = new System.Drawing.Size(195, 23);
            this.txtNombreMascota.TabIndex = 14;
            // 
            // txtIdMascota
            // 
            this.txtIdMascota.Location = new System.Drawing.Point(11, 37);
            this.txtIdMascota.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.txtIdMascota.Name = "txtIdMascota";
            this.txtIdMascota.Size = new System.Drawing.Size(120, 23);
            this.txtIdMascota.TabIndex = 13;
            this.txtIdMascota.ValueChanged += new System.EventHandler(this.txtIdMascota_ValueChanged);
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(157, 18);
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
            this.grpTurno.Controls.Add(this.dtFecha);
            this.grpTurno.Controls.Add(this.lblFecha);
            this.grpTurno.Controls.Add(this.lblComentario);
            this.grpTurno.Controls.Add(this.txtComentario);
            this.grpTurno.Enabled = false;
            this.grpTurno.Location = new System.Drawing.Point(7, 173);
            this.grpTurno.Name = "grpTurno";
            this.grpTurno.Size = new System.Drawing.Size(371, 133);
            this.grpTurno.TabIndex = 15;
            this.grpTurno.TabStop = false;
            this.grpTurno.Text = "Turno";
            // 
            // dtFecha
            // 
            this.dtFecha.Location = new System.Drawing.Point(11, 94);
            this.dtFecha.MaxDate = new System.DateTime(2022, 6, 17, 0, 0, 0, 0);
            this.dtFecha.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(200, 23);
            this.dtFecha.TabIndex = 15;
            this.dtFecha.Value = new System.DateTime(2022, 6, 17, 0, 0, 0, 0);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(11, 76);
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
            // txtComentario
            // 
            this.txtComentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtComentario.Location = new System.Drawing.Point(11, 40);
            this.txtComentario.MaxLength = 50;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(341, 23);
            this.txtComentario.TabIndex = 11;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Location = new System.Drawing.Point(34, 312);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(143, 23);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(216, 312);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(143, 23);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmCargarTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 342);
            this.Controls.Add(this.grpTurno);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpMascota);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCargarTurno";
            this.Text = "Carga de turno";
            this.Load += new System.EventHandler(this.FrmCargarTurno_Load);
            this.grpMascota.ResumeLayout(false);
            this.grpMascota.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdMascota)).EndInit();
            this.grpTurno.ResumeLayout(false);
            this.grpTurno.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMascota;
        private System.Windows.Forms.TextBox txtNombreMascota;
        private System.Windows.Forms.NumericUpDown txtIdMascota;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Label lblIdMascota;
        private System.Windows.Forms.NumericUpDown txtPeso;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.DateTimePicker dtFechaNacimiento;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.GroupBox grpTurno;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
    }
}