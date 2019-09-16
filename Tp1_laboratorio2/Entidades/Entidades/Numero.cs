using System;
using System.Collections.Generic;
using System.Text;

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
                num=ValidarNumero(value);
                this.numero = num;
            }
        }

        public  Numero()
        {
            this.numero = 0;
            
        }

        public  Numero(double numero)
        {
            this.numero = numero;
            
        }

        public Numero(string strNumero)
        {
            double numero;
            bool flag;
            flag = double.TryParse(strNumero, out numero);
            if(flag == true)
            {
                this.numero = numero;
            }
           
        }

        


        public double ValidarNumero(string numero)
            {
                bool flag;
                double numeroD=0;
            double retorno=0;
                flag= double.TryParse(numero, out numeroD);
            if (flag==true)
            {
                retorno = numeroD;
            }
                return retorno;
            }


        public string BinarioADecimal(string binario)
        {
            string retorno="Valor invalido";
            int l = 0;
            int len = 0;
            len = binario.Length;
            for(l=0;l<len;l++)
            {
                if(binario[l]== '1' || binario[l] == '1')
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
            //string retorno;
            //char[] array = binario.ToCharArray();
            //Array.Reverse(array);
            //int sum = 0;

            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (array[i] == '1')
            //    {
            //        sum += (int)Math.Pow(2, i);
            //    }
            //}
            //retorno =sum.ToString();
            //return retorno;
        }

        public string DecimalBinario(string numero)
        {
            double num = 0;
            bool numeroV;
            double resto;
            string binario = "Valor invalido";
            numeroV= double.TryParse(numero, out num);

            if(numeroV == true)
            {
                resto = 0;
                binario = "";
           
                while (num >=1)
                {
                    resto = num % 2;
                    num = (int)num / 2;
                    binario = resto.ToString()+ binario;
                }
            }
            return binario;
        }

        public string DecimalBinario(double numero)
        {
            string num;
            num=numero.ToString();
            return DecimalBinario(num);
        }


        public static double operator +(Numero numero1, Numero numero2)
        {
            
            return numero1.numero + numero2.numero;
        }

        public static double operator -(Numero numero1, Numero numero2)
        {

            return numero1.numero - numero2.numero;
        }

        public static double operator /(Numero numero1, Numero numero2)
        {

            return numero1.numero / numero2.numero;
        }

        public static double operator *(Numero numero1, Numero numero2)
        {

            return numero1.numero * numero2.numero;
        }
    }
}
