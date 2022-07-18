using Entidades.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tiempo : IComparable
    {
        private int hora;
        private int minuto;
        private int segundo;

        /// <summary>
        /// Parte hora del tiempo
        /// 
        /// CLASE 10 - Excepciones
        /// 
        /// </summary>
        /// <exception cref="HorarioInvalidoException">Lanzada cuando el valor provisto no cumple con las condiciones validas</exception>
        public int Hora
        {
            get { return hora; }
            set 
            {
                if (value < 0 || value > 23)
                    throw new HorarioInvalidoException("El valor de hora debe estar entre 0 y 23");
                hora = value;
            }
        }

        /// <summary>
        /// Parte minutos del tiempo
        /// 
        /// CLASE 10 - Excepciones
        /// 
        /// </summary>
        /// <exception cref="HorarioInvalidoException">Lanzada cuando el valor provisto no cumple con las condiciones validas</exception>
        public int Minuto
        {
            get { return minuto; }
            set 
            {
                if (value < 0 || value > 59)
                    throw new HorarioInvalidoException("El valor de minutos debe estar entre 0 y 59");
                minuto = value; 
            }
        }

        /// <summary>
        /// Parte segundos del tiempo
        /// 
        /// CLASE 10 - Excepciones
        /// 
        /// </summary>
        /// <exception cref="HorarioInvalidoException">Lanzada cuando el valor provisto no cumple con las condiciones validas</exception>
        public int Segundo
        {
            get { return segundo; }
            set 
            {
                if (value < 0 || value > 59)
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
        /// 
        /// CLASE 10 - Excepciones
        /// 
        /// </summary>
        /// <param name="hora">Hora en formato hh:mm:ss</param>
        /// <exception cref="HorarioInvalidoException">Lanzada cuando alguna parte del tiempo no cumple con las condiciones necesarias</exception>
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

        public static bool operator >=(Tiempo t1, Tiempo t2)
        {
            return t1 > t2 || t1 == t2;
        }

        public static bool operator <=(Tiempo t1, Tiempo t2)
        {
            return t1 < t2 || t1 == t2;
        }

        #endregion




        public override string ToString()
        {
            return $"{this.hora.ToString().PadLeft(2, '0')}:{this.minuto.ToString().PadLeft(2, '0')}:{this.segundo.ToString().PadLeft(2, '0')}";
        }

        public int CompareTo(object obj)
        {
            if (this > (Tiempo)obj)
                return 1;
            else if (this < (Tiempo)obj)
                return -1;
            else
                return 0;
        }
    }
}
