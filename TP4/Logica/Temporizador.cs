using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logica
{
    public class Temporizador
    {
        public delegate void DelegateTimerHandler();

        public event DelegateTimerHandler OnTimerCompleto;

        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;
        private Task hilo;
        private int intervalo;

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
        public int Interval { get { return intervalo; } set { intervalo = value; } }

        public Temporizador(int intervalo)
        {
            this.intervalo = intervalo;
        }

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

        public void Detener()
        {
            if (hilo is not null && !hilo.IsCompleted)
            {
                cancellationTokenSource.Cancel();
            }
        }
    }
}
