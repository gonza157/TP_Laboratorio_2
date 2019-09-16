using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero = 0;

        private string SetNumero
        {

            set
            {
                double num;
                num = ValidarNumero(value);
                this.numero = num;
            }
        }
        /// <summary>
        /// contructor de la clase numero sin parametros
        /// </summary>
        public Numero()
        {
            this.numero = 0;

        }
        /// <summary>
        /// Sobrecarga constructor de numero con un parametro double
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;

        }
        /// <summary>
        /// Sobrecarga de constructor de numero con un string
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            double numero;
            bool flag;
            flag = double.TryParse(strNumero, out numero);
            if (flag == true)
            {
                this.numero = numero;
            }

        }



        /// <summary>
        /// Valida que un numero sea numero
        /// </summary>
        /// <param name="numero">string a validar</param>
        /// <returns></returns>retorna un double con numero validado o el caso de error
        public double ValidarNumero(string numero)
        {
            bool flag;
            double numeroD = 0;
            double retorno = 0;
            flag = double.TryParse(numero, out numeroD);
            if (flag == true)
            {
                retorno = numeroD;
            }
            return retorno;
        }

        /// <summary>
        /// cambierte un numero binario en decimal
        /// </summary>
        /// <param name="binario">numero a comvertir</param>
        /// <returns></returns>retorna el numero en decimal de ser posible y sino el caso de error
        public string BinarioADecimal(string binario)
        {
            string retorno = "Valor invalido";
            int l = 0;
            int len = 0;
            len = binario.Length;
            for (l = 0; l < len; l++)
            {
                if (binario[l] == '1' || binario[l] == '1')
                {
                    char[] array = binario.ToCharArray();
                    Array.Reverse(array);
                    int sum = 0;

                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] == '1')
                        {
                            sum += (int)Math.Pow(2, i);
                        }
                    }
                    retorno = sum.ToString();
                }

            }
            return retorno;
            
        }
        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="numero">numero a convertir</param>
        /// <returns></returns>retorna el numero si pudo convertirlo y sino el caso error
        public string DecimalBinario(string numero)
        {
            double num = 0;
            bool numeroV;
            double resto;
            string binario = "Valor invalido";
            numeroV = double.TryParse(numero, out num);

            if (numeroV == true)
            {
                resto = 0;
                binario = "";

                while (num >= 1)
                {
                    resto = num % 2;
                    num = (int)num / 2;
                    binario = resto.ToString() + binario;
                }
            }
            return binario;
        }
        /// <summary>
        /// Sobrecarga de decimal a binario, tambien lo convierte pero su parametro es del tipo double
        /// </summary>
        /// <param name="numero">numero a comvertir</param>
        /// <returns></returns>retorna el numero si lo pudo convertir y sino el caso de error
        public string DecimalBinario(double numero)
        {
            string num;
            num = numero.ToString();
            return DecimalBinario(num);
        }

        /// <summary>
        /// sobrecargas de operadores, permite trabajar con objetos 
        /// </summary>
        /// <param name="numero1">objeto numero 1</param>
        /// <param name="numero2">objeto numero 2</param>
        /// <returns></returns>un resultado de la operacion o un caso de error
        public static double operator +(Numero numero1, Numero numero2)
        {

            return numero1.numero + numero2.numero;
        }
        /// <summary>
        /// sobrecargas de operadores, permite trabajar con objetos 
        /// </summary>
        /// <param name="numero1">objeto numero 1</param>
        /// <param name="numero2">objeto numero 2</param>
        /// <returns></returns>un resultado de la operacion o un caso de error
        public static double operator -(Numero numero1, Numero numero2)
        {

            return numero1.numero - numero2.numero;
        }
        /// <summary>
        /// sobrecargas de operadores, permite trabajar con objetos 
        /// </summary>
        /// <param name="numero1">objeto numero 1</param>
        /// <param name="numero2">objeto numero 2</param>
        /// <returns></returns>un resultado de la operacion o un caso de error
        public static double operator /(Numero numero1, Numero numero2)
        {

            return numero1.numero / numero2.numero;
        }
        /// <summary>
        /// sobrecargas de operadores, permite trabajar con objetos 
        /// </summary>
        /// <param name="numero1">objeto numero 1</param>
        /// <param name="numero2">objeto numero 2</param>
        /// <returns></returns>un resultado de la operacion o un caso de error
        public static double operator *(Numero numero1, Numero numero2)
        {

            return numero1.numero * numero2.numero;
        }
    }
}
