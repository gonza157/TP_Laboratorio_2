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

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

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
