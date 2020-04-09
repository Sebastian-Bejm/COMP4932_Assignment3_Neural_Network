using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NeuralNet.src;

namespace NeuralNet
{
    public partial class Form1 : Form
    {
        mnist_loader ml = new mnist_loader();

        public Form1()
        {
            InitializeComponent();
            ml.load_data_wrapper(); // testing for now
        }
    }
}
