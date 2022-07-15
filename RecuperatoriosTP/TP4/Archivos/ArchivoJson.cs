﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Archivos
{
    public class ArchivoJson<T> : Archivo, IArchivo<T>
      where T : class
    {
        protected override string Extension => ".json";

        /// <summary>
        /// Serializa un objeto y lo almacena en un archivo en formato json
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="contenido"></param>
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

        /// <summary>
        /// Deserializa un archivo json en el objeto T especificado
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>
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
