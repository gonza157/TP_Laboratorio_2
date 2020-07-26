using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exepciones
{
    public class ArchivosException : Exception
    {
        string mensaje;
        /// <summary>
        /// constructor vacio con un mensaje por defecto
        /// </summary>
        public ArchivosException()
        {
            this.mensaje = "Se a generado un error al querer trabajar con el archivo";
        }
        /// <summary>
        ///  constructor con un parametro mensaje  
        /// </summary>
        /// <param name="mensaje"></param>
        public ArchivosException(string mensaje) : base(mensaje)
        {

        }
        /// <summary>
        ///  constructor con un parametro mensaje  y la inner con la informacion de todo el error
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="innerexception"></param>
        public ArchivosException(string mensaje, Exception innerexception) : base(mensaje, innerexception)
        {

        }
    }
}
