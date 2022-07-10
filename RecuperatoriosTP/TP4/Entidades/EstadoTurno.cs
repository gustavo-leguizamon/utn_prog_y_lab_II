using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EstadoTurno : IEntidad
    {
        public enum eEstadoTurno
        {
            Vigente = 1,
            Atendido = 2,
            Cancelado = 3,
        }

        private long id;
        private string descripcion;
        
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}
