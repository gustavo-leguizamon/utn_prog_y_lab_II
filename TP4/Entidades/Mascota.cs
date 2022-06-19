using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mascota
    {
        public long DniDuenio { get; set; }
        public string Nombre { get; set; }
        public float Peso { get; set; }
        public DateTime FechaNacimiento { get; set; }

        #region Operators

        public static bool operator ==(Mascota m1, Mascota m2)
        {
            return m1.DniDuenio == m2.DniDuenio &&
                   m1.Nombre == m2.Nombre &&
                   m1.FechaNacimiento.Date == m2.FechaNacimiento.Date;
        }

        public static bool operator !=(Mascota m1, Mascota m2)
        {
            return !(m1 == m2);
        }

        #endregion
    }
}
