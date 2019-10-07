using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {

        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        EMarca marca;
        string codigoDeBarras;
        ConsoleColor colorPrimarioEmpaque;
        /// <summary>
        /// sireve para cargar los datos genericos de un producto
        /// </summary>
        /// <param name="codigo">es el codigo de barras del producto</param>
        /// <param name="marca">es la marca del producto en cuestion</param>
        /// <param name="color">es el color primario del producto</param>
        public Producto(string codigo, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = codigo;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }

        /// <summary>
        /// ReadOnly: Retornará la cntidad de calorias
        /// </summary>
        protected abstract short CantidadCalorias { get;}

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        /// <summary>
        /// pone todos los datos del producto como string
        /// </summary>
        /// <param name="p">es el producto a del momento</param>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1">producto a comparar</param>
        /// <param name="v2">producto a comparar</param>
        /// <returns>retorna un bool dependiendo de si es igua o no</returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            bool retorno = false;
            if(v1.codigoDeBarras == v2.codigoDeBarras)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1">producto a comparar</param>
        /// <param name="v2">producto a comparar</param>
        /// <returns>retorna un bool dependiendo de si son iguales o no </returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1== v2);
        }
        
    }
}
