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
    public partial class FrmABMCliente : Form
    {
        private ClienteDAO clienteDAO;
        private eFrmABM eFrmABM;
        private Cliente cliente;
        private bool operacionFinalizada;

        public FrmABMCliente(ClienteDAO clienteDAO)
            : this(clienteDAO, eFrmABM.Crear, null)
        {
        }

        public FrmABMCliente(ClienteDAO clienteDAO, eFrmABM eFrmABM, Cliente cliente)
        {
            InitializeComponent();

            this.clienteDAO = clienteDAO;
            this.eFrmABM = eFrmABM;
            this.cliente = cliente;
            this.operacionFinalizada = false;
        }

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
                exception is ArgumentException ||
                exception is ValidacionException)
            {
                MessageBox.Show(exception.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (exception is NotImplementedException)
            {
                MessageBox.Show("Hay partes sin implementar de la aplicación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show($"Error inesperado. {exception.Message} - {exception.StackTrace}");
            }
        }

        /// <summary>
        /// Indica si se realizaron cambios en los campos
        /// </summary>
        /// <returns>True si hay cambios, false caso contrario</returns>
        private bool SeRealizaronCambios()
        {
            return (this.eFrmABM == eFrmABM.Crear && (!string.IsNullOrWhiteSpace(this.txtNombre.Text) ||
                                                      !string.IsNullOrWhiteSpace(this.txtApellido.Text) ||
                                                      !string.IsNullOrWhiteSpace(this.txtDireccion.Text) ||
                                                      this.txtDni.Value > 0)) ||
                   (this.eFrmABM == eFrmABM.Editar && !this.operacionFinalizada && 
                                                     (this.txtNombre.Text.Trim() != this.cliente.Nombre.Trim() ||
                                                       this.txtApellido.Text.Trim() != this.cliente.Apellido.Trim() ||
                                                       this.txtDireccion.Text.Trim() != this.cliente.Direccion.Trim() ||
                                                       this.txtDni.Value != this.cliente.Dni ||
                                                       this.dtFechaNacimiento.Value != this.cliente.FechaNacimiento));

        }

        /// <summary>
        /// Valida si se completaron todos los campos obligatorios en el formulario
        /// 
        /// CLASE 10 - Excepciones
        /// 
        /// </summary>
        /// <exception cref="ValidacionException">Lanzada cuando no se completaron todos los campos obligatorios</exception>
        private void SeCompletaronTodosLosCampos()
        {
            if (string.IsNullOrWhiteSpace(this.txtNombre.Text) ||
                string.IsNullOrWhiteSpace(this.txtApellido.Text) ||
                string.IsNullOrWhiteSpace(this.txtDireccion.Text) ||
                this.txtDni.Value == 0)
            {
                throw new ValidacionException("Debe indicar todos los datos");
            }
        }

        /// <summary>
        /// Valida si el dni de la persona es unico
        /// 
        /// CLASE 10 - Excepciones
        /// 
        /// </summary>
        /// <exception cref="ValidacionException">Lanzada cuando ya existe una persona cargada con el mismo deni</exception>
        private void EsDniUnico()
        {
            try
            {
                if (this.clienteDAO.Existe((long)this.txtDni.Value))
                {
                    throw new ValidacionException("Debe indicar un DNI diferente ya que hay otro cliente con el mismo.");
                }
            }
            catch (EntidadInexistenteException)
            {

            }
        }

        /// <summary>
        /// Establece las configuraciones iniciales de los controles
        /// </summary>
        private void ConfigurarControles()
        {
            bool editarDatos = this.eFrmABM != eFrmABM.Ver;
            this.txtApellido.Enabled = editarDatos;
            this.txtNombre.Enabled = editarDatos;
            this.txtDni.Enabled = editarDatos;
            this.txtDireccion.Enabled = editarDatos;
            this.dtFechaNacimiento.Enabled = editarDatos;
            this.chkActivo.Enabled = editarDatos;
            if (this.eFrmABM == eFrmABM.Crear)
            {
                this.Text = "Cargar nuevo cliente";
                this.btnAceptar.Text = "Registrar";
            }
            else if (this.eFrmABM == eFrmABM.Editar)
            {
                this.Text = "Modificar datos de cliente";
                this.btnAceptar.Text = "Modificar";
            }
            else
            {
                this.Text = "Datos de cliente";
                this.btnAceptar.Visible = false;
                this.btnCancelar.Text = "Aceptar";
            }
        }

        /// <summary>
        /// Coloca los datos de un cliente se se brinda el mismo
        /// </summary>
        private void ColocarDatos()
        {
            if (this.cliente is not null)
            {
                this.txtApellido.Text = cliente.Apellido;
                this.txtNombre.Text = cliente.Nombre;
                this.txtDni.Value = cliente.Dni;
                this.txtDireccion.Text = cliente.Direccion;
                this.dtFechaNacimiento.Value = cliente.FechaNacimiento;
                this.chkActivo.Checked = cliente.Activo;
            }

        }

        #endregion

        #region Eventos

        #region Form

        private void FrmABMCliente_Load(object sender, EventArgs e)
        {
            this.dtFechaNacimiento.MaxDate = DateTime.Now.AddYears(-18);
            ColocarDatos();
            ConfigurarControles();
        }

        private void FrmABMCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.eFrmABM != eFrmABM.Ver &&
                !this.operacionFinalizada &&
                SeRealizaronCambios() && 
                MessageBox.Show("Se perderan los cambios realizados ¿Desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Botones

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.eFrmABM != eFrmABM.Ver)
                {
                    SeCompletaronTodosLosCampos();
                    EsDniUnico();
                    Cliente cliente = new Cliente(this.cliente.Id, (long)this.txtDni.Value, this.txtNombre.Text, this.txtApellido.Text, this.dtFechaNacimiento.Value, this.txtDireccion.Text, this.chkActivo.Checked);
                    if (this.eFrmABM == eFrmABM.Crear)
                    {
                        this.clienteDAO.Guardar(cliente);
                    }
                    else if (this.eFrmABM == eFrmABM.Editar)
                    {
                        this.clienteDAO.Modificar(cliente);
                    }
                    this.DialogResult = DialogResult.OK;
                    this.operacionFinalizada = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        #endregion

        #endregion
    }
}
