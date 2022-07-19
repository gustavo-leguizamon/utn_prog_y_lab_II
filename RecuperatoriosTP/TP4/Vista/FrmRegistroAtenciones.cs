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
    public partial class FrmRegistroAtenciones : Form
    {
        private AtencionDAO visitaDAO;
        //private EstadoTurnoDAO estadoTurnoDAO;

        private BuscadorDeAtenciones buscadorDeAtenciones;

        public FrmRegistroAtenciones()
        {
            InitializeComponent();

            this.visitaDAO = new AtencionDAO();
            //this.estadoTurnoDAO = new EstadoTurnoDAO();

            this.buscadorDeAtenciones = new BuscadorDeAtenciones();
            this.buscadorDeAtenciones.OnBusquedaIniciada += IniciarProgressBar;
            this.buscadorDeAtenciones.OnBusquedaFinalizada += BusquedaAtencionesFinalizada;
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
        /// Busca el registro de las atenciones realizadas en un rango de fechas
        /// </summary>
        /// <param name="fechaDesde">Fecha inicial</param>
        /// <param name="fechaHasta">Fecha final</param>
        //private void BuscarAtenciones(DateTime fechaDesde, DateTime fechaHasta)
        //{
        //    List<InformacionDeAtencion> listadoAtenciones = this.visitaDAO.ObtenerRegistroDeAtenciones(fechaDesde, fechaHasta);
        //    this.dtgAtenciones.DataSource = listadoAtenciones;
        //    this.dtgAtenciones.Update();
        //    this.dtgAtenciones.Refresh();
        //}


        /// <summary>
        /// Busca el registro de las atenciones realizadas en un rango de fechas
        /// </summary>
        /// <param name="fechaDesde">Fecha inicial</param>
        /// <param name="fechaHasta">Fecha final</param>
        private void BuscarAtenciones(DateTime fechaDesde, DateTime fechaHasta)
        {
            if (this.buscadorDeAtenciones is not null)
            {
                this.buscadorDeAtenciones.CancelarBusqueda();
            }
            this.buscadorDeAtenciones.Buscar(fechaDesde, fechaHasta);
        }

        private void IniciarProgressBar()
        {
            this.pbrBusqueda.Value = 0;
            this.pbrBusqueda.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
        }

        private void DetenerProgressBar()
        {
            this.pbrBusqueda.Value = this.pbrBusqueda.Maximum;
            this.pbrBusqueda.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
        }

        private void BusquedaAtencionesFinalizada(List<InformacionDeAtencion> listadoAtenciones)
        {
            if (this.dtgAtenciones.InvokeRequired)
            {
                BuscadorDeAtenciones.DelegadoBusquedaAtencionesFinalizadaHandler delegadoBusquedaFinaliza = BusquedaAtencionesFinalizada;
                this.dtgAtenciones.Invoke(delegadoBusquedaFinaliza, new object[] { listadoAtenciones });
            }
            else
            {
                this.dtgAtenciones.DataSource = listadoAtenciones;
                this.dtgAtenciones.Update();
                this.dtgAtenciones.Refresh();

                DetenerProgressBar();

                if (listadoAtenciones.Count == 0)
                    MessageBox.Show("No hay registros en las fechas seleccionadas");
            }
        }

        /// <summary>
        /// Valida que el rango de fechas se correcto
        /// 
        /// CLASE 10 - Excepciones
        /// 
        /// </summary>
        /// <exception cref="ValidacionException">Lanzada cuando la fecha inicial sea mayor que la final</exception>
        private void ValidarFechas()
        {
            if (this.dtFechaDesde.Value.Date > this.dtFechaHasta.Value.Date)
            {
                throw new ValidacionException("Fecha desde debe ser menor o igual a la fecha hasta");
            }
        }

        /// <summary>
        /// Establece las configuraciones iniciales de los controles
        /// </summary>
        private void ConfigurarControles()
        {
            this.dtFechaDesde.MaxDate = DateTime.Today;
            this.dtFechaHasta.MaxDate = DateTime.Today;
        }

        #endregion

        #region Eventos

        #region Form

        private void FrmListadoDeTurnos_Load(object sender, EventArgs e)
        {
            try
            {
                //BuscarAtenciones(DateTime.Today, DateTime.Today);
                ConfigurarControles();
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        #endregion

        #region Button

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarFechas();
                BuscarAtenciones(this.dtFechaDesde.Value, this.dtFechaHasta.Value);
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
