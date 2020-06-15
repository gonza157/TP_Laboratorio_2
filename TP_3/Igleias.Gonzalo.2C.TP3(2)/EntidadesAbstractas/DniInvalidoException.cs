using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public class DniInvalidoException : Exception
    {
        private string mensaje;
        /// <summary>
        /// constructor vasio con un mensaje por defecto 
        /// </summary>
        public DniInvalidoException()
        {
            this.mensaje = "El DNI no es valido";
        }
        /// <summary>
        /// constructor con solo una inner
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e)
        {

        }
        /// <summary>
        ///  constructor con un parametro mensaje 
        /// </summary>
        /// <param name="mensaje"></param>
        public DniInvalidoException(string mensaje) : base(mensaje)
        {

        }
        /// <summary>
        ///  constructor con un parametro mensaje  y la inner con la informacion de todo el error
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="innerexception"></param>
        public DniInvalidoException(string mensaje, Exception innerexception) : base(mensaje, innerexception)
        {

        }
    }
}
