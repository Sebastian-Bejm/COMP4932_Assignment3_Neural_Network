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
        private NDArray sizes;
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

        public network(NDArray size)
        {
            num_layers = size.size;
            sizes = size;
            biases = new List<NDArray>(sizes.size-1);//new int[sizes.Length-1];

            for (int y = 1; y < size.size; y++) {
                biases[y] = NumSharp.np.random.randn(y, 1);
            }

            for (int i = 0,x = 1, y = size.size-1; x < size.size; x++, y--) {
                weights[0] = NumSharp.np.random.randn(size[y], size[x]);
            }

        }

        public NDArray feedfoward(NDArray a)
        {
            for (int i = 0; i < sizes.size; i++) {
                a = sigmoid(NumSharp.np.dot(weights[i],a) + weights[i]);
            }
            return a;
        }

        //not finished translating
        public void SGD(List<Tuple<NDArray,NDArray>> training_data, int epochs, int mini_batch_size, int eta, List<Tuple<NDArray,NDArray>> test_data)
        {
            int n_test = 0;
            if (test_data != null) n_test = test_data.Count;
            int n = training_data.Count;
            
            for (int j = 0; j < epochs; j++) 
            {
                shuffle(training_data);
                
                //not sure if this is a list of list of tuples
                List<List<Tuple<NDArray,NDArray>>> mini_batches = new List<List<Tuple<NDArray, NDArray>>>();

                for (int k = 0; k < n; k+=mini_batch_size) {
                    mini_batches.Add(training_data.GetRange(k,k+mini_batch_size));
                }

                foreach (List<Tuple<NDArray,NDArray>> mini_batch in mini_batches) {
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

        public void update_mini_batch(List<Tuple<NDArray,NDArray>> mini_batch, int eta)
        {
            List<NDArray> nabla_b = new List<NDArray>();
            for (int i = 0; i < nabla_b.Count;i++) { nabla_b.Add(np.zeros(biases.ElementAt(i).Shape)); }
            
            List<NDArray> nabla_w = new List<NDArray>();
            for (int i = 0; i < nabla_w.Count; i++) { nabla_w.Add(np.zeros(weights.ElementAt(i).Shape)); }

            int count = 0;

            for (int i = 0; i < mini_batch.Count; i++) {
                Tuple<List<NDArray>, List<NDArray>> back = backprop(mini_batch[i].Item1, mini_batch[i].Item2);
                List<NDArray> delta_nabla_b = back.Item1;
                List<NDArray> delta_nabla_w = back.Item2;
                for (int j = 0; j < nabla_b.Count;j++) {
                    nabla_b[j] = nabla_b[j]+delta_nabla_b[j];
                }

                for (int j = 0; i < nabla_b.Count; j++)
                {
                    nabla_w[j] = nabla_w[j] + delta_nabla_w[j];
                }

            }

            for (int i = 0; i < weights.Count; i++) {
                weights[i] = weights[i] - (eta / mini_batch.Count) * nabla_w[i];
            }

            for (int i = 0; i < biases.Count; i++)
            {
                biases[i] = biases[i] - (eta / mini_batch.Count) * nabla_b[i];
            }
        }

        public Tuple<List<NDArray>,List<NDArray>> backprop(NDArray x, NDArray y)
        {

            List<NDArray> nabla_b = new List<NDArray>();
            for (int i = 0; i < nabla_b.Count; i++) { nabla_b.Add(np.zeros(biases[i].Shape)); }

            List<NDArray> nabla_w = new List<NDArray>();
            for (int i = 0; i < nabla_w.Count; i++) { nabla_w.Add(np.zeros(weights[i].Shape)); }

            //feedforward
            NDArray activation = x;
            List<NDArray> activations = new List<NDArray>(x);
            List<NDArray> zs = new List<NDArray>();

            for (int i = 0; i < biases.Count; i++) {
                NDArray z = NumSharp.np.dot(weights[i], activation) + biases[i];
                zs.Add(z);
                activation = sigmoid(z);
                activations.Add(activation);
            }

            //backward pass
            NDArray delta = cost_derivative(activations.Last(), y) * sigmoid_prime(zs.Last());
            nabla_b[nabla_b.Count - 1] = delta;
            nabla_w[nabla_w.Count - 1] = np.dot(delta, activations[activations.Count - 2].transpose());

            for (int l = num_layers-2; l > 0; l-=1) {
                NDArray z = zs[l];
                NDArray sp = sigmoid_prime(z);
                delta = np.dot(weights[l + 1].transpose(), delta) * sp;
                nabla_b[l] = delta;
                nabla_w[l] = np.dot(delta, activations[l - 1].transpose());
            }

            Tuple<List<NDArray>, List<NDArray>> result = new Tuple<List<NDArray>, List<NDArray>>(nabla_b,nabla_w);
            return result;
        }

        public int evaluate(List<Tuple<NDArray,NDArray>> test_data)
        {
            List<Tuple<NDArray,NDArray>> test_results = new List<Tuple<NDArray,NDArray>>();
            for(int i = 0; i < test_data.Count; i++)
            {
                NDArray x = np.argmax(feedfoward(test_data[i].Item1));
                NDArray y = test_data[i].Item2;
                test_results.Add(new Tuple<NDArray, NDArray>(x,y));
            }
            int sum = 0;
            for (int i = 0; i < test_results.Count;i++) {
                if (test_results[i].Item1 == test_results[i].Item2) {
                    sum++;
                }
            }
            return sum;
        }

        public NDArray cost_derivative(NDArray output_activations,NDArray y)
        {
            return (output_activations-y);
        }

        public NDArray sigmoid(NDArray z)
        {
            return 1.0 / (1.0 + NumSharp.np.exp(-z));
        }

        public NDArray sigmoid_prime(int z)
        {
            return sigmoid(z) * (1 - sigmoid(z));
        }
    }
}
