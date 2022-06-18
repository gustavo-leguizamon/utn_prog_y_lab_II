using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<Mascota> Mascotas { get; set; }

        public Cliente()
        {
            Mascotas = new List<Mascota>();
        }

        #region Operators

        public static bool operator ==(Cliente c1, Cliente c2)
        {
            return c1.Dni == c2.Dni;
        }

        public static bool operator !=(Cliente m1, Cliente m2)
        {
            return !(m1 == m2);
        }

        #endregion
    }
}
