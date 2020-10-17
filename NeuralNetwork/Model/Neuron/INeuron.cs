using NeuralNetwork.Model.Neuron.Connection;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    internal interface INeuron
    {
        double Threshold { get; set; }

        double Value { get; set; }

        void Calculate();
    }
}