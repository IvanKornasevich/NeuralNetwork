using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    internal class Connection
    {
        internal INeuron Neuron { get; private set; }

        internal double Weight { get; set; }

        public Connection(INeuron neuron, double weight = 0.5)
        {
            Neuron = neuron;
            Weight = weight;
        }
    }
}