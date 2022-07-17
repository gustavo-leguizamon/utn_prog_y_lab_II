using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Indica formatos para tipos de datos DateTime nulables
        /// </summary>
        /// <param name="datetime">Instancia del objeto DateTime nulable</param>
        /// <param name="format">Formato de salida</param>
        /// <param name="message">Mensaje opcional cuando la instancia es null</param>
        /// <returns>String con el formato especificado o el mensaje opcional si el objeto DateTime es null</returns>
        public static string ToString(this DateTime? datetime, string format, string message = "")
        {
            return datetime == null ? message : datetime.Value.ToString(format);
        }

        /// <summary>
        /// Devuelve la hora de la instancia en el formato hh:mm:ss
        /// </summary>
        /// <param name="dateTime">Instancia del objeto DateTime</param>
        /// <returns>String con la hora en formato hh:mm:ss</returns>
        public static string GetHora(this DateTime dateTime)
        {
            return dateTime.ToString("HH:mm:ss");
        }
    }
}
