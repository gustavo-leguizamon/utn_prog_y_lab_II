using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class InformacionTurno
    {
        private long turnoId;
        private DateTime fecha;
        private string comentario;
        private string estado;
        private string cliente;
        private string mascota;
        private short estadoTurnoId;

        public short EstadoTurnoId
        {
            get { return estadoTurnoId; }
        }


        public long TurnoId
        {
            get { return turnoId; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
        }

        public string Comentario
        {
            get { return comentario; }
        }

        public string Estado
        {
            get { return estado; }
        }

        public string Cliente
        {
            get { return cliente; }
        }

        public string Mascota
        {
            get { return mascota; }
        }


        public InformacionTurno(long turnoId, DateTime fecha, string comentario, short estadoId, string estado, string cliente, string mascota)
        {
            this.turnoId = turnoId;
            this.fecha = fecha;
            this.comentario = comentario;
            this.estadoTurnoId = estadoId;
            this.estado = estado;
            this.cliente = cliente;
            this.mascota = mascota;
        }
    }
}
