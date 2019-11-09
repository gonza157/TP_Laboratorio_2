using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;

namespace Biblioteca.Entidades
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        public  Profesor()
        {

        }

        static Profesor()
        {
            random = new Random();
        }

        public Profesor(int id,string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad) : base(id,nombre,apellido,dni,nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        private void _randomClases()
        {
            int numero = -1;
            
            
            for (int i = 0; i < 2; i++)
            {
                numero = random.Next(0, 3);
                switch (numero)
                {
                    case 0:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;

                    case 1:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;

                    case 2:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Progamacion);
                        break;

                    case 3:
                        this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                }
            }

        }

        protected override string MostrarDatos()
        {
            StringBuilder srt = new StringBuilder();

            srt.AppendLine(base.ToString());
            srt.AppendLine(this.clasesDelDia.ToString());

            return srt.ToString();
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            
            foreach (Universidad.EClases claseC in i.clasesDelDia)
            {
                if(claseC == clase)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        protected override string ParticiparEnclase()
        {
            StringBuilder srt = new StringBuilder();

            srt.AppendFormat(" CLASE DEL DIA: {0}", this.clasesDelDia);

            return srt.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
