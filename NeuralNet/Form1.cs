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
            Tuple<List<Tuple<NDArray, NDArray>>, List<Tuple<NDArray, NDArray>>, List<Tuple<NDArray, NDArray>>> tuple = ml.load_data_wrapper(); // testing for now

            List<Tuple<NDArray, NDArray>> training_data = tuple.Item1;
            List<Tuple<NDArray, NDArray>> validation_data = tuple.Item2;
            List<Tuple<NDArray, NDArray>> test_data = tuple.Item3;

            //Console.WriteLine(training_data[1].Item2.Shape);

            //Console.WriteLine(training_data.Count);
            //Console.WriteLine(validation_data.Count);
            //Console.WriteLine(test_data.Count);

            //network network = new network(new int[] {784, 30, 10});
            //network.SGD(training_data, 30, 10, 3.0, test_data);
        }
    }
}
