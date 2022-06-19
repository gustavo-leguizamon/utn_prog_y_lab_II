using System;
using System.IO;

namespace Archivos
{
    public abstract class Archivo
    {
        protected abstract string Extension { get; }

        public bool ValidarExtension(string ruta)
        {
            if (Path.GetExtension(ruta) != Extension)
                throw new ExtensionIncorrectaException($"El archivo no tiene la extensión {Extension}.");
            return true;
        }

        public bool ValidarSiExisteArchivo(string ruta)
        {
            if (!File.Exists(ruta))
                throw new ArchivoNoEncontradoException($"No se encontró el archivo: {ruta}");
            return true;
        }
    }
}
