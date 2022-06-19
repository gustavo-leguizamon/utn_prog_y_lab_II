using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public interface IBusqueda<T, ID>
    {
        T Buscar(ID id);
        bool Existe(ID id);
    }
}
