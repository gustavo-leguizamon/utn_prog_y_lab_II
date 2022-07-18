using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logica
{
    /// <summary>
    /// Simula un reloj que se ejecuta cada cierto intervalo de tiempo
    /// 
    /// CLASE 18 - Hilos
    /// 
    /// </summary>
    public class Temporizador
    {
        /// <summary>
        /// Delegado para manejar el reloj
        /// 
        /// CLASE 17 - Delegados y expresiones lambda
        /// 
        /// </summary>
        public delegate void DelegateTimerHandler();

        /// <summary>
        /// Evento que notifica cuando el intervalo configurado se completa
        /// 
        /// CLASE 19 - Eventos
        /// 
        /// </summary>
        public event DelegateTimerHandler OnTimerCompleto;

        /// <summary>
        /// Evento que notifica cuando el temporizador se reinicia
        /// 
        /// CLASE 19 - Eventos
        /// 
        /// </summary>
        public event DelegateTimerHandler OnTimerReiniciar;

        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;
        private Task hilo;
        private int intervalo;

        /// <summary>
        /// Indica si el hilo del temporizador se encuentra activo
        /// </summary>
        public bool EstaActivo
        {
            get
            {
                return hilo is not null &&
                    (hilo.Status == TaskStatus.Running ||
                    hilo.Status == TaskStatus.WaitingToRun ||
                    hilo.Status == TaskStatus.WaitingForActivation);
            }
        }

        /// <summary>
        /// Indica el intervalo utilizado
        /// </summary>
        public int Interval 
        { 
            get { return intervalo; } 
        }

        public Temporizador(int intervalo)
        {
            this.intervalo = intervalo;
        }

        /// <summary>
        /// Detiene la ejecucion del temporizador cada intervalo configurado
        /// 
        /// CLASE 19 - Eventos
        /// 
        /// </summary>
        private void Ejecutar()
        {
            do
            {
                if (OnTimerCompleto is not null)
                {
                    OnTimerCompleto.Invoke();
                }

                Thread.Sleep(intervalo);
            } while (!cancellationToken.IsCancellationRequested);
        }

        /// <summary>
        /// Inicia el temporizador
        /// </summary>
        public void Comenzar()
        {
            if (hilo is null || hilo.IsCompleted)
            {
                cancellationTokenSource = new CancellationTokenSource();
                cancellationToken = cancellationTokenSource.Token;

                hilo = new Task(Ejecutar, cancellationToken);
            }

            if (!EstaActivo)
            {
                hilo.Start();
            }
        }

        /// <summary>
        /// Reinicia el temporizador
        /// 
        /// CLASE 19 - Eventos
        /// 
        /// </summary>
        public void Reiniciar()
        {
            Detener();
            Comenzar();
            if (OnTimerReiniciar is not null)
            {
                OnTimerReiniciar.Invoke();
            }
        }

        /// <summary>
        /// Detiene el temporizador
        /// </summary>
        public void Detener()
        {
            if (hilo is not null && !hilo.IsCompleted)
            {
                cancellationTokenSource.Cancel();
                hilo = null;
            }
        }
    }
}
