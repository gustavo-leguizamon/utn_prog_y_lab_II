using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vista.Modelos;

namespace Vista.Mapeadores
{
    public class MascotaMapper
    {
        public static MascotaDTO Map(Mascota mascota)
        {
            return new MascotaDTO(mascota.Id, mascota.Nombre, mascota.Cliente.Dni, $"{mascota.Cliente.Apellido} {mascota.Cliente.Nombre}", mascota.Peso, mascota.FechaNacimiento);
        }

        public static List<MascotaDTO> Map(List<Mascota> mascotas)
        {
            List<MascotaDTO> list = new List<MascotaDTO>();
            foreach (Mascota mascota in mascotas)
            {
                list.Add(Map(mascota));
            }

            return list;
        }
    }
}
