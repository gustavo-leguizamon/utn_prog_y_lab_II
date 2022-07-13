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
        private Tiempo horaInicio;
        private Tiempo horaFin;
        private string cliente;
        private string mascota;
        private string tipoMascota;

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

        public Tiempo HoraInicio
        {
            get { return horaInicio; }
            set { horaInicio = value; }
        }

        public Tiempo HoraFin
        {
            get { return horaFin; }
            set { horaFin = value; }
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


        //public ProximoTurno(long turnoId, DateTime fecha, string horaInicio, string horaFin, string cliente, string mascota)
        //{
        //    this.nroTurno = turnoId;
        //    this.fecha = fecha;
        //    this.horaInicio = new Tiempo(horaInicio);
        //    this.horaFin = new Tiempo(horaFin);
        //    this.cliente = cliente;
        //    this.mascota = mascota;
        //}

        public ProximoTurno(Turno turno)
        {
            this.nroTurno = turno.Id;
            this.fecha = turno.Fecha;
            this.horaInicio = new Tiempo(turno.HoraInicio);
            this.horaFin = new Tiempo(turno.HoraFin);
            this.cliente = turno.Mascota.Cliente.NombreCompleto;
            this.mascota = turno.Mascota.Nombre;
            this.tipoMascota = Enum.GetName(turno.Mascota.TipoMascota);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"#Turno: {this.nroTurno}");
            sb.AppendLine($"Fecha: {this.Fecha.ToString("dd/MM/yyyy")} {this.horaInicio}-{this.horaFin}");
            sb.AppendLine($"Cliente: {this.cliente}");
            sb.AppendLine($"Mascota: {this.mascota} ({this.tipoMascota})");

            return sb.ToString();
        }
    }
}
