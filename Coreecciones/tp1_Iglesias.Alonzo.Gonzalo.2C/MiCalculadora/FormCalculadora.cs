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

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// verifica que los texbox tengan algo para operar y llama al metodo operar. De lo contrario imprime numero inbalido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Operar_Click(object sender, EventArgs e)
        {
            double resultado = 0;
            if(this.txt_Numero1.Text != "" && this.txt_Numero2.Text != "")
            {
                resultado = Operar(this.txt_Numero1.Text,this.txt_Numero2.Text,this.cbm_Operador.Text);
                this.lbl_Resultado.Text = resultado.ToString();
            }
            else
            {
                this.lbl_Resultado.Text = "Numero Invalido";
            }
        }
        /// <summary>
        /// llama al metodo limpiar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        /// <summary>
        /// cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// si el label tiene un resultado y se puede realizar la operacion lo conbierte en binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CombertirABinario_Click(object sender, EventArgs e)
        {
            if(this.lbl_Resultado.Text != "")
            {
                Numero aux = new Numero();
                this.lbl_Resultado.Text = aux.DecimalBinario(this.lbl_Resultado.Text);
            }
        }
        /// <summary>
        /// si el label tiene un resultado y se puede realizar la operacion lo conbierte en decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (this.lbl_Resultado.Text != "" )
            {
                Numero aux = new Numero();
                this.lbl_Resultado.Text = aux.BinarioDecimal(this.lbl_Resultado.Text);
            }
        }
        /// <summary>
        /// metodo que limpia los texbox el label y el combobox
        /// </summary>
        private void Limpiar()
        {
            this.txt_Numero1.Text = "";
            this.txt_Numero2.Text = "";
            this.lbl_Resultado.Text = "";
            this.cbm_Operador.Text = "";
        }
        /// <summary>
        /// si es posible hace la operacion especificada entre los valores que le pasan por parametro 
        /// </summary>
        /// <param name="numero1">numero a operar</param>
        /// <param name="numero2">numero a operar</param>
        /// <param name="operador"> devuleve el resultado en un double</param>
        /// <returns></returns>
        public static double Operar(string numero1 , string numero2, string operador)
        {
            Calculadora calculadoraAux = new Calculadora();
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
                        
            return calculadoraAux.Operar(n1, n2, operador);
        }

    }
}
