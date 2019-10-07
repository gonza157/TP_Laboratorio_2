using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
     public sealed class Changuito
    {
        List<Producto> productos;
        int espacioDisponible;
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        #region "Constructores"
        /// <summary>
        /// Reserva espacio en memoria para la lista
        /// </summary>
        private Changuito()
        {
            this.productos = new List<Producto>();
        }
        /// <summary>
        /// crea la lista con espacios listos para ser cargados
        /// </summary>
        /// <param name="espacioDisponible"> es el tamaño de la lista </param>
        public Changuito(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns>string con tdos los elementos de la lisa</returns>
        public override string ToString()
        {
            return this.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>lista de productos</returns>
        public string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.productos.Count, c.espacioDisponible);
            sb.AppendLine("");
            foreach (Producto v in c.productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if (v is Snacks)
                        {
                            Snacks s = (Snacks)v;
                            sb.AppendLine(s.Mostrar());
                        }                        
                        break;
                    case ETipo.Dulce:
                        if (v is Dulce)
                        {
                            Dulce d = (Dulce)v;
                            sb.AppendLine(d.Mostrar());
                        }                        
                        break;
                    case ETipo.Leche:
                        if (v is Leche)
                        {
                            Leche l = (Leche)v;
                            sb.AppendLine(l.Mostrar());
                        }                        
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }

                
                

            }

            return sb.ToString();
            

        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns>la lista con el objeto si no encontro el mismo</returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            
            if(c.productos.Count==0 && !(p is null))
            {
                c.productos.Add(p);
                
            }
            else
            {
                
                if(!(p is null) && c.espacioDisponible > c.productos.Count)
                {
                    bool cargar = true;
                    for (int i = 0; i < c.productos.Count; i++)
                    {
                         if (c.productos[i] == p)
                         {
                            cargar = false;
                         }                    
                    }

                    if (cargar)
                    {
                        c.productos.Add(p);
                    }
                }
                
               /* foreach (Producto v in c.productos)
                {

                    if (v != p && !(p is null) && c.espacioDisponible >= c.productos.Count)
                    {
                        c.productos.Add(p);
                        break;
                    }

                }*/
            }
            
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns>la lista sin el objeto si encontro el mismo</returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            foreach (Producto v in c.productos)
            {
                if (v == p)
                {
                    c.productos.Remove(v);
                    break;
                }
            }

            return c;
        }
        #endregion
    }
}
