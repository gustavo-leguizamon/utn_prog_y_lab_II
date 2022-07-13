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
    public class BuscadorDeTurnos
    {
        private static TurnoDAO turnoDAO;

        public delegate void DelegadoBusquedaFinalizadaHandler(List<Tiempo> horariosDisponibles, List<Tiempo> horariosNoDisponibles);

        public event DelegadoBusquedaFinalizadaHandler OnBusquedaFinalizada;

        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;
        private Task hilo;
        private DateTime fecha;
        //private DelegadoBusquedaFinalizadaHandler busquedaFinalizada;

        public DateTime Fecha 
        { 
            get { return fecha; }
        }

        static BuscadorDeTurnos()
        {
            BuscadorDeTurnos.turnoDAO = new TurnoDAO();
        }

        //public BuscadorDeTurnos(DateTime fecha, DelegadoBusquedaFinalizadaHandler delegadoBusquedaFinalizada)
        public BuscadorDeTurnos()
        {
            //this.fecha = fecha;
            //this.busquedaFinalizada = delegadoBusquedaFinalizada;
        }

        public void BuscarHorarios(DateTime fecha)
        {
            this.fecha = fecha;
            if (hilo is null || hilo.IsCompleted)
            {
                this.cancellationTokenSource = new CancellationTokenSource();
                this.cancellationToken = this.cancellationTokenSource.Token;
                hilo = Task.Run(BuscarListadoDisponibles, this.cancellationToken);
            }
            //return Task.Run(BuscarListadoDisponibles);
        }

        public void CancelarBusqueda()
        {
            if (hilo is not null && !this.hilo.IsCompleted)
            {
                this.cancellationTokenSource.Cancel();
            }
        }

        private void BuscarListadoDisponibles()
        {
            //System.Threading.Thread.Sleep(10000);
            List<Tiempo> horariosNoDisponibles;
            List<Tiempo> horarios = BuscadorDeTurnos.turnoDAO.ObtenerHorariosDisponibles(this.fecha, out horariosNoDisponibles);
            if (OnBusquedaFinalizada is not null)
            {
                OnBusquedaFinalizada.Invoke(horarios, horariosNoDisponibles);
            }
            //this.busquedaFinalizada.Invoke(horarios);
        }
    }
}
