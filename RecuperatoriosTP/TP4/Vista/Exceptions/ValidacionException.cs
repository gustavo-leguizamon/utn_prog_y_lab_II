using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vista.Exceptions
{
    internal class ValidacionException : Exception
    {
        public ValidacionException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
