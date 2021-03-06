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
            this.btnCargarCliente = new System.Windows.Forms.Button();
            this.btnCargarMascota = new System.Windows.Forms.Button();
            this.btnExportarClientes = new System.Windows.Forms.Button();
            this.btnImportarClientes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCargarCliente
            // 
            this.btnCargarCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCargarCliente.Location = new System.Drawing.Point(12, 12);
            this.btnCargarCliente.Name = "btnCargarCliente";
            this.btnCargarCliente.Size = new System.Drawing.Size(279, 49);
            this.btnCargarCliente.TabIndex = 0;
            this.btnCargarCliente.Text = "Cargar nuevo cliente";
            this.btnCargarCliente.UseVisualStyleBackColor = true;
            this.btnCargarCliente.Click += new System.EventHandler(this.btnCargarCliente_Click);
            // 
            // btnCargarMascota
            // 
            this.btnCargarMascota.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCargarMascota.Location = new System.Drawing.Point(297, 12);
            this.btnCargarMascota.Name = "btnCargarMascota";
            this.btnCargarMascota.Size = new System.Drawing.Size(279, 49);
            this.btnCargarMascota.TabIndex = 1;
            this.btnCargarMascota.Text = "Cargar nueva mascota";
            this.btnCargarMascota.UseVisualStyleBackColor = true;
            this.btnCargarMascota.Click += new System.EventHandler(this.btnCargarMascota_Click);
            // 
            // btnExportarClientes
            // 
            this.btnExportarClientes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExportarClientes.Location = new System.Drawing.Point(12, 67);
            this.btnExportarClientes.Name = "btnExportarClientes";
            this.btnExportarClientes.Size = new System.Drawing.Size(279, 49);
            this.btnExportarClientes.TabIndex = 2;
            this.btnExportarClientes.Text = "Exportar clientes";
            this.btnExportarClientes.UseVisualStyleBackColor = true;
            this.btnExportarClientes.Click += new System.EventHandler(this.btnExportarClientes_Click);
            // 
            // btnImportarClientes
            // 
            this.btnImportarClientes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnImportarClientes.Location = new System.Drawing.Point(298, 67);
            this.btnImportarClientes.Name = "btnImportarClientes";
            this.btnImportarClientes.Size = new System.Drawing.Size(279, 49);
            this.btnImportarClientes.TabIndex = 3;
            this.btnImportarClientes.Text = "Importar clientes";
            this.btnImportarClientes.UseVisualStyleBackColor = true;
            this.btnImportarClientes.Click += new System.EventHandler(this.btnImportarClientes_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 146);
            this.Controls.Add(this.btnImportarClientes);
            this.Controls.Add(this.btnExportarClientes);
            this.Controls.Add(this.btnCargarMascota);
            this.Controls.Add(this.btnCargarCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Veterinaria";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCargarCliente;
        private System.Windows.Forms.Button btnCargarMascota;
        private System.Windows.Forms.Button btnExportarClientes;
        private System.Windows.Forms.Button btnImportarClientes;
    }
}