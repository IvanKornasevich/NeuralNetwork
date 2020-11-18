using NeuralNetwork.Model.Neuron.Connection;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    internal class Connection : IConnection
    {
        public INeuron Neuron { get; private set; }

        public double Weight { get; set; }

        public Connection(INeuron neuron, double weight = 0.1)
        {
            Neuron = neuron;
            Weight = weight;
        }
    }
}