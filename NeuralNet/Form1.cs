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
using System.Drawing.Imaging;

using NeuralNet.src;
using NumSharp;


namespace NeuralNet
{
    public partial class Form1 : Form
    {
        Point lastPoint = Point.Empty;
        bool isMouseDown = new bool();

        mnist_loader ml = new mnist_loader();
        network Network;
        mnist_average_darkness mad = new mnist_average_darkness();
        Dictionary<int, float> avgs;

        public List<Tuple<NDArray, NDArray>> training_data;
        public List<Tuple<NDArray, NDArray>> validation_data;
        public List<Tuple<NDArray, NDArray>> test_data;

        private string epochs, miniBatch, learnRate;

        public Form1()
        {
            InitializeComponent();
            Tuple<List<Tuple<NDArray, NDArray>>, List<Tuple<NDArray, NDArray>>, List<Tuple<NDArray, NDArray>>> tuple = ml.load_data_wrapper(); // testing for now
           
            training_data = tuple.Item1;
            validation_data = tuple.Item2;
            test_data = tuple.Item3;
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
                        Bitmap bmp = new Bitmap(280, 280);
                        pictureBox1.Image = bmp;
                    }
                    using (Graphics g = Graphics.FromImage(pictureBox1.Image)) {
                        g.DrawLine(new Pen(Color.Black, 15), lastPoint, e.Location);
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
            //Bitmap res = new Bitmap(pictureBox1.Image,pictureBox1.Image.Width / 10, pictureBox1.Height / 10);

            Bitmap res = new Bitmap(pictureBox1.Image.Width / 10, pictureBox1.Height / 10);
            using (Graphics g = Graphics.FromImage((Image)res)) {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Image.Width / 10, pictureBox1.Height / 10);
            }

            result.Image = res;

            NDArray n = res.ToNDArray(flat: false, copy:true, discardAlpha: false).reshape(28,28,4);

            NDArray rgb = n["0:28,0:28,3"];
            rgb = rgb.reshape(784,1);

            int predict = Network.evaluateSample(rgb);
            label5.Text = "Prediction: " + predict.ToString();
        }

        private void trainBtn_Click(object sender, EventArgs e)
        {
            int eps = Int32.Parse(epochs);
            int mbs = Int32.Parse(miniBatch);
            double learn = Double.Parse(learnRate);

            Network = new network(new int[] { 784,5,10});
            Network.SGD(training_data, eps, mbs, learn, test_data);
        }

        private void epochTextbox_TextChanged(object sender, EventArgs e)
        {
            epochs = epochTextbox.Text;
        }

        private void minibatchTextbox_TextChanged(object sender, EventArgs e)
        {
            miniBatch = minibatchTextbox.Text;
            //Console.WriteLine(miniBatch);
        }

        private void learnrateTextbox_TextChanged(object sender, EventArgs e)
        {
            learnRate = learnrateTextbox.Text;
            //Console.WriteLine(learnRate);
        }
    }
}
