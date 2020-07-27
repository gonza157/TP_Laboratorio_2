using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Texto()
        {

        }
        /// <summary>
        /// metodo para guardar archivos para texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            bool flag = false;
            StreamWriter srt = null;
            try
            {
                //if (File.Exists(archivo)
                srt = new StreamWriter(archivo);
                srt.Write(datos);
                flag = true;


            }
            catch (Exception)
            {
                flag = false;
            }
            finally
            {
                if (!(srt is null))
                {
                    srt.Close();
                }

            }
            return flag;
        }
        /// <summary>
        /// metodo para Leer archivos para texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool flag = false;
            StreamReader srt = null;
            datos = null;
            try
            {
                if (File.Exists(archivo))
                {
                    srt = new StreamReader(archivo);
                    datos = srt.ReadToEnd();
                    flag = true;
                }

            }
            catch (Exception)
            {
                flag = false;
            }
            finally
            {
                if (!(srt is null))
                {
                    srt.Close();
                }

            }
            return flag;
        }
    }
}
