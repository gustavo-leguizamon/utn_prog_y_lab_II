using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class EntidadInexistenteException : Exception
    {
        public EntidadInexistenteException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
