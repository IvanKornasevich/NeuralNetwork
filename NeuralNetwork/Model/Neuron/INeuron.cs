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

        double Error { get; set; }

        double ValueBeforeActivation { get; }

        IList<IConnection> Connections { get; }

        Func<double, double> ActivFunc { get; }

        Func<double, double> DerivativeOfActivFunc { get; }

        void Calculate();
    }
}