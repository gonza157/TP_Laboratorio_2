using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo; 

        public FrmPpal()
        {
            InitializeComponent();
        }

        private void FrmPpal_Load(object sender, EventArgs e)
        {
            this.correo = new Correo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete nuevoPaquete = new Paquete(txtDireccion.Text, mtxtTrakingID.Text);
            nuevoPaquete.InformaEstado += paq_InformaEstado;
            try
            {
                correo = correo + nuevoPaquete;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
                this.ActualizarEstados();            
        }


        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostar<List<Paquete>>)correo);
        }

        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach (Paquete item in this.correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(item);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(item);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(item);
                        break;
                }
            }
        }



        private void MostrarInformacion<T>(IMostar<T> elemento)
        {

            try
            {
                if (elemento != null)
                {
                    string aux = elemento.MostrarDatos(elemento);
                    this.rtbMostrar.Text = aux;
                    aux.Guardar("salida.txt");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("no se pudo guardar el listado");
            }
        }

        private void MostarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

       
    }
}
