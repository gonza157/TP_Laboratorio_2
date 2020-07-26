using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Exepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Xml()
        {

        }
        /// <summary>
        /// metodo para guardar archivos generico
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns> guarda los datos en un archivo
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer;
            XmlSerializer ser;
            bool flag = false;
            writer = new XmlTextWriter(archivo, System.Text.Encoding.UTF8);
            try
            {
                ser = new XmlSerializer(typeof(T));
                ser.Serialize(writer, datos);
                flag = true;
            }
            catch (Exception error)
            {
                flag = false;
                throw new ArchivosException("No se pudo serializar el archivo", error);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
            return flag;

        }
        /// <summary>
        /// metodo para Leer archivos generico
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns> retorna los datos dleidos 
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader;
            XmlSerializer ser;
            bool flag = false;
            reader = new XmlTextReader(archivo);
            datos = default(T);
            try
            {
                ser = new XmlSerializer(typeof(T));
                datos = (T)ser.Deserialize(reader);
                flag = true;
            }
            catch (Exception error)
            {
                flag = false;
                throw new ArchivosException("No se pudo deserializar el archivo", error);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return flag;
        }
    }
}
