using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        /// <summary>
        /// constructor por defecto , asigna 0 en el atributo numero
        /// </summary>
        public Numero()
        {
            this.SetNumero = "0";
        }
        /// <summary>
        /// sobrecarga constructor que recibe un double y lo asigna al atributo
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.SetNumero = numero.ToString();
        }
        /// <summary>
        /// sobrecarga de constructor que recibe string para asignar en el atributo 
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        /// <summary>
        /// sobrecarga operador +
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>retorna la suma entre el atributo double de dos clases numero</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// sobrecarga de operador -
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>retorna la resta entre el atributo double de dos clases numero</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// sobrecarga de operador *
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>retorna la multiplicacion entre el atributo double de dos clases numero</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// sobrecarga del operador /
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>retorna la divicion entre el atributo double de dos clases numero siempre y cuando no sea divicion por 0</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = 0;
            if(n2.numero == 0)
            {
                retorno = double.MinValue;
            }else
            {
                retorno = n1.numero / n2.numero;
            }
            return retorno;
        }
        /// <summary>
        /// convierte numero de binario a decimal 
        /// </summary>
        /// <param name="binario">string con el numero en binario</param>
        /// <returns>un string con el numero decimal que representa el binario que recibio si no pede hacerlo devuelve caso de error  </returns>
        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido";
            bool flag = EsBinario(binario);
            if(flag)
            {
                for (int l = 0; l < binario.Length; l++)
                {
                    if (binario[l] == '1' || binario[l] == '0')
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
            }
            
            return retorno;
        }
        /// <summary>
        /// convierte de un numero decimal a un numero binario si puede hacerlo
        /// </summary>
        /// <param name="numero">double con el valor a convertir </param>
        /// <returns>string con el numero en binario que representa el numero decimal (para esto llama al la sobrecarga de si mismo) </returns>
        public string DecimalBinario(double numero)
        {
            string num;
            num = numero.ToString();
            return DecimalBinario(num);
        }
        /// <summary>
        /// sobrecarga del metodo con parametro string 
        /// </summary>
        /// <param name="numero">string con el valor a convertir </param>
        /// <returns>retorna un string con el valor espresado en binario que representa el numero inicial en decimal</returns>
        public string DecimalBinario(string numero)
        {
            double num = 0;
            bool flag;
            double resto;
            string binario = "";


                flag = double.TryParse(numero, out num);

                if (flag == true)
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
        /// comprueba que una cadena de string sea un numero binario valido
        /// </summary>
        /// <param name="binario">string a validar</param>
        /// <returns>bool con el valor segun si es o no un binario </returns>
        private bool EsBinario(string binario)
        {
            bool flag = false;
            for (int i = 0; i < binario.Length; i++)
            {
                if(binario[i] == '1' || binario[i] == '0')
                {
                    flag = true;
                }
            }
            return flag;
        }
        /// <summary>
        /// valida que sea solo alla numeros en un string 
        /// </summary>
        /// <param name="strNumero">string a validar</param>
        /// <returns> si solo tien enumeros devuelve el valor en un double </returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;
            double aux = 0;
            bool flag = false;
            flag = double.TryParse(strNumero, out aux);
            if(flag == true)
            {
                retorno = aux;
            }
            return retorno;
        }
    }
}
