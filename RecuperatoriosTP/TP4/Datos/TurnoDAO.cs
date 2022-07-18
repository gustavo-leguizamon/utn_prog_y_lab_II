using Datos.Exceptions;
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
    /// Clase encargada de administrar entidades de tipo Turno
    /// 
    /// CLASE 12 - Tipos genericos
    /// 
    /// </summary>
    public class TurnoDAO : BaseDAO<long, Turno>
    {
        protected override string Tabla => "Turnos";

        public override List<Turno> Leer(Type[] incluirRelaciones)
        {
            List<Turno> turnos = Leer();
            foreach (Turno turno in turnos)
            {
                if (incluirRelaciones.Contains(typeof(Mascota)))
                {
                    turno.Mascota = new MascotaDAO().LeerPorId(turno.MascotaId);
                }
                if (incluirRelaciones.Contains(typeof(Cliente)))
                {
                    if (turno.Mascota is null)
                    {
                        turno.Mascota = new MascotaDAO().LeerPorId(turno.MascotaId);
                    }
                    turno.Mascota.Cliente = new ClienteDAO().LeerPorId(turno.Mascota.ClienteId);
                }
            }

            return turnos;
        }

        public override Turno LeerPorId(long id, Type[] incluirRelaciones)
        {
            Turno turno = LeerPorId(id);
            if (incluirRelaciones.Contains(typeof(Mascota)))
            {
                turno.Mascota = new MascotaDAO().LeerPorId(turno.MascotaId);
            }
            return turno;
        }

        protected override SqlCommand CrearCommandInsert(Turno entidad)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine($"INSERT INTO {Tabla} (MascotaId, Fecha, HoraInicio, HoraFin, Comentario, EstadoTurnoId)");
            query.AppendLine("VALUES(@idMascota, @fecha, @horaInicio, @horaFin, @comentario, @estado)");
            query.AppendLine("SELECT CAST(@@IDENTITY AS BIGINT)");

            SqlCommand command = new SqlCommand(query.ToString());
            command.Parameters.AddWithValue("idMascota", entidad.MascotaId);
            command.Parameters.AddWithValue("fecha", entidad.Fecha);
            command.Parameters.AddWithValue("horaInicio", entidad.HoraInicio);
            command.Parameters.AddWithValue("horaFin", entidad.HoraFin);
            command.Parameters.AddWithValue("comentario", entidad.Comentario);
            command.Parameters.AddWithValue("estado", (short)EstadoTurno.eEstadoTurno.Vigente);

            return command;
        }

        protected override SqlCommand CrearCommandUpdate(Turno entidad)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine($"UPDATE {Tabla} SET");
            query.AppendLine("MascotaId = @idMascota,");
            query.AppendLine("Fecha = @fecha,");
            query.AppendLine("HoraInicio = @horaInicio,");
            query.AppendLine("HoraFin = @horaFin,");
            query.AppendLine("Comentario = @comentario,");
            query.AppendLine("EstadoTurnoId = @estado");
            query.AppendLine("WHERE Id = @id");

            SqlCommand command = new SqlCommand(query.ToString());
            command.Parameters.AddWithValue("id", entidad.Id);
            command.Parameters.AddWithValue("idMascota", entidad.MascotaId);
            command.Parameters.AddWithValue("fecha", entidad.Fecha);
            command.Parameters.AddWithValue("horaInicio", entidad.HoraInicio);
            command.Parameters.AddWithValue("horaFin", entidad.HoraFin);
            command.Parameters.AddWithValue("comentario", entidad.Comentario);
            command.Parameters.AddWithValue("estado", entidad.EstadoTurnoId);

            return command;
        }

        protected override Turno ParseResultado(SqlDataReader reader)
        {
            long id = Convert.ToInt64(reader["Id"].ToString());
            long mascotaId = Convert.ToInt64(reader["MascotaId"].ToString());
            short estadoTurnoId = Convert.ToInt16(reader["EstadoTurnoId"].ToString());
            DateTime fecha = Convert.ToDateTime(reader["Fecha"].ToString());
            string horaInicio = reader["HoraInicio"].ToString();
            string horaFin = reader["HoraFin"].ToString();
            string comentario = reader["Comentario"].ToString();

            return new Turno(id, estadoTurnoId, mascotaId, fecha, horaInicio, horaFin, comentario);
        }

        /// <summary>
        /// Busca los turnos que coincidan con el estado pasado por parametro, o si no se especifica un estado, busca todos los turnos de la base de datos
        /// </summary>
        /// <param name="estadoTurno">Estado del turno</param>
        /// <returns>Listado de turnos que coincidan con el estado</returns>
        public List<InformacionTurno> ObtenerListadoDeTurnos(EstadoTurno estadoTurno)
        {
            List<InformacionTurno> list = new List<InformacionTurno>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                short? estadoTurnoId = estadoTurno?.Id;

                string query = @"SELECT 
                                T.Id AS 'NroTurno', T.Fecha, T.Comentario, ET.Id AS 'EstadoTurnoId',
                                ET.Descripcion AS 'Estado', C.Dni, C.Apellido + ' ' + C.Nombre AS 'Cliente', M.Nombre AS 'Mascota'
                                FROM Turnos T JOIN Mascotas     M  ON T.MascotaId = M.Id
                                              JOIN EstadosTurno ET ON T.EstadoTurnoId = ET.Id
			                                  JOIN Clientes     C  ON M.ClienteId = C.Id
                                WHERE (@estado IS NULL OR @estado = 0 OR T.EstadoTurnoId = @estado)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("estado", estadoTurnoId);

                SqlDataReader reader = command.ExecuteReader();
                long nroTurno;
                DateTime fecha;
                string comentario;
                short estadoId;
                string estado;
                string cliente;
                string mascota;
                while (reader.Read())
                {
                    nroTurno = Convert.ToInt64(reader["NroTurno"].ToString());
                    fecha = Convert.ToDateTime(reader["Fecha"].ToString());
                    comentario = reader["Comentario"].ToString();
                    estadoId = Convert.ToInt16(reader["EstadoTurnoId"].ToString());
                    estado = reader["Estado"].ToString();
                    cliente = reader["Cliente"].ToString();
                    mascota = reader["Mascota"].ToString();
                    InformacionTurno informacionTurno = new InformacionTurno(nroTurno, fecha, comentario, estadoId, estado, cliente, mascota);
                    list.Add(informacionTurno);
                }
            }

            return list;
        }

        /// <summary>
        /// Cambia el estado de un turno
        /// </summary>
        /// <param name="turnoId">ID del turno</param>
        /// <param name="estadoTurno">Nuevo estado a colocar</param>
        public void CambiarEstado(long turnoId, EstadoTurno.eEstadoTurno estadoTurno)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                
                string query = $"UPDATE {Tabla} SET EstadoTurnoId = @estadoId WHERE Id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", turnoId);
                command.Parameters.AddWithValue("estadoId", (short)estadoTurno);
                command.ExecuteNonQuery();
            }

            InvocarActualizacionDatos();
        }

        /// <summary>
        /// Busca el proximo turno mas cercano a la fecha actual
        /// 
        /// CLASE 10 - Excepciones
        /// CLASE 17 - Delegados y expresiones lambda
        /// 
        /// </summary>
        /// <returns>Objeto con informacion del proximo turno</returns>
        /// <exception cref="NoHayMasTurnosException">Lanzada cuando no hay más turnos en adelante</exception>
        public ProximoTurno ProximoTurno()
        {
            DateTime fechaActual = DateTime.Now;
            List<Turno> vigentes = Leer(turno => turno.EstadoTurnoId == (short)EstadoTurno.eEstadoTurno.Vigente && turno.Fecha >= fechaActual, new Type[] { typeof(Mascota), typeof(Cliente) });
            if (!vigentes.Any())
            {
                throw new NoHayMasTurnosException("No hay próximos turnos");
            }
            Turno turno = vigentes.OrderBy(turno => turno.Fecha).ToList().First();
            return new ProximoTurno(turno);
        }

        /// <summary>
        /// Busca entre los turnos ya otorgados, los horarios disponibles para nuevos turnos
        /// 
        /// CLASE 17 - Delegados y expresiones lambda
        /// 
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="horariosNoDisponibles"></param>
        /// <returns></returns>
        public List<Tiempo> ObtenerHorariosDisponibles(DateTime fecha, out List<Tiempo> horariosNoDisponibles)
        {
            List<Tiempo> horariosDisponibles = new List<Tiempo>();
            List<Tiempo> horariosOcupados = new List<Tiempo>();
            List<Turno> turnosDelDia = Leer(turno => turno.Fecha == fecha.Date && turno.EstadoTurnoId != (short)EstadoTurno.eEstadoTurno.Cancelado);
            if (turnosDelDia.Any())
            {
                foreach (Turno turno in turnosDelDia.OrderBy(t => t.HoraInicio))
                {
                    Tiempo horaInicio = new Tiempo(turno.HoraInicio);
                    DateTime fechaDesde = new DateTime(turno.Fecha.Year, turno.Fecha.Month, turno.Fecha.Day, horaInicio.Hora, horaInicio.Minuto, 0);
                    Tiempo horaFin = new Tiempo(turno.HoraFin);
                    DateTime fechaHasta = new DateTime(turno.Fecha.Year, turno.Fecha.Month, turno.Fecha.Day, horaFin.Hora, horaFin.Minuto, 0);

                    do
                    {
                        horariosOcupados.Add(new Tiempo(fechaDesde.GetHora())); //CLASE 20 - Metodos de extension
                        fechaDesde = fechaDesde.AddMinutes(30);
                    } 
                    while (fechaDesde < fechaHasta);
                }
            }

            Tiempo horario;
            DateTime horarioDelDia = DateTime.Now;
            if (fecha.Date > horarioDelDia.Date)
                horarioDelDia = fecha;
            DateTime proximoDia = horarioDelDia.AddDays(1).Date;
            if (horarioDelDia.Date == DateTime.Today)
            {
                if (horarioDelDia.Minute >= 30)
                {
                    horarioDelDia = new DateTime(horarioDelDia.Year, horarioDelDia.Month, horarioDelDia.Day, horarioDelDia.Hour == 23 ? 0 : horarioDelDia.Hour + 1, 0, 0);
                }
                else
                {
                    horarioDelDia = new DateTime(horarioDelDia.Year, horarioDelDia.Month, horarioDelDia.Day, horarioDelDia.Hour, 30, 0);
                }
            }

            do
            {
                horario = new Tiempo(horarioDelDia.GetHora()); //CLASE 20 - Metodos de extension
                if (!horariosOcupados.Any(ocupado => ocupado == horario))
                {
                    horariosDisponibles.Add(horario);
                }
                horarioDelDia = horarioDelDia.AddMinutes(30);
            }
            while (horarioDelDia < proximoDia);

            horariosNoDisponibles = horariosOcupados;

            return horariosDisponibles;
        }
    }
}
