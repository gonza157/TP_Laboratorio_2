using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public sealed class Alumno : Universitario
    {

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        protected override string MostrarDatos()
        {
            StringBuilder srt = new StringBuilder();

            srt.AppendLine(base.ToString());
            srt.AppendLine(this.claseQueToma.ToString());
            srt.AppendLine(this.estadoCuenta.ToString());

            return srt.ToString();
        }

        protected override string ParticiparEnclase()
        {
            StringBuilder srt = new StringBuilder();

            srt.AppendFormat("TOMA CLASE DE: {0}", this.claseQueToma);

            return srt.ToString();
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if (a.claseQueToma != clase )
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
                {
                retorno = true;
                }
            return retorno;
        }

        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        public override string ToString()
        {

            return this.MostrarDatos();
        }
    }
}
