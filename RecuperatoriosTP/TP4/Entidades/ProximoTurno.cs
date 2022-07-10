using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProximoTurno
    {
        private long nroTurno;
        private DateTime fecha;
        private string cliente;
        private string mascota;

        public long NroTurno
        {
            get { return nroTurno; }
            set { nroTurno = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public string Mascota
        {
            get { return mascota; }
            set { mascota = value; }
        }


        public ProximoTurno(long turnoId, DateTime fecha, string cliente, string mascota)
        {
            this.nroTurno = turnoId;
            this.fecha = fecha;
            this.cliente = cliente;
            this.mascota = mascota;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"#Turno: {this.nroTurno}");
            sb.AppendLine($"Fecha: {this.Fecha.ToString("dd/MM/yyyy HH:mm")}");
            sb.AppendLine($"Cliente: {this.cliente}");
            sb.AppendLine($"Mascota: {this.mascota}");

            return sb.ToString();
        }
    }
}
