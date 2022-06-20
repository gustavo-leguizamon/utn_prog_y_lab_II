using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class MascotaDAO : BaseDAO<long, Mascota>
    {
        public delegate void DelegadoActualizacionDatosHandler();

        public event DelegadoActualizacionDatosHandler OnNuevosDatos;

        public override void Eliminar(long id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM Mascotas WHERE Id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
            }

            if (OnNuevosDatos is not null)
            {
                OnNuevosDatos.Invoke();
            }
        }

        public override void Guardar(Mascota entidad)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "INSERT INTO Mascotas (DniCliente, Nombre, Peso, FechaNacimiento) VALUES(@dni, @nombre, @peso, @fecha)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("dni", entidad.DniCliente);
                command.Parameters.AddWithValue("nombre", entidad.Nombre);
                command.Parameters.AddWithValue("peso", entidad.Peso);
                command.Parameters.AddWithValue("fecha", entidad.FechaNacimiento);
                command.ExecuteNonQuery();
            }

            if (OnNuevosDatos is not null)
            {
                OnNuevosDatos.Invoke();
            }
        }

        public override List<Mascota> Leer()
        {
            List<Mascota> list = new List<Mascota>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Mascotas";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    long id = Convert.ToInt64(reader["Id"].ToString());
                    long dni = Convert.ToInt64(reader["DniCliente"].ToString());
                    string nombre = reader["Nombre"].ToString();
                    float peso = Convert.ToSingle(reader["Peso"].ToString());
                    DateTime fecha = Convert.ToDateTime(reader["FechaNacimiento"].ToString());
                    list.Add(new Mascota(id, dni, nombre, peso, fecha));
                }
            }

            return list;
        }

        public override List<Mascota> Leer(Type[] incluirRelaciones)
        {
            throw new NotImplementedException();
        }

        public override List<Mascota> Leer(Func<Mascota, bool> predicate)
        {
            return Leer().Where(predicate).ToList();
        }

        public override Mascota LeerPorId(long id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Mascotas WHERE Id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    long dni = Convert.ToInt64(reader["DniCliente"].ToString());
                    string nombre = reader["Nombre"].ToString();
                    float peso = Convert.ToSingle(reader["Peso"].ToString());
                    DateTime fecha = Convert.ToDateTime(reader["FechaNacimiento"].ToString());
                    return new Mascota(id, dni, nombre, peso, fecha);
                }
            }

            throw new EntidadInexistenteException($"No existe mascota con id: {id}");
        }

        public override Mascota LeerPorId(long id, Type[] incluirRelaciones)
        {
            throw new NotImplementedException();
        }

        public override void Modificar(Mascota entidad)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "UPDATE Mascotas SET DniCliente, @cliente, Nombre = @nombre, Peso = @peso, FechaNacimiento = @nacimiento WHERE Id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", entidad.Id);
                command.Parameters.AddWithValue("cliente", entidad.DniCliente);
                command.Parameters.AddWithValue("nombre", entidad.Nombre);
                command.Parameters.AddWithValue("peso", entidad.Peso);
                command.Parameters.AddWithValue("nacimiento", entidad.FechaNacimiento);
                command.ExecuteNonQuery();
            }

            if (OnNuevosDatos is not null)
            {
                OnNuevosDatos.Invoke();
            }
        }
    }
}
