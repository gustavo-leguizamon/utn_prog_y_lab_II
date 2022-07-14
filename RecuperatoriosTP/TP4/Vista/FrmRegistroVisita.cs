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
using Utilidades.Extensions;
using Vista.Exceptions;

namespace Vista
{
    public partial class FrmRegistroVisita : Form
    {
        private Mascota mascota;
        private VisitaDAO visitaDAO;
        private bool operacionFinalizada;

        public FrmRegistroVisita(Mascota mascota)
        {
            InitializeComponent();

            this.mascota = mascota;
            this.visitaDAO = new VisitaDAO();
            this.operacionFinalizada = false;
        }


        #region Metodos

        private void ManejarExcepcion(Exception exception)
        {
            if (exception is ArgumentException ||
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

        private bool SeRealizaronCambios()
        {
            return this.txtPesoActual.Value > 0 ||
                   !string.IsNullOrWhiteSpace(this.rtbObservaciones.Text);
        }


        private void SeCompletaronTodosLosCampos()
        {
            if (this.txtPesoActual.Value == 0 ||
                string.IsNullOrWhiteSpace(this.rtbObservaciones.Text))
            {
                throw new ValidacionException("Debe indicar todos los datos");
            }
        }

        private void ValidarHorarios()
        {
            if (new Tiempo(this.dtHoraLLegada.Value.GetHora()) >= new Tiempo(this.dtHoraSalida.Value.GetHora()))
            {
                throw new ValidacionException("El horario de llegada debe ser menor al de salida");
            }
        }

        #endregion

        #region Eventos

        #region Form

        private void FrmRegistroVisita_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.operacionFinalizada &&
                SeRealizaronCambios() && 
                MessageBox.Show("Se perderan los cambios realizados ¿Desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void FrmRegistroVisita_Load(object sender, EventArgs e)
        {
            this.dtFechaVisita.MaxDate = DateTime.Now;
            this.dtFechaVisita.MinDate = DateTime.Now.AddMonths(-6);
        }

        #endregion

        #region Botones

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                SeCompletaronTodosLosCampos();
                ValidarHorarios();
                Tiempo llegada = new Tiempo(this.dtHoraLLegada.Value.GetHora());
                Tiempo salida = new Tiempo(this.dtHoraSalida.Value.GetHora());
                llegada.Segundo = 0;
                salida.Segundo = 0;
                Visita visita = new Visita(this.mascota.Id, this.dtFechaVisita.Value, llegada, salida, (float)this.txtPesoActual.Value, this.rtbObservaciones.Text);
                this.visitaDAO.Guardar(visita);
                this.DialogResult = DialogResult.OK;
                this.operacionFinalizada = true;
                this.Close();
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

    }
}
