namespace Vista
{
    partial class FrmMain2
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
            this.btnEliminarCliente = new System.Windows.Forms.Button();
            this.btnEditarCliente = new System.Windows.Forms.Button();
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.lstClientes = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEliminarMascota = new System.Windows.Forms.Button();
            this.btnEditarMascota = new System.Windows.Forms.Button();
            this.btnNuevaMascota = new System.Windows.Forms.Button();
            this.lstMascotas = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEliminarCliente);
            this.groupBox1.Controls.Add(this.btnEditarCliente);
            this.groupBox1.Controls.Add(this.btnNuevoCliente);
            this.groupBox1.Controls.Add(this.lstClientes);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 311);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clientes";
            // 
            // btnEliminarCliente
            // 
            this.btnEliminarCliente.Enabled = false;
            this.btnEliminarCliente.Location = new System.Drawing.Point(262, 80);
            this.btnEliminarCliente.Name = "btnEliminarCliente";
            this.btnEliminarCliente.Size = new System.Drawing.Size(100, 23);
            this.btnEliminarCliente.TabIndex = 3;
            this.btnEliminarCliente.Text = "Borrar";
            this.btnEliminarCliente.UseVisualStyleBackColor = true;
            // 
            // btnEditarCliente
            // 
            this.btnEditarCliente.Enabled = false;
            this.btnEditarCliente.Location = new System.Drawing.Point(262, 51);
            this.btnEditarCliente.Name = "btnEditarCliente";
            this.btnEditarCliente.Size = new System.Drawing.Size(100, 23);
            this.btnEditarCliente.TabIndex = 2;
            this.btnEditarCliente.Text = "Editar";
            this.btnEditarCliente.UseVisualStyleBackColor = true;
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.Location = new System.Drawing.Point(262, 22);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(100, 23);
            this.btnNuevoCliente.TabIndex = 1;
            this.btnNuevoCliente.Text = "Nuevo cliente";
            this.btnNuevoCliente.UseVisualStyleBackColor = true;
            // 
            // lstClientes
            // 
            this.lstClientes.FormattingEnabled = true;
            this.lstClientes.ItemHeight = 15;
            this.lstClientes.Location = new System.Drawing.Point(6, 22);
            this.lstClientes.Name = "lstClientes";
            this.lstClientes.Size = new System.Drawing.Size(250, 274);
            this.lstClientes.TabIndex = 0;
            this.lstClientes.Click += new System.EventHandler(this.lstClientes_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEliminarMascota);
            this.groupBox2.Controls.Add(this.btnEditarMascota);
            this.groupBox2.Controls.Add(this.btnNuevaMascota);
            this.groupBox2.Controls.Add(this.lstMascotas);
            this.groupBox2.Location = new System.Drawing.Point(425, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 311);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mascotas";
            // 
            // btnEliminarMascota
            // 
            this.btnEliminarMascota.Enabled = false;
            this.btnEliminarMascota.Location = new System.Drawing.Point(262, 80);
            this.btnEliminarMascota.Name = "btnEliminarMascota";
            this.btnEliminarMascota.Size = new System.Drawing.Size(100, 23);
            this.btnEliminarMascota.TabIndex = 6;
            this.btnEliminarMascota.Text = "Borrar";
            this.btnEliminarMascota.UseVisualStyleBackColor = true;
            // 
            // btnEditarMascota
            // 
            this.btnEditarMascota.Enabled = false;
            this.btnEditarMascota.Location = new System.Drawing.Point(262, 51);
            this.btnEditarMascota.Name = "btnEditarMascota";
            this.btnEditarMascota.Size = new System.Drawing.Size(100, 23);
            this.btnEditarMascota.TabIndex = 5;
            this.btnEditarMascota.Text = "Editar";
            this.btnEditarMascota.UseVisualStyleBackColor = true;
            // 
            // btnNuevaMascota
            // 
            this.btnNuevaMascota.Location = new System.Drawing.Point(262, 22);
            this.btnNuevaMascota.Name = "btnNuevaMascota";
            this.btnNuevaMascota.Size = new System.Drawing.Size(100, 23);
            this.btnNuevaMascota.TabIndex = 4;
            this.btnNuevaMascota.Text = "Nueva mascota";
            this.btnNuevaMascota.UseVisualStyleBackColor = true;
            // 
            // lstMascotas
            // 
            this.lstMascotas.FormattingEnabled = true;
            this.lstMascotas.ItemHeight = 15;
            this.lstMascotas.Location = new System.Drawing.Point(6, 22);
            this.lstMascotas.Name = "lstMascotas";
            this.lstMascotas.Size = new System.Drawing.Size(250, 274);
            this.lstMascotas.TabIndex = 1;
            this.lstMascotas.Click += new System.EventHandler(this.lstMascotas_Click);
            // 
            // FrmMain2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMain2";
            this.Text = "Veterinaria";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain2_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEliminarCliente;
        private System.Windows.Forms.Button btnEditarCliente;
        private System.Windows.Forms.Button btnNuevoCliente;
        private System.Windows.Forms.ListBox lstClientes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEliminarMascota;
        private System.Windows.Forms.Button btnEditarMascota;
        private System.Windows.Forms.Button btnNuevaMascota;
        private System.Windows.Forms.ListBox lstMascotas;
    }
}