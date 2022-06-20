using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Lanzada cuando no se encuentra un archivo
    /// </summary>
    public class ArchivoNoEncontradoException : Exception
    {
        public ArchivoNoEncontradoException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
