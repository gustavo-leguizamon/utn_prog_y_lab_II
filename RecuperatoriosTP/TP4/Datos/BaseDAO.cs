using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    /// <summary>
    /// Clase base para conectar con la base de datos
    /// </summary>
    /// <typeparam name="TID">Tipo de dato del ID de la tabla</typeparam>
    /// <typeparam name="E">Tipo de dato de la entidad</typeparam>
    public abstract class BaseDAO<TID, E>
        where E : class
    {
        protected static string ConnectionString;

        static BaseDAO()
        {
            BaseDAO<TID, E>.ConnectionString = @"Server=.\SQLEXPRESS;Database=Veterinaria;Trusted_Connection=True;";
        }

        /// <summary>
        /// Almacena los datos de una entidad en la BD
        /// </summary>
        /// <param name="entidad"></param>
        public abstract void Guardar(E entidad);

        /// <summary>
        /// Almacena los datos de multiples entidades en la BD
        /// </summary>
        /// <param name="entidades"></param>
        public virtual void Guardar(List<E> entidades)
        {
            foreach (E entidad in entidades)
            {
                Guardar(entidad);
            }
        }

        /// <summary>
        /// Devuelve todas la entidades almacenadas en la BD
        /// </summary>
        /// <returns></returns>
        public abstract List<E> Leer();

        /// <summary>
        /// Devuelve todas la entidades almacenadas en la BD que cumplan con la condicion especificada
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual List<E> Leer(Func<E, bool> predicate)
        {
            return Leer().Where(predicate).ToList();
        }

        /// <summary>
        /// Devuelve todas la entidades almacenadas en la BD, ademas le agregas las tablas relacionadas que se especifiquen
        /// </summary>
        /// <param name="incluirRelaciones"></param>
        /// <returns></returns>
        public abstract List<E> Leer(Type[] incluirRelaciones);

        /// <summary>
        /// Devuelve una entidad que coincida con el ID especificado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract E LeerPorId(TID id);

        /// <summary>
        /// /// Devuelve una entidad que coincida con el ID especificado, ademas le agrega las tablas relacionadas que se especifiquen
        /// </summary>
        /// <param name="id"></param>
        /// <param name="incluirRelaciones"></param>
        /// <returns></returns>
        public abstract E LeerPorId(TID id, Type[] incluirRelaciones);

        /// <summary>
        /// Actualiza los datos de una entidad en la BD
        /// </summary>
        /// <param name="entidad"></param>
        public abstract void Modificar(E entidad);

        /// <summary>
        /// Elimina una entidad de la BD por medio de su ID
        /// </summary>
        /// <param name="id"></param>
        public abstract void Eliminar(TID id);

        /// <summary>
        /// Verifica si existe una entidad con el ID especificado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Existe(TID id)
        {
            return LeerPorId(id) is not null;
        }

        /// <summary>
        /// Devuelve el valor mas bajo para la columna de la entidad especificada
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Lanzada si no hay datos para evaluar</exception>
        public virtual T Min<T>(Func<E, T> predicate)
        {
            List<E> lista = Leer();
            if (lista.Any())
            {
                return lista.Min(predicate);
            }
            throw new InvalidOperationException("No hay datos para evaluar la condicion");
        }

        /// <summary>
        /// Devuelve el valor mas alto para la columna de la entidad especificada
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Lanzada si no hay datos para evaluar</exception>
        public virtual T Max<T>(Func<E, T> predicate)
        {
            List<E> lista = Leer();
            if (lista.Any())
            {
                return lista.Max(predicate);
            }
            throw new InvalidOperationException("No hay datos para evaluar la condicion");
        }
    }
}
