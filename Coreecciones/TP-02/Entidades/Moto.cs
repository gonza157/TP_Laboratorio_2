using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        /// <summary>
        /// Carga todos los parametros en la instancia del objeto moto
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Moto(string chasis,EMarca marca, ConsoleColor color) :base(chasis,marca,color)
        {
        }

        /// <summary>
        /// Las motos son chicas
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        /// <summary>
        /// Publica todos los datos de la moto.
        /// </summary>
        /// <returns>string con todos los datos </returns>
        public override  string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
                       
            sb.AppendLine("MOTO");
            sb.AppendLine($"{base.Mostrar()}");
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
