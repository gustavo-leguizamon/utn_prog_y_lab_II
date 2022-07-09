using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Cliente : IEntidad, IActivable
    {
        private long id;
        private long dni;
        private string nombre;
        private string apellido;
        private DateTime fechaNacimiento;
        private string direccion;
        private bool activo;

        public long Id 
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public long Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string NombreCompleto 
        {
            get
            {
                return $"{this.apellido} {this.nombre}";
            }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        public List<Mascota> Mascotas
        {
            get;
            set;
        }

        public Cliente()
        {
            Mascotas = new List<Mascota>();
        }

        public Cliente(long id, long dni, string nombre, string apellido, DateTime nacimiento, string direccion)
            : this()
        {
            this.id = id;
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.fechaNacimiento = nacimiento;
        }

        public Cliente(long dni, string nombre, string apellido, DateTime nacimiento, string direccion)
            : this(0, dni, nombre, apellido, nacimiento, direccion)
        {
        }

        public Cliente(long id, long dni, string nombre, string apellido, DateTime nacimiento, string direccion, List<Mascota> mascotas)
            : this(id, dni, nombre, apellido, nacimiento, direccion)
        {
            this.Mascotas = mascotas;
        }

        public override string ToString()
        {
            return $"{this.dni} - {this.NombreCompleto}";
        }

        #region Operators

        public static bool operator ==(Cliente c1, Cliente c2)
        {
            return c1.Dni == c2.Dni;
        }

        public static bool operator !=(Cliente m1, Cliente m2)
        {
            return !(m1 == m2);
        }

        #endregion
    }
}
