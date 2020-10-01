using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    internal class LayerTopology
    {
        internal int NeuronsCount { get; private set; }

        internal Func<double, double> ActivationFunction { get; private set; }

        internal Func<double, double> DerivativeOfActivationFunction { get; private set; }

        public LayerTopology(int neuronsCount, Func<double, double> activationFunction, Func<double, double> derivativeOfActivationFunction)
        {
            NeuronsCount = neuronsCount;
            ActivationFunction = activationFunction;
            DerivativeOfActivationFunction = derivativeOfActivationFunction;
        }
    }
}