using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turno
    {
        private long id;
        private long idMascota;
        private DateTime fecha;
        private string comentario;

        private Mascota mascota;

        public long Id
        {
            get { return id; }
        }

        public long IdMascota
        {
            get { return idMascota; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
        }

        public string Comentario
        {
            get { return comentario; }
        }

        public Mascota Mascota
        {
            get { return mascota; }
            set { mascota = value; }
        }

        public Turno(long id, long idMascota, DateTime fecha, string comentario)
        {
            this.id = id;
            this.idMascota = idMascota;
            this.fecha = fecha;
            this.comentario = comentario;
        }

        public Turno(long id, Mascota mascota, DateTime fecha, string comentario)
            : this(id, mascota.Id, fecha, comentario)
        {
            this.mascota = mascota;
        }

        public Turno(long idMascota, DateTime fecha, string comentario)
            : this(0, idMascota, fecha, comentario)
        {

        }
    }
}
