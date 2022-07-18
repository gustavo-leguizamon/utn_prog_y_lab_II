using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Exceptions
{
    /// <summary>
    /// Excepcion para manejar cuando no hay mas turnos en la base de datos
    /// 
    /// CLASE 10 - Excepciones
    /// 
    /// </summary>
    public class NoHayMasTurnosException : Exception
    {
        public NoHayMasTurnosException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
