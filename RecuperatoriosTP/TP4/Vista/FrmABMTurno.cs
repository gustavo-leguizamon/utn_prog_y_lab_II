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
        //private MascotaDAO mascotaDAO;
        private eFrmABM eFrmABM;
        private Turno turno;
        private TurnoDAO turnoDAO;
        private bool edicionFinalizada;

        private BuscadorDeTurnos buscadorDeTurnos;

        public FrmABMTurno(TurnoDAO turnoDAO, Mascota mascota)
           : this(turnoDAO, eFrmABM.Crear, new Turno(mascota))
        {
        }

        public FrmABMTurno(TurnoDAO turnoDAO, eFrmABM eFrmABM, Turno turno)
        {
            InitializeComponent();

            this.turnoDAO = turnoDAO;
            //this.clienteDAO = new ClienteDAO();
            this.eFrmABM = eFrmABM;
            this.turno = turno;
            this.edicionFinalizada = false;

            this.buscadorDeTurnos = new BuscadorDeTurnos();
            this.buscadorDeTurnos.OnBusquedaFinalizada += ColocarHorariosDisponibles;
        }

        //public FrmABMTurno(TurnoDAO turnoDAO)
        //{
        //    InitializeComponent();

        //    this.mascotaDAO = new MascotaDAO();
        //    this.turnoDAO = turnoDAO;
        //}

        //private void EstablecerMascota()
        //{
        //    try
        //    {
        //        Mascota mascota = this.mascotaDAO.LeerPorId((long)txtIdMascota.Value);
        //        this.txtNombreMascota.Text = mascota.Nombre;
        //        txtPeso.Value = (decimal)mascota.Peso;
        //        dtFechaNacimiento.Value = mascota.FechaNacimiento;
        //        this.grpTurno.Enabled = true;
        //        this.btnAgregar.Enabled = true;
        //    }
        //    catch (EntidadInexistenteException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        this.grpMascota.Enabled = false;
        //        this.btnAgregar.Enabled = false;
        //        this.txtNombreMascota.Text = string.Empty;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.grpMascota.Enabled = false;
        //        this.btnAgregar.Enabled = false;
        //        this.txtNombreMascota.Text = string.Empty;
        //    }
        //}


        #region Metodos

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
            else
            {
                MessageBox.Show($"Error inesperado. {exception.Message} - {exception.StackTrace}");
            }
        }

        private void ColocarDatos()
        {
            if (this.turno is not null)
            {
                this.txtIdMascota.Text = this.turno.MascotaId.ToString();
                this.txtNombreMascota.Text = this.turno.Mascota.Nombre;
                this.txtPeso.Value = (decimal)this.turno.Mascota.Peso;
                this.txtFechaNacimiento.Text = this.turno.Mascota.FechaNacimiento.ToString("dd/MM/yyyy");
                if (turno.Id > 0)
                {
                    this.txtComentario.Text = this.turno.Comentario;
                    //this.grpTurno.Enabled = true;
                    this.btnAceptar.Enabled = true;
                }
            }
        }

        private void ManejarControles()
        {
            //bool editarDatos = this.eFrmABM != eFrmABM.Ver;
            //this.txtNombre.Enabled = editarDatos;
            //this.txtPeso.Enabled = editarDatos;
            ////this.txtDni.Enabled = editarDatos;
            //this.dtFechaNacimiento.Enabled = editarDatos;
            //this.chkActivo.Enabled = editarDatos;
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

        private bool SeRealizaronCambios()
        {
            return (this.eFrmABM == eFrmABM.Crear && (!string.IsNullOrWhiteSpace(this.txtComentario.Text))) ||
                   (this.eFrmABM == eFrmABM.Editar && !this.edicionFinalizada && (this.txtComentario.Text.Trim() != this.turno.Comentario.Trim()));
        }

        private bool SeCompletaronTodosLosCampos()
        {
            return !string.IsNullOrWhiteSpace(this.txtComentario.Text);
        }

        private void ReiniciarCampos()
        {
            this.txtComentario.Text = string.Empty;
        }

        //private void BuscarTurnosDisponibles(DateTime fecha)
        //{
        //    //this.buscadorDeTurnos = new BuscadorDeTurnos(fecha, ColocarHorariosDisponibles);
        //    //this.buscadorDeTurnos.BuscarHorarios();

        //    this.buscadorDeTurnos = new BuscadorDeTurnos(fecha);
        //    this.buscadorDeTurnos.OnBusquedaFinalizada += ColocarHorariosDisponibles;
        //    this.buscadorDeTurnos.BuscarHorarios();
        //}

        private void ColocarHorariosDisponibles(List<Tiempo> horarios)
        {
            if (this.cmbHoraDesde.InvokeRequired)
            {
                //BuscadorDeTurnos.DelegadoBusquedaFinalizada delegadoBusquedaFinaliza = new BuscadorDeTurnos.DelegadoBusquedaFinalizada(ColocarHorariosDisponibles);
                //this.cmbHoraDesde.Invoke(delegadoBusquedaFinaliza, new object[] { horarios });
                BuscadorDeTurnos.DelegadoBusquedaFinalizadaHandler delegadoBusquedaFinaliza = ColocarHorariosDisponibles;
                this.cmbHoraDesde.Invoke(delegadoBusquedaFinaliza, new object[] { horarios });
            }
            else
            {
                this.cmbHoraDesde.Items.Clear();
                this.cmbHoraDesde.Items.AddRange(horarios.ToArray());
                this.cmbHoraDesde.Enabled = true;
            }
        }

        #endregion

        #region Eventos

        #region Form

        private void FrmCargarTurno_Load(object sender, EventArgs e)
        {
            dtFechaTurno.MaxDate = DateTime.Today.AddMonths(6);
            dtFechaTurno.MinDate = DateTime.Today;
            dtFechaTurno.Value = DateTime.Today;
            //BuscarTurnosDisponibles(DateTime.Today);
            this.buscadorDeTurnos.BuscarHorarios(DateTime.Today);
            ColocarDatos();
            ManejarControles();
        }

        private void FrmCargarTurno_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.eFrmABM != eFrmABM.Ver && SeRealizaronCambios() && MessageBox.Show("Se perderan los cambios realizados ¿Desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
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
            if (SeCompletaronTodosLosCampos())
            {
                Turno turno = new Turno(this.turno.Id, (short)EstadoTurno.eEstadoTurno.Vigente, Convert.ToInt64(txtIdMascota.Text), dtFechaTurno.Value, this.cmbHoraDesde.Text, this.cmbHoraHasta.Text, txtComentario.Text);
                if (this.eFrmABM == eFrmABM.Crear)
                {
                    this.turnoDAO.Guardar(turno);
                }
                else if (this.eFrmABM == eFrmABM.Editar)
                {
                    this.turnoDAO.Modificar(turno);
                    this.edicionFinalizada = true;
                }
                this.DialogResult = DialogResult.OK;
                ReiniciarCampos();
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe indicar todos los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        #endregion

        #region ComboBox

        //private void cmbHoraDesde_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //List<string> horariosDisponibles = this.turnoDAO.ObtenerHorariosDisponibles(this.dtFechaTurno.Value);
        //        //this.cmbHoraDesde.DataSource = horariosDisponibles;
        //    }
        //    catch (Exception ex)
        //    {
        //        ManejarExcepcion(ex);
        //    }
        //}

        private void cmbHoraDesde_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.cmbHoraHasta.Items.Clear();

                List<string> horariosDisponibles = new List<string>();
                foreach (string hora in this.cmbHoraDesde.Items)
                {
                    //if (hora > this.cmbHoraDesde.SelectedValue.ToString())
                    //{

                    //}
                }

                //this.cmbHoraHasta.Items.AddRange();
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

            //BuscarTurnosDisponibles(dtFechaTurno.Value);
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
