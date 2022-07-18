using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Interface para manejar archivos
    /// 
    /// CLASE 12 - Tipos genericos
    /// CLASE 13 - Interfaces
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IArchivo<T>
    {
        /// <summary>
        /// Serializa un objeto y lo almacena en un archivo en disco
        /// </summary>
        /// <param name="ruta">Ruta del archivo en el disco</param>
        /// <param name="contenido">Objeto a serializar</param>
        void Guardar(string ruta, T contenido);

        /// <summary>
        /// Deserializa un archivo en el objeto T especificado
        /// </summary>
        /// <param name="ruta">Ruta del archivo en el disco</param>
        /// <returns>Objeto en el programa con los datos del archivo</returns>
        T Leer(string ruta);
    }
}
