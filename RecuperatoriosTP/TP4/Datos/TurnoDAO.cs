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
            Turno turno = LeerPorId(id);
            if (incluirRelaciones.Contains(typeof(Mascota)))
            {
                turno.Mascota = new MascotaDAO().LeerPorId(turno.MascotaId);
            }
            return turno;
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
            StringBuilder query = new StringBuilder();
            query.AppendLine($"INSERT INTO {Tabla} (MascotaId, Fecha, HoraInicio, HoraFin, Comentario, EstadoTurnoId)");
            query.AppendLine("VALUES(@idMascota, @fecha, @horaInicio, @horaFin, @comentario, @estado)");
            query.AppendLine("SELECT CAST(@@IDENTITY AS BIGINT)");
            //string query = $"INSERT INTO {Tabla} (MascotaId, Fecha, HoraInicio, HoraFin, Comentario, EstadoTurnoId) VALUES(@idMascota, @fecha, @horaInicio, @horaFin, @comentario, @estado)";

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
            //string query = $"UPDATE {Tabla} SET MascotaId = @idMascota, Fecha = @fecha, HoraInicio = @horaInicio, HoraFin = @horaFin, Comentario = @comentario, EstadoTurnoId = @estado WHERE Id = @id";

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

        public List<InformacionTurno> ObtenerListadoDeTurnos(EstadoTurno estadoTurno)
        {
            List<InformacionTurno> list = new List<InformacionTurno>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                short? estadoTurnoId = estadoTurno?.Id;
                //string where = string.Empty;
                //if (estadoTurnoId.HasValue && estadoTurnoId.Value > 0)
                //{
                //    where = "AND T.EstadoTurnoId = @estado";
                //}

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
        /// 
        /// </summary>
        /// <returns></returns>
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
            //return new ProximoTurno(turno.Id, turno.Fecha, turno.HoraInicio, turno.HoraFin, turno.Mascota.Cliente.NombreCompleto, turno.Mascota.Nombre);
            return new ProximoTurno(turno);
        }

        public List<Tiempo> ObtenerHorariosDisponibles(DateTime fecha, out List<Tiempo> horariosNoDisponibles)
        {
            List<Tiempo> horariosDisponibles = new List<Tiempo>();
            List<Tiempo> horariosOcupados = new List<Tiempo>();
            List<Turno> turnosDelDia = Leer(turno => turno.Fecha == fecha.Date);
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
                        horariosOcupados.Add(new Tiempo(fechaDesde.GetHora()));
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
                horario = new Tiempo(horarioDelDia.GetHora());
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
