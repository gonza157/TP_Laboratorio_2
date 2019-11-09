using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;

        public DniInvalidoException(): this("El DNI es invalido")
        {
            
        }

        public DniInvalidoException(Exception e) :this("DNI invalido",e)
        {
            
        }
        public DniInvalidoException(string message) : base(message)
        {

        }

        public DniInvalidoException(string message,Exception e) : base(message,e)
        {

        }
    }
}
