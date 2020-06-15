using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public class SinProfesorException : Exception
    {
        private string mensaje;
        /// <summary>
        /// constructor vasio con mensaje por defecto
        /// </summary>
        public SinProfesorException()
        {
            this.mensaje = "No hay profesor para la clase";
        }
        /// <summary>
        ///  constructor con un parametro mensaje 
        /// </summary>
        /// <param name="mensaje"></param>
        public SinProfesorException(string mensaje) : base(mensaje)
        {

        }
        /// <summary>
        ///  constructor con un parametro mensaje  y la inner con la informacion de todo el error
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="innerexeption"></param>
        public SinProfesorException(string mensaje, Exception innerexeption) : base(mensaje, innerexeption)
        {

        }
    }
}
