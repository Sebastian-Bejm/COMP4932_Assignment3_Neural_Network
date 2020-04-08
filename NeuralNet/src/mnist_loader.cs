using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Numpy;

namespace NeuralNet.src
{
    class mnist_loader
    {
        public void load_data() { 
        }

        public void load_data_wrapper() { 
        }

        public NDarray vectorized_result(int j) {
            var e = np.zeros(10, 1);
            var n = e.GetData<double>();
            n[j] = 1.0;
            return n;
        }
    }
}
