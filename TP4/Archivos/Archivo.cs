using System;
using System.IO;

namespace Archivos
{
    public abstract class Archivo
    {
        protected abstract string Extension { get; }

        /// <summary>
        /// Cheque si la extension de un archivo corresponde al tipo que se esté trabajando
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>
        /// <exception cref="ExtensionIncorrectaException"></exception>
        public bool ValidarExtension(string ruta)
        {
            if (Path.GetExtension(ruta) != Extension)
                throw new ExtensionIncorrectaException($"El archivo no tiene la extensión {Extension}.");
            return true;
        }

        /// <summary>
        /// Verifica si existe el archivo en el disco
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>
        /// <exception cref="ArchivoNoEncontradoException"></exception>
        public bool ValidarSiExisteArchivo(string ruta)
        {
            if (!File.Exists(ruta))
                throw new ArchivoNoEncontradoException($"No se encontró el archivo: {ruta}");
            return true;
        }
    }
}
