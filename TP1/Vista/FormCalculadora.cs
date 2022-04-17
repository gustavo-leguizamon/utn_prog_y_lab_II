using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Reinicia los controles TextBox, Label y ComboBox
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            lblResultado.Text = string.Empty;
            cmbOperador.SelectedIndex = 0;
        }


        /// <summary>
        /// Realiza la operacion seleccionada
        /// </summary>
        /// <param name="numero1">Operando A</param>
        /// <param name="numero2">Operando B</param>
        /// <param name="operador">Tipo de operacion</param>
        /// <returns>Resultado de la operacion</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Operando(numero1), new Operando(numero2), operador[0]);
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string valor1 = txtNumero1.Text;
            string valor2 = txtNumero2.Text;
            string operador = string.Empty;
            if (cmbOperador.SelectedItem is not null)
            {
                operador = (string)cmbOperador.SelectedItem;
            }
            double resultado = Operar(valor1, valor2, operador);
            lblResultado.Text = resultado.ToString();
            lstOperaciones.Items.Add($"{valor1} {operador} {valor2} = {resultado}");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lblResultado.Text))
            {
                Operando operando = new Operando();
                string resultado = operando.DecimalBinario(lblResultado.Text);
                lstOperaciones.Items.Add($"{Math.Floor(Math.Abs(double.Parse(lblResultado.Text)))} a binario = {resultado}");
            }
        }
    }
}
