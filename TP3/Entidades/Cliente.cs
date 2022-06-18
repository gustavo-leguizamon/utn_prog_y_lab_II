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
    }
}
