using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Text.RegularExpressions;

namespace Biblioteca.Entidades
{
    public class Persona
    {
        public enum ENacionalidad
        {
            Argentina,
            extranjero
        }
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int DNI;



        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }
        public int Dni
        {
            get
            {
                return this.DNI;
            }
            set
            {
                this.DNI = value;
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string StringToDNI
        {
            set
            {
                /*int resultado=0;
                bool flag = false;
                flag = int.TryParse(value, out resultado);
                if(value.Count()>=7 && value.Count() <=8 && flag==true)
                {*/
                this.DNI = this.ValidarDni(this.Nacionalidad, value);
                /*}else
                {
                    throw new DniInvalidoException();
                }*/

            }
        }


        public Persona()
        {

        }

        protected Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dNI, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dNI;
        }
        public Persona(string nombre, string apellido, string dNI, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dNI;
        }

        public override string ToString()
        {
            StringBuilder srt = new StringBuilder();

            srt.AppendLine(this.Nombre);
            srt.AppendLine(this.Apellido);
            srt.AppendLine(this.Dni.ToString());
            srt.AppendLine(this.Nacionalidad.ToString());            

            return srt.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            bool flag = false;

            if (dato >= 1 && dato <= 89999999 && nacionalidad == ENacionalidad.Argentina
                || dato > 89999999 && dato > 99999999 && nacionalidad == ENacionalidad.extranjero)
            {
                flag = true;
            }
            else
            {
                throw new DniInvalidoException();
            }
                       
            return dato;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int resultado = 0;
            bool flag = false;
            flag = int.TryParse(dato, out resultado);  
            if (flag == true)
            {
                ValidarDni(nacionalidad, resultado);
            }
            else
            {
                throw new DniInvalidoException();
            }
            return resultado;
        }

        private string ValidarNombreApellido(string dato)
        {
            string nombre = "";
            Regex regex = new Regex("^[a-z-A-Z- :\\S]+$");
            Match match = regex.Match(dato);
            if (match.Success && dato.Count() <= 50)
            {
                nombre = dato;
            }
            return nombre;
        }
    }
}
