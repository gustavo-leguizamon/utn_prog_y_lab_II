using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    /// <summary>
    /// Excepcion para manejar la utilizacion de horas
    /// 
    /// CLASE 10 - Excepciones
    /// 
    /// </summary>
    public class HorarioInvalidoException : Exception
    {
        public HorarioInvalidoException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
