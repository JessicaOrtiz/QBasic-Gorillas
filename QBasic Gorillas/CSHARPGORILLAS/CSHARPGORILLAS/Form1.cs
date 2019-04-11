using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CSHARPGORILLAS
{
    public partial class Form1 : Form
    {
        int tiempo = 0;
        int jugador = 1;
        List<Image> listEdificios = new List<Image>();
        List<int> tamaños = new List<int>();
        int tamImagen = 75;

        public Form1()
        {
            InitializeComponent();
            CreaEscenario();
            label1.Text ="Turno jugador 1";
            this.MaximizeBox =false;
            timer1.Start();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CreaEscenario()
        {
            string dir = Directory.GetCurrentDirectory();
            int posSol = 0;
            int posSol2 = 0;
            int ancho = this.Size.Width;
            var seed = Environment.TickCount;
            var random = new Random(seed);

            while(posSol == posSol2)
            {
                posSol = random.Next(1, (int)ancho / tamImagen);
                posSol2 = random.Next(1, (int)ancho / tamImagen);
            }

           

            for (int i = 0; i <(int) ancho/tamImagen; i++)
            {
               
                PictureBox pic = new PictureBox();
                string edificio = "Edificio" + random.Next(1, 7).ToString() + ".png";
                Image img = Image.FromFile(dir + @"\edificios\" + edificio);
                pic.Name = "pic";
                int tam = random.Next(30, 200);
                pic.Size = new Size(tamImagen, tamImagen + tam);
                pic.Location = new Point(posicion(i), this.Height - (tamImagen+tam));
                if (i == posSol)
                {
                    PictureBox picS1 = new PictureBox();
                    Image imgS1;
                    if (posSol > posSol2)
                         imgS1= Image.FromFile(dir + @"\Personajes\soldado2.png");
                    else
                         imgS1 = Image.FromFile(dir + @"\Personajes\soldado.png");
                    picS1.Name = "PicS1";
                    picS1.Size = new Size(28, 36);
                    picS1.Location = new Point(posicion(i)+30, this.Height - (tamImagen + tam)-36);
                    picS1.Image = new System.Drawing.Bitmap(imgS1);
                    picS1.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(picS1);
                }
                if(i == posSol2)
                {
                    PictureBox picS2 = new PictureBox();
                    Image imgS2;
                    if (posSol < posSol2)
                        imgS2 = Image.FromFile(dir + @"\Personajes\soldado2.png");
                    else
                        imgS2 = Image.FromFile(dir + @"\Personajes\soldado.png");
                    picS2.Name = "PicS2";
                    picS2.Size = new Size(28, 36);
                    picS2.Location = new Point(posicion(i) + 37, this.Height - (tamImagen + tam) - 36);
                    picS2.Image = new System.Drawing.Bitmap(imgS2);
                    picS2.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(picS2);
                }


                pic.ImageLocation = dir + @"\edificios\" + edificio;
                pic.Image = new System.Drawing.Bitmap(img);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(pic);
            }

            
            int t = 0;


        }


        private int posicion(int ii)
        {
            int tam=0;

            for(int i = 0; i < ii; i++)
            {
                tam += tamImagen;
            }
            return tam;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tiempo++;
            if (tiempo > 100)
            {
                timer1.Stop();
                if (jugador == 1) 
                    jugador =2;
                else 
                    jugador =1;
                establece(jugador);
                timer1.Start();

            }
        }


        private void establece(int num)
        {
            label1.Text = "Turno del jugador" + num.ToString();
            tiempo = 0;

            if (num == 2)
            {       
                label2.Location = new Point(label2.Location.X + 600, label2.Location.Y);
                textBox1.Location = new Point(textBox1.Location.X + 600, textBox1.Location.Y);
                label3.Location = new Point(label3.Location.X + 600, label3.Location.Y);
                textBox2.Location = new Point(textBox2.Location.X + 600, textBox2.Location.Y);
            }
            else
            {             
                label2.Location = new Point(label2.Location.X - 600, label2.Location.Y);
                textBox1.Location = new Point(textBox1.Location.X -600, textBox1.Location.Y);
                label3.Location = new Point(label3.Location.X - 600, label3.Location.Y);
                textBox2.Location = new Point(textBox2.Location.X - 600, textBox2.Location.Y);
            }
        }


        private void pictureA2_Click(object sender, EventArgs e)
        {   
                textBox2.Text = 60.ToString();
        }

        private void pictureA1_Click(object sender, EventArgs e)
        {    
                textBox2.Text = 20.ToString();
        }

        private void pictureA3_Click(object sender, EventArgs e)
        {      
                textBox2.Text = 90.ToString();
        }

        private void pictureA4_Click(object sender, EventArgs e)
        {          
                textBox2.Text = 45.ToString();
        }

        private void picturea5_Click(object sender, EventArgs e)
        {
                textBox2.Text = 84.ToString();
        }
    }
}
