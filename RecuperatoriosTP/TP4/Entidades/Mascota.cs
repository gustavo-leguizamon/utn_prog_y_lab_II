using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que representa una entidad de tipo Mascota
    /// 
    /// CLASE 12 - Tipos genericos
    /// CLASE 13 - Interfaces
    /// 
    /// </summary>
    public class Mascota : IEntidad<long>, IActivable
    {
        private long id;
        private long clienteId;
        private short tipoMascotaId;
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

        public TipoMascota.eTipoMascota TipoMascota
        {
            get { return (TipoMascota.eTipoMascota)tipoMascotaId; }
            set { tipoMascotaId = (short)value; }
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

        public List<Atencion> Atenciones
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
            this.Atenciones = new List<Atencion>();
        }

        public Mascota(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public Mascota(long id, long clienteId, TipoMascota.eTipoMascota tipoMascota, string nombre, float peso, DateTime nacimiento, bool activo)
            : this()
        {
            this.id = id;
            this.clienteId = clienteId;
            this.tipoMascotaId = (short)tipoMascota;
            this.nombre = nombre;
            this.peso = peso;
            this.fechaNacimiento = nacimiento;
            this.activo = activo;
        }

        public Mascota(long clienteId, TipoMascota.eTipoMascota tipoMascota, string nombre, float peso, DateTime nacimiento, bool activo)
            : this(0, clienteId, tipoMascota, nombre, peso, nacimiento, activo)
        {
        }

        public override string ToString()
        {
            return String.Format("#{0,-8} - {1} - {2}", this.id, Enum.GetName(this.TipoMascota).ToUpper(), this.nombre);
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
