using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class TurnoDAO : BaseDAO<long, Turno>
    {
        protected override string Tabla => "Turnos";

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

        //public override void Guardar(Turno entidad)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        string query = $"INSERT INTO {Tabla} (IdMascota, Fecha, Comentario) VALUES(@idMascota, @fecha, @comentario)";

        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("idMascota", entidad.MascotaId);
        //        command.Parameters.AddWithValue("fecha", entidad.Fecha);
        //        command.Parameters.AddWithValue("comentario", entidad.Comentario);
        //        command.ExecuteNonQuery();
        //    }

        //    if (OnNuevosDatos is not null)
        //    {
        //        OnNuevosDatos.Invoke();
        //    }
        //}

        //public override List<Turno> Leer()
        //{
        //    List<Turno> list = new List<Turno>();
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        string query = "SELECT * FROM Turnos";

        //        SqlCommand command = new SqlCommand(query, connection);

        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            long id = Convert.ToInt64(reader["Id"].ToString());
        //            long idMascota = Convert.ToInt64(reader["IdMascota"].ToString());
        //            DateTime fecha = Convert.ToDateTime(reader["Fecha"].ToString());
        //            string comentario = reader["Comentario"].ToString();
        //            list.Add(new Turno(id, idMascota, fecha, comentario));
        //        }
        //    }

        //    return list;
        //}

        public override List<Turno> Leer(Type[] incluirRelaciones)
        {
            List<Turno> turnos = Leer();
            foreach (Turno turno in turnos)
            {
                if (incluirRelaciones.Contains(typeof(Mascota)))
                {
                    turno.Mascota = new MascotaDAO().LeerPorId(turno.MascotaId);
                }
            }

            return turnos;
        }

        //public override Turno LeerPorId(long id)
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
        //            long idMascota = Convert.ToInt64(reader["IdMascota"].ToString());
        //            DateTime fecha = Convert.ToDateTime(reader["Fecha"].ToString());
        //            string comentario = reader["Comentario"].ToString();
        //            return new Turno(id, idMascota, fecha, comentario);
        //        }
        //    }

        //    throw new EntidadInexistenteException($"No existe turno con id: {id}");
        //}

        public override Turno LeerPorId(long id, Type[] incluirRelaciones)
        {
            throw new NotImplementedException();
        }

        //public override void Modificar(Turno entidad)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        string query = $"UPDATE {Tabla} SET IdMascota = @idMascota, Fecha = @fecha, Comentario = @comentario WHERE Id = @id";

        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("id", entidad.Id);
        //        command.Parameters.AddWithValue("idMascota", entidad.MascotaId);
        //        command.Parameters.AddWithValue("fecha", entidad.Fecha);
        //        command.Parameters.AddWithValue("comentario", entidad.Comentario);
        //        command.ExecuteNonQuery();
        //    }

        //    if (OnNuevosDatos is not null)
        //    {
        //        OnNuevosDatos.Invoke();
        //    }
        //}

        protected override SqlCommand CrearCommandInsert(Turno entidad)
        {
            string query = $"INSERT INTO {Tabla} (IdMascota, Fecha, Comentario) VALUES(@idMascota, @fecha, @comentario)";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("idMascota", entidad.MascotaId);
            command.Parameters.AddWithValue("fecha", entidad.Fecha);
            command.Parameters.AddWithValue("comentario", entidad.Comentario);

            return command;
        }

        protected override SqlCommand CrearCommandUpdate(Turno entidad)
        {
            string query = $"UPDATE {Tabla} SET MascotaId = @idMascota, Fecha = @fecha, Comentario = @comentario WHERE Id = @id";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("id", entidad.Id);
            command.Parameters.AddWithValue("idMascota", entidad.MascotaId);
            command.Parameters.AddWithValue("fecha", entidad.Fecha);
            command.Parameters.AddWithValue("comentario", entidad.Comentario);

            return command;
        }

        protected override Turno ParseResultado(SqlDataReader reader)
        {
            long id = Convert.ToInt64(reader["Id"].ToString());
            long mascotaId = Convert.ToInt64(reader["MascotaId"].ToString());
            DateTime fecha = Convert.ToDateTime(reader["Fecha"].ToString());
            string comentario = reader["Comentario"].ToString();

            return new Turno(id, mascotaId, fecha, comentario);
        }
    }
}
