using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public static class ManejadorArchivo
    {
        /// <summary>
        /// Determina la clase encargada de manejar el tipo de archivos que se pasa por parametro
        /// </summary>
        /// <typeparam name="T">Clase con la cual se va a utilizar el archivo</typeparam>
        /// <param name="ruta">Ruta del archivo en el disco</param>
        /// <returns>Una instancia del tipo de objeto que puede manejar el tipo de archivos</returns>
        /// <exception cref="ArchivoException">Lanzada cuando no hay ningun manejador para el tipo de archivo pasado por parametro</exception>
        public static IArchivo<T> ObtenerArchivo<T>(string ruta)
            where T : class
        {
            List<Type> tiposArchivos = new List<Type>
            {
                typeof(ArchivoJson<T>),
                typeof(ArchivoXml<T>),
            };

            Archivo archivo;
            foreach (Type tipo in tiposArchivos)
            {
                try
                {
                    archivo = (Archivo)Activator.CreateInstance(tipo);
                    archivo.ValidarExtension(ruta);
                    return (IArchivo<T>)archivo;
                }
                catch (ArchivoException)
                {

                }
            }

            throw new ArchivoException($"No existe un menejador de archivos para los archivos {Path.GetExtension(ruta)}");
        }
    }
}
