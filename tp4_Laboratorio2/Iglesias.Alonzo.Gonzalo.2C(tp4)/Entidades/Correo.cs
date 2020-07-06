using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo: IMostar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }
        /// <summary>
        /// constructor, se inicializan las listas
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        /// <summary>
        /// Suma un paquete al correo si no existe ya el mismo paquete con el mismo trackingID
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns>el correo con el paquete nuevo si pudo hacerlo</returns> 
        public static Correo operator +(Correo c, Paquete p)
        {
            bool repetido = false;
            foreach (Paquete item in c.Paquetes)
            {
                if (item == p)
                {
                    repetido = true;
                }
            }


            if (repetido == false)
            {
                c.Paquetes.Add(p);
                Thread nuevoHilo = new Thread(new ThreadStart(p.MockCicloDeVida));
                nuevoHilo.Start();
                c.mockPaquetes.Add(nuevoHilo);
            }
            else
            {
                throw new TrackingIdRepetidoExeption("Paquete Repetido");
            }
            return c;
        }
        /// <summary>
        /// se cirran los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread a in mockPaquetes)
            {
                if (a.IsAlive)
                {
                    a.Abort();
                }

            }
        }
        /// <summary>
        /// Muestra los datos de los paquetes del correo
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns>string con los datos</returns>  
        public string MostrarDatos(IMostar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete a in ((Correo)elementos).Paquetes)
            {
                sb.Append(string.Format("{0} para {1} ({2})\n", a.TrackingID, a.DireccionEntrega, a.Estado.ToString()));
            }

            return sb.ToString();
        }


    }
}
