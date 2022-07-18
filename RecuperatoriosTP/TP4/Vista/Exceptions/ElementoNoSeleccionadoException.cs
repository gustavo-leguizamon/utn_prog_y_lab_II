using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vista.Exceptions
{
    internal class ElementoNoSeleccionadoException : Exception
    {
        /// <summary>
        /// Excepcion para manejar cuando no se selecciona un elemento de uns listado
        /// 
        /// CLASE 10 - Excepciones
        /// 
        /// </summary>
        /// <param name="mensaje"></param>
        public ElementoNoSeleccionadoException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
