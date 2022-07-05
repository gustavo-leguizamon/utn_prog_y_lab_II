using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Indica formatos para tipos de datos DateTime nulables
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="format"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string ToString(this DateTime? datetime, string format, string message = "")
        {
            return datetime == null ? message : datetime.Value.ToString(format);
        }
    }
}
