using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//python libraries
using NumSharp;
using Keras;
#if true
#else
#endif
namespace NeuralNet.src
{
    class network3
    {
        public const bool GPU = true;
        //if(GPU == true){
        //}

    }

    class Network
    {
        public void init(int self, int layers, int mini_batch_size) {
        }
    }

    class ConvPoolLayer {
        //self in python is just used to reference the instance of class to reference methods and attributes of class
        public Tuple<int> self_filter_shape;
        public Tuple<int> self_image_shape;
        public Tuple<int> self_poolsize;

        public void init(Tuple<int> filter_shape, Tuple<int> image_shape, Tuple<int> poolsize) {
            self_filter_shape = filter_shape;
            self_image_shape = image_shape;
            self_poolsize = poolsize;

        }
    }
}
