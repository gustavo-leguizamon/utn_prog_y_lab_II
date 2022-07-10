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
            this.btnVerCliente = new System.Windows.Forms.Button();
            this.btnEliminarCliente = new System.Windows.Forms.Button();
            this.btnEditarCliente = new System.Windows.Forms.Button();
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.lstClientes = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnVerMascota = new System.Windows.Forms.Button();
            this.btnEliminarMascota = new System.Windows.Forms.Button();
            this.btnEditarMascota = new System.Windows.Forms.Button();
            this.btnNuevaMascota = new System.Windows.Forms.Button();
            this.lstMascotas = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTurnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCargarTurno = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnVerCliente);
            this.groupBox1.Controls.Add(this.btnEliminarCliente);
            this.groupBox1.Controls.Add(this.btnEditarCliente);
            this.groupBox1.Controls.Add(this.btnNuevoCliente);
            this.groupBox1.Controls.Add(this.lstClientes);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 311);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clientes";
            // 
            // btnVerCliente
            // 
            this.btnVerCliente.Enabled = false;
            this.btnVerCliente.Location = new System.Drawing.Point(262, 109);
            this.btnVerCliente.Name = "btnVerCliente";
            this.btnVerCliente.Size = new System.Drawing.Size(100, 23);
            this.btnVerCliente.TabIndex = 4;
            this.btnVerCliente.Text = "Ver";
            this.btnVerCliente.UseVisualStyleBackColor = true;
            this.btnVerCliente.Click += new System.EventHandler(this.btnVerCliente_Click);
            // 
            // btnEliminarCliente
            // 
            this.btnEliminarCliente.Enabled = false;
            this.btnEliminarCliente.Location = new System.Drawing.Point(262, 80);
            this.btnEliminarCliente.Name = "btnEliminarCliente";
            this.btnEliminarCliente.Size = new System.Drawing.Size(100, 23);
            this.btnEliminarCliente.TabIndex = 3;
            this.btnEliminarCliente.Text = "Dar de baja";
            this.btnEliminarCliente.UseVisualStyleBackColor = true;
            this.btnEliminarCliente.Click += new System.EventHandler(this.btnEliminarCliente_Click);
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
            this.btnEditarCliente.Click += new System.EventHandler(this.btnEditarCliente_Click);
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.Location = new System.Drawing.Point(262, 22);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(100, 23);
            this.btnNuevoCliente.TabIndex = 1;
            this.btnNuevoCliente.Text = "Nuevo cliente";
            this.btnNuevoCliente.UseVisualStyleBackColor = true;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
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
            this.lstClientes.DoubleClick += new System.EventHandler(this.lstClientes_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCargarTurno);
            this.groupBox2.Controls.Add(this.btnVerMascota);
            this.groupBox2.Controls.Add(this.btnEliminarMascota);
            this.groupBox2.Controls.Add(this.btnEditarMascota);
            this.groupBox2.Controls.Add(this.btnNuevaMascota);
            this.groupBox2.Controls.Add(this.lstMascotas);
            this.groupBox2.Location = new System.Drawing.Point(425, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 311);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mascotas";
            // 
            // btnVerMascota
            // 
            this.btnVerMascota.Enabled = false;
            this.btnVerMascota.Location = new System.Drawing.Point(262, 109);
            this.btnVerMascota.Name = "btnVerMascota";
            this.btnVerMascota.Size = new System.Drawing.Size(100, 23);
            this.btnVerMascota.TabIndex = 5;
            this.btnVerMascota.Text = "Ver";
            this.btnVerMascota.UseVisualStyleBackColor = true;
            this.btnVerMascota.Click += new System.EventHandler(this.btnVerMascota_Click);
            // 
            // btnEliminarMascota
            // 
            this.btnEliminarMascota.Enabled = false;
            this.btnEliminarMascota.Location = new System.Drawing.Point(262, 80);
            this.btnEliminarMascota.Name = "btnEliminarMascota";
            this.btnEliminarMascota.Size = new System.Drawing.Size(100, 23);
            this.btnEliminarMascota.TabIndex = 6;
            this.btnEliminarMascota.Text = "Dar de baja";
            this.btnEliminarMascota.UseVisualStyleBackColor = true;
            this.btnEliminarMascota.Click += new System.EventHandler(this.btnEliminarMascota_Click);
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
            this.btnEditarMascota.Click += new System.EventHandler(this.btnEditarMascota_Click);
            // 
            // btnNuevaMascota
            // 
            this.btnNuevaMascota.Enabled = false;
            this.btnNuevaMascota.Location = new System.Drawing.Point(262, 22);
            this.btnNuevaMascota.Name = "btnNuevaMascota";
            this.btnNuevaMascota.Size = new System.Drawing.Size(100, 23);
            this.btnNuevaMascota.TabIndex = 4;
            this.btnNuevaMascota.Text = "Nueva mascota";
            this.btnNuevaMascota.UseVisualStyleBackColor = true;
            this.btnNuevaMascota.Click += new System.EventHandler(this.btnNuevaMascota_Click);
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivosToolStripMenuItem,
            this.mnuTurnosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(805, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivosToolStripMenuItem
            // 
            this.archivosToolStripMenuItem.Name = "archivosToolStripMenuItem";
            this.archivosToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.archivosToolStripMenuItem.Text = "Archivos";
            // 
            // mnuTurnosToolStripMenuItem
            // 
            this.mnuTurnosToolStripMenuItem.Name = "mnuTurnosToolStripMenuItem";
            this.mnuTurnosToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.mnuTurnosToolStripMenuItem.Text = "Turnos";
            this.mnuTurnosToolStripMenuItem.Click += new System.EventHandler(this.mnuTurnosToolStripMenuItem_Click);
            // 
            // btnCargarTurno
            // 
            this.btnCargarTurno.Enabled = false;
            this.btnCargarTurno.Location = new System.Drawing.Point(262, 138);
            this.btnCargarTurno.Name = "btnCargarTurno";
            this.btnCargarTurno.Size = new System.Drawing.Size(100, 23);
            this.btnCargarTurno.TabIndex = 7;
            this.btnCargarTurno.Text = "Cargar turno";
            this.btnCargarTurno.UseVisualStyleBackColor = true;
            this.btnCargarTurno.Click += new System.EventHandler(this.btnCargarTurno_Click);
            // 
            // FrmMain2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Veterinaria";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain2_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnVerCliente;
        private System.Windows.Forms.Button btnVerMascota;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuTurnosToolStripMenuItem;
        private System.Windows.Forms.Button btnCargarTurno;
    }
}