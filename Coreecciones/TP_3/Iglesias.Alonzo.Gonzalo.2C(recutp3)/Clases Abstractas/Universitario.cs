using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;
        /// <summary>
        /// constructor por defecto sin parametros 
        /// </summary>
        public Universitario()
        {

        }
        /// <summary>
        /// constructor con todos los parametros 
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        /// <summary>
        /// metodo abstract de la participacion en la clase 
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// sobrecarga de operador ==  comparacion entre universitarios 
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>un bool , true si son iguales
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool flag = false;
            if (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo)
            {

                flag = true;
            }
            return flag;
        }
        /// <summary>
        /// sobrecarga del operador == (universitarios)
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns> retorna bool en false de ser diferentes los universitarios 
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {

            return !(pg1 == pg2);
        }
        /// <summary>
        /// genera un string con todos los datos del universitario 
        /// </summary>
        /// <returns></returns>retorna el string con los datos 
        protected virtual string MostrarDatos()
        {
            StringBuilder srt = new StringBuilder();
            //srt.AppendLine($"Datos: ");
            //srt.AppendLine($" {base.ToString()}");
            srt.AppendLine($"Legajo Numero : {this.legajo}");



            return srt.ToString();
        }
        /// <summary>
        /// sobrecarga del metodo equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>retorna si el objeto es igual 
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
