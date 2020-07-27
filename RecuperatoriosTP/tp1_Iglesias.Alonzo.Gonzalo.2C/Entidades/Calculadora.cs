using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// valida que operacion se desea realizar y la realiza
        /// </summary>
        /// <param name="num1">numero a operar</param>
        /// <param name="num2">numero a operar</param>
        /// <param name="operador">operacion a realizar</param>
        /// <returns>devuelce el double con el resultado de la operacion </returns>
        public double Operar(Numero num1, Numero num2,string operador)
        {
            string operadorValidado = ValidarOperador(char.Parse(operador));
            double resultado = 0;
            switch (operadorValidado)
            {
                case "-":
                    {
                        resultado = num1 - num2;
                        break;
                    }
                case "*":
                    {
                        resultado = num1 * num2;
                        break;
                    }
                case "/":
                    {
                        resultado = num1 / num2;
                        break;
                    }
                default :
                    {
                        resultado = num1 + num2;
                        break;
                    }
            }
            return resultado;
        }
        /// <summary>
        /// valida que el operador sea de los permitidos 
        /// </summary>
        /// <param name="operador">cahar con el operador</param>
        /// <returns>string con el operador </returns>
        private static string ValidarOperador(char operador)
        {
            char retorno = '+';
            switch (operador)
            {
                case '-':
                    {
                        retorno = '-';
                        break;
                    }
                case '*':
                    {
                        retorno = '*';
                        break;
                    }
                case '/':
                    {
                        retorno = '/';
                        break;
                    }
            }
            return retorno.ToString();
        }
    }
}
