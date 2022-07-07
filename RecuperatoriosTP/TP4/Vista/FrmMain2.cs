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
            Cliente cliente = this.lstClientes.SelectedItem as Cliente;
            if (cliente is not null)
            {
                HabilitarModificacionCliente(true);
                BuscarMascotas(cliente);
            }
            else
            {
                HabilitarModificacionCliente(false);
                HabilitarModificacionMascota(false);
            }
        }

        #endregion

        #region ListBox Mascotas

        private void lstMascotas_Click(object sender, EventArgs e)
        {
            Mascota mascota = this.lstMascotas.SelectedItem as Mascota;
            if (mascota is not null)
            {
                HabilitarModificacionMascota(true);
            }
            else
            {
                HabilitarModificacionMascota(false);
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
            this.lstClientes.Update();
            this.lstClientes.Refresh();
            this.lstClientes.SelectedItem = null;
            HabilitarModificacionCliente(false);
        }

        //private void ActualizarDatosMascotas()
        //{
        //    List<Mascota> mascotas = this.mascotaDAO.Leer(new Type[] { typeof(Cliente) });
        //    this.lstMascotas.Items.Clear();
        //    this.lstMascotas.DataSource = mascotas;
        //    this.lstMascotas.Update();
        //    this.lstMascotas.Refresh();
        //}

        private void HabilitarModificacionCliente(bool habilitar)
        {
            this.btnEditarCliente.Enabled = habilitar;
            this.btnEliminarCliente.Enabled = habilitar;
        }

        private void HabilitarModificacionMascota(bool habilitar)
        {
            this.btnEditarMascota.Enabled = habilitar;
            this.btnEliminarMascota.Enabled = habilitar;
        }

        private void BuscarMascotas(Cliente cliente)
        {
            List<Mascota> mascotas = this.mascotaDAO.Leer(mascota => mascota.ClienteId == cliente.Id);
            //this.lstMascotas.Items.Clear();
            this.lstMascotas.DataSource = mascotas;
            this.lstMascotas.Update();
            this.lstMascotas.Refresh();
            this.lstMascotas.SelectedItem = null;
            HabilitarModificacionMascota(false);
        }

        //private void ActualizarDatosTurnos()
        //{
        //    List<Turno> turnos = this.turnoDAO.Leer(new Type[] { typeof(Mascota) });
        //    dtgResultados.DataSource = TurnoMapper.Map(turnos);
        //    dtgResultados.Update();
        //    dtgResultados.Refresh();
        //}

        #endregion

    }
}
