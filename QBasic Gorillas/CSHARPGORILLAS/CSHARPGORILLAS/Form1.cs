using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        private int DESPLAZAMIENTOX; // DISTANCIA RECORRIDA EN EL EJE X
        private int TIEMPO; // TIEMPO TOMADO PARA LOS CALCULOS
        private ArrayList ARRAYX = new ArrayList(); // DATOS DE X EN FUNCION DEL TIEMPO
        private ArrayList ARRAYY = new ArrayList(); // DATOS DE Y EN FUNCION DEL TIEMPO
        private int CONTADOR = 0; // CONTADOR DE PASO DE TIEMPO

        Button btn1 = new Button();
        Button btn2 = new Button();
        Button btn = new Button();
        Button btnSalir = new Button();
        Label titulo = new Label();

        PictureBox picS2 = new PictureBox();
        Image imgS2;

        public Form1()
        {
            InitializeComponent();
            /* CreaEscenario();
             label1.Text ="Turno jugador 1";
             this.MaximizeBox =false;
             timer1.Start();*/
            inicio();
            button1_click();
            button2_click();
        }

        //Evento de Click en el boton
        //Al hacer click crea los componentes necesarios para iniciar el juego.
        void button1_click()
        {
            btn1.Click += (sender, args) =>
            {
                componentes_inicio_false();
                CreaEscenario();
                label1.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                pictureA1.Visible = true;
                pictureA2.Visible = true;
                pictureA3.Visible = true;
                pictureA4.Visible = true;
                picturea5.Visible = true;
                btnSalir.Visible = true;
                timer1.Start();
            };
        }

        void button2_click()
        {
            btn2.Click += (sender, args) =>
            {
                //Image fondo = new Bitmap(@"C:\Users\c\source\repos\Gorilas\Gorilas\fondo.jpg");
                componentes_inicio_false();
                vista_records();
                //this.BackgroundImage = fondo;
            };
        }

        void button3_click()
        {
            btn.Click += (sender, args) =>
            {
                //Image fondo = new Bitmap(@"C:\Users\c\source\repos\Gorilas\Gorilas\fondo1.jpg");
                componentes_inicio_true();
                vista_records();
                componentes_records();
                //this.BackgroundImage = fondo;
            };
        }

        void button4_click()
        {
            btnSalir.Click += (sender, args) =>
            {
                componentes_juego();
                //Image fondo = new Bitmap(@"C:\Users\c\source\repos\Gorilas\Gorilas\fondo1.jpg");
                componentes_inicio_true();
                //this.BackgroundImage = fondo;

                componentes_dinamicos_false();
                btnSalir.Visible = false;

                /*  pic.Visible = false;
                  picS1.Visible = false;
                  picS2.Visible = false;
                  imgS1 = null;
                  imgS2 = null;*/
            };
        }

        private void boton_salir()
        {
            btnSalir.Text = "Salir";
            btnSalir.Visible = true;
            btnSalir.BackColor = Color.FromArgb(244, 208, 63);
            btnSalir.Location = new System.Drawing.Point(810, 10);

            this.Controls.Add(btnSalir);
        }

        //Quita los componentes del menu de inicio
        private void componentes_inicio_false()
        {
            btn1.Visible = false;
            btn2.Visible = false;
            this.BackgroundImage = null;
        }

        private void componentes_inicio_true()
        {
           // Image fondo = new Bitmap(@"C:\Users\c\source\repos\Gorilas\Gorilas\fondo.jpg");
            btn1.Visible = true;
            btn2.Visible = true;
            //this.BackgroundImage = null;
        }

        private void inicio()
        {
            btn1.Text = "Iniciar";
            btn1.Location = new System.Drawing.Point(454, 200);
            btn1.BackColor = Color.FromArgb(244, 208, 63);
            btn1.Visible = true;

            btn2.Text = "Records";
            btn2.Location = new System.Drawing.Point(454, 226);
            btn2.BackColor = Color.FromArgb(244, 208, 63);
            btn2.Visible = true;

            this.Controls.Add(btn1);
            this.Controls.Add(btn2);

            componentes_juego();
        }

        private void componentes_juego()
        {
            label1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            pictureA1.Visible = false;
            pictureA2.Visible = false;
            pictureA3.Visible = false;
            pictureA4.Visible = false;
            picturea5.Visible = false;


           
        }

        private void componentes_dinamicos_false()
        {
            for (int i = 0; i < (int)this.Size.Width / tamImagen; i++)
            {
                PictureBox PB = new PictureBox();
                PictureBox PB1 = new PictureBox();
                PB = this.Controls.OfType<PictureBox>().FirstOrDefault(x => x.Name == "pic" + i.ToString());
                this.Controls.Remove(PB);
                if (i == 1 || i == 2)
                {
                    PB1 = this.Controls.OfType<PictureBox>().FirstOrDefault(x => x.Name == "PicS" + i.ToString());
                    this.Controls.Remove(PB1);
                }
            }

        }

        private void vista_records()
        {
            titulo.Size = new Size(210, 70);
            titulo.Font = new Font(titulo.Font.FontFamily, 36f, titulo.Font.Style);
            titulo.Text = "Records";
            titulo.Visible = true;
            titulo.Location = new System.Drawing.Point(380, 50);
            titulo.AutoSize = false;

            btn.Text = "Menú";
            btn.Visible = true;
            btn.Location = new System.Drawing.Point(810, 10);
            btn.BackColor = Color.FromArgb(244, 208, 63);

            this.Controls.Add(titulo);
            this.Controls.Add(btn);

            button3_click();
        }

        void componentes_records()
        {
            btn.Visible = false;
            titulo.Visible = false;
            this.BackgroundImage = null;
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

            boton_salir();
            for (int i = 0; i <(int) ancho/tamImagen; i++)
            {
               
                PictureBox pic = new PictureBox();
                string edificio = "Edificio" + random.Next(1, 7).ToString() + ".png";
                Image img = Image.FromFile(dir + @"\edificios\" + edificio);
                pic.Name = "pic" + i.ToString();
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
                   /* PictureBox picS2 = new PictureBox();
                    Image imgS2;*/
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
            button4_click();

        //    int t = 0;
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

        public void CALCULAR_TIEMPO_DESPLAZAMIENTOX()
        {
            // LIMPIA LOS ARRAYS Y EL CONTADOR POR SI SE HACEN VARIOS CALCULOS SIN REINICIAR LA APLICACION
            ARRAYX.Clear();
            ARRAYY.Clear();
            CONTADOR = 0;
           // pictureBox1.Image = null;
            try
            {
                // TOMA DATOS
                // Dim ALTURA_INI As Single = CSng(TextBoxALT_INI.Text)
                // Dim ALTURA_FIN As Single = CSng(TextBoxALT_FIN.Text)
                int VELOCIDAD_INI = Convert.ToInt32(textBox1.Text);
                int ANGULO = Convert.ToInt32(textBox2.Text);


                int GRAVEDAD = 10;
                // CONVERSION GRADOS A RADIANES
                int RADIANES = Convert.ToInt32(ANGULO * Math.PI) / 180;

                // DETERMINAMOS SENO Y COSENO DEL ANGULO
                int SENO = Convert.ToInt32(Math.Sin(RADIANES));

                int COSENO = Convert.ToInt32(Math.Cos(RADIANES));

                // DETERMINAMOS VECTORES VELOCIDAD INICIAL X E Y
                int VECTORY = VELOCIDAD_INI * Convert.ToInt32(SENO);
                int VECTORX = VELOCIDAD_INI * Convert.ToInt32(COSENO);


                // DETERMINAMOS LA DIFERENCIA DE ALTURAS
                // Dim DIFERENCIA_ALTURAS As Single = ALTURA_FIN - ALTURA_INI

                // SI ANGULO ES MAYOR QUE CERO
                if (ANGULO > 0)
                {

                    // DETERMINAMOS LOS DOS POSIBLES TIEMPOS QUE SALEN DE LA ECUACION BICUADRADA APLICANDO (-B +-(B^2-4AC)^0,5)/2A   YA QUE: 1/2 * g* t^2 - Voyt - Yo + Yf = 0
                    int TIEMPO1 = (VECTORY + Convert.ToInt32(Math.Sqrt((Math.Pow(VECTORY, 2))))) / GRAVEDAD;
                    int TIEMPO2 = (VECTORY - Convert.ToInt32(Math.Sqrt((Math.Pow(VECTORY, 2))))) / GRAVEDAD;
                    // TOMAREMOS EL TIEMPO EN FUNCION DE LA DIFERENCIA DE ALTURAS. LO NORMAL ES QUE LA ALTURA INICIAL SEA MAYOR O IGUAL A LA FINAL. 
                    // If ALTURA_INI >= ALTURA_FIN Then
                    // TIEMPO = Math.Max(TIEMPO1, TIEMPO2)

                    // Else
                    // TIEMPO = Math.Min(TIEMPO1, TIEMPO2)
                    // End If
                    TIEMPO = Math.Max(TIEMPO1, TIEMPO2);
                }
                else if (ANGULO == 0)
                {
                }
                else
                    MessageBox.Show("REVISA EL VALOR DEL ANGULO");

                // EL DESPLAZAMIENTO EN X ES IGUAL AL VECTORX POR EL TIEMPO
                DESPLAZAMIENTOX = VECTORX * TIEMPO;

                // CARGAMOS LOS ARRAYS DEL DESPLAZAMIENTO EN X E Y EN FUNCION DEL TIEMPO
                for (var I = 0; I <= TIEMPO; I++)
                {
                    //double a = Math.Pow(I, 2);
                    ARRAYX.Add(VECTORX * I);
                    ARRAYY.Add((VECTORY * I) - ((GRAVEDAD / (double)2) * Math.Pow(I, 2)));
                }

                // AÑADE EL RESTO DE LAS MEDIDAS EN CASO DE QUE EL TIEMPO SEA UN NUMERO DECIMAL
                int aux = Convert.ToInt32(ARRAYX[TIEMPO].ToString());
                int RESTOX = DESPLAZAMIENTOX - aux;
                if (RESTOX > 0)
                {
                    ARRAYX.Add(DESPLAZAMIENTOX);
                    ARRAYY.Add(0);
                }
                // Dim RESTOY As Single = ARRAYY(Math.Truncate(TIEMPO)) - ALTURA_FIN
                // If RESTOY > 0 Then
                // ARRAYY.Add(ALTURA_FIN)
                // End If

                // CALCULO DE LA ALTURA MAXIMA: EN EL PUNTO DE ALTURA MAXIMA LA VELOCIDAD Y = 0 : VECTORY - GRAVEDAD * TIEMPO = 0 => TIEMPO = VECTORY/GRAVEDAD
                int TIEMPOALTURAMAXIMA = VECTORY / GRAVEDAD;

                // LA ALTURA MAXIMA = ALTURA INICIAL + (VELOCIDAD MEDIA EN Y * TIEMPO EN ALCANZAR LA ALTURA MAXIMA)
                int YALTURAMAXIMA = ((VECTORY / (2 * TIEMPOALTURAMAXIMA)));

                // EL PUNTO EN X EN EL MOMENTO EN QUE LA ALTURA ES MAXIMA = VECTORX * TIEMPOALTURAMAXIMA
                int XALTURAMAXIMA = VECTORX * TIEMPOALTURAMAXIMA;
            }
            catch (Exception ex)
            {
                MessageBox.Show("REVISA LOS VALORES INICIALES");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            PictureBox PB1 = new PictureBox();
            PB1 = this.Controls.OfType<PictureBox>().FirstOrDefault(x => x.Name == "bala");

            if (CONTADOR < ARRAYX.Count)
            {
                int Xr =0;
                int Yr = 0;
                
                int auxX = Convert.ToInt32(ARRAYX[CONTADOR].ToString());
                int auxY = Convert.ToInt32(ARRAYY[CONTADOR].ToString());

                if (jugador ==  1) {
                    PictureBox SOL= new PictureBox();
                    SOL = this.Controls.OfType<PictureBox>().FirstOrDefault(x => x.Name == "PicS1");
                    Xr = auxX + SOL.Location.X;
                    Yr= auxY + SOL.Location.Y;
                }
                else
                {
                    PictureBox SOL = new PictureBox();
                    SOL = this.Controls.OfType<PictureBox>().FirstOrDefault(x => x.Name == "PicS2");
                    Xr = auxX + SOL.Location.X;
                    Yr = auxY + SOL.Location.Y;
                }
                
                PB1.Location = new Point(Xr, Yr);
                PB1.Visible = true;
                CONTADOR += 1;
            }
            else
            {
                //COLISION
                this.Controls.Remove(PB1);
                timer2.Stop();

            }
        }

        //FUNCIONA CON ENTER SOLO EN EL SEGUNDO TEXTBOX SE DISPARA LA BALA

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                CALCULAR_TIEMPO_DESPLAZAMIENTOX();
                PictureBox bala = new PictureBox();
                Image img = Image.FromFile(Directory.GetCurrentDirectory() + @"\edificios\Edificio1.png");
                bala.Name = "bala";
                bala.Size = new Size(75, 75);
                bala.Image = new System.Drawing.Bitmap(img);
                bala.SizeMode = PictureBoxSizeMode.StretchImage;
                bala.Visible = false;
                this.Controls.Add(bala);
                timer2.Start();
            }
        }
    }
}
