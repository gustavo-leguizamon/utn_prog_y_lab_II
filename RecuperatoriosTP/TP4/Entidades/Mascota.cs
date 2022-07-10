using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mascota : IEntidad<long>, IActivable
    {
        private long id;
        private long clienteId;
        private string nombre;
        private float peso;
        private DateTime fechaNacimiento;
        private bool activo;

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

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
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

        public Mascota(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public Mascota(long id, long clienteId, string nombre, float peso, DateTime nacimiento, bool activo)
            : this()
        {
            this.id = id;
            this.clienteId = clienteId;
            this.nombre = nombre;
            this.peso = peso;
            this.fechaNacimiento = nacimiento;
            this.activo = activo;
        }

        public Mascota(long clienteId, string nombre, float peso, DateTime nacimiento, bool activo)
            : this(0, clienteId, nombre, peso, nacimiento, activo)
        {
        }

        public override string ToString()
        {
            return String.Format("#{0,-8} - {1}", this.id, this.nombre);
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
