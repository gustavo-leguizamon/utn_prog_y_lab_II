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
    public partial class FrmRegistroAtenciones : Form
    {
        private AtencionDAO visitaDAO;
        private EstadoTurnoDAO estadoTurnoDAO;

        public FrmRegistroAtenciones()
        {
            InitializeComponent();

            this.visitaDAO = new AtencionDAO();
            this.estadoTurnoDAO = new EstadoTurnoDAO();
        }

        #region Metodos

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


        private void BuscarAtenciones(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<InformacionDeAtencion> listadoAtenciones = this.visitaDAO.ObtenerRegistroDeAtenciones(fechaDesde, fechaHasta);
            this.dtgAtenciones.DataSource = listadoAtenciones;
            this.dtgAtenciones.Update();
            this.dtgAtenciones.Refresh();
        }

        private void ValidarFechas()
        {
            if (this.dtFechaDesde.Value > this.dtFechaHasta.Value)
            {
                throw new ValidacionException("Fecha desde debe ser menor o igual a la fecha hasta");
            }
        }

        #endregion

        #region Eventos

        #region Form

        private void FrmListadoDeTurnos_Load(object sender, EventArgs e)
        {
            try
            {
                BuscarAtenciones(DateTime.Today, DateTime.Today);
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
