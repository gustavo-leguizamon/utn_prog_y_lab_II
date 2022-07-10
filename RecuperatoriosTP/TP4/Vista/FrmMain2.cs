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
            this.clienteDAO.OnNuevosDatos += BuscarClientes;
            //this.mascotaDAO.OnNuevosDatos += ActualizarDatosMascotas;
            //this.turnoDAO.OnNuevosDatos += ActualizarDatosTurnos;

            BuscarClientes();
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

        #region ListBox

        private void lstClientes_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = ClienteSeleccionado();
                this.btnNuevaMascota.Enabled = true;
                ColocarTextoBotonEliminacion(this.btnEliminarCliente, cliente);
                HabilitarControlesCliente(true);
                BuscarMascotas(cliente);
            }
            catch (ElementoNoSeleccionadoException)
            {
                HabilitarControlesCliente(false);
                HabilitarControlesMascota(false);
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
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

        private void lstMascotas_Click(object sender, EventArgs e)
        {
            try
            {
                Mascota mascota = MascotaSeleccionada();
                ColocarTextoBotonEliminacion(this.btnEliminarMascota, mascota);
                HabilitarControlesMascota(true);
            }
            catch (ElementoNoSeleccionadoException)
            {
                HabilitarControlesMascota(false);
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }


        private void lstBox_MarcarActivos(object sender, DrawItemEventArgs e)
        {
            //IActivable item = this.lstClientes.Items[e.Index] as IActivable;
            //if (item != null)
            //{
            //    Color color = Color.Black;
            //    if (!item.Activo)
            //    {
            //        color = Color.Red;
            //    }
            //    e.Graphics.DrawString(
            //        item.ToString(),
            //        this.lstClientes.Font,
            //        new SolidBrush(color),
            //        e.Bounds.X, // Use e.Bounds on these two lines.
            //        e.Bounds.Y
            //    );
            //}
            //else
            //{
            //    // The item isn't a MyListBoxItem, do something about it
            //}


            try
            {
                e.DrawBackground();
                Brush myBrush = Brushes.Black;

                //int sayi = Convert.ToInt32(((ListBox)sender).Items[e.Index].ToString());
                IActivable activable = ((ListBox)sender).Items[e.Index] as IActivable;
                if (activable is not null && !activable.Activo)
                {
                    myBrush = Brushes.Red;
                }

                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

                e.DrawFocusRectangle();
            }
            catch
            {

            }
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
            try
            {
                Cliente cliente = ClienteSeleccionado();
                if (MessageBox.Show($"Dar de baja al cliente: {cliente.NombreCompleto}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.clienteDAO.EliminarLogico(cliente);
                }
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
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
                //MessageBox.Show($"Error inesperado. {ex.Message} - {ex.StackTrace}");
                ManejarExcepcion(ex);
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

        private void btnEliminarMascota_Click(object sender, EventArgs e)
        {
            try
            {
                Mascota mascota = MascotaSeleccionada();
                if (MessageBox.Show($"Dar de baja la mascota {mascota.Nombre} del cliente {mascota.Cliente.NombreCompleto}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.mascotaDAO.EliminarLogico(mascota);
                }
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
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
            //catch (ElementoNoSeleccionadoException)
            //{
            //    MessageBox.Show("Debe seleccionar un cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            catch (Exception ex)
            {
                //MessageBox.Show($"Error inesperado. {ex.Message} - {ex.StackTrace}");
                ManejarExcepcion(ex);
            }
        }

        private void btnCargarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new FrmABMTurno(turnoDAO, MascotaSeleccionada());
                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Se generó correctamente el turno!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        #endregion

        #region Menu

        private void mnuTurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion

        #region Metodos

        private void ManejarExcepcion(Exception exception)
        {
            if (exception is ElementoNoSeleccionadoException ||
                exception is ArgumentException)
            {
                MessageBox.Show(exception.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show($"Error inesperado. {exception.Message} - {exception.StackTrace}");
            }
        }

        private void BuscarClientes()
        {
            List<Cliente> clientes = this.clienteDAO.Leer();
            //this.lstClientes.Items.Clear();
            this.lstClientes.DataSource = clientes;
            this.lstClientes.SelectedItem = null;
            this.lstClientes.Update();
            this.lstClientes.Refresh();
            HabilitarControlesCliente(false);
        }

        private void MarcarInactivos(ListBox.ObjectCollection objectCollection)
        {
            for (int i = 0; i < objectCollection.Count; i++)
            {
                if (!(objectCollection[i] as IActivable).Activo)
                {
                    //objectCollection[i].
                }
            }

            foreach (object item in objectCollection)
            {
                IActivable activable = item as IActivable;
                if (activable is null)
                {

                }
                else
                {

                }
            }
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
            this.btnCargarTurno.Enabled = habilitar;
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
            //catch (ElementoNoSeleccionadoException)
            //{
            //    MessageBox.Show("Debe seleccionar un cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            catch (Exception ex)
            {
                //MessageBox.Show($"Error inesperado. {ex.Message} - {ex.StackTrace}");
                ManejarExcepcion(ex);
            }
        }

        private Cliente ClienteSeleccionado()
        {
            Cliente cliente = this.lstClientes.SelectedItem as Cliente;
            if (cliente is null)
            {
                throw new ElementoNoSeleccionadoException("Debe seleccionar un cliente");
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
            //catch (ElementoNoSeleccionadoException)
            //{
            //    MessageBox.Show("Debe seleccionar una mascota", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            catch (Exception ex)
            {
                //MessageBox.Show($"Error inesperado. {ex.Message} - {ex.StackTrace}");
                ManejarExcepcion(ex);
            }
        }

        private Mascota MascotaSeleccionada()
        {
            Mascota mascota = this.lstMascotas.SelectedItem as Mascota;
            if (mascota is null)
            {
                throw new ElementoNoSeleccionadoException("Debe seleccionar una mascota");
            }
            mascota.Cliente = ClienteSeleccionado();
            return mascota;
        }

        private void ColocarTextoBotonEliminacion(Button button, IActivable activable)
        {
            if (activable.Activo)
            {
                button.Text = "Eliminar";
            }
            else
            {
                button.Text = "Reactivar";
            }
        }

        #endregion

    }
}
