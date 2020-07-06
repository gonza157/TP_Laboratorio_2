using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Metodo de extension de string que guardará en un archivo de texto en el escritorio de la máquina.
        /// Si el archivo existe, agregará información en él.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns>bool si pudo o no hacerlo</returns>
        public static bool Guardar(this string texto, string archivo)
        {

            bool retorno = true;
            StreamWriter guardar = null;
            try
            {
                string pathEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);//devuelve la ruta del escritorio
                StringBuilder path = new StringBuilder();
                path.Append(pathEscritorio);
                path.AppendFormat("\\{0}", archivo);
                guardar = new StreamWriter(path.ToString(), true);
                guardar.WriteLine(texto); ;
                guardar.Close();
            }
            catch(Exception error)
            {
                throw new Exception("error al guardar",error);
            }
            finally
            {
                retorno = false;
                if (guardar != null)
                {
                    guardar.Close();
                }
            }
            return retorno;
        }
    }
}
