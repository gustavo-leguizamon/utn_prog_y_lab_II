using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Visita : IEntidad<long>
    {
        private long id;
        private long mascotaId;
        private DateTime llegada;
        private DateTime salida;
        private float pesoActual;
        private string observacion;

        private Mascota mascota;


        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public long MascotaId
        {
            get { return mascotaId; }
            set { mascotaId = value; }
        }

        public DateTime Llegada
        {
            get { return llegada; }
            set { llegada = value; }
        }

        public DateTime Salida
        {
            get { return salida; }
            set { salida = value; }
        }

        public float PesoActual
        {
            get { return pesoActual; }
            set { pesoActual = value; }
        }

        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }


        public Visita(long id, long mascotaId, DateTime llegada, DateTime salida, float pesoActual, string observacion)
        {
            this.id = id;
            this.mascotaId = mascotaId;
            this.llegada = llegada;
            this.salida = salida;
            this.pesoActual = pesoActual;
            this.observacion = observacion;
        }

        public Visita(long mascotaId, DateTime llegada, DateTime salida, float pesoActual, string observacion)
            : this(0, mascotaId, llegada, salida, pesoActual, observacion)
        {

        }
    }
}
