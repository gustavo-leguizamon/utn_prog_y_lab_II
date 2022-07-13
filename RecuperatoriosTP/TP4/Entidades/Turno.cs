using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turno : IEntidad<long>
    {
        private long id;
        private long mascotaId;
        private short estadoTurnoId;
        private DateTime fecha;
        private string horaInicio;
        private string horaFin;
        private string comentario;

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

        public short EstadoTurnoId
        {
            get { return estadoTurnoId; }
            set { estadoTurnoId = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string HoraInicio
        {
            get { return horaInicio; }
            set { horaInicio = value; }
        }

        public string HoraFin
        {
            get { return horaFin; }
            set { horaFin = value; }
        }

        public string Comentario
        {
            get { return comentario; }
            set { comentario = value; }
        }

        public Mascota Mascota
        {
            get { return mascota; }
            set { mascota = value; }
        }

        public Turno()
        {

        }

        public Turno(Mascota mascota)
        {
            this.mascota = mascota;
        }

        public Turno(long id, short estadoTurnoId, long idMascota, DateTime fecha, string horaInicio, string horaFin, string comentario)
        {
            this.id = id;
            this.estadoTurnoId = estadoTurnoId;
            this.mascotaId = idMascota;
            this.fecha = fecha;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.comentario = comentario;
        }

        public Turno(long id, short estadoTurnoId, Mascota mascota, DateTime fecha, string horaInicio, string horaFin, string comentario)
            : this(id, estadoTurnoId, mascota.Id, fecha, horaInicio, horaFin, comentario)
        {
            this.mascota = mascota;
        }

        public Turno(short estadoTurnoId, long idMascota, DateTime fecha, string horaInicio, string horaFin, string comentario)
            : this(0, estadoTurnoId, idMascota, fecha, horaInicio, horaFin, comentario)
        {

        }
    }
}
