using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        void Guardar(string ruta, T contenido);
        //void SaveAS(string path, T content);
        T Leer(string ruta);
    }
}
