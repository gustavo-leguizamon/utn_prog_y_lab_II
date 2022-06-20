using Archivos;
using Datos;
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
        private ClienteDAO clienteDAO;
        private MascotaDAO mascotaDAO;

        public FrmMain()
        {
            InitializeComponent();

            this.clienteDAO = new ClienteDAO();
            this.mascotaDAO = new MascotaDAO();
        }

        private void ActualizarDatosClientes()
        {
            dtgClientes.DataSource = this.clienteDAO.Leer();
            dtgClientes.Update();
            dtgClientes.Refresh();
        }

        private void ActualizarDatosMascotas()
        {
            dtgMascotas.DataSource = this.mascotaDAO.Leer();
            dtgMascotas.Update();
            dtgMascotas.Refresh();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #region Archivos

        private void mnuImportarDatos_Click(object sender, EventArgs e)
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
                    List<Cliente> clientes = xml.Leer(openFileDialog.FileName);
                    this.clienteDAO.Guardar(clientes);
                    MessageBox.Show($"Se realizó la importación de {clientes.Count} clientes", "Importación completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"No se pudo importar los datos. Revise el archivo seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado. {ex.Message} - {ex.StackTrace}");
            }
        }

        private void mnuExportarDatos_Click(object sender, EventArgs e)
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
                    List<Cliente> clientes = this.clienteDAO.Leer();
                    xml.Guardar(saveFileDialog.FileName, clientes);
                    MessageBox.Show($"Se realizó la exportación de {clientes.Count} clientes", "Exportación completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo exportar los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void mnuAltaMascota_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCargaMascota frm = new FrmCargaMascota(this.mascotaDAO);
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

        private void mnuAltaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCargaCliente frm = new FrmCargaCliente(this.clienteDAO);
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

        private void FrmMain_Load(object sender, EventArgs e)
        {
            dtgClientes.DataSource = this.clienteDAO.Leer();
            this.clienteDAO.OnNuevosDatos += ActualizarDatosClientes;
            this.mascotaDAO.OnNuevosDatos += ActualizarDatosMascotas;
        }

        private void mnuVerClientes_Click(object sender, EventArgs e)
        {
            dtgClientes.Visible = true;
            dtgMascotas.Visible = false;
            ActualizarDatosClientes();
        }

        private void mnuVerMascotas_Click(object sender, EventArgs e)
        {
            dtgClientes.Visible = false;
            dtgMascotas.Visible = true;
            ActualizarDatosMascotas();
        }
    }
}
