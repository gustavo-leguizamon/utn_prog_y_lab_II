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
using Vista.Exceptions;

namespace Vista
{
    public partial class FrmMain2 : Form
    {
        private ClienteDAO clienteDAO;
        private MascotaDAO mascotaDAO;
        private TurnoDAO turnoDAO;

        public FrmMain2()
        {
            InitializeComponent();

            this.clienteDAO = new ClienteDAO();
            this.mascotaDAO = new MascotaDAO();
            this.turnoDAO = new TurnoDAO();
        }

        #region Eventos

        #region Form

        private void FrmMain2_Load(object sender, EventArgs e)
        {
            this.clienteDAO.OnNuevosDatos += ActualizarDatosClientes;
            //this.mascotaDAO.OnNuevosDatos += ActualizarDatosMascotas;
            //this.turnoDAO.OnNuevosDatos += ActualizarDatosTurnos;

            ActualizarDatosClientes();
            //ActualizarDatosMascotas();
        }

        private void FrmMain2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region ListBox Clientes

        private void lstClientes_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = ClienteSeleccionado();
                this.btnNuevaMascota.Enabled = true;
                HabilitarControlesCliente(true);
                BuscarMascotas(cliente);
            }
            catch (ElementoNoSeleccionadoException)
            {
                HabilitarControlesCliente(false);
                HabilitarControlesMascota(false);
            }
            //Cliente cliente = this.lstClientes.SelectedItem as Cliente;
            //if (cliente is not null)
            //{
            //    this.btnNuevaMascota.Enabled = true;
            //    HabilitarControlesCliente(true);
            //    BuscarMascotas(cliente);
            //}
            //else
            //{
            //    HabilitarControlesCliente(false);
            //    HabilitarControlesMascota(false);
            //}
        }
        private void lstClientes_DoubleClick(object sender, EventArgs e)
        {
            VerDatosCliente(eFrmABM.Ver);
        }

        #endregion

        #region ListBox Mascotas

        private void lstMascotas_Click(object sender, EventArgs e)
        {
            try
            {
                MascotaSeleccionada();
                HabilitarControlesMascota(true);
            }
            catch (ElementoNoSeleccionadoException)
            {
                HabilitarControlesMascota(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado. {ex.Message} - {ex.StackTrace}");
            }

            //Mascota mascota = this.lstMascotas.SelectedItem as Mascota;
            //if (mascota is not null)
            //{
            //    HabilitarControlesMascota(true);
            //}
            //else
            //{
            //    HabilitarControlesMascota(false);
            //}
        }

        #endregion

        #region Botones

        private void btnVerCliente_Click(object sender, EventArgs e)
        {
            VerDatosCliente(eFrmABM.Ver);
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            VerDatosCliente(eFrmABM.Editar);
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new FrmABMCliente(this.clienteDAO);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Se agregó el cliente!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado. {ex.Message} - {ex.StackTrace}");
            }
        }

        private void btnVerMascota_Click(object sender, EventArgs e)
        {
            VerDatosMascota(eFrmABM.Ver);
        }

        private void btnEditarMascota_Click(object sender, EventArgs e)
        {
            VerDatosMascota(eFrmABM.Editar);
        }

        private void btnNuevaMascota_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new FrmABMMascota(this.mascotaDAO, ClienteSeleccionado());
                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Se agregó la mascota!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ElementoNoSeleccionadoException)
            {
                MessageBox.Show("Debe seleccionar un cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado. {ex.Message} - {ex.StackTrace}");
            }
        }

        #endregion

        #endregion

        #region Metodos

        private void ActualizarDatosClientes()
        {
            List<Cliente> clientes = this.clienteDAO.Leer();
            //this.lstClientes.Items.Clear();
            this.lstClientes.DataSource = clientes;
            this.lstClientes.SelectedItem = null;
            this.lstClientes.Update();
            this.lstClientes.Refresh();
            HabilitarControlesCliente(false);
        }

        //private void ActualizarDatosMascotas()
        //{
        //    List<Mascota> mascotas = this.mascotaDAO.Leer(new Type[] { typeof(Cliente) });
        //    this.lstMascotas.Items.Clear();
        //    this.lstMascotas.DataSource = mascotas;
        //    this.lstMascotas.Update();
        //    this.lstMascotas.Refresh();
        //}

        private void HabilitarControlesCliente(bool habilitar)
        {
            this.btnEditarCliente.Enabled = habilitar;
            this.btnEliminarCliente.Enabled = habilitar;
            this.btnVerCliente.Enabled = habilitar;
        }

        private void HabilitarControlesMascota(bool habilitar)
        {
            //this.btnNuevaMascota.Enabled = habilitar;
            this.btnEditarMascota.Enabled = habilitar;
            this.btnEliminarMascota.Enabled = habilitar;
            this.btnVerMascota.Enabled = habilitar;
        }

        private void BuscarMascotas(Cliente cliente)
        {
            List<Mascota> mascotas = this.mascotaDAO.Leer(mascota => mascota.ClienteId == cliente.Id);
            //this.lstMascotas.Items.Clear();
            this.lstMascotas.DataSource = mascotas;
            this.lstMascotas.SelectedItem = null;
            this.lstMascotas.Update();
            this.lstMascotas.Refresh();
            HabilitarControlesMascota(false);
        }

        //private void ActualizarDatosTurnos()
        //{
        //    List<Turno> turnos = this.turnoDAO.Leer(new Type[] { typeof(Mascota) });
        //    dtgResultados.DataSource = TurnoMapper.Map(turnos);
        //    dtgResultados.Update();
        //    dtgResultados.Refresh();
        //}

        private void VerDatosCliente(eFrmABM eFrmABM)
        {
            try
            {
                Form form = new FrmABMCliente(this.clienteDAO, eFrmABM, ClienteSeleccionado());
                form.ShowDialog();
            }
            catch (ElementoNoSeleccionadoException)
            {
                MessageBox.Show("Debe seleccionar un cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado. {ex.Message} - {ex.StackTrace}");
            }
        }

        private Cliente ClienteSeleccionado()
        {
            Cliente cliente = this.lstClientes.SelectedItem as Cliente;
            if (cliente is null)
            {
                throw new ElementoNoSeleccionadoException();
            }
            return cliente;
        }

        private void VerDatosMascota(eFrmABM eFrmABM)
        {
            try
            {
                Form form = new FrmABMMascota(this.mascotaDAO, eFrmABM, MascotaSeleccionada());
                form.ShowDialog();
            }
            catch (ElementoNoSeleccionadoException)
            {
                MessageBox.Show("Debe seleccionar una mascota", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado. {ex.Message} - {ex.StackTrace}");
            }
        }

        private Mascota MascotaSeleccionada()
        {
            Mascota mascota = this.lstMascotas.SelectedItem as Mascota;
            mascota.Cliente = ClienteSeleccionado();
            if (mascota is null)
            {
                throw new ElementoNoSeleccionadoException();
            }
            return mascota;
        }

        #endregion

    }
}
