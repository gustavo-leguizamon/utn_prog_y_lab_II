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
using Vista.Mapeadores;
using Vista.Modelos;

namespace Vista
{
    public partial class FrmMain : Form
    {
        private ClienteDAO clienteDAO;
        private MascotaDAO mascotaDAO;
        private TurnoDAO turnoDAO;

        private ArchivoXml<List<Cliente>> archivoXml;
        private ArchivoJson<List<Cliente>> archivoJson;

        public FrmMain()
        {
            InitializeComponent();

            this.clienteDAO = new ClienteDAO();
            this.mascotaDAO = new MascotaDAO();
            this.turnoDAO = new TurnoDAO();

            this.archivoXml = new ArchivoXml<List<Cliente>>();
            this.archivoJson = new ArchivoJson<List<Cliente>>();
        }

        private void ActualizarDatosClientes()
        {
            List<Cliente> clientes = this.clienteDAO.Leer();
            dtgResultados.DataSource = ClienteMapper.Map(clientes);
            dtgResultados.Columns["Id"].Visible = false;
            dtgResultados.Update();
            dtgResultados.Refresh();
        }

        private void ActualizarDatosMascotas()
        {
            List<Mascota> mascotas = this.mascotaDAO.Leer(new Type[] { typeof(Cliente) });
            dtgResultados.DataSource = MascotaMapper.Map(mascotas);
            dtgResultados.Columns["Id"].Visible = true;
            dtgResultados.Update();
            dtgResultados.Refresh();
        }

        private void ActualizarDatosTurnos()
        {
            List<Turno> turnos = this.turnoDAO.Leer(new Type[] { typeof(Mascota) });
            dtgResultados.DataSource = TurnoMapper.Map(turnos);
            dtgResultados.Update();
            dtgResultados.Refresh();
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
                    List<Cliente> clientes = null;
                    try
                    {
                        archivoXml.ValidarExtension(openFileDialog.FileName);
                        clientes = archivoXml.Leer(openFileDialog.FileName);
                    }
                    catch (ExtensionIncorrectaException)
                    {
                        clientes = archivoJson.Leer(openFileDialog.FileName);
                    }

                    List<Cliente> clientesGuardar = new List<Cliente>();
                    List<Mascota> mascotasGuardar = new List<Mascota>();
                    List<Turno> turnosGuardar = new List<Turno>();

                    foreach (Cliente cliente in clientes)
                    {
                        foreach (Mascota mascota in cliente.Mascotas)
                        {
                            foreach (Turno turno in mascota.Turnos)
                            {
                                try
                                {
                                    this.turnoDAO.Existe(turno.Id);
                                }
                                catch (EntidadInexistenteException)
                                {
                                    turnosGuardar.Add(turno);
                                }
                            }

                            try
                            {
                                this.mascotaDAO.Existe(mascota.Id);
                            }
                            catch (EntidadInexistenteException)
                            {
                                mascotasGuardar.Add(mascota);
                            }
                        }

                        try
                        {
                            this.clienteDAO.Existe(cliente.Dni);
                        }
                        catch (EntidadInexistenteException)
                        {
                            clientesGuardar.Add(cliente);
                        }
                    }

                    this.clienteDAO.Guardar(clientesGuardar);
                    this.mascotaDAO.Guardar(mascotasGuardar);
                    this.turnoDAO.Guardar(turnosGuardar);
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
                    List<Cliente> clientes = this.clienteDAO.Leer(new Type[] { typeof(Mascota), typeof(Turno) });
                    try
                    {
                        archivoXml.ValidarExtension(saveFileDialog.FileName);
                        archivoXml.Guardar(saveFileDialog.FileName, clientes);
                    }
                    catch (ExtensionIncorrectaException)
                    {
                        archivoJson.Guardar(saveFileDialog.FileName, clientes);
                    }

                    MessageBox.Show($"Se realizó la exportación de {clientes.Count} clientes", "Exportación completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show($"No tiene permisos para guardar el archivo en esa carpeta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.clienteDAO.OnNuevosDatos += ActualizarDatosClientes;
            this.mascotaDAO.OnNuevosDatos += ActualizarDatosMascotas;
            this.turnoDAO.OnNuevosDatos += ActualizarDatosTurnos;

            DateTime? fecha = null;
            try
            {
                fecha = this.turnoDAO.Min(x => x.Fecha);
            }
            catch (InvalidOperationException)
            {

            }

            new FrmProximoTurno(fecha).Show();

            ActualizarDatosClientes();
        }

        private void mnuVerClientes_Click(object sender, EventArgs e)
        {
            //dtgResultados.Visible = true;
            //dtgMascotas.Visible = false;
            //dtgTurnos.Visible = false;
            ActualizarDatosClientes();
        }

        private void mnuVerMascotas_Click(object sender, EventArgs e)
        {
            //dtgResultados.Visible = false;
            //dtgMascotas.Visible = true;
            //dtgTurnos.Visible = false;
            ActualizarDatosMascotas();
        }

        private void mnuVerTurnos_Click(object sender, EventArgs e)
        {
            //dtgResultados.Visible = false;
            //dtgMascotas.Visible = false;
            //dtgTurnos.Visible = true;
            ActualizarDatosTurnos();
        }

        private void mnuNuevoTurno_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCargarTurno frm = new FrmCargarTurno(this.turnoDAO);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Se agregó el turno!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado. {ex.Message} - {ex.StackTrace}");
            }
        }
    }
}
