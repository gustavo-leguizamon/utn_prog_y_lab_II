using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EstadoTurno : IEntidad<short>
    {
        public enum eEstadoTurno
        {
            Vigente = 1,
            Atendido = 2,
            Cancelado = 3,
        }

        private short id;
        private string descripcion;
        
        public short Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public EstadoTurno(short id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }

        public override string ToString()
        {
            return this.descripcion;
        }
    }
}
