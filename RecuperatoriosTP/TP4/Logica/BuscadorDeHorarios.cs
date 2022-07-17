using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utilidades;

namespace Logica
{
    /// <summary>
    /// Permite buscar horarios de turnos en hilo separado
    /// </summary>
    public class BuscadorDeHorarios
    {
        private static TurnoDAO turnoDAO;

        /// <summary>
        /// Delegado para recibir los horarios de un dia
        /// </summary>
        /// <param name="horariosDisponibles">Listado de horarios disponibles</param>
        /// <param name="horariosNoDisponibles">Listado de horarios no disponibles</param>
        public delegate void DelegadoBusquedaFinalizadaHandler(List<Tiempo> horariosDisponibles, List<Tiempo> horariosNoDisponibles);

        /// <summary>
        /// Evento encargado de notificar cuando la busqueda finalice
        /// </summary>
        public event DelegadoBusquedaFinalizadaHandler OnBusquedaFinalizada;

        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;
        private Task hilo;
        private DateTime fecha;

        public DateTime Fecha 
        { 
            get { return fecha; }
        }

        static BuscadorDeHorarios()
        {
            BuscadorDeHorarios.turnoDAO = new TurnoDAO();
        }

        public BuscadorDeHorarios()
        {
        }

        /// <summary>
        /// Inicia la busqueda de horarios
        /// </summary>
        /// <param name="fecha">Fecha a buscar horarios</param>
        public void BuscarHorarios(DateTime fecha)
        {
            this.fecha = fecha;
            if (hilo is null || hilo.IsCompleted)
            {
                this.cancellationTokenSource = new CancellationTokenSource();
                this.cancellationToken = this.cancellationTokenSource.Token;
                hilo = Task.Run(BuscarListadoDisponibles, this.cancellationToken);
            }
        }

        /// <summary>
        /// Cancela la busqueda de horarios
        /// </summary>
        public void CancelarBusqueda()
        {
            if (hilo is not null && !this.hilo.IsCompleted)
            {
                this.cancellationTokenSource.Cancel();
            }
        }

        /// <summary>
        /// Busca los horarios y notifica cuando finaliza
        /// </summary>
        private void BuscarListadoDisponibles()
        {
            List<Tiempo> horariosNoDisponibles;
            List<Tiempo> horarios = BuscadorDeHorarios.turnoDAO.ObtenerHorariosDisponibles(this.fecha, out horariosNoDisponibles);
            if (OnBusquedaFinalizada is not null)
            {
                OnBusquedaFinalizada.Invoke(horarios, horariosNoDisponibles);
            }
        }
    }
}
