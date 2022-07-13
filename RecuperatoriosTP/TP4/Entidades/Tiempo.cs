using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tiempo
    {
        private int hora;
        private int minuto;
        private int segundo;

        public int Hora
        {
            get { return hora; }
            set 
            {
                if (hora < 0 || hora > 23)
                    throw new HorarioInvalidoException("El valor de hora debe estar entre 0 y 23");
                hora = value; 
            }
        }

        public int Minuto
        {
            get { return minuto; }
            set 
            {
                if (minuto < 0 || minuto > 59)
                    throw new HorarioInvalidoException("El valor de minutos debe estar entre 0 y 59");
                minuto = value; 
            }
        }

        public int Segundo
        {
            get { return segundo; }
            set 
            {
                if (segundo < 0 || segundo > 59)
                    throw new HorarioInvalidoException("El valor de segundos debe estar entre 0 y 59");
                segundo = value; 
            }
        }


        public Tiempo(int hora, int minuto, int segundo)
        {
            this.Hora = hora;
            this.Minuto = minuto;
            this.Segundo = segundo;
        }


        /// <summary>
        /// Inicializa el objeto con un string en formato hh:mm:ss
        /// </summary>
        /// <param name="hora">Hora en formato hh:mm:ss</param>
        public Tiempo(string hora)
        {
            string[] partes = hora.Split(':');
            if (partes.Length != 3)
                throw new HorarioInvalidoException("La hora no esta en el formato hh:mm:ss");
            if (!int.TryParse(partes[0], out int horas))
                throw new HorarioInvalidoException("Las horas deben ser un numero");
            if (!int.TryParse(partes[1], out int minutos))
                throw new HorarioInvalidoException("Los minutos deben ser un numero");
            if (!int.TryParse(partes[2], out int segundos))
                throw new HorarioInvalidoException("Los segundos deben ser un numero");
            this.Hora = horas;
            this.Minuto = minutos;
            this.Segundo = segundos;
        }

        #region Operadores

        public static bool operator ==(Tiempo t1, Tiempo t2)
        {
            return t1.Hora == t2.Hora &&
                   t1.Minuto == t2.Minuto &&
                   t1.Segundo == t2.Segundo;
        }

        public static bool operator !=(Tiempo t1, Tiempo t2)
        {
            return !(t1 == t2);
        }

        public static bool operator >(Tiempo t1, Tiempo t2)
        {
            return t1 != t2 &&
                   (t1.Hora > t2.Hora ||
                    (t1.Hora == t2.Hora && t1.Minuto > t2.Minuto) ||
                    (t1.Hora == t2.Hora && t1.Minuto == t2.Minuto && t1.Segundo > t2.Segundo));
        }

        public static bool operator <(Tiempo t1, Tiempo t2)
        {
            return !(t1 > t2);
        }

        #endregion




        public override string ToString()
        {
            return $"{this.hora.ToString().PadLeft(2, '0')}:{this.minuto.ToString().PadLeft(2, '0')}:{this.segundo.ToString().PadLeft(2, '0')}";
        }

        //public string HoraCorta()
        //{
        //    return $"{this.hora.ToString().PadLeft(2, '0')}:{this.minuto.ToString().PadLeft(2, '0')}";
        //}
    }
}
