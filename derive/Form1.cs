using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace derive
{

    public partial class Form1 : Form
    {

        public string funcion;
        public int cuanto;
        public int contador = 0;
        public int TotalMono = 0;
        public char[] operadores = { '+', '-' };
        public char[] grado = { 'x', '^' };
        private object formGraphics;
        public string submono;
        public string [] parte;
        public int TotalParte;
        public int MaxGrado;
        public int multi;
        
        public Form1()
        {
            InitializeComponent();
            panel1.BackColor = Color.Black;
        }
        System.Drawing.Pen Lapiz = new System.Drawing.Pen(System.Drawing.Color.Blue);

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics formGraphics = panel1.CreateGraphics();
            if (string.IsNullOrEmpty(textBox1.Text) || string.Format(textBox1.Text) == "Ingrese f(x) aquí") {
                MessageBox.Show("Ingrese una funcion! \n");
            }
            else
            {
                funcion = (textBox1.Text);
                cuanto = funcion.Length; //cuantos caracteres tiene la funcion
                string[] mono = funcion.Split(operadores); //le paso la cadena separada por + y -
                TotalMono = mono.Length;
                
                for (int i=0; i < TotalMono;i++)
                {                   
                    submono = mono[i];
                    parte = submono.Split(grado);   //separo por 'x' y '^' a monomio
                    TotalParte = parte.Length;
                    for (int p=0; p < TotalParte; p++)
                    {

                        MessageBox.Show("probando" + parte[p]);
                        
                    }
                    MessageBox.Show("paso!");
                    
                }
                
                for (int i = 0; i < TotalMono; i++)
                {
                    if (funcion[i] == 'a'){
                        contador += 1;
                    }

                    MessageBox.Show("La derivada es \n" + mono[i]);
                    MessageBox.Show("test formato" + formato(funcion));
                }
                //MessageBox.Show("La derivada es \n" + contador);
                textBox2.Text = Convert.ToString(contador);
                //formGraphics.DrawLine(Lapiz, 0, 100, 550, 100);
                //formGraphics.DrawLine(Lapiz, 0, 100, 550, 100);
                //double[] x = new double[1000];
                //double[] y = new double[1000];

            }

        }
        //private int algo = Math. 
        public string formato(string funcion)
        {
            string salir = "";
            funcion = Convert.ToString(funcion);

            int j = 0;
            for (int i = 0; i < funcion.Length; i++)
            {
                if (funcion[i] == '-' || funcion[i] == '+' && i > 1)
                {
                    if (funcion[i - 1] != '^')
                    {
                        salir += funcion.Substring(j, i - 1) + " ";
                        j = i;
                    }
                }
            }
            salir += funcion.Substring(j, funcion.Length - j);
            return salir;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)      //dibujo el grafico + para la funcion
        {
            int xcentro = panel1.Width / 2;
            int ycentro = panel1.Height / 2;
            e.Graphics.TranslateTransform(xcentro, ycentro);
            e.Graphics.ScaleTransform(1, - 1);
            e.Graphics.DrawLine(Lapiz, xcentro * -1, 0, xcentro * 2, 0); //ejex
            e.Graphics.DrawLine(Lapiz, 0, ycentro, 0, ycentro * -1); // ejey
        }

       
    }
}
