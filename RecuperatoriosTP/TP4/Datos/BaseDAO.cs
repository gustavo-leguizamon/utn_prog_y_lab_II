using Entidades;
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
        where E : class, IEntidad
    {
        protected static string ConnectionString;

        public delegate void DelegadoActualizacionDatosHandler();

        public event DelegadoActualizacionDatosHandler OnNuevosDatos;

        protected abstract string Tabla { get; }

        static BaseDAO()
        {
            BaseDAO<TID, E>.ConnectionString = @"Server=.\SQLEXPRESS;Database=Veterinaria;Trusted_Connection=True;";
        }

        protected abstract SqlCommand CrearCommandInsert(E entidad);
        protected abstract SqlCommand CrearCommandUpdate(E entidad);

        /// <summary>
        /// Almacena los datos de una entidad en la BD
        /// </summary>
        /// <param name="entidad"></param>
        public void Guardar(E entidad)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = CrearCommandInsert(entidad);
                command.Connection = connection;
                command.ExecuteNonQuery();
            }

            if (OnNuevosDatos is not null)
            {
                OnNuevosDatos.Invoke();
            }
        }

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

        private List<E> ParseResultados(SqlDataReader reader)
        {
            List<E> list = new List<E>();
            while (reader.Read())
            {
                list.Add(ParseResultado(reader));
            }

            return list;
        }

        protected abstract E ParseResultado(SqlDataReader reader);

        /// <summary>
        /// Devuelve todas la entidades almacenadas en la BD
        /// </summary>
        /// <returns></returns>
        public List<E> Leer()
        {
            List<E> list;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM {Tabla}";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                list = ParseResultados(reader);
            }

            return list;
        }

        /// <summary>
        /// Devuelve todas la entidades almacenadas en la BD que cumplan con la condicion especificada
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public virtual List<E> Leer(Func<E, bool> filtro)
        {
            return Leer().Where(filtro).ToList();
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
        public E LeerPorId(TID id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM {Tabla} WHERE Id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return ParseResultado(reader);
                }
            }

            throw new EntidadInexistenteException(id.ToString());
        }

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
        public void Modificar(E entidad)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = CrearCommandUpdate(entidad);
                command.Connection = connection;
                command.ExecuteNonQuery();
            }

            if (OnNuevosDatos is not null)
            {
                OnNuevosDatos.Invoke();
            }
        }

        /// <summary>
        /// Elimina una entidad de la BD por medio de su ID
        /// </summary>
        /// <param name="id"></param>
        public void Eliminar(TID id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = $"DELETE FROM {Tabla} WHERE Id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
            }

            if (OnNuevosDatos is not null)
            {
                OnNuevosDatos.Invoke();
            }
        }

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
