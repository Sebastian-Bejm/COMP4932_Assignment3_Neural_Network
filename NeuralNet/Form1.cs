using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NeuralNet.src;
using NumSharp;

namespace NeuralNet
{
    public partial class Form1 : Form
    {
        Point lastPoint = Point.Empty;
        bool isMouseDown = new bool();

        mnist_loader ml = new mnist_loader();

        public Form1()
        {
            InitializeComponent();
            //Tuple<List<Tuple<NDArray, NDArray>>, List<Tuple<NDArray, NDArray>>, List<Tuple<NDArray, NDArray>>> tuple = ml.load_data_wrapper(); // testing for now

            //List<Tuple<NDArray, NDArray>> training_data = tuple.Item1;
            //List<Tuple<NDArray, NDArray>> validation_data = tuple.Item2;
            //List<Tuple<NDArray, NDArray>> test_data = tuple.Item3;          

            //network network = new network(new int[] { 784, 30, 10 });
            //network.SGD(training_data, 30, 10, 3.0, test_data);
        }

        private void pictureBox1_Mouse_Down(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
            isMouseDown = true;
        }

        private void pictureBox1_Mouse_Move(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true) {
                if (lastPoint != null) {
                    if (pictureBox1.Image == null) {
                        Bitmap bmp = new Bitmap(560, 560);
                        pictureBox1.Image = bmp;
                    }
                    using (Graphics g = Graphics.FromImage(pictureBox1.Image)) {
                        g.DrawLine(new Pen(Color.Black, 2), lastPoint, e.Location);
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                    }
                    pictureBox1.Invalidate();
                    lastPoint = e.Location;
                }
            }
        }

        private void pictureBox1_Mouse_Up(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            lastPoint = Point.Empty;
        }

        private void clear(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) {
                pictureBox1.Image = null;
                pictureBox1.Invalidate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap res = new Bitmap(pictureBox1.Image,pictureBox1.Image.Width / 10 / 2, pictureBox1.Height / 10 / 2);
            result.Image = res;
            result.Invalidate();
        }
    }
}
