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
using NumSharp;

namespace NeuralNet
{
    public partial class Form1 : Form
    {
        mnist_loader ml = new mnist_loader();

        public Form1()
        {
            InitializeComponent();
            Tuple<Tuple<NDArray, NDArray>, Tuple<NDArray, NDArray>, Tuple<NDArray, NDArray>> tuple = ml.load_data_wrapper(); // testing for now

            Tuple<NDArray, NDArray> training_data = tuple.Item1;
            Tuple<NDArray, NDArray> validation_data = tuple.Item2;
            Tuple<NDArray, NDArray> test_data = tuple.Item3;

            network network = new network(new NDArray(784,30,10));




        }
    }
}
