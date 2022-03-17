using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using AForge.Video;
using AForge;

namespace Kamerasovellus
{
   
    public partial class Form1 : Form
    { 
        MJPEGStream stream;
        public Form1()
        {
            InitializeComponent();
            stream = new MJPEGStream("http://192.168.1.98/video.mjpg");
            stream.NewFrame += stream_NewFrame;
        } 

        void stream_NewFrame (object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bmp;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            stream.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stream.Stop();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                //Save First
                Bitmap varBmp = new Bitmap(pictureBox1.Image);
                Bitmap newBitmap = new Bitmap(varBmp);
                varBmp.Save(@"C:\Users\hho\Desktop\testikuva.png", ImageFormat.Png);
                //Now Dispose to free the memory
                varBmp.Dispose();
                varBmp = null;
            }
            else
            { MessageBox.Show("No image source."); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
