using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Model.Topology.LayerFabric
{
    internal class InputLayerFabric : ILayerFabric
    {
        public Layer Create(Layer prev, int neuronsCount, Func<double, double> activationFunction, Func<double, double> derivativeOfActivatoinFunction)
        {
            return new InputLayer(neuronsCount);
        }
    }
}