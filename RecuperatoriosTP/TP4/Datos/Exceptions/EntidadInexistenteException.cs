using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Exceptions
{
    public class EntidadInexistenteException : Exception
    {
        public EntidadInexistenteException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
