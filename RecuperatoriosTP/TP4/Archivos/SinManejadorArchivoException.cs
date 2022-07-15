using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class SinManejadorArchivoException : Exception
    {
        public SinManejadorArchivoException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
