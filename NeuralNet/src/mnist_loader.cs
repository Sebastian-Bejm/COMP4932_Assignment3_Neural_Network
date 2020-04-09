using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumSharp;
using NumSharp.Generic;

namespace NeuralNet.src
{
    class mnist_loader
    {

        private const string TrainImages = "\\Data\\train-images-idx3-ubyte\\train-images.idx3-ubyte";
        private const string TrainLabels = "\\Data\\train-labels-idx1-ubyte\\train-labels.idx1-ubyte";
        private const string TestImages = "\\Data\\t10k-images-idx3-ubyte\\t10k-images.idx3-ubyte";
        private const string TestLabels = "\\Data\\t10k-labels-idx1-ubyte\\t10k-labels.idx1-ubyte";

        public Tuple<Tuple<NDArray, NDArray>, Tuple<NDArray, NDArray>, Tuple<NDArray, NDArray>> load_data() { 
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            List<DigitImage> temp_training_data = ReadTrainingData(path).ToList();
            // validation and test data are the same
            List<DigitImage> temp_validation_data = ReadTestData(path).ToList();
            List<DigitImage> temp_test_data = ReadTestData(path).ToList();

            Tuple<NDArray, NDArray> training_data = CreateNDArrayTuple(temp_training_data); 
            Tuple<NDArray, NDArray> validation_data = CreateNDArrayTuple(temp_validation_data); 
            Tuple<NDArray, NDArray> test_data = CreateNDArrayTuple(temp_test_data); 

            return Tuple.Create(training_data, validation_data, test_data);
        }


        private Tuple<NDArray, NDArray> CreateNDArrayTuple(List<DigitImage> data)
        {
            int n = data.Count();
            var firstEntry = np.arange(n * 28 * 28).reshape(n, 28, 28); // n entries of 28*28 NDArrays
            var secondEntry = np.arange(n).reshape(n); // n entries of labels/digit

            for (int i = 0; i < data.Count(); i++)
            {
                firstEntry[i] = data[i].Data; // the 28*28 NDArray
                int val = data[i].Label; // label of the digit represented
                secondEntry[i] = val;
                
            }

            return Tuple.Create(firstEntry, secondEntry);
        }

        /*
         * Support method for reading the training data 
         */
        private IEnumerable<DigitImage> ReadTrainingData(string path)
        {
            foreach (var item in Read(path+TrainImages, path+TrainLabels))
            {
                yield return item;
            }
        }

        /*
         * Support method for reading the test data
         */
        private IEnumerable<DigitImage> ReadTestData(string path)
        {
            foreach (var item in Read(path + TestImages, path + TestLabels))
            {
                yield return item;
            }
        }        

        /*
         * Support method for reading in the data given the paths and returns it as a DigitImage 
         */
        private IEnumerable<DigitImage> Read(string imagesPath, string labelsPath)
        {
            BinaryReader images, labels;

            using (var labelStream = new FileStream(labelsPath, FileMode.Open))
            using (var imageStream = new FileStream(imagesPath, FileMode.Open))
            {
                using (labels = new BinaryReader(labelStream))
                using (images = new BinaryReader(imageStream))
                {

                    int magicImageNumber = images.ReadBigInt32(); // discard
                    int numberOfImages = images.ReadBigInt32();
                    int width = images.ReadBigInt32(); // width of image
                    int height = images.ReadBigInt32(); // height of image

                    int magicLabelsNumber = labels.ReadBigInt32(); // discard
                    int numberOfLabels = labels.ReadBigInt32(); // not needed since number of labels is the same as number of images

                    for (int i = 0; i < numberOfImages; i++)
                    {
                        var bytes = images.ReadBytes(width * height);
                        var arr = new byte[height, width];

                        arr.ForEach((j, k) => arr[j, k] = bytes[j * height + k]);

                        yield return new DigitImage()
                        {
                            Data = arr,
                            Label = labels.ReadByte()
                        };
                    }
                }
            }

        }

        public Tuple<Tuple<NDArray, NDArray>, Tuple<NDArray, NDArray>, Tuple<NDArray, NDArray>> load_data_wrapper() {

            Tuple<Tuple<NDArray, NDArray>, Tuple<NDArray, NDArray>, Tuple<NDArray, NDArray>> all_data = load_data();
            Tuple<NDArray, NDArray> tr_d = all_data.Item1; // training
            Tuple<NDArray, NDArray> va_d = all_data.Item2; // validation
            Tuple<NDArray, NDArray> te_d = all_data.Item3; // test

            // training data
            var training_inputs = tr_d.Item1;
            var training_results = tr_d.Item2;
            var vectorized_training_results = np.arange(training_results.size*10).reshape(training_results.size, 1, 10);
            
            int i = 0;
            foreach (int digit in training_results)
            {
                var vector = vectorized_result(digit);
                vectorized_training_results[i++] = vector;
            }

            Tuple<NDArray, NDArray> training_data = Tuple.Create(training_inputs, vectorized_training_results);

            // our validation and test data are already organized from load_data()

            return Tuple.Create(training_data, va_d, te_d);
        }

        public NDArray vectorized_result(int j) {
            var e = new NDArray(typeof(double), 10);
            e[j] = 1.0;
            return e;
        }
    }
}
