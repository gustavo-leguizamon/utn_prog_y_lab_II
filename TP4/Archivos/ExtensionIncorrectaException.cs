using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Lanzada cuando se recibe una extension incorrecta al tipo de archivo trabajado
    /// </summary>
    public class ExtensionIncorrectaException : Exception
    {
        public ExtensionIncorrectaException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
