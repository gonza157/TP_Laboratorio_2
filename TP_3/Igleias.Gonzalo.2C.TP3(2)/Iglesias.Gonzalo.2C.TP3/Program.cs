using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;

namespace Iglesias.Gonzalo._2C.TP3
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona p = new Persona("Gonzalo","iglesias",39715929,Persona.ENacionalidad.Argentina);

            Console.WriteLine(p.ToString());
            Console.ReadKey();
           /* try
            {
                p.Nombre = "Matia?s";
                p.Apellido = "palmieri";
                p.Nacionalidad = Persona.ENacionalidad.extranjero;

                p.StringToDNI = "13";
                // p.DNI = 90000000;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            finally
            {

            }*/
        }
    }
}
