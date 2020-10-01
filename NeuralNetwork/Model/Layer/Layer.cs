using System.Collections.Generic;
using System.ComponentModel;

namespace NeuralNetwork
{
    internal abstract class Layer
    {
        internal List<Neuron> Neurons { get; set; }

        internal abstract void FeedForward();
    }
}