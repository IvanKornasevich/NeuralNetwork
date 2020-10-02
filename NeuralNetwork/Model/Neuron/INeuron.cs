using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    internal interface INeuron
    {
        List<Connection> Connections { get; }

        double Threshold { get; set; }

        double Value { get; set; }

        double ValueBeforeActivation { get; }

        void Calculate();
    }
}