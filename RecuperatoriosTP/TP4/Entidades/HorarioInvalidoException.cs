using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class HorarioInvalidoException : Exception
    {
        public HorarioInvalidoException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
