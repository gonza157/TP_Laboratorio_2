using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        private string mensaje;
        /// <summary>
        /// constructor vasio con un mensaje por defecto
        /// </summary>
        public NacionalidadInvalidaException()
        {
            this.mensaje = "La nacionalidad no corresponde";
        }
        /// <summary>
        ///  constructor con un parametro mensaje  
        /// </summary>
        /// <param name="mensaje"></param>
        public NacionalidadInvalidaException(string mensaje) : base(mensaje)
        {

        }
        /// <summary>
        ///  constructor con un parametro mensaje  y la inner con la informacion de todo el error
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="innerexception"></param>
        public NacionalidadInvalidaException(string mensaje, Exception innerexception) : base(mensaje, innerexception)
        {

        }
    }
}
