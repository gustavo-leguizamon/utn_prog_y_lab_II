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
    /// <summary>
    /// Permite realizar la busqueda de mascotas
    /// 
    /// CLASE 12 - Tipos genericos
    /// CLASE 13 - Interfaces
    /// 
    /// </summary>
    public class BusquedaMascota : IBusqueda<Mascota>
    {
        private MascotaDAO mascotaDAO;

        public BusquedaMascota()
        {
            this.mascotaDAO = new MascotaDAO();
        }

        /// <summary>
        /// Determina si una mascata ya existe
        /// 
        /// CLASE 17 - Delegados y expresiones lambda
        /// 
        /// </summary>
        /// <param name="mascota">Mascota a evaluar</param>
        /// <returns>True si existe, false caso contrario</returns>
        public bool Existe(Mascota mascota)
        {
            bool existe;
            List<Mascota> mascotas = this.mascotaDAO.Leer(m => m.ClienteId == mascota.ClienteId);
            if (mascota.Id > 0)
            {
                existe = mascotas.Any(m => m.Id != mascota.Id && m.ClienteId == mascota.ClienteId && m.Nombre == mascota.Nombre && m.FechaNacimiento == mascota.FechaNacimiento);
            }
            else
            {
                existe = mascotas.Any(m => m.ClienteId == mascota.ClienteId && m.Nombre == mascota.Nombre && m.FechaNacimiento == mascota.FechaNacimiento);
            }
            return existe;
        }
    }
}
