using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    public abstract class BaseDAO<ID, E>
        where E : class
    {
        protected static string ConnectionString;

        static BaseDAO()
        {
            BaseDAO<ID, E>.ConnectionString = @"Server=.\SQLEXPRESS;Database=Veterinaria;Trusted_Connection=True;";
        }

        public abstract void Guardar(E entidad);
        public virtual void Guardar(List<E> entidades)
        {
            foreach (E entidad in entidades)
            {
                Guardar(entidad);
            }
        }

        public abstract List<E> Leer();

        public virtual List<E> Leer(Func<E, bool> predicate)
        {
            return Leer().Where(predicate).ToList();
        }
        public abstract List<E> Leer(Type[] incluirRelaciones);

        public abstract E LeerPorId(ID id);
        public abstract E LeerPorId(ID id, Type[] incluirRelaciones);

        public abstract void Modificar(E entidad);

        public abstract void Eliminar(ID id);

        public virtual bool Existe(ID id)
        {
            return LeerPorId(id) is not null;
        }

        public virtual T Max<T>(Func<E, T> predicate)
        {
            return Leer().Max(predicate);
        }
    }
}
