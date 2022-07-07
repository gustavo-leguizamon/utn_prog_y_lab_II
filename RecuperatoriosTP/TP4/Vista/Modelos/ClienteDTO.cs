using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vista.Modelos
{
    public class ClienteDTO
    {
        private long id;
        private long dni;
        private string nombre;
        private string apellido;
        private string direccion;
        private DateTime fechaNacimiento;

        public long Id
        {
            get { return id; }
            set { id = value; }
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

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public ClienteDTO(long id, long dni, string nombre, string apellido, string direccion, DateTime fechaNacimiento)
        {
            this.id = id;
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.fechaNacimiento = fechaNacimiento;
        }
    }
}
