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
        public delegate void DelegadoActualizacionDatosHandler();

        public event DelegadoActualizacionDatosHandler OnNuevosDatos;

        public override void Eliminar(long id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM Clientes WHERE Dni = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
            }

            if (OnNuevosDatos is not null)
            {
                OnNuevosDatos.Invoke();
            }
        }

        public override void Guardar(Cliente entidad)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "INSERT INTO Clientes (Dni, Nombre, Apellido, FechaNacimiento, Direccion) VALUES(@dni, @nombre, @apellido, @fecha, @direccion)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("dni", entidad.Dni);
                command.Parameters.AddWithValue("nombre", entidad.Nombre);
                command.Parameters.AddWithValue("apellido", entidad.Apellido);
                command.Parameters.AddWithValue("fecha", entidad.FechaNacimiento);
                command.Parameters.AddWithValue("direccion", entidad.Direccion);
                command.ExecuteNonQuery();
            }

            if (OnNuevosDatos is not null)
            {
                OnNuevosDatos.Invoke();
            }
        }

        public override List<Cliente> Leer()
        {
            List<Cliente> list = new List<Cliente>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Clientes";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    long id = Convert.ToInt64(reader["Dni"].ToString());
                    string nombre = reader["Nombre"].ToString();
                    string apellido = reader["Apellido"].ToString();
                    DateTime fecha = Convert.ToDateTime(reader["FechaNacimiento"].ToString());
                    string direccion = reader["Direccion"].ToString();
                    list.Add(new Cliente(id, nombre, apellido, fecha, direccion));
                }
            }

            return list;
        }

        public override List<Cliente> Leer(Type[] incluirRelaciones)
        {
            List<Cliente> clientes = Leer();
            foreach (Cliente cliente in clientes)
            {
                if (incluirRelaciones.Contains(typeof(Mascota)))
                {
                    cliente.Mascotas = new MascotaDAO().Leer();
                }
            }

            return clientes;
        }

        public override List<Cliente> Leer(Func<Cliente, bool> predicate)
        {
            return Leer().Where(predicate).ToList();
        }

        public override Cliente LeerPorId(long id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Clientes WHERE Dni = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string nombre = reader["Nombre"].ToString();
                    string apellido = reader["Apellido"].ToString();
                    DateTime fecha = Convert.ToDateTime(reader["FechaNacimiento"].ToString());
                    string direccion = reader["Direccion"].ToString();
                    return new Cliente(id, nombre, apellido, fecha, direccion);
                }
            }

            throw new EntidadInexistenteException($"No existe cliente con dni: {id}");
        }

        public override Cliente LeerPorId(long id, Type[] incluirRelaciones)
        {
            Cliente cliente = LeerPorId(id);
            if (incluirRelaciones.Contains(typeof(Mascota)))
            {
                cliente.Mascotas = new MascotaDAO().Leer(x => x.DniCliente == cliente.Dni);
            }
            return cliente;
        }

        public override void Modificar(Cliente entidad)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "UPDATE Clientes SET Nombre = @nombre, Apellido = @apellido, FechaNacimiento = @nacimiento, Direccion = @direccion WHERE Dni = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", entidad.Dni);
                command.Parameters.AddWithValue("nombre", entidad.Nombre);
                command.Parameters.AddWithValue("apellido", entidad.Apellido);
                command.Parameters.AddWithValue("nacimiento", entidad.FechaNacimiento);
                command.Parameters.AddWithValue("direccion", entidad.Direccion);
                command.ExecuteNonQuery();
            }

            if (OnNuevosDatos is not null)
            {
                OnNuevosDatos.Invoke();
            }
        }
    }
}
