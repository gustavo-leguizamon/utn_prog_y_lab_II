using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class InformacionDeAtencion
    {
        private string cliente;
        private long dni;
        private string mascota;
        private string tipoMascota;
        private string observacion;
        private DateTime llegada;
        private DateTime salida;

        public string Cliente { get => this.cliente; }
        public long Dni { get => this.dni; }
        public string Mascota { get => this.mascota; }
        public string TipoMascota { get => this.tipoMascota; }
        public string Observacion { get => this.observacion; }
        public DateTime Llegada { get => this.llegada; }
        public DateTime Salida { get => this.salida; }

        public InformacionDeAtencion(string cliente, long dni, string mascota, string tipoMascota, string observacion, DateTime llegada, DateTime salida)
        {
            this.cliente = cliente;
            this.dni = dni;
            this.mascota = mascota;
            this.tipoMascota = tipoMascota;
            this.observacion = observacion;
            this.llegada = llegada;
            this.salida = salida;
        }
    }
}
