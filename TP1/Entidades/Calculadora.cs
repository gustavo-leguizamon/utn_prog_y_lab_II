using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza una operacion aritmetica sobre los operandos
        /// </summary>
        /// <param name="num1">Operando A</param>
        /// <param name="num2">Operando B</param>
        /// <param name="operador">Operacion aritmetica</param>
        /// <returns>Resultado de la operacion</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;
            switch (ValidarOperador(operador))
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Valida que el operador pasado este entre los esperados. Caso contrario devolverá el operador '+'
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>El operador si es valido o por defecto el operador '+' si no lo es</returns>
        private static char ValidarOperador(char operador)
        {
            if (operador == '-' ||
                operador == '/' ||
                operador == '*')
            {
                return operador;
            }
            return '+';
        }
    }
}
