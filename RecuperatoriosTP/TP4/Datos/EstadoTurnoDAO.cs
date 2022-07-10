using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class EstadoTurnoDAO : BaseDAO<short, EstadoTurno>
    {
        protected override string Tabla => "EstadosTurno";

        public override List<EstadoTurno> Leer(Type[] incluirRelaciones)
        {
            throw new NotImplementedException();
        }

        public override EstadoTurno LeerPorId(short id, Type[] incluirRelaciones)
        {
            throw new NotImplementedException();
        }

        protected override SqlCommand CrearCommandInsert(EstadoTurno entidad)
        {
            throw new NotImplementedException();
        }

        protected override SqlCommand CrearCommandUpdate(EstadoTurno entidad)
        {
            throw new NotImplementedException();
        }

        protected override EstadoTurno ParseResultado(SqlDataReader reader)
        {
            short id = Convert.ToInt16(reader["Id"].ToString());
            string descripcion = reader["Descripcion"].ToString();

            return new EstadoTurno(id, descripcion);
        }
    }
}
