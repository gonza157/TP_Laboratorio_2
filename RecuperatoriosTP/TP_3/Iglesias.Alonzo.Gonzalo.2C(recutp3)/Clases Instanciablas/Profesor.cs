using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exepciones;
using EntidadesAbstractas;

namespace Clases_Instanciablas
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> claseDelDia;
        static Random random;
        /// <summary>
        /// constructor de instancia// inicio la queue;
        /// </summary>
        public Profesor()
        {
            this.claseDelDia = new Queue<Universidad.EClases>();
        }
        /// <summary>
        /// constructor estatico// para inicializar el random 
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// constructor de instancia con todos los campos //
        /// uso el random para elegir dos clases al asar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseDelDia = new Queue<Universidad.EClases>();
            this.claseDelDia.Enqueue((Universidad.EClases)random.Next(3));
            this.claseDelDia.Enqueue((Universidad.EClases)random.Next(3));
        }
        /// <summary>
        /// sobrecarga del operador == para profesor y clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns> retorna true si el profesor puede dar la clase 
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool flag = false;
            foreach (Universidad.EClases item in i.claseDelDia)
            {
                if (item == clase)
                {
                    flag = true;
                }
            }
            return flag;
        }
        /// <summary>
        /// sobrecarga del operador != (profesoir y clase)
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns> retorna un profesor que no puede dar la clase que esta por parametro
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        /// <summary>
        /// genera un string con la clase del dia del profesor 
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder srt = new StringBuilder();

            srt.AppendLine("CLASES DEL DIA :");
            foreach (Universidad.EClases item in this.claseDelDia)
            {
                srt.AppendLine($"{item}");
            }

            return srt.ToString();
        }
        /// <summary>
        /// genera un strin con todos los datos ddel profesor
        /// </summary>
        /// <returns></returns>el string con los datos 
        protected override string MostrarDatos()
        {
            StringBuilder srt = new StringBuilder();

            srt.AppendLine($"Nacionalidad :{this.Nacionalidad}");
            srt.AppendLine($"");
            srt.AppendLine($"{base.MostrarDatos()}");
            srt.Append($"{this.ParticiparEnClase()}");
            return srt.ToString();
        }
        /// <summary>
        /// genera un string apartidr del metodo mostrardato
        /// </summary>
        /// <returns></returns>retorna el string con los datos 
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
