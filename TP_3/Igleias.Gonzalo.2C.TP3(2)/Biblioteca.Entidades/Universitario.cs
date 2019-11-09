using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;

namespace Biblioteca.Entidades
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(this.GetType() == obj.GetType())
            {
                retorno = true;
            }
            return retorno;
        }


        public static bool operator !=(Universitario pg1, Universitario pg2)
        {

            return !(pg1 == pg2);
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if(pg1.Equals(pg2) && pg1.Dni == pg2.Dni || (pg1.legajo == pg2.legajo))
            {
                retorno = true;
            }
            return retorno;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder srt = new StringBuilder();
            
            srt.AppendLine(base.ToString());
            srt.AppendLine(this.legajo.ToString());

            return srt.ToString();
        }

        protected abstract string ParticiparEnclase();

        public Universitario()
        {

        }
        public Universitario(int legajo,string nombre,string apellido,string dni,Persona.ENacionalidad nacionalidad) : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
    }
}
