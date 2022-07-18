using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.Extensions;

namespace Datos
{
    /// <summary>
    /// Clase encargada de administrar entidades de tipo Atencion
    /// 
    /// CLASE 12 - Tipos genericos
    /// 
    /// </summary>
    public class AtencionDAO : BaseDAO<long, Atencion>
    {
        protected override string Tabla => "Atenciones";

        public override List<Atencion> Leer(Type[] incluirRelaciones)
        {
            throw new NotImplementedException();
        }

        public override Atencion LeerPorId(long id, Type[] incluirRelaciones)
        {
            throw new NotImplementedException();
        }

        protected override SqlCommand CrearCommandInsert(Atencion entidad)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine($"INSERT INTO {Tabla} (MascotaId, Llegada, Salida, PesoActual, Observacion)");
            query.AppendLine("VALUES (@idMascota, @llegada, @salida, @pesoActual, @observacion)");
            query.AppendLine("SELECT CAST(@@IDENTITY AS BIGINT)");

            SqlCommand command = new SqlCommand(query.ToString());
            command.Parameters.AddWithValue("idMascota", entidad.MascotaId);
            command.Parameters.AddWithValue("llegada", entidad.Llegada);
            command.Parameters.AddWithValue("salida", entidad.Salida);
            command.Parameters.AddWithValue("pesoActual", entidad.PesoActual);
            command.Parameters.AddWithValue("observacion", entidad.Observacion);

            return command;
        }

        protected override SqlCommand CrearCommandUpdate(Atencion entidad)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine($"UPDATE {Tabla} SET");
            query.AppendLine("MascotaId = @idMascota,");
            query.AppendLine("Llegada = @llegada,");
            query.AppendLine("Salida = @salida,");
            query.AppendLine("PesoActual = @pesoActual,");
            query.AppendLine("Observacion = @observacion");
            query.AppendLine("WHERE Id = @id");

            SqlCommand command = new SqlCommand(query.ToString());
            command.Parameters.AddWithValue("id", entidad.Id);
            command.Parameters.AddWithValue("idMascota", entidad.MascotaId);
            command.Parameters.AddWithValue("llegada", entidad.Llegada);
            command.Parameters.AddWithValue("salida", entidad.Salida);
            command.Parameters.AddWithValue("pesoActual", entidad.PesoActual);
            command.Parameters.AddWithValue("observacion", entidad.Observacion);

            return command;
        }

        protected override Atencion ParseResultado(SqlDataReader reader)
        {
            long id = Convert.ToInt64(reader["Id"].ToString());
            long mascotaId = Convert.ToInt64(reader["MascotaId"].ToString());
            DateTime llegada = Convert.ToDateTime(reader["Llegada"].ToString());
            DateTime salida = Convert.ToDateTime(reader["Salida"].ToString());
            float pesoActual = Convert.ToSingle(reader["PesoActual"].ToString());
            string observacion = reader["Observacion"].ToString();

            return new Atencion(id, mascotaId, llegada, salida, pesoActual, observacion);
        }

        /// <summary>
        /// Buscar el registro de las atenciones realizadas a la mascotas en un rango de fechas
        /// </summary>
        /// <param name="fechaDesde">Fecha de inicio</param>
        /// <param name="fechaHasta">Fecha de fin</param>
        /// <returns>Listado de los registros de atenciones dentro del rango de fechas</returns>
        public List<InformacionDeAtencion> ObtenerRegistroDeAtenciones(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<InformacionDeAtencion> list = new List<InformacionDeAtencion>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = @"SELECT
                                C.Apellido + ' ' + C.Nombre AS 'Cliente', C.Dni,
                                M.Nombre AS 'Mascota', T.Tipo AS 'TipoMascota', A.Observacion,
                                A.Llegada, A.Salida
                                FROM Atenciones A JOIN Mascotas M ON A.MascotaId = M.Id
                                                  JOIN Clientes C ON M.ClienteId = C.Id
				                                  JOIN TiposMascota T ON M.TipoMascotaId = T.Id
                                WHERE A.Llegada BETWEEN @fechaDesde AND @fecaHasta";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("fechaDesde", fechaDesde.Date);
                command.Parameters.AddWithValue("fecaHasta", fechaHasta.Date.AddDays(1).AddSeconds(-1));

                SqlDataReader reader = command.ExecuteReader();
                string cliente;
                long dni;
                string mascota;
                string tipoMascota;
                string observacion;
                DateTime llegada;
                DateTime salida;
                while (reader.Read())
                {
                    cliente = reader["Cliente"].ToString();
                    dni = Convert.ToInt64(reader["Dni"].ToString());
                    mascota = reader["Mascota"].ToString();
                    tipoMascota = reader["TipoMascota"].ToString();
                    observacion = reader["Observacion"].ToString();
                    llegada = Convert.ToDateTime(reader["Llegada"].ToString());
                    salida = Convert.ToDateTime(reader["Salida"].ToString());

                    list.Add(new InformacionDeAtencion(cliente, dni, mascota, tipoMascota, observacion, llegada, salida));
                }
            }

            return list;
        }
    }
}
