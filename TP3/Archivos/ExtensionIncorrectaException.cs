using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class ExtensionIncorrectaException : Exception
    {
        public ExtensionIncorrectaException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
