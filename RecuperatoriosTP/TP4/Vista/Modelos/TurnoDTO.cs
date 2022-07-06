using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vista.Modelos
{
    public class TurnoDTO
    {
        private long nroTurno;
        private string mascota;
        private DateTime fecha;
        private string comentario;

        public long NroTurno
        {
            get { return nroTurno; }
            set { nroTurno = value; }
        }

        public string Mascota
        {
            get { return mascota; }
            set { mascota = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Comentario
        {
            get { return comentario; }
            set { comentario = value; }
        }

        public TurnoDTO(long nroTurno, string mascota, DateTime fecha, string comentario)
        {
            this.nroTurno = nroTurno;
            this.mascota = mascota;
            this.fecha = fecha;
            this.comentario = comentario;
        }
    }
}
