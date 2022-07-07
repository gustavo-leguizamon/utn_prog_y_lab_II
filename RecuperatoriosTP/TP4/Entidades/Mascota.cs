using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mascota : IEntidad
    {
        private long id;
        private long clienteId;
        private string nombre;
        private float peso;
        private DateTime fechaNacimiento;

        private Cliente cliente;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public long ClienteId
        {
            get { return clienteId; }
            set { clienteId = value; }
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

        public List<Turno> Turnos
        {
            get;
            set;
        }
        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public Mascota()
        {
            this.Turnos = new List<Turno>();
        }

        public Mascota(long id, long cliente, string nombre, float peso, DateTime nacimiento)
            : this()
        {
            this.id = id;
            this.clienteId = cliente;
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
            return m1.ClienteId == m2.ClienteId &&
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
