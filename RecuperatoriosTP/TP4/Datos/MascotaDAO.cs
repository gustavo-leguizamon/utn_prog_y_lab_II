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
        protected override string Tabla => "Mascotas";

        //public delegate void DelegadoActualizacionDatosHandler();

        //public event DelegadoActualizacionDatosHandler OnNuevosDatos;

        //public override void Eliminar(long id)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        string query = $"DELETE FROM {Tabla} WHERE Id = @id";

        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("id", id);
        //        command.ExecuteNonQuery();
        //    }

        //    if (OnNuevosDatos is not null)
        //    {
        //        OnNuevosDatos.Invoke();
        //    }
        //}

        //public override void Guardar(Mascota entidad)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        string query = $"INSERT INTO {Tabla} (DniCliente, Nombre, Peso, FechaNacimiento) VALUES(@dni, @nombre, @peso, @fecha)";

        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("dni", entidad.ClienteId);
        //        command.Parameters.AddWithValue("nombre", entidad.Nombre);
        //        command.Parameters.AddWithValue("peso", entidad.Peso);
        //        command.Parameters.AddWithValue("fecha", entidad.FechaNacimiento);
        //        command.ExecuteNonQuery();
        //    }

        //    if (OnNuevosDatos is not null)
        //    {
        //        OnNuevosDatos.Invoke();
        //    }
        //}

        //public override List<Mascota> Leer()
        //{
        //    List<Mascota> list = new List<Mascota>();
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        string query = "SELECT * FROM Mascotas";

        //        SqlCommand command = new SqlCommand(query, connection);

        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            long id = Convert.ToInt64(reader["Id"].ToString());
        //            long dni = Convert.ToInt64(reader["DniCliente"].ToString());
        //            string nombre = reader["Nombre"].ToString();
        //            float peso = Convert.ToSingle(reader["Peso"].ToString());
        //            DateTime fecha = Convert.ToDateTime(reader["FechaNacimiento"].ToString());
        //            list.Add(new Mascota(id, dni, nombre, peso, fecha));
        //        }
        //    }

        //    return list;
        //}

        public override List<Mascota> Leer(Type[] incluirRelaciones)
        {
            List<Mascota> mascotas = Leer();
            foreach (Mascota mascota in mascotas)
            {
                if (incluirRelaciones.Contains(typeof(Cliente)))
                {
                    mascota.Cliente = new ClienteDAO().LeerPorId(mascota.ClienteId);
                }
                if (incluirRelaciones.Contains(typeof(Turno)))
                {
                    mascota.Turnos = new TurnoDAO().Leer(x => x.MascotaId == mascota.Id);
                }
            }

            return mascotas;
        }

        //public override Mascota LeerPorId(long id)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        string query = $"SELECT * FROM {Tabla} WHERE Id = @id";

        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("id", id);

        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            long dni = Convert.ToInt64(reader["DniCliente"].ToString());
        //            string nombre = reader["Nombre"].ToString();
        //            float peso = Convert.ToSingle(reader["Peso"].ToString());
        //            DateTime fecha = Convert.ToDateTime(reader["FechaNacimiento"].ToString());
        //            return new Mascota(id, dni, nombre, peso, fecha);
        //        }
        //    }

        //    throw new EntidadInexistenteException($"No existe mascota con id: {id}");
        //}

        public override Mascota LeerPorId(long id, Type[] incluirRelaciones)
        {
            Mascota mascota = LeerPorId(id);
            if (incluirRelaciones.Contains(typeof(Turno)))
            {
                mascota.Turnos = new TurnoDAO().Leer(x => x.MascotaId == mascota.Id);
            }
            return mascota;
        }

        //public override void Modificar(Mascota entidad)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        string query = $"UPDATE {Tabla} SET DniCliente, @cliente, Nombre = @nombre, Peso = @peso, FechaNacimiento = @nacimiento WHERE Id = @id";

        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("id", entidad.Id);
        //        command.Parameters.AddWithValue("cliente", entidad.ClienteId);
        //        command.Parameters.AddWithValue("nombre", entidad.Nombre);
        //        command.Parameters.AddWithValue("peso", entidad.Peso);
        //        command.Parameters.AddWithValue("nacimiento", entidad.FechaNacimiento);
        //        command.ExecuteNonQuery();
        //    }

        //    if (OnNuevosDatos is not null)
        //    {
        //        OnNuevosDatos.Invoke();
        //    }
        //}

        protected override SqlCommand CrearCommandInsert(Mascota entidad)
        {
            string query = $"INSERT INTO {Tabla} (DniCliente, Nombre, Peso, FechaNacimiento) VALUES(@dni, @nombre, @peso, @fecha)";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("dni", entidad.ClienteId);
            command.Parameters.AddWithValue("nombre", entidad.Nombre);
            command.Parameters.AddWithValue("peso", entidad.Peso);
            command.Parameters.AddWithValue("fecha", entidad.FechaNacimiento);

            return command;
        }

        protected override SqlCommand CrearCommandUpdate(Mascota entidad)
        {
            string query = $"UPDATE {Tabla} SET ClienteId, @cliente, Nombre = @nombre, Peso = @peso, FechaNacimiento = @nacimiento WHERE Id = @id";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("id", entidad.Id);
            command.Parameters.AddWithValue("cliente", entidad.ClienteId);
            command.Parameters.AddWithValue("nombre", entidad.Nombre);
            command.Parameters.AddWithValue("peso", entidad.Peso);
            command.Parameters.AddWithValue("nacimiento", entidad.FechaNacimiento);

            return command;
        }

        protected override Mascota ParseResultado(SqlDataReader reader)
        {
            long id = Convert.ToInt64(reader["Id"].ToString());
            long clienteId = Convert.ToInt64(reader["ClienteId"].ToString());
            string nombre = reader["Nombre"].ToString();
            float peso = Convert.ToSingle(reader["Peso"].ToString());
            DateTime fecha = Convert.ToDateTime(reader["FechaNacimiento"].ToString());

            return new Mascota(id, clienteId, nombre, peso, fecha);
        }
    }
}
