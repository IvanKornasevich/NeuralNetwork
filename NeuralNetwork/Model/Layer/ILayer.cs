using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    internal interface ILayer
    {
        void FeedForward();

        List<INeuron> Neurons { get; }
    }
}