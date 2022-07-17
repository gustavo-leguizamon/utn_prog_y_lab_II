﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Archivos
{
    public class ArchivoXml<T> : Archivo, IArchivo<T>
      where T : class
    {
        protected override string Extension => ".xml";

        public void Guardar(string ruta, T contenido)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(ruta))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWriter, contenido);
                }
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
                using (StreamReader streamReader = new StreamReader(ruta))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    return xmlSerializer.Deserialize(streamReader) as T;
                }
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
            return result;
        }
    }
}
