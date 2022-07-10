using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Exceptions
{
    public class NoHayMasTurnosException : Exception
    {
        public NoHayMasTurnosException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
