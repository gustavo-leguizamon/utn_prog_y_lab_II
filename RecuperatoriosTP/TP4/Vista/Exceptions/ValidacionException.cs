using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vista.Exceptions
{
    /// <summary>
    /// Excepcion para manejar las validaciones en formularios
    /// 
    /// CLASE 10 - Excepciones
    /// 
    /// </summary>
    internal class ValidacionException : Exception
    {
        public ValidacionException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
