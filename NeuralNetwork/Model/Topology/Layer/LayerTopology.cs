using NeuralNetwork.Model.Topology.Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    internal class LayerTopology : ILayerTopology
    {
        public int NeuronsCount { get; private set; }

        public Func<double, double> ActivationFunction { get; private set; }

        public Func<double, double> DerivativeOfActivationFunction { get; private set; }

        public LayerTopology(int neuronsCount, Func<double, double> activationFunction, Func<double, double> derivativeOfActivationFunction)
        {
            NeuronsCount = neuronsCount;
            ActivationFunction = activationFunction;
            DerivativeOfActivationFunction = derivativeOfActivationFunction;
        }
    }
}