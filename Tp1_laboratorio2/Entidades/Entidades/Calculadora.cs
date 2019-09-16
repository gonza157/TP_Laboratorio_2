using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            string retorno="+";

            if(operador=="+" || operador == "-" || operador== "/" || operador == "*")
            {
                retorno= operador;
            }
            return retorno;
        }
    }
}
