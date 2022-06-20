using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mascota
    {
        private long id;
        private long dniCliente;
        private string nombre;
        private float peso;
        private DateTime fechaNacimiento;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public long DniCliente
        {
            get { return dniCliente; }
            set { dniCliente = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public float Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public Mascota()
        {

        }

        public Mascota(long id, long cliente, string nombre, float peso, DateTime nacimiento)
            : this()
        {
            this.id = id;
            this.dniCliente = cliente;
            this.nombre = nombre;
            this.peso = peso;
            this.fechaNacimiento = nacimiento;
        }

        public Mascota(long cliente, string nombre, float peso, DateTime nacimiento)
            : this(0, cliente, nombre, peso, nacimiento)
        {
        }

        #region Operators

        public static bool operator ==(Mascota m1, Mascota m2)
        {
            return m1.DniCliente == m2.DniCliente &&
                   m1.Nombre == m2.Nombre &&
                   m1.FechaNacimiento.Date == m2.FechaNacimiento.Date;
        }

        public static bool operator !=(Mascota m1, Mascota m2)
        {
            return !(m1 == m2);
        }

        #endregion
    }
}
