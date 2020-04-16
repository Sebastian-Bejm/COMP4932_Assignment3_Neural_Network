using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NumSharp;

namespace NeuralNet.src
{
    class mnist_average_darkness
    {
        public void main() { 
        }

        public Dictionary<int,float> avg_darknesses(List<Tuple<NDArray,NDArray>> training_data) {
            int[] digit_counts = new int[10];
            float[] darknesses = new float[10];

            for (int i = 0; i < training_data.Count; i++) {
                int digit = 0;
                foreach (object val in training_data[i].Item2)
                {
                    if ((double)val != 0) { break; }
                    digit++;
                }

                digit_counts[digit] += 1;
                darknesses[digit] += np.asscalar<float>(np.sum(training_data[i].Item1));
            }

            Dictionary<int, float> avgs = new Dictionary<int, float>();
            
            for (int i = 0; i < digit_counts.Length; i++) {
                avgs.Add(i, darknesses[i] / digit_counts[i]);
            }
            return avgs;
        }

        public int guess_digit(Bitmap image, Dictionary<int,float> avgs) {
            Console.WriteLine(image.Width + image.Height);
            NDArray ndarray = image.ToNDArray();
            Console.WriteLine(ndarray.Shape);
            float darkness = np.asscalar<float>(np.sum(ndarray));
            Console.WriteLine(darkness);
            Dictionary<int, float> distances = new Dictionary<int, float>();

            for (int i = 0; i < avgs.Count; i++) {
                distances.Add(i,Math.Abs(avgs[i] - darkness));
                Console.WriteLine("Digit = " + i + ", Distance = " + distances[i]);
            }

            int key = distances.First().Key;
            float min = distances.First().Value;

            foreach (KeyValuePair<int, float> kvp in distances)
            {
                if (kvp.Value < min)
                {
                    min = kvp.Value;
                    key = kvp.Key;
                }
            }

            return key;
        }
    }
}
