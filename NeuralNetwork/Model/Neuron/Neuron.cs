using System;

namespace NeuralNetwork
{
    abstract internal class Neuron
    {
        protected internal double Value { get; protected set; }

        internal abstract void Calculate();
    }
}