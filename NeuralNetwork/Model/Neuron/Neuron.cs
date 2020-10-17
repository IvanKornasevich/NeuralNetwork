using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    abstract internal class Neuron : INeuron
    {
        public double Threshold { get; set; }

        public double Value { get; set; }

        public abstract void Calculate();
    }
}