using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUevoEulerMejorado
{
    public partial class Form1 : Form
    {
        double x, Cifras, ValorReal, ValorAprox, ErrorAprox, ValorAnterior;
        int Iteraciones,n;

        private void CalculoDeCifras()
        {
            Cifras = Convert.ToDouble(txtN.Text);
            Cifras = 1 / Math.Pow(10, Cifras);
            txtCifras.Text = Cifras.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public static void BloqueaNum(KeyPressEventArgs pE)
        {
            //Para obligar a que sólo se introduzcan números

            if (Char.IsDigit(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (Char.IsControl(pE.KeyChar)) //permitir teclas de control como retroceso
            {
                pE.Handled = false;
            }
            else if (Char.IsWhiteSpace(pE.KeyChar)) //no permitir teclas de control como espacio
            {
                pE.Handled = true;
            }
            else if (pE.KeyChar == '-')//permitir tecla -
            {
                pE.Handled = false;
            }
            else if (Char.IsPunctuation(pE.KeyChar))// permitir teclas de puntuacion
            {
                pE.Handled = false;
            }
            else //el resto de teclas pulsadas se desactivan
            {
                pE.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            if (MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
            else
            {
                this.pictureBox1.Focus();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void txtX_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloqueaNum(e);
        }

        private void txtN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtN_KeyPress(object sender, KeyPressEventArgs e)
        {
            BloqueaNum(e);
        }

        private void btnLimpia_Click(object sender, EventArgs e)
        {
            Limpia();
        }

        private void Limpia()
        {
            txtCifras.Clear();
            txtErrorAprox.Clear();
            txtIteraciones.Clear();
            txtN.Clear();
            txtValorA.Clear();
            txtX.Clear();
            txtValorR.Clear();
            txtX.Focus();
        }

        private void CalculoValorReal()
        {
            x = Convert.ToDouble(txtX.Text);
            ValorReal = Math.Pow(2.7182, x);
            txtValorR.Text = ValorReal.ToString();
        }
        private double factorial(double a)
        {
            if (a == 0)
            {
                return 1;
            }
            else
            {
                return a * factorial(a - 1);
            }
        }
        private void Iteracion()
        {
            ValorAprox = 1 + x;
            Iteraciones = 1;
            while (ValorAprox + Cifras <= ValorReal)
            {
                Iteraciones = Iteraciones + 1;
                ValorAnterior = ValorAprox;
                ValorAprox = ValorAprox + Math.Pow(x, Iteraciones) / factorial(Iteraciones);
                ErrorAprox = ((ValorAprox - ValorAnterior) / ValorAprox) * 100;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //calculo de cifras
                CalculoDeCifras();
                //definir valor real
                CalculoValorReal();
                ValorAprox = 1;
                //pasos
                Iteracion();
                //printf xd
                txtValorA.Text = ValorAprox.ToString();
                txtIteraciones.Text = Iteraciones.ToString();
                txtErrorAprox.Text = ErrorAprox.ToString();

            }
            catch
            {
                MessageBox.Show ("Por favor Ingrese los valores");
                Limpia();
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }
    }
}
