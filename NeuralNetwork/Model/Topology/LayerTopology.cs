using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    internal class LayerTopology
    {
        internal int NeuronsCount { get; private set; }

        internal Func<double, double> ActivationFunction { get; private set; }

        public LayerTopology(int neuronsCount, Func<double, double> activationFunction)
        {
            NeuronsCount = neuronsCount;
            ActivationFunction = activationFunction;
        }
    }
}