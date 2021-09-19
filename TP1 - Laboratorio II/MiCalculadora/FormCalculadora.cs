using System;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        ///Inicializa el Formulario
        public FormCalculadora()
        {
            InitializeComponent();
        }

        #region EVENTOS

        //Al iniciar el Formulario se llamara al metodo encargado de limpiar los campos
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        //Al Clickear el boton "limpiar" se llamara al metodo encargado de limpiar los campos
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        //Al clickear el boton "operar" se chequea que los textbox ni el combobox esten vacios
        private void btnOperar_Click(object sender, EventArgs e)
        {
            //Si los textbox y el combobox contienen datos, se enviaran al metodo operar
            //El resultado es convertido a string y se almacena en el label
            if (txtNumero1.Text != string.Empty && txtNumero2.Text != string.Empty && cmbOperador.Text != string.Empty)
            {
                lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
                lstOperaciones.Items.Add($"{txtNumero1.Text} {cmbOperador.Text} {txtNumero2.Text} = {lblResultado.Text}");
            }
        }

        //Al Clickear el boton "cerrar" se ejecutara el cierre del programa
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Al Clickear el boton "convertir a binario" se enviara el label del resultado al metodo DecimalBinario de Operando
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operando.DecimalBinario(lblResultado.Text);
        }

        //Al Clickear el boton "convertir a decimal" se enviara el label del resultado al metodo BinarioDecimal de Operando
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operando.BinarioDecimal(lblResultado.Text);
        }

        //Al intentar cerrar el formulario se preguntara una confirmacion al usuario
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea salir?", "Close Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //Si el usuario indica que no quiere salir, se cancela el evento y se continua la ejecucion del programa, else innecesario. La unica opcion es Si
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        #endregion

        #region METODOS

        //Limpia los textbox y el combobox de la calculadora. Setea el label del resultado en "0"
        private void Limpiar()
        {
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            cmbOperador.Text = string.Empty;
            lblResultado.Text = "0";
        }

        //Recibe dos strings de numeros y un string de operador. Envia al constructor de operandos los numeros y envia los datos al metodo Operar de Calculadora
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
            Operando operando1 = new Operando(numero1);
            Operando operando2 = new Operando(numero2);

            resultado = Calculadora.Operar(operando1, operando2, operador[0]); //Llamo al metodo Operar de Calculadora, enviando ambos operandos y el primer caracter del string operador
            
            return resultado;
        }

        #endregion
    }
}
