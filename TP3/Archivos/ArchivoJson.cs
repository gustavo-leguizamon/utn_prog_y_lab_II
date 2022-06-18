using System;
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

        public void Guardar(string ruta, T contenido)
        {
            string jsonString = JsonSerializer.Serialize(contenido);
            File.WriteAllText(ruta, jsonString);
        }

        public T Leer(string ruta)
        {
            ValidarSiExisteArchivo(ruta);
            ValidarExtension(ruta);
            string jsonString = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
