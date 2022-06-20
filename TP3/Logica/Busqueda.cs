using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Busqueda<T, ID> : IBusqueda<T, ID>
    {
        public List<T> list { get; set; }

        public Busqueda(List<T> list)
        {
            this.list = list;
        }

        public Cliente Buscar(long id)
        {
            throw new NotImplementedException();
        }

        public bool Existe(long id)
        {
            throw new NotImplementedException();
        }
    }
}
