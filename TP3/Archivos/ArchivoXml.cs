using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Archivos
{
    public class ArchivoXml<T> : Archivo, IArchivo<T>
      where T : class, new()
    {
        protected override string Extension => ".xml";

        public void Guardar(string ruta, T contenido)
        {
            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(streamWriter, contenido);
            }
        }

        public T Leer(string ruta)
        {
            ValidarSiExisteArchivo(ruta);
            ValidarExtension(ruta);
            using (StreamReader streamReader = new StreamReader(ruta))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                return xmlSerializer.Deserialize(streamReader) as T;
            }
        }
    }
}
