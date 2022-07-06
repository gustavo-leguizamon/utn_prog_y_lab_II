using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vista.Modelos;

namespace Vista.Mapeadores
{
    public class TurnoMapper
    {
        public static TurnoDTO Map(Turno turno)
        {
            return new TurnoDTO(turno.Id, turno.Mascota.Nombre, turno.Fecha, turno.Comentario);
        }

        public static List<TurnoDTO> Map(List<Turno> turnos)
        {
            List<TurnoDTO> list = new List<TurnoDTO>();
            foreach (Turno turno in turnos)
            {
                list.Add(Map(turno));
            }

            return list;
        }
    }
}
