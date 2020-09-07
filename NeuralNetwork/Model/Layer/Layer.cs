using System.Collections.Generic;

namespace NeuralNetwork
{
    internal abstract class Layer
    {
        protected internal List<Neuron> Neurons { get; protected set; }

        abstract internal void FeedForward();
    }
}