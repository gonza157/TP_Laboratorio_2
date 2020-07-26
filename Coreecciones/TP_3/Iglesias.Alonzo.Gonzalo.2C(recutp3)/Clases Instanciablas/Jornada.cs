using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exepciones;
using Archivos;
using Clases_Instanciablas;

namespace Clases_Instanciablas
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        /// <summary>
        /// propiedad del atributo lista alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        /// <summary>
        /// propiedad del atributo clase que se dara 
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        /// <summary>
        /// propiedad del atributo profesor que imparte la clase
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        /// <summary>
        ///constructor por defecto donde se instancia la lista de alumnos 
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }
        /// <summary>
        /// se instancia una joranada con su datos y se reutiliza el constructor de la lista alumnos 
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// sobrecarga del operador == para compara jornada con un alumno si ya esta cargado
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>retorna un bool con true si es igual a algun alumno de la lista 
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool flag = false;
            if (j.Alumnos != null)
            {
                foreach (Alumno item in j.Alumnos)
                {
                    if (item == a)
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }
        /// <summary>
        /// sobreacarga del operador !=    
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns> retorna false si el alumno es diferente a todos los de la lista alumnos de jornada 
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// sobrecarga del operador + 
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns> retorna una jornada con el alumno si es que pudo cargarlo (tiene que ser diferente a los que ya tenga cargados)
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }
        /// <summary>
        /// guarda los datos de la jornada en un archivo de texto en el escritoriuo de la pc
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns> un bool segun si pudo o no guardar los datos 
        public static bool Guardar(Jornada datos)
        {
            bool flag = false;
            try
            {
                Texto text = new Texto();
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                flag = text.Guardar(path + @"\ArchivoJornada", datos.ToString());
            }
            catch (Exception error)
            {

                throw new ArchivosException("no se pudo guardar", error);
            }
            return flag;
        }
        /// <summary>
        /// Lee los datos desde el path indicado 
        /// </summary>
        /// <returns></returns> retorna los datos en un string
        bool Leer()
        {
            bool flag = false;
            string datos;
            try
            {
                Texto text = new Texto();
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                flag = text.Leer(path + @"\ArchivoJornada", out datos);
            }
            catch (Exception error)
            {

                throw new ArchivosException("no se pudo guardar", error);
            }
            return flag;
        }
        /// <summary>
        /// genera un string con todos los datos de la clase
        /// </summary>
        /// <returns></returns> retorna el string que genero con los datos 
        public override string ToString()
        {
            StringBuilder srt = new StringBuilder();
            srt.AppendLine(string.Format("CLASE DE {0} POR NOMBRE COMPLETO : {1} {2}", this.Clase, this.Instructor.Nombre, this.Instructor.Apellido));
            //srt.AppendLine(string.Format("Profesor {0}", this.Instructor));
            srt.AppendLine($"{this.Instructor.ToString()}");

            srt.AppendLine($"Alumnos");
            foreach (Alumno item in this.Alumnos)
            {
                srt.AppendLine($"{item.ToString()}");
            }

            return srt.ToString();
        }
    }
}
