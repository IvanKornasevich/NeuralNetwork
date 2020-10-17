using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Model.Neuron.Connection
{
    internal interface IConnection
    {
        INeuron Neuron { get; }

        double Weight { get; set; }
    }
}