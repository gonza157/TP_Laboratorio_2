using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exepciones
{
    public class AlumnoRepetidoException : Exception
    {
        private string mensaje;
        /// <summary>
        /// constructor por defecto guarda un mensaje por defecto
        /// </summary>
        public AlumnoRepetidoException()
        {
            this.mensaje = "Es alumno ya existe";
        }
        /// <summary>
        /// constructor con un parametro mensaje 
        /// </summary>
        /// <param name="mensaje"></param>
        public AlumnoRepetidoException(string mensaje) : base(mensaje)
        {

        }
        /// <summary>
        /// constructor con un parametro mensaje  y la inner con la informacion de todo el error 
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="innerException"></param>
        public AlumnoRepetidoException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
