using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class BusquedaMascota : IBusqueda<Mascota, long>
    {
        private List<Mascota> mascotas;

        public BusquedaMascota(List<Mascota> mascotas)
        {
            this.mascotas = mascotas;
        }

        public Mascota Buscar(long id)
        {
            foreach (Mascota mascota in this.mascotas)
            {
                if (mascota.DniDuenio == id)
                {
                    return mascota;
                }
            }

            throw new EntidadInexistenteException($"No existe mascota del dueño: {id}");
        }

        public bool Existe(long id)
        {
            try
            {
                return Buscar(id) is not null;
            }
            catch (EntidadInexistenteException)
            {
                return false;
            }
        }
    }
}
