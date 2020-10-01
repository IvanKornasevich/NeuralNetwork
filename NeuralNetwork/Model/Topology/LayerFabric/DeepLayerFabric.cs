using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Model.Topology.LayerFabric
{
    internal class DeepLayerFabric : ILayerFabric
    {
        public Layer Create(Layer prev, int neuronsCount, Func<double, double> activationFunction, Func<double, double> derivativeOfActivatoinFunction)
        {
            return new DeepLayer(prev, neuronsCount, activationFunction, derivativeOfActivatoinFunction);
        }
    }
}