using Archivos;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmMain : Form
    {
        private List<Cliente> clientes;

        public FrmMain()
        {
            InitializeComponent();

            this.clientes = new List<Cliente>();
        }

        private void btnCargarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCargaCliente frm = new FrmCargaCliente(this.clientes);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Se agregó el cliente!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado. {ex.Message} - {ex.StackTrace}");
            }
        }

        private void btnCargarMascota_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCargaMascota frm = new FrmCargaMascota(this.clientes);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Se agregó la mascota!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado. {ex.Message} - {ex.StackTrace}");
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnExportarClientes_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    Filter = "Archivos JSON (.json)|*.json|Archivos XML (.xml)|*.xml",
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ArchivoXml<List<Cliente>> xml = new ArchivoXml<List<Cliente>>();
                    xml.Guardar(saveFileDialog.FileName, this.clientes);
                    MessageBox.Show($"Se realizó la exportación de {this.clientes.Count} clientes", "Exportación completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado. {ex.Message} - {ex.StackTrace}");
            }
        }

        private void btnImportarClientes_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Filter = "Archivos JSON (.json)|*.json|Archivos XML (.xml)|*.xml",
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ArchivoXml<List<Cliente>> xml = new ArchivoXml<List<Cliente>>();
                    this.clientes = xml.Leer(openFileDialog.FileName);
                    MessageBox.Show($"Se realizó la importación de {this.clientes.Count} clientes", "Importación completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado. {ex.Message} - {ex.StackTrace}");
            }
        }
    }
}
