using NeuralNetwork.Model.Neuron;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Model.Layer
{
    internal interface IDeepLayer : ILayer
    {
        Func<double, double> ActivationFunction { get; }

        Func<double, double> DerivativeOfActivationFunction { get; }
    }
}