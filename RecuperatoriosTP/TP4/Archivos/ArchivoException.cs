using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Excepcion para utilizar en manejo de archivos
    /// 
    /// CLASE 10 - Excepciones
    /// 
    /// </summary>
    public class ArchivoException : Exception
    {
        public ArchivoException(string mensaje)
            : base(mensaje)
        {

        }

        public ArchivoException(string mensaje, Exception exception)
            : base(mensaje, exception)
        {

        }
    }
}
