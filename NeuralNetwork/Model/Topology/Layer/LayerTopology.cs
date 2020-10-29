using NeuralNetwork.Model.Topology.Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    internal class LayerTopology : ILayerTopology
    {
        public int NeuronsCount { get; private set; }

        public Func<double, double> ActivFunc { get; private set; }

        public Func<double, double> DerivativeOfActivFunc { get; private set; }

        public LayerTopology(int neuronsCount, Func<double, double> activFunc, Func<double, double> derivativeOfActivFunc)
        {
            NeuronsCount = neuronsCount;
            ActivFunc = activFunc;
            DerivativeOfActivFunc = derivativeOfActivFunc;
        }
    }
}