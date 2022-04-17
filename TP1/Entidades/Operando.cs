using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public string Numero 
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// Instancia el objeto Operando con valores por defecto
        /// </summary>
        public Operando()
            : this(0)
        {
        }

        /// <summary>
        /// Instancia el objeto Operando especificando el valor del mismo
        /// </summary>
        /// <param name="numero">Valor del operando</param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Instancia el objeto Operando especificando el valor del mismo en tipo cadena
        /// </summary>
        /// <param name="strNumero">Numero en tipo cadena</param>
        public Operando(string strNumero)
        {
            Numero = strNumero;
        }

        /// <summary>
        /// Suma dos operandos
        /// </summary>
        /// <param name="n1">Operando A</param>
        /// <param name="n2">Operando B</param>
        /// <returns>Suma de ambos operandos</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Resta dos operandos
        /// </summary>
        /// <param name="n1">Operando A</param>
        /// <param name="n2">Operando B</param>
        /// <returns>Resta del operando n2 al operando n1</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Multiplica dos operandos
        /// </summary>
        /// <param name="n1">Operando A</param>
        /// <param name="n2">Operando B</param>
        /// <returns>Multiplicacion de ambos operandos</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Divide dos operandos
        /// </summary>
        /// <param name="n1">Operando A</param>
        /// <param name="n2">Operando B</param>
        /// <returns>Division del operando n2 sobre el operando n1</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }

        /// <summary>
        /// Comprueba que el parametro pasado sea un numero, en caso de serlo retornara el numero
        /// </summary>
        /// <param name="strNumero">Numero el formato string</param>
        /// <returns>El numero convertido a tipo numero o cero en caso de no poder convertir el numero</returns>
        private double ValidarOperando(string strNumero)
        {
            double numero;
            if (double.TryParse(strNumero, out numero))
            {
                return numero;
            }
            return 0;
        }

        /// <summary>
        /// Valida que la cadena pasado como parametro este compuesta solo por 0 y/o 1
        /// </summary>
        /// <param name="binario">Cadena a validar</param>
        /// <returns>True si la cadena constiene solo 0 y 1, False si contiene cualquier otro caracter</returns>
        private bool EsBinario(string binario)
        {
            bool valido = true;

            if (!string.IsNullOrWhiteSpace(binario))
            {
                foreach (char caracter in binario)
                {
                    if (caracter != '0' && caracter != '1')
                    {
                        valido = false;
                        break;
                    }
                }
            }
            else
            {
                valido = false;
            }

            return valido;
        }

        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="binario">Numero en formato binario</param>
        /// <returns>Numero en tipo string</returns>
        public string BinarioDecimal(string binario)
        {
            if (EsBinario(binario))
            {
                int longitud = binario.Length;
                int potencia = binario.Length - 1;
                double suma = 0;
                for (int i = 0; i < longitud; i++)
                {
                    suma += double.Parse(binario[i].ToString()) * Math.Pow(2, potencia);
                    potencia--;
                }
                return suma.ToString();
            }
            else
            {
                return "Valor inválido";
            }
        }

        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Numero en formato binario</returns>
        public string DecimalBinario(double numero)
        {
            double numeroAbsoluto = Math.Abs(numero);
            string binario = string.Empty;
            int resto;
            double resultado = numeroAbsoluto;

            do
            {
                resto = (int)resultado % 2;
                resultado = (int)(resultado / 2);

                binario = binario.Insert(0, resto.ToString());
            } while (resultado >= 2);

            if (binario.Length > 1)
                binario = binario.Insert(0, resultado.ToString());

            return binario;
        }

        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero">Cadena con el numero a convertir</param>
        /// <returns>Numero en formato binario</returns>
        public string DecimalBinario(string numero)
        {
            double auxNumero;
            
            if (double.TryParse(numero, out auxNumero))
            {
                return DecimalBinario(auxNumero);
            }
            else
            {
                return "Valor inválido";
            }
        }
    }
}
