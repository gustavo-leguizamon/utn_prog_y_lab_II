using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logica
{
    public class BuscadorDeAtenciones
    {
        private static AtencionDAO visitaDAO;

        /// <summary>
        /// Delegado para recibir las atenciones encontradas
        /// 
        /// CLASE 17 - Delegados y expresiones lambda
        /// 
        /// </summary>
        /// <param name="atenciones">Atenciones encontradas</param>
        public delegate void DelegadoBusquedaAtencionesFinalizadaHandler(List<InformacionDeAtencion> atenciones);

        /// <summary>
        /// Delegado para tratar el inicio de la busqueda
        /// 
        /// CLASE 17 - Delegados y expresiones lambda
        /// 
        /// </summary>
        public delegate void DelegadoBusquedaAtencionesIniciadaHandler();

        /// <summary>
        /// Evento encargado de notificar cuando la busqueda finalice
        /// 
        /// CLASE 19 - Eventos
        /// 
        /// </summary>
        public event DelegadoBusquedaAtencionesFinalizadaHandler OnBusquedaFinalizada;

        /// <summary>
        /// Evento encargado de notificar cuando la busqueda inicia
        /// 
        /// CLASE 19 - Eventos
        /// 
        /// </summary>
        public event DelegadoBusquedaAtencionesIniciadaHandler OnBusquedaIniciada;

        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;
        private Task hilo;
        DateTime fechaDesde;
        DateTime fechaHasta;

        static BuscadorDeAtenciones()
        {
            BuscadorDeAtenciones.visitaDAO = new AtencionDAO();
        }

        public BuscadorDeAtenciones()
        {
        }

        /// <summary>
        /// Inicia la busqueda de atenciones
        /// </summary>
        public void Buscar(DateTime fechaDesde, DateTime fechaHasta)
        {
            if (hilo is null || hilo.IsCompleted)
            {
                this.fechaDesde = fechaDesde;
                this.fechaHasta = fechaHasta;

                this.cancellationTokenSource = new CancellationTokenSource();
                this.cancellationToken = this.cancellationTokenSource.Token;
                hilo = Task.Run(BuscarListadoDisponibles, this.cancellationToken);

                if (this.OnBusquedaIniciada is not null)
                {
                    this.OnBusquedaIniciada.Invoke();
                }
            }
        }

        /// <summary>
        /// Cancela la busqueda de atenciones
        /// </summary>
        public void CancelarBusqueda()
        {
            if (hilo is not null && !this.hilo.IsCompleted)
            {
                this.cancellationTokenSource.Cancel();
            }
        }

        /// <summary>
        /// Busca las atenciones y notifica cuando finaliza
        /// 
        /// CLASE 19 - Eventos
        /// 
        /// </summary>
        private void BuscarListadoDisponibles()
        {
            List<InformacionDeAtencion> atenciones = BuscadorDeAtenciones.visitaDAO.ObtenerRegistroDeAtenciones(this.fechaDesde, this.fechaHasta);
            if (this.OnBusquedaFinalizada is not null)
            {
                this.OnBusquedaFinalizada.Invoke(atenciones);
            }
        }
    }
}
