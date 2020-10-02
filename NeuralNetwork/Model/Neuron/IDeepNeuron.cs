using NeuralNetwork.Model.Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Model.Neuron
{
    internal interface IDeepNeuron : INeuron
    {
        IDeepLayer LayerOfTheNeuron { get; }
    }
}