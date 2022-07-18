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
    public partial class FrmABMTurno : Form
    {
        private eFrmABM eFrmABM;
        private Turno turno;
        private TurnoDAO turnoDAO;
        private bool operacionFinalizada;

        private BuscadorDeHorarios buscadorDeTurnos;
        private List<Tiempo> horariosDisponibles;
        private List<Tiempo> horariosOcupados;

        public FrmABMTurno(TurnoDAO turnoDAO, Mascota mascota)
           : this(turnoDAO, eFrmABM.Crear, new Turno(mascota))
        {
        }

        public FrmABMTurno(TurnoDAO turnoDAO, eFrmABM eFrmABM, Turno turno)
        {
            InitializeComponent();

            this.turnoDAO = turnoDAO;
            this.eFrmABM = eFrmABM;
            this.turno = turno;
            this.operacionFinalizada = false;

            this.buscadorDeTurnos = new BuscadorDeHorarios();
            this.buscadorDeTurnos.OnBusquedaFinalizada += ColocarHorariosDisponibles; //CLASE 19 - Eventos
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
            else if (exception is NoHayMasTurnosException)
            {

            }
            else
            {
                MessageBox.Show($"Error inesperado. {exception.Message} - {exception.StackTrace}");
            }
        }


        /// <summary>
        /// Coloca los datos de un turno si se brinda el mismo
        /// </summary>
        private void ColocarDatos()
        {
            if (this.turno is not null)
            {
                this.txtIdMascota.Text = this.turno.MascotaId.ToString();
                this.txtNombreMascota.Text = this.turno.Mascota.Nombre;
                this.txtPeso.Value = (decimal)this.turno.Mascota.Peso;
                this.txtFechaNacimiento.Text = this.turno.Mascota.FechaNacimiento.ToString("dd/MM/yyyy");
                this.txtTipoMascota.Text = Enum.GetName(this.turno.Mascota.TipoMascota);
                if (turno.Id > 0)
                {
                    this.txtComentario.Text = this.turno.Comentario;
                    this.btnAceptar.Enabled = true;
                }
            }
        }


        /// <summary>
        /// Establece las configuraciones iniciales de los controles
        /// </summary>
        private void ConfigurarControles()
        {
            if (this.eFrmABM == eFrmABM.Crear)
            {
                this.Text = "Agregar nuevo turno";
                this.btnAceptar.Text = "Agregar";
            }
            else if (this.eFrmABM == eFrmABM.Editar)
            {
                this.Text = "Modificar datos del turno";
                this.btnAceptar.Text = "Modificar";
            }
            else
            {
                this.Text = "Ver datos del turno";
                this.btnAceptar.Visible = false;
                this.btnCancelar.Text = "Aceptar";
            }
        }


        /// <summary>
        /// Indica si se realizaron cambios en los campos
        /// </summary>
        /// <returns>True si hay cambios, false caso contrario</returns>
        private bool SeRealizaronCambios()
        {
            return (this.eFrmABM == eFrmABM.Crear && (!string.IsNullOrWhiteSpace(this.txtComentario.Text) ||
                                                      this.cmbHoraDesde.SelectedItem is not null ||
                                                      this.cmbHoraHasta.SelectedItem is not null)) ||
                   (this.eFrmABM == eFrmABM.Editar && !this.operacionFinalizada && 
                                                      (this.txtComentario.Text.Trim() != this.turno.Comentario.Trim() ||
                                                       (this.cmbHoraDesde.SelectedItem is not null && ((Tiempo)this.cmbHoraDesde.SelectedItem) != new Tiempo(this.turno.HoraInicio)) ||
                                                       (this.cmbHoraHasta.SelectedItem is not null && ((Tiempo)this.cmbHoraHasta.SelectedItem) != new Tiempo(this.turno.HoraFin))));
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
            if (string.IsNullOrWhiteSpace(this.txtComentario.Text) ||
                this.cmbHoraDesde.SelectedItem is null ||
                this.cmbHoraHasta.SelectedItem is null)
            {
                throw new ValidacionException("Debe indicar todos los datos");
            }
        }

        /// <summary>
        /// Coloca el listado de horarios disponibles y no disponibles para solicitar turnos
        /// </summary>
        /// <param name="horarios">Horarios disponibles</param>
        /// <param name="horariosNoDisponibles">Horarios no disponibles</param>
        private void ColocarHorariosDisponibles(List<Tiempo> horarios, List<Tiempo> horariosNoDisponibles)
        {
            if (this.cmbHoraDesde.InvokeRequired)
            {
                BuscadorDeHorarios.DelegadoBusquedaFinalizadaHandler delegadoBusquedaFinaliza = ColocarHorariosDisponibles;
                this.cmbHoraDesde.Invoke(delegadoBusquedaFinaliza, new object[] { horarios, horariosNoDisponibles });
            }
            else
            {
                this.horariosDisponibles = horarios;
                this.horariosOcupados = horariosNoDisponibles;
                this.cmbHoraDesde.Items.Clear();
                this.cmbHoraDesde.Items.AddRange(this.horariosDisponibles.Take(this.horariosDisponibles.Count - 1).ToArray());
                this.cmbHoraDesde.Enabled = true;
            }
        }

        #endregion

        #region Eventos

        #region Form

        private void FrmABMTurno_Load(object sender, EventArgs e)
        {
            dtFechaTurno.MaxDate = DateTime.Today.AddMonths(6);
            dtFechaTurno.MinDate = DateTime.Today;
            dtFechaTurno.Value = DateTime.Today;
            this.buscadorDeTurnos.BuscarHorarios(DateTime.Today);
            ColocarDatos();
            ConfigurarControles();
        }

        private void FrmABMTurno_FormClosing(object sender, FormClosingEventArgs e)
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
                SeCompletaronTodosLosCampos();
                Turno turno = new Turno(this.turno.Id, (short)EstadoTurno.eEstadoTurno.Vigente, Convert.ToInt64(txtIdMascota.Text), dtFechaTurno.Value, this.cmbHoraDesde.Text, this.cmbHoraHasta.Text, txtComentario.Text);
                if (this.eFrmABM == eFrmABM.Crear)
                {
                    this.turnoDAO.Guardar(turno);
                }
                else if (this.eFrmABM == eFrmABM.Editar)
                {
                    this.turnoDAO.Modificar(turno);
                }
                this.DialogResult = DialogResult.OK;
                this.operacionFinalizada = true;
                this.Close();
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }



        #endregion

        #region ComboBox
            
        private void cmbHoraDesde_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.cmbHoraHasta.Items.Clear();
                this.cmbHoraHasta.Enabled = false;

                IEnumerable<Tiempo> noDisponiblesSuperiorAlSeleccionado = this.horariosOcupados.Where(h => (Tiempo)this.cmbHoraDesde.SelectedItem < h);
                Tiempo proximoNoDisponible = noDisponiblesSuperiorAlSeleccionado?.OrderBy(h => h).FirstOrDefault();
                foreach (Tiempo horario in this.horariosDisponibles)
                {
                    if (horario > (Tiempo)this.cmbHoraDesde.SelectedItem)
                    {
                        if (proximoNoDisponible is not null && horario > proximoNoDisponible)
                        {
                            this.cmbHoraHasta.Items.Add(proximoNoDisponible);
                            break;
                        }
                        else
                        {
                            this.cmbHoraHasta.Items.Add(horario);
                        }
                    }
                }

                if (this.cmbHoraHasta.Items.Count > 0)
                {
                    this.cmbHoraHasta.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        #endregion

        #region DatetimePicker

        private void dtFechaTurno_ValueChanged(object sender, EventArgs e)
        {
            if (this.buscadorDeTurnos is not null)
            {
                this.buscadorDeTurnos.CancelarBusqueda();
            }

            this.buscadorDeTurnos.BuscarHorarios(dtFechaTurno.Value);
            this.cmbHoraDesde.Enabled = false;
            this.cmbHoraDesde.Items.Clear();
            this.cmbHoraHasta.Enabled = false;
            this.cmbHoraHasta.Items.Clear();
        }

        #endregion

        #endregion

    }
}
