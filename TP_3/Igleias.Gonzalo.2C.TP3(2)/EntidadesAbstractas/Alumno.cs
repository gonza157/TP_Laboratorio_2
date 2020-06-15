using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueTOma;
        private EEstadoCuenta estadoCuenta;

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        /// <summary>
        /// constructor por defecto 
        /// </summary>
        public Alumno()
        {

        }
        /// <summary>
        /// constructor de instancia sin el parametro estado de cuenta 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueTOma = claseQueToma;
        }
        /// <summary>
        /// constructor de instancia sin el parametro con la totalidad de los campos 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) :this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            
            this.estadoCuenta = estadoCuenta;
        }
        /// <summary>
        /// sobrecarga del operador == en caso de alumno y la clse que se imparte 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool flag = false;
            if (a.claseQueTOma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                flag = true;
            }
            return flag;
        }
        /// <summary>
        /// la sobrecarga del operador != si el alumno no  asis te a esa clase 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool flag = false;
            if (a.claseQueTOma != clase)
            {
                flag = true;
            }
            return flag;
        }
        /// <summary>
        /// de que clase participa 
        /// </summary>
        /// <returns></returns>retorna un string con la clase que toma el alumno
        protected override string ParticiparEnClase()
        {
            string retorno = "";
            return retorno = string.Format("TOMA CLASE DE {0}", this.claseQueTOma);
        }
        /// <summary>
        /// carga todos los datos del alumno en un string para que pueda ser usado 
        /// </summary>
        /// <returns></returns> retorna el string 
        protected override string MostrarDatos()
        {
            StringBuilder srt = new StringBuilder();

            srt.Append($"{base.MostrarDatos()}");
            srt.AppendLine($"Estado de cuenta :{this.estadoCuenta}");


            return srt.ToString();
        }
        /// <summary>
        /// usa el metodo  mostrardatos para optener un string con todos los datos de alumno
        /// </summary>
        /// <returns></returns> retorna el string con los datos 
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
