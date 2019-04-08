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
        public Form1()
        {
            InitializeComponent();
            CreaEscenario();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CreaEscenario()
        {
            string dir = Directory.GetCurrentDirectory();
            int ancho = this.Size.Width;
            var seed = Environment.TickCount;
            var random = new Random(seed);

            for (int i = 0; i < 8; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Location = new Point(20*i+100 , 570);               
                pic.Name = "pic" +i;
                pic.Size = new Size(75, 75);
                string edificio = "Edificio" + random.Next(1, 7).ToString() + ".png";
                pic.ImageLocation = dir + @"\edificios\" + edificio;
                pic.Image = new System.Drawing.Bitmap(Image.FromFile(dir + @"\edificios\" + edificio));
                pic.SizeMode = PictureBoxSizeMode.AutoSize;
                this.Controls.Add(pic);
            }

        }
    }
}
