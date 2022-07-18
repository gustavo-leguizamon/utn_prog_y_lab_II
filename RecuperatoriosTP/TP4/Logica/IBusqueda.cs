using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    /// <summary>
    /// Interface para implementar en clase que realicen busquedas de entidades
    /// 
    /// CLASE 12 - Tipos genericos
    /// CLASE 13 - Interfaces
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBusqueda<T>
    {
        bool Existe(T entidad);
    }
}
