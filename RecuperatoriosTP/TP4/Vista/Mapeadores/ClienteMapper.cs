using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vista.Modelos;

namespace Vista.Mapeadores
{
    public class ClienteMapper
    {
        public static ClienteDTO Map(Cliente cliente)
        {
            return new ClienteDTO(cliente.Id, cliente.Dni, cliente.Nombre, cliente.Apellido, cliente.Direccion, cliente.FechaNacimiento);
        }

        public static List<ClienteDTO> Map(List<Cliente> clientes)
        {
            List<ClienteDTO> list = new List<ClienteDTO>();
            foreach (Cliente cliente in clientes)
            {
                list.Add(Map(cliente));
            }

            return list;
        }
    }
}
