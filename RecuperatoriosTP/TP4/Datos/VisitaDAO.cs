using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class VisitaDAO : BaseDAO<long, Visita>
    {
        protected override string Tabla => "Visitas";

        public override List<Visita> Leer(Type[] incluirRelaciones)
        {
            throw new NotImplementedException();
        }

        public override Visita LeerPorId(long id, Type[] incluirRelaciones)
        {
            throw new NotImplementedException();
        }

        protected override SqlCommand CrearCommandInsert(Visita entidad)
        {
            string query = $"INSERT INTO {Tabla} (MascotaId, Llegada, Salida, PesoActual, Observacion) VALUES(@idMascota, @llegada, @salida, @pesoActual, @observacion)";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("idMascota", entidad.MascotaId);
            command.Parameters.AddWithValue("llegada", entidad.Llegada);
            command.Parameters.AddWithValue("salida", entidad.Salida);
            command.Parameters.AddWithValue("pesoActual", entidad.PesoActual);
            command.Parameters.AddWithValue("observacion", entidad.Observacion);

            return command;
        }

        protected override SqlCommand CrearCommandUpdate(Visita entidad)
        {
            string query = $"UPDATE {Tabla} SET MascotaId = @idMascota, Llegada = @llegada, Salida = @salida, PesoActual = @pesoActual, Observacion = @observacion WHERE Id = @id";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("id", entidad.Id);
            command.Parameters.AddWithValue("idMascota", entidad.MascotaId);
            command.Parameters.AddWithValue("llegada", entidad.Llegada);
            command.Parameters.AddWithValue("salida", entidad.Salida);
            command.Parameters.AddWithValue("pesoActual", entidad.PesoActual);
            command.Parameters.AddWithValue("observacion", entidad.Observacion);

            return command;
        }

        protected override Visita ParseResultado(SqlDataReader reader)
        {
            long id = Convert.ToInt64(reader["Id"].ToString());
            long mascotaId = Convert.ToInt64(reader["MascotaId"].ToString());
            DateTime llegada = Convert.ToDateTime(reader["Llegada"].ToString());
            DateTime salida = Convert.ToDateTime(reader["Salida"].ToString());
            float pesoActual = Convert.ToSingle(reader["PesoActual"].ToString());
            string observacion = reader["Observacion"].ToString();

            return new Visita(id, mascotaId, llegada, salida, pesoActual, observacion);
        }
    }
}
