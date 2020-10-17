using NeuralNetwork.Model.Layer;
using NeuralNetwork.Model.Neuron.Connection;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Model.Neuron
{
    internal interface IDeepNeuron : INeuron
    {
        IDeepLayer LayerOfTheNeuron { get; }

        IList<IConnection> Connections { get; }

        double ValueBeforeActivation { get; }

        double Error { get; set; }
    }
}