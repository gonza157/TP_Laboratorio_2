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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// crea dos dos objetos numero y se los pasa a otra funcion operar(que se encarga de hacer las operaciones)
        /// </summary>
        /// <param name="numero1">string con el valor a operar</param>
        /// <param name="numero2">string con el valor a operar</param>
        /// <param name="operador">string con el tipo de operador</param>
        /// <returns></returns>retorna un double con el valor resultado de la operacion
        private static double Operador(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            double respuesta = 0;
            respuesta = Calcucladora.Operar(n1, n2, operador);
            return respuesta;
        }
        /// <summary>
        /// limpia los textbox y el label del formCalculadora 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {


            //MessageBox.Show(this.txt_dato.Text);
            this.txtNumero1.Text = " ";
            this.txtNumero2.Text=" ";
            this.lblResultado.Text = " ";
        }
        /// <summary>
        /// Cierra el programa al precionar el booton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Combierte un numero decimal a Binario al precionar el booton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvertiraBinario_Click(object sender, EventArgs e)
        {
                string respuesta;
                respuesta = lblResultado.Text;
                Numero resultado = new Numero(respuesta);
                lblResultado.Text= resultado.DecimalBinario(respuesta);
        }
        /// <summary>
        /// Combierte un binario a decimal al hacer clic en el booton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvertiraDecimal_Click(object sender, EventArgs e)
        {
                string respuesta;
                respuesta = lblResultado.Text;
                Numero resultado = new Numero(respuesta);
                lblResultado.Text = resultado.BinarioADecimal(respuesta);
        }
        /// <summary>
        /// Llama al metodo antes creeado para operar al clickear en el booton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOperar_Click(object sender, EventArgs e)
        {
            double respuesta = 0;
           respuesta = Operador(this.txtNumero1.Text, this.txtNumero2.Text,cmbOpérador.Text);
            lblResultado.Text = respuesta.ToString();
        }

    }
}
