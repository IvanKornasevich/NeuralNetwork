using System;

namespace NeuralNetwork
{
    abstract internal class Neuron
    {
        protected internal double Value { get; protected set; }

        internal abstract void Calculate();

        protected double Sigmoid(double arg) => 1 / (1 + Math.Exp(-arg));
    }
}