using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Clase encargada de manejar archivos de extension .json
    /// 
    /// CLASE 12 - Tipos genericos
    /// CLASE 13 - Interfaces
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArchivoJson<T> : Archivo, IArchivo<T>
      where T : class
    {
        protected override string Extension => ".json";

        public void Guardar(string ruta, T contenido)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(contenido);
                File.WriteAllText(ruta, jsonString);
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        public T Leer(string ruta)
        {
            T result = null;
            try
            {
                ValidarSiExisteArchivo(ruta);
                ValidarExtension(ruta);
                string jsonString = File.ReadAllText(ruta);
                result = JsonSerializer.Deserialize<T>(jsonString);
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
            return result;
        }
    }
}
