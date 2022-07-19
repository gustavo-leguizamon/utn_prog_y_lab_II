using System;
using System.IO;

namespace Archivos
{
    public abstract class Archivo
    {
        /// <summary>
        /// Tipo de extension de los archivos a manejar
        /// </summary>
        protected abstract string Extension { get; }


        /// <summary>
        /// Cheque si la extension de un archivo corresponde al tipo de archivo que se esté trabajando
        /// 
        /// CLASE 10 - Excepciones
        /// 
        /// </summary>
        /// <param name="ruta">Ruta del archivo en el disco</param>
        /// <returns>True si valida la extension</returns>
        /// <exception cref="ArchivoException">Lanzada si el archivo no es de la extension correcta</exception>
        public bool ValidarExtension(string ruta)
        {
            if (Path.GetExtension(ruta) != Extension)
                throw new ArchivoException($"El archivo no tiene la extensión {Extension}.");
            return true;
        }

        /// <summary>
        /// Verifica si existe el archivo en el disco
        /// 
        /// CLASE 10 - Excepciones
        /// 
        /// </summary>
        /// <param name="ruta">Ruta del archivo en el disco</param>
        /// <returns>True si existe</returns>
        /// <exception cref="ArchivoException">Lanzada cuando no existe el archivo</exception>
        public bool ValidarSiExisteArchivo(string ruta)
        {
            if (!File.Exists(ruta))
                throw new ArchivoException($"No se encontró el archivo: {ruta}");
            return true;
        }

        /// <summary>
        /// Manejar las excepciones producidas al operar con los archivos
        /// 
        /// CLASE 10 - Excepciones
        /// 
        /// </summary>
        /// <param name="exception">Excepcion producida originalmente</param>
        /// <exception cref="ArchivoException">Lanzada como excepcion propia luego de manejar la original</exception>
        protected void ManejarExcepcion(Exception exception)
        {
            string mensaje = string.Empty;
            if (exception is ArchivoException)
            {
                throw exception;
            }
            else if (exception is PathTooLongException)
            {
                mensaje = "La ruta del archivo supera el límite";
            }
            else if (exception is DirectoryNotFoundException ||
                     exception is FileNotFoundException)
            {
                mensaje = "No se encontro el archivo, revisar la ruta provista";
            }
            else if (exception is UnauthorizedAccessException)
            {
                mensaje = "No se puede acceder al archivo por falta de permisos";
            }
            else
            {
                mensaje = "Revise el formato del archivo";
            }
            throw new ArchivoException(mensaje, exception);
        }
    }
}
