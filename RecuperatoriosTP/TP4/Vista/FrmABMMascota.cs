using Datos;
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
    public partial class FrmABMMascota : Form
    {
        private eFrmABM eFrmABM;
        private Mascota mascota;
        private MascotaDAO mascotaDAO;

        private BusquedaMascota busquedaMascota;

        private bool operacionFinalizada;

        public FrmABMMascota(MascotaDAO mascotaDAO, Cliente cliente)
            : this(mascotaDAO, eFrmABM.Crear, new Mascota(cliente))
        {
        }

        public FrmABMMascota(MascotaDAO mascotaDAO, eFrmABM eFrmABM, Mascota mascota)
        {
            InitializeComponent();

            this.mascotaDAO = mascotaDAO;

            this.busquedaMascota = new BusquedaMascota();

            this.eFrmABM = eFrmABM;
            this.mascota = mascota;
            this.operacionFinalizada = false;
        }














        #region Metodos

        /// <summary>
        /// Maneja las excepciones ocurridas en el formulario
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
                                                      this.txtPeso.Value > 0)) ||
                   (this.eFrmABM == eFrmABM.Editar && !this.operacionFinalizada && 
                                                      (this.txtNombre.Text.Trim() != this.mascota.Nombre.Trim() ||
                                                       (float)this.txtPeso.Value != this.mascota.Peso ||
                                                       this.dtFechaNacimiento.Value != this.mascota.FechaNacimiento ||
                                                       this.chkActivo.Checked != this.mascota.Activo));
        }


        /// <summary>
        /// Valida si se completaron todos los campos obligatorios en el formulario
        /// </summary>
        /// <exception cref="ValidacionException">Lanzada cuando no se completaron todos los campos obligatorios</exception>
        private void SeCompletaronTodosLosCampos()
        {
            if (string.IsNullOrWhiteSpace(this.txtNombre.Text) ||
                this.txtPeso.Value == 0)
            {
                throw new ValidacionException("Debe indicar todos los datos");
            }
        }

        /// <summary>
        /// Valida si una mascota es unica para el cliente
        /// </summary>
        /// <exception cref="ValidacionException">Lanzada cuando la mascota ya fue cargada para el cliente</exception>
        private void ValidaMascotaUnica()
        {
            if (this.busquedaMascota.Existe(ConstruirMascota()))
            {
                throw new ValidacionException("Debe indicar una mascota diferente ya que el cliente ya la registró.");
            }
            
        }

        /// <summary>
        /// Contruye el objeto Mascota a partir de los datos del formulatio
        /// </summary>
        /// <returns>Objeto mascota</returns>
        private Mascota ConstruirMascota()
        {
            return new Mascota(this.mascota.Id, this.mascota.Cliente.Id, (TipoMascota.eTipoMascota)this.cmbTipoMascota.SelectedItem, this.txtNombre.Text, (float)this.txtPeso.Value, this.dtFechaNacimiento.Value, this.chkActivo.Checked);
        }


        /// <summary>
        /// Establece las configuraciones iniciales de los controles
        /// </summary>
        private void ConfigurarControles()
        {
            bool editarDatos = this.eFrmABM != eFrmABM.Ver;
            this.txtNombre.Enabled = editarDatos;
            this.txtPeso.Enabled = editarDatos;
            this.dtFechaNacimiento.Enabled = editarDatos;
            this.chkActivo.Enabled = editarDatos;
            this.cmbTipoMascota.Enabled = editarDatos;
            if (this.eFrmABM == eFrmABM.Crear)
            {
                this.Text = "Agregar nueva mascota";
                this.btnAceptar.Text = "Agregar";
            }
            else if (this.eFrmABM == eFrmABM.Editar)
            {
                this.Text = "Modificar datos de mascota";
                this.btnAceptar.Text = "Modificar";
            }
            else
            {
                this.Text = "Datos de mascota";
                this.btnAceptar.Visible = false;
                this.btnCancelar.Text = "Aceptar";
            }

            this.cmbTipoMascota.DataSource = Enum.GetValues<TipoMascota.eTipoMascota>();
        }

        /// <summary>
        /// Coloca los datos de una mascota si se brinda la misma
        /// </summary>
        private void ColocarDatos()
        {
            if (this.mascota is not null)
            {
                this.txtDni.Text = this.mascota.Cliente.Dni.ToString();
                this.txtNombreCliente.Text = this.mascota.Cliente.NombreCompleto;
                if (this.mascota.Id > 0)
                {
                    this.txtNombre.Text = mascota.Nombre;
                    this.txtPeso.Value = (decimal)mascota.Peso;
                    this.dtFechaNacimiento.Value = mascota.FechaNacimiento;
                    this.chkActivo.Checked = mascota.Activo;
                }
            }
        }

        #endregion

        #region Eventos

        #region Form

        private void FrmCargaMascota_Load(object sender, EventArgs e)
        {
            this.dtFechaNacimiento.MaxDate = DateTime.Now;
            this.dtFechaNacimiento.Value = DateTime.Today;
            ColocarDatos();
            ConfigurarControles();
        }

        private void FrmCargaMascota_FormClosing(object sender, FormClosingEventArgs e)
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
                    ValidaMascotaUnica();
                    Mascota mascota = ConstruirMascota();
                    if (this.eFrmABM == eFrmABM.Crear)
                    {
                        this.mascotaDAO.Guardar(mascota);
                    }
                    else if (this.eFrmABM == eFrmABM.Editar)
                    {
                        this.mascotaDAO.Modificar(mascota);
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
