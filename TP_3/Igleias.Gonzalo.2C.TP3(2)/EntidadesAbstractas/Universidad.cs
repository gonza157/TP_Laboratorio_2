using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        /// <summary>
        /// propiedad del atributo alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        /// <summary>
        /// propiedad del atributo profesores 
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }
        /// <summary>
        /// propiedad del atributo jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }
        /// <summary>
        /// index de jornadas
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Jornada this[int index]
        {
            get
            {
                Jornada j = null;
                if(Jornadas.Count > index)
                {
                    j = Jornadas[index];
                }
                return j;
            }
            set
            {
                if(Jornadas.Count < index && index >= 0)
                {
                    Jornadas.Add(value);
                }else
                {
                    Jornadas.Insert(index,value);
                }
            }
        }
        /// <summary>
        /// constructor por defecto 
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
        /// <summary>
        /// sobrecarga del operador == compara universidad y aluno si ya esta cargado
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>retorna true si ya existe
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool flag = false;
            foreach (Alumno item in g.Alumnos)
            {
                if (item == a)
                {
                    flag = true;
                }
            }
            return flag;
        }
        /// <summary>
        /// sobrecarga del operador == compara universidad con profesor a ver si ya pertenece
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>retorna true si ya existe
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool flag = false;
            foreach (Profesor item in g.Instructores)
            {
                if (item == i)
                {
                    flag = true;
                }
            }
            return flag;
        }
        /// <summary>
        /// sobrecarga del operador == compara entre clase y universidad
        /// se lanza una exepcion si no se encunetra nigun profesor que de la clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>retorna un profesor que pueda dar la clase
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor profesorNuevo = new Profesor();
            try
            {
                foreach (Profesor item in u.Instructores)
                {
                    if (item == clase)
                    {
                        //profesorNuevo = new Profesor();
                        profesorNuevo = item;
                    }
                    else
                    {
                        throw new SinProfesorException("no hay profesor para la clase");
                    }
                }
            }
            catch (SinProfesorException error)
            {
                throw new SinProfesorException("No hay profesor para la clase",error);

            }

            return profesorNuevo;
        }
        /// <summary>
        /// sobrecarga del operador !=  entre universidad y alumno
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>retorna false si ya no existe
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// sobrecarga del operador != entre univerdsidad profesor
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>retorna false si ya no existe
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>retorna un profesor que no pueda dar la clase 
        public static Profesor operator !=(Universidad u, EClases clase)
        {

            Profesor profesorNuevo = new Profesor();
            foreach (Profesor item in u.Instructores)
            {
                if (item != clase)
                {
                    profesorNuevo = item;
                }
            }
            return profesorNuevo;
        }
        /// <summary>
        /// sobrecarga del operador + para sumar un alumno a la universidad
        /// lanza la excepcion si ya existe el alumno
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns> la univerciad con el alumno nuevo si pudo cargarlo 
        public static Universidad operator +(Universidad g, Alumno a)
        {
            try
            {
                if (g != a)
                {
                    g.Alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException("Este alumno ya se encuentra anotado a la clase");
                }
            }
            catch (AlumnoRepetidoException error)
            {
                throw new AlumnoRepetidoException("Alumno repetido",error);
            }
            return g;
        }
        /// <summary>
        /// sobrecarga del operador + para sumar un profesor a una universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>la universidad con el profesor si pudo cargarlo
        public static Universidad operator +(Universidad g, Profesor i)
        {

            if (g != i)
            {
                g.Instructores.Add(i);
            }

            return g;
        }
        /// <summary>
        /// sobrecarga del operador + suma una clase(jornada con profesor y alumnos) a la universidad
        /// lanza exeption si no puede conseguir un profesor para la clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>retorna la univerciadd con la jornada cargada si oudo ahcerlo 
        public static Universidad operator +(Universidad g, EClases clase)
        {
            try
            {
                Profesor profesorParaLaClase = (g == clase);
                Jornada jornadaNueva = new Jornada(clase, profesorParaLaClase);
                if(g.Alumnos != null)
                {
                    foreach (Alumno item in g.Alumnos)
                    {
                        if ( jornadaNueva != item && item == clase)
                        {
                            jornadaNueva = jornadaNueva + item;
                        }//else if(jornadaNueva != item)
                        //{
                        //    jornadaNueva.Alumnos.Add(item);
                        //}
                    }
                    g.Jornadas.Add(jornadaNueva);
                }
                return g;
            }
            catch (SinProfesorException error)
            {

                throw new SinProfesorException("No hay Profesor para la clase", error);
            }
            catch(Exception error)
            {
                throw new SinProfesorException("Error inesperado",error);
            }
           
            
        }
        /// <summary>
        /// guarda un archivo con los datos de la universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns> si pudo guardar los datos o no un bool con true o false
        public static bool Guardar(Universidad uni)
        {
            bool flag = false;
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                Xml<Universidad> xml = new Xml<Universidad>();
                flag = xml.Guardar(path + @"\ArchivoUnivercidad.xml", uni);
            }
            catch (Exception error)
            {
                throw new ArchivosException("no se pudo guardar el archivo", error);
            }
            return flag;
        }
        /// <summary>
        /// lee los datos de un path 
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>si pudo leer los datos o no un bool con true o false
        public bool Leer(Universidad uni)
        {
            bool flag = false;
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                Xml<Universidad> xml = new Xml<Universidad>();
                flag = xml.Leer(path + @"\ArchivoUnivercidad.xml", out uni);
            }
            catch (Exception error)
            {
                throw new ArchivosException("no se pudo leer el archivo", error);
            }
            return flag;
        }
        /// <summary>
        /// genera un string con los datos de las jornadas de la universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns> retorna el string generado
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder srt = new StringBuilder();

            //srt.AppendLine("Profesores :");
            //foreach (Profesor item in uni.Instructores)
            //{
            //    srt.AppendLine(item.ToString());
            //}

            //srt.AppendLine("Alumnos :");
            //foreach (Alumno item in uni.Alumnos)
            //{
            //    srt.AppendLine(item.ToString());
            //}

            srt.AppendLine("Jornadas :");
            foreach (Jornada item in uni.Jornadas)
            {
                srt.AppendLine("<---------------------------------------------->");
                srt.AppendLine(item.ToString());
                srt.AppendLine("<---------------------------------------------->");
            }

            return srt.ToString();
        }
        /// <summary>
        /// usa el metodo mostrar datos
        /// </summary>
        /// <returns></returns> retorna un string con los datos de univercidad
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
    }
}
