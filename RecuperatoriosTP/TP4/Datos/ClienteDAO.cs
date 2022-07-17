using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ClienteDAO : BaseDAO<long, Cliente>
    {
        protected override string Tabla => "Clientes";
                
        public override List<Cliente> Leer(Type[] incluirRelaciones)
        {
            List<Cliente> clientes = base.Leer();
            if (clientes.Any())
            {
                MascotaDAO mascotaDAO = new MascotaDAO();
                TurnoDAO turnoDAO = new TurnoDAO();
                AtencionDAO atencionDAO = new AtencionDAO();
                foreach (Cliente cliente in clientes)
                {
                    if (incluirRelaciones.Contains(typeof(Mascota)))
                    {
                        cliente.Mascotas = mascotaDAO.Leer(x => x.ClienteId == cliente.Id);
                    }
                    if (incluirRelaciones.Contains(typeof(Turno)))
                    {
                        if (cliente.Mascotas is null || cliente.Mascotas.Count == 0)
                        {
                            cliente.Mascotas = mascotaDAO.Leer(x => x.ClienteId == cliente.Id);
                        }
                        foreach (Mascota mascota in cliente.Mascotas)
                        {
                            mascota.Turnos = turnoDAO.Leer(x => x.MascotaId == mascota.Id);
                        }
                    }
                    if (incluirRelaciones.Contains(typeof(Atencion)))
                    {
                        if (cliente.Mascotas is null || cliente.Mascotas.Count == 0)
                        {
                            cliente.Mascotas = mascotaDAO.Leer(x => x.ClienteId == cliente.Id);
                        }
                        foreach (Mascota mascota in cliente.Mascotas)
                        {
                            mascota.Atenciones = atencionDAO.Leer(x => x.MascotaId == mascota.Id);
                        }
                    }
                }
            }

            return clientes;
        }

        
        public override Cliente LeerPorId(long id, Type[] incluirRelaciones)
        {
            Cliente cliente = LeerPorId(id);
            if (incluirRelaciones.Contains(typeof(Mascota)))
            {
                cliente.Mascotas = new MascotaDAO().Leer(x => x.ClienteId == cliente.Id);
            }
            return cliente;
        }

        protected override SqlCommand CrearCommandInsert(Cliente entidad)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine($"INSERT INTO {Tabla} (Dni, Nombre, Apellido, FechaNacimiento, Direccion, Activo)");
            query.AppendLine("VALUES(@dni, @nombre, @apellido, @fecha, @direccion, @activo)");
            query.AppendLine("SELECT CAST(@@IDENTITY AS BIGINT)");

            SqlCommand command = new SqlCommand(query.ToString());
            command.Parameters.AddWithValue("dni", entidad.Dni);
            command.Parameters.AddWithValue("nombre", entidad.Nombre);
            command.Parameters.AddWithValue("apellido", entidad.Apellido);
            command.Parameters.AddWithValue("fecha", entidad.FechaNacimiento);
            command.Parameters.AddWithValue("direccion", entidad.Direccion);
            command.Parameters.AddWithValue("activo", entidad.Activo);

            return command;
        }

        protected override SqlCommand CrearCommandUpdate(Cliente entidad)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine($"UPDATE {Tabla} SET");
            query.AppendLine("Dni = @dni,");
            query.AppendLine("Nombre = @nombre,");
            query.AppendLine("Apellido = @apellido,");
            query.AppendLine("FechaNacimiento = @nacimiento,");
            query.AppendLine("Direccion = @direccion,");
            query.AppendLine("Activo = @activo");
            query.AppendLine("WHERE Id = @id");

            SqlCommand command = new SqlCommand(query.ToString());
            command.Parameters.AddWithValue("id", entidad.Id);
            command.Parameters.AddWithValue("dni", entidad.Dni);
            command.Parameters.AddWithValue("nombre", entidad.Nombre);
            command.Parameters.AddWithValue("apellido", entidad.Apellido);
            command.Parameters.AddWithValue("nacimiento", entidad.FechaNacimiento);
            command.Parameters.AddWithValue("direccion", entidad.Direccion);
            command.Parameters.AddWithValue("activo", entidad.Activo);

            return command;
        }

        protected override Cliente ParseResultado(SqlDataReader reader)
        {
            long id = Convert.ToInt64(reader["Id"]);
            long dni = Convert.ToInt64(reader["Dni"]);
            string nombre = reader["Nombre"].ToString();
            string apellido = reader["Apellido"].ToString();
            DateTime fecha = Convert.ToDateTime(reader["FechaNacimiento"].ToString());
            string direccion = reader["Direccion"].ToString();
            bool activo = Convert.ToBoolean(reader["Activo"]);
            return new Cliente(id, dni, nombre, apellido, fecha, direccion, activo);
        }

        public override void Guardar(Cliente entidad, bool incluirRelaciones)
        {
            Guardar(entidad);
            if (incluirRelaciones)
            {
                MascotaDAO mascotaDAO = new MascotaDAO();
                TurnoDAO turnoDAO = new TurnoDAO();
                AtencionDAO atencionDAO = new AtencionDAO();
                foreach (Mascota mascota in entidad.Mascotas)
                {
                    mascota.ClienteId = entidad.Id;
                    mascotaDAO.Guardar(mascota);
                    foreach(Turno turno in mascota.Turnos)
                    {
                        turno.MascotaId = mascota.Id;
                        turnoDAO.Guardar(turno);
                    }
                    foreach (Atencion atencion in mascota.Atenciones)
                    {
                        atencion.MascotaId = mascota.Id;
                        atencionDAO.Guardar(atencion);
                    }
                }
            }
        }
    }
}
