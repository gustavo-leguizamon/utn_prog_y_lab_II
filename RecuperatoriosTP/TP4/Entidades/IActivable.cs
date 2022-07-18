using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interface para implementar en entidades que puedan activarse o desactivarse
    /// 
    /// CLASE 13 - Interfaces
    /// 
    /// </summary>
    public interface IActivable
    {
        bool Activo { get; set; }
    }
}
