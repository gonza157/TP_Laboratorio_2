using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

         public  enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.TrackingID = trackingID;
            this.DireccionEntrega= direccionEntrega;
            this.Estado = EEstado.Ingresado;
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool flag = false;
            if (p1.TrackingID == p2.TrackingID)
            {
                flag = true;
            }
            return flag;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1==p2);
        }
        /// <summary>
        /// hará que el paquete cambie de estado
        ///a. Colocar una demora de 4 segundos.
        ///b.Pasar al siguiente estado.
        ///c.Informar el estado a través de InformarEstado. EventArgs no tendrá ningún dato extra.
        ///d.Repetir las acciones desde el punto A hasta que el estado sea Entregado.
        ///e.Finalmente guardar los datos del paquete en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            Thread.Sleep(4000);
            this.Estado = EEstado.EnViaje;
            this.InformaEstado.Invoke(this, EventArgs.Empty);
            Thread.Sleep(4000);
            this.Estado = EEstado.Entregado;
            this.InformaEstado.Invoke(this, EventArgs.Empty);
            PaqueteDAO.Insertar(this);
        }
        /// <summary>
        /// Muestra la info de un paquete , implementa la interfaz IMostrar
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>string con los datos </returns>
        public string MostrarDatos(IMostar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;
            return string.Format("{0} para {1}\n", p.TrackingID, p.DireccionEntrega);
        }
        /// <summary>
        /// reutiliza el metodo mostrar datos 
        /// </summary>
        /// <returns> string con los datos </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.MostrarDatos(this));

            return sb.ToString();
        }


    }
}
