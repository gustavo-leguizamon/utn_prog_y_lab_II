using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que representa una entidad de tipo Atencion
    /// 
    /// CLASE 12 - Tipos genericos
    /// CLASE 13 - Interfaces
    /// 
    /// </summary>
    public class Atencion : IEntidad<long>
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

        public Atencion()
        {

        }

        public Atencion(long id, long mascotaId, DateTime llegada, DateTime salida, float pesoActual, string observacion)
        {
            this.id = id;
            this.mascotaId = mascotaId;
            this.llegada = llegada;
            this.salida = salida;
            this.pesoActual = pesoActual;
            this.observacion = observacion;
        }


        public Atencion(long mascotaId, DateTime fecha, Tiempo llegada, Tiempo salida, float pesoActual, string observacion)
            : this(0, mascotaId, fecha.Date.AddHours(llegada.Hora).AddMinutes(llegada.Minuto).AddSeconds(llegada.Segundo), fecha.Date.AddHours(salida.Hora).AddMinutes(salida.Minuto).AddSeconds(salida.Segundo), pesoActual, observacion)
        {
        }
    }
}
