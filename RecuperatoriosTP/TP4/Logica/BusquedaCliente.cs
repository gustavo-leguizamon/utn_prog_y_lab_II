using Datos;
using Datos.Exceptions;
using Entidades;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class BusquedaCliente : IBusqueda<Cliente, long>
    {
        private List<Cliente> clientes;

        public BusquedaCliente(List<Cliente> clientes)
        {
            this.clientes = clientes;
        }

        public Cliente Buscar(long dni)
        {
            foreach (Cliente cliente in this.clientes)
            {
                if (cliente.Dni == dni)
                {
                    return cliente;
                }
            }

            throw new EntidadInexistenteException($"No existe el cliente con DNI: {dni}");
        }

        public bool Existe(long dni)
        {
            try
            {
                return Buscar(dni) is not null;
            }
            catch (EntidadInexistenteException)
            {
                return false;
            }
        }
    }
}
