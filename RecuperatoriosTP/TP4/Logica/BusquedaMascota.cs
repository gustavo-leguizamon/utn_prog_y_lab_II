using Datos;
using Datos.Exceptions;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class BusquedaMascota// : IBusqueda<Mascota, long>
    {
        //private List<Mascota> mascotas;
        private MascotaDAO mascotaDAO;

        //public BusquedaMascota(List<Mascota> mascotas)
        //{
        //    this.mascotas = mascotas;
        //}

        public BusquedaMascota()
        {
            this.mascotaDAO = new MascotaDAO();
        }

        //public Mascota Buscar(long id)
        //{
        //    foreach (Mascota mascota in this.mascotas)
        //    {
        //        if (mascota.ClienteId == id)
        //        {
        //            return mascota;
        //        }
        //    }

        //    throw new EntidadInexistenteException($"No existe mascota del dueño: {id}");
        //}

        //public bool Existe(long id)
        //{
        //    try
        //    {
        //        return Buscar(id) is not null;
        //    }
        //    catch (EntidadInexistenteException)
        //    {
        //        return false;
        //    }
        //}

        public bool Existe(Mascota mascota)
        {
            List<Mascota> mascotas = this.mascotaDAO.Leer();
            return mascotas.Any(m => m.ClienteId == mascota.ClienteId && m.Nombre == mascota.Nombre && m.FechaNacimiento == mascota.FechaNacimiento);
        }
    }
}
