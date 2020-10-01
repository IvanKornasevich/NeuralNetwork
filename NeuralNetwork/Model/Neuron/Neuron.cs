using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    abstract internal class Neuron
    {
        internal List<Connection> Connections { get; set; }

        internal double Value { get; set; }

        internal double Threshold { get; set; }

        internal abstract void Calculate();
    }
}