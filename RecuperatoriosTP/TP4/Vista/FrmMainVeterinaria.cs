using Archivos;
using Datos;
using Datos.Exceptions;
using Entidades;
using Logica;
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
    public partial class FrmMainVeterinaria : Form
    {
        private ClienteDAO clienteDAO;
        private MascotaDAO mascotaDAO;
        private TurnoDAO turnoDAO;

        private Temporizador temporizadorRestante;
        private ProximoTurno proximoTurno;

        public FrmMainVeterinaria()
        {
            InitializeComponent();

            this.clienteDAO = new ClienteDAO();
            this.mascotaDAO = new MascotaDAO();
            this.turnoDAO = new TurnoDAO();

            this.temporizadorRestante = new Temporizador(1000);
        }

        #region Eventos

        #region Form

        private void FrmMainVeterinaria_Load(object sender, EventArgs e)
        {

            //CLASE 19 - Eventos
            this.clienteDAO.OnNuevosDatos += BuscarClientes;
            this.mascotaDAO.OnNuevosDatos += ActualizarMascotas;
            this.turnoDAO.OnNuevosDatos += ReiniciarTemporizador;
            this.temporizadorRestante.OnTimerCompleto += AsignarHoraRestante;
            this.temporizadorRestante.OnTimerReiniciar += ReiniciarHoraRestante;
            this.temporizadorRestante.Comenzar();

            BuscarClientes();
        }

        private void FrmMainVeterinaria_FormClosing(object sender, FormClosingEventArgs e)
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
        }

        private void lstClientes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DatosCliente(eFrmABM.Ver);
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        private void lstMascotas_Click(object sender, EventArgs e)
        {
            try
            {
                Mascota mascota = MascotaSeleccionada();
                ColocarTextoBotonEliminacion(this.btnEliminarMascota, mascota);
                HabilitarControlesMascota(true);
                HabilitarBoton(this.btnCargarTurno, mascota);
                HabilitarBoton(this.btnRegistrarVisita, mascota);
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

        private void lstMascotas_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DatosMascota(eFrmABM.Ver);
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        /// <summary>
        /// Marca las entidades activas o no de un ListBox
        /// 
        /// CLASE 13 - Interfaces
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstBox_MarcarActivos(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                Brush myBrush = Brushes.Black;

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
            try
            {
                DatosCliente(eFrmABM.Ver);
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                DatosCliente(eFrmABM.Editar);
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = ClienteSeleccionado();
                string mensaje = cliente.Activo ? $"Dar de baja" : $"Reactivar";
                mensaje += $" al cliente: {cliente.NombreCompleto}?";

                if (MessageBox.Show(mensaje, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.clienteDAO.Activacion(cliente, !cliente.Activo);
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
                ManejarExcepcion(ex);
            }
        }

        private void btnVerMascota_Click(object sender, EventArgs e)
        {
            try
            {
                DatosMascota(eFrmABM.Ver);
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        private void btnEditarMascota_Click(object sender, EventArgs e)
        {
            try
            {
                DatosMascota(eFrmABM.Editar);
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        private void btnEliminarMascota_Click(object sender, EventArgs e)
        {
            try
            {
                Mascota mascota = MascotaSeleccionada();
                string mensaje = mascota.Activo ? "Dar de baja" : "Reactivar";
                mensaje += $" la mascota {mascota.Nombre} del cliente {mascota.Cliente.NombreCompleto}?";

                if (MessageBox.Show(mensaje, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.mascotaDAO.Activacion(mascota, !mascota.Activo);
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
            catch (Exception ex)
            {
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
                    ReiniciarTemporizador();
                    MessageBox.Show("Se generó correctamente el turno!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }
        
        private void btnRegistrarVisita_Click(object sender, EventArgs e)
        {
            try
            {
                Mascota mascota = MascotaSeleccionada();
                Form form = new FrmRegistroVisita(mascota);
                form.ShowDialog();
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
            try
            {
                Form form = new FrmListadoDeTurnos();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        private void mnuAtencionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new FrmRegistroAtenciones();
                form.ShowDialog();
            }
            catch(Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        /// <summary>
        /// Maneja el evento al exportar clientes
        /// 
        /// CLASE 10 - Excepciones
        /// CLASE 12 - Tipos genericos
        /// CLASE 13 - Interfaces
        /// CLASE 14 - Archivos y serializacion
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="ArchivoException"></exception>
        private void mnuExportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog()
                    {
                        Filter = "Archivos JSON (.json)|*.json|Archivos XML (.xml)|*.xml",
                    };
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        IArchivo<List<Cliente>> archivo = ManejadorArchivo.ObtenerArchivo<List<Cliente>>(saveFileDialog.FileName);
                        List<Cliente> clientes = this.clienteDAO.Leer(new Type[] { typeof(Mascota), typeof(Turno), typeof(Atencion) });
                        archivo.Guardar(saveFileDialog.FileName, clientes);

                        MessageBox.Show($"Se realizó la exportación de {clientes.Count} clientes", "Exportación completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (ArchivoException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw new ArchivoException("No se pudo exportar los datos.", ex);
                }
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        /// <summary>
        /// Maneja el evento al importar clientes
        /// 
        /// CLASE 10 - Excepciones
        /// CLASE 12 - Tipos genericos
        /// CLASE 13 - Interfaces
        /// CLASE 14 - Archivos y serializacion
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="ArchivoException"></exception>
        private void mnuImportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog()
                    {
                        Filter = "Archivos JSON (.json)|*.json|Archivos XML (.xml)|*.xml",
                    };
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        IArchivo<List<Cliente>> archivo = ManejadorArchivo.ObtenerArchivo<List<Cliente>>(openFileDialog.FileName);
                        List<Cliente> clientes = archivo.Leer(openFileDialog.FileName);

                        this.clienteDAO.Guardar(clientes, true);

                        MessageBox.Show($"Se realizó la importación de {clientes.Count} clientes", "Importación completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (ArchivoException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw new ArchivoException($"No se pudo importar los datos. Revise el archivo seleccionado.", ex);
                }
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        #endregion

        #endregion

        #region Metodos

        /// <summary>
        /// Maneja las excepciones ocurridas en el formulario
        /// 
        /// CLASE 10 - Excepciones
        /// 
        /// </summary>
        /// <param name="exception">Excepcion que ocurrio</param>
        private void ManejarExcepcion(Exception exception)
        {
            if (exception is ElementoNoSeleccionadoException ||
                exception is ArgumentException)
            {
                MessageBox.Show(exception.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (exception is NotImplementedException)
            {
                MessageBox.Show("Hay partes sin implementar de la aplicación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (exception is NoHayMasTurnosException)
            {

            }
            else if (exception is ArchivoException)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Error inesperado. {exception.Message} - {exception.StackTrace}");
            }
        }

        /// <summary>
        /// Actualiza la cuenta regresiva del reloj con el proximo turno
        /// </summary>
        private void AsignarHoraRestante()
        {
            if (this.lblHoraRestante.InvokeRequired)
            {
                Action delegadoAsignarHora = AsignarHoraRestante;
                this.lblHoraRestante.Invoke(delegadoAsignarHora);
            }
            else
            {
                string horaRestante;
                if (this.proximoTurno is null)
                {
                    horaRestante = "No hay ningún turno próximo";
                    BuscarProximoTurno();
                }
                else
                {
                    double segundosRestantes = this.proximoTurno.Fecha.Subtract(DateTime.Now).TotalSeconds;
                    if (segundosRestantes > 0)
                    {
                        horaRestante = this.proximoTurno.Fecha.Subtract(DateTime.Now).ToString("d' Días 'h' Horas 'm' Minutos 's' Segundos'");
                        if (string.IsNullOrWhiteSpace(this.rtbProximoTurno.Text))
                        {
                            this.rtbProximoTurno.Text = this.proximoTurno.ToString();
                        }
                    }
                    else
                    {
                        horaRestante = string.Empty;
                        this.rtbProximoTurno.Text = string.Empty;
                        BuscarProximoTurno();
                    }
                }
                this.lblHoraRestante.Text = horaRestante;
            }
        }

        /// <summary>
        /// Reinicia el temporizador con la cuenta reegresiva del proximo turno
        /// </summary>
        private void ReiniciarHoraRestante()
        {
            if (this.lblHoraRestante.InvokeRequired)
            {
                Action delegadoReiniciarHora = ReiniciarHoraRestante;
                this.lblHoraRestante.Invoke(delegadoReiniciarHora);
            }
            else
            {
                this.rtbProximoTurno.Text = String.Empty;
                BuscarProximoTurno();
            }
        }

        /// <summary>
        /// Busca el turno mas proximo a la fecha actual
        /// 
        /// CLASE 10 - Excepciones
        /// 
        /// </summary>
        private void BuscarProximoTurno()
        {
            try
            {
                this.proximoTurno = this.turnoDAO.ProximoTurno();
            }
            catch (NoHayMasTurnosException)
            {
                this.proximoTurno = null;
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        /// <summary>
        /// Busca todos los clientes del sistema
        /// </summary>
        private void BuscarClientes()
        {
            List<Cliente> clientes = this.clienteDAO.Leer();
            this.lstClientes.DataSource = clientes;
            this.lstClientes.SelectedItem = null;
            this.lstClientes.Update();
            this.lstClientes.Refresh();
            HabilitarControlesCliente(false);
        }

        /// <summary>
        /// Habilita los controles de ABM de clientes
        /// </summary>
        /// <param name="habilitar">True si habilita los controles, false si los deshabilita</param>
        private void HabilitarControlesCliente(bool habilitar)
        {
            this.btnEditarCliente.Enabled = habilitar;
            this.btnEliminarCliente.Enabled = habilitar;
            this.btnVerCliente.Enabled = habilitar;
        }

        /// <summary>
        /// Habilita los controles de ABM de mascotas
        /// </summary>
        /// <param name="habilitar">True si habilita los controles, false si los deshabilita</param>
        private void HabilitarControlesMascota(bool habilitar)
        {
            this.btnEditarMascota.Enabled = habilitar;
            this.btnEliminarMascota.Enabled = habilitar;
            this.btnVerMascota.Enabled = habilitar;
            this.btnCargarTurno.Enabled = habilitar;
            this.btnRegistrarVisita.Enabled = habilitar;
        }

        /// <summary>
        /// Busca todas las mascotas de un cliente
        /// </summary>
        /// <param name="cliente">Cliente a buscar</param>
        private void BuscarMascotas(Cliente cliente)
        {
            List<Mascota> mascotas = this.mascotaDAO.Leer(mascota => mascota.ClienteId == cliente.Id);
            this.lstMascotas.DataSource = mascotas;
            this.lstMascotas.SelectedItem = null;
            this.lstMascotas.Update();
            this.lstMascotas.Refresh();
            HabilitarControlesMascota(false);
        }

        /// <summary>
        /// Actualiza los datos de las mascotas del cliente seleccionado
        /// </summary>
        private void ActualizarMascotas()
        {
            try
            {
                Cliente cliente = ClienteSeleccionado();
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
        }

        /// <summary>
        /// Muestra el formulario de ABM de clientes
        /// </summary>
        /// <param name="eFrmABM">Tipo de ABM</param>
        private void DatosCliente(eFrmABM eFrmABM)
        {
            try
            {
                Form form = new FrmABMCliente(this.clienteDAO, eFrmABM, ClienteSeleccionado());
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        /// <summary>
        /// Obtiene el cliente seleccionado del listado en pantalla
        /// 
        /// CLASE 10 - Excepciones
        /// 
        /// </summary>
        /// <returns>Objeto cliente</returns>
        /// <exception cref="ElementoNoSeleccionadoException">Lanzada cuando se llama sin tener un cliente seleccionado</exception>
        private Cliente ClienteSeleccionado()
        {
            Cliente cliente = this.lstClientes.SelectedItem as Cliente;
            if (cliente is null)
            {
                throw new ElementoNoSeleccionadoException("Debe seleccionar un cliente");
            }
            return cliente;
        }

        /// <summary>
        /// Muestra el formulario de ABM de mascotas
        /// </summary>
        /// <param name="eFrmABM">Tipo de ABM</param>
        private void DatosMascota(eFrmABM eFrmABM)
        {
            try
            {
                Form form = new FrmABMMascota(this.mascotaDAO, eFrmABM, MascotaSeleccionada());
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        /// <summary>
        /// Obtiene la mascota seleccionada del listado en pantalla
        /// 
        /// CLASE 10 - Excepciones
        /// 
        /// </summary>
        /// <returns>Objeto mascota</returns>
        /// <exception cref="ElementoNoSeleccionadoException">Lanzada cuando se llama sin tener una mascota seleccionada</exception>
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

        /// <summary>
        /// Coloca el texto a un boton segun la entidad activable
        /// 
        /// CLASE 13 - Interfaces
        /// 
        /// </summary>
        /// <param name="button">Boton sobre el cual se va a cambiar el texto</param>
        /// <param name="activable">Entidad activable</param>
        private void ColocarTextoBotonEliminacion(Button button, IActivable activable)
        {
            button.Text = activable.Activo ? "Dar de baja" : "Reactivar";
        }

        /// <summary>
        /// Habilita un boton segun la entidad activable
        /// 
        /// CLASE 13 - Interfaces
        /// 
        /// </summary>
        /// <param name="button">Boton que se va a activar o desactivar</param>
        /// <param name="activable">Entidad activable</param>
        private void HabilitarBoton(Button button, IActivable activable)
        {
            button.Enabled = activable.Activo;
        }

        /// <summary>
        /// Reinicia el temporizador de cuenta regresiva
        /// </summary>
        private void ReiniciarTemporizador()
        {
            this.temporizadorRestante.Reiniciar();
        }

        #endregion

    }
}
