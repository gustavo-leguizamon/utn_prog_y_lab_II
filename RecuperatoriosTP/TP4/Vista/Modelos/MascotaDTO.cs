using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vista.Modelos
{
    public class MascotaDTO
    {
        private long id;
        private string nombre;
        private float peso;
        private DateTime fechaNacimiento;
        private long dni;
        private string cliente;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public long Dni
        {
            get { return dni; }
            set { dni = value; }
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

        public MascotaDTO(long id, string nombre, long dni, string cliente, float peso, DateTime fechaNacimiento)
        {
            this.id = id;
            this.nombre = nombre;
            this.dni = dni;
            this.cliente = cliente;
            this.peso = peso;
            this.fechaNacimiento = fechaNacimiento;
        }
    }
}
