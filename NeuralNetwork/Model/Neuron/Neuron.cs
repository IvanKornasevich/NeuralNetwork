using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    abstract internal class Neuron : INeuron
    {
        public List<Connection> Connections { get; private protected set; }

        public double Threshold { get; set; }

        public double Value { get; set; }

        public double ValueBeforeActivation { get; private protected set; }

        public abstract void Calculate();
    }
}