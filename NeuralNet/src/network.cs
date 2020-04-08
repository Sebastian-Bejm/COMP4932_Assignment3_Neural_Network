using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumSharp;
namespace NeuralNet.src
{
    class network
    {
        private int num_layers;
        private int[] sizes;
        private List<NDArray> biases;
        private List<NDArray> weights;

        private static Random rng = new Random();

        public static void shuffle<T>(List<T> list) {
            int n = list.Count;
            while (n > 1) {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public void init(int[] size)
        {
            num_layers = size.Length;
            sizes = size;
            biases = new List<NDArray>(sizes.Length-1);//new int[sizes.Length-1];

            for (int y = 1; y < size.Length; y++) {
                biases[y] = NumSharp.np.random.randn(y, 1);
            }

            for (int i = 0,x = 1, y = size.Length-1; x < size.Length; x++, y--) {
                weights[0] = NumSharp.np.random.randn(size[y], size[x]);
            }

        }

        public NDArray feedfoward(NDArray a)
        {
            for (int i = 0; i < sizes.Length; i++) {
                a = sigmoid(NumSharp.np.dot(weights[i],a) + weights[i]);
            }
            return a;
        }

        //not finished translating
        public void SGD(List<Tuple<int,int>> training_data, int epochs, int mini_batch_size, int eta, int[] test_data)
        {
            int n_test = 0;
            if (test_data != null) n_test = test_data.Length;
            int n = training_data.Count;
            
            for (int j = 0; j < epochs; j++) 
            {
                shuffle(training_data);
                
                //not sure if this is a list of list of tuples
                List<List<Tuple<int,int>>> mini_batches = new List<List<Tuple<int, int>>>();

                for (int k = 0; k < n; k+=mini_batch_size) {
                    mini_batches.Add(training_data.GetRange(k,k+mini_batch_size));
                }

                foreach (List<Tuple<int,int>> mini_batch in mini_batches) {
                    update_mini_batch(mini_batch, eta);
                }

                if (test_data != null)
                {
                    Console.WriteLine("Epoch {}: {1} / {2}",j, evaluate(test_data),n_test);
                }
                else 
                {
                    Console.WriteLine("Epoch {0} complete", j);
                }
            }
        }

        public void update_mini_batch(List<Tuple<int,int>> mini_batch, int eta)
        {
            List<Tuple<int, int>> nabla_b = new List<Tuple<int, int>>();
            List<Tuple<int, int>> nabla_w = new List<Tuple<int, int>>();
            int count = 0;

            for (int x = 0, y = 0; x < mini_batch.Count; x++) {
                Tuple<int, int> delta_nabla_b = backprop(x, y);
                Tuple<int, int> delta_nabla_w = backprop(x, y);

            }

            foreach(Tuple<int, int> n in mini_batch) {
                //missing some stuff here
                //nabla_b[count];

            }
        }

        public Tuple<int,int> backprop(int x, int y)
        {

            //var nabla_b = NumSharp.np.zeros(biases.shape);
            //var nabla_w = NumSharp.np.zeros(weights.shape);

            List<NDArray> nabla_b = new List<NDArray>();
            for (int i = 0; i < biases.Count; i++) {
                nabla_b.Add(np.zeros(biases.ElementAt(i)));
            }

            List<NDArray> nabla_w = new List<NDArray>();
            for (int i = 0; i < biases.Count; i++)
            {
                nabla_w.Add(np.zeros(weights.ElementAt(i)));
            }

            //feedforward
            double activation = x;
            List<double> activations = new List<double>(x);
            List<NDArray> zs = new List<NDArray>();

            for (int i = 0; i < biases.Count; i++) {
                NDArray z = NumSharp.np.dot(weights.ElementAt(i), activation) + biases.ElementAt(i);
                zs.Add(z);
                activation = sigmoid(z);
                activations.Add(activation);
            }

            //backward pass
            double delta;//= cost_derivative();

            return null;
        }

        public int evaluate(int[] test_data)
        {

            return 1;
        }

        public double cost_derivative(int[] output_activations,int y)
        {
            return 1;
        }

        public double sigmoid(NDArray z)
        {
            return 1.0 / (1.0 + NumSharp.np.exp(-z));
        }

        public double sigmoid_prime(int z)
        {
            return sigmoid(z) * (1 - sigmoid(z));
        }
    }
}
