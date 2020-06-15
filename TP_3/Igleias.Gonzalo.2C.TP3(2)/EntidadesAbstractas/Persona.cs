using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        /// <summary>
        /// propiedad atributo apellido con la validadcion de que
        /// sean caracteres validos 
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set
            {
                string valido;
                valido = ValidarNombreApellido(value);
                if (valido != null)
                {
                    this.apellido = valido;
                }

            }
        }
        /// <summary>
        /// propiedad atributo dni con sus validaciones de que este dentro
        /// de los parametros pedidos 
        /// </summary>
        public int DNI
        {
            get { return this.dni; }

            set
            {
                int retorno = ValidarDni(this.Nacionalidad, value);
                if (retorno > 0)
                {
                    this.dni = value;
                }

            }
        }
        /// <summary>
        /// propiedad del atributo nacionalidad 
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }
        /// <summary>
        /// propiedad del atributo nombre con la validacion 
        /// de que los caracteres sean validos 
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                string valido;
                valido = ValidarNombreApellido(value);
                if (valido != null)
                {
                    this.nombre =valido;
                }
            }
        }
        /// <summary>
        /// segunda propiedad del atributo dni pero con valor recibido de string y validado
        /// </summary>
        public string StringToDNI
        {
            set
            {
                int retorno = ValidarDni(this.Nacionalidad, value);
                if (retorno > 0)
                {
                    this.dni = retorno;
                }
            }
        }
        /// <summary>
        /// constructor de por defecto 
        /// </summary>
        public Persona()
        {

        }
        /// <summary>
        /// constructor de instancia con parcialidad de los datos 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// constructor de instancia con la totalidad de los datos  (DNI valor int) validado
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            try
            {
                this.DNI = dni;
            }
            catch (NacionalidadInvalidaException error)
            {

                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el DNI");
            }
        }
        /// <summary>
        /// constructor de instancia con la totalidad de los datos  (DNI valor string) validado
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            try
            {
                this.StringToDNI = dni;
            }
            catch (DniInvalidoException error)
            {

                throw new DniInvalidoException("DNI invalido", error);
            }

        }
        /// <summary>
        /// genera el string con todos los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder srt = new StringBuilder();

            srt.AppendLine(string.Format("Nombre Completo: {0} {1}",this.Nombre , this.Apellido));
            //srt.AppendLine($"Apellido : {this.Apellido}");
            srt.AppendLine($"Nacionalidad : {this.Nacionalidad}");
            srt.Append($"DNI : {this.DNI}");
            

            return srt.ToString();
        }
        /// <summary>
        /// valida que el numero del dni este dentro de los parametros establecidos  sino lanza exception
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dni"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dni)
        {
            int valido = 0;
            try
            {
                if (nacionalidad is ENacionalidad.Argentino)
                {
                    if (dni > 1 && dni < 89999999 )
                    {
                        valido = dni;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException("El numero de dni no coninside con la nacionalidad");
                    }
                }
                else if(nacionalidad is ENacionalidad.Extranjero)
                {
                    if (dni > 90000000 && dni < 99999999)
                    {
                        valido = dni;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException("El numero de dni no coninside con la nacionalidad");
                    }
                }
            }
            catch (Exception e)
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI",e);
            }

            return valido;
        }
        /// <summary>
        /// valida que el dni que nos pasan como string se pueda convertir a int sino lanza exception
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dni"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dni)
        {
            int valido = 0;
            bool flag = false;
            try
            {
                flag = int.TryParse(dni, out valido);
                if (flag == false)
                {
                    throw new DniInvalidoException("No es un DNI valido");
                }
                else
                {
                    if (dni.Length <= 8)
                        valido = ValidarDni(nacionalidad, valido);
                }
            }
            catch(NacionalidadInvalidaException error)
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de  DNI",error);
            }
            catch (Exception error)
            {
                throw new DniInvalidoException("El DNI no es valido",error);
            }

            return valido;
        }
        /// <summary>
        /// vsalida los campos de string nombre y apellido que sean caracteres validos para esos campos(usa expresiones regulares)
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {

            Regex Val = new Regex(@"^[a-zA-Z]+$");
            if (!Val.IsMatch(dato))
            {
                dato = null;
            }
            return dato;
        }
    }
}
