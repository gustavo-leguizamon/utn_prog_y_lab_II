using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    /// <summary>
    /// Clase encargada de administrar entidades de tipo Mascota
    /// 
    /// CLASE 12 - Tipos genericos
    /// 
    /// </summary>
    public class MascotaDAO : BaseDAO<long, Mascota>
    {
        protected override string Tabla => "Mascotas";

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
                    //CLASE 17 - Delegados y expresiones lambda
                    mascota.Turnos = new TurnoDAO().Leer(x => x.MascotaId == mascota.Id);
                }
            }

            return mascotas;
        }

        public override Mascota LeerPorId(long id, Type[] incluirRelaciones)
        {
            Mascota mascota = LeerPorId(id);
            if (incluirRelaciones.Contains(typeof(Turno)))
            {
                //CLASE 17 - Delegados y expresiones lambda
                mascota.Turnos = new TurnoDAO().Leer(x => x.MascotaId == mascota.Id);
            }
            return mascota;
        }

        protected override SqlCommand CrearCommandInsert(Mascota entidad)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine($"INSERT INTO {Tabla} (ClienteId, TipoMascotaId, Nombre, Peso, FechaNacimiento, Activo)");
            query.AppendLine("VALUES(@clienteId, @tipoId, @nombre, @peso, @fecha, @activo)");
            query.AppendLine("SELECT CAST(@@IDENTITY AS BIGINT)");

            SqlCommand command = new SqlCommand(query.ToString());
            command.Parameters.AddWithValue("clienteId", entidad.ClienteId);
            command.Parameters.AddWithValue("tipoId", (short)entidad.TipoMascota);
            command.Parameters.AddWithValue("nombre", entidad.Nombre);
            command.Parameters.AddWithValue("peso", entidad.Peso);
            command.Parameters.AddWithValue("fecha", entidad.FechaNacimiento);
            command.Parameters.AddWithValue("activo", entidad.Activo);

            return command;
        }

        protected override SqlCommand CrearCommandUpdate(Mascota entidad)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine($"UPDATE {Tabla} SET");
            query.AppendLine("ClienteId = @cliente,");
            query.AppendLine("TipoMascotaId = @tipoId,");
            query.AppendLine("Nombre = @nombre,");
            query.AppendLine("Peso = @peso,");
            query.AppendLine("FechaNacimiento = @nacimiento,");
            query.AppendLine("Activo = @activo");
            query.AppendLine("WHERE Id = @id");

            SqlCommand command = new SqlCommand(query.ToString());
            command.Parameters.AddWithValue("id", entidad.Id);
            command.Parameters.AddWithValue("cliente", entidad.ClienteId);
            command.Parameters.AddWithValue("tipoId", (short)entidad.TipoMascota);
            command.Parameters.AddWithValue("nombre", entidad.Nombre);
            command.Parameters.AddWithValue("peso", entidad.Peso);
            command.Parameters.AddWithValue("nacimiento", entidad.FechaNacimiento);
            command.Parameters.AddWithValue("activo", entidad.Activo);

            return command;
        }

        protected override Mascota ParseResultado(SqlDataReader reader)
        {
            long id = Convert.ToInt64(reader["Id"].ToString());
            long clienteId = Convert.ToInt64(reader["ClienteId"].ToString());
            short tipoMascotaId = Convert.ToInt16(reader["TipoMascotaId"].ToString());
            string nombre = reader["Nombre"].ToString();
            float peso = Convert.ToSingle(reader["Peso"].ToString());
            DateTime fecha = Convert.ToDateTime(reader["FechaNacimiento"].ToString());
            bool activo = Convert.ToBoolean(reader["Activo"]);

            return new Mascota(id, clienteId, (TipoMascota.eTipoMascota)tipoMascotaId, nombre, peso, fecha, activo);
        }
    }
}
