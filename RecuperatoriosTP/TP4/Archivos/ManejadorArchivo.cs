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

            throw new SinManejadorArchivoException($"No existe un menejador de archivos para los archivos {Path.GetExtension(ruta)}");
        }

        private static void ValidarArchivo<T>(T archivo, string ruta)
            where T : Archivo
        {
            archivo.ValidarExtension(ruta);
        }
    }
}
