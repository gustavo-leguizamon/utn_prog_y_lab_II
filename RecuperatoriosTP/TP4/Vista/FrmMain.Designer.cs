namespace Vista
{
    partial class FrmMain
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
            this.mnuContainer = new System.Windows.Forms.MenuStrip();
            this.altaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAltaCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.mascotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerMascotas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAltaMascota = new System.Windows.Forms.ToolStripMenuItem();
            this.turnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerTurnos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNuevoTurno = new System.Windows.Forms.ToolStripMenuItem();
            this.archivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportarDatos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportarDatos = new System.Windows.Forms.ToolStripMenuItem();
            this.dtgResultados = new System.Windows.Forms.DataGridView();
            this.mnuContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuContainer
            // 
            this.mnuContainer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaToolStripMenuItem,
            this.mascotasToolStripMenuItem,
            this.turnosToolStripMenuItem,
            this.archivosToolStripMenuItem});
            this.mnuContainer.Location = new System.Drawing.Point(0, 0);
            this.mnuContainer.Name = "mnuContainer";
            this.mnuContainer.Size = new System.Drawing.Size(589, 24);
            this.mnuContainer.TabIndex = 4;
            this.mnuContainer.Text = "menuStrip";
            // 
            // altaToolStripMenuItem
            // 
            this.altaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVerClientes,
            this.mnuAltaCliente});
            this.altaToolStripMenuItem.Name = "altaToolStripMenuItem";
            this.altaToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.altaToolStripMenuItem.Text = "Clientes";
            // 
            // mnuVerClientes
            // 
            this.mnuVerClientes.Name = "mnuVerClientes";
            this.mnuVerClientes.Size = new System.Drawing.Size(169, 22);
            this.mnuVerClientes.Text = "Ver clientes";
            this.mnuVerClientes.Click += new System.EventHandler(this.mnuVerClientes_Click);
            // 
            // mnuAltaCliente
            // 
            this.mnuAltaCliente.Name = "mnuAltaCliente";
            this.mnuAltaCliente.Size = new System.Drawing.Size(169, 22);
            this.mnuAltaCliente.Text = "Alta nuevo cliente";
            this.mnuAltaCliente.Click += new System.EventHandler(this.mnuAltaCliente_Click);
            // 
            // mascotasToolStripMenuItem
            // 
            this.mascotasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVerMascotas,
            this.mnuAltaMascota});
            this.mascotasToolStripMenuItem.Name = "mascotasToolStripMenuItem";
            this.mascotasToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.mascotasToolStripMenuItem.Text = "Mascotas";
            // 
            // mnuVerMascotas
            // 
            this.mnuVerMascotas.Name = "mnuVerMascotas";
            this.mnuVerMascotas.Size = new System.Drawing.Size(156, 22);
            this.mnuVerMascotas.Text = "Ver mascotas";
            this.mnuVerMascotas.Click += new System.EventHandler(this.mnuVerMascotas_Click);
            // 
            // mnuAltaMascota
            // 
            this.mnuAltaMascota.Name = "mnuAltaMascota";
            this.mnuAltaMascota.Size = new System.Drawing.Size(156, 22);
            this.mnuAltaMascota.Text = "Nueva mascota";
            this.mnuAltaMascota.Click += new System.EventHandler(this.mnuAltaMascota_Click);
            // 
            // turnosToolStripMenuItem
            // 
            this.turnosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVerTurnos,
            this.mnuNuevoTurno});
            this.turnosToolStripMenuItem.Name = "turnosToolStripMenuItem";
            this.turnosToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.turnosToolStripMenuItem.Text = "Turnos";
            // 
            // mnuVerTurnos
            // 
            this.mnuVerTurnos.Name = "mnuVerTurnos";
            this.mnuVerTurnos.Size = new System.Drawing.Size(141, 22);
            this.mnuVerTurnos.Text = "Ver turnos";
            this.mnuVerTurnos.Click += new System.EventHandler(this.mnuVerTurnos_Click);
            // 
            // mnuNuevoTurno
            // 
            this.mnuNuevoTurno.Name = "mnuNuevoTurno";
            this.mnuNuevoTurno.Size = new System.Drawing.Size(141, 22);
            this.mnuNuevoTurno.Text = "Nuevo turno";
            this.mnuNuevoTurno.Click += new System.EventHandler(this.mnuNuevoTurno_Click);
            // 
            // archivosToolStripMenuItem
            // 
            this.archivosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImportarDatos,
            this.mnuExportarDatos});
            this.archivosToolStripMenuItem.Name = "archivosToolStripMenuItem";
            this.archivosToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.archivosToolStripMenuItem.Text = "Archivos";
            // 
            // mnuImportarDatos
            // 
            this.mnuImportarDatos.Name = "mnuImportarDatos";
            this.mnuImportarDatos.Size = new System.Drawing.Size(152, 22);
            this.mnuImportarDatos.Text = "Importar datos";
            this.mnuImportarDatos.Click += new System.EventHandler(this.mnuImportarDatos_Click);
            // 
            // mnuExportarDatos
            // 
            this.mnuExportarDatos.Name = "mnuExportarDatos";
            this.mnuExportarDatos.Size = new System.Drawing.Size(152, 22);
            this.mnuExportarDatos.Text = "Exportar datos";
            this.mnuExportarDatos.Click += new System.EventHandler(this.mnuExportarDatos_Click);
            // 
            // dtgResultados
            // 
            this.dtgResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgResultados.Location = new System.Drawing.Point(0, 24);
            this.dtgResultados.Name = "dtgResultados";
            this.dtgResultados.RowTemplate.Height = 25;
            this.dtgResultados.Size = new System.Drawing.Size(589, 247);
            this.dtgResultados.TabIndex = 5;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 271);
            this.Controls.Add(this.dtgResultados);
            this.Controls.Add(this.mnuContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnuContainer;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Veterinaria";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.mnuContainer.ResumeLayout(false);
            this.mnuContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mnuContainer;
        private System.Windows.Forms.ToolStripMenuItem altaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAltaCliente;
        private System.Windows.Forms.ToolStripMenuItem mascotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAltaMascota;
        private System.Windows.Forms.ToolStripMenuItem archivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuImportarDatos;
        private System.Windows.Forms.ToolStripMenuItem mnuExportarDatos;
        private System.Windows.Forms.DataGridView dtgResultados;
        private System.Windows.Forms.ToolStripMenuItem mnuVerClientes;
        private System.Windows.Forms.ToolStripMenuItem mnuVerMascotas;
        private System.Windows.Forms.ToolStripMenuItem turnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuNuevoTurno;
        private System.Windows.Forms.ToolStripMenuItem mnuVerTurnos;
    }
}