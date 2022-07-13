using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoMascota : IEntidad<short>
    {
        public enum eTipoMascota
        {
            Perro = 1,
            Gato = 2,
        }

        private short id;
        private string tipo;

        public short Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public TipoMascota(short id, string tipo)
        {
            this.id = id;
            this.tipo = tipo;
        }

        public override string ToString()
        {
            return this.tipo;
        }
    }
}
