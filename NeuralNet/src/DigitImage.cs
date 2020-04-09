using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.src
{
    class DigitImage
    {
        public byte Label { get; set; } // label of this digit, (0, 1, ... 9)
        public byte[,] Data { get; set; } // 2d array of bytes that make up the image
    }
}
