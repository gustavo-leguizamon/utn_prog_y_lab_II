using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Exceptions
{
    /// <summary>
    /// Excepcion para manejar la inexistencia de una entidad
    /// 
    /// CLASE 10 - Excepciones
    /// 
    /// </summary>
    public class EntidadInexistenteException : Exception
    {
        public EntidadInexistenteException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
