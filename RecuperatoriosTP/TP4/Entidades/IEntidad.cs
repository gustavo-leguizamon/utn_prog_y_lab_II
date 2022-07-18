using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfece para implementar en entidades
    /// 
    /// CLASE 12 - Tipos genericos
    /// CLASE 13 - Interfaces
    /// 
    /// </summary>
    /// <typeparam name="TID">Tipo de dato del ID de la entidad</typeparam>
    public interface IEntidad<TID>
    {
        TID Id { get; set; }
    }
}
