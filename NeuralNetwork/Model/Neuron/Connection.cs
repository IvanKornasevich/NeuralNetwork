using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    internal class Connection
    {
        internal Neuron Neuron { get; private set; }

        internal double Weight { get; set; }

        public Connection(Neuron neuron, double weight = 0.5)
        {
            Neuron = neuron;
            Weight = weight;
        }
    }
}