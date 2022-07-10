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

        //public delegate void DelegadoActualizacionDatosHandler();

        //public event DelegadoActualizacionDatosHandler OnNuevosDatos;


        //public override void Eliminar(long id)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        string query = $"DELETE FROM {Tabla} WHERE Dni = @id";

        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("id", id);
        //        command.ExecuteNonQuery();
        //    }

        //    if (OnNuevosDatos is not null)
        //    {
        //        OnNuevosDatos.Invoke();
        //    }
        //}

        //public override void Guardar(Cliente entidad)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        string query = $"INSERT INTO {Tabla} (Dni, Nombre, Apellido, FechaNacimiento, Direccion) VALUES(@dni, @nombre, @apellido, @fecha, @direccion)";

        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("dni", entidad.Dni);
        //        command.Parameters.AddWithValue("nombre", entidad.Nombre);
        //        command.Parameters.AddWithValue("apellido", entidad.Apellido);
        //        command.Parameters.AddWithValue("fecha", entidad.FechaNacimiento);
        //        command.Parameters.AddWithValue("direccion", entidad.Direccion);
        //        command.ExecuteNonQuery();
        //    }

        //    if (base.OnNuevosDatos is not null)
        //    {
        //        OnNuevosDatos.Invoke();
        //    }
        //}

        //public override List<Cliente> Leer()
        //{
        //    List<Cliente> list = new List<Cliente>();
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        string query = "SELECT * FROM Clientes";

        //        SqlCommand command = new SqlCommand(query, connection);

        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            long id = Convert.ToInt64(reader["Dni"].ToString());
        //            string nombre = reader["Nombre"].ToString();
        //            string apellido = reader["Apellido"].ToString();
        //            DateTime fecha = Convert.ToDateTime(reader["FechaNacimiento"].ToString());
        //            string direccion = reader["Direccion"].ToString();
        //            list.Add(new Cliente(id, nombre, apellido, fecha, direccion));
        //        }
        //    }

        //    return list;
        //}

        public override List<Cliente> Leer(Type[] incluirRelaciones)
        {
            List<Cliente> clientes = base.Leer();
            if (clientes.Any())
            {
                MascotaDAO mascotaDAO = new MascotaDAO();
                TurnoDAO turnoDAO = new TurnoDAO();
                foreach (Cliente cliente in clientes)
                {
                    if (incluirRelaciones.Contains(typeof(Mascota)))
                    {
                        cliente.Mascotas = mascotaDAO.Leer(x => x.ClienteId == cliente.Dni);
                    }
                    if (incluirRelaciones.Contains(typeof(Turno)))
                    {
                        if (cliente.Mascotas is null || cliente.Mascotas.Count == 0)
                        {
                            cliente.Mascotas = mascotaDAO.Leer(x => x.ClienteId == cliente.Dni);
                        }
                        foreach (Mascota mascota in cliente.Mascotas)
                        {
                            mascota.Turnos = turnoDAO.Leer(x => x.MascotaId == mascota.Id);
                        }
                    }
                }
            }

            return clientes;
        }

        //public override Cliente LeerPorId(long id)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        string query = "SELECT * FROM Clientes WHERE Dni = @id";

        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("id", id);

        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            string nombre = reader["Nombre"].ToString();
        //            string apellido = reader["Apellido"].ToString();
        //            DateTime fecha = Convert.ToDateTime(reader["FechaNacimiento"].ToString());
        //            string direccion = reader["Direccion"].ToString();
        //            return new Cliente(id, nombre, apellido, fecha, direccion);
        //        }
        //    }

        //    throw new EntidadInexistenteException($"No existe cliente con dni: {id}");
        //}

        public override Cliente LeerPorId(long id, Type[] incluirRelaciones)
        {
            Cliente cliente = LeerPorId(id);
            if (incluirRelaciones.Contains(typeof(Mascota)))
            {
                cliente.Mascotas = new MascotaDAO().Leer(x => x.ClienteId == cliente.Id);
            }
            return cliente;
        }

        //public override void Modificar(Cliente entidad)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        string query = $"UPDATE {Tabla} SET Nombre = @nombre, Apellido = @apellido, FechaNacimiento = @nacimiento, Direccion = @direccion WHERE Dni = @id";

        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("id", entidad.Dni);
        //        command.Parameters.AddWithValue("nombre", entidad.Nombre);
        //        command.Parameters.AddWithValue("apellido", entidad.Apellido);
        //        command.Parameters.AddWithValue("nacimiento", entidad.FechaNacimiento);
        //        command.Parameters.AddWithValue("direccion", entidad.Direccion);
        //        command.ExecuteNonQuery();
        //    }

        //    if (OnNuevosDatos is not null)
        //    {
        //        OnNuevosDatos.Invoke();
        //    }
        //}

        protected override SqlCommand CrearCommandInsert(Cliente entidad)
        {
            string query = $"INSERT INTO {Tabla} (Dni, Nombre, Apellido, FechaNacimiento, Direccion, Activo) VALUES(@dni, @nombre, @apellido, @fecha, @direccion, @activo)";

            SqlCommand command = new SqlCommand(query);
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
            string query = $"UPDATE {Tabla} SET Dni = @dni, Nombre = @nombre, Apellido = @apellido, FechaNacimiento = @nacimiento, Direccion = @direccion, Activo = @activo WHERE Id = @id";

            SqlCommand command = new SqlCommand(query);
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
    }
}
