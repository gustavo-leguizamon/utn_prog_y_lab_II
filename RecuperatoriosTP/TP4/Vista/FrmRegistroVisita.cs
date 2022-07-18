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
        private AtencionDAO visitaDAO;
        private bool operacionFinalizada;

        public FrmRegistroVisita(Mascota mascota)
        {
            InitializeComponent();

            this.mascota = mascota;
            this.visitaDAO = new AtencionDAO();
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

        /// <summary>
        /// Indica si se realizaron cambios en los campos
        /// </summary>
        /// <returns>True si hay cambios, false caso contrario</returns>
        private bool SeRealizaronCambios()
        {
            return this.txtPesoActual.Value > 0 ||
                   !string.IsNullOrWhiteSpace(this.rtbObservaciones.Text);
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
            if (this.txtPesoActual.Value == 0 ||
                string.IsNullOrWhiteSpace(this.rtbObservaciones.Text))
            {
                throw new ValidacionException("Debe indicar todos los datos");
            }
        }

        /// <summary>
        /// Valida que los horarios sean correctos
        /// 
        /// CLASE 10 - Excepciones
        /// CLASE 20 - Metodos de extension
        /// 
        /// </summary>
        /// <exception cref="ValidacionException">Lanzada cuando el horario de llegada es mayor o igual al de salida</exception>
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                SeCompletaronTodosLosCampos();
                ValidarHorarios();
                Tiempo llegada = new Tiempo(this.dtHoraLLegada.Value.GetHora()); //CLASE 20 - Metodos de extension
                Tiempo salida = new Tiempo(this.dtHoraSalida.Value.GetHora()); //CLASE 20 - Metodos de extension
                llegada.Segundo = 0;
                salida.Segundo = 0;
                Atencion visita = new Atencion(this.mascota.Id, this.dtFechaVisita.Value, llegada, salida, (float)this.txtPesoActual.Value, this.rtbObservaciones.Text);
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

        #endregion

        #endregion


    }
}
