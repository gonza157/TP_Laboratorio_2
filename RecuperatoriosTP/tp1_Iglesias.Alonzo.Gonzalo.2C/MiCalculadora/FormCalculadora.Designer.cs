namespace MiCalculadora
{
    partial class FormCalculadora
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Operar = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.btn_CombertirABinario = new System.Windows.Forms.Button();
            this.btn_ConvertirADecimal = new System.Windows.Forms.Button();
            this.txt_Numero1 = new System.Windows.Forms.TextBox();
            this.txt_Numero2 = new System.Windows.Forms.TextBox();
            this.cbm_Operador = new System.Windows.Forms.ComboBox();
            this.lbl_Resultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Operar
            // 
            this.btn_Operar.Location = new System.Drawing.Point(12, 178);
            this.btn_Operar.Name = "btn_Operar";
            this.btn_Operar.Size = new System.Drawing.Size(127, 36);
            this.btn_Operar.TabIndex = 2;
            this.btn_Operar.Text = "Operar";
            this.btn_Operar.UseVisualStyleBackColor = true;
            this.btn_Operar.Click += new System.EventHandler(this.btn_Operar_Click);
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Location = new System.Drawing.Point(143, 178);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(127, 36);
            this.btn_Limpiar.TabIndex = 3;
            this.btn_Limpiar.Text = "Limpiar";
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Location = new System.Drawing.Point(276, 178);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(127, 36);
            this.btn_Cerrar.TabIndex = 4;
            this.btn_Cerrar.Text = "Cerrar";
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // btn_CombertirABinario
            // 
            this.btn_CombertirABinario.Location = new System.Drawing.Point(12, 229);
            this.btn_CombertirABinario.Name = "btn_CombertirABinario";
            this.btn_CombertirABinario.Size = new System.Drawing.Size(193, 42);
            this.btn_CombertirABinario.TabIndex = 5;
            this.btn_CombertirABinario.Text = "Convertir a Binario";
            this.btn_CombertirABinario.UseVisualStyleBackColor = true;
            this.btn_CombertirABinario.Click += new System.EventHandler(this.btn_CombertirABinario_Click);
            // 
            // btn_ConvertirADecimal
            // 
            this.btn_ConvertirADecimal.Location = new System.Drawing.Point(210, 229);
            this.btn_ConvertirADecimal.Name = "btn_ConvertirADecimal";
            this.btn_ConvertirADecimal.Size = new System.Drawing.Size(193, 42);
            this.btn_ConvertirADecimal.TabIndex = 6;
            this.btn_ConvertirADecimal.Text = "Convertir a Decimal";
            this.btn_ConvertirADecimal.UseVisualStyleBackColor = true;
            this.btn_ConvertirADecimal.Click += new System.EventHandler(this.btn_ConvertirADecimal_Click);
            // 
            // txt_Numero1
            // 
            this.txt_Numero1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Numero1.Location = new System.Drawing.Point(12, 82);
            this.txt_Numero1.Name = "txt_Numero1";
            this.txt_Numero1.Size = new System.Drawing.Size(127, 35);
            this.txt_Numero1.TabIndex = 0;
            // 
            // txt_Numero2
            // 
            this.txt_Numero2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Numero2.Location = new System.Drawing.Point(276, 82);
            this.txt_Numero2.Name = "txt_Numero2";
            this.txt_Numero2.Size = new System.Drawing.Size(127, 35);
            this.txt_Numero2.TabIndex = 1;
            // 
            // cbm_Operador
            // 
            this.cbm_Operador.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbm_Operador.FormattingEnabled = true;
            this.cbm_Operador.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.cbm_Operador.Location = new System.Drawing.Point(164, 82);
            this.cbm_Operador.Name = "cbm_Operador";
            this.cbm_Operador.Size = new System.Drawing.Size(89, 37);
            this.cbm_Operador.TabIndex = 7;
            // 
            // lbl_Resultado
            // 
            this.lbl_Resultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Resultado.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_Resultado.Location = new System.Drawing.Point(12, 34);
            this.lbl_Resultado.Name = "lbl_Resultado";
            this.lbl_Resultado.Size = new System.Drawing.Size(391, 29);
            this.lbl_Resultado.TabIndex = 8;
            this.lbl_Resultado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 287);
            this.Controls.Add(this.lbl_Resultado);
            this.Controls.Add(this.cbm_Operador);
            this.Controls.Add(this.txt_Numero2);
            this.Controls.Add(this.txt_Numero1);
            this.Controls.Add(this.btn_ConvertirADecimal);
            this.Controls.Add(this.btn_CombertirABinario);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.btn_Limpiar);
            this.Controls.Add(this.btn_Operar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de Gonzalo Iglesias Alonzo del curso 2°C";
            this.Load += new System.EventHandler(this.FormCalculadora_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Operar;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.Button btn_CombertirABinario;
        private System.Windows.Forms.Button btn_ConvertirADecimal;
        private System.Windows.Forms.TextBox txt_Numero1;
        private System.Windows.Forms.TextBox txt_Numero2;
        private System.Windows.Forms.ComboBox cbm_Operador;
        private System.Windows.Forms.Label lbl_Resultado;
    }
}

