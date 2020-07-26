using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    interface IArchivo<T>
    {
        /// <summary>
        /// metodo para guardar archivos generico
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>si pudo o no guardarlo
        bool Guardar(string archivo, T datos);
        /// <summary>
        /// metodo para leer generico
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns> retorna si pudo o no leerlo
        bool Leer(string archivo, out T datos);
    }
}
