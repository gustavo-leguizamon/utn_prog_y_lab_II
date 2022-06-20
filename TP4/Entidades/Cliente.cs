using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Cliente
    {
        private long dni;
        private string nombre;
        private string apellido;
        private DateTime fechaNacimiento;
        private string direccion;

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

        public List<Mascota> Mascotas { get; set; }

        public Cliente()
        {
            Mascotas = new List<Mascota>();
        }

        public Cliente(long dni, string nombre, string apellido, DateTime nacimiento, string direccion)
            : this()
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.fechaNacimiento = nacimiento;
        }

        public Cliente(long dni, string nombre, string apellido, DateTime nacimiento, string direccion, List<Mascota> mascotas)
            : this(dni, nombre, apellido, nacimiento, direccion)
        {
            this.Mascotas = mascotas;
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
