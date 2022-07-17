using Datos.Exceptions;
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
        where E : class, IEntidad<TID>
    {
        /// <summary>
        /// Cadena de conexion con la base de datos a utilizar
        /// </summary>
        protected static string ConnectionString;

        public delegate void DelegadoActualizacionDatosHandler();

        /// <summary>
        /// Evento que sucede cuando se actualizan los datos en la tabla de la entidad E
        /// </summary>
        public event DelegadoActualizacionDatosHandler OnNuevosDatos;

        /// <summary>
        /// Nombre de la tabla en la base de datos para la entidad E
        /// </summary>
        protected abstract string Tabla { get; }

        static BaseDAO()
        {
            BaseDAO<TID, E>.ConnectionString = @"Server=.\SQLEXPRESS;Database=Veterinaria;Trusted_Connection=True;";
        }

        /// <summary>
        /// Crea el comando para realizar la insercion en la base de datos de la entidad
        /// </summary>
        /// <param name="entidad">Entidad con los datos a insertar</param>
        /// <returns>Objeto SqlCommand para realizar un INSERT en la base de datos</returns>
        protected abstract SqlCommand CrearCommandInsert(E entidad);

        /// <summary>
        /// Crea el comando para realizar la actualizacion en la base de datos de la entidad
        /// </summary>
        /// <param name="entidad">Entidad con los datos a actualizar</param>
        /// <returns>Objeto SqlCommand para realizar un UPDATE en la base de datos</returns>
        protected abstract SqlCommand CrearCommandUpdate(E entidad);

        /// <summary>
        /// Parsea los resultados de una consulta de la entidad en la base de datos
        /// </summary>
        /// <param name="reader">Objeto SqlReader con los datos obtenidos de la base de datos</param>
        /// <returns>Objeto de la entidad E construido con los datos obtenidos de la consulta</returns>
        protected abstract E ParseResultado(SqlDataReader reader);

        /// <summary>
        /// Invoca al evento que avisa sobre la actualizacion de datos, siempre que el evento halla sido configurado
        /// </summary>
        protected void InvocarActualizacionDatos()
        {
            if (OnNuevosDatos is not null)
            {
                OnNuevosDatos.Invoke();
            }
        }

        /// <summary>
        /// Almacena los datos de una entidad en la base de datos
        /// </summary>
        /// <param name="entidad">Entidad con los datos a insertar</param>
        public virtual void Guardar(E entidad)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = CrearCommandInsert(entidad);
                command.Connection = connection;
                entidad.Id = (TID)command.ExecuteScalar();
            }

            InvocarActualizacionDatos();
        }

        /// <summary>
        /// Almacena los datos de multiples entidades en la base de datos
        /// </summary>
        /// <param name="entidades">Entidades con los datos a insertar</param>
        public virtual void Guardar(List<E> entidades)
        {
            foreach (E entidad in entidades)
            {
                Guardar(entidad);
            }
        }

        /// <summary>
        /// Almacena los datos de una entidad en la base de datos, ademas insertando los datos de sus relaciones dentro del objeto
        /// </summary>
        /// <param name="entidad">Entidad con los datos a insertar</param>
        /// <param name="incluirRelaciones">Indicar si incluye las relaciones internas o no</param>
        public virtual void Guardar(E entidad, bool incluirRelaciones)
        {

        }

        /// <summary>
        /// Almacena los datos de multiples entidades en la base de datos, ademas insertando los datos de sus relaciones dentro del objeto
        /// </summary>
        /// <param name="entidades">Entidades con los datos a insertar</param>
        /// <param name="incluirRelaciones">Indicar si incluye las relaciones internas o no de cada entidad</param>
        public virtual void Guardar(List<E> entidades, bool incluirRelaciones)
        {
            foreach (E entidad in entidades)
            {
                Guardar(entidad, incluirRelaciones);
            }
        }

        /// <summary>
        /// Parsea los resultados de una consulta de la entidad en la base de datos
        /// </summary>
        /// <param name="reader">Objeto SqlReader con los datos obtenidos de la base de datos</param>
        /// <returns>Listado de objetos de la entidad E construido con los datos obtenidos de la consulta</returns>
        private List<E> ParseResultados(SqlDataReader reader)
        {
            List<E> list = new List<E>();
            while (reader.Read())
            {
                list.Add(ParseResultado(reader));
            }

            return list;
        }

        /// <summary>
        /// Devuelve todas la entidades almacenadas en la base de datos
        /// </summary>
        /// <returns>Listado de objetos de la entidad E obtenidos de la base de datos</returns>
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
        /// Devuelve todas la entidades almacenadas en la base de datos incluyendo sus relaciones
        /// </summary>
        /// <param name="incluirRelaciones">Listado de los tipos de los objetos que tienen relacion</param>
        /// <returns>Listado de objetos de la entidad E obtenidos de la base de datos</returns>
        public abstract List<E> Leer(Type[] incluirRelaciones);

        /// <summary>
        /// Devuelve todas la entidades almacenadas en la base de datos que cumplan con la condicion especificada
        /// </summary>
        /// <param name="filtro">Condicion que deben cumplir las entidades</param>
        /// <returns>Listado de objetos de la entidad E que cumplen con la condicion obtenidos de la base de datos </returns>
        public virtual List<E> Leer(Func<E, bool> filtro)
        {
            return Leer().Where(filtro).ToList();
        }

        /// <summary>
        /// Devuelve todas la entidades almacenadas en la base de datos que cumplan con la condicion especificada incluyendo sus relaciones
        /// </summary>
        /// <param name="filtro">Condicion que deben cumplir las entidades</param>
        /// <param name="incluirRelaciones">Listado de los tipos de los objetos que tienen relacion</param>
        /// <returns>Listado de objetos de la entidad E que cumplen con la condicion obtenidos de la base de datos</returns>
        public virtual List<E> Leer(Func<E, bool> filtro, Type[] incluirRelaciones)
        {
            return Leer(incluirRelaciones).Where(filtro).ToList();
        }


        /// <summary>
        /// Devuelve una entidad que coincida con el ID especificado
        /// </summary>
        /// <param name="id">Valor del id buscado</param>
        /// <returns>Entidad que tenga el ID</returns>
        /// <exception cref="EntidadInexistenteException">Lanzada cuando no se encuentra ningun registro en la tabla que tenga el ID especificado</exception>
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
        /// Devuelve una entidad que coincida con el ID especificado, ademas le agrega las tablas relacionadas que se especifiquen
        /// </summary>
        /// <param name="id">Valor del id buscado</param>
        /// <param name="incluirRelaciones">Listado de los tipos de los objetos que tienen relacion</param>
        /// <returns>Entidad que tenga el ID</returns>
        public abstract E LeerPorId(TID id, Type[] incluirRelaciones);

        /// <summary>
        /// Actualiza los datos de una entidad en la base de datos
        /// </summary>
        /// <param name="entidad">Entidad con los datos a actualizar</param>
        public void Modificar(E entidad)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = CrearCommandUpdate(entidad);
                command.Connection = connection;
                command.ExecuteNonQuery();
            }

            InvocarActualizacionDatos();
        }

        /// <summary>
        /// Elimina fisicamente una entidad de la base de datos por medio de su ID
        /// </summary>
        /// <param name="id">ID del registro a eliminar de la tabla</param>
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

            InvocarActualizacionDatos();
        }

        /// <summary>
        /// Elimina o activa logicamente una entidad de la BD
        /// </summary>
        /// <param name="entidad">Entidad sobre la que se va a operar</param>
        /// <param name="activo">True para activar la entidad, o false para desactivarla</param>
        /// <exception cref="ArgumentException">Lanzada cuando la entidad no es del tipo IActivable para realizar una baja logica</exception>
        public void Activacion(E entidad, bool activo)
        {
            if (entidad is not IActivable)
            {
                throw new ArgumentException("La entidad no es activable para para realizar un borrado logico");
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = $"UPDATE {Tabla} SET Activo = @activo WHERE Id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", entidad.Id);
                command.Parameters.AddWithValue("activo", activo);
                command.ExecuteNonQuery();
            }

            InvocarActualizacionDatos();
        }

        /// <summary>
        /// Verifica si existe una entidad con el ID especificado
        /// </summary>
        /// <param name="id">ID del registro a verificar</param>
        /// <returns>True si existe, false caso contrario</returns>
        public virtual bool Existe(TID id)
        {
            return LeerPorId(id) is not null;
        }


    }
}
