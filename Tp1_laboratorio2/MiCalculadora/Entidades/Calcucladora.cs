using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calcucladora
    {
        /// <summary>
        /// Valida el operador pasado por referencia 
        /// </summary>
        /// <param name="operador"> el parametro operador</param>
        /// <returns></returns>retorna un string con el operador o el default
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";

            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                retorno = operador;
            }
            return retorno;
        }
        /// <summary>
        /// opera entre dos objetos de la clase numero
        /// </summary>
        /// <param name="num1">objeto uno</param>
        /// <param name="num2">objeto dos </param>
        /// <param name="operador">operacion a realizar entre los objetos</param>
        /// <returns></returns>retorna un double con el valor
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            string respuesta;
            Double resultado=0;
            respuesta= ValidarOperador(operador);
            switch(respuesta)
            {
                case "+":
                   resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }
    }
}
